Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Text

Public Class ChartProperties
    '  Friend _ThresholdValue As New List(Of String)
    ' Friend _THPointsColor As New List(Of String)
    Friend Chart_Series_Properties As New List(Of ChartSeriesProperties)

    Friend _seriesName As String = vbNullString
    Public Property SeriesName() As String
        Get
            Return _seriesName
        End Get
        Set(ByVal Value As String)
            _seriesName = Value
        End Set
    End Property
    Friend _yExpression As String = vbNullString

    Public Property YExpression() As String
        Get
            Return _yExpression
        End Get
        Set(ByVal Value As String)
            _yExpression = Value
        End Set
    End Property
    Friend _xExpression As String = vbNullString
    Public Property XExpression() As String
        Get
            Return _xExpression
        End Get
        Set(ByVal Value As String)
            _xExpression = Value
        End Set
    End Property
    'Friend _seriesColor As Integer

    'Public Property SeriesColor() As Integer
    '    Get
    '        Return _seriesColor
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _seriesColor = Value
    '    End Set
    'End Property
    Friend _chartType As String = vbNullString

    Public Property ChartType() As String
        Get
            Return _chartType
        End Get
        Set(ByVal Value As String)
            _chartType = Value
        End Set
    End Property
    Friend _markerStyle As String = vbNullString

    Public Property MarkerStyle() As String
        Get
            Return _markerStyle
        End Get
        Set(ByVal Value As String)
            _markerStyle = Value
        End Set
    End Property
    Friend _markerSize As Integer

    Public Property MarkerSize() As Integer
        Get
            Return _markerSize
        End Get
        Set(ByVal Value As Integer)
            _markerSize = Value
        End Set
    End Property ' = 0

    Friend _markercolor As Integer

    Public Property Markercolor() As Integer
        Get
            Return _markercolor
        End Get
        Set(ByVal Value As Integer)
            _markercolor = Value
        End Set
    End Property
    Friend _axisLabelColor As Integer

    Public Property AxisLabelColor() As Integer
        Get
            Return _axisLabelColor
        End Get
        Set(ByVal Value As Integer)
            _axisLabelColor = Value
        End Set
    End Property

    Friend _axixLabelEnabled As Boolean

    Public Property AxixLabelEnabled() As Boolean
        Get
            Return _axixLabelEnabled
        End Get
        Set(ByVal Value As Boolean)
            _axixLabelEnabled = Value
        End Set
    End Property


End Class

Public Class ChartSeriesProperties
    Friend _ThresholdValue As New List(Of String)
    Friend _THPointsColor As New List(Of String)


    Friend _TagName As String = vbNullString

    Public Property TagName() As String
        Get
            Return _TagName
        End Get
        Set(ByVal Value As String)
            _TagName = Value
        End Set
    End Property


    Friend _seriesColor As Integer
    Public Property SeriesColor() As Integer
        Get
            Return _seriesColor
        End Get
        Set(ByVal Value As Integer)
            _seriesColor = Value
        End Set
    End Property
End Class