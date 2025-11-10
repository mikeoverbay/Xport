Imports System.IO
Imports System.Math
Imports System.String

Public Class frmfilter
    Private process_mouse As New Point
    Public G1 As Boolean = False
    Public prog_str As New StringBuilder
    Public work_str As String = ""
    Public arc_count As UInteger = 0
    Public max_angle As Single = 0D
    Public max_hoa As Single = 0D
    Public arc_plane As Integer = -1
    Public old_arc_plane As Integer = 100
    Public arc_plane_str As String = ""
    Public arc_mode As Integer = -1
    Public arc_mode_str As String = ""
    Public break_code As Integer = -1
    Public arc_file As String = ""
    Public mode As Integer
    Public arc As Integer
    Public drill_mode As Integer
    Public block As String
    Public retract As Boolean
    Public arc_data As New arc_class
    Public need_g1 As Boolean = False
    Public i_string, j_string As String
    Public file_lines As Integer = 0
    Public new_file_lines As Integer = 0
    Public old_feed As Single
    Public feed As Single
    Public feed_string As String
    Public g1_str As String = ""
    Public start_block_str As String = ""
    Public max_seg As Single = 0.003
    Public process_btn As New W_my_Btn
    Public ok_btn As New my_Btn

    Public Enum state
        active
        aborted_with_data_0_lines
        aborted_with_data_1_lines
        aborted_with_data_2_lines
        aborted_no_data_1_lines
        aborted_no_data_2_lines

    End Enum

    Private Sub filter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.btn_process.Enabled = True
    End Sub


    Private Sub filter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' house keeping
        AddHandler process_btn.Click, AddressOf bt_process_file_Click
        process_btn.Location = New Point(77, 65)

        AddHandler ok_btn.Click, AddressOf bt_ok_Click
        ok_btn.Location = New Point(200, 250)
        Me.Controls.Add(process_btn)
        Me.Controls.Add(ok_btn)
        process_btn.Text = "Process File"
        process_btn.ForeColor = Color.White
        ok_btn.Text = "OK"
        ok_btn.ForeColor = Color.White

        name_txt.Text = "Prepare settings and" + vbCrLf + " click -Process-"
        output_txt.Text = ""
        arc_plane = -1
        arc_plane_str = ""
        arc_mode = -1
        arc_mode_str = ""
        file_lines = 0
        new_file_lines = 0
        zoom_window.TopMost = False

    End Sub

    Private Sub tb_max_angle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_max_angle.TextChanged
        If tb_max_angle.Text.Length = 0 Then Return
        If tb_max_angle.Text.Length = 1 And _
        InStr(tb_max_angle.Text, ".") = 1 Then Return

        If Not IsNumeric(tb_max_angle.Text) Then
            MsgBox("Numeric Only Please...", MsgBoxStyle.OkOnly, "Number Format Error")
            Return
        End If
        max_angle = CSng(tb_max_angle.Text) * 0.017453293D
        If max_angle < 0 Then max_angle *= -1
    End Sub

    Private Sub tb_max_rad_var_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_max_rad_var.TextChanged
        If tb_max_rad_var.Text.Length = 0 Then Return
        If tb_max_rad_var.Text.Length = 1 And _
        InStr(tb_max_rad_var.Text, ".") = 1 Then Return

        If Not IsNumeric(tb_max_rad_var.Text) Then
            MsgBox("Numeric Only Please...", MsgBoxStyle.OkOnly, "Number Format Error")
            Return
        End If
        max_hoa = CDec(tb_max_rad_var.Text)
        If max_hoa < 0 Then max_hoa *= -1
    End Sub


    Private Sub bt_process_file_Click()
        OpenFileDialog2.FilterIndex = My.Settings.open2_filter_index
        name_txt.Text = ""
        frmMain.make_filter()

        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            frmMain.clear_selection()
            process()
            If frmMain.codechop_loaded Then
                frmMain.delete_stl()
            End If
        End If
        My.Settings.open2_filter_index = OpenFileDialog2.FilterIndex
        frmMain.DrawScene()
    End Sub
    '-----------
    '-----------
    '----------- load and process file section
    Private Sub process()
        ' house keeping
        ReDim presistent(1)
        draw_presistent_selection = False
        _Loading = True
        ReDim arc_data.x_data(1)
        ReDim arc_data.y_data(1)
        ReDim arc_data.z_data(1)
        frmMain.clear_arrays()

        ReDim arc_data.blocks(4)
        name_txt.Text = ""
        output_txt.Text = ""
        arc_plane = -1
        old_arc_plane = 100
        arc_plane_str = ""
        arc_mode = -1
        arc_mode_str = ""
        file_lines = 0
        new_file_lines = 0
        prog_str.Length = 0
        work_str = ""
        reset_arc()
        'end house keeping
        frmMain.path = OpenFileDialog2.FileName
        OpenFileDialog2.Dispose()
        frmMain.DrawScene()
        Application.DoEvents()
        arc_file = frmMain.path
        name_txt.Text = "Processing.... " + vbCrLf + frmMain.get_filename
        frmMain.Text = frmMain.App_Name + " : " + frmMain.get_filename()
        Dim reader As New StreamReader(arc_file, True)
        Dim fsize As UInt32
        reader = System.IO.File.OpenText(arc_file)
        Dim myfileinfo As New FileInfo(arc_file)
        fsize = myfileinfo.Length
        frmMain.pg1.Maximum = fsize
        frmMain.pg1.Value = 0
        Dim read_bytes As UInt32 = 0
        frmMain.pg1.Visible = True
        frmMain.set_pg1_size()
        frmMain.pg1.BringToFront()
        frmMain.pg1.Width = frmMain.Splitter.Panel2.Width
        frmMain.pg1.Height = 15
        Application.DoEvents()
        frmMain.RTB1.Text = "Filtering Arcs..."
        frmMain.Timer1.Enabled = False

        frmMain.max_lines = frmMain.max_lines_reload

read_next:
        GoTo _next_part

