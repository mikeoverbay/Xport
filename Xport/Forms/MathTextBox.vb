Imports System.Data
Imports System.Windows.Forms


Public Class MathTextBox
        Inherits TextBox

        ' Evaluate when user presses Enter
        Public Property EvaluateOnEnter As Boolean = True

        ' Evaluate when control loses focus
        Public Property EvaluateOnLeave As Boolean = False

        Private _lastValue As Double?

        Public ReadOnly Property LastValue As Double?
            Get
                Return _lastValue
            End Get
        End Property

        Public Event EvaluationCompleted(sender As Object, result As Double)
        Public Event EvaluationFailed(sender As Object, expression As String, ex As Exception)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub EvaluateExpression()
            ' Do nothing at design time
            If IsInDesignMode() Then Return

            Dim expr As String = Me.Text.Trim()
            If String.IsNullOrWhiteSpace(expr) Then
                _lastValue = Nothing
                Return
            End If

            Try
                Dim dt As New DataTable()
                Dim obj = dt.Compute(expr, Nothing)
                Dim value As Double = Convert.ToDouble(obj)

                _lastValue = value
                Me.Text = value.ToString()

                RaiseEvent EvaluationCompleted(Me, value)
            Catch ex As Exception
                _lastValue = Nothing
                RaiseEvent EvaluationFailed(Me, expr, ex)
                Me.SelectAll()
            End Try
        End Sub

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            MyBase.OnKeyDown(e)

            If EvaluateOnEnter AndAlso e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                EvaluateExpression()
            End If
        End Sub

        Protected Overrides Sub OnLeave(e As EventArgs)
            MyBase.OnLeave(e)

            If EvaluateOnLeave Then
                EvaluateExpression()
            End If
        End Sub

        Private Function IsInDesignMode() As Boolean
            If Me.Site IsNot Nothing AndAlso Me.Site.DesignMode Then
                Return True
            End If
            Return DesignMode
        End Function

    End Class


