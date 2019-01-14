// Include Libraries
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_LIS3DH.h>
#include <Adafruit_Sensor.h>


// Declare Output Pin
#define cameraTrig_Pin 34
#define LedTrig_Pin 39
#define DaqTrig_Pin 30
#define currentOut_Pin A22
#define connected_Pin 5

// Declare Input Pin
#define cameraOn_Pin 32

// Input Pin to measure acceleration
#define LIS3DH_CLK 7
#define LIS3DH_MISO 9
#define LIS3DH_MOSI 8
#define LIS3DH_CS 10

// Declare variable for sub-microsecond time feature
#define NOP6 "nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t"
#define NOP8 "nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t"
#define NOP12 "nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t""nop\n\t"
#define P5 __asm__(NOP12 NOP12 NOP12 NOP12 NOP12 NOP12 NOP8 NOP6)  // P5 corresponds to 0.5us
#define PAUSE P5


// Declare Variable
int cameraState = 0;    // camera exposure is on or not
int lastCamState = 0;   // check last camera state

bool newCmd = false;
bool connection = false;  // connected to Python or not
bool triggerWait = false; // waiting for auto trigger or not
bool triggered = false;   // experiment triggered or not
bool lastTriggerCountState = false;   // true if acceleration is in range and counting, false otherwise 
bool LedTrig = false;  // trigger the LED or not
bool LedOn = false;   // Led is set to on or not

float acceleration[3];    // acceleration
float LedOnDuration = 1.0;  // LED on time for each camera exposure cycle (us)
float currentOut = 50.0;  // current out for Thorlabs (mA)
float acceLimit1 = 0.0;    // low acceleration limit that trigger the measurement (m/s^2)
float acceLimit2 = 0.0;    // high acceleration limit that trigger the measurement (m/s^2)
float acceTotal = 0.0;    // Total acceleration
float LedInterval = 105;    // Interval between two consecutive Led trigger, generraly equals exposure time of the camera.
float camInterval = 1000;  // Interval between two consecutive cam trigger in microseconds
float camTriggerCount = 0; // Numbers of time camera was triggered
float expBufferTime = 50; // Buffer time before before starting and ending point of the experiment

long triggerWaitDuration = 4000;  // experiment will trigger if acceleration falls into range for this long (ms)
long triggerWaitStartTime = 0;    // the moment
long expDuration = 1000;     // run time of the experiment (ms)
long expStartTime = 0;    // time start of the experiment (ms)
long LedLastTime = 0;    // time LED starts lighting (us)
long previousAcceTime = 0;  // store the last time acce is updated
long acceInterval = 200;  // time between acceleration updates
long lastCamTime = 0; // store the last time a new camera frame is triggered

const byte numChars = 20; // number of characters for Serial command
char receivedCmd[numChars]; // Serial command received from Python
char acceString[8]; // Print the acceleration

Adafruit_LIS3DH lis = Adafruit_LIS3DH(LIS3DH_CS, LIS3DH_MOSI, LIS3DH_MISO, LIS3DH_CLK);


#if defined(ARDUINO_ARCH_SAMD)
// for Zero, output on USB Serial console, remove line below if using programming port to program the Zero!
#define Serial SerialUSB
#endif

void setup()
{
#ifndef ESP8266
  while (!Serial);     // will pause Zero, Leonardo, etc until serial console opens
#endif

  pinMode(cameraTrig_Pin, OUTPUT);
  pinMode(LedTrig_Pin, OUTPUT);
  pinMode(DaqTrig_Pin, OUTPUT);
  pinMode(currentOut_Pin, OUTPUT);

  pinMode(cameraOn_Pin, INPUT);

  lis.setRange(LIS3DH_RANGE_4_G);
  if (!lis.begin(0x18))
  {
    Serial.println("Couldn't find accellerometer!");
    while (1);
  }

  if (!Serial)
  {
    // resetParameters();
  }

  Serial.begin(9600);

}

