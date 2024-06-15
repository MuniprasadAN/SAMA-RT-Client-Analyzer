' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-13-2014
' ***********************************************************************
' <copyright file="MainPage.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports OPC
Imports OPCDA.NET
Imports NAudio.Wave
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text
Imports System.Security.Permissions
Imports System.Security.AccessControl
Imports System.Net
Imports System.Diagnostics
Imports System.ComponentModel
Imports SAMAAnalyzer.CtrlCloneTst
Imports ch = DevExpress.XtraCharts
Imports OPCDA
'Imports DevExpress.XtraCharts

Public Class MainPage

#Region "VariableDeclarations"

    Public Const STATIC_SERIES_LAMBDA = 1
    Public Const X_AXIS_MIN_VALUE = 100
    Public Const X_AXIS_MAX_VALUE = 1000
    Public Const Y_AXIS_MIN_VALUE = 1700
    Public Const Y_AXIS_MAX_VALUE = 2400

    Friend Constr As String = ""
    Private Page_Ctrl As New Panel
    Friend Grid_TableCtrl As New DataGridViewCtrl
    Friend Annunciator_Ctrl As New AnnunciatorCtrl
    Friend Guage_Ctrl As New AnalyzerMeter.AGauge
    Friend Label_Ctrl As New Label
    Friend Button_Ctrl As New Button_Control
    Friend ValueLabel_Ctrl As New LabelValue
    Friend Trender_Ctrl As New MultiTrendCtrl
    Friend Chart_Ctrl As New ChartControl
    Friend MChart_Ctrl As New MChartControl
    Friend OPCWrite_Ctrl As New OPCWriterControl
    Friend Panel_Ctrl As New Panel
    Friend PictureBox_Ctrl As New PictureBox
    Private Ctrl_MinSize As New Size(20, 20)
    Private Annunciator_Ctrl_MinSize As New Size(50, 50)
    Private GridCtrl_MinSize As New Size(40, 40)

    Private Ctrl_NameList As New List(Of String)
    Private Past_Ctrl As New Control
    Private _iniChartName As Integer = 1, _iniLabelName As Integer = 1, _iniTableName As Integer = 1, _iniAnnunciatorName As Integer = 1,
     _iniValuelabelName As Integer = 1, _iniGuageName As Integer = 1, _iniPanelName As Integer, _iniPicName As Integer = 1, _iniButtonName As Integer = 1, _iniTrenderName As Integer = 1, _iniOPCWriterName As Integer = 1, _iniMchartName As Integer = 1
    Public _iniPageName As Integer = 0
    Friend modify As Boolean
    Friend SltPageIndex As String
    Private blnguageDrag = False
    Private blnLabelDrag = False
    Private pageidx As Integer
    Friend dragging As Boolean
    Private Child As New TreeNode
    Private dt As New DataTable
    Private ds As New DataSet


    Private oldX, OldY As Single 'Cursor Loc
    Private blnCngcolor As Boolean
    Private blnsound As Boolean

    Private blnCopy As Boolean
    Private blnCut As Boolean
    Private blnPaste As Boolean

    Private GuageProp_Form As New GuageValueFromUser
    Private LabelProp_Form As New LabelPropertiesForm
    Private DisValueLabelProp_Form As New DisplayvalueLabelPropertiesForm
    Private ChartProp_Form As New ChartPropertiesForm
    Private MChartProp_Form As New MChartPropertiesFormNew
    Private MultitrendChartProp_Form As New MultiTrendChartProperties
    Private LvlIndicatorProp_form As New IndicatorProperties
    Private LineProp_form As New LinePropertiesForm
    Private ValveProp_Form As New ValvePropertiesForm

    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4

    Friend channelList As New ChannelList
    Friend OPC_ChannelList_Class As New OpcChannelListClass
    Friend OPC_Servers() As OpcServer = Nothing
    Friend opcCnfgTags() As DataForm = Nothing
    Friend DBDataFormClass() As DBDataForm = Nothing

    Friend SAMAHistorian_ChannelList As New SAMAHistorianChannelList

    Friend OPCDAServersList As New OPCDAServersList
    Friend OPCHDAServersList As New OPCHDAServersList

    Public Shared OPCDAChannelsList As New OPCDAChannelsList
    Public Shared OPCHDAChannelsList As New OPCHDAChannelsList

    Public OPCDAServersCollection As New Dictionary(Of String, Object)
    Public OPCHDAServersCollection As New Dictionary(Of String, Object)

    Friend OPC_ServeNames() As String = Nothing
    Private aProgIds As String() = Nothing
    Friend Lst_Display_fields, Lst_TableName, Lst_Where, Lst_GroupBy, Lst_XaxisName, Lst_YaxisName As New List(Of String)
    Private PrintGrid As DataGridViewPrinter
    Friend Server_Flag As Boolean = True
    Friend _errLog As New List(Of String)
    Friend Task_ScheduleList As New List(Of String)
    Friend Task_scheduleClassList() As TaskScheduleClass


    Friend LogCtrl As New LogViewer
    Private LogBookPrintGrid As LogViewerDataGridViewPrinter
    Private _iniLogBookName As Integer = 1
    Private _runMode As Boolean

    Friend blnOPC_AllowClients As Boolean
    Friend blnDB_AllowClients As Boolean

    Friend bln_OPCSource As Boolean
    Friend bln_DBSource As Boolean

    Friend _serverIP As String
    Friend _AutoReconnect As Boolean
    Friend Storage_Loc As String
    Friend Server_PushDataPath As String
    Friend Server_PullDataPath As String
    Friend _oldPass As String
    Friend _NewPass As String
    Friend _RetypePass As String


    Friend EmailSetting As New List(Of String)

    'Symbol
    Private _iniindicatorName As Integer = 0, _iniLineName As Integer = 0, _iniValveName As Integer = 0
    Friend LevelIndicator_ctrl As New LevelIndicator
    Friend Line_Ctrl As New LineElbow
    Friend Valve_Ctrl As New Valve

    Friend _tgNamesAIMS As New ArrayList
    Friend _tgNames As New ArrayList
    Public Shared TagNames As New ArrayList

    Friend Shared _ChannelIds As New ArrayList
    Friend _DbLocation As String
    Private CsvFileWatchTimer As Timer
    '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> 

    Friend _IsAdmin As Boolean
    Friend _IsSimpleUser As Boolean
    Friend _IsPowerUser As Boolean
    Friend CurrentUser As String
    Public _IsSuperAdmin As Boolean

    Public Access_Level As String
    Public Access_Rules As String
    Public Shared CreatedPages As New List(Of String)
    Private ReportLocation As String
    Friend pageprevname As String
    Public RemoteOPCServer As String

    Public tagdictionary As New Dictionary(Of String, Integer)
    'Devexpress chart events
    Private defCursor As System.Windows.Forms.Cursor
    Private _dragging As Boolean = False
    Private chart As MChartControl
    Private diagram As DevExpress.XtraCharts.XYDiagram
    Private line As DevExpress.XtraCharts.ConstantLine
#End Region

    Private Enum EdgeEnum 'Enum for Controls resize
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum


    ''' <summary>
    ''' Finction to Get the SQL Connection String from Connection.Config File
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetConString() As String
        'GEt Query string from COnnection File
        Try
            If IO.File.Exists(Application.StartupPath & "\" & "Connection.SupraConfig") Then
                Dim strfl As New StreamReader(Application.StartupPath & "\" & "Connection.SupraConfig")
                Dim tmp As String = ""
                Dim st As String = ""
                Dim kk As Integer = 1
                Dim dt As String = ""
                Do Until strfl.EndOfStream
                    tmp = strfl.ReadLine()
                    If kk = 1 Then
                        st = tmp
                    ElseIf kk = 2 Then
                        dt = tmp
                    End If
                    kk += 1
                Loop
                strfl.Close()
                AppDomain.CurrentDomain.SetData("DataDirectory", dt)
                Return st
            Else
                _errLog.Add("Info@" & Now.ToString & "@Connection String File Not Found !!!@GetConString()")
                Return ""
            End If


        Catch ex As FileNotFoundException
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GetConString()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
        Return ""

    End Function
    Private CurrServerState As Boolean
    Private PrevServerState As Boolean = True
    Private Sub tmrCheckConnectivity_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheckConnectivity.Tick

        Try
            If My.Computer.Network.Ping(_serverIP) Then
                CurrServerState = True
                If CurrServerState = True AndAlso PrevServerState = False Then
                    Call RefreshDBChannel()
                    Call RefreshOPC_Channel()
                    MainErrorPV.Clear()
                    _errLog.Add("Error@" & Now.ToString & "@ Server ReConnected Success !!!@")
                    CurrServerState = True
                    PrevServerState = True
                End If
            Else
                _errLog.Add("Error@" & Now.ToString & "@ Server Disconnected @tmrCheckConnectivity_Tick()")
                MainErrorPV.SetError(lblAlert, "Server Disconnected !!!")
                PrevServerState = False
                CurrServerState = False
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@ Server Disconnected @tmrCheckConnectivity_Tick()")
            MainErrorPV.SetError(lblAlert, "Server Disconnected !!!")
            CurrServerState = False
            PrevServerState = False
        End Try

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            createuserconfig()
            Dim login As New LoginForm
            login.Text = "Login"
            login.ShowDialog()
            CheckForIllegalCrossThreadCalls = False
            If _IsSimpleUser Then
                Main_ToolBoxMenu.Visible = False
                'SettingsToolStripMenuItem.Visible = False
                UsersToolStripMenuItem.Enabled = False
                SymbolsToolStripMenuItem.Visible = False
                Main_SaveMenu.Visible = False
                Main_SaveAsMenu.Visible = False
                AutoStartToolStripMenuItem.Visible = False
                UsersToolStripMenuItem.Visible = False

            ElseIf _IsPowerUser Then
                'SettingsToolStripMenuItem.Visible = False
                UsersToolStripMenuItem.Enabled = False
            ElseIf _IsAdmin Then
                UsersToolStripMenuItem.Enabled = False
            ElseIf _IsSuperAdmin Then
                UsersToolStripMenuItem.Enabled = True
            End If

            Server_PullDataPath = Application.StartupPath
            Server_PushDataPath = Application.StartupPath
            Storage_Loc = Application.StartupPath

            If Server_Flag Then
                Me.Text = "SAMA RT Client - Untitled  [Server]"
            Else
                Me.Text = "SAMA RT Client - Untitled  [Client]"
            End If
            Me.KeyPreview = True

            Child = New TreeNode("SAMA RT Client  ")

            Child.Nodes.Add("SAMA Channels")
            Child.Nodes.Add("OPC Channels")

            '  Child.Nodes.Add("Pages")
            Child.Nodes.Add("OPC Historian")

            Child.Nodes.Add("OPC DA")
            Child.Nodes.Add("OPC HDA")
            ' Child.Nodes(2).Nodes.Add("Page1")
            ' Child.Nodes(2).Nodes.Add("Page2")
            PageTreeView.Nodes.Add(Child)

            PageTreeView.ImageList = imagelistMain 'Set Image to Tree Node
            PageTreeView.Nodes(0).ImageIndex = 0
            PageTreeView.Nodes(0).SelectedImageIndex = 0
            PageTreeView.Nodes(0).Nodes(0).ImageIndex = 1
            PageTreeView.Nodes(0).Nodes(1).ImageIndex = 2
            PageTreeView.Nodes(0).Nodes(2).ImageIndex = 2
            PageTreeView.Nodes(0).Nodes(3).ImageIndex = 2
            PageTreeView.Nodes(0).Nodes(4).ImageIndex = 2
            '  PageTreeView.Nodes(0).Nodes(3).ImageIndex = 2
            PageTreeView.Nodes(0).Nodes(0).SelectedImageIndex = 1
            PageTreeView.Nodes(0).Nodes(1).SelectedImageIndex = 2
            PageTreeView.Nodes(0).Nodes(2).SelectedImageIndex = 2
            PageTreeView.Nodes(0).Nodes(3).SelectedImageIndex = 2
            PageTreeView.Nodes(0).Nodes(4).SelectedImageIndex = 2
            '  PageTreeView.Nodes(0).Nodes(3).SelectedImageIndex = 2
            'Node font setting

            Dim font = New Font("Verdana", 9, FontStyle.Bold)
            PageTreeView.Nodes(0).NodeFont = fontvueFrequency
            PageTreeView.Nodes(0).Nodes(0).NodeFont = New Font("Verdana", 9, FontStyle.Bold)
            PageTreeView.Nodes(0).Nodes(1).NodeFont = New Font("Verdana", 9, FontStyle.Bold)
            PageTreeView.Nodes(0).Nodes(2).NodeFont = New Font("Verdana", 9, FontStyle.Bold)
            PageTreeView.Nodes(0).Nodes(3).NodeFont = New Font("Verdana", 9, FontStyle.Bold)
            PageTreeView.Nodes(0).Nodes(4).NodeFont = New Font("Verdana", 9, FontStyle.Bold)

            PageTreeView.ExpandAll()
            PageTreeView.ItemHeight = 20
            'PageTreeView.SelectedNode = PageTreeView.Nodes(0).Nodes(2).Nodes(0)
            AddHandler PageTreeView.MouseClick, AddressOf PageClick
            AddHandler Page_Ctrl.MouseMove, AddressOf Page_Ctrl_MouseMove
            AddHandler Page_Ctrl.MouseClick, AddressOf Page_Ctrl_MouseClick

            GetAlarmServerTags()
            GetSAMAHistorianTags()
            Explore_DataSources()



            If My.Application.CommandLineArgs.Count > 0 Then 'Read Command Line -To get File Path
                If Not (Not My.Application.CommandLineArgs(0) Is Nothing AndAlso String.IsNullOrEmpty(My.Application.CommandLineArgs(0))) Then
                    Call OpenFile(My.Application.CommandLineArgs(0))
                    Me.Tag = My.Application.CommandLineArgs(0)
                    If Server_Flag Then
                        Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Server] "
                    Else
                        Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Client] "
                    End If


                End If

            Else

                If System.IO.File.Exists(Application.StartupPath & "\Autostartfile.cfg") Then
                    Dim objReader As New System.IO.StreamReader(Application.StartupPath & "\Autostartfile.cfg")
                    Dim pth As String = objReader.ReadLine()
                    Dim enable As String = objReader.ReadLine()
                    objReader.Close()
                    objReader.Dispose()
                    If enable = "True" Then
                        If Not String.IsNullOrEmpty(pth) Then
                            Call OpenFile(pth)
                            Me.Tag = pth
                            If Server_Flag Then
                                Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Server] "
                            Else
                                Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Client] "
                            End If

                        End If
                    End If

                End If
            End If

            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(1).Nodes.Count - 1 'Set Image to Supra DB Channel node
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).SelectedImageIndex = 4
            Next
            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(0).Nodes.Count - 1 'Set Image to Opc Channel node
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).SelectedImageIndex = 4
            Next
            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1 'Set Image to SAMA Historian Channel node
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).SelectedImageIndex = 4
            Next

            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(3).Nodes.Count - 1 'Set Image to SAMA OPCDA Channel node
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).SelectedImageIndex = 4
            Next

            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(4).Nodes.Count - 1 'Set Image to SAMA OPCHDA Channel node
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).SelectedImageIndex = 4
            Next





            'ExploreReports()

            'If IO.File.Exists(Application.StartupPath & "\RemoteOPC.txt") Then
            '    RemoteOPCServer = IO.File.ReadAllLines(Application.StartupPath & "\RemoteOPC.txt")(0).Trim()
            'Else
            '    RemoteOPCServer = ""
            'End If
            '  PageTreeView.Nodes(0).Nodes(0).
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Form1_Load()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
        'Try
        '    Dim cef As New CefSharp.CefSettings
        '    CefSharp.Cef.Initialize(cef)
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub createuserconfig()
        Dim datset As DataSet
        Dim datbl As DataTable
        Dim daro As DataRow
        If Not IO.File.Exists(Application.StartupPath & "\UsersConfig.xml") Then
            datset = New DataSet
            datbl = New DataTable
            datbl.Columns.Add(New DataColumn("SerialNo", Type.GetType("System.String")))
            datbl.Columns.Add(New DataColumn("Username", Type.GetType("System.String")))
            datbl.Columns.Add(New DataColumn("Password", Type.GetType("System.String")))
            datbl.Columns.Add(New DataColumn("RetypePassword", Type.GetType("System.String")))
            datbl.Columns.Add(New DataColumn("IsSimple", Type.GetType("System.Boolean")))
            datbl.Columns.Add(New DataColumn("IsPower", Type.GetType("System.Boolean")))
            datbl.Columns.Add(New DataColumn("IsAdmin", Type.GetType("System.Boolean")))
            datbl.Columns.Add(New DataColumn("IsSuperAdmin", Type.GetType("System.Boolean")))
            datbl.Columns.Add(New DataColumn("Accesslevel", Type.GetType("System.String")))
            datbl.Columns.Add(New DataColumn("Accessrules", Type.GetType("System.String")))

            datbl.Columns(0).AutoIncrementSeed = 1
            datbl.Columns(0).AutoIncrement = True
            daro = datbl.NewRow()

            daro("Username") = "sa"
            daro("Password") = "sa"
            daro("RetypePassword") = "sa"

            daro("IsSimple") = "False"
            daro("IsPower") = "False"
            daro("IsAdmin") = "False"
            daro("IsSuperAdmin") = "True"

            daro("Accesslevel") = "All"
            daro("Accessrules") = "All"

            datbl.Rows.Add(daro)
            datset.Tables.Add(datbl)

            datset.WriteXml(Application.StartupPath & "\UsersConfig.xml", XmlWriteMode.WriteSchema)
        End If
    End Sub

    Public Sub InsertFileLog(ByVal msg As String)
        Try
            If Not IO.File.Exists(Application.StartupPath & "\" & Now.ToString("ddMMMyyyy") & ".log") Then
                IO.File.WriteAllText(Application.StartupPath & "\" & Now.ToString("ddMMMyyyy") & ".log", msg)
            Else
                File.AppendAllText(Application.StartupPath & "\" & Now.ToString("ddMMMyyyy") & ".log", msg)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetSAMAHistorianTags()
        Try
            Dim paths() As String = IO.File.ReadAllLines(Application.StartupPath & "\ReportLocation.txt")
            ' _DbLocation = IO.File.ReadAllText(Application.StartupPath & "\ReportLocation.txt")
            _DbLocation = paths(0)
            ReportLocation = paths(1)

            If File.Exists(_DbLocation & "\Tags.rpt") Then
                System.IO.File.Delete(_DbLocation & "\Tags.rpt")
            End If
            System.IO.File.Create(_DbLocation & "\Tags.rpt")
            System.Threading.Thread.Sleep(5000)


            If File.Exists(_DbLocation & "\Tags.csv") Then
                _tgNames.Clear()
                ' _ChannelIds.Clear()

                Dim tgscsv() As String = IO.File.ReadAllLines(_DbLocation & "\Tags.csv")
                For Each s As String In tgscsv
                    ' Dim s As String = str.Split("~")(0)

                    If (Not s = "") AndAlso (Not _tgNames.Contains(s)) Then
                        _tgNames.Add(s)
                        '_tgNames.Add(Mid(s, InStr(s, ".") + 1))
                        '_ChannelIds.Add(s.Split(".")(0))

                    End If

                Next

            End If

            CsvFileWatchTimer = New Timer()
            CsvFileWatchTimer.Interval = 3000
            CsvFileWatchTimer.Enabled = True
            AddHandler CsvFileWatchTimer.Tick, (AddressOf SAMAHistorianChannels.tmr_GenerateHistorianChannelDataTable)


        Catch ex As Exception
            '_errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Form1_Load @GetSAMAHistorianTags")
            'MainErrorPV.SetError(lblAlert, "Error !!!")
            InsertFileLog(ex.Message)
        End Try
    End Sub



    Private Sub GetAlarmServerTags()
        Dim con = GetConString()
        Dim sqlConn As New SqlConnection(con)
        Dim sqlCmd As New SqlCommand()
        Dim sqLdr As SqlDataReader
        Try
            _tgNamesAIMS.Clear()
            If Not String.IsNullOrEmpty(Constr) Then

                sqlConn.Open()
                sqlCmd = New SqlCommand("select Plant,Area,Unit from vueUnit where DefaultUnit='false'", sqlConn)
                sqLdr = sqlCmd.ExecuteReader
                While sqLdr.Read
                    _tgNamesAIMS.Add(sqLdr("Plant") & "~" & sqLdr("Area") & "~" & sqLdr("Unit"))
                End While
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Form1_Load @GetAlarmServerTags")
            MainErrorPV.SetError(lblAlert, "Error !!!")
            InsertFileLog(ex.Message)
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Search and Get the Available OPC Server in Local host
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub GetopcServers()
        Dim srvList As OpcServerBrowser = New OpcServerBrowser()

        Try
            'Get Available  OPC Servers
            If srvList IsNot Nothing Then
                srvList.GetServerList(aProgIds)
                'Check if any thhing Found,If Found Store it in tree view
                If Not aProgIds Is Nothing Then
                    ReDim OPC_ServeNames(aProgIds.Length - 1)
                    ReDim OPC_Servers(aProgIds.Length - 1)
                    For kk As Integer = 0 To aProgIds.Length - 1
                        OPC_ServeNames(kk) = aProgIds(kk)
                    Next
                End If
            End If

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GETOPC_Servers()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Get Analyse Query From Sql Server
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Proc_FillQueryFromtblReportType()
        Dim sqlConn As New SqlConnection(Constr)
        Dim sqlCmd As New SqlCommand()
        Dim sqLdr As SqlDataReader
        If Not String.IsNullOrEmpty(Constr) Then
            Try
                sqlConn.Open()
                sqlCmd = New SqlCommand("SELECT ReportGroup,DisplayFields,TableorQueryName,ThresHold,GroupBy,ReportSubGroup From tblReportType", sqlConn)
                sqLdr = sqlCmd.ExecuteReader
                While sqLdr.Read
                    If sqLdr("ReportGroup") = "Analysis" Then
                        If Not sqLdr("ReportSubGroup") = "PriorityDistribution" Then
                            Dim Filds As String = sqLdr("DisplayFields")
                            If Filds.Contains("TagNo,TagNo") Then
                                Filds = Filds.Replace("TagNo,TagNo", "TagNo")
                            ElseIf Filds.StartsWith("Count(*)") Then
                                Filds = Filds.Replace("Count(*) as  AlmCount,TagNo,", "")
                            End If

                            If sqLdr("TableorQueryName") = "vueStandingAlarms" Or sqLdr("TableorQueryName") = "vueStandingAlarmDuration" Or sqLdr("TableorQueryName") = "vueUnAckAlarms" _
                            Or sqLdr("TableorQueryName") = "vueAckAlarms" Then
                                Filds = Filds.Replace("AlmCount", "Duration_mins")
                            ElseIf sqLdr("TableorQueryName") = "vueStaleAlarms" Then
                                Filds = Filds.Replace("AlmCount", "Duration_Days")
                            End If

                            Lst_Display_fields.Add(Filds)
                            Lst_TableName.Add(sqLdr("TableorQueryName"))
                            Lst_Where.Add(sqLdr("ThresHold"))
                            Lst_GroupBy.Add(sqLdr("GroupBy"))

                        Else
                            Lst_Display_fields.Add("COUNT(*) AS Value,Priority")
                            Lst_TableName.Add(sqLdr("TableorQueryName"))
                            Lst_Where.Add(sqLdr("ThresHold"))
                            Lst_GroupBy.Add("Priority")
                        End If


                    End If
                End While
            Catch ex As Exception
                _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_FillQueryFromtblReportType()")
                MainErrorPV.SetError(lblAlert, "Error !!!")
            Finally
                If sqlConn.State = ConnectionState.Open Then
                    sqlConn.Close()
                End If
            End Try
        End If

    End Sub


    'Panel Part
    '----------
    ''' <summary>
    ''' Event Handler Refresh the panel to clear the Border when Mouse Click on Panel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Page_Ctrl_MouseClick(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try

            If e.Button = MouseButtons.Right Then
                If blnCopy Or blnCut Then
                    MS_PagePaste.Enabled = True
                Else
                    MS_PagePaste.Enabled = False
                End If


                If _runMode Then
                    DesignModeToolStripMenuItem.Enabled = True
                    MS_PagePropertie.Enabled = False
                Else
                    DesignModeToolStripMenuItem.Enabled = False
                    MS_PagePropertie.Enabled = True
                End If
                PageProperties.Show(Page_Ctrl, e.Location)


            Else
                Page_Ctrl.Refresh()
            End If
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Page_Ctrl_MouseClick()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    Dim Pgname As String = ""
    Dim Dtime As String
    ''' <summary>
    ''' Event Handler Display Working Area X and Y Position with Page Name...
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Page_Ctrl_MouseMove(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try

            If SltPageIndex <> "" Then
                'If PageTreeView.SelectedNode.Index > 0 Then
                TSPagelbl.Text = "Current Page  : " & SltPageIndex
                'End If
            End If

            TSPoslbl.Text = "Screen Pos X : " & e.X & " , Y : " & e.Y & "                 "

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Page_Ctrl_MouseMove()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    ''' Event to Display the Desired Panel When Click On Child Node in TreeView !!!
    ''' </summary>

    Private Sub PageTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles PageTreeView.AfterSelect

    End Sub
    Private Sub Page_Ctrl_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub Page_Ctrl_Drop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files


            Try
                If Not path.EndsWith(".sam") Then
                    MsgBox("Sorry,This is not a Valid File !!!")
                    Exit Sub
                End If
                If modify Then
                    Dim result = MessageBox.Show("Do you Want to Save tha Changes.....", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    If result = DialogResult.Cancel Then
                        Exit Sub
                    ElseIf result = DialogResult.No Then
                        Me.Tag = path
                        If Server_Flag Then
                            Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Server]"
                        Else
                            Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Client]"
                        End If


                        Call ClearALL() 'Clear Server,etc
                        Call OpenFile(path)

                    ElseIf result = DialogResult.Yes Then
                        Call Main_SaveMenu_Click(sender, e)
                        Me.Tag = path
                        If Server_Flag Then
                            Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Server]"
                        Else
                            Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Client]"
                        End If
                        Call ClearALL()
                        Call OpenFile(path)
                    End If
                Else
                    Me.Tag = path
                    If Server_Flag Then
                        Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Server]"
                    Else
                        Me.Text = "SAMA RT Client - " & Microsoft.VisualBasic.Mid(Me.Tag, InStrRev(Me.Tag, "\") + 1) & "  [Client]"
                    End If
                    Call ClearALL()
                    Call OpenFile(path)
                End If

                If _runMode Then
                    FullScreenToolStripMenuItem_Click(sender, e)
                End If
            Catch ex As Exception
                _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OpenToolStripMenuItem_Click()")
                MainErrorPV.SetError(lblAlert, "Error !!!")
            End Try




        Next

    End Sub

    ''' <summary>
    ''' Event Handler Right Click on TreeView List Show the Page Properties
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PageClick(ByVal sender As [Object], ByVal e As MouseEventArgs) Handles PageTreeView.NodeMouseClick
        Try
            If Not _IsSimpleUser Then
                If Not _runMode Then
                    If Not PageTreeView.SelectedNode Is Nothing Then
                        If Not PageTreeView.SelectedNode.Parent Is Nothing Then
                            'If PageTreeView.SelectedNode.Parent.Index = 2 Then 'Pages Node
                            '    If e.Button = MouseButtons.Right Then
                            '        If PageTreeView.SelectedNode.Index > 1 Then
                            '            If PageTreeView.SelectedNode.Index = PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1 Then
                            '                MS_DeletePage.Enabled = True
                            '            Else
                            '                MS_DeletePage.Enabled = False
                            '            End If
                            '        Else
                            '            MS_DeletePage.Enabled = False
                            '        End If
                            '        ContextMenuStripPages.Show(PageTreeView, e.X, e.Y)
                            '    End If
                            'End If
                            If PageTreeView.SelectedNode.Text = "SAMA Channels" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_Add_SupraDB_Channel.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If


                            If PageTreeView.SelectedNode.Text = "OPC Channels" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_AddOPC_Channel.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Text = "OPC Historian" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_AddSAMA_Historianchannel.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Text = "OPC DA" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_AddOPCDA.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Text = "OPC HDA" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_AddOPCHDA.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Parent.Text = "OPC Channels" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_ShowDataForm.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If
                            If PageTreeView.SelectedNode.Parent.Text = "SAMA Channels" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_showDBDataForm.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If
                            If PageTreeView.SelectedNode.Parent.Text = "OPC Historian" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_ShowSAMAHistorianForm.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Parent.Text = "OPC DA" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_ShowOPCDAForm.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                            If PageTreeView.SelectedNode.Parent.Text = "OPC HDA" Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_ShowOPCHDAForm.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                        Else
                            If PageTreeView.SelectedNode.Text = "SAMA RT Client   " AndAlso Not Server_Flag Then
                                If e.Button = MouseButtons.Right Then
                                    CMS_ConnectServer.Show(PageTreeView, e.X, e.Y)
                                End If
                            End If

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PageClick()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try




    End Sub
    'Page Context Menu
    Private Sub PastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_PagePaste.Click
        Call Paste_Controls()
        blnPaste = False
        blnCopy = False
        blnCut = False
    End Sub

    Private Sub MS_PagePropertie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_PagePropertie.Click

        Try
            Dim pgProp As New PageProperties
            Dim pnlObj() As Control
            pnlObj = Me.Controls.Find(SltPageIndex, True)
            If pnlObj.Length <> 0 Then
                If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                    pgProp.txtPageName.Text = pnlObj(0).Name
                    pgProp.BGColorLbl.BackColor = pnlObj(0).BackColor
                End If
            End If
            pgProp.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MS_PageProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_PageProperties.Click

        Try
            Dim pgProp As New PageProperties
            Dim pnlObj() As Control
            pnlObj = Me.Controls.Find(SltPageIndex, True)
            If pnlObj.Length <> 0 Then
                If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                    pgProp.txtPageName.Text = pnlObj(0).Name
                    pgProp.BGColorLbl.BackColor = pnlObj(0).BackColor
                    pageprevname = pnlObj(0).Name
                End If
            End If
            pgProp.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub


#Region "Guage"
    'Guage Context Menu

    Private Sub MS_GuagePropertie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_GuagePropertie.Click

        Try
            GuageProp_Form = New GuageValueFromUser
            GuageProp_Form.txtMinValue.Text = Guage_Ctrl.MinValue
            GuageProp_Form.txtMaxValue.Text = Guage_Ctrl.MaxValue
            GuageProp_Form.txtAcceptStartValue.Text = Guage_Ctrl.MinValue
            GuageProp_Form.Channel_Text = Guage_Ctrl.AccessibleDescription
            GuageProp_Form.txtCapX.Text = Guage_Ctrl.CapPosition.X
            GuageProp_Form.txtCapY.Text = Guage_Ctrl.CapPosition.Y


            GuageProp_Form.NUDNeedleType.Value = Guage_Ctrl.NeedleType
            GuageProp_Form.NUDNeedleWidth.Value = Guage_Ctrl.NeedleWidth
            GuageProp_Form.NUDStepValue.Value = Guage_Ctrl.ScaleLinesMajorStepValue
            GuageProp_Form.lblColor.BackColor = Guage_Ctrl.NeedleColor2
            If Not Guage_Ctrl.NeedleColor2.Name = "Violet" Then
                GuageProp_Form.cboxColors.SelectedIndex = GuageProp_Form.cboxColors.Items.IndexOf(Guage_Ctrl.NeedleColor2.Name)
            Else
                GuageProp_Form.cboxColors.SelectedIndex = GuageProp_Form.cboxColors.Items.IndexOf("Magenta")
            End If

            Guage_Ctrl.Range_Idx = 0
            GuageProp_Form.txtAcceptStartValue.Text = Guage_Ctrl.RangeStartValue
            GuageProp_Form.txtAcceptable.Text = Guage_Ctrl.RangeEndValue
            GuageProp_Form.AcceptanleColor.BackColor = Guage_Ctrl.RangeColor
            Guage_Ctrl.Range_Idx = 1
            GuageProp_Form.txtManageStartValue.Text = Guage_Ctrl.RangeStartValue
            GuageProp_Form.txtManageable.Text = Guage_Ctrl.RangeEndValue
            GuageProp_Form.ManageableColor.BackColor = Guage_Ctrl.RangeColor
            Guage_Ctrl.Range_Idx = 2
            GuageProp_Form.txtUnManageStartValue.Text = Guage_Ctrl.RangeStartValue
            GuageProp_Form.txtUnManageable.Text = Guage_Ctrl.RangeEndValue
            GuageProp_Form.UnManageableColor.BackColor = Guage_Ctrl.RangeColor
            Guage_Ctrl.RangeEnabled = True

            If Guage_Ctrl.BaseArcRadius = 0 Then
                GuageProp_Form.CkBoxOuterArc.Checked = False
            End If
            GuageProp_Form.lblCtrlBackColor.BackColor = Guage_Ctrl.BackColor
            GuageProp_Form.txtRangeDegree.Text = Guage_Ctrl.BaseArcSweep
            GuageProp_Form.txtRangeStartDegree.Text = Guage_Ctrl.BaseArcStart
            GuageProp_Form.lbloutarccolor.BackColor = Guage_Ctrl.BaseArcColor
            GuageProp_Form.txtCaption.Text = Guage_Ctrl.CapText
            GuageProp_Form.ShowDialog()

        Catch ex As Exception
            MainErrorPV.SetError(lblAlert, "Error !!!")
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SaveToolStripMenuItem_Click()")
        End Try
    End Sub

    Private Sub MS_GuageClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_GuageClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Guage_Ctrl)

    End Sub
    Private Sub MS_GuageSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_GuageSendToBack.Click
        Guage_Ctrl.SendToBack()
    End Sub
    Private Sub MS_GuageBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_GuageBringToFront.Click
        Guage_Ctrl.BringToFront()
    End Sub

#End Region

#Region "Label"

    'Context Menu Label 
    Private Sub MS_LabelPropertie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LabelPropertie.Click
        LabelProp_Form = New LabelPropertiesForm

        LabelProp_Form.txtCaption.Text = Label_Ctrl.Text

        LabelProp_Form.lblCtrlBackColor.BackColor = Label_Ctrl.BackColor
        LabelProp_Form.forecolorlbl.BackColor = Label_Ctrl.ForeColor

        LabelProp_Form.CBoxFont.Text = Label_Ctrl.Font.Name
        LabelProp_Form.NUDFontSize.Value = Label_Ctrl.Font.Size
        LabelProp_Form.CBoxStyle.Text = Label_Ctrl.BorderStyle.ToString
        If Label_Ctrl.Font.Style = FontStyle.Bold Then
            LabelProp_Form.CKboxBold.Checked = True
        End If
        If Label_Ctrl.Font.Style = FontStyle.Italic Then
            LabelProp_Form.Ckboxbtnitalic.Checked = True
        End If
        If Label_Ctrl.Font.Style = FontStyle.Underline Then
            LabelProp_Form.CKBoxUnderLine.Checked = True
        End If

        LabelProp_Form.ShowDialog()
    End Sub

    Private Sub MS_LabelClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LabelClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Label_Ctrl)

    End Sub
    Private Sub MS_LabelSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LabelSendToBack.Click
        Label_Ctrl.SendToBack()
    End Sub

    Private Sub MS_LabelBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LabelBringToFront.Click
        Label_Ctrl.BringToFront()
    End Sub

#End Region

#Region "ValueLabel"

    'Context Menu Value Label 
    Private Sub MS_ValueLabelPropertie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValueLabelPropertie.Click

        Try
            DisValueLabelProp_Form = New DisplayvalueLabelPropertiesForm
            DisValueLabelProp_Form.lblCtrlBackColor.BackColor = ValueLabel_Ctrl.Default_BackColor
            DisValueLabelProp_Form.forecolorlbl.BackColor = ValueLabel_Ctrl.DefaultForeColors_
            DisValueLabelProp_Form.CBoxFont.Text = ValueLabel_Ctrl.Font.Name
            DisValueLabelProp_Form.NUDFontSize.Value = ValueLabel_Ctrl.Font.Size
            DisValueLabelProp_Form.Channel_Text = ValueLabel_Ctrl.AccessibleDescription

            DisValueLabelProp_Form.txtUnits.Text = ValueLabel_Ctrl.UnitsValue
            DisValueLabelProp_Form.CBoxStyle.Text = ValueLabel_Ctrl.BorderStyle.ToString

            If ValueLabel_Ctrl.Font.Style = FontStyle.Bold Then
                DisValueLabelProp_Form.CKboxBold.Checked = True
            Else
                DisValueLabelProp_Form.CKboxBold.Checked = False
            End If
            DisValueLabelProp_Form.GVTHValue.Rows.Clear()
            For i As Integer = 0 To ValueLabel_Ctrl._ThresholdValue.Count - 1
                DisValueLabelProp_Form.GVTHValue.Rows.Add()
                Dim tt() As String = ValueLabel_Ctrl._ThresholdValue(i).Split("@")
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(0).Value = tt(0)
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(1).Value = tt(1)
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(ValueLabel_Ctrl._THForeColor(i))
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(3).Style.BackColor = Color.FromArgb(ValueLabel_Ctrl._THBackColor(i))
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(4).Value = ValueLabel_Ctrl._Description(i)
                DisValueLabelProp_Form.GVTHValue.Rows(i).Cells(5).Value = ValueLabel_Ctrl._THblink(i)
            Next
            DisValueLabelProp_Form.ShowDialog()
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DisValLblProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub MS_ValueLabelClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValueLabelClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(ValueLabel_Ctrl)

    End Sub

    Private Sub MS_ValueLabelSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValueLabelSendToBack.Click
        ValueLabel_Ctrl.SendToBack()
    End Sub

    Private Sub MS_ValueLabelBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValueLabelBringToFront.Click
        ValueLabel_Ctrl.BringToFront()
    End Sub

#End Region

#Region "MS_Chart"

    'Context Menu Chart

    Private Sub MS_ChartProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartProperties.Click
        Try
            ChartProp_Form = New ChartPropertiesForm
            ChartProp_Form.txtComponentName.Text = Chart_Ctrl.Name

            ChartProp_Form._ListChart_Series = New List(Of ChartProperties)


            Dim prop As New ChartProperties
            prop = ChartProp_Form.ProcAddProperties(Chart_Ctrl.Series(0).Name, Chart_Ctrl.Series(0).YValueMembers _
 , Chart_Ctrl.Series(0).ChartType.ToString, Chart_Ctrl.Series(0).MarkerStyle.ToString, Chart_Ctrl.Series(0).MarkerSize _
, Chart_Ctrl.Series(0).MarkerColor.ToArgb, Chart_Ctrl.Series(0).LabelForeColor.ToArgb, Chart_Ctrl.Series(0).IsValueShownAsLabel)
            For i As Integer = 0 To Chart_Ctrl.Series.Count - 1
                Dim chartseriesprop As New ChartSeriesProperties
                chartseriesprop.TagName = Chart_Ctrl.Series(i).Name
                chartseriesprop.SeriesColor = Chart_Ctrl.Series(i).Color.ToArgb
                chartseriesprop._ThresholdValue.Clear()
                chartseriesprop._THPointsColor.Clear()

                If Chart_Ctrl.Series_TH_Data.Count > 0 AndAlso Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then 'Add TH Value Ch
                    ' artProperties._ThresholdValue
                    chartseriesprop._ThresholdValue.AddRange(Chart_Ctrl.Series_TH_Data(i).ThresholdValue.ToArray)
                    chartseriesprop._THPointsColor.AddRange(Chart_Ctrl.Series_TH_Data(i).THPointsColor.ToArray)
                End If
                prop.Chart_Series_Properties.Add(chartseriesprop)
            Next

            ChartProp_Form._ListChart_Series.Add(prop)

            If Chart_Ctrl.Series.Count > 0 Then
                If Chart_Ctrl.Titles.Count > 0 Then
                    ChartProp_Form._Title = Chart_Ctrl.Titles(0).Text
                End If

                If Not Double.IsNaN(Chart_Ctrl.ChartAreas(0).AxisY.Maximum) Then
                    ChartProp_Form._YScaleMax = Chart_Ctrl.ChartAreas(0).AxisY.Maximum
                    ChartProp_Form._YScaleMin = Chart_Ctrl.ChartAreas(0).AxisY.Minimum
                Else
                    ChartProp_Form._YScaleMax = 0
                    ChartProp_Form._YScaleMin = 0
                End If

                ChartProp_Form.XYAxislbl_Font = Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font
                ChartProp_Form.XYAxislbl_color = Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.ForeColor

                ChartProp_Form.Title_Font = Chart_Ctrl.Titles(0).Font
                ChartProp_Form.Title_Color = Chart_Ctrl.Titles(0).ForeColor

                ChartProp_Form.Chart_BGColor = Chart_Ctrl.BackColor
                ChartProp_Form.Grid_Color = Chart_Ctrl.ChartAreas(0).AxisX.MajorGrid.LineColor

                ChartProp_Form.txtXAxisTitle.Text = Chart_Ctrl.ChartAreas(0).AxisX.Title
                ChartProp_Form.txtYAxisTitle.Text = Chart_Ctrl.ChartAreas(0).AxisY.Title
                ChartProp_Form.xyTitle_Color = Chart_Ctrl.ChartAreas(0).AxisX.TitleForeColor
                ChartProp_Form.Legend_Color = Chart_Ctrl.Legends(0).ForeColor

                ChartProp_Form.cBoxChartBorder.Text = Chart_Ctrl.BorderSkin.SkinStyle.ToString

                If Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True" Then
                    ChartProp_Form.ckYAutoScale.Checked = True
                Else
                    ChartProp_Form.ckYAutoScale.Checked = False
                End If

                If Chart_Ctrl.Legends(0).Position.Width = 100 Then
                    ChartProp_Form.blnLegend = True
                Else
                    ChartProp_Form.blnLegend = False
                End If
            End If


            ChartProp_Form.ShowDialog()


        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_ChartProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub MultitrendProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultitrendProperties.Click
        Try
            MultitrendChartProp_Form = New MultiTrendChartProperties
            MultitrendChartProp_Form.txtComponentName.Text = Trender_Ctrl.Name

            MultitrendChartProp_Form._ListChart_Series = New List(Of ChartProperties)
            For i As Integer = 0 To Trender_Ctrl.ChartControl1.Series.Count - 1

                Dim prop As New ChartProperties
                prop = MultitrendChartProp_Form.ProcAddProperties(Trender_Ctrl.ChartControl1.Series(i).Name, Trender_Ctrl.ChartControl1.Series(i).YValueMembers _
 , Trender_Ctrl.ChartControl1.Series(i).Color.ToArgb, Trender_Ctrl.ChartControl1.Series(i).ChartType.ToString, Trender_Ctrl.ChartControl1.Series(i).MarkerStyle.ToString, Trender_Ctrl.ChartControl1.Series(i).MarkerSize _
, Trender_Ctrl.ChartControl1.Series(i).MarkerColor.ToArgb, Trender_Ctrl.ChartControl1.Series(i).LabelForeColor.ToArgb, Trender_Ctrl.ChartControl1.Series(i).IsValueShownAsLabel)



                MultitrendChartProp_Form._ListChart_Series.Add(prop)


            Next

            If Trender_Ctrl.ChartControl1.Series.Count > 0 Then
                If Trender_Ctrl.ChartControl1.Titles.Count > 0 Then
                    MultitrendChartProp_Form._Title = Trender_Ctrl.ChartControl1.Titles(0).Text
                End If

                If Not Double.IsNaN(Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Maximum) Then
                    MultitrendChartProp_Form._YScaleMax = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Maximum
                    MultitrendChartProp_Form._YScaleMin = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Minimum
                Else
                    MultitrendChartProp_Form._YScaleMax = 0
                    MultitrendChartProp_Form._YScaleMin = 0
                End If

                MultitrendChartProp_Form.XYAxislbl_Font = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.Font
                MultitrendChartProp_Form.XYAxislbl_color = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.ForeColor

                MultitrendChartProp_Form.Title_Font = Trender_Ctrl.ChartControl1.Titles(0).Font
                MultitrendChartProp_Form.Title_Color = Trender_Ctrl.ChartControl1.Titles(0).ForeColor

                MultitrendChartProp_Form.Chart_BGColor = Trender_Ctrl.ChartControl1.BackColor
                MultitrendChartProp_Form.Grid_Color = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.MajorGrid.LineColor

                MultitrendChartProp_Form.txtXAxisTitle.Text = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.Title
                MultitrendChartProp_Form.txtYAxisTitle.Text = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Title
                MultitrendChartProp_Form.xyTitle_Color = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.TitleForeColor


                MultitrendChartProp_Form.cBoxChartBorder.Text = Trender_Ctrl.ChartControl1.BorderSkin.SkinStyle.ToString

                If Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Tag = "True" Then
                    MultitrendChartProp_Form.ckYAutoScale.Checked = True
                Else
                    MultitrendChartProp_Form.ckYAutoScale.Checked = False
                End If


            End If



            MultitrendChartProp_Form.ShowDialog()


        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_ChartProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub MS_ChartClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Chart_Ctrl)

    End Sub

    Private Sub MS_ChartSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartSendToBack.Click
        Chart_Ctrl.SendToBack()
    End Sub

    Private Sub MS_ChartBringToFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartBringToFront.Click
        Chart_Ctrl.BringToFront()
    End Sub

#End Region

#Region "Panel"

    'Context Menu Panel
    Private Sub TS_pnlProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_pnlProperties.Click
        PanelPropertiesForm.BGColorLbl.BackColor = Panel_Ctrl.BackColor
        If Panel_Ctrl.AccessibleDescription = "Edge" Then
            PanelPropertiesForm.rdobtnRaisedEdge.Checked = True
        Else
            PanelPropertiesForm.rdobtnRaisedEdge.Checked = False
        End If
        PanelPropertiesForm.ShowDialog()
    End Sub

    Private Sub TS_pnlClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_pnlClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Panel_Ctrl)

    End Sub

    Private Sub TS_pnlSentoback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_pnlSentoback.Click
        Panel_Ctrl.SendToBack()
    End Sub

    Private Sub TS_BtoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_BtoF.Click
        Panel_Ctrl.BringToFront()
    End Sub

#End Region

#Region "PictureBox"

    'Context Menu PictureBox

    Private Sub Pic_Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Properties.Click
        If PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Stretch Then
            PicPropertiesForm.CkBoxStretch.Checked = True
        Else
            PicPropertiesForm.CkBoxStretch.Checked = False
        End If
        If Not (Not PictureBox_Ctrl.AccessibleDescription Is Nothing AndAlso String.IsNullOrEmpty(PictureBox_Ctrl.AccessibleDescription)) Then
            PicPropertiesForm.SltImg = PictureBox_Ctrl.AccessibleDescription
        Else
            PicPropertiesForm.SltImg = "(None)"
        End If


        PicPropertiesForm.ShowDialog()
    End Sub


    Private Sub PicBox_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBox_Clear.Click
        Me.modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(PictureBox_Ctrl)

    End Sub

    Private Sub PicBox_StoB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBox_StoB.Click
        PictureBox_Ctrl.SendToBack()
    End Sub

    Private Sub PicBox_BtoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBox_BtoF.Click
        PictureBox_Ctrl.BringToFront()
    End Sub

#End Region

#Region "ButtonControl"

    'Contextmenu Button_Ctrl
    Private Sub MS_BtnProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_BtnProperties.Click
        Try
            Dim buttonPropForm As New buttonPropertiesForm
            buttonPropForm.BackColorlbl.BackColor = Button_Ctrl.BackColor
            buttonPropForm.forecolorlbl.BackColor = Button_Ctrl.ForeColor
            buttonPropForm.txtTitleFont.Text = Button_Ctrl.Font.ToString
            buttonPropForm.btnFont = Button_Ctrl.Font
            buttonPropForm.txtText.Text = Button_Ctrl.Text
            buttonPropForm.CBoxStyle.Text = (Button_Ctrl.FlatStyle.ToString)
            buttonPropForm.CBoxActionType.Text = (Button_Ctrl.Action_Type)
            buttonPropForm.cBoxComponent.Text = (Button_Ctrl.Action_Ctrl)
            buttonPropForm.ShowDialog()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_BtnProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub MS_BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_BtnClear.Click
        Me.modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Button_Ctrl)
    End Sub

    Private Sub MS_BtnS_To_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_BtnS_To_B.Click
        Button_Ctrl.SendToBack()
    End Sub

    Private Sub MS_BtnB_To_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_BtnB_To_F.Click
        Button_Ctrl.BringToFront()
    End Sub

#End Region

#Region "Cut, Copy"

    'Common Cut,Copy Menu
    Private Sub MS_PanelCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click, PicBox_Cut.Click, MS_ValueLabelCut.Click, MS_TableCut.Click, MS_PanelCut.Click, MS_LBCut.Click, MS_LabelCut.Click, MS_GuageCut.Click, MS_ChartCut.Click, MS_Btn_Cut.Click
        Try
            blnCut = True
            blnCopy = False
            blnPaste = True
            MS_PagePaste.Enabled = True
            Page_Ctrl.Controls.Remove(Past_Ctrl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MS_PanelCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click, PicBox_Copy.Click, MS_ValueLabelCopy.Click, MS_TableCopy.Click, MS_PanelCopy.Click, MS_LabelCopy.Click, MS_GuageCopy.Click, MS_ChartCopy.Click, MS_Btn_Copy.Click
        Try
            blnCut = False
            blnCopy = True
            blnPaste = True
            MS_PagePaste.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' Procedure to Draw the Border to All Controls when Moving or clicking the Controls !!
    ''' </summary>

    Private Sub Border(ByRef ctrl As Control)
        Try
            Dim myCoolPenstyle As New Pen(Color.OrangeRed, 3.0F) '// (color, pen width.)
            myCoolPenstyle.DashStyle = Drawing2D.DashStyle.Dash
            myCoolPenstyle.DashOffset = 2.0F

            With ctrl '// draw just outside the Bounds of the Control.
                'Page_Ctrl.Refresh()
                'Page_Ctrl.CreateGraphics.DrawRectangle(myCoolPenstyle, .Location.X, .Location.Y, .Width, .Height)
                ctrl.Refresh()
                ctrl.SuspendLayout()
                ctrl.CreateGraphics.DrawRectangle(myCoolPenstyle, 0, 0, .Width - 1, .Height - 1)
                ctrl.ResumeLayout()
            End With
            myCoolPenstyle.Dispose()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Border()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' List of Data Table column Name and its DataType
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub DTColumnsAdd()

        dt = New DataTable

        'Channel List

        dt.Columns.Add(New DataColumn("DBChannel_RefreshTime", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Channel_Name", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("ChannelQuery", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("ChannelType", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("_DBQuery", Type.GetType("System.String")))
        'OPC Channel List
        dt.Columns.Add(New DataColumn("OPC_ChannelName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_OPCServer", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_Tag", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_RefreshTime", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_HisLength", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_nnHoursHistory", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPC_IsMultiview", Type.GetType("System.String")))
        'SAMA Historian Channel List
        dt.Columns.Add(New DataColumn("SAMA_ReportName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_Description", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_Tags", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_Duration", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_Interval", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_XAxis", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SAMA_Operation", Type.GetType("System.String")))

        'OPCDAServers List
        dt.Columns.Add(New DataColumn("OPCDA_ConfigName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_PrimaryIP", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_PrimaryPort", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_SecondaryIP", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_SecondaryPort", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_RefreshInterval", Type.GetType("System.String")))

        'OPCHDAServers List
        dt.Columns.Add(New DataColumn("OPCHDA_ConfigName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_PrimaryIP", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_PrimaryPort", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_SecondaryIP", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_SecondaryPort", Type.GetType("System.String")))

        'OPCDA Channel List
        dt.Columns.Add(New DataColumn("OPCDA_ChannelName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_OPCServer", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_Tag", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_RefreshTime", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_HisLength", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_nnHoursHistory", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCDA_IsMultiview", Type.GetType("System.String")))

        'OPCHDA Channel List
        dt.Columns.Add(New DataColumn("OPCHDA_ChannelName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_OPCServer", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_Tag", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_Last", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_Interval", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_RelativeTime", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCHDA_XAxis", Type.GetType("System.String")))

        'Pages
        dt.Columns.Add(New DataColumn("PageNo", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Pagecolor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("PageName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("PageNodePath", Type.GetType("System.String")))
        'Common
        dt.Columns.Add(New DataColumn("Tag", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Width", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Height", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Font", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("ForeColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("BackColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Style", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LocX", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LocY", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("ChannelName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Ctrl_Name", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Z_Order", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("Dt_StoreLoc", Type.GetType("System.String")))


        'Guage_Ctrl Column

        dt.Columns.Add(New DataColumn("CaptionName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("CapX", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("CapY", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("MinValue", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("MaxValue", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("BGColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("NeedleType", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("NeedleWidth", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("NeedleColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("StepValue", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Rangedegree", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("StartDegree", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OutArcColor", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("Rangeidx0", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeStartValue0", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeEndValue0", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeColor0", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("Rangeidx1", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeStartValue1", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeEndValue1", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeColor1", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("Rangeidx2", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeStartValue2", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeEndValue2", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeColor2", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OuterEnable", Type.GetType("System.String")))
        'Columns for Label_Ctrl
        dt.Columns.Add(New DataColumn("lblText", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("lblFontName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblFontSize", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblBorderStyle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblStyle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblThresholdVal", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblTHForeColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblTHBackColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblTHBlink", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("lblTHFont", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Units", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Dese", Type.GetType("System.String")))


        'Columns for Chart_Ctrl
        dt.Columns.Add(New DataColumn("Titile", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LegentEnabled", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LegentColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("ChartBGColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("GridColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("XYTitleColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("XTitle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("YTitle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("BorderSkinStyle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TitleFont", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("XYLabelFont", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("YMin", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("YMax", Type.GetType("System.Int32")))

        dt.Columns.Add(New DataColumn("ChartLocX", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("ChartLocY", Type.GetType("System.Int32")))



        dt.Columns.Add(New DataColumn("Seriesname", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SeriesYExp", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SeriesColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("MarkerColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("MarkerStyle", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("Markersize", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("ChartType", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("Axislblcolor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("AxisEnabled", Type.GetType("System.String")))


        dt.Columns.Add(New DataColumn("SeriesTHValues", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SeriesTHColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("3DChart", Type.GetType("System.String")))

        'Annunciator Column
        dt.Columns.Add(New DataColumn("Annunciator_BackColor", Type.GetType("System.String")))


        'Column for Panel_Ctrl
        dt.Columns.Add(New DataColumn("EdgeRaised", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("pnlBackColor", Type.GetType("System.String")))

        'Column for Picture Box Control
        dt.Columns.Add(New DataColumn("ImageName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("isStretch", Type.GetType("System.String")))
        'Grid Table Column
        dt.Columns.Add(New DataColumn("C_BC", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("C_FC", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("AL_BC", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("AL_FC", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SL_BC", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("SL_FC", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("C_Font", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("AL_Font", Type.GetType("System.String")))

        'Column for LogBook Ctrl
        dt.Columns.Add(New DataColumn("isLatest", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Path", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LastnnHour", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Extension", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Delimiter", Type.GetType("System.String")))

        'Column for Button Ctrl
        dt.Columns.Add(New DataColumn("Action_Type", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Action_Ctrl", Type.GetType("System.String")))


        'Column for OPCWriter Ctrl
        dt.Columns.Add(New DataColumn("OPCServerName", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCTag", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("OPCValue", Type.GetType("System.String")))

        'Columns for Trender_Ctrl
        dt.Columns.Add(New DataColumn("TTitle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TChartBGColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TGridColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TXYTitleColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TXTitle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TYTitle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TBorderSkinStyle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TTitleFont", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TXYLabelFont", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("XaxisTimeorValue", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("TYMin", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("TYMax", Type.GetType("System.Int32")))

        dt.Columns.Add(New DataColumn("TChartLocX", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("TChartLocY", Type.GetType("System.Int32")))


        dt.Columns.Add(New DataColumn("TSeriesname", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TSeriesColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TSeriesYExp", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TMarkerColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TMarkerStyle", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("TMarkersize", Type.GetType("System.Int32")))
        dt.Columns.Add(New DataColumn("TChartType", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TAxislblcolor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("TAxisEnabled", Type.GetType("System.String")))


        AddColumnsForMchartInDataTable()



        'Column for Symbol,Switch Ctrl
        dt.Columns.Add(New DataColumn("THCondition", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("THState", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LineSize", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("D_Color", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("ActiveColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("InActiveColor", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeStart", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("RangeEnd", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LevelsCount", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Scale_Enabled", Type.GetType("System.String")))

        dt.Columns.Add(New DataColumn("LineCap", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("CapStyle", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("LineDirection", Type.GetType("System.String")))
        dt.Columns.Add(New DataColumn("Description", Type.GetType("System.String")))


    End Sub

    ''' <summary>
    ''' Pricedure to Save all Properties of Controls from all Pages ,That are saved in XML file(Supra File(.sam))
    ''' </summary>

    Dim dtidx As Integer ' = 0

    Private Sub DataRow(ByVal pageNo As String, ByVal blnGug As Boolean, ByVal blnChrt As Boolean, ByVal blnlbl As Boolean, ByVal blnlblval As Boolean, ByVal blnPnl As Boolean, ByVal blnPicture As Boolean, ByVal blnGrid As Boolean, ByVal blnLogBook As Boolean, ByVal blnButton As Boolean, ByVal blnValve As Boolean, ByVal blnSwitch As Boolean, ByVal blnSymbol As Boolean, ByVal blnIndicator As Boolean, ByVal blnTrender As Boolean, ByVal blnMChrt As Boolean, ByVal blnOPCWriter As Boolean, ByVal blnAnnunciator As Boolean, ByVal tblName As String)

        Try
            Call DTColumnsAdd()
            Dim dr As DataRow = dt.NewRow()
            If blnGug Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Guage_Ctrl.Name
                dr("Tag") = "Guage"
                dr("LocX") = Guage_Ctrl.Location.X
                dr("LocY") = Guage_Ctrl.Location.Y
                dr("ChannelName") = Guage_Ctrl.AccessibleDescription
                dr("CapX") = Guage_Ctrl.CapPosition.X
                dr("CapY") = Guage_Ctrl.CapPosition.Y
                dr("CaptionName") = Guage_Ctrl.CapText
                dr("MinValue") = Guage_Ctrl.MinValue
                dr("MaxValue") = Guage_Ctrl.MaxValue
                dr("BGColor") = Guage_Ctrl.BackColor.ToArgb
                dr("NeedleType") = Guage_Ctrl.NeedleType
                dr("NeedleWidth") = Guage_Ctrl.NeedleWidth
                dr("NeedleColor") = Guage_Ctrl.NeedleColor2.Name
                dr("StepValue") = Guage_Ctrl.ScaleLinesMajorStepValue
                dr("Rangedegree") = Guage_Ctrl.BaseArcSweep
                dr("StartDegree") = Guage_Ctrl.BaseArcStart
                dr("OutArcColor") = Guage_Ctrl.BaseArcColor.ToArgb
                dr("RangeIdx0") = 0
                dr("RangeStartValue0") = Guage_Ctrl.RangesStartValue(0)
                dr("RangeEndValue0") = Guage_Ctrl.RangesEndValue(0)
                dr("RangeColor0") = Guage_Ctrl.RangesColor(0).ToArgb
                dr("RangeIdx1") = 1
                dr("RangeStartValue1") = Guage_Ctrl.RangesStartValue(1)
                dr("RangeEndValue1") = Guage_Ctrl.RangesEndValue(1)
                dr("RangeColor1") = Guage_Ctrl.RangesColor(1).ToArgb
                dr("RangeIdx2") = 2
                dr("RangeStartValue2") = Guage_Ctrl.RangesStartValue(2)
                dr("RangeEndValue2") = Guage_Ctrl.RangesEndValue(2)
                dr("RangeColor2") = Guage_Ctrl.RangesColor(2).ToArgb
                dr("OuterEnable") = Guage_Ctrl.BaseArcRadius

                dr("Width") = Guage_Ctrl.Width
                dr("Height") = Guage_Ctrl.Height
                dr("Z_Order") = pnl.Controls.GetChildIndex(Guage_Ctrl).ToString()
            End If

            If (blnlbl And Not blnlblval) Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Label_Ctrl.Name
                dr("Tag") = Label_Ctrl.Tag
                dr("Locx") = Label_Ctrl.Location.X
                dr("LocY") = Label_Ctrl.Location.Y
                dr("lblText") = Label_Ctrl.Text
                dr("BackColor") = Label_Ctrl.BackColor.ToArgb
                dr("ForeColor") = Label_Ctrl.ForeColor.ToArgb
                dr("Width") = Label_Ctrl.Width
                dr("Height") = Label_Ctrl.Height
                dr("lblFontName") = Label_Ctrl.Font.Name
                dr("lblFontSize") = Label_Ctrl.Font.Size
                dr("lblBorderStyle") = Label_Ctrl.BorderStyle


                If Label_Ctrl.Font.Style = FontStyle.Bold Then
                    dr("lblStyle") = "Bold"
                ElseIf Label_Ctrl.Font.Style = FontStyle.Italic Then
                    dr("lblStyle") = "Italic"
                ElseIf Label_Ctrl.Font.Style = FontStyle.Underline Then
                    dr("lblStyle") = "Underline"
                Else
                    dr("lblStyle") = "Regular"
                End If
                dr("Z_Order") = pnl.Controls.GetChildIndex(Label_Ctrl).ToString()
            End If
            If blnLogBook Then
                dr("PageNo") = pageNo
                dr("Tag") = LogCtrl.Tag
                dr("LocX") = LogCtrl.Location.X
                dr("LocY") = LogCtrl.Location.Y
                dr("Width") = LogCtrl.Width
                dr("Height") = LogCtrl.Height

                dr("isLatest") = LogCtrl.isLatest
                dr("Path") = LogCtrl.File_Path
                dr("LastnnHour") = LogCtrl.nnHour
                dr("Extension") = LogCtrl.Extension
                dr("Delimiter") = LogCtrl.Delimiter
                dr("Z_Order") = pnl.Controls.GetChildIndex(LogCtrl).ToString()
            End If
            If blnButton Then
                dr("PageNo") = pageNo
                dr("Tag") = Button_Ctrl.Tag
                dr("lblText") = Button_Ctrl.Text
                dr("LocX") = Button_Ctrl.Location.X
                dr("LocY") = Button_Ctrl.Location.Y
                dr("Width") = Button_Ctrl.Width
                dr("Height") = Button_Ctrl.Height
                dr("Font") = Button_Ctrl.Font.Name & "," & Button_Ctrl.Font.Size & "," & Button_Ctrl.Font.Style.ToString
                dr("Style") = Button_Ctrl.FlatStyle.ToString
                dr("BackColor") = Button_Ctrl.BackColor.ToArgb
                dr("ForeColor") = Button_Ctrl.ForeColor.ToArgb


                dr("Action_Type") = Button_Ctrl.Action_Type
                dr("Action_Ctrl") = Button_Ctrl.Action_Ctrl
                dr("Z_Order") = pnl.Controls.GetChildIndex(Button_Ctrl).ToString()
            End If

            If blnOPCWriter Then
                dr("PageNo") = pageNo
                dr("Tag") = OPCWrite_Ctrl.Tag
                dr("lblText") = OPCWrite_Ctrl.Text
                dr("LocX") = OPCWrite_Ctrl.Location.X
                dr("LocY") = OPCWrite_Ctrl.Location.Y
                dr("Width") = OPCWrite_Ctrl.Width
                dr("Height") = OPCWrite_Ctrl.Height
                dr("Font") = OPCWrite_Ctrl.Font.Name & "," & OPCWrite_Ctrl.Font.Size & "," & OPCWrite_Ctrl.Font.Style.ToString
                dr("Style") = OPCWrite_Ctrl.FlatStyle.ToString
                dr("BackColor") = OPCWrite_Ctrl.BackColor.ToArgb
                dr("ForeColor") = OPCWrite_Ctrl.ForeColor.ToArgb


                dr("ChannelName") = OPCWrite_Ctrl.AccessibleDescription
                dr("OPCServerName") = OPCWrite_Ctrl.OPCServerName
                dr("OPCTag") = OPCWrite_Ctrl.OPCTag
                dr("OPCValue") = OPCWrite_Ctrl.OPCValue
                dr("Z_Order") = pnl.Controls.GetChildIndex(OPCWrite_Ctrl).ToString()
            End If

            If blnlblval Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = ValueLabel_Ctrl.Name
                dr("Tag") = ValueLabel_Ctrl.Tag
                dr("LocX") = ValueLabel_Ctrl.Location.X
                dr("LocY") = ValueLabel_Ctrl.Location.Y
                dr("lblText") = ValueLabel_Ctrl.Text
                dr("BackColor") = ValueLabel_Ctrl.Default_BackColor.ToArgb
                dr("ForeColor") = ValueLabel_Ctrl.DefaultForeColors_.ToArgb
                dr("Width") = ValueLabel_Ctrl.Width
                dr("Height") = ValueLabel_Ctrl.Height
                dr("lblFontName") = ValueLabel_Ctrl.Font.Name
                dr("lblFontSize") = ValueLabel_Ctrl.Font.Size
                dr("lblBorderStyle") = ValueLabel_Ctrl.BorderStyle
                dr("Units") = ValueLabel_Ctrl.UnitsValue
                dr("ChannelName") = ValueLabel_Ctrl.AccessibleDescription
                If Not ValueLabel_Ctrl._ThresholdValue.Count > 0 Then
                    dr("lblThresholdVal") = "False"
                    dr("lblTHForeColor") = "False"
                    dr("lblTHBackColor") = "False"
                    dr("lblTHBlink") = "False"
                    dr("Dese") = "False"
                Else
                    Dim thVal = ""
                    Dim fc = ""
                    Dim bc = ""
                    Dim Blink = ""
                    Dim desc = ""
                    For i As Integer = 0 To ValueLabel_Ctrl._ThresholdValue.Count - 1
                        thVal &= ValueLabel_Ctrl._ThresholdValue(i) & "*"
                        fc &= ValueLabel_Ctrl._THForeColor(i) & "*"
                        bc &= ValueLabel_Ctrl._THBackColor(i) & "*"
                        Blink &= ValueLabel_Ctrl._THblink(i) & "*"
                        desc &= ValueLabel_Ctrl._Description(i) & "*"

                    Next
                    dr("lblThresholdVal") = thVal
                    dr("lblTHForeColor") = fc
                    dr("lblTHBackColor") = bc
                    dr("Dese") = desc
                    dr("lblTHBlink") = Blink
                End If

                If ValueLabel_Ctrl.Font.Style = FontStyle.Bold Then
                    dr("lblStyle") = "Bold"
                ElseIf ValueLabel_Ctrl.Font.Style = FontStyle.Italic Then
                    dr("lblStyle") = "Italic"
                ElseIf ValueLabel_Ctrl.Font.Style = FontStyle.Underline Then
                    dr("lblStyle") = "Underline"
                Else
                    dr("lblStyle") = "Regular"
                End If
                dr("Z_Order") = pnl.Controls.GetChildIndex(ValueLabel_Ctrl).ToString()
            End If

            If blnChrt Then
                'Write code for Chart_Ctrl
                dr("Tag") = Chart_Ctrl.Tag
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Chart_Ctrl.Name
                dr("ChartLocX") = Chart_Ctrl.Location.X
                dr("ChartLocY") = Chart_Ctrl.Location.Y
                dr("Titile") = Chart_Ctrl.Titles(0).Text
                dr("Width") = Chart_Ctrl.Width
                dr("Height") = Chart_Ctrl.Height
                dr("LegentColor") = Chart_Ctrl.Legends(0).ForeColor.ToArgb
                dr("XTitle") = Chart_Ctrl.ChartAreas(0).AxisX.Title
                dr("YTitle") = Chart_Ctrl.ChartAreas(0).AxisY.Title

                dr("ChartBGColor") = Chart_Ctrl.BackColor.ToArgb
                dr("GridColor") = Chart_Ctrl.ChartAreas(0).AxisX.MajorGrid.LineColor.ToArgb
                dr("XYTitleColor") = Chart_Ctrl.ChartAreas(0).AxisX.TitleForeColor.ToArgb
                dr("BorderSkinStyle") = Chart_Ctrl.BorderSkin.SkinStyle.ToString
                dr("TitleFont") = Chart_Ctrl.Titles(0).Font.Name & "," & Chart_Ctrl.Titles(0).Font.Size & "," & Chart_Ctrl.Titles(0).Font.Style.ToString & "," & Chart_Ctrl.Titles(0).ForeColor.ToArgb
                dr("XYLabelFont") = Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font.Name & "," & Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font.Size & "," & Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font.Style.ToString & "," & Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.ForeColor.ToArgb

                If Chart_Ctrl.ChartAreas(0).Area3DStyle.Enable3D = True Then
                    dr("3DChart") = "True"
                Else
                    dr("3DChart") = "False"
                End If



                If Not Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True" Then
                    dr("YMin") = Chart_Ctrl.ChartAreas(0).AxisY.Minimum
                    dr("YMax") = Chart_Ctrl.ChartAreas(0).AxisY.Maximum
                Else
                    dr("YMin") = 0
                    dr("YMax") = 0
                End If

                dr("LegentEnabled") = "True"
                'If Chart_Ctrl.Legends(0).Position.Width = 100 Then
                '    dr("LegentEnabled") = "True"
                'Else
                '    dr("LegentEnabled") = "False"
                'End If


                dr("Z_Order") = pnl.Controls.GetChildIndex(Chart_Ctrl).ToString()

                dt.Rows.Add(dr)

                For i As Integer = 0 To Chart_Ctrl.Series.Count - 1
                    dr = dt.NewRow()
                    dr("Seriesname") = Chart_Ctrl.Series(i).Name
                    dr("SeriesYExp") = Chart_Ctrl.Series(i).YValueMembers
                    dr("SeriesColor") = Chart_Ctrl.Series(i).Color.ToArgb
                    dr("ChartType") = Chart_Ctrl.Series(i).ChartType

                    If Chart_Ctrl.Series(i).IsValueShownAsLabel = True Then
                        dr("AxisEnabled") = 1
                    Else
                        dr("AxisEnabled") = 0
                    End If
                    dr("Axislblcolor") = Chart_Ctrl.Series(i).LabelForeColor.ToArgb

                    dr("MarkerColor") = Chart_Ctrl.Series(i).MarkerColor.ToArgb
                    dr("MarkerStyle") = Chart_Ctrl.Series(i).MarkerStyle
                    dr("Markersize") = Chart_Ctrl.Series(i).MarkerSize

                    Dim idx As Integer = Array.IndexOf(OPC_ChannelList_Class.OPC_Channel_Name.ToArray, Chart_Ctrl.Series(i).YValueMembers)
                    If idx <> -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                        If opcCnfgTags(idx).bln_Store Then
                            dr("Dt_StoreLoc") = Storage_Loc & "\History_Data\" & Chart_Ctrl.Series(i).YValueMembers & ".dt"
                        Else
                            dr("Dt_StoreLoc") = ""
                        End If
                    Else
                        dr("Dt_StoreLoc") = ""
                    End If

                    If Chart_Ctrl.Series_TH_Data.Count > 0 AndAlso Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then
                        For n As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                            dr("SeriesTHValues") &= Chart_Ctrl.Series_TH_Data(i).ThresholdValue(n) & ","
                            dr("SeriesTHColor") &= Chart_Ctrl.Series_TH_Data(i).THPointsColor(n) & ","
                        Next
                    Else
                        dr("SeriesTHValues") = ""
                        dr("SeriesTHColor") = ""
                    End If
                    dt.Rows.Add(dr)
                Next
            End If

            If blnPnl Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Panel_Ctrl.Name
                dr("Tag") = Panel_Ctrl.Tag
                dr("LocX") = Panel_Ctrl.Location.X
                dr("LocY") = Panel_Ctrl.Location.Y
                dr("pnlBackColor") = Panel_Ctrl.BackColor.ToArgb
                dr("EdgeRaised") = Panel_Ctrl.AccessibleDescription
                dr("Width") = Panel_Ctrl.Width
                dr("Height") = Panel_Ctrl.Height
                dr("Z_Order") = pnl.Controls.GetChildIndex(Panel_Ctrl).ToString()
            End If


            If blnPicture Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = PictureBox_Ctrl.Name
                dr("Tag") = PictureBox_Ctrl.Tag
                dr("LocX") = PictureBox_Ctrl.Location.X
                dr("LocY") = PictureBox_Ctrl.Location.Y
                dr("ImageName") = PictureBox_Ctrl.AccessibleDescription
                If PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Stretch Then
                    dr("isStretch") = "True"
                Else
                    dr("isStretch") = "False"
                End If

                dr("Width") = PictureBox_Ctrl.Width
                dr("Height") = PictureBox_Ctrl.Height
                dr("Z_Order") = pnl.Controls.GetChildIndex(PictureBox_Ctrl).ToString()
            End If


            If blnGrid Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Grid_TableCtrl.Name
                dr("Tag") = Grid_TableCtrl.Tag
                dr("LocX") = Grid_TableCtrl.Location.X
                dr("LocY") = Grid_TableCtrl.Location.Y
                dr("Width") = Grid_TableCtrl.Width
                dr("Height") = Grid_TableCtrl.Height

                dr("ChannelName") = Grid_TableCtrl.AccessibleDescription
                dr("C_BC") = Grid_TableCtrl.RowsDefaultCellStyle.BackColor.ToArgb
                dr("C_FC") = Grid_TableCtrl.RowsDefaultCellStyle.ForeColor.ToArgb
                dr("AL_BC") = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.BackColor.ToArgb
                dr("AL_FC") = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.ForeColor.ToArgb
                dr("SL_BC") = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionBackColor.ToArgb
                dr("SL_FC") = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionForeColor.ToArgb

                dr("C_Font") = Grid_TableCtrl.RowsDefaultCellStyle.Font.Name & "," & Grid_TableCtrl.RowsDefaultCellStyle.Font.Size & "," & Grid_TableCtrl.RowsDefaultCellStyle.Font.Style.ToString
                dr("AL_Font") = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font.Name & "," & Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font.Size & "," & Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font.Style.ToString

                Dim idx As Integer = Array.IndexOf(OPC_ChannelList_Class.OPC_Channel_Name.ToArray, Grid_TableCtrl.AccessibleDescription)
                If idx <> -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                    If opcCnfgTags(idx).bln_Store Then
                        dr("Dt_StoreLoc") = Storage_Loc & "\History_Data\" & Grid_TableCtrl.AccessibleDescription & ".dt"
                    Else
                        dr("Dt_StoreLoc") = ""
                    End If
                Else
                    dr("Dt_StoreLoc") = ""
                End If

                dr("Z_Order") = pnl.Controls.GetChildIndex(Grid_TableCtrl).ToString()

                If Not Grid_TableCtrl._ThresholdValue.Count > 0 Then
                    dr("lblThresholdVal") = "False"
                    dr("lblTHForeColor") = "False"
                    dr("lblTHBackColor") = "False"
                    dr("lblTHFont") = "False"
                Else
                    Dim thVal = ""
                    Dim fc = ""
                    Dim bc = ""
                    Dim thFont = ""
                    For i As Integer = 0 To Grid_TableCtrl._ThresholdValue.Count - 1
                        thVal &= Grid_TableCtrl._ThresholdValue(i) & "*"
                        fc &= Grid_TableCtrl._THForeColor(i) & "*"
                        bc &= Grid_TableCtrl._THBackColor(i) & "*"
                        thFont &= Grid_TableCtrl._THFont(i) & "*"
                    Next
                    dr("lblThresholdVal") = thVal
                    dr("lblTHForeColor") = fc
                    dr("lblTHBackColor") = bc
                    dr("lblTHFont") = thFont
                End If


            End If

            If blnAnnunciator Then

                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Annunciator_Ctrl.Name
                dr("Tag") = Annunciator_Ctrl.Tag
                dr("LocX") = Annunciator_Ctrl.Location.X
                dr("LocY") = Annunciator_Ctrl.Location.Y
                dr("Width") = Annunciator_Ctrl.Width
                dr("Height") = Annunciator_Ctrl.Height


                ' dr("ViewName") = Tagpar_AliasName




                'dr("Annunciator_BackColor") = Annunciator_Ctrl.BackColor.ToArgb
                dr("ChannelName") = Annunciator_Ctrl.AccessibleDescription
                dr("C_BC") = Annunciator_Ctrl.BackColor.ToArgb
                dr("C_FC") = Annunciator_Ctrl.ForeColor.ToArgb
                'dr("AL_BC") = Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.BackColor.ToArgb
                'dr("AL_FC") = Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.ForeColor.ToArgb
                'dr("SL_BC") = Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.SelectionBackColor.ToArgb
                'dr("SL_FC") = Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.SelectionForeColor.ToArgb

                'dr("C_Font") = Annunciator_Ctrl.RowsDefaultCellStyle.Font.Name & "," & Annunciator_Ctrl.RowsDefaultCellStyle.Font.Size & "," & Annunciator_Ctrl.RowsDefaultCellStyle.Font.Style.ToString
                'dr("AL_Font") = Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.Font.Name & "," & Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.Font.Size & "," & Annunciator_Ctrl.AlternatingRowsDefaultCellStyle.Font.Style.ToString

                Dim idx As Integer = Array.IndexOf(OPC_ChannelList_Class.OPC_Channel_Name.ToArray, Annunciator_Ctrl.AccessibleDescription)
                If idx <> -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                    If opcCnfgTags(idx).bln_Store Then
                        dr("Dt_StoreLoc") = Storage_Loc & "\History_Data\" & Annunciator_Ctrl.AccessibleDescription & ".dt"
                    Else
                        dr("Dt_StoreLoc") = ""
                    End If
                Else
                    dr("Dt_StoreLoc") = ""
                End If

                dr("Z_Order") = pnl.Controls.GetChildIndex(Annunciator_Ctrl).ToString()

                'If Not Annunciator_Ctrl._ThresholdValue.Count > 0 Then
                '    dr("lblThresholdVal") = "False"
                '    dr("lblTHForeColor") = "False"
                '    dr("lblTHBackColor") = "False"
                '    dr("lblTHFont") = "False"
                'Else
                '    Dim thVal = ""
                '    Dim fc = ""
                '    Dim bc = ""
                '    Dim thFont = ""
                '    For i As Integer = 0 To Annunciator_Ctrl._ThresholdValue.Count - 1
                '        thVal &= Annunciator_Ctrl._ThresholdValue(i) & "*"
                '        fc &= Annunciator_Ctrl._THForeColor(i) & "*"
                '        bc &= Annunciator_Ctrl._THBackColor(i) & "*"
                '        thFont &= Annunciator_Ctrl._THFont(i) & "*"
                '    Next
                '    dr("lblThresholdVal") = thVal
                '    dr("lblTHForeColor") = fc
                '    dr("lblTHBackColor") = bc
                '    dr("lblTHFont") = thFont
                'End If


            End If

            If blnTrender Then
                dr("Tag") = Trender_Ctrl.Tag
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Trender_Ctrl.Name
                dr("TChartLocX") = Trender_Ctrl.Location.X
                dr("TChartLocY") = Trender_Ctrl.Location.Y
                dr("TTitle") = Trender_Ctrl.ChartControl1.Titles(0).Text
                dr("Width") = Trender_Ctrl.Width
                dr("Height") = Trender_Ctrl.Height
                dr("TXTitle") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.Title
                dr("TYTitle") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Title

                dr("TChartBGColor") = Trender_Ctrl.ChartControl1.BackColor.ToArgb
                dr("TGridColor") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.MajorGrid.LineColor.ToArgb
                dr("TXYTitleColor") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.TitleForeColor.ToArgb
                dr("TBorderSkinStyle") = Trender_Ctrl.ChartControl1.BorderSkin.SkinStyle.ToString
                dr("TTitleFont") = Trender_Ctrl.ChartControl1.Titles(0).Font.Name & "," & Trender_Ctrl.ChartControl1.Titles(0).Font.Size & "," & Trender_Ctrl.ChartControl1.Titles(0).Font.Style.ToString & "," & Trender_Ctrl.ChartControl1.Titles(0).ForeColor.ToArgb
                dr("TXYLabelFont") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font.Name & "," & Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font.Size & "," & Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font.Style.ToString & "," & Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.ForeColor.ToArgb

                dr("XaxisTimeorValue") = Trender_Ctrl.xaxis

                If Not Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Tag = "True" Then
                    dr("TYMin") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Minimum
                    dr("TYMax") = Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.Maximum
                Else
                    dr("TYMin") = 0
                    dr("TYMax") = 0
                End If
                dr("Z_Order") = pnl.Controls.GetChildIndex(Trender_Ctrl).ToString()
                dt.Rows.Add(dr)


                For i As Integer = 0 To Trender_Ctrl.ChartControl1.Series.Count - 1
                    dr = dt.NewRow()
                    dr("TSeriesname") = Trender_Ctrl.ChartControl1.Series(i).Name
                    dr("TSeriesYExp") = Trender_Ctrl.ChartControl1.AccessibleDescription
                    dr("TSeriesColor") = Trender_Ctrl.ChartControl1.Series(i).Color.ToArgb
                    dr("TChartType") = Trender_Ctrl.ChartControl1.Series(i).ChartTypeName

                    If Trender_Ctrl.ChartControl1.Series(i).IsValueShownAsLabel = True Then
                        dr("TAxisEnabled") = 1
                    Else
                        dr("TAxisEnabled") = 0
                    End If
                    dr("TAxislblcolor") = Trender_Ctrl.ChartControl1.Series(i).LabelForeColor.ToArgb
                    dr("TMarkerColor") = Trender_Ctrl.ChartControl1.Series(i).MarkerColor.ToArgb
                    dr("TMarkerStyle") = Trender_Ctrl.ChartControl1.Series(i).MarkerStyle
                    dr("TMarkersize") = Trender_Ctrl.ChartControl1.Series(i).MarkerSize

                    dt.Rows.Add(dr)

                Next


            End If

            If blnMChrt Then
                UpdateDataRowFromMChartVariablesForSavingInXml(pageNo)
            End If


            '-------------------------------------------
            'Symbols Part
            If blnIndicator Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = LevelIndicator_ctrl.Name
                dr("Tag") = LevelIndicator_ctrl.Tag
                dr("LocX") = LevelIndicator_ctrl.Location.X
                dr("LocY") = LevelIndicator_ctrl.Location.Y
                dr("Width") = LevelIndicator_ctrl.Width
                dr("Height") = LevelIndicator_ctrl.Height

                If Not LevelIndicator_ctrl.AccessibleDescription Is Nothing Then
                    dr("ChannelName") = LevelIndicator_ctrl.AccessibleDescription
                Else
                    dr("ChannelName") = ""
                End If

                dr("ActiveColor") = LevelIndicator_ctrl.ActiveColor.ToArgb()
                dr("InActiveColor") = LevelIndicator_ctrl.InActiveColor.ToArgb()
                dr("ForeColor") = LevelIndicator_ctrl.ForeColor.ToArgb
                dr("RangeStart") = LevelIndicator_ctrl.RangeStart
                dr("RangeEnd") = LevelIndicator_ctrl.RangeEnd
                dr("LevelsCount") = LevelIndicator_ctrl.LevelsCount
                dr("Scale_Enabled") = LevelIndicator_ctrl.Scale_Enabled.ToString()


                dr("Z_Order") = pnl.Controls.GetChildIndex(LevelIndicator_ctrl).ToString()
            End If

            If blnValve Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Valve_Ctrl.Name
                dr("Tag") = Valve_Ctrl.Tag
                dr("LocX") = Valve_Ctrl.Location.X
                dr("LocY") = Valve_Ctrl.Location.Y
                dr("Width") = Valve_Ctrl.Width
                dr("Height") = Valve_Ctrl.Height

                If Not Valve_Ctrl.AccessibleDescription Is Nothing Then
                    dr("ChannelName") = Valve_Ctrl.AccessibleDescription
                Else
                    dr("ChannelName") = ""
                End If

                dr("Z_Order") = pnl.Controls.GetChildIndex(Valve_Ctrl).ToString()

                dr("Description") = Valve_Ctrl.Description
                dr("ForeColor") = Valve_Ctrl.ForeColor.ToArgb()

                dr("D_Color") = Valve_Ctrl.D_Color1.ToArgb()
                If Not Valve_Ctrl._ThresholdValue.Count > 0 Then
                    dr("lblThresholdVal") = "False"
                    dr("THCondition") = "False"
                    dr("lblTHBackColor") = "False"

                Else
                    Dim thVal = ""
                    Dim bc = ""
                    Dim Condi = ""
                    For i As Integer = 0 To Valve_Ctrl._ThresholdValue.Count - 1
                        thVal &= Valve_Ctrl._ThresholdValue(i) & "*"
                        Condi &= Valve_Ctrl._THCondition(i) & "*"
                        bc &= Valve_Ctrl._THColor(i) & "*"

                    Next
                    dr("lblThresholdVal") = thVal
                    dr("THCondition") = Condi
                    dr("lblTHBackColor") = bc

                End If


            End If

            If blnSwitch Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Switch_Ctrl.Name
                dr("Tag") = Switch_Ctrl.Tag
                dr("LocX") = Switch_Ctrl.Location.X
                dr("LocY") = Switch_Ctrl.Location.Y
                dr("Width") = Switch_Ctrl.Width
                dr("Height") = Switch_Ctrl.Height


                If Not Switch_Ctrl.AccessibleDescription Is Nothing Then
                    dr("ChannelName") = Switch_Ctrl.AccessibleDescription
                Else
                    dr("ChannelName") = ""
                End If

                dr("Z_Order") = pnl.Controls.GetChildIndex(Switch_Ctrl).ToString()
                dr("D_Color") = Switch_Ctrl.D_Color1.ToArgb()

                If Not Switch_Ctrl._ThresholdValue.Count > 0 Then
                    dr("lblThresholdVal") = "False"
                    dr("THCondition") = "False"
                    dr("lblTHBackColor") = "False"
                    dr("THState") = "False"
                Else
                    Dim thVal = ""
                    Dim bc = ""
                    Dim Condi = ""
                    Dim State = ""
                    For i As Integer = 0 To Switch_Ctrl._ThresholdValue.Count - 1
                        thVal &= Switch_Ctrl._ThresholdValue(i) & "*"
                        Condi &= Switch_Ctrl._THCondition(i) & "*"
                        bc &= Switch_Ctrl._THColor(i) & "*"
                        State &= Switch_Ctrl._THState(i) & "*"
                    Next
                    dr("lblThresholdVal") = thVal
                    dr("THCondition") = Condi
                    dr("lblTHBackColor") = bc
                    dr("THState") = State
                End If


            End If

            If blnSymbol Then
                dr("PageNo") = pageNo
                dr("Ctrl_Name") = Symbol_Ctrl.Name
                dr("Tag") = Symbol_Ctrl.Tag
                dr("LocX") = Symbol_Ctrl.Location.X
                dr("LocY") = Symbol_Ctrl.Location.Y
                dr("Width") = Symbol_Ctrl.Width
                dr("Height") = Symbol_Ctrl.Height


                If Not Symbol_Ctrl.AccessibleDescription Is Nothing Then
                    dr("ChannelName") = Symbol_Ctrl.AccessibleDescription
                Else
                    dr("ChannelName") = ""
                End If
                dr("Z_Order") = pnl.Controls.GetChildIndex(Symbol_Ctrl).ToString()
                If TypeOf Symbol_Ctrl Is LineElbow Then
                    dr("LineSize") = Symbol_Ctrl.PenSize
                    dr("LineCap") = Symbol_Ctrl.Caps.ToString
                    dr("CapStyle") = Symbol_Ctrl.CapStyle.ToString()
                    dr("LineDirection") = Symbol_Ctrl.DirectionType.ToString()
                Else
                    dr("Description") = Symbol_Ctrl.Description
                    dr("ForeColor") = Symbol_Ctrl.ForeColor.ToArgb

                End If
                dr("D_Color") = Symbol_Ctrl.D_Color1.ToArgb()

                If Not Symbol_Ctrl._ThresholdValue.Count > 0 Then
                    dr("lblThresholdVal") = "False"
                    dr("THCondition") = "False"
                    dr("lblTHBackColor") = "False"
                    dr("THState") = "False"
                Else
                    Dim thVal = ""
                    Dim bc = ""
                    Dim Condi = ""

                    For i As Integer = 0 To Symbol_Ctrl._ThresholdValue.Count - 1
                        thVal &= Symbol_Ctrl._ThresholdValue(i) & "*"
                        Condi &= Symbol_Ctrl._THCondition(i) & "*"
                        bc &= Symbol_Ctrl._THColor(i) & "*"

                    Next
                    dr("lblThresholdVal") = thVal
                    dr("THCondition") = Condi
                    dr("lblTHBackColor") = bc

                End If



            End If

            If blnChrt Or blnTrender Or blnMChrt Then

            Else
                'If dt.Rows.Contains(dr) Then
                '    dt.Rows.Add(dr)
                'Else
                '    dt.Rows.Add(dr)
                'End If
                dt.Rows.Add(dr)
            End If

            ds.Tables.Add(dt)

            If tblName = "" Then
                tblName = "Table1"
            End If
            ds.Tables(dtidx).TableName = tblName
            dtidx += 1

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataRow()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Create Guage Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddGuadge(ByVal locX As Object, ByVal locY As Object, ByVal capText As String, ByVal capX As Integer, ByVal capY As Integer, ByVal channelName As String, ByVal minval As Object, ByVal maxval As Object, ByVal bgColor As Object, ByVal needleType As Object, ByVal needleWidth As Object, ByVal needleColor As Object, ByVal stepValue As Object, ByVal rangedegree As Object, ByVal startegree As Object, ByVal outarccolor As Object, ByVal ridx0 As Object, ByVal rsv0 As Object, ByVal rev0 As Object, ByVal rc0 As Object, ByVal ridx1 As Object, ByVal rsv1 As Object, ByVal rev1 As Object, ByVal rc1 As Object, ByVal ridx2 As Object, ByVal rsv2 As Object, ByVal rev2 As Object, ByVal rc2 As Object, ByVal outRadious As Object, ByVal width As Integer, ByVal height As Integer)

        Try
            Guage_Ctrl = New AnalyzerMeter.AGauge
            Guage_Ctrl.Name = "Guage" & _iniGuageName
            Guage_Ctrl.MinimumSize = Ctrl_MinSize


            AddHandler Guage_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Guage_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Guage_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Guage_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Guage_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Guage_Ctrl.AccessibleDescription = channelName

            Guage_Ctrl.AutoSize = False
            Guage_Ctrl.Width = width
            Guage_Ctrl.Height = height

            Guage_Ctrl.Location = New Point(locX, locY)

            Guage_Ctrl.MinValue = CInt(minval)
            Guage_Ctrl.MaxValue = CInt(maxval)
            Guage_Ctrl.CapPosition = New Point(capX, capY)
            Guage_Ctrl.CapText = capText
            Guage_Ctrl.Range_Idx = CInt(ridx0)
            Guage_Ctrl.RangesStartValue.SetValue(CInt(rsv0), 0)
            Guage_Ctrl.RangesEndValue.SetValue(CInt(rev0), 0)

            Guage_Ctrl.BackColor = Color.FromArgb(bgColor)
            Guage_Ctrl.NeedleType = CInt(needleType)
            Guage_Ctrl.NeedleWidth = CInt(needleWidth)
            Guage_Ctrl.Font = New Font("Verdana", 8.25, FontStyle.Bold)
            If needleColor = "Gray" Then
                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Gray
                Guage_Ctrl.NeedleColor2 = Color.Gray
            End If
            If needleColor = "Red" Then
                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Red
                Guage_Ctrl.NeedleColor2 = Color.Red
            End If
            If needleColor = "Green" Then
                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Green
                Guage_Ctrl.NeedleColor2 = Color.Green
            End If
            If needleColor = "Blue" Then

                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Blue
                Guage_Ctrl.NeedleColor2 = Color.Blue
            End If
            If needleColor = "Yellow" Then
                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Yellow
                Guage_Ctrl.NeedleColor2 = Color.Yellow
            End If
            If needleColor = "Violet" Then
                Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Violet
                Guage_Ctrl.NeedleColor2 = Color.Violet
            End If
            If needleColor = "Magenta" Then
                If CInt(needleType) = 0 Then
                    Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Violet
                    Guage_Ctrl.NeedleColor2 = Color.Magenta
                Else
                    Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Violet
                    Guage_Ctrl.NeedleColor2 = Color.Violet
                End If

            End If


            Guage_Ctrl.BaseArcSweep = CInt(rangedegree)
            Guage_Ctrl.BaseArcStart = CInt(startegree)
            Guage_Ctrl.BaseArcColor = Color.FromArgb(outarccolor)
            Guage_Ctrl.ScaleLinesMinorColor = Color.FromArgb(outarccolor)
            Guage_Ctrl.ScaleLinesInterColor = Color.FromArgb(outarccolor)
            Guage_Ctrl.ScaleLinesMajorStepValue = CInt(stepValue)
            Guage_Ctrl.RangeColor = Color.FromArgb(rc0)
            Guage_Ctrl.RangeEnabled = True
            Guage_Ctrl.Range_Idx = CInt(ridx1)

            Guage_Ctrl.RangesStartValue.SetValue(CInt(rsv1), 1)
            Guage_Ctrl.RangesEndValue.SetValue(CInt(rev1), 1)
            Guage_Ctrl.RangeColor = Color.FromArgb(rc1)
            Guage_Ctrl.Range_Idx = CInt(ridx2)
            Guage_Ctrl.RangesStartValue.SetValue(CInt(rsv2), 2)
            Guage_Ctrl.RangesEndValue.SetValue(CInt(rev2), 2)
            Guage_Ctrl.RangeColor = Color.FromArgb(rc2)

            Guage_Ctrl.BaseArcRadius = CInt(outRadious)

            Guage_Ctrl.RangesEnabled(0) = True
            Guage_Ctrl.RangesEnabled(1) = True
            Guage_Ctrl.RangesEnabled(2) = True



            Guage_Ctrl.Center = New Point(width / 2, height / 2)
            Page_Ctrl.Controls.Add(Guage_Ctrl)
            Guage_Ctrl.BringToFront()
            _iniGuageName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDGuadge()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    ''' Create Label Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddLabel(ByVal locX As Object, ByVal locY As Object, ByVal text As String, ByVal bgColor As Object, ByVal fColor As Object, ByVal width As Object, ByVal height As Object, ByVal borStyle As Object, ByVal fontName As Object, ByVal fontsize As Object, ByVal tag As Object, ByVal style As Object)

        Try
            Label_Ctrl = New Label
            Label_Ctrl.Tag = tag
            Label_Ctrl.Name = "Label" & _iniLabelName
            Label_Ctrl.MinimumSize = New Size(20, 12)
            Label_Ctrl.TextAlign = ContentAlignment.MiddleCenter
            Label_Ctrl.AutoSize = False

            AddHandler Label_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Label_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Label_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Label_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Label_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave


            Label_Ctrl.Width = width
            Label_Ctrl.Height = height
            Label_Ctrl.Text = text
            Label_Ctrl.Width = width
            Label_Ctrl.Height = height

            Dim emsize As Single = fontsize

            Label_Ctrl.Location = New Point(locX, locY)
            Label_Ctrl.BackColor = Color.FromArgb(bgColor)
            Label_Ctrl.ForeColor = Color.FromArgb(fColor)
            If borStyle = "None" Then
                Label_Ctrl.BorderStyle = BorderStyle.None
            End If
            If borStyle = "FixedSingle" Then
                Label_Ctrl.BorderStyle = BorderStyle.FixedSingle
            End If
            If borStyle = "Fixed3D" Then
                Label_Ctrl.BorderStyle = BorderStyle.Fixed3D
            End If
            If style = "Bold" Then
                Label_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Bold)
            ElseIf style = "Italic" Then
                Label_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Italic)
            ElseIf style = "Underline" Then
                Label_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Underline)
            Else
                Label_Ctrl.Font = New Font(fontName.ToString, emsize)
            End If

            Page_Ctrl.Controls.Add(Label_Ctrl)
            Label_Ctrl.BringToFront()
            _iniLabelName += 1
            'j += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDLabel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    '''  Create Value Label Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddValLabelCtrl(ByVal channelName As String, ByVal locX As Object, ByVal locY As Object, ByVal text As String,
                                ByVal bgColor As Object, ByVal fColor As Object, ByVal width As Object, ByVal height As Object,
                                ByVal borStyle As Object, ByVal fontName As Object, ByVal fontsize As Object,
                                ByVal tag As Object, ByVal style As Object, ByVal thresholdVal As Object,
                                ByVal thfColor As Object, ByVal thbColor As Object, ByVal UnitVal As Object, ByVal thBlink As Object, ByVal desc As Object)

        Try
            ValueLabel_Ctrl = New LabelValue
            ValueLabel_Ctrl.Tag = tag
            ValueLabel_Ctrl.MinimumSize = New Size(20, 12)
            ValueLabel_Ctrl.TextAlign = ContentAlignment.MiddleCenter
            ValueLabel_Ctrl.AutoSize = False

            ValueLabel_Ctrl.Name = "ValueLabel" & _iniValuelabelName
            AddHandler ValueLabel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler ValueLabel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ValueLabel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ValueLabel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ValueLabel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            'ValueLabel_Ctrl.AutoSize = False
            ValueLabel_Ctrl.Width = width
            ValueLabel_Ctrl.Height = height
            'ValueLabel_Ctrl.Width = width
            'ValueLabel_Ctrl.Height = height
            'ValueLabel_Ctrl.TextAlign = ContentAlignment.MiddleCenter
            ValueLabel_Ctrl.AccessibleDescription = channelName

            ValueLabel_Ctrl.UnitsValue = UnitVal

            Dim emsize As Single = fontsize

            If Not OPC_Servers Is Nothing Then
                ValueLabel_Ctrl.Text = text
            Else
                ValueLabel_Ctrl.Text = 0
            End If

            ValueLabel_Ctrl.Location = New Point(locX, locY)

            ValueLabel_Ctrl.BackColor = Color.FromArgb(bgColor)
            ValueLabel_Ctrl.ForeColor = Color.FromArgb(fColor)

            ValueLabel_Ctrl.Default_BackColor = Color.FromArgb(bgColor)
            ValueLabel_Ctrl.DefaultForeColors_ = Color.FromArgb(fColor)


            If borStyle = "None" Then
                ValueLabel_Ctrl.BorderStyle = BorderStyle.None
            End If
            If borStyle = "FixedSingle" Then
                ValueLabel_Ctrl.BorderStyle = BorderStyle.FixedSingle
            End If
            If borStyle = "Fixed3D" Then
                ValueLabel_Ctrl.BorderStyle = BorderStyle.Fixed3D
            End If
            If style = "Bold" Then
                ValueLabel_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Bold)
            ElseIf style = "Italic" Then
                ValueLabel_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Italic)
            ElseIf style = "Underline" Then
                ValueLabel_Ctrl.Font = New Font(fontName.ToString, emsize, FontStyle.Underline)
            Else
                ValueLabel_Ctrl.Font = New Font(fontName.ToString, emsize)
            End If
            'Add ThValue to Label_Value class._ThresholdValue
            ValueLabel_Ctrl._ThresholdValue.Clear()
            ValueLabel_Ctrl._THForeColor.Clear()
            ValueLabel_Ctrl._THBackColor.Clear()
            ValueLabel_Ctrl._THblink.Clear()
            ValueLabel_Ctrl._Description.Clear()
            If Not thresholdVal.ToString = "False" Then
                Dim thv, thfC, thbC, TnBlink, thDesc As New ArrayList
                thv = New ArrayList(thresholdVal.ToString.Split("*"))
                thfC = New ArrayList(thfColor.ToString.Split("*"))
                thbC = New ArrayList(thbColor.ToString.Split("*"))
                TnBlink = New ArrayList(thBlink.ToString.Split("*"))
                thDesc = New ArrayList(desc.ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    ValueLabel_Ctrl._ThresholdValue.Add(thv(i))
                    ValueLabel_Ctrl._THForeColor.Add(CInt(thfC(i)))
                    ValueLabel_Ctrl._THBackColor.Add(CInt(thbC(i)))
                    ValueLabel_Ctrl._Description.Add((thDesc(i)))
                    If thBlink(i) = "T" Then
                        ValueLabel_Ctrl._THblink.Add(1)
                    Else
                        ValueLabel_Ctrl._THblink.Add(0)
                    End If

                Next

            End If



            Page_Ctrl.Controls.Add(ValueLabel_Ctrl)
            ValueLabel_Ctrl.BringToFront()
            _iniValuelabelName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDValLabel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Create Chart Based on the (.sa, File Properties !!
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddChart(ByVal dt As DataTable)
        Try
            Chart_Ctrl = New ChartControl
            Chart_Ctrl.Name = dt.Rows(0).Item("Ctrl_Name")
            Ctrl_NameList.Add(Chart_Ctrl.Name)
            Chart_Ctrl.Tag = "Chart"
            Chart_Ctrl.MinimumSize = Ctrl_MinSize


            AddHandler Chart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Chart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Chart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Chart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Chart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Dim genChartArea As New ChartArea
            For i As Integer = 0 To dt.Rows.Count - 1
                If i = 0 Then
                    Chart_Ctrl.BackColor = Color.FromArgb(CInt(dt.Rows(i).Item("ChartBGColor")))
                    genChartArea.BackColor = Color.FromArgb(CInt(dt.Rows(i).Item("ChartBGColor")))

                    genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
                    genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines


                    genChartArea.Axes(0).Title = dt.Rows(i).Item("XTitle")
                    genChartArea.Axes(1).Title = dt.Rows(i).Item("YTitle")

                    genChartArea.Axes(0).TitleForeColor = Color.FromArgb(dt.Rows(i).Item("XYTitleColor"))
                    genChartArea.Axes(1).TitleForeColor = Color.FromArgb(dt.Rows(i).Item("XYTitleColor"))

                    genChartArea.Axes(0).MajorGrid.LineColor = Color.FromArgb(dt.Rows(i).Item("GridColor"))
                    genChartArea.Axes(1).MajorGrid.LineColor = Color.FromArgb(dt.Rows(i).Item("GridColor"))

                    genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
                    genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

                    If dt.Rows(i).Item("3DChart") = "True" Then
                        genChartArea.Area3DStyle.Enable3D = True
                    Else
                        genChartArea.Area3DStyle.Enable3D = False
                    End If


                    ' genChartArea.AxisX.Interval = 1
                    'genChartArea.AxisX.LabelStyle.Angle=-45

                    Chart_Ctrl.BorderlineColor = Color.Black
                    Chart_Ctrl.BorderlineWidth = 1
                    Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid

                    Chart_Ctrl.ChartAreas.Add(genChartArea)

                    If dt.Rows(i).Item("YMax") = "0" Then
                        Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True"
                        Chart_Ctrl.ResetAutoValues()
                        Chart_Ctrl.ChartAreas(0).AxisY.Maximum = Double.NaN
                        Chart_Ctrl.ChartAreas(0).AxisY.Minimum = Double.NaN
                        Chart_Ctrl.ResetAutoValues()
                    Else
                        Chart_Ctrl.ChartAreas(0).AxisY.Tag = "False"
                        Chart_Ctrl.ChartAreas(0).AxisY.Maximum = dt.Rows(i).Item("YMax")
                        Chart_Ctrl.ChartAreas(0).AxisY.Minimum = dt.Rows(i).Item("YMin")

                    End If

                    Dim xyLabelFont As String = dt.Rows(i).Item("XYLabelFont")
                    Dim arrXYLabelFont() As String
                    arrXYLabelFont = xyLabelFont.Split(",")
                    If arrXYLabelFont(2) = "Bold" Then
                        Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
                        Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
                    ElseIf arrXYLabelFont(2) = "Regular" Then
                        Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
                        Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
                    ElseIf arrXYLabelFont(2) = "Italic" Then
                        Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
                        Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
                    End If
                    Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
                    Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

                    genChartArea.Axes(0).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
                    genChartArea.Axes(1).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

                    genChartArea.Axes(0).MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
                    genChartArea.Axes(1).MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))


                    If Chart_Ctrl.Titles.Count > 0 Then
                        Chart_Ctrl.Titles.Clear()
                    End If

                    Chart_Ctrl.Titles.Add("")
                    Chart_Ctrl.Titles(0).Text = dt.Rows(i).Item("Titile")
                    Chart_Ctrl.Titles(0).Alignment = ContentAlignment.MiddleCenter

                    Dim titleFnt As String = dt.Rows(i).Item("TitleFont")
                    Dim arrTitleFnt() As String
                    arrTitleFnt = titleFnt.Split(",")

                    If arrTitleFnt(2) = "Bold" Then
                        Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
                    ElseIf arrTitleFnt(2) = "Regular" Then
                        Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Regular)
                    ElseIf arrTitleFnt(2) = "Italic" Then
                        Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Italic)
                    End If
                    Chart_Ctrl.Titles(0).ForeColor = Color.FromArgb(CInt(arrTitleFnt(3)))

                    If Not dt.Rows(i).Item("BorderSkinStyle") = "None" Then
                        Chart_Ctrl.BorderSkin.PageColor = Color.Transparent
                    End If
                    Select Case dt.Rows(i).Item("BorderSkinStyle")
                        Case "None"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.None

                        Case "FrameThin1"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1
                        Case "FrameThin2"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2
                        Case "FrameThin3"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3
                        Case "FrameThin4"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin4
                        Case "FrameThin5"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin5
                        Case "FrameThin6"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin6
                        Case "FrameTitle1"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1
                        Case "FrameTitle2"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle2
                        Case "FrameTitle3"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle3
                        Case "FrameTitle4"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle4
                        Case "FrameTitle5"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle5
                        Case "FrameTitle6"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle6
                        Case "FrameTitle7"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle7
                        Case "FrameTitle8"
                            Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle8

                        Case Else
                            ' do the defalut action
                    End Select

                    Chart_Ctrl.Location = New Point(CInt(dt.Rows(i).Item("ChartLocX")), CInt(dt.Rows(i).Item("ChartLocY")))
                    Chart_Ctrl.Size = New Size(CInt(dt.Rows(i).Item("Width")), CInt(dt.Rows(i).Item("Height")))
                Else
                    Chart_Ctrl.Series.Add(dt.Rows(i).Item("Seriesname"))
                    Chart_Ctrl.Series(i - 1).Color = Color.FromArgb(CInt(dt.Rows(i).Item("SeriesColor")))
                    Chart_Ctrl.Series(i - 1).MarkerColor = Color.FromArgb(CInt(dt.Rows(i).Item("MarkerColor")))
                    Chart_Ctrl.Series(i - 1).MarkerSize = dt.Rows(i).Item("Markersize")
                    Chart_Ctrl.Series(i - 1).ChartType = dt.Rows(i).Item("ChartType")
                    Chart_Ctrl.Series(i - 1).MarkerStyle = dt.Rows(i).Item("MarkerStyle")
                    'Chart_Ctrl.Series(i - 1).CustomProperties="LabelStyle=Top"

                    If dt.Rows(i).Item("AxisEnabled") = "1" Then
                        Chart_Ctrl.Series(i - 1).IsValueShownAsLabel = True
                    Else
                        Chart_Ctrl.Series(i - 1).IsValueShownAsLabel = False
                    End If
                    Chart_Ctrl.Series(i - 1).LabelForeColor = Color.FromArgb(CInt(dt.Rows(i).Item("Axislblcolor")))

                    Chart_Ctrl.Legends.Add(dt.Rows(i).Item("Seriesname"))

                    Chart_Ctrl.Legends(i - 1).ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("LegentColor")))
                    Chart_Ctrl.Legends(i - 1).BackColor = Color.Transparent

                    Chart_Ctrl.Series(i - 1).ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
                    Chart_Ctrl.Series(i - 1).XValueType = ChartValueType.String 'X value type

                    Chart_Ctrl.Series(i - 1).BorderWidth = 2
                    If dt.Rows(0).Item("LegentEnabled") = "False" Then
                        Chart_Ctrl.Legends(i - 1).Position.Width = 0
                        Chart_Ctrl.Legends(i - 1).Position.Height = 0
                    Else
                        Chart_Ctrl.Legends(i - 1).Enabled = True
                        Chart_Ctrl.Legends(i - 1).Alignment = StringAlignment.Far
                        Chart_Ctrl.Legends(i - 1).Position.Width = 100
                        Chart_Ctrl.Legends(i - 1).Position.Height = 10
                        Chart_Ctrl.Legends(i - 1).Position.X = 70
                        Chart_Ctrl.Legends(i - 1).Position.Y = 0
                    End If


                    Dim Ch_TH As New ChartSeriesTHValue

                    If Not String.IsNullOrEmpty(dt.Rows(i).Item("SeriesTHValues")) Then
                        Dim S_ThVal() As String = dt.Rows(i).Item("SeriesTHValues").ToString.Split(",")
                        Dim S_ThColor() As String = dt.Rows(i).Item("SeriesTHColor").ToString.Split(",")
                        Ch_TH.ThresholdValue.AddRange(S_ThVal.Take(S_ThVal.Length - 1))
                        Ch_TH.THPointsColor.AddRange(S_ThColor.Take(S_ThColor.Length - 1))
                        Ch_TH.TagName = dt.Rows(i).Item("Seriesname")
                        Chart_Ctrl.Series_TH_Data.Add(Ch_TH)
                    Else
                        Chart_Ctrl.Series_TH_Data.Add(Ch_TH)
                    End If




                    'Read From Storage File
                    Chart_Ctrl.Series(i - 1).YValueMembers = dt.Rows(i).Item("SeriesYExp")
                    Dim path As String = dt.Rows(i).Item("Dt_StoreLoc")
                    If Not (Not path Is Nothing AndAlso String.IsNullOrEmpty(path)) Then
                        Dim idx As Integer = OPC_ChannelList_Class.OPC_Channel_Name.IndexOf(dt.Rows(i).Item("SeriesYExp"))
                        If Not idx = -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                            Dim g_ds = New DataSet
                            If IO.File.Exists(path) Then
                                'g_ds.ReadXml(path)
                                MyDecryptor(g_ds, path)
                                For j As Integer = 0 To g_ds.Tables(0).Rows.Count - 1
                                    Chart_Ctrl.Series(i - 1).Points.AddXY(CDate(g_ds.Tables(0).Rows(j).Item(0)).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), g_ds.Tables(0).Rows(j).Item(1))
                                Next
                            End If

                        End If

                    End If

                    Chart_Ctrl.Series(i - 1).Font = New Font("Verdana", 8, FontStyle.Regular)
                    'End If
                End If
            Next

            Chart_Ctrl.BringToFront()
            Page_Ctrl.Controls.Add(Chart_Ctrl) 'Add GuageControls in panel
            _iniChartName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDChart()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Create Trender Based on the (.sa, File Properties !!
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private _Listtrender_Series As New List(Of ChartProperties)
    Private Sub AddTrender(ByVal dt As DataTable)
        Try

            Trender_Ctrl = New MultiTrendCtrl
            Trender_Ctrl.Name = dt.Rows(0).Item("Ctrl_Name")
            Ctrl_NameList.Add(Trender_Ctrl.Name)
            Trender_Ctrl.Tag = "Trender"
            Trender_Ctrl.MinimumSize = Ctrl_MinSize
            Trender_Ctrl.Location = New Point(CInt(dt.Rows(0).Item("TChartLocX")), CInt(dt.Rows(0).Item("TChartLocY")))
            Trender_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Trender_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))
            Trender_Ctrl.xaxis = dt.Rows(0).Item("XaxisTimeorValue")

            _Listtrender_Series.Clear()
            For i As Integer = 1 To dt.Rows.Count - 1
                Dim lblAxixlabel As Boolean
                If dt.Rows(i).Item("TAxisEnabled") = 1 Then
                    lblAxixlabel = True
                Else
                    lblAxixlabel = False
                End If

                Dim prop As New ChartProperties
                prop = ProcAddProperties(dt.Rows(i).Item("TSeriesname"), dt.Rows(i).Item("TSeriesYExp") _
    , dt.Rows(i).Item("TSeriesColor"), dt.Rows(i).Item("TChartType"), dt.Rows(i).Item("TMarkerStyle"), dt.Rows(i).Item("TMarkersize") _
    , dt.Rows(i).Item("TMarkerColor"), dt.Rows(i).Item("TAxislblcolor"), lblAxixlabel)

                _Listtrender_Series.Add(prop)
            Next
            Call Properties(Trender_Ctrl, dt)

            Trender_Ctrl.BringToFront()
            Page_Ctrl.Controls.Add(Trender_Ctrl) 'Add GuageControls in panel
            _iniTrenderName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDChart()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Create Devexpress Chart Based on the (.sa, File Properties !!
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddMChartOld(ByVal dt As DataTable)
        'Try
        '    MChart_Ctrl = New MChartControl
        '    MChart_Ctrl.Name = dt.Rows(0).Item("Ctrl_Name")
        '    Ctrl_NameList.Add(MChart_Ctrl.Name)
        '    MChart_Ctrl.Tag = "MChart"
        '    MChart_Ctrl.MinimumSize = Ctrl_MinSize
        '    MChart_Ctrl.Location = New Point(CInt(dt.Rows(0).Item("MChartLocX")), CInt(dt.Rows(0).Item("MChartLocY")))
        '    MChart_Ctrl.Width = dt.Rows(0).Item("Width")
        '    MChart_Ctrl.Height = dt.Rows(0).Item("Height")
        '    'MChart_Ctrl._xaxis = dt.Rows(0).Item("XaxisTimeorValue")
        '    MChart_Ctrl._xaxis = dt.Rows(0).Item("MChartXaxisTimeorValue")


        '    AddHandler MChart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
        '    AddHandler MChart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
        '    AddHandler MChart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
        '    AddHandler MChart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
        '    AddHandler MChart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

        '    MChart_Ctrl.AutoSize = False
        '    MChart_Ctrl.Titles.Clear()

        '    Dim charttitle As ch.ChartTitle = New ch.ChartTitle
        '    charttitle.Text = dt.Rows(0).Item("McTitle")
        '    charttitle.Font = New Font("Thahoma", 10, FontStyle.Bold)
        '    charttitle.TextColor = Color.Blue
        '    MChart_Ctrl.Titles.Add(charttitle)


        '    'MChart_Ctrl.Titles(0).Text = dt.Rows(0).Item("McTitle")
        '    Dim mctitlefont = dt.Rows(0).Item("McTitleFont")
        '    Dim arrFntlst() As String = mctitlefont.Split(",")
        '    If arrFntlst(2) = "Bold" Then
        '        MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Bold)
        '    ElseIf arrFntlst(2) = "Regular" Then
        '        MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Regular)
        '    ElseIf arrFntlst(2) = "Italic" Then
        '        MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Italic)
        '    End If
        '    MChart_Ctrl.Titles(0).TextColor = Color.FromArgb(CInt(arrFntlst(3)))

        '    'Dim _diag As ch.XYDiagram = CType(MChart_Ctrl.Diagram, ch.XYDiagram)
        '    '_diag.AxisX.Title = dt.Rows(0).Item("McXTitle")
        '    '_diag.AxisY.Title = dt.Rows(0).Item("McYTitle")
        '    MChart_Ctrl.BackColor = Color.FromArgb(dt.Rows(0).Item("McYTitle"))

        '    Dim genChartArea As New ChartArea
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        If i = 0 Then
        '            Chart_Ctrl.BackColor = Color.FromArgb(CInt(dt.Rows(i).Item("ChartBGColor")))
        '            genChartArea.BackColor = Color.FromArgb(CInt(dt.Rows(i).Item("ChartBGColor")))

        '            genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
        '            genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines


        '            genChartArea.Axes(0).Title = dt.Rows(i).Item("XTitle")
        '            genChartArea.Axes(1).Title = dt.Rows(i).Item("YTitle")

        '            genChartArea.Axes(0).TitleForeColor = Color.FromArgb(dt.Rows(i).Item("XYTitleColor"))
        '            genChartArea.Axes(1).TitleForeColor = Color.FromArgb(dt.Rows(i).Item("XYTitleColor"))

        '            genChartArea.Axes(0).MajorGrid.LineColor = Color.FromArgb(dt.Rows(i).Item("GridColor"))
        '            genChartArea.Axes(1).MajorGrid.LineColor = Color.FromArgb(dt.Rows(i).Item("GridColor"))

        '            genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
        '            genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

        '            If dt.Rows(i).Item("3DChart") = "True" Then
        '                genChartArea.Area3DStyle.Enable3D = True
        '            Else
        '                genChartArea.Area3DStyle.Enable3D = False
        '            End If


        '            ' genChartArea.AxisX.Interval = 1
        '            'genChartArea.AxisX.LabelStyle.Angle=-45

        '            Chart_Ctrl.BorderlineColor = Color.Black
        '            Chart_Ctrl.BorderlineWidth = 1
        '            Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid

        '            Chart_Ctrl.ChartAreas.Add(genChartArea)

        '            If dt.Rows(i).Item("YMax") = "0" Then
        '                Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True"
        '                Chart_Ctrl.ResetAutoValues()
        '                Chart_Ctrl.ChartAreas(0).AxisY.Maximum = Double.NaN
        '                Chart_Ctrl.ChartAreas(0).AxisY.Minimum = Double.NaN
        '                Chart_Ctrl.ResetAutoValues()
        '            Else
        '                Chart_Ctrl.ChartAreas(0).AxisY.Tag = "False"
        '                Chart_Ctrl.ChartAreas(0).AxisY.Maximum = dt.Rows(i).Item("YMax")
        '                Chart_Ctrl.ChartAreas(0).AxisY.Minimum = dt.Rows(i).Item("YMin")

        '            End If

        '            Dim xyLabelFont As String = dt.Rows(i).Item("XYLabelFont")
        '            Dim arrXYLabelFont() As String
        '            arrXYLabelFont = xyLabelFont.Split(",")
        '            If arrXYLabelFont(2) = "Bold" Then
        '                Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
        '                Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
        '            ElseIf arrXYLabelFont(2) = "Regular" Then
        '                Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
        '                Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
        '            ElseIf arrXYLabelFont(2) = "Italic" Then
        '                Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
        '                Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
        '            End If
        '            Chart_Ctrl.ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
        '            Chart_Ctrl.ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

        '            genChartArea.Axes(0).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
        '            genChartArea.Axes(1).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

        '            genChartArea.Axes(0).MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
        '            genChartArea.Axes(1).MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))


        '            If Chart_Ctrl.Titles.Count > 0 Then
        '                Chart_Ctrl.Titles.Clear()
        '            End If

        '            Chart_Ctrl.Titles.Add("")
        '            Chart_Ctrl.Titles(0).Text = dt.Rows(i).Item("Titile")
        '            Chart_Ctrl.Titles(0).Alignment = ContentAlignment.MiddleCenter

        '            Dim titleFnt As String = dt.Rows(i).Item("TitleFont")
        '            Dim arrTitleFnt() As String
        '            arrTitleFnt = titleFnt.Split(",")

        '            If arrTitleFnt(2) = "Bold" Then
        '                Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
        '            ElseIf arrTitleFnt(2) = "Regular" Then
        '                Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Regular)
        '            ElseIf arrTitleFnt(2) = "Italic" Then
        '                Chart_Ctrl.Titles(0).Font = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Italic)
        '            End If
        '            Chart_Ctrl.Titles(0).ForeColor = Color.FromArgb(CInt(arrTitleFnt(3)))

        '            If Not dt.Rows(i).Item("BorderSkinStyle") = "None" Then
        '                Chart_Ctrl.BorderSkin.PageColor = Color.Transparent
        '            End If
        '            Select Case dt.Rows(i).Item("BorderSkinStyle")
        '                Case "None"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.None

        '                Case "FrameThin1"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1
        '                Case "FrameThin2"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2
        '                Case "FrameThin3"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3
        '                Case "FrameThin4"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin4
        '                Case "FrameThin5"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin5
        '                Case "FrameThin6"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin6
        '                Case "FrameTitle1"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1
        '                Case "FrameTitle2"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle2
        '                Case "FrameTitle3"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle3
        '                Case "FrameTitle4"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle4
        '                Case "FrameTitle5"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle5
        '                Case "FrameTitle6"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle6
        '                Case "FrameTitle7"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle7
        '                Case "FrameTitle8"
        '                    Chart_Ctrl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle8

        '                Case Else
        '                    ' do the defalut action
        '            End Select

        '            Chart_Ctrl.Location = New Point(CInt(dt.Rows(i).Item("ChartLocX")), CInt(dt.Rows(i).Item("ChartLocY")))
        '            Chart_Ctrl.Size = New Size(CInt(dt.Rows(i).Item("Width")), CInt(dt.Rows(i).Item("Height")))
        '        Else
        '            Chart_Ctrl.Series.Add(dt.Rows(i).Item("Seriesname"))
        '            Chart_Ctrl.Series(i - 1).Color = Color.FromArgb(CInt(dt.Rows(i).Item("SeriesColor")))
        '            Chart_Ctrl.Series(i - 1).MarkerColor = Color.FromArgb(CInt(dt.Rows(i).Item("MarkerColor")))
        '            Chart_Ctrl.Series(i - 1).MarkerSize = dt.Rows(i).Item("Markersize")
        '            Chart_Ctrl.Series(i - 1).ChartType = dt.Rows(i).Item("ChartType")
        '            Chart_Ctrl.Series(i - 1).MarkerStyle = dt.Rows(i).Item("MarkerStyle")
        '            'Chart_Ctrl.Series(i - 1).CustomProperties="LabelStyle=Top"

        '            If dt.Rows(i).Item("AxisEnabled") = "1" Then
        '                Chart_Ctrl.Series(i - 1).IsValueShownAsLabel = True
        '            Else
        '                Chart_Ctrl.Series(i - 1).IsValueShownAsLabel = False
        '            End If
        '            Chart_Ctrl.Series(i - 1).LabelForeColor = Color.FromArgb(CInt(dt.Rows(i).Item("Axislblcolor")))

        '            Chart_Ctrl.Legends.Add(dt.Rows(i).Item("Seriesname"))

        '            Chart_Ctrl.Legends(i - 1).ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("LegentColor")))
        '            Chart_Ctrl.Legends(i - 1).BackColor = Color.Transparent

        '            Chart_Ctrl.Series(i - 1).ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
        '            Chart_Ctrl.Series(i - 1).XValueType = ChartValueType.String 'X value type

        '            Chart_Ctrl.Series(i - 1).BorderWidth = 2
        '            If dt.Rows(0).Item("LegentEnabled") = "False" Then
        '                Chart_Ctrl.Legends(i - 1).Position.Width = 0
        '                Chart_Ctrl.Legends(i - 1).Position.Height = 0
        '            Else
        '                Chart_Ctrl.Legends(i - 1).Enabled = True
        '                Chart_Ctrl.Legends(i - 1).Alignment = StringAlignment.Far
        '                Chart_Ctrl.Legends(i - 1).Position.Width = 100
        '                Chart_Ctrl.Legends(i - 1).Position.Height = 10
        '                Chart_Ctrl.Legends(i - 1).Position.X = 70
        '                Chart_Ctrl.Legends(i - 1).Position.Y = 0
        '            End If


        '            Dim Ch_TH As New ChartSeriesTHValue

        '            If Not String.IsNullOrEmpty(dt.Rows(i).Item("SeriesTHValues")) Then
        '                Dim S_ThVal() As String = dt.Rows(i).Item("SeriesTHValues").ToString.Split(",")
        '                Dim S_ThColor() As String = dt.Rows(i).Item("SeriesTHColor").ToString.Split(",")
        '                Ch_TH.ThresholdValue.AddRange(S_ThVal.Take(S_ThVal.Length - 1))
        '                Ch_TH.THPointsColor.AddRange(S_ThColor.Take(S_ThColor.Length - 1))
        '                Ch_TH.TagName = dt.Rows(i).Item("Seriesname")
        '                Chart_Ctrl.Series_TH_Data.Add(Ch_TH)
        '            Else
        '                Chart_Ctrl.Series_TH_Data.Add(Ch_TH)
        '            End If




        '            'Read From Storage File
        '            Chart_Ctrl.Series(i - 1).YValueMembers = dt.Rows(i).Item("SeriesYExp")
        '            Dim path As String = dt.Rows(i).Item("Dt_StoreLoc")
        '            If Not (Not path Is Nothing AndAlso String.IsNullOrEmpty(path)) Then
        '                Dim idx As Integer = OPC_ChannelList_Class.OPC_Channel_Name.IndexOf(dt.Rows(i).Item("SeriesYExp"))
        '                If Not idx = -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
        '                    Dim g_ds = New DataSet
        '                    If IO.File.Exists(path) Then
        '                        'g_ds.ReadXml(path)
        '                        MyDecryptor(g_ds, path)
        '                        For j As Integer = 0 To g_ds.Tables(0).Rows.Count - 1
        '                            Chart_Ctrl.Series(i - 1).Points.AddXY(CDate(g_ds.Tables(0).Rows(j).Item(0)).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), g_ds.Tables(0).Rows(j).Item(1))
        '                        Next
        '                    End If

        '                End If

        '            End If

        '            Chart_Ctrl.Series(i - 1).Font = New Font("Verdana", 8, FontStyle.Regular)
        '            'End If
        '        End If
        '    Next

        '    Chart_Ctrl.BringToFront()
        '    Page_Ctrl.Controls.Add(Chart_Ctrl) 'Add DevexpressControls in panel
        '    _iniChartName += 1
        'Catch ex As Exception
        '    _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDMChart()")
        '    MainErrorPV.SetError(lblAlert, "Error !!!")
        'End Try

    End Sub

    Private Function ProcAddProperties(ByVal seriesName As String, ByVal yExpression As String, ByVal seriesColor As Integer,
                                        ByVal chartType As String, ByVal markerStyle As String, ByVal markerSize As Integer,
                                        ByVal markercolor As Integer, ByVal axisLabelColor As Integer, ByVal axixLabelEnabled As Boolean) As ChartProperties

        Dim chartProp As New ChartProperties

        chartProp.SeriesName = seriesName
        chartProp.YExpression = yExpression
        ' chartProp.SeriesColor = seriesColor
        chartProp.ChartType = chartType
        chartProp.MarkerStyle = markerStyle
        chartProp.MarkerSize = markerSize
        chartProp.Markercolor = markercolor
        chartProp.AxisLabelColor = axisLabelColor
        chartProp.AxixLabelEnabled = axixLabelEnabled

        Return chartProp
    End Function
    Private Sub Properties(ByVal TrendCtl As MultiTrendCtrl, ByVal dt As DataTable)
        Try


            If TrendCtl.ChartControl1.Series.Count > 0 Then
                TrendCtl.ChartControl1.ResetAutoValues()
                TrendCtl.ChartControl1.ChartAreas.Clear()
                TrendCtl.ChartControl1.Series.Clear()
                TrendCtl.ChartControl1.ChartAreas.Add("ChartArea1")
            End If


            TrendCtl.ChartControl1.AccessibleDescription = dt.Rows(1).Item("TSeriesYExp")
            Dim DataTbl As New DataTable
            DataTbl = SAMAHistorian_ChannelList.ChannelDatatable.Item(SAMAHistorian_ChannelList.ChannelReportname.IndexOf(dt.Rows(1).Item("TSeriesYExp")))


            Dim clmcnt As Integer = _Listtrender_Series.Count
            For i As Integer = 0 To clmcnt - 1
                TrendCtl.ChartControl1.Series.Add(_Listtrender_Series.Item(i).SeriesName)
            Next


            TrendCtl.DataGridViewCtrl1.Rows.Clear()
            For j As Integer = 0 To TrendCtl.ChartControl1.Series.Count - 1
                Dim k = TrendCtl.DataGridViewCtrl1.Rows.Add
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("SerialNo").Value = j + 1
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("LowRange").Value = dt.Rows(0).Item("TYMin")
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("HighRange").Value = dt.Rows(0).Item("TYMax")
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("TagName").Value = _Listtrender_Series.Item(j).SeriesName
                ' TrendCtl.DataGridViewCtrl1.Rows(j).Cells("PenColour").Style.BackColor = Color.FromArgb(_Listtrender_Series.Item(j).SeriesColor)
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("IsActive").Value = True
                ' TrendCtl.DataGridViewCtrl1.Rows(j).Cells("TagValue").Value = DataTbl.Rows(DataTbl.Rows.Count - 2)(_Listtrender_Series.Item(j).SeriesName)
                ' TrendCtl.DataGridViewCtrl1.Refresh()


                ' TrendCtl.ChartControl1.Series(j).Color = Color.FromArgb(_Listtrender_Series.Item(j).SeriesColor)
                TrendCtl.ChartControl1.Series(j).MarkerColor = Color.FromArgb(_Listtrender_Series.Item(0)._markercolor)
                TrendCtl.ChartControl1.Series(j).MarkerSize = _Listtrender_Series.Item(0)._markerSize

                Select Case _Listtrender_Series.Item(0)._chartType
                    Case "Line"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Line
                    Case "Spline"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Spline
                    Case "Area"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Area
                    Case "SplineArea"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.SplineArea
                    Case "StackedArea"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedArea
                    Case "Bar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Bar
                    Case "StackedBar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedBar
                    Case "Column"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Column
                    Case "StackedColumn"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedColumn
                    Case "Pie"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Pie
                    Case "Doughnut"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Doughnut
                    Case "Pyramid"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Pyramid
                    Case "Funnel"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Funnel
                    Case "Radar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Radar
                End Select
                'chrartCtl.Series(0).ChartType = (CboxChartType.SelectedIndex)

                If _Listtrender_Series.Item(0)._markerStyle <> 0 Then
                    TrendCtl.ChartControl1.Series(j).MarkerStyle = _Listtrender_Series.Item(0)._markerStyle
                Else
                    TrendCtl.ChartControl1.Series(j).MarkerStyle = MarkerStyle.None
                End If
                If _Listtrender_Series.Item(0).AxixLabelEnabled Then
                    TrendCtl.ChartControl1.Series(j).IsValueShownAsLabel = True
                Else
                    TrendCtl.ChartControl1.Series(j).IsValueShownAsLabel = False
                End If
                TrendCtl.ChartControl1.Series(j).LabelForeColor = Color.FromArgb(_Listtrender_Series.Item(0)._axisLabelColor)
                TrendCtl.ChartControl1.Series(j).ToolTip = TrendCtl.ChartControl1.Series(j).Name & "," & dt.Rows(0).Item("TYTitle") & ": #VALY"         ' & txtXAxisTitle.Text & ": #VALX"
                TrendCtl.ChartControl1.Series(j).XValueType = ChartValueType.Time 'X value type
                TrendCtl.ChartControl1.Series(j).BorderWidth = 2


                TrendCtl.ChartControl1.Series(j).YValueMembers = _Listtrender_Series.Item(0)._yExpression

                '  chrartCtl.Series(j).XValueMember = _ListChart_Series.Item(0)._xExpression

                TrendCtl.ChartControl1.Series(j).Font = New Font("Verdana", 8, FontStyle.Regular)

                'If j > 0 Then
                '    TrendCtl.ChartControl1.ChartAreas(0).AxisY2.Enabled = AxisEnabled.True
                '    TrendCtl.ChartControl1.Series(j).YAxisType = AxisType.Secondary

                'End If
            Next

            SAMAHistorianChannels.AssigntoControl(DataTbl, _Listtrender_Series.Item(0)._yExpression)


            If dt.Rows(0).Item("TYMax") = "0" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Tag = "True"
                TrendCtl.ChartControl1.ResetAutoValues()
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Maximum = Double.NaN
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Minimum = Double.NaN
                TrendCtl.ChartControl1.ResetAutoValues()
            Else
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Tag = "False"
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Maximum = dt.Rows(0).Item("TYMax")
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Minimum = dt.Rows(0).Item("TYMin")

            End If
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Format = "HH:mm:ss"



            Dim xyLabelFont As String = dt.Rows(0).Item("TXYLabelFont")
            Dim arrXYLabelFont() As String
            arrXYLabelFont = xyLabelFont.Split(",")
            If arrXYLabelFont(2) = "Bold" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Bold)
            ElseIf arrXYLabelFont(2) = "Regular" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Regular)
            ElseIf arrXYLabelFont(2) = "Italic" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.Font = New Font(arrXYLabelFont(0), CInt(arrXYLabelFont(1)), FontStyle.Italic)
            End If
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

            TrendCtl.ChartControl1.ChartAreas(0).AxisX.MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.MajorTickMark.LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))

            TrendCtl.ChartControl1.ChartAreas(0).Axes(0).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))
            TrendCtl.ChartControl1.ChartAreas(0).Axes(1).LineColor = Color.FromArgb(CInt(arrXYLabelFont(3)))


            TrendCtl.ChartControl1.ChartAreas(0).AxisX.Title = dt.Rows(0).Item("TXTitle")
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.Title = dt.Rows(0).Item("TYTitle")

            TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleForeColor = Color.FromArgb(dt.Rows(0).Item("TXYTitleColor"))
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleForeColor = Color.FromArgb(dt.Rows(0).Item("TXYTitleColor"))


            Dim titleFnt As String = dt.Rows(0).Item("TTitleFont")
            Dim arrTitleFnt() As String
            arrTitleFnt = titleFnt.Split(",")

            If arrTitleFnt(2) = "Bold" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
            ElseIf arrTitleFnt(2) = "Regular" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Regular)
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
            ElseIf arrTitleFnt(2) = "Italic" Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Italic)
                TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleFont = New Font(arrTitleFnt(0), CInt(arrTitleFnt(1)), FontStyle.Bold)
            End If
            ' TrendCtl.ChartControl1.Titles(0).ForeColor = Color.FromArgb(CInt(arrTitleFnt(3)))


            TrendCtl.ChartControl1.ChartAreas(0).BackColor = Color.FromArgb(dt.Rows(0).Item("TChartBGColor"))
            TrendCtl.ChartControl1.BackColor = Color.FromArgb(dt.Rows(0).Item("TChartBGColor"))
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.FromArgb(dt.Rows(0).Item("TGridColor"))
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.FromArgb(dt.Rows(0).Item("TGridColor"))

            If TrendCtl.ChartControl1.Titles.Count > 0 Then
                TrendCtl.ChartControl1.Titles.Clear()
            End If


            TrendCtl.ChartControl1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorX.AutoScroll = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorY.AutoScroll = True


            TrendCtl.ChartControl1.Titles.Add("")
            TrendCtl.ChartControl1.Titles(0).Text = dt.Rows(0).Item("TTitle")
            TrendCtl.ChartControl1.Titles(0).Alignment = ContentAlignment.MiddleCenter
            ' TrendCtl.ChartControl1.Titles(0).ForeColor = Title_Color
            ' TrendCtl.ChartControl1.Titles(0).Font = Title_Font
            If Not (dt.Rows(0).Item("TBorderSkinStyle")) = "None" Then
                TrendCtl.ChartControl1.BorderSkin.PageColor = Color.Transparent
            End If
            Select Case dt.Rows(0).Item("TBorderSkinStyle")
                Case "None"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.None

                Case "FrameThin1"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1
                Case "FrameThin2"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2
                Case "FrameThin3"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3
                Case "FrameThin4"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin4
                Case "FrameThin5"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin5
                Case "FrameThin6"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin6
                Case "FrameTitle1"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1
                Case "FrameTitle2"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle2
                Case "FrameTitle3"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle3
                Case "FrameTitle4"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle4
                Case "FrameTitle5"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle5
                Case "FrameTitle6"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle6
                Case "FrameTitle7"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle7
                Case "FrameTitle8"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle8


                Case Else
                    ' do the defalut action
            End Select


        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Trender-Properties()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub


    ''' <summary>
    '''  Create Panel Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddPanel(ByVal width As Integer, ByVal height As Integer, ByVal locX As Object, ByVal locY As Object, ByVal edgeRaised As String, ByVal bgColor As Object)

        Try
            Panel_Ctrl = New Panel
            Panel_Ctrl.Name = "Panel" & _iniPanelName
            Panel_Ctrl.Tag = "Panel"
            Panel_Ctrl.MinimumSize = Ctrl_MinSize

            Panel_Ctrl.BorderStyle = BorderStyle.None

            AddHandler Panel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Panel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Panel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Panel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Panel_Ctrl.Paint, AddressOf panel_Ctrl_Paint
            AddHandler Panel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave
            If edgeRaised = "Edge" Then
                Panel_Ctrl.AccessibleDescription = "Edge"
            End If
            Panel_Ctrl.BackColor = Color.FromArgb(bgColor)
            Panel_Ctrl.Location = New Point(locX, locY)
            Panel_Ctrl.Width = width
            Panel_Ctrl.Height = height
            Page_Ctrl.Controls.Add(Panel_Ctrl)

            'Selected_Ctrl = Panel_Ctrl
            Call Border(Panel_Ctrl) 'Create Border
            Panel_Ctrl.SendToBack()
            _iniPanelName += 1
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddPanel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    '''  Create Picture Box Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddPictureBox(ByVal width As Integer, ByVal height As Integer, ByVal locX As Object, ByVal locY As Object, ByVal isStretch As String, ByVal imageName As Object)
        Try

            PictureBox_Ctrl = New PictureBox
            PictureBox_Ctrl.Name = "Pic" & _iniPicName
            PictureBox_Ctrl.Tag = "PicBox"
            PictureBox_Ctrl.MinimumSize = Ctrl_MinSize

            'PictureBox_Ctrl.BorderStyle = BorderStyle.FixedSingle

            AddHandler PictureBox_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler PictureBox_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler PictureBox_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler PictureBox_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler PictureBox_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave


            PictureBox_Ctrl.Location = New Point(locX, locY)
            PictureBox_Ctrl.Width = width
            PictureBox_Ctrl.Height = height
            PictureBox_Ctrl.BackColor = Color.Transparent

            If isStretch = "True" Then
                PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Stretch
            Else
                PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Center
            End If

            If Not imageName = "(None)" Then
                PictureBox_Ctrl.BackgroundImage = Image.FromFile(Application.StartupPath & "\Resources\" & imageName)
                PictureBox_Ctrl.AccessibleDescription = imageName
            Else
                PictureBox_Ctrl.AccessibleDescription = "(None)"
            End If
            Page_Ctrl.Controls.Add(PictureBox_Ctrl)


            PictureBox_Ctrl.SendToBack()
            _iniPicName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddPictureBox()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    '''  Create Grid Table  Based on the XML File Properties !!
    ''' </summary>

    Private Sub AddGrid_Table(ByVal width As Integer, ByVal height As Integer, ByVal locX As Object, ByVal locY As Object, ByVal dt As DataTable)

        Try

            Grid_TableCtrl = New DataGridViewCtrl
            Grid_TableCtrl.Name = dt.Rows(0).Item("Ctrl_Name")
            Ctrl_NameList.Add(Grid_TableCtrl.Name)
            Grid_TableCtrl.Tag = "Grid"
            Grid_TableCtrl.MinimumSize = GridCtrl_MinSize

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Grid_TableCtrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")

                'Dim indx As Integer = OPCDAChannelsList.OPC_Channel_Name.IndexOf(dt.Rows(0).Item("ChannelName"))
                'If indx > -1 Then
                '    If OPCDAChannelsList.OPC_Multiview(indx) Then
                '        Grid_TableCtrl.Columns.Add("Tags", "Tags")
                '        Grid_TableCtrl.Columns.Add("DateTime", "Date Time")
                '        Grid_TableCtrl.Columns.Add("Value", "Value")
                '    End If
                'End If
            Else
                Grid_TableCtrl.AccessibleDescription = ""
            End If



            AddHandler Grid_TableCtrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Grid_TableCtrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Grid_TableCtrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Grid_TableCtrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Grid_TableCtrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Grid_TableCtrl.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Grid_TableCtrl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Grid_TableCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Grid_TableCtrl.Width = width
            Grid_TableCtrl.Height = height
            Grid_TableCtrl.Location = New Point(locX, locY)

            Grid_TableCtrl.RowHeadersVisible = False

            Grid_TableCtrl.AllowUserToAddRows = False
            Grid_TableCtrl.ReadOnly = True
            Grid_TableCtrl.MultiSelect = False
            Grid_TableCtrl.AllowUserToResizeColumns = True
            Grid_TableCtrl.RowsDefaultCellStyle.BackColor = Color.FromArgb(CInt(dt.Rows(0).Item("C_BC")))
            Grid_TableCtrl.RowsDefaultCellStyle.ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("C_FC")))
            Grid_TableCtrl.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(CInt(dt.Rows(0).Item("SL_BC")))
            Grid_TableCtrl.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("SL_FC")))

            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CInt(dt.Rows(0).Item("AL_BC")))
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("AL_FC")))
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(CInt(dt.Rows(0).Item("SL_BC")))
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("SL_FC")))

            'Font
            Dim cFont, alFont
            cFont = dt.Rows(0).Item("C_Font").ToString.Split(",")
            alFont = dt.Rows(0).Item("AL_Font").ToString.Split(",")
            If cFont(2) = "Regular" Then
                Grid_TableCtrl.RowsDefaultCellStyle.Font = New Font(CStr(cFont(0)), CInt(cFont(1)), FontStyle.Regular)
            ElseIf cFont(2) = "Bold" Then
                Grid_TableCtrl.RowsDefaultCellStyle.Font = New Font(CStr(cFont(0)), CInt(cFont(1)), FontStyle.Bold)
            ElseIf cFont(2) = "Italic" Then
                Grid_TableCtrl.RowsDefaultCellStyle.Font = New Font(CStr(cFont(0)), CInt(cFont(1)), FontStyle.Italic)
            Else
                Grid_TableCtrl.RowsDefaultCellStyle.Font = New Font(CStr(cFont(0)), CInt(cFont(1)), FontStyle.Regular)
            End If

            If alFont(2) = "Regular" Then
                Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = New Font(CStr(alFont(0)), CInt(alFont(1)), FontStyle.Regular)
            ElseIf alFont(2) = "Bold" Then
                Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = New Font(CStr(alFont(0)), CInt(alFont(1)), FontStyle.Bold)
            ElseIf alFont(2) = "Italic" Then
                Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = New Font(CStr(alFont(0)), CInt(alFont(1)), FontStyle.Italic)
            Else
                Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = New Font(CStr(alFont(0)), CInt(alFont(1)), FontStyle.Regular)
            End If
            'Read From Storage File
            Dim path As String = dt.Rows(0).Item("Dt_StoreLoc")
            If Not (Not path Is Nothing AndAlso String.IsNullOrEmpty(path)) Then
                Dim idx As Integer = OPC_ChannelList_Class.OPC_Channel_Name.IndexOf(Grid_TableCtrl.AccessibleDescription)
                If Not idx = -1 And Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                    Dim g_ds = New DataSet
                    If IO.File.Exists(path) Then
                        'g_ds.ReadXml(path)
                        MyDecryptor(g_ds, path)

                        If g_ds.Tables(0) IsNot Nothing Then
                            ' Create DataView 
                            Dim view As New DataView(g_ds.Tables(0))

                            ' Sort by Date_Time column in descending order
                            view.Sort = "Date_Time DESC"
                            If g_ds.Tables(0).Columns.Count = 2 Then
                                If Not Grid_TableCtrl.Columns.Count > 0 Then
                                    Grid_TableCtrl.Columns.Add("DateTime", "Date Time")
                                    Grid_TableCtrl.Columns.Add("Value", "Value")
                                End If

                                For Each rw As DataRowView In view
                                    Grid_TableCtrl.Rows.Add(New String() {rw(0), rw(1)})
                                Next
                            ElseIf g_ds.Tables(0).Columns.Count = 3 Then
                                If Not Grid_TableCtrl.Columns.Count > 0 Then
                                    Grid_TableCtrl.Columns.Add("Tags", "Tags")
                                    Grid_TableCtrl.Columns.Add("DateTime", "Date Time")
                                    Grid_TableCtrl.Columns.Add("Value", "Value")
                                End If

                                For Each rw As DataRowView In view
                                    Grid_TableCtrl.Rows.Add(New String() {rw(0), rw(1), rw(2)})
                                Next
                            End If
                        End If

                    End If

                End If
            End If



            Grid_TableCtrl._ThresholdValue.Clear()
            Grid_TableCtrl._THForeColor.Clear()
            Grid_TableCtrl._THBackColor.Clear()
            Grid_TableCtrl._THFont.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, thfC, thbC, thFont As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                thfC = New ArrayList(dt.Rows(0).Item("lblTHForeColor").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                thFont = New ArrayList(dt.Rows(0).Item("lblTHFont").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    Grid_TableCtrl._ThresholdValue.Add(thv(i))
                    Grid_TableCtrl._THForeColor.Add(CInt(thfC(i)))
                    Grid_TableCtrl._THBackColor.Add(CInt(thbC(i)))
                    Grid_TableCtrl._THFont.Add(thFont(i))
                Next
            End If
            Grid_TableCtrl.Font = New Font("Verdana", 9, FontStyle.Bold)



            Page_Ctrl.Controls.Add(Grid_TableCtrl) 'Add Grid_TableCtrl in panel

            Grid_TableCtrl.BringToFront()
            _iniTableName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddGrid_Table()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    Private Sub Add_Annunciator(ByVal width As Integer, ByVal height As Integer, ByVal locX As Object, ByVal locY As Object, ByVal dt As DataTable)

        Try
            Annunciator_Ctrl = New AnnunciatorCtrl
            Annunciator_Ctrl.Name = dt.Rows(0).Item("Ctrl_Name")
            Ctrl_NameList.Add(Annunciator_Ctrl.Name)
            Annunciator_Ctrl.Tag = "Annunciator"
            Annunciator_Ctrl.MinimumSize = Annunciator_Ctrl_MinSize

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Annunciator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
                AnnunciatorPropertiesForm.cBoxActionChannel.Items.Add(dt.Rows(0).Item("ChannelName").ToString)
            Else
                Annunciator_Ctrl.AccessibleDescription = ""
            End If
            'Dim asdd = AnnunciatorPropertiesForm.cBoxActionChannel
            AddHandler Annunciator_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Annunciator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Annunciator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Annunciator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Annunciator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Annunciator_Ctrl.Width = width
            Annunciator_Ctrl.Height = height
            Annunciator_Ctrl.Location = New Point(locX, locY)

            Annunciator_Ctrl.BackColor = Color.FromArgb(CInt(dt.Rows(0).Item("C_BC")))
            Annunciator_Ctrl.ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("C_FC")))

            Page_Ctrl.Controls.Add(Annunciator_Ctrl) 'Add AnnunCiator_ctrl in panel
            Annunciator_Ctrl.BringToFront()

            If Annunciator_Ctrl.AccessibleDescription <> "" Then
                'AnnunciatorPropertiesForm.AnnunciatorFlow_Properties(Me.Annunciator_Ctrl)
                Dim asdd = AnnunciatorPropertiesForm.cBoxActionChannel.Items 'AnnAnnunciatorFlow_Properties(MainPage.Annunciator_Ctrl)
            End If




            Dim indx = Me.channelList.Channel_Name.IndexOf(dt.Rows(0).Item("ChannelName")) 'SAMAHistorian_ChannelList.ChannelReportname.IndexOf(PageTreeView.SelectedNode.Text)


            If indx >= 0 Then
                Dim QvalDt = Me.channelList._Query_Channel(indx)
                If Not String.IsNullOrEmpty(QvalDt) Then

                    Dim CtrlAnn() As Control = Me.Controls.Find(dt.Rows(0).Item("Ctrl_Name"), True)
                    CtrlAnn(0).Controls.Clear()

                    Dim TagParam = QvalDt.Split("^")
                    Dim Qval = TagParam(1).Split(",")

                    For k = 0 To Qval.Length - 1
                        Dim TagNo = Qval(k).Split("~")
                        Dim Button = New Button_Control
                        Button.Size = New Size(118, 50)
                        Button.BackColor = Color.Gainsboro
                        Button.Tag = TagNo(1).ToString
                        If TagParam(0) = "Tagpar_AliasName" Then
                            Button.Text = TagNo(1) & "   " & TagNo(0)
                        ElseIf TagParam(0) = "AliasName" Then
                            Button.Text = TagNo(0)
                        ElseIf TagParam(0) = "Tagpar" Then
                            Button.Text = TagNo(1)
                        Else
                            Button.Text = TagNo(1).ToString
                        End If
                        Button.Name = TagNo(1).ToString
                        CtrlAnn(0).Controls.Add(Button)
                    Next
                    _iniTableName += 1
                End If
            End If



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Add_Annunciator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Set Storage Location 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddSettings(ByVal dt As DataTable)
        Try
            Storage_Loc = dt.Rows(0).Item("Storage_Loc")
            Server_PushDataPath = dt.Rows(0).Item("RemotePushDatapath")
            Server_PullDataPath = dt.Rows(0).Item("RemotePullDatapath")
            _serverIP = dt.Rows(0).Item("ServerIP")
            _oldPass = dt.Rows(0).Item("OldPass")
            _NewPass = dt.Rows(0).Item("NewPass")
            _RetypePass = dt.Rows(0).Item("RetypePass")

            If dt.Rows(0).Item("AutoReconnect") = "True" Then
                _AutoReconnect = True
                tmrCheckConnectivity.Enabled = True
            Else
                _AutoReconnect = False
                tmrCheckConnectivity.Enabled = False
            End If


            If dt.Rows(0).Item("OPC_AllowClients") = "True" Then
                blnOPC_AllowClients = True
            End If
            If dt.Rows(0).Item("DB_AllowClients") = "True" Then
                blnDB_AllowClients = True
            End If
            If dt.Rows(0).Item("RunMode") = "True" Then
                _runMode = True
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddSettings()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Add Page Node to TreeView
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddPages(ByVal dt As DataTable)
        '  PageTreeView.Nodes(0).Nodes(2).Nodes.Clear()
        Try
            For i As Integer = 0 To dt.Rows.Count - 1

                CreatedPages.Add(dt.Rows(i).Item("PageName"))
                Dim pnlObj() As Control
                pnlObj = Me.Controls.Find("pnlPage" & i + 1, True)
                If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                    pnlObj(0).BackColor = Color.FromArgb(CInt(dt.Rows(i).Item("PageColor")))
                    pnlObj(0).Name = dt.Rows(i).Item("PageName")

                    Dim nodepath As String = dt.Rows(i).Item("PageNodePath")
                    AddPagetoTreeview(nodepath)
                    _iniPageName += 1
                    ' Dim noda As TreeNode
                    'noda.Name = dt.Rows(i).Item("PageName")
                    'noda.ImageIndex = 7
                    'noda.SelectedImageIndex = 7

                    'PageTreeView.Nodes(0).Nodes(2).Nodes.Add(dt.Rows(i).Item("PageName"))
                    'PageTreeView.Nodes(0).Nodes(2).Nodes(i).Name = (dt.Rows(i).Item("PageName"))
                    'PageTreeView.Nodes(0).Nodes(2).Nodes(i).ImageIndex = 7
                    'PageTreeView.Nodes(0).Nodes(2).Nodes(i).SelectedImageIndex = 7
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddPagetoTreeview(ByVal path As String)
        Try

            Dim _path() As String = path.Split("\")
            Dim pagenam As String = _path(_path.Length - 1)

            For i As Integer = 0 To _path.Length - 1
                Dim node As TreeNode() = TreeViewLeft.Nodes.Find(_path(i).Trim(), True)
                If node.Length <> 0 Then
                    TreeViewLeft.SelectedNode = node(0)
                Else
                    Dim dnode As New TreeNode
                    dnode.Name = _path(i)
                    dnode.Text = _path(i)
                    dnode.ImageIndex = 7
                    dnode.SelectedImageIndex = 7
                    dnode.Tag = "PageNode"
                    TreeViewLeft.SelectedNode.Nodes.Insert(0, dnode)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Add Supra DB Channel To TreeNode DBChannel
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddChaneel(ByVal dt As DataTable)

        Try
            PageTreeView.Nodes(0).Nodes(0).Nodes.Clear()
            ReDim DBDataFormClass(dt.Rows.Count - 1) 'Redim the DBDataForm Class
            For i As Integer = 0 To dt.Rows.Count - 1
                channelList.Channel_Name.Add(dt.Rows(i).Item("Channel_Name"))
                channelList.Channel_Query.Add(dt.Rows(i).Item("ChannelQuery"))
                channelList.Channel_Flag.Add(dt.Rows(i).Item("ChannelType"))
                channelList._Query_Channel.Add(dt.Rows(i).Item("_DBQuery"))
                channelList.DBChannel_RefreshTime.Add(dt.Rows(i).Item("DBChannel_RefreshTime"))

                PageTreeView.Nodes(0).Nodes(0).Nodes.Add(dt.Rows(i).Item("Channel_Name"))
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).Name = channelList.Channel_Name(i)
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).Tag = "True"

                Dim rfTime As Integer
                rfTime = CInt(dt.Rows(i).Item("DBChannel_RefreshTime")) * 1000

                If Server_Flag Then
                    DBDataFormClass(i) = New DBDataForm(dt.Rows(i).Item("ChannelType"), dt.Rows(i).Item("_DBQuery"), rfTime, Constr, 1, dt.Rows(i).Item("Channel_Name")) 'Create Instace Class to each Query
                Else
                    DBDataFormClass(i) = New DBDataForm(dt.Rows(i).Item("ChannelType"), dt.Rows(i).Item("_DBQuery"), rfTime, Constr, 0, dt.Rows(i).Item("Channel_Name")) 'Create Instace Class to each Query
                End If


                DBDataFormClass(i).Tag = i
                DBDataFormClass(i).Name = dt.Rows(i).Item("Channel_Name")
                DBDataFormClass(i).AllowTransparency = True
                DBDataFormClass(i).Show()
                DBDataFormClass(i).Visible = False
                DBDataFormClass(i).AllowTransparency = False
            Next
            PageTreeView.Nodes(0).Nodes(0).ExpandAll()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddChaneel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Recreate the DataForm class perform OPC Channel Operation
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub RefreshOPC_Channel()
        Try

            For i As Integer = 0 To OPC_ChannelList_Class.OPC_Channel_Name.Count - 1
                opcCnfgTags(i).Watcher.Path = Server_PullDataPath
                opcCnfgTags(i).Watcher.EnableRaisingEvents = True
            Next



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RefreshOPC_Channel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Recreate the DBData form to perform SAMA Channel operation
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub RefreshDBChannel()
        Try


            For i As Integer = 0 To channelList.Channel_Name.Count - 1
                DBDataFormClass(i).Watcher.Path = Server_PullDataPath
                DBDataFormClass(i).Watcher.EnableRaisingEvents = True
            Next
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RefreshDBChannel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Add OPC Channel To TreeNode OPCChannel
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddOpcChaneel(ByVal dt As DataTable)
        Try
            PageTreeView.Nodes(0).Nodes(1).Nodes.Clear()
            Dim rst As Integer
            Dim itemdata As ItemDef
            ReDim opcCnfgTags(dt.Rows.Count - 1)
            For i As Integer = 0 To dt.Rows.Count - 1
                OPC_ChannelList_Class.OPC_Channel_Name.Add(dt.Rows(i).Item("OPC_ChannelName"))
                OPC_ChannelList_Class.OPC_ServerName.Add(dt.Rows(i).Item("OPC_OPCServer"))
                OPC_ChannelList_Class.OPC_OPCItems.Add(dt.Rows(i).Item("OPC_Tag"))
                OPC_ChannelList_Class.OPC_RefreshTime.Add(dt.Rows(i).Item("OPC_RefreshTime"))
                OPC_ChannelList_Class.OPC_HistoryLength.Add(dt.Rows(i).Item("OPC_HisLength"))
                OPC_ChannelList_Class.OPC_LastnnHourHistory.Add(dt.Rows(i).Item("OPC_nnHoursHistory"))

                If dt.Rows(i).Item("OPC_IsMultiview") = "True" Then
                    OPC_ChannelList_Class.OPC_Multiview.Add(True)

                Else
                    OPC_ChannelList_Class.OPC_Multiview.Add(False)
                End If

                If Server_Flag Then

                    Dim srvName = OPC_ChannelList_Class.OPC_ServerName(i)
                    Dim isavail As Integer = -1
                    If Not OPC_ServeNames Is Nothing Then
                        isavail = Array.IndexOf(OPC_ServeNames, srvName)
                    End If
                    If isavail <> -1 Then
                        If OPC_Servers(isavail) Is Nothing Then
                            OPC_Servers(isavail) = New OpcServer
                            If RemoteOPCServer = "" Then
                                rst = OPC_Servers(isavail).Connect(srvName)
                            Else
                                rst = OPC_Servers(isavail).Connect(RemoteOPCServer, srvName)
                            End If



                        End If

                        Try
                            If Not HRESULTS.Failed(rst) Then

                                Dim rfTime As Integer = OPC_ChannelList_Class.OPC_RefreshTime(i) * 1000

                                If OPC_ChannelList_Class.OPC_LastnnHourHistory(i) > 0 Then
                                    Dim hrCnt As Integer = OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
                                    opcCnfgTags(i) = New DataForm(OPC_Servers(isavail), rfTime, 1, 1, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                                Else
                                    opcCnfgTags(i) = New DataForm(OPC_Servers(isavail), rfTime, 0, 1, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                                End If
                                Dim OPC_Item() As String = OPC_ChannelList_Class.OPC_OPCItems(i).Split(",")
                                For k As Integer = 0 To OPC_Item.Length - 1
                                    itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                    If itemdata Is Nothing Then     ' probably first use
                                        opcCnfgTags(i)._asyncRefrGroup.Add(OPC_Item(k))      ' add item to group if not found
                                    End If
                                    itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                    If itemdata Is Nothing Then     ' there is a problem
                                        MsgBox("Item not found.")
                                        Exit For
                                    End If
                                Next

                            End If
                        Catch ex As Exception
                            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddOPC_Channel()")
                            MainErrorPV.SetError(lblAlert, "Error !!!")
                        End Try
                    ElseIf srvName.contains("^") Then
                        Try
                            Dim opsrv As New OpcServer
                            rst = opsrv.Connect(srvName.Split("^")(0), srvName.Split("^")(1))
                            If Not HRESULTS.Failed(rst) Then
                                Dim rfTime As Integer = OPC_ChannelList_Class.OPC_RefreshTime(i) * 1000

                                If OPC_ChannelList_Class.OPC_LastnnHourHistory(i) > 0 Then
                                    Dim hrCnt As Integer = OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
                                    opcCnfgTags(i) = New DataForm(opsrv, rfTime, 1, 1, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                                Else
                                    opcCnfgTags(i) = New DataForm(opsrv, rfTime, 0, 1, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                                End If
                                Dim OPC_Item() As String = OPC_ChannelList_Class.OPC_OPCItems(i).Split(",")
                                For k As Integer = 0 To OPC_Item.Length - 1
                                    itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                    If itemdata Is Nothing Then     ' probably first use
                                        opcCnfgTags(i)._asyncRefrGroup.Add(OPC_Item(k))      ' add item to group if not found
                                    End If
                                    itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                    If itemdata Is Nothing Then     ' there is a problem
                                        MsgBox("Item not found.")
                                        Exit For
                                    End If
                                Next

                            End If
                        Catch ex As Exception
                            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddOPC_Channel()")
                            MainErrorPV.SetError(lblAlert, "Error !!!")
                        End Try
                    End If
                Else
                    Dim rfTime As Integer
                    Dim opcSerObj As New OpcServer
                    rfTime = OPC_ChannelList_Class.OPC_RefreshTime(i) * 1000
                    If OPC_ChannelList_Class.OPC_LastnnHourHistory(i) > 0 Then
                        Dim hrCnt As Integer = OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
                        opcCnfgTags(i) = New DataForm(opcSerObj, rfTime, 1, 0, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                    Else
                        opcCnfgTags(i) = New DataForm(opcSerObj, rfTime, 0, 0, OPC_ChannelList_Class.OPC_Channel_Name(i), OPC_ChannelList_Class.OPC_Multiview(i))
                    End If
                End If

                opcCnfgTags(i).Tag = i
                opcCnfgTags(i).Name = OPC_ChannelList_Class.OPC_Channel_Name(i)
                opcCnfgTags(i).AllowTransparency = True
                opcCnfgTags(i).Show()

                opcCnfgTags(i).Visible = False
                opcCnfgTags(i).AllowTransparency = False

                PageTreeView.Nodes(0).Nodes(1).Nodes.Add(OPC_ChannelList_Class.OPC_Channel_Name(i))
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).Name = OPC_ChannelList_Class.OPC_Channel_Name(i)
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).Tag = "True" 'For start And Stop Channel
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).ToolTipText = OPC_ChannelList_Class.OPC_ServerName(i) & "&" & OPC_ChannelList_Class.OPC_OPCItems(i)

            Next

            PageTreeView.Nodes(0).Nodes(1).ExpandAll()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddOpcChaneel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    Private Sub AddOPCDAservers(ByVal dt As DataTable)
        Try
            OPCDAServersCollection.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                OPCDAServersList.Configname.Add(dt.Rows(i).Item("OPCDA_ConfigName"))
                OPCDAServersList.PrimaryIPAddress.Add(dt.Rows(i).Item("OPCDA_PrimaryIP"))
                OPCDAServersList.PrimaryPortNo.Add(dt.Rows(i).Item("OPCDA_PrimaryPort"))
                OPCDAServersList.SecondaryIPAddress.Add(dt.Rows(i).Item("OPCDA_SecondaryIP"))
                OPCDAServersList.SecondaryPortNo.Add(dt.Rows(i).Item("OPCDA_SecondaryPort"))
                OPCDAServersList.RefreshInterval.Add(dt.Rows(i).Item("OPCDA_RefreshInterval"))

                If dt.Rows(i).Item("OPCDA_SecondaryIP") = "-" Then
                    If OPCDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCDA_ConfigName")) Then

                    Else
                        Dim tmpOPCDA As New Redundancy(dt.Rows(i).Item("OPCDA_PrimaryIP") + ":" + dt.Rows(i).Item("OPCDA_PrimaryPort"), "", False, Me, dt.Rows(i).Item("OPCDA_RefreshInterval"))
                        tmpOPCDA.Connect()
                        OPCDAServersCollection.Add(dt.Rows(i).Item("OPCDA_ConfigName"), tmpOPCDA)
                    End If
                Else
                    If OPCDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCDA_ConfigName")) Then
                        ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                    Else
                        Dim tmpOPCDA As New Redundancy(dt.Rows(i).Item("OPCDA_PrimaryIP") + ":" + dt.Rows(i).Item("OPCDA_PrimaryPort"), dt.Rows(i).Item("OPCDA_SecondaryIP") + ":" + dt.Rows(i).Item("OPCDA_SecondaryPort"), True, Me, dt.Rows(i).Item("OPCDA_RefreshInterval"))
                        tmpOPCDA.Connect()
                        OPCDAServersCollection.Add(dt.Rows(i).Item("OPCDA_ConfigName"), tmpOPCDA)
                    End If
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddOPCHDAservers(ByVal dt As DataTable)
        Try
            OPCHDAServersCollection.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                OPCHDAServersList.Configname.Add(dt.Rows(i).Item("OPCHDA_ConfigName"))
                OPCHDAServersList.PrimaryIPAddress.Add(dt.Rows(i).Item("OPCHDA_PrimaryIP"))
                OPCHDAServersList.PrimaryPortNo.Add(dt.Rows(i).Item("OPCHDA_PrimaryPort"))
                OPCHDAServersList.SecondaryIPAddress.Add(dt.Rows(i).Item("OPCHDA_SecondaryIP"))
                OPCHDAServersList.SecondaryPortNo.Add(dt.Rows(i).Item("OPCHDA_SecondaryPort"))

                If dt.Rows(i).Item("OPCHDA_SecondaryIP") = "-" Then
                    If OPCHDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCHDA_ConfigName")) Then
                        Dim tmpopchda As HDARedundancy = OPCHDAServersCollection(dt.Rows(i).Item("OPCHDA_ConfigName"))
                        OPCHDAServersCollection(dt.Rows(i).Item("OPCHDA_ConfigName")) = tmpopchda
                        ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                    Else
                        Dim tmpOPCHDA As New HDARedundancy(dt.Rows(i).Item("OPCHDA_PrimaryIP") + ":" + dt.Rows(i).Item("OPCHDA_PrimaryPort"), "", False, Me)
                        tmpOPCHDA.Connect()
                        OPCHDAServersCollection.Add(dt.Rows(i).Item("OPCHDA_ConfigName"), tmpOPCHDA)
                    End If
                Else
                    If OPCHDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCHDA_ConfigName")) Then
                        Dim tmpopchda As HDARedundancy = OPCHDAServersCollection(dt.Rows(i).Item("OPCHDA_ConfigName"))

                        OPCHDAServersCollection(dt.Rows(i).Item("OPCHDA_ConfigName")) = tmpopchda
                        ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                    Else
                        Dim tmpOPCHDA As New HDARedundancy(dt.Rows(i).Item("OPCHDA_PrimaryIP") + ":" + dt.Rows(i).Item("OPCHDA_PrimaryPort"), dt.Rows(i).Item("OPCHDA_SecondaryIP") + ":" + dt.Rows(i).Item("OPCHDA_SecondaryPort"), True, Me)
                        tmpOPCHDA.Connect()
                        OPCHDAServersCollection.Add(dt.Rows(i).Item("OPCHDA_ConfigName"), tmpOPCHDA)
                    End If
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddOPCDAChannel(ByVal dt As DataTable)
        Try
            PageTreeView.Nodes(0).Nodes(3).Nodes.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1

                OPCDAChannelsList.OPC_Channel_Name.Add(dt.Rows(i).Item("OPCDA_ChannelName"))
                OPCDAChannelsList.OPC_ServerName.Add(dt.Rows(i).Item("OPCDA_OPCServer"))
                OPCDAChannelsList.OPC_OPCItems.Add(dt.Rows(i).Item("OPCDA_Tag"))
                OPCDAChannelsList.OPC_RefreshTime.Add(dt.Rows(i).Item("OPCDA_RefreshTime"))
                OPCDAChannelsList.OPC_HistoryLength.Add(dt.Rows(i).Item("OPCDA_HisLength"))
                OPCDAChannelsList.OPC_LastnnHourHistory.Add(dt.Rows(i).Item("OPCDA_nnHoursHistory"))

                If dt.Rows(i).Item("OPCDA_IsMultiview") = "True" Then
                    OPCDAChannelsList.OPC_Multiview.Add(True)
                Else
                    OPCDAChannelsList.OPC_Multiview.Add(False)
                End If

                If OPCDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCDA_OPCServer")) Then
                    Dim tmpopcda As Redundancy = OPCDAServersCollection.Item(dt.Rows(i).Item("OPCDA_OPCServer"))

                    If tmpopcda.lstChannels.ContainsKey(dt.Rows(i).Item("OPCDA_ChannelName")) Then
                        tmpopcda.RemoveChannel(dt.Rows(i).Item("OPCDA_ChannelName"))
                    End If
                    tmpopcda.AddChannel(dt.Rows(i).Item("OPCDA_ChannelName"), dt.Rows(i).Item("OPCDA_Tag").split(","), dt.Rows(i).Item("OPCDA_HisLength"))
                End If


                PageTreeView.Nodes(0).Nodes(3).Nodes.Add(dt.Rows(i).Item("OPCDA_ChannelName"))
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).Name = dt.Rows(i).Item("OPCDA_ChannelName")
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).Tag = "True" 'For start And Stop Channel
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).SelectedImageIndex = 4
                PageTreeView.Nodes(0).Nodes(3).Nodes(i).ToolTipText = dt.Rows(i).Item("OPCDA_ChannelName")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddOPCHDAChannel(ByVal dt As DataTable)
        Try
            PageTreeView.Nodes(0).Nodes(4).Nodes.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1

                OPCHDAChannelsList.OPC_Channel_Name.Add(dt.Rows(i).Item("OPCHDA_ChannelName"))
                OPCHDAChannelsList.OPC_ServerName.Add(dt.Rows(i).Item("OPCHDA_OPCServer"))
                OPCHDAChannelsList.OPC_OPCItems.Add(dt.Rows(i).Item("OPCHDA_Tag"))
                OPCHDAChannelsList.OPC_Last.Add(dt.Rows(i).Item("OPCHDA_Last"))
                OPCHDAChannelsList.OPC_Interval.Add(dt.Rows(i).Item("OPCHDA_Interval"))
                OPCHDAChannelsList.OPC_RelativeTime.Add(dt.Rows(i).Item("OPCHDA_RelativeTime"))
                OPCHDAChannelsList.OPC_XAxis.Add(dt.Rows(i).Item("OPCHDA_XAxis"))

                If OPCHDAServersCollection.ContainsKey(dt.Rows(i).Item("OPCHDA_OPCServer")) Then
                    Dim tmpopchda As HDARedundancy = OPCHDAServersCollection.Item(dt.Rows(i).Item("OPCHDA_OPCServer"))

                    If tmpopchda.lstChannels.ContainsKey(dt.Rows(i).Item("OPCHDA_ChannelName")) Then
                        tmpopchda.RemoveChannel(dt.Rows(i).Item("OPCHDA_ChannelName"))
                    End If

                    Dim dattbl As New DataTable
                    dattbl.Columns.Add("Quality", GetType(System.String))
                    dattbl.Columns.Add("TimeStamp", GetType(System.DateTime))
                    dattbl.Columns.Add("Value", GetType(System.String))
                    dattbl.Columns.Add("TagName", GetType(System.String))

                    Dim HistinMins As Integer = 0
                    If dt.Rows(i).Item("OPCHDA_Last").split(" ")(1) = "Months" Then
                        HistinMins = CInt(dt.Rows(i).Item("OPCHDA_Last").split(" ")(0)) * 30 * 24 * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Last").split(" ")(1) = "Days" Then
                        HistinMins = CInt(dt.Rows(i).Item("OPCHDA_Last").split(" ")(0)) * 24 * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Last").split(" ")(1) = "Hours" Then
                        HistinMins = CInt(dt.Rows(i).Item("OPCHDA_Last").split(" ")(0)) * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Last").split(" ")(1) = "Minutes" Then
                        HistinMins = CInt(dt.Rows(i).Item("OPCHDA_Last").split(" ")(0))
                    End If

                    Dim IntervalinSecs As Integer = 0
                    If dt.Rows(i).Item("OPCHDA_Interval").split(" ")(1) = "Days" Then
                        IntervalinSecs = CInt(dt.Rows(i).Item("OPCHDA_Interval").split(" ")(0)) * 24 * 60 * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Interval").split(" ")(1) = "Hours" Then
                        IntervalinSecs = CInt(dt.Rows(i).Item("OPCHDA_Interval").split(" ")(0)) * 60 * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Interval").split(" ")(1) = "Minutes" Then
                        IntervalinSecs = CInt(dt.Rows(i).Item("OPCHDA_Interval").split(" ")(0)) * 60
                    ElseIf dt.Rows(i).Item("OPCHDA_Interval").split(" ")(1) = "Seconds" Then
                        IntervalinSecs = CInt(dt.Rows(i).Item("OPCHDA_Interval").split(" ")(0))
                    End If


                    tmpopchda.AddChannel(dt.Rows(i).Item("OPCHDA_ChannelName"), dt.Rows(i).Item("OPCHDA_Tag").split(","), HistinMins, IntervalinSecs, "A", DateTime.Parse(dt.Rows(i).Item("OPCHDA_RelativeTime")))
                End If


                PageTreeView.Nodes(0).Nodes(4).Nodes.Add(dt.Rows(i).Item("OPCHDA_ChannelName"))
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).Name = dt.Rows(i).Item("OPCHDA_ChannelName")
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).Tag = "True" 'For start And Stop Channel
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).SelectedImageIndex = 4
                PageTreeView.Nodes(0).Nodes(4).Nodes(i).ToolTipText = dt.Rows(i).Item("OPCHDA_ChannelName")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddSAMAHistorianChannel(ByVal dt As DataTable)
        Try
            PageTreeView.Nodes(0).Nodes(2).Nodes.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                SAMAHistorian_ChannelList.ChannelReportname.Add(dt.Rows(i).Item("SAMA_ReportName"))
                SAMAHistorian_ChannelList.ChannelReportDescription.Add(dt.Rows(i).Item("SAMA_Description"))
                SAMAHistorian_ChannelList.ChannelTags.Add(dt.Rows(i).Item("SAMA_Tags"))
                SAMAHistorian_ChannelList.ChannelDuration.Add(dt.Rows(i).Item("SAMA_Duration"))
                SAMAHistorian_ChannelList.ChannelInterval.Add(dt.Rows(i).Item("SAMA_Interval"))
                SAMAHistorian_ChannelList.ChannelXAxis.Add(dt.Rows(i).Item("SAMA_XAxis"))
                SAMAHistorian_ChannelList.ChannelOperations.Add(dt.Rows(i).Item("SAMA_Operation"))
            Next


            Dim _Datatbl As DataTable
            Dim _timer As Timer
            For i As Integer = 0 To SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                _timer = New Timer()
                _timer.Tag = SAMAHistorian_ChannelList.ChannelReportname(i) + "timer"
                Dim _interval() As String = SAMAHistorian_ChannelList.ChannelInterval(i).Split(" ")
                If _interval(1) = "Minutes" Then
                    _timer.Interval = _interval(0) * 60 * 1000
                ElseIf _interval(1) = "Hours" Then
                    _timer.Interval = _interval(0) * 60 * 60 * 1000
                ElseIf _interval(1) = "Days" Then
                    _timer.Interval = _interval(0) * 24 * 60 * 60 * 1000
                ElseIf _interval(1) = "Weeks" Then
                    _timer.Interval = _interval(0) * 7 * 24 * 60 * 60 * 1000
                ElseIf _interval(1) = "Months" Then
                    _timer.Interval = _interval(0) * 30 * 7 * 24 * 60 * 60 * 1000
                End If
                _timer.Enabled = True

                AddHandler _timer.Tick, (AddressOf SAMAHistorianChannels.tmr_GenerateReport)

                _Datatbl = New DataTable()

                SAMAHistorian_ChannelList.ChannelDatatable.Add(_Datatbl)
                SAMAHistorian_ChannelList.ChannelTimers.Add(_timer)

                PageTreeView.Nodes(0).Nodes(2).Nodes.Add(SAMAHistorian_ChannelList.ChannelReportname(i))
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).Name = SAMAHistorian_ChannelList.ChannelReportname(i)
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).Tag = "True" 'For start And Stop Channel
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).ToolTipText = SAMAHistorian_ChannelList.ChannelTags(i)
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(2).Nodes(i).SelectedImageIndex = 4
                PageTreeView.Nodes(0).Nodes(2).ExpandAll()
                'Me.Close()

                SAMAHistorianChannels.tmr_GenerateReport(_timer, Nothing)
            Next


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddSAMAHistorianChannel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub AddTask_List(ByVal Dt As DataTable)
        Try
            Task_ScheduleList.Clear()

            ReDim Task_scheduleClassList(Dt.Rows.Count - 1)

            For i As Integer = 0 To Dt.Rows.Count - 1
                Dim Split_Task = Dt.Rows(i).Item("Task_List").ToString.Split("#")
                Dim rfTime As Integer
                Dim ss = Split_Task(0).Split(" ")
                If CInt(ss(0)) = 10 Or CInt(ss(0)) = 30 Then
                    rfTime = CInt(ss(0)) * 60 * 1000
                Else
                    rfTime = CInt(ss(0)) * 60 * 60 * 1000
                End If

                Task_scheduleClassList(i) = New TaskScheduleClass(rfTime, Split_Task(2), Split_Task(1), Split_Task(3)) 'Create Instace Class to each Query

                Task_ScheduleList.Add(Dt.Rows(i).Item("Task_List"))



            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Add e-Mail setting,getting from (.sam) file
    ''' </summary>
    ''' <param name="Dt"></param>
    ''' <remarks></remarks>
    Private Sub AddEmailSetting(ByVal Dt As DataTable)

        EmailSetting = New List(Of String)

        EmailSetting.Add(Dt.Rows(0).Item(0))
        EmailSetting.Add(Dt.Rows(0).Item(1))
        EmailSetting.Add(Dt.Rows(0).Item(2))
        EmailSetting.Add(Dt.Rows(0).Item(3))
        EmailSetting.Add(Dt.Rows(0).Item(4))

    End Sub
    ''' <summary>
    ''' Create Log Viewer Control form (.sam) file  info
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddLogViewer(ByVal dt As DataTable)
        Try



            LogCtrl = New LogViewer
            LogCtrl.Name = "LogBook" & _iniLogBookName
            LogCtrl.Tag = "LogBook"
            LogCtrl.TabPages(0).Text = "Log Book" & _iniLogBookName
            AddHandler LogCtrl.MouseClick, (AddressOf Ctrl_Click)

            Dim x, y, width, height As Integer
            width = CInt(dt.Rows(0).Item("Width"))
            height = CInt(dt.Rows(0).Item("Height"))
            x = CInt(dt.Rows(0).Item("LocX"))
            y = CInt(dt.Rows(0).Item("LocY"))

            LogCtrl.Size = New Size(width, height)
            LogCtrl.Location = New Point(x, y)

            Page_Ctrl.Controls.Add(LogCtrl)
            LogCtrl.BringToFront()
            _iniLogBookName += 1

            'Function part
            If Not String.IsNullOrEmpty(dt.Rows(0).Item("Path")) AndAlso Not String.IsNullOrEmpty(dt.Rows(0).Item("Extension")) Then


                Select Case dt.Rows(0).Item("Extension")
                    Case ".txt"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadTextFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"))
                        Else
                            LogCtrl.LoadTextFile(dt.Rows(0).Item("Path"), True, 1)
                        End If
                    Case ".csv"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadCSVFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"), dt.Rows(0).Item("Delimiter"))
                        Else
                            LogCtrl.LoadCSVFile(dt.Rows(0).Item("Path"), True, 1, dt.Rows(0).Item("Delimiter"))
                        End If
                    Case ".xls"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadExcelFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"), ".xls")
                        Else
                            LogCtrl.LoadExcelFile(dt.Rows(0).Item("Path"), True, 1, ".xls")
                        End If
                    Case ".xlsx"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadExcelFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"), ".xlsx")
                        Else
                            LogCtrl.LoadExcelFile(dt.Rows(0).Item("Path"), True, 1, ".xlsx")
                        End If
                    Case ".html"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadHTMLFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"))
                        Else
                            LogCtrl.LoadHTMLFile(dt.Rows(0).Item("Path"), True, 1)
                        End If
                    Case ".xml"
                        If dt.Rows(0).Item("isLatest") = "False" Then
                            LogCtrl.LoadXMLFile(dt.Rows(0).Item("Path"), False, dt.Rows(0).Item("LastnnHour"))
                        Else
                            LogCtrl.LoadXMLFile(dt.Rows(0).Item("Path"), True, 1)
                        End If
                End Select


            End If



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddLogViewer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Add button control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddButton(ByVal dt As DataTable)
        Try

            Button_Ctrl = New Button_Control
            Button_Ctrl.Name = "Button" & _iniButtonName
            Button_Ctrl.Tag = "Button"
            Button_Ctrl.Text = dt.Rows(0).Item("lblText")
            Button_Ctrl.MinimumSize = Ctrl_MinSize

            Button_Ctrl.Font = New Font("Verdana", 9)
            AddHandler Button_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Button_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Button_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Button_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            AddHandler Button_Ctrl.Click, AddressOf ButtonCtrl_Click

            Button_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Button_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Button_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))
            Button_Ctrl.ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Button_Ctrl.BackColor = Color.FromArgb(CInt(dt.Rows(0).Item("BackColor")))
            Button_Ctrl.Action_Ctrl = dt.Rows(0).Item("Action_Ctrl")
            Button_Ctrl.Action_Type = dt.Rows(0).Item("Action_Type")
            If dt.Rows(0).Item("Style") = "Popup" Then
                Button_Ctrl.FlatStyle = FlatStyle.Popup
            ElseIf dt.Rows(0).Item("Style") = "Flat" Then
                Button_Ctrl.FlatStyle = FlatStyle.Flat
            Else
                Button_Ctrl.FlatStyle = FlatStyle.Standard
            End If

            Page_Ctrl.Controls.Add(Button_Ctrl)
            Button_Ctrl.BringToFront()
            _iniButtonName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddLogViewer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    ''' <summary>
    ''' Add OPCWriter control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddOPCWriter(ByVal dt As DataTable)
        Try

            OPCWrite_Ctrl = New OPCWriterControl
            OPCWrite_Ctrl.Name = "OPCWriter" & _iniOPCWriterName
            OPCWrite_Ctrl.Tag = "OPCWriter"
            OPCWrite_Ctrl.Text = dt.Rows(0).Item("lblText")
            OPCWrite_Ctrl.MinimumSize = Ctrl_MinSize

            Button_Ctrl.Font = New Font("Verdana", 9)
            AddHandler OPCWrite_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler OPCWrite_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler OPCWrite_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler OPCWrite_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            AddHandler OPCWrite_Ctrl.Click, AddressOf OPCWriterCtrl_Click

            OPCWrite_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            OPCWrite_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            OPCWrite_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))
            OPCWrite_Ctrl.ForeColor = Color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            OPCWrite_Ctrl.BackColor = Color.FromArgb(CInt(dt.Rows(0).Item("BackColor")))
            OPCWrite_Ctrl.OPCServerName = dt.Rows(0).Item("OPCServerName")
            OPCWrite_Ctrl.OPCTag = dt.Rows(0).Item("OPCTag")
            OPCWrite_Ctrl.OPCValue = dt.Rows(0).Item("OPCValue")
            If dt.Rows(0).Item("Style") = "Popup" Then
                OPCWrite_Ctrl.FlatStyle = FlatStyle.Popup
            ElseIf dt.Rows(0).Item("Style") = "Flat" Then
                OPCWrite_Ctrl.FlatStyle = FlatStyle.Flat
            Else
                OPCWrite_Ctrl.FlatStyle = FlatStyle.Standard
            End If

            OPCWrite_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")

            Page_Ctrl.Controls.Add(OPCWrite_Ctrl)
            OPCWrite_Ctrl.BringToFront()
            _iniOPCWriterName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddOPCWriter()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'Add Symbol Part
    '--------------------------------------------------

    ''' <summary>
    ''' Create Indicator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddIndicator(ByVal dt As DataTable)
        Try

            LevelIndicator_ctrl = New LevelIndicator
            LevelIndicator_ctrl.Name = "Indicator" & _iniindicatorName
            LevelIndicator_ctrl.Tag = "Indicator"

            LevelIndicator_ctrl.MinimumSize = Ctrl_MinSize


            AddHandler LevelIndicator_ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler LevelIndicator_ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler LevelIndicator_ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler LevelIndicator_ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler LevelIndicator_ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                LevelIndicator_ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                LevelIndicator_ctrl.AccessibleDescription = ""
            End If

            LevelIndicator_ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            LevelIndicator_ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            LevelIndicator_ctrl.Height = CInt(dt.Rows(0).Item("Height"))
            LevelIndicator_ctrl.ActiveColor = color.FromArgb(CInt(dt.Rows(0).Item("ActiveColor")))
            LevelIndicator_ctrl.InActiveColor = color.FromArgb(CInt(dt.Rows(0).Item("InActiveColor")))
            LevelIndicator_ctrl.RangeStart = CSng(dt.Rows(0).Item("RangeStart"))
            LevelIndicator_ctrl.RangeEnd = CSng(dt.Rows(0).Item("RangeEnd"))
            If dt.Rows(0).Item("Scale_Enabled") = "True" Then
                LevelIndicator_ctrl.Scale_Enabled = True
            Else
                LevelIndicator_ctrl.Scale_Enabled = False
            End If


            Page_Ctrl.Controls.Add(LevelIndicator_ctrl)
            LevelIndicator_ctrl.BringToFront()
            _iniindicatorName += 1




        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddIndicator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Line  control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddLineElbow(ByVal dt As DataTable)
        Try

            Line_Ctrl = New LineElbow
            Line_Ctrl.Name = "LineElbow" & _iniLineName
            Line_Ctrl.Tag = "LineElbow"




            AddHandler Line_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Line_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Line_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Line_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Line_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Line_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Line_Ctrl.AccessibleDescription = ""
            End If

            Line_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Line_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Line_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))
            Line_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Line_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Line_Ctrl.PenSize = CInt(dt.Rows(0).Item("LineSize"))


            Select Case dt.Rows(0).Item("LineCap")
                Case "StartCap"
                    Line_Ctrl.Caps = LineElbow.E_Caps.StartCap
                Case "EndCap"
                    Line_Ctrl.Caps = LineElbow.E_Caps.EndCap
                Case "Both"
                    Line_Ctrl.Caps = LineElbow.E_Caps.Both
                Case Else
                    Line_Ctrl.Caps = LineElbow.E_Caps.None
            End Select

            Select Case dt.Rows(0).Item("CapStyle")

                Case "Arrow"
                    Line_Ctrl.CapStyle = LineElbow.E_Capstyle.Arrow
                Case "Circle"
                    Line_Ctrl.CapStyle = LineElbow.E_Capstyle.Circle
                Case Else
                    Line_Ctrl.CapStyle = LineElbow.E_Capstyle.None
            End Select

            Select Case dt.Rows(0).Item("LineDirection")
                Case "Horizontal"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.Horizontal
                Case "Vertical"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.Vertical
                Case "LeftBottom"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.LeftBottom
                Case "LeftBottomTriangle"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.LeftBottomTriangle
                Case "RightBottom"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.RightBottom
                Case "RightBottomTriangle"
                    Line_Ctrl.DirectionType = LineElbow.DirectionTypes.RightBottomTriangle
            End Select






            Line_Ctrl._ThresholdValue.Clear()
            Line_Ctrl._THCondition.Clear()
            Line_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Line_Ctrl._ThresholdValue.Add(thv(i))
                    Line_Ctrl._THCondition.Add(th_C(i))
                    Line_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Line_Ctrl)
            Line_Ctrl.BringToFront()
            _iniLineName += 1




        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddLineElbow()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Distillation Tower control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddDistillationTower(ByVal dt As DataTable)
        Try

            DistillationTower_Ctrl = New Distillation_Tower
            DistillationTower_Ctrl.Name = "DistillationTower" & _symDistillationTowerName
            DistillationTower_Ctrl.Tag = "DistillationTower"




            AddHandler DistillationTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler DistillationTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler DistillationTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler DistillationTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler DistillationTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                DistillationTower_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                DistillationTower_Ctrl.AccessibleDescription = ""
            End If

            DistillationTower_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            DistillationTower_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            DistillationTower_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            DistillationTower_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            DistillationTower_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            DistillationTower_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            DistillationTower_Ctrl.Description = dt.Rows(0).Item("Description")

            DistillationTower_Ctrl._ThresholdValue.Clear()
            DistillationTower_Ctrl._THCondition.Clear()
            DistillationTower_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    DistillationTower_Ctrl._ThresholdValue.Add(thv(i))
                    DistillationTower_Ctrl._THCondition.Add((th_C(i)))
                    DistillationTower_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(DistillationTower_Ctrl)
            DistillationTower_Ctrl.BringToFront()
            _symDistillationTowerName += 1




        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddDistillationTower()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Jacked Vessel control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddJacketedVessel(ByVal dt As DataTable)
        Try

            JacketedVessel_Ctrl = New Jacketed_Vessel
            JacketedVessel_Ctrl.Name = "JacketedVessel" & _symJacketedVesselName
            JacketedVessel_Ctrl.Tag = "JacketedVessel"




            AddHandler JacketedVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler JacketedVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler JacketedVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler JacketedVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler JacketedVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                JacketedVessel_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                JacketedVessel_Ctrl.AccessibleDescription = ""
            End If

            JacketedVessel_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            JacketedVessel_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            JacketedVessel_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            JacketedVessel_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            JacketedVessel_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            JacketedVessel_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            JacketedVessel_Ctrl.Description = dt.Rows(0).Item("Description")

            JacketedVessel_Ctrl._ThresholdValue.Clear()
            JacketedVessel_Ctrl._THCondition.Clear()
            JacketedVessel_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    JacketedVessel_Ctrl._ThresholdValue.Add(thv(i))
                    JacketedVessel_Ctrl._THCondition.Add(th_C(i))
                    JacketedVessel_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(JacketedVessel_Ctrl)
            JacketedVessel_Ctrl.BringToFront()
            _symJacketedVesselName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddJacketedVessel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Reactor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddReactor(ByVal dt As DataTable)
        Try

            Reactor_Ctrl = New Reactor
            Reactor_Ctrl.Name = "Reactor" & _symReactorName
            Reactor_Ctrl.Tag = "Reactor"




            AddHandler Reactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Reactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Reactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Reactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Reactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Reactor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Reactor_Ctrl.AccessibleDescription = ""
            End If

            Reactor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Reactor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Reactor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Reactor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Reactor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Reactor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Reactor_Ctrl.Description = dt.Rows(0).Item("Description")


            Reactor_Ctrl._ThresholdValue.Clear()
            Reactor_Ctrl._THCondition.Clear()
            Reactor_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Reactor_Ctrl._ThresholdValue.Add(thv(i))
                    Reactor_Ctrl._THCondition.Add(th_C(i))
                    Reactor_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Reactor_Ctrl)
            Reactor_Ctrl.BringToFront()
            _symReactorName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddReactor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Vessel control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddVessel(ByVal dt As DataTable)
        Try

            Vessel_Ctrl = New Vessel
            Vessel_Ctrl.Name = "VesselElbow" & _symVesselName
            Vessel_Ctrl.Tag = "VesselElbow"




            AddHandler Vessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Vessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Vessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Vessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Vessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Vessel_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Vessel_Ctrl.AccessibleDescription = ""
            End If

            Vessel_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Vessel_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Vessel_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Vessel_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Vessel_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Vessel_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Vessel_Ctrl.Description = dt.Rows(0).Item("Description")


            Vessel_Ctrl._ThresholdValue.Clear()
            Vessel_Ctrl._THCondition.Clear()
            Vessel_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Vessel_Ctrl._ThresholdValue.Add(thv(i))
                    Vessel_Ctrl._THCondition.Add(th_C(i))
                    Vessel_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Vessel_Ctrl)
            Vessel_Ctrl.BringToFront()
            _symVesselName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddVessel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Atmospheric Tank control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddAtmosphericTank(ByVal dt As DataTable)
        Try

            AdmosphericTank_Ctrl = New Admospheric_Tank
            AdmosphericTank_Ctrl.Name = "AtmosphericTank" & _symATNKName
            AdmosphericTank_Ctrl.Tag = "AtmosphericTank"




            AddHandler AdmosphericTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler AdmosphericTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler AdmosphericTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler AdmosphericTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler AdmosphericTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                AdmosphericTank_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                AdmosphericTank_Ctrl.AccessibleDescription = ""
            End If

            AdmosphericTank_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            AdmosphericTank_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            AdmosphericTank_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            AdmosphericTank_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            AdmosphericTank_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            AdmosphericTank_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            AdmosphericTank_Ctrl.Description = dt.Rows(0).Item("Description")

            AdmosphericTank_Ctrl._ThresholdValue.Clear()
            AdmosphericTank_Ctrl._THCondition.Clear()
            AdmosphericTank_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    AdmosphericTank_Ctrl._ThresholdValue.Add(thv(i))
                    AdmosphericTank_Ctrl._THCondition.Add(th_C(i))
                    AdmosphericTank_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(AdmosphericTank_Ctrl)
            AdmosphericTank_Ctrl.BringToFront()
            _symATNKName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddAtmosphericTank()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Bin control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddBin(ByVal dt As DataTable)
        Try

            Bin_Ctrl = New Bin
            Bin_Ctrl.Name = "Bin" & _symBinName
            Bin_Ctrl.Tag = "Bin"




            AddHandler Bin_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Bin_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Bin_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Bin_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Bin_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Bin_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Bin_Ctrl.AccessibleDescription = ""
            End If

            Bin_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Bin_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Bin_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Bin_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Bin_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Bin_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Bin_Ctrl.Description = dt.Rows(0).Item("Description")
            Bin_Ctrl._ThresholdValue.Clear()
            Bin_Ctrl._THCondition.Clear()
            Bin_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Bin_Ctrl._ThresholdValue.Add(thv(i))
                    Bin_Ctrl._THCondition.Add(th_C(i))
                    Bin_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Bin_Ctrl)
            Bin_Ctrl.BringToFront()
            _symBinName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddBin()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Floating Roof Tank control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddFloatingRoofTank(ByVal dt As DataTable)
        Try

            FloatingRoofTank_Ctrl = New FloatingRoof_Tank
            FloatingRoofTank_Ctrl.Name = "FloatingRoofTank" & _symFloatingRoofTankName
            FloatingRoofTank_Ctrl.Tag = "FloatingRoofTank"




            AddHandler FloatingRoofTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler FloatingRoofTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler FloatingRoofTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler FloatingRoofTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler FloatingRoofTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                FloatingRoofTank_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                FloatingRoofTank_Ctrl.AccessibleDescription = ""
            End If

            FloatingRoofTank_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            FloatingRoofTank_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            FloatingRoofTank_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            FloatingRoofTank_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            FloatingRoofTank_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            FloatingRoofTank_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            FloatingRoofTank_Ctrl.Description = dt.Rows(0).Item("Description")
            FloatingRoofTank_Ctrl._ThresholdValue.Clear()
            FloatingRoofTank_Ctrl._THCondition.Clear()
            FloatingRoofTank_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    FloatingRoofTank_Ctrl._ThresholdValue.Add(thv(i))
                    FloatingRoofTank_Ctrl._THCondition.Add(th_C(i))
                    FloatingRoofTank_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(FloatingRoofTank_Ctrl)
            FloatingRoofTank_Ctrl.BringToFront()
            _symFloatingRoofTankName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddFloatingRoofTank()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Gas Holder control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddGasHolder(ByVal dt As DataTable)
        Try

            GasHolder_Ctrl = New GAS_Holder
            GasHolder_Ctrl.Name = "GasHolder" & _symGasHolderName
            GasHolder_Ctrl.Tag = "GasHolder"




            AddHandler GasHolder_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler GasHolder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler GasHolder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler GasHolder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler GasHolder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                GasHolder_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                GasHolder_Ctrl.AccessibleDescription = ""
            End If

            GasHolder_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            GasHolder_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            GasHolder_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            GasHolder_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            GasHolder_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            GasHolder_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            GasHolder_Ctrl.Description = dt.Rows(0).Item("Description")
            GasHolder_Ctrl._ThresholdValue.Clear()
            GasHolder_Ctrl._THCondition.Clear()
            GasHolder_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    GasHolder_Ctrl._ThresholdValue.Add(thv(i))
                    GasHolder_Ctrl._THCondition.Add(th_C(i))
                    GasHolder_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(GasHolder_Ctrl)
            GasHolder_Ctrl.BringToFront()
            _symGasHolderName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddGasHolder()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Pressure Storage Vessel control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddPressureStorageVessel(ByVal dt As DataTable)
        Try

            PressureStorageVessel_Ctrl = New PressureStorage_Vessel
            PressureStorageVessel_Ctrl.Name = "PressureStorageVessel" & _symPressureStorageVesselName
            PressureStorageVessel_Ctrl.Tag = "PressureStorageVessel"




            AddHandler PressureStorageVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler PressureStorageVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler PressureStorageVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler PressureStorageVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler PressureStorageVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                PressureStorageVessel_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                PressureStorageVessel_Ctrl.AccessibleDescription = ""
            End If

            PressureStorageVessel_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            PressureStorageVessel_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            PressureStorageVessel_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            PressureStorageVessel_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            PressureStorageVessel_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            PressureStorageVessel_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            PressureStorageVessel_Ctrl.Description = dt.Rows(0).Item("Description")
            PressureStorageVessel_Ctrl._ThresholdValue.Clear()
            PressureStorageVessel_Ctrl._THCondition.Clear()
            PressureStorageVessel_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    PressureStorageVessel_Ctrl._ThresholdValue.Add(thv(i))
                    PressureStorageVessel_Ctrl._THCondition.Add(th_C(i))
                    PressureStorageVessel_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(PressureStorageVessel_Ctrl)
            PressureStorageVessel_Ctrl.BringToFront()
            _symPressureStorageVesselName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddPressureStorageVessel()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create WeightHopper control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddWeighHopper(ByVal dt As DataTable)
        Try

            WeighHopper_Ctrl = New Weigh_Hopper
            WeighHopper_Ctrl.Name = "WeighHopper" & _symWeighHopperName
            WeighHopper_Ctrl.Tag = "WeighHopper"




            AddHandler WeighHopper_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler WeighHopper_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler WeighHopper_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler WeighHopper_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler WeighHopper_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                WeighHopper_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                WeighHopper_Ctrl.AccessibleDescription = ""
            End If

            WeighHopper_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            WeighHopper_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            WeighHopper_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            WeighHopper_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            WeighHopper_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            WeighHopper_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            WeighHopper_Ctrl.Description = dt.Rows(0).Item("Description")
            WeighHopper_Ctrl._ThresholdValue.Clear()
            WeighHopper_Ctrl._THCondition.Clear()
            WeighHopper_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    WeighHopper_Ctrl._ThresholdValue.Add(thv(i))
                    WeighHopper_Ctrl._THCondition.Add(th_C(i))
                    WeighHopper_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(WeighHopper_Ctrl)
            WeighHopper_Ctrl.BringToFront()
            _symWeighHopperName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddWeighHopper()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Circuit Breaker control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddCircuitBreaker(ByVal dt As DataTable)
        Try

            CircuitBreaker_Ctrl = New Circuit_Breaker
            CircuitBreaker_Ctrl.Name = "CircuitBreaker" & _symCircuitBreakerKName
            CircuitBreaker_Ctrl.Tag = "CircuitBreaker"




            AddHandler CircuitBreaker_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CircuitBreaker_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CircuitBreaker_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CircuitBreaker_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CircuitBreaker_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                CircuitBreaker_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                CircuitBreaker_Ctrl.AccessibleDescription = ""
            End If

            CircuitBreaker_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            CircuitBreaker_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            CircuitBreaker_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            CircuitBreaker_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            CircuitBreaker_Ctrl.LineColor = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            CircuitBreaker_Ctrl._ThresholdValue.Clear()
            CircuitBreaker_Ctrl._THCondition.Clear()
            CircuitBreaker_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC, th_S As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                th_S = New ArrayList(dt.Rows(0).Item("THState").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    CircuitBreaker_Ctrl._ThresholdValue.Add(thv(i))
                    CircuitBreaker_Ctrl._THCondition.Add((th_C(i)))
                    CircuitBreaker_Ctrl._THColor.Add(CInt(thbC(i)))
                    CircuitBreaker_Ctrl._THState.Add((th_S(i)))
                Next
            End If

            Page_Ctrl.Controls.Add(CircuitBreaker_Ctrl)
            CircuitBreaker_Ctrl.BringToFront()
            _symCircuitBreakerKName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddCircuitBreaker()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Manual Contactor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddManualContactor(ByVal dt As DataTable)
        Try

            ManualContactor_Ctrl = New ManualContactor
            ManualContactor_Ctrl.Name = "ManualContactor" & _symManualContactorName
            ManualContactor_Ctrl.Tag = "ManualContactor"




            AddHandler ManualContactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ManualContactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ManualContactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ManualContactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ManualContactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                ManualContactor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                ManualContactor_Ctrl.AccessibleDescription = ""
            End If

            ManualContactor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            ManualContactor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            ManualContactor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            ManualContactor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            ManualContactor_Ctrl.LineColor = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            ManualContactor_Ctrl._ThresholdValue.Clear()
            ManualContactor_Ctrl._THCondition.Clear()
            ManualContactor_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC, th_S As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                th_S = New ArrayList(dt.Rows(0).Item("THState").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    ManualContactor_Ctrl._ThresholdValue.Add(thv(i))
                    ManualContactor_Ctrl._THCondition.Add((th_C(i)))
                    ManualContactor_Ctrl._THColor.Add(CInt(thbC(i)))
                    ManualContactor_Ctrl._THState.Add((th_S(i)))
                Next
            End If

            Page_Ctrl.Controls.Add(ManualContactor_Ctrl)
            ManualContactor_Ctrl.BringToFront()
            _symManualContactorName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddManualContactor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Delta Connection control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddDeltaConnection(ByVal dt As DataTable)
        Try

            DeltaConnection_Ctrl = New Delta_Connection
            DeltaConnection_Ctrl.Name = "DeltaConnection" & _symDeltaConnectionName
            DeltaConnection_Ctrl.Tag = "DeltaConnection"




            AddHandler DeltaConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler DeltaConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler DeltaConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler DeltaConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler DeltaConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                DeltaConnection_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                DeltaConnection_Ctrl.AccessibleDescription = ""
            End If

            DeltaConnection_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            DeltaConnection_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            DeltaConnection_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            DeltaConnection_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            DeltaConnection_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            DeltaConnection_Ctrl.Description = dt.Rows(0).Item("Description")

            DeltaConnection_Ctrl._ThresholdValue.Clear()
            DeltaConnection_Ctrl._THCondition.Clear()
            DeltaConnection_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    DeltaConnection_Ctrl._ThresholdValue.Add(thv(i))
                    DeltaConnection_Ctrl._THCondition.Add(th_C(i))
                    DeltaConnection_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(DeltaConnection_Ctrl)
            DeltaConnection_Ctrl.BringToFront()
            _symDeltaConnectionName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddDeltaConnection()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Fuse control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddFuse(ByVal dt As DataTable)
        Try

            Fuse_Ctrl = New Fuse
            Fuse_Ctrl.Name = "Fuse" & _symFuseName
            Fuse_Ctrl.Tag = "Fuse"




            AddHandler Fuse_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Fuse_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Fuse_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Fuse_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Fuse_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Fuse_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Fuse_Ctrl.AccessibleDescription = ""
            End If

            Fuse_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Fuse_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Fuse_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Fuse_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Fuse_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Fuse_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Fuse_Ctrl.Description = dt.Rows(0).Item("Description")


            Fuse_Ctrl._ThresholdValue.Clear()
            Fuse_Ctrl._THCondition.Clear()
            Fuse_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Fuse_Ctrl._ThresholdValue.Add(thv(i))
                    Fuse_Ctrl._THCondition.Add(th_C(i))
                    Fuse_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Fuse_Ctrl)
            Fuse_Ctrl.BringToFront()
            _symFuseName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddFuse()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Motor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddMotor(ByVal dt As DataTable)
        Try

            Motor_Ctrl = New Motor
            Motor_Ctrl.Name = "Motor" & _symMotorName
            Motor_Ctrl.Tag = "Motor"




            AddHandler Motor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Motor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Motor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Motor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Motor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Motor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Motor_Ctrl.AccessibleDescription = ""
            End If

            Motor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Motor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Motor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Motor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Motor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Motor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Motor_Ctrl.Description = dt.Rows(0).Item("Description")

            Motor_Ctrl._ThresholdValue.Clear()
            Motor_Ctrl._THCondition.Clear()
            Motor_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Motor_Ctrl._ThresholdValue.Add(thv(i))
                    Motor_Ctrl._THCondition.Add(th_C(i))
                    Motor_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Motor_Ctrl)
            Motor_Ctrl.BringToFront()
            _symMotorName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddMotor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create State Indicator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddStateIndicator(ByVal dt As DataTable)
        Try

            StateIndicator_Ctrl = New StateIndicator
            StateIndicator_Ctrl.Name = "StateIndicator" & _symStateIndicatorName
            StateIndicator_Ctrl.Tag = "StateIndicator"




            AddHandler StateIndicator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler StateIndicator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler StateIndicator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler StateIndicator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler StateIndicator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                StateIndicator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                StateIndicator_Ctrl.AccessibleDescription = ""
            End If

            StateIndicator_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            StateIndicator_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            StateIndicator_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            StateIndicator_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            StateIndicator_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            StateIndicator_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            StateIndicator_Ctrl.Description = dt.Rows(0).Item("Description")

            StateIndicator_Ctrl._ThresholdValue.Clear()
            StateIndicator_Ctrl._THCondition.Clear()
            StateIndicator_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    StateIndicator_Ctrl._ThresholdValue.Add(thv(i))
                    StateIndicator_Ctrl._THCondition.Add(th_C(i))
                    StateIndicator_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(StateIndicator_Ctrl)
            StateIndicator_Ctrl.BringToFront()
            _symStateIndicatorName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddStateIndicator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Transformer control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddTransformer(ByVal dt As DataTable)
        Try

            Transformer_Ctrl = New Transformer
            Transformer_Ctrl.Name = "Transformer" & _symTransformerName
            Transformer_Ctrl.Tag = "Transformer"




            AddHandler Transformer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Transformer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Transformer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Transformer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Transformer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Transformer_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Transformer_Ctrl.AccessibleDescription = ""
            End If

            Transformer_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Transformer_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Transformer_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Transformer_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Transformer_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Transformer_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Transformer_Ctrl.Description = dt.Rows(0).Item("Description")

            Transformer_Ctrl._ThresholdValue.Clear()
            Transformer_Ctrl._THCondition.Clear()
            Transformer_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Transformer_Ctrl._ThresholdValue.Add(thv(i))
                    Transformer_Ctrl._THCondition.Add(th_C(i))
                    Transformer_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Transformer_Ctrl)
            Transformer_Ctrl.BringToFront()
            _symTransformerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddTransformer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create WYE Connection control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddWyeConnection(ByVal dt As DataTable)
        Try

            WyeConnection_Ctrl = New WYE_Connection
            WyeConnection_Ctrl.Name = "WyeConnection" & _symWyeConnectionName
            WyeConnection_Ctrl.Tag = "WyeConnection"




            AddHandler WyeConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler WyeConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler WyeConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler WyeConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler WyeConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                WyeConnection_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                WyeConnection_Ctrl.AccessibleDescription = ""
            End If

            WyeConnection_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            WyeConnection_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            WyeConnection_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            WyeConnection_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            WyeConnection_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            WyeConnection_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            WyeConnection_Ctrl.Description = dt.Rows(0).Item("Description")


            WyeConnection_Ctrl._ThresholdValue.Clear()
            WyeConnection_Ctrl._THCondition.Clear()
            WyeConnection_Ctrl._THColor.Clear()
            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    WyeConnection_Ctrl._ThresholdValue.Add(thv(i))
                    WyeConnection_Ctrl._THCondition.Add(th_C(i))
                    WyeConnection_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(WyeConnection_Ctrl)
            WyeConnection_Ctrl.BringToFront()
            _symWyeConnectionName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddWyeConnection()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Liquid Filter control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddLiquidFilter(ByVal dt As DataTable)
        Try

            LiquidFilter_Ctrl = New Liquid_Filter
            LiquidFilter_Ctrl.Name = "LiquidFilter" & _symLiquidFilterName
            LiquidFilter_Ctrl.Tag = "LiquidFilter"




            AddHandler LiquidFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler LiquidFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler LiquidFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler LiquidFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler LiquidFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                LiquidFilter_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                LiquidFilter_Ctrl.AccessibleDescription = ""
            End If

            LiquidFilter_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            LiquidFilter_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            LiquidFilter_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            LiquidFilter_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            LiquidFilter_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            LiquidFilter_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            LiquidFilter_Ctrl.Description = dt.Rows(0).Item("Description")

            LiquidFilter_Ctrl._ThresholdValue.Clear()
            LiquidFilter_Ctrl._THCondition.Clear()
            LiquidFilter_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    LiquidFilter_Ctrl._ThresholdValue.Add(thv(i))
                    LiquidFilter_Ctrl._THCondition.Add(th_C(i))
                    LiquidFilter_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(LiquidFilter_Ctrl)
            LiquidFilter_Ctrl.BringToFront()
            _symLiquidFilterName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddLiquidFilter()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Vacuum Filter control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddVacuumFilter(ByVal dt As DataTable)
        Try

            VacuumFilter_Ctrl = New Vacuum_Filter
            VacuumFilter_Ctrl.Name = "VacuumFilter" & _symVacuumFilterName
            VacuumFilter_Ctrl.Tag = "VacuumFilter"




            AddHandler VacuumFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler VacuumFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler VacuumFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler VacuumFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler VacuumFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                VacuumFilter_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                VacuumFilter_Ctrl.AccessibleDescription = ""
            End If

            VacuumFilter_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            VacuumFilter_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            VacuumFilter_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            VacuumFilter_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            VacuumFilter_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            VacuumFilter_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            VacuumFilter_Ctrl.Description = dt.Rows(0).Item("Description")

            VacuumFilter_Ctrl._ThresholdValue.Clear()
            VacuumFilter_Ctrl._THCondition.Clear()
            VacuumFilter_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    VacuumFilter_Ctrl._ThresholdValue.Add(thv(i))
                    VacuumFilter_Ctrl._THCondition.Add(th_C(i))
                    VacuumFilter_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(VacuumFilter_Ctrl)
            VacuumFilter_Ctrl.BringToFront()
            _symVacuumFilterName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddVacuumFilter()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Exchanger control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddExchanger(ByVal dt As DataTable)
        Try

            Exchanger_Ctrl = New Exchanger
            Exchanger_Ctrl.Name = "Exchanger" & _symExchangerName
            Exchanger_Ctrl.Tag = "Exchanger"




            AddHandler Exchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Exchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Exchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Exchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Exchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Exchanger_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Exchanger_Ctrl.AccessibleDescription = ""
            End If

            Exchanger_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Exchanger_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Exchanger_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Exchanger_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Exchanger_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Exchanger_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Exchanger_Ctrl.Description = dt.Rows(0).Item("Description")

            Exchanger_Ctrl._ThresholdValue.Clear()
            Exchanger_Ctrl._THCondition.Clear()
            Exchanger_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Exchanger_Ctrl._ThresholdValue.Add(thv(i))
                    Exchanger_Ctrl._THCondition.Add(th_C(i))
                    Exchanger_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Exchanger_Ctrl)
            Exchanger_Ctrl.BringToFront()
            _symExchangerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddExchanger()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Forced Air Exchanger control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddForcedAirExchanger(ByVal dt As DataTable)
        Try

            ForcedAirExchanger_Ctrl = New Forced_Air_Exchanged
            ForcedAirExchanger_Ctrl.Name = "ForcedAirExchanger" & _symForcedAirExchangerName
            ForcedAirExchanger_Ctrl.Tag = "ForcedAirExchanger"




            AddHandler ForcedAirExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ForcedAirExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ForcedAirExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ForcedAirExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ForcedAirExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                ForcedAirExchanger_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                ForcedAirExchanger_Ctrl.AccessibleDescription = ""
            End If

            ForcedAirExchanger_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            ForcedAirExchanger_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            ForcedAirExchanger_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            ForcedAirExchanger_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            ForcedAirExchanger_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            ForcedAirExchanger_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            ForcedAirExchanger_Ctrl.Description = dt.Rows(0).Item("Description")

            ForcedAirExchanger_Ctrl._ThresholdValue.Clear()
            ForcedAirExchanger_Ctrl._THCondition.Clear()
            ForcedAirExchanger_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    ForcedAirExchanger_Ctrl._ThresholdValue.Add(thv(i))
                    ForcedAirExchanger_Ctrl._THCondition.Add(th_C(i))
                    ForcedAirExchanger_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(ForcedAirExchanger_Ctrl)
            ForcedAirExchanger_Ctrl.BringToFront()
            _symForcedAirExchangerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddForcedAirExchanger()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Furnace control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddFurnace(ByVal dt As DataTable)
        Try

            Furnace_Ctrl = New Furnace
            Furnace_Ctrl.Name = "Furnace" & _symFurnaceName
            Furnace_Ctrl.Tag = "Furnace"




            AddHandler Furnace_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Furnace_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Furnace_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Furnace_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Furnace_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Furnace_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Furnace_Ctrl.AccessibleDescription = ""
            End If

            Furnace_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Furnace_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Furnace_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Furnace_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Furnace_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Furnace_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Furnace_Ctrl.Description = dt.Rows(0).Item("Description")

            Furnace_Ctrl._ThresholdValue.Clear()
            Furnace_Ctrl._THCondition.Clear()
            Furnace_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Furnace_Ctrl._ThresholdValue.Add(thv(i))
                    Furnace_Ctrl._THCondition.Add(th_C(i))
                    Furnace_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Furnace_Ctrl)
            Furnace_Ctrl.BringToFront()
            _symFurnaceName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddFurnace()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Rotary Kiln control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddRotaryKiln(ByVal dt As DataTable)
        Try

            RotaryKiln_Ctrl = New Rotary_Kiln
            RotaryKiln_Ctrl.Name = "RotaryKiln" & _symRotaryKilnName
            RotaryKiln_Ctrl.Tag = "RotaryKiln"




            AddHandler RotaryKiln_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotaryKiln_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotaryKiln_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotaryKiln_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotaryKiln_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                RotaryKiln_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                RotaryKiln_Ctrl.AccessibleDescription = ""
            End If

            RotaryKiln_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            RotaryKiln_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            RotaryKiln_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            RotaryKiln_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            RotaryKiln_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            RotaryKiln_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            RotaryKiln_Ctrl.Description = dt.Rows(0).Item("Description")

            RotaryKiln_Ctrl._ThresholdValue.Clear()
            RotaryKiln_Ctrl._THCondition.Clear()
            RotaryKiln_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    RotaryKiln_Ctrl._ThresholdValue.Add(thv(i))
                    RotaryKiln_Ctrl._THCondition.Add(th_C(i))
                    RotaryKiln_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(RotaryKiln_Ctrl)
            RotaryKiln_Ctrl.BringToFront()
            _symRotaryKilnName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddRotaryKiln()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Cooling Tower control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddCoolingTower(ByVal dt As DataTable)
        Try

            CoolingTower_Ctrl = New Cooling_Tower
            CoolingTower_Ctrl.Name = "CoolingTower" & _symCoolingTowerName
            CoolingTower_Ctrl.Tag = "CoolingTower"




            AddHandler CoolingTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CoolingTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CoolingTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CoolingTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CoolingTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                CoolingTower_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                CoolingTower_Ctrl.AccessibleDescription = ""
            End If

            CoolingTower_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            CoolingTower_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            CoolingTower_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            CoolingTower_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            CoolingTower_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            CoolingTower_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            CoolingTower_Ctrl.Description = dt.Rows(0).Item("Description")

            CoolingTower_Ctrl._ThresholdValue.Clear()
            CoolingTower_Ctrl._THCondition.Clear()
            CoolingTower_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    CoolingTower_Ctrl._ThresholdValue.Add(thv(i))
                    CoolingTower_Ctrl._THCondition.Add(th_C(i))
                    CoolingTower_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(CoolingTower_Ctrl)
            CoolingTower_Ctrl.BringToFront()
            _symCoolingTowerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddCoolingTower()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Evaporator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddEvaporator(ByVal dt As DataTable)
        Try

            Evaporator_Ctrl = New Evaporator
            Evaporator_Ctrl.Name = "Evaporator" & _symEvaporatorName
            Evaporator_Ctrl.Tag = "Evaporator"




            AddHandler Evaporator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Evaporator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Evaporator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Evaporator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Evaporator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Evaporator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Evaporator_Ctrl.AccessibleDescription = ""
            End If

            Evaporator_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Evaporator_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Evaporator_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Evaporator_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Evaporator_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Evaporator_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Evaporator_Ctrl.Description = dt.Rows(0).Item("Description")

            Evaporator_Ctrl._ThresholdValue.Clear()
            Evaporator_Ctrl._THCondition.Clear()
            Evaporator_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    Evaporator_Ctrl._ThresholdValue.Add(thv(i))
                    Evaporator_Ctrl._THCondition.Add(th_C(i))
                    Evaporator_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Evaporator_Ctrl)
            Evaporator_Ctrl.BringToFront()
            _symEvaporatorName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddEvaporator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Finned Exchanger control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddFinnedExchanger(ByVal dt As DataTable)
        Try

            FinnedExchanger_Ctrl = New Finned_Exchanger
            FinnedExchanger_Ctrl.Name = "FinnedExchanger" & _symFinnedExchangerName
            FinnedExchanger_Ctrl.Tag = "FinnedExchanger"




            AddHandler FinnedExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler FinnedExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler FinnedExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler FinnedExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler FinnedExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                FinnedExchanger_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                FinnedExchanger_Ctrl.AccessibleDescription = ""
            End If

            FinnedExchanger_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            FinnedExchanger_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            FinnedExchanger_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            FinnedExchanger_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            FinnedExchanger_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            FinnedExchanger_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            FinnedExchanger_Ctrl.Description = dt.Rows(0).Item("Description")

            FinnedExchanger_Ctrl._ThresholdValue.Clear()
            FinnedExchanger_Ctrl._THCondition.Clear()
            FinnedExchanger_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    FinnedExchanger_Ctrl._ThresholdValue.Add(thv(i))
                    FinnedExchanger_Ctrl._THCondition.Add(th_C(i))
                    FinnedExchanger_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(FinnedExchanger_Ctrl)
            FinnedExchanger_Ctrl.BringToFront()
            _symFinnedExchangerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddFinnedExchanger()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Conveyor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddConveyor(ByVal dt As DataTable)
        Try

            Conveyor_Ctrl = New Conveyor
            Conveyor_Ctrl.Name = "Conveyor" & _symConveyorName
            Conveyor_Ctrl.Tag = "Conveyor"




            AddHandler Conveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Conveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Conveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Conveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Conveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Conveyor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Conveyor_Ctrl.AccessibleDescription = ""
            End If

            Conveyor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Conveyor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Conveyor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Conveyor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Conveyor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Conveyor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Conveyor_Ctrl.Description = dt.Rows(0).Item("Description")

            Conveyor_Ctrl._ThresholdValue.Clear()
            Conveyor_Ctrl._THCondition.Clear()
            Conveyor_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    Conveyor_Ctrl._ThresholdValue.Add(thv(i))
                    Conveyor_Ctrl._THCondition.Add(th_C(i))
                    Conveyor_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Conveyor_Ctrl)
            Conveyor_Ctrl.BringToFront()
            _symConveyorName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddConveyor)")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Mill control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddMill(ByVal dt As DataTable)
        Try

            Mill_Ctrl = New Mill
            Mill_Ctrl.Name = "Mill" & _symMillName
            Mill_Ctrl.Tag = "Mill"




            AddHandler Mill_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Mill_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Mill_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Mill_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Mill_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Mill_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Mill_Ctrl.AccessibleDescription = ""
            End If

            Mill_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Mill_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Mill_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Mill_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Mill_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Mill_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Mill_Ctrl.Description = dt.Rows(0).Item("Description")

            Mill_Ctrl._ThresholdValue.Clear()
            Mill_Ctrl._THCondition.Clear()
            Mill_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    Mill_Ctrl._ThresholdValue.Add(thv(i))
                    Mill_Ctrl._THCondition.Add(th_C(i))
                    Mill_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If

            Page_Ctrl.Controls.Add(Mill_Ctrl)
            Mill_Ctrl.BringToFront()
            _symMillName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddMill()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Roll Stand control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddRollStand(ByVal dt As DataTable)
        Try

            RollStand_Ctrl = New Roll_Stand
            RollStand_Ctrl.Name = "RollStand" & _symRollStandName
            RollStand_Ctrl.Tag = "RollStand"




            AddHandler RollStand_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RollStand_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RollStand_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RollStand_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RollStand_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                RollStand_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                RollStand_Ctrl.AccessibleDescription = ""
            End If

            RollStand_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            RollStand_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            RollStand_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            RollStand_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            RollStand_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            RollStand_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            RollStand_Ctrl.Description = dt.Rows(0).Item("Description")

            RollStand_Ctrl._ThresholdValue.Clear()
            RollStand_Ctrl._THCondition.Clear()
            RollStand_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    RollStand_Ctrl._ThresholdValue.Add(thv(i))
                    RollStand_Ctrl._THCondition.Add(th_C(i))
                    RollStand_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If
            Page_Ctrl.Controls.Add(RollStand_Ctrl)
            RollStand_Ctrl.BringToFront()
            _symRollStandName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddRollStand()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Rotary Feeder control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddRotaryFeeder(ByVal dt As DataTable)
        Try

            RotaryFeeder_Ctrl = New Rotary_Feeder
            RotaryFeeder_Ctrl.Name = "RotaryFeeder" & _symRotaryFeederName
            RotaryFeeder_Ctrl.Tag = "RotaryFeeder"




            AddHandler RotaryFeeder_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotaryFeeder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotaryFeeder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotaryFeeder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotaryFeeder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                RotaryFeeder_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                RotaryFeeder_Ctrl.AccessibleDescription = ""
            End If

            RotaryFeeder_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            RotaryFeeder_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            RotaryFeeder_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            RotaryFeeder_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            RotaryFeeder_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            RotaryFeeder_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            RotaryFeeder_Ctrl.Description = dt.Rows(0).Item("Description")

            RotaryFeeder_Ctrl._ThresholdValue.Clear()
            RotaryFeeder_Ctrl._THCondition.Clear()
            RotaryFeeder_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    RotaryFeeder_Ctrl._ThresholdValue.Add(thv(i))
                    RotaryFeeder_Ctrl._THCondition.Add(th_C(i))
                    RotaryFeeder_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If

            Page_Ctrl.Controls.Add(RotaryFeeder_Ctrl)
            RotaryFeeder_Ctrl.BringToFront()
            _symRotaryFeederName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddRotaryFeeder()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Roll Screw Conveyor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddScrewConveyor(ByVal dt As DataTable)
        Try

            ScrewConveyor_Ctrl = New Screw_Conveyor
            ScrewConveyor_Ctrl.Name = "ScrewConveyor" & _symScrewConveyorName
            ScrewConveyor_Ctrl.Tag = "ScrewConveyor"




            AddHandler ScrewConveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ScrewConveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ScrewConveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ScrewConveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ScrewConveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                ScrewConveyor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                ScrewConveyor_Ctrl.AccessibleDescription = ""
            End If

            ScrewConveyor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            ScrewConveyor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            ScrewConveyor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            ScrewConveyor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            ScrewConveyor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            ScrewConveyor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            ScrewConveyor_Ctrl.Description = dt.Rows(0).Item("Description")

            ScrewConveyor_Ctrl._ThresholdValue.Clear()
            ScrewConveyor_Ctrl._THCondition.Clear()
            ScrewConveyor_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))
                For i As Integer = 0 To thv.Count - 2
                    ScrewConveyor_Ctrl._ThresholdValue.Add(thv(i))
                    ScrewConveyor_Ctrl._THCondition.Add(th_C(i))
                    ScrewConveyor_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If

            Page_Ctrl.Controls.Add(ScrewConveyor_Ctrl)
            ScrewConveyor_Ctrl.BringToFront()
            _symScrewConveyorName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddScrewConveyor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Agitator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddAgitator(ByVal dt As DataTable)
        Try

            Agitator_Ctrl = New Agitator
            Agitator_Ctrl.Name = "Agitator" & _symAgitatorName
            Agitator_Ctrl.Tag = "Agitator"




            AddHandler Agitator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Agitator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Agitator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Agitator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Agitator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Agitator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Agitator_Ctrl.AccessibleDescription = ""
            End If

            Agitator_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Agitator_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Agitator_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Agitator_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Agitator_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Agitator_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Agitator_Ctrl.Description = dt.Rows(0).Item("Description")

            Agitator_Ctrl._ThresholdValue.Clear()
            Agitator_Ctrl._THCondition.Clear()
            Agitator_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Agitator_Ctrl._ThresholdValue.Add(thv(i))
                    Agitator_Ctrl._THCondition.Add(th_C(i))
                    Agitator_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If
            Page_Ctrl.Controls.Add(Agitator_Ctrl)
            Agitator_Ctrl.BringToFront()
            _symAgitatorName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddAgitator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Inline Mixer control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddInlineMixer(ByVal dt As DataTable)
        Try

            InlineMixer_Ctrl = New Inline_Mixer
            InlineMixer_Ctrl.Name = "InlineMixer" & _symInlineMixerName
            InlineMixer_Ctrl.Tag = "InlineMixer"




            AddHandler InlineMixer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler InlineMixer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler InlineMixer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler InlineMixer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler InlineMixer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                InlineMixer_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                InlineMixer_Ctrl.AccessibleDescription = ""
            End If

            InlineMixer_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            InlineMixer_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            InlineMixer_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            InlineMixer_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            InlineMixer_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            InlineMixer_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            InlineMixer_Ctrl.Description = dt.Rows(0).Item("Description")

            InlineMixer_Ctrl._ThresholdValue.Clear()
            InlineMixer_Ctrl._THCondition.Clear()
            InlineMixer_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    InlineMixer_Ctrl._ThresholdValue.Add(thv(i))
                    InlineMixer_Ctrl._THCondition.Add(th_C(i))
                    InlineMixer_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If
            Page_Ctrl.Controls.Add(InlineMixer_Ctrl)
            InlineMixer_Ctrl.BringToFront()
            _symInlineMixerName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddInlineMixer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    ''' <summary>
    ''' Create Reciprocating Compressor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddReciprocatingCompressor(ByVal dt As DataTable)
        Try

            ReciprocatingCompressor_Ctrl = New Reciprocating_Compressor
            ReciprocatingCompressor_Ctrl.Name = "ReciprocatingCompressor" & _symReciprocatingCompressorName
            ReciprocatingCompressor_Ctrl.Tag = "ReciprocatingCompressor"




            AddHandler ReciprocatingCompressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ReciprocatingCompressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ReciprocatingCompressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ReciprocatingCompressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ReciprocatingCompressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                ReciprocatingCompressor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                ReciprocatingCompressor_Ctrl.AccessibleDescription = ""
            End If

            ReciprocatingCompressor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            ReciprocatingCompressor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            ReciprocatingCompressor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            ReciprocatingCompressor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            ReciprocatingCompressor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            ReciprocatingCompressor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            ReciprocatingCompressor_Ctrl.Description = dt.Rows(0).Item("Description")

            ReciprocatingCompressor_Ctrl._ThresholdValue.Clear()
            ReciprocatingCompressor_Ctrl._THCondition.Clear()
            ReciprocatingCompressor_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    ReciprocatingCompressor_Ctrl._ThresholdValue.Add(thv(i))
                    ReciprocatingCompressor_Ctrl._THCondition.Add(th_C(i))
                    ReciprocatingCompressor_Ctrl._THColor.Add(CInt(thbC(i)))
                Next
            End If
            Page_Ctrl.Controls.Add(ReciprocatingCompressor_Ctrl)
            ReciprocatingCompressor_Ctrl.BringToFront()
            _symReciprocatingCompressorName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddReciprocatingCompressor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Blower control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddBlower(ByVal dt As DataTable)
        Try

            Blower_Ctrl = New Blower
            Blower_Ctrl.Name = "Blower" & _symBlowerName
            Blower_Ctrl.Tag = "Blower"




            AddHandler Blower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Blower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Blower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Blower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Blower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Blower_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Blower_Ctrl.AccessibleDescription = ""
            End If

            Blower_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Blower_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Blower_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Blower_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Blower_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Blower_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Blower_Ctrl.Description = dt.Rows(0).Item("Description")

            Blower_Ctrl._ThresholdValue.Clear()
            Blower_Ctrl._THCondition.Clear()
            Blower_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Blower_Ctrl._ThresholdValue.Add(thv(i))
                    Blower_Ctrl._THCondition.Add(th_C(i))
                    Blower_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Blower_Ctrl)
            Blower_Ctrl.BringToFront()
            _symBlowerName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddBlower()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Compressor control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddCompressor(ByVal dt As DataTable)
        Try

            Compressor_Ctrl = New Compressor
            Compressor_Ctrl.Name = "Compressor" & _symCompressorName
            Compressor_Ctrl.Tag = "Compressor"




            AddHandler Compressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Compressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Compressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Compressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Compressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Compressor_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Compressor_Ctrl.AccessibleDescription = ""
            End If

            Compressor_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Compressor_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Compressor_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Compressor_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Compressor_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Compressor_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Compressor_Ctrl.Description = dt.Rows(0).Item("Description")

            Compressor_Ctrl._ThresholdValue.Clear()
            Compressor_Ctrl._THCondition.Clear()
            Compressor_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Compressor_Ctrl._ThresholdValue.Add(thv(i))
                    Compressor_Ctrl._THCondition.Add(th_C(i))
                    Compressor_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Compressor_Ctrl)
            Compressor_Ctrl.BringToFront()
            _symCompressorName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddCompressor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Pump control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddPump(ByVal dt As DataTable)
        Try

            Pump_Ctrl = New Pump
            Pump_Ctrl.Name = "Pump" & _symPumpName
            Pump_Ctrl.Tag = "Pump"




            AddHandler Pump_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Pump_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Pump_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Pump_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Pump_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Pump_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Pump_Ctrl.AccessibleDescription = ""
            End If

            Pump_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Pump_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Pump_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Pump_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Pump_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Pump_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Pump_Ctrl.Description = dt.Rows(0).Item("Description")

            Pump_Ctrl._ThresholdValue.Clear()
            Pump_Ctrl._THCondition.Clear()
            Pump_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Pump_Ctrl._ThresholdValue.Add(thv(i))
                    Pump_Ctrl._THCondition.Add(th_C(i))
                    Pump_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Pump_Ctrl)
            Pump_Ctrl.BringToFront()
            _symPumpName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddPump()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Turbine control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddTurbine(ByVal dt As DataTable)
        Try
            Turbine_Ctrl = New Turbine
            Turbine_Ctrl.Name = "Turbine" & _symTurbineName
            Turbine_Ctrl.Tag = "Turbine"




            AddHandler Turbine_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Turbine_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Turbine_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Turbine_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Turbine_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Turbine_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Turbine_Ctrl.AccessibleDescription = ""
            End If

            Turbine_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Turbine_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Turbine_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Turbine_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Turbine_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Turbine_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Turbine_Ctrl.Description = dt.Rows(0).Item("Description")

            Turbine_Ctrl._ThresholdValue.Clear()
            Turbine_Ctrl._THCondition.Clear()
            Turbine_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Turbine_Ctrl._ThresholdValue.Add(thv(i))
                    Turbine_Ctrl._THCondition.Add(th_C(i))
                    Turbine_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Turbine_Ctrl)
            Turbine_Ctrl.BringToFront()
            _symTurbineName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddTurbine()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Cyclone Seperator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddCycloneSeparator(ByVal dt As DataTable)
        Try

            CycloneSeparator_Ctrl = New Cyclone_Seperator
            CycloneSeparator_Ctrl.Name = "CycloneSeparator" & _symCycloneSeparatorName
            CycloneSeparator_Ctrl.Tag = "CycloneSeparator"




            AddHandler CycloneSeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CycloneSeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CycloneSeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CycloneSeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CycloneSeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                CycloneSeparator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                CycloneSeparator_Ctrl.AccessibleDescription = ""
            End If

            CycloneSeparator_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            CycloneSeparator_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            CycloneSeparator_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            CycloneSeparator_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            CycloneSeparator_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            CycloneSeparator_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            CycloneSeparator_Ctrl.Description = dt.Rows(0).Item("Description")

            CycloneSeparator_Ctrl._ThresholdValue.Clear()
            CycloneSeparator_Ctrl._THCondition.Clear()
            CycloneSeparator_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    CycloneSeparator_Ctrl._ThresholdValue.Add(thv(i))
                    CycloneSeparator_Ctrl._THCondition.Add(th_C(i))
                    CycloneSeparator_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(CycloneSeparator_Ctrl)
            CycloneSeparator_Ctrl.BringToFront()
            _symCycloneSeparatorName += 1


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddCycloneSeparator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Rotary Seperator control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddRotarySeparator(ByVal dt As DataTable)
        Try

            RotarySeparator_Ctrl = New Rotary_Seperator
            RotarySeparator_Ctrl.Name = "RotarySeparator" & _symRotarySeparatorName
            RotarySeparator_Ctrl.Tag = "RotarySeparator"




            AddHandler RotarySeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotarySeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotarySeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotarySeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotarySeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                RotarySeparator_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                RotarySeparator_Ctrl.AccessibleDescription = ""
            End If

            RotarySeparator_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            RotarySeparator_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            RotarySeparator_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            RotarySeparator_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            RotarySeparator_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            RotarySeparator_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            RotarySeparator_Ctrl.Description = dt.Rows(0).Item("Description")

            RotarySeparator_Ctrl._ThresholdValue.Clear()
            RotarySeparator_Ctrl._THCondition.Clear()
            RotarySeparator_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    RotarySeparator_Ctrl._ThresholdValue.Add(thv(i))
                    RotarySeparator_Ctrl._THCondition.Add(th_C(i))
                    RotarySeparator_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(RotarySeparator_Ctrl)
            RotarySeparator_Ctrl.BringToFront()
            _symRotarySeparatorName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddRotarySeparator()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create SprayDryer control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddSprayDryer(ByVal dt As DataTable)
        Try
            SprayDryer_Ctrl = New Spray_Dryer
            SprayDryer_Ctrl.Name = "SprayDryer" & _symSprayDryerName
            SprayDryer_Ctrl.Tag = "SprayDryer"




            AddHandler SprayDryer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler SprayDryer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler SprayDryer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler SprayDryer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler SprayDryer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                SprayDryer_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                SprayDryer_Ctrl.AccessibleDescription = ""
            End If

            SprayDryer_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            SprayDryer_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            SprayDryer_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            SprayDryer_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            SprayDryer_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            SprayDryer_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            SprayDryer_Ctrl.Description = dt.Rows(0).Item("Description")

            SprayDryer_Ctrl._ThresholdValue.Clear()
            SprayDryer_Ctrl._THCondition.Clear()
            SprayDryer_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    SprayDryer_Ctrl._ThresholdValue.Add(thv(i))
                    SprayDryer_Ctrl._THCondition.Add(th_C(i))
                    SprayDryer_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(SprayDryer_Ctrl)
            SprayDryer_Ctrl.BringToFront()
            _symSprayDryerName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddSprayDryer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    ''' <summary>
    ''' Create Valve control from .sam file
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub AddValve(ByVal dt As DataTable)
        Try
            Valve_Ctrl = New Valve
            Valve_Ctrl.Name = "Valve" & _iniValveName
            Valve_Ctrl.Tag = "Valve"




            AddHandler Valve_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Valve_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Valve_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Valve_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Valve_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            If Not IsDBNull(dt.Rows(0).Item("ChannelName")) Then
                Valve_Ctrl.AccessibleDescription = dt.Rows(0).Item("ChannelName")
            Else
                Valve_Ctrl.AccessibleDescription = ""
            End If

            Valve_Ctrl.Location = New Point(CSng(dt.Rows(0).Item("LocX")), CSng(dt.Rows(0).Item("LocY")))
            Valve_Ctrl.Width = CInt(dt.Rows(0).Item("Width"))
            Valve_Ctrl.Height = CInt(dt.Rows(0).Item("Height"))

            Valve_Ctrl.D_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))
            Valve_Ctrl.Gradient_Color1 = color.FromArgb(CInt(dt.Rows(0).Item("D_Color")))

            Valve_Ctrl.ForeColor = color.FromArgb(CInt(dt.Rows(0).Item("ForeColor")))
            Valve_Ctrl.Description = dt.Rows(0).Item("Description")

            Valve_Ctrl._ThresholdValue.Clear()
            Valve_Ctrl._THCondition.Clear()
            Valve_Ctrl._THColor.Clear()

            If Not dt.Rows(0).Item("lblThresholdVal").ToString = "False" Then
                Dim thv, th_C, thbC As New ArrayList
                thv = New ArrayList(dt.Rows(0).Item("lblThresholdVal").ToString.Split("*"))
                th_C = New ArrayList(dt.Rows(0).Item("THCondition").ToString.Split("*"))
                thbC = New ArrayList(dt.Rows(0).Item("lblTHBackColor").ToString.Split("*"))

                For i As Integer = 0 To thv.Count - 2
                    Valve_Ctrl._ThresholdValue.Add(thv(i))
                    Valve_Ctrl._THCondition.Add(th_C(i))
                    Valve_Ctrl._THColor.Add(CInt(thbC(i)))

                Next
            End If

            Page_Ctrl.Controls.Add(Valve_Ctrl)
            Valve_Ctrl.BringToFront()
            _iniValveName += 1



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddValve()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    ''' <summary>
    ''' Read the XML(.sam) file and create the Controls Which are Stored in the file
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Sub OpenFile(ByVal path As String)
        Try
            Explore_DataSources()
            ds = New DataSet
            ds.ReadXml(path)
            'MyDecryptor(ds, path)
            If ds.Tables.Count > 0 Then
                _iniPageName = 0
                _iniChartName = 1
                _iniGuageName = 1
                _iniLabelName = 1
                _iniValuelabelName = 1
                PageTreeView.Nodes(0).Nodes(0).Nodes.Clear()
                PageTreeView.Nodes(0).Nodes(1).Nodes.Clear()

                'Server_PushDataPath = Application.StartupPath
                'Server_PullDataPath = Application.StartupPath
                'Storage_Loc = Application.StartupPath

                For i As Integer = 0 To ds.Tables.Count - 1
                    dt = New DataTable()
                    dt = ds.Tables(i).DefaultView.ToTable(True)
                    dt.AcceptChanges()

                    If ds.Tables(i).TableName = "Settings" Then
                        Server_PushDataPath = dt.Rows(0).Item("RemotePushDatapath")
                        Server_PullDataPath = dt.Rows(0).Item("RemotePullDatapath")
                        Storage_Loc = dt.Rows(0).Item("Storage_Loc")
                    End If
                Next

                For i As Integer = 0 To ds.Tables.Count - 1
                    dt = New DataTable()
                    dt = ds.Tables(i).DefaultView.ToTable(True)
                    dt.AcceptChanges()

                    If ds.Tables(i).TableName = "Channel" Then
                        channelList.Channel_Name.Clear()
                        channelList.Channel_Query.Clear()
                        channelList.Channel_Flag.Clear()
                        channelList._Query_Channel.Clear()
                        channelList.DBChannel_RefreshTime.Clear()
                        AddChaneel(dt)
                        ' AnnunciatorPropertiesForm.AnnunciatorFlow_Properties(Me.Annunciator_Ctrl)
                    ElseIf ds.Tables(i).TableName = "OPCChannel" Then
                        OPC_ChannelList_Class.OPC_Channel_Name.Clear()
                        OPC_ChannelList_Class.OPC_ServerName.Clear()
                        OPC_ChannelList_Class.OPC_OPCItems.Clear()
                        OPC_ChannelList_Class.OPC_RefreshTime.Clear()
                        OPC_ChannelList_Class.OPC_HistoryLength.Clear()
                        OPC_ChannelList_Class.OPC_LastnnHourHistory.Clear()
                        OPC_ChannelList_Class.OPC_Multiview.Clear()
                        AddOpcChaneel(dt)

                    ElseIf ds.Tables(i).TableName = "SAMAHistorianChannel" Then
                        SAMAHistorian_ChannelList.ChannelReportname.Clear()
                        SAMAHistorian_ChannelList.ChannelReportDescription.Clear()
                        SAMAHistorian_ChannelList.ChannelTags.Clear()
                        SAMAHistorian_ChannelList.ChannelDuration.Clear()
                        SAMAHistorian_ChannelList.ChannelInterval.Clear()
                        SAMAHistorian_ChannelList.ChannelXAxis.Clear()
                        SAMAHistorian_ChannelList.ChannelOperations.Clear()
                        AddSAMAHistorianChannel(dt)

                    ElseIf ds.Tables(i).TableName = "OPCDAServers" Then
                        OPCDAServersList.Configname.Clear()
                        OPCDAServersList.PrimaryIPAddress.Clear()
                        OPCDAServersList.PrimaryPortNo.Clear()
                        OPCDAServersList.SecondaryIPAddress.Clear()
                        OPCDAServersList.SecondaryPortNo.Clear()
                        OPCDAServersList.RefreshInterval.Clear()
                        AddOPCDAservers(dt)

                    ElseIf ds.Tables(i).TableName = "OPCHDAServers" Then
                        OPCHDAServersList.Configname.Clear()
                        OPCHDAServersList.PrimaryIPAddress.Clear()
                        OPCHDAServersList.PrimaryPortNo.Clear()
                        OPCHDAServersList.SecondaryIPAddress.Clear()
                        OPCHDAServersList.SecondaryPortNo.Clear()
                        AddOPCHDAServers(dt)

                    ElseIf ds.Tables(i).TableName = "OPCDAChannel" Then
                        OPCDAChannelsList.OPC_Channel_Name.Clear()
                        OPCDAChannelsList.OPC_ServerName.Clear()
                        OPCDAChannelsList.OPC_OPCItems.Clear()
                        OPCDAChannelsList.OPC_RefreshTime.Clear()
                        OPCDAChannelsList.OPC_HistoryLength.Clear()
                        OPCDAChannelsList.OPC_LastnnHourHistory.Clear()
                        OPCDAChannelsList.OPC_Multiview.Clear()
                        AddOPCDAChannel(dt)

                    ElseIf ds.Tables(i).TableName = "OPCHDAChannel" Then
                        OPCHDAChannelsList.OPC_Channel_Name.Clear()
                        OPCHDAChannelsList.OPC_ServerName.Clear()
                        OPCHDAChannelsList.OPC_OPCItems.Clear()
                        OPCHDAChannelsList.OPC_Last.Clear()
                        OPCHDAChannelsList.OPC_Interval.Clear()
                        OPCHDAChannelsList.OPC_RelativeTime.Clear()
                        OPCHDAChannelsList.OPC_XAxis.Clear()
                        AddOPCHDAChannel(dt)

                    ElseIf ds.Tables(i).TableName = "Pages" Then
                        AddPages(dt)
                    ElseIf ds.Tables(i).TableName = "Settings" Then
                        AddSettings(dt)
                    ElseIf ds.Tables(i).TableName = "Task" Then
                        AddTask_List(dt)
                    ElseIf ds.Tables(i).TableName = "Email" Then
                        AddEmailSetting(dt)
                    Else
                        Dim pnl_Obj As Panel

                        Dim pnlObj() As Control
                        pnlObj = Me.Controls.Find(dt.Rows(0).Item("PageNo"), True)
                        If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                            pnl_Obj = pnlObj(0)
                        End If


                        Page_Ctrl = pnl_Obj
                        If (dt.Rows(0).Item("Tag")) = "Guage" Then
                            AddGuadge(dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt.Rows(0).Item("CaptionName"), dt.Rows(0).Item("CapX"), dt.Rows(0).Item("CapY"), dt.Rows(0).Item("ChannelName"),
                            dt.Rows(0).Item("MinValue"), dt.Rows(0).Item("MaxValue"), dt.Rows(0).Item("BGColor"), dt.Rows(0).Item("NeedleType"), dt.Rows(0).Item("NeedleWidth"), dt.Rows(0).Item("NeedleColor"),
                            dt.Rows(0).Item("StepValue"), dt.Rows(0).Item("Rangedegree"), dt.Rows(0).Item("StartDegree"), dt.Rows(0).Item("OutarcColor"), dt.Rows(0).Item("RangeIdx0"), dt.Rows(0).Item("RangeStartValue0"),
                            dt.Rows(0).Item("RangeEndValue0"), dt.Rows(0).Item("RangeColor0"), dt.Rows(0).Item("RangeIdx1"), dt.Rows(0).Item("RangeStartValue1"), dt.Rows(0).Item("RangeEndValue1"), dt.Rows(0).Item("RangeColor1"),
                            dt.Rows(0).Item("RangeIdx2"), dt.Rows(0).Item("RangeStartValue2"), dt.Rows(0).Item("RangeEndValue2"), dt.Rows(0).Item("RangeColor2"), dt.Rows(0).Item("OuterEnable"), dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"))

                            Page_Ctrl.Controls.SetChildIndex(Guage_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Text" Then
                            AddLabel(dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt.Rows(0).Item("lblText"), dt.Rows(0).Item("BackColor"), dt.Rows(0).Item("ForeColor"), dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"),
                            dt.Rows(0).Item("lblBorderStyle"), dt.Rows(0).Item("lblFontName"), dt.Rows(0).Item("lblFontSize"), dt.Rows(0).Item("Tag"), dt.Rows(0).Item("lblStyle"))

                            Page_Ctrl.Controls.SetChildIndex(Label_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "displayValue" Then
                            AddValLabelCtrl(dt.Rows(0).Item("ChannelName"), dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt.Rows(0).Item("lblText"),
                             dt.Rows(0).Item("BackColor"), dt.Rows(0).Item("ForeColor"), dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"), dt.Rows(0).Item("lblBorderStyle"),
                             dt.Rows(0).Item("lblFontName"), dt.Rows(0).Item("lblFontSize"), dt.Rows(0).Item("Tag"),
                            dt.Rows(0).Item("lblStyle"), dt.Rows(0).Item("lblThresholdVal"), dt.Rows(0).Item("lblTHForeColor"),
                            dt.Rows(0).Item("lblTHBackColor"), dt.Rows(0).Item("Units"), dt.Rows(0).Item("lblTHBlink"), dt.Rows(0).Item("Dese"))

                            Page_Ctrl.Controls.SetChildIndex(ValueLabel_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Chart" Then
                            AddChart(dt)

                            Page_Ctrl.Controls.SetChildIndex(Chart_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Panel" Then
                            AddPanel(dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"), dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt.Rows(0).Item("EdgeRaised"), dt.Rows(0).Item("pnlBackColor"))

                            pnl_Obj.Controls.SetChildIndex(Panel_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "PicBox" Then
                            AddPictureBox(dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"), dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt.Rows(0).Item("isStretch"), dt.Rows(0).Item("ImageName"))

                            pnl_Obj.Controls.SetChildIndex(PictureBox_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Grid" Then
                            AddGrid_Table(dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"), dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt)
                            Page_Ctrl.Controls.SetChildIndex(Grid_TableCtrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "Annunciator" Then
                            Add_Annunciator(dt.Rows(0).Item("Width"), dt.Rows(0).Item("Height"), dt.Rows(0).Item("LocX"), dt.Rows(0).Item("LocY"), dt)
                            Page_Ctrl.Controls.SetChildIndex(Annunciator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "LogBook" Then
                            AddLogViewer(dt)
                            Page_Ctrl.Controls.SetChildIndex(LogCtrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Button" Then
                            AddButton(dt)
                            Page_Ctrl.Controls.SetChildIndex(Button_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "OPCWriter" Then
                            AddOPCWriter(dt)
                            Page_Ctrl.Controls.SetChildIndex(OPCWrite_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Trender" Then
                            AddTrender(dt)
                            Page_Ctrl.Controls.SetChildIndex(Trender_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "MChart" Then
                            AddNewMChartFromDataTable(dt)
                            'Page_Ctrl.Controls.SetChildIndex(MChart_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                            'Page_Ctrl.Controls.SetChildIndex(ct, CInt(dt.Rows(0).Item("Z_Order")))

                            '----------------------- Symbols Part ---------------------------------
                        ElseIf (dt.Rows(0).Item("Tag")) = "DistillationTower" Then
                            AddDistillationTower(dt)

                            Page_Ctrl.Controls.SetChildIndex(DistillationTower_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "JacketedVessel" Then
                            AddJacketedVessel(dt)
                            Page_Ctrl.Controls.SetChildIndex(JacketedVessel_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Reactor" Then
                            AddReactor(dt)
                            Page_Ctrl.Controls.SetChildIndex(Reactor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "Vessel" Then
                            AddVessel(dt)
                            Page_Ctrl.Controls.SetChildIndex(Vessel_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "AtmosphericTank" Then
                            AddAtmosphericTank(dt)
                            Page_Ctrl.Controls.SetChildIndex(AdmosphericTank_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "Bin" Then
                            AddBin(dt)
                            Page_Ctrl.Controls.SetChildIndex(Bin_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "FloatingRoofTank" Then
                            AddFloatingRoofTank(dt)
                            Page_Ctrl.Controls.SetChildIndex(FloatingRoofTank_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "GasHolder" Then
                            AddGasHolder(dt)
                            Page_Ctrl.Controls.SetChildIndex(GasHolder_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "PressureStorageVessel" Then
                            AddPressureStorageVessel(dt)
                            Page_Ctrl.Controls.SetChildIndex(PressureStorageVessel_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "WeighHopper" Then
                            AddWeighHopper(dt)
                            Page_Ctrl.Controls.SetChildIndex(WeighHopper_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "CircuitBreaker" Then
                            AddCircuitBreaker(dt)
                            Page_Ctrl.Controls.SetChildIndex(CircuitBreaker_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "ManualContactor" Then
                            AddManualContactor(dt)
                            Page_Ctrl.Controls.SetChildIndex(ManualContactor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "DeltaConnection" Then
                            AddDeltaConnection(dt)
                            Page_Ctrl.Controls.SetChildIndex(DeltaConnection_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Fuse" Then
                            AddFuse(dt)
                            Page_Ctrl.Controls.SetChildIndex(Fuse_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Motor" Then
                            AddMotor(dt)
                            Page_Ctrl.Controls.SetChildIndex(Motor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "StateIndicator" Then
                            AddStateIndicator(dt)
                            Page_Ctrl.Controls.SetChildIndex(StateIndicator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Transformer" Then
                            AddTransformer(dt)
                            Page_Ctrl.Controls.SetChildIndex(Transformer_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "WyeConnection" Then
                            AddWyeConnection(dt)
                            Page_Ctrl.Controls.SetChildIndex(WyeConnection_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "LiquidFilter" Then
                            AddLiquidFilter(dt)
                            Page_Ctrl.Controls.SetChildIndex(LiquidFilter_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "VacuumFilter" Then
                            AddVacuumFilter(dt)
                            Page_Ctrl.Controls.SetChildIndex(VacuumFilter_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Exchanger" Then
                            AddExchanger(dt)
                            Page_Ctrl.Controls.SetChildIndex(Exchanger_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "ForcedAirExchanger" Then
                            AddForcedAirExchanger(dt)
                            Page_Ctrl.Controls.SetChildIndex(ForcedAirExchanger_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Furnace" Then
                            AddFurnace(dt)
                            Page_Ctrl.Controls.SetChildIndex(Furnace_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "RotaryKiln" Then
                            AddRotaryKiln(dt)
                            Page_Ctrl.Controls.SetChildIndex(RotaryKiln_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "CoolingTower" Then
                            AddCoolingTower(dt)
                            Page_Ctrl.Controls.SetChildIndex(CoolingTower_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Evaporator" Then
                            AddEvaporator(dt)
                            Page_Ctrl.Controls.SetChildIndex(Evaporator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "FinnedExchanger" Then
                            AddFinnedExchanger(dt)
                            Page_Ctrl.Controls.SetChildIndex(FinnedExchanger_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "Conveyor" Then
                            AddConveyor(dt)
                            Page_Ctrl.Controls.SetChildIndex(Conveyor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Mill" Then
                            AddMill(dt)
                            Page_Ctrl.Controls.SetChildIndex(Mill_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "RollStand" Then
                            AddRollStand(dt)
                            Page_Ctrl.Controls.SetChildIndex(RollStand_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "RotaryFeeder" Then
                            AddRotaryFeeder(dt)
                            Page_Ctrl.Controls.SetChildIndex(RotaryFeeder_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "ScrewConveyor" Then
                            AddScrewConveyor(dt)
                            Page_Ctrl.Controls.SetChildIndex(ScrewConveyor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Agitator" Then
                            AddAgitator(dt)
                            Page_Ctrl.Controls.SetChildIndex(Agitator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "InlineMixer" Then
                            AddInlineMixer(dt)
                            Page_Ctrl.Controls.SetChildIndex(InlineMixer_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "ReciprocatingCompressor" Then
                            AddReciprocatingCompressor(dt)
                            Page_Ctrl.Controls.SetChildIndex(ReciprocatingCompressor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "Blower" Then
                            AddBlower(dt)
                            Page_Ctrl.Controls.SetChildIndex(Blower_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Compressor" Then
                            AddCompressor(dt)
                            Page_Ctrl.Controls.SetChildIndex(Compressor_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Pump" Then
                            AddPump(dt)
                            Page_Ctrl.Controls.SetChildIndex(Pump_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Turbine" Then
                            AddTurbine(dt)
                            Page_Ctrl.Controls.SetChildIndex(Turbine_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "CycloneSeparator" Then
                            AddCycloneSeparator(dt)
                            Page_Ctrl.Controls.SetChildIndex(CycloneSeparator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "RotarySeparator" Then
                            AddRotarySeparator(dt)
                            Page_Ctrl.Controls.SetChildIndex(RotarySeparator_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        ElseIf (dt.Rows(0).Item("Tag")) = "SprayDryer" Then
                            AddSprayDryer(dt)
                            Page_Ctrl.Controls.SetChildIndex(SprayDryer_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Valve" Then
                            AddValve(dt)
                            Page_Ctrl.Controls.SetChildIndex(Valve_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "Indicator" Then
                            AddIndicator(dt)
                            Page_Ctrl.Controls.SetChildIndex(LevelIndicator_ctrl, CInt(dt.Rows(0).Item("Z_Order")))
                        ElseIf (dt.Rows(0).Item("Tag")) = "LineElbow" Then
                            AddLineElbow(dt)
                            Page_Ctrl.Controls.SetChildIndex(Line_Ctrl, CInt(dt.Rows(0).Item("Z_Order")))

                        End If
                    End If

                Next
                ' PageTreeView.SelectedNode = PageTreeView.Nodes(0).Nodes(2).Nodes(0)
            End If
            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(1).Nodes.Count - 1 'Set Image to Supra DB Channel node
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(1).Nodes(i).SelectedImageIndex = 4
            Next
            For i As Integer = 0 To PageTreeView.Nodes(0).Nodes(0).Nodes.Count - 1 'Set Image to Opc Channel node
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).ImageIndex = 4
                PageTreeView.Nodes(0).Nodes(0).Nodes(i).SelectedImageIndex = 4
            Next

            If _runMode Then
                MSMenu.Visible = False
                SplitContainer1.Panel2Collapsed = True
                _runMode = True
            End If

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OpenFile()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    Private Sub MainPage_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim result1 = MsgBox("Are you sure want to Exit ?", vbYesNo)
            If result1 = DialogResult.Yes Then
                If modify Then
                    Dim result = MessageBox.Show("Do you Want to Save the Changes.....", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    If result = DialogResult.Cancel Then
                        e.Cancel = True
                    ElseIf result = DialogResult.No Then
                        Call ClearALL()
                        ' End 'Terminate Exe
                    ElseIf result = DialogResult.Yes Then
                        Call Main_SaveMenu_Click(sender, e)
                        Call ClearALL()
                        ' End 'Terminate Exe
                    End If
                Else
                    Call ClearALL()
                    ' End 'if Not modified the Page End the Process
                End If


                Dim login As New LoginForm
                login.Text = "Logout"
                login.ShowDialog()
                If login.BtnOk Then
                    If login.datarow.Count > 0 Then

                        'Try
                        '    CefSharp.Cef.Shutdown()

                        'Catch ex As Exception

                        'End Try
                        End
                    End If
                ElseIf login.Blncancel Then
                    e.Cancel = True
                End If
                'If login.BtnOk And login.datarow.Count > 0 Then

                '    End

                'Else
                '    e.Cancel = True
                'End If




            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainPage_FormClosing()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        Finally
            For Each p As Process In Process.GetProcessesByName("EmailSender")
                p.Kill()
                p.WaitForExit()
            Next
        End Try


    End Sub
    Private Sub MainPage_FormClosing(ByVal sender As System.Object, ByVal e As EventArgs)
        Try

            If modify Then
                Dim result = MessageBox.Show("Do you Want to Save the Changes.....", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                If result = DialogResult.Cancel Then
                    Exit Sub
                ElseIf result = DialogResult.No Then
                    Call ClearALL()

                    'Try
                    '    CefSharp.Cef.Shutdown()

                    'Catch ex As Exception

                    'End Try
                    End 'Terminate Exe
                ElseIf result = DialogResult.Yes Then
                    Call Main_SaveMenu_Click(sender, e)
                    Call ClearALL()

                    'Try
                    '    CefSharp.Cef.Shutdown()

                    'Catch ex As Exception

                    'End Try
                    End 'Terminate Exe
                End If
            Else
                Call ClearALL()

                'Try
                '    CefSharp.Cef.Shutdown()

                'Catch ex As Exception

                'End Try
                End 'if Not modified the Page End the Process
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainPage_FormClosing()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    Private Sub printDOCCurrReport_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDOCCurrReport.PrintPage
        Try
            Dim myImage As New Bitmap(Page_Ctrl.Width, Page_Ctrl.Height)
            Dim printSize As Size = e.MarginBounds.Size
            Dim scale As Double = 1
            Page_Ctrl.BorderStyle = BorderStyle.None
            Page_Ctrl.DrawToBitmap(myImage, New Rectangle(Point.Empty, Page_Ctrl.Size))
            Page_Ctrl.BorderStyle = BorderStyle.Fixed3D
            printSize.Width *= 1.0 'convert to pixels
            printSize.Height *= 1.0
            If myImage.Width > printSize.Width Then
                'Form is to big. Scale it down.
                scale = printSize.Width / myImage.Width
                e.Graphics.ScaleTransform(scale, scale)
            End If
            If (myImage.Height * scale) > printSize.Height Then
                'The form is still to big. Scale it again.
                scale = printSize.Height / (myImage.Height * scale)
                e.Graphics.ScaleTransform(scale, scale)
            End If
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
            e.Graphics.DrawImage(myImage, e.MarginBounds.Location)
            myImage.Dispose()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@printDOCCurrReport_PrintPage()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub


    Private Sub TS_TableClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TableClear.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Page_Ctrl.Controls.Remove(Grid_TableCtrl)

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TS_TableClear_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub TS_TableSendToBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TableSendToBack.Click
        Grid_TableCtrl.SendToBack()
    End Sub

    Private Sub TS_TableBringtoFront_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TableBringtoFront.Click
        Grid_TableCtrl.BringToFront()
    End Sub

    Private Sub AddChannelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChannelAdd.Click
        SupraDBChannelsListForm.ShowDialog()
    End Sub
    Private Sub ConnectServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectServerToolStripMenuItem.Click
        ConnectServerForm.ShowDialog()
    End Sub
    ''' <summary>
    ''' Dispose the all the resource , reset the OPC server,Timers and File Watcher
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearALL()
        Try
            'Remove Task_Schedule Timer
            If Not Task_scheduleClassList Is Nothing Then
                For i As Integer = 0 To Task_scheduleClassList.Length - 1
                    If Not Task_scheduleClassList(i) Is Nothing Then
                        Task_scheduleClassList(i).Task_timer.Dispose() 'Dispose Timer
                    End If
                Next
            End If
            'Remove SupraDBChannel Timer & Watcher
            If Not DBDataFormClass Is Nothing Then
                For i As Integer = 0 To DBDataFormClass.Length - 1
                    If Not DBDataFormClass(i) Is Nothing Then
                        DBDataFormClass(i).Q_Timer.Dispose() 'Dispose Timer
                        DBDataFormClass(i).Watcher.Dispose() 'Dispose FileWatcher
                    End If
                Next
            End If

            'Remove OPC Server Tags
            If Not opcCnfgTags Is Nothing Then
                For j As Integer = 0 To opcCnfgTags.Length - 1
                    opcCnfgTags(j).Watcher.Dispose() 'Dispose File Watcher
                    If Not opcCnfgTags(j) Is Nothing AndAlso Not opcCnfgTags(j)._asyncRefrGroup Is Nothing Then
                        Dim item() As ItemDef = opcCnfgTags(j)._asyncRefrGroup.GetItemsInGroup()
                        For i As Integer = 0 To item.Length - 1
                            opcCnfgTags(j)._asyncRefrGroup.Remove(item(i).OpcIDef.ItemID) 'Remove OPC Items
                        Next
                        opcCnfgTags(j).Close()

                    End If
                Next
            End If
            'Remove SAMAHistorianChannels
            SAMAHistorian_ChannelList.ChannelReportname.Clear()
            SAMAHistorian_ChannelList.ChannelReportDescription.Clear()
            SAMAHistorian_ChannelList.ChannelTags.Clear()
            SAMAHistorian_ChannelList.ChannelDuration.Clear()
            SAMAHistorian_ChannelList.ChannelInterval.Clear()
            SAMAHistorian_ChannelList.ChannelXAxis.Clear()
            SAMAHistorian_ChannelList.ChannelDatatable.Clear()
            For Each tmr In SAMAHistorian_ChannelList.ChannelTimers
                tmr.Stop()
                tmr.Dispose()
            Next
            'CsvFileWatchTimer.Stop()
            'CsvFileWatchTimer.Dispose()
            SAMAHistorian_ChannelList.ChannelTimers.Clear()
            'PageTreeView.Nodes(0).Nodes(3).Nodes.Clear()

            'Opc Server Disconnect
            If Not OPC_Servers Is Nothing Then
                For i As Integer = 0 To OPC_Servers.Length - 1
                    If Not OPC_Servers(i) Is Nothing Then
                        OPC_Servers(i).Disconnect()
                        OPC_Servers(i) = Nothing
                    End If

                Next
            End If


            ''Clear Channels Nodes

            'PageTreeView.Nodes(0).Nodes(0).Nodes.Clear
            'PageTreeView.Nodes(0).Nodes(1).Nodes.Clear

            'For Clear Controls in Pages
            For i As Integer = 0 To CreatedPages.Count - 1
                Dim pnlObj() As Control
                pnlObj = Me.Controls.Find(CreatedPages(i), True)
                If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                    pnlObj(0).Controls.Clear()
                End If
            Next
            CreatedPages.Clear()

            pnlPage1.Name = "pnlPage1"
            pnlPage2.Name = "pnlPage2"
            pnlPage3.Name = "pnlPage3"
            pnlPage4.Name = "pnlPage4"
            pnlPage5.Name = "pnlPage5"
            pnlPage6.Name = "pnlPage6"
            pnlPage7.Name = "pnlPage7"
            pnlPage8.Name = "pnlPage8"
            pnlPage9.Name = "pnlPage9"
            pnlPage10.Name = "pnlPage10"
            pnlPage11.Name = "pnlPage11"
            pnlPage12.Name = "pnlPage12"
            pnlPage13.Name = "pnlPage13"
            pnlPage14.Name = "pnlPage14"
            pnlPage15.Name = "pnlPage15"
            pnlPage16.Name = "pnlPage16"
            pnlPage17.Name = "pnlPage17"
            pnlPage18.Name = "pnlPage18"
            pnlPage19.Name = "pnlPage19"
            pnlPage20.Name = "pnlPage20"

            TreeViewLeft.Nodes.Clear()

            Ctrl_NameList.Clear() 'Clear Control Name Chart & GridTable
            tmrCheckConnectivity.Enabled = False
            _serverIP = ""
            _AutoReconnect = False
            Storage_Loc = ""
            Server_PushDataPath = ""
            Server_PullDataPath = ""
            _oldPass = ""
            _NewPass = ""
            _RetypePass = ""
            EmailSetting.Clear()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ClearALL()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        Finally
            GC.Collect()
        End Try


    End Sub
    'Open Menu
    Private Sub Main_OpenMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Main_OpenMenu.Click

        Try
            If modify Then
                Dim result = MessageBox.Show("Do you Want to Save tha Changes.....", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                If result = DialogResult.Cancel Then
                    Exit Sub
                ElseIf result = DialogResult.No Then


                    Dim openSavedlg As New OpenFileDialog
                    openSavedlg.Filter = "Supra File (*.sam)|*.sam"
                    openSavedlg.FilterIndex = 0
                    If openSavedlg.ShowDialog = DialogResult.OK Then
                        If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                            Me.Tag = openSavedlg.FileName
                            If Server_Flag Then
                                Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Server]"
                            Else
                                Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Client]"
                            End If


                            Call ClearALL() 'Clear Server,etc
                            Call OpenFile(openSavedlg.FileName)
                        Else
                            MsgBox("File Name Required !!")
                        End If
                    End If
                ElseIf result = DialogResult.Yes Then
                    Call Main_SaveMenu_Click(sender, e)



                    Dim openSavedlg As New OpenFileDialog
                    openSavedlg.Filter = "Supra File (*.sam)|*.sam"
                    openSavedlg.FilterIndex = 0
                    If openSavedlg.ShowDialog = DialogResult.OK Then
                        If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                            Me.Tag = openSavedlg.FileName
                            If Server_Flag Then
                                Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Server]"
                            Else
                                Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Client]"
                            End If
                            Call ClearALL()
                            Call OpenFile(openSavedlg.FileName)
                        Else
                            MsgBox("File Name Required !!")
                        End If
                    End If
                End If
            Else

                Dim openSavedlg As New OpenFileDialog
                openSavedlg.Filter = "Supra File (*.sam)|*.sam"
                openSavedlg.FilterIndex = 0
                If openSavedlg.ShowDialog = DialogResult.OK Then
                    If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                        Me.Tag = openSavedlg.FileName
                        If Server_Flag Then
                            Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Server]"
                        Else
                            Me.Text = "SAMA Analyzer - " & openSavedlg.SafeFileName & "  [Client]"
                        End If
                        Call ClearALL()
                        Call OpenFile(openSavedlg.FileName)

                    Else
                        MsgBox("File Name Required !!")
                    End If
                End If
            End If


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OpenToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'SAVE MENU
    Dim pnlObj() As Control
    Dim pnl As Panel
    Private Sub Main_SaveMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Main_SaveMenu.Click
        Try

            Dim docName As String = ""
            If modify Then
                ds = New DataSet
                dt = New DataTable
                'Dim blnopen As Boolean
                Dim fname As String = ""
                If Me.Tag = "SAMA Analyzer - Untitled" Then
                    Dim savedlg As New SaveFileDialog
                    savedlg.Filter = "SupraXMLFile (*.Supra File)|*.sam"
                    savedlg.FilterIndex = 0
                    If savedlg.ShowDialog = DialogResult.OK Then
                        'blnopen = True
                        fname = savedlg.FileName
                        docName = Microsoft.VisualBasic.Mid(fname, InStrRev(fname, "\") + 1)
                    End If
                Else
                    fname = Me.Tag
                    docName = Microsoft.VisualBasic.Mid(fname, InStrRev(fname, "\") + 1)
                End If
                If (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                    Exit Sub
                End If
                'If blnopen Then
                ds.Namespace = fname
                Call DTColumnsAdd()
                dtidx = 0
                Call Proc_ChannelSave()
                dtidx = 1
                Call ProcOpcChannelSave()
                dtidx = 2
                Call ProcSAMAHistorianChannelSave()
                dtidx = 3
                Call ProcOPCDAServerSave()
                dtidx = 4
                Call ProcOPCHDAServerSave()
                dtidx = 5
                Call ProcOPCDAChannelSave()
                dtidx = 6
                Call ProcOPCHDAChannelSave()
                dtidx = 7
                Call Proc_PageS()
                dtidx = 8
                Call Proc_CommonSetting()
                dtidx = 9
                Call Proc_Task_List()
                dtidx = 10
                Call Proc_EmailSetting()
                dtidx = 11
                'Get Panel through Page Node 
                For i As Integer = 0 To CreatedPages.Count - 1
                    pnlObj = Nothing
                    pnlObj = Me.Controls.Find(CreatedPages(i), True)

                    If pnlObj.Length <> 0 Then
                        If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                            pnl = Nothing
                            pnl = pnlObj(0)
                            pnl.AutoScrollPosition = New Point(0, 0) 'Set Cursor LOcation

                            'Get All Controls from  Pnl_Obj(0)
                            For Each Fcontrols In pnlObj(0).Controls
                                If (TypeOf Fcontrols Is DataGridView) Then
                                    'Handled in MChartCtrl
                                    Continue For
                                End If
                                If (TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then
                                    Guage_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Guage_Ctrl.Name)
                                End If
                                If (TypeOf Fcontrols Is LabelValue) Then
                                    ValueLabel_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ValueLabel_Ctrl.Name)
                                ElseIf (TypeOf Fcontrols Is Label) Then
                                    Label_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Label_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is ChartControl) Then
                                    Chart_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Chart_Ctrl.Name)
                                End If
                                If (TypeOf Fcontrols Is MChartControl) Then
                                    MChart_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, MChart_Ctrl.Name)
                                End If
                                If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                    Grid_TableCtrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Grid_TableCtrl.Name)
                                End If
                                If (TypeOf Fcontrols Is AnnunciatorCtrl) Then
                                    Annunciator_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Annunciator_Ctrl.Name)
                                End If
                                If (TypeOf Fcontrols Is Panel) Then
                                    Panel_Ctrl = Fcontrols
                                    If Not Panel_Ctrl.Tag = "Annunciator" Then
                                        Call DataRow(CreatedPages(i), 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Panel_Ctrl.Name)
                                    End If
                                End If
                                If (TypeOf Fcontrols Is PictureBox) Then
                                    PictureBox_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, PictureBox_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is Button_Control) Then
                                    Button_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, Button_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is OPCWriterControl) Then
                                    OPCWrite_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, OPCWrite_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is LogViewer) Then
                                    LogCtrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, LogCtrl.Name)
                                End If

                                If (TypeOf Fcontrols Is MultiTrendCtrl) Then
                                    Trender_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, Trender_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is Valve) Then
                                    Valve_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, Valve_Ctrl.Name)
                                End If

                                If (TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor) Then
                                    Switch_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, Switch_Ctrl.Name)
                                End If

                                If Not (TypeOf Fcontrols Is Button_Control Or TypeOf Fcontrols Is PictureBox Or TypeOf Fcontrols Is Label _
                                        Or TypeOf Fcontrols Is Panel Or TypeOf Fcontrols Is LogViewer _
                                        Or TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor Or TypeOf Fcontrols Is Valve _
                               Or TypeOf Fcontrols Is LevelIndicator Or TypeOf Fcontrols Is DataGridViewCtrl _
                               Or TypeOf Fcontrols Is Chart Or TypeOf Fcontrols Is LabelValue Or TypeOf Fcontrols Is AnalyzerMeter.AGauge Or TypeOf Fcontrols Is MultiTrendCtrl Or TypeOf Fcontrols Is MChartControl Or TypeOf Fcontrols Is OPCWriterControl) Then


                                    Symbol_Ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, Symbol_Ctrl.Name)
                                End If


                                If (TypeOf Fcontrols Is LevelIndicator) Then
                                    LevelIndicator_ctrl = Fcontrols
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, LevelIndicator_ctrl.Name)
                                End If
                            Next

                        End If
                    End If
                Next

                If Not String.IsNullOrEmpty(fname) Then
                    ds.WriteXml(fname)
                    ' MyEncryptor(ds, fname)
                    Me.Tag = fname
                    If Server_Flag Then
                        Me.Text = "SAMA Analyzer - " & docName & "  [Server]"
                    Else
                        Me.Text = "SAMA Analyzer - " & docName & "  [Client]"
                    End If

                    modify = False
                    MsgBox("Done")

                End If
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainSaveMenu_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    'Save As Menu
    Private Sub Main_SaveAsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Main_SaveAsMenu.Click
        Try
            Dim docName As String = ""

            ds = New DataSet
            dt = New DataTable
            'Dim blnopen As Boolean
            Dim fname As String = ""
            Dim savedlg As New SaveFileDialog
            savedlg.Filter = "SupraXMLFile (*.Supra File)|*.sam"
            savedlg.FilterIndex = 0
            If savedlg.ShowDialog = DialogResult.OK Then
                fname = savedlg.FileName
            End If

            If (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                Exit Sub
            End If

            If (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                Exit Sub
            End If
            'If blnopen Then
            ds.Namespace = fname
            Call DTColumnsAdd()
            dtidx = 0
            Call Proc_ChannelSave()
            dtidx = 1
            Call ProcOpcChannelSave()
            dtidx = 2
            Call ProcSAMAHistorianChannelSave()
            dtidx = 3
            Call ProcOPCDAServerSave()
            dtidx = 4
            Call ProcOPCHDAServerSave()
            dtidx = 5
            Call ProcOPCDAChannelSave()
            dtidx = 6
            Call ProcOPCHDAChannelSave()
            dtidx = 7
            Call Proc_PageS()
            dtidx = 8
            Call Proc_CommonSetting()
            dtidx = 9
            Call Proc_Task_List()
            dtidx = 10
            Call Proc_EmailSetting()
            dtidx = 11
            'Get Panel through Page Node 
            For i As Integer = 0 To CreatedPages.Count - 1
                pnlObj = Nothing
                pnlObj = Me.Controls.Find(CreatedPages(i), True)

                If pnlObj.Length <> 0 Then
                    If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                        pnl = Nothing
                        pnl = pnlObj(0)
                        pnl.AutoScrollPosition = New Point(0, 0) 'Set Cursor LOcation

                        'Get All Controls from  Pnl_Obj(0)
                        For Each Fcontrols In pnlObj(0).Controls
                            If (TypeOf Fcontrols Is DataGridView) Then
                                'Handled by MChart Control
                                Continue For
                            End If
                            If (TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then
                                Guage_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Guage_Ctrl.Name)
                            End If
                            If (TypeOf Fcontrols Is LabelValue) Then
                                ValueLabel_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ValueLabel_Ctrl.Name)
                            ElseIf (TypeOf Fcontrols Is Label) Then
                                Label_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Label_Ctrl.Name)
                            End If

                            If (TypeOf Fcontrols Is ChartControl) Then
                                Chart_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Chart_Ctrl.Name)
                            End If
                            If (TypeOf Fcontrols Is MChartControl) Then
                                MChart_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, MChart_Ctrl.Name)
                            End If
                            If (TypeOf Fcontrols Is Panel) Then
                                Panel_Ctrl = Fcontrols
                                If Not Panel_Ctrl.Tag = "Annunciator" Then
                                    Call DataRow(CreatedPages(i), 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Panel_Ctrl.Name)
                                End If

                            End If
                            If (TypeOf Fcontrols Is PictureBox) Then
                                PictureBox_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, PictureBox_Ctrl.Name)
                            End If
                            If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                Grid_TableCtrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Grid_TableCtrl.Name)
                            End If
                            If (TypeOf Fcontrols Is AnnunciatorCtrl) Then
                                Annunciator_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, Annunciator_Ctrl.Name)
                            End If
                            If (TypeOf Fcontrols Is Button_Control) Then
                                Button_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, Button_Ctrl.Name)
                            End If

                            If (TypeOf Fcontrols Is OPCWriterControl) Then
                                OPCWrite_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, OPCWrite_Ctrl.Name)
                            End If

                            If (TypeOf Fcontrols Is LogViewer) Then
                                LogCtrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, LogCtrl.Name)
                            End If

                            If (TypeOf Fcontrols Is MultiTrendCtrl) Then
                                Trender_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, Trender_Ctrl.Name)
                            End If

                            If (TypeOf Fcontrols Is Valve) Then
                                Valve_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, Valve_Ctrl.Name)
                            End If

                            If (TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor) Then
                                Switch_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, Switch_Ctrl.Name)
                            End If

                            If Not (TypeOf Fcontrols Is Button_Control Or TypeOf Fcontrols Is PictureBox Or TypeOf Fcontrols Is Label _
                                    Or TypeOf Fcontrols Is Panel Or TypeOf Fcontrols Is LogViewer _
                                    Or TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor Or TypeOf Fcontrols Is Valve _
                           Or TypeOf Fcontrols Is LevelIndicator Or TypeOf Fcontrols Is DataGridViewCtrl _
                           Or TypeOf Fcontrols Is Chart Or TypeOf Fcontrols Is LabelValue Or TypeOf Fcontrols Is AnalyzerMeter.AGauge Or TypeOf Fcontrols Is MultiTrendCtrl Or TypeOf Fcontrols Is MChartControl) Then


                                Symbol_Ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, Symbol_Ctrl.Name)
                            End If


                            If (TypeOf Fcontrols Is LevelIndicator) Then
                                LevelIndicator_ctrl = Fcontrols
                                Call DataRow(CreatedPages(i), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, LevelIndicator_ctrl.Name)
                            End If
                        Next

                    End If
                End If
            Next

            If Not String.IsNullOrEmpty(fname) Then
                ds.WriteXml(fname)
                'MyEncryptor(ds, fname)
                Me.Tag = fname
                If Server_Flag Then
                    Me.Text = "SAMA Analyzer - " & docName & "  [Server]"
                Else
                    Me.Text = "SAMA Analyzer - " & docName & "  [Client]"
                End If

                modify = False
                MsgBox("Done")

            End If


        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Main_SaveAsMenu_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'Print Menu
    Private Sub Main_PrintMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Main_PrintMenu.Click
        Dim printDialogCurrReport As PrintDialog = New PrintDialog

        printDialogCurrReport.Document = printDOCCurrReport

        If printDialogCurrReport.ShowDialog = DialogResult.OK Then
            printDOCCurrReport.Print()
        End If
    End Sub

    'Document Settings Menu
    Private Sub Main_DocumentSettingsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Main_DocumentSettingsMenu.Click
        DocumentSettings.ShowDialog()
    End Sub


    Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes("B499F4BF48242E05548D1E4C8BB26A2E")
    Dim byteIV As Byte() = System.Text.Encoding.UTF8.GetBytes(",%u'm&'CXSy/T7x;4")
    ''' <summary>
    ''' Encript the .sam File 
    ''' </summary>
    ''' <param name="D"></param>
    ''' <param name="sPath"></param>
    ''' <remarks></remarks>
    Friend Sub MyEncryptor(ByVal D As DataSet, ByVal sPath As String)
        Try
            Threading.Thread.Sleep(100)
            Dim vFile As IO.FileStream = New IO.FileStream(sPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateEncryptor(byteKey, byteIV), CryptoStreamMode.Write)
            Dim vXmlWriter As New Xml.XmlTextWriter(vCrypto, Encoding.Unicode)

            vXmlWriter.WriteStartDocument(True)
            D.WriteXml(vXmlWriter)
            vCrypto.FlushFinalBlock()

            vXmlWriter.Close()
            vCrypto.Close()
            vFile.Close()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm MyEncryptor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Decript the (.sam) File
    ''' </summary>
    ''' <param name="D"></param>
    ''' <param name="sPath"></param>
    ''' <remarks></remarks>
    Friend Sub MyDecryptor(ByVal D As DataSet, ByVal sPath As String)
        Try
            Threading.Thread.Sleep(300)
            Dim vFile As IO.FileStream = New IO.FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateDecryptor(byteKey, byteIV), CryptoStreamMode.Read)
            Dim vStreamReader As New IO.StreamReader(vCrypto, Encoding.Unicode)
            Dim vXmlReader As New Xml.XmlTextReader(vStreamReader)

            D.ReadXml(vXmlReader)

            vXmlReader.Close()
            vStreamReader.Close()
            vCrypto.Close()
            vFile.Close()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm MyDecryptor()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' save task to .sam file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proc_Task_List()
        Try
            Dim dr As DataRow
            dt = New DataTable
            'Task ScheduleList
            dt.Columns.Add(New DataColumn("Task_List", Type.GetType("System.String")))
            For i As Integer = 0 To Task_ScheduleList.Count - 1
                dr = dt.NewRow()
                dr("Task_List") = Task_ScheduleList(i)
                dt.Rows.Add(dr)
            Next

            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "Task"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm Proc_Task_List()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' SAVE e-Mail setting to .sam file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proc_EmailSetting()
        Try
            Dim dr As DataRow
            dt = New DataTable
            'Task ScheduleList
            dt.Columns.Add(New DataColumn("EMail", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("MailPassword", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("smtpServer", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("smtpport", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("ssl", Type.GetType("System.String")))

            dr = dt.NewRow()
            If EmailSetting.Count > 0 Then
                dr("EMail") = EmailSetting(0)
                dr("MailPassword") = EmailSetting(1)
                dr("smtpServer") = EmailSetting(2)
                dr("smtpport") = EmailSetting(3)
                dr("ssl") = EmailSetting(4)
            Else
                dr("EMail") = ""
                dr("MailPassword") = ""
                dr("smtpServer") = ""
                dr("smtpport") = ""
                dr("ssl") = ""
            End If

            dt.Rows.Add(dr)


            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "Email"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm Proc_EmailSetting()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub


    ''' <summary>
    ''' Save Common setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proc_CommonSetting()
        Try
            Dim dr As DataRow
            dt = New DataTable
            dt.Columns.Add(New DataColumn("Storage_Loc", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("OPC_AllowClients", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("DB_AllowClients", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("RunMode", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("ServerIP", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("RemotePushDatapath", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("RemotePullDatapath", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("OldPass", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("NewPass", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("RetypePass", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("AutoReconnect", Type.GetType("System.String")))
            dr = dt.NewRow()
            dr("Storage_Loc") = Storage_Loc
            dr("OPC_AllowClients") = blnOPC_AllowClients.ToString
            dr("DB_AllowClients") = blnDB_AllowClients.ToString
            dr("RunMode") = _runMode.ToString

            If _serverIP Is Nothing Then
                dr("ServerIP") = ""
            Else
                dr("ServerIP") = _serverIP
            End If

            If _oldPass Is Nothing Then
                dr("OldPass") = ""
            Else
                dr("OldPass") = _oldPass
            End If

            If _NewPass Is Nothing Then
                dr("NewPass") = ""
            Else
                dr("NewPass") = _NewPass
            End If
            If _RetypePass Is Nothing Then
                dr("RetypePass") = ""
            Else
                dr("RetypePass") = _RetypePass
            End If


            dr("RemotePushDatapath") = Server_PushDataPath
            dr("RemotePullDatapath") = Server_PullDataPath
            dr("AutoReconnect") = _AutoReconnect.ToString

            dt.Rows.Add(dr)
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "Settings"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm Proc_CommonSetting()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    ''' Save Page setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proc_PageS()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To CreatedPages.Count - 1
                Dim pnlObj() As Control
                pnlObj = Me.Controls.Find(CreatedPages(i), True)
                If pnlObj.Length <> 0 Then
                    If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                        dr = dt.NewRow()
                        dr("PageColor") = pnlObj(0).BackColor.ToArgb
                        dr("PageName") = pnlObj(0).Name
                        Dim nodepath As TreeNode() = TreeViewLeft.Nodes.Find(CreatedPages(i), True)
                        TreeViewLeft.SelectedNode = nodepath(0)
                        Dim path As String = TreeViewLeft.SelectedNode.FullPath
                        dr("PageNodePath") = path
                        dt.Rows.Add(dr)
                    End If
                End If
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "Pages"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm Proc_PageS()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save Supra DB Channel setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Proc_ChannelSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To channelList.Channel_Name.Count - 1
                dr = dt.NewRow()
                dr("DBChannel_RefreshTime") = channelList.DBChannel_RefreshTime(i)
                dr("Channel_Name") = channelList.Channel_Name(i)
                dr("ChannelQuery") = channelList.Channel_Query(i)
                dr("ChannelType") = channelList.Channel_Flag(i)
                dr("_DBQuery") = channelList._Query_Channel(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "Channel"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm Proc_ChannelSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save OPC Channel setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcOpcChannelSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To OPC_ChannelList_Class.OPC_Channel_Name.Count - 1
                dr = dt.NewRow()
                dr("OPC_ChannelName") = OPC_ChannelList_Class.OPC_Channel_Name(i)
                dr("OPC_OPCServer") = OPC_ChannelList_Class.OPC_ServerName(i)
                dr("OPC_Tag") = OPC_ChannelList_Class.OPC_OPCItems(i)
                dr("OPC_RefreshTime") = OPC_ChannelList_Class.OPC_RefreshTime(i)
                dr("OPC_HisLength") = OPC_ChannelList_Class.OPC_HistoryLength(i)
                dr("OPC_nnHoursHistory") = OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
                dr("OPC_IsMultiview") = OPC_ChannelList_Class.OPC_Multiview(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "OPCChannel"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcOpcChannelSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save SAMAHistorian Channel setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcSAMAHistorianChannelSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                dr = dt.NewRow()
                dr("SAMA_ReportName") = SAMAHistorian_ChannelList.ChannelReportname(i)
                dr("SAMA_Description") = SAMAHistorian_ChannelList.ChannelReportDescription(i)
                dr("SAMA_Tags") = SAMAHistorian_ChannelList.ChannelTags(i)
                dr("SAMA_Duration") = SAMAHistorian_ChannelList.ChannelDuration(i)
                dr("SAMA_Interval") = SAMAHistorian_ChannelList.ChannelInterval(i)
                dr("SAMA_XAxis") = SAMAHistorian_ChannelList.ChannelXAxis(i)
                dr("SAMA_Operation") = SAMAHistorian_ChannelList.ChannelOperations(i)

                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "SAMAHistorianChannel"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcSAMAHistorianChannelSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    ''' <summary>
    ''' Save OPCDAServers Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcOPCDAServerSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To OPCDAServersList.Configname.Count - 1
                dr = dt.NewRow()
                dr("OPCDA_ConfigName") = OPCDAServersList.Configname(i)
                dr("OPCDA_PrimaryIP") = OPCDAServersList.PrimaryIPAddress(i)
                dr("OPCDA_PrimaryPort") = OPCDAServersList.PrimaryPortNo(i)
                dr("OPCDA_SecondaryIP") = OPCDAServersList.SecondaryIPAddress(i)
                dr("OPCDA_SecondaryPort") = OPCDAServersList.SecondaryPortNo(i)
                dr("OPCDA_RefreshInterval") = OPCDAServersList.RefreshInterval(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "OPCDAServers"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcOPCDAServerSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save OPCHDAServers Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcOPCHDAServerSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To OPCHDAServersList.Configname.Count - 1
                dr = dt.NewRow()
                dr("OPCHDA_ConfigName") = OPCHDAServersList.Configname(i)
                dr("OPCHDA_PrimaryIP") = OPCHDAServersList.PrimaryIPAddress(i)
                dr("OPCHDA_PrimaryPort") = OPCHDAServersList.PrimaryPortNo(i)
                dr("OPCHDA_SecondaryIP") = OPCHDAServersList.SecondaryIPAddress(i)
                dr("OPCHDA_SecondaryPort") = OPCHDAServersList.SecondaryPortNo(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "OPCHDAServers"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcOPCHDAServerSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save OPCDA Channel setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcOPCDAChannelSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To OPCDAChannelsList.OPC_Channel_Name.Count - 1
                dr = dt.NewRow()
                dr("OPCDA_ChannelName") = OPCDAChannelsList.OPC_Channel_Name(i)
                dr("OPCDA_OPCServer") = OPCDAChannelsList.OPC_ServerName(i)
                dr("OPCDA_Tag") = OPCDAChannelsList.OPC_OPCItems(i)
                dr("OPCDA_RefreshTime") = OPCDAChannelsList.OPC_RefreshTime(i)
                dr("OPCDA_HisLength") = OPCDAChannelsList.OPC_HistoryLength(i)
                dr("OPCDA_nnHoursHistory") = OPCDAChannelsList.OPC_LastnnHourHistory(i)
                dr("OPCDA_IsMultiview") = OPCDAChannelsList.OPC_Multiview(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "OPCDAChannel"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcOPCDAChannelSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Save OPCHDA Channel setting Details to Xml File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcOPCHDAChannelSave()
        Try
            Dim dr As DataRow
            dt = New DataTable
            Call DTColumnsAdd()
            For i As Integer = 0 To OPCHDAChannelsList.OPC_Channel_Name.Count - 1
                dr = dt.NewRow()
                dr("OPCHDA_ChannelName") = OPCHDAChannelsList.OPC_Channel_Name(i)
                dr("OPCHDA_OPCServer") = OPCHDAChannelsList.OPC_ServerName(i)
                dr("OPCHDA_Tag") = OPCHDAChannelsList.OPC_OPCItems(i)
                dr("OPCHDA_Last") = OPCHDAChannelsList.OPC_Last(i)
                dr("OPCHDA_Interval") = OPCHDAChannelsList.OPC_Interval(i)
                dr("OPCHDA_RelativeTime") = OPCHDAChannelsList.OPC_RelativeTime(i)
                dr("OPCHDA_XAxis") = OPCHDAChannelsList.OPC_XAxis(i)
                dt.Rows.Add(dr)
            Next
            ds.Tables.Add(dt)
            ds.Tables(dtidx).TableName = "OPCHDAChannel"
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MainForm ProcOPCHDAChannelSave()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    ''' Past the Contols From Clipbord
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Paste_Controls()
        Try
            If (TypeOf Past_Ctrl Is AnalyzerMeter.AGauge) Then

                If blnCopy Then
                    Dim ct As AnalyzerMeter.AGauge
                    ct = Past_Ctrl
                    modify = True
                    If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                        Me.Text = Me.Text & " *"
                    End If

                    Guage_Ctrl = New AnalyzerMeter.AGauge
                    AddHandler Guage_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                    AddHandler Guage_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                    AddHandler Guage_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                    AddHandler Guage_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                    AddHandler Guage_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                    Guage_Ctrl.AutoSize = False
                    Guage_Ctrl.Name = "Guage" & _iniGuageName
                    Guage_Ctrl.Tag = "Guage"
                    Guage_Ctrl.MinimumSize = Ctrl_MinSize


                    Guage_Ctrl.AccessibleDescription = ct.AccessibleDescription
                    Guage_Ctrl.Width = ct.Width
                    Guage_Ctrl.Height = ct.Height
                    Guage_Ctrl.MinValue = ct.MinValue
                    Guage_Ctrl.MaxValue = ct.MaxValue
                    Guage_Ctrl.CapPosition = ct.CapPosition
                    Guage_Ctrl.Range_Idx = 0

                    Guage_Ctrl.RangeStartValue = ct.RangesStartValue(0)
                    Guage_Ctrl.RangeEndValue = ct.RangesEndValue(0)
                    Guage_Ctrl.RangeEnabled = True

                    Guage_Ctrl.RangeColor = ct.RangesColor(0)
                    Guage_Ctrl.Font = ct.Font
                    Guage_Ctrl.Range_Idx = 1
                    Guage_Ctrl.RangeStartValue = ct.RangesStartValue(1)
                    Guage_Ctrl.RangeEndValue = ct.RangesEndValue(1)
                    Guage_Ctrl.RangeColor = ct.RangesColor(1)
                    Guage_Ctrl.RangeEnabled = True

                    Guage_Ctrl.Range_Idx = 2
                    Guage_Ctrl.RangeEndValue = ct.RangesEndValue(2)
                    Guage_Ctrl.RangeStartValue = ct.RangesStartValue(2)
                    Guage_Ctrl.ScaleLinesMajorStepValue = ct.ScaleLinesMajorStepValue
                    Guage_Ctrl.RangeColor = ct.RangesColor(2)
                    Guage_Ctrl.RangeEnabled = True
                    Guage_Ctrl.Location = Cursor.Position
                    Guage_Ctrl.Center = ct.Center
                    Guage_Ctrl.NeedleWidth = ct.NeedleWidth
                    Guage_Ctrl.NeedleColor1 = ct.NeedleColor1
                    Guage_Ctrl.NeedleColor2 = ct.NeedleColor2
                    Guage_Ctrl.NeedleType = ct.NeedleType
                    Guage_Ctrl.BaseArcSweep = ct.BaseArcSweep
                    Guage_Ctrl.BaseArcStart = ct.BaseArcStart


                    Guage_Ctrl.BaseArcRadius = ct.BaseArcRadius
                    Guage_Ctrl.BaseArcColor = ct.BaseArcColor
                    Page_Ctrl.Controls.Add(Guage_Ctrl) 'Add GuageControls in panel
                    Call Border(Guage_Ctrl) 'Create Border
                    _iniGuageName += 1

                End If
                If blnCut Then
                    Guage_Ctrl = Past_Ctrl
                    Guage_Ctrl.Location = Cursor.Position
                    Page_Ctrl.Controls.Add(Guage_Ctrl)
                End If
            ElseIf (TypeOf Past_Ctrl Is LabelValue) Then
                If Past_Ctrl.Tag = "displayValue" Then

                    If blnCopy Then
                        Dim ct As LabelValue
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        ValueLabel_Ctrl = New LabelValue
                        ValueLabel_Ctrl.MinimumSize = New Size(20, 12)
                        ValueLabel_Ctrl.Tag = "displayValue"
                        ValueLabel_Ctrl.Text = ct.Text
                        ValueLabel_Ctrl.Font = ct.Font
                        ValueLabel_Ctrl.AccessibleDescription = ct.AccessibleDescription
                        ValueLabel_Ctrl.Name = "ValueLabel" & _iniValuelabelName
                        AddHandler ValueLabel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler ValueLabel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler ValueLabel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler ValueLabel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler ValueLabel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        ValueLabel_Ctrl.Location = Cursor.Position

                        ValueLabel_Ctrl.ForeColor = ct.ForeColor
                        ValueLabel_Ctrl.BackColor = ct.BackColor
                        ValueLabel_Ctrl.BorderStyle = ct.BorderStyle
                        ValueLabel_Ctrl.Width = ct.Width
                        ValueLabel_Ctrl.Height = ct.Height

                        ValueLabel_Ctrl._ThresholdValue.Clear()
                        ValueLabel_Ctrl._THForeColor.Clear()
                        ValueLabel_Ctrl._THBackColor.Clear()

                        If ct._ThresholdValue.Count > 0 Then
                            ValueLabel_Ctrl._ThresholdValue.AddRange(ct._ThresholdValue)
                            ValueLabel_Ctrl._THForeColor.AddRange(ct._THForeColor)
                            ValueLabel_Ctrl._THBackColor.AddRange(ct._THBackColor)
                        End If





                        ValueLabel_Ctrl.BringToFront()
                        Page_Ctrl.Controls.Add(ValueLabel_Ctrl) 'Add GuageControls in panel
                        Call Border(ValueLabel_Ctrl) 'Create Border
                        _iniValuelabelName += 1
                    End If
                    If blnCut Then
                        ValueLabel_Ctrl = Past_Ctrl
                        ValueLabel_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(ValueLabel_Ctrl)
                    End If
                End If
            ElseIf (TypeOf Past_Ctrl Is Label) Then
                If Past_Ctrl.Tag = "Text" Then
                    If blnCopy Then
                        Dim ct As Label
                        'ct = DirectCast(Past_Ctrl, Label)
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        Label_Ctrl = New Label
                        Label_Ctrl.MinimumSize = New Size(20, 12)
                        Label_Ctrl.Tag = "Text"
                        Label_Ctrl.Name = "Label" & _iniLabelName
                        Label_Ctrl.Text = ct.Text
                        Label_Ctrl.Font = ct.Font

                        AddHandler Label_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler Label_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler Label_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler Label_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler Label_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        Label_Ctrl.Location = Cursor.Position


                        Label_Ctrl.ForeColor = ct.ForeColor
                        Label_Ctrl.BackColor = ct.BackColor

                        'Dim g As Graphics = Label_Ctrl.CreateGraphics() ' COMMENTED BY CODEIT.RIGHT
                        Label_Ctrl.Width = ct.Width
                        Label_Ctrl.Height = ct.Height
                        Label_Ctrl.BringToFront()
                        Label_Ctrl.BorderStyle = ct.BorderStyle

                        Page_Ctrl.Controls.Add(Label_Ctrl) 'Add GuageControls in panel
                        Call Border(Label_Ctrl) 'Create Border
                        _iniLabelName += 1
                    End If
                    If blnCut Then
                        Label_Ctrl = Past_Ctrl
                        Label_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Label_Ctrl)
                    End If

                End If

            ElseIf (TypeOf Past_Ctrl Is ChartControl) Then
                If blnCopy Then
                    modify = True
                    If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                        Me.Text = Me.Text & " *"
                    End If

                    Dim chart_Obj As ChartControl
                    chart_Obj = Past_Ctrl

                    Chart_Ctrl = New ChartControl
                    Chart_Ctrl.Name = "Chart" & _iniChartName
                    Chart_Ctrl.MinimumSize = Ctrl_MinSize



                    AddHandler Chart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                    AddHandler Chart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                    AddHandler Chart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                    AddHandler Chart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                    AddHandler Chart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                    Chart_Ctrl.AutoSize = False
                    Chart_Ctrl.Tag = "Chart"
                    Chart_Ctrl.Width = chart_Obj.Width
                    Chart_Ctrl.Height = chart_Obj.Height
                    Chart_Ctrl.Location = Cursor.Position
                    Dim genChartSeries As New Series
                    Dim genChartArea As New ChartArea
                    Chart_Ctrl.BackColor = chart_Obj.BackColor
                    genChartArea.BackColor = chart_Obj.BackColor
                    genChartArea.Axes(0).LineColor = chart_Obj.ChartAreas(0).Axes(0).LineColor
                    genChartArea.Axes(1).LineColor = chart_Obj.ChartAreas(0).Axes(1).LineColor
                    genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
                    genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines

                    genChartArea.AxisX.LabelStyle.Font = chart_Obj.ChartAreas(0).AxisX.LabelStyle.Font
                    genChartArea.AxisY.LabelStyle.Font = chart_Obj.ChartAreas(0).AxisY.LabelStyle.Font

                    genChartArea.Axes(0).LabelStyle.ForeColor = chart_Obj.ChartAreas(0).Axes(0).LabelStyle.ForeColor
                    genChartArea.Axes(1).LabelStyle.ForeColor = chart_Obj.ChartAreas(0).Axes(1).LabelStyle.ForeColor

                    genChartArea.Axes(0).MajorTickMark.LineColor = chart_Obj.ChartAreas(0).Axes(0).MajorTickMark.LineColor
                    genChartArea.Axes(1).MajorTickMark.LineColor = chart_Obj.ChartAreas(0).Axes(0).MajorTickMark.LineColor
                    genChartArea.Axes(0).Title = chart_Obj.ChartAreas(0).Axes(0).Title
                    genChartArea.Axes(1).Title = chart_Obj.ChartAreas(0).Axes(1).Title

                    genChartArea.Axes(0).TitleForeColor = chart_Obj.ChartAreas(0).Axes(0).TitleForeColor
                    genChartArea.Axes(1).TitleForeColor = chart_Obj.ChartAreas(0).Axes(0).TitleForeColor

                    genChartArea.Axes(0).MajorGrid.LineColor = chart_Obj.ChartAreas(0).Axes(0).MajorGrid.LineColor
                    genChartArea.Axes(1).MajorGrid.LineColor = chart_Obj.ChartAreas(0).Axes(0).MajorGrid.LineColor

                    genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
                    genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

                    genChartArea.AxisY.Tag = chart_Obj.ChartAreas(0).AxisY.Tag

                    If chart_Obj.ChartAreas(0).Area3DStyle.Enable3D = True Then
                        genChartArea.Area3DStyle.Enable3D = True
                    Else
                        genChartArea.Area3DStyle.Enable3D = False
                    End If




                    'genChartArea.AxisX.Interval = 1
                    'genChartArea.AxisX.LabelStyle.Angle=-45

                    Chart_Ctrl.BorderlineColor = Color.Black
                    Chart_Ctrl.BorderlineWidth = 1
                    Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid
                    Chart_Ctrl.BorderSkin.SkinStyle = chart_Obj.BorderSkin.SkinStyle
                    Chart_Ctrl.BorderSkin.PageColor = chart_Obj.BorderSkin.PageColor

                    For i As Integer = 0 To chart_Obj.Series.Count - 1
                        genChartSeries = New Series

                        genChartSeries.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
                        genChartSeries.XValueType = ChartValueType.String 'X Value type

                        genChartSeries.Name = chart_Obj.Series(i).Name
                        genChartSeries.BorderWidth = chart_Obj.Series(i).BorderWidth

                        genChartSeries.MarkerColor = chart_Obj.Series(i).MarkerColor
                        genChartSeries.MarkerSize = chart_Obj.Series(i).MarkerSize
                        genChartSeries.MarkerStyle = chart_Obj.Series(i).MarkerStyle
                        genChartSeries.ChartType = chart_Obj.Series(i).ChartType
                        genChartSeries.BorderDashStyle = chart_Obj.Series(i).BorderDashStyle
                        genChartSeries.Color = chart_Obj.Series(i).Color
                        If chart_Obj.Series(i).IsValueShownAsLabel Then
                            genChartSeries.IsValueShownAsLabel = True
                        Else
                            genChartSeries.IsValueShownAsLabel = False
                        End If
                        genChartSeries.Font = chart_Obj.Series(i).Font
                        genChartSeries.LabelForeColor = chart_Obj.Series(i).LabelForeColor
                        If chart_Obj.Series(i).Points.Count > 0 Then
                            For j As Integer = 0 To chart_Obj.Series(i).Points.Count - 1
                                Dim dp As New DataPoint
                                dp = chart_Obj.Series(i).Points(j)
                                genChartSeries.Points.AddXY(dp.AxisLabel, dp.YValues(0))
                            Next
                        End If
                        genChartSeries.YValueMembers = chart_Obj.Series(i).YValueMembers
                        Chart_Ctrl.Legends.Add(genChartSeries.Name)
                        Chart_Ctrl.Series.Add(genChartSeries)



                        Dim Se_THClass As New ChartSeriesTHValue 'ChartSeriesTHValue Class 
                        If chart_Obj.Series_TH_Data.Count > 0 AndAlso chart_Obj.Series_TH_Data(i).ThresholdValue.Count > 0 Then
                            Se_THClass.ThresholdValue.AddRange(chart_Obj.Series_TH_Data(i).ThresholdValue.ToArray)
                            Se_THClass.THPointsColor.AddRange(chart_Obj.Series_TH_Data(i).THPointsColor.ToArray)
                        End If

                        Chart_Ctrl.Series_TH_Data.Add(Se_THClass)



                    Next


                    If chart_Obj.Legends(0).Position.Width = 0 Then
                        Chart_Ctrl.Legends(0).Position.Width = 0
                        Chart_Ctrl.Legends(0).Position.Height = 0
                    Else
                        Chart_Ctrl.Legends(0).Enabled = True
                        Chart_Ctrl.Legends(0).Alignment = StringAlignment.Far
                        Chart_Ctrl.Legends(0).Position.Width = 100
                        Chart_Ctrl.Legends(0).Position.Height = 10
                        Chart_Ctrl.Legends(0).Position.X = 70
                        Chart_Ctrl.Legends(0).Position.Y = 0

                        Chart_Ctrl.Legends(0).ForeColor = chart_Obj.Legends(0).ForeColor
                        Chart_Ctrl.Legends(0).BackColor = Color.Transparent
                    End If


                    Chart_Ctrl.Font = chart_Obj.Font


                    Chart_Ctrl.ChartAreas.Add(genChartArea)
                    Chart_Ctrl.Titles.Add(chart_Obj.Titles(0).Text)
                    Chart_Ctrl.Titles(0).ForeColor = chart_Obj.Titles(0).ForeColor
                    Chart_Ctrl.Titles(0).Font = chart_Obj.Titles(0).Font
                    Page_Ctrl.Controls.Add(Chart_Ctrl)

                    Chart_Ctrl.BringToFront()
                    'Selected_Ctrl = Chart_Ctrl
                    _iniChartName += 1
                End If
                If blnCut Then
                    Chart_Ctrl = Past_Ctrl
                    Chart_Ctrl.Location = Cursor.Position
                    Page_Ctrl.Controls.Add(Chart_Ctrl)
                End If
            ElseIf (TypeOf Past_Ctrl Is Panel) And Past_Ctrl.Tag <> "Annunciator" Then

                If Past_Ctrl.Tag = "Panel" Then
                    If blnCopy Then
                        Dim ct As Panel
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        Panel_Ctrl = New Panel
                        Panel_Ctrl.MinimumSize = Ctrl_MinSize
                        Panel_Ctrl.Name = "Panel" & _iniPanelName
                        Panel_Ctrl.Tag = "Panel"

                        Panel_Ctrl.BorderStyle = BorderStyle.None

                        AddHandler Panel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler Panel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler Panel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler Panel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler Panel_Ctrl.Paint, AddressOf panel_Ctrl_Paint
                        AddHandler Panel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        Panel_Ctrl.AccessibleDescription = ct.AccessibleDescription
                        Panel_Ctrl.Location = Cursor.Position
                        Panel_Ctrl.Width = ct.Width
                        Panel_Ctrl.Height = ct.Height
                        Panel_Ctrl.BackColor = ct.BackColor

                        Page_Ctrl.Controls.Add(Panel_Ctrl)

                        'Selected_Ctrl = Panel_Ctrl
                        Call Border(Panel_Ctrl) 'Create Border
                        Panel_Ctrl.SendToBack()
                        _iniPanelName += 1
                    End If
                    If blnCut Then
                        Panel_Ctrl = Past_Ctrl
                        Panel_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Panel_Ctrl)
                    End If

                End If
            ElseIf (TypeOf Past_Ctrl Is PictureBox) Then
                If Past_Ctrl.Tag = "PicBox" Then
                    If blnCopy Then
                        Dim ct As PictureBox
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        PictureBox_Ctrl = New PictureBox
                        PictureBox_Ctrl.MinimumSize = Ctrl_MinSize

                        PictureBox_Ctrl.Name = "Pic" & _iniPicName
                        PictureBox_Ctrl.Tag = "PicBox"


                        AddHandler PictureBox_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler PictureBox_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler PictureBox_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler PictureBox_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler PictureBox_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave


                        PictureBox_Ctrl.Location = Cursor.Position
                        PictureBox_Ctrl.Width = ct.Width
                        PictureBox_Ctrl.Height = ct.Height
                        PictureBox_Ctrl.BackgroundImage = ct.BackgroundImage
                        PictureBox_Ctrl.BackColor = ct.BackColor
                        PictureBox_Ctrl.BackgroundImageLayout = ct.BackgroundImageLayout
                        ' PictureBox_Ctrl.BorderStyle = BorderStyle.FixedSingle
                        Page_Ctrl.Controls.Add(PictureBox_Ctrl)
                        PictureBox_Ctrl.AccessibleDescription = "(None)"
                        'Selected_Ctrl = PictureBox_Ctrl
                        Call Border(PictureBox_Ctrl) 'Create Border
                        PictureBox_Ctrl.SendToBack()
                        _iniPicName += 1
                    End If
                    If blnCut Then
                        PictureBox_Ctrl = Past_Ctrl
                        PictureBox_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(PictureBox_Ctrl)
                    End If

                End If
                'Grid Control
            ElseIf (TypeOf Past_Ctrl Is DataGridViewCtrl) Then
                If Past_Ctrl.Tag = "Grid" Then
                    If blnCopy Then
                        Dim ct As DataGridViewCtrl
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        Grid_TableCtrl = New DataGridViewCtrl
                        Grid_TableCtrl.MinimumSize = GridCtrl_MinSize

                        Grid_TableCtrl.Name = "Table" & _iniTableName
                        Grid_TableCtrl.AccessibleDescription = ct.AccessibleDescription
                        AddHandler Grid_TableCtrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler Grid_TableCtrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler Grid_TableCtrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler Grid_TableCtrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler Grid_TableCtrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        Grid_TableCtrl.AutoSize = False
                        Grid_TableCtrl.Tag = "Grid"
                        Grid_TableCtrl.Width = ct.Width
                        Grid_TableCtrl.Height = ct.Height
                        Grid_TableCtrl.Location = Cursor.Position
                        Grid_TableCtrl.BackColor = ct.BackColor
                        Grid_TableCtrl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                        Grid_TableCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                        Grid_TableCtrl.RowHeadersVisible = False


                        Grid_TableCtrl.AllowUserToAddRows = False
                        Grid_TableCtrl.ReadOnly = True

                        Grid_TableCtrl.RowsDefaultCellStyle.BackColor = ct.RowsDefaultCellStyle.BackColor
                        Grid_TableCtrl.RowsDefaultCellStyle.ForeColor = ct.RowsDefaultCellStyle.ForeColor
                        Grid_TableCtrl.RowsDefaultCellStyle.SelectionBackColor = ct.RowsDefaultCellStyle.SelectionBackColor
                        Grid_TableCtrl.RowsDefaultCellStyle.SelectionForeColor = ct.RowsDefaultCellStyle.SelectionForeColor

                        Grid_TableCtrl.AlternatingRowsDefaultCellStyle.BackColor = ct.AlternatingRowsDefaultCellStyle.BackColor
                        Grid_TableCtrl.AlternatingRowsDefaultCellStyle.ForeColor = ct.AlternatingRowsDefaultCellStyle.ForeColor
                        Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionBackColor = ct.AlternatingRowsDefaultCellStyle.SelectionBackColor
                        Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionForeColor = ct.AlternatingRowsDefaultCellStyle.SelectionForeColor

                        'Font
                        Grid_TableCtrl.RowsDefaultCellStyle.Font = ct.RowsDefaultCellStyle.Font
                        Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = ct.AlternatingRowsDefaultCellStyle.Font

                        Grid_TableCtrl._ThresholdValue.Clear()
                        Grid_TableCtrl._THForeColor.Clear()
                        Grid_TableCtrl._THBackColor.Clear()
                        Grid_TableCtrl._THFont.Clear()
                        For i As Integer = 0 To ct._ThresholdValue.Count - 1
                            Grid_TableCtrl._ThresholdValue.AddRange(ct._ThresholdValue)
                            Grid_TableCtrl._THForeColor.AddRange(ct._THForeColor)
                            Grid_TableCtrl._THBackColor.AddRange(ct._THBackColor)
                            Grid_TableCtrl._THFont.AddRange(ct._THFont)
                        Next


                        Grid_TableCtrl.Font = ct.Font
                        Page_Ctrl.Controls.Add(Grid_TableCtrl) 'Add Grid_TableCtrl in panel

                        Grid_TableCtrl.BringToFront()
                        _iniTableName += 1
                    End If
                    If blnCut Then
                        Grid_TableCtrl = Past_Ctrl
                        Grid_TableCtrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Grid_TableCtrl)
                    End If

                End If
            ElseIf (TypeOf Past_Ctrl Is AnnunciatorCtrl) Then
                If Past_Ctrl.Tag = "Annunciator" Then
                    If blnCopy Then
                        Dim ct As AnnunciatorCtrl
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If

                        Annunciator_Ctrl = New AnnunciatorCtrl
                        Annunciator_Ctrl.MinimumSize = Annunciator_Ctrl_MinSize

                        Annunciator_Ctrl.Name = "Annunciator" & _iniTableName
                        Annunciator_Ctrl.AccessibleDescription = ct.AccessibleDescription
                        AddHandler Annunciator_Ctrl.MouseClick, (AddressOf Ctrl_Click)
                        AddHandler Annunciator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler Annunciator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler Annunciator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler Annunciator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        Annunciator_Ctrl.AutoSize = False
                        Annunciator_Ctrl.Tag = "Annunciator"
                        Annunciator_Ctrl.Width = ct.Width
                        Annunciator_Ctrl.Height = ct.Height
                        Annunciator_Ctrl.Location = Cursor.Position
                        Annunciator_Ctrl.BackColor = ct.BackColor

                        Annunciator_Ctrl.Font = ct.Font
                        Page_Ctrl.Controls.Add(Annunciator_Ctrl)

                        Dim indx = Me.channelList.Channel_Name.IndexOf(ct.AccessibleDescription) 'SAMAHistorian_ChannelList.ChannelReportname.IndexOf(PageTreeView.SelectedNode.Text)
                        Dim Qval = Nothing
                        If Me.channelList._Query_Channel.Count > 0 Then
                            Qval = Me.channelList._Query_Channel(indx).Split(",")
                        End If


                        Dim CtrlAnn() As Control = Me.Controls.Find(Annunciator_Ctrl.Name, True)
                        CtrlAnn(0).Controls.Clear()
                        If Qval IsNot Nothing Then
                            For k = 0 To Qval.Length - 1
                                Dim TagNo = Qval(k)
                                Dim Button = New Button_Control
                                Button.Size = New Size(118, 50)
                                Button.BackColor = Color.Gainsboro
                                Button.Tag = TagNo.ToString
                                Button.Text = TagNo.ToString
                                Button.Name = TagNo.ToString
                                CtrlAnn(0).Controls.Add(Button)
                            Next
                        End If



                        'Add Grid_TableCtrl in panel

                        Annunciator_Ctrl.BringToFront()
                        _iniTableName += 1
                    End If
                    If blnCut Then
                        Annunciator_Ctrl = Past_Ctrl
                        Annunciator_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Annunciator_Ctrl)
                    End If
                    ' AnnunciatorPropertiesForm.AnnunciatorFlow_Properties(Me.Annunciator_Ctrl)
                End If

            ElseIf (TypeOf Past_Ctrl Is Button_Control) Then
                If Past_Ctrl.Tag = "Button" Then
                    If blnCopy Then
                        Dim ct As Button_Control
                        ct = Past_Ctrl
                        modify = True
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If
                        Button_Ctrl = New Button_Control
                        Button_Ctrl.Name = "Button" & _iniButtonName
                        Button_Ctrl.Tag = "Button"
                        Button_Ctrl.Text = ct.Text
                        Button_Ctrl.MinimumSize = Ctrl_MinSize
                        Button_Ctrl.ForeColor = ct.ForeColor
                        Button_Ctrl.BackColor = ct.BackColor
                        Button_Ctrl.Action_Ctrl = ct.Action_Ctrl
                        Button_Ctrl.Action_Type = ct.Action_Type
                        Button_Ctrl.Size = ct.Size
                        Button_Ctrl.Font = ct.Font
                        AddHandler Button_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler Button_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler Button_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler Button_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                        AddHandler Button_Ctrl.Click, AddressOf ButtonCtrl_Click

                        Button_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Button_Ctrl)
                        Button_Ctrl.BringToFront()
                        _iniButtonName += 1
                    End If
                    If blnCut Then
                        Button_Ctrl = Past_Ctrl
                        Button_Ctrl.Location = Cursor.Position
                        Page_Ctrl.Controls.Add(Button_Ctrl)
                    End If

                End If
            ElseIf (TypeOf Past_Ctrl Is LogViewer) Then
                If blnCut Then
                    LogCtrl = Past_Ctrl
                    LogCtrl.Location = Cursor.Position
                    Page_Ctrl.Controls.Add(LogCtrl)
                End If
            Else
                'Symbols

                If blnCut Then
                    modify = True
                    If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                        Me.Text = Me.Text & " *"
                    End If
                    Past_Ctrl.Location = Cursor.Position
                    Page_Ctrl.Controls.Add(Past_Ctrl)
                End If
                If blnCopy Then
                    modify = True
                    If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                        Me.Text = Me.Text & " *"
                    End If


                    Select Case Past_Ctrl.GetType().Name
                        Case "LevelIndicator"

                            LevelIndicator_ctrl = New LevelIndicator()
                            Dim ctrl As New LevelIndicator()

                            ctrl = Past_Ctrl
                            LevelIndicator_ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            LevelIndicator_ctrl.Name = "Indicator" & _iniindicatorName

                            AddHandler LevelIndicator_ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler LevelIndicator_ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler LevelIndicator_ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler LevelIndicator_ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler LevelIndicator_ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            Page_Ctrl.Controls.Add(LevelIndicator_ctrl)
                            LevelIndicator_ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, LevelIndicator_ctrl.Bounds.Width, LevelIndicator_ctrl.Bounds.Height)
                            _iniindicatorName += 1
                            LevelIndicator_ctrl.Show()


                        Case "LineElbow"

                            Line_Ctrl = New LineElbow()
                            Dim ctrl As New LineElbow()

                            ctrl = Past_Ctrl
                            Line_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Line_Ctrl.Name = "LineElbow" & _iniLineName
                            AddHandler Line_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Line_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Line_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Line_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Line_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Line_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Line_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Line_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Line_Ctrl)
                            Line_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Line_Ctrl.Bounds.Width, Line_Ctrl.Bounds.Height)
                            _iniLineName += 1
                            Line_Ctrl.Show()
                        Case "Valve"

                            Valve_Ctrl = New Valve()
                            Dim ctrl As New Valve()

                            ctrl = Past_Ctrl
                            Valve_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Valve_Ctrl.Name = "Valve" & _iniValveName
                            AddHandler Valve_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Valve_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Valve_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Valve_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Valve_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Valve_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Valve_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Valve_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Valve_Ctrl)
                            Valve_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Valve_Ctrl.Bounds.Width, Valve_Ctrl.Bounds.Height)
                            _iniValveName += 1
                            Valve_Ctrl.Show()
                        Case "Circuit_Breaker"

                            CircuitBreaker_Ctrl = New Circuit_Breaker()
                            Dim ctrl As New Circuit_Breaker()

                            ctrl = Past_Ctrl
                            CircuitBreaker_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            CircuitBreaker_Ctrl.Name = "CircuitBreaker" & _symCircuitBreakerKName

                            AddHandler CircuitBreaker_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler CircuitBreaker_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler CircuitBreaker_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler CircuitBreaker_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler CircuitBreaker_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                CircuitBreaker_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                CircuitBreaker_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                CircuitBreaker_Ctrl._THColor.Add(ctrl._THColor(i))
                                CircuitBreaker_Ctrl._THState.Add(ctrl._THState(i))
                            Next


                            Page_Ctrl.Controls.Add(CircuitBreaker_Ctrl)
                            CircuitBreaker_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, CircuitBreaker_Ctrl.Bounds.Width, CircuitBreaker_Ctrl.Bounds.Height)
                            _symCircuitBreakerKName += 1
                            CircuitBreaker_Ctrl.Show()
                        Case "ManualContactor"

                            ManualContactor_Ctrl = New ManualContactor()
                            Dim ctrl As New ManualContactor()

                            ctrl = Past_Ctrl
                            ManualContactor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            ManualContactor_Ctrl.Name = "ManualContactor" & _symManualContactorName
                            AddHandler ManualContactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler ManualContactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler ManualContactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler ManualContactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler ManualContactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                ManualContactor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                ManualContactor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                ManualContactor_Ctrl._THColor.Add(ctrl._THColor(i))
                                ManualContactor_Ctrl._THState.Add(ctrl._THState(i))
                            Next


                            Page_Ctrl.Controls.Add(ManualContactor_Ctrl)
                            ManualContactor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, ManualContactor_Ctrl.Bounds.Width, ManualContactor_Ctrl.Bounds.Height)
                            _symManualContactorName += 1
                            ManualContactor_Ctrl.Show()

                        Case "Distillation_Tower"

                            DistillationTower_Ctrl = New Distillation_Tower()
                            Dim ctrl As New Distillation_Tower()

                            ctrl = Past_Ctrl
                            DistillationTower_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            DistillationTower_Ctrl.Name = "DistillationTower" & _symDistillationTowerName
                            AddHandler DistillationTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler DistillationTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler DistillationTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler DistillationTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler DistillationTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                DistillationTower_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                DistillationTower_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                DistillationTower_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(DistillationTower_Ctrl)
                            DistillationTower_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, DistillationTower_Ctrl.Bounds.Width, DistillationTower_Ctrl.Bounds.Height)
                            _symDistillationTowerName += 1
                            DistillationTower_Ctrl.Show()

                        Case "Jacketed_Vessel"

                            JacketedVessel_Ctrl = New Jacketed_Vessel()
                            Dim ctrl As New Jacketed_Vessel()

                            ctrl = Past_Ctrl
                            JacketedVessel_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            JacketedVessel_Ctrl.Name = "JacketedVessel" & _symJacketedVesselName

                            AddHandler JacketedVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler JacketedVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler JacketedVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler JacketedVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler JacketedVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                JacketedVessel_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                JacketedVessel_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                JacketedVessel_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(JacketedVessel_Ctrl)
                            JacketedVessel_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, JacketedVessel_Ctrl.Bounds.Width, JacketedVessel_Ctrl.Bounds.Height)
                            _symJacketedVesselName += 1
                            JacketedVessel_Ctrl.Show()
                        Case "Reactor"

                            Reactor_Ctrl = New Reactor()
                            Dim ctrl As New Reactor()

                            ctrl = Past_Ctrl
                            Reactor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Reactor_Ctrl.Name = "Reactor" & _symReactorName
                            AddHandler Reactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Reactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Reactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Reactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Reactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Reactor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Reactor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Reactor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Reactor_Ctrl)
                            Reactor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Reactor_Ctrl.Bounds.Width, Reactor_Ctrl.Bounds.Height)
                            _symReactorName += 1
                            Reactor_Ctrl.Show()
                        Case "Vessel"

                            Vessel_Ctrl = New Vessel()
                            Dim ctrl As New Vessel()

                            ctrl = Past_Ctrl
                            Vessel_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Vessel_Ctrl.Name = "Vessel" & _symVesselName
                            AddHandler Vessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Vessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Vessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Vessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Vessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Vessel_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Vessel_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Vessel_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Vessel_Ctrl)
                            Vessel_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Vessel_Ctrl.Bounds.Width, Vessel_Ctrl.Bounds.Height)
                            _symVesselName += 1
                            Vessel_Ctrl.Show()

                        Case "Admospheric_Tank"

                            AdmosphericTank_Ctrl = New Admospheric_Tank()
                            Dim ctrl As New Admospheric_Tank()

                            ctrl = Past_Ctrl
                            AdmosphericTank_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            AdmosphericTank_Ctrl.Name = "AtmosphericTank" & _symATNKName
                            AddHandler AdmosphericTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler AdmosphericTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler AdmosphericTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler AdmosphericTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler AdmosphericTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                AdmosphericTank_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                AdmosphericTank_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                AdmosphericTank_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(AdmosphericTank_Ctrl)
                            AdmosphericTank_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, AdmosphericTank_Ctrl.Bounds.Width, AdmosphericTank_Ctrl.Bounds.Height)
                            _symATNKName += 1
                            AdmosphericTank_Ctrl.Show()


                        Case "Bin"

                            Bin_Ctrl = New Bin()
                            Dim ctrl As New Bin()

                            ctrl = Past_Ctrl
                            Bin_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Bin_Ctrl.Name = "Bin" & _symBinName
                            AddHandler Bin_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Bin_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Bin_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Bin_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Bin_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Bin_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Bin_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Bin_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Bin_Ctrl)
                            Bin_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Bin_Ctrl.Bounds.Width, Bin_Ctrl.Bounds.Height)
                            _symBinName += 1
                            Bin_Ctrl.Show()

                        Case "FloatingRoof_Tank"

                            FloatingRoofTank_Ctrl = New FloatingRoof_Tank()
                            Dim ctrl As New FloatingRoof_Tank()

                            ctrl = Past_Ctrl
                            FloatingRoofTank_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            FloatingRoofTank_Ctrl.Name = "FloatingRoofTank" & _symFloatingRoofTankName
                            AddHandler FloatingRoofTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler FloatingRoofTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler FloatingRoofTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler FloatingRoofTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler FloatingRoofTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                FloatingRoofTank_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                FloatingRoofTank_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                FloatingRoofTank_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(FloatingRoofTank_Ctrl)
                            FloatingRoofTank_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, FloatingRoofTank_Ctrl.Bounds.Width, FloatingRoofTank_Ctrl.Bounds.Height)
                            _symFloatingRoofTankName += 1
                            FloatingRoofTank_Ctrl.Show()

                        Case "GAS_Holder"
                            GasHolder_Ctrl = New GAS_Holder()
                            Dim ctrl As New GAS_Holder()

                            ctrl = Past_Ctrl
                            'GasHolder_Ctrl=ControlFactory.CloneCtrl(Ctrl)
                            GasHolder_Ctrl.Tag = ctrl.Tag
                            GasHolder_Ctrl.BackColor = ctrl.BackColor
                            GasHolder_Ctrl.ForeColor = ctrl.ForeColor
                            GasHolder_Ctrl.font = ctrl.Font
                            GasHolder_Ctrl.Description = ctrl.Description
                            GasHolder_Ctrl.Gradient_Color1 = ctrl.Gradient_Color1
                            GasHolder_Ctrl.Gradient_Color2 = ctrl.Gradient_Color2
                            GasHolder_Ctrl.D_Color1 = ctrl.D_Color1



                            GasHolder_Ctrl.Name = "GasHolder" & _symGasHolderName
                            AddHandler GasHolder_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler GasHolder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler GasHolder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler GasHolder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler GasHolder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                GasHolder_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                GasHolder_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                GasHolder_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(GasHolder_Ctrl)
                            GasHolder_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, GasHolder_Ctrl.Bounds.Width, GasHolder_Ctrl.Bounds.Height)
                            _symGasHolderName += 1
                            GasHolder_Ctrl.Show()

                        Case "PressureStorage_Vessel"

                            PressureStorageVessel_Ctrl = New PressureStorage_Vessel()
                            Dim ctrl As New PressureStorage_Vessel()

                            ctrl = Past_Ctrl
                            PressureStorageVessel_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            PressureStorageVessel_Ctrl.Name = "PressureStorageVessel" & _symPressureStorageVesselName
                            AddHandler PressureStorageVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler PressureStorageVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler PressureStorageVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler PressureStorageVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler PressureStorageVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                PressureStorageVessel_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                PressureStorageVessel_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                PressureStorageVessel_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(PressureStorageVessel_Ctrl)
                            PressureStorageVessel_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, PressureStorageVessel_Ctrl.Bounds.Width, PressureStorageVessel_Ctrl.Bounds.Height)
                            _symPressureStorageVesselName += 1
                            PressureStorageVessel_Ctrl.Show()

                        Case "Weigh_Hopper"

                            WeighHopper_Ctrl = New Weigh_Hopper()
                            Dim ctrl As New Weigh_Hopper()

                            ctrl = Past_Ctrl
                            WeighHopper_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            WeighHopper_Ctrl.Name = "WeighHopper" & _symWeighHopperName

                            AddHandler WeighHopper_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler WeighHopper_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler WeighHopper_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler WeighHopper_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler WeighHopper_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                WeighHopper_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                WeighHopper_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                WeighHopper_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(WeighHopper_Ctrl)
                            WeighHopper_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, WeighHopper_Ctrl.Bounds.Width, WeighHopper_Ctrl.Bounds.Height)
                            _symWeighHopperName += 1
                            WeighHopper_Ctrl.Show()

                        Case "Delta_Connection"

                            DeltaConnection_Ctrl = New Delta_Connection()
                            Dim ctrl As New Delta_Connection()

                            ctrl = Past_Ctrl
                            DeltaConnection_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            DeltaConnection_Ctrl.Name = "DeltaConnection" & _symDeltaConnectionName
                            AddHandler DeltaConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler DeltaConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler DeltaConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler DeltaConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler DeltaConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                DeltaConnection_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                DeltaConnection_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                DeltaConnection_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(DeltaConnection_Ctrl)
                            DeltaConnection_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, DeltaConnection_Ctrl.Bounds.Width, DeltaConnection_Ctrl.Bounds.Height)
                            _symDeltaConnectionName += 1
                            DeltaConnection_Ctrl.Show()


                        Case "Fuse"

                            Fuse_Ctrl = New Fuse()
                            Dim ctrl As New Fuse()

                            ctrl = Past_Ctrl
                            Fuse_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Fuse_Ctrl.Name = "Fuse" & _symFuseName

                            AddHandler Fuse_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Fuse_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Fuse_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Fuse_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Fuse_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Fuse_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Fuse_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Fuse_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Fuse_Ctrl)
                            Fuse_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Fuse_Ctrl.Bounds.Width, Fuse_Ctrl.Bounds.Height)
                            _symFuseName += 1
                            Fuse_Ctrl.Show()


                        Case "Motor"

                            Motor_Ctrl = New Motor()
                            Dim ctrl As New Motor()

                            ctrl = Past_Ctrl
                            Motor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Motor_Ctrl.Name = "Motor" & _symMotorName
                            AddHandler Motor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Motor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Motor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Motor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Motor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Motor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Motor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Motor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Motor_Ctrl)
                            Motor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Motor_Ctrl.Bounds.Width, Motor_Ctrl.Bounds.Height)
                            _symMotorName += 1

                            Motor_Ctrl.Show()

                        Case "StateIndicator"

                            StateIndicator_Ctrl = New StateIndicator()
                            Dim ctrl As New StateIndicator()

                            ctrl = Past_Ctrl
                            StateIndicator_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            StateIndicator_Ctrl.Name = "StateIndicator" & _symStateIndicatorName
                            AddHandler StateIndicator_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler StateIndicator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler StateIndicator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler StateIndicator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler StateIndicator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                StateIndicator_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                StateIndicator_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                StateIndicator_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(StateIndicator_Ctrl)
                            StateIndicator_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, StateIndicator_Ctrl.Bounds.Width, StateIndicator_Ctrl.Bounds.Height)
                            _symStateIndicatorName += 1
                            StateIndicator_Ctrl.Show()

                        Case "Transformer"

                            Transformer_Ctrl = New Transformer()
                            Dim ctrl As New Transformer()

                            ctrl = Past_Ctrl
                            Transformer_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Transformer_Ctrl.Name = "Transformer" & _symTransformerName
                            AddHandler Transformer_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Transformer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Transformer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Transformer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Transformer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Transformer_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Transformer_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Transformer_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Transformer_Ctrl)
                            Transformer_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Transformer_Ctrl.Bounds.Width, Transformer_Ctrl.Bounds.Height)
                            _symTransformerName += 1
                            Transformer_Ctrl.Show()
                        Case "WYE_Connection"

                            WyeConnection_Ctrl = New WYE_Connection()
                            Dim ctrl As New WYE_Connection()

                            ctrl = Past_Ctrl
                            WyeConnection_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            WyeConnection_Ctrl.Name = "WyeConnection" & _symWyeConnectionName

                            AddHandler WyeConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler WyeConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler WyeConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler WyeConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler WyeConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                WyeConnection_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                WyeConnection_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                WyeConnection_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(WyeConnection_Ctrl)
                            WyeConnection_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, WyeConnection_Ctrl.Bounds.Width, WyeConnection_Ctrl.Bounds.Height)
                            _symWyeConnectionName += 1
                            WyeConnection_Ctrl.Show()

                        Case "Liquid_Filter"

                            LiquidFilter_Ctrl = New Liquid_Filter()
                            Dim ctrl As New Liquid_Filter()

                            ctrl = Past_Ctrl
                            LiquidFilter_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            LiquidFilter_Ctrl.Name = "LiquidFilter" & _symLiquidFilterName

                            AddHandler LiquidFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler LiquidFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler LiquidFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler LiquidFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler LiquidFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                LiquidFilter_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                LiquidFilter_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                LiquidFilter_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(LiquidFilter_Ctrl)
                            LiquidFilter_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, LiquidFilter_Ctrl.Bounds.Width, LiquidFilter_Ctrl.Bounds.Height)
                            _symLiquidFilterName += 1
                            LiquidFilter_Ctrl.Show()

                        Case "Vacuum_Filter"

                            VacuumFilter_Ctrl = New Vacuum_Filter()
                            Dim ctrl As New Vacuum_Filter()

                            ctrl = Past_Ctrl
                            VacuumFilter_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            VacuumFilter_Ctrl.Name = "VacuumFilter" & _symVacuumFilterName
                            AddHandler VacuumFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler VacuumFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler VacuumFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler VacuumFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler VacuumFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                VacuumFilter_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                VacuumFilter_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                VacuumFilter_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(VacuumFilter_Ctrl)
                            VacuumFilter_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, VacuumFilter_Ctrl.Bounds.Width, VacuumFilter_Ctrl.Bounds.Height)
                            _symVacuumFilterName += 1
                            VacuumFilter_Ctrl.Show()

                        Case "Exchanger"

                            Exchanger_Ctrl = New Exchanger()
                            Dim ctrl As New Exchanger()

                            ctrl = Past_Ctrl
                            Exchanger_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Exchanger_Ctrl.Name = "Exchanger" & _symExchangerName
                            AddHandler Exchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Exchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Exchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Exchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Exchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Exchanger_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Exchanger_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Exchanger_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Exchanger_Ctrl)
                            Exchanger_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Exchanger_Ctrl.Bounds.Width, Exchanger_Ctrl.Bounds.Height)
                            _symExchangerName += 1
                            Exchanger_Ctrl.Show()
                        Case "Forced_Air_Exchanged"

                            ForcedAirExchanger_Ctrl = New Forced_Air_Exchanged()
                            Dim ctrl As New Forced_Air_Exchanged()

                            ctrl = Past_Ctrl
                            ForcedAirExchanger_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            ForcedAirExchanger_Ctrl.Name = "ForcedAirExchanger" & _symForcedAirExchangerName


                            AddHandler ForcedAirExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler ForcedAirExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler ForcedAirExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler ForcedAirExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler ForcedAirExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                ForcedAirExchanger_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                ForcedAirExchanger_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                ForcedAirExchanger_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(ForcedAirExchanger_Ctrl)
                            ForcedAirExchanger_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, ForcedAirExchanger_Ctrl.Bounds.Width, ForcedAirExchanger_Ctrl.Bounds.Height)
                            _symForcedAirExchangerName += 1
                            ForcedAirExchanger_Ctrl.Show()


                        Case "Furnace"

                            Furnace_Ctrl = New Furnace()
                            Dim ctrl As New Furnace()

                            ctrl = Past_Ctrl
                            Furnace_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Furnace_Ctrl.Name = "Furnace" & _symFurnaceName

                            AddHandler Furnace_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Furnace_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Furnace_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Furnace_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Furnace_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Furnace_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Furnace_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Furnace_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Furnace_Ctrl)
                            Furnace_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Furnace_Ctrl.Bounds.Width, Furnace_Ctrl.Bounds.Height)
                            _symFurnaceName += 1
                            Furnace_Ctrl.Show()

                        Case "Rotary_Kiln"

                            RotaryKiln_Ctrl = New Rotary_Kiln()
                            Dim ctrl As New Rotary_Kiln()

                            ctrl = Past_Ctrl
                            RotaryKiln_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            RotaryKiln_Ctrl.Name = "RotaryKiln" & _symRotaryKilnName

                            AddHandler RotaryKiln_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler RotaryKiln_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler RotaryKiln_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler RotaryKiln_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler RotaryKiln_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                RotaryKiln_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                RotaryKiln_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                RotaryKiln_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(RotaryKiln_Ctrl)
                            RotaryKiln_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, RotaryKiln_Ctrl.Bounds.Width, RotaryKiln_Ctrl.Bounds.Height)
                            _symRotaryKilnName += 1
                            RotaryKiln_Ctrl.Show()

                        Case "Cooling_Tower"

                            CoolingTower_Ctrl = New Cooling_Tower()
                            Dim ctrl As New Cooling_Tower()

                            ctrl = Past_Ctrl
                            CoolingTower_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            CoolingTower_Ctrl.Name = "CoolingTower" & _symCoolingTowerName

                            AddHandler CoolingTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler CoolingTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler CoolingTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler CoolingTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler CoolingTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                CoolingTower_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                CoolingTower_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                CoolingTower_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(CoolingTower_Ctrl)
                            CoolingTower_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, CoolingTower_Ctrl.Bounds.Width, CoolingTower_Ctrl.Bounds.Height)
                            _symCoolingTowerName += 1
                            CoolingTower_Ctrl.Show()
                        Case "Evaporator"

                            Evaporator_Ctrl = New Evaporator()
                            Dim ctrl As New Evaporator()

                            ctrl = Past_Ctrl
                            Evaporator_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Evaporator_Ctrl.Name = "Evaporator" & _symEvaporatorName

                            AddHandler Evaporator_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Evaporator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Evaporator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Evaporator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Evaporator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Evaporator_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Evaporator_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Evaporator_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Evaporator_Ctrl)
                            Evaporator_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Evaporator_Ctrl.Bounds.Width, Evaporator_Ctrl.Bounds.Height)
                            _symEvaporatorName += 1
                            Evaporator_Ctrl.Show()

                        Case "Finned_Exchanger"

                            FinnedExchanger_Ctrl = New Finned_Exchanger()
                            Dim ctrl As New Finned_Exchanger()

                            ctrl = Past_Ctrl
                            FinnedExchanger_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            FinnedExchanger_Ctrl.Name = "FinnedExchanger" & _symFinnedExchangerName
                            AddHandler FinnedExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler FinnedExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler FinnedExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler FinnedExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler FinnedExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                FinnedExchanger_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                FinnedExchanger_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                FinnedExchanger_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(FinnedExchanger_Ctrl)
                            FinnedExchanger_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, FinnedExchanger_Ctrl.Bounds.Width, FinnedExchanger_Ctrl.Bounds.Height)
                            _symFinnedExchangerName += 1
                            FinnedExchanger_Ctrl.Show()

                        Case "Conveyor"

                            Conveyor_Ctrl = New Conveyor()
                            Dim ctrl As New Conveyor()

                            ctrl = Past_Ctrl
                            Conveyor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Conveyor_Ctrl.Name = "Conveyor" & _symConveyorName

                            AddHandler Conveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Conveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Conveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Conveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Conveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Conveyor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Conveyor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Conveyor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Conveyor_Ctrl)
                            Conveyor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Conveyor_Ctrl.Bounds.Width, Conveyor_Ctrl.Bounds.Height)
                            _symConveyorName += 1
                            Conveyor_Ctrl.Show()
                        Case "Mill"

                            Mill_Ctrl = New Mill()
                            Dim ctrl As New Mill()

                            ctrl = Past_Ctrl
                            Mill_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Mill_Ctrl.Name = "Mill" & _symMillName

                            AddHandler Mill_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Mill_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Mill_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Mill_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Mill_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Mill_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Mill_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Mill_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Mill_Ctrl)
                            Mill_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Mill_Ctrl.Bounds.Width, Mill_Ctrl.Bounds.Height)
                            _symMillName += 1
                            Mill_Ctrl.Show()

                        Case "Roll_Stand"

                            RollStand_Ctrl = New Roll_Stand()
                            Dim ctrl As New Roll_Stand()

                            ctrl = Past_Ctrl
                            RollStand_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            RollStand_Ctrl.Name = "RollStand" & _symRollStandName

                            AddHandler RollStand_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler RollStand_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler RollStand_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler RollStand_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler RollStand_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                RollStand_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                RollStand_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                RollStand_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(RollStand_Ctrl)
                            RollStand_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, RollStand_Ctrl.Bounds.Width, RollStand_Ctrl.Bounds.Height)
                            _symRollStandName += 1
                            RollStand_Ctrl.Show()

                        Case "Rotary_Feeder"

                            RotaryFeeder_Ctrl = New Rotary_Feeder()
                            Dim ctrl As New Rotary_Feeder()

                            ctrl = Past_Ctrl
                            RotaryFeeder_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            RotaryFeeder_Ctrl.Name = "RotaryFeeder" & _symRotaryFeederName
                            AddHandler RotaryFeeder_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler RotaryFeeder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler RotaryFeeder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler RotaryFeeder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler RotaryFeeder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                RotaryFeeder_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                RotaryFeeder_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                RotaryFeeder_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(RotaryFeeder_Ctrl)
                            RotaryFeeder_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, RotaryFeeder_Ctrl.Bounds.Width, RotaryFeeder_Ctrl.Bounds.Height)
                            _symRotaryFeederName += 1
                            RotaryFeeder_Ctrl.Show()

                        Case "Screw_Conveyor"

                            ScrewConveyor_Ctrl = New Screw_Conveyor()
                            Dim ctrl As New Screw_Conveyor()

                            ctrl = Past_Ctrl
                            ScrewConveyor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            ScrewConveyor_Ctrl.Name = "ScrewConveyor" & _symScrewConveyorName
                            AddHandler ScrewConveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler ScrewConveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler ScrewConveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler ScrewConveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler ScrewConveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                ScrewConveyor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                ScrewConveyor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                ScrewConveyor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(ScrewConveyor_Ctrl)
                            ScrewConveyor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, ScrewConveyor_Ctrl.Bounds.Width, ScrewConveyor_Ctrl.Bounds.Height)
                            _symScrewConveyorName += 1
                            ScrewConveyor_Ctrl.Show()


                        Case "Agitator"

                            Agitator_Ctrl = New Agitator()
                            Dim ctrl As New Agitator()

                            ctrl = Past_Ctrl
                            Agitator_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Agitator_Ctrl.Name = "Agitator" & _symAgitatorName

                            AddHandler Agitator_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Agitator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Agitator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Agitator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Agitator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Agitator_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Agitator_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Agitator_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Agitator_Ctrl)
                            Agitator_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Agitator_Ctrl.Bounds.Width, Agitator_Ctrl.Bounds.Height)
                            _symAgitatorName += 1
                            Agitator_Ctrl.Show()

                        Case "Inline_Mixer"

                            InlineMixer_Ctrl = New Inline_Mixer()
                            Dim ctrl As New Inline_Mixer()

                            ctrl = Past_Ctrl
                            InlineMixer_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            InlineMixer_Ctrl.Name = "InlineMixer" & _symInlineMixerName

                            AddHandler InlineMixer_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler InlineMixer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler InlineMixer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler InlineMixer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler InlineMixer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                InlineMixer_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                InlineMixer_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                InlineMixer_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(InlineMixer_Ctrl)
                            InlineMixer_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, InlineMixer_Ctrl.Bounds.Width, InlineMixer_Ctrl.Bounds.Height)
                            _symInlineMixerName += 1
                            InlineMixer_Ctrl.Show()

                        Case "Reciprocating_Compressor"

                            ReciprocatingCompressor_Ctrl = New Reciprocating_Compressor()
                            Dim ctrl As New Reciprocating_Compressor()

                            ctrl = Past_Ctrl
                            ReciprocatingCompressor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            ReciprocatingCompressor_Ctrl.Name = "ReciprocatingCompressor" & _symReciprocatingCompressorName

                            AddHandler ReciprocatingCompressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler ReciprocatingCompressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler ReciprocatingCompressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler ReciprocatingCompressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler ReciprocatingCompressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                ReciprocatingCompressor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                ReciprocatingCompressor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                ReciprocatingCompressor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(ReciprocatingCompressor_Ctrl)
                            ReciprocatingCompressor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, ReciprocatingCompressor_Ctrl.Bounds.Width, ReciprocatingCompressor_Ctrl.Bounds.Height)
                            _symReciprocatingCompressorName += 1
                            ReciprocatingCompressor_Ctrl.Show()
                        Case "Blower"

                            Blower_Ctrl = New Blower()
                            Dim ctrl As New Blower()

                            ctrl = Past_Ctrl
                            Blower_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Blower_Ctrl.Name = "Blower" & _symBlowerName
                            AddHandler Blower_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Blower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Blower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Blower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Blower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Blower_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Blower_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Blower_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Blower_Ctrl)
                            Blower_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Blower_Ctrl.Bounds.Width, Blower_Ctrl.Bounds.Height)
                            _symBlowerName += 1
                            Blower_Ctrl.Show()

                        Case "Compressor"

                            Compressor_Ctrl = New Compressor()
                            Dim ctrl As New Compressor()

                            ctrl = Past_Ctrl
                            Compressor_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Compressor_Ctrl.Name = "Compressor" & _symCompressorName

                            AddHandler Compressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Compressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Compressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Compressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Compressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Compressor_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Compressor_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Compressor_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Compressor_Ctrl)
                            Compressor_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Compressor_Ctrl.Bounds.Width, Compressor_Ctrl.Bounds.Height)
                            _symCompressorName += 1
                            Compressor_Ctrl.Show()

                        Case "Pump"

                            Pump_Ctrl = New Pump()
                            Dim ctrl As New Pump()

                            ctrl = Past_Ctrl
                            Pump_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Pump_Ctrl.Name = "Pump" & _symPumpName
                            AddHandler Pump_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Pump_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Pump_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Pump_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Pump_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Pump_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Pump_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Pump_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Pump_Ctrl)
                            Pump_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Pump_Ctrl.Bounds.Width, Pump_Ctrl.Bounds.Height)
                            _symPumpName += 1
                            Pump_Ctrl.Show()

                        Case "Turbine"

                            Turbine_Ctrl = New Turbine()
                            Dim ctrl As New Turbine()

                            ctrl = Past_Ctrl
                            Turbine_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            Turbine_Ctrl.Name = "Turbine" & _symTurbineName
                            AddHandler Turbine_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler Turbine_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler Turbine_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler Turbine_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler Turbine_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                Turbine_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                Turbine_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                Turbine_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(Turbine_Ctrl)
                            Turbine_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, Turbine_Ctrl.Bounds.Width, Turbine_Ctrl.Bounds.Height)
                            _symTurbineName += 1
                            Turbine_Ctrl.Show()

                        Case "Cyclone_Seperator"

                            CycloneSeparator_Ctrl = New Cyclone_Seperator()
                            Dim ctrl As New Cyclone_Seperator()

                            ctrl = Past_Ctrl
                            CycloneSeparator_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            CycloneSeparator_Ctrl.Name = "CycloneSeparator" & _symCycloneSeparatorName
                            AddHandler CycloneSeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler CycloneSeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler CycloneSeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler CycloneSeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler CycloneSeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                CycloneSeparator_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                CycloneSeparator_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                CycloneSeparator_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(CycloneSeparator_Ctrl)
                            CycloneSeparator_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, CycloneSeparator_Ctrl.Bounds.Width, CycloneSeparator_Ctrl.Bounds.Height)
                            _symCycloneSeparatorName += 1
                            CycloneSeparator_Ctrl.Show()
                        Case "Rotary_Seperator"

                            RotarySeparator_Ctrl = New Rotary_Seperator()
                            Dim ctrl As New Rotary_Seperator()

                            ctrl = Past_Ctrl
                            RotarySeparator_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            RotarySeparator_Ctrl.Name = "RotarySeparator" & _symRotarySeparatorName

                            AddHandler RotarySeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler RotarySeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler RotarySeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler RotarySeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler RotarySeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                RotarySeparator_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                RotarySeparator_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                RotarySeparator_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(RotarySeparator_Ctrl)
                            RotarySeparator_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, RotarySeparator_Ctrl.Bounds.Width, RotarySeparator_Ctrl.Bounds.Height)
                            _symRotarySeparatorName += 1
                            RotarySeparator_Ctrl.Show()
                        Case "Spray_Dryer"

                            SprayDryer_Ctrl = New Spray_Dryer()
                            Dim ctrl As New Spray_Dryer()

                            ctrl = Past_Ctrl
                            SprayDryer_Ctrl = ControlFactory.CloneCtrl(Past_Ctrl)
                            SprayDryer_Ctrl.Name = "SprayDryer" & _symSprayDryerName
                            AddHandler SprayDryer_Ctrl.MouseClick, (AddressOf Symbol_Click)
                            AddHandler SprayDryer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
                            AddHandler SprayDryer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
                            AddHandler SprayDryer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
                            AddHandler SprayDryer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

                            For i As Integer = 0 To ctrl._THCondition.Count - 1
                                SprayDryer_Ctrl._THCondition.Add(ctrl._THCondition(i))
                                SprayDryer_Ctrl._ThresholdValue.Add(ctrl._ThresholdValue(i))
                                SprayDryer_Ctrl._THColor.Add(ctrl._THColor(i))
                            Next


                            Page_Ctrl.Controls.Add(SprayDryer_Ctrl)
                            SprayDryer_Ctrl.SetBounds(Cursor.Position.X, Cursor.Position.Y, SprayDryer_Ctrl.Bounds.Width, SprayDryer_Ctrl.Bounds.Height)
                            _symSprayDryerName += 1
                            SprayDryer_Ctrl.Show()



                    End Select



                End If
            End If
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Paste_Controls()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    'Guage Ctrl
    Private Sub GuageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuageToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Guage_Ctrl = New AnalyzerMeter.AGauge
            Guage_Ctrl.Name = "Guage" & _iniGuageName
            AddHandler Guage_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Guage_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Guage_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Guage_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Guage_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Guage_Ctrl.AutoSize = False
            Guage_Ctrl.Tag = "Guage"
            Guage_Ctrl.Width = 245
            Guage_Ctrl.Height = 214
            Guage_Ctrl.MinimumSize = Ctrl_MinSize


            Guage_Ctrl.MinValue = 0
            Guage_Ctrl.MaxValue = 400
            Guage_Ctrl.CapPosition = New Point(100, 180)
            Guage_Ctrl.Range_Idx = 0
            Guage_Ctrl.RangeStartValue = 0
            Guage_Ctrl.RangeEndValue = 150
            Guage_Ctrl.RangeColor = Color.Lime
            Guage_Ctrl.Font = New Font("Verdana", 8.25, FontStyle.Bold)
            Guage_Ctrl.NeedleColor2 = Color.Blue
            Guage_Ctrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Blue
            Guage_Ctrl.Range_Idx = 1
            Guage_Ctrl.RangeStartValue = 150
            Guage_Ctrl.RangeEndValue = 300
            Guage_Ctrl.RangeColor = Color.Orange


            Guage_Ctrl.Range_Idx = 2
            Guage_Ctrl.RangeEndValue = 400
            Guage_Ctrl.RangeStartValue = 300

            Guage_Ctrl.RangeColor = Color.Red
            Guage_Ctrl.RangeEnabled = True
            Guage_Ctrl.Location = New Point(220, 175)
            Guage_Ctrl.Center = New Point(120, 110)
            Guage_Ctrl.AccessibleDescription = ""


            Page_Ctrl.Controls.Add(Guage_Ctrl) 'Add GuageControls in panel
            Guage_Ctrl.BringToFront()
            Call Border(Guage_Ctrl) 'Create Border
            _iniGuageName += 1

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GaugeToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    ''' Set Default Cursor style When Ctrl Mouse Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ctrl_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Set Control  dragging = False
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ctrl_MouseUp(ByVal sender As [Object], ByVal e As MouseEventArgs)
        dragging = False
        If TypeOf sender Is Button_Control Then
            Button_Ctrl = sender
            If e.Button = MouseButtons.Right Then
                ButtonProperties.Show(Button_Ctrl, e.X, e.Y)
                Past_Ctrl = sender
            End If
        ElseIf TypeOf sender Is OPCWriterControl Then
            OPCWrite_Ctrl = sender
            If e.Button = MouseButtons.Right Then
                OPCWriterProperties.Show(OPCWrite_Ctrl, e.X, e.Y)
                Past_Ctrl = sender
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set Control Old Position and dragging = True
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ctrl_MouseDown(ByVal sender As [Object], ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Left Then
            dragging = True
            oldX = e.X
            OldY = e.Y
        End If

    End Sub

    ''' <summary>
    ''' Event Handler when Click On Ctrl Control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ctrl_Click(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            If Not _runMode Then
                Page_Ctrl.Refresh()

                If TypeOf sender Is AnalyzerMeter.AGauge Then
                    Guage_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        GuageProperties.Show(Guage_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is LabelValue Then
                    ValueLabel_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        MSDisplayValueLabel.Show(ValueLabel_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is Label Then
                    Label_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        labelProperties.Show(Label_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is FlowLayoutPanel Then
                    Annunciator_Ctrl = sender
                    Call Border(sender)
                    If e.Button = MouseButtons.Right Then
                        AnnunciatorProperties.Show(Annunciator_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is DataGridViewCtrl Then
                    Grid_TableCtrl = sender

                    If e.Button = MouseButtons.Right Then
                        GridTableProperties.Show(Grid_TableCtrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If

                    'ElseIf TypeOf sender Is MultiTrendCtrl Then
                    '    Trender_Ctrl = sender

                    '    If e.Button = MouseButtons.Right Then
                    '        If Trender_Ctrl.ChartControl1.Series.Count > 1 Then
                    '            MultiTrendChartProperties.Show(Trender_Ctrl.ChartControl1, e.X, e.Y)
                    '            Past_Ctrl = sender
                    '        End If
                    '    End If
                ElseIf TypeOf sender Is ChartControl Then
                    Chart_Ctrl = sender

                    If e.Button = MouseButtons.Right Then
                        'If Chart_Ctrl.Series.Count > 1 Then
                        '    MultiTrendChartProperties.Show(Chart_Ctrl, e.X, e.Y)
                        '    Past_Ctrl = sender
                        'Else
                        ChartProperties.Show(Chart_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                        'End If
                    End If
                ElseIf TypeOf sender Is Panel Then
                    Panel_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        PanelProperties.Show(Panel_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is PictureBox Then
                    PictureBox_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        PicBoxProperties.Show(PictureBox_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is LogViewer Then
                    LogCtrl = sender
                    If e.Button = MouseButtons.Right Then
                        If LogCtrl.TabPages(0).Controls.Count > 0 AndAlso Not TypeOf LogCtrl.TabPages(0).Controls(0) Is WebBrowser Then
                            MS_LBPrint.Enabled = True
                        Else
                            MS_LBPrint.Enabled = False
                        End If

                        If Not LogCtrl.isTimerStart Then
                            StartToolStripMenuItem.Enabled = True
                            StopToolStripMenuItem1.Enabled = False
                        Else
                            StartToolStripMenuItem.Enabled = False
                            StopToolStripMenuItem1.Enabled = True
                        End If
                        LogBookProperties.Show(LogCtrl, e.X, e.Y)
                        Past_Ctrl = sender
                    End If
                ElseIf TypeOf sender Is MChartControl Then
                    MChart_Ctrl = sender

                    If e.Button = MouseButtons.Right Then
                        'If Chart_Ctrl.Series.Count > 1 Then
                        '    MultiTrendChartProperties.Show(Chart_Ctrl, e.X, e.Y)
                        '    Past_Ctrl = sender
                        'Else
                        MChartProperties.Show(MChart_Ctrl, e.X, e.Y)
                        Past_Ctrl = sender
                        'End If
                    End If

                End If
            End If

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Ctrl_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Event Handler Move the  Control along with the Panel and Draw the Border !!!
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Ctrl_MouseMove(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try

            If Not _runMode Then
                Dim c As Control = CType(sender, Control)
                If (My.Computer.Keyboard.CtrlKeyDown) Then
                    If dragging And mEdge <> EdgeEnum.None Then
                        modify = True  'Manage the page is modified or not
                        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Me.Text = Me.Text & " *"
                        End If
                        If Not (TypeOf c Is DataGridViewCtrl Or TypeOf c Is ChartControl _
                                Or TypeOf c Is Button_Control) Then
                            Call Border(c) 'Create Border

                        End If

                        c.SuspendLayout()
                        Select Case mEdge
                            Case EdgeEnum.Left
                                c.SetBounds(c.Left + e.X, c.Top,
                        c.Width - e.X, c.Height)
                            Case EdgeEnum.Right
                                c.SetBounds(c.Left, c.Top,
                        c.Width - (c.Width - e.X), c.Height)
                            Case EdgeEnum.Top
                                c.SetBounds(c.Left, c.Top + e.Y,
                        c.Width, c.Height - e.Y)
                            Case EdgeEnum.Bottom
                                c.SetBounds(c.Left, c.Top,
                        c.Width, c.Height - (c.Height - e.Y))
                            Case EdgeEnum.TopLeft
                                If dragging And (My.Computer.Keyboard.CtrlKeyDown) Then
                                    c.SetBounds((e.X + c.Left) - oldX, (e.Y + c.Top) - OldY, c.Width, c.Height)
                                End If
                            Case Else
                                ' do the defalut action
                        End Select
                        c.ResumeLayout()
                    Else
                        Select Case True
                            Case e.X <= mWidth 'left edge
                                c.Cursor = Cursors.SizeWE
                                mEdge = EdgeEnum.Left
                            Case e.X > c.Width - (mWidth + 1) 'right edge
                                c.Cursor = Cursors.SizeWE
                                mEdge = EdgeEnum.Right
                            Case e.Y <= mWidth 'top edge
                                c.Cursor = Cursors.SizeNS
                                mEdge = EdgeEnum.Top
                            Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                                c.Cursor = Cursors.SizeNS
                                mEdge = EdgeEnum.Bottom
                            Case Else 'no edge
                                c.Cursor = Cursors.SizeAll
                                mEdge = EdgeEnum.TopLeft
                        End Select
                    End If
                End If

            End If


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Ctrl_MouseMove()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    ''' <summary>
    '''  Event Handler MouseDown the  Devexpress Chart Control!!!
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub DevexpressChart_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    If diagram Is Nothing Then
    '        Return
    '    End If
    '    ' Get the information about clicked point
    '    Dim coords As ch.DiagramCoordinates = diagram.PointToDiagram(e.Location)
    '    ' if the point is within the diagram and in the constant line..
    '    If (Not coords.IsEmpty) AndAlso TypeOf line.AxisValue Is Integer AndAlso coords.NumericalArgument.Equals(CInt(line.AxisValue)) Then
    '        ' allow dragging and catch the mouse, change the cursor
    '        _dragging = True
    '        chart.Capture = True
    '        setCursor()
    '    End If
    'End Sub
    'Private Sub DevexpressChart_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    _dragging = False
    '    chart.Capture = False
    'End Sub
    'Private Sub DevexpressChart_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    If diagram Is Nothing Then
    '        Return
    '    End If

    '    If _dragging AndAlso (e.Button And MouseButtons.Left) = 0 Then
    '        _dragging = False
    '        chart.Capture = False
    '    End If

    '    Dim coords As ch.DiagramCoordinates = diagram.PointToDiagram(e.Location)
    '    If coords.IsEmpty Then
    '        RestoreCursor()
    '    Else
    '        If _dragging Then
    '            line.AxisValue = coords.NumericalArgument
    '        End If

    '        If TypeOf line.AxisValue Is Integer AndAlso coords.NumericalArgument.Equals(CInt(line.AxisValue)) Then
    '            SetCursor()
    '        Else
    '            RestoreCursor()
    '        End If
    '    End If
    'End Sub
    'Private Sub SetCursor()
    '    If defCursor Is Nothing Then
    '        defCursor = Cursor.Current
    '    End If
    '    Cursor.Current = Cursors.VSplit
    'End Sub

    'Private Sub RestoreCursor()
    '    If defCursor IsNot Nothing Then
    '        Cursor.Current = defCursor
    '        defCursor = Nothing
    '    End If
    'End Sub

    'Label
    Private Sub LabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Label_Ctrl = New Label
            Label_Ctrl.Name = "Label" & _iniLabelName
            Label_Ctrl.Tag = "Text"
            Label_Ctrl.Text = "Text" & _iniLabelName
            Label_Ctrl.MinimumSize = New Size(20, 12)
            Label_Ctrl.TextAlign = ContentAlignment.MiddleCenter
            Label_Ctrl.AutoSize = False
            Label_Ctrl.Font = New Font("Verdana", 10)
            AddHandler Label_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Label_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Label_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Label_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Label_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Label_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Label_Ctrl)
            Label_Ctrl.BringToFront()
            _iniLabelName += 1
            Call Border(Label_Ctrl)
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LabelToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'button_Ctrl
    Private Sub ButtonMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Button_Ctrl = New Button_Control
            Button_Ctrl.Name = "Button" & _iniButtonName
            Button_Ctrl.Tag = "Button"
            Button_Ctrl.Text = "Button " & _iniButtonName
            Button_Ctrl.MinimumSize = Ctrl_MinSize

            Button_Ctrl.Font = New Font("Verdana", 9)
            AddHandler Button_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Button_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Button_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Button_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            AddHandler Button_Ctrl.Click, AddressOf ButtonCtrl_Click

            Button_Ctrl.Location = Cursor.Position
            Page_Ctrl.Controls.Add(Button_Ctrl)
            Button_Ctrl.BringToFront()
            _iniButtonName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ButtonMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    Public AsyncRefrGroup As RefreshGroup
    Private TagNamename As String = ""
    Private Sub OPCWriterCtrl_Click(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            If Not (My.Computer.Keyboard.CtrlKeyDown) Then
                OPCWrite_Ctrl = sender
                Dim result1 = MsgBox("Are you sure want to Write " + OPCWrite_Ctrl.OPCTag + " as " + OPCWrite_Ctrl.OPCValue + " ?", vbYesNo)
                If result1 = DialogResult.Yes Then

                    Dim opservername As String = OPCWrite_Ctrl.OPCServerName
                    Dim opctag As String = OPCWrite_Ctrl.OPCTag
                    Dim opcval As String = OPCWrite_Ctrl.OPCValue

                    Dim opcsr = New OpcServer()
                    Dim rst As Int32
                    If opservername.Contains("^") Then
                        rst = opcsr.Connect(opservername.Split("^")(0), opservername.Split("^")(1))
                    Else
                        rst = opcsr.Connect(opservername)
                    End If

                    'Check For Successful Connection
                    If HRESULTS.Failed(rst) Then
                        MsgBox(opcsr.GetErrorString(rst, 1))
                        opcsr = Nothing
                    Else
                        AsyncRefrGroup = New RefreshGroup(opcsr, AddressOf OPCDataChangeHandler, 1000)
                    End If

                    AsyncRefrGroup.Write(opctag, opcval)


                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub OPCDataChangeHandler(ByVal sender As Object, ByVal e As DataChangeEventArgs)
        If InvokeRequired Then
            BeginInvoke(New DataChangeEventHandler(AddressOf OPCDataChangeHandler), New Object() {sender, e})
            Return
        End If

        Dim _OpcTime As DateTime
        Dim _OpcValue As Object = Nothing
        Dim _ArrOPCValue As Object = ""
        Dim _Temp_dbl As Double
        Dim _OpcItem As ItemDef
        Dim _hndClient As Int32

        Try

            For n As Integer = 0 To e.sts.Length - 1
                _hndClient = e.sts(n).HandleClient
                _OpcValue = e.sts(n).DataValue
                _OpcTime = DateTime.FromFileTime(e.sts(n).TimeStamp)

                _OpcItem = AsyncRefrGroup.FindClientHandle(_hndClient)
                If Not (_OpcItem Is Nothing) Then
                    TagNamename = _OpcItem.OpcIDef.ItemID 'Assign tag Name
                End If
                _ArrOPCValue = ""
                If Not _OpcValue Is Nothing Then
                    If IsArray(_OpcValue) Then
                        For jj As Integer = 0 To _OpcValue.Length - 1
                            If (Not _ArrOPCValue Is Nothing AndAlso String.IsNullOrEmpty(_ArrOPCValue)) Then
                                _ArrOPCValue = _OpcValue(jj)
                            Else
                                _ArrOPCValue &= "," & _OpcValue(jj)
                            End If
                        Next
                    Else
                        _ArrOPCValue = _OpcValue
                    End If
                    'Check the _ArrOPCValue are Double or not, If true then round the value   
                    If IsNumeric(_ArrOPCValue) Then
                        If Double.TryParse(_ArrOPCValue, _Temp_dbl) Then
                            _ArrOPCValue = Math.Round(_Temp_dbl, 2)
                        End If
                    End If
                End If
            Next



        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCDataChangeHandler()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub ButtonCtrl_Click(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Button_Ctrl = sender
        If Not (My.Computer.Keyboard.CtrlKeyDown) Then
            Select Case Button_Ctrl.Action_Type
                Case "Change Page"

                    Dim pgIdx As Integer = PageTreeView.Nodes(0).Nodes(2).Nodes.IndexOfKey(Button_Ctrl.Action_Ctrl)
                    If pgIdx <> -1 Then
                        PageTreeView.SelectedNode = PageTreeView.Nodes(0).Nodes(2).Nodes(pgIdx)
                    End If
                Case "Print"
                    Call PrintAndExportComponent(Button_Ctrl.Action_Ctrl, "Print")
                Case "Export"
                    Call PrintAndExportComponent(Button_Ctrl.Action_Ctrl, "Export")
                Case "Write OPC Value"
                    Dim Idx As Integer = PageTreeView.Nodes(0).Nodes(1).Nodes.IndexOfKey(Button_Ctrl.Action_Ctrl)
                    If Idx <> -1 Then
                        If Not opcCnfgTags Is Nothing AndAlso opcCnfgTags.Length > 0 Then
                            If Not opcCnfgTags(Idx) Is Nothing Then
                                Dim name = PageTreeView.Nodes(0).Nodes(1).Nodes(Idx).ToolTipText.Split("&")
                                If name.Length > 0 Then
                                    OPCWriter.OPCName = name(1)
                                End If
                                OPCWriter.txtOPCValue.Text = opcCnfgTags(Idx).DGVChannelsValue.Rows(0).Cells(2).Value
                                OPCWriter.idx = Idx
                                OPCWriter.ShowDialog()
                            End If
                        End If

                    End If

                Case "Exit"
                    Call MainPage_FormClosing(sender, e)
            End Select
        End If
    End Sub

    Private Sub PrintAndExportComponent(ByVal name As String, ByVal Type As String)
        Try

            For j As Integer = 0 To PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
                Dim pnlObj() As Control
                pnlObj = Controls.Find("pnlPage" & j + 1, True)
                If pnlObj.Length > 0 Then
                    If Not pnlObj(0) Is Nothing Then
                        Dim Fcontrols = pnlObj(0).Controls.Find(name, True)
                        If Fcontrols.Length > 0 Then
                            If Not Fcontrols(0) Is Nothing Then
                                If (TypeOf Fcontrols(0) Is DataGridViewCtrl) Then
                                    If Type = "Print" Then
                                        Dim prntdlg As New PrintDialog
                                        If prntdlg.ShowDialog = DialogResult.OK Then
                                            PrintDoc_Table.PrinterSettings.PrinterName = prntdlg.PrinterSettings.PrinterName
                                            PrintDoc_Table.PrintController = New StandardPrintController
                                            If SetupThePrinting(Fcontrols(0)) Then
                                                PrintDoc_Table.Print()
                                            End If
                                        End If
                                    ElseIf Type = "Export" Then
                                        Call Export_GridTable(Fcontrols(0))
                                    End If
                                ElseIf (TypeOf Fcontrols(0) Is Chart) Then
                                    If Type = "Print" Then
                                        Chart_Ctrl = Fcontrols(0)
                                        Dim prntdlg As New PrintDialog
                                        If prntdlg.ShowDialog = DialogResult.OK Then
                                            PrintDoc_Chart.PrinterSettings.PrinterName = prntdlg.PrinterSettings.PrinterName
                                            PrintDoc_Chart.PrintController = New StandardPrintController
                                            PrintDoc_Chart.Print()
                                        End If

                                    ElseIf Type = "Export" Then
                                        Chart_Ctrl = Fcontrols(0)
                                        Dim Savefldlg As New SaveFileDialog
                                        Savefldlg.Filter = ("Jpeg Image(.jpeg)|*.jpeg")
                                        If Savefldlg.ShowDialog = DialogResult.OK Then
                                            Chart_Ctrl.SaveImage(Savefldlg.FileName, ChartImageFormat.Jpeg)
                                            MsgBox("Done !!!", MsgBoxStyle.Information)
                                        End If

                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TaskScheduleClass.Task_timer_Tick()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'ValueLabel
    Private Sub ValueLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueLabelToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ValueLabel_Ctrl = New LabelValue
            ValueLabel_Ctrl.Name = "ValueLabel" & _iniValuelabelName
            ValueLabel_Ctrl.MinimumSize = New Size(20, 12)
            ValueLabel_Ctrl.TextAlign = ContentAlignment.MiddleCenter
            ValueLabel_Ctrl.AutoSize = False

            AddHandler ValueLabel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler ValueLabel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ValueLabel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ValueLabel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ValueLabel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            ValueLabel_Ctrl.AccessibleDescription = ""
            ValueLabel_Ctrl.BackColor = Color.Transparent
            ValueLabel_Ctrl.ForeColor = Color.Black

            Page_Ctrl.Controls.Add(ValueLabel_Ctrl)

            ValueLabel_Ctrl.BringToFront()
            _iniValuelabelName += 1
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DisplayValuesToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    'Chart Ctrl
    Private Sub DChartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart2DToolStripMenuItem.Click

        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Chart_Ctrl = New ChartControl

L1:
            If Ctrl_NameList.Contains("Chart" & _iniChartName) Then 'Assign Unique Name
                _iniChartName += 1
                GoTo L1
            End If

            Chart_Ctrl.Name = "Chart" & _iniChartName
            Chart_Ctrl.MinimumSize = Ctrl_MinSize

            AddHandler Chart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Chart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Chart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Chart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Chart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave


            Chart_Ctrl.AutoSize = False
            Chart_Ctrl.Tag = "Chart"
            Chart_Ctrl.Width = 650
            Chart_Ctrl.Height = 270
            Chart_Ctrl.Location = New Point(150, 200)
            Dim genChartSeries As New Series
            Dim genChartArea As New ChartArea
            Chart_Ctrl.BackColor = Color.WhiteSmoke
            genChartArea.BackColor = Color.WhiteSmoke
            genChartArea.Axes(0).LineColor = Color.Black
            genChartArea.Axes(1).LineColor = Color.Black
            genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
            genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines

            genChartArea.AxisX.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisY.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)

            genChartArea.Axes(0).LabelStyle.ForeColor = Color.Black
            genChartArea.Axes(1).LabelStyle.ForeColor = Color.Black

            genChartArea.Axes(0).MajorTickMark.LineColor = Color.Black
            genChartArea.Axes(1).MajorTickMark.LineColor = Color.Black

            genChartArea.Axes(0).Title = "X- Axis"
            genChartArea.Axes(1).Title = "Y- Axis"

            genChartArea.Axes(0).TitleForeColor = Color.Black
            genChartArea.Axes(1).TitleForeColor = Color.Black

            genChartArea.Axes(0).MajorGrid.LineColor = Color.LightGray
            genChartArea.Axes(1).MajorGrid.LineColor = Color.LightGray

            genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
            genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

            'genChartArea.AxisX.Interval = 2
            ' genChartArea.AxisX.LabelStyle.IsStaggered=True
            'genChartArea.AxisX.LabelStyle.Angle=-45

            genChartArea.AxisY.Tag = "True"

            Chart_Ctrl.BorderlineColor = Color.Black
            Chart_Ctrl.BorderlineWidth = 1
            Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid

            genChartArea.BorderWidth = 2

            'GenChartSeries.ToolTip = "#VALX,#VAL{N}"
            genChartSeries.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries.XValueType = ChartValueType.String
            genChartSeries.BorderWidth = 2
            genChartSeries.Name = "Series1"

            genChartSeries.MarkerColor = Color.Red
            genChartSeries.MarkerSize = 0
            genChartSeries.MarkerStyle = MarkerStyle.Triangle
            genChartSeries.ChartType = SeriesChartType.Line
            genChartSeries.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries.Color = Color.Green
            genChartSeries.IsValueShownAsLabel = True
            genChartSeries.LabelForeColor = Color.Black
            genChartSeries.Font = New Font("Verdana", 8, FontStyle.Regular)
            'genChartSeries.CustomProperties="LabelStyle=Top"
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries.Points.AddXY("0", 5)
            genChartSeries.Points.AddXY("10", 49)
            genChartSeries.Points.AddXY("26", 58)
            genChartSeries.Points.AddXY("35", 14)
            genChartSeries.Points.AddXY("44", 70)
            genChartSeries.Points.AddXY("60", 49)
            genChartSeries.Points.AddXY("70", 62)
            genChartSeries.Points.AddXY("80", 19)

            Chart_Ctrl.Legends.Add("Series1")
            Chart_Ctrl.Legends(0).Enabled = True
            Chart_Ctrl.Legends(0).Alignment = StringAlignment.Far
            Chart_Ctrl.Legends(0).Position.Width = 100
            Chart_Ctrl.Legends(0).Position.Height = 10
            Chart_Ctrl.Legends(0).Position.X = 70
            Chart_Ctrl.Legends(0).Position.Y = 0
            Chart_Ctrl.Legends(0).ForeColor = Color.Black
            Chart_Ctrl.Legends(0).BackColor = Color.Transparent
            Chart_Ctrl.Series.Add(genChartSeries)
            Chart_Ctrl.ChartAreas.Add(genChartArea)
            Chart_Ctrl.Titles.Add("")


            Chart_Ctrl.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Chart_Ctrl.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            Chart_Ctrl.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart_Ctrl.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            Chart_Ctrl.ChartAreas(0).CursorX.AutoScroll = True
            Chart_Ctrl.ChartAreas(0).CursorY.AutoScroll = True


            Page_Ctrl.Controls.Add(Chart_Ctrl)


            Chart_Ctrl.BringToFront()
            'Selected_Ctrl = Chart_Ctrl
            _iniChartName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DGraphToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'Multiple Trend
    Private Sub MultipleTrendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Chart_Ctrl = New ChartControl

L1:
            If Ctrl_NameList.Contains("Chart" & _iniChartName) Then 'Assign Unique Name
                _iniChartName += 1
                GoTo L1
            End If

            Chart_Ctrl.Name = "Chart" & _iniChartName
            Chart_Ctrl.MinimumSize = Ctrl_MinSize

            AddHandler Chart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Chart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Chart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Chart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Chart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave


            Chart_Ctrl.AutoSize = False
            Chart_Ctrl.Tag = "Chart"
            Chart_Ctrl.Width = 650
            Chart_Ctrl.Height = 270
            Chart_Ctrl.Location = New Point(150, 200)
            Dim genChartSeries As New Series
            Dim genChartSeries1 As New Series
            Dim genChartArea As New ChartArea
            Chart_Ctrl.BackColor = Color.WhiteSmoke
            genChartArea.BackColor = Color.WhiteSmoke
            genChartArea.Axes(0).LineColor = Color.Black
            genChartArea.Axes(1).LineColor = Color.Black
            genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
            genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines

            genChartArea.AxisX.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisY.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)

            genChartArea.Axes(0).LabelStyle.ForeColor = Color.Black
            genChartArea.Axes(1).LabelStyle.ForeColor = Color.Black

            genChartArea.Axes(0).MajorTickMark.LineColor = Color.Black
            genChartArea.Axes(1).MajorTickMark.LineColor = Color.Black

            genChartArea.Axes(0).Title = "X- Axis"
            genChartArea.Axes(1).Title = "Y- Axis"

            genChartArea.Axes(0).TitleForeColor = Color.Black
            genChartArea.Axes(1).TitleForeColor = Color.Black

            genChartArea.Axes(0).MajorGrid.LineColor = Color.LightGray
            genChartArea.Axes(1).MajorGrid.LineColor = Color.LightGray

            genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
            genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

            'genChartArea.AxisX.Interval = 2
            ' genChartArea.AxisX.LabelStyle.IsStaggered=True
            'genChartArea.AxisX.LabelStyle.Angle=-45

            genChartArea.AxisY.Tag = "True"

            Chart_Ctrl.BorderlineColor = Color.Black
            Chart_Ctrl.BorderlineWidth = 1
            Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid

            genChartArea.BorderWidth = 2

            'Chartseries
            genChartSeries.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries.XValueType = ChartValueType.String
            genChartSeries.BorderWidth = 2
            genChartSeries.Name = "Series1"

            genChartSeries.MarkerColor = Color.Red
            genChartSeries.MarkerSize = 0
            genChartSeries.MarkerStyle = MarkerStyle.Triangle
            genChartSeries.ChartType = SeriesChartType.Line
            genChartSeries.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries.Color = Color.Green
            genChartSeries.IsValueShownAsLabel = True
            genChartSeries.LabelForeColor = Color.Black
            genChartSeries.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries.Points.AddXY("0", 5)
            genChartSeries.Points.AddXY("10", 49)
            genChartSeries.Points.AddXY("26", 58)
            genChartSeries.Points.AddXY("35", 14)
            genChartSeries.Points.AddXY("44", 70)
            genChartSeries.Points.AddXY("60", 49)
            genChartSeries.Points.AddXY("70", 62)
            genChartSeries.Points.AddXY("80", 19)

            'Chartseries1
            genChartSeries1.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries1.XValueType = ChartValueType.String
            genChartSeries1.BorderWidth = 2
            genChartSeries1.Name = "Series2"

            genChartSeries1.MarkerColor = Color.Red
            genChartSeries1.MarkerSize = 0
            genChartSeries1.MarkerStyle = MarkerStyle.Triangle
            genChartSeries1.ChartType = SeriesChartType.Line
            genChartSeries1.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries1.Color = Color.Orange
            genChartSeries1.IsValueShownAsLabel = True
            genChartSeries1.LabelForeColor = Color.Black
            genChartSeries1.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries1.Points.AddXY("0", 10)
            genChartSeries1.Points.AddXY("14", 43)
            genChartSeries1.Points.AddXY("30", 95)
            genChartSeries1.Points.AddXY("38", 110)
            genChartSeries1.Points.AddXY("50", 85)
            genChartSeries1.Points.AddXY("62", 74)
            genChartSeries1.Points.AddXY("75", 69)
            genChartSeries1.Points.AddXY("90", 50)


            Chart_Ctrl.Legends.Add("Series1")
            Chart_Ctrl.Legends.Add("Series2")
            Chart_Ctrl.Legends(0).Enabled = True
            Chart_Ctrl.Legends(0).Alignment = StringAlignment.Far
            Chart_Ctrl.Legends(0).Position.Width = 100
            Chart_Ctrl.Legends(0).Position.Height = 10
            Chart_Ctrl.Legends(0).Position.X = 70
            Chart_Ctrl.Legends(0).Position.Y = 0
            Chart_Ctrl.Legends(0).ForeColor = Color.Black
            Chart_Ctrl.Legends(0).BackColor = Color.Transparent
            Chart_Ctrl.Series.Add(genChartSeries)
            Chart_Ctrl.Series.Add(genChartSeries1)
            Chart_Ctrl.ChartAreas.Add(genChartArea)
            Chart_Ctrl.Titles.Add("")


            Chart_Ctrl.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Chart_Ctrl.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            Chart_Ctrl.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Chart_Ctrl.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            Chart_Ctrl.ChartAreas(0).CursorX.AutoScroll = True
            Chart_Ctrl.ChartAreas(0).CursorY.AutoScroll = True


            Page_Ctrl.Controls.Add(Chart_Ctrl)


            Chart_Ctrl.BringToFront()
            'Selected_Ctrl = Chart_Ctrl
            _iniChartName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DGraphToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub TrenderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrenderToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Trender_Ctrl = New MultiTrendCtrl

L1:
            If Ctrl_NameList.Contains("Trender" & _iniTrenderName) Then 'Assign Unique Name
                _iniTrenderName += 1
                GoTo L1
            End If

            Trender_Ctrl.Name = "Trender" & _iniTrenderName
            Trender_Ctrl.MinimumSize = Ctrl_MinSize

            'AddHandler Trender_Ctrl.ChartControl1.MouseClick, (AddressOf Ctrl_Click)
            'AddHandler Trender_Ctrl.ChartControl1.MouseDown, AddressOf Ctrl_MouseDown
            'AddHandler Trender_Ctrl.ChartControl1.MouseUp, AddressOf Ctrl_MouseUp
            'AddHandler Trender_Ctrl.ChartControl1.MouseMove, AddressOf Ctrl_MouseMove
            'AddHandler Trender_Ctrl.ChartControl1.MouseLeave, AddressOf Ctrl_MouseLeave

            Trender_Ctrl.ChartControl1.AccessibleDescription = "test"
            Trender_Ctrl.AutoSize = False
            Trender_Ctrl.Tag = "Trender"
            Trender_Ctrl.Width = 650
            Trender_Ctrl.Height = 400
            Trender_Ctrl.Location = New Point(150, 200)
            Trender_Ctrl.BackColor = Color.Transparent


            Trender_Ctrl.ChartControl1.AutoSize = False
            Trender_Ctrl.ChartControl1.Width = 640
            Trender_Ctrl.ChartControl1.Height = 300
            Trender_Ctrl.ChartControl1.Location = New Point(5, 5)

            Trender_Ctrl.DataGridViewCtrl1.AutoSize = False
            Trender_Ctrl.DataGridViewCtrl1.Width = 640
            Trender_Ctrl.DataGridViewCtrl1.Height = 100
            Trender_Ctrl.DataGridViewCtrl1.Location = New Point(5, 305)

            Trender_Ctrl.ChartControl1.Series.Clear()

            Dim genChartSeries As New Series
            Dim genChartSeries1 As New Series
            Dim genChartArea As New ChartArea
            Trender_Ctrl.BackColor = Color.WhiteSmoke
            genChartArea.BackColor = Color.WhiteSmoke
            genChartArea.Axes(0).LineColor = Color.Black
            genChartArea.Axes(1).LineColor = Color.Black
            genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
            genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines

            genChartArea.AxisX.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisY.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)

            genChartArea.Axes(0).LabelStyle.ForeColor = Color.Black
            genChartArea.Axes(1).LabelStyle.ForeColor = Color.Black

            genChartArea.Axes(0).MajorTickMark.LineColor = Color.Black
            genChartArea.Axes(1).MajorTickMark.LineColor = Color.Black

            genChartArea.Axes(0).Title = "X- Axis"
            genChartArea.Axes(1).Title = "Y- Axis"

            genChartArea.Axes(0).TitleForeColor = Color.Black
            genChartArea.Axes(1).TitleForeColor = Color.Black

            genChartArea.Axes(0).MajorGrid.LineColor = Color.LightGray
            genChartArea.Axes(1).MajorGrid.LineColor = Color.LightGray

            genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
            genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

            'genChartArea.AxisX.Interval = 2
            ' genChartArea.AxisX.LabelStyle.IsStaggered=True
            'genChartArea.AxisX.LabelStyle.Angle=-45

            genChartArea.AxisY.Tag = "True"

            Trender_Ctrl.ChartControl1.BorderlineColor = Color.Black
            Trender_Ctrl.ChartControl1.BorderlineWidth = 1
            Trender_Ctrl.ChartControl1.BorderlineDashStyle = ChartDashStyle.Solid

            genChartArea.BorderWidth = 2

            'Chartseries()
            genChartSeries.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries.XValueType = ChartValueType.String
            genChartSeries.BorderWidth = 2
            genChartSeries.Name = "Series1"

            genChartSeries.MarkerColor = Color.Red
            genChartSeries.MarkerSize = 0
            genChartSeries.MarkerStyle = MarkerStyle.Triangle
            genChartSeries.ChartType = SeriesChartType.Line
            genChartSeries.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries.Color = Color.Green
            genChartSeries.IsValueShownAsLabel = True
            genChartSeries.LabelForeColor = Color.Black
            genChartSeries.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries.Points.AddXY("0", 5)
            genChartSeries.Points.AddXY("10", 49)
            genChartSeries.Points.AddXY("26", 58)
            genChartSeries.Points.AddXY("35", 14)
            genChartSeries.Points.AddXY("44", 70)
            genChartSeries.Points.AddXY("60", 49)
            genChartSeries.Points.AddXY("70", 62)
            genChartSeries.Points.AddXY("80", 19)

            'Chartseries1
            genChartSeries1.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries1.XValueType = ChartValueType.String
            genChartSeries1.BorderWidth = 2
            genChartSeries1.Name = "Series2"

            genChartSeries1.MarkerColor = Color.Red
            genChartSeries1.MarkerSize = 0
            genChartSeries1.MarkerStyle = MarkerStyle.Triangle
            genChartSeries1.ChartType = SeriesChartType.Line
            genChartSeries1.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries1.Color = Color.Orange
            genChartSeries1.IsValueShownAsLabel = True
            genChartSeries1.LabelForeColor = Color.Black
            genChartSeries1.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries1.Points.AddXY("0", 10)
            genChartSeries1.Points.AddXY("14", 43)
            genChartSeries1.Points.AddXY("30", 95)
            genChartSeries1.Points.AddXY("38", 110)
            genChartSeries1.Points.AddXY("50", 85)
            genChartSeries1.Points.AddXY("62", 74)
            genChartSeries1.Points.AddXY("75", 69)
            genChartSeries1.Points.AddXY("90", 50)


            Trender_Ctrl.ChartControl1.Legends.Add("Series1")
            Trender_Ctrl.ChartControl1.Legends.Add("Series2")
            Trender_Ctrl.ChartControl1.Legends(0).Enabled = True
            Trender_Ctrl.ChartControl1.Legends(0).Alignment = StringAlignment.Far
            Trender_Ctrl.ChartControl1.Legends(0).Position.Auto = True
            'Trender_Ctrl.ChartControl1.Legends(0).Position.Height = 15
            ' Trender_Ctrl.ChartControl1.Legends(0).Position.X = 30
            'Trender_Ctrl.ChartControl1.Legends(0).Position.Y = 0
            Trender_Ctrl.ChartControl1.Legends(0).ForeColor = Color.Black
            Trender_Ctrl.ChartControl1.Legends(0).BackColor = Color.Transparent
            Trender_Ctrl.ChartControl1.Series.Add(genChartSeries)
            Trender_Ctrl.ChartControl1.Series.Add(genChartSeries1)
            Trender_Ctrl.ChartControl1.ChartAreas.Add(genChartArea)
            Trender_Ctrl.ChartControl1.Titles.Add("")


            Trender_Ctrl.ChartControl1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            Trender_Ctrl.ChartControl1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            Trender_Ctrl.ChartControl1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            Trender_Ctrl.ChartControl1.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            Trender_Ctrl.ChartControl1.ChartAreas(0).CursorX.AutoScroll = True
            Trender_Ctrl.ChartControl1.ChartAreas(0).CursorY.AutoScroll = True




            Page_Ctrl.Controls.Add(Trender_Ctrl)


            Trender_Ctrl.BringToFront()
            'Selected_Ctrl = Chart_Ctrl
            _iniTrenderName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DGraphToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub


    'Tabel Ctrl
    Private Sub TableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
L1:
            If Ctrl_NameList.Contains("Table" & _iniTableName) Then
                _iniTableName += 1
                GoTo L1
            End If


            Grid_TableCtrl = New DataGridViewCtrl
            Grid_TableCtrl.Name = "Table" & _iniTableName
            Grid_TableCtrl.MinimumSize = GridCtrl_MinSize

            Grid_TableCtrl.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            Grid_TableCtrl.AccessibleDescription = ""
            AddHandler Grid_TableCtrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Grid_TableCtrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Grid_TableCtrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Grid_TableCtrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Grid_TableCtrl.MouseLeave, AddressOf Ctrl_MouseLeave
            'AddHandler Grid_TableCtrl.ColumnHeaderMouseClick, AddressOf Grid_Table_Sort

            Grid_TableCtrl.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Grid_TableCtrl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            Grid_TableCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            Grid_TableCtrl.Tag = "Grid"
            Grid_TableCtrl.Width = 250
            Grid_TableCtrl.Height = 350
            Grid_TableCtrl.Location = New Point(150, 200)
            Grid_TableCtrl.BackColor = Color.WhiteSmoke

            Grid_TableCtrl.RowHeadersVisible = False

            Grid_TableCtrl.MultiSelect = False
            Grid_TableCtrl.AllowUserToAddRows = False
            Grid_TableCtrl.ReadOnly = True

            Grid_TableCtrl.RowsDefaultCellStyle.BackColor = Color.White
            Grid_TableCtrl.RowsDefaultCellStyle.ForeColor = Color.Black
            Grid_TableCtrl.RowsDefaultCellStyle.SelectionBackColor = Color.Gold
            Grid_TableCtrl.RowsDefaultCellStyle.SelectionForeColor = Color.Maroon

            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.Gold
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Maroon

            'Font
            Grid_TableCtrl.RowsDefaultCellStyle.Font = New Font("Verdana", 9, FontStyle.Regular)
            Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font = New Font("Verdana", 9, FontStyle.Regular)




            Grid_TableCtrl.Font = New Font("Verdana", 9, FontStyle.Bold)
            Page_Ctrl.Controls.Add(Grid_TableCtrl) 'Add Grid_TableCtrl in panel

            Grid_TableCtrl.BringToFront()
            _iniTableName += 1
            'Selected_Ctrl = Grid_TableCtrl
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GridTableToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    'Panel
    Private Sub PanelToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Panel_Ctrl = New Panel
            Panel_Ctrl.Name = "Panel" & _iniPanelName
            Panel_Ctrl.Tag = "Panel"
            Panel_Ctrl.MinimumSize = Ctrl_MinSize

            Panel_Ctrl.BorderStyle = BorderStyle.None

            AddHandler Panel_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Panel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Panel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Panel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Panel_Ctrl.Paint, AddressOf panel_Ctrl_Paint
            AddHandler Panel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Panel_Ctrl.AccessibleDescription = "Edge"
            Panel_Ctrl.Height = 250
            Panel_Ctrl.Width = 200
            Panel_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Panel_Ctrl)

            'Selected_Ctrl = Panel_Ctrl

            Panel_Ctrl.SendToBack()
            Call Border(Panel_Ctrl)
            _iniPanelName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TextToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub panel_Ctrl_Paint(ByVal sender As Object, ByVal e As EventArgs)

        MyBase.OnPaint(e)
        Dim g As Graphics = sender.CreateGraphics()

        'ControlPaint.DrawBorder3D(g, sender.clientRectangle, Border3DStyle.Raised, Border3DSide.All)
        ' Panel_Ctrl.Refresh()
        If Panel_Ctrl.AccessibleDescription = "Edge" Then
            'Dim g As Graphics = sender.CreateGraphics()

            Dim panelRect As Rectangle = sender.ClientRectangle

            Dim p1 As Point = New Point(panelRect.Left, panelRect.Top)  'top left
            Dim p2 As Point = New Point(panelRect.Right - 1, panelRect.Top)  'Top Right
            Dim p3 As Point = New Point(panelRect.Left, panelRect.Bottom - 1)  'Bottom Left
            Dim p4 As Point = New Point(panelRect.Right - 1, panelRect.Bottom - 1)  'Bottom        Right

            Dim pen1 As Pen = New Pen(System.Drawing.Color.White, 2)
            Dim pen2 As Pen = New Pen(System.Drawing.Color.FromKnownColor(KnownColor.ControlDark), 2)

            g.DrawLine(pen1, p1, p2)
            g.DrawLine(pen1, p1, p3)
            g.DrawLine(pen2, p2, p4)
            g.DrawLine(pen2, p3, p4)
        Else
            Panel_Ctrl.BorderStyle = BorderStyle.None
        End If

    End Sub


    'Picture Box
    Private Sub PicturePanelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicturePanelToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            PictureBox_Ctrl = New PictureBox
            PictureBox_Ctrl.Name = "Pic" & _iniPicName
            PictureBox_Ctrl.Tag = "PicBox"
            PictureBox_Ctrl.MinimumSize = Ctrl_MinSize

            AddHandler PictureBox_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler PictureBox_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler PictureBox_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler PictureBox_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler PictureBox_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            PictureBox_Ctrl.Height = 100
            PictureBox_Ctrl.Width = 250

            PictureBox_Ctrl.Location = New Point(150, 200)
            PictureBox_Ctrl.BackColor = Color.Transparent
            PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Center
            'PictureBox_Ctrl.BorderStyle = BorderStyle.FixedSingle
            Page_Ctrl.Controls.Add(PictureBox_Ctrl)
            PictureBox_Ctrl.AccessibleDescription = "(None)"

            PictureBox_Ctrl.SendToBack()
            Call Border(PictureBox_Ctrl)
            _iniPicName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PicturePanelToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_TableProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TableProperty.Click

        GridPropertiesForm.txtComponentName.Text = Grid_TableCtrl.Name
        GridPropertiesForm.Channel_Text = Grid_TableCtrl.AccessibleDescription
        GridPropertiesForm.color_BackColorlbl.BackColor = Grid_TableCtrl.RowsDefaultCellStyle.BackColor
        GridPropertiesForm.Color_forecolorlbl.BackColor = Grid_TableCtrl.RowsDefaultCellStyle.ForeColor
        GridPropertiesForm.ColorSL_BClbl.BackColor = Grid_TableCtrl.RowsDefaultCellStyle.SelectionBackColor
        GridPropertiesForm.ColorSL_FC.BackColor = Grid_TableCtrl.RowsDefaultCellStyle.SelectionForeColor

        GridPropertiesForm.ColorAL_BClbl.BackColor = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.BackColor
        GridPropertiesForm.ColorAL_FC.BackColor = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.ForeColor

        'Font
        Dim cFont, alFont As Font
        cFont = Grid_TableCtrl.RowsDefaultCellStyle.Font
        alFont = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font
        GridPropertiesForm.txtFont.Text = cFont.Name & "," & cFont.Size & "," & cFont.Style.ToString
        GridPropertiesForm.txtAL_Font.Text = alFont.Name & "," & alFont.Size & "," & alFont.Style.ToString

        GridPropertiesForm.C_font = Grid_TableCtrl.RowsDefaultCellStyle.Font
        GridPropertiesForm.AL_Font = Grid_TableCtrl.AlternatingRowsDefaultCellStyle.Font
        GridPropertiesForm.GVTHValue.Rows.Clear()
        For i As Integer = 0 To Grid_TableCtrl._ThresholdValue.Count - 1
            GridPropertiesForm.GVTHValue.Rows.Add()
            Dim tt() As String = Grid_TableCtrl._ThresholdValue(i).Split("@")
            GridPropertiesForm.GVTHValue.Rows(i).Cells(0).Value = tt(0)
            GridPropertiesForm.GVTHValue.Rows(i).Cells(1).Value = tt(1)
            GridPropertiesForm.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(Grid_TableCtrl._THForeColor(i))
            GridPropertiesForm.GVTHValue.Rows(i).Cells(3).Style.BackColor = Color.FromArgb(Grid_TableCtrl._THBackColor(i))
            GridPropertiesForm.GVTHValue.Rows(i).Cells(4).Value = Grid_TableCtrl._THFont(i)
        Next

        GridPropertiesForm.ShowDialog()
    End Sub

    'OPC Channel Part
    '-------------------
    Private Sub MS_OPCChannelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_OPCChannelAdd.Click
        OpcChaneelListForm.ShowDialog()
    End Sub

    Private Sub ViewDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewDataToolStripMenuItem.Click
        Dim i = PageTreeView.SelectedNode.Index

        If Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(i) Is Nothing Then
            opcCnfgTags(i).Text = PageTreeView.SelectedNode.ToolTipText
            opcCnfgTags(i).Show()
        End If


    End Sub
    Private Sub viewSAMAHistorianChnl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewSAMAHistorianChnl.Click
        Dim i = PageTreeView.SelectedNode.Index

        Dim SAMAHistorianDF As SAMAHistorianChannelDataform
        If SAMAHistorian_ChannelList.ChannelReportname.Contains(PageTreeView.SelectedNode.Text) Then
            Dim RptIndx = SAMAHistorian_ChannelList.ChannelReportname.IndexOf(PageTreeView.SelectedNode.Text)
            SAMAHistorianDF = New SAMAHistorianChannelDataform(SAMAHistorian_ChannelList.ChannelDatatable.Item(RptIndx), PageTreeView.SelectedNode.Text)
            SAMAHistorianDF.Show()
        End If
    End Sub
    Private Sub MS_DBDataForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_DBDataForm.Click

        'Dim i = PageTreeView.SelectedNode.Index
        'If Not DBDataFormClass Is Nothing AndAlso Not DBDataFormClass(i) Is Nothing Then
        '    DBDataFormClass(i).Text = "DB Channel-" & DBDataFormClass(i).Name
        '    DBDataFormClass(i).Show()
        'End If
    End Sub
    Private Sub MS_AddPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_AddPage.Click
        Dim addPageForm As New PageProperties
        addPageForm.Text = "Page Add"
        addPageForm.txtPageName.Text = "Page" & _iniPageName
        addPageForm.txtPageName.Tag = _iniPageName.ToString()

        addPageForm.ShowDialog()
    End Sub

    Private Sub MS_DeletePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_DeletePage.Click
        If MessageBox.Show("Do you want to Delete this page", "Message !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            CreatedPages.Remove(TreeViewLeft.SelectedNode.Name)
            Page_Ctrl.Controls.Clear()
            Page_Ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
            TreeViewLeft.SelectedNode.Remove()
            _iniPageName -= 1
            'Dim cnt As Integer = PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
            'PageTreeView.SelectedNode = PageTreeView.Nodes(0).Nodes(2).Nodes(cnt)
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
        End If

    End Sub

    Private Sub PrintDoc_Table_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc_Table.PrintPage
        Dim more As Boolean = PrintGrid.DrawDataGridView(e.Graphics)
        If more = True Then
            e.HasMorePages = True
        End If
    End Sub

    Private Sub MS_TablePrinterSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TablePrinterSetting.Click
        Try
            If SetupThePrinting(Grid_TableCtrl) Then
                Dim myPrintPreviewDialog As New PrintPreviewDialog
                myPrintPreviewDialog.Document = PrintDoc_Table
                myPrintPreviewDialog.ShowDialog()
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_TablePrinterSetting_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub MS_TablePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TablePrint.Click
        Dim prntdlg As New PrintDialog
        If prntdlg.ShowDialog = DialogResult.OK Then
            PrintDoc_Table.PrinterSettings.PrinterName = prntdlg.PrinterSettings.PrinterName
            PrintDoc_Table.PrintController = New StandardPrintController
            If SetupThePrinting(Grid_TableCtrl) Then
                PrintDoc_Table.Print()
            End If
        End If
    End Sub
    ''' <summary>
    ''' Printing Setup
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetupThePrinting(ByVal Grid_TableCtrl As DataGridViewCtrl) As Boolean
        '========Individual User Status tab=====
        'PrintDoc_MainPage.DefaultPageSettings.Margins =new Margins(30, 30, 30, 30)
        Dim title As String = ""
        Dim result = MessageBox.Show("Print Table with Title ?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim val As String = InputBox("Please Enter the Title", "Title")
            title = val
        End If
        PrintGrid = New DataGridViewPrinter(Grid_TableCtrl, PrintDoc_Table, False, True, title, New Font("Verdana", 9, FontStyle.Bold, GraphicsUnit.Point),
          Color.Black, True)
        Return True
    End Function

    Private Sub MS_TableExpo_Csv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_TableExpo_Csv.Click
        Call Export_GridTable(Grid_TableCtrl)
    End Sub
    ''' <summary>
    ''' Grid table Content Export to .CSV File
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Export_GridTable(ByVal Grid_TableCtrl As DataGridViewCtrl)
        Try
            Dim savefldlg As New SaveFileDialog
            Dim fname As String = ""
            Dim s As StreamWriter
            savefldlg.Filter = ("CSV Files|.csv")
            savefldlg.FilterIndex = 0

            If savefldlg.ShowDialog = DialogResult.OK Then
                fname = savefldlg.FileName

                Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
                s = New StreamWriter(fs)
                Dim Msg As String = ""
                For j = 0 To Grid_TableCtrl.ColumnCount - 1
                    Msg &= " " & Grid_TableCtrl.Columns(j).HeaderText & ","
                Next
                Msg &= vbNewLine
                's.BaseStream.Seek(0, SeekOrigin.End)
                For i = 0 To Grid_TableCtrl.RowCount - 1
                    For j = 0 To Grid_TableCtrl.ColumnCount - 1
                        Msg &= " " & Grid_TableCtrl(j, i).Value.ToString & ","
                    Next
                    Msg &= vbNewLine
                Next
                s.WriteLine(Msg)
                s.Close()

            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Export_GridTable()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub
    'Private Sub ReleaseObject(ByVal obj As Object)
    '    Try
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '        obj = Nothing
    '    Catch ex As Exception
    '        obj = Nothing
    '    Finally
    '        GC.Collect()
    '    End Try
    'End Sub

    'For charting

    Private Sub MS_ChartPrinterSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartPrinterSetting.Click
        Dim printPreviewdlg As New PrintPreviewDialog()
        printPreviewdlg.Document = PrintDoc_Chart

        If printPreviewdlg.ShowDialog() = DialogResult.OK Then
            PrintDoc_Chart.Print()
        End If

    End Sub

    Private Sub MS_ChartPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartPrint.Click
        Dim printdlg As New PrintDialog
        printdlg.Document = PrintDoc_Chart
        If printdlg.ShowDialog() = DialogResult.OK Then
            PrintDoc_Chart.Print()
        End If
    End Sub

    Private Sub PrintDoc_Chart_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc_Chart.PrintPage
        Try
            Dim myImage As New Bitmap(Chart_Ctrl.Width, Chart_Ctrl.Height)
            Dim printSize As Size = e.MarginBounds.Size
            Dim scale As Double = 1
            Chart_Ctrl.DrawToBitmap(myImage, New Rectangle(Point.Empty, Chart_Ctrl.Size))
            printSize.Width *= 1.0 'convert to pixels
            printSize.Height *= 1.0
            If myImage.Width > printSize.Width Then
                'Form is to big. Scale it down.
                scale = printSize.Width / myImage.Width
                e.Graphics.ScaleTransform(scale, scale)
            End If
            If (myImage.Height * scale) > printSize.Height Then
                'The form is still to big. Scale it again.
                scale = printSize.Height / (myImage.Height * scale)
                e.Graphics.ScaleTransform(scale, scale)
            End If
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(myImage, e.MarginBounds.Location)
            myImage.Dispose()
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PrintDoc_Chart_PrintPage()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_ChartExpo_Img_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ChartExpo_Img.Click
        Dim savedlg As New SaveFileDialog
        savedlg.Filter = "Jepg File (*.Jpeg)|*.jpeg"
        savedlg.FilterIndex = 0
        If savedlg.ShowDialog = DialogResult.OK Then
            Chart_Ctrl.SaveImage(savedlg.FileName, ChartImageFormat.Jpeg)
        End If
    End Sub


    Private Sub DesignModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignModeToolStripMenuItem.Click
        If _runMode Then
            If Not _RetypePass = "" And Not _NewPass = "" And Not _oldPass = "" Then
                LoingToDesignMode.ShowDialog()
                If String.Equals(LoingToDesignMode.txtPassword.Text, _oldPass) Then
                    MSMenu.Visible = True
                    SplitContainer1.Panel2Collapsed = False
                    _runMode = False
                Else
                    MsgBox("Incorrect Password", MsgBoxStyle.Critical, "Warning!!!")
                End If
            Else
                MSMenu.Visible = True
                SplitContainer2.Visible = True
                TreeViewLeft.Visible = True
                'TreeViewReports.Visible = True
                SplitContainer1.Panel2Collapsed = False
                _runMode = False
            End If

        Else
            MSMenu.Visible = False
            SplitContainer1.Panel2Collapsed = True
            _runMode = True
        End If

    End Sub



    Private Sub ErrorLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorLogToolStripMenuItem.Click
        MainErrorPV.Dispose()
        ErrorLogForm.ShowDialog()
    End Sub

    Private Sub TaskSchedulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskSchedulerToolStripMenuItem.Click
        TaskSchedulerForm.ShowDialog()
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        MSMenu.Visible = False
        ' Leftpanel.Visible = False
        SplitContainer2.Visible = False
        'TreeViewLeft.Visible = False
        'TreeViewReports.Visible = False
        SplitContainer1.Panel2Collapsed = True
        _runMode = True
    End Sub

    Private Sub HideGridLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideGridLineToolStripMenuItem.Click
        Grid_TableCtrl.CellBorderStyle = DataGridViewCellBorderStyle.None
    End Sub

    Private Sub ShowGridLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowGridLineToolStripMenuItem.Click
        Grid_TableCtrl.CellBorderStyle = DataGridViewCellBorderStyle.Single
    End Sub

    Private Sub StartChannelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartChannelToolStripMenuItem.Click
        Try
            Dim i = PageTreeView.SelectedNode.Index
            If Not DBDataFormClass Is Nothing AndAlso Not DBDataFormClass(i) Is Nothing Then

                If PageTreeView.SelectedNode.Tag = "False" Then
                    PageTreeView.SelectedNode.Tag = "True"
                    If Server_Flag Then
                        DBDataFormClass(i).Q_Timer.Start()
                    Else
                        DBDataFormClass(i).Watcher.EnableRaisingEvents = True
                    End If

                    PageTreeView.SelectedNode.ImageIndex = 4
                    PageTreeView.SelectedNode.SelectedImageIndex = 4
                End If



            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DB:StartChannelToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub StopChannelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopChannelToolStripMenuItem.Click
        Try
            Dim i = PageTreeView.SelectedNode.Index
            If Not DBDataFormClass Is Nothing AndAlso Not DBDataFormClass(i) Is Nothing Then
                If PageTreeView.SelectedNode.Tag = "True" Then
                    PageTreeView.SelectedNode.Tag = "False"
                    If Server_Flag Then
                        DBDataFormClass(i).Q_Timer.Stop()
                    Else
                        DBDataFormClass(i).Watcher.EnableRaisingEvents = False
                    End If
                    PageTreeView.SelectedNode.ImageIndex = 5
                    PageTreeView.SelectedNode.SelectedImageIndex = 5
                End If

            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DB:StopChannelToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        Try
            Dim i = PageTreeView.SelectedNode.Index
            If Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(i) Is Nothing Then

                If PageTreeView.SelectedNode.Tag = "False" Then
                    PageTreeView.SelectedNode.Tag = "True"
                    If Server_Flag Then
                        If Not opcCnfgTags(i)._asyncRefrGroup Is Nothing Then
                            Dim Itemdata As ItemDef
                            Dim OPC_Item() As String = OPC_ChannelList_Class.OPC_OPCItems(i).Split(",")
                            For k As Integer = 0 To OPC_Item.Length - 1
                                Itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                If Itemdata Is Nothing Then     ' probably first use
                                    opcCnfgTags(i)._asyncRefrGroup.Add(OPC_Item(k))      ' add item to group if not found
                                End If
                                Itemdata = opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                If Itemdata Is Nothing Then     ' there is a problem
                                    MsgBox("Item not found.")
                                    Exit For
                                End If
                            Next

                        End If

                    Else
                        opcCnfgTags(i).Watcher.EnableRaisingEvents = True
                    End If

                    PageTreeView.SelectedNode.ImageIndex = 4
                    PageTreeView.SelectedNode.SelectedImageIndex = 4
                End If



            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC:RunToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Try
            Dim idx = PageTreeView.SelectedNode.Index
            If Not opcCnfgTags Is Nothing AndAlso Not opcCnfgTags(idx) Is Nothing Then
                If PageTreeView.SelectedNode.Tag = "True" Then
                    PageTreeView.SelectedNode.Tag = "False"
                    If Server_Flag Then
                        If Not opcCnfgTags(idx) Is Nothing AndAlso Not opcCnfgTags(idx)._asyncRefrGroup Is Nothing Then
                            Dim item() As ItemDef = opcCnfgTags(idx)._asyncRefrGroup.GetItemsInGroup()
                            For j As Integer = 0 To item.Length - 1
                                opcCnfgTags(idx)._asyncRefrGroup.Remove(item(j).OpcIDef.ItemID)
                            Next

                            opcCnfgTags(idx).Close() 'Close Forms
                        End If
                    Else
                        opcCnfgTags(idx).Watcher.EnableRaisingEvents = False
                    End If
                    PageTreeView.SelectedNode.ImageIndex = 5
                    PageTreeView.SelectedNode.SelectedImageIndex = 5
                End If

            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC:StopToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub Chart3DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chart3DToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Chart_Ctrl = New ChartControl
L1:
            If Ctrl_NameList.Contains("Chart" & _iniChartName) Then 'Assign Unique Name
                _iniChartName += 1
                GoTo L1
            End If

            Chart_Ctrl.Name = "Chart" & _iniChartName
            Chart_Ctrl.MinimumSize = Ctrl_MinSize

            AddHandler Chart_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Chart_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Chart_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Chart_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Chart_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Chart_Ctrl.AutoSize = False
            Chart_Ctrl.Tag = "Chart"
            Chart_Ctrl.Width = 650
            Chart_Ctrl.Height = 270
            Chart_Ctrl.Location = New Point(150, 200)
            Dim genChartSeries As New Series
            Dim genChartArea As New ChartArea
            Chart_Ctrl.BackColor = Color.WhiteSmoke
            genChartArea.BackColor = Color.WhiteSmoke
            genChartArea.Axes(0).LineColor = Color.Black
            genChartArea.Axes(1).LineColor = Color.Black
            genChartArea.Axes(0).ArrowStyle = AxisArrowStyle.Lines
            genChartArea.Axes(1).ArrowStyle = AxisArrowStyle.Lines

            genChartArea.AxisX.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisY.LabelStyle.Font = New Font("Verdana", 8, FontStyle.Regular)

            genChartArea.Axes(0).LabelStyle.ForeColor = Color.Black
            genChartArea.Axes(1).LabelStyle.ForeColor = Color.Black

            genChartArea.Axes(0).MajorTickMark.LineColor = Color.Black
            genChartArea.Axes(1).MajorTickMark.LineColor = Color.Black

            genChartArea.Axes(0).Title = "X- Axis"
            genChartArea.Axes(1).Title = "Y- Axis"

            genChartArea.Axes(0).TitleForeColor = Color.Black
            genChartArea.Axes(1).TitleForeColor = Color.Black

            genChartArea.Axes(0).MajorGrid.LineColor = Color.LightGray
            genChartArea.Axes(1).MajorGrid.LineColor = Color.LightGray

            genChartArea.Axes(0).MajorGrid.LineDashStyle = ChartDashStyle.Dash
            genChartArea.Axes(1).MajorGrid.LineDashStyle = ChartDashStyle.Dash

            'Enable 3D Style
            genChartArea.Area3DStyle.Enable3D = True

            'genChartArea.AxisX.Interval = 2
            ' genChartArea.AxisX.LabelStyle.IsStaggered=True
            'genChartArea.AxisX.LabelStyle.Angle=-45

            genChartArea.AxisY.Tag = "True"

            Chart_Ctrl.BorderlineColor = Color.Black
            Chart_Ctrl.BorderlineWidth = 1
            Chart_Ctrl.BorderlineDashStyle = ChartDashStyle.Solid

            genChartArea.BorderWidth = 2

            'GenChartSeries.ToolTip = "#VALX,#VAL{N}"
            genChartSeries.ToolTip = genChartArea.Axes(1).Title & ": #VALY," & genChartArea.Axes(0).Title & ": #VALX"
            genChartSeries.XValueType = ChartValueType.String
            genChartSeries.BorderWidth = 2
            genChartSeries.Name = "Series1"


            genChartSeries.MarkerColor = Color.Red
            genChartSeries.MarkerSize = 0
            genChartSeries.MarkerStyle = MarkerStyle.Triangle
            genChartSeries.ChartType = SeriesChartType.Line
            genChartSeries.BorderDashStyle = ChartDashStyle.Solid
            genChartSeries.Color = Color.Green
            genChartSeries.IsValueShownAsLabel = True
            genChartSeries.LabelForeColor = Color.Black
            genChartSeries.Font = New Font("Verdana", 8, FontStyle.Regular)
            genChartArea.AxisX.IntervalType = DateTimeIntervalType.Number
            genChartArea.AxisX.IntervalOffset = DateTimeIntervalType.Number
            genChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount
            genChartSeries.Points.AddXY("0", 5)
            genChartSeries.Points.AddXY("10", 49)
            genChartSeries.Points.AddXY("26", 58)
            genChartSeries.Points.AddXY("35", 14)
            genChartSeries.Points.AddXY("44", 70)
            genChartSeries.Points.AddXY("60", 49)
            genChartSeries.Points.AddXY("70", 62)
            genChartSeries.Points.AddXY("80", 19)

            Chart_Ctrl.Legends.Add("Series1")
            Chart_Ctrl.Legends(0).Enabled = True
            Chart_Ctrl.Legends(0).Alignment = StringAlignment.Far
            Chart_Ctrl.Legends(0).Position.Width = 100
            Chart_Ctrl.Legends(0).Position.Height = 10
            Chart_Ctrl.Legends(0).Position.X = 70
            Chart_Ctrl.Legends(0).Position.Y = 0
            Chart_Ctrl.Legends(0).ForeColor = Color.Black
            Chart_Ctrl.Legends(0).BackColor = Color.Transparent

            Chart_Ctrl.Legends(0).Alignment = StringAlignment.Far

            Chart_Ctrl.Series.Add(genChartSeries)
            Chart_Ctrl.ChartAreas.Add(genChartArea)
            Chart_Ctrl.Titles.Add("")
            Page_Ctrl.Controls.Add(Chart_Ctrl)

            Chart_Ctrl.BringToFront()
            'Selected_Ctrl = Chart_Ctrl
            _iniChartName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DGraphToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    'Log Book Ctrl Part
    Private Sub LogBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogBookToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            LogCtrl = New LogViewer
            LogCtrl.Size = New Size(600, 400)
            LogCtrl.Name = "LogBook" & _iniLogBookName
            LogCtrl.Tag = "LogBook"
            LogCtrl.TabPages(0).Text = "Log Book" & _iniLogBookName
            AddHandler LogCtrl.MouseClick, (AddressOf Ctrl_Click)

            LogCtrl.Location = Cursor.Position

            Page_Ctrl.Controls.Add(LogCtrl)
            LogCtrl.BringToFront()
            _iniLogBookName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LogBookToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub MS_LBProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LBProperties.Click
        Dim LogctrlPropFrm As New LogCtrlProperties
        If Not String.IsNullOrEmpty(LogCtrl.File_Path) Then
            If LogCtrl.isLatest Then
                LogctrlPropFrm.cboxOption.SelectedIndex = 0
            Else
                LogctrlPropFrm.cboxOption.SelectedIndex = 1
                LogctrlPropFrm.nudnnhours.Value = LogCtrl.nnHour
            End If
            LogctrlPropFrm.txtPath.Text = LogCtrl.File_Path
            LogctrlPropFrm.txtdelimiter.Text = LogCtrl.Delimiter
            If Not String.IsNullOrEmpty(LogCtrl.Extension) Then
                LogctrlPropFrm.cboxExtension.SelectedItem = LogCtrl.Extension
            End If
        Else
            LogctrlPropFrm.nudnnhours.Enabled = False
            LogctrlPropFrm.txtdelimiter.Enabled = False
        End If


        LogctrlPropFrm.ShowDialog()
    End Sub

    Private Sub MS_LBClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LBClear.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If

            Page_Ctrl.Controls.Remove(LogCtrl)

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_LBClear_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_LBS_to_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LBS_to_B.Click
        LogCtrl.SendToBack()
    End Sub

    Private Sub MS_LBB_to_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LBB_to_F.Click
        LogCtrl.BringToFront()
    End Sub
    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        If Not LogCtrl.isTimerStart Then
            LogCtrl.tmrAutoUpdate.Start()
            LogCtrl.isTimerStart = True
        End If

    End Sub

    Private Sub StopToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem1.Click
        If LogCtrl.isTimerStart Then
            LogCtrl.tmrAutoUpdate.Stop()
            LogCtrl.isTimerStart = False
        End If
    End Sub

    Private Sub MS_LBPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LBPrint.Click
        If LogCtrl.TabPages(0).Controls.Count > 0 AndAlso Not TypeOf LogCtrl.TabPages(0).Controls(0) Is WebBrowser Then
            Dim prntdlg As New PrintDialog
            If prntdlg.ShowDialog = DialogResult.OK Then
                PdocGrid.PrinterSettings.PrinterName = prntdlg.PrinterSettings.PrinterName
                PdocGrid.PrintController = New StandardPrintController

                If TypeOf LogCtrl.TabPages(0).Controls(0) Is DataGridView Then
                    If LogBookSetupThePrinting() Then
                        PdocGrid.Print()
                    End If
                End If
                If TypeOf LogCtrl.TabPages(0).Controls(0) Is RichTextBox Then
                    PdocRText.PrinterSettings.PrinterName = prntdlg.PrinterSettings.PrinterName
                    PdocRText.PrintController = New StandardPrintController
                    ReadFile()
                    PdocRText.Print()
                End If


            End If
        End If
    End Sub
    ''' <summary>
    ''' Printing Setup
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LogBookSetupThePrinting() As Boolean
        LogBookPrintGrid = New LogViewerDataGridViewPrinter(LogCtrl.TabPages(0).Controls(0), PdocGrid, False, True, "", New Font("Verdana", 8, FontStyle.Bold, GraphicsUnit.Point),
        Color.Black, True)
        Return True
    End Function

    Private stringToPrint As String = ""
    Private Sub ReadFile()
        For i As Integer = 0 To LogCtrl.TabPages.Count - 1
            Dim docName As String = LogCtrl.TabPages(i).Tag
            PdocRText.DocumentName = "RichText Printing"
            PdocRText.DefaultPageSettings.Margins = New Drawing.Printing.Margins(5, 5, 10, 5)
            'Dim stream As New FileStream(docName, FileMode.Open)
            Try
                'Dim reader As New StreamReader(stream)
                Try

                    'stringToPrint & = LogCtrl.TabPages(i).Text & vbCrLf & vbCrLf & vbCrLf & reader.ReadToEnd() & vbCrLf & vbCrLf & vbCrLf
                    stringToPrint &= LogCtrl.TabPages(i).Text & vbCrLf & vbCrLf & vbCrLf & LogCtrl.TabPages(i).Controls(0).Text & vbCrLf & vbCrLf & vbCrLf
                Finally
                    'reader.Dispose()
                End Try
            Finally
                'stream.Dispose()
            End Try
        Next

    End Sub

    Private Sub PdocRText_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PdocRText.PrintPage
        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0
        Dim _font As New Font("Courier New", 8, FontStyle.Regular)
        ' Sets the value of charactersOnPage to the number of characters  
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, _font, e.MarginBounds.Size,
             StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(stringToPrint, _font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

    End Sub

    Private Sub PdocGrid_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PdocGrid.PrintPage
        Dim more As Boolean = LogBookPrintGrid.DrawDataGridView(e.Graphics)
        If more = True Then
            e.HasMorePages = True
        End If
    End Sub


    Private Sub MainPage_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            DesignModeToolStripMenuItem_Click(sender, e)
            Page_Ctrl.Refresh()
        End If


    End Sub

    Private Sub AutoStartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStartToolStripMenuItem.Click
        AutoStartLocationForm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub lblAlert_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAlert.DoubleClick
        MainErrorPV.Dispose()
        ErrorLogForm.ShowDialog()
    End Sub

    Dim _errToolTip As New ToolTip
    Private Sub lblAlert_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAlert.MouseHover

        _errToolTip.SetToolTip(lblAlert, "Double Click to View Error Logs !!!")
    End Sub

    Private Sub EMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMailToolStripMenuItem.Click
        EMailSettingform.ShowDialog()
        PageTreeView.SelectedNode.ImageIndex = 2
        PageTreeView.SelectedNode.SelectedImageIndex = 2
    End Sub



    Private Sub AddEditChannelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditChannelToolStripMenuItem.Click

        SAMAHistorianChannels.ShowDialog()
    End Sub



    Private Sub RunSAMAHistorianChnl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunSAMAHistorianChnl.Click
        Try
            If SAMAHistorian_ChannelList.ChannelReportname.Contains(PageTreeView.SelectedNode.Text) Then
                Dim indx = SAMAHistorian_ChannelList.ChannelReportname.IndexOf(PageTreeView.SelectedNode.Text)
                If PageTreeView.SelectedNode.Tag = "False" Then
                    PageTreeView.SelectedNode.Tag = "True"
                    If SAMAHistorian_ChannelList.ChannelTimers.Contains(SAMAHistorian_ChannelList.ChannelTimers.Item(indx)) Then
                        SAMAHistorian_ChannelList.ChannelTimers.Item(indx).Start()
                    End If
                End If
            End If
            PageTreeView.SelectedNode.ImageIndex = 4
            PageTreeView.SelectedNode.SelectedImageIndex = 4
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_Channel Run()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub StopSAMAHistorianChnl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopSAMAHistorianChnl.Click
        Try
            If SAMAHistorian_ChannelList.ChannelReportname.Contains(PageTreeView.SelectedNode.Text) Then
                Dim indx = SAMAHistorian_ChannelList.ChannelReportname.IndexOf(PageTreeView.SelectedNode.Text)
                If PageTreeView.SelectedNode.Tag = "True" Then
                    PageTreeView.SelectedNode.Tag = "False"
                    If SAMAHistorian_ChannelList.ChannelTimers.Contains(SAMAHistorian_ChannelList.ChannelTimers.Item(indx)) Then
                        SAMAHistorian_ChannelList.ChannelTimers.Item(indx).Stop()
                    End If
                End If
            End If
            PageTreeView.SelectedNode.ImageIndex = 5
            PageTreeView.SelectedNode.SelectedImageIndex = 5
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_Channel Stop()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub




    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Page_Ctrl.Controls.Remove(Trender_Ctrl)
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Dim savedlg As New SaveFileDialog
        savedlg.Filter = "Jepg File (*.Jpeg)|*.jpeg"
        savedlg.FilterIndex = 0
        If savedlg.ShowDialog = DialogResult.OK Then
            Trender_Ctrl.ChartControl1.SaveImage(savedlg.FileName, ChartImageFormat.Jpeg)
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim printPreviewdlg As New PrintPreviewDialog()
        printPreviewdlg.Document = PrintDoc_Chart

        If printPreviewdlg.ShowDialog() = DialogResult.OK Then
            PrintDoc_Chart.Print()
        End If
    End Sub


    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        UsersForm.ShowDialog()
    End Sub


    'Symbols Part
#Region "Symbols Declaration Parts"

    Private _symATNKName As Integer = 1, _symAgitatorName As Integer = 1, _symBinName As Integer = 1, _symBlowerName As Integer = 1
    Private _symDistillationTowerName As Integer = 1, _symJacketedVesselName As Integer = 1, _symReactorName As Integer = 1, _symVesselName As Integer = 1
    Private _symFloatingRoofTankName As Integer = 1, _symGasHolderName As Integer = 1, _symPressureStorageVesselName As Integer = 1, _symWeighHopperName As Integer = 1
    Private _symCircuitBreakerKName As Integer = 1, _symManualContactorName As Integer = 1, _symDeltaConnectionName As Integer = 1, _symFuseName As Integer = 1
    Private _symMotorName As Integer = 1, _symStateIndicatorName As Integer = 1, _symTransformerName As Integer = 1, _symWyeConnectionName As Integer = 1
    Private _symLiquidFilterName As Integer = 1, _symVacuumFilterName As Integer = 1, _symExchangerName As Integer = 1, _symForcedAirExchangerName As Integer = 1
    Private _symFurnaceName As Integer = 1, _symRotaryKilnName As Integer = 1, _symCoolingTowerName As Integer = 1, _symEvaporatorName As Integer = 1
    Private _symFinnedExchangerName As Integer = 1, _symConveyorName As Integer = 1, _symMillName As Integer = 1, _symRollStandName As Integer = 1
    Private _symRotaryFeederName As Integer = 1, _symScrewConveyorName As Integer = 1, _symInlineMixerName As Integer = 1, _symReciprocatingCompressorName As Integer = 1
    Private _symCompressorName As Integer = 1, _symPumpName As Integer = 1, _symTurbineName As Integer = 1, _symCycloneSeparatorName As Integer = 1
    Private _symRotarySeparatorName As Integer = 1, _symSprayDryerName As Integer = 1

    Friend AdmosphericTank_Ctrl As New Admospheric_Tank
    Friend Agitator_Ctrl As New Agitator
    Friend Bin_Ctrl As New Bin
    Friend Blower_Ctrl As New Blower

    Friend DistillationTower_Ctrl As New Distillation_Tower
    Friend JacketedVessel_Ctrl As New Jacketed_Vessel
    Friend Reactor_Ctrl As New Reactor
    Friend Vessel_Ctrl As New Vessel
    Friend FloatingRoofTank_Ctrl As New FloatingRoof_Tank
    Friend GasHolder_Ctrl As New GAS_Holder
    Friend PressureStorageVessel_Ctrl As New PressureStorage_Vessel
    Friend WeighHopper_Ctrl As New Weigh_Hopper
    Friend CircuitBreaker_Ctrl As New Circuit_Breaker
    Friend ManualContactor_Ctrl As New ManualContactor
    Friend DeltaConnection_Ctrl As New Delta_Connection
    Friend Fuse_Ctrl As New Fuse
    Friend Motor_Ctrl As New Motor
    Friend StateIndicator_Ctrl As New StateIndicator
    Friend Transformer_Ctrl As New Transformer
    Friend WyeConnection_Ctrl As New WYE_Connection
    Friend LiquidFilter_Ctrl As New Liquid_Filter
    Friend VacuumFilter_Ctrl As New Vacuum_Filter
    Friend Exchanger_Ctrl As New Exchanger
    Friend ForcedAirExchanger_Ctrl As New Forced_Air_Exchanged
    Friend Furnace_Ctrl As New Furnace
    Friend RotaryKiln_Ctrl As New Rotary_Kiln
    Friend CoolingTower_Ctrl As New Cooling_Tower
    Friend Evaporator_Ctrl As New Evaporator
    Friend FinnedExchanger_Ctrl As New Finned_Exchanger
    Friend Conveyor_Ctrl As New Conveyor
    Friend Mill_Ctrl As New Mill
    Friend RollStand_Ctrl As New Roll_Stand
    Friend RotaryFeeder_Ctrl As New Rotary_Feeder
    Friend ScrewConveyor_Ctrl As New Screw_Conveyor
    Friend InlineMixer_Ctrl As New Inline_Mixer
    Friend ReciprocatingCompressor_Ctrl As New Reciprocating_Compressor
    Friend Compressor_Ctrl As New Compressor
    Friend Pump_Ctrl As New Pump
    Friend Turbine_Ctrl As New Turbine
    Friend CycloneSeparator_Ctrl As New Cyclone_Seperator
    Friend RotarySeparator_Ctrl As New Rotary_Seperator
    Friend SprayDryer_Ctrl As New Spray_Dryer




    Friend Symbol_Ctrl As Object
    Friend Switch_Ctrl As Object
    Private SymbolProp_Form As New SymbolPropertiesForm

    Private SwitchProp_Form As New SwitchPropertiesForm


#End Region


    ''' <summary>
    ''' Event Handler when Click On Ctrl Control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub Symbol_Click(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            If Not _runMode Then
                Page_Ctrl.Refresh()
                Past_Ctrl = sender

                If TypeOf Sender Is LevelIndicator Then
                    LevelIndicator_ctrl = sender
                    'Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        IndicatorProperties.Show(LevelIndicator_ctrl, e.X, e.Y)
                    End If
                ElseIf TypeOf Sender Is LineElbow Then
                    Line_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        LineProperties.Show(Line_Ctrl, e.X, e.Y)

                    End If
                ElseIf TypeOf Sender Is Valve Then
                    Valve_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        ValveProperties.Show(Valve_Ctrl, e.X, e.Y)

                    End If

                ElseIf (TypeOf sender Is Circuit_Breaker Or TypeOf sender Is ManualContactor) Then

                    Switch_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        SwitchProperties.Show(Switch_Ctrl, e.X, e.Y)

                    End If
                Else

                    Symbol_Ctrl = sender
                    Call Border(sender) 'Create Border
                    If e.Button = MouseButtons.Right Then
                        SymbolsProperties.Show(Symbol_Ctrl, e.X, e.Y)

                    End If

                End If
            End If

        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Symbol_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    'LevelIndicator

    Private Sub LevelIndicatorMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelIndicatorMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            LevelIndicator_ctrl = New LevelIndicator
            LevelIndicator_ctrl.Name = "Indicator" & _iniindicatorName
            LevelIndicator_ctrl.Tag = "Indicator"

            LevelIndicator_ctrl.MinimumSize = Ctrl_MinSize


            AddHandler LevelIndicator_ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler LevelIndicator_ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler LevelIndicator_ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler LevelIndicator_ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler LevelIndicator_ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            LevelIndicator_ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(LevelIndicator_ctrl)
            LevelIndicator_ctrl.BringToFront()
            _iniindicatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LevelIndicatorMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_IndicatorClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_IndicatorClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(LevelIndicator_ctrl)
    End Sub

    Private Sub MS_IndicatorS_to_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_IndicatorS_to_B.Click
        LevelIndicator_ctrl.SendToBack()
    End Sub

    Private Sub MS_IndicatorB_To_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_IndicatorB_To_F.Click
        LevelIndicator_ctrl.BringToFront()
    End Sub


    Private Sub MS_IndicatorProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_IndicatorProperties.Click
        Try
            LvlIndicatorProp_form = New IndicatorProperties


            LvlIndicatorProp_form.lblActiveColor.BackColor = LevelIndicator_ctrl.ActiveColor
            LvlIndicatorProp_form.lblCtrlBackColor.BackColor = LevelIndicator_ctrl.InActiveColor
            LvlIndicatorProp_form.forecolorlbl.BackColor = LevelIndicator_ctrl.ForeColor

            LvlIndicatorProp_form.txtStart.text = LevelIndicator_ctrl.RangeStart
            LvlIndicatorProp_form.txtEnd.text = LevelIndicator_ctrl.RangeEnd


            LvlIndicatorProp_form.txtlvlCount.text = LevelIndicator_ctrl.LevelsCount
            LvlIndicatorProp_form.Channel_Text = LevelIndicator_ctrl.AccessibleDescription

            If LevelIndicator_ctrl.Scale_Enabled Then
                LvlIndicatorProp_form.CKboxScaleEnable.Checked = True
            Else
                LvlIndicatorProp_form.CKboxScaleEnable.Checked = False

            End If

            LvlIndicatorProp_form.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Line Control

    Private Sub LineMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Line_Ctrl = New LineElbow
            Line_Ctrl.Name = "LineElbow" & _iniLineName
            Line_Ctrl.Tag = "LineElbow"

            Line_Ctrl.MinimumSize = Ctrl_MinSize


            AddHandler Line_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Line_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Line_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Line_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Line_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Line_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Line_Ctrl)
            Line_Ctrl.SendToBack()
            Call Border(Line_Ctrl)
            _iniLineName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LineMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_LineVClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LineVClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Line_Ctrl)
    End Sub

    Private Sub MS_LineVS_T_to_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LineVS_T_to_B.Click
        Line_Ctrl.SendToBack()
    End Sub

    Private Sub MS_LineVB_to_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LineVB_to_F.Click
        Line_Ctrl.BringToFront()
    End Sub

    Private Sub MS_LineVProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_LineVProperties.Click
        Try
            LineProp_form = New LinePropertiesForm



            LineProp_form.lblBackClr.BackColor = Line_Ctrl.D_Color1

            LineProp_form.txtThick.text = Line_Ctrl.PenSize
            LineProp_form.Channel_Text = Line_Ctrl.AccessibleDescription


            LineProp_form.GVTHValue.Rows.Clear()
            For i As Integer = 0 To Line_Ctrl._ThresholdValue.Count - 1
                LineProp_form.GVTHValue.Rows.Add()

                LineProp_form.GVTHValue.Rows(i).Cells(0).Value = Line_Ctrl._THCondition(i)
                LineProp_form.GVTHValue.Rows(i).Cells(1).Value = Line_Ctrl._ThresholdValue(i)
                LineProp_form.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(Line_Ctrl._THColor(i))

            Next


            LineProp_form.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Valve Control
    Private Sub ValveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValveToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Valve_Ctrl = New Valve
            Valve_Ctrl.Name = "Valve" & _iniValveName
            Valve_Ctrl.Tag = "Valve"

            Valve_Ctrl.MinimumSize = Ctrl_MinSize


            AddHandler Valve_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Valve_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Valve_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Valve_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Valve_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Valve_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Valve_Ctrl)
            Valve_Ctrl.BringToFront()

            Call Border(Valve_Ctrl)
            _iniValveName += 1
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ValveToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MS_ValveProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValveProperties.Click
        Try
            ValveProp_Form = New ValvePropertiesForm



            ValveProp_Form.lblBackClr.BackColor = Valve_Ctrl.D_Color1


            ValveProp_Form.Channel_Text = Valve_Ctrl.AccessibleDescription


            ValveProp_Form.GVTHValue.Rows.Clear()
            For i As Integer = 0 To Valve_Ctrl._ThresholdValue.Count - 1
                ValveProp_Form.GVTHValue.Rows.Add()

                ValveProp_Form.GVTHValue.Rows(i).Cells(0).Value = Valve_Ctrl._THCondition(i)
                ValveProp_Form.GVTHValue.Rows(i).Cells(1).Value = Valve_Ctrl._ThresholdValue(i)
                ValveProp_Form.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(Valve_Ctrl._THColor(i))

            Next


            ValveProp_Form.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub MS_ValveClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValveClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Valve_Ctrl)
    End Sub

    Private Sub MS_ValveS_to_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValveS_to_B.Click
        Valve_Ctrl.SendToBack()
    End Sub

    Private Sub MS_ValveB_to_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_ValveB_to_F.Click
        Valve_Ctrl.BringToFront()
    End Sub
    'Admospheric Tank Control
    Private Sub AtmosphericTankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtmosphericTankToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            AdmosphericTank_Ctrl = New Admospheric_Tank
            AdmosphericTank_Ctrl.Name = "AtmosphericTank" & _symATNKName
            AdmosphericTank_Ctrl.Tag = "AtmosphericTank"

            AdmosphericTank_Ctrl.MinimumSize = Ctrl_MinSize


            AddHandler AdmosphericTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler AdmosphericTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler AdmosphericTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler AdmosphericTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler AdmosphericTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            AdmosphericTank_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(AdmosphericTank_Ctrl)
            AdmosphericTank_Ctrl.BringToFront()

            Call Border(AdmosphericTank_Ctrl)
            _symATNKName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AtmosphericTankToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub AgitatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgitatorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Agitator_Ctrl = New Agitator
            Agitator_Ctrl.Name = "Agitator" & _symAgitatorName
            Agitator_Ctrl.Tag = "Agitator"




            AddHandler Agitator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Agitator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Agitator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Agitator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Agitator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Agitator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Agitator_Ctrl)
            Agitator_Ctrl.BringToFront()

            Call Border(Agitator_Ctrl)
            _symAgitatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AgitatorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub BinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BinToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Bin_Ctrl = New Bin
            Bin_Ctrl.Name = "Bin" & _symBinName
            Bin_Ctrl.Tag = "Bin"
            Bin_Ctrl.MinimumSize = Ctrl_MinSize



            AddHandler Bin_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Bin_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Bin_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Bin_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Bin_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Bin_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Bin_Ctrl)
            Agitator_Ctrl.BringToFront()

            Call Border(Bin_Ctrl)
            _symBinName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@BinToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub BlowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlowerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Blower_Ctrl = New Blower
            Blower_Ctrl.Name = "Blower" & _symBinName
            Blower_Ctrl.Tag = "Blower"




            AddHandler Blower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Blower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Blower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Blower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Blower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Blower_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Blower_Ctrl)
            Blower_Ctrl.BringToFront()

            'Call Border(Blower_Ctrl)
            _symBinName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@BlowerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub


    Private Sub DistillationTowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistillationTowerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            DistillationTower_Ctrl = New Distillation_Tower
            DistillationTower_Ctrl.Name = "DistillationTower" & _symDistillationTowerName
            DistillationTower_Ctrl.Tag = "DistillationTower"




            AddHandler DistillationTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler DistillationTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler DistillationTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler DistillationTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler DistillationTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            DistillationTower_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(DistillationTower_Ctrl)
            DistillationTower_Ctrl.BringToFront()

            'Call Border(DistillationTower_Ctrl)
            _symDistillationTowerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DistillationTowerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub JacketedVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JacketedVesselToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            JacketedVessel_Ctrl = New Jacketed_Vessel
            JacketedVessel_Ctrl.Name = "JacketedVessel" & _symJacketedVesselName
            JacketedVessel_Ctrl.Tag = "JacketedVessel"




            AddHandler JacketedVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler JacketedVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler JacketedVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler JacketedVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler JacketedVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            JacketedVessel_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(JacketedVessel_Ctrl)
            JacketedVessel_Ctrl.BringToFront()

            'Call Border(JacketedVessel_Ctrl)
            _symJacketedVesselName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@JacketedVesselToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ReactorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReactorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Reactor_Ctrl = New Reactor
            Reactor_Ctrl.Name = "Reactor" & _symReactorName
            Reactor_Ctrl.Tag = "Reactor"




            AddHandler Reactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Reactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Reactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Reactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Reactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Reactor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Reactor_Ctrl)
            Reactor_Ctrl.BringToFront()

            'Call Border(Reactor_Ctrl)
            _symReactorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ReactorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub VesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VesselToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Vessel_Ctrl = New Vessel
            Vessel_Ctrl.Name = "Vessel" & _symVesselName
            Vessel_Ctrl.Tag = "Vessel"




            AddHandler Vessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Vessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Vessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Vessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Vessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Vessel_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Vessel_Ctrl)
            Vessel_Ctrl.BringToFront()

            'Call Border(Vessel_Ctrl)
            _symVesselName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@VesselToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub FloatingRoofTankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloatingRoofTankToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            FloatingRoofTank_Ctrl = New FloatingRoof_Tank
            FloatingRoofTank_Ctrl.Name = "FloatingRoofTank" & _symFloatingRoofTankName
            FloatingRoofTank_Ctrl.Tag = "FloatingRoofTank"




            AddHandler FloatingRoofTank_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler FloatingRoofTank_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler FloatingRoofTank_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler FloatingRoofTank_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler FloatingRoofTank_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            FloatingRoofTank_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(FloatingRoofTank_Ctrl)
            FloatingRoofTank_Ctrl.BringToFront()

            'Call Border(FloatingRoofTank_Ctrl)
            _symFloatingRoofTankName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@FloatingRoofTankToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub GasHolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GasHolderToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            GasHolder_Ctrl = New GAS_Holder
            GasHolder_Ctrl.Name = "GasHolder" & _symGasHolderName
            GasHolder_Ctrl.Tag = "GasHolder"




            AddHandler GasHolder_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler GasHolder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler GasHolder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler GasHolder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler GasHolder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            GasHolder_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(GasHolder_Ctrl)
            GasHolder_Ctrl.BringToFront()

            'Call Border(GasHolder_Ctrl)
            _symGasHolderName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GasHolderToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub PressureStorageVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PressureStorageVesselToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            PressureStorageVessel_Ctrl = New PressureStorage_Vessel
            PressureStorageVessel_Ctrl.Name = "PressureStorageVessel" & _symPressureStorageVesselName
            PressureStorageVessel_Ctrl.Tag = "PressureStorageVessel"




            AddHandler PressureStorageVessel_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler PressureStorageVessel_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler PressureStorageVessel_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler PressureStorageVessel_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler PressureStorageVessel_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            PressureStorageVessel_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(PressureStorageVessel_Ctrl)
            PressureStorageVessel_Ctrl.BringToFront()

            'Call Border(PressureStorageVessel_Ctrl)
            _symPressureStorageVesselName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PressureStorageVesselToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub WeighHopperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeighHopperToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            WeighHopper_Ctrl = New Weigh_Hopper
            WeighHopper_Ctrl.Name = "WeighHopper" & _symWeighHopperName
            WeighHopper_Ctrl.Tag = "WeighHopper"




            AddHandler WeighHopper_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler WeighHopper_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler WeighHopper_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler WeighHopper_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler WeighHopper_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            WeighHopper_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(WeighHopper_Ctrl)
            WeighHopper_Ctrl.BringToFront()

            'Call Border(WeighHopper_Ctrl)
            _symWeighHopperName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@WeighHopperToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub CircuitBreakerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CircuitBreakerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            CircuitBreaker_Ctrl = New Circuit_Breaker
            CircuitBreaker_Ctrl.Name = "CircuitBreaker" & _symCircuitBreakerKName
            CircuitBreaker_Ctrl.Tag = "CircuitBreaker"




            AddHandler CircuitBreaker_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CircuitBreaker_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CircuitBreaker_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CircuitBreaker_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CircuitBreaker_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            CircuitBreaker_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(CircuitBreaker_Ctrl)
            CircuitBreaker_Ctrl.BringToFront()

            'Call Border(CircuitBreaker_Ctrl)
            _symCircuitBreakerKName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@CircuitBreakerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Dim OPCWritePropForm As New OPCWriterPropertiesForm
            OPCWritePropForm.BackColorlbl.BackColor = OPCWrite_Ctrl.BackColor
            OPCWritePropForm.forecolorlbl.BackColor = OPCWrite_Ctrl.ForeColor
            OPCWritePropForm.txtTitleFont.Text = OPCWrite_Ctrl.Font.ToString
            OPCWritePropForm.btnFont = OPCWrite_Ctrl.Font
            OPCWritePropForm.txtText.Text = OPCWrite_Ctrl.Text
            OPCWritePropForm.CBoxStyle.Text = (OPCWrite_Ctrl.FlatStyle.ToString)
            OPCWritePropForm.txtboxopcvalue.Text = OPCWrite_Ctrl.OPCValue

            OPCWritePropForm.CBoxActionChannel.Text = OPCWrite_Ctrl.AccessibleDescription
            OPCWritePropForm.Channel_Text = OPCWrite_Ctrl.AccessibleDescription
            OPCWritePropForm.ShowDialog()
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MS_OPCWriterProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Me.modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(OPCWrite_Ctrl)
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Button_Ctrl.SendToBack()
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Button_Ctrl.BringToFront()
    End Sub


    Public Sub MyDataChangeHandler(ByVal sender As Object, ByVal e As DataChangeEventArgs)

    End Sub

    Private Sub ResetTotalizerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetTotalizerToolStripMenuItem.Click
        Dim result1 = MsgBox("Are you sure want to reset the all Totalizer Values of MFMS?", vbYesNo)
        If result1 = DialogResult.Yes Then
            Dim rst As Integer
            For i As Integer = 0 To OPC_ChannelList_Class.OPC_Channel_Name.Count - 1
                If OPC_ChannelList_Class.OPC_Channel_Name(i).StartsWith("reset") Then
                    Dim opsrv As New OpcServer
                    If OPC_ChannelList_Class.OPC_ServerName(i).Contains("^") Then
                        rst = opsrv.Connect(OPC_ChannelList_Class.OPC_ServerName(i).Split("^")(0), OPC_ChannelList_Class.OPC_ServerName(i).Split("^")(1))
                    Else
                        rst = opsrv.Connect(OPC_ChannelList_Class.OPC_ServerName(i))
                    End If

                    If Not HRESULTS.Failed(rst) Then

                        For Each Tag As String In OPC_ChannelList_Class.OPC_OPCItems(i).Split(",")

                            Dim refre As RefreshGroup = New RefreshGroup(opsrv, AddressOf MyDataChangeHandler, 60000)
                            refre.Item(Tag)
                            Try
                                Dim seleitemdata As OPCItemState = Nothing
                                refre.Read(OPCDA.OPCDATASOURCE.OPC_DS_CACHE, Tag, seleitemdata)
                                If Not seleitemdata.DataValue Is Nothing Then
                                    If tagdictionary.ContainsKey(Tag) Then
                                        tagdictionary.Item(Tag) = seleitemdata.DataValue
                                        Console.WriteLine(Tag & vbTab & seleitemdata.DataValue)
                                    Else
                                        tagdictionary.Add(Tag, seleitemdata.DataValue)
                                        Console.WriteLine(Tag & vbTab & seleitemdata.DataValue)
                                    End If
                                End If
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub OPCDAConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OPCDAConfigurationToolStripMenuItem.Click
        Dim addDAServer As New OPCDA_Servers()
        addDAServer.ShowDialog()
    End Sub

    Private Sub OPCHDAConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OPCHDAConfigurationToolStripMenuItem.Click
        Dim addHDAServer As New OPCHDA_Servers()
        addHDAServer.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        OPCDA_ChannelsList.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        OPCHDA_ChannelsList.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        Try

            Dim i = PageTreeView.SelectedNode.Index
            Dim dt As New DataTable
            Dim SAMAHistorianDF As SAMAHistorianChannelDataform
            If OPCDAChannelsList.OPC_Channel_Name.Contains(PageTreeView.SelectedNode.Text) Then
                Dim RptIndx = OPCDAChannelsList.OPC_Channel_Name.IndexOf(PageTreeView.SelectedNode.Text)
                Dim tmpopcda As Redundancy = OPCDAServersCollection.Item(OPCDAChannelsList.OPC_ServerName(RptIndx))

                If OPCDAChannelsList.OPC_Multiview(RptIndx) Then
                    SAMAHistorianDF = New SAMAHistorianChannelDataform(tmpopcda, RptIndx)
                    SAMAHistorianDF.Show()
                Else
                    For Each tg As String In Split(OPCDAChannelsList.OPC_OPCItems(RptIndx), ",")
                        If tmpopcda.opctg.ContainsKey(tg) Then
                            dt = tmpopcda.opctg(tg).opcdt
                        End If
                    Next
                    SAMAHistorianDF = New SAMAHistorianChannelDataform(dt, PageTreeView.SelectedNode.Text & "  " & OPCDAChannelsList.OPC_OPCItems(RptIndx))
                    SAMAHistorianDF.Show()
                End If


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        Try
            Dim i = PageTreeView.SelectedNode.Index
            Dim dt As New DataTable
            Dim SAMAHistorianDF As SAMAHistorianChannelDataform
            If OPCHDAChannelsList.OPC_Channel_Name.Contains(PageTreeView.SelectedNode.Text) Then
                Dim RptIndx = OPCHDAChannelsList.OPC_Channel_Name.IndexOf(PageTreeView.SelectedNode.Text)

                If OPCHDAChannelsList.OPC_OPCItems(RptIndx).Split(",").Count > 1 Then
                    SAMAHistorianDF = New SAMAHistorianChannelDataform(RptIndx, PageTreeView.SelectedNode.Text & "  " & OPCHDAChannelsList.OPC_OPCItems(RptIndx))
                    SAMAHistorianDF.Show()

                Else
                    Dim tmpopcda As HDARedundancy = OPCHDAServersCollection.Item(OPCHDAChannelsList.OPC_ServerName(RptIndx))
                    For Each tg As String In Split(OPCHDAChannelsList.OPC_OPCItems(RptIndx), ",")
                        If tmpopcda.opctg.ContainsKey(tg.ToString() + OPCHDAChannelsList.OPC_Channel_Name(RptIndx).ToString()) Then
                            dt = tmpopcda.opctg(tg.ToString() + OPCHDAChannelsList.OPC_Channel_Name(RptIndx).ToString()).opcdt
                        End If
                    Next
                    SAMAHistorianDF = New SAMAHistorianChannelDataform(dt, PageTreeView.SelectedNode.Text & "  " & OPCHDAChannelsList.OPC_OPCItems(RptIndx))
                    SAMAHistorianDF.Show()
                End If


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnnunciatorWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnunciatorWindowToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
L1:
            If Ctrl_NameList.Contains("Annunciator" & _iniAnnunciatorName) Then
                _iniAnnunciatorName += 1
                GoTo L1
            End If

            Annunciator_Ctrl = New AnnunciatorCtrl
            Annunciator_Ctrl.Name = "Annunciator" & _iniAnnunciatorName
            Annunciator_Ctrl.Tag = "Annunciator"
            Annunciator_Ctrl.MinimumSize = Annunciator_Ctrl_MinSize

            Annunciator_Ctrl.BorderStyle = BorderStyle.FixedSingle
            Annunciator_Ctrl.BackColor = Color.LightGray 'BorderStyle = BorderStyle.FixedSingle

            AddHandler Annunciator_Ctrl.MouseClick, (AddressOf Ctrl_Click)
            AddHandler Annunciator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Annunciator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Annunciator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Annunciator_Ctrl.Paint, AddressOf panel_Ctrl_Paint
            AddHandler Annunciator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Annunciator_Ctrl.AccessibleDescription = "Edge"
            Annunciator_Ctrl.Height = 300
            Annunciator_Ctrl.Width = 500
            Annunciator_Ctrl.AutoSize = False

            Annunciator_Ctrl.BackColor = Color.White
            Annunciator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Annunciator_Ctrl)
            'Selected_Ctrl = Panel_Ctrl
            Annunciator_Ctrl.SendToBack()
            Call Border(Annunciator_Ctrl)
            _iniAnnunciatorName += 1
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AnnunciatorWindowToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub


    Private Sub MS_AnnunciatorClear_Click(sender As Object, e As EventArgs) Handles MS_AnnunciatorClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Annunciator_Ctrl)
    End Sub

    Private Sub MS_AnnunciatorSentoback_Click(sender As Object, e As EventArgs) Handles MS_AnnunciatorSentoback.Click
        Annunciator_Ctrl.SendToBack()
    End Sub

    Private Sub MS_AnnunciatorBtoF_Click(sender As Object, e As EventArgs) Handles MS_AnnunciatorBtoF.Click
        Annunciator_Ctrl.BringToFront()
    End Sub

    Private Sub MS_AnnunciatorCut_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click, PicBox_Cut.Click, MS_ValueLabelCut.Click, MS_TableCut.Click, MS_PanelCut.Click, MS_LBCut.Click, MS_LabelCut.Click, MS_GuageCut.Click, MS_ChartCut.Click, MS_Btn_Cut.Click, MS_AnnunciatorCut.Click
        Try
            blnCut = True
            blnCopy = False
            blnPaste = True
            MS_PagePaste.Enabled = True
            Page_Ctrl.Controls.Remove(Annunciator_Ctrl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MS_AnnunciatorCopy_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click, PicBox_Copy.Click, MS_ValueLabelCopy.Click, MS_TableCopy.Click, MS_PanelCopy.Click, MS_LabelCopy.Click, MS_GuageCopy.Click, MS_ChartCopy.Click, MS_Btn_Copy.Click, MS_AnnunciatorCopy.Click
        Try

            blnCut = False
            blnCopy = True
            blnPaste = True
            MS_PagePaste.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MS_AnnunciatorProperties_Click(sender As Object, e As EventArgs) Handles MS_AnnunciatorProperties.Click
        Try
            AnnunciatorPropertiesForm.Channel_Text = Annunciator_Ctrl.AccessibleDescription
            AnnunciatorPropertiesForm.Channel_BackColor = Annunciator_Ctrl.BackColor
            AnnunciatorPropertiesForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AlarmSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlarmSettingsToolStripMenuItem.Click
        Annunciator_ColorSetting.Show()
    End Sub

    Private Sub AudibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AudibleToolStripMenuItem.Click
        Annunciator_AudibleSetting.ShowDialog()
    End Sub


    Private Sub OPCHDAQueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OPCHDAQueryToolStripMenuItem.Click
        Dim sdd As New QueryOPCHDA
        sdd.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click

    End Sub

    Private Sub lblAlert_Click(sender As Object, e As EventArgs) Handles lblAlert.Click

    End Sub

    Private Sub TSPagelbl_Click(sender As Object, e As EventArgs) Handles TSPagelbl.Click

    End Sub

    Private Sub PropertiseToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub DMS_ChartClear_Click(sender As Object, e As EventArgs) Handles DMS_ChartClear.Click
        Dim objMChartCtrl As MChartControl
        objMChartCtrl = MChart_Ctrl
        Page_Ctrl.Controls.Remove(objMChartCtrl.gdgvMORS)
        Page_Ctrl.Controls.Remove(objMChartCtrl.gdgvUnitValues)
        Page_Ctrl.Controls.Remove(MChart_Ctrl)
    End Sub




    Private Sub OPCWriterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OPCWriterToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            OPCWrite_Ctrl = New OPCWriterControl
            OPCWrite_Ctrl.Name = "OPCWriter" & _iniOPCWriterName
            OPCWrite_Ctrl.Tag = "OPCWriter"
            OPCWrite_Ctrl.Text = "OPCWriter " & _iniOPCWriterName
            OPCWrite_Ctrl.MinimumSize = Ctrl_MinSize

            OPCWrite_Ctrl.Font = New Font("Verdana", 9)
            AddHandler OPCWrite_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler OPCWrite_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler OPCWrite_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler OPCWrite_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            AddHandler OPCWrite_Ctrl.Click, AddressOf OPCWriterCtrl_Click
            ' AddHandler OPCWrite_Ctrl.Click, AddressOf ButtonCtrl_Click

            OPCWrite_Ctrl.Location = Cursor.Position
            Page_Ctrl.Controls.Add(OPCWrite_Ctrl)
            OPCWrite_Ctrl.BringToFront()
            _iniOPCWriterName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCWriterMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub


    '----------------------------------------------------
    Private Sub ManualContactorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualContactorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ManualContactor_Ctrl = New ManualContactor
            ManualContactor_Ctrl.Name = "ManualContactor" & _symManualContactorName
            ManualContactor_Ctrl.Tag = "ManualContactor"
            AddHandler ManualContactor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ManualContactor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ManualContactor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ManualContactor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ManualContactor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            ManualContactor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(ManualContactor_Ctrl)
            ManualContactor_Ctrl.BringToFront()

            'Call Border(ManualContactor_Ctrl)
            _symManualContactorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ManualContactorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub DeltaConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeltaConnectionToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            DeltaConnection_Ctrl = New Delta_Connection
            DeltaConnection_Ctrl.Name = "DeltaConnection" & _symDeltaConnectionName
            DeltaConnection_Ctrl.Tag = "DeltaConnection"




            AddHandler DeltaConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler DeltaConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler DeltaConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler DeltaConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler DeltaConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            DeltaConnection_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(DeltaConnection_Ctrl)
            DeltaConnection_Ctrl.BringToFront()

            'Call Border(DeltaConnection_Ctrl)
            _symDeltaConnectionName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DeltaConnectionToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub FuseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuseToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Fuse_Ctrl = New Fuse
            Fuse_Ctrl.Name = "Fuse" & _symFuseName
            Fuse_Ctrl.Tag = "Fuse"




            AddHandler Fuse_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Fuse_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Fuse_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Fuse_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Fuse_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Fuse_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Fuse_Ctrl)
            Fuse_Ctrl.BringToFront()

            'Call Border(Fuse_Ctrl)
            _symFuseName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@FuseToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MotorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Motor_Ctrl = New Motor
            Motor_Ctrl.Name = "Motor" & _symMotorName
            Motor_Ctrl.Tag = "Motor"




            AddHandler Motor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Motor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Motor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Motor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Motor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Motor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Motor_Ctrl)
            Motor_Ctrl.BringToFront()

            'Call Border(Motor_Ctrl)
            _symMotorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MotorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub StateIndicatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StateIndicatorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            StateIndicator_Ctrl = New StateIndicator
            StateIndicator_Ctrl.Name = "StateIndicator" & _symStateIndicatorName
            StateIndicator_Ctrl.Tag = "StateIndicator"




            AddHandler StateIndicator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler StateIndicator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler StateIndicator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler StateIndicator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler StateIndicator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            StateIndicator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(StateIndicator_Ctrl)
            StateIndicator_Ctrl.BringToFront()

            'Call Border(StateIndicator_Ctrl)
            _symStateIndicatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@StateIndicatorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub TransformerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Transformer_Ctrl = New Transformer
            Transformer_Ctrl.Name = "Transformer" & _symTransformerName
            Transformer_Ctrl.Tag = "Transformer"




            AddHandler Transformer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Transformer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Transformer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Transformer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Transformer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Transformer_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Transformer_Ctrl)
            Transformer_Ctrl.BringToFront()

            'Call Border(Transformer_Ctrl)
            _symTransformerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@BlowerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub WyeConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WyeConnectionToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            WyeConnection_Ctrl = New WYE_Connection
            WyeConnection_Ctrl.Name = "WyeConnection" & _symWyeConnectionName
            WyeConnection_Ctrl.Tag = "WyeConnection"




            AddHandler WyeConnection_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler WyeConnection_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler WyeConnection_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler WyeConnection_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler WyeConnection_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            WyeConnection_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(WyeConnection_Ctrl)
            WyeConnection_Ctrl.BringToFront()

            'Call Border(WyeConnection_Ctrl)
            _symWyeConnectionName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@WyeConnectionToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub LiquidFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidFilterToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            LiquidFilter_Ctrl = New Liquid_Filter
            LiquidFilter_Ctrl.Name = "LiquidFilter" & _symLiquidFilterName
            LiquidFilter_Ctrl.Tag = "LiquidFilter"




            AddHandler LiquidFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler LiquidFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler LiquidFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler LiquidFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler LiquidFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            LiquidFilter_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(LiquidFilter_Ctrl)
            LiquidFilter_Ctrl.BringToFront()

            'Call Border(LiquidFilter_Ctrl)
            _symLiquidFilterName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LiquidFilterToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub VacuumFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VacuumFilterToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            VacuumFilter_Ctrl = New Vacuum_Filter
            VacuumFilter_Ctrl.Name = "VacuumFilter" & _symVacuumFilterName
            VacuumFilter_Ctrl.Tag = "VacuumFilter"




            AddHandler VacuumFilter_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler VacuumFilter_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler VacuumFilter_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler VacuumFilter_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler VacuumFilter_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            VacuumFilter_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(VacuumFilter_Ctrl)
            VacuumFilter_Ctrl.BringToFront()

            'Call Border(VacuumFilter_Ctrl)
            _symVacuumFilterName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@BlowerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ExchangerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Exchanger_Ctrl = New Exchanger
            Exchanger_Ctrl.Name = "Exchanger" & _symExchangerName
            Exchanger_Ctrl.Tag = "Exchanger"




            AddHandler Exchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Exchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Exchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Exchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Exchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Exchanger_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Exchanger_Ctrl)
            Exchanger_Ctrl.BringToFront()

            'Call Border(Exchanger_Ctrl)
            _symExchangerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ExchangerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ForcedAirExchangerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForcedAirExchangerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ForcedAirExchanger_Ctrl = New Forced_Air_Exchanged
            ForcedAirExchanger_Ctrl.Name = "ForcedAirExchanger" & _symForcedAirExchangerName
            ForcedAirExchanger_Ctrl.Tag = "ForcedAirExchanger"




            AddHandler ForcedAirExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ForcedAirExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ForcedAirExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ForcedAirExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ForcedAirExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            ForcedAirExchanger_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(ForcedAirExchanger_Ctrl)
            ForcedAirExchanger_Ctrl.BringToFront()

            'Call Border(ForcedAirExchanger_Ctrl)
            _symForcedAirExchangerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ForcedAirExchangerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub FurnaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FurnaceToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Furnace_Ctrl = New Furnace
            Furnace_Ctrl.Name = "Furnace" & _symFurnaceName
            Furnace_Ctrl.Tag = "Furnace"




            AddHandler Furnace_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Furnace_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Furnace_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Furnace_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Furnace_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Furnace_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Furnace_Ctrl)
            Furnace_Ctrl.BringToFront()

            'Call Border(Furnace_Ctrl)
            _symFurnaceName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@FurnaceToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub RotaryKilnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotaryKilnToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            RotaryKiln_Ctrl = New Rotary_Kiln
            RotaryKiln_Ctrl.Name = "RotaryKiln" & _symRotaryKilnName
            RotaryKiln_Ctrl.Tag = "RotaryKiln"




            AddHandler RotaryKiln_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotaryKiln_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotaryKiln_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotaryKiln_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotaryKiln_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            RotaryKiln_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(RotaryKiln_Ctrl)
            RotaryKiln_Ctrl.BringToFront()

            'Call Border(RotaryKiln_Ctrl)
            _symRotaryKilnName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RotaryKilnToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub CoolingTowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoolingTowerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            CoolingTower_Ctrl = New Cooling_Tower
            CoolingTower_Ctrl.Name = "CoolingTower" & _symCoolingTowerName
            CoolingTower_Ctrl.Tag = "CoolingTower"




            AddHandler CoolingTower_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CoolingTower_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CoolingTower_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CoolingTower_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CoolingTower_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            CoolingTower_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(CoolingTower_Ctrl)
            CoolingTower_Ctrl.BringToFront()

            'Call Border(CoolingTower_Ctrl)
            _symCoolingTowerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@CoolingTowerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub EvaporatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvaporatorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Evaporator_Ctrl = New Evaporator
            Evaporator_Ctrl.Name = "Evaporator" & _symEvaporatorName
            Evaporator_Ctrl.Tag = "Evaporator"




            AddHandler Evaporator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Evaporator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Evaporator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Evaporator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Evaporator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Evaporator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Evaporator_Ctrl)
            Evaporator_Ctrl.BringToFront()

            'Call Border(Evaporator_Ctrl)
            _symEvaporatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@EvaporatorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub FinnedExchangerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinnedExchangerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            FinnedExchanger_Ctrl = New Finned_Exchanger
            FinnedExchanger_Ctrl.Name = "FinnedExchanger" & _symFinnedExchangerName
            FinnedExchanger_Ctrl.Tag = "FinnedExchanger"




            AddHandler FinnedExchanger_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler FinnedExchanger_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler FinnedExchanger_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler FinnedExchanger_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler FinnedExchanger_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            FinnedExchanger_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(FinnedExchanger_Ctrl)
            FinnedExchanger_Ctrl.BringToFront()

            'Call Border(FinnedExchanger_Ctrl)
            _symFinnedExchangerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@FinnedExchangerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ConveyorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConveyorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Conveyor_Ctrl = New Conveyor
            Conveyor_Ctrl.Name = "Conveyor" & _symConveyorName
            Conveyor_Ctrl.Tag = "Conveyor"




            AddHandler Conveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Conveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Conveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Conveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Conveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Conveyor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Conveyor_Ctrl)
            Conveyor_Ctrl.BringToFront()

            Call Border(Conveyor_Ctrl)
            _symConveyorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ConveyorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub MillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MillToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Mill_Ctrl = New Mill
            Mill_Ctrl.Name = "Mill" & _symMillName
            Mill_Ctrl.Tag = "Mill"




            AddHandler Mill_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Mill_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Mill_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Mill_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Mill_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Mill_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Mill_Ctrl)
            Mill_Ctrl.BringToFront()

            'Call Border(Mill_Ctrl)
            _symMillName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MillToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub RollStandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollStandToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            RollStand_Ctrl = New Roll_Stand
            RollStand_Ctrl.Name = "RollStand" & _symRollStandName
            RollStand_Ctrl.Tag = "RollStand"




            AddHandler RollStand_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RollStand_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RollStand_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RollStand_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RollStand_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            RollStand_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(RollStand_Ctrl)
            RollStand_Ctrl.BringToFront()

            'Call Border(RollStand_Ctrl)
            _symRollStandName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RollStandToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub RotaryFeederToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotaryFeederToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            RotaryFeeder_Ctrl = New Rotary_Feeder
            RotaryFeeder_Ctrl.Name = "RotaryFeeder" & _symRotaryFeederName
            RotaryFeeder_Ctrl.Tag = "RotaryFeeder"




            AddHandler RotaryFeeder_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotaryFeeder_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotaryFeeder_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotaryFeeder_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotaryFeeder_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            RotaryFeeder_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(RotaryFeeder_Ctrl)
            RotaryFeeder_Ctrl.BringToFront()

            'Call Border(RotaryFeeder_Ctrl)
            _symRotaryFeederName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RotaryFeederToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ScrewConveyorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrewConveyorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ScrewConveyor_Ctrl = New Screw_Conveyor
            ScrewConveyor_Ctrl.Name = "ScrewConveyor" & _symScrewConveyorName
            ScrewConveyor_Ctrl.Tag = "ScrewConveyor"




            AddHandler ScrewConveyor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ScrewConveyor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ScrewConveyor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ScrewConveyor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ScrewConveyor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            ScrewConveyor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(ScrewConveyor_Ctrl)
            ScrewConveyor_Ctrl.BringToFront()

            'Call Border(ScrewConveyor_Ctrl)
            _symScrewConveyorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ScrewConveyorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub InlineMixerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InlineMixerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            InlineMixer_Ctrl = New Inline_Mixer
            InlineMixer_Ctrl.Name = "InlineMixer" & _symInlineMixerName
            InlineMixer_Ctrl.Tag = "InlineMixer"




            AddHandler InlineMixer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler InlineMixer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler InlineMixer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler InlineMixer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler InlineMixer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            InlineMixer_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(InlineMixer_Ctrl)
            InlineMixer_Ctrl.BringToFront()

            'Call Border(InlineMixer_Ctrl)
            _symInlineMixerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@InlineMixerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub CompressorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompressorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Compressor_Ctrl = New Compressor
            Compressor_Ctrl.Name = "Compressor" & _symCompressorName
            Compressor_Ctrl.Tag = "Compressor"




            AddHandler Compressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Compressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Compressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Compressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Compressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Compressor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Compressor_Ctrl)
            Compressor_Ctrl.BringToFront()

            'Call Border(Compressor_Ctrl)
            _symCompressorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@CompressorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub PumpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PumpToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Pump_Ctrl = New Pump
            Pump_Ctrl.Name = "Pump" & _symPumpName
            Pump_Ctrl.Tag = "Pump"




            AddHandler Pump_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Pump_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Pump_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Pump_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Pump_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Pump_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Pump_Ctrl)
            Pump_Ctrl.BringToFront()

            'Call Border(Pump_Ctrl)
            _symPumpName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PumpToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub TurbineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurbineToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            Turbine_Ctrl = New Turbine
            Turbine_Ctrl.Name = "Turbine" & _symTurbineName
            Turbine_Ctrl.Tag = "Turbine"




            AddHandler Turbine_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler Turbine_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler Turbine_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler Turbine_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler Turbine_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            Turbine_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(Turbine_Ctrl)
            Turbine_Ctrl.BringToFront()

            'Call Border(Turbine_Ctrl)
            _symTurbineName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TurbineToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub CycloneSeparatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CycloneSeparatorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            CycloneSeparator_Ctrl = New Cyclone_Seperator
            CycloneSeparator_Ctrl.Name = "CycloneSeparator" & _symCycloneSeparatorName
            CycloneSeparator_Ctrl.Tag = "CycloneSeparator"




            AddHandler CycloneSeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler CycloneSeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler CycloneSeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler CycloneSeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler CycloneSeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            CycloneSeparator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(CycloneSeparator_Ctrl)
            CycloneSeparator_Ctrl.BringToFront()

            'Call Border(CycloneSeparator_Ctrl)
            _symCycloneSeparatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@CycloneSeparatorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub RotarySeparatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotarySeparatorToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            RotarySeparator_Ctrl = New Rotary_Seperator
            RotarySeparator_Ctrl.Name = "RotarySeparator" & _symRotarySeparatorName
            RotarySeparator_Ctrl.Tag = "RotarySeparator"




            AddHandler RotarySeparator_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler RotarySeparator_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler RotarySeparator_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler RotarySeparator_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler RotarySeparator_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            RotarySeparator_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(RotarySeparator_Ctrl)
            RotarySeparator_Ctrl.BringToFront()

            'Call Border(RotarySeparator_Ctrl)
            _symRotarySeparatorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@RotarySeparatorToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub SprayDryerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SprayDryerToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            SprayDryer_Ctrl = New Spray_Dryer
            SprayDryer_Ctrl.Name = "SprayDryer" & _symSprayDryerName
            SprayDryer_Ctrl.Tag = "SprayDryer"




            AddHandler SprayDryer_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler SprayDryer_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler SprayDryer_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler SprayDryer_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler SprayDryer_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            SprayDryer_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(SprayDryer_Ctrl)
            SprayDryer_Ctrl.BringToFront()

            'Call Border(SprayDryer_Ctrl)
            _symSprayDryerName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SprayDryerToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ReciprocatingCompressorOrPumpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReciprocatingCompressorOrPumpToolStripMenuItem.Click
        Try
            modify = True
            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ReciprocatingCompressor_Ctrl = New Reciprocating_Compressor
            ReciprocatingCompressor_Ctrl.Name = "ReciprocatingCompressor" & _symReciprocatingCompressorName
            ReciprocatingCompressor_Ctrl.Tag = "ReciprocatingCompressor"




            AddHandler ReciprocatingCompressor_Ctrl.MouseClick, (AddressOf Symbol_Click)
            AddHandler ReciprocatingCompressor_Ctrl.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler ReciprocatingCompressor_Ctrl.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler ReciprocatingCompressor_Ctrl.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler ReciprocatingCompressor_Ctrl.MouseLeave, AddressOf Ctrl_MouseLeave

            ReciprocatingCompressor_Ctrl.Location = New Point(150, 200)

            Page_Ctrl.Controls.Add(ReciprocatingCompressor_Ctrl)
            ReciprocatingCompressor_Ctrl.BringToFront()

            'Call Border(ReciprocatingCompressor_Ctrl)
            _symReciprocatingCompressorName += 1

        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ReciprocatingCompressorOrPumpToolStripMenuItem_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub




    Private Sub MS_SymClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If
        Page_Ctrl.Controls.Remove(Symbol_Ctrl)
    End Sub

    Private Sub MS_SymS_To_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymS_To_B.Click
        Symbol_Ctrl.SendToBack()
    End Sub

    Private Sub MS_SymB_To_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymB_To_F.Click
        Symbol_Ctrl.BringToFront()
    End Sub

    Private Sub MS_SymCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymCut.Click
        Try
            blnCut = True
            blnCopy = False
            blnPaste = True
            MS_PagePaste.Enabled = True
            Page_Ctrl.Controls.Remove(Symbol_Ctrl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MS_SymCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymCopy.Click
        Try
            blnCut = False
            blnCopy = True
            blnPaste = True
            MS_PagePaste.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub MS_SymProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SymProperties.Click

        Try
            SymbolProp_Form = New SymbolPropertiesForm

            SymbolProp_Form.lblBackClr.BackColor = Symbol_Ctrl.D_Color1

            SymbolProp_Form.forecolorLbl.BackColor = Symbol_Ctrl.ForeColor
            SymbolProp_Form.txtDesc.Text = Symbol_Ctrl.Description
            SymbolProp_Form.Channel_Text = Symbol_Ctrl.AccessibleDescription


            SymbolProp_Form.GVTHValue.Rows.Clear()
            For i As Integer = 0 To Symbol_Ctrl._ThresholdValue.Count - 1
                SymbolProp_Form.GVTHValue.Rows.Add()

                SymbolProp_Form.GVTHValue.Rows(i).Cells(0).Value = Symbol_Ctrl._THCondition(i)
                SymbolProp_Form.GVTHValue.Rows(i).Cells(1).Value = Symbol_Ctrl._ThresholdValue(i)
                SymbolProp_Form.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(Symbol_Ctrl._THColor(i))

            Next


            SymbolProp_Form.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    Private Sub MS_SwitchProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchProperties.Click
        Try
            SwitchProp_Form = New SwitchPropertiesForm



            SwitchProp_Form.lblBackClr.BackColor = Switch_Ctrl.D_Color1


            SwitchProp_Form.Channel_Text = Switch_Ctrl.AccessibleDescription


            SwitchProp_Form.GVTHValue.Rows.Clear()
            For i As Integer = 0 To Switch_Ctrl._ThresholdValue.Count - 1
                SwitchProp_Form.GVTHValue.Rows.Add()

                SwitchProp_Form.GVTHValue.Rows(i).Cells(0).Value = Switch_Ctrl._THCondition(i)
                SwitchProp_Form.GVTHValue.Rows(i).Cells(1).Value = Switch_Ctrl._ThresholdValue(i)
                SwitchProp_Form.GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.FromArgb(Switch_Ctrl._THColor(i))
                SwitchProp_Form.GVTHValue.Rows(i).Cells(3).value = Switch_Ctrl._THState(i)
            Next


            SwitchProp_Form.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub MS_SwitchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchClear.Click
        modify = True
        If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            Me.Text = Me.Text & " *"
        End If

        Page_Ctrl.Controls.Remove(Switch_Ctrl)


    End Sub




    Private Sub MS_SwitchS_To_B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchS_To_B.Click
        Switch_Ctrl.SendToBack()
    End Sub

    Private Sub MS_SwitchB_To_F_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchB_To_F.Click
        Switch_Ctrl.BringToFront()
    End Sub

    Private Sub MS_SwitchCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchCut.Click
        Try
            blnCut = True
            blnCopy = False
            blnPaste = True
            MS_PagePaste.Enabled = True
            Page_Ctrl.Controls.Remove(Switch_Ctrl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MS_SwitchCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MS_SwitchCopy.Click
        Try
            blnCut = False
            blnCopy = True
            blnPaste = True
            MS_PagePaste.Enabled = True


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'Private Sub ExploreReports()
    '    Try
    '        'Dim ReportLocation As String = "C:\velu\velu"

    '        TreeViewReports.Visible = True
    '        TreeViewReports.Nodes.Clear()
    '        TreeViewReports.Nodes.Add("Generated Reports", "Generated Reports        ")
    '        TreeViewReports.ImageList = ImageList1
    '        TreeViewReports.Nodes(0).ImageIndex = 0
    '        TreeViewReports.Nodes(0).SelectedImageIndex = 0
    '        TreeViewReports.Nodes(0).NodeFont = New Font("Verdana", 9, FontStyle.Bold)
    '        If IO.Directory.Exists(ReportLocation & "\Generated Reports") Then
    '            PopulateTreeView(ReportLocation & "\Generated Reports", TreeViewReports.Nodes(0))
    '        End If

    '    Catch ex As Exception
    '        _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddInlineMixer()")
    '        MainErrorPV.SetError(lblAlert, "Error !!!")
    '    End Try
    'End Sub
    Private Sub PopulateTreeView(ByVal dir As String, ByVal parentNode As TreeNode)
        Try

            Dim folder As String = String.Empty

            'Add the files to treeview
            Dim files() As String = IO.Directory.GetFiles(dir)
            If files.Length <> 0 Then
                Dim fileNode As TreeNode = Nothing
                For Each file As String In files
                    If file.EndsWith(".xls") Then
                        fileNode = parentNode.Nodes.Add(IO.Path.GetFileName(file).Replace(".xls", ""))
                        fileNode.ImageIndex = 2
                        fileNode.SelectedImageIndex = 2
                        fileNode.NodeFont = New Font("Verdana", 8.25, FontStyle.Regular)
                        fileNode.Tag = file
                    ElseIf file.EndsWith(".htm") Then
                        fileNode = parentNode.Nodes.Add(IO.Path.GetFileName(file).Replace(".htm", ""))
                        fileNode.ImageIndex = 4
                        fileNode.SelectedImageIndex = 4
                        fileNode.NodeFont = New Font("Verdana", 8.25, FontStyle.Regular)
                        fileNode.Tag = file
                    ElseIf file.EndsWith(".pdf") Then
                        fileNode = parentNode.Nodes.Add(IO.Path.GetFileName(file).Replace(".pdf", ""))
                        fileNode.ImageIndex = 3
                        fileNode.SelectedImageIndex = 3
                        fileNode.NodeFont = New Font("Verdana", 8.25, FontStyle.Regular)
                        fileNode.Tag = file
                    End If
                Next
            End If
            'Add folders to treeview


            Dim folders() As String = IO.Directory.GetDirectories(dir)
            If folders.Length <> 0 And files.Length <> 0 Then
                If files(0).EndsWith(".htm") And (files(0).Replace(".htm", "") = folders(0).Replace("_files", "")) Then

                Else
                    Dim folderNode As TreeNode = Nothing
                    Dim folderName As String = String.Empty

                    For Each folder In folders
                        folderName = IO.Path.GetFileName(folder)
                        folderNode = parentNode.Nodes.Add(folderName)
                        folderNode.ImageIndex = 1
                        folderNode.SelectedImageIndex = 1
                        folderNode.NodeFont = New Font("Verdana", 9, FontStyle.Bold)
                        folderNode.Tag = folder
                        PopulateTreeView(folder, folderNode)
                    Next
                End If
            ElseIf folders.Length <> 0 Then
                Dim folderNode As TreeNode = Nothing
                Dim folderName As String = String.Empty
                For Each folder In folders
                    folderName = IO.Path.GetFileName(folder)
                    folderNode = parentNode.Nodes.Add(folderName)
                    folderNode.ImageIndex = 1
                    folderNode.SelectedImageIndex = 1
                    folderNode.NodeFont = New Font("Verdana", 9, FontStyle.Bold)
                    folderNode.Tag = folder
                    PopulateTreeView(folder, folderNode)
                Next
            End If


        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddInlineMixer()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    Try
    '        If Not TreeViewLeft.Visible Then
    '            Explore_DataSources()
    '            TreeViewLeft.Visible = True
    '        Else
    '            TreeViewLeft.Visible = False
    '            TreeViewLeft.Nodes.Clear()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Friend Sub Explore_DataSources()
        Try
            TreeViewLeft.Nodes.Clear()
            TreeViewLeft.ImageList = ImageList1
            TreeViewLeft.Nodes.Add("Screens", "Screens       ")
            TreeViewLeft.Nodes(0).ImageIndex = 9
            TreeViewLeft.Nodes(0).SelectedImageIndex = 9
            TreeViewLeft.Nodes(0).NodeFont = New Font("Verdana", 9, FontStyle.Bold)

            TreeViewLeft.Nodes(0).Nodes.Add("AIMS", "AIMS")
            'GetSAMAHistorianTags()
            GenerateAlarmTreeView(_tgNamesAIMS)
            TreeViewLeft.Nodes(0).Nodes.Add("HISTORIAN", "HISTORIAN")
            GenerateTreeView(_tgNames)

            AddHandler TreeViewLeft.MouseClick, AddressOf Page_Click
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Explore_DataSources()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub TreeViewLeft_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewLeft.AfterSelect
        Try
            If (e.Node.Parent Is Nothing) Then
                RemoveHandler TreeViewLeft.MouseClick, AddressOf Page_Click
            Else
                ' If TreeViewLeft.SelectedNode.Index > 0 Then
                Dim pgIdx As String = TreeViewLeft.SelectedNode.Name
                Dim pnlPage() As Control
                pnlPage = Me.Controls.Find(pgIdx, True)
                If pnlPage.Length <> 0 Then
                    If Not pnlPage Is Nothing AndAlso Not pnlPage(0) Is Nothing Then
                        Page_Ctrl = pnlPage(0)
                        Page_Ctrl.BringToFront()
                        Page_Ctrl.Dock = DockStyle.Fill
                        Page_Ctrl.AllowDrop = True
                        SltPageIndex = pgIdx
                        Page_Ctrl.Visible = True


                        RemoveHandler Page_Ctrl.DragDrop, AddressOf Page_Ctrl_Drop
                        RemoveHandler Page_Ctrl.DragEnter, AddressOf Page_Ctrl_DragEnter

                        TSPagelbl.Text = "Current Page  : " & TreeViewLeft.SelectedNode.Text
                        Page_Ctrl.AutoScrollMinSize = New Size(500, 500)

                        AddHandler TreeViewLeft.MouseClick, AddressOf Page_Click
                        AddHandler Page_Ctrl.MouseMove, AddressOf Page_Ctrl_MouseMove
                        AddHandler Page_Ctrl.MouseClick, AddressOf Page_Ctrl_MouseClick
                        AddHandler Page_Ctrl.DragDrop, AddressOf Page_Ctrl_Drop
                        AddHandler Page_Ctrl.DragEnter, AddressOf Page_Ctrl_DragEnter
                    End If
                End If
                'End If
                'If TreeViewLeft.SelectedNode.Index > 0 Then

                'End If
            End If


        Catch ex As Exception
            MainErrorPV.SetError(lblAlert, "Error !!!")
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TreeViewLeft_AfterSelect()")
        End Try

    End Sub

    Private Sub Page_Click(ByVal sender As [Object], ByVal e As MouseEventArgs) Handles TreeViewLeft.NodeMouseClick
        Try
            If Not _IsSimpleUser Then

                If Not _runMode Then
                    If TreeViewLeft.SelectedNode Is Nothing Then
                        Exit Sub
                    End If
                    If Not TreeViewLeft.SelectedNode.Parent Is Nothing Then
                        'If TreeViewLeft.SelectedNode.Parent.Index = 0 Then 'Pages Node
                        If e.Button = MouseButtons.Right Then
                            'MsgBox(TreeViewLeft.SelectedNode.Level & "  " & TreeViewLeft.SelectedNode.Index)

                            If TreeViewLeft.SelectedNode.Level > 0 Then
                                If TreeViewLeft.SelectedNode.Tag = "PageNode" Then
                                    MS_AddPage.Enabled = False
                                    MS_PageProperties.Enabled = True
                                    MS_DeletePage.Enabled = True
                                Else
                                    MS_AddPage.Enabled = True
                                    MS_PageProperties.Enabled = False
                                    MS_DeletePage.Enabled = False
                                End If
                                ContextMenuStripPages.Show(TreeViewLeft, e.X, e.Y)
                            End If



                            'If TreeViewLeft.SelectedNode.Index > 1 Then
                            '    'If TreeViewLeft.SelectedNode.Index = TreeViewLeft.Nodes(0).Nodes(2).Nodes.Count - 1 Then
                            '    MS_DeletePage.Enabled = True
                            '    'Else
                            '    'MS_DeletePage.Enabled = False
                            '    ' End If
                            'Else
                            '    MS_DeletePage.Enabled = False
                            'End If

                        End If
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GenerateAlarmTreeView(ByVal ar As ArrayList)
        Try
            ' TreeView_Connectivity.Nodes.Clear()
            _ChannelIds.Clear()
            TagNames.Clear()
            Dim n As TreeNode = TreeViewLeft.Nodes(0).FirstNode, isavail As Integer = -1
            For Each s As String In ar

                Dim plant As String = s.Split("~")(0)
                Dim area As String = s.Split("~")(1)
                Dim unit As String = s.Split("~")(2)
                'Dim equipment As String = s.Split("~")(7)
                'Dim tagmain As String = s.Split("~")(8)
                If _IsSuperAdmin Then
                    Dim _plant As New TreeNode
                    Dim _area As New TreeNode
                    Dim _unit As New TreeNode

                    isavail = -1
                    Searchnode(TreeViewLeft.Nodes(0).FirstNode.Nodes, plant, isavail, n)
                    If isavail = -1 Then
                        _plant = TreeViewLeft.Nodes(0).FirstNode.Nodes.Add(plant, plant)
                    Else
                        _plant = n
                    End If

                    isavail = -1
                    Searchnode(_plant.Nodes, area, isavail, n)
                    If isavail = -1 Then
                        _area = _plant.Nodes.Add(area, area)
                    Else
                        _area = n
                    End If

                    isavail = -1
                    Searchnode(_area.Nodes, unit, isavail, n)
                    If isavail = -1 Then
                        _unit = _area.Nodes.Add(unit, unit)
                    Else
                        _unit = n
                    End If
                Else

                    Dim accessrul As New ArrayList

                    Dim accessrul1() As String = Access_Rules.Split("/")
                    For j As Integer = 0 To accessrul1.Length - 1
                        If (accessrul1(j) <> " ") And (accessrul1(j) <> "") Then
                            Dim HistCheck As String = accessrul1(j)
                            Dim asd = HistCheck.Substring(0, HistCheck.IndexOf("~"))
                            If asd = "AIMS" Then
                                accessrul.Add(accessrul1(j).ToString)
                            End If
                        End If
                    Next

                    Dim plants As New ArrayList
                    If Access_Level = "Plant" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))

                            End If
                        Next
                    End If


                    Dim areas As New ArrayList
                    If Access_Level = "Area" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                                areas.Add(Trim(accessrul(i).Split("~")(2)))
                            End If
                        Next
                    End If

                    Dim units As New ArrayList
                    If Access_Level = "Unit" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                                areas.Add(Trim(accessrul(i).Split("~")(2)))
                                units.Add(Trim(accessrul(i).Split("~")(3)))
                            End If
                        Next
                    End If

                    Dim _plant As New TreeNode
                    Dim _area As New TreeNode
                    Dim _unit As New TreeNode


                    If Access_Level = "Plant" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).FirstNode.Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).FirstNode.Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            isavail = -1
                            Searchnode(_plant.Nodes, area, isavail, n)
                            If isavail = -1 Then
                                _area = _plant.Nodes.Add(area, area)
                            Else
                                _area = n
                            End If

                            isavail = -1
                            Searchnode(_area.Nodes, unit, isavail, n)
                            If isavail = -1 Then
                                _unit = _area.Nodes.Add(unit, unit)
                            Else
                                _unit = n
                            End If
                        End If
                    End If


                    If Access_Level = "Area" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).FirstNode.Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).FirstNode.Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            If areas.Contains(area) Then
                                isavail = -1
                                Searchnode(_plant.Nodes, area, isavail, n)
                                If isavail = -1 Then
                                    _area = _plant.Nodes.Add(area, area)
                                Else
                                    _area = n
                                End If

                                isavail = -1
                                Searchnode(_area.Nodes, unit, isavail, n)
                                If isavail = -1 Then
                                    _unit = _area.Nodes.Add(unit, unit)
                                Else
                                    _unit = n
                                End If
                            End If
                        End If
                    End If


                    If Access_Level = "Unit" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).FirstNode.Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).FirstNode.Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            If areas.Contains(area) Then
                                isavail = -1
                                Searchnode(_plant.Nodes, area, isavail, n)
                                If isavail = -1 Then
                                    _area = _plant.Nodes.Add(area, area)
                                Else
                                    _area = n
                                End If


                                If units.Contains(unit) Then
                                    isavail = -1
                                    Searchnode(_area.Nodes, unit, isavail, n)
                                    If isavail = -1 Then
                                        _unit = _area.Nodes.Add(unit, unit)
                                    Else
                                        _unit = n
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GenerateTreeView()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
            'insertfilelog(ex.Message & "@GenerateTreeView() at Mainpage")
        End Try
    End Sub
    Private Sub GenerateTreeView(ByVal ar As ArrayList)
        Try
            ' TreeView_Connectivity.Nodes.Clear()
            _ChannelIds.Clear()
            TagNames.Clear()
            Dim n As TreeNode = TreeViewLeft.Nodes(0).Nodes(1), isavail As Integer = -1
            For Each s As String In ar
                Dim tag As String = s.Split("~")(0)
                'Dim chnlId As String = tag.Split(".")(0)
                'Dim tagname As String = tag.Split(".")(1)
                'Dim tagparam As String = tag.Split(".")(2)

                Dim chnlId As String = tag.Split(".")(0)
                Dim tagname As String = tag.Substring(tag.IndexOf(".") + 1, (tag.LastIndexOf(".") - (tag.IndexOf(".") + 1)))
                Dim tagparam As String = tag.Substring(tag.LastIndexOf(".") + 1)


                Dim plant As String = s.Split("~")(4)
                Dim area As String = s.Split("~")(5)
                Dim unit As String = s.Split("~")(6)
                Dim equipment As String = s.Split("~")(7)
                Dim tagmain As String = s.Split("~")(8)
                If _IsSuperAdmin Then
                    Dim _plant As New TreeNode
                    Dim _area As New TreeNode
                    Dim _unit As New TreeNode
                    Dim _equipment As New TreeNode
                    Dim _tagmain As New TreeNode
                    Dim _tagname As New TreeNode
                    Dim _tagparam As New TreeNode


                    isavail = -1
                    Searchnode(TreeViewLeft.Nodes(0).Nodes(1).Nodes, plant, isavail, n)
                    If isavail = -1 Then
                        _plant = TreeViewLeft.Nodes(0).Nodes(1).Nodes.Add(plant, plant)
                    Else
                        _plant = n
                    End If

                    isavail = -1
                    Searchnode(_plant.Nodes, area, isavail, n)
                    If isavail = -1 Then
                        _area = _plant.Nodes.Add(area, area)
                    Else
                        _area = n
                    End If

                    isavail = -1
                    Searchnode(_area.Nodes, unit, isavail, n)
                    If isavail = -1 Then
                        _unit = _area.Nodes.Add(unit, unit)
                    Else
                        _unit = n
                    End If

                    isavail = -1
                    Searchnode(_unit.Nodes, equipment, isavail, n)
                    If isavail = -1 Then
                        _equipment = _unit.Nodes.Add(equipment, equipment)
                    Else
                        _equipment = n
                    End If

                    isavail = -1
                    Searchnode(_equipment.Nodes, tagmain, isavail, n)
                    If isavail = -1 Then
                        _tagmain = _equipment.Nodes.Add(tagmain, tagmain)
                    Else
                        _tagmain = n
                    End If


                    isavail = -1
                    Searchnode(_tagmain.Nodes, tagname, isavail, n)
                    If isavail = -1 Then
                        _tagname = _tagmain.Nodes.Add(tagname, tagname)
                    Else
                        _tagname = n
                    End If

                    isavail = -1
                    Searchnode(_tagname.Nodes, tagparam, isavail, n)
                    If isavail = -1 Then
                        _tagparam = _tagname.Nodes.Add(tagparam, tagparam)
                    Else
                        _tagparam = n
                    End If

                    _ChannelIds.Add(chnlId)
                    TagNames.Add(tagname + "." + tagparam)

                Else

                    Dim accessrul As New ArrayList
                    Dim accessrul1() As String = Access_Rules.Split("/")
                    For j As Integer = 0 To accessrul1.Length - 1
                        If (accessrul1(j) <> " ") And (accessrul1(j) <> "") Then
                            Dim HistCheck As String = accessrul1(j)
                            Dim asd = HistCheck.Substring(0, HistCheck.IndexOf("~"))
                            If asd = "HISTORIAN" Then
                                accessrul.Add(accessrul1(j).ToString)
                            End If
                        End If
                    Next

                    Dim plants As New ArrayList
                    If Access_Level = "Plant" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                            End If
                        Next
                    End If


                    Dim areas As New ArrayList
                    If Access_Level = "Area" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                                areas.Add(Trim(accessrul(i).Split("~")(2)))
                            End If
                        Next
                    End If





                    Dim units As New ArrayList
                    If Access_Level = "Unit" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                                areas.Add(Trim(accessrul(i).Split("~")(2)))
                                units.Add(Trim(accessrul(i).Split("~")(3)))
                            End If
                        Next
                    End If

                    Dim equipments As New ArrayList
                    If Access_Level = "Equipment" Then
                        For i As Integer = 0 To accessrul.Count - 1
                            If Not IsDBNull(accessrul(i)) And (accessrul(i) <> "") Then
                                plants.Add(Trim(accessrul(i).Split("~")(1)))
                                areas.Add(Trim(accessrul(i).Split("~")(2)))
                                units.Add(Trim(accessrul(i).Split("~")(3)))
                                equipments.Add(Trim(accessrul(i).Split("~")(4)))
                            End If
                        Next
                    End If


                    Dim _plant As New TreeNode
                    Dim _area As New TreeNode
                    Dim _unit As New TreeNode
                    Dim _equipment As New TreeNode
                    Dim _tagmain As New TreeNode
                    Dim _tagname As New TreeNode
                    Dim _tagparam As New TreeNode


                    If Access_Level = "Plant" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).Nodes(1).Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).Nodes(1).Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            isavail = -1
                            Searchnode(_plant.Nodes, area, isavail, n)
                            If isavail = -1 Then
                                _area = _plant.Nodes.Add(area, area)
                            Else
                                _area = n
                            End If

                            isavail = -1
                            Searchnode(_area.Nodes, unit, isavail, n)
                            If isavail = -1 Then
                                _unit = _area.Nodes.Add(unit, unit)
                            Else
                                _unit = n
                            End If

                            isavail = -1
                            Searchnode(_unit.Nodes, equipment, isavail, n)
                            If isavail = -1 Then
                                _equipment = _unit.Nodes.Add(equipment, equipment)
                            Else
                                _equipment = n
                            End If

                            isavail = -1
                            Searchnode(_equipment.Nodes, tagmain, isavail, n)
                            If isavail = -1 Then
                                _tagmain = _equipment.Nodes.Add(tagmain, tagmain)
                            Else
                                _tagmain = n
                            End If


                            isavail = -1
                            Searchnode(_tagmain.Nodes, tagname, isavail, n)
                            If isavail = -1 Then
                                _tagname = _tagmain.Nodes.Add(tagname, tagname)
                            Else
                                _tagname = n
                            End If


                            isavail = -1
                            Searchnode(_tagname.Nodes, tagparam, isavail, n)
                            If isavail = -1 Then
                                _tagparam = _tagname.Nodes.Add(tagparam, tagparam)
                            Else
                                _tagparam = n
                            End If

                            _ChannelIds.Add(chnlId)
                            TagNames.Add(tagname + "." + tagparam)
                        End If
                    End If


                    If Access_Level = "Area" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).Nodes(1).Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).Nodes(1).Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            If areas.Contains(area) Then
                                isavail = -1
                                Searchnode(_plant.Nodes, area, isavail, n)
                                If isavail = -1 Then
                                    _area = _plant.Nodes.Add(area, area)
                                Else
                                    _area = n
                                End If

                                isavail = -1
                                Searchnode(_area.Nodes, unit, isavail, n)
                                If isavail = -1 Then
                                    _unit = _area.Nodes.Add(unit, unit)
                                Else
                                    _unit = n
                                End If

                                isavail = -1
                                Searchnode(_unit.Nodes, equipment, isavail, n)
                                If isavail = -1 Then
                                    _equipment = _unit.Nodes.Add(equipment, equipment)
                                Else
                                    _equipment = n
                                End If

                                isavail = -1
                                Searchnode(_equipment.Nodes, tagmain, isavail, n)
                                If isavail = -1 Then
                                    _tagmain = _equipment.Nodes.Add(tagmain, tagmain)
                                Else
                                    _tagmain = n
                                End If

                                isavail = -1
                                Searchnode(_tagmain.Nodes, tagname, isavail, n)
                                If isavail = -1 Then
                                    _tagname = _tagmain.Nodes.Add(tagname, tagname)
                                Else
                                    _tagname = n
                                End If

                                isavail = -1
                                Searchnode(_tagname.Nodes, tagparam, isavail, n)
                                If isavail = -1 Then
                                    _tagparam = _tagname.Nodes.Add(tagparam, tagparam)
                                Else
                                    _tagparam = n
                                End If

                                _ChannelIds.Add(chnlId)
                                TagNames.Add(tagname + "." + tagparam)
                            End If
                        End If
                    End If



                    If Access_Level = "Unit" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).Nodes(1).Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).Nodes(1).Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            If areas.Contains(area) Then
                                isavail = -1
                                Searchnode(_plant.Nodes, area, isavail, n)
                                If isavail = -1 Then
                                    _area = _plant.Nodes.Add(area, area)
                                Else
                                    _area = n
                                End If


                                If units.Contains(unit) Then
                                    isavail = -1
                                    Searchnode(_area.Nodes, unit, isavail, n)
                                    If isavail = -1 Then
                                        _unit = _area.Nodes.Add(unit, unit)
                                    Else
                                        _unit = n
                                    End If

                                    isavail = -1
                                    Searchnode(_unit.Nodes, equipment, isavail, n)
                                    If isavail = -1 Then
                                        _equipment = _unit.Nodes.Add(equipment, equipment)
                                    Else
                                        _equipment = n
                                    End If

                                    isavail = -1
                                    Searchnode(_equipment.Nodes, tagmain, isavail, n)
                                    If isavail = -1 Then
                                        _tagmain = _equipment.Nodes.Add(tagmain, tagmain)
                                    Else
                                        _tagmain = n
                                    End If

                                    isavail = -1
                                    Searchnode(_tagmain.Nodes, tagname, isavail, n)
                                    If isavail = -1 Then
                                        _tagname = _tagmain.Nodes.Add(tagname, tagname)
                                    Else
                                        _tagname = n
                                    End If

                                    isavail = -1
                                    Searchnode(_tagname.Nodes, tagparam, isavail, n)
                                    If isavail = -1 Then
                                        _tagparam = _tagname.Nodes.Add(tagparam, tagparam)
                                    Else
                                        _tagparam = n
                                    End If
                                    _ChannelIds.Add(chnlId)
                                    TagNames.Add(tagname + "." + tagparam)
                                End If
                            End If
                        End If
                    End If


                    If Access_Level = "Equipment" Then
                        If plants.Contains(plant) Then
                            isavail = -1
                            Searchnode(TreeViewLeft.Nodes(0).Nodes(1).Nodes, plant, isavail, n)
                            If isavail = -1 Then
                                _plant = TreeViewLeft.Nodes(0).Nodes(1).Nodes.Add(plant, plant)
                            Else
                                _plant = n
                            End If

                            If areas.Contains(area) Then
                                isavail = -1
                                Searchnode(_plant.Nodes, area, isavail, n)
                                If isavail = -1 Then
                                    _area = _plant.Nodes.Add(area, area)
                                Else
                                    _area = n
                                End If

                                If units.Contains(unit) Then
                                    isavail = -1
                                    Searchnode(_area.Nodes, unit, isavail, n)
                                    If isavail = -1 Then
                                        _unit = _area.Nodes.Add(unit, unit)
                                    Else
                                        _unit = n
                                    End If


                                    If equipments.Contains(equipment) Then
                                        isavail = -1
                                        Searchnode(_unit.Nodes, equipment, isavail, n)
                                        If isavail = -1 Then
                                            _equipment = _unit.Nodes.Add(equipment, equipment)
                                        Else
                                            _equipment = n
                                        End If

                                        isavail = -1
                                        Searchnode(_equipment.Nodes, tagmain, isavail, n)
                                        If isavail = -1 Then
                                            _tagmain = _equipment.Nodes.Add(tagmain, tagmain)
                                        Else
                                            _tagmain = n
                                        End If

                                        isavail = -1
                                        Searchnode(_tagmain.Nodes, tagname, isavail, n)
                                        If isavail = -1 Then
                                            _tagname = _tagmain.Nodes.Add(tagname, tagname)
                                        Else
                                            _tagname = n
                                        End If

                                        isavail = -1
                                        Searchnode(_tagname.Nodes, tagparam, isavail, n)
                                        If isavail = -1 Then
                                            _tagparam = _tagname.Nodes.Add(tagparam, tagparam)
                                        Else
                                            _tagparam = n
                                        End If
                                        _ChannelIds.Add(chnlId)
                                        TagNames.Add(tagname + "." + tagparam)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GenerateTreeView()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
            'insertfilelog(ex.Message & "@GenerateTreeView() at Mainpage")
        End Try
    End Sub

    Private Sub Searchnode(ByVal chldNodes As TreeNodeCollection, ByVal NodeName As String, ByRef res As Integer, ByRef resnode As TreeNode)
        Try
            'Search the Selected Node 

            For Each nd As TreeNode In chldNodes

                If nd.Text = NodeName Then
                    resnode = nd
                    res = nd.Index
                    'nd.BackColor = Color.Green
                End If

                If nd.Nodes.Count > 0 Then
                    Searchnode(nd.Nodes, NodeName, res, resnode)
                End If
            Next
        Catch ex As Exception
            'insertfilelog(ex.Message & "@Searchnode() at Mainpage")
        End Try
    End Sub




    'Private Sub TreeViewReports_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
    '    Try
    '        If (Not TreeViewReports.SelectedNode Is Nothing) And TreeViewReports.Nodes(0).Name = "Generated Reports" Then
    '            If TreeViewReports.SelectedNode.GetNodeCount(True) = 0 And e.Node.FullPath.Contains("\XLS\") Then
    '                'OpenExcel(ReportLocation & "\" & e.Node.FullPath & ".xls", "Sheet1")
    '                System.Diagnostics.Process.Start(ReportLocation & "\" & e.Node.FullPath.Replace("        ", "") & ".xls")
    '            ElseIf TreeViewReports.SelectedNode.GetNodeCount(True) = 0 And e.Node.FullPath.Contains("\PDF\") Then
    '                System.Diagnostics.Process.Start(ReportLocation & "\" & e.Node.FullPath.Replace("        ", "") & ".pdf")
    '            ElseIf TreeViewReports.SelectedNode.GetNodeCount(True) = 0 And e.Node.FullPath.Contains("\HTML\") Then
    '                System.Diagnostics.Process.Start(ReportLocation & "\" & e.Node.FullPath.Replace("        ", "") & ".htm")
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub



#Region "MChart"

    '1st Time & From Saved Data
    'Create Chart & default objects
    'Create Default "property values"
    'create Default "variable values"

    'Sub1:
    'update "property values" in chart
    'Sub2:
    'update "variable values" in chart

    'While backend data update, 
    'update "variable values"
    ' & Call Sub2

    'While Properties screen update
    'update "property values"
    'update Or create "variable values"
    'Call Sub1 & Sub2

    'While Saving
    'Properties to dr
    '


    'First Time Creation
    Private Sub MORSChartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MORSChartToolStripMenuItem.Click

        Try
            modify = True

            If Not Me.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                Me.Text = Me.Text & " *"
            End If
            ' Create an empty chart.
            MChart_Ctrl = New MChartControl

L1:'
            If Ctrl_NameList.Contains("MChart" & _iniMchartName) Then 'Assign Unique Name
                _iniMchartName += 1
                GoTo L1
            End If
            MChartInit(MChart_Ctrl)
            Dim objMChartCtrl As MChartControl
            objMChartCtrl = MChart_Ctrl

            CreateDefaultPropertyValues(objMChartCtrl)
            CreateDefaultVariableValues(objMChartCtrl)
            UpdatePropertyValuesInChart(objMChartCtrl)
            'UpdateLambdaMinMaxFromOpcOneTime(objMChartCtrl)
            SetDataGridViewProperties(objMChartCtrl)
            SetDataGridViewValues(objMChartCtrl)
            'UpdateVariableValuesInChart(objMChartCtrl)
            AddExtraSeriesIfNecessary(objMChartCtrl)
            For I = 1 To objMChartCtrl.gintMCUnits
                PlotDataGridValuesInSeries(objMChartCtrl, I)
                CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, I)
                PlotIntersectValuesInChart(objMChartCtrl, I)
            Next
        Catch ex As Exception
            MsgBox("MORSToolClick:" & ex.Message)
        End Try

    End Sub

    Private Sub MChartInit(ByRef objMChartCtrl As MChartControl)

        Try
            CreateDefaultObjectsInMChart(objMChartCtrl)

            Page_Ctrl.Controls.Add(objMChartCtrl)

            objMChartCtrl.gdgvMORS = New DataGridView
            objMChartCtrl.gdgvUnitValues = New DataGridView

            DataGridViewInit(objMChartCtrl)

            Page_Ctrl.Controls.Add(objMChartCtrl.gdgvMORS)
            Page_Ctrl.Controls.Add(objMChartCtrl.gdgvUnitValues)
        Catch ex As Exception
            MsgBox("MCI:" & ex.Message)
        End Try

    End Sub

#Region "DataGridView"

    Private Sub DataGridViewInit(ByRef objMChartCtrl As MChartControl)

        Try
            With objMChartCtrl.gdgvMORS
                AddHandler .MouseClick, AddressOf Ctrl_Click
                AddHandler .MouseDown, AddressOf Ctrl_MouseDown
                AddHandler .MouseUp, AddressOf Ctrl_MouseUp
                AddHandler .MouseMove, AddressOf Ctrl_MouseMove
                AddHandler .MouseLeave, AddressOf Ctrl_MouseLeave
            End With

            With objMChartCtrl
                .gintMCDgvTop = 100
                .gintMCDgvLeft = 30
                .gintMCDgvWidth = 425
                .gintMCDgvHeight = 160

                .gintMCDgvCol0Width = 170
                .gintMCDgvCol1Width = 85
                .gintMCDgvCol2Width = 75
                .gintMCDgvCol3Width = 90
            End With

            With objMChartCtrl.gdgvMORS
                .Visible = True

                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToAddRows = False
                .EditMode = DataGridViewEditMode.EditProgrammatically

                .RowHeadersVisible = False
                .Columns.Clear()

                .Columns.Add("Index", "INDEX")
                .Columns.Add("LoadScheduled", "LOAD SCHEDULED")
                .Columns.Add("Ifc", "IFC")
                .Columns.Add("GenerationCost", "GENERATION COST")

                For I = 0 To .Columns.Count - 1
                    .Columns(I).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next

                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception
            MsgBox("DGVI1:" & ex.Message)
        End Try

        Try
            'UnitValues
            With objMChartCtrl.gdgvUnitValues
                AddHandler .MouseClick, AddressOf Ctrl_Click
                AddHandler .MouseDown, AddressOf Ctrl_MouseDown
                AddHandler .MouseUp, AddressOf Ctrl_MouseUp
                AddHandler .MouseMove, AddressOf Ctrl_MouseMove
                AddHandler .MouseLeave, AddressOf Ctrl_MouseLeave
                'AddHandler .CellEndEdit, AddressOf mySampleDGV_CellEndEdit
                AddHandler .CellValidating, AddressOf mySampleDGV_CellValidating
                AddHandler .CellPainting, AddressOf mySampleDGV_CellPainting
            End With

            With objMChartCtrl
                .gintMCDgvUnitTop = 100
                .gintMCDgvUnitLeft = 500
                .gintMCDgvUnitWidth = 325
                .gintMCDgvUnitHeight = 130

                .gintMCDgvUnitColWidth = 75
            End With

            With objMChartCtrl.gdgvUnitValues
                .Visible = True

                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToAddRows = False
                '.EditMode = DataGridViewEditMode.EditProgrammatically
                .AllowUserToOrderColumns = False
                .RowHeadersVisible = False
                ToolTip1.Show("F4 to Refresh Data from OPC", objMChartCtrl.gdgvUnitValues)

                .Columns.Clear()
                For I = 1 To objMChartCtrl.gintMcUnits
                    .Columns.Add("P" & I, "P" & I)
                    .Columns.Add("PLambda" & I, "PLambda" & I)
                    .Columns(I - 1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(I - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    '.Columns("PLambda" & I).Visible = False
                Next
                For I = 0 To .Columns.Count - 1
                    .Columns(I).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End With
        Catch ex As Exception
            MsgBox("DGVI2:" & ex.Message)
        End Try

    End Sub

    Private Sub mySampleDGV_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) 'Handles mySampleDGV.Validating

        If Not IsNumeric(e.FormattedValue) Then
            MsgBox("Invalid Value!")
            e.Cancel = True
        Else
            Try
                Dim dgvUnitValues As DataGridView
                dgvUnitValues = DirectCast(sender, DataGridView)
                Dim objMChartCtrl As MChartControl
                objMChartCtrl = Me.MChart_Ctrl
                With objMChartCtrl
                    Dim dblValue As Double
                    Dim strItemP, strItemPLambda As String
                    Dim intPosInLOS, intUnit As Integer
                    intPosInLOS = e.ColumnIndex / 2
                    intUnit = intPosInLOS + 1

                    strItemP = MakeOpcReadable(.glosMCTagForMan(intPosInLOS))
                    strItemPLambda = MakeOpcReadable(.glosMCTagForPLambda(intPosInLOS))

                    If dgvUnitValues.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = e.FormattedValue Then
                        'If MsgBox("Wish to read data again from OPC Server?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        '    dblValue = FetchYValue(.gstrMCWritebackOpcServer, strItemPLambda)

                        '    dgvUnitValues.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = dblValue

                        '    PlotDataGridValuesInSeries(objMChartCtrl, intUnit)
                        'End If
                        Exit Sub
                    End If

                    Dim strValue As String = ""
                    'For Each dgvOneRow As DataGridViewRow In dgvUnitValues.Rows
                    '    strValue &= dgvOneRow.Cells(e.ColumnIndex).FormattedValue & ","
                    'Next
                    For I = 0 To dgvUnitValues.Rows.Count - 1
                        Dim dgvOneRow As DataGridViewRow
                        dgvOneRow = dgvUnitValues.Rows(I)
                        If e.RowIndex = I Then
                            strValue &= e.FormattedValue & ","
                        Else
                            strValue &= dgvOneRow.Cells(e.ColumnIndex).Value & ","
                        End If
                    Next
                    If strValue <> "" Then
                        strValue = strValue.Substring(0, strValue.Length - 1)
                    End If
                    '.glosMCActData(intPosInLOS) = strValue
                    WriteInOpc(.gstrMCWritebackOpcServer, strItemP, e.FormattedValue)
                    'Wait for Few Seconds
                    Threading.Thread.CurrentThread.Sleep(2000)

                    dblValue = FetchYValue(.gstrMCWritebackOpcServer, strItemPLambda)

                    dgvUnitValues.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = dblValue
                    'Dim sngP, sngPLambda As Single
                    'sngP = e.FormattedValue
                    'sngPlambda = dblValue
                    '.gdtMCLiveData.Rows.Add({e.ColumnIndex, sngP, sngPLambda})
                    PlotDataGridValuesInSeries(objMChartCtrl, intUnit)
                    CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, intUnit)
                    PlotIntersectValuesInChart(objMChartCtrl, intUnit)
                End With
            Catch ex As Exception
                MsgBox("mSDCV:" & ex.Message)
            End Try
        End If

    End Sub

    Private Sub mySampleDGV_CellPainting(Sender As Object, e As DataGridViewCellPaintingEventArgs)
        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

        If (e.RowIndex < 1 OrElse e.ColumnIndex < 0) Then
            Exit Sub
        End If
        Dim dgv As DataGridView
        dgv = DirectCast(Sender, DataGridView)
        If (IsTheSameCellValue(dgv, e.ColumnIndex, e.RowIndex)) Then
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
        Else
            e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top
        End If
        'If dgv Then

        'End If
    End Sub
    Private Function IsTheSameCellValue(dgv As DataGridView, intCol As Integer, intRow As Integer) As Boolean
        Dim dgvCell1, dgvCell2 As DataGridViewCell
        dgvCell1 = dgv(intCol, intRow)
        dgvCell2 = dgv(intCol, intRow - 1)
    End Function

    Private Sub PlotDataGridValuesInSeries(ByRef objMChartCtrl As MChartControl,
                                           intUnit As Integer)

        Try
            With objMChartCtrl
                .Series("P" & intUnit).Points.Clear()
                .Series("IntersectP" & intUnit).Points.Clear()
                For Each dgvOneRow As DataGridViewRow In .gdgvUnitValues.Rows
                    Dim sngPX, sngPLambdaY As Single
                    sngPX = dgvOneRow.Cells((intUnit - 1) * 2).Value
                    sngPLambdaY = dgvOneRow.Cells((intUnit - 1) * 2 + 1).Value
                    .Series("P" & intUnit).Points.AddPoint(sngPX, sngPLambdaY)
                Next
            End With
        Catch ex As Exception
            MsgBox("PDGVIS:" & ex.Message)
        End Try

    End Sub

    Private Sub PlotIntersectValuesInChart(ByRef objMChartCtrl As MChartControl,
                                           intUnit As Integer)

        Try
            With objMChartCtrl
                .Series("IntersectP" & intUnit).Points.AddPoint(.glogIntersectX1(intUnit - 1), .glogIntersectY1(intUnit - 1))
                .Series("IntersectP" & intUnit).Points.AddPoint(.glogIntersectX2(intUnit - 1), .glogIntersectY2(intUnit - 1))
                .Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations.AddTextAnnotation("IntersectP" & intUnit, "Optimum: " & .glogIntersectX2(intUnit - 1))
                .Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations(0).RuntimeMoving = True
                '.Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations(0).RuntimeResizing = True
                '.Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations(0).RuntimeRotation = True
                '.Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations(0).Angle = 45

                If .gstrIntersectAnnotationData <> "" Then
                    Dim strOneAnnotationData As String
                    strOneAnnotationData = Split(.gstrIntersectAnnotationData, "~")(intUnit - 1)
                    Dim rp As DevExpress.XtraCharts.RelativePosition = New DevExpress.XtraCharts.RelativePosition
                    rp.Angle = Split(strOneAnnotationData, ",")(0)
                    rp.ConnectorLength = Split(strOneAnnotationData, ",")(1)
                    .Series("IntersectP" & intUnit).Points(.Series("IntersectP" & intUnit).Points.Count - 1).Annotations(0).ShapePosition = rp
                End If
            End With
        Catch ex As Exception
            MsgBox("PIVIC:" & ex.Message)
        End Try

    End Sub

    Private Function MakeOpcReadable(strItemBefore As String) As String

        Dim strItemReadable As String
        strItemReadable = strItemBefore

        strItemReadable = Split(strItemReadable, "_")(0)
        strItemReadable = strItemReadable.Replace("#", ".")

        Return strItemReadable

    End Function


    Private Function FetchYValue(strOpcServerName As String, strItemPLambda As String,
                                 Optional strItemP As String = "",
                                 Optional dblItemPValue As Double = 0
                                 ) As Double

        Dim dblValue As Double = 0D
        If strOpcServerName Is Nothing OrElse strOpcServerName = "" Then
            Return dblValue
        End If
        If strItemP <> "" Then
            WriteInOpc(strOpcServerName, strItemP, dblItemPValue)
        End If
        'Wait for Few Seconds
        Threading.Thread.CurrentThread.Sleep(2000)
        dblValue = ReadFromOpc(strOpcServerName, strItemPLambda)

        Return dblValue

    End Function

    Private Sub WriteInOpc(strOpcServerName As String, strItem As String, dblValue As Double)

        If strOpcServerName Is Nothing OrElse strOpcServerName = "" Then
            Exit Sub
        End If
        Try
            Dim myOpcServer As OpcServer
            Dim myRefreshGroup As RefreshGroup
            myOpcServer = New OpcServer
            'Dim strOpcServerName As String = "SAMA.DAServerV2.1"
            'strOpcServerName = "Matrikon.OPC.Simulation.1"
            Dim intResult As Integer
            intResult = myOpcServer.Connect(strOpcServerName)
            myRefreshGroup = myOpcServer.AddRefreshGroup(500, AddressOf RefreshGroupHandler)
            myRefreshGroup.OpcGrp.Active = True

            Dim intErr As Integer
            intErr = myRefreshGroup.Add(strItem)
            If HRESULTS.Failed(intErr) Then
                MsgBox("Unable to Update in OPC Server - Err1-Code:" & intErr)
            Else
                intResult = myRefreshGroup.Write(strItem, dblValue)
                If HRESULTS.Failed(intResult) Then
                    MsgBox("Unable to Update in OPC Server - WriteErr-Code:" & intResult & " - " & strItem)
                End If
            End If

            If myOpcServer.isConnectedDA Then
                myOpcServer.Disconnect()
            End If
            myOpcServer = Nothing
        Catch ex As Exception
            MsgBox("WIO:" & ex.Message)
        End Try

    End Sub

    Private Function ReadFromOpc(strOpcServerName As String, strItem As String) As Double

        Dim dblReturn As Double = 0D
        Dim myOpcServer As OpcServer = New OpcServer()
        Dim rtc As Int32 = myOpcServer.Connect(strOpcServerName)
        If HRESULTS.Failed(rtc) Then
            MsgBox("RFO:ErrConnecting Server:" & myOpcServer.GetErrorString(rtc, 0))
        Else
            Dim srwGroup As SyncIOGroup = New SyncIOGroup(myOpcServer)
            Dim objRslt As New OPCItemState
            srwGroup = New SyncIOGroup(myOpcServer)
            rtc = srwGroup.Read(OPCDATASOURCE.OPC_DS_DEVICE, strItem, objRslt)
            If HRESULTS.Failed(rtc) Then
                MsgBox("RFO2:ReadErr-" & strItem & ":" & rtc)
            Else
                dblReturn = objRslt.DataValue
            End If
            srwGroup.Dispose()
        End If
        If myOpcServer.isConnectedDA Then
            myOpcServer.Disconnect()
        End If
        myOpcServer = Nothing
        Return dblReturn

    End Function

    Private Sub UpdateLambdaMinMaxFromOpcOneTime(ByRef objMChartControl As MChartControl)

        Try
            With objMChartControl
                If .gstrMCTagForLambda Is Nothing OrElse .gstrMCTagForLambda = "" Then
                    Exit Sub
                End If
                Dim strLambdaTagName As String
                strLambdaTagName = MakeOpcReadable(.gstrMCTagForLambda)

                Dim sngLambdaX1, sngLambdaY1, sngLambdaX2, sngLambdaY2 As Single
                sngLambdaX1 = X_AXIS_MIN_VALUE
                sngLambdaY1 = ReadFromOpc(.gstrMCWritebackOpcServer, strLambdaTagName)
                sngLambdaX2 = X_AXIS_MAX_VALUE
                sngLambdaY2 = sngLambdaY1
                .gsngLambdaY1 = sngLambdaY1
                .gsngLambdaY2 = sngLambdaY1

                UpdateLambda(objMChartControl)

                Dim intUnits As Integer
                intUnits = .gintMCUnits
                For I = 1 To intUnits
                    Dim strMinTagName, strMaxTagName As String
                    strMinTagName = MakeOpcReadable(.glosMCTagForMin(I - 1))
                    strMaxTagName = MakeOpcReadable(.glosMCTagForMax(I - 1))
                    Dim sngMinX1, sngMinY1, sngMinX2, sngMinY2 As Single
                    Dim sngMaxX1, sngMaxY1, sngMaxX2, sngMaxY2 As Single

                    sngMinX1 = ReadFromOpc(.gstrMCWritebackOpcServer, strMinTagName)
                    sngMinY1 = Y_AXIS_MIN_VALUE
                    sngMinX2 = sngMinX1
                    sngMinY2 = Y_AXIS_MAX_VALUE


                    sngMaxX1 = ReadFromOpc(.gstrMCWritebackOpcServer, strMaxTagName)
                    sngMaxY1 = Y_AXIS_MIN_VALUE
                    sngMaxX2 = sngMaxX1
                    sngMaxY2 = Y_AXIS_MAX_VALUE

                    .Series("MinP" & I).Points.Clear()
                    .Series("MinP" & I).Points.AddPoint(sngMinX1, sngMinY1)
                    .Series("MinP" & I).Points.AddPoint(sngMinX2, sngMinY2)

                    .Series("MaxP" & I).Points.Clear()
                    .Series("MaxP" & I).Points.AddPoint(sngMaxX1, sngMaxY1)
                    .Series("MaxP" & I).Points.AddPoint(sngMaxX2, sngMaxY2)
                Next

            End With
        Catch ex As Exception
            MsgBox("ULMMFOOT:" & ex.Message)
        End Try

    End Sub

    Private Sub UpdateLambda(ByRef objMChartCtrl As MChartControl)
        With objMChartCtrl
            .Series("Lambda").Points.Clear()
            .Series("Lambda").Points.AddPoint(.gsngLambdaX1, .gsngLambdaY1)
            .Series("Lambda").Points.AddPoint(.gsngLambdaX2, .gsngLambdaY2)
        End With
    End Sub

    Private Sub RefreshGroupHandler(ByVal sender As Object, ByVal arg As RefreshEventArguments)
        If arg.Reason = RefreshEventReason.ReadCompleted Then
            intCurrent = arg.items(0).OpcIRslt.DataValue
        End If
    End Sub

    Private Sub SetDataGridViewProperties(ByRef objMChartCtrl As MChartControl)

        Try
            With objMChartCtrl.gdgvMORS
                .Top = objMChartCtrl.gintMCDgvTop
                .Left = objMChartCtrl.gintMCDgvLeft
                .Width = objMChartCtrl.gintMCDgvWidth
                .Height = objMChartCtrl.gintMCDgvHeight

                .Columns(0).Width = objMChartCtrl.gintMCDgvCol0Width
                .Columns(1).Width = objMChartCtrl.gintMCDgvCol1Width
                .Columns(2).Width = objMChartCtrl.gintMCDgvCol2Width
                .Columns(3).Width = objMChartCtrl.gintMCDgvCol3Width
                .ColumnHeadersHeight = 40
            End With
        Catch ex As Exception
            MsgBox("SDGVP1:" & ex.Message)
        End Try

        Try
            With objMChartCtrl.gdgvUnitValues
                .Top = objMChartCtrl.gintMCDgvUnitTop
                .Left = objMChartCtrl.gintMCDgvUnitLeft
                .Width = objMChartCtrl.gintMCDgvUnitWidth
                .Height = objMChartCtrl.gintMCDgvUnitHeight

                For Each dgvOneColumn As DataGridViewColumn In .Columns
                    dgvOneColumn.Width = objMChartCtrl.gintMCDgvUnitColWidth
                Next
                'For I = 1 To objMChartCtrl.gintMcUnits
                '    .Columns(I - 1).Width = objMChartCtrl.gintMCDgvUnitColWidth
                'Next
            End With
        Catch ex As Exception
            MsgBox("SDGVP2:" & ex.Message)
        End Try

    End Sub

    Private Sub SetDataGridViewValues(ByRef objMChartCtrl As MChartControl)

        objMChartCtrl.gdgvMORS.Rows.Clear()

        Dim intUnits As Integer
        intUnits = objMChartCtrl.gintMcUnits

        Try
            With objMChartCtrl
                'For I = 1 To intUnits
                '    If I > .glogLoadScheduledUnitOptimalLoading.Count Then
                '        .glogLoadScheduledUnitOptimalLoading.Add(0)
                '        .glogLoadScheduledUnitLoadingAtPresent.Add(0)
                '        .glogIFCUnitOptimalLoading.Add(0)
                '        .glogIFCUnitLoadingAtPresent.Add(0)
                '    End If
                'Next
                For I = 1 To intUnits
                    .gdgvMORS.Rows.Add({"UNIT-" & I & " OPTIMUM LOADING", 0, 0, 0})
                Next
                For I = 1 To intUnits
                    .gdgvMORS.Rows.Add({"UNIT-" & I & " LOADING AT PRESENT", 0, 0, 0})
                Next
                .gdgvMORS.Rows.Add({"COST OF GENERATION AT PRESENT", 0, 0, 0})
                .gdgvMORS.Rows.Add({"OPTIMUM COST OF GENERATION", 0, 0, 0})
                .gdgvMORS.Rows.Add({"PROVISION FOR PROFIT", 0, 0, 0})
                .gdgvMORS.AutoGenerateColumns = False

                '.gdgvMORS.Columns.Add(New DataGridViewTextBoxColumn)
                'Dim dgvCell As DataGridViewTextBoxCell
                'dgvCell = .gdgvMORS(4, intUnits * 2 + 1,)
                'Dim dg As DataGridViewCell
                'dg.colspan dgvCell.colspan
                '.gdgvMORS.Rows(intUnits * 2 + 1).Cells(2).COLSPAN

                .gdgvMORS.Refresh()
            End With
        Catch ex As Exception
            MsgBox("SDGVV1:" & ex.Message)
        End Try

        If False Then
            Try
                'With objMChartCtrl.gdgvUnitValues
                '    For I = 1 To 7
                '        Dim strData As String = ""
                '        For J = 1 To objMChartCtrl.gintMcUnits
                '            strData &= I * 100 & ","
                '        Next
                '        strData = strData.Substring(0, strData.Length - 1)
                '        .Rows.Add(Split(strData, ","))
                '    Next
                '    .Refresh()
                'End With
                'With objMChartCtrl
                '    If .glosMCActData(0) = "" Then
                '        'First Time?
                '        .glosMCActData.Clear()
                '        For I = 1 To .gintMcUnits
                '            Dim strData As String = ""
                '            For J = 1 To .gintMCSamples
                '                strData = strData & J * 100 & "," & J * 100 & ","

                '            Next
                '            strData = strData.Substring(0, strData.Length - 1)
                '            '.glosMCActData.Add("100,200,300,400,500,600,700")
                '            .glosMCActData.Add(strData)
                '        Next
                '    End If
                'End With

                'With objMChartCtrl
                '    'Dim losKey, losData As New List(Of String)
                '    'losKey.Clear()
                '    'losData.Clear()
                '    ''1~Unit1XValue~Unit1YValue~Unit2XValue~Unit2YValue

                '    'For J = 0 To .glosMCActData.Count - 1
                '    '    Dim aryData() As String = Split(.glosMCActData(J), ",")
                '    '    For I = 0 To aryData.Length - 1
                '    '        Dim dblYValue As Double
                '    '        Dim intUnitNo As Integer
                '    '        Dim strItemP, strItemPLambda As String
                '    '        intUnitNo = J + 1
                '    '        '
                '    '        'Pass current X value and fetch Y value
                '    '        '
                '    '        strItemP = MakeOpcReadable(.glosMCTagForMan(intUnitNo - 1))
                '    '        strItemPLambda = MakeOpcReadable(.glosMCTagForPLambda(intUnitNo - 1))

                '    '        dblYValue = FetchYValue(.gstrMCWritebackOpcServer, strItemPLambda, strItemP, aryData(I))
                '    '        If losKey.Contains(I) Then
                '    '            losData(I) &= "," & aryData(I) & "," & dblYValue
                '    '        Else
                '    '            losKey.Add(I)
                '    '            losData.Add(aryData(I) & "," & dblYValue)
                '    '        End If
                '    '    Next
                '    'Next

                '    '.gdgvUnitValues.Rows.Clear()

                '    'For Each strOneData In losData
                '    '    .gdgvUnitValues.Rows.Add(Split(strOneData, ","))
                '    'Next
                'End With
            Catch ex As Exception
                MsgBox("SDGVV2:" & ex.Message)
            End Try
        End If

    End Sub

#End Region

#Region "CreateDefaults"

    Private Sub CreateDefaultObjectsInMChart(ByRef objMChartCtrl As MChartControl)

        Try

            With objMChartCtrl
                AddHandler .MouseClick, AddressOf Ctrl_Click
                AddHandler .MouseDown, AddressOf Ctrl_MouseDown
                AddHandler .MouseUp, AddressOf Ctrl_MouseUp
                AddHandler .MouseMove, AddressOf Ctrl_MouseMove
                AddHandler .MouseLeave, AddressOf Ctrl_MouseLeave

                .CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False

                'Create Chart Title
                Dim charttitle As ch.ChartTitle = New ch.ChartTitle
                .Titles.Add(charttitle)

                'objMChartCtrl.AutoSize = False

                Dim mySeriesLambda As ch.Series = New ch.Series("Lambda", ch.ViewType.Line)

                Dim mySeriesForP1 As ch.Series = New ch.Series("P1", ch.ViewType.Line)
                Dim mySeriesIntersectP1 As ch.Series = New ch.Series("IntersectP1", ch.ViewType.Line)
                Dim mySeriesMinP1 As ch.Series = New ch.Series("MinP1", ch.ViewType.Line)
                Dim mySeriesMaxP1 As ch.Series = New ch.Series("MaxP1", ch.ViewType.Line)

                .Series.Add(mySeriesLambda)

                .Series.Add(mySeriesForP1)
                .Series.Add(mySeriesIntersectP1)
                .Series.Add(mySeriesMinP1)
                .Series.Add(mySeriesMaxP1)

                Dim diagram As ch.XYDiagram = TryCast(.Diagram, ch.XYDiagram)
                ' Customize the appearance of the X-axis title.
                diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True
                diagram.AxisX.Title.Alignment = StringAlignment.Center

                ' Customize the appearance of the Y-axis title.
                diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True
                diagram.AxisY.Title.Alignment = StringAlignment.Center

                For I = 0 To .Series.Count - 1
                    .Series(I).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
                    .Series(I).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                Next


                'Dim tan As New DevExpress.XtraCharts.TextAnnotation("Test", "Test1")
                '.AnnotationRepository.Add(tan)
                'Dim cap As DevExpress.XtraCharts.ChartAnchorPoint = New DevExpress.XtraCharts.ChartAnchorPoint
                'cap.X = 200
                'cap.Y = 200
                'tan.AnchorPoint = cap
                'Dim rp As DevExpress.XtraCharts.RelativePosition = New DevExpress.XtraCharts.RelativePosition
                'rp.Angle = 20
                'rp.ConnectorLength = 100
                'tan.ShapePosition = rp


                .gintMcUnits = 2
            End With
        Catch ex As Exception
            MsgBox("CDOIM:" & ex.Message)
        End Try


        'mySeriesMinLine.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        'mySeriesMaxLine.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

    End Sub

    Private Sub CreateDefaultPropertyValues(ByRef objMChartCtrl As MChartControl)

        Dim aryPColors() As String =
            {Color.Red.ToArgb,
            Color.Blue.ToArgb,
            Color.Green.ToArgb,
            Color.Brown.ToArgb,
            Color.Gray.ToArgb,
            Color.DarkBlue.ToArgb,
            Color.IndianRed.ToArgb,
            Color.Magenta.ToArgb,
            Color.Orange.ToArgb}

        Try
            With objMChartCtrl
                .gstrMCTitle = "MORS Chart"
                .gstrMCTitleFont = "Tahoma,8,Regular," & Color.Black.ToArgb
                .gstrMCXAxisTitle = "-> Output"
                .gstrMCYAxisTitle = "IFC (Lambda)"
                .gstrMCXYAxisTitleColor = Color.Black.ToArgb
                .gstrMCChartBackColor = Color.Gray.ToArgb
                .gstrMCLegendEnable = "1"
                .gstrMCLegendColor = Color.Green.ToArgb
                .gstrMCAxisLabelEnable = "1"
                .gstrMCAxisLabelColor = Color.DarkBlue.ToArgb

                .gstrMCActionChannel = ""
                .gstrMCActionChannel = "MORS"
                .gintMcTargetPower = 1400
                .gintMcUnits = 2
                .gintMcSamples = 7
                .gstrMCWritebackOpcServer = "Matrikon.OPC.Simulation.1"
                .gintTop = 250
                .gintLeft = 30
                .gintHeight = 300
                .gintWidth = 800


                .gstrMCTagForLambda = "ULambda.CV"
                .gstrMCLambdaSeriesName = "Lambda"
                .gstrMCLambdaSeriesColor = Color.Cyan.ToArgb

                .glosMCTagForMan.Clear()
                .glosMCTagForPLambda.Clear()
                .glosMCTagForOpt.Clear()
                .glosMCTagForMin.Clear()
                .glosMCMinColor.Clear()
                .glosMCTagForMax.Clear()
                .glosMCMaxColor.Clear()
                .glosMCSeriesName.Clear()
                .glosMCSeriesColor.Clear()
                .glosMCIntersectName.Clear()
                .glosMCIntersectColor.Clear()
                '.glosMCActData.Clear()

                For I = 1 To .gintMCUnits
                    .glosMCTagForMan.Add("ActP" & I & ".PV")
                    .glosMCTagForPLambda.Add("U" & I & "P.CV")
                    .glosMCTagForOpt.Add("OptP" & I & ".CV")
                    .glosMCTagForMin.Add("P" & I & "min.SV")
                    .glosMCMinColor.Add(aryPColors(I - 1))
                    .glosMCTagForMax.Add("P" & I & "max.SV")
                    .glosMCMaxColor.Add(aryPColors(I - 1))
                    .glosMCSeriesName.Add("P" & I)
                    .glosMCSeriesColor.Add(aryPColors(I - 1))
                    .glosMCIntersectName.Add("Intersect" & I)
                    .glosMCIntersectColor.Add(Color.GreenYellow.ToArgb)
                    '.glosMCActData.Add("100,200,300,400,500,600,700")
                    '.glosMCActData.Add("")

                    'Vertical Lines
                    .glogMinX1.Add(X_AXIS_MIN_VALUE)
                    .glogMinY1.Add(Y_AXIS_MIN_VALUE)
                    .glogMinX2.Add(X_AXIS_MIN_VALUE)
                    .glogMinY2.Add(Y_AXIS_MAX_VALUE)

                    .glogMaxX1.Add(X_AXIS_MAX_VALUE)
                    .glogMaxY1.Add(Y_AXIS_MIN_VALUE)
                    .glogMaxX2.Add(X_AXIS_MAX_VALUE)
                    .glogMaxY2.Add(Y_AXIS_MAX_VALUE)

                    .glogIntersectX1.Add(X_AXIS_MIN_VALUE)
                    .glogIntersectY1.Add(Y_AXIS_MAX_VALUE)
                    .glogIntersectX2.Add(X_AXIS_MIN_VALUE)
                    .glogIntersectY2.Add(Y_AXIS_MAX_VALUE)
                Next

                'CreateDefaultLiveDataTableColumns(objMChartCtrl)

                'Grid Values
                'For I = 1 To 2
                '    .glogLoadScheduledUnitOptimalLoading.Add(0)
                '    .glogLoadScheduledUnitLoadingAtPresent.Add(0)
                '    .glogIFCUnitOptimalLoading.Add(0)
                '    .glogIFCUnitLoadingAtPresent.Add(0)
                'Next
            End With
        Catch ex As Exception
            MsgBox("CDVFMV:" & ex.Message)
        End Try

    End Sub

    'Private Sub CreateDefaultLiveDataTableColumns(ByRef objMChartControl As MChartControl)

    '    With objMChartControl
    '        .gdtMCLiveData.Columns.Add(New DataColumn("PUnitNo", Type.GetType("System.Single")))
    '        .gdtMCLiveData.Columns.Add(New DataColumn("PX", Type.GetType("System.Single")))
    '        .gdtMCLiveData.Columns.Add(New DataColumn("PY", Type.GetType("System.Single")))
    '    End With

    'End Sub

    Private Sub CreateDefaultVariableValues(ByRef objMChartCtrl As MChartControl)

        CreateDefaultDataForLambda(objMChartCtrl)
        CreateSeriesDataForTesting(objMChartCtrl)
        For I = 1 To objMChartCtrl.gintMcUnits
            CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, I)
        Next

    End Sub

    Private Sub CreateDefaultDataForLambda(ByRef objMChartCtrl As MChartControl)

        objMChartCtrl.gsngLambdaX1 = X_AXIS_MIN_VALUE - 50
        objMChartCtrl.gsngLambdaY1 = 2100
        objMChartCtrl.gsngLambdaX2 = X_AXIS_MAX_VALUE + 50
        objMChartCtrl.gsngLambdaY2 = 2100

    End Sub

    Private Sub CreateSeriesDataForTesting(ByRef objMChartCtrl As MChartControl)

        Try
            'Dim sngMax As Single = 0
            Dim aryData() As String, losData As New List(Of String)
            aryData = File.ReadAllLines(System.Environment.CurrentDirectory & "\MORSChartData.csv")
            losData.AddRange(aryData)
            For Each strOne In losData
                Dim aryOne() As String
                Dim sngP, sngBeta, sngGamma, sngLambda As Single
                aryOne = Split(strOne, ",")
                If Not IsNumeric(aryOne(0)) Then
                    Continue For
                End If
                Dim strOneRowData As String = ""
                For I = 1 To 5
                    Dim J As Integer
                    sngP = aryOne((I - 1) * 5 + 0)
                    sngBeta = aryOne((I - 1) * 5 + 1)
                    sngGamma = aryOne((I - 1) * 5 + 2)
                    sngLambda = aryOne((I - 1) * 5 + 3)
                    strOneRowData &= "," & sngP & "," & sngLambda
                Next
                strOneRowData = strOneRowData.Substring(1)
                objMChartCtrl.gdgvUnitValues.Rows.Add(Split(strOneRowData, ","))
                'objMChartCtrl.gdtMCLiveData.Rows.Add({I, sngP, sngLambda})
            Next
            objMChartCtrl.gintMCSamples = objMChartCtrl.gdgvUnitValues.Rows.Count

        Catch ex As Exception
            MsgBox("CSDFT:" & ex.Message)
        End Try

    End Sub

#End Region

    Public Sub CalculateIntersectAndUpdateIntersectVariables(ByRef objMChartCtrl As MChartControl,
                               intUnit As Integer)

        Dim sngLineX1, sngLineY1, sngLineX2, sngLineY2 As Single

        Try
            sngLineY1 = 0
            sngLineY2 = objMChartCtrl.gsngLambdaY1

            Try
                With objMChartCtrl
                    Dim intColPosForX, intColPosForY As Integer
                    intColPosForX = (intUnit - 1) * 2
                    intColPosForY = intColPosForX + 1
                    For Each dgvOneRow As DataGridViewRow In .gdgvUnitValues.Rows
                        Dim sngP, sngLambdaForP As Single
                        sngP = dgvOneRow.Cells(intColPosForX).Value
                        sngLambdaForP = dgvOneRow.Cells(intColPosForY).Value
                        If sngLambdaForP > sngLineY1 And sngLambdaForP < objMChartCtrl.gsngLambdaY1 Then
                            sngLineX1 = sngP
                            sngLineY1 = sngLambdaForP
                        End If
                        If sngLambdaForP > sngLineY2 And sngLineY2 = objMChartCtrl.gsngLambdaY1 Then 'First Time
                            sngLineX2 = sngP
                            sngLineY2 = sngLambdaForP
                        End If
                    Next
                End With
            Catch ex As Exception
                MsgBox("UI1:" & ex.Message)
            End Try

            Dim sngLineM, sngLineB As Single

            Dim strEquationForP, strEquationForLambda As String

            Dim sngLambdaM, sngLambdaB As Single
            Try
                strEquationForLambda = GetLinearEquationYEqualToMXPlusB(objMChartCtrl.gsngLambdaX1, objMChartCtrl.gsngLambdaY1,
                                                          objMChartCtrl.gsngLambdaX2, objMChartCtrl.gsngLambdaY2,
                                                          sngLambdaM, sngLambdaB)


                strEquationForP = GetLinearEquationYEqualToMXPlusB(sngLineX1, sngLineY1,
                                                          sngLineX2, sngLineY2,
                                                          sngLineM, sngLineB)

            Catch ex As Exception
                MsgBox("UI2:" & ex.Message)
            End Try
            'Get the two equations for the lines into slope-intercept form. 
            'That Is, have them in this form: y = mx + b.
            'Set the two equations For y equal To Each other.
            'Solve for x. This will be the x-coordinate for the point of intersection.
            'Use this x-coordinate And substitute it into either of the original equations for the lines And solve for y. This will be the y-coordinate of the point of intersection.

            Dim sngIntersectX, sngIntersectY As Single, strRevisedEquation As String
            'sngY = 2100
            Try
                'Subtract the two equations
                strRevisedEquation = strEquationForP & " - " & strEquationForLambda
                sngIntersectX = (sngLambdaB - sngLineB) / (sngLineM - sngLambdaM)
                sngIntersectY = sngLineM * sngIntersectX + sngLineB
            Catch ex As Exception
                MsgBox("UI3:" & ex.Message)
            End Try
            'MsgBox("Intersect1:" & sngIntersect1X & ", " & sngIntersect1Y)

            'If sngIntersect1X > sngLine1X1 And sngIntersect1X < sngLine1X2 Then
            '    sngIntersect1X = 0
            'End If
            'If sngIntersect1Y > sngLine1Y1 And sngIntersect1Y < sngLine1Y2 Then
            '    sngIntersect1Y = 0
            'End If

            With objMChartCtrl
                If intUnit > .glogIntersectX1.Count Then
                    .glogIntersectX1.Add(sngIntersectX)
                    .glogIntersectY1.Add(Y_AXIS_MIN_VALUE)
                    .glogIntersectX2.Add(sngIntersectX)
                    .glogIntersectY2.Add(sngIntersectY)
                Else
                    .glogIntersectX1(intUnit - 1) = sngIntersectX
                    .glogIntersectY1(intUnit - 1) = Y_AXIS_MIN_VALUE
                    .glogIntersectX2(intUnit - 1) = sngIntersectX
                    .glogIntersectY2(intUnit - 1) = sngIntersectY
                End If

                If .gdgvMORS.Rows.Count > 0 Then
                    .gdgvMORS.Rows(intUnit - 1).Cells(1).Value = sngIntersectX
                    .gdgvMORS.Rows(intUnit - 1).Cells(2).Value = sngIntersectY
                    .gdgvMORS.Rows(intUnit - 1).Cells(3).Value = sngIntersectY * .gsngPricePerUnit
                End If
            End With
        Catch ex As Exception
            MsgBox("UI3A:" & ex.Message)
        End Try

        If False Then
                    'objMChartCtrl.gdgvMORS.Rows(0).Cells(1).Value = objMChartCtrl.gsngLoadScheduledUnit1OptimalLoading
                    'objMChartCtrl.gdgvMORS.Rows(1).Cells(1).Value = objMChartCtrl.gsngLoadScheduledUnit2OptimalLoading
                    'objMChartCtrl.gdgvMORS.Rows(2).Cells(1).Value = objMChartCtrl.gsngLoadScheduledUnit1LoadingAtPresent
                    'objMChartCtrl.gdgvMORS.Rows(3).Cells(1).Value = objMChartCtrl.gsngLoadScheduledUnit2LoadingAtPresent
                    'objMChartCtrl.gdgvMORS.Refresh()
                    'Try
                    '    Dim dv As DataView
                    '    dv = objMChartCtrl.gdtMCLiveData.DefaultView

                    '    objMChartCtrl.gdtMCLiveData.DefaultView.Sort = "PY ASC"
                    '    For Each drv As DataRowView In dv
                    '        If drv("PUnitNo") <> intUnit Then
                    '            Continue For
                    '        End If
                    '        Dim sngP, sngLambdaForP As Single
                    '        sngP = drv("PX")
                    '        sngLambdaForP = drv("PY")
                    '        If sngLambdaForP > sngLineY1 And sngLambdaForP < objMChartCtrl.gsngLambdaY1 Then
                    '            sngLineX1 = sngP
                    '            sngLineY1 = sngLambdaForP
                    '        End If
                    '        If sngLambdaForP > sngLineY2 And sngLineY2 = objMChartCtrl.gsngLambdaY1 Then 'First Time
                    '            sngLineX2 = sngP
                    '            sngLineY2 = sngLambdaForP
                    '        End If
                    '    Next
                    'Catch ex As Exception
                    '    MsgBox("UI1:" & ex.Message)
                    'End Try


                    'Dim sv As DevExpress.XtraCharts.LineSeriesView =
                    '    CType(.Series("IntersectP" & intUnit).View,
                    '        DevExpress.XtraCharts.LineSeriesView)
                    'sv.FirstPoint.LabelDisplayMode = DevExpress.XtraCharts.SidePointDisplayMode.SeriesPoint
                    'sv.LastPoint.LabelDisplayMode = DevExpress.XtraCharts.SidePointDisplayMode.SeriesPoint

                    'sv.FirstPoint.Label.BackColor = Color.LightGray
                    'sv.FirstPoint.Label.LineColor = Color.Red

                    'sv.FirstPoint.Label.Border.Color = Color.Red
                    'sv.FirstPoint.Label.Border.Thickness = 2

                    'sv.FirstPoint.Label.TextColor = Color.Red
                    'sv.FirstPoint.Label.TextPattern = "{V:F2}"

                    'Dim tan As New DevExpress.XtraCharts.TextAnnotation("Test", sngIntersectY)
                    'Me.MChart_Ctrl.AnnotationRepository.Add(tan)
                    'Dim pap As DevExpress.XtraCharts.PaneAnchorPoint = New DevExpress.XtraCharts.PaneAnchorPoint()
                    'pap.Pane = CType(.Diagram, DevExpress.XtraCharts.XYDiagram).DefaultPane
                    '' Define axis coordinates of the anchor point.
                    'pap.AxisXCoordinate.AxisValue = "Indiana" & sngIntersectY
                    'pap.AxisYCoordinate.AxisValue = 195
                    'tan.AnchorPoint = pap
                    ''Dim cap As DevExpress.XtraCharts.ChartAnchorPoint = New DevExpress.XtraCharts.ChartAnchorPoint
                    ''cap.X = sngIntersectX
                    ''cap.Y = sngIntersectY
                    ''tan.AnchorPoint = cap
                    'Dim rp As DevExpress.XtraCharts.RelativePosition = New DevExpress.XtraCharts.RelativePosition
                    'rp.Angle = 20
                    'rp.ConnectorLength = 100
                    'tan.ShapePosition = rp
                End If


    End Sub

    Private Sub UpdatePropertyValuesInChart(ByRef objMChartCtrl As MChartControl)

        Try
            With objMChartCtrl
                .Tag = "MChart"
                .Width = .gintWidth
                .Height = .gintHeight
                .Location = New Point(.gintLeft, .gintTop)
                .BackColor = Color.FromArgb(.gstrMCChartBackColor)

                .Titles(0).Text = .gstrMCTitle & " (Target: " & .gintMcTargetPower & ")"
                .Titles(0).TextColor = Color.FromArgb(.gstrMCTitleFont.Split(",")(3))
                SetFont(.Titles(0), .gstrMCTitleFont)
            End With
        Catch ex As Exception
            MsgBox("PVIM1:" & ex.Message)
        End Try

        Try
            With objMChartCtrl
                .Series("Lambda").View.Color = Color.FromArgb(.gstrMCLambdaSeriesColor)
                .Series("Lambda").LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
                'Dim sv As DevExpress.XtraCharts.LineSeriesView = CType(.Series("Lambda").View, DevExpress.XtraCharts.LineSeriesView)
                'sv.FirstPoint.LabelDisplayMode = DevExpress.XtraCharts.SidePointDisplayMode.SeriesPoint
                'sv.LastPoint.LabelDisplayMode = DevExpress.XtraCharts.SidePointDisplayMode.SeriesPoint

                'sv.FirstPoint.Label.BackColor = Color.LightGray
                'sv.FirstPoint.Label.LineColor = Color.Red

                'sv.FirstPoint.Label.Border.Color = Color.Red
                'sv.FirstPoint.Label.Border.Thickness = 2

                'sv.FirstPoint.Label.TextColor = Color.Red
                'sv.FirstPoint.Label.TextPattern = "{V:F2}"
            End With
        Catch ex As Exception
            MsgBox("PVIM3:" & ex.Message)
        End Try

        'Customize Axis
        Try
            Dim diagram As ch.XYDiagram = TryCast(objMChartCtrl.Diagram, ch.XYDiagram)
            With objMChartCtrl
                diagram.AxisX.Title.Text = .gstrMCXAxisTitle
                diagram.AxisX.Title.TextColor = Color.FromArgb(.gstrMCXYAxisTitleColor)
                SetFont(diagram.AxisX.Title, .gstrMCTitleFont)

                diagram.AxisY.Title.Text = .gstrMCYAxisTitle
                diagram.AxisY.Title.TextColor = Color.FromArgb(.gstrMCXYAxisTitleColor)
                SetFont(diagram.AxisY.Title, .gstrMCTitleFont) ' = New Font("Tahoma", 10, FontStyle.Regular)
            End With
        Catch ex As Exception
            MsgBox("PVIM2:" & ex.Message)
        End Try
    End Sub

    Private Sub RemoveExtraUnits(ByRef objMChartCtrl As MChartControl)

        Dim intUnits, intSeriesToHave As Integer
        'Series total 1 + 4 * Units
        Try
            With objMChartCtrl
                intUnits = .gintMCUnits
                intSeriesToHave = STATIC_SERIES_LAMBDA + intUnits * 4
                If .Series.Count > intSeriesToHave Then
                    For I = .Series.Count - 1 To intSeriesToHave Step -1
                        .Series.RemoveAt(I)
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox("REU:" & ex.Message)
        End Try

    End Sub

    Private Sub AddExtraSeriesIfNecessary(ByRef objMChartCtrl As MChartControl)

        Try
            With objMChartCtrl
                Dim intUnits, intSeriesToHave As Integer
                intUnits = .gintMCUnits
                intSeriesToHave = STATIC_SERIES_LAMBDA + intUnits * 4
                For I = 1 To intUnits
                    Dim intPositionOfUnitInSeries As Integer
                    intPositionOfUnitInSeries = STATIC_SERIES_LAMBDA + (I - 1) * 4 + 1
                    If .Series.Count <= intPositionOfUnitInSeries Then
                        Dim mySeriesForP As ch.Series = New ch.Series("P" & I, ch.ViewType.Line)
                        Dim mySeriesIntersectP As ch.Series = New ch.Series("IntersectP" & I, ch.ViewType.Line)
                        Dim mySeriesForMinP As ch.Series = New ch.Series("MinP" & I, ch.ViewType.Line)
                        Dim mySeriesForMaxP As ch.Series = New ch.Series("MaxP" & I, ch.ViewType.Line)

                        .Series.Add(mySeriesForP)
                        .Series.Add(mySeriesIntersectP)
                        .Series.Add(mySeriesForMinP)
                        .Series.Add(mySeriesForMaxP)

                        '.Series(intPositionOfUnitInSeries - 1).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
                        '.Series(intPositionOfUnitInSeries - 1).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                    End If
                    .Series("P" & I).View.Color = Color.FromArgb(.glosMCSeriesColor(I - 1))
                    .Series("IntersectP" & I).View.Color = Color.FromArgb(.glosMCIntersectColor(I - 1))
                Next
            End With
        Catch ex As Exception
            MsgBox("AESIN:" & ex.Message)
        End Try

    End Sub

    'Public Sub UpdateVariableValuesInChart(ByRef objMChartCtrl As MChartControl)

    '    Try
    '        With objMChartCtrl
    '            For I = 1 To intUnits
    '                Dim intPositionOfUnitInSeries As Integer
    '                intPositionOfUnitInSeries = STATIC_SERIES_LAMBDA + (I - 1) * 4 + 1
    '                If .Series.Count <= intPositionOfUnitInSeries Then
    '                    Dim mySeriesForP As ch.Series = New ch.Series("P" & I, ch.ViewType.Line)
    '                    Dim mySeriesIntersectP As ch.Series = New ch.Series("IntersectP" & I, ch.ViewType.Line)
    '                    Dim mySeriesForMinP As ch.Series = New ch.Series("MinP" & I, ch.ViewType.Line)
    '                    Dim mySeriesForMaxP As ch.Series = New ch.Series("MaxP" & I, ch.ViewType.Line)

    '                    .Series.Add(mySeriesForP)
    '                    .Series.Add(mySeriesIntersectP)
    '                    .Series.Add(mySeriesForMinP)
    '                    .Series.Add(mySeriesForMaxP)

    '                    '.Series(intPositionOfUnitInSeries - 1).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
    '                    '.Series(intPositionOfUnitInSeries - 1).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
    '                End If
    '                .Series("P" & I).View.Color = Color.FromArgb(.glosMCSeriesColor(I - 1))
    '                .Series("IntersectP" & I).View.Color = Color.FromArgb(.glosMCIntersectColor(I - 1))
    '            Next
    '        End With
    '    Catch ex As Exception
    '        MsgBox("PVIM4:" & ex.Message)
    '    End Try
    '    Try
    '        With objMChartCtrl
    '            For I = 0 To .gintMcUnits - 1
    '                .Series("P" & I + 1).Points.Clear()
    '                .Series("IntersectP" & I + 1).Points.Clear()
    '                'For Each dr As DataRow In .gdtMCLiveData.Rows
    '                '    If dr("PUnitNo") = I + 1 Then
    '                '        .Series("P" & I + 1).Points.AddPoint(dr("PX"), dr("PY"))
    '                '    End If
    '                'Next
    '                For Each dgvOneRow As DataGridViewRow In .gdgvUnitValues.Rows
    '                    Dim sngX, sngY As Single
    '                    sngX = dgvOneRow.Cells(I * 2).Value
    '                    sngY = dgvOneRow.Cells(I * 2 + 1).Value
    '                    .Series("P" & I + 1).Points.AddPoint(sngX, sngY)
    '                Next
    '                .Series("MinP" & I + 1).Points.AddPoint(.glogMinX1(I), .glogMinY1(I))
    '                .Series("MinP" & I + 1).Points.AddPoint(.glogMinX2(I), .glogMinY2(I))
    '                .Series("MaxP" & I + 1).Points.AddPoint(.glogMaxX1(I), .glogMaxY1(I))
    '                .Series("MaxP" & I + 1).Points.AddPoint(.glogMaxX2(I), .glogMaxY2(I))

    '            Next
    '        End With
    '    Catch ex As Exception
    '        MsgBox("PDIM1:" & ex.Message)
    '    End Try

    '    Try
    '        With objMChartCtrl
    '            .Series("Lambda").Points.AddPoint(.gsngLambdaX1, .gsngLambdaY1)
    '            .Series("Lambda").Points.AddPoint(.gsngLambdaX2, .gsngLambdaY2)
    '        End With
    '    Catch ex As Exception
    '        MsgBox("PDIM2:" & ex.Message)
    '    End Try

    'End Sub

    Private Sub SetFont(ByRef objFont As Object, strFontDetails As String)

        Dim aryFontDetails() As String
        aryFontDetails = Split(strFontDetails, ",")
        If aryFontDetails(2) = "Regular" Then
            objFont.Font = New Font(aryFontDetails(0), CSng(aryFontDetails(1)), FontStyle.Regular)
        ElseIf aryFontDetails(2) = "Bold" Then
            objFont.Font = New Font(aryFontDetails(0), CSng(aryFontDetails(1)), FontStyle.Bold)
        ElseIf aryFontDetails(2) = "Italic" Then
            objFont.Font = New Font(aryFontDetails(0), CSng(aryFontDetails(1)), FontStyle.Italic)
        End If

    End Sub





    Private Sub AddColumnsForMchartInDataTable()

        'Columns for MChart_Ctrl

        Try
            dt.Columns.Add(New DataColumn("McTitle", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McTitleFont", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McXAxisTitle", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McYAxisTitle", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McXYAxisTitleColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McChartBackColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McLegendEnable", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McLegendColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McAxisLabelEnable", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McAxisLabelColor", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McActionChannel", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McUnits", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McTargetPower", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McPricePerUnit", Type.GetType("System.Single")))
            dt.Columns.Add(New DataColumn("McSamples", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McWritebackOpcServer", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McLocX", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McLocY", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McWidth", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McHeight", Type.GetType("System.Int32")))

            dt.Columns.Add(New DataColumn("McTagForLambda", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McLambdaSeriesName", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McLambdaSeriesColor", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McDgvTop", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvLeft", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvWidth", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvHeight", Type.GetType("System.Int32")))

            dt.Columns.Add(New DataColumn("McDgvCol0Width", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvCol1Width", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvCol2Width", Type.GetType("System.Int32")))

            dt.Columns.Add(New DataColumn("McDgvUnitTop", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvUnitLeft", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvUnitWidth", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvUnitHeight", Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("McDgvUnitColWidth", Type.GetType("System.Int32")))

            'Will have multiple entries with , in one row separated by ~
            dt.Columns.Add(New DataColumn("McTagForMan", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("MCTagForPLambda", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("MCTagForOpt", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McTagForMin", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMinColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McTagForMax", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMaxColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McSeriesName", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McSeriesColor", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectName", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectColor", Type.GetType("System.String")))


            'Last Data Values
            dt.Columns.Add(New DataColumn("McLambdaX1", Type.GetType("System.Single")))
            dt.Columns.Add(New DataColumn("McLambdaY1", Type.GetType("System.Single")))
            dt.Columns.Add(New DataColumn("McLambdaX2", Type.GetType("System.Single")))
            dt.Columns.Add(New DataColumn("McLambdaY2", Type.GetType("System.Single")))

            dt.Columns.Add(New DataColumn("McLoadScheduleUnitOptimalLoading", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McLoadScheduledUnitLoadingAtPresent", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIFCUnitOptmimalLoading", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIFCUnitLoadingAtPresent", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McIntersectX1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectY1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectX2", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectY2", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McIntersectAnnotationData", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McMinX1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMinY1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMinX2", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMinY2", Type.GetType("System.String")))

            dt.Columns.Add(New DataColumn("McMaxX1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMaxY1", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMaxX2", Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("McMaxY2", Type.GetType("System.String")))

            'LoadSch1,IFC1,Cost1~LoadSch2,IFC2,Cost2~...
            dt.Columns.Add(New DataColumn("McCurrentData", Type.GetType("System.String")))

            'UnitNo,X,Y~...
            '1,PX,PY~2,PX,PY~...
            dt.Columns.Add(New DataColumn("McDataForPlotting", Type.GetType("System.String")))
            'dt.Columns.Add(New DataColumn("McActData", Type.GetType("System.String")))

            'dt.Columns.Add(New DataColumn("McLiveData", Type.GetType("System.String")))
        Catch ex As Exception
            MsgBox("ACFMIDT:" & ex.Message)
        End Try

    End Sub




    Private Function AddNewMChartFromDataTable(dt As DataTable) As ch.ChartControl

        Try
            'Dim MChart_Ctrl As DevExpress.XtraCharts.ChartControl
            'MChart_Ctrl = New DevExpress.XtraCharts.ChartControl ' New MChartControl
            Dim dr As DataRow
            dr = dt.Rows(0)
            MChart_Ctrl = New MChartControl

            Ctrl_NameList.Add(MChart_Ctrl.Name)

            MChartInit(MChart_Ctrl)

            Dim objMChartCtrl As MChartControl
            objMChartCtrl = MChart_Ctrl

            Try

                With objMChartCtrl
                    .gstrMCTitle = dr("McTitle")
                    .gstrMCTitle = dr("McTitle")
                    .gstrMCTitleFont = dr("McTitleFont")
                    .gstrMCXAxisTitle = dr("McXAxisTitle")
                    .gstrMCYAxisTitle = dr("McYAxisTitle")
                    .gstrMCXYAxisTitleColor = dr("McXYAxisTitleColor")
                    .gstrMCChartBackColor = dr("McChartBackColor")
                    .gstrMCLegendEnable = dr("McLegendEnable")
                    .gstrMCLegendColor = dr("McLegendColor")
                    .gstrMCAxisLabelEnable = dr("McAxisLabelEnable")
                    .gstrMCAxisLabelColor = dr("McAxisLabelColor")

                    .gstrMCActionChannel = dr("McActionChannel")
                    .AccessibleDescription = .gstrMCActionChannel
                    .gintMCUnits = dr("McUnits")
                    .gintMCTargetPower = dr("McTargetPower")
                    .gsngPricePerUnit = dr("McPricePerUnit")
                    .gintMCSamples = dr("McSamples")
                    .gstrMCWritebackOpcServer = dr("McWritebackOpcServer")

                    .gintLeft = dr("McLocX")
                    .gintTop = dr("McLocY")
                    .gintWidth = dr("McWidth")
                    .gintHeight = dr("McHeight")

                    .gstrMCTagForLambda = dr("McTagForLambda")
                    .gstrMCLambdaSeriesName = dr("McLambdaSeriesName")
                    .gstrMCLambdaSeriesColor = dr("McLambdaSeriesColor")

                    .gintMCDgvTop = dr("McDgvTop")
                    .gintMCDgvLeft = dr("McDgvLeft")
                    .gintMCDgvWidth = dr("McDgvWidth")
                    .gintMCDgvHeight = dr("McDgvHeight")

                    .gintMCDgvCol0Width = dr("McDgvCol0Width")
                    .gintMCDgvCol1Width = dr("McDgvCol1Width")
                    .gintMCDgvCol2Width = dr("McDgvCol2Width")

                    .glosMCTagForMan.AddRange(Split(dr("McTagForMan"), "~"))
                    .glosMCTagForPLambda.AddRange(Split(dr("MCTagForPLambda"), "~"))
                    .glosMCTagForOpt.AddRange(Split(dr("MCTagForOpt"), "~"))
                    .glosMCTagForMin.AddRange(Split(dr("McTagForMin"), "~"))
                    .glosMCMinColor.AddRange(Split(dr("McMinColor"), "~"))
                    .glosMCTagForMax.AddRange(Split(dr("McTagForMax"), "~"))
                    .glosMCMaxColor.AddRange(Split(dr("McMaxColor"), "~"))
                    .glosMCSeriesName.AddRange(Split(dr("McSeriesName"), "~"))
                    .glosMCSeriesColor.AddRange(Split(dr("McSeriesColor"), "~"))
                    .glosMCIntersectName.AddRange(Split(dr("McIntersectName"), "~"))
                    .glosMCIntersectColor.AddRange(Split(dr("McIntersectColor"), "~"))
                    '.glosMCActData.AddRange(Split(dr("McActData"), "~"))

                    .gintMCDgvUnitTop = dr("McDgvUnitTop")
                    .gintMCDgvUnitLeft = dr("McDgvUnitLeft")
                    .gintMCDgvUnitWidth = dr("McDgvUnitWidth")
                    .gintMCDgvUnitHeight = dr("McDgvUnitHeight")
                    .gintMCDgvUnitColWidth = dr("McDgvUnitColWidth")
                End With
            Catch ex As Exception
                MsgBox("ANMCFDT1:" & ex.Message)
            End Try

            Try
                'Last Saved Data
                With objMChartCtrl
                    .gsngLambdaX1 = dr("McLambdaX1")
                    .gsngLambdaY1 = dr("McLambdaY1")
                    .gsngLambdaX2 = dr("McLambdaX2")
                    .gsngLambdaY2 = dr("McLambdaY2")

                    '.glogLoadScheduledUnitOptimalLoading.AddRange(StringToListOfSingle(dr("McLoadScheduleUnitOptimalLoading")))
                    '.glogLoadScheduledUnitLoadingAtPresent.AddRange(StringToListOfSingle(dr("McLoadScheduledUnitLoadingAtPresent")))
                    '.glogIFCUnitOptimalLoading.AddRange(StringToListOfSingle(dr("McIFCUnitOptmimalLoading")))
                    '.glogIFCUnitLoadingAtPresent.AddRange(StringToListOfSingle(dr("McIFCUnitLoadingAtPresent")))

                    .gstrIntersectAnnotationData = dr("McIntersectAnnotationData")
                    .glogIntersectX1.AddRange(StringToListOfSingle(dr("McIntersectX1")))
                    .glogIntersectY1.AddRange(StringToListOfSingle(dr("McIntersectY1")))
                    .glogIntersectX2.AddRange(StringToListOfSingle(dr("McIntersectX2")))
                    .glogIntersectY2.AddRange(StringToListOfSingle(dr("McIntersectY2")))

                    .glogMinX1.AddRange(StringToListOfSingle(dr("McMinX1")))
                    .glogMinY1.AddRange(StringToListOfSingle(dr("McMinY1")))
                    .glogMinX2.AddRange(StringToListOfSingle(dr("McMinX2")))
                    .glogMinY2.AddRange(StringToListOfSingle(dr("McMinY2")))

                    .glogMaxX1.AddRange(StringToListOfSingle(dr("McMaxX1")))
                    .glogMaxY1.AddRange(StringToListOfSingle(dr("McMaxY1")))
                    .glogMaxX2.AddRange(StringToListOfSingle(dr("McMaxX2")))
                    .glogMaxY2.AddRange(StringToListOfSingle(dr("McMaxY2")))

                    'CreateDefaultLiveDataTableColumns(objMChartCtrl)

                    'Dim losLiveData As New List(Of String)
                    'losLiveData.AddRange(Split(dr("McLiveData"), "~"))
                    '.gdtMCLiveData = LOStoDataTable(objMChartCtrl, losLiveData)
                End With
            Catch ex As Exception
                MsgBox("ANMCFDT2:" & ex.Message)
            End Try

            Dim strCurrentData, strDataForPlotting As String
            strCurrentData = dr("McCurrentData")
            strDataForPlotting = dr("McDataForPlotting")

            'CreateDefaultPropertyValues(objMChartCtrl)
            'CreateDefaultVariableValues(objMChartCtrl)
            UpdatePropertyValuesInChart(objMChartCtrl)
            'UpdateVariableValuesInChart(objMChartCtrl)
            AddExtraSeriesIfNecessary(objMChartCtrl)


            SetDataGridViewProperties(objMChartCtrl)
            SetDataGridViewValues(objMChartCtrl)



            Dim losCurrentData As New List(Of String)
            losCurrentData.Clear()
            losCurrentData.AddRange(Split(strCurrentData, "~"))
            For I = 0 To losCurrentData.Count - 1
                Dim aryData() As String
                aryData = Split(losCurrentData(I), ",")
                With objMChartCtrl.gdgvMORS
                    'LoadSch1,IFC1,Cost1...
                    .Rows(I).Cells(1).Value = aryData(0)
                    .Rows(I).Cells(2).Value = aryData(1)
                    .Rows(I).Cells(3).Value = aryData(2)
                End With
            Next

            losCurrentData.Clear()
            losCurrentData.AddRange(Split(strDataForPlotting, "~"))
            For Each strOneData In losCurrentData
                ''UnitNo,X,Y~......
                Dim strRowDataWithoutUnitNo As String = ""
                For I = 1 To objMChartCtrl.gintMCUnits
                    Dim aryData() As String
                    aryData = Split(strOneData, ",")
                    strRowDataWithoutUnitNo &= "," & aryData((I - 1) * 3 + 1) & "," & aryData((I - 1) * 3 + 2)
                Next
                objMChartCtrl.gdgvUnitValues.Rows.Add(Split(strRowDataWithoutUnitNo.Substring(1), ","))
            Next

            For I = 1 To objMChartCtrl.gintMCUnits
                PlotDataGridValuesInSeries(objMChartCtrl, I)
                CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, I)
                PlotIntersectValuesInChart(objMChartCtrl, I)
            Next
            UpdateLambda(objMChartCtrl)

            If False Then
                'CreateObjectsInMChart(MChart_Ctrl)

                'MChart_Ctrl.gdgvMORS = New DataGridView
                'DataGridViewInit(MChart_Ctrl)
                'Page_Ctrl.Controls.Add(MChart_Ctrl.gdgvMORS)
                'Try
                '    DataTableToChartVariables(dr, MChart_Ctrl)
                '    PlotVariablesInMChart(MChart_Ctrl)
                'Catch ex As Exception
                '    MsgBox("AMCFDT1:" & ex.Message)
                'End Try
                'Try
                '    CreateDefaultDataForLambdaMinMax(MChart_Ctrl)
                '    CreateSeriesDataForTesting(MChart_Ctrl)
                '    For I = 1 To MChart_Ctrl.glosMCTagForMan.Count
                '        UpdateIntersect(MChart_Ctrl, I)
                '    Next
                '    PlotDataInMChart(MChart_Ctrl)
                'Catch ex As Exception
                '    MsgBox("AMCFDT2:" & ex.Message)
                'End Try
                'Try
                '    SetDataGridViewProperties(MChart_Ctrl)
                '    SetDataGridViewValues(MChart_Ctrl)
                'Catch ex As Exception
                '    MsgBox("AMCFDT3:" & ex.Message)
                'End Try

                'MChart_Ctrl.BringToFront()
                'Page_Ctrl.Controls.Add(MChart_Ctrl) 'Add DevexpressControls in panel
                'Page_Ctrl.Controls.SetChildIndex(MChart_Ctrl, 0)

                'Series
                'For I = 1 To dt.Rows.Count - 1
                '    MChart_Ctrl.AccessibleDescription = dt.Rows(0).Item("McActionChannel")  ' dt.Rows(I).Item("McSeriesYMember")
                '    Dim mySeries As ch.Series = New ch.Series("Series" & I, ch.ViewType.Spline)
                '    mySeries.Name = dt.Rows(I).Item("McSeriesname")
                '    mySeries.View.Color = Color.FromArgb(dt.Rows(I).Item("McSeriesColor"))
                '    'mySeries.View.DiagramType = DevExpress.XtraCharts.XYDiagram

                '    Dim myPointSeriesView As DevExpress.XtraCharts.PointSeriesView
                '    myPointSeriesView = mySeries.View
                '    myPointSeriesView.PointMarkerOptions.BorderColor = Color.FromArgb(dt.Rows(I).Item("McMarkerColor"))
                '    myPointSeriesView.PointMarkerOptions.Kind = dt.Rows(I).Item("McMarkerStyle")
                '    myPointSeriesView.PointMarkerOptions.Size = dt.Rows(I).Item("McMarkersize")

                '    mySeries.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
                '    mySeries.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
                '    If dt.Rows(I).Item("McAxisEnabled") = 1 Then
                '        mySeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
                '    Else
                '        mySeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                '    End If
                '    mySeries.Label.TextColor = Color.FromArgb(dt.Rows(I).Item("McAxislblcolor"))

                '    For K = 1 To 5
                '        mySeries.Points.AddPoint((I * 2) + K, (I * 2) + K + 5)
                '    Next
                '    MChart_Ctrl.Series.Add(mySeries)
                'Next
                'MChart_Ctrl.Titles.Clear()

                ''MChart_Ctrl.Titles(0).Text = dt.Rows(0).Item("McTitle")
                'Dim mctitlefont = dt.Rows(0).Item("McTitleFont")
                'Dim arrFntlst() As String = mctitlefont.Split(",")
                'If arrFntlst(2) = "Bold" Then
                '    MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Bold)
                'ElseIf arrFntlst(2) = "Regular" Then
                '    MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Regular)
                'ElseIf arrFntlst(2) = "Italic" Then
                '    MChart_Ctrl.Titles(0).Font = New Font(arrFntlst(0), CInt(arrFntlst(1)), FontStyle.Italic)
                'End If
                'MChart_Ctrl.Titles(0).TextColor = Color.FromArgb(CInt(arrFntlst(3)))

                'Dim myDiagram As ch.XYDiagram
                'myDiagram = TryCast(MChart_Ctrl.Diagram, ch.XYDiagram)
                'Dim myAxisX As ch.AxisX = myDiagram.AxisX
                'myAxisX.Title.Text = dt.Rows(0).Item("McXTitle")
                'diagram.AxisY.Title.Text = dt.Rows(0).Item("McYTitle")
                'diagram.AxisX.GridLines.Color = Color.FromArgb(dt.Rows(0).Item("McGridColor"))
                'diagram.AxisX.Title.TextColor = Color.FromArgb(dt.Rows(0).Item("McXYTitleColor"))

                'MChart_Ctrl._xaxis = dt.Rows(0).Item("MChartXaxisTimeorValue")

                '<McTitle>MORS Chart</McTitle>
                '<McBGColor>16777215</McBGColor>
                '<McGridColor>0</McGridColor>
                '<McXYTitleColor>-65536</McXYTitleColor>
                '<McXTitle>Argument</McXTitle>
                '<McYTitle>Value</McYTitle>
                '<McTitleFont>Verdana,8, Regular,-16777216</McTitleFont>
                '<McXYLabelFont>Tahoma,8, Regular,-65536</McXYLabelFont>
                '<MChartXaxisTimeorValue>10FIC01/PV#CV_Instant</MChartXaxisTimeorValue>
                '<McYMin>18</McYMin>
                '<McYMax>110</McYMax>
                '<MChartLocX>150</MChartLocX>
                '<MChartLocY>200</MChartLocY>

                'Dim diagram As ch.XYDiagram = TryCast(MChart_Ctrl.Diagram, ch.XYDiagram)
                '' Customize the appearance of the X-axis title.
                'diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
                'diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True
                'diagram.AxisX.Title.Alignment = StringAlignment.Center
                'diagram.AxisX.Title.Text = "------> Output"
                'diagram.AxisX.Title.TextColor = Color.Red
                ''diagram.AxisX.Title.Antialiasing = DevExpress.Utils.DefaultBoolean.True
                'diagram.AxisX.Title.Font = New Font("Tahoma", 10, FontStyle.Regular)
                '' Customize the appearance of the Y-axis title.
                'diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
                'diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True
                'diagram.AxisY.Title.Alignment = StringAlignment.Center
                'diagram.AxisY.Title.Text = "IFC (Lambda)"
                'diagram.AxisY.Title.TextColor = Color.Red
                'diagram.AxisY.Title.Font = New Font("Tahoma", 10, FontStyle.Regular)

                'Dim myLabel As New Label
                'myLabel.Top = MChart_Ctrl.Top - 15
                'myLabel.Left = MChart_Ctrl.Left
                'myLabel.Text = "Manual Entry"
                'AddHandler myLabel.Click, AddressOf ManualEntry
                'Page_Ctrl.Controls.Add(myLabel)
            End If

            _iniChartName += 1
        Catch ex As Exception
            MsgBox("AMCFDT4:" & ex.Message)
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ADDMChart()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

        Return MChart_Ctrl

    End Function


    Private Function StringToListOfSingle(strData As String) As List(Of Single)

        Dim logReturn As New List(Of Single)
        logReturn.Clear()

        Try
            Dim aryData() As String
            aryData = Split(strData, "~")
            For Each a In aryData
                logReturn.Add(CSng(a))
            Next
        Catch ex As Exception
            MsgBox("STLOFS:" & ex.Message)
        End Try

        Return logReturn

    End Function

    'Private Function LOStoDataTable(objMChart As MChartControl, losLiveData As List(Of String)) As DataTable

    '    Dim dtLive As New DataTable
    '    dtLive = objMChart.gdtMCLiveData
    '    For Each strOneData In losLiveData
    '        '1,300,1782.3~2,300,1843.72
    '        dtLive.Rows.Add(Split(strOneData, ","))
    '    Next
    '    Return dtLive

    'End Function

    'Private Function DataTableToLOS(dt As DataTable, intUnits As Integer) As List(Of String)

    '    Dim losReturn As New List(Of String)
    '    For Each dr As DataRow In dt.Rows
    '        Dim strData As String
    '        If dr("PUnitNo") <= intUnits Then
    '            strData = dr("PUnitNo") & "," & dr("PX") & "," & dr("PY")
    '            losReturn.Add(strData)
    '        End If
    '    Next
    '    Return losReturn

    'End Function


    Private Sub UpdateDataRowFromMChartVariablesForSavingInXml(pageNo As String)

        Dim objMChartCtrl As MChartControl
        objMChartCtrl = MChart_Ctrl

        With objMChartCtrl
            .gintLeft = .Left
            .gintTop = .Top
            .gintWidth = .Width
            .gintHeight = .Height

            .gintMCDgvTop = .gdgvMORS.Top
            .gintMCDgvLeft = .gdgvMORS.Left
            .gintMCDgvWidth = .gdgvMORS.Width
            .gintMCDgvHeight = .gdgvMORS.Height

            .gintMCDgvCol0Width = .gdgvMORS.Columns(0).Width
            .gintMCDgvCol1Width = .gdgvMORS.Columns(1).Width
            .gintMCDgvCol2Width = .gdgvMORS.Columns(2).Width

            .gintMCDgvUnitTop = .gdgvUnitValues.Top
            .gintMCDgvUnitLeft = .gdgvUnitValues.Left
            .gintMCDgvUnitWidth = .gdgvUnitValues.Width
            .gintMCDgvUnitHeight = .gdgvUnitValues.Height
            .gintMCDgvUnitColWidth = .gdgvUnitValues.Columns(0).Width
        End With

        Dim dr As DataRow = dt.NewRow()

        Try
            'dr("Tag") = MChart_Ctrl.Tag
            dr("Tag") = "MChart"
            dr("PageNo") = pageNo
            dr("Ctrl_Name") = objMChartCtrl.Name
            dr("Z_Order") = pnl.Controls.GetChildIndex(MChart_Ctrl).ToString()

            Try
                With objMChartCtrl
                    dr("McTitle") = .gstrMCTitle
                    dr("McTitleFont") = .gstrMCTitleFont
                    dr("McXAxisTitle") = .gstrMCXAxisTitle
                    dr("McYAxisTitle") = .gstrMCYAxisTitle
                    dr("McXYAxisTitleColor") = .gstrMCXYAxisTitleColor
                    dr("McChartBackColor") = .gstrMCChartBackColor
                    dr("McLegendEnable") = .gstrMCLegendEnable
                    dr("McLegendColor") = .gstrMCLegendColor
                    dr("McAxisLabelEnable") = .gstrMCAxisLabelEnable
                    dr("McAxisLabelColor") = .gstrMCAxisLabelColor

                    MChart_Ctrl.AccessibleDescription = .gstrMCActionChannel
                    dr("McActionChannel") = .gstrMCActionChannel
                    dr("McUnits") = .gintMCUnits
                    dr("McTargetPower") = .gintMCTargetPower
                    dr("McPricePerUnit") = .gsngPricePerUnit
                    dr("McSamples") = .gintMCSamples
                    dr("McWritebackOpcServer") = IIf(IsNothing(.gstrMCWritebackOpcServer), "", .gstrMCWritebackOpcServer)

                    dr("McLocX") = .gintLeft
                    dr("McLocY") = .gintTop
                    dr("McWidth") = .gintWidth
                    dr("McHeight") = .gintHeight

                    dr("McTagForLambda") = .gstrMCTagForLambda
                    dr("McLambdaSeriesName") = .gstrMCLambdaSeriesName
                    dr("McLambdaSeriesColor") = .gstrMCLambdaSeriesColor

                    dr("McDgvTop") = .gintMCDgvTop
                    dr("McDgvLeft") = .gintMCDgvLeft
                    dr("McDgvWidth") = .gintMCDgvWidth
                    dr("McDgvHeight") = .gintMCDgvHeight

                    dr("McDgvCol0Width") = .gintMCDgvCol0Width
                    dr("McDgvCol1Width") = .gintMCDgvCol1Width
                    dr("McDgvCol2Width") = .gintMCDgvCol2Width

                    dr("McDgvUnitTop") = .gintMCDgvUnitTop
                    dr("McDgvUnitLeft") = .gintMCDgvUnitLeft
                    dr("McDgvUnitWidth") = .gintMCDgvUnitWidth
                    dr("McDgvUnitHeight") = .gintMCDgvUnitHeight
                    dr("McDgvUnitColWidth") = .gintMCDgvUnitColWidth

                    dr("McTagForMan") = String.Join("~", .glosMCTagForMan.ToArray)
                    dr("McTagForPLambda") = String.Join("~", .glosMCTagForPLambda.ToArray)
                    dr("McTagForOpt") = String.Join("~", .glosMCTagForOpt.ToArray)
                    dr("McTagForMin") = String.Join("~", .glosMCTagForMin.ToArray)
                    dr("McMinColor") = String.Join("~", .glosMCMinColor.ToArray)
                    dr("McTagForMax") = String.Join("~", .glosMCTagForMax.ToArray)
                    dr("McMaxColor") = String.Join("~", .glosMCMaxColor.ToArray)
                    dr("McSeriesName") = String.Join("~", .glosMCSeriesName.ToArray)
                    dr("McSeriesColor") = String.Join("~", .glosMCSeriesColor.ToArray)
                    dr("McIntersectName") = String.Join("~", .glosMCIntersectName.ToArray)
                    dr("McIntersectColor") = String.Join("~", .glosMCIntersectColor.ToArray)

                    Dim losData As New List(Of String)
                    losData.Clear()
                    For Each dgvOneRow As DataGridViewRow In .gdgvMORS.Rows
                        'LoadSch1,IFC1,Cost1...
                        '
                        Dim strData As String = ""
                        With dgvOneRow
                            strData = .Cells(1).Value & "," & .Cells(2).Value & "," & .Cells(3).Value
                        End With
                        losData.Add(strData)
                    Next
                    dr("McCurrentData") = String.Join("~", losData.ToArray)

                    losData.Clear()
                    For Each dgvOneRow As DataGridViewRow In .gdgvUnitValues.Rows
                        ''UnitNo,X,Y~...
                        '
                        Dim strData As String = ""
                        With dgvOneRow
                            For I = 1 To objMChartCtrl.gintMCUnits
                                strData &= "," & I & "," & .Cells((I - 1) * 2).Value & "," & .Cells((I - 1) * 2 + 1).Value
                            Next
                        End With
                        losData.Add(strData.Substring(1))
                    Next
                    dr("McDataForPlotting") = String.Join("~", losData.ToArray)
                    'Dim losData As New List(Of String)
                    'losData.Clear()
                    ''dr("McActData") = String.Join("~", .glosMCActData.ToArray)
                    'For Each dgvOneRow As DataGridViewRow In .gdgvUnitValues.Rows
                    '    'P1X,P1Y,P2X,P2Y
                    '    Dim strData As String = ""
                    '    For I = 0 To .gdgvUnitValues.Columns.Count - 1
                    '        strData &= dgvOneRow.Cells(I).Value & ","
                    '    Next
                    '    strData = strData.Substring(0, strData.Length - 1)
                    '    losData.Add(strData)
                    'Next
                    'dr("McActData") = String.Join("~", losData.ToArray)
                End With
            Catch ex As Exception
                MsgBox("UDRFM1:" & ex.Message)
            End Try

            Try
                With objMChartCtrl
                    dr("McLambdaX1") = .gsngLambdaX1
                    dr("McLambdaY1") = .gsngLambdaY1
                    dr("McLambdaX2") = .gsngLambdaX2
                    dr("McLambdaY2") = .gsngLambdaY2

                    'dr("McLoadScheduleUnitOptimalLoading") = String.Join("~", .glogLoadScheduledUnitOptimalLoading.ToArray)
                    'dr("McLoadScheduledUnitLoadingAtPresent") = String.Join("~", .glogLoadScheduledUnitLoadingAtPresent.ToArray)
                    'dr("McIFCUnitOptmimalLoading") = String.Join("~", .glogIFCUnitOptimalLoading.ToArray)
                    'dr("McIFCUnitLoadingAtPresent") = String.Join("~", .glogIFCUnitLoadingAtPresent.ToArray)

                    Dim rp As DevExpress.XtraCharts.RelativePosition = New DevExpress.XtraCharts.RelativePosition
                    'rp.Angle = 325
                    'rp.ConnectorLength = 150
                    '.Series("IntersectP" & I + 1).Points(.Series("IntersectP" & I + 1).Points.Count - 1).Annotations(0).ShapePosition = rp

                    Dim intLastCount As Integer
                    'MsgBox("Angle:" & rp.Angle & " Connector Length:" & rp.ConnectorLength)
                    Dim strAnnotationData As String = ""
                    Dim intUnits As Integer
                    intUnits = .gintMcUnits
                    For I = 1 To intUnits
                        'Angle1,ConnectorLength1~Angle2,ConnectorLength2
                        intLastCount = .Series("IntersectP" & I).Points.Count - 1
                        rp = .Series("IntersectP" & I).Points(intLastCount).Annotations(0).ShapePosition
                        strAnnotationData &= Math.Round(rp.Angle, 0) & "," & Math.Round(rp.ConnectorLength, 0) & "~"
                    Next
                    strAnnotationData = strAnnotationData.Substring(0, strAnnotationData.Length - 1)
                    dr("McIntersectAnnotationData") = strAnnotationData

                    dr("McIntersectX1") = String.Join("~", .glogIntersectX1.ToArray)
                    dr("McIntersectY1") = String.Join("~", .glogIntersectY1.ToArray)
                    dr("McIntersectX2") = String.Join("~", .glogIntersectX2.ToArray)
                    dr("McIntersectY2") = String.Join("~", .glogIntersectY2.ToArray)

                    dr("McMinX1") = String.Join("~", .glogMinX1.ToArray)
                    dr("McMinY1") = String.Join("~", .glogMinY1.ToArray)
                    dr("McMinX2") = String.Join("~", .glogMinX2.ToArray)
                    dr("McMinY2") = String.Join("~", .glogMinY2.ToArray)

                    dr("McMaxX1") = String.Join("~", .glogMaxX1.ToArray)
                    dr("McMaxY1") = String.Join("~", .glogMaxY1.ToArray)
                    dr("McMaxX2") = String.Join("~", .glogMaxX2.ToArray)
                    dr("McMaxY2") = String.Join("~", .glogMaxY2.ToArray)

                    'Dim losLiveData As New List(Of String)
                    'losLiveData = DataTableToLOS(.gdtMCLiveData, .gintMcUnits)
                    'dr("McLiveData") = String.Join("~", losLiveData.ToArray)
                End With
            Catch ex As Exception
                MsgBox("UDRFM2:" & ex.Message)
            End Try

            dt.Rows.Add(dr)
        Catch ex As Exception
            MsgBox("UDRFM:" & ex.Message)
        End Try

    End Sub



    'Context Menu -> RightClick -> Properties
    Private Sub DMS_ChartProperties_Click(sender As Object, e As EventArgs) Handles DMS_ChartProperties.Click

        Try
            MChartProp_Form = New MChartPropertiesFormNew
            MChartProp_Form.ShowDialog()
            Dim objMChartCtrl As MChartControl
            objMChartCtrl = Me.MChart_Ctrl
            UpdatePropertyValuesInChart(objMChartCtrl)
            RemoveExtraUnits(objMChartCtrl)
            AddExtraSeriesIfNecessary(objMChartCtrl)
            UpdateLambdaMinMaxFromOpcOneTime(objMChartCtrl)

            SetDataGridViewProperties(objMChartCtrl)
            SetDataGridViewValues(objMChartCtrl)

            For I = 1 To objMChartCtrl.gintMCUnits
                PlotDataGridValuesInSeries(objMChartCtrl, I)
                CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, I)
                PlotIntersectValuesInChart(objMChartCtrl, I)
            Next
            'UpdateVariableValuesInChart(objMChartCtrl)

            If False Then
                'MChartProp_Form.txtMainTitle.Text = MChart_Ctrl.Titles(0).Text
                'MChartProp_Form._ListChart_Series = New List(Of MChartProperties)
                'MChartProp_Form._Constant_Lines = New BindingList(Of ConstantLineProp)


                'Dim diag As ch.XYDiagram = TryCast(MChart_Ctrl.Diagram, ch.XYDiagram)
                'If Not IsNothing(diag) Then
                '    MChartProp_Form.txtXAxisTitle.Text = diag.AxisX.Title.Text
                '    MChartProp_Form.txtYAxisTitle.Text = diag.AxisY.Title.Text
                'End If

                'For i As Integer = 0 To MChart_Ctrl.Series.Count - 1
                '    Dim prop As New MChartProperties
                '    'Dim vt As ch.ViewType = ch.Native.SeriesViewFactory.GetViewType(MChart_Ctrl.Series(i).View)
                '    prop = MChartProp_Form.ProcAddProperties(MChart_Ctrl.Series(i).Name, MChart_Ctrl.Series(i).View.Color.ToArgb _
                '        , MChart_Ctrl.AccessibleDescription, MChart_Ctrl.Series(i).View.ToString() _
                '        , CType(MChart_Ctrl.Series(i).View, ch.PointSeriesView).PointMarkerOptions.Kind.ToString(), CType(MChart_Ctrl.Series(i).View _
                '        , ch.PointSeriesView).PointMarkerOptions.Size, CType(MChart_Ctrl.Series(i).View, ch.PointSeriesView).PointMarkerOptions.BorderColor.ToArgb _
                '        , MChart_Ctrl.Series(i).Label.BackColor.ToArgb, MChart_Ctrl.Series(i).LabelsVisibility)

                '    MChartProp_Form._ListChart_Series.Add(prop)
                'Next

                'If MChart_Ctrl.Series.Count > 0 Then
                '    MChartProp_Form._Title = MChart_Ctrl.Titles(0).Text
                '    MChartProp_Form._XaxisTitle = diag.AxisX.Title.Text
                '    MChartProp_Form._YaxisTitle = diag.AxisY.Title.Text

                '    If Not Double.IsNaN(diag.AxisY.WholeRange.MaxValue) Then
                '        MChartProp_Form._YScaleMax = diag.AxisY.WholeRange.MaxValue
                '        MChartProp_Form._YScaleMin = diag.AxisY.WholeRange.MinValue
                '    Else
                '        MChartProp_Form._YScaleMax = 0
                '        MChartProp_Form._YScaleMin = 0
                '    End If

                '    MChartProp_Form.XYAxislbl_Font = MChart_Ctrl.Series(0).Label.Font
                '    MChartProp_Form.XYAxislbl_color = MChart_Ctrl.Series(0).Label.BackColor

                '    MChartProp_Form.Chart_BGColor = MChart_Ctrl.BackColor

                '    MChartProp_Form.txtXAxisTitle.Text = diag.AxisX.Title.Text
                '    MChartProp_Form.txtYAxisTitle.Text = diag.AxisY.Title.Text
                '    MChartProp_Form.xyTitle_Color = diag.AxisX.Title.TextColor

                '    If diag.AxisY.Tag = "True" Then
                '        MChartProp_Form.ckYAutoScale.Checked = True
                '    Else
                '        MChartProp_Form.ckYAutoScale.Checked = False
                '    End If
                'End If

                'MChartPropertiesFormNew.ShowDialog()
            End If
        Catch ex As Exception
            _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DMS_ChartProperties_Click()")
            MainErrorPV.SetError(lblAlert, "Error !!!")
        End Try

    End Sub

    Private Function GetLinearEquationYEqualToMXPlusB(sngX1 As Single,
                                                      sngY1 As Single,
                                                      sngX2 As Single,
                                                      sngY2 As Single,
                                                      ByRef sngM As Single,
                                                      ByRef sngB As Single) As String

        'y=mx+b
        'where m = (y2-y1)/(x2-x1)

        sngM = (sngY2 - sngY1) / (sngX2 - sngX1)
        sngB = sngY1 - sngM * sngX1

        Dim strEquation As String
        strEquation = "y=" & sngM & "*x+" & sngB

        Return strEquation

    End Function

    'Private Sub UpdateMChartVariablesFromDataRow(dr As DataRow, ByRef MChart As MChartControl)

    '    MChart.Tag = "MChart"
    '    'PageNo
    '    MChart.Name = dr("Ctrl_Name")

    '    MChart.MinimumSize = Ctrl_MinSize

    '    Dim diagram As ch.XYDiagram = CType(MChart.Diagram, ch.XYDiagram)
    '    Dim aryMcTitleFont() As String
    '    aryMcTitleFont = Split(dr("McTitleFont"), ",")

    '    Dim charttitle As ch.ChartTitle = New ch.ChartTitle
    '    charttitle.Text = dt.Rows(0).Item("McTitle")

    '    If aryMcTitleFont(2) = "Regular" Then
    '        charttitle.Font = New Font(aryMcTitleFont(0), CSng(aryMcTitleFont(1)), FontStyle.Regular)
    '    ElseIf aryMcTitleFont(2) = "Bold" Then
    '        charttitle.Font = New Font(aryMcTitleFont(0), CSng(aryMcTitleFont(1)), FontStyle.Bold)
    '    ElseIf aryMcTitleFont(2) = "Italic" Then
    '        charttitle.Font = New Font(aryMcTitleFont(0), CSng(aryMcTitleFont(1)), FontStyle.Italic)
    '    End If
    '    charttitle.TextColor = Color.FromArgb(CInt(aryMcTitleFont(3)))
    '    MChart.Titles.Add(charttitle)
    '    diagram.AxisX.Title.Text = dr("McXAxisTitle")
    '    diagram.AxisY.Title.Text = dr("McYAxisTitle")
    '    diagram.AxisX.Title.TextColor = Color.FromArgb(dr("McXYAxisTitleColor"))
    '    MChart.BackColor = Color.FromArgb(dr("McChartBackColor"))
    '    MChart.Legends(0).BackColor = Color.FromArgb(dr("McLegendColor"))
    '    diagram.AxisX.Color = Color.FromArgb(dr("McAxisLabelColor"))
    '    MChart.gstrMCActionChannel = dr("McActionChannel")

    '    MChart.Location = New Point(CInt(dr("McLocX")), CInt(dr("McLocY")))
    '    MChart.Width = dr("McWidth")
    '    MChart.Height = dr("McHeight")

    '    MChart.gstrMCTagForLambda = dr("McTagForLambda")
    '    MChart.gstrMCLambdaSeriesName = dr("McLambdaSeriesName")
    '    MChart.gstrMCLambdaSeriesColor = dr("McLambdaSeriesColor")

    '    MChart.gstrMCTagForP1 = dr("McTagForP1")
    '    MChart.gstrMCTagForP1Lambda = dr("MCTagForP1Lambda")
    '    MChart.gstrMCP1SeriesName = dr("McP1SeriesName")
    '    MChart.gstrMCP1SeriesName = dr("McP1SeriesColor")

    '    MChart.gstrMCTagForP2 = dt.Rows(0).Item("McTagForP2")
    '    MChart.gstrMCTagForP2Lambda = dt.Rows(0).Item("MCTagForP2Lambda")
    '    MChart.gstrMCP2SeriesName = dr("McP2SeriesName")
    '    MChart.gstrMCP2SeriesColor = dr("McP2SeriesColor")

    '    MChart.gstrMCMinTag = dr("McMinTag")
    '    MChart.gstrMCMinSeriesName = dr("McMinSeriesName")
    '    MChart.gstrMCMinSeriesColor = dr("McMinSeriesColor")

    '    MChart.gstrMCMaxTag = dr("McMaxTag")
    '    MChart.gstrMCMaxSeriesName = dr("McMaxSeriesName")
    '    MChart.gstrMCMaxSeriesColor = dr("McMaxSeriesColor")

    'End Sub
    'Private Sub DataTableToChartVariables(dr As DataRow, ByRef objMChartCtrl As MChartControl)

    '    With objMChartCtrl
    '        .AccessibleDescription = dr("McActionChannel")

    '        .gstrMCTitle = dr("McTitle")
    '        .gstrMCTitleFont = dr("McTitleFont")
    '        .gstrMCXAxisTitle = dr("McXAxisTitle")
    '        .gstrMCYAxisTitle = dr("McYAxisTitle")
    '        .gstrMCXYAxisTitleColor = dr("McXYAxisTitleColor")
    '        .gstrMCChartBackColor = dr("McChartBackColor")
    '        .gstrMCLegendEnable = dr("McLegendEnable")
    '        .gstrMCLegendColor = dr("McLegendColor")
    '        .gstrMCAxisLabelEnable = dr("McAxisLabelEnable")
    '        .gstrMCAxisLabelColor = dr("McAxisLabelColor")

    '        .gstrMCActionChannel = dr("McActionChannel")
    '        .gintMcTargetPower = dr("McTargetPower")
    '        .gintMcUnits = dr("McUnits")
    '        .gintMcSamples = dr("McSamples")

    '        .gintLeft = dr("McLocX")
    '        .gintTop = dr("McLocY")
    '        .gintHeight = dr("McHeight")
    '        .gintWidth = dr("McWidth")

    '        .gstrMCTagForLambda = dr("McTagForLambda")
    '        .gstrMCLambdaSeriesName = dr("McLambdaSeriesName")
    '        .gstrMCLambdaSeriesColor = dr("McLambdaSeriesColor")



    '        .gintMCDgvTop = dr("McDgvTop")
    '        .gintMCDgvLeft = dr("McDgvLeft")
    '        .gintMCDgvWidth = dr("McDgvWidth")
    '        .gintMCDgvHeight = dr("McDgvHeight")

    '        .gintMCDgvCol0Width = dr("McDgvCol0Width")
    '        .gintMCDgvCol1Width = dr("McDgvCol1Width")
    '        .gintMCDgvCol2Width = dr("McDgvCol2Width")

    '        .glosMCTagForMan.Clear()
    '        .glosMCTagForPLambda.Clear()
    '        .glosMCTagForOpt.Clear()
    '        .glosMCTagForMin.Clear()
    '        .glosMCMinColor.Clear()
    '        .glosMCTagForMax.Clear()
    '        .glosMCSeriesName.Clear()
    '        .glosMCSeriesColor.Clear()
    '        .glosMCIntersectName.Clear()
    '        .glosMCIntersectColor.Clear()
    '        .glosMCActData.Clear()

    '        .glosMCTagForMan.AddRange(Split(dr("McTagForMan"), "~"))
    '        .glosMCTagForPLambda.AddRange(Split(dr("McTagForSch"), "~"))
    '        .glosMCTagForOpt.AddRange(Split(dr("McTagForOpt"), "~"))
    '        .glosMCTagForMin.AddRange(Split(dr("McTagForMin"), "~"))
    '        .glosMCTagForMin.AddRange(Split(dr("McMinColor"), "~"))
    '        .glosMCTagForMax.AddRange(Split(dr("McTagForMax"), "~"))
    '        .glosMCTagForMax.AddRange(Split(dr("McMaxColor"), "~"))
    '        .glosMCSeriesName.AddRange(Split(dr("McSeriesName"), "~"))
    '        .glosMCSeriesColor.AddRange(Split(dr("McSeriesColor"), "~"))
    '        .glosMCIntersectName.AddRange(Split(dr("McIntersectName"), "~"))
    '        .glosMCIntersectColor.AddRange(Split(dr("McIntersectColor"), "~"))
    '        .glosMCActData.AddRange(Split(dr("McActData"), "~"))
    '    End With

    'End Sub

#End Region

End Class
