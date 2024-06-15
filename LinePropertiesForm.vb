﻿Public Class LinePropertiesForm
  Private ColDialog As New ColorDialog
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer

    Private slt_Idx As Integer' = 0
    Friend Channel_Text As String = ""
    Private lineElbo_Ctrl As LineElbow

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.close
End Sub

Private Sub lblActiveColor_DoubleClick( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles   lblBackClr.DoubleClick
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
Private Sub LinePropertiesForm_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
    Try
            lineElbo_Ctrl=MainPage.Line_Ctrl
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
        cboxCap.Text=lineElbo_Ctrl.Caps.ToString()
         cboxCapStyle.Text=lineElbo_Ctrl.CapStyle.ToString()
         cboxDirection.Text=lineElbo_Ctrl.DirectionType.ToString()

        Dim cboxClm As New DataGridViewComboBoxColumn
        cboxClm = GVTHValue.Columns("Condition")
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

        Call Properties(lineElbo_Ctrl)
End Sub
    Private Sub Properties(ByVal lineElbo_Ctrl As LineElbow)
    Try
        'BackColor Setting
        
        lineElbo_Ctrl.Gradient_Color1=lblBackClr.BackColor
        lineElbo_Ctrl.D_Color1=lblBackClr.BackColor
       

        If IsNumeric(txtThick.Text) Then
            lineElbo_Ctrl.PenSize=cint(txtThick.Text)
        End If
         
        lineElbo_Ctrl._ThresholdValue.Clear()
        lineElbo_Ctrl._THColor.Clear()
        lineElbo_Ctrl._THCondition.Clear()
        Dim ss() As string= {"=", ">", "<", ">=", "<=", ">=<="}
        For i As Integer = 0 To GVTHValue.Rows.Count - 1
              If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(0).Value) AndAlso ss.Contains(GVTHValue.Rows(i).Cells(0).Value) Then
                 If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(1).Value) Then
                    lineElbo_Ctrl._THCondition.Add(GVTHValue.Rows(i).Cells(0).Value)
                    lineElbo_Ctrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(1).Value )
                    lineElbo_Ctrl._THColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                Else
                    MsgBox("Empty Fields Not Allowed !!!",MsgBoxStyle.Critical)
                Exit sub
                End If
            Else
                 If  Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(0).Value) Then
                    lineElbo_Ctrl._THCondition.Add(GVTHValue.Rows(i).Cells(0).Value)
                    lineElbo_Ctrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(1).Value )
                    lineElbo_Ctrl._THColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                Else
                    MsgBox("Empty Fields Not Allowed !!!",MsgBoxStyle.Critical)
                Exit sub
                End If
           End If
            
        Next




        Select Case cboxCap.Text
            Case "Start Cap"
                lineElbo_Ctrl.Caps= LineElbow.E_Caps.StartCap
            Case "End Cap"
                lineElbo_Ctrl.Caps= LineElbow.E_Caps.EndCap
            Case "Both"
                lineElbo_Ctrl.Caps= LineElbow.E_Caps.Both
            Case Else
                lineElbo_Ctrl.Caps=LineElbow.E_Caps.None
        End Select
        
         Select Case cboxCapStyle.Text
            
            Case "Arrow"
                lineElbo_Ctrl.CapStyle= LineElbow.E_Capstyle.Arrow
            Case "Circle"
                lineElbo_Ctrl.CapStyle= LineElbow.E_Capstyle.Circle
            Case Else
                lineElbo_Ctrl.CapStyle=LineElbow.E_Capstyle.None
        End Select

         Select Case cboxDirection.Text
            Case "Horizontal"
                lineElbo_Ctrl.DirectionType= LineElbow.DirectionTypes.Horizontal
            Case "Vertical"
                lineElbo_Ctrl.DirectionType= LineElbow.DirectionTypes.Vertical
            Case "LeftBottom"
                lineElbo_Ctrl.DirectionType= LineElbow.DirectionTypes.LeftBottom
            Case "LeftBottomTriangle"
                lineElbo_Ctrl.DirectionType= LineElbow.DirectionTypes.LeftBottomTriangle
            Case "RightBottom"
                lineElbo_Ctrl.DirectionType= LineElbow.DirectionTypes.RightBottom
            Case "RightBottomTriangle"
                lineElbo_Ctrl.DirectionType=LineElbow.DirectionTypes.RightBottomTriangle
        End Select
       
        lineElbo_Ctrl.AccessibleDescription = cBoxActionChannel.Text
        Me.close
    Catch ex As Exception
        MsgBox(ex.Message)
    End Try
        
    End Sub

 Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
       
        Dim i As Integer =GVTHValue.Rows.Add()
        GVTHValue.Rows(i).Cells(2).Style.BackColor=Color.Black
         
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If GVTHValue.Rows.Count > 0 AndAlso GVTHValue.CurrentRow.Index <> -1 Then
            GVTHValue.Rows.RemoveAt(GVTHValue.CurrentRow.Index)
        End If

    End Sub
End Class