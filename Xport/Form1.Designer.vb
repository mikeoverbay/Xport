<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.Split_Panel = New System.Windows.Forms.SplitContainer
        Me.Splitter = New System.Windows.Forms.SplitContainer
        Me.pg1 = New System.Windows.Forms.ProgressBar
        Me.RTB1 = New System.Windows.Forms.RichTextBox
        Me.RTB1_C = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me._undo = New System.Windows.Forms.ToolStripMenuItem
        Me._redo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me._cut = New System.Windows.Forms.ToolStripMenuItem
        Me._copy = New System.Windows.Forms.ToolStripMenuItem
        Me._paste = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me._delete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me._sel_all = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me._plot_selected = New System.Windows.Forms.ToolStripMenuItem
        Me._center_selected = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.status_t1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.status_t2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me._grid_brightness = New System.Windows.Forms.ToolStripComboBox
        Me._rewind = New System.Windows.Forms.ToolStripMenuItem
        Me._play = New System.Windows.Forms.ToolStripMenuItem
        Me._foward = New System.Windows.Forms.ToolStripMenuItem
        Me._exit = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideZOnlyMovesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideRapidMovesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DrawGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._gl_depth_test = New System.Windows.Forms.ToolStripMenuItem
        Me._lighting = New System.Windows.Forms.ToolStripMenuItem
        Me._prompts = New System.Windows.Forms.ToolStripMenuItem
        Me.DrawTestObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._lable_1 = New System.Windows.Forms.ToolStripTextBox
        Me._ambient = New System.Windows.Forms.ToolStripComboBox
        Me._show_eye_center = New System.Windows.Forms.ToolStripMenuItem
        Me.cancel_read_btn = New System.Windows.Forms.Button
        Me.cancel_send_btn = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Bits = New System.Windows.Forms.ComboBox
        Me.recv_btn = New System.Windows.Forms.Button
        Me.send_btn = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.port = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.baud = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.parity = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.stopbits = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.handshake = New System.Windows.Forms.ComboBox
        Me.comp_text_btn = New System.Windows.Forms.Button
        Me.sep_text_btn = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me._new_file = New System.Windows.Forms.ToolStripMenuItem
        Me._open = New System.Windows.Forms.ToolStripMenuItem
        Me._save = New System.Windows.Forms.ToolStripMenuItem
        Me._save_as = New System.Windows.Forms.ToolStripMenuItem
        Me.font_size = New System.Windows.Forms.ToolStripComboBox
        Me._auto_center_selected = New System.Windows.Forms.ToolStripMenuItem
        Me._plot = New System.Windows.Forms.ToolStripMenuItem
        Me.orintation = New System.Windows.Forms.ToolStripMenuItem
        Me._rotate = New System.Windows.Forms.ToolStripMenuItem
        Me.Com_btn = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Split_Panel.Panel1.SuspendLayout()
        Me.Split_Panel.Panel2.SuspendLayout()
        Me.Split_Panel.SuspendLayout()
        Me.Splitter.Panel1.SuspendLayout()
        Me.Splitter.Panel2.SuspendLayout()
        Me.Splitter.SuspendLayout()
        Me.RTB1_C.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Split_Panel
        '
        Me.Split_Panel.BackColor = System.Drawing.Color.DarkGray
        Me.Split_Panel.DataBindings.Add(New System.Windows.Forms.Binding("Panel2Collapsed", Global.Xport.My.MySettings.Default, "p2_collapsed", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Split_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Split_Panel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.Split_Panel.IsSplitterFixed = True
        Me.Split_Panel.Location = New System.Drawing.Point(0, 25)
        Me.Split_Panel.Name = "Split_Panel"
        '
        'Split_Panel.Panel1
        '
        Me.Split_Panel.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Split_Panel.Panel1.Controls.Add(Me.Splitter)
        '
        'Split_Panel.Panel2
        '
        Me.Split_Panel.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Split_Panel.Panel2.Controls.Add(Me.cancel_read_btn)
        Me.Split_Panel.Panel2.Controls.Add(Me.cancel_send_btn)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label6)
        Me.Split_Panel.Panel2.Controls.Add(Me.Bits)
        Me.Split_Panel.Panel2.Controls.Add(Me.recv_btn)
        Me.Split_Panel.Panel2.Controls.Add(Me.send_btn)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label5)
        Me.Split_Panel.Panel2.Controls.Add(Me.port)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label4)
        Me.Split_Panel.Panel2.Controls.Add(Me.baud)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label3)
        Me.Split_Panel.Panel2.Controls.Add(Me.parity)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label2)
        Me.Split_Panel.Panel2.Controls.Add(Me.stopbits)
        Me.Split_Panel.Panel2.Controls.Add(Me.Label1)
        Me.Split_Panel.Panel2.Controls.Add(Me.handshake)
        Me.Split_Panel.Panel2.ForeColor = System.Drawing.Color.White
        Me.Split_Panel.Panel2Collapsed = Global.Xport.My.MySettings.Default.p2_collapsed
        Me.Split_Panel.Panel2MinSize = 0
        Me.Split_Panel.Size = New System.Drawing.Size(660, 432)
        Me.Split_Panel.SplitterDistance = 518
        Me.Split_Panel.SplitterWidth = 5
        Me.Split_Panel.TabIndex = 0
        '
        'Splitter
        '
        Me.Splitter.BackColor = System.Drawing.Color.Gray
        Me.Splitter.DataBindings.Add(New System.Windows.Forms.Binding("Panel2Collapsed", Global.Xport.My.MySettings.Default, "main_splitter_p2_collapsed", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Splitter.DataBindings.Add(New System.Windows.Forms.Binding("SplitterDistance", Global.Xport.My.MySettings.Default, "main_split_distance", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Splitter.Location = New System.Drawing.Point(0, 0)
        Me.Splitter.Name = "Splitter"
        '
        'Splitter.Panel1
        '
        Me.Splitter.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Splitter.Panel1.Controls.Add(Me.pg1)
        Me.Splitter.Panel1.Controls.Add(Me.RTB1)
        Me.Splitter.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Splitter.Panel1MinSize = 250
        '
        'Splitter.Panel2
        '
        Me.Splitter.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Splitter.Panel2.Controls.Add(Me.MenuStrip2)
        Me.Splitter.Panel2.ForeColor = System.Drawing.Color.Transparent
        Me.Splitter.Panel2Collapsed = Global.Xport.My.MySettings.Default.main_splitter_p2_collapsed
        Me.Splitter.Panel2MinSize = 0
        Me.Splitter.Size = New System.Drawing.Size(660, 432)
        Me.Splitter.SplitterDistance = Global.Xport.My.MySettings.Default.main_split_distance
        Me.Splitter.TabIndex = 4
        '
        'pg1
        '
        Me.pg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pg1.Location = New System.Drawing.Point(0, 0)
        Me.pg1.Name = "pg1"
        Me.pg1.Size = New System.Drawing.Size(318, 13)
        Me.pg1.TabIndex = 3
        Me.pg1.Visible = False
        '
        'RTB1
        '
        Me.RTB1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.RTB1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTB1.ContextMenuStrip = Me.RTB1_C
        Me.RTB1.Font = New System.Drawing.Font("Lucida Console", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB1.ForeColor = System.Drawing.Color.White
        Me.RTB1.Location = New System.Drawing.Point(10, 0)
        Me.RTB1.Name = "RTB1"
        Me.RTB1.Size = New System.Drawing.Size(306, 410)
        Me.RTB1.TabIndex = 1
        Me.RTB1.Text = ""
        Me.RTB1.WordWrap = False
        '
        'RTB1_C
        '
        Me.RTB1_C.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RTB1_C.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._undo, Me._redo, Me.ToolStripSeparator2, Me._cut, Me._copy, Me._paste, Me.ToolStripSeparator4, Me._delete, Me.ToolStripSeparator3, Me._sel_all, Me.ToolStripSeparator5, Me._plot_selected, Me._center_selected})
        Me.RTB1_C.Name = "RTB1_C"
        Me.RTB1_C.Size = New System.Drawing.Size(182, 262)
        '
        '_undo
        '
        Me._undo.Image = Global.Xport.My.Resources.Resources.arrow_skip_180
        Me._undo.Name = "_undo"
        Me._undo.Size = New System.Drawing.Size(181, 26)
        Me._undo.Text = "Undo"
        '
        '_redo
        '
        Me._redo.Image = Global.Xport.My.Resources.Resources.arrow_skip
        Me._redo.Name = "_redo"
        Me._redo.Size = New System.Drawing.Size(181, 26)
        Me._redo.Text = "Redo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        '_cut
        '
        Me._cut.Image = Global.Xport.My.Resources.Resources.clipboard__arrow
        Me._cut.Name = "_cut"
        Me._cut.Size = New System.Drawing.Size(181, 26)
        Me._cut.Text = "Cut"
        '
        '_copy
        '
        Me._copy.Image = Global.Xport.My.Resources.Resources.documents
        Me._copy.Name = "_copy"
        Me._copy.Size = New System.Drawing.Size(181, 26)
        Me._copy.Text = "Copy"
        '
        '_paste
        '
        Me._paste.Image = Global.Xport.My.Resources.Resources.clipboard
        Me._paste.Name = "_paste"
        Me._paste.Size = New System.Drawing.Size(181, 26)
        Me._paste.Text = "Paste"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(178, 6)
        '
        '_delete
        '
        Me._delete.Image = Global.Xport.My.Resources.Resources.cross
        Me._delete.Name = "_delete"
        Me._delete.Size = New System.Drawing.Size(181, 26)
        Me._delete.Text = "Delete"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(178, 6)
        '
        '_sel_all
        '
        Me._sel_all.Image = Global.Xport.My.Resources.Resources.document_text
        Me._sel_all.Name = "_sel_all"
        Me._sel_all.Size = New System.Drawing.Size(181, 26)
        Me._sel_all.Text = "Select All"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(178, 6)
        '
        '_plot_selected
        '
        Me._plot_selected.CheckOnClick = True
        Me._plot_selected.Image = Global.Xport.My.Resources.Resources.plot
        Me._plot_selected.Name = "_plot_selected"
        Me._plot_selected.Size = New System.Drawing.Size(181, 26)
        Me._plot_selected.Text = "Draw Selected.."
        '
        '_center_selected
        '
        Me._center_selected.Image = Global.Xport.My.Resources.Resources.image_resize_actual
        Me._center_selected.Name = "_center_selected"
        Me._center_selected.Size = New System.Drawing.Size(181, 26)
        Me._center_selected.Text = "Center on Selected"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.Xport.My.Resources.Resources.column_back_1
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status_t1, Me.status_t2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 410)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(318, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status_t1
        '
        Me.status_t1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.status_t1.Margin = New System.Windows.Forms.Padding(3)
        Me.status_t1.Name = "status_t1"
        Me.status_t1.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.status_t1.Size = New System.Drawing.Size(63, 16)
        Me.status_t1.Text = "status_t1"
        '
        'status_t2
        '
        Me.status_t2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.status_t2.Margin = New System.Windows.Forms.Padding(3)
        Me.status_t2.Name = "status_t2"
        Me.status_t2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.status_t2.Size = New System.Drawing.Size(63, 16)
        Me.status_t2.Text = "status_t2"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AutoSize = False
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.BackgroundImage = Global.Xport.My.Resources.Resources.column_back_1
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._grid_brightness, Me._rewind, Me._play, Me._foward, Me._exit, Me.OptionsToolStripMenuItem, Me._lable_1, Me._ambient, Me._show_eye_center})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 410)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(338, 22)
        Me.MenuStrip2.TabIndex = 3
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        '_grid_brightness
        '
        Me._grid_brightness.AutoSize = False
        Me._grid_brightness.BackColor = System.Drawing.SystemColors.InfoText
        Me._grid_brightness.DropDownWidth = 35
        Me._grid_brightness.ForeColor = System.Drawing.Color.White
        Me._grid_brightness.Items.AddRange(New Object() {"2.0", "1.9", "1.8", "1.7", "1.6", "1.5", "1.4", "1.3", "1.2", "1.1", "1.0", "0.9", "0.8", "0.7", "0.6", "0.5", "0.4", "0.3", "0.2", "0.1"})
        Me._grid_brightness.Name = "_grid_brightness"
        Me._grid_brightness.Size = New System.Drawing.Size(40, 21)
        Me._grid_brightness.Text = Global.Xport.My.MySettings.Default.grid_level
        '
        '_rewind
        '
        Me._rewind.AutoSize = False
        Me._rewind.Image = Global.Xport.My.Resources.Resources.control_stop_180
        Me._rewind.Name = "_rewind"
        Me._rewind.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._rewind.Size = New System.Drawing.Size(22, 22)
        Me._rewind.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        '_play
        '
        Me._play.AutoSize = False
        Me._play.Image = Global.Xport.My.Resources.Resources.control
        Me._play.Name = "_play"
        Me._play.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._play.Size = New System.Drawing.Size(22, 22)
        Me._play.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        '_foward
        '
        Me._foward.AutoSize = False
        Me._foward.Image = Global.Xport.My.Resources.Resources.control_stop
        Me._foward.Name = "_foward"
        Me._foward.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._foward.Size = New System.Drawing.Size(22, 22)
        Me._foward.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        '_exit
        '
        Me._exit.AutoSize = False
        Me._exit.Image = Global.Xport.My.Resources.Resources.control_power
        Me._exit.Name = "_exit"
        Me._exit.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._exit.Size = New System.Drawing.Size(22, 22)
        Me._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideZOnlyMovesToolStripMenuItem, Me.HideRapidMovesToolStripMenuItem, Me.DrawGridToolStripMenuItem, Me._gl_depth_test, Me._lighting, Me._prompts, Me.DrawTestObjectToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(62, 18)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'HideZOnlyMovesToolStripMenuItem
        '
        Me.HideZOnlyMovesToolStripMenuItem.Checked = Global.Xport.My.MySettings.Default.hide_z
        Me.HideZOnlyMovesToolStripMenuItem.CheckOnClick = True
        Me.HideZOnlyMovesToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.cross
        Me.HideZOnlyMovesToolStripMenuItem.Name = "HideZOnlyMovesToolStripMenuItem"
        Me.HideZOnlyMovesToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.HideZOnlyMovesToolStripMenuItem.Text = "Hide Z only moves?"
        '
        'HideRapidMovesToolStripMenuItem
        '
        Me.HideRapidMovesToolStripMenuItem.Checked = Global.Xport.My.MySettings.Default.hide_rapid
        Me.HideRapidMovesToolStripMenuItem.CheckOnClick = True
        Me.HideRapidMovesToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.cross
        Me.HideRapidMovesToolStripMenuItem.Name = "HideRapidMovesToolStripMenuItem"
        Me.HideRapidMovesToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.HideRapidMovesToolStripMenuItem.Text = "Hide Rapid Moves?"
        '
        'DrawGridToolStripMenuItem
        '
        Me.DrawGridToolStripMenuItem.Checked = Global.Xport.My.MySettings.Default.show_grid
        Me.DrawGridToolStripMenuItem.CheckOnClick = True
        Me.DrawGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DrawGridToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.grid
        Me.DrawGridToolStripMenuItem.Name = "DrawGridToolStripMenuItem"
        Me.DrawGridToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DrawGridToolStripMenuItem.Text = "Draw Grid?"
        '
        '_gl_depth_test
        '
        Me._gl_depth_test.Checked = Global.Xport.My.MySettings.Default.render_3d
        Me._gl_depth_test.CheckOnClick = True
        Me._gl_depth_test.Image = Global.Xport.My.Resources.Resources._3D
        Me._gl_depth_test.Name = "_gl_depth_test"
        Me._gl_depth_test.Size = New System.Drawing.Size(194, 22)
        Me._gl_depth_test.Text = "3D Depth Render?"
        '
        '_lighting
        '
        Me._lighting.Checked = Global.Xport.My.MySettings.Default.gl_lighting
        Me._lighting.CheckOnClick = True
        Me._lighting.CheckState = System.Windows.Forms.CheckState.Checked
        Me._lighting.Image = Global.Xport.My.Resources.Resources.light_bulb_off
        Me._lighting.Name = "_lighting"
        Me._lighting.Size = New System.Drawing.Size(194, 22)
        Me._lighting.Text = "GL Lighting?"
        '
        '_prompts
        '
        Me._prompts.Checked = Global.Xport.My.MySettings.Default.screen_prompts
        Me._prompts.CheckOnClick = True
        Me._prompts.Image = Global.Xport.My.Resources.Resources.question
        Me._prompts.Name = "_prompts"
        Me._prompts.Size = New System.Drawing.Size(194, 22)
        Me._prompts.Text = "Screen Prompts?"
        '
        'DrawTestObjectToolStripMenuItem
        '
        Me.DrawTestObjectToolStripMenuItem.CheckOnClick = True
        Me.DrawTestObjectToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.ball
        Me.DrawTestObjectToolStripMenuItem.Name = "DrawTestObjectToolStripMenuItem"
        Me.DrawTestObjectToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DrawTestObjectToolStripMenuItem.Text = "Draw Test Object"
        '
        '_lable_1
        '
        Me._lable_1.AutoSize = False
        Me._lable_1.BackColor = System.Drawing.Color.DimGray
        Me._lable_1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._lable_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lable_1.ForeColor = System.Drawing.Color.Black
        Me._lable_1.HideSelection = False
        Me._lable_1.Name = "_lable_1"
        Me._lable_1.ReadOnly = True
        Me._lable_1.Size = New System.Drawing.Size(48, 18)
        Me._lable_1.Text = "Ambient"
        Me._lable_1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me._lable_1.Visible = False
        '
        '_ambient
        '
        Me._ambient.AutoSize = False
        Me._ambient.BackColor = System.Drawing.Color.Black
        Me._ambient.DropDownWidth = 30
        Me._ambient.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ambient.ForeColor = System.Drawing.Color.White
        Me._ambient.Items.AddRange(New Object() {".1", ".2", ".3", ".4", ".5", ".6", ".7", ".8", ".9", "1.0"})
        Me._ambient.Name = "_ambient"
        Me._ambient.Size = New System.Drawing.Size(40, 21)
        Me._ambient.Text = Global.Xport.My.MySettings.Default.ambient
        Me._ambient.Visible = False
        '
        '_show_eye_center
        '
        Me._show_eye_center.AutoSize = False
        Me._show_eye_center.BackColor = System.Drawing.Color.Transparent
        Me._show_eye_center.CheckOnClick = True
        Me._show_eye_center.Image = Global.Xport.My.Resources.Resources.target
        Me._show_eye_center.Name = "_show_eye_center"
        Me._show_eye_center.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._show_eye_center.Size = New System.Drawing.Size(22, 22)
        Me._show_eye_center.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'cancel_read_btn
        '
        Me.cancel_read_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel_read_btn.ForeColor = System.Drawing.Color.Black
        Me.cancel_read_btn.Location = New System.Drawing.Point(10, 344)
        Me.cancel_read_btn.Name = "cancel_read_btn"
        Me.cancel_read_btn.Size = New System.Drawing.Size(83, 23)
        Me.cancel_read_btn.TabIndex = 14
        Me.cancel_read_btn.Text = "Cancel"
        Me.cancel_read_btn.UseVisualStyleBackColor = True
        Me.cancel_read_btn.Visible = False
        '
        'cancel_send_btn
        '
        Me.cancel_send_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel_send_btn.ForeColor = System.Drawing.Color.Black
        Me.cancel_send_btn.Location = New System.Drawing.Point(10, 315)
        Me.cancel_send_btn.Name = "cancel_send_btn"
        Me.cancel_send_btn.Size = New System.Drawing.Size(83, 23)
        Me.cancel_send_btn.TabIndex = 2
        Me.cancel_send_btn.Text = "Cancel"
        Me.cancel_send_btn.UseVisualStyleBackColor = True
        Me.cancel_send_btn.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Char Bits"
        '
        'Bits
        '
        Me.Bits.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "bits", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Bits.FormattingEnabled = True
        Me.Bits.Items.AddRange(New Object() {"7", "8"})
        Me.Bits.Location = New System.Drawing.Point(10, 110)
        Me.Bits.Name = "Bits"
        Me.Bits.Size = New System.Drawing.Size(83, 21)
        Me.Bits.TabIndex = 12
        Me.Bits.Text = Global.Xport.My.MySettings.Default.bits
        '
        'recv_btn
        '
        Me.recv_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.recv_btn.ForeColor = System.Drawing.Color.Black
        Me.recv_btn.Location = New System.Drawing.Point(10, 286)
        Me.recv_btn.Name = "recv_btn"
        Me.recv_btn.Size = New System.Drawing.Size(83, 23)
        Me.recv_btn.TabIndex = 11
        Me.recv_btn.Text = "Receive"
        Me.recv_btn.UseVisualStyleBackColor = True
        '
        'send_btn
        '
        Me.send_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send_btn.ForeColor = System.Drawing.Color.Black
        Me.send_btn.Location = New System.Drawing.Point(10, 257)
        Me.send_btn.Name = "send_btn"
        Me.send_btn.Size = New System.Drawing.Size(83, 23)
        Me.send_btn.TabIndex = 10
        Me.send_btn.Text = "Send"
        Me.send_btn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Port"
        '
        'port
        '
        Me.port.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "port", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.port.FormattingEnabled = True
        Me.port.Items.AddRange(New Object() {"Com1", "Com2", "Com3", "Com4"})
        Me.port.Location = New System.Drawing.Point(10, 22)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(83, 21)
        Me.port.TabIndex = 8
        Me.port.Text = Global.Xport.My.MySettings.Default.port
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Baud Rate"
        '
        'baud
        '
        Me.baud.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "baud", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.baud.FormattingEnabled = True
        Me.baud.Items.AddRange(New Object() {"300", "600", "1200", "4800", "9600", "19200", ""})
        Me.baud.Location = New System.Drawing.Point(10, 70)
        Me.baud.Name = "baud"
        Me.baud.Size = New System.Drawing.Size(83, 21)
        Me.baud.TabIndex = 6
        Me.baud.Text = Global.Xport.My.MySettings.Default.baud
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Parity"
        '
        'parity
        '
        Me.parity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "parity", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.parity.FormattingEnabled = True
        Me.parity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.parity.Location = New System.Drawing.Point(10, 150)
        Me.parity.Name = "parity"
        Me.parity.Size = New System.Drawing.Size(83, 21)
        Me.parity.TabIndex = 4
        Me.parity.Text = Global.Xport.My.MySettings.Default.parity
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Stop Bits"
        '
        'stopbits
        '
        Me.stopbits.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "stop_bits", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.stopbits.FormattingEnabled = True
        Me.stopbits.Items.AddRange(New Object() {"0", "1", "2", "1.5"})
        Me.stopbits.Location = New System.Drawing.Point(10, 190)
        Me.stopbits.Name = "stopbits"
        Me.stopbits.Size = New System.Drawing.Size(83, 21)
        Me.stopbits.TabIndex = 2
        Me.stopbits.Text = Global.Xport.My.MySettings.Default.stop_bits
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Xfer Mode"
        '
        'handshake
        '
        Me.handshake.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Xport.My.MySettings.Default, "xfer_mode", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.handshake.FormattingEnabled = True
        Me.handshake.Items.AddRange(New Object() {"None", "Xon/Xoff", "Req. Send", "Req. Send Xon/Xoff"})
        Me.handshake.Location = New System.Drawing.Point(10, 230)
        Me.handshake.Name = "handshake"
        Me.handshake.Size = New System.Drawing.Size(83, 21)
        Me.handshake.TabIndex = 0
        Me.handshake.Text = Global.Xport.My.MySettings.Default.xfer_mode
        '
        'comp_text_btn
        '
        Me.comp_text_btn.BackColor = System.Drawing.Color.Gainsboro
        Me.comp_text_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comp_text_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comp_text_btn.ForeColor = System.Drawing.Color.Black
        Me.comp_text_btn.Location = New System.Drawing.Point(290, 2)
        Me.comp_text_btn.Name = "comp_text_btn"
        Me.comp_text_btn.Size = New System.Drawing.Size(50, 20)
        Me.comp_text_btn.TabIndex = 15
        Me.comp_text_btn.Text = "X><Y"
        Me.comp_text_btn.UseVisualStyleBackColor = False
        '
        'sep_text_btn
        '
        Me.sep_text_btn.BackColor = System.Drawing.Color.Gainsboro
        Me.sep_text_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sep_text_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sep_text_btn.ForeColor = System.Drawing.Color.Black
        Me.sep_text_btn.Location = New System.Drawing.Point(346, 2)
        Me.sep_text_btn.Name = "sep_text_btn"
        Me.sep_text_btn.Size = New System.Drawing.Size(50, 20)
        Me.sep_text_btn.TabIndex = 14
        Me.sep_text_btn.Text = "X<>Y"
        Me.sep_text_btn.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackgroundImage = Global.Xport.My.Resources.Resources.column_back_1
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me._new_file, Me._open, Me._save, Me._save_as, Me.font_size, Me._auto_center_selected, Me._plot, Me.orintation, Me._rotate, Me.Com_btn})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(660, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.LoadToolStripMenuItem1, Me.SaveToolStripMenuItem, Me.SaveAToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.LoadToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(38, 21)
        Me.LoadToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.Xport.My.Resources.Resources.generic
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(139, 22)
        Me.ToolStripMenuItem4.Text = "&New File"
        '
        'LoadToolStripMenuItem1
        '
        Me.LoadToolStripMenuItem1.Image = Global.Xport.My.Resources.Resources.folder_open
        Me.LoadToolStripMenuItem1.Name = "LoadToolStripMenuItem1"
        Me.LoadToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.LoadToolStripMenuItem1.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.disk_black
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAToolStripMenuItem
        '
        Me.SaveAToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.disk
        Me.SaveAToolStripMenuItem.Name = "SaveAToolStripMenuItem"
        Me.SaveAToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SaveAToolStripMenuItem.Text = "Save &As..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(136, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.Xport.My.Resources.Resources.cross
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        '_new_file
        '
        Me._new_file.AutoSize = False
        Me._new_file.Image = Global.Xport.My.Resources.Resources.generic
        Me._new_file.Name = "_new_file"
        Me._new_file.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._new_file.Size = New System.Drawing.Size(22, 22)
        Me._new_file.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._new_file.ToolTipText = "Create New"
        '
        '_open
        '
        Me._open.AutoSize = False
        Me._open.Image = Global.Xport.My.Resources.Resources.folder_open
        Me._open.Name = "_open"
        Me._open.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._open.Size = New System.Drawing.Size(22, 22)
        Me._open.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._open.ToolTipText = "Open"
        '
        '_save
        '
        Me._save.AutoSize = False
        Me._save.Image = Global.Xport.My.Resources.Resources.disk_black
        Me._save.Name = "_save"
        Me._save.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._save.Size = New System.Drawing.Size(22, 22)
        Me._save.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._save.ToolTipText = "Save"
        '
        '_save_as
        '
        Me._save_as.AutoSize = False
        Me._save_as.Image = Global.Xport.My.Resources.Resources.disk
        Me._save_as.Name = "_save_as"
        Me._save_as.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._save_as.Size = New System.Drawing.Size(22, 22)
        Me._save_as.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._save_as.ToolTipText = "Save As.."
        '
        'font_size
        '
        Me.font_size.AutoSize = False
        Me.font_size.BackColor = System.Drawing.Color.Black
        Me.font_size.ForeColor = System.Drawing.Color.White
        Me.font_size.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28"})
        Me.font_size.Margin = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.font_size.Name = "font_size"
        Me.font_size.Size = New System.Drawing.Size(35, 21)
        Me.font_size.Text = Global.Xport.My.MySettings.Default.tb_text_size
        Me.font_size.ToolTipText = "Font Size"
        '
        '_auto_center_selected
        '
        Me._auto_center_selected.AutoSize = False
        Me._auto_center_selected.CheckOnClick = True
        Me._auto_center_selected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._auto_center_selected.Image = Global.Xport.My.Resources.Resources.__center
        Me._auto_center_selected.Name = "_auto_center_selected"
        Me._auto_center_selected.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._auto_center_selected.Size = New System.Drawing.Size(22, 22)
        Me._auto_center_selected.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._auto_center_selected.ToolTipText = "Auto Center Selection"
        '
        '_plot
        '
        Me._plot.AutoSize = False
        Me._plot.Checked = Global.Xport.My.MySettings.Default.main_splitter_p2_collapsed
        Me._plot.CheckOnClick = True
        Me._plot.Image = Global.Xport.My.Resources.Resources.plot
        Me._plot.Name = "_plot"
        Me._plot.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._plot.Size = New System.Drawing.Size(22, 22)
        Me._plot.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._plot.ToolTipText = "Hide/Show Plot Window"
        '
        'orintation
        '
        Me.orintation.AutoSize = False
        Me.orintation.Checked = True
        Me.orintation.CheckOnClick = True
        Me.orintation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.orintation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.orintation.Image = Global.Xport.My.Resources.Resources.__layout_h
        Me.orintation.Name = "orintation"
        Me.orintation.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.orintation.Size = New System.Drawing.Size(22, 22)
        Me.orintation.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.orintation.ToolTipText = "Vert/Horz Layout"
        '
        '_rotate
        '
        Me._rotate.AutoSize = False
        Me._rotate.CheckOnClick = True
        Me._rotate.Image = Global.Xport.My.Resources.Resources.arrow_circle
        Me._rotate.Name = "_rotate"
        Me._rotate.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me._rotate.Size = New System.Drawing.Size(22, 22)
        Me._rotate.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me._rotate.ToolTipText = "Animate Rotation"
        '
        'Com_btn
        '
        Me.Com_btn.AutoSize = False
        Me.Com_btn.Checked = Global.Xport.My.MySettings.Default.p2_collapsed
        Me.Com_btn.CheckOnClick = True
        Me.Com_btn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Com_btn.Image = Global.Xport.My.Resources.Resources.WirelessConnection
        Me.Com_btn.Name = "Com_btn"
        Me.Com_btn.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Com_btn.Size = New System.Drawing.Size(22, 22)
        Me.Com_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Com_btn.ToolTipText = "Hide/Show Com Panel"
        '
        'SaveFileDialog1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = Global.Xport.My.MySettings.Default.file_name
        Me.OpenFileDialog1.InitialDirectory = Global.Xport.My.MySettings.Default.f_open_directory
        '
        'Timer1
        '
        Me.Timer1.Interval = 40
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = Global.Xport.My.MySettings.Default.main_client_size
        Me.Controls.Add(Me.Split_Panel)
        Me.Controls.Add(Me.comp_text_btn)
        Me.Controls.Add(Me.sep_text_btn)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("StartPosition", Global.Xport.My.MySettings.Default, "Where_Main_Is", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.Xport.My.MySettings.Default, "main_client_size", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.Location = New System.Drawing.Point(300, 300)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(668, 332)
        Me.Name = "Form1"
        Me.StartPosition = Global.Xport.My.MySettings.Default.Where_Main_Is
        Me.Text = "N-SEE"
        Me.Split_Panel.Panel1.ResumeLayout(False)
        Me.Split_Panel.Panel2.ResumeLayout(False)
        Me.Split_Panel.Panel2.PerformLayout()
        Me.Split_Panel.ResumeLayout(False)
        Me.Splitter.Panel1.ResumeLayout(False)
        Me.Splitter.Panel1.PerformLayout()
        Me.Splitter.Panel2.ResumeLayout(False)
        Me.Splitter.ResumeLayout(False)
        Me.RTB1_C.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Split_Panel As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stopbits As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents handshake As System.Windows.Forms.ComboBox
    Friend WithEvents baud As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents parity As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents port As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RTB1 As RichTextBox
    Friend WithEvents send_btn As System.Windows.Forms.Button
    Friend WithEvents recv_btn As System.Windows.Forms.Button
    Friend WithEvents _open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _save_as As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _new_file As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Bits As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status_t1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents status_t2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sep_text_btn As System.Windows.Forms.Button
    Friend WithEvents comp_text_btn As System.Windows.Forms.Button
    Friend WithEvents cancel_send_btn As System.Windows.Forms.Button
    Friend WithEvents font_size As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cancel_read_btn As System.Windows.Forms.Button
    Friend WithEvents Com_btn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RTB1_C As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents _undo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _redo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _sel_all As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _plot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents _rewind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _play As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _foward As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _plot_selected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideZOnlyMovesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideRapidMovesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DrawGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _gl_depth_test As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _lighting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _prompts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _ambient As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents _lable_1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents DrawTestObjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _show_eye_center As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Splitter As System.Windows.Forms.SplitContainer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents orintation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _rotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _center_selected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents _auto_center_selected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _grid_brightness As System.Windows.Forms.ToolStripComboBox

End Class
