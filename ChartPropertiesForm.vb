' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-16-2014
' ***********************************************************************
' <copyright file="ChartPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************

Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Text

Public Class ChartPropertiesForm
    Private ColDialog As New ColorDialog
    Friend _ListChart_Series As New List(Of ChartProperties)
    Friend _Title As String = ""
    Friend blnLegend As Boolean
    Friend _XScaleMin As Integer
    Friend _XScaleMax As Integer
    Friend _YScaleMin As Integer
    Friend _YScaleMax As Integer

    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer

    Private slt_Idx As Integer ' = 0
    Friend Channel_Text As String = ""

    Friend Title_Font, XYAxislbl_Font As New Font("Verdana", 8, FontStyle.Regular)
    Friend Title_Color As Color = Color.Black
    Friend XYAxislbl_color As Color = Color.Black
    Friend Chart_BGColor As Color = Color.WhiteSmoke
    Friend Grid_Color As Color = Color.Silver
    Friend Legend_Color As Color = Color.Black
    Friend xyTitle_Color As Color = Color.Black
    Private bln3Dstyle As Boolean
    Private Sub Properties(ByVal chrartCtl As ChartControl)
        Try
            _Title = TxtTitle.Text

            If CkboxLegend.Checked Then
                blnLegend = True
            Else
                blnLegend = False
            End If
            If chrartCtl.ChartAreas(0).Area3DStyle.Enable3D = True Then
                bln3Dstyle = True
            End If
            If Not (Not txtYFrom.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYFrom.Text)) And Not (Not txtYFrom.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYFrom.Text)) Then
                _YScaleMax = txtYTo.Text
                _YScaleMin = txtYFrom.Text
            Else
                MsgBox("Scalling could not be empty !!!")
                Exit Sub
            End If

            If chrartCtl.Series.Count > 0 Then
                chrartCtl.ResetAutoValues()
                chrartCtl.ChartAreas.Clear()
                chrartCtl.Series.Clear()
                chrartCtl.Legends.Clear()
                chrartCtl.ChartAreas.Add("ChartArea1")
            End If

            chrartCtl.Series_TH_Data.Clear() 'Clear the Series_TH_Data Value

            'chrartCtl.Series.Add(txtSeriesName.Text)
            Dim chnindx As Integer = -1
            If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(cBoxChannelYValue.SelectedItem) Then
                chnindx = MainPage.OPCDAChannelsList.OPC_Channel_Name.IndexOf(cBoxChannelYValue.SelectedItem)
                Dim tags() As String = MainPage.OPCDAChannelsList.OPC_OPCItems(chnindx).Split(",")
                For i As Integer = 0 To tags.Length - 1
                    chrartCtl.Series.Add(tags(i))

                    chrartCtl.Legends.Add(tags(i))

                Next

            End If

            CboxChartType.SelectedIndex = CboxChartType.Items.IndexOf(_ListChart_Series.Item(0)._chartType)
            CboxMarkerStyle.SelectedIndex = CboxMarkerStyle.Items.IndexOf(_ListChart_Series.Item(0)._markerStyle)

            If chnindx <> -1 Then
                Dim tags() As String = MainPage.OPCDAChannelsList.OPC_OPCItems(chnindx).Split(",")
                For i As Integer = 0 To tags.Length - 1
                    'Dim chartpropindx As Integer = _ListChart_Series.Item(0).Chart_Series_Properties(i).TagName.IndexOf(tags(i))

                    chrartCtl.Series(i).Color = Color.FromArgb(_ListChart_Series.Item(0).Chart_Series_Properties(i)._seriesColor)
                    chrartCtl.Series(i).MarkerColor = Color.FromArgb(_ListChart_Series.Item(0)._markercolor)
                    chrartCtl.Series(i).MarkerSize = _ListChart_Series.Item(0)._markerSize

                    Select Case CboxChartType.Text
                        Case "Line"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Line
                        Case "Spline"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Spline
                        Case "Area"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Area
                        Case "SplineArea"
                            chrartCtl.Series(i).ChartType = SeriesChartType.SplineArea
                        Case "StackedArea"
                            chrartCtl.Series(i).ChartType = SeriesChartType.StackedArea
                        Case "Bar"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Bar
                        Case "StackedBar"
                            chrartCtl.Series(i).ChartType = SeriesChartType.StackedBar
                        Case "Column"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Column
                        Case "StackedColumn"
                            chrartCtl.Series(i).ChartType = SeriesChartType.StackedColumn
                        Case "Pie"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Pie
                        Case "Doughnut"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Doughnut
                        Case "Pyramid"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Pyramid
                        Case "Funnel"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Funnel
                        Case "Radar"
                            chrartCtl.Series(i).ChartType = SeriesChartType.Radar
                    End Select
                    'chrartCtl.Series(0).ChartType = (CboxChartType.SelectedIndex)

                    If CboxMarkerStyle.SelectedIndex <> 0 Then
                        chrartCtl.Series(i).MarkerStyle = CboxMarkerStyle.SelectedIndex
                    Else
                        chrartCtl.Series(i).MarkerStyle = MarkerStyle.None
                    End If
                    If _ListChart_Series.Item(0).AxixLabelEnabled Then
                        chrartCtl.Series(i).IsValueShownAsLabel = True
                    Else
                        chrartCtl.Series(i).IsValueShownAsLabel = False
                    End If
                    chrartCtl.Series(i).LabelForeColor = Color.FromArgb(_ListChart_Series.Item(0)._axisLabelColor)

                    chrartCtl.Series(i).ToolTip = txtYAxisTitle.Text & ": #VALY," & txtXAxisTitle.Text & ": #VALX"
                    chrartCtl.Series(i).XValueType = ChartValueType.String 'X value type

                    chrartCtl.Series(i).BorderWidth = 2

                    chrartCtl.Series(i).YValueMembers = _ListChart_Series.Item(0)._yExpression
                    chrartCtl.Series(i).XValueMember = _ListChart_Series.Item(0)._xExpression

                    chrartCtl.Series(i).Font = New Font("Verdana", 8, FontStyle.Regular)

                    chrartCtl.Legends(i).ForeColor = Legend_Color
                    chrartCtl.Legends(i).BackColor = Color.Transparent

                    If Not blnLegend Then 'Check Legent True/False
                        chrartCtl.Legends(i).Position.Width = 0
                        chrartCtl.Legends(i).Position.Height = 0
                    Else
                        chrartCtl.Legends(i).Enabled = True
                        chrartCtl.Legends(i).Alignment = StringAlignment.Far
                        chrartCtl.Legends(i).Position.Width = 100
                        chrartCtl.Legends(i).Position.Height = 10
                        chrartCtl.Legends(i).Position.X = 70
                        chrartCtl.Legends(i).Position.Y = 0
                    End If
                Next
            End If


            If _ListChart_Series.Item(0).Chart_Series_Properties.Count > 0 Then 'Check  _ListChart_Series.Item(0)._ThresholdValue Count
                For i As Integer = 0 To _ListChart_Series.Item(0).Chart_Series_Properties.Count - 1
                    Dim Se_THClass As New ChartSeriesTHValue 'ChartSeriesTHValue Class 
                    Se_THClass.TagName = _ListChart_Series.Item(0).Chart_Series_Properties(i)._TagName
                    Se_THClass.ThresholdValue.AddRange(_ListChart_Series.Item(0).Chart_Series_Properties(i)._ThresholdValue.ToArray)
                    Se_THClass.THPointsColor.AddRange(_ListChart_Series.Item(0).Chart_Series_Properties(i)._THPointsColor.ToArray)
                    chrartCtl.Series_TH_Data.Add(Se_THClass)
                Next
            Else
                Dim Se_THClass As New ChartSeriesTHValue
                chrartCtl.Series_TH_Data.Add(Se_THClass)
            End If

            'If _ListChart_Series.Item(0)._ThresholdValue.Count > 0 Then 'Check  _ListChart_Series.Item(0)._ThresholdValue Count
            '    Dim Se_THClass As New ChartSeriesTHValue 'ChartSeriesTHValue Class 
            '    Se_THClass.ThresholdValue.AddRange(_ListChart_Series.Item(0)._ThresholdValue.ToArray)
            '    Se_THClass.THPointsColor.AddRange(_ListChart_Series.Item(0)._THPointsColor.ToArray)
            '    chrartCtl.Series_TH_Data.Add(Se_THClass)
            'Else
            '    Dim Se_THClass As New ChartSeriesTHValue
            '    chrartCtl.Series_TH_Data.Add(Se_THClass)
            'End If




            If ckYAutoScale.Checked Then
                chrartCtl.ChartAreas(0).AxisY.Tag = "True"
                chrartCtl.ResetAutoValues()
                chrartCtl.ChartAreas(0).AxisY.Maximum = Double.NaN
                chrartCtl.ChartAreas(0).AxisY.Minimum = Double.NaN
                chrartCtl.ResetAutoValues()

            Else
                chrartCtl.ChartAreas(0).AxisY.Tag = "False"
                chrartCtl.ChartAreas(0).AxisY.Maximum = _YScaleMax
                chrartCtl.ChartAreas(0).AxisY.Minimum = _YScaleMin
            End If



            chrartCtl.ChartAreas(0).AxisX.LabelStyle.Font = XYAxislbl_Font
            chrartCtl.ChartAreas(0).AxisY.LabelStyle.Font = XYAxislbl_Font
            chrartCtl.ChartAreas(0).AxisX.LabelStyle.ForeColor = XYAxislbl_color
            chrartCtl.ChartAreas(0).AxisY.LabelStyle.ForeColor = XYAxislbl_color

            chrartCtl.ChartAreas(0).AxisY.Title = txtYAxisTitle.Text
            chrartCtl.ChartAreas(0).AxisX.Title = txtXAxisTitle.Text
            chrartCtl.ChartAreas(0).AxisY.TitleForeColor = xyTitle_Color
            chrartCtl.ChartAreas(0).AxisX.TitleForeColor = xyTitle_Color


            If bln3Dstyle Then
                chrartCtl.ChartAreas(0).Area3DStyle.Enable3D = True
            Else
                chrartCtl.ChartAreas(0).Area3DStyle.Enable3D = False
            End If
            'chrartCtl.ChartAreas(0).AxisX.IsLabelAutoFit=False
            'chrartCtl.ChartAreas(0).AxisX.Interval = 2
            'chrartCtl.ChartAreas(0).AxisX.LabelStyle.IsStaggered=True
            'chrartCtl.ChartAreas(0).AxisX.LabelStyle.Angle=-45

            Chart_BGColor = lbl_ChartBackColor.BackColor
            Grid_Color = lbl_GridColor.BackColor

            chrartCtl.ChartAreas(0).BackColor = Chart_BGColor
            chrartCtl.BackColor = Chart_BGColor
            chrartCtl.ChartAreas(0).AxisX.MajorGrid.LineColor = Grid_Color
            chrartCtl.ChartAreas(0).AxisY.MajorGrid.LineColor = Grid_Color
            chrartCtl.ChartAreas(0).AxisX.MajorTickMark.LineColor = XYAxislbl_color
            chrartCtl.ChartAreas(0).AxisY.MajorTickMark.LineColor = XYAxislbl_color

            chrartCtl.ChartAreas(0).Axes(0).LineColor = XYAxislbl_color
            chrartCtl.ChartAreas(0).Axes(1).LineColor = XYAxislbl_color

            If chrartCtl.Titles.Count > 0 Then
                chrartCtl.Titles.Clear()
            End If


            chrartCtl.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            chrartCtl.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            chrartCtl.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            chrartCtl.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            chrartCtl.ChartAreas(0).CursorX.AutoScroll = True
            chrartCtl.ChartAreas(0).CursorY.AutoScroll = True


            chrartCtl.Titles.Add("")
            chrartCtl.Titles(0).Text = _Title
            chrartCtl.Titles(0).Alignment = ContentAlignment.MiddleCenter
            chrartCtl.Titles(0).ForeColor = Title_Color
            chrartCtl.Titles(0).Font = Title_Font
            If Not cBoxChartBorder.Text = "None" Then
                chrartCtl.BorderSkin.PageColor = Color.Transparent
            End If
            Select Case cBoxChartBorder.Text
                Case "None"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.None

                Case "FrameThin1"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1
                Case "FrameThin2"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2
                Case "FrameThin3"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3
                Case "FrameThin4"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin4
                Case "FrameThin5"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin5
                Case "FrameThin6"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin6
                Case "FrameTitle1"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1
                Case "FrameTitle2"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle2
                Case "FrameTitle3"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle3
                Case "FrameTitle4"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle4
                Case "FrameTitle5"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle5
                Case "FrameTitle6"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle6
                Case "FrameTitle7"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle7
                Case "FrameTitle8"
                    chrartCtl.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle8


                Case Else
                    ' do the defalut action
            End Select


        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Chart-Properties()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub



    Private Sub ChartPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabcontrolSeries.TabPages.Remove(TabPage1)
        TabcontrolSeries.TabPages.Remove(TabPage2)
        TabcontrolSeries.TabPages.Remove(TabPage3)
        TabcontrolSeries.TabPages.Remove(TabPage4)
        TabcontrolSeries.TabPages.Remove(TabPage5)
        TabcontrolSeries.TabPages.Remove(TabPage6)
        TabcontrolSeries.TabPages.Remove(TabPage7)
        TabcontrolSeries.TabPages.Remove(TabPage8)

        'Dim installed_fonts As New InstalledFontCollection
        ' Get an array of the system's font familiies.
        '        Dim font_families() As FontFamily = installed_fonts.Families() ' COMMENTED BY CODEIT.RIGHT
        'CboxChartType.Items.Clear()
        'CboxChartType.Items.AddRange([Enum].GetNames(GetType(SeriesChartType)))
        Try
            DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Trend")).ToArray
            OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
            ' OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray
            cBoxChannelYValue.Items.Clear()
            For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
                cBoxChannelYValue.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
            Next
            For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
                cBoxChannelYValue.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
            Next
            For i As Integer = 0 To MainPage.OPCDAChannelsList.OPC_Channel_Name.Count - 1
                cBoxChannelYValue.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(i))
            Next
            'For i As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
            '    cBoxChannelYValue.Items.Add(MainPage.SAMAHistorian_ChannelList.ChannelReportname.Item(i))
            'Next
            cBoxChannelYValue.Text = _ListChart_Series(0).YExpression

            txtTitleFont.Text = Title_Font.Name & "," & Title_Font.Size & "," & Title_Font.Style.ToString & "," & Title_Color.Name
            txtxyAxislblFont.Text = XYAxislbl_Font.Name & "," & XYAxislbl_Font.Size & "," & XYAxislbl_Font.Style.ToString & "," & XYAxislbl_color.Name

            lbl_LegentColor.BackColor = Legend_Color
            lbl_xytitleColor.BackColor = xyTitle_Color
            lbl_ChartBackColor.BackColor = Chart_BGColor
            lbl_GridColor.BackColor = Grid_Color
            TxtTitle.Text = _Title

            txtYFrom.Text = _YScaleMin
            txtYTo.Text = _YScaleMax

            Call LoadChartProperies()

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ChartPropertiesForm_Load()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


    End Sub

    Private Sub lblColorMarker_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblColorMarker.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblColorMarker.BackColor = ColDialog.Color
    End Sub

    Private Sub lblColorTrace_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab1_lblColorTrace.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab1_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub lblTextFColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        'lblTextFColor.BackColor = ColDialog.Color
    End Sub
    Private Sub lblAxisLabelColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAxisLabelColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblAxisLabelColor.BackColor = ColDialog.Color
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Add_Properties()
        If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Contains(cBoxChannelYValue.Text) Then
            ' Call Multiple_Properties(MainPage.Chart_Ctrl)
        Else
            Call Properties(MainPage.Chart_Ctrl)
        End If
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Add_Properties()
        Try
            Dim idx As Integer = 0
            'If Not (txtSeriesName.Text = "") Then
            Dim lblAxixlabel As Boolean
            If CKBoxAxixlabel.Checked Then
                lblAxixlabel = True
            Else
                lblAxixlabel = False
            End If
            Dim prop As New ChartProperties
            prop = ProcAddProperties(txtSeriesName.Text, cBoxChannelYValue.Text _
    , CboxChartType.Text, CboxMarkerStyle.Text, cboxMarkerValue.Text _
    , lblColorMarker.BackColor.ToArgb, lblAxisLabelColor.BackColor.ToArgb, lblAxixlabel)
            _ListChart_Series.RemoveAt(idx)

            For Each tabpa As TabPage In TabcontrolSeries.TabPages
                Dim chartseriesprop As New ChartSeriesProperties
                chartseriesprop.TagName = tabpa.Text
                chartseriesprop._ThresholdValue.Clear()
                chartseriesprop._THPointsColor.Clear()

                Select Case tabpa.Name
                    Case "TabPage1"
                        chartseriesprop.SeriesColor = tab1_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab1_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab1_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab1_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab1_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage2"
                        chartseriesprop.SeriesColor = tab2_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab2_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab2_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab2_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab2_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage3"
                        chartseriesprop.SeriesColor = tab3_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab3_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab3_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab3_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab3_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage4"
                        chartseriesprop.SeriesColor = tab4_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab4_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab4_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab4_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab4_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage5"
                        chartseriesprop.SeriesColor = tab5_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab5_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab5_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab5_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab5_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage6"
                        chartseriesprop.SeriesColor = tab6_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab6_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab6_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab6_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab6_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage7"
                        chartseriesprop.SeriesColor = tab7_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab7_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab7_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab7_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab7_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next
                    Case "TabPage8"
                        chartseriesprop.SeriesColor = tab8_lblColorTrace.BackColor.ToArgb
                        For i As Integer = 0 To tab8_GVTHValue.Rows.Count - 1
                            If Not String.IsNullOrEmpty(tab8_GVTHValue.Rows(i).Cells(0).Value) Then
                                chartseriesprop._ThresholdValue.Add(tab8_GVTHValue.Rows(i).Cells(0).Value)
                                chartseriesprop._THPointsColor.Add(tab8_GVTHValue.Rows(i).Cells(1).Style.BackColor.ToArgb)
                            End If
                        Next

                End Select

                prop.Chart_Series_Properties.Add(chartseriesprop)
            Next

            _ListChart_Series.Insert(idx, prop)
            ' End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@btnUpdate_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub


    Public Function ProcAddProperties(ByVal seriesName As String, ByVal yExpression As String,
                                         ByVal chartType As String, ByVal markerStyle As String, ByVal markerSize As Integer,
                                         ByVal markercolor As Integer, ByVal axisLabelColor As Integer, ByVal axixLabelEnabled As Boolean) As ChartProperties

        Dim chartProp As New ChartProperties

        chartProp.SeriesName = seriesName
        chartProp.YExpression = yExpression
        chartProp.ChartType = chartType
        chartProp.MarkerStyle = markerStyle
        chartProp.MarkerSize = markerSize
        chartProp.Markercolor = markercolor
        chartProp.AxisLabelColor = axisLabelColor
        chartProp.AxixLabelEnabled = axixLabelEnabled

        Return chartProp
    End Function


    Private Sub LoadChartProperies()
        Try
            Dim idx As Integer = 0

            txtSeriesName.Text = _ListChart_Series.Item(idx)._seriesName
            cBoxChannelYValue.Text = _ListChart_Series.Item(idx)._yExpression
            ' tab1_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx)._seriesColor)
            CboxChartType.Text = _ListChart_Series.Item(idx)._chartType
            CboxMarkerStyle.Text = _ListChart_Series.Item(idx)._markerStyle
            cboxMarkerValue.Text = _ListChart_Series.Item(idx)._markerSize
            lblColorMarker.BackColor = Color.FromArgb(_ListChart_Series.Item(idx)._markercolor)

            lblAxisLabelColor.BackColor = Color.FromArgb(_ListChart_Series.Item(idx)._axisLabelColor)
            If _ListChart_Series.Item(idx).AxixLabelEnabled Then
                CKBoxAxixlabel.Checked = True
            Else
                CKBoxAxixlabel.Checked = False
            End If

            'tab1_GVTHValue.Rows.Clear()
            'tab2_GVTHValue.Rows.Clear()
            'tab3_GVTHValue.Rows.Clear()
            'tab4_GVTHValue.Rows.Clear()
            'tab5_GVTHValue.Rows.Clear()
            'tab6_GVTHValue.Rows.Clear()
            'tab7_GVTHValue.Rows.Clear()
            'tab8_GVTHValue.Rows.Clear()

            For n As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties.Count - 1
                Select Case n
                    Case 0
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab1_GVTHValue.Rows.Add
                            tab1_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab1_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab1_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 1
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab2_GVTHValue.Rows.Add
                            tab2_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab2_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab2_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 2
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab3_GVTHValue.Rows.Add
                            tab3_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab3_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab3_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 3
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab4_GVTHValue.Rows.Add
                            tab4_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab4_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab4_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 4
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab5_GVTHValue.Rows.Add
                            tab5_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab5_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab5_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 5
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab6_GVTHValue.Rows.Add
                            tab6_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab6_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab6_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 6
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab7_GVTHValue.Rows.Add
                            tab7_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab7_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab7_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)
                    Case 7
                        For i As Integer = 0 To _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue.Count - 1
                            Dim k = tab8_GVTHValue.Rows.Add
                            tab8_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx).Chart_Series_Properties(n)._ThresholdValue(i)
                            tab8_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._THPointsColor(i)))
                        Next
                        tab8_lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx).Chart_Series_Properties(n)._seriesColor)

                End Select
            Next

            'For i As Integer = 0 To _ListChart_Series.Item(idx)._ThresholdValue.Count - 1
            '    Dim k = tab1_GVTHValue.Rows.Add
            '    tab1_GVTHValue.Rows(k).Cells(0).Value = _ListChart_Series.Item(idx)._ThresholdValue(i)
            '    tab1_GVTHValue.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(CInt(_ListChart_Series.Item(idx)._THPointsColor(i)))
            'Next


        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@lstBoxSeries_SelectedIndexChanged()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub



    Private Sub lbl_GridColor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_GridColor.MouseDoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        Grid_Color = ColDialog.Color
    End Sub

    Private Sub lbl_ChartBackColor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_ChartBackColor.MouseDoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        Chart_BGColor = ColDialog.Color
    End Sub
    Private Sub lbl_LegentColor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_LegentColor.MouseDoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        Legend_Color = ColDialog.Color
    End Sub
    Private Sub lbl_xytitleColor_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_xytitleColor.MouseDoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        xyTitle_Color = ColDialog.Color
    End Sub



    Private Sub btnTitleFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitleFont.Click
        Dim fntDlg As New FontDialog
        fntDlg.ShowColor = True
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString & "," & fntDlg.Color.Name
            Title_Font = fntDlg.Font
            Title_Color = fntDlg.Color
        End If
    End Sub

    Private Sub btnxyAxislblFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnxyAxislblFont.Click
        Dim fntDlg As New FontDialog
        fntDlg.ShowColor = True
        If fntDlg.ShowDialog = DialogResult.OK Then
            txtxyAxislblFont.Text = fntDlg.Font.Name & "," & fntDlg.Font.Size & "," & fntDlg.Font.Style.ToString & "," & fntDlg.Color.Name
            XYAxislbl_Font = fntDlg.Font
            XYAxislbl_color = fntDlg.Color
        End If
    End Sub


    Private Sub ckYAutoScale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckYAutoScale.CheckedChanged
        If ckYAutoScale.Checked Then
            txtYFrom.Enabled = False
            txtYTo.Enabled = False
        Else
            txtYFrom.Enabled = True
            txtYTo.Enabled = True
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab1_btnAdd.Click
        Try
            If tab1_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab1_GVTHValue.Rows(tab1_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab1_GVTHValue.Rows.Add()
                    tab1_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab1_GVTHValue.Rows.Add()
                tab1_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab1_btnDelete.Click
        If tab1_GVTHValue.Rows.Count > 0 AndAlso tab1_GVTHValue.CurrentRow.Index <> -1 Then
            tab1_GVTHValue.Rows.RemoveAt(tab1_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub GVTHValue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tab1_GVTHValue.CellDoubleClick
        If tab1_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab1_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab2_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab2_GVTHValue.CellDoubleClick
        If tab2_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab2_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab3_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab3_GVTHValue.CellDoubleClick
        If tab3_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab3_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab4_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab4_GVTHValue.CellDoubleClick
        If tab4_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab4_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab5_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab5_GVTHValue.CellDoubleClick
        If tab5_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab5_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab6_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab6_GVTHValue.CellDoubleClick
        If tab6_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab6_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab7_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab7_GVTHValue.CellDoubleClick
        If tab7_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab7_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub tab8_GVTHValue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tab8_GVTHValue.CellDoubleClick
        If tab8_GVTHValue.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            tab8_GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub
    Private Sub cBoxChannelYValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxChannelYValue.SelectedIndexChanged
        Try
            TabcontrolSeries.TabPages.Clear()

            If MainPage.OPCDAChannelsList.OPC_Channel_Name.Contains(cBoxChannelYValue.Text) Then
                Dim indx As Integer = MainPage.OPCDAChannelsList.OPC_Channel_Name.IndexOf(cBoxChannelYValue.Text)
                If indx <> -1 Then
                    If MainPage.OPCDAChannelsList.OPC_Multiview(indx) Then
                        Dim tags() As String = MainPage.OPCDAChannelsList.OPC_OPCItems(indx).Split(",")
                        For i As Integer = 0 To tags.Length - 1                            '
                            Select Case i
                                Case 0
                                    TabPage1.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage1)
                                Case 1
                                    TabPage2.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage2)
                                Case 2
                                    TabPage3.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage3)
                                Case 3
                                    TabPage4.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage4)
                                Case 4
                                    TabPage5.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage5)
                                Case 5
                                    TabPage6.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage6)
                                Case 6
                                    TabPage7.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage7)
                                Case 7
                                    TabPage8.Text = tags(i)
                                    TabcontrolSeries.TabPages.Add(TabPage8)
                            End Select
                        Next
                    Else
                        TabPage1.Text = MainPage.OPCDAChannelsList.OPC_OPCItems(indx)
                        TabcontrolSeries.TabPages.Insert(0, TabPage1)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tab2_btnAdd_Click(sender As Object, e As EventArgs) Handles tab2_btnAdd.Click
        Try
            If tab2_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab2_GVTHValue.Rows(tab2_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab2_GVTHValue.Rows.Add()
                    tab2_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab2_GVTHValue.Rows.Add()
                tab2_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab3_btnAdd_Click(sender As Object, e As EventArgs) Handles tab3_btnAdd.Click
        Try
            If tab3_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab3_GVTHValue.Rows(tab3_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab3_GVTHValue.Rows.Add()
                    tab3_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab3_GVTHValue.Rows.Add()
                tab3_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab4_btnAdd_Click(sender As Object, e As EventArgs) Handles tab4_btnAdd.Click
        Try
            If tab4_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab4_GVTHValue.Rows(tab4_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab4_GVTHValue.Rows.Add()
                    tab4_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab4_GVTHValue.Rows.Add()
                tab4_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab5_btnAdd_Click(sender As Object, e As EventArgs) Handles tab5_btnAdd.Click
        Try
            If tab5_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab5_GVTHValue.Rows(tab5_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab5_GVTHValue.Rows.Add()
                    tab5_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab5_GVTHValue.Rows.Add()
                tab5_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab6_btnAdd_Click(sender As Object, e As EventArgs) Handles tab6_btnAdd.Click
        Try
            If tab6_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab6_GVTHValue.Rows(tab6_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab6_GVTHValue.Rows.Add()
                    tab6_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab6_GVTHValue.Rows.Add()
                tab6_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab7_btnAdd_Click(sender As Object, e As EventArgs) Handles tab7_btnAdd.Click
        Try
            If tab7_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab7_GVTHValue.Rows(tab7_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab7_GVTHValue.Rows.Add()
                    tab7_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab7_GVTHValue.Rows.Add()
                tab7_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab8_btnAdd_Click(sender As Object, e As EventArgs) Handles tab8_btnAdd.Click
        Try
            If tab8_GVTHValue.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(tab8_GVTHValue.Rows(tab8_GVTHValue.Rows.Count - 1).Cells(0).Value) Then
                    Dim i = tab8_GVTHValue.Rows.Add()
                    tab8_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
                Else
                    MsgBox("Empty Fields Not Allowed !!!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                Dim i = tab8_GVTHValue.Rows.Add()
                tab8_GVTHValue.Rows(i).Cells(1).Style.BackColor = Color.Green
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tab2_btnDelete_Click(sender As Object, e As EventArgs) Handles tab2_btnDelete.Click
        If tab2_GVTHValue.Rows.Count > 0 AndAlso tab2_GVTHValue.CurrentRow.Index <> -1 Then
            tab2_GVTHValue.Rows.RemoveAt(tab2_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab3_btnDelete_Click(sender As Object, e As EventArgs) Handles tab3_btnDelete.Click
        If tab3_GVTHValue.Rows.Count > 0 AndAlso tab3_GVTHValue.CurrentRow.Index <> -1 Then
            tab3_GVTHValue.Rows.RemoveAt(tab3_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab4_btnDelete_Click(sender As Object, e As EventArgs) Handles tab4_btnDelete.Click
        If tab4_GVTHValue.Rows.Count > 0 AndAlso tab4_GVTHValue.CurrentRow.Index <> -1 Then
            tab4_GVTHValue.Rows.RemoveAt(tab4_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab5_btnDelete_Click(sender As Object, e As EventArgs) Handles tab5_btnDelete.Click
        If tab5_GVTHValue.Rows.Count > 0 AndAlso tab5_GVTHValue.CurrentRow.Index <> -1 Then
            tab5_GVTHValue.Rows.RemoveAt(tab5_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab6_btnDelete_Click(sender As Object, e As EventArgs) Handles tab6_btnDelete.Click
        If tab6_GVTHValue.Rows.Count > 0 AndAlso tab6_GVTHValue.CurrentRow.Index <> -1 Then
            tab6_GVTHValue.Rows.RemoveAt(tab6_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab7_btnDelete_Click(sender As Object, e As EventArgs) Handles tab7_btnDelete.Click
        If tab7_GVTHValue.Rows.Count > 0 AndAlso tab7_GVTHValue.CurrentRow.Index <> -1 Then
            tab7_GVTHValue.Rows.RemoveAt(tab7_GVTHValue.CurrentRow.Index)
        End If
    End Sub
    Private Sub tab8_btnDelete_Click(sender As Object, e As EventArgs) Handles tab8_btnDelete.Click
        If tab8_GVTHValue.Rows.Count > 0 AndAlso tab8_GVTHValue.CurrentRow.Index <> -1 Then
            tab8_GVTHValue.Rows.RemoveAt(tab8_GVTHValue.CurrentRow.Index)
        End If
    End Sub

    Private Sub tab2_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab2_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab2_lblColorTrace.BackColor = ColDialog.Color
    End Sub

    Private Sub tab3_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab3_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab3_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub tab4_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab4_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab4_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub tab5_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab5_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab5_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub tab6_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab6_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab6_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub tab7_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab7_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab7_lblColorTrace.BackColor = ColDialog.Color
    End Sub
    Private Sub tab8_lblColorTrace_Click(sender As Object, e As EventArgs) Handles tab8_lblColorTrace.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        tab8_lblColorTrace.BackColor = ColDialog.Color
    End Sub

    Private Sub llblInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblInfo.LinkClicked
        ChartInfo.ShowDialog()
    End Sub


End Class

