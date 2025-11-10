Public Class Find
    Private find_mouse As New Point
    Private replace_all As Boolean = False
    Public close_bn As New my_Frm_Btn
    Public replace_bn As New W_my_Btn
    Public replace_all_bn As New W_my_Btn
    Public find_bn As New W_my_Btn
    Public find_next_bn As New W_my_Btn
 
    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        zoom_window.TopMost = False
        With frmMain
            If find_replace Then
                Me.Height = 180
            Else
                Me.Height = 90
            End If
            close_bn.Image = My.Resources.cross
            close_bn.Name = "cb"
            close_bn.Location = New Point(Me.Width - 27, 3)
            AddHandler close_bn.Click, AddressOf close_me
            '
            'find
            find_bn.Location = New Point(54, 50)
            find_bn.Name = "find"
            AddHandler find_bn.Click, AddressOf find
            '
            'find_next
            find_next_bn.Location = New Point(54 + 96, 50)
            find_next_bn.Name = "find_next"
            AddHandler find_next_bn.Click, AddressOf find_next
            '
            'replace
            replace_bn.Location = New Point(54, 140)
            replace_bn.Name = "replace"
            AddHandler replace_bn.Click, AddressOf replace_text
            'replace_all
            replace_all_bn.Location = New Point(54 + 96, 140)
            replace_all_bn.Name = "replace_all"
            AddHandler replace_all_bn.Click, AddressOf replace_all_text


            Dim cn As Int16 = Me.Controls.Count

            Me.Controls.Add(find_bn)
            Me.Controls.Add(find_next_bn)
            Me.Controls.Add(close_bn)
            Me.Controls.Add(replace_bn)
            Me.Controls.Add(replace_all_bn)

            find_bn.Text = "Find"
            find_bn.ForeColor = Color.White
            find_next_bn.Text = "Find Next"
            find_next_bn.ForeColor = Color.White


            replace_bn.Text = "Replace"
            replace_bn.ForeColor = Color.White
            replace_all_bn.Text = "Replace All"
            replace_all_bn.ForeColor = Color.White


            replace_count = 0

            find_TB.Text = find_string
            rpl_TB.Text = replace_string
            find_TB.Focus()
        End With
    End Sub
    Private Sub close_me()
        zoom_window.TopMost = True
        frmMain.btn_find.Enabled = True
        frmMain.btn_find_next.Enabled = True
        frmMain.btn_replace.Enabled = True
        Me.Dispose()

        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
    End Sub
    Private Sub find()
        disable_btns()
        find_text()
        frmMain.btn_find.Enabled = True
        frmMain.btn_find_next.Enabled = True
        frmMain.btn_replace.Enabled = True
        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
        Me.Dispose()

    End Sub
    Private Sub find_next()
        disable_btns()
        find_text()
        enable_btns()
        frmMain.RTB1.Update()
    End Sub
    Private Sub replace_text()
        disable_btns()
        replace_all = False
        replace()
        enable_btns()
        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
    End Sub
    Private Sub replace_all_text()
        replace_count = 0
        disable_btns()
        replace_all = True
        replace()
        replace_all = False
        enable_btns()
        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
    End Sub
    Private Sub disable_btns()
        find_bn.Enabled = False
        find_next_bn.Enabled = False
        replace_bn.Enabled = False
        replace_all_bn.Enabled = False
        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
    End Sub
    Private Sub enable_btns()
        find_bn.Enabled = True
        find_next_bn.Enabled = True
        replace_bn.Enabled = True
        replace_all_bn.Enabled = True
        frmMain.RTB1.Update()
        frmMain.RTB1.Focus()
    End Sub

    Private Sub find_text()
        ' Dim st As New StringBuilder
        With frmMain
            Dim old_pos = .RTB1.SelectionStart
            '   st.Length = 0
            '
            Dim lines = .RTB1.Text.Split(ChrW(10))
            Dim pos As UInteger = 0
            Dim sel_start, sel_end As Integer
            Dim ts, te, fs As String
            If lines.Length = 0 Then
                Return
            End If
            ' .RTB1.SuspendLayout()
            Dim rs As String = rpl_TB.Text
            sel_end = find_TB.Text.Length

            For pos = find_position To lines.Length - 1
                Dim ln = lines(pos)
                fs = ln
                If ln.Length = 0 Then GoTo skip ' not on this line
                sel_start = InStr(ln, find_TB.Text)
                If sel_start = 0 Then GoTo skip


                ts = Microsoft.VisualBasic.Mid(ln, 1, sel_start)
                te = Microsoft.VisualBasic.Mid(ln, sel_start + 1 + sel_end + 1)
                Dim s As UInteger = .RTB1.GetFirstCharIndexFromLine(pos)
                .RTB1.SelectionStart = (s + sel_start - 1)
                .RTB1.SelectionLength = sel_end
                .RTB1.ScrollToCaret()
                GoTo done
