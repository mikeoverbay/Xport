Public Class Re_number
    Private renum_mouse As New Point
    Public cb As New my_Frm_Btn
    Public doit As New my_Btn

    Private Sub Re_number_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        zoom_window.TopMost = False
        With frmMain
            Me.Height = 90
            cb.Image = My.Resources.cross
            cb.Name = "cb"
            cb.Location = New Point(Me.Width - 27, 3)
            AddHandler cb.Click, AddressOf close_me

            doit.Location = New Point(Me.Width - 58, 40)
            doit.Name = "doit"
            AddHandler doit.Click, AddressOf do_it
            Dim cn As Int16 = Me.Controls.Count
            'Try
            '    Me.Controls.RemoveAt(7)
            '    Me.Controls.RemoveAt(8)
            'Catch ex As Exception

            'End Try
            Me.Controls.Add(cb)
            Me.Controls.Add(doit)
            doit.Text = "OK"
            doit.ForeColor = Color.White
            ComboBox1.SelectedIndex = My.Settings.ln_num_pad
            rn_start_TB.Focus()
        End With
    End Sub
    Private Sub close_me()
        zoom_window.TopMost = True
        frmMain.btn_renum.Enabled = True
        frmMain.btn_del_num.Enabled = True
        Me.Dispose()
    End Sub
    Private Sub do_it()
        doit.Enabled = False
        Dim st As New StringBuilder
        With frmMain
            Dim old_pos = .RTB1.SelectionStart
            st.Length = 0
            '
            Dim lines = .RTB1.Text.Split(ChrW(10))
            Dim pos As UInteger = 0
            Dim sel_start, sel_end As Integer
            Dim n_s As Int16 = CInt(rn_start_TB.Text)
            Dim n_inc As Int16 = CInt(inc_number_TB.Text)
            Dim pad = CInt(ComboBox1.SelectedItem)
            Dim max_num As Int32
            Dim ts, te, ns, fs As String
            Dim comment As Boolean = False
            max_num = CInt(ComboBox1.SelectedItem)
            max_num = Math.Pow(10, max_num)
            If lines.Length = 0 Then
                doit.Enabled = True
                Return
            End If
            Me.Height = 110
            ProgressBar1.Maximum = lines.Length
            ' .RTB1.SuspendLayout()

            For Each ln In lines
                fs = ln
                If InStr(ln, "O") = 1 Then GoTo skip ' program name
                If InStr(ln, "%") > 0 Then GoTo skip
                If InStr(ln, ";") > 1 Then GoTo skip
                If fs.Length = 0 Then GoTo skip ' dont want to num null lines
                comment = .find_number(ln, sel_start, sel_end, pos, old_pos)
                If comment Then GoTo skip ' no number
                If sel_end = sel_start Then
                    ts = ""
                    te = ln
                Else
                    ts = Microsoft.VisualBasic.Mid(ln, 1, sel_start)
                    te = Microsoft.VisualBasic.Mid(ln, sel_start + 1 + sel_end + 1)
                End If
                ns = n_s.ToString
                If CheckBox1.Checked Then
                    ns = ns.PadLeft(pad, "0")
                End If
                ns = "N" + ns
                fs = ts + ns + te
                n_s += n_inc
                If n_s >= max_num Then
                    n_s = CInt(rn_start_TB.Text)
                End If
skip:
                Application.DoEvents()
                st.Append(fs + vbCrLf)
                pos += 1
                ProgressBar1.Value = pos
            Next
            .RTB1.Text = st.ToString
            If old_pos > 0 Then
                Dim sl = .RTB1.GetFirstCharIndexFromLine(old_pos)
                .RTB1.SelectionStart = sl + 1
                .RTB1.SelectionLength = 1
            End If
            Application.DoEvents()

        End With
        doit.Enabled = True
        ProgressBar1.Value = 0
        frmMain.btn_renum.Enabled = True
        frmMain.btn_del_num.Enabled = True
        Me.Height = 90
        frmMain.RTB1.Focus()
        Me.Dispose()

    End Sub

    Private Sub Re_number_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim delta As New Size(e.X - renum_mouse.X, e.Y - renum_mouse.Y)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += delta
            renum_mouse = e.Location - delta
            Me.Update()
            ' frmMain.DrawScene()
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            renum_mouse.X = e.X
            renum_mouse.Y = e.Y
        End If
    End Sub


    Private Sub rn_start_TB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rn_start_TB.TextChanged
        If rn_start_TB.Text.Length = 0 Then
            Return
        End If
        If Not IsNumeric(rn_start_TB.Text) Then
            MsgBox("Integer Numbers Only", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub inc_number_TB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inc_number_TB.TextChanged
        If inc_number_TB.Text.Length = 0 Then
            Return
        End If
        If Not IsNumeric(inc_number_TB.Text) Then
            MsgBox("Integer Numbers Only", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        My.Settings.ln_num_pad = ComboBox1.SelectedIndex
    End Sub
End Class