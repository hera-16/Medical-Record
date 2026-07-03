Option Strict On
Option Explicit On

Public Class frmMain

    Private ReadOnly _patientService As New Services.PatientService()
    Private ReadOnly _karteService As New Services.KarteService()
    Private _currentList As New List(Of Models.Patient)

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeGridColumns()
        SeedSampleData()
        RefreshPatientList()
    End Sub

    Private Sub InitializeGridColumns()
        dgvPatients.Columns.Clear()
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "PatientId", .HeaderText = "ID", .Width = 50})
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Name", .HeaderText = "氏名", .Width = 120})
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "NameKana", .HeaderText = "フリガナ", .Width = 120})
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Age", .HeaderText = "年齢", .Width = 50})
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "Gender", .HeaderText = "性別", .Width = 60})
        dgvPatients.Columns.Add(New DataGridViewTextBoxColumn With {
            .DataPropertyName = "PhoneNumber", .HeaderText = "電話番号", .Width = 110})
    End Sub

    Private Sub SeedSampleData()
        Dim p1 As New Models.Patient() With {
            .Name = "山田 太郎", .NameKana = "ヤマダ タロウ",
            .BirthDate = New Date(1985, 4, 12), .Gender = "男性",
            .PhoneNumber = "090-1234-5678", .Address = "東京都新宿区1-2-3"}
        Dim p2 As New Models.Patient() With {
            .Name = "佐藤 花子", .NameKana = "サトウ ハナコ",
            .BirthDate = New Date(1992, 9, 30), .Gender = "女性",
            .PhoneNumber = "080-9876-5432", .Address = "東京都渋谷区4-5-6"}
        _patientService.Add(p1)
        _patientService.Add(p2)

        _karteService.Add(New Models.KarteRecord() With {
            .PatientId = p1.PatientId, .RecordDateTime = DateTime.Now.AddDays(-7),
            .Subjective = "頭痛が続いている", .Objective = "体温36.8度、血圧正常",
            .Assessment = "緊張型頭痛の疑い", .Plan = "鎮痛剤を処方し経過観察"})
    End Sub

    Private Sub RefreshPatientList(Optional keyword As String = "")
        _currentList = _patientService.Search(keyword)
        dgvPatients.DataSource = Nothing
        dgvPatients.DataSource = _currentList
    End Sub

    Private Function GetSelectedPatient() As Models.Patient
        If dgvPatients.CurrentRow Is Nothing Then Return Nothing
        Dim index = dgvPatients.CurrentRow.Index
        If index < 0 OrElse index >= _currentList.Count Then Return Nothing
        Return _currentList(index)
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        RefreshPatientList(txtSearch.Text)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using editForm As New frmPatientEdit()
            If editForm.ShowDialog(Me) = DialogResult.OK Then
                _patientService.Add(editForm.ResultPatient)
                RefreshPatientList(txtSearch.Text)
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim target = GetSelectedPatient()
        If target Is Nothing Then
            MessageBox.Show("編集する患者を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using editForm As New frmPatientEdit(target)
            If editForm.ShowDialog(Me) = DialogResult.OK Then
                _patientService.Update(editForm.ResultPatient)
                RefreshPatientList(txtSearch.Text)
            End If
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim target = GetSelectedPatient()
        If target Is Nothing Then
            MessageBox.Show("削除する患者を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show($"「{target.Name}」を削除しますか?関連するカルテも全て削除されます。",
            "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.Yes Then
            _karteService.DeleteByPatientId(target.PatientId)
            _patientService.Delete(target.PatientId)
            RefreshPatientList(txtSearch.Text)
        End If
    End Sub

    Private Sub btnKarte_Click(sender As Object, e As EventArgs) Handles btnKarte.Click
        Dim target = GetSelectedPatient()
        If target Is Nothing Then
            MessageBox.Show("カルテを開く患者を選択してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using karteForm As New frmKarte(target, _karteService)
            karteForm.ShowDialog(Me)
        End Using
    End Sub

End Class
