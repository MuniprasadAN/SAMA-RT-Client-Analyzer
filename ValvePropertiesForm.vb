Public Class ValvePropertiesForm
Private ColDialog As New ColorDialog
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer
    Private slt_Idx As Integer' = 0
    Friend Channel_Text As String = ""
    Private Valve_Ctl As Valve

Private Sub btnDelete_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnDelete.Click
       
         If GVTHValue.Rows.Count > 0 AndAlso GVTHValue.CurrentRow.Index <> -1 Then
            GVTHValue.Rows.RemoveAt(GVTHValue.CurrentRow.Index)
        End If

End Sub

Private Sub btnadd_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnadd.Click
          Dim i As Integer =GVTHValue.Rows.Add()
        GVTHValue.Rows(i).Cells(2).Style.BackColor=Color.Black
End Sub

Private Sub lblBackClr_DoubleClick( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles lblBackClr.DoubleClick
         ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
End Sub
    Private Sub GVTHValue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GVTHValue.CellDoubleClick
        If GVTHValue.CurrentCell.ColumnIndex = 2  Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub

Private Sub ValvePropertiesForm_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
    Try
            Valve_Ctl=MainPage.Valve_Ctrl
        DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Process")).ToArray
        OPC_Chnl_Index_Collection= Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f)=False).ToArray
        cBoxActionChannel.Items.Clear()
        For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
        Next
            For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
                CBoxActionChannel.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
            Next

            OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray
            For i As Integer = 0 To OPCDA_Chnl_Index_Collection.Length - 1
                cBoxActionChannel.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(OPCDA_Chnl_Index_Collection(i)))
            Next
            cBoxActionChannel.Text = Channel_Text
      

         Dim cboxClm As New DataGridViewComboBoxColumn
        cboxClm = GVTHValue.Columns(0)
        cboxClm.Items.AddRange(New String() {"=", ">", "<", ">=", "<=", ">=<=","Alarm","Normal","Ack","Return & Reset","Return & not Reset"})
    Catch ex As Exception
        MsgBox(ex.Message)
    End Try
         
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
  MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Call Properties(Valve_Ctl)
End Sub
Private Sub Properties(ByVal Valve_Ctrl As Valve )
    Try
         'BackColor Setting
        
        Valve_Ctrl.Gradient_Color1=lblBackClr.BackColor
        Valve_Ctrl.D_Color1=lblBackClr.BackColor
       

      
         
        Valve_Ctrl._ThresholdValue.Clear()
        Valve_Ctrl._THColor.Clear()
        Valve_Ctrl._THCondition.Clear()
       Dim ss() As string= {"=", ">", "<", ">=", "<=", ">=<="}
        For i As Integer = 0 To GVTHValue.Rows.Count - 1
             If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(0).Value) AndAlso ss.Contains(GVTHValue.Rows(i).Cells(0).Value) Then
                 If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(1).Value) Then
                Valve_Ctrl._THCondition.Add(GVTHValue.Rows(i).Cells(0).Value)
                Valve_Ctrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(1).Value )
                Valve_Ctrl._THColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                Else
                    MsgBox("Empty Fields Not Allowed !!!",MsgBoxStyle.Critical)
                Exit sub
                End If
            Else
                 If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(0).Value) Then
                  Valve_Ctrl._THCondition.Add(GVTHValue.Rows(i).Cells(0).Value)
                Valve_Ctrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(1).Value )
                Valve_Ctrl._THColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                Else
                    MsgBox("Empty Fields Not Allowed !!!",MsgBoxStyle.Critical)
                Exit sub
                End If
           End If
        Next




      
        Valve_Ctrl.AccessibleDescription = cBoxActionChannel.Text
        Me.close
    Catch ex As Exception
        MsgBox(ex.Message)
    End Try
       
    End Sub

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
End Sub
End Class