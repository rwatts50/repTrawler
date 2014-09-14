Imports Trawler.DataAccess
Imports System.Threading

Public Class Email

#Region "Member Variables"

  Private _EmailContactsSingle As String
  Private _EmailContactsMultiple As List(Of String)
  Private _EmailGategories As New List(Of String)
  Private WithEvents _wb As WebBrowser
  Private _EmailCount As Integer
  Private _IsEmailPostBack As Boolean = False
  Private _NFUserName As String
  Private _NFPassword As String
  Private _Recipients As String
  Private _Subject As String
  Private _Body As String
  Private _dataGridViewSelectedRowCollection As DataGridViewSelectedRowCollection
  Private _NoInactiveContactsSent As Integer
  Private _NoTotalContactsSent As Integer
  Private _EmailSent_FK As Integer
  Private _LogoutInProgress As Boolean
  Private _IsLoginPostBack As Boolean
  Private _LoginFailure As Boolean
  Private _LastFeedbackDate As Date
  Private _NumberOfContacts As Integer
  Private _AdditionalTestContact As String
  Private _NumberOfContactsPerEmailForMultiple As Integer

#End Region

#Region "Public Properties"

  Public Property EmailContactsSingle As String
    Get
      Return _EmailContactsSingle
    End Get
    Set(value As String)
      _EmailContactsSingle = value
    End Set
  End Property
  Public Property EmailContactsMultiple As List(Of String)
    Get
      Return _EmailContactsMultiple
    End Get
    Set(value As List(Of String))
      _EmailContactsMultiple = value
    End Set
  End Property
  Public Property EmailGategories As List(Of String)
    Get
      Return _EmailGategories
    End Get
    Set(value As List(Of String))
      _EmailGategories = value
    End Set
  End Property
  Public Property wb As WebBrowser
    Get
      Return _wb
    End Get
    Set(value As WebBrowser)
      _wb = value
    End Set
  End Property
  Public Property EmailCount As Integer
    Get
      Return _EmailCount
    End Get
    Set(value As Integer)
      _EmailCount = value
    End Set
  End Property
  Public Property NFUserName As String
    Get
      Return _NFUserName
    End Get
    Set(value As String)
      _NFUserName = value
    End Set
  End Property
  Public Property NFPassword As String
    Get
      Return _NFPassword
    End Get
    Set(value As String)
      _NFPassword = value
    End Set
  End Property
  Public Property Recipients As String
    Get
      Return _Recipients
    End Get
    Set(value As String)
      _Recipients = value
    End Set
  End Property
  Public Property Subject As String
    Get
      Return _Subject
    End Get
    Set(value As String)
      _Subject = value
    End Set
  End Property
  Public Property Body As String
    Get
      Return _Body
    End Get
    Set(value As String)
      _Body = value
    End Set
  End Property
  Public Property LoginFailure As Boolean
    Get
      Return _LoginFailure
    End Get
    Set(value As Boolean)
      _LoginFailure = value
    End Set
  End Property
  Public Property NoTotalContactsSent As Integer
    Get
      Return _NoTotalContactsSent
    End Get
    Set(value As Integer)
      _NoTotalContactsSent = value
    End Set
  End Property
  Public Property NoInactiveContactsSent As Integer
    Get
      Return _NoInactiveContactsSent
    End Get
    Set(value As Integer)
      _NoInactiveContactsSent = value
    End Set
  End Property
  Public Property LastFeedbackDate As Date
    Get
      Return _LastFeedbackDate
    End Get
    Set(value As Date)
      _LastFeedbackDate = value
    End Set
  End Property
  Public Property NumberOfContacts As Integer
    Get
      Return _NumberOfContacts
    End Get
    Set(value As Integer)
      _NumberOfContacts = value
    End Set
  End Property
  Public Property AdditionalTestContact As String
    Get
      Return _AdditionalTestContact
    End Get
    Set(value As String)
      _AdditionalTestContact = value
    End Set
  End Property
  Public Property NumberOfContactsPerEmailForMultiple As Integer
    Get
      Return _NumberOfContactsPerEmailForMultiple
    End Get
    Set(value As Integer)
      _NumberOfContactsPerEmailForMultiple = value
    End Set
  End Property
#End Region

