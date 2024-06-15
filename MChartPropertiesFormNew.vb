Imports System.IO
Imports tab = DevExpress.XtraTab
Imports cht = DevExpress.XtraCharts
Imports System.Drawing.Text
Imports System.Data
Imports System.ComponentModel
Imports DevExpress.Utils.Extensions

Imports OPC
Imports OPCDA.NET

'Imports Microsoft.Office.Interop.Excel

Public Class MChartPropertiesFormNew

    Private ColDialog As New ColorDialog
    'Friend _ListChart_Series As New List(Of MChartProperties)
    'Friend _Constant_Lines As New BindingList(Of ConstantLineProp)
    ''Friend Tagscls As New List(Of SeriesTags)
    'Friend _Title As String = ""
    'Friend _XaxisTitle As String = ""
    'Friend _YaxisTitle As String = ""

    'Friend _XScaleMin As Integer
    'Friend _XScaleMax As Integer
    'Friend _YScaleMin As Integer
    'Friend _YScaleMax As Integer


    'Private DB_Chnl_Index_Collection() As Integer
    'Private OPC_Chnl_Index_Collection() As Integer
    'Private OPCDA_Chnl_Index_Collection() As Integer

    'Private Slt_idx As Integer
    'Private ChannelText As String

    'Friend Title_Font, XYAxislbl_Font As New Font("Verdana", 8, FontStyle.Regular)
    'Friend Title_Color As Color = System.Drawing.Color.Black
    'Friend XYAxislbl_color As Color = System.Drawing.Color.Black
    'Friend Chart_BGColor As Color = System.Drawing.Color.WhiteSmoke
    'Friend Grid_Color As Color = System.Drawing.Color.Silver
    'Friend Legend_Color As Color = System.Drawing.Color.Blue
    'Friend xyTitle_Color As Color = System.Drawing.Color.Black
    'Friend Series_Color As Color = System.Drawing.Color.Blue
    'Private bln3Dstyle As Boolean
    'Dim DaTbl As DataTable


    Dim blnTesting As Boolean = False
    Dim losChannelTags As New List(Of String)

    'Private 
    Private Sub cboActionChannel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActionChannel.SelectedIndexChanged

        If cboActionChannel.Text <> "" Then
            cboLambda.Items.Clear()
            losChannelTags.Clear()

            Try
                Dim myDataTable As DataTable
                myDataTable = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cboActionChannel.Text))
                Dim intColCount As Integer
                intColCount = myDataTable.Columns.Count - 1
                For I = 0 To intColCount
                    If myDataTable.Columns(I).ColumnName = "Tags/Time" Then
                        Continue For
                    End If
                    cboLambda.Items.Add(myDataTable.Columns(I).ColumnName)

                    losChannelTags.Add(myDataTable.Columns(I).ColumnName)
                Next
            Catch ex As Exception
                MsgBox("SIC1:" & ex.Message)
            End Try
            Dim intUnits As Integer
            intUnits = txtUnits.Text
            For I = 1 To intUnits
                Try
                    Dim myCombo As ComboBox
                    myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForManP" & I), ComboBox)
                    myCombo.Items.Clear()
                    myCombo.Items.AddRange(losChannelTags.ToArray)

                    myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForPLambdaP" & I), ComboBox)
                    myCombo.Items.Clear()
                    myCombo.Items.AddRange(losChannelTags.ToArray)

                    myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForOptP" & I), ComboBox)
                    myCombo.Items.Clear()
                    myCombo.Items.AddRange(losChannelTags.ToArray)

                    myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForMinP" & I), ComboBox)
                    myCombo.Items.Clear()
                    myCombo.Items.AddRange(losChannelTags.ToArray)

                    myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForMaxP" & I), ComboBox)
                    myCombo.Items.Clear()
                    myCombo.Items.AddRange(losChannelTags.ToArray)
                Catch ex As Exception
                    MsgBox("SIC2:" & ex.Message)
                End Try
            Next
        End If

    End Sub

    Private Sub MChartPropertiesFormNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboActionChannel.Items.Clear()
        cboLambda.Items.Clear()

        cboActionChannel.Text = ""
        cboLambda.Text = ""

        txtUnits.Text = 2
        txtSamples.Text = 7
        mySampleDGV.Visible = False

        Try
            If Not blnTesting Then
                If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count > 0 Then
                    For I As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                        cboActionChannel.Items.Add(MainPage.SAMAHistorian_ChannelList.ChannelReportname.Item(I))
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("L1:" & ex.Message)
        End Try
        If Not blnTesting Then

            Try
                'DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Trend")).ToArray
                'OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
                'OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray

                'txtTitleFont.Text = Title_Font.Name & "," & Title_Font.Size & "," & Title_Font.Style.ToString & "," & Title_Color.Name

                'lblLegendColor.BackColor = Legend_Color
                'lblXYTitleColor.BackColor = xyTitle_Color
                'lblChartBackColor.BackColor = Chart_BGColor

                'txtMainTitle.Text = _Title
                'txtXAxisTitle.Text = _XaxisTitle
                'txtYAxisTitle.Text = _YaxisTitle
                Dim objMChartCtrl As MChartControl
                objMChartCtrl = MainPage.MChart_Ctrl

                With objMChartCtrl
                    Try
                        txtMainTitle.Text = .gstrMCTitle
                        txtTitleFont.Text = .gstrMCTitleFont
                        txtXAxisTitle.Text = .gstrMCXAxisTitle
                        txtYAxisTitle.Text = .gstrMCYAxisTitle
                        txtXYTitleColor.BackColor = Color.FromArgb(.gstrMCXYAxisTitleColor)
                        txtChartBackColor.BackColor = Color.FromArgb(.gstrMCChartBackColor)
                        chkLabelEnable.Checked = IIf(.gstrMCLegendEnable = "1", True, False)
                        txtLegendColor.BackColor = Color.FromArgb(.gstrMCLegendColor)
                        chkLegendEnable.Checked = IIf(.gstrMCAxisLabelEnable = "1", True, False)
                        txtAxisLabelColor.BackColor = Color.FromArgb(.gstrMCAxisLabelColor)

                        cboLambda.Text = .gstrMCTagForLambda
                        txtLambdaName.Text = .gstrMCLambdaSeriesName
                        txtLambdaSeriesColor.BackColor = Color.FromArgb(.gstrMCLambdaSeriesColor)
                    Catch ex As Exception
                        MsgBox("L2:" & ex.Message)
                    End Try

                    Dim intUnits As Integer
                    'intUnits = .glosMCTagForMan.Count
                    intUnits = .gintMcUnits

                    txtUnits.Text = intUnits
                    CreateTabs(intUnits)

                    txtTargetPower.Text = .gintMCTargetPower
                    txtPricePerUnit.Text = .gsngPricePerUnit
                    txtSamples.Text = .gintMCSamples

                    cboActionChannel.Text = .gstrMCActionChannel
                    cboWritebackOpcServer.Text = .gstrMCWritebackOpcServer

                    For I = 1 To intUnits
                        Try
                            Dim myCombo As ComboBox
                            myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForManP" & I), ComboBox)
                            myCombo.Items.Clear()
                            myCombo.Items.AddRange(losChannelTags.ToArray)

                            myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForPLambdaP" & I), ComboBox)
                            myCombo.Items.Clear()
                            myCombo.Items.AddRange(losChannelTags.ToArray)

                            myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForOptP" & I), ComboBox)
                            myCombo.Items.Clear()
                            myCombo.Items.AddRange(losChannelTags.ToArray)

                            myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForMinP" & I), ComboBox)
                            myCombo.Items.Clear()
                            myCombo.Items.AddRange(losChannelTags.ToArray)

                            myCombo = DirectCast(tabMChartProp.TabPages(I + 1).Controls("cboTagForMaxP" & I), ComboBox)
                            myCombo.Items.Clear()
                            myCombo.Items.AddRange(losChannelTags.ToArray)
                        Catch ex As Exception
                            MsgBox("L3:" & ex.Message)
                        End Try
                        Try
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "cboTagForManP" & I,
                                          .glosMCTagForMan(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "cboTagForPLambdaP" & I,
                                          .glosMCTagForPLambda(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "cboTagForOptP" & I,
                                          .glosMCTagForOpt(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "cboTagForMinP" & I,
                                          .glosMCTagForMin(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtSeriesMinColorP" & I,
                                          .glosMCMinColor(I - 1),
                                          1)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "cboTagForMaxP" & I,
                                          .glosMCTagForMax(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtSeriesMaxColorP" & I,
                                          .glosMCMaxColor(I - 1),
                                          1)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtSeriesNameP" & I,
                                          .glosMCSeriesName(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtSeriesColorP" & I,
                                          .glosMCSeriesColor(I - 1),
                                          1)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtIntersectNameP" & I,
                                          .glosMCIntersectName(I - 1),
                                          0)
                            SetValueForObject(tabMChartProp.TabPages(I + 1),
                                          "txtIntersectColorP" & I,
                                          .glosMCIntersectColor(I - 1),
                                          1)
                            'SetValueForObject(tabMChartProp.TabPages(I + 1),
                            '              "dgvDataP" & I,
                            '              .glosMCActData(I - 1),
                            '              0)
                        Catch ex As Exception
                            MsgBox("L4:" & ex.Message)
                        End Try
                    Next
                End With
            Catch ex As Exception
                MsgBox("L5:" & ex.Message)
            End Try

        End If
        tabGeneral.BringToFront()
        'cboActionChannel.Text = "MORS"
        'cboLambda.Text = "ULambda#CV_Instant"
        'cboP1.Text = "ActP1#PV_Instant"
        'cboP1Sch.Text = "U1P#CV_Instant"
        'cboP1Opt.Text = "OptP1#CV_Instant"
        'cboP2.Text = "ActP2#PV_Instant"
        'cboP2Sch.Text = "U2P#CV_Instant"
        'cboP2Opt.Text = "OptP2#CV_Instant"
        'cboMin.Text = "P1min#SV_Instant"
        'cboMax.Text = "P1max#SV_Instant"

    End Sub

    Private Sub SetValueForObject(objTabPage As tab.XtraTabPage,
                                  strControlName As String,
                                  strValue As String,
                                  blnBackColor As Boolean)

        Try
            For Each ctrlOne As Control In objTabPage.Controls
                If ctrlOne.Name = strControlName Then
                    Try
                        If strControlName.StartsWith("dgv") Then
                            Dim dgv As DataGridView
                            dgv = DirectCast(ctrlOne, DataGridView)
                            dgv.Rows.Clear()
                            Dim arySplit() As String
                            arySplit = Split(strValue, ",")
                            For Each a In arySplit
                                dgv.Rows.Add({a})
                            Next
                        Else
                            If blnBackColor Then
                                Try
                                    ctrlOne.BackColor = Color.FromArgb(strValue)
                                Catch ex As Exception
                                    MsgBox("SVFO2:" & ex.Message)
                                    ctrlOne.BackColor = Color.Red
                                End Try
                            Else
                                ctrlOne.Text = strValue
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("SVFO1:" & ex.Message)
                    End Try
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("SVFO2:" & ex.Message)
        End Try

    End Sub

    Private Function GetValueFromObject(objTabPage As tab.XtraTabPage,
                                  strControlName As String,
                                  blnBackColor As Boolean) As String

        Dim strValue As String = ""
        For Each ctrlOne As Control In objTabPage.Controls
            If ctrlOne.Name = strControlName Then
                If strControlName.StartsWith("dgv") Then
                    Dim dgvData As DataGridView
                    dgvData = DirectCast(ctrlOne, DataGridView)
                    For Each dgvOneRow As DataGridViewRow In dgvData.Rows
                        strValue = strValue & dgvOneRow.Cells()(0).Value & ","
                    Next
                    If strValue <> "" Then
                        strValue = strValue.Substring(0, Len(strValue) - 1)
                    End If
                Else
                    If blnBackColor Then
                        strValue = ctrlOne.BackColor.ToArgb
                    Else
                        strValue = ctrlOne.Text
                    End If
                End If
                Exit For
            End If
        Next
        Return strValue

    End Function

    Private Function ValidRecords() As Boolean

        ValidRecords = False
        If Not IsNumeric(txtTargetPower.Text) Then
            MsgBox("Invalid Entry!")
            txtTargetPower.Focus()
            Exit Function
        End If
        If Not ValidCombo(cboLambda) Then
            Exit Function
        End If
        Dim intUnits As Integer
        intUnits = txtUnits.Text
        For I = 1 To intUnits
            Dim cboForMan, cboForPLambda, cboForOpt, cboForMin, cboForMax As ComboBox
            cboForMan = DirectCast(tabMChartProp.TabPages(I + 1).Controls(tabMChartProp.TabPages(I + 1).Controls.IndexOfKey("cboTagForManP" & I)), ComboBox)
            cboForPLambda = DirectCast(tabMChartProp.TabPages(I + 1).Controls(tabMChartProp.TabPages(I + 1).Controls.IndexOfKey("cboTagForPLambdaP" & I)), ComboBox)
            cboForOpt = DirectCast(tabMChartProp.TabPages(I + 1).Controls(tabMChartProp.TabPages(I + 1).Controls.IndexOfKey("cboTagForOptP" & I)), ComboBox)
            cboForMin = DirectCast(tabMChartProp.TabPages(I + 1).Controls(tabMChartProp.TabPages(I + 1).Controls.IndexOfKey("cboTagForMinP" & I)), ComboBox)
            cboForMax = DirectCast(tabMChartProp.TabPages(I + 1).Controls(tabMChartProp.TabPages(I + 1).Controls.IndexOfKey("cboTagForMaxP" & I)), ComboBox)
            If ValidCombo(cboForMan) AndAlso
                ValidCombo(cboForPLambda) AndAlso
                ValidCombo(cboForOpt) Then
            Else
                Exit Function
            End If
        Next
        If Not IsNumeric(txtPricePerUnit.Text) Then
            MsgBox("Invalid Price Per Unit!")
            txtPricePerUnit.Focus()
            Exit Function
        End If
        ValidRecords = True

    End Function

    Private Function ValidCombo(ComboBox1 As ComboBox) As Boolean

        If ComboBox1.Text = "" Then
            MsgBox("Invalid " & ComboBox1.Name.Substring(3) & " Selected!")
            ComboBox1.Focus()
            Return False
        End If
        Return True

    End Function



    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Try
            If Not ValidRecords() Then
                Exit Sub
            End If
            Dim objMChartCtrl As MChartControl
            objMChartCtrl = MainPage.MChart_Ctrl
            With objMChartCtrl
                .AccessibleDescription = cboActionChannel.Text
                .gstrMCTitle = txtMainTitle.Text
                .gstrMCTitleFont = txtTitleFont.Text
                .gstrMCXAxisTitle = txtXAxisTitle.Text
                .gstrMCYAxisTitle = txtYAxisTitle.Text
                .gstrMCXYAxisTitleColor = txtXYTitleColor.BackColor.ToArgb
                .gstrMCChartBackColor = txtChartBackColor.BackColor.ToArgb
                .gstrMCLegendEnable = IIf(chkLabelEnable.Checked, 1, 0)
                .gstrMCLegendColor = txtLegendColor.BackColor.ToArgb
                .gstrMCAxisLabelEnable = IIf(chkLegendEnable.Checked, 1, 0)
                .gstrMCAxisLabelColor = txtAxisLabelColor.BackColor.ToArgb

                .gstrMCActionChannel = cboActionChannel.Text
                Dim intUnits As Integer
                intUnits = txtUnits.Text

                .gintMCUnits = intUnits
                .gintMCTargetPower = txtTargetPower.Text
                .gsngPricePerUnit = txtPricePerUnit.Text
                .gintMCSamples = txtSamples.Text
                .gstrMCWritebackOpcServer = cboWritebackOpcServer.Text

                .gstrMCTagForLambda = cboLambda.Text
                .gstrMCLambdaSeriesName = txtLambdaName.Text
                .gstrMCLambdaSeriesColor = txtLambdaSeriesColor.BackColor.ToArgb

                .glosMCTagForMan.Clear()
                .glosMCTagForPLambda.Clear()
                .glosMCTagForOpt.Clear()
                .glosMCTagForMin.Clear()
                .glosMCMinColor.Clear()
                .glosMCTagForMax.Clear()
                .glosMCMaxColor.Clear()
                .glosMCSeriesName.Clear()
                .glosMCSeriesColor.Clear()
                .glosMCIntersectName.Clear()
                .glosMCIntersectColor.Clear()
                '.glosMCActData.Clear() 'Manually Entered Data should not be removed

                .glogMinX1.Clear()
                .glogMinY1.Clear()
                .glogMinX2.Clear()
                .glogMinY2.Clear()

                .glogMinX1.Clear()
                .glogMinY1.Clear()
                .glogMinX2.Clear()
                .glogMinY2.Clear()

                .glogIntersectX1.Clear()
                .glogIntersectY1.Clear()
                .glogIntersectX2.Clear()
                .glogIntersectY2.Clear()

                For I = 1 To intUnits
                    Dim strValue As String
                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "cboTagForManP" & I,
                                         0)
                    .glosMCTagForMan.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "cboTagForPLambdaP" & I,
                                         0)
                    .glosMCTagForPLambda.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "cboTagForOptP" & I,
                                         0)
                    .glosMCTagForOpt.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "cboTagForMinP" & I,
                                         0)
                    .glosMCTagForMin.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtMinColorP" & I,
                                         1)
                    .glosMCMinColor.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "cboTagForMaxP" & I,
                                         0)
                    .glosMCTagForMax.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtMaxColorP" & I,
                                         1)
                    .glosMCMaxColor.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtSeriesNameP" & I,
                                         0)
                    .glosMCSeriesName.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtSeriesColorP" & I,
                                         1)
                    .glosMCSeriesColor.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtIntersectNameP" & I,
                                         0)
                    .glosMCIntersectName.Add(strValue)

                    strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                                         "txtIntersectColorP" & I,
                                         1)
                    .glosMCIntersectColor.Add(strValue)

                    'Dim strExistingData As String, losExistingData As New List(Of String)
                    'strExistingData = .glosMCActData(I - 1)
                    'losExistingData.Clear()
                    'losExistingData.AddRange(Split(strExistingData, ","))
                    'If losExistingData.Count + 1 > .gintMcSamples Then
                    '    For J = losExistingData.Count - 1 To .gintMcSamples Step -1
                    '        losExistingData.RemoveAt(J)
                    '    Next
                    'ElseIf losExistingData.Count < .gintMcSamples Then
                    '    For J = losExistingData.Count + 1 To .gintMcSamples
                    '        losExistingData.Add("100")
                    '    Next
                    'End If
                    'strValue = String.Join(",", losExistingData.ToArray)
                    ''strValue = GetValueFromObject(tabMChartProp.TabPages(I + 1),
                    ''                     "dgvDataP" & I,
                    ''                     0)
                    '.glosMCActData(I - 1) = strValue

                    .glogMinX1.Add(MainPage.X_AXIS_MIN_VALUE)
                    .glogMinY1.Add(MainPage.Y_AXIS_MIN_VALUE)
                    .glogMinX2.Add(MainPage.X_AXIS_MIN_VALUE)
                    .glogMinY2.Add(MainPage.Y_AXIS_MAX_VALUE)

                    .glogMaxX1.Add(MainPage.X_AXIS_MAX_VALUE)
                    .glogMaxY1.Add(MainPage.Y_AXIS_MIN_VALUE)
                    .glogMaxX2.Add(MainPage.X_AXIS_MAX_VALUE)
                    .glogMaxY2.Add(MainPage.Y_AXIS_MAX_VALUE)

                    .glogIntersectX1.Add(MainPage.X_AXIS_MIN_VALUE)
                    .glogIntersectY1.Add(MainPage.Y_AXIS_MIN_VALUE)
                    .glogIntersectX2.Add(MainPage.X_AXIS_MIN_VALUE)
                    .glogIntersectY2.Add(MainPage.Y_AXIS_MAX_VALUE)
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'End If

        Me.Close()

    End Sub

    Private Sub btnMChartPropertiesCancel_Click(sender As Object, e As EventArgs) Handles btnMChartpropertiseCancel.Click
        Me.Close()
    End Sub


