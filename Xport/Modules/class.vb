Imports System.Math


Module classes
    Public z_retract As Single = 0
    Public Class plt
        Public _run As Boolean = True
        Public _abort As Boolean = False
        Public Sub run()
            _run = True
        End Sub
        Public Sub pause()
            _run = False
        End Sub
        Public Sub abort()
            _abort = True
        End Sub
        Public Sub start()
            Dim t As New Thread(AddressOf _main)
            t.IsBackground = True
            t.Name = "_plot_thread"
            t.Priority = ThreadPriority.Lowest
            _abort = False
            _run = True
            t.Start()
        End Sub
        Private Sub _main()
            While Not _abort
                While _run
                    frmMain.DrawScene()
                End While
            End While
        End Sub
    End Class



    Public Class lk_up ' used for cross referencing 
        Public g_buff As Integer
        Public t_buff As Integer
        Public sub_call As Boolean = False
    End Class
    Public Class xyz
        Public x As Single
        Public y As Single
        Public z As Single
    End Class
    Public Class line_d
        Public sx As Single
        Public sy As Single
        Public sz As Single
        Public ex As Single
        Public ey As Single
        Public ez As Single
        'Public color = Drawing.Color.Blue ' this uses to much space!
        Public co_r As Byte
        Public co_g As Byte
        Public co_b As Byte
        Public width As Single = 1.0
        Public just_z As Boolean = False
        Public rapid As Boolean = False
        Public text_pnt As Integer = 0
        Public arc As Integer = 0
        Public arc_data() As xyz
        Public info_string As String = ""
        Public valid As Boolean = False

    End Class

    Public Structure GCodeToken
        Public Line As String
        Public IsGoto As Boolean
        Public isNew()
        Public HasVTLCN As Boolean
        Public IsCommented As Boolean
        Public GCodes As List(Of Single)
        Public MCode As Integer
        Public Axes As Dictionary(Of String, Single)
    End Structure
    '---------------------------------
    Public Class op_core
        ' registers
        Public sx As Single
        Public sy As Single
        Public sz As Single
        '-------
        Public ex As Single
        Public ey As Single
        Public ez As Single
        '-------
        Public h As Single
        Public i As Single
        Public j As Single
        Public k As Single
        Public r As Single
        Public q As Single
        Public t As Single
        Public m As Single
        Public s As Single
        Public start_angle, end_angle As Single
        Public xc, yc, zc As Single
        Public arc As Single
        Public f As Single
        Public initial_z As Single
        '-------
        Public color As New Color
        '-------
        Public line_width As Single
        '-------
        Public rapid As Boolean
        Public just_z As Boolean
        '-------
        Public arc_string As String
        Public old_x As Single
        Public old_y As Single
        Public old_z As Single
        Public ts As Single
        Public te As Single
        Public _arc_step_size As Single = PI / 20
        Public arc_str As String = ""
        Public drill_depth As Single
        Public drill_mode As Integer
        Public retract As Boolean
        Public absolute As Boolean
        Public drill_start As Boolean
        Public hole_bottom As Single
        '-------
        Public text_pos As Integer
        Public line_n As Integer
        Public buff_pnt As Integer
        Public saved_buf_pnt As Integer
        Public mode As Integer
        Public new_op As Boolean
        Dim str_builder As New StringBuilder
        Public draw_data_length As Integer = 0
        Public first_sub_call As Boolean = True
        Public sub_call As Boolean = False
        Public sub_levels(10) As Integer
        Public sub_pointer As Integer = 0
        Public call_sub, return_sub As String
        Public fixture As Decimal
        ' Token list for preprocessed lines
        Public tokenizedLines As List(Of GCodeToken)

        Public Function TokenizeLines(lines As String()) As List(Of GCodeToken)
            Dim tokens As New List(Of GCodeToken)

            For Each ln In lines
                Dim rawLine As String = ln
                Dim codeOnly As String = StripComments(ln)

                Dim token As New GCodeToken With {
            .Line = rawLine,
            .IsGoto = codeOnly.Contains("GOTO"),
            .HasVTLCN = codeOnly.Contains("VTLCN"),
            .IsCommented = (codeOnly.TrimStart().StartsWith(";") Or codeOnly.TrimStart().StartsWith("(")),
            .GCodes = New List(Of Single),
            .Axes = New Dictionary(Of String, Single)(StringComparer.OrdinalIgnoreCase),
            .isNew = {False, False, False, False, False, False, False, False, False, False, False}
        }
                Dim axisId = 0
                For Each axis In {"X", "Y", "Z", "I", "J", "K", "R", "Q", "T", "H", "S"}
                    Dim val = ExtractSingleValue(codeOnly, axis)
                    If Not Single.IsNaN(val) Then
                        token.Axes(axis) = val
                        token.isNew(axisId) = True
                    End If
                    axisId += 1
                Next
                Dim mVal = ExtractSingleValue(codeOnly, "M")
                If Not Single.IsNaN(mVal) Then
                    token.MCode = mVal
                End If
                Dim gMatches = Text.RegularExpressions.Regex.Matches(codeOnly, "G(\d+)")
                For Each g In gMatches
                    Dim v As Single
                    If Single.TryParse(g.Groups(1).Value, v) Then
                        token.GCodes.Add(v)
                    End If
                Next

                tokens.Add(token)
            Next

            Return tokens
        End Function

        Private Function ExtractSingleValue(line As String, prefix As String) As Single
            Dim match = Text.RegularExpressions.Regex.Match(line, prefix & "([-+]?\d*\.?\d+)")
            If match.Success Then Return CSng(match.Groups(1).Value)
            Return Single.NaN
        End Function
        Private Function StripComments(line As String) As String
            Dim semi = line.IndexOf(";"c)
            Dim paren = line.IndexOf("("c)

            If semi = -1 Then semi = Integer.MaxValue
            If paren = -1 Then paren = Integer.MaxValue

            Dim cut = Math.Min(semi, paren)
            If cut = Integer.MaxValue Then
                Return line
            Else
                Return line.Substring(0, cut).Trim()
            End If
        End Function

        Public Function run() As Boolean
            Dim pnt As Integer
            If tokenizedLines Is Nothing OrElse tokenizedLines.Count = 0 Then
                tokenizedLines = TokenizeLines(frmMain.RTB1.Lines)
            End If

            call_sub = Lighting.sub_call_tb.Text
            return_sub = Lighting.sub_return_tb.Text
            setup_buffers_and_pointers()
            start_up()
            frmMain.pg1.Maximum = pgm_lines.Length - 1
            Dim running_count, xc, yc, zc, run_x, run_y, run_z As Decimal
            If pgm_lines.Length = 1 Then
                Return True
            End If
            ez = z_retract : sz = z_retract
            store(0)
            buff_pnt += 1
            running_count = 0

            '--- Initialize modal position state ---
            sx = ex : sy = ey : sz = ez

            For ln = 0 To tokenizedLines.Count - 1
                line_width = 1.0
                frmMain.pg1.Value = ln
                Dim token = tokenizedLines(ln)

                If token.IsCommented Or token.HasVTLCN Then
                    If Not sub_call Then text_pos += 1
                    Continue For
                End If

                If token.IsGoto Then
                    Dim n = ExtractSingleValue(token.Line, "N")
                    For pnt = ln + 1 To tokenizedLines.Count - 1
                        Dim fn = ExtractSingleValue(tokenizedLines(pnt).Line, "N")
                        If n = fn Then
                            ln = pnt
                            Exit For
                        End If
                        If pnt = tokenizedLines.Count - 1 Then
                            MsgBox("GOTO N" & n.ToString & " : N not found!", MsgBoxStyle.Exclamation, "Program Error")
                            Return False
                        End If
                    Next
                    Continue For
                End If

                If absolute Then
                    If token.isNew(0) Then ex = token.Axes("X")
                    If token.isNew(1) Then ey = token.Axes("Y")
                    If token.isNew(2) Then ez = token.Axes("Z")

                Else
                    If token.Axes.ContainsKey("X") Then ex += token.Axes("X")
                    If token.Axes.ContainsKey("Y") Then ey += token.Axes("Y")
                    If token.Axes.ContainsKey("Z") Then ez += token.Axes("Z")
                End If

                If token.isNew(3) Then i = token.Axes("I")
                If token.isNew(4) Then j = token.Axes("J")
                If token.isNew(5) Then k = token.Axes("K")
                If token.Axes.ContainsKey("R") Then r += token.Axes("R")
                If token.Axes.ContainsKey("Q") Then q += token.Axes("Q")
                If token.Axes.ContainsKey("S") Then s += token.Axes("S")
                If token.Axes.ContainsKey("T") Then t += token.Axes("T")
                If token.Axes.ContainsKey("H") Then h += token.Axes("H")

                m = token.MCode

                ' Set G and modal modes
                If token.GCodes.Contains(0) Then mode = 0
                If token.GCodes.Contains(1) Or token.GCodes.Contains(40) Or token.GCodes.Contains(41) Or token.GCodes.Contains(42) Then mode = 1
                If token.GCodes.Contains(2) Then mode = 2
                If token.GCodes.Contains(3) Then mode = 3
                If token.GCodes.Contains(17) Then arc = 17
                If token.GCodes.Contains(18) Then arc = 18
                If token.GCodes.Contains(19) Then arc = 19
                If token.GCodes.Contains(28) Or token.GCodes.Contains(29) Or token.GCodes.Contains(49) Then mode = 28
                If token.GCodes.Contains(43) Then mode = 43 : retract = False
                If token.GCodes.Contains(73) Then mode = 81 : drill_mode = 81
                If token.GCodes.Contains(81) Then mode = 81 : drill_mode = 81
                If token.GCodes.Contains(82) Then mode = 81 : drill_mode = 81
                If token.GCodes.Contains(83) Then mode = 81 : drill_mode = 83
                If token.GCodes.Contains(84) Then mode = 81 : drill_mode = 84
                If token.GCodes.Contains(90) Then absolute = True
                If token.GCodes.Contains(91) Then absolute = False
                If token.GCodes.Contains(98) Then retract = True
                If token.GCodes.Contains(99) Then retract = False

                If ex <> sx Or ey <> sy Or ez <> sz Or mode = 2 Or mode = 3 Or mode = 6 Or mode = 15 Or mode = 28 Or sub_call Then
                    rapid = False
                    just_z = (sx = ex And sy = ey)
                    If mode <> 0 Then
                        run_x += sx + offset_x(fixture)
                        run_y += sx + offset_y(fixture)
                        run_z += sz
                        running_count += 1
                        xc = run_x / running_count
                        yc = run_y / running_count
                        zc = run_z / running_count
                    End If
                    check_min_max()
                    line_width = 1
                    draw_data(buff_pnt).arc = 0

                    Select Case mode
                        Case 0
                            color = Color.White : rapid = True : line_width = 1
                            store(ln) : set_lookup() : set_current_xyz()
                            draw_data(buff_pnt).info_string = $"RAPID - X{ex:F4} Y{ey:F4} Z{ez:F4}"
                            buff_pnt += 1

                        Case 1, 40, 41, 42
                            color = Drawing.Color.Blue : rapid = False : line_width = 4
                            store(ln) : set_lookup() : set_current_xyz()
                            draw_data(buff_pnt).info_string = $"LINEAR - X{ex:F4} Y{ey:F4} Z{ez:F4}"
                            buff_pnt += 1

                        Case 2, 3
                            draw_data(buff_pnt).info_string = "" : just_z = False
                            Select Case arc
                                Case 17
                                    old_x = ex : old_y = ey
                                    do_gcode17(arc_str, sx, ex, sy, ey, i, j, mode, draw_data(buff_pnt).info_string)
                                    ex = old_x : ey = old_y
                                Case 18
                                    old_x = ex : old_z = ez
                                    do_gcode18(arc_str, sx, ex, sz, ez, i, k, mode, draw_data(buff_pnt).info_string)
                                    ex = old_x : ez = old_z
                                Case 19
                                    old_y = ey : old_z = ez
                                    do_gcode19(arc_str, sy, ey, sz, ez, j, k, mode, draw_data(buff_pnt).info_string)
                                    ey = old_y : ez = old_z

                            End Select
                            color = Drawing.Color.Blue : rapid = False : line_width = 1
                            store(ln) : set_lookup() : set_current_xyz()
                            buff_pnt += 1

                        Case 43
                            mode = 0 : drill_start = True : initial_z = ez
                            color = Drawing.Color.White : rapid = True : line_width = 1
                            store(ln) : set_lookup()
                            sx = ex : sy = ey : sz = ez
                            draw_data(buff_pnt).info_string = $"Length Comp. - X{ex:F4} Y{ey:F4} Z{ez:F4}"
                            buff_pnt += 1

                        Case 28
                            ez = z_retract : initial_z = z_retract
                            set_lookup() : color = Drawing.Color.Yellow : rapid = True
                            store(ln)
                            draw_data(buff_pnt).info_string = $"Home - X{ex:F4} Y{ey:F4} Z{ez:F4}"
                            buff_pnt += 1 : set_current_xyz()
                            If m = 6 Then m = 0

                        Case 6
                            ez = z_retract : initial_z = z_retract
                            set_lookup() : color = Drawing.Color.Yellow : rapid = True
                            store(ln)
                            draw_data(buff_pnt).info_string = $"Tool Change - T{t:F0} X{ex:F4} Y{ey:F4} Z{ez:F4}"
                            buff_pnt += 1 : set_current_xyz()
                            If m = 6 Then m = 0

                        Case 15
                            draw_data(buff_pnt).info_string = $"Fixture Offset #{fixture:F0} X{offset_x(fixture):F4} Y{offset_y(fixture):F4}"
                            store(ln) : set_lookup()
                            buff_pnt += 1
                    End Select
                ElseIf m = 1 Then
                    draw_data(buff_pnt).info_string = $"OPT PROGRAM STOP X{ex:F4} Y{ey:F4} Z{ez:F4}"
                    store(ln) : set_lookup()
                    buff_pnt += 1
                End If

                If Not sub_call Then text_pos += 1
                If m = 30 Then
                    ReDim Preserve draw_data(buff_pnt - 1)
                    Return False
                End If
            Next

            eye_x = xc
            eye_y = zc
            eye_z = yc

            If sub_call Then
                ReDim Preserve draw_data(buff_pnt)
                MsgBox("M99 Sub return not found!", MsgBoxStyle.Exclamation, "Program Error")
            End If

            Return False
        End Function

        Public Function FindSub(ByVal pnt As Integer, ByVal token1 As String, ByVal token2 As String) As Integer
            Dim num As Integer = get_val(pgm_lines(pnt - 1), token1, 0.0!, pnt)
            Dim o, c As Integer
            If num = 0 Then
                pnt -= 1
                MsgBox("Program error at line:" + pnt.ToString, MsgBoxStyle.Exclamation, "Program Error")
                Return -1
            End If
            For pos = pnt + 1 To pgm_lines.Length - 1
                Dim loc As Integer = InStr(pgm_lines(pos), ";")
                If loc = 0 Then loc = 1000
                Dim hit As Integer = InStr(pgm_lines(pos), token2)
                If hit > 0 And hit < loc Then
                    Dim fndval = get_val(pgm_lines(pos), token2, 0.0!, pos)
                    If InStr(pgm_lines(pos), call_sub) = 0 Then
                        If fndval = num Then
                            If frmMain.sub_start_line = 1000000 Then
                                frmMain.sub_start_line = pos
                            End If
                            If first_sub_call Then

                                Dim lx = pos + 1
                                While InStr(pgm_lines(lx), return_sub) = 0
                                    o = InStr(pgm_lines(lx), "O")
                                    c = InStr(pgm_lines(lx), ";")
                                    If c = 0 Then c = 10000
                                    If o > 0 Then
                                        If Not o > c Then
                                            'MsgBox(return_sub + " Sub return not found! line:" + pnt.ToString, MsgBoxStyle.Exclamation, "Program Error")
                                            GoTo skip_
                                        End If
                                    End If
                                    ' If c = 10000 Or o < c Then
