' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-12-2014
' ***********************************************************************
' <copyright file="DBQueryForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************


Imports System.Data.SqlClient
Public Class DBQueryForm
    Private AL_TagID As New ArrayList
    Private AL_Tag As New ArrayList
    Private AL_ParameterAE As New ArrayList
    Private AL_ParameterAEid As New ArrayList


    Private _Condition As String = ""
    Private _Query As String = ""
    Friend _Flag As String = "Grid"
    Friend _QueryString As String = ""

    Private Fun_Idx As String = ""

    Friend blnField As Boolean
    Friend AL_Fields As New ArrayList

    Friend blnGBField As Boolean
    Friend AL_GBFields As New ArrayList

    Private Sub rdobtnnnRec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnnnRec.CheckedChanged
        If rdobtnnnRec.Checked Then
            txtBoxnnRec.Enabled = True
            txtBoxnnDays.Enabled = False
        End If

    End Sub

    Private Sub rdobtnnnDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnnnDays.CheckedChanged
        If rdobtnnnDays.Checked Then
            txtBoxnnDays.Enabled = True
            txtBoxnnRec.Enabled = False
        End If
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lblAND_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAND.DoubleClick
        If lblAND.Text = "(AND)" Then
            lblAND.Text = "(OR)"
        Else
            lblAND.Text = "(AND)"
        End If
    End Sub

    Private Sub ckBoxbuild_Fun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckBoxbuild_Fun.CheckedChanged
        If ckBoxbuild_Fun.Checked Then
            cboxBuildFunction.Enabled = True
            CKlstBox__Fields.Enabled = False
            rdobtnnnDays.Enabled = True

            If rdobtnnnRec.Checked Then
                txtBoxnnDays.Enabled = False
            Else
                txtBoxnnDays.Enabled = True
            End If
        Else
            cboxBuildFunction.Enabled = False
            CKlstBox__Fields.Enabled = True
            txtBoxnnDays.Enabled = False
            rdobtnnnDays.Enabled = False
            rdobtnnnRec.Checked = True
        End If
    End Sub

    Private Sub DBQueryForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        blnField = False
        AL_Fields.Clear()
        blnGBField = False
        AL_GBFields.Clear()
        cboxFunField.Text = ""
        CBoxFields.SelectedIndex = -1
        cboxCondition.SelectedIndex = -1
        cboxValue.SelectedIndex = -1
        cboxBuildFunction.SelectedIndex = -1
        cboxFunction.SelectedIndex = -1
        cboxFunField.SelectedIndex = -1
        rtBoxCondition.Clear()

    End Sub

    Private Sub DBQueryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GrpBoxAnnunciator.Visible = True
        If blnField Then
            For i As Integer = 0 To AL_Fields.Count - 1
                CKlstBox__Fields.SetItemChecked(AL_Fields(i), True)
            Next
            ckBoxbuild_Fun.Checked = False
        Else
            ckBoxbuild_Fun.Checked = True
        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            Dim fields As String
            '.SelectionMode = SelectionMode.MultiExtended
            If _Flag = "Grid" Then       '*******Radio button Table if Checked ********
                _Query = ""
                fields = ""
                If ckBoxbuild_Fun.Checked Then   'for build in function

                    If Not (String.IsNullOrEmpty(cboxBuildFunction.Text)) Then
                        _Query = "0@" & cboxBuildFunction.Text '0 for build in function

                        If rdobtnnnDays.Checked Then 'nn Days
                            If (String.IsNullOrEmpty(txtBoxnnDays.Text)) Then
                                MsgBox("Last nn Days field empty!!!")
                                Exit Sub
                            Else
                                _Query &= "@0@" & txtBoxnnDays.Text & "@" & rtBoxCondition.Text
                                'Starting 
                                If Not String.IsNullOrEmpty(rtBoxCondition.Text) Then
                                    Dim tt As String = ""
                                    If rtBoxCondition.Text.EndsWith("AND", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("OR", StringComparison.CurrentCulture) Then
                                        tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                    Else
                                        tt = rtBoxCondition.Text
                                    End If
                                    Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxBuildFunction.Text)
                                    Dim where As String = ""
                                    Dim gBy As String = ""
                                    If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                        where = MainPage.Lst_Where(idx) & " AND "
                                    Else
                                        where = " "
                                    End If
                                    If MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx)) Then
                                        gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                    Else
                                        gBy = " "
                                    End If
                                    'Forming Query
                                    _QueryString = "SELECT " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) AND  GETDATE() AND " & where & tt & gBy
                                Else
                                    Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxBuildFunction.Text)
                                    Dim where As String = ""
                                    Dim gBy As String = ""
                                    If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                        where = " AND " & MainPage.Lst_Where(idx)
                                    Else
                                        where = " "
                                    End If
                                    If MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx)) Then
                                        gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                    Else
                                        gBy = " "
                                    End If

                                    'Forming Query
                                    _QueryString = "SELECT " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) AND  GETDATE() " & where & gBy

                                End If
                                'Ending

                            End If
                        End If

                        'nn Record
                        If rdobtnnnRec.Checked Then
                            If (Not txtBoxnnRec.Text Is Nothing AndAlso String.IsNullOrEmpty(txtBoxnnRec.Text)) Then
                                MsgBox("Last nn Record field empty!!!")
                                Exit Sub
                            Else
                                _Query &= "@1@" & txtBoxnnRec.Text & "@" & rtBoxCondition.Text
                                'Starting 
                                If Not (Not rtBoxCondition.Text Is Nothing AndAlso String.IsNullOrEmpty(rtBoxCondition.Text)) Then
                                    Dim tt As String = ""
                                    If rtBoxCondition.Text.EndsWith("AND", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("OR", StringComparison.CurrentCulture) Then
                                        tt = " WHERE " & rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                    Else
                                        tt = " WHERE " & rtBoxCondition.Text
                                    End If
                                    Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxBuildFunction.Text)
                                    Dim where As String = ""
                                    Dim gBy As String = ""
                                    If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                        where = " AND " & MainPage.Lst_Where(idx)
                                    Else
                                        where = " "
                                    End If
                                    If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                        gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                    Else
                                        gBy = " "
                                    End If
                                    'Forming Query
                                    _QueryString = "SELECT " & MainPage.Lst_Display_fields(idx) & " FROM  ( SELECT TOP " & txtBoxnnRec.Text & " * FROM  " & MainPage.Lst_TableName(idx) & tt & where & " ORDER BY StandingSince DESC ) " & MainPage.Lst_TableName(idx) & gBy
                                Else
                                    Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxBuildFunction.Text)
                                    Dim where As String = ""
                                    Dim gBy As String = ""
                                    If (MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx))) Then
                                        where = " WHERE " & MainPage.Lst_Where(idx)
                                    Else
                                        where = " "
                                    End If
                                    If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                        gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                    Else
                                        gBy = " "
                                    End If
                                    'Forming Query
                                    _QueryString = "SELECT " & MainPage.Lst_Display_fields(idx) & " FROM  ( SELECT TOP " & txtBoxnnRec.Text & " * FROM  " & MainPage.Lst_TableName(idx) & where & " ORDER BY StandingSince DESC ) " & MainPage.Lst_TableName(idx) & gBy

                                End If
                                'Ending

                            End If
                        End If


                    Else
                        MsgBox("Please Select any build in Function!!")
                        Exit Sub
                    End If
                    '*** End Function Part


                Else    '*** Start Fields Part
                    _Query = ""
                    If CKlstBox__Fields.CheckedItems.Count > 0 Then
                        For Each item As String In CKlstBox__Fields.CheckedItems
                            fields &= Trim(item) & ","
                        Next
                        _Query = "1@" & fields.Remove(fields.Length - 1, 1) '1 for select fields

                        If rdobtnnnDays.Checked Then
                            If (Not txtBoxnnDays.Text Is Nothing AndAlso String.IsNullOrEmpty(txtBoxnnDays.Text)) Then
                                MsgBox("Last nn Days field empty!!!")
                                Exit Sub
                            Else
                                _Query &= "@0@" & txtBoxnnDays.Text & "@" & rtBoxCondition.Text '0 for nn days


                                If Not String.IsNullOrEmpty(rtBoxCondition.Text) Then
                                    Dim tt As String = ""
                                    If rtBoxCondition.Text.EndsWith("AND", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("OR", StringComparison.CurrentCulture) Then
                                        tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                    Else
                                        tt = rtBoxCondition.Text
                                    End If
                                    _QueryString = "SELECT EventID," & fields.Remove(fields.Length - 1, 1) & " FROM VueEvents WHERE StartTime BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) AND  GETDATE() AND EventId >0 AND " & tt & " ORDER BY Start_Time DESC"
                                Else
                                    _QueryString = "SELECT EventID," & fields.Remove(fields.Length - 1, 1) & " FROM VueEvents WHERE StartTime BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) AND  GETDATE() AND EventId >0 ORDER BY Start_Time  DESC"
                                End If
                            End If
                        End If
                        If rdobtnnnRec.Checked Then
                            If (String.IsNullOrEmpty(txtBoxnnRec.Text)) Then
                                MsgBox("Last nn Record field empty!!!")
                                Exit Sub
                            Else
                                _Query &= "@1@" & txtBoxnnRec.Text & "@" & rtBoxCondition.Text '1 for nn records

                                If (Not String.IsNullOrEmpty(rtBoxCondition.Text)) Then
                                    'write to remove last AND or OR
                                    Dim tt As String = ""
                                    If rtBoxCondition.Text.EndsWith("AND", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("OR", StringComparison.CurrentCulture) Then
                                        tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                    Else
                                        tt = rtBoxCondition.Text
                                    End If

                                    _QueryString = "SELECT TOP " & txtBoxnnRec.Text & " EventID," & fields.Remove(fields.Length - 1, 1) & " FROM VueEvents WHERE " & tt & " AND EventId >0 ORDER BY StartTime DESC"
                                Else
                                    _QueryString = "SELECT TOP " & txtBoxnnRec.Text & " EventID," & fields.Remove(fields.Length - 1, 1) & " FROM VueEvents WHERE  EventId >0 ORDER BY StartTime DESC"
                                End If

                            End If
                        End If
                    Else
                        MsgBox("Please Select the Fields !!!", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(3).Value = _Query
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(4).Value = _Flag
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(5).Value = _QueryString

                Me.Close()
            End If

            '****************************************Radio button Annunciator if Checked ********

            If _Flag = "Annunciator" Then       '
                _Query = ""
                'nn Record
                ' If LstBoxSelectValue.Items.Count > 0 Then
                Dim DataListBox As New List(Of String)
                For Each item In LstBoxSelectValue.Items
                    DataListBox.Add(item)
                Next

                Dim dt As String = Join(DataListBox.ToArray(), ",")
                _Query = "Annunciator"
                _QueryString = dt
                Dim Tagpar_AliasName As String
                If chkAliasNameView.Checked AndAlso chkTagParView.Checked Then

                    Tagpar_AliasName = "Tagpar_AliasName"
                ElseIf chkAliasNameView.Checked Then
                    Tagpar_AliasName = "AliasName"
                ElseIf chkTagParView.Checked Then
                    Tagpar_AliasName = "Tagpar"
                Else
                    Tagpar_AliasName = "Tagpar"
                End If

                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(3).Value = _Query
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(4).Value = _Flag
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(5).Value = Tagpar_AliasName & "^" & _QueryString

                Me.Close()
                'End If
            End If

            '*******Radio button Value if Checked ********

            If _Flag = "Value" Then
                _Query = ""
                If Not cboxFunction.SelectedIndex <= 2 Then
                    _Query = "1@" & cboxFunction.Text '1 for Non aggregate Function like Standing Alarms

                Else
                    If Not String.IsNullOrEmpty(cboxFunction.Text) AndAlso Not (String.IsNullOrEmpty(cboxFunField.Text)) Then
                        _Query = "0@" & cboxFunction.Text & "(" & cboxFunField.Text & ")" '0 for aggregate Function
                    Else
                        MsgBox("Function fields empty!!!")
                        Exit Sub
                    End If
                End If

                If rdobtnnnDays.Checked Then 'nn Days
                    If (String.IsNullOrEmpty(txtBoxnnDays.Text)) Then
                        MsgBox("Last nn Days field empty!!!")
                        Exit Sub
                    Else
                        _Query &= "@0@" & txtBoxnnDays.Text & "@" & rtBoxCondition.Text

                        If cboxFunction.SelectedIndex <= 2 Then
                            If (Not String.IsNullOrEmpty(rtBoxCondition.Text)) Then
                                Dim tt As String = ""
                                If rtBoxCondition.Text.EndsWith("And", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("Or", StringComparison.CurrentCulture) Then
                                    tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                Else
                                    tt = rtBoxCondition.Text
                                End If
                                _QueryString = "Select " & cboxFunction.Text & "(" & cboxFunField.Text & ") As Value FROM VueEvents WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE() " & tt
                            Else
                                _QueryString = "Select " & cboxFunction.Text & "(" & cboxFunField.Text & ") As Value FROM VueEvents WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE() "

                            End If

                        Else
                            'Starting
                            If (Not String.IsNullOrEmpty(rtBoxCondition.Text)) Then
                                Dim tt As String = ""
                                If rtBoxCondition.Text.EndsWith("And", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("Or", StringComparison.CurrentCulture) Then
                                    tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                                Else
                                    tt = rtBoxCondition.Text
                                End If
                                Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                                Dim where As String = ""
                                Dim gBy As String = ""

                                If (MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx))) Then
                                    where = MainPage.Lst_Where(idx) & " And "
                                Else
                                    where = " "
                                End If

                                If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                    gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                Else
                                    gBy = " "
                                End If
                                'Forming Query
                                _QueryString = "Select COUNT(*) As Value FROM (Select " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE() And " & where & tt & gBy & ") Sub"
                            Else
                                Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                                Dim where As String = ""
                                Dim gBy As String = ""
                                If (MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx))) Then
                                    where = " And " & MainPage.Lst_Where(idx)
                                Else
                                    where = " "
                                End If
                                If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                    gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                                Else
                                    gBy = " "
                                End If
                                'Forming Query
                                _QueryString = "Select COUNT(*) As Value FROM (Select " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE()  " & where & gBy & ") Sub"
                            End If
                            'Ending

                        End If
                    End If
                End If

                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(3).Value = _Query
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(4).Value = _Flag
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(5).Value = _QueryString

                Me.Close()

            End If
            '*******Radio button Graph if Checked ********

            If _Flag = "Trend" Then
                _Query = ""
                Fun_Idx = ""
                fields = ""

                _Query = "1@" & cboxFunction.Text '1 for Non aggregate Function like Standing Alarms


                If rdobtnnnDays.Checked Then 'nn Days
                    If (String.IsNullOrEmpty(txtBoxnnDays.Text)) Then
                        MsgBox("Last nn Days field empty!!!")
                        Exit Sub
                    Else
                        _Query &= "@0@" & txtBoxnnDays.Text & "@" & rtBoxCondition.Text
                        'Starting 
                        If Not String.IsNullOrEmpty(rtBoxCondition.Text) Then
                            Dim tt As String = ""
                            If rtBoxCondition.Text.EndsWith("And", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("Or", StringComparison.CurrentCulture) Then
                                tt = rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                            Else
                                tt = rtBoxCondition.Text
                            End If
                            Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                            Dim where As String = ""
                            Dim gBy As String = ""
                            If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                where = MainPage.Lst_Where(idx) & " And "
                            Else
                                where = " "
                            End If
                            If MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx)) Then
                                gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                            Else
                                gBy = " "
                            End If
                            'Forming Query
                            _QueryString = "Select " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE() And " & where & tt & gBy
                        Else
                            Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                            Dim where As String = ""
                            Dim gBy As String = ""
                            If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                where = " And " & MainPage.Lst_Where(idx)
                            Else
                                where = " "
                            End If
                            If MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx)) Then
                                gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                            Else
                                gBy = " "
                            End If

                            'Forming Query
                            _QueryString = "Select " & MainPage.Lst_Display_fields(idx) & " FROM  " & MainPage.Lst_TableName(idx) & " WHERE StandingSince BETWEEN DATEADD(dd,-" & txtBoxnnDays.Text & ",GETDATE()) And  GETDATE() " & where & gBy

                        End If
                        'Ending

                    End If
                End If

                'nn Record
                If rdobtnnnRec.Checked Then
                    If (Not txtBoxnnRec.Text Is Nothing AndAlso String.IsNullOrEmpty(txtBoxnnRec.Text)) Then
                        MsgBox("Last nn Record field empty!!!")
                        Exit Sub
                    Else
                        _Query &= "@1@" & txtBoxnnRec.Text & "@" & rtBoxCondition.Text
                        'Starting 
                        If Not (Not rtBoxCondition.Text Is Nothing AndAlso String.IsNullOrEmpty(rtBoxCondition.Text)) Then
                            Dim tt As String = ""
                            If rtBoxCondition.Text.EndsWith("And", StringComparison.CurrentCulture) Or rtBoxCondition.Text.EndsWith("Or", StringComparison.CurrentCulture) Then
                                tt = " WHERE " & rtBoxCondition.Text.Substring(0, InStrRev(rtBoxCondition.Text, " "))
                            Else
                                tt = " WHERE " & rtBoxCondition.Text
                            End If
                            Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                            Dim where As String = ""
                            Dim gBy As String = ""
                            If MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx)) Then
                                where = " And " & MainPage.Lst_Where(idx)
                            Else
                                where = " "
                            End If
                            If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                            Else
                                gBy = " "
                            End If
                            'Forming Query
                            _QueryString = "Select " & MainPage.Lst_Display_fields(idx) & " FROM  ( Select TOP " & txtBoxnnRec.Text & " * FROM  " & MainPage.Lst_TableName(idx) & tt & where & " ORDER BY StandingSince DESC ) " & MainPage.Lst_TableName(idx) & gBy
                        Else
                            Dim idx As Integer = cboxBuildFunction.Items.IndexOf(cboxFunction.Text)
                            Dim where As String = ""
                            Dim gBy As String = ""
                            If (MainPage.Lst_Where.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_Where(idx))) Then
                                where = " WHERE " & MainPage.Lst_Where(idx)
                            Else
                                where = " "
                            End If
                            If (MainPage.Lst_GroupBy.Count > 0 AndAlso Not String.IsNullOrEmpty(MainPage.Lst_GroupBy(idx))) Then
                                gBy = " GROUP BY " & MainPage.Lst_GroupBy(idx)
                            Else
                                gBy = " "
                            End If
                            'Forming Query
                            _QueryString = "Select " & MainPage.Lst_Display_fields(idx) & " FROM  ( Select TOP " & txtBoxnnRec.Text & " * FROM  " & MainPage.Lst_TableName(idx) & where & " ORDER BY StandingSince DESC ) " & MainPage.Lst_TableName(idx) & gBy

                        End If
                        'Ending

                    End If
                End If

                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(3).Value = _Query
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(4).Value = _Flag
                SupraDBChannelsListForm.GVChannelsAdd.CurrentRow.Cells(5).Value = _QueryString

                Me.Close()
            End If


        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@btnOk_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


    End Sub
    Private Sub Proc_GetTags()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim sqLdr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select TagID,TagNo from tblTag", sqLconn)
            sqLdr = sqLcmd.ExecuteReader
            AL_TagID = New ArrayList
            AL_Tag = New ArrayList
            While sqLdr.Read
                AL_Tag.Add(sqLdr("TagNo"))
                AL_TagID.Add(sqLdr("TagID"))
            End While
            cboxValue.Items.Clear()
            cboxValue.Items.AddRange(AL_Tag.ToArray)

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_GetTags()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub cboxFunction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxFunction.SelectedIndexChanged

        If rdobtnTrend.Checked Then
            If cboxFunction.SelectedIndex = 5 Then
                btnOk.Enabled = False
                MsgBox("Trending Not Available!!", MsgBoxStyle.Information)
            Else
                btnOk.Enabled = True
            End If
            cboxFunField.Enabled = False
        Else
            btnOk.Enabled = True
            If Not cboxFunction.SelectedIndex <= 2 Then
                cboxFunField.Enabled = False

            Else
                cboxFunField.Items.Clear()
                cboxFunField.Items.AddRange(New String() {"UserField1", "UserField2", "UserField3", "UserField4", "UserField5"})

                cboxFunField.Enabled = True

            End If
        End If

    End Sub
    Private Sub Proc_GetChannel()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Channel from tblChannel Where Active=1", sqLconn)
            dr = sqLcmd.ExecuteReader
            cboxValue.Items.Clear()
            While dr.Read
                cboxValue.Items.Add(dr("Channel"))
            End While

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_GetChannel()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub Annunciator_GetChannel()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Channel from tblChannel Where Active=1", sqLconn)
            dr = sqLcmd.ExecuteReader
            CBoxAnnunValue.Items.Clear()
            While dr.Read
                CBoxAnnunValue.Items.Add(dr("Channel"))
            End While

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetChannel()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub Proc_GetUnit()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Unit from tblUnit", sqLconn)
            dr = sqLcmd.ExecuteReader
            cboxValue.Items.Clear()
            While dr.Read
                cboxValue.Items.Add(dr("Unit"))
            End While
        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_GetUnit()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub Annunciator_GetUnit()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Unit from tblUnit", sqLconn)
            dr = sqLcmd.ExecuteReader
            CBoxAnnunValue.Items.Clear()
            While dr.Read
                CBoxAnnunValue.Items.Add(dr("Unit"))
            End While
        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetUnit()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub Proc_GetArea()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Area  from tblArea", sqLconn)
            dr = sqLcmd.ExecuteReader
            cboxValue.Items.Clear()
            While dr.Read
                cboxValue.Items.Add(dr("Area"))
            End While
        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_GetArea()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub Annunciator_GetArea()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Area  from tblArea", sqLconn)
            dr = sqLcmd.ExecuteReader
            CBoxAnnunValue.Items.Clear()
            While dr.Read
                CBoxAnnunValue.Items.Add(dr("Area"))
            End While
        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetArea()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub Proc_GetPlant()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Plant from tblPlant", sqLconn)
            dr = sqLcmd.ExecuteReader
            cboxValue.Items.Clear()
            While dr.Read
                cboxValue.Items.Add(dr("Plant"))
            End While
            sqLconn.Close()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_GetPlant()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub Annunciator_GetPlant()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select Plant from tblPlant", sqLconn)
            dr = sqLcmd.ExecuteReader
            CBoxAnnunValue.Items.Clear()
            While dr.Read
                CBoxAnnunValue.Items.Add(dr("Plant"))
            End While
            sqLconn.Close()
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_GetPlant()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub Proc_ParameterAE()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim sqLdr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("Select ParameterAEId, ParameterAEName from tblParameterAE", sqLconn)
            sqLdr = sqLcmd.ExecuteReader
            AL_ParameterAEid = New ArrayList
            AL_ParameterAE = New ArrayList
            While sqLdr.Read
                AL_ParameterAE.Add(sqLdr("ParameterAEName"))
                AL_ParameterAEid.Add(sqLdr("ParameterAEId"))
            End While
            cboxValue.Items.Clear()
            cboxValue.Items.AddRange(AL_ParameterAE.ToArray)

        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Proc_ParameterAE()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub
    Private Sub CBoxFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBoxFields.SelectedIndexChanged
        If CBoxFields.SelectedIndex = 0 Then
            Proc_GetChannel()
        ElseIf CBoxFields.SelectedIndex = 1 Then
            cboxValue.Items.Clear()
            'Proc_GetStartTime()
        ElseIf CBoxFields.SelectedIndex = 2 Then
            cboxValue.Items.Clear()
            'Proc_GetAlarmIdentifier()
        ElseIf CBoxFields.SelectedIndex = 3 Then
            cboxValue.Items.Clear()
            'Proc_GetPriority()
        ElseIf CBoxFields.SelectedIndex = 4 Then
            Proc_GetTags()
            'cboxValue.'SelectedValue = SelectionMode.MultiExtended
        ElseIf CBoxFields.SelectedIndex = 5 Then
            Proc_ParameterAE()
        ElseIf CBoxFields.SelectedIndex = 6 Then
            Proc_GetUnit()
        ElseIf CBoxFields.SelectedIndex = 7 Then
            Proc_GetArea()
        ElseIf CBoxFields.SelectedIndex = 8 Then
            Proc_GetPlant()
        End If
    End Sub
    Private Sub btnWhereAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWhereAdd.Click
        If Not (Not CBoxFields.Text Is Nothing AndAlso String.IsNullOrEmpty(CBoxFields.Text)) And Not (Not cboxCondition.Text Is Nothing AndAlso String.IsNullOrEmpty(cboxCondition.Text)) And Not (Not cboxValue.Text Is Nothing AndAlso String.IsNullOrEmpty(cboxValue.Text)) Then
            rtBoxCondition.AppendText(" " & CBoxFields.Text & " " & cboxCondition.Text & "'" & cboxValue.Text & "' " & lblAND.Text.Replace("(", "").Replace(")", ""))
            CBoxFields.Text = ""
            cboxCondition.Text = ""
            cboxValue.Text = ""
        End If
    End Sub

    Private Sub rdobtnDisplay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnDisplay.CheckedChanged
        If rdobtnDisplay.Checked Then
            GrpBoxAnnunciator.Visible = False
            GrpBoxSelect.Visible = True
            grpBoxFunction.Visible = True
            grpBoxWhere.Visible = True
            GrpBoxSelect.Enabled = True
            grpBoxFunction.Enabled = False
            rdobtnnnRec.Enabled = True
            rdobtnnnDays.Enabled = True
            If ckBoxbuild_Fun.Checked Then
                txtBoxnnDays.Enabled = True
            Else
                txtBoxnnDays.Enabled = False
            End If
            rdobtnnnRec.Checked = True
            _Flag = "Grid"
        End If

    End Sub

    Private Sub rdobtnTrend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnTrend.CheckedChanged
        If rdobtnTrend.Checked Then
            GrpBoxAnnunciator.Visible = False
            GrpBoxSelect.Visible = True
            grpBoxFunction.Visible = True
            grpBoxWhere.Visible = True
            GrpBoxSelect.Enabled = False
            grpBoxFunction.Enabled = True
            rdobtnnnRec.Enabled = True
            rdobtnnnRec.Checked = True
            txtBoxnnRec.Enabled = True
            rdobtnnnDays.Enabled = True
            If cboxFunction.Items.Contains("Max") Then
                cboxFunction.Items.RemoveAt(0)
                cboxFunction.Items.RemoveAt(0)
                cboxFunction.Items.RemoveAt(0)
            End If

            _Flag = "Trend"
        End If

    End Sub

    Private Sub rdobtnValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnValue.CheckedChanged
        If rdobtnValue.Checked Then
            GrpBoxSelect.Enabled = False
            GrpBoxSelect.Visible = True
            grpBoxFunction.Visible = True
            grpBoxWhere.Visible = True
            grpBoxFunction.Enabled = True
            rdobtnnnRec.Enabled = False
            txtBoxnnRec.Enabled = False
            rdobtnnnDays.Enabled = True
            rdobtnnnDays.Checked = True
            txtBoxnnDays.Enabled = True
            If Not cboxFunction.Items.Contains("Max") Then
                cboxFunction.Items.Insert(0, "Avg")
                cboxFunction.Items.Insert(0, "Min")
                cboxFunction.Items.Insert(0, "Max")
            End If

            _Flag = "Value"
        End If

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        rtBoxCondition.Clear()
    End Sub

    Private Sub rdobtnAnnunciator_CheckedChanged(sender As Object, e As EventArgs) Handles rdobtnAnnunciator.CheckedChanged
        GrpBoxSelect.Visible = False
        grpBoxFunction.Visible = False
        grpBoxWhere.Visible = False
        'LstboxAnnunFields.Items.Clear()
        LstBoxSelectValue.Items.Clear()
        If rdobtnAnnunciator.Checked Then
            GrpBoxAnnunciator.Visible = True
            rdobtnnnRec.Enabled = True
            rdobtnnnDays.Enabled = False
            If ckBoxbuild_Fun.Checked <> True Then
                txtBoxnnDays.Enabled = False
            Else
                txtBoxnnDays.Enabled = False
            End If
            '  rdobtnnnRec.Checked = True
            _Flag = "Annunciator"
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxAnnunFields.SelectedIndexChanged
        If CBoxAnnunFields.SelectedIndex = 0 Then
            Annunciator_GetPlant()
        ElseIf CBoxAnnunFields.SelectedIndex = 1 Then
            Annunciator_GetArea()
        ElseIf CBoxAnnunFields.SelectedIndex = 2 Then
            Annunciator_GetUnit()
        ElseIf CBoxAnnunFields.SelectedIndex = 3 Then

        End If
    End Sub

    Private Sub CBoxAnnunValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxAnnunValue.SelectedIndexChanged
        Dim Annunfield = CBoxAnnunFields.Text
        Dim AnnunValue = CBoxAnnunValue.Text
        If Annunfield <> "" And AnnunValue <> "" Then
            LoadAnnun_TagValue(Annunfield, AnnunValue)
            LoadAnnun_ParameterValue()
        End If

    End Sub

    Public Sub LoadAnnun_TagValue(ByVal CBoxAnnunFields As String, ByVal CBoxAnnunValue As String)
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            'Dim SecondName As String =
            '  Dim FindVal = CBoxAnnunFields.Text & "=" & CBoxAnnunValue.Text
            sqLconn.Open()
            sqLcmd = New SqlCommand("select tg.TagNo from tblTag as tg join tblUnit as tu on tg.UnitId=tu.UnitId join tblArea as ta on ta.AreaId=tu.AreaId join tblPlant as tp on tp.PlantId=ta.PlantId where " & CBoxAnnunFields & "='" + CBoxAnnunValue + "'", sqLconn)
            dr = sqLcmd.ExecuteReader
            cBoxTagNoField.Items.Clear()
            While dr.Read
                cBoxTagNoField.Items.Add(dr("TagNo"))
            End While
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_CBoxAnnunValue()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Public Sub LoadAnnun_ParameterValue()
        Dim sqLconn As New SqlConnection
        Dim sqLcmd As New SqlCommand
        Dim dr As SqlDataReader
        Try
            sqLconn.ConnectionString = MainPage.Constr
            sqLconn.Open()
            sqLcmd = New SqlCommand("select ParameterId,Parameter from tblParameter", sqLconn)
            dr = sqLcmd.ExecuteReader
            cBoxParameterField.Items.Clear()
            While dr.Read
                cBoxParameterField.Items.Add(dr("Parameter"))
            End While
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_CBoxAnnunValue()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If sqLconn.State = ConnectionState.Open Then
                sqLconn.Close()
            End If
        End Try
    End Sub

    Private Sub grpboxType_Enter(sender As Object, e As EventArgs) Handles grpboxType.Enter
    End Sub



    Private Sub LstBoxSelectValue_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LstBoxSelectValue.MouseDoubleClick
        Dim selectValue = LstBoxSelectValue.SelectedItem.ToString()
        LstBoxSelectValue.Items.Remove(selectValue)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LstBoxSelectValue.Items.Clear()
    End Sub



    Private Sub BtnAdd_TagParameter_Click(sender As Object, e As EventArgs) Handles BtnAdd_TagParameter.Click
        Dim DataValue = txtAlaiseName.Text & "~" & cBoxTagNoField.Text & "." & cBoxParameterField.Text
        If (LstBoxSelectValue.Items.Contains(DataValue)) Then
            MsgBox("THIS ITEM ALREADY EXISTS")
        Else
            LstBoxSelectValue.Items.Add(DataValue)
        End If

    End Sub

    Private Sub btnMoveUpValue_Click(sender As Object, e As EventArgs) Handles btnMoveUpValue.Click
        Dim item As Object = LstBoxSelectValue.SelectedItem
        If Not item Is Nothing Then
            Dim index As Integer = LstBoxSelectValue.Items.IndexOf(item)
            If index <> 0 Then
                LstBoxSelectValue.Items.RemoveAt(index)
                index -= 1
                LstBoxSelectValue.Items.Insert(index, item)
                LstBoxSelectValue.SelectedIndex = index
            End If
        End If
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        Dim item As Object = LstBoxSelectValue.SelectedItem
        If Not item Is Nothing Then
            Dim index As Integer = LstBoxSelectValue.Items.IndexOf(item)
            If index < LstBoxSelectValue.Items.Count - 1 Then
                LstBoxSelectValue.Items.RemoveAt(index)
                index += 1
                LstBoxSelectValue.Items.Insert(index, item)
                LstBoxSelectValue.SelectedIndex = index
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class