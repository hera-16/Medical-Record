Option Strict On
Option Explicit On

Namespace Models

    Public Class Patient

        Public Property PatientId As Integer
        Public Property Name As String
        Public Property NameKana As String
        Public Property BirthDate As Date
        Public Property Gender As String
        Public Property PhoneNumber As String
        Public Property Address As String
        Public Property Note As String

        Public Sub New()
            Name = String.Empty
            NameKana = String.Empty
            Gender = String.Empty
            PhoneNumber = String.Empty
            Address = String.Empty
            Note = String.Empty
        End Sub

        Public ReadOnly Property Age As Integer
            Get
                Dim today As Date = Date.Today
                Dim calculatedAge As Integer = today.Year - BirthDate.Year
                If BirthDate.Date > today.AddYears(-calculatedAge) Then
                    calculatedAge -= 1
                End If
                Return calculatedAge
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Name}({NameKana})"
        End Function

    End Class

End Namespace
