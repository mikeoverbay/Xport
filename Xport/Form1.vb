Imports System.String
Imports System.IO
Imports System.IO.Ports
Imports Microsoft.VisualBasic
Imports System.Windows.Forms.Control
Imports Tao.OpenGl
Imports Tao.Platform.Windows
Imports Tao.FreeGlut
Imports Tao.FreeGlut.Glut
Imports System.Math
Imports System.Windows.Forms
Imports System.Windows


Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Platform.Windows

Public Class Form1
    Public _grid_multi As Single
    Public _is_collapsed As Boolean = False
    Public _auto_center As Boolean = False
    Public _gs As Single = 0.0F
    Public _drawing As Boolean = False
    Public _R As Single = 0.0F
    Public pgm_lines() As String
    Public _OBJ_ID As String
    Public obj_sel As Integer
    Public drawing_flag As Boolean = False
    Public _SELECTED As Integer
    Public _buffer() As Integer
    Public pnl2_width = 105
    Public panel2_visiable As Boolean = True
    Public App_Name As String = "Xfer"
    Public path As String = ""
    Public file_pos As Integer
    Public file_size As Integer
    Public encoder As Encoding
    Public paused As Boolean = False
    Public hDC As System.IntPtr
    Public hRC As System.IntPtr
    Public Declare Sub ZeroMemory Lib "kernel32.dll" Alias "RtlZeroMemory" _
    (ByVal Destination As Gdi.PIXELFORMATDESCRIPTOR, ByVal Length As Integer)

    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" ( _
    ByVal hwnd As IntPtr, _
    ByVal wMsg As Integer, _
    ByVal wParam As IntPtr, _
    ByVal lParam As IntPtr) As Integer
    Public PB1 As New my_PB1

    Public sp_w, sp_h As Integer
    Public _plot_thread As Object
    Public sel_center_pnt As Integer = 0
    Public Nav_Ball As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler PB1.MouseDown, AddressOf PB1_MouseDown
        AddHandler PB1.MouseMove, AddressOf PB1_MouseMove
        AddHandler PB1.MouseUp, AddressOf PB1_MouseUp
        AddHandler PB1.PreviewKeyDown, AddressOf PB1_PreviewKeyDown1
        PB1.Cursor = Cursors.Cross
        PB1.Dock = DockStyle.Fill
        'PB1.BackgroundImage = My.Resources.blank_sort
        PB1.BackgroundImageLayout = ImageLayout.Stretch
        Splitter.Panel2.Controls.Add(PB1)

        'AddHandler Splitter.Panel2.MouseDown, AddressOf PB1_MouseDown
        'AddHandler Splitter.Panel2.MouseMove, AddressOf PB1_MouseMove
        'AddHandler Splitter.Panel2.MouseUp, AddressOf PB1_MouseUp
        'AddHandler Splitter.Panel2.PreviewKeyDown, AddressOf PB1_PreviewKeyDown1


        Dim port_names As String() = SerialPort.GetPortNames
        port.Items.Clear()
        For Each pt In port_names
            port.Items.Add(pt)
        Next
        disable_btns()
        status_t1.Text = ""
        status_t2.Text = ""
        OpenFileDialog1.Filter = ""
        pg1.Visible = False
        If Not SP.IsOpen Then
            'SP.BaudRate.
        End If
        'Split_Panel.Panel2Collapsed = True

        ' font_size.Text = My.Settings.tb_text_size
        RTB1.Font = New Font(Label1.Font.Name, CInt(font_size.Text), _
    RTB1.Font.Style, RTB1.Font.Unit)
        RTB1.ContextMenuStrip = Nothing
        status_t1.Text = "No Text"
        hDC = User.GetDC(PB1.Handle)
        'hDC = User.GetDC(Splitter.Panel2.Handle)

        status_t2.Text = "Load a file?"
        Me.Show()
        Me.KeyPreview = True ' so I can catch the key events for mouse behavour modification
        'AddHandler PB1.KeyPress, AddressOf PB1_PreviewKeyDown

        EnableOpenGL(hDC)

        trapUndo = True
        RichTextBox_Change()
        Timer1.Enabled = True
        draw_grid = True
        gl_lighting = True

        MenuStrip2.Items("_ambient").Visible = gl_lighting
        MenuStrip2.Items("_lable_1").Visible = gl_lighting
        Look_X_angle = -PI / 5
        Look_Y_angle = -PI / 5
        look_radius = -50.0F
        My.Settings.Reload()
        '  Split_Panel.Panel2Collapsed = Not My.Settings.p2_collapsed
        'Com_btn.Checked = My.Settings.p2_collapsed
        '_plot_thread = New plt
        '  _plot_thread.start()
        ' Me.ClientSize = My.Settings.main_client_size
        isInitiated = True
    End Sub
    Public Sub PB1_onBack_ground_Paint()
        DrawScene()
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Block_Close Then ' check if we are set to go to the tray
            If e.CloseReason = CloseReason.UserClosing Then
                e.Cancel = True
                Me.WindowState = FormWindowState.Minimized
                Me.Visible = False
                Exit Sub
            End If
        End If
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
        End If
        DisableOpenGL()
        My.Settings.Save()
        ' _plot_thread.abort()
        ' My.Settings.tb_text_size = font_size.Text
    End Sub

    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If PB1.Visible Then
            DrawScene()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        'save
    End Sub

    Private Sub LoadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem1.Click
        file_open()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _open.Click
        file_open()
    End Sub

    Private Sub SaveAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAToolStripMenuItem.Click
        'save as
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
    End Sub

    Public Sub file_open()
        draw_presistent_selection = False ' clear
        _plot_selected.Checked = False 'clear
        clear_arrays()
        OpenFileDialog1.ShowDialog(Me)
        'If Splitter.Panel2.Visible Then
        draw_all()
        'End If
    End Sub
    Public Sub clear_arrays()
        ReDim Preserve presistent(1)
        ReDim Preserve draw_data(1)
        ReDim Preserve lookup(1)
        ReDim Preserve pgm_lines(1)

    End Sub
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If e.Cancel = True Then
            Return
        End If
        Timer1.Enabled = False
        path = sender.FileName
        Try
            Me.Invalidate()
            Split_Panel.Invalidate()
            Splitter.Invalidate()
            PB1.Invalidate()
            RTB1.Invalidate()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            RTB1.Text = System.IO.File.ReadAllText(path)

        Catch ex As Exception
            MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
            Timer1.Enabled = True
            Return
        End Try
        Me.Text = App_Name + " : " + get_filename()
        status_t2.Text = get_filename() + " : Loaded"
        enable_btns()
        _save.Enabled = False
        _save_as.Enabled = True
        RTB1.ContextMenuStrip = RTB1_C
        Timer1.Enabled = True
    End Sub
    Public Sub enable_btns()
        send_btn.Enabled = True
        'recv_btn.Enabled = True
        sep_text_btn.Enabled = True
        comp_text_btn.Enabled = True
        SaveToolStripMenuItem.Enabled = True 'save
        _save_as.Enabled = True 'save as
        SaveAToolStripMenuItem.Enabled = True 'save as
        '_plot.Enabled = True
    End Sub
    Public Sub disable_btns()
        send_btn.Enabled = False
        'recv_btn.Enabled = False
        sep_text_btn.Enabled = False
        comp_text_btn.Enabled = False
        SaveToolStripMenuItem.Enabled = False 'save
        _save.Enabled = False 'save
        _save_as.Enabled = False 'save as
        SaveAToolStripMenuItem.Enabled = False 'save as
        '  _plot.Enabled = False
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        'save
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _new_file.Click
        'new file
        If _save.Enabled Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo, "Save?") = MsgBoxResult.Ok Then
                Try
                    System.IO.File.WriteAllText(path, RTB1.Text)
                Catch ex As Exception
                    MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
                    Return
                End Try
            End If
        End If
        If _save_as.Enabled Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo, "Save?") = MsgBoxResult.Ok Then
                Try
                    System.IO.File.WriteAllText(path, RTB1.Text)
                Catch ex As Exception
                    MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
                    Return
                End Try
            End If
        End If
        RTB1.Text = ""
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _save.Click
        'save
        Try
            System.IO.File.WriteAllText(path, RTB1.Text)
        Catch ex As Exception
            MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
            Return
        End Try
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _save_as.Click
        ' save as
        SaveFileDialog1.FileName = path
        If SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim temp_path As String = path
            Try
                System.IO.File.WriteAllText(path, RTB1.Text)
            Catch ex As Exception
                MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
                Return
            End Try
            Me.Text = App_Name + " : " + get_filename()
        End If
    End Sub
    Public Function get_filename()
        Dim sp() As String
        sp = path.Split("\")
        Return (sp(sp.Length - 1))
    End Function
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

    End Sub
    Private Sub send_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles send_btn.Click

        SP.PortName = Microsoft.VisualBasic.Replace(port.Text, " ", "")
        SP.BaudRate = baud.Text
        SP.Encoding = Encoding.ASCII
        SP.Parity = CInt(parity.SelectedIndex)
        SP.Handshake = CInt(handshake.SelectedIndex)
        SP.StopBits = CInt(stopbits.SelectedIndex)
        SP.DataBits = Bits.SelectedIndex + 7
        SP.Open()
        Dim x As Integer = 10
        SP.Close()
    End Sub
    Private Sub recv_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles recv_btn.Click
        Dim big_str As String = ""
        'setup port
        '--------------------------------
        SP.PortName = Microsoft.VisualBasic.Replace(port.Text, " ", "")
        SP.BaudRate = baud.Text
        SP.Encoding = Encoding.ASCII
        SP.Parity = CInt(parity.SelectedIndex)
        SP.Handshake = CInt(handshake.SelectedIndex)
        SP.StopBits = CInt(stopbits.SelectedIndex)
        SP.DataBits = Bits.SelectedIndex + 7
        SP.ReadTimeout = 100
        SP.Open()
        '------------------------------
        cancel_read_btn.Visible = True
        recv_btn.Enabled = False
        Dim THRD As New com_thread
        THRD.abortme = False
        THRD.start(_READ)
        While THRD.r_thd.IsAlive
            While Not THRD.data_ready
                Application.DoEvents()
                If Not THRD.r_thd.IsAlive Then Exit While
            End While
            Try
                If THRD._str.Length > 0 Then
                    big_str += THRD._str + vbCrLf
                    THRD._wait = False
                End If
            Catch ex As Exception
            End Try
        End While
        If big_str.Length > 0 Then
            RTB1.Text += big_str
            enable_btns()
        End If
        SP.Close()
        cancel_read_btn.Visible = False
        recv_btn.Enabled = True
    End Sub


    Private Sub sep_text_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sep_text_btn.Click
        Timer1.Enabled = False
        status_t2.Text = "Expanding Text"
        Dim buffer_string As String = ""
        Dim holding_str As String = ""
        Dim line_cnt As Integer = 1
        Dim st As String
        holding_str = RTB1.Text
        Dim txt_array As String() = holding_str.Split(ChrW(10))

        line_cnt = txt_array.Length - 1
        pg1.Visible = True
        pg1.Maximum = line_cnt

        For I = 0 To line_cnt - 1
            Application.DoEvents()
            pg1.Value = I

            '  Application.DoEvents()
            st = txt_array(I)
            st = Microsoft.VisualBasic.Replace(st, ChrW(13), "")
            If st.Length = Nothing Then GoTo no_text
            RTB1.Focus()

            If InStr(st, "(") = 0 Then
                st = Microsoft.VisualBasic.Replace(st, "X", " X")
                st = Microsoft.VisualBasic.Replace(st, "Y", " Y")
                st = Microsoft.VisualBasic.Replace(st, "Z", " Z")
                st = Microsoft.VisualBasic.Replace(st, "I", " I")
                st = Microsoft.VisualBasic.Replace(st, "J", " J")
                st = Microsoft.VisualBasic.Replace(st, "K", " K")
                st = Microsoft.VisualBasic.Replace(st, "R", " R")
                st = Microsoft.VisualBasic.Replace(st, "S", " S")
                st = Microsoft.VisualBasic.Replace(st, "T", " T")
                st = Microsoft.VisualBasic.Replace(st, "F", " F")
                st = Microsoft.VisualBasic.Replace(st, "P", " P")
                st = Microsoft.VisualBasic.Replace(st, "M", " M")
                st = Microsoft.VisualBasic.Replace(st, "G", " G")
                st = Microsoft.VisualBasic.Replace(st, "H", " H")
                st = Microsoft.VisualBasic.Replace(st, "D", " D")
                st = Microsoft.VisualBasic.Replace(st, "W", " W")
                st = Microsoft.VisualBasic.Replace(st, "E", " E")
                buffer_string += st + vbCrLf
            Else
                Dim comm_pos = InStr(st, "(")
                If InStr(st, "X") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "X", " X", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Y") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Y", " Y", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Z") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Z", " Z", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "I") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "I", " I", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "J") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "J", " J", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "K") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "K", " K", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Q") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Q", " Q", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "R") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "R", " R", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "S") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "S", " S", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "T") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "T", " T", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "M") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "M", " M", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "F") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "F", " F", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "H") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "H", " H", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "D") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "D", " D", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "P") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "P", " P", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                st = Microsoft.VisualBasic.Replace(st, "(", " (", , 1, )
                buffer_string += st + vbCrLf
            End If
