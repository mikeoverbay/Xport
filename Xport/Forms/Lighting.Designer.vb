<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lighting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lighting))
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Mc6 = New System.Windows.Forms.RadioButton()
        Me.Mc5 = New System.Windows.Forms.RadioButton()
        Me.Mc4 = New System.Windows.Forms.RadioButton()
        Me.Mc3 = New System.Windows.Forms.RadioButton()
        Me.Mc2 = New System.Windows.Forms.RadioButton()
        Me.mc1 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.fanuc_cb = New System.Windows.Forms.CheckBox()
        Me.sub_return_tb = New System.Windows.Forms.TextBox()
        Me.sub_call_tb = New System.Windows.Forms.TextBox()
        Me.abs_ckb = New System.Windows.Forms.CheckBox()
        Me.cb_steptime = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.Black
        Me.TrackBar1.LargeChange = 10
        Me.TrackBar1.Location = New System.Drawing.Point(17, 31)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(268, 45)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TickFrequency = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(198, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "1.5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(92, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "OpenGL Light Level"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(92, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Grid Brightness Level"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(200, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "1.5"
        '
        'TrackBar2
        '
        Me.TrackBar2.BackColor = System.Drawing.Color.Black
        Me.TrackBar2.LargeChange = 10
        Me.TrackBar2.Location = New System.Drawing.Point(17, 123)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(268, 45)
        Me.TrackBar2.TabIndex = 3
        Me.TrackBar2.TickFrequency = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Mc6)
        Me.GroupBox1.Controls.Add(Me.Mc5)
        Me.GroupBox1.Controls.Add(Me.Mc4)
        Me.GroupBox1.Controls.Add(Me.Mc3)
        Me.GroupBox1.Controls.Add(Me.Mc2)
        Me.GroupBox1.Controls.Add(Me.mc1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(12, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 73)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selected Model Color"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(150, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Color Scale"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.CodeChop.My.MySettings.Default, "color_scale", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown1.DecimalPlaces = 2
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.NumericUpDown1.Location = New System.Drawing.Point(217, 47)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 65536})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = Global.CodeChop.My.MySettings.Default.color_scale
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = Global.CodeChop.My.MySettings.Default.show_model
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "show_model", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox1.Location = New System.Drawing.Point(150, 16)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Show Model"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Mc6
        '
        Me.Mc6.Appearance = System.Windows.Forms.Appearance.Button
        Me.Mc6.BackColor = System.Drawing.Color.SlateGray
        Me.Mc6.Checked = Global.CodeChop.My.MySettings.Default.mc6
        Me.Mc6.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc6", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Mc6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Mc6.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateGray
        Me.Mc6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mc6.Location = New System.Drawing.Point(96, 44)
        Me.Mc6.Name = "Mc6"
        Me.Mc6.Size = New System.Drawing.Size(35, 23)
        Me.Mc6.TabIndex = 5
        Me.Mc6.TabStop = True
        Me.Mc6.UseVisualStyleBackColor = False
        '
        'Mc5
        '
        Me.Mc5.Appearance = System.Windows.Forms.Appearance.Button
        Me.Mc5.BackColor = System.Drawing.Color.Chocolate
        Me.Mc5.Checked = Global.CodeChop.My.MySettings.Default.mc5
        Me.Mc5.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc5", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Mc5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Mc5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Chocolate
        Me.Mc5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mc5.Location = New System.Drawing.Point(96, 16)
        Me.Mc5.Name = "Mc5"
        Me.Mc5.Size = New System.Drawing.Size(35, 23)
        Me.Mc5.TabIndex = 4
        Me.Mc5.TabStop = True
        Me.Mc5.UseVisualStyleBackColor = False
        '
        'Mc4
        '
        Me.Mc4.Appearance = System.Windows.Forms.Appearance.Button
        Me.Mc4.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Mc4.Checked = Global.CodeChop.My.MySettings.Default.mc4
        Me.Mc4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc4", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Mc4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Mc4.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGoldenrod
        Me.Mc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mc4.Location = New System.Drawing.Point(51, 44)
        Me.Mc4.Name = "Mc4"
        Me.Mc4.Size = New System.Drawing.Size(35, 23)
        Me.Mc4.TabIndex = 3
        Me.Mc4.UseVisualStyleBackColor = False
        '
        'Mc3
        '
        Me.Mc3.Appearance = System.Windows.Forms.Appearance.Button
        Me.Mc3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Mc3.Checked = Global.CodeChop.My.MySettings.Default.mc3
        Me.Mc3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc3", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Mc3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Mc3.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSlateGray
        Me.Mc3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mc3.Location = New System.Drawing.Point(51, 16)
        Me.Mc3.Name = "Mc3"
        Me.Mc3.Size = New System.Drawing.Size(35, 23)
        Me.Mc3.TabIndex = 2
        Me.Mc3.UseVisualStyleBackColor = False
        '
        'Mc2
        '
        Me.Mc2.Appearance = System.Windows.Forms.Appearance.Button
        Me.Mc2.BackColor = System.Drawing.Color.DarkGray
        Me.Mc2.Checked = Global.CodeChop.My.MySettings.Default.mc2
        Me.Mc2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Mc2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Mc2.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray
        Me.Mc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mc2.Location = New System.Drawing.Point(7, 44)
        Me.Mc2.Name = "Mc2"
        Me.Mc2.Size = New System.Drawing.Size(35, 23)
        Me.Mc2.TabIndex = 1
        Me.Mc2.UseVisualStyleBackColor = False
        '
        'mc1
        '
        Me.mc1.Appearance = System.Windows.Forms.Appearance.Button
        Me.mc1.BackColor = System.Drawing.Color.DimGray
        Me.mc1.Checked = Global.CodeChop.My.MySettings.Default.mc1
        Me.mc1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "mc1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.mc1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.mc1.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray
        Me.mc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mc1.Location = New System.Drawing.Point(7, 16)
        Me.mc1.Name = "mc1"
        Me.mc1.Size = New System.Drawing.Size(35, 23)
        Me.mc1.TabIndex = 0
        Me.mc1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(74, 309)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Z Retract"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(74, 285)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Near Clip Plane"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(172, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Step Delay"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(14, 370)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Sub CALL and RET Codes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(74, 397)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Call"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(74, 423)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Return"
        '
        'fanuc_cb
        '
        Me.fanuc_cb.AutoSize = True
        Me.fanuc_cb.BackColor = System.Drawing.Color.Transparent
        Me.fanuc_cb.Checked = Global.CodeChop.My.MySettings.Default.fanuc
        Me.fanuc_cb.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "fanuc", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.fanuc_cb.ForeColor = System.Drawing.Color.White
        Me.fanuc_cb.Location = New System.Drawing.Point(162, 370)
        Me.fanuc_cb.Name = "fanuc_cb"
        Me.fanuc_cb.Size = New System.Drawing.Size(95, 17)
        Me.fanuc_cb.TabIndex = 21
        Me.fanuc_cb.Text = "Fanuc/Okuma"
        Me.fanuc_cb.UseVisualStyleBackColor = False
        '
        'sub_return_tb
        '
        Me.sub_return_tb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeChop.My.MySettings.Default, "sub_return", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.sub_return_tb.Location = New System.Drawing.Point(19, 420)
        Me.sub_return_tb.Name = "sub_return_tb"
        Me.sub_return_tb.Size = New System.Drawing.Size(49, 20)
        Me.sub_return_tb.TabIndex = 20
        Me.sub_return_tb.Text = Global.CodeChop.My.MySettings.Default.sub_return
        Me.sub_return_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sub_call_tb
        '
        Me.sub_call_tb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeChop.My.MySettings.Default, "sub_call", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.sub_call_tb.Location = New System.Drawing.Point(19, 394)
        Me.sub_call_tb.Name = "sub_call_tb"
        Me.sub_call_tb.Size = New System.Drawing.Size(49, 20)
        Me.sub_call_tb.TabIndex = 19
        Me.sub_call_tb.Text = Global.CodeChop.My.MySettings.Default.sub_call
        Me.sub_call_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'abs_ckb
        '
        Me.abs_ckb.AutoSize = True
        Me.abs_ckb.BackColor = System.Drawing.Color.Transparent
        Me.abs_ckb.Checked = Global.CodeChop.My.MySettings.Default.abs_inc_mode
        Me.abs_ckb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.abs_ckb.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.CodeChop.My.MySettings.Default, "abs_inc_mode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.abs_ckb.ForeColor = System.Drawing.Color.White
        Me.abs_ckb.Location = New System.Drawing.Point(19, 333)
        Me.abs_ckb.Name = "abs_ckb"
        Me.abs_ckb.Size = New System.Drawing.Size(107, 17)
        Me.abs_ckb.TabIndex = 15
        Me.abs_ckb.Text = "ABS/INC Default"
        Me.abs_ckb.UseVisualStyleBackColor = False
        '
        'cb_steptime
        '
        Me.cb_steptime.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeChop.My.MySettings.Default, "step_time", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cb_steptime.FormattingEnabled = True
        Me.cb_steptime.Items.AddRange(New Object() {"100", "60", "30", "20", "10", "5", "1"})
        Me.cb_steptime.Location = New System.Drawing.Point(233, 282)
        Me.cb_steptime.Name = "cb_steptime"
        Me.cb_steptime.Size = New System.Drawing.Size(55, 21)
        Me.cb_steptime.TabIndex = 14
        Me.cb_steptime.Text = Global.CodeChop.My.MySettings.Default.step_time
        '
        'ComboBox2
        '
        Me.ComboBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeChop.My.MySettings.Default, "clip_plane", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {".1", ".05", ".03", ".02", ".01", ".005"})
        Me.ComboBox2.Location = New System.Drawing.Point(19, 282)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(49, 21)
        Me.ComboBox2.TabIndex = 12
        Me.ComboBox2.Text = Global.CodeChop.My.MySettings.Default.clip_plane
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeChop.My.MySettings.Default, "z_retract", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"5.0", "10.0", "15.0", "20.0", "25.0", "30.0", "35.0", "40.0"})
        Me.ComboBox1.Location = New System.Drawing.Point(19, 306)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(49, 21)
        Me.ComboBox1.TabIndex = 9
        Me.ComboBox1.Text = Global.CodeChop.My.MySettings.Default.z_retract
        '
        'Lighting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(300, 450)
        Me.Controls.Add(Me.fanuc_cb)
        Me.Controls.Add(Me.sub_return_tb)
        Me.Controls.Add(Me.sub_call_tb)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.abs_ckb)
        Me.Controls.Add(Me.cb_steptime)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Lighting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Light Level"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mc1 As System.Windows.Forms.RadioButton
    Friend WithEvents Mc6 As System.Windows.Forms.RadioButton
    Friend WithEvents Mc5 As System.Windows.Forms.RadioButton
    Friend WithEvents Mc4 As System.Windows.Forms.RadioButton
    Friend WithEvents Mc3 As System.Windows.Forms.RadioButton
    Friend WithEvents Mc2 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cb_steptime As System.Windows.Forms.ComboBox
    Friend WithEvents abs_ckb As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents sub_call_tb As System.Windows.Forms.TextBox
    Friend WithEvents sub_return_tb As System.Windows.Forms.TextBox
    Friend WithEvents fanuc_cb As System.Windows.Forms.CheckBox
End Class
