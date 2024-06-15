Public Class EMailSettingform

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
End Sub

Private Sub EMailSettingform_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
Try
     If MainPage.EmailSetting.Count>0 then
        txtEmailId.Text=MainPage.EmailSetting(0)
        txtEmailPwd.Text=MainPage.EmailSetting(1)
        txtSMTPServer.Text=MainPage.EmailSetting(2)
        txtSMTPPort.Text=MainPage.EmailSetting(3)
        cmbSSL.Text=MainPage.EmailSetting(4)  
    End If
Catch ex As Exception
    MsgBox(ex.Message)
End Try
       
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
Try
    If Not String.IsNullOrEmpty(txtEmailId.Text) And Not String.IsNullOrEmpty(txtEmailPwd.Text) _
        And Not String.IsNullOrEmpty(txtSMTPServer.Text) And Not String.IsNullOrEmpty(txtSMTPPort.Text) Then
         MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        MainPage.EmailSetting.clear()
        MainPage.EmailSetting.add(txtEmailId.Text)
        MainPage.EmailSetting.add(txtEmailPwd.Text)
        MainPage.EmailSetting.add(txtSMTPServer.Text)
        MainPage.EmailSetting.add(txtSMTPPort.Text)
        MainPage.EmailSetting.add(cmbSSL.Text)

        Me.Close()
    Else
        MsgBox("Empty Fields Not allowed",MsgBoxStyle.Information,"Warning!!!")
    End If
    
    
    
Catch ex As Exception
    MsgBox(ex.Message)
End Try
   
End Sub
End Class