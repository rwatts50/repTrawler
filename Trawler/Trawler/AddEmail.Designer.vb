<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmail
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
    Me.txtBody = New System.Windows.Forms.TextBox()
    Me.txtSubject = New System.Windows.Forms.TextBox()
    Me.lblSubject = New System.Windows.Forms.Label()
    Me.lblBody = New System.Windows.Forms.Label()
    Me.btnSave = New System.Windows.Forms.Button()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.lblValue = New System.Windows.Forms.Label()
    Me.txtValue = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'txtBody
    '
    Me.txtBody.Location = New System.Drawing.Point(55, 57)
    Me.txtBody.Multiline = True
    Me.txtBody.Name = "txtBody"
    Me.txtBody.Size = New System.Drawing.Size(399, 117)
    Me.txtBody.TabIndex = 22
    '
    'txtSubject
    '
    Me.txtSubject.Location = New System.Drawing.Point(55, 22)
    Me.txtSubject.Name = "txtSubject"
    Me.txtSubject.Size = New System.Drawing.Size(399, 20)
    Me.txtSubject.TabIndex = 19
    '
    'lblSubject
    '
    Me.lblSubject.AutoSize = True
    Me.lblSubject.Location = New System.Drawing.Point(6, 29)
    Me.lblSubject.Name = "lblSubject"
    Me.lblSubject.Size = New System.Drawing.Size(43, 13)
    Me.lblSubject.TabIndex = 20
    Me.lblSubject.Text = "Subject"
    '
    'lblBody
    '
    Me.lblBody.AutoSize = True
    Me.lblBody.Location = New System.Drawing.Point(18, 60)
    Me.lblBody.Name = "lblBody"
    Me.lblBody.Size = New System.Drawing.Size(31, 13)
    Me.lblBody.TabIndex = 21
    Me.lblBody.Text = "Body"
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(276, 226)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(106, 23)
    Me.btnSave.TabIndex = 23
    Me.btnSave.Text = "Save"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(95, 226)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(121, 23)
    Me.btnCancel.TabIndex = 24
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'lblValue
    '
    Me.lblValue.AutoSize = True
    Me.lblValue.Location = New System.Drawing.Point(12, 189)
    Me.lblValue.Name = "lblValue"
    Me.lblValue.Size = New System.Drawing.Size(34, 13)
    Me.lblValue.TabIndex = 25
    Me.lblValue.Text = "Value"
    '
    'txtValue
    '
    Me.txtValue.Location = New System.Drawing.Point(55, 182)
    Me.txtValue.Name = "txtValue"
    Me.txtValue.Size = New System.Drawing.Size(100, 20)
    Me.txtValue.TabIndex = 26
    '
    'AddEmail
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(466, 277)
    Me.Controls.Add(Me.txtValue)
    Me.Controls.Add(Me.lblValue)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnSave)
    Me.Controls.Add(Me.txtBody)
    Me.Controls.Add(Me.txtSubject)
    Me.Controls.Add(Me.lblSubject)
    Me.Controls.Add(Me.lblBody)
    Me.Name = "AddEmail"
    Me.Text = "AddEmail"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtBody As System.Windows.Forms.TextBox
  Friend WithEvents txtSubject As System.Windows.Forms.TextBox
  Friend WithEvents lblSubject As System.Windows.Forms.Label
  Friend WithEvents lblBody As System.Windows.Forms.Label
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents lblValue As System.Windows.Forms.Label
  Friend WithEvents txtValue As System.Windows.Forms.TextBox
End Class
