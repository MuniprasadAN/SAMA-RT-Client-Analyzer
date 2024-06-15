Public Class OPCHDA_Servers
    Private Sub btnChnlAdd_Click(sender As Object, e As EventArgs) Handles btnChnlAdd.Click
        Try
            Dim addopc As New AddOPC
            addopc.Text = "Add/Edit OPC HDA"

            addopc.txtbx_refreshinterval.Visible = False
            addopc.lblmillisecs.Visible = False
            addopc.lblrefreshinterval.Visible = False

            addopc.ShowDialog()

            Dim configname As String
            Dim ipaddress As String
            Dim portnumber As String
            Dim secondaryipaddress As String = "-"
            Dim secondaryportnumber As String = "-"
            Dim i As Integer = GVChannelsAdd.Rows.Count
            If addopc.btnclose Then
                For j As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                    If GVChannelsAdd.Rows(j).Cells(1).Value = addopc.txtbxconfigname.Text Then
                        MsgBox("Same Config Name May Exists in OPCHDA Servers List!!! At Row:" & j + 1)
                        Exit Sub
                    End If
                Next
                configname = addopc.txtbxconfigname.Text
                ipaddress = addopc.TxtbxHostname.Text
                portnumber = addopc.TxtbxPortnumber.Text
                If addopc.CBxredundancy.Checked Then
                    secondaryipaddress = addopc.txtbxredundantipaddr.Text
                    secondaryportnumber = addopc.txtbxredundantportno.Text
                Else
                    secondaryipaddress = "-"
                    secondaryportnumber = "-"
                End If
                i += 1

                Dim row As Object() = New Object() {i, configname, ipaddress, portnumber, secondaryipaddress, secondaryportnumber}
                GVChannelsAdd.Rows.Add(row)

                MsgBox("OPC HDA Server Added Successfully!")
            End If

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnChnlApply_Click(sender As Object, e As EventArgs) Handles btnChnlApply.Click
        Try
            MainPage.OPCHDAServersList.Configname.Clear()
            MainPage.OPCHDAServersList.PrimaryIPAddress.Clear()
            MainPage.OPCHDAServersList.PrimaryPortNo.Clear()
            MainPage.OPCHDAServersList.SecondaryIPAddress.Clear()
            MainPage.OPCHDAServersList.SecondaryPortNo.Clear()

            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not MainPage.OPCHDAServersList.Configname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                    MainPage.OPCHDAServersList.Configname.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                    MainPage.OPCHDAServersList.PrimaryIPAddress.Add(GVChannelsAdd.Rows(i).Cells(2).Value)
                    MainPage.OPCHDAServersList.PrimaryPortNo.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                    MainPage.OPCHDAServersList.SecondaryIPAddress.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                    MainPage.OPCHDAServersList.SecondaryPortNo.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                    If GVChannelsAdd.Rows(i).Cells(4).Value = "-" Then
                        If MainPage.OPCHDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                            Dim tmpopchda As HDARedundancy = MainPage.OPCHDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value)

                            MainPage.OPCHDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value) = tmpopchda
                            ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        Else
                            Dim tmpOPCHDA As New HDARedundancy(GVChannelsAdd.Rows(i).Cells(2).Value + ":" + GVChannelsAdd.Rows(i).Cells(3).Value, "", False, MainPage)
                            tmpOPCHDA.Connect()
                            MainPage.OPCHDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCHDA)
                        End If
                    Else
                        If MainPage.OPCHDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                            Dim tmpopchda As HDARedundancy = MainPage.OPCHDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value)

                            MainPage.OPCHDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value) = tmpopchda
                            ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        Else
                            Dim tmpOPCHDA As New HDARedundancy(GVChannelsAdd.Rows(i).Cells(2).Value + ":" + GVChannelsAdd.Rows(i).Cells(3).Value, GVChannelsAdd.Rows(i).Cells(4).Value + ":" + GVChannelsAdd.Rows(i).Cells(5).Value, True, MainPage)
                            tmpOPCHDA.Connect()
                            MainPage.OPCHDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCHDA)
                        End If
                    End If
                Else
                    MsgBox("Same Config Name May Exists in OPCHDA Servers List!!! At Row:" & i + 1)
                    Exit Sub

                End If
            Next
            MsgBox("OPC HDA Servers Configuration Saved Successfully!")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OPCHDA_Servers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()

            For i As Integer = 0 To MainPage.OPCHDAServersList.Configname.Count - 1
                GVChannelsAdd.Rows.Add()

                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.OPCHDAServersList.Configname(i)
                GVChannelsAdd.Rows(i).Cells(2).Value = MainPage.OPCHDAServersList.PrimaryIPAddress(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.OPCHDAServersList.PrimaryPortNo(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.OPCHDAServersList.SecondaryIPAddress(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.OPCHDAServersList.SecondaryPortNo(i)
            Next

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCHDA_Servers_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub btnChnlEdit_Click(sender As Object, e As EventArgs) Handles btnChnlEdit.Click
        Try
            If GVChannelsAdd.SelectedRows.Count > 0 Then
                Dim opcdaedit As New AddOPC
                opcdaedit.Text = "Add/Edit OPC HDA"
                opcdaedit.txtbxconfigname.Text = GVChannelsAdd.SelectedRows(0).Cells(1).Value
                opcdaedit.TxtbxHostname.Text = GVChannelsAdd.SelectedRows(0).Cells(2).Value
                opcdaedit.TxtbxPortnumber.Text = GVChannelsAdd.SelectedRows(0).Cells(3).Value
                opcdaedit.txtbxredundantipaddr.Text = GVChannelsAdd.SelectedRows(0).Cells(4).Value
                opcdaedit.txtbxredundantportno.Text = GVChannelsAdd.SelectedRows(0).Cells(5).Value

                opcdaedit.txtbx_refreshinterval.Visible = False
                opcdaedit.lblmillisecs.Visible = False
                opcdaedit.lblrefreshinterval.Visible = False

                If GVChannelsAdd.SelectedRows(0).Cells(4).Value = "-" Then
                    opcdaedit.CBxredundancy.Checked = False
                Else
                    opcdaedit.CBxredundancy.Checked = True
                End If
                opcdaedit.btnadd.Text = "Update"
                opcdaedit.ShowDialog()


                If opcdaedit.btnupdate And opcdaedit.btnclose Then
                    GVChannelsAdd.SelectedRows(0).Cells(1).Value = opcdaedit.txtbxconfigname.Text
                    GVChannelsAdd.SelectedRows(0).Cells(2).Value = opcdaedit.TxtbxHostname.Text
                    GVChannelsAdd.SelectedRows(0).Cells(3).Value = opcdaedit.TxtbxPortnumber.Text
                    If opcdaedit.CBxredundancy.Checked Then
                        GVChannelsAdd.SelectedRows(0).Cells(4).Value = opcdaedit.txtbxredundantipaddr.Text
                        GVChannelsAdd.SelectedRows(0).Cells(5).Value = opcdaedit.txtbxredundantportno.Text
                    Else
                        GVChannelsAdd.SelectedRows(0).Cells(4).Value = "-"
                        GVChannelsAdd.SelectedRows(0).Cells(5).Value = "-"
                    End If
                End If
            Else
                MsgBox("Please select row to Edit")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChnlDelete_Click(sender As Object, e As EventArgs) Handles btnChnlDelete.Click
        Try
            Dim result As DialogResult
            If GVChannelsAdd.SelectedRows.Count > 0 Then
                result = MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo, "Confirm Delete")
                If result = MsgBoxResult.Yes Then
                    GVChannelsAdd.Rows.Remove(GVChannelsAdd.SelectedRows(0))
                    MsgBox("The Selected Record Deleted successfully")
                End If
            Else
                MsgBox("Please select row to Delete")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class