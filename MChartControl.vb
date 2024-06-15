'Imports System.Windows.Forms.DataVisualization.Charting
Imports chh = DevExpress.XtraCharts

Public Class MChartControl
    Inherits chh.ChartControl

    'Public _xaxis As String
    'Public SeriesTags As New List(Of String)
    'Friend MSeries_TH_Data As New List(Of MChartSeriesTHValue)

    Public gstrMCTitle, gstrMCTitleFont,
            gstrMCXAxisTitle, gstrMCYAxisTitle, gstrMCXYAxisTitleColor,
            gstrMCChartBackColor, gstrMCLegendEnable, gstrMCLegendColor,
            gstrMCAxisLabelEnable, gstrMCAxisLabelColor As String
    Public gstrMCActionChannel, gstrMCWritebackOpcServer As String
    Public gintMCUnits, gintMCTargetPower, gintMCSamples As Integer
    Public gsngPricePerUnit As Single

    Public gintTop, gintLeft, gintHeight, gintWidth As Integer

    Public gstrMCTagForLambda, gstrMCLambdaSeriesName, gstrMCLambdaSeriesColor As String

    Public glosMCTagForMan, glosMCTagForPLambda, glosMCTagForOpt,
                glosMCTagForMin, glosMCMinColor, glosMCTagForMax, glosMCMaxColor,
                glosMCSeriesName, glosMCSeriesColor,
                glosMCIntersectName, glosMCIntersectColor As New List(Of String)
    ',                glosMCActData 

    Public gdgvMORS, gdgvUnitValues As New DataGridView

    Public gintMCDgvCol0Width, gintMCDgvCol1Width, gintMCDgvCol2Width, gintMCDgvCol3Width As Integer
    Public gintMCDgvTop, gintMCDgvLeft, gintMCDgvWidth, gintMCDgvHeight As Integer
    Public gintMCDgvUnitTop, gintMCDgvUnitLeft, gintMCDgvUnitWidth, gintMCDgvUnitHeight,
            gintMCDgvUnitColWidth As Integer
    Public glosIntersectWidthHeightAngle As New List(Of String)

    'DynamicDataValues
    Public gsngLambdaX1, gsngLambdaY1, gsngLambdaX2, gsngLambdaY2 As Single

    'Public glogLoadScheduledUnitOptimalLoading, glogLoadScheduledUnitLoadingAtPresent,
    '            glogIFCUnitOptimalLoading, glogIFCUnitLoadingAtPresent As New List(Of Single)

    Public glogIntersectX1, glogIntersectY1,
                glogIntersectX2, glogIntersectY2 As New List(Of Single)
    Public gstrIntersectAnnotationData As String
    Public glogMinX1, glogMinY1, glogMinX2, glogMinY2 As New List(Of Single)
    Public glogMaxX1, glogMaxY1, glogMaxX2, glogMaxY2 As New List(Of Single)

    'Public gdtMCLiveData As New DataTable

End Class
