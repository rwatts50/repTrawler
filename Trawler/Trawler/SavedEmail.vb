Public Class SavedEmail

#Region "Members"

  Private _EmailSent_PK As Integer
  Private _Profile_FK As Integer
  Private _Subject As String
  Private _Body As String
  Private _EstimatedValue As Decimal

#End Region

#Region "Public Properties"

  Public Property EmailSent_PK As Integer
    Get
      Return _EmailSent_PK
    End Get
    Set(value As Integer)
      _EmailSent_PK = value
    End Set
  End Property
  Public Property Profile_FK As Integer
    Get
      Return _Profile_FK
    End Get
    Set(value As Integer)
      _Profile_FK = value
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
  Public Property EstimatedValue As Decimal
    Get
      Return _EstimatedValue
    End Get
    Set(value As Decimal)
      _EstimatedValue = value
    End Set
  End Property

#End Region

#Region "Constructors"

  Public Sub New()

  End Sub

  Public Sub New(ByVal EmailSent_PK As Integer, ByVal Profile_FK As Integer, ByVal Subject As String, ByVal Body As String, ByVal EstimatedValue As Decimal)
    Try

      _EmailSent_PK = EmailSent_PK
      _Profile_FK = Profile_FK
      _Subject = Subject
      _Body = Body
      _EstimatedValue = EstimatedValue

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try
  End Sub

#End Region

End Class