_next_part:
        block = reader.ReadLine
        If frmMain.DEMO Then

            If frmMain.max_lines <= 0 Then
                MsgBox("Sorry.. This is the Demo Version" + vbCrLf + "You have hit the " + frmMain.max_lines_reload.ToString + " line limit." + vbCrLf + _
                        "For unlimited file size, buy the software.", MsgBoxStyle.Information, "Demo Limitation")
                block = Nothing
            End If
            frmMain.max_lines -= 1
        End If
        ' end check if demo mode
        If Not block Is Nothing Then
            read_bytes += block.Length
        End If
        frmMain.pg1.Value = read_bytes
        Application.DoEvents()
        If block Is Nothing Then
            frmMain.pg1.Visible = False
            reader.Close()
            reader.Dispose()
            frmMain.RTB1.Text = prog_str.ToString
            Dim saved As Integer = file_lines - new_file_lines
            output_txt.Text = "Old Line Count: " + file_lines.ToString + vbCrLf + vbCrLf + _
            "New Line Count: " + new_file_lines.ToString + vbCrLf + vbCrLf + _
              saved.ToString + " Lines Removed" + vbCrLf + vbCrLf + _
              CStr(100 * CSng(Round(1 - (new_file_lines / file_lines), 4))) + "% Reduction"
            Application.DoEvents()
            frmMain.draw_all()
            'frmMain.Timer1.Enabled = True
            Application.DoEvents()
            _Loading = False
            Return
        End If
        file_lines += 1

        block += vbCrLf

        Application.DoEvents()
        look_for_g_codes()
        'look for comment
        Dim com As Integer = InStr(block, ";")
        If com > 0 Then
            prog_str.Append(block)
            new_file_lines += 1
            GoTo read_next
        End If
        ' prase mode
        Select Case mode
            Case 81
                prog_str.Append(block)
                new_file_lines += 1
                Exit Select
            Case 0, 2, 3
                If arc_data.arc_started Then
                    finish_arc(state.aborted_with_data_0_lines, 1)
                Else
                    Select Case arc_data.block_count
                        Case 1
                            prog_str.Append(g1_str)
                            prog_str.Append(arc_data.blocks(0))
                            new_file_lines += 1
                        Case 2
                            prog_str.Append(g1_str)
                            prog_str.Append(arc_data.blocks(0))
                            prog_str.Append(arc_data.blocks(1))
                            new_file_lines += 2
                    End Select
                End If
                reset_arc()
                prog_str.Append(block)
                new_file_lines += 1
                Exit Select
            Case 1
                Dim _arcState As Integer = find_plane(block) ' this is the guts of the math!!
                Select Case _arcState
                    Case state.active
                        Exit Select
                        'this is while are data is active with no errors
                    Case state.aborted_with_data_0_lines
                        finish_arc(_arcState, 2)
                        prog_str.Append(g1_str)
                        new_file_lines += 1
                        prog_str.Append(block)
                        old_feed = feed
                        ' frmMain.draw_all()
                        reset_arc()

                    Case state.aborted_with_data_1_lines
                        finish_arc(_arcState, 1)

                        prog_str.Append(g1_str)
                        prog_str.Append(arc_data.blocks(arc_data.block_count - 2))
                        new_file_lines += 2
                        old_feed = feed
                        prog_str.Append(block)
                        reset_arc()

                    Case state.aborted_with_data_2_lines
                        finish_arc(_arcState, 1)

                        prog_str.Append(g1_str)
                        prog_str.Append(arc_data.blocks(arc_data.block_count - 3))
                        prog_str.Append(arc_data.blocks(arc_data.block_count - 2))
                        new_file_lines += 3
                        prog_str.Append(block)
                        old_feed = feed
                        reset_arc()

                    Case state.aborted_no_data_1_lines
                        prog_str.Append(g1_str)
                        prog_str.Append(arc_data.blocks(0))
                        new_file_lines += 2
                        prog_str.Append(block)
                        reset_arc()

                    Case state.aborted_no_data_2_lines
                        prog_str.Append(g1_str)
                        prog_str.Append(arc_data.blocks(0))
                        prog_str.Append(arc_data.blocks(1))
                        new_file_lines += 3
                        prog_str.Append(block)
                        old_feed = feed
                        reset_arc()

                    Case 9
                        prog_str.Append(block)
                        new_file_lines += 1
                End Select
        End Select
        ' frmMain.RTB1.Text = prog_str
        GoTo read_next

    End Sub
    '------------------

    Private Function find_plane(ByVal ln As String) As Integer
        Dim val As Integer = 0
        Dim arcstate As Integer = 0
        Dim x, y, z As Single
        '1+3 (4) = G17
        '1+5 (6) = G18
        '3+8 (8) = G19
        '1+3+5 (9) = NO ARC
        If InStr(ln, "X") > 0 Then
            val += 1
            x = get_val(ln, "X", 0)
        End If

        If InStr(ln, "Y") > 0 Then
            val += 3
            y = get_val(ln, "Y", 0)
        End If

        If InStr(ln, "Z") > 0 Then
            val += 5
            z = get_val(ln, "Z", 0)
        End If
        feed = get_val(ln, "F", feed)
        If old_feed <> feed Then
            feed_string = "F" + CSng(Round(feed, 2)).ToString
        Else
            feed_string = ""
        End If
        '1+3 (4) = G17
        '1+5 (6) = G18
        '3+8 (8) = G19
        '1+3+5 (9) = NO ARC

        Select Case val
            Case 0, 1, 3, 5, 9
                If arc_data.arc_started Then
                    'get_i_j_str(3)
                    'finish_arc(arcstate, 1)
                    Select Case arc_data.block_count
                        Case 1
                            Return state.aborted_with_data_1_lines
                        Case 2
                            Return state.aborted_with_data_2_lines
                    End Select
                    finish_arc(state.aborted_with_data_0_lines, 1)

                    prog_str.Append(g1_str)
                    'new_file_lines += 1
                    'prog_str.Append(block)
                    old_feed = feed
                    ' frmMain.draw_all()
                    reset_arc()
                Else
                    Select Case arc_data.block_count
                        Case 1
                            work_str = ""
                            Return state.aborted_no_data_1_lines
                        Case 2
                            work_str = ""
                            Return state.aborted_no_data_2_lines
                    End Select
                End If
                Return 9

            Case 4
                If arc_plane = 17 Then
                    'arc_plane_str = ""
                Else
                    If arc_data.arc_started Then
                        finish_arc(state.aborted_with_data_0_lines, 1)

                        prog_str.Append(g1_str)
                        new_file_lines += 1
                        prog_str.Append(block)
                        old_feed = feed
                        ' frmMain.draw_all()
                        reset_arc()

                    Else
                        Select Case arc_data.block_count
                            Case 1
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                new_file_lines += 1
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                            Case 2
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                prog_str.Append(arc_data.blocks(1))
                                new_file_lines += 2
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                        End Select

                    End If
                    arc_plane_str = "G17"
                    arc_plane = 17
                End If
                arcstate = x_y_arc(x, y, ln)
            Case 6
                If arc_plane = 18 Then
                    'arc_plane_str = ""
                Else
                    If arc_data.arc_started Then
                        finish_arc(state.aborted_with_data_0_lines, 1)

                        prog_str.Append(g1_str)
                        new_file_lines += 1
                        prog_str.Append(block)
                        ' frmMain.draw_all()
                        old_feed = feed
                        reset_arc()

                    Else
                        Select Case arc_data.block_count
                            Case 1
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                new_file_lines += 1
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                            Case 2
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                prog_str.Append(arc_data.blocks(1))
                                new_file_lines += 2
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                        End Select

                    End If
                    arc_plane_str = "G18"
                    arc_plane = 18
                End If
                arcstate = x_z_arc(x, z, ln)
            Case 8
                If arc_plane = 19 Then
                    'arc_plane_str = ""
                Else
                    If arc_data.arc_started Then
                        finish_arc(state.aborted_with_data_0_lines, 1)

                        prog_str.Append(g1_str)
                        new_file_lines += 1
                        prog_str.Append(block)
                        old_feed = feed
                        ' frmMain.draw_all()
                        reset_arc()

                    Else
                        Select Case arc_data.block_count
                            Case 1
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                new_file_lines += 1
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                            Case 2
                                prog_str.Append(g1_str)
                                prog_str.Append(arc_data.blocks(0))
                                prog_str.Append(arc_data.blocks(1))
                                new_file_lines += 2
                                ' prog_str.Append(block)
                                old_feed = feed
                                reset_arc()
                        End Select

                    End If
                    arc_plane_str = "G19"
                    arc_plane = 19
                End If
                arcstate = y_z_arc(y, z, ln)
        End Select


        'Select Case arcstate
        '    Case state.active, state.aborted_with_data_0_lines, state.aborted_with_data_1_lines, state.aborted_with_data_2_lines
        '       get_i_j_str(3)
        'finish_arc(arcstate, 2)
        'End Select

        Return arcstate
    End Function
    Private Sub finish_arc(ByVal arcstate As Integer, ByVal offset As Integer)
        ' get_arc_direction()
        get_i_j_str()
        Dim debug_ As String = ""
        Dim xpl() As String = {"X", "X", "Y"}
        Dim ypl() As String = {"Y", "Z", "Z"}
        'debug_ = "(Avg Radius= R" + CSng(Round(arc_data.running_radius / arc_data.running_count, 6)).ToString + ")" + _
        'vbCrLf + "( XC=" + CSng(Round(arc_data.xc, 5)).ToString + " YC=" + CSng(Round(arc_data.yc, 5)).ToString + _
        '"  ZC=" + CSng(Round(arc_data.zc, 5)).ToString + " R= " + arc_data.radius.ToString + " )" + vbCrLf
        'debug_ = arc_data.str + vbCrLf
        'debug_ = ""
        Dim ss, se As String
        Select Case arcstate
            Case state.aborted_with_data_0_lines, state.aborted_with_data_1_lines, state.aborted_with_data_2_lines
                Dim x, y, z As Single
                If arc_data.block_count < 3 Then Return
                Dim _len As Integer = arc_data.blocks(arc_data.block_count - offset).Length - 2
                Select Case arc_plane
                    Case 17
                        x = arc_data.x_data(arc_data.block_count - offset)
                        y = arc_data.y_data(arc_data.block_count - offset)
                        ss = arc_data.blocks(0)
                        se = arc_data.direction + arc_plane_str + LSet(arc_data.blocks(arc_data.block_count - offset), _len) _
                            + i_string + j_string + vbCrLf
                        work_str = ss + se + debug_
                        need_g1 = True
                    Case 18
                        ' find_x_z_arc()
                        x = arc_data.x_data(arc_data.block_count - offset)
                        z = arc_data.z_data(arc_data.block_count - offset)
                        ss = arc_data.blocks(0)
                        se = arc_data.direction + arc_plane_str + LSet(arc_data.blocks(arc_data.block_count - offset), _len) _
                            + i_string + j_string + vbCrLf
                        work_str = ss + se + debug_
                        need_g1 = True
                    Case 19
                        y = arc_data.y_data(arc_data.block_count - offset)
                        z = arc_data.z_data(arc_data.block_count - offset)
                        ss = arc_data.blocks(0)
                        se = arc_data.direction + arc_plane_str + LSet(arc_data.blocks(arc_data.block_count - offset), _len) _
                            + i_string + j_string + vbCrLf
                        work_str = ss + se + debug_
                End Select
                prog_str.Append(work_str)
                new_file_lines += 2
                arc_plane_str = ""
                g1_str = "G1"
                'arc_data.direction = ""
        End Select

    End Sub
    Private Sub get_arc_direction()
        Return
        Dim code_sa, code_ea As Integer
        code_sa = 5
        Select Case arc_data.start_angle
            Case Is < PI / 2
                code_sa -= 3
            Case Is < PI
                code_sa -= 2
            Case Is < PI / 0.75
                code_sa -= 1
            Case Is = 0.0
                code_sa -= 4
        End Select
        code_ea = 250
        Select Case arc_data.end_angle
            Case Is < PI / 2
                code_ea -= 150
            Case Is < PI
                code_ea -= 100
            Case Is < PI / 0.75
                code_ea -= 50
            Case Is = 0.0
                code_ea -= 200
        End Select
        Dim sum As Integer = code_sa + code_ea
        If arc_data.start_angle < arc_data.end_angle Then
            sum += 5
        End If
        If arc_data.x_off <= 0 Then
            sum += 250
        End If
        If arc_data.y_off < 0 Then
            sum += 500
        End If
        Select Case sum
            Case Is = 1010, 760, 458, 605, 408, 959, 157, 1009, 207, 107, 855
                arc_data.direction = "G3"
            Case Is = 107
                arc_data.direction = "G3"

            Case Is = 257, 508, 755, 403, 102, 353, 954, 105, 1005, 955, 705, 904, 905
                arc_data.direction = "G2"

        End Select

        arc_data.str = " - sum=" + sum.ToString + " " + arc_data.direction

    End Sub
    Private Sub get_i_j_str()
        Dim x, y, z As Single
        x = arc_data.x_data(0)
        y = arc_data.y_data(0)
        z = arc_data.z_data(0)

        Dim i, j, k As Single
        i = 0D
        j = 0D
        k = 0D
        Dim ipl() As String = {"I", "I", "J"}
        Dim jpl() As String = {"J", "K", "K"}
        i_string = ""
        j_string = ""
        j_string = ""
        Select Case arc_plane
            Case 17
                i = arc_data.xc - x
                i_string = ipl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(i, 4)))
                j = arc_data.yc - y
                j_string = jpl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(j, 4)))
            Case 18
                i = arc_data.xc - x
                i_string = ipl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(i, 4)))
                k = arc_data.zc - z
                j_string = jpl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(k, 4)))
            Case 19
                j = arc_data.yc - y
                i_string = ipl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(j, 4)))
                k = arc_data.zc - z
                j_string = jpl(arc_plane - 17) + String.Format("{0:F4}", CSng(Round(k, 4)))
        End Select

