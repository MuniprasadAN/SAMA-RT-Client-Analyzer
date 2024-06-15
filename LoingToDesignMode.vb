Public Class LoingToDesignMode
    Friend Password As String=""
Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
End Sub

Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
       
        Me.Close()
End Sub

Private Sub LoingToDesignMode_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
        txtPassword.Text=""
End Sub
End Class