<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EMailSettingform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EMailSettingform))
        Me.pnlEmail = New System.Windows.Forms.Panel
        Me.cmbSSL = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtSMTPPort = New System.Windows.Forms.TextBox
        Me.txtSMTPServer = New System.Windows.Forms.TextBox
        Me.txtEmailPwd = New System.Windows.Forms.TextBox
        Me.txtEmailId = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.pnlEmail.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEmail
        '
        Me.pnlEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEmail.Controls.Add(Me.cmbSSL)
        Me.pnlEmail.Controls.Add(Me.Label22)
        Me.pnlEmail.Controls.Add(Me.txtSMTPPort)
        Me.pnlEmail.Controls.Add(Me.txtSMTPServer)
        Me.pnlEmail.Controls.Add(Me.txtEmailPwd)
        Me.pnlEmail.Controls.Add(Me.txtEmailId)
        Me.pnlEmail.Controls.Add(Me.Label10)
        Me.pnlEmail.Controls.Add(Me.Label9)
        Me.pnlEmail.Controls.Add(Me.Label8)
        Me.pnlEmail.Controls.Add(Me.Label7)
        Me.pnlEmail.Location = New System.Drawing.Point(8, 8)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.Size = New System.Drawing.Size(537, 240)
        Me.pnlEmail.TabIndex = 1
        '
        'cmbSSL
        '
        Me.cmbSSL.FormattingEnabled = True
        Me.cmbSSL.Items.AddRange(New Object() {"True", "False"})
        Me.cmbSSL.Location = New System.Drawing.Point(157, 182)
        Me.cmbSSL.Name = "cmbSSL"
        Me.cmbSSL.Size = New System.Drawing.Size(166, 21)
        Me.cmbSSL.TabIndex = 39
        Me.cmbSSL.Text = "True"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(33, 186)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 13)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "Use SSL"
        '
        'txtSMTPPort
        '
        Me.txtSMTPPort.Location = New System.Drawing.Point(157, 140)
        Me.txtSMTPPort.Name = "txtSMTPPort"
        Me.txtSMTPPort.Size = New System.Drawing.Size(84, 21)
        Me.txtSMTPPort.TabIndex = 37
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.Location = New System.Drawing.Point(157, 104)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.Size = New System.Drawing.Size(166, 21)
        Me.txtSMTPServer.TabIndex = 36
        '
        'txtEmailPwd
        '
        Me.txtEmailPwd.Location = New System.Drawing.Point(157, 68)
        Me.txtEmailPwd.Name = "txtEmailPwd"
        Me.txtEmailPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmailPwd.Size = New System.Drawing.Size(166, 21)
        Me.txtEmailPwd.TabIndex = 35
        '
        'txtEmailId
        '
        Me.txtEmailId.Location = New System.Drawing.Point(157, 33)
        Me.txtEmailId.Name = "txtEmailId"
        Me.txtEmailId.Size = New System.Drawing.Size(278, 21)
        Me.txtEmailId.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "SMTP Port :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "SMTP ServerName :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Email PassWord :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Email ID :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(471, 253)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 22)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(388, 253)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 22)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'EMailSettingform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 278)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pnlEmail)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(557, 300)
        Me.Name = "EMailSettingform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E Mail settings"
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlEmail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents cmbSSL As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPPort As System.Windows.Forms.TextBox
    Friend WithEvents txtSMTPServer As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