skip_:
                                    lx += 1
                                    'End If
                                    If lx = pgm_lines.Length Then
                                        MsgBox(return_sub + " Sub return not found! line:" + pnt.ToString, MsgBoxStyle.Exclamation, "Program Error")
                                        Return -1

                                    End If
                                End While
                                lx -= 1
                                Dim lk As Integer = lookup.Length
                                Dim dk As Integer = draw_data.Length
                                ReDim Preserve lookup(lookup.Length + lx)
                                ReDim Preserve draw_data(draw_data.Length + lx)
                                draw_data_length += lx
                                For bp = 0 To lx
                                    lookup(bp + lk) = New lk_up
                                    draw_data(bp + dk) = New line_d
                                Next
                            End If
                            first_sub_call = False

                            Return pos + 1
                        End If
                    End If
                End If
            Next
            ' MsgBox("Sub Program not found! :" + pnt.ToString, MsgBoxStyle.Exclamation, "Program Error")
            Return -1

        End Function
        Private Sub set_current_xyz()
            sx = ex
            sy = ey
            sz = ez
        End Sub
        Private Sub start_up()
            first_sub_call = True
            sub_call = False
            retract = False
            drill_start = True
            mode = 0
            new_op = True
            h = 0
            ex = 0
            ey = 0
            ez = 3
            sx = 0
            sy = 0
            sz = 20
            draw_data(buff_pnt) = New line_d
            frmMain.sub_start_line = 1000000
            If My.Settings.abs_inc_mode Then
                absolute = True
            Else
                absolute = False
            End If
        End Sub
        Private Sub setup_buffers_and_pointers()
            str_builder.Length = 0
            str_builder.Append(frmMain.RTB1.Text)
            pgm_lines = str_builder.ToString.Split(ChrW(10)) ' frmMain.RTB1.Text.Split(ChrW(10))
            draw_data_length = pgm_lines.Length + 1
            ReDim Preserve draw_data(pgm_lines.Length + 1)
            ReDim Preserve lookup(pgm_lines.Length + 1)
            For bp = 0 To pgm_lines.Length + 1
                draw_data(bp) = New line_d
                lookup(bp) = New lk_up
            Next
            text_pos = 0
            buff_pnt = 0
            frmMain.sub_start_line = 1000000
        End Sub

        Private Sub resize_draw_data()
            draw_data_length += 1
            ReDim Preserve draw_data(draw_data_length)
            draw_data(draw_data_length) = New line_d
        End Sub
        Private Sub set_lookup()
            lookup(text_pos).t_buff = text_pos
            lookup(text_pos).g_buff = buff_pnt
        End Sub
        Private Sub store(ByVal ln As Integer)
            'draw_data(buff_pnt).color = color
            draw_data(buff_pnt).co_r = color.R
            draw_data(buff_pnt).co_g = color.G
            draw_data(buff_pnt).co_b = color.B
            draw_data(buff_pnt).width = line_width
            draw_data(buff_pnt).rapid = rapid
            draw_data(buff_pnt).just_z = just_z

            draw_data(buff_pnt).sx = sx + offset_x(fixture)
            draw_data(buff_pnt).sy = sy + offset_y(fixture)
            draw_data(buff_pnt).sz = sz

            draw_data(buff_pnt).ex = ex + offset_x(fixture)
            draw_data(buff_pnt).ey = ey + offset_y(fixture)
            draw_data(buff_pnt).ez = ez
            draw_data(buff_pnt).text_pnt = ln
            draw_data(buff_pnt).valid = True
        End Sub
        Dim ls As String = "XYZIJKGMDFHQRSTO"
        Private Function test_valid_line(ByVal ln As Integer) As Boolean
            Dim s = pgm_lines(ln)
            Dim pos As Integer = 0
            If s.Length = 0 Then Return False
            Dim com = InStr(s, ";")
            If com = 0 Then com = 1000
            For p1 = 0 To s.Length - 1
                pos = InStr(ls, s(p1))
                If pos > 0 And pos < com Then

                    Return True
                End If
                'For p2 = 0 To ls.Length - 1
                '    If s(p1) = ls(p2) Then
                '        If p1 > com Then
                '            Return False
                '        Else
                '            Return True
                '        End If
                '    End If
                'Next
            Next
            Return False
        End Function
        Private Sub look_for_g_codes(ByVal ln As Integer)
            If InStr(pgm_lines(ln), "GOTO") > 0 Then Return
            Dim loc As Integer = 0
            Dim z As Integer = 0
            Dim s As String = ""
            ' Dim cc As Char
            Dim out_str As String = ""
            Dim com As Integer = InStr(pgm_lines(ln), ";", CompareMethod.Binary)

            If com = 0 Then com = 1000

            loc = InStr(pgm_lines(ln), "G")
            If loc = 0 Then
                Return
            End If

            While loc < pgm_lines(ln).Length - 1
                If loc > com Then ' make sure we dont return comment values.. :)
                    Return
                End If
                loc = InStr(loc, pgm_lines(ln), "G", CompareMethod.Binary)

                If loc = 0 Then
                    Return
                End If
                Dim c As Integer = 0
                For z = loc To pgm_lines(ln).Length - 1
                    c += 1
                    s = Mid(pgm_lines(ln), loc + 1, 1)
                    If s > "," And s < ":" Then
                        out_str += s
                        loc += 1
                    Else
                        Exit For
                    End If



                Next
                If c = 1 And Not _IsNumeric(s) Then
                    Dim l = ln + 1
                    MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + pgm_lines(ln) + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                    Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(ln)
                    Dim sll = sl + z
                    frmMain.RTB1.SelectionStart = sll
                    frmMain.RTB1.SelectionLength = 1
                    Return

                End If
