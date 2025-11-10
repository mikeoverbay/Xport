Public Class zoom_window
    Private Sub zoom_window_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = 1
        Me.Hide()
        frmMain.btn_zoom.Checked = False
        frmMain.btn_zoom.BackgroundImage = My.Resources.D_RND_BTN_M_UP
    End Sub

    Private Sub zoom_window_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub zoom_window_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub zoom_window_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Public Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmMain.zoom_factor = CSng(frmMain.TrackBar1.Value)
        frmMain.DrawScene()
    End Sub

    Private Sub zoom_window_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        frmMain.RTB1.Focus()
    End Sub

    Private Sub zoom_window_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        frmMain.TrackBar1.SuspendLayout()
    End Sub

    Private Sub zoom_window_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        frmMain.TrackBar1.ResumeLayout()
    End Sub
End Class