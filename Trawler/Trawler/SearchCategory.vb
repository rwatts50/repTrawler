Imports System.ComponentModel

Public Class SearchCategory

#Region "Members"

  Private _Selected As Boolean = False
  Private _Category As String

#End Region

#Region "Public Properties"

  Public Property Selected As Boolean
    Get
      Return _Selected
    End Get
    Set(value As Boolean)
      value = _Selected
    End Set
  End Property
  Public Property Category As String
    Get
      Return _Category
    End Get
    Set(value As String)
      _Category = value
    End Set
  End Property

  Public Sub New(bSelected As Boolean, sCategory As String)
    _Selected = bSelected
    _Category = sCategory
  End Sub

#End Region

End Class