no_text:
        Next
        status_t2.Text = "Done"
        pg1.Visible = False
        RTB1.Text = buffer_string
        If Not Splitter.Panel2Collapsed Then
            Timer1.Enabled = True
        End If

    End Sub
    Private Sub comp_text_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comp_text_btn.Click
        Timer1.Enabled = False
        status_t2.Text = "Compressing Text"
        RTB1.Focus()
        Dim buffer_string As String = ""
        Dim holding_str As String = ""
        Dim line_cnt As Integer = 1
        Dim st As String
        holding_str = RTB1.Text
        Dim txt_array As String() = holding_str.Split(ChrW(10))

        line_cnt = txt_array.Length - 1
        pg1.Visible = True
        pg1.Maximum = line_cnt

        For I = 0 To line_cnt - 1
            Application.DoEvents()
            pg1.Value = I

            '  Application.DoEvents()
            st = txt_array(I)
            st = Microsoft.VisualBasic.Replace(st, ChrW(13), "")
            If st.Length = Nothing Then GoTo no_text

            If InStr(st, "(") = 0 Then
                st = Microsoft.VisualBasic.Replace(st, " X", "X")
                st = Microsoft.VisualBasic.Replace(st, " Y", "Y")
                st = Microsoft.VisualBasic.Replace(st, " Z", "Z")
                st = Microsoft.VisualBasic.Replace(st, " I", "I")
                st = Microsoft.VisualBasic.Replace(st, " J", "J")
                st = Microsoft.VisualBasic.Replace(st, " K", "K")
                st = Microsoft.VisualBasic.Replace(st, " R", "R")
                st = Microsoft.VisualBasic.Replace(st, " S", "S")
                st = Microsoft.VisualBasic.Replace(st, " T", "T")
                st = Microsoft.VisualBasic.Replace(st, " F", "F")
                st = Microsoft.VisualBasic.Replace(st, " P", "P")
                st = Microsoft.VisualBasic.Replace(st, " M", "M")
                st = Microsoft.VisualBasic.Replace(st, " G", "G")
                st = Microsoft.VisualBasic.Replace(st, " H", "H")
                st = Microsoft.VisualBasic.Replace(st, " D", "D")
                st = Microsoft.VisualBasic.Replace(st, " W", "W")
                st = Microsoft.VisualBasic.Replace(st, " E", "E")
                buffer_string += st + vbCrLf
            Else
                Dim comm_pos = InStr(st, "(")
                If InStr(st, "X") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " X", " X", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Y") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Y", " Y", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Z") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Z", " Z", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "I") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " I", " I", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "J") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " J", " J", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "K") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " K", " K", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "Q") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Q", " Q", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "R") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " R", "R", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "S") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " S", "S", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "T") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " T", "T", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "M") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " M", "M", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "F") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " F", "F", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "H") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " H", "H", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "D") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " D", "D", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "P") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " P", "P", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " W", "W", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                If InStr(st, "E") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " E", "E", , 1, )
                    comm_pos = InStr(st, "(")
                End If
                st = Microsoft.VisualBasic.Replace(st, " (", "(", , 1, )
                buffer_string += st + vbCrLf
            End If
