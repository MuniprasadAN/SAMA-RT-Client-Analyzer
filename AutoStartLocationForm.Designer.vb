''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoStartLocationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoStartLocationForm))
        Me.grpboxLocat = New System.Windows.Forms.GroupBox
        Me.ckEnable = New System.Windows.Forms.CheckBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.lblPath = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpboxLocat.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpboxLocat
        '
        Me.grpboxLocat.Controls.Add(Me.ckEnable)
        Me.grpboxLocat.Controls.Add(Me.btnBrowse)
        Me.grpboxLocat.Controls.Add(Me.txtPath)
        Me.grpboxLocat.Controls.Add(Me.lblPath)
        Me.grpboxLocat.Location = New System.Drawing.Point(12, 12)
        Me.grpboxLocat.Name = "grpboxLocat"
        Me.grpboxLocat.Size = New System.Drawing.Size(550, 90)
        Me.grpboxLocat.TabIndex = 0
        Me.grpboxLocat.TabStop = False
        Me.grpboxLocat.Text = "Auto Start File"
        '
        'ckEnable
        '
        Me.ckEnable.AutoSize = True
        Me.ckEnable.Location = New System.Drawing.Point(63, 20)
        Me.ckEnable.Name = "ckEnable"
        Me.ckEnable.Size = New System.Drawing.Size(64, 17)
        Me.ckEnable.TabIndex = 3
        Me.ckEnable.Text = "Enable"
        Me.ckEnable.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(478, 46)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(40, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "....."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(63, 48)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(404, 21)
        Me.txtPath.TabIndex = 1
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(15, 51)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(41, 13)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "Path :"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(426, 108)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(61, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(501, 108)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(61, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'AutoStartLocationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 136)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.grpboxLocat)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AutoStartLocationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auto Start"
        Me.grpboxLocat.ResumeLayout(False)
        Me.grpboxLocat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpboxLocat As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ckEnable As System.Windows.Forms.CheckBox
End Class
