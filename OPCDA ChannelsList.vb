Public Class OPCDA_ChannelsList
    Private Sub OPCDA_ChannelsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()

            For i As Integer = 0 To MainPage.OPCDAChannelsList.OPC_Channel_Name.Count - 1
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
                GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.OPCDAChannelsList.OPC_Channel_Name(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.OPCDAChannelsList.OPC_ServerName(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.OPCDAChannelsList.OPC_OPCItems(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.OPCDAChannelsList.OPC_RefreshTime(i)
                GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.OPCDAChannelsList.OPC_HistoryLength(i)
                GVChannelsAdd.Rows(i).Cells(7).Value = MainPage.OPCDAChannelsList.OPC_LastnnHourHistory(i)
                GVChannelsAdd.Rows(i).Cells(8).Value = MainPage.OPCDAChannelsList.OPC_Multiview(i)
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCDA_ChannelsList_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub btnChnlAdd_Click(sender As Object, e As EventArgs) Handles btnChnlAdd.Click
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
            Else
                BrowseOPCTags.ShowDialog()
            End If
        End If
    End Sub
    Private Sub btnChnlDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlDelete.Click
        If GVChannelsAdd.Rows.Count > 0 Then
            Dim i = GVChannelsAdd.CurrentRow.Index
            GVChannelsAdd.Rows.RemoveAt(i)
        End If
    End Sub
    Private Sub btnChnlApply_Click(sender As Object, e As EventArgs) Handles btnChnlApply.Click
        MainPage.modify = True

        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Apply_Channel()
        Me.Close()
    End Sub
    Private Sub Apply_Channel()
        Try
            MainPage.OPCDAChannelsList.OPC_Channel_Name.Clear()
            MainPage.OPCDAChannelsList.OPC_ServerName.Clear()
            MainPage.OPCDAChannelsList.OPC_OPCItems.Clear()
            MainPage.OPCDAChannelsList.OPC_RefreshTime.Clear()
            MainPage.OPCDAChannelsList.OPC_HistoryLength.Clear()
            MainPage.OPCDAChannelsList.OPC_LastnnHourHistory.Clear()
            MainPage.OPCDAChannelsList.OPC_Multiview.Clear()
            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes.Clear()

            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(3).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(4).Value) Then
                    If Not MainPage.channelList.Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) And Not MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                        If Not IsNumeric(GVChannelsAdd.Rows(i).Cells(5).Value) And Not IsNumeric(GVChannelsAdd.Rows(i).Cells(6).Value) Then
                            MsgBox("Incorrect Refresh Time/Incorrect History length !!! At Row:" & i + 1)
                            Exit For
                        End If
                        If Not IsNumeric(GVChannelsAdd.Rows(i).Cells(7).Value) Then
                            MsgBox("History Value Should be Numeric")
                            Exit For
                        End If

                        If MainPage.OPCDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(3).Value) Then
                            Dim tmpopcda As Redundancy = MainPage.OPCDAServersCollection.Item(GVChannelsAdd.Rows(i).Cells(3).Value)

                            If tmpopcda.lstChannels.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                                tmpopcda.RemoveChannel(GVChannelsAdd.Rows(i).Cells(1).Value)
                            End If
                            tmpopcda.AddChannel(GVChannelsAdd.Rows(i).Cells(1).Value, GVChannelsAdd.Rows(i).Cells(4).Value.split(","), GVChannelsAdd.Rows(i).Cells(6).Value)
                        End If


                        MainPage.OPCDAChannelsList.OPC_Channel_Name.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                            MainPage.OPCDAChannelsList.OPC_ServerName.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                            MainPage.OPCDAChannelsList.OPC_OPCItems.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                            MainPage.OPCDAChannelsList.OPC_RefreshTime.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                            MainPage.OPCDAChannelsList.OPC_HistoryLength.Add(GVChannelsAdd.Rows(i).Cells(6).Value)
                            MainPage.OPCDAChannelsList.OPC_LastnnHourHistory.Add(GVChannelsAdd.Rows(i).Cells(7).Value)

                            If GVChannelsAdd.Rows(i).Cells(8).Value = "True" Then
                            MainPage.OPCDAChannelsList.OPC_Multiview.Add(True)
                        Else
                            MainPage.OPCDAChannelsList.OPC_Multiview.Add(False)
                        End If


                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes(i).Tag = "True" 'For start And Stop Channel
                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes(i).ImageIndex = 4
                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes(i).SelectedImageIndex = 4
                            MainPage.PageTreeView.Nodes(0).Nodes(3).Nodes(i).ToolTipText = GVChannelsAdd.Rows(i).Cells(3).Value & "&" & GVChannelsAdd.Rows(i).Cells(4).Value
                        Else
                            MsgBox("Same Channel Name May Exixts in OPC Channel/Supra DB Channel/SAMA Historian Channel  !!! At Row:" & i + 1)
                        Exit Sub
                    End If
                Else
                    MsgBox("Empty Fields not Allowed !!!")
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class