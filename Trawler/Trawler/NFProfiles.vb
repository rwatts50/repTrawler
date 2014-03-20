Public Class NFProfile

#Region "Members"

  Private _Profile_PK As Integer
  Private _ProfileName As String

#End Region

#Region "Public Properties"

  Public Property Profile_PK As Integer
    Get
      Return _Profile_PK
    End Get
    Set(value As Integer)
      _Profile_PK = value
    End Set
  End Property
  Public Property ProfileName As String
    Get
      Return _ProfileName
    End Get
    Set(value As String)
      _ProfileName = value
    End Set
  End Property

#End Region

#Region "Constructors"

  Public Sub New()

  End Sub

  Public Sub New(ByVal Profile_PK As Integer, ByVal ProfileName As String)
    Try

      _Profile_PK = Profile_PK
      _ProfileName = ProfileName

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region

End Class