#Region "Contructors"

  ''' <summary>
  ''' Default constructor
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub New()
    _wb = New WebBrowser
  End Sub

  ''' <summary>
  '''  Constructor with settings
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub New(setting As Setting)
    _wb = New WebBrowser
  End Sub


  ''' <summary>
  ''' Construnctor for setting subject and body to selected row
  ''' </summary>
  ''' <param name="dc"></param>
  ''' <remarks></remarks>
  Sub New(dc As DataGridViewSelectedRowCollection, Setting As Setting)
    Try

      _wb = New WebBrowser
      _dataGridViewSelectedRowCollection = dc
      If dc IsNot Nothing Then
        For Each dr As DataGridViewRow In dc
          _EmailSent_FK = dr.Cells("EmailSent_PK").Value
          _Subject = dr.Cells("Subject").Value.ToString
          _Body = dr.Cells("Body").Value.ToString
        Next
      End If

      _NFUserName = Setting.NFUserName
      _NFPassword = Setting.NFPassword
      _LastFeedbackDate = Setting.LastFeedbackDate
      _NumberOfContacts = Setting.NumberOfContactsToSendTo
      _AdditionalTestContact = Setting.AdditionalTestContact
      _NumberOfContactsPerEmailForMultiple = Setting.NumberOfContactsPerEmail
    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

#End Region

#Region "Methods"

  ''' <summary>
  ''' Gets all recipients in one string
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub PopulateContactsSingleEmail()
    Try

      _EmailContactsSingle = PopulateEmailContactsSingleEmail(_EmailGategories, _LastFeedbackDate, _NumberOfContacts, _AdditionalTestContact, _EmailSent_FK)
      Dim arrEmailContactsSingle As String() = _EmailContactsSingle.Split(",")
      _NoTotalContactsSent = arrEmailContactsSingle.Length

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Gets recipients in a list with no item in the list being over 1000 charactors long
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub PopulateContactsMultipleEmail()
    Try
      Dim arrEmailContactsSingle As String()
      _NoTotalContactsSent = 0
      _EmailContactsMultiple = PopulateEmailContactsMultipleEmail(_EmailGategories, _LastFeedbackDate, _NumberOfContacts, _AdditionalTestContact, _EmailSent_FK)

      For Each mail In _EmailContactsMultiple
        arrEmailContactsSingle = mail.Split(",")
        _NoTotalContactsSent = _NoTotalContactsSent + arrEmailContactsSingle.Length
      Next

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  ''' <summary>
  ''' Browses to NF login page
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub wbLogin()
    Try

      If (Not String.IsNullOrWhiteSpace(NFUserName)) AndAlso (Not String.IsNullOrWhiteSpace(NFPassword)) Then
        wb.Navigate("https://www.niteflirt.com/login")
        Do While wb.ReadyState <> WebBrowserReadyState.Complete
          Thread.Sleep(100)
          Application.DoEvents()
        Loop
      End If

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub


  ''' <summary>
  ''' Sends multiple emails to recipients
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub SendMulitipleEmails()
    Try

      If EmailContactsMultiple IsNot Nothing AndAlso EmailContactsMultiple.Count > 0 Then
        For Each contact As String In EmailContactsMultiple
          Recipients = contact
          wbCompose()
          Thread.Sleep(300000) 'Wait 5 mins between each email.
        Next
      End If

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  ''' <summary>
  ''' Sends single email to recipients
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub SendSingleEmail()
    Try

      Recipients = EmailContactsSingle
      wbCompose()

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  ''' <summary>
  ''' Browses to compose message page
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub wbCompose()
    Try

      wb.Navigate("http://www.niteflirt.com/messages/compose")
      Do While wb.ReadyState <> WebBrowserReadyState.Complete
        Thread.Sleep(100)
        Application.DoEvents()
      Loop

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

  ''' <summary>
  ''' Navigates to Account to set up logout
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub Logout()

    Try

      _LogoutInProgress = True
      wb.Navigate(" http://www.niteflirt.com/account")
      Do While wb.ReadyState <> WebBrowserReadyState.Complete
        Thread.Sleep(100)
        Application.DoEvents()
      Loop

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message)
    End Try

  End Sub

  ''' <summary>
  ''' Fires when a web page is loaded. Handles logging in and sending messages
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub wb_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles _wb.DocumentCompleted

    Try

      Dim arrInactiveContacts As String()
      Dim listInactiveContacts As New List(Of String)
      Dim FilteredContentsSent As New List(Of String)

      If wb.Document IsNot Nothing Then

        'If at login page - Login
        Dim LoginElement = wb.Document.GetElementById("login")
        If LoginElement IsNot Nothing Then
          If (Not _IsLoginPostBack) Then

            _IsLoginPostBack = True

            Dim ElementUserName As HtmlElement = wb.Document.All.Item("login")
            ElementUserName.InnerText = NFUserName

            Dim ElementPassword As HtmlElement = wb.Document.All.Item("password")
            ElementPassword.InnerText = NFPassword

            wb.Document.GetElementById("commit").InvokeMember("click")

          Else
            _IsLoginPostBack = False
            _LoginFailure = True
          End If

        End If

        'If are email page send email
        Dim EmailElement = wb.Document.GetElementById("message_recipients_list") 'Send Email
        If EmailElement IsNot Nothing Then

          If (Not _IsEmailPostBack) Then

            Dim inputs As HtmlElementCollection = wb.Document.GetElementsByTagName("input")

            For Each Input As HtmlElement In inputs
              If Input.GetAttribute("name").Equals("message[recipients_list]") Then
                Input.SetAttribute("value", Recipients)
              End If
              If Input.GetAttribute("name").Equals("message[subject]") Then
                Input.SetAttribute("value", Subject)
              End If
            Next

            Dim BodyTextBox As HtmlElement = wb.Document.All.Item("message[content]")
            BodyTextBox.InnerText = Body

            wb.Document.GetElementById("commit").InvokeMember("click")

            _IsEmailPostBack = True

          Else

            'If at email postback collect messages about contacts sent
            _IsEmailPostBack = False

            Dim lstElement = wb.Document.GetElementsByTagName("li")
            Dim InactiveContacts As String = String.Empty

            For Each elem As HtmlElement In lstElement
              InactiveContacts = elem.InnerHtml.ToString
              If InactiveContacts.Contains("We're sorry, mail cannot be sent to inactive accounts:") Then
                InactiveContacts = InactiveContacts.Substring((InactiveContacts.IndexOf(":") + 2), (InactiveContacts.Length - (InactiveContacts.IndexOf(":") + 2)))
                arrInactiveContacts = InactiveContacts.Split(",")
                _NoInactiveContactsSent = arrInactiveContacts.Length
                listInactiveContacts = New List(Of String)(arrInactiveContacts)
                ImportInactiveContactsFromEmailSend(listInactiveContacts)
              End If
            Next

            Dim arrContactsSent As String() = Recipients.Split(",")
            Dim ContactsSent As New List(Of String)(arrContactsSent)

            If listInactiveContacts IsNot Nothing Then

              FilteredContentsSent = ContactsSent.Except(listInactiveContacts.Select(Function(x) x.Trim)).ToList()

            End If

            InsertContactEmail(_EmailSent_FK, FilteredContentsSent)  'Update table to show contacts have had this email sent
            InsertEmailActivity(_EmailSent_FK, _NoTotalContactsSent, _NoInactiveContactsSent, (_NoTotalContactsSent - _NoInactiveContactsSent))
          End If

          'If all contacts sent successfully
        ElseIf EmailElement Is Nothing AndAlso _IsEmailPostBack = True Then
          _IsEmailPostBack = False

          Dim arrContactsSent As String() = Recipients.Split(",")
          Dim ContactsSent As New List(Of String)(arrContactsSent)

          InsertContactEmail(_EmailSent_FK, ContactsSent)  'Update table to show contacts have had this email sent
          InsertEmailActivity(_EmailSent_FK, _NoTotalContactsSent, 0, (_NoTotalContactsSent))
        End If
      End If

      'When logging out the browser sends to the my account page so will show balance
      Dim AccountElementForLogout = wb.Document.GetElementById("balance")
      If AccountElementForLogout IsNot Nothing Then
        _IsLoginPostBack = False

        If _LogoutInProgress Then
          _LogoutInProgress = False

          Dim inputs = wb.Document.GetElementsByTagName("a")
          For Each Input As HtmlElement In inputs
            If Input.InnerHtml.Contains("Sign Out") Then
              Input.InvokeMember("click")
            End If
          Next

        End If
      End If

        Catch ex As Exception
            ErrorLog(ex)
            MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region

End Class
