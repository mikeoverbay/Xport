Imports System.Windows.Forms
Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Public Class frmControl


    Public Shared port As New SerialPort()
    Dim stop_run As Boolean = False
    Dim pause_run As Boolean = False
    Public shared setCoordValue As Single = 0.0F
    Private pendingLines As New Queue(Of String)
    Private lastResponseTime As DateTime
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles connect_btn.Click
        sender.text = FindGrblPort()
    End Sub

    Function FindGrblPort() As String
        If port.IsOpen Then Return port.PortName


        For Each portName As String In SerialPort.GetPortNames()
            port = New SerialPort(portName, 115200)

            Try
                port.ReadTimeout = 500
                port.WriteTimeout = 500
                port.Open()

                ' GRBL responds to ? with a status report, or to $$ with the settings list.
                ' We'll use '?<CR>' here:
                port.DiscardInBuffer()
                port.Write("?")
                'updateTimer.Enabled = True
                Dim response As String = port.ReadLine()   ' e.g. "<Idle|MPos:0.000,0.000,0.000|FS:0,0>"
                status_tb.AppendText($"Connecting to {SP.PortName }: {response}{Environment.NewLine}")
                If response.StartsWith("<") AndAlso response.Contains("MPos:") Then
                    status_tb.AppendText($"Found GRBL on {SP.PortName }: {response}{Environment.NewLine}")
                    Return port.PortName
                Else
                    port.Close()
                End If
            Catch ex As TimeoutException
                ' no response on this port, move on
            Catch ex As Exception
                ' some ports may throw on open/access denied; ignore
            Finally
                'If port.IsOpen Then port.Close()
            End Try

        Next

        Return Nothing   ' not found
    End Function


    Public Structure GCodeSample
        Public State As String
        Public MPosX As Double
        Public MPosY As Double
        Public MPosZ As Double
        Public MPosA As Double
        Public WCOX As Double
        Public WCOY As Double
        Public WCOZ As Double
        Public WCOA As Double
        Public Feed As Integer
        Public Spindle As Integer
        Public OvFeed As Integer
        Public OvRapid As Integer
        Public OvSpindle As Integer
        Public PinState As String
        Public Timestamp As DateTime
    End Structure

    Public Shared gCodeSamples(99) As GCodeSample


    Private Sub drawPath()
        If port Is Nothing OrElse Not port.IsOpen Then Return

        Try
            port.WriteLine("?")
            Dim response As String = port.ReadLine()

            If response.StartsWith("<"c) AndAlso response.Contains("MPos:") Then
                For i As Integer = gCodeSamples.Length - 1 To 1 Step -1
                    gCodeSamples(i) = gCodeSamples(i - 1)
                Next

                Dim sample As New GCodeSample()
                sample.Timestamp = DateTime.Now
                sample.MPosX = Double.NaN
                sample.MPosY = Double.NaN
                sample.MPosZ = Double.NaN
                sample.MPosA = Double.NaN
                Dim parts = response.Trim("<"c, ">"c).Split("|"c)
                ' Prepare locals to compute display after parsing
                Dim mX As Double = Double.NaN, mY As Double = Double.NaN, mZ As Double = Double.NaN
                Dim wX As Double = Double.NaN, wY As Double = Double.NaN, wZ As Double = Double.NaN

                For Each part In parts
                    If part.StartsWith("Idle") OrElse part.StartsWith("Run") OrElse part.StartsWith("Hold") Then
                        sample.State = part

                    ElseIf part.StartsWith("MPos:") Then
                        Dim vals = part.Substring(5).Split(","c)
                        Dim d As Double
                        If vals.Length > 0 AndAlso Double.TryParse(vals(0), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.MPosX = d : mX = d
                        End If
                        If vals.Length > 1 AndAlso Double.TryParse(vals(1), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.MPosY = d : mY = d
                        End If
                        If vals.Length > 2 AndAlso Double.TryParse(vals(2), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.MPosZ = d : mZ = d
                        End If
                        If vals.Length > 3 AndAlso Double.TryParse(vals(3), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.MPosA = d
                        End If

                    ElseIf part.StartsWith("WCO:") Then
                        Dim vals = part.Substring(4).Split(","c)
                        Dim d As Double
                        If vals.Length > 0 AndAlso Double.TryParse(vals(0), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.WCOX = d : wX = d
                        End If
                        If vals.Length > 1 AndAlso Double.TryParse(vals(1), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.WCOY = d : wY = d
                        End If
                        If vals.Length > 2 AndAlso Double.TryParse(vals(2), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.WCOZ = d : wZ = d
                        End If

                    ElseIf part.StartsWith("FS:") Then
                        Dim vals = part.Substring(3).Split(","c)
                        Dim d As Double
                        Dim unitScale As Double = If(inch_metric, 1.0 / 25.4, 1.0) ' mm→in if inch mode
                        If vals.Length > 0 AndAlso Double.TryParse(vals(0), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.Feed = (d * unitScale).ToString("0000.00", Globalization.CultureInfo.InvariantCulture)
                        End If
                        If vals.Length > 1 AndAlso Double.TryParse(vals(1), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, d) Then
                            sample.Spindle = d ' RPM (no conversion)
                        End If

                    ElseIf part.StartsWith("Ov:") Then
                        Dim vals = part.Substring(3).Split(","c)
                        Dim iv As Integer
                        If vals.Length > 0 AndAlso Integer.TryParse(vals(0), Globalization.NumberStyles.Integer, Globalization.CultureInfo.InvariantCulture, iv) Then sample.OvFeed = iv
                        If vals.Length > 1 AndAlso Integer.TryParse(vals(1), Globalization.NumberStyles.Integer, Globalization.CultureInfo.InvariantCulture, iv) Then sample.OvRapid = iv
                        If vals.Length > 2 AndAlso Integer.TryParse(vals(2), Globalization.NumberStyles.Integer, Globalization.CultureInfo.InvariantCulture, iv) Then sample.OvSpindle = iv

                    ElseIf part.StartsWith("Pn:") Then
                        sample.PinState = part.Substring(3)
                    End If
                Next

                ' --- After parsing: update UI using WORK coords (MPos - WCO), scaled if inch_metric ---
                Dim ux As Double = If(Double.IsNaN(mX), Double.NaN, mX - If(Double.IsNaN(wX), 0.0, wX))
                Dim uy As Double = If(Double.IsNaN(mY), Double.NaN, mY - If(Double.IsNaN(wY), 0.0, wY))
                Dim uz As Double = If(Double.IsNaN(mZ), Double.NaN, mZ - If(Double.IsNaN(wZ), 0.0, wZ))

                Dim unitScaleForDisplay As Double = If(inch_metric, 1.0 / 25.4, 1.0)

                If Not Double.IsNaN(ux) Then txtPosX.Text = (ux * unitScaleForDisplay).ToString("0.000", Globalization.CultureInfo.InvariantCulture)
                If Not Double.IsNaN(uy) Then txtPosY.Text = (uy * unitScaleForDisplay).ToString("0.000", Globalization.CultureInfo.InvariantCulture)
                If Not Double.IsNaN(uz) Then txtPosZ.Text = (uz * unitScaleForDisplay).ToString("0.000", Globalization.CultureInfo.InvariantCulture)

                gCodeSamples(0) = sample


                Dim main = Application.OpenForms.OfType(Of frmMain)().FirstOrDefault()
                If main IsNot Nothing AndAlso main.IsHandleCreated Then
                    main.BeginInvoke(Sub() main.DrawScene())
                End If
            End If
        Catch
            ' swallow serial/read hiccups
        End Try
    End Sub



    ''' <summary>
    ''' Queues and sends a G-code line to the controller.
    ''' </summary>
    Public Sub SendGCodeLine(line As String)
        If port IsNot Nothing AndAlso port.IsOpen Then
            pendingLines.Enqueue(line)
            port.WriteLine(line)
            'DrawBufferedLines()
        Else
            status_tb.AppendText("Cannot send, port not open." & Environment.NewLine)
        End If
    End Sub
    Private Sub Speed_text_label_Click(sender As Object, e As EventArgs) Handles Speed_text_label.Click
    End Sub



    Private Sub step_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles step_combobox.SelectedIndexChanged

    End Sub

    Private Sub speed_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles speed_combobox.SelectedIndexChanged

    End Sub
    Private Sub frmControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        run_btn.Enabled = True
        pause_btn.Enabled = False
        stop_btn.Enabled = False
        connect_btn.Focus()

    End Sub
    Public Sub FlattenGCodeSamplesToFirst()
        Dim base = gCodeSamples(0)
        For i As Integer = 1 To gCodeSamples.Length - 1
            gCodeSamples(i).MPosX = base.MPosX
            gCodeSamples(i).MPosY = base.MPosY
            gCodeSamples(i).MPosZ = base.MPosZ
            gCodeSamples(i).MPosA = base.MPosA
            gCodeSamples(i).State = base.State
            gCodeSamples(i).Timestamp = base.Timestamp
        Next
    End Sub

    ' Called when user clicks "Run"
    Private Sub run_btn_Click(sender As Object, e As EventArgs) Handles run_btn.Click
        ' minimal sanity
        If frmMain.RTB1 Is Nothing OrElse frmMain.RTB1.Lines Is Nothing OrElse frmMain.RTB1.Lines.Length < 1 Then Return
        If port Is Nothing OrElse Not port.IsOpen Then
            status_tb.AppendText("Port not open. Unable to send G-code." & Environment.NewLine)
            Return
        End If

        ' UI + state
        pause_run = False
        stop_run = False
        step_pos = 0
        run_btn.Enabled = False
        pause_btn.Enabled = True
        stop_btn.Enabled = True
        status_tb.Text = ""
        updateTimer.Enabled = True
        frmMain.machining = True

        ' clear samples
        For i As Integer = 0 To gCodeSamples.Length - 1
            gCodeSamples(i) = New GCodeSample()
        Next

        ' ensure SerialPort newline is just LF (optional but recommended)
        ' port.NewLine = vbLf

        ' --- UNLOCK and wait for ok ---
        Try
            port.WriteLine("$X") ' DO NOT append vbCr; WriteLine already adds NewLine
        Catch ex As Exception
            status_tb.AppendText("Failed to write $X: " & ex.Message & Environment.NewLine)
            GoTo teardown
        End Try

        If Not WaitForOk(status_tb) Then GoTo teardown

        ' Snapshot lines so editor changes don’t race
        Dim lines = frmMain.RTB1.Lines
        Dim pos As Integer = 0
        Dim pending As Boolean = False

        ' main loop
        While pos < lines.Length AndAlso Not stop_run
            If Not port.IsOpen Then
                status_tb.AppendText("Port closed during run." & Environment.NewLine)
                Exit While
            End If

            ' If we have a line to send and we're not paused and nothing pending, send next
            If Not pause_run AndAlso Not pending Then
                Dim raw As String = lines(pos)
                pos += 1

                Dim line As String = NormalizeGcodeLine(raw)
                If line.Length = 0 Then
                    ' comment/blank - just continue
                Else
                    Try
                        port.WriteLine(line)
                        pending = True

                        ' Update inch/metric toggle for UI when we actually sent this block
                        Dim l = line.ToUpperInvariant()
                        If l.Contains("G20") Then inch_metric = True
                        If l.Contains("G21") Then inch_metric = False

                        status_tb.AppendText($"Sent:  [{pos}] {line}{Environment.NewLine}")

                        ' Program end on M30: stop after it ACKs
                        If l.Contains("M30") Then
                            ' we will still wait for ok below, then stop
                            stop_run = True
                        End If

                        ' Optional stop M0: set pause; Grbl will still return ok for the block
                        If l = "M0" OrElse l.StartsWith("M0 ") Then
                            pause_run = True
                            status_tb.AppendText("Paused (M0). Press Resume to continue." & Environment.NewLine)
                            pause_btn.Text = "Resume"
                        End If
                    Catch ex As Exception
                        status_tb.AppendText("Write failed: " & ex.Message & Environment.NewLine)
                        Exit While
                    End Try
                End If
            End If

            ' Read and process all available responses
            Try
                While port.BytesToRead > 0
                    Dim resp As String = port.ReadLine().Trim()
                    If resp.Length = 0 Then Continue While

                    ' Status reports start with '<...>' — useful for UI but not flow control
                    If resp.StartsWith("<"c) Then
                        ' optional: stash/display
                        ' status_tb.AppendText($"GRBL: {resp}{Environment.NewLine}")
                        Continue While
                    End If

                    ' ok / error / alarm
                    If resp.StartsWith("ok", StringComparison.OrdinalIgnoreCase) Then
                        lastResponseTime = DateTime.Now
                        status_tb.AppendText($"GRBL: {resp}{Environment.NewLine}")
                        pending = False
                    ElseIf resp.StartsWith("error", StringComparison.OrdinalIgnoreCase) OrElse resp.StartsWith("ALARM", StringComparison.OrdinalIgnoreCase) Then
                        status_tb.AppendText($"GRBL: {resp}{Environment.NewLine}")
                        pending = False
                        ' leave run going unless you want to abort:
                        ' stop_run = True
                    Else
                        ' other lines (e.g., $ reports, $G prints)
                        status_tb.AppendText($"GRBL: {resp}{Environment.NewLine}")
                    End If
                End While
            Catch ex As TimeoutException
                status_tb.AppendText("Timeout waiting for response from GRBL." & Environment.NewLine)
                Exit While
            Catch ex As Exception
                status_tb.AppendText("Read failed: " & ex.Message & Environment.NewLine)
                Exit While
            End Try

            ' light pacing
            Thread.Sleep(10)
            Application.DoEvents()
        End While

        status_tb.AppendText($"Sent: [{pos}] PROGRAM END{Environment.NewLine}")

teardown:
        updateTimer.Enabled = True  ' if this should keep running; set False if not

        frmMain.btn_step_forward.Enabled = True
        frmMain.btn_step_back.Enabled = True
        frmMain.btn_rewind.Enabled = True
        frmMain.btn_plot_all.Enabled = True
        frmMain.RTB1.Enabled = True

        run_btn.Enabled = True
        pause_btn.Enabled = False
        pause_btn.Text = "Pause"
        stop_btn.Enabled = False
    End Sub
    ' Strip comments and whitespace; return "" if the block should be skipped
    Private Function NormalizeGcodeLine(raw As String) As String
        If raw Is Nothing Then Return ""
        Dim s = raw.Trim()
        If s = "" Then Return ""
        If s.StartsWith(";") OrElse s.StartsWith("%") OrElse s.StartsWith("O") Then Return ""
        ' strip ( ... ) inline comments (simple)
        Dim openIdx = s.IndexOf("("c)
        If openIdx >= 0 Then
            Dim closeIdx = s.IndexOf(")"c, openIdx + 1)
            If closeIdx > openIdx Then s = s.Remove(openIdx, closeIdx - openIdx + 1).Trim()
        End If
        ' strip everything after ';' inline comment
        Dim semi = s.IndexOf(";"c)
        If semi >= 0 Then s = s.Substring(0, semi).Trim()
        Return s
    End Function

    ' Waits for a single 'ok' (drains other lines)
    Private Function WaitForOk(log As TextBox) As Boolean
        Dim t0 = Environment.TickCount
        While Environment.TickCount - t0 < 3000
            If port Is Nothing OrElse Not port.IsOpen Then Return False
            If port.BytesToRead > 0 Then
                Dim r = port.ReadLine().Trim()
                If r.StartsWith("ok", StringComparison.OrdinalIgnoreCase) Then
                    If log IsNot Nothing Then log.AppendText($"GRBL: {r}{Environment.NewLine}")
                    Return True
                End If
                ' ignore status/others
                If log IsNot Nothing AndAlso Not r.StartsWith("<"c) Then
                    log.AppendText($"GRBL: {r}{Environment.NewLine}")
                End If
            Else
                Thread.Sleep(5)
                Application.DoEvents()
            End If
        End While
        If log IsNot Nothing Then log.AppendText("Timeout waiting for ok." & Environment.NewLine)
        Return False
    End Function

    Private Sub update_screen()
        drawPath()
        Return

    End Sub
    Private Sub stop_btn_Click(sender As Object, e As EventArgs) Handles stop_btn.Click
        stop_run = True
        If port IsNot Nothing AndAlso port.IsOpen Then
            port.Write(Chr(24)) ' Ctrl+X
            status_tb.AppendText("Sent: Ctrl+X (Soft Reset)" & Environment.NewLine)
        End If
    End Sub

    Private Sub pause_btn_Click(sender As Object, e As EventArgs) Handles pause_btn.Click
        If port Is Nothing OrElse Not port.IsOpen Then Exit Sub

        Try
            If pause_run Then
                ' Currently running → send feed hold (pause)
                port.Write("!")
                pause_run = False
                pause_btn.Text = "Resume"
            Else
                ' Currently paused → send cycle start (resume)
                port.Write("~")
                pause_run = True
                pause_btn.Text = "Pause"
            End If
        Catch ex As Exception
            Debug.WriteLine("Pause/Run toggle failed: " & ex.Message)
        End Try
    End Sub

    Private Sub frmControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmMain.btn_com_con.BackgroundImage = My.Resources.D_RND_BTN_M_UP
        frmMain.btn_com_con.Checked = False

        Application.DoEvents()
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmControl_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        connect_btn.Focus()

    End Sub

    Private Sub updateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        ' Marshal the entire drawPath to the frmMain UI thread
        If frmMain.InvokeRequired Then
            frmMain.BeginInvoke(Sub() drawPath())
        Else
            drawPath()
        End If
    End Sub

    Private Sub zero_x_btn_Click(sender As Object, e As EventArgs) Handles zero_x_btn.Click
        If port?.IsOpen Then
            port.WriteLine($"G10 L20 P1 X0")
        End If
    End Sub

    Private Sub zero_y_btn_Click(sender As Object, e As EventArgs) Handles zero_y_btn.Click
        If port?.IsOpen Then
            port.WriteLine($"G10 L20 P1 Y0")
        End If
    End Sub

    Private Sub zero_z_btn_Click(sender As Object, e As EventArgs) Handles zero_z_btn.Click
        If port?.IsOpen Then
            port.WriteLine($"G10 L20 P1 Z0")
        End If
    End Sub

    Private Sub zero_a_btn_Click(sender As Object, e As EventArgs) Handles zero_a_btn.Click
        If port?.IsOpen Then
            port.WriteLine($"G10 L20 P1 A0")
        End If
    End Sub



    Private Sub txtPosX_Click(sender As Object, e As EventArgs) Handles txtPosX.Click
        frmSetCoord.Location = Me.txtPosX.Location
        If frmSetCoord.ShowDialog() = DialogResult.OK Then
            Dim value As Double = setCoordValue
            If Not inch_metric Then
                ' mm mode
                port.WriteLine($"G92.0 X{value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            Else
                ' inch mode
                port.WriteLine($"G92.0 X{(value / 25.4).ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            End If
            status_tb.AppendText($"Set X to {value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & Environment.NewLine)
            ' Update all samples to this new position
            FlattenGCodeSamplesToFirst()
            drawPath()
        End If

    End Sub

    Private Sub txtPosY_Click(sender As Object, e As EventArgs) Handles txtPosY.Click
        frmSetCoord.Location = Me.txtPosY.Location
        If frmSetCoord.ShowDialog() = DialogResult.OK Then
            Dim value As Double = setCoordValue
            If Not inch_metric Then
                ' mm mode
                port.WriteLine($"G92.0 Y{value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            Else
                ' inch mode
                port.WriteLine($"G92.0 Y{(value / 25.4).ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            End If
            status_tb.AppendText($"Set Y to {value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & Environment.NewLine)
            ' Update all samples to this new position
            FlattenGCodeSamplesToFirst()
            drawPath()
        End If

    End Sub

    Private Sub txtPosZ_Click(sender As Object, e As EventArgs) Handles txtPosZ.Click
        frmSetCoord.Location = Me.txtPosZ.Location
        If frmSetCoord.ShowDialog() = DialogResult.OK Then
            Dim value As Double = setCoordValue
            If Not inch_metric Then
                ' mm mode
                port.WriteLine($"G92.0 Z{value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            Else
                ' inch mode
                port.WriteLine($"G92.0 Z{(value / 25.4).ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            End If
            status_tb.AppendText($"Set Z to {value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & Environment.NewLine)
            ' Update all samples to this new position
            FlattenGCodeSamplesToFirst()
            drawPath()
        End If

    End Sub

    Private Sub txtPosA_Click(sender As Object, e As EventArgs) Handles txtPosA.Click
        frmSetCoord.Location = Me.txtPosA.Location
        If frmSetCoord.ShowDialog() = DialogResult.OK Then
            Dim value As Double = setCoordValue
            If Not inch_metric Then
                ' mm mode
                port.WriteLine($"G92.0 A{value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            Else
                ' inch mode
                port.WriteLine($"G92.0 A{(value / 25.4).ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & vbCr)
            End If
            status_tb.AppendText($"Set A to {value.ToString("0.000", Globalization.CultureInfo.InvariantCulture)}" & Environment.NewLine)
            ' Update all samples to this new position
            FlattenGCodeSamplesToFirst()
            drawPath()
        End If

    End Sub
End Class