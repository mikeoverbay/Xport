Imports System.Threading
Imports System.IO
Imports System.IO.Ports
Imports System.String
Imports System.Windows.Forms

Module classes
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
            Dim t As New thread(AddressOf _main)
            t.name = "_plot_thread"
            t.priority = lowest
            _abort = False
            _run = True
            t.start()
        End Sub
        Private Sub _main()
            While Not _abort
                While _run
                    form1.drawscene()
                End While
            End While
        End Sub
    End Class

    Public Class com_thread
        Public _str As String
        Public _wait As Boolean = False
        Public need_data As Boolean = True
        Public data_ready As Boolean = False
        Public done As Boolean = False
        Public com_error As String = ""
        Public _sending As Boolean = False
        Public abortme As Boolean = False
        Public w_thd As New Thread(AddressOf write_comm)
        Public r_thd As New Thread(AddressOf read_comm)
        Public Sub start(ByVal flag As Integer)
            If flag = _READ Then
                r_thd.IsBackground = True
                r_thd.Name = "_read_thread"
                r_thd.Start()
            End If
            If flag = _SEND Then
                w_thd.Name = "_write_thread"
                w_thd.IsBackground = True
                w_thd.Start()
            End If
        End Sub
        Public Sub read_comm()
            THRD._str = ""
            While 1

                Try
                    THRD._str = SP.ReadLine()

                Catch ex As TimeoutException

                End Try
                If THRD._str.Length > 0 Then
                    THRD._wait = True
                    THRD.data_ready = True
                Else
                    THRD._wait = False
                End If
                While THRD._wait
                    If THRD.abortme Then Exit While
                End While
                THRD.data_ready = False
                If THRD.abortme Then
                    THRD.data_ready = True
                    Thread.CurrentThread.Abort()
                End If
            End While
        End Sub
        Public Sub write_comm()
        End Sub
    End Class
    '<MTAThread()> _
    '<MTAThread()> _

    Public Class lk_up ' used for cross referencing 
        Public g_buff As Integer
        Public t_buff As Integer
    End Class

    Public Class line_d
        Public sx As Single
        Public sy As Single
        Public sz As Single
        Public ex As Single
        Public ey As Single
        Public ez As Single
        Public color_r As Single
        Public color_g As Single
        Public color_b As Single
        Public width As Single
        Public just_z As Boolean = False
        Public rapid As Boolean = False
        Public text_pnt As Integer = 0
    End Class


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
        Public ts As Single
        Public te As Single
        Public drill_depth As Single
        Public drill_mode As Integer
        Public retract As Boolean
        Public absolute As Boolean
        Public drill_start As Boolean
        Public hole_bottom As Double
        '-------
        Public text_pos As Integer
        Public line_n As Integer
        Public buff_pnt As Integer
        Public mode As Integer
        Public new_op As Boolean

        Public Sub run()
            setup_buffers_and_pointers()
            start_up()
            Form1.pg1.Maximum = pgm_lines.Length - 1
            For ln = 0 To pgm_lines.Length - 1
                Form1.pg1.Value = ln
                get_all_values(ln)
                look_for_g_codes()
                inc_lookup() ' but lookup stays at this position while
                If m = 6 Then
                    ez = 10 : sz = initial_z
                    m = 9 : mode = 28 ' force a retract to tool change height
                End If
                If ex <> sx Or ey <> sy Or ez <> sz Then 'we have an axis move?
                    check_min_max() 'Used to set the display bounds and center look at point.
                    If sx = ex And sy = ey Then ' check for Z only move.
                        just_z = True
                    Else
                        just_z = False
                    End If
                    rapid = False 'cleared as most ops do NOT rapid.. lol
                    inc_buffer() ' these 2 happen on every new move
                    ' the draw_data may increment hight.
                    line_width = 1 ' default line width
                    Select Case mode
                        Case 0
                            color = Drawing.Color.Aqua
                            rapid = True
                            line_width = 1
                            store()
                            set_lookup()
                            set_current_xyz()
                            buff_pnt += 1
                            ' inc_buffer()
                        Case 1
                            color = Drawing.Color.Blue
                            rapid = False
                            store()
                            line_width = 1
                            set_lookup()
                            set_current_xyz()
                            buff_pnt += 1
                            ' inc_buffer()
                        Case 2

                        Case 3
                        Case 43
                            drill_start = True
                            initial_z = ez
                            color = Drawing.Color.Gainsboro
                            rapid = True
                            line_width = 1
                            store()
                            set_lookup()
                            sx = ex
                            sy = ey
                            sz = ez
                            buff_pnt += 1
                            ' inc_buffer()
                        Case 80
                        Case 81
                            ' drill_start determins if we need to draw to the next hole before drawing Z
                            ' or if we need to draw Z and ignore the XY. At the start of a hole, we are all
                            ' ready over the first hole. After. we move to next and then drill the hole.
                            set_lookup() 'only once for all lines created in next drill cycles
                            If Not drill_start Then ' common to all drilling cycles
                                color = Drawing.Color.Orange
                                rapid = True
                                line_width = 1
                                te = ez : ts = sz ' gotta save the Zs and move in the inital_Z
                                ez = initial_z : sz = initial_z
                                store()
                                ez = te : sz = ts
                                buff_pnt += 1
                                inc_buffer()
                                sx = ex
                                sy = ey

                            End If

                            Select Case drill_mode
                                Case 73, 81, 82, 83, 84
                                    If drill_start Then
                                        drill_depth = ez

                                    End If
                                    If retract Then
                                        sz = initial_z
                                        color = Drawing.Color.DarkGreen
                                        line_width = 2
                                        rapid = True
                                        ez = r
                                        store()
                                        buff_pnt += 1
                                        inc_buffer()
                                    Else
                                        If drill_start Then
                                            sz = initial_z
                                            color = Drawing.Color.DarkGreen
                                            line_width = 2
                                            rapid = True
                                            ez = r
                                            store()
                                            buff_pnt += 1
                                            inc_buffer()
                                            initial_z = r
                                        End If
                                    End If
                                    drill_start = False
                                    color = Drawing.Color.Green
                                    rapid = False
                                    line_width = 2
                                    ez = drill_depth
                                    sz = r
                                    store()
                                    buff_pnt += 1
                                    '  inc_buffer()
                                    If retract Then
                                        sz = initial_z
                                        ez = initial_z
                                    Else
                                        sz = r
                                        ez = r
                                    End If
                                    sx = ex
                                    sy = ey
                                Case 83
                                Case 73
                                Case 84
                                Case 76
                            End Select
                        Case 28
                            set_lookup()
                            ez = 10.0 'extrem huh?
                            initial_z = 1000.0
                            color = Drawing.Color.Aqua
                            'inc_buffer()
                            rapid = True
                            store()
                            buff_pnt += 1
                            set_current_xyz()
                            If m = 6 Then m = 8

                    End Select

                End If
                text_pos += 1

            Next
        End Sub
        Private Sub set_current_xyz()
            sx = ex
            sy = ey
            sz = ez
        End Sub
        Private Sub start_up()
            retract = False
            drill_start = True
            mode = 0
            new_op = True
            h = 0
            ex = 0
            ey = 0
            ez = 10
            sx = 0
            sy = 0
            sz = 10
        End Sub
        Private Sub setup_buffers_and_pointers()
            pgm_lines = Form1.RTB1.Text.Split(ChrW(10))
            text_pos = 0
            buff_pnt = 0
        End Sub
        Private Sub inc_buffer()
            ReDim Preserve draw_data(buff_pnt + 1)
            draw_data(buff_pnt) = New line_d
        End Sub
        Private Sub inc_lookup()
            ReDim Preserve lookup(text_pos + 1)
            lookup(text_pos) = New lk_up
            lookup(text_pos).g_buff = -1
        End Sub
        Private Sub set_lookup()
            lookup(text_pos).t_buff = text_pos
            lookup(text_pos).g_buff = buff_pnt
        End Sub
        Private Sub store()
            draw_data(buff_pnt).color_r = color.R / 255
            draw_data(buff_pnt).color_g = color.G / 255
            draw_data(buff_pnt).color_b = color.B / 255
            draw_data(buff_pnt).width = line_width
            draw_data(buff_pnt).rapid = rapid
            draw_data(buff_pnt).just_z = just_z

            draw_data(buff_pnt).sx = sx
            draw_data(buff_pnt).sy = sy
            draw_data(buff_pnt).sz = sz

            draw_data(buff_pnt).ex = ex
            draw_data(buff_pnt).ey = ey
            draw_data(buff_pnt).ez = ez
            draw_data(buff_pnt).width = 1.0F
            draw_data(buff_pnt).text_pnt = text_pos
        End Sub
        Public Sub get_mode()
            look_for_g_codes()
        End Sub
        Private Sub look_for_g_codes()
            Dim loc As Integer = 0
            Dim out_str As String = ""
            Dim com As Integer = InStr(pgm_lines(text_pos), "(")
            If com = 0 Then com = 1000
            loc = InStr(pgm_lines(text_pos), "G")
            If loc = 0 Then Return

            While loc < pgm_lines(text_pos).Length - 1
                If loc > com Then ' make sure we dont return comment values.. :)
                    Return
                End If
                loc = InStr(loc, pgm_lines(text_pos), "G")
                If loc = 0 Then Return

                For z = loc To pgm_lines(text_pos).Length - 1
                    Dim s As String = Mid(pgm_lines(text_pos), loc + 1, 1)
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
                        mode = 28
                    Case 29
                        mode = 28
                    Case 49
                        mode = 28
                        ' cutter dia/length comp---------------
                    Case 40
                    Case 41
                    Case 42
                    Case 43
                        mode = 43 ' tool len apply so clear retract
                        retract = False
                    Case 80
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
                loc += 1
                out_str = ""
            End While
