<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
    Me.btnImportAcive = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.btnImportBlocked = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'btnImportAcive
    '
    Me.btnImportAcive.Location = New System.Drawing.Point(43, 209)
    Me.btnImportAcive.Name = "btnImportAcive"
    Me.btnImportAcive.Size = New System.Drawing.Size(97, 27)
    Me.btnImportAcive.TabIndex = 0
    Me.btnImportAcive.Text = "Import Active"
    Me.btnImportAcive.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(163, 210)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(276, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "This will import new active contacts. If any currently exist "
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(163, 223)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(151, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "their status will be set to active"
    '
    'btnImportBlocked
    '
    Me.btnImportBlocked.Location = New System.Drawing.Point(43, 267)
    Me.btnImportBlocked.Name = "btnImportBlocked"
    Me.btnImportBlocked.Size = New System.Drawing.Size(97, 27)
    Me.btnImportBlocked.TabIndex = 3
    Me.btnImportBlocked.Text = "Import Blocked"
    Me.btnImportBlocked.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(169, 281)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(295, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Any contacts in the file which do not exist will not be imported"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(167, 267)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(268, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "This will change the status of any contacts to Blocked. "
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(43, 322)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(97, 27)
    Me.Button1.TabIndex = 6
    Me.Button1.Text = "Import Customer"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(169, 322)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(295, 13)
    Me.Label5.TabIndex = 7
    Me.Label5.Text = "When customers have been in contact with a profile account"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(170, 336)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(294, 13)
    Me.Label6.TabIndex = 8
    Me.Label6.Text = "you may want to send them mails direct from tje Flirts account"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(169, 349)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(306, 13)
    Me.Label7.TabIndex = 9
    Me.Label7.Text = "by importing customers the contacts will remain in the database "
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(170, 362)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(280, 13)
    Me.Label8.TabIndex = 10
    Me.Label8.Text = "assigned to a flirts profile but no emails will be sent to them"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(12, 24)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(496, 20)
    Me.Label9.TabIndex = 11
    Me.Label9.Text = "The admin page allows management of the contacts in the database."
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(13, 48)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(360, 20)
    Me.Label10.TabIndex = 12
    Me.Label10.Text = "Each contact can have one of the following status"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(39, 94)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(40, 13)
    Me.Label11.TabIndex = 13
    Me.Label11.Text = "Active:"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(39, 114)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(49, 13)
    Me.Label12.TabIndex = 14
    Me.Label12.Text = "Blocked:"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(44, 133)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(26, 13)
    Me.Label13.TabIndex = 15
    Me.Label13.Text = "Flirt:"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(43, 159)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(48, 13)
    Me.Label14.TabIndex = 16
    Me.Label14.Text = "Inactive:"
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(94, 94)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(243, 13)
    Me.Label15.TabIndex = 17
    Me.Label15.Text = "All active contacts will have contacts sent to them"
    '
    'frmAdmin
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(646, 436)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.btnImportBlocked)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btnImportAcive)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frmAdmin"
    Me.Text = "Admin"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnImportAcive As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnImportBlocked As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