no_k:   Return
    End Sub

    Public Function x_y_arc(ByVal x As Single, ByVal y As Single, ByVal ln As String) As Integer

        'Dim t1, t2, t3, q1, q2, q3 As Single
        Dim xc, yc As Single
        Dim x1, y1, x2, y2, x3, y3 As Single
        Dim i, j, k, cnt As Integer
        Dim z__ As Decimal
        Dim direction As String = ""

        ReDim Preserve arc_data.rdata(arc_data.block_count)
        ReDim Preserve arc_data.x_data(arc_data.block_count)
        ReDim Preserve arc_data.y_data(arc_data.block_count)
        ReDim Preserve arc_data.blocks(arc_data.block_count)

        arc_data.x_data(arc_data.block_count) = x
        arc_data.y_data(arc_data.block_count) = y
        arc_data.blocks(arc_data.block_count) = block
        Dim cb As Integer = arc_data.block_count
        arc_data.block_count += 1
        If arc_data.block_count < 3 Then Return state.active

        x1 = arc_data.x_data(0)
        y1 = arc_data.y_data(0)
        x2 = arc_data.x_data(CInt(cb / 2))
        y2 = arc_data.y_data(CInt(cb / 2))
        x3 = arc_data.x_data(cb)
        y3 = arc_data.y_data(cb)

        Dim s As Single = 0.5D * ((x2 - x3) * (x1 - x3) - (y2 - y3) * (y3 - y1))
        Dim sUnder As Single = (x1 - x2) * (y3 - y1) - (y2 - y1) * (x1 - x3)

        If sUnder <> 0 Then

            s /= sUnder

            xc = 0.5D * (x1 + x2) + s * (y2 - y1) ' center x coordinate
            yc = 0.5D * (y1 + y2) + s * (x1 - x2) ' center y coordinate
            If yc < -1000.0 Or yc > 1000.0 Then
                Return state.aborted_no_data_2_lines
            End If
        Else
            Dim c = 1
            If arc_data.arc_started Then
                If arc_data.running_count = 0 Then
                    work_str = ""
                    g1_str = ""
                End If
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If

        End If

        'q1 = x1 - x2
        'q2 = x2 - x3
        'q3 = x1 - x3

        't1 = y2 - y1
        't2 = y3 - y2
        't3 = y3 - y1

        Dim r1d As Single = CSng(Round((Sqrt(((x3 - xc) * (x3 - xc)) + ((y3 - yc) * (y3 - yc)))), 4))
        'check angle tolorance
        Dim x1_A As Single = arc_data.x_data(cb - 2)
        Dim x2_A As Single = arc_data.x_data(cb - 1)
        Dim x3_A As Single = arc_data.x_data(cb)
        Dim y1_A As Single = arc_data.y_data(cb - 2)
        Dim y2_A As Single = arc_data.y_data(cb - 1)
        Dim y3_A As Single = arc_data.y_data(cb)
        Dim dxr1 As Single = CSng(Round(arc_data.x_data(0) - xc, 6))
        Dim dx2 As Single = CSng(Round(x3_A - xc, 6))
        Dim dyr1 As Single = CSng(Round(arc_data.y_data(0) - yc, 6))
        Dim dy2 As Single = CSng(Round(y3_A - yc, 6))
        Dim dx1 As Single = CSng(Round(x1_A - xc, 6))
        Dim dy1 As Single = CSng(Round(y2_A - yc, 6))

        Dim sa = Round(mAtan2(y1_A - y2_A, x1_A - x2_A), 6)
        Dim ea = Round(mAtan2(y2_A - y3_A, x2_A - x3_A), 6)

        Dim a1 As Single = CSng(Round(mAtan2(dy1, dx1), 6)) '+ PI * 4
        Dim start_angle As Single = CSng(Round(mAtan2(dyr1, dxr1), 6)) '+ PI * 4
        Dim end_angle As Single = CSng(Round(mAtan2(dy2, dx2), 6)) '+ PI * 4

        Dim seg1 As Single = CSng(Sqrt(((x2_A - x1_A) ^ 2) + ((y2_A - y1_A) ^ 2)))
        Dim seg2 As Single = CSng(Sqrt(((x3_A - x2_A) ^ 2) + ((y3_A - y2_A) ^ 2)))
        'Dim seg3 As Single = CSng(Sqrt(((x3_A - x1_A) ^ 2) + ((y3_A - y1_A) ^ 2)))
        'test that its the same arc direction
        i = arc_data.block_count - 3
        j = i + 1
        k = i + 2
        z__ = (arc_data.x_data(j) - arc_data.x_data(i)) * (arc_data.y_data(k) - arc_data.y_data(j))
        z__ -= (arc_data.y_data(j) - arc_data.y_data(i)) * (arc_data.x_data(k) - arc_data.x_data(j))
        If z__ < 0 Then
            cnt -= 1
        Else
            If z__ > 0 Then
                cnt += 1
            End If
        End If
        If z__ = 0 Then
            Dim h = z__
        End If
        If cnt > 0 Then
            direction = "G3"
        Else
            direction = "G2"
        End If
        If arc_data.direction = "G0" Then
            arc_data.direction = direction
        Else
            If arc_data.direction <> direction Then
                GoTo kill_this_one
            End If
        End If

        Dim seg_len As Single
        max_seg = (max_hoa * 10)
        If seg1 > seg2 Then
            seg_len = seg1 - seg2
        Else
            seg_len = seg2 - seg1
        End If
        seg_len *= Sign(seg_len)
        If seg_len > (max_seg) Then
            ' Debug.WriteLine("----------------len_seg Length Cut off: " + String.Format("{0:F8}", seg_len))
            GoTo kill_this_one
        End If



        Dim h1 As Single = CSng(Sqrt(((x2_A - xc) ^ 2) + ((y2_A - yc) ^ 2)))
        Dim h2 As Single = CSng(Sqrt(((x3_A - xc) ^ 2) + ((y3_A - yc) ^ 2)))
        Dim hoa As Single = h1 - h2
        hoa *= Sign(hoa)
        If hoa > max_hoa Then
            ' Debug.WriteLine("----------------hoa Length Cut off: " + String.Format("{0:F8}", hoa))
