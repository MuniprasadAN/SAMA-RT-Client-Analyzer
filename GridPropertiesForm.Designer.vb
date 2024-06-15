''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GridPropertiesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not C_font Is Nothing Then C_font.Dispose()


                If Not AL_Font Is Nothing Then AL_Font.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GridPropertiesForm))
        Me.grpBoxProperties = New System.Windows.Forms.GroupBox()
        Me.txtComponentName = New System.Windows.Forms.TextBox()
        Me.lblComponentName = New System.Windows.Forms.Label()
        Me.GboxSelectionrow = New System.Windows.Forms.GroupBox()
        Me.ColorSL_FC = New System.Windows.Forms.Label()
        Me.ColorSL_BClbl = New System.Windows.Forms.Label()
        Me.lblSL_FC = New System.Windows.Forms.Label()
        Me.lblSL_BC = New System.Windows.Forms.Label()
        Me.GboxAlternaterow = New System.Windows.Forms.GroupBox()
        Me.txtAL_Font = New System.Windows.Forms.TextBox()
        Me.ColorAL_FC = New System.Windows.Forms.Label()
        Me.ColorAL_BClbl = New System.Windows.Forms.Label()
        Me.btnALFont = New System.Windows.Forms.Button()
        Me.lblAL_FC = New System.Windows.Forms.Label()
        Me.lblAL_BC = New System.Windows.Forms.Label()
        Me.txtFont = New System.Windows.Forms.TextBox()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.Color_forecolorlbl = New System.Windows.Forms.Label()
        Me.lblForecolor = New System.Windows.Forms.Label()
        Me.color_BackColorlbl = New System.Windows.Forms.Label()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox()
        Me.lblActionChannel = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TbProperty = New System.Windows.Forms.TabControl()
        Me.TpComponentName = New System.Windows.Forms.TabPage()
        Me.Thresold = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGViewTagSetPnt = New System.Windows.Forms.DataGridView()
        Me.TagName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.setpoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TbThValue = New System.Windows.Forms.TabPage()
        Me.grpBoxThValue = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GVTHValue = New System.Windows.Forms.DataGridView()
        Me.Condition = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ForegroundColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FontSett = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpBoxProperties.SuspendLayout()
        Me.GboxSelectionrow.SuspendLayout()
        Me.GboxAlternaterow.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.Thresold.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGViewTagSetPnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbThValue.SuspendLayout()
        Me.grpBoxThValue.SuspendLayout()
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBoxProperties
        '
        Me.grpBoxProperties.Controls.Add(Me.txtComponentName)
        Me.grpBoxProperties.Controls.Add(Me.lblComponentName)
        Me.grpBoxProperties.Controls.Add(Me.GboxSelectionrow)
        Me.grpBoxProperties.Controls.Add(Me.GboxAlternaterow)
        Me.grpBoxProperties.Controls.Add(Me.txtFont)
        Me.grpBoxProperties.Controls.Add(Me.btnFont)
        Me.grpBoxProperties.Controls.Add(Me.lblFont)
        Me.grpBoxProperties.Controls.Add(Me.Color_forecolorlbl)
        Me.grpBoxProperties.Controls.Add(Me.lblForecolor)
        Me.grpBoxProperties.Controls.Add(Me.color_BackColorlbl)
        Me.grpBoxProperties.Controls.Add(Me.lblBKcolor)
        Me.grpBoxProperties.Controls.Add(Me.cBoxActionChannel)
        Me.grpBoxProperties.Controls.Add(Me.lblActionChannel)
        Me.grpBoxProperties.Location = New System.Drawing.Point(6, 6)
        Me.grpBoxProperties.Name = "grpBoxProperties"
        Me.grpBoxProperties.Size = New System.Drawing.Size(528, 258)
        Me.grpBoxProperties.TabIndex = 0
        Me.grpBoxProperties.TabStop = False
        Me.grpBoxProperties.Text = "Table Properties"
        '
        'txtComponentName
        '
        Me.txtComponentName.Location = New System.Drawing.Point(141, 14)
        Me.txtComponentName.Name = "txtComponentName"
        Me.txtComponentName.ReadOnly = True
        Me.txtComponentName.Size = New System.Drawing.Size(201, 21)
        Me.txtComponentName.TabIndex = 94
        '
        'lblComponentName
        '
        Me.lblComponentName.AutoSize = True
        Me.lblComponentName.Location = New System.Drawing.Point(16, 17)
        Me.lblComponentName.Name = "lblComponentName"
        Me.lblComponentName.Size = New System.Drawing.Size(119, 13)
        Me.lblComponentName.TabIndex = 93
        Me.lblComponentName.Text = "Component Name :"
        '
        'GboxSelectionrow
        '
        Me.GboxSelectionrow.Controls.Add(Me.ColorSL_FC)
        Me.GboxSelectionrow.Controls.Add(Me.ColorSL_BClbl)
        Me.GboxSelectionrow.Controls.Add(Me.lblSL_FC)
        Me.GboxSelectionrow.Controls.Add(Me.lblSL_BC)
        Me.GboxSelectionrow.Location = New System.Drawing.Point(14, 191)
        Me.GboxSelectionrow.Name = "GboxSelectionrow"
        Me.GboxSelectionrow.Size = New System.Drawing.Size(477, 61)
        Me.GboxSelectionrow.TabIndex = 61
        Me.GboxSelectionrow.TabStop = False
        Me.GboxSelectionrow.Text = "Selection Row Color settings"
        '
        'ColorSL_FC
        '
        Me.ColorSL_FC.BackColor = System.Drawing.Color.Black
        Me.ColorSL_FC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ColorSL_FC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorSL_FC.Location = New System.Drawing.Point(237, 23)
        Me.ColorSL_FC.Name = "ColorSL_FC"
        Me.ColorSL_FC.Size = New System.Drawing.Size(58, 20)
        Me.ColorSL_FC.TabIndex = 68
        '
        'ColorSL_BClbl
        '
        Me.ColorSL_BClbl.BackColor = System.Drawing.SystemColors.Control
        Me.ColorSL_BClbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ColorSL_BClbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorSL_BClbl.Location = New System.Drawing.Point(92, 24)
        Me.ColorSL_BClbl.Name = "ColorSL_BClbl"
        Me.ColorSL_BClbl.Size = New System.Drawing.Size(58, 19)
        Me.ColorSL_BClbl.TabIndex = 69
        '
        'lblSL_FC
        '
        Me.lblSL_FC.AutoSize = True
        Me.lblSL_FC.Location = New System.Drawing.Point(155, 27)
        Me.lblSL_FC.Name = "lblSL_FC"
        Me.lblSL_FC.Size = New System.Drawing.Size(76, 13)
        Me.lblSL_FC.TabIndex = 65
        Me.lblSL_FC.Text = "Fore Color :"
        '
        'lblSL_BC
        '
        Me.lblSL_BC.AutoSize = True
        Me.lblSL_BC.Location = New System.Drawing.Point(7, 27)
        Me.lblSL_BC.Name = "lblSL_BC"
        Me.lblSL_BC.Size = New System.Drawing.Size(79, 13)
        Me.lblSL_BC.TabIndex = 66
        Me.lblSL_BC.Text = "Back Color :"
        '
        'GboxAlternaterow
        '
        Me.GboxAlternaterow.Controls.Add(Me.txtAL_Font)
        Me.GboxAlternaterow.Controls.Add(Me.ColorAL_FC)
        Me.GboxAlternaterow.Controls.Add(Me.ColorAL_BClbl)
        Me.GboxAlternaterow.Controls.Add(Me.btnALFont)
        Me.GboxAlternaterow.Controls.Add(Me.lblAL_FC)
        Me.GboxAlternaterow.Controls.Add(Me.lblAL_BC)
        Me.GboxAlternaterow.Location = New System.Drawing.Point(14, 124)
        Me.GboxAlternaterow.Name = "GboxAlternaterow"
        Me.GboxAlternaterow.Size = New System.Drawing.Size(477, 61)
        Me.GboxAlternaterow.TabIndex = 60
        Me.GboxAlternaterow.TabStop = False
        Me.GboxAlternaterow.Text = "Alternate Row Color Settings"
        '
        'txtAL_Font
        '
        Me.txtAL_Font.Location = New System.Drawing.Point(301, 23)
        Me.txtAL_Font.Name = "txtAL_Font"
        Me.txtAL_Font.Size = New System.Drawing.Size(115, 21)
        Me.txtAL_Font.TabIndex = 64
        '
        'ColorAL_FC
        '
        Me.ColorAL_FC.BackColor = System.Drawing.Color.Black
        Me.ColorAL_FC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ColorAL_FC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorAL_FC.Location = New System.Drawing.Point(237, 23)
        Me.ColorAL_FC.Name = "ColorAL_FC"
        Me.ColorAL_FC.Size = New System.Drawing.Size(58, 20)
        Me.ColorAL_FC.TabIndex = 63
        '
        'ColorAL_BClbl
        '
        Me.ColorAL_BClbl.BackColor = System.Drawing.SystemColors.Control
        Me.ColorAL_BClbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ColorAL_BClbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorAL_BClbl.Location = New System.Drawing.Point(92, 24)
        Me.ColorAL_BClbl.Name = "ColorAL_BClbl"
        Me.ColorAL_BClbl.Size = New System.Drawing.Size(58, 19)
        Me.ColorAL_BClbl.TabIndex = 63
        '
        'btnALFont
        '
        Me.btnALFont.Location = New System.Drawing.Point(422, 23)
        Me.btnALFont.Name = "btnALFont"
        Me.btnALFont.Size = New System.Drawing.Size(40, 21)
        Me.btnALFont.TabIndex = 63
        Me.btnALFont.Text = "Font..."
        Me.btnALFont.UseVisualStyleBackColor = True
        '
        'lblAL_FC
        '
        Me.lblAL_FC.AutoSize = True
        Me.lblAL_FC.Location = New System.Drawing.Point(155, 27)
        Me.lblAL_FC.Name = "lblAL_FC"
        Me.lblAL_FC.Size = New System.Drawing.Size(76, 13)
        Me.lblAL_FC.TabIndex = 62
        Me.lblAL_FC.Text = "Fore Color :"
        '
        'lblAL_BC
        '
        Me.lblAL_BC.AutoSize = True
        Me.lblAL_BC.Location = New System.Drawing.Point(7, 27)
        Me.lblAL_BC.Name = "lblAL_BC"
        Me.lblAL_BC.Size = New System.Drawing.Size(79, 13)
        Me.lblAL_BC.TabIndex = 62
        Me.lblAL_BC.Text = "Back Color :"
        '
        'txtFont
        '
        Me.txtFont.Location = New System.Drawing.Point(294, 78)
        Me.txtFont.Name = "txtFont"
        Me.txtFont.Size = New System.Drawing.Size(163, 21)
        Me.txtFont.TabIndex = 59
        '
        'btnFont
        '
        Me.btnFont.Location = New System.Drawing.Point(460, 78)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(49, 21)
        Me.btnFont.TabIndex = 58
        Me.btnFont.Text = "Font..."
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'lblFont
        '
        Me.lblFont.AutoSize = True
        Me.lblFont.Location = New System.Drawing.Point(248, 82)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(40, 13)
        Me.lblFont.TabIndex = 57
        Me.lblFont.Text = "Font :"
        '
        'Color_forecolorlbl
        '
        Me.Color_forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.Color_forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Color_forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Color_forecolorlbl.Location = New System.Drawing.Point(139, 103)
        Me.Color_forecolorlbl.Name = "Color_forecolorlbl"
        Me.Color_forecolorlbl.Size = New System.Drawing.Size(77, 20)
        Me.Color_forecolorlbl.TabIndex = 56
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(16, 104)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(76, 13)
        Me.lblForecolor.TabIndex = 55
        Me.lblForecolor.Text = "Fore Color :"
        '
        'color_BackColorlbl
        '
        Me.color_BackColorlbl.BackColor = System.Drawing.SystemColors.Control
        Me.color_BackColorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.color_BackColorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.color_BackColorlbl.Location = New System.Drawing.Point(141, 75)
        Me.color_BackColorlbl.Name = "color_BackColorlbl"
        Me.color_BackColorlbl.Size = New System.Drawing.Size(75, 20)
        Me.color_BackColorlbl.TabIndex = 54
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(16, 75)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(79, 13)
        Me.lblBKcolor.TabIndex = 53
        Me.lblBKcolor.Text = "Back Color :"
        '
        'cBoxActionChannel
        '
        Me.cBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxActionChannel.DropDownHeight = 80
        Me.cBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxActionChannel.FormattingEnabled = True
        Me.cBoxActionChannel.IntegralHeight = False
        Me.cBoxActionChannel.ItemHeight = 13
        Me.cBoxActionChannel.Location = New System.Drawing.Point(141, 41)
        Me.cBoxActionChannel.Name = "cBoxActionChannel"
        Me.cBoxActionChannel.Size = New System.Drawing.Size(284, 21)
        Me.cBoxActionChannel.TabIndex = 52
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(16, 46)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblActionChannel.TabIndex = 51
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(439, 314)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(59, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(507, 314)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Controls.Add(Me.Thresold)
        Me.TbProperty.Controls.Add(Me.TbThValue)
        Me.TbProperty.Location = New System.Drawing.Point(12, 12)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(554, 296)
        Me.TbProperty.TabIndex = 23
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.grpBoxProperties)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(546, 270)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'Thresold
        '
        Me.Thresold.Controls.Add(Me.GroupBox1)
        Me.Thresold.Location = New System.Drawing.Point(4, 22)
        Me.Thresold.Name = "Thresold"
        Me.Thresold.Size = New System.Drawing.Size(546, 270)
        Me.Thresold.TabIndex = 4
        Me.Thresold.Text = "Thresold Settings"
        Me.Thresold.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGViewTagSetPnt)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 234)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thresold Color Settings"
        '
        'DGViewTagSetPnt
        '
        Me.DGViewTagSetPnt.AllowUserToAddRows = False
        Me.DGViewTagSetPnt.AllowUserToDeleteRows = False
        Me.DGViewTagSetPnt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGViewTagSetPnt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGViewTagSetPnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGViewTagSetPnt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TagName, Me.setpoint})
        Me.DGViewTagSetPnt.Location = New System.Drawing.Point(6, 18)
        Me.DGViewTagSetPnt.Name = "DGViewTagSetPnt"
        Me.DGViewTagSetPnt.RowHeadersVisible = False
        Me.DGViewTagSetPnt.Size = New System.Drawing.Size(464, 191)
        Me.DGViewTagSetPnt.TabIndex = 1
        '
        'TagName
        '
        Me.TagName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TagName.HeaderText = "Tag Name"
        Me.TagName.Name = "TagName"
        '
        'setpoint
        '
        Me.setpoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.setpoint.HeaderText = "SetPoint Condition"
        Me.setpoint.Name = "setpoint"
        '
        'TbThValue
        '
        Me.TbThValue.Controls.Add(Me.grpBoxThValue)
        Me.TbThValue.Location = New System.Drawing.Point(4, 22)
        Me.TbThValue.Name = "TbThValue"
        Me.TbThValue.Padding = New System.Windows.Forms.Padding(3)
        Me.TbThValue.Size = New System.Drawing.Size(546, 270)
        Me.TbThValue.TabIndex = 3
        Me.TbThValue.Text = "Color Settings"
        Me.TbThValue.UseVisualStyleBackColor = True
        '
        'grpBoxThValue
        '
        Me.grpBoxThValue.Controls.Add(Me.btnDelete)
        Me.grpBoxThValue.Controls.Add(Me.btnAdd)
        Me.grpBoxThValue.Controls.Add(Me.GVTHValue)
        Me.grpBoxThValue.Location = New System.Drawing.Point(6, 13)
        Me.grpBoxThValue.Name = "grpBoxThValue"
        Me.grpBoxThValue.Size = New System.Drawing.Size(520, 251)
        Me.grpBoxThValue.TabIndex = 0
        Me.grpBoxThValue.TabStop = False
        Me.grpBoxThValue.Text = "Color Settings"
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
        Me.GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Condition, Me.Value, Me.ForegroundColor, Me.BackgroundColor, Me.FontSett})
        Me.GVTHValue.Location = New System.Drawing.Point(9, 22)
        Me.GVTHValue.Name = "GVTHValue"
        Me.GVTHValue.RowHeadersVisible = False
        Me.GVTHValue.Size = New System.Drawing.Size(501, 191)
        Me.GVTHValue.TabIndex = 1
        '
        'Condition
        '
        Me.Condition.HeaderText = "Fields"
        Me.Condition.Name = "Condition"
        Me.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Width = 150
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
        'FontSett
        '
        Me.FontSett.HeaderText = "Font"
        Me.FontSett.Name = "FontSett"
        '
        'GridPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 341)
        Me.Controls.Add(Me.TbProperty)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GridPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.grpBoxProperties.ResumeLayout(False)
        Me.grpBoxProperties.PerformLayout()
        Me.GboxSelectionrow.ResumeLayout(False)
        Me.GboxSelectionrow.PerformLayout()
        Me.GboxAlternaterow.ResumeLayout(False)
        Me.GboxAlternaterow.PerformLayout()
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.Thresold.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGViewTagSetPnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbThValue.ResumeLayout(False)
        Me.grpBoxThValue.ResumeLayout(False)
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBoxProperties As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents Color_forecolorlbl As System.Windows.Forms.Label
    Friend WithEvents lblForecolor As System.Windows.Forms.Label
    Friend WithEvents color_BackColorlbl As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents txtFont As System.Windows.Forms.TextBox
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents GboxSelectionrow As System.Windows.Forms.GroupBox
    Friend WithEvents GboxAlternaterow As System.Windows.Forms.GroupBox
    Friend WithEvents ColorSL_FC As System.Windows.Forms.Label
    Friend WithEvents ColorSL_BClbl As System.Windows.Forms.Label
    Friend WithEvents lblSL_FC As System.Windows.Forms.Label
    Friend WithEvents lblSL_BC As System.Windows.Forms.Label
    Friend WithEvents txtAL_Font As System.Windows.Forms.TextBox
    Friend WithEvents ColorAL_FC As System.Windows.Forms.Label
    Friend WithEvents ColorAL_BClbl As System.Windows.Forms.Label
    Friend WithEvents btnALFont As System.Windows.Forms.Button
    Friend WithEvents lblAL_FC As System.Windows.Forms.Label
    Friend WithEvents lblAL_BC As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents TbThValue As System.Windows.Forms.TabPage
    Friend WithEvents grpBoxThValue As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GVTHValue As System.Windows.Forms.DataGridView
    Friend WithEvents Condition As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ForegroundColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackgroundColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FontSett As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtComponentName As System.Windows.Forms.TextBox
    Friend WithEvents lblComponentName As System.Windows.Forms.Label
    Friend WithEvents Thresold As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGViewTagSetPnt As System.Windows.Forms.DataGridView
    Friend WithEvents TagName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents setpoint As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