no_text:
        Next
        status_t2.Text = "Done"
        pg1.Visible = False
        RTB1.Text = buffer_string
        If Not Splitter.Panel2Collapsed Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub font_size_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles font_size.TextChanged
        Try

            RTB1.Font = New Font(Label1.Font.Name, CInt(font_size.Text), _
                RTB1.Font.Style, RTB1.Font.Unit)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub cancel_read_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_read_btn.Click

        THRD.abortme = True
    End Sub

    Private Sub Com_btn_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Com_btn.CheckStateChanged
        Split_Panel.Panel2Collapsed = Com_btn.Checked
    End Sub



    ' RTB_C context menu events ------------------------------------------------------ RTB_C context menu events
    Private Sub _undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _undo.Click
        'If RTB1.CanUndo Then
        '    RTB1.Undo()
        'End If
        Call Undo()

    End Sub
    Private Sub _redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _redo.Click
        'If RTB1.CanRedo Then
        '    RTB1.Redo()
        'End If
        Redo()
    End Sub
    Private Sub _copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _copy.Click
        If RTB1.SelectedText.Length > 0 Then
            Clipboard.SetText(RTB1.SelectedText)
        End If
    End Sub
    Private Sub _cut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _cut.Click
        If RTB1.SelectedText.Length > 0 Then
            Clipboard.SetText(RTB1.SelectedText)
            RTB1.SelectedText = ""
        End If
    End Sub
    Private Sub _paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _paste.Click
        If Clipboard.GetText.Length > 0 Then
            RTB1.Paste()
        End If
    End Sub
    Private Sub _delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _delete.Click
        If RTB1.SelectedText.Length > 0 Then
            RTB1.SelectedText = ""
        End If

    End Sub
    Private Sub _sel_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _sel_all.Click
        RTB1.SelectAll()
    End Sub
    Private Sub _center_selected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _center_selected.Click
        eye_x = draw_data(sel_center_pnt).ex
        eye_z = -draw_data(sel_center_pnt).ey
        eye_y = draw_data(sel_center_pnt).ez

    End Sub
    Private Sub orintation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles orintation.Click
        If sender.checked Then
            sender.image = My.Resources.__layout_v
            Splitter.Orientation = Orientation.Vertical
            ResizeGL()
        Else
            sender.image = My.Resources.__layout_h
            Splitter.Orientation = Orientation.Horizontal
            ResizeGL()
        End If

    End Sub
    Private Sub _rotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rotate.Click
        If sender.checkstate Then
            _R = 0.01
        Else
            _R = 0.0
        End If
    End Sub
    Private Sub _auto_center_selected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _auto_center_selected.Click
        _auto_center = sender.Checkstate

        If _auto_center Then
            _auto_center_selected.BackColor = Color.Orange
        Else
            _auto_center_selected.BackColor = Color.Transparent
        End If
    End Sub


    ' draw selected text subs -------------------------------------------------------- draw selected text subs
    Private Sub RTB1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTB1.SelectionChanged
        If Not draw_presistent_selection Then
            Return
        End If
        Dim _end As Integer
        Dim _start As Integer = RTB1.SelectionStart
        Dim start_ln As Integer = RTB1.GetLineFromCharIndex(_start)
        If RTB1.SelectionLength = 0 Then
            _end = RTB1.SelectionStart + 1
        Else
            _end = RTB1.SelectionStart + RTB1.SelectionLength
        End If
        Dim end_ln As Integer = RTB1.GetLineFromCharIndex(_end)

        Dim sp As Integer = lookup(start_ln).g_buff
        Dim ep As Integer = lookup(end_ln).g_buff
        If sp < 0 Then
            While start_ln > 0 And sp < 0
                start_ln -= 1
                sp = lookup(start_ln).g_buff
            End While
        End If
        If ep < 0 Then
            Try
                While (start_ln < lookup.Length - 2) And sp < 0
                    end_ln += 1
                    ep = lookup(end_ln).g_buff
                End While
            Catch ex As Exception
                Return
            End Try
            Dim tp = ep
            Try
                While lookup(end_ln).g_buff <> tp
                    end_ln += 1
                    ep += 1
                End While
            Catch ex As Exception
                Return
            End Try
        End If

        Dim pnt As Integer = 0
        For ln = sp To ep
            ReDim Preserve presistent(pnt + 1)
            sel_center_pnt = sp
            presistent(pnt) = New line_d
            Try
                presistent(pnt).color_r = draw_data(ln).color_r
                presistent(pnt).color_g = draw_data(ln).color_g
                presistent(pnt).color_b = draw_data(ln).color_b
                presistent(pnt).sx = draw_data(ln).sx
                presistent(pnt).sy = draw_data(ln).sy
                presistent(pnt).sz = draw_data(ln).sz
                presistent(pnt).ex = draw_data(ln).ex
                presistent(pnt).ey = draw_data(ln).ey
                presistent(pnt).ez = draw_data(ln).ez
                presistent(pnt).width = draw_data(ln).width
                presistent(pnt).just_z = draw_data(ln).just_z
                presistent(pnt).rapid = draw_data(ln).rapid
                presistent(pnt).arc = draw_data(ln).arc
                If draw_data(ln).arc > 0 Then
                    With presistent(pnt)
                        ReDim Preserve .arc_data(draw_data(ln).arc_data.Length - 1)
                        For lp = 0 To .arc_data.Length - 1
                            .arc_data(lp) = New xyz
                            .arc_data(lp) = draw_data(ln).arc_data(lp)
                        Next
                    End With
                End If
                ' presistent(pnt).arc_data = draw_data(ln).arc_data
                pnt += 1
            Catch ex As Exception
            End Try
        Next
        If _auto_center Then
            eye_x = draw_data(sel_center_pnt).ex
            eye_z = -draw_data(sel_center_pnt).ey
            eye_y = draw_data(sel_center_pnt).ez

        End If
        DrawScene()
    End Sub
    Private Sub _plot_selected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _plot_selected.Click
        draw_presistent_selection = sender.checkstate
        DrawScene()
    End Sub
    Private Sub RTB1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB1.MouseClick
        If PB1.Visible Then
            RTB1_SelectionChanged(sender, e)
        End If

    End Sub
    Private Sub RTB1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RTB1.TextChanged
        If path.Length = 0 Then
            _save_as.Enabled = True
        Else
            _save.Enabled = True 'save
        End If
        status_t1.Text = "File Size:" + CStr(RTB1.Text.Length)
        RTB1.Focus()
        RTB1.ContextMenuStrip = RTB1_C
        'undo redo functions stuff
        If Not trapUndo Then Exit Sub
        Dim newElement As New UndoElement
        Dim c%
        For c% = 1 To RedoStack.Count
            RedoStack.Remove(1)
        Next c%
        newElement.selectionstart = RTB1.SelectionStart
        newElement.TextLen = Len(RTB1.Text)
        newElement.Text = RTB1.Text
        UndoStack.Add(Item:=newElement)
        ' draw_all_no_auto_size()
    End Sub
    'Find screen item ----------------------------------------------------------------'Find screen item 
    Public Sub GetOGLPos(ByVal x As Integer, ByVal y As Integer)
        Dim viewport(4) As Integer
        Dim modelview(16) As Double
        Dim projection(16) As Double
        _SELECTED = 0
        _OBJ_ID = 0
        Dim I As UInt32
        For I = 0 To 99
            ReDim Preserve _buffer(I + 1)
            _buffer(I) = 0
        Next
        Try
            ' ViewPerspective()

            ' gl.Viewport(pb1.Location.X, pb1.Location.Y, pb1.Width, pb1.Height)
            gl.GetIntegerv(gl._VIEWPORT, viewport)

            gl.SelectBuffer(100, _buffer)
            gl.RenderMode(gl._SELECT)
            gl.InitNames()
            'gl.PushName(50)

            gl.MatrixMode(gl._PROJECTION)
            gl.LoadIdentity()
            gl.PushMatrix()
            Dim yOff As Double = viewport(3) - y
            Glu.gluPickMatrix(x, yOff, 8.0F, 8.0F, viewport)
            Glu.gluPerspective(45.0F, CSng((PB1.Width) / (PB1.Height)), 0.02F, 10000.0F)
            set_eyes()
            seek_scene()

            'gl.MatrixMode(gl._MODELVIEW)
            'gl.InitNames()
            'gl.PopName()

            gl.MatrixMode(gl._PROJECTION)
            gl.PopMatrix()
            gl.MatrixMode(gl._MODELVIEW)
            gl.Flush()

            Application.DoEvents()
            Dim hits As Integer = gl.RenderMode(gl._RENDER)

            If hits <> 0 Then

                Application.DoEvents()
                Dim j As Integer
                Dim names, ptr, minZ, ptrNames, numberOfNames As Integer

                ptr = 0
                minZ = 3200000
                For I = 0 To hits
                    names = _buffer(ptr)
                    ptr += 1
                    If _buffer(ptr) < minZ Then
                        numberOfNames = names
                        minZ = _buffer(ptr)
                        ptrNames = ptr + 2
                    End If

                    ptr += names + 2
                Next
                ptr = ptrNames
                For j = 0 To numberOfNames - 1
                    _OBJ_ID = CInt(_buffer(ptr - 1))
                    _SELECTED = CInt(_buffer(ptr))
                    ptr += 1
                Next

            End If
            If _SELECTED > 0 Then
                If Not draw_presistent_selection Then
                    RTB1_C.Items("_plot_selected").PerformClick() ' set this if it isnt on already so the graphic is highlighted
                End If

                Dim text_pnt As Integer = draw_data(_SELECTED).text_pnt
                Dim loc As Integer = RTB1.GetFirstCharIndexFromLine(text_pnt)
                Dim e_loc As Integer = RTB1.GetFirstCharIndexFromLine(text_pnt + 1)
                'RTB1.SelectionStart = loc
                'RTB1.SelectionLength = e_loc = loc
                RTB1.Select(loc, e_loc - loc - 1)
            End If
            ResizeGL()
            DrawScene()

        Catch ex As Exception
        End Try
        'Timer1.Enabled = True
        RTB1.Focus()
    End Sub
    Public Sub seek_scene()
        ' gl.Clear(gl._COLOR_BUFFER_BIT Or gl._DEPTH_BUFFER_BIT)
        ' ...................................................

        gl.Disable(gl._LINE_STIPPLE)
        Try
            Dim _end As Integer = draw_data.Length - 1
            If single_step Then _end = step_pos
            For El = 0 To _end
                If NO_Zs And draw_data(El).just_z Then GoTo skip_z
                If NO_RAPIDs And draw_data(El).rapid Then GoTo skip_z
                gl.LineWidth(draw_data(El).width)
                gl.PushName(El)
                If draw_data(El).arc > 0 Then
                    gl.Begin(gl._LINES)
                    gl.Color3f(draw_data(El).color_r, draw_data(El).color_g, draw_data(El).color_b)
                    Try
                        For crc_cnt = 0 To draw_data(El).arc_data.Length - 3
                            gl.Vertex3f(draw_data(El).arc_data(crc_cnt).x, draw_data(El).arc_data(crc_cnt).z _
                                          , -draw_data(El).arc_data(crc_cnt).y)
                            gl.Vertex3f(draw_data(El).arc_data(crc_cnt + 1).x, draw_data(El).arc_data(crc_cnt + 1).z _
                                          , -draw_data(El).arc_data(crc_cnt + 1).y)
                        Next
                    Catch ex As Exception
                    End Try
                    gl.End()
                Else
                    gl.Begin(gl._LINES)
                    gl.Color3f(draw_data(El).color_r, draw_data(El).color_g, draw_data(El).color_b)

                    gl.Vertex3f(draw_data(El).sx, draw_data(El).sz, -draw_data(El).sy)
                    gl.Vertex3f(draw_data(El).ex, draw_data(El).ez, -draw_data(El).ey)

                    gl.Disable(gl._LINE_STIPPLE)
                    gl.End()
                End If
                gl.PopName()
