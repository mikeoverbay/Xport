
Imports System.Math
Imports System.Runtime.InteropServices
Imports System.Windows
Imports CodeChop.frmControl
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports Tao.FreeGlut.Glut

Public Class frmMain
    '----- demo variables
    Public DEMO As Boolean = False

    Public max_lines_reload As Integer = 1000
    Public max_lines As Integer = 0

    '--------------------------------
    'colors to text text highlighting

    Public t_stopwatch As New Stopwatch
    Const _front = 241
    Const _back = 242
    Const _top = 243
    Const _bottom = 244
    Const _right = 245
    Const _left = 246
    Public codechop_loaded As Boolean = False
    Public sub_start_line As Integer = 1000000
    Public tb_ec As New Point
    Public total_lines_drawn As UInteger = 0
    Public draw_points As Boolean = False
    Public selected_letter As Byte
    Public over_nav_ball As Boolean = False
    Public info_str As String = ""
    Public RTB1 As New RTB1_
    Public _grid_multi As Single
    Public _is_collapsed As Boolean = False
    Public _auto_center As Boolean = False
    Public _gs As Single = 0.0F
    Public _drawing As Boolean = False
    Public _R As Single = 0.0F
    Public _OBJ_ID As Integer
    Public obj_sel As Integer
    Public drawing_flag As Boolean = False
    Public _SELECTED As ULong
    Public _buffer() As Integer
    Public pnl2_width As Integer = 105
    Public panel2_visiable As Boolean = True
    Public App_Name As String = "CodeChop"
    Public path As String = ""
    Public new_path As String = ""
    Public file_pos As Integer
    Public file_size As Integer
    Public encoder As Encoding
    Public paused As Boolean = False
    Public hDC As System.IntPtr
    Public hRC As System.IntPtr
    Public zoom_hDC As System.IntPtr
    Public zoom_hRC As System.IntPtr
    Public current_hDC As System.IntPtr
    Public Declare Sub ZeroMemory Lib "kernel32.dll" Alias "RtlZeroMemory" _
    (ByVal Destination As Gdi.PIXELFORMATDESCRIPTOR, ByVal Length As Integer)

    Public Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (
       ByVal hwnd As IntPtr,
       ByVal wMsg As Integer,
       ByVal wParam As IntPtr,
       ByVal lParam As IntPtr) As Integer
    Public Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (
        ByVal hwnd As IntPtr,
        ByVal wMsg As Integer,
        ByVal wParam As Integer,
        ByVal lParam As Integer) As Integer

    Public sp_w, sp_h, old_sp_w As Integer
    Public _plot_thread As Object
    Public sel_center_pnt As Integer = 0
    Public Nav_Ball As Integer = 0
    Public Nav_Letters As Integer = 0
    Public main_plot_list As Integer = -1
    Public stl_list As Integer = -1
    Public gl_list_base As Integer = -1
    Public PB1 As New my_PB1
    Public status_t1, status_t2, status_ln As New Label
    Public status_CNC As New Label
    Public status_CNC_info As New Label
    Public FILE_PROCESS_MODE As Boolean = False
    Public zoom_factor As Single = 10
    '
    Public btn_process As New my_Btn
    Public btn_new As New my_Btn
    Public btn_open As New my_Btn
    Public btn_save As New my_Btn
    Public btn_save_as As New my_Btn
    Public spacer1 As New my_spacer
    Public spacer2 As New my_spacer
    Public spacer3 As New my_spacer
    Public spacer4 As New my_spacer
    Public spacer5 As New my_spacer
    Public spacer6 As New my_spacer
    Public spacer10 As New my_spacer
    Public spacer11 As New my_spacer
    Public spacer12 As New my_spacer
    Public btn_copy As New my_Btn
    Public btn_paste As New my_Btn
    Public btn_delete As New my_Btn
    Public btn_cut As New my_Btn
    Public btn_undo As New my_Btn
    Public btn_redo As New my_Btn
    Public btn_find As New my_Btn
    Public btn_find_next As New my_Btn
    Public btn_replace As New my_Btn
    Public btn_renum As New my_Btn
    Public btn_del_num As New my_Btn
    'define modal buttons
    Public btn_snap_selected As New my_Sqr_Btn
    Public btn_show_plot As New my_Sqr_Btn
    Public btn_gl_lighting As New my_Sqr_Btn
    Public btn_show_rapid As New my_Sqr_Btn
    Public btn_show_z_moves As New my_Sqr_Btn
    Public btn_show_points As New my_Sqr_Btn
    Public btn_draw_3d As New my_Sqr_Btn
    Public btn_draw_grid As New my_Sqr_Btn
    Public btn_draw_rapids As New my_Sqr_Btn
    Public btn_auto_center As New my_Sqr_Btn
    Public btn_draw_eye_center As New my_Sqr_Btn
    Public btn_split_direction As New my_Sqr_Btn
    Public btn_draw_highlighted As New my_Sqr_Btn
    Public btn_free_spin As New my_Sqr_Btn
    Public btn_com_con As New my_Sqr_Btn
    Public btn_zoom As New my_Sqr_Btn
    'plot buttons
    Public btn_rewind As New my_Btn
    Public btn_step_back As New my_repeat_btn_back
    Public btn_plot_all As New my_Btn
    Public btn_step_forward As New my_repeat_btn_forward
    Public btn_light As New my_Btn
    Public btn_solids As New my_Btn
    Public PB2 As New my_PB1
    Public TrackBar1 As New my_trackbar
    Public stl(1) As Vertex_data
    Public stl_len As Integer
    Public show_stl As Boolean = True
    Public model_color As Color = Color.DimGray
    Public color_scale As Single = 0.8
    Public GLControl1 As New GLControl
    Public GLControl2 As New GLControl
    Public machining As Boolean

    ' Add this declaration at the top of your class or module
    <DllImport("opengl32.dll")>
    Public Shared Function wglGetCurrentContext() As IntPtr
    End Function

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        'this is very important!!
        'It stops the splitter from auto resizing!
        'It took for ever for this to get figured out.
        Splitter.FixedPanel = FixedPanel.Panel1
        MyBase.OnResize(e)
        Splitter.FixedPanel = FixedPanel.None
        If Me.WindowState = FormWindowState.Maximized Then

        End If
        DrawScene()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim str As New StringBuilder
        'setup user_defalut data


        'this crap was used to build create a class
        'str.Append("Public Class Table_LookUp" + vbCrLf)
        'str.Append(" Public C() as Color" + vbCrLf)

        'For i = 32 To 128
        '    Dim ss As String = "C(" + String.Format("{0}", i - 32) + ") = Color.White '" + "  - " + ChrW(i) + vbCrLf
        '    str.Append(ss)
        'Next
        'str.Append("}" + vbCrLf + "Class End" + vbCrLf)
        'Dim so = str.ToString

        'setup top of custom form look
        top_bar_plot_controls.Location = New Point(0, 0)
        Me.Update()

        ' load my settings that are needed before startup ------------------------------------
        step_time = Convert.ToInt32(My.Settings.step_time)
        z_retract = Convert.ToSingle(My.Settings.z_retract)
        near_clip_plane = Convert.ToSingle(My.Settings.clip_plane)
        Me.Size = My.Settings.main_client_size
        ambient_level = My.Settings.ambient
        _grid_multi = My.Settings.grid_level

        '---------------------------------------------------------------------------------------
        Me.Show()
        While Not Me.Visible

        End While
        Try
            Dim pt = Application.StartupPath
            Dim offs As String = File.ReadAllText(pt + "\offsets.text")
            Dim _data = offs.Split(",")
            Dim pos As Integer = 0
            For i = 0 To _data.Length - 1 Step 2
                offset_x(pos) = CDec(_data(i))
                offset_y(pos) = CDec(_data(i + 1))
                pos += 1
            Next
        Catch ex As Exception

        End Try
        setup_offset_panel()

        Dim sw As Integer = Me.ClientSize.Width
        Dim sh As Integer = Me.ClientSize.Height - 38 - 38
        Splitter.Location = New Point(0, 38)
        Splitter.Dock = DockStyle.None
        Splitter.Width = sw
        Splitter.Height = sh
        Splitter.Anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom
        Splitter.SplitterDistance = My.Settings.main_split_distance
        'setup trackbar for zoom_window
        TrackBar1.LargeChange = 1
        TrackBar1.Maximum = 46
        TrackBar1.Minimum = 1
        TrackBar1.TickFrequency = 5
        TrackBar1.Orientation = Orientation.Vertical
        TrackBar1.AutoSize = False
        TrackBar1.Width = 20
        TrackBar1.Height = zoom_window.ClientSize.Height
        TrackBar1.Location = New Point(0, 0)
        TrackBar1.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Bottom
        'TrackBar1.BackColor = Color.Transparent
        'TrackBar1.Dock = DockStyle.Left
        TrackBar1.TabStop = False
        TrackBar1.Value = 10
        AddHandler TrackBar1.Scroll, AddressOf zoom_window.TrackBar1_Scroll

        zoom_window.Controls.Add(TrackBar1)

        OpenTK.Graphics.GraphicsContext.ShareContexts = True
        ' Setup GLControl2 (zoom view)
        GLControl2.MakeCurrent()
        GLControl2.Width = zoom_window.ClientSize.Width - TrackBar1.Width
        GLControl2.Height = zoom_window.ClientSize.Height
        GLControl2.Location = New Point(TrackBar1.Width, 0)
        GLControl2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Left
        GLControl2.BorderStyle = BorderStyle.None
        GLControl2.BringToFront()
        GLControl2.BackColor = Color.Black
        AddHandler GLControl2.MouseDown, AddressOf GLControl2_MouseDown
        AddHandler GLControl2.MouseMove, AddressOf GLControl2_MouseMove
        AddHandler GLControl2.MouseUp, AddressOf GLControl1_MouseUp
        AddHandler GLControl2.Paint, AddressOf PB1_Paint
        AddHandler GLControl2.MouseLeave, AddressOf GLControl1_MouseLeave
        GLControl2.Cursor = Cursors.Cross
        zoom_window.Controls.Add(GLControl2)
        zoom_window.TopMost = True

        ' Setup GLControl1 (main view)
        GLControl1.MakeCurrent()
        GLControl1.Dock = DockStyle.Fill
        GLControl1.BorderStyle = BorderStyle.None
        GLControl1.BringToFront()
        GLControl1.BackColor = Color.Black
        AddHandler GLControl1.MouseDown, AddressOf GLControl1_MouseDown
        AddHandler GLControl1.MouseMove, AddressOf GLControl1_MouseMove
        AddHandler GLControl1.MouseUp, AddressOf GLControl1_MouseUp
        AddHandler GLControl1.Paint, AddressOf PB1_Paint
        AddHandler GLControl1.MouseLeave, AddressOf GLControl1_MouseLeave
        GLControl1.Cursor = Cursors.Cross
        Splitter.Panel2.Controls.Add(GLControl1)
        '-----------------------------------------------------------------------------------
        disable_btns()
        'do this before setting up RTB1 
        'TheBuffer.Initialize()

        ' font_size.Text = My.Settings.tb_text_size
        RTB1.Font = New Font(Label1.Font.Name, 12,
            RTB1.Font.Style, RTB1.Font.Unit)
        RTB1.ContextMenuStrip = Nothing
        'RTB1.Width = Splitter.Panel1.Width - 15
        RTB1.Dock = DockStyle.Fill
        RTB1.BorderStyle = BorderStyle.None
        RTB1.BackColor = Color.FromArgb(-14078911)
        RTB1.ForeColor = Color.White
        RTB1.WordWrap = False
        RTB1.ShowSelectionMargin = True
        RTB1.ScrollBars = RichTextBoxScrollBars.ForcedBoth
        RTB1.Text = "One Moment..." + vbCrLf + "-Creating Form controls." + vbCrLf
        RTB1.EnableAutoDragDrop = True
        ' RTB1.no_autoresize()
        Splitter.Panel1.Controls.Add(RTB1)
        RTB1.Update()
        build_menu_bars()

        Application.DoEvents()

        GLControl1.MakeCurrent()
        gl_set_lights()
        GLControl2.MakeCurrent()
        gl_set_lights()
        build_gl_list()

        RTB1.Text = "Welcome....." + vbCrLf
        If DEMO Then
            RTB1.Text += vbCrLf + "CodeChop Demo Version"
        End If
        Dim info As String =
            "OpenGL Info..." & vbCrLf &
            "Vendor: " & GL.GetString(StringName.Vendor) & vbCrLf &
            "Renderer: " & GL.GetString(StringName.Renderer) & vbCrLf &
            "Version: " & GL.GetString(StringName.Version)
        RTB1.Text += vbCrLf + "- - - - - - - - - - - -" + vbCrLf + info


        Dim VersionInfo As Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
        Dim ver As String = VersionInfo.Major & "." & VersionInfo.Minor & "." & VersionInfo.Revision
        RTB1.Text += vbCrLf + "- - - - - - - - - - - -" + vbCrLf +
        App_Name + " Version: " + ver
        status_t1.Text = "No Text"
        status_t2.Text = "Load a file?"
        status_ln.Text = "ln: 1"
        pg1.Visible = False
        Application.DoEvents()

        trapUndo = True
        RichTextBox_Change()
        draw_grid = True
        gl_lighting = True

        Look_X_angle = PI * 0.8
        Look_Y_angle = -PI * 0.2
        look_radius = -8.0F
        Me.KeyPreview = True ' so I can catch the key events for mouse behavour modification
        add_plot_bar_buttons()
        clear_arrays()
        'Table_Lookup.set_colors()
        'model_color = Color.SlateGray
        Lighting.Visible = False
        Lighting.Show()
        Lighting.Hide()
        pg1.Dock = DockStyle.None
        set_pg1_size()
        isInitiated = True
        FontDialog1.Font = My.Settings.selected_font
        RTB1.Font = FontDialog1.Font
        ColorDialog1.Color = My.Settings.font_fore_color
        RTB1.ForeColor = ColorDialog1.Color
        build_stl(Application.StartupPath + "\codechop.stl")
        codechop_loaded = True
        btn_save_as.Enabled = False
        Try
            Dim f As String = Environment.GetCommandLineArgs(1)
            If f.Length > 1 Then
                OpenFileDialog1.FileName = f
                delete_stl()
                open_file()
            End If
        Catch ex As Exception
        End Try
        Startup_Path = Application.StartupPath
        Me.WindowState = FormWindowState.Maximized
        Application.DoEvents()
        DrawScene()
        Application.DoEvents()
        DrawScene()
        Application.DoEvents()


    End Sub
    Private Sub build_menu_bars()
        '---------------------------
        'setup width and location of top_bar_plot_controls
        tb_ec = New Point(3 + (15 * 5) + (32 * 16), 0)
        top_bar_plot_controls.Location = tb_ec
        top_bar_plot_controls.Width = Me.ClientRectangle.Width - tb_ec.X
        top_bar_plot_controls.Height = 38
        top_bar_plot_controls.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        'add buttons to top bar ----------------------------------------------
        'btn_process
        btn_process.Image = My.Resources.arc
        btn_process.Location = New Point(3, 3)
        top_bar.Controls.Add(btn_process)
        ToolTip1.SetToolTip(btn_process, "Convert Moves")
        AddHandler btn_process.MouseClick, AddressOf _btn_process
        'btn_new
        btn_new.Image = My.Resources.document_text
        btn_new.Location = New Point(3 + (32 * 1), 3)
        top_bar.Controls.Add(btn_new)
        ToolTip1.SetToolTip(btn_new, "New Document")
        AddHandler btn_new.MouseClick, AddressOf _btn_new
        'btn_open
        btn_open.Image = My.Resources.folder_open_document_text
        btn_open.Location = New Point(3 + (32 * 2), 3)
        top_bar.Controls.Add(btn_open)
        ToolTip1.SetToolTip(btn_open, "Open Document")
        AddHandler btn_open.MouseClick, AddressOf _btn_open
        'btn_save
        btn_save.Image = My.Resources.disk_black
        btn_save.Location = New Point(3 + (32 * 3), 3)
        top_bar.Controls.Add(btn_save)
        ToolTip1.SetToolTip(btn_save, "Save Document")
        AddHandler btn_save.MouseClick, AddressOf _btn_save
        'btn_save_as
        btn_save_as.Image = My.Resources.disk
        btn_save_as.Location = New Point(3 + (32 * 4), 3)
        top_bar.Controls.Add(btn_save_as)
        ToolTip1.SetToolTip(btn_save_as, "Save Document As..")
        AddHandler btn_save_as.MouseClick, AddressOf _btn_save_as
        'spacer
        spacer1.Width = 15
        spacer1.BackgroundImage = My.Resources.spacer_2
        spacer1.Location = New Point(3 + (32 * 5), 0)
        top_bar.Controls.Add(spacer1)
        'btn_copy
        btn_copy.Image = My.Resources.documents
        btn_copy.Location = New Point(3 + (spacer1.Width * 1) + (32 * 5), 3)
        top_bar.Controls.Add(btn_copy)
        ToolTip1.SetToolTip(btn_copy, "Copy Selection")
        AddHandler btn_copy.MouseClick, AddressOf _btn_copy
        'btn_paste
        btn_paste.Image = My.Resources.clipboard__arrow
        btn_paste.Location = New Point(3 + (spacer1.Width * 1) + (32 * 6), 3)
        top_bar.Controls.Add(btn_paste)
        ToolTip1.SetToolTip(btn_paste, "Paste Copied")
        AddHandler btn_paste.MouseClick, AddressOf _btn_paste
        'btn_delete
        btn_delete.Image = My.Resources.DeleteHS
        btn_delete.Location = New Point(3 + (spacer1.Width * 1) + (32 * 7), 3)
        top_bar.Controls.Add(btn_delete)
        ToolTip1.SetToolTip(btn_delete, "Delete Selection")
        AddHandler btn_delete.MouseClick, AddressOf _btn_delete
        'btn_cut
        btn_cut.Image = My.Resources.CutHS
        btn_cut.Location = New Point(3 + (spacer1.Width * 1) + (32 * 8), 3)
        top_bar.Controls.Add(btn_cut)
        ToolTip1.SetToolTip(btn_cut, "Move to ClipBoard")
        AddHandler btn_cut.MouseClick, AddressOf _btn_cut
        'spacer2
        spacer2.Width = 15
        spacer2.BackgroundImage = My.Resources.spacer_2
        spacer2.Location = New Point(3 + (spacer1.Width * 1) + (32 * 9), 0)
        top_bar.Controls.Add(spacer2)
        'btn_undo
        btn_undo.Image = My.Resources.Edit_UndoHS
        btn_undo.Location = New Point(3 + (spacer1.Width * 2) + (32 * 9), 3)
        top_bar.Controls.Add(btn_undo)
        ToolTip1.SetToolTip(btn_undo, "Undo changes")
        AddHandler btn_undo.MouseClick, AddressOf _btn_undo
        'btn_redo
        btn_redo.Image = My.Resources.Edit_RedoHS
        btn_redo.Location = New Point(3 + (spacer1.Width * 2) + (32 * 10), 3)
        top_bar.Controls.Add(btn_redo)
        ToolTip1.SetToolTip(btn_redo, "Redo changes")
        AddHandler btn_redo.MouseClick, AddressOf _btn_redo
        'spacer3
        spacer3.Width = 15
        spacer3.BackgroundImage = My.Resources.spacer_2
        spacer3.Location = New Point(3 + (spacer1.Width * 2) + (32 * 11), 0)
        top_bar.Controls.Add(spacer3)
        'btn_find
        btn_find.Image = My.Resources.FindHS
        btn_find.Location = New Point(3 + (spacer1.Width * 3) + (32 * 11), 3)
        top_bar.Controls.Add(btn_find)
        ToolTip1.SetToolTip(btn_find, "Search Text")
        AddHandler btn_find.MouseClick, AddressOf _btn_find
        'btn_find_next
        btn_find_next.Image = My.Resources.FindNextHS
        btn_find_next.Location = New Point(3 + (spacer1.Width * 3) + (32 * 12), 3)
        top_bar.Controls.Add(btn_find_next)
        ToolTip1.SetToolTip(btn_find_next, "Search Next")
        AddHandler btn_find_next.MouseClick, AddressOf _btn_find_next
        'btn_replace
        btn_replace.Image = My.Resources.ReplaceHS
        btn_replace.Location = New Point(3 + (spacer1.Width * 3) + (32 * 13), 3)
        top_bar.Controls.Add(btn_replace)
        ToolTip1.SetToolTip(btn_replace, "Search and Replace")
        AddHandler btn_replace.MouseClick, AddressOf _btn_replace
        'spacer4
        spacer4.Width = 15
        spacer4.BackgroundImage = My.Resources.spacer_2
        spacer4.Location = New Point(3 + (spacer1.Width * 3) + (32 * 14), 0)
        top_bar.Controls.Add(spacer4)
        'btn_renum
        btn_renum.Image = My.Resources.re_num
        btn_renum.Location = New Point(3 + (spacer1.Width * 4) + (32 * 14), 3)
        top_bar.Controls.Add(btn_renum)
        ToolTip1.SetToolTip(btn_renum, "Re-Number...")
        AddHandler btn_renum.MouseClick, AddressOf _btn_renum
        'btn_del_num
        btn_del_num.Image = My.Resources.del_num
        btn_del_num.Location = New Point(3 + (spacer1.Width * 4) + (32 * 15), 3)
        top_bar.Controls.Add(btn_del_num)
        ToolTip1.SetToolTip(btn_del_num, "Delete Line Nums")
        AddHandler btn_del_num.MouseClick, AddressOf _btn_del_num
        'spacer5
        spacer5.Width = 15
        spacer5.BackgroundImage = My.Resources.spacer_2
        spacer5.Location = New Point(3 + (spacer1.Width * 4) + (32 * 16), 0)
        top_bar.Controls.Add(spacer5)
        ' end add buttons to top_bar ---------------------------------------------------------

        'add buttons to top_bar_plot_controls
        'these are MODAL buttons
        'btn_show_plot
        btn_show_plot.Checked = True
        btn_show_plot.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
        btn_show_plot.Image = My.Resources.plot
        btn_show_plot.Location = New Point(3 + (spacer1.Width * 0) + (32 * 0), 3)
        top_bar_plot_controls.Controls.Add(btn_show_plot)
        ToolTip1.SetToolTip(btn_show_plot, "Show/Hide Plot Window")
        AddHandler btn_show_plot.MouseClick, AddressOf _btn_show_plot
        'btn_split_direction
        btn_split_direction.Checked = False
        Splitter.Orientation = Orientation.Vertical
        btn_split_direction.mouse_in = False
        btn_split_direction.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_split_direction.Image = My.Resources.__layout_h
        btn_split_direction.Location = New Point(3 + (spacer1.Width * 0) + (32 * 1), 3)
        top_bar_plot_controls.Controls.Add(btn_split_direction)
        ToolTip1.SetToolTip(btn_split_direction, "Vert/Horz Splitter")
        AddHandler btn_split_direction.MouseClick, AddressOf _btn_split_direction

        'spacer6
        spacer6.Width = 15
        spacer6.BackgroundImage = My.Resources.spacer_2
        spacer6.Location = New Point(3 + (spacer1.Width * 0) + (32 * 2), 0)
        top_bar_plot_controls.Controls.Add(spacer6)
        '

        'btn_draw_grid
        btn_draw_grid.Checked = True
        btn_draw_grid.mouse_in = False
        btn_draw_grid.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
        btn_draw_grid.Image = My.Resources.grid
        btn_draw_grid.Location = New Point(3 + (spacer1.Width * 1) + (32 * 2), 3)
        top_bar_plot_controls.Controls.Add(btn_draw_grid)
        ToolTip1.SetToolTip(btn_draw_grid, "Show/Hide Grid")
        AddHandler btn_draw_grid.MouseClick, AddressOf _btn_draw_grid
        'btn_draw_rapids
        btn_draw_rapids.Checked = True
        btn_draw_rapids.mouse_in = False
        btn_draw_rapids.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
        btn_draw_rapids.Image = My.Resources.rapid
        btn_draw_rapids.Location = New Point(3 + (spacer1.Width * 1) + (32 * 3), 3)
        top_bar_plot_controls.Controls.Add(btn_draw_rapids)
        ToolTip1.SetToolTip(btn_draw_rapids, "Show/Hide G0 Moves")
        AddHandler btn_draw_rapids.MouseClick, AddressOf _btn_draw_rapids
        'btn_show_z_moves
        btn_show_z_moves.Checked = True
        btn_show_z_moves.mouse_in = False
        btn_show_z_moves.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
        btn_show_z_moves.Image = My.Resources.z_only
        btn_show_z_moves.Location = New Point(3 + (spacer1.Width * 1) + (32 * 4), 3)
        top_bar_plot_controls.Controls.Add(btn_show_z_moves)
        ToolTip1.SetToolTip(btn_show_z_moves, "Show/Hide Z Only Moves")
        AddHandler btn_show_z_moves.MouseClick, AddressOf _btn_show_z_moves
        'btn_show_points
        btn_show_points.Checked = False
        btn_show_points.mouse_in = False
        btn_show_points.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_show_points.Image = My.Resources.points
        btn_show_points.Location = New Point(3 + (spacer1.Width * 1) + (32 * 5), 3)
        top_bar_plot_controls.Controls.Add(btn_show_points)
        ToolTip1.SetToolTip(btn_show_points, "Show/Hide End Points")
        AddHandler btn_show_points.MouseClick, AddressOf _btn_show_points
        'btn_draw_3d
        btn_draw_3d.Checked = False
        btn_draw_3d.mouse_in = False
        btn_draw_3d.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_draw_3d.Image = My.Resources._3D
        btn_draw_3d.Location = New Point(3 + (spacer1.Width * 1) + (32 * 6), 3)
        top_bar_plot_controls.Controls.Add(btn_draw_3d)
        ToolTip1.SetToolTip(btn_draw_3d, "Z-Buffer On/Off")
        AddHandler btn_draw_3d.MouseClick, AddressOf _btn_draw_3d
        'btn_auto_center
        btn_auto_center.Checked = False
        _auto_center = False
        btn_auto_center.mouse_in = False
        btn_auto_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_auto_center.Image = My.Resources.__center
        btn_auto_center.Location = New Point(3 + (spacer1.Width * 1) + (32 * 7), 3)
        top_bar_plot_controls.Controls.Add(btn_auto_center)
        ToolTip1.SetToolTip(btn_auto_center, "Auto Center Selected")
        AddHandler btn_auto_center.MouseClick, AddressOf _btn_auto_center
        'btn_draw_eye_center
        btn_draw_eye_center.Checked = False
        eye_target = False
        btn_draw_eye_center.mouse_in = False
        btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_draw_eye_center.Image = My.Resources.target
        btn_draw_eye_center.Location = New Point(3 + (spacer1.Width * 1) + (32 * 8), 3)
        top_bar_plot_controls.Controls.Add(btn_draw_eye_center)
        ToolTip1.SetToolTip(btn_draw_eye_center, "Show Eye Look Center")
        AddHandler btn_draw_eye_center.MouseClick, AddressOf _btn_draw_eye_center
        'btn_draw_highlighted
        btn_draw_highlighted.Checked = False
        draw_presistent_selection = False
        Splitter.Orientation = Orientation.Vertical
        btn_draw_highlighted.mouse_in = False
        btn_draw_highlighted.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_draw_highlighted.Image = My.Resources.draw_highlighted
        btn_draw_highlighted.Location = New Point(3 + (spacer1.Width * 1) + (32 * 9), 3)
        top_bar_plot_controls.Controls.Add(btn_draw_highlighted)
        ToolTip1.SetToolTip(btn_draw_highlighted, "HighLight Selected")
        AddHandler btn_draw_highlighted.MouseClick, AddressOf _btn_draw_highlighted
        'btn_zoom
        btn_zoom.Checked = False
        btn_zoom.mouse_in = False
        btn_zoom.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_zoom.Image = My.Resources.zoom_window
        btn_zoom.Location = New Point(3 + (spacer1.Width * 1) + (32 * 10), 3)
        top_bar_plot_controls.Controls.Add(btn_zoom)
        ToolTip1.SetToolTip(btn_zoom, "Show/Hide Zoom Window")
        AddHandler btn_zoom.MouseClick, AddressOf _btn_zoom
        'btn_free_spin
        btn_free_spin.Checked = False
        Timer1.Enabled = False
        btn_free_spin.mouse_in = False
        btn_free_spin.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_free_spin.Image = My.Resources.arrow_circle
        btn_free_spin.Location = New Point(3 + (spacer1.Width * 1) + (32 * 11), 3)
        top_bar_plot_controls.Controls.Add(btn_free_spin)
        ToolTip1.SetToolTip(btn_free_spin, "Free Spin Plot")
        AddHandler btn_free_spin.MouseClick, AddressOf _btn_free_spin
        'btn_com_con
        btn_com_con.Checked = False
        btn_com_con.mouse_in = False
        btn_com_con.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_com_con.Image = My.Resources.WirelessConnection
        btn_com_con.Location = New Point(3 + (spacer1.Width * 1) + (32 * 12), 3)
        top_bar_plot_controls.Controls.Add(btn_com_con)
        ToolTip1.SetToolTip(btn_com_con, "Open Com Con")
        AddHandler btn_com_con.MouseClick, AddressOf _btn_com_con
    End Sub
    Private Sub add_plot_bar_buttons()
        plot_toolbar.Controls.Clear()


        status_CNC.Location = New Point(600, 21)
        status_CNC.BackColor = Color.Transparent
        status_CNC.ForeColor = Color.Aquamarine
        status_CNC.AutoSize = True

        status_CNC_info.Location = New Point(600, 4)
        status_CNC_info.BackColor = Color.Transparent
        status_CNC_info.ForeColor = Color.Aquamarine
        status_CNC_info.AutoSize = True

        status_t1.Location = New Point(3, 4)
        status_t1.BackColor = Color.Transparent
        status_t1.ForeColor = Color.Aquamarine
        status_t1.AutoSize = True

        status_t2.Location = New Point(3, 21)
        status_t2.BackColor = Color.Transparent
        status_t2.ForeColor = Color.Aquamarine
        status_t2.AutoSize = True

        status_ln.Location = New Point(150, 4)
        status_ln.BackColor = Color.Transparent
        status_ln.ForeColor = Color.Aquamarine
        status_ln.AutoSize = True

        ' status_ln.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        plot_toolbar.Controls.Add(status_t1)
        plot_toolbar.Controls.Add(status_t2)
        plot_toolbar.Controls.Add(status_ln)
        plot_toolbar.Controls.Add(status_CNC)
        plot_toolbar.Controls.Add(status_CNC_info)

        Dim loc As Integer = Splitter.SplitterDistance + 30
        'btn_free_spin.Location = New Point(loc + (32 * 1), 3)
        'btn_rewind
        btn_rewind.BackgroundImage = My.Resources.BTN_M_UP
        btn_rewind.Image = My.Resources.control_double_180
        btn_rewind.Location = New Point(loc, 3)
        plot_toolbar.Controls.Add(btn_rewind)
        ToolTip1.SetToolTip(btn_rewind, "Clear and Rewind")
        AddHandler btn_rewind.MouseClick, AddressOf _btn_rewind
        'btn_step_back
        btn_step_back.BackgroundImage = My.Resources.BTN_M_UP
        btn_step_back.Image = My.Resources.control_stop_180
        btn_step_back.Location = New Point(loc + (32 * 1), 3)
        plot_toolbar.Controls.Add(btn_step_back)
        ToolTip1.SetToolTip(btn_step_back, "Step Back")
        AddHandler btn_step_back.MouseClick, AddressOf _btn_step_back

        'btn_plot_all
        btn_plot_all.BackgroundImage = My.Resources.BTN_M_UP
        btn_plot_all.Image = My.Resources.control
        btn_plot_all.Location = New Point(loc + (32 * 2), 3)
        plot_toolbar.Controls.Add(btn_plot_all)
        ToolTip1.SetToolTip(btn_plot_all, "ReDraw all")
        AddHandler btn_plot_all.MouseClick, AddressOf _btn_plot_all
        'btn_step_forward
        btn_step_forward.BackgroundImage = My.Resources.BTN_M_UP
        btn_step_forward.Image = My.Resources.control_stop
        btn_step_forward.Location = New Point(loc + (32 * 3), 3)
        plot_toolbar.Controls.Add(btn_step_forward)
        ToolTip1.SetToolTip(btn_step_forward, "Step Forward")
        AddHandler btn_step_forward.MouseClick, AddressOf _btn_step_forward

        'spacer10
        spacer10.Width = 15
        spacer10.BackgroundImage = My.Resources.spacer_2
        spacer10.Location = New Point(loc + (spacer1.Width * 0) + (32 * 4), 0)
        plot_toolbar.Controls.Add(spacer10)
        '
        'btn_light
        btn_light.BackgroundImage = My.Resources.BTN_M_UP
        btn_light.Image = My.Resources.light_bulb_off
        btn_light.Location = New Point(loc + (spacer1.Width * 1) + (32 * 4), 3)
        plot_toolbar.Controls.Add(btn_light)
        ToolTip1.SetToolTip(btn_light, "Change Settings")
        AddHandler btn_light.MouseClick, AddressOf _btn_light
        'spacer11
        spacer11.Width = 15
        spacer11.BackgroundImage = My.Resources.spacer_2
        spacer11.Location = New Point(loc + (spacer1.Width * 1) + (32 * 5), 0)
        plot_toolbar.Controls.Add(spacer11)
        ''
        'btn_solids
        btn_solids.BackgroundImage = My.Resources.BTN_M_UP
        btn_solids.Image = My.Resources.solids
        btn_solids.Location = New Point(loc + (spacer1.Width * 2) + (32 * 5), 3)
        plot_toolbar.Controls.Add(btn_solids)
        ToolTip1.SetToolTip(btn_solids, "Load STL Solid")
        AddHandler btn_solids.MouseClick, AddressOf _btn_solids


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
        If Me.WindowState = FormWindowState.Maximized Then
            My.Settings.main_client_size = form_client_size
        Else
            My.Settings.main_client_size = Me.Size
        End If
        'save offset data
        Dim oss As New StringBuilder
        For i = 0 To 99
            oss.Append(offset_x(i).ToString + "," + offset_y(i).ToString + ",")

        Next
        Dim pt = Application.StartupPath
        File.WriteAllText(pt + "\offsets.text", oss.ToString)
        GL.DeleteLists(gl_list_base, 5)
        DisableOpenGL()
        My.Settings.Save()
        ' _plot_thread.abort()
        ' My.Settings.tb_text_size = font_size.Text
    End Sub
    Public Sub setup_offset_panel()
        For i = 1 To 99
            Dim t1 As New my_x_tb
            Dim t2 As New my_y_tb
            Dim lb1 As New Label
            Dim lb2 As New Label
            Dim lb3 As New Label
            lb1.BackColor = Color.Transparent
            lb1.ForeColor = Color.Yellow

            lb2.BackColor = Color.Transparent
            lb2.ForeColor = Color.Yellow

            lb3.BackColor = Color.Transparent
            lb3.ForeColor = Color.White
            lb1.AutoSize = False
            lb1.Width = 22
            lb2.AutoSize = False
            lb2.Width = 22
            lb3.AutoSize = False
            lb3.Width = 22
            lb1.Text = "X"
            lb2.Text = "Y"
            lb3.Text = i.ToString
            lb3.TextAlign = ContentAlignment.MiddleRight
            lb2.TextAlign = ContentAlignment.MiddleRight
            lb1.TextAlign = ContentAlignment.MiddleRight

            t1.id = i - 1
            t2.id = i - 1
            t1.set_Color()
            t2.set_Color()
            t1.Name = i.ToString
            t1.Text = offset_x(i - 1).ToString
            t2.Text = offset_y(i - 1).ToString
            t2.Name = i.ToString
            lb3.Location = New Point(5, i * 25)

            lb1.Location = New Point(30, i * 25)
            t1.Location = New Point(55, i * 25)
            lb2.Location = New Point(100, i * 25)
            t2.Location = New Point(125, i * 25)

            fixture_offsets.offset_panel.Controls.Add(lb3) 'id

            fixture_offsets.offset_panel.Controls.Add(lb1) 'x
            fixture_offsets.offset_panel.Controls.Add(t1) 'x textbox
            fixture_offsets.offset_panel.Controls.Add(lb2) 'y
            fixture_offsets.offset_panel.Controls.Add(t2) 'y textbox
        Next

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'save
    End Sub

    Private Sub SaveAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'save as
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    End Sub



    Public Sub clear_arrays()
        ReDim Preserve presistent(1)
        ReDim Preserve draw_data(1)
        ReDim Preserve lookup(1)
        ReDim Preserve pgm_lines(1)
        'presistent(0) = New line_d
        'draw_data(0) = New line_d
        'lookup(0) = New lk_up
        'pgm_lines(0) = ""
    End Sub
    Public Sub enable_btns()
        '    send_btn.Enabled = True
        'recv_btn.Enabled = True
        btn_save.Enabled = True 'save
        btn_save_as.Enabled = True 'save as
        '_plot.Enabled = True
    End Sub
    Public Sub disable_btns()
        '    send_btn.Enabled = False
        'recv_btn.Enabled = False
        btn_save.Enabled = False 'save
        btn_save_as.Enabled = False 'save as
        '  _plot.Enabled = False
    End Sub


    Public Function get_filename() As String
        Dim sp() As String
        sp = path.Split("\"c)
        new_path = ""
        For i = 0 To sp.Length - 2
            new_path += sp(i) + "\"
        Next
        file_root = new_path
        If FILE_PROCESS_MODE Then
            file_name = "CVRT_" + sp(sp.Length - 1)
            Return ("CVRT_" + sp(sp.Length - 1))
        Else
            file_name = sp(sp.Length - 1)
            Return (sp(sp.Length - 1))
        End If

    End Function


    ' File IO ------------------------------------------------------------------------ File IO
    ' file filter read and setup
    Public Sub make_filter()
        Dim filter As String = ""
        Dim f As String = File.ReadAllText(Application.StartupPath + "\file_filter.txt")
        If f.Length = 0 Then MsgBox("Can find File_filter.txt file!", MsgBoxStyle.Exclamation, "File Missing Error")
        f = Microsoft.VisualBasic.Replace(f, vbCrLf, vbLf)
        Dim a = f.Split(vbLf)

        For Each s In a
            If s.Length <= 1 Then GoTo next_
            If InStr(s, "//") > 0 Then GoTo next_
            Dim x = s.Split(":")
            filter += x(0) + " (" + x(1) + ")" + "|" + x(1) + "|"
next_:
        Next
        filter = LSet(filter, filter.Length - 1)
        OpenFileDialog1.Filter = filter
        frmfilter.OpenFileDialog2.Filter = filter
        SaveFileDialog1.Filter = filter
    End Sub

    Public Sub open_file()
        ' Timer1.Enabled = False
        path = OpenFileDialog1.FileName
        'RTB1._Paint = False
        Dim _sr As New StringBuilder
        Dim sr As New StreamReader(path)
        Try
            clear_arrays()
            RTB1.Text = ""
            RTB1.Rtf = ""
            'Splitter.Invalidate()
            RTB1.Invalidate()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            Application.DoEvents()
            _Loading = True
            max_lines = max_lines_reload
            If DEMO Then
                Dim data() = sr.ReadToEnd.Split(vbCrLf)
                If data.Length <= max_lines Then
                    For i = 0 To data.Length - 1
                        _sr.Append(data(i))
                    Next
                    GoTo no_data
                Else
                    For i = 0 To max_lines
                        _sr.Append(data(i))
                    Next
                End If
                MsgBox("Sorry.. This is the Demo Version" + vbCrLf + "You have hit the " + max_lines_reload.ToString + " line limit." + vbCrLf +
                                "For unlimited file size, buy the software.", MsgBoxStyle.Information, "Demo Limitation")
            Else
                _sr.Append(sr.ReadToEnd)

            End If
no_data:
            sr.Close()
            sr.Dispose()
        Catch ex As Exception
            RTB1._Paint = True
            RTB1.SelectionStart = 0
            sr.Close()
            sr.Dispose()

            _Loading = False
            MsgBox("Error.. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "File Read Error..")
            ' Timer1.Enabled = True
            Return
        End Try

        RTB1.Text = _sr.ToString
        '------------------ color replace
        'colorize_rtb1()

        clear_selection() 'clear any selected plot text
        Me.Text = App_Name + " : " + get_filename()
        status_t2.Text = get_filename() + " : Loaded"
        status_t1.Text = "File Size:" + CStr(RTB1.Text.Length)
        enable_btns()
        RTB1.ContextMenuStrip = RTB1_C
        'RTB1._Paint = True
        'Application.DoEvents()
        'RTB1.Invalidate()
        Application.DoEvents()
        'RTB1.ScrollBars = RichTextBoxScrollBars.None
        'RTB1.ScrollBars = RichTextBoxScrollBars.Both
        Application.DoEvents()
        _Loading = False
        draw_all()
        'Timer1.Enabled = True
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        'save
        path = SaveFileDialog1.FileName
        Me.Text = App_Name + " : " + get_filename()
        IO.File.WriteAllText(path, RTB1.Text)

    End Sub
    'get color string
    Private Function get_rtf_color(ByVal c As Color) As String
        Dim s As String = ";\red" + c.R.ToString + "\green" + c.G.ToString + "\blue" + c.B.ToString
        Return s
    End Function
    Public Sub colorize_rtb1()
        Dim ts As String = ""
        Dim spl = RTB1.Rtf.Split(vbCr)
        RTB1.Rtf = ""
        ts = spl(0) + vbCr
        ts += "{\colortbl" + get_rtf_color(Color.White) +
                            get_rtf_color(Color.Lime) +
                            get_rtf_color(Color.Aqua) +
                            get_rtf_color(Color.LightYellow) +
                            get_rtf_color(Color.Orange) +
                            get_rtf_color(Color.Blue) + ";}" + vbCr


        For id = 2 To spl.Length - 1
            ts += set_colors(spl(id)) + vbCr
            'ts = Microsoft.VisualBasic.Replace(ts, "Y", "{\cf2 Y}")
            'ts += Microsoft.VisualBasic.Replace(ts, "Z", "{\cf2 Y}")
            'ts += Microsoft.VisualBasic.Replace(ts, "M", "{\cf3 Y}")
            '   RTB1.Rtf += spl(id) + vbCrLf
        Next
        RTB1.Rtf = ts + "}"

        ' ts += Microsoft.VisualBasic.Replace(ts, "X", "{\cf2 X}")
        '------------------ color replace
    End Sub

    Public Function set_colors(ByRef s As String) As String
        Dim hit As Boolean = False
        Dim error_ As Boolean = False
        Dim ts As String = ""
        ' Dim ts2 As String = ""
        If Not s <> Nothing Then Return ""
        For i = 0 To s.Length - 1 - 4

            Select Case s(i)
                Case ";"
                    hit = True
                    ts += "\cf2 "
                    Dim ta = s.Split(";")
                    Dim ln = ";" + RSet(ta(1), s.Length - i - 5)
                    ts += ln + "\cf1\par"
                    Return ts
                Case "M", "T", "G"
                    hit = True
                    ts += "\cf3 " + s(i)
                    For k = i + 1 To s.Length - 1
                        Select Case s(k)
                            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                                ts += s(k)
                                i = k '+ 1
                                GoTo next_m

                            Case Else
                                ts += "\cf1 "
                                'i -= 1
                                GoTo next_i
                        End Select
                        ts += "\"
                        Exit For
next_m:
                    Next


                Case "X", "Y", "Z", "I", "J", "K", "R", "P"
                    hit = True
                    ts += "\cf4 " + s(i)
                    For k = i + 1 To s.Length - 1
                        Select Case s(k)
                            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "-", "+"
                                ts += s(k)
                                i = k '+ 1
                                GoTo next_x

                            Case Else

                                ts += "\cf1 "
                                'i -= 1
                                GoTo next_i
                        End Select
                        ts += "\"
                        Exit For
next_x:
                    Next

                Case "H", "S", "D", "F" ', "I", "J", "K", "R", "P"
                    hit = True
                    ts += "\cf5 " + s(i)
                    For k = i + 1 To s.Length - 1
                        Select Case s(k)
                            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "-", "+"
                                ts += s(k)
                                i = k '+ 1
                                GoTo next_h

                            Case Else
                                ts += "\cf1 "
                                'i -= 1
                                GoTo next_i
                        End Select
                        ts += "\"
                        Exit For
next_h:
                    Next

                Case "N" ', "I", "J", "K", "R", "P"
                    hit = True
                    ts += "\cf6 " + s(i)
                    For k = i + 1 To s.Length - 1
                        Select Case s(k)
                            Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                                ts += s(k)
                                i = k '+ 1
                                GoTo next_N

                            Case Else
                                ts += "\cf1 "
                                'i -= 1
                                GoTo next_i
                        End Select
                        ts += "\"
                        Exit For
next_N:
                    Next
                Case Else
                    ts += s(i)
            End Select
next_i:
        Next i
        If hit Then
            Return ts + "\par"
        Else
            Return s
        End If
    End Function
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
        If _center_selected.Checked Then
            Try
                eye_x = draw_data(sel_center_pnt).ex
                eye_z = -draw_data(sel_center_pnt).ey
                eye_y = draw_data(sel_center_pnt).ez

            Catch ex As Exception
            End Try
            _auto_center = True
            btn_auto_center.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
            btn_auto_center.Checked = True
        Else
            _auto_center = False
            btn_auto_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            btn_auto_center.Checked = False

        End If

        DrawScene()
    End Sub
    Private Sub _plot_selected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _plot_selected.Click
        If _plot_selected.Checked Then
            draw_presistent_selection = True
            btn_draw_highlighted.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
            btn_draw_highlighted.Checked = True
        Else
            draw_presistent_selection = False
            btn_draw_highlighted.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            btn_draw_highlighted.Checked = False
        End If
        DrawScene()
    End Sub
    Private Sub _expand_text_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _expand_text.Click
        Timer1.Enabled = False
        Dim call_sub = Lighting.sub_call_tb.Text
        Dim return_sub = Lighting.sub_return_tb.Text

        Dim buffer_string As New StringBuilder
        Dim holding_str As String = ""
        Dim line_cnt As Integer = 1
        Dim st As String
        holding_str = RTB1.Text
        Dim txt_array As String() = holding_str.Split(ChrW(10))

        line_cnt = txt_array.Length - 1
        pg1.Visible = True
        set_pg1_size()
        pg1.Maximum = line_cnt

        For I = 0 To line_cnt - 1
            Application.DoEvents()
            pg1.Value = I

            '  Application.DoEvents()
            st = txt_array(I)
            st = Microsoft.VisualBasic.Replace(st, ChrW(13), "")
            If Not st <> Nothing Then GoTo no_text
            If st.Length = 0 Then GoTo no_text
            RTB1.Focus()

            If InStr(st, ";") = 0 Then
                If InStr(st, "X") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "X", " X", , 1, )
                End If
                If InStr(st, "Y") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "Y", " Y", , 1, )
                End If
                If InStr(st, "Z") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "Z", " Z", , 1, )
                End If
                If InStr(st, "I") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "I", " I", , 1, )
                End If
                If InStr(st, "J") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "J", " J", , 1, )
                End If
                If InStr(st, "K") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "K", " K", , 1, )
                End If
                If InStr(st, "Q") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "Q", " Q", , 1, )
                End If
                If InStr(st, "M") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "M", " M", , 1, )
                End If
                If InStr(st, "F") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "F", " F", , 1, )
                End If
                If InStr(st, "H") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "H", " H", , 1, )
                End If
                If InStr(st, "D") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "D", " D", , 1, )
                End If
                If InStr(st, "P") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "P", " P", , 1, )
                End If
                If InStr(st, "W") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                End If
                If InStr(st, "W") > 1 Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                End If
                If Not InStr(st, return_sub) > 0 Then
                    If InStr(st, "R") > 1 Then
                        st = Microsoft.VisualBasic.Replace(st, "R", " R", , 1, )
                    End If
                    If InStr(st, "S") > 1 Then
                        st = Microsoft.VisualBasic.Replace(st, "S", " S", , 1, )
                    End If
                    If InStr(st, "T") > 1 Then
                        st = Microsoft.VisualBasic.Replace(st, "T", " T", , 1, )
                    End If
                End If
            Else
                Dim comm_pos = InStr(st, ";")
                If InStr(st, "X") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "X", " X", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Y") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Y", " Y", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Z") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Z", " Z", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "I") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "I", " I", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "J") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "J", " J", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "K") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "K", " K", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Q") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "Q", " Q", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "R") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "R", " R", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "S") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "S", " S", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "T") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "T", " T", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "M") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "M", " M", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "F") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "F", " F", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "H") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "H", " H", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "D") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "D", " D", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "P") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "P", " P", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, "W", " W", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                'st = Microsoft.VisualBasic.Replace(st, ";", " (", , 1, )
            End If
no_text:
            buffer_string.Append(st + vbCrLf)
        Next
        pg1.Visible = False
        RTB1.Text = buffer_string.ToString
        If Not Splitter.Panel2Collapsed Then
            'Timer1.Enabled = True
        End If
    End Sub

    Private Sub _Compress_text_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _Compress_text.Click

        Timer1.Enabled = False
        RTB1.Focus()
        Dim buffer_string As New StringBuilder
        Dim holding_str As String = ""
        Dim line_cnt As Integer = 1
        Dim st As String
        holding_str = RTB1.Text
        Dim txt_array As String() = holding_str.Split(ChrW(10))

        line_cnt = txt_array.Length - 1
        pg1.Visible = True
        set_pg1_size()
        pg1.Maximum = line_cnt

        For I = 0 To line_cnt - 1
            Application.DoEvents()
            pg1.Value = I

            '  Application.DoEvents()
            st = txt_array(I)
            st = Microsoft.VisualBasic.Replace(st, ChrW(13), "")
            If Not st <> Nothing Then GoTo no_text
            If st.Length = 0 Then GoTo no_text

            If InStr(st, ";") = 0 Then
                st = Microsoft.VisualBasic.Replace(st, " X", "X")
                st = Microsoft.VisualBasic.Replace(st, " Y", "Y")
                st = Microsoft.VisualBasic.Replace(st, " Z", "Z")
                st = Microsoft.VisualBasic.Replace(st, " I", "I")
                st = Microsoft.VisualBasic.Replace(st, " J", "J")
                st = Microsoft.VisualBasic.Replace(st, " K", "K")
                st = Microsoft.VisualBasic.Replace(st, " F", "F")
                st = Microsoft.VisualBasic.Replace(st, " P", "P")
                st = Microsoft.VisualBasic.Replace(st, " M", "M")
                st = Microsoft.VisualBasic.Replace(st, " G", "G")
                st = Microsoft.VisualBasic.Replace(st, " H", "H")
                st = Microsoft.VisualBasic.Replace(st, " D", "D")
                st = Microsoft.VisualBasic.Replace(st, " W", "W")
                st = Microsoft.VisualBasic.Replace(st, " E", "E")
                st = Microsoft.VisualBasic.Replace(st, " R", "R")
                st = Microsoft.VisualBasic.Replace(st, " S", "S")
                st = Microsoft.VisualBasic.Replace(st, " T", "T")
                st = Microsoft.VisualBasic.Replace(st, " C", "C")
                st = Microsoft.VisualBasic.Replace(st, " (", ";")

            Else
                Dim comm_pos = InStr(st, ";")
                If InStr(st, "X") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " X", " X", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Y") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Y", " Y", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Z") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Z", " Z", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "I") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " I", " I", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "J") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " J", " J", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "K") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " K", " K", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "Q") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " Q", " Q", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "R") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " R", "R", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "S") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " S", "S", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "T") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " T", "T", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "M") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " M", "M", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "F") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " F", "F", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "H") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " H", "H", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "D") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " D", "D", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "P") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " P", "P", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "W") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " W", "W", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                If InStr(st, "E") < comm_pos Then
                    st = Microsoft.VisualBasic.Replace(st, " E", "E", , 1, )
                    comm_pos = InStr(st, ";")
                End If
                st = Microsoft.VisualBasic.Replace(st, " (", ";", , 1, )
            End If
