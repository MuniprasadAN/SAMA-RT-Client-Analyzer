Public Class MChartPropertiesFormOnlyFields
    Private Sub MChartPropertiesFormNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboActionChannel.Items.Clear()
        cboLambda.Items.Clear()
        cboP1.Items.Clear()
        cboP1Sch.Items.Clear()
        cboP2.Items.Clear()
        cboP2Sch.Items.Clear()
        If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count > 0 Then
            For I As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                cboActionChannel.Items.Add(MainPage.SAMAHistorian_ChannelList.ChannelReportname.Item(I))
            Next
        End If
        'If MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Count > 0 Then

        '    DaTbl = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelValue.Text))
        '    Dtcnt = DaTbl.Columns.Count - 1
        '    tabcnt = tabMChartProp.TabPages.Count - 1
        '    Dim clmcnt As Integer = DaTbl.Columns.Count - 1
        '    If DaTbl.Columns.Count > 0 Then
        '        For i As Integer = 1 To clmcnt
        '            If RBtnValue.Checked = True Then
        '                CboxTagscale.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser1_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser2_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser3_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser4_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser5_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser6_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser7_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser8_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '            Else
        '                CboxTagscale.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser1_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser2_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser3_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser4_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser5_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser6_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser7_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '                Ser8_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
        '            End If

        '        Next
        '    Else
        '        MainPage._errLog.Add("Error@" & Now.ToString & "@" & "Tags not found" & "@ChannelValueSelect()")
        '        MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        '    End If

        'End If

    End Sub

    Private Sub cboActionChannel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActionChannel.SelectedIndexChanged

        If cboActionChannel.Text <> "" Then
            Dim myDataTable As DataTable
            myDataTable = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cboActionChannel.Text))
            Dim intColCount As Integer
            intColCount = myDataTable.Columns.Count - 1
            For I = 0 To intColCount
                If myDataTable.Columns(I).ColumnName = "Tags/Time" Then
                    Continue For
                End If
                cboLambda.Items.Add(myDataTable.Columns(I).ColumnName)
                cboP1.Items.Add(myDataTable.Columns(I).ColumnName)
                cboP1Sch.Items.Add(myDataTable.Columns(I).ColumnName)
                cboP2.Items.Add(myDataTable.Columns(I).ColumnName)
                cboP2Sch.Items.Add(myDataTable.Columns(I).ColumnName)
            Next

        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidRecords() Then
            Dim myDataSet As New DataSet
            Dim myDataTable As New DataTable
            Dim myDataRow As DataRow = myDataTable.NewRow()
            myDataRow("McActionChannel") = cboActionChannel.Text
            myDataRow("McTagForLambda") = cboLambda.Text
            myDataRow("McTagForP1") = cboP1.Text
            myDataRow("MCTagForP1Lambda") = cboP1Sch.Text
            myDataRow("McTagForP2") = cboP2.Text
            myDataRow("MCTagForP2Lambda") = cboP2Sch.Text
            myDataTable.Rows.Add(myDataRow)
            myDataSet.Tables.Add(myDataTable)
            myDataSet.Tables(0).TableName = "Table1"
            myDataSet.WriteXml(fname)
        End If
    End Sub

    Private Function ValidRecords() As Boolean

        ValidRecords = False
        If ValidCombo(cboLambda) AndAlso
            ValidCombo(cboP1) AndAlso
            ValidCombo(cboP1Sch) AndAlso
            ValidCombo(cboP2) AndAlso
            ValidCombo(cboP2Sch) Then
        Else
            Exit Function
        End If
        ValidRecords = True

    End Function

    Private Function ValidCombo(ComboBox1 As ComboBox) As Boolean

        If ComboBox1.Text = "" Then
            MsgBox("Invalid " & ComboBox1.Name.Substring(3) & " Selected!")
            Return False
        End If
        Return True

    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
