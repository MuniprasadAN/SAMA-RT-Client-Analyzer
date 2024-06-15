Imports System.IO

Public Class LoginForm

    Dim tmr As New System.Timers.Timer

    Dim ds As DataSet
    Dim dt As DataTable
    Dim dr As DataRow
    Public datarow() As DataRow
    Public BtnOk As Boolean
    Public Blnclose As Boolean
    Public Blncancel As Boolean
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            BtnOk = True
            If Me.Text = "Login" Then
                ds = New DataSet
                ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
                dt = ds.Tables(0)
                datarow = dt.Select("Username= '" & UsernameTextBox.Text & "' and Password= '" & PasswordTextBox.Text & "'")
                If datarow.Count > 0 Then
                    MainPage.CurrentUser = UsernameTextBox.Text
                    MainPage.Access_Level = datarow(0)("Accesslevel")
                    MainPage.Access_Rules = datarow(0)("Accessrules")
                    If Not IsDBNull(datarow(0)("IsAdmin")) And (datarow(0)("IsAdmin") = "True") Then
                        MainPage._IsAdmin = True
                        MainPage._IsSimpleUser = False
                        MainPage._IsPowerUser = False
                        MainPage._IsSuperAdmin = False
                    ElseIf Not IsDBNull(datarow(0)("IsSimple")) And (datarow(0)("IsSimple") = "True") Then
                        MainPage._IsAdmin = False
                        MainPage._IsSimpleUser = True
                        MainPage._IsPowerUser = False
                        MainPage._IsSuperAdmin = False
                    ElseIf Not IsDBNull(datarow(0)("IsPower")) And (datarow(0)("IsPower") = "True") Then
                        MainPage._IsAdmin = False
                        MainPage._IsSimpleUser = False
                        MainPage._IsPowerUser = True
                        MainPage._IsSuperAdmin = False
                    ElseIf Not IsDBNull(datarow(0)("IsSuperAdmin")) And (datarow(0)("IsSuperAdmin") = "True") Then
                        MainPage._IsAdmin = False
                        MainPage._IsSimpleUser = False
                        MainPage._IsPowerUser = False
                        MainPage._IsSuperAdmin = True
                    End If
                    Blnclose = True
                    Me.Close()



                Else
                    MsgBox("Login Failed")
                End If
            ElseIf Me.Text = "Logout" Then
                ds = New DataSet
                ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
                dt = ds.Tables(0)
                datarow = dt.Select("Username= '" & MainPage.CurrentUser & "' and Password= '" & PasswordTextBox.Text & "'")
                If datarow.Count > 0 Then
                    'End
                    Me.Close()
                    'MsgBox("Logged Out", MsgBoxStyle.Information)

                Else
                    Blnclose = True
                    MsgBox("Logout Failed")

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        BtnOk = False
        If Me.Text = "Login" Then
            End
        ElseIf Me.Text = "Logout" Then
            Blncancel = True
            Me.Close()
        End If
    End Sub

    'Private Sub LoginForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    '    If Me.Text = "Login" And Not Blnclose Then
    '        End
    '    ElseIf Me.Text = "Logout" And Blnclose Then
    '        ' Me.Close()

    '    End If
    'End Sub

    Private Sub LoginForm_FormClosing(sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Text = "Login" And Not Blnclose Then
            End
            'ElseIf Me.Text = "Logout" And Not Blnclose Then
            '    e.Cancel = True
            '    ' Me.Close()

        End If
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Environment.CurrentDirectory & "\AutoLoginLogout") Then
            UsernameTextBox.Text = "sa"
            PasswordTextBox.Text = "sa"
            'AddHandler tmr.Elapsed, AddressOf tmrElapsed
            'tmr.Interval = 1000
            'tmr.Start()
        End If
    End Sub
    Private Sub tmrElapsed()
        'tmr.Stop()
        'OK_Click(Nothing, Nothing)
    End Sub

End Class
