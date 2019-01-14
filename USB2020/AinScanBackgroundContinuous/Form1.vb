Imports System.IO
Imports System.IO.Ports

Public Class Form1

    'Initate the GUI and set the default input value
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'First Lets make sure there's a USB-2020 plugged in:
        MccDaq.DaqDeviceManager.IgnoreInstaCal() 'don't use information from InstaCal.

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor 'change cursor to wait.
        Dim Boardfound As Boolean = False

        'load all the boards it can find
        inventory = MccDaq.DaqDeviceManager.GetDaqDeviceInventory(MccDaq.DaqDeviceInterface.Any)

        Dim numDevDiscovered As Integer = inventory.Length 'how many was that?

        If numDevDiscovered > 0 Then
            For boardNum As Integer = 0 To numDevDiscovered - 1

                Try
                    '    Create a new MccBoard object for Board and assign a board number 
                    '    to the specified DAQ device with CreateDaqDevice()
                    Daqboard = MccDaq.DaqDeviceManager.CreateDaqDevice(boardNum, inventory(boardNum))

                    If Daqboard.BoardName.Contains("2020") Then
                        Boardfound = True
                        Daqboard.FlashLED()
                        Exit For
                    Else
                        MccDaq.DaqDeviceManager.ReleaseDaqDevice(Daqboard)
                    End If
                Catch ule As MccDaq.ULException
                    MsgBox(ule.ErrorInfo.Message)
                End Try
            Next
        End If

        If Boardfound = False Then
            MsgBox("No USB-2020 board found in system.  Please run InstaCal.", MsgBoxStyle.Critical, "No Board detected")
            End
        End If

        Dim mystring As String = Daqboard.BoardName.Substring(0, Daqboard.BoardName.Trim.Length - 1) +
            " found as board number: " + Daqboard.BoardNum.ToString
        Me.Text = mystring

        Timer2.Enabled = True

        'Initialize some of the objects on the form
        LoadComboBox(cmboAInScanRange)
        AInScanRange = MccDaq.Range.Bip10Volts
        rate_comBox.SelectedIndex = 1

        Daqboard.BoardConfig.GetNumAdChans(numchannels)
        nudLowChannel.Maximum = numchannels - 1
        nudHighChannel.Maximum = numchannels - 1

        ' This part initializes the control for teensy
        expDuration_comBox.SelectedIndex = 0
        camFps_comBox.SelectedIndex = 0
        LedDuration_comBox.SelectedIndex = 0
        currentOut_txtBox.Text = "50"
        acceTrigger1_txtBox.Text = "0"
        acceTrigger2_txtBox.Text = "0.2"
        Timer1.Enabled = False
        populateComPort()
        chkExtTrigger.Checked = True


    End Sub

    ' This part helps with resizing the windows
    Dim curWidth As Integer = Me.Width
    Dim curHeight As Integer = Me.Height

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim ratioHeight As Double = (Me.Height - curHeight) / curHeight
        Dim ratioWidth As Double = (Me.Width - curWidth) / curWidth

        For Each Ctrl As Control In Controls
            Ctrl.Width += Ctrl.Width * ratioWidth
            Ctrl.Left += Ctrl.Left * ratioWidth
            Ctrl.Top += Ctrl.Top * ratioHeight
            Ctrl.Height += Ctrl.Height * ratioHeight
        Next

        curHeight = Me.Height
        curWidth = Me.Width
    End Sub

    '##########################################################################################################
    '##########################################################################################################
    ' THIS PART CONTROL THE MICROCONTROLLER TEENSY 3.6

    Dim comPort As String
    Dim receivedData As String = ""
    Dim connected As Boolean = False
    Dim count = 0
    Dim acceTotal As String = "0"
    Dim messageOut As String = ""

    'Refresh button refresh COM ports
    Private Sub refreshCom_Btn_Click(sender As Object, e As EventArgs) Handles refreshCom_Btn.Click
        SerialPort1.Close()
        populateComPort()
    End Sub

    Private Sub populateComPort()
        comPort = ""
        comPort_comBox.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            comPort_comBox.Items.Add(sp)
        Next
    End Sub

    Private Sub comPort_comBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPort_comBox.SelectedIndexChanged
        If (comPort_comBox.Text <> "") Then
            comPort = comPort_comBox.SelectedItem
        End If
    End Sub



    ' When the Connect button is clicked, if a COM port has been selected, connect and send out HELLO message
    ' Then wait for the controller to respond
    ' When the HELLO is receive and we are connected, change the button text to Disconnect
    Private Sub connect_Btn_Click(sender As Object, e As EventArgs) Handles connect_Btn.Click
        comPort = comPort_comBox.SelectedItem
        If (connect_Btn.Text = "Connect") Then
            If (comPort <> "") Then
                SerialPort1.Close()
                SerialPort1.PortName = comPort
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default
                SerialPort1.ReadTimeout = 10000

                SerialPort1.Open()
                ' See if the controller is there
                count = 0
                SerialPort1.WriteLine("<DISCONNECT>")
                SerialPort1.WriteLine("<HELLO>")
                connect_Btn.Text = "Connecting..."
                connecting_Timer.Enabled = True
            Else
                MsgBox("Select a COM port first")
            End If
        Else
            ' When the controller has been connected, change the connect to disconnect
            ' close the connection and reset the button and timer label
            Timer1.Enabled = False
            SerialPort1.WriteLine("<DISCONNECT>")
            SerialPort1.Close()
            connected = False
            connect_Btn.Text = "Connect"
            start_Btn.Text = "Start"
            RichTextBox1.Text = RichTextBox1.Text & "Device disconnected" & vbCrLf
            populateComPort()
        End If

    End Sub

    ' The connecting_Timer waits for the controller to respond.
    ' If respond is not received in 2 seconds display an error message.
    ' The connecting_Timer is only used for connecting
    Private Sub connecting_Timer_Tick(sender As Object, e As EventArgs) Handles connecting_Timer.Tick
        connecting_Timer.Enabled = False
        count = count + 1

        If (count <= 8) Then
            receivedData = receivedData & ReceiveSerialData()

            If (Microsoft.VisualBasic.Left(receivedData, 5) = "HELLO") Then
                connected = True
                connect_Btn.Text = "Disconnect"
                Timer1.Enabled = True
                receivedData = ReceiveSerialData()
                receivedData = ""
                SerialPort1.WriteLine("<START>")
            Else
                ' Start the timer again
                connecting_Timer.Enabled = True
            End If

        Else
            ' time out (8 * 250 = 2 seconds)
            RichTextBox1.Text &= vbCrLf & "ERROR" & vbCrLf & "Cannot connect" & vbCrLf
            connect_Btn.Text = "Connect"
            populateComPort()
        End If

    End Sub


    ' After connection is made, the timer waits for data from the controller
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        receivedData = ReceiveSerialData()
        If receivedData <> "" Then
            If IsNumeric(receivedData) = True Then
                acceTotal = receivedData
                RichTextBox2.Text = acceTotal(0) & acceTotal(1) & acceTotal(2) & acceTotal(3)
            Else
                messageOut = receivedData
                RichTextBox1.Text &= messageOut
                If messageOut = "Experiment stopped!" Then
                    start_Btn.Text = "Start"
                End If
            End If
        End If

    End Sub

    ' Function to receive Serial data
    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function

    Private Sub clear_Btn_Click(sender As Object, e As EventArgs) Handles clear_Btn.Click
        RichTextBox1.Text = ""
    End Sub


    ' Declare command function to receive experiment input

    Function getExpDuration()
        If expDuration_comBox.SelectedIndex = 0 Then
            SerialPort1.WriteLine("<T0>")
        ElseIf expDuration_comBox.SelectedIndex = 1 Then
            SerialPort1.WriteLine("<T1>")
        ElseIf expDuration_comBox.SelectedIndex = 2 Then
            SerialPort1.WriteLine("<T2>")
        End If
    End Function

    Function getCamFPS()
        If camFps_comBox.SelectedIndex = 0 Then
            SerialPort1.WriteLine("<F0>")
        ElseIf camFps_comBox.SelectedIndex = 1 Then
            SerialPort1.WriteLine("<F1>")
        End If
    End Function

    Function getLedDuration()
        If LedDuration_comBox.SelectedIndex = 0 Then
            SerialPort1.WriteLine("<B0>")
        ElseIf LedDuration_comBox.SelectedIndex = 1 Then
            SerialPort1.WriteLine("<B1>")
        ElseIf LedDuration_comBox.SelectedIndex = 2 Then
            SerialPort1.WriteLine("<B2>")
        End If
    End Function

    Function getCurrent()
        Dim currentOut = currentOut_txtBox.Text
        Dim currentData As String
        Dim currentOutDouble = Convert.ToDouble(currentOut)
        currentData = "<c_" & Format(currentOutDouble, "###00") & ">"
        SerialPort1.WriteLine(currentData)
    End Function

    Function getAcceLim()
        Dim acceLim1 = acceTrigger1_txtBox.Text
        Dim acceLim2 = acceTrigger2_txtBox.Text
        Dim acceLimData1 As String
        Dim acceLimData2 As String
        Dim acceLimDouble1 = Convert.ToDouble(acceLim1)
        Dim acceLimDouble2 = Convert.ToDouble(acceLim2)
        acceLimData1 = "<a_" & Format(acceLimDouble1 * 9.81, "###0.0") & ">"
        acceLimData2 = "<b_" & Format(acceLimDouble2 * 9.81, "###0.0") & ">"
        SerialPort1.WriteLine(acceLimData1)
        SerialPort1.WriteLine(acceLimData2)
    End Function


    ' When the "Start" button is pressed, transfer all input parameter to the controller
    ' and enable manual trigger mode
    Private Sub start_Btn_Click(sender As Object, e As EventArgs) Handles start_Btn.Click
        If (connected) Then
            If start_Btn.Text = "Start" Then
                start_Btn.Text = "Manual Trigger"
                SerialPort1.WriteLine("<WAIT>")
                getExpDuration()
                getAcceLim()
                getCurrent()
                getLedDuration()
                getCamFPS()
            ElseIf start_Btn.Text = "Manual Trigger" Then
                SerialPort1.WriteLine("<STARTEXP>")
                start_Btn.Text = "Start"
            End If
        Else
            MsgBox("Not connected")
        End If
    End Sub

    Private Sub LedOn_Btn_Click(sender As Object, e As EventArgs) Handles LedOn_Btn.Click
        If (connected) Then
            If LedOn_Btn.Text = "LED On" Then
                LedOn_Btn.Text = "LED Off"
                getLedDuration()
                SerialPort1.WriteLine("<LEDON>")
            ElseIf LedOn_Btn.Text = "LED Off" Then
                LedOn_Btn.Text = "LED On"
                SerialPort1.WriteLine("<LEDOFF>")
            End If
        Else
            MsgBox("Not connected")
        End If
    End Sub

    Private Sub stop_Btn_Click(sender As Object, e As EventArgs) Handles stop_Btn.Click
        If (connected) Then
            start_Btn.Text = "Start"
            SerialPort1.WriteLine("<STOP>")
        Else
            MsgBox("Not connected")
        End If
    End Sub


    ' ####################################################################################################'
    ' ####################################################################################################'
    ' THIS PART CONTROL THE DATA ACQUISTION BOARD USB2020

    Dim inventory As MccDaq.DaqDeviceDescriptor()
    Public Daqboard As New MccDaq.MccBoard()
    Dim ulstat As MccDaq.ErrorInfo
    Public AIMhandle As IntPtr
    Dim AINumPoints As Integer
    Dim numpoints As Integer
    Dim numchannels As Integer
    Dim AInScanRange As MccDaq.Range
    Dim LastPass As String = "Upper"
    Public ADDataV() As Double
    Dim j As Integer
    Dim CurIndex As Integer
    Dim CurCount As Integer
    Dim AIStatus As Short
    Dim ChannelCount As Integer

    Dim arrayindex As Integer
    Dim m2DRows As Integer
    Dim rows, cols As Integer
    Dim twoDData(,) As Double
    Dim expTime As Double
    Dim currentTime As String

    Const AllowedCharactersInt As String = "0123456789"
    Const AllowedCharactersFloat As String = "0123456789."

    Private Sub KeyPressService(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal charSet As String)
        'this sub is here to make sure the user only enters an allowed character based upon the constants above.
        If Not charSet.Contains(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtFilePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnAInStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAInStartStop.Click
        If btnAInStartStop.Text = "Start DAQ" Then
            If txtFilePath.Text = "" Then
                MsgBox("Please select folder")
            Else
                btnAInStartStop.Text = "Stop"
                Me.Refresh()
                Call RunAdc()
            End If
        Else
            btnAInStartStop.Text = "Start DAQ"
            tmrAtoD.Enabled = False
            ulstat = Daqboard.StopBackground(MccDaq.FunctionType.AiFunction)
            If ulstat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            lblAIMode.Text = "Idle"
            ulstat = MccDaq.MccService.WinBufFreeEx(AIMhandle) ' Free up memory for use by other programs
        End If
    End Sub

    Public Sub RunAdc()
        Dim AInOptions As MccDaq.ScanOptions
        Dim LowChannelNumber, HighChannelNumber As Integer
        Dim ADRate As Integer

        'read in the channel configuration, and check to make sure they are correct
        Integer.TryParse(nudLowChannel.Value, LowChannelNumber)
        Integer.TryParse(nudHighChannel.Value, HighChannelNumber)
        ChannelCount = HighChannelNumber - LowChannelNumber + 1
        If ChannelCount <= 0 Then
            MessageBox.Show(" Low channel selected is higher than High channel selected", "Invalid Channel Number ",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnAInStartStop.Text = "Start DAQ"
            Exit Sub
        End If

        'read in the sampling rate/channel
        If rate_comBox.SelectedIndex = 0 Then
            ADRate = 5000000
        ElseIf rate_comBox.SelectedIndex = 1 Then
            ADRate = 10000000
        ElseIf rate_comBox.SelectedIndex = 2 Then
            ADRate = 15000000
        End If

        'read in the number of samples/channel,
        If expDuration_comBox.SelectedIndex = 0 Then
            expTime = 0.5
        ElseIf expDuration_comBox.SelectedIndex = 1 Then
            expTime = 1.0
        ElseIf expDuration_comBox.SelectedIndex = 2 Then
            expTime = 1.5
        End If

        AINumPoints = ADRate * expTime
        numpoints = AINumPoints
        AINumPoints = AINumPoints * ChannelCount

        'Try
        '    Integer.TryParse(txtNumSamples.Text, AINumPoints)
        '    numpoints = AINumPoints
        '    AINumPoints = AINumPoints * ChannelCount
        'Catch ex As Exception
        '    MessageBox.Show(txtRate.Text + " is not a valid number of points value", "Invalid count ",
        '                    MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    btnAInStartStop.Text = "Start"
        '    Exit Sub
        'End Try

        'set up sample count and redim arrays
        ReDim ADDataV((ChannelCount) * (numpoints - 1))
        ReDim twoDData((ChannelCount - 1), (Math.Truncate(numpoints) - 1)) '/ ChannelCount)

        ' set aside memory to hold data
        AIMhandle = MccDaq.MccService.ScaledWinBufAllocEx(AINumPoints)
        If AIMhandle = 0 Then Stop


        'Try
        '    Integer.TryParse(txtRate.Text, ADRate)
        'Catch
        '    MessageBox.Show(txtNumSamples.Text + " is not a valid rate value", "Invalid Rate Number ", _
        '        MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    btnAInStartStop.Text = "Start"
        '    Exit Sub
        'End Try

        'read in the range
        AInScanRange = SelectRange(cmboAInScanRange.SelectedIndex)
        Oscilloscope1.YMaximum = OsciRange(cmboAInScanRange.SelectedIndex)
        Oscilloscope1.YMinimum = -OsciRange(cmboAInScanRange.SelectedIndex)

        'Set scan options
        AInOptions = MccDaq.ScanOptions.Background + MccDaq.ScanOptions.ScaleData
        'If ADRate > 8000000 Then 
        AInOptions += MccDaq.ScanOptions.BurstIo
        If chkExtTrigger.Checked Then AInOptions += MccDaq.ScanOptions.ExtTrigger

        'Start the scan
        ulstat = Daqboard.AInScan(LowChannelNumber, HighChannelNumber, AINumPoints,
             ADRate, AInScanRange, AIMhandle, AInOptions)
        If ulstat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            errhandler(ulstat)
            Exit Sub
        End If

        'Start the timer
        tmrAtoD.Enabled = True

    End Sub

    Public Sub errhandler(ByVal ulstat As MccDaq.ErrorInfo)
        'Generic UL error handler
        MessageBox.Show(ulstat.Message, "Universal Library Error ",
                   MessageBoxButtons.OK, MessageBoxIcon.Error)
        lblAIMode.Text = "Idle"
        btnAInStartStop.Text = "Start DAQ"
        ulstat = Daqboard.StopBackground(MccDaq.FunctionType.AiFunction)
        ulstat = MccDaq.MccService.WinBufFreeEx(AIMhandle) ' Free up memory for use by other programs
    End Sub

    Private Sub tmrAtoD_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAtoD.Tick


        'At every timer tick, we find out where we are, we do this by checking the CurIndex (current Index)
        ulstat = Daqboard.GetStatus(AIStatus, CurCount, CurIndex, MccDaq.FunctionType.AiFunction)
        If ulstat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            errhandler(ulstat)
            Exit Sub
        End If

        lblAIShowCount.Text = CurCount.ToString()
        lblAICurIndex.Text = CurIndex.ToString()
        If AIStatus = MccDaq.MccBoard.Running Then lblAIMode.Text = "Running"

        If CurCount = numpoints Then
            'AIStatus = "Idle"
            tmrAtoD.Enabled = False
            btnAInStartStop.Text = "Start DAQ"
            ConvertData()
            Exit Sub
        End If

        'what to do if the scan stops....
        If (AIStatus = MccDaq.MccBoard.Idle) Then
            btnAInStartStop.Text = "Start DAQ"
            lblAIMode.Text = "Idle"
            tmrAtoD.Enabled = False
            ConvertData()
            saveData()
        End If

    End Sub

    Private Sub ConvertData()


        ulstat = MccDaq.MccService.ScaledWinBufToArray(AIMhandle, ADDataV, 0, ChannelCount * (numpoints - 1))
        If ulstat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            errhandler(ulstat)
            Exit Sub
        End If

        For cols = 0 To ChannelCount - 1
            m2DRows = -1
            For rows = 0 To ChannelCount * (numpoints - ChannelCount) Step ChannelCount
                arrayindex = cols + rows
                m2DRows += 1
                twoDData(cols, m2DRows) = ADDataV(arrayindex)
            Next
        Next

        'use the data. Here the data is displayed graphically.
        Oscilloscope1.UpdateScope(twoDData)    'twoDData is an array of new data to send to the oscilloscope.

        ulstat = Daqboard.StopBackground(MccDaq.FunctionType.AiFunction)
        lblAIMode.Text = "Idle"
        ulstat = MccDaq.MccService.WinBufFreeEx(AIMhandle) ' Free up memory for use by other programs
        If ulstat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then
            errhandler(ulstat)
            Exit Sub
        End If

    End Sub

    Private Sub saveData()
        ' save data to file
        Dim myLine As String
        Dim fileName As String
        fileName = txtFilePath.Text & "\" & currentTime & "-" & currentOut_txtBox.Text & "mA" & "-" & RichTextBox2.Text & "ms2" & ".csv" '  filename is current data and time
        Dim myWriter As New StreamWriter(fileName)
        myLine = ""
        myLine = myLine + "Experiment duration (s)" + "," + expDuration_comBox.Text + vbCrLf
        myLine = myLine + "Camera FPS" + "," + camFps_comBox.Text + vbCrLf
        myLine = myLine + "LED Duration (us)" + "," + LedDuration_comBox.Text + vbCrLf
        myLine = myLine + "Output current (mA) " + "," + currentOut_txtBox.Text + vbCrLf
        myLine = myLine + "Current gravity (m/s^2)" + "," + RichTextBox2.Text + vbCrLf
        myLine = myLine + "Measurement range" + "," + cmboAInScanRange.Text + vbCrLf
        myLine = myLine + "Measurement rate" + "," + rate_comBox.Text + vbCrLf
        myWriter.Write(myLine)
        For rows = 0 To twoDData.GetLength(1) - 1
            myLine = ""
            For cols = 0 To twoDData.GetLength(0) - 1
                myLine = myLine + "," + twoDData(cols, rows).ToString
            Next
            myWriter.WriteLine(myLine)
        Next
        myWriter.Close()
    End Sub

    Private Sub btnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.Click
        'How to end the program gracefully
        btnAInStartStop.Text = "Start DAQ"
        tmrAtoD.Enabled = False
        ulstat = Daqboard.StopBackground(MccDaq.FunctionType.AiFunction)
        lblAIMode.Text = "Idle"
        ulstat = MccDaq.MccService.WinBufFreeEx(AIMhandle) ' Free up memory for use by other programs
    End Sub

    Public Function SelectRange(ByVal ComboBoxIndex As Int32) As Int32
        Dim AInScanRange As Int32

        Select Case ComboBoxIndex
            Case 0
                AInScanRange = Convert.ToInt32([Enum].Parse(GetType(MccDaq.Range), MccDaq.Range.Bip10Volts))
            Case 1
                AInScanRange = Convert.ToInt32([Enum].Parse(GetType(MccDaq.Range), MccDaq.Range.Bip5Volts))
            Case 2
                AInScanRange = Convert.ToInt32([Enum].Parse(GetType(MccDaq.Range), MccDaq.Range.Bip2Volts))
            Case 3
                AInScanRange = Convert.ToInt32([Enum].Parse(GetType(MccDaq.Range), MccDaq.Range.Bip1Volts))
        End Select

        Return AInScanRange
    End Function

    Public Function OsciRange(ByVal ComboBoxIndex As Int32) As Integer
        Dim yRange As Integer

        Select Case ComboBoxIndex
            Case 0
                yRange = 10
            Case 1
                yRange = 5
            Case 2
                yRange = 2
            Case 3
                yRange = 1
        End Select

        Return yRange
    End Function

    Public Sub LoadComboBox(ByVal sender As System.Object)
        With sender
            .Items.Add("BIP10VOLTS")
            .Items.Add("BIP5VOLTS")
            .Items.Add("BIP2VOLTS")
            .Items.Add("BIP1VOLTS")
            .SelectedIndex = 2
        End With
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        currentTime = Date.Now.ToString("yyyy-MM-dd  hh-mm-ss")
    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("Are you sure you want to close the application? Save your file yet?", "My Application", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                SerialPort1.Write("<DISCONNECT>")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                e.Cancel = False
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

End Class
