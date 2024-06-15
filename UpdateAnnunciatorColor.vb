Imports System
Imports System.Data.SqlClient

Public Class UpdateAnnunciatorColor

    Dim sqLconn As SqlConnection = New SqlConnection(IO.File.ReadAllLines(Application.StartupPath & "\Connection.SupraConfig")(0))
    Dim sqLcmd As New SqlCommand
    Dim dr As SqlDataReader

    Dim AlarmVal As String

    Public Sub New(ByVal AlarmState As String)
        ' This call is required by the designer.
        InitializeComponent()
        AlarmVal = AlarmState
        If AlarmVal IsNot Nothing Then
            sqLconn.Open()
            sqLcmd = New SqlCommand("select tA.AlarmState,tA.ForeColor,tA.BackColor,tA.Blink,tA.BlinkSpeed,tA.width,tA.Height from tblAnnunciator as tA where AlarmState='" & AlarmVal & "'", sqLconn)
            dr = sqLcmd.ExecuteReader()
            While dr.Read
                txtforeColor.BackColor = Color.FromArgb(Convert.ToInt32(dr("ForeColor")))
                txtBackcolor.BackColor = Color.FromArgb(Convert.ToInt32(dr("BackColor")))
                ChkboxBlink.Checked = dr("Blink")
                cmbBoxBlinkSecs.Text = dr("BlinkSpeed")
                txtWidth.Text = dr("width")
                txtHeight.Text = dr("Height")

            End While
            sqLconn.Close()
        End If

        ' Add any initialization after the InitializeComponent() call.
    End Sub



    Private Sub Add_Properties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (ChkboxBlink.Checked = False) Then
            cmbBoxBlinkSecs.Hide()
            lblsecs.Hide()
        ElseIf (ChkboxBlink.Checked = True) Then
            cmbBoxBlinkSecs.Show()
            lblsecs.Show()
        End If
        ' Dim cboxClm As New DataGridViewComboBoxColumn
        'cboxClm = AudibleValue.Columns("ClmPriorityName")
        'cboxClm.Items.Clear()
        'DisplayAudible()
        'Annunciator_GetPriority()
        ' cboxClm.Items.AddRange(New String() {"TagNo", "Parameter", "AlarmIdentifier", "Priority", "Channel", "Unit", "Value"})


    End Sub
    'Private Sub Annunciator_GetPriority()
    '    Dim sqLconn As New SqlConnection
    '    Dim sqLcmd As New SqlCommand
    '    Dim dr As SqlDataReader
    '    Try
    '        Dim cboxClm As New DataGridViewComboBoxColumn
    '        cboxClm = AudibleValue.Columns("ClmPriorityName")
    '        sqLconn.ConnectionString = MainPage.Constr
    '        sqLconn.Open()
    '        sqLcmd = New SqlCommand("Select * From tblPriority", sqLconn)
    '        dr = sqLcmd.ExecuteReader
    '        cboxClm.Items.Clear()
    '        While dr.Read
    '            cboxClm.Items.Add(dr("PriorityName"))
    '        End While
    '        sqLconn.Close()
    '    Catch ex As Exception
    '        MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetPlant()")
    '        MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
    '    Finally
    '        If sqLconn.State = ConnectionState.Open Then
    '            sqLconn.Close()
    '        End If
    '    End Try
    'End Sub
    Private Sub LinklblForeClr_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        AlarmColorDialog.Color = Color.White
        AlarmColorDialog.ShowDialog()
        AlarmColorDialog.FullOpen = False
        txtforeColor.BackColor = AlarmColorDialog.Color
    End Sub

    Private Sub Linklblbackclr_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        AlarmColorDialog.Color = Color.White
        AlarmColorDialog.ShowDialog()
        AlarmColorDialog.FullOpen = False
        txtBackcolor.BackColor = AlarmColorDialog.Color
    End Sub

    Private Sub ChkboxBlink_CheckedChanged(sender As Object, e As EventArgs) Handles ChkboxBlink.CheckedChanged
        If (ChkboxBlink.Checked = False) Then
            cmbBoxBlinkSecs.Hide()
            lblsecs.Hide()
        ElseIf (ChkboxBlink.Checked = True) Then
            cmbBoxBlinkSecs.Show()
            lblsecs.Show()
        End If

    End Sub

    'Public Sub DisplayAudible()
    '    Try
    '        'AudibleValue.Rows.Clear()
    '        sqLconn.Open()
    '        Dim dt As DataTable = New DataTable
    '        sqLcmd = New SqlCommand("select * from tblAnnunciator_Priority ", sqLconn)
    '        dr = sqLcmd.ExecuteReader()
    '        While dr.Read
    '            Dim index = AudibleValue.Rows.Add()
    '            AudibleValue.Rows(index).Cells("ClmPriorityName").Value = dr("PriorityName")
    '            AudibleValue.Rows(index).Cells("Audible1").Value = dr("Audible1")
    '            AudibleValue.Rows(index).Cells("Audible2").Value = dr("Audible2")
    '        End While
    '        sqLconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "error")
    '    End Try
    'End Sub

    Private Sub txtWidth_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtHeight_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    'Private Sub btnBrowseAudibleFile_Click(sender As Object, e As EventArgs)
    '    openFileAudible.Title = "Select Audio file.."
    '    openFileAudible.InitialDirectory = Application.StartupPath
    '    openFileAudible.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*"
    '    If (openFileAudible.ShowDialog = DialogResult.OK) Then
    '        txtAudibleFilename.Text = System.IO.Path.GetFullPath(openFileAudible.FileName)
    '    End If
    'End Sub

    Private Sub btnSbmtProperties_Click(sender As Object, e As EventArgs) Handles btnSbmtProperties.Click

        If txtforeColor.BackColor.Name <> "" And txtBackcolor.BackColor.Name <> "" Then
            sqLconn.Open()
            sqLcmd = New SqlCommand("update tblAnnunciator set ForeColor='" & txtforeColor.BackColor.ToArgb & "',BackColor='" & txtBackcolor.BackColor.ToArgb & "',Blink='" & ChkboxBlink.Checked & "',BlinkSpeed='" & cmbBoxBlinkSecs.Text & "',width='" & txtWidth.Text & "',Height='" & txtHeight.Text & "' where AlarmState='" & AlarmVal & "'", sqLconn)
            dr = sqLcmd.ExecuteReader
            sqLconn.Close()
            '  clear()
            Me.Close()
            Annunciator_ColorSetting.DisplayData()
        Else
            MsgBox("Please Enter the Value !")
        End If

    End Sub
    'Private Sub btnAdd_Click_1(sender As Object, e As EventArgs)
    '    Dim i As Integer = AudibleValue.Rows.Add()
    '    AudibleValue.Rows(i).Cells(1).Value = ""
    '    AudibleValue.Rows(i).Cells(2).Value = ""
    'End Sub





    'Private Sub btnAudible1Brwse_Click(sender As Object, e As EventArgs) Handles btnAudible1Brwse.Click
    '    openFileAudible.ShowDialog()
    '    openFileAudible.Title = "Select Audio file.."
    '    openFileAudible.InitialDirectory = Application.StartupPath
    '    openFileAudible.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*"
    '    If (openFileAudible.ShowDialog = DialogResult.OK) Then
    '        txtAudible.Text = System.IO.Path.GetFullPath(openFileAudible.FileName)
    '    End If
    'End Sub

    'Private Sub btnAudible2Brwse_Click(sender As Object, e As EventArgs) Handles btnAudible2Brwse.Click
    '    openFileAudible.ShowDialog()
    '    openFileAudible.Title = "Select Audio file.."
    '    openFileAudible.InitialDirectory = Application.StartupPath
    '    openFileAudible.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*"
    '    If (openFileAudible.ShowDialog = DialogResult.OK) Then
    '        txtAudible2.Text = System.IO.Path.GetFullPath(openFileAudible.FileName)
    '    End If
    'End Sub

    'Private Sub btnDelete_Click(sender As Object, e As EventArgs)
    '    If AudibleValue.Rows.Count > 0 AndAlso AudibleValue.CurrentRow.Index <> -1 Then
    '        AudibleValue.Rows.RemoveAt(AudibleValue.CurrentRow.Index)
    '    End If
    'End Sub

    'Private Sub AudibleValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If AudibleValue.CurrentCell.ColumnIndex = 1 Or AudibleValue.CurrentCell.ColumnIndex = 2 Then
    '        openFileAudible.ShowDialog()
    '        openFileAudible.Title = "Select Audio file.."
    '        'openFileAudible.InitialDirectory = Application.StartupPath
    '        openFileAudible.Filter = "wav (*.wav)|*.wav|All files (*.*)|*.*"
    '        If (openFileAudible.ShowDialog = DialogResult.OK) Then
    '            AudibleValue.CurrentCell.Value = System.IO.Path.GetFullPath(openFileAudible.FileName)
    '        End If
    '    End If
    'End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

    End Sub
End Class
