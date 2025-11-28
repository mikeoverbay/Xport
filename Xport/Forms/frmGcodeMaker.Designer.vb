<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGcodeMaker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.close_btn = New System.Windows.Forms.Button()
        Me.lblStartX = New System.Windows.Forms.Label()
        Me.lblStartY = New System.Windows.Forms.Label()
        Me.txtStartX = New System.Windows.Forms.TextBox()
        Me.txtStartY = New System.Windows.Forms.TextBox()
        Me.lblSizeX = New System.Windows.Forms.Label()
        Me.lblSizeY = New System.Windows.Forms.Label()
        Me.txtSizeX = New System.Windows.Forms.TextBox()
        Me.txtSizeY = New System.Windows.Forms.TextBox()
        Me.lblFinalDepth = New System.Windows.Forms.Label()
        Me.txtFinalDepth = New System.Windows.Forms.TextBox()
        Me.lblStepPerPass = New System.Windows.Forms.Label()
        Me.txtStepPerPass = New System.Windows.Forms.TextBox()
        Me.lblToolDia = New System.Windows.Forms.Label()
        Me.txtToolDia = New System.Windows.Forms.TextBox()
        Me.lblBorder = New System.Windows.Forms.Label()
        Me.txtBorder = New System.Windows.Forms.TextBox()
        Me.lblEntryFeed = New System.Windows.Forms.Label()
        Me.txtEntryFeed = New System.Windows.Forms.TextBox()
        Me.lblCutFeed = New System.Windows.Forms.Label()
        Me.txtCutFeed = New System.Windows.Forms.TextBox()
        Me.lblRPM = New System.Windows.Forms.Label()
        Me.txtRPM = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.circular_cutout_rb = New System.Windows.Forms.RadioButton()
        Me.cutout_3sides_rb = New System.Windows.Forms.RadioButton()
        Me.cutout_rb = New System.Windows.Forms.RadioButton()
        Me.rbCircle = New System.Windows.Forms.RadioButton()
        Me.rbPocket = New System.Windows.Forms.RadioButton()
        Me.rbFace = New System.Windows.Forms.RadioButton()
        Me.execute_btn = New System.Windows.Forms.Button()
        Me.y_countTB = New System.Windows.Forms.TextBox()
        Me.x_countTB = New System.Windows.Forms.TextBox()
        Me.labelYcount = New System.Windows.Forms.Label()
        Me.labelXcount = New System.Windows.Forms.Label()
        Me.txtPercentCut = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecision = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'close_btn
        '
        Me.close_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.close_btn.AutoSize = True
        Me.close_btn.BackColor = System.Drawing.Color.Transparent
        Me.close_btn.BackgroundImage = Global.CodeChop.My.Resources.Resources.cross
        Me.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.close_btn.Location = New System.Drawing.Point(519, 12)
        Me.close_btn.Name = "close_btn"
        Me.close_btn.Size = New System.Drawing.Size(29, 25)
        Me.close_btn.TabIndex = 0
        Me.close_btn.UseVisualStyleBackColor = False
        '
        'lblStartX
        '
        Me.lblStartX.AutoSize = True
        Me.lblStartX.BackColor = System.Drawing.Color.Transparent
        Me.lblStartX.ForeColor = System.Drawing.Color.White
        Me.lblStartX.Location = New System.Drawing.Point(20, 50)
        Me.lblStartX.Name = "lblStartX"
        Me.lblStartX.Size = New System.Drawing.Size(61, 13)
        Me.lblStartX.TabIndex = 1
        Me.lblStartX.Text = "Start X (X0)"
        '
        'lblStartY
        '
        Me.lblStartY.AutoSize = True
        Me.lblStartY.BackColor = System.Drawing.Color.Transparent
        Me.lblStartY.ForeColor = System.Drawing.Color.White
        Me.lblStartY.Location = New System.Drawing.Point(20, 76)
        Me.lblStartY.Name = "lblStartY"
        Me.lblStartY.Size = New System.Drawing.Size(61, 13)
        Me.lblStartY.TabIndex = 2
        Me.lblStartY.Text = "Start Y (Y0)"
        '
        'txtStartX
        '
        Me.txtStartX.Location = New System.Drawing.Point(110, 47)
        Me.txtStartX.Name = "txtStartX"
        Me.txtStartX.Size = New System.Drawing.Size(127, 20)
        Me.txtStartX.TabIndex = 1
        Me.txtStartX.Text = "0.0"
        '
        'txtStartY
        '
        Me.txtStartY.Location = New System.Drawing.Point(110, 73)
        Me.txtStartY.Name = "txtStartY"
        Me.txtStartY.Size = New System.Drawing.Size(127, 20)
        Me.txtStartY.TabIndex = 2
        Me.txtStartY.Text = "0.0"
        '
        'lblSizeX
        '
        Me.lblSizeX.AutoSize = True
        Me.lblSizeX.BackColor = System.Drawing.Color.Transparent
        Me.lblSizeX.ForeColor = System.Drawing.Color.White
        Me.lblSizeX.Location = New System.Drawing.Point(20, 108)
        Me.lblSizeX.Name = "lblSizeX"
        Me.lblSizeX.Size = New System.Drawing.Size(71, 13)
        Me.lblSizeX.TabIndex = 3
        Me.lblSizeX.Text = "Size X (width)"
        '
        'lblSizeY
        '
        Me.lblSizeY.AutoSize = True
        Me.lblSizeY.BackColor = System.Drawing.Color.Transparent
        Me.lblSizeY.ForeColor = System.Drawing.Color.White
        Me.lblSizeY.Location = New System.Drawing.Point(20, 134)
        Me.lblSizeY.Name = "lblSizeY"
        Me.lblSizeY.Size = New System.Drawing.Size(75, 13)
        Me.lblSizeY.TabIndex = 4
        Me.lblSizeY.Text = "Size Y (height)"
        '
        'txtSizeX
        '
        Me.txtSizeX.Location = New System.Drawing.Point(110, 105)
        Me.txtSizeX.Name = "txtSizeX"
        Me.txtSizeX.Size = New System.Drawing.Size(127, 20)
        Me.txtSizeX.TabIndex = 3
        Me.txtSizeX.Text = "20.0"
        '
        'txtSizeY
        '
        Me.txtSizeY.Location = New System.Drawing.Point(110, 131)
        Me.txtSizeY.Name = "txtSizeY"
        Me.txtSizeY.Size = New System.Drawing.Size(127, 20)
        Me.txtSizeY.TabIndex = 4
        Me.txtSizeY.Text = "10.0"
        '
        'lblFinalDepth
        '
        Me.lblFinalDepth.AutoSize = True
        Me.lblFinalDepth.BackColor = System.Drawing.Color.Transparent
        Me.lblFinalDepth.ForeColor = System.Drawing.Color.White
        Me.lblFinalDepth.Location = New System.Drawing.Point(20, 166)
        Me.lblFinalDepth.Name = "lblFinalDepth"
        Me.lblFinalDepth.Size = New System.Drawing.Size(77, 13)
        Me.lblFinalDepth.TabIndex = 5
        Me.lblFinalDepth.Text = "Final Depth (Z)"
        '
        'txtFinalDepth
        '
        Me.txtFinalDepth.Location = New System.Drawing.Point(110, 163)
        Me.txtFinalDepth.Name = "txtFinalDepth"
        Me.txtFinalDepth.Size = New System.Drawing.Size(127, 20)
        Me.txtFinalDepth.TabIndex = 5
        Me.txtFinalDepth.Text = "-0.25"
        '
        'lblStepPerPass
        '
        Me.lblStepPerPass.AutoSize = True
        Me.lblStepPerPass.BackColor = System.Drawing.Color.Transparent
        Me.lblStepPerPass.ForeColor = System.Drawing.Color.White
        Me.lblStepPerPass.Location = New System.Drawing.Point(20, 192)
        Me.lblStepPerPass.Name = "lblStepPerPass"
        Me.lblStepPerPass.Size = New System.Drawing.Size(70, 13)
        Me.lblStepPerPass.TabIndex = 6
        Me.lblStepPerPass.Text = "Z Step Count"
        '
        'txtStepPerPass
        '
        Me.txtStepPerPass.Location = New System.Drawing.Point(110, 189)
        Me.txtStepPerPass.Name = "txtStepPerPass"
        Me.txtStepPerPass.Size = New System.Drawing.Size(127, 20)
        Me.txtStepPerPass.TabIndex = 6
        Me.txtStepPerPass.Text = "1.0"
        '
        'lblToolDia
        '
        Me.lblToolDia.AutoSize = True
        Me.lblToolDia.BackColor = System.Drawing.Color.Transparent
        Me.lblToolDia.ForeColor = System.Drawing.Color.White
        Me.lblToolDia.Location = New System.Drawing.Point(20, 218)
        Me.lblToolDia.Name = "lblToolDia"
        Me.lblToolDia.Size = New System.Drawing.Size(64, 13)
        Me.lblToolDia.TabIndex = 7
        Me.lblToolDia.Text = "Tool Dia (Ø)"
        '
        'txtToolDia
        '
        Me.txtToolDia.Location = New System.Drawing.Point(110, 215)
        Me.txtToolDia.Name = "txtToolDia"
        Me.txtToolDia.Size = New System.Drawing.Size(127, 20)
        Me.txtToolDia.TabIndex = 7
        Me.txtToolDia.Text = "1.0"
        '
        'lblBorder
        '
        Me.lblBorder.AutoSize = True
        Me.lblBorder.BackColor = System.Drawing.Color.Transparent
        Me.lblBorder.ForeColor = System.Drawing.Color.White
        Me.lblBorder.Location = New System.Drawing.Point(20, 244)
        Me.lblBorder.Name = "lblBorder"
        Me.lblBorder.Size = New System.Drawing.Size(77, 13)
        Me.lblBorder.TabIndex = 8
        Me.lblBorder.Text = "Border / Stock"
        '
        'txtBorder
        '
        Me.txtBorder.Location = New System.Drawing.Point(110, 241)
        Me.txtBorder.Name = "txtBorder"
        Me.txtBorder.Size = New System.Drawing.Size(127, 20)
        Me.txtBorder.TabIndex = 8
        Me.txtBorder.Text = "0.0"
        '
        'lblEntryFeed
        '
        Me.lblEntryFeed.AutoSize = True
        Me.lblEntryFeed.BackColor = System.Drawing.Color.Transparent
        Me.lblEntryFeed.ForeColor = System.Drawing.Color.White
        Me.lblEntryFeed.Location = New System.Drawing.Point(306, 50)
        Me.lblEntryFeed.Name = "lblEntryFeed"
        Me.lblEntryFeed.Size = New System.Drawing.Size(58, 13)
        Me.lblEntryFeed.TabIndex = 9
        Me.lblEntryFeed.Text = "Entry Feed"
        '
        'txtEntryFeed
        '
        Me.txtEntryFeed.Location = New System.Drawing.Point(396, 47)
        Me.txtEntryFeed.Name = "txtEntryFeed"
        Me.txtEntryFeed.Size = New System.Drawing.Size(127, 20)
        Me.txtEntryFeed.TabIndex = 9
        Me.txtEntryFeed.Text = "12.0"
        '
        'lblCutFeed
        '
        Me.lblCutFeed.AutoSize = True
        Me.lblCutFeed.BackColor = System.Drawing.Color.Transparent
        Me.lblCutFeed.ForeColor = System.Drawing.Color.White
        Me.lblCutFeed.Location = New System.Drawing.Point(306, 76)
        Me.lblCutFeed.Name = "lblCutFeed"
        Me.lblCutFeed.Size = New System.Drawing.Size(50, 13)
        Me.lblCutFeed.TabIndex = 10
        Me.lblCutFeed.Text = "Cut Feed"
        '
        'txtCutFeed
        '
        Me.txtCutFeed.Location = New System.Drawing.Point(396, 73)
        Me.txtCutFeed.Name = "txtCutFeed"
        Me.txtCutFeed.Size = New System.Drawing.Size(127, 20)
        Me.txtCutFeed.TabIndex = 10
        Me.txtCutFeed.Text = "60.0"
        '
        'lblRPM
        '
        Me.lblRPM.AutoSize = True
        Me.lblRPM.BackColor = System.Drawing.Color.Transparent
        Me.lblRPM.ForeColor = System.Drawing.Color.White
        Me.lblRPM.Location = New System.Drawing.Point(306, 102)
        Me.lblRPM.Name = "lblRPM"
        Me.lblRPM.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM.TabIndex = 11
        Me.lblRPM.Text = "RPM"
        '
        'txtRPM
        '
        Me.txtRPM.Location = New System.Drawing.Point(396, 99)
        Me.txtRPM.Name = "txtRPM"
        Me.txtRPM.Size = New System.Drawing.Size(127, 20)
        Me.txtRPM.TabIndex = 11
        Me.txtRPM.Text = "14000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Path Maker"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.circular_cutout_rb)
        Me.GroupBox1.Controls.Add(Me.cutout_3sides_rb)
        Me.GroupBox1.Controls.Add(Me.cutout_rb)
        Me.GroupBox1.Controls.Add(Me.rbCircle)
        Me.GroupBox1.Controls.Add(Me.rbPocket)
        Me.GroupBox1.Controls.Add(Me.rbFace)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(16, 281)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 88)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Path Type"
        '
        'circular_cutout_rb
        '
        Me.circular_cutout_rb.AutoSize = True
        Me.circular_cutout_rb.ForeColor = System.Drawing.Color.White
        Me.circular_cutout_rb.Location = New System.Drawing.Point(114, 65)
        Me.circular_cutout_rb.Name = "circular_cutout_rb"
        Me.circular_cutout_rb.Size = New System.Drawing.Size(99, 17)
        Me.circular_cutout_rb.TabIndex = 22
        Me.circular_cutout_rb.TabStop = True
        Me.circular_cutout_rb.Text = "Circular Cut Out"
        Me.circular_cutout_rb.UseVisualStyleBackColor = True
        '
        'cutout_3sides_rb
        '
        Me.cutout_3sides_rb.AutoSize = True
        Me.cutout_3sides_rb.ForeColor = System.Drawing.Color.White
        Me.cutout_3sides_rb.Location = New System.Drawing.Point(114, 42)
        Me.cutout_3sides_rb.Name = "cutout_3sides_rb"
        Me.cutout_3sides_rb.Size = New System.Drawing.Size(99, 17)
        Me.cutout_3sides_rb.TabIndex = 21
        Me.cutout_3sides_rb.TabStop = True
        Me.cutout_3sides_rb.Text = "Cut Out 3 Sides"
        Me.cutout_3sides_rb.UseVisualStyleBackColor = True
        '
        'cutout_rb
        '
        Me.cutout_rb.AutoSize = True
        Me.cutout_rb.ForeColor = System.Drawing.Color.White
        Me.cutout_rb.Location = New System.Drawing.Point(114, 19)
        Me.cutout_rb.Name = "cutout_rb"
        Me.cutout_rb.Size = New System.Drawing.Size(99, 17)
        Me.cutout_rb.TabIndex = 20
        Me.cutout_rb.TabStop = True
        Me.cutout_rb.Text = "Cut Out 4 Sides"
        Me.cutout_rb.UseVisualStyleBackColor = True
        '
        'rbCircle
        '
        Me.rbCircle.AutoSize = True
        Me.rbCircle.ForeColor = System.Drawing.Color.White
        Me.rbCircle.Location = New System.Drawing.Point(16, 65)
        Me.rbCircle.Name = "rbCircle"
        Me.rbCircle.Size = New System.Drawing.Size(88, 17)
        Me.rbCircle.TabIndex = 19
        Me.rbCircle.TabStop = True
        Me.rbCircle.Text = "Circle Pocket"
        Me.rbCircle.UseVisualStyleBackColor = True
        '
        'rbPocket
        '
        Me.rbPocket.AutoSize = True
        Me.rbPocket.ForeColor = System.Drawing.Color.White
        Me.rbPocket.Location = New System.Drawing.Point(16, 42)
        Me.rbPocket.Name = "rbPocket"
        Me.rbPocket.Size = New System.Drawing.Size(59, 17)
        Me.rbPocket.TabIndex = 18
        Me.rbPocket.TabStop = True
        Me.rbPocket.Text = "Pocket"
        Me.rbPocket.UseVisualStyleBackColor = True
        '
        'rbFace
        '
        Me.rbFace.AutoSize = True
        Me.rbFace.ForeColor = System.Drawing.Color.White
        Me.rbFace.Location = New System.Drawing.Point(16, 19)
        Me.rbFace.Name = "rbFace"
        Me.rbFace.Size = New System.Drawing.Size(74, 17)
        Me.rbFace.TabIndex = 17
        Me.rbFace.TabStop = True
        Me.rbFace.Text = "Face Area"
        Me.rbFace.UseVisualStyleBackColor = True
        '
        'execute_btn
        '
        Me.execute_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.execute_btn.Location = New System.Drawing.Point(396, 331)
        Me.execute_btn.Name = "execute_btn"
        Me.execute_btn.Size = New System.Drawing.Size(116, 32)
        Me.execute_btn.TabIndex = 23
        Me.execute_btn.Text = "Execute"
        Me.execute_btn.UseVisualStyleBackColor = True
        '
        'y_countTB
        '
        Me.y_countTB.Location = New System.Drawing.Point(396, 158)
        Me.y_countTB.Name = "y_countTB"
        Me.y_countTB.Size = New System.Drawing.Size(127, 20)
        Me.y_countTB.TabIndex = 13
        Me.y_countTB.Text = "0.0"
        '
        'x_countTB
        '
        Me.x_countTB.Location = New System.Drawing.Point(396, 132)
        Me.x_countTB.Name = "x_countTB"
        Me.x_countTB.Size = New System.Drawing.Size(127, 20)
        Me.x_countTB.TabIndex = 12
        Me.x_countTB.Tag = "0.0"
        Me.x_countTB.Text = "0.0"
        '
        'labelYcount
        '
        Me.labelYcount.AutoSize = True
        Me.labelYcount.BackColor = System.Drawing.Color.Transparent
        Me.labelYcount.ForeColor = System.Drawing.Color.White
        Me.labelYcount.Location = New System.Drawing.Point(306, 161)
        Me.labelYcount.Name = "labelYcount"
        Me.labelYcount.Size = New System.Drawing.Size(45, 13)
        Me.labelYcount.TabIndex = 27
        Me.labelYcount.Text = "Y Count"
        '
        'labelXcount
        '
        Me.labelXcount.AutoSize = True
        Me.labelXcount.BackColor = System.Drawing.Color.Transparent
        Me.labelXcount.ForeColor = System.Drawing.Color.White
        Me.labelXcount.Location = New System.Drawing.Point(306, 135)
        Me.labelXcount.Name = "labelXcount"
        Me.labelXcount.Size = New System.Drawing.Size(45, 13)
        Me.labelXcount.TabIndex = 25
        Me.labelXcount.Text = "X Count"
        '
        'txtPercentCut
        '
        Me.txtPercentCut.Location = New System.Drawing.Point(395, 215)
        Me.txtPercentCut.Name = "txtPercentCut"
        Me.txtPercentCut.Size = New System.Drawing.Size(127, 20)
        Me.txtPercentCut.TabIndex = 14
        Me.txtPercentCut.Text = "50"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(251, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Percent of cutter (cut width)"
        '
        'txtPrecision
        '
        Me.txtPrecision.Location = New System.Drawing.Point(395, 241)
        Me.txtPrecision.Name = "txtPrecision"
        Me.txtPrecision.Size = New System.Drawing.Size(127, 20)
        Me.txtPrecision.TabIndex = 15
        Me.txtPrecision.Text = "60.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(271, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Segments/360 degrees"
        '
        'frmGcodeMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.CodeChop.My.Resources.Resources.process_bg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(560, 389)
        Me.Controls.Add(Me.txtPrecision)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPercentCut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.y_countTB)
        Me.Controls.Add(Me.x_countTB)
        Me.Controls.Add(Me.labelYcount)
        Me.Controls.Add(Me.labelXcount)
        Me.Controls.Add(Me.execute_btn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRPM)
        Me.Controls.Add(Me.lblRPM)
        Me.Controls.Add(Me.txtCutFeed)
        Me.Controls.Add(Me.lblCutFeed)
        Me.Controls.Add(Me.txtEntryFeed)
        Me.Controls.Add(Me.lblEntryFeed)
        Me.Controls.Add(Me.txtBorder)
        Me.Controls.Add(Me.lblBorder)
        Me.Controls.Add(Me.txtToolDia)
        Me.Controls.Add(Me.lblToolDia)
        Me.Controls.Add(Me.txtStepPerPass)
        Me.Controls.Add(Me.lblStepPerPass)
        Me.Controls.Add(Me.txtFinalDepth)
        Me.Controls.Add(Me.lblFinalDepth)
        Me.Controls.Add(Me.txtSizeY)
        Me.Controls.Add(Me.txtSizeX)
        Me.Controls.Add(Me.lblSizeY)
        Me.Controls.Add(Me.lblSizeX)
        Me.Controls.Add(Me.txtStartY)
        Me.Controls.Add(Me.txtStartX)
        Me.Controls.Add(Me.lblStartY)
        Me.Controls.Add(Me.lblStartX)
        Me.Controls.Add(Me.close_btn)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGcodeMaker"
        Me.Text = "frmGcodeMaker"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents close_btn As Button
    Friend WithEvents lblStartX As Label
    Friend WithEvents lblStartY As Label
    Friend WithEvents txtStartX As TextBox
    Friend WithEvents txtStartY As TextBox
    Friend WithEvents lblSizeX As Label
    Friend WithEvents lblSizeY As Label
    Friend WithEvents txtSizeX As TextBox
    Friend WithEvents txtSizeY As TextBox
    Friend WithEvents lblFinalDepth As Label
    Friend WithEvents txtFinalDepth As TextBox
    Friend WithEvents lblStepPerPass As Label
    Friend WithEvents txtStepPerPass As TextBox
    Friend WithEvents lblToolDia As Label
    Friend WithEvents txtToolDia As TextBox
    Friend WithEvents lblBorder As Label
    Friend WithEvents txtBorder As TextBox
    Friend WithEvents lblEntryFeed As Label
    Friend WithEvents txtEntryFeed As TextBox
    Friend WithEvents lblCutFeed As Label
    Friend WithEvents txtCutFeed As TextBox
    Friend WithEvents lblRPM As Label
    Friend WithEvents txtRPM As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbFace As RadioButton
    Friend WithEvents rbPocket As RadioButton
    Friend WithEvents rbCircle As RadioButton
    Friend WithEvents cutout_rb As RadioButton
    Friend WithEvents cutout_3sides_rb As RadioButton
    Friend WithEvents circular_cutout_rb As RadioButton
    Friend WithEvents execute_btn As Button
    Friend WithEvents y_countTB As TextBox
    Friend WithEvents x_countTB As TextBox
    Friend WithEvents labelYcount As Label
    Friend WithEvents labelXcount As Label
    Friend WithEvents txtPercentCut As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrecision As TextBox
    Friend WithEvents Label3 As Label
End Class
