<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class com_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(com_Settings))
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.cb_port = New System.Windows.Forms.ComboBox
        Me.tb_name = New System.Windows.Forms.TextBox
        Me.cb_baud = New System.Windows.Forms.ComboBox
        Me.cb_databits = New System.Windows.Forms.ComboBox
        Me.cb_stopbits = New System.Windows.Forms.ComboBox
        Me.cb_parity = New System.Windows.Forms.ComboBox
        Me.cb_handshake = New System.Windows.Forms.ComboBox
        Me.cb_send_comments = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btn_close = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_add = New System.Windows.Forms.Button
        Me.edit_container = New System.Windows.Forms.GroupBox
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.edit_container.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(0, 0)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(670, 225)
        Me.DGV1.TabIndex = 0
        '
        'cb_port
        '
        Me.cb_port.FormattingEnabled = True
        Me.cb_port.Location = New System.Drawing.Point(152, 33)
        Me.cb_port.Name = "cb_port"
        Me.cb_port.Size = New System.Drawing.Size(74, 21)
        Me.cb_port.TabIndex = 1
        '
        'tb_name
        '
        Me.tb_name.Location = New System.Drawing.Point(6, 34)
        Me.tb_name.Name = "tb_name"
        Me.tb_name.Size = New System.Drawing.Size(140, 20)
        Me.tb_name.TabIndex = 2
        '
        'cb_baud
        '
        Me.cb_baud.FormattingEnabled = True
        Me.cb_baud.Items.AddRange(New Object() {"300", "600", "1200", "2400", "4800", "9600"})
        Me.cb_baud.Location = New System.Drawing.Point(232, 34)
        Me.cb_baud.Name = "cb_baud"
        Me.cb_baud.Size = New System.Drawing.Size(90, 21)
        Me.cb_baud.TabIndex = 3
        '
        'cb_databits
        '
        Me.cb_databits.FormattingEnabled = True
        Me.cb_databits.Items.AddRange(New Object() {"7", "8"})
        Me.cb_databits.Location = New System.Drawing.Point(328, 34)
        Me.cb_databits.Name = "cb_databits"
        Me.cb_databits.Size = New System.Drawing.Size(53, 21)
        Me.cb_databits.TabIndex = 4
        '
        'cb_stopbits
        '
        Me.cb_stopbits.FormattingEnabled = True
        Me.cb_stopbits.Items.AddRange(New Object() {"0", "1", "2"})
        Me.cb_stopbits.Location = New System.Drawing.Point(387, 34)
        Me.cb_stopbits.Name = "cb_stopbits"
        Me.cb_stopbits.Size = New System.Drawing.Size(53, 21)
        Me.cb_stopbits.TabIndex = 5
        '
        'cb_parity
        '
        Me.cb_parity.FormattingEnabled = True
        Me.cb_parity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.cb_parity.Location = New System.Drawing.Point(446, 34)
        Me.cb_parity.Name = "cb_parity"
        Me.cb_parity.Size = New System.Drawing.Size(73, 21)
        Me.cb_parity.TabIndex = 6
        '
        'cb_handshake
        '
        Me.cb_handshake.FormattingEnabled = True
        Me.cb_handshake.Items.AddRange(New Object() {"None", "Xon/Xoff", "ReqToSend", "ReqToSend Xon/Xoff"})
        Me.cb_handshake.Location = New System.Drawing.Point(525, 34)
        Me.cb_handshake.Name = "cb_handshake"
        Me.cb_handshake.Size = New System.Drawing.Size(84, 21)
        Me.cb_handshake.TabIndex = 7
        '
        'cb_send_comments
        '
        Me.cb_send_comments.AutoSize = True
        Me.cb_send_comments.Checked = True
        Me.cb_send_comments.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_send_comments.Location = New System.Drawing.Point(6, 60)
        Me.cb_send_comments.Name = "cb_send_comments"
        Me.cb_send_comments.Size = New System.Drawing.Size(103, 17)
        Me.cb_send_comments.TabIndex = 8
        Me.cb_send_comments.Text = "Send Comments"
        Me.cb_send_comments.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(149, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(229, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Baud"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(325, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Data Bits"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(384, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Stop Bits"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(443, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Parity"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(522, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Handshake"
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_close.Location = New System.Drawing.Point(580, 321)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 16
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_edit.Location = New System.Drawing.Point(302, 321)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 23)
        Me.btn_edit.TabIndex = 17
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Location = New System.Drawing.Point(383, 321)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_add.Location = New System.Drawing.Point(11, 321)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 19
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'edit_container
        '
        Me.edit_container.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.edit_container.Controls.Add(Me.cb_port)
        Me.edit_container.Controls.Add(Me.tb_name)
        Me.edit_container.Controls.Add(Me.cb_baud)
        Me.edit_container.Controls.Add(Me.cb_databits)
        Me.edit_container.Controls.Add(Me.cb_stopbits)
        Me.edit_container.Controls.Add(Me.Label7)
        Me.edit_container.Controls.Add(Me.cb_parity)
        Me.edit_container.Controls.Add(Me.Label6)
        Me.edit_container.Controls.Add(Me.cb_handshake)
        Me.edit_container.Controls.Add(Me.Label5)
        Me.edit_container.Controls.Add(Me.cb_send_comments)
        Me.edit_container.Controls.Add(Me.Label4)
        Me.edit_container.Controls.Add(Me.Label1)
        Me.edit_container.Controls.Add(Me.Label3)
        Me.edit_container.Controls.Add(Me.Label2)
        Me.edit_container.Location = New System.Drawing.Point(12, 231)
        Me.edit_container.Name = "edit_container"
        Me.edit_container.Size = New System.Drawing.Size(644, 84)
        Me.edit_container.TabIndex = 20
        Me.edit_container.TabStop = False
        Me.edit_container.Text = "Client Settings"
        '
        'btn_cancel
        '
        Me.btn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_cancel.Location = New System.Drawing.Point(464, 321)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 21
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_delete.Location = New System.Drawing.Point(163, 321)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_delete.TabIndex = 22
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'com_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 356)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.edit_container)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.DGV1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(676, 1024)
        Me.MinimumSize = New System.Drawing.Size(676, 380)
        Me.Name = "com_Settings"
        Me.Text = "Client Settings"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.edit_container.ResumeLayout(False)
        Me.edit_container.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents cb_port As System.Windows.Forms.ComboBox
    Friend WithEvents tb_name As System.Windows.Forms.TextBox
    Friend WithEvents cb_baud As System.Windows.Forms.ComboBox
    Friend WithEvents cb_databits As System.Windows.Forms.ComboBox
    Friend WithEvents cb_stopbits As System.Windows.Forms.ComboBox
    Friend WithEvents cb_parity As System.Windows.Forms.ComboBox
    Friend WithEvents cb_handshake As System.Windows.Forms.ComboBox
    Friend WithEvents cb_send_comments As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents edit_container As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button

End Class
