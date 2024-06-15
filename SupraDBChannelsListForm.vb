Imports System.Data.SqlClient

''' <summary>
''' 	
''' </summary>
Public Class SupraDBChannelsListForm

    Private DataSourceClm As New DataGridViewComboBoxColumn
    Private AL_ChList As New ArrayList

    Private Sub btnChnlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlAdd.Click
        Dim i As Integer = 0
        If GVChannelsAdd.Rows.Count <> 0 Then
            If Not  String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(3).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(1).Value) Then
                i = GVChannelsAdd.Rows.Add()
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(6).Value =5
            Else
                MsgBox("Empty Fields not Allowed !!!")
                Exit Sub
            End If
        Else
            i = GVChannelsAdd.Rows.Add()
            GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
            GVChannelsAdd.Rows(i).Cells(6).Value = 5
        End If
    End Sub

    Private Sub wk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GVChannelsAdd.Rows.Clear()
        If MainPage.blnDB_AllowClients Then
            ckBox_DBAllowClients.Checked=True
        End If
       If Not MainPage.Server_Flag Then
            ckBox_DBAllowClients.Enabled=False
        Else
            ckBox_DBAllowClients.Enabled=True
       End If

        For i As Integer = 0 To MainPage.channelList.Channel_Name.Count - 1
            GVChannelsAdd.Rows.Add()
            If Not MainPage.Server_Flag Then
                GVChannelsAdd.Rows(i).Cells(0).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(1).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(3).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(4).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(5).ReadOnly = True
                GVChannelsAdd.Rows(i).Cells(6).ReadOnly = True
            End If
            GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
            GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.channelList.Channel_Name(i)
            GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.channelList.Channel_Query(i)
            GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.channelList.Channel_Flag(i)
            GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.channelList._Query_Channel(i)
            GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.channelList.DBChannel_RefreshTime(i)
        Next
    End Sub

  Private Sub Apply_Channel()
        Try
            MainPage.channelList.Channel_Name.Clear()
            MainPage.channelList.Channel_Query.Clear()
            MainPage.channelList.Channel_Flag.Clear()
            MainPage.channelList._Query_Channel.Clear()
            MainPage.channelList.DBChannel_RefreshTime.Clear()
            MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes.Clear()
        

        If Not MainPage.DBDataFormClass Is Nothing Then
            For i As Integer = 0 To MainPage.DBDataFormClass.Length - 1
                If Not MainPage.DBDataFormClass(i) Is Nothing Then
                    MainPage.DBDataFormClass(i).Q_Timer.Dispose() 'Dispose Timer
                    MainPage.DBDataFormClass(i).Watcher.Dispose() 'Dispose FileWatcher
                     MainPage.DBDataFormClass(i).Close()'Close Instance DBDataForm
                End If
            Next
        End If
    
        ReDim MainPage.DBDataFormClass(GVChannelsAdd.Rows.Count - 1)

        For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
            If  (Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(1).Value)) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(3).Value) Then
                If Not AL_ChList.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) And Not MainPage.OPC_ChannelList_Class.OPC_Channel_Name.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) and Not MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                    Dim rfTime As Integer
                    rfTime = CInt(GVChannelsAdd.Rows(i).Cells(6).Value) * 1000

                        Dim AnnunciatorName = GVChannelsAdd.Rows(i).Cells(4).Value
                        If MainPage.Server_Flag Then
                            If AnnunciatorName = "Annunciator" Then
                                MainPage.DBDataFormClass(i) = New DBDataForm(AnnunciatorName, GVChannelsAdd.Rows(i).Cells(5).Value, rfTime, MainPage.Constr, 1, GVChannelsAdd.Rows(i).Cells(1).Value) 'Create Instace Class to each Query
                            ElseIf AnnunciatorName = "Grid" Then
                                MainPage.DBDataFormClass(i) = New DBDataForm(AnnunciatorName, GVChannelsAdd.Rows(i).Cells(5).Value, rfTime, MainPage.Constr, 1, GVChannelsAdd.Rows(i).Cells(1).Value) 'Create Instace Class to each Query
                            Else
                                MainPage.DBDataFormClass(i) = New DBDataForm(AnnunciatorName, GVChannelsAdd.Rows(i).Cells(5).Value, rfTime, MainPage.Constr, 0, GVChannelsAdd.Rows(i).Cells(1).Value) 'Create Instace Class to each Query
                            End If
                        End If

                        MainPage.DBDataFormClass(i).Tag = i
                    MainPage.DBDataFormClass(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                    MainPage.DBDataFormClass(i).AllowTransparency=True
                    MainPage.DBDataFormClass(i).Show()
                    MainPage.DBDataFormClass(i).Visible = False
                    MainPage.DBDataFormClass(i).AllowTransparency=False


                    MainPage.channelList.Channel_Name.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                    MainPage.channelList.Channel_Query.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                    MainPage.channelList.Channel_Flag.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                    MainPage.channelList._Query_Channel.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                    MainPage.channelList.DBChannel_RefreshTime.Add(GVChannelsAdd.Rows(i).Cells(6).Value)

                    MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                    MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes(i).Name = GVChannelsAdd.Rows(i).Cells(1).Value
                    MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes(i).Tag ="True"

                Else
                    MsgBox("Same Channel Name May Exixt in Supra DB Channel/OPC Channel/SAMA Historian Channel  !!! At Row:" & i + 1)
                    Exit Sub
                End If
                AL_ChList.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
            Else
                MsgBox("Empty Fields not Allowed !!!")
                Exit Sub
            End If

        Next
        For i As Integer = 0 To MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes.Count - 1 'Set Image to Supra DB Channel node
            MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes(i).ImageIndex = 4
            MainPage.PageTreeView.Nodes(0).Nodes(0).Nodes(i).SelectedImageIndex = 4
        Next
        MainPage.PageTreeView.Nodes(0).Nodes(0).ExpandAll()
        Me.Close()
        Catch ex As Exception
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@SupraDB:Apply_Channel()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
  End Sub

    private Sub btnChnlApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlApply.Click
        AL_ChList.Clear()
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Apply_Channel()
    End Sub

    Private Sub btnChnlDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlDelete.Click
        If GVChannelsAdd.Rows.Count > 0 Then
            Dim i = GVChannelsAdd.CurrentRow.Index
            GVChannelsAdd.Rows.RemoveAt(i)
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GVChannelsAdd_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GVChannelsAdd.MouseClick
        Try
            If GVChannelsAdd.CurrentCell.ColumnIndex = 2 Then
                If Not MainPage.Server_Flag Then
                    MsgBox("Sorry !!! Cannot Configure the Client!!!", MsgBoxStyle.Critical, "Warning!!!")
                ElseIf MainPage.Lst_TableName Is Nothing Or Not MainPage.Lst_TableName.Count > 0 Then
                    MsgBox("Sorry !!! No Server/Tables available !!!", MsgBoxStyle.Critical, "Warning!!!")
                Else
                    Dim idx As Integer = GVChannelsAdd.CurrentRow.Index
                    Dim _Exp As String = ""
                    Dim alExp() As String
                    Dim typeSplit As String
                    If (Not GVChannelsAdd.CurrentRow.Cells(4).Value Is Nothing AndAlso Not String.IsNullOrEmpty(GVChannelsAdd.CurrentRow.Cells(4).Value)) Then
                        typeSplit = GVChannelsAdd.CurrentRow.Cells(4).Value
                        If typeSplit = "Grid" Then
                            DBQueryForm.rdobtnDisplay.Checked = True
                            _Exp = GVChannelsAdd.Rows(idx).Cells(3).Value
                            alExp = _Exp.Split("@")
                            If alExp(0) = "0" Then
                                DBQueryForm.ckBoxbuild_Fun.Checked = True
                                DBQueryForm.cboxBuildFunction.Text = alExp(1)
                            Else
                                DBQueryForm.ckBoxbuild_Fun.CheckState = CheckState.Unchecked
                                Dim arrField() As String = alExp(1).Split(",")
                                DBQueryForm.AL_Fields.Clear()
                                For i As Integer = 0 To arrField.Length - 1
                                    Dim id As Integer = DBQueryForm.CKlstBox__Fields.Items.IndexOf(arrField(i))
                                    DBQueryForm.blnField = True
                                    DBQueryForm.AL_Fields.Add(id)
                                Next
                            End If
                            If alExp(2) = "0" Then
                                DBQueryForm.rdobtnnnDays.Checked = True
                                DBQueryForm.txtBoxnnDays.Text = alExp(3)
                            Else
                                DBQueryForm.rdobtnnnRec.Checked = True
                                DBQueryForm.txtBoxnnRec.Text = alExp(3)
                            End If
                            DBQueryForm.rtBoxCondition.Text = alExp(4)
                        End If

                        If typeSplit = "Annunciator" Then
                            DBQueryForm.rdobtnAnnunciator.Checked = True
                            _Exp = GVChannelsAdd.Rows(idx).Cells(5).Value
                            Dim TagParam = _Exp.Split("^")
                            alExp = TagParam(1).Split(",")
                            'If alExp(0) = "0" Then
                            If TagParam(0) = "Tagpar_AliasName" Then
                                DBQueryForm.chkAliasNameView.Checked = True
                                DBQueryForm.chkTagParView.Checked = True
                            ElseIf TagParam(0) = "AliasName" Then
                                DBQueryForm.chkAliasNameView.Checked = True
                            ElseIf TagParam(0) = "Tagpar" Then
                                DBQueryForm.chkTagParView.Checked = True
                            Else
                                DBQueryForm.chkTagParView.Checked = False
                                DBQueryForm.chkAliasNameView.Checked = Falses
                            End If
                            DBQueryForm.LstBoxSelectValue.Items.Clear()
                            DBQueryForm.GrpBoxAnnunciator.Visible = True
                            DBQueryForm.GrpBoxSelect.Enabled = False
                            DBQueryForm.grpBoxFunction.Enabled = False
                            DBQueryForm.rdobtnnnDays.Enabled = False
                            DBQueryForm.rdobtnnnRec.Enabled = True

                            For k = 0 To alExp.Length - 1
                                DBQueryForm.rdobtnnnRec.Checked = True
                                DBQueryForm.LstBoxSelectValue.Items.Add(alExp(k))
                            Next
                            Dim Annunfield = DBQueryForm.CBoxAnnunFields.Text
                            Dim AnnunValue = DBQueryForm.CBoxAnnunValue.Text
                            If Annunfield <> "" Then
                                DBQueryForm.LoadAnnun_TagValue(Annunfield, AnnunValue)
                            End If

                        End If

                        If typeSplit = "Value" Then
                            DBQueryForm.rdobtnValue.Checked = True
                            _Exp = GVChannelsAdd.Rows(idx).Cells(3).Value
                            alExp = _Exp.Split("@")
                            Dim fn As String, fld As String

                            If alExp(0) = "0" Then
                                fn = alExp(1).Substring(0, InStr(alExp(1), "(", CompareMethod.Text) - 1)
                                fld = alExp(1).Split("(")(1).Replace(")", "").Trim
                                DBQueryForm.cboxFunction.SelectedItem = fn
                                DBQueryForm.cboxFunField.SelectedItem = fld
                                If alExp(2) = "0" Then
                                    DBQueryForm.rdobtnnnDays.Checked = True
                                    DBQueryForm.txtBoxnnDays.Text = alExp(3)
                                Else
                                    DBQueryForm.rdobtnnnRec.Checked = True
                                    DBQueryForm.txtBoxnnRec.Text = alExp(3)
                                End If
                                DBQueryForm.rtBoxCondition.Text = alExp(4)
                            Else
                                DBQueryForm.cboxFunction.SelectedItem = alExp(1)
                                If alExp(2) = "0" Then
                                    DBQueryForm.rdobtnnnDays.Checked = True
                                    DBQueryForm.txtBoxnnDays.Text = alExp(3)
                                Else
                                    DBQueryForm.rdobtnnnRec.Checked = True
                                    DBQueryForm.txtBoxnnRec.Text = alExp(3)
                                End If
                                DBQueryForm.rtBoxCondition.Text = alExp(4)
                            End If


                        End If
                        If typeSplit = "Trend" Then
                            DBQueryForm.rdobtnTrend.Checked = True
                            _Exp = GVChannelsAdd.Rows(idx).Cells(3).Value
                            alExp = _Exp.Split("@")
                            DBQueryForm.cboxFunction.SelectedItem = alExp(1)
                            If alExp(2) = "0" Then
                                DBQueryForm.rdobtnnnDays.Checked = True
                                DBQueryForm.txtBoxnnDays.Text = alExp(3)
                            Else
                                DBQueryForm.rdobtnnnRec.Checked = True
                                DBQueryForm.txtBoxnnRec.Text = alExp(3)
                            End If
                            DBQueryForm.rtBoxCondition.Text = alExp(4)



                        End If

                    End If
                    DBQueryForm.ShowDialog()

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Dt As New DataTable
    Private Ds As New DataSet

    Private Sub DTColumn()
        Dt.Columns.Add(New DataColumn("Channel_Name", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("ChannelQuery", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("ChannelType", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("_DBQuery", Type.GetType("System.String")))
        Dt.Columns.Add(New DataColumn("DBChannel_RefreshTime", Type.GetType("System.String")))
    End Sub
    Private Sub ProcOpcChannelSave()
        Dim dr As DataRow
        Dt = New DataTable
        Ds = New DataSet
        Call DTColumn()
        For i As Integer = 0 To MainPage.channelList.Channel_Name.Count - 1
            dr = Dt.NewRow()
            dr("Channel_Name") = MainPage.channelList.Channel_Name(i)
            dr("ChannelQuery") = MainPage.channelList.Channel_Query(i)
            dr("ChannelType") = MainPage.channelList.Channel_Flag(i)
            dr("_DBQuery") = MainPage.channelList._Query_Channel(i)
            dr("DBChannel_RefreshTime") = MainPage.channelList.DBChannel_RefreshTime(i)
            Dt.Rows.Add(dr)
        Next
        Ds.Tables.Add(Dt)
        Ds.Tables(0).TableName = "Channel"
       
    End Sub
    Private Sub btnChnlExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlExport.Click
        Dim fname As String = ""
        Dim savedlg As New SaveFileDialog
        savedlg.Filter = "Supra DB Channel File (*.XML)|*.xml"
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
                MainPage.MyEncryptor(Ds,fname)
                MsgBox("Done")
            ElseIf Not (Not fname Is Nothing AndAlso String.IsNullOrEmpty(fname)) Then
                If MsgBox("Do you Want to Replace....", MsgBoxStyle.YesNo, "Confirm...") = MsgBoxResult.Yes Then
                    'Ds.WriteXml(fname)
                    MainPage.MyEncryptor(Ds,fname)
                    MsgBox("Done")
                End If
            End If
        End If
    End Sub

    Private Sub btnChnlimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlimport.Click
        Try
            Dim openSavedlg As New OpenFileDialog
            openSavedlg.Filter = "Supra DB Channel File (*.XML)|*.xml"
            openSavedlg.FilterIndex = 0
            If openSavedlg.ShowDialog = DialogResult.OK Then
                If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                    Ds = New DataSet
                    'Ds.ReadXml(openSavedlg.FileName)
                     Mainpage.MyDecryptor(ds,openSavedlg.FileName)
                    For i As Integer = 0 To Ds.Tables.Count - 1
                        Dt = New DataTable()
                        Dt = Ds.Tables(i).DefaultView.ToTable(True)
                        Dt.AcceptChanges()
                        If Ds.Tables(i).TableName = "Channel" Then
                            AddDBChannel(Dt)
                        Else
                            MsgBox("Not a valid Supra DB Channel file", MsgBoxStyle.Critical, "Warning !!!")
                        End If
                    Next
                Else
                    MsgBox("File Name Required !!")
                End If
            End If
        Catch ex As Exception
           
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@btnChnlimport_Click()")
              Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
    End Sub

    Private Sub AddDBChannel(ByVal Dt As DataTable)
        GVChannelsAdd.Rows.Clear()
        For i As Integer = 0 To Dt.Rows.Count - 1
            GVChannelsAdd.Rows.Add()
            GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
            GVChannelsAdd.Rows(i).Cells(1).Value = (Dt.Rows(i).Item("Channel_Name"))
            GVChannelsAdd.Rows(i).Cells(3).Value = (Dt.Rows(i).Item("ChannelQuery"))
            GVChannelsAdd.Rows(i).Cells(4).Value = (Dt.Rows(i).Item("ChannelType"))
            GVChannelsAdd.Rows(i).Cells(5).Value = (Dt.Rows(i).Item("_DBQuery"))
            GVChannelsAdd.Rows(i).Cells(6).Value = (Dt.Rows(i).Item("DBChannel_RefreshTime"))
        Next
    End Sub

Private Sub ckBox_OPCAllowClients_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles ckBox_DBAllowClients.CheckedChanged
        If ckBox_DBAllowClients.Checked Then
             if Not IO.Directory.Exists(Application.StartupPath & "\RemoteData") Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\RemoteData")
            End If
            Mainpage.blnDB_AllowClients=True
        Else
            Mainpage.blnDB_AllowClients=False
        End If
End Sub

    Private Sub GVChannelsAdd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GVChannelsAdd.CellContentClick

    End Sub

    Private Sub GVChannelsAdd_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles GVChannelsAdd.DataBindingComplete

    End Sub

    Private Sub pnlChnlTop_Paint(sender As Object, e As PaintEventArgs) Handles pnlChnlTop.Paint

    End Sub
End Class