<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
    Me.wbProf = New System.Windows.Forms.WebBrowser()
    Me.stripStatus = New System.Windows.Forms.StatusStrip()
    Me.lblbstripStatus = New System.Windows.Forms.ToolStripStatusLabel()
    Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Menu = New System.Windows.Forms.MenuStrip()
    Me.File = New System.Windows.Forms.ToolStripMenuItem()
    Me.mTrawler = New System.Windows.Forms.ToolStripMenuItem()
    Me.mSettings = New System.Windows.Forms.ToolStripMenuItem()
    Me.mCategories = New System.Windows.Forms.ToolStripMenuItem()
    Me.mExit = New System.Windows.Forms.ToolStripMenuItem()
    Me.lblTest = New System.Windows.Forms.Label()
    Me.grdEmails = New System.Windows.Forms.DataGridView()
    Me.btnSendMessages = New System.Windows.Forms.Button()
    Me.txtDeleteMail = New System.Windows.Forms.Button()
    Me.btnCreateNewEmail = New System.Windows.Forms.Button()
    Me.txtTestUser = New System.Windows.Forms.TextBox()
    Me.grdProfiles = New System.Windows.Forms.DataGridView()
    Me.chkTest = New System.Windows.Forms.CheckBox()
    Me.ListEmailReport = New System.Windows.Forms.ListView()
    Me.stripStatus.SuspendLayout()
    Me.Menu.SuspendLayout()
    CType(Me.grdEmails, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grdProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'wbProf
    '
    Me.wbProf.Location = New System.Drawing.Point(134, 34)
    Me.wbProf.MinimumSize = New System.Drawing.Size(20, 20)
    Me.wbProf.Name = "wbProf"
    Me.wbProf.Size = New System.Drawing.Size(250, 250)
    Me.wbProf.TabIndex = 3
    '
    'stripStatus
    '
    Me.stripStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblbstripStatus, Me.ToolStripStatusLabel1})
    Me.stripStatus.Location = New System.Drawing.Point(0, 437)
    Me.stripStatus.Name = "stripStatus"
    Me.stripStatus.Size = New System.Drawing.Size(779, 22)
    Me.stripStatus.TabIndex = 20
    '
    'lblbstripStatus
    '
    Me.lblbstripStatus.Name = "lblbstripStatus"
    Me.lblbstripStatus.Size = New System.Drawing.Size(0, 17)
    '
    'ToolStripStatusLabel1
    '
    Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
    Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
    Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Menu
    '
    Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File})
    Me.Menu.Location = New System.Drawing.Point(0, 0)
    Me.Menu.Name = "Menu"
    Me.Menu.Size = New System.Drawing.Size(779, 24)
    Me.Menu.TabIndex = 32
    Me.Menu.Text = "Menu"
    '
    'File
    '
    Me.File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mTrawler, Me.mSettings, Me.mCategories, Me.mExit})
    Me.File.Name = "File"
    Me.File.Size = New System.Drawing.Size(37, 20)
    Me.File.Text = "File"
    '
    'mTrawler
    '
    Me.mTrawler.Name = "mTrawler"
    Me.mTrawler.Size = New System.Drawing.Size(130, 22)
    Me.mTrawler.Text = "Trawler"
    '
    'mSettings
    '
    Me.mSettings.Name = "mSettings"
    Me.mSettings.Size = New System.Drawing.Size(130, 22)
    Me.mSettings.Text = "Settings"
    '
    'mCategories
    '
    Me.mCategories.Name = "mCategories"
    Me.mCategories.Size = New System.Drawing.Size(130, 22)
    Me.mCategories.Text = "Categories"
    '
    'mExit
    '
    Me.mExit.Name = "mExit"
    Me.mExit.Size = New System.Drawing.Size(130, 22)
    Me.mExit.Text = "Exit"
    '
    'lblTest
    '
    Me.lblTest.AutoSize = True
    Me.lblTest.Location = New System.Drawing.Point(14, 199)
    Me.lblTest.Name = "lblTest"
    Me.lblTest.Size = New System.Drawing.Size(76, 13)
    Me.lblTest.TabIndex = 38
    Me.lblTest.Text = "Test Recipient"
    '
    'grdEmails
    '
    Me.grdEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grdEmails.Location = New System.Drawing.Point(227, 39)
    Me.grdEmails.MultiSelect = False
    Me.grdEmails.Name = "grdEmails"
    Me.grdEmails.Size = New System.Drawing.Size(536, 212)
    Me.grdEmails.TabIndex = 40
    '
    'btnSendMessages
    '
    Me.btnSendMessages.Location = New System.Drawing.Point(50, 228)
    Me.btnSendMessages.Name = "btnSendMessages"
    Me.btnSendMessages.Size = New System.Drawing.Size(113, 52)
    Me.btnSendMessages.TabIndex = 37
    Me.btnSendMessages.Text = "Send Messages"
    Me.btnSendMessages.UseVisualStyleBackColor = True
    '
    'txtDeleteMail
    '
    Me.txtDeleteMail.Location = New System.Drawing.Point(349, 257)
    Me.txtDeleteMail.Name = "txtDeleteMail"
    Me.txtDeleteMail.Size = New System.Drawing.Size(113, 23)
    Me.txtDeleteMail.TabIndex = 43
    Me.txtDeleteMail.Text = "Delete Email"
    Me.txtDeleteMail.UseVisualStyleBackColor = True
    '
    'btnCreateNewEmail
    '
    Me.btnCreateNewEmail.Location = New System.Drawing.Point(230, 257)
    Me.btnCreateNewEmail.Name = "btnCreateNewEmail"
    Me.btnCreateNewEmail.Size = New System.Drawing.Size(113, 23)
    Me.btnCreateNewEmail.TabIndex = 42
    Me.btnCreateNewEmail.Text = "New NF Email"
    Me.btnCreateNewEmail.UseVisualStyleBackColor = True
    '
    'txtTestUser
    '
    Me.txtTestUser.Location = New System.Drawing.Point(105, 197)
    Me.txtTestUser.Name = "txtTestUser"
    Me.txtTestUser.Size = New System.Drawing.Size(100, 20)
    Me.txtTestUser.TabIndex = 39
    '
    'grdProfiles
    '
    Me.grdProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grdProfiles.Location = New System.Drawing.Point(12, 39)
    Me.grdProfiles.MultiSelect = False
    Me.grdProfiles.Name = "grdProfiles"
    Me.grdProfiles.Size = New System.Drawing.Size(193, 111)
    Me.grdProfiles.TabIndex = 41
    '
    'chkTest
    '
    Me.chkTest.AutoSize = True
    Me.chkTest.Location = New System.Drawing.Point(60, 165)
    Me.chkTest.Name = "chkTest"
    Me.chkTest.Size = New System.Drawing.Size(69, 17)
    Me.chkTest.TabIndex = 44
    Me.chkTest.Text = "Test Mail"
    Me.chkTest.UseVisualStyleBackColor = True
    '
    'ListEmailReport
    '
    Me.ListEmailReport.Location = New System.Drawing.Point(17, 300)
    Me.ListEmailReport.Name = "ListEmailReport"
    Me.ListEmailReport.Size = New System.Drawing.Size(746, 134)
    Me.ListEmailReport.TabIndex = 45
    Me.ListEmailReport.UseCompatibleStateImageBehavior = False
    '
    'Main
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(779, 459)
    Me.Controls.Add(Me.ListEmailReport)
    Me.Controls.Add(Me.chkTest)
    Me.Controls.Add(Me.lblTest)
    Me.Controls.Add(Me.grdEmails)
    Me.Controls.Add(Me.btnSendMessages)
    Me.Controls.Add(Me.txtDeleteMail)
    Me.Controls.Add(Me.btnCreateNewEmail)
    Me.Controls.Add(Me.txtTestUser)
    Me.Controls.Add(Me.grdProfiles)
    Me.Controls.Add(Me.stripStatus)
    Me.Controls.Add(Me.Menu)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.Menu
    Me.Name = "Main"
    Me.Text = "Send Emails"
    Me.stripStatus.ResumeLayout(False)
    Me.stripStatus.PerformLayout()
    Me.Menu.ResumeLayout(False)
    Me.Menu.PerformLayout()
    CType(Me.grdEmails, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grdProfiles, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents wbProf As System.Windows.Forms.WebBrowser
  Friend WithEvents stripStatus As System.Windows.Forms.StatusStrip
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents lblbstripStatus As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents Menu As System.Windows.Forms.MenuStrip
  Friend WithEvents File As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mSettings As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mTrawler As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mExit As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mCategories As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents lblTest As System.Windows.Forms.Label
  Friend WithEvents grdEmails As System.Windows.Forms.DataGridView
  Friend WithEvents btnSendMessages As System.Windows.Forms.Button
  Friend WithEvents txtDeleteMail As System.Windows.Forms.Button
  Friend WithEvents btnCreateNewEmail As System.Windows.Forms.Button
  Friend WithEvents txtTestUser As System.Windows.Forms.TextBox
  Friend WithEvents grdProfiles As System.Windows.Forms.DataGridView
  Friend WithEvents chkTest As System.Windows.Forms.CheckBox
  Friend WithEvents ListEmailReport As System.Windows.Forms.ListView

End Class
