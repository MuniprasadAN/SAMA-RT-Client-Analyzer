Public Class ConnectOPCServer
    Public BtnOK As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BtnOK = True
        Me.Close()
    End Sub

    Private Sub txtbxservername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbxservername.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            BtnOK = True
            Me.Close()
        End If
    End Sub
End Class