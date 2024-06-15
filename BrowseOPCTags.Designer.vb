<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseOPCTags
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
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chklstTreeValues = New System.Windows.Forms.CheckedListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.ComBxServer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnbrowsse = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.pnlSearch.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.Panel3)
        Me.pnlSearch.Controls.Add(Me.Panel2)
        Me.pnlSearch.Location = New System.Drawing.Point(41, 71)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(290, 384)
        Me.pnlSearch.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chklstTreeValues)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(288, 354)
        Me.Panel3.TabIndex = 1
        '
        'chklstTreeValues
        '
        Me.chklstTreeValues.CheckOnClick = True
        Me.chklstTreeValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklstTreeValues.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstTreeValues.FormattingEnabled = True
        Me.chklstTreeValues.Location = New System.Drawing.Point(0, 0)
        Me.chklstTreeValues.Name = "chklstTreeValues"
        Me.chklstTreeValues.Size = New System.Drawing.Size(288, 354)
        Me.chklstTreeValues.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtSearchText)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(288, 28)
        Me.Panel2.TabIndex = 0
        '
        'txtSearchText
        '
        Me.txtSearchText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchText.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(288, 31)
        Me.txtSearchText.TabIndex = 0
        '
        'ComBxServer
        '
        Me.ComBxServer.FormattingEnabled = True
        Me.ComBxServer.Location = New System.Drawing.Point(77, 28)
        Me.ComBxServer.Name = "ComBxServer"
        Me.ComBxServer.Size = New System.Drawing.Size(201, 21)
        Me.ComBxServer.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Server"
        '
        'btnbrowsse
        '
        Me.btnbrowsse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowsse.Location = New System.Drawing.Point(296, 28)
        Me.btnbrowsse.Name = "btnbrowsse"
        Me.btnbrowsse.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowsse.TabIndex = 4
        Me.btnbrowsse.Text = "Browse Tags"
        Me.btnbrowsse.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(102, 474)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(194, 474)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 6
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'BrowseOPCTags
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 509)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnbrowsse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComBxServer)
        Me.Controls.Add(Me.pnlSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(393, 548)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(393, 548)
        Me.Name = "BrowseOPCTags"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BrowseOPCTags"
        Me.pnlSearch.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chklstTreeValues As CheckedListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearchText As TextBox
    Friend WithEvents ComBxServer As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnbrowsse As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btncancel As Button
End Class