next_part:
                If out_str.Length = 0 Then GoTo no_string
                'pair up the G-Code
                Try

                    Select Case CSng(out_str)
                        Case 15 ' okuma offset code
                            If Not Lighting.fanuc_cb.Checked Then
                                fixture = get_val(pgm_lines(ln), "H", -1, ln) - 1
                                If fixture = -1 Then
                                    MsgBox("Bad Sub call", MsgBoxStyle.Exclamation, "Program Error")
                                    fixture = 0
                                End If
                                'mode = 15
                            End If
                        Case 54, 55, 56, 57, 58, 59 'fanuc offsets
                            If Lighting.fanuc_cb.Checked Then
                                fixture = CSng(out_str) - 54
                                'mode = 15
                            Else
                                If CSng(out_str) = 56 Then
                                    mode = 43 ' tool len apply so clear retract
                                    retract = False
                                End If
                            End If
                        Case 125
                            mode = mode 'debug
                        Case 0
                            mode = 0
                            'mill cycles ----------------
                        Case 1, 41, 42, 40
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
                            mode = 28
                        Case 29
                            mode = 28
                        Case 49
                            mode = 28
                            ' cutter dia/length comp---------------
                            'Case 40
                            'Case 41
                            'Case 42
                        Case 43
                            mode = 43 ' tool len apply so clear retract
                            retract = False
                        Case 80
                            mode = 0
                            retract = False
                            drill_mode = 0
                            drill_start = True 'reset drill flag
                            'drill cycles ----------------
                        Case 73
                            mode = 81
                            drill_mode = 81
                            hole_bottom = ez
                        Case 74
                            mode = 81
                            drill_mode = 74
                            hole_bottom = ez
                        Case 76
                            mode = 81
                            drill_mode = 76
                            hole_bottom = ez
                        Case 81
                            mode = 81
                            drill_mode = 81
                            hole_bottom = ez
                        Case 82
                            mode = 81
                            drill_mode = 81
                            hole_bottom = ez
                        Case 83
                            mode = 81
                            drill_mode = 83
                            hole_bottom = ez
                        Case 84
                            mode = 81
                            drill_mode = 84
                            hole_bottom = ez
                            'msc cycles ----------------
                        Case 90
                            absolute = True
                        Case 91
                            absolute = False
                        Case 98
                            retract = True
                        Case 99
                            retract = False

                    End Select
                Catch ex As Exception
                    If s = "." Or s = "-" Then GoTo next_part
                    Dim l = ln + 1
                    MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + pgm_lines(ln) + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                    Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(ln)
                    Dim sll = sl + z
                    frmMain.RTB1.SelectionStart = sll
                    frmMain.RTB1.SelectionLength = 1
                    Return

                End Try
                loc += 1
                out_str = ""
                ' Application.DoEvents()
            End While
