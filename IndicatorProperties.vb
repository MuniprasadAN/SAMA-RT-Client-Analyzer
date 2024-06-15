Public Class IndicatorProperties
    Private ColDialog As New ColorDialog
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer

    Private slt_Idx As Integer' = 0
    Friend Channel_Text As String = ""
Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.close
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Call Properties(MainPage.LevelIndicator_ctrl)
End Sub
    Private Sub Properties(ByVal lvlindicator_Ctrl As LevelIndicator)
        'BackColor Setting
        lvlindicator_Ctrl.InActiveColor = lblCtrlBackColor.BackColor
        lvlindicator_Ctrl.ForeColor = forecolorlbl.BackColor
        lvlindicator_Ctrl.ActiveColor= lblactivecolor.BackColor
     
        lvlindicator_Ctrl.RangeStart=txtStart.Text
        lvlindicator_Ctrl.RangeEnd=txtEnd.Text

        If cint(txtlvlCount.Text) >0 Then
             lvlindicator_Ctrl.LevelsCount=txtlvlCount.Text
        Else
             lvlindicator_Ctrl.LevelsCount=1
        End If
       
       
        lvlindicator_Ctrl.Scale_Enabled=CKboxScaleEnable.CheckState
        

       
        lvlindicator_Ctrl.AccessibleDescription = cBoxActionChannel.Text
        Me.close
    End Sub

Private Sub IdicatorProperties_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
        'DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Value")).ToArray
        OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
        OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray

        cBoxActionChannel.Items.Clear()
        'For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
        '    cBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
        'Next
        For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
            CBoxActionChannel.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
        Next


        For i As Integer = 0 To OPCDA_Chnl_Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(OPCDA_Chnl_Index_Collection(i)))
        Next

        cBoxActionChannel.Text = Channel_Text
End Sub

Private Sub lblActiveColor_DoubleClick( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles lblCtrlBackColor.DoubleClick, lblActiveColor.DoubleClick, forecolorlbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
End Sub
End Class