no_string:
        End Sub
        Private Sub check_min_max()
            If ex < x_min Then x_min = ex
            If ex > x_max Then x_max = ex
            If ey < y_min Then y_min = ey
            If ey > y_max Then y_max = ey
            If ez < z_min Then z_min = ez
            If ez > z_max Then z_max = ez
        End Sub

        Public Sub get_all_values(ByVal line_n As Integer)
            ex = get_val(pgm_lines(line_n), "X", ex)
            ey = get_val(pgm_lines(line_n), "Y", ey)
            ez = get_val(pgm_lines(line_n), "Z", ez)
            If mode = 2 Or mode = 3 Then ' only search if we are in ARC mode.. saves time
                i = get_val(pgm_lines(line_n), "I", i)
                j = get_val(pgm_lines(line_n), "J", j)
                k = get_val(pgm_lines(line_n), "K", k)
            End If
            q = get_val(pgm_lines(line_n), "Q", q)
            r = get_val(pgm_lines(line_n), "R", r)
            s = get_val(pgm_lines(line_n), "S", s)
            t = get_val(pgm_lines(line_n), "T", t)
            h = get_val(pgm_lines(line_n), "H", 0)
            m = get_val(pgm_lines(line_n), "M", 9)
            If h > 0 Then
            End If

        End Sub
        Public Sub get_xyz_only() 'may or may not use this sub
            ex = get_val(pgm_lines(text_pos), "X", ex)
            ey = get_val(pgm_lines(text_pos), "Y", ey)

        End Sub
        Private Function get_val(ByVal ln As String, ByVal g_code As String, ByVal old_val As Double)
            Dim loc As Integer = 0
            Dim out_str As String = ""
            Dim com As Integer = InStr(ln, "(")
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
                Return CDbl(out_str)
            Catch ex As Exception
                Return old_val
            End Try
        End Function
    End Class
End Module
