Imports System.Data.SqlClient
Imports System
Imports NAudio.Wave

Public Class EditAnnuciator_AudibleSetting
    Friend Update_AudibleValue As String
    Friend Update_Value As Integer
    Dim constring As New MainPage
    Dim con = constring.GetConString()
    Dim sqlConn As New SqlConnection(con)
    Dim sqlCmd As New SqlCommand()
    Dim sqLdr As SqlDataReader


    Private Sub btnBrowseAudibleFile_Click(sender As Object, e As EventArgs) Handles btnBrowseAudibleFile.Click
        Dim openFileAudible As New OpenFileDialog
        openFileAudible.Title = "Select Audio file.."
        'openFileAudible.InitialDirectory = Application.StartupPath
        openFileAudible.Filter = "All Media Files|*.wav;*.mp3;"

        'dlg.Filter = "All Media Files|*.wav;*.mp3;"

        If (openFileAudible.ShowDialog = DialogResult.OK) Then
            txtAudible1Filename.Text = System.IO.Path.GetFullPath(openFileAudible.FileName)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBrowseAudible2File.Click
        Dim openFileAudible As New OpenFileDialog
        openFileAudible.Title = "Select Audio file.."
        'openFileAudible.InitialDirectory = Application.StartupPath
        openFileAudible.Filter ="All Media Files|*.wav;*.mp3;"
        If (openFileAudible.ShowDialog = DialogResult.OK) Then
            txtAudible2Filename.Text = System.IO.Path.GetFullPath(openFileAudible.FileName)
        End If
    End Sub

    Private Sub btnsveAudible_Click(sender As Object, e As EventArgs) Handles btnsveAudible.Click
        Try
            sqlConn.Open()
            If Update_AudibleValue = "EDIT" Then
                Dim PriorityName As String = cmbPriorityName.SelectedValue
                Dim AudioDeviceName As String = cmbPlayAudioDevice.Text
                Dim AlarmState As String = cmbAlarmState.Text
                Dim Audible1_path As String = txtAudible1Filename.Text
                Dim Audible2_path As String = txtAudible2Filename.Text

                sqlCmd = New SqlCommand("update tblAnnunciator_Priority SET PriorityName='" & PriorityName & "', AlarmState='" & AlarmState & "',AudioDeviceName='" & AudioDeviceName & "',Audible1Enabled='" & chkbAudible1.Checked & "',Audible2Enabled='" & chkbAudible2.Checked & "',Audible1Path='" & Audible1_path & "',Audible2Path='" & Audible2_path & "'  where Annunciator_PriorityId='" & Update_Value & "'", sqlConn)
                sqlCmd.ExecuteReader()
            ElseIf Update_AudibleValue = "ADD" Then
                Dim vpriortyName As String = cmbPriorityName.SelectedValue
                Dim Audible1_path As String = txtAudible1Filename.Text
                Dim Audible2_path As String = txtAudible2Filename.Text
                sqlCmd = New SqlCommand("insert into tblAnnunciator_Priority (PriorityName,AlarmState,AudioDeviceName,Audible1Enabled,Audible2Enabled,Audible1Path,Audible2Path) values('" & cmbPriorityName.SelectedValue & "','" & cmbAlarmState.SelectedItem & "','" & cmbPlayAudioDevice.SelectedItem & "','" & chkbAudible1.Checked & "','" & chkbAudible2.Checked & "','" & Audible1_path & "','" & Audible2_path & "' )", sqlConn)
                sqlCmd.ExecuteReader()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
        Annunciator_GetPriority()
        Me.Close()
    End Sub

    Private Sub btnCancelAudible_Click(sender As Object, e As EventArgs) Handles btnCancelAudible.Click
        Me.Close()
    End Sub

    Public Sub EditAudible(ByVal AlarmState As Integer)
        Dim dr As SqlDataReader
        Try
            Annunciator_GetPriority()
            sqlConn.Open()
            If AlarmState Then
                sqlCmd = New SqlCommand("SELECT ta.Annunciator_PriorityId,tp.PriorityName,ta.AlarmState,ta.AudioDeviceName,ta.Audible1Enabled,ta.Audible2Enabled,ta.Audible1Path,ta.Audible2Path,tp.PriorityId From tblAnnunciator_Priority as Ta join tblPriority as tp on tp.PriorityId=ta.PriorityName where Ta.Annunciator_PriorityId='" & AlarmState & "'", sqlConn)
                dr = sqlCmd.ExecuteReader()
                While dr.Read
                    Update_Value = dr("Annunciator_PriorityId")
                    Dim sdaas As Integer = dr("PriorityId")
                    cmbPriorityName.SelectedValue = sdaas
                    cmbAlarmState.Text = dr("AlarmState")
                    cmbPlayAudioDevice.Text = dr("AudioDeviceName")
                    chkbAudible1.Checked = dr("Audible1Enabled")
                    chkbAudible2.Checked = dr("Audible2Enabled")
                    txtAudible1Filename.Text = dr("Audible1Path")
                    txtAudible2Filename.Text = dr("Audible2Path")
                End While
            End If
            sqlConn.Close()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@EditAudible()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try
    End Sub

    Private Sub EditAnnuciator_AudibleSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GrpbAudio.Visible = False
        chkbAudible1.Visible = False
        chkbAudible2.Visible = False
        txtAudible2Filename.Visible = False
        txtAudible1Filename.Visible = False
        btnBrowseAudibleFile.Visible = False
        btnBrowseAudible2File.Visible = False
        For n = 0 To WaveOut.DeviceCount - 1
            Dim caps = WaveOut.GetCapabilities(n)
            cmbPlayAudioDevice.Items.Add(caps.ProductName)
        Next
        Annunciator_GetPriority()
    End Sub


    Public Sub Annunciator_GetPriority()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Try
            sqLconn.ConnectionString = MainPage.Constr
            Try
                cmbPriorityName.Items.Clear()
                sqLconn.Open()
                'sqLcmd = New SqlCommand("Select * From tblPriority", sqLconn)

                Dim daColours As New SqlDataAdapter("Select * From tblPriority", sqLconn)

                Dim dtColours As New DataTable
                daColours.Fill(dtColours)

                cmbPriorityName.DataSource = dtColours
                cmbPriorityName.DisplayMember = "PriorityName"
                cmbPriorityName.ValueMember = "PriorityId"
                sqLconn.Close()
                'dr = sqLcmd.ExecuteReader
                'While dr.Read
                '    cmbPriorityName.Items.Add(dr("PriorityName"))
                '    cmbPriorityName.ValueMember = dr("PriorityId")
                '    cmbPriorityName.DisplayMember = dr("PriorityName")
                'End While

            Catch ex As Exception

            End Try
            Try
                cmbAlarmState.Items.Clear()
                Dim sdr As SqlDataReader
                sqLconn.Open()
                sqLcmd = New SqlCommand("select tA.AnnunciatorId, tA.AlarmState from tblAnnunciator as tA", sqLconn)
                sdr = sqLcmd.ExecuteReader
                While sdr.Read
                    cmbAlarmState.Items.Add(sdr("AlarmState"))
                End While
                sqLconn.Close()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetPriority()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub chkbAudible1_CheckedChanged(sender As Object, e As EventArgs) Handles chkbAudible1.CheckedChanged
        If chkbAudible1.Checked Then
            txtAudible1Filename.Enabled = True
            btnBrowseAudibleFile.Enabled = True
        Else
            txtAudible1Filename.Text = ""
            txtAudible1Filename.Enabled = False
            btnBrowseAudibleFile.Enabled = False
        End If
    End Sub

    Private Sub chkbAudible2_CheckedChanged(sender As Object, e As EventArgs) Handles chkbAudible2.CheckedChanged
        If chkbAudible2.Checked Then
            txtAudible2Filename.Enabled = True
            btnBrowseAudible2File.Enabled = True
        Else
            txtAudible2Filename.Text = ""
            txtAudible2Filename.Enabled = False
            btnBrowseAudible2File.Enabled = False
        End If
    End Sub

    Private Sub cmbAlarmState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAlarmState.SelectedIndexChanged
        '        Normal
        '        Alarm
        '        Acknowledged  & under Alarm
        'Return To Normal
        'Return To Normal Before Acknowledge
        If cmbAlarmState.Text = "Normal" Then
            GrpbAudio.Visible = False
            chkbAudible1.Visible = False
            chkbAudible2.Visible = False
            txtAudible2Filename.Visible = False
            txtAudible1Filename.Visible = False
            btnBrowseAudibleFile.Visible = False
            btnBrowseAudible2File.Visible = False

        ElseIf cmbAlarmState.Text = "Alarm" Then
            GrpbAudio.Visible = True
            chkbAudible1.Visible = True
            chkbAudible2.Visible = False
            txtAudible2Filename.Visible = False
            txtAudible1Filename.Visible = True
            btnBrowseAudibleFile.Visible = True
            btnBrowseAudible2File.Visible = False
        ElseIf cmbAlarmState.Text = "Acknowledged  & under Alarm" Then
            GrpbAudio.Visible = False
            chkbAudible1.Visible = False
            chkbAudible2.Visible = False
            txtAudible2Filename.Visible = False
            txtAudible1Filename.Visible = False
            btnBrowseAudibleFile.Visible = False
            btnBrowseAudible2File.Visible = False
        ElseIf cmbAlarmState.Text = "Return To Normal" Then
            GrpbAudio.Visible = True
            chkbAudible1.Visible = False
            chkbAudible2.Visible = True
            txtAudible1Filename.Visible = False
            txtAudible2Filename.Visible = True
            btnBrowseAudibleFile.Visible = False
            btnBrowseAudible2File.Visible = True
        ElseIf cmbAlarmState.Text = "Return To Normal Before Acknowledge" Then
            GrpbAudio.Visible = True
            chkbAudible1.Visible = True
            chkbAudible2.Visible = True
            txtAudible1Filename.Visible = True
            txtAudible2Filename.Visible = True
            btnBrowseAudibleFile.Visible = True
            btnBrowseAudible2File.Visible = True
        End If


    End Sub


End Class