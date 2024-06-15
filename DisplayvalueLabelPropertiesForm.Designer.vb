''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayvalueLabelPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DisplayvalueLabelPropertiesForm))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox()
        Me.TbProperty = New System.Windows.Forms.TabControl()
        Me.TpComponentName = New System.Windows.Forms.TabPage()
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox()
        Me.CBoxStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.lblUnits = New System.Windows.Forms.Label()
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox()
        Me.lblActionChannel = New System.Windows.Forms.Label()
        Me.CKboxBold = New System.Windows.Forms.CheckBox()
        Me.forecolorlbl = New System.Windows.Forms.Label()
        Me.lblForecolor = New System.Windows.Forms.Label()
        Me.NUDFontSize = New System.Windows.Forms.NumericUpDown()
        Me.CBoxFont = New System.Windows.Forms.ComboBox()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.lblCtrlBackColor = New System.Windows.Forms.Label()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.TbThValue = New System.Windows.Forms.TabPage()
        Me.grpBoxThValue = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GVTHValue = New System.Windows.Forms.DataGridView()
        Me.Condition = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ForegroundColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Blink = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Thres_ForeColorlbl = New System.Windows.Forms.Label()
        Me.lblThres_ForeColor = New System.Windows.Forms.Label()
        Me.rdobtnBlinkwith = New System.Windows.Forms.RadioButton()
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        CType(Me.NUDFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbThValue.SuspendLayout()
        Me.grpBoxThValue.SuspendLayout()
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(5, 4)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(564, 357)
        Me.GrpBoxPoperties.TabIndex = 15
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Label Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Controls.Add(Me.TbThValue)
        Me.TbProperty.Location = New System.Drawing.Point(12, 19)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(540, 295)
        Me.TbProperty.TabIndex = 22
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.GrpMaxMinValues)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(532, 269)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.Label1)
        Me.GrpMaxMinValues.Controls.Add(Me.txtUnits)
        Me.GrpMaxMinValues.Controls.Add(Me.lblUnits)
        Me.GrpMaxMinValues.Controls.Add(Me.cBoxActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.CKboxBold)
        Me.GrpMaxMinValues.Controls.Add(Me.forecolorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblForecolor)
        Me.GrpMaxMinValues.Controls.Add(Me.NUDFontSize)
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxFont)
        Me.GrpMaxMinValues.Controls.Add(Me.lblFont)
        Me.GrpMaxMinValues.Controls.Add(Me.lblFontSize)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCtrlBackColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(6, 2)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(523, 258)
        Me.GrpMaxMinValues.TabIndex = 21
        Me.GrpMaxMinValues.TabStop = False
        '
        'CBoxStyle
        '
        Me.CBoxStyle.FormattingEnabled = True
        Me.CBoxStyle.Items.AddRange(New Object() {"None", "FixedSingle", "Fixed3D"})
        Me.CBoxStyle.Location = New System.Drawing.Point(124, 188)
        Me.CBoxStyle.Name = "CBoxStyle"
        Me.CBoxStyle.Size = New System.Drawing.Size(121, 21)
        Me.CBoxStyle.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Border Style :"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(124, 60)
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(100, 21)
        Me.txtUnits.TabIndex = 50
        '
        'lblUnits
        '
        Me.lblUnits.AutoSize = True
        Me.lblUnits.Location = New System.Drawing.Point(9, 63)
        Me.lblUnits.Name = "lblUnits"
        Me.lblUnits.Size = New System.Drawing.Size(44, 13)
        Me.lblUnits.TabIndex = 49
        Me.lblUnits.Text = "Units :"
        '
        'cBoxActionChannel
        '
        Me.cBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxActionChannel.DropDownHeight = 80
        Me.cBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxActionChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cBoxActionChannel.FormattingEnabled = True
        Me.cBoxActionChannel.IntegralHeight = False
        Me.cBoxActionChannel.ItemHeight = 13
        Me.cBoxActionChannel.Location = New System.Drawing.Point(124, 29)
        Me.cBoxActionChannel.Name = "cBoxActionChannel"
        Me.cBoxActionChannel.Size = New System.Drawing.Size(298, 21)
        Me.cBoxActionChannel.TabIndex = 48
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(9, 32)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblActionChannel.TabIndex = 44
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'CKboxBold
        '
        Me.CKboxBold.AutoSize = True
        Me.CKboxBold.Location = New System.Drawing.Point(242, 225)
        Me.CKboxBold.Name = "CKboxBold"
        Me.CKboxBold.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CKboxBold.Size = New System.Drawing.Size(72, 17)
        Me.CKboxBold.TabIndex = 41
        Me.CKboxBold.Text = "Bold :   "
        Me.CKboxBold.UseVisualStyleBackColor = True
        '
        'forecolorlbl
        '
        Me.forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.forecolorlbl.Location = New System.Drawing.Point(124, 126)
        Me.forecolorlbl.Name = "forecolorlbl"
        Me.forecolorlbl.Size = New System.Drawing.Size(77, 20)
        Me.forecolorlbl.TabIndex = 34
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(9, 127)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(76, 13)
        Me.lblForecolor.TabIndex = 33
        Me.lblForecolor.Text = "Fore Color :"
        '
        'NUDFontSize
        '
        Me.NUDFontSize.Location = New System.Drawing.Point(124, 223)
        Me.NUDFontSize.Name = "NUDFontSize"
        Me.NUDFontSize.Size = New System.Drawing.Size(58, 21)
        Me.NUDFontSize.TabIndex = 32
        '
        'CBoxFont
        '
        Me.CBoxFont.FormattingEnabled = True
        Me.CBoxFont.Location = New System.Drawing.Point(124, 156)
        Me.CBoxFont.Name = "CBoxFont"
        Me.CBoxFont.Size = New System.Drawing.Size(121, 21)
        Me.CBoxFont.TabIndex = 31
        '
        'lblFont
        '
        Me.lblFont.AutoSize = True
        Me.lblFont.Location = New System.Drawing.Point(9, 164)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(40, 13)
        Me.lblFont.TabIndex = 30
        Me.lblFont.Text = "Font :"
        '
        'lblFontSize
        '
        Me.lblFontSize.AutoSize = True
        Me.lblFontSize.Location = New System.Drawing.Point(9, 227)
        Me.lblFontSize.Name = "lblFontSize"
        Me.lblFontSize.Size = New System.Drawing.Size(68, 13)
        Me.lblFontSize.TabIndex = 28
        Me.lblFontSize.Text = "Font Size :"
        '
        'lblCtrlBackColor
        '
        Me.lblCtrlBackColor.BackColor = System.Drawing.SystemColors.Control
        Me.lblCtrlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtrlBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCtrlBackColor.Location = New System.Drawing.Point(124, 94)
        Me.lblCtrlBackColor.Name = "lblCtrlBackColor"
        Me.lblCtrlBackColor.Size = New System.Drawing.Size(75, 20)
        Me.lblCtrlBackColor.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(9, 95)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(79, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Back Color :"
        '
        'TbThValue
        '
        Me.TbThValue.Controls.Add(Me.grpBoxThValue)
        Me.TbThValue.Location = New System.Drawing.Point(4, 22)
        Me.TbThValue.Name = "TbThValue"
        Me.TbThValue.Padding = New System.Windows.Forms.Padding(3)
        Me.TbThValue.Size = New System.Drawing.Size(532, 269)
        Me.TbThValue.TabIndex = 3
        Me.TbThValue.Text = "Threshold Settings"
        Me.TbThValue.UseVisualStyleBackColor = True
        '
        'grpBoxThValue
        '
        Me.grpBoxThValue.Controls.Add(Me.btnDelete)
        Me.grpBoxThValue.Controls.Add(Me.btnAdd)
        Me.grpBoxThValue.Controls.Add(Me.GVTHValue)
        Me.grpBoxThValue.Location = New System.Drawing.Point(6, 12)
        Me.grpBoxThValue.Name = "grpBoxThValue"
        Me.grpBoxThValue.Size = New System.Drawing.Size(520, 251)
        Me.grpBoxThValue.TabIndex = 0
        Me.grpBoxThValue.TabStop = False
        Me.grpBoxThValue.Text = "Threshold settings"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(93, 219)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 21)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(16, 219)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 21)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GVTHValue
        '
        Me.GVTHValue.AllowUserToAddRows = False
        Me.GVTHValue.AllowUserToDeleteRows = False
        Me.GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Condition, Me.Value, Me.ForegroundColor, Me.BackgroundColor, Me.Desc, Me.Blink})
        Me.GVTHValue.Location = New System.Drawing.Point(9, 22)
        Me.GVTHValue.Name = "GVTHValue"
        Me.GVTHValue.RowHeadersVisible = False
        Me.GVTHValue.Size = New System.Drawing.Size(501, 191)
        Me.GVTHValue.TabIndex = 1
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.Name = "Condition"
        Me.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        '
        'ForegroundColor
        '
        Me.ForegroundColor.HeaderText = "Foreground  Color"
        Me.ForegroundColor.Name = "ForegroundColor"
        '
        'BackgroundColor
        '
        Me.BackgroundColor.HeaderText = "Background Color"
        Me.BackgroundColor.Name = "BackgroundColor"
        '
        'Desc
        '
        Me.Desc.HeaderText = "Desc"
        Me.Desc.Name = "Desc"
        '
        'Blink
        '
        Me.Blink.HeaderText = "Blink"
        Me.Blink.Name = "Blink"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(473, 320)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(392, 320)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Thres_ForeColorlbl
        '
        Me.Thres_ForeColorlbl.BackColor = System.Drawing.Color.Black
        Me.Thres_ForeColorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thres_ForeColorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Thres_ForeColorlbl.Location = New System.Drawing.Point(231, 56)
        Me.Thres_ForeColorlbl.Name = "Thres_ForeColorlbl"
        Me.Thres_ForeColorlbl.Size = New System.Drawing.Size(77, 16)
        Me.Thres_ForeColorlbl.TabIndex = 45
        '
        'lblThres_ForeColor
        '
        Me.lblThres_ForeColor.AutoSize = True
        Me.lblThres_ForeColor.Location = New System.Drawing.Point(126, 57)
        Me.lblThres_ForeColor.Name = "lblThres_ForeColor"
        Me.lblThres_ForeColor.Size = New System.Drawing.Size(97, 13)
        Me.lblThres_ForeColor.TabIndex = 44
        Me.lblThres_ForeColor.Text = "ThreholdFore Color"
        '
        'rdobtnBlinkwith
        '
        Me.rdobtnBlinkwith.AutoSize = True
        Me.rdobtnBlinkwith.Location = New System.Drawing.Point(358, 56)
        Me.rdobtnBlinkwith.Name = "rdobtnBlinkwith"
        Me.rdobtnBlinkwith.Size = New System.Drawing.Size(104, 17)
        Me.rdobtnBlinkwith.TabIndex = 54
        Me.rdobtnBlinkwith.TabStop = True
        Me.rdobtnBlinkwith.Text = "Blink with Sound"
        Me.rdobtnBlinkwith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdobtnBlinkwith.UseVisualStyleBackColor = True
        '
        'DisplayvalueLabelPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 356)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.Controls.Add(Me.lblThres_ForeColor)
        Me.Controls.Add(Me.Thres_ForeColorlbl)
        Me.Controls.Add(Me.rdobtnBlinkwith)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(586, 395)
        Me.Name = "DisplayvalueLabelPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        CType(Me.NUDFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbThValue.ResumeLayout(False)
        Me.grpBoxThValue.ResumeLayout(False)
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Thres_ForeColorlbl As System.Windows.Forms.Label
    Friend WithEvents lblThres_ForeColor As System.Windows.Forms.Label
    Friend WithEvents rdobtnBlinkwith As System.Windows.Forms.RadioButton
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents CKboxBold As System.Windows.Forms.CheckBox
    Friend WithEvents forecolorlbl As System.Windows.Forms.Label
    Friend WithEvents lblForecolor As System.Windows.Forms.Label
    Friend WithEvents NUDFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents CBoxFont As System.Windows.Forms.ComboBox
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents lblCtrlBackColor As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents TbThValue As System.Windows.Forms.TabPage
    Friend WithEvents grpBoxThValue As System.Windows.Forms.GroupBox
    Friend WithEvents GVTHValue As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents lblUnits As System.Windows.Forms.Label
    Friend WithEvents CBoxStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Condition As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ForegroundColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackgroundColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Blink As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
