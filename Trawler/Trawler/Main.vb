Imports HtmlAgilityPack
Imports System.Configuration
Imports System.Data.EntityClient
Imports Trawler.Constants
Imports Trawler.DataAccess
Imports System.Net.WebClient
Imports System.Threading
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports Microsoft.SqlServer.Server
Imports System.IO
Imports System.Threading.Tasks
Imports System.Net
Imports System.Net.Cache
Imports System.Text.RegularExpressions
Imports System.Linq

'TODO: 
'Make an msi App.

Public Class Main

  Private b As New BrowserSession
  Private WithEvents wb As New WebBrowser
  Private StopAfterLoop As Boolean = False
  Private Subject As String = String.Empty
  Private Body As String = String.Empty
  Dim EmailNo As Integer = 0
  Dim TotalEmailToSendNo As Integer = 0
  Dim Categories As DataSet
  Dim IsEmailPostBack As Boolean = False
  Private mSynchronizationContext As SynchronizationContext


#Region "Loading Methods"

  ''' <summary>
  ''' Set Form items on load
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    mSynchronizationContext = New SynchronizationContext
    GetCategoryTypes()
    PopulateProfiles()
    txtTestUser.Enabled = False
    Dim today As DateTime = GetNistTime()
    today = New DateTime(2013, 8, 21)
    If today = Date.MinValue Then
      MsgBox("You must be connected to the internet")
      Me.Close()
    End If
    If today > New DateTime(2013, 10, 20) Then
      MsgBox("You're 30 day license has ended")
      Me.Close()
    End If
  End Sub

  Public Shared Function GetNistTime() As DateTime
    Dim dateTime__1 As DateTime = DateTime.MinValue

    Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://nist.time.gov/timezone.cgi?UTC/s/0"), HttpWebRequest)
    request.Method = "GET"
    request.Accept = "text/html, application/xhtml+xml, */*"
    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)"
    request.CachePolicy = New RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
    'No caching
    Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
    If response.StatusCode = HttpStatusCode.OK Then
      Dim stream As New StreamReader(response.GetResponseStream())
      Dim html As String = stream.ReadToEnd().ToUpper()
      Dim time As String = Regex.Match(html, ">\d+:\d+:\d+<").Value
      'HH:mm:ss format
      Dim [date] As String = Regex.Match(html, ">\w+,\s\w+\s\d+,\s\d+<").Value
      'dddd, MMMM dd, yyyy
      dateTime__1 = DateTime.Parse(([date] & " " & time).Replace(">", "").Replace("<", ""))
    End If

    Return dateTime__1
  End Function

  Private Sub GetCategoryTypes()
    Categories = PopulateCategories()
    grdProfiles.DataSource = PopulateProfiles()
    grdProfiles.Rows(0).Selected = True
    If grdProfiles.Rows.Count > 0 Then
      grdProfiles.Rows(0).Selected = True
    End If

    SetGridFormatting()
    lblbstripStatus.Text = "Ready"
  End Sub

#End Region