no_string:
            Return
        End Sub

        Public Sub get_all_values(ByVal line_n As Integer)
            If InStr(pgm_lines(line_n), call_sub) > 0 Then
                m = 98
                Return
            End If

            If InStr(pgm_lines(line_n), return_sub) > 0 Then
                m = 99
                Return
            End If
            m = get_val(pgm_lines(line_n), "M", 9, line_n)
            Select Case m
                Case 140, 105, 190, 104, 109, 82, 117, 84
                Case Else
                    ex = get_val(pgm_lines(line_n), "X", ex, line_n)
                    ey = get_val(pgm_lines(line_n), "Y", ey, line_n)
                    ez = get_val(pgm_lines(line_n), "Z", ez, line_n)
                    i = get_val(pgm_lines(line_n), "I", 0, line_n)
                    j = get_val(pgm_lines(line_n), "J", 0, line_n)
                    k = get_val(pgm_lines(line_n), "K", 0, line_n)
                    q = get_val(pgm_lines(line_n), "Q", q, line_n)
                    r = get_val(pgm_lines(line_n), "R", r, line_n)
                    s = get_val(pgm_lines(line_n), "S", s, line_n)
                    t = get_val(pgm_lines(line_n), "T", t, line_n)
                    h = get_val(pgm_lines(line_n), "H", 0, line_n)

            End Select




            If h > 0 Then
            End If

        End Sub
        Public Sub get_all_values_incremental(ByRef line_n As Integer)
            If InStr(pgm_lines(line_n), call_sub) > 0 Then
                m = 98
                Return
            End If

            If InStr(pgm_lines(line_n), return_sub) > 0 Then
                m = 99
                Return
            End If
            Dim i_ex = get_val(pgm_lines(line_n), "X", 0, line_n)
            Dim i_ey = get_val(pgm_lines(line_n), "Y", 0, line_n)
            Dim i_ez = get_val(pgm_lines(line_n), "Z", 0, line_n)
            i = get_val(pgm_lines(line_n), "I", 0, line_n)
            j = get_val(pgm_lines(line_n), "J", 0, line_n)
            k = get_val(pgm_lines(line_n), "K", 0, line_n)
            q = get_val(pgm_lines(line_n), "Q", q, line_n)
            r = get_val(pgm_lines(line_n), "R", r, line_n)
            s = get_val(pgm_lines(line_n), "S", s, line_n)
            t = get_val(pgm_lines(line_n), "T", t, line_n)
            h = get_val(pgm_lines(line_n), "H", 0, line_n)
            m = get_val(pgm_lines(line_n), "M", 9, line_n)
            ex += i_ex
            ey += i_ey
            ez += i_ez


            If h > 0 Then
            End If

        End Sub

        Private Sub check_min_max()
            If ex < x_min Then x_min = ex
            If ex > x_max Then x_max = ex
            If ey < y_min Then y_min = ey
            If ey > y_max Then y_max = ey
            If ez < z_min Then z_min = ez
            If ez > z_max Then z_max = ez
        End Sub

        Private Function do_gcode17(ByRef datastring As String, ByVal xo As Single, ByVal xn As Single _
                             , ByVal yo As Single, ByVal yn As Single, ByVal ii As Single _
                             , ByVal jj As Single, ByVal g As Single, ByRef str As String) As Integer

            Dim xa, ya, xb, yb, radius1, radius2 As Single
            Dim rad1, rad2 As Single

            xc = Round(xo + ii, 4)
            yc = Round(yo + jj, 4)


            xa = xo - xc
            ya = yo - yc
            xb = xn - xc
            yb = yn - yc

            rad1 = CSng(Sqrt((xa * xa) + (ya * ya)))
            rad2 = CSng(Sqrt((xb * xb) + (yb * yb)))

            start_angle = CSng(mAtan2(ya, xa))
            end_angle = CSng(mAtan2(yb, xb))
            radius1 = Round(rad1, 4)
            radius2 = Round(rad2, 4)
            str = String.Format("ARC - Radius={0:F4} Start angle={1:F4} End angle={2:F4} X{3:F4} Y{4:F4} Z{5:F4} " _
                                        , radius1, start_angle * 57.29578, end_angle * 57.29578, xn, yn, ez)

            If radius1 = 0 Or radius2 = 0 Then Return (1)


            If g = 2 And end_angle > start_angle Then
                end_angle -= (PI * 2)
            End If
            If g = 2 And end_angle = start_angle Then
                end_angle -= (PI * 2)
            End If
            If g = 3 And start_angle > end_angle Then
                start_angle -= (PI * 2)
            End If
            If g = 3 And start_angle = end_angle Then
                start_angle -= (PI * 2)
            End If
            do_arc17(rad1, start_angle, end_angle, xc, yc)

            Return (0)

        End Function
        Private Sub do_arc17(ByVal radi As Single, ByVal start As Single _
                            , ByVal _end As Single, ByVal i As Single _
                            , ByVal j As Single)

            ' G02
            Dim x, y, z As Single

            With draw_data(buff_pnt)
                ' If _end > start Then start += CSng(2D * PI)
                If _end = start Then start += CSng(2D * PI)

                Dim arc_data_pnt As Integer = 0
                start = Round(start, 6)
                _end = Round(_end, 6)
                If _end = start Then start += CSng(2 * PI)
                Dim diff As Single = Round(_end - start, 6)
                Dim _step As Single = CSng(Round(diff / 30.0!, 10))
                If _step = 0 Then _step = Sign(diff)

                Dim z_step = (sz - ez) / (diff / _step)
                If ez = 0 Then z_step = 0
                z = sz
                ReDim Preserve .arc_data(50)

                For _pos@ = start To _end Step _step
                    x = CSng((Cos(_pos) * radi) + i)
                    y = CSng((Sin(_pos) * radi) + j)
                    .arc_data(arc_data_pnt) = New xyz
                    .arc_data(arc_data_pnt).x = x + offset_x(fixture)
                    .arc_data(arc_data_pnt).y = y + offset_y(fixture)
                    .arc_data(arc_data_pnt).z = z
                    z -= z_step
                    arc_data_pnt += 1
                Next _pos
                .arc_data(arc_data_pnt) = New xyz
                .arc_data(arc_data_pnt).x = ex + offset_x(fixture)
                .arc_data(arc_data_pnt).y = ey + offset_y(fixture)
                .arc_data(arc_data_pnt).z = ez
                ReDim Preserve .arc_data(arc_data_pnt)
            End With
            draw_data(buff_pnt).arc = 2
        End Sub

        Private Function do_gcode18(ByRef datastring As String, ByVal xo As Single, ByVal xn As Single _
                        , ByVal zo As Single, ByVal zn As Single, ByVal ii As Single _
                        , ByVal kk As Single, ByVal g As Single, ByRef str As String) As Integer

            Dim xa, za, xb, zb, radius1, radius2 As Single
            Dim rad1, rad2 As Single

            xc = Round(xo + ii, 4)
            zc = Round(zo + kk, 4)

            xa = xo - xc
            za = zo - zc
            xb = xn - xc
            zb = zn - zc

            rad1 = CSng(Sqrt((xa * xa) + (za * za)))
            rad2 = CSng(Sqrt((xb * xb) + (zb * zb)))

            start_angle = CSng(mAtan2(za, xa))
            end_angle = CSng(mAtan2(zb, xb))
            radius1 = Round(rad1, 4)
            radius2 = Round(rad2, 4)
            rad1 = radius1
            rad2 = radius2

            str = String.Format("ARC - Radius={0:F4} Start angle={1:F4} End angle={2:F4} X{3:F4} Y{4:F4} Z{5:F4} " _
                        , radius1, start_angle * 57.29578, end_angle * 57.29578, xn, ey, zn)

            ' minimal direction fix
            If radius1 = 0 Or radius2 = 0 Then Return 1

            Dim sweep As Single = end_angle - start_angle
            If sweep <= -PI Then
                sweep += CSng(2 * PI)
            ElseIf sweep > PI Then
                sweep -= CSng(2 * PI)
            End If

            If CInt(g) = 3 Then                ' G2 = CW -> negative sweep
                If sweep > 0 Then sweep -= CSng(2 * PI)
                If Math.Abs(sweep) < 0.000001F Then sweep = CSng(-2 * PI)
            ElseIf CInt(g) = 2 Then            ' G3 = CCW -> positive sweep
                If sweep < 0 Then sweep += CSng(2 * PI)
                If Math.Abs(sweep) < 0.000001F Then sweep = CSng(2 * PI)
            Else
                Return 3
            End If

            end_angle = start_angle + sweep
            ' end minimal fix

            do_arc18(rad1, start_angle, end_angle, xc, zc)
            Return 0
        End Function
        Private Sub do_arc18(ByVal radi As Single,
                     ByVal start As Single,
                     ByVal _end As Single,
                     ByVal cx As Single,   ' i
                     ByVal cz As Single)   ' k

            Const PI As Single = 3.14159274F
            Const MAX_SEG_ANG As Single = PI / 36.0F   ' 5° per segment
            Const TOL As Single = 0.000001F

            Dim diff As Single = _end - start
            If Math.Abs(diff) < TOL Then
                ' assume caller normalized full-circle already; keep tiny sweep as zero
                diff = 0.0F
            End If

            Dim steps As Integer = Math.Max(2, CInt(Math.Ceiling(Math.Abs(diff) / MAX_SEG_ANG)))
            If diff = 0.0F Then steps = 2 ' straight helical “arc” with no angular motion

            With draw_data(buff_pnt)
                ' allocate exactly
                ReDim .arc_data(steps)

                For idx As Integer = 0 To steps
                    Dim t As Single = idx / CSng(steps)
                    Dim ang As Single = start + t * diff

                    Dim x As Single, z As Single, y As Single

                    If diff = 0.0F Then
                        ' degenerate: no angular motion, keep start angle
                        x = CSng(Math.Cos(start) * radi) + cx
                        z = CSng(Math.Sin(start) * radi) + cz
                    Else
                        x = CSng(Math.Cos(ang) * radi) + cx
                        z = CSng(Math.Sin(ang) * radi) + cz
                    End If

                    y = sy + t * (ey - sy)   ' linear Y for helical moves

                    .arc_data(idx) = New xyz With {
                .x = x + offset_x(fixture),
                .y = y + offset_y(fixture),
                .z = z
            }
                Next

                ' Snap endpoint to commanded end to avoid accumulation error
                .arc_data(steps).x = ex + offset_x(fixture)
                .arc_data(steps).y = ey + offset_y(fixture)
                .arc_data(steps).z = ez

                .arc = 2
            End With
        End Sub

        ' G19: YZ plane, center J,K
        Private Function do_gcode19(ByRef datastring As String,
                            ByVal yo As Single, ByVal yn As Single,
                            ByVal zo As Single, ByVal zn As Single,
                            ByVal jj As Single, ByVal kk As Single,
                            ByVal g As Single,
                            ByRef str As String) As Integer

            Dim ya, za, yb, zb, radius1, radius2 As Single
            Dim rad1, rad2 As Single

            ' Arc center in YZ plane
            yc = CSng(Round(yo + jj, 4))
            zc = CSng(Round(zo + kk, 4))

            ' Vectors from center to start and end
            ya = yo - yc
            za = zo - zc
            yb = yn - yc
            zb = zn - zc

            rad1 = CSng(Sqrt((ya * ya) + (za * za)))
            rad2 = CSng(Sqrt((yb * yb) + (zb * zb)))

            ' SAME pattern as G17, but in YZ
            start_angle = CSng(mAtan2(za, ya))
            end_angle = CSng(mAtan2(zb, yb))

            radius1 = CSng(Round(rad1, 4))
            radius2 = CSng(Round(rad2, 4))

            str = String.Format("ARC G19 - Radius={0:F4} Start angle={1:F4} End angle={2:F4} Y{3:F4} Z{4:F4} X{5:F4} ",
                        radius1,
                        start_angle * 57.29578,
                        end_angle * 57.29578,
                        yn, zn, ex)   ' ex = final X

            If radius1 = 0 Or radius2 = 0 Then Return 1

            ' IDENTICAL unwrapping rules
            If g = 2 AndAlso end_angle > start_angle Then
                end_angle -= CSng(PI * 2)
            End If
            If g = 2 AndAlso end_angle = start_angle Then
                end_angle -= CSng(PI * 2)
            End If
            If g = 3 AndAlso start_angle > end_angle Then
                start_angle -= CSng(PI * 2)
            End If
            If g = 3 AndAlso start_angle = end_angle Then
                start_angle -= CSng(PI * 2)
            End If

            do_arc19(rad1, start_angle, end_angle, yc, zc)

            Return 0
        End Function

        Private Sub do_arc19(ByVal radi As Single,
                     ByVal start As Single,
                     ByVal _end As Single,
                     ByVal j As Single,
                     ByVal k As Single)

            ' G19: YZ plane, X is helical axis
            Dim x, y, z As Single

            With draw_data(buff_pnt)
                If _end = start Then start += CSng(2D * PI)

                Dim arc_data_pnt As Integer = 0

                start = Round(start, 6)
                _end = Round(_end, 6)
                If _end = start Then start += CSng(2 * PI)

                Dim diff As Single = Round(_end - start, 6)
                Dim _step As Single = CSng(Round(diff / 30.0!, 10))
                If _step = 0 Then _step = Sign(diff)

                ' Helical along X (axis not in the YZ plane)
                Dim x_step As Single = CSng((sx - ex) / (diff / _step))
                If sx = ex Then x_step = 0
                x = sx

                ReDim Preserve .arc_data(50)

                For _pos@ = start To _end Step _step
                    y = CSng((Cos(_pos) * radi) + j)
                    z = CSng((Sin(_pos) * radi) + k)

                    .arc_data(arc_data_pnt) = New xyz
                    .arc_data(arc_data_pnt).x = x + offset_x(fixture)
                    .arc_data(arc_data_pnt).y = y + offset_y(fixture)
                    .arc_data(arc_data_pnt).z = z

                    x -= x_step
                    arc_data_pnt += 1
                Next _pos

                ' Force exact end point
                .arc_data(arc_data_pnt) = New xyz
                .arc_data(arc_data_pnt).x = ex + offset_x(fixture)
                .arc_data(arc_data_pnt).y = ey + offset_y(fixture)
                .arc_data(arc_data_pnt).z = ez

                ReDim Preserve .arc_data(arc_data_pnt)
            End With

            draw_data(buff_pnt).arc = 2
        End Sub



        'Public Sub get_xyz_only() 'may or may not use this sub
        '    ex = get_val(pgm_lines(text_pos), "X", ex)
        '    ey = get_val(pgm_lines(text_pos), "Y", ey)

        'End Sub

        'Private Sub get_arc_vals_special()
        '    ex = get_val(pgm_lines(text_pos), "X", 0.0F)
        '    ey = get_val(pgm_lines(text_pos), "Y", 0.0F)

        'End Sub
        Private Function get_val_call(ByRef ln As String, ByRef g_code As String, ByRef old_val As Single, ByRef pos As Integer) As Single

            Dim loc As Integer = 0
            Dim z As Integer
            Dim s As String = ""
            Dim out_str As String = ""
            Dim com As Integer = InStr(ln, ";", CompareMethod.Binary)
            If com = 0 Then com = 1000
            loc = InStr(ln, g_code, CompareMethod.Binary)
            If loc = 0 Then
                Return old_val
            End If
            If loc > com Then ' make sure we dont use values in comments.. :)
                Return old_val
            End If
            Dim c As Integer = 0
            For z = loc To ln.Length - 1
                c += 1
                s = Mid(ln, loc + 1, 1)
                If s > "," And s < ":" Then
                    out_str += s
                    loc += 1
                Else
                    Exit For
                End If
            Next
            If c = 1 And Not _IsNumeric(s) Then
                Dim l = pos + 1
                MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + ln + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(pos)
                Dim sll = sl + z
                frmMain.RTB1.SelectionStart = sll
                frmMain.RTB1.SelectionLength = 1

                Return old_val

            End If