void loop() {
  if (Serial.available() > 0) { recvCommand(); }
  if (newCmd) { processCmd(); }
  if (connection == true)
  {
    if (LedOn == true) { triggerLED(); }
    acceRead();
    checkTrigger();
    sendOutput();
  }
}


/****************************
* This function read and print the acceleration value
*/
void acceRead()
{

  unsigned long currentMillis = millis();
  if (currentMillis - previousAcceTime > acceInterval)
  {
    // This part reads the acceleration
    lis.read();
    sensors_event_t event;
    lis.getEvent(&event);
    float ax = event.acceleration.x;
    float ay = event.acceleration.y;
    float az = event.acceleration.z;
    acceTotal = sqrt(pow(ax, 2) + pow(ay, 2) + pow(az, 2));

    // acceTotal = 0.00;
    // This part prints the acceleration
    dtostrf(acceTotal, 4, 2, acceString);
    previousAcceTime = currentMillis;
    Serial.println(acceString);
  }
}


/***********************
* This function sends out the initial message
*/
void sendStartMessage()
{
  Serial.println("Controller found!");
  Serial.println("Waiting for commands!");
  Serial.println("Accelerometer found!");
  Serial.print("Range = "); Serial.print(2 << lis.getRange());
  Serial.println("G");
}


/***********************
* This function takes serial input and looks for data between a start and end marker
*/
void recvCommand()
{
  static boolean recvInProgress = false;
  static byte index = 0;
  char startMarker = '<';
  char endMarker = '>';

  char receive;

  if (Serial.available() > 0)
  {
    receive = Serial.read();
    if (recvInProgress == true)
    {
      if (receive != endMarker)
      {
        receivedCmd[index] = receive;
        index++;
        if (index >= numChars) { index = numChars - 1; }
      }
      else
      {
        receivedCmd[index] = '\0'; // terminate the string
        recvInProgress = false;
        index = 0;
        newCmd = true;
      }
    }
    else if (receive == startMarker) { recvInProgress = true; }
  }
}


/******************************
* This function process command
*/
void processCmd()
{
  newCmd = false;
  // This checks connection between Python and controller
  if (strcmp(receivedCmd, "HELLO") == 0)
  {
    Serial.println("HELLO");
  }

  // This displays the inital message on the GUI
  if (strcmp(receivedCmd, "START") == 0)
  {
    connection = true;
    sendStartMessage();
  }

  // This stops all operation
  if (strcmp(receivedCmd, "STOP") == 0)
  {
    Serial.println("Experiment stopped!");
    triggered = false;
    triggerWait = false;
    lastTriggerCountState = false;
  }

  // This turns on the LED
  if (strcmp(receivedCmd, "LEDON") == 0)
  {
    Serial.println("LED on!");
    LedOn = true;
    LedLastTime = micros();
  }

  // This turns off the LED
  if (strcmp(receivedCmd, "LEDOFF") == 0)
  {
    Serial.println("LED off!");
    LedOn = false;
  }

  // This disconnect the micro-controller from the GUI
  if (strcmp(receivedCmd, "DISCONNECT") == 0)
  {
    connection = false;
    resetParameters();
  }

  // This receives Auto Triggering Mode
  if (strcmp(receivedCmd, "WAIT") == 0)
  {
    triggerWait = true;
    Serial.println("Waiting for acceleration");
  }

  // This receives Manual Trigger Mode
  if (strcmp(receivedCmd, "STARTEXP") == 0)
  {
    triggered = true;
    expStartTime = millis();
    Serial.println("Experiment started manually!");
    lastTriggerCountState = false;
    //Serial.println(expStartTime);
  }

  // This receives LED On time
  if (receivedCmd[0] == 'B') // B for brightness
  {
    if (receivedCmd[1] == '0') { LedOnDuration = 1.0; }
    else if (receivedCmd[1] == '1') { LedOnDuration = 2.0; }
    else if (receivedCmd[1] == '2') { LedOnDuration = 3.0; }
  }

  // This receives Experiment Run Time
  if (receivedCmd[0] == 'T')
  {
    if (receivedCmd[1] == '0') { expDuration = 500; }
    else if (receivedCmd[1] == '1') { expDuration = 1000; }
    else if (receivedCmd[1] == '2') { expDuration = 1500; }
  }

  // This receives Camera frame per second
  if (receivedCmd[0] == 'F')
  {
    if (receivedCmd[1] == '0') { camInterval = 1000; }
    else if (receivedCmd[1] == '1') { camInterval = 625; }
  }

  // This receive output current to Thorlabs
  if (receivedCmd[0] == 'c')
  {
    char* strtokIndx;
    strtokIndx = strtok(receivedCmd, "_");
    strtokIndx = strtok(NULL, "_");
    currentOut = atof(strtokIndx);
  }

  // This receives low acceleration limit to trigger the experiment
  if (receivedCmd[0] == 'a')
  {
    char* strtokIndx;
    strtokIndx = strtok(receivedCmd, "_");
    strtokIndx = strtok(NULL, "_");
    acceLimit1 = atof(strtokIndx);
    //Serial.println(acceLimit);
  }

  // This receives high acceleration limit to trigger the experiment
    if (receivedCmd[0] == 'b')
  {
    char* strtokIndx;
    strtokIndx = strtok(receivedCmd, "_");
    strtokIndx = strtok(NULL, "_");
    acceLimit2 = atof(strtokIndx);
    //Serial.println(acceLimit);
  }
}