#Region "Send Message"

  ''' <summary>
  ''' Sends messages to Contacts
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub btnSendMessages_Click(sender As System.Object, e As System.EventArgs) Handles btnSendMessages.Click

    Try

      If grdEmails.SelectedRows Is Nothing OrElse grdEmails.SelectedRows.Count = 0 Then
        MsgBox("No Email Selected")
        Exit Sub
      End If

      'Get Settings
      Dim Setting As Setting = DataAccess.PopulateSetting

      'Create an instance of the email class
      Dim SendEmail As New Email(grdEmails.SelectedRows, Setting)

      'Get categories from items selected on the grid
      For Each dr As DataRow In Categories.Tables(0).Rows
        Dim isSelected As Boolean? = dr.Field(Of Boolean?)("Select")
        Dim tabValue As String
        If isSelected.HasValue AndAlso isSelected Then
          tabValue = dr.Field(Of String)("CategoryName")
          If tabValue <> String.Empty Then
            SendEmail.EmailGategories.Add(dr("CategoryName").ToString)
          End If
        End If
      Next

      'Validate Categories
      If SendEmail.EmailGategories Is Nothing OrElse SendEmail.EmailGategories.Count = 0 Then
        MsgBox("No categories selected")
        Exit Sub
      End If

      'Login to account
      SendEmail.wbLogin()

      If SendEmail.LoginFailure = True Then
        MsgBox("Login Failure")
        Exit Sub
      End If

      'Populate recipients dependant whether user requires multiple emails to be sent or one
      If chkTest.Checked = True Then
        SendEmail.NoTotalContactsSent = 1
      ElseIf (Setting.SingleEmail) Then
        SendEmail.PopulateContactsSingleEmail()
      Else
        SendEmail.PopulateContactsMultipleEmail()
      End If

      'Run a user check to ensure that emails should be sent
      Dim DiaRes As DialogResult = MsgBox("Are you sure you want to send email \ emails to " & SendEmail.NoTotalContactsSent & " contacts", MsgBoxStyle.OkCancel)
      If DiaRes = Windows.Forms.DialogResult.Cancel Then
        Exit Sub
      End If

      'DEFINE FROM DATABASE CALL
      'Set email recipients dependant on type of email sending selected
      If chkTest.Checked = True Then
        SendEmail.Recipients = txtTestUser.Text
        SendEmail.wbCompose()
      ElseIf Setting.SingleEmail = False Then
        SendEmail.SendMulitipleEmails()
      Else
        SendEmail.SendSingleEmail()
      End If

      lblbstripStatus.Text = SendEmail.NoTotalContactsSent & "Messages Sent"
      'SendEmail.Logout()

      'lblEmailsAttemptedNo.Text = SendEmail.NoTotalContactsSent
      'lblEmailsAttemptedNo.Text = SendEmail.NoInactiveContactsSent
      'lblEmailsAttemptedNo.Text = (SendEmail.NoTotalContactsSent - SendEmail.NoInactiveContactsSent)

      stripStatus.Text = "Messages Sent"

      SendEmail = Nothing

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region

#Region "Grid Formatting"

  ''' <summary>
  ''' Formats the DataGridViews
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub SetGridFormatting()

    Try

      With Me.grdEmails
        .Columns("EmailSent_PK").Visible = False
        .Columns("Profile_FK").Visible = False
        .Columns("Subject").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
      End With

      With Me.grdProfiles
        .Columns("Profile_PK").Visible = False
      End With

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Populates Email grid based on selected profile
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub grdProfiles_SelectionChanged(sender As Object, e As System.EventArgs) Handles grdProfiles.SelectionChanged

    Try

      Dim CategoriesSelected As New List(Of String)

      For Each SelectedRow As DataGridViewRow In grdProfiles.SelectedRows
        'Get emails associated with Profile
        grdEmails.DataSource = PopulateSavedEmails(SelectedRow.Cells("Profile_PK").Value)
        'Get selected categories saved for profile
        CategoriesSelected = PopulateSelectedCategories(SelectedRow.Cells("Profile_PK").Value)
      Next

      If CategoriesSelected IsNot Nothing AndAlso CategoriesSelected.Count > 0 Then
        For Each Cat In CategoriesSelected
          For Each dr As DataRow In Categories.Tables(0).Rows
            If dr.Item("CategoryName").ToString = Cat Then
              dr.Item("Select") = True
            End If
          Next
        Next
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Stops cells being edited in Profile grid
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub grdProfiles_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdProfiles.CellBeginEdit
    Try

      If e.ColumnIndex <> 0 Then
        e.Cancel = True
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Stops cells being edited in Email grid
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub grdEmails_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdEmails.CellBeginEdit

    Try

      If e.ColumnIndex <> 0 Then
        e.Cancel = True
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Stops cells being selected in Profile grid
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub grdProfiles_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles grdProfiles.CellStateChanged

    Try

      If e.Cell Is Nothing OrElse e.StateChanged <> DataGridViewElementStates.Selected Then
        Return
      End If
      e.Cell.Selected = False

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try


  End Sub

  ''' <summary>
  ''' Stops cells from being selected in Email grid
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub grdEmails_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles grdEmails.CellStateChanged

    Try

      If e.Cell Is Nothing OrElse e.StateChanged <> DataGridViewElementStates.Selected Then
        Return
      End If
      e.Cell.Selected = False

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region

