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

Public Class Trawler

#Region "Members"

  Private _UserName As String
  Private _Password As String
  Private _BSession As BrowserSession
  Private _WebAddresses As List(Of SearchAddressLink)
  Private _FlirtLinksAlreadyKnown As List(Of String)
  Private _StopTrawl As Boolean = False
  Private _DeepSearch As Boolean = False
  Private _LightSearch As Boolean = False
  Private _FlirtLinksAlreadyScraped As New List(Of String)

#End Region

#Region "Public Properties"

  Public Property UserName As String
    Get
      Return _UserName
    End Get
    Set(value As String)
      _UserName = value
    End Set
  End Property
  Public Property Password As String
    Get
      Return _Password
    End Get
    Set(value As String)
      _Password = value
    End Set
  End Property
  Public Property BSession As BrowserSession
    Get
      Return _BSession
    End Get
    Set(value As BrowserSession)
      _BSession = value
    End Set
  End Property
  Public Property WebAddresses As List(Of SearchAddressLink)
    Get
      Return _WebAddresses
    End Get
    Set(value As List(Of SearchAddressLink))
      _WebAddresses = value
    End Set
  End Property
  Public Property FlirtLinksAlreadyKnown As List(Of String)
    Get
      Return _FlirtLinksAlreadyKnown
    End Get
    Set(value As List(Of String))
      _FlirtLinksAlreadyKnown = value
    End Set
  End Property
  Public Property StopTrawl As Boolean
    Get
      Return _StopTrawl
    End Get
    Set(value As Boolean)
      _StopTrawl = value
    End Set
  End Property
  Public Property DeepSearch As Boolean
    Get
      Return _DeepSearch
    End Get
    Set(value As Boolean)
      _DeepSearch = value
    End Set
  End Property
  Public Property LightSearch As Boolean
    Get
      Return _LightSearch
    End Get
    Set(value As Boolean)
      _LightSearch = value
    End Set
  End Property

#End Region

#Region "Constructors"

  Public Sub New()
    _BSession = New BrowserSession
    _WebAddresses = New List(Of SearchAddressLink)
  End Sub

#End Region

#Region "Public Methods"

  Public Function StartTrawl() As String

    Try

      Dim CategoryWebAddresses As New List(Of SearchAddressLink)
      Dim CategoryPageWebAddress As String = String.Empty
      Dim usernames As List(Of ContactInfo) = New List(Of ContactInfo)
      Dim LastPageNumber As Integer
      Dim LastSearchPage As Integer = 50
      Dim hw As New HtmlWeb()

      'Login to the site
      If (Not NFLogin()) Then
        Return "Login Falied"
      End If

      'Populate web addresses already known
      CategoryWebAddresses = PopulateWebAddresses()

      'Get List of Links already scraped
      _FlirtLinksAlreadyScraped = PopulateFlirtLinks()

      'Loop through all web addresses 
      For Each SearchAddLink As SearchAddressLink In CategoryWebAddresses

        'If no web address has been found exit sub
        If SearchAddLink.Address = String.Empty Then
          Return ("No Web Addresses Loaded")
        End If

        'Set the amount of feedback pages to search
        If SearchAddLink.Address = MAIN_PAGE Then
          LastSearchPage = 100
        ElseIf SearchAddLink.IsTopLevelCatagory = True Then
          LastSearchPage = 50
        Else
          LastSearchPage = 20
        End If

        'Loop through search pages
        For i = 1 To LastSearchPage

          CategoryPageWebAddress = SearchAddLink.Address & "?page=" & i

          'Get urls for the profiles on that page
          Dim PageProfiles As List(Of String) = GetPageProfiles(CategoryPageWebAddress)
          If PageProfiles Is Nothing OrElse PageProfiles.Count = 0 Then
            Continue For
          End If

          'Loop through feedback pages of profile
          For Each FlirtProfile As String In PageProfiles

            'Get Last Page Number
            LastPageNumber = GetLastPageNumber(FlirtProfile)

            'Get Usernames
            usernames = GetUserNames(FlirtProfile, LastPageNumber)

            If _StopTrawl = True Then
              Return "Trawl Stopped"
            End If

            'Write event log
            WriteFlirtEventLog(FlirtProfile, LastPageNumber)
          Next

          'Insert usernames into database
          If usernames IsNot Nothing OrElse usernames.Count > 0 Then
            For Each continfo As ContactInfo In usernames
              InsertContacts(continfo)
            Next
          Else
            Continue For
          End If

          WritePageEventLog(SearchAddLink, i)

        Next
        'Run Database import
        ImportToDatabase(SearchAddLink.CategoryType)
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return "All categories Searched"

  End Function

#End Region

