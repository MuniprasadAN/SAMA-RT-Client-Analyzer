Public Class OPCWriter
    Friend idx As Integer
    Friend OPCName As string
Private Sub btnOK_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If Idx <>-1 andalso Not String.IsNullOrEmpty(OPCName) Then

                If   Not Mainpage.opcCnfgTags Is Nothing ANDalso Mainpage.opcCnfgTags.Length >0 Then
                    If Not  Mainpage.opcCnfgTags(Idx)is Nothing AndAlso Not Mainpage.opcCnfgTags(idx)._asyncRefrGroup Is Nothing
                        Mainpage.opcCnfgTags(idx)._asyncRefrGroup.Write(OPCName ,txtOPCValue.Text)
                    End If
                End If
          
                End If
        Catch ex As Exception
             Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@OPC Writer:btnOK_Click()")
             Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
        
End Sub

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
End Sub
End Class