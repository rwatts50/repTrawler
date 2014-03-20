Public Class ContactInfo

#Region "Members"

  Private _ContactName As String
  Private _currentFeedbackDate As String
  Private _FlirtName As String
  Private _FlirtLink As String

#End Region

#Region "Constructor"

  Sub New(ContactName As String, CurrentFeedbackDate As String, FlirtName As String, FlirtLink As String)
    Try

    _ContactName = ContactName
    _currentFeedbackDate = CurrentFeedbackDate
    _FlirtName = FlirtName
    _FlirtLink = FlirtLink

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

#End Region

#Region "Public Properties"

  Public Property ContactName As String
    Get
      Return _ContactName
    End Get
    Set(value As String)
      _ContactName = value
    End Set
  End Property
  Public Property FeedbackDate As String
    Get
      Return _currentFeedbackDate
    End Get
    Set(value As String)
      value = _currentFeedbackDate
    End Set
  End Property
  Public Property FlirtName As String
    Get
      Return _FlirtName
    End Get
    Set(value As String)
      _FlirtName = value
    End Set
  End Property
  Public Property FlirtLink As String
    Get
      Return _FlirtLink
    End Get
    Set(value As String)
      value = _FlirtLink
    End Set
  End Property

#End Region

End Class