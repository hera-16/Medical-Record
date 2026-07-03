Option Strict On
Option Explicit On

Namespace Models

    Public Class KarteRecord

        Public Property KarteId As Integer
        Public Property PatientId As Integer
        Public Property RecordDateTime As DateTime
        Public Property Subjective As String
        Public Property Objective As String
        Public Property Assessment As String
        Public Property Plan As String

        Public Sub New()
            RecordDateTime = DateTime.Now
            Subjective = String.Empty
            Objective = String.Empty
            Assessment = String.Empty
            Plan = String.Empty
        End Sub

    End Class

End Namespace
