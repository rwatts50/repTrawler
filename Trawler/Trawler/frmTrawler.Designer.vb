<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrawler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrawler))
    Me.grpTrawler = New System.Windows.Forms.GroupBox()
    Me.rdDeepSearch = New System.Windows.Forms.RadioButton()
    Me.progTrawler = New System.Windows.Forms.ProgressBar()
    Me.rdLightSearch = New System.Windows.Forms.RadioButton()
    Me.lblUserName = New System.Windows.Forms.Label()
    Me.btnStopNFTrawl = New System.Windows.Forms.Button()
    Me.lblPassword = New System.Windows.Forms.Label()
    Me.btnStartNFTrawl = New System.Windows.Forms.Button()
    Me.txtTrawlerPassword = New System.Windows.Forms.TextBox()
    Me.txtTrawlerUsername = New System.Windows.Forms.TextBox()
    Me.lstTrawlerActivity = New System.Windows.Forms.ListBox()
    Me.grpTrawler.SuspendLayout()
    Me.SuspendLayout()
    '
    'grpTrawler
    '
    Me.grpTrawler.Controls.Add(Me.rdDeepSearch)
    Me.grpTrawler.Controls.Add(Me.progTrawler)
    Me.grpTrawler.Controls.Add(Me.rdLightSearch)
    Me.grpTrawler.Controls.Add(Me.lblUserName)
    Me.grpTrawler.Controls.Add(Me.btnStopNFTrawl)
    Me.grpTrawler.Controls.Add(Me.lblPassword)
    Me.grpTrawler.Controls.Add(Me.btnStartNFTrawl)
    Me.grpTrawler.Controls.Add(Me.txtTrawlerPassword)
    Me.grpTrawler.Controls.Add(Me.txtTrawlerUsername)
    Me.grpTrawler.Location = New System.Drawing.Point(12, 12)
    Me.grpTrawler.Name = "grpTrawler"
    Me.grpTrawler.Size = New System.Drawing.Size(352, 198)
    Me.grpTrawler.TabIndex = 28
    Me.grpTrawler.TabStop = False
    Me.grpTrawler.Text = "Trawler"
    '
    'rdDeepSearch
    '
    Me.rdDeepSearch.AutoSize = True
    Me.rdDeepSearch.Location = New System.Drawing.Point(209, 21)
    Me.rdDeepSearch.Name = "rdDeepSearch"
    Me.rdDeepSearch.Size = New System.Drawing.Size(88, 17)
    Me.rdDeepSearch.TabIndex = 15
    Me.rdDeepSearch.TabStop = True
    Me.rdDeepSearch.Text = "Deep Search"
    Me.rdDeepSearch.UseVisualStyleBackColor = True
    '
    'progTrawler
    '
    Me.progTrawler.Location = New System.Drawing.Point(51, 145)
    Me.progTrawler.Name = "progTrawler"
    Me.progTrawler.Size = New System.Drawing.Size(271, 23)
    Me.progTrawler.TabIndex = 17
    '
    'rdLightSearch
    '
    Me.rdLightSearch.AutoSize = True
    Me.rdLightSearch.Location = New System.Drawing.Point(209, 44)
    Me.rdLightSearch.Name = "rdLightSearch"
    Me.rdLightSearch.Size = New System.Drawing.Size(85, 17)
    Me.rdLightSearch.TabIndex = 16
    Me.rdLightSearch.TabStop = True
    Me.rdLightSearch.Text = "Light Search"
    Me.rdLightSearch.UseVisualStyleBackColor = True
    '
    'lblUserName
    '
    Me.lblUserName.AutoSize = True
    Me.lblUserName.Location = New System.Drawing.Point(24, 23)
    Me.lblUserName.Name = "lblUserName"
    Me.lblUserName.Size = New System.Drawing.Size(55, 13)
    Me.lblUserName.TabIndex = 5
    Me.lblUserName.Text = "Username"
    '
    'btnStopNFTrawl
    '
    Me.btnStopNFTrawl.Location = New System.Drawing.Point(209, 84)
    Me.btnStopNFTrawl.Name = "btnStopNFTrawl"
    Me.btnStopNFTrawl.Size = New System.Drawing.Size(113, 24)
    Me.btnStopNFTrawl.TabIndex = 2
    Me.btnStopNFTrawl.Text = "Stop NF Trawl"
    Me.btnStopNFTrawl.UseVisualStyleBackColor = True
    '
    'lblPassword
    '
    Me.lblPassword.AutoSize = True
    Me.lblPassword.Location = New System.Drawing.Point(26, 49)
    Me.lblPassword.Name = "lblPassword"
    Me.lblPassword.Size = New System.Drawing.Size(53, 13)
    Me.lblPassword.TabIndex = 6
    Me.lblPassword.Text = "Password"
    '
    'btnStartNFTrawl
    '
    Me.btnStartNFTrawl.Location = New System.Drawing.Point(51, 84)
    Me.btnStartNFTrawl.Name = "btnStartNFTrawl"
    Me.btnStartNFTrawl.Size = New System.Drawing.Size(113, 24)
    Me.btnStartNFTrawl.TabIndex = 1
    Me.btnStartNFTrawl.Text = "Start NF Trawl"
    Me.btnStartNFTrawl.UseVisualStyleBackColor = True
    '
    'txtTrawlerPassword
    '
    Me.txtTrawlerPassword.Location = New System.Drawing.Point(85, 46)
    Me.txtTrawlerPassword.Name = "txtTrawlerPassword"
    Me.txtTrawlerPassword.Size = New System.Drawing.Size(100, 20)
    Me.txtTrawlerPassword.TabIndex = 4
    '
    'txtTrawlerUsername
    '
    Me.txtTrawlerUsername.Location = New System.Drawing.Point(85, 20)
    Me.txtTrawlerUsername.Name = "txtTrawlerUsername"
    Me.txtTrawlerUsername.Size = New System.Drawing.Size(100, 20)
    Me.txtTrawlerUsername.TabIndex = 3
    '
    'lstTrawlerActivity
    '
    Me.lstTrawlerActivity.FormattingEnabled = True
    Me.lstTrawlerActivity.Location = New System.Drawing.Point(12, 217)
    Me.lstTrawlerActivity.Name = "lstTrawlerActivity"
    Me.lstTrawlerActivity.Size = New System.Drawing.Size(352, 134)
    Me.lstTrawlerActivity.TabIndex = 29
    '
    'frmTrawler
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(405, 392)
    Me.Controls.Add(Me.lstTrawlerActivity)
    Me.Controls.Add(Me.grpTrawler)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frmTrawler"
    Me.Text = "Trawler"
    Me.grpTrawler.ResumeLayout(False)
    Me.grpTrawler.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents grpTrawler As System.Windows.Forms.GroupBox
  Friend WithEvents rdDeepSearch As System.Windows.Forms.RadioButton
  Friend WithEvents progTrawler As System.Windows.Forms.ProgressBar
  Friend WithEvents rdLightSearch As System.Windows.Forms.RadioButton
  Friend WithEvents lblUserName As System.Windows.Forms.Label
  Friend WithEvents btnStopNFTrawl As System.Windows.Forms.Button
  Friend WithEvents lblPassword As System.Windows.Forms.Label
  Friend WithEvents btnStartNFTrawl As System.Windows.Forms.Button
  Friend WithEvents txtTrawlerPassword As System.Windows.Forms.TextBox
  Friend WithEvents txtTrawlerUsername As System.Windows.Forms.TextBox
  Friend WithEvents lstTrawlerActivity As System.Windows.Forms.ListBox
End Class
