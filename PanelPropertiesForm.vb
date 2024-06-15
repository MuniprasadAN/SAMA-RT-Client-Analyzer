' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="PanelPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Public Class PanelPropertiesForm
    Dim ColDialog As New ColorDialog
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If rdobtnNone.Checked Then
            MainPage.Panel_Ctrl.AccessibleDescription = "NoEdge"
        ElseIf rdobtnRaisedEdge.Checked Then
            MainPage.Panel_Ctrl.AccessibleDescription = "Edge"
        End If
        MainPage.Panel_Ctrl.BackColor = BGColorLbl.BackColor
        MainPage.Panel_Ctrl.Refresh
        Me.Close()
    End Sub
    Private Sub BGColorLbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGColorLbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        BGColorLbl.BackColor = ColDialog.Color
    End Sub


End Class