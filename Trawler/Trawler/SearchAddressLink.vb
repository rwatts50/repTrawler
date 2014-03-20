Imports Trawler.Constants

Public Class SearchAddressLink

#Region "Members"

  Private _Address As String
  Private _CategoryType As Integer
  Private _IsTopLevelCatagory As Boolean

#End Region

#Region "Constructors"

  Sub New(Address As String, CategoryType As Integer, IsTopLevelCatagory As Boolean)
    Try

      _Address = Address
      _CategoryType = CategoryType
      _IsTopLevelCatagory = IsTopLevelCatagory

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

#End Region

#Region "Public Properties"

  Public Property Address As String
    Get
      Return _Address
    End Get
    Set(value As String)
      value = _Address
    End Set
  End Property
  Public Property CategoryType As Integer
    Get
      Return _CategoryType
    End Get
    Set(value As Integer)
      _CategoryType = value
    End Set
  End Property
  Public Property IsTopLevelCatagory As Boolean
    Get
      Return _IsTopLevelCatagory
    End Get
    Set(value As Boolean)
      _IsTopLevelCatagory = value
    End Set
  End Property

#End Region

End Class
