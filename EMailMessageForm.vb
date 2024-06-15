Public Class EMailMessageForm

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim ValueStr As String=""
            If Not string.IsNullOrEmpty(txtFrom.Text) andAlso Not  string.IsNullOrEmpty(txtTo.Text)AndAlso Not  string.IsNullOrEmpty(txtSubject.Text) Then
                 ValueStr=txtTo.Text & "&" & txtSubject.Text & "&" & rtxboxMsg.Text & "&" & CkboxAttach.Checked.ToString()
                 TaskSchedulerForm. GVChannelsAdd.CurrentRow.Cells(4).Value=ValueStr
                 Me.Close()
            Else
                MsgBox("From,To,Subject Fields are Mandatory!!!",MsgBoxStyle.Information)
                TaskSchedulerForm. GVChannelsAdd.CurrentRow.Cells(4).Value=""
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
End Sub

Private Sub EMailMessageForm_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
Try
    
        If MainPage.EmailSetting.Count>0 then
            txtFrom.Text=MainPage.EmailSetting(0)
        End If
   
    If Not TaskSchedulerForm. GVChannelsAdd.CurrentRow.Cells(4).Value="" Then
             
        dim aL_msg=TaskSchedulerForm. GVChannelsAdd.CurrentRow.Cells(4).Value.ToString.Split("&")

        If aL_msg.Length>1 Then
            txtTo.Text=aL_msg(0)
            txtSubject.Text=aL_msg(1)
            rtxboxMsg.Text=aL_msg(2)

            If aL_msg(3)="True" Then
                CkboxAttach.Checked=True
            Else
                CkboxAttach.Checked=False
            End If
        Else
            txtTo.Text=""
            txtSubject.Text=""
            rtxboxMsg.Text=""

        End If
   End If
Catch ex As Exception
    MsgBox(ex.Message)
End Try
   
      
End Sub
End Class