Imports HtmlAgilityPack
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.IO
Imports System.Object

Public Class BrowserSession

#Region "Memebers"

  Private _isPost As Boolean
  Private _isDownload As Boolean
  Private _htmlDoc As HtmlDocument
  Private _download As String

#End Region

#Region "Public Properties"

  ''' <summary>
  ''' System.Net.CookieCollection. Provides a collection container for instances of Cookie class 
  ''' </summary>
  Public Property Cookies() As CookieCollection
    Get
      Return m_Cookies
    End Get
    Set(value As CookieCollection)
      m_Cookies = value
    End Set
  End Property
  Private m_Cookies As CookieCollection

  ''' <summary>
  ''' Provide a key-value-pair collection of form elements 
  ''' </summary>
  Public Property FormElements() As FormElementCollection
    Get
      Return m_FormElements
    End Get
    Set(value As FormElementCollection)
      m_FormElements = value
    End Set
  End Property
  Private m_FormElements As FormElementCollection

#End Region

#Region "Public Methods"

  ''' <summary>
  ''' Makes a HTTP GET request to the given URL
  ''' </summary>
  Public Function [Get](url As String) As String
    _isPost = False
    CreateWebRequestObject().Load(url)
    Return _htmlDoc.DocumentNode.InnerHtml
  End Function

  ''' <summary>
  ''' Makes a HTTP POST request to the given URL
  ''' </summary>
  Public Function Post(url As String) As String
    _isPost = True
    CreateWebRequestObject().Load(url, "POST")
    Return _htmlDoc.DocumentNode.InnerHtml
  End Function

  Public Function GetDownload(url As String) As String
    _isPost = False
    _isDownload = True
    CreateWebRequestObject().Load(url)
    Return _download
  End Function

  ''' <summary>
  ''' Creates the HtmlWeb object and initializes all event handlers. 
  ''' </summary>
  Private Function CreateWebRequestObject() As HtmlWeb
    Dim web As New HtmlWeb()
    web.UseCookies = True
    web.PreRequest = New HtmlWeb.PreRequestHandler(AddressOf OnPreRequest)
    web.PostResponse = New HtmlWeb.PostResponseHandler(AddressOf OnAfterResponse)
    web.PreHandleDocument = New HtmlWeb.PreHandleDocumentHandler(AddressOf OnPreHandleDocument)
    Return web
  End Function

  ''' <summary>
  ''' Event handler for HtmlWeb.PreRequestHandler. Occurs before an HTTP request is executed.
  ''' </summary>
  Protected Function OnPreRequest(request As HttpWebRequest) As Boolean
    AddCookiesTo(request)
    ' Add cookies that were saved from previous requests
    If _isPost Then
      AddPostDataTo(request)
    End If
    ' We only need to add post data on a POST request
    Return True
  End Function

  ''' <summary>
  ''' Event handler for HtmlWeb.PostResponseHandler. Occurs after a HTTP response is received
  ''' </summary>
  Protected Sub OnAfterResponse(request As HttpWebRequest, response As HttpWebResponse)
    SaveCookiesFrom(request, response)
    ' Save cookies for subsequent requests
    If response IsNot Nothing AndAlso _isDownload Then
      Dim remoteStream As Stream = response.GetResponseStream()
      Dim sr = New StreamReader(remoteStream)
      _download = sr.ReadToEnd()
    End If
  End Sub

  ''' <summary>
  ''' Event handler for HtmlWeb.PreHandleDocumentHandler. Occurs before a HTML document is handled
  ''' </summary>
  Protected Sub OnPreHandleDocument(document As HtmlDocument)
    SaveHtmlDocument(document)
  End Sub

  ''' <summary>
  ''' Assembles the Post data and attaches to the request object
  ''' </summary>
  Private Sub AddPostDataTo(request As HttpWebRequest)
    Dim payload As String = FormElements.AssemblePostPayload()
    Dim buff As Byte() = Encoding.UTF8.GetBytes(payload.ToCharArray())
    request.ContentLength = buff.Length
    request.ContentType = "application/x-www-form-urlencoded"
    Dim reqStream As System.IO.Stream = request.GetRequestStream()
    reqStream.Write(buff, 0, buff.Length)
  End Sub

  ''' <summary>
  ''' Add cookies to the request object
  ''' </summary>
  Private Sub AddCookiesTo(request As HttpWebRequest)
    If Cookies IsNot Nothing AndAlso Cookies.Count > 0 Then
      request.CookieContainer.Add(Cookies)
    End If
  End Sub

  ''' <summary>
  ''' Saves cookies from the response object to the local CookieCollection object
  ''' </summary>
  Private Sub SaveCookiesFrom(request As HttpWebRequest, response As HttpWebResponse)
    'save the cookies ;)
    If request.CookieContainer.Count > 0 OrElse response.Cookies.Count > 0 Then
      If Cookies Is Nothing Then
        Cookies = New CookieCollection()
      End If

      Cookies.Add(request.CookieContainer.GetCookies(request.RequestUri))
      Cookies.Add(response.Cookies)
    End If
  End Sub

  ''' <summary>
  ''' Saves the form elements collection by parsing the HTML document
  ''' </summary>
  Private Sub SaveHtmlDocument(document As HtmlDocument)
    _htmlDoc = document
    FormElements = New FormElementCollection(_htmlDoc)
  End Sub

#End Region

End Class

''' <summary>
''' Represents a combined list and collection of Form Elements.
''' </summary>
Public Class FormElementCollection
  Inherits Dictionary(Of String, String)

#Region "Constructors"

  ''' <summary>
  ''' Constructor. Parses the HtmlDocument to get all form input elements. 
  ''' </summary>
  Public Sub New(htmlDoc As HtmlDocument)
    Dim inputs = htmlDoc.DocumentNode.Descendants("input")
    For Each element In inputs
      Dim name As String = element.GetAttributeValue("name", "undefined")
      Dim value As String = element.GetAttributeValue("value", "")

      If Not Me.ContainsKey(name) Then
        If Not name.Equals("undefined") Then
          Add(name, value)
        End If
      End If
    Next
  End Sub

#End Region

#Region "Methods"

  ''' <summary>
  ''' Assembles all form elements and values to POST. Also html encodes the values.  
  ''' </summary>
  Public Function AssemblePostPayload() As String
    Dim sb As New StringBuilder()
    For Each element In Me
      Dim value As String = System.Web.httputility.UrlEncode(element.Value)
      sb.Append("&" & Convert.ToString(element.Key) & "=" & value)
    Next
    Return sb.ToString().Substring(1)
  End Function

#End Region

End Class
