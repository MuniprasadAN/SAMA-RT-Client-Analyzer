''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabelPropertiesForm))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox()
        Me.TbProperty = New System.Windows.Forms.TabControl()
        Me.TpComponentName = New System.Windows.Forms.TabPage()
        Me.grpBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox()
        Me.CKBoxUnderLine = New System.Windows.Forms.RadioButton()
        Me.Ckboxbtnitalic = New System.Windows.Forms.RadioButton()
        Me.CKboxBold = New System.Windows.Forms.RadioButton()
        Me.CBoxStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUDFontSize = New System.Windows.Forms.NumericUpDown()
        Me.CBoxFont = New System.Windows.Forms.ComboBox()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.forecolorlbl = New System.Windows.Forms.Label()
        Me.lblForecolor = New System.Windows.Forms.Label()
        Me.lblCtrlBackColor = New System.Windows.Forms.Label()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.grpBoxMain.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        CType(Me.NUDFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(12, 12)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(512, 337)
        Me.GrpBoxPoperties.TabIndex = 14
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Label Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Location = New System.Drawing.Point(12, 19)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(491, 285)
        Me.TbProperty.TabIndex = 22
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.grpBoxMain)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(483, 259)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'grpBoxMain
        '
        Me.grpBoxMain.Controls.Add(Me.txtCaption)
        Me.grpBoxMain.Controls.Add(Me.lblCaption)
        Me.grpBoxMain.Controls.Add(Me.GrpMaxMinValues)
        Me.grpBoxMain.Location = New System.Drawing.Point(6, 6)
        Me.grpBoxMain.Name = "grpBoxMain"
        Me.grpBoxMain.Size = New System.Drawing.Size(471, 247)
        Me.grpBoxMain.TabIndex = 0
        Me.grpBoxMain.TabStop = False
        '
        'txtCaption
        '
        Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaption.Location = New System.Drawing.Point(55, 34)
        Me.txtCaption.Multiline = True
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(404, 92)
        Me.txtCaption.TabIndex = 27
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(8, 34)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(40, 13)
        Me.lblCaption.TabIndex = 28
        Me.lblCaption.Text = "Text :"
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.CKBoxUnderLine)
        Me.GrpMaxMinValues.Controls.Add(Me.Ckboxbtnitalic)
        Me.GrpMaxMinValues.Controls.Add(Me.CKboxBold)
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.Label1)
        Me.GrpMaxMinValues.Controls.Add(Me.NUDFontSize)
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxFont)
        Me.GrpMaxMinValues.Controls.Add(Me.lblFont)
        Me.GrpMaxMinValues.Controls.Add(Me.lblFontSize)
        Me.GrpMaxMinValues.Controls.Add(Me.forecolorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblForecolor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCtrlBackColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(11, 132)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(448, 109)
        Me.GrpMaxMinValues.TabIndex = 20
        Me.GrpMaxMinValues.TabStop = False
        Me.GrpMaxMinValues.Text = "Color Settings"
        '
        'CKBoxUnderLine
        '
        Me.CKBoxUnderLine.AutoSize = True
        Me.CKBoxUnderLine.Location = New System.Drawing.Point(361, 82)
        Me.CKBoxUnderLine.Name = "CKBoxUnderLine"
        Me.CKBoxUnderLine.Size = New System.Drawing.Size(79, 17)
        Me.CKBoxUnderLine.TabIndex = 49
        Me.CKBoxUnderLine.TabStop = True
        Me.CKBoxUnderLine.Text = "Underline"
        Me.CKBoxUnderLine.UseVisualStyleBackColor = True
        '
        'Ckboxbtnitalic
        '
        Me.Ckboxbtnitalic.AutoSize = True
        Me.Ckboxbtnitalic.Location = New System.Drawing.Point(308, 82)
        Me.Ckboxbtnitalic.Name = "Ckboxbtnitalic"
        Me.Ckboxbtnitalic.Size = New System.Drawing.Size(53, 17)
        Me.Ckboxbtnitalic.TabIndex = 48
        Me.Ckboxbtnitalic.TabStop = True
        Me.Ckboxbtnitalic.Text = "Italic"
        Me.Ckboxbtnitalic.UseVisualStyleBackColor = True
        '
        'CKboxBold
        '
        Me.CKboxBold.AutoSize = True
        Me.CKboxBold.Location = New System.Drawing.Point(257, 82)
        Me.CKboxBold.Name = "CKboxBold"
        Me.CKboxBold.Size = New System.Drawing.Size(50, 17)
        Me.CKboxBold.TabIndex = 47
        Me.CKboxBold.TabStop = True
        Me.CKboxBold.Text = "Bold"
        Me.CKboxBold.UseVisualStyleBackColor = True
        '
        'CBoxStyle
        '
        Me.CBoxStyle.FormattingEnabled = True
        Me.CBoxStyle.Items.AddRange(New Object() {"None", "FixedSingle", "Fixed3D"})
        Me.CBoxStyle.Location = New System.Drawing.Point(118, 78)
        Me.CBoxStyle.Name = "CBoxStyle"
        Me.CBoxStyle.Size = New System.Drawing.Size(121, 21)
        Me.CBoxStyle.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Border Style"
        '
        'NUDFontSize
        '
        Me.NUDFontSize.Location = New System.Drawing.Point(311, 51)
        Me.NUDFontSize.Name = "NUDFontSize"
        Me.NUDFontSize.Size = New System.Drawing.Size(73, 21)
        Me.NUDFontSize.TabIndex = 32
        '
        'CBoxFont
        '
        Me.CBoxFont.FormattingEnabled = True
        Me.CBoxFont.Location = New System.Drawing.Point(308, 23)
        Me.CBoxFont.Name = "CBoxFont"
        Me.CBoxFont.Size = New System.Drawing.Size(121, 21)
        Me.CBoxFont.TabIndex = 31
        '
        'lblFont
        '
        Me.lblFont.AutoSize = True
        Me.lblFont.Location = New System.Drawing.Point(254, 25)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(31, 13)
        Me.lblFont.TabIndex = 30
        Me.lblFont.Text = "Font"
        '
        'lblFontSize
        '
        Me.lblFontSize.AutoSize = True
        Me.lblFontSize.Location = New System.Drawing.Point(254, 55)
        Me.lblFontSize.Name = "lblFontSize"
        Me.lblFontSize.Size = New System.Drawing.Size(59, 13)
        Me.lblFontSize.TabIndex = 28
        Me.lblFontSize.Text = "Font Size"
        '
        'forecolorlbl
        '
        Me.forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.forecolorlbl.Location = New System.Drawing.Point(119, 50)
        Me.forecolorlbl.Name = "forecolorlbl"
        Me.forecolorlbl.Size = New System.Drawing.Size(75, 16)
        Me.forecolorlbl.TabIndex = 27
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(4, 50)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(67, 13)
        Me.lblForecolor.TabIndex = 26
        Me.lblForecolor.Text = "Fore Color"
        '
        'lblCtrlBackColor
        '
        Me.lblCtrlBackColor.BackColor = System.Drawing.SystemColors.Control
        Me.lblCtrlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtrlBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCtrlBackColor.Location = New System.Drawing.Point(120, 22)
        Me.lblCtrlBackColor.Name = "lblCtrlBackColor"
        Me.lblCtrlBackColor.Size = New System.Drawing.Size(75, 16)
        Me.lblCtrlBackColor.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(4, 22)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(110, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Background Color"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(416, 310)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(319, 310)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'LabelPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 361)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(540, 400)
        Me.Name = "LabelPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.grpBoxMain.ResumeLayout(False)
        Me.grpBoxMain.PerformLayout()
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        CType(Me.NUDFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents grpBoxMain As System.Windows.Forms.GroupBox
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents forecolorlbl As System.Windows.Forms.Label
    Friend WithEvents lblForecolor As System.Windows.Forms.Label
    Friend WithEvents lblCtrlBackColor As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents NUDFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents CBoxFont As System.Windows.Forms.ComboBox
    Friend WithEvents CBoxStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CKBoxUnderLine As System.Windows.Forms.RadioButton
    Friend WithEvents Ckboxbtnitalic As System.Windows.Forms.RadioButton
    Friend WithEvents CKboxBold As System.Windows.Forms.RadioButton
    Friend WithEvents txtCaption As System.Windows.Forms.TextBox
    Friend WithEvents lblCaption As System.Windows.Forms.Label
End Class
