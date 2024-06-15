Imports tab = DevExpress.XtraTab
Imports cht = DevExpress.XtraCharts
Imports System.Drawing.Text
Imports System.Data
Imports System.ComponentModel
'Imports Microsoft.Office.Interop.Excel

Public Class MChartPropertiesForm
    Private ColDialog As New ColorDialog
    Friend _ListChart_Series As New List(Of MChartProperties)
    Friend _Constant_Lines As New BindingList(Of ConstantLineProp)
    'Friend Tagscls As New List(Of SeriesTags)
    Friend _Title As String = ""
    Friend _XaxisTitle As String = ""
    Friend _YaxisTitle As String = ""

    Friend _XScaleMin As Integer
    Friend _XScaleMax As Integer
    Friend _YScaleMin As Integer
    Friend _YScaleMax As Integer


    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer

    Private Slt_idx As Integer
    Private ChannelText As String

    Friend Title_Font, XYAxislbl_Font As New Font("Verdana", 8, FontStyle.Regular)
    Friend Title_Color As Color = System.Drawing.Color.Black
    Friend XYAxislbl_color As Color = System.Drawing.Color.Black
    Friend Chart_BGColor As Color = System.Drawing.Color.WhiteSmoke
    Friend Grid_Color As Color = System.Drawing.Color.Silver
    Friend Legend_Color As Color = System.Drawing.Color.Blue
    Friend xyTitle_Color As Color = System.Drawing.Color.Black
    Friend Series_Color As Color = System.Drawing.Color.Blue
    Private bln3Dstyle As Boolean
    Dim DaTbl As DataTable

    'Private 
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

    Private Sub MChartPropertiseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
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
            cboActionChannel.Text = "MORS"
            cboLambda.Text = "U1Lambda#CV_Instant"
            cboP1.Text = "U1P#CV_Instant"
            cboP1Sch.Text = "ActP1#PV_Instant"
            cboP2.Text = "U2P#CV_Instant"
            cboP2Sch.Text = "ActP2#PV_Instant"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Trend")).ToArray
            OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
            OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray
            'Dim cBoxChannelYValues() As ComboBox = {cBoxChannelYValue, Ser2_cBoxChannelYValue, Ser3_cBoxChannelYValue, Ser4_cBoxChannelYValue, Ser5_cBoxChannelYValue, Ser6_cBoxChannelYValue, Ser7_cBoxChannelYValue, Ser8_cBoxChannelYValue}
            'Dim cBoxChannelXValues() As ComboBox = {Ser1_cBoxChannelXValue, Ser2_cBoxChannelXValue, Ser3_cBoxChannelXValue, Ser4_cBoxChannelXValue, Ser5_cBoxChannelXValue, Ser6_cBoxChannelXValue, Ser7_cBoxChannelXValue, Ser8_cBoxChannelXValue}
            Dim cBoxChannelY2Values() As ComboBox = {Ser1_cBoxChannelY2Value, Ser2_cBoxChannelY2Value, Ser3_cBoxChannelY2Value, Ser4_cBoxChannelY2Value, Ser5_cBoxChannelY2Value, Ser6_cBoxChannelY2Value, Ser7_cBoxChannelY2Value, Ser8_cBoxChannelY2Value}
            Dim lblColorSeries() As Label = {Ser1_lblColorSeries, Ser2_lblColorSeries, Ser3_lblColorSeries, Ser4_lblColorSeries, Ser5_lblColorSeries, Ser6_lblColorSeries, Ser7_lblColorSeries, Ser8_lblColorSeries}
            Dim lblColorMarkers() As Label = {Ser1_lblColorMarker, Ser2_lblColorMarker, Ser3_lblColorMarker, Ser4_lblColorMarker, Ser5_lblColorMarker, Ser6_lblColorMarker, Ser7_lblColorMarker, Ser8_lblColorMarker}
            'For c As Integer = 1 To tabControl.TabPages.Count
            '    cBoxChannelYValues(c).Items.Clear()
            '    cBoxChannelXValues(c).Items.Clear()
            '    cBoxChannelY2Values(c).Items.Clear()
            'Next
            'DGViewConstantLine.DataSource = Null


            'For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
            '    cBoxChannelValue.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
            'Next
            'For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
            '    cBoxChannelValue.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
            'Next
            'For i As Integer = 0 To MainPage.OPCDAChannelsList.OPC_Channel_Name.Count - 1
            '    cBoxChannelValue.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(i))
            'Next
            If MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count > 0 Then
                For i As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                    cBoxChannelValue.Items.Add(MainPage.SAMAHistorian_ChannelList.ChannelReportname.Item(i))
                Next
            End If

            Dim rnd As New Random
            ' Dim rnd1 As New Random


            txtTitleFont.Text = Title_Font.Name & "," & Title_Font.Size & "," & Title_Font.Style.ToString & "," & Title_Color.Name
            'txtxyAxislblFont.Text = XYAxislbl_Font.Name & "," & XYAxislbl_Font.Size & "," & XYAxislbl_Font.Style.ToString & "," & XYAxislbl_color.Name

            lbl_LegendColor.BackColor = Legend_Color
            lbl_xytitleColor.BackColor = xyTitle_Color
            lbl_ChartBackColor.BackColor = Chart_BGColor
            'lbl_GridColor.BackColor = Grid_Color
            TxtTitle.Text = _Title
            txtXAxisTitle.Text = _XaxisTitle
            txtYAxisTitle.Text = _YaxisTitle

            txtYFrom.Text = _YScaleMin
            txtYTo.Text = _YScaleMax


            'For t As Integer = 1 To tabControl.TabPages.Count - 1
            '    lblColorSeries(t).BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
            '    lblColorMarkers(t).BackColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))
            'Next

            gcConstantLine.DataSource = _Constant_Lines

            Call LoadChartProperies()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Properties(ByVal chartctl As MChartControl)

        Dim DT As New DataTable

        Try
            _Title = TxtTitle.Text
            _XaxisTitle = txtXAxisTitle.Text
            _YaxisTitle = txtYAxisTitle.Text

            'Dim cBoxChannelYValues() As ComboBox = {Ser1_cBoxChannelYValue, Ser2_cBoxChannelYValue, Ser3_cBoxChannelYValue, Ser4_cBoxChannelYValue, Ser5_cBoxChannelYValue, Ser6_cBoxChannelYValue, Ser7_cBoxChannelYValue, Ser8_cBoxChannelYValue}
            Dim cBoxChannelY2Values() As ComboBox = {Ser1_cBoxChannelY2Value, Ser2_cBoxChannelY2Value, Ser3_cBoxChannelY2Value, Ser4_cBoxChannelY2Value, Ser5_cBoxChannelY2Value, Ser6_cBoxChannelY2Value, Ser7_cBoxChannelY2Value, Ser8_cBoxChannelY2Value}
            Dim CboxViewTypes() As ComboBox = {Ser1_cBoxViewType, Ser2_cBoxViewType, Ser3_cBoxViewType, Ser4_cBoxViewType, Ser5_cBoxViewType, Ser6_cBoxViewType, Ser7_cBoxViewType, Ser8_cBoxViewType}
            Dim CboxMarkerStyles() As ComboBox = {Ser1_cBoxMarkerStyle, Ser2_cBoxMarkerStyle, Ser3_cBoxMarkerStyle, Ser4_CboxMarkerStyle, Ser5_cBoxMarkerStyle, Ser6_cBoxMarkerStyle, Ser7_cBoxMarkerStyle, Ser8_cBoxMarkerStyle}
            'Dim cboxMarkerValues() As ComboBox = {Ser1_cboxMarkerValue, Ser2_cboxMarkerValue, Ser3_cboxMarkerValue, Ser4_cboxMarkerValue, Ser5_cboxMarkerValue, Ser6_cboxMarkerValue, Ser7_cboxMarkerValue, Ser8_cboxMarkerValue}
            'Dim lblColorMarkers() As Label = {Ser1_lblColorMarker, Ser2_lblColorMarker, Ser3_lblColorMarker, Ser4_lblColorMarker, Ser5_lblColorMarker, Ser6_lblColorMarker, Ser7_lblColorMarker, Ser8_lblColorMarker}
            Dim SeriesNames() As TextBox = {Ser1_txtSeriesName, Ser2_txtSeriesName, Ser3_txtSeriesName, Ser4_txtSeriesName, Ser5_txtSeriesName, Ser6_txtSeriesName, Ser7_txtSeriesName, Ser8_txtSeriesName}
            Dim lblColorSeries() As Label = {Ser1_lblColorSeries, Ser2_lblColorSeries, Ser3_lblColorSeries, Ser4_lblColorSeries, Ser5_lblColorSeries, Ser6_lblColorSeries, Ser7_lblColorSeries, Ser8_lblColorSeries}

            'If TrendCtl.ChartControl1.ChartAreas(0).Area3DStyle.Enable3D = True Then
            '    bln3Dstyle = True
            'End If
            If Not (Not txtYFrom.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYFrom.Text)) And Not (Not txtYTo.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYTo.Text)) Then
                _YScaleMax = txtYTo.Text
                _YScaleMin = txtYFrom.Text
            Else
                MsgBox("Scalling could not be empty !!!")
                Exit Sub
            End If

            Dim diagram As cht.XYDiagram = CType(chartctl.Diagram, cht.XYDiagram)
            If chartctl.Series.Count > 0 Then
                'chartctl.DataSource = vbNull
                diagram.AxisX.ConstantLines.Clear()
                diagram.AxisY.ConstantLines.Clear()
                chartctl.Series.Clear()
                'chartctl.Legends.Clear()
                chartctl.Titles.Clear()
                diagram.SecondaryAxesY.Clear()
                'diagram.Panes.Add(New cht.XYDiagramPane("ChartArea1"))
            End If

            Dim tt As New cht.ChartTitle
            tt.Text = _Title
            tt.Font = Title_Font
            tt.TextColor = Title_Color
            chartctl.Titles.Add(tt)

            chartctl.AccessibleDescription = cBoxChannelValue.Text


            DT = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cboActionChannel.Text))

            'DT = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelValue.Text))

            'if Time scale
            If Rbtntime.Checked = True Then
                'Adding series to the chart on runtime
                For p As Integer = 1 To DT.Columns.Count - 1
                    'p -= 1
                    SeriesNames(p - 1).Text = _ListChart_Series.Item(p - 1)._seriesName
                    CboxViewTypes(p - 1).SelectedIndex = CboxViewTypes(p - 1).Items.IndexOf(_ListChart_Series.Item(p - 1)._viewtype)
                    CboxMarkerStyles(p - 1).SelectedIndex = CboxMarkerStyles(p - 1).Items.IndexOf(_ListChart_Series.Item(p - 1)._markerstyle)


                    Dim ser As cht.Series = New cht.Series(_ListChart_Series.Item(p - 1)._seriesName, cht.ViewType.Line)
                    chartctl.Series.Add(ser)
                Next

                chartctl.DataSource = DT

                For j = 0 To chartctl.Series.Count - 1
                    chartctl.Series(j).View.Color = Color.FromArgb(_ListChart_Series.Item(j)._seriesColor)
                    'Get seriesnames from the chart
                    Dim Seriesbase As cht.Series = chartctl.GetSeriesByName(chartctl.Series(j).Name)

                    Select Case CboxViewTypes(j).Text
                        Case "Line"
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.LineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Line)
                            End If
                            Dim myview1 As cht.LineSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.LineMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Spline"
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.SplineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Spline)
                            End If
                            Dim myview1 As cht.SplineSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Area"
                            'Dim myview1 As cht.AreaSeriesView = CType(chartctl.Series(j).View, cht.AreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Area)
                            End If
                            Dim myview1 As cht.AreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "SplineArea"
                            'Dim myview1 As cht.SplineAreaSeriesView = CType(chartctl.Series(j).View, cht.SplineAreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.SplineArea)
                            End If
                            Dim myview1 As cht.SplineAreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "StackedArea"
                            'Dim myview1 As cht.StackedAreaSeriesView = CType(chartctl.Series(j).View, cht.StackedAreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.StackedArea)
                            End If
                            Dim myview1 As cht.StackedAreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Bar"
                            'Dim myview1 As cht.BarSeriesView = CType(chartctl.Series(j).View, cht.BarSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Bar)
                            End If
                            Dim myview1 As cht.BarSeriesView = Seriesbase.View
                        Case "StackedBar"
                            'Dim myview1 As cht.StackedBarSeriesView = CType(chartctl.Series(j).View, cht.StackedBarSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.StackedBar)
                            End If
                            Dim myview1 As cht.StackedBarSeriesView = Seriesbase.View
                        Case "Pie"
                            'Dim myview1 As cht.PieSeriesView = CType(chartctl.Series(j).View, cht.PieSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Pie)
                            End If
                            Dim myview1 As cht.PieSeriesView = Seriesbase.View
                        Case "Doughnut"
                            'Dim myview1 As cht.DoughnutSeriesView = CType(chartctl.Series(j).View, cht.DoughnutSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Doughnut)
                            End If
                            Dim myview1 As cht.DoughnutSeriesView = Seriesbase.View
                        Case "Funnel"
                            'Dim myview1 As cht.FunnelSeriesView = CType(chartctl.Series(j).View, cht.FunnelSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Funnel)
                            End If
                            Dim myview1 As cht.FunnelSeriesView = Seriesbase.View
                        Case "Radar"
                            'Dim myview1 As cht.RadarLineSeriesView = CType(chartctl.Series(j).View, cht.RadarLineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.RadarLine)
                            End If
                            Dim myview1 As cht.RadarLineSeriesView = Seriesbase.View
                        Case Else
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.LineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Line)
                                Dim myview1 As cht.LineSeriesView = Seriesbase.View
                                Select Case CboxMarkerStyles(j).Text
                                    Case "Circle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                    Case "Cross"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                    Case "Diamond"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                    Case "Hexagon"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                    Case "InvertedTriangle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                    Case "Pentagon"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                    Case "Plus"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                    Case "Square"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                    Case "Star"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                    Case "ThinCross"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                    Case "Triangle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                                End Select
                                myview1.LineMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                                myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                            End If
                    End Select

                    'Set scaletype auto - XAxis
                    chartctl.Series(j).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

                Next
            ElseIf RBtnValue.Checked = True Then
                For p As Integer = 1 To DT.Columns.Count - 1
                    SeriesNames(p - 1).Text = _ListChart_Series.Item(p - 1)._seriesName
                    CboxViewTypes(p - 1).SelectedIndex = CboxViewTypes(p - 1).Items.IndexOf(_ListChart_Series.Item(p - 1)._viewtype)
                    CboxMarkerStyles(p - 1).SelectedIndex = CboxMarkerStyles(p - 1).Items.IndexOf(_ListChart_Series.Item(p - 1)._markerstyle)


                    Dim ser As cht.Series = New cht.Series(_ListChart_Series.Item(p - 1)._seriesName, cht.ViewType.Line)
                    chartctl.Series.Add(ser)

                Next


                chartctl.DataSource = DT

                For j = 0 To chartctl.Series.Count - 1
                    chartctl.Series(j).View.Color = Color.FromArgb(_ListChart_Series.Item(j)._seriesColor)
                    Dim myseries As cht.Series = New cht.Series(chartctl.Series(j).Name, cht.ViewType.Line)
                    Dim myview As cht.PointSeriesView = CType(chartctl.Series(j).View, cht.PointSeriesView)

                    Dim Seriesbase As cht.Series = chartctl.GetSeriesByName(chartctl.Series(j).Name)

                    Select Case CboxViewTypes(j).Text
                        Case "Line"
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.LineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Line)
                            End If
                            Dim myview1 As cht.LineSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.LineMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Spline"
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.SplineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Spline)
                            End If
                            Dim myview1 As cht.SplineSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Area"
                            'Dim myview1 As cht.AreaSeriesView = CType(chartctl.Series(j).View, cht.AreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Area)
                            End If
                            Dim myview1 As cht.AreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "SplineArea"
                            'Dim myview1 As cht.SplineAreaSeriesView = CType(chartctl.Series(j).View, cht.SplineAreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.SplineArea)
                            End If
                            Dim myview1 As cht.SplineAreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "StackedArea"
                            'Dim myview1 As cht.StackedAreaSeriesView = CType(chartctl.Series(j).View, cht.StackedAreaSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.StackedArea)
                            End If
                            Dim myview1 As cht.StackedAreaSeriesView = Seriesbase.View
                            Select Case CboxMarkerStyles(j).Text
                                Case "Circle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                Case "Cross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                Case "Diamond"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                Case "Hexagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                Case "InvertedTriangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                Case "Pentagon"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                Case "Plus"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                Case "Square"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                Case "Star"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                Case "ThinCross"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                Case "Triangle"
                                    myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                            End Select
                            myview1.PointMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                            myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                        Case "Bar"
                            'Dim myview1 As cht.BarSeriesView = CType(chartctl.Series(j).View, cht.BarSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Bar)
                            End If
                            Dim myview1 As cht.BarSeriesView = Seriesbase.View
                        Case "StackedBar"
                            'Dim myview1 As cht.StackedBarSeriesView = CType(chartctl.Series(j).View, cht.StackedBarSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.StackedBar)
                            End If
                            Dim myview1 As cht.StackedBarSeriesView = Seriesbase.View
                        Case "Pie"
                            'Dim myview1 As cht.PieSeriesView = CType(chartctl.Series(j).View, cht.PieSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Pie)
                            End If
                            Dim myview1 As cht.PieSeriesView = Seriesbase.View
                        Case "Doughnut"
                            'Dim myview1 As cht.DoughnutSeriesView = CType(chartctl.Series(j).View, cht.DoughnutSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Doughnut)
                            End If
                            Dim myview1 As cht.DoughnutSeriesView = Seriesbase.View
                        Case "Funnel"
                            'Dim myview1 As cht.FunnelSeriesView = CType(chartctl.Series(j).View, cht.FunnelSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Funnel)
                            End If
                            Dim myview1 As cht.FunnelSeriesView = Seriesbase.View
                        Case "Radar"
                            'Dim myview1 As cht.RadarLineSeriesView = CType(chartctl.Series(j).View, cht.RadarLineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.RadarLine)
                            End If
                            Dim myview1 As cht.RadarLineSeriesView = Seriesbase.View
                        Case Else
                            'Dim myview1 As cht.LineSeriesView = CType(chartctl.Series(j).View, cht.LineSeriesView)
                            If Seriesbase IsNot Nothing Then
                                Seriesbase.ChangeView(cht.ViewType.Line)
                                Dim myview1 As cht.LineSeriesView = Seriesbase.View
                                Select Case CboxMarkerStyles(j).Text
                                    Case "Circle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Circle
                                    Case "Cross"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Cross
                                    Case "Diamond"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Diamond
                                    Case "Hexagon"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Hexagon
                                    Case "InvertedTriangle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.InvertedTriangle
                                    Case "Pentagon"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Pentagon
                                    Case "Plus"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Plus
                                    Case "Square"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Square
                                    Case "Star"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Star
                                    Case "ThinCross"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.ThinCross
                                    Case "Triangle"
                                        myview1.PointMarkerOptions.Kind = cht.MarkerKind.Triangle
                                End Select
                                myview1.LineMarkerOptions.Size = _ListChart_Series.Item(j)._markersize
                                myview1.PointMarkerOptions.BorderColor = Color.FromArgb(_ListChart_Series.Item(j)._markercolor)
                            End If
                    End Select

                    'Set scaletype auto - XAxis
                    chartctl.Series(j).ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

                Next

            End If
            Dim Secondary As New cht.SecondaryAxisY("Y-Axis1")
            diagram.SecondaryAxesY.Add(Secondary)
            CType(chartctl.Series(1).View, cht.PointSeriesView).AxisY = Secondary
            SAMAHistorianChannels.AssigntoControl(DT, cBoxChannelValue.Text)

            'diagram.AxisX.GridLines.Visible = True
            'diagram.AxisY.GridLines.Visible = True
            'diagram.AxisX.QualitativeScaleOptions.GridSpacing = 2
            'If Rbtntime.Checked = True Then
            '    'Customize Axis
            '    '---Dim diagram1 As cht.XYDiagram = TryCast(chartctl.Diagram, cht.XYDiagram)
            '    ' Define the date-time measurement unit, to which the beginning of 
            '    ' a diagram's gridlines and labels should be aligned. 
            '    'diagram.AxisX.QualitativeScaleOptions.GridLayoutMode = DevExpress.XtraCharts.GridLayoutMode.GridAndLabelShifted

            '    ' Define the detail level for date-time values.
            '    '---diagram.AxisX.DateTimeScaleOptions.MeasureUnit = cht.DateTimeMeasureUnit.Second

            '    ' Define the custom date-time format (name of a month) for the axis labels.
            '    '---diagram.AxisX.Label.TextPattern = "{A:HH:mm:ss}"

            '    ' Since the ValueScaleType of the chart's series is Numerical,
            '    ' it Is possible to customize the NumericOptions of Y-axis.
            '    'diagram.AxisY.Label.TextPattern = "{V:C1}"
            'End If



            If ckYAutoScale.Checked Then
                diagram.AxisY.WholeRange.Auto = True
                diagram.AxisY.WholeRange.MinValue = Double.NaN
                diagram.AxisY.WholeRange.MaxValue = Double.NaN
            Else
                diagram.AxisY.WholeRange.MinValue = _YScaleMin
                diagram.AxisY.WholeRange.MaxValue = _YScaleMax
            End If
            'Secondary y axis range
            'Secondary.WholeRange.SetMinMaxValues(diagram.AxisY.WholeRange.MinValue, diagram.AxisY.WholeRange.MaxValue)


            'Constant line add(vertical)
            If _Constant_Lines.Count > 0 Then

                For p As Integer = 0 To _Constant_Lines.Count - 1
                    If _Constant_Lines.Item(p).Axis = "X-Axis" Then
                        Dim horzline As New cht.ConstantLine(_Constant_Lines.Item(p).LineName.ToString())
                        horzline.Color = Color.FromArgb(_Constant_Lines.Item(p).Color)
                        horzline.AxisValue = _Constant_Lines.Item(p).AxisValue
                        horzline.ShowBehind = _Constant_Lines.Item(p).Visible

                        diagram.AxisY.ConstantLines.Add(horzline)
                    ElseIf _Constant_Lines.Item(p).Axis = "Y-Axis" Then
                        Dim vertline As New cht.ConstantLine(_Constant_Lines.Item(p).LineName.ToString())
                        vertline.Color = Color.FromArgb(_Constant_Lines.Item(p).Color)
                        vertline.AxisValue = _Constant_Lines.Item(p).AxisValue
                        vertline.ShowBehind = _Constant_Lines.Item(p).Visible

                        diagram.AxisY.ConstantLines.Add(vertline)
                    End If
                Next

                If RBtnValue.Checked Then
                    diagram.EnableAxisXScrolling = False
                    diagram.EnableAxisYScrolling = False
                Else
                    diagram.EnableAxisXScrolling = True
                    diagram.EnableAxisYScrolling = True
                End If
            End If

            'Dim x1 As New cht.ConstantLine("min")
            'Dim x2 As New cht.ConstantLine("max")
            'Dim y1 As New cht.ConstantLine("cost")
            'x1.AxisValue = diagram.AxisX.WholeRange.MinValue
            'x1.ShowInLegend = True
            'x2.AxisValue = diagram.AxisX.WholeRange.MaxValue
            'x2.ShowInLegend = True

            'Horizontal line
            'y1.AxisValue = diagram.AxisY.WholeRange.MaxValue
            'y1.ShowInLegend = True
            'y1.Color = Color.Red
            'y1.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot
            'y1.RuntimeMoving = True



            diagram.AxisX.Label.Font = XYAxislbl_Font
            diagram.AxisY.Label.Font = XYAxislbl_Font
            diagram.AxisX.Label.TextColor = XYAxislbl_color
            diagram.AxisY.Label.TextColor = XYAxislbl_color

            diagram.AxisY.Logarithmic = True
            diagram.AxisY.LogarithmicBase = 10

            diagram.AxisX.Label.Angle = -45
            'diagram.EnableAxisXScrolling = True
            diagram.EnableAxisXZooming = True
            diagram.EnableAxisYZooming = True




            diagram.AxisY.Title.Text = _YaxisTitle
            diagram.AxisX.Title.Text = _XaxisTitle
            diagram.AxisY.Title.TextColor = xyTitle_Color
            diagram.AxisX.Title.TextColor = xyTitle_Color
            diagram.AxisY.Title.Font = XYAxislbl_Font
            diagram.AxisX.Title.Font = XYAxislbl_Font

            ' Customize the appearance of the axes' tickmarks.
            diagram.AxisX.Tickmarks.CrossAxis = False
            diagram.AxisX.Tickmarks.Length = 5
            'diagram.AxisX.Tickmarks.Thickness = 2

            'diagram.AxisY.Tickmarks.Visible = False
            'diagram.AxisY.Tickmarks.MinorVisible = False

            'diagram.AxisX.Tickmarks.MinorLength = 3
            'diagram.AxisX.Tickmarks.MinorThickness = 1

            'diagram.AxisX.MinorCount = 2
            'diagram.AxisY.MinorCount = 4

            ' Customize the appearance of the axes' grid lines.
            diagram.AxisX.GridLines.Visible = True
            'diagram.AxisX.GridLines.MinorVisible = False

            diagram.AxisY.GridLines.Visible = True
            'diagram.AxisY.GridLines.MinorVisible = True

            'diagram.AxisY.GridLines.Color = Color.Black
            'diagram.AxisY.GridLines.LineStyle.DashStyle = cht.DashStyle.Solid
            'diagram.AxisY.GridLines.LineStyle.Thickness = 2

            'diagram.AxisY.GridLines.MinorColor = Color.Blue
            'diagram.AxisY.GridLines.MinorLineStyle.DashStyle = cht.DashStyle.Solid
            'diagram.AxisY.GridLines.MinorLineStyle.Thickness = 1

            Chart_BGColor = lbl_ChartBackColor.BackColor
            'Grid_Color = lblLegendColor.BackColor

            chartctl.BackColor = Chart_BGColor
            'diagram.AxisX.GridLines.Color = Color.Black
            'diagram.AxisY.GridLines.Color = Color.Black




        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@MChart-Properties()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


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



    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        'If MainPage.SAMAHistorian_ChannelList.ChannelXAxis.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(Ser1_cBoxChannelYValue.Text)) = "Time" Then
        '    MsgBox("The Chart Cannot be Displayed")
        'Else
        Call Add_Properties()
        Call Properties(MainPage.MChart_Ctrl)
        Try
            If Not ValidRecords() Then
                Exit Sub
            End If
            MainPage.MChart_Ctrl.gstrMCActionChannel = cboActionChannel.Text
            MainPage.MChart_Ctrl.gstrMCTagForLambda = cboLambda.Text
            'MainPage.MChart_Ctrl.gstrMCTagForP1 = cboP1.Text
            'MainPage.MChart_Ctrl.gstrMCTagForP1Lambda = cboP1Sch.Text
            'MainPage.MChart_Ctrl.gstrMCTagForP2 = cboP2.Text
            'MainPage.MChart_Ctrl.gstrMCTagForP2Lambda = cboP2Sch.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'End If

        Me.Close()
    End Sub

    Private Sub LoadChartProperies()

        Try
            Dim idx As Integer = 0

            Dim cBoxChannelY2Values() As ComboBox = {Ser1_cBoxChannelY2Value, Ser2_cBoxChannelY2Value, Ser3_cBoxChannelY2Value, Ser4_cBoxChannelY2Value, Ser5_cBoxChannelY2Value, Ser6_cBoxChannelY2Value, Ser7_cBoxChannelY2Value, Ser8_cBoxChannelY2Value}
            Dim CboxViewTypes() As ComboBox = {Ser1_cBoxViewType, Ser2_cBoxViewType, Ser3_cBoxViewType, Ser4_cBoxViewType, Ser5_cBoxViewType, Ser6_cBoxViewType, Ser7_cBoxViewType, Ser8_cBoxViewType}
            Dim CboxMarkerStyles() As ComboBox = {Ser1_cBoxMarkerStyle, Ser2_cBoxMarkerStyle, Ser3_cBoxMarkerStyle, Ser4_CboxMarkerStyle, Ser5_cBoxMarkerStyle, Ser6_cBoxMarkerStyle, Ser7_cBoxMarkerStyle, Ser8_cBoxMarkerStyle}
            Dim cboxMarkerValues() As ComboBox = {Ser1_cboxMarkerValue, Ser2_cboxMarkerValue, Ser3_cboxMarkerValue, Ser4_cboxMarkerValue, Ser5_cboxMarkerValue, Ser6_cboxMarkerValue, Ser7_cboxMarkerValue, Ser8_cboxMarkerValue}
            Dim lblColorMarkers() As Label = {Ser1_lblColorMarker, Ser2_lblColorMarker, Ser3_lblColorMarker, Ser4_lblColorMarker, Ser5_lblColorMarker, Ser6_lblColorMarker, Ser7_lblColorMarker, Ser8_lblColorMarker}
            Dim lblColorSeries() As Label = {Ser1_lblColorSeries, Ser2_lblColorSeries, Ser3_lblColorSeries, Ser4_lblColorSeries, Ser5_lblColorSeries, Ser6_lblColorSeries, Ser7_lblColorSeries, Ser8_lblColorSeries}
            Dim txtSeriesNames() As TextBox = {Ser1_txtSeriesName, Ser2_txtSeriesName, Ser3_txtSeriesName, Ser4_txtSeriesName, Ser5_txtSeriesName, Ser6_txtSeriesName, Ser7_txtSeriesName, Ser8_txtSeriesName}
            'Dim lblAxisLabelColors() As Label = {, Ser2_lblColorMarker, Ser3_lblColorMarker, Ser4_lblColorMarker, Ser5_lblColorMarker, Ser6_lblColorMarker, Ser7_lblColorMarker, Ser8_lblColorMarker}
            'cBoxChannelValue.Items.Clear()
            cBoxChannelValue.Text = _ListChart_Series.Item(idx)._yExpression

            'Dim rnm As New Random
            If _ListChart_Series.Count > 0 Then
                For i As Integer = 0 To _ListChart_Series.Count - 1
                    txtSeriesNames(i).Text = _ListChart_Series.Item(i)._seriesName
                    CboxViewTypes(i).Text = _ListChart_Series.Item(i)._viewtype
                    CboxMarkerStyles(i).Text = _ListChart_Series.Item(i)._markerstyle
                    cboxMarkerValues(i).Text = _ListChart_Series.Item(i)._markersize
                    lblColorMarkers(i).BackColor = Color.FromArgb(_ListChart_Series.Item(i)._markercolor)
                    lblColorSeries(i).BackColor = Color.FromArgb(_ListChart_Series.Item(i)._seriesColor)

                    'If MainPage.MChart_Ctrl.SeriesTags.Count > 0 Then
                    '    If MainPage.MChart_Ctrl._xaxis <> "Time" Then
                    '        If MainPage.MChart_Ctrl._xaxis = MainPage.MChart_Ctrl.SeriesTags(i) Then
                    '            Continue For
                    '        Else
                    '            cBoxChannelY2Values(i - 1).Text = MainPage.MChart_Ctrl.SeriesTags(i)
                    '        End If
                    '    ElseIf MainPage.MChart_Ctrl._xaxis = "Time" Then
                    '        cBoxChannelY2Values(i).Text = MainPage.MChart_Ctrl.SeriesTags(i)
                    '    End If
                    'End If
                Next
            End If

            If _ListChart_Series.Item(idx).AxixLabelEnabled Then
                ckLabelEnable.Checked = True
            Else
                ckLabelEnable.Checked = False
            End If

            'If MainPage.MChart_Ctrl._xaxis = "Time" Then
            '    Rbtntime.Checked = True
            '    Label2.Visible = False
            '    CboxTagscale.Visible = False

            'Else
            '    RBtnValue.Checked = True
            '    Label2.Visible = True
            '    CboxTagscale.Visible = True
            'End If


            CboxTagscale.Items.Clear()

            'MessageBox.Show(MainPage.MChart_Ctrl.SeriesTags.Count.ToString())
            'If MainPage.MChart_Ctrl._xaxis <> "Time" Then
            '    For i As Integer = 0 To _ListChart_Series.Count - 1
            '        If MainPage.MChart_Ctrl.SeriesTags.Count > 0 Then
            '            CboxTagscale.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
            '            'cBoxChannelY2Values(i).Text = MainPage.MChart_Ctrl.SeriesTags(i + 1)
            '        End If
            '    Next
            '    If Not MainPage.MChart_Ctrl._xaxis = "" Then
            '        CboxTagscale.Text = MainPage.MChart_Ctrl._xaxis
            '    End If
            'End If




        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@lstBoxSeries_SelectedIndexChanged()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub
    Private Sub Add_Properties()
        Try
            Dim lblSeriesNames() As TextBox = {Ser1_txtSeriesName, Ser2_txtSeriesName, Ser3_txtSeriesName, Ser4_txtSeriesName, Ser5_txtSeriesName, Ser6_txtSeriesName, Ser7_txtSeriesName, Ser8_txtSeriesName}
            Dim cBoxserYValues() As ComboBox = {Ser1_cBoxChannelY2Value, Ser2_cBoxChannelY2Value, Ser3_cBoxChannelY2Value, Ser4_cBoxChannelY2Value, Ser5_cBoxChannelY2Value, Ser6_cBoxChannelY2Value, Ser7_cBoxChannelY2Value, Ser8_cBoxChannelY2Value}
            Dim cBoxViewTypes() As ComboBox = {Ser1_cBoxViewType, Ser2_cBoxViewType, Ser3_cBoxViewType, Ser4_cBoxViewType, Ser5_cBoxViewType, Ser6_cBoxViewType, Ser7_cBoxViewType, Ser8_cBoxViewType}
            Dim cBoxMarkerStyles() As ComboBox = {Ser1_cBoxMarkerStyle, Ser2_cBoxMarkerStyle, Ser3_cBoxMarkerStyle, Ser4_CboxMarkerStyle, Ser5_cBoxMarkerStyle, Ser6_cBoxMarkerStyle, Ser7_cBoxMarkerStyle, Ser8_cBoxMarkerStyle}
            Dim cboxMarkerValues() As ComboBox = {Ser1_cboxMarkerValue, Ser2_cboxMarkerValue, Ser3_cboxMarkerValue, Ser4_cboxMarkerValue, Ser5_cboxMarkerValue, Ser6_cboxMarkerValue, Ser7_cboxMarkerValue, Ser8_cboxMarkerValue}
            Dim lblColorMarkers() As Label = {Ser1_lblColorMarker, Ser2_lblColorMarker, Ser3_lblColorMarker, Ser4_lblColorMarker, Ser5_lblColorMarker, Ser6_lblColorMarker, Ser7_lblColorMarker, Ser8_lblColorMarker}
            Dim lblColorSeries() As Label = {Ser1_lblColorSeries, Ser2_lblColorSeries, Ser3_lblColorSeries, Ser4_lblColorSeries, Ser5_lblColorSeries, Ser6_lblColorSeries, Ser7_lblColorSeries, Ser8_lblColorSeries}

            Dim lblAxixlabel As Boolean
            If ckLabelEnable.Checked Then
                lblAxixlabel = True
            Else
                lblAxixlabel = False
            End If

            'Customize Axis
            Dim diagram As cht.XYDiagram = TryCast(MainPage.MChart_Ctrl.Diagram, cht.XYDiagram)
            'If Rbtntime.Checked Then
            '    MainPage.MChart_Ctrl._xaxis = "Time"
            'ElseIf RBtnValue.Checked Then
            '    MainPage.MChart_Ctrl._xaxis = CboxTagscale.Text
            '    MainPage.MChart_Ctrl.SeriesTags.Add(CboxTagscale.Text)
            'End If

            _ListChart_Series.Clear()

            'To get tabpage visible count
            Dim aa As Integer = 0
            For a As Integer = 1 To tabMChartProp.TabPages.Count - 1
                If tabMChartProp.TabPages(a).PageVisible = True Then
                    aa = aa + 1
                End If
            Next

            Dim prop As New MChartProperties
            If Rbtntime.Checked = True Then
                For i As Integer = 0 To aa
                    prop = ProcAddProperties(lblSeriesNames(i).Text, lblColorSeries(i).BackColor.ToArgb, cBoxChannelValue.Text _
                , cBoxViewTypes(i).Text, cBoxMarkerStyles(i).Text, cboxMarkerValues(i).Text _
                , lblColorMarkers(i).BackColor.ToArgb, lblAxisLabelColor.BackColor.ToArgb, lblAxixlabel)


                    _ListChart_Series.Add(prop)
                Next
            Else
                prop = ProcAddProperties(lblSeriesNames(0).Text, lblColorSeries(0).BackColor.ToArgb, cBoxChannelValue.Text _
               , cBoxViewTypes(0).Text, cBoxMarkerStyles(0).Text, cboxMarkerValues(0).Text _
               , lblColorMarkers(0).BackColor.ToArgb, lblAxisLabelColor.BackColor.ToArgb, lblAxixlabel)
                _ListChart_Series.Add(prop)
                For i As Integer = 0 To aa
                    prop = ProcAddProperties(lblSeriesNames(i + 1).Text, lblColorSeries(i + 1).BackColor.ToArgb, cBoxChannelValue.Text _
                                    , cBoxViewTypes(i + 1).Text, cBoxMarkerStyles(i + 1).Text, cboxMarkerValues(i + 1).Text _
                                    , lblColorMarkers(i + 1).BackColor.ToArgb, lblAxisLabelColor.BackColor.ToArgb, lblAxixlabel)
                    _ListChart_Series.Add(prop)
                Next
            End If

            'Add ConstantLines
            ' _ConstantLines.Clear()
            'Dim clines As New ConstantLine
            'Dim avillines As BindingList(Of ConstantLine) = gcConstantLine.DataSource

            'For m As Integer = 0 To avillines.Count - 1
            '    clines = ProcAddContantLine(avillines.Item(m).LineName, avillines.Item(m).Axis, avillines.Item(m).AxisValue, avillines.Item(m).Color, avillines.Item(m).Visible)
            '    _ConstantLines.Add(clines)
            'Next



            ' Add Tagnames 
            'For j As Integer = 0 To _ListChart_Series.Count - 1
            '    If RBtnValue.Checked Then
            '        If cBoxserYValues(j).Text IsNot Nothing Then
            '            MainPage.MChart_Ctrl.SeriesTags.Add(cBoxserYValues(j).Text)
            '        End If
            '    Else
            '        If cBoxserYValues(j).Text IsNot Nothing Then
            '            MainPage.MChart_Ctrl.SeriesTags.Add(cBoxserYValues(j).Text)
            '        End If
            '    End If

            'Next



        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@btnUpdate_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub



    Private Sub RBtnValue_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnValue.CheckedChanged
        If RBtnValue.Checked Then
            lblXaxisTagname.Visible = True
            CboxTagscale.Visible = True
        Else
            lblXaxisTagname.Visible = False
            CboxTagscale.Visible = False
        End If

    End Sub

    Private Sub Rbtntime_CheckedChanged(sender As Object, e As EventArgs) Handles Rbtntime.CheckedChanged
        If Rbtntime.Checked Then
            lblXaxisTagname.Visible = False
            CboxTagscale.Visible = False

        Else
            lblXaxisTagname.Visible = True
            CboxTagscale.Visible = True
        End If
    End Sub

    Private Sub btnMChartpropertiseCancel_Click(sender As Object, e As EventArgs) Handles btnMChartpropertiseCancel.Click
        Me.Close()
    End Sub

    'Private Sub lbl_GridColor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '    Coldialog.ShowDialog()
    '    Coldialog.FullOpen = False
    '    sender.BackColor = Coldialog.Color
    '    Grid_Color = Coldialog.Color
    'End Sub

    Private Sub lbl_ChartBackColor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        Chart_BGColor = ColDialog.Color
    End Sub

    Private Sub lbl_xytitleColor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        xyTitle_Color = ColDialog.Color
    End Sub

    Private Sub lblAxisLabelColor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        XYAxislbl_color = ColDialog.Color
    End Sub

    Private Sub btnTitleFont_Click(sender As Object, e As EventArgs)
        Dim fntdlg As New FontDialog
        fntdlg.ShowColor = True
        If fntdlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntdlg.Font.Name & "," & fntdlg.Font.Size & "," & Font.Style.ToString & "," & fntdlg.Color.Name
            Title_Font = fntdlg.Font
            Title_Color = fntdlg.Color
        End If

    End Sub

    Private Sub btnxyAxislblFont_Click(sender As Object, e As EventArgs)
        Dim fntdlg As New FontDialog
        fntdlg.ShowColor = True
        If fntdlg.ShowDialog = DialogResult.OK Then
            'txtxyAxislblFont.Text = fntdlg.Font.Name & "," & fntdlg.Font.Size & "," & Font.Style.ToString & "," & fntdlg.Color.Name
            XYAxislbl_Font = fntdlg.Font
            XYAxislbl_color = fntdlg.Color
        End If
    End Sub

    Private Sub ckYAutoScale_CheckedChanged(sender As Object, e As EventArgs)
        If ckYAutoScale.Checked Then
            txtYFrom.Enabled = True
            txtYTo.Enabled = True
        Else
            txtYFrom.Enabled = False
            txtYTo.Enabled = False
        End If
    End Sub

    Private Sub btnTitleFont_Click_1(sender As Object, e As EventArgs) Handles btnTitleFont.Click
        Dim fntdlg As New FontDialog
        fntdlg.ShowColor = True
        If fntdlg.ShowDialog = DialogResult.OK Then
            txtTitleFont.Text = fntdlg.Font.Name & "," & fntdlg.Font.Size & "," & fntdlg.Font.Style.ToString() & "," & fntdlg.Color.Name
            Title_Color = fntdlg.Color
            Title_Font = fntdlg.Font
        End If
    End Sub

    Private Sub lbl_xytitleColor_MouseDoubleClick_1(sender As Object, e As MouseEventArgs) Handles lbl_xytitleColor.MouseDoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        sender.BackColor = ColDialog.Color
        xyTitle_Color = ColDialog.Color
    End Sub

    Private Sub cBoxChannelYValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxChannelValue.SelectedIndexChanged
        Try
            CboxTagscale.Items.Clear()
            Ser1_cBoxChannelY2Value.Items.Clear()
            Ser2_cBoxChannelY2Value.Items.Clear()
            Ser3_cBoxChannelY2Value.Items.Clear()
            Ser4_cBoxChannelY2Value.Items.Clear()
            Ser5_cBoxChannelY2Value.Items.Clear()
            Ser6_cBoxChannelY2Value.Items.Clear()
            Ser7_cBoxChannelY2Value.Items.Clear()
            Ser8_cBoxChannelY2Value.Items.Clear()

            Dim Dtcnt As Integer = 0
            Dim tabcnt As Integer = 0
            If MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Count > 0 Then
                DaTbl = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelValue.Text))
                Dtcnt = DaTbl.Columns.Count - 1
                tabcnt = tabMChartProp.TabPages.Count - 1

                Dim clmcnt As Integer = DaTbl.Columns.Count - 1
                If DaTbl.Columns.Count > 0 Then
                    For i As Integer = 1 To clmcnt
                        If RBtnValue.Checked = True Then
                            CboxTagscale.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser1_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser2_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser3_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser4_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser5_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser6_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser7_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser8_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                        Else
                            CboxTagscale.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser1_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser2_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser3_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser4_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser5_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser6_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser7_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                            Ser8_cBoxChannelY2Value.Items.Add(DaTbl.Columns(i).ColumnName)
                        End If

                    Next
                Else
                    MainPage._errLog.Add("Error@" & Now.ToString & "@" & "Tags not found" & "@ChannelValueSelect()")
                    MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
                End If

                If (Dtcnt > 0 And RBtnValue.Checked) Then
                    For j As Integer = Dtcnt - 1 To tabcnt
                        For a As Integer = 1 To Dtcnt - 1
                            tabMChartProp.TabPages(a).PageVisible = True
                        Next
                        tabMChartProp.TabPages(j).PageVisible = False

                    Next
                ElseIf (Dtcnt > 0 And Rbtntime.Checked) Then
                    For k As Integer = Dtcnt + 1 To tabcnt
                        For a As Integer = 1 To Dtcnt
                            tabMChartProp.TabPages(a).PageVisible = True
                        Next
                        tabMChartProp.TabPages(k).PageVisible = False
                    Next
                End If

                'If (Dtcnt > 0 And MainPage.MChart_Ctrl._xaxis <> "Time") Then
                '    For j As Integer = Dtcnt + 1 To tabcnt
                '        For a As Integer = 1 To Dtcnt - 1
                '            tabMChartProp.TabPages(a).PageVisible = True
                '        Next
                '        tabMChartProp.TabPages(j).PageVisible = False

                '    Next
                'ElseIf (Dtcnt > 0 And MainPage.MChart_Ctrl._xaxis = "Time") Then

                '    For k As Integer = Dtcnt To tabcnt
                '        For a As Integer = 1 To Dtcnt
                '            tabMChartProp.TabPages(a).PageVisible = True
                '        Next
                '        tabMChartProp.TabPages(k).PageVisible = False
                '    Next
                'End If
                'elseif mainpage.opcdachannelslist.opc_channel_name.contains(cboxchannelvalue.text) then
                '    dim indx as integer = mainpage.opcdachannelslist.opc_channel_name.indexof(cboxchannelvalue.text)
                '    if indx <> -1 then
                '        if mainpage.opcdachannelslist.opc_multiview(indx) then
                '            dim tags() as string = mainpage.opcdachannelslist.opc_opcitems(indx).split(",")
                '            for i as integer = 0 to tags.length - 1
                '                if rbtnvalue.checked = true then
                '                    select case i
                '                        case 0
                '                            cboxtagscale.items.add(tags(i))
                '                            cboxtagscale.datasource = tags
                '                        case 1
                '                            ser1_cboxchannely2value.items.add(tags(i))
                '                            ser1_cboxchannely2value.datasource = tags
                '                        case 2
                '                            ser2_cboxchannely2value.items.add(tags(i))
                '                            ser2_cboxchannely2value.datasource = tags
                '                        case 3
                '                            ser3_cboxchannely2value.items.add(tags(i))
                '                            ser3_cboxchannely2value.datasource = tags
                '                        case 4
                '                            ser4_cboxchannely2value.items.add(tags(i))
                '                            ser4_cboxchannely2value.datasource = tags
                '                        case 5
                '                            ser5_cboxchannely2value.items.add(tags(i))
                '                            ser5_cboxchannely2value.datasource = tags
                '                        case 6
                '                            ser6_cboxchannely2value.items.add(tags(i))
                '                            ser6_cboxchannely2value.datasource = tags
                '                        case 7
                '                            ser7_cboxchannely2value.items.add(tags(i))
                '                            ser7_cboxchannely2value.datasource = tags
                '                        case 8
                '                            ser8_cboxchannely2value.items.add(tags(i))
                '                            ser8_cboxchannely2value.datasource = tags
                '                    end select

                '                    tabmchartprop.tabpages(i).pagevisible = true


                '                else
                '                    select case i
                '                        case 0
                '                            cboxtagscale.items.add(tags(i))
                '                        case 1
                '                            ser1_cboxchannely2value.items.add(tags(i))
                '                        case 2
                '                            ser2_cboxchannely2value.items.add(tags(i))
                '                        case 3
                '                            ser3_cboxchannely2value.items.add(tags(i))
                '                        case 4
                '                            ser4_cboxchannely2value.items.add(tags(i))
                '                        case 5
                '                            ser5_cboxchannely2value.items.add(tags(i))
                '                        case 6
                '                            ser6_cboxchannely2value.items.add(tags(i))
                '                        case 7
                '                            ser7_cboxchannely2value.items.add(tags(i))
                '                        case 8
                '                            ser8_cboxchannely2value.items.add(tags(i))
                '                    end select

                '                    tabmchartprop.tabpages(i).pagevisible = true

                '                end if
                '            next
                '            for j as integer = tags.length to tabmchartprop.tabpages.count - 1
                '                tabmchartprop.tabpages(j).pagevisible = false
                '            next
                '        end if
                '    end if
            End If


            If _ListChart_Series.Item(0)._yExpression IsNot Nothing Then
                If cBoxChannelValue.Text = _ListChart_Series.Item(0)._yExpression Then
                    'For i As Integer = 0 To _ListChart_Series.Count - 1
                    '    If MainPage.MChart_Ctrl._xaxis <> "Time" Then
                    '        'CboxTagscale.Items.Add(MainPage.MChart_Ctrl._xaxis)
                    '        Ser1_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser2_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser3_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser4_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser5_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser6_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser7_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser8_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))

                    '    ElseIf MainPage.MChart_Ctrl._xaxis = "Time" Then
                    '        'CboxTagscale.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser1_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser2_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser3_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser4_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser5_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser6_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser7_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '        Ser8_cBoxChannelY2Value.Items.Add(MainPage.MChart_Ctrl.SeriesTags(i))
                    '    End If
                    'Next

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & Now)
        End Try


    End Sub

    Private Sub Ser1_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser1_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser1_lblColorMarker.BackColor = ColDialog.Color

    End Sub

    Private Sub Ser2_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser2_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser2_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser3_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser3_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser3_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser4_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser4_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser4_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser5_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser5_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser5_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser6_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser6_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser6_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser7_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser7_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser7_lblColorMarker.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser8_lblColorMarker_Click(sender As Object, e As EventArgs) Handles Ser8_lblColorMarker.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser8_lblColorMarker.BackColor = ColDialog.Color
    End Sub

    Private Sub lbl_xytitleColor_Click(sender As Object, e As EventArgs) Handles lbl_xytitleColor.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lbl_xytitleColor.BackColor = ColDialog.Color
    End Sub

    Private Sub lbl_ChartBackColor_Click(sender As Object, e As EventArgs) Handles lbl_ChartBackColor.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lbl_ChartBackColor.BackColor = ColDialog.Color
    End Sub

    Private Sub lbl_LegendColor_Click(sender As Object, e As EventArgs) Handles lbl_LegendColor.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lbl_LegendColor.BackColor = ColDialog.Color
    End Sub

    Private Sub lblAxisLabelColor_Click(sender As Object, e As EventArgs) Handles lblAxisLabelColor.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblAxisLabelColor.BackColor = ColDialog.Color
    End Sub

    Private Sub Ser1_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser1_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser1_lblColorSeries.BackColor = ColDialog.Color
    End Sub

    Private Sub Ser2_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser2_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser2_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser3_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser3_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser3_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser4_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser4_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser4_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser5_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser5_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser5_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser6_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser6_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser6_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser7_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser7_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser7_lblColorSeries.BackColor = ColDialog.Color
    End Sub
    Private Sub Ser8_lblColorSeries_Click(sender As Object, e As EventArgs) Handles Ser8_lblColorSeries.Click
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        Ser8_lblColorSeries.BackColor = ColDialog.Color
    End Sub



    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ViewConstantLine.InitNewRow

    End Sub

    Private Sub btnCLineAdd_Click(sender As Object, e As EventArgs)
        ViewConstantLine.AddNewRow()
    End Sub

    'Private Sub DGViewConstantLine_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If DGViewConstantLine.CurrentCell.ColumnIndex = 4 Then
    '        ColDialog.ShowDialog()
    '        ColDialog.FullOpen = False
    '        DGViewConstantLine.CurrentCell.Style.BackColor = ColDialog.Color
    '    End If
    'End Sub

    'Private Sub btnAddConstLine_Click(sender As Object, e As EventArgs)
    '    'Call setInitiateRow()
    '    DGViewConstantLine.Rows.Add()
    'End Sub


    'Private Sub btnDeleteConstLine_Click(sender As Object, e As EventArgs)

    '    For Each drow As DataGridViewRow In DGViewConstantLine.SelectedRows
    '        DGViewConstantLine.Rows.RemoveAt(drow.Index)
    '    Next

    'End Sub

    Public Function ProcAddProperties(ByVal seriesName As String, ByVal seriesColor As Integer, ByVal yExpression As String, ByVal viewType As String, ByVal markerStyle As String, ByVal markerSize As Integer,
                                         ByVal markercolor As Integer, ByVal axisLabelColor As Integer, ByVal axixLabelEnabled As Boolean) As MChartProperties
        'Public Function ProcAddProperties(ByVal seriesName As String, ByVal yExpression As String,
        '                             ByVal chartType As String, ByVal markerStyle As String, ByVal markerSize As Integer,
        '                             ByVal markercolor As Integer, ByVal axisLabelColor As Integer, ByVal axixLabelEnabled As Boolean) As MChartProperties

        Dim chartProp As New MChartProperties

        chartProp.SeriesName = seriesName
        'chartProp.TagName = tagName
        chartProp.SeriesColor = seriesColor
        chartProp.YExpression = yExpression
        chartProp.Viewtype = viewType
        chartProp.MarkerStyle = markerStyle
        chartProp.Markersize = markerSize
        chartProp.Markercolor = markercolor
        chartProp.AxisLabelColor = axisLabelColor
        chartProp.AxixLabelEnabled = axixLabelEnabled

        Return chartProp
    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub tabPage1_General_Paint(sender As Object, e As PaintEventArgs) Handles tabPage1_General.Paint

    End Sub

    Public Function ProcAddContantLine(ByVal linename, ByVal axis, ByVal axisvalue, ByVal color, ByVal visible)
        Dim chartCline As New ConstantLineProp
        chartCline.LineName = linename
        chartCline.Axis = axis
        chartCline.AxisValue = axisvalue
        chartCline.Color = color
        chartCline.Visible = visible

        Return chartCline
    End Function

End Class