#Region "Database Saves"

  'Private Sub btnUpdateSelectedContacts_Click(sender As System.Object, e As System.EventArgs)

  '  Try

  '    Dim CategoriesSelected As New List(Of String)
  '    Dim Profile_PK As Integer

  '    'Get Profile_PK from selected profile
  '    For Each SelectedRow As DataGridViewRow In grdProfiles.SelectedRows
  '      Profile_PK = (SelectedRow.Cells("Profile_PK").Value)
  '    Next

  '    'Get selected categories and update database
  '    For Each dr As DataRow In Categories.Tables(0).Rows
  '      Dim isSelected As Boolean? = dr.Field(Of Boolean?)("Select")
  '      If isSelected.HasValue AndAlso isSelected Then
  '        CategoriesSelected.Add(dr("CategoryName").ToString)
  '      End If
  '    Next

  '    UpdateSelectedCategories(Profile_PK, CategoriesSelected)

  '  Catch ex As Exception
  '    MsgBox(ex.Message & Now.ToString)
  '  End Try

  'End Sub

#End Region

#Region "Button Navigation"

  Private Sub btnCreateNewEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateNewEmail.Click

    Try

      Dim Profile_FK As Integer
      Dim Action As String = "i"
      Dim Email_PK As Integer = 0

      'Get Profile_PK from selected profile
      For Each SelectedRow As DataGridViewRow In grdProfiles.SelectedRows
        Profile_FK = (SelectedRow.Cells("Profile_PK").Value)
      Next
      Dim frmAddNEwEmail As New AddEmail(Profile_FK, Action, Email_PK)
      frmAddNEwEmail.ShowDialog()

      'Refresh Grid
      grdEmails.DataSource = PopulateSavedEmails(Profile_FK)

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub


  Private Sub txtDeleteMail_Click(sender As System.Object, e As System.EventArgs) Handles txtDeleteMail.Click

    Try

      Dim Action As String = "d"
      Dim Email_PK As Integer
      Dim Profile_FK As Integer
      Dim SubjectLine As String = String.Empty
      Dim Value As Decimal

      'Get Email_PK, Profile_PK and Subject from selected email
      For Each SelectedRow As DataGridViewRow In grdEmails.SelectedRows
        Email_PK = (SelectedRow.Cells("EmailSent_PK").Value)
        Profile_FK = (SelectedRow.Cells("Profile_FK").Value)
        SubjectLine = (SelectedRow.Cells("Subject").Value)
        Value = (SelectedRow.Cells("EstimatedValue").Value)
      Next

      'Delete email
      SaveEmail(Action, Email_PK, Profile_FK, SubjectLine, String.Empty, Value)

      'Refresh Grid
      grdEmails.DataSource = PopulateSavedEmails(Profile_FK)

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  Private Sub grdEmails_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdEmails.CellMouseDoubleClick

    Try

      Dim SelectedRow As New DataGridViewRow
      Dim Profile_FK As Integer
      Dim Email_PK As Integer
      Dim Subject As String = String.Empty
      Dim Body As String = String.Empty
      Dim Value As Decimal = 0

      If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
        SelectedRow = grdEmails.Rows(e.RowIndex)

        Profile_FK = SelectedRow.Cells.Item("Profile_FK").Value
        Email_PK = SelectedRow.Cells.Item("EmailSent_PK").Value
        Subject = SelectedRow.Cells.Item("Subject").Value
        Body = SelectedRow.Cells.Item("Body").Value
        Value = SelectedRow.Cells.Item("EstimatedValue").Value

        Dim UpdateEmail As New AddEmail(Profile_FK, "u", Email_PK, Subject, Body, Value)
        UpdateEmail.ShowDialog()

        'Refresh Grid
        grdEmails.DataSource = PopulateSavedEmails(Profile_FK)

      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  Private Sub Import_Click(sender As System.Object, e As System.EventArgs)

    Try

      Dim sContacts As String
      Dim Status As String
      Dim Profile_FK As Integer

      'If rdActive.Checked Then
      '  Status = "Active"
      'ElseIf rdBlocked.Checked Then
      '  Status = "Blocked"
      'ElseIf rdFlirt.Checked Then
      '  Status = "Flirt"
      'End If

      'Get Profile_PK from selected profile
      For Each SelectedRow As DataGridViewRow In grdProfiles.SelectedRows
        Profile_FK = (SelectedRow.Cells("Profile_PK").Value)
      Next

      Using dlgOpen As New OpenFileDialog()
        Try
          ' Available file extensions
          dlgOpen.Filter = "All files(*.*)|*.*"
          ' Initial directory
          dlgOpen.InitialDirectory = "D:"
          ' OpenFileDialog title
          dlgOpen.Title = "Open"
          ' Show OpenFileDialog box
          If dlgOpen.ShowDialog() = DialogResult.OK Then
            ' Create new StreamReader
            Dim sr As New StreamReader(dlgOpen.FileName)
            ' Get all text from the file
            sContacts = sr.ReadToEnd()
            ' Close the StreamReader
            sr.Close()
          End If

          Dim ContactsImport As New DataTable()
          ContactsImport.Columns.Add("Contact", GetType(String))

          Dim Contacts As String() = sContacts.Split(",")

          For i As Integer = 0 To Contacts.Length - 1
            If Contacts(i) <> "" Then
              ContactsImport.Rows.Add(New Object() {Contacts(i)})
            End If
          Next

          ImportContactsNF(ContactsImport, Profile_FK, Status)

          stripStatus.Text = "Contacts Imported"

        Catch errorMsg As Exception
          MessageBox.Show(errorMsg.Message)
        End Try
      End Using

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region



  Private Sub mCategories_Click(sender As System.Object, e As System.EventArgs) Handles mCategories.Click

    Dim frmCategories As New Categories(Categories)
    frmCategories.ShowDialog()

  End Sub

  Private Sub mTrawler_Click(sender As System.Object, e As System.EventArgs) Handles mTrawler.Click
    Dim frmTrawlerForm As New frmTrawler()
    frmTrawlerForm.ShowDialog()
  End Sub

  Private Sub mSettings_Click(sender As System.Object, e As System.EventArgs) Handles mSettings.Click
    Dim frmSettingForm As New frmSettings()
    frmSettingForm.ShowDialog()
  End Sub

  Private Sub chkTest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTest.CheckedChanged
    If chkTest.Checked = True Then
      txtTestUser.Enabled = True
    Else
      txtTestUser.Text = String.Empty
      txtTestUser.Enabled = False
    End If
  End Sub

    Private Sub ReviewImportedContactsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReviewImportedContactsToolStripMenuItem.Click
        Dim frmContactForReviewForm As New frmContactReview()
        frmContactForReviewForm.ShowDialog()
    End Sub

  Private Sub btnImportContacts_Click(sender As Object, e As EventArgs) Handles btnImportContacts.Click
    Dim impContacts As Trawler = New Trawler()
    Dim profilePK As Integer
    Dim profileName As String

    For Each dr As DataGridViewRow In grdProfiles.SelectedRows
      profilePK = dr.Cells("Profile_PK").Value
      profileName = dr.Cells("ProfileName").Value
    Next
    Dim b As Boolean = impContacts.ImportContacts(profilePK, profileName)


  End Sub
End Class

