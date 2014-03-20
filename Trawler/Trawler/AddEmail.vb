Imports Trawler.DataAccess

Public Class AddEmail

  Private _Profile_FK As Integer
  Private _Action As String
  Private _Email_PK As Integer

  Public Sub New(ByVal Profile_FK As Integer, ByVal Action As String, ByVal Email_PK As Integer, Optional ByVal Subject As String = "", _
                  Optional ByVal Body As String = "", Optional ByVal Value As Decimal = 0)

    InitializeComponent()

    _Profile_FK = Profile_FK
    _Action = Action
    _Email_PK = Email_PK

    If Action = "u" Then
      txtSubject.Text = Subject
      txtBody.Text = Body
      txtValue.Text = Value
    End If

  End Sub

  Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
    Me.Close()
  End Sub

  Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

    Dim res As String = ValidateForm()
    If (Not res = String.Empty) Then
      MsgBox(res)
      Exit Sub
    End If

    SaveEmail(_Action, _Email_PK, _Profile_FK, txtSubject.Text, txtBody.Text, txtValue.Text)

    Me.Close()

  End Sub

  Private Function ValidateForm() As String

    If txtSubject.Text = String.Empty Then
      Return "Subject cannot be blank"
    End If

    If txtBody.Text = String.Empty Then
      Return "Subject cannot be blank"
    End If

    If txtValue.Text = String.Empty Then
      Return "Value cannot be blank"
    End If

    If (Not IsNumeric(txtValue.Text)) Then
      Return "Value must me a numeric"
    End If

    Return String.Empty

  End Function

End Class