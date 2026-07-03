Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Linq

Namespace Services

    ''' <summary>
    ''' カルテ記録をインメモリ(List)で保持・管理する。MVPのためDBへの永続化は行わず、
    ''' アプリ実行中のみデータを保持する。
    ''' </summary>
    Public Class KarteService

        Private ReadOnly _karteRecords As New List(Of Models.KarteRecord)
        Private _nextId As Integer = 1

        Public Function Add(karte As Models.KarteRecord) As Integer
            karte.KarteId = _nextId
            _nextId += 1
            _karteRecords.Add(karte)
            Return karte.KarteId
        End Function

        Public Function GetByPatientId(patientId As Integer) As List(Of Models.KarteRecord)
            Dim matched = _karteRecords.Where(Function(k) k.PatientId = patientId)
            Return matched.OrderByDescending(Function(k) k.RecordDateTime).ToList()
        End Function

        Public Function GetById(karteId As Integer) As Models.KarteRecord
            Return _karteRecords.FirstOrDefault(Function(k) k.KarteId = karteId)
        End Function

        Public Function Update(karte As Models.KarteRecord) As Boolean
            Dim target = GetById(karte.KarteId)
            If target Is Nothing Then Return False

            target.RecordDateTime = karte.RecordDateTime
            target.Subjective = karte.Subjective
            target.Objective = karte.Objective
            target.Assessment = karte.Assessment
            target.Plan = karte.Plan
            Return True
        End Function

        Public Function Delete(karteId As Integer) As Boolean
            Dim target = GetById(karteId)
            If target Is Nothing Then Return False
            Return _karteRecords.Remove(target)
        End Function

        ''' <summary>
        ''' 患者削除時のカスケード削除用。指定患者に紐づく全カルテを削除する。
        ''' </summary>
        Public Sub DeleteByPatientId(patientId As Integer)
            _karteRecords.RemoveAll(Function(k) k.PatientId = patientId)
        End Sub

    End Class

End Namespace