skip_z:
            Next
        Catch ex As Exception
            gl.Disable(gl._LINE_STIPPLE)
        End Try

        '--------------------------------------------------------------------------
        gl.Flush()
        ' Gdi.SwapBuffers(hDC)

    End Sub

    'openGL crap --------------------------------------------------------------------- OpenGL crap
    Public Sub EnableOpenGL(ByVal ghDC As System.IntPtr)
        Dim pfd As Gdi.PIXELFORMATDESCRIPTOR
        Dim PixelFormat As Integer

        ZeroMemory(pfd, Len(pfd))
        pfd.nSize = Len(pfd)
        pfd.nVersion = 1
        pfd.dwFlags = Gdi.PFD_DRAW_TO_WINDOW Or Gdi.PFD_SUPPORT_OPENGL Or Gdi.PFD_DOUBLEBUFFER Or Gdi.PFD_GENERIC_ACCELERATED
        pfd.iPixelType = Gdi.PFD_TYPE_RGBA
        pfd.cColorBits = 32
        pfd.cDepthBits = 32
        pfd.cStencilBits = 32
        pfd.iLayerType = Gdi.PFD_MAIN_PLANE

        PixelFormat = Gdi.ChoosePixelFormat(ghDC, pfd)
        If PixelFormat = 0 Then
            MessageBox.Show("Unable to retrieve pixel format")
            End
        End If
        If Not (Gdi.SetPixelFormat(ghDC, PixelFormat, pfd)) Then
            MessageBox.Show("Unable to set pixel format")
            End
        End If
        hRC = Wgl.wglCreateContext(ghDC)
        If hRC.ToInt32 = 0 Then
            MessageBox.Show("Unable to get rendering context")
            End
        End If
        If Not (Wgl.wglMakeCurrent(ghDC, hRC)) Then
            MessageBox.Show("Unable to make rendering context current")
            End
        End If

        Glut.glutInit()
        Glut.glutInitDisplayMode(GLUT_RGBA Or GLUT_DOUBLE)

        gl.ClearColor(0.0F, 0.0F, 0.0F, 1.0F)
        'lighting

        Dim specReflection() As Single = {0.8F, 0.8F, 0.8F, 1.0F}
        Dim specular() As Single = {0.7F, 0.7F, 0.7F, 1.0F}
        Dim emission() As Single = {0.0F, 0.0F, 0.0F, 1.0F}
        Dim ambient() As Single = {0.4F, 0.4F, 0.4F}
        Dim global_ambient() As Single = {0.5F, 0.5F, 0.5F, 1.0F}
        Dim diffuseLight() As Single = {0.5F, 0.5F, 0.5F, 1.0F}

        Dim mcolor() As Single = {0.5F, 0.5F, 0.7F, 1.0F}
        ' gl.Enable(gl._SMOOTH)
        'gl.ShadeModel(gl._SMOOTH)

        gl.Enable(gl._COLOR_MATERIAL)
        gl.Enable(gl._LIGHT0)
        gl.Enable(gl._LIGHTING)


        gl.LightModelfv(gl._LIGHT_MODEL_AMBIENT, global_ambient)

        gl.Lightfv(gl._LIGHT0, gl._SPECULAR, specular)

        'gl.Lightfv(gl._LIGHT0, gl._EMISSION, emission)

        gl.Lightfv(gl._LIGHT0, gl._DIFFUSE, diffuseLight)

        gl.Lightfv(gl._LIGHT0, gl._AMBIENT, ambient)

        Dim position() As Single = {0.0F, 0.0F, 10.0F, 1.0F}

        gl.Lightfv(gl._LIGHT0, gl._POSITION, position)

        'gl.Materialfv(gl._FRONT, gl._AMBIENT_AND_DIFFUSE, mcolor)
        gl.Materialfv(gl._FRONT, gl._SPECULAR, specReflection)
        gl.ColorMaterial(gl._FRONT, gl._EMISSION Or gl._AMBIENT_AND_DIFFUSE)


        gl.Materiali(gl._FRONT, gl._SHININESS, 30)

        'gl.FrontFace(gl._CCW)
        gl.ClearDepth(1.0F)
        gl.Enable(gl._DEPTH_TEST)
        'gl.LightModelfv(gl._LIGHT_MODEL_LOCAL_VIEWER, 1.0F)
        gl.Enable(gl._NORMALIZE)
        ResizeGL()
        gl.Enable(gl._BLEND)

        build_gl_list()
    End Sub
    Sub DisableOpenGL()
        Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero)
        Wgl.wglDeleteContext(hRC)
    End Sub
    Public Sub ResizeGL()
        ' gl.Viewport(PB1.Location.X, PB1.Location.Y, PB1.Width, PB1.Height)
        gl.Viewport(0, 0, sp_w, sp_h)
        gl.MatrixMode(gl._PROJECTION) ' Select The Projection Matrix
        gl.LoadIdentity() ' Reset The Projection Matrix

        ' Calculate The Aspect Ratio Of The Window
        Glu.gluPerspective(45.0F, CSng((sp_w) / (sp_h)), 0.02F, 10000.0F)

        gl.MatrixMode(gl._MODELVIEW) ' Select The Modelview Matrix
        gl.LoadIdentity() ' Reset The Modelview Matrix
        ' gl.Enable(gl._DEPTH_TEST)

        '  Glu.gluLookAt(Sin(_ROTATION) * _ZOOM, _VERTICAL, Cos(_ROTATION) * _ZOOM, _
        '0.0F, 0.0F, 0.0F, _
        '0.0F, 1.0F, 0.0F)
        'set_eyes()

    End Sub
    Public Sub set_eyes()
        cam_y = Sin(Look_Y_angle) * look_radius
        cam_x = (Sin(Look_X_angle) - (1 - Cos(Look_Y_angle)) * Sin(Look_X_angle)) * look_radius
        cam_z = (Cos(Look_X_angle) - (1 - Cos(Look_Y_angle)) * Cos(Look_X_angle)) * look_radius
        'Look_at_X = cam_x + Sin(Look_X_angle) - ((1 - Cos(Look_Y_angle)) * Sin(Look_X_angle))
        'Look_at_Y = cam_y + Sin(Look_Y_angle)
        'Look_at_Z = cam_z + Cos(Look_X_angle) - ((1 - Cos(Look_Y_angle)) * Cos(Look_X_angle))
        Glu.gluLookAt(cam_x + eye_x, cam_y + eye_y, cam_z + eye_z, eye_x, eye_y, eye_z, 0.0F, 1.0F, 0.0F)


    End Sub
    Public Sub ViewOrtho()
        gl.MatrixMode(gl._PROJECTION) ';// Select Projection
        gl.LoadIdentity() ';						// Reset The Matrix
        gl.Ortho(0, sp_w, -sp_h, 0, 0.0001, 3000.0) ';// Select Ortho Mode
        gl.MatrixMode(gl._MODELVIEW) ';// Select Modelview Matrix
        'gl.Disable(gl._DEPTH_TEST)
        'gl.DepthMask(gl._FALSE)
        gl.LoadIdentity() ';// Reset The Matrix
    End Sub
    Public Sub ViewPerspective()                            '// Set Up A Perspective View

        gl.MatrixMode(gl._PROJECTION) ';					// Select Projection
        gl.LoadIdentity() ';	
        Glu.gluPerspective(45.0F, CSng((sp_w) / (sp_h)), 0.02F, 10000.0F)

        gl.Enable(gl._DEPTH_TEST)
        gl.DepthMask(gl._TRUE)
        gl.DepthRange(0.0, 1.0)
        gl.MatrixMode(gl._MODELVIEW) ';					// Select Modelview
        gl.LoadIdentity() ';						// Reset The Matrix

    End Sub
    Private Sub build_gl_list()
        Nav_Ball = gl.GenLists(1)
        ' start list
        gl.NewList(Nav_Ball, gl._COMPILE)
        ' call the function that contains the rendering commands
        draw_nav_ball()
        'end list
        'bullet list
        gl.EndList()
    End Sub
    ' draw subs ---------------------------------------------------------------------- draw subs
    <MTAThread()>
    Public Sub DrawScene()
        If Not isInitiated Then Return
        drawing_flag = True
        ResizeGL()
        gl.Clear(gl._COLOR_BUFFER_BIT Or gl._DEPTH_BUFFER_BIT)
        ViewPerspective()
        ' switches based on user settings ...................
        If gl_lighting Then
            gl.Enable(gl._LIGHTING)
        Else
            gl.Disable(gl._LIGHTING)
        End If
        If _3D Then
            gl.Enable(gl._DEPTH_TEST)
        Else
            gl.Disable(gl._DEPTH_TEST)
        End If
        ' ...................................................
        'set light level
        Dim ambient() As Single = {ambient_level, ambient_level, ambient_level}
        gl.Lightfv(gl._LIGHT0, gl._AMBIENT, ambient)
        ' ...................................................
        set_eyes()
        gl.PushMatrix()
        gl.Scalef(1.0, 1.0, -1.0)
        If draw_grid Then ' draw the grid?
            draw_XZ_grid()
        End If
        gl.PopMatrix()
        If draw_ball Then 'shall we draw the test object?
            gl.CallList(Nav_Ball)
        End If
        gl.Enable(gl._LINE_STIPPLE)
        gl.PushMatrix()
        Try
            Dim _end As Integer = draw_data.Length - 1
            If single_step Then _end = step_pos
            For El = 0 To _end
                If draw_data(El).rapid Then
                    gl.LineStipple(1, &H7777)
                Else
                    gl.LineStipple(1, &HFFFF)
                End If
                If NO_Zs And draw_data(El).just_z Then GoTo skip_z
                If NO_RAPIDs And draw_data(El).rapid Then GoTo skip_z
                gl.LineWidth(draw_data(El).width)
                If draw_data(El).arc > 0 Then
                    gl.Begin(gl._LINES)
                    gl.Color3f(draw_data(El).color_r, draw_data(El).color_g, draw_data(El).color_b)
                    Try
                        For crc_cnt = 0 To draw_data(El).arc_data.Length - 2
                            gl.Vertex3f(draw_data(El).arc_data(crc_cnt).x, draw_data(El).arc_data(crc_cnt).z _
                                          , -draw_data(El).arc_data(crc_cnt).y)
                            gl.Vertex3f(draw_data(El).arc_data(crc_cnt + 1).x, draw_data(El).arc_data(crc_cnt + 1).z _
                                          , -draw_data(El).arc_data(crc_cnt + 1).y)
                        Next
                    Catch ex As Exception
                    End Try
                    gl.End()
                Else
                    gl.Begin(gl._LINES)
                    gl.Color3f(draw_data(El).color_r, draw_data(El).color_g, draw_data(El).color_b)

                    gl.Vertex3f(draw_data(El).sx, draw_data(El).sz, -draw_data(El).sy)
                    gl.Vertex3f(draw_data(El).ex, draw_data(El).ez, -draw_data(El).ey)

                    gl.End()
                End If
