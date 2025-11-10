Public Class fixture_offsets

    Private Sub fixture_offsets_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True

        Me.Visible = False
    End Sub

    Private Sub fixture_offsets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub clear_all_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear_all_btn.Click
        For i = 0 To 99
            offset_x(i) = 0
            offset_y(i) = 0
        Next
        offset_panel.Controls.Clear()
        frmMain.setup_offset_panel()
    End Sub

    Private Sub offset_panel_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles offset_panel.Scroll
        'sender.update()
    End Sub
End Class