<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrAtoD = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.refreshCom_Btn = New System.Windows.Forms.Button()
        Me.comPort_comBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.connect_Btn = New System.Windows.Forms.Button()
        Me.LedOn_Btn = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.expDuration_comBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.camFps_comBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LedDuration_comBox = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.currentOut_txtBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.acceTrigger1_txtBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.start_Btn = New System.Windows.Forms.Button()
        Me.stop_Btn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.acceTrigger2_txtBox = New System.Windows.Forms.TextBox()
        Me.clear_Btn = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblAIMode = New System.Windows.Forms.Label()
        Me.lblAICurIndex = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblAIShowCount = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnAInStartStop = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmboAInScanRange = New System.Windows.Forms.ComboBox()
        Me.nudLowChannel = New System.Windows.Forms.NumericUpDown()
        Me.nudHighChannel = New System.Windows.Forms.NumericUpDown()
        Me.chkExtTrigger = New System.Windows.Forms.CheckBox()
        Me.Oscilloscope1 = New BERGtools.Oscilloscope()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.rate_comBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.connecting_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudLowChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHighChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrAtoD
        '
        Me.tmrAtoD.Interval = 50
        '
        'refreshCom_Btn
        '
        Me.refreshCom_Btn.Location = New System.Drawing.Point(33, 46)
        Me.refreshCom_Btn.Margin = New System.Windows.Forms.Padding(4)
        Me.refreshCom_Btn.Name = "refreshCom_Btn"
        Me.refreshCom_Btn.Size = New System.Drawing.Size(41, 28)
        Me.refreshCom_Btn.TabIndex = 111
        Me.refreshCom_Btn.Text = "R"
        Me.refreshCom_Btn.UseVisualStyleBackColor = True
        '
        'comPort_comBox
        '
        Me.comPort_comBox.FormattingEnabled = True
        Me.comPort_comBox.Location = New System.Drawing.Point(82, 46)
        Me.comPort_comBox.Margin = New System.Windows.Forms.Padding(4)
        Me.comPort_comBox.Name = "comPort_comBox"
        Me.comPort_comBox.Size = New System.Drawing.Size(130, 28)
        Me.comPort_comBox.TabIndex = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "COM Port"
        '
        'connect_Btn
        '
        Me.connect_Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connect_Btn.Location = New System.Drawing.Point(219, 45)
        Me.connect_Btn.Name = "connect_Btn"
        Me.connect_Btn.Size = New System.Drawing.Size(101, 28)
        Me.connect_Btn.TabIndex = 114
        Me.connect_Btn.Text = "Connect"
        Me.connect_Btn.UseVisualStyleBackColor = True
        '
        'LedOn_Btn
        '
        Me.LedOn_Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LedOn_Btn.Location = New System.Drawing.Point(424, 44)
        Me.LedOn_Btn.Name = "LedOn_Btn"
        Me.LedOn_Btn.Size = New System.Drawing.Size(96, 28)
        Me.LedOn_Btn.TabIndex = 115
        Me.LedOn_Btn.Text = "LED On"
        Me.LedOn_Btn.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(45, 108)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(181, 239)
        Me.RichTextBox1.TabIndex = 116
        Me.RichTextBox1.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Log Message"
        '
        'expDuration_comBox
        '
        Me.expDuration_comBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expDuration_comBox.FormattingEnabled = True
        Me.expDuration_comBox.Items.AddRange(New Object() {"0.5 s", "1.0 s", "1.5 s"})
        Me.expDuration_comBox.Location = New System.Drawing.Point(252, 107)
        Me.expDuration_comBox.Name = "expDuration_comBox"
        Me.expDuration_comBox.Size = New System.Drawing.Size(127, 24)
        Me.expDuration_comBox.TabIndex = 118
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(392, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 17)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Experiment Duration"
        '
        'camFps_comBox
        '
        Me.camFps_comBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.camFps_comBox.FormattingEnabled = True
        Me.camFps_comBox.Items.AddRange(New Object() {"1000", "1600"})
        Me.camFps_comBox.Location = New System.Drawing.Point(252, 136)
        Me.camFps_comBox.Name = "camFps_comBox"
        Me.camFps_comBox.Size = New System.Drawing.Size(127, 24)
        Me.camFps_comBox.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(392, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 17)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Camera FPS"
        '
        'LedDuration_comBox
        '
        Me.LedDuration_comBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LedDuration_comBox.FormattingEnabled = True
        Me.LedDuration_comBox.Items.AddRange(New Object() {"1.0 us", "2.0 us", "3.0 us"})
        Me.LedDuration_comBox.Location = New System.Drawing.Point(252, 163)
        Me.LedDuration_comBox.Name = "LedDuration_comBox"
        Me.LedDuration_comBox.Size = New System.Drawing.Size(127, 24)
        Me.LedDuration_comBox.TabIndex = 122
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(392, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 17)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "LED Duration"
        '
        'currentOut_txtBox
        '
        Me.currentOut_txtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentOut_txtBox.Location = New System.Drawing.Point(252, 190)
        Me.currentOut_txtBox.Name = "currentOut_txtBox"
        Me.currentOut_txtBox.Size = New System.Drawing.Size(127, 22)
        Me.currentOut_txtBox.TabIndex = 124
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(392, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 17)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "Output Current (mA)"
        '
        'acceTrigger1_txtBox
        '
        Me.acceTrigger1_txtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acceTrigger1_txtBox.Location = New System.Drawing.Point(252, 216)
        Me.acceTrigger1_txtBox.Name = "acceTrigger1_txtBox"
        Me.acceTrigger1_txtBox.Size = New System.Drawing.Size(48, 22)
        Me.acceTrigger1_txtBox.TabIndex = 126
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(392, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 17)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Trigger Gravity (g)"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(252, 308)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(124, 53)
        Me.RichTextBox2.TabIndex = 128
        Me.RichTextBox2.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(253, 285)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 20)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Current Gravity"
        '
        'start_Btn
        '
        Me.start_Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_Btn.ForeColor = System.Drawing.Color.DarkGreen
        Me.start_Btn.Location = New System.Drawing.Point(405, 285)
        Me.start_Btn.Name = "start_Btn"
        Me.start_Btn.Size = New System.Drawing.Size(115, 31)
        Me.start_Btn.TabIndex = 130
        Me.start_Btn.Text = "Start"
        Me.start_Btn.UseVisualStyleBackColor = True
        '
        'stop_Btn
        '
        Me.stop_Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stop_Btn.ForeColor = System.Drawing.Color.Red
        Me.stop_Btn.Location = New System.Drawing.Point(405, 330)
        Me.stop_Btn.Name = "stop_Btn"
        Me.stop_Btn.Size = New System.Drawing.Size(115, 31)
        Me.stop_Btn.TabIndex = 131
        Me.stop_Btn.Text = "Stop"
        Me.stop_Btn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.acceTrigger2_txtBox)
        Me.GroupBox2.Controls.Add(Me.LedDuration_comBox)
        Me.GroupBox2.Controls.Add(Me.clear_Btn)
        Me.GroupBox2.Controls.Add(Me.stop_Btn)
        Me.GroupBox2.Controls.Add(Me.start_Btn)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.RichTextBox2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.acceTrigger1_txtBox)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.currentOut_txtBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.camFps_comBox)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.expDuration_comBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Controls.Add(Me.LedOn_Btn)
        Me.GroupBox2.Controls.Add(Me.connect_Btn)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.comPort_comBox)
        Me.GroupBox2.Controls.Add(Me.refreshCom_Btn)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(563, 382)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Teensy Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(306, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 17)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "to"
        '
        'acceTrigger2_txtBox
        '
        Me.acceTrigger2_txtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acceTrigger2_txtBox.Location = New System.Drawing.Point(332, 216)
        Me.acceTrigger2_txtBox.Name = "acceTrigger2_txtBox"
        Me.acceTrigger2_txtBox.Size = New System.Drawing.Size(47, 22)
        Me.acceTrigger2_txtBox.TabIndex = 133
        '
        'clear_Btn
        '
        Me.clear_Btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clear_Btn.Location = New System.Drawing.Point(92, 353)
        Me.clear_Btn.Name = "clear_Btn"
        Me.clear_Btn.Size = New System.Drawing.Size(75, 23)
        Me.clear_Btn.TabIndex = 132
        Me.clear_Btn.Text = "Clear"
        Me.clear_Btn.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(313, 280)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 17)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Cur Count:"
        '
        'lblAIMode
        '
        Me.lblAIMode.AutoSize = True
        Me.lblAIMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAIMode.Location = New System.Drawing.Point(407, 230)
        Me.lblAIMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAIMode.Name = "lblAIMode"
        Me.lblAIMode.Size = New System.Drawing.Size(30, 17)
        Me.lblAIMode.TabIndex = 55
        Me.lblAIMode.Text = "Idle"
        '
        'lblAICurIndex
        '
        Me.lblAICurIndex.AutoSize = True
        Me.lblAICurIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAICurIndex.Location = New System.Drawing.Point(407, 255)
        Me.lblAICurIndex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAICurIndex.Name = "lblAICurIndex"
        Me.lblAICurIndex.Size = New System.Drawing.Size(16, 17)
        Me.lblAICurIndex.TabIndex = 54
        Me.lblAICurIndex.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(317, 255)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 17)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Cur Index:"
        '
        'lblAIShowCount
        '
        Me.lblAIShowCount.AutoSize = True
        Me.lblAIShowCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAIShowCount.Location = New System.Drawing.Point(407, 280)
        Me.lblAIShowCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAIShowCount.Name = "lblAIShowCount"
        Me.lblAIShowCount.Size = New System.Drawing.Size(16, 17)
        Me.lblAIShowCount.TabIndex = 4
        Me.lblAIShowCount.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(341, 230)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(47, 17)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "Mode:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(341, 307)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 17)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Status:  No Errors"
        '
        'btnAInStartStop
        '
        Me.btnAInStartStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAInStartStop.ForeColor = System.Drawing.Color.Blue
        Me.btnAInStartStop.Location = New System.Drawing.Point(403, 100)
        Me.btnAInStartStop.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAInStartStop.Name = "btnAInStartStop"
        Me.btnAInStartStop.Size = New System.Drawing.Size(115, 31)
        Me.btnAInStartStop.TabIndex = 0
        Me.btnAInStartStop.Text = "Start DAQ"
        Me.btnAInStartStop.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(40, 280)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 17)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Range"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(52, 307)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 17)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Rate"
        '
        'btnEnd
        '
        Me.btnEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnd.ForeColor = System.Drawing.Color.Red
        Me.btnEnd.Location = New System.Drawing.Point(403, 148)
        Me.btnEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(115, 32)
        Me.btnEnd.TabIndex = 65
        Me.btnEnd.Text = "Reset DAQ"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 230)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 17)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Low Channel"
        '
        'cmboAInScanRange
        '
        Me.cmboAInScanRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmboAInScanRange.FormattingEnabled = True
        Me.cmboAInScanRange.Location = New System.Drawing.Point(102, 278)
        Me.cmboAInScanRange.Margin = New System.Windows.Forms.Padding(4)
        Me.cmboAInScanRange.Name = "cmboAInScanRange"
        Me.cmboAInScanRange.Size = New System.Drawing.Size(150, 24)
        Me.cmboAInScanRange.TabIndex = 68
        '
        'nudLowChannel
        '
        Me.nudLowChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudLowChannel.Location = New System.Drawing.Point(102, 228)
        Me.nudLowChannel.Margin = New System.Windows.Forms.Padding(4)
        Me.nudLowChannel.Name = "nudLowChannel"
        Me.nudLowChannel.Size = New System.Drawing.Size(45, 23)
        Me.nudLowChannel.TabIndex = 74
        '
        'nudHighChannel
        '
        Me.nudHighChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudHighChannel.Location = New System.Drawing.Point(102, 253)
        Me.nudHighChannel.Margin = New System.Windows.Forms.Padding(4)
        Me.nudHighChannel.Name = "nudHighChannel"
        Me.nudHighChannel.Size = New System.Drawing.Size(45, 23)
        Me.nudHighChannel.TabIndex = 75
        Me.nudHighChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkExtTrigger
        '
        Me.chkExtTrigger.AutoSize = True
        Me.chkExtTrigger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExtTrigger.Location = New System.Drawing.Point(69, 337)
        Me.chkExtTrigger.Margin = New System.Windows.Forms.Padding(4)
        Me.chkExtTrigger.Name = "chkExtTrigger"
        Me.chkExtTrigger.Size = New System.Drawing.Size(131, 21)
        Me.chkExtTrigger.TabIndex = 102
        Me.chkExtTrigger.Text = "External Trigger"
        Me.chkExtTrigger.UseVisualStyleBackColor = True
        '
        'Oscilloscope1
        '
        Me.Oscilloscope1.AutoScale = False
        Me.Oscilloscope1.BackgroundColor = System.Drawing.Color.DarkGreen
        Me.Oscilloscope1.FontColor = System.Drawing.Color.Beige
        Me.Oscilloscope1.Location = New System.Drawing.Point(28, 28)
        Me.Oscilloscope1.Margin = New System.Windows.Forms.Padding(5)
        Me.Oscilloscope1.Name = "Oscilloscope1"
        Me.Oscilloscope1.ScaleColor = System.Drawing.Color.DarkKhaki
        Me.Oscilloscope1.Size = New System.Drawing.Size(343, 193)
        Me.Oscilloscope1.TabIndex = 103
        Me.Oscilloscope1.TracePen0 = System.Drawing.Color.LightSteelBlue
        Me.Oscilloscope1.TracePen1 = System.Drawing.Color.SkyBlue
        Me.Oscilloscope1.TracePen2 = System.Drawing.Color.PaleGreen
        Me.Oscilloscope1.TracePen3 = System.Drawing.Color.PaleGoldenrod
        Me.Oscilloscope1.TracePen4 = System.Drawing.Color.Wheat
        Me.Oscilloscope1.TracePen5 = System.Drawing.Color.PeachPuff
        Me.Oscilloscope1.TracePen6 = System.Drawing.Color.MistyRose
        Me.Oscilloscope1.TracePen7 = System.Drawing.Color.White
        Me.Oscilloscope1.YAxisScale = BERGtools.YAxisScaleVal.Bipolar
        Me.Oscilloscope1.YMaximum = 10.0R
        Me.Oscilloscope1.YMinimum = -10.0R
        Me.Oscilloscope1.YTicks = 10
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(283, 333)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(94, 28)
        Me.btnBrowse.TabIndex = 106
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilePath.Location = New System.Drawing.Point(385, 336)
        Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(159, 22)
        Me.txtFilePath.TabIndex = 107
        '
        'rate_comBox
        '
        Me.rate_comBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rate_comBox.FormattingEnabled = True
        Me.rate_comBox.Items.AddRange(New Object() {"5 MS", "10 MS", "15 MS"})
        Me.rate_comBox.Location = New System.Drawing.Point(102, 305)
        Me.rate_comBox.Margin = New System.Windows.Forms.Padding(4)
        Me.rate_comBox.Name = "rate_comBox"
        Me.rate_comBox.Size = New System.Drawing.Size(150, 24)
        Me.rate_comBox.TabIndex = 109
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.rate_comBox)
        Me.GroupBox1.Controls.Add(Me.txtFilePath)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.Oscilloscope1)
        Me.GroupBox1.Controls.Add(Me.chkExtTrigger)
        Me.GroupBox1.Controls.Add(Me.nudHighChannel)
        Me.GroupBox1.Controls.Add(Me.nudLowChannel)
        Me.GroupBox1.Controls.Add(Me.cmboAInScanRange)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.btnEnd)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.btnAInStartStop)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lblAIShowCount)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblAICurIndex)
        Me.GroupBox1.Controls.Add(Me.lblAIMode)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 403)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(561, 364)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DAQ Control"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(-1, 255)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 17)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "High Channel"
        '
        'connecting_Timer
        '
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 772)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "-+"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudLowChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHighChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrAtoD As System.Windows.Forms.Timer
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents refreshCom_Btn As Button
    Friend WithEvents comPort_comBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents connect_Btn As Button
    Friend WithEvents LedOn_Btn As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents expDuration_comBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents camFps_comBox As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LedDuration_comBox As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents currentOut_txtBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents acceTrigger1_txtBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents start_Btn As Button
    Friend WithEvents stop_Btn As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblAIMode As Label
    Friend WithEvents lblAICurIndex As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblAIShowCount As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnAInStartStop As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btnEnd As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents cmboAInScanRange As ComboBox
    Friend WithEvents nudLowChannel As NumericUpDown
    Friend WithEvents nudHighChannel As NumericUpDown
    Friend WithEvents chkExtTrigger As CheckBox
    Friend WithEvents Oscilloscope1 As BERGtools.Oscilloscope
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents rate_comBox As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents clear_Btn As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents connecting_Timer As Timer
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents acceTrigger2_txtBox As TextBox
    Friend WithEvents Label2 As Label
End Class
