




Imports System.Threading
Imports System.Collections
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Diagnostics
Imports System.Windows.Forms.DataVisualization.Charting

Public Class HDARedundancy

    Private PrimaryOPC As String, SecondaryOPC As String

    Friend StartClientHandle As Integer
    Friend ConfigId As Integer
    Friend blnConnected As Boolean = False, StopConnecting As Boolean = False
    Friend PrimaryClient As New OPCHDA.OPCHDAWcfService, SecondaryClient As New OPCHDA.OPCHDAWcfService
    Friend PrimaryOPCServerName As String, SecondayOPCServerName As String

    Friend PrimaryFailed As Boolean = True
    Friend SecondaryFailed As Boolean = True
    Friend PrimaryTags As New List(Of OPCHDA.Tgs)
    Friend lstChannels As New Dictionary(Of String, List(Of String))
    Friend opctg As New Dictionary(Of String, OPCHDAStorage)
    Friend ChannelControls As New Dictionary(Of String, List(Of ControlDef))

    Friend Utc_Time As Long
    Friend opctags As New List(Of String)
    Friend RT_OPCTags As New Dictionary(Of Integer, RtStorage)
    Friend blnRedundancy As Boolean
    Dim usr As MainPage
    Public Sub New(ByVal Primary_OPC As String, Secondary_OPC As String, bln_Redundancy As Boolean, ByVal usrfrm As MainPage)

        PrimaryOPC = Primary_OPC
        SecondaryOPC = Secondary_OPC

        blnRedundancy = bln_Redundancy
        Insertfilelog(Now & vbTab & PrimaryOPC & vbCrLf & SecondaryOPC)
        usr = usrfrm
    End Sub

    Friend Sub Connect()
        Try

            ' PrimaryClient = Nothing
            'SecondaryClient = Nothing
            Dim ConnectThread As Thread = New Thread(AddressOf ThreadConnect)
            ConnectThread.SetApartmentState(ApartmentState.STA)
            ConnectThread.Start()

        Catch ex As Exception

        End Try
    End Sub

    Shared myThread As Thread
    Shared StopThread As ManualResetEvent = Nothing

    Public Sub RemoveChannel(ByVal Channelname As String)

        Try
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
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AddChannel(ByVal ChannelName As String, ByVal ChannelTags() As String, HistoryInMins As Integer, IntervalInSecs As Integer, UpdateType As Char, RElativeTime As DateTime)
        Try
            lstChannels.Add(ChannelName, ChannelTags.ToList())
            For Each tggg As String In ChannelTags
                AddNewTag(tggg, ChannelName, HistoryInMins, IntervalInSecs, UpdateType, RElativeTime)
            Next
        Catch ex As Exception

        End Try


    End Sub

    Public Function GetAllTags() As List(Of String)
        Try

            Dim lstTags As New List(Of String)
            If Not PrimaryFailed Then

                Dim ls() As OPCHDA.Tgs = PrimaryClient.GetOPCTags()

                For Each k In ls
                    lstTags.Add(k.TgName)
                Next
            Else

                If Not SecondaryFailed Then
                    Dim ls() As OPCHDA.Tgs = SecondaryClient.GetOPCTags()
                    For Each k In ls
                        lstTags.Add(k.TgName)
                    Next
                End If

            End If


            Return lstTags

        Catch ex As Exception

        End Try
    End Function
    Public Sub AddNewTag(ByVal TagName As String, ChannelName As String, HistoryInMins As Integer, IntervalInSecs As Integer, UpdateType As Char, RElativeTime As DateTime)
        Try
            If opctg.ContainsKey(TagName.ToString() + ChannelName.ToString) Then
                Dim rtstor As OPCHDAStorage = Nothing
                opctg.TryGetValue(TagName.ToString() + ChannelName.ToString, rtstor)

                opctg.Item(TagName.ToString() + ChannelName.ToString).ChannelName.Add(ChannelName)
            Else
                opctg.Add(TagName.ToString() + ChannelName.ToString, New OPCHDAStorage(HistoryInMins, ChannelName, IntervalInSecs, UpdateType, TagName, RElativeTime))
            End If


            If Not opctags.Contains(TagName) Then
                opctags.Add(TagName)
            End If

            GetHistoryValues(ChannelName, TagName, HistoryInMins, IntervalInSecs)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RemoveTag(ByVal TagName As String, ChannelName As String)
        Try


            If opctg.ContainsKey(TagName.ToString() + ChannelName.ToString) Then
                Dim rtstor As OPCHDAStorage = Nothing
                opctg.TryGetValue(TagName.ToString() + ChannelName.ToString, rtstor)
                If Not rtstor Is Nothing Then

                    opctg(TagName.ToString() + ChannelName.ToString).ChannelName.Remove(ChannelName)
                    If opctg(TagName.ToString() + ChannelName.ToString).ChannelName.Count = 0 Then
                        rtstor.opcdt.Rows.Clear()
                        rtstor = Nothing
                        opctg.Remove(TagName.ToString() + ChannelName.ToString)
                        opctags.Remove(TagName)
                    End If

                End If



            End If
        Catch ex As Exception

        End Try
    End Sub






    Public Sub ThreadConnect()


        If StopConnecting Then
            Exit Sub
        End If

        Try
            Try
                If PrimaryFailed Then

                    Insertfilelog(Now & "  Trying to Connect primary")
                    PrimaryClient = New OPCHDA.OPCHDAWcfService()

                    PrimaryClient.Url = PrimaryClient.Url.Replace("192.168.1.36:89", PrimaryOPC)
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
                    SecondaryClient = New OPCHDA.OPCHDAWcfService()
                    SecondaryClient.Url = SecondaryClient.Url.Replace("192.168.1.36:89", SecondaryOPC)
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
                myThread.SetApartmentState(ApartmentState.STA)

                myThread.Start()




                Dim myThread1 As Thread = New Thread(AddressOf CheckOPCHDAStatus)
                myThread1.Name = "Item Simulation"
                myThread1.SetApartmentState(ApartmentState.STA)

                myThread1.Start()
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
        Try

            blnConnected = False
            If StopConnecting Then
                Exit Sub
            End If

            Insertfilelog(Now & vbTab & " Trying to REcoonnect")



            Thread.Sleep(5000)
            Connect()

        Catch ex As Exception

        End Try
    End Sub

    Friend Sub DisConnect()
        Insertfilelog("Disconnecting from OPCServers")

        Try

            StopConnecting = True

        Catch ex As Exception

        End Try


        Try
            PrimaryClient.Dispose()
        Catch ex As Exception

        End Try


        If blnRedundancy Then
            Try
                SecondaryClient.Dispose()
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

    Private Sub CheckOPCHDAStatus()


        Insertfilelog(Now & vbTab & " Refresh")
        Dim blnPrimaryLog As Boolean = False, blnSecondaryLog As Boolean = False
        While blnConnected



            Try
                If (Not PrimaryFailed) Then
                    Try
                        Dim blncon As Boolean
                        PrimaryClient.GetOPCStatus(blncon, True)
                        If blncon Then
                            If Not blnPrimaryLog Then
                                Insertfilelog(Now & vbTab & "@Primary OPC Server is Connected")
                                blnPrimaryLog = True
                            End If

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
                        SecondaryClient.GetOPCStatus(blncon, True)
                        If blncon Then
                            If Not blnSecondaryLog Then
                                Insertfilelog(Now & vbTab & "@Secondary OPC Server is Connected")
                                blnSecondaryLog = True
                            End If
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
            Thread.Sleep(5000)      ' ms wait time

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

    Public Function GetRawValues(ByVal TagName() As String, FRomTime As DateTime, ToTime As DateTime) As String

        Dim outlst As String = ""
        Try

            If (Not PrimaryFailed) Then
                Try

                    outlst = PrimaryClient.ReadRawValues(TagName, FRomTime, True, ToTime, True, -1, True)

                Catch ex As Exception
                    Insertfilelog(Now & vbTab & " Primary server Failed : " & ex.Message)
                    PrimaryFailed = True
                End Try
            End If

            If blnRedundancy AndAlso PrimaryFailed AndAlso (Not SecondaryFailed) Then
                Try

                    outlst = SecondaryClient.ReadRawValues(TagName, FRomTime, True, ToTime, True, -1, True)


                Catch ex As Exception
                    Insertfilelog(Now & vbTab & "@Secondary server Failed : " & ex.Message)
                    SecondaryFailed = True
                End Try


            End If

        Catch timeout_exception As Net.Sockets.SocketException
            Insertfilelog(Now & "  Socket Exception" & timeout_exception.Message)



        Catch ex As Exception

            Insertfilelog(Now & " Thread " & ex.Message)


        End Try


        Return outlst
    End Function


    Public Function GetHistoryValuesUsingDateRange(ByVal TagName As String, ByVal HistoryInSecs As Int64, FRomTime As DateTime, ToTime As DateTime) As List(Of OPCHDAData)

        Dim outlst As New List(Of OPCHDAData)
        Try

            If (Not PrimaryFailed) Then
                Try


                    For j As Integer = 0 To ((ToTime - FRomTime).TotalSeconds / HistoryInSecs) - 1
                        Dim opcdt As String = PrimaryClient.ReadRawValuesIncludeBounds(TagName, FRomTime, True, FRomTime.AddSeconds(HistoryInSecs), True, -1, True)


                        Dim lst As New List(Of OPCHDAData)
                        lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)

                        If lst.Count = 0 Then
                        Else
                            lst(0).D = CDate(lst(0).D.ToString("yyyy/MMM/dd HH:mm:ss.fff"))
                            outlst.Add(lst(0))
                        End If

                        FRomTime = DateAdd(DateInterval.Second, HistoryInSecs, FRomTime)
                    Next



                Catch ex As Exception
                    Insertfilelog(Now & vbTab & " Primary server Failed : " & ex.Message)
                    PrimaryFailed = True
                End Try
            End If

            If blnRedundancy AndAlso PrimaryFailed AndAlso (Not SecondaryFailed) Then
                Try
                    For j As Integer = 0 To ((ToTime - FRomTime).TotalSeconds / HistoryInSecs) - 1
                        Dim opcdt As String = SecondaryClient.ReadRawValuesIncludeBounds(TagName, FRomTime, True, DateAdd(DateInterval.Second, HistoryInSecs, FRomTime), True, -1, True)

                        Dim lst As New List(Of OPCHDAData)
                        lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                        If lst.Count = 0 Then



                        Else
                            outlst.Add(lst(0))

                        End If
                        FRomTime = DateAdd(DateInterval.Second, HistoryInSecs, FRomTime)
                    Next




                Catch ex As Exception
                    Insertfilelog(Now & vbTab & "@Secondary server Failed : " & ex.Message)
                    SecondaryFailed = True
                End Try


            End If

        Catch timeout_exception As Net.Sockets.SocketException
            Insertfilelog(Now & "  Socket Exception" & timeout_exception.Message)



        Catch ex As Exception

            Insertfilelog(Now & " Thread " & ex.Message)


        End Try


        Return outlst
    End Function
    Public Sub GetHistoryValues(ByVal ChannelName As String, ByVal TagName As String, ByVal HistoryInMins As Int16, ByVal HistoryInSecs As Int64)
        Try
            Dim kk As OPCHDAStorage = Nothing
            Dim CurKey As String = TagName.ToString + ChannelName.ToString
            If opctg.ContainsKey(CurKey) Then
                kk = opctg(CurKey)
            Else
                Exit Sub
            End If

            If kk.UpdateType <> "A" Then
                Exit Sub
            End If

            'kk.LastTime = DateAdd(DateInterval.Second, -kk.IntervalInSecs, kk.LastTime)

            If (Not PrimaryFailed) Then
                Try

                    For j As Integer = 0 To (kk.HistoryInMins * 60 / HistoryInSecs) - 1

                        If (Now - kk.LastTime).TotalSeconds < (kk.IntervalInSecs + 2) Then
                            Exit For
                        End If

                        If DateAdd(DateInterval.Second, kk.IntervalInSecs + 2, kk.LastTime) >= Now Then
                            Exit For
                        End If
                        Dim opcdt As String = PrimaryClient.ReadRawValuesIncludeBounds(kk.TagName, kk.LastTime, True, kk.LastTime.AddSeconds(kk.IntervalInSecs), True, -1, True)

                        Insertfilelog(kk.LastTime & vbTab & kk.LastTime.AddSeconds(kk.IntervalInSecs) & vbTab & (Now - kk.LastTime).TotalSeconds & vbTab & kk.IntervalInSecs)


                        Dim lst As New List(Of OPCHDAData)
                        lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                        If lst.Count = 0 Then
                        Else
                            ' kk.LastTime = DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime)
                            kk.LastTime = lst(0).D
                            AssignValuesToControls(lst(0), kk.ChannelName(0), CurKey)
                        End If


                    Next


                    kk.blnFirstTime = True
                Catch ex As Exception
                    Insertfilelog(Now & vbTab & " Primary server Failed : " & ex.Message)
                    PrimaryFailed = True
                End Try
            End If

            If blnRedundancy AndAlso PrimaryFailed AndAlso (Not SecondaryFailed) Then
                Try
                    For j As Integer = 0 To (kk.HistoryInMins * 60 / HistoryInSecs) - 1

                        If (Now - kk.LastTime).TotalSeconds < (kk.IntervalInSecs + 2) Then
                            Exit For
                        End If
                        If DateAdd(DateInterval.Second, kk.IntervalInSecs + 2, kk.LastTime) >= Now Then
                            Exit For
                        End If


                        Dim opcdt As String = SecondaryClient.ReadRawValuesIncludeBounds(kk.TagName, kk.LastTime, True, DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime), True, -1, True)


                        Insertfilelog(kk.LastTime & vbTab & kk.LastTime.AddSeconds(kk.IntervalInSecs) & vbTab & (Now - kk.LastTime).TotalSeconds & vbTab & kk.IntervalInSecs)


                        Dim lst As New List(Of OPCHDAData)
                        lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                        If lst.Count = 0 Then

                        Else
                            '  kk.LastTime = DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime)
                            kk.LastTime = lst(0).D
                            AssignValuesToControls(lst(0), kk.ChannelName(0), CurKey)
                        End If

                    Next

                    'For Each opc_dt As OPCHDAData In JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                    '    If opctg.ContainsKey(opc_dt.T) Then

                    '        AssignValuesToControls(opc_dt, kk.ChannelName(0))
                    '        If Utc_Time < opc_dt.U Then
                    '            Utc_Time = opc_dt.U
                    '        End If
                    '    End If
                    'Next



                Catch ex As Exception
                    Insertfilelog(Now & vbTab & "@Secondary server Failed : " & ex.Message)
                    SecondaryFailed = True
                End Try


            End If

        Catch timeout_exception As Net.Sockets.SocketException
            Insertfilelog(Now & "  Socket Exception" & timeout_exception.Message)



        Catch ex As Exception

            Insertfilelog(Now & " Thread " & ex.Message)


        End Try

    End Sub

    Private Sub RefreshThread1()


        Insertfilelog(Now & vbTab & " Refresh")
        Dim blnPrimaryLog As Boolean = False, blnSecondaryLog As Boolean = False
        While blnConnected

            Try
                For Each kk As OPCHDAStorage In opctg.Values
                    If kk.UpdateType <> "A" Then
                        Continue For
                    End If

                    If (Now - kk.LastTime).TotalSeconds < (kk.IntervalInSecs + 2) Then
                        Debug.Print(Now & vbTab & kk.LastTime & vbTab & (Now - kk.LastTime).TotalSeconds & vbTab & kk.IntervalInSecs)
                        Continue For
                    End If

                    If Not kk.blnFirstTime Then
                        GetHistoryValues(kk.ChannelName(0), kk.TagName, kk.HistoryInMins, kk.IntervalInSecs)
                        Continue For
                    End If

                    Try
                        If (Not PrimaryFailed) Then
                            Try

                                Insertfilelog(kk.LastTime & vbTab & kk.LastTime.AddSeconds(kk.IntervalInSecs) & vbTab & (Now - kk.LastTime).TotalSeconds & vbTab & kk.IntervalInSecs)
                                Dim opcdt As String = PrimaryClient.ReadRawValuesIncludeBounds(kk.TagName, kk.LastTime, True, DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime), True, -1, True)
                                Insertfilelog(opcdt)
                                Dim lst As New List(Of OPCHDAData)
                                lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                                If lst.Count = 0 Then
                                Else


                                    'kk.LastTime = DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime)
                                    'Insertfilelog(kk.TagName & vbTab & " Last Time : " & kk.LastTime)
                                    kk.LastTime = lst(0).D
                                    AssignValuesToControls(lst(0), kk.ChannelName(0), kk.TagName.ToString + kk.ChannelName(0).ToString)
                                End If

                            Catch ex As Exception
                                Insertfilelog(Now & vbTab & " Primary server Failed @ Getting Tags: " & ex.Message)
                                PrimaryFailed = True
                            End Try
                        End If

                        If blnRedundancy AndAlso PrimaryFailed AndAlso (Not SecondaryFailed) Then
                            Try
                                'If kk.LastTime < Now.AddMinutes(-kk.HistoryInMins) Then
                                '    GetHistoryValues(kk.ChannelName(0), kk.TagName, kk.HistoryInMins, kk.IntervalInSecs)
                                'End If
                                Dim opcdt As String = SecondaryClient.ReadRawValuesIncludeBounds(kk.TagName, kk.LastTime, True, DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime), True, -1, True)

                                Dim lst As New List(Of OPCHDAData)
                                lst = JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(opcdt)
                                If lst.Count = 0 Then

                                Else
                                    ' kk.LastTime = DateAdd(DateInterval.Second, kk.IntervalInSecs, kk.LastTime)
                                    kk.LastTime = lst(0).D
                                    AssignValuesToControls(lst(0), kk.ChannelName(0), kk.TagName.ToString + kk.ChannelName(0).ToString)
                                End If




                            Catch ex As Exception
                                Insertfilelog(Now & vbTab & "@Secondary server Failed @ Getting Tags : " & ex.Message)
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


                Next
            Catch ex As Exception
                Insertfilelog(Now & vbTab & ex.Message & vbTab & " @Checking Tag wise ")
            End Try



            If StopConnecting Then
                Exit Sub
            End If
            If SecondaryFailed And PrimaryFailed Then
                Exit While
            End If
            Thread.Sleep(4000)      ' ms wait time

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


    Private Sub AssignValuesToControls(ByVal keyName As OPCHDAData, ByVal ChannelName As String, ByVal CurKey As String)
        Try
            If opctg.ContainsKey(CurKey) Then
                Dim dr() As DataRow = opctg(CurKey).opcdt.Select("TimeStamp='" & keyName.D & "'")
                If dr.Length >= 1 Then
                    Exit Sub
                End If



                Dim dtrw As DataRow = opctg(CurKey).opcdt.NewRow
                dtrw("TimeStamp") = keyName.D
                dtrw("Value") = keyName.V
                dtrw("Quality") = keyName.Q
                opctg(CurKey).opcdt.Rows.InsertAt(dtrw, 0)

                If opctg(CurKey).opcdt.Rows.Count > (opctg(CurKey).HistoryInMins * 60) / opctg(CurKey).IntervalInSecs Then
                    opctg(CurKey).opcdt.Rows.RemoveAt(opctg(CurKey).opcdt.Rows.Count - 1)
                End If


                For Each Channel_Name In opctg(CurKey).ChannelName
                     OpcDataUpDateds1(opctg(CurKey).opcdt, Channel_Name, -1, keyName.T)
                Next




            End If
        Catch ex As Exception
            Insertfilelog(Now & vbTab & ex.Message & " @ AssignValuesToControls")
        End Try





    End Sub
    Private Delegate Sub UpdateOPCDA(ByVal opcdtt As DataTable, ByVal chName As String, ByVal pointlen As Integer, ByVal CurTag As String)

    Friend Sub OpcDataUpDateds1(ByVal opcdtt As DataTable, ByVal chName As String, ByVal pointlen As Integer, ByVal CurTag As String)
        Try

            If usr.InvokeRequired Then
                usr.Invoke(New UpdateOPCDA(AddressOf OpcDataUpDateds1), opcdtt, chName, pointlen, CurTag)

            Else
                Dim chindx As Integer = MainPage.OPCHDAChannelsList.OPC_Channel_Name.IndexOf(chName)
                ' Debug.Print(MainPage.CreatedPages.Count)
                For j As Integer = 0 To MainPage.CreatedPages.Count - 1
                    Dim pnlObj() As Control
                    pnlObj = usr.Controls.Find(MainPage.CreatedPages(j), True) 'Get the Panel control
                    If pnlObj.Length > 0 Then
                        If Not pnlObj(0) Is Nothing Then

                            For Each Fcontrols In pnlObj(0).Controls 'Get the controls one by one from panel control

                                If (TypeOf Fcontrols Is Chart) Then
                                    Dim Chart_Ctrl As ChartControl = Fcontrols 'Assign Ctrl
                                    For i As Integer = 0 To Chart_Ctrl.Series.Count - 1

                                        If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(Chart_Ctrl.Series(i).YValueMembers) Then
                                            If Chart_Ctrl.Series(i).YValueMembers = chName Then
                                                Dim val As Object = opcdtt.Rows(0)("Value")
                                                If Not IsNumeric(val) AndAlso val = "True" Then
                                                    val = 1
                                                ElseIf Not IsNumeric(val) AndAlso opcdtt.Rows(0)("Value") = "False" Then
                                                    val = 0
                                                Else

                                                    If Chart_Ctrl.Series(i).Points.Count >= MainPage.OPCDAChannelsList.OPC_HistoryLength(chindx) Then
                                                        Chart_Ctrl.Series(i).Points.RemoveAt(0)
                                                    End If
                                                    Chart_Ctrl.Series(i).Points.AddXY(CDate(opcdtt.Rows(0)("TimeStamp")).ToString("hh:mm:ss tt", CultureInfo.CurrentCulture), val)


                                                    'Color Set to TH
                                                    If Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count > 0 Then

                                                        For k As Integer = 0 To Chart_Ctrl.Series_TH_Data(i).ThresholdValue.Count - 1
                                                            If Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Contains(":") Then
                                                                Dim bt_Val() As String = Chart_Ctrl.Series_TH_Data(i).ThresholdValue(k).Split(":")
                                                                If IsNumeric(bt_Val(0)) AndAlso IsNumeric(bt_Val(1)) Then
                                                                    If CInt(opcdtt.Rows(0)("Value")) >= CInt(bt_Val(0)) And CInt(opcdtt.Rows(0)("Value")) <= CInt(bt_Val(1)) Then
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

                                                'If Chart_Ctrl.Series(i).Points.Count >= usr.OPC_ChannelList_Class.OPC_HistoryLength(CInt(Me.Tag)) Then
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
                                    If MainPage.OPCHDAChannelsList.OPC_Channel_Name.Contains(gvCtrl.AccessibleDescription) Then
                                        If gvCtrl.AccessibleDescription = chName Then
                                            If MainPage.OPCHDAChannelsList.OPC_OPCItems(chindx).Split(",").Count = 1 Then
                                                gvCtrl.DataSource = opcdtt

                                            Else 'if muliView=True
                                                Dim dt As New DataTable
                                                Dim lstofDT As New List(Of DataTable)
                                                Dim tmpopcda As HDARedundancy = MainPage.OPCHDAServersCollection.Item(MainPage.OPCHDAChannelsList.OPC_ServerName(chindx))
                                                For Each tg As String In Split(MainPage.OPCHDAChannelsList.OPC_OPCItems(chindx), ",")
                                                    If tmpopcda.opctg.ContainsKey(tg.ToString() + MainPage.OPCHDAChannelsList.OPC_Channel_Name(chindx).ToString()) Then
                                                        lstofDT.Add(tmpopcda.opctg(tg.ToString() + MainPage.OPCHDAChannelsList.OPC_Channel_Name(chindx).ToString()).opcdt)

                                                    End If
                                                Next

                                                If MainPage.OPCHDAChannelsList.OPC_XAxis(chindx).ToString() = "DateTime" Then
                                                    dt = MultiDttoOne(lstofDT, MainPage.OPCHDAChannelsList.OPC_XAxis(chindx).ToString())
                                                    gvCtrl.Columns.Clear()
                                                    gvCtrl.DataSource = dt
                                                ElseIf MainPage.OPCHDAChannelsList.OPC_XAxis(chindx).ToString() = "Tags" Then
                                                    dt = MultiDttoOne(lstofDT, MainPage.OPCHDAChannelsList.OPC_XAxis(chindx).ToString())
                                                    gvCtrl.DataSource = dt
                                                End If
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
    Private Function MultiDttoOne(ByVal lstdt As List(Of DataTable), ByVal xaxis As String) As DataTable


        Dim outdt As New DataTable
        Try
            If xaxis = "Tags" Then
                outdt.Columns.Clear()
                outdt.Columns.Add("DateTime", Type.GetType("System.DateTime"))


                For Each dtt As DataTable In lstdt

                    outdt.Columns.Add(dtt.TableName)
                    For Each dr As DataRow In dtt.Rows
                        Dim dr1() As DataRow = outdt.Select("DateTime='" & dr("TimeStamp") & "'")

                        If dr1.Length = 0 Then
                            Dim dr2 As DataRow = outdt.NewRow
                            dr2("DateTime") = dr("TimeStamp")
                            dr2(dtt.TableName) = dr("Value")
                            outdt.Rows.Add(dr2)
                        Else
                            dr1(0)(dtt.TableName) = dr("Value")
                            outdt.AcceptChanges()
                        End If
                    Next
                    outdt.AcceptChanges()
                Next


                ' DGDataform.DataSource = outdt

            ElseIf xaxis = "DateTime" Then

                outdt.Columns.Clear()
                outdt.Columns.Add("TagName", Type.GetType("System.String"))

                For Each dtt As DataTable In lstdt

                    Dim dr1() As DataRow = outdt.Select("TagName='" & dtt.TableName & "'")
                    If dr1.Length = 0 Then
                        Dim dr2 As DataRow = outdt.NewRow
                        dr2("TagName") = dtt.TableName
                        outdt.Rows.Add(dr2)
                    End If
                    outdt.AcceptChanges()
                    Dim Curdr As DataRow = outdt.Select("TagName='" & dtt.TableName & "'")(0)
                    For Each dr As DataRow In dtt.Select("", "TimeStamp desc")

                        If outdt.Columns.Contains(dr("TimeStamp")) Then
                            Curdr(dr("TimeStamp")) = dr("Value")
                        Else
                            outdt.Columns.Add(dr("TimeStamp"))
                            Curdr(dr("TimeStamp")) = dr("Value")
                            outdt.AcceptChanges()
                        End If
                        outdt.AcceptChanges()
                    Next

                Next
                ' DGDataform.Columns.Clear()
                ' DGDataform.DataSource = outdt
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@HDARedundancy_MultiDttoOne")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            'MainPage._errLog.Add(ex.Message)
        End Try

        Return outdt
    End Function