#Region "Font & BackColor"

    Private Sub btnTitleFont_Click(sender As Object, e As EventArgs) Handles btnTitleFont.Click
        Dim fntdlg As New FontDialog
        fntdlg.ShowColor = True
        If fntdlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntdlg.Font.Name & "," & fntdlg.Font.Size & "," & fntdlg.Font.Style.ToString() & "," & fntdlg.Color.ToArgb
            Title_Color = fntdlg.Color
            Title_Font = fntdlg.Font
        End If
    End Sub

    Private Sub txtXYTitleColor_Click(sender As Object, e As EventArgs) Handles txtXYTitleColor.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtXYTitleColor.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtChartBackColor_Click(sender As Object, e As EventArgs) Handles txtChartBackColor.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtChartBackColor.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtLegendColor_Click(sender As Object, e As EventArgs) Handles txtLegendColor.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtLegendColor.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtAxisLabelColor_Click(sender As Object, e As EventArgs) Handles txtAxisLabelColor.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtAxisLabelColor.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtMinSeriesColor_Click(sender As Object, e As EventArgs) Handles txtMinColorP1.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtMinColorP1.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtMaxSeriesColor_Click(sender As Object, e As EventArgs) Handles txtMaxColorP1.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtMaxColorP1.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub txtLambdaSeriesColor_Click(sender As Object, e As EventArgs) Handles txtLambdaSeriesColor.Click
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            txtLambdaSeriesColor.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub ControlColorClick(sender As Object, e As EventArgs)
        ColDialog.FullOpen = False
        If ColDialog.ShowDialog() = DialogResult.OK Then
            sender.BackColor = ColDialog.Color
        End If
    End Sub

