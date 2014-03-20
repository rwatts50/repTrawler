Public Class frmTrawler

  Private Trawl As Trawler

  Private Sub frmTrawler_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    rdLightSearch.Checked = True
    Trawl = New Trawler
  End Sub


  ''' <summary>
  ''' Main Proc to control the direction of the scrape, gather data and then save to database
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub btnStartNFTrawl_Click(sender As System.Object, e As System.EventArgs) Handles btnStartNFTrawl.Click

    Try

      Trawl.UserName = txtTrawlerUsername.Text
      Trawl.Password = txtTrawlerPassword.Text

      If rdDeepSearch.Checked = True Then
        Trawl.DeepSearch = True
      Else
        Trawl.LightSearch = True
      End If

      txtTrawlerUsername.Enabled = False
      txtTrawlerPassword.Text = String.Empty
      txtTrawlerPassword.Enabled = False

      Trawl.StartTrawl()

      'Dim repsonse As String = Trawl.StartTrawl()

      'Dim TrawlThread As New System.Threading.Thread(TrawlThread.Start(Function()
      '                                                                   For N As Integer = 0 To 99
      '                                                                     Thread.Sleep(50)
      '                                                                     progTrawler.Value = N
      '                                                                   Next
      '                                                                   lblbstripStatus.Text = "Trawl Completed"
      '                                                                 End Function))
      'TrawlThread.Start()
      'AddressOf trawl.StartTrawl

      'lblbstripStatus.Text = repsonse

      txtTrawlerUsername.Enabled = True
      txtTrawlerUsername.Text = String.Empty
      txtTrawlerPassword.Enabled = True

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

  ''' <summary>
  ''' Sets a stop parameter to exit the next loop.
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub btnStopNFTrawl_Click(sender As System.Object, e As System.EventArgs) Handles btnStopNFTrawl.Click
    Try

      Trawl.StopTrawl = True
      txtTrawlerUsername.Enabled = True
      txtTrawlerUsername.Text = String.Empty
      txtTrawlerPassword.Enabled = True

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

  End Sub

 
End Class