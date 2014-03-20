Imports Trawler.DataAccess

Public Class frmSettings

  Private _Setting_Pk As Integer


  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    Dim setting As Setting = GetSettingsData()

    If setting Is Nothing Then
      Exit Sub
    End If

    PopulateForm(setting)

  End Sub

  Private Function GetSettingsData() As Setting
    Dim Setting As Setting = DataAccess.PopulateSetting
    Return Setting
  End Function

  Private Function PopulateSettingsClass() As Setting

    Dim Setting As New Setting()

    Try

      Setting.Setting_PK = _Setting_Pk
      Setting.LastFeedbackDate = dtLastFeedbackdate.Text
      Setting.NumberOfContactsToSendTo = txtNumberOfContactsToSendTo.Text

      If rdEmailBullk.Checked Then
        Setting.SingleEmail = True
      Else
        Setting.SingleEmail = False
      End If

      Setting.NumberOfContactsPerEmail = txtNumberOfContactsPerEmail.Text
      Setting.AdditionalTestContact = txtAdditionalTestContact.Text
      Setting.NFUserName = txtNFUserName.Text
      Setting.NFPassword = txtNFPassword.Text

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

    Return Setting

  End Function

  Private Sub PopulateForm(setting As Setting)

    Try

      _Setting_Pk = setting.Setting_PK
      dtLastFeedbackdate.Text = setting.LastFeedbackDate
      txtNumberOfContactsToSendTo.Text = setting.NumberOfContactsToSendTo

      If setting.SingleEmail = True Then
        rdEmailBullk.Checked = True
      Else
        rdEmailSeperate.Checked = True
      End If

      txtNumberOfContactsPerEmail.Text = setting.NumberOfContactsPerEmail
      txtAdditionalTestContact.Text = setting.AdditionalTestContact
      txtNFUserName.Text = setting.NFUserName
      txtNFPassword.Text = setting.NFPassword

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub

  Private Function ValidateForm() As Boolean

    If (Not IsNumeric(txtNumberOfContactsToSendTo.Text)) Then
      MsgBox("Number Of Contacts To Send To must be a number", MsgBoxStyle.OkOnly)
      Return False
    End If

    If CInt(txtNumberOfContactsToSendTo.Text) > 10000 Then
      MsgBox("Number Of Contacts To Send To must be below 10,000", MsgBoxStyle.OkOnly)
      Return False
    End If

    If String.IsNullOrWhiteSpace(txtNumberOfContactsPerEmail.Text) Then
      txtNumberOfContactsPerEmail.Text = 0
    End If

    If (Not IsNumeric(txtNumberOfContactsPerEmail.Text)) Then
      MsgBox("Number Of Contacts per Email must be a number", MsgBoxStyle.OkOnly)
      Return False
    End If

    If String.IsNullOrWhiteSpace(txtNFUserName.Text) Then
      MsgBox("UserName must be entered", MsgBoxStyle.OkOnly)
      Return False
    End If

    If String.IsNullOrWhiteSpace(txtNFPassword.Text) Then
      MsgBox("Password must be entered", MsgBoxStyle.OkOnly)
      Return False
    End If

    Return True

  End Function

  Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
    Me.Close()
  End Sub

  Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click

    Try

      Dim FormB As Boolean = ValidateForm()

      If FormB = True Then
        Dim setting As Setting = PopulateSettingsClass()
        DataAccess.SaveSetting(setting)
      Else
        Exit Sub
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub


  Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

    Try

      Dim FormB As Boolean = ValidateForm()

      If FormB = True Then
        Dim setting As Setting = PopulateSettingsClass()
        DataAccess.SaveSetting(setting)
        Me.Close()
      Else
        Exit Sub
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub rdEmailBullk_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdEmailBullk.CheckedChanged
    If rdEmailBullk.Checked = True Then
      txtNumberOfContactsPerEmail.Text = String.Empty
      txtNumberOfContactsPerEmail.Enabled = False
    Else
      txtNumberOfContactsPerEmail.Enabled = True
    End If
  End Sub
End Class