kill_this_one:
            If arc_data.arc_started Then
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If
        End If

        Dim agl As Single = 0
        If sa > ea Then
            agl = sa - ea
        Else
            agl = ea - sa
        End If
        If direction = "G3" Then
            If sa > ea Then
                agl = sa - (ea + PI * 2)
            Else
                agl = ea - sa
            End If
        End If
        If direction = "G2" Then
            If ea > sa Then
                agl = ea - (sa + PI * 2)
            Else
                agl = sa - ea
            End If
        End If
        agl *= Sign(agl)     'Debug.WriteLine(String.Format("sa:{0:F8} ea:{1:F8} sa-ea:{2:F8} max:{3:F8}", sa, ea, agl, max_angle))
        If agl > max_angle Then
            ' Debug.WriteLine("---------------Angle Tol Break")
            GoTo kill_this_one
        End If
over:
        arc_data.x_running += xc
        arc_data.y_running += yc
        arc_data.running_count += 1
        arc_data.xc = xc 'csng(round(arc_data.x_running / arc_data.running_count, 4)
        arc_data.yc = yc 'csng(round(arc_data.y_running / arc_data.running_count, 4)
        arc_data.running_radius += r1d
        arc_data.radius = r1d 'csng(round(arc_data.running_radius / arc_data.running_count, 6)
        arc_data.start_angle = start_angle
        arc_data.end_angle = end_angle


        arc_data.x_off = x1 - xc
        arc_data.y_off = y1 - yc

        arc_data.arc_started = True
        If old_arc_plane <> arc_plane Then
            arc_plane_str = "G17"
            old_arc_plane = arc_plane
        End If
        Return state.active  ' passed arc test
    End Function

    Public Function x_z_arc(ByVal x As Single, ByVal z As Single, ByVal ln As String) As Integer
        'Dim t1, t2, t3, q1, q2, q3 As Single
        Dim xc, zc As Single
        Dim x1, z1, x2, z2, x3, z3 As Single
        Dim direction As String = ""
        Dim i, j, k, cnt As Integer
        Dim z__ As Decimal

        ReDim Preserve arc_data.rdata(arc_data.block_count)
        ReDim Preserve arc_data.x_data(arc_data.block_count)
        ReDim Preserve arc_data.z_data(arc_data.block_count)
        ReDim Preserve arc_data.blocks(arc_data.block_count)

        arc_data.x_data(arc_data.block_count) = x
        arc_data.z_data(arc_data.block_count) = z
        arc_data.blocks(arc_data.block_count) = block
        Dim cb As Integer = arc_data.block_count
        arc_data.block_count += 1
        If arc_data.block_count < 3 Then Return state.active

        x1 = arc_data.x_data(0)
        z1 = arc_data.z_data(0)
        x2 = arc_data.x_data(CInt(cb / 2))
        z2 = arc_data.z_data(CInt(cb / 2))
        x3 = arc_data.x_data(cb)
        z3 = arc_data.z_data(cb)

        Dim s As Single = 0.5D * ((x2 - x3) * (x1 - x3) - (z2 - z3) * (z3 - z1))
        Dim sUnder As Single = (x1 - x2) * (z3 - z1) - (z2 - z1) * (x1 - x3)

        If sUnder <> 0 Then

            s /= sUnder

            xc = 0.5D * (x1 + x2) + s * (z2 - z1) ' center x coordinate
            zc = 0.5D * (z1 + z2) + s * (x1 - x2) ' center y coordinate
            If zc < -1000.0 Or zc > 1000.0 Then
                GoTo kill_this_one
            End If
        Else
            Dim c = 1
            If arc_data.arc_started Then
                If arc_data.running_count = 0 Then
                    work_str = ""
                    g1_str = ""
                End If
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If

        End If

        'q1 = x1 - x2
        'q2 = x2 - x3
        'q3 = x1 - x3

        't1 = z2 - z1
        't2 = z3 - z2
        't3 = z3 - z1

        Dim r1d As Single = CSng(Round((Sqrt(((x3 - xc) * (x3 - xc)) + ((z3 - zc) * (z3 - zc)))), 4))
        'check angle tolorance
        Dim x1_A As Single = arc_data.x_data(cb - 2)
        Dim x2_A As Single = arc_data.x_data(cb - 1)
        Dim x3_A As Single = arc_data.x_data(cb)
        Dim z1_A As Single = arc_data.z_data(cb - 2)
        Dim z2_A As Single = arc_data.z_data(cb - 1)
        Dim z3_A As Single = arc_data.z_data(cb)
        Dim dxr1 As Single = CSng(Round(arc_data.x_data(0) - xc, 6))
        Dim dx2 As Single = CSng(Round(x3_A - xc, 6))
        Dim dzr1 As Single = CSng(Round(arc_data.z_data(0) - zc, 6))
        Dim dz2 As Single = CSng(Round(z3_A - zc, 6))
        Dim dx1 As Single = CSng(Round(x1_A - xc, 6))
        Dim dz1 As Single = CSng(Round(z2_A - zc, 6))

        Dim sa = Round(mAtan2(z1_A - z2_A, x1_A - x2_A), 6)
        Dim ea = Round(mAtan2(z2_A - z3_A, x2_A - x3_A), 6)

        Dim a1 As Single = CSng(Round(mAtan2(dz1, dx1), 6)) '+ PI * 4
        Dim start_angle As Single = CSng(Round(mAtan2(dzr1, dxr1), 6)) '+ PI * 4
        Dim end_angle As Single = CSng(Round(mAtan2(dz2, dx2), 6)) '+ PI * 4

        Dim seg1 As Single = CSng(Sqrt(((x2_A - x1_A) ^ 2) + ((z2_A - z1_A) ^ 2)))
        Dim seg2 As Single = CSng(Sqrt(((x3_A - x2_A) ^ 2) + ((z3_A - z2_A) ^ 2)))
        'Dim seg3 As Single = CSng(Sqrt(((x3_A - x1_A) ^ 2) + ((z3_A - z1_A) ^ 2)))
        'test that its the same arc direction
        i = arc_data.block_count - 3
        j = i + 1
        k = i + 2
        z__ = (arc_data.x_data(j) - arc_data.x_data(i)) * (arc_data.z_data(k) - arc_data.z_data(j))
        z__ -= (arc_data.z_data(j) - arc_data.z_data(i)) * (arc_data.x_data(k) - arc_data.x_data(j))
        If z__ < 0 Then
            cnt -= 1
        Else
            If z__ > 0 Then
                cnt += 1
            End If
        End If
        If z__ = 0 Then
            Dim h = z__
        End If
        If cnt > 0 Then
            direction = "G3"
        Else
            direction = "G2"
        End If
        If arc_data.direction = "G0" Then
            arc_data.direction = direction
        Else
            If arc_data.direction <> direction Then
                GoTo kill_this_one
            End If
        End If

        Dim seg_len As Single
        max_seg = (max_hoa * 10)
        If seg1 > seg2 Then
            seg_len = seg1 - seg2
        Else
            seg_len = seg2 - seg1
        End If
        seg_len *= Sign(seg_len)
        If seg_len > (max_seg) Then
            ' Debug.WriteLine("----------------len_seg Length Cut off: " + String.Format("{0:F8}", seg_len))
            GoTo kill_this_one
        End If



        Dim h1 As Single = CSng(Sqrt(((x2_A - xc) ^ 2) + ((z2_A - zc) ^ 2)))
        Dim h2 As Single = CSng(Sqrt(((x3_A - xc) ^ 2) + ((z3_A - zc) ^ 2)))
        Dim hoa As Single = h1 - h2
        hoa *= Sign(hoa)
        If hoa > max_hoa Then
            ' Debug.WriteLine("----------------hoa Length Cut off: " + String.Format("{0:F8}", hoa))
