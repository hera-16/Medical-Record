Partial Class frmKarte
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblPatientInfo = New System.Windows.Forms.Label()
        Me.dgvKarteList = New System.Windows.Forms.DataGridView()
        Me.lblRecordDateTime = New System.Windows.Forms.Label()
        Me.dtpRecordDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblSubjective = New System.Windows.Forms.Label()
        Me.txtSubjective = New System.Windows.Forms.TextBox()
        Me.lblObjective = New System.Windows.Forms.Label()
        Me.txtObjective = New System.Windows.Forms.TextBox()
        Me.lblAssessment = New System.Windows.Forms.Label()
        Me.txtAssessment = New System.Windows.Forms.TextBox()
        Me.lblPlan = New System.Windows.Forms.Label()
        Me.txtPlan = New System.Windows.Forms.TextBox()
        Me.btnNewKarte = New System.Windows.Forms.Button()
        Me.btnSaveKarte = New System.Windows.Forms.Button()
        Me.btnDeleteKarte = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.dgvKarteList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPatientInfo
        '
        Me.lblPatientInfo.AutoSize = True
        Me.lblPatientInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblPatientInfo.Name = "lblPatientInfo"
        Me.lblPatientInfo.Size = New System.Drawing.Size(65, 12)
        Me.lblPatientInfo.TabIndex = 0
        Me.lblPatientInfo.Text = "患者情報"
        '
        'dgvKarteList
        '
        Me.dgvKarteList.AllowUserToAddRows = False
        Me.dgvKarteList.AllowUserToDeleteRows = False
        Me.dgvKarteList.AutoGenerateColumns = False
        Me.dgvKarteList.ReadOnly = True
        Me.dgvKarteList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKarteList.MultiSelect = False
        Me.dgvKarteList.Location = New System.Drawing.Point(12, 30)
        Me.dgvKarteList.Name = "dgvKarteList"
        Me.dgvKarteList.Size = New System.Drawing.Size(560, 120)
        Me.dgvKarteList.TabIndex = 1
        '
        'lblRecordDateTime
        '
        Me.lblRecordDateTime.AutoSize = True
        Me.lblRecordDateTime.Location = New System.Drawing.Point(12, 162)
        Me.lblRecordDateTime.Name = "lblRecordDateTime"
        Me.lblRecordDateTime.Size = New System.Drawing.Size(59, 12)
        Me.lblRecordDateTime.TabIndex = 2
        Me.lblRecordDateTime.Text = "診療日時:"
        '
        'dtpRecordDateTime
        '
        Me.dtpRecordDateTime.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.dtpRecordDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRecordDateTime.Location = New System.Drawing.Point(110, 159)
        Me.dtpRecordDateTime.Name = "dtpRecordDateTime"
        Me.dtpRecordDateTime.Size = New System.Drawing.Size(150, 19)
        Me.dtpRecordDateTime.TabIndex = 3
        '
        'lblSubjective
        '
        Me.lblSubjective.AutoSize = True
        Me.lblSubjective.Location = New System.Drawing.Point(12, 192)
        Me.lblSubjective.Name = "lblSubjective"
        Me.lblSubjective.Size = New System.Drawing.Size(83, 12)
        Me.lblSubjective.TabIndex = 4
        Me.lblSubjective.Text = "主訴(S):"
        '
        'txtSubjective
        '
        Me.txtSubjective.Location = New System.Drawing.Point(110, 189)
        Me.txtSubjective.Multiline = True
        Me.txtSubjective.Name = "txtSubjective"
        Me.txtSubjective.Size = New System.Drawing.Size(460, 38)
        Me.txtSubjective.TabIndex = 5
        '
        'lblObjective
        '
        Me.lblObjective.AutoSize = True
        Me.lblObjective.Location = New System.Drawing.Point(12, 234)
        Me.lblObjective.Name = "lblObjective"
        Me.lblObjective.Size = New System.Drawing.Size(83, 12)
        Me.lblObjective.TabIndex = 6
        Me.lblObjective.Text = "所見(O):"
        '
        'txtObjective
        '
        Me.txtObjective.Location = New System.Drawing.Point(110, 231)
        Me.txtObjective.Multiline = True
        Me.txtObjective.Name = "txtObjective"
        Me.txtObjective.Size = New System.Drawing.Size(460, 38)
        Me.txtObjective.TabIndex = 7
        '
        'lblAssessment
        '
        Me.lblAssessment.AutoSize = True
        Me.lblAssessment.Location = New System.Drawing.Point(12, 276)
        Me.lblAssessment.Name = "lblAssessment"
        Me.lblAssessment.Size = New System.Drawing.Size(89, 12)
        Me.lblAssessment.TabIndex = 8
        Me.lblAssessment.Text = "評価・診断(A):"
        '
        'txtAssessment
        '
        Me.txtAssessment.Location = New System.Drawing.Point(110, 273)
        Me.txtAssessment.Multiline = True
        Me.txtAssessment.Name = "txtAssessment"
        Me.txtAssessment.Size = New System.Drawing.Size(460, 38)
        Me.txtAssessment.TabIndex = 9
        '
        'lblPlan
        '
        Me.lblPlan.AutoSize = True
        Me.lblPlan.Location = New System.Drawing.Point(12, 318)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Size = New System.Drawing.Size(89, 12)
        Me.lblPlan.TabIndex = 10
        Me.lblPlan.Text = "治療方針(P):"
        '
        'txtPlan
        '
        Me.txtPlan.Location = New System.Drawing.Point(110, 315)
        Me.txtPlan.Multiline = True
        Me.txtPlan.Name = "txtPlan"
        Me.txtPlan.Size = New System.Drawing.Size(460, 38)
        Me.txtPlan.TabIndex = 11
        '
        'btnNewKarte
        '
        Me.btnNewKarte.Location = New System.Drawing.Point(12, 365)
        Me.btnNewKarte.Name = "btnNewKarte"
        Me.btnNewKarte.Size = New System.Drawing.Size(90, 30)
        Me.btnNewKarte.TabIndex = 12
        Me.btnNewKarte.Text = "新規"
        Me.btnNewKarte.UseVisualStyleBackColor = True
        '
        'btnSaveKarte
        '
        Me.btnSaveKarte.Location = New System.Drawing.Point(108, 365)
        Me.btnSaveKarte.Name = "btnSaveKarte"
        Me.btnSaveKarte.Size = New System.Drawing.Size(90, 30)
        Me.btnSaveKarte.TabIndex = 13
        Me.btnSaveKarte.Text = "保存"
        Me.btnSaveKarte.UseVisualStyleBackColor = True
        '
        'btnDeleteKarte
        '
        Me.btnDeleteKarte.Location = New System.Drawing.Point(204, 365)
        Me.btnDeleteKarte.Name = "btnDeleteKarte"
        Me.btnDeleteKarte.Size = New System.Drawing.Size(90, 30)
        Me.btnDeleteKarte.TabIndex = 14
        Me.btnDeleteKarte.Text = "削除"
        Me.btnDeleteKarte.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(482, 365)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 30)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmKarte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 407)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDeleteKarte)
        Me.Controls.Add(Me.btnSaveKarte)
        Me.Controls.Add(Me.btnNewKarte)
        Me.Controls.Add(Me.txtPlan)
        Me.Controls.Add(Me.lblPlan)
        Me.Controls.Add(Me.txtAssessment)
        Me.Controls.Add(Me.lblAssessment)
        Me.Controls.Add(Me.txtObjective)
        Me.Controls.Add(Me.lblObjective)
        Me.Controls.Add(Me.txtSubjective)
        Me.Controls.Add(Me.lblSubjective)
        Me.Controls.Add(Me.dtpRecordDateTime)
        Me.Controls.Add(Me.lblRecordDateTime)
        Me.Controls.Add(Me.dgvKarteList)
        Me.Controls.Add(Me.lblPatientInfo)
        Me.MinimizeBox = False
        Me.Name = "frmKarte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "カルテ"
        CType(Me.dgvKarteList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPatientInfo As System.Windows.Forms.Label
    Friend WithEvents dgvKarteList As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecordDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpRecordDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSubjective As System.Windows.Forms.Label
    Friend WithEvents txtSubjective As System.Windows.Forms.TextBox
    Friend WithEvents lblObjective As System.Windows.Forms.Label
    Friend WithEvents txtObjective As System.Windows.Forms.TextBox
    Friend WithEvents lblAssessment As System.Windows.Forms.Label
    Friend WithEvents txtAssessment As System.Windows.Forms.TextBox
    Friend WithEvents lblPlan As System.Windows.Forms.Label
    Friend WithEvents txtPlan As System.Windows.Forms.TextBox
    Friend WithEvents btnNewKarte As System.Windows.Forms.Button
    Friend WithEvents btnSaveKarte As System.Windows.Forms.Button
    Friend WithEvents btnDeleteKarte As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

End Class
