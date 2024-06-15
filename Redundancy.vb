




Imports System.Threading
Imports System.Collections
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Globalization
Imports System.Diagnostics

Public Class Redundancy

    Friend PrimaryOPC As String, SecondaryOPC As String

    Friend StartClientHandle As Integer
    Friend ConfigId As Integer
    Friend blnConnected As Boolean = False, StopConnecting As Boolean = False
    'Friend PrimaryClient As New OPCDA1.OPCDAWcfService, SecondaryClient As New OPCDA1.OPCDAWcfService
    Friend PrimaryClient As New OPCDA1.OpcDaWcfSerClient, SecondaryClient As New OPCDA1.OpcDaWcfSerClient
    Friend PrimaryOPCServerName As String, SecondayOPCServerName As String

    Friend PrimaryFailed As Boolean = True
    Friend SecondaryFailed As Boolean = True
    Friend PrimaryTags As New List(Of OPCDA1.Tgs)
    Friend lstChannels As New Dictionary(Of String, List(Of String))
    Friend opctg As New Dictionary(Of String, RtStorage)
    Friend ChannelControls As New Dictionary(Of String, List(Of ControlDef))

    Friend Utc_Time As Long
    Friend opctags As New List(Of String)
    Friend RT_OPCTags As New Dictionary(Of Integer, RtStorage)
    Friend blnRedundancy As Boolean
    Friend Refresh_interval As Integer
    Dim usr As MainPage
    Public Sub New(ByVal Primary_OPC As String, Secondary_OPC As String, bln_Redundancy As Boolean, ByVal usrfrm As MainPage, ByVal refreshinterval As Integer)

        PrimaryOPC = Primary_OPC
        SecondaryOPC = Secondary_OPC

        blnRedundancy = bln_Redundancy
        Insertfilelog(Now & vbTab & PrimaryOPC & vbCrLf & SecondaryOPC)
        usr = usrfrm
        Refresh_interval = refreshinterval
    End Sub


    Friend Sub Connect()

        ' PrimaryClient = Nothing
        'SecondaryClient = Nothing
        Dim ConnectThread As Thread = New Thread(AddressOf ThreadConnect)
        ConnectThread.ApartmentState = ApartmentState.STA
        ConnectThread.Start()

    End Sub

    Shared myThread As Thread
    Shared StopThread As ManualResetEvent = Nothing

    Public Sub RemoveChannel(ByVal Channelname As String)
        If lstChannels.ContainsKey(Channelname) Then
            Dim rtstor As New List(Of String)
            lstChannels.TryGetValue(Channelname, rtstor)
            If Not rtstor Is Nothing Then

                For Each tggg In rtstor
                    RemoveTag(tggg, Channelname)
                Next

            End If
            If ChannelControls.ContainsKey(Channelname) Then
                ChannelControls.Remove(Channelname)
            End If
            lstChannels.Remove(Channelname)
        End If
    End Sub

    Public Sub AddChannel(ByVal ChannelName As String, ByVal ChannelTags() As String, HistLength As Integer)
        lstChannels.Add(ChannelName, ChannelTags.ToList())
        For Each tggg As String In ChannelTags
            AddNewTag(tggg, HistLength, ChannelName)
        Next
    End Sub

    Public Function GetAllTags() As List(Of String)
        Dim lstTags As New List(Of String)
        If Not PrimaryFailed Then

            Dim ls() As OPCDA1.Tgs = PrimaryClient.GetOPCTags()

            For Each k In ls
                lstTags.Add(k.TgName)
            Next
        Else

            If Not SecondaryFailed Then
                Dim ls() As OPCDA1.Tgs = SecondaryClient.GetOPCTags()
                For Each k In ls
                    lstTags.Add(k.TgName)
                Next
            End If

        End If


        Return lstTags
    End Function
    Public Sub AddNewTag(ByVal TagName As String, HistLength As Integer, ChannelName As String)
        If opctg.ContainsKey(TagName) Then
            Dim rtstor As RtStorage = Nothing
            opctg.TryGetValue(TagName, rtstor)
            If Not rtstor Is Nothing Then
                If rtstor.HistoryLength < HistLength Then
                    opctg.Item(TagName).HistoryLength = HistLength
                End If
            End If
            opctg.Item(TagName).ChannelName.Add(ChannelName)
        Else
            opctg.Add(TagName, New RtStorage(HistLength, ChannelName))
        End If


        If Not opctags.Contains(TagName) Then
            opctags.Add(TagName)
        End If

    End Sub

    Public Sub RemoveTag(ByVal TagName As String, ChannelName As String)

        If opctg.ContainsKey(TagName) Then
            Dim rtstor As RtStorage = Nothing
            opctg.TryGetValue(TagName, rtstor)
            If Not rtstor Is Nothing Then

                opctg(TagName).ChannelName.Remove(ChannelName)
                If opctg(TagName).ChannelName.Count = 0 Then
                    rtstor.opcdt.Rows.Clear()
                    rtstor = Nothing
                    opctg.Remove(TagName)
                    opctags.Remove(TagName)
                End If

            End If



        End If

    End Sub

    Public Sub AddControls(ByVal ChannelName As String, ByRef cntrl As String, PageName As String)
        If ChannelControls.ContainsKey(ChannelName) Then
            Dim lst As List(Of ControlDef) = Nothing
            ChannelControls.TryGetValue(ChannelName, lst)
            If Not lst Is Nothing Then
                lst.Add(New ControlDef(cntrl, PageName))
                ChannelControls.Item(ChannelName) = lst
            Else
                lst.Add(New ControlDef(cntrl, PageName))
                ChannelControls.Add(ChannelName, lst)
            End If

        Else
            Dim lst As List(Of ControlDef) = Nothing
            lst.Add(New ControlDef(cntrl, PageName))
            ChannelControls.Add(ChannelName, lst)
        End If


    End Sub


    Public Sub RemoveControl(ByVal ChannelName As String, ByRef cntrl As String, PageName As String)
        Dim lst As List(Of ControlDef) = Nothing
        lst.Add(New ControlDef(cntrl, PageName))
        If ChannelControls.ContainsValue(lst) Then
            Dim rtstor As List(Of ControlDef) = Nothing
            ChannelControls.TryGetValue(ChannelName, rtstor)
            If Not rtstor Is Nothing Then

                ChannelControls(ChannelName).Remove(rtstor(0))
                If ChannelControls(ChannelName).Count = 0 Then
                    ChannelControls.Remove(ChannelName)
                End If


            End If



        End If

    End Sub

    Public Sub ThreadConnect()


        If StopConnecting Then
            Exit Sub
        End If

        Try
            Try
                If PrimaryFailed Then

                    Insertfilelog(Now & "  Trying to Connect primary")
                    PrimaryClient = New OPCDA1.OpcDaWcfSerClient()

                    PrimaryClient.Endpoint.Address = New System.ServiceModel.EndpointAddress(PrimaryClient.Endpoint.Address.Uri.ToString().Replace("127.0.0.1:32150", PrimaryOPC.ToString()))
                    Insertfilelog(Now & "  Primary Server Connected")

                    PrimaryFailed = False

                End If

            Catch ex As Exception
                Insertfilelog(Now & vbTab & " Primary Connection Failed " & vbTab & ex.Message)
                PrimaryFailed = True
            End Try
            Insertfilelog(SecondaryFailed)

            Try
                If blnRedundancy AndAlso SecondaryFailed Then


                    Insertfilelog(Now & "  Trying to Connect Secondary")
                    SecondaryClient = New OPCDA1.OpcDaWcfSerClient()
                    SecondaryClient.Endpoint.Address = New ServiceModel.EndpointAddress(PrimaryClient.Endpoint.Address.Uri.ToString().Replace("127.0.0.1:32150", SecondaryOPC.ToString()))
                    Insertfilelog(Now & "  Secondary Server Connected")
                    SecondaryFailed = False
                End If



            Catch ex As Exception
                Insertfilelog(Now & vbTab & " Secondary Connection Failed " & vbTab & ex.Message)
                SecondaryFailed = True
            End Try


            If (PrimaryFailed) And (SecondaryFailed) Then
                If StopConnecting Then
                    Exit Sub
                End If
                Reconnect()

            Else
                blnConnected = True
                myThread = New Thread(AddressOf RefreshThread1)
                myThread.Name = "Item Simulation"
                myThread.ApartmentState = ApartmentState.STA

                myThread.Start()
            End If




        Catch ex As Exception
            Insertfilelog(Now & vbTab & " Connection Failed " & vbTab & ex.Message)
            InsertStatusLog(Now & vbTab & " Connection Failed " & vbTab & ex.Message)
            ' UpdateBadValues()
            '  Thread.Sleep(Reconnect_Delay * 1000)
            blnConnected = False

            If StopConnecting Then
                Exit Sub
            End If
            Reconnect()
        End Try


    End Sub
    Friend Sub Reconnect()

        blnConnected = False
        If StopConnecting Then
            Exit Sub
        End If

        Insertfilelog(Now & vbTab & " Trying to REcoonnect")



        Thread.Sleep(5000)
        Connect()
    End Sub

    Friend Sub DisConnect()
        Insertfilelog("Disconnecting from OPCServers")

        Try

            StopConnecting = True

        Catch ex As Exception

        End Try


        Try
            PrimaryClient.Close()
        Catch ex As Exception

        End Try


        If blnRedundancy Then
            Try
                SecondaryClient.Close()
            Catch ex As Exception

            End Try
        End If



    End Sub

    Private Sub Insertfilelog(ByVal msg As String)

        Try
            System.IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\" & Now.ToString("MMMddyyyy") & ".txt", msg & vbCrLf)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub InsertStatusLog(ByVal msg As String)

        Try
            System.IO.File.WriteAllText(My.Application.Info.DirectoryPath & "\" & ConfigId & "_Status.txt", msg & vbCrLf)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub RefreshThread1()


        Insertfilelog(Now & vbTab & " Refresh")
        Dim blnPrimaryLog As Boolean = False, blnSecondaryLog As Boolean = False
        While blnConnected



            Try
                If (Not PrimaryFailed) Then
                    Try
                        Dim blncon As Boolean
                        blncon = PrimaryClient.GetOPCStatus()
                        If blncon Then
                            If Not blnPrimaryLog Then
                                Insertfilelog(Now & vbTab & "@Primary OPC Server is Connected")
                                blnPrimaryLog = True
                            End If
                            Dim opcdt As String = PrimaryClient.GetOPCValues(opctags.ToArray, Utc_Time)
                            Dim lst As New List(Of OPCData)
                            For Each opc_dt As OPCData In JsonConvert.DeserializeObject(Of List(Of OPCData))(opcdt)
                                If opctg.ContainsKey(opc_dt.T) Then
                                    ' Dim rtstor As RtStorage = Nothing
                                    ' opctg.TryGetValue(opc_dt.T, rtstor)
                                    AssignValuesToControls(opc_dt)
                                    If Utc_Time < opc_dt.U Then
                                        Utc_Time = opc_dt.U
                                    End If
                                End If
                            Next
                        Else
                            Insertfilelog(Now & vbTab & "@Primary OPC Server Failed")
                            PrimaryFailed = True
                        End If



                    Catch ex As Exception
                        Insertfilelog(Now & vbTab & " Primary server Failed : " & ex.Message)
                        PrimaryFailed = True
                    End Try
                End If

                If blnRedundancy AndAlso PrimaryFailed AndAlso (Not SecondaryFailed) Then
                    Try
                        Dim blncon As Boolean
                        blncon = SecondaryClient.GetOPCStatus()
                        If blncon Then
                            If Not blnSecondaryLog Then
                                Insertfilelog(Now & vbTab & "@Secondary OPC Server is Connected")
                                blnSecondaryLog = True
                            End If
                            Dim opcdt As String = SecondaryClient.GetOPCValues(opctags.ToArray, Utc_Time)
                            Dim lst As New List(Of OPCData)
                            For Each opc_dt As OPCData In JsonConvert.DeserializeObject(Of List(Of OPCData))(opcdt)
                                If opctg.ContainsKey(opc_dt.T) Then
                                    'Dim rtstor As RtStorage = Nothing
                                    'opctg.TryGetValue(opc_dt.T, rtstor)
                                    AssignValuesToControls(opc_dt)
                                    If Utc_Time < opc_dt.U Then
                                        Utc_Time = opc_dt.U
                                    End If
                                End If

                            Next
                        Else
                            Insertfilelog(Now & vbTab & "Secondary OPC Server Failed")
                            SecondaryFailed = True
                        End If

                    Catch ex As Exception
                        Insertfilelog(Now & vbTab & "@Secondary server Failed : " & ex.Message)
                        SecondaryFailed = True
                    End Try


                End If

            Catch timeout_exception As Net.Sockets.SocketException
                Insertfilelog(Now & "  Socket Exception" & timeout_exception.Message)


                Exit While

            Catch ex As Exception

                Insertfilelog(Now & " Thread " & ex.Message)
                Exit While

            End Try



            If StopConnecting Then
                Exit Sub
            End If
            If SecondaryFailed And PrimaryFailed Then
                Exit While
            End If
            Thread.Sleep(Refresh_interval)      ' ms wait time

        End While


        If StopConnecting Then
            Exit Sub
        Else
            blnConnected = False
            Insertfilelog(Now & vbTab & " Trying to REcoonnect")
            InsertStatusLog(Now & vbTab & " Trying to REcoonnect")
            Connect()
        End If


    End Sub


    Private Sub AssignValuesToControls(ByVal keyName As OPCData)
        Try
            If opctg.ContainsKey(keyName.T) Then

                Dim dtrw As DataRow = opctg(keyName.T).opcdt.NewRow
                dtrw("TimeStamp") = DateTime.FromFileTime(keyName.U)
                dtrw("Value") = keyName.V
                dtrw("Quality") = keyName.Q
                opctg(keyName.T).opcdt.Rows.InsertAt(dtrw, 0)

                If opctg(keyName.T).opcdt.Rows.Count > opctg(keyName.T).HistoryLength Then
                    opctg(keyName.T).opcdt.Rows.RemoveAt(opctg(keyName.T).HistoryLength)
                End If

                For Each Channel_Name In opctg(keyName.T).ChannelName

                    OpcDataUpDateds1(opctg(keyName.T).opcdt, Channel_Name, opctg(keyName.T).HistoryLength, keyName.T)
                Next




            End If
        Catch ex As Exception
            Insertfilelog(ex.Message)
        End Try





    End Sub
    Private Delegate Sub UpdateOPCDA(ByVal opcdtt As DataTable, ByVal chName As String, ByVal pointlen As Integer, ByVal CurTag As String)

    Friend Sub OpcDataUpDateds1(ByVal opcdtt As DataTable, ByVal chName As String, ByVal pointlen As Integer, ByVal CurTag As String)
        Try

            If usr.InvokeRequired Then
                usr.Invoke(New UpdateOPCDA(AddressOf OpcDataUpDateds1), opcdtt, chName, pointlen, CurTag)

            Else
                Dim chindx As Integer = MainPage.OPCDAChannelsList.OPC_Channel_Name.IndexOf(chName)
                Debug.Print(MainPage.CreatedPages.Count)
                For j As Integer = 0 To MainPage.CreatedPages.Count - 1
                    Dim pnlObj() As Control
                    pnlObj = usr.Controls.Find(MainPage.CreatedPages(j), True) 'Get the Panel control
                    If pnlObj.Length > 0 Then
                        If Not pnlObj(0) Is Nothing Then

                            For Each Fcontrols In pnlObj(0).Controls 'Get the controls one by one from panel control
                                If (TypeOf Fcontrols Is AnalyzerMeter.AGauge) Then
                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                        If Fcontrols.AccessibleDescription = chName Then
                                            If IsNumeric(opcdtt.Rows(0)("Value")) Then
                                                Fcontrols.Value = CInt(opcdtt.Rows(0)("Value"))
                                            End If

                                        End If
                                    End If
                                End If
                                If (TypeOf Fcontrols Is LabelValue) Then
                                    Dim value_lbl As LabelValue
                                    value_lbl = Fcontrols

                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then
                                        If value_lbl.AccessibleDescription = chName Then


                                            If value_lbl._ThresholdValue.Count > 0 Then
                                                Dim spltValue() As String
                                                For i As Integer = 0 To value_lbl._ThresholdValue.Count - 1
                                                    spltValue = Nothing
                                                    spltValue = value_lbl._ThresholdValue(i).Split("@")
                                                    Select Case spltValue(0)
                                                        Case "="
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(spltValue(1)) = CInt(opcdtt.Rows(0)("Value")) Then

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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If


                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            ElseIf spltValue(1).Contains(opcdtt.Rows(0)("Value")) Then
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
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                End If
                                                                Exit For
                                                            Else
                                                                value_lbl.Blink = False
                                                                value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                value_lbl.BackColor = value_lbl.Default_BackColor
                                                                value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                            End If
                                                        Case ">"
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) > CInt(spltValue(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            End If
                                                        Case "<"
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) < CInt(spltValue(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            End If
                                                        Case ">="
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) >= CInt(spltValue(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_

                                                                End If
                                                            End If
                                                        Case "<="
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) <= CInt(spltValue(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            End If
                                                        Case "<>"
                                                            If IsNumeric(spltValue(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) <> CInt(spltValue(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            End If
                                                        Case ">=<="
                                                            Dim bt_Val() As String = spltValue(1).Split(":")
                                                            If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
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
                                                                        value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    End If
                                                                    Exit For
                                                                Else
                                                                    value_lbl.Blink = False
                                                                    value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                                                    value_lbl.BackColor = value_lbl.Default_BackColor
                                                                    value_lbl.ForeColor = value_lbl.DefaultForeColors_
                                                                End If
                                                            End If
                                                        Case Else
                                                            ' do the defalut action
                                                    End Select
                                                Next
                                            Else
                                                value_lbl.Text = opcdtt.Rows(0)("Value") & " " & value_lbl.UnitsValue
                                            End If
                                        End If
                                    End If
                                End If
                                If (TypeOf Fcontrols Is Chart) Then
                                    Dim Chart_Ctrl As ChartControl = Fcontrols 'Assign Ctrl
                                    'For i As Integer = 0 To Chart_Ctrl.Series.Count - 1
                                    If Chart_Ctrl.Series.IndexOf(CurTag) <> -1 Then

                                        If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Chart_Ctrl.Series(0).YValueMembers) Then
                                            If Chart_Ctrl.Series(CurTag).YValueMembers = chName Then
                                                Dim val As Object = opcdtt.Rows(0)("Value")
                                                If Not IsNumeric(val) AndAlso val = "True" Then
                                                    val = 1
                                                ElseIf Not IsNumeric(val) AndAlso opcdtt.Rows(0)("Value") = "False" Then
                                                    val = 0
                                                Else

                                                    If Chart_Ctrl.Series(CurTag).Points.Count >= MainPage.OPCDAChannelsList.OPC_HistoryLength(chindx) Then
                                                        Chart_Ctrl.Series(CurTag).Points.RemoveAt(0)
                                                    End If
                                                    Chart_Ctrl.Series(CurTag).Points.AddXY(CDate(opcdtt.Rows(0)("TimeStamp")).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), val)


                                                    'Color Set to TH
                                                    For Each daa In Chart_Ctrl.Series_TH_Data
                                                        If daa.TagName = CurTag Then
                                                            If daa.ThresholdValue.Count > 0 Then

                                                                For k As Integer = 0 To daa.ThresholdValue.Count - 1
                                                                    If daa.ThresholdValue(k).Contains(":") Then
                                                                        Dim bt_Val() As String = daa.ThresholdValue(k).Split(":")
                                                                        If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                            If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
                                                                                Chart_Ctrl.Series(CurTag).Points(Chart_Ctrl.Series(CurTag).Points.Count - 1).Color = Color.FromArgb(daa.THPointsColor(k))
                                                                            End If
                                                                        End If

                                                                    Else
                                                                        If daa.ThresholdValue(k).Equals(val) Then
                                                                            Chart_Ctrl.Series(CurTag).Points(Chart_Ctrl.Series(CurTag).Points.Count - 1).Color = Color.FromArgb(daa.THPointsColor(k))
                                                                        End If

                                                                    End If

                                                                Next
                                                            End If
                                                        End If
                                                    Next



                                                    'If Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then

                                                    '    For k As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                                                    '        If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Contains(":") Then
                                                    '            Dim bt_Val() As String = Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Split(":")
                                                    '            If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                    '                If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
                                                    '                    Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                    '                End If
                                                    '            End If

                                                    '        Else
                                                    '            If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Equals(val) Then
                                                    '                Chart_Ctrl.Series(i).Points(Chart_Ctrl.Series(i).Points.Count - 1).Color = Color.FromArgb(Chart_Ctrl.Series_TH_Data(i).THPointsColor(k))
                                                    '            End If

                                                    '        End If

                                                    '    Next
                                                    'End If

                                                End If

                                                'If Chart_Ctrl.Series(i).Points.Count >= usr.OPC_ChannelList_Class.OPC_HistoryLength(CInt(Me.Tag)) Then
                                                '        Chart_Ctrl.Series(i).Points.RemoveAt(0)
                                                'End if
                                                'Chart_Ctrl.Series(i).Points.AddXY(Cdate(_OpcTime).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), 0)
                                            End If
                                        End If
                                        'Next

                                        If Chart_Ctrl.ChartAreas(0).AxisY.Tag = "True" Then
                                            Chart_Ctrl.ChartAreas(0).RecalculateAxesScale()
                                        End If
                                    End If
                                End If
                                If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                    Dim gvCtrl As DataGridViewCtrl = Fcontrols 'Assign Ctrl
                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(gvCtrl.AccessibleDescription) Then
                                        If gvCtrl.AccessibleDescription = chName Then
                                            If Not MainPage.OPCDAChannelsList.OPC_Multiview(chindx) Then
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
                                                    gvCtrl.Rows.Insert(0, New String() {opcdtt.Rows(0)("TimeStamp"), opcdtt.Rows(0)("Value")})
                                                    If MainPage.OPCDAChannelsList.OPC_HistoryLength.Count > 0 AndAlso gvCtrl.Rows.Count > MainPage.OPCDAChannelsList.OPC_HistoryLength(chindx) Then
                                                        gvCtrl.Rows.RemoveAt(pointlen)
                                                    End If
                                                Else
                                                    gvCtrl.Rows.Add(New String() {opcdtt.Rows(0)("TimeStamp"), opcdtt.Rows(0)("Value")})
                                                End If



                                            Else 'if muliView=True
                                                If gvCtrl.Columns.GetColumnCount(DataGridViewElementStates.None) = 0 Then
                                                    gvCtrl.Columns.Add("Tags", "Tags")
                                                    gvCtrl.Columns.Add("DateTime", "Date Time")
                                                    gvCtrl.Columns.Add("Value", "Value")
                                                End If
                                                Dim blnTagfound As Boolean, idx As Integer
                                                For Each dtrw As DataGridViewRow In gvCtrl.Rows
                                                    If dtrw.Cells("Tags").Value = CurTag Then
                                                        blnTagfound = True
                                                        idx = dtrw.Index
                                                    End If
                                                Next
                                                If blnTagfound Then

                                                    gvCtrl.Rows(idx).Cells(2).Value = opcdtt.Rows(0)("Value")
                                                    gvCtrl.Rows(idx).Cells(1).Value = opcdtt.Rows(0)("TimeStamp")

                                                Else
                                                    Dim i As Integer = gvCtrl.Rows.Add()
                                                    gvCtrl.Rows(i).Cells(0).Value = CurTag
                                                    gvCtrl.Rows(i).Cells(2).Value = opcdtt.Rows(0)("Value")
                                                    gvCtrl.Rows(i).Cells(1).Value = opcdtt.Rows(0)("TimeStamp")
                                                End If
                                                'If gvCtrl.Columns.Count > 0 AndAlso Not gvCtrl.Columns(0).HeaderText = "Tags" Then
                                                '    gvCtrl.Columns.Clear()
                                                'End If
                                                'If Not GV_CtrlE_Time Or Not gvCtrl.Columns.Count > 0 Then 'Add Column to Grid Ctrl at Once
                                                '    GV_CtrlE_Time = True
                                                '    gvCtrl.Columns.Clear()
                                                '    gvCtrl.Columns.Add("Tags", "Tags")
                                                '    gvCtrl.Columns.Add("DateTime", "Date Time")
                                                '    gvCtrl.Columns.Add("Value", "Value")

                                                '    For i As Integer = 0 To DGVChannelsValue.Rows.Count - 1
                                                '        gvCtrl.Rows.Add()
                                                '        gvCtrl.Rows(i).Cells(0).Value = DGVChannelsValue.Rows(i).Cells(0).Value
                                                '        gvCtrl.Rows(i).Cells(1).Value = DGVChannelsValue.Rows(i).Cells(1).Value
                                                '        gvCtrl.Rows(i).Cells(2).Value = DGVChannelsValue.Rows(i).Cells(2).Value
                                                '    Next
                                                'End If

                                                'For i As Integer = 0 To DGVChannelsValue.Rows.Count - 1
                                                '    gvCtrl.Rows(i).Cells(1).Value = DGVChannelsValue.Rows(i).Cells(1).Value
                                                '    gvCtrl.Rows(i).Cells(2).Value = DGVChannelsValue.Rows(i).Cells(2).Value
                                                'Next

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

                                                                If spltValue(1).Contains(opcdtt.Rows(0)("Value")) Then
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

                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(LevelIndicator_Ctrl.AccessibleDescription) Then


                                        If LevelIndicator_Ctrl.AccessibleDescription = chName Then

                                            If IsNumeric(opcdtt.Rows(0)("Value")) Then
                                                LevelIndicator_Ctrl.Value = CSng(opcdtt.Rows(0)("Value"))
                                            End If

                                        End If

                                    End If

                                End If



                                If (TypeOf Fcontrols Is Valve) Then
                                    Dim Valve_Ctl As Valve = Fcontrols 'Assign Ctrl

                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Valve_Ctl.AccessibleDescription) Then


                                        If Valve_Ctl.AccessibleDescription = chName Then

                                            If Valve_Ctl._ThresholdValue.Count > 0 Then

                                                For i As Integer = 0 To Valve_Ctl._ThresholdValue.Count - 1

                                                    Select Case Valve_Ctl._THCondition(i)
                                                        Case "="
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) = CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If
                                                            ElseIf Valve_Ctl._ThresholdValue(i).Contains(opcdtt.Rows(0)("Value")) Then

                                                                Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                Exit For
                                                            Else

                                                                Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                            End If
                                                        Case ">"
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) > CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If

                                                            End If
                                                        Case "<"
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) < CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If

                                                            End If
                                                        Case ">="
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) >= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If

                                                            End If
                                                        Case "<="
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) <= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If

                                                            End If
                                                        Case "<>"
                                                            If IsNumeric(Valve_Ctl._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) <> CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Valve_Ctl.Gradient_Color1 = Color.FromArgb(Valve_Ctl._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Valve_Ctl.Gradient_Color1 = Valve_Ctl.D_Color1

                                                                End If

                                                            End If
                                                        Case ">=<="
                                                            Dim bt_Val() As String = Valve_Ctl._ThresholdValue(i).Split(":")
                                                            If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
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


                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then


                                        If Fcontrols.AccessibleDescription = chName Then

                                            If Fcontrols._ThresholdValue.Count > 0 Then

                                                For i As Integer = 0 To Fcontrols._ThresholdValue.Count - 1

                                                    Select Case Fcontrols._THCondition(i)
                                                        Case "="
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) = CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                            ElseIf Fcontrols._ThresholdValue(i).Contains(opcdtt.Rows(0)("Value")) Then
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
                                                                If CSng(opcdtt.Rows(0)("Value")) > CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                                If CSng(opcdtt.Rows(0)("Value")) < CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                                If CSng(opcdtt.Rows(0)("Value")) >= CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                                If CSng(opcdtt.Rows(0)("Value")) <= CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                                If CSng(opcdtt.Rows(0)("Value")) <> CSng(Fcontrols._ThresholdValue(i)) Then

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
                                                                If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
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


                                    If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Fcontrols.AccessibleDescription) Then


                                        If Fcontrols.AccessibleDescription = chName And Not Fcontrols.Tag = "OPCWriter" Then

                                            If Fcontrols._ThresholdValue.Count > 0 Then

                                                For i As Integer = 0 To Fcontrols._ThresholdValue.Count - 1

                                                    Select Case Fcontrols._THCondition(i)
                                                        Case "="
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(Fcontrols._ThresholdValue(i)) = CSng(opcdtt.Rows(0)("Value")) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If
                                                            ElseIf Fcontrols._ThresholdValue(i).Contains(opcdtt.Rows(0)("Value")) Then

                                                                Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                Exit For
                                                            Else

                                                                Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                            End If
                                                        Case ">"
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) > CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If

                                                            End If
                                                        Case "<"
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) < CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If

                                                            End If
                                                        Case ">="
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) >= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If

                                                            End If
                                                        Case "<="
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) <= CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If

                                                            End If
                                                        Case "<>"
                                                            If IsNumeric(Fcontrols._ThresholdValue(i)) Then
                                                                If CSng(opcdtt.Rows(0)("Value")) <> CSng(Fcontrols._ThresholdValue(i)) Then

                                                                    Fcontrols.Gradient_Color1 = Color.FromArgb(Fcontrols._THColor(i))

                                                                    Exit For
                                                                Else

                                                                    Fcontrols.Gradient_Color1 = Fcontrols.D_Color1

                                                                End If

                                                            End If
                                                        Case ">=<="
                                                            Dim bt_Val() As String = Fcontrols._ThresholdValue(i).Split(":")
                                                            If bt_Val.Length = 2 AndAlso IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
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
            End If


        Catch ex As Exception
            usr._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Redundancy OPC_DataUpdates()")
            usr.MainErrorPV.SetError(usr.lblAlert, "Error !!!")
        End Try

    End Sub
End Class
Public Class OPCData
    Public Property V As Object
    ' Public Property d As DateTime = "1970-01-01"
    Public Property U As Long
    ' Public Property Quality As String = ""
    Public Property Q As Integer = 0
    Public Property T As String = ""
End Class

Public Class RtStorage
    Public Property opcdt As New DataTable
    Public Property HistoryLength As Integer = 1
    Public ChannelName As New List(Of String)
    Public Sub New(ByVal History_length As Integer, ByVal Channel_name As String)
        Dim dc As New DataColumn("TimeStamp", Type.GetType("System.DateTime"))
        opcdt.Columns.Add(dc)
        dc = New DataColumn("Value", Type.GetType("System.Object"))
        opcdt.Columns.Add(dc)
        dc = New DataColumn("Quality", Type.GetType("System.String"))
        opcdt.Columns.Add(dc)

        HistoryLength = History_length
        ChannelName.Add(Channel_name)
    End Sub
End Class
Public Class ControlDef

    Public Property ControlName As String = ""
    Public Property PageName As String = ""
    Public Sub New(ByVal Control_Name As String, ByRef Page_Name As String)

        ControlName = Control_Name
        PageName = Page_Name
    End Sub
End Class