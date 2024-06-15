Public Class OPCWriterPropertiesForm
    Private OPC_Chnl_Index_Collection() As Integer
    Friend Channel_Text As String = ""
    Friend btnFont As New Font("Verdana", 9, FontStyle.Regular)

    Private Sub BackColorlbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackColorlbl.Click, forecolorlbl.Click
        Dim ColDialog As New ColorDialog
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
    End Sub
    Private Sub OPCWriterPropertiesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
            ' SAMA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count).Where(Function(f) MainPage.SAMAHistorian_ChannelList.ChannelTags.Count = 1).ToArray
            CBoxActionChannel.Items.Clear()
            For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
                CBoxActionChannel.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
            Next

            'cBoxActionChannel.Items.AddRange(MainPage.OPC_ChannelList_Class.OPC_Channel_Name.ToArray)
            CBoxActionChannel.Text = Channel_Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Dim OPCCtrl As OPCWriterControl = MainPage.OPCWrite_Ctrl
        OPCCtrl.Font = btnFont
        OPCCtrl.Text = txtText.Text
        OPCCtrl.BackColor = BackColorlbl.BackColor
        OPCCtrl.ForeColor = forecolorlbl.BackColor
        OPCCtrl.AccessibleDescription = CBoxActionChannel.Text
        Dim idx = MainPage.OPC_ChannelList_Class.OPC_Channel_Name.IndexOf(CBoxActionChannel.Text)
        If idx <> -1 Then
            OPCCtrl.OPCServerName = MainPage.OPC_ChannelList_Class.OPC_ServerName(idx)
            OPCCtrl.OPCTag = MainPage.OPC_ChannelList_Class.OPC_OPCItems(idx)
            OPCCtrl.OPCValue = txtboxopcvalue.Text
        End If


        If CBoxStyle.Text = "Flat" Then
            OPCCtrl.FlatStyle = FlatStyle.Flat
        ElseIf CBoxStyle.Text = "Popup" Then
            OPCCtrl.FlatStyle = FlatStyle.Popup
        Else
            OPCCtrl.FlatStyle = FlatStyle.Standard
        End If
        Me.Close()
    End Sub

    Private Sub btnTitleFont_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitleFont.Click
        Dim fntDlg As New FontDialog
        fntDlg.ShowColor = True
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString & "," & fntDlg.Color.Name
        End If
    End Sub


End Class