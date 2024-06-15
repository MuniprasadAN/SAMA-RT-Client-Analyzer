''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PanelPropertiesForm))
        Me.grpBoxPanel = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.rdobtnNone = New System.Windows.Forms.RadioButton()
        Me.rdobtnRaisedEdge = New System.Windows.Forms.RadioButton()
        Me.BGColorLbl = New System.Windows.Forms.Label()
        Me.lblBGColor = New System.Windows.Forms.Label()
        Me.grpBoxPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBoxPanel
        '
        Me.grpBoxPanel.Controls.Add(Me.btnCancel)
        Me.grpBoxPanel.Controls.Add(Me.btnOK)
        Me.grpBoxPanel.Controls.Add(Me.rdobtnNone)
        Me.grpBoxPanel.Controls.Add(Me.rdobtnRaisedEdge)
        Me.grpBoxPanel.Controls.Add(Me.BGColorLbl)
        Me.grpBoxPanel.Controls.Add(Me.lblBGColor)
        Me.grpBoxPanel.Location = New System.Drawing.Point(12, 12)
        Me.grpBoxPanel.Name = "grpBoxPanel"
        Me.grpBoxPanel.Size = New System.Drawing.Size(487, 151)
        Me.grpBoxPanel.TabIndex = 0
        Me.grpBoxPanel.TabStop = False
        Me.grpBoxPanel.Text = "Panel Properties"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(349, 63)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 55
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(349, 34)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 54
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rdobtnNone
        '
        Me.rdobtnNone.AutoSize = True
        Me.rdobtnNone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdobtnNone.Location = New System.Drawing.Point(169, 95)
        Me.rdobtnNone.Name = "rdobtnNone"
        Me.rdobtnNone.Size = New System.Drawing.Size(63, 17)
        Me.rdobtnNone.TabIndex = 53
        Me.rdobtnNone.TabStop = True
        Me.rdobtnNone.Text = "None :"
        Me.rdobtnNone.UseVisualStyleBackColor = True
        '
        'rdobtnRaisedEdge
        '
        Me.rdobtnRaisedEdge.AutoSize = True
        Me.rdobtnRaisedEdge.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdobtnRaisedEdge.Location = New System.Drawing.Point(33, 95)
        Me.rdobtnRaisedEdge.Name = "rdobtnRaisedEdge"
        Me.rdobtnRaisedEdge.Size = New System.Drawing.Size(104, 17)
        Me.rdobtnRaisedEdge.TabIndex = 52
        Me.rdobtnRaisedEdge.TabStop = True
        Me.rdobtnRaisedEdge.Text = "Raised Edge :"
        Me.rdobtnRaisedEdge.UseVisualStyleBackColor = True
        '
        'BGColorLbl
        '
        Me.BGColorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BGColorLbl.Location = New System.Drawing.Point(155, 48)
        Me.BGColorLbl.Name = "BGColorLbl"
        Me.BGColorLbl.Size = New System.Drawing.Size(92, 24)
        Me.BGColorLbl.TabIndex = 5
        '
        'lblBGColor
        '
        Me.lblBGColor.AutoSize = True
        Me.lblBGColor.Location = New System.Drawing.Point(32, 54)
        Me.lblBGColor.Name = "lblBGColor"
        Me.lblBGColor.Size = New System.Drawing.Size(119, 13)
        Me.lblBGColor.TabIndex = 4
        Me.lblBGColor.Text = "Background Color :"
        '
        'PanelPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 171)
        Me.Controls.Add(Me.grpBoxPanel)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(527, 210)
        Me.Name = "PanelPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.grpBoxPanel.ResumeLayout(False)
        Me.grpBoxPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBoxPanel As System.Windows.Forms.GroupBox
    Friend WithEvents BGColorLbl As System.Windows.Forms.Label
    Friend WithEvents lblBGColor As System.Windows.Forms.Label
    Friend WithEvents rdobtnNone As System.Windows.Forms.RadioButton
    Friend WithEvents rdobtnRaisedEdge As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
