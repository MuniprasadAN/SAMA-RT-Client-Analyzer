<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorLogForm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorLogForm))
        Me.lstViewErrorLog = New System.Windows.Forms.ListView
        Me.ErrorType = New System.Windows.Forms.ColumnHeader
        Me.ErrTime = New System.Windows.Forms.ColumnHeader
        Me.Desc = New System.Windows.Forms.ColumnHeader
        Me.ErrFun = New System.Windows.Forms.ColumnHeader
        Me.imgListErrorLog = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstViewErrorLog
        '
        Me.lstViewErrorLog.BackColor = System.Drawing.Color.White
        Me.lstViewErrorLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ErrorType, Me.ErrTime, Me.Desc, Me.ErrFun})
        Me.lstViewErrorLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstViewErrorLog.FullRowSelect = True
        Me.lstViewErrorLog.GridLines = True
        Me.lstViewErrorLog.Location = New System.Drawing.Point(0, 0)
        Me.lstViewErrorLog.Name = "lstViewErrorLog"
        Me.lstViewErrorLog.Size = New System.Drawing.Size(894, 369)
        Me.lstViewErrorLog.SmallImageList = Me.imgListErrorLog
        Me.lstViewErrorLog.TabIndex = 0
        Me.lstViewErrorLog.UseCompatibleStateImageBehavior = False
        Me.lstViewErrorLog.View = System.Windows.Forms.View.Details
        '
        'ErrorType
        '
        Me.ErrorType.Text = "Error Type"
        Me.ErrorType.Width = 120
        '
        'ErrTime
        '
        Me.ErrTime.Text = "DateTime"
        Me.ErrTime.Width = 150
        '
        'Desc
        '
        Me.Desc.Text = "Description"
        Me.Desc.Width = 450
        '
        'ErrFun
        '
        Me.ErrFun.Text = "Error Function"
        Me.ErrFun.Width = 181
        '
        'imgListErrorLog
        '
        Me.imgListErrorLog.ImageStream = CType(resources.GetObject("imgListErrorLog.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListErrorLog.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListErrorLog.Images.SetKeyName(0, "Comment-delete-icon.png")
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 369)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(894, 40)
        Me.Panel1.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(709, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear Log"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(806, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(7, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ErrorLogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(894, 409)
        Me.Controls.Add(Me.lstViewErrorLog)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(902, 431)
        Me.Name = "ErrorLogForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Errors Log"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstViewErrorLog As System.Windows.Forms.ListView
    Friend WithEvents ErrorType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Desc As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrFun As System.Windows.Forms.ColumnHeader
    Friend WithEvents ErrTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgListErrorLog As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class
