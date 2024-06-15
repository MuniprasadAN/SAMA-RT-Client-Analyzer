''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                If Not PrintGrid Is Nothing Then PrintGrid.Dispose()

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPage))
        Me.GuageProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_GuagePropertie = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_GuageClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_GuageSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_GuageBringToFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_GuageCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_GuageCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripPages = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_PageProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_AddPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_DeletePage = New System.Windows.Forms.ToolStripMenuItem()
        Me.labelProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_LabelPropertie = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LabelClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LabelSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LabelBringToFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LabelCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LabelCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSDisplayValueLabel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_ValueLabelPropertie = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValueLabelClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ValueLabelSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValueLabelBringToFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ValueLabelCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValueLabelCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.printDOCCurrReport = New System.Drawing.Printing.PrintDocument()
        Me.ChartProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_ChartProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ChartClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ChartSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ChartBringToFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ChartCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ChartCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ChartPrinterSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ChartPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ChartExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ChartExpo_Img = New System.Windows.Forms.ToolStripMenuItem()
        Me.DddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PageProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_PagePropertie = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesignModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_PagePaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridTableProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_TableProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_TableClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_TableSendToBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_TableBringtoFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_TableCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_TableCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_TablePrinterSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_TablePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_TableExpo_Csv = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.HideGridLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGridLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlPage1 = New System.Windows.Forms.Panel()
        Me.pnlPage20 = New System.Windows.Forms.Panel()
        Me.pnlPage19 = New System.Windows.Forms.Panel()
        Me.pnlPage18 = New System.Windows.Forms.Panel()
        Me.pnlPage17 = New System.Windows.Forms.Panel()
        Me.pnlPage16 = New System.Windows.Forms.Panel()
        Me.pnlPage15 = New System.Windows.Forms.Panel()
        Me.pnlPage14 = New System.Windows.Forms.Panel()
        Me.pnlPage13 = New System.Windows.Forms.Panel()
        Me.pnlPage12 = New System.Windows.Forms.Panel()
        Me.pnlPage11 = New System.Windows.Forms.Panel()
        Me.pnlPage10 = New System.Windows.Forms.Panel()
        Me.pnlPage9 = New System.Windows.Forms.Panel()
        Me.pnlPage8 = New System.Windows.Forms.Panel()
        Me.pnlPage5 = New System.Windows.Forms.Panel()
        Me.pnlPage7 = New System.Windows.Forms.Panel()
        Me.pnlPage6 = New System.Windows.Forms.Panel()
        Me.pnlPage4 = New System.Windows.Forms.Panel()
        Me.pnlPage3 = New System.Windows.Forms.Panel()
        Me.pnlPage2 = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TreeViewLeft = New System.Windows.Forms.TreeView()
        Me.PageTreeView = New System.Windows.Forms.TreeView()
        Me.Main_STContainer = New System.Windows.Forms.ToolStripContainer()
        Me.CMS_Add_SupraDB_Channel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_ChannelAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_pnlProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_pnlClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_pnlSentoback = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_BtoF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_PanelCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_PanelCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PicBoxProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Pic_Properties = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBox_Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.PicBox_StoB = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBox_BtoF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.PicBox_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBox_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddOPC_Channel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_OPCChannelAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ShowDataForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainErrorPV = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.imagelistMain = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDoc_Table = New System.Drawing.Printing.PrintDocument()
        Me.PrintDoc_Chart = New System.Drawing.Printing.PrintDocument()
        Me.SS_Analyzer = New System.Windows.Forms.StatusStrip()
        Me.TSPagelbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSPoslbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MSMenu = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_OpenMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.Main_SaveMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_SaveAsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.Main_DocumentSettingsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_ToolBoxMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValueLabelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LevelIndicatorMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.Chart2DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Chart3DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.TableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.PanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicturePanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPCHDAQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPCWriterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnunciatorWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MORSChartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SymbolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShapMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainersAndVesselsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DistillationTowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JacketedVesselToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReactorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VesselToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StorageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtmosphericTankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FloatingRoofTankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GasHolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PressureStorageVesselToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WeighHopperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElectricalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CircuitBreakerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualContactorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeltaConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MotorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StateIndicatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WyeConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VacuumFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HeatTransferDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExchangerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForcedAirExchangerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FurnaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotaryKilnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HVACToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoolingTowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EvaporatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinnedExchangerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialHandlingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConveyorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RollStandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotaryFeederToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScrewConveyorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MixingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgitatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InlineMixerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotatingEquipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompressorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PumpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TurbineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeparatorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CycloneSeparatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotarySeparatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SprayDryerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReciprocatingEquipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReciprocatingCompressorOrPumpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValvesAndActuatorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TaskSchedulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FullScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.EMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetTotalizerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPCDAConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OPCHDAConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnunciatorColorSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlarmSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AudibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Main_PrintMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_showDBDataForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_DBDataForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblAlert = New System.Windows.Forms.Label()
        Me.LogBookProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_LBProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LBClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LBS_to_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LBB_to_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LBCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LBPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.AutoUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PdocRText = New System.Drawing.Printing.PrintDocument()
        Me.PdocGrid = New System.Drawing.Printing.PrintDocument()
        Me.ButtonProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_BtnProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_BtnClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_BtnS_To_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_BtnB_To_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_Btn_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_Btn_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrCheckConnectivity = New System.Windows.Forms.Timer(Me.components)
        Me.CMS_ConnectServer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConnectServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddSAMA_Historianchannel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddEditChannelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ShowSAMAHistorianForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.viewSAMAHistorianChnl = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunSAMAHistorianChnl = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopSAMAHistorianChnl = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiTrendChartProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MultitrendProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SymbolsProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_SymProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SymClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator43 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_SymS_To_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SymB_To_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_SymCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SymCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndicatorProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_IndicatorProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_IndicatorClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator41 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_IndicatorS_to_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_IndicatorB_To_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator42 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_IndicatorCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_IndicatorCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValveProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_ValveProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValveClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ValveS_to_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValveB_to_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_ValveCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_ValveCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwitchProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_SwitchProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SwitchClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator47 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_SwitchS_To_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SwitchB_To_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator48 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_SwitchCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_SwitchCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_LineVProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LineVClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator49 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LineVS_T_to_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LineVB_to_F = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator50 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_LineVCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_LineVCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OPCWriterProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator52 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddOPCDA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_AddOPCHDA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ShowOPCDAForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ShowOPCHDAForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem23 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem24 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnnunciatorProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MS_AnnunciatorProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_AnnunciatorClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator53 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_AnnunciatorSentoback = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_AnnunciatorBtoF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator54 = New System.Windows.Forms.ToolStripSeparator()
        Me.MS_AnnunciatorCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.MS_AnnunciatorCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MChartProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DMS_ChartProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.DMS_ChartClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator55 = New System.Windows.Forms.ToolStripSeparator()
        Me.SendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator56 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator57 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrinterPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator58 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.JpecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GuageProperties.SuspendLayout()
        Me.ContextMenuStripPages.SuspendLayout()
        Me.labelProperties.SuspendLayout()
        Me.MSDisplayValueLabel.SuspendLayout()
        Me.ChartProperties.SuspendLayout()
        Me.PageProperties.SuspendLayout()
        Me.GridTableProperties.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Main_STContainer.ContentPanel.SuspendLayout()
        Me.Main_STContainer.SuspendLayout()
        Me.CMS_Add_SupraDB_Channel.SuspendLayout()
        Me.PanelProperties.SuspendLayout()
        Me.PicBoxProperties.SuspendLayout()
        Me.CMS_AddOPC_Channel.SuspendLayout()
        Me.CMS_ShowDataForm.SuspendLayout()
        CType(Me.MainErrorPV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SS_Analyzer.SuspendLayout()
        Me.MSMenu.SuspendLayout()
        Me.CMS_showDBDataForm.SuspendLayout()
        Me.LogBookProperties.SuspendLayout()
        Me.ButtonProperties.SuspendLayout()
        Me.CMS_ConnectServer.SuspendLayout()
        Me.CMS_AddSAMA_Historianchannel.SuspendLayout()
        Me.CMS_ShowSAMAHistorianForm.SuspendLayout()
        Me.MultiTrendChartProperties.SuspendLayout()
        Me.SymbolsProperties.SuspendLayout()
        Me.IndicatorProperties.SuspendLayout()
        Me.ValveProperties.SuspendLayout()
        Me.SwitchProperties.SuspendLayout()
        Me.LineProperties.SuspendLayout()
        Me.OPCWriterProperties.SuspendLayout()
        Me.CMS_AddOPCDA.SuspendLayout()
        Me.CMS_AddOPCHDA.SuspendLayout()
        Me.CMS_ShowOPCDAForm.SuspendLayout()
        Me.CMS_ShowOPCHDAForm.SuspendLayout()
        Me.AnnunciatorProperties.SuspendLayout()
        Me.MChartProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'GuageProperties
        '
        Me.GuageProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.GuageProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_GuagePropertie, Me.MS_GuageClear, Me.ToolStripSeparator12, Me.MS_GuageSendToBack, Me.MS_GuageBringToFront, Me.ToolStripSeparator13, Me.MS_GuageCut, Me.MS_GuageCopy})
        Me.GuageProperties.Name = "ContextMenuStrip1"
        Me.GuageProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_GuagePropertie
        '
        Me.MS_GuagePropertie.Image = CType(resources.GetObject("MS_GuagePropertie.Image"), System.Drawing.Image)
        Me.MS_GuagePropertie.Name = "MS_GuagePropertie"
        Me.MS_GuagePropertie.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuagePropertie.Text = "Properties"
        '
        'MS_GuageClear
        '
        Me.MS_GuageClear.Image = CType(resources.GetObject("MS_GuageClear.Image"), System.Drawing.Image)
        Me.MS_GuageClear.Name = "MS_GuageClear"
        Me.MS_GuageClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuageClear.Text = "Clear"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(152, 6)
        '
        'MS_GuageSendToBack
        '
        Me.MS_GuageSendToBack.Image = CType(resources.GetObject("MS_GuageSendToBack.Image"), System.Drawing.Image)
        Me.MS_GuageSendToBack.Name = "MS_GuageSendToBack"
        Me.MS_GuageSendToBack.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuageSendToBack.Text = "Send to Back"
        '
        'MS_GuageBringToFront
        '
        Me.MS_GuageBringToFront.Image = CType(resources.GetObject("MS_GuageBringToFront.Image"), System.Drawing.Image)
        Me.MS_GuageBringToFront.Name = "MS_GuageBringToFront"
        Me.MS_GuageBringToFront.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuageBringToFront.Text = "Bring to Front"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(152, 6)
        '
        'MS_GuageCut
        '
        Me.MS_GuageCut.Image = CType(resources.GetObject("MS_GuageCut.Image"), System.Drawing.Image)
        Me.MS_GuageCut.Name = "MS_GuageCut"
        Me.MS_GuageCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuageCut.Text = "Cut"
        '
        'MS_GuageCopy
        '
        Me.MS_GuageCopy.Image = CType(resources.GetObject("MS_GuageCopy.Image"), System.Drawing.Image)
        Me.MS_GuageCopy.Name = "MS_GuageCopy"
        Me.MS_GuageCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_GuageCopy.Text = "Copy"
        '
        'ContextMenuStripPages
        '
        Me.ContextMenuStripPages.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStripPages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_PageProperties, Me.MS_AddPage, Me.MS_DeletePage})
        Me.ContextMenuStripPages.Name = "ContextMenuStrip1"
        Me.ContextMenuStripPages.Size = New System.Drawing.Size(145, 94)
        '
        'MS_PageProperties
        '
        Me.MS_PageProperties.Image = CType(resources.GetObject("MS_PageProperties.Image"), System.Drawing.Image)
        Me.MS_PageProperties.Name = "MS_PageProperties"
        Me.MS_PageProperties.Size = New System.Drawing.Size(144, 30)
        Me.MS_PageProperties.Text = "Properties..."
        '
        'MS_AddPage
        '
        Me.MS_AddPage.Image = CType(resources.GetObject("MS_AddPage.Image"), System.Drawing.Image)
        Me.MS_AddPage.Name = "MS_AddPage"
        Me.MS_AddPage.Size = New System.Drawing.Size(144, 30)
        Me.MS_AddPage.Text = "Add Page"
        '
        'MS_DeletePage
        '
        Me.MS_DeletePage.Image = CType(resources.GetObject("MS_DeletePage.Image"), System.Drawing.Image)
        Me.MS_DeletePage.Name = "MS_DeletePage"
        Me.MS_DeletePage.Size = New System.Drawing.Size(144, 30)
        Me.MS_DeletePage.Text = "Delete Page"
        '
        'labelProperties
        '
        Me.labelProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.labelProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_LabelPropertie, Me.MS_LabelClear, Me.ToolStripSeparator10, Me.MS_LabelSendToBack, Me.MS_LabelBringToFront, Me.ToolStripSeparator11, Me.MS_LabelCut, Me.MS_LabelCopy})
        Me.labelProperties.Name = "ContextMenuStrip1"
        Me.labelProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_LabelPropertie
        '
        Me.MS_LabelPropertie.Image = CType(resources.GetObject("MS_LabelPropertie.Image"), System.Drawing.Image)
        Me.MS_LabelPropertie.Name = "MS_LabelPropertie"
        Me.MS_LabelPropertie.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelPropertie.Text = "Properties"
        '
        'MS_LabelClear
        '
        Me.MS_LabelClear.Image = CType(resources.GetObject("MS_LabelClear.Image"), System.Drawing.Image)
        Me.MS_LabelClear.Name = "MS_LabelClear"
        Me.MS_LabelClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelClear.Text = "Clear"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LabelSendToBack
        '
        Me.MS_LabelSendToBack.Image = CType(resources.GetObject("MS_LabelSendToBack.Image"), System.Drawing.Image)
        Me.MS_LabelSendToBack.Name = "MS_LabelSendToBack"
        Me.MS_LabelSendToBack.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelSendToBack.Text = "Send to Back"
        '
        'MS_LabelBringToFront
        '
        Me.MS_LabelBringToFront.Image = CType(resources.GetObject("MS_LabelBringToFront.Image"), System.Drawing.Image)
        Me.MS_LabelBringToFront.Name = "MS_LabelBringToFront"
        Me.MS_LabelBringToFront.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelBringToFront.Text = "Bring to Front"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LabelCut
        '
        Me.MS_LabelCut.Image = CType(resources.GetObject("MS_LabelCut.Image"), System.Drawing.Image)
        Me.MS_LabelCut.Name = "MS_LabelCut"
        Me.MS_LabelCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelCut.Text = "Cut"
        '
        'MS_LabelCopy
        '
        Me.MS_LabelCopy.Image = CType(resources.GetObject("MS_LabelCopy.Image"), System.Drawing.Image)
        Me.MS_LabelCopy.Name = "MS_LabelCopy"
        Me.MS_LabelCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_LabelCopy.Text = "Copy"
        '
        'MSDisplayValueLabel
        '
        Me.MSDisplayValueLabel.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MSDisplayValueLabel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_ValueLabelPropertie, Me.MS_ValueLabelClear, Me.ToolStripSeparator8, Me.MS_ValueLabelSendToBack, Me.MS_ValueLabelBringToFront, Me.ToolStripSeparator9, Me.MS_ValueLabelCut, Me.MS_ValueLabelCopy})
        Me.MSDisplayValueLabel.Name = "ContextMenuStrip1"
        Me.MSDisplayValueLabel.Size = New System.Drawing.Size(156, 196)
        '
        'MS_ValueLabelPropertie
        '
        Me.MS_ValueLabelPropertie.Image = CType(resources.GetObject("MS_ValueLabelPropertie.Image"), System.Drawing.Image)
        Me.MS_ValueLabelPropertie.Name = "MS_ValueLabelPropertie"
        Me.MS_ValueLabelPropertie.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelPropertie.Text = "Properties"
        '
        'MS_ValueLabelClear
        '
        Me.MS_ValueLabelClear.Image = CType(resources.GetObject("MS_ValueLabelClear.Image"), System.Drawing.Image)
        Me.MS_ValueLabelClear.Name = "MS_ValueLabelClear"
        Me.MS_ValueLabelClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelClear.Text = "Clear"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(152, 6)
        '
        'MS_ValueLabelSendToBack
        '
        Me.MS_ValueLabelSendToBack.Image = CType(resources.GetObject("MS_ValueLabelSendToBack.Image"), System.Drawing.Image)
        Me.MS_ValueLabelSendToBack.Name = "MS_ValueLabelSendToBack"
        Me.MS_ValueLabelSendToBack.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelSendToBack.Text = "Send to Back"
        '
        'MS_ValueLabelBringToFront
        '
        Me.MS_ValueLabelBringToFront.Image = CType(resources.GetObject("MS_ValueLabelBringToFront.Image"), System.Drawing.Image)
        Me.MS_ValueLabelBringToFront.Name = "MS_ValueLabelBringToFront"
        Me.MS_ValueLabelBringToFront.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelBringToFront.Text = "Bring to Front"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(152, 6)
        '
        'MS_ValueLabelCut
        '
        Me.MS_ValueLabelCut.Image = CType(resources.GetObject("MS_ValueLabelCut.Image"), System.Drawing.Image)
        Me.MS_ValueLabelCut.Name = "MS_ValueLabelCut"
        Me.MS_ValueLabelCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelCut.Text = "Cut"
        '
        'MS_ValueLabelCopy
        '
        Me.MS_ValueLabelCopy.Image = CType(resources.GetObject("MS_ValueLabelCopy.Image"), System.Drawing.Image)
        Me.MS_ValueLabelCopy.Name = "MS_ValueLabelCopy"
        Me.MS_ValueLabelCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValueLabelCopy.Text = "Copy"
        '
        'printDOCCurrReport
        '
        '
        'ChartProperties
        '
        Me.ChartProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ChartProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_ChartProperties, Me.MS_ChartClear, Me.ToolStripSeparator14, Me.MS_ChartSendToBack, Me.MS_ChartBringToFront, Me.ToolStripSeparator15, Me.MS_ChartCut, Me.MS_ChartCopy, Me.ToolStripSeparator4, Me.MS_ChartPrinterSetting, Me.MS_ChartPrint, Me.ToolStripSeparator3, Me.MS_ChartExport, Me.DddToolStripMenuItem})
        Me.ChartProperties.Name = "ContextMenuStrip1"
        Me.ChartProperties.Size = New System.Drawing.Size(162, 328)
        '
        'MS_ChartProperties
        '
        Me.MS_ChartProperties.Image = CType(resources.GetObject("MS_ChartProperties.Image"), System.Drawing.Image)
        Me.MS_ChartProperties.Name = "MS_ChartProperties"
        Me.MS_ChartProperties.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartProperties.Text = "Properties"
        '
        'MS_ChartClear
        '
        Me.MS_ChartClear.Image = CType(resources.GetObject("MS_ChartClear.Image"), System.Drawing.Image)
        Me.MS_ChartClear.Name = "MS_ChartClear"
        Me.MS_ChartClear.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartClear.Text = "Clear"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(158, 6)
        '
        'MS_ChartSendToBack
        '
        Me.MS_ChartSendToBack.Image = CType(resources.GetObject("MS_ChartSendToBack.Image"), System.Drawing.Image)
        Me.MS_ChartSendToBack.Name = "MS_ChartSendToBack"
        Me.MS_ChartSendToBack.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartSendToBack.Text = "Send to Back"
        '
        'MS_ChartBringToFront
        '
        Me.MS_ChartBringToFront.Image = CType(resources.GetObject("MS_ChartBringToFront.Image"), System.Drawing.Image)
        Me.MS_ChartBringToFront.Name = "MS_ChartBringToFront"
        Me.MS_ChartBringToFront.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartBringToFront.Text = "Bring to Front"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(158, 6)
        '
        'MS_ChartCut
        '
        Me.MS_ChartCut.Image = CType(resources.GetObject("MS_ChartCut.Image"), System.Drawing.Image)
        Me.MS_ChartCut.Name = "MS_ChartCut"
        Me.MS_ChartCut.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartCut.Text = "Cut"
        '
        'MS_ChartCopy
        '
        Me.MS_ChartCopy.Image = CType(resources.GetObject("MS_ChartCopy.Image"), System.Drawing.Image)
        Me.MS_ChartCopy.Name = "MS_ChartCopy"
        Me.MS_ChartCopy.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartCopy.Text = "Copy"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(158, 6)
        '
        'MS_ChartPrinterSetting
        '
        Me.MS_ChartPrinterSetting.Image = CType(resources.GetObject("MS_ChartPrinterSetting.Image"), System.Drawing.Image)
        Me.MS_ChartPrinterSetting.Name = "MS_ChartPrinterSetting"
        Me.MS_ChartPrinterSetting.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartPrinterSetting.Text = "Printer Preview"
        '
        'MS_ChartPrint
        '
        Me.MS_ChartPrint.Image = CType(resources.GetObject("MS_ChartPrint.Image"), System.Drawing.Image)
        Me.MS_ChartPrint.Name = "MS_ChartPrint"
        Me.MS_ChartPrint.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartPrint.Text = "Print"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(158, 6)
        '
        'MS_ChartExport
        '
        Me.MS_ChartExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_ChartExpo_Img})
        Me.MS_ChartExport.Image = CType(resources.GetObject("MS_ChartExport.Image"), System.Drawing.Image)
        Me.MS_ChartExport.Name = "MS_ChartExport"
        Me.MS_ChartExport.Size = New System.Drawing.Size(161, 30)
        Me.MS_ChartExport.Text = "Export"
        '
        'MS_ChartExpo_Img
        '
        Me.MS_ChartExpo_Img.Image = CType(resources.GetObject("MS_ChartExpo_Img.Image"), System.Drawing.Image)
        Me.MS_ChartExpo_Img.Name = "MS_ChartExpo_Img"
        Me.MS_ChartExpo_Img.Size = New System.Drawing.Size(119, 22)
        Me.MS_ChartExpo_Img.Text = "Jpeg File"
        '
        'DddToolStripMenuItem
        '
        Me.DddToolStripMenuItem.Name = "DddToolStripMenuItem"
        Me.DddToolStripMenuItem.Size = New System.Drawing.Size(161, 30)
        Me.DddToolStripMenuItem.Text = "ddd"
        '
        'PageProperties
        '
        Me.PageProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PageProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_PagePropertie, Me.DesignModeToolStripMenuItem, Me.MS_PagePaste})
        Me.PageProperties.Name = "ContextMenuStrip1"
        Me.PageProperties.Size = New System.Drawing.Size(153, 94)
        '
        'MS_PagePropertie
        '
        Me.MS_PagePropertie.Image = CType(resources.GetObject("MS_PagePropertie.Image"), System.Drawing.Image)
        Me.MS_PagePropertie.Name = "MS_PagePropertie"
        Me.MS_PagePropertie.Size = New System.Drawing.Size(152, 30)
        Me.MS_PagePropertie.Text = "Properties..."
        '
        'DesignModeToolStripMenuItem
        '
        Me.DesignModeToolStripMenuItem.Image = CType(resources.GetObject("DesignModeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DesignModeToolStripMenuItem.Name = "DesignModeToolStripMenuItem"
        Me.DesignModeToolStripMenuItem.Size = New System.Drawing.Size(152, 30)
        Me.DesignModeToolStripMenuItem.Text = "Design Mode"
        '
        'MS_PagePaste
        '
        Me.MS_PagePaste.Image = CType(resources.GetObject("MS_PagePaste.Image"), System.Drawing.Image)
        Me.MS_PagePaste.Name = "MS_PagePaste"
        Me.MS_PagePaste.Size = New System.Drawing.Size(152, 30)
        Me.MS_PagePaste.Text = "Paste"
        '
        'GridTableProperties
        '
        Me.GridTableProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.GridTableProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_TableProperty, Me.MS_TableClear, Me.ToolStripSeparator16, Me.MS_TableSendToBack, Me.MS_TableBringtoFront, Me.ToolStripSeparator17, Me.MS_TableCut, Me.MS_TableCopy, Me.ToolStripSeparator1, Me.MS_TablePrinterSetting, Me.MS_TablePrint, Me.ToolStripSeparator2, Me.ExportToolStripMenuItem, Me.ToolStripSeparator7, Me.HideGridLineToolStripMenuItem, Me.ShowGridLineToolStripMenuItem})
        Me.GridTableProperties.Name = "ContextMenuStrip1"
        Me.GridTableProperties.Size = New System.Drawing.Size(162, 364)
        '
        'MS_TableProperty
        '
        Me.MS_TableProperty.Image = CType(resources.GetObject("MS_TableProperty.Image"), System.Drawing.Image)
        Me.MS_TableProperty.Name = "MS_TableProperty"
        Me.MS_TableProperty.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableProperty.Text = "Properties"
        '
        'MS_TableClear
        '
        Me.MS_TableClear.Image = CType(resources.GetObject("MS_TableClear.Image"), System.Drawing.Image)
        Me.MS_TableClear.Name = "MS_TableClear"
        Me.MS_TableClear.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableClear.Text = "Clear"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(158, 6)
        '
        'MS_TableSendToBack
        '
        Me.MS_TableSendToBack.Image = CType(resources.GetObject("MS_TableSendToBack.Image"), System.Drawing.Image)
        Me.MS_TableSendToBack.Name = "MS_TableSendToBack"
        Me.MS_TableSendToBack.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableSendToBack.Text = "Send to Back"
        '
        'MS_TableBringtoFront
        '
        Me.MS_TableBringtoFront.Image = CType(resources.GetObject("MS_TableBringtoFront.Image"), System.Drawing.Image)
        Me.MS_TableBringtoFront.Name = "MS_TableBringtoFront"
        Me.MS_TableBringtoFront.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableBringtoFront.Text = "Bring to Front"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(158, 6)
        '
        'MS_TableCut
        '
        Me.MS_TableCut.Image = CType(resources.GetObject("MS_TableCut.Image"), System.Drawing.Image)
        Me.MS_TableCut.Name = "MS_TableCut"
        Me.MS_TableCut.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableCut.Text = "Cut"
        '
        'MS_TableCopy
        '
        Me.MS_TableCopy.Image = CType(resources.GetObject("MS_TableCopy.Image"), System.Drawing.Image)
        Me.MS_TableCopy.Name = "MS_TableCopy"
        Me.MS_TableCopy.Size = New System.Drawing.Size(161, 30)
        Me.MS_TableCopy.Text = "Copy"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'MS_TablePrinterSetting
        '
        Me.MS_TablePrinterSetting.Image = CType(resources.GetObject("MS_TablePrinterSetting.Image"), System.Drawing.Image)
        Me.MS_TablePrinterSetting.Name = "MS_TablePrinterSetting"
        Me.MS_TablePrinterSetting.Size = New System.Drawing.Size(161, 30)
        Me.MS_TablePrinterSetting.Text = "Printer Preview"
        '
        'MS_TablePrint
        '
        Me.MS_TablePrint.Image = CType(resources.GetObject("MS_TablePrint.Image"), System.Drawing.Image)
        Me.MS_TablePrint.Name = "MS_TablePrint"
        Me.MS_TablePrint.Size = New System.Drawing.Size(161, 30)
        Me.MS_TablePrint.Text = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_TableExpo_Csv})
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(161, 30)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'MS_TableExpo_Csv
        '
        Me.MS_TableExpo_Csv.Image = CType(resources.GetObject("MS_TableExpo_Csv.Image"), System.Drawing.Image)
        Me.MS_TableExpo_Csv.Name = "MS_TableExpo_Csv"
        Me.MS_TableExpo_Csv.Size = New System.Drawing.Size(119, 22)
        Me.MS_TableExpo_Csv.Text = "CSV  File"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(158, 6)
        '
        'HideGridLineToolStripMenuItem
        '
        Me.HideGridLineToolStripMenuItem.Image = CType(resources.GetObject("HideGridLineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HideGridLineToolStripMenuItem.Name = "HideGridLineToolStripMenuItem"
        Me.HideGridLineToolStripMenuItem.Size = New System.Drawing.Size(161, 30)
        Me.HideGridLineToolStripMenuItem.Text = "Hide Grid Line"
        '
        'ShowGridLineToolStripMenuItem
        '
        Me.ShowGridLineToolStripMenuItem.Image = CType(resources.GetObject("ShowGridLineToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShowGridLineToolStripMenuItem.Name = "ShowGridLineToolStripMenuItem"
        Me.ShowGridLineToolStripMenuItem.Size = New System.Drawing.Size(161, 30)
        Me.ShowGridLineToolStripMenuItem.Text = "Show Grid Line"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(1035, 408)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage20)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage19)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlPage2)
        Me.SplitContainer1.Panel1MinSize = 100
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2MinSize = 0
        Me.SplitContainer1.Size = New System.Drawing.Size(799, 328)
        Me.SplitContainer1.SplitterDistance = 663
        Me.SplitContainer1.TabIndex = 0
        '
        'pnlPage1
        '
        Me.pnlPage1.AllowDrop = True
        Me.pnlPage1.AutoScroll = True
        Me.pnlPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage1.Location = New System.Drawing.Point(38, 31)
        Me.pnlPage1.Name = "pnlPage1"
        Me.pnlPage1.Size = New System.Drawing.Size(92, 44)
        Me.pnlPage1.TabIndex = 0
        Me.pnlPage1.Visible = False
        '
        'pnlPage20
        '
        Me.pnlPage20.AllowDrop = True
        Me.pnlPage20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage20.Location = New System.Drawing.Point(506, 227)
        Me.pnlPage20.Name = "pnlPage20"
        Me.pnlPage20.Size = New System.Drawing.Size(108, 44)
        Me.pnlPage20.TabIndex = 16
        Me.pnlPage20.Visible = False
        '
        'pnlPage19
        '
        Me.pnlPage19.AllowDrop = True
        Me.pnlPage19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage19.Location = New System.Drawing.Point(374, 227)
        Me.pnlPage19.Name = "pnlPage19"
        Me.pnlPage19.Size = New System.Drawing.Size(100, 44)
        Me.pnlPage19.TabIndex = 17
        Me.pnlPage19.Visible = False
        '
        'pnlPage18
        '
        Me.pnlPage18.AllowDrop = True
        Me.pnlPage18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage18.Location = New System.Drawing.Point(254, 227)
        Me.pnlPage18.Name = "pnlPage18"
        Me.pnlPage18.Size = New System.Drawing.Size(105, 44)
        Me.pnlPage18.TabIndex = 15
        Me.pnlPage18.Visible = False
        '
        'pnlPage17
        '
        Me.pnlPage17.AllowDrop = True
        Me.pnlPage17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage17.Location = New System.Drawing.Point(146, 227)
        Me.pnlPage17.Name = "pnlPage17"
        Me.pnlPage17.Size = New System.Drawing.Size(92, 44)
        Me.pnlPage17.TabIndex = 14
        Me.pnlPage17.Visible = False
        '
        'pnlPage16
        '
        Me.pnlPage16.AllowDrop = True
        Me.pnlPage16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage16.Location = New System.Drawing.Point(38, 227)
        Me.pnlPage16.Name = "pnlPage16"
        Me.pnlPage16.Size = New System.Drawing.Size(92, 43)
        Me.pnlPage16.TabIndex = 13
        Me.pnlPage16.Visible = False
        '
        'pnlPage15
        '
        Me.pnlPage15.AllowDrop = True
        Me.pnlPage15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage15.Location = New System.Drawing.Point(506, 162)
        Me.pnlPage15.Name = "pnlPage15"
        Me.pnlPage15.Size = New System.Drawing.Size(108, 44)
        Me.pnlPage15.TabIndex = 11
        Me.pnlPage15.Visible = False
        '
        'pnlPage14
        '
        Me.pnlPage14.AllowDrop = True
        Me.pnlPage14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage14.Location = New System.Drawing.Point(374, 162)
        Me.pnlPage14.Name = "pnlPage14"
        Me.pnlPage14.Size = New System.Drawing.Size(100, 44)
        Me.pnlPage14.TabIndex = 12
        Me.pnlPage14.Visible = False
        '
        'pnlPage13
        '
        Me.pnlPage13.AllowDrop = True
        Me.pnlPage13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage13.Location = New System.Drawing.Point(254, 162)
        Me.pnlPage13.Name = "pnlPage13"
        Me.pnlPage13.Size = New System.Drawing.Size(105, 44)
        Me.pnlPage13.TabIndex = 10
        Me.pnlPage13.Visible = False
        '
        'pnlPage12
        '
        Me.pnlPage12.AllowDrop = True
        Me.pnlPage12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage12.Location = New System.Drawing.Point(146, 162)
        Me.pnlPage12.Name = "pnlPage12"
        Me.pnlPage12.Size = New System.Drawing.Size(92, 44)
        Me.pnlPage12.TabIndex = 9
        Me.pnlPage12.Visible = False
        '
        'pnlPage11
        '
        Me.pnlPage11.AllowDrop = True
        Me.pnlPage11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage11.Location = New System.Drawing.Point(38, 162)
        Me.pnlPage11.Name = "pnlPage11"
        Me.pnlPage11.Size = New System.Drawing.Size(92, 43)
        Me.pnlPage11.TabIndex = 8
        Me.pnlPage11.Visible = False
        '
        'pnlPage10
        '
        Me.pnlPage10.AllowDrop = True
        Me.pnlPage10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage10.Location = New System.Drawing.Point(506, 94)
        Me.pnlPage10.Name = "pnlPage10"
        Me.pnlPage10.Size = New System.Drawing.Size(108, 44)
        Me.pnlPage10.TabIndex = 6
        Me.pnlPage10.Visible = False
        '
        'pnlPage9
        '
        Me.pnlPage9.AllowDrop = True
        Me.pnlPage9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage9.Location = New System.Drawing.Point(374, 94)
        Me.pnlPage9.Name = "pnlPage9"
        Me.pnlPage9.Size = New System.Drawing.Size(100, 44)
        Me.pnlPage9.TabIndex = 7
        Me.pnlPage9.Visible = False
        '
        'pnlPage8
        '
        Me.pnlPage8.AllowDrop = True
        Me.pnlPage8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage8.Location = New System.Drawing.Point(254, 94)
        Me.pnlPage8.Name = "pnlPage8"
        Me.pnlPage8.Size = New System.Drawing.Size(105, 44)
        Me.pnlPage8.TabIndex = 5
        Me.pnlPage8.Visible = False
        '
        'pnlPage5
        '
        Me.pnlPage5.AllowDrop = True
        Me.pnlPage5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage5.Location = New System.Drawing.Point(506, 31)
        Me.pnlPage5.Name = "pnlPage5"
        Me.pnlPage5.Size = New System.Drawing.Size(108, 44)
        Me.pnlPage5.TabIndex = 2
        Me.pnlPage5.Visible = False
        '
        'pnlPage7
        '
        Me.pnlPage7.AllowDrop = True
        Me.pnlPage7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage7.Location = New System.Drawing.Point(146, 94)
        Me.pnlPage7.Name = "pnlPage7"
        Me.pnlPage7.Size = New System.Drawing.Size(92, 44)
        Me.pnlPage7.TabIndex = 4
        Me.pnlPage7.Visible = False
        '
        'pnlPage6
        '
        Me.pnlPage6.AllowDrop = True
        Me.pnlPage6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage6.Location = New System.Drawing.Point(38, 94)
        Me.pnlPage6.Name = "pnlPage6"
        Me.pnlPage6.Size = New System.Drawing.Size(92, 43)
        Me.pnlPage6.TabIndex = 3
        Me.pnlPage6.Visible = False
        '
        'pnlPage4
        '
        Me.pnlPage4.AllowDrop = True
        Me.pnlPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage4.Location = New System.Drawing.Point(374, 31)
        Me.pnlPage4.Name = "pnlPage4"
        Me.pnlPage4.Size = New System.Drawing.Size(100, 44)
        Me.pnlPage4.TabIndex = 3
        Me.pnlPage4.Visible = False
        '
        'pnlPage3
        '
        Me.pnlPage3.AllowDrop = True
        Me.pnlPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage3.Location = New System.Drawing.Point(254, 31)
        Me.pnlPage3.Name = "pnlPage3"
        Me.pnlPage3.Size = New System.Drawing.Size(105, 44)
        Me.pnlPage3.TabIndex = 2
        Me.pnlPage3.Visible = False
        '
        'pnlPage2
        '
        Me.pnlPage2.AllowDrop = True
        Me.pnlPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPage2.Location = New System.Drawing.Point(146, 31)
        Me.pnlPage2.Name = "pnlPage2"
        Me.pnlPage2.Size = New System.Drawing.Size(92, 44)
        Me.pnlPage2.TabIndex = 1
        Me.pnlPage2.Visible = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeViewLeft)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.PageTreeView)
        Me.SplitContainer2.Size = New System.Drawing.Size(132, 328)
        Me.SplitContainer2.SplitterDistance = 156
        Me.SplitContainer2.TabIndex = 0
        '
        'TreeViewLeft
        '
        Me.TreeViewLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewLeft.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewLeft.Name = "TreeViewLeft"
        Me.TreeViewLeft.Size = New System.Drawing.Size(132, 156)
        Me.TreeViewLeft.TabIndex = 0
        '
        'PageTreeView
        '
        Me.PageTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PageTreeView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PageTreeView.Location = New System.Drawing.Point(0, 0)
        Me.PageTreeView.Name = "PageTreeView"
        Me.PageTreeView.Size = New System.Drawing.Size(132, 168)
        Me.PageTreeView.TabIndex = 0
        '
        'Main_STContainer
        '
        '
        'Main_STContainer.ContentPanel
        '
        Me.Main_STContainer.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.Main_STContainer.ContentPanel.Size = New System.Drawing.Size(799, 328)
        Me.Main_STContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_STContainer.Location = New System.Drawing.Point(0, 30)
        Me.Main_STContainer.Name = "Main_STContainer"
        Me.Main_STContainer.Size = New System.Drawing.Size(799, 353)
        Me.Main_STContainer.TabIndex = 3
        Me.Main_STContainer.Text = "ToolStripContainer1"
        '
        'Main_STContainer.TopToolStripPanel
        '
        Me.Main_STContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'CMS_Add_SupraDB_Channel
        '
        Me.CMS_Add_SupraDB_Channel.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_Add_SupraDB_Channel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_ChannelAdd})
        Me.CMS_Add_SupraDB_Channel.Name = "ContextMenuStrip1"
        Me.CMS_Add_SupraDB_Channel.Size = New System.Drawing.Size(183, 34)
        '
        'MS_ChannelAdd
        '
        Me.MS_ChannelAdd.Image = CType(resources.GetObject("MS_ChannelAdd.Image"), System.Drawing.Image)
        Me.MS_ChannelAdd.Name = "MS_ChannelAdd"
        Me.MS_ChannelAdd.Size = New System.Drawing.Size(182, 30)
        Me.MS_ChannelAdd.Text = "Add / Edit Channel"
        '
        'MS_pnlProperties
        '
        Me.MS_pnlProperties.Image = CType(resources.GetObject("MS_pnlProperties.Image"), System.Drawing.Image)
        Me.MS_pnlProperties.Name = "MS_pnlProperties"
        Me.MS_pnlProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_pnlProperties.Text = "Properties"
        '
        'MS_pnlClear
        '
        Me.MS_pnlClear.Image = CType(resources.GetObject("MS_pnlClear.Image"), System.Drawing.Image)
        Me.MS_pnlClear.Name = "MS_pnlClear"
        Me.MS_pnlClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_pnlClear.Text = "Clear"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(152, 6)
        '
        'MS_pnlSentoback
        '
        Me.MS_pnlSentoback.Image = CType(resources.GetObject("MS_pnlSentoback.Image"), System.Drawing.Image)
        Me.MS_pnlSentoback.Name = "MS_pnlSentoback"
        Me.MS_pnlSentoback.Size = New System.Drawing.Size(155, 30)
        Me.MS_pnlSentoback.Text = "Send to Back"
        '
        'MS_BtoF
        '
        Me.MS_BtoF.Image = CType(resources.GetObject("MS_BtoF.Image"), System.Drawing.Image)
        Me.MS_BtoF.Name = "MS_BtoF"
        Me.MS_BtoF.Size = New System.Drawing.Size(155, 30)
        Me.MS_BtoF.Text = "Bring to Front"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(152, 6)
        '
        'MS_PanelCut
        '
        Me.MS_PanelCut.Image = CType(resources.GetObject("MS_PanelCut.Image"), System.Drawing.Image)
        Me.MS_PanelCut.Name = "MS_PanelCut"
        Me.MS_PanelCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_PanelCut.Text = "Cut"
        '
        'MS_PanelCopy
        '
        Me.MS_PanelCopy.Image = CType(resources.GetObject("MS_PanelCopy.Image"), System.Drawing.Image)
        Me.MS_PanelCopy.Name = "MS_PanelCopy"
        Me.MS_PanelCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_PanelCopy.Text = "Copy"
        '
        'PanelProperties
        '
        Me.PanelProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PanelProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_pnlProperties, Me.MS_pnlClear, Me.ToolStripSeparator19, Me.MS_pnlSentoback, Me.MS_BtoF, Me.ToolStripSeparator20, Me.MS_PanelCut, Me.MS_PanelCopy})
        Me.PanelProperties.Name = "ContextMenuStrip1"
        Me.PanelProperties.Size = New System.Drawing.Size(156, 196)
        '
        'PicBoxProperties
        '
        Me.PicBoxProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.PicBoxProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pic_Properties, Me.PicBox_Clear, Me.ToolStripSeparator21, Me.PicBox_StoB, Me.PicBox_BtoF, Me.ToolStripSeparator22, Me.PicBox_Cut, Me.PicBox_Copy})
        Me.PicBoxProperties.Name = "ContextMenuStrip1"
        Me.PicBoxProperties.Size = New System.Drawing.Size(156, 196)
        '
        'Pic_Properties
        '
        Me.Pic_Properties.Image = CType(resources.GetObject("Pic_Properties.Image"), System.Drawing.Image)
        Me.Pic_Properties.Name = "Pic_Properties"
        Me.Pic_Properties.Size = New System.Drawing.Size(155, 30)
        Me.Pic_Properties.Text = "Properties"
        '
        'PicBox_Clear
        '
        Me.PicBox_Clear.Image = CType(resources.GetObject("PicBox_Clear.Image"), System.Drawing.Image)
        Me.PicBox_Clear.Name = "PicBox_Clear"
        Me.PicBox_Clear.Size = New System.Drawing.Size(155, 30)
        Me.PicBox_Clear.Text = "Clear"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(152, 6)
        '
        'PicBox_StoB
        '
        Me.PicBox_StoB.Image = CType(resources.GetObject("PicBox_StoB.Image"), System.Drawing.Image)
        Me.PicBox_StoB.Name = "PicBox_StoB"
        Me.PicBox_StoB.Size = New System.Drawing.Size(155, 30)
        Me.PicBox_StoB.Text = "Send to Back"
        '
        'PicBox_BtoF
        '
        Me.PicBox_BtoF.Image = CType(resources.GetObject("PicBox_BtoF.Image"), System.Drawing.Image)
        Me.PicBox_BtoF.Name = "PicBox_BtoF"
        Me.PicBox_BtoF.Size = New System.Drawing.Size(155, 30)
        Me.PicBox_BtoF.Text = "Bring to Front"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(152, 6)
        '
        'PicBox_Cut
        '
        Me.PicBox_Cut.Image = CType(resources.GetObject("PicBox_Cut.Image"), System.Drawing.Image)
        Me.PicBox_Cut.Name = "PicBox_Cut"
        Me.PicBox_Cut.Size = New System.Drawing.Size(155, 30)
        Me.PicBox_Cut.Text = "Cut"
        '
        'PicBox_Copy
        '
        Me.PicBox_Copy.Image = CType(resources.GetObject("PicBox_Copy.Image"), System.Drawing.Image)
        Me.PicBox_Copy.Name = "PicBox_Copy"
        Me.PicBox_Copy.Size = New System.Drawing.Size(155, 30)
        Me.PicBox_Copy.Text = "Copy"
        '
        'CMS_AddOPC_Channel
        '
        Me.CMS_AddOPC_Channel.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_AddOPC_Channel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_OPCChannelAdd})
        Me.CMS_AddOPC_Channel.Name = "ContextMenuStrip1"
        Me.CMS_AddOPC_Channel.Size = New System.Drawing.Size(183, 34)
        '
        'MS_OPCChannelAdd
        '
        Me.MS_OPCChannelAdd.Image = CType(resources.GetObject("MS_OPCChannelAdd.Image"), System.Drawing.Image)
        Me.MS_OPCChannelAdd.Name = "MS_OPCChannelAdd"
        Me.MS_OPCChannelAdd.Size = New System.Drawing.Size(182, 30)
        Me.MS_OPCChannelAdd.Text = "Add / Edit Channel"
        '
        'CMS_ShowDataForm
        '
        Me.CMS_ShowDataForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_ShowDataForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDataToolStripMenuItem, Me.RunToolStripMenuItem, Me.StopToolStripMenuItem})
        Me.CMS_ShowDataForm.Name = "ContextMenuStrip1"
        Me.CMS_ShowDataForm.Size = New System.Drawing.Size(135, 94)
        '
        'ViewDataToolStripMenuItem
        '
        Me.ViewDataToolStripMenuItem.Image = CType(resources.GetObject("ViewDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewDataToolStripMenuItem.Name = "ViewDataToolStripMenuItem"
        Me.ViewDataToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.ViewDataToolStripMenuItem.Text = "View Data"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.Image = CType(resources.GetObject("RunToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = CType(resources.GetObject("StopToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'MainErrorPV
        '
        Me.MainErrorPV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.MainErrorPV.ContainerControl = Me
        Me.MainErrorPV.Icon = CType(resources.GetObject("MainErrorPV.Icon"), System.Drawing.Icon)
        Me.MainErrorPV.RightToLeft = True
        '
        'imagelistMain
        '
        Me.imagelistMain.ImageStream = CType(resources.GetObject("imagelistMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagelistMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imagelistMain.Images.SetKeyName(0, "chart-stock-icon.png")
        Me.imagelistMain.Images.SetKeyName(1, "shape-group.png")
        Me.imagelistMain.Images.SetKeyName(2, "shape-group-icon.png")
        Me.imagelistMain.Images.SetKeyName(3, "page-2-icon.png")
        Me.imagelistMain.Images.SetKeyName(4, "Program-Group-icon.png")
        Me.imagelistMain.Images.SetKeyName(5, "ch.png")
        Me.imagelistMain.Images.SetKeyName(6, "Activity-Monitor-icon.png")
        '
        'PrintDoc_Table
        '
        '
        'PrintDoc_Chart
        '
        '
        'SS_Analyzer
        '
        Me.SS_Analyzer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SS_Analyzer.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SS_Analyzer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSPagelbl, Me.TSPoslbl})
        Me.SS_Analyzer.Location = New System.Drawing.Point(0, 383)
        Me.SS_Analyzer.Name = "SS_Analyzer"
        Me.SS_Analyzer.Size = New System.Drawing.Size(799, 25)
        Me.SS_Analyzer.TabIndex = 13
        Me.SS_Analyzer.Text = "SS_Analyzer"
        '
        'TSPagelbl
        '
        Me.TSPagelbl.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TSPagelbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.TSPagelbl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSPagelbl.Name = "TSPagelbl"
        Me.TSPagelbl.Size = New System.Drawing.Size(43, 20)
        Me.TSPagelbl.Text = "page"
        Me.TSPagelbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TSPoslbl
        '
        Me.TSPoslbl.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TSPoslbl.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.TSPoslbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSPoslbl.Name = "TSPoslbl"
        Me.TSPoslbl.Size = New System.Drawing.Size(34, 20)
        Me.TSPoslbl.Text = "Pos"
        Me.TSPoslbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MSMenu
        '
        Me.MSMenu.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSMenu.GripMargin = New System.Windows.Forms.Padding(2)
        Me.MSMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MSMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MSMenu.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MSMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.Main_ToolBoxMenu, Me.SymbolsToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.Main_PrintMenu})
        Me.MSMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MSMenu.Location = New System.Drawing.Point(0, 0)
        Me.MSMenu.Name = "MSMenu"
        Me.MSMenu.Padding = New System.Windows.Forms.Padding(2, 1, 0, 1)
        Me.MSMenu.ShowItemToolTips = True
        Me.MSMenu.Size = New System.Drawing.Size(799, 30)
        Me.MSMenu.TabIndex = 12
        Me.MSMenu.Text = "Menu"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Main_OpenMenu, Me.ToolStripSeparator34, Me.Main_SaveMenu, Me.Main_SaveAsMenu, Me.ToolStripSeparator35, Me.Main_DocumentSettingsMenu, Me.ToolStripSeparator36, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(62, 28)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'Main_OpenMenu
        '
        Me.Main_OpenMenu.Image = CType(resources.GetObject("Main_OpenMenu.Image"), System.Drawing.Image)
        Me.Main_OpenMenu.Name = "Main_OpenMenu"
        Me.Main_OpenMenu.ShortcutKeyDisplayString = "Ctrl+O"
        Me.Main_OpenMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.Main_OpenMenu.Size = New System.Drawing.Size(198, 30)
        Me.Main_OpenMenu.Text = "&Open"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(195, 6)
        '
        'Main_SaveMenu
        '
        Me.Main_SaveMenu.Image = CType(resources.GetObject("Main_SaveMenu.Image"), System.Drawing.Image)
        Me.Main_SaveMenu.Name = "Main_SaveMenu"
        Me.Main_SaveMenu.ShortcutKeyDisplayString = "Ctrl+S"
        Me.Main_SaveMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.Main_SaveMenu.Size = New System.Drawing.Size(198, 30)
        Me.Main_SaveMenu.Text = "&Save"
        '
        'Main_SaveAsMenu
        '
        Me.Main_SaveAsMenu.Image = CType(resources.GetObject("Main_SaveAsMenu.Image"), System.Drawing.Image)
        Me.Main_SaveAsMenu.Name = "Main_SaveAsMenu"
        Me.Main_SaveAsMenu.ShortcutKeyDisplayString = "Ctrl+Alt+S"
        Me.Main_SaveAsMenu.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.Main_SaveAsMenu.Size = New System.Drawing.Size(198, 30)
        Me.Main_SaveAsMenu.Text = "&Save As"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(195, 6)
        Me.ToolStripSeparator35.Visible = False
        '
        'Main_DocumentSettingsMenu
        '
        Me.Main_DocumentSettingsMenu.Image = CType(resources.GetObject("Main_DocumentSettingsMenu.Image"), System.Drawing.Image)
        Me.Main_DocumentSettingsMenu.Name = "Main_DocumentSettingsMenu"
        Me.Main_DocumentSettingsMenu.Size = New System.Drawing.Size(198, 30)
        Me.Main_DocumentSettingsMenu.Text = "Document Settings"
        Me.Main_DocumentSettingsMenu.Visible = False
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(195, 6)
        Me.ToolStripSeparator36.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Main_ToolBoxMenu
        '
        Me.Main_ToolBoxMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelToolStripMenuItem, Me.ButtonMenuItem, Me.ToolStripSeparator26, Me.GuageToolStripMenuItem, Me.ValueLabelToolStripMenuItem, Me.LevelIndicatorMenuItem, Me.ToolStripSeparator25, Me.Chart2DToolStripMenuItem, Me.Chart3DToolStripMenuItem, Me.ToolStripSeparator18, Me.TableToolStripMenuItem, Me.ToolStripSeparator23, Me.PanelToolStripMenuItem, Me.PicturePanelToolStripMenuItem, Me.ToolStripSeparator24, Me.LogBookToolStripMenuItem, Me.TrenderToolStripMenuItem, Me.OPCHDAQueryToolStripMenuItem, Me.OPCWriterToolStripMenuItem, Me.AnnunciatorWindowToolStripMenuItem, Me.MORSChartToolStripMenuItem})
        Me.Main_ToolBoxMenu.Image = CType(resources.GetObject("Main_ToolBoxMenu.Image"), System.Drawing.Image)
        Me.Main_ToolBoxMenu.Name = "Main_ToolBoxMenu"
        Me.Main_ToolBoxMenu.Size = New System.Drawing.Size(92, 28)
        Me.Main_ToolBoxMenu.Text = "Tool Box"
        '
        'LabelToolStripMenuItem
        '
        Me.LabelToolStripMenuItem.Image = CType(resources.GetObject("LabelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LabelToolStripMenuItem.Name = "LabelToolStripMenuItem"
        Me.LabelToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.LabelToolStripMenuItem.Text = "Text"
        '
        'ButtonMenuItem
        '
        Me.ButtonMenuItem.Image = CType(resources.GetObject("ButtonMenuItem.Image"), System.Drawing.Image)
        Me.ButtonMenuItem.Name = "ButtonMenuItem"
        Me.ButtonMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.ButtonMenuItem.Text = "Button"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(195, 6)
        '
        'GuageToolStripMenuItem
        '
        Me.GuageToolStripMenuItem.Image = CType(resources.GetObject("GuageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GuageToolStripMenuItem.Name = "GuageToolStripMenuItem"
        Me.GuageToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.GuageToolStripMenuItem.Text = "Analog Guage"
        '
        'ValueLabelToolStripMenuItem
        '
        Me.ValueLabelToolStripMenuItem.Image = CType(resources.GetObject("ValueLabelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ValueLabelToolStripMenuItem.Name = "ValueLabelToolStripMenuItem"
        Me.ValueLabelToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.ValueLabelToolStripMenuItem.Text = "Value Label"
        '
        'LevelIndicatorMenuItem
        '
        Me.LevelIndicatorMenuItem.Image = CType(resources.GetObject("LevelIndicatorMenuItem.Image"), System.Drawing.Image)
        Me.LevelIndicatorMenuItem.Name = "LevelIndicatorMenuItem"
        Me.LevelIndicatorMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.LevelIndicatorMenuItem.Text = "Level Indicator"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(195, 6)
        '
        'Chart2DToolStripMenuItem
        '
        Me.Chart2DToolStripMenuItem.Image = CType(resources.GetObject("Chart2DToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Chart2DToolStripMenuItem.Name = "Chart2DToolStripMenuItem"
        Me.Chart2DToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.Chart2DToolStripMenuItem.Text = "2D Chart"
        '
        'Chart3DToolStripMenuItem
        '
        Me.Chart3DToolStripMenuItem.Image = CType(resources.GetObject("Chart3DToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Chart3DToolStripMenuItem.Name = "Chart3DToolStripMenuItem"
        Me.Chart3DToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.Chart3DToolStripMenuItem.Text = "3D Chart"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(195, 6)
        '
        'TableToolStripMenuItem
        '
        Me.TableToolStripMenuItem.Image = CType(resources.GetObject("TableToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TableToolStripMenuItem.Name = "TableToolStripMenuItem"
        Me.TableToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.TableToolStripMenuItem.Text = "Table"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(195, 6)
        '
        'PanelToolStripMenuItem
        '
        Me.PanelToolStripMenuItem.Image = CType(resources.GetObject("PanelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PanelToolStripMenuItem.Name = "PanelToolStripMenuItem"
        Me.PanelToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.PanelToolStripMenuItem.Text = "Panel"
        '
        'PicturePanelToolStripMenuItem
        '
        Me.PicturePanelToolStripMenuItem.Image = CType(resources.GetObject("PicturePanelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PicturePanelToolStripMenuItem.Name = "PicturePanelToolStripMenuItem"
        Me.PicturePanelToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.PicturePanelToolStripMenuItem.Text = "Picture Panel"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(195, 6)
        '
        'LogBookToolStripMenuItem
        '
        Me.LogBookToolStripMenuItem.Image = CType(resources.GetObject("LogBookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogBookToolStripMenuItem.Name = "LogBookToolStripMenuItem"
        Me.LogBookToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.LogBookToolStripMenuItem.Text = "Log Book"
        '
        'TrenderToolStripMenuItem
        '
        Me.TrenderToolStripMenuItem.Image = CType(resources.GetObject("TrenderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TrenderToolStripMenuItem.Name = "TrenderToolStripMenuItem"
        Me.TrenderToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.TrenderToolStripMenuItem.Text = "Trender"
        '
        'OPCHDAQueryToolStripMenuItem
        '
        Me.OPCHDAQueryToolStripMenuItem.Name = "OPCHDAQueryToolStripMenuItem"
        Me.OPCHDAQueryToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.OPCHDAQueryToolStripMenuItem.Text = "OPCHDA Query "
        '
        'OPCWriterToolStripMenuItem
        '
        Me.OPCWriterToolStripMenuItem.Name = "OPCWriterToolStripMenuItem"
        Me.OPCWriterToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.OPCWriterToolStripMenuItem.Text = "OPC Writer"
        '
        'AnnunciatorWindowToolStripMenuItem
        '
        Me.AnnunciatorWindowToolStripMenuItem.Name = "AnnunciatorWindowToolStripMenuItem"
        Me.AnnunciatorWindowToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.AnnunciatorWindowToolStripMenuItem.Text = "Annunciator Window"
        '
        'MORSChartToolStripMenuItem
        '
        Me.MORSChartToolStripMenuItem.Name = "MORSChartToolStripMenuItem"
        Me.MORSChartToolStripMenuItem.Size = New System.Drawing.Size(198, 30)
        Me.MORSChartToolStripMenuItem.Text = "MORS Chart"
        '
        'SymbolsToolStripMenuItem
        '
        Me.SymbolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShapMenuItem, Me.ContainersAndVesselsToolStripMenuItem, Me.ElectricalToolStripMenuItem, Me.FiltersToolStripMenuItem, Me.HeatTransferDevicesToolStripMenuItem, Me.HVACToolStripMenuItem, Me.MaterialHandlingToolStripMenuItem, Me.MixingToolStripMenuItem, Me.RotatingEquipmentToolStripMenuItem, Me.SeparatorsToolStripMenuItem, Me.ReciprocatingEquipmentToolStripMenuItem, Me.ValvesAndActuatorsToolStripMenuItem})
        Me.SymbolsToolStripMenuItem.Image = CType(resources.GetObject("SymbolsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SymbolsToolStripMenuItem.Name = "SymbolsToolStripMenuItem"
        Me.SymbolsToolStripMenuItem.Size = New System.Drawing.Size(92, 28)
        Me.SymbolsToolStripMenuItem.Text = "Symbols"
        '
        'ShapMenuItem
        '
        Me.ShapMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LineMenuItem})
        Me.ShapMenuItem.Name = "ShapMenuItem"
        Me.ShapMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ShapMenuItem.Text = "Shapes"
        '
        'LineMenuItem
        '
        Me.LineMenuItem.Name = "LineMenuItem"
        Me.LineMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.LineMenuItem.Text = "Line"
        '
        'ContainersAndVesselsToolStripMenuItem
        '
        Me.ContainersAndVesselsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessToolStripMenuItem, Me.StorageToolStripMenuItem})
        Me.ContainersAndVesselsToolStripMenuItem.Name = "ContainersAndVesselsToolStripMenuItem"
        Me.ContainersAndVesselsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ContainersAndVesselsToolStripMenuItem.Text = "Containers and vessels"
        '
        'ProcessToolStripMenuItem
        '
        Me.ProcessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DistillationTowerToolStripMenuItem, Me.JacketedVesselToolStripMenuItem, Me.ReactorToolStripMenuItem, Me.VesselToolStripMenuItem})
        Me.ProcessToolStripMenuItem.Name = "ProcessToolStripMenuItem"
        Me.ProcessToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ProcessToolStripMenuItem.Text = "Process"
        '
        'DistillationTowerToolStripMenuItem
        '
        Me.DistillationTowerToolStripMenuItem.Name = "DistillationTowerToolStripMenuItem"
        Me.DistillationTowerToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DistillationTowerToolStripMenuItem.Text = "Distillation Tower"
        '
        'JacketedVesselToolStripMenuItem
        '
        Me.JacketedVesselToolStripMenuItem.Name = "JacketedVesselToolStripMenuItem"
        Me.JacketedVesselToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.JacketedVesselToolStripMenuItem.Text = "Jacketed Vessel"
        '
        'ReactorToolStripMenuItem
        '
        Me.ReactorToolStripMenuItem.Name = "ReactorToolStripMenuItem"
        Me.ReactorToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ReactorToolStripMenuItem.Text = "Reactor"
        '
        'VesselToolStripMenuItem
        '
        Me.VesselToolStripMenuItem.Name = "VesselToolStripMenuItem"
        Me.VesselToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.VesselToolStripMenuItem.Text = "Vessel"
        '
        'StorageToolStripMenuItem
        '
        Me.StorageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtmosphericTankToolStripMenuItem, Me.BinToolStripMenuItem, Me.FloatingRoofTankToolStripMenuItem, Me.GasHolderToolStripMenuItem, Me.PressureStorageVesselToolStripMenuItem, Me.WeighHopperToolStripMenuItem})
        Me.StorageToolStripMenuItem.Name = "StorageToolStripMenuItem"
        Me.StorageToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.StorageToolStripMenuItem.Text = "Storage"
        '
        'AtmosphericTankToolStripMenuItem
        '
        Me.AtmosphericTankToolStripMenuItem.Name = "AtmosphericTankToolStripMenuItem"
        Me.AtmosphericTankToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.AtmosphericTankToolStripMenuItem.Text = "Atmospheric Tank"
        '
        'BinToolStripMenuItem
        '
        Me.BinToolStripMenuItem.Name = "BinToolStripMenuItem"
        Me.BinToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.BinToolStripMenuItem.Text = "Bin"
        '
        'FloatingRoofTankToolStripMenuItem
        '
        Me.FloatingRoofTankToolStripMenuItem.Name = "FloatingRoofTankToolStripMenuItem"
        Me.FloatingRoofTankToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.FloatingRoofTankToolStripMenuItem.Text = "Floating Roof Tank"
        '
        'GasHolderToolStripMenuItem
        '
        Me.GasHolderToolStripMenuItem.Name = "GasHolderToolStripMenuItem"
        Me.GasHolderToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.GasHolderToolStripMenuItem.Text = "Gas Holder"
        '
        'PressureStorageVesselToolStripMenuItem
        '
        Me.PressureStorageVesselToolStripMenuItem.Name = "PressureStorageVesselToolStripMenuItem"
        Me.PressureStorageVesselToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.PressureStorageVesselToolStripMenuItem.Text = "Pressure Storage Vessel"
        '
        'WeighHopperToolStripMenuItem
        '
        Me.WeighHopperToolStripMenuItem.Name = "WeighHopperToolStripMenuItem"
        Me.WeighHopperToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.WeighHopperToolStripMenuItem.Text = "Weigh Hopper"
        '
        'ElectricalToolStripMenuItem
        '
        Me.ElectricalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CircuitBreakerToolStripMenuItem, Me.ManualContactorToolStripMenuItem, Me.DeltaConnectionToolStripMenuItem, Me.FuseToolStripMenuItem, Me.MotorToolStripMenuItem, Me.StateIndicatorToolStripMenuItem, Me.TransformerToolStripMenuItem, Me.WyeConnectionToolStripMenuItem})
        Me.ElectricalToolStripMenuItem.Name = "ElectricalToolStripMenuItem"
        Me.ElectricalToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ElectricalToolStripMenuItem.Text = "Electrical"
        '
        'CircuitBreakerToolStripMenuItem
        '
        Me.CircuitBreakerToolStripMenuItem.Name = "CircuitBreakerToolStripMenuItem"
        Me.CircuitBreakerToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CircuitBreakerToolStripMenuItem.Text = "Circuit Breaker"
        '
        'ManualContactorToolStripMenuItem
        '
        Me.ManualContactorToolStripMenuItem.Name = "ManualContactorToolStripMenuItem"
        Me.ManualContactorToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ManualContactorToolStripMenuItem.Text = "Manual Contactor"
        '
        'DeltaConnectionToolStripMenuItem
        '
        Me.DeltaConnectionToolStripMenuItem.Name = "DeltaConnectionToolStripMenuItem"
        Me.DeltaConnectionToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DeltaConnectionToolStripMenuItem.Text = "Delta Connection"
        '
        'FuseToolStripMenuItem
        '
        Me.FuseToolStripMenuItem.Name = "FuseToolStripMenuItem"
        Me.FuseToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.FuseToolStripMenuItem.Text = "Fuse"
        '
        'MotorToolStripMenuItem
        '
        Me.MotorToolStripMenuItem.Name = "MotorToolStripMenuItem"
        Me.MotorToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MotorToolStripMenuItem.Text = "Motor"
        '
        'StateIndicatorToolStripMenuItem
        '
        Me.StateIndicatorToolStripMenuItem.Name = "StateIndicatorToolStripMenuItem"
        Me.StateIndicatorToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.StateIndicatorToolStripMenuItem.Text = "State Indicator"
        '
        'TransformerToolStripMenuItem
        '
        Me.TransformerToolStripMenuItem.Name = "TransformerToolStripMenuItem"
        Me.TransformerToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.TransformerToolStripMenuItem.Text = "Transformer"
        '
        'WyeConnectionToolStripMenuItem
        '
        Me.WyeConnectionToolStripMenuItem.Name = "WyeConnectionToolStripMenuItem"
        Me.WyeConnectionToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.WyeConnectionToolStripMenuItem.Text = "Wye Connection"
        '
        'FiltersToolStripMenuItem
        '
        Me.FiltersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidFilterToolStripMenuItem, Me.VacuumFilterToolStripMenuItem})
        Me.FiltersToolStripMenuItem.Name = "FiltersToolStripMenuItem"
        Me.FiltersToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.FiltersToolStripMenuItem.Text = "Filters"
        '
        'LiquidFilterToolStripMenuItem
        '
        Me.LiquidFilterToolStripMenuItem.Name = "LiquidFilterToolStripMenuItem"
        Me.LiquidFilterToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.LiquidFilterToolStripMenuItem.Text = "Liquid Filter"
        '
        'VacuumFilterToolStripMenuItem
        '
        Me.VacuumFilterToolStripMenuItem.Name = "VacuumFilterToolStripMenuItem"
        Me.VacuumFilterToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.VacuumFilterToolStripMenuItem.Text = "Vacuum Filter"
        '
        'HeatTransferDevicesToolStripMenuItem
        '
        Me.HeatTransferDevicesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExchangerToolStripMenuItem, Me.ForcedAirExchangerToolStripMenuItem, Me.FurnaceToolStripMenuItem, Me.RotaryKilnToolStripMenuItem})
        Me.HeatTransferDevicesToolStripMenuItem.Name = "HeatTransferDevicesToolStripMenuItem"
        Me.HeatTransferDevicesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.HeatTransferDevicesToolStripMenuItem.Text = "Heat transfer devices"
        '
        'ExchangerToolStripMenuItem
        '
        Me.ExchangerToolStripMenuItem.Name = "ExchangerToolStripMenuItem"
        Me.ExchangerToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ExchangerToolStripMenuItem.Text = "Exchanger"
        '
        'ForcedAirExchangerToolStripMenuItem
        '
        Me.ForcedAirExchangerToolStripMenuItem.Name = "ForcedAirExchangerToolStripMenuItem"
        Me.ForcedAirExchangerToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ForcedAirExchangerToolStripMenuItem.Text = "Forced Air Exchanger"
        '
        'FurnaceToolStripMenuItem
        '
        Me.FurnaceToolStripMenuItem.Name = "FurnaceToolStripMenuItem"
        Me.FurnaceToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.FurnaceToolStripMenuItem.Text = "Furnace"
        '
        'RotaryKilnToolStripMenuItem
        '
        Me.RotaryKilnToolStripMenuItem.Name = "RotaryKilnToolStripMenuItem"
        Me.RotaryKilnToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.RotaryKilnToolStripMenuItem.Text = "Rotary Kiln"
        '
        'HVACToolStripMenuItem
        '
        Me.HVACToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CoolingTowerToolStripMenuItem, Me.EvaporatorToolStripMenuItem, Me.FinnedExchangerToolStripMenuItem})
        Me.HVACToolStripMenuItem.Name = "HVACToolStripMenuItem"
        Me.HVACToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.HVACToolStripMenuItem.Text = "HVAC"
        '
        'CoolingTowerToolStripMenuItem
        '
        Me.CoolingTowerToolStripMenuItem.Name = "CoolingTowerToolStripMenuItem"
        Me.CoolingTowerToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.CoolingTowerToolStripMenuItem.Text = "Cooling Tower"
        '
        'EvaporatorToolStripMenuItem
        '
        Me.EvaporatorToolStripMenuItem.Name = "EvaporatorToolStripMenuItem"
        Me.EvaporatorToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EvaporatorToolStripMenuItem.Text = "Evaporator"
        '
        'FinnedExchangerToolStripMenuItem
        '
        Me.FinnedExchangerToolStripMenuItem.Name = "FinnedExchangerToolStripMenuItem"
        Me.FinnedExchangerToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.FinnedExchangerToolStripMenuItem.Text = "Finned Exchanger"
        '
        'MaterialHandlingToolStripMenuItem
        '
        Me.MaterialHandlingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConveyorToolStripMenuItem, Me.MillToolStripMenuItem, Me.RollStandToolStripMenuItem, Me.RotaryFeederToolStripMenuItem, Me.ScrewConveyorToolStripMenuItem})
        Me.MaterialHandlingToolStripMenuItem.Name = "MaterialHandlingToolStripMenuItem"
        Me.MaterialHandlingToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.MaterialHandlingToolStripMenuItem.Text = "Material handling"
        '
        'ConveyorToolStripMenuItem
        '
        Me.ConveyorToolStripMenuItem.Name = "ConveyorToolStripMenuItem"
        Me.ConveyorToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ConveyorToolStripMenuItem.Text = "Conveyor"
        '
        'MillToolStripMenuItem
        '
        Me.MillToolStripMenuItem.Name = "MillToolStripMenuItem"
        Me.MillToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.MillToolStripMenuItem.Text = "Mill"
        '
        'RollStandToolStripMenuItem
        '
        Me.RollStandToolStripMenuItem.Name = "RollStandToolStripMenuItem"
        Me.RollStandToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.RollStandToolStripMenuItem.Text = "Roll Stand"
        '
        'RotaryFeederToolStripMenuItem
        '
        Me.RotaryFeederToolStripMenuItem.Name = "RotaryFeederToolStripMenuItem"
        Me.RotaryFeederToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.RotaryFeederToolStripMenuItem.Text = "Rotary Feeder"
        '
        'ScrewConveyorToolStripMenuItem
        '
        Me.ScrewConveyorToolStripMenuItem.Name = "ScrewConveyorToolStripMenuItem"
        Me.ScrewConveyorToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ScrewConveyorToolStripMenuItem.Text = "Screw Conveyor"
        '
        'MixingToolStripMenuItem
        '
        Me.MixingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgitatorToolStripMenuItem, Me.InlineMixerToolStripMenuItem})
        Me.MixingToolStripMenuItem.Name = "MixingToolStripMenuItem"
        Me.MixingToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.MixingToolStripMenuItem.Text = "Mixing"
        '
        'AgitatorToolStripMenuItem
        '
        Me.AgitatorToolStripMenuItem.Name = "AgitatorToolStripMenuItem"
        Me.AgitatorToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AgitatorToolStripMenuItem.Text = "Agitator"
        '
        'InlineMixerToolStripMenuItem
        '
        Me.InlineMixerToolStripMenuItem.Name = "InlineMixerToolStripMenuItem"
        Me.InlineMixerToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.InlineMixerToolStripMenuItem.Text = "Inline Mixer"
        '
        'RotatingEquipmentToolStripMenuItem
        '
        Me.RotatingEquipmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlowerToolStripMenuItem, Me.CompressorToolStripMenuItem, Me.PumpToolStripMenuItem, Me.TurbineToolStripMenuItem})
        Me.RotatingEquipmentToolStripMenuItem.Name = "RotatingEquipmentToolStripMenuItem"
        Me.RotatingEquipmentToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RotatingEquipmentToolStripMenuItem.Text = "Rotating equipment"
        '
        'BlowerToolStripMenuItem
        '
        Me.BlowerToolStripMenuItem.Name = "BlowerToolStripMenuItem"
        Me.BlowerToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.BlowerToolStripMenuItem.Text = "Blower"
        '
        'CompressorToolStripMenuItem
        '
        Me.CompressorToolStripMenuItem.Name = "CompressorToolStripMenuItem"
        Me.CompressorToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CompressorToolStripMenuItem.Text = "Compressor"
        '
        'PumpToolStripMenuItem
        '
        Me.PumpToolStripMenuItem.Name = "PumpToolStripMenuItem"
        Me.PumpToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PumpToolStripMenuItem.Text = "Pump"
        '
        'TurbineToolStripMenuItem
        '
        Me.TurbineToolStripMenuItem.Name = "TurbineToolStripMenuItem"
        Me.TurbineToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.TurbineToolStripMenuItem.Text = "Turbine"
        '
        'SeparatorsToolStripMenuItem
        '
        Me.SeparatorsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CycloneSeparatorToolStripMenuItem, Me.RotarySeparatorToolStripMenuItem, Me.SprayDryerToolStripMenuItem})
        Me.SeparatorsToolStripMenuItem.Name = "SeparatorsToolStripMenuItem"
        Me.SeparatorsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.SeparatorsToolStripMenuItem.Text = "Separators"
        '
        'CycloneSeparatorToolStripMenuItem
        '
        Me.CycloneSeparatorToolStripMenuItem.Name = "CycloneSeparatorToolStripMenuItem"
        Me.CycloneSeparatorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CycloneSeparatorToolStripMenuItem.Text = "Cyclone Separator"
        '
        'RotarySeparatorToolStripMenuItem
        '
        Me.RotarySeparatorToolStripMenuItem.Name = "RotarySeparatorToolStripMenuItem"
        Me.RotarySeparatorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RotarySeparatorToolStripMenuItem.Text = "Rotary Separator"
        '
        'SprayDryerToolStripMenuItem
        '
        Me.SprayDryerToolStripMenuItem.Name = "SprayDryerToolStripMenuItem"
        Me.SprayDryerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SprayDryerToolStripMenuItem.Text = "Spray Dryer"
        '
        'ReciprocatingEquipmentToolStripMenuItem
        '
        Me.ReciprocatingEquipmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReciprocatingCompressorOrPumpToolStripMenuItem})
        Me.ReciprocatingEquipmentToolStripMenuItem.Name = "ReciprocatingEquipmentToolStripMenuItem"
        Me.ReciprocatingEquipmentToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ReciprocatingEquipmentToolStripMenuItem.Text = "Reciprocating Equipment"
        '
        'ReciprocatingCompressorOrPumpToolStripMenuItem
        '
        Me.ReciprocatingCompressorOrPumpToolStripMenuItem.Name = "ReciprocatingCompressorOrPumpToolStripMenuItem"
        Me.ReciprocatingCompressorOrPumpToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ReciprocatingCompressorOrPumpToolStripMenuItem.Text = "Reciprocating Compressor or Pump"
        '
        'ValvesAndActuatorsToolStripMenuItem
        '
        Me.ValvesAndActuatorsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValveToolStripMenuItem})
        Me.ValvesAndActuatorsToolStripMenuItem.Name = "ValvesAndActuatorsToolStripMenuItem"
        Me.ValvesAndActuatorsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ValvesAndActuatorsToolStripMenuItem.Text = "Valves"
        '
        'ValveToolStripMenuItem
        '
        Me.ValveToolStripMenuItem.Name = "ValveToolStripMenuItem"
        Me.ValveToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.ValveToolStripMenuItem.Text = "Valve"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ErrorLogToolStripMenuItem, Me.ToolStripSeparator5, Me.TaskSchedulerToolStripMenuItem, Me.ToolStripSeparator6, Me.FullScreenToolStripMenuItem, Me.AutoStartToolStripMenuItem, Me.ToolStripSeparator37, Me.EMailToolStripMenuItem, Me.UsersToolStripMenuItem, Me.ResetTotalizerToolStripMenuItem, Me.OPCDAConfigurationToolStripMenuItem, Me.OPCHDAConfigurationToolStripMenuItem, Me.AnnunciatorColorSettingToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(89, 28)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ErrorLogToolStripMenuItem
        '
        Me.ErrorLogToolStripMenuItem.Image = CType(resources.GetObject("ErrorLogToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ErrorLogToolStripMenuItem.Name = "ErrorLogToolStripMenuItem"
        Me.ErrorLogToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.ErrorLogToolStripMenuItem.Text = "Error Log"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(228, 6)
        Me.ToolStripSeparator5.Visible = False
        '
        'TaskSchedulerToolStripMenuItem
        '
        Me.TaskSchedulerToolStripMenuItem.Image = CType(resources.GetObject("TaskSchedulerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TaskSchedulerToolStripMenuItem.Name = "TaskSchedulerToolStripMenuItem"
        Me.TaskSchedulerToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.TaskSchedulerToolStripMenuItem.Text = "Task Scheduler"
        Me.TaskSchedulerToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(228, 6)
        Me.ToolStripSeparator6.Visible = False
        '
        'FullScreenToolStripMenuItem
        '
        Me.FullScreenToolStripMenuItem.Image = CType(resources.GetObject("FullScreenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem"
        Me.FullScreenToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.FullScreenToolStripMenuItem.Text = "Run Mode"
        '
        'AutoStartToolStripMenuItem
        '
        Me.AutoStartToolStripMenuItem.Image = CType(resources.GetObject("AutoStartToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AutoStartToolStripMenuItem.Name = "AutoStartToolStripMenuItem"
        Me.AutoStartToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.AutoStartToolStripMenuItem.Text = "Auto Start"
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(228, 6)
        '
        'EMailToolStripMenuItem
        '
        Me.EMailToolStripMenuItem.Image = CType(resources.GetObject("EMailToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EMailToolStripMenuItem.Name = "EMailToolStripMenuItem"
        Me.EMailToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.EMailToolStripMenuItem.Text = "E-Mail"
        Me.EMailToolStripMenuItem.Visible = False
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'ResetTotalizerToolStripMenuItem
        '
        Me.ResetTotalizerToolStripMenuItem.Name = "ResetTotalizerToolStripMenuItem"
        Me.ResetTotalizerToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.ResetTotalizerToolStripMenuItem.Text = "Reset Totalizer"
        Me.ResetTotalizerToolStripMenuItem.Visible = False
        '
        'OPCDAConfigurationToolStripMenuItem
        '
        Me.OPCDAConfigurationToolStripMenuItem.Name = "OPCDAConfigurationToolStripMenuItem"
        Me.OPCDAConfigurationToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.OPCDAConfigurationToolStripMenuItem.Text = "OPC DA Configuration"
        '
        'OPCHDAConfigurationToolStripMenuItem
        '
        Me.OPCHDAConfigurationToolStripMenuItem.Name = "OPCHDAConfigurationToolStripMenuItem"
        Me.OPCHDAConfigurationToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.OPCHDAConfigurationToolStripMenuItem.Text = "OPC HDA Configuration"
        '
        'AnnunciatorColorSettingToolStripMenuItem
        '
        Me.AnnunciatorColorSettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlarmSettingsToolStripMenuItem, Me.AudibleToolStripMenuItem})
        Me.AnnunciatorColorSettingToolStripMenuItem.Name = "AnnunciatorColorSettingToolStripMenuItem"
        Me.AnnunciatorColorSettingToolStripMenuItem.Size = New System.Drawing.Size(231, 30)
        Me.AnnunciatorColorSettingToolStripMenuItem.Text = "Annunciator Configuration"
        '
        'AlarmSettingsToolStripMenuItem
        '
        Me.AlarmSettingsToolStripMenuItem.Name = "AlarmSettingsToolStripMenuItem"
        Me.AlarmSettingsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AlarmSettingsToolStripMenuItem.Text = "Alarm Settings"
        '
        'AudibleToolStripMenuItem
        '
        Me.AudibleToolStripMenuItem.Name = "AudibleToolStripMenuItem"
        Me.AudibleToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AudibleToolStripMenuItem.Text = "Audible"
        '
        'Main_PrintMenu
        '
        Me.Main_PrintMenu.Image = CType(resources.GetObject("Main_PrintMenu.Image"), System.Drawing.Image)
        Me.Main_PrintMenu.Name = "Main_PrintMenu"
        Me.Main_PrintMenu.Size = New System.Drawing.Size(69, 28)
        Me.Main_PrintMenu.Text = "Print"
        Me.Main_PrintMenu.Visible = False
        '
        'CMS_showDBDataForm
        '
        Me.CMS_showDBDataForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_showDBDataForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_DBDataForm, Me.StartChannelToolStripMenuItem, Me.StopChannelToolStripMenuItem})
        Me.CMS_showDBDataForm.Name = "ContextMenuStrip1"
        Me.CMS_showDBDataForm.Size = New System.Drawing.Size(135, 94)
        '
        'MS_DBDataForm
        '
        Me.MS_DBDataForm.Image = CType(resources.GetObject("MS_DBDataForm.Image"), System.Drawing.Image)
        Me.MS_DBDataForm.Name = "MS_DBDataForm"
        Me.MS_DBDataForm.Size = New System.Drawing.Size(134, 30)
        Me.MS_DBDataForm.Text = "View Data"
        Me.MS_DBDataForm.Visible = False
        '
        'StartChannelToolStripMenuItem
        '
        Me.StartChannelToolStripMenuItem.Image = CType(resources.GetObject("StartChannelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartChannelToolStripMenuItem.Name = "StartChannelToolStripMenuItem"
        Me.StartChannelToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.StartChannelToolStripMenuItem.Text = "Run"
        '
        'StopChannelToolStripMenuItem
        '
        Me.StopChannelToolStripMenuItem.Image = CType(resources.GetObject("StopChannelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StopChannelToolStripMenuItem.Name = "StopChannelToolStripMenuItem"
        Me.StopChannelToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.StopChannelToolStripMenuItem.Text = "Stop"
        '
        'lblAlert
        '
        Me.lblAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlert.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAlert.Location = New System.Drawing.Point(1093, 387)
        Me.lblAlert.Name = "lblAlert"
        Me.lblAlert.Size = New System.Drawing.Size(49, 19)
        Me.lblAlert.TabIndex = 14
        Me.lblAlert.Text = "ALERT"
        Me.lblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogBookProperties
        '
        Me.LogBookProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.LogBookProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_LBProperties, Me.MS_LBClear, Me.ToolStripSeparator27, Me.MS_LBS_to_B, Me.MS_LBB_to_F, Me.ToolStripSeparator28, Me.MS_LBCut, Me.ToolStripSeparator29, Me.MS_LBPrint, Me.ToolStripSeparator30, Me.AutoUpdateToolStripMenuItem})
        Me.LogBookProperties.Name = "ContextMenuStrip1"
        Me.LogBookProperties.Size = New System.Drawing.Size(156, 238)
        '
        'MS_LBProperties
        '
        Me.MS_LBProperties.Image = CType(resources.GetObject("MS_LBProperties.Image"), System.Drawing.Image)
        Me.MS_LBProperties.Name = "MS_LBProperties"
        Me.MS_LBProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBProperties.Text = "Properties"
        '
        'MS_LBClear
        '
        Me.MS_LBClear.Image = CType(resources.GetObject("MS_LBClear.Image"), System.Drawing.Image)
        Me.MS_LBClear.Name = "MS_LBClear"
        Me.MS_LBClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBClear.Text = "Clear"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LBS_to_B
        '
        Me.MS_LBS_to_B.Image = CType(resources.GetObject("MS_LBS_to_B.Image"), System.Drawing.Image)
        Me.MS_LBS_to_B.Name = "MS_LBS_to_B"
        Me.MS_LBS_to_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBS_to_B.Text = "Send to Back"
        '
        'MS_LBB_to_F
        '
        Me.MS_LBB_to_F.Image = CType(resources.GetObject("MS_LBB_to_F.Image"), System.Drawing.Image)
        Me.MS_LBB_to_F.Name = "MS_LBB_to_F"
        Me.MS_LBB_to_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBB_to_F.Text = "Bring to Front"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LBCut
        '
        Me.MS_LBCut.Image = CType(resources.GetObject("MS_LBCut.Image"), System.Drawing.Image)
        Me.MS_LBCut.Name = "MS_LBCut"
        Me.MS_LBCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBCut.Text = "Cut"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LBPrint
        '
        Me.MS_LBPrint.Image = CType(resources.GetObject("MS_LBPrint.Image"), System.Drawing.Image)
        Me.MS_LBPrint.Name = "MS_LBPrint"
        Me.MS_LBPrint.Size = New System.Drawing.Size(155, 30)
        Me.MS_LBPrint.Text = "Print"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(152, 6)
        '
        'AutoUpdateToolStripMenuItem
        '
        Me.AutoUpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopToolStripMenuItem1})
        Me.AutoUpdateToolStripMenuItem.Name = "AutoUpdateToolStripMenuItem"
        Me.AutoUpdateToolStripMenuItem.Size = New System.Drawing.Size(155, 30)
        Me.AutoUpdateToolStripMenuItem.Text = "Auto Update"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem1
        '
        Me.StopToolStripMenuItem1.Enabled = False
        Me.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1"
        Me.StopToolStripMenuItem1.Size = New System.Drawing.Size(98, 22)
        Me.StopToolStripMenuItem1.Text = "Stop"
        '
        'PdocRText
        '
        '
        'PdocGrid
        '
        '
        'ButtonProperties
        '
        Me.ButtonProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ButtonProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_BtnProperties, Me.MS_BtnClear, Me.ToolStripSeparator32, Me.MS_BtnS_To_B, Me.MS_BtnB_To_F, Me.ToolStripSeparator33, Me.MS_Btn_Cut, Me.MS_Btn_Copy})
        Me.ButtonProperties.Name = "ContextMenuStrip1"
        Me.ButtonProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_BtnProperties
        '
        Me.MS_BtnProperties.Image = CType(resources.GetObject("MS_BtnProperties.Image"), System.Drawing.Image)
        Me.MS_BtnProperties.Name = "MS_BtnProperties"
        Me.MS_BtnProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_BtnProperties.Text = "Properties"
        '
        'MS_BtnClear
        '
        Me.MS_BtnClear.Image = CType(resources.GetObject("MS_BtnClear.Image"), System.Drawing.Image)
        Me.MS_BtnClear.Name = "MS_BtnClear"
        Me.MS_BtnClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_BtnClear.Text = "Clear"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(152, 6)
        '
        'MS_BtnS_To_B
        '
        Me.MS_BtnS_To_B.Image = CType(resources.GetObject("MS_BtnS_To_B.Image"), System.Drawing.Image)
        Me.MS_BtnS_To_B.Name = "MS_BtnS_To_B"
        Me.MS_BtnS_To_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_BtnS_To_B.Text = "Send to Back"
        '
        'MS_BtnB_To_F
        '
        Me.MS_BtnB_To_F.Image = CType(resources.GetObject("MS_BtnB_To_F.Image"), System.Drawing.Image)
        Me.MS_BtnB_To_F.Name = "MS_BtnB_To_F"
        Me.MS_BtnB_To_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_BtnB_To_F.Text = "Bring to Front"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(152, 6)
        '
        'MS_Btn_Cut
        '
        Me.MS_Btn_Cut.Image = CType(resources.GetObject("MS_Btn_Cut.Image"), System.Drawing.Image)
        Me.MS_Btn_Cut.Name = "MS_Btn_Cut"
        Me.MS_Btn_Cut.Size = New System.Drawing.Size(155, 30)
        Me.MS_Btn_Cut.Text = "Cut"
        '
        'MS_Btn_Copy
        '
        Me.MS_Btn_Copy.Image = CType(resources.GetObject("MS_Btn_Copy.Image"), System.Drawing.Image)
        Me.MS_Btn_Copy.Name = "MS_Btn_Copy"
        Me.MS_Btn_Copy.Size = New System.Drawing.Size(155, 30)
        Me.MS_Btn_Copy.Text = "Copy"
        '
        'tmrCheckConnectivity
        '
        Me.tmrCheckConnectivity.Interval = 30000
        '
        'CMS_ConnectServer
        '
        Me.CMS_ConnectServer.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_ConnectServer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectServerToolStripMenuItem})
        Me.CMS_ConnectServer.Name = "ContextMenuStrip1"
        Me.CMS_ConnectServer.Size = New System.Drawing.Size(163, 34)
        '
        'ConnectServerToolStripMenuItem
        '
        Me.ConnectServerToolStripMenuItem.Image = CType(resources.GetObject("ConnectServerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConnectServerToolStripMenuItem.Name = "ConnectServerToolStripMenuItem"
        Me.ConnectServerToolStripMenuItem.Size = New System.Drawing.Size(162, 30)
        Me.ConnectServerToolStripMenuItem.Text = "Connect Server"
        '
        'CMS_AddSAMA_Historianchannel
        '
        Me.CMS_AddSAMA_Historianchannel.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_AddSAMA_Historianchannel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEditChannelToolStripMenuItem})
        Me.CMS_AddSAMA_Historianchannel.Name = "CMS_AddSAMA_Historianchannel"
        Me.CMS_AddSAMA_Historianchannel.Size = New System.Drawing.Size(169, 26)
        '
        'AddEditChannelToolStripMenuItem
        '
        Me.AddEditChannelToolStripMenuItem.Name = "AddEditChannelToolStripMenuItem"
        Me.AddEditChannelToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddEditChannelToolStripMenuItem.Text = "Add/Edit Channel"
        '
        'CMS_ShowSAMAHistorianForm
        '
        Me.CMS_ShowSAMAHistorianForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_ShowSAMAHistorianForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.viewSAMAHistorianChnl, Me.RunSAMAHistorianChnl, Me.StopSAMAHistorianChnl})
        Me.CMS_ShowSAMAHistorianForm.Name = "ContextMenuStrip1"
        Me.CMS_ShowSAMAHistorianForm.Size = New System.Drawing.Size(135, 94)
        '
        'viewSAMAHistorianChnl
        '
        Me.viewSAMAHistorianChnl.Image = CType(resources.GetObject("viewSAMAHistorianChnl.Image"), System.Drawing.Image)
        Me.viewSAMAHistorianChnl.Name = "viewSAMAHistorianChnl"
        Me.viewSAMAHistorianChnl.Size = New System.Drawing.Size(134, 30)
        Me.viewSAMAHistorianChnl.Text = "View Data"
        '
        'RunSAMAHistorianChnl
        '
        Me.RunSAMAHistorianChnl.Image = CType(resources.GetObject("RunSAMAHistorianChnl.Image"), System.Drawing.Image)
        Me.RunSAMAHistorianChnl.Name = "RunSAMAHistorianChnl"
        Me.RunSAMAHistorianChnl.Size = New System.Drawing.Size(134, 30)
        Me.RunSAMAHistorianChnl.Text = "Run"
        '
        'StopSAMAHistorianChnl
        '
        Me.StopSAMAHistorianChnl.Image = CType(resources.GetObject("StopSAMAHistorianChnl.Image"), System.Drawing.Image)
        Me.StopSAMAHistorianChnl.Name = "StopSAMAHistorianChnl"
        Me.StopSAMAHistorianChnl.Size = New System.Drawing.Size(134, 30)
        Me.StopSAMAHistorianChnl.Text = "Stop"
        '
        'MultiTrendChartProperties
        '
        Me.MultiTrendChartProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MultiTrendChartProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MultitrendProperties, Me.ToolStripMenuItem3, Me.ToolStripSeparator31, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripSeparator38, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripSeparator39, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripSeparator40, Me.ToolStripMenuItem10})
        Me.MultiTrendChartProperties.Name = "ContextMenuStrip1"
        Me.MultiTrendChartProperties.Size = New System.Drawing.Size(162, 298)
        Me.MultiTrendChartProperties.Text = "MultitrendChartProperties"
        '
        'MultitrendProperties
        '
        Me.MultitrendProperties.Image = CType(resources.GetObject("MultitrendProperties.Image"), System.Drawing.Image)
        Me.MultitrendProperties.Name = "MultitrendProperties"
        Me.MultitrendProperties.Size = New System.Drawing.Size(161, 30)
        Me.MultitrendProperties.Text = "Properties"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem3.Text = "Clear"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(158, 6)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem4.Text = "Send to Back"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem5.Text = "Bring to Front"
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(158, 6)
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = CType(resources.GetObject("ToolStripMenuItem6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem6.Text = "Cut"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem7.Text = "Copy"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(158, 6)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem8.Text = "Printer Preview"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem9.Text = "Print"
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(158, 6)
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem11})
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(161, 30)
        Me.ToolStripMenuItem10.Text = "Export"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = CType(resources.GetObject("ToolStripMenuItem11.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(119, 22)
        Me.ToolStripMenuItem11.Text = "Jpeg File"
        '
        'SymbolsProperties
        '
        Me.SymbolsProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SymbolsProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_SymProperties, Me.MS_SymClear, Me.ToolStripSeparator43, Me.MS_SymS_To_B, Me.MS_SymB_To_F, Me.ToolStripSeparator44, Me.MS_SymCut, Me.MS_SymCopy})
        Me.SymbolsProperties.Name = "ContextMenuStrip1"
        Me.SymbolsProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_SymProperties
        '
        Me.MS_SymProperties.Image = CType(resources.GetObject("MS_SymProperties.Image"), System.Drawing.Image)
        Me.MS_SymProperties.Name = "MS_SymProperties"
        Me.MS_SymProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymProperties.Text = "Properties"
        '
        'MS_SymClear
        '
        Me.MS_SymClear.Image = CType(resources.GetObject("MS_SymClear.Image"), System.Drawing.Image)
        Me.MS_SymClear.Name = "MS_SymClear"
        Me.MS_SymClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymClear.Text = "Clear"
        '
        'ToolStripSeparator43
        '
        Me.ToolStripSeparator43.Name = "ToolStripSeparator43"
        Me.ToolStripSeparator43.Size = New System.Drawing.Size(152, 6)
        '
        'MS_SymS_To_B
        '
        Me.MS_SymS_To_B.Image = CType(resources.GetObject("MS_SymS_To_B.Image"), System.Drawing.Image)
        Me.MS_SymS_To_B.Name = "MS_SymS_To_B"
        Me.MS_SymS_To_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymS_To_B.Text = "Send to Back"
        '
        'MS_SymB_To_F
        '
        Me.MS_SymB_To_F.Image = CType(resources.GetObject("MS_SymB_To_F.Image"), System.Drawing.Image)
        Me.MS_SymB_To_F.Name = "MS_SymB_To_F"
        Me.MS_SymB_To_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymB_To_F.Text = "Bring to Front"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(152, 6)
        '
        'MS_SymCut
        '
        Me.MS_SymCut.Image = CType(resources.GetObject("MS_SymCut.Image"), System.Drawing.Image)
        Me.MS_SymCut.Name = "MS_SymCut"
        Me.MS_SymCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymCut.Text = "Cut"
        '
        'MS_SymCopy
        '
        Me.MS_SymCopy.Image = CType(resources.GetObject("MS_SymCopy.Image"), System.Drawing.Image)
        Me.MS_SymCopy.Name = "MS_SymCopy"
        Me.MS_SymCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_SymCopy.Text = "Copy"
        '
        'IndicatorProperties
        '
        Me.IndicatorProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.IndicatorProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_IndicatorProperties, Me.MS_IndicatorClear, Me.ToolStripSeparator41, Me.MS_IndicatorS_to_B, Me.MS_IndicatorB_To_F, Me.ToolStripSeparator42, Me.MS_IndicatorCut, Me.MS_IndicatorCopy})
        Me.IndicatorProperties.Name = "ContextMenuStrip1"
        Me.IndicatorProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_IndicatorProperties
        '
        Me.MS_IndicatorProperties.Image = CType(resources.GetObject("MS_IndicatorProperties.Image"), System.Drawing.Image)
        Me.MS_IndicatorProperties.Name = "MS_IndicatorProperties"
        Me.MS_IndicatorProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorProperties.Text = "Properties"
        '
        'MS_IndicatorClear
        '
        Me.MS_IndicatorClear.Image = CType(resources.GetObject("MS_IndicatorClear.Image"), System.Drawing.Image)
        Me.MS_IndicatorClear.Name = "MS_IndicatorClear"
        Me.MS_IndicatorClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorClear.Text = "Clear"
        '
        'ToolStripSeparator41
        '
        Me.ToolStripSeparator41.Name = "ToolStripSeparator41"
        Me.ToolStripSeparator41.Size = New System.Drawing.Size(152, 6)
        '
        'MS_IndicatorS_to_B
        '
        Me.MS_IndicatorS_to_B.Image = CType(resources.GetObject("MS_IndicatorS_to_B.Image"), System.Drawing.Image)
        Me.MS_IndicatorS_to_B.Name = "MS_IndicatorS_to_B"
        Me.MS_IndicatorS_to_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorS_to_B.Text = "Send to Back"
        '
        'MS_IndicatorB_To_F
        '
        Me.MS_IndicatorB_To_F.Image = CType(resources.GetObject("MS_IndicatorB_To_F.Image"), System.Drawing.Image)
        Me.MS_IndicatorB_To_F.Name = "MS_IndicatorB_To_F"
        Me.MS_IndicatorB_To_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorB_To_F.Text = "Bring to Front"
        '
        'ToolStripSeparator42
        '
        Me.ToolStripSeparator42.Name = "ToolStripSeparator42"
        Me.ToolStripSeparator42.Size = New System.Drawing.Size(152, 6)
        '
        'MS_IndicatorCut
        '
        Me.MS_IndicatorCut.Image = CType(resources.GetObject("MS_IndicatorCut.Image"), System.Drawing.Image)
        Me.MS_IndicatorCut.Name = "MS_IndicatorCut"
        Me.MS_IndicatorCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorCut.Text = "Cut"
        '
        'MS_IndicatorCopy
        '
        Me.MS_IndicatorCopy.Image = CType(resources.GetObject("MS_IndicatorCopy.Image"), System.Drawing.Image)
        Me.MS_IndicatorCopy.Name = "MS_IndicatorCopy"
        Me.MS_IndicatorCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_IndicatorCopy.Text = "Copy"
        '
        'ValveProperties
        '
        Me.ValveProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ValveProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_ValveProperties, Me.MS_ValveClear, Me.ToolStripSeparator45, Me.MS_ValveS_to_B, Me.MS_ValveB_to_F, Me.ToolStripSeparator46, Me.MS_ValveCut, Me.MS_ValveCopy})
        Me.ValveProperties.Name = "ContextMenuStrip1"
        Me.ValveProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_ValveProperties
        '
        Me.MS_ValveProperties.Image = CType(resources.GetObject("MS_ValveProperties.Image"), System.Drawing.Image)
        Me.MS_ValveProperties.Name = "MS_ValveProperties"
        Me.MS_ValveProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveProperties.Text = "Properties"
        '
        'MS_ValveClear
        '
        Me.MS_ValveClear.Image = CType(resources.GetObject("MS_ValveClear.Image"), System.Drawing.Image)
        Me.MS_ValveClear.Name = "MS_ValveClear"
        Me.MS_ValveClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveClear.Text = "Clear"
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(152, 6)
        '
        'MS_ValveS_to_B
        '
        Me.MS_ValveS_to_B.Image = CType(resources.GetObject("MS_ValveS_to_B.Image"), System.Drawing.Image)
        Me.MS_ValveS_to_B.Name = "MS_ValveS_to_B"
        Me.MS_ValveS_to_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveS_to_B.Text = "Send to Back"
        '
        'MS_ValveB_to_F
        '
        Me.MS_ValveB_to_F.Image = CType(resources.GetObject("MS_ValveB_to_F.Image"), System.Drawing.Image)
        Me.MS_ValveB_to_F.Name = "MS_ValveB_to_F"
        Me.MS_ValveB_to_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveB_to_F.Text = "Bring to Front"
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(152, 6)
        '
        'MS_ValveCut
        '
        Me.MS_ValveCut.Image = CType(resources.GetObject("MS_ValveCut.Image"), System.Drawing.Image)
        Me.MS_ValveCut.Name = "MS_ValveCut"
        Me.MS_ValveCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveCut.Text = "Cut"
        '
        'MS_ValveCopy
        '
        Me.MS_ValveCopy.Image = CType(resources.GetObject("MS_ValveCopy.Image"), System.Drawing.Image)
        Me.MS_ValveCopy.Name = "MS_ValveCopy"
        Me.MS_ValveCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_ValveCopy.Text = "Copy"
        '
        'SwitchProperties
        '
        Me.SwitchProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SwitchProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_SwitchProperties, Me.MS_SwitchClear, Me.ToolStripSeparator47, Me.MS_SwitchS_To_B, Me.MS_SwitchB_To_F, Me.ToolStripSeparator48, Me.MS_SwitchCut, Me.MS_SwitchCopy})
        Me.SwitchProperties.Name = "ContextMenuStrip1"
        Me.SwitchProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_SwitchProperties
        '
        Me.MS_SwitchProperties.Image = CType(resources.GetObject("MS_SwitchProperties.Image"), System.Drawing.Image)
        Me.MS_SwitchProperties.Name = "MS_SwitchProperties"
        Me.MS_SwitchProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchProperties.Text = "Properties"
        '
        'MS_SwitchClear
        '
        Me.MS_SwitchClear.Image = CType(resources.GetObject("MS_SwitchClear.Image"), System.Drawing.Image)
        Me.MS_SwitchClear.Name = "MS_SwitchClear"
        Me.MS_SwitchClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchClear.Text = "Clear"
        '
        'ToolStripSeparator47
        '
        Me.ToolStripSeparator47.Name = "ToolStripSeparator47"
        Me.ToolStripSeparator47.Size = New System.Drawing.Size(152, 6)
        '
        'MS_SwitchS_To_B
        '
        Me.MS_SwitchS_To_B.Image = CType(resources.GetObject("MS_SwitchS_To_B.Image"), System.Drawing.Image)
        Me.MS_SwitchS_To_B.Name = "MS_SwitchS_To_B"
        Me.MS_SwitchS_To_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchS_To_B.Text = "Send to Back"
        '
        'MS_SwitchB_To_F
        '
        Me.MS_SwitchB_To_F.Image = CType(resources.GetObject("MS_SwitchB_To_F.Image"), System.Drawing.Image)
        Me.MS_SwitchB_To_F.Name = "MS_SwitchB_To_F"
        Me.MS_SwitchB_To_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchB_To_F.Text = "Bring to Front"
        '
        'ToolStripSeparator48
        '
        Me.ToolStripSeparator48.Name = "ToolStripSeparator48"
        Me.ToolStripSeparator48.Size = New System.Drawing.Size(152, 6)
        '
        'MS_SwitchCut
        '
        Me.MS_SwitchCut.Image = CType(resources.GetObject("MS_SwitchCut.Image"), System.Drawing.Image)
        Me.MS_SwitchCut.Name = "MS_SwitchCut"
        Me.MS_SwitchCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchCut.Text = "Cut"
        '
        'MS_SwitchCopy
        '
        Me.MS_SwitchCopy.Image = CType(resources.GetObject("MS_SwitchCopy.Image"), System.Drawing.Image)
        Me.MS_SwitchCopy.Name = "MS_SwitchCopy"
        Me.MS_SwitchCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_SwitchCopy.Text = "Copy"
        '
        'LineProperties
        '
        Me.LineProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.LineProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_LineVProperties, Me.MS_LineVClear, Me.ToolStripSeparator49, Me.MS_LineVS_T_to_B, Me.MS_LineVB_to_F, Me.ToolStripSeparator50, Me.MS_LineVCut, Me.MS_LineVCopy})
        Me.LineProperties.Name = "ContextMenuStrip1"
        Me.LineProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_LineVProperties
        '
        Me.MS_LineVProperties.Image = CType(resources.GetObject("MS_LineVProperties.Image"), System.Drawing.Image)
        Me.MS_LineVProperties.Name = "MS_LineVProperties"
        Me.MS_LineVProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVProperties.Text = "Properties"
        '
        'MS_LineVClear
        '
        Me.MS_LineVClear.Image = CType(resources.GetObject("MS_LineVClear.Image"), System.Drawing.Image)
        Me.MS_LineVClear.Name = "MS_LineVClear"
        Me.MS_LineVClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVClear.Text = "Clear"
        '
        'ToolStripSeparator49
        '
        Me.ToolStripSeparator49.Name = "ToolStripSeparator49"
        Me.ToolStripSeparator49.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LineVS_T_to_B
        '
        Me.MS_LineVS_T_to_B.Image = CType(resources.GetObject("MS_LineVS_T_to_B.Image"), System.Drawing.Image)
        Me.MS_LineVS_T_to_B.Name = "MS_LineVS_T_to_B"
        Me.MS_LineVS_T_to_B.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVS_T_to_B.Text = "Send to Back"
        '
        'MS_LineVB_to_F
        '
        Me.MS_LineVB_to_F.Image = CType(resources.GetObject("MS_LineVB_to_F.Image"), System.Drawing.Image)
        Me.MS_LineVB_to_F.Name = "MS_LineVB_to_F"
        Me.MS_LineVB_to_F.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVB_to_F.Text = "Bring to Front"
        '
        'ToolStripSeparator50
        '
        Me.ToolStripSeparator50.Name = "ToolStripSeparator50"
        Me.ToolStripSeparator50.Size = New System.Drawing.Size(152, 6)
        '
        'MS_LineVCut
        '
        Me.MS_LineVCut.Image = CType(resources.GetObject("MS_LineVCut.Image"), System.Drawing.Image)
        Me.MS_LineVCut.Name = "MS_LineVCut"
        Me.MS_LineVCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVCut.Text = "Cut"
        '
        'MS_LineVCopy
        '
        Me.MS_LineVCopy.Image = CType(resources.GetObject("MS_LineVCopy.Image"), System.Drawing.Image)
        Me.MS_LineVCopy.Name = "MS_LineVCopy"
        Me.MS_LineVCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_LineVCopy.Text = "Copy"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "generatedRpt.png")
        Me.ImageList1.Images.SetKeyName(1, "folder.png")
        Me.ImageList1.Images.SetKeyName(2, "16x16-excel.png")
        Me.ImageList1.Images.SetKeyName(3, "pdf.png")
        Me.ImageList1.Images.SetKeyName(4, "html.png")
        Me.ImageList1.Images.SetKeyName(5, "adva.png")
        Me.ImageList1.Images.SetKeyName(6, "std.png")
        Me.ImageList1.Images.SetKeyName(7, "Template.png")
        Me.ImageList1.Images.SetKeyName(8, "newtempl.png")
        Me.ImageList1.Images.SetKeyName(9, "datasource.png")
        Me.ImageList1.Images.SetKeyName(10, "odbc.png")
        Me.ImageList1.Images.SetKeyName(11, "Historian_Male_Dark.png")
        Me.ImageList1.Images.SetKeyName(12, "opc.png")
        '
        'OPCWriterProperties
        '
        Me.OPCWriterProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.OPCWriterProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem12, Me.ToolStripSeparator51, Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripSeparator52, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16})
        Me.OPCWriterProperties.Name = "ContextMenuStrip1"
        Me.OPCWriterProperties.Size = New System.Drawing.Size(156, 196)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem2.Text = "Properties"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Image = CType(resources.GetObject("ToolStripMenuItem12.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem12.Text = "Clear"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(152, 6)
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Image = CType(resources.GetObject("ToolStripMenuItem13.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem13.Text = "Send to Back"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Image = CType(resources.GetObject("ToolStripMenuItem14.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem14.Text = "Bring to Front"
        '
        'ToolStripSeparator52
        '
        Me.ToolStripSeparator52.Name = "ToolStripSeparator52"
        Me.ToolStripSeparator52.Size = New System.Drawing.Size(152, 6)
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Image = CType(resources.GetObject("ToolStripMenuItem15.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem15.Text = "Cut"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Image = CType(resources.GetObject("ToolStripMenuItem16.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(155, 30)
        Me.ToolStripMenuItem16.Text = "Copy"
        '
        'CMS_AddOPCDA
        '
        Me.CMS_AddOPCDA.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_AddOPCDA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem17})
        Me.CMS_AddOPCDA.Name = "CMS_AddSAMA_Historianchannel"
        Me.CMS_AddOPCDA.Size = New System.Drawing.Size(169, 26)
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(168, 22)
        Me.ToolStripMenuItem17.Text = "Add/Edit Channel"
        '
        'CMS_AddOPCHDA
        '
        Me.CMS_AddOPCHDA.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_AddOPCHDA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem18})
        Me.CMS_AddOPCHDA.Name = "CMS_AddSAMA_Historianchannel"
        Me.CMS_AddOPCHDA.Size = New System.Drawing.Size(169, 26)
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(168, 22)
        Me.ToolStripMenuItem18.Text = "Add/Edit Channel"
        '
        'CMS_ShowOPCDAForm
        '
        Me.CMS_ShowOPCDAForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_ShowOPCDAForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem19, Me.ToolStripMenuItem20, Me.ToolStripMenuItem21})
        Me.CMS_ShowOPCDAForm.Name = "ContextMenuStrip1"
        Me.CMS_ShowOPCDAForm.Size = New System.Drawing.Size(135, 94)
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Image = CType(resources.GetObject("ToolStripMenuItem19.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem19.Text = "View Data"
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Image = CType(resources.GetObject("ToolStripMenuItem20.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        Me.ToolStripMenuItem20.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem20.Text = "Run"
        Me.ToolStripMenuItem20.Visible = False
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Image = CType(resources.GetObject("ToolStripMenuItem21.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        Me.ToolStripMenuItem21.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem21.Text = "Stop"
        Me.ToolStripMenuItem21.Visible = False
        '
        'CMS_ShowOPCHDAForm
        '
        Me.CMS_ShowOPCHDAForm.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_ShowOPCHDAForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem22, Me.ToolStripMenuItem23, Me.ToolStripMenuItem24})
        Me.CMS_ShowOPCHDAForm.Name = "ContextMenuStrip1"
        Me.CMS_ShowOPCHDAForm.Size = New System.Drawing.Size(135, 94)
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Image = CType(resources.GetObject("ToolStripMenuItem22.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        Me.ToolStripMenuItem22.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem22.Text = "View Data"
        '
        'ToolStripMenuItem23
        '
        Me.ToolStripMenuItem23.Image = CType(resources.GetObject("ToolStripMenuItem23.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem23.Name = "ToolStripMenuItem23"
        Me.ToolStripMenuItem23.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem23.Text = "Run"
        Me.ToolStripMenuItem23.Visible = False
        '
        'ToolStripMenuItem24
        '
        Me.ToolStripMenuItem24.Image = CType(resources.GetObject("ToolStripMenuItem24.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem24.Name = "ToolStripMenuItem24"
        Me.ToolStripMenuItem24.Size = New System.Drawing.Size(134, 30)
        Me.ToolStripMenuItem24.Text = "Stop"
        Me.ToolStripMenuItem24.Visible = False
        '
        'AnnunciatorProperties
        '
        Me.AnnunciatorProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.AnnunciatorProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_AnnunciatorProperties, Me.MS_AnnunciatorClear, Me.ToolStripSeparator53, Me.MS_AnnunciatorSentoback, Me.MS_AnnunciatorBtoF, Me.ToolStripSeparator54, Me.MS_AnnunciatorCut, Me.MS_AnnunciatorCopy})
        Me.AnnunciatorProperties.Name = "ContextMenuStrip1"
        Me.AnnunciatorProperties.Size = New System.Drawing.Size(156, 196)
        '
        'MS_AnnunciatorProperties
        '
        Me.MS_AnnunciatorProperties.Image = CType(resources.GetObject("MS_AnnunciatorProperties.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorProperties.Name = "MS_AnnunciatorProperties"
        Me.MS_AnnunciatorProperties.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorProperties.Text = "Properties"
        '
        'MS_AnnunciatorClear
        '
        Me.MS_AnnunciatorClear.Image = CType(resources.GetObject("MS_AnnunciatorClear.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorClear.Name = "MS_AnnunciatorClear"
        Me.MS_AnnunciatorClear.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorClear.Text = "Clear"
        '
        'ToolStripSeparator53
        '
        Me.ToolStripSeparator53.Name = "ToolStripSeparator53"
        Me.ToolStripSeparator53.Size = New System.Drawing.Size(152, 6)
        '
        'MS_AnnunciatorSentoback
        '
        Me.MS_AnnunciatorSentoback.Image = CType(resources.GetObject("MS_AnnunciatorSentoback.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorSentoback.Name = "MS_AnnunciatorSentoback"
        Me.MS_AnnunciatorSentoback.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorSentoback.Text = "Send to Back"
        '
        'MS_AnnunciatorBtoF
        '
        Me.MS_AnnunciatorBtoF.Image = CType(resources.GetObject("MS_AnnunciatorBtoF.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorBtoF.Name = "MS_AnnunciatorBtoF"
        Me.MS_AnnunciatorBtoF.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorBtoF.Text = "Bring to Front"
        '
        'ToolStripSeparator54
        '
        Me.ToolStripSeparator54.Name = "ToolStripSeparator54"
        Me.ToolStripSeparator54.Size = New System.Drawing.Size(152, 6)
        '
        'MS_AnnunciatorCut
        '
        Me.MS_AnnunciatorCut.Image = CType(resources.GetObject("MS_AnnunciatorCut.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorCut.Name = "MS_AnnunciatorCut"
        Me.MS_AnnunciatorCut.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorCut.Text = "Cut"
        '
        'MS_AnnunciatorCopy
        '
        Me.MS_AnnunciatorCopy.Image = CType(resources.GetObject("MS_AnnunciatorCopy.Image"), System.Drawing.Image)
        Me.MS_AnnunciatorCopy.Name = "MS_AnnunciatorCopy"
        Me.MS_AnnunciatorCopy.Size = New System.Drawing.Size(155, 30)
        Me.MS_AnnunciatorCopy.Text = "Copy"
        '
        'MChartProperties
        '
        Me.MChartProperties.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MChartProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DMS_ChartProperties, Me.DMS_ChartClear, Me.ToolStripSeparator55, Me.SendToBackToolStripMenuItem, Me.BringToFrontToolStripMenuItem, Me.ToolStripSeparator56, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.ToolStripSeparator57, Me.PrinterPreviewToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ToolStripSeparator58, Me.ExportToolStripMenuItem1})
        Me.MChartProperties.Name = "MChartPropertise"
        Me.MChartProperties.Size = New System.Drawing.Size(181, 248)
        '
        'DMS_ChartProperties
        '
        Me.DMS_ChartProperties.Name = "DMS_ChartProperties"
        Me.DMS_ChartProperties.Size = New System.Drawing.Size(180, 22)
        Me.DMS_ChartProperties.Text = "Properties"
        '
        'DMS_ChartClear
        '
        Me.DMS_ChartClear.Name = "DMS_ChartClear"
        Me.DMS_ChartClear.Size = New System.Drawing.Size(180, 22)
        Me.DMS_ChartClear.Text = "Clear"
        '
        'ToolStripSeparator55
        '
        Me.ToolStripSeparator55.Name = "ToolStripSeparator55"
        Me.ToolStripSeparator55.Size = New System.Drawing.Size(177, 6)
        '
        'SendToBackToolStripMenuItem
        '
        Me.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem"
        Me.SendToBackToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SendToBackToolStripMenuItem.Text = "Send To Back"
        '
        'BringToFrontToolStripMenuItem
        '
        Me.BringToFrontToolStripMenuItem.Name = "BringToFrontToolStripMenuItem"
        Me.BringToFrontToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BringToFrontToolStripMenuItem.Text = "Bring To Front"
        '
        'ToolStripSeparator56
        '
        Me.ToolStripSeparator56.Name = "ToolStripSeparator56"
        Me.ToolStripSeparator56.Size = New System.Drawing.Size(177, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'ToolStripSeparator57
        '
        Me.ToolStripSeparator57.Name = "ToolStripSeparator57"
        Me.ToolStripSeparator57.Size = New System.Drawing.Size(177, 6)
        '
        'PrinterPreviewToolStripMenuItem
        '
        Me.PrinterPreviewToolStripMenuItem.Name = "PrinterPreviewToolStripMenuItem"
        Me.PrinterPreviewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrinterPreviewToolStripMenuItem.Text = "Printer Preview"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator58
        '
        Me.ToolStripSeparator58.Name = "ToolStripSeparator58"
        Me.ToolStripSeparator58.Size = New System.Drawing.Size(177, 6)
        '
        'ExportToolStripMenuItem1
        '
        Me.ExportToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JpecToolStripMenuItem})
        Me.ExportToolStripMenuItem1.Name = "ExportToolStripMenuItem1"
        Me.ExportToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ExportToolStripMenuItem1.Text = "Export"
        '
        'JpecToolStripMenuItem
        '
        Me.JpecToolStripMenuItem.Name = "JpecToolStripMenuItem"
        Me.JpecToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.JpecToolStripMenuItem.Text = "jpeg Type"
        '
        'MainPage
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(799, 408)
        Me.Controls.Add(Me.lblAlert)
        Me.Controls.Add(Me.Main_STContainer)
        Me.Controls.Add(Me.MSMenu)
        Me.Controls.Add(Me.SS_Analyzer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "SAMA Analyzer - Untitled"
        Me.Text = "SAMA RT Client - Untitled"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GuageProperties.ResumeLayout(False)
        Me.ContextMenuStripPages.ResumeLayout(False)
        Me.labelProperties.ResumeLayout(False)
        Me.MSDisplayValueLabel.ResumeLayout(False)
        Me.ChartProperties.ResumeLayout(False)
        Me.PageProperties.ResumeLayout(False)
        Me.GridTableProperties.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Main_STContainer.ContentPanel.ResumeLayout(False)
        Me.Main_STContainer.ResumeLayout(False)
        Me.Main_STContainer.PerformLayout()
        Me.CMS_Add_SupraDB_Channel.ResumeLayout(False)
        Me.PanelProperties.ResumeLayout(False)
        Me.PicBoxProperties.ResumeLayout(False)
        Me.CMS_AddOPC_Channel.ResumeLayout(False)
        Me.CMS_ShowDataForm.ResumeLayout(False)
        CType(Me.MainErrorPV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SS_Analyzer.ResumeLayout(False)
        Me.SS_Analyzer.PerformLayout()
        Me.MSMenu.ResumeLayout(False)
        Me.MSMenu.PerformLayout()
        Me.CMS_showDBDataForm.ResumeLayout(False)
        Me.LogBookProperties.ResumeLayout(False)
        Me.ButtonProperties.ResumeLayout(False)
        Me.CMS_ConnectServer.ResumeLayout(False)
        Me.CMS_AddSAMA_Historianchannel.ResumeLayout(False)
        Me.CMS_ShowSAMAHistorianForm.ResumeLayout(False)
        Me.MultiTrendChartProperties.ResumeLayout(False)
        Me.SymbolsProperties.ResumeLayout(False)
        Me.IndicatorProperties.ResumeLayout(False)
        Me.ValveProperties.ResumeLayout(False)
        Me.SwitchProperties.ResumeLayout(False)
        Me.LineProperties.ResumeLayout(False)
        Me.OPCWriterProperties.ResumeLayout(False)
        Me.CMS_AddOPCDA.ResumeLayout(False)
        Me.CMS_AddOPCHDA.ResumeLayout(False)
        Me.CMS_ShowOPCDAForm.ResumeLayout(False)
        Me.CMS_ShowOPCHDAForm.ResumeLayout(False)
        Me.AnnunciatorProperties.ResumeLayout(False)
        Me.MChartProperties.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GuageProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_GuagePropertie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_GuageClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripPages As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_PageProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents labelProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_LabelPropertie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LabelClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MSDisplayValueLabel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_ValueLabelPropertie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValueLabelClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printDOCCurrReport As System.Drawing.Printing.PrintDocument
    Friend WithEvents MS_ValueLabelSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValueLabelBringToFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_GuageSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_GuageBringToFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LabelSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LabelBringToFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChartProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_ChartProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartBringToFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_ValueLabelCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValueLabelCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_GuageCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_GuageCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LabelCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LabelCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_ChartCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_PagePropertie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_PagePaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridTableProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_TableProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_TableClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_TableSendToBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_TableBringtoFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_TableCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_TableCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PageTreeView As System.Windows.Forms.TreeView
    Friend WithEvents Main_STContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents pnlPage5 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage4 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage3 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage2 As System.Windows.Forms.Panel
    Friend WithEvents CMS_Add_SupraDB_Channel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_ChannelAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_pnlProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_pnlClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_pnlSentoback As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_BtoF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_PanelCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_PanelCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Pic_Properties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBox_Clear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicBox_StoB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBox_BtoF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicBox_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBox_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_AddOPC_Channel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_OPCChannelAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_ShowDataForm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainErrorPV As System.Windows.Forms.ErrorProvider
    Friend WithEvents imagelistMain As System.Windows.Forms.ImageList
    Friend WithEvents pnlPage6 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage10 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage9 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage8 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage7 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage20 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage19 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage18 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage17 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage16 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage15 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage14 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage13 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage12 As System.Windows.Forms.Panel
    Friend WithEvents pnlPage11 As System.Windows.Forms.Panel
    Friend WithEvents MS_AddPage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_DeletePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_TablePrinterSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_TablePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartPrinterSetting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_ChartExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ChartExpo_Img As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_TableExpo_Csv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintDoc_Table As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDoc_Chart As System.Drawing.Printing.PrintDocument
    Friend WithEvents pnlPage1 As System.Windows.Forms.Panel
    Friend WithEvents SS_Analyzer As System.Windows.Forms.StatusStrip
    Friend WithEvents MSMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents Main_PrintMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_ToolBoxMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ValueLabelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Chart2DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicturePanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSPagelbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSPoslbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CMS_showDBDataForm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_DBDataForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesignModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaskSchedulerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblAlert As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HideGridLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowGridLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Chart3DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogBookProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_LBProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LBClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LBS_to_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LBB_to_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LBCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LBPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PdocRText As System.Drawing.Printing.PrintDocument
    Friend WithEvents PdocGrid As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AutoUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_BtnProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_BtnClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_BtnS_To_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_BtnB_To_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_Btn_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_Btn_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoStartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_OpenMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Main_SaveMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Main_SaveAsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCheckConnectivity As System.Windows.Forms.Timer
    Friend WithEvents Main_DocumentSettingsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMS_ConnectServer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ConnectServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator37 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EMailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents CMS_AddSAMA_Historianchannel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddEditChannelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_ShowSAMAHistorianForm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents viewSAMAHistorianChnl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunSAMAHistorianChnl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopSAMAHistorianChnl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultiTrendChartProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MultitrendProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SymbolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContainersAndVesselsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DistillationTowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JacketedVesselToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReactorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VesselToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StorageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtmosphericTankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FloatingRoofTankToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GasHolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PressureStorageVesselToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeighHopperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElectricalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CircuitBreakerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualContactorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeltaConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FuseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MotorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StateIndicatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WyeConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquidFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VacuumFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HeatTransferDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExchangerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForcedAirExchangerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FurnaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotaryKilnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HVACToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoolingTowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EvaporatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinnedExchangerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialHandlingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConveyorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RollStandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotaryFeederToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScrewConveyorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MixingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgitatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InlineMixerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotatingEquipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompressorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PumpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TurbineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeparatorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CycloneSeparatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotarySeparatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SprayDryerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReciprocatingEquipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReciprocatingCompressorOrPumpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValvesAndActuatorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SymbolsProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_SymProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SymClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator43 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_SymS_To_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SymB_To_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator44 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_SymCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SymCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndicatorProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_IndicatorProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_IndicatorClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator41 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_IndicatorS_to_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_IndicatorB_To_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator42 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_IndicatorCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_IndicatorCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValveProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_ValveProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValveClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator45 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_ValveS_to_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValveB_to_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator46 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_ValveCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_ValveCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SwitchProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_SwitchProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SwitchClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator47 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_SwitchS_To_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SwitchB_To_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator48 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_SwitchCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_SwitchCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MS_LineVProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LineVClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator49 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LineVS_T_to_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LineVB_to_F As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator50 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MS_LineVCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MS_LineVCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelIndicatorMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeViewLeft As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents OPCWriterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OPCWriterProperties As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator51 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator52 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem15 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents ResetTotalizerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMS_AddOPCDA As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem17 As ToolStripMenuItem
    Friend WithEvents CMS_AddOPCHDA As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem18 As ToolStripMenuItem
    Friend WithEvents OPCDAConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OPCHDAConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMS_ShowOPCDAForm As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem19 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem21 As ToolStripMenuItem
    Friend WithEvents CMS_ShowOPCHDAForm As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem22 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem23 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem24 As ToolStripMenuItem
    Friend WithEvents OPCHDAQueryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnnunciatorWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnnunciatorProperties As ContextMenuStrip
    Friend WithEvents MS_AnnunciatorProperties As ToolStripMenuItem
    Friend WithEvents MS_AnnunciatorClear As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator53 As ToolStripSeparator
    Friend WithEvents MS_AnnunciatorSentoback As ToolStripMenuItem
    Friend WithEvents MS_AnnunciatorBtoF As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator54 As ToolStripSeparator
    Friend WithEvents MS_AnnunciatorCut As ToolStripMenuItem
    Friend WithEvents MS_AnnunciatorCopy As ToolStripMenuItem
    Friend WithEvents AnnunciatorColorSettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlarmSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AudibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MORSChartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MChartProperties As ContextMenuStrip
    Friend WithEvents DMS_ChartProperties As ToolStripMenuItem
    Friend WithEvents DMS_ChartClear As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator55 As ToolStripSeparator
    Friend WithEvents SendToBackToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BringToFrontToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator56 As ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator57 As ToolStripSeparator
    Friend WithEvents PrinterPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator58 As ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents JpecToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
End Class
