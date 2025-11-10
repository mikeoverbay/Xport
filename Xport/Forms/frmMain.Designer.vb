<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Splitter = New System.Windows.Forms.SplitContainer
        Me.pg1 = New System.Windows.Forms.ProgressBar
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
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me._plot_selected = New System.Windows.Forms.ToolStripMenuItem
        Me._center_selected = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me._expand_text = New System.Windows.Forms.ToolStripMenuItem
        Me._Compress_text = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me._edit_window = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me._set_font = New System.Windows.Forms.ToolStripMenuItem
        Me._set_font_color = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.top_bar_plot_controls = New System.Windows.Forms.Panel
        Me.top_bar = New System.Windows.Forms.Panel
        Me.plot_toolbar = New System.Windows.Forms.Panel
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Splitter.Panel2.SuspendLayout()
        Me.Splitter.SuspendLayout()
        Me.RTB1_C.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Splitter
        '
        Me.Splitter.BackColor = System.Drawing.Color.DimGray
        Me.Splitter.Location = New System.Drawing.Point(1, 64)
        Me.Splitter.Name = "Splitter"
        '
        'Splitter.Panel1
        '
        Me.Splitter.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Splitter.Panel1MinSize = 250
        '
        'Splitter.Panel2
        '
        Me.Splitter.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Splitter.Panel2.Controls.Add(Me.pg1)
        Me.Splitter.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Splitter.Panel2MinSize = 0
        Me.Splitter.Size = New System.Drawing.Size(660, 415)
        Me.Splitter.SplitterDistance = 318
        Me.Splitter.TabIndex = 4
        '
        'pg1
        '
        Me.pg1.Dock = System.Windows.Forms.DockStyle.Top
        Me.pg1.Location = New System.Drawing.Point(0, 0)
        Me.pg1.Name = "pg1"
        Me.pg1.Size = New System.Drawing.Size(338, 15)
        Me.pg1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pg1.TabIndex = 3
        Me.pg1.Visible = False
        '
        'RTB1_C
        '
        Me.RTB1_C.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RTB1_C.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._undo, Me._redo, Me.ToolStripSeparator2, Me._cut, Me._copy, Me._paste, Me.ToolStripSeparator4, Me._delete, Me.ToolStripSeparator3, Me._sel_all, Me.ToolStripSeparator7, Me._plot_selected, Me._center_selected, Me.ToolStripSeparator5, Me._expand_text, Me._Compress_text, Me.ToolStripSeparator8, Me._edit_window, Me.ToolStripSeparator9, Me._set_font, Me._set_font_color})
        Me.RTB1_C.Name = "RTB1_C"
        Me.RTB1_C.Size = New System.Drawing.Size(182, 410)
        '
        '_undo
        '
        Me._undo.Image = Global.CodeChop.My.Resources.Resources.Edit_UndoHS
        Me._undo.Name = "_undo"
        Me._undo.Size = New System.Drawing.Size(181, 26)
        Me._undo.Text = "Undo"
        '
        '_redo
        '
        Me._redo.Image = Global.CodeChop.My.Resources.Resources.Edit_RedoHS
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
        Me._cut.Image = Global.CodeChop.My.Resources.Resources.CutHS
        Me._cut.Name = "_cut"
        Me._cut.Size = New System.Drawing.Size(181, 26)
        Me._cut.Text = "Cut"
        '
        '_copy
        '
        Me._copy.Image = Global.CodeChop.My.Resources.Resources.documents
        Me._copy.Name = "_copy"
        Me._copy.Size = New System.Drawing.Size(181, 26)
        Me._copy.Text = "Copy"
        '
        '_paste
        '
        Me._paste.Image = Global.CodeChop.My.Resources.Resources.clipboard__arrow
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
        Me._delete.Image = Global.CodeChop.My.Resources.Resources.DeleteHS
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
        Me._sel_all.Image = Global.CodeChop.My.Resources.Resources.document_text
        Me._sel_all.Name = "_sel_all"
        Me._sel_all.Size = New System.Drawing.Size(181, 26)
        Me._sel_all.Text = "Select All"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(178, 6)
        '
        '_plot_selected
        '
        Me._plot_selected.CheckOnClick = True
        Me._plot_selected.Image = Global.CodeChop.My.Resources.Resources.draw_highlighted
        Me._plot_selected.Name = "_plot_selected"
        Me._plot_selected.Size = New System.Drawing.Size(181, 26)
        Me._plot_selected.Text = "Draw Selected.."
        '
        '_center_selected
        '
        Me._center_selected.CheckOnClick = True
        Me._center_selected.Image = Global.CodeChop.My.Resources.Resources.__center
        Me._center_selected.Name = "_center_selected"
        Me._center_selected.Size = New System.Drawing.Size(181, 26)
        Me._center_selected.Text = "Center on Selected"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(178, 6)
        '
        '_expand_text
        '
        Me._expand_text.Image = Global.CodeChop.My.Resources.Resources.ExpandSpaceHS
        Me._expand_text.Name = "_expand_text"
        Me._expand_text.Size = New System.Drawing.Size(181, 26)
        Me._expand_text.Text = "Expand Text"
        '
        '_Compress_text
        '
        Me._Compress_text.Image = Global.CodeChop.My.Resources.Resources.CompressSpaceHS
        Me._Compress_text.Name = "_Compress_text"
        Me._Compress_text.Size = New System.Drawing.Size(181, 26)
        Me._Compress_text.Text = "Compress Text"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(178, 6)
        '
        '_edit_window
        '
        Me._edit_window.CheckOnClick = True
        Me._edit_window.Image = Global.CodeChop.My.Resources.Resources.FullScreenHS1
        Me._edit_window.Name = "_edit_window"
        Me._edit_window.Size = New System.Drawing.Size(181, 26)
        Me._edit_window.Text = "Edit Window"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(178, 6)
        '
        '_set_font
        '
        Me._set_font.Image = Global.CodeChop.My.Resources.Resources.FontDialogHS
        Me._set_font.Name = "_set_font"
        Me._set_font.Size = New System.Drawing.Size(181, 26)
        Me._set_font.Text = "Set Font"
        '
        '_set_font_color
        '
        Me._set_font_color.Image = Global.CodeChop.My.Resources.Resources.Color_fontHS
        Me._set_font_color.Name = "_set_font_color"
        Me._set_font_color.Size = New System.Drawing.Size(181, 26)
        Me._set_font_color.Text = "Font Color"
        '
        'SaveFileDialog1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = Global.CodeChop.My.MySettings.Default.file_name
        Me.OpenFileDialog1.Filter = "nc (*.nc)|*.nc|NCF (*.ncf)|*.ncf|Text files (*.txt)|*.txt|All files (*.*)|*.*"
        Me.OpenFileDialog1.FilterIndex = Global.CodeChop.My.MySettings.Default.open1_fliter_index
        Me.OpenFileDialog1.InitialDirectory = Global.CodeChop.My.MySettings.Default.f_open_directory
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = Global.CodeChop.My.MySettings.Default.selected_font
        '
        'ColorDialog1
        '
        Me.ColorDialog1.Color = Global.CodeChop.My.MySettings.Default.font_fore_color
        '
        'top_bar_plot_controls
        '
        Me.top_bar_plot_controls.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.top_bar_plot_controls.BackgroundImage = CType(resources.GetObject("top_bar_plot_controls.BackgroundImage"), System.Drawing.Image)
        Me.top_bar_plot_controls.Location = New System.Drawing.Point(32, 42)
        Me.top_bar_plot_controls.Margin = New System.Windows.Forms.Padding(0)
        Me.top_bar_plot_controls.Name = "top_bar_plot_controls"
        Me.top_bar_plot_controls.Size = New System.Drawing.Size(522, 38)
        Me.top_bar_plot_controls.TabIndex = 39
        '
        'top_bar
        '
        Me.top_bar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.top_bar.BackgroundImage = CType(resources.GetObject("top_bar.BackgroundImage"), System.Drawing.Image)
        Me.top_bar.Dock = System.Windows.Forms.DockStyle.Top
        Me.top_bar.Location = New System.Drawing.Point(0, 0)
        Me.top_bar.Margin = New System.Windows.Forms.Padding(0)
        Me.top_bar.Name = "top_bar"
        Me.top_bar.Size = New System.Drawing.Size(800, 38)
        Me.top_bar.TabIndex = 38
        '
        'plot_toolbar
        '
        Me.plot_toolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.plot_toolbar.BackgroundImage = CType(resources.GetObject("plot_toolbar.BackgroundImage"), System.Drawing.Image)
        Me.plot_toolbar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plot_toolbar.Location = New System.Drawing.Point(0, 528)
        Me.plot_toolbar.Margin = New System.Windows.Forms.Padding(0)
        Me.plot_toolbar.Name = "plot_toolbar"
        Me.plot_toolbar.Size = New System.Drawing.Size(800, 38)
        Me.plot_toolbar.TabIndex = 39
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = Global.CodeChop.My.MySettings.Default.file_name
        Me.OpenFileDialog2.Filter = "STL Files (*.stl)|*.stl"
        Me.OpenFileDialog2.FilterIndex = Global.CodeChop.My.MySettings.Default.open1_fliter_index
        Me.OpenFileDialog2.InitialDirectory = Global.CodeChop.My.MySettings.Default.f_open_directory
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(605, 501)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RTB1 Dummy Font"
        Me.Label1.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = Global.CodeChop.My.MySettings.Default.main_client_size
        Me.Controls.Add(Me.top_bar_plot_controls)
        Me.Controls.Add(Me.top_bar)
        Me.Controls.Add(Me.Splitter)
        Me.Controls.Add(Me.plot_toolbar)
        Me.Controls.Add(Me.Label1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("StartPosition", Global.CodeChop.My.MySettings.Default, "Where_Main_Is", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.CodeChop.My.MySettings.Default, "main_client_size", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(300, 300)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmMain"
        Me.StartPosition = Global.CodeChop.My.MySettings.Default.Where_Main_Is
        Me.Text = "CodeChop "
        Me.Splitter.Panel2.ResumeLayout(False)
        Me.Splitter.ResumeLayout(False)
        Me.RTB1_C.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
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
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _plot_selected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Splitter As System.Windows.Forms.SplitContainer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents _center_selected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents plot_toolbar As System.Windows.Forms.Panel
    Friend WithEvents top_bar As System.Windows.Forms.Panel
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _expand_text As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _Compress_text As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _edit_window As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _set_font As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents _set_font_color As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents top_bar_plot_controls As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label


End Class
