Imports System
Imports System.Data.SqlClient
Public Class Annunciator_AudibleSetting
        Dim ds As DataSet
        Dim dt As DataTable
    Dim dr As DataRow

    Dim Constring As New MainPage
    Dim con = Constring.GetConString()
    Dim sqlConn As New SqlConnection(con)
    Dim sqlCmd As New SqlCommand()
    Dim sqLdr As SqlDataReader

    Private Sub btnAddAudible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAudible.Click
        Try
            Dim editAudibleSetting As New EditAnnuciator_AudibleSetting
            editAudibleSetting.Update_AudibleValue = "ADD"
            'Dim DataName = AudibleValue.CurrentCell.Value
            editAudibleSetting.ShowDialog()
            DisplayAnnunciator_Audible()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Annunciator_AudibleSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayAnnunciator_Audible()
    End Sub

    Public Sub DisplayAnnunciator_Audible()
        Try
            AudibleValue.Rows.Clear()
            sqlConn.Open()
            Dim dt As DataTable = New DataTable
            sqlCmd = New SqlCommand("SELECT ta.Annunciator_PriorityId,ta.AlarmState,ta.AudioDeviceName,ta.Audible1Enabled,ta.Audible2Enabled,ta.Audible1Path,ta.Audible2Path,tp.PriorityName From tblAnnunciator_Priority as Ta join tblPriority as tp on tp.PriorityId=ta.PriorityName", sqlConn)
            sqLdr = sqlCmd.ExecuteReader()
            While sqLdr.Read
                Dim index = AudibleValue.Rows.Add()
                AudibleValue.Rows(index).Cells("clmPriorityID").Value = sqLdr("Annunciator_PriorityId")
                AudibleValue.Rows(index).Cells("ClmPriorityName").Value = sqLdr("PriorityName")
                AudibleValue.Rows(index).Cells("clmAlarmState").Value = sqLdr("AlarmState")
                AudibleValue.Rows(index).Cells("clmPlayDeviceName").Value = sqLdr("AudioDeviceName")
                AudibleValue.Rows(index).Cells("clmAudible1Enabled").Value = sqLdr("Audible1Enabled")
                AudibleValue.Rows(index).Cells("clmAudible2Enabled").Value = sqLdr("Audible2Enabled")
                AudibleValue.Rows(index).Cells("Audible1").Value = sqLdr("Audible1Path")
                AudibleValue.Rows(index).Cells("Audible2").Value = sqLdr("Audible2Path")
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try
    End Sub
    Private Sub btnEditAudible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAudible.Click
        Try
            Dim editAudibleSetting As New EditAnnuciator_AudibleSetting
            editAudibleSetting.Update_AudibleValue = "EDIT"
            Dim _SerialNo As Integer = AudibleValue.CurrentRow.Index
            Dim data As Integer = AudibleValue.Rows(_SerialNo).Cells(0).Value
            'Dim DataName = AudibleValue.CurrentCell.Value
            editAudibleSetting.EditAudible(data)
            editAudibleSetting.ShowDialog()
            DisplayAnnunciator_Audible()
        Catch ex As Exception
            'MainPage.insertfilelog(ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteAudible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAudible.Click
        Try
            Dim IndexVal As Integer = AudibleValue.CurrentRow.Index
            Dim data As Integer = AudibleValue.Rows(IndexVal).Cells(0).Value
            If data Then
                sqlConn.Open()
                Dim dt As DataTable = New DataTable
                sqlCmd = New SqlCommand("Delete From tblAnnunciator_Priority where Annunciator_PriorityId='" & data & "'", sqlConn)
                sqLdr = sqlCmd.ExecuteReader()
                sqlConn.Close()
            End If
            DisplayAnnunciator_Audible()
        Catch ex As Exception
            'MainPage.insertfilelog(ex.Message)
        End Try
        End Sub

    Private Sub btnCnl_Click(sender As Object, e As EventArgs) Handles btnCnl.Click
        Me.Close()
    End Sub


End Class
