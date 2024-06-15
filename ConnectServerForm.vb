Imports System.IO

Public Class ConnectServerForm

    Private Sub CkBoxAutoConnect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkBoxAutoConnect.CheckedChanged
        If CkBoxAutoConnect.Checked Then
            MainPage._AutoReconnect = True
            MainPage.tmrCheckConnectivity.Enabled=True
        Else
            MainPage._AutoReconnect = False
             MainPage.tmrCheckConnectivity.Enabled=False
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Call Mainpage.RefreshOPC_Channel()
        Call Mainpage.RefreshDBChannel()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ConnectServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblStatus.Text=""
        txtServerIP.Text = MainPage._serverIP
        If MainPage._AutoReconnect Then
            CkBoxAutoConnect.Checked = True
        Else
            CkBoxAutoConnect.Checked = False
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try

            If Not String.IsNullOrEmpty(txtServerIP.Text) Then
            lblStatus.Text="Connecing......"
            Dim serverIPpath As String = "\\" & txtServerIP.Text & "\RemoteData"
            MainPage._serverIP = txtServerIP.Text
           
            If My.Computer.Network.Ping(txtServerIP.Text) Then

                Dim DirInfo As New DirectoryInfo(serverIPpath) 'Check Folder Exist in Destination Machine
                If DirInfo.Exists Then
                    
                    Call Mainpage.RefreshOPC_Channel()
                    Call Mainpage.RefreshDBChannel()
                    
                    lblStatus.Text="Connecion Successful"
                     MainPage.Server_PullDataPath = serverIPpath
                    MainPage.modify = True
                    If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                        MainPage.Text = MainPage.Text & " *"
                    End If
                    If CkBoxAutoConnect.Checked Then
                        MainPage._AutoReconnect = True
                    Else
                        MainPage._AutoReconnect = False
                    End If

                    If Not Mainpage.Server_Flag and Mainpage._AutoReconnect Then
                        Mainpage.tmrCheckConnectivity.Enabled=True
                    End If
                Else
                    MsgBox("Data Cannot be Accessed !!", MsgBoxStyle.Exclamation)
                End If

            Else
                MsgBox("Server Cannot be Located !!!", MsgBoxStyle.Critical, "Server Not Found")
            End If

        Else
            MsgBox("Address Field is Empty ?", MsgBoxStyle.Information, "Info")
        End If
        Catch ex As Exception
             MsgBox(ex.Message, MsgBoxStyle.Critical, "Address Not Found")
    End Try
        
    End Sub
End Class