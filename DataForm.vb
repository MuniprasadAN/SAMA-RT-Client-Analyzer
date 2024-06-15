' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-13-2014
' ***********************************************************************
' <copyright file="DataForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Security.Permissions
Imports System.IO
Imports OPCDA.NET
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Globalization
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading

Public Class DataForm
    Friend WithEvents opcsr As OpcServer

    Friend _readWriteGroup As SyncIOGroup
    Friend _asyncRefrGroup As RefreshGroup

   
    Private Dt_dataMain As New DataTable
    Private Ds_Main As New DataSet
    Private Dr_Main As dataRow

    Private _StoragePath As String = ""
    Private _Remote_Push_Path As string=""
    Private Myname As String
    Private path As String = ""
    Private GV_CtrlE_Time As Boolean
    Private TagNamename As String = ""


    Friend Watcher As New FileSystemWatcher()
    Friend rF_Time As Integer = 0
    Friend bln_Store As Boolean
    Friend isMultiview As Boolean
    Friend GVClassF_Time As Boolean
    Public Shared ResetTag As Boolean
    'Public tagdictionary As New Dictionary(Of String, Integer)
    Dim thread_Timer As  Threading.Timer

    ''' <summary>
    ''' Initializes a new instance of the <see cref="DataForm" /> class.	
    ''' </summary>
    ''' <param name="srv">The SRV.</param>
    ''' <param name="rfTime">The rf time.</param>
    ''' <param name="blnST">The BLN_ st.</param>
    ''' <param name="servermode">The servermode.</param>
    ''' <param name="name">The name.</param>
    ''' <remarks></remarks>
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Public Sub New(ByVal srv As OpcServer, ByVal rfTime As Integer, ByVal blnST As Boolean, ByVal servermode As Boolean, ByVal name As String, ByVal _isMultiview As Boolean)
        ' This call is required by the Windows Form Designer.
        Try

            GVClassF_Time = False
            GV_CtrlE_Time = False
            isMultiview = _isMultiview

            Myname = name
            InitializeComponent()

            Dt_dataMain = New DataTable
            Ds_Main = New DataSet
            Call DTColumn() 'Assign column to DataTable
            bln_Store = blnST




            If servermode Then

                opcsr = srv
                rF_Time = rfTime
                '_readWriteGroup = New SyncIOGroup(opcsr)
                _asyncRefrGroup = New RefreshGroup(opcsr, AddressOf DataChangeHandler, rF_Time)

                DGVChannelsValue.Rows.Add()
                Me.Visible = False
            Else
                'Client Mode 'File Watcher
                Watcher = New FileSystemWatcher
                Watcher.Filter = "*.rdt" & Myname
                Watcher.NotifyFilter = NotifyFilters.LastWrite
                Watcher.Path = MainPage.Server_PullDataPath
                ' Add event handlers. 

                AddHandler Watcher.Changed, AddressOf OnChanged
                ' Begin watching.
                Watcher.EnableRaisingEvents = True
                DGVChannelsValue.Rows.Add()
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataForm-New()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub DTColumn()
        Dt_dataMain.Columns.Add(New DataColumn("Date_Time", Type.GetType("System.String")))
        Dt_dataMain.Columns.Add(New DataColumn("Value", Type.GetType("System.String")))
        Dt_dataMain.Columns.Add(New DataColumn("Tags", Type.GetType("System.String")))
    End Sub
    ' Define the event handlers. 
    ''' <summary>
    ''' Raise the events when the file is modified
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OnChanged()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' call Fun_RetrieveOPCDataFromFile() and OpcDataUpDateds() procedure
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TT()
        Try

            Dim dt As DataTable = Fun_RetrieveOPCDataFromFile(path) 'Data Retrive from File

            Dt_dataMain.Rows.Clear() 'Clear Row Before Add New Row
            Ds_Main.Tables.Clear()'Clear Table Before Add New Table

             If Not IO.Directory.Exists(MainPage.Storage_Loc & "\History_Data") Then
                Directory.CreateDirectory(MainPage.Storage_Loc & "\History_Data")
            End If
             _StoragePath = MainPage.Storage_Loc & "\History_Data\" & Me.Name

            Ds_Main.Namespace = _StoragePath



            If Not dt Is Nothing Then
                If Not isMultiview Then
                    DGVChannelsValue.Rows(0).Cells(1).Value = dt.Rows(0).Item("Date_Time")
                    DGVChannelsValue.Rows(0).Cells(2).Value =dt.Rows(0).Item ("Value")

                        Dr_Main = Dt_dataMain.NewRow()
                        Dr_Main("Date_Time") = dt.Rows(0).Item("Date_Time")
                        Dr_Main("Value") = dt.Rows(0).Item ("Value")

                        Dt_dataMain.Rows.Add(Dr_Main)

                        Ds_Main.Tables.Add(Dt_dataMain)
                        Ds_Main.Tables(0).TableName = "OPCData"


                    'Store data to .dt File
                    If IO.File.Exists(_StoragePath & ".dt") Then
                        If bln_Store Then
                            ProcFileInsert( dt.Rows(0).Item("Date_Time"),dt.Rows(0).Item ("Value"))
                        End If
                    Else
                        If bln_Store Then
                           Call MyEncryptor(Ds_Main,_StoragePath & ".dt")'Save To History Data Folder
                        End If

                    End If

                Else
                    If Not GVClassF_Time Then
                        GVClassF_Time = True
                        DGVChannelsValue.Columns.Clear()
                        DGVChannelsValue.Columns.Add("Tags", "Tags")
                        DGVChannelsValue.Columns.Add("DateTime", "Date Time")
                        DGVChannelsValue.Columns.Add("Value", "Value")

                     End If
                        DGVChannelsValue.Rows.Clear()
                        For i = 0 To dt.Rows.Count - 1
                            DGVChannelsValue.Rows.Add()

                            DGVChannelsValue.Rows(i).Cells(0).Value = dt.Rows(i).Item("Tags")
                            DGVChannelsValue.Rows(i).Cells(1).Value = dt.Rows(i).Item("Date_Time")
                            DGVChannelsValue.Rows(i).Cells(2).Value = dt.Rows(i).Item("Value")

                                Dr_Main = Dt_dataMain.NewRow()

                                Dr_Main("Tags") = dt.Rows(i).Item("Tags")
                                Dr_Main("Date_Time") = dt.Rows(i).Item("Date_Time")
                                Dr_Main("Value") = dt.Rows(i).Item("Value")

                                Dt_dataMain.Rows.Add(Dr_Main)
                        Next
                        Ds_Main.Tables.Add(Dt_dataMain)
                        Ds_Main.Tables(0).TableName = "OPCDataMultiView"
                        If bln_Store Then
                           Call MyEncryptor(Ds_Main,_StoragePath & ".dt")'Save To History Data Folder
                        End If
                   
                End If
                OpcDataUpDateds(dt.Rows(0).Item("Value"), (dt.Rows(0).Item("Date_Time")), Myname) 'Update Value to controls       
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataForm TT()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub
    ''' <summary>
    ''' Function retrive the data from file
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Fun_RetrieveOPCDataFromFile(ByVal path As String) As DataTable
        Dim ds As New DataSet
        Dim dtData As New DataTable
        Try
            ds = New DataSet
            'ds.ReadXml(path)
            MyDecryptor(ds, path)
            If ds.Tables.Count > 0 Then
                dtData = ds.Tables(0)
                ds.Tables(0).TableName = "OPCData"
                Return dtData
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Fun_RetrieveDBDataFromFile()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            Return Nothing
        End Try
        Return dtData
    End Function
    ''' <summary>
    ''' Event Firing When Opc Data arrives
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub DataChangeHandler(ByVal sender As Object, ByVal e As DataChangeEventArgs)
        If InvokeRequired Then
              BeginInvoke(New DataChangeEventHandler(AddressOf DataChangeHandler), New Object() {sender, e})
            Return
        End If

      

        Dim _OpcTime As DateTime
        Dim _OpcValue As Object = Nothing
        Dim _ArrOPCValue As Object = ""
        Dim _Temp_dbl As Double
        Dim _OpcItem As ItemDef
        Dim _hndClient As Int32

        Try
            Dt_dataMain.Rows.Clear() 'Clear Row Before Add New Row
            Ds_Main.Tables.Clear() 'Clear Table Before Add New Table


            For n As Integer = 0 To e.sts.Length - 1
                _hndClient = e.sts(n).HandleClient
                _OpcValue = e.sts(n).DataValue
                _OpcTime = DateTime.FromFileTime(e.sts(n).TimeStamp)

                _OpcItem = _asyncRefrGroup.FindClientHandle(_hndClient)
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
                        If Myname.StartsWith("reset") Then
                            If MainPage.tagdictionary.ContainsKey(TagNamename) Then
                                Dim num As Integer = MainPage.tagdictionary.Item(TagNamename)
                                _ArrOPCValue = _OpcValue - num
                            Else
                                _ArrOPCValue = _OpcValue
                            End If
                        Else
                            _ArrOPCValue = _OpcValue
                        End If

                    End If
                    'Check the _ArrOPCValue are Double or not, If true then round the value   
                    If IsNumeric(_ArrOPCValue) Then
                        If Double.TryParse(_ArrOPCValue, _Temp_dbl) Then
                            _ArrOPCValue = Math.Round(_Temp_dbl, 2)
                        End If
                    End If


                    'If ResetTag Then
                    '    If Myname.StartsWith("reset") Then
                    '        If tagdictionary.ContainsKey(TagNamename) Then
                    '            tagdictionary.Item(TagNamename) = _OpcValue
                    '            Console.WriteLine(TagNamename & vbTab & _OpcValue)
                    '        Else
                    '            tagdictionary.Add(TagNamename, _ArrOPCValue)
                    '            Console.WriteLine(TagNamename & vbTab & _ArrOPCValue)
                    '        End If
                    '    End If
                    'End If



                    If Not isMultiview Then
                        DGVChannelsValue.Rows(0).Cells(1).Value = _OpcTime
                        DGVChannelsValue.Rows(0).Cells(2).Value = _ArrOPCValue

                        Dr_Main = Dt_dataMain.NewRow()
                        Dr_Main("Date_Time") = _OpcTime
                        Dr_Main("Value") = _ArrOPCValue

                        Dt_dataMain.Rows.Add(Dr_Main)


                        Ds_Main.Tables.Add(Dt_dataMain)
                        Ds_Main.Tables(0).TableName = "OPCData"

                    Else

                        If Not GVClassF_Time Then
                            GVClassF_Time = True
                            DGVChannelsValue.Columns.Clear()
                            DGVChannelsValue.Columns.Add("Tags", "Tags")
                            DGVChannelsValue.Columns.Add("DateTime", "Date Time")
                            DGVChannelsValue.Columns.Add("Value", "Value")

                            Dim Tags As String = MainPage.OPC_ChannelList_Class.OPC_OPCItems(Me.Tag)
                            Dim OPC_Tags() As String = Tags.Split(",")
                            For k As Integer = 0 To OPC_Tags.Length - 1
                                DGVChannelsValue.Rows.Add()
                                DGVChannelsValue.Rows(k).Cells(0).Value = OPC_Tags(k)
                            Next
                        End If
                        For i = 0 To DGVChannelsValue.Rows.Count - 1
                            If DGVChannelsValue.Rows(i).Cells(0).Value = TagNamename Then
                                DGVChannelsValue.Rows(i).Cells(2).Value = _ArrOPCValue
                                DGVChannelsValue.Rows(i).Cells(1).Value = _OpcTime

                                Dr_Main = Dt_dataMain.NewRow()

                                Dr_Main("Tags") = TagNamename
                                Dr_Main("Date_Time") = _OpcTime
                                Dr_Main("Value") = _ArrOPCValue

                                Dt_dataMain.Rows.Add(Dr_Main)

                            End If
                        Next
                        If n = e.sts.Length - 1 Then
                            Ds_Main.Tables.Add(Dt_dataMain)
                            Ds_Main.Tables(0).TableName = "OPCDataMultiView"
                        End If

                    End If
                End If
            Next




            If bln_Store Then
                If Not IO.Directory.Exists(MainPage.Storage_Loc & "\History_Data") Then
                    Directory.CreateDirectory(MainPage.Storage_Loc & "\History_Data")
                End If
            End If
            if Not IO.Directory.Exists(MainPage.Server_PushDataPath & "\RemoteData") Then
                IO.Directory.CreateDirectory(MainPage.Server_PushDataPath & "\RemoteData")
            End If
            _StoragePath = MainPage.Storage_Loc & "\History_Data\" & Me.Name
            _Remote_Push_Path=MainPage.Server_PushDataPath & "\RemoteData\" & Myname & ".rdt" & Myname

            Ds_Main.Namespace = _StoragePath



            Call OpcDataUpDateds(_ArrOPCValue, _OpcTime, Me.Name) 'Update Value to controls

            If MainPage.blnOPC_AllowClients Then
                 Call MyEncryptor(Ds_Main,_Remote_Push_Path)'Push to RemoteData Folder
            End If

            If Not isMultiview Then
                'Store data to .dt File
                If IO.File.Exists(_StoragePath & ".dt") Then
                    If bln_Store Then
                        Call ProcFileInsert(_OpcTime, _ArrOPCValue)
                    End If
                Else
                    If bln_Store Then
                        Call MyEncryptor(Ds_Main, _StoragePath & ".dt")
                    End If
                End If
            Else
                 If bln_Store Then
                        Call MyEncryptor(Ds_Main, _StoragePath & ".dt")'Store Multitag value
                    End If 
            End If
            
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataChangeHandler()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub
   
    ''' <summary>
    ''' Procedure to write the OPC values to the .dt file 	
    ''' </summary>
    ''' <param name="_OpcTime">The D time.</param>
    ''' <param name="val">The val.</param>
    ''' <remarks></remarks>
    Public Sub ProcFileInsert(ByVal _OpcTime As String, ByVal val As String)
        Try
            Dim dr_Temp As DataRow
            Dim Dt_Temp= New DataTable
            Dim Ds_Temp = New DataSet

            'Ds.ReadXml(_StoragePath & ".dt")
            MyDecryptor(Ds_Temp, _StoragePath & ".dt")
            If (Ds_Temp.Tables(0).Rows.Count > MainPage.OPC_ChannelList_Class.OPC_LastnnHourHistory(CInt(Me.Tag))) Then
                Ds_Temp.Tables(0).Rows.RemoveAt(0)
            End If
            Ds_Temp.Tables(0).AcceptChanges()
            Dt_Temp = Ds_Temp.Tables(0)

            dr_Temp = Dt_Temp.NewRow()
            dr_Temp("Date_Time") = _OpcTime
            dr_Temp("Value") = val
            Dt_Temp.Rows.Add(dr_Temp)
            Ds_Temp.Tables(0).TableName = "OPCData"
         
            'Ds.WriteXml(_StoragePath & ".dt")
            MyEncryptor(Ds_Temp, _StoragePath & ".dt")
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ProcFileInsert()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes("B499F4BF48242E05548D1E4C8BB26A2E")
    Dim byteIV As Byte() = System.Text.Encoding.UTF8.GetBytes(",%u'm&'CXSy/T7x;4")
    Dim _Mutex As new Mutex
    ''' <summary>
    ''' Write to file with encripted format
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
            'D.WriteXml(sPath)
        Catch ex As Exception
             MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataFormMyEncryptor()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            _Mutex.ReleaseMutex()
           
        End Try
        
    End Sub
    ''' <summary>
    ''' Read the normal data from encripted file 
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
             MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@DataFormMyDecryptor()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            _Mutex.ReleaseMutex()
            
        End Try

    End Sub

    ''' <summary>
    ''' update the Values to  Controls
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="_OpcTime"></param>
    ''' <param name="chName"></param>
    ''' <remarks></remarks>
    Friend Sub OpcDataUpDateds(ByVal val As Object, ByVal _OpcTime As String, ByVal chName As String)
        Try
            For j As Integer = 0 To MainPage.CreatedPages.Count - 1
                Dim pnlObj() As Control
                pnlObj = MainPage.Controls.Find(MainPage.CreatedPages(j), True) 'Get the Panel control
                If pnlObj.Length > 0 Then
                    If Not pnlObj(0) Is Nothing Then

                        For Each Fcontrols In pnlObj(0).Controls 'Get the controls one by one from panel control
                            If (TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then
                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If Fcontrols.AccessibleDescription = chName Then
                                        If IsNumeric(val) Then
                                            Fcontrols.Value = CInt(val)
                                        End If

                                    End If
                                End If
                            End If
                            If (TypeOf Fcontrols Is LabelValue) Then
                                Dim value_lbl As LabelValue
                                value_lbl = Fcontrols

                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                    If value_lbl.AccessibleDescription = chName Then


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

                                    If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Chart_Ctrl.Series(i).YValueMembers) Then
                                        If Chart_Ctrl.Series(i).YValueMembers = chName Then

                                            If Not IsNumeric(val) AndAlso val = "True" Then
                                                val = 1
                                            ElseIf Not IsNumeric(val) AndAlso val = "False" Then
                                                val = 0
                                            Else
                                                If Chart_Ctrl.Series(i).Points.Count >= MainPage.OPC_ChannelList_Class.OPC_HistoryLength(CInt(Me.Tag)) Then
                                                    Chart_Ctrl.Series(i).Points.RemoveAt(0)
                                                End If
                                                Chart_Ctrl.Series(i).Points.AddXY(CDate(_OpcTime).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), val)


                                                'Color Set to TH
                                                If Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then

                                                    For k As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                                                        If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Contains(":") Then
                                                            Dim bt_Val() As String = Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Split(":")
                                                            If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                If CInt(val) >= CInt(bt_Val(0)) And CInt(val) <= CInt(bt_Val(1)) Then
                                                                    Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                                End If
                                                            End If

                                                        Else
                                                            If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Equals(val) Then
                                                                Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                            End If

                                                        End If

                                                    Next
                                                End If

                                            End If

                                            'If Chart_Ctrl.Series(i).Points.Count >= MainPage.OPC_ChannelList_Class.OPC_HistoryLength(CInt(Me.Tag)) Then
                                            '        Chart_Ctrl.Series(i).Points.RemoveAt(0)
                                            'End if
                                            'Chart_Ctrl.Series(i).Points.AddXY(Cdate(_OpcTime).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), 0)
                                        End If
                                    End If
                                Next

                                If Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True" Then
                                    Chart_Ctrl.ChartAreas(0).RecalculateAxesScale()
                                End If
                            End If

                            If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                Dim gvCtrl As DataGridViewCtrl = Fcontrols 'Assign Ctrl
                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(gvCtrl.AccessibleDescription) Then
                                    If gvCtrl.AccessibleDescription = chName Then
                                        If Not isMultiview Then
                                            If gvCtrl.Columns.Count > 0 AndAlso gvCtrl.Columns(0).HeaderText = "Tags" Then
                                                gvCtrl.Columns.Clear()
                                            End If
                                            If Not gvCtrl.Columns.Count > 0 Then 'Add Column to Grid Ctrl at Once
                                                gvCtrl.Columns.Clear()
                                                gvCtrl.Columns.Add("DateTime", "Date Time")
                                                gvCtrl.Columns.Add("Value", "Value")
                                            End If


                                            'Insert Row to Grid Ctrl
                                            If gvCtrl.Rows.Count > 0 Then
                                                gvCtrl.Rows.Insert(0, New String() {_OpcTime, val})
                                                If MainPage.OPC_ChannelList_Class.OPC_HistoryLength.Count > 0 AndAlso gvCtrl.Rows.Count > MainPage.OPC_ChannelList_Class.OPC_HistoryLength(CInt(Me.Tag)) Then
                                                    gvCtrl.Rows.RemoveAt(gvCtrl.Rows.Count - 1)
                                                End If
                                            Else
                                                gvCtrl.Rows.Add(New String() {_OpcTime, val})
                                            End If



                                        Else 'if muliView=True
                                            If gvCtrl.Columns.Count > 0 AndAlso Not gvCtrl.Columns(0).HeaderText = "Tags" Then
                                                gvCtrl.Columns.Clear()
                                            End If
                                            If Not GV_CtrlE_Time Or Not gvCtrl.Columns.Count > 0 Then 'Add Column to Grid Ctrl at Once
                                                GV_CtrlE_Time = True
                                                gvCtrl.Columns.Clear()
                                                gvCtrl.Columns.Add("Tags", "Tags")
                                                gvCtrl.Columns.Add("DateTime", "Date Time")
                                                gvCtrl.Columns.Add("Value", "Value")

                                                For i As Integer = 0 To DGVChannelsValue.Rows.Count - 1
                                                    gvCtrl.Rows.Add()
                                                    gvCtrl.Rows(i).Cells(0).Value = DGVChannelsValue.Rows(i).Cells(0).Value
                                                    gvCtrl.Rows(i).Cells(1).Value = DGVChannelsValue.Rows(i).Cells(1).Value
                                                    gvCtrl.Rows(i).Cells(2).Value = DGVChannelsValue.Rows(i).Cells(2).Value
                                                Next
                                            End If

                                            For i As Integer = 0 To DGVChannelsValue.Rows.Count - 1
                                                gvCtrl.Rows(i).Cells(1).Value = DGVChannelsValue.Rows(i).Cells(1).Value
                                                gvCtrl.Rows(i).Cells(2).Value = DGVChannelsValue.Rows(i).Cells(2).Value
                                            Next

                                        End If


                                        'Color Set to TH
                                        If gvCtrl._ThresholdValue.Count > 0 Then
                                            Dim spltValue() As String
                                            For i As Integer = 0 To gvCtrl._ThresholdValue.Count - 1
                                                spltValue = Nothing
                                                spltValue = gvCtrl._ThresholdValue(i).Split("@")
                                                Select Case spltValue(0)
                                                    Case "Value"
                                                        If spltValue(1).Contains(":") Then
                                                            Dim bt_Val() As String = spltValue(1).Split(":")
                                                            If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) AndAlso IsNumeric(gvCtrl.Rows(0).Cells(1).Value) Then
                                                                If CInt(gvCtrl.Rows(0).Cells(1).Value) >= CInt(bt_Val(0)) And CInt(gvCtrl.Rows(0).Cells(1).Value) <= CInt(bt_Val(1)) Then
                                                                    gvCtrl.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                    gvCtrl.Rows(0).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                    Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                    If fnt(2) = "Bold" Then
                                                                        gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                    ElseIf fnt(2) = "Italic" Then
                                                                        gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                    Else
                                                                        gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                    End If
                                                                End If
                                                            End If

                                                        Else

                                                            If spltValue(1).Contains(val) Then
                                                                gvCtrl.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(gvCtrl._THBackColor(i))
                                                                gvCtrl.Rows(0).DefaultCellStyle.ForeColor = Color.FromArgb(gvCtrl._THForeColor(i))
                                                                Dim fnt = gvCtrl._THFont(i).ToString.Split(",")
                                                                If fnt(2) = "Bold" Then
                                                                    gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Bold)
                                                                ElseIf fnt(2) = "Italic" Then
                                                                    gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Italic)
                                                                Else
                                                                    gvCtrl.Rows(0).DefaultCellStyle.Font = New Font(fnt(0), CSng(fnt(1)), FontStyle.Regular)
                                                                End If
                                                            End If

                                                        End If


                                                End Select
                                            Next
                                        End If
                                        Fcontrols.FirstDisplayedScrollingRowIndex = 0
                                    End If
                                End If
                            End If

                            If (TypeOf Fcontrols Is LevelIndicator) Then
                                Dim LevelIndicator_Ctrl As LevelIndicator = Fcontrols 'Assign Ctrl

                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(LevelIndicator_Ctrl.AccessibleDescription) Then


                                    If LevelIndicator_Ctrl.AccessibleDescription = chName Then

                                        If IsNumeric(val) Then
                                            LevelIndicator_Ctrl.Value = CSng(val)
                                        End If

                                    End If

                                End If

                            End If



                            If (TypeOf Fcontrols Is Valve) Then
                                Dim Valve_Ctl As Valve = Fcontrols 'Assign Ctrl

                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Valve_Ctl.AccessibleDescription) Then


                                    If Valve_Ctl.AccessibleDescription = chName Then

                                        If Valve_Ctl._ThresholdValue.Count > 0 Then

                                            For i As Integer = 0 To Valve_Ctl._ThresholdValue.Count - 1

                                                Select Case Valve_Ctl._THCondition(i)
                                                    Case "="
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) = CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If
                                                        ElseIf Valve_Ctl._ThresholdValue(i).Contains(val) Then

                                                            Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                            Exit For
                                                        Else

                                                            Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                        End If
                                                    Case ">"
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) > CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If

                                                        End If
                                                    Case "<"
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) < CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If

                                                        End If
                                                    Case ">="
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) >= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If

                                                        End If
                                                    Case "<="
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) <= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If

                                                        End If
                                                    Case "<>"
                                                        If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                            If CSng(val) <> CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If

                                                        End If
                                                    Case ">=<="
                                                        Dim bt_Val() As String = Valve_Ctl._ThresholdValue(i).Split(":")
                                                        If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                            If CInt(val) >= CInt(bt_Val(0)) And CInt(val) <= CInt(bt_Val(1)) Then
                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1
                                                            End If
                                                        End If
                                                    Case Else
                                                        ' do the defalut action
                                                End Select
                                            Next
                                        Else
                                            Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1
                                        End If


                                    End If

                                End If


                            End If

                            If (TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor) Then


                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then


                                    If Fcontrols.AccessibleDescription = chName Then

                                        If Fcontrols._ThresholdValue.Count > 0 Then

                                            For i As Integer = 0 To Fcontrols._ThresholdValue.Count - 1

                                                Select Case Fcontrols._THCondition(i)
                                                    Case "="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) = CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                Fcontrols.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If
                                                        ElseIf Fcontrols._ThresholdValue(i).Contains(val) Then
                                                            Dim c As New Circuit_Breaker

                                                            Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                            If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                If Fcontrols._THState(i) = "Open" Then
                                                                    Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                Else
                                                                    Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                End If
                                                            Else
                                                                If Fcontrols._THState(i) = "Open" Then
                                                                    Fcontrols.State = ManualContactor.StateIND.Open
                                                                Else
                                                                    Fcontrols.State = ManualContactor.StateIND.Closed
                                                                End If
                                                            End If
                                                            'Fcontrols.parent.refresh()
                                                            Exit For
                                                        Else

                                                            Fcontrols.LineColor = Fcontrols.D_Color1

                                                        End If
                                                    Case ">"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) > CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If

                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) < CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case ">="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) >= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) <= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<>"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) <> CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case ">=<="
                                                        Dim bt_Val() As String = Fcontrols._ThresholdValue(i).Split(":")
                                                        If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                            If CInt(val) >= CInt(bt_Val(0)) And CInt(val) <= CInt(bt_Val(1)) Then
                                                                Fcontrols.LineColor = Color.FromArgb(Fcontrols._THColor(i))
                                                                If TypeOf Fcontrols Is Circuit_Breaker Then
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = Circuit_Breaker.StateIND.Closed
                                                                    End If
                                                                Else
                                                                    If Fcontrols._THState(i) = "Open" Then
                                                                        Fcontrols.State = ManualContactor.StateIND.Open
                                                                    Else
                                                                        Fcontrols.State = ManualContactor.StateIND.Closed
                                                                    End If
                                                                End If
                                                                'Fcontrols.parent.refresh()
                                                                Exit For
                                                            Else

                                                                Fcontrols.LineColor = Fcontrols.D_Color1
                                                            End If
                                                        End If
                                                    Case Else
                                                        ' do the defalut action
                                                End Select
                                            Next
                                        Else
                                            Fcontrols.LineColor = Fcontrols.D_Color1
                                        End If


                                    End If

                                End If


                            End If

                            If Not (TypeOf Fcontrols Is Button_Control Or TypeOf Fcontrols Is PictureBox Or TypeOf Fcontrols Is Label _
                                     Or TypeOf Fcontrols Is Panel Or TypeOf Fcontrols Is LogViewer _
                                     Or TypeOf Fcontrols Is Circuit_Breaker Or TypeOf Fcontrols Is ManualContactor Or TypeOf Fcontrols Is Valve _
                            Or TypeOf Fcontrols Is LevelIndicator Or TypeOf Fcontrols Is DataGridViewCtrl _
                            Or TypeOf Fcontrols Is Chart Or TypeOf Fcontrols Is LabelValue Or TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then


                                If MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then


                                    If Fcontrols.AccessibleDescription = chName And Not Fcontrols.Tag = "OPCWriter" Then

                                        If Fcontrols._ThresholdValue.Count > 0 Then

                                            For i As Integer = 0 To Fcontrols._ThresholdValue.Count - 1

                                                Select Case Fcontrols._THCondition(i)
                                                    Case "="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(Fcontrols._ThresholdValue(i)) = CSng(val) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If
                                                        ElseIf Fcontrols._ThresholdValue(i).Contains(val) Then

                                                            Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                            Exit For
                                                        Else

                                                            Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                        End If
                                                    Case ">"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) > CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) < CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case ">="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) >= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<="
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) <= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case "<>"
                                                        If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                            If CSng(val) <> CSng(Fcontrols._ThresholdValue(i)) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If

                                                        End If
                                                    Case ">=<="
                                                        Dim bt_Val() As String = Fcontrols._ThresholdValue(i).Split(":")
                                                        If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                            If CInt(val) >= CInt(bt_Val(0)) And CInt(val) <= CInt(bt_Val(1)) Then
                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1
                                                            End If
                                                        End If
                                                    Case Else
                                                        ' do the defalut action
                                                End Select
                                            Next
                                        Else
                                            Fcontrols.Gradient_Color1 = Fcontrols.D_Color1
                                        End If


                                    End If

                                End If





                            End If
                        Next


                    End If
                End If
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC_DataUpdates()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Private _shutreason As String
    Private Sub opcsr_ShutdownRequested(ByVal sender As Object, ByVal e As ShutdownRequestEventArgs) Handles opcsr.ShutdownRequested
        _shutreason = e.shutdownReason
    End Sub


    Private Sub DataForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Dim df As DataForm
        df = MainPage.opcCnfgTags(CInt(sender.tag))
        df.Visible = False
    End Sub

    Private Sub DataForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class