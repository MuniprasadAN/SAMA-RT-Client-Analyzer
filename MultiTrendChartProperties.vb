Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Text

Public Class MultiTrendChartProperties
    Private ColDialog As New ColorDialog
    Friend _ListChart_Series As New List(Of ChartProperties)
    Friend _Title As String = ""

    Friend _XScaleMin As Integer
    Friend _XScaleMax As Integer
    Friend _YScaleMin As Integer
    Friend _YScaleMax As Integer

    Private slt_Idx As Integer ' = 0
    Friend Channel_Text As String = ""

    Friend Title_Font, XYAxislbl_Font As New Font("Verdana", 8, FontStyle.Regular)

    Friend Title_Color As Color = Color.Black
    Friend XYAxislbl_color As Color = Color.Black
    Friend Chart_BGColor As Color = Color.WhiteSmoke
    Friend Grid_Color As Color = Color.Silver

    Friend xyTitle_Color As Color = Color.Black
    Private bln3Dstyle As Boolean
    Dim DaTbl As New DataTable
    Private Sub cBoxChannelYValue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cBoxChannelYValue.SelectedIndexChanged
        CbxTags.Items.Clear()
        DaTbl = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelYValue.Text))
        DGViewSeriesColor.Rows.Clear()
        If cBoxChannelYValue.Text = _ListChart_Series.Item(0)._yExpression Then
            For i As Integer = 0 To _ListChart_Series.Count - 1
                Dim k = DGViewSeriesColor.Rows.Add
                DGViewSeriesColor.Rows(k).Cells(0).Value = _ListChart_Series.Item(i)._seriesName
                'DGViewSeriesColor.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(_ListChart_Series.Item(i)._seriesColor)
                CbxTags.Items.Add(_ListChart_Series.Item(i)._seriesName)
            Next
        Else
            Dim clmcnt As Integer = DaTbl.Columns.Count - 1
            For i As Integer = 1 To clmcnt
                Dim k = DGViewSeriesColor.Rows.Add
                DGViewSeriesColor.Rows(k).Cells(0).Value = DaTbl.Columns(i).ColumnName
                DGViewSeriesColor.Rows(k).Cells(1).Style.BackColor = Color.Green
                CbxTags.Items.Add(DaTbl.Columns(i).ColumnName)
            Next

        End If

    End Sub
    Private Sub Properties(ByVal TrendCtl As MultiTrendCtrl)
        Try
            _Title = TxtTitle.Text


            If TrendCtl.ChartControl1.ChartAreas(0).Area3DStyle.Enable3D = True Then
                bln3Dstyle = True
            End If
            If Not (Not txtYFrom.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYFrom.Text)) And Not (Not txtYFrom.Text Is Nothing AndAlso String.IsNullOrEmpty(txtYFrom.Text)) Then
                _YScaleMax = txtYTo.Text
                _YScaleMin = txtYFrom.Text
            Else
                MsgBox("Scalling could not be empty !!!")
                Exit Sub
            End If

            If TrendCtl.ChartControl1.Series.Count > 0 Then
                TrendCtl.ChartControl1.ResetAutoValues()
                TrendCtl.ChartControl1.ChartAreas.Clear()
                TrendCtl.ChartControl1.Series.Clear()
                TrendCtl.ChartControl1.ChartAreas.Add("ChartArea1")
            End If

            CboxChartType.SelectedIndex = CboxChartType.Items.IndexOf(_ListChart_Series.Item(0)._chartType)
            CboxMarkerStyle.SelectedIndex = CboxMarkerStyle.Items.IndexOf(_ListChart_Series.Item(0)._markerStyle)

            TrendCtl.ChartControl1.AccessibleDescription = cBoxChannelYValue.Text
            Dim DT As New DataTable
            DT = MainPage.SAMAHistorian_ChannelList.ChannelDatatable.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelYValue.Text))


            Dim clmcnt As Integer = DGViewSeriesColor.Rows.Count
            For i As Integer = 0 To clmcnt - 1
                TrendCtl.ChartControl1.Series.Add(DGViewSeriesColor.Rows(i).Cells(0).Value)
            Next

          

            TrendCtl.DataGridViewCtrl1.Rows.Clear()
            For j As Integer = 0 To TrendCtl.ChartControl1.Series.Count - 1
                Dim k = TrendCtl.DataGridViewCtrl1.Rows.Add
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("SerialNo").Value = j + 1
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("LowRange").Value = _YScaleMin
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("HighRange").Value = _YScaleMax
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("TagName").Value = DGViewSeriesColor.Rows(j).Cells(0).Value
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("PenColour").Style.BackColor = DGViewSeriesColor.Rows(j).Cells(1).Style.BackColor
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("IsActive").Value = True
                TrendCtl.DataGridViewCtrl1.Rows(j).Cells("TagValue").Value = DT.Rows(DT.Rows.Count - 2)(DGViewSeriesColor.Rows(j).Cells(0).Value)
                ' TrendCtl.DataGridViewCtrl1.Refresh()
                

                TrendCtl.ChartControl1.Series(j).Color = DGViewSeriesColor.Rows(j).Cells(1).Style.BackColor

                TrendCtl.ChartControl1.Series(j).MarkerColor = Color.FromArgb(_ListChart_Series.Item(0)._markercolor)
                TrendCtl.ChartControl1.Series(j).MarkerSize = _ListChart_Series.Item(0)._markerSize

                Select Case CboxChartType.Text
                    Case "Line"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Line
                    Case "Spline"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Spline
                    Case "Area"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Area
                    Case "SplineArea"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.SplineArea
                    Case "StackedArea"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedArea
                    Case "Bar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Bar
                    Case "StackedBar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedBar
                    Case "Column"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Column
                    Case "StackedColumn"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.StackedColumn
                    Case "Pie"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Pie
                    Case "Doughnut"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Doughnut
                    Case "Pyramid"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Pyramid
                    Case "Funnel"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Funnel
                    Case "Radar"
                        TrendCtl.ChartControl1.Series(j).ChartType = SeriesChartType.Radar
                End Select
                'chrartCtl.Series(0).ChartType = (CboxChartType.SelectedIndex)

                If CboxMarkerStyle.SelectedIndex <> 0 Then
                    TrendCtl.ChartControl1.Series(j).MarkerStyle = CboxMarkerStyle.SelectedIndex
                Else
                    TrendCtl.ChartControl1.Series(j).MarkerStyle = MarkerStyle.None
                End If
                If _ListChart_Series.Item(0).AxixLabelEnabled Then
                    TrendCtl.ChartControl1.Series(j).IsValueShownAsLabel = True
                Else
                    TrendCtl.ChartControl1.Series(j).IsValueShownAsLabel = False
                End If
                TrendCtl.ChartControl1.Series(j).LabelForeColor = Color.FromArgb(_ListChart_Series.Item(0)._axisLabelColor)
                TrendCtl.ChartControl1.Series(j).ToolTip = TrendCtl.ChartControl1.Series(j).Name & "," & txtYAxisTitle.Text & ": #VALY"         ' & txtXAxisTitle.Text & ": #VALX"

                ' TrendCtl.ChartControl1.Series(j).XValueType = ChartValueType.Time 'X value type
               
                TrendCtl.ChartControl1.Series(j).BorderWidth = 2


                TrendCtl.ChartControl1.Series(j).YValueMembers = _ListChart_Series.Item(0)._yExpression

                '  chrartCtl.Series(j).XValueMember = _ListChart_Series.Item(0)._xExpression

                TrendCtl.ChartControl1.Series(j).Font = New Font("Verdana", 8, FontStyle.Regular)

                'If j > 0 Then
                '    TrendCtl.ChartControl1.ChartAreas(0).AxisY2.Enabled = AxisEnabled.True
                '    TrendCtl.ChartControl1.Series(j).YAxisType = AxisType.Secondary

                'End If
            Next

            SAMAHistorianChannels.AssigntoControl(DT, cBoxChannelYValue.Text)




            If ckYAutoScale.Checked Then
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Tag = "True"
                TrendCtl.ChartControl1.ResetAutoValues()
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Maximum = Double.NaN
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Minimum = Double.NaN
                TrendCtl.ChartControl1.ResetAutoValues()

            Else
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Tag = "False"
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Maximum = _YScaleMax
                TrendCtl.ChartControl1.ChartAreas(0).AxisY.Minimum = _YScaleMin
            End If
            ' TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Format = "HH:mm:ss"
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Font = XYAxislbl_Font
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.Font = XYAxislbl_Font
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.ForeColor = XYAxislbl_color
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.LabelStyle.ForeColor = XYAxislbl_color

            'TrendCtl.ChartControl1.ChartAreas(0).AxisY.IsLogarithmic = True
            ' TrendCtl.ChartControl1.ChartAreas(0).AxisY.LogarithmBase = 10

            'TrendCtl.ChartControl1.ChartAreas(0).AxisX.LabelStyle.Angle = -45


            TrendCtl.ChartControl1.ChartAreas(0).AxisY.Title = txtYAxisTitle.Text
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.Title = txtXAxisTitle.Text
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleForeColor = xyTitle_Color
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleForeColor = xyTitle_Color
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.TitleFont = XYAxislbl_Font
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.TitleFont = XYAxislbl_Font

            If bln3Dstyle Then
                TrendCtl.ChartControl1.ChartAreas(0).Area3DStyle.Enable3D = True
            Else
                TrendCtl.ChartControl1.ChartAreas(0).Area3DStyle.Enable3D = False
            End If
            'chrartCtl.ChartAreas(0).AxisX.IsLabelAutoFit=False
            'chrartCtl.ChartAreas(0).AxisX.Interval = 2
            'chrartCtl.ChartAreas(0).AxisX.LabelStyle.IsStaggered=True
            'chrartCtl.ChartAreas(0).AxisX.LabelStyle.Angle=-45

            Chart_BGColor = lbl_ChartBackColor.BackColor
            Grid_Color = lbl_GridColor.BackColor

            TrendCtl.ChartControl1.ChartAreas(0).BackColor = Chart_BGColor
            TrendCtl.ChartControl1.BackColor = Chart_BGColor
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.MajorGrid.LineColor = Grid_Color
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.MajorGrid.LineColor = Grid_Color
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.MajorTickMark.LineColor = XYAxislbl_color
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.MajorTickMark.LineColor = XYAxislbl_color

            TrendCtl.ChartControl1.ChartAreas(0).Axes(0).LineColor = XYAxislbl_color
            TrendCtl.ChartControl1.ChartAreas(0).Axes(1).LineColor = XYAxislbl_color

            If TrendCtl.ChartControl1.Titles.Count > 0 Then
                TrendCtl.ChartControl1.Titles.Clear()
            End If


            TrendCtl.ChartControl1.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            TrendCtl.ChartControl1.ChartAreas(0).AxisX.ScaleView.Zoomable = True
            TrendCtl.ChartControl1.ChartAreas(0).AxisY.ScaleView.Zoomable = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorX.AutoScroll = True
            TrendCtl.ChartControl1.ChartAreas(0).CursorY.AutoScroll = True


            TrendCtl.ChartControl1.Titles.Add("")
            TrendCtl.ChartControl1.Titles(0).Text = _Title
            TrendCtl.ChartControl1.Titles(0).Alignment = ContentAlignment.MiddleCenter
            TrendCtl.ChartControl1.Titles(0).ForeColor = Title_Color
            TrendCtl.ChartControl1.Titles(0).Font = Title_Font
            If Not cBoxChartBorder.Text = "None" Then
                TrendCtl.ChartControl1.BorderSkin.PageColor = Color.Transparent
            End If
            Select Case cBoxChartBorder.Text
                Case "None"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.None

                Case "FrameThin1"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1
                Case "FrameThin2"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2
                Case "FrameThin3"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3
                Case "FrameThin4"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin4
                Case "FrameThin5"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin5
                Case "FrameThin6"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin6
                Case "FrameTitle1"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle1
                Case "FrameTitle2"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle2
                Case "FrameTitle3"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle3
                Case "FrameTitle4"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle4
                Case "FrameTitle5"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle5
                Case "FrameTitle6"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle6
                Case "FrameTitle7"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle7
                Case "FrameTitle8"
                    TrendCtl.ChartControl1.BorderSkin.SkinStyle = BorderSkinStyle.FrameTitle8


                Case Else
                    ' do the defalut action
            End Select


        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Chart-Properties()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub



    Private Sub ChartPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim installed_fonts As New InstalledFontCollection
        ' Get an array of the system's font familiies.
        '        Dim font_families() As FontFamily = installed_fonts.Families() ' COMMENTED BY CODEIT.RIGHT
        'CboxChartType.Items.Clear()
        'CboxChartType.Items.AddRange([Enum].GetNames(GetType(SeriesChartType)))
        Try

            cBoxChannelYValue.Items.Clear()

            For i As Integer = 0 To MainPage.SAMAHistorian_ChannelList.ChannelReportname.Count - 1
                cBoxChannelYValue.Items.Add(MainPage.SAMAHistorian_ChannelList.ChannelReportname.Item(i))
            Next

            txtTitleFont.Text = Title_Font.Name & "," & Title_Font.Size & "," & Title_Font.Style.ToString & "," & Title_Color.Name
            txtxyAxislblFont.Text = XYAxislbl_Font.Name & "," & XYAxislbl_Font.Size & "," & XYAxislbl_Font.Style.ToString & "," & XYAxislbl_color.Name

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
        If MainPage.SAMAHistorian_ChannelList.ChannelXAxis.Item(MainPage.SAMAHistorian_ChannelList.ChannelReportname.IndexOf(cBoxChannelYValue.Text)) = "Time" Then
            MsgBox("The Chart Cannot be Displayed")
        Else
            Call Add_Properties()
            Call Properties(MainPage.Trender_Ctrl)

        End If
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
   
    Private Sub Add_Properties()
        Try

            Dim lblAxixlabel As Boolean
            If CKBoxAxixlabel.Checked Then
                lblAxixlabel = True
            Else
                lblAxixlabel = False
            End If


            If Rbtntime.Checked Then
                MainPage.Trender_Ctrl.xaxis = "Time"
            ElseIf RBtnValue.Checked Then
                MainPage.Trender_Ctrl.xaxis = CbxTags.Text
            End If

            _ListChart_Series.Clear()
            For i As Integer = 0 To DGViewSeriesColor.Rows.Count - 1
                Dim prop As New ChartProperties
                prop = ProcAddProperties(DGViewSeriesColor.Rows(i).Cells(0).Value, cBoxChannelYValue.Text _
    , DGViewSeriesColor.Rows(i).Cells(1).Style.BackColor.ToArgb, CboxChartType.Text, CboxMarkerStyle.Text, cboxMarkerValue.Text _
    , lblColorMarker.BackColor.ToArgb, lblAxisLabelColor.BackColor.ToArgb, lblAxixlabel)

                _ListChart_Series.Add(prop)
            Next


        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@btnUpdate_Click()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub


    Public Function ProcAddProperties(ByVal seriesName As String, ByVal yExpression As String, ByVal seriesColor As Integer, _
                                         ByVal chartType As String, ByVal markerStyle As String, ByVal markerSize As Integer, _
                                         ByVal markercolor As Integer, ByVal axisLabelColor As Integer, ByVal axixLabelEnabled As Boolean) As ChartProperties

        Dim chartProp As New ChartProperties

        chartProp.SeriesName = seriesName
        chartProp.YExpression = yExpression
        ' chartProp.SeriesColor = seriesColor
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

            ' txtSeriesName.Text = _ListChart_Series.Item(idx)._seriesName
            cBoxChannelYValue.Text = _ListChart_Series.Item(idx)._yExpression
            ' lblColorTrace.BackColor = Color.FromArgb(_ListChart_Series.Item(idx)._seriesColor)
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

            If MainPage.Trender_Ctrl.xaxis = "Time" Then
                Rbtntime.Checked = True
                Label2.Visible = False
                CbxTags.Visible = False
            Else
                RBtnValue.Checked = True
                Label2.Visible = True
                CbxTags.Visible = True
            End If
            

            DGViewSeriesColor.Rows.Clear()
            CbxTags.Items.Clear()
            For i As Integer = 0 To _ListChart_Series.Count - 1
                Dim k = DGViewSeriesColor.Rows.Add
                DGViewSeriesColor.Rows(k).Cells(0).Value = _ListChart_Series.Item(i)._seriesName
                ' DGViewSeriesColor.Rows(k).Cells(1).Style.BackColor = Color.FromArgb(_ListChart_Series.Item(i)._seriesColor)
                CbxTags.Items.Add(_ListChart_Series.Item(i)._seriesName)
            Next

            If MainPage.Trender_Ctrl.xaxis <> "Time" Then
                CbxTags.Text = MainPage.Trender_Ctrl.xaxis
            End If
          


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




    Private Sub DGViewSeriesColor_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGViewSeriesColor.CellDoubleClick
        If DGViewSeriesColor.CurrentCell.ColumnIndex = 1 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            DGViewSeriesColor.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub

    Private Sub llblInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblInfo.LinkClicked
        ChartInfo.ShowDialog()
    End Sub


    Private Sub Rbtntime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtntime.CheckedChanged
        If Rbtntime.Checked Then
            Label2.Visible = False
            CbxTags.Visible = False
        End If
    End Sub

    Private Sub RBtnValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBtnValue.CheckedChanged
        If RBtnValue.Checked Then
            Label2.Visible = True
            CbxTags.Visible = True
        End If
    End Sub
End Class