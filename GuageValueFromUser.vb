' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="GuageValueFromUser.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.IO
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Public Class GuageValueFromUser
    Dim ColDialog As New ColorDialog
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer
    Private slt_Idx As Integer ' = 0
    Friend Channel_Text As String = ""


    Private Sub cboxcolors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxColors.SelectedIndexChanged
        If cboxColors.SelectedItem = "Gray" Then
            lblColor.BackColor = Color.Gray
        End If
        If cboxColors.SelectedItem = "Red" Then
            lblColor.BackColor = Color.Red
        End If
        If cboxColors.SelectedItem = "Green" Then
            lblColor.BackColor = Color.Green
        End If
        If cboxColors.SelectedItem = "Blue" Then
            lblColor.BackColor = Color.Blue
        End If
        If cboxColors.SelectedItem = "Yellow" Then
            lblColor.BackColor = Color.Yellow
        End If
        If cboxColors.SelectedItem = "Magenta" Then
            If NUDNeedleType.Value = 0 Then
                lblColor.BackColor = Color.Magenta
            Else
                lblColor.BackColor = Color.Violet
            End If

        End If

    End Sub


    Private Sub txtAcceptable_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcceptable.Leave
        If Not (Not txtAcceptable.Text Is Nothing AndAlso String.IsNullOrEmpty(txtAcceptable.Text)) Then
            txtManageStartValue.Text = txtAcceptable.Text
        Else
            ErrorProvider.SetError(txtAcceptable, "Should not be blank !!!")
            txtAcceptable.Focus()
            Exit Sub
        End If
        If CInt(txtAcceptable.Text) > CInt(txtMaxValue.Text) Then
            ErrorProvider.SetError(txtAcceptable, "Value Should be less than Maximum Value")
            txtAcceptable.Focus()
        End If

    End Sub

    Private Sub txtManageable_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManageable.Leave
        If Not (Not txtManageable.Text Is Nothing AndAlso String.IsNullOrEmpty(txtManageable.Text)) Then
            txtUnManageStartValue.Text = txtManageable.Text
        Else
            ErrorProvider.SetError(txtManageable, "Should not be blank !!!")
            txtManageable.Focus()
            Exit Sub
        End If
        If CInt(txtManageable.Text) > CInt(txtMaxValue.Text) Then
            ErrorProvider.SetError(txtManageable, "Value Should be less than Maximum Value")
            txtManageable.Focus()
        End If

    End Sub

    Private Sub txtUnManageable_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnManageable.Leave
        If (Not txtUnManageable.Text Is Nothing AndAlso String.IsNullOrEmpty(txtUnManageable.Text)) Then
            ErrorProvider.SetError(txtUnManageable, "Should not be blank !!!")
            txtUnManageable.Focus()
            Exit Sub
        End If
        If CInt(txtUnManageable.Text) > CInt(txtMaxValue.Text) Then
            ErrorProvider.SetError(txtUnManageable, "Value Should be less than Maximum Value")
            txtUnManageable.Focus()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub AcceptanleColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptanleColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        AcceptanleColor.BackColor = ColDialog.Color
    End Sub

    Private Sub ManageableColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageableColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        ManageableColor.BackColor = ColDialog.Color
    End Sub

    Private Sub UnManageableColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnManageableColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        UnManageableColor.BackColor = ColDialog.Color
    End Sub


    Private Sub Properties(ByVal guageCtrl As AnalyzerMeter.AGauge)
        Try
            'Max and Min Value


            guageCtrl.MinValue = CInt(txtMinValue.Text)
            guageCtrl.MaxValue = CInt(txtUnManageable.Text)


            'range Setting

            guageCtrl.Range_Idx = 0
            guageCtrl.RangesStartValue.SetValue(CInt(txtAcceptStartValue.Text), 0)
            guageCtrl.RangesEndValue.SetValue(CInt(txtAcceptable.Text), 0)
            guageCtrl.RangeColor = AcceptanleColor.BackColor
            guageCtrl.Range_Idx = 1
            guageCtrl.RangesStartValue.SetValue(CInt(txtAcceptable.Text), 1)
            guageCtrl.RangesEndValue.SetValue(CInt(txtManageable.Text), 1)
            guageCtrl.RangeColor = ManageableColor.BackColor

            guageCtrl.Range_Idx = 2
            guageCtrl.RangesStartValue.SetValue(CInt(txtManageable.Text), 2)
            guageCtrl.RangesEndValue.SetValue(CInt(txtUnManageable.Text), 2)
            guageCtrl.RangeColor = UnManageableColor.BackColor
            guageCtrl.RangeEnabled = True


            'BackColor Setting
            guageCtrl.BackColor = lblCtrlBackColor.BackColor

            'Caption Setting
            guageCtrl.CapText = txtCaption.Text
            guageCtrl.CapPosition = New Point(txtCapX.Text, txtCapY.Text)
            'Channel Name
            guageCtrl.AccessibleDescription = CBoxActionChannel.Text



            'StepValue
            guageCtrl.ScaleLinesMajorStepValue = NUDStepValue.Value

            'Needle Properties
            guageCtrl.NeedleType = NUDNeedleType.Value
            guageCtrl.NeedleWidth = NUDNeedleWidth.Value
            If cboxColors.SelectedItem = "Gray" Then
                guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Gray
                guageCtrl.NeedleColor2 = Color.Gray
            End If
            If cboxColors.SelectedItem = "Red" Then
                guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Red
                guageCtrl.NeedleColor2 = Color.Red
            End If
            If cboxColors.SelectedItem = "Green" Then
                guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Green
                guageCtrl.NeedleColor2 = Color.Green
            End If
            If cboxColors.SelectedItem = "Blue" Then

                guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Blue
                guageCtrl.NeedleColor2 = Color.Blue
            End If
            If cboxColors.SelectedItem = "Yellow" Then
                guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Yellow
                guageCtrl.NeedleColor2 = Color.Yellow
            End If
            If cboxColors.SelectedItem = "Magenta" Then
                If NUDNeedleType.Value = 0 Then
                    guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Violet
                    guageCtrl.NeedleColor2 = Color.Magenta
                Else
                    guageCtrl.NeedleColor1 = AnalyzerMeter.AGauge.NeedleColorEnum.Violet
                    guageCtrl.NeedleColor2 = Color.Violet
                End If

            End If


            'Control Arc

            guageCtrl.BaseArcSweep = CInt(txtRangeDegree.Text)
            guageCtrl.BaseArcStart = CInt(txtRangeStartDegree.Text)
            If CkBoxOuterArc.Checked = True Then
                guageCtrl.BaseArcRadius = 80
            Else
                guageCtrl.BaseArcRadius = 0
            End If
            guageCtrl.BaseArcColor = lbloutarccolor.BackColor
            guageCtrl.ScaleLinesInterColor = lbloutarccolor.BackColor
            guageCtrl.ScaleLinesMinorColor = lbloutarccolor.BackColor

            'If Not CBoxActionChannel.Text = "" Then

            '    slt_Idx = Index_Collection(CBoxActionChannel.Items.IndexOf(CBoxActionChannel.Text))

            '    If slt_Idx <> -1 Then
            '        Dim Dt As DataTable = MainPage.Fun_RetrieveDBData(MainPage.channelList._Query_Channel(slt_Idx))
            '        If Not GuageCtrl.DataBindings.Count > 0 Then
            '            If Not Dt.Rows(0).IsNull(0) Then
            '                GuageCtrl.DataBindings.Add("Value", Dt, "Value")
            '            Else
            '                GuageCtrl.Value = 0
            '            End If

            '        Else
            '            GuageCtrl.DataBindings.RemoveAt(0)
            '            If Not Dt.Rows(0).IsNull(0) Then
            '                GuageCtrl.DataBindings.Add("Value", Dt, "Value")
            '            Else
            '                GuageCtrl.Value = 0
            '            End If
            '        End If
            '    End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Properties(MainPage.Guage_Ctrl)
        Me.Close()
    End Sub


    Private Sub lblCtrlBackColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCtrlBackColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblCtrlBackColor.BackColor = ColDialog.Color
    End Sub

    Private Sub lbloutarccolor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbloutarccolor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lbloutarccolor.BackColor = ColDialog.Color
    End Sub

    Private Sub txtCapX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapX.KeyPress, txtCapY.KeyPress, txtMaxValue.KeyPress, txtMinValue.KeyPress
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not Asc(e.KeyChar) = 8 And Not Asc(e.KeyChar) = 45 Then
            e.Handled = True
        Else

            e.Handled = False
        End If
    End Sub
    Private SAMA_Chnl_Index_Collection() As Integer

    Private Sub GuageValueFromUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Value")).ToArray
            OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
            ' SAMA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count).Where(Function(f) MainPage.SAMAHistorian_ChannelList.ChannelTags.Count = 1).ToArray
            OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray
            CBoxActionChannel.Items.Clear()
            For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
                CBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
            Next
            For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
                CBoxActionChannel.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
            Next

            For i As Integer = 0 To OPCDA_Chnl_Index_Collection.Length - 1
                CBoxActionChannel.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(OPCDA_Chnl_Index_Collection(i)))
            Next
            'cBoxActionChannel.Items.AddRange(MainPage.OPC_ChannelList_Class.OPC_Channel_Name.ToArray)
            CBoxActionChannel.Text = Channel_Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub txtMinValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMinValue.Leave
        txtAcceptStartValue.Text = txtMinValue.Text
    End Sub
End Class