#Region "Private Methods"

  ''' <summary>
  ''' Logs into NF with credentials provided
  ''' </summary>
  ''' <remarks></remarks>
  Public Function NFLogin() As Boolean

    Try

      _BSession.[Get]("http://www.niteflirt.com/login")
      _BSession.FormElements("login") = UserName
      _BSession.FormElements("password") = Password
      Dim response As String = _BSession.Post("https://www.niteflirt.com/login")
      If response.Contains("Please try again later") Then
        Return False
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return True

  End Function

  ''' <summary>
  ''' Get all the web addresses of the 12 profiles on a search page
  ''' </summary>
  ''' <param name="CategoryPageWebAddress"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetPageProfiles(ByVal CategoryPageWebAddress As String) As List(Of String)

    Dim PageProfiles As List(Of String) = New List(Of String)

    Try

      'Get all links from starting web page
      Dim hw As New HtmlWeb()
      Dim doc As HtmlDocument = hw.Load(CategoryPageWebAddress)

      For Each link As HtmlNode In doc.DocumentNode.SelectNodes("//a[@href]")
        Dim att As HtmlAttribute = link.Attributes("href")
        PageProfiles.Add(att.Value)
      Next

      'Get the 12 profile links on the page
      PageProfiles = PageProfiles.Where(Function(y) y.Length > 39).ToList
      PageProfiles = PageProfiles.Where(Function(x) x.Substring(0, 39) = "http://www.niteflirt.com/listings/show/").ToList

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return PageProfiles.Distinct.ToList

  End Function

  ''' <summary>
  ''' Get the last feedback page number of a Profile
  ''' </summary>
  ''' <param name="FlirtProfile"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetLastPageNumber(ByVal FlirtProfile As String) As Integer

    Try

      Dim hw As New HtmlWeb()
      Dim doc As HtmlDocument = hw.Load(FlirtProfile)
      doc = hw.Load(FlirtProfile & "?page=1")
      'If deep search chosen always go to the end of the feedback page
      If DeepSearch = True Then
        Return ExtractLastFeedbackPageNumber(doc.DocumentNode.SelectNodes("//div[@class='pagination new_pagination']//a[@href]"))
      Else
        'If link already exists only scrape the first three pages of feedback as older data already gathered
        If _FlirtLinksAlreadyScraped.Any(Function(x) x.ToString = FlirtProfile.ToString) Then
          Return 3
        Else
          Return ExtractLastFeedbackPageNumber(doc.DocumentNode.SelectNodes("//div[@class='pagination new_pagination']//a[@href]"))
        End If
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return 3

  End Function

  ''' <summary>
  ''' Get the usernames from a feedback page
  ''' </summary>
  ''' <param name="FlirtProfile"></param>
  ''' <param name="LastPageNumber"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetUserNames(ByVal FlirtProfile As String, ByVal LastPageNumber As Integer) As List(Of ContactInfo)

    Dim usernames As List(Of ContactInfo) = New List(Of ContactInfo)

    Try

      Dim hw As New HtmlWeb()
      Dim doc As HtmlDocument = hw.Load(FlirtProfile)
      Dim FlirtName As String = String.Empty

      For z = 1 To LastPageNumber
        Dim webpage As String = BSession.Get(FlirtProfile & "?page=" & z)
        doc.LoadHtml(webpage)
        If doc IsNot Nothing Then
          If z = 1 Then
            FlirtName = GetFlirtName(doc.DocumentNode.SelectNodes("//h3"))
          End If
          If doc.DocumentNode IsNot Nothing Then
            If doc.DocumentNode.SelectNodes("//td") IsNot Nothing Then
              If doc.DocumentNode.SelectNodes("//td").Count > 0 Then
                usernames.AddRange(ExtractUsernames(doc.DocumentNode.SelectNodes("//td"), FlirtName, FlirtProfile))
              End If
            End If
          End If
        End If
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return usernames

  End Function


  Private Function GetFlirtName(html As HtmlNodeCollection) As String

    Try

      If html Is Nothing Then
        Return String.Empty
      End If

      'Get the value of the column and print it
      For Each col As HtmlNode In html
        If col.InnerText.Contains(":") Then
          Return col.InnerText.Substring(0, col.InnerText.IndexOf(":"))
        End If
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return String.Empty

  End Function

  ''' <summary>
  ''' Returns the maximum feedback page number
  ''' </summary>
  ''' <param name="Links"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function ExtractLastFeedbackPageNumber(ByVal Links As HtmlNodeCollection) As Integer

    Try

      If Links Is Nothing OrElse Links.Count < 3 Then
        Return 1
      End If

      Dim NodeWanted As Integer = Links.Count - 2
      Dim Node As HtmlNode = Links.Nodes(NodeWanted)

      If IsNumeric(Node.InnerHtml) Then
        Return CInt(Node.InnerHtml)
      Else
        Return 1000
      End If

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return 1

  End Function

  ''' <summary>
  ''' Extract the usernames from the HTML version of the feedback page
  ''' </summary>
  ''' <param name="html"></param>
  ''' <param name="FlirtLink"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function ExtractUsernames(ByVal html As HtmlNodeCollection, ByVal FlirtName As String, ByVal FlirtLink As String) As List(Of ContactInfo)

    Dim List As New List(Of ContactInfo)

    Try

      Dim Position As Integer = 0
      Dim DoCapture As Boolean = False
      Dim Day As String
      Dim Month As String
      Dim Year As String
      Dim CurrentFeedbackDate As String

      If html Is Nothing Then
        Return List
      End If

      'Get the value of the column and print it
      For Each col As HtmlNode In html
        If col.InnerText.Length > 6 AndAlso col.InnerText.Substring(2, 3) = "..." Then
          NFLogin()
          Return List
        ElseIf DoCapture = True Then
          'List.Add(Trim(col.InnerText))
          If (Not String.IsNullOrWhiteSpace(col.InnerText)) Then
            List.Add(New ContactInfo(Trim(col.InnerText), CurrentFeedbackDate, FlirtName, FlirtLink))
          End If
          DoCapture = False
        ElseIf col.InnerText.Length > 6 AndAlso col.InnerText.Substring(2, 1) = "/" Then
          Day = col.InnerText.Substring(3, 2)
          Month = col.InnerText.Substring(0, 2)
          Year = col.InnerText.Substring(6, 4)
          If IsDate(Day & "/" & Month & "/" & Year) Then
            DoCapture = True
            CurrentFeedbackDate = Day & "/" & Month & "/" & Year
          End If
        End If
      Next

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    Return List
  End Function

#End Region

End Class
