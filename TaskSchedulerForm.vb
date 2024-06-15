Imports System.Windows.Forms.DataVisualization.Charting
Namespace tt

End NameSpace
Public Class TaskSchedulerForm
    Private CboxClm As New DataGridViewComboBoxColumn
    
    Private Sub btnChnlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChnlAdd.Click
        Dim i As Integer = 0
        If GVChannelsAdd.Rows.Count <> 0 Then
            If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(2).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(3).Value) _
            And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(GVChannelsAdd.Rows.Count - 1).Cells(4).Value) Then

                i = GVChannelsAdd.Rows.Add()
                GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
                GVChannelsAdd.Rows(i).Cells(6).Value = Now
            Else
                MsgBox("Empty Fields not Allowed !!!")
                Exit Sub
            End If
        Else
            i = GVChannelsAdd.Rows.Add()
            GVChannelsAdd.Rows(i).Cells(0).Value = i + 1
            GVChannelsAdd.Rows(i).Cells(6).Value = Now
        End If
    End Sub

    Private Sub TaskSchedulerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try
            CboxClm = New DataGridViewComboBoxColumn
        CboxClm = GVChannelsAdd.Columns(2)

        CboxClm.Items.Clear()
        For i As Integer = 0 To MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
            Dim pnlObj() As Control
            pnlObj = MainPage.Controls.Find("pnlPage" & i + 1, True)
            If Not pnlObj Is Nothing AndAlso Not pnlObj(0) Is Nothing Then
                'Get All Controls from  Pnl_Obj(0)
                For Each Fcontrols In pnlObj(0).Controls
                    If (TypeOf Fcontrols Is ChartControl) Then
                        CboxClm.Items.Add(Fcontrols.name)
                    End If
                    If (TypeOf Fcontrols Is DataGridViewCtrl) Then
                      CboxClm.Items.Add(Fcontrols.name)
                    End If
                Next
             End If
        Next
        GVChannelsAdd.Rows.Clear()
        For i As Integer=0 to  MainPage.Task_ScheduleList.Count-1
            Dim Split_Schedule = MainPage.Task_ScheduleList(i).Split("#")
            GVChannelsAdd.Rows.Add()
            GVChannelsAdd.Rows(i).Cells(0).Value=i+1
            GVChannelsAdd.Rows(i).Cells(1).Value=Split_Schedule(0)
            GVChannelsAdd.Rows(i).Cells(2).Value=Split_Schedule(1)
            GVChannelsAdd.Rows(i).Cells(3).Value=Split_Schedule(2)
            GVChannelsAdd.Rows(i).Cells(4).Value=Split_Schedule(3)
            GVChannelsAdd.Rows(i).Cells(6).Value=Split_Schedule(4)

        Next
    Catch ex As Exception
        MsgBox(ex.Message)
    End Try
        

    End Sub

Private Sub btnChnlDelete_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnChnlDelete.Click
            If GVChannelsAdd.Rows.Count > 0 Then
            Dim i = GVChannelsAdd.CurrentRow.Index
            GVChannelsAdd.Rows.RemoveAt(i)
        End If
End Sub
    Private Combo As ComboBox
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GVChannelsAdd.EditingControlShowing
        If Me.GVChannelsAdd.CurrentCell.ColumnIndex = 3 Then 'Your ColumnCB index
            If Combo Is Nothing Then
                Combo = CType(e.Control, ComboBox)
                RemoveHandler Combo.SelectedIndexChanged, New EventHandler(AddressOf Combo_SelectedIndexChange)
                AddHandler Combo.SelectedIndexChanged, New EventHandler(AddressOf Combo_SelectedIndexChange)
            End If
        End If
    End Sub
    Private Sub Combo_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DirectCast(sender, ComboBox).SelectedIndex <> -1 Then
           GVChannelsAdd.CurrentRow.Cells(4).Value=""
        End If
    End Sub
     Private Sub GVChannelsAdd_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GVChannelsAdd.MouseClick
    Try
            If GVChannelsAdd.CurrentCell.ColumnIndex =5 Then
           
                Dim idx As Integer = GVChannelsAdd.CurrentRow.Index
            If GVChannelsAdd.Rows(idx).Cells(3).Value="Print" Then
                  Dim prntdlg As New PrintDialog
                 If prntdlg.ShowDialog = DialogResult.OK Then
                        GVChannelsAdd.Rows(idx).Cells(4).Value  = prntdlg.PrinterSettings.PrinterName
                  End If
            ElseIf GVChannelsAdd.Rows(idx).Cells(3).Value="Export Image/ CSV File" Then
                  Dim FldBrowseDlg As New FolderBrowserDialog
                FldBrowseDlg.RootFolder=Environment.SpecialFolder.Desktop
                if FldBrowseDlg.ShowDialog=DialogResult.OK
                    GVChannelsAdd.Rows(idx).Cells(4).Value  = FldBrowseDlg.SelectedPath
                End If
             ElseIf GVChannelsAdd.Rows(idx).Cells(3).Value="EMail" Then
                 EMailMessageForm.ShowDialog()
                
            End If

        End If
    Catch ex As Exception
            MsgBox(ex.Message)
    End Try
        

    End Sub

Private Sub btnChnlApply_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnChnlApply.Click
    Try
            MainPage.Task_ScheduleList.Clear()
    
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        If Not MainPage.Task_scheduleClassList Is Nothing then

            For i As Integer = 0 To MainPage.Task_scheduleClassList.Length - 1
                If Not MainPage.Task_scheduleClassList(i) Is Nothing Then
                    MainPage.Task_scheduleClassList(i).Task_timer.Dispose() 'Dispose Timer
                End If
            Next
        End If
    
        ReDim MainPage.Task_scheduleClassList(GVChannelsAdd.Rows.Count - 1)

        For i As Integer = 0 To GVChannelsAdd.Rows.Count - 1
            If Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(2).Value) And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(3).Value) _
            And Not String.IsNullOrEmpty(GVChannelsAdd.Rows(i).Cells(4).Value) Then


                    Dim rfTime As Integer
                    Dim ss=GVChannelsAdd.Rows(i).Cells(1).Value.ToString.Split(" ")
                    If CInt(ss(0))=10 or CInt(ss(0))=30 then
                         rfTime = CInt(ss(0)) * 60 * 1000
                    Else
                        rfTime = CInt(ss(0)) * 60 * 60* 1000
                    End If
                   
             MainPage.Task_scheduleClassList(i) = New TaskScheduleClass( rfTime,GVChannelsAdd.Rows(i).Cells(3).Value , GVChannelsAdd.Rows(i).Cells(2).Value,GVChannelsAdd.Rows(i).Cells(4).Value) 'Create Instace Class to each Query
  
            MainPage.Task_ScheduleList.Add(GVChannelsAdd.Rows(i).Cells(1).Value & "#" & GVChannelsAdd.Rows(i).Cells(2).Value _
                & "#" & GVChannelsAdd.Rows(i).Cells(3).Value & "#" & GVChannelsAdd.Rows(i).Cells(4).Value _
               & "#" & GVChannelsAdd.Rows(i).Cells(6).Value )
                                                    
            
                Else
                MsgBox("Empty Field not Allowed!!!",MsgBoxStyle.Information,"Info")
                Exit  Sub
        End If
     Next
       
        Me.Close()
    Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TaskSchedulerForm.btnChnlApply_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
    End Try


      
End Sub

Private Sub btnClose_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnClose.Click
        Me.close
End Sub
End Class