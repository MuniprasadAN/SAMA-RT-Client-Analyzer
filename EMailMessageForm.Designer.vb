<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EMailMessageForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EMailMessageForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblindi = New System.Windows.Forms.Label
        Me.CkboxAttach = New System.Windows.Forms.CheckBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.rtxboxMsg = New System.Windows.Forms.RichTextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.lblSubject = New System.Windows.Forms.Label
        Me.lblTo = New System.Windows.Forms.Label
        Me.lblFrom = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblindi)
        Me.GroupBox1.Controls.Add(Me.CkboxAttach)
        Me.GroupBox1.Controls.Add(Me.lblMsg)
        Me.GroupBox1.Controls.Add(Me.rtxboxMsg)
        Me.GroupBox1.Controls.Add(Me.txtSubject)
        Me.GroupBox1.Controls.Add(Me.lblSubject)
        Me.GroupBox1.Controls.Add(Me.lblTo)
        Me.GroupBox1.Controls.Add(Me.lblFrom)
        Me.GroupBox1.Controls.Add(Me.txtTo)
        Me.GroupBox1.Controls.Add(Me.txtFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 361)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Write Message "
        '
        'lblindi
        '
        Me.lblindi.AutoSize = True
        Me.lblindi.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblindi.Location = New System.Drawing.Point(36, 91)
        Me.lblindi.Name = "lblindi"
        Me.lblindi.Size = New System.Drawing.Size(276, 13)
        Me.lblindi.TabIndex = 23
        Me.lblindi.Text = "Add Multiple Receiver  seperated by Comma(,)"
        '
        'CkboxAttach
        '
        Me.CkboxAttach.AutoSize = True
        Me.CkboxAttach.Checked = True
        Me.CkboxAttach.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkboxAttach.Location = New System.Drawing.Point(12, 305)
        Me.CkboxAttach.Name = "CkboxAttach"
        Me.CkboxAttach.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CkboxAttach.Size = New System.Drawing.Size(100, 17)
        Me.CkboxAttach.TabIndex = 22
        Me.CkboxAttach.Text = "Attachment :"
        Me.CkboxAttach.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(9, 167)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(65, 13)
        Me.lblMsg.TabIndex = 21
        Me.lblMsg.Text = "Message :"
        '
        'rtxboxMsg
        '
        Me.rtxboxMsg.Location = New System.Drawing.Point(74, 164)
        Me.rtxboxMsg.Name = "rtxboxMsg"
        Me.rtxboxMsg.Size = New System.Drawing.Size(234, 113)
        Me.rtxboxMsg.TabIndex = 20
        Me.rtxboxMsg.Text = ""
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(74, 118)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(234, 21)
        Me.txtSubject.TabIndex = 19
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(9, 125)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(59, 13)
        Me.lblSubject.TabIndex = 18
        Me.lblSubject.Text = "Subject :"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(9, 62)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(30, 13)
        Me.lblTo.TabIndex = 17
        Me.lblTo.Text = "To :"
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(9, 33)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(45, 13)
        Me.lblFrom.TabIndex = 16
        Me.lblFrom.Text = "From :"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(74, 59)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(234, 21)
        Me.txtTo.TabIndex = 15
        '
        'txtFrom
        '
        Me.txtFrom.Enabled = False
        Me.txtFrom.Location = New System.Drawing.Point(74, 26)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(234, 21)
        Me.txtFrom.TabIndex = 14
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(248, 372)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 22)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(165, 372)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 22)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'EMailMessageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 400)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(344, 427)
        Me.Name = "EMailMessageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail Message"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents rtxboxMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents CkboxAttach As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblindi As System.Windows.Forms.Label
End Class
