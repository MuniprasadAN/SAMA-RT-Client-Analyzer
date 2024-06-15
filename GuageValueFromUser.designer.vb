''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuageValueFromUser
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuageValueFromUser))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox
        Me.TbProperty = New System.Windows.Forms.TabControl
        Me.TpComponentName = New System.Windows.Forms.TabPage
        Me.grpBoxMain = New System.Windows.Forms.GroupBox
        Me.CBoxActionChannel = New System.Windows.Forms.ComboBox
        Me.lblActionChannel = New System.Windows.Forms.Label
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox
        Me.lblCapX = New System.Windows.Forms.Label
        Me.txtCapX = New System.Windows.Forms.TextBox
        Me.lblCapY = New System.Windows.Forms.Label
        Me.txtCapY = New System.Windows.Forms.TextBox
        Me.txtCaption = New System.Windows.Forms.TextBox
        Me.lblCtrlBackColor = New System.Windows.Forms.Label
        Me.lblBKcolor = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.lblMinValue = New System.Windows.Forms.Label
        Me.txtMinValue = New System.Windows.Forms.TextBox
        Me.lblMaxValue = New System.Windows.Forms.Label
        Me.txtMaxValue = New System.Windows.Forms.TextBox
        Me.TpNeedleProperties = New System.Windows.Forms.TabPage
        Me.GrpBoxArc = New System.Windows.Forms.GroupBox
        Me.lbloutarccolor = New System.Windows.Forms.Label
        Me.lblOutArc = New System.Windows.Forms.Label
        Me.CkBoxOuterArc = New System.Windows.Forms.CheckBox
        Me.txtRangeStartDegree = New System.Windows.Forms.TextBox
        Me.txtRangeDegree = New System.Windows.Forms.TextBox
        Me.lblstartDegrees = New System.Windows.Forms.Label
        Me.lblRangeDegree = New System.Windows.Forms.Label
        Me.grpBoxNeedleProperties = New System.Windows.Forms.GroupBox
        Me.NUDStepValue = New System.Windows.Forms.NumericUpDown
        Me.lblStepValue = New System.Windows.Forms.Label
        Me.cboxColors = New System.Windows.Forms.ComboBox
        Me.lblColor = New System.Windows.Forms.Label
        Me.lblNeedleColor = New System.Windows.Forms.Label
        Me.NUDNeedleWidth = New System.Windows.Forms.NumericUpDown
        Me.lblNeedleWidth = New System.Windows.Forms.Label
        Me.NUDNeedleType = New System.Windows.Forms.NumericUpDown
        Me.lblNeedleType = New System.Windows.Forms.Label
        Me.TpColorRanges = New System.Windows.Forms.TabPage
        Me.grpBoxColorRange = New System.Windows.Forms.GroupBox
        Me.txtAcceptStartValue = New System.Windows.Forms.TextBox
        Me.txtManageStartValue = New System.Windows.Forms.TextBox
        Me.txtUnManageStartValue = New System.Windows.Forms.TextBox
        Me.UnManageableColor = New System.Windows.Forms.Label
        Me.lblUnmanageColor = New System.Windows.Forms.Label
        Me.ManageableColor = New System.Windows.Forms.Label
        Me.lblManageColor = New System.Windows.Forms.Label
        Me.AcceptanleColor = New System.Windows.Forms.Label
        Me.lblAcceptColor = New System.Windows.Forms.Label
        Me.lblUnManageableRange = New System.Windows.Forms.Label
        Me.lblManageableRange = New System.Windows.Forms.Label
        Me.lblAcceptableRange = New System.Windows.Forms.Label
        Me.txtAcceptable = New System.Windows.Forms.TextBox
        Me.txtManageable = New System.Windows.Forms.TextBox
        Me.txtUnManageable = New System.Windows.Forms.TextBox
        Me.lblAcceptable = New System.Windows.Forms.Label
        Me.lblManageable = New System.Windows.Forms.Label
        Me.lblUnManageable = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.grpBoxMain.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.TpNeedleProperties.SuspendLayout()
        Me.GrpBoxArc.SuspendLayout()
        Me.grpBoxNeedleProperties.SuspendLayout()
        CType(Me.NUDStepValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDNeedleWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDNeedleType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpColorRanges.SuspendLayout()
        Me.grpBoxColorRange.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(568, 361)
        Me.GrpBoxPoperties.TabIndex = 13
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Guage Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Controls.Add(Me.TpNeedleProperties)
        Me.TbProperty.Controls.Add(Me.TpColorRanges)
        Me.TbProperty.Location = New System.Drawing.Point(12, 19)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(550, 309)
        Me.TbProperty.TabIndex = 22
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.grpBoxMain)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(542, 283)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'grpBoxMain
        '
        Me.grpBoxMain.Controls.Add(Me.CBoxActionChannel)
        Me.grpBoxMain.Controls.Add(Me.lblActionChannel)
        Me.grpBoxMain.Controls.Add(Me.GrpMaxMinValues)
        Me.grpBoxMain.Location = New System.Drawing.Point(6, 6)
        Me.grpBoxMain.Name = "grpBoxMain"
        Me.grpBoxMain.Size = New System.Drawing.Size(521, 271)
        Me.grpBoxMain.TabIndex = 0
        Me.grpBoxMain.TabStop = False
        '
        'CBoxActionChannel
        '
        Me.CBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBoxActionChannel.DropDownHeight = 80
        Me.CBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxActionChannel.FormattingEnabled = True
        Me.CBoxActionChannel.IntegralHeight = False
        Me.CBoxActionChannel.ItemHeight = 13
        Me.CBoxActionChannel.Location = New System.Drawing.Point(118, 26)
        Me.CBoxActionChannel.Name = "CBoxActionChannel"
        Me.CBoxActionChannel.Size = New System.Drawing.Size(305, 21)
        Me.CBoxActionChannel.TabIndex = 50
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(10, 30)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblActionChannel.TabIndex = 49
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.lblCapX)
        Me.GrpMaxMinValues.Controls.Add(Me.txtCapX)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCapY)
        Me.GrpMaxMinValues.Controls.Add(Me.txtCapY)
        Me.GrpMaxMinValues.Controls.Add(Me.txtCaption)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCtrlBackColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCaption)
        Me.GrpMaxMinValues.Controls.Add(Me.lblMinValue)
        Me.GrpMaxMinValues.Controls.Add(Me.txtMinValue)
        Me.GrpMaxMinValues.Controls.Add(Me.lblMaxValue)
        Me.GrpMaxMinValues.Controls.Add(Me.txtMaxValue)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(13, 78)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(493, 159)
        Me.GrpMaxMinValues.TabIndex = 20
        Me.GrpMaxMinValues.TabStop = False
        Me.GrpMaxMinValues.Text = "Properties"
        '
        'lblCapX
        '
        Me.lblCapX.AutoSize = True
        Me.lblCapX.Location = New System.Drawing.Point(348, 35)
        Me.lblCapX.Name = "lblCapX"
        Me.lblCapX.Size = New System.Drawing.Size(48, 13)
        Me.lblCapX.TabIndex = 28
        Me.lblCapX.Text = "Pos X :"
        '
        'txtCapX
        '
        Me.txtCapX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapX.Location = New System.Drawing.Point(402, 34)
        Me.txtCapX.Name = "txtCapX"
        Me.txtCapX.Size = New System.Drawing.Size(55, 21)
        Me.txtCapX.TabIndex = 27
        Me.txtCapX.Text = "0"
        '
        'lblCapY
        '
        Me.lblCapY.AutoSize = True
        Me.lblCapY.Location = New System.Drawing.Point(348, 66)
        Me.lblCapY.Name = "lblCapY"
        Me.lblCapY.Size = New System.Drawing.Size(47, 13)
        Me.lblCapY.TabIndex = 30
        Me.lblCapY.Text = "Pos Y :"
        '
        'txtCapY
        '
        Me.txtCapY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapY.Location = New System.Drawing.Point(402, 61)
        Me.txtCapY.Name = "txtCapY"
        Me.txtCapY.Size = New System.Drawing.Size(55, 21)
        Me.txtCapY.TabIndex = 29
        Me.txtCapY.Text = "0"
        '
        'txtCaption
        '
        Me.txtCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaption.Location = New System.Drawing.Point(131, 30)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(200, 21)
        Me.txtCaption.TabIndex = 25
        '
        'lblCtrlBackColor
        '
        Me.lblCtrlBackColor.BackColor = System.Drawing.Color.Gray
        Me.lblCtrlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtrlBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCtrlBackColor.Location = New System.Drawing.Point(131, 134)
        Me.lblCtrlBackColor.Name = "lblCtrlBackColor"
        Me.lblCtrlBackColor.Size = New System.Drawing.Size(75, 16)
        Me.lblCtrlBackColor.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(11, 134)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(119, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Background Color :"
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(11, 34)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(60, 13)
        Me.lblCaption.TabIndex = 26
        Me.lblCaption.Text = "Caption :"
        '
        'lblMinValue
        '
        Me.lblMinValue.AutoSize = True
        Me.lblMinValue.Location = New System.Drawing.Point(11, 73)
        Me.lblMinValue.Name = "lblMinValue"
        Me.lblMinValue.Size = New System.Drawing.Size(35, 13)
        Me.lblMinValue.TabIndex = 10
        Me.lblMinValue.Text = "Min :"
        '
        'txtMinValue
        '
        Me.txtMinValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinValue.Location = New System.Drawing.Point(131, 69)
        Me.txtMinValue.Name = "txtMinValue"
        Me.txtMinValue.Size = New System.Drawing.Size(65, 21)
        Me.txtMinValue.TabIndex = 9
        Me.txtMinValue.Text = "0"
        '
        'lblMaxValue
        '
        Me.lblMaxValue.AutoSize = True
        Me.lblMaxValue.Location = New System.Drawing.Point(11, 105)
        Me.lblMaxValue.Name = "lblMaxValue"
        Me.lblMaxValue.Size = New System.Drawing.Size(39, 13)
        Me.lblMaxValue.TabIndex = 12
        Me.lblMaxValue.Text = "Max :"
        '
        'txtMaxValue
        '
        Me.txtMaxValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxValue.Location = New System.Drawing.Point(131, 102)
        Me.txtMaxValue.Name = "txtMaxValue"
        Me.txtMaxValue.Size = New System.Drawing.Size(62, 21)
        Me.txtMaxValue.TabIndex = 11
        Me.txtMaxValue.Text = "450"
        '
        'TpNeedleProperties
        '
        Me.TpNeedleProperties.Controls.Add(Me.GrpBoxArc)
        Me.TpNeedleProperties.Controls.Add(Me.grpBoxNeedleProperties)
        Me.TpNeedleProperties.Location = New System.Drawing.Point(4, 22)
        Me.TpNeedleProperties.Name = "TpNeedleProperties"
        Me.TpNeedleProperties.Padding = New System.Windows.Forms.Padding(3)
        Me.TpNeedleProperties.Size = New System.Drawing.Size(542, 283)
        Me.TpNeedleProperties.TabIndex = 0
        Me.TpNeedleProperties.Text = "Needle Properties"
        Me.TpNeedleProperties.UseVisualStyleBackColor = True
        '
        'GrpBoxArc
        '
        Me.GrpBoxArc.Controls.Add(Me.lbloutarccolor)
        Me.GrpBoxArc.Controls.Add(Me.lblOutArc)
        Me.GrpBoxArc.Controls.Add(Me.CkBoxOuterArc)
        Me.GrpBoxArc.Controls.Add(Me.txtRangeStartDegree)
        Me.GrpBoxArc.Controls.Add(Me.txtRangeDegree)
        Me.GrpBoxArc.Controls.Add(Me.lblstartDegrees)
        Me.GrpBoxArc.Controls.Add(Me.lblRangeDegree)
        Me.GrpBoxArc.Location = New System.Drawing.Point(6, 133)
        Me.GrpBoxArc.Name = "GrpBoxArc"
        Me.GrpBoxArc.Size = New System.Drawing.Size(517, 132)
        Me.GrpBoxArc.TabIndex = 20
        Me.GrpBoxArc.TabStop = False
        Me.GrpBoxArc.Text = "Arc"
        '
        'lbloutarccolor
        '
        Me.lbloutarccolor.BackColor = System.Drawing.Color.Black
        Me.lbloutarccolor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbloutarccolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbloutarccolor.Location = New System.Drawing.Point(110, 106)
        Me.lbloutarccolor.Name = "lbloutarccolor"
        Me.lbloutarccolor.Size = New System.Drawing.Size(53, 16)
        Me.lbloutarccolor.TabIndex = 23
        '
        'lblOutArc
        '
        Me.lblOutArc.AutoSize = True
        Me.lblOutArc.Location = New System.Drawing.Point(7, 107)
        Me.lblOutArc.Name = "lblOutArc"
        Me.lblOutArc.Size = New System.Drawing.Size(97, 13)
        Me.lblOutArc.TabIndex = 23
        Me.lblOutArc.Text = "Outer Arc Color"
        '
        'CkBoxOuterArc
        '
        Me.CkBoxOuterArc.AutoSize = True
        Me.CkBoxOuterArc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CkBoxOuterArc.Checked = True
        Me.CkBoxOuterArc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkBoxOuterArc.Location = New System.Drawing.Point(5, 80)
        Me.CkBoxOuterArc.Name = "CkBoxOuterArc"
        Me.CkBoxOuterArc.Size = New System.Drawing.Size(122, 17)
        Me.CkBoxOuterArc.TabIndex = 24
        Me.CkBoxOuterArc.Text = "Show Outer Arc?"
        Me.CkBoxOuterArc.UseVisualStyleBackColor = True
        '
        'txtRangeStartDegree
        '
        Me.txtRangeStartDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRangeStartDegree.Location = New System.Drawing.Point(100, 53)
        Me.txtRangeStartDegree.Name = "txtRangeStartDegree"
        Me.txtRangeStartDegree.Size = New System.Drawing.Size(67, 21)
        Me.txtRangeStartDegree.TabIndex = 22
        '
        'txtRangeDegree
        '
        Me.txtRangeDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRangeDegree.Location = New System.Drawing.Point(100, 20)
        Me.txtRangeDegree.Name = "txtRangeDegree"
        Me.txtRangeDegree.Size = New System.Drawing.Size(67, 21)
        Me.txtRangeDegree.TabIndex = 21
        '
        'lblstartDegrees
        '
        Me.lblstartDegrees.AutoSize = True
        Me.lblstartDegrees.Location = New System.Drawing.Point(7, 55)
        Me.lblstartDegrees.Name = "lblstartDegrees"
        Me.lblstartDegrees.Size = New System.Drawing.Size(85, 13)
        Me.lblstartDegrees.TabIndex = 18
        Me.lblstartDegrees.Text = "Start degrees"
        '
        'lblRangeDegree
        '
        Me.lblRangeDegree.AutoSize = True
        Me.lblRangeDegree.Location = New System.Drawing.Point(5, 26)
        Me.lblRangeDegree.Name = "lblRangeDegree"
        Me.lblRangeDegree.Size = New System.Drawing.Size(95, 13)
        Me.lblRangeDegree.TabIndex = 17
        Me.lblRangeDegree.Text = "Range Degrees"
        '
        'grpBoxNeedleProperties
        '
        Me.grpBoxNeedleProperties.Controls.Add(Me.NUDStepValue)
        Me.grpBoxNeedleProperties.Controls.Add(Me.lblStepValue)
        Me.grpBoxNeedleProperties.Controls.Add(Me.cboxColors)
        Me.grpBoxNeedleProperties.Controls.Add(Me.lblColor)
        Me.grpBoxNeedleProperties.Controls.Add(Me.lblNeedleColor)
        Me.grpBoxNeedleProperties.Controls.Add(Me.NUDNeedleWidth)
        Me.grpBoxNeedleProperties.Controls.Add(Me.lblNeedleWidth)
        Me.grpBoxNeedleProperties.Controls.Add(Me.NUDNeedleType)
        Me.grpBoxNeedleProperties.Controls.Add(Me.lblNeedleType)
        Me.grpBoxNeedleProperties.Location = New System.Drawing.Point(6, 15)
        Me.grpBoxNeedleProperties.Name = "grpBoxNeedleProperties"
        Me.grpBoxNeedleProperties.Size = New System.Drawing.Size(517, 112)
        Me.grpBoxNeedleProperties.TabIndex = 19
        Me.grpBoxNeedleProperties.TabStop = False
        Me.grpBoxNeedleProperties.Text = "Needle Properties"
        '
        'NUDStepValue
        '
        Me.NUDStepValue.Location = New System.Drawing.Point(252, 61)
        Me.NUDStepValue.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NUDStepValue.Name = "NUDStepValue"
        Me.NUDStepValue.Size = New System.Drawing.Size(73, 21)
        Me.NUDStepValue.TabIndex = 22
        Me.NUDStepValue.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'lblStepValue
        '
        Me.lblStepValue.AutoSize = True
        Me.lblStepValue.Location = New System.Drawing.Point(169, 65)
        Me.lblStepValue.Name = "lblStepValue"
        Me.lblStepValue.Size = New System.Drawing.Size(69, 13)
        Me.lblStepValue.TabIndex = 21
        Me.lblStepValue.Text = "Step Value"
        '
        'cboxColors
        '
        Me.cboxColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxColors.FormattingEnabled = True
        Me.cboxColors.Items.AddRange(New Object() {"Gray", "Red", "Green", "Blue", "Yellow", "Magenta"})
        Me.cboxColors.Location = New System.Drawing.Point(253, 18)
        Me.cboxColors.Name = "cboxColors"
        Me.cboxColors.Size = New System.Drawing.Size(74, 21)
        Me.cboxColors.TabIndex = 20
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColor.Enabled = False
        Me.lblColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblColor.Location = New System.Drawing.Point(333, 20)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(53, 16)
        Me.lblColor.TabIndex = 19
        '
        'lblNeedleColor
        '
        Me.lblNeedleColor.AutoSize = True
        Me.lblNeedleColor.Location = New System.Drawing.Point(169, 22)
        Me.lblNeedleColor.Name = "lblNeedleColor"
        Me.lblNeedleColor.Size = New System.Drawing.Size(81, 13)
        Me.lblNeedleColor.TabIndex = 18
        Me.lblNeedleColor.Text = "Needle Color"
        '
        'NUDNeedleWidth
        '
        Me.NUDNeedleWidth.Location = New System.Drawing.Point(87, 61)
        Me.NUDNeedleWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUDNeedleWidth.Name = "NUDNeedleWidth"
        Me.NUDNeedleWidth.Size = New System.Drawing.Size(56, 21)
        Me.NUDNeedleWidth.TabIndex = 17
        '
        'lblNeedleWidth
        '
        Me.lblNeedleWidth.AutoSize = True
        Me.lblNeedleWidth.Location = New System.Drawing.Point(9, 67)
        Me.lblNeedleWidth.Name = "lblNeedleWidth"
        Me.lblNeedleWidth.Size = New System.Drawing.Size(43, 13)
        Me.lblNeedleWidth.TabIndex = 16
        Me.lblNeedleWidth.Text = " Width"
        '
        'NUDNeedleType
        '
        Me.NUDNeedleType.Location = New System.Drawing.Point(87, 19)
        Me.NUDNeedleType.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUDNeedleType.Name = "NUDNeedleType"
        Me.NUDNeedleType.Size = New System.Drawing.Size(37, 21)
        Me.NUDNeedleType.TabIndex = 15
        '
        'lblNeedleType
        '
        Me.lblNeedleType.AutoSize = True
        Me.lblNeedleType.Location = New System.Drawing.Point(7, 22)
        Me.lblNeedleType.Name = "lblNeedleType"
        Me.lblNeedleType.Size = New System.Drawing.Size(78, 13)
        Me.lblNeedleType.TabIndex = 14
        Me.lblNeedleType.Text = "Needle Type"
        '
        'TpColorRanges
        '
        Me.TpColorRanges.Controls.Add(Me.grpBoxColorRange)
        Me.TpColorRanges.Location = New System.Drawing.Point(4, 22)
        Me.TpColorRanges.Name = "TpColorRanges"
        Me.TpColorRanges.Padding = New System.Windows.Forms.Padding(3)
        Me.TpColorRanges.Size = New System.Drawing.Size(542, 283)
        Me.TpColorRanges.TabIndex = 1
        Me.TpColorRanges.Text = "Color Rangs"
        Me.TpColorRanges.UseVisualStyleBackColor = True
        '
        'grpBoxColorRange
        '
        Me.grpBoxColorRange.Controls.Add(Me.txtAcceptStartValue)
        Me.grpBoxColorRange.Controls.Add(Me.txtManageStartValue)
        Me.grpBoxColorRange.Controls.Add(Me.txtUnManageStartValue)
        Me.grpBoxColorRange.Controls.Add(Me.UnManageableColor)
        Me.grpBoxColorRange.Controls.Add(Me.lblUnmanageColor)
        Me.grpBoxColorRange.Controls.Add(Me.ManageableColor)
        Me.grpBoxColorRange.Controls.Add(Me.lblManageColor)
        Me.grpBoxColorRange.Controls.Add(Me.AcceptanleColor)
        Me.grpBoxColorRange.Controls.Add(Me.lblAcceptColor)
        Me.grpBoxColorRange.Controls.Add(Me.lblUnManageableRange)
        Me.grpBoxColorRange.Controls.Add(Me.lblManageableRange)
        Me.grpBoxColorRange.Controls.Add(Me.lblAcceptableRange)
        Me.grpBoxColorRange.Controls.Add(Me.txtAcceptable)
        Me.grpBoxColorRange.Controls.Add(Me.txtManageable)
        Me.grpBoxColorRange.Controls.Add(Me.txtUnManageable)
        Me.grpBoxColorRange.Controls.Add(Me.lblAcceptable)
        Me.grpBoxColorRange.Controls.Add(Me.lblManageable)
        Me.grpBoxColorRange.Controls.Add(Me.lblUnManageable)
        Me.grpBoxColorRange.Location = New System.Drawing.Point(17, 50)
        Me.grpBoxColorRange.Name = "grpBoxColorRange"
        Me.grpBoxColorRange.Size = New System.Drawing.Size(506, 192)
        Me.grpBoxColorRange.TabIndex = 20
        Me.grpBoxColorRange.TabStop = False
        Me.grpBoxColorRange.Text = "Analyzer Ranges"
        '
        'txtAcceptStartValue
        '
        Me.txtAcceptStartValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAcceptStartValue.Enabled = False
        Me.txtAcceptStartValue.Location = New System.Drawing.Point(113, 52)
        Me.txtAcceptStartValue.Name = "txtAcceptStartValue"
        Me.txtAcceptStartValue.Size = New System.Drawing.Size(62, 21)
        Me.txtAcceptStartValue.TabIndex = 26
        Me.txtAcceptStartValue.Text = "0"
        '
        'txtManageStartValue
        '
        Me.txtManageStartValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManageStartValue.Enabled = False
        Me.txtManageStartValue.Location = New System.Drawing.Point(113, 94)
        Me.txtManageStartValue.Name = "txtManageStartValue"
        Me.txtManageStartValue.Size = New System.Drawing.Size(62, 21)
        Me.txtManageStartValue.TabIndex = 27
        Me.txtManageStartValue.Text = "0"
        '
        'txtUnManageStartValue
        '
        Me.txtUnManageStartValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnManageStartValue.Enabled = False
        Me.txtUnManageStartValue.Location = New System.Drawing.Point(113, 136)
        Me.txtUnManageStartValue.Name = "txtUnManageStartValue"
        Me.txtUnManageStartValue.Size = New System.Drawing.Size(62, 21)
        Me.txtUnManageStartValue.TabIndex = 28
        Me.txtUnManageStartValue.Text = "0"
        '
        'UnManageableColor
        '
        Me.UnManageableColor.BackColor = System.Drawing.Color.Red
        Me.UnManageableColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UnManageableColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UnManageableColor.Location = New System.Drawing.Point(365, 143)
        Me.UnManageableColor.Name = "UnManageableColor"
        Me.UnManageableColor.Size = New System.Drawing.Size(53, 16)
        Me.UnManageableColor.TabIndex = 25
        '
        'lblUnmanageColor
        '
        Me.lblUnmanageColor.AutoSize = True
        Me.lblUnmanageColor.Location = New System.Drawing.Point(314, 144)
        Me.lblUnmanageColor.Name = "lblUnmanageColor"
        Me.lblUnmanageColor.Size = New System.Drawing.Size(38, 13)
        Me.lblUnmanageColor.TabIndex = 24
        Me.lblUnmanageColor.Text = "Color"
        '
        'ManageableColor
        '
        Me.ManageableColor.BackColor = System.Drawing.Color.Gold
        Me.ManageableColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ManageableColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ManageableColor.Location = New System.Drawing.Point(365, 101)
        Me.ManageableColor.Name = "ManageableColor"
        Me.ManageableColor.Size = New System.Drawing.Size(53, 16)
        Me.ManageableColor.TabIndex = 23
        '
        'lblManageColor
        '
        Me.lblManageColor.AutoSize = True
        Me.lblManageColor.Location = New System.Drawing.Point(314, 102)
        Me.lblManageColor.Name = "lblManageColor"
        Me.lblManageColor.Size = New System.Drawing.Size(38, 13)
        Me.lblManageColor.TabIndex = 22
        Me.lblManageColor.Text = "Color"
        '
        'AcceptanleColor
        '
        Me.AcceptanleColor.BackColor = System.Drawing.Color.LimeGreen
        Me.AcceptanleColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AcceptanleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AcceptanleColor.Location = New System.Drawing.Point(365, 55)
        Me.AcceptanleColor.Name = "AcceptanleColor"
        Me.AcceptanleColor.Size = New System.Drawing.Size(53, 16)
        Me.AcceptanleColor.TabIndex = 21
        '
        'lblAcceptColor
        '
        Me.lblAcceptColor.AutoSize = True
        Me.lblAcceptColor.Location = New System.Drawing.Point(314, 56)
        Me.lblAcceptColor.Name = "lblAcceptColor"
        Me.lblAcceptColor.Size = New System.Drawing.Size(38, 13)
        Me.lblAcceptColor.TabIndex = 20
        Me.lblAcceptColor.Text = "Color"
        '
        'lblUnManageableRange
        '
        Me.lblUnManageableRange.AutoSize = True
        Me.lblUnManageableRange.Location = New System.Drawing.Point(186, 142)
        Me.lblUnManageableRange.Name = "lblUnManageableRange"
        Me.lblUnManageableRange.Size = New System.Drawing.Size(18, 13)
        Me.lblUnManageableRange.TabIndex = 18
        Me.lblUnManageableRange.Text = "to"
        '
        'lblManageableRange
        '
        Me.lblManageableRange.AutoSize = True
        Me.lblManageableRange.Location = New System.Drawing.Point(186, 99)
        Me.lblManageableRange.Name = "lblManageableRange"
        Me.lblManageableRange.Size = New System.Drawing.Size(18, 13)
        Me.lblManageableRange.TabIndex = 17
        Me.lblManageableRange.Text = "to"
        '
        'lblAcceptableRange
        '
        Me.lblAcceptableRange.AutoSize = True
        Me.lblAcceptableRange.Location = New System.Drawing.Point(186, 54)
        Me.lblAcceptableRange.Name = "lblAcceptableRange"
        Me.lblAcceptableRange.Size = New System.Drawing.Size(18, 13)
        Me.lblAcceptableRange.TabIndex = 16
        Me.lblAcceptableRange.Text = "to"
        '
        'txtAcceptable
        '
        Me.txtAcceptable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAcceptable.Location = New System.Drawing.Point(227, 52)
        Me.txtAcceptable.Name = "txtAcceptable"
        Me.txtAcceptable.Size = New System.Drawing.Size(69, 21)
        Me.txtAcceptable.TabIndex = 9
        Me.txtAcceptable.Text = "0"
        '
        'txtManageable
        '
        Me.txtManageable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManageable.Location = New System.Drawing.Point(227, 94)
        Me.txtManageable.Name = "txtManageable"
        Me.txtManageable.Size = New System.Drawing.Size(69, 21)
        Me.txtManageable.TabIndex = 10
        Me.txtManageable.Text = "0"
        '
        'txtUnManageable
        '
        Me.txtUnManageable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnManageable.Location = New System.Drawing.Point(227, 136)
        Me.txtUnManageable.Name = "txtUnManageable"
        Me.txtUnManageable.Size = New System.Drawing.Size(69, 21)
        Me.txtUnManageable.TabIndex = 11
        Me.txtUnManageable.Text = "0"
        '
        'lblAcceptable
        '
        Me.lblAcceptable.AutoSize = True
        Me.lblAcceptable.Location = New System.Drawing.Point(29, 57)
        Me.lblAcceptable.Name = "lblAcceptable"
        Me.lblAcceptable.Size = New System.Drawing.Size(63, 13)
        Me.lblAcceptable.TabIndex = 12
        Me.lblAcceptable.Text = "Range 1 :"
        '
        'lblManageable
        '
        Me.lblManageable.AutoSize = True
        Me.lblManageable.Location = New System.Drawing.Point(29, 99)
        Me.lblManageable.Name = "lblManageable"
        Me.lblManageable.Size = New System.Drawing.Size(63, 13)
        Me.lblManageable.TabIndex = 13
        Me.lblManageable.Text = "Range 2 :"
        '
        'lblUnManageable
        '
        Me.lblUnManageable.AutoSize = True
        Me.lblUnManageable.Location = New System.Drawing.Point(29, 144)
        Me.lblUnManageable.Name = "lblUnManageable"
        Me.lblUnManageable.Size = New System.Drawing.Size(63, 13)
        Me.lblUnManageable.TabIndex = 14
        Me.lblUnManageable.Text = "Range 3 :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(479, 334)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(386, 334)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GuageValueFromUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 383)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(596, 405)
        Me.Name = "GuageValueFromUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.grpBoxMain.ResumeLayout(False)
        Me.grpBoxMain.PerformLayout()
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.TpNeedleProperties.ResumeLayout(False)
        Me.GrpBoxArc.ResumeLayout(False)
        Me.GrpBoxArc.PerformLayout()
        Me.grpBoxNeedleProperties.ResumeLayout(False)
        Me.grpBoxNeedleProperties.PerformLayout()
        CType(Me.NUDStepValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDNeedleWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDNeedleType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpColorRanges.ResumeLayout(False)
        Me.grpBoxColorRange.ResumeLayout(False)
        Me.grpBoxColorRange.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblUnManageable As System.Windows.Forms.Label
    Friend WithEvents lblManageable As System.Windows.Forms.Label
    Friend WithEvents lblAcceptable As System.Windows.Forms.Label
    Friend WithEvents txtUnManageable As System.Windows.Forms.TextBox
    Friend WithEvents txtManageable As System.Windows.Forms.TextBox
    Friend WithEvents txtAcceptable As System.Windows.Forms.TextBox
    Friend WithEvents grpBoxNeedleProperties As System.Windows.Forms.GroupBox
    Friend WithEvents lblNeedleColor As System.Windows.Forms.Label
    Friend WithEvents NUDNeedleWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDNeedleType As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents cboxColors As System.Windows.Forms.ComboBox
    Friend WithEvents grpBoxColorRange As System.Windows.Forms.GroupBox
    Friend WithEvents lblUnManageableRange As System.Windows.Forms.Label
    Friend WithEvents lblManageableRange As System.Windows.Forms.Label
    Friend WithEvents lblAcceptableRange As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents UnManageableColor As System.Windows.Forms.Label
    Friend WithEvents lblUnmanageColor As System.Windows.Forms.Label
    Friend WithEvents ManageableColor As System.Windows.Forms.Label
    Friend WithEvents lblManageColor As System.Windows.Forms.Label
    Friend WithEvents AcceptanleColor As System.Windows.Forms.Label
    Friend WithEvents lblAcceptColor As System.Windows.Forms.Label
    Friend WithEvents NUDStepValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStepValue As System.Windows.Forms.Label
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpNeedleProperties As System.Windows.Forms.TabPage
    Friend WithEvents TpColorRanges As System.Windows.Forms.TabPage
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents grpBoxMain As System.Windows.Forms.GroupBox
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents lblMinValue As System.Windows.Forms.Label
    Friend WithEvents txtMinValue As System.Windows.Forms.TextBox
    Friend WithEvents lblMaxValue As System.Windows.Forms.Label
    Friend WithEvents txtMaxValue As System.Windows.Forms.TextBox
    Friend WithEvents lblCtrlBackColor As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents GrpBoxArc As System.Windows.Forms.GroupBox
    Friend WithEvents txtRangeStartDegree As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeDegree As System.Windows.Forms.TextBox
    Friend WithEvents lblstartDegrees As System.Windows.Forms.Label
    Friend WithEvents lblRangeDegree As System.Windows.Forms.Label
    Friend WithEvents lblNeedleWidth As System.Windows.Forms.Label
    Friend WithEvents lblNeedleType As System.Windows.Forms.Label
    Friend WithEvents CkBoxOuterArc As System.Windows.Forms.CheckBox
    Friend WithEvents lbloutarccolor As System.Windows.Forms.Label
    Friend WithEvents lblOutArc As System.Windows.Forms.Label
    Friend WithEvents txtCaption As System.Windows.Forms.TextBox
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents CBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents lblCapX As System.Windows.Forms.Label
    Friend WithEvents txtCapX As System.Windows.Forms.TextBox
    Friend WithEvents lblCapY As System.Windows.Forms.Label
    Friend WithEvents txtCapY As System.Windows.Forms.TextBox
    Friend WithEvents txtAcceptStartValue As System.Windows.Forms.TextBox
    Friend WithEvents txtManageStartValue As System.Windows.Forms.TextBox
    Friend WithEvents txtUnManageStartValue As System.Windows.Forms.TextBox
End Class