skip_z:
                gl.Disable(gl._LINE_STIPPLE)
            Next
        Catch ex As Exception
            gl.Disable(gl._LINE_STIPPLE)
        End Try
        gl.PopMatrix()
        gl.LineStipple(1, &HFFFF)

        '--------------------------------------------------------------------------
        If draw_presistent_selection Then ' if there is selected text, lets draw it!
            DrawSegment()
        End If
        '---------------------------------------------------------------------------
        If move_mod Or z_move Or eye_target Then 'draw reference lines to eye center
            gl.LineStipple(1, &HF00F)
            gl.Enable(gl._LINE_STIPPLE)
            gl.LineWidth(1)
            gl.Begin(gl._LINES)
            gl.Color3f(1.0, 0.5, 0.0)
            gl.Vertex3f(eye_x, eye_y + 100, eye_z)
            gl.Vertex3f(eye_x, eye_y - 100, eye_z)

            gl.Vertex3f(eye_x + 100, eye_y, eye_z)
            gl.Vertex3f(eye_x - 100, eye_y, eye_z)

            gl.Vertex3f(eye_x, eye_y, eye_z + 100)
            gl.Vertex3f(eye_x, eye_y, eye_z - 100)
            gl.End()
            gl.Disable(gl._LINE_STIPPLE)
        End If
        gl.LineStipple(1, &HFFFF)



        ViewOrtho()
        gl.PushMatrix()
        gl.Translatef(0.0, 0.0F, -0.01F)
        gl.Rotatef(0.0, 0.0, 0.0, 0.0)
        gl.Scalef(1.0, 1.0, 1.0)
        If draw_grid Then
            glutPrint(2, -Splitter.Panel2.Height + 25, String.Format("Grid:{0:F2}", _gs), 1.0F, 1.0F, 1.0F, 1.0F)
        End If
        draw_heading()

        gl.PopMatrix()

        ViewPerspective()

        drawing_flag = False

        gl.Flush()

        Gdi.SwapBuffers(hDC)
    End Sub
    Public Sub DrawSegment()

        'gl.Clear(gl._COLOR_BUFFER_BIT Or gl._DEPTH_BUFFER_BIT)
        ' draw_shape()

        gl.Enable(gl._LINE_STIPPLE)
        Try
            For El = 0 To presistent.Length - 2
                If draw_data(El).rapid Then
                    gl.LineStipple(1, &H7777)
                Else
                    gl.LineStipple(1, &HFFFF)
                End If
                gl.LineWidth(2)
                gl.Begin(gl._LINES)
                If presistent(El).arc > 0 Then
                    gl.Begin(gl._LINES)
                    gl.Color3f(1.0, 1.0, 1.0)
                    Try
                        For crc_cnt = 0 To presistent(El).arc_data.Length - 2
                            gl.Vertex3f(presistent(El).arc_data(crc_cnt).x, presistent(El).arc_data(crc_cnt).z _
                                          , -presistent(El).arc_data(crc_cnt).y)
                            gl.Vertex3f(presistent(El).arc_data(crc_cnt + 1).x, presistent(El).arc_data(crc_cnt + 1).z _
                                          , -presistent(El).arc_data(crc_cnt + 1).y)
                        Next
                    Catch ex As Exception
                    End Try
                    gl.End()
                Else
                    gl.Begin(gl._LINES)
                    gl.Color3f(1.0, 1.0, 1.0)

                    gl.Vertex3f(presistent(El).sx, presistent(El).sz, -presistent(El).sy)
                    gl.Vertex3f(presistent(El).ex, presistent(El).ez, -presistent(El).ey)

                    gl.End()
                End If
            Next
        Catch ex As Exception
            gl.Disable(gl._LINE_STIPPLE)
        End Try
        gl.Disable(gl._LINE_STIPPLE)
        gl.LineStipple(1, &HFFFF)


    End Sub
    Public Sub draw_heading()
        gl.PushMatrix()
        gl.Enable(gl._DEPTH_TEST)
        Dim degree As Single = (PI * 2) / 360
        gl.Scalef(0.75, 0.75, 0.75)
        gl.Translatef(60.0, -60.0, -50.0)
        gl.Rotatef((Look_X_angle / degree) + 180, 0.0F, -1.0F, 0.0F)
        gl.Rotatef((Look_Y_angle / degree), Cos(Look_X_angle) _
                     , -0.0F, -Sin(Look_X_angle)) '- Cos(Look_X_angle))
        ' gl.Scalef(-1.0F, 1.0, 1.0)

        gl.CallList(Nav_Ball)
        gl.Disable(gl._DEPTH_TEST)
        gl.PopMatrix()
        'Dim sc As Single = 100
        'Dim r As Single = 60.0
        'Dim r2 As Single = 50.0F
        'Dim xo As Single = -12
        'Dim yo As Single = -5
        'Dim sx, sy As Single
        'Dim halfPI As Single = PI / 2
        'Dim dv As Single = PI / 60
        'Dim radi As Single = 0.0F
        'gl.Scalef(1.0, 1.0, 1.0)
        'gl.Disable(gl._LIGHTING) 'shut this off so it dont get messed up by the lights
        'sx = (Cos(-Look_X_angle + halfPI) * r) + sc
        'sy = (Sin(-Look_X_angle + halfPI) * r) + sc
        'Dim lx As Single = (Cos(-Look_X_angle - dv + halfPI) * r2) + sc
        'Dim rx As Single = (Cos(-Look_X_angle + dv + halfPI) * r2) + sc
        'Dim ly As Single = (Sin(-Look_X_angle - dv + halfPI) * r2) + sc
        'Dim ry As Single = (Sin(-Look_X_angle + dv + halfPI) * r2) + sc

        'gl.Begin(gl._LINES)
        'gl.Color3f(1.0, 1.0, 0.0)
        'gl.Vertex3f(sc, -sc, -0.01)
        'gl.Vertex3f(sx, -sy, -0.01)

        'gl.Vertex3f(sx, -sy, -0.01)
        'gl.Vertex3f(lx, -ly, -0.01)

        'gl.Vertex3f(sx, -sy, -0.01)
        'gl.Vertex3f(rx, -ry, -0.01)

        'gl.End()
        'r = 80.0
        'glutPrint((Cos(radi) * r) + sc + xo, (Sin(radi) * r) - sc + yo, "X +", 1.0, 1.0, 0.0, 1.0)
        'radi += halfPI
        'glutPrint((Cos(radi) * r) + sc + xo, (Sin(radi) * r) - sc + yo, "Y +", 1.0, 0.0, 0.0, 1.0)
        'radi += halfPI
        'glutPrint((Cos(radi) * r) + sc + xo, (Sin(radi) * r) - sc + yo, "X -", 0.0, 1.0, 0.0, 1.0)
        'radi += halfPI
        'glutPrint((Cos(radi) * r) + sc + xo, (Sin(radi) * r) - sc + yo, "Y -", 0.0, 0.0, 1.0, 1.0)
        'radi += halfPI
        gl.Enable(gl._LIGHTING) ' turn lighting back on
        If screen_prompts Then
            If show_left And (Not move_mod) Then
                glutPrint(210, -18, "Left/Right = Rotate around Z", 0.0, 1.0, 0.0, 1.0)
                glutPrint(210, -38, "Up/Down = Pivot Around Center", 0.0, 1.0, 0.0, 1.0)
            End If
            If show_left And move_mod Then
                glutPrint(210, -18, "Left/Right = Move on X", 0.0, 1.0, 0.0, 1.0)
                glutPrint(210, -38, "Up/Down = Move on Z", 0.0, 1.0, 0.0, 1.0)
            End If
            If show_right Then
                glutPrint(210, -18, "Up/Down = Zoom", 0.0, 1.0, 0.0, 1.0)
            End If
        End If

    End Sub
    Public Sub glutPrint(ByVal x As Single, ByVal y As Single,
ByVal text As String, ByVal r As Single, ByVal g As Single, ByVal b As Single, ByVal a As Single)

        If text.Length = 0 Then Exit Sub
        Dim blending As Boolean = False
        If gl.IsEnabled(gl._BLEND) Then blending = True
        gl.Enable(gl._BLEND)
        gl.Color3f(r, g, b)
        gl.RasterPos2f(x, y)
        For Each I In text

            Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, Asc(I))

        Next
        If Not blending Then gl.Disable(gl._BLEND)
    End Sub
    Public Sub draw_XZ_grid()
        Dim p As Single
        If look_radius < -50 Then
            p = 10.0F
        End If
        If look_radius >= -50 And look_radius < -10 Then
            p = 5.0
        End If
        If look_radius >= -10 And look_radius < -5.0 Then
            p = 1.0F
        End If
        If look_radius >= -5.0 Then
            p = 0.25F
        End If
        _gs = p
        gl.LineWidth(1)
        gl.Begin(gl._LINES)
        gl.Color3f(0.16 * _grid_multi, 0.17 * _grid_multi, 0.25 * _grid_multi)
        For z As Single = p To p * 100 Step p
            gl.Vertex3f(-p * 100, 0.0F, z)
            gl.Vertex3f(p * 100, 0.0F, z)
        Next
        For z As Single = -p * 100 To -p Step p
            gl.Vertex3f(-p * 100, 0.0F, z)
            gl.Vertex3f(p * 100, 0.0F, z)
        Next
        For x As Single = p To p * 100 Step p
            gl.Vertex3f(x, 0.0F, p * 100)
            gl.Vertex3f(x, 0.0F, -p * 100)
        Next
        For x As Single = -p * 100 To -p Step p
            gl.Vertex3f(x, 0.0F, p * 100)
            gl.Vertex3f(x, 0.0F, -p * 100)
        Next
        gl.End()
        gl.LineWidth(1)
        gl.Begin(gl._LINES)
        gl.Color3f(0.6F, 0.6F, 0.6F)
        gl.Vertex3f(p, 0.0F, 0.0F)
        gl.Vertex3f(-p, 0.0F, 0.0F)
        gl.Vertex3f(0.0F, 0.0F, p)
        gl.Vertex3f(0.0F, 0.0F, -p)
        gl.End()
        'begin axis markers
        ' red is z+
        ' green is x-
        'blue is z-
        ' yellow x+
        gl.LineWidth(1)

        gl.Begin(gl._LINES)
        'z+ red
        gl.Color3f(1.0F, 0.0F, 0.0F)
        gl.Vertex3f(0.0F, 0.0F, p)
        gl.Vertex3f(0.0F, 0.0F, p * 100.0F)
        'z- blue
        gl.Color3f(0.0F, 0.0F, 1.0F)
        gl.Vertex3f(0.0F, 0.0F, -p)
        gl.Vertex3f(0.0F, 0.0F, -p * 100.0F)
        'x+ yellow
        gl.Color3f(1.0F, 1.0F, 0.0F)
        gl.Vertex3f(p, 0.0F, 0.0F)
        gl.Vertex3f(p * 100.0F, 0.0F, 0.0F)
        'x- green
        gl.Color3f(0.0F, 1.0F, 0.0F)
        gl.Vertex3f(-p, 0.0F, 0.0F)
        gl.Vertex3f(-p * 100.0F, 0.0F, 0.0F)
        '---------
        gl.End()



    End Sub

    'Mouse events -------------------------------------------------------------------- Mouse events
    Private Sub PB1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Forms.MouseButtons.Middle Then
            Timer1.Enabled = False
            While drawing_flag
                Application.DoEvents()
            End While
            GetOGLPos(e.X, e.Y)
        End If
        PB1.Focus()
        If e.Button = Forms.MouseButtons.Right Then
            'Timer1.Enabled = False
            show_right = True
            move_cam_z = True
            mouse.X = e.X
            mouse.Y = e.Y
        End If
        If e.Button = Forms.MouseButtons.Left Then
            'Timer1.Enabled = False
            show_left = True
            'M_MOVE = False
            M_DOWN = True
            mouse.X = e.X
            mouse.Y = e.Y
        End If

    End Sub
    Private Sub PB1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim dead As Integer = 5
        Dim t As Single
        Dim M_Speed As Single = 0.8
        Dim ms As Single = 0.2F * look_radius ' distance away changes speed.. THIS WORKS WELL!
        If M_DOWN Then
            If e.X > (mouse.X + dead) Then
                If e.X - mouse.X > 100 Then t = (1.0F * M_Speed)
            Else : t = CSng(Sin((e.X - mouse.X) / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x -= ((t * ms) * (Cos(Look_X_angle)))
                        eye_z -= ((t * ms) * (-Sin(Look_X_angle)))
                    Else
                        Look_X_angle -= t
                    End If
                    If Look_X_angle > (2 * PI) Then Look_X_angle -= (2 * PI)
                    mouse.X = e.X
                End If
            End If
            If e.X < (mouse.X - dead) Then
                If mouse.X - e.X > 100 Then t = (M_Speed)
            Else : t = CSng(Sin((mouse.X - e.X) / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x += ((t * ms) * (Cos(Look_X_angle)))
                        eye_z += ((t * ms) * (-Sin(Look_X_angle)))
                    Else
                        Look_X_angle += t
                    End If
                    If Look_X_angle < 0 Then Look_X_angle += (2 * PI)
                    mouse.X = e.X
                End If
            End If
            ' ------- Y moves ----------------------------------
            If e.Y > (mouse.Y + dead) Then
                If e.Y - mouse.Y > 100 Then t = (M_Speed)
            Else : t = CSng(Sin((e.Y - mouse.Y) / 100)) * M_Speed
                If z_move Then
                    eye_y -= (t * ms)
                Else
                    If move_mod Then ' check for modifying flag
                        eye_z -= ((t * ms) * (Cos(Look_X_angle)))
                        eye_x -= ((t * ms) * (Sin(Look_X_angle)))
                    Else
                        Look_Y_angle -= t
                    End If
                    If Look_Y_angle < -1.3 Then Look_Y_angle = -1.3
                End If
                mouse.Y = e.Y
            End If
            If e.Y < (mouse.Y - dead) Then
                If mouse.Y - e.Y > 100 Then t = (M_Speed)
            Else : t = CSng(Sin((mouse.Y - e.Y) / 100)) * M_Speed
                If z_move Then
                    eye_y += (t * ms)
                Else
                    If move_mod Then ' check for modifying flag
                        eye_z += ((t * ms) * (Cos(Look_X_angle)))
                        eye_x += ((t * ms) * (Sin(Look_X_angle)))
                    Else
                        Look_Y_angle += t
                    End If
                    If Look_Y_angle > 1.3 Then Look_Y_angle = 1.3
                End If
                mouse.Y = e.Y
            End If
            DrawScene()
        End If
        If move_cam_z Then
            If e.Y > (mouse.Y + dead) Then
                If e.Y - mouse.Y > 100 Then t = (10)
            Else : t = CSng(Sin((e.Y - mouse.Y) / 100)) * 12
                look_radius += (t * (look_radius * 0.2)) ' zoom is factored in to look radius
                mouse.Y = e.Y
            End If
            If e.Y < (mouse.Y - dead) Then
                If mouse.Y - e.Y > 100 Then t = (10)
            Else : t = CSng(Sin((mouse.Y - e.Y) / 100)) * 12
                look_radius -= (t * (look_radius * 0.2)) ' zoom is factored in to look radius
                If look_radius > -0.5 Then look_radius = -0.5
                mouse.Y = e.Y
            End If
            If look_radius > -0.5 Then look_radius = -0.5
            DrawScene()


        End If
    End Sub
    Private Sub PB1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        show_right = False
        show_left = False
        If e.Button = Forms.MouseButtons.Right Then
            move_cam_z = False
        End If
        If e.Button = Forms.MouseButtons.Left Then
            M_DOWN = False
            M_MOVE = True
        End If
        'Timer1.Enabled = True
        DrawScene()
        RTB1.Focus()

    End Sub

    Private Sub Splitter_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Splitter.ClientSizeChanged
        sp_w = Splitter.Panel2.ClientSize.Width
        sp_h = Splitter.Panel2.ClientSize.Height
        ResizeGL()
    End Sub

    Private Sub Splitter_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Splitter.Paint
        DrawScene()
    End Sub

    Private Sub Splitter_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Splitter.SplitterMoved
        sp_w = Splitter.Panel2.ClientSize.Width
        sp_h = Splitter.Panel2.ClientSize.Height
        PB1.Height = sp_h - MenuStrip2.Height
        ResizeGL()
        RTB1.Focus()

    End Sub
    ' RTB1 Menu subs ----------------------------------------------------------------- RTB1 Menu subs 
    Private Sub _plot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _plot.Click
        If Splitter.Panel2Collapsed Then
            Splitter.Panel2Collapsed = False
            Timer1.Enabled = True
            ResizeGL()
            '    Splitter.Panel2.Visible = False
        Else
            Splitter.Panel2Collapsed = True
            Timer1.Enabled = False
            '    Splitter.Panel2.Visible = True
            '    RTB1_C.Items(11).Visible = True
            '    If RTB1.TextLength > 0 Then
            '        draw_all()
            '    End If
        End If
    End Sub


    Public Function get_val(ByVal ln As String, ByVal g_code As String, ByVal old_val As Double)
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

    Private Sub _play_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _play.Click
        single_step = False
        first_step = True
        draw_all()
    End Sub
    Public Sub draw_all()
        Dim CORE As New op_core

        x_max = -10000
        x_min = 10000
        y_max = -10000
        y_min = 10000
        z_max = -10000
        z_min = 10000

        status_t2.Text = "Building Graphics"
        pg1.Visible = True
        CORE.run()
        status_t2.Text = "Total Lines Drawn: " + CStr(draw_data.Length - 1)
        cam_x = 0
        cam_y = 0
        cam_z = 6
        Look_at_X = 0
        Look_at_Y = 0
        Look_at_Z = 0
        look_radius = -20.0
        Look_X_angle = -PI

        eye_x = (x_max + x_min) / 2
        eye_z = (y_max + y_min) / 2 ' y / z swaped for opengl viewing
        eye_y = (z_max + z_min) / 2
        'look_radius = -Sqrt((eye_x * eye_x) + (eye_y * eye_y) + (eye_z * eye_z)) * 20
        look_radius = 0 - ((x_max - x_min) + (y_max - y_min))
        pg1.Visible = False
        DrawScene()
    End Sub
    Public Sub draw_all_no_auto_size()
        Dim CORE As New op_core

        x_max = -10000
        x_min = 10000
        y_max = -10000
        y_min = 10000
        z_max = -10000
        z_min = 10000

        status_t2.Text = "Building Graphics"
        pg1.Visible = True
        CORE.run()
        status_t2.Text = "Tot Lines Drawn: " + CStr(draw_data.Length - 1)
        cam_x = 0
        cam_y = 0
        cam_z = 6
        Look_at_X = 0
        Look_at_Y = 0
        Look_at_Z = 0
        look_radius = -20.0
        Look_X_angle = 0

        eye_x = (x_max + x_min) / 2
        eye_z = (y_max + y_min) / 2 ' y / z swaped for opengl viewing
        eye_y = (z_max + z_min) / 2
        'look_radius = -Sqrt((eye_x * eye_x) + (eye_y * eye_y) + (eye_z * eye_z)) * 20
        look_radius = 0 - ((x_max - x_min) + (y_max - y_min))
        pg1.Visible = False
        DrawScene()
    End Sub
    Public Sub draw_all_()
        status_t2.Text = "Building Graphics"
        pgm_lines = RTB1.Text.Split(ChrW(10))
        Dim x, y, Th, z, q, r, i, j, k, p As Double
        Dim t, m, g, s As Integer
        Dim ox, oy, oz As Double
        Dim initial_Z As Double = 0
        Dim ln As Integer
        Dim line_n As Integer
        Dim retract As Boolean = False
        Dim op_start As Boolean = True
        'start with cleared values
        x = 0 : ox = 0
        y = 0 : oy = 0
        z = 0 : oz = 0
        g = 0
        m = 0
        q = 0
        r = 0
        s = 0
        t = 0
        p = 0
        i = 0
        j = 0
        k = 0
        x_max = -10000
        x_min = 10000
        y_max = -10000
        y_min = 10000
        z_max = -10000
        z_min = 10000

        ln = pgm_lines.Length - 1
        Dim bf_pnt As Integer = 0
        Dim path_mode As Integer = 0
        ReDim Preserve draw_data(bf_pnt + 1) ' need a starting place
        ReDim Preserve lookup(ln + 1)
        For i = 0 To ln
            lookup(i) = New lk_up ' initilize
        Next
        pg1.Visible = True
        pg1.Maximum = ln
        For line_n = 0 To ln
            lookup(line_n).g_buff = -1
            lookup(line_n).t_buff = line_n
            pg1.Value = line_n
            'ok.. lets get the path_mode
            If InStr(pgm_lines(line_n), "G0") > 0 Then
                path_mode = 0
            End If
            If InStr(pgm_lines(line_n), "G00") > 0 Then
                path_mode = 0
            End If
            If InStr(pgm_lines(line_n), "G1") > 0 Then
                path_mode = 1
            End If
            If InStr(pgm_lines(line_n), "G01") > 0 Then
                path_mode = 1
            End If
            ' get coords
            x = get_val(pgm_lines(line_n), "X", x)
            y = get_val(pgm_lines(line_n), "Y", y)
            z = get_val(pgm_lines(line_n), "Z", z)
            r = get_val(pgm_lines(line_n), "R", r)
            initial_Z = 0F
            'we need to find the inital Z for the G98/G99 modes

            If x < x_min Then x_min = x
            If x > x_max Then x_max = x
            If y < y_min Then y_min = y
            If y > y_max Then y_max = y
            If z < z_min Then z_min = z
            If z > z_max Then z_max = z


            'for now, just texting the functions

            'we need ot make a new postion in the arary and load the values
            If ox <> x Or oy <> y Or oz <> z Then
                lookup(line_n).g_buff = bf_pnt ' save for cross reference '

                ReDim Preserve draw_data(bf_pnt + 1)
                draw_data(bf_pnt) = New line_d
                Application.DoEvents()

                draw_data(bf_pnt).width = 1.0F 'default line width
                If ox = x And oy = y Then
                    draw_data(bf_pnt).just_z = True
                End If
                draw_data(bf_pnt).rapid = False ' preset this before select testing...
                Select Case path_mode
                    Case 0
                        draw_data(bf_pnt).color_r = 0.0F
                        draw_data(bf_pnt).color_g = 0.9F
                        draw_data(bf_pnt).color_b = 0.9F ' Blue
                        draw_data(bf_pnt).width = 1.0F
                        draw_data(bf_pnt).rapid = True
                        draw_data(bf_pnt).sx = x
                        draw_data(bf_pnt).sy = z
                        draw_data(bf_pnt).sz = y

                        draw_data(bf_pnt).ex = ox
                        draw_data(bf_pnt).ey = oz
                        draw_data(bf_pnt).ez = oy
                        draw_data(bf_pnt).width = 1.0F
                        bf_pnt += 1
                    Case 1
                        draw_data(bf_pnt).color_r = 0.0F
                        draw_data(bf_pnt).color_g = 0.0F
                        draw_data(bf_pnt).color_b = 0.9F ' Blue
                        draw_data(bf_pnt).width = 2.0F

                        draw_data(bf_pnt).sx = x
                        draw_data(bf_pnt).sy = z
                        draw_data(bf_pnt).sz = y

                        draw_data(bf_pnt).ex = ox
                        draw_data(bf_pnt).ey = oz
                        draw_data(bf_pnt).ez = oy
                        draw_data(bf_pnt).width = 2.0F
                        bf_pnt += 1



                End Select

                ox = x
                oy = y
                oz = z
            End If

        Next ' end poter loop lime_n

        status_t2.Text = "Tot Lines: " + CStr(ln)
        cam_x = 0
        cam_y = 0
        cam_z = 6
        Look_at_X = 0
        Look_at_Y = 0
        Look_at_Z = 0
        look_radius = -20.0
        Look_X_angle = 0

        eye_x = (x_max + x_min) / 2
        eye_z = (y_max + y_min) / 2 ' y / z swaped for opengl viewing
        eye_y = (z_max + z_min) / 2
        look_radius = -Sqrt((eye_x * eye_x) + (eye_y * eye_y) + (eye_z * eye_z)) * 20
        pg1.Visible = False
        DrawScene()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        DrawScene()
    End Sub
    ' form resize ------------------------------------------------------------------- form resize subs
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Split_Panel.Panel2Collapsed = Com_btn.Checked
    End Sub
    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If isInitiated And Me.WindowState <> FormWindowState.Minimized And Me.WindowState <> FormWindowState.Maximized Then
            form_height = Me.Height
            form_width = Me.Width
            form_client_size = Me.ClientSize
            My.Settings.main_client_size = Me.ClientSize
        End If
        Split_Panel.Panel2Collapsed = Com_btn.Checked
    End Sub
    Private Sub Form1_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        If isInitiated And Me.WindowState = FormWindowState.Minimized Or Me.WindowState = FormWindowState.Maximized Then
            Me.Height = form_height
            Me.Width = form_width
            Me.ClientSize = form_client_size
        End If
        Split_Panel.Panel2Collapsed = Com_btn.Checked
    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

        'MenuStrip2.Width = PB1.Width
        'RTB1.Width = Split_Panel.Panel1.Width - PB1.Width - 10


        If isInitiated And Me.WindowState <> FormWindowState.Minimized And Me.WindowState <> FormWindowState.Maximized Then
            form_height = Me.Height
            form_width = Me.Width
            form_client_size = Me.ClientSize
            My.Settings.main_client_size = Me.ClientSize
        End If
        Split_Panel.Panel2Collapsed = Com_btn.Checked
        sp_w = Splitter.Panel2.ClientSize.Width
        sp_h = Splitter.Panel2.ClientSize.Height

        DrawScene()

    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Split_Panel.Panel2Collapsed = Com_btn.Checked
    End Sub

    ' key functions ----------------------------------------------------------------- key functions
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Shift Then
            move_mod = True
        End If
        If e.KeyCode = Keys.Control Then
            z_move = True
        End If
    End Sub
    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If move_mod Then
            move_mod = False
            If Not _show_eye_center.Checked Then
                _show_eye_center.BackColor = Color.Transparent
            End If
            eye_target = _show_eye_center.Checked
            DrawScene()
        End If
        If z_move Then
            z_move = False
            If Not _show_eye_center.Checked Then
                _show_eye_center.BackColor = Color.Transparent
            End If
            eye_target = _show_eye_center.Checked
            DrawScene()
        End If
    End Sub
    Private Sub RTB1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RTB1.KeyPress
        Dim c As Char = e.KeyChar
        e.KeyChar = Char.ToUpper(c)

    End Sub
    Private Sub PB1_PreviewKeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        If e.KeyCode = 16 Then
            move_mod = True ' SHIFT KET
            _show_eye_center.BackColor = Color.Coral
            eye_target = True
        End If
        If e.KeyCode = 17 Then
            z_move = True ' CTRL KEY
            _show_eye_center.BackColor = Color.Coral
            eye_target = True
        End If
        ' DrawScene()
    End Sub

    ' PB1 menu subs ----------------------------------------------------------------- PB1 menu subs
    Private Sub HideZOnlyMovesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideZOnlyMovesToolStripMenuItem.Click
        NO_Zs = sender.checkstate
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HideRapidMovesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideRapidMovesToolStripMenuItem.Click
        NO_RAPIDs = sender.checkstate
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DrawGridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawGridToolStripMenuItem.Click
        draw_grid = sender.checkstate
        _grid_brightness.Visible = draw_grid
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DDepthRenderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _gl_depth_test.Click
        _3D = sender.checkstate
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GLLightingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lighting.Click
        gl_lighting = sender.checkstate

        MenuStrip2.Items("_ambient").Visible = gl_lighting
        MenuStrip2.Items("_lable_1").Visible = gl_lighting
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DrawTestObjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawTestObjectToolStripMenuItem.Click
        draw_ball = sender.checkstate
        DrawScene()
    End Sub
    Private Sub ScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _prompts.Click
        screen_prompts = sender.checkstate
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub _ambient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ambient.TextChanged
        ambient_level = CSng(_ambient.Text)
        Try
            DrawScene()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _rewind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rewind.Click
        first_step = True
        step_pos = 0
        single_step = True
        DrawScene()
    End Sub
    Private Sub _foward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _foward.Click
        If first_step Then
            single_step = True
            step_pos = 1
            first_step = False
            DrawScene()
        Else
            step_pos += 1
            DrawScene()
        End If
    End Sub

    Private Sub _show_eye_center_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _show_eye_center.Click
        eye_target = sender.checkstate
        If eye_target Then
            _show_eye_center.BackColor = Color.Orange
        Else
            _show_eye_center.BackColor = Color.Transparent
        End If
        DrawScene()
    End Sub
    Private Sub _grid_brightness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _grid_brightness.Click

    End Sub
    Private Sub _grid_brightness_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _grid_brightness.TextChanged
        _grid_multi = CSng(_grid_brightness.Text)
    End Sub


    'RTF Form's Code
    '------------------------------------------
    Public Sub Redo()
        Dim chg$
        Dim DeleteFlag As Boolean
        Dim objElement As Object
        If RedoStack.Count > 0 And trapUndo Then
            trapUndo = False
            DeleteFlag = RedoStack(RedoStack.Count).TextLen < Len(RTB1.Text)
            If DeleteFlag Then
                objElement = RedoStack(RedoStack.Count)
                RTB1.SelectionStart = objElement.selectionstart
                RTB1.SelectionLength = Len(RTB1.Text) - objElement.TextLen
                RTB1.SelectedText = ""
            Else
                objElement = RedoStack(RedoStack.Count)
                chg$ = Change(RTB1.Text, objElement.Text, objElement.selectionstart + 1)
                RTB1.SelectionStart = objElement.selectionstart - Len(chg$)
                RTB1.SelectionLength = 0
                RTB1.SelectedText = chg$
                RTB1.SelectionStart = objElement.selectionstart - Len(chg$)
                If Len(chg$) > 1 And chg$ <> vbCrLf Then
                    RTB1.SelectionLength = Len(chg$)
                Else
                    RTB1.SelectionStart = RTB1.SelectionStart + Len(chg$)
                End If
            End If
            UndoStack.Add(Item:=objElement)
            RedoStack.Remove(RedoStack.Count)
        End If
        trapUndo = True
        RTB1.Focus()
    End Sub
    Public Sub Undo()
        Dim chg$, x&
        Dim DeleteFlag As Boolean
        Dim objElement As Object, objElement2 As Object
        If UndoStack.Count > 1 And trapUndo Then
            trapUndo = False
            DeleteFlag = UndoStack(UndoStack.Count - 1).TextLen < UndoStack(UndoStack.Count).TextLen
            If DeleteFlag Then
                x& = SendMessage(RTB1.Handle, Xport.RichEditControl.EM_HIDESELECTION, 1&, 1&)
                objElement = UndoStack(UndoStack.Count)
                objElement2 = UndoStack(UndoStack.Count - 1)
                RTB1.SelectionStart = objElement.selectionstart - (objElement.TextLen - objElement2.TextLen)
                RTB1.SelectionLength = objElement.TextLen - objElement2.TextLen
                RTB1.SelectedText = ""
                x& = SendMessage(RTB1.Handle, Xport.RichEditControl.EM_HIDESELECTION, 0&, 0&)
            Else
                objElement = UndoStack(UndoStack.Count - 1)
                objElement2 = UndoStack(UndoStack.Count)
                chg$ = Change(objElement.Text, objElement2.Text, _
                    objElement2.selectionstart + 1 + Abs(Len(objElement.Text) - Len(objElement2.Text)))
                RTB1.SelectionStart = objElement2.selectionstart
                RTB1.SelectionLength = 0
                RTB1.SelectedText = chg$
                RTB1.SelectionStart = objElement2.selectionstart
                If Len(chg$) > 1 And chg$ <> vbCrLf Then
                    RTB1.SelectionLength = Len(chg$)
                Else
                    RTB1.SelectionStart = RTB1.SelectionStart + Len(chg$)
                End If
            End If
            RedoStack.Add(Item:=UndoStack(UndoStack.Count))
            UndoStack.Remove(UndoStack.Count)
        End If
        trapUndo = True
        RTB1.Focus()
    End Sub
    Public Function Change(ByVal lParam1 As String, ByVal lParam2 As String, ByVal startSearch As Long) As String
        Dim tempParam$
        Dim d&
        If Len(lParam1) > Len(lParam2) Then 'swap
            tempParam$ = lParam1
            lParam1 = lParam2
            lParam2 = tempParam$
        End If
        d& = Len(lParam2) - Len(lParam1)
        Change = Mid(lParam2, startSearch - d&, d&)
    End Function
    Private Sub RichTextBox_Change()
        If Not trapUndo Then Exit Sub

        Dim newElement As New UndoElement
        Dim c%


        For c% = 1 To RedoStack.Count
            RedoStack.Remove(1)
        Next c%


        newElement.selectionstart = RTB1.SelectionStart
        newElement.TextLen = Len(RTB1.Text)
        newElement.Text = RTB1.Text


        UndoStack.Add(Item:=newElement)

    End Sub
    '-----------------------------------------



    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        ' Splitter.ResumeLayout()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If _drawing Then
            Return
        End If
        _drawing = True
        DrawScene()
        If _R > 0 Then
            Look_X_angle += _R
            If Look_X_angle > 2 * PI Then
                Look_X_angle = -2 * PI
            End If
        End If
        _drawing = False

    End Sub


    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        '   Split_Panel.Panel2Collapsed = Not Com_btn.CheckState
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Split_Panel.SuspendLayout()
    End Sub




End Class
