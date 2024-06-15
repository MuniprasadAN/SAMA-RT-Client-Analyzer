' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 02-06-2014
'
' Last Modified By : supra
' Last Modified On : 02-13-2014
' ***********************************************************************
' <copyright file="DBDataForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Security.Permissions
Imports System.Text
Imports System.Security.Cryptography
Imports System.Threading
Imports NAudio.Wave
Imports System.ComponentModel

Public Class DBDataForm
    Friend Q_Timer As New System.Windows.Forms.Timer
    Private Q_Constr As String = ""
    Private DB_Query As String = ""
    Private Annun_Query As String = ""
    Private path As String = ""
    Private Myname As String = ""
    Friend Watcher As New FileSystemWatcher()
    Private Event_ID As Integer = 0
    Private temp_Qyery As String = ""
    Private Row_Size As Integer = 0

    Private _blink As Boolean
    Public _timer As New System.Windows.Forms.Timer
    Public dt_AnnunciatorValue As New DataTable
    Public dt_PriorityAnunnciator As New DataTable
    Dim usr As MainPage
    Dim _AnnunAlarmstateClass As New AnnunciatorAlarmstateClass

    ''' <summary>
    ''' Initializes a new instance of the <see cref="DBDataForm" /> class.	
    ''' </summary>
    ''' <param name="Annun_Name">The Annun_Name.</param>
    ''' <param name="query">The query.</param>
    ''' <param name="rfTime">The rf time.</param>
    ''' <param name="constr">The constr.</param>
    ''' <param name="serverMode">The server mode.</param>
    ''' <param name="name">The name.</param>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Public Sub New(ByVal Annun_Name As String, ByVal query As String, ByVal rfTime As Integer, ByVal constr As String, ByVal serverMode As Boolean, ByVal name As String)
        Try
            InitializeComponent()
            Myname = Annun_Name
            Dim fd = Myname
            If serverMode Then
                If rfTime > 0 Then
                    Q_Timer.Interval = rfTime
                Else
                    Q_Timer.Interval = 1000
                End If
                If Annun_Name = "Grid" Then
                    temp_Qyery = query
                    Q_Constr = constr
                    DB_Query = query
                    AddHandler Q_Timer.Tick, (AddressOf Q_TimerTick)
                ElseIf Annun_Name = "Annunciator" Then
                    Q_Constr = constr
                    Annun_Query = query
                    MainPage.Annunciator_Ctrl.AccessibleDescription = name
                    'Add_AnnunBtn_Properties(MainPage.Annunciator_Ctrl, Annun_Query)
                    AddHandler Q_Timer.Tick, (AddressOf Q_AnnunciatorTimerTick)
                End If

                If rfTime > 0 AndAlso MainPage.Lst_TableName.Count > 0 Then
                    Q_Timer.Start()
                Else
                    Q_Timer.Stop()
                End If
            End If

            'Myname = name
            'Dim fd = MainPage.Annunciator_Ctrl.Name
            'If serverMode Then
            '    If rfTime > 0 Then
            '        Q_Timer.Interval = rfTime
            '    Else
            '        Q_Timer.Interval = 1000
            '    End If
            '    'Q_Constr = constr
            '    'DB_Query = query'

            '    temp_Qyery = query
            '        Q_Constr = constr
            '        DB_Query = query
            '        AddHandler Q_Timer.Tick, (AddressOf Q_TimerTick)

            '    If rfTime > 0 AndAlso MainPage.Lst_TableName.Count > 0 Then
            '        Q_Timer.Start()
            '    Else
            '        Q_Timer.Stop()
            '    End If

            '-----------------------SAMA Chanels in data sample ===================='
            'Else
            '    'Clien Mode

            '    Watcher = New FileSystemWatcher()
            '    Watcher.Filter = "*.rdt" & Myname
            '    Watcher.Path = MainPage.Server_PullDataPath
            '    Watcher.NotifyFilter = NotifyFilters.LastWrite
            '    ' Add event handlers. 
            '    AddHandler Watcher.Changed, AddressOf OnChanged
            '    Watcher.EnableRaisingEvents = False 'temprorly stop the raise event
            'End If

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DBDataForm-New()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            InsertFileLog(ex.Message)
        End Try
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


    'Public Sub New(ByVal query As String, ByVal rfTime As Integer, ByVal constr As String, ByVal serverMode As Boolean, ByVal name As String)
    '    Try
    '        InitializeComponent()
    '        'Myname = Annun_Name
    '        Dim fd = Myname
    '        If serverMode Then
    '            If rfTime > 0 Then
    '                Q_Timer.Interval = rfTime
    '            Else
    '                Q_Timer.Interval = 1000
    '            End If
    '            If query Then
    '                Dim TagVal = query.Split(",")
    '                If Not TagVal Is Nothing Then
    '                    Dim Annunciator_Ctrl As AnnunciatorCtrl
    '                    For i = 0 To TagVal.Length - 1
    '                        Dim TagNo = TagVal(i)
    '                        Dim Button = New Button_Control
    '                        Button.Size = New Size(118, 50)
    '                        Button.BackColor = Color.Gainsboro
    '                        Button.Tag = TagNo.ToString
    '                        Button.Text = TagNo.ToString
    '                        Button.Name = TagNo.ToString
    '                        Annunciator_Ctrl.Controls.Add(Button)
    '                    Next
    '                End If
    '            End If

    '            'If Annun_Name = "Grid" Then
    '            '    temp_Qyery = query
    '            '    Q_Constr = constr
    '            '    DB_Query = query
    '            '    AddHandler Q_Timer.Tick, (AddressOf Q_TimerTick)
    '            'ElseIf Annun_Name = "Annunciator" Then
    '            Q_Constr = constr
    '            Annun_Query = query
    '            AddHandler Q_Timer.Tick, (AddressOf Q_AnnunciatorTimerTick)
    '            'End If

    '            If rfTime > 0 AndAlso MainPage.Lst_TableName.Count > 0 Then
    '                Q_Timer.Start()
    '            Else
    '                Q_Timer.Stop()
    '            End If
    '        End If


    '    Catch ex As Exception
    '        MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DBDataForm-New()")
    '        MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
    '    End Try
    'End Sub

    Public Sub Add_AnnunBtn_Properties(ByVal Annunciator_Ctrl As AnnunciatorCtrl, ByVal DBQUeryVA As String)
        Try
            Annunciator_Ctrl.Controls.Clear()
            Dim TagVal = DBQUeryVA.Split(",")
            If Not TagVal Is Nothing Then
                For i = 0 To TagVal.Length - 1
                    Dim TagNo = TagVal(i)
                    Dim Button = New Button_Control
                    Button.Size = New Size(118, 50)
                    Button.BackColor = Color.Gainsboro
                    Button.Tag = TagNo.ToString
                    Button.Text = TagNo.ToString
                    Button.Name = TagNo.ToString
                    Annunciator_Ctrl.Controls.Add(Button)
                Next
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AnnunciatorFlow_Properties()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")

        End Try
        Me.Close()
    End Sub
    ' Define the event handlers. 
    ''' <summary>
    ''' When file is modified onChanged Event imediatly raise to get data from changed File
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>File Changed()</remarks>
    Private Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)

        Try

            Dim obj_Watcher As System.IO.FileSystemWatcher = source
            obj_Watcher.EnableRaisingEvents = False

            If e.ChangeType = IO.WatcherChangeTypes.Changed Then
                If Me.InvokeRequired Then
                    path = e.FullPath
                    Me.Invoke(New MethodInvoker(AddressOf TT))
                Else
                    path = e.FullPath
                End If
            End If
            obj_Watcher.EnableRaisingEvents = True

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DBDataForm-OnChanged()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' procedure to call the "Fun_RetrieveDBDataFromFile()" and "Data_UpDated()"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TT()
        Dim dt As DataTable = Fun_RetrieveDBDataFromFile(path)
        If Not dt Is Nothing Then
            Call Data_UpDated(dt)
            DGVDBChannelsValue.DataSource = dt 'binding dt
            MS_Updatetime.Text = Now & " No of Rows : " & dt.Rows.Count
        End If
    End Sub
    ''' <summary>
    ''' procedure to get the data from file
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Fun_RetrieveDBDataFromFile(ByVal path As String) As DataTable
        Dim ds As New DataSet
        Dim dtData As New DataTable
        Try
            ds = New DataSet
            'ds.ReadXml(path)
            MyDecryptor(ds, path) 'Read Data From File

            If Not ds.Tables.Count > 0 Then
                Return Nothing
            End If
            dtData = ds.Tables(0)
            If dtData.Columns.Contains("StartTime") Then
                For Each r In dtData.Rows
                    r("StartTime") = CDate(r("StartTime")).ToString("dd/MM/yyyy HH:mm:ss.fff")
                Next
            End If
            If dtData.Columns.Contains("SupraCurrTime_") Then
                For Each r In dtData.Rows
                    r("SupraCurrTime_") = CDate(r("SupraCurrTime_")).ToString("dd/MM/yyyy HH:mm:ss.fff")
                Next
            End If
            If dtData.Columns.Contains("RtnTime") Then
                For Each r In dtData.Rows
                    If Not IsDBNull(r("RtnTime")) Then
                        r("RtnTime") = CDate(r("RtnTime")).ToString("dd/MM/yyyy HH:mm:ss.fff")
                    End If

                Next
            End If
            ds.Tables(0).TableName = "DBData"

        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Fun_RetrieveDBDataFromFile()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
        Return dtData
    End Function
    ''' <summary>
    ''' Q_TimerTick event to call "Fun_RetrieveDBData()" and  "Data_UpDated()"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>


    Private Sub Q_TimerTick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Alarm_Timer.Tick
        Try
            Q_Timer.Stop()
            Dim dt As DataTable = Nothing
            Thread.Sleep(200)

            dt = Fun_RetrieveDBData(DB_Query) 'Geting Data From SQL Server
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    Call Data_UpDated(dt) 'Data Update to Control
                    If MainPage.blnDB_AllowClients Then
                        Call Proc_DataPushtoRemoteData(dt) 'Write to .rdt file
                    End If
                End If

                'DGVDBChannelsValue.DataSource = dt 'binding dt
                'If DGVDBChannelsValue.Columns.Contains("StartTime") Then
                '      DGVDBChannelsValue.Columns("StartTime").DefaultCellStyle.Format="MM/dd/yyyy HH:mm:ss fff"
                'End If

                MS_Updatetime.Text = Now & "No of Rows affected : " & dt.Rows.Count
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Q_TimerTick()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            Q_Timer.Start()
        End Try
    End Sub

    Private Sub Q_AnnunciatorTimerTick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim myConnection As New SqlConnection
        Dim sqlcmd As New SqlCommand
        Dim QueryTag As New List(Of String)
        Dim QueryTagParameter As New List(Of String)

        Try
            Q_Timer.Stop()

            Dim dtb As New DataTable
            Thread.Sleep(200)
            'MainPage.Annunciator_Ctrl.Controls.Clear()
            GenerateAnnunciator()
            GenerateAnnunciatorPriority()

            myConnection = New SqlConnection(Q_Constr)
            Dim cTRLvAL = MainPage.Annunciator_Ctrl.Controls
            Dim QuerDta = Annun_Query.Split(",")
            For i = 0 To QuerDta.Length - 1
                Dim T_Val = QuerDta(i).Substring(0, QuerDta(i).LastIndexOf("."))
                If Not QueryTag.Contains(T_Val) Then
                    Dim T_Val2 = T_Val.Substring(T_Val.LastIndexOf("~") + 1)
                    QueryTag.Add(T_Val2)
                End If
                Dim TP_Val = QuerDta(i).Substring(QuerDta(i).LastIndexOf(".") + 1)
                If Not QueryTagParameter.Contains(TP_Val) Then
                    QueryTagParameter.Add(TP_Val)
                End If
            Next

            dt = Fun_AnnunciatorRetrieveDBData(QueryTag) 'Geting Data From SQL Server
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    Call Data_UpDated(dt) 'Data Update to Control
                    'If MainPage.blnDB_AllowClients Then
                    '    Call Proc_DataPushtoRemoteData(dt) 'Write to .rdt file
                    'End If
                End If

                'MS_Updatetime.Text = Now & "No of Rows affected : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Q_AnnunciatorTimerTick()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            Q_Timer.Start()
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

    End Sub


    ''' <summary>
    ''' procedure to write data to RemoteData Folder
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub Proc_DataPushtoRemoteData(ByVal dt As DataTable)
        Try
            Dim ds As DataSet
            ds = New DataSet
            ds.Tables.Add(dt)
            ds.Tables(0).TableName = "DBData"
            If dt.Rows.Count > 0 Then
                If Not IO.Directory.Exists(MainPage.Server_PushDataPath & "\RemoteData") Then
                    IO.Directory.CreateDirectory(MainPage.Server_PushDataPath & "\RemoteData")
                End If
                'ds.WriteXml(Application.StartupPath & "\RemoteData\" & Me.Name & ".rdt" & Me.Name)
                MyEncryptor(ds, MainPage.Server_PushDataPath & "\RemoteData\" & Me.Name & ".rdt" & Me.Name)
            End If

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_DataPushtoRemoteData()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes("B499F4BF48242E05548D1E4C8BB26A2E")
    Dim byteIV As Byte() = System.Text.Encoding.UTF8.GetBytes(",%u'm&'CXSy/T7x;4")
    Dim _Mutex As new Mutex
    ''' <summary>
    ''' Write all configuration to  file with encripted format
    ''' </summary>
    ''' <param name="D"></param>
    ''' <param name="sPath"></param>
    ''' <remarks></remarks>
    Friend Sub MyEncryptor(ByVal D As DataSet, ByVal sPath As String)
        Try
            _Mutex.WaitOne(1000)
            Thread.Sleep(100)
            Dim vFile As IO.FileStream = New IO.FileStream(sPath, FileMode.Create,FileAccess.Write,FileShare.ReadWrite)
            Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateEncryptor(byteKey, byteIV), CryptoStreamMode.Write)
            Dim vXmlWriter As New Xml.XmlTextWriter(vCrypto, Encoding.Unicode)

            vXmlWriter.WriteStartDocument(True)
            D.WriteXml(vXmlWriter)
            vCrypto.FlushFinalBlock()

            vXmlWriter.Close()
            vCrypto.Close()
            vFile.Close()
        Catch ex As Exception
             MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DBDataForm MyEncryptor()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            _Mutex.ReleaseMutex()
           
        End Try
        
    End Sub
    ''' <summary>
    ''' Read the  file get the normal text from the encripted text
    ''' </summary>
    ''' <param name="D"></param>
    ''' <param name="sPath"></param>
    ''' <remarks></remarks>
    Friend Sub MyDecryptor(ByVal D As DataSet, ByVal sPath As String)
        Try
             _Mutex.WaitOne(1000)
            Thread.Sleep(200)
            Dim vFile As IO.FileStream = New IO.FileStream(sPath, FileMode.Open,FileAccess.Read,FileShare.ReadWrite)
            Dim vCrypto As New CryptoStream(vFile, (New RijndaelManaged()).CreateDecryptor(byteKey, byteIV), CryptoStreamMode.Read)
            Dim vStreamReader As New IO.StreamReader(vCrypto, Encoding.Unicode)
            Dim vXmlReader As New Xml.XmlTextReader(vStreamReader)

            D.ReadXml(vXmlReader)

            vXmlReader.Close()
            vStreamReader.Close()
            vCrypto.Close()
            vFile.Close()
        Catch ex As Exception
             MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DBDataForm MyDecryptor()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            _Mutex.ReleaseMutex()
          
        End Try

    End Sub
    ''' <summary>
    ''' update the Values to the all controls here
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    ''' 
    Private Delegate Sub UpdateData(ByVal dt As DataTable)

    Friend Sub Data_UpDated(ByVal dt As DataTable)
        Try
            For j As Integer = 0 To MainPage.CreatedPages.Count - 1
                Dim pnlObj() As Control
                pnlObj = MainPage.Controls.Find(MainPage.CreatedPages(j), True) 'Get the Panel control
                If pnlObj.Length > 0 Then
                    If Not pnlObj(0) Is Nothing Then
                        For Each Fcontrols In pnlObj(0).Controls 'Get the controls one by one from panel control
                            If (TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then

                                If Not (Not Fcontrols.AccessibleDescription Is Nothing AndAlso String.IsNullOrEmpty(Fcontrols.AccessibleDescription)) AndAlso MainPage.channelList.Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If Fcontrols.AccessibleDescription = Me.Name Then
                                        If Not Fcontrols.DataBindings.Count > 0 Then
                                            If Not dt.Rows(0).IsNull(0) Then
                                                Fcontrols.DataBindings.Add("Value", dt, "Value")
                                            Else
                                                Fcontrols.Value = 0
                                            End If
                                        Else
                                            Fcontrols.DataBindings.RemoveAt(0)
                                            If Not dt.Rows(0).IsNull(0) Then
                                                Fcontrols.DataBindings.Add("Value", dt, "Value")
                                            Else
                                                Fcontrols.Value = 0
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            If (TypeOf Fcontrols Is LabelValue) Then
                                Dim value_lbl As LabelValue
                                value_lbl = Fcontrols
                                If (Not String.IsNullOrEmpty(Fcontrols.AccessibleDescription)) AndAlso MainPage.channelList.Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If Fcontrols.AccessibleDescription = Me.Name Then
                                        If Not Fcontrols.DataBindings.Count > 0 Then
                                            Fcontrols.DataBindings.Add("Text", dt, "Value")
                                        Else
                                            Fcontrols.DataBindings.RemoveAt(0)
                                            Fcontrols.DataBindings.Add("Text", dt, "Value")
                                        End If
                                        Dim val As Integer = CInt(value_lbl.Text)


                                        If value_lbl._ThresholdValue.Count > 0 Then
                                            Dim spltValue() As String
                                            For i As Integer = 0 To value_lbl._ThresholdValue.Count - 1
                                                spltValue = Nothing
                                                spltValue = value_lbl._ThresholdValue(i).Split("@")
                                                Select Case spltValue(0)
                                                    Case "="
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(spltValue(1)) = CInt(val) Then

                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))

                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If


                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        ElseIf spltValue(1).Contains(val) Then
                                                            value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                            value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                            If value_lbl._THblink(i) = True Then
                                                                value_lbl.Blink = True
                                                            Else
                                                                value_lbl.Blink = False
                                                            End If
                                                            If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                value_lbl.Text = value_lbl._Description(i)
                                                            Else
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                            End If
                                                            Exit For
                                                        Else
                                                            value_lbl.Blink = False
                                                            value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                            value_lbl.BackColor = value_lbl.Default_BackColor
                                                            value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                        End If
                                                    Case ">"
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(val) > CInt(spltValue(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        End If
                                                    Case "<"
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(val) < CInt(spltValue(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        End If
                                                    Case ">="
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(val) >= CInt(spltValue(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_

                                                            End If
                                                        End If
                                                    Case "<="
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(val) <= CInt(spltValue(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        End If
                                                    Case "<>"
                                                        If IsNumeric(spltValue(1)) Then
                                                            If CInt(val) <> CInt(spltValue(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        End If
                                                    Case ">=<="
                                                        Dim bt_Val() As String = spltValue(1).Split(":")
                                                        If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                            If CInt(val) >= CInt(bt_Val(0)) And CInt(val) <= CInt(bt_Val(1)) Then
                                                                value_lbl.BackColor = Color.FromArgb(value_lbl._THBackColor(i))
                                                                value_lbl.ForeColor = Color.FromArgb(value_lbl._THForeColor(i))
                                                                If value_lbl._THblink(i) Then
                                                                    value_lbl.Blink = True
                                                                Else
                                                                    value_lbl.Blink = False
                                                                End If
                                                                If Not String.IsNullOrEmpty(value_lbl._Description(i)) Then
                                                                    value_lbl.Text = value_lbl._Description(i)
                                                                Else
                                                                    value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = val & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        End If
                                                    Case Else
                                                        ' do the defalut action
                                                End Select
                                            Next
                                        Else
                                            value_lbl.Text = val & " " & value_lbl.UnitsValue
                                        End If

                                    End If

                                End If
                            End If
                            If (TypeOf Fcontrols Is Chart) Then
                                Dim Chart_Ctrl As ChartControl = Fcontrols 'Assign Ctrl
                                For i As Integer = 0 To Chart_Ctrl.Series.Count - 1
                                    If Not (Not Chart_Ctrl.Series(i).YValueMembers Is Nothing AndAlso String.IsNullOrEmpty(Chart_Ctrl.Series(i).YValueMembers)) AndAlso MainPage.channelList.Channel_Name.Contains(Fcontrols.Series(i).YValueMembers) Then
                                        If Chart_Ctrl.Series(i).YValueMembers = Me.Name Then
                                            Chart_Ctrl.Series(i).Points.Clear() 'Clear ChartCtrl Points

                                            If dt.Columns.Count >= 3 Then
                                                For rowIndex As UShort = 0 To dt.Rows.Count - 1
                                                    Chart_Ctrl.Series(i).Points.AddXY(dt.Rows(rowIndex).Item(1) & "(&)" & dt.Rows(rowIndex).Item(2), dt.Rows(rowIndex).Item(0))
                                                    'Color Set to TH
                                                    If Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then

                                                        For k As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                                                            If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Contains(":") Then
                                                                Dim bt_Val() As String = Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Split(":")
                                                                If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                    If CInt(dt.Rows(rowIndex).Item(0)) >= CInt(bt_Val(0)) And CInt(dt.Rows(rowIndex).Item(0)) <= CInt(bt_Val(1)) Then
                                                                        Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                                    End If
                                                                End If

                                                            Else
                                                                If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Equals(dt.Rows(rowIndex).Item(0)) Then
                                                                    Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                                End If

                                                            End If

                                                        Next
                                                    End If
                                                Next
                                            Else
                                                For rowIndex As UShort = 0 To dt.Rows.Count - 1
                                                    Fcontrols.Series(i).Points.AddXY(If(IsDBNull(dt.Rows(rowIndex).Item(1)), "", dt.Rows(rowIndex).Item(1)), dt.Rows(rowIndex).Item(0))
                                                    'Color Set to TH
                                                    If Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then

                                                        For k As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                                                            If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Contains(":") Then
                                                                Dim bt_Val() As String = Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Split(":")
                                                                If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                    If CInt(dt.Rows(rowIndex).Item(0)) >= CInt(bt_Val(0)) And CInt(dt.Rows(rowIndex).Item(0)) <= CInt(bt_Val(1)) Then
                                                                        Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                                    End If
                                                                End If

                                                            Else
                                                                If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Equals(dt.Rows(rowIndex).Item(0)) Then
                                                                    Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                                End If

                                                            End If

                                                        Next
                                                    End If
                                                Next
                                            End If
                                        End If
                                    End If
                                Next
                            End If

                            If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                Dim gvCtrl As DataGridViewCtrl
                                gvCtrl = Fcontrols
                                If Not String.IsNullOrEmpty(gvCtrl.AccessibleDescription) AndAlso MainPage.channelList.Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If gvCtrl.AccessibleDescription = Me.Name Then
                                        gvCtrl.AutoGenerateColumns = True
                                        If dt.Columns.Count > 0 AndAlso Not dt.Columns.Count = gvCtrl.Columns.Count Then ' Column Count > or < GvCtrl  Clear All Columns
                                            gvCtrl.Columns.Clear() 'Clear Column with Column Count Change 
                                        End If

                                        If Not gvCtrl.Columns.Count > 0 Then
                                            If dt.Columns.Contains("EventId") Then
                                                If Not String.IsNullOrEmpty(DB_Query) Then
                                                    Dim Ss As String = temp_Qyery.Substring(0, 20)
                                                    Dim AQ = Ss.Split(" ")
                                                    Row_Size = AQ(2)
                                                Else
                                                    Dim idx = MainPage.channelList.Channel_Name.IndexOf(Me.Name)
                                                    If idx <> -1 Then
                                                        Dim Ss As String = MainPage.channelList._Query_Channel(idx).Substring(0, 20)
                                                        Dim AQ = Ss.Split(" ")
                                                        Row_Size = AQ(2)
                                                    End If
                                                End If
                                                For i As Integer = 0 To dt.Columns.Count - 1
                                                    gvCtrl.Columns.Add(dt.Columns(i).ColumnName, dt.Columns(i).ColumnName)
                                                Next
                                                gvCtrl.Columns(0).Visible = False
                                            Else
                                                Row_Size = dt.Rows.Count
                                                For i As Integer = 0 To dt.Columns.Count - 1
                                                    gvCtrl.Columns.Add(dt.Columns(i).ColumnName, dt.Columns(i).ColumnName)
                                                Next
                                            End If

                                        Else
                                            If dt.Columns.Contains("EventId") Then
                                                If Not String.IsNullOrEmpty(DB_Query) Then
                                                    Dim Ss As String = temp_Qyery.Substring(0, 20)
                                                    Dim AQ = Ss.Split(" ")
                                                    Row_Size = AQ(2)

                                                    If dt.Rows.Count > 0 Then
                                                        Event_ID = dt.Rows(0).Item(0)
                                                        DB_Query = temp_Qyery.Replace(">0", ">" & Event_ID)
                                                    End If
                                                Else
                                                    Dim idx = MainPage.channelList.Channel_Name.IndexOf(Me.Name)
                                                    If idx <> -1 Then
                                                        Dim Ss As String = MainPage.channelList._Query_Channel(idx).Substring(0, 20)
                                                        Dim AQ = Ss.Split(" ")
                                                        Row_Size = AQ(2)
                                                    End If
                                                End If
                                            Else
                                                Row_Size = dt.Rows.Count
                                                If gvCtrl.Rows.Count >= Row_Size Then
                                                    gvCtrl.Rows.Clear()
                                                End If
                                            End If
                                        End If


                                        For k As Integer = 0 To dt.Rows.Count - 1
                                            If Not gvCtrl.Rows.Count >= Row_Size Then
                                                gvCtrl.Rows.Insert(k, dt.Rows(k).ItemArray)
                                            Else
                                                gvCtrl.Rows.Insert(k, dt.Rows(k).ItemArray)
                                                gvCtrl.Rows.RemoveAt(gvCtrl.Rows.Count - 1)
                                            End If


                                            If gvCtrl._ThresholdValue.Count > 0 Then
                                                Dim spltValue() As String
                                                For i As Integer = 0 To gvCtrl._ThresholdValue.Count - 1
                                                    spltValue = Nothing
                                                    spltValue = gvCtrl._ThresholdValue(i).Split("@")
                                                    If spltValue.Length = 2 Then
                                                        Select Case spltValue(0)
                                                            Case "TagNo"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                            Case "Parameter"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                            Case "AlarmIdentifier"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                            Case "Priority"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                            Case "Channel"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                            Case "Unit"
                                                                Dim temp_Clm = gvCtrl.Columns(spltValue(0))
                                                                If Not temp_Clm Is Nothing Then
                                                                    Dim idx_C = gvCtrl.Columns.IndexOf(temp_Clm)
                                                                    If idx_C <> -1 Then

                                                                        If gvCtrl.Rows(k).Cells(idx_C).Value.ToString.Contains(spltValue(1)) Then
                                                                            gvCtrl.Rows(k).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                            gvCtrl.Rows(k).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                            Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                            If fnt(2) = "Bold" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                            ElseIf fnt(2) = "Italic" Then
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                            Else
                                                                                gvCtrl.Rows(k).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                            End If
                                                                        End If


                                                                    End If
                                                                End If
                                                        End Select
                                                    End If
                                                Next
                                            End If
                                        Next


                                        If dt.Rows.Count > 0 Then
                                            If gvCtrl.Columns.Contains("StartTime") Then
                                                gvCtrl.Columns("StartTime").DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss fff"
                                            End If
                                            If gvCtrl.Columns.Contains("SupraCurrTime_") Then
                                                gvCtrl.Columns("SupraCurrTime_").DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss fff"
                                            End If
                                            If gvCtrl.Columns.Contains("RtnTime") Then
                                                gvCtrl.Columns("RtnTime").DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss fff"
                                            End If
                                            gvCtrl.FirstDisplayedScrollingRowIndex = 0
                                        End If

                                    End If
                                End If
                            End If

                            If (TypeOf Fcontrols Is AnnunciatorCtrl) Then
                                Dim AnnunCtrl As AnnunciatorCtrl
                                AnnunCtrl = Fcontrols

                                Dim asdsa = MainPage.channelList.Channel_Name.Count
                                If Not String.IsNullOrEmpty(AnnunCtrl.AccessibleDescription) AndAlso MainPage.channelList.Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If AnnunCtrl.AccessibleDescription = Me.Name Then
                                        ' If AnnunCtrl.Controls.Count Then 'Columns.Count > 0 Then
                                        Dim dataTagd = dt.Columns().Count
                                            For i = 0 To AnnunCtrl.Controls.Count - 1 'AnnunCtrl.Controls.Count - 1

                                                'If Not String.IsNullOrEmpty(dt.Rows(i).ItemArray(1)) Then
                                                ' Dim dataTag = dt.Rows(i).ItemArray()
                                                'Dim Tag As String = dt.Rows(i).ItemArray(1) & "." & dt.Rows(i).ItemArray(2)
                                                'Dim _StartTime = dt.Rows(i).ItemArray(3)
                                                'Dim RtnEvt As Integer = dt.Rows(i).ItemArray(4)
                                                'Dim NrmEvt As Integer = dt.Rows(i).ItemArray(5)
                                                'Dim AckEvt As Integer = dt.Rows(i).ItemArray(6)


                                                ' Dim Check_TagValxcs() As Control = AnnunCtrl.Controls.Find(Tag, True)
                                                Dim Check_TagVals() As Control = AnnunCtrl.Controls.Find(AnnunCtrl.Controls(i).Tag, True)

                                                    Dim TagV = AnnunCtrl.Controls

                                                    For Each Check_TagVal In Check_TagVals
                                                        Dim ct As Button_Control
                                                        ct = DirectCast(Check_TagVal, Button_Control)

                                                        Dim Result As DataRow()
                                                        Dim T_Val = Check_TagVal.Tag.Substring(0, Check_TagVal.Tag.LastIndexOf("."))

                                                        Result = dt.Select("TagNo='" & T_Val & "'")
                                                        Dim RtnEvt As Integer = Nothing
                                                        Dim NrmEvt As Integer = Nothing
                                                        Dim AckEvt As Integer = Nothing
                                                        Dim _PriorityId As Integer = Nothing
                                                        Dim Tag As String = Nothing
                                                        Dim _PriorityVal As String = Nothing

                                                If Result.Length > 0 Then

                                                    Tag = Result(0).ItemArray(1) & "." & Result(0).ItemArray(2)
                                                    '' Dim _StartTime = Result(0).ItemArray(3)
                                                    RtnEvt = Result(0).ItemArray(4)
                                                    NrmEvt = Result(0).ItemArray(5)
                                                    AckEvt = Result(0).ItemArray(6)
                                                    _PriorityVal = Result(0).ItemArray(11)
                                                    _PriorityId = Result(0).ItemArray(10)
                                                End If

                                                If Not String.IsNullOrEmpty(Check_TagVal.Text) Then
                                                            If Tag = Check_TagVal.Tag Then
                                                                Dim Blink_I As Integer = 0

                                                                '-----------------------Alarm-----------------------'
                                                                If RtnEvt = 0 And NrmEvt = 0 And AckEvt = 0 Then
                                                                    Dim AlarmState = "Alarm"
                                                                    Dim ass = dt_AnnunciatorValue.Rows.Count
                                                                    For k = 0 To ass - 1
                                                                        Dim Mval = dt_AnnunciatorValue.Rows(k).ItemArray(1)
                                                                        Dim timer = dt_AnnunciatorValue.Rows(k).ItemArray(5) * 100
                                                                        If Mval = AlarmState Then
                                                                            Dim ColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(3)
                                                                            Dim ForeColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(2)
                                                                            Dim Blink As Boolean = dt_AnnunciatorValue.Rows(k).ItemArray(4)

                                                                            Check_TagVal.BackColor = Color.FromArgb(ColorVal)
                                                                            Check_TagVal.ForeColor = Color.FromArgb(ForeColorVal)
                                                                            ct._backColor = ColorVal

                                                                            Dim PriorityAnuunVal = dt_PriorityAnunnciator.Rows.Count
                                                                            For l = 0 To PriorityAnuunVal - 1
                                                                                Dim GetPriorityName As String = dt_PriorityAnunnciator.Rows(l).ItemArray(1)
                                                                                Dim Audible As String = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                ct._InterValTime = timer
                                                                                ct.almstate = "Alm"
                                                                                'ct.priority =
                                                                                '-------------------------Blink --------------------------'
                                                                                If Blink Then
                                                                                    ct.Blink = True
                                                                                Else
                                                                                    ct.Blink = False
                                                                                End If

                                                                                '---------------------Audible with priority------------------'
                                                                                Dim _AlarmState As String = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                If _PriorityVal = GetPriorityName And AlarmState = _AlarmState Then
                                                                                    Dim _AlmPrty As Integer = _PriorityId

                                                                                    If Not _AnnunAlarmstateClass.CheckAlaramList.Contains(_AlmPrty) Then
                                                                                        _AnnunAlarmstateClass.CheckAlaramList.Add(_AlmPrty)
                                                                                        If Not _AnnunAlarmstateClass.blnplaying Then
                                                                                            _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                        End If
                                                                                    Else
                                                                                        '_AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    End If

                                                                                End If
                                                                            Next
                                                                        End If
                                                                    Next
                                                                    '----------------------- Normal Alarm-----------------------'
                                                                ElseIf NrmEvt <> 0 And RtnEvt = 0 And AckEvt = 0 Then
                                                                    Dim AlarmState As String = "Normal"
                                                                    Dim ass = dt_AnnunciatorValue.Rows.Count
                                                                    For k = 0 To ass - 1
                                                                        Dim Mval = dt_AnnunciatorValue.Rows(k).ItemArray(1)
                                                                        Dim timer As Integer = dt_AnnunciatorValue.Rows(k).ItemArray(5) * 500
                                                                        If Mval = "Normal" Then
                                                                            Dim ColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(3)
                                                                            Dim ForeColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(2)
                                                                            Dim Blink As Boolean = dt_AnnunciatorValue.Rows(k).ItemArray(4)

                                                                            Check_TagVal.BackColor = Color.FromArgb(ColorVal)
                                                                            Check_TagVal.ForeColor = Color.FromArgb(ForeColorVal)
                                                                            ct._backColor = ColorVal

                                                                            Dim PriorityAnuunVal = dt_PriorityAnunnciator.Rows.Count
                                                                            For l = 0 To PriorityAnuunVal - 1
                                                                                Dim GetPriorityName As String = dt_PriorityAnunnciator.Rows(l).ItemArray(1)
                                                                                Dim Audible As String = dt_PriorityAnunnciator.Rows(l).ItemArray(2)
                                                                                ct._InterValTime = timer

                                                                                ct.almstate = "NORMAL"
                                                                                If Blink Then
                                                                                    ct.Blink = True
                                                                                Else
                                                                                    ct.Blink = False
                                                                                End If

                                                                                '---------------------Audible with priority------------------'
                                                                                Dim _AlarmState As String = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                If _PriorityVal = GetPriorityName And AlarmState = _AlarmState Then
                                                                                    Dim _AlmPrty As Integer = _PriorityId

                                                                                    If Not _AnnunAlarmstateClass.CheckAlaramList.Contains(_AlmPrty) Then
                                                                                        _AnnunAlarmstateClass.CheckAlaramList.Add(_AlmPrty)
                                                                                        If Not _AnnunAlarmstateClass.blnplaying Then
                                                                                            _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                        End If
                                                                                    Else
                                                                                        '_AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    End If

                                                                                End If
                                                                            Next
                                                                        End If
                                                                    Next
                                                                ElseIf RtnEvt <> 0 And NrmEvt = 0 And AckEvt = 0 Then
                                                                    ' MsgBox("Return")
                                                                    Dim ass = dt_AnnunciatorValue.Rows.Count
                                                                    For k = 0 To ass - 1
                                                                        Dim Mval = dt_AnnunciatorValue.Rows(k).ItemArray(1)
                                                                        Dim AlarmState = "Return To Normal"
                                                                        If Mval = AlarmState Then
                                                                            Dim ColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(3)
                                                                            Dim ForeColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(2)
                                                                            Dim Blink = dt_AnnunciatorValue.Rows(k).ItemArray(4)
                                                                            Check_TagVal.BackColor = Color.FromArgb(ColorVal)
                                                                            Check_TagVal.ForeColor = Color.FromArgb(ForeColorVal)
                                                                            ct._backColor = ColorVal

                                                                            Dim PriorityAnuunVal = dt_PriorityAnunnciator.Rows.Count
                                                                            For l = 0 To PriorityAnuunVal - 1
                                                                                Dim GetPriorityName = dt_PriorityAnunnciator.Rows(l).ItemArray(1)
                                                                                Dim Audible = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                Dim timer = CInt(dt_AnnunciatorValue.Rows(k).ItemArray(5)) * 750
                                                                                ct._InterValTime = timer

                                                                                '-------------------------Blink --------------------------'
                                                                                If Blink Then
                                                                                    ct.Blink = True
                                                                                Else
                                                                                    ct.Blink = False
                                                                                End If
                                                                                ''---------------------Audible with priority------------------'
                                                                                Dim _AlarmState = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                If _PriorityVal = GetPriorityName And AlarmState = _AlarmState Then
                                                                                    ' Dim Dte As New AnnunciatorAlarmstateClass
                                                                                    Dim _AlmPrty As Integer = _PriorityId

                                                                                    If Not _AnnunAlarmstateClass.CheckAlaramList.Contains(_AlmPrty) Then
                                                                                        _AnnunAlarmstateClass.CheckAlaramList.Add(_AlmPrty)
                                                                                        _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    Else
                                                                                        '_AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    End If

                                                                                End If
                                                                            Next
                                                                        End If
                                                                    Next
                                                                ElseIf AckEvt <> 0 And NrmEvt = 0 And RtnEvt = 0 Then
                                                                    Dim ass = dt_AnnunciatorValue.Rows.Count
                                                                    For k = 0 To ass - 1
                                                                        Dim Mval = dt_AnnunciatorValue.Rows(k).ItemArray(1)
                                                                        Dim AlarmState As String = "Acknowledged  & under Alarm"

                                                                        If Mval = AlarmState Then
                                                                            Dim ColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(3)
                                                                            Dim ForeColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(2)
                                                                            Check_TagVal.BackColor = Color.FromArgb(ColorVal)
                                                                            Check_TagVal.ForeColor = Color.FromArgb(ForeColorVal)
                                                                            ct._backColor = ColorVal

                                                                            Dim PriorityAnuunVal = dt_PriorityAnunnciator.Rows.Count
                                                                            For l = 0 To PriorityAnuunVal - 1
                                                                                Dim GetPriorityName = dt_PriorityAnunnciator.Rows(l).ItemArray(1)
                                                                                Dim Audible = dt_PriorityAnunnciator.Rows(l).ItemArray(2)


                                                                                'TagVal(i).Text = "Acknowledge"
                                                                                Dim Blink = dt_AnnunciatorValue.Rows(k).ItemArray(4)
                                                                                Dim timer = CInt(dt_AnnunciatorValue.Rows(k).ItemArray(5)) * 1000
                                                                                ct._InterValTime = timer
                                                                                If Blink Then
                                                                                    ct.Blink = True
                                                                                Else
                                                                                    ct.Blink = False
                                                                                End If

                                                                                '---------------------Audible with priority------------------'
                                                                                Dim _AlarmState = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                If _PriorityVal = GetPriorityName And AlarmState = _AlarmState Then
                                                                                    Dim _AlmPrty As Integer = _PriorityId

                                                                                    If Not _AnnunAlarmstateClass.CheckAlaramList.Contains(_AlmPrty) Then
                                                                                        _AnnunAlarmstateClass.CheckAlaramList.Add(_AlmPrty)
                                                                                        _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    Else
                                                                                        ' _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                    End If
                                                                                End If
                                                                            Next
                                                                        End If
                                                                    Next
                                                                ElseIf (RtnEvt <> 0 And AckEvt <> 0 And NrmEvt = 0) Then
                                                                    If RtnEvt < AckEvt Then
                                                                        Dim ass = dt_AnnunciatorValue.Rows.Count
                                                                        For k = 0 To ass - 1
                                                                            Dim Mval = dt_AnnunciatorValue.Rows(k).ItemArray(1)
                                                                            Dim AlarmState = "Return To Normal Before Acknowledge"
                                                                            If Mval = AlarmState Then

                                                                                Dim ColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(3)
                                                                                Dim ForeColorVal = dt_AnnunciatorValue.Rows(k).ItemArray(2)
                                                                                Dim Blink = dt_AnnunciatorValue.Rows(k).ItemArray(4)
                                                                                Check_TagVal.BackColor = Color.FromArgb(ColorVal)
                                                                                Check_TagVal.ForeColor = Color.FromArgb(ForeColorVal)
                                                                                ct._backColor = ColorVal

                                                                                Dim PriorityAnuunVal = dt_PriorityAnunnciator.Rows.Count
                                                                                For l = 0 To PriorityAnuunVal - 1
                                                                                    Dim GetPriorityName = dt_PriorityAnunnciator.Rows(l).ItemArray(1)
                                                                                    Dim Audible = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                    Dim timer = CInt(dt_AnnunciatorValue.Rows(k).ItemArray(5)) * 750
                                                                                    ct._InterValTime = timer

                                                                                    '-------------------------Blink --------------------------'
                                                                                    If Blink Then
                                                                                        ct.Blink = True
                                                                                    Else
                                                                                        ct.Blink = False
                                                                                    End If

                                                                                    '---------------------Audible with priority------------------'
                                                                                    Dim _AlarmState = dt_PriorityAnunnciator.Rows(l).ItemArray(2)

                                                                                    If _PriorityVal = GetPriorityName And AlarmState = _AlarmState Then
                                                                                        Dim _AlmPrty As Integer = _PriorityId

                                                                                        If Not _AnnunAlarmstateClass.CheckAlaramList.Contains(_AlmPrty) Then
                                                                                            _AnnunAlarmstateClass.CheckAlaramList.Add(_AlmPrty)
                                                                                            _AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                        Else
                                                                                            '_AnnunAlarmstateClass.AddFunction(Tag, _PriorityVal, _StartTime, AlarmState)
                                                                                        End If
                                                                                    End If
                                                                                Next
                                                                            End If
                                                                        Next
                                                                    End If
                                                                End If



                                                            End If
                                                        End If
                                                    Next
                                                'End If
                                            Next
                                            'End If
                                        End If
                                End If


                            End If
                        Next
                    End If
                End If
            Next
            'End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Data_Updated()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub



    Public Sub GenerateAnnunciator()
        Dim MpageVal As New MainPage
        Dim con = MpageVal.GetConString()
        Dim myConnection As New SqlConnection(con)
        Try
            dt_AnnunciatorValue.Clear()
            myConnection.Open()
            Using dad As New SqlDataAdapter("Select * from tblAnnunciator ", myConnection)
                dad.Fill(dt_AnnunciatorValue)
            End Using
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GenerateAnnunciator()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
        Try
            MpageVal.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GenerateAnnunciatorPriority()
        Dim MpageVal As New MainPage
        Dim con = MpageVal.GetConString()
        Dim myConnection As New SqlConnection(con)
        Try
            dt_PriorityAnunnciator.Clear()
            myConnection.Open()
            'Using dad As New SqlDataAdapter("Select * from tblAnnunciator_Priority ", myConnection)
            Using dad As New SqlDataAdapter("SELECT ta.Annunciator_PriorityId,tp.PriorityName,ta.AlarmState,ta.AudioDeviceName,ta.Audible1Enabled,ta.Audible2Enabled,ta.Audible1Path,ta.Audible2Path,tp.PriorityId From tblAnnunciator_Priority as Ta join tblPriority as tp on tp.PriorityId= ta.PriorityName", myConnection)
                dad.Fill(dt_PriorityAnunnciator)
            End Using

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GenerateAnnunciatorPriority()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
        Try
            Try
                MpageVal.Dispose()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Data get from Sql database
    ''' </summary>
    ''' <param name="query"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Fun_RetrieveDBData(ByVal query As String) As DataTable

        Dim myConnection As New SqlConnection
        Dim sqlcmd As New SqlCommand
        'Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            myConnection = New SqlConnection(Q_Constr)
            myConnection.Open()
            Using dad As New SqlDataAdapter(query, myConnection)
                dad.Fill(dt)
            End Using
            'da.SelectCommand = New SqlCommand(query, myConnection)
            'sqlcmd = New SqlCommand(query, myConnection)
            ' da.Fill(dt)

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Fun_RetrieveDBData()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            Return Nothing
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
        Return dt
    End Function

    Friend Function Fun_AnnunciatorRetrieveDBData(ByVal query As List(Of String)) As DataTable

        Dim myConnection As New SqlConnection
        Dim sqlcmd As New SqlCommand
        ' Dim dr As SqlDataReader
        Dim dt As New DataTable

        Try
            myConnection = New SqlConnection(Q_Constr)
            myConnection.Open()
            Using dad As New SqlDataAdapter("Select TagId,TagNo,Parameter,StartTime,RtnEventId,NormalEventId,AckEventId, DiffTimeInSecsRtn , DiffTimeinSecsNormal,DiffTimeInSecsAck,Priority,PriorityName  from vueAlarm Where  AlarmId In(Select max(AlarmId) from vueAlarm Where TagId In (Select TagId from tbltag Where TagNo In ('" & String.Join("','", query) & "'))  Group by TagNo,Parameter ) Order By TagId,Parameter ", myConnection)
                dad.Fill(dt)
            End Using
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Fun_AnnunciatorRetrieveDBData()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            Return Nothing
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
        Return dt
    End Function

    Private Sub DBDataForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Dim df As DBDataForm
        df = MainPage.DBDataFormClass(CInt(sender.tag))
        df.Visible = False
    End Sub


    Private Sub DBDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GenerateAnnunciator()
        GenerateAnnunciatorPriority()
        Control.CheckForIllegalCrossThreadCalls = True '// allow cross threading.
    End Sub


End Class