/**********************************
* This function trigger the LED
*/
void triggerLED()
{
  if (LedOn == true)
  {
    LedTrig = false;
    /***
    long currentLedTime = micros();
    {
    if (currentLedTime - LedLastTime > LedInterval - LedOnDuration)
    {
    LedTrig = true;
    }
    }
    */
    cameraState = digitalRead(cameraOn_Pin);
    if (cameraState != lastCamState)
    {
      if (cameraState == HIGH)
      {
        LedTrig = true;
      }
    }
    lastCamState = cameraState;

    if (LedTrig == true)
    {
      if (LedOnDuration == 1.0)
      {
        noInterrupts();
        digitalWriteFast(LedTrig_Pin, HIGH);
        PAUSE;
        PAUSE;
        digitalWriteFast(LedTrig_Pin, LOW);
        interrupts();
      }
      else if (LedOnDuration == 2.0)
      {
        noInterrupts();
        digitalWriteFast(LedTrig_Pin, HIGH);
        PAUSE;
        PAUSE;
        PAUSE;
        PAUSE;
        digitalWriteFast(LedTrig_Pin, LOW);
        interrupts();
      }
      else if (LedOnDuration == 3.0)
      {
        noInterrupts();
        digitalWriteFast(LedTrig_Pin, HIGH);
        PAUSE;
        PAUSE;
        PAUSE;
        PAUSE;
        PAUSE;
        PAUSE;
        digitalWriteFast(LedTrig_Pin, LOW);
        interrupts();
      }
      LedLastTime = micros();
    }
  }
}

/**********************************
* This function trigger Camera
*/
void triggerCam()
{
  unsigned long currentCamTime = micros();
  if ((currentCamTime - lastCamTime > camInterval / 4) && (currentCamTime - lastCamTime < camInterval))
  {
    digitalWrite(cameraTrig_Pin, LOW);
  }
  else if (currentCamTime - lastCamTime > camInterval)
  {
    digitalWrite(cameraTrig_Pin, HIGH);
    lastCamTime = currentCamTime;
    // camTriggerCount = camTriggerCount+1;
  }
}

