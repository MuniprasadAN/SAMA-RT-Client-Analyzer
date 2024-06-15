Public Class BrowseOPCHDA
    Private Sub BrowseOPCHDA_Tags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComBxServer.Items.Clear()
            For i As Integer = 0 To chklstTreeValues.Items.Count - 1
                chklstTreeValues.SetItemChecked(i, False)
            Next
            ComBxServer.Items.AddRange(MainPage.OPCHDAServersList.Configname.ToArray())
        Catch ex As Exception

        End Try


    End Sub
    Dim lst As New List(Of String)
    Dim lstSelectedValues As New List(Of String)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComBxServer.Items.Clear()
        For i As Integer = 0 To chklstTreeValues.Items.Count - 1
            chklstTreeValues.SetItemChecked(i, False)
        Next
        ComBxServer.Items.AddRange(MainPage.OPCHDAServersList.Configname.ToArray())

    End Sub

    Private Sub FilterIt()
        If txtSearchText.Text = "" Then
            chklstTreeValues.Items.Clear()
            chklstTreeValues.Items.AddRange(lst.ToArray)
        Else
            chklstTreeValues.Items.Clear()

            Dim v = From k In lst.ToArray()
                    Where k.IndexOf(txtSearchText.Text, StringComparison.CurrentCultureIgnoreCase) >= 0

            For Each ol In v
                chklstTreeValues.Items.Add(ol)
            Next

        End If

        For jj As Integer = 0 To chklstTreeValues.Items.Count - 1
            '   Debug.Print(chklstTreeValues.Items(jj).ToString)

            If lstSelectedValues.Contains(chklstTreeValues.Items(jj).ToString) Then
                ' Debug.Print(jj & vbTab & chklstTreeValues.Items(jj).ToString)
                chklstTreeValues.SetItemChecked(jj, True)
            Else
                chklstTreeValues.SetItemChecked(jj, False)
            End If
        Next
    End Sub

    Private Sub txtSearchText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchText.KeyPress
        FilterIt()
    End Sub

    Private Sub txtSearchText_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearchText.KeyUp
        FilterIt()
    End Sub

    Private Sub txtSearchText_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchText.KeyDown
        FilterIt()
    End Sub

    Private Sub chklstTreeValues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklstTreeValues.SelectedIndexChanged

    End Sub

    Private Sub chklstTreeValues_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chklstTreeValues.ItemCheck
        Dim val As String = chklstTreeValues.Items(e.Index)


        If e.NewValue Then
            ' Debug.Print(val & vbTab & " Checked")
            If Not lstSelectedValues.Contains(val) Then
                lstSelectedValues.Add(val)
            End If

        Else
            ' Debug.Print(val & vbTab & "UnChecked")
            lstSelectedValues.Remove(val)
        End If
    End Sub

    Private Sub btnbrowsse_Click(sender As Object, e As EventArgs) Handles btnbrowsse.Click
        Try

            Dim indx As Integer = MainPage.OPCHDAServersList.Configname.IndexOf(ComBxServer.Text)

            lst = New List(Of String)
            lstSelectedValues = New List(Of String)
            chklstTreeValues.Items.Clear()

            If indx > -1 Then

                If MainPage.OPCHDAServersList.SecondaryIPAddress(indx) = "-" Then
                    Dim tmpOPCHDA As New HDARedundancy(MainPage.OPCHDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.PrimaryPortNo(indx), "", False, MainPage)
                    tmpOPCHDA.ThreadConnect()
                    System.Diagnostics.Debug.Print(tmpOPCHDA.PrimaryClient.Url)
                    Dim tm As DateTime = Now
                    While True
                        If Not tmpOPCHDA.PrimaryFailed Then
                            Exit While
                        End If

                        If Now > DateAdd(DateInterval.Second, 10, tm) Then
                            Exit While
                        End If
                    End While
                    lst = tmpOPCHDA.GetAllTags
                    chklstTreeValues.Items.AddRange(lst.ToArray)
                Else
                    Dim tmpOPCHDA As New HDARedundancy(MainPage.OPCHDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.PrimaryPortNo(indx), MainPage.OPCHDAServersList.SecondaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.SecondaryPortNo(indx), True, MainPage)
                    tmpOPCHDA.ThreadConnect()
                    Dim tm As DateTime = Now
                    While True
                        If Not tmpOPCHDA.PrimaryFailed Then
                            Exit While
                        End If

                        If Now > DateAdd(DateInterval.Second, 10, tm) Then
                            Exit While
                        End If
                    End While
                    lst = tmpOPCHDA.GetAllTags
                    chklstTreeValues.Items.AddRange(lst.ToArray)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If chklstTreeValues.CheckedItems.Count > 0 Then
                Dim chkitem As New List(Of String)

                For Each ite In chklstTreeValues.CheckedItems
                    chkitem.Add(ite)
                Next

                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(5).Value = CBxLast.Text + " " + CBx_Last.Text
                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(6).Value = CBxIntervalAutoUpd.Text + " " + CBxInterval_AutoUpd.Text
                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(7).Value = DTimeRelative.Value.ToString("HH:mm")
                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(8).Value = CbxXaxis.Text

                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(3).Value = ComBxServer.Text
                OPCHDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(4).Value = String.Join(",", chkitem.ToArray())
                Me.Close()
            Else
                MsgBox("Please select atleast one tag")
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class