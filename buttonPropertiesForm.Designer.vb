<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class buttonPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(buttonPropertiesForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox()
        Me.lblTitleFont = New System.Windows.Forms.Label()
        Me.txtTitleFont = New System.Windows.Forms.TextBox()
        Me.btnTitleFont = New System.Windows.Forms.Button()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.CBoxStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.forecolorlbl = New System.Windows.Forms.Label()
        Me.lblForecolor = New System.Windows.Forms.Label()
        Me.BackColorlbl = New System.Windows.Forms.Label()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblComponent = New System.Windows.Forms.Label()
        Me.lblActionType = New System.Windows.Forms.Label()
        Me.CBoxActionType = New System.Windows.Forms.ComboBox()
        Me.cBoxComponent = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GrpMaxMinValues)
        Me.GroupBox1.Controls.Add(Me.cBoxComponent)
        Me.GroupBox1.Controls.Add(Me.lblComponent)
        Me.GroupBox1.Controls.Add(Me.CBoxActionType)
        Me.GroupBox1.Controls.Add(Me.lblActionType)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 225)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.lblTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.txtTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.btnTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.txtText)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCaption)
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.Label1)
        Me.GrpMaxMinValues.Controls.Add(Me.forecolorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblForecolor)
        Me.GrpMaxMinValues.Controls.Add(Me.BackColorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(11, 89)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(565, 125)
        Me.GrpMaxMinValues.TabIndex = 55
        Me.GrpMaxMinValues.TabStop = False
        Me.GrpMaxMinValues.Text = "Color Settings"
        '
        'lblTitleFont
        '
        Me.lblTitleFont.AutoSize = True
        Me.lblTitleFont.Location = New System.Drawing.Point(19, 47)
        Me.lblTitleFont.Name = "lblTitleFont"
        Me.lblTitleFont.Size = New System.Drawing.Size(40, 13)
        Me.lblTitleFont.TabIndex = 113
        Me.lblTitleFont.Text = "Font :"
        '
        'txtTitleFont
        '
        Me.txtTitleFont.Location = New System.Drawing.Point(100, 43)
        Me.txtTitleFont.Name = "txtTitleFont"
        Me.txtTitleFont.ReadOnly = True
        Me.txtTitleFont.Size = New System.Drawing.Size(288, 21)
        Me.txtTitleFont.TabIndex = 112
        '
        'btnTitleFont
        '
        Me.btnTitleFont.Location = New System.Drawing.Point(394, 42)
        Me.btnTitleFont.Name = "btnTitleFont"
        Me.btnTitleFont.Size = New System.Drawing.Size(49, 21)
        Me.btnTitleFont.TabIndex = 111
        Me.btnTitleFont.Text = "Font..."
        Me.btnTitleFont.UseVisualStyleBackColor = True
        '
        'txtText
        '
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtText.Location = New System.Drawing.Point(100, 16)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(154, 21)
        Me.txtText.TabIndex = 109
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(18, 24)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(40, 13)
        Me.lblCaption.TabIndex = 110
        Me.lblCaption.Text = "Text :"
        '
        'CBoxStyle
        '
        Me.CBoxStyle.FormattingEnabled = True
        Me.CBoxStyle.Items.AddRange(New Object() {"Flat", "Popup", "Standard"})
        Me.CBoxStyle.Location = New System.Drawing.Point(101, 98)
        Me.CBoxStyle.Name = "CBoxStyle"
        Me.CBoxStyle.Size = New System.Drawing.Size(121, 21)
        Me.CBoxStyle.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Style :"
        '
        'forecolorlbl
        '
        Me.forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.forecolorlbl.Location = New System.Drawing.Point(260, 73)
        Me.forecolorlbl.Name = "forecolorlbl"
        Me.forecolorlbl.Size = New System.Drawing.Size(63, 17)
        Me.forecolorlbl.TabIndex = 27
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(185, 75)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(73, 13)
        Me.lblForecolor.TabIndex = 26
        Me.lblForecolor.Text = "Fore color :"
        '
        'BackColorlbl
        '
        Me.BackColorlbl.BackColor = System.Drawing.SystemColors.Control
        Me.BackColorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BackColorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BackColorlbl.Location = New System.Drawing.Point(101, 73)
        Me.BackColorlbl.Name = "BackColorlbl"
        Me.BackColorlbl.Size = New System.Drawing.Size(63, 17)
        Me.BackColorlbl.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(18, 74)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(76, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Back color :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(522, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 21)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(447, 244)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(68, 21)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblComponent
        '
        Me.lblComponent.AutoSize = True
        Me.lblComponent.Location = New System.Drawing.Point(15, 64)
        Me.lblComponent.Name = "lblComponent"
        Me.lblComponent.Size = New System.Drawing.Size(82, 13)
        Me.lblComponent.TabIndex = 53
        Me.lblComponent.Text = "Component :"
        '
        'lblActionType
        '
        Me.lblActionType.AutoSize = True
        Me.lblActionType.Location = New System.Drawing.Point(15, 29)
        Me.lblActionType.Name = "lblActionType"
        Me.lblActionType.Size = New System.Drawing.Size(82, 13)
        Me.lblActionType.TabIndex = 51
        Me.lblActionType.Text = "Action Type :"
        '
        'CBoxActionType
        '
        Me.CBoxActionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBoxActionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBoxActionType.DropDownHeight = 80
        Me.CBoxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxActionType.FormattingEnabled = True
        Me.CBoxActionType.IntegralHeight = False
        Me.CBoxActionType.ItemHeight = 13
        Me.CBoxActionType.Items.AddRange(New Object() {"Change Page", "Print", "Export", "Exit"})
        Me.CBoxActionType.Location = New System.Drawing.Point(142, 28)
        Me.CBoxActionType.Name = "CBoxActionType"
        Me.CBoxActionType.Size = New System.Drawing.Size(166, 21)
        Me.CBoxActionType.TabIndex = 52
        '
        'cBoxComponent
        '
        Me.cBoxComponent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxComponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxComponent.DropDownHeight = 80
        Me.cBoxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxComponent.FormattingEnabled = True
        Me.cBoxComponent.IntegralHeight = False
        Me.cBoxComponent.ItemHeight = 13
        Me.cBoxComponent.Location = New System.Drawing.Point(142, 60)
        Me.cBoxComponent.Name = "cBoxComponent"
        Me.cBoxComponent.Size = New System.Drawing.Size(274, 21)
        Me.cBoxComponent.TabIndex = 54
        '
        'buttonPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 271)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "buttonPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents CBoxStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents forecolorlbl As System.Windows.Forms.Label
    Friend WithEvents lblForecolor As System.Windows.Forms.Label
    Friend WithEvents BackColorlbl As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblTitleFont As System.Windows.Forms.Label
    Friend WithEvents txtTitleFont As System.Windows.Forms.TextBox
    Friend WithEvents btnTitleFont As System.Windows.Forms.Button
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents cBoxComponent As ComboBox
    Friend WithEvents lblComponent As Label
    Friend WithEvents CBoxActionType As ComboBox
    Friend WithEvents lblActionType As Label
End Class