kill_this_one:
            If arc_data.arc_started Then
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If
        End If
        Dim agl As Single = 0
        If sa > ea Then
            agl = sa - ea
        Else
            agl = ea - sa
        End If
        If direction = "G3" Then
            If sa > ea Then
                agl = sa - (ea + PI * 2)
            Else
                agl = ea - sa
            End If
        End If
        If direction = "G2" Then
            If ea > sa Then
                agl = ea - (sa + PI * 2)
            Else
                agl = sa - ea
            End If
        End If
        agl *= Sign(agl)
        ' Debug.WriteLine(String.Format("sa:{0:F8} ea:{1:F8} sa-ea:{2:F8} max:{3:F8}", sa, ea, agl, max_angle))
        If agl > max_angle Then
            ' Debug.WriteLine("---------------Angle Tol Break")
            GoTo kill_this_one
        End If
over:
        arc_data.x_running += xc
        arc_data.z_running += zc
        arc_data.running_count += 1
        arc_data.xc = xc 'csng(round(arc_data.x_running / arc_data.running_count, 4)
        arc_data.zc = zc 'csng(round(arc_data.z_running / arc_data.running_count, 4)
        arc_data.running_radius += r1d
        arc_data.radius = r1d 'csng(round(arc_data.running_radius / arc_data.running_count, 6)

        arc_data.start_angle = start_angle
        arc_data.end_angle = end_angle


        arc_data.x_off = x1 - xc
        arc_data.y_off = z1 - zc

        arc_data.arc_started = True
        If old_arc_plane <> arc_plane Then
            arc_plane_str = "G18"
            old_arc_plane = arc_plane
        End If
        Return state.active  ' passed arc test
    End Function

    Public Function y_z_arc(ByVal y As Single, ByVal z As Single, ByVal ln As String) As Integer

        Dim yc, zc As Single
        Dim y1, z1, y2, z2, y3, z3 As Single
        Dim direction As String = ""
        Dim i, j, k, cnt As Integer
        Dim z__ As Decimal

        ReDim Preserve arc_data.rdata(arc_data.block_count)
        ReDim Preserve arc_data.y_data(arc_data.block_count)
        ReDim Preserve arc_data.z_data(arc_data.block_count)
        ReDim Preserve arc_data.blocks(arc_data.block_count)

        arc_data.y_data(arc_data.block_count) = y
        arc_data.z_data(arc_data.block_count) = z
        arc_data.blocks(arc_data.block_count) = block
        Dim cb As Integer = arc_data.block_count
        arc_data.block_count += 1
        If arc_data.block_count < 3 Then Return state.active

        y1 = arc_data.y_data(0)
        z1 = arc_data.z_data(0)
        y2 = arc_data.y_data(CInt(cb / 2))
        z2 = arc_data.z_data(CInt(cb / 2))
        y3 = arc_data.y_data(cb)
        z3 = arc_data.z_data(cb)

        Dim s As Single = 0.5D * ((y2 - y3) * (y1 - y3) - (z2 - z3) * (z3 - z1))
        Dim sUnder As Single = (y1 - y2) * (z3 - z1) - (z2 - z1) * (y1 - y3)

        If sUnder <> 0 Then

            s /= sUnder

            yc = 0.5D * (y1 + y2) + s * (z2 - z1) ' center y coordinate
            zc = 0.5D * (z1 + z2) + s * (y1 - y2) ' center y coordinate
            If zc < -1000.0 Or zc > 1000.0 Then
                Return state.aborted_no_data_2_lines
            End If
        Else
            Dim c = 1
            If arc_data.arc_started Then
                If arc_data.running_count = 0 Then
                    work_str = ""
                    g1_str = ""
                End If
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If

        End If

        'q1 = y1 - y2
        'q2 = y2 - y3
        'q3 = y1 - y3

        't1 = z2 - z1
        't2 = z3 - z2
        't3 = z3 - z1

        Dim r1d As Single = CSng(Round((Sqrt(((y3 - yc) * (y3 - yc)) + ((z3 - zc) * (z3 - zc)))), 4))
        'check angle tolorance
        Dim y1_A As Single = arc_data.y_data(cb - 2)
        Dim y2_A As Single = arc_data.y_data(cb - 1)
        Dim y3_A As Single = arc_data.y_data(cb)
        Dim z1_A As Single = arc_data.z_data(cb - 2)
        Dim z2_A As Single = arc_data.z_data(cb - 1)
        Dim z3_A As Single = arc_data.z_data(cb)
        Dim dyr1 As Single = CSng(Round(arc_data.y_data(0) - yc, 6))
        Dim dy2 As Single = CSng(Round(y3_A - yc, 6))
        Dim dzr1 As Single = CSng(Round(arc_data.z_data(0) - zc, 6))
        Dim dz2 As Single = CSng(Round(z3_A - zc, 6))
        Dim dy1 As Single = CSng(Round(y1_A - yc, 6))
        Dim dz1 As Single = CSng(Round(z2_A - zc, 6))

        Dim sa = Round(mAtan2(z1_A - z2_A, y1_A - y2_A), 6)
        Dim ea = Round(mAtan2(z2_A - z3_A, y2_A - y3_A), 6)

        Dim a1 As Single = CSng(Round(mAtan2(dz1, dy1), 6)) '+ PI * 4
        Dim start_angle As Single = CSng(Round(mAtan2(dzr1, dyr1), 6)) '+ PI * 4
        Dim end_angle As Single = CSng(Round(mAtan2(dz2, dy2), 6)) '+ PI * 4

        Dim seg1 As Single = CSng(Sqrt(((y2_A - y1_A) ^ 2) + ((z2_A - z1_A) ^ 2)))
        Dim seg2 As Single = CSng(Sqrt(((y3_A - y2_A) ^ 2) + ((z3_A - z2_A) ^ 2)))
        'Dim seg3 As Single = CSng(Sqrt(((y3_A - y1_A) ^ 2) + ((z3_A - z1_A) ^ 2)))
        'test that its the same arc direction
        i = arc_data.block_count - 3
        j = i + 1
        k = i + 2
        z__ = (arc_data.y_data(j) - arc_data.y_data(i)) * (arc_data.z_data(k) - arc_data.z_data(j))
        z__ -= (arc_data.z_data(j) - arc_data.z_data(i)) * (arc_data.y_data(k) - arc_data.y_data(j))
        If z__ < 0 Then
            cnt -= 1
        Else
            If z__ > 0 Then
                cnt += 1
            End If
        End If
        If z__ = 0 Then
            Dim h = z__
        End If
        If cnt > 0 Then
            direction = "G3"
        Else
            direction = "G2"
        End If
        If arc_data.direction = "G0" Then
            arc_data.direction = direction
        Else
            If arc_data.direction <> direction Then
                GoTo kill_this_one
            End If
        End If

        Dim seg_len As Single
        max_seg = (max_hoa * 10)
        If seg1 > seg2 Then
            seg_len = seg1 - seg2
        Else
            seg_len = seg2 - seg1
        End If
        seg_len *= Sign(seg_len)
        If seg_len > (max_seg) Then
            ' Debug.WriteLine("----------------len_seg Length Cut off: " + String.Format("{0:F8}", seg_len))
            GoTo kill_this_one
        End If



        Dim h1 As Single = CSng(Sqrt(((y2_A - yc) ^ 2) + ((z2_A - zc) ^ 2)))
        Dim h2 As Single = CSng(Sqrt(((y3_A - yc) ^ 2) + ((z3_A - zc) ^ 2)))
        Dim hoa As Single = h1 - h2
        hoa *= Sign(hoa)
        If hoa > max_hoa Then
            ' Debug.WriteLine("----------------hoa Length Cut off: " + String.Format("{0:F8}", hoa))
