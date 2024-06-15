Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports ch = DevExpress.XtraCharts

Public Class SAMAHistorianChannels


    Private Sub btnChnlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlAdd.Click
        Try
            Dim i As Integer = 0
            If GVChannelsAdd.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(2).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(4).Value) Then
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
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian:Apply_Channel()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub GVChannelsAdd_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GVChannelsAdd.CellMouseClick
        Try
            If GVChannelsAdd.CurrentCell.ColumnIndex = 1 Then
                Dim AddReport As New SAMAReports_Config()
                If (Not GVChannelsAdd.CurrentRow.Cells.Item(2).Value Is Nothing) Then
                    AddReport.txtRpt.Text = GVChannelsAdd.CurrentRow.Cells.Item(2).Value
                    AddReport.Txtbx_Description.Text = GVChannelsAdd.CurrentRow.Cells.Item(3).Value
                    Dim duration() As String = (GVChannelsAdd.CurrentRow.Cells.Item(5).Value).split(" ")
                    Dim interval() As String = (GVChannelsAdd.CurrentRow.Cells.Item(6).Value).split(" ")
                    AddReport.Txtbx_duration.Text = duration(0)
                    AddReport.CBx_duration.Text = duration(1)
                    AddReport.Txtbx_Interval.Text = interval(0)
                    AddReport.CBx_Interval.Text = interval(1)
                    AddReport.CBx_XAxis.Text = GVChannelsAdd.CurrentRow.Cells.Item(7).Value
                    ' AddReport.CBxOperation.Text = GVChannelsAdd.CurrentRow.Cells.Item(8).Value
                End If
                AddReport.ShowDialog()
                If AddReport.BtnOk Then
                    GVChannelsAdd.CurrentRow.Cells(2).Value = AddReport.txtRpt.Text
                    GVChannelsAdd.CurrentRow.Cells(3).Value = AddReport.Txtbx_Description.Text
                    GVChannelsAdd.CurrentRow.Cells(5).Value = AddReport.Txtbx_duration.Text + " " + AddReport.CBx_duration.Text
                    GVChannelsAdd.CurrentRow.Cells(6).Value = AddReport.Txtbx_Interval.Text + " " + AddReport.CBx_Interval.Text
                    GVChannelsAdd.CurrentRow.Cells(7).Value = AddReport.CBx_XAxis.Text
                    ' GVChannelsAdd.CurrentRow.Cells(8).Value = AddReport.CBxOperation.Text
                End If
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian:Channel_Configuration()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub GVChannelsAdd_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GVChannelsAdd.CellMouseDoubleClick
        Try
            If GVChannelsAdd.CurrentCell.ColumnIndex = 4 Then
                Dim Add_SAMATags As New Add_SAMAHistoriantags(MainPage.TagNames)
                If (Not GVChannelsAdd.CurrentCell.Value Is Nothing) Then
                    ' Add_SAMATags.lstbxSelectedTags.Text = GVChannelsAdd.CurrentCell.Value
                    Dim tag As String = GVChannelsAdd.CurrentCell.Value.ToString()
                    Dim tags() As String = tag.Split(",")
                    For Each tg In tags
                        Add_SAMATags.lstbxSelectedTags.Items.Add(tg.ToString())
                    Next

                    Dim oper As String = GVChannelsAdd.CurrentRow.Cells.Item(8).Value
                    Dim operations() As String = oper.Split(",")
                    For Each op In operations
                        Add_SAMATags.lstbxseltopr.Items.Add(op.ToString())
                    Next

                End If
                Add_SAMATags.ShowDialog()
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian:ChannelTagsConfiguration()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub btnChnlDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlDelete.Click
        Try
            If GVChannelsAdd.Rows.Count > 0 Then
                Dim i = GVChannelsAdd.CurrentRow.Index
                GVChannelsAdd.Rows.RemoveAt(i)
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian:channelDelete()")
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
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_ChannelApply_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Public Sub Apply_Channel()
        Try
            MainPage.SAMAHistorian_ChannelList.ChannelReportname.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelReportDescription.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelTags.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelDuration.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelInterval.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelXAxis.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelOperations.Clear()
            MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Clear()
            For Each tmr In MainPage.SAMAHistorian_ChannelList.ChannelTimers
                tmr.Stop()
                tmr.Dispose()
            Next
            MainPage.SAMAHistorian_ChannelList.ChannelTimers.Clear()

            MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Clear()
            Dim DT As DataTable
            Dim _timer As Timer
            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(2).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(3).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(4).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(5).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(6).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(7).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(8).Value) Then
                    If Not MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(GVChannelsAdd.Rows(i).Cells(2).Value) And Not MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(2).Value) And Not MainPage.channelList.Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(2).Value) Then


                        _timer = New Timer()
                        _timer.Tag = GVChannelsAdd.Rows(i).Cells(2).Value + "timer"
                        Dim _interval() As String = (GVChannelsAdd.Rows(i).Cells(6).Value).split(" ")

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
                        ' _timer.Interval = 10000
                        _timer.Enabled = True
                        AddHandler _timer.Tick, (AddressOf tmr_GenerateReport)

                        DT = New DataTable()

                        MainPage.SAMAHistorian_ChannelList.ChannelReportname.Add(GVChannelsAdd.Rows(i).Cells(2).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelReportDescription.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelTags.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelDuration.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelInterval.Add(GVChannelsAdd.Rows(i).Cells(6).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelXAxis.Add(GVChannelsAdd.Rows(i).Cells(7).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelOperations.Add(GVChannelsAdd.Rows(i).Cells(8).Value)
                        MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Add(DT)
                        MainPage.SAMAHistorian_ChannelList.ChannelTimers.Add(_timer)

                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Add(GVChannelsAdd.Rows(i).Cells(2).Value)
                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).Name = GVChannelsAdd.Rows(i).Cells(2).Value
                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).Tag = "True" 'For start And Stop Channel
                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).ToolTipText = GVChannelsAdd.Rows(i).Cells(4).Value
                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).ImageIndex = 4
                        MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).SelectedImageIndex = 4

                        tmr_GenerateReport(_timer, Nothing)
                    Else
                        MsgBox("Same Channel Name May Exixts in SAMAHistorian Channel/OPC Channel/Supra DB Channel  !!! At Row:" & i + 1)
                        Exit Sub

                    End If
                Else
                    MsgBox("Empty Fields not Allowed !!!")
                    Exit Sub
                End If
            Next


            MainPage.PageTreeView.Nodes(0).Nodes(2).ExpandAll()
            Me.Close()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_ChannelApply_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Public Sub tmr_GenerateReport(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim _Reportname, RptDescription, RptTags, _Daterange, _interval, RptType, operati, OperationType As String
            _Reportname = (sender.Tag).remove(sender.tag.indexof("timer"))

            Dim Rptindx = MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(_Reportname)
            RptDescription = MainPage.SAMAHistorian_ChannelList.ChannelReportDescription(Rptindx)
            RptTags = MainPage.SAMAHistorian_ChannelList.ChannelTags(Rptindx)
            _interval = MainPage.SAMAHistorian_ChannelList.ChannelInterval(Rptindx)
            RptType = MainPage.SAMAHistorian_ChannelList.ChannelXAxis(Rptindx)
            operati = MainPage.SAMAHistorian_ChannelList.ChannelOperations(Rptindx)
            Dim durat() As String = (MainPage.SAMAHistorian_ChannelList.ChannelDuration(Rptindx)).Split(" ")
            Dim startdate, enddate As Date
            Dim currenttime As Date = Now.ToString("MMM/dd/yyyy HH:mm:00")
            If durat(1) = "Minutes" Then
                startdate = currenttime.AddMinutes(-CInt(durat(0)))
                enddate = currenttime
                _Daterange = startdate.ToString("MMM/dd/yyyy HH:mm:00") + "," + enddate.ToString("MMM/dd/yyyy HH:mm:00")
            ElseIf durat(1) = "Hours" Then
                startdate = currenttime.AddHours(-CInt(durat(0)))
                enddate = currenttime
                _Daterange = startdate.ToString("MMM/dd/yyyy HH:mm:00") + "," + enddate.ToString("MMM/dd/yyyy HH:mm:00")
            ElseIf durat(1) = "Days" Then
                startdate = currenttime.AddDays(-CInt(durat(0)))
                enddate = currenttime
                _Daterange = startdate.ToString("MMM/dd/yyyy HH:mm:00") + "," + enddate.ToString("MMM/dd/yyyy HH:mm:00")
            ElseIf durat(1) = "Weeks" Then
                startdate = currenttime.AddDays(-7 * CInt(durat(0)))
                enddate = currenttime
                _Daterange = startdate.ToString("MMM/dd/yyyy HH:mm:00") + "," + enddate.ToString("MMM/dd/yyyy HH:mm:00")
            ElseIf durat(1) = "Months" Then
                startdate = currenttime.AddMonths(-CInt(durat(0)))
                enddate = currenttime
                _Daterange = startdate.ToString("MMM/dd/yyyy HH:mm:00") + "," + enddate.ToString("MMM/dd/yyyy HH:mm:00")
            End If

            Dim operations() As String = operati.Split(",")
            Dim oprlist As New List(Of String)
            For Each oper In operations
                oprlist.Add(oper)
            Next
            Dim seloper As New List(Of String)
            For i As Integer = 0 To oprlist.Count - 1
                If oprlist(i) = "Average" Then
                    'oprlist.Remove("Average")
                    seloper.Add("Avg")
                ElseIf oprlist(i) = "Maximum" Then
                    ' oprlist.Remove("Maximum")
                    seloper.Add("Max")
                ElseIf oprlist(i) = "Minimum" Then
                    'oprlist.Remove("Minimum")
                    seloper.Add("Min")
                ElseIf oprlist(i) = "Instant" Then
                    'oprlist.Remove("Instant")
                    seloper.Add("Inst")

                ElseIf oprlist(i) = "Count" Then
                    'oprlist.Remove("Count")
                    seloper.Add("Count")

                ElseIf oprlist(i) = "Totalizer" Then
                    'oprlist.Remove("Totalizer")
                    seloper.Add("Tot")

                ElseIf oprlist(i) = "Standard Deviation" Then
                    'oprlist.Remove("Standard Deviation")
                    seloper.Add("Sdev")

                ElseIf oprlist(i) = "Variance" Then
                    'oprlist.Remove("Variance")
                    seloper.Add("Vrnc")

                ElseIf oprlist(i) = "Sum" Then
                    'oprlist.Remove("Sum")
                    seloper.Add("Sum")

                ElseIf oprlist(i) = "Incremental Average" Then
                    'oprlist.Remove("Incremental Average")
                    seloper.Add("IAvg")

                ElseIf oprlist(i) = "Incremental Maximum" Then
                    'oprlist.Remove("Incremental Maximum")
                    seloper.Add("IMax")

                ElseIf oprlist(i) = "Incremental Minimum" Then
                    'oprlist.Remove("Incremental Minimum")
                    seloper.Add("IMin")

                ElseIf oprlist(i) = "Incremental Instant" Then
                    'oprlist.Remove("Incremental Instant")
                    seloper.Add("IInst")

                ElseIf oprlist(i) = "Incremental Count" Then
                    'oprlist.Remove("Incremental Count")
                    seloper.Add("ICount")

                ElseIf oprlist(i) = "Incremental Totalizer" Then
                    'oprlist.Remove("Incremental Totalizer")
                    seloper.Add("ITot")

                ElseIf oprlist(i) = "Incremental Sum" Then
                    'oprlist.Remove("Incremental Sum")
                    seloper.Add("ISum")

                ElseIf oprlist(i) = "Deviation" Then
                    'oprlist.Remove("Deviation")
                    seloper.Add("Dev")

                ElseIf oprlist(i) = "Rate of Change" Then
                    'oprlist.Remove("Rate of Change")
                    seloper.Add("ROC")
                End If
            Next
            OperationType = String.Join(",", seloper.ToArray())
            Generate_Rpt_File(_Reportname, RptTags, _Daterange, "TXT", _interval, RptType, OperationType)
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_ChannelGenerateReport()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Function AddChannelIdToTag(ByVal tags As String) As String
        Try
            Dim tagarr() As String = tags.Split(",")
            For i As Integer = 0 To tagarr.Length - 1
                Dim Tagindx = MainPage.TagNames.IndexOf(tagarr(i))
                If Tagindx <> -1 Then
                    tagarr(i) = tagarr(i).Replace(tagarr(i), MainPage._ChannelIds.Item(Tagindx) & "." & tagarr(i))
                End If
            Next
            Return Join(tagarr, ",")
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_AddChannelIdToTag()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Function

    Private Sub Generate_Rpt_File(ByVal RpName As String, ByVal tgs As String, ByVal DateRange As String, ByVal OutPut_Format As String, ByVal Interval As String, ByVal ReportType As String, ByVal operation As String)
        Try
            Dim sb As New StringBuilder
            sb.AppendLine(OutPut_Format)
            sb.AppendLine(RpName & "_" & Now.ToString("yyyy_MMM_dd_HH_mm") & ".txt")
            sb.AppendLine(AddChannelIdToTag(tgs))
            sb.AppendLine(DateRange)
            sb.AppendLine(Interval)
            sb.AppendLine("Time")
            sb.AppendLine("Tags")
            sb.AppendLine(1)
            sb.AppendLine(operation)
            'MsgBox(MainPage._DbLocation)
            IO.File.WriteAllText(MainPage._DbLocation & "\" & RpName & "_" & Now.ToString("yyyy_MMM_dd_HH_mm") & ".rpt", sb.ToString)

            MainPage._errLog.Add("Log@" & "File Request@" & Now.ToString & "@" & MainPage._DbLocation & "\" & RpName & "_" & Now.ToString("yyyy_MMM_dd_HH_mm") & ".rpt")

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_Generate_Rpt_File()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Public Sub tmr_GenerateHistorianChannelDataTable(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If MainPage._DbLocation = "" Then
                Exit Sub
            End If


            Dim tmr As System.Windows.Forms.Timer
            tmr = DirectCast(sender, System.Windows.Forms.Timer)
            tmr.Stop()

            Dim dirInfo As New DirectoryInfo(MainPage._DbLocation)
            Dim ReportName As String = "", Rpt_FileName As String = ""
            For Each fl As FileInfo In dirInfo.GetFiles("*.txt")

                If fl.Name = ("Tags.csv") Then
                Else

                    MainPage._errLog.Add("Log@" & "File Response@" & Now.ToString & "@" & fl.FullName)

                    Convert_To_CSV(fl)
                    'File.Delete(fl.FullName.Replace(".txt", ".rpt"))
                    'fl.Delete()

                End If
            Next
            tmr.Start()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_tmr_GenerateHistorianChannelDataTable()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Private Sub Convert_To_CSV(ByVal flinfo As FileInfo)
        Try

            Dim RptName As String = flinfo.Name.Split("_")(0)

            If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(RptName) Then
                Dim _Rptindx = MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(RptName)

                Dim XAxisParam As String = MainPage.SAMAHistorian_ChannelList.ChannelXAxis(_Rptindx)
                Dim _datatable As DataTable = MainPage.SAMAHistorian_ChannelList.ChannelDatatable(_Rptindx)


                If XAxisParam <> "" Then

                    If XAxisParam = "Time" Then


                        Dim fl() As String = File.ReadAllLines(flinfo.FullName)

                        For Row_no As Integer = 0 To fl.Length - 1
                            If fl(Row_no) = "" Then
                                Continue For
                            End If
                            'Remove Channel Number from Tag
                            If (Row_no > 0) Then
                                fl(Row_no) = Mid(fl(Row_no), InStr(fl(Row_no), ".") + 1)
                                Dim str() As String = fl(Row_no).Split(",")
                                Dim tempstr(str.Count - 1) As String
                                For l As Integer = 0 To str.Count - 1
                                    If l = 0 Then
                                        tempstr(l) = str(l)
                                    Else
                                        tempstr(l) = str(l).Split("~")(0)
                                    End If
                                Next
                                fl(Row_no) = String.Join(",", tempstr)
                                'MsgBox(fl(Row_no))
                            End If
                        Next
                        IO.File.WriteAllLines(Application.StartupPath & "\" & flinfo.Name, fl)

                    Else
                        Dim ar() As String
                        Dim fl() As String = File.ReadAllLines(flinfo.FullName)
                        ReDim ar(fl(0).Split(",").Length - 1)
                        Dim tx() As String = fl(0).Split(",")

                        For k As Integer = 0 To tx.Length - 1
                            ar(k) = tx(k)
                        Next
                        Dim clmcnt As Integer = 0
                        For j As Integer = 1 To fl.Length - 1
                            If fl(j) = "" Then
                                Continue For
                            End If
                            clmcnt = 0
                            For Each clm As String In fl(j).Split(",")
                                If clm.Contains("~") Then
                                    ar(clmcnt) &= "," & (clm.Split("~")(0))
                                Else
                                    ar(clmcnt) &= "," & clm
                                End If

                                clmcnt += 1
                            Next

                        Next

                        For Each s As String In ar(0).Split(",")
                            If s = "" Then
                                Continue For
                            End If
                            'Remove Channel Number from Tag
                            ar(0) = ar(0).Replace(s, Mid(s, InStr(s, ".") + 1))
                        Next

                        File.WriteAllLines(Application.StartupPath & "\" & flinfo.Name, ar)
                    End If
                End If

                ConvertCSVtoDatatable(flinfo.Name, _Rptindx, RptName)
                File.Delete(Application.StartupPath & "\" & flinfo.Name)


                File.Delete(flinfo.FullName.Replace(".txt", ".rpt"))
                flinfo.Delete()
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_Convert_To_CSV()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub ConvertCSVtoDatatable(ByVal fileinfo As String, ByVal indx As Integer, ByVal _Rptname As String)
        Try
            Dim folder = Application.StartupPath
            'Dim con = "Provider=Microsoft.Jet.oledb.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=yes;FMT=Delimited"";"
            'Dim dt As New DataTable
            'Using Adp As New OleDbDataAdapter("Select * From [" & fileinfo & "]", con)
            '    Adp.Fill(dt)
            'End Using

            Dim operati, _tags As String
            operati = MainPage.SAMAHistorian_ChannelList.ChannelOperations(indx)
            _tags = MainPage.SAMAHistorian_ChannelList.ChannelTags(indx)

            Dim operation() As String = operati.Split(",")
            Dim tags() As String = _tags.Split(",")

            Dim optline() As String = IO.File.ReadAllLines(folder & "\" & fileinfo) '(0).Split(",")
            Dim colm() As String = optline(0).Split(",")

            Dim innnndx As Integer = 0
            For j As Integer = 0 To colm.Length - 1
                If tags.Contains(colm(j)) Then
                    colm(j) = tags(innnndx) & "_" & operation(innnndx)
                    innnndx += 1
                End If
            Next
            optline(0) = Join(colm, ",").ToString()
            IO.File.Delete(folder & "\" & fileinfo)
            IO.File.WriteAllLines(folder & "\" & fileinfo, optline)

            'System.Diagnostics.Debug.Print(Join(optline, ","))
            'For Each dc As DataColumn In dt.Columns
            '    System.Diagnostics.Debug.Print(dc.ColumnName)
            'Next

            Dim con = "Provider=Microsoft.Jet.oledb.4.0;Data Source=" & folder & ";Extended Properties=""text;HDR=yes;FMT=Delimited"";"
            Dim dt As New DataTable
            Using Adp As New OleDbDataAdapter("Select * From [" & fileinfo & "]", con)
                Adp.Fill(dt)
            End Using


            MainPage.SAMAHistorian_ChannelList.ChannelDatatable(indx) = dt
            AssigntoControl(dt, _Rptname)
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_ConvertCSVtoDatatable()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Public Sub AssigntoControl(ByVal dt As DataTable, ByVal chName As String)

        Try
            For j As Integer = 0 To MainPage.CreatedPages.Count - 1
                Dim pnlObj() As Control
                pnlObj = MainPage.Controls.Find(MainPage.CreatedPages(j), True) 'Get the Panel control
                If pnlObj.Length > 0 Then
                    If Not pnlObj(0) Is Nothing Then

                        For Each Fcontrols In pnlObj(0).Controls 'Get the controls one by one from panel control


                            If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                Dim gvCtrl As DataGridViewCtrl = Fcontrols 'Assign Ctrl
                                If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(gvCtrl.AccessibleDescription) Then
                                    If gvCtrl.AccessibleDescription = chName Then

                                        gvCtrl.DataSource = dt

                                        'Fcontrols.FirstDisplayedScrollingRowIndex = 0
                                    End If
                                End If
                            ElseIf (TypeOf Fcontrols Is MultiTrendCtrl) Then
                                Dim TrendCtrl As MultiTrendCtrl = Fcontrols

                                If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(TrendCtrl.ChartControl1.AccessibleDescription) Then
                                    If TrendCtrl.ChartControl1.AccessibleDescription = chName Then
                                        'Dim enumerableTable = TryCast(dt, System.ComponentModel.IListSource).GetList()
                                        'chrtCtrl.DataBindTable(enumerableTable, "Tags/Time")

                                        Dim clmcnt As Integer = dt.Columns.Count - 1
                                        For i As Integer = 0 To clmcnt - 1
                                            For k As Integer = 0 To dt.Rows.Count - 1
                                                TrendCtrl.ChartControl1.Series(i).Points.Clear()
                                            Next
                                        Next

                                        If TrendCtrl.xaxis = "Time" Then
                                            TrendCtrl.ChartControl1.Series(0).XValueType = DataVisualization.Charting.ChartValueType.Time 'X value type
                                            TrendCtrl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Format = "HH:mm:ss"
                                            For i As Integer = 0 To clmcnt - 1
                                                For k As Integer = 0 To dt.Rows.Count - 1
                                                    If IsDBNull(dt.Rows(k).Item(0)) Then
                                                        Continue For
                                                    End If

                                                    TrendCtrl.ChartControl1.Series(i).Points.AddXY(CDate(dt.Rows(k).Item(0)).ToString("HH:mm:ss"), dt.Rows(k).Item(i + 1))

                                                Next
                                                TrendCtrl.DataGridViewCtrl1.Rows(i).Cells("TagValue").Value = dt.Rows(dt.Rows.Count - 1)(dt.Columns(i + 1))
                                            Next
                                        Else
                                            TrendCtrl.ChartControl1.Series(0).XValueType = DataVisualization.Charting.ChartValueType.UInt64 'X value type
                                            For i As Integer = 1 To clmcnt
                                                If dt.Columns(i).ColumnName = TrendCtrl.xaxis Then
                                                    TrendCtrl.ChartControl1.Series(i - 1).Enabled = False
                                                Else
                                                    For k As Integer = 0 To dt.Rows.Count - 1
                                                        If IsDBNull(dt.Rows(k).Item(0)) Then
                                                            Continue For
                                                        End If
                                                        If Not IsDBNull(dt.Rows(k).Item(TrendCtrl.xaxis)) Then
                                                            TrendCtrl.ChartControl1.Series(i - 1).Points.AddXY(dt.Rows(k).Item(TrendCtrl.xaxis), dt.Rows(k).Item(i))
                                                        End If
                                                    Next
                                                End If
                                                TrendCtrl.DataGridViewCtrl1.Rows(i - 1).Cells("TagValue").Value = dt.Rows(dt.Rows.Count - 1)(dt.Columns(i))
                                            Next
                                        End If
                                    End If
                                End If
                                '-----Newly added by aravinth
                                '-----MORS chart control assign values
                            ElseIf (TypeOf Fcontrols Is MChartControl) Then
                                Dim MchartCtrl As MChartControl = Fcontrols
                                If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(MchartCtrl.AccessibleDescription) Then
                                    If True Then
                                        If MchartCtrl.AccessibleDescription = chName Then
                                            Dim objMChartCtrl As MChartControl = Fcontrols
                                            With objMChartCtrl
                                                Dim intUnits As Integer
                                                intUnits = .gintMCUnits
                                                Dim intLastRowInTheHistorianData As Integer
                                                intLastRowInTheHistorianData = dt.Rows.Count - 1
                                                Dim dblPresentCost, dblOptimumCost, dblProfit As Double
                                                dblPresentCost = 0
                                                dblOptimumCost = 0
                                                dblProfit = 0

                                                Dim strTagNameForUnit, strTagNameForPLambda As String
                                                For I = 1 To intUnits '- 1 To .gdgvMORS.Rows.Count - 1
                                                    'First 'n' rows is for OptimumLoading
                                                    'Start from LoadingAtPresent
                                                    strTagNameForUnit = Replace(.glosMCTagForMan(I - 1), ".", "#") & "_Instant"
                                                    strTagNameForPLambda = Replace(.glosMCTagForPLambda(I - 1), ".", "#") & "_Instant"
                                                    Dim sngP, sngPLambda As Single
                                                    sngP = dt.Rows(intLastRowInTheHistorianData).Item(strTagNameForUnit)
                                                    sngPLambda = dt.Rows(intLastRowInTheHistorianData).Item(strTagNameForPLambda)

                                                    dblPresentCost += (sngPLambda * .gsngPricePerUnit)

                                                    .gdgvMORS.Rows(I + intUnits - 1).Cells(1).Value = sngP
                                                    .gdgvMORS.Rows(I + intUnits - 1).Cells(2).Value = sngPLambda
                                                    .gdgvMORS.Rows(I + intUnits - 1).Cells(3).Value = sngPLambda * .gsngPricePerUnit
                                                Next
                                                dblOptimumCost = .gdgvMORS.Rows(1).Cells(3).Value * 2

                                                dblProfit = dblPresentCost - dblOptimumCost
                                                .gdgvMORS.Rows(.gdgvMORS.Rows.Count - 3).Cells(3).Value = dblPresentCost
                                                .gdgvMORS.Rows(.gdgvMORS.Rows.Count - 2).Cells(3).Value = dblOptimumCost
                                                .gdgvMORS.Rows(.gdgvMORS.Rows.Count - 1).Cells(3).Value = dblProfit
                                                .gdgvMORS.Refresh()
                                            End With
                                        End If
                                    End If

                                    If False Then

                                        'If MchartCtrl.AccessibleDescription = chName Then
                                        '    Dim clmcnt As Integer = dt.Columns.Count - 1
                                        '    For i As Integer = 0 To clmcnt - 1
                                        '        MchartCtrl.Series(i).Points.Clear()
                                        '    Next

                                        '    Dim diagram As ch.XYDiagram = CType(MainPage.MChart_Ctrl.Diagram, ch.XYDiagram)
                                        '    If MchartCtrl._xaxis = "Time" Then
                                        '        ' diagram.AxisX.Label.TextPattern = "{HH:mm:ss}"

                                        '        For i As Integer = 0 To clmcnt - 1
                                        '            MchartCtrl.Series(i).ArgumentScaleType = ch.ScaleType.Qualitative
                                        '            For k As Integer = 0 To dt.Rows.Count - 1
                                        '                If IsDBNull(dt.Rows(k).Item(0)) Then
                                        '                    Continue For
                                        '                End If
                                        '                Dim ds As DateTime = dt.Rows(k).Item(0)
                                        '                Dim day As Integer = ds.Day
                                        '                Dim Mon As Integer = ds.Month
                                        '                Dim Year As Integer = ds.Year
                                        '                Dim hr As Integer = ds.Hour
                                        '                Dim min As Integer = ds.Minute
                                        '                Dim sec As Integer = ds.Second
                                        '                'MchartCtrl.Series(i).Points.Add(New ch.SeriesPoint(New TimeSpan(hr, min, sec), New Double() {dt.Rows(k).Item(i + 1)}))
                                        '                MchartCtrl.Series(i).Points.Add(New ch.SeriesPoint(dt.Rows(k).Item(0).ToString(), New Double() {dt.Rows(k).Item(i + 1)}))
                                        '            Next
                                        '            ' TrendCtrl.DataGridViewCtrl1.Rows(i).Cells("TagValue").Value = dt.Rows(dt.Rows.Count - 1)(dt.Columns(i + 1))
                                        '        Next
                                        '    Else
                                        '        MchartCtrl.Series(0).ArgumentScaleType = ch.ScaleType.Numerical
                                        '        For i As Integer = 1 To clmcnt
                                        '            If dt.Columns(i).ColumnName = MchartCtrl._xaxis Then
                                        '                MchartCtrl.Series(i - 1).Visible = False
                                        '            Else
                                        '                For k As Integer = 0 To dt.Rows.Count - 1
                                        '                    If IsDBNull(dt.Rows(k).Item(0)) Then
                                        '                        Continue For
                                        '                    End If
                                        '                    If Not IsDBNull(dt.Rows(k).Item(MchartCtrl._xaxis)) Then
                                        '                        'MsgBox(dt.Rows(k).Item(MchartCtrl._xaxis), dt.Rows(k).Item(i))
                                        '                        MchartCtrl.Series(i - 1).Points.AddPoint(dt.Rows(k).Item(MchartCtrl._xaxis), dt.Rows(k).Item(i))
                                        '                    End If
                                        '                Next
                                        '            End If
                                        '        Next
                                        '    End If
                                        'End If

                                    End If

                                    If False Then
                                        'If MchartCtrl.AccessibleDescription = chName Then
                                        '    Dim objMChartCtrl As MChartControl = Fcontrols
                                        '    objMChartCtrl.gdtMCLiveData.Rows.Clear()

                                        '    Dim sngLambdaY1Y2 As Single
                                        '    Dim intUnits As Integer
                                        '    With objMChartCtrl
                                        '        intUnits = .glosMCTagForMan.Count - 1
                                        '        For I = 0 To intUnits
                                        '            Dim sngP, sngLambda As Single
                                        '            Dim K As Integer = -1
                                        '            For K = 0 To dt.Rows.Count - 1
                                        '                sngP = dt.Rows(K).Item(.glosMCTagForMan(I))
                                        '                sngLambda = dt.Rows(K).Item(.glosMCTagForPLambda(I))
                                        '                .gdtMCLiveData.Rows.Add({I + 1, sngP, sngLambda})

                                        '                .glogLoadScheduledUnitLoadingAtPresent(intUnits) = sngP
                                        '                .glogIFCUnitOptimalLoading(intUnits) = 0
                                        '                'If I = 0 Then
                                        '                '    sngP1Opt = dt.Rows(K).Item(.glosMCTagForOpt(I))
                                        '                '    .gsngLoadScheduledUnit1LoadingAtPresent = sngP
                                        '                'ElseIf I = 1 Then
                                        '                '    sngP2Opt = dt.Rows(K).Item(.glosMCTagForOpt(I))
                                        '                '    .gsngLoadScheduledUnit2LoadingAtPresent = sngP
                                        '                'End If
                                        '            Next
                                        '            If K <> -1 Then
                                        '                sngLambdaY1Y2 = dt.Rows(K).Item(.gstrMCTagForLambda)
                                        '                'sngMinY2 = dt.Rows(K).Item(.gstrMCMinTag)
                                        '                'sngMaxY2 = dt.Rows(K).Item(.gstrMCMaxTag)
                                        '            End If
                                        '            MainPage.CalculateIntersectAndUpdateIntersectVariables(objMChartCtrl, I)
                                        '        Next
                                        '    End With

                                        '    objMChartCtrl.gsngLambdaY1 = sngLambdaY1Y2
                                        '    objMChartCtrl.gsngLambdaY2 = sngLambdaY1Y2

                                        '    MainPage.UpdateVariableValuesInChart(objMChartCtrl)

                                        '    If False Then
                                        '        Try
                                        '            MchartCtrl.Series(0).Points.Clear()
                                        '            MchartCtrl.Series(1).Points.Clear()
                                        '            MchartCtrl.Series(2).Points.Clear()
                                        '            MchartCtrl.Series(0).View.Color = System.Drawing.Color.Red
                                        '            MchartCtrl.Series(1).View.Color = System.Drawing.Color.Blue
                                        '            'series1.ArgumentDataMember = "MW"
                                        '            MchartCtrl.Series(0).ArgumentScaleType = ch.ScaleType.Numerical
                                        '            MchartCtrl.Series(1).ArgumentScaleType = ch.ScaleType.Numerical

                                        '            Dim sngULambda As Single = 0
                                        '            For i = 0 To dt.Rows.Count - 1
                                        '                Dim sngP1, sngActP1, sngP2, sngActP2 As Single
                                        '                'dt.Columns.IndexOf("U1P#CV_Instant")
                                        '                sngP1 = dt.Rows(i).Item("U1P#CV_Instant")
                                        '                sngActP1 = dt.Rows(i).Item("ActP1#PV_Instant")
                                        '                sngP2 = dt.Rows(i).Item("U2P#CV_Instant")
                                        '                sngActP2 = dt.Rows(i).Item("ActP2#PV_Instant")
                                        '                sngULambda = dt.Rows(i).Item("U1Lambda#CV_Instant")
                                        '                Try
                                        '                    MchartCtrl.Series(0).Points.AddPoint(sngActP1, sngP1)
                                        '                    MchartCtrl.Series(1).Points.AddPoint(sngActP2, sngP2)
                                        '                Catch ex As Exception
                                        '                    MsgBox("PlotErr:" & ex.Message)
                                        '                End Try
                                        '            Next
                                        '            MchartCtrl.Series(2).Points.AddPoint(0, sngULambda)
                                        '            MchartCtrl.Series(2).Points.AddPoint(700, sngULambda)

                                        '        Catch ex As Exception
                                        '            MsgBox("Err:" & ex.Message)
                                        '        End Try
                                        '    End If

                                        '    If False Then
                                        '        MchartCtrl.DataSource = dt
                                        '        For i = 1 To dt.Columns.Count - 1
                                        '            If dt.Columns(i).ColumnName = "Tags/Time" Then
                                        '                Continue For
                                        '            End If
                                        '            MchartCtrl.Series(i).ArgumentDataMember = dt.Columns(0).ColumnName
                                        '            MchartCtrl.Series(i).ValueDataMembers.AddRange({dt.Columns(i).ColumnName})
                                        '            'MchartCtrl.Series(I).Points(0).Color = Color.Green
                                        '            'MchartCtrl.Series(I).Points(1).Color = Color.Red
                                        '        Next

                                        '    End If
                                        '    If False Then
                                        '        'Dim ctrlMChart As MChartControl
                                        '        'ctrlMChart = CType(MchartCtrl, MChartControl)
                                        '        Dim strXAxisName As String
                                        '        'strXAxisName = MchartCtrl._xaxis

                                        '        Dim intColCount As Integer = dt.Columns.Count - 1
                                        '        For i = 1 To intColCount
                                        '            MchartCtrl.Series(i - 1).Points.Clear()
                                        '        Next

                                        '        'Dim myXYDiagram As DevExpress.XtraCharts.XYDiagram
                                        '        'myXYDiagram = CType(MainPage.MChart_Ctrl.Diagram, DevExpress.XtraCharts.XYDiagram)
                                        '        MchartCtrl.Series(0).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical
                                        '        'DataTable contains
                                        '        'Date,Tag1Value,Tag2Value
                                        '        For i = 1 To intColCount
                                        '            If dt.Columns(i).ColumnName = strXAxisName Then
                                        '                MchartCtrl.Series(i).Visible = False
                                        '            Else
                                        '                Dim dblXAxisValue, dblYAxisValue As Double

                                        '                For K = 0 To dt.Rows.Count - 1
                                        '                    If IsDBNull(dt.Rows(K).Item(0)) Or IsDBNull(dt.Rows(K).Item(strXAxisName)) Then
                                        '                        MsgBox("DbNull!")
                                        '                    Else
                                        '                        'dblXAxisValue = dt.Rows(K).Item(strXAxisName)
                                        '                        'dblYAxisValue = dt.Rows(K).Item(I)
                                        '                        'MchartCtrl.Series(I - 1).Points.AddPoint(dblXAxisValue, dblYAxisValue)
                                        '                        MchartCtrl.Series(i - 1).Points.AddPoint(dt.Rows(K).Item(strXAxisName), dt.Rows(K).Item(i))
                                        '                    End If
                                        '                Next
                                        '            End If
                                        '        Next
                                        '    End If

                                        'End If
                                    End If
                                End If

                            End If
                        Next


                    End If
                End If
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_AssigntoControl()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


    End Sub


    Private Sub SAMAHistorianChannels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()

            For i As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                GVChannelsAdd.Rows.Add()

                GVChannelsAdd.Rows(i).Cells(0).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(2).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(3).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(4).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(5).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(6).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(7).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(8).ReadOnly = True

                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(2).Value = MainPage.SAMAHistorian_ChannelList.ChannelReportname(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.SAMAHistorian_ChannelList.ChannelReportDescription(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.SAMAHistorian_ChannelList.ChannelTags(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.SAMAHistorian_ChannelList.ChannelDuration(i)
                GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.SAMAHistorian_ChannelList.ChannelInterval(i)
                GVChannelsAdd.Rows(i).Cells(7).Value = MainPage.SAMAHistorian_ChannelList.ChannelXAxis(i)
                GVChannelsAdd.Rows(i).Cells(8).Value = MainPage.SAMAHistorian_ChannelList.ChannelOperations(i)

            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorianChannelsForm_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

End Class
