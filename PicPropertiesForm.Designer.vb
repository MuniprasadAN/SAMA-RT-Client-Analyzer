''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PicPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PicPropertiesForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnimport = New System.Windows.Forms.Button
        Me.lstPicCollection = New System.Windows.Forms.ListBox
        Me.PicBoxPreview = New System.Windows.Forms.PictureBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.CkBoxStretch = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnimport)
        Me.GroupBox1.Controls.Add(Me.lstPicCollection)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 219)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select image"
        '
        'btnimport
        '
        Me.btnimport.Location = New System.Drawing.Point(119, 190)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(75, 21)
        Me.btnimport.TabIndex = 1
        Me.btnimport.Text = "Import"
        Me.btnimport.UseVisualStyleBackColor = True
        '
        'lstPicCollection
        '
        Me.lstPicCollection.BackColor = System.Drawing.SystemColors.Window
        Me.lstPicCollection.FormattingEnabled = True
        Me.lstPicCollection.Location = New System.Drawing.Point(11, 20)
        Me.lstPicCollection.Name = "lstPicCollection"
        Me.lstPicCollection.Size = New System.Drawing.Size(183, 160)
        Me.lstPicCollection.TabIndex = 0
        '
        'PicBoxPreview
        '
        Me.PicBoxPreview.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PicBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBoxPreview.Location = New System.Drawing.Point(223, 16)
        Me.PicBoxPreview.Name = "PicBoxPreview"
        Me.PicBoxPreview.Size = New System.Drawing.Size(246, 215)
        Me.PicBoxPreview.TabIndex = 1
        Me.PicBoxPreview.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(410, 242)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 21)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(340, 242)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 21)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'CkBoxStretch
        '
        Me.CkBoxStretch.AutoSize = True
        Me.CkBoxStretch.Location = New System.Drawing.Point(224, 243)
        Me.CkBoxStretch.Name = "CkBoxStretch"
        Me.CkBoxStretch.Size = New System.Drawing.Size(108, 17)
        Me.CkBoxStretch.TabIndex = 4
        Me.CkBoxStretch.Text = "Stretch Image"
        Me.CkBoxStretch.UseVisualStyleBackColor = True
        '
        'PicPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 270)
        Me.Controls.Add(Me.CkBoxStretch)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.PicBoxPreview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(491, 297)
        Me.Name = "PicPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstPicCollection As System.Windows.Forms.ListBox
    Friend WithEvents PicBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnimport As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents CkBoxStretch As System.Windows.Forms.CheckBox
End Class
