<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentSettings))
        Me.grpboxSettings = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtServerIP = New System.Windows.Forms.TextBox
        Me.lblServerIP = New System.Windows.Forms.Label
        Me.grpBoxPassword = New System.Windows.Forms.GroupBox
        Me.lblRetypePass = New System.Windows.Forms.Label
        Me.lblNewPass = New System.Windows.Forms.Label
        Me.lblOldPass = New System.Windows.Forms.Label
        Me.txtRetypePass = New System.Windows.Forms.TextBox
        Me.txtNewPass = New System.Windows.Forms.TextBox
        Me.txtOldPass = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRemoteDataPath = New System.Windows.Forms.TextBox
        Me.txtHistoryPath = New System.Windows.Forms.TextBox
        Me.lblHistoryPath = New System.Windows.Forms.Label
        Me.lblRemotePath = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.grpboxSettings.SuspendLayout()
        Me.grpBoxPassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpboxSettings
        '
        Me.grpboxSettings.Controls.Add(Me.Label2)
        Me.grpboxSettings.Controls.Add(Me.txtServerIP)
        Me.grpboxSettings.Controls.Add(Me.lblServerIP)
        Me.grpboxSettings.Controls.Add(Me.grpBoxPassword)
        Me.grpboxSettings.Controls.Add(Me.txtRemoteDataPath)
        Me.grpboxSettings.Controls.Add(Me.txtHistoryPath)
        Me.grpboxSettings.Controls.Add(Me.lblHistoryPath)
        Me.grpboxSettings.Controls.Add(Me.lblRemotePath)
        Me.grpboxSettings.Location = New System.Drawing.Point(5, 9)
        Me.grpboxSettings.Name = "grpboxSettings"
        Me.grpboxSettings.Size = New System.Drawing.Size(437, 225)
        Me.grpboxSettings.TabIndex = 3
        Me.grpboxSettings.TabStop = False
        Me.grpboxSettings.Text = "Document Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label2.Location = New System.Drawing.Point(285, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "*Dbl click to Browse..."
        '
        'txtServerIP
        '
        Me.txtServerIP.Location = New System.Drawing.Point(131, 104)
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(171, 21)
        Me.txtServerIP.TabIndex = 14
        '
        'lblServerIP
        '
        Me.lblServerIP.AutoSize = True
        Me.lblServerIP.Location = New System.Drawing.Point(12, 108)
        Me.lblServerIP.Name = "lblServerIP"
        Me.lblServerIP.Size = New System.Drawing.Size(75, 13)
        Me.lblServerIP.TabIndex = 13
        Me.lblServerIP.Text = "Server IP  :"
        '
        'grpBoxPassword
        '
        Me.grpBoxPassword.Controls.Add(Me.lblRetypePass)
        Me.grpBoxPassword.Controls.Add(Me.lblNewPass)
        Me.grpBoxPassword.Controls.Add(Me.lblOldPass)
        Me.grpBoxPassword.Controls.Add(Me.txtRetypePass)
        Me.grpBoxPassword.Controls.Add(Me.txtNewPass)
        Me.grpBoxPassword.Controls.Add(Me.txtOldPass)
        Me.grpBoxPassword.Controls.Add(Me.Label1)
        Me.grpBoxPassword.Location = New System.Drawing.Point(10, 138)
        Me.grpBoxPassword.Name = "grpBoxPassword"
        Me.grpBoxPassword.Size = New System.Drawing.Size(421, 68)
        Me.grpBoxPassword.TabIndex = 4
        Me.grpBoxPassword.TabStop = False
        Me.grpBoxPassword.Text = "Password"
        '
        'lblRetypePass
        '
        Me.lblRetypePass.AutoSize = True
        Me.lblRetypePass.Location = New System.Drawing.Point(327, 17)
        Me.lblRetypePass.Name = "lblRetypePass"
        Me.lblRetypePass.Size = New System.Drawing.Size(47, 13)
        Me.lblRetypePass.TabIndex = 10
        Me.lblRetypePass.Text = "Retype"
        '
        'lblNewPass
        '
        Me.lblNewPass.AutoSize = True
        Me.lblNewPass.Location = New System.Drawing.Point(237, 15)
        Me.lblNewPass.Name = "lblNewPass"
        Me.lblNewPass.Size = New System.Drawing.Size(31, 13)
        Me.lblNewPass.TabIndex = 9
        Me.lblNewPass.Text = "New"
        '
        'lblOldPass
        '
        Me.lblOldPass.AutoSize = True
        Me.lblOldPass.Location = New System.Drawing.Point(138, 15)
        Me.lblOldPass.Name = "lblOldPass"
        Me.lblOldPass.Size = New System.Drawing.Size(30, 13)
        Me.lblOldPass.TabIndex = 8
        Me.lblOldPass.Text = "Old "
        '
        'txtRetypePass
        '
        Me.txtRetypePass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetypePass.Location = New System.Drawing.Point(313, 31)
        Me.txtRetypePass.Name = "txtRetypePass"
        Me.txtRetypePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetypePass.Size = New System.Drawing.Size(80, 21)
        Me.txtRetypePass.TabIndex = 7
        '
        'txtNewPass
        '
        Me.txtNewPass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPass.Location = New System.Drawing.Point(220, 31)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass.Size = New System.Drawing.Size(80, 21)
        Me.txtNewPass.TabIndex = 6
        '
        'txtOldPass
        '
        Me.txtOldPass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPass.Location = New System.Drawing.Point(127, 31)
        Me.txtOldPass.Name = "txtOldPass"
        Me.txtOldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPass.Size = New System.Drawing.Size(80, 21)
        Me.txtOldPass.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Document Editing :"
        '
        'txtRemoteDataPath
        '
        Me.txtRemoteDataPath.Location = New System.Drawing.Point(131, 69)
        Me.txtRemoteDataPath.Name = "txtRemoteDataPath"
        Me.txtRemoteDataPath.Size = New System.Drawing.Size(290, 21)
        Me.txtRemoteDataPath.TabIndex = 3
        '
        'txtHistoryPath
        '
        Me.txtHistoryPath.Location = New System.Drawing.Point(131, 28)
        Me.txtHistoryPath.Name = "txtHistoryPath"
        Me.txtHistoryPath.Size = New System.Drawing.Size(290, 21)
        Me.txtHistoryPath.TabIndex = 2
        '
        'lblHistoryPath
        '
        Me.lblHistoryPath.AutoSize = True
        Me.lblHistoryPath.Location = New System.Drawing.Point(7, 31)
        Me.lblHistoryPath.Name = "lblHistoryPath"
        Me.lblHistoryPath.Size = New System.Drawing.Size(123, 13)
        Me.lblHistoryPath.TabIndex = 1
        Me.lblHistoryPath.Text = "Points History Path :"
        '
        'lblRemotePath
        '
        Me.lblRemotePath.AutoSize = True
        Me.lblRemotePath.Location = New System.Drawing.Point(7, 71)
        Me.lblRemotePath.Name = "lblRemotePath"
        Me.lblRemotePath.Size = New System.Drawing.Size(124, 13)
        Me.lblRemotePath.TabIndex = 0
        Me.lblRemotePath.Text = "Remote Data  Path :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(381, 240)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(63, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(312, 240)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(63, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'DocumentSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 272)
        Me.Controls.Add(Me.grpboxSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DocumentSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Document Settings"
        Me.grpboxSettings.ResumeLayout(False)
        Me.grpboxSettings.PerformLayout()
        Me.grpBoxPassword.ResumeLayout(False)
        Me.grpBoxPassword.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpboxSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServerIP As System.Windows.Forms.TextBox
    Friend WithEvents lblServerIP As System.Windows.Forms.Label
    Friend WithEvents grpBoxPassword As System.Windows.Forms.GroupBox
    Friend WithEvents lblRetypePass As System.Windows.Forms.Label
    Friend WithEvents lblNewPass As System.Windows.Forms.Label
    Friend WithEvents lblOldPass As System.Windows.Forms.Label
    Friend WithEvents txtRetypePass As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents txtOldPass As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRemoteDataPath As System.Windows.Forms.TextBox
    Friend WithEvents txtHistoryPath As System.Windows.Forms.TextBox
    Friend WithEvents lblHistoryPath As System.Windows.Forms.Label
    Friend WithEvents lblRemotePath As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
