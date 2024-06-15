Public Class buttonPropertiesForm
    Friend btnFont As new Font("Verdana",9,FontStyle.Regular)

Private Sub BackColorlbl_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles BackColorlbl.Click,forecolorlbl.Click
        Dim ColDialog As New ColorDialog
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
End Sub

Private Sub CBoxActionType_SelectedIndexChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CBoxActionType.SelectedIndexChanged
    Try
            Select Case CBoxActionType.Text
                Case "Change Page"
                    cBoxComponent.Enabled = True
                    cBoxComponent.Items.Clear()
                    For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes(2).Nodes.Count - 1
                        cBoxComponent.Items.Add(MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(i).Text)
                    Next
                Case "Print"

                    cBoxComponent.Enabled = True
                    cBoxComponent.Items.Clear()

                    For i As Integer = 0 To MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
                        Dim pnlObj() As Control
                        pnlObj = MainPage.Controls.Find("pnlPage" & i + 1, True)
                        If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                            'Get All Controls from  Pnl_Obj(0)
                            For Each Fcontrols In pnlObj(0).Controls
                                If (TypeOf Fcontrols Is ChartControl) Then
                                    cBoxComponent.Items.Add(Fcontrols.name)
                                End If
                                If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                    cBoxComponent.Items.Add(Fcontrols.name)
                                End If
                            Next
                        End If
                    Next
                Case "Export"

                    cBoxComponent.Enabled = True
                    cBoxComponent.Items.Clear()

                    For i As Integer = 0 To MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
                        Dim pnlObj() As Control
                        pnlObj = MainPage.Controls.Find("pnlPage" & i + 1, True)
                        If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                            'Get All Controls from  Pnl_Obj(0)
                            For Each Fcontrols In pnlObj(0).Controls
                                If (TypeOf Fcontrols Is ChartControl) Then
                                    cBoxComponent.Items.Add(Fcontrols.name)
                                End If
                                If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                                    cBoxComponent.Items.Add(Fcontrols.name)
                                End If
                            Next
                        End If
                    Next

                Case 3
                    cBoxComponent.Enabled = False

                Case 4

                    cBoxComponent.Enabled = True
                    cBoxComponent.Items.Clear()

                    cBoxComponent.Items.AddRange(MainPage.OPC_ChannelList_Class.OPC_Channel_Name.ToArray)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
    End Try
       
End Sub

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.close
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
        
         MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Dim btnCtrl As Button_Control=MainPage.Button_Ctrl
        btnCtrl.Font=btnFont
        btnCtrl.Text=txtText.Text
        btnCtrl.BackColor=backcolorlbl.BackColor
        btnCtrl.ForeColor=forecolorlbl.BackColor
        btnCtrl.Action_Type=CBoxActionType.Text
        btnCtrl.Action_Ctrl=cBoxComponent.Text

        If CBoxStyle.Text="Flat" Then
            btnCtrl.FlatStyle=FlatStyle.Flat
        ElseIf CBoxStyle.Text="Popup" Then
            btnCtrl.FlatStyle=FlatStyle.Popup
        Else
            btnCtrl.FlatStyle=FlatStyle.Standard
        End If
        Me.Close()
End Sub

Private Sub btnTitleFont_Click_1( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnTitleFont.Click
         Dim fntDlg As New FontDialog
        fntDlg.ShowColor = True
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString & "," & fntDlg.Color.Name
        End If
    End Sub

End Class