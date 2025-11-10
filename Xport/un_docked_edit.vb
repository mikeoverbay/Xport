Public Class un_docked_edit

    Private Sub un_docked_edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True ' so I can catch the key events for mouse behavour modification
        While Not Me.Visible

        End While
        frmMain.Controls.Remove(frmMain.top_bar)
        frmMain.top_bar_plot_controls.Location = New Point(0, 0)
        frmMain.top_bar_plot_controls.Width = frmMain.ClientRectangle.Width

        Me.Controls.Add(frmMain.top_bar)
        Me.ClientSize = New Size(577, 350)
    End Sub
    Private Sub un_docked_edit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Controls.Remove(frmMain.RTB1)
        Me.Controls.Remove(frmMain.top_bar)
        frmMain.Controls.Add(frmMain.top_bar)
        frmMain.top_bar_plot_controls.Location = frmMain.tb_ec
        frmMain.top_bar_plot_controls.Width = frmMain.ClientRectangle.Width - frmMain.tb_ec.X
        frmMain.Splitter.Panel1.Controls.Add(frmMain.RTB1)
        frmMain.Splitter.BackColor = Color.DimGray
        frmMain.Splitter.Panel1Collapsed = False
        frmMain.Splitter.SplitterWidth = 4
        frmMain._edit_window.Checked = False
        frmMain.RTB1.Focus()
    End Sub

    Private Sub un_docked_edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 16 Then
            If Not move_mod Then
                move_mod = True ' SHIFT KET
                If Not frmMain.btn_draw_eye_center.Checked Then
                    frmMain.btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
                End If
                eye_target = True
                frmMain.DrawScene()
            End If
        End If
        If e.KeyCode = 17 Then
            If Not z_move Then
                z_move = True ' CTRL KEY
                If Not frmMain.btn_draw_eye_center.Checked Then
                    frmMain.btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_LOCKED
                End If
                eye_target = True
                frmMain.DrawScene()
            End If
        End If
    End Sub

    Private Sub un_docked_edit_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            Me.Close()
        End If
        If e.KeyCode = Keys.F6 Then
            If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Else
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

            End If
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
            If Not frmMain.btn_draw_eye_center.Checked Then
                frmMain.btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            End If
            eye_target = frmMain.btn_draw_eye_center.Checked
            frmMain.DrawScene()
        End If
        If z_move Then
            z_move = False
            If Not frmMain.btn_draw_eye_center.Checked Then
                frmMain.btn_draw_eye_center.BackgroundImage = My.Resources.D_RND_BTN_M_UP
            End If
            eye_target = frmMain.btn_draw_eye_center.Checked
            frmMain.DrawScene()
        End If
    End Sub


    Private Sub un_docked_edit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    End Sub

    Private Sub un_docked_edit_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Me.Text = "Editor : " + frmMain.get_filename()
    End Sub



End Class