next_part:
            If out_str.Length > 0 Then
                Try

                    Return CSng(out_str)
                Catch ex As Exception
                    Dim l = pos + 1
                    MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + ln + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                    Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(pos)
                    Dim sll = sl + z
                    frmMain.RTB1.SelectionStart = sll
                    frmMain.RTB1.SelectionLength = 1
                    Return old_val
                End Try
            Else
                Return old_val
            End If

        End Function
        Private Function get_val(ByRef ln As String, ByRef g_code As String, ByRef old_val As Single, ByRef pos As Integer) As Single
            If InStr(ln, "GOTO") > 0 Then Return old_val
            If InStr(ln, "NAT") > 0 Then
                If g_code = "N" Or g_code = "T" Or g_code = "A" Then
                    Return old_val
                End If
            End If

            Dim loc As Integer = 0
            Dim z As Integer
            Dim s As String = ""
            Dim out_str As String = ""
            Dim com As Integer = InStr(ln, ";", CompareMethod.Binary)
            If com = 0 Then com = 1000
            loc = InStr(ln, g_code, CompareMethod.Binary)
            If loc = 0 Then
                Return old_val
            End If
            If loc > com Then ' make sure we dont use values in comments.. :)
                Return old_val
            End If
            Dim c As Integer = 0
            For z = loc To ln.Length - 1
                c += 1
                s = Mid(ln, loc + 1, 1)
                If s > "," And s < ":" Then
                    out_str += s
                    loc += 1
                Else
                    Exit For
                End If
            Next
            If c = 1 And Not _IsNumeric(s) Then
                Dim l = pos + 1
                MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + ln + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(pos)
                Dim sll = sl + z
                frmMain.RTB1.SelectionStart = sll
                frmMain.RTB1.SelectionLength = 1

                Return old_val

            End If
next_part:
            If out_str.Length > 0 Then
                Try

                    Return CSng(out_str)
                Catch ex As Exception
                    Dim l = pos + 1
                    MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + ln + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")
                    Dim sl = frmMain.RTB1.GetFirstCharIndexFromLine(pos)
                    Dim sll = sl + z
                    frmMain.RTB1.SelectionStart = sll
                    frmMain.RTB1.SelectionLength = 1
                    Return old_val
                End Try
            Else
                Return old_val
            End If

        End Function
        Private Function mAtan2(ByRef y As Single, ByRef x As Single) _
       As Single
            Dim theta As Single
            theta = CSng(Atan2(y, x))
            If theta < 0 Then
                theta += CSng((PI * 2))
            End If
            Return theta
        End Function
    End Class
    Public Function _IsNumeric(ByRef s As Char) As Boolean
        If s < "," Or s > ":" Then Return False
        If s = "/" Then Return False
        Return True
    End Function

End Module
