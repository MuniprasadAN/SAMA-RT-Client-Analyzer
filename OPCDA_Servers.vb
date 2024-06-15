Public Class OPCDA_Servers


    Private Sub btnChnlAdd_Click(sender As Object, e As EventArgs)
        'Try
        '    Dim i As Integer = 0
        '    If GVChannelsAdd.Rows.Count > 0 Then
        '        If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(1).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(1).Value) Then
        '            i = GVChannelsAdd.Rows.Add()
        '            GVChannelsAdd.Rows(i).Cells(0).Value = i + 1

        '        Else
        '            MsgBox("Empty Fields not Allowed !!!")
        '            Exit Sub
        '        End If
        '    Else
        '        i = GVChannelsAdd.Rows.Add()
        '        GVChannelsAdd.Rows(i).Cells(0).Value = i + 1

        '    End If
        'Catch ex As Exception
        '    MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPC DA Servers:Add_Channel()")
        '    MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        'End Try
    End Sub

    Private Sub btnChnlAdd_Click_1(sender As Object, e As EventArgs) Handles btnChnlAdd.Click
        Try
            Dim addopc As New AddOPC
            addopc.ShowDialog()


            Dim configname As String
            Dim ipaddress As String
            Dim portnumber As String
            Dim refreshinterval As String
            Dim secondaryipaddress As String = "-"
            Dim secondaryportnumber As String = "-"
            Dim i As Integer = GVChannelsAdd.Rows.Count
            If addopc.btnclose Then
                For j As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                    If GVChannelsAdd.Rows(j).Cells(1).Value = addopc.txtbxconfigname.Text Then
                        MsgBox("Same Config Name May Exists in OPCDA Servers List!!! At Row:" & j + 1)
                        Exit Sub
                    End If
                Next
                configname = addopc.txtbxconfigname.Text
                ipaddress = addopc.TxtbxHostname.Text
                portnumber = addopc.TxtbxPortnumber.Text
                refreshinterval = addopc.txtbx_refreshinterval.Text
                If addopc.CBxredundancy.Checked Then
                    secondaryipaddress = addopc.txtbxredundantipaddr.Text
                    secondaryportnumber = addopc.txtbxredundantportno.Text
                Else
                    secondaryipaddress = "-"
                    secondaryportnumber = "-"
                End If
                i += 1

                Dim row As Object() = New Object() {i, configname, ipaddress, portnumber, secondaryipaddress, secondaryportnumber, refreshinterval}
                GVChannelsAdd.Rows.Add(row)

                MsgBox("OPC DA Server Added Successfully!")
            End If

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnChnlApply_Click(sender As Object, e As EventArgs) Handles btnChnlApply.Click
        Try

            MainPage.OPCDAServersList.Configname.Clear()
            MainPage.OPCDAServersList.PrimaryIPAddress.Clear()
            MainPage.OPCDAServersList.PrimaryPortNo.Clear()
            MainPage.OPCDAServersList.SecondaryIPAddress.Clear()
            MainPage.OPCDAServersList.SecondaryPortNo.Clear()
            MainPage.OPCDAServersList.RefreshInterval.Clear()

            'MainPage.OPCDAServersCollection.Clear()

            For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
                If Not MainPage.OPCDAServersList.Configname.Contains(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                    MainPage.OPCDAServersList.Configname.Add(GVChannelsAdd.Rows(i).Cells(1).Value)
                    MainPage.OPCDAServersList.PrimaryIPAddress.Add(GVChannelsAdd.Rows(i).Cells(2).Value)
                    MainPage.OPCDAServersList.PrimaryPortNo.Add(GVChannelsAdd.Rows(i).Cells(3).Value)
                    MainPage.OPCDAServersList.SecondaryIPAddress.Add(GVChannelsAdd.Rows(i).Cells(4).Value)
                    MainPage.OPCDAServersList.SecondaryPortNo.Add(GVChannelsAdd.Rows(i).Cells(5).Value)
                    MainPage.OPCDAServersList.RefreshInterval.Add(GVChannelsAdd.Rows(i).Cells(6).Value)

                    If GVChannelsAdd.Rows(i).Cells(4).Value = "-" Then
                        If MainPage.OPCDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                            Dim tmpopcda As Redundancy = MainPage.OPCDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value)
                            tmpopcda.Refresh_interval = GVChannelsAdd.Rows(i).Cells(6).Value

                            MainPage.OPCDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value) = tmpopcda
                            ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        Else
                            Dim tmpOPCDA As New Redundancy(GVChannelsAdd.Rows(i).Cells(2).Value + ":" + GVChannelsAdd.Rows(i).Cells(3).Value, "", False, MainPage, GVChannelsAdd.Rows(i).Cells(6).Value)
                            tmpOPCDA.Connect()
                            MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        End If
                    Else
                        If MainPage.OPCDAServersCollection.ContainsKey(GVChannelsAdd.Rows(i).Cells(1).Value) Then
                            Dim tmpopcda As Redundancy = MainPage.OPCDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value)
                            tmpopcda.Refresh_interval = GVChannelsAdd.Rows(i).Cells(6).Value


                            MainPage.OPCDAServersCollection(GVChannelsAdd.Rows(i).Cells(1).Value) = tmpopcda
                            ' MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        Else
                            Dim tmpOPCDA As New Redundancy(GVChannelsAdd.Rows(i).Cells(2).Value + ":" + GVChannelsAdd.Rows(i).Cells(3).Value, GVChannelsAdd.Rows(i).Cells(4).Value + ":" + GVChannelsAdd.Rows(i).Cells(5).Value, True, MainPage, GVChannelsAdd.Rows(i).Cells(6).Value)
                            tmpOPCDA.Connect()
                            MainPage.OPCDAServersCollection.Add(GVChannelsAdd.Rows(i).Cells(1).Value, tmpOPCDA)
                        End If
                    End If
                Else
                    MsgBox("Same Config Name May Exists in OPCDA Channels List!!! At Row:" & i + 1)
                    Exit Sub
                End If
            Next
            MsgBox("OPCDA Channels Saved Successfully!")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OPCDA_Servers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GVChannelsAdd.Rows.Clear()

            For i As Integer = 0 To MainPage.OPCDAServersList.Configname.Count - 1
                GVChannelsAdd.Rows.Add()

                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(1).Value = MainPage.OPCDAServersList.Configname(i)
                GVChannelsAdd.Rows(i).Cells(2).Value = MainPage.OPCDAServersList.PrimaryIPAddress(i)
                GVChannelsAdd.Rows(i).Cells(3).Value = MainPage.OPCDAServersList.PrimaryPortNo(i)
                GVChannelsAdd.Rows(i).Cells(4).Value = MainPage.OPCDAServersList.SecondaryIPAddress(i)
                GVChannelsAdd.Rows(i).Cells(5).Value = MainPage.OPCDAServersList.SecondaryPortNo(i)
                GVChannelsAdd.Rows(i).Cells(6).Value = MainPage.OPCDAServersList.RefreshInterval(i)
            Next

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@OPCDA_Servers_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub btnChnlEdit_Click(sender As Object, e As EventArgs) Handles btnChnlEdit.Click
        Try
            If GVChannelsAdd.SelectedRows.Count > 0 Then
                Dim opcdaedit As New AddOPC
                opcdaedit.txtbxconfigname.Text = GVChannelsAdd.SelectedRows(0).Cells(1).Value
                opcdaedit.TxtbxHostname.Text = GVChannelsAdd.SelectedRows(0).Cells(2).Value
                opcdaedit.TxtbxPortnumber.Text = GVChannelsAdd.SelectedRows(0).Cells(3).Value
                opcdaedit.txtbxredundantipaddr.Text = GVChannelsAdd.SelectedRows(0).Cells(4).Value
                opcdaedit.txtbxredundantportno.Text = GVChannelsAdd.SelectedRows(0).Cells(5).Value
                opcdaedit.txtbx_refreshinterval.Text = GVChannelsAdd.SelectedRows(0).Cells(6).Value

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
                    GVChannelsAdd.SelectedRows(0).Cells(6).Value = opcdaedit.txtbx_refreshinterval.Text
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
                    If MainPage.OPCDAServersCollection.ContainsKey(GVChannelsAdd.SelectedRows(0).Cells(1).Value) Then
                        Dim dsd As Redundancy = MainPage.OPCDAServersCollection(GVChannelsAdd.SelectedRows(0).Cells(1).Value)
                        dsd.StopConnecting = True
                        dsd = Nothing
                        MainPage.OPCDAServersCollection.Remove(GVChannelsAdd.SelectedRows(0).Cells(1).Value)
                    End If
                    MsgBox("The Selected Record Deleted successfully")
                End If
            Else
                MsgBox("Please select row to Delete")
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class