no_text:
            buffer_string.Append(st + vbCrLf)
        Next
        pg1.Visible = False
        RTB1.Text = buffer_string.ToString
        If Not Splitter.Panel2Collapsed Then
            ' Timer1.Enabled = True
        End If

    End Sub
    Private Sub _edit_window_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _edit_window.Click
        If _edit_window.Checked Then
            Splitter.Panel1.Controls.Remove(RTB1)
            Splitter.Panel1Collapsed = True
            Splitter.SplitterWidth = 1
            Splitter.BackColor = Color.Black
            un_docked_edit.Controls.Add(RTB1)
            un_docked_edit.TopMost = False
            un_docked_edit.Show()

        Else
            'un_docked_edit.Controls.Remove(RTB1)
            'Splitter.Panel1.Controls.Add(RTB1)
            'Splitter.BackColor = Color.DimGray
            'Splitter.SplitterWidth = 4
            'Splitter.Panel1Collapsed = False
            un_docked_edit.Close()
        End If

    End Sub
    Private Sub _set_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _set_font.Click
        FontDialog1.Font = RTB1.Font
        If FontDialog1.ShowDialog = Forms.DialogResult.OK Then
            RTB1.Font = FontDialog1.Font
            My.Settings.selected_font = RTB1.Font
        End If
    End Sub
    Private Sub _set_font_color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _set_font_color.Click
        ColorDialog1.Color = RTB1.ForeColor
        If ColorDialog1.ShowDialog = Forms.DialogResult.OK Then
            RTB1.ForeColor = ColorDialog1.Color
            My.Settings.font_fore_color = RTB1.ForeColor
        End If
    End Sub



    Public Sub RTB1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If _Loading Then
            Return
        End If
        If Not isInitiated Then
            Return
        End If
        Dim _end As Integer
        Dim ep As Integer
        Dim sp As Integer
        Dim _start As Integer = RTB1.SelectionStart
        Dim start_ln As Integer = RTB1.GetLineFromCharIndex(_start)
        status_ln.Text = "Ln: " + String.Format("{0}", start_ln + 1)
        If RTB1.SelectionLength = 0 Then
            _end = RTB1.SelectionStart + 1
        Else
            _end = RTB1.SelectionStart + RTB1.SelectionLength
        End If
        Dim end_ln As Integer = RTB1.GetLineFromCharIndex(_end)

        Try
            sp = lookup(start_ln).g_buff
        Catch ex As Exception
            Return
        End Try
        Try
            ep = lookup(end_ln).g_buff

        Catch ex As Exception

        End Try
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
        If lookup(start_ln).sub_call And end_ln < start_ln + 2 Then
            sp = lookup(start_ln - 1).g_buff + 1
            ep = lookup(start_ln).g_buff
        End If
        If lookup(start_ln).sub_call And start_ln = end_ln Then
            sp = lookup(start_ln - 1).g_buff + 1
            ep = lookup(start_ln).g_buff - 1
        End If
        Try
            If lookup(end_ln).sub_call Then

                ep -= 1
            End If
        Catch ex As Exception
            Return
        End Try
        Dim pnt As Integer = 0
        If ep < sp Then
            Return
        End If
        If sp <> 0 Then
            '  _SELECTED = sp
        End If
        ReDim Preserve presistent(ep - sp + 1)
        Debug.WriteLine(String.Format("sp: {0} ep:{1}", sp.ToString, ep.ToString))
        For ln = sp To ep
            sel_center_pnt = sp
            presistent(pnt) = New line_d
            Try
                ' presistent(pnt).color = draw_data(ln).color
                presistent(pnt).co_r = draw_data(ln).co_r
                presistent(pnt).co_g = draw_data(ln).co_g
                presistent(pnt).co_b = draw_data(ln).co_b
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
                presistent(pnt).valid = draw_data(ln).valid
                presistent(pnt).info_string = draw_data(ln).info_string
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
        If _auto_center And sel_center_pnt > 0 Then
            Try

                eye_x = draw_data(sel_center_pnt).ex
                eye_z = -draw_data(sel_center_pnt).ey
                eye_y = draw_data(sel_center_pnt).ez
            Catch ex As Exception
            End Try

        End If
        DrawScene()
    End Sub
    ' draw selected text subs -------------------------------------------------------- draw selected text subs
    Public Sub RTB1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not Splitter.Panel2Collapsed Then
            RTB1_SelectionChanged(sender, e)
        End If
    End Sub
    Public Sub RTB1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Loading Then
            Return
        End If
        If Not isInitiated Then
            Return
        End If
        ' RTB1._Paint = False
        'pgm_lines = RTB1.Text.Split(ChrW(10))
        ' RTB1._Paint = True
        If path.Length = 0 Then
            btn_save_as.Enabled = True
        Else
            btn_save.Enabled = True 'save
        End If
        status_t1.Text = "File Size:" + CStr(RTB1.Text.Length)
        'RTB1.Focus()
        ' RTB1.ContextMenuStrip = RTB1_C
        'undo redo functions stuff
        If Not trapUndo Then Exit Sub
        Dim newElement As New UndoElement
        Dim c%
        For c% = 1 To RedoStack.Count
            RedoStack.Remove(1)
        Next c%



        '  RTB1.SelectionLength = 0


        newElement.selectionstart = RTB1.SelectionStart
        newElement.TextLen = Len(RTB1.Text)
        newElement.Text = RTB1.Text
        UndoStack.Add(Item:=newElement)
        ' draw_all_no_auto_size()
    End Sub
    'Find screen item ----------------------------------------------------------------'Find screen item 
    Public Sub GetOGLPos(ByVal x As Integer, ByVal y As Integer, ByVal zoom As Boolean)
        If drawing_flag Then
            Return
        End If

        If Not isInitiated Then Return

        Dim viewport(4) As Integer
        Dim pixel() As Byte = {0, 0, 0}
        'ResizeGL()
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.PushMatrix()
        If zoom Then
            Wgl.wglMakeCurrent(zoom_hDC, zoom_hRC)
            ViewPerspectiveZoom()
            current_hDC = zoom_hDC
            set_eyes()
            gl_set_lights()
        Else
            GLControl1.MakeCurrent()
            ViewPerspective()
            current_hDC = hDC
            set_eyes()
            gl_set_lights()
        End If
        seek_scene()
        GL.PopMatrix()

        GL.GetInteger(GetPName.Viewport, viewport)
        GL.ReadPixels(x, viewport(3) - y, 1, 1, PixelFormat.Rgb, PixelType.UnsignedByte, pixel)
        _SELECTED = CULng(pixel(2)) + (CULng(pixel(1)) << 8) + (CULng(pixel(0)) << 16)
        Debug.WriteLine("_selected: " + _SELECTED.ToString)

        If _SELECTED > 0 Then
            If Not draw_presistent_selection Then
                draw_presistent_selection = True
                btn_draw_highlighted.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
                btn_draw_highlighted.Checked = True ' set this if it isnt on already so the graphic is highlighted
                _plot_selected.Checked = True

            End If
            If _auto_center Then
                eye_x = draw_data(_SELECTED).ex
                eye_z = -draw_data(_SELECTED).ey
                eye_y = draw_data(_SELECTED).ez
            End If

            Dim text_pnt As Integer = draw_data(_SELECTED).text_pnt
            Dim loc As Integer = RTB1.GetFirstCharIndexFromLine(text_pnt)
            Dim e_loc As Integer = RTB1.GetFirstCharIndexFromLine(text_pnt + 1)
            Try

                RTB1.Select(loc, e_loc - loc - 1)
            Catch ex As Exception

            End Try
        End If
        DrawScene()
        RTB1.Focus()
    End Sub
    Public Sub seek_scene()
        GL.Enable(EnableCap.DepthTest)
        GL.Disable(EnableCap.Lighting)
        GL.Disable(EnableCap.LineStipple)

        Dim _end As Integer = draw_data.Length - 2
        If _end <= 0 Then GoTo no_data

        Dim red, green, blue As Byte
        GL.LineWidth(5.0F)

        For El As Integer = 0 To _end
            If NO_Zs AndAlso draw_data(El).just_z Then GoTo skip_z
            If NO_RAPIDs AndAlso draw_data(El).rapid Then GoTo skip_z

            red = CByte((El And &HFF0000) >> 16)
            green = CByte((El And &HFF00) >> 8)
            blue = CByte(El And &HFF)

            GL.Color3(red, green, blue)
            GL.Begin(PrimitiveType.LineStrip)

            If draw_data(El).arc > 0 Then
                GL.Vertex3(draw_data(El).arc_data(0).x, draw_data(El).arc_data(0).z, -draw_data(El).arc_data(0).y)
                For crc_cnt = 1 To draw_data(El).arc_data.Length - 1
                    GL.Vertex3(draw_data(El).arc_data(crc_cnt).x, draw_data(El).arc_data(crc_cnt).z, -draw_data(El).arc_data(crc_cnt).y)
                Next
            Else
                GL.Vertex3(draw_data(El).sx, draw_data(El).sz, -draw_data(El).sy)
                GL.Vertex3(draw_data(El).ex, draw_data(El).ez, -draw_data(El).ey)
            End If

            GL.End()
