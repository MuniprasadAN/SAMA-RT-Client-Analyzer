Imports System
Imports System.Configuration
Imports System.Data.SqlClient


Public Class Annunciator_ColorSetting
    Dim Constring As New MainPage
    Dim con = Constring.GetConString()
    Dim sqlConn As New SqlConnection(con)
    Dim sqLcmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim adapt As SqlDataAdapter
    Dim AlarmState As String

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub dataGridAlamStatus_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridAlamStatus.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex > 0 Then
            AlarmState = dataGridAlamStatus.Rows(e.RowIndex).Cells("clmState").Value
            Dim addprop As New UpdateAnnunciatorColor(AlarmState)
            addprop.ShowDialog()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGridAlamStatus.Rows.Add("Alarm")
        dataGridAlamStatus.Rows.Add("Return")
        dataGridAlamStatus.Rows.Add("Normal")
        dataGridAlamStatus.Rows.Add("Return Before ACK")
        dataGridAlamStatus.Rows.Add("Return UNACK")
        DisplayData()

    End Sub

    Public Sub DisplayData()
        Try
            dataGridAlamStatus.Rows.Clear()
            sqlConn.Open()
            Dim dt As DataTable = New DataTable
            sqLcmd = New SqlCommand("select tA.AlarmState,tA.ForeColor,ta.BackColor,ta.Blink,ta.BlinkSpeed,ta.width,ta.Height  from tblAnnunciator as tA ", sqlConn)
            dr = sqLcmd.ExecuteReader()
            While dr.Read
                Dim index = dataGridAlamStatus.Rows.Add()
                dataGridAlamStatus.Rows(index).Cells("clmState").Value = dr("AlarmState")
                dataGridAlamStatus.Rows(index).Cells("clmforecolor").Style.BackColor = Color.FromArgb(Convert.ToInt32(dr("ForeColor"))) 'FromName("#ffffff80")
                dataGridAlamStatus.Rows(index).Cells("clmbackcolor").Style.BackColor = Color.FromArgb(Convert.ToInt32(dr("BackColor")))

                dataGridAlamStatus.Rows(index).Cells("clmblink").Value = dr("Blink")
                dataGridAlamStatus.Rows(index).Cells("clmblinkspeed").Value = dr("BlinkSpeed")
                dataGridAlamStatus.Rows(index).Cells("clmWidth").Value = dr("width")
                dataGridAlamStatus.Rows(index).Cells("clmnHeight").Value = dr("Height")
                'dataGridAlamStatus.Rows(index).Cells("clmAudible1").Value = dr("Audible1")

            End While
            ' MsgBox(dr.Item("AlarmState"))
            sqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        End Try

        '   MessageBox.Show("Record Inserted Successfully")
    End Sub

    'Private Sub btnAdd_Click(sender As Object, e As EventArgs)
    '    Dim addprop As New UpdateAnnunciatorColor(AlarmState)
    '    addprop.ShowDialog()
    'End Sub
End Class
