Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Linq

Namespace Services

    ''' <summary>
    ''' 患者情報をインメモリ(List)で保持・管理する。MVPのためDBへの永続化は行わず、
    ''' アプリ実行中のみデータを保持する。
    ''' </summary>
    Public Class PatientService

        Private ReadOnly _patients As New List(Of Models.Patient)
        Private _nextId As Integer = 1

        Public Function Add(patient As Models.Patient) As Integer
            patient.PatientId = _nextId
            _nextId += 1
            _patients.Add(patient)
            Return patient.PatientId
        End Function

        Public Function GetAll() As List(Of Models.Patient)
            Return _patients.OrderBy(Function(p) p.NameKana).ToList()
        End Function

        Public Function GetById(patientId As Integer) As Models.Patient
            Return _patients.FirstOrDefault(Function(p) p.PatientId = patientId)
        End Function

        Public Function Search(keyword As String) As List(Of Models.Patient)
            If String.IsNullOrWhiteSpace(keyword) Then
                Return GetAll()
            End If

            Dim matched = _patients.Where(Function(p) p.Name.Contains(keyword) OrElse p.NameKana.Contains(keyword))
            Return matched.OrderBy(Function(p) p.NameKana).ToList()
        End Function

        Public Function Update(patient As Models.Patient) As Boolean
            Dim target = GetById(patient.PatientId)
            If target Is Nothing Then Return False

            target.Name = patient.Name
            target.NameKana = patient.NameKana
            target.BirthDate = patient.BirthDate
            target.Gender = patient.Gender
            target.PhoneNumber = patient.PhoneNumber
            target.Address = patient.Address
            target.Note = patient.Note
            Return True
        End Function

        Public Function Delete(patientId As Integer) As Boolean
            Dim target = GetById(patientId)
            If target Is Nothing Then Return False
            Return _patients.Remove(target)
        End Function

    End Class

End Namespace