skip_z:
        Next
no_data:
        GL.Flush()
        GL.Disable(EnableCap.DepthTest)
        GL.Enable(EnableCap.Lighting)
    End Sub
    Public Sub GetNavPos(ByVal x As Integer, ByVal y As Integer)
        If drawing_flag Then
            Return
        End If

        If Not isInitiated Then Return

        Dim viewport(4) As Integer
        Dim pixel() As Byte = {0, 0, 0}
        'ResizeGL()
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        'Debug.WriteLine("GL Error A:" + gl.GetError().ToString)
        seek_nav_scene()

        GL.GetInteger(GetPName.Viewport, viewport)
        GL.ReadPixels(x, viewport(3) - y, 1, 1, PixelFormat.Rgb, PixelType.UnsignedByte, pixel)
        selected_letter = pixel(2)

        GL.Finish()
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        DrawScene()
        RTB1.Focus()
    End Sub
    Public Sub seek_nav_scene()
        set_eyes()
        ViewOrtho()
        GL.PushMatrix()
        GL.Enable(EnableCap.DepthTest)

        Dim degree As Single = CSng(Math.PI * 2 / 360)

        GL.Scale(0.75F, 0.75F, 0.75F)
        GL.Translate(60.0F, -60.0F, -50.0F)
        GL.Rotate((Look_X_angle / degree) + 180.0F, 0.0F, -1.0F, 0.0F)
        GL.Rotate((Look_Y_angle / degree), CSng(Math.Cos(Look_X_angle)), 0.0F, CSng(-Math.Sin(Look_X_angle)))

        GL.Disable(EnableCap.Lighting)
        GL.Disable(EnableCap.Blend)

        p_nav_front(0, 0, 241)
        p_nav_back(0, 0, 242)
        p_nav_top(0, 0, 243)
        p_nav_bot(0, 0, 244)
        p_nav_right(0, 0, 245)
        p_nav_left(0, 0, 246)
        GL.Enable(EnableCap.Lighting)

        GL.Disable(EnableCap.DepthTest)
        GL.PopMatrix()
        ViewPerspective()
    End Sub
    Private Sub draw_pick_blocks()
        p_nav_front(0, 0, 241)
        p_nav_back(0, 0, 242)
        p_nav_top(0, 0, 243)
        p_nav_bot(0, 0, 244)
        p_nav_right(0, 0, 245)
        p_nav_left(0, 0, 246)

    End Sub


    'openGL crap --------------------------------------------------------------------- OpenGL crap
    Public Sub EnableOpenGL(ByVal ghDC As System.IntPtr)
        Dim pfd As Gdi.PIXELFORMATDESCRIPTOR
        Dim PixelFormat As Integer

        ZeroMemory(pfd, Len(pfd))
        'pfd.nSize = Len(pfd)
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
        If Not (Gdi.SetPixelFormat(zoom_hDC, PixelFormat, pfd)) Then
            MessageBox.Show("Unable to set pixel format")
            End
        End If
        hRC = Wgl.wglCreateContext(ghDC)
        zoom_hRC = Wgl.wglCreateContext(zoom_hDC)
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

    End Sub
    Private Sub gl_set_lights()
        GL.ClearColor(0.0F, 0.0F, 0.0F, 1.0F)

        Dim specReflection() As Single = {ambient_level * 0.8F, ambient_level * 0.8F, ambient_level * 0.8F, 1.0F}
        Dim specular() As Single = {ambient_level * 0.7F, ambient_level * 0.7F, ambient_level * 0.7F, 1.0F}
        Dim ambient() As Single = {ambient_level * 0.4F, ambient_level * 0.4F, ambient_level * 0.4F}
        Dim diffuseLight() As Single = {ambient_level * 0.6F, ambient_level * 0.6F, ambient_level * 0.6F, 1.0F}
        Dim global_ambient() As Single = {ambient_level * 0.4F, ambient_level * 0.4F, ambient_level * 0.4F, 1.0F}
        Dim emission() As Single = {0.0F, 0.0F, 0.0F, 1.0F}
        Dim mcolor() As Single = {ambient_level * 0.5F, ambient_level * 0.5F, ambient_level * 0.5F, 1.0F}

        GL.Enable(EnableCap.ColorMaterial)
        GL.Enable(EnableCap.Light0)
        GL.Enable(EnableCap.Lighting)

        GL.Light(LightName.Light0, LightParameter.Specular, specular)
        GL.Light(LightName.Light0, LightParameter.Diffuse, diffuseLight)
        GL.Light(LightName.Light0, LightParameter.Ambient, ambient)

        Dim position() As Single = {100.0F, 100.0F, 100.0F, 1.0F}
        GL.Light(LightName.Light0, LightParameter.Position, position)

        GL.LightModel(LightModelParameter.LightModelAmbient, global_ambient)

        GL.Material(MaterialFace.Front, MaterialParameter.AmbientAndDiffuse, mcolor)
        GL.Material(MaterialFace.Front, MaterialParameter.Specular, specReflection)

        GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.Emission)
        GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.AmbientAndDiffuse)

        GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 20)

        Dim localViewer() As Single = {1.0F}
        GL.LightModel(LightModelParameter.LightModelLocalViewer, localViewer)

        GL.Enable(EnableCap.PointSmooth)
    End Sub

    Sub DisableOpenGL()
        Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero)
        Wgl.wglDeleteContext(hRC)
        Wgl.wglDeleteContext(zoom_hRC)
    End Sub
    Public Sub ResizeGL()
        GL.Viewport(0, 0, GLControl1.Width, GLControl1.Height)
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()

        Dim aspectRatio As Single = CSng(GLControl1.Width) / CSng(GLControl1.Height)
        Dim projection As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.DegreesToRadians(45.0F),
            aspectRatio,
            0.02F,
            10000.0F
        )
        GL.LoadMatrix(projection)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()

    End Sub

    Public Sub Resize_zoom()
        GL.Viewport(0, 0, GLControl2.Width, GLControl2.Height)

        Dim aspectRatio As Single = CSng(GLControl2.Width) / CSng(GLControl2.Height)
        Dim projection As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(
        MathHelper.DegreesToRadians(45.0F),
        aspectRatio,
        0.02F,
        10000.0F
    )

        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadMatrix(projection)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
    End Sub


    Public Sub set_eyes()
        Dim direction As Single = 1.0!
        If Look_Y_angle < PI * 1.5 And Look_Y_angle > PI * 0.5 Then
            direction = -1.0!
        End If
        cam_y = CSng(Sin(Look_Y_angle) * look_radius)
        cam_x = CSng((Sin(Look_X_angle) - (1 - Cos(Look_Y_angle)) * Sin(Look_X_angle)) * look_radius)
        cam_z = CSng((Cos(Look_X_angle) - (1 - Cos(Look_Y_angle)) * Cos(Look_X_angle)) * look_radius)
        Glu.gluLookAt(cam_x + eye_x, cam_y + eye_y, cam_z + eye_z, eye_x, eye_y, eye_z, 0.0F, direction, 0.0F)
    End Sub
    Public Sub ViewOrtho()
        GL.MatrixMode(MatrixMode.Projection) ' Select Projection Matrix
        GL.LoadIdentity()

        GL.Ortho(0.0, GLControl1.Width, -GLControl1.Height, 0.0, 0.0001, 1000.0) ' Set orthographic projection

        GL.MatrixMode(MatrixMode.Modelview) ' Select Modelview Matrix
        GL.LoadIdentity()

        ' Optional: disable depth testing if needed for 2D overlays
        ' GL.Disable(EnableCap.DepthTest)
        ' GL.DepthMask(False)
    End Sub

    Public Sub ViewPerspective()
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()

        Dim aspect As Single = CSng(GLControl1.Width) / CSng(GLControl1.Height)
        Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(
        MathHelper.DegreesToRadians(45.0F),
        aspect,
        0.05F,
        1000.0F
    )
        GL.LoadMatrix(perspective)

        GL.Enable(EnableCap.DepthTest)
        GL.DepthMask(True)
        GL.DepthRange(0.0, 1.0)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
    End Sub
    Public Sub ViewPerspectiveZoom()
        GL.MatrixMode(MatrixMode.Projection)
        GL.LoadIdentity()

        Dim aspectRatio As Single = CSng(GLControl2.Width) / CSng(GLControl2.Height)
        Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(
        MathHelper.DegreesToRadians(zoom_factor),
        aspectRatio,
        near_clip_plane,
        100.0F
    )
        GL.LoadMatrix(perspective)

        GL.Enable(EnableCap.DepthTest)
        GL.DepthMask(True)
        GL.DepthRange(0.0, 1.0)

        GL.MatrixMode(MatrixMode.Modelview)
        GL.LoadIdentity()
    End Sub
    Private Sub build_gl_list()
        Try
            gl_list_base = GL.GenLists(3)
            If gl_list_base = 0 Then
                Throw New Exception("Failed to generate OpenGL display lists.")
            End If

            '--- Ball
            Nav_Ball = gl_list_base
            GL.NewList(Nav_Ball, ListMode.Compile)
            draw_nav_ball()
            GL.EndList()

            '--- Letters
            Nav_Letters = gl_list_base + 1
            GL.NewList(Nav_Letters, ListMode.Compile)
            create_letters()
            GL.EndList()

        Catch ex As Exception
            MessageBox.Show("OpenGL List Build Error: " & ex.Message, "GL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub create_letters()
        nav_front(0, 0, 255)

        nav_back(180, 0, 0)

        nav_top(180, 180, 180)

        nav_bot(180, 0, 127)

        nav_right(180, 180, 0)

        nav_left(0, 180, 0)

    End Sub

    ' draw subs ---------------------------------------------------------------------- draw subs

    Public Sub make_plotlist()

        Dim w(3) As Single
        Dim w2(3) As Single
        'gl.GetFloatv(gl.LINE_WIDTH_RANGE, w)
        total_lines_drawn = 0
        'gl.GetFloatv(gl.LINE_WIDTH_GRANULARITY, w2)
        Dim _end As UInteger
        Try
            _end = draw_data.Length - 2

        Catch ex As Exception
            Return
        End Try
        Dim El As UInteger = 0
        Debug.WriteLine("gl_list 0 - " + GL.GetError().ToString)

        Dim co As New Color
        Dim old_width As Single = 1.0
        Dim old_color As Color = Color.Black
        If main_plot_list > 0 Then
            GL.DeleteLists(main_plot_list, 1)
        Else
            main_plot_list = GL.GenLists(1)
        End If
        GL.NewList(main_plot_list, ListMode.Compile)

        If _end <= 0 Then GoTo no_data
        Debug.WriteLine(GL.GetError())
        Dim er = GL.GetError
        If er > 0 Then
            MsgBox("OpenGL has produced an error while" + vbCrLf +
                    "creating the main display list!" + vbCrLf +
                    "Error number: " + er.ToString, MsgBoxStyle.Exclamation, "OpenGL Error")
        End If

        ' ---- Unit scale & WCO (work offset) ----
        Dim s As Single = If(inch_metric, 1.0F, 25.4F) ' mm → inches when inch_metric=True
        Dim wcoX As Double = 0.0, wcoY As Double = 0.0, wcoZ As Double = 0.0

        If frmControl.port IsNot Nothing AndAlso frmControl.port.IsOpen Then
            If frmControl.gCodeSamples IsNot Nothing AndAlso frmControl.gCodeSamples.Length > 0 Then
                Dim s0 = frmControl.gCodeSamples(0)
                If Not Double.IsNaN(s0.WCOX) Then wcoX = s0.WCOX
                If Not Double.IsNaN(s0.WCOY) Then wcoY = s0.WCOY
                If Not Double.IsNaN(s0.WCOZ) Then wcoZ = s0.WCOZ
            End If
        End If

        GL.LineWidth(1.0!)
        Dim oldColor As Color = Color.Empty
        Dim stripOpen As Boolean = False

        For El = 0 To _end
            ' color, filtering, etc. (unchanged)

            If draw_data(El).arc > 0 Then
                ' ARC as strip
                If Not stripOpen Then
                    GL.Begin(PrimitiveType.LineStrip)
                    stripOpen = True
                End If

                ' First point (apply WORK = MPos - WCO, then unit scaling and your axis mapping)
                Dim ax As Single = CSng((draw_data(El).arc_data(0).x - wcoX) / s)
                Dim ay As Single = CSng((draw_data(El).arc_data(0).y - wcoY) / s)
                Dim az As Single = CSng((draw_data(El).arc_data(0).z - wcoZ) / s)
                GL.Vertex3(ax, az, -ay)
                total_lines_drawn += 1

                ' Remaining points
                For crc_cnt = 1 To draw_data(El).arc_data.Length - 1
                    ax = CSng((draw_data(El).arc_data(crc_cnt).x - wcoX) / s)
                    ay = CSng((draw_data(El).arc_data(crc_cnt).y - wcoY) / s)
                    az = CSng((draw_data(El).arc_data(crc_cnt).z - wcoZ) / s)
                    GL.Vertex3(ax, az, -ay)
                Next

                GL.End() : stripOpen = False

            Else
                ' STRAIGHT segment as isolated line
                If stripOpen Then GL.End() : stripOpen = False
                GL.Begin(PrimitiveType.Lines)

                Dim sx As Single = CSng((draw_data(El).sx - wcoX) / s)
                Dim sy As Single = CSng((draw_data(El).sy - wcoY) / s)
                Dim sz As Single = CSng((draw_data(El).sz - wcoZ) / s)

                Dim ex As Single = CSng((draw_data(El).ex - wcoX) / s)
                Dim ey As Single = CSng((draw_data(El).ey - wcoY) / s)
                Dim ez As Single = CSng((draw_data(El).ez - wcoZ) / s)

                ' Your axis mapping: (X, Z, -Y)
                GL.Vertex3(sx, sz, -sy)
                GL.Vertex3(ex, ez, -ey)
                GL.End()
                total_lines_drawn += 1
            End If
        Next

        If stripOpen Then GL.End()

        If draw_points Then
            GL.PointSize(3.0!)
            GL.Begin(PrimitiveType.Points)
            GL.Color3(0.0, 0.3, 1.0)
            For El = 0 To _end - 1
                If draw_data(El).valid Then
                    If NO_RAPIDs AndAlso draw_data(El).rapid Then Continue For
                    Dim px As Single = CSng((draw_data(El).ex - wcoX) / s)
                    Dim py As Single = CSng((draw_data(El).ey - wcoY) / s)
                    Dim pz As Single = CSng((draw_data(El).ez - wcoZ) / s)
                    GL.Vertex3(px, pz, -py)
                End If
            Next
            GL.End()
        End If
no_data:
        ' create_main_plot()
        GL.EndList()
        'gl.Flush()
        Debug.WriteLine("gl_list 2 - " + GL.GetError().ToString)

    End Sub

    Public Sub DrawScene()
        If Not isInitiated Then Return
        If drawing_flag Then
            Return
        End If
        drawing_flag = True
        If zoom_window.Visible Then
            Wgl.wglMakeCurrent(zoom_hDC, zoom_hRC)
            Resize_zoom()
            DrawSceneZoom()
        End If
        GLControl1.MakeCurrent()
        ResizeGL()
        DrawSceneMain()
        drawing_flag = False
    End Sub

    'draw scene subs -----------------------------
    Public Sub DrawSceneZoom()
        draw_ball = False
        gl_lighting = True

        Wgl.wglMakeCurrent(zoom_hDC, zoom_hRC)
        gl_set_lights()
        ViewPerspectiveZoom()

        If _3D Then
            GL.Enable(EnableCap.DepthTest)
        Else
            GL.Disable(EnableCap.DepthTest)
        End If
        ' ...................................................

        ' ...................................................

        set_eyes()
        'test -  draw light
        GL.PushMatrix()
        '  p_nav_front(0, 0, 0)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        GL.PopMatrix()


        GL.PushMatrix()
        GL.Scale(1.0, 1.0, -1.0)
        If draw_grid Then ' draw the grid?
            draw_XZ_grid()
        End If
        GL.PopMatrix()

        If show_stl Then
            If stl_list > 0 Then
                GL.Color3(model_color.R / 255 * color_scale, model_color.G / 255 * color_scale, model_color.B / 255 * color_scale)
                GL.Enable(EnableCap.DepthTest)
                GL.Enable(EnableCap.Lighting)
                GL.CallList(stl_list)
                '   gl.Disable(EnableCap.Lighting)
                If Not _3D Then
                    GL.Disable(EnableCap.DepthTest)
                End If
            End If
        End If
        If GL.IsList(Nav_Letters + 1) Then
            GL.CallList(main_plot_list)
        End If


        '--------------------------------------------------------------------------
        'Debug.WriteLine("GL Error A:" + gl.GetError().ToString)

        GL.Disable(EnableCap.DepthTest)
        If draw_presistent_selection Then ' if there is selected text, lets draw it!
            DrawSegment()
        End If
        If single_step Then
            single_step_plot()
        End If
        '---------------------------------------------------------------------------
        'Debug.WriteLine("GL Error B:" + gl.GetError().ToString)
        If move_mod Or z_move Or eye_target Then 'draw reference lines to eye center
            GL.Disable(EnableCap.Lighting)
            GL.Disable(EnableCap.DepthTest)
            GL.LineStipple(1, &HFF00)
            GL.Enable(EnableCap.LineStipple)
            GL.LineWidth(1)
            GL.Begin(PrimitiveType.Lines)
            GL.Color3(1.0, 1.0, 1.0)
            GL.Vertex3(eye_x, eye_y + 100, eye_z)
            GL.Vertex3(eye_x, eye_y - 100, eye_z)

            GL.Vertex3(eye_x + 100, eye_y, eye_z)
            GL.Vertex3(eye_x - 100, eye_y, eye_z)

            GL.Vertex3(eye_x, eye_y, eye_z + 100)
            GL.Vertex3(eye_x, eye_y, eye_z - 100)
            GL.End()
            GL.Disable(EnableCap.LineStipple)
            GL.Enable(EnableCap.Lighting)
        End If
        '  gl.LineStipple(1, &HFFFF)
        GL.Flush()
        'gl.Finish()
        GLControl2.SwapBuffers()
        drawing_flag = False
    End Sub

    Public Sub DrawSceneMain()

        t_stopwatch.Reset()
        t_stopwatch.Start()
        draw_ball = False
        gl_lighting = True

        'GLControl1.MakeCurrent()
        gl_set_lights()
        ViewPerspective()

        If _3D Then
            GL.Enable(EnableCap.DepthTest)
        Else
            GL.Disable(EnableCap.DepthTest)
        End If
        ' ...................................................

        ' ...................................................

        set_eyes()

        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)


        GL.PushMatrix()
        GL.Scale(1.0, 1.0, -1.0)
        If draw_grid Then ' draw the grid?
            draw_XZ_grid()
        End If
        GL.PopMatrix()

        'GL.Enable(EnableCap.Lighting)
        'GL.Disable(EnableCap.Lighting)
        If show_stl Then
            If stl_list > 0 Then
                GL.Enable(EnableCap.DepthTest)
                GL.Color3(model_color.R / 255.0! * color_scale, model_color.G / 255.0! * color_scale, model_color.B / 255.0! * color_scale)
                GL.CallList(stl_list)
                If Not _3D Then
                    GL.Disable(EnableCap.DepthTest)
                End If
            End If
        End If
        GL.Disable(EnableCap.Lighting)
        GL.Disable(EnableCap.PointSmooth)
        GL.LineWidth(1.0F)

        If GL.IsList(main_plot_list) Then
            GL.CallList(main_plot_list)
        End If
        '
        '

        info_str = ""
        '--------------------------------------------------------------------------
        If machining Then
            OpenTK.Graphics.OpenGL.GL.Color3(1.0, 1.0, 0.0)
            OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.PrimitiveType.LineStrip)

            ' Render scale: draw in inches if inch_metric=True, else mm
            Dim s As Single = 25.4F 'If(inch_metric, 25.4F, 1.0F)

            Dim firstSet As Boolean = False

            For Each sample As GCodeSample In frmControl.gCodeSamples
                If Not (Double.IsNaN(sample.MPosX) OrElse
                Double.IsNaN(sample.MPosY) OrElse
                Double.IsNaN(sample.MPosZ)) Then

                    Dim x As Single = CSng(sample.MPosX / s)
                    Dim z As Single = CSng(-sample.MPosY / s)
                    Dim y As Single = CSng(sample.MPosZ / s)

                    OpenTK.Graphics.OpenGL.GL.Vertex3(x, y, z)

                    ' only set eye_* once, for the first valid sample
                    If _auto_center AndAlso Not firstSet Then
                        eye_x = x
                        eye_y = y
                        eye_z = z
                        firstSet = True
                    End If
                End If
            Next

            OpenTK.Graphics.OpenGL.GL.End()
        End If

        '--------------------------------------------------------------------------


        GL.Disable(EnableCap.DepthTest)
        If draw_presistent_selection Then ' if there is selected text, lets draw it!
            DrawSegment()
        End If
        If single_step Then
            single_step_plot()
        End If
        '---------------------------------------------------------------------------
        If move_mod Or z_move Or eye_target Then 'draw reference lines to eye center
            GL.Disable(EnableCap.Lighting)
            GL.Disable(EnableCap.DepthTest)
            GL.LineStipple(1, &HFF00)
            GL.Enable(EnableCap.LineStipple)
            GL.LineWidth(1)
            GL.Begin(PrimitiveType.Lines)
            GL.Color3(1.0, 1.0, 1.0)
            GL.Vertex3(eye_x, eye_y + 100, eye_z)
            GL.Vertex3(eye_x, eye_y - 100, eye_z)

            GL.Vertex3(eye_x + 100, eye_y, eye_z)
            GL.Vertex3(eye_x - 100, eye_y, eye_z)

            GL.Vertex3(eye_x, eye_y, eye_z + 100)
            GL.Vertex3(eye_x, eye_y, eye_z - 100)
            GL.End()
            GL.Disable(EnableCap.LineStipple)
            GL.Enable(EnableCap.Lighting)
        End If
        GL.LineStipple(1, &HFFFF)



        ViewOrtho()

        draw_heading()
        GL.Enable(EnableCap.Lighting)

        If draw_grid Then
            status_CNC_info.Text = String.Format("Grid:{0:F2}", _gs)
        End If

        status_CNC.Text = info_str
        t_stopwatch.Stop()
        Dim ti = t_stopwatch.ElapsedMilliseconds
        t_stopwatch.Reset()
        'status_CNC_info.Text = String.Format("Screen Draw Time in ms:{0:F1}", ti)
        If show_stl Then
            If stl_list > 0 And Not codechop_loaded Then
                'glutPrint(250, -PB1.Height + 40, String.Format("STL Poly Count: {0}", stl_len.ToString), 1.0F, 1.0F, 1.0F, 1.0F)

            End If
        End If
        'glutPrint(2, -PB1.Height + 40, String.Format("Ipicked Letter:{0}", selected_letter), 1.0F, 1.0F, 1.0F, 1.0F)


        'ViewPerspective()
        GL.Flush()
        GL.Finish()
        GLControl1.SwapBuffers()
    End Sub

    Public Sub single_step_plot()
        If step_pos >= draw_data.Length - 1 Then
            'GoTo no_data 'at end of data
        End If
        GL.LineWidth(1.0!)
        'gl.Enable(gl.LINE_STIPPLE)
        'gl.LineStipple(2, &HC0C0)
        Try
            If Not draw_data(1).info_string <> Nothing Then
                Return
            End If

        Catch ex As Exception
            Return
        End Try
        Try

            GL.Color3(1.0!, 1.0!, 0!)
            GL.Begin(PrimitiveType.LineStrip)

            For El = _SELECTED To step_pos
                info_str = draw_data(El).info_string



                If draw_data(El).arc > 0 Then

                    GL.Vertex3(draw_data(El).arc_data(0).x, draw_data(El).arc_data(0).z _
                              , -draw_data(El).arc_data(0).y)

                    For crc_cnt = 1 To draw_data(El).arc_data.Length - 1
                        GL.Vertex3(draw_data(El).arc_data(crc_cnt).x, draw_data(El).arc_data(crc_cnt).z _
                                      , -draw_data(El).arc_data(crc_cnt).y)
                    Next
                Else
                    GL.Vertex3(draw_data(El).sx, draw_data(El).sz, -draw_data(El).sy)
                    GL.Vertex3(draw_data(El).ex, draw_data(El).ez, -draw_data(El).ey)
                End If