/**********************************
* This function send Output signal
*/
void sendOutput()
{
  if (connection == true)
  {
    digitalWrite(connected_Pin, HIGH);
  }

  if (triggered == true)
  {
    triggerWait = false;
    unsigned long currentExpTime = millis();
    // send out signal
    digitalWrite(DaqTrig_Pin, HIGH);
    triggerCam();
    if ((currentExpTime - expStartTime > expBufferTime) && (currentExpTime - expStartTime < expDuration - expBufferTime))
    {
      float outputVolt = currentOut / 200;
      float Vout = outputVolt / 53 * 4096;
      analogWrite(currentOut_Pin, Vout);
    }
    else
    {
      analogWrite(currentOut_Pin, 0);
    }

    // when to turn off the exp
    if ((currentExpTime - expStartTime) > expDuration)
    {
      Serial.println("Experiment stopped!");
      //Serial.println(camTriggerCount);
      //camTriggerCount = 0;
      triggered = false;
    }
  }
  else
  {
    digitalWrite(DaqTrig_Pin, LOW);
    digitalWrite(cameraTrig_Pin, LOW);
    analogWrite(currentOut_Pin, 0);
  }
}


/************************************
* This function check trigger condition in Auto Triggering Mode
*/

void checkTrigger()
{
  if (triggerWait == true)
  {
    // This checks when to start counting time
    bool triggerCountState = false;
    if (abs(acceTotal) < acceLimit2 && abs(acceTotal) > acceLimit1)
    {
      triggerCountState = true;
    }
    if (triggerCountState != lastTriggerCountState)
    {
      if (triggerCountState == true)
      {
        triggerWaitStartTime = millis();
        //Serial.println(triggerWaitStartTime);
      }
    }
    lastTriggerCountState = triggerCountState;

    // This checks when sufficient time to trigger
    if (triggerCountState == true)
    {
      unsigned long triggerWaitTime = millis();
      if (triggerWaitTime - triggerWaitStartTime > triggerWaitDuration)
      {
        triggerWait = false;
        triggered = true;
        expStartTime = millis();
        Serial.println("Experiment started automatically!");
        //Serial.println(expStartTime);
        lastTriggerCountState = false;
      }
    }
  }
}

/******************************************
* This function reset all parameters of the controller. Executed when controller disconnected from pc.
*/
void resetParameters()
{
  bool newCmd = false;
  bool connection = false;  // connected to Python or not
  bool triggerWait = false; // waiting for auto trigger or not
  bool triggered = false;   // experiment triggered or not
  bool lastTriggerCountState = false;   // true if acceleration is in range and counting, false otherwise 
  bool LedTrig = false;  // trigger the LED or not
  bool LedOn = false;   // Led is set to on or not
  
  float acceleration[3];    // acceleration
  float LedOnDuration = 1.0;  // LED on time for each camera exposure cycle (us)
  float currentOut = 50.0;  // current out for Thorlabs (mA)
  float acceLimit1 = 0.0;    // low acceleration limit that trigger the measurement (m/s^2)
  float acceLimit2 = 0.0;    // high acceleration limit that trigger the measurement (m/s^2)
  float acceTotal = 0.0;    // Total acceleration
  float LedInterval = 105;    // Interval between two consecutive Led trigger, generraly equals exposure time of the camera.
  float camInterval = 1000;  // Interval between two consecutive cam trigger in microseconds
  float camTriggerCount = 0; // Numbers of time camera was triggered
  float expBufferTime = 50; // Buffer time before before starting and ending point of the experiment
  
  long triggerWaitDuration = 4000;  // experiment will trigger if acceleration falls into range for this long (ms)
  long triggerWaitStartTime = 0;    // the moment
  long expDuration = 1000;     // run time of the experiment (ms)
  long expStartTime = 0;    // time start of the experiment (ms)
  long LedLastTime = 0;    // time LED starts lighting (us)
  long previousAcceTime = 0;  // store the last time acce is updated
  long acceInterval = 200;  // time between acceleration updates
  long lastCamTime = 0; // store the last time a new camera frame is triggered
}