skip:
                Application.DoEvents()
                ' st.Append(fs + vbCrLf)
                If pos >= lines.Length Then
                    Me.TopMost = False
                    MsgBox("End Of File Reached...", MsgBoxStyle.OkOnly, "Search Completed")
                    Me.TopMost = True
                    find_position = 0
                    GoTo done
                End If
            Next
done:
            Application.DoEvents()
            '.RTB1.Text = st.ToString
            find_position = pos + 1
            If pos >= lines.Length Then
                Me.TopMost = False
                MsgBox("End Of File Reached...", MsgBoxStyle.OkOnly, "Search Completed")
                Me.TopMost = True
                find_position = 0
            End If

        End With
        ' frmMain.Focus()
    End Sub
    Private Sub replace()
        With frmMain
            Dim old_pos = .RTB1.SelectionStart
            Dim st As New StringBuilder
            st.Length = 0
            '
            Dim lines = .RTB1.Text.Split(ChrW(10))
            Dim pos As Integer = 0
            Dim last As Integer = 0
            Dim caret_position As Integer = 0
            Dim sel_end, pnt, loc As Integer
            If lines.Length = 0 Then
                replace_bn.Enabled = True
                Return
            End If
            ' .RTB1.SuspendLayout()
            Dim rs As String = rpl_TB.Text
            Dim fs As String = find_TB.Text
            If fs.Length = 0 Then
                Me.TopMost = False
                MsgBox("Need a Search String!", MsgBoxStyle.Exclamation, "Opps...")
                Me.TopMost = True
                Return
            End If
            sel_end = find_TB.Text.Length

            While True
                If Not replace_all Then

                    pos = .RTB1.Find(fs, pos, RichTextBoxFinds.NoHighlight)
                    If pos = -1 Then
                        Exit While
                    End If
                    pnt = .RTB1.GetLineFromCharIndex(pos)
                    If InStr(lines(pnt), "(") <> 0 Then
                        Exit While
                    End If
                    .RTB1.Text = .RTB1.Text.Remove(pos, sel_end)
                    .RTB1.Text = .RTB1.Text.Insert(pos, rs)
                    replace_count += 1
                    caret_position = pos
                    Exit While
                Else
                    Me.Height = 200
                    pbar.Maximum = lines.Length - 1
                    pbar.Value = 0
                    Application.DoEvents()
                    pos = 0
                    For pos = 0 To lines.Length - 1
                        pbar.Value = pos
                        loc = InStr(lines(pos), "(")
                        If loc = 0 Then loc = 1000
                        If InStr(lines(pos), fs) <= loc Then
                            lines(pos) = lines(pos).Replace(fs, rs)
                            last = InStr(lines(pos), rs)
                            If last > 0 Then
                                replace_count += 1
                                caret_position = .RTB1.GetFirstCharIndexFromLine(pos) + last - 1
                            End If
                        End If
                        st.Append(lines(pos) + vbCrLf)
                    Next
                    .RTB1.Text = st.ToString
                    Me.Height = 180
                    Application.DoEvents()
                    pos = -1
                    Exit While
                End If
skip:
                'If pos >= .RTB1.Text.Length Then
            End While
done:
            Application.DoEvents()
            '.RTB1.Text = st.ToString
            find_position = pos
            If pos = -1 Then
                Me.TopMost = False
                MsgBox("Bottom Reached" + vbCrLf + "Replaced " + replace_count.ToString + " items.", MsgBoxStyle.Exclamation, "")
                Me.TopMost = True
                find_position = 0
                pos = 0
            End If
            .RTB1.SelectionStart = caret_position
            .RTB1.SelectionLength = fs.Length
            .RTB1.ScrollToCaret()
        End With

    End Sub




    Private Sub find_TB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles find_TB.TextChanged
        Dim o As Int32 = sender.selectionstart
        find_TB.Text = find_TB.Text.ToUpper
        sender.selectionstart = o
        find_string = find_TB.Text
    End Sub



    Private Sub rpl_TB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rpl_TB.TextChanged

        Dim o As Int32 = sender.selectionstart
        sender.text = sender.text.toupper
        replace_string = rpl_TB.Text
        sender.selectionstart = o

    End Sub

    Private Sub Find_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim delta As New Size(e.X - find_mouse.X, e.Y - find_mouse.Y)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += delta
            find_mouse = e.Location - delta
            Me.Update()
            ' frmMain.DrawScene()
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            find_mouse.X = e.X
            find_mouse.Y = e.Y
        End If
    End Sub
End Class