kill_this_one:
            If arc_data.arc_started Then
                Return state.aborted_with_data_0_lines
            Else
                work_str = ""
                g1_str = ""
                Select Case arc_data.block_count
                    Case 3
                        Return state.aborted_no_data_2_lines
                End Select
            End If
        End If

        Dim agl As Single = 0
        If sa > ea Then
            agl = sa - ea
        Else
            agl = ea - sa
        End If
        'Debug.WriteLine(String.Format("sa:{0:F8} ea:{1:F8} sa-ea:{2:F8} may:{3:F8}", sa, ea, agl, may_angle))
        If direction = "G3" Then
            If sa > ea Then
                agl = sa - (ea + PI * 2)
            Else
                agl = ea - sa
            End If
        End If
        If direction = "G2" Then
            If ea > sa Then
                agl = ea - (sa + PI * 2)
            Else
                agl = sa - ea
            End If
        End If
        agl *= Sign(agl)
        If agl > max_angle Then
            ' Debug.WriteLine("---------------Angle Tol Break")
            GoTo kill_this_one
        End If
over:
        arc_data.y_running += yc
        arc_data.z_running += zc
        arc_data.running_count += 1
        arc_data.yc = yc 'csng(round(arc_data.y_running / arc_data.running_count, 4)
        arc_data.zc = zc 'csng(round(arc_data.z_running / arc_data.running_count, 4)
        arc_data.running_radius += r1d
        arc_data.radius = r1d 'csng(round(arc_data.running_radius / arc_data.running_count, 6)

        arc_data.start_angle = start_angle
        arc_data.end_angle = end_angle

        arc_data.x_off = y1 - yc
        arc_data.y_off = z1 - zc


        arc_data.arc_started = True
        If old_arc_plane <> arc_plane Then
            arc_plane_str = "G19"
            old_arc_plane = arc_plane
        End If
        Return state.active  ' passed arc test
    End Function

    Private Function mAtan2(ByVal y As Single, ByVal x As Single) _
  As Single
        Dim theta As Single
        theta = CSng(Atan2(y, x))
        If theta < 0 Then
            theta += CSng((PI * 2))
        End If
        Return theta
    End Function
    ' Inverse Sine
    Public Function ArcSin(ByVal X As Double) As Double
        ArcSin = Atan(X / Sqrt(-X * X + 1))
    End Function

    ' Inverse Cosine
    Public Function ArcCos(ByVal X As Double) As Double
        ArcCos = Atan(-X / Sqrt(-X * X + 1)) + 2 * Atan(1)
    End Function

    Private Function get_val(ByVal ln As String, ByVal g_code As String, ByVal old_val As Single) As Single
        Dim loc As Integer = 0
        Dim out_str As String = ""
        Dim com As Integer = InStr(ln, ";")
        If com = 0 Then com = 1000
        loc = InStr(ln, g_code)
        If loc > com Then ' make sure we dont return comment valuse.. :)
            Return old_val
        End If
        If loc = 0 Then
            Return old_val
        End If
        For z = loc To ln.Length - 1
            Dim s As String = Mid(ln, loc + 1, 1)
            If IsNumeric(s) Then
                out_str += s
                loc += 1
            ElseIf s = "-" Or s = "." Then
                out_str += s
                loc += 1
            ElseIf Not IsNumeric(s) Then
                Exit For

            End If

        Next
        Try
            Return CSng(out_str)
        Catch ex As Exception
            Return old_val
        End Try
    End Function
    Private Sub look_for_g_codes()
        Dim loc As Integer = 0
        Dim out_str As String = ""
        Dim com As Integer = InStr(block, ";")
        If com = 0 Then com = 1000
        loc = InStr(block, "G")
        If loc = 0 Then Return

        While loc < block.Length - 1
            If loc > com Then ' make sure we dont return comment values.. :)
                Return
            End If
            loc = InStr(loc, block, "G")

            If loc = 0 Then
                Return
            End If

            For z = loc To block.Length - 1
                Dim s As String = Mid(block, loc + 1, 1)
                If IsNumeric(s) Then
                    out_str += s
                    loc += 1
                ElseIf s = "-" Or s = "." Then
                    out_str += s
                    loc += 1
                ElseIf Not IsNumeric(s) Then
                    Exit For

                End If

            Next
            If out_str.Length = 0 Then GoTo no_string
            'pair up the G-Code
            Select Case CSng(out_str)
                Case 125
                    mode = mode 'debug
                Case 0
                    mode = 0
                    'mill cycles ----------------
                Case 1
                    mode = 1
                Case 2
                    mode = 2
                Case 3
                    mode = 3
                Case 17
                    arc = 17
                Case 18
                    arc = 18
                Case 19
                    arc = 19
                    'home cycles ----------------
                Case 28
                    mode = 0
                Case 29
                    mode = 0
                Case 49
                    ' mode = 20
                    ' cutter dia/length comp---------------
                    'Case 40
                    'Case 41
                    'Case 42
                Case 43
                    mode = 0 ' tool len apply so clear retract
                    retract = False
                Case 80
                    drill_mode = 0
                    ' drill_start = True 'reset drill flag
                    'drill cycles ----------------
                Case 73
                    mode = 81
                    drill_mode = 81
                Case 74
                    mode = 81
                    drill_mode = 74
                Case 76
                    mode = 81
                    drill_mode = 76
                Case 81
                    mode = 81
                    drill_mode = 81
                Case 82
                    mode = 81
                    drill_mode = 81
                Case 83
                    mode = 81
                    drill_mode = 83
                Case 84
                    mode = 81
                    drill_mode = 84
                    'msc cycles ----------------
                Case 90
                    'absolute = True
                Case 91
                    'absolute = False
                Case 98
                    retract = True
                Case 99
                    retract = False

            End Select
            loc += 1
            out_str = ""
            ' Application.DoEvents()
        End While
no_string:
    End Sub
    Private Sub reset_arc()

        work_str = ""
        arc_data.block_count = 0
        arc_data.arc_started = False
        arc_data.x_running = 0
        arc_data.y_running = 0
        arc_data.z_running = 0
        arc_data.running_count = 0
        arc_data.radius = 0
        arc_data.running_radius = 0
        arc_mode_str = ""
        '    arc_plane_str = ""
        g1_str = ""
        arc_data.x_sum = 0
        arc_data.y_sum = 0
        arc_data.z_sum = 0
        arc_data.direction = "G0"
        ReDim arc_data.rdata(1)
    End Sub

    Private Sub bt_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Visible = False
        frmMain.btn_process.Enabled = True
        zoom_window.TopMost = True
        frmMain.RTB1.Focus()
    End Sub

    Private Sub filter_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim delta As New Size(e.X - process_mouse.X, e.Y - process_mouse.Y)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += delta
            process_mouse = e.Location - delta
            Me.Update()
            frmMain.DrawScene()
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            process_mouse.X = e.X
            process_mouse.Y = e.Y
        End If
    End Sub

End Class