skip_z:
            Next
        Catch ex As Exception

        End Try
        GL.End()
        Application.DoEvents()
no_data:
    End Sub

    Public Sub DrawSegment()
        info_str = ""
        GL.LineWidth(1.0!)
        'Debug.WriteLine("GL Error Ba:" + gl.GetError().ToString)
        GL.Enable(EnableCap.LineStipple)
        GL.Enable(EnableCap.Blend)
        If presistent.Length > 1 Then
            Try
                GL.Color3(1.0!, 0.0!, 0.0!)

                For El = 0 To presistent.Length - 2
                    If draw_data(_SELECTED).text_pnt < sub_start_line And _SELECTED > 0 Then

                        info_str = presistent(El).info_string
                        If presistent(El).arc > 0 Then

                            GL.Begin(PrimitiveType.LineStrip)

                            GL.Vertex3(presistent(El).arc_data(0).x, presistent(El).arc_data(0).z _
                                      , -presistent(El).arc_data(0).y)

                            For crc_cnt = 1 To presistent(El).arc_data.Length - 1
                                GL.Vertex3(presistent(El).arc_data(crc_cnt).x, presistent(El).arc_data(crc_cnt).z _
                                              , -presistent(El).arc_data(crc_cnt).y)
                            Next
                            GL.End()
                        Else
                            GL.Begin(PrimitiveType.Lines)
                            GL.Vertex3(presistent(El).sx, presistent(El).sz, -presistent(El).sy)
                            GL.Vertex3(presistent(El).ex, presistent(El).ez, -presistent(El).ey)
                            GL.End()
                        End If
                    End If

                Next
            Catch ex As Exception
                GL.End()
            End Try
        End If

        'Is there sub call data selected?
        If _SELECTED > 0 Then
            If draw_data(_SELECTED).text_pnt >= sub_start_line Then 'only plot this if its part of a sub call!


                GL.Color3(1.0!, 0.0!, 0.0!)
                ' If info_str.Length = 0 Then
                info_str = draw_data(_SELECTED).info_string
                'End If

                If draw_data(_SELECTED).arc > 0 Then
                    GL.Begin(PrimitiveType.LineStrip)

                    GL.Vertex3(draw_data(_SELECTED).arc_data(0).x, draw_data(_SELECTED).arc_data(0).z _
                              , -draw_data(_SELECTED).arc_data(0).y)

                    For crc_cnt = 1 To draw_data(_SELECTED).arc_data.Length - 1
                        GL.Vertex3(draw_data(_SELECTED).arc_data(crc_cnt).x, draw_data(_SELECTED).arc_data(crc_cnt).z _
                                      , -draw_data(_SELECTED).arc_data(crc_cnt).y)
                    Next
                    GL.End()
                Else
                    GL.Begin(PrimitiveType.Lines)
                    GL.Vertex3(draw_data(_SELECTED).sx, draw_data(_SELECTED).sz, -draw_data(_SELECTED).sy)
                    GL.Vertex3(draw_data(_SELECTED).ex, draw_data(_SELECTED).ez, -draw_data(_SELECTED).ey)
                    GL.End()
                End If
                GL.End()
            End If
        End If
        GL.Disable(EnableCap.Blend)
        GL.Enable(EnableCap.LineStipple)
        GL.LineStipple(1.0!, &HFFFF)


    End Sub
    Public Sub draw_heading()
        'GL.Material(MaterialFace.Front, MaterialParameter.AmbientAndDiffuse, New Single() {0.5, 0.5, 0.5, 1})
        GL.PushAttrib(AttribMask.CurrentBit Or AttribMask.LightingBit)

        GL.PushMatrix()

        GL.Enable(EnableCap.DepthTest)
        GL.Enable(EnableCap.Lighting)
        GL.Enable(EnableCap.Normalize)

        Dim degree As Single = (PI * 2) / 360
        GL.Scale(0.75, 0.75, 0.75)
        GL.Translate(60.0, -60.0, -50.0)
        GL.Rotate((Look_X_angle / degree) + 180, 0.0F, -1.0F, 0.0F)
        GL.Rotate((Look_Y_angle / degree), CSng(Cos(Look_X_angle)) _
                     , 0.0F, CSng(-Sin(Look_X_angle)))


        Dim localViewer() As Single = {1.0F}
        GL.LightModel(LightModelParameter.LightModelLocalViewer, localViewer)

        If Not over_nav_ball Then
            GL.Color3(0.2F, 0.2F, 0.2F)                  ' reset color
            GL.CallList(Nav_Ball)

        End If
        GL.Disable(EnableCap.Lighting)
        GL.CallList(Nav_Letters)
        GL.Disable(EnableCap.DepthTest)

        'highlights selected letter
        Select Case selected_letter
            Case _front
                nav_front(255, 255, 255)
            Case _back
                nav_back(255, 255, 255)
            Case _top
                nav_top(255, 255, 255)
            Case _bottom
                nav_bot(255, 255, 255)
            Case _right
                nav_right(255, 255, 255)
            Case _left
                nav_left(255, 255, 255)
        End Select
        GL.PopMatrix()

        GL.PopAttrib()
        GL.Color3(0.1F, 0.1F, 0.1F)                  ' reset color

    End Sub
    Public Sub glutPrint(ByVal x As Single, ByVal y As Single,
                     ByVal text As String, ByVal r As Single, ByVal g As Single,
                     ByVal b As Single, ByVal a As Single)

        If String.IsNullOrEmpty(text) Then Exit Sub

        ' Save current blending state
        Dim blendingEnabled As Boolean = GL.IsEnabled(EnableCap.Blend)

        ' Enable blending for transparent text
        If Not blendingEnabled Then GL.Enable(EnableCap.Blend)

        GL.Color4(r, g, b, a)
        GL.RasterPos2(x, y)

        For Each ch As Char In text
            Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, AscW(ch))
        Next

        ' Restore previous blend state
        If Not blendingEnabled Then GL.Disable(EnableCap.Blend)

    End Sub

    Public Sub glutPrint_3d(ByVal x As Single, ByVal y As Single,
                        ByVal text As String, ByVal r As Single, ByVal g As Single,
                        ByVal b As Single, ByVal a As Single)

        If String.IsNullOrEmpty(text) Then Exit Sub

        Dim blendingEnabled As Boolean = GL.IsEnabled(EnableCap.Blend)
        If Not blendingEnabled Then GL.Enable(EnableCap.Blend)

        GL.Color4(r, g, b, a)
        GL.RasterPos2(x, y)

        For Each ch As Char In text
            Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, AscW(ch))
        Next

        If Not blendingEnabled Then GL.Disable(EnableCap.Blend)

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
        GL.Disable(EnableCap.Lighting)
        GL.LineWidth(1)
        GL.Begin(PrimitiveType.Lines)
        GL.Color3(0.64D * _grid_multi, 0.68D * _grid_multi, _grid_multi)
        For z As Single = p To p * 100 Step p
            GL.Vertex3(-p * 100, 0.0F, z)
            GL.Vertex3(p * 100, 0.0F, z)
        Next
        For z As Single = -p * 100 To -p Step p
            GL.Vertex3(-p * 100, 0.0F, z)
            GL.Vertex3(p * 100, 0.0F, z)
        Next
        For x As Single = p To p * 100 Step p
            GL.Vertex3(x, 0.0F, p * 100)
            GL.Vertex3(x, 0.0F, -p * 100)
        Next
        For x As Single = -p * 100 To -p Step p
            GL.Vertex3(x, 0.0F, p * 100)
            GL.Vertex3(x, 0.0F, -p * 100)
        Next
        GL.End()
        GL.LineWidth(1.0!)
        GL.Color3(0.6F, 0.6F, 0.6F)
        GL.Begin(PrimitiveType.Lines)
        GL.Vertex3(p, 0.0F, 0.0F)
        GL.Vertex3(-p, 0.0F, 0.0F)
        GL.Vertex3(0.0F, 0.0F, p)
        GL.Vertex3(0.0F, 0.0F, -p)
        GL.End()
        'begin axis markers
        ' red is z+
        ' green is x-
        'blue is z-
        ' yellow x+
        GL.LineWidth(1)

        GL.Begin(PrimitiveType.Lines)
        'z+ red
        GL.Color3(1.0F, 0.0F, 0.0F)
        GL.Vertex3(0.0F, 0.0F, p)
        GL.Vertex3(0.0F, 0.0F, p * 100.0F)
        'z- blue
        GL.Color3(0.0F, 0.0F, 1.0F)
        GL.Vertex3(0.0F, 0.0F, -p)
        GL.Vertex3(0.0F, 0.0F, -p * 100.0F)
        'x+ yellow
        GL.Color3(1.0F, 1.0F, 0.0F)
        GL.Vertex3(p, 0.0F, 0.0F)
        GL.Vertex3(p * 100.0F, 0.0F, 0.0F)
        'x- green
        GL.Color3(0.0F, 1.0F, 0.0F)
        GL.Vertex3(-p, 0.0F, 0.0F)
        GL.Vertex3(-p * 100.0F, 0.0F, 0.0F)
        '---------
        GL.End()
        GL.Enable(EnableCap.Lighting)



    End Sub

    'Mouse events -------------------------------------------------------------------- Mouse events
    Public Sub GLControl1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Forms.MouseButtons.Middle Then
            If e.X < 85 And e.Y < 85 Then
                Select Case selected_letter
                    Case _front
                        Look_X_angle = PI
                        Look_Y_angle = 0
                    Case _back
                        Look_X_angle = PI * 2
                        Look_Y_angle = 0
                    Case _top
                        Look_X_angle = PI
                        Look_Y_angle = PI * 1.5
                    Case _bottom
                        Look_X_angle = PI
                        Look_Y_angle = PI / 2
                    Case _right
                        Look_X_angle = PI + (PI / 2)
                        Look_Y_angle = 0
                    Case _left
                        Look_X_angle = PI / 2
                        Look_Y_angle = 0
                End Select
                Return
            End If
            first_step = True
            single_step = False
            Timer1.Enabled = False
            While drawing_flag
                Application.DoEvents()
            End While
            GetOGLPos(e.X, e.Y, False)
            'Timer1.Enabled = True
        End If
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
    Public Sub GLControl1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim dead As Integer = 2
        Dim t As Single
        Dim M_Speed As Single = 0.8
        If e.X < 85 And e.Y < 85 Then
            over_nav_ball = True
            GetNavPos(e.X, e.Y)
            'Debug.WriteLine("in")
            DrawScene()
            ' Return
        Else
            selected_letter = 0
            If over_nav_ball Then
                over_nav_ball = False
                DrawScene()
                Debug.WriteLine("out")
            End If

        End If
        Dim direction As Single = -1.0!
        If Look_Y_angle < PI * 1.5 And Look_Y_angle > PI * 0.5 Then
            direction = 1.0!
        End If
        Dim m_x As Single = (mouse.X - e.X)
        m_x *= direction
        Dim ms As Single = 0.2F * look_radius ' distance away changes speed.. THIS WORKS WELL!
        If M_DOWN Then
            If m_x > 2 Then
                If m_x > 100 Then t = (M_Speed)
            Else
                t = CSng(Sin(m_x / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x -= ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_z -= ((t * ms) * CSng((-Sin(Look_X_angle))))
                    Else
                        Look_X_angle -= t
                    End If
                    If Look_X_angle > (2 * PI) Then Look_X_angle -= CSng((2D * PI))
                    mouse.X = e.X
                End If
            End If
            If m_x < 2 Then
                If m_x < 100 Then t = (-M_Speed)
            Else
                t = CSng(Sin(-m_x / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x += ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_z += ((t * ms) * CSng((-Sin(Look_X_angle))))
                    Else
                        Look_X_angle += t
                    End If
                    If Look_X_angle < 0 Then Look_X_angle += CSng((2 * PI))
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
                        eye_z -= ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_x -= ((t * ms) * CSng((Sin(Look_X_angle))))
                    Else
                        Look_Y_angle -= t
                    End If
                    If Look_Y_angle < 0 Then Look_Y_angle += CSng((2 * PI))
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
                        eye_z += ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_x += ((t * ms) * CSng((Sin(Look_X_angle))))
                    Else
                        Look_Y_angle += t
                    End If
                    If Look_Y_angle > (2 * PI) Then Look_Y_angle -= CSng((2D * PI))
                End If
                mouse.Y = e.Y
            End If
            If Not over_nav_ball Then
                DrawScene()
            End If
        End If
        If move_cam_z Then
            If e.Y > (mouse.Y + dead) Then
                If e.Y - mouse.Y > 100 Then t = (10)
            Else : t = CSng(Sin((e.Y - mouse.Y) / 100)) * 12
                look_radius += (t * (look_radius * 0.2D)) ' zoom is factored in to look radius
                mouse.Y = e.Y
            End If
            If e.Y < (mouse.Y - dead) Then
                If mouse.Y - e.Y > 100 Then t = (10)
            Else : t = CSng(Sin((mouse.Y - e.Y) / 100)) * 12
                look_radius -= (t * (look_radius * 0.2D)) ' zoom is factored in to look radius
                If look_radius > -0.1 Then look_radius = -0.1
                mouse.Y = e.Y
            End If
            If look_radius > -0.001 Then look_radius = -0.001
            If Not over_nav_ball Then
                DrawScene()
            End If
        End If
    End Sub
    Public Sub GLControl1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
    Public Sub PB1_Paint()
        'DrawScene()
    End Sub
    Public Sub GLControl1_MouseLeave()
        selected_letter = 0
        over_nav_ball = False
        DrawScene()
    End Sub


    Public Sub GLControl2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Forms.MouseButtons.Middle Then
            first_step = True
            single_step = False
            Timer1.Enabled = False
            While drawing_flag
                Application.DoEvents()
            End While
            GetOGLPos(e.X, e.Y, True)
            'Timer1.Enabled = True
        End If
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
    Public Sub GLControl2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim dead As Integer = 2
        Dim t As Single
        Dim M_Speed As Single = 0.8

        Dim direction As Single = -1.0!
        If Look_Y_angle < PI * 1.5 And Look_Y_angle > PI * 0.5 Then
            direction = 1.0!
        End If
        Dim m_x As Single = (mouse.X - e.X)
        m_x *= direction
        Dim ms As Single = 0.2F * look_radius ' distance away changes speed.. THIS WORKS WELL!
        If M_DOWN Then
            If m_x > 2 Then
                If m_x > 100 Then t = (M_Speed)
            Else
                t = CSng(Sin(m_x / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x -= ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_z -= ((t * ms) * CSng((-Sin(Look_X_angle))))
                    Else
                        Look_X_angle -= t
                    End If
                    If Look_X_angle > (2 * PI) Then Look_X_angle -= CSng((2D * PI))
                    mouse.X = e.X
                End If
            End If
            If m_x < 2 Then
                If m_x < 100 Then t = (-M_Speed)
            Else
                t = CSng(Sin(-m_x / 100)) * M_Speed
                If Not z_move Then
                    If move_mod Then ' check for modifying flag
                        eye_x += ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_z += ((t * ms) * CSng((-Sin(Look_X_angle))))
                    Else
                        Look_X_angle += t
                    End If
                    If Look_X_angle < 0 Then Look_X_angle += CSng((2 * PI))
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
                        eye_z -= ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_x -= ((t * ms) * CSng((Sin(Look_X_angle))))
                    Else
                        Look_Y_angle -= t
                    End If
                    If Look_Y_angle < 0 Then Look_Y_angle += CSng((2 * PI))
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
                        eye_z += ((t * ms) * CSng((Cos(Look_X_angle))))
                        eye_x += ((t * ms) * CSng((Sin(Look_X_angle))))
                    Else
                        Look_Y_angle += t
                    End If
                    If Look_Y_angle > (2 * PI) Then Look_Y_angle -= CSng((2D * PI))
                End If
                mouse.Y = e.Y
            End If
            If Not over_nav_ball Then
                DrawScene()
            End If
        End If
        If move_cam_z Then
            If e.Y > (mouse.Y + dead) Then
                If e.Y - mouse.Y > 100 Then t = (10)
            Else : t = CSng(Sin((e.Y - mouse.Y) / 100)) * 12
                look_radius += (t * (look_radius * 0.2D)) ' zoom is factored in to look radius
                mouse.Y = e.Y
            End If
            If e.Y < (mouse.Y - dead) Then
                If mouse.Y - e.Y > 100 Then t = (10)
            Else : t = CSng(Sin((mouse.Y - e.Y) / 100)) * 12
                look_radius -= (t * (look_radius * 0.2D)) ' zoom is factored in to look radius
                If look_radius > -0.1 Then look_radius = -0.1
                mouse.Y = e.Y
            End If
            If look_radius > -0.1 Then look_radius = -0.1
            If Not over_nav_ball Then
                DrawScene()
            End If
        End If
    End Sub

    ' Splitter change events --------------------------------------------------------- Splitter change events
    Private Sub Splitter_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Splitter.SplitterMoved
        Dim off As Integer
        If Splitter.SplitterDistance = 0 Then
            Return
        End If
        If Splitter.Orientation = Orientation.Horizontal Then
            off = Splitter.Panel1.Height - sp_w
        Else
            off = Splitter.Panel1.Width - sp_w
        End If

        If plot_toolbar.Controls.Count > 4 Then
            If Splitter.Orientation = Orientation.Horizontal Then
                For I = 3 To plot_toolbar.Controls.Count - 1
                    plot_toolbar.Controls(I).Location = New Point(plot_toolbar.Controls(I).Location.X + off, plot_toolbar.Controls(I).Location.Y)
                Next
            Else
                For I = 3 To plot_toolbar.Controls.Count - 1
                    plot_toolbar.Controls(I).Location = New Point(plot_toolbar.Controls(I).Location.X + off, plot_toolbar.Controls(I).Location.Y)
                Next
            End If
        End If
        If Splitter.Orientation = Orientation.Horizontal Then
            sp_w = Splitter.Panel1.Height
        Else
            sp_w = Splitter.Panel1.Width
        End If

        DrawScene()
        'RTB1.Width = Splitter.Panel1.Width - 15
        RTB1.Update()
        '        _Paint = True
        RTB1.Focus()
    End Sub
    Private Sub Splitter_SplitterMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs) Handles Splitter.SplitterMoving
        If Not Splitter.Orientation = Orientation.Horizontal Then
            sp_w = Splitter.Panel1.Width
        Else
            sp_w = Splitter.Panel1.Height

        End If
        ' _Paint = False
    End Sub

    ' RTB1 Menu subs ----------------------------------------------------------------- RTB1 Menu subs 



    Public Sub clear_selection()
        ReDim Preserve presistent(1)
        draw_presistent_selection = False
        btn_draw_highlighted.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        btn_draw_highlighted.Checked = False
        _plot_selected.Checked = False
        step_pos = 0
        _SELECTED = 0
    End Sub

    Public Sub draw_all()

        Dim CORE As New op_core

        x_max = -10000
        x_min = 10000
        y_max = -10000
        y_min = 10000
        z_max = -10000
        z_min = 10000
        Dim o_eye_x = eye_x
        Dim o_eye_y = eye_y
        Dim o_eye_z = eye_z
        status_t2.Text = "Building Graphics"
        pg1.Visible = True
        set_pg1_size()
        pg1.BringToFront()

        pg1.Width = Splitter.Panel2.Width
        pg1.Height = 15

        If CORE.run() Then
            clear_arrays()
            make_plotlist()
            eye_x = o_eye_x
            eye_y = -o_eye_y
            eye_z = -o_eye_z
            pg1.Visible = False
            Try
                status_t2.Text = "Tot Lines Drawn: " + CStr(draw_data.Length - 1)

            Catch ex As Exception
                status_t2.Text = "Tot Lines Drawn: 0"
            End Try
            DrawScene()
            Return
        End If
        Try
            status_t2.Text = "Tot Lines Drawn: " + CStr(draw_data.Length - 1)

        Catch ex As Exception
            status_t2.Text = "Tot Lines Drawn: 0"
        End Try
        'cam_x = 0
        'cam_y = 0
        'cam_z = 6
        'Look_at_X = 0
        'Look_at_Y = 0
        'Look_at_Z = 0
        'look_radius = -20.0
        'Look_X_angle = -PI

        'eye_x = (x_max + x_min) / 2
        'eye_z = (y_max + y_min) / 2 ' y / z swaped for opengl viewing
        ' eye_z = (z_max + z_min) / 2

        ''look_radius = -Sqrt((eye_x * eye_x) + (eye_y * eye_y) + (eye_z * eye_z)) * 20
        look_radius = 0 - ((x_max - x_min) + (y_max - y_min))
        pg1.SendToBack()
        pg1.Visible = False
        make_plotlist()
        status_t2.Text = "Tot Lines Drawn: " + CStr(total_lines_drawn)
        DrawScene()
    End Sub
    'Public Sub draw_all_no_auto_size()
    '    Dim CORE As New op_core
    '    x_max = -10000
    '    x_min = 10000
    '    y_max = -10000
    '    y_min = 10000
    '    z_max = -10000
    '    z_min = 10000

    '    status_t2.Text = "Building Graphics"
    '    pg1.Visible = True
    '    set_pg1_size()
    '    CORE.run()
    '    status_t2.Text = "Tot Lines Drawn: " + CStr(draw_data.Length - 1)
    '    cam_x = 0
    '    cam_y = 0
    '    cam_z = 6
    '    Look_at_X = 0
    '    Look_at_Y = 0
    '    Look_at_Z = 0
    '    look_radius = -20.0
    '    Look_X_angle = 0

    '    eye_x = (x_max + x_min) / 2
    '    eye_z = (y_max + y_min) / 2 ' y / z swaped for opengl viewing
    '    eye_y = (z_max + z_min) / 2
    '    'look_radius = -Sqrt((eye_x * eye_x) + (eye_y * eye_y) + (eye_z * eye_z)) * 20
    '    look_radius = 0 - ((x_max - x_min) + (y_max - y_min))
    '    pg1.Visible = False
    '    DrawScene()
    'End Sub


    ' form resize ------------------------------------------------------------------- form resize subs
    Private Sub frmMain_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        ' My.Settings.main_split_distance = Splitter.SplitterDistance
    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If isInitiated And Me.WindowState = FormWindowState.Minimized Or Me.WindowState = FormWindowState.Maximized Then
            Me.Height = form_height
            Me.Width = form_width
            Me.Size = form_client_size
        End If
        If Splitter.SplitterDistance <> 0 Then
            Splitter.SplitterDistance = sp_w
        End If
        pg1.Width = Splitter.Panel2.Width
        Me.Update()
    End Sub
    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If isInitiated And Me.WindowState <> FormWindowState.Minimized And Me.WindowState <> FormWindowState.Maximized Then
            form_height = Me.Height
            form_width = Me.Width
            form_client_size = Me.Size
        End If
    End Sub


    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

        If isInitiated And Me.WindowState <> FormWindowState.Minimized And Me.WindowState <> FormWindowState.Maximized Then
            form_height = Me.Height
            form_width = Me.Width
            form_client_size = Me.Size
        End If
        Splitter.IsSplitterFixed = False
        DrawScene()

    End Sub


    ' key functions ----------------------------------------------------------------- key functions
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 16 Then
            If Not move_mod Then
                move_mod = True ' SHIFT KET
                If Not btn_draw_eye_center.Checked Then
                    btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
                End If
                eye_target = True
                DrawScene()
            End If
        End If
        If e.KeyCode = 17 Then
            If Not z_move Then
                z_move = True ' CTRL KEY
                If Not btn_draw_eye_center.Checked Then
                    btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
                End If
                eye_target = True
                DrawScene()
            End If
        End If
    End Sub
    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then

            If Not _edit_window.Checked Then
                _edit_window.Checked = True
                Splitter.Panel1.Controls.Remove(RTB1)
                Splitter.Panel1Collapsed = True
                Splitter.SplitterWidth = 1
                Splitter.BackColor = Color.Black
                un_docked_edit.Controls.Add(RTB1)
                un_docked_edit.TopMost = False
                un_docked_edit.Show()

            Else
                '_edit_window.Checked = False
                'un_docked_edit.Controls.Remove(RTB1)
                'Splitter.Panel1.Controls.Add(RTB1)
                'Splitter.BackColor = Color.DimGray
                'Splitter.SplitterWidth = 4
                'Splitter.Panel1Collapsed = False

                un_docked_edit.Close()
            End If
            Return
        End If
        If e.KeyCode = Keys.F3 Then
            _btn_find_next()
            Return
        End If
        If e.KeyCode = Keys.F4 Then
            _btn_replace()
            Return
        End If
        If move_mod Then
            move_mod = False
            If Not btn_draw_eye_center.Checked Then
                btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            End If
            eye_target = btn_draw_eye_center.Checked
            DrawScene()
        End If
        If z_move Then
            z_move = False
            If Not btn_draw_eye_center.Checked Then
                btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            End If
            eye_target = btn_draw_eye_center.Checked
            DrawScene()
        End If
    End Sub

    'RTF Form's Code
    '------------------------------------------
    Public Sub Redo()
        Dim chg$
        Dim DeleteFlag As Boolean
        Dim objElement As Object
        If RedoStack.Count > 0 And trapUndo Then
            trapUndo = False
            DeleteFlag = CBool(RedoStack(RedoStack.Count).TextLen < Len(RTB1.Text))
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
                If objElement.selectionstart - (objElement.TextLen - objElement2.TextLen) < 0 Then
                    Return
                End If
                RTB1.SelectionStart = objElement.selectionstart - (objElement.TextLen - objElement2.TextLen)
                RTB1.SelectionLength = objElement.TextLen - objElement2.TextLen
                RTB1.SelectedText = ""
                x& = SendMessage(RTB1.Handle, Xport.RichEditControl.EM_HIDESELECTION, 0&, 0&)
            Else
                objElement = UndoStack(UndoStack.Count - 1)
                objElement2 = UndoStack(UndoStack.Count)
                chg$ = Change(objElement.Text, objElement2.Text,
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
        Change = Mid(lParam2, startSearch - d, d)
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


    ' Numbering subs ---------------------------------------------------------------------- Numbering Subs
    Public Function find_number(ByVal ln As String, ByRef n_start As UInteger, ByRef n_end As UInteger, ByVal pos As Integer, ByRef old_pos As Integer) As Boolean
        Dim loc As Integer = 0
        Dim z As Integer = 0
        Dim out_str As String = ""
        Dim s As String = ""
        Dim c As Integer = 0
        Dim com As Integer = InStr(ln, ";")
        If com = 1 Then Return True ' comment as start of line
        If com = 0 Then com = 1000
        loc = InStr(ln, "N")
        If loc = 0 Then
            n_start = loc
            n_end = loc
            Return False ' no comment
        End If
        n_start = loc - 1
        If loc > com Then ' make sure we dont return comment valuse.. :)
            n_start = loc
            n_end = loc
            Return True ' yes a comment
        End If
        For z = loc To ln.Length - 1
            c += 1
            s = Mid(ln, loc + 1, 1)
            If _IsNumeric(s) Then
                out_str += s
                loc += 1
            ElseIf s = "-" Or s = "." Then
                out_str += s
                loc += 1
            ElseIf Not _IsNumeric(s) Then
                Exit For

            End If
            n_end = n_start + z

        Next
        If c = 1 And Not _IsNumeric(s) Then
            Dim l = pos + 1
            MsgBox("Number Format error in line:" + vbCrLf + vbCrLf + ln + vbCrLf + vbCrLf + "at line number: " + l.ToString, MsgBoxStyle.Exclamation, "Format Error")

            old_pos = pos
            Return True

        End If
        Return False ' no comment
    End Function

    Public Sub strip_line_numbers()
        Dim st As New StringBuilder
        Dim old_pos = 0 'RTB1.SelectionStart
        st.Length = 0
        '
        Dim lines = RTB1.Text.Split(ChrW(10))
        Dim pos As UInteger = 0
        Dim sel_start, sel_end As Integer
        Dim ts, te, fs As String
        Dim comment As Boolean = False
        If lines.Length = 0 Then
            Return
        End If

        For Each ln In lines
            fs = ln
            If InStr(ln, "O") = 1 Then GoTo skip ' program name
            If InStr(ln, "%") > 0 Then GoTo skip
            If InStr(ln, ";") > 1 Then GoTo skip
            If fs.Length = 0 Then GoTo skip ' dont want to num null lines
            comment = find_number(ln, sel_start, sel_end, pos, old_pos)
            If comment Then GoTo skip ' no number
            If sel_end = sel_start Then
                ts = ""
                te = ln
            Else
                ts = Microsoft.VisualBasic.Mid(ln, 1, sel_start)
                te = Microsoft.VisualBasic.Mid(ln, sel_start + 1 + sel_end + 1)
            End If
            fs = ts + te
skip:
            Application.DoEvents()
            st.Append(fs + vbCrLf)
            pos += 1
        Next
        RTB1.Text = st.ToString
        If old_pos > 0 Then
            Dim sl = RTB1.GetFirstCharIndexFromLine(old_pos)
            RTB1.SelectionStart = sl + 1
            RTB1.SelectionLength = 1
        End If
        Application.DoEvents()
        RTB1.Focus()
    End Sub

    ' Build STL --------------------------------------------------------------------------- Build STL
    Public Sub build_stl(ByVal name As String)



        Dim size As Integer = 1
        Dim f As StreamReader = New StreamReader(name)
        Dim s As String
        Dim fp As Integer = 0
        Dim fss As FileStream
        s = f.ReadLine
        Dim d As IO.FileInfo = New FileInfo(name)
        Dim fs = d.Length
        fp += s.Length
        pg1.Minimum = 0
        pg1.Maximum = fs
        pg1.Visible = True
        set_pg1_size()
        s = f.ReadLine
        If Not InStr(s, "facet") > 0 Then
            f.Close()
            f.Dispose()

            fss = New FileStream(name, FileMode.Open)
            Dim r As New BinaryReader(fss)
            fp = 0
            For i = 1 To 80
                r.ReadByte()
            Next
            fp = 79
            Try
                size = r.ReadInt32

            Catch ex As Exception
                MsgBox("Bad File Format!", MsgBoxStyle.Critical, "File Type Error")
                fss.Dispose()
                pg1.Hide()
                Return
            End Try
            fp += 4

            ReDim Preserve stl(size)
            For i = 0 To size - 1
                stl(i) = New Vertex_data
                'get normals
                stl(i).nx = r.ReadSingle
                stl(i).ny = r.ReadSingle
                stl(i).nz = r.ReadSingle
                'get vertex 1
                stl(i).x1 = r.ReadSingle
                stl(i).y1 = r.ReadSingle
                stl(i).z1 = r.ReadSingle
                'get vertex 2
                stl(i).x2 = r.ReadSingle
                stl(i).y2 = r.ReadSingle
                stl(i).z2 = r.ReadSingle
                'get vertex 3
                stl(i).x3 = r.ReadSingle
                stl(i).y3 = r.ReadSingle
                stl(i).z3 = r.ReadSingle
                'read dummy attribute
                r.ReadInt16()
                fp += 50
            Next
            fss.Dispose()
            GoTo finish_stl
        Else

        End If

        size = 0
        While (f.ReadLine <> Nothing) ' get line count
            size += 1
        End While
        size = (size - 2) / 7
        ReDim Preserve stl(size)
        f.Close()
        f = New StreamReader(name)
        f.ReadLine() ' kill Solid tag

        For i = 0 To size
            stl(i) = New Vertex_data
            s = f.ReadLine
            fp += s.Length
            If InStr(s, "endsolid") > 0 Then Exit For
            If InStr(s, "end solid") > 0 Then Exit For
            Dim data0 = s.Split("normal")
            s = Microsoft.VisualBasic.Replace(data0(1), ChrW(9), " ") ' strip tabs and convert if present
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' replace dbl space with single
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' this will replace triple spaced
            s = Microsoft.VisualBasic.Replace(s, " ", "#") ' strip spaces and conver to pound sign. This makes it easy to split
            Dim data = s.Split("#")
            stl(i).nx = CSng(data(1)) ' save normals
            stl(i).ny = CSng(data(2))
            stl(i).nz = CSng(data(3))
            s = f.ReadLine ' read dummy line 'outter loop'
            fp += s.Length

            'get first vertex coords
            s = f.ReadLine ' read actual
            fp += s.Length
            data0 = s.Split("vertex")
            s = Microsoft.VisualBasic.Replace(data0(1), ChrW(9), " ") ' strip tabs and convert if present
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' replace dbl space with single
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' this will replace triple spaced
            s = Microsoft.VisualBasic.Replace(s, " ", "#") ' strip spaces and conver to pound sign. This makes it easy to split
            data = s.Split("#")
            stl(i).x1 = CSng(data(1)) ' save vertex
            stl(i).y1 = CSng(data(2))
            stl(i).z1 = CSng(data(3))

            'get second vertex coords
            s = f.ReadLine ' read actual
            fp += s.Length
            data0 = s.Split("vertex")
            s = Microsoft.VisualBasic.Replace(data0(1), ChrW(9), " ") ' strip tabs and convert if present
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' replace dbl space with single
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' this will replace triple spaced
            s = Microsoft.VisualBasic.Replace(s, " ", "#") ' strip spaces and conver to pound sign. This makes it easy to split
            data = s.Split("#")
            stl(i).x2 = CSng(data(1)) ' save vertex
            stl(i).y2 = CSng(data(2))
            stl(i).z2 = CSng(data(3))

            'get third vertex coords
            s = f.ReadLine ' read actual
            fp += s.Length
            data0 = s.Split("vertex")
            s = Microsoft.VisualBasic.Replace(data0(1), ChrW(9), " ") ' strip tabs and convert if present
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' replace dbl space with single
            s = Microsoft.VisualBasic.Replace(s, "  ", " ") ' this will replace triple spaced
            s = Microsoft.VisualBasic.Replace(s, " ", "#") ' strip spaces and conver to pound sign. This makes it easy to split
            data = s.Split("#")
            stl(i).x3 = CSng(data(1)) ' save vertex
            stl(i).y3 = CSng(data(2))
            stl(i).z3 = CSng(data(3))

            s = f.ReadLine ' read dummy "endloop' line
            fp += s.Length
            s = f.ReadLine ' read dummy "endfacet' line
            fp += s.Length

            pg1.Value = fp
        Next i
        f.Dispose()
finish_stl:

        pg1.Visible = False
        stl_len = stl.Length - 2
        If stl_list > 0 Then
            GL.DeleteLists(stl_list, 1)
        End If
        stl_list = GL.GenLists(1)
        GL.NewList(stl_list, ListMode.Compile)
        GL.Begin(PrimitiveType.Triangles)

        For i = 0 To stl_len
            'normal
            GL.Normal3(stl(i).nx, stl(i).nz, -stl(i).ny)
            'v1
            GL.Vertex3(stl(i).x2, stl(i).z2, -stl(i).y2)
            'v2
            GL.Vertex3(stl(i).x1, stl(i).z1, -stl(i).y1)
            'v3
            GL.Vertex3(stl(i).x3, stl(i).z3, -stl(i).y3)

        Next
        GL.End()
        ReDim stl(1)
        GL.EndList()
        If Not Lighting.CheckBox1.Checked Then
            Lighting.CheckBox1.Checked = True
        End If
        DrawScene()
    End Sub
    Public Sub delete_stl()
        GL.DeleteLists(stl_list, 1)
        stl_list = -1
        codechop_loaded = False
    End Sub

    ' bar graph size/location
    Public Sub set_pg1_size()
        pg1.BringToFront()

        pg1.Width = Splitter.Panel2.Width
        pg1.Location = New Point(0, Splitter.Panel2.Height - pg1.Height)
    End Sub
    Public Sub offset_x_text_changed(ByVal id As Integer, ByVal tb As TextBox)
        If tb.Text.Length = 0 Then Return
        If tb.Text.Length = 1 Then
            If InStr(tb.Text, ".") = 1 Or InStr(tb.Text, ".") = 2 Then
                Return
            End If
        End If
        If tb.Text.Length = 1 And
        InStr(tb.Text, "-") = 1 Then Return

        If Not IsNumeric(tb.Text) Then
            MsgBox("Numeric Only Please...", MsgBoxStyle.OkOnly, "Number Format Error")
            Return
        End If
        Dim v = CDec(tb.Text)
        offset_x(id) = v
    End Sub
    Public Sub offset_y_text_changed(ByVal id As Integer, ByVal tb As TextBox)
        If tb.Text.Length = 0 Then Return
        If tb.Text.Length = 1 Then
            If InStr(tb.Text, ".") = 1 Or InStr(tb.Text, ".") = 2 Then
                Return
            End If
        End If
        If tb.Text.Length = 1 And
        InStr(tb.Text, "-") = 1 Then Return

        If Not IsNumeric(tb.Text) Then
            MsgBox("Numeric Only Please...", MsgBoxStyle.OkOnly, "Number Format Error")
            Return
        End If
        Dim v = CDec(tb.Text)
        offset_y(id) = v
    End Sub

End Class
