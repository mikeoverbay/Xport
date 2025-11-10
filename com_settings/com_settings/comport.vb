Imports System.String
Imports System.IO
Imports System.Threading
Imports System.IO.Ports
Imports System.Text
Public Class com_thread
    Public comments As Boolean = False
    Public s As New StringBuilder
    Private c As Char = ""
    Public str As String = ""
    Public dataready As Boolean = False
    Public abort As Boolean = False
    Public working As Boolean = False
    Public sthread As New Thread(AddressOf send)
    Public rthread As New Thread(AddressOf receive)
    Public Sub s_start()
        abort = False
        working = True
        sthread.Priority = ThreadPriority.Highest
        sthread.IsBackground = True
        sthread.Name = "send_thrd"
        sthread.Start()
    End Sub

    Public Sub r_start()
        s.Length = 0
        abort = False
        working = True
        rthread.Priority = ThreadPriority.Highest
        rthread.IsBackground = True
        rthread.Name = "receive_thd"
        dataready = False
        rthread.Start()

    End Sub

    Public Sub send()
        Dim p, cp, term_cnt As Integer
        term_cnt = 0
        s = s.Replace(vbCrLf, "~")
        Dim ss = s.ToString.Split("~")
        Dim st As String = ""
        For l = 0 To ss.Length - 1
            st = ss(l)
            frmMain.pg1_position += st.Length + 2 ' update position

            cp = InStr(ss(l), "(")
            If cp = 0 Then cp = 1000
            If comments Then
                p = st.Length - 1
            Else
                If cp = 0 Then p = st.Length - 1
                If cp < 2 Then GoTo skip_line
            End If
            For i = 0 To p
                c = st(i)
                If i < cp Then 'less then comment position
                    If c = " " Then 'dont send spaces
                        GoTo space
                    End If
                End If
send_again:
                Try
                    frmMain.SPORT.Write(c)
                    If c = "%" Then
                        term_cnt += 1
                        If term_cnt = 2 Then
                            abort = True
                            working = False
                        End If
                    End If
                    If abort = True Then
                        abort = False
                        sthread.Abort()
                    End If
                Catch ex As Exception
                    If abort = True Then
                        abort = False
                        sthread.Abort()
                    End If
                    GoTo send_again
                End Try
space:
            Next
end_line:
            Try
                frmMain.SPORT.Write(vbCr)
                frmMain.SPORT.Write(vbLf)
            Catch ex As Exception

            End Try
skip_line:
        Next
        working = False

    End Sub


    Public Sub receive()

        working = True
        Dim b, term_cnt As Integer
        b = 0 : term_cnt = 0
        Dim k As String
        While Not abort
            Try
                c = ChrW(frmMain.SPORT.ReadChar)
                b = AscW(c)
            Catch ex As Exception

            End Try
            If b < 32 Then
                If b = 10 Then
                    GoTo good_c
                End If
                GoTo next_c
            End If
            k = s.ToString

good_c:
            If c = "%" Then
                term_cnt += 1
                If term_cnt = 2 Then
                    abort = True
                    s.Append("%")
                    s.Append(vbCrLf)
                    str += vbCrLf
                    GoTo next_c
                End If
            End If
            If c = vbLf Then
                s.Append(vbCrLf)
                str += vbCrLf
                dataready = True
                While dataready
                    Application.DoEvents()
                End While

                str = ""
            Else
                s.Append(c)
                str += c
            End If
next_c:
        End While
        abort = False
        working = False
    End Sub
End Class
