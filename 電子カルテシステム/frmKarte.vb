Option Strict On
Option Explicit On

Public Class frmKarte

    Private ReadOnly _patient As Models.Patient
    Private ReadOnly _karteService As Services.KarteService
    Private _currentList As New List(Of Models.KarteRecord)
    Private _editingKarteId As Integer = 0

    Public Sub New(patient As Models.Patient, karteService As Services.KarteService)
        InitializeComponent()
        _patient = patient
        _karteService = karteService
    End Sub

    Private Sub frmKarte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPatientInfo.Text = $"患者: {_patient.Name}({_patient.NameKana})  {_patient.Age}歳  {_patient.Gender}"
        InitializeGridColumns()
        RefreshKarteList()
        If dgvKarteList.Rows.Count = 0 Then
            ClearDetailFields()
        End If
    End Sub

    Private Sub InitializeGridColumns()
        dgvKarteList.Columns.Clear()
        Dim colDate As New DataGridViewTextBoxColumn With {
            .DataPropertyName = "RecordDateTime", .HeaderText = "診療日時", .Width = 150}
        colDate.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm"
        dgvKarteList.Columns.Add(colDate)
        dgvKarteList.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Subjective", .HeaderText = "主訴", .Width = 380})
    End Sub

    Private Sub RefreshKarteList()
        _currentList = _karteService.GetByPatientId(_patient.PatientId)
        dgvKarteList.DataSource = Nothing
        dgvKarteList.DataSource = _currentList
    End Sub

    Private Function GetSelectedKarte() As Models.KarteRecord
        If dgvKarteList.CurrentRow Is Nothing Then Return Nothing
        Dim index = dgvKarteList.CurrentRow.Index
        If index < 0 OrElse index >= _currentList.Count Then Return Nothing
        Return _currentList(index)
    End Function

    Private Sub ClearDetailFields()
        _editingKarteId = 0
        dtpRecordDateTime.Value = DateTime.Now
        txtSubjective.Clear()
        txtObjective.Clear()
        txtAssessment.Clear()
        txtPlan.Clear()
    End Sub

    Private Sub dgvKarteList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvKarteList.SelectionChanged
        Dim target = GetSelectedKarte()
        If target Is Nothing Then Return

        _editingKarteId = target.KarteId
        dtpRecordDateTime.Value = target.RecordDateTime
        txtSubjective.Text = target.Subjective
        txtObjective.Text = target.Objective
        txtAssessment.Text = target.Assessment
        txtPlan.Text = target.Plan
    End Sub

    Private Sub btnNewKarte_Click(sender As Object, e As EventArgs) Handles btnNewKarte.Click
        dgvKarteList.ClearSelection()
        ClearDetailFields()
        txtSubjective.Focus()
    End Sub

    Private Sub btnSaveKarte_Click(sender As Object, e As EventArgs) Handles btnSaveKarte.Click
        If String.IsNullOrWhiteSpace(txtSubjective.Text) Then
            MessageBox.Show("主訴を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSubjective.Focus()
            Return
        End If

        If _editingKarteId = 0 Then
            Dim newKarte As New Models.KarteRecord() With {
                .PatientId = _patient.PatientId,
                .RecordDateTime = dtpRecordDateTime.Value,
                .Subjective = txtSubjective.Text.Trim(),
                .Objective = txtObjective.Text.Trim(),
                .Assessment = txtAssessment.Text.Trim(),
                .Plan = txtPlan.Text.Trim()}
            _karteService.Add(newKarte)
        Else
            Dim updated As New Models.KarteRecord() With {
                .KarteId = _editingKarteId,
                .PatientId = _patient.PatientId,
                .RecordDateTime = dtpRecordDateTime.Value,
                .Subjective = txtSubjective.Text.Trim(),
                .Objective = txtObjective.Text.Trim(),
                .Assessment = txtAssessment.Text.Trim(),
                .Plan = txtPlan.Text.Trim()}
            _karteService.Update(updated)
        End If

        RefreshKarteList()
        ClearDetailFields()
    End Sub

    Private Sub btnDeleteKarte_Click(sender As Object, e As EventArgs) Handles btnDeleteKarte.Click
        If _editingKarteId = 0 Then
            MessageBox.Show("削除するカルテを選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show("選択したカルテを削除しますか?", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            _karteService.Delete(_editingKarteId)
            RefreshKarteList()
            ClearDetailFields()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
