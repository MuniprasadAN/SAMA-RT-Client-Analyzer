Imports Microsoft.Win32

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Try

                Dim v As New ValidKey.Class1
                Dim basekey As RegistryKey
                Dim strRegKey As String = ""

                If Environment.Is64BitOperatingSystem Then
                    basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                Else
                    basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                End If


                Dim subkey As RegistryKey = basekey.OpenSubKey("SOFTWARE\SupraControls\Valid")
                strRegKey = (subkey.GetValue("key"))
                subkey.Close()
                basekey.Close()


                MainPage.Server_Flag = True
                If v.CheckKey(strRegKey, 65536) Then
                    If v.ErrorNo = -1 Then
                        MsgBox(v.Message)
                        'End
                    Else
                        MainPage.Server_Flag = True
                    End If

                ElseIf v.CheckKey(strRegKey, 131072) Then
                    If v.ErrorNo = -1 Then
                        MsgBox(v.Message)
                        'End
                    Else
                        MainPage.Server_Flag = False
                    End If
                Else
                    'If Product Then Not license End the application
                    MsgBox(v.Message, MsgBoxStyle.Exclamation, "Warning")
                    'End
                End If

            Catch ex As Exception
                MsgBox("Valid Key is Not Properly Installed !!!", MsgBoxStyle.Exclamation, "Warning!!!")
            End Try

        End Sub
    End Class

End Namespace

