Imports System.Data
Imports System.String
Imports System.IO
Imports System.IO.Ports


Public Class com_Settings
    Public settings As New DataTable
    Public settings_row As DataRow
    Public port_names() As String
    Public current_row As Integer = 0
    Dim app_root As String = ""
    Public com_port As New SerialPort

    Private Sub com_Settings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not btn_edit.Enabled Then
            MsgBox("You are in the middle of editing.", MsgBoxStyle.Exclamation, "Edit Active")
            e.Cancel = True
            Return
        End If
        Dim v = DGV1.Rows(0).Cells(1).Value
        If IsDBNull(v) Then
            Return
        End If
        settings.WriteXml(Application.StartupPath + "\comsettings.xml")

    End Sub


    Private Sub com_Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        app_root = Application.StartupPath
        settings.TableName = "port_settings"
        If File.Exists(app_root + "\comsettings.xml") Then
            Dim str As String = IO.File.ReadAllText(app_root + "\comsettings.xml")
            Dim data_set As New DataSet
            Dim r As New StringReader(str)
            data_set.ReadXml(r)
            settings = data_set.Tables("port_settings")
            DGV1.DataSource = settings
            set_column_widths()
            r.Dispose()
        Else
            DGV1.DataSource = settings
            create_data_record()
            set_column_widths()
        End If
        Dim ports() As String = SerialPort.GetPortNames()
        cb_port.Items.Clear()
        For Each s In ports
            cb_port.Items.Add(s)
        Next

        btn_save.Enabled = False
        btn_cancel.Enabled = False
    End Sub
    Public Sub create_data_record()
        Dim c1, c2, c3, c4, c5, c6, c7 As New DataColumn
        Dim c8 As New DataColumn
        settings_row = settings.NewRow
        c1.DataType = GetType(System.String)
        c2.DataType = GetType(System.String)
        c3.DataType = GetType(System.String)
        c4.DataType = GetType(System.String)
        c5.DataType = GetType(System.String)
        c6.DataType = GetType(System.String)
        c7.DataType = GetType(System.String)
        c8.DataType = GetType(System.Boolean)
        '
        c1.ColumnName = "Name"
        c2.ColumnName = "Port"
        c3.ColumnName = "Baud"
        c4.ColumnName = "Data Bits"
        c5.ColumnName = "Stop Bits"
        c6.ColumnName = "Parity"
        c7.ColumnName = "Handshake"
        c8.ColumnName = "(...)"
        '
        settings.Columns.Add(c1)
        settings.Columns.Add(c2)
        settings.Columns.Add(c3)
        settings.Columns.Add(c4)
        settings.Columns.Add(c5)
        settings.Columns.Add(c6)
        settings.Columns.Add(c7)
        settings.Columns.Add(c8)
        '
        settings_row(0) = "New Data"
        settings.Rows.Add(settings_row)

    End Sub
    Public Sub set_column_widths()
        DGV1.Columns(0).Width = 150 'name
        DGV1.Columns(1).Width = 65 'port
        DGV1.Columns(2).Width = 65 'baud
        DGV1.Columns(3).Width = 50 'dbits
        DGV1.Columns(4).Width = 50 'stopbits
        DGV1.Columns(5).Width = 75 'parity
        DGV1.Columns(6).Width = 100 'handshake
        DGV1.Columns(7).Width = 50 'comments
        'kill sorting
        DGV1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        DGV1.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable

    End Sub
    Public Sub create_columns()
        Dim c1, c2, c3, c4, c5, c6, c7 As New DataColumn
        Dim c8 As New DataColumn

        settings_row = settings.NewRow
        c1.DataType = GetType(System.String)
        c2.DataType = GetType(System.String)
        c3.DataType = GetType(System.String)
        c4.DataType = GetType(System.String)
        c5.DataType = GetType(System.String)
        c6.DataType = GetType(System.String)
        c7.DataType = GetType(System.String)
        c8.DataType = GetType(System.Boolean)
        '
        c1.ColumnName = "Name"
        c2.ColumnName = "Port"
        c3.ColumnName = "Baud"
        c4.ColumnName = "Data Bits"
        c5.ColumnName = "Stop Bits"
        c6.ColumnName = "Parity"
        c7.ColumnName = "Handshake"
        c8.ColumnName = "(...)"
        '
        settings.Columns.Add(c1)
        settings.Columns.Add(c2)
        settings.Columns.Add(c3)
        settings.Columns.Add(c4)
        settings.Columns.Add(c5)
        settings.Columns.Add(c6)
        settings.Columns.Add(c7)
        settings.Columns.Add(c8)
        '
        settings_row(0) = "New Data"
        settings.Rows.Add(settings_row)

    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Dim v_name As String = tb_name.Text
        If v_name.Length = 0 Then
            MsgBox("Name Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_port As String = cb_port.Text
        If v_port.Length = 0 Then
            MsgBox("Port Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_baud As String = cb_baud.Text
        If v_baud.Length = 0 Then
            MsgBox("Baud Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_databits As String = cb_databits.Text
        If v_databits.Length = 0 Then
            MsgBox("Data Bits Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_stopbits As String = cb_stopbits.Text
        If v_stopbits.Length = 0 Then
            MsgBox("Stop Bits Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_parity As String = cb_parity.Text
        If v_parity.Length = 0 Then
            MsgBox("Parity Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_handshake As String = cb_handshake.Text
        If v_handshake.Length = 0 Then
            MsgBox("Handshake Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim tr As DataRow = settings.NewRow
        tr(0) = v_name
        tr(1) = v_port
        tr(2) = v_baud
        tr(3) = v_databits
        tr(4) = v_stopbits
        tr(5) = v_parity
        tr(6) = v_handshake
        tr(7) = cb_send_comments.Checked
        Dim v = DGV1.Rows(0).Cells(1).Value
        If IsDBNull(v) Then
            settings.Rows.RemoveAt(0)
        End If
        settings.Rows.Add(tr)
        '---------------------------------------
        'update frmMain client list
        frmMain.cb_client.Items.Clear()
        For z = 0 To DGV1.Rows.Count - 1
            Dim n = DGV1.Rows(z).Cells(0).Value
            frmMain.cb_client.Items.Add(n)
        Next

    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        btn_edit.Enabled = False
        btn_add.Enabled = False
        btn_delete.Enabled = False
        btn_save.Enabled = True
        btn_cancel.Enabled = True
        Dim sr As Integer = DGV1.SelectedRows(0).Index
        current_row = sr
        Dim v_name = DGV1.Rows(sr).Cells(0).Value
        Dim v_port = DGV1.Rows(sr).Cells(1).Value
        Dim v_baud = DGV1.Rows(sr).Cells(2).Value
        Dim v_databits = DGV1.Rows(sr).Cells(3).Value
        Dim v_stopbits = DGV1.Rows(sr).Cells(4).Value
        Dim v_parity = DGV1.Rows(sr).Cells(5).Value
        Dim v_handshake = DGV1.Rows(sr).Cells(6).Value
        Dim v_comments = DGV1.Rows(sr).Cells(7).Value
        '--------------------------------------------
        Try
            tb_name.Text = v_name
            cb_port.Text = v_port
            cb_baud.Text = v_baud
            cb_databits.Text = v_databits
            cb_stopbits.Text = v_stopbits
            cb_parity.Text = v_parity
            cb_handshake.Text = v_handshake
            cb_send_comments.Checked = v_comments

        Catch ex As Exception

        End Try



    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        'make sure valuse are legit!
        Dim v_name As String = tb_name.Text
        If v_name.Length = 0 Then
            MsgBox("Name Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_port As String = cb_port.Text
        If v_port.Length = 0 Then
            MsgBox("Port Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_baud As String = cb_baud.Text
        If v_baud.Length = 0 Then
            MsgBox("Baud Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_databits As String = cb_databits.Text
        If v_databits.Length = 0 Then
            MsgBox("Data Bits Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_stopbits As String = cb_stopbits.Text
        If v_stopbits.Length = 0 Then
            MsgBox("Stop Bits Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_parity As String = cb_parity.Text
        If v_parity.Length = 0 Then
            MsgBox("Parity Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------
        Dim v_handshake As String = cb_handshake.Text
        If v_handshake.Length = 0 Then
            MsgBox("Handshake Field is empty!", MsgBoxStyle.Exclamation, "Com Settings")
            Return
        End If
        '------------------------------------------------------------------------

        btn_edit.Enabled = True
        btn_save.Enabled = False
        btn_cancel.Enabled = False
        btn_add.Enabled = True
        btn_delete.Enabled = True
        Dim sr As Integer = DGV1.SelectedRows(0).Index

        DGV1.Rows(sr).Cells(0).Value = v_name
        DGV1.Rows(sr).Cells(1).Value = v_port
        DGV1.Rows(sr).Cells(2).Value = v_baud
        DGV1.Rows(sr).Cells(3).Value = v_databits
        DGV1.Rows(sr).Cells(4).Value = v_stopbits
        DGV1.Rows(sr).Cells(5).Value = v_parity
        DGV1.Rows(sr).Cells(6).Value = v_handshake
        DGV1.Rows(sr).Cells(7).Value = cb_send_comments.Checked
        '--------------------------------------------
        'update frmMain client list
        frmMain.cb_client.Items.Clear()
        For z = 0 To DGV1.Rows.Count - 1
            Dim n = DGV1.Rows(z).Cells(0).Value
            frmMain.cb_client.Items.Add(n)
        Next

    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        btn_edit.Enabled = True
        btn_save.Enabled = False
        btn_cancel.Enabled = False
        btn_add.Enabled = True
        btn_delete.Enabled = True
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim r = DGV1.SelectedRows(0).Index
        Dim name = DGV1.Rows(r).Cells(0).Value
        If Not MsgBox("Are you sure you want to delete """ + name + """?", MsgBoxStyle.YesNo, "Delete Row") = MsgBoxResult.Yes Then
            Return
        End If

        settings.Rows.RemoveAt(r)
        '---------------------------------------
        'update frmMain client list
        frmMain.cb_client.Items.Clear()
        For z = 0 To DGV1.Rows.Count - 1
            Dim n = DGV1.Rows(z).Cells(0).Value
            frmMain.cb_client.Items.Add(n)
        Next
    End Sub

    Private Sub DGV1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.RowEnter
        Dim sr As Integer
        Try
            sr = DGV1.SelectedRows(0).Index
            If sr <> current_row And btn_save.Enabled Then 'make sure user dont change rows during edit!
                DGV1.ClearSelection()
                DGV1.Rows(current_row).Selected = True
                Return
            End If
        Catch ex As Exception
            Return
        End Try

        Dim v_name = DGV1.Rows(sr).Cells(0).Value
        Dim v_port = DGV1.Rows(sr).Cells(1).Value
        Dim v_baud = DGV1.Rows(sr).Cells(2).Value
        Dim v_databits = DGV1.Rows(sr).Cells(3).Value
        Dim v_stopbits = DGV1.Rows(sr).Cells(4).Value
        Dim v_parity = DGV1.Rows(sr).Cells(5).Value
        Dim v_handshake = DGV1.Rows(sr).Cells(6).Value
        Dim v_comments = DGV1.Rows(sr).Cells(7).Value

        Try
            tb_name.Text = v_name
            cb_port.Text = v_port
            cb_baud.Text = v_baud
            cb_databits.Text = v_databits
            cb_stopbits.Text = v_stopbits
            cb_parity.Text = v_parity
            cb_handshake.Text = v_handshake
            cb_send_comments.Checked = v_comments

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub DGV1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.SelectionChanged
        Try
            Dim sr = DGV1.SelectedRows(0).Index
            If sr <> current_row And btn_save.Enabled Then 'make sure user dont change rows during edit!
                DGV1.ClearSelection()
                DGV1.Rows(current_row).Selected = True
                Return
            End If
        Catch ex As Exception
            Return
        End Try
    End Sub
End Class
