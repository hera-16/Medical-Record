Option Strict On
Option Explicit On

Public Class frmPatientEdit

    Private ReadOnly _patient As Models.Patient
    Public Property ResultPatient As Models.Patient

    Public Sub New(Optional sourcePatient As Models.Patient = Nothing)
        InitializeComponent()
        If sourcePatient Is Nothing Then
            _patient = New Models.Patient()
        Else
            _patient = sourcePatient
        End If
    End Sub

    Private Sub frmPatientEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Text = _patient.Name
        txtNameKana.Text = _patient.NameKana
        If _patient.BirthDate <> Date.MinValue Then
            dtpBirthDate.Value = _patient.BirthDate
        End If
        If Not String.IsNullOrEmpty(_patient.Gender) AndAlso cmbGender.Items.Contains(_patient.Gender) Then
            cmbGender.SelectedItem = _patient.Gender
        Else
            cmbGender.SelectedIndex = 0
        End If
        txtPhoneNumber.Text = _patient.PhoneNumber
        txtAddress.Text = _patient.Address
        txtNote.Text = _patient.Note
        Me.Text = If(_patient.PatientId = 0, "患者登録", "患者情報編集")
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("氏名を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        _patient.Name = txtName.Text.Trim()
        _patient.NameKana = txtNameKana.Text.Trim()
        _patient.BirthDate = dtpBirthDate.Value.Date
        _patient.Gender = If(cmbGender.SelectedItem?.ToString(), String.Empty)
        _patient.PhoneNumber = txtPhoneNumber.Text.Trim()
        _patient.Address = txtAddress.Text.Trim()
        _patient.Note = txtNote.Text.Trim()

        ResultPatient = _patient
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
