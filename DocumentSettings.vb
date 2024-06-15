Public Class DocumentSettings

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs)  Handles btnCancel.Click
        Me.Close
End Sub



Private Sub txtHistoryPath_DoubleClick( ByVal sender As System.Object,  ByVal e As System.EventArgs)  Handles txtHistoryPath.DoubleClick,  txtRemoteDataPath.DoubleClick
        Dim Browsedlg As New FolderBrowserDialog
        
        If Browsedlg.ShowDialog=DialogResult.OK Then
            sender.text=Browsedlg.SelectedPath
        End If
End Sub


Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs)  Handles btnOK.Click

If MainPage.Server_Flag  Then
     If string.IsNullOrEmpty(txtHistoryPath.Text) or string.IsNullOrEmpty(txtRemoteDataPath.Text) Then
        MsgBox("Path Field could not Empty!!!",MsgBoxStyle.Information)
        Exit Sub
    End If
     If (Not txtNewPass.Text="" and txtRetypePass.Text="") Or  ( txtNewPass.Text="" and Not txtRetypePass.Text="") Then
            MsgBox("Sorry, Password Mismatch !!!",MsgBoxStyle.Information)
            Exit Sub
     End If
    If Not txtNewPass.Text="" And Not txtRetypePass.Text="" Then
        If Not MainPage._oldPass="" Then
            If Not string.Equals(MainPage._oldPass,txtOldPass.text)
                MsgBox("Please Ender Correct Old Password",MsgBoxStyle.Information)
                Exit Sub
            End If
            If Not string.Equals(MainPage._NewPass,MainPage._RetypePass)
                MsgBox("Sorry, Password Mismatch !!!",MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            If Not string.Equals(txtNewPass.Text,txtRetypePass.Text)
                MsgBox("Sorry, Password Mismatch !!!",MsgBoxStyle.Information)
                Exit Sub
           
            End If

        End If
        
        MainPage._oldPass=txtNewPass.Text
        MainPage._NewPass=txtNewPass.Text
        MainPage._RetypePass=txtRetypePass.Text
        MainPage._serverIP=txtServerIP.Text
        MainPage.Storage_Loc=txtHistoryPath.Text 
        MainPage.Server_PushDataPath=txtRemoteDataPath.Text
    
    Else
        MainPage.Storage_Loc=txtHistoryPath.Text 
        If MainPage.Server_Flag Then
             MainPage.Server_PushDataPath=txtRemoteDataPath.Text
        Else
            MainPage.Server_PullDataPath=txtRemoteDataPath.Text
        End If
       
    End If
 Else
        If string.IsNullOrEmpty(txtHistoryPath.Text) Then
            MsgBox("Please Ender Correct Old Password",MsgBoxStyle.Information)
            Exit Sub
        End If
     MainPage.Storage_Loc=txtHistoryPath.Text 
 End If  
         
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Me.Close()


End Sub

Private Sub DocumentSettings_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
        
        txtHistoryPath.Text=MainPage.Storage_Loc
        txtServerIP.Text=MainPage._serverIP
        txtOldPass.Text=""
        txtNewPass.Text=""
        txtRetypePass.Text=""

        If Not MainPage.Server_Flag Then
            grpBoxPassword.Enabled=False
            txtServerIP.Enabled=false
            txtRemoteDataPath.Enabled=False
            txtRemoteDataPath.Text= MainPage.Server_PullDataPath
        Else
            grpBoxPassword.Enabled=True
            txtServerIP.Enabled=True
            txtRemoteDataPath.Enabled=True
            txtRemoteDataPath.Text= MainPage.Server_PushDataPath
        End If
End Sub


End Class