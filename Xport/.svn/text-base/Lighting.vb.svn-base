Imports System.Windows.Forms

Imports System

Public Class Lighting
    Private lmouse As New Point(0, 0)
    Private Sub Lighting_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.DrawScene()
    End Sub

    Private Sub Lighting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Try
            abs_ckb.Checked = My.Settings.abs_inc_mode
        Catch ex As Exception

        End Try
        Label1.Text = String.Format("{0:F2}", ambient_level.ToString)
        TrackBar1.Value = CInt(ambient_level * 100)
        Label4.Text = String.Format("{0:F2}", frmMain._grid_multi.ToString)
        TrackBar2.Value = CInt(frmMain._grid_multi * 100)
        Dim cnt As Integer = Me.Controls.Count
        Try
            Me.Controls.RemoveAt(cnt)
        Catch ex As Exception
        End Try
        Dim btn_close As New my_Frm_Btn
        btn_close.Image = My.Resources.cross
        AddHandler btn_close.Click, AddressOf close_me
        btn_close.Location = New Point(Me.Width - 27, 3)
        Me.Controls.Add(btn_close)

        Dim edit_file_types As New W_my_Btn
        AddHandler edit_file_types.Click, AddressOf edit_types
        Me.Controls.Add(edit_file_types)
        edit_file_types.Location = New Point(187, 315)
        edit_file_types.ForeColor = Color.White
        edit_file_types.Text = "File Types"

        Dim work_offsets_btn As New W_my_Btn
        AddHandler work_offsets_btn.Click, AddressOf show_offsets
        Me.Controls.Add(work_offsets_btn)
        work_offsets_btn.Location = New Point(187, 405)
        work_offsets_btn.ForeColor = Color.White
        work_offsets_btn.Text = "Fixture Offsets"


        Me.Update()

        lmouse.X = 0
        lmouse.Y = 0
    End Sub
    Private Sub show_offsets()
        fixture_offsets.Show()
    End Sub
    Private Sub edit_types()
        Dim ap As String = Application.StartupPath

        Diagnostics.Process.Start(ap + "\file_filter.txt")

    End Sub
    Private Sub close_me()
        My.Settings.ambient = ambient_level
        My.Settings.grid_level = frmMain._grid_multi
        If fixture_offsets.Visible = True Then
            fixture_offsets.Visible = False
        End If
        Me.Dispose()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        ambient_level = CSng(TrackBar1.Value * 0.01)
        Label1.Text = String.Format("{0:F2}", ambient_level)
        frmMain.DrawScene()
        My.Settings.ambient = ambient_level
    End Sub

    Private Sub Lighting_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim delta As New Size(e.X - lmouse.X, e.Y - lmouse.Y)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += delta
            lmouse = e.Location - delta
            Me.Update()
            'frmMain.DrawScene()
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            lmouse.X = e.X
            lmouse.Y = e.Y
        End If
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        frmMain._grid_multi = CSng(TrackBar2.Value * 0.01)
        Label4.Text = String.Format("{0:F2}", frmMain._grid_multi)
        frmMain.DrawScene()
        My.Settings.grid_level = frmMain._grid_multi

    End Sub

    Private Sub mc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mc1.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub Mc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mc2.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub Mc3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mc3.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub Mc4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mc4.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub Mc5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mc5.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub Mc6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mc6.CheckedChanged
        frmMain.model_color = sender.backcolor
        frmMain.DrawScene()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        frmMain.show_stl = CheckBox1.CheckState
        frmMain.DrawScene()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        frmMain.color_scale = sender.value
        frmMain.DrawScene()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        z_retract = Convert.ToSingle(ComboBox1.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        near_clip_plane = Convert.ToSingle(ComboBox2.Text)
        frmMain.DrawScene()
    End Sub

    Private Sub cb_steptime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_steptime.SelectedIndexChanged
        step_time = Convert.ToInt32(cb_steptime.Text)
    End Sub

    Private Sub abs_ckb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles abs_ckb.CheckedChanged
        My.Settings.abs_inc_mode = sender.checked
    End Sub

    Private Sub fanuc_cb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fanuc_cb.CheckedChanged

    End Sub

    Private Sub fanuc_cb_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles fanuc_cb.MouseClick
        If fanuc_cb.Checked Then
            sub_call_tb.Text = "M98"
            sub_return_tb.Text = "M99"
        Else
            sub_call_tb.Text = "CALL"
            sub_return_tb.Text = "RTS"

        End If
    End Sub
End Class