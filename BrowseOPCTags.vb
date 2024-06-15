Public Class BrowseOPCTags
    Dim lst As New List(Of String)
    Dim lstSelectedValues As New List(Of String)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComBxServer.Items.Clear()
        For i As Integer = 0 To chklstTreeValues.Items.Count - 1
            chklstTreeValues.SetItemChecked(i, False)
        Next
        ComBxServer.Items.AddRange(MainPage.OPCDAServersList.Configname.ToArray())

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

        Dim indx As Integer = MainPage.OPCDAServersList.Configname.IndexOf(ComBxServer.Text)

        lst = New List(Of String)
        lstSelectedValues = New List(Of String)
        chklstTreeValues.Items.Clear()

        If indx > -1 Then

            If MainPage.OPCDAServersList.SecondaryIPAddress(indx) = "-" Then
                Dim tmpOPCDA As New Redundancy(MainPage.OPCDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCDAServersList.PrimaryPortNo(indx), "", False, MainPage, MainPage.OPCDAServersList.RefreshInterval(indx))
                tmpOPCDA.ThreadConnect()
                Dim tm As DateTime = Now
                While True
                    If Not tmpOPCDA.PrimaryFailed Then
                        Exit While
                    End If

                    If Now > DateAdd(DateInterval.Second, 10, tm) Then
                        Exit While
                    End If
                End While
                lst = tmpOPCDA.GetAllTags
                chklstTreeValues.Items.AddRange(lst.ToArray)
            Else
                Dim tmpOPCDA As New Redundancy(MainPage.OPCDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCDAServersList.PrimaryPortNo(indx), MainPage.OPCDAServersList.SecondaryIPAddress(indx) + ":" + MainPage.OPCDAServersList.SecondaryPortNo(indx), True, MainPage, MainPage.OPCDAServersList.RefreshInterval(indx))
                tmpOPCDA.ThreadConnect()
                Dim tm As DateTime = Now
                While True
                    If Not tmpOPCDA.PrimaryFailed Then
                        Exit While
                    End If

                    If Now > DateAdd(DateInterval.Second, 10, tm) Then
                        Exit While
                    End If
                End While
                lst = tmpOPCDA.GetAllTags
                chklstTreeValues.Items.AddRange(lst.ToArray)
            End If





        End If


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim chkitem As New List(Of String)

            For Each ite In chklstTreeValues.CheckedItems
                chkitem.Add(ite)
            Next
            If chklstTreeValues.CheckedItems.Count > 1 Then
                OPCDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(8).Value = "True"
            Else
                OPCDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(8).Value = "False"
            End If
            OPCDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(3).Value = ComBxServer.Text
            OPCDA_ChannelsList.GVChannelsAdd.CurrentRow.Cells(4).Value = String.Join(",", chkitem.ToArray())
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class