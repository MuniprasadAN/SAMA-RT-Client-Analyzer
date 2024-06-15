Imports OPC
Imports OPCDA.NET
Public Class OpcChaneelListForm
    Private AL_ChList As New ArrayList
    Dim Itemdata As ItemDef

    Private Sub btnChnlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlAdd.Click
        Try
            Dim i As Integer = 0
            If GVChannelsAdd.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(3).Value) Then
                    i = GVChannelsAdd.Rows.Add()
                    GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                    GVChannelsAdd.Rows(i).Cells(5).Value = 2
                    GVChannelsAdd.Rows(i).Cells(6).Value = 10
                    GVChannelsAdd.Rows(i).Cells(7).Value = 0
                Else
                    MsgBox("Empty Fields not Allowed !!!")
                    Exit Sub
                End If
            Else
                i = GVChannelsAdd.Rows.Add()
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(5).Value = 2
                GVChannelsAdd.Rows(i).Cells(6).Value = 10
                GVChannelsAdd.Rows(i).Cells(7).Value = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GVChannelsAdd_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GVChannelsAdd.CellMouseClick
        If GVChannelsAdd.CurrentCell.ColumnIndex = 2 Then
            If Not MainPage.Server_Flag Then
                MsgBox("Sorry !!! Cannot Configure the Client !!!", MsgBoxStyle.Critical, "Warning!!!")
            ElseIf MainPage.OPC_ServeNames Is Nothing Then
                MsgBox("Sorry !!! Server Not Available !!!", MsgBoxStyle.Critical, "Warning!!!")
            Else
                OpcServerlistForm.ShowDialog()
            End If
        End If
    End Sub
    Private Sub Apply_Channel()
        Try
            Dim rst As Int32
            MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Clear()
            MainPage.OPC_ChannelList_Class.OPC_ServerName.Clear()
            MainPage.OPC_ChannelList_Class.OPC_OPCItems.Clear()
            MainPage.OPC_ChannelList_Class.OPC_RefreshTime.Clear()
            MainPage.OPC_ChannelList_Class.OPC_HistoryLength.Clear()
            MainPage.OPC_ChannelList_Class.OPC_LastnnHourHistory.Clear()
            MainPage.OPC_ChannelList_Class.OPC_Multiview.Clear()


            MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes.Clear()

            AL_ChList.Clear() 'it contain unique Channel Name


            If Not MainPage.opcCnfgTags Is Nothing AndAlso MainPage.opcCnfgTags.Length > 0 Then


                For j As Integer = 0 To MainPage.opcCnfgTags.Length - 1
                    If Not MainPage.opcCnfgTags(j) Is Nothing Then
                        MainPage.opcCnfgTags(j).Watcher.Dispose() 'Dispose File Watcher
                        If Not MainPage.opcCnfgTags(j)._asyncRefrGroup Is Nothing Then
                            Dim item() As ItemDef = MainPage.opcCnfgTags(j)._asyncRefrGroup.GetItemsInGroup()
                            If item.Length > 0 Then
                                For i As Integer = 0 To item.Length - 1
                                    MainPage.opcCnfgTags(j)._asyncRefrGroup.Remove(item(i).OpcIDef.ItemID) 'Remove OPC Items
                                Next

                            End If
                            Try
                                MainPage.opcCnfgTags(j)._asyncRefrGroup.OpcGrp.Remove(True)
                            Catch ex As Exception

                            End Try
                            Try
                                MainPage.opcCnfgTags(j)._asyncRefrGroup.Dispose()
                            Catch ex As Exception

                            End Try
                            Try
                                MainPage.opcCnfgTags(j).Dispose()
                                MainPage.opcCnfgTags(j) = Nothing
                            Catch ex As Exception

                            End Try

                            Try
                                MainPage.opcCnfgTags(j).Close() 'Close Instance DataForm 
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                Next

            End If
            'Opc Server Disconnect
            If Not MainPage.OPC_Servers Is Nothing Then
                For i As Integer = 0 To MainPage.OPC_Servers.Length - 1
                    If Not MainPage.OPC_Servers(i) Is Nothing Then
                        MainPage.OPC_Servers(i).Disconnect()
                        MainPage.OPC_Servers(i) = Nothing
                    End If
                    
                Next
            End If

            ReDim MainPage.opcCnfgTags(GVChannelsAdd.Rows.Count - 1) 'Re allocate the Channel Dataform
            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(3).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(4).Value) Then
                    If Not AL_ChList.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) And Not MainPage.channelList.Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) and Not MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                        If Not IsNumeric(GVChannelsAdd.Rows(i).Cells(5).Value) And Not IsNumeric(GVChannelsAdd.Rows(i).Cells(6).Value) Then
                            MsgBox("Incorrect Refresh Time/Incorrect History length !!! At Row:" & i + 1)
                            Exit For
                        End If
                        If Not IsNumeric(GVChannelsAdd.Rows(i).Cells(7).Value) Then
                            MsgBox("History Value Should be Numeric")
                            Exit For
                        End If


                        If MainPage.Server_Flag Then
                            Dim srvName = GVChannelsAdd.Rows(i).Cells(3).Value
                            Dim isavail As Integer = -1
                            If Not MainPage.OPC_ServeNames Is Nothing Then
                                isavail = Array.IndexOf(MainPage.OPC_ServeNames, srvName)
                            End If


                            If isavail <> -1 Then
                                If MainPage.OPC_Servers(isavail) Is Nothing Then
                                    MainPage.OPC_Servers(isavail) = New OpcServer

                                    rst = MainPage.OPC_Servers(isavail).Connect(srvName)

                                End If
                                If Not HRESULTS.Failed(rst) Then
                                    Dim rfTime As Integer = 1000
                                    rfTime = CInt(GVChannelsAdd.Rows(i).Cells(5).Value) * 1000
                                    Dim isM_View As Boolean
                                    If GVChannelsAdd.Rows(i).Cells(8).Value = "True" Then
                                        isM_View = True
                                    Else
                                        isM_View = False

                                    End If

                                    If CInt(GVChannelsAdd.Rows(i).Cells(7).Value) > 0 Then

                                        MainPage.opcCnfgTags(i) = New DataForm(MainPage.OPC_Servers(isavail), rfTime, 1, 1, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                                    Else
                                        MainPage.opcCnfgTags(i) = New DataForm(MainPage.OPC_Servers(isavail), rfTime, 0, 1, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                                    End If

                                    Dim OPC_Item() As String = GVChannelsAdd.Rows(i).Cells(4).Value.ToString.Split(",")
                                    For k As Integer = 0 To OPC_Item.Length - 1
                                        Itemdata = MainPage.opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                        If Itemdata Is Nothing Then     ' probably first use
                                            MainPage.opcCnfgTags(i)._asyncRefrGroup.Add(OPC_Item(k))      ' add item to group if not found
                                        End If
                                        Itemdata = MainPage.opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                        If Itemdata Is Nothing Then     ' there is a problem
                                            MsgBox("Item not found.")
                                            Exit For
                                        End If
                                    Next



                                    'Dim rts As Integer = MainPage.opcCnfgTags(i)._asyncRefrGroup.Add(Itemdata.OpcIDef.ItemID)
                                End If
                            ElseIf srvName.contains("^") Then
                                Dim opsrv As New OpcServer
                                rst = opsrv.Connect(srvName.split("^")(0), srvName.split("^")(1))
                                If Not HRESULTS.Failed(rst) Then
                                    Dim rfTime As Integer = 1000
                                    rfTime = CInt(GVChannelsAdd.Rows(i).Cells(5).Value) * 1000
                                    Dim isM_View As Boolean
                                    If GVChannelsAdd.Rows(i).Cells(8).Value = "True" Then
                                        isM_View = True
                                    Else
                                        isM_View = False

                                    End If

                                    If CInt(GVChannelsAdd.Rows(i).Cells(7).Value) > 0 Then

                                        MainPage.opcCnfgTags(i) = New DataForm(opsrv, rfTime, 1, 1, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                                    Else


                                        MainPage.opcCnfgTags(i) = New DataForm(opsrv, rfTime, 0, 1, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                                    End If
                                    Dim OPC_Item() As String = GVChannelsAdd.Rows(i).Cells(4).Value.ToString.Split(",")
                                    For k As Integer = 0 To OPC_Item.Length - 1
                                        Itemdata = MainPage.opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                        If Itemdata Is Nothing Then     ' probably first use
                                            MainPage.opcCnfgTags(i)._asyncRefrGroup.Add(OPC_Item(k))      ' add item to group if not found
                                        End If
                                        Itemdata = MainPage.opcCnfgTags(i)._asyncRefrGroup.Item(OPC_Item(k))
                                        If Itemdata Is Nothing Then     ' there is a problem
                                            MsgBox("Item not found.")
                                            Exit For
                                        End If
                                    Next



                                    'Dim rts As Integer = MainPage.opcCnfgTags(i)._asyncRefrGroup.Add(Itemdata.OpcIDef.ItemID)
                                End If

                            End If
                        Else
                            Dim rfTime As Integer
                            Dim opcSerObj As New OpcServer
                            rfTime = CInt(GVChannelsAdd.Rows(i).Cells(5).Value) * 1000
                            Dim isM_View As Boolean
                            If GVChannelsAdd.Rows(i).Cells(8).Value = "True" Then
                                isM_View = True
                            Else
                                isM_View = False
                            End If
                            If CInt(GVChannelsAdd.Rows(i).Cells(7).Value) > 0 Then
                                Dim hrCnt As Integer = CInt(GVChannelsAdd.Rows(i).Cells(7).Value)
                                MainPage.opcCnfgTags(i) = New DataForm(opcSerObj, rfTime, 1, 0, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                            Else
                                MainPage.opcCnfgTags(i) = New DataForm(opcSerObj, rfTime, 0, 0, GVChannelsAdd.Rows(i).Cells(1).Value, isM_View)
                            End If
                        End If



                        MainPage.opcCnfgTags(i).Tag = i
                        MainPage.opcCnfgTags(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                        MainPage.opcCnfgTags(i).AllowTransparency = True
                        MainPage.opcCnfgTags(i).Show()
                        MainPage.opcCnfgTags(i).Visible = False
                        MainPage.opcCnfgTags(i).AllowTransparency = False

                        MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                        MainPage.OPC_ChannelList_Class.OPC_ServerName.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                        MainPage.OPC_ChannelList_Class.OPC_OPCItems.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                        MainPage.OPC_ChannelList_Class.OPC_RefreshTime.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                        MainPage.OPC_ChannelList_Class.OPC_HistoryLength.Add(GVChannelsAdd.Rows(i).Cells(6).Value)
                        MainPage.OPC_ChannelList_Class.OPC_LastnnHourHistory.Add(GVChannelsAdd.Rows(i).Cells(7).Value)

                        If GVChannelsAdd.Rows(i).Cells(8).Value = "True" Then
                            MainPage.OPC_ChannelList_Class.OPC_Multiview.Add(True)
                        Else
                            MainPage.OPC_ChannelList_Class.OPC_Multiview.Add(False)
                        End If


                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes(i).Tag = "True" 'For start And Stop Channel
                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes(i).ImageIndex = 4
                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes(i).SelectedImageIndex = 4
                        MainPage.PageTreeView.Nodes(0).Nodes(1).Nodes(i).ToolTipText = GVChannelsAdd.Rows(i).Cells(3).Value & "&" & GVChannelsAdd.Rows(i).Cells(4).Value

                    Else
                        MsgBox("Same Channel Name May Exixts in OPC Channel/Supra DB Channel/SAMA Historian Channel  !!! At Row:" & i + 1)
                        Exit Sub
                    End If
                    AL_ChList.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                Else
                    MsgBox("Empty Fields not Allowed !!!")
                    Exit Sub
                End If

            Next

            MainPage.PageTreeView.Nodes(0).Nodes(1).ExpandAll()
            Me.Close()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC:Apply_Channel()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub
    Private Sub btnChnlApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlApply.Click
        Try

            MainPage.modify = True

            If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                MainPage.Text = MainPage.Text & " *"
            End If
            Call Apply_Channel()

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC:btnChnlApply_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub OPC_ChaneelListForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()
            If MainPage.blnOPC_AllowClients Then
                ckBox_OPCAllowClients.Checked = True
            End If
            If Not MainPage.Server_Flag Then
                ckBox_OPCAllowClients.Enabled = False
            Else
                ckBox_OPCAllowClients.Enabled = True
            End If
            For i As Integer = 0 To MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Count - 1
                GVChannelsAdd.Rows.Add()
                If Not MainPage.Server_Flag Then
                    GVChannelsAdd.Rows(i).Cells(0).ReadOnly = True
                    GVChannelsAdd.Rows(i).Cells(1).ReadOnly = True
                    GVChannelsAdd.Rows(i).Cells(3).ReadOnly = True
                    GVChannelsAdd.Rows(i).Cells(4).ReadOnly = True
                    GVChannelsAdd.Rows(i).Cells(5).ReadOnly = True

                End If
                GVChannelsAdd.Rows(i).Cells(8).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.OPC_ChannelList_Class.OPC_Channel_Name(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.OPC_ChannelList_Class.OPC_ServerName(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.OPC_ChannelList_Class.OPC_OPCItems(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.OPC_ChannelList_Class.OPC_RefreshTime(i)
                GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.OPC_ChannelList_Class.OPC_HistoryLength(i)
                GVChannelsAdd.Rows(i).Cells(7).Value = MainPage.OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
                GVChannelsAdd.Rows(i).Cells(8).Value = MainPage.OPC_ChannelList_Class.OPC_Multiview(i)
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC_ChaneelListForm_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub btnChnlDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlDelete.Click
        If GVChannelsAdd.Rows.Count > 0 Then
            Dim i = GVChannelsAdd.CurrentRow.Index
            GVChannelsAdd.Rows.RemoveAt(i)
        End If

    End Sub
    Private Dt As New DataTable
    Private Ds As New DataSet
    Private Sub DTColumn()
        Dt.Columns.Add(New DataColumn("OPC_ChannelName", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_OPCServer", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_Tag", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_RefreshTime", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_HisLength", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_nnHoursHistory", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("OPC_isMultiView", Type.GetType("System.String")))
    End Sub
    Private Sub ProcOpcChannelSave()
        Dim dr As DataRow
        Dt = New DataTable
        Ds = New DataSet
        Call DTColumn()
        For i As Integer = 0 To MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Count - 1
            dr = Dt.NewRow()
            dr("OPC_ChannelName") = MainPage.OPC_ChannelList_Class.OPC_Channel_Name(i)
            dr("OPC_OPCServer") = MainPage.OPC_ChannelList_Class.OPC_ServerName(i)
            dr("OPC_Tag") = MainPage.OPC_ChannelList_Class.OPC_OPCItems(i)
            dr("OPC_RefreshTime") = MainPage.OPC_ChannelList_Class.OPC_RefreshTime(i)
            dr("OPC_HisLength") = MainPage.OPC_ChannelList_Class.OPC_HistoryLength(i)
            dr("OPC_nnHoursHistory") = MainPage.OPC_ChannelList_Class.OPC_LastnnHourHistory(i)
            dr("OPC_isMultiView") = MainPage.OPC_ChannelList_Class.OPC_Multiview(i)
            Dt.Rows.Add(dr)
        Next
        Ds.Tables.Add(Dt)
        Ds.Tables(0).TableName = "OPCChannel"
    End Sub
    Private Sub btnChnlExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlExport.Click
        Try
            Dim fname As String = ""
            Dim savedlg As New SaveFileDialog
            savedlg.Filter = "OPC Channel File (*.XML)|*.xml"
            savedlg.FilterIndex = 0
            If savedlg.ShowDialog = DialogResult.OK Then
                fname = savedlg.FileName
            End If
            If (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                Exit Sub
            Else
                Ds.Namespace = fname
                Call ProcOpcChannelSave()
                If Not IO.File.Exists(fname & ".xml") And Not (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                    'Ds.WriteXml(fname)
                    MainPage.MyEncryptor(Ds, fname)
                    MsgBox("Done")
                ElseIf Not (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                    If MsgBox("Do you Want to Replace....", MsgBoxStyle.YesNo, "Confirm...") = MsgBoxResult.Yes Then
                        'Ds.WriteXml(fname)
                        MainPage.MyEncryptor(Ds, fname)
                        MsgBox("Done")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub AddOpcChaneel(ByVal Dt As DataTable)
        Try
            GVChannelsAdd.Rows.Clear()
            For i As Integer = 0 To Dt.Rows.Count - 1
                GVChannelsAdd.Rows.Add()
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(1).Value = (Dt.Rows(i).Item("OPC_ChannelName"))
                GVChannelsAdd.Rows(i).Cells(3).Value = (Dt.Rows(i).Item("OPC_OPCServer"))
                GVChannelsAdd.Rows(i).Cells(4).Value = (Dt.Rows(i).Item("OPC_Tag"))
                GVChannelsAdd.Rows(i).Cells(5).Value = (Dt.Rows(i).Item("OPC_RefreshTime"))
                GVChannelsAdd.Rows(i).Cells(6).Value = (Dt.Rows(i).Item("OPC_HisLength"))
                GVChannelsAdd.Rows(i).Cells(7).Value = (Dt.Rows(i).Item("OPC_nnHoursHistory"))
                GVChannelsAdd.Rows(i).Cells(8).Value = (Dt.Rows(i).Item("OPC_isMultiView"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btnChnlimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlimport.Click
        Try
            Dim openSavedlg As New OpenFileDialog
            openSavedlg.Filter = "OPC Channel File(*.XML)|*.xml"
            openSavedlg.FilterIndex = 0
            If openSavedlg.ShowDialog = DialogResult.OK Then
                If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                    Ds = New DataSet
                    'Ds.ReadXml(openSavedlg.FileName)
                    MainPage.MyDecryptor(Ds, openSavedlg.FileName)
                    For i As Integer = 0 To Ds.Tables.Count - 1
                        Dt = New DataTable()
                        Dt = Ds.Tables(i).DefaultView.ToTable(True)
                        Dt.AcceptChanges()
                        If Ds.Tables(i).TableName = "OPCChannel" Then
                            AddOpcChaneel(Dt)
                        Else
                            MsgBox("Not a valid OPC Channel file", MsgBoxStyle.Critical, "Warning !!!")
                        End If
                    Next
                Else
                    MsgBox("File Name Required !!")
                End If
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@btnChnlimport_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub


    Private Sub ckBox_OPCAllowClients_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBox_OPCAllowClients.CheckedChanged
        If ckBox_OPCAllowClients.Checked Then
            MainPage.blnOPC_AllowClients = True
        Else
            MainPage.blnOPC_AllowClients = False
        End If
    End Sub
End Class