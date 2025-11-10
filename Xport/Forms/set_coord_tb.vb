Public Class frmSetCoord
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub frmSetCoord_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim value As Double
        If Double.TryParse(TextBox1.Text, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, value) Then
            TextBox1.BackColor = Color.White  ' valid
        Else
            TextBox1.BackColor = Color.MistyRose  ' invalid
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim value As Double
            If Double.TryParse(TextBox1.Text, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, value) Then
                frmControl.setCoordValue = value
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Please enter a valid number.")
                TextBox1.SelectAll()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub frmSetCoord_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.BringToFront()
        Me.TopMost = True
    End Sub
End Class