Public Class frmTrawler

  Private WithEvents Trawl As Trawler
  Private ProgressBarTotalCount As Integer
  Private StopTrawl As Boolean
  Private TrawlerThread As System.Threading.Thread

  Private Sub frmTrawler_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    rdLightSearch.Checked = True
    lblTrawl.Text = String.Empty
  End Sub


  ''' <summary>
  ''' Main Proc to control the direction of the scrape, gather data and then save to database
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub btnStartNFTrawl_Click(sender As System.Object, e As System.EventArgs) Handles btnStartNFTrawl.Click

    Try

      Trawl = New Trawler

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

      btnStartNFTrawl.Enabled = False
      btnStopNFTrawl.Enabled = True

      txtTrawlerUsername.Enabled = True
            'txtTrawlerUsername.Text = String.Empty
      txtTrawlerPassword.Enabled = True

      lstTrawlerActivity.MultiColumn = True

      TrawlerThread = New Threading.Thread(AddressOf Trawl.StartTrawl)
      TrawlerThread.IsBackground = True
      TrawlerThread.Start()

    Catch ex As Exception
      MsgBox(ex.Message & Now.ToString)
    End Try

    End Sub

    Private Sub UpdateListBox(ByVal report As String) Handles Trawl._DisplayReport

        If lstTrawlerActivity.InvokeRequired Then
            lstTrawlerActivity.Invoke(New Action(Of String)(AddressOf UpdateListBox), report)
        Else
            lstTrawlerActivity.BeginUpdate()
            lstTrawlerActivity.Items.Add(report)
            lstTrawlerActivity.EndUpdate()
        End If

    End Sub

    Private Sub UpdateProgressBarTotalCount(ByVal TotalCount As Integer) Handles Trawl._UpdateTotalCount
        ProgressBarTotalCount = TotalCount
    End Sub

    Private Sub UpdateProgressBar(ByVal Count As Integer) Handles Trawl._DisplayProgressBar

        If progTrawler.InvokeRequired Then
            progTrawler.Invoke(New Action(Of Integer)(AddressOf UpdateProgressBar), Count)
        Else
            progTrawler.Value = (Count / ProgressBarTotalCount * 100)
        End If

        If lblTrawl.InvokeRequired Then
            lblTrawl.Invoke(New Action(Of Integer)(AddressOf UpdateProgressBar), Count)
        Else
            lblTrawl.Text = Count & "of " & ProgressBarTotalCount & " imported"
        End If

    End Sub

  


    ''' <summary>
    ''' Sets a stop parameter to exit the next loop.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStopNFTrawl_Click(sender As System.Object, e As System.EventArgs) Handles btnStopNFTrawl.Click
        Try

            StopTrawl = True

            ' Enable to Start Button
            btnStartNFTrawl.Enabled = True
            ' Disable to Stop Button
            btnStopNFTrawl.Enabled = False

            txtTrawlerUsername.Enabled = True
            txtTrawlerPassword.Enabled = True

            If Not TrawlerThread Is Nothing Then
                If TrawlerThread.ThreadState = Threading.ThreadState.Running Then
                    TrawlerThread.Abort()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & Now.ToString)
        End Try

    End Sub


End Class