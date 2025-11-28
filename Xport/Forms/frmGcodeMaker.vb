
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window


Public Class frmGcodeMaker

    Dim percentCut As Double = 0.75

    ' === API DECLARATIONS ===
    <DllImport("user32.dll", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.dll", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    ' === CONSTANTS ===
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2

    Private Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        Me.Hide()         ' Just hide it
    End Sub

    Private Sub frmGcodeMaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub frmGcodeMaker_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub


    Private Function TryEvaluateMathExpression(ByRef input As String) As Boolean
        Try
            ' Use DataTable to evaluate simple math expressions
            Dim result = New DataTable().Compute(input, Nothing)

            ' Ensure result is numeric
            If IsNumeric(result) Then
                input = result.ToString()
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function


    Private Sub txtStartX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStartX.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtStartX.Text
            If TryEvaluateMathExpression(text) Then
                txtStartX.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtStartY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStartY.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtStartY.Text
            If TryEvaluateMathExpression(text) Then
                txtStartY.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtSizeX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSizeX.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtSizeX.Text
            If TryEvaluateMathExpression(text) Then
                txtSizeX.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub txtSizeY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSizeY.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtSizeY.Text
            If TryEvaluateMathExpression(text) Then
                txtSizeY.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtStepPerPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStepPerPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtStepPerPass.Text
            If TryEvaluateMathExpression(text) Then
                txtStepPerPass.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub txtFinalDepth_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFinalDepth.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtFinalDepth.Text
            If TryEvaluateMathExpression(text) Then
                txtFinalDepth.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtToolDia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtToolDia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtToolDia.Text
            If TryEvaluateMathExpression(text) Then
                txtToolDia.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtBorder_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBorder.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtBorder.Text
            If TryEvaluateMathExpression(text) Then
                txtBorder.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtEntryFeed_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEntryFeed.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtEntryFeed.Text
            If TryEvaluateMathExpression(text) Then
                txtEntryFeed.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtCutFeed_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCutFeed.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtCutFeed.Text
            If TryEvaluateMathExpression(text) Then
                txtCutFeed.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtRPM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRPM.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtRPM.Text
            If TryEvaluateMathExpression(text) Then
                txtRPM.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub x_countTB_KeyDown(sender As Object, e As KeyEventArgs) Handles x_countTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = x_countTB.Text
            If TryEvaluateMathExpression(text) Then
                x_countTB.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub y_countTB_KeyDown(sender As Object, e As KeyEventArgs) Handles labelYcount.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = y_countTB.Text
            If TryEvaluateMathExpression(text) Then
                y_countTB.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub txtPercentCut_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercentCut.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtPercentCut.Text
            If TryEvaluateMathExpression(text) Then
                txtPercentCut.Text = text
                percentCut = Val(txtPercentCut.Text) / 100.0
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub txtPrecision_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecision.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim text As String = txtPrecision.Text
            If TryEvaluateMathExpression(text) Then
                txtPrecision.Text = text
            Else
                MessageBox.Show("Invalid math expression.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub execute_btn_Click(sender As Object, e As EventArgs) Handles execute_btn.Click

        Select Case True
            Case rbFace.Checked
                ' Call Face function
                face_part()
            Case rbPocket.Checked
                ' Call Pocket function
                pocket_part()
            Case rbCircle.Checked
                circle_pocket_part()
            ' Call Circle Pocket function
            Case cutout_rb.Checked
                ' Call cutout funcion
                cutout_part()
            Case cutout_3sides_rb.Checked
                ' Call cutout 3 sides function
                cutout_3_sides()
            Case circular_cutout_rb.Checked
                ' Call circular cutout function
                circle_cutout_part()
            Case Else
                MessageBox.Show("Please select a path type.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
    End Sub
    Private Sub face_part()
        ' Ask user: append or replace existing G-code
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        ' === Read Inputs ===
        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, CInt(Val(txtStepPerPass.Text)))
        Dim stepZ As Double = Math.Abs(finalDepth / zPassCount)
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = CInt(Val(txtRPM.Text))
        Dim percentCut As Double = Val(txtPercentCut.Text) / 100.0
        ' === Toolpath Bounds ===
        Dim stepOver As Double = toolDia * percentCut
        Dim minX As Double = startX + border
        Dim maxX As Double = startX + sizeX - border
        Dim yStart As Double = startY + border
        Dim yEnd As Double = startY + sizeY - border
        Dim currentDepth As Double = 0

        ' === Start G-code Output ===
        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))

        ' === Z-depth Passes ===
        For i As Integer = 1 To zPassCount
            currentDepth -= stepZ
            If currentDepth < finalDepth Then currentDepth = finalDepth

            gcode.AppendLine($"( Depth pass at Z{currentDepth:F4} )")

            gcode.AppendLine($"G54 G0 X{minX:F4} Y{yStart:F4}")
            gcode.AppendLine($"( Rapid to 0.1 above part)")

            gcode.AppendLine($"G0 Z0.1")
            gcode.AppendLine($"G1 Z{currentDepth:F4} F{entryFeed}")

            ' === Zig-Zag Passes (Y sweep)
            Dim yPos As Double = yStart
            Dim passDir As Boolean = True ' L→R first

            While yPos <= yEnd
                Dim xStart As Double = If(passDir, minX, maxX)
                Dim xEnd As Double = If(passDir, maxX, minX)

                gcode.AppendLine($"G1 X{xStart:F4} Y{yPos:F4} F{cutFeed}")
                gcode.AppendLine($"G1 X{xEnd:F4} Y{yPos:F4}")

                yPos += stepOver
                passDir = Not passDir
            End While

            gcode.AppendLine("G53 G0 Z0") ' retract between passes
        Next

        gcode.AppendLine(generate_gcode_footer())

        ' === Output to RichTextBox ===
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        ' === Show updated toolpath ===
        show_path()
    End Sub

    Private Sub circle_cutout_part()
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        ' === INPUT VARIABLES ===
        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, Val(txtStepPerPass.Text))
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = Val(txtRPM.Text)

        Dim safeZ As Double = 0.1
        Dim ellipseSegments As Integer = Math.Max(12, Val(txtPrecision.Text)) ' user-defined precision

        ' === ELLIPSE GEOMETRY ===
        Dim centerX As Double = startX + (sizeX / 2)
        Dim centerY As Double = startY + (sizeY / 2)
        Dim finishA As Double = (sizeX / 2) + border + (toolDia / 2)
        Dim finishB As Double = (sizeY / 2) + border + (toolDia / 2)

        ' === CALCULATE Z STEP PER SEGMENT ===
        Dim totalSegments As Integer = zPassCount * ellipseSegments
        Dim zStepPerSegment As Double = finalDepth / totalSegments ' negative value (downward)

        ' === G-CODE HEADER ===
        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))
        gcode.AppendLine("( ELLIPTICAL OUTSIDE CUTOUT - QUASI SPIRAL DESCENT )")
        gcode.AppendLine("( Continuous descent, climb cut CCW, final finish lap at depth )")

        ' === START POSITION ===
        Dim startXPos As Double = centerX + finishA
        Dim startYPos As Double = centerY
        gcode.AppendLine($"G0 X{startXPos:F4} Y{startYPos:F4}")
        gcode.AppendLine($"G0 Z{safeZ:F4}")
        gcode.AppendLine($"G1 F{entryFeed}")
        gcode.AppendLine($"G1 Z0.0")
        gcode.AppendLine($"G1 F{cutFeed}")
        gcode.AppendLine("( Begin quasi spiral descent )")

        ' === SPIRAL LOOP ===
        Dim currentZ As Double = 0.0
        For seg As Integer = 0 To totalSegments
            Dim t As Double = (2 * Math.PI * (seg Mod ellipseSegments)) / ellipseSegments
            currentZ += zStepPerSegment
            If currentZ < finalDepth Then currentZ = finalDepth

            Dim x As Double = centerX + finishA * Math.Cos(t)
            Dim y As Double = centerY + finishB * Math.Sin(t)

            gcode.AppendLine($"G1 X{x:F4} Y{y:F4} Z{currentZ:F4}")

            If currentZ <= finalDepth Then Exit For
        Next

        ' === FINAL FINISH LAP ===
        gcode.AppendLine()
        gcode.AppendLine("( Final lap at full depth and finish size )")

        For i As Integer = 0 To ellipseSegments
            Dim t As Double = (2 * Math.PI * i) / ellipseSegments
            Dim x As Double = centerX + finishA * Math.Cos(t)
            Dim y As Double = centerY + finishB * Math.Sin(t)
            gcode.AppendLine($"G1 X{x:F4} Y{y:F4}")
        Next

        ' === RETRACT ===
        gcode.AppendLine("G53 G0 Z0")
        gcode.AppendLine(generate_gcode_footer())

        ' === OUTPUT ===
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        show_path()
    End Sub


    Private Sub cutout_3_sides()
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        ' === INPUT VARIABLES ===
        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, Val(txtStepPerPass.Text))
        Dim stepZ As Double = Math.Abs(finalDepth / zPassCount)
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = Val(txtRPM.Text)
        Dim safeZ As Double = 0.1

        ' === DEFINE CUT LIMITS ===
        Dim minX As Double = startX - border - (toolDia / 2)
        Dim maxX As Double = startX + sizeX + border + (toolDia / 2)
        Dim minY As Double = startY - border - (toolDia)
        Dim maxY As Double = startY + sizeY + border + (toolDia / 2)

        ' The open side ends at minY + toolDia (leaves one side uncut)
        Dim openEndY As Double = minY + toolDia

        ' === G-CODE HEADER ===
        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))
        gcode.AppendLine("( RECTANGULAR 3-SIDED CUTOUT )")
        gcode.AppendLine("( Climb cut, retract after each depth pass )")

        ' === SAFE START POSITION ===
        gcode.AppendLine($"G54 G0 X{minX:F4} Y{minY:F4}")
        gcode.AppendLine($"G0 Z{safeZ:F4}")

        Dim currentDepth As Double = 0

        ' === DEPTH LOOP ===
        For z = 1 To zPassCount
            currentDepth -= stepZ
            If currentDepth < finalDepth Then currentDepth = finalDepth

            gcode.AppendLine()
            gcode.AppendLine($"( Pass {z} at Z{currentDepth:F4} )")
            gcode.AppendLine($"G1 Z{currentDepth:F4} F{entryFeed}")
            gcode.AppendLine($"G1 F{cutFeed}")

            ' --- CLIMB (CCW) THREE-SIDE PATH ---
            ' 1 → Up (+Y)
            gcode.AppendLine($"G1 X{minX:F4} Y{maxY:F4}")
            ' 2 → Right (+X)
            gcode.AppendLine($"G1 X{maxX:F4} Y{maxY:F4}")
            ' 3 → Down (-Y) leaving open front
            gcode.AppendLine($"G1 X{maxX:F4} Y{minY:F4}")
            ' Retract up
            gcode.AppendLine("G53 G0 Z0")
            ' Return to start for next pass
            gcode.AppendLine($"G54 G0 X{minX:F4} Y{minY:F4}")
            gcode.AppendLine($"G0 Z{safeZ:F4}")
        Next

        ' === FINISH LAP AT FULL DEPTH ===
        gcode.AppendLine()
        gcode.AppendLine("( Finish pass at full depth )")
        gcode.AppendLine($"G54 G0 X{minX:F4} Y{minY:F4}")
        gcode.AppendLine($"G0 Z{safeZ:F4}")
        gcode.AppendLine($"G1 Z{finalDepth:F4} F{entryFeed}")
        gcode.AppendLine($"G1 F{cutFeed}")
        gcode.AppendLine($"G1 X{minX:F4} Y{maxY:F4}")
        gcode.AppendLine($"G1 X{maxX:F4} Y{maxY:F4}")
        gcode.AppendLine($"G1 X{maxX:F4} Y{minY:F4}")
        gcode.AppendLine("G53 G0 Z0")

        ' === FOOTER ===
        gcode.AppendLine(generate_gcode_footer())

        ' === OUTPUT TO RTB ===
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        show_path()
    End Sub


    Private Sub cutout_part()
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        ' === INPUT VARIABLES ===
        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, Val(txtStepPerPass.Text))
        Dim stepZ As Double = Math.Abs(finalDepth / zPassCount)
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = Val(txtRPM.Text)
        Dim safeZ As Double = 0.1

        ' === CALCULATE PATH LIMITS ===
        ' Toolpath offset outside part boundary
        Dim minX As Double = startX - border - (toolDia / 2)
        Dim maxX As Double = startX + sizeX + border + (toolDia / 2)
        Dim minY As Double = startY - border - (toolDia / 2)
        Dim maxY As Double = startY + sizeY + border + (toolDia / 2)

        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))
        gcode.AppendLine("( RECTANGULAR OUTSIDE CUTOUT WITH MULTI-LAP RAMP AND FINISH LAP )")

        ' === MOVE TO START ===
        gcode.AppendLine($"G54 G0 X{minX:F4} Y{minY - (toolDia * 0.5):F4}")
        gcode.AppendLine($"G0 Z{safeZ:F4}")

        Dim currentDepth As Double = 0.0
        Dim lastDepth As Double = 0.0

        ' === MULTI-LAP RAMPING LOOP ===
        For z = 1 To zPassCount
            currentDepth = -stepZ * z
            If currentDepth < finalDepth Then currentDepth = finalDepth

            gcode.AppendLine($"( Ramp lap {z} to depth Z{currentDepth:F4} )")
            gcode.AppendLine($"G1 F{entryFeed}")
            gcode.AppendLine($"G1 Z{lastDepth:F4}")
            gcode.AppendLine($"G1 F{cutFeed}")

            ' --- Ramp continuously around the rectangle ---
            Dim depthIncrement As Double = (currentDepth - lastDepth) / 4.0

            ' 1st side — Left to Top
            gcode.AppendLine($"G1 X{minX:F4} Y{maxY:F4} Z{lastDepth + depthIncrement:F4}")
            ' 2nd side — Top to Right
            gcode.AppendLine($"G1 X{maxX:F4} Y{maxY:F4} Z{lastDepth + (2 * depthIncrement):F4}")
            ' 3rd side — Right to Bottom
            gcode.AppendLine($"G1 X{maxX:F4} Y{minY:F4} Z{lastDepth + (3 * depthIncrement):F4}")
            ' 4th side — Bottom to Left
            gcode.AppendLine($"G1 X{minX:F4} Y{minY:F4} Z{currentDepth:F4}")

            lastDepth = currentDepth

            gcode.AppendLine("( Lap complete )")
            'gcode.AppendLine("G53 G0 Z0")
            'gcode.AppendLine($"G54 G0 Z{safeZ:F4}")
            'gcode.AppendLine($"G0 X{minX:F4} Y{minY:F4}")
        Next

        ' === FINISH LAP AT FULL DEPTH ===
        gcode.AppendLine("( Finish lap at full depth )")
        gcode.AppendLine($"G0 Z{safeZ:F4}")
        gcode.AppendLine($"G0 X{minX:F4} Y{minY:F4}")
        gcode.AppendLine($"G1 Z{finalDepth:F4} F{entryFeed}")
        gcode.AppendLine($"G1 F{cutFeed}")
        gcode.AppendLine($"G1 X{minX:F4} Y{maxY:F4}")
        gcode.AppendLine($"G1 X{maxX:F4} Y{maxY:F4}")
        gcode.AppendLine($"G1 X{maxX:F4} Y{minY:F4}")
        gcode.AppendLine($"G1 X{minX:F4} Y{minY:F4}")

        ' === RETRACT & FOOTER ===
        gcode.AppendLine(generate_gcode_footer())

        ' === OUTPUT ===
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        show_path()
    End Sub


    Private Sub circle_pocket_part()
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        ' === INPUT VARIABLES ===
        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, Val(txtStepPerPass.Text))
        Dim stepZ As Double = Math.Abs(finalDepth / zPassCount)
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = Val(txtRPM.Text)
        Dim percentCut As Double = Val(txtPercentCut.Text) / 100.0
        Dim leaveStock As Double = 0.02
        Dim segments As Integer = 36
        Try
            If Val(txtPrecision.Text) > 0 Then segments = Val(txtPrecision.Text)
        Catch
            segments = 36
        End Try

        ' === BASIC POCKET BOUNDARIES ===
        Dim finishMinX As Double = startX + border + (toolDia / 2)
        Dim finishMaxX As Double = startX + sizeX - border - (toolDia / 2)
        Dim finishMinY As Double = startY + border + (toolDia / 2)
        Dim finishMaxY As Double = startY + sizeY - border - (toolDia / 2)

        Dim centerX As Double = (finishMinX + finishMaxX) / 2
        Dim centerY As Double = (finishMinY + finishMaxY) / 2

        Dim radiusX As Double = (finishMaxX - finishMinX) / 2
        Dim radiusY As Double = (finishMaxY - finishMinY) / 2

        ' --- Stepover calculations ---
        Dim stepOver As Double = toolDia * percentCut
        Dim maxRadius As Double = Math.Max(radiusX, radiusY)
        Dim stepCount As Integer = Math.Max(1, Math.Floor(maxRadius / stepOver))
        Dim stepSize As Double = maxRadius / stepCount

        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))

        Dim currentDepth As Double = 0

        ' === ROUGHING DEPTH LOOP ===
        For z = 1 To zPassCount
            ' Spiral entry position
            Dim spiralRadius As Double = toolDia
            Dim spiralStartX As Double = centerX + spiralRadius
            Dim spiralStartY As Double = centerY

            ' Safe move to start
            gcode.AppendLine($"G54 G0 X{spiralStartX:F4} Y{spiralStartY:F4}")
            gcode.AppendLine($"G0 Z0.1")
            gcode.AppendLine($"G1 Z{currentDepth:F4} F{entryFeed}")

            ' Update current depth for this pass
            currentDepth -= stepZ
            If currentDepth < finalDepth Then currentDepth = finalDepth

            gcode.AppendLine($"( Elliptical pocket depth pass Z{currentDepth:F4} )")

            ' Spiral down entry
            gcode.AppendLine($"G3 X{spiralStartX:F4} Y{spiralStartY:F4} Z{currentDepth:F4} I{-spiralRadius:F4} J0.0000 F{entryFeed}")

            ' Build path segments
            Dim pathSegments As New List(Of String)

            For stepIdx As Integer = 0 To stepCount
                Dim scale As Double = (stepIdx / stepCount)
                Dim localRadiusX As Double = (radiusX - leaveStock) * scale
                Dim localRadiusY As Double = (radiusY - leaveStock) * scale

                If localRadiusX <= 0 Or localRadiusY <= 0 Then Continue For

                Dim segment As New System.Text.StringBuilder()
                segment.AppendLine($"( Offset loop {stepIdx} - RX={localRadiusX:F4}, RY={localRadiusY:F4} )")

                ' Build ellipse points CCW (climb cut)
                Dim firstX As Double = 0
                Dim firstY As Double = 0
                Dim firstPoint As Boolean = True

                For angleDeg As Double = 0 To 360 Step (360 / segments)
                    Dim rad As Double = Math.PI * angleDeg / 180.0
                    Dim x As Double = centerX + localRadiusX * Math.Cos(rad)
                    Dim y As Double = centerY + localRadiusY * Math.Sin(rad)

                    If firstPoint Then
                        segment.AppendLine($"G1 X{x:F4} Y{y:F4} F{cutFeed}")
                        firstX = x
                        firstY = y
                        firstPoint = False
                    Else
                        segment.AppendLine($"G1 X{x:F4} Y{y:F4}")
                    End If
                Next

                ' Close the loop
                segment.AppendLine($"G1 X{firstX:F4} Y{firstY:F4}")
                pathSegments.Add(segment.ToString())
            Next

            ' Append segments in normal order (INSIDE → OUTSIDE)
            For i As Integer = 0 To pathSegments.Count - 1
                gcode.Append(pathSegments(i))
            Next

            gcode.AppendLine("G53 G0 Z0")
        Next

        ' === FINISH PASS ===
        gcode.AppendLine("( Finish elliptical contour pass )")
        gcode.AppendLine($"G54 G0 Z0.1")
        gcode.AppendLine($"G1 X{centerX + radiusX:F4} Y{centerY:F4}")
        gcode.AppendLine($"G1 Z{finalDepth:F4} F{entryFeed}")

        For angleDeg As Double = 0 To 360 Step (360 / segments)
            Dim rad As Double = Math.PI * angleDeg / 180.0
            Dim x As Double = centerX + radiusX * Math.Cos(rad)
            Dim y As Double = centerY + radiusY * Math.Sin(rad)
            gcode.AppendLine($"G1 X{x:F4} Y{y:F4} F{cutFeed}")
        Next

        gcode.AppendLine($"G1 X{centerX + radiusX:F4} Y{centerY:F4}")

        gcode.AppendLine(generate_gcode_footer())

        ' === OUTPUT ===
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        show_path()
    End Sub

    Private Sub pocket_part()
        Dim append As Boolean = (MessageBox.Show("Append to existing G-code?", "G-code Output", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        Dim startX As Double = Val(txtStartX.Text)
        Dim startY As Double = Val(txtStartY.Text)
        Dim sizeX As Double = Val(txtSizeX.Text)
        Dim sizeY As Double = Val(txtSizeY.Text)
        Dim finalDepth As Double = Val(txtFinalDepth.Text)
        Dim zPassCount As Integer = Math.Max(1, Val(txtStepPerPass.Text))
        Dim stepZ As Double = Math.Abs(finalDepth / zPassCount)
        Dim toolDia As Double = Val(txtToolDia.Text)
        Dim border As Double = Val(txtBorder.Text)
        Dim entryFeed As Double = Val(txtEntryFeed.Text)
        Dim cutFeed As Double = Val(txtCutFeed.Text)
        Dim spindle As Integer = Val(txtRPM.Text)
        Dim percentCut As Double = Val(txtPercentCut.Text) / 100.0
        Dim leaveStock As Double = 0.02

        ' --- Define finished pocket limits ---
        Dim finishMinX As Double = startX + border + (toolDia / 2)
        Dim finishMaxX As Double = startX + sizeX - border - (toolDia / 2)
        Dim finishMinY As Double = startY + border + (toolDia / 2)
        Dim finishMaxY As Double = startY + sizeY - border - (toolDia / 2)

        Dim centerX As Double = (finishMinX + finishMaxX) / 2
        Dim centerY As Double = (finishMinY + finishMaxY) / 2

        Dim usableWidth As Double = finishMaxX - finishMinX
        Dim usableHeight As Double = finishMaxY - finishMinY

        ' --- Independent stepovers for X and Y ---
        Dim stepOverX As Double = toolDia * percentCut
        Dim stepOverY As Double = toolDia * percentCut

        Dim xStepCount As Integer = Math.Max(1, Math.Floor((usableWidth / 2) / stepOverX))
        Dim yStepCount As Integer = Math.Max(1, Math.Floor((usableHeight / 2) / stepOverY))

        ' Adjust stepovers to end at pocket wall
        stepOverX = (usableWidth / 2) / xStepCount
        stepOverY = (usableHeight / 2) / yStepCount

        Dim gcode As New System.Text.StringBuilder()
        gcode.AppendLine(generate_gcode_header(spindle))

        Dim currentDepth As Double = 0

        ' === Roughing Depth loop ===
        For z = 1 To zPassCount
            ' --- Spiral Entry ---
            Dim spiralRadius As Double = toolDia
            Dim spiralStartX As Double = centerX + spiralRadius
            Dim spiralStartY As Double = centerY

            gcode.AppendLine($"G0 X{spiralStartX:F4} Y{spiralStartY:F4}")
            gcode.AppendLine($"G0 Z0.1")
            gcode.AppendLine($"G1 Z{currentDepth:F4} F{entryFeed}")
            currentDepth -= stepZ
            If currentDepth < finalDepth Then currentDepth = finalDepth

            gcode.AppendLine($"( Pocket depth pass Z{currentDepth:F4} )")

            gcode.AppendLine($"( Spiral entry to Z{currentDepth:F4} )")
            gcode.AppendLine($"G3 X{spiralStartX:F4} Y{spiralStartY:F4} Z{currentDepth:F4} I{-spiralRadius:F4} J0.0000 F{entryFeed}")

            ' --- Roughing limits (leave stock on all rough passes) ---
            Dim roughMinX As Double = finishMinX + leaveStock
            Dim roughMaxX As Double = finishMaxX - leaveStock
            Dim roughMinY As Double = finishMinY + leaveStock
            Dim roughMaxY As Double = finishMaxY - leaveStock

            ' --- Build each rectangular path segment ---
            Dim pathSegments As New List(Of String)
            Dim offsetX As Double = 0
            Dim offsetY As Double = 0

            Do
                Dim segment As New System.Text.StringBuilder()

                Dim x0 As Double = roughMinX + offsetX
                Dim x1 As Double = roughMaxX - offsetX
                Dim y0 As Double = roughMinY + offsetY
                Dim y1 As Double = roughMaxY - offsetY

                If x0 >= x1 Or y0 >= y1 Then Exit Do

                'segment.AppendLine($"( Rough pass Offset X={offsetX:F4}, Y={offsetY:F4} )")
                segment.AppendLine($"G1 X{x0:F4} Y{y0:F4} F{cutFeed}")
                segment.AppendLine($"G1 X{x0:F4} Y{y1:F4}")
                segment.AppendLine($"G1 X{x1:F4} Y{y1:F4}")
                segment.AppendLine($"G1 X{x1:F4} Y{y0:F4}")
                segment.AppendLine($"G1 X{x0:F4} Y{y0:F4}")

                pathSegments.Add(segment.ToString())

                offsetX += stepOverX
                offsetY += stepOverY
            Loop

            ' --- Append paths in REVERSE order (inside → outside) ---
            For i As Integer = pathSegments.Count - 1 To 0 Step -1
                gcode.Append(pathSegments(i))
            Next

            gcode.AppendLine("G53 G0 Z0")
        Next

        ' === Finish pass after all roughing ===
        gcode.AppendLine("( Finish pass at full depth and size )")
        gcode.AppendLine($"G0 X{finishMinX:F4} Y{finishMinY:F4}")
        gcode.AppendLine("G0 Z0.1")
        gcode.AppendLine($"G1 Z{finalDepth:F4} F{entryFeed}")
        gcode.AppendLine($"G1 X{finishMinX:F4} Y{finishMaxY:F4} F{cutFeed}")
        gcode.AppendLine($"G1 X{finishMaxX:F4} Y{finishMaxY:F4}")
        gcode.AppendLine($"G1 X{finishMaxX:F4} Y{finishMinY:F4}")
        gcode.AppendLine($"G1 X{finishMinX:F4} Y{finishMinY:F4}")

        gcode.AppendLine(generate_gcode_footer())

        ' --- Output ---
        If append Then
            frmMain.RTB1.AppendText(gcode.ToString() & vbCrLf)
        Else
            frmMain.RTB1.Text = gcode.ToString()
        End If

        show_path()
    End Sub


    Private Function generate_gcode_header(spindle As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("( Facing Operation Start )")
        sb.AppendLine("G20")
        sb.AppendLine("G90")
        sb.AppendLine("G17")
        sb.AppendLine("G54")
        sb.AppendLine("T1")
        sb.AppendLine($"S{spindle} M3")
        sb.AppendLine("G53 G0 Z0")
        Return sb.ToString()
    End Function

    Private Function generate_gcode_footer() As String
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("G53 G0 Z0")
        sb.AppendLine("M5")
        sb.AppendLine("M9")
        sb.AppendLine("M30")
        Return sb.ToString()
    End Function

    Private Sub show_path()
        draw_presistent_selection = False ' clear
        _Loading = True
        ReDim presistent(1)
        frmMain.clear_selection()
        zoom_window.TopMost = True
        If frmMain.codechop_loaded Then
            frmMain.delete_stl()
        End If
        frmMain.draw_all()
        _Loading = False
    End Sub


End Class