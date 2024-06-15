Imports System.String
Public Class SAMAReports_Config
    Public BtnOk As Boolean
    Private Reportname As String
    Private Function NeedUserInput() As Boolean

        Dim hr() As Integer = {1, 2, 3, 4, 6, 8, 12}

        If txtRpt.Text = "" Then
            MsgBox("Please Enter Report Name")
            Return True
        End If
        If Txtbx_Description.Text = "" Then
            MsgBox("Please Enter Report Description")
            Return True
        End If
        If Txtbx_duration.Text = "" Or CBx_duration.Text = "" Then
            MsgBox("Please Enter Duration")
            Return True
        End If
        If Txtbx_Interval.Text = "" Then
            MsgBox("Please Enter Interval")
            Return True
        End If

        If Txtbx_Interval.Text = "" Or CBx_Interval.Text = "" Then
            MsgBox("Please Enter Interval")
            Return True
        End If
        If CBx_XAxis.Text = "" Then
            MsgBox("Please Select XAxis Type")
            Return True
        End If

        

    End Function

    Private Sub Btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Save.Click
        Try
            
            If NeedUserInput() Then
                Exit Sub
            Else
                BtnOk = True
                Me.Close()
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorian_Btn_Save_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Me.Close()
    End Sub


 
End Class