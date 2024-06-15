Imports System.IO

Public Class ErrorLogForm

    Private Sub ErrorLogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstViewErrorLog.Items.Clear()
        If MainPage._errLog isnot Nothing Then
            For i As Integer = 0 To MainPage._errLog.Count - 1
            Dim Arr_Err As Object
            Arr_Err = MainPage._errLog(i).Split("@")
            Dim LV_item As New ListViewItem(CStr(Arr_Err(0)), 0)
            LV_item.SubItems.Add(Arr_Err(1))
            LV_item.SubItems.Add(Arr_Err(2).ToString.Replace("#","@"))
            LV_item.SubItems.Add(Arr_Err(3))
            lstViewErrorLog.Items.Add(LV_item)
        Next
        End If
      
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lstViewErrorLog.Items.Clear()
        MainPage._errLog.Clear
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim savefldlg As New SaveFileDialog
            Dim fname As String = ""
            Dim s As StreamWriter
            savefldlg.Filter = ("log Files|.txt")
            savefldlg.FilterIndex = 0

            If savefldlg.ShowDialog = DialogResult.OK Then
                fname = savefldlg.FileName

                Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
                s = New StreamWriter(fs)
                Dim Msg As String = ""

                's.BaseStream.Seek(0, SeekOrigin.End)
                For i = 0 To MainPage._errLog.Count - 1
                   Msg &=MainPage._errLog(i).ToString.Replace("@", vbTab).Replace("#","@") & vbNewLine
                Next
                s.WriteLine(Msg)
                s.Close()

            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Error Log Form.btnSave_Click()")
        End Try
    End Sub
End Class