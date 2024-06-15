<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectServerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectServerForm))
        Me.grpBpxServerIP = New System.Windows.Forms.GroupBox
        Me.btnConnect = New System.Windows.Forms.Button
        Me.CkBoxAutoConnect = New System.Windows.Forms.CheckBox
        Me.txtServerIP = New System.Windows.Forms.TextBox
        Me.lblServerIP = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.grpBpxServerIP.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBpxServerIP
        '
        Me.grpBpxServerIP.Controls.Add(Me.btnConnect)
        Me.grpBpxServerIP.Controls.Add(Me.CkBoxAutoConnect)
        Me.grpBpxServerIP.Controls.Add(Me.txtServerIP)
        Me.grpBpxServerIP.Controls.Add(Me.lblServerIP)
        Me.grpBpxServerIP.Location = New System.Drawing.Point(5, 12)
        Me.grpBpxServerIP.Name = "grpBpxServerIP"
        Me.grpBpxServerIP.Size = New System.Drawing.Size(476, 96)
        Me.grpBpxServerIP.TabIndex = 12
        Me.grpBpxServerIP.TabStop = False
        Me.grpBpxServerIP.Text = "Server IP Address"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(344, 30)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(76, 22)
        Me.btnConnect.TabIndex = 7
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'CkBoxAutoConnect
        '
        Me.CkBoxAutoConnect.AutoSize = True
        Me.CkBoxAutoConnect.Location = New System.Drawing.Point(10, 63)
        Me.CkBoxAutoConnect.Name = "CkBoxAutoConnect"
        Me.CkBoxAutoConnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CkBoxAutoConnect.Size = New System.Drawing.Size(140, 17)
        Me.CkBoxAutoConnect.TabIndex = 6
        Me.CkBoxAutoConnect.Text = "Auto Reconnect :    "
        Me.CkBoxAutoConnect.UseVisualStyleBackColor = True
        '
        'txtServerIP
        '
        Me.txtServerIP.Location = New System.Drawing.Point(134, 32)
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(171, 21)
        Me.txtServerIP.TabIndex = 5
        '
        'lblServerIP
        '
        Me.lblServerIP.AutoSize = True
        Me.lblServerIP.Location = New System.Drawing.Point(14, 35)
        Me.lblServerIP.Name = "lblServerIP"
        Me.lblServerIP.Size = New System.Drawing.Size(75, 13)
        Me.lblServerIP.TabIndex = 5
        Me.lblServerIP.Text = "Server IP  :"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(349, 114)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 22)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(420, 114)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(63, 22)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(7, 119)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 14
        '
        'ConnectServerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 139)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpBpxServerIP)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ConnectServerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connect..."
        Me.grpBpxServerIP.ResumeLayout(False)
        Me.grpBpxServerIP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpBpxServerIP As System.Windows.Forms.GroupBox
    Friend WithEvents CkBoxAutoConnect As System.Windows.Forms.CheckBox
    Friend WithEvents txtServerIP As System.Windows.Forms.TextBox
    Friend WithEvents lblServerIP As System.Windows.Forms.Label
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
