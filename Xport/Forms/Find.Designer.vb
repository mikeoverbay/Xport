<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.find_TB = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.rpl_TB = New System.Windows.Forms.TextBox
        Me.pbar = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(131, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Find"
        '
        'find_TB
        '
        Me.find_TB.BackColor = System.Drawing.Color.White
        Me.find_TB.ForeColor = System.Drawing.Color.Black
        Me.find_TB.Location = New System.Drawing.Point(54, 24)
        Me.find_TB.Name = "find_TB"
        Me.find_TB.Size = New System.Drawing.Size(192, 20)
        Me.find_TB.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(110, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Replace With"
        '
        'rpl_TB
        '
        Me.rpl_TB.BackColor = System.Drawing.Color.White
        Me.rpl_TB.ForeColor = System.Drawing.Color.Black
        Me.rpl_TB.Location = New System.Drawing.Point(54, 114)
        Me.rpl_TB.Name = "rpl_TB"
        Me.rpl_TB.Size = New System.Drawing.Size(192, 20)
        Me.rpl_TB.TabIndex = 3
        '
        'pbar
        '
        Me.pbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pbar.Location = New System.Drawing.Point(0, 180)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(300, 20)
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar.TabIndex = 4
        '
        'Find
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CodeChop.My.Resources.Resources.light_background
        Me.ClientSize = New System.Drawing.Size(300, 200)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.rpl_TB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.find_TB)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.CodeChop.My.MySettings.Default, "find_location", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = Global.CodeChop.My.MySettings.Default.find_location
        Me.Name = "Find"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents find_TB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rpl_TB As System.Windows.Forms.TextBox
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
End Class
