Public Class SetCondition
    Public conditionstr As String
    Public Btnok As Boolean
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Rows.Add()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each dr As DataRow In DataGridView1.Rows
            If dr(2) = "=X" Then
                conditionstr = "=" + "^" + dr(0) + "^" + dr(3)
            ElseIf dr(2) = "=Y" Then
                conditionstr = "=" + "^" + dr(1) + "^" + dr(3)
            ElseIf dr(2) = ">X" Then

            ElseIf dr(2) = ">Y" Then

            ElseIf dr(2) = "<X" Then

            ElseIf dr(2) = "<Y" Then

            End If
        Next
        Btnok = True
    End Sub
End Class