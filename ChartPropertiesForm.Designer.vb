''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartPropertiesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not Title_Font Is Nothing Then Title_Font.Dispose()


                If Not XYAxislbl_Font Is Nothing Then XYAxislbl_Font.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChartPropertiesForm))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox()
        Me.TbProperty = New System.Windows.Forms.TabControl()
        Me.TPSeriesAdd = New System.Windows.Forms.TabPage()
        Me.TabcontrolSeries = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grpBoxThValue = New System.Windows.Forms.GroupBox()
        Me.tab1_btnDelete = New System.Windows.Forms.Button()
        Me.tab1_btnAdd = New System.Windows.Forms.Button()
        Me.tab1_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PointsColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTraceColor = New System.Windows.Forms.Label()
        Me.tab1_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tab2_btnDelete = New System.Windows.Forms.Button()
        Me.tab2_btnAdd = New System.Windows.Forms.Button()
        Me.tab2_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab2_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tab3_btnDelete = New System.Windows.Forms.Button()
        Me.tab3_btnAdd = New System.Windows.Forms.Button()
        Me.tab3_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tab3_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tab4_btnDelete = New System.Windows.Forms.Button()
        Me.tab4_btnAdd = New System.Windows.Forms.Button()
        Me.tab4_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tab4_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tab5_btnDelete = New System.Windows.Forms.Button()
        Me.tab5_btnAdd = New System.Windows.Forms.Button()
        Me.tab5_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tab5_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tab6_btnDelete = New System.Windows.Forms.Button()
        Me.tab6_btnAdd = New System.Windows.Forms.Button()
        Me.tab6_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tab6_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tab7_btnDelete = New System.Windows.Forms.Button()
        Me.tab7_btnAdd = New System.Windows.Forms.Button()
        Me.tab7_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tab7_lblColorTrace = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tab8_btnDelete = New System.Windows.Forms.Button()
        Me.tab8_btnAdd = New System.Windows.Forms.Button()
        Me.tab8_GVTHValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tab8_lblColorTrace = New System.Windows.Forms.Label()
        Me.llblInfo = New System.Windows.Forms.LinkLabel()
        Me.txtComponentName = New System.Windows.Forms.TextBox()
        Me.lblComponentName = New System.Windows.Forms.Label()
        Me.lblAxisLabelColor = New System.Windows.Forms.Label()
        Me.lblAxisC = New System.Windows.Forms.Label()
        Me.cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.lblMarkerSize = New System.Windows.Forms.Label()
        Me.lblColorMarker = New System.Windows.Forms.Label()
        Me.lblMarkercolor = New System.Windows.Forms.Label()
        Me.CboxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.lblMarkerStyle = New System.Windows.Forms.Label()
        Me.CKBoxAxixlabel = New System.Windows.Forms.CheckBox()
        Me.CboxChartType = New System.Windows.Forms.ComboBox()
        Me.lblChartType = New System.Windows.Forms.Label()
        Me.cBoxChannelYValue = New System.Windows.Forms.ComboBox()
        Me.lblYActionChannel = New System.Windows.Forms.Label()
        Me.TpComponentName = New System.Windows.Forms.TabPage()
        Me.GboxComponentName = New System.Windows.Forms.GroupBox()
        Me.txtSeriesName = New System.Windows.Forms.TextBox()
        Me.lblSeriesName = New System.Windows.Forms.Label()
        Me.lbl_LegentColor = New System.Windows.Forms.Label()
        Me.lblLegentColor = New System.Windows.Forms.Label()
        Me.lbl_xytitleColor = New System.Windows.Forms.Label()
        Me.lblxytitleColor = New System.Windows.Forms.Label()
        Me.grpBoxYScalling = New System.Windows.Forms.GroupBox()
        Me.ckYAutoScale = New System.Windows.Forms.CheckBox()
        Me.txtYTo = New System.Windows.Forms.TextBox()
        Me.txtYFrom = New System.Windows.Forms.TextBox()
        Me.lblYTo = New System.Windows.Forms.Label()
        Me.lblYFrom = New System.Windows.Forms.Label()
        Me.cBoxChartBorder = New System.Windows.Forms.ComboBox()
        Me.lblChartBorder = New System.Windows.Forms.Label()
        Me.lbl_GridColor = New System.Windows.Forms.Label()
        Me.lblGridColor = New System.Windows.Forms.Label()
        Me.lbl_ChartBackColor = New System.Windows.Forms.Label()
        Me.lblYAxisTitle = New System.Windows.Forms.Label()
        Me.lblChartBackColor = New System.Windows.Forms.Label()
        Me.txtYAxisTitle = New System.Windows.Forms.TextBox()
        Me.lblXAxisTitle = New System.Windows.Forms.Label()
        Me.txtXAxisTitle = New System.Windows.Forms.TextBox()
        Me.lblTitleFont = New System.Windows.Forms.Label()
        Me.txtTitleFont = New System.Windows.Forms.TextBox()
        Me.btnTitleFont = New System.Windows.Forms.Button()
        Me.lblxyaxislblFont = New System.Windows.Forms.Label()
        Me.txtxyAxislblFont = New System.Windows.Forms.TextBox()
        Me.btnxyAxislblFont = New System.Windows.Forms.Button()
        Me.CkboxLegend = New System.Windows.Forms.CheckBox()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.lblCompontName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TPSeriesAdd.SuspendLayout()
        Me.TabcontrolSeries.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grpBoxThValue.SuspendLayout()
        CType(Me.tab1_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tab2_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tab3_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tab4_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.tab5_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.tab6_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.tab7_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.tab8_GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpComponentName.SuspendLayout()
        Me.GboxComponentName.SuspendLayout()
        Me.grpBoxYScalling.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(8, 3)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(904, 414)
        Me.GrpBoxPoperties.TabIndex = 14
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Chart Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TPSeriesAdd)
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Location = New System.Drawing.Point(11, 16)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(876, 365)
        Me.TbProperty.TabIndex = 22
        '
        'TPSeriesAdd
        '
        Me.TPSeriesAdd.Controls.Add(Me.TabcontrolSeries)
        Me.TPSeriesAdd.Controls.Add(Me.llblInfo)
        Me.TPSeriesAdd.Controls.Add(Me.txtComponentName)
        Me.TPSeriesAdd.Controls.Add(Me.lblComponentName)
        Me.TPSeriesAdd.Controls.Add(Me.lblAxisLabelColor)
        Me.TPSeriesAdd.Controls.Add(Me.lblAxisC)
        Me.TPSeriesAdd.Controls.Add(Me.cboxMarkerValue)
        Me.TPSeriesAdd.Controls.Add(Me.lblMarkerSize)
        Me.TPSeriesAdd.Controls.Add(Me.lblColorMarker)
        Me.TPSeriesAdd.Controls.Add(Me.lblMarkercolor)
        Me.TPSeriesAdd.Controls.Add(Me.CboxMarkerStyle)
        Me.TPSeriesAdd.Controls.Add(Me.lblMarkerStyle)
        Me.TPSeriesAdd.Controls.Add(Me.CKBoxAxixlabel)
        Me.TPSeriesAdd.Controls.Add(Me.CboxChartType)
        Me.TPSeriesAdd.Controls.Add(Me.lblChartType)
        Me.TPSeriesAdd.Controls.Add(Me.cBoxChannelYValue)
        Me.TPSeriesAdd.Controls.Add(Me.lblYActionChannel)
        Me.TPSeriesAdd.Location = New System.Drawing.Point(4, 22)
        Me.TPSeriesAdd.Name = "TPSeriesAdd"
        Me.TPSeriesAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.TPSeriesAdd.Size = New System.Drawing.Size(868, 339)
        Me.TPSeriesAdd.TabIndex = 3
        Me.TPSeriesAdd.Text = " Series"
        Me.TPSeriesAdd.UseVisualStyleBackColor = True
        '
        'TabcontrolSeries
        '
        Me.TabcontrolSeries.Controls.Add(Me.TabPage1)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage2)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage3)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage4)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage5)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage6)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage7)
        Me.TabcontrolSeries.Controls.Add(Me.TabPage8)
        Me.TabcontrolSeries.Location = New System.Drawing.Point(380, 6)
        Me.TabcontrolSeries.Name = "TabcontrolSeries"
        Me.TabcontrolSeries.SelectedIndex = 0
        Me.TabcontrolSeries.Size = New System.Drawing.Size(482, 301)
        Me.TabcontrolSeries.TabIndex = 127
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpBoxThValue)
        Me.TabPage1.Controls.Add(Me.lblTraceColor)
        Me.TabPage1.Controls.Add(Me.tab1_lblColorTrace)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(474, 275)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpBoxThValue
        '
        Me.grpBoxThValue.Controls.Add(Me.tab1_btnDelete)
        Me.grpBoxThValue.Controls.Add(Me.tab1_btnAdd)
        Me.grpBoxThValue.Controls.Add(Me.tab1_GVTHValue)
        Me.grpBoxThValue.Location = New System.Drawing.Point(19, 6)
        Me.grpBoxThValue.Name = "grpBoxThValue"
        Me.grpBoxThValue.Size = New System.Drawing.Size(326, 210)
        Me.grpBoxThValue.TabIndex = 125
        Me.grpBoxThValue.TabStop = False
        Me.grpBoxThValue.Text = "Threshold settings"
        '
        'tab1_btnDelete
        '
        Me.tab1_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab1_btnDelete.Name = "tab1_btnDelete"
        Me.tab1_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab1_btnDelete.TabIndex = 24
        Me.tab1_btnDelete.Text = "Delete"
        Me.tab1_btnDelete.UseVisualStyleBackColor = True
        '
        'tab1_btnAdd
        '
        Me.tab1_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab1_btnAdd.Name = "tab1_btnAdd"
        Me.tab1_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab1_btnAdd.TabIndex = 23
        Me.tab1_btnAdd.Text = "Add"
        Me.tab1_btnAdd.UseVisualStyleBackColor = True
        '
        'tab1_GVTHValue
        '
        Me.tab1_GVTHValue.AllowUserToAddRows = False
        Me.tab1_GVTHValue.AllowUserToDeleteRows = False
        Me.tab1_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab1_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab1_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab1_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Value, Me.PointsColor})
        Me.tab1_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab1_GVTHValue.Name = "tab1_GVTHValue"
        Me.tab1_GVTHValue.RowHeadersVisible = False
        Me.tab1_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab1_GVTHValue.TabIndex = 1
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Width = 63
        '
        'PointsColor
        '
        Me.PointsColor.HeaderText = "Color"
        Me.PointsColor.Name = "PointsColor"
        Me.PointsColor.Width = 63
        '
        'lblTraceColor
        '
        Me.lblTraceColor.AutoSize = True
        Me.lblTraceColor.Location = New System.Drawing.Point(24, 234)
        Me.lblTraceColor.Name = "lblTraceColor"
        Me.lblTraceColor.Size = New System.Drawing.Size(87, 13)
        Me.lblTraceColor.TabIndex = 68
        Me.lblTraceColor.Text = "Series Color :"
        '
        'tab1_lblColorTrace
        '
        Me.tab1_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab1_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab1_lblColorTrace.Location = New System.Drawing.Point(149, 234)
        Me.tab1_lblColorTrace.Name = "tab1_lblColorTrace"
        Me.tab1_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab1_lblColorTrace.TabIndex = 69
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.tab2_lblColorTrace)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(474, 275)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tab2_btnDelete)
        Me.GroupBox1.Controls.Add(Me.tab2_btnAdd)
        Me.GroupBox1.Controls.Add(Me.tab2_GVTHValue)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Threshold settings"
        '
        'tab2_btnDelete
        '
        Me.tab2_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab2_btnDelete.Name = "tab2_btnDelete"
        Me.tab2_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab2_btnDelete.TabIndex = 24
        Me.tab2_btnDelete.Text = "Delete"
        Me.tab2_btnDelete.UseVisualStyleBackColor = True
        '
        'tab2_btnAdd
        '
        Me.tab2_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab2_btnAdd.Name = "tab2_btnAdd"
        Me.tab2_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab2_btnAdd.TabIndex = 23
        Me.tab2_btnAdd.Text = "Add"
        Me.tab2_btnAdd.UseVisualStyleBackColor = True
        '
        'tab2_GVTHValue
        '
        Me.tab2_GVTHValue.AllowUserToAddRows = False
        Me.tab2_GVTHValue.AllowUserToDeleteRows = False
        Me.tab2_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab2_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab2_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab2_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.tab2_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab2_GVTHValue.Name = "tab2_GVTHValue"
        Me.tab2_GVTHValue.RowHeadersVisible = False
        Me.tab2_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab2_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 63
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Series Color :"
        '
        'tab2_lblColorTrace
        '
        Me.tab2_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab2_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab2_lblColorTrace.Location = New System.Drawing.Point(148, 234)
        Me.tab2_lblColorTrace.Name = "tab2_lblColorTrace"
        Me.tab2_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab2_lblColorTrace.TabIndex = 127
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.tab3_lblColorTrace)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(474, 275)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tab3_btnDelete)
        Me.GroupBox2.Controls.Add(Me.tab3_btnAdd)
        Me.GroupBox2.Controls.Add(Me.tab3_GVTHValue)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox2.TabIndex = 128
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Threshold settings"
        '
        'tab3_btnDelete
        '
        Me.tab3_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab3_btnDelete.Name = "tab3_btnDelete"
        Me.tab3_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab3_btnDelete.TabIndex = 24
        Me.tab3_btnDelete.Text = "Delete"
        Me.tab3_btnDelete.UseVisualStyleBackColor = True
        '
        'tab3_btnAdd
        '
        Me.tab3_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab3_btnAdd.Name = "tab3_btnAdd"
        Me.tab3_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab3_btnAdd.TabIndex = 23
        Me.tab3_btnAdd.Text = "Add"
        Me.tab3_btnAdd.UseVisualStyleBackColor = True
        '
        'tab3_GVTHValue
        '
        Me.tab3_GVTHValue.AllowUserToAddRows = False
        Me.tab3_GVTHValue.AllowUserToDeleteRows = False
        Me.tab3_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab3_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab3_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab3_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.tab3_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab3_GVTHValue.Name = "tab3_GVTHValue"
        Me.tab3_GVTHValue.RowHeadersVisible = False
        Me.tab3_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab3_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 63
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Series Color :"
        '
        'tab3_lblColorTrace
        '
        Me.tab3_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab3_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab3_lblColorTrace.Location = New System.Drawing.Point(144, 231)
        Me.tab3_lblColorTrace.Name = "tab3_lblColorTrace"
        Me.tab3_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab3_lblColorTrace.TabIndex = 127
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.tab4_lblColorTrace)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(474, 275)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tab4_btnDelete)
        Me.GroupBox3.Controls.Add(Me.tab4_btnAdd)
        Me.GroupBox3.Controls.Add(Me.tab4_GVTHValue)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox3.TabIndex = 128
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Threshold settings"
        '
        'tab4_btnDelete
        '
        Me.tab4_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab4_btnDelete.Name = "tab4_btnDelete"
        Me.tab4_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab4_btnDelete.TabIndex = 24
        Me.tab4_btnDelete.Text = "Delete"
        Me.tab4_btnDelete.UseVisualStyleBackColor = True
        '
        'tab4_btnAdd
        '
        Me.tab4_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab4_btnAdd.Name = "tab4_btnAdd"
        Me.tab4_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab4_btnAdd.TabIndex = 23
        Me.tab4_btnAdd.Text = "Add"
        Me.tab4_btnAdd.UseVisualStyleBackColor = True
        '
        'tab4_GVTHValue
        '
        Me.tab4_GVTHValue.AllowUserToAddRows = False
        Me.tab4_GVTHValue.AllowUserToDeleteRows = False
        Me.tab4_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab4_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab4_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab4_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.tab4_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab4_GVTHValue.Name = "tab4_GVTHValue"
        Me.tab4_GVTHValue.RowHeadersVisible = False
        Me.tab4_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab4_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 63
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 63
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Series Color :"
        '
        'tab4_lblColorTrace
        '
        Me.tab4_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab4_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab4_lblColorTrace.Location = New System.Drawing.Point(142, 231)
        Me.tab4_lblColorTrace.Name = "tab4_lblColorTrace"
        Me.tab4_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab4_lblColorTrace.TabIndex = 127
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Controls.Add(Me.Label7)
        Me.TabPage5.Controls.Add(Me.tab5_lblColorTrace)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(474, 275)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tab5_btnDelete)
        Me.GroupBox4.Controls.Add(Me.tab5_btnAdd)
        Me.GroupBox4.Controls.Add(Me.tab5_GVTHValue)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox4.TabIndex = 128
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Threshold settings"
        '
        'tab5_btnDelete
        '
        Me.tab5_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab5_btnDelete.Name = "tab5_btnDelete"
        Me.tab5_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab5_btnDelete.TabIndex = 24
        Me.tab5_btnDelete.Text = "Delete"
        Me.tab5_btnDelete.UseVisualStyleBackColor = True
        '
        'tab5_btnAdd
        '
        Me.tab5_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab5_btnAdd.Name = "tab5_btnAdd"
        Me.tab5_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab5_btnAdd.TabIndex = 23
        Me.tab5_btnAdd.Text = "Add"
        Me.tab5_btnAdd.UseVisualStyleBackColor = True
        '
        'tab5_GVTHValue
        '
        Me.tab5_GVTHValue.AllowUserToAddRows = False
        Me.tab5_GVTHValue.AllowUserToDeleteRows = False
        Me.tab5_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab5_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab5_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab5_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.tab5_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab5_GVTHValue.Name = "tab5_GVTHValue"
        Me.tab5_GVTHValue.RowHeadersVisible = False
        Me.tab5_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab5_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 63
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 63
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "Series Color :"
        '
        'tab5_lblColorTrace
        '
        Me.tab5_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab5_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab5_lblColorTrace.Location = New System.Drawing.Point(143, 231)
        Me.tab5_lblColorTrace.Name = "tab5_lblColorTrace"
        Me.tab5_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab5_lblColorTrace.TabIndex = 127
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.GroupBox5)
        Me.TabPage6.Controls.Add(Me.Label9)
        Me.TabPage6.Controls.Add(Me.tab6_lblColorTrace)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(474, 275)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "TabPage6"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tab6_btnDelete)
        Me.GroupBox5.Controls.Add(Me.tab6_btnAdd)
        Me.GroupBox5.Controls.Add(Me.tab6_GVTHValue)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox5.TabIndex = 128
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Threshold settings"
        '
        'tab6_btnDelete
        '
        Me.tab6_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab6_btnDelete.Name = "tab6_btnDelete"
        Me.tab6_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab6_btnDelete.TabIndex = 24
        Me.tab6_btnDelete.Text = "Delete"
        Me.tab6_btnDelete.UseVisualStyleBackColor = True
        '
        'tab6_btnAdd
        '
        Me.tab6_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab6_btnAdd.Name = "tab6_btnAdd"
        Me.tab6_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab6_btnAdd.TabIndex = 23
        Me.tab6_btnAdd.Text = "Add"
        Me.tab6_btnAdd.UseVisualStyleBackColor = True
        '
        'tab6_GVTHValue
        '
        Me.tab6_GVTHValue.AllowUserToAddRows = False
        Me.tab6_GVTHValue.AllowUserToDeleteRows = False
        Me.tab6_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab6_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab6_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab6_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.tab6_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab6_GVTHValue.Name = "tab6_GVTHValue"
        Me.tab6_GVTHValue.RowHeadersVisible = False
        Me.tab6_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab6_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 63
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "Series Color :"
        '
        'tab6_lblColorTrace
        '
        Me.tab6_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab6_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab6_lblColorTrace.Location = New System.Drawing.Point(133, 231)
        Me.tab6_lblColorTrace.Name = "tab6_lblColorTrace"
        Me.tab6_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab6_lblColorTrace.TabIndex = 127
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GroupBox6)
        Me.TabPage7.Controls.Add(Me.Label11)
        Me.TabPage7.Controls.Add(Me.tab7_lblColorTrace)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(474, 275)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "TabPage7"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tab7_btnDelete)
        Me.GroupBox6.Controls.Add(Me.tab7_btnAdd)
        Me.GroupBox6.Controls.Add(Me.tab7_GVTHValue)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox6.TabIndex = 128
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Threshold settings"
        '
        'tab7_btnDelete
        '
        Me.tab7_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab7_btnDelete.Name = "tab7_btnDelete"
        Me.tab7_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab7_btnDelete.TabIndex = 24
        Me.tab7_btnDelete.Text = "Delete"
        Me.tab7_btnDelete.UseVisualStyleBackColor = True
        '
        'tab7_btnAdd
        '
        Me.tab7_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab7_btnAdd.Name = "tab7_btnAdd"
        Me.tab7_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab7_btnAdd.TabIndex = 23
        Me.tab7_btnAdd.Text = "Add"
        Me.tab7_btnAdd.UseVisualStyleBackColor = True
        '
        'tab7_GVTHValue
        '
        Me.tab7_GVTHValue.AllowUserToAddRows = False
        Me.tab7_GVTHValue.AllowUserToDeleteRows = False
        Me.tab7_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab7_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab7_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab7_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.tab7_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab7_GVTHValue.Name = "tab7_GVTHValue"
        Me.tab7_GVTHValue.RowHeadersVisible = False
        Me.tab7_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab7_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 63
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 231)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Series Color :"
        '
        'tab7_lblColorTrace
        '
        Me.tab7_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab7_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab7_lblColorTrace.Location = New System.Drawing.Point(142, 231)
        Me.tab7_lblColorTrace.Name = "tab7_lblColorTrace"
        Me.tab7_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab7_lblColorTrace.TabIndex = 127
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.GroupBox7)
        Me.TabPage8.Controls.Add(Me.Label13)
        Me.TabPage8.Controls.Add(Me.tab8_lblColorTrace)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(474, 275)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "TabPage8"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tab8_btnDelete)
        Me.GroupBox7.Controls.Add(Me.tab8_btnAdd)
        Me.GroupBox7.Controls.Add(Me.tab8_GVTHValue)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(326, 210)
        Me.GroupBox7.TabIndex = 128
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Threshold settings"
        '
        'tab8_btnDelete
        '
        Me.tab8_btnDelete.Location = New System.Drawing.Point(252, 47)
        Me.tab8_btnDelete.Name = "tab8_btnDelete"
        Me.tab8_btnDelete.Size = New System.Drawing.Size(57, 21)
        Me.tab8_btnDelete.TabIndex = 24
        Me.tab8_btnDelete.Text = "Delete"
        Me.tab8_btnDelete.UseVisualStyleBackColor = True
        '
        'tab8_btnAdd
        '
        Me.tab8_btnAdd.Location = New System.Drawing.Point(252, 20)
        Me.tab8_btnAdd.Name = "tab8_btnAdd"
        Me.tab8_btnAdd.Size = New System.Drawing.Size(57, 21)
        Me.tab8_btnAdd.TabIndex = 23
        Me.tab8_btnAdd.Text = "Add"
        Me.tab8_btnAdd.UseVisualStyleBackColor = True
        '
        'tab8_GVTHValue
        '
        Me.tab8_GVTHValue.AllowUserToAddRows = False
        Me.tab8_GVTHValue.AllowUserToDeleteRows = False
        Me.tab8_GVTHValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tab8_GVTHValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.tab8_GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tab8_GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.tab8_GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.tab8_GVTHValue.Name = "tab8_GVTHValue"
        Me.tab8_GVTHValue.RowHeadersVisible = False
        Me.tab8_GVTHValue.Size = New System.Drawing.Size(221, 184)
        Me.tab8_GVTHValue.TabIndex = 1
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 63
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 63
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 231)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 126
        Me.Label13.Text = "Series Color :"
        '
        'tab8_lblColorTrace
        '
        Me.tab8_lblColorTrace.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tab8_lblColorTrace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tab8_lblColorTrace.Location = New System.Drawing.Point(142, 231)
        Me.tab8_lblColorTrace.Name = "tab8_lblColorTrace"
        Me.tab8_lblColorTrace.Size = New System.Drawing.Size(71, 18)
        Me.tab8_lblColorTrace.TabIndex = 127
        '
        'llblInfo
        '
        Me.llblInfo.AutoSize = True
        Me.llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.llblInfo.Location = New System.Drawing.Point(311, 111)
        Me.llblInfo.Name = "llblInfo"
        Me.llblInfo.Size = New System.Drawing.Size(34, 18)
        Me.llblInfo.TabIndex = 126
        Me.llblInfo.TabStop = True
        Me.llblInfo.Text = "*Info"
        Me.llblInfo.UseCompatibleTextRendering = True
        '
        'txtComponentName
        '
        Me.txtComponentName.Location = New System.Drawing.Point(153, 29)
        Me.txtComponentName.Name = "txtComponentName"
        Me.txtComponentName.ReadOnly = True
        Me.txtComponentName.Size = New System.Drawing.Size(201, 21)
        Me.txtComponentName.TabIndex = 92
        '
        'lblComponentName
        '
        Me.lblComponentName.AutoSize = True
        Me.lblComponentName.Location = New System.Drawing.Point(28, 32)
        Me.lblComponentName.Name = "lblComponentName"
        Me.lblComponentName.Size = New System.Drawing.Size(119, 13)
        Me.lblComponentName.TabIndex = 91
        Me.lblComponentName.Text = "Component Name :"
        '
        'lblAxisLabelColor
        '
        Me.lblAxisLabelColor.BackColor = System.Drawing.Color.Black
        Me.lblAxisLabelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAxisLabelColor.Location = New System.Drawing.Point(153, 248)
        Me.lblAxisLabelColor.Name = "lblAxisLabelColor"
        Me.lblAxisLabelColor.Size = New System.Drawing.Size(71, 18)
        Me.lblAxisLabelColor.TabIndex = 87
        '
        'lblAxisC
        '
        Me.lblAxisC.AutoSize = True
        Me.lblAxisC.Location = New System.Drawing.Point(28, 249)
        Me.lblAxisC.Name = "lblAxisC"
        Me.lblAxisC.Size = New System.Drawing.Size(109, 13)
        Me.lblAxisC.TabIndex = 86
        Me.lblAxisC.Text = "Axis Label Color :"
        '
        'cboxMarkerValue
        '
        Me.cboxMarkerValue.FormattingEnabled = True
        Me.cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboxMarkerValue.Location = New System.Drawing.Point(153, 181)
        Me.cboxMarkerValue.Name = "cboxMarkerValue"
        Me.cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.cboxMarkerValue.TabIndex = 84
        Me.cboxMarkerValue.Text = "0"
        '
        'lblMarkerSize
        '
        Me.lblMarkerSize.AutoSize = True
        Me.lblMarkerSize.Location = New System.Drawing.Point(28, 183)
        Me.lblMarkerSize.Name = "lblMarkerSize"
        Me.lblMarkerSize.Size = New System.Drawing.Size(84, 13)
        Me.lblMarkerSize.TabIndex = 83
        Me.lblMarkerSize.Text = "Marker Size :"
        '
        'lblColorMarker
        '
        Me.lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColorMarker.Location = New System.Drawing.Point(153, 217)
        Me.lblColorMarker.Name = "lblColorMarker"
        Me.lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.lblColorMarker.TabIndex = 81
        '
        'lblMarkercolor
        '
        Me.lblMarkercolor.AutoSize = True
        Me.lblMarkercolor.Location = New System.Drawing.Point(28, 218)
        Me.lblMarkercolor.Name = "lblMarkercolor"
        Me.lblMarkercolor.Size = New System.Drawing.Size(91, 13)
        Me.lblMarkercolor.TabIndex = 76
        Me.lblMarkercolor.Text = "Marker Color :"
        '
        'CboxMarkerStyle
        '
        Me.CboxMarkerStyle.FormattingEnabled = True
        Me.CboxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.CboxMarkerStyle.Location = New System.Drawing.Point(153, 143)
        Me.CboxMarkerStyle.Name = "CboxMarkerStyle"
        Me.CboxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.CboxMarkerStyle.TabIndex = 75
        Me.CboxMarkerStyle.Text = "None"
        '
        'lblMarkerStyle
        '
        Me.lblMarkerStyle.AutoSize = True
        Me.lblMarkerStyle.Location = New System.Drawing.Point(28, 146)
        Me.lblMarkerStyle.Name = "lblMarkerStyle"
        Me.lblMarkerStyle.Size = New System.Drawing.Size(89, 13)
        Me.lblMarkerStyle.TabIndex = 74
        Me.lblMarkerStyle.Text = "Marker Style :"
        '
        'CKBoxAxixlabel
        '
        Me.CKBoxAxixlabel.AutoSize = True
        Me.CKBoxAxixlabel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CKBoxAxixlabel.Location = New System.Drawing.Point(31, 287)
        Me.CKBoxAxixlabel.Name = "CKBoxAxixlabel"
        Me.CKBoxAxixlabel.Size = New System.Drawing.Size(133, 17)
        Me.CKBoxAxixlabel.TabIndex = 73
        Me.CKBoxAxixlabel.Text = "Axis Label Enabled"
        Me.CKBoxAxixlabel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CKBoxAxixlabel.UseVisualStyleBackColor = True
        '
        'CboxChartType
        '
        Me.CboxChartType.FormattingEnabled = True
        Me.CboxChartType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.CboxChartType.Location = New System.Drawing.Point(153, 108)
        Me.CboxChartType.Name = "CboxChartType"
        Me.CboxChartType.Size = New System.Drawing.Size(152, 21)
        Me.CboxChartType.TabIndex = 72
        Me.CboxChartType.Text = "Line"
        '
        'lblChartType
        '
        Me.lblChartType.AutoSize = True
        Me.lblChartType.Location = New System.Drawing.Point(28, 111)
        Me.lblChartType.Name = "lblChartType"
        Me.lblChartType.Size = New System.Drawing.Size(79, 13)
        Me.lblChartType.TabIndex = 71
        Me.lblChartType.Text = "Chart Type :"
        '
        'cBoxChannelYValue
        '
        Me.cBoxChannelYValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxChannelYValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxChannelYValue.DropDownHeight = 80
        Me.cBoxChannelYValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxChannelYValue.FormattingEnabled = True
        Me.cBoxChannelYValue.IntegralHeight = False
        Me.cBoxChannelYValue.ItemHeight = 13
        Me.cBoxChannelYValue.Location = New System.Drawing.Point(153, 68)
        Me.cBoxChannelYValue.Name = "cBoxChannelYValue"
        Me.cBoxChannelYValue.Size = New System.Drawing.Size(201, 21)
        Me.cBoxChannelYValue.TabIndex = 50
        '
        'lblYActionChannel
        '
        Me.lblYActionChannel.AutoSize = True
        Me.lblYActionChannel.Location = New System.Drawing.Point(28, 73)
        Me.lblYActionChannel.Name = "lblYActionChannel"
        Me.lblYActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblYActionChannel.TabIndex = 49
        Me.lblYActionChannel.Text = "Action Channel :"
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.GboxComponentName)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(868, 339)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "General"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'GboxComponentName
        '
        Me.GboxComponentName.Controls.Add(Me.txtSeriesName)
        Me.GboxComponentName.Controls.Add(Me.lblSeriesName)
        Me.GboxComponentName.Controls.Add(Me.lbl_LegentColor)
        Me.GboxComponentName.Controls.Add(Me.lblLegentColor)
        Me.GboxComponentName.Controls.Add(Me.lbl_xytitleColor)
        Me.GboxComponentName.Controls.Add(Me.lblxytitleColor)
        Me.GboxComponentName.Controls.Add(Me.grpBoxYScalling)
        Me.GboxComponentName.Controls.Add(Me.cBoxChartBorder)
        Me.GboxComponentName.Controls.Add(Me.lblChartBorder)
        Me.GboxComponentName.Controls.Add(Me.lbl_GridColor)
        Me.GboxComponentName.Controls.Add(Me.lblGridColor)
        Me.GboxComponentName.Controls.Add(Me.lbl_ChartBackColor)
        Me.GboxComponentName.Controls.Add(Me.lblYAxisTitle)
        Me.GboxComponentName.Controls.Add(Me.lblChartBackColor)
        Me.GboxComponentName.Controls.Add(Me.txtYAxisTitle)
        Me.GboxComponentName.Controls.Add(Me.lblXAxisTitle)
        Me.GboxComponentName.Controls.Add(Me.txtXAxisTitle)
        Me.GboxComponentName.Controls.Add(Me.lblTitleFont)
        Me.GboxComponentName.Controls.Add(Me.txtTitleFont)
        Me.GboxComponentName.Controls.Add(Me.btnTitleFont)
        Me.GboxComponentName.Controls.Add(Me.lblxyaxislblFont)
        Me.GboxComponentName.Controls.Add(Me.txtxyAxislblFont)
        Me.GboxComponentName.Controls.Add(Me.btnxyAxislblFont)
        Me.GboxComponentName.Controls.Add(Me.CkboxLegend)
        Me.GboxComponentName.Controls.Add(Me.TxtTitle)
        Me.GboxComponentName.Controls.Add(Me.lblCompontName)
        Me.GboxComponentName.Location = New System.Drawing.Point(6, 3)
        Me.GboxComponentName.Name = "GboxComponentName"
        Me.GboxComponentName.Size = New System.Drawing.Size(764, 294)
        Me.GboxComponentName.TabIndex = 22
        Me.GboxComponentName.TabStop = False
        '
        'txtSeriesName
        '
        Me.txtSeriesName.Location = New System.Drawing.Point(331, 52)
        Me.txtSeriesName.Name = "txtSeriesName"
        Me.txtSeriesName.Size = New System.Drawing.Size(146, 21)
        Me.txtSeriesName.TabIndex = 125
        Me.txtSeriesName.Visible = False
        '
        'lblSeriesName
        '
        Me.lblSeriesName.AutoSize = True
        Me.lblSeriesName.Location = New System.Drawing.Point(284, 55)
        Me.lblSeriesName.Name = "lblSeriesName"
        Me.lblSeriesName.Size = New System.Drawing.Size(40, 13)
        Me.lblSeriesName.TabIndex = 124
        Me.lblSeriesName.Text = "Text :"
        Me.lblSeriesName.Visible = False
        '
        'lbl_LegentColor
        '
        Me.lbl_LegentColor.BackColor = System.Drawing.Color.Black
        Me.lbl_LegentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LegentColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_LegentColor.Location = New System.Drawing.Point(223, 54)
        Me.lbl_LegentColor.Name = "lbl_LegentColor"
        Me.lbl_LegentColor.Size = New System.Drawing.Size(55, 18)
        Me.lbl_LegentColor.TabIndex = 123
        '
        'lblLegentColor
        '
        Me.lblLegentColor.AutoSize = True
        Me.lblLegentColor.Location = New System.Drawing.Point(170, 55)
        Me.lblLegentColor.Name = "lblLegentColor"
        Me.lblLegentColor.Size = New System.Drawing.Size(47, 13)
        Me.lblLegentColor.TabIndex = 122
        Me.lblLegentColor.Text = "Color :"
        '
        'lbl_xytitleColor
        '
        Me.lbl_xytitleColor.BackColor = System.Drawing.Color.Black
        Me.lbl_xytitleColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_xytitleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_xytitleColor.Location = New System.Drawing.Point(141, 182)
        Me.lbl_xytitleColor.Name = "lbl_xytitleColor"
        Me.lbl_xytitleColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_xytitleColor.TabIndex = 121
        '
        'lblxytitleColor
        '
        Me.lblxytitleColor.AutoSize = True
        Me.lblxytitleColor.Location = New System.Drawing.Point(11, 183)
        Me.lblxytitleColor.Name = "lblxytitleColor"
        Me.lblxytitleColor.Size = New System.Drawing.Size(110, 13)
        Me.lblxytitleColor.TabIndex = 120
        Me.lblxytitleColor.Text = "X && Y Title Color :"
        '
        'grpBoxYScalling
        '
        Me.grpBoxYScalling.Controls.Add(Me.ckYAutoScale)
        Me.grpBoxYScalling.Controls.Add(Me.txtYTo)
        Me.grpBoxYScalling.Controls.Add(Me.txtYFrom)
        Me.grpBoxYScalling.Controls.Add(Me.lblYTo)
        Me.grpBoxYScalling.Controls.Add(Me.lblYFrom)
        Me.grpBoxYScalling.Location = New System.Drawing.Point(436, 239)
        Me.grpBoxYScalling.Name = "grpBoxYScalling"
        Me.grpBoxYScalling.Size = New System.Drawing.Size(322, 49)
        Me.grpBoxYScalling.TabIndex = 119
        Me.grpBoxYScalling.TabStop = False
        Me.grpBoxYScalling.Text = "Y Axis Scalling "
        '
        'ckYAutoScale
        '
        Me.ckYAutoScale.AutoSize = True
        Me.ckYAutoScale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckYAutoScale.Checked = True
        Me.ckYAutoScale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckYAutoScale.Location = New System.Drawing.Point(18, 17)
        Me.ckYAutoScale.Name = "ckYAutoScale"
        Me.ckYAutoScale.Size = New System.Drawing.Size(87, 17)
        Me.ckYAutoScale.TabIndex = 124
        Me.ckYAutoScale.Text = "Auto Scale"
        Me.ckYAutoScale.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ckYAutoScale.UseVisualStyleBackColor = True
        '
        'txtYTo
        '
        Me.txtYTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYTo.Location = New System.Drawing.Point(238, 14)
        Me.txtYTo.Name = "txtYTo"
        Me.txtYTo.Size = New System.Drawing.Size(51, 21)
        Me.txtYTo.TabIndex = 85
        Me.txtYTo.Text = "500"
        '
        'txtYFrom
        '
        Me.txtYFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYFrom.Location = New System.Drawing.Point(157, 14)
        Me.txtYFrom.Name = "txtYFrom"
        Me.txtYFrom.Size = New System.Drawing.Size(43, 21)
        Me.txtYFrom.TabIndex = 83
        Me.txtYFrom.Text = "0"
        '
        'lblYTo
        '
        Me.lblYTo.AutoSize = True
        Me.lblYTo.Location = New System.Drawing.Point(206, 18)
        Me.lblYTo.Name = "lblYTo"
        Me.lblYTo.Size = New System.Drawing.Size(27, 13)
        Me.lblYTo.TabIndex = 86
        Me.lblYTo.Text = "to :"
        '
        'lblYFrom
        '
        Me.lblYFrom.AutoSize = True
        Me.lblYFrom.Location = New System.Drawing.Point(111, 18)
        Me.lblYFrom.Name = "lblYFrom"
        Me.lblYFrom.Size = New System.Drawing.Size(45, 13)
        Me.lblYFrom.TabIndex = 84
        Me.lblYFrom.Text = "From :"
        '
        'cBoxChartBorder
        '
        Me.cBoxChartBorder.FormattingEnabled = True
        Me.cBoxChartBorder.Items.AddRange(New Object() {"None", "FrameThin1", "FrameThin2", "FrameThin3", "FrameThin4", "FrameThin5", "FrameThin6", "FrameTitle1", "FrameTitle2", "FrameTitle3", "FrameTitle4", "FrameTitle5", "FrameTitle6", "FrameTitle7", "FrameTitle8"})
        Me.cBoxChartBorder.Location = New System.Drawing.Point(141, 265)
        Me.cBoxChartBorder.Name = "cBoxChartBorder"
        Me.cBoxChartBorder.Size = New System.Drawing.Size(121, 21)
        Me.cBoxChartBorder.TabIndex = 118
        '
        'lblChartBorder
        '
        Me.lblChartBorder.AutoSize = True
        Me.lblChartBorder.Location = New System.Drawing.Point(11, 268)
        Me.lblChartBorder.Name = "lblChartBorder"
        Me.lblChartBorder.Size = New System.Drawing.Size(91, 13)
        Me.lblChartBorder.TabIndex = 117
        Me.lblChartBorder.Text = "Chart Border :"
        '
        'lbl_GridColor
        '
        Me.lbl_GridColor.BackColor = System.Drawing.Color.Silver
        Me.lbl_GridColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_GridColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_GridColor.Location = New System.Drawing.Point(141, 238)
        Me.lbl_GridColor.Name = "lbl_GridColor"
        Me.lbl_GridColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_GridColor.TabIndex = 116
        '
        'lblGridColor
        '
        Me.lblGridColor.AutoSize = True
        Me.lblGridColor.Location = New System.Drawing.Point(11, 239)
        Me.lblGridColor.Name = "lblGridColor"
        Me.lblGridColor.Size = New System.Drawing.Size(103, 13)
        Me.lblGridColor.TabIndex = 115
        Me.lblGridColor.Text = "Axis Grid Color :"
        '
        'lbl_ChartBackColor
        '
        Me.lbl_ChartBackColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_ChartBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ChartBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_ChartBackColor.Location = New System.Drawing.Point(141, 209)
        Me.lbl_ChartBackColor.Name = "lbl_ChartBackColor"
        Me.lbl_ChartBackColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_ChartBackColor.TabIndex = 114
        '
        'lblYAxisTitle
        '
        Me.lblYAxisTitle.AutoSize = True
        Me.lblYAxisTitle.Location = New System.Drawing.Point(11, 155)
        Me.lblYAxisTitle.Name = "lblYAxisTitle"
        Me.lblYAxisTitle.Size = New System.Drawing.Size(79, 13)
        Me.lblYAxisTitle.TabIndex = 114
        Me.lblYAxisTitle.Text = "Y Axis Title :"
        '
        'lblChartBackColor
        '
        Me.lblChartBackColor.AutoSize = True
        Me.lblChartBackColor.Location = New System.Drawing.Point(11, 210)
        Me.lblChartBackColor.Name = "lblChartBackColor"
        Me.lblChartBackColor.Size = New System.Drawing.Size(115, 13)
        Me.lblChartBackColor.TabIndex = 113
        Me.lblChartBackColor.Text = "Chart Back Color :"
        '
        'txtYAxisTitle
        '
        Me.txtYAxisTitle.Location = New System.Drawing.Point(141, 152)
        Me.txtYAxisTitle.Name = "txtYAxisTitle"
        Me.txtYAxisTitle.Size = New System.Drawing.Size(120, 21)
        Me.txtYAxisTitle.TabIndex = 113
        '
        'lblXAxisTitle
        '
        Me.lblXAxisTitle.AutoSize = True
        Me.lblXAxisTitle.Location = New System.Drawing.Point(11, 123)
        Me.lblXAxisTitle.Name = "lblXAxisTitle"
        Me.lblXAxisTitle.Size = New System.Drawing.Size(80, 13)
        Me.lblXAxisTitle.TabIndex = 112
        Me.lblXAxisTitle.Text = "X Axis Title :"
        '
        'txtXAxisTitle
        '
        Me.txtXAxisTitle.Location = New System.Drawing.Point(141, 119)
        Me.txtXAxisTitle.Name = "txtXAxisTitle"
        Me.txtXAxisTitle.Size = New System.Drawing.Size(120, 21)
        Me.txtXAxisTitle.TabIndex = 111
        '
        'lblTitleFont
        '
        Me.lblTitleFont.AutoSize = True
        Me.lblTitleFont.Location = New System.Drawing.Point(426, 24)
        Me.lblTitleFont.Name = "lblTitleFont"
        Me.lblTitleFont.Size = New System.Drawing.Size(68, 13)
        Me.lblTitleFont.TabIndex = 105
        Me.lblTitleFont.Text = "Title Font :"
        '
        'txtTitleFont
        '
        Me.txtTitleFont.Location = New System.Drawing.Point(499, 20)
        Me.txtTitleFont.Name = "txtTitleFont"
        Me.txtTitleFont.Size = New System.Drawing.Size(190, 21)
        Me.txtTitleFont.TabIndex = 104
        '
        'btnTitleFont
        '
        Me.btnTitleFont.Location = New System.Drawing.Point(695, 19)
        Me.btnTitleFont.Name = "btnTitleFont"
        Me.btnTitleFont.Size = New System.Drawing.Size(49, 21)
        Me.btnTitleFont.TabIndex = 103
        Me.btnTitleFont.Text = "Font..."
        Me.btnTitleFont.UseVisualStyleBackColor = True
        '
        'lblxyaxislblFont
        '
        Me.lblxyaxislblFont.AutoSize = True
        Me.lblxyaxislblFont.Location = New System.Drawing.Point(11, 87)
        Me.lblxyaxislblFont.Name = "lblxyaxislblFont"
        Me.lblxyaxislblFont.Size = New System.Drawing.Size(125, 13)
        Me.lblxyaxislblFont.TabIndex = 102
        Me.lblxyaxislblFont.Text = "X,Y Axis Label Font :"
        '
        'txtxyAxislblFont
        '
        Me.txtxyAxislblFont.Location = New System.Drawing.Point(141, 83)
        Me.txtxyAxislblFont.Name = "txtxyAxislblFont"
        Me.txtxyAxislblFont.Size = New System.Drawing.Size(163, 21)
        Me.txtxyAxislblFont.TabIndex = 101
        '
        'btnxyAxislblFont
        '
        Me.btnxyAxislblFont.Location = New System.Drawing.Point(310, 83)
        Me.btnxyAxislblFont.Name = "btnxyAxislblFont"
        Me.btnxyAxislblFont.Size = New System.Drawing.Size(49, 21)
        Me.btnxyAxislblFont.TabIndex = 100
        Me.btnxyAxislblFont.Text = "Font..."
        Me.btnxyAxislblFont.UseVisualStyleBackColor = True
        '
        'CkboxLegend
        '
        Me.CkboxLegend.AutoSize = True
        Me.CkboxLegend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CkboxLegend.Checked = True
        Me.CkboxLegend.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkboxLegend.Location = New System.Drawing.Point(9, 54)
        Me.CkboxLegend.Name = "CkboxLegend"
        Me.CkboxLegend.Size = New System.Drawing.Size(148, 17)
        Me.CkboxLegend.TabIndex = 74
        Me.CkboxLegend.Text = "Legend  :                 "
        Me.CkboxLegend.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CkboxLegend.UseVisualStyleBackColor = True
        '
        'TxtTitle
        '
        Me.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtTitle.Location = New System.Drawing.Point(142, 20)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(269, 21)
        Me.TxtTitle.TabIndex = 23
        Me.TxtTitle.Text = "Title"
        '
        'lblCompontName
        '
        Me.lblCompontName.AutoSize = True
        Me.lblCompontName.Location = New System.Drawing.Point(11, 22)
        Me.lblCompontName.Name = "lblCompontName"
        Me.lblCompontName.Size = New System.Drawing.Size(70, 13)
        Me.lblCompontName.TabIndex = 24
        Me.lblCompontName.Text = "Main Title :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(719, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(71, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(644, 387)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(68, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ChartPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 420)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(940, 500)
        Me.Name = "ChartPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChartProperties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TPSeriesAdd.ResumeLayout(False)
        Me.TPSeriesAdd.PerformLayout()
        Me.TabcontrolSeries.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.grpBoxThValue.ResumeLayout(False)
        CType(Me.tab1_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tab2_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.tab3_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.tab4_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.tab5_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.tab6_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.tab7_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.tab8_GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpComponentName.ResumeLayout(False)
        Me.GboxComponentName.ResumeLayout(False)
        Me.GboxComponentName.PerformLayout()
        Me.grpBoxYScalling.ResumeLayout(False)
        Me.grpBoxYScalling.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GboxComponentName As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblCompontName As System.Windows.Forms.Label
    Friend WithEvents TPSeriesAdd As System.Windows.Forms.TabPage
    Friend WithEvents cBoxChannelYValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblYActionChannel As System.Windows.Forms.Label
    Friend WithEvents CKBoxAxixlabel As System.Windows.Forms.CheckBox
    Friend WithEvents CkboxLegend As System.Windows.Forms.CheckBox
    Friend WithEvents lblAxisLabelColor As System.Windows.Forms.Label
    Friend WithEvents lblAxisC As System.Windows.Forms.Label
    Friend WithEvents txtxyAxislblFont As System.Windows.Forms.TextBox
    Friend WithEvents btnxyAxislblFont As System.Windows.Forms.Button
    Friend WithEvents lblTitleFont As System.Windows.Forms.Label
    Friend WithEvents txtTitleFont As System.Windows.Forms.TextBox
    Friend WithEvents btnTitleFont As System.Windows.Forms.Button
    Friend WithEvents lblxyaxislblFont As System.Windows.Forms.Label
    Friend WithEvents lblYAxisTitle As System.Windows.Forms.Label
    Friend WithEvents txtYAxisTitle As System.Windows.Forms.TextBox
    Friend WithEvents lblXAxisTitle As System.Windows.Forms.Label
    Friend WithEvents txtXAxisTitle As System.Windows.Forms.TextBox
    Friend WithEvents cBoxChartBorder As System.Windows.Forms.ComboBox
    Friend WithEvents lblChartBorder As System.Windows.Forms.Label
    Friend WithEvents lbl_GridColor As System.Windows.Forms.Label
    Friend WithEvents lblGridColor As System.Windows.Forms.Label
    Friend WithEvents lbl_ChartBackColor As System.Windows.Forms.Label
    Friend WithEvents lblChartBackColor As System.Windows.Forms.Label
    Friend WithEvents cboxMarkerValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblMarkerSize As System.Windows.Forms.Label
    Friend WithEvents lblColorMarker As System.Windows.Forms.Label
    Friend WithEvents lblMarkercolor As System.Windows.Forms.Label
    Friend WithEvents CboxMarkerStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblMarkerStyle As System.Windows.Forms.Label
    Friend WithEvents CboxChartType As System.Windows.Forms.ComboBox
    Friend WithEvents lblChartType As System.Windows.Forms.Label
    Friend WithEvents tab1_lblColorTrace As System.Windows.Forms.Label
    Friend WithEvents lblTraceColor As System.Windows.Forms.Label
    Friend WithEvents grpBoxYScalling As System.Windows.Forms.GroupBox
    Friend WithEvents txtYTo As System.Windows.Forms.TextBox
    Friend WithEvents txtYFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblYTo As System.Windows.Forms.Label
    Friend WithEvents lblYFrom As System.Windows.Forms.Label
    Friend WithEvents lbl_LegentColor As System.Windows.Forms.Label
    Friend WithEvents lblLegentColor As System.Windows.Forms.Label
    Friend WithEvents lbl_xytitleColor As System.Windows.Forms.Label
    Friend WithEvents lblxytitleColor As System.Windows.Forms.Label
    Friend WithEvents ckYAutoScale As System.Windows.Forms.CheckBox
    Friend WithEvents txtComponentName As System.Windows.Forms.TextBox
    Friend WithEvents lblComponentName As System.Windows.Forms.Label
    Friend WithEvents grpBoxThValue As System.Windows.Forms.GroupBox
    Friend WithEvents tab1_btnDelete As System.Windows.Forms.Button
    Friend WithEvents tab1_btnAdd As System.Windows.Forms.Button
    Friend WithEvents tab1_GVTHValue As System.Windows.Forms.DataGridView
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PointsColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents llblInfo As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSeriesName As System.Windows.Forms.TextBox
    Friend WithEvents lblSeriesName As System.Windows.Forms.Label
    Friend WithEvents TabcontrolSeries As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tab2_btnDelete As Button
    Friend WithEvents tab2_btnAdd As Button
    Friend WithEvents tab2_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents tab2_lblColorTrace As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tab3_btnDelete As Button
    Friend WithEvents tab3_btnAdd As Button
    Friend WithEvents tab3_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents tab3_lblColorTrace As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tab4_btnDelete As Button
    Friend WithEvents tab4_btnAdd As Button
    Friend WithEvents tab4_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents tab4_lblColorTrace As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tab5_btnDelete As Button
    Friend WithEvents tab5_btnAdd As Button
    Friend WithEvents tab5_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents tab5_lblColorTrace As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents tab6_btnDelete As Button
    Friend WithEvents tab6_btnAdd As Button
    Friend WithEvents tab6_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents Label9 As Label
    Friend WithEvents tab6_lblColorTrace As Label
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tab7_btnDelete As Button
    Friend WithEvents tab7_btnAdd As Button
    Friend WithEvents tab7_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents Label11 As Label
    Friend WithEvents tab7_lblColorTrace As Label
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents tab8_btnDelete As Button
    Friend WithEvents tab8_btnAdd As Button
    Friend WithEvents tab8_GVTHValue As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents Label13 As Label
    Friend WithEvents tab8_lblColorTrace As Label
End Class
