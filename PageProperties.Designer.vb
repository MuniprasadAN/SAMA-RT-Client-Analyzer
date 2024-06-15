''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PageProperties))
        Me.GboxPageProperties = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.rdoBoxEnable = New System.Windows.Forms.RadioButton
        Me.lblstatus = New System.Windows.Forms.Label
        Me.BGColorLbl = New System.Windows.Forms.Label
        Me.lblBGColor = New System.Windows.Forms.Label
        Me.txtPageName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.GboxPageProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'GboxPageProperties
        '
        Me.GboxPageProperties.Controls.Add(Me.btnCancel)
        Me.GboxPageProperties.Controls.Add(Me.btnOK)
        Me.GboxPageProperties.Controls.Add(Me.rdoBoxEnable)
        Me.GboxPageProperties.Controls.Add(Me.lblstatus)
        Me.GboxPageProperties.Controls.Add(Me.BGColorLbl)
        Me.GboxPageProperties.Controls.Add(Me.lblBGColor)
        Me.GboxPageProperties.Controls.Add(Me.txtPageName)
        Me.GboxPageProperties.Controls.Add(Me.lblName)
        Me.GboxPageProperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxPageProperties.Location = New System.Drawing.Point(6, 1)
        Me.GboxPageProperties.Name = "GboxPageProperties"
        Me.GboxPageProperties.Size = New System.Drawing.Size(444, 104)
        Me.GboxPageProperties.TabIndex = 0
        Me.GboxPageProperties.TabStop = False
        Me.GboxPageProperties.Text = "Page Properties"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(358, 52)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(358, 23)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rdoBoxEnable
        '
        Me.rdoBoxEnable.AutoSize = True
        Me.rdoBoxEnable.Checked = True
        Me.rdoBoxEnable.Location = New System.Drawing.Point(144, 112)
        Me.rdoBoxEnable.Name = "rdoBoxEnable"
        Me.rdoBoxEnable.Size = New System.Drawing.Size(63, 17)
        Me.rdoBoxEnable.TabIndex = 5
        Me.rdoBoxEnable.TabStop = True
        Me.rdoBoxEnable.Text = "Enable"
        Me.rdoBoxEnable.UseVisualStyleBackColor = True
        Me.rdoBoxEnable.Visible = False
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(21, 112)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(52, 13)
        Me.lblstatus.TabIndex = 4
        Me.lblstatus.Text = "Status :"
        Me.lblstatus.Visible = False
        '
        'BGColorLbl
        '
        Me.BGColorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BGColorLbl.Location = New System.Drawing.Point(144, 66)
        Me.BGColorLbl.Name = "BGColorLbl"
        Me.BGColorLbl.Size = New System.Drawing.Size(92, 24)
        Me.BGColorLbl.TabIndex = 3
        '
        'lblBGColor
        '
        Me.lblBGColor.AutoSize = True
        Me.lblBGColor.Location = New System.Drawing.Point(21, 72)
        Me.lblBGColor.Name = "lblBGColor"
        Me.lblBGColor.Size = New System.Drawing.Size(119, 13)
        Me.lblBGColor.TabIndex = 2
        Me.lblBGColor.Text = "Background Color :"
        '
        'txtPageName
        '
        Me.txtPageName.Location = New System.Drawing.Point(144, 26)
        Me.txtPageName.Name = "txtPageName"
        Me.txtPageName.Size = New System.Drawing.Size(190, 21)
        Me.txtPageName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(21, 33)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(81, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Page Name :"
        '
        'PageProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 114)
        Me.Controls.Add(Me.GboxPageProperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(460, 136)
        Me.MinimizeBox = False
        Me.Name = "PageProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GboxPageProperties.ResumeLayout(False)
        Me.GboxPageProperties.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GboxPageProperties As System.Windows.Forms.GroupBox
    Friend WithEvents BGColorLbl As System.Windows.Forms.Label
    Friend WithEvents lblBGColor As System.Windows.Forms.Label
    Friend WithEvents txtPageName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents rdoBoxEnable As System.Windows.Forms.RadioButton
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
