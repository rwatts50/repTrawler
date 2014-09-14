Imports Trawler.DataAccess

Public Class Categories

  Private _categories As DataSet

  Public Sub New(Categories As DataSet)

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    _categories = Categories
    grdEmailCategories.DataSource = _categories.Tables(0)

    With Me.grdEmailCategories
      .Columns("CategoryName").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End With

  End Sub

  Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
    Me.Close()
  End Sub

  Private Sub btnUpdateSelectedContacts_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateSelectedContacts.Click

    UpdateContacts()
    Me.Close()

  End Sub

  Private Sub btnApply_Click(sender As System.Object, e As System.EventArgs) Handles btnApply.Click

    UpdateContacts()

  End Sub

  Private Sub UpdateContacts()

    Try

      Dim CategoriesSelected As New List(Of String)
      Dim Profile_PK As Integer

      'Get Profile_PK from selected profile
      For Each SelectedRow As DataGridViewRow In Main.grdProfiles.SelectedRows
        Profile_PK = (SelectedRow.Cells("Profile_PK").Value)
      Next

      'Get selected categories and update database
      For Each dr As DataRow In _categories.Tables(0).Rows
        Dim isSelected As Boolean? = dr.Field(Of Boolean?)("Select")
        If isSelected.HasValue AndAlso isSelected Then
          CategoriesSelected.Add(dr("CategoryName").ToString)
        End If
      Next

      UpdateSelectedCategories(Profile_PK, CategoriesSelected)


    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

    Private Sub grdEmailCategories_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdEmailCategories.CellContentClick

    End Sub
End Class