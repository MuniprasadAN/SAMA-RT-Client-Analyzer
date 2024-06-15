Public Class OPCHDA_ChannelsList
    Private Sub btnChnlAdd_Click(sender As Object, e As EventArgs) Handles btnChnlAdd.Click
        Try
            Dim i As Integer = 0
            If GVChannelsAdd.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(3).Value) Then
                    i = GVChannelsAdd.Rows.Add()
                    GVChannelsAdd.Rows(i).Cells(0).Value = i + 1

                Else
                    MsgBox("Empty Fields not Allowed !!!")
                    Exit Sub
                End If
            Else
                i = GVChannelsAdd.Rows.Add()
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GVChannelsAdd_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GVChannelsAdd.CellMouseClick
        If GVChannelsAdd.CurrentCell.ColumnIndex = 2 Then
            If Not MainPage.Server_Flag Then
                MsgBox("Sorry !!! Cannot Configure the Client !!!", MsgBoxStyle.Critical, "Warning!!!")
            Else
                If Not String.IsNullOrEmpty(GVChannelsAdd.CurrentRow.Cells(3).Value) Then

                    BrowseOPCHDA.CBxLast.Text = GVChannelsAdd.CurrentRow.Cells(5).Value.split(" ")(0)
                    BrowseOPCHDA.CBx_Last.Text = GVChannelsAdd.CurrentRow.Cells(5).Value.split(" ")(1)

                    BrowseOPCHDA.CBxIntervalAutoUpd.Text = GVChannelsAdd.CurrentRow.Cells(6).Value.split(" ")(0)
                    BrowseOPCHDA.CBxInterval_AutoUpd.Text = GVChannelsAdd.CurrentRow.Cells(6).Value.split(" ")(1)

                    BrowseOPCHDA.DTimeRelative.Value = DateTime.Parse(GVChannelsAdd.CurrentRow.Cells(7).Value)
                    BrowseOPCHDA.CbxXaxis.Text = GVChannelsAdd.CurrentRow.Cells(8).Value
                    BrowseOPCHDA.ShowDialog()
                Else
                    BrowseOPCHDA.ShowDialog()
                End If

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
            MainPage.OPCHDAChannelsList.OPC_Channel_Name.Clear()
            MainPage.OPCHDAChannelsList.OPC_ServerName.Clear()
            MainPage.OPCHDAChannelsList.OPC_OPCItems.Clear()
            MainPage.OPCHDAChannelsList.OPC_Last.Clear()
            MainPage.OPCHDAChannelsList.OPC_Interval.Clear()
            MainPage.OPCHDAChannelsList.OPC_RelativeTime.Clear()
            MainPage.OPCHDAChannelsList.OPC_XAxis.Clear()
            MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes.Clear()

            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(3).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(4).Value) Then
                    If Not MainPage.channelList.Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) And Not MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then

                        If MainPage.OPCHDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(3).Value) Then
                            Dim tmpopchda As HDARedundancy = MainPage.OPCHDAServersCollection.Item(GVChannelsAdd.Rows(i).Cells(3).Value)

                            If tmpopchda.lstChannels.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                                tmpopchda.RemoveChannel(GVChannelsAdd.Rows(i).Cells(1).Value)
                            End If

                            Dim dt As New DataTable
                            dt.Columns.Add("Quality", GetType(System.String))
                            dt.Columns.Add("TimeStamp", GetType(System.DateTime))
                            dt.Columns.Add("Value", GetType(System.String))
                            dt.Columns.Add("TagName", GetType(System.String))

                            Dim HistinMins As Integer = 0
                            If GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(1) = "Months" Then
                                HistinMins = CInt(GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(0)) * 30 * 24 * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(1) = "Days" Then
                                HistinMins = CInt(GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(0)) * 24 * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(1) = "Hours" Then
                                HistinMins = CInt(GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(0)) * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(1) = "Minutes" Then
                                HistinMins = CInt(GVChannelsAdd.Rows(i).Cells(5).Value.split(" ")(0))
                            End If

                            Dim IntervalinSecs As Integer = 0
                            If GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(1) = "Days" Then
                                IntervalinSecs = CInt(GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(0)) * 24 * 60 * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(1) = "Hours" Then
                                IntervalinSecs = CInt(GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(0)) * 60 * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(1) = "Minutes" Then
                                IntervalinSecs = CInt(GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(0)) * 60
                            ElseIf GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(1) = "Seconds" Then
                                IntervalinSecs = CInt(GVChannelsAdd.Rows(i).Cells(6).Value.split(" ")(0))
                            End If


                            tmpopchda.AddChannel(GVChannelsAdd.Rows(i).Cells(1).Value, GVChannelsAdd.Rows(i).Cells(4).Value.split(","), HistinMins, IntervalinSecs, "A", DateTime.Parse(GVChannelsAdd.Rows(i).Cells(7).Value))
                        End If


                        MainPage.OPCHDAChannelsList.OPC_Channel_Name.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                        MainPage.OPCHDAChannelsList.OPC_ServerName.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                        MainPage.OPCHDAChannelsList.OPC_OPCItems.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                        MainPage.OPCHDAChannelsList.OPC_Last.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                        MainPage.OPCHDAChannelsList.OPC_Interval.Add(GVChannelsAdd.Rows(i).Cells(6).Value)
                        MainPage.OPCHDAChannelsList.OPC_RelativeTime.Add(GVChannelsAdd.Rows(i).Cells(7).Value)
                        MainPage.OPCHDAChannelsList.OPC_XAxis.Add(GVChannelsAdd.Rows(i).Cells(8).Value)

                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes(i).Tag = "True" 'For start And Stop Channel
                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes(i).ImageIndex = 4
                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes(i).SelectedImageIndex = 4
                        MainPage.PageTreeView.Nodes(0).Nodes(4).Nodes(i).ToolTipText = GVChannelsAdd.Rows(i).Cells(4).Value & "&" & GVChannelsAdd.Rows(i).Cells(4).Value
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
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCHDA_Apply_Channel()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub OPCHDA_ChannelsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()

            For i As Integer = 0 To MainPage.OPCHDAChannelsList.OPC_Channel_Name.Count - 1
                GVChannelsAdd.Rows.Add()

                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.OPCHDAChannelsList.OPC_Channel_Name(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.OPCHDAChannelsList.OPC_ServerName(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.OPCHDAChannelsList.OPC_OPCItems(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.OPCHDAChannelsList.OPC_Last(i)
                GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.OPCHDAChannelsList.OPC_Interval(i)
                GVChannelsAdd.Rows(i).Cells(7).Value = MainPage.OPCHDAChannelsList.OPC_RelativeTime(i)
                GVChannelsAdd.Rows(i).Cells(8).Value = MainPage.OPCHDAChannelsList.OPC_XAxis(i)
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCHDA_ChannelsList_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub
End Class