<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Categories
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Categories))
    Me.grdEmailCategories = New System.Windows.Forms.DataGridView()
    Me.btnUpdateSelectedContacts = New System.Windows.Forms.Button()
    Me.btnExit = New System.Windows.Forms.Button()
    Me.btnApply = New System.Windows.Forms.Button()
    CType(Me.grdEmailCategories, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'grdEmailCategories
    '
    Me.grdEmailCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grdEmailCategories.Location = New System.Drawing.Point(12, 12)
    Me.grdEmailCategories.Name = "grdEmailCategories"
    Me.grdEmailCategories.RowHeadersVisible = False
    Me.grdEmailCategories.Size = New System.Drawing.Size(355, 444)
    Me.grdEmailCategories.TabIndex = 35
    '
    'btnUpdateSelectedContacts
    '
    Me.btnUpdateSelectedContacts.Location = New System.Drawing.Point(25, 462)
    Me.btnUpdateSelectedContacts.Name = "btnUpdateSelectedContacts"
    Me.btnUpdateSelectedContacts.Size = New System.Drawing.Size(98, 23)
    Me.btnUpdateSelectedContacts.TabIndex = 36
    Me.btnUpdateSelectedContacts.Text = "OK"
    Me.btnUpdateSelectedContacts.UseVisualStyleBackColor = True
    '
    'btnExit
    '
    Me.btnExit.Location = New System.Drawing.Point(138, 462)
    Me.btnExit.Name = "btnExit"
    Me.btnExit.Size = New System.Drawing.Size(98, 23)
    Me.btnExit.TabIndex = 37
    Me.btnExit.Text = "Cancel"
    Me.btnExit.UseVisualStyleBackColor = True
    '
    'btnApply
    '
    Me.btnApply.Location = New System.Drawing.Point(255, 462)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(98, 23)
    Me.btnApply.TabIndex = 38
    Me.btnApply.Text = "Apply"
    Me.btnApply.UseVisualStyleBackColor = True
    '
    'Categories
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(386, 495)
    Me.Controls.Add(Me.btnApply)
    Me.Controls.Add(Me.btnExit)
    Me.Controls.Add(Me.grdEmailCategories)
    Me.Controls.Add(Me.btnUpdateSelectedContacts)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "Categories"
    Me.Text = "Categories"
    CType(Me.grdEmailCategories, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents grdEmailCategories As System.Windows.Forms.DataGridView
  Friend WithEvents btnUpdateSelectedContacts As System.Windows.Forms.Button
  Friend WithEvents btnExit As System.Windows.Forms.Button
  Friend WithEvents btnApply As System.Windows.Forms.Button
End Class
