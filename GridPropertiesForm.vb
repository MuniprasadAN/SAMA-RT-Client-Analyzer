' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-07-2014
'
' Last Modified By : supra
' Last Modified On : 02-11-2014
' ***********************************************************************
' <copyright file="GridPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Public Class GridPropertiesForm
    Private ColDialog As New ColorDialog
    Private Index_Collection() As Integer
    Private slt_Idx As Integer' = 0
    Friend Channel_Text As String = ""
    Friend C_font, AL_Font As New Font("Verdana", 8, FontStyle.Regular)
    Private bln_ChnlChanged As Boolean

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        Dim fntDlg As New FontDialog
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtFont.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString
            C_font = fntDlg.Font
        End If
    End Sub

    Private Sub btnALFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnALFont.Click
        Dim fntDlg As New FontDialog
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtAL_Font.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString
            AL_Font = fntDlg.Font
        End If
    End Sub
    Private Sub color_BackColorlbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorSL_FC.DoubleClick, ColorSL_BClbl.DoubleClick, ColorAL_FC.DoubleClick, ColorAL_BClbl.DoubleClick, Color_forecolorlbl.DoubleClick, color_BackColorlbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
    End Sub

    Private Sub GridPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Grid")).ToArray

        cBoxActionChannel.Items.Clear()
        For i As Integer = 0 To Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(Index_Collection(i)))
        Next
        cBoxActionChannel.Items.AddRange(MainPage.OPC_ChannelList_Class.OPC_Channel_Name.ToArray)
        cBoxActionChannel.Items.AddRange(MainPage.SAMAHistorian_ChannelList.ChannelReportname.ToArray)
        cBoxActionChannel.Items.AddRange(MainPage.OPCDAChannelsList.OPC_Channel_Name.ToArray)
        cBoxActionChannel.Items.AddRange(MainPage.OPCHDAChannelsList.OPC_Channel_Name.ToArray)
        cBoxActionChannel.Text = Channel_Text

        bln_ChnlChanged = False

        Dim cboxClm As New DataGridViewComboBoxColumn
        cboxClm = GVTHValue.Columns("Condition")
        cboxClm.Items.Clear()
        cboxClm.Items.AddRange(New String() {"TagNo", "Parameter", "AlarmIdentifier", "Priority", "Channel", "Unit", "Value"})
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Properties(MainPage.Grid_TableCtrl)
    End Sub
    Private Sub Properties(ByVal gridTableCtrl As DataGridViewCtrl)

        Try
            'Default Row Style
            gridTableCtrl.RowsDefaultCellStyle.Font = C_font
            gridTableCtrl.RowsDefaultCellStyle.BackColor = color_BackColorlbl.BackColor
            gridTableCtrl.RowsDefaultCellStyle.ForeColor = Color_forecolorlbl.BackColor
            gridTableCtrl.RowsDefaultCellStyle.SelectionBackColor = ColorSL_BClbl.BackColor
            gridTableCtrl.RowsDefaultCellStyle.SelectionForeColor = ColorSL_FC.BackColor
            'Alternate Row Style
            gridTableCtrl.AlternatingRowsDefaultCellStyle.Font = AL_Font
            gridTableCtrl.AlternatingRowsDefaultCellStyle.BackColor = ColorAL_BClbl.BackColor
            gridTableCtrl.AlternatingRowsDefaultCellStyle.ForeColor = ColorAL_FC.BackColor
            gridTableCtrl.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorSL_BClbl.BackColor
            gridTableCtrl.AlternatingRowsDefaultCellStyle.SelectionForeColor = ColorSL_FC.BackColor
            gridTableCtrl.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            gridTableCtrl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            gridTableCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            If bln_ChnlChanged Then
                gridTableCtrl.Columns.Clear()
                bln_ChnlChanged = False
            End If
            gridTableCtrl._ThresholdValue.Clear()
            gridTableCtrl._THForeColor.Clear()
            gridTableCtrl._THBackColor.Clear()
            gridTableCtrl._THFont.Clear()
            For i As Integer = 0 To GVTHValue.Rows.Count - 1
                If Not String.IsNullOrEmpty(GVTHValue.Rows(i).Cells(0).Value) And Not String.IsNullOrEmpty(GVTHValue.Rows(i).Cells(1).Value) And Not String.IsNullOrEmpty(GVTHValue.Rows(i).Cells(4).Value) Then
                    gridTableCtrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(0).Value & "@" & GVTHValue.Rows(i).Cells(1).Value)
                    gridTableCtrl._THForeColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                    gridTableCtrl._THBackColor.Add(GVTHValue.Rows(i).Cells(3).Style.BackColor.ToArgb)
                    gridTableCtrl._THFont.Add(GVTHValue.Rows(i).Cells(4).Value)
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            Next
            gridTableCtrl.AccessibleDescription = cBoxActionChannel.Text

            If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(cBoxActionChannel.Text) Then
                Dim dt As DataTable = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxActionChannel.Text))
                gridTableCtrl.DataSource = dt
                For i = 1 To dt.Columns.Count - 1
                    gridTableCtrl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim i As Integer = GVTHValue.Rows.Add()
        GVTHValue.Rows(i).Cells(2).Style.BackColor = Color.Black
        GVTHValue.Rows(i).Cells(3).Style.BackColor = Color.White
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If GVTHValue.Rows.Count > 0 AndAlso GVTHValue.CurrentRow.Index <> -1 Then
            GVTHValue.Rows.RemoveAt(GVTHValue.CurrentRow.Index)
        End If

    End Sub

    Private Sub GVTHValue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GVTHValue.CellDoubleClick
        If GVTHValue.CurrentCell.ColumnIndex = 2 Or GVTHValue.CurrentCell.ColumnIndex = 3 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
        If GVTHValue.CurrentCell.ColumnIndex = 4 Then
            Dim fntDlg As New FontDialog
            If fntDlg.ShowDialog = DialogResult.OK Then
                GVTHValue.CurrentCell.Value = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString
            End If
        End If
    End Sub

Private Sub cBoxActionChannel_SelectedIndexChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles cBoxActionChannel.SelectedIndexChanged
        bln_ChnlChanged = True
        'Try


        '    'Dim DT As New DataTable
        '    'DT = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxActionChannel.Text))
        '    'DGViewTagSetPnt.Rows.Clear()
        '    'If cBoxActionChannel.Text <> "" Then
        '    '    Dim clmcnt As Integer = DT.Columns.Count - 1
        '    '    For i As Integer = 1 To clmcnt
        '    '        Dim k = DGViewTagSetPnt.Rows.Add()
        '    '        DGViewTagSetPnt.Rows(k).Cells(0).Value = DT.Columns(i).ColumnName
        '    '        If MainPage.Grid_TableCtrl._SetCondtion.Count > 0 Then

        '    '        End If
        '    '    Next

        '    'End If
        'Catch ex As Exception
        '    MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@cBoxActionChannel_SelectedIndexChanged()")
        '    ' MainErrorPV.SetError(lblAlert, "Error !!!")
        'End Try
    End Sub

    Private Sub DGViewTagSetPnt_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGViewTagSetPnt.CellDoubleClick
        If DGViewTagSetPnt.CurrentCell.ColumnIndex = 1 Then
            SetCondition.ShowDialog()
            If SetCondition.Btnok Then
                DGViewTagSetPnt.CurrentCell.Value = SetCondition.conditionstr
            End If
        End If
    End Sub
End Class