#End Region

    Private Sub txtUnits_LostFocus(sender As Object, e As EventArgs)

        If Not IsNumeric(txtUnits.Text) Then
            txtUnits.Focus()
            Exit Sub
        End If

        CreateTabs(txtUnits.Text)

    End Sub

    Private Sub txtUnits_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnits.KeyDown
        If e.KeyCode >= Asc(2) And e.KeyCode <= Asc(9) Then
        Else
            MsgBox("Valid Values: 2 to 9")
            txtUnits.Text = 2
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtPricePerUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPricePerUnit.KeyDown
        If (e.KeyCode >= Asc(0) And e.KeyCode <= Asc(9)) Or e.KeyCode = Asc(".") Then
        Else
            MsgBox("Valid Values: Number")
            txtSamples.Text = "1.0"
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtPricePerUnit_LostFocus(sender As Object, e As EventArgs) Handles txtPricePerUnit.LostFocus
        If Not IsNumeric(txtPricePerUnit.Text) Then
            txtPricePerUnit.Text = "1.0"
        End If
    End Sub

    Private Sub txtSamples_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSamples.KeyDown
        If e.KeyCode >= Asc(0) And e.KeyCode <= Asc(9) Then
        Else
            MsgBox("Valid Values: 2 to 10")
            txtSamples.Text = 7
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtSamples_LostFocus(sender As Object, e As EventArgs) Handles txtSamples.LostFocus
        If txtSamples.Text < 2 Then
            txtSamples.Text = 2
        End If
    End Sub

    Private Sub CreateTabs(intUnits As Integer)

        Dim DEFAULT_TAB_PAGES = 2
        Try
            For I = 1 To intUnits
                If I + DEFAULT_TAB_PAGES > tabMChartProp.TabPages.Count Then
                    tabMChartProp.TabPages.Add("P" & I)
                End If
            Next
            For I = tabMChartProp.TabPages.Count To _
                            intUnits + DEFAULT_TAB_PAGES + 1 Step -1
                tabMChartProp.TabPages.RemoveAt(I - 1)
            Next
            For I = 1 To intUnits
                tabMChartProp.TabPages(I + 1).Name = "P" & I
                CreateControls(tabMChartProp.TabPages(I + 1))
            Next
        Catch ex As Exception
            MsgBox("CT:" & ex.Message)
        End Try

    End Sub

    Private Sub CreateControls(objTabPage As tab.XtraTabPage)

        'Dim aryPColors() As String = {"Red", "Blue", "Green", "Brown", "Gray",
        '                                "DarkBlue", "IndianRed", "Magenta", "Orange"}
        Dim aryPColors() As String =
            {Color.Red.ToArgb,
            Color.Blue.ToArgb,
            Color.Green.ToArgb,
            Color.Brown.ToArgb,
            Color.Gray.ToArgb,
            Color.DarkBlue.ToArgb,
            Color.IndianRed.ToArgb,
            Color.Magenta.ToArgb,
            Color.Orange.ToArgb}

        Dim intUnit, intColorPos As Integer
        Try
            Dim strName As String = objTabPage.Name     'P1, P2, P3, etc.
            intUnit = strName.Substring(1)  ' Ignore P
            intColorPos = intUnit Mod 10 - 1

            Dim losControls As New List(Of String)

            'ControlName~Text~Top~Left~Width~BackColor
            losControls.Add("lblTagFor" & strName & "~" & "Tag for " & strName & "~13~45~0~")
            losControls.Add("lblTagForPLambda" & strName & "~" & "Tag for PLambda" & strName & "~13~81~0~")
            losControls.Add("lblTagForOpt" & strName & "~" & "Tag for Opt" & strName & "~13~117~0~")
            losControls.Add("lblTagForMin" & strName & "~" & "Tag for Min" & strName & "~13~153~0~")
            losControls.Add("lblMinColor" & strName & "~" & "Min Series Color" & strName & "~317~153~0~")
            losControls.Add("lblTagForMax" & strName & "~" & "Tag for Max" & strName & "~13~189~0~")
            losControls.Add("lblMaxColor" & strName & "~" & "Max Series Color" & strName & "~317~189~0~")
            losControls.Add("lblSeriesName" & strName & "~" & "Series Name" & strName & "~13~224~0~")
            losControls.Add("lblSeriesColor" & strName & "~" & "Series Color" & strName & "~317~224~0~")
            losControls.Add("lblIntersectName" & strName & "~" & "Intersection Name" & strName & "~13~260~0~")
            losControls.Add("lblIntersectColor" & strName & "~" & "Intersection Color" & strName & "~317~260~0~")

            losControls.Add("cboTagForMan" & strName & "~M~124~42~181~")
            losControls.Add("cboTagForPLambda" & strName & "~S~124~78~181~")
            losControls.Add("cboTagForOpt" & strName & "~O~124~114~181~")
            losControls.Add("cboTagForMin" & strName & "~N~124~150~181~")
            losControls.Add("cboTagForMax" & strName & "~X~124~186~181~")

            losControls.Add("txtSeriesName" & strName & "~" & strName & "~124~222~144~")
            losControls.Add("txtIntersectName" & strName & "~Intersect" & strName & "~124~258~144~")

            losControls.Add("txtMinColor" & strName & "~~436~151~63~" & aryPColors(intColorPos))
            losControls.Add("txtMaxColor" & strName & "~~436~187~63~" & aryPColors(intColorPos))
            losControls.Add("txtSeriesColor" & strName & "~~436~222~63~" & aryPColors(intColorPos))
            losControls.Add("txtIntersectColor" & strName & "~~436~258~63~" & Color.GreenYellow.ToArgb)

            'losControls.Add("dgvData" & strName)
            'losControls.Add("btnAdd" & strName)
            'losControls.Add("btnRemove" & strName)

            For Each strOneControl In losControls
                If strOneControl.StartsWith("lbl") Then
                    Dim lblNew As New Label
                    lblNew.Name = strOneControl.Split("~")(0)
                    lblNew.Text = strOneControl.Split("~")(1)
                    lblNew.Left = strOneControl.Split("~")(2)
                    lblNew.Top = strOneControl.Split("~")(3)
                    lblNew.AutoSize = True
                    If Not IsNothing(FindIfControlExists(objTabPage, lblNew.Name)) Then 'objTabPage.Controls.Contains(lblNew) Then
                        'Skip
                    Else
                        objTabPage.Controls.Add(lblNew)
                    End If
                ElseIf strOneControl.StartsWith("cbo") Then
                    Dim cboNew As New ComboBox
                    cboNew.Name = strOneControl.Split("~")(0)
                    cboNew.Text = strOneControl.Split("~")(1)
                    cboNew.Left = strOneControl.Split("~")(2)
                    cboNew.Top = strOneControl.Split("~")(3)
                    cboNew.Width = strOneControl.Split("~")(4)
                    If Not IsNothing(FindIfControlExists(objTabPage, cboNew.Name)) Then
                        'Skip
                    Else
                        objTabPage.Controls.Add(cboNew)
                    End If
                    cboNew.Items.Clear()
                    cboNew.Items.AddRange(losChannelTags.ToArray)
                ElseIf strOneControl.StartsWith("txt") Then
                    Dim txtNew As New TextBox
                    txtNew.Name = strOneControl.Split("~")(0)
                    txtNew.Text = strOneControl.Split("~")(1)
                    txtNew.Left = strOneControl.Split("~")(2)
                    txtNew.Top = strOneControl.Split("~")(3)
                    txtNew.Width = strOneControl.Split("~")(4)
                    If strOneControl.Split("~")(5) <> "" Then
                        txtNew.BackColor = Color.FromArgb(strOneControl.Split("~")(5))
                        txtNew.ReadOnly = True
                        txtNew.Text = ""
                        AddHandler txtNew.Click, AddressOf ControlColorClick
                    End If
                    Dim ctrl As Control
                    ctrl = FindIfControlExists(objTabPage, txtNew.Name)
                    If Not IsNothing(ctrl) Then
                        'Skip
                        If strOneControl.Split("~")(5) <> "" Then
                            objTabPage.Controls.RemoveByKey(txtNew.Name)
                            objTabPage.Controls.Add(txtNew)
                        End If
                    Else
                        objTabPage.Controls.Add(txtNew)
                    End If
                ElseIf strOneControl.StartsWith("dgv") Then
                    Dim dgvData As New DataGridView
                    dgvData.Name = strOneControl.Split("~")(0)
                    dgvData.Left = mySampleDGV.Left
                    dgvData.Top = mySampleDGV.Top
                    dgvData.Width = mySampleDGV.Width
                    dgvData.Height = mySampleDGV.Height

                    With dgvData
                        .Visible = True

                        .RowsDefaultCellStyle.BackColor = Color.Bisque
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
                        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        .AllowUserToAddRows = False
                        '.EditMode = DataGridViewEditMode.EditProgrammatically

                        .RowHeadersVisible = False
                        .Columns.Clear()
                        .Columns.Add("Alt", "Alt")
                        .Columns(0).Width = 70

                        .Rows.Add({100})
                        .Rows.Add({200})
                        .Rows.Add({300})
                        .Rows.Add({400})
                        .Rows.Add({500})
                        .Rows.Add({600})
                        .Rows.Add({700})
                        AddHandler .CellEndEdit, AddressOf mySampleDGV_CellEndEdit
                    End With
                    If Not IsNothing(FindIfControlExists(objTabPage, dgvData.Name)) Then
                        'Skip
                    Else
                        objTabPage.Controls.Add(dgvData)
                    End If
                ElseIf strOneControl.StartsWith("btn") Then
                    Dim btnNew As New Button
                    btnNew.Name = strOneControl
                    If strOneControl.Contains("Add") Then
                        btnNew.Text = "+"
                        btnNew.Top = mySampleAdd.Top
                        btnNew.Left = mySampleAdd.Left
                        btnNew.Width = mySampleAdd.Width
                        btnNew.Height = mySampleAdd.Height
                        AddHandler btnNew.Click, AddressOf mySampleAdd_Click
                    Else
                        btnNew.Text = "-"
                        btnNew.Top = mySampleRemove.Top
                        btnNew.Left = mySampleRemove.Left
                        btnNew.Width = mySampleRemove.Width
                        btnNew.Height = mySampleRemove.Height
                        AddHandler btnNew.Click, AddressOf mySampleRemove_Click
                    End If
                    If Not IsNothing(FindIfControlExists(objTabPage, btnNew.Name)) Then
                        'Skip
                    Else
                        objTabPage.Controls.Add(btnNew)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("CC:" & ex.Message)
        End Try

    End Sub

    Private Function FindIfControlExists(objTabPage As tab.XtraTabPage, strControlName As String) As Control

        Dim ctrl As Control = Nothing

        For Each ctrlOne As Control In objTabPage.Controls
            If ctrlOne.Name = strControlName Then
                ctrl = ctrlOne
                Exit For
            End If
        Next

        Return ctrl

    End Function

    Private Sub mySampleAdd_Click(sender As Object, e As EventArgs) Handles mySampleAdd.Click
        Try

            Dim btnAdd As Button
            btnAdd = DirectCast(sender, Button)

            Dim objTabPage As tab.XtraTabPage
            objTabPage = DirectCast(btnAdd.Parent, tab.XtraTabPage)

            Dim strDgvName As String
            strDgvName = "dgvData" & btnAdd.Name.Replace("btnAdd", "")

            Dim dgvData As DataGridView
            'Add in all TabPages
            For Each objOneTabPage As tab.XtraTabPage In tabMChartProp.TabPages
                If objOneTabPage.Name.StartsWith("P") Then
                    strDgvName = "dgvData" & objOneTabPage.Name
                    dgvData = DirectCast(FindIfControlExists(objOneTabPage, strDgvName), DataGridView)
                    dgvData.Rows.Add({105})
                End If
            Next
            'dgvData = DirectCast(FindIfControlExists(objTabPage, strDgvName), DataGridView)
            'dgvData.Rows.Add({100})
        Catch ex As Exception
            MsgBox("MSA_C:" & ex.Message)
        End Try

    End Sub

    Private Sub mySampleRemove_Click(sender As Object, e As EventArgs) Handles mySampleRemove.Click
        Dim btnRemove As Button
        btnRemove = DirectCast(sender, Button)

        Dim objTabPage As tab.XtraTabPage
        objTabPage = DirectCast(btnRemove.Parent, tab.XtraTabPage)

        Dim strDgvName As String
        strDgvName = "dgvData" & btnRemove.Name.Replace("btnRemove", "")

        Dim dgvData As DataGridView
        dgvData = DirectCast(FindIfControlExists(objTabPage, strDgvName), DataGridView)
        Dim intRow As Integer
        If dgvData.CurrentCell Is Nothing Then
            Exit Sub
        End If
        intRow = dgvData.CurrentCell.RowIndex
        If intRow <> -1 Then
            'intCol = dgvData.CurrentCell.ColumnIndex
            dgvData.Rows.RemoveAt(intRow)
        End If
    End Sub

    Private Sub mySampleDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles mySampleDGV.CellEndEdit
        Dim dgvData As DataGridView
        dgvData = DirectCast(sender, DataGridView)
        If dgvData.CurrentRow Is Nothing Then
            Exit Sub
        End If
        Dim strValue As String
        strValue = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If Not IsNumeric(strValue) Then
            MsgBox("Invalid Value!")
            dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 100
        End If
    End Sub


    Private Sub cboWritebackOpcServer_DropDown(sender As Object, e As EventArgs) Handles cboWritebackOpcServer.DropDown

        Dim aryOpcServers() As String
        Dim opcServerList As New OPC.OpcServerBrowser
        opcServerList.GetServerList(aryOpcServers)
        cboWritebackOpcServer.Items.AddRange(aryOpcServers)

    End Sub

    Private Sub tabLambdaMinMax_Paint(sender As Object, e As PaintEventArgs) Handles tabLambdaMinMax.Paint

    End Sub

    Private Sub MChartPropertiesFormNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.F5 Then

        End If
    End Sub

    Private Sub MChartPropertiesFormNew_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        Dim aryLines(), strTagsLocationPath As String

        Try
            aryLines = File.ReadAllLines(Environment.CurrentDirectory & "\ReportLocation.txt")
            strTagsLocationPath = aryLines(0)

            aryLines = File.ReadAllLines(strTagsLocationPath & "\Tags.csv")
            cboLambda.Items.Clear()

            Dim intUnits As Integer
            intUnits = txtUnits.Text
            For I = 1 To intUnits
                For Each objOneTabPage As tab.XtraTabPage In tabMChartProp.TabPages
                    If objOneTabPage.Name.StartsWith("P" & I) Then
                        Dim cboTemp As ComboBox
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForManP" & I), ComboBox)
                        cboTemp.Items.Clear()
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForPLambdaP" & I), ComboBox)
                        cboTemp.Items.Clear()
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForOptP" & I), ComboBox)
                        cboTemp.Items.Clear()
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForMinP" & I), ComboBox)
                        cboTemp.Items.Clear()
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForMaxP" & I), ComboBox)
                        cboTemp.Items.Clear()
                    End If
                Next

            Next

            Dim losTags As New List(Of String)
            For Each a In aryLines
                Dim strTagNameWithChannel, strTagName As String
                strTagNameWithChannel = Split(a, "~")(0)
                strTagName = strTagNameWithChannel.Substring(strTagNameWithChannel.IndexOf(".") + 1)
                losTags.Add(strTagName)
            Next
            cboLambda.Items.AddRange(losTags.ToArray)
            For I = 1 To intUnits
                For Each objOneTabPage As tab.XtraTabPage In tabMChartProp.TabPages
                    If objOneTabPage.Name.StartsWith("P" & I) Then
                        Dim cboTemp As ComboBox
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForManP" & I), ComboBox)
                        cboTemp.Items.AddRange(losTags.ToArray)
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForPLambdaP" & I), ComboBox)
                        cboTemp.Items.AddRange(losTags.ToArray)
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForOptP" & I), ComboBox)
                        cboTemp.Items.AddRange(losTags.ToArray)
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForMinP" & I), ComboBox)
                        cboTemp.Items.AddRange(losTags.ToArray)
                        cboTemp = DirectCast(objOneTabPage.Controls("cboTagForMaxP" & I), ComboBox)
                        cboTemp.Items.AddRange(losTags.ToArray)
                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox("MCPFN_MDC:" & ex.Message)
        End Try
    End Sub

    Private Sub txtPricePerUnit_TextChanged(sender As Object, e As EventArgs) Handles txtPricePerUnit.TextChanged

    End Sub


End Class
