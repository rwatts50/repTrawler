Public Class Setting

#Region "Members"

  Private _Setting_PK As Integer
  Private _LastFeedbackDate As Date
  Private _NumberOfContactsToSendTo As Integer
  Private _SingleEmail As Boolean
  Private _NumberOfContactsPerEmail As Integer
  Private _AdditionalTestContact As String
  Private _NFUserName As String
  Private _NFPassword As String

#End Region

#Region "Public Properties"

  Public Property Setting_PK As Integer
    Get
      Return _Setting_PK
    End Get
    Set(value As Integer)
      _Setting_PK = value
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
  Public Property NumberOfContactsToSendTo As Integer
    Get
      Return _NumberOfContactsToSendTo
    End Get
    Set(value As Integer)
      _NumberOfContactsToSendTo = value
    End Set
  End Property
  Public Property SingleEmail As Boolean
    Get
      Return _SingleEmail
    End Get
    Set(value As Boolean)
      _SingleEmail = value
    End Set
  End Property
  Public Property NumberOfContactsPerEmail As Integer
    Get
      Return _NumberOfContactsPerEmail
    End Get
    Set(value As Integer)
      _NumberOfContactsPerEmail = value
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

  Public Sub New(Setting_PK As Integer, LastFeedbackDate As Date, NumberOfContactsToSendTo As Integer, SingleEmail As Boolean, NumberOfContactsPerEmail As Integer,
                 AdditionalTestContact As String, NFUserName As String, NFPassword As String)


    _Setting_PK = Setting_PK
    _LastFeedbackDate = LastFeedbackDate
    _NumberOfContactsToSendTo = NumberOfContactsToSendTo
    _SingleEmail = SingleEmail
    _NumberOfContactsPerEmail = NumberOfContactsPerEmail
    _AdditionalTestContact = AdditionalTestContact
    _NFUserName = NFUserName
    _NFPassword = NFPassword


  End Sub

  Public Sub New()

  End Sub

#End Region

End Class
