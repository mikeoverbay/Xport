Imports System.IO
Imports System.String
Imports System.Data
Imports System.IO.Ports
Imports System.Math

Public Class frmMain
    Public save_file As String = ""
    Public readmode As Boolean = False
    Dim data_set As New DataSet
    Public myThread = New com_thread
    Public Shared pg1_position As Integer = 0
    Public Shared SPORT As New SerialPort
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            myThread.sthread.abort()
        Catch ex As Exception
        End Try
        Try
            myThread.rthread.abort()
        Catch ex As Exception
        End Try
        myThread.working = False
        Try
            SPORT.Close()
        Catch ex As Exception

        End Try
        My.Settings.current_client = cb_client.Text
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'non-active height 130
        'send/rcv height 165
        Me.Height = 130

        tb_output.Location = pg1.Location
        tb_output.Visible = False
        tb_percent.Visible = False
        pg1.Visible = False
        btn_abort.Enabled = False
        read_xml()
    End Sub

    Public Sub read_xml()
        Dim app_root As String = Application.StartupPath
        If File.Exists(app_root + "\comsettings.xml") Then
            Dim str As String = IO.File.ReadAllText(app_root + "\comsettings.xml")
            Dim r As New StringReader(str)
            data_set.Clear()
            data_set.ReadXml(r)
            com_Settings.settings = data_set.Tables("port_settings")
            com_Settings.DGV1.DataSource = com_Settings.settings
            com_Settings.set_column_widths()
            r.Dispose()
            cb_client.Items.Clear()
            For z = 0 To com_Settings.DGV1.Rows.Count - 1
                Dim n = com_Settings.DGV1.Rows(z).Cells(0).Value
                cb_client.Items.Add(n)
            Next
        Else
            com_Settings.DGV1.DataSource = com_Settings.settings
            com_Settings.create_data_record()
            com_Settings.set_column_widths()
        End If
        cb_client.Text = My.Settings.current_client
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        com_Settings.ShowDialog(Me)
        read_xml()
    End Sub

    Private Sub btn_snd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_snd.Click
        readmode = False
        If cb_client.Text.Length = 0 Then
            MsgBox("You need to select or create a client to send data to.", MsgBoxStyle.Exclamation, "Set Error")
            Return
        End If
        btn_snd.Enabled = False
        btn_rcv.Enabled = False
        btn_abort.Enabled = True
        Dim par() = {"None", "Odd", "Even", "Mark", "Space"}
        Dim hs() = {"None", "Xon/Xoff", "ReqToSend", "ReqToSend Xon/Xoff"}
        'Dim name, port, baud, databits, stopbits, parity, handshake As String
        Dim tbl = data_set.Tables("port_Settings")
        Dim q = From _row In tbl.AsEnumerable _
        Where _row.Field(Of String)("Name") = cb_client.Text _
        Select _
        name = _row.Field(Of String)("Name"), _
        port = _row.Field(Of String)("Port"), _
        baud = _row.Field(Of String)("Baud"), _
        databits = _row.Field(Of String)("data bits"), _
        stopbits = _row.Field(Of String)("stop bits"), _
        parity = _row.Field(Of String)("parity"), _
        handshake = _row.Field(Of String)("handshake"), _
        comments = _row.Field(Of String)("(...)")

        SPORT.PortName = q(0).port
        SPORT.BaudRate = CInt(q(0).baud)
        SPORT.DataBits = CInt(q(0).databits)
        SPORT.StopBits = CInt(q(0).stopbits)
        For n = 0 To 4 ' nasty way to find this
            If InStr(par(n), q(0).parity) > 0 Then
                SPORT.Parity = n
                Exit For
            End If
        Next
        For n = 0 To 2 ' nasty way to find this
            If InStr(hs(n), q(0).handshake) > 0 Then
                SPORT.Handshake = n
                Exit For
            End If
        Next

        SPORT.WriteTimeout = 500
        SPORT.ReadTimeout = 500
        SPORT.WriteBufferSize = 100
        tbl.Dispose()
        make_filter() ' set filtering for file opening
        OpenFileDialog1.FileName = My.Settings.file_name
        OpenFileDialog1.FilterIndex = My.Settings.filterIndex
        OpenFileDialog1.InitialDirectory = My.Settings.file_path

        myThread = New com_thread
        myThread.comments = CBool(q(0).comments)
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            My.Settings.filterIndex = OpenFileDialog1.FilterIndex
            Dim fi As FileInfo = New FileInfo(OpenFileDialog1.FileName)
            My.Settings.file_name = fi.Name
            Me.Text = "Com Console : " + fi.Name
            My.Settings.file_path = fi.DirectoryName
            Try
                SPORT.Open()

            Catch ex As Exception
                MsgBox(ex.InnerException, MsgBoxStyle.Exclamation, "Port Error!")
                Return
            End Try
            SPORT.DiscardOutBuffer()

            myThread.s.length = 0
            myThread.s.append(File.ReadAllText(OpenFileDialog1.FileName))
            pg1.Maximum = myThread.s.length - 1

            tb_output.Visible = False
            tb_percent.Visible = True
            pg1.Visible = True

            Me.Height = 165
            pg1_position = 0
            myThread.s_start()
            Dim f_size As Single = myThread.s.length
            While myThread.working
                Try : pg1.Value = pg1_position
                Catch ex As Exception
                End Try

                tb_percent.Text = String.Format("{0:F0}%", Round(pg1_position / f_size, 2) * 100)
                Application.DoEvents()
            End While
            Try
                pg1.Value = pg1.Maximum
                tb_percent.Text = "100%"
                Application.DoEvents()
                SPORT.Close()
            Catch ex As Exception
            End Try
        End If

        btn_snd.Enabled = True
        btn_rcv.Enabled = True
        btn_abort.Enabled = False

        My.Settings.filterIndex = OpenFileDialog1.FilterIndex
    End Sub

    Private Sub btn_rcv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rcv.Click
        If cb_client.Text.Length = 0 Then
            MsgBox("You need to select or create a client to receive data from.", MsgBoxStyle.Exclamation, "Set Error")
            Return
        End If
        btn_snd.Enabled = False
        btn_rcv.Enabled = False
        Dim par() = {"None", "Odd", "Even", "Mark", "Space"}
        Dim hs() = {"None", "Xon/Xoff", "ReqToSend", "ReqToSend Xon/Xoff"}
        'Dim name, port, baud, databits, stopbits, parity, handshake As String
        Dim tbl = data_set.Tables("port_Settings")
        Dim q = From _row In tbl.AsEnumerable _
        Where _row.Field(Of String)("Name") = cb_client.Text _
        Select _
        name = _row.Field(Of String)("Name"), _
        port = _row.Field(Of String)("Port"), _
        baud = _row.Field(Of String)("Baud"), _
        databits = _row.Field(Of String)("data bits"), _
        stopbits = _row.Field(Of String)("stop bits"), _
        parity = _row.Field(Of String)("parity"), _
        handshake = _row.Field(Of String)("handshake"), _
        comments = _row.Field(Of String)("(...)")

        SPORT.PortName = q(0).port
        SPORT.BaudRate = CInt(q(0).baud)
        SPORT.DataBits = CInt(q(0).databits)
        SPORT.StopBits = CInt(q(0).stopbits)
        For n = 0 To 4 ' nasty way to find this
            If InStr(par(n), q(0).parity) > 0 Then
                SPORT.Parity = n
                Exit For
            End If
        Next
        For n = 0 To 2 ' nasty way to find this
            If InStr(hs(n), q(0).handshake) > 0 Then
                SPORT.Handshake = n
                Exit For
            End If
        Next

        SPORT.WriteTimeout = 500
        SPORT.ReadTimeout = 500
        SPORT.ReadBufferSize = 100
        Dim utf8 As New System.Text.UTF8Encoding()
        SPORT.Encoding = utf8
        tbl.Dispose()
        make_filter() ' set filtering for file opening
        myThread = New com_thread
        SaveFileDialog1.FilterIndex = My.Settings.save_filterIndex
        SaveFileDialog1.FileName = My.Settings.save_file_name
        SaveFileDialog1.InitialDirectory = My.Settings.save_file_path
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fi As FileInfo = New FileInfo(SaveFileDialog1.FileName)
            My.Settings.save_file_name = fi.Name
            Me.Text = "Com Console : " + fi.Name
            My.Settings.save_filterIndex = SaveFileDialog1.FilterIndex
            My.Settings.save_file_path = fi.DirectoryName
            save_file = SaveFileDialog1.FileName
            Try
                SPORT.Open()

            Catch ex As Exception
                MsgBox(ex.InnerException, MsgBoxStyle.Exclamation, "Port Error!")
                Return
            End Try
            SPORT.DiscardInBuffer()
            btn_abort.Enabled = True
            tb_output.Visible = True
            tb_percent.Visible = False
            pg1.Visible = False

            tb_output.Text = "Waiting for data to arrive..."
            Me.Height = 165

            myThread.r_start()
            readmode = True
            While myThread.working
                Application.DoEvents()
                If myThread.dataready Then
                    show_data_line(myThread.str)
                    myThread.dataready = False
                End If
            End While
            Try
                SPORT.Close()

            Catch ex As Exception

            End Try
        End If
        btn_snd.Enabled = True
        btn_rcv.Enabled = True
        btn_abort.Enabled = False
    End Sub
    Public Delegate Sub show_(ByRef s As String)
    Public Sub show_data_line(ByRef s As String)
        s = Microsoft.VisualBasic.Replace(s, vbCr, "")
        s = Microsoft.VisualBasic.Replace(s, vbLf, "")
        tb_output.Text = s '= LSet(s, s.Length - 1)
        tb_output.Invalidate()
        tb_output.Update()
        Application.DoEvents()
    End Sub




    Private Sub btn_ftypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ftypes.Click
        Dim ap As String = Application.StartupPath

        Diagnostics.Process.Start(ap + "\file_filter.txt")
    End Sub
    Private Sub make_filter()
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
        SaveFileDialog1.Filter = filter
    End Sub

    Private Sub btn_abort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abort.Click
        myThread.abort = True
        myThread.working = False
        If readmode Then
            If myThread.s.length > 0 Then
                File.WriteAllText(save_file, myThread.s.ToString)
            End If
        End If

    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub SPORT_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs)
        MsgBox(e.ToString, MsgBoxStyle.Critical, "Port Error")
    End Sub

    Private Sub btn_done_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_done.Click
        Me.Height = 130
        tb_output.Visible = False
        tb_percent.Visible = False
        pg1.Visible = False

    End Sub

    Private Sub tb_output_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_output.TextChanged
        Dim z = 100

    End Sub
End Class