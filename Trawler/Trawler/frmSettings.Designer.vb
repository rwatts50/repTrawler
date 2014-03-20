<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
    Me.lblEmailDate = New System.Windows.Forms.Label()
    Me.dtLastFeedbackdate = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtNumberOfContactsToSendTo = New System.Windows.Forms.TextBox()
    Me.rdEmailBullk = New System.Windows.Forms.RadioButton()
    Me.rdEmailSeperate = New System.Windows.Forms.RadioButton()
    Me.txtNFUserName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtNumberOfContactsPerEmail = New System.Windows.Forms.TextBox()
    Me.lblUserName = New System.Windows.Forms.Label()
    Me.txtNFPassword = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.btnOk = New System.Windows.Forms.Button()
    Me.btnApply = New System.Windows.Forms.Button()
    Me.txtAdditionalTestContact = New System.Windows.Forms.TextBox()
    Me.lblAdditionalTestContact = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lblEmailDate
    '
    Me.lblEmailDate.AutoSize = True
    Me.lblEmailDate.Location = New System.Drawing.Point(55, 27)
    Me.lblEmailDate.Name = "lblEmailDate"
    Me.lblEmailDate.Size = New System.Drawing.Size(102, 13)
    Me.lblEmailDate.TabIndex = 40
    Me.lblEmailDate.Text = "Last Feedback date"
    '
    'dtLastFeedbackdate
    '
    Me.dtLastFeedbackdate.Location = New System.Drawing.Point(167, 21)
    Me.dtLastFeedbackdate.Name = "dtLastFeedbackdate"
    Me.dtLastFeedbackdate.Size = New System.Drawing.Size(200, 20)
    Me.dtLastFeedbackdate.TabIndex = 39
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(0, 63)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(157, 13)
    Me.Label1.TabIndex = 41
    Me.Label1.Text = "Number of Contacts to Send To"
    '
    'txtNumberOfContactsToSendTo
    '
    Me.txtNumberOfContactsToSendTo.Location = New System.Drawing.Point(167, 56)
    Me.txtNumberOfContactsToSendTo.Name = "txtNumberOfContactsToSendTo"
    Me.txtNumberOfContactsToSendTo.Size = New System.Drawing.Size(200, 20)
    Me.txtNumberOfContactsToSendTo.TabIndex = 42
    '
    'rdEmailBullk
    '
    Me.rdEmailBullk.AutoSize = True
    Me.rdEmailBullk.Location = New System.Drawing.Point(167, 97)
    Me.rdEmailBullk.Name = "rdEmailBullk"
    Me.rdEmailBullk.Size = New System.Drawing.Size(73, 17)
    Me.rdEmailBullk.TabIndex = 43
    Me.rdEmailBullk.TabStop = True
    Me.rdEmailBullk.Text = "One Email"
    Me.rdEmailBullk.UseVisualStyleBackColor = True
    '
    'rdEmailSeperate
    '
    Me.rdEmailSeperate.AutoSize = True
    Me.rdEmailSeperate.Location = New System.Drawing.Point(283, 97)
    Me.rdEmailSeperate.Name = "rdEmailSeperate"
    Me.rdEmailSeperate.Size = New System.Drawing.Size(84, 17)
    Me.rdEmailSeperate.TabIndex = 44
    Me.rdEmailSeperate.TabStop = True
    Me.rdEmailSeperate.Text = "Many Emails"
    Me.rdEmailSeperate.UseVisualStyleBackColor = True
    '
    'txtNFUserName
    '
    Me.txtNFUserName.Location = New System.Drawing.Point(167, 184)
    Me.txtNFUserName.Name = "txtNFUserName"
    Me.txtNFUserName.Size = New System.Drawing.Size(200, 20)
    Me.txtNFUserName.TabIndex = 45
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 137)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(147, 13)
    Me.Label2.TabIndex = 46
    Me.Label2.Text = "Number of Contacts per Email"
    '
    'txtNumberOfContactsPerEmail
    '
    Me.txtNumberOfContactsPerEmail.Location = New System.Drawing.Point(167, 132)
    Me.txtNumberOfContactsPerEmail.Name = "txtNumberOfContactsPerEmail"
    Me.txtNumberOfContactsPerEmail.Size = New System.Drawing.Size(200, 20)
    Me.txtNumberOfContactsPerEmail.TabIndex = 47
    '
    'lblUserName
    '
    Me.lblUserName.AutoSize = True
    Me.lblUserName.Location = New System.Drawing.Point(64, 187)
    Me.lblUserName.Name = "lblUserName"
    Me.lblUserName.Size = New System.Drawing.Size(95, 13)
    Me.lblUserName.TabIndex = 48
    Me.lblUserName.Text = "Niteflirt User Name"
    '
    'txtNFPassword
    '
    Me.txtNFPassword.Location = New System.Drawing.Point(167, 211)
    Me.txtNFPassword.Name = "txtNFPassword"
    Me.txtNFPassword.Size = New System.Drawing.Size(200, 20)
    Me.txtNFPassword.TabIndex = 49
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(71, 211)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(88, 13)
    Me.Label3.TabIndex = 50
    Me.Label3.Text = "Niteflirt Password"
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(230, 248)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(88, 23)
    Me.btnCancel.TabIndex = 52
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'btnOk
    '
    Me.btnOk.Location = New System.Drawing.Point(149, 248)
    Me.btnOk.Name = "btnOk"
    Me.btnOk.Size = New System.Drawing.Size(75, 23)
    Me.btnOk.TabIndex = 53
    Me.btnOk.Text = "OK"
    Me.btnOk.UseVisualStyleBackColor = True
    '
    'btnApply
    '
    Me.btnApply.Location = New System.Drawing.Point(324, 248)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(75, 23)
    Me.btnApply.TabIndex = 54
    Me.btnApply.Text = "Apply"
    Me.btnApply.UseVisualStyleBackColor = True
    '
    'txtAdditionalTestContact
    '
    Me.txtAdditionalTestContact.Location = New System.Drawing.Point(167, 158)
    Me.txtAdditionalTestContact.Name = "txtAdditionalTestContact"
    Me.txtAdditionalTestContact.Size = New System.Drawing.Size(200, 20)
    Me.txtAdditionalTestContact.TabIndex = 55
    '
    'lblAdditionalTestContact
    '
    Me.lblAdditionalTestContact.AutoSize = True
    Me.lblAdditionalTestContact.Location = New System.Drawing.Point(40, 161)
    Me.lblAdditionalTestContact.Name = "lblAdditionalTestContact"
    Me.lblAdditionalTestContact.Size = New System.Drawing.Size(117, 13)
    Me.lblAdditionalTestContact.TabIndex = 56
    Me.lblAdditionalTestContact.Text = "Additional Test Contact"
    '
    'frmSettings
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(474, 302)
    Me.Controls.Add(Me.lblAdditionalTestContact)
    Me.Controls.Add(Me.txtAdditionalTestContact)
    Me.Controls.Add(Me.btnApply)
    Me.Controls.Add(Me.btnOk)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtNFPassword)
    Me.Controls.Add(Me.lblUserName)
    Me.Controls.Add(Me.txtNumberOfContactsPerEmail)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtNFUserName)
    Me.Controls.Add(Me.rdEmailBullk)
    Me.Controls.Add(Me.rdEmailSeperate)
    Me.Controls.Add(Me.txtNumberOfContactsToSendTo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.lblEmailDate)
    Me.Controls.Add(Me.dtLastFeedbackdate)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frmSettings"
    Me.Text = "Settings"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblEmailDate As System.Windows.Forms.Label
  Friend WithEvents dtLastFeedbackdate As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtNumberOfContactsToSendTo As System.Windows.Forms.TextBox
  Friend WithEvents rdEmailBullk As System.Windows.Forms.RadioButton
  Friend WithEvents rdEmailSeperate As System.Windows.Forms.RadioButton
  Friend WithEvents txtNFUserName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtNumberOfContactsPerEmail As System.Windows.Forms.TextBox
  Friend WithEvents lblUserName As System.Windows.Forms.Label
  Friend WithEvents txtNFPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents btnOk As System.Windows.Forms.Button
  Friend WithEvents btnApply As System.Windows.Forms.Button
  Friend WithEvents txtAdditionalTestContact As System.Windows.Forms.TextBox
  Friend WithEvents lblAdditionalTestContact As System.Windows.Forms.Label
End Class
