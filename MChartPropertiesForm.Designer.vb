<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MChartPropertiesForm
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tabMChartProp = New DevExpress.XtraTab.XtraTabControl()
        Me.tabPage1_General = New DevExpress.XtraTab.XtraTabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboActionChannel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLambda = New System.Windows.Forms.ComboBox()
        Me.cboP2Sch = New System.Windows.Forms.ComboBox()
        Me.cboP2 = New System.Windows.Forms.ComboBox()
        Me.cboP1Sch = New System.Windows.Forms.ComboBox()
        Me.cboP1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.btnCLineDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCLineAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.gcConstantLine = New DevExpress.XtraGrid.GridControl()
        Me.ViewConstantLine = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAxis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepItemCboxAxis = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colAxisValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepItemSpinAxisVal = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colVisible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepItemChkVisible = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepItemColorLine = New DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.btnCSeriesDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCSeriesAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.gcConstantSeries = New DevExpress.XtraGrid.GridControl()
        Me.ViewStaticSeries = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSeriesName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPointX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPointY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSeriesColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepItemColorSeries = New DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit()
        Me.colMarker = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CboxTagscale = New System.Windows.Forms.ComboBox()
        Me.lblXaxisTagname = New System.Windows.Forms.Label()
        Me.cBoxChannelValue = New System.Windows.Forms.ComboBox()
        Me.Ser1_lblYActionChannel = New System.Windows.Forms.Label()
        Me.lblAxisLabelColor = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ckLabelEnable = New System.Windows.Forms.CheckBox()
        Me.ckLegendEnable = New System.Windows.Forms.CheckBox()
        Me.lbl_LegendColor = New System.Windows.Forms.Label()
        Me.lblLegendColor = New System.Windows.Forms.Label()
        Me.RBtnValue = New System.Windows.Forms.RadioButton()
        Me.Rbtntime = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_ChartBackColor = New System.Windows.Forms.Label()
        Me.lblChartBackColor = New System.Windows.Forms.Label()
        Me.grpBoxYScalling = New System.Windows.Forms.GroupBox()
        Me.ckYAutoScale = New System.Windows.Forms.CheckBox()
        Me.txtYTo = New System.Windows.Forms.TextBox()
        Me.txtYFrom = New System.Windows.Forms.TextBox()
        Me.lblYTo = New System.Windows.Forms.Label()
        Me.lblYFrom = New System.Windows.Forms.Label()
        Me.lbl_xytitleColor = New System.Windows.Forms.Label()
        Me.lblxytitleColor = New System.Windows.Forms.Label()
        Me.lblYAxisTitle = New System.Windows.Forms.Label()
        Me.txtYAxisTitle = New System.Windows.Forms.TextBox()
        Me.lblXAxisTitle = New System.Windows.Forms.Label()
        Me.txtXAxisTitle = New System.Windows.Forms.TextBox()
        Me.lblTitleFont = New System.Windows.Forms.Label()
        Me.txtTitleFont = New System.Windows.Forms.TextBox()
        Me.btnTitleFont = New System.Windows.Forms.Button()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.lblChartTitleName = New System.Windows.Forms.Label()
        Me.tabPage2_Series1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser1_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser1_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser1_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser1_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser1_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser1_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser1_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser1_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser1_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser1_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser1_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser1_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser1_lblViewType = New System.Windows.Forms.Label()
        Me.Ser1_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser1_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage3_Series2 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser2_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser2_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser2_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser2_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser2_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser2_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser2_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser2_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser2_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser2_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser2_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser2_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser2_lblViewType = New System.Windows.Forms.Label()
        Me.Ser2_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser2_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage4_Series3 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser3_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser3_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser3_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser3_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser3_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser3_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser3_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser3_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser3_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser3_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser3_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser3_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser3_lblViewType = New System.Windows.Forms.Label()
        Me.Ser3_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser3_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage5_Series4 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser4_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser4_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser4_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser4_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser4_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser4_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser4_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser4_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser4_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser4_CboxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser4_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser4_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser4_lblViewType = New System.Windows.Forms.Label()
        Me.Ser4_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser4_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage6_Series5 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser5_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser5_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser5_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser5_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser5_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.lblMarkerSize5 = New System.Windows.Forms.Label()
        Me.Ser5_lblColorMarker = New System.Windows.Forms.Label()
        Me.lblMarkercolor5 = New System.Windows.Forms.Label()
        Me.Ser5_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.lblMarkerStyle5 = New System.Windows.Forms.Label()
        Me.Ser5_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.lblViewType5 = New System.Windows.Forms.Label()
        Me.Ser5_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser5_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage7_Series6 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser6_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser6_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser6_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser6_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser6_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser6_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser6_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser6_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser6_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser6_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser6_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser6_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser6_lblViewType = New System.Windows.Forms.Label()
        Me.Ser6_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser6_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage8_Series7 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser7_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser7_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser7_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser7_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser7_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser7_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.Ser7_lblMarkerSize = New System.Windows.Forms.Label()
        Me.Ser7_lblColorMarker = New System.Windows.Forms.Label()
        Me.lblMarkercolor7 = New System.Windows.Forms.Label()
        Me.Ser7_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser7_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser7_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser7_lblViewType = New System.Windows.Forms.Label()
        Me.Ser7_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser7_lblSeriesName = New System.Windows.Forms.Label()
        Me.tabPage9_Series8 = New DevExpress.XtraTab.XtraTabPage()
        Me.Ser8_llblInfo = New System.Windows.Forms.LinkLabel()
        Me.Ser8_lblColorSeries = New System.Windows.Forms.Label()
        Me.Ser8_lblSeriescolor = New System.Windows.Forms.Label()
        Me.Ser8_cBoxChannelY2Value = New System.Windows.Forms.ComboBox()
        Me.Ser8_lblY2ActionChannel = New System.Windows.Forms.Label()
        Me.Ser8_cboxMarkerValue = New System.Windows.Forms.ComboBox()
        Me.lblMarkerSize8 = New System.Windows.Forms.Label()
        Me.Ser8_lblColorMarker = New System.Windows.Forms.Label()
        Me.Ser8_lblMarkercolor = New System.Windows.Forms.Label()
        Me.Ser8_cBoxMarkerStyle = New System.Windows.Forms.ComboBox()
        Me.Ser8_lblMarkerStyle = New System.Windows.Forms.Label()
        Me.Ser8_cBoxViewType = New System.Windows.Forms.ComboBox()
        Me.Ser8_lblViewType = New System.Windows.Forms.Label()
        Me.Ser8_txtSeriesName = New System.Windows.Forms.TextBox()
        Me.Ser8_lblSeriesName = New System.Windows.Forms.Label()
        Me.btnMChartpropertiseCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tabMChartProp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMChartProp.SuspendLayout()
        Me.tabPage1_General.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.gcConstantLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewConstantLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItemCboxAxis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItemSpinAxisVal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItemChkVisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItemColorLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.gcConstantSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewStaticSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItemColorSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBoxYScalling.SuspendLayout()
        Me.tabPage2_Series1.SuspendLayout()
        Me.tabPage3_Series2.SuspendLayout()
        Me.tabPage4_Series3.SuspendLayout()
        Me.tabPage5_Series4.SuspendLayout()
        Me.tabPage6_Series5.SuspendLayout()
        Me.tabPage7_Series6.SuspendLayout()
        Me.tabPage8_Series7.SuspendLayout()
        Me.tabPage9_Series8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tabMChartProp)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 441)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chart Properties"
        '
        'tabMChartProp
        '
        Me.tabMChartProp.Location = New System.Drawing.Point(9, 19)
        Me.tabMChartProp.Name = "tabMChartProp"
        Me.tabMChartProp.SelectedTabPage = Me.tabPage1_General
        Me.tabMChartProp.Size = New System.Drawing.Size(873, 412)
        Me.tabMChartProp.TabIndex = 2
        Me.tabMChartProp.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabPage1_General, Me.tabPage2_Series1, Me.tabPage3_Series2, Me.tabPage4_Series3, Me.tabPage5_Series4, Me.tabPage6_Series5, Me.tabPage7_Series6, Me.tabPage8_Series7, Me.tabPage9_Series8})
        '
        'tabPage1_General
        '
        Me.tabPage1_General.Controls.Add(Me.Label6)
        Me.tabPage1_General.Controls.Add(Me.Label5)
        Me.tabPage1_General.Controls.Add(Me.cboActionChannel)
        Me.tabPage1_General.Controls.Add(Me.Label4)
        Me.tabPage1_General.Controls.Add(Me.cboLambda)
        Me.tabPage1_General.Controls.Add(Me.cboP2Sch)
        Me.tabPage1_General.Controls.Add(Me.cboP2)
        Me.tabPage1_General.Controls.Add(Me.cboP1Sch)
        Me.tabPage1_General.Controls.Add(Me.cboP1)
        Me.tabPage1_General.Controls.Add(Me.Label1)
        Me.tabPage1_General.Controls.Add(Me.Label7)
        Me.tabPage1_General.Controls.Add(Me.Label8)
        Me.tabPage1_General.Controls.Add(Me.XtraTabControl1)
        Me.tabPage1_General.Controls.Add(Me.CboxTagscale)
        Me.tabPage1_General.Controls.Add(Me.lblXaxisTagname)
        Me.tabPage1_General.Controls.Add(Me.cBoxChannelValue)
        Me.tabPage1_General.Controls.Add(Me.Ser1_lblYActionChannel)
        Me.tabPage1_General.Controls.Add(Me.lblAxisLabelColor)
        Me.tabPage1_General.Controls.Add(Me.Label3)
        Me.tabPage1_General.Controls.Add(Me.ckLabelEnable)
        Me.tabPage1_General.Controls.Add(Me.ckLegendEnable)
        Me.tabPage1_General.Controls.Add(Me.lbl_LegendColor)
        Me.tabPage1_General.Controls.Add(Me.lblLegendColor)
        Me.tabPage1_General.Controls.Add(Me.RBtnValue)
        Me.tabPage1_General.Controls.Add(Me.Rbtntime)
        Me.tabPage1_General.Controls.Add(Me.Label2)
        Me.tabPage1_General.Controls.Add(Me.lbl_ChartBackColor)
        Me.tabPage1_General.Controls.Add(Me.lblChartBackColor)
        Me.tabPage1_General.Controls.Add(Me.grpBoxYScalling)
        Me.tabPage1_General.Controls.Add(Me.lbl_xytitleColor)
        Me.tabPage1_General.Controls.Add(Me.lblxytitleColor)
        Me.tabPage1_General.Controls.Add(Me.lblYAxisTitle)
        Me.tabPage1_General.Controls.Add(Me.txtYAxisTitle)
        Me.tabPage1_General.Controls.Add(Me.lblXAxisTitle)
        Me.tabPage1_General.Controls.Add(Me.txtXAxisTitle)
        Me.tabPage1_General.Controls.Add(Me.lblTitleFont)
        Me.tabPage1_General.Controls.Add(Me.txtTitleFont)
        Me.tabPage1_General.Controls.Add(Me.btnTitleFont)
        Me.tabPage1_General.Controls.Add(Me.TxtTitle)
        Me.tabPage1_General.Controls.Add(Me.lblChartTitleName)
        Me.tabPage1_General.Name = "tabPage1_General"
        Me.tabPage1_General.Size = New System.Drawing.Size(868, 386)
        Me.tabPage1_General.Text = "General"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(527, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 463
        Me.Label6.Text = "Tag for P2Sch"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(527, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 459
        Me.Label5.Text = "Tag for P1Sch"
        '
        'cboActionChannel
        '
        Me.cboActionChannel.FormattingEnabled = True
        Me.cboActionChannel.Location = New System.Drawing.Point(642, 47)
        Me.cboActionChannel.Name = "cboActionChannel"
        Me.cboActionChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboActionChannel.TabIndex = 454
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(527, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 453
        Me.Label4.Text = "Action Channel"
        '
        'cboLambda
        '
        Me.cboLambda.FormattingEnabled = True
        Me.cboLambda.Location = New System.Drawing.Point(642, 74)
        Me.cboLambda.Name = "cboLambda"
        Me.cboLambda.Size = New System.Drawing.Size(181, 21)
        Me.cboLambda.TabIndex = 456
        '
        'cboP2Sch
        '
        Me.cboP2Sch.FormattingEnabled = True
        Me.cboP2Sch.Location = New System.Drawing.Point(642, 182)
        Me.cboP2Sch.Name = "cboP2Sch"
        Me.cboP2Sch.Size = New System.Drawing.Size(181, 21)
        Me.cboP2Sch.TabIndex = 464
        '
        'cboP2
        '
        Me.cboP2.FormattingEnabled = True
        Me.cboP2.Location = New System.Drawing.Point(642, 155)
        Me.cboP2.Name = "cboP2"
        Me.cboP2.Size = New System.Drawing.Size(181, 21)
        Me.cboP2.TabIndex = 462
        '
        'cboP1Sch
        '
        Me.cboP1Sch.FormattingEnabled = True
        Me.cboP1Sch.Location = New System.Drawing.Point(642, 128)
        Me.cboP1Sch.Name = "cboP1Sch"
        Me.cboP1Sch.Size = New System.Drawing.Size(181, 21)
        Me.cboP1Sch.TabIndex = 460
        '
        'cboP1
        '
        Me.cboP1.FormattingEnabled = True
        Me.cboP1.Location = New System.Drawing.Point(642, 101)
        Me.cboP1.Name = "cboP1"
        Me.cboP1.Size = New System.Drawing.Size(181, 21)
        Me.cboP1.TabIndex = 458
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(527, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 455
        Me.Label1.Text = "Tag for Lambda"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(527, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 461
        Me.Label7.Text = "Tags for P2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(527, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 457
        Me.Label8.Text = "Tag for P1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 193)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(481, 235)
        Me.XtraTabControl1.TabIndex = 148
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        Me.XtraTabControl1.Visible = False
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.btnCLineDelete)
        Me.XtraTabPage1.Controls.Add(Me.btnCLineAdd)
        Me.XtraTabPage1.Controls.Add(Me.gcConstantLine)
        Me.XtraTabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(476, 209)
        Me.XtraTabPage1.Text = "Constant Lines"
        '
        'btnCLineDelete
        '
        Me.btnCLineDelete.Location = New System.Drawing.Point(421, 180)
        Me.btnCLineDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCLineDelete.Name = "btnCLineDelete"
        Me.btnCLineDelete.Size = New System.Drawing.Size(43, 21)
        Me.btnCLineDelete.TabIndex = 1
        Me.btnCLineDelete.Text = "Delete"
        '
        'btnCLineAdd
        '
        Me.btnCLineAdd.Location = New System.Drawing.Point(361, 180)
        Me.btnCLineAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCLineAdd.Name = "btnCLineAdd"
        Me.btnCLineAdd.Size = New System.Drawing.Size(43, 21)
        Me.btnCLineAdd.TabIndex = 1
        Me.btnCLineAdd.Text = "Add"
        '
        'gcConstantLine
        '
        Me.gcConstantLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcConstantLine.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.First.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.gcConstantLine.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.gcConstantLine.Location = New System.Drawing.Point(0, 0)
        Me.gcConstantLine.MainView = Me.ViewConstantLine
        Me.gcConstantLine.Margin = New System.Windows.Forms.Padding(2)
        Me.gcConstantLine.Name = "gcConstantLine"
        Me.gcConstantLine.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepItemColorLine, Me.RepItemCboxAxis, Me.RepItemChkVisible, Me.RepItemSpinAxisVal})
        Me.gcConstantLine.Size = New System.Drawing.Size(476, 174)
        Me.gcConstantLine.TabIndex = 0
        Me.gcConstantLine.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ViewConstantLine})
        '
        'ViewConstantLine
        '
        Me.ViewConstantLine.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colName, Me.colAxis, Me.colAxisValue, Me.colVisible, Me.colColor})
        Me.ViewConstantLine.DetailHeight = 239
        Me.ViewConstantLine.GridControl = Me.gcConstantLine
        Me.ViewConstantLine.Name = "ViewConstantLine"
        Me.ViewConstantLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "LineName"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 0
        '
        'colAxis
        '
        Me.colAxis.Caption = "Axis"
        Me.colAxis.ColumnEdit = Me.RepItemCboxAxis
        Me.colAxis.FieldName = "Axis"
        Me.colAxis.Name = "colAxis"
        Me.colAxis.Visible = True
        Me.colAxis.VisibleIndex = 1
        '
        'RepItemCboxAxis
        '
        Me.RepItemCboxAxis.AutoHeight = False
        Me.RepItemCboxAxis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepItemCboxAxis.Items.AddRange(New Object() {"X-Axis", "Y-Axis"})
        Me.RepItemCboxAxis.Name = "RepItemCboxAxis"
        '
        'colAxisValue
        '
        Me.colAxisValue.Caption = "AxisValue"
        Me.colAxisValue.ColumnEdit = Me.RepItemSpinAxisVal
        Me.colAxisValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAxisValue.FieldName = "AxisValue"
        Me.colAxisValue.Name = "colAxisValue"
        Me.colAxisValue.Visible = True
        Me.colAxisValue.VisibleIndex = 2
        '
        'RepItemSpinAxisVal
        '
        Me.RepItemSpinAxisVal.AutoHeight = False
        Me.RepItemSpinAxisVal.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepItemSpinAxisVal.Name = "RepItemSpinAxisVal"
        '
        'colVisible
        '
        Me.colVisible.Caption = "Visible"
        Me.colVisible.ColumnEdit = Me.RepItemChkVisible
        Me.colVisible.FieldName = "Visible"
        Me.colVisible.Name = "colVisible"
        Me.colVisible.Visible = True
        Me.colVisible.VisibleIndex = 3
        '
        'RepItemChkVisible
        '
        Me.RepItemChkVisible.AutoHeight = False
        Me.RepItemChkVisible.Name = "RepItemChkVisible"
        '
        'colColor
        '
        Me.colColor.Caption = "Color"
        Me.colColor.ColumnEdit = Me.RepItemColorLine
        Me.colColor.FieldName = "Color"
        Me.colColor.Name = "colColor"
        Me.colColor.Visible = True
        Me.colColor.VisibleIndex = 4
        '
        'RepItemColorLine
        '
        Me.RepItemColorLine.AutoHeight = False
        Me.RepItemColorLine.AutomaticColor = System.Drawing.Color.Black
        Me.RepItemColorLine.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepItemColorLine.Name = "RepItemColorLine"
        Me.RepItemColorLine.StoreColorAsInteger = True
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.btnCSeriesDelete)
        Me.XtraTabPage2.Controls.Add(Me.btnCSeriesAdd)
        Me.XtraTabPage2.Controls.Add(Me.gcConstantSeries)
        Me.XtraTabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(476, 209)
        Me.XtraTabPage2.Text = "Constant Series"
        '
        'btnCSeriesDelete
        '
        Me.btnCSeriesDelete.Location = New System.Drawing.Point(418, 180)
        Me.btnCSeriesDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCSeriesDelete.Name = "btnCSeriesDelete"
        Me.btnCSeriesDelete.Size = New System.Drawing.Size(43, 21)
        Me.btnCSeriesDelete.TabIndex = 2
        Me.btnCSeriesDelete.Text = "Delete"
        '
        'btnCSeriesAdd
        '
        Me.btnCSeriesAdd.Location = New System.Drawing.Point(358, 180)
        Me.btnCSeriesAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCSeriesAdd.Name = "btnCSeriesAdd"
        Me.btnCSeriesAdd.Size = New System.Drawing.Size(43, 21)
        Me.btnCSeriesAdd.TabIndex = 3
        Me.btnCSeriesAdd.Text = "Edit"
        '
        'gcConstantSeries
        '
        Me.gcConstantSeries.Dock = System.Windows.Forms.DockStyle.Top
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.First.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.gcConstantSeries.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.gcConstantSeries.Location = New System.Drawing.Point(0, 0)
        Me.gcConstantSeries.MainView = Me.ViewStaticSeries
        Me.gcConstantSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.gcConstantSeries.Name = "gcConstantSeries"
        Me.gcConstantSeries.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepItemColorSeries})
        Me.gcConstantSeries.Size = New System.Drawing.Size(476, 174)
        Me.gcConstantSeries.TabIndex = 0
        Me.gcConstantSeries.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ViewStaticSeries})
        '
        'ViewStaticSeries
        '
        Me.ViewStaticSeries.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSeriesName, Me.colPointX, Me.colPointY, Me.colSeriesColor, Me.colMarker})
        Me.ViewStaticSeries.DetailHeight = 239
        Me.ViewStaticSeries.GridControl = Me.gcConstantSeries
        Me.ViewStaticSeries.Name = "ViewStaticSeries"
        Me.ViewStaticSeries.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        '
        'colSeriesName
        '
        Me.colSeriesName.Caption = "SeriesName"
        Me.colSeriesName.Name = "colSeriesName"
        '
        'colPointX
        '
        Me.colPointX.Caption = "Point-X Value"
        Me.colPointX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPointX.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPointX.Name = "colPointX"
        '
        'colPointY
        '
        Me.colPointY.Caption = "Point-Y Value"
        Me.colPointY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPointY.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPointY.Name = "colPointY"
        '
        'colSeriesColor
        '
        Me.colSeriesColor.Caption = "Color"
        Me.colSeriesColor.ColumnEdit = Me.RepItemColorSeries
        Me.colSeriesColor.Name = "colSeriesColor"
        '
        'RepItemColorSeries
        '
        Me.RepItemColorSeries.AutoHeight = False
        Me.RepItemColorSeries.AutomaticColor = System.Drawing.Color.Black
        Me.RepItemColorSeries.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepItemColorSeries.Name = "RepItemColorSeries"
        '
        'colMarker
        '
        Me.colMarker.Caption = "Marker"
        Me.colMarker.Name = "colMarker"
        '
        'CboxTagscale
        '
        Me.CboxTagscale.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboxTagscale.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboxTagscale.DropDownHeight = 80
        Me.CboxTagscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboxTagscale.FormattingEnabled = True
        Me.CboxTagscale.IntegralHeight = False
        Me.CboxTagscale.ItemHeight = 13
        Me.CboxTagscale.Location = New System.Drawing.Point(132, 337)
        Me.CboxTagscale.Name = "CboxTagscale"
        Me.CboxTagscale.Size = New System.Drawing.Size(201, 21)
        Me.CboxTagscale.TabIndex = 147
        Me.CboxTagscale.Visible = False
        '
        'lblXaxisTagname
        '
        Me.lblXaxisTagname.AutoSize = True
        Me.lblXaxisTagname.Location = New System.Drawing.Point(9, 339)
        Me.lblXaxisTagname.Name = "lblXaxisTagname"
        Me.lblXaxisTagname.Size = New System.Drawing.Size(59, 13)
        Me.lblXaxisTagname.TabIndex = 146
        Me.lblXaxisTagname.Text = "Tag Name:"
        Me.lblXaxisTagname.Visible = False
        '
        'cBoxChannelValue
        '
        Me.cBoxChannelValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxChannelValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxChannelValue.DropDownHeight = 80
        Me.cBoxChannelValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxChannelValue.FormattingEnabled = True
        Me.cBoxChannelValue.IntegralHeight = False
        Me.cBoxChannelValue.ItemHeight = 13
        Me.cBoxChannelValue.Location = New System.Drawing.Point(132, 272)
        Me.cBoxChannelValue.Name = "cBoxChannelValue"
        Me.cBoxChannelValue.Size = New System.Drawing.Size(201, 21)
        Me.cBoxChannelValue.TabIndex = 145
        '
        'Ser1_lblYActionChannel
        '
        Me.Ser1_lblYActionChannel.AutoSize = True
        Me.Ser1_lblYActionChannel.Location = New System.Drawing.Point(7, 277)
        Me.Ser1_lblYActionChannel.Name = "Ser1_lblYActionChannel"
        Me.Ser1_lblYActionChannel.Size = New System.Drawing.Size(86, 13)
        Me.Ser1_lblYActionChannel.TabIndex = 144
        Me.Ser1_lblYActionChannel.Text = "Action Channel :"
        '
        'lblAxisLabelColor
        '
        Me.lblAxisLabelColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAxisLabelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAxisLabelColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAxisLabelColor.Location = New System.Drawing.Point(136, 216)
        Me.lblAxisLabelColor.Name = "lblAxisLabelColor"
        Me.lblAxisLabelColor.Size = New System.Drawing.Size(59, 18)
        Me.lblAxisLabelColor.TabIndex = 143
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Axis Label Color :"
        '
        'ckLabelEnable
        '
        Me.ckLabelEnable.AutoSize = True
        Me.ckLabelEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckLabelEnable.Checked = True
        Me.ckLabelEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckLabelEnable.Location = New System.Drawing.Point(6, 250)
        Me.ckLabelEnable.Name = "ckLabelEnable"
        Me.ckLabelEnable.Size = New System.Drawing.Size(109, 17)
        Me.ckLabelEnable.TabIndex = 141
        Me.ckLabelEnable.Text = "Axis Label Enable"
        Me.ckLabelEnable.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ckLabelEnable.UseVisualStyleBackColor = True
        '
        'ckLegendEnable
        '
        Me.ckLegendEnable.AutoSize = True
        Me.ckLegendEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckLegendEnable.Checked = True
        Me.ckLegendEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckLegendEnable.Location = New System.Drawing.Point(6, 193)
        Me.ckLegendEnable.Name = "ckLegendEnable"
        Me.ckLegendEnable.Size = New System.Drawing.Size(96, 17)
        Me.ckLegendEnable.TabIndex = 140
        Me.ckLegendEnable.Text = "Legend Enable"
        Me.ckLegendEnable.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ckLegendEnable.UseVisualStyleBackColor = True
        '
        'lbl_LegendColor
        '
        Me.lbl_LegendColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_LegendColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LegendColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_LegendColor.Location = New System.Drawing.Point(136, 158)
        Me.lbl_LegendColor.Name = "lbl_LegendColor"
        Me.lbl_LegendColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_LegendColor.TabIndex = 139
        '
        'lblLegendColor
        '
        Me.lblLegendColor.AutoSize = True
        Me.lblLegendColor.Location = New System.Drawing.Point(6, 163)
        Me.lblLegendColor.Name = "lblLegendColor"
        Me.lblLegendColor.Size = New System.Drawing.Size(77, 13)
        Me.lblLegendColor.TabIndex = 138
        Me.lblLegendColor.Text = "Legend Color :"
        '
        'RBtnValue
        '
        Me.RBtnValue.AutoSize = True
        Me.RBtnValue.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RBtnValue.Checked = True
        Me.RBtnValue.Location = New System.Drawing.Point(201, 309)
        Me.RBtnValue.Name = "RBtnValue"
        Me.RBtnValue.Size = New System.Drawing.Size(51, 17)
        Me.RBtnValue.TabIndex = 137
        Me.RBtnValue.TabStop = True
        Me.RBtnValue.Text = "Value"
        Me.RBtnValue.UseVisualStyleBackColor = True
        '
        'Rbtntime
        '
        Me.Rbtntime.AutoSize = True
        Me.Rbtntime.Location = New System.Drawing.Point(132, 309)
        Me.Rbtntime.Name = "Rbtntime"
        Me.Rbtntime.Size = New System.Drawing.Size(47, 17)
        Me.Rbtntime.TabIndex = 136
        Me.Rbtntime.Text = "Time"
        Me.Rbtntime.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 313)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "X - Axis ScaleType"
        '
        'lbl_ChartBackColor
        '
        Me.lbl_ChartBackColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_ChartBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ChartBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_ChartBackColor.Location = New System.Drawing.Point(136, 129)
        Me.lbl_ChartBackColor.Name = "lbl_ChartBackColor"
        Me.lbl_ChartBackColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_ChartBackColor.TabIndex = 134
        '
        'lblChartBackColor
        '
        Me.lblChartBackColor.AutoSize = True
        Me.lblChartBackColor.Location = New System.Drawing.Point(6, 130)
        Me.lblChartBackColor.Name = "lblChartBackColor"
        Me.lblChartBackColor.Size = New System.Drawing.Size(94, 13)
        Me.lblChartBackColor.TabIndex = 133
        Me.lblChartBackColor.Text = "Chart Back Color :"
        '
        'grpBoxYScalling
        '
        Me.grpBoxYScalling.Controls.Add(Me.ckYAutoScale)
        Me.grpBoxYScalling.Controls.Add(Me.txtYTo)
        Me.grpBoxYScalling.Controls.Add(Me.txtYFrom)
        Me.grpBoxYScalling.Controls.Add(Me.lblYTo)
        Me.grpBoxYScalling.Controls.Add(Me.lblYFrom)
        Me.grpBoxYScalling.Location = New System.Drawing.Point(471, 288)
        Me.grpBoxYScalling.Name = "grpBoxYScalling"
        Me.grpBoxYScalling.Size = New System.Drawing.Size(322, 49)
        Me.grpBoxYScalling.TabIndex = 131
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
        Me.ckYAutoScale.Size = New System.Drawing.Size(77, 17)
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
        Me.lblYTo.Size = New System.Drawing.Size(24, 13)
        Me.lblYTo.TabIndex = 86
        Me.lblYTo.Text = "to :"
        '
        'lblYFrom
        '
        Me.lblYFrom.AutoSize = True
        Me.lblYFrom.Location = New System.Drawing.Point(111, 18)
        Me.lblYFrom.Name = "lblYFrom"
        Me.lblYFrom.Size = New System.Drawing.Size(38, 13)
        Me.lblYFrom.TabIndex = 84
        Me.lblYFrom.Text = "From :"
        '
        'lbl_xytitleColor
        '
        Me.lbl_xytitleColor.BackColor = System.Drawing.Color.Black
        Me.lbl_xytitleColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_xytitleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_xytitleColor.Location = New System.Drawing.Point(136, 98)
        Me.lbl_xytitleColor.Name = "lbl_xytitleColor"
        Me.lbl_xytitleColor.Size = New System.Drawing.Size(59, 18)
        Me.lbl_xytitleColor.TabIndex = 130
        '
        'lblxytitleColor
        '
        Me.lblxytitleColor.AutoSize = True
        Me.lblxytitleColor.Location = New System.Drawing.Point(6, 99)
        Me.lblxytitleColor.Name = "lblxytitleColor"
        Me.lblxytitleColor.Size = New System.Drawing.Size(90, 13)
        Me.lblxytitleColor.TabIndex = 129
        Me.lblxytitleColor.Text = "X && Y Title Color :"
        '
        'lblYAxisTitle
        '
        Me.lblYAxisTitle.AutoSize = True
        Me.lblYAxisTitle.Location = New System.Drawing.Point(6, 71)
        Me.lblYAxisTitle.Name = "lblYAxisTitle"
        Me.lblYAxisTitle.Size = New System.Drawing.Size(66, 13)
        Me.lblYAxisTitle.TabIndex = 128
        Me.lblYAxisTitle.Text = "Y Axis Title :"
        '
        'txtYAxisTitle
        '
        Me.txtYAxisTitle.Location = New System.Drawing.Point(136, 68)
        Me.txtYAxisTitle.Name = "txtYAxisTitle"
        Me.txtYAxisTitle.Size = New System.Drawing.Size(120, 21)
        Me.txtYAxisTitle.TabIndex = 127
        '
        'lblXAxisTitle
        '
        Me.lblXAxisTitle.AutoSize = True
        Me.lblXAxisTitle.Location = New System.Drawing.Point(6, 39)
        Me.lblXAxisTitle.Name = "lblXAxisTitle"
        Me.lblXAxisTitle.Size = New System.Drawing.Size(66, 13)
        Me.lblXAxisTitle.TabIndex = 126
        Me.lblXAxisTitle.Text = "X Axis Title :"
        '
        'txtXAxisTitle
        '
        Me.txtXAxisTitle.Location = New System.Drawing.Point(136, 35)
        Me.txtXAxisTitle.Name = "txtXAxisTitle"
        Me.txtXAxisTitle.Size = New System.Drawing.Size(120, 21)
        Me.txtXAxisTitle.TabIndex = 125
        '
        'lblTitleFont
        '
        Me.lblTitleFont.AutoSize = True
        Me.lblTitleFont.Location = New System.Drawing.Point(439, 14)
        Me.lblTitleFont.Name = "lblTitleFont"
        Me.lblTitleFont.Size = New System.Drawing.Size(59, 13)
        Me.lblTitleFont.TabIndex = 108
        Me.lblTitleFont.Text = "Title Font :"
        '
        'txtTitleFont
        '
        Me.txtTitleFont.Location = New System.Drawing.Point(512, 10)
        Me.txtTitleFont.Name = "txtTitleFont"
        Me.txtTitleFont.Size = New System.Drawing.Size(190, 21)
        Me.txtTitleFont.TabIndex = 107
        '
        'btnTitleFont
        '
        Me.btnTitleFont.Location = New System.Drawing.Point(708, 9)
        Me.btnTitleFont.Name = "btnTitleFont"
        Me.btnTitleFont.Size = New System.Drawing.Size(49, 21)
        Me.btnTitleFont.TabIndex = 106
        Me.btnTitleFont.Text = "Font..."
        Me.btnTitleFont.UseVisualStyleBackColor = True
        '
        'TxtTitle
        '
        Me.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TxtTitle.Location = New System.Drawing.Point(138, 9)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(269, 21)
        Me.TxtTitle.TabIndex = 26
        Me.TxtTitle.Text = "Title"
        '
        'lblChartTitleName
        '
        Me.lblChartTitleName.AutoSize = True
        Me.lblChartTitleName.Location = New System.Drawing.Point(13, 11)
        Me.lblChartTitleName.Name = "lblChartTitleName"
        Me.lblChartTitleName.Size = New System.Drawing.Size(59, 13)
        Me.lblChartTitleName.TabIndex = 25
        Me.lblChartTitleName.Text = "Main Title :"
        '
        'tabPage2_Series1
        '
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblColorSeries)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblSeriescolor)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_cBoxChannelY2Value)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblY2ActionChannel)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_llblInfo)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_cboxMarkerValue)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblMarkerSize)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblColorMarker)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblMarkercolor)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_cBoxMarkerStyle)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblMarkerStyle)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_cBoxViewType)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblViewType)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_txtSeriesName)
        Me.tabPage2_Series1.Controls.Add(Me.Ser1_lblSeriesName)
        Me.tabPage2_Series1.Name = "tabPage2_Series1"
        Me.tabPage2_Series1.Size = New System.Drawing.Size(868, 386)
        Me.tabPage2_Series1.Text = "Series 1"
        '
        'Ser1_lblColorSeries
        '
        Me.Ser1_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser1_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser1_lblColorSeries.Location = New System.Drawing.Point(146, 99)
        Me.Ser1_lblColorSeries.Name = "Ser1_lblColorSeries"
        Me.Ser1_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser1_lblColorSeries.TabIndex = 135
        '
        'Ser1_lblSeriescolor
        '
        Me.Ser1_lblSeriescolor.AutoSize = True
        Me.Ser1_lblSeriescolor.Location = New System.Drawing.Point(23, 99)
        Me.Ser1_lblSeriescolor.Name = "Ser1_lblSeriescolor"
        Me.Ser1_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser1_lblSeriescolor.TabIndex = 134
        Me.Ser1_lblSeriescolor.Text = "Series Color"
        '
        'Ser1_cBoxChannelY2Value
        '
        Me.Ser1_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser1_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser1_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser1_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser1_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser1_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser1_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser1_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser1_cBoxChannelY2Value.Name = "Ser1_cBoxChannelY2Value"
        Me.Ser1_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser1_cBoxChannelY2Value.TabIndex = 131
        '
        'Ser1_lblY2ActionChannel
        '
        Me.Ser1_lblY2ActionChannel.AutoSize = True
        Me.Ser1_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser1_lblY2ActionChannel.Name = "Ser1_lblY2ActionChannel"
        Me.Ser1_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser1_lblY2ActionChannel.TabIndex = 129
        Me.Ser1_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser1_llblInfo
        '
        Me.Ser1_llblInfo.AutoSize = True
        Me.Ser1_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser1_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser1_llblInfo.Location = New System.Drawing.Point(316, 135)
        Me.Ser1_llblInfo.Name = "Ser1_llblInfo"
        Me.Ser1_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser1_llblInfo.TabIndex = 127
        Me.Ser1_llblInfo.TabStop = True
        Me.Ser1_llblInfo.Text = "*Info"
        Me.Ser1_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser1_cboxMarkerValue
        '
        Me.Ser1_cboxMarkerValue.FormattingEnabled = True
        Me.Ser1_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser1_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser1_cboxMarkerValue.Name = "Ser1_cboxMarkerValue"
        Me.Ser1_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser1_cboxMarkerValue.TabIndex = 92
        Me.Ser1_cboxMarkerValue.Text = "3"
        '
        'Ser1_lblMarkerSize
        '
        Me.Ser1_lblMarkerSize.AutoSize = True
        Me.Ser1_lblMarkerSize.Location = New System.Drawing.Point(21, 207)
        Me.Ser1_lblMarkerSize.Name = "Ser1_lblMarkerSize"
        Me.Ser1_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser1_lblMarkerSize.TabIndex = 91
        Me.Ser1_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser1_lblColorMarker
        '
        Me.Ser1_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser1_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser1_lblColorMarker.Location = New System.Drawing.Point(144, 241)
        Me.Ser1_lblColorMarker.Name = "Ser1_lblColorMarker"
        Me.Ser1_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser1_lblColorMarker.TabIndex = 90
        '
        'Ser1_lblMarkercolor
        '
        Me.Ser1_lblMarkercolor.AutoSize = True
        Me.Ser1_lblMarkercolor.Location = New System.Drawing.Point(19, 242)
        Me.Ser1_lblMarkercolor.Name = "Ser1_lblMarkercolor"
        Me.Ser1_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser1_lblMarkercolor.TabIndex = 89
        Me.Ser1_lblMarkercolor.Text = "Marker Color"
        '
        'Ser1_cBoxMarkerStyle
        '
        Me.Ser1_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser1_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser1_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser1_cBoxMarkerStyle.Name = "Ser1_cBoxMarkerStyle"
        Me.Ser1_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser1_cBoxMarkerStyle.TabIndex = 88
        Me.Ser1_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser1_lblMarkerStyle
        '
        Me.Ser1_lblMarkerStyle.AutoSize = True
        Me.Ser1_lblMarkerStyle.Location = New System.Drawing.Point(21, 170)
        Me.Ser1_lblMarkerStyle.Name = "Ser1_lblMarkerStyle"
        Me.Ser1_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser1_lblMarkerStyle.TabIndex = 87
        Me.Ser1_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser1_cBoxViewType
        '
        Me.Ser1_cBoxViewType.FormattingEnabled = True
        Me.Ser1_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser1_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser1_cBoxViewType.Name = "Ser1_cBoxViewType"
        Me.Ser1_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser1_cBoxViewType.TabIndex = 86
        Me.Ser1_cBoxViewType.Text = "Line"
        '
        'Ser1_lblViewType
        '
        Me.Ser1_lblViewType.AutoSize = True
        Me.Ser1_lblViewType.Location = New System.Drawing.Point(21, 135)
        Me.Ser1_lblViewType.Name = "Ser1_lblViewType"
        Me.Ser1_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser1_lblViewType.TabIndex = 85
        Me.Ser1_lblViewType.Text = "View Type :"
        '
        'Ser1_txtSeriesName
        '
        Me.Ser1_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser1_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser1_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser1_txtSeriesName.Location = New System.Drawing.Point(146, 61)
        Me.Ser1_txtSeriesName.Name = "Ser1_txtSeriesName"
        Me.Ser1_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser1_txtSeriesName.TabIndex = 28
        Me.Ser1_txtSeriesName.Text = "Series 1"
        '
        'Ser1_lblSeriesName
        '
        Me.Ser1_lblSeriesName.AutoSize = True
        Me.Ser1_lblSeriesName.Location = New System.Drawing.Point(21, 63)
        Me.Ser1_lblSeriesName.Name = "Ser1_lblSeriesName"
        Me.Ser1_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser1_lblSeriesName.TabIndex = 27
        Me.Ser1_lblSeriesName.Text = "Series Name :"
        '
        'tabPage3_Series2
        '
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblColorSeries)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblSeriescolor)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_cBoxChannelY2Value)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblY2ActionChannel)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_llblInfo)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_cboxMarkerValue)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblMarkerSize)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblColorMarker)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblMarkercolor)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_cBoxMarkerStyle)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblMarkerStyle)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_cBoxViewType)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblViewType)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_txtSeriesName)
        Me.tabPage3_Series2.Controls.Add(Me.Ser2_lblSeriesName)
        Me.tabPage3_Series2.Name = "tabPage3_Series2"
        Me.tabPage3_Series2.Size = New System.Drawing.Size(868, 386)
        Me.tabPage3_Series2.Text = "Series 2"
        '
        'Ser2_lblColorSeries
        '
        Me.Ser2_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser2_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser2_lblColorSeries.Location = New System.Drawing.Point(146, 99)
        Me.Ser2_lblColorSeries.Name = "Ser2_lblColorSeries"
        Me.Ser2_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser2_lblColorSeries.TabIndex = 150
        '
        'Ser2_lblSeriescolor
        '
        Me.Ser2_lblSeriescolor.AutoSize = True
        Me.Ser2_lblSeriescolor.Location = New System.Drawing.Point(23, 99)
        Me.Ser2_lblSeriescolor.Name = "Ser2_lblSeriescolor"
        Me.Ser2_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser2_lblSeriescolor.TabIndex = 149
        Me.Ser2_lblSeriescolor.Text = "Series Color"
        '
        'Ser2_cBoxChannelY2Value
        '
        Me.Ser2_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser2_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser2_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser2_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser2_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser2_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser2_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser2_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser2_cBoxChannelY2Value.Name = "Ser2_cBoxChannelY2Value"
        Me.Ser2_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser2_cBoxChannelY2Value.TabIndex = 148
        '
        'Ser2_lblY2ActionChannel
        '
        Me.Ser2_lblY2ActionChannel.AutoSize = True
        Me.Ser2_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser2_lblY2ActionChannel.Name = "Ser2_lblY2ActionChannel"
        Me.Ser2_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser2_lblY2ActionChannel.TabIndex = 146
        Me.Ser2_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser2_llblInfo
        '
        Me.Ser2_llblInfo.AutoSize = True
        Me.Ser2_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser2_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser2_llblInfo.Location = New System.Drawing.Point(305, 133)
        Me.Ser2_llblInfo.Name = "Ser2_llblInfo"
        Me.Ser2_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser2_llblInfo.TabIndex = 144
        Me.Ser2_llblInfo.TabStop = True
        Me.Ser2_llblInfo.Text = "*Info"
        Me.Ser2_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser2_cboxMarkerValue
        '
        Me.Ser2_cboxMarkerValue.FormattingEnabled = True
        Me.Ser2_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser2_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser2_cboxMarkerValue.Name = "Ser2_cboxMarkerValue"
        Me.Ser2_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser2_cboxMarkerValue.TabIndex = 143
        Me.Ser2_cboxMarkerValue.Text = "3"
        '
        'Ser2_lblMarkerSize
        '
        Me.Ser2_lblMarkerSize.AutoSize = True
        Me.Ser2_lblMarkerSize.Location = New System.Drawing.Point(21, 207)
        Me.Ser2_lblMarkerSize.Name = "Ser2_lblMarkerSize"
        Me.Ser2_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser2_lblMarkerSize.TabIndex = 142
        Me.Ser2_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser2_lblColorMarker
        '
        Me.Ser2_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser2_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser2_lblColorMarker.Location = New System.Drawing.Point(146, 246)
        Me.Ser2_lblColorMarker.Name = "Ser2_lblColorMarker"
        Me.Ser2_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser2_lblColorMarker.TabIndex = 141
        '
        'Ser2_lblMarkercolor
        '
        Me.Ser2_lblMarkercolor.AutoSize = True
        Me.Ser2_lblMarkercolor.Location = New System.Drawing.Point(21, 247)
        Me.Ser2_lblMarkercolor.Name = "Ser2_lblMarkercolor"
        Me.Ser2_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser2_lblMarkercolor.TabIndex = 140
        Me.Ser2_lblMarkercolor.Text = "Marker Color"
        '
        'Ser2_cBoxMarkerStyle
        '
        Me.Ser2_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser2_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser2_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser2_cBoxMarkerStyle.Name = "Ser2_cBoxMarkerStyle"
        Me.Ser2_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser2_cBoxMarkerStyle.TabIndex = 139
        Me.Ser2_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser2_lblMarkerStyle
        '
        Me.Ser2_lblMarkerStyle.AutoSize = True
        Me.Ser2_lblMarkerStyle.Location = New System.Drawing.Point(21, 170)
        Me.Ser2_lblMarkerStyle.Name = "Ser2_lblMarkerStyle"
        Me.Ser2_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser2_lblMarkerStyle.TabIndex = 138
        Me.Ser2_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser2_cBoxViewType
        '
        Me.Ser2_cBoxViewType.FormattingEnabled = True
        Me.Ser2_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser2_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser2_cBoxViewType.Name = "Ser2_cBoxViewType"
        Me.Ser2_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser2_cBoxViewType.TabIndex = 137
        Me.Ser2_cBoxViewType.Text = "Line"
        '
        'Ser2_lblViewType
        '
        Me.Ser2_lblViewType.AutoSize = True
        Me.Ser2_lblViewType.Location = New System.Drawing.Point(21, 135)
        Me.Ser2_lblViewType.Name = "Ser2_lblViewType"
        Me.Ser2_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser2_lblViewType.TabIndex = 136
        Me.Ser2_lblViewType.Text = "View Type :"
        '
        'Ser2_txtSeriesName
        '
        Me.Ser2_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser2_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser2_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser2_txtSeriesName.Location = New System.Drawing.Point(146, 58)
        Me.Ser2_txtSeriesName.Name = "Ser2_txtSeriesName"
        Me.Ser2_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser2_txtSeriesName.TabIndex = 133
        Me.Ser2_txtSeriesName.Text = "Series 2"
        '
        'Ser2_lblSeriesName
        '
        Me.Ser2_lblSeriesName.AutoSize = True
        Me.Ser2_lblSeriesName.Location = New System.Drawing.Point(21, 60)
        Me.Ser2_lblSeriesName.Name = "Ser2_lblSeriesName"
        Me.Ser2_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser2_lblSeriesName.TabIndex = 132
        Me.Ser2_lblSeriesName.Text = "Series Name :"
        '
        'tabPage4_Series3
        '
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_llblInfo)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblColorSeries)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblSeriescolor)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_cBoxChannelY2Value)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblY2ActionChannel)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_cboxMarkerValue)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblMarkerSize)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblColorMarker)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblMarkercolor)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_cBoxMarkerStyle)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblMarkerStyle)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_cBoxViewType)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblViewType)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_txtSeriesName)
        Me.tabPage4_Series3.Controls.Add(Me.Ser3_lblSeriesName)
        Me.tabPage4_Series3.Name = "tabPage4_Series3"
        Me.tabPage4_Series3.Size = New System.Drawing.Size(868, 386)
        Me.tabPage4_Series3.Text = "Series 3"
        '
        'Ser3_llblInfo
        '
        Me.Ser3_llblInfo.AutoSize = True
        Me.Ser3_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser3_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser3_llblInfo.Location = New System.Drawing.Point(312, 132)
        Me.Ser3_llblInfo.Name = "Ser3_llblInfo"
        Me.Ser3_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser3_llblInfo.TabIndex = 167
        Me.Ser3_llblInfo.TabStop = True
        Me.Ser3_llblInfo.Text = "*Info"
        Me.Ser3_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser3_lblColorSeries
        '
        Me.Ser3_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser3_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser3_lblColorSeries.Location = New System.Drawing.Point(147, 97)
        Me.Ser3_lblColorSeries.Name = "Ser3_lblColorSeries"
        Me.Ser3_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser3_lblColorSeries.TabIndex = 166
        '
        'Ser3_lblSeriescolor
        '
        Me.Ser3_lblSeriescolor.AutoSize = True
        Me.Ser3_lblSeriescolor.Location = New System.Drawing.Point(24, 97)
        Me.Ser3_lblSeriescolor.Name = "Ser3_lblSeriescolor"
        Me.Ser3_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser3_lblSeriescolor.TabIndex = 165
        Me.Ser3_lblSeriescolor.Text = "Series Color"
        '
        'Ser3_cBoxChannelY2Value
        '
        Me.Ser3_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser3_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser3_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser3_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser3_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser3_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser3_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser3_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser3_cBoxChannelY2Value.Name = "Ser3_cBoxChannelY2Value"
        Me.Ser3_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser3_cBoxChannelY2Value.TabIndex = 164
        '
        'Ser3_lblY2ActionChannel
        '
        Me.Ser3_lblY2ActionChannel.AutoSize = True
        Me.Ser3_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser3_lblY2ActionChannel.Name = "Ser3_lblY2ActionChannel"
        Me.Ser3_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser3_lblY2ActionChannel.TabIndex = 162
        Me.Ser3_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser3_cboxMarkerValue
        '
        Me.Ser3_cboxMarkerValue.FormattingEnabled = True
        Me.Ser3_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser3_cboxMarkerValue.Location = New System.Drawing.Point(147, 205)
        Me.Ser3_cboxMarkerValue.Name = "Ser3_cboxMarkerValue"
        Me.Ser3_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser3_cboxMarkerValue.TabIndex = 160
        Me.Ser3_cboxMarkerValue.Text = "3"
        '
        'Ser3_lblMarkerSize
        '
        Me.Ser3_lblMarkerSize.AutoSize = True
        Me.Ser3_lblMarkerSize.Location = New System.Drawing.Point(22, 207)
        Me.Ser3_lblMarkerSize.Name = "Ser3_lblMarkerSize"
        Me.Ser3_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser3_lblMarkerSize.TabIndex = 159
        Me.Ser3_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser3_lblColorMarker
        '
        Me.Ser3_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser3_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser3_lblColorMarker.Location = New System.Drawing.Point(147, 241)
        Me.Ser3_lblColorMarker.Name = "Ser3_lblColorMarker"
        Me.Ser3_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser3_lblColorMarker.TabIndex = 158
        '
        'Ser3_lblMarkercolor
        '
        Me.Ser3_lblMarkercolor.AutoSize = True
        Me.Ser3_lblMarkercolor.Location = New System.Drawing.Point(22, 242)
        Me.Ser3_lblMarkercolor.Name = "Ser3_lblMarkercolor"
        Me.Ser3_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser3_lblMarkercolor.TabIndex = 157
        Me.Ser3_lblMarkercolor.Text = "Marker Color"
        '
        'Ser3_cBoxMarkerStyle
        '
        Me.Ser3_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser3_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser3_cBoxMarkerStyle.Location = New System.Drawing.Point(147, 167)
        Me.Ser3_cBoxMarkerStyle.Name = "Ser3_cBoxMarkerStyle"
        Me.Ser3_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser3_cBoxMarkerStyle.TabIndex = 156
        Me.Ser3_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser3_lblMarkerStyle
        '
        Me.Ser3_lblMarkerStyle.AutoSize = True
        Me.Ser3_lblMarkerStyle.Location = New System.Drawing.Point(22, 170)
        Me.Ser3_lblMarkerStyle.Name = "Ser3_lblMarkerStyle"
        Me.Ser3_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser3_lblMarkerStyle.TabIndex = 155
        Me.Ser3_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser3_cBoxViewType
        '
        Me.Ser3_cBoxViewType.FormattingEnabled = True
        Me.Ser3_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser3_cBoxViewType.Location = New System.Drawing.Point(147, 132)
        Me.Ser3_cBoxViewType.Name = "Ser3_cBoxViewType"
        Me.Ser3_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser3_cBoxViewType.TabIndex = 154
        Me.Ser3_cBoxViewType.Text = "Line"
        '
        'Ser3_lblViewType
        '
        Me.Ser3_lblViewType.AutoSize = True
        Me.Ser3_lblViewType.Location = New System.Drawing.Point(22, 135)
        Me.Ser3_lblViewType.Name = "Ser3_lblViewType"
        Me.Ser3_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser3_lblViewType.TabIndex = 153
        Me.Ser3_lblViewType.Text = "View Type :"
        '
        'Ser3_txtSeriesName
        '
        Me.Ser3_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser3_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser3_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser3_txtSeriesName.Location = New System.Drawing.Point(147, 62)
        Me.Ser3_txtSeriesName.Name = "Ser3_txtSeriesName"
        Me.Ser3_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser3_txtSeriesName.TabIndex = 150
        Me.Ser3_txtSeriesName.Text = "Series 3"
        '
        'Ser3_lblSeriesName
        '
        Me.Ser3_lblSeriesName.AutoSize = True
        Me.Ser3_lblSeriesName.Location = New System.Drawing.Point(22, 64)
        Me.Ser3_lblSeriesName.Name = "Ser3_lblSeriesName"
        Me.Ser3_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser3_lblSeriesName.TabIndex = 149
        Me.Ser3_lblSeriesName.Text = "Series Name :"
        '
        'tabPage5_Series4
        '
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_llblInfo)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblColorSeries)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblSeriescolor)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_cBoxChannelY2Value)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblY2ActionChannel)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_cboxMarkerValue)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblMarkerSize)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblColorMarker)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblMarkercolor)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_CboxMarkerStyle)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblMarkerStyle)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_cBoxViewType)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblViewType)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_txtSeriesName)
        Me.tabPage5_Series4.Controls.Add(Me.Ser4_lblSeriesName)
        Me.tabPage5_Series4.Name = "tabPage5_Series4"
        Me.tabPage5_Series4.Size = New System.Drawing.Size(868, 386)
        Me.tabPage5_Series4.Text = "Series 4"
        '
        'Ser4_llblInfo
        '
        Me.Ser4_llblInfo.AutoSize = True
        Me.Ser4_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser4_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser4_llblInfo.Location = New System.Drawing.Point(309, 135)
        Me.Ser4_llblInfo.Name = "Ser4_llblInfo"
        Me.Ser4_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser4_llblInfo.TabIndex = 185
        Me.Ser4_llblInfo.TabStop = True
        Me.Ser4_llblInfo.Text = "*Info"
        Me.Ser4_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser4_lblColorSeries
        '
        Me.Ser4_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser4_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser4_lblColorSeries.Location = New System.Drawing.Point(146, 98)
        Me.Ser4_lblColorSeries.Name = "Ser4_lblColorSeries"
        Me.Ser4_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser4_lblColorSeries.TabIndex = 184
        '
        'Ser4_lblSeriescolor
        '
        Me.Ser4_lblSeriescolor.AutoSize = True
        Me.Ser4_lblSeriescolor.Location = New System.Drawing.Point(23, 98)
        Me.Ser4_lblSeriescolor.Name = "Ser4_lblSeriescolor"
        Me.Ser4_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser4_lblSeriescolor.TabIndex = 183
        Me.Ser4_lblSeriescolor.Text = "Series Color"
        '
        'Ser4_cBoxChannelY2Value
        '
        Me.Ser4_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser4_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser4_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser4_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser4_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser4_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser4_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser4_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser4_cBoxChannelY2Value.Name = "Ser4_cBoxChannelY2Value"
        Me.Ser4_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser4_cBoxChannelY2Value.TabIndex = 180
        '
        'Ser4_lblY2ActionChannel
        '
        Me.Ser4_lblY2ActionChannel.AutoSize = True
        Me.Ser4_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser4_lblY2ActionChannel.Name = "Ser4_lblY2ActionChannel"
        Me.Ser4_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser4_lblY2ActionChannel.TabIndex = 178
        Me.Ser4_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser4_cboxMarkerValue
        '
        Me.Ser4_cboxMarkerValue.FormattingEnabled = True
        Me.Ser4_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser4_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser4_cboxMarkerValue.Name = "Ser4_cboxMarkerValue"
        Me.Ser4_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser4_cboxMarkerValue.TabIndex = 176
        Me.Ser4_cboxMarkerValue.Text = "3"
        '
        'Ser4_lblMarkerSize
        '
        Me.Ser4_lblMarkerSize.AutoSize = True
        Me.Ser4_lblMarkerSize.Location = New System.Drawing.Point(21, 207)
        Me.Ser4_lblMarkerSize.Name = "Ser4_lblMarkerSize"
        Me.Ser4_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser4_lblMarkerSize.TabIndex = 175
        Me.Ser4_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser4_lblColorMarker
        '
        Me.Ser4_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser4_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser4_lblColorMarker.Location = New System.Drawing.Point(146, 241)
        Me.Ser4_lblColorMarker.Name = "Ser4_lblColorMarker"
        Me.Ser4_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser4_lblColorMarker.TabIndex = 174
        '
        'Ser4_lblMarkercolor
        '
        Me.Ser4_lblMarkercolor.AutoSize = True
        Me.Ser4_lblMarkercolor.Location = New System.Drawing.Point(21, 242)
        Me.Ser4_lblMarkercolor.Name = "Ser4_lblMarkercolor"
        Me.Ser4_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser4_lblMarkercolor.TabIndex = 173
        Me.Ser4_lblMarkercolor.Text = "Marker Color"
        '
        'Ser4_CboxMarkerStyle
        '
        Me.Ser4_CboxMarkerStyle.FormattingEnabled = True
        Me.Ser4_CboxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser4_CboxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser4_CboxMarkerStyle.Name = "Ser4_CboxMarkerStyle"
        Me.Ser4_CboxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser4_CboxMarkerStyle.TabIndex = 172
        Me.Ser4_CboxMarkerStyle.Text = "Circle"
        '
        'Ser4_lblMarkerStyle
        '
        Me.Ser4_lblMarkerStyle.AutoSize = True
        Me.Ser4_lblMarkerStyle.Location = New System.Drawing.Point(21, 170)
        Me.Ser4_lblMarkerStyle.Name = "Ser4_lblMarkerStyle"
        Me.Ser4_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser4_lblMarkerStyle.TabIndex = 171
        Me.Ser4_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser4_cBoxViewType
        '
        Me.Ser4_cBoxViewType.FormattingEnabled = True
        Me.Ser4_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser4_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser4_cBoxViewType.Name = "Ser4_cBoxViewType"
        Me.Ser4_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser4_cBoxViewType.TabIndex = 170
        Me.Ser4_cBoxViewType.Text = "Line"
        '
        'Ser4_lblViewType
        '
        Me.Ser4_lblViewType.AutoSize = True
        Me.Ser4_lblViewType.Location = New System.Drawing.Point(21, 135)
        Me.Ser4_lblViewType.Name = "Ser4_lblViewType"
        Me.Ser4_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser4_lblViewType.TabIndex = 169
        Me.Ser4_lblViewType.Text = "View Type :"
        '
        'Ser4_txtSeriesName
        '
        Me.Ser4_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser4_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser4_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser4_txtSeriesName.Location = New System.Drawing.Point(146, 62)
        Me.Ser4_txtSeriesName.Name = "Ser4_txtSeriesName"
        Me.Ser4_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser4_txtSeriesName.TabIndex = 166
        Me.Ser4_txtSeriesName.Text = "Series 4"
        '
        'Ser4_lblSeriesName
        '
        Me.Ser4_lblSeriesName.AutoSize = True
        Me.Ser4_lblSeriesName.Location = New System.Drawing.Point(21, 64)
        Me.Ser4_lblSeriesName.Name = "Ser4_lblSeriesName"
        Me.Ser4_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser4_lblSeriesName.TabIndex = 165
        Me.Ser4_lblSeriesName.Text = "Series Name :"
        '
        'tabPage6_Series5
        '
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_llblInfo)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_lblColorSeries)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_lblSeriescolor)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_cBoxChannelY2Value)
        Me.tabPage6_Series5.Controls.Add(Me.lblY2ActionChannel)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_cboxMarkerValue)
        Me.tabPage6_Series5.Controls.Add(Me.lblMarkerSize5)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_lblColorMarker)
        Me.tabPage6_Series5.Controls.Add(Me.lblMarkercolor5)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_cBoxMarkerStyle)
        Me.tabPage6_Series5.Controls.Add(Me.lblMarkerStyle5)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_cBoxViewType)
        Me.tabPage6_Series5.Controls.Add(Me.lblViewType5)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_txtSeriesName)
        Me.tabPage6_Series5.Controls.Add(Me.Ser5_lblSeriesName)
        Me.tabPage6_Series5.Name = "tabPage6_Series5"
        Me.tabPage6_Series5.Size = New System.Drawing.Size(868, 386)
        Me.tabPage6_Series5.Text = "Series 5"
        '
        'Ser5_llblInfo
        '
        Me.Ser5_llblInfo.AutoSize = True
        Me.Ser5_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser5_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser5_llblInfo.Location = New System.Drawing.Point(310, 135)
        Me.Ser5_llblInfo.Name = "Ser5_llblInfo"
        Me.Ser5_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser5_llblInfo.TabIndex = 199
        Me.Ser5_llblInfo.TabStop = True
        Me.Ser5_llblInfo.Text = "*Info"
        Me.Ser5_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser5_lblColorSeries
        '
        Me.Ser5_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser5_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser5_lblColorSeries.Location = New System.Drawing.Point(146, 100)
        Me.Ser5_lblColorSeries.Name = "Ser5_lblColorSeries"
        Me.Ser5_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser5_lblColorSeries.TabIndex = 198
        '
        'Ser5_lblSeriescolor
        '
        Me.Ser5_lblSeriescolor.AutoSize = True
        Me.Ser5_lblSeriescolor.Location = New System.Drawing.Point(23, 100)
        Me.Ser5_lblSeriescolor.Name = "Ser5_lblSeriescolor"
        Me.Ser5_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser5_lblSeriescolor.TabIndex = 197
        Me.Ser5_lblSeriescolor.Text = "Series Color"
        '
        'Ser5_cBoxChannelY2Value
        '
        Me.Ser5_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser5_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser5_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser5_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser5_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser5_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser5_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser5_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser5_cBoxChannelY2Value.Name = "Ser5_cBoxChannelY2Value"
        Me.Ser5_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser5_cBoxChannelY2Value.TabIndex = 196
        '
        'lblY2ActionChannel
        '
        Me.lblY2ActionChannel.AutoSize = True
        Me.lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.lblY2ActionChannel.Name = "lblY2ActionChannel"
        Me.lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.lblY2ActionChannel.TabIndex = 194
        Me.lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser5_cboxMarkerValue
        '
        Me.Ser5_cboxMarkerValue.FormattingEnabled = True
        Me.Ser5_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser5_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser5_cboxMarkerValue.Name = "Ser5_cboxMarkerValue"
        Me.Ser5_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser5_cboxMarkerValue.TabIndex = 192
        Me.Ser5_cboxMarkerValue.Text = "3"
        '
        'lblMarkerSize5
        '
        Me.lblMarkerSize5.AutoSize = True
        Me.lblMarkerSize5.Location = New System.Drawing.Point(21, 207)
        Me.lblMarkerSize5.Name = "lblMarkerSize5"
        Me.lblMarkerSize5.Size = New System.Drawing.Size(69, 13)
        Me.lblMarkerSize5.TabIndex = 191
        Me.lblMarkerSize5.Text = "Marker Size :"
        '
        'Ser5_lblColorMarker
        '
        Me.Ser5_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser5_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser5_lblColorMarker.Location = New System.Drawing.Point(146, 241)
        Me.Ser5_lblColorMarker.Name = "Ser5_lblColorMarker"
        Me.Ser5_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser5_lblColorMarker.TabIndex = 190
        '
        'lblMarkercolor5
        '
        Me.lblMarkercolor5.AutoSize = True
        Me.lblMarkercolor5.Location = New System.Drawing.Point(21, 242)
        Me.lblMarkercolor5.Name = "lblMarkercolor5"
        Me.lblMarkercolor5.Size = New System.Drawing.Size(68, 13)
        Me.lblMarkercolor5.TabIndex = 189
        Me.lblMarkercolor5.Text = "Marker Color"
        '
        'Ser5_cBoxMarkerStyle
        '
        Me.Ser5_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser5_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser5_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser5_cBoxMarkerStyle.Name = "Ser5_cBoxMarkerStyle"
        Me.Ser5_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser5_cBoxMarkerStyle.TabIndex = 188
        Me.Ser5_cBoxMarkerStyle.Text = "Circle"
        '
        'lblMarkerStyle5
        '
        Me.lblMarkerStyle5.AutoSize = True
        Me.lblMarkerStyle5.Location = New System.Drawing.Point(21, 170)
        Me.lblMarkerStyle5.Name = "lblMarkerStyle5"
        Me.lblMarkerStyle5.Size = New System.Drawing.Size(74, 13)
        Me.lblMarkerStyle5.TabIndex = 187
        Me.lblMarkerStyle5.Text = "Marker Style :"
        '
        'Ser5_cBoxViewType
        '
        Me.Ser5_cBoxViewType.FormattingEnabled = True
        Me.Ser5_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser5_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser5_cBoxViewType.Name = "Ser5_cBoxViewType"
        Me.Ser5_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser5_cBoxViewType.TabIndex = 186
        Me.Ser5_cBoxViewType.Text = "Line"
        '
        'lblViewType5
        '
        Me.lblViewType5.AutoSize = True
        Me.lblViewType5.Location = New System.Drawing.Point(21, 135)
        Me.lblViewType5.Name = "lblViewType5"
        Me.lblViewType5.Size = New System.Drawing.Size(63, 13)
        Me.lblViewType5.TabIndex = 185
        Me.lblViewType5.Text = "View Type :"
        '
        'Ser5_txtSeriesName
        '
        Me.Ser5_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser5_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser5_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser5_txtSeriesName.Location = New System.Drawing.Point(146, 59)
        Me.Ser5_txtSeriesName.Name = "Ser5_txtSeriesName"
        Me.Ser5_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser5_txtSeriesName.TabIndex = 182
        Me.Ser5_txtSeriesName.Text = "Series 5"
        '
        'Ser5_lblSeriesName
        '
        Me.Ser5_lblSeriesName.AutoSize = True
        Me.Ser5_lblSeriesName.Location = New System.Drawing.Point(21, 61)
        Me.Ser5_lblSeriesName.Name = "Ser5_lblSeriesName"
        Me.Ser5_lblSeriesName.Size = New System.Drawing.Size(70, 13)
        Me.Ser5_lblSeriesName.TabIndex = 181
        Me.Ser5_lblSeriesName.Text = "Series Name:"
        '
        'tabPage7_Series6
        '
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_llblInfo)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblColorSeries)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblSeriescolor)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_cBoxChannelY2Value)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblY2ActionChannel)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_cboxMarkerValue)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblMarkerSize)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblColorMarker)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblMarkercolor)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_cBoxMarkerStyle)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblMarkerStyle)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_cBoxViewType)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblViewType)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_txtSeriesName)
        Me.tabPage7_Series6.Controls.Add(Me.Ser6_lblSeriesName)
        Me.tabPage7_Series6.Name = "tabPage7_Series6"
        Me.tabPage7_Series6.Size = New System.Drawing.Size(868, 386)
        Me.tabPage7_Series6.Text = "Series 6"
        '
        'Ser6_llblInfo
        '
        Me.Ser6_llblInfo.AutoSize = True
        Me.Ser6_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser6_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser6_llblInfo.Location = New System.Drawing.Point(312, 134)
        Me.Ser6_llblInfo.Name = "Ser6_llblInfo"
        Me.Ser6_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser6_llblInfo.TabIndex = 215
        Me.Ser6_llblInfo.TabStop = True
        Me.Ser6_llblInfo.Text = "*Info"
        Me.Ser6_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser6_lblColorSeries
        '
        Me.Ser6_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser6_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser6_lblColorSeries.Location = New System.Drawing.Point(146, 98)
        Me.Ser6_lblColorSeries.Name = "Ser6_lblColorSeries"
        Me.Ser6_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser6_lblColorSeries.TabIndex = 214
        '
        'Ser6_lblSeriescolor
        '
        Me.Ser6_lblSeriescolor.AutoSize = True
        Me.Ser6_lblSeriescolor.Location = New System.Drawing.Point(24, 98)
        Me.Ser6_lblSeriescolor.Name = "Ser6_lblSeriescolor"
        Me.Ser6_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser6_lblSeriescolor.TabIndex = 213
        Me.Ser6_lblSeriescolor.Text = "Series Color"
        '
        'Ser6_cBoxChannelY2Value
        '
        Me.Ser6_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser6_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser6_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser6_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser6_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser6_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser6_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser6_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser6_cBoxChannelY2Value.Name = "Ser6_cBoxChannelY2Value"
        Me.Ser6_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser6_cBoxChannelY2Value.TabIndex = 212
        '
        'Ser6_lblY2ActionChannel
        '
        Me.Ser6_lblY2ActionChannel.Enabled = False
        Me.Ser6_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser6_lblY2ActionChannel.Name = "Ser6_lblY2ActionChannel"
        Me.Ser6_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser6_lblY2ActionChannel.TabIndex = 210
        Me.Ser6_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser6_cboxMarkerValue
        '
        Me.Ser6_cboxMarkerValue.FormattingEnabled = True
        Me.Ser6_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser6_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser6_cboxMarkerValue.Name = "Ser6_cboxMarkerValue"
        Me.Ser6_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser6_cboxMarkerValue.TabIndex = 208
        Me.Ser6_cboxMarkerValue.Text = "3"
        '
        'Ser6_lblMarkerSize
        '
        Me.Ser6_lblMarkerSize.AutoSize = True
        Me.Ser6_lblMarkerSize.Location = New System.Drawing.Point(22, 207)
        Me.Ser6_lblMarkerSize.Name = "Ser6_lblMarkerSize"
        Me.Ser6_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser6_lblMarkerSize.TabIndex = 207
        Me.Ser6_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser6_lblColorMarker
        '
        Me.Ser6_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser6_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser6_lblColorMarker.Location = New System.Drawing.Point(146, 241)
        Me.Ser6_lblColorMarker.Name = "Ser6_lblColorMarker"
        Me.Ser6_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser6_lblColorMarker.TabIndex = 206
        '
        'Ser6_lblMarkercolor
        '
        Me.Ser6_lblMarkercolor.AutoSize = True
        Me.Ser6_lblMarkercolor.Location = New System.Drawing.Point(22, 242)
        Me.Ser6_lblMarkercolor.Name = "Ser6_lblMarkercolor"
        Me.Ser6_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser6_lblMarkercolor.TabIndex = 205
        Me.Ser6_lblMarkercolor.Text = "Marker Color"
        '
        'Ser6_cBoxMarkerStyle
        '
        Me.Ser6_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser6_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser6_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser6_cBoxMarkerStyle.Name = "Ser6_cBoxMarkerStyle"
        Me.Ser6_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser6_cBoxMarkerStyle.TabIndex = 204
        Me.Ser6_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser6_lblMarkerStyle
        '
        Me.Ser6_lblMarkerStyle.AutoSize = True
        Me.Ser6_lblMarkerStyle.Location = New System.Drawing.Point(22, 170)
        Me.Ser6_lblMarkerStyle.Name = "Ser6_lblMarkerStyle"
        Me.Ser6_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser6_lblMarkerStyle.TabIndex = 203
        Me.Ser6_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser6_cBoxViewType
        '
        Me.Ser6_cBoxViewType.FormattingEnabled = True
        Me.Ser6_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser6_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser6_cBoxViewType.Name = "Ser6_cBoxViewType"
        Me.Ser6_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser6_cBoxViewType.TabIndex = 202
        Me.Ser6_cBoxViewType.Text = "Line"
        '
        'Ser6_lblViewType
        '
        Me.Ser6_lblViewType.AutoSize = True
        Me.Ser6_lblViewType.Location = New System.Drawing.Point(22, 135)
        Me.Ser6_lblViewType.Name = "Ser6_lblViewType"
        Me.Ser6_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser6_lblViewType.TabIndex = 201
        Me.Ser6_lblViewType.Text = "View Type :"
        '
        'Ser6_txtSeriesName
        '
        Me.Ser6_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser6_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser6_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser6_txtSeriesName.Location = New System.Drawing.Point(146, 57)
        Me.Ser6_txtSeriesName.Name = "Ser6_txtSeriesName"
        Me.Ser6_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser6_txtSeriesName.TabIndex = 198
        Me.Ser6_txtSeriesName.Text = "Series 6"
        '
        'Ser6_lblSeriesName
        '
        Me.Ser6_lblSeriesName.AutoSize = True
        Me.Ser6_lblSeriesName.Location = New System.Drawing.Point(22, 62)
        Me.Ser6_lblSeriesName.Name = "Ser6_lblSeriesName"
        Me.Ser6_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser6_lblSeriesName.TabIndex = 197
        Me.Ser6_lblSeriesName.Text = "Series Name :"
        '
        'tabPage8_Series7
        '
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_llblInfo)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblColorSeries)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblSeriescolor)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_cBoxChannelY2Value)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblY2ActionChannel)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_cboxMarkerValue)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblMarkerSize)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblColorMarker)
        Me.tabPage8_Series7.Controls.Add(Me.lblMarkercolor7)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_cBoxMarkerStyle)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblMarkerStyle)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_cBoxViewType)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblViewType)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_txtSeriesName)
        Me.tabPage8_Series7.Controls.Add(Me.Ser7_lblSeriesName)
        Me.tabPage8_Series7.Name = "tabPage8_Series7"
        Me.tabPage8_Series7.Size = New System.Drawing.Size(868, 386)
        Me.tabPage8_Series7.Text = "Series 7"
        '
        'Ser7_llblInfo
        '
        Me.Ser7_llblInfo.AutoSize = True
        Me.Ser7_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser7_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser7_llblInfo.Location = New System.Drawing.Point(312, 134)
        Me.Ser7_llblInfo.Name = "Ser7_llblInfo"
        Me.Ser7_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser7_llblInfo.TabIndex = 231
        Me.Ser7_llblInfo.TabStop = True
        Me.Ser7_llblInfo.Text = "*Info"
        Me.Ser7_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser7_lblColorSeries
        '
        Me.Ser7_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser7_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser7_lblColorSeries.Location = New System.Drawing.Point(146, 100)
        Me.Ser7_lblColorSeries.Name = "Ser7_lblColorSeries"
        Me.Ser7_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser7_lblColorSeries.TabIndex = 230
        '
        'Ser7_lblSeriescolor
        '
        Me.Ser7_lblSeriescolor.AutoSize = True
        Me.Ser7_lblSeriescolor.Location = New System.Drawing.Point(24, 100)
        Me.Ser7_lblSeriescolor.Name = "Ser7_lblSeriescolor"
        Me.Ser7_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser7_lblSeriescolor.TabIndex = 229
        Me.Ser7_lblSeriescolor.Text = "Series Color"
        '
        'Ser7_cBoxChannelY2Value
        '
        Me.Ser7_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser7_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser7_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser7_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser7_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser7_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser7_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser7_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser7_cBoxChannelY2Value.Name = "Ser7_cBoxChannelY2Value"
        Me.Ser7_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser7_cBoxChannelY2Value.TabIndex = 228
        '
        'Ser7_lblY2ActionChannel
        '
        Me.Ser7_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser7_lblY2ActionChannel.Name = "Ser7_lblY2ActionChannel"
        Me.Ser7_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser7_lblY2ActionChannel.TabIndex = 226
        Me.Ser7_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser7_cboxMarkerValue
        '
        Me.Ser7_cboxMarkerValue.FormattingEnabled = True
        Me.Ser7_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser7_cboxMarkerValue.Location = New System.Drawing.Point(146, 205)
        Me.Ser7_cboxMarkerValue.Name = "Ser7_cboxMarkerValue"
        Me.Ser7_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser7_cboxMarkerValue.TabIndex = 224
        Me.Ser7_cboxMarkerValue.Text = "3"
        '
        'Ser7_lblMarkerSize
        '
        Me.Ser7_lblMarkerSize.AutoSize = True
        Me.Ser7_lblMarkerSize.Location = New System.Drawing.Point(21, 207)
        Me.Ser7_lblMarkerSize.Name = "Ser7_lblMarkerSize"
        Me.Ser7_lblMarkerSize.Size = New System.Drawing.Size(69, 13)
        Me.Ser7_lblMarkerSize.TabIndex = 223
        Me.Ser7_lblMarkerSize.Text = "Marker Size :"
        '
        'Ser7_lblColorMarker
        '
        Me.Ser7_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser7_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser7_lblColorMarker.Location = New System.Drawing.Point(146, 241)
        Me.Ser7_lblColorMarker.Name = "Ser7_lblColorMarker"
        Me.Ser7_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser7_lblColorMarker.TabIndex = 222
        '
        'lblMarkercolor7
        '
        Me.lblMarkercolor7.AutoSize = True
        Me.lblMarkercolor7.Location = New System.Drawing.Point(21, 242)
        Me.lblMarkercolor7.Name = "lblMarkercolor7"
        Me.lblMarkercolor7.Size = New System.Drawing.Size(68, 13)
        Me.lblMarkercolor7.TabIndex = 221
        Me.lblMarkercolor7.Text = "Marker Color"
        '
        'Ser7_cBoxMarkerStyle
        '
        Me.Ser7_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser7_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser7_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 167)
        Me.Ser7_cBoxMarkerStyle.Name = "Ser7_cBoxMarkerStyle"
        Me.Ser7_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser7_cBoxMarkerStyle.TabIndex = 220
        Me.Ser7_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser7_lblMarkerStyle
        '
        Me.Ser7_lblMarkerStyle.AutoSize = True
        Me.Ser7_lblMarkerStyle.Location = New System.Drawing.Point(21, 170)
        Me.Ser7_lblMarkerStyle.Name = "Ser7_lblMarkerStyle"
        Me.Ser7_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser7_lblMarkerStyle.TabIndex = 219
        Me.Ser7_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser7_cBoxViewType
        '
        Me.Ser7_cBoxViewType.FormattingEnabled = True
        Me.Ser7_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser7_cBoxViewType.Location = New System.Drawing.Point(146, 132)
        Me.Ser7_cBoxViewType.Name = "Ser7_cBoxViewType"
        Me.Ser7_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser7_cBoxViewType.TabIndex = 218
        Me.Ser7_cBoxViewType.Text = "Line"
        '
        'Ser7_lblViewType
        '
        Me.Ser7_lblViewType.AutoSize = True
        Me.Ser7_lblViewType.Location = New System.Drawing.Point(21, 135)
        Me.Ser7_lblViewType.Name = "Ser7_lblViewType"
        Me.Ser7_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser7_lblViewType.TabIndex = 217
        Me.Ser7_lblViewType.Text = "View Type :"
        '
        'Ser7_txtSeriesName
        '
        Me.Ser7_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser7_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser7_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser7_txtSeriesName.Location = New System.Drawing.Point(146, 62)
        Me.Ser7_txtSeriesName.Name = "Ser7_txtSeriesName"
        Me.Ser7_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser7_txtSeriesName.TabIndex = 214
        Me.Ser7_txtSeriesName.Text = "Series 7"
        '
        'Ser7_lblSeriesName
        '
        Me.Ser7_lblSeriesName.AutoSize = True
        Me.Ser7_lblSeriesName.Location = New System.Drawing.Point(21, 64)
        Me.Ser7_lblSeriesName.Name = "Ser7_lblSeriesName"
        Me.Ser7_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser7_lblSeriesName.TabIndex = 213
        Me.Ser7_lblSeriesName.Text = "Series Name :"
        '
        'tabPage9_Series8
        '
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_llblInfo)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblColorSeries)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblSeriescolor)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_cBoxChannelY2Value)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblY2ActionChannel)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_cboxMarkerValue)
        Me.tabPage9_Series8.Controls.Add(Me.lblMarkerSize8)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblColorMarker)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblMarkercolor)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_cBoxMarkerStyle)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblMarkerStyle)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_cBoxViewType)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblViewType)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_txtSeriesName)
        Me.tabPage9_Series8.Controls.Add(Me.Ser8_lblSeriesName)
        Me.tabPage9_Series8.Name = "tabPage9_Series8"
        Me.tabPage9_Series8.Size = New System.Drawing.Size(868, 386)
        Me.tabPage9_Series8.Text = "Series 8"
        '
        'Ser8_llblInfo
        '
        Me.Ser8_llblInfo.AutoSize = True
        Me.Ser8_llblInfo.LinkArea = New System.Windows.Forms.LinkArea(1, 5)
        Me.Ser8_llblInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Ser8_llblInfo.Location = New System.Drawing.Point(311, 130)
        Me.Ser8_llblInfo.Name = "Ser8_llblInfo"
        Me.Ser8_llblInfo.Size = New System.Drawing.Size(31, 18)
        Me.Ser8_llblInfo.TabIndex = 247
        Me.Ser8_llblInfo.TabStop = True
        Me.Ser8_llblInfo.Text = "*Info"
        Me.Ser8_llblInfo.UseCompatibleTextRendering = True
        '
        'Ser8_lblColorSeries
        '
        Me.Ser8_lblColorSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser8_lblColorSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser8_lblColorSeries.Location = New System.Drawing.Point(146, 98)
        Me.Ser8_lblColorSeries.Name = "Ser8_lblColorSeries"
        Me.Ser8_lblColorSeries.Size = New System.Drawing.Size(71, 18)
        Me.Ser8_lblColorSeries.TabIndex = 246
        '
        'Ser8_lblSeriescolor
        '
        Me.Ser8_lblSeriescolor.AutoSize = True
        Me.Ser8_lblSeriescolor.Location = New System.Drawing.Point(24, 98)
        Me.Ser8_lblSeriescolor.Name = "Ser8_lblSeriescolor"
        Me.Ser8_lblSeriescolor.Size = New System.Drawing.Size(64, 13)
        Me.Ser8_lblSeriescolor.TabIndex = 245
        Me.Ser8_lblSeriescolor.Text = "Series Color"
        '
        'Ser8_cBoxChannelY2Value
        '
        Me.Ser8_cBoxChannelY2Value.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Ser8_cBoxChannelY2Value.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Ser8_cBoxChannelY2Value.DropDownHeight = 80
        Me.Ser8_cBoxChannelY2Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Ser8_cBoxChannelY2Value.FormattingEnabled = True
        Me.Ser8_cBoxChannelY2Value.IntegralHeight = False
        Me.Ser8_cBoxChannelY2Value.ItemHeight = 13
        Me.Ser8_cBoxChannelY2Value.Location = New System.Drawing.Point(146, 17)
        Me.Ser8_cBoxChannelY2Value.Name = "Ser8_cBoxChannelY2Value"
        Me.Ser8_cBoxChannelY2Value.Size = New System.Drawing.Size(201, 21)
        Me.Ser8_cBoxChannelY2Value.TabIndex = 244
        '
        'Ser8_lblY2ActionChannel
        '
        Me.Ser8_lblY2ActionChannel.AutoSize = True
        Me.Ser8_lblY2ActionChannel.Location = New System.Drawing.Point(21, 22)
        Me.Ser8_lblY2ActionChannel.Name = "Ser8_lblY2ActionChannel"
        Me.Ser8_lblY2ActionChannel.Size = New System.Drawing.Size(82, 13)
        Me.Ser8_lblY2ActionChannel.TabIndex = 242
        Me.Ser8_lblY2ActionChannel.Text = "Value Channel :"
        '
        'Ser8_cboxMarkerValue
        '
        Me.Ser8_cboxMarkerValue.FormattingEnabled = True
        Me.Ser8_cboxMarkerValue.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.Ser8_cboxMarkerValue.Location = New System.Drawing.Point(146, 201)
        Me.Ser8_cboxMarkerValue.Name = "Ser8_cboxMarkerValue"
        Me.Ser8_cboxMarkerValue.Size = New System.Drawing.Size(41, 21)
        Me.Ser8_cboxMarkerValue.TabIndex = 240
        Me.Ser8_cboxMarkerValue.Text = "3"
        '
        'lblMarkerSize8
        '
        Me.lblMarkerSize8.AutoSize = True
        Me.lblMarkerSize8.Location = New System.Drawing.Point(21, 203)
        Me.lblMarkerSize8.Name = "lblMarkerSize8"
        Me.lblMarkerSize8.Size = New System.Drawing.Size(69, 13)
        Me.lblMarkerSize8.TabIndex = 239
        Me.lblMarkerSize8.Text = "Marker Size :"
        '
        'Ser8_lblColorMarker
        '
        Me.Ser8_lblColorMarker.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Ser8_lblColorMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ser8_lblColorMarker.Location = New System.Drawing.Point(146, 237)
        Me.Ser8_lblColorMarker.Name = "Ser8_lblColorMarker"
        Me.Ser8_lblColorMarker.Size = New System.Drawing.Size(71, 18)
        Me.Ser8_lblColorMarker.TabIndex = 238
        '
        'Ser8_lblMarkercolor
        '
        Me.Ser8_lblMarkercolor.AutoSize = True
        Me.Ser8_lblMarkercolor.Location = New System.Drawing.Point(21, 238)
        Me.Ser8_lblMarkercolor.Name = "Ser8_lblMarkercolor"
        Me.Ser8_lblMarkercolor.Size = New System.Drawing.Size(68, 13)
        Me.Ser8_lblMarkercolor.TabIndex = 237
        Me.Ser8_lblMarkercolor.Text = "Marker Color"
        '
        'Ser8_cBoxMarkerStyle
        '
        Me.Ser8_cBoxMarkerStyle.FormattingEnabled = True
        Me.Ser8_cBoxMarkerStyle.Items.AddRange(New Object() {"None", "Square", "Circle", "Diamond", "Triangle", "Cross"})
        Me.Ser8_cBoxMarkerStyle.Location = New System.Drawing.Point(146, 163)
        Me.Ser8_cBoxMarkerStyle.Name = "Ser8_cBoxMarkerStyle"
        Me.Ser8_cBoxMarkerStyle.Size = New System.Drawing.Size(152, 21)
        Me.Ser8_cBoxMarkerStyle.TabIndex = 236
        Me.Ser8_cBoxMarkerStyle.Text = "Circle"
        '
        'Ser8_lblMarkerStyle
        '
        Me.Ser8_lblMarkerStyle.AutoSize = True
        Me.Ser8_lblMarkerStyle.Location = New System.Drawing.Point(21, 166)
        Me.Ser8_lblMarkerStyle.Name = "Ser8_lblMarkerStyle"
        Me.Ser8_lblMarkerStyle.Size = New System.Drawing.Size(74, 13)
        Me.Ser8_lblMarkerStyle.TabIndex = 235
        Me.Ser8_lblMarkerStyle.Text = "Marker Style :"
        '
        'Ser8_cBoxViewType
        '
        Me.Ser8_cBoxViewType.FormattingEnabled = True
        Me.Ser8_cBoxViewType.Items.AddRange(New Object() {"Line", "Spline", "Area", "SplineArea", "Bar", "Column", "Pie", "Doughnut", "Pyramid", "Funnel", "Radar"})
        Me.Ser8_cBoxViewType.Location = New System.Drawing.Point(146, 128)
        Me.Ser8_cBoxViewType.Name = "Ser8_cBoxViewType"
        Me.Ser8_cBoxViewType.Size = New System.Drawing.Size(152, 21)
        Me.Ser8_cBoxViewType.TabIndex = 234
        Me.Ser8_cBoxViewType.Text = "Line"
        '
        'Ser8_lblViewType
        '
        Me.Ser8_lblViewType.AutoSize = True
        Me.Ser8_lblViewType.Location = New System.Drawing.Point(21, 131)
        Me.Ser8_lblViewType.Name = "Ser8_lblViewType"
        Me.Ser8_lblViewType.Size = New System.Drawing.Size(63, 13)
        Me.Ser8_lblViewType.TabIndex = 233
        Me.Ser8_lblViewType.Text = "View Type :"
        '
        'Ser8_txtSeriesName
        '
        Me.Ser8_txtSeriesName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ser8_txtSeriesName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Ser8_txtSeriesName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Ser8_txtSeriesName.Location = New System.Drawing.Point(146, 61)
        Me.Ser8_txtSeriesName.Name = "Ser8_txtSeriesName"
        Me.Ser8_txtSeriesName.Size = New System.Drawing.Size(201, 21)
        Me.Ser8_txtSeriesName.TabIndex = 230
        Me.Ser8_txtSeriesName.Text = "Series 8"
        '
        'Ser8_lblSeriesName
        '
        Me.Ser8_lblSeriesName.AutoSize = True
        Me.Ser8_lblSeriesName.Location = New System.Drawing.Point(21, 63)
        Me.Ser8_lblSeriesName.Name = "Ser8_lblSeriesName"
        Me.Ser8_lblSeriesName.Size = New System.Drawing.Size(73, 13)
        Me.Ser8_lblSeriesName.TabIndex = 229
        Me.Ser8_lblSeriesName.Text = "Series Name :"
        '
        'btnMChartpropertiseCancel
        '
        Me.btnMChartpropertiseCancel.Location = New System.Drawing.Point(703, 447)
        Me.btnMChartpropertiseCancel.Name = "btnMChartpropertiseCancel"
        Me.btnMChartpropertiseCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnMChartpropertiseCancel.TabIndex = 1
        Me.btnMChartpropertiseCancel.Text = "Cancel"
        Me.btnMChartpropertiseCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(565, 447)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 25)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'MChartPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 484)
        Me.Controls.Add(Me.btnMChartpropertiseCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOk)
        Me.IconOptions.ShowIcon = False
        Me.MaximizeBox = False
        Me.Name = "MChartPropertiesForm"
        Me.Text = "MChartPropertiesForm"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tabMChartProp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMChartProp.ResumeLayout(False)
        Me.tabPage1_General.ResumeLayout(False)
        Me.tabPage1_General.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.gcConstantLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewConstantLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItemCboxAxis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItemSpinAxisVal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItemChkVisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItemColorLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.gcConstantSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewStaticSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItemColorSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBoxYScalling.ResumeLayout(False)
        Me.grpBoxYScalling.PerformLayout()
        Me.tabPage2_Series1.ResumeLayout(False)
        Me.tabPage2_Series1.PerformLayout()
        Me.tabPage3_Series2.ResumeLayout(False)
        Me.tabPage3_Series2.PerformLayout()
        Me.tabPage4_Series3.ResumeLayout(False)
        Me.tabPage4_Series3.PerformLayout()
        Me.tabPage5_Series4.ResumeLayout(False)
        Me.tabPage5_Series4.PerformLayout()
        Me.tabPage6_Series5.ResumeLayout(False)
        Me.tabPage6_Series5.PerformLayout()
        Me.tabPage7_Series6.ResumeLayout(False)
        Me.tabPage7_Series6.PerformLayout()
        Me.tabPage8_Series7.ResumeLayout(False)
        Me.tabPage8_Series7.PerformLayout()
        Me.tabPage9_Series8.ResumeLayout(False)
        Me.tabPage9_Series8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnMChartpropertiseCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents tabMChartProp As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabPage1_General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage2_Series1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage3_Series2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage4_Series3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage5_Series4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage6_Series5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage7_Series6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage8_Series7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPage9_Series8 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblChartTitleName As Label
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents lblTitleFont As Label
    Friend WithEvents txtTitleFont As TextBox
    Friend WithEvents btnTitleFont As Button
    Friend WithEvents lbl_xytitleColor As Label
    Friend WithEvents lblxytitleColor As Label
    Friend WithEvents lblYAxisTitle As Label
    Friend WithEvents txtYAxisTitle As TextBox
    Friend WithEvents lblXAxisTitle As Label
    Friend WithEvents txtXAxisTitle As TextBox
    Friend WithEvents grpBoxYScalling As GroupBox
    Friend WithEvents ckYAutoScale As CheckBox
    Friend WithEvents txtYTo As TextBox
    Friend WithEvents txtYFrom As TextBox
    Friend WithEvents lblYTo As Label
    Friend WithEvents lblYFrom As Label
    Friend WithEvents lbl_ChartBackColor As Label
    Friend WithEvents lblChartBackColor As Label
    Friend WithEvents Ser1_txtSeriesName As TextBox
    Friend WithEvents Ser1_lblSeriesName As Label
    Friend WithEvents Ser1_cboxMarkerValue As ComboBox
    Friend WithEvents Ser1_lblMarkerSize As Label
    Friend WithEvents Ser1_lblColorMarker As Label
    Friend WithEvents Ser1_lblMarkercolor As Label
    Friend WithEvents Ser1_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser1_lblMarkerStyle As Label
    Friend WithEvents Ser1_cBoxViewType As ComboBox
    Friend WithEvents Ser1_lblViewType As Label
    Friend WithEvents Ser1_llblInfo As LinkLabel
    Friend WithEvents RBtnValue As RadioButton
    Friend WithEvents Rbtntime As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Ser1_lblY2ActionChannel As Label
    Friend WithEvents Ser2_lblY2ActionChannel As Label
    Friend WithEvents Ser2_llblInfo As LinkLabel
    Friend WithEvents Ser2_cboxMarkerValue As ComboBox
    Friend WithEvents Ser2_lblMarkerSize As Label
    Friend WithEvents Ser2_lblColorMarker As Label
    Friend WithEvents Ser2_lblMarkercolor As Label
    Friend WithEvents Ser2_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser2_lblMarkerStyle As Label
    Friend WithEvents Ser2_cBoxViewType As ComboBox
    Friend WithEvents Ser2_lblViewType As Label
    Friend WithEvents Ser2_txtSeriesName As TextBox
    Friend WithEvents Ser2_lblSeriesName As Label
    Friend WithEvents Ser3_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser3_lblY2ActionChannel As Label
    Friend WithEvents Ser3_cboxMarkerValue As ComboBox
    Friend WithEvents Ser3_lblMarkerSize As Label
    Friend WithEvents Ser3_lblColorMarker As Label
    Friend WithEvents Ser3_lblMarkercolor As Label
    Friend WithEvents Ser3_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser3_lblMarkerStyle As Label
    Friend WithEvents Ser3_cBoxViewType As ComboBox
    Friend WithEvents Ser3_lblViewType As Label
    Friend WithEvents Ser3_txtSeriesName As TextBox
    Friend WithEvents Ser3_lblSeriesName As Label
    Friend WithEvents Ser4_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser4_lblY2ActionChannel As Label
    Friend WithEvents Ser4_cboxMarkerValue As ComboBox
    Friend WithEvents Ser4_lblMarkerSize As Label
    Friend WithEvents Ser4_lblColorMarker As Label
    Friend WithEvents Ser4_lblMarkercolor As Label
    Friend WithEvents Ser4_CboxMarkerStyle As ComboBox
    Friend WithEvents Ser4_lblMarkerStyle As Label
    Friend WithEvents Ser4_cBoxViewType As ComboBox
    Friend WithEvents Ser4_lblViewType As Label
    Friend WithEvents Ser4_txtSeriesName As TextBox
    Friend WithEvents Ser4_lblSeriesName As Label
    Friend WithEvents Ser5_cBoxChannelY2Value As ComboBox
    Friend WithEvents lblY2ActionChannel As Label
    Friend WithEvents Ser5_cboxMarkerValue As ComboBox
    Friend WithEvents lblMarkerSize5 As Label
    Friend WithEvents Ser5_lblColorMarker As Label
    Friend WithEvents lblMarkercolor5 As Label
    Friend WithEvents Ser5_cBoxMarkerStyle As ComboBox
    Friend WithEvents lblMarkerStyle5 As Label
    Friend WithEvents Ser5_cBoxViewType As ComboBox
    Friend WithEvents lblViewType5 As Label
    Friend WithEvents Ser5_txtSeriesName As TextBox
    Friend WithEvents Ser5_lblSeriesName As Label
    Friend WithEvents Ser6_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser6_lblY2ActionChannel As Label
    Friend WithEvents Ser6_cboxMarkerValue As ComboBox
    Friend WithEvents Ser6_lblMarkerSize As Label
    Friend WithEvents Ser6_lblColorMarker As Label
    Friend WithEvents Ser6_lblMarkercolor As Label
    Friend WithEvents Ser6_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser6_lblMarkerStyle As Label
    Friend WithEvents Ser6_cBoxViewType As ComboBox
    Friend WithEvents Ser6_lblViewType As Label
    Friend WithEvents Ser6_txtSeriesName As TextBox
    Friend WithEvents Ser6_lblSeriesName As Label
    Friend WithEvents Ser7_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser7_lblY2ActionChannel As Label
    Friend WithEvents Ser7_cboxMarkerValue As ComboBox
    Friend WithEvents Ser7_lblMarkerSize As Label
    Friend WithEvents Ser7_lblColorMarker As Label
    Friend WithEvents lblMarkercolor7 As Label
    Friend WithEvents Ser7_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser7_lblMarkerStyle As Label
    Friend WithEvents Ser7_cBoxViewType As ComboBox
    Friend WithEvents Ser7_lblViewType As Label
    Friend WithEvents Ser7_txtSeriesName As TextBox
    Friend WithEvents Ser7_lblSeriesName As Label
    Friend WithEvents Ser8_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser8_lblY2ActionChannel As Label
    Friend WithEvents Ser8_cboxMarkerValue As ComboBox
    Friend WithEvents lblMarkerSize8 As Label
    Friend WithEvents Ser8_lblColorMarker As Label
    Friend WithEvents Ser8_lblMarkercolor As Label
    Friend WithEvents Ser8_cBoxMarkerStyle As ComboBox
    Friend WithEvents Ser8_lblMarkerStyle As Label
    Friend WithEvents Ser8_cBoxViewType As ComboBox
    Friend WithEvents Ser8_lblViewType As Label
    Friend WithEvents Ser8_txtSeriesName As TextBox
    Friend WithEvents Ser8_lblSeriesName As Label
    Friend WithEvents ckLegendEnable As CheckBox
    Friend WithEvents lbl_LegendColor As Label
    Friend WithEvents lblLegendColor As Label
    Friend WithEvents ckLabelEnable As CheckBox
    Friend WithEvents lblAxisLabelColor As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cBoxChannelValue As ComboBox
    Friend WithEvents Ser1_lblYActionChannel As Label
    Friend WithEvents CboxTagscale As ComboBox
    Friend WithEvents lblXaxisTagname As Label
    Friend WithEvents Ser1_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser2_cBoxChannelY2Value As ComboBox
    Friend WithEvents Ser1_lblColorSeries As Label
    Friend WithEvents Ser1_lblSeriescolor As Label
    Friend WithEvents Ser2_lblColorSeries As Label
    Friend WithEvents Ser2_lblSeriescolor As Label
    Friend WithEvents Ser3_lblColorSeries As Label
    Friend WithEvents Ser3_lblSeriescolor As Label
    Friend WithEvents Ser4_lblColorSeries As Label
    Friend WithEvents Ser4_lblSeriescolor As Label
    Friend WithEvents Ser5_lblColorSeries As Label
    Friend WithEvents Ser5_lblSeriescolor As Label
    Friend WithEvents Ser6_lblColorSeries As Label
    Friend WithEvents Ser6_lblSeriescolor As Label
    Friend WithEvents Ser7_lblColorSeries As Label
    Friend WithEvents Ser7_lblSeriescolor As Label
    Friend WithEvents Ser8_lblColorSeries As Label
    Friend WithEvents Ser8_lblSeriescolor As Label
    Friend WithEvents Ser3_llblInfo As LinkLabel
    Friend WithEvents Ser4_llblInfo As LinkLabel
    Friend WithEvents Ser5_llblInfo As LinkLabel
    Friend WithEvents Ser6_llblInfo As LinkLabel
    Friend WithEvents Ser7_llblInfo As LinkLabel
    Friend WithEvents Ser8_llblInfo As LinkLabel
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcConstantLine As DevExpress.XtraGrid.GridControl
    Friend WithEvents ViewConstantLine As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcConstantSeries As DevExpress.XtraGrid.GridControl
    Friend WithEvents ViewStaticSeries As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAxis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAxisValue As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colVisible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSeriesName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPointX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPointY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSeriesColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarker As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepItemColorLine As DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit
    Friend WithEvents RepItemColorSeries As DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit
    Friend WithEvents btnCLineDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCLineAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCSeriesDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCSeriesAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepItemCboxAxis As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepItemSpinAxisVal As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepItemChkVisible As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboActionChannel As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboLambda As ComboBox
    Friend WithEvents cboP2Sch As ComboBox
    Friend WithEvents cboP2 As ComboBox
    Friend WithEvents cboP1Sch As ComboBox
    Friend WithEvents cboP1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
