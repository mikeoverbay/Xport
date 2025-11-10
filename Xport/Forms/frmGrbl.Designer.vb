<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrbl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrbl))
        Me.btn_snd = New System.Windows.Forms.Button
        Me.cb_client = New System.Windows.Forms.ComboBox
        Me.btn_close = New System.Windows.Forms.Button
        Me.btn_abort = New System.Windows.Forms.Button
        Me.btn_rcv = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.pg1 = New System.Windows.Forms.ProgressBar
        Me.tb_percent = New System.Windows.Forms.Label
        Me.btn_ftypes = New System.Windows.Forms.Button
        Me.btn_done = New System.Windows.Forms.Button
        Me.tb_output = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_snd
        '
        Me.btn_snd.Location = New System.Drawing.Point(113, 39)
        Me.btn_snd.Name = "btn_snd"
        Me.btn_snd.Size = New System.Drawing.Size(75, 23)
        Me.btn_snd.TabIndex = 0
        Me.btn_snd.Text = "Send File"
        Me.btn_snd.UseVisualStyleBackColor = True
        '
        'cb_client
        '
        Me.cb_client.FormattingEnabled = True
        Me.cb_client.Location = New System.Drawing.Point(113, 12)
        Me.cb_client.Name = "cb_client"
        Me.cb_client.Size = New System.Drawing.Size(163, 21)
        Me.cb_client.TabIndex = 1
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(294, 73)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 2
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_abort
        '
        Me.btn_abort.Enabled = False
        Me.btn_abort.Location = New System.Drawing.Point(113, 73)
        Me.btn_abort.Name = "btn_abort"
        Me.btn_abort.Size = New System.Drawing.Size(163, 23)
        Me.btn_abort.TabIndex = 3
        Me.btn_abort.Text = "Abort"
        Me.btn_abort.UseVisualStyleBackColor = True
        '
        'btn_rcv
        '
        Me.btn_rcv.Location = New System.Drawing.Point(201, 39)
        Me.btn_rcv.Name = "btn_rcv"
        Me.btn_rcv.Size = New System.Drawing.Size(75, 23)
        Me.btn_rcv.TabIndex = 4
        Me.btn_rcv.Text = "Receive File"
        Me.btn_rcv.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(294, 12)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 5
        Me.btn_edit.Text = "Edit Clients"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'pg1
        '
        Me.pg1.Location = New System.Drawing.Point(12, 111)
        Me.pg1.Name = "pg1"
        Me.pg1.Size = New System.Drawing.Size(264, 22)
        Me.pg1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pg1.TabIndex = 7
        '
        'tb_percent
        '
        Me.tb_percent.AutoSize = True
        Me.tb_percent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_percent.ForeColor = System.Drawing.Color.White
        Me.tb_percent.Location = New System.Drawing.Point(284, 116)
        Me.tb_percent.Name = "tb_percent"
        Me.tb_percent.Size = New System.Drawing.Size(51, 13)
        Me.tb_percent.TabIndex = 8
        Me.tb_percent.Text = "Percent"
        '
        'btn_ftypes
        '
        Me.btn_ftypes.Location = New System.Drawing.Point(294, 41)
        Me.btn_ftypes.Name = "btn_ftypes"
        Me.btn_ftypes.Size = New System.Drawing.Size(75, 23)
        Me.btn_ftypes.TabIndex = 9
        Me.btn_ftypes.Text = "File Types"
        Me.btn_ftypes.UseVisualStyleBackColor = True
        '
        'btn_done
        '
        Me.btn_done.Location = New System.Drawing.Point(341, 111)
        Me.btn_done.Name = "btn_done"
        Me.btn_done.Size = New System.Drawing.Size(31, 23)
        Me.btn_done.TabIndex = 10
        Me.btn_done.Text = "OK"
        Me.btn_done.UseVisualStyleBackColor = True
        '
        'tb_output
        '
        Me.tb_output.BackColor = System.Drawing.Color.Black
        Me.tb_output.Enabled = False
        Me.tb_output.ForeColor = System.Drawing.Color.White
        Me.tb_output.Location = New System.Drawing.Point(12, 139)
        Me.tb_output.Name = "tb_output"
        Me.tb_output.Size = New System.Drawing.Size(322, 20)
        Me.tb_output.TabIndex = 11
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.FilterIndex = Global.com_console.My.MySettings.Default.filterIndex
        Me.OpenFileDialog1.InitialDirectory = Global.com_console.My.MySettings.Default.file_path
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = Global.com_console.My.MySettings.Default.save_file_name
        Me.SaveFileDialog1.FilterIndex = Global.com_console.My.MySettings.Default.save_filterIndex
        Me.SaveFileDialog1.InitialDirectory = Global.com_console.My.MySettings.Default.save_file_path
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(86, 84)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(384, 169)
        Me.Controls.Add(Me.tb_output)
        Me.Controls.Add(Me.btn_done)
        Me.Controls.Add(Me.btn_ftypes)
        Me.Controls.Add(Me.tb_percent)
        Me.Controls.Add(Me.pg1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_rcv)
        Me.Controls.Add(Me.btn_abort)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.cb_client)
        Me.Controls.Add(Me.btn_snd)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("StartPosition", Global.com_console.My.MySettings.Default, "com_startup", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(400, 400)
        Me.Name = "frmMain"
        Me.StartPosition = Global.com_console.My.MySettings.Default.com_startup
        Me.Text = "Com Console"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_snd As System.Windows.Forms.Button
    Friend WithEvents cb_client As System.Windows.Forms.ComboBox
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_abort As System.Windows.Forms.Button
    Friend WithEvents btn_rcv As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tb_percent As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_ftypes As System.Windows.Forms.Button
    Friend WithEvents btn_done As System.Windows.Forms.Button
    Friend WithEvents tb_output As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