End Class


Public Class OPCHDAStorage
    Public Property opcdt As New DataTable
    Public ChannelName As New List(Of String)
    Public IntervalInSecs As ULong = 1
    Public HistoryInMins As Integer = 60
    Public UpdateType As Char = "A"
    Public TagName As String = ""
    Public RelativeTime As DateTime
    Public LastTime As DateTime = CDate("1900-01-01 12:00:00.000")
    Public blnFirstTime As Boolean = False
    Public Sub New(ByVal History_InMins As Integer, ByVal Channel_name As String, ByVal Interval_InSecs As ULong, Update_Type As Char, ByVal Tag_Name As String, Relative_Time As DateTime)

        Dim dc As New DataColumn("TimeStamp", Type.GetType("System.DateTime"))
        opcdt.Columns.Add(dc)
        dc = New DataColumn("Value", Type.GetType("System.Object"))
        opcdt.Columns.Add(dc)
        dc = New DataColumn("Quality", Type.GetType("System.String"))
        opcdt.Columns.Add(dc)
        opcdt.TableName = Tag_Name

        TagName = Tag_Name
        HistoryInMins = History_InMins
        IntervalInSecs = Interval_InSecs
        RelativeTime = Relative_Time
        UpdateType = Update_Type


        Select Case True
            Case HistoryInMins < 60
                If Now.Hour <= RelativeTime.Hour Then
                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddDays(-1).AddMinutes(-HistoryInMins)

                Else
                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddMinutes(-HistoryInMins)
                End If



            Case HistoryInMins < 60 * 24

                If Now.Hour <= RelativeTime.Hour Then
                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddDays(-1).AddMinutes(-HistoryInMins)

                Else
                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddMinutes(-HistoryInMins)
                End If


            Case Else
                If Now.Hour <= RelativeTime.Hour Then
                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddDays(-1).AddMinutes(-HistoryInMins)
                Else

                    LastTime = New DateTime(Now.Year, Now.Month, Now.Day, RelativeTime.Hour, RelativeTime.Minute, 0)
                    LastTime = LastTime.AddMinutes(-HistoryInMins)
                End If

        End Select

        Dim tmptime As DateTime = LastTime
        While True

            tmptime = tmptime.AddSeconds(IntervalInSecs)
            If tmptime >= Now Then
                LastTime = tmptime
                Exit While
            End If

        End While

        LastTime = LastTime.AddMinutes(-HistoryInMins)


        ChannelName.Add(Channel_name)
    End Sub
End Class

Public Class OPCHDAData
    Public Property V As String
    ' Public Property d As DateTime = "1970-01-01"
    Public Property D As DateTime
    ' Public Property Quality As String = ""
    Public Property Q As String = ""
    Public Property T As String = ""
End Class