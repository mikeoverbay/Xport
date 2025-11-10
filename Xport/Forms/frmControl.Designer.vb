Imports System.Windows.Forms
Imports System.Drawing.SystemColors
Imports System.Drawing
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmControl
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControl))
        Me.txtPosX = New System.Windows.Forms.TextBox()
        Me.txtPosY = New System.Windows.Forms.TextBox()
        Me.txtPosZ = New System.Windows.Forms.TextBox()
        Me.txtPosA = New System.Windows.Forms.TextBox()
        Me.updateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.status_tb = New System.Windows.Forms.TextBox()
        Me.input_tb = New System.Windows.Forms.TextBox()
        Me.connect_btn = New System.Windows.Forms.Button()
        Me.Speed_text_label = New System.Windows.Forms.Label()
        Me.speed_combobox = New System.Windows.Forms.ComboBox()
        Me.step_combobox = New System.Windows.Forms.ComboBox()
        Me.step_label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stop_btn = New CodeChop.my_Frm_Btn_control()
        Me.pause_btn = New CodeChop.my_Frm_Btn_control()
        Me.run_btn = New CodeChop.my_Frm_Btn_control()
        Me.zero_a_btn = New CodeChop.my_Frm_Btn_control()
        Me.zero_z_btn = New CodeChop.my_Frm_Btn_control()
        Me.zero_y_btn = New CodeChop.my_Frm_Btn_control()
        Me.zero_x_btn = New CodeChop.my_Frm_Btn_control()
        Me.btnHomeA = New CodeChop.my_Frm_Btn_control()
        Me.btnFup = New CodeChop.my_Frm_Btn_control()
        Me.btnFdown = New CodeChop.my_Frm_Btn_control()
        Me.btnHomeZ = New CodeChop.my_Frm_Btn_control()
        Me.btnZPlus = New CodeChop.my_Frm_Btn_control()
        Me.btnZMinus = New CodeChop.my_Frm_Btn_control()
        Me.btnHomeY = New CodeChop.my_Frm_Btn_control()
        Me.btnYPlus = New CodeChop.my_Frm_Btn_control()
        Me.btnYMinus = New CodeChop.my_Frm_Btn_control()
        Me.btnHomeX = New CodeChop.my_Frm_Btn_control()
        Me.btnXPlus = New CodeChop.my_Frm_Btn_control()
        Me.btnXMinus = New CodeChop.my_Frm_Btn_control()
        Me.SuspendLayout()
        '
        'txtPosX
        '
        Me.txtPosX.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPosX.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPosX.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPosX.Location = New System.Drawing.Point(401, 51)
        Me.txtPosX.Name = "txtPosX"
        Me.txtPosX.ReadOnly = True
        Me.txtPosX.Size = New System.Drawing.Size(133, 25)
        Me.txtPosX.TabIndex = 12
        Me.txtPosX.Text = "X-0000.0000"
        '
        'txtPosY
        '
        Me.txtPosY.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPosY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPosY.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPosY.Location = New System.Drawing.Point(401, 113)
        Me.txtPosY.Name = "txtPosY"
        Me.txtPosY.ReadOnly = True
        Me.txtPosY.Size = New System.Drawing.Size(133, 25)
        Me.txtPosY.TabIndex = 13
        Me.txtPosY.Text = "Y-0000.0000"
        '
        'txtPosZ
        '
        Me.txtPosZ.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPosZ.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPosZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPosZ.Location = New System.Drawing.Point(401, 191)
        Me.txtPosZ.Name = "txtPosZ"
        Me.txtPosZ.ReadOnly = True
        Me.txtPosZ.Size = New System.Drawing.Size(133, 25)
        Me.txtPosZ.TabIndex = 14
        Me.txtPosZ.Text = "Z-0000.0000"
        '
        'txtPosA
        '
        Me.txtPosA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPosA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPosA.Enabled = False
        Me.txtPosA.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPosA.Location = New System.Drawing.Point(401, 255)
        Me.txtPosA.Name = "txtPosA"
        Me.txtPosA.ReadOnly = True
        Me.txtPosA.Size = New System.Drawing.Size(133, 25)
        Me.txtPosA.TabIndex = 15
        '
        'updateTimer
        '
        Me.updateTimer.Enabled = True
        Me.updateTimer.Interval = 200
        '
        'status_tb
        '
        Me.status_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.status_tb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.status_tb.Location = New System.Drawing.Point(11, 246)
        Me.status_tb.Multiline = True
        Me.status_tb.Name = "status_tb"
        Me.status_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.status_tb.Size = New System.Drawing.Size(350, 157)
        Me.status_tb.TabIndex = 27
        '
        'input_tb
        '
        Me.input_tb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.input_tb.Location = New System.Drawing.Point(11, 409)
        Me.input_tb.Name = "input_tb"
        Me.input_tb.Size = New System.Drawing.Size(350, 20)
        Me.input_tb.TabIndex = 28
        '
        'connect_btn
        '
        Me.connect_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.connect_btn.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.connect_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.connect_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connect_btn.ForeColor = System.Drawing.Color.White
        Me.connect_btn.Location = New System.Drawing.Point(11, 12)
        Me.connect_btn.Name = "connect_btn"
        Me.connect_btn.Size = New System.Drawing.Size(112, 30)
        Me.connect_btn.TabIndex = 32
        Me.connect_btn.Text = "Connect"
        Me.connect_btn.UseVisualStyleBackColor = False
        '
        'Speed_text_label
        '
        Me.Speed_text_label.AutoSize = True
        Me.Speed_text_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Speed_text_label.ForeColor = System.Drawing.Color.White
        Me.Speed_text_label.Location = New System.Drawing.Point(124, 22)
        Me.Speed_text_label.Name = "Speed_text_label"
        Me.Speed_text_label.Size = New System.Drawing.Size(48, 15)
        Me.Speed_text_label.TabIndex = 34
        Me.Speed_text_label.Text = "Speed"
        '
        'speed_combobox
        '
        Me.speed_combobox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.speed_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.speed_combobox.ForeColor = System.Drawing.Color.White
        Me.speed_combobox.FormattingEnabled = True
        Me.speed_combobox.Items.AddRange(New Object() {"10", "20", "50", "100", "150"})
        Me.speed_combobox.Location = New System.Drawing.Point(178, 19)
        Me.speed_combobox.Name = "speed_combobox"
        Me.speed_combobox.Size = New System.Drawing.Size(68, 21)
        Me.speed_combobox.TabIndex = 35
        Me.speed_combobox.Text = "100"
        '
        'step_combobox
        '
        Me.step_combobox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.step_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.step_combobox.ForeColor = System.Drawing.Color.White
        Me.step_combobox.FormattingEnabled = True
        Me.step_combobox.Items.AddRange(New Object() {"0.001", "0.01", "0.1", "1.0", "10.0", "100.0"})
        Me.step_combobox.Location = New System.Drawing.Point(298, 19)
        Me.step_combobox.Name = "step_combobox"
        Me.step_combobox.Size = New System.Drawing.Size(68, 21)
        Me.step_combobox.TabIndex = 36
        Me.step_combobox.Text = "100"
        '
        'step_label
        '
        Me.step_label.AutoSize = True
        Me.step_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.step_label.ForeColor = System.Drawing.Color.White
        Me.step_label.Location = New System.Drawing.Point(256, 22)
        Me.step_label.Name = "step_label"
        Me.step_label.Size = New System.Drawing.Size(36, 15)
        Me.step_label.TabIndex = 37
        Me.step_label.Text = "Step"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(307, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "0.000"
        '
        'stop_btn
        '
        Me.stop_btn.BackgroundImage = CType(resources.GetObject("stop_btn.BackgroundImage"), System.Drawing.Image)
        Me.stop_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.stop_btn.FlatAppearance.BorderSize = 0
        Me.stop_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.stop_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stop_btn.ForeColor = System.Drawing.Color.White
        Me.stop_btn.Image = Global.CodeChop.My.Resources.Resources.StopHS
        Me.stop_btn.Location = New System.Drawing.Point(612, 352)
        Me.stop_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.stop_btn.Name = "stop_btn"
        Me.stop_btn.Size = New System.Drawing.Size(60, 60)
        Me.stop_btn.TabIndex = 31
        Me.stop_btn.TabStop = False
        Me.stop_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.stop_btn.UseVisualStyleBackColor = True
        '
        'pause_btn
        '
        Me.pause_btn.BackgroundImage = CType(resources.GetObject("pause_btn.BackgroundImage"), System.Drawing.Image)
        Me.pause_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pause_btn.FlatAppearance.BorderSize = 0
        Me.pause_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pause_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pause_btn.ForeColor = System.Drawing.Color.White
        Me.pause_btn.Image = Global.CodeChop.My.Resources.Resources.control_pause
        Me.pause_btn.Location = New System.Drawing.Point(525, 352)
        Me.pause_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.pause_btn.Name = "pause_btn"
        Me.pause_btn.Size = New System.Drawing.Size(60, 60)
        Me.pause_btn.TabIndex = 30
        Me.pause_btn.TabStop = False
        Me.pause_btn.UseVisualStyleBackColor = True
        '
        'run_btn
        '
        Me.run_btn.BackgroundImage = CType(resources.GetObject("run_btn.BackgroundImage"), System.Drawing.Image)
        Me.run_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.run_btn.FlatAppearance.BorderSize = 0
        Me.run_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.run_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.run_btn.ForeColor = System.Drawing.Color.White
        Me.run_btn.Image = Global.CodeChop.My.Resources.Resources.control
        Me.run_btn.Location = New System.Drawing.Point(441, 352)
        Me.run_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.run_btn.Name = "run_btn"
        Me.run_btn.Size = New System.Drawing.Size(60, 60)
        Me.run_btn.TabIndex = 29
        Me.run_btn.TabStop = False
        Me.run_btn.UseVisualStyleBackColor = True
        '
        'zero_a_btn
        '
        Me.zero_a_btn.BackgroundImage = CType(resources.GetObject("zero_a_btn.BackgroundImage"), System.Drawing.Image)
        Me.zero_a_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.zero_a_btn.Enabled = False
        Me.zero_a_btn.FlatAppearance.BorderSize = 0
        Me.zero_a_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zero_a_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_a_btn.ForeColor = System.Drawing.Color.White
        Me.zero_a_btn.Location = New System.Drawing.Point(538, 246)
        Me.zero_a_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.zero_a_btn.Name = "zero_a_btn"
        Me.zero_a_btn.Size = New System.Drawing.Size(70, 48)
        Me.zero_a_btn.TabIndex = 26
        Me.zero_a_btn.TabStop = False
        Me.zero_a_btn.Text = "ZERO"
        Me.zero_a_btn.UseVisualStyleBackColor = True
        '
        'zero_z_btn
        '
        Me.zero_z_btn.BackgroundImage = CType(resources.GetObject("zero_z_btn.BackgroundImage"), System.Drawing.Image)
        Me.zero_z_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.zero_z_btn.FlatAppearance.BorderSize = 0
        Me.zero_z_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zero_z_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_z_btn.ForeColor = System.Drawing.Color.White
        Me.zero_z_btn.Location = New System.Drawing.Point(538, 182)
        Me.zero_z_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.zero_z_btn.Name = "zero_z_btn"
        Me.zero_z_btn.Size = New System.Drawing.Size(70, 48)
        Me.zero_z_btn.TabIndex = 25
        Me.zero_z_btn.TabStop = False
        Me.zero_z_btn.Text = "ZERO"
        Me.zero_z_btn.UseVisualStyleBackColor = True
        '
        'zero_y_btn
        '
        Me.zero_y_btn.BackgroundImage = CType(resources.GetObject("zero_y_btn.BackgroundImage"), System.Drawing.Image)
        Me.zero_y_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.zero_y_btn.FlatAppearance.BorderSize = 0
        Me.zero_y_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zero_y_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_y_btn.ForeColor = System.Drawing.Color.White
        Me.zero_y_btn.Location = New System.Drawing.Point(538, 104)
        Me.zero_y_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.zero_y_btn.Name = "zero_y_btn"
        Me.zero_y_btn.Size = New System.Drawing.Size(70, 48)
        Me.zero_y_btn.TabIndex = 24
        Me.zero_y_btn.TabStop = False
        Me.zero_y_btn.Text = "ZERO"
        Me.zero_y_btn.UseVisualStyleBackColor = True
        '
        'zero_x_btn
        '
        Me.zero_x_btn.BackgroundImage = CType(resources.GetObject("zero_x_btn.BackgroundImage"), System.Drawing.Image)
        Me.zero_x_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.zero_x_btn.FlatAppearance.BorderSize = 0
        Me.zero_x_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zero_x_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zero_x_btn.ForeColor = System.Drawing.Color.White
        Me.zero_x_btn.Location = New System.Drawing.Point(538, 42)
        Me.zero_x_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.zero_x_btn.Name = "zero_x_btn"
        Me.zero_x_btn.Size = New System.Drawing.Size(70, 48)
        Me.zero_x_btn.TabIndex = 17
        Me.zero_x_btn.TabStop = False
        Me.zero_x_btn.Text = "ZERO"
        Me.zero_x_btn.UseVisualStyleBackColor = True
        '
        'btnHomeA
        '
        Me.btnHomeA.BackgroundImage = CType(resources.GetObject("btnHomeA.BackgroundImage"), System.Drawing.Image)
        Me.btnHomeA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHomeA.Enabled = False
        Me.btnHomeA.FlatAppearance.BorderSize = 0
        Me.btnHomeA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeA.ForeColor = System.Drawing.Color.Yellow
        Me.btnHomeA.Location = New System.Drawing.Point(602, 246)
        Me.btnHomeA.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHomeA.Name = "btnHomeA"
        Me.btnHomeA.Size = New System.Drawing.Size(70, 48)
        Me.btnHomeA.TabIndex = 11
        Me.btnHomeA.TabStop = False
        Me.btnHomeA.Text = "Home A"
        Me.btnHomeA.UseVisualStyleBackColor = True
        '
        'btnFup
        '
        Me.btnFup.BackgroundImage = CType(resources.GetObject("btnFup.BackgroundImage"), System.Drawing.Image)
        Me.btnFup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFup.FlatAppearance.BorderSize = 0
        Me.btnFup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFup.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFup.ForeColor = System.Drawing.Color.White
        Me.btnFup.Location = New System.Drawing.Point(306, 75)
        Me.btnFup.Margin = New System.Windows.Forms.Padding(0)
        Me.btnFup.Name = "btnFup"
        Me.btnFup.Size = New System.Drawing.Size(60, 48)
        Me.btnFup.TabIndex = 10
        Me.btnFup.TabStop = False
        Me.btnFup.Text = "Feed +"
        Me.btnFup.UseVisualStyleBackColor = True
        '
        'btnFdown
        '
        Me.btnFdown.BackgroundImage = CType(resources.GetObject("btnFdown.BackgroundImage"), System.Drawing.Image)
        Me.btnFdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFdown.FlatAppearance.BorderSize = 0
        Me.btnFdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFdown.ForeColor = System.Drawing.Color.White
        Me.btnFdown.Location = New System.Drawing.Point(306, 168)
        Me.btnFdown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnFdown.Name = "btnFdown"
        Me.btnFdown.Size = New System.Drawing.Size(60, 48)
        Me.btnFdown.TabIndex = 9
        Me.btnFdown.TabStop = False
        Me.btnFdown.Text = "Feed  -"
        Me.btnFdown.UseVisualStyleBackColor = True
        '
        'btnHomeZ
        '
        Me.btnHomeZ.BackgroundImage = CType(resources.GetObject("btnHomeZ.BackgroundImage"), System.Drawing.Image)
        Me.btnHomeZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHomeZ.FlatAppearance.BorderSize = 0
        Me.btnHomeZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeZ.ForeColor = System.Drawing.Color.Yellow
        Me.btnHomeZ.Location = New System.Drawing.Point(602, 182)
        Me.btnHomeZ.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHomeZ.Name = "btnHomeZ"
        Me.btnHomeZ.Size = New System.Drawing.Size(70, 48)
        Me.btnHomeZ.TabIndex = 8
        Me.btnHomeZ.TabStop = False
        Me.btnHomeZ.Text = "Home Z"
        Me.btnHomeZ.UseVisualStyleBackColor = True
        '
        'btnZPlus
        '
        Me.btnZPlus.BackgroundImage = CType(resources.GetObject("btnZPlus.BackgroundImage"), System.Drawing.Image)
        Me.btnZPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnZPlus.FlatAppearance.BorderSize = 0
        Me.btnZPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZPlus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnZPlus.Location = New System.Drawing.Point(203, 75)
        Me.btnZPlus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnZPlus.Name = "btnZPlus"
        Me.btnZPlus.Size = New System.Drawing.Size(48, 48)
        Me.btnZPlus.TabIndex = 7
        Me.btnZPlus.TabStop = False
        Me.btnZPlus.Text = "Z +"
        Me.btnZPlus.UseVisualStyleBackColor = True
        '
        'btnZMinus
        '
        Me.btnZMinus.BackgroundImage = CType(resources.GetObject("btnZMinus.BackgroundImage"), System.Drawing.Image)
        Me.btnZMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnZMinus.FlatAppearance.BorderSize = 0
        Me.btnZMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZMinus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnZMinus.Location = New System.Drawing.Point(203, 168)
        Me.btnZMinus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnZMinus.Name = "btnZMinus"
        Me.btnZMinus.Size = New System.Drawing.Size(48, 48)
        Me.btnZMinus.TabIndex = 6
        Me.btnZMinus.TabStop = False
        Me.btnZMinus.Text = "Z -"
        Me.btnZMinus.UseVisualStyleBackColor = True
        '
        'btnHomeY
        '
        Me.btnHomeY.BackgroundImage = CType(resources.GetObject("btnHomeY.BackgroundImage"), System.Drawing.Image)
        Me.btnHomeY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHomeY.FlatAppearance.BorderSize = 0
        Me.btnHomeY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeY.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeY.ForeColor = System.Drawing.Color.Yellow
        Me.btnHomeY.Location = New System.Drawing.Point(602, 104)
        Me.btnHomeY.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHomeY.Name = "btnHomeY"
        Me.btnHomeY.Size = New System.Drawing.Size(70, 48)
        Me.btnHomeY.TabIndex = 5
        Me.btnHomeY.TabStop = False
        Me.btnHomeY.Text = "Home Y"
        Me.btnHomeY.UseVisualStyleBackColor = True
        '
        'btnYPlus
        '
        Me.btnYPlus.BackgroundImage = CType(resources.GetObject("btnYPlus.BackgroundImage"), System.Drawing.Image)
        Me.btnYPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYPlus.FlatAppearance.BorderSize = 0
        Me.btnYPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYPlus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnYPlus.Location = New System.Drawing.Point(75, 75)
        Me.btnYPlus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnYPlus.Name = "btnYPlus"
        Me.btnYPlus.Size = New System.Drawing.Size(48, 48)
        Me.btnYPlus.TabIndex = 4
        Me.btnYPlus.TabStop = False
        Me.btnYPlus.Text = "Y +"
        Me.btnYPlus.UseVisualStyleBackColor = True
        '
        'btnYMinus
        '
        Me.btnYMinus.BackgroundImage = CType(resources.GetObject("btnYMinus.BackgroundImage"), System.Drawing.Image)
        Me.btnYMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYMinus.FlatAppearance.BorderSize = 0
        Me.btnYMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYMinus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnYMinus.Location = New System.Drawing.Point(75, 168)
        Me.btnYMinus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnYMinus.Name = "btnYMinus"
        Me.btnYMinus.Size = New System.Drawing.Size(48, 48)
        Me.btnYMinus.TabIndex = 3
        Me.btnYMinus.TabStop = False
        Me.btnYMinus.Text = "Y -"
        Me.btnYMinus.UseVisualStyleBackColor = True
        '
        'btnHomeX
        '
        Me.btnHomeX.BackgroundImage = CType(resources.GetObject("btnHomeX.BackgroundImage"), System.Drawing.Image)
        Me.btnHomeX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHomeX.FlatAppearance.BorderSize = 0
        Me.btnHomeX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeX.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeX.ForeColor = System.Drawing.Color.Yellow
        Me.btnHomeX.Location = New System.Drawing.Point(602, 42)
        Me.btnHomeX.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHomeX.Name = "btnHomeX"
        Me.btnHomeX.Size = New System.Drawing.Size(70, 48)
        Me.btnHomeX.TabIndex = 2
        Me.btnHomeX.TabStop = False
        Me.btnHomeX.Text = "Home X"
        Me.btnHomeX.UseVisualStyleBackColor = True
        '
        'btnXPlus
        '
        Me.btnXPlus.BackgroundImage = CType(resources.GetObject("btnXPlus.BackgroundImage"), System.Drawing.Image)
        Me.btnXPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnXPlus.FlatAppearance.BorderSize = 0
        Me.btnXPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXPlus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnXPlus.Location = New System.Drawing.Point(124, 123)
        Me.btnXPlus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXPlus.Name = "btnXPlus"
        Me.btnXPlus.Size = New System.Drawing.Size(48, 48)
        Me.btnXPlus.TabIndex = 1
        Me.btnXPlus.TabStop = False
        Me.btnXPlus.Text = "X +"
        Me.btnXPlus.UseVisualStyleBackColor = True
        '
        'btnXMinus
        '
        Me.btnXMinus.BackgroundImage = CType(resources.GetObject("btnXMinus.BackgroundImage"), System.Drawing.Image)
        Me.btnXMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnXMinus.FlatAppearance.BorderSize = 0
        Me.btnXMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXMinus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXMinus.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnXMinus.Location = New System.Drawing.Point(27, 123)
        Me.btnXMinus.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXMinus.Name = "btnXMinus"
        Me.btnXMinus.Size = New System.Drawing.Size(48, 48)
        Me.btnXMinus.TabIndex = 0
        Me.btnXMinus.TabStop = False
        Me.btnXMinus.Text = "X -"
        Me.btnXMinus.UseVisualStyleBackColor = True
        '
        'frmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(685, 441)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.step_label)
        Me.Controls.Add(Me.step_combobox)
        Me.Controls.Add(Me.speed_combobox)
        Me.Controls.Add(Me.Speed_text_label)
        Me.Controls.Add(Me.connect_btn)
        Me.Controls.Add(Me.stop_btn)
        Me.Controls.Add(Me.pause_btn)
        Me.Controls.Add(Me.run_btn)
        Me.Controls.Add(Me.input_tb)
        Me.Controls.Add(Me.status_tb)
        Me.Controls.Add(Me.zero_a_btn)
        Me.Controls.Add(Me.zero_z_btn)
        Me.Controls.Add(Me.zero_y_btn)
        Me.Controls.Add(Me.zero_x_btn)
        Me.Controls.Add(Me.txtPosA)
        Me.Controls.Add(Me.txtPosZ)
        Me.Controls.Add(Me.txtPosY)
        Me.Controls.Add(Me.txtPosX)
        Me.Controls.Add(Me.btnHomeA)
        Me.Controls.Add(Me.btnFup)
        Me.Controls.Add(Me.btnFdown)
        Me.Controls.Add(Me.btnHomeZ)
        Me.Controls.Add(Me.btnZPlus)
        Me.Controls.Add(Me.btnZMinus)
        Me.Controls.Add(Me.btnHomeY)
        Me.Controls.Add(Me.btnYPlus)
        Me.Controls.Add(Me.btnYMinus)
        Me.Controls.Add(Me.btnHomeX)
        Me.Controls.Add(Me.btnXPlus)
        Me.Controls.Add(Me.btnXMinus)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmControl"
        Me.Text = "Machine Control"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPosX As TextBox
    Friend WithEvents txtPosY As TextBox
    Friend WithEvents txtPosZ As TextBox
    Friend WithEvents txtPosA As TextBox
    Friend WithEvents updateTimer As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents zero_y_btn As my_Frm_Btn_control
    Friend WithEvents zero_z_btn As my_Frm_Btn_control
    Friend WithEvents zero_a_btn As my_Frm_Btn_control
    Friend WithEvents status_tb As TextBox
    Friend WithEvents input_tb As TextBox
    Friend WithEvents btnXMinus As my_Frm_Btn_control
    Friend WithEvents btnXPlus As my_Frm_Btn_control
    Friend WithEvents btnHomeX As my_Frm_Btn_control
    Friend WithEvents btnYMinus As my_Frm_Btn_control
    Friend WithEvents btnYPlus As my_Frm_Btn_control
    Friend WithEvents btnHomeY As my_Frm_Btn_control
    Friend WithEvents btnZMinus As my_Frm_Btn_control
    Friend WithEvents btnZPlus As my_Frm_Btn_control
    Friend WithEvents btnHomeZ As my_Frm_Btn_control
    Friend WithEvents btnFdown As my_Frm_Btn_control
    Friend WithEvents btnFup As my_Frm_Btn_control
    Friend WithEvents btnHomeA As my_Frm_Btn_control
    Friend WithEvents zero_x_btn As my_Frm_Btn_control
    Friend WithEvents run_btn As my_Frm_Btn_control
    Friend WithEvents stop_btn As my_Frm_Btn_control
    Friend WithEvents pause_btn As my_Frm_Btn_control
    Friend WithEvents connect_btn As Button
    Friend WithEvents Speed_text_label As Label
    Friend WithEvents speed_combobox As ComboBox
    Friend WithEvents step_combobox As ComboBox
    Friend WithEvents step_label As Label
    Friend WithEvents Label1 As Label
End Class
