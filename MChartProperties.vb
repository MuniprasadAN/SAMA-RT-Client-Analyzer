Imports System.ComponentModel
Public Class MChartProperties
    Friend MChart_Series_Properties As New List(Of MChartSeriesProperties)
    Friend Constant_Lines As New BindingList(Of ConstantLineProp)
    Friend Static_Series As New BindingList(Of StaticSeries)

    Friend _seriesName As String = vbNullString
    Public Property SeriesName() As String
        Get
            Return _seriesName
        End Get
        Set(ByVal Value As String)
            _seriesName = Value
        End Set
    End Property

    'Friend _TagName As String = vbNullString

    'Public Property TagName() As String
    '    Get
    '        Return _TagName
    '    End Get
    '    Set(ByVal Value As String)
    '        _TagName = Value
    '    End Set
    'End Property
    Friend _seriesColor
    Public Property SeriesColor() As Integer
        Get
            Return _seriesColor
        End Get
        Set(ByVal Value As Integer)
            _seriesColor = Value
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
    Friend _viewtype As String = vbNullString
    Public Property Viewtype() As String
        Get
            Return _viewtype
        End Get
        Set(ByVal Value As String)
            _viewtype = Value
        End Set
    End Property

    Friend _markerstyle As String = vbNullString
    Public Property MarkerStyle() As String
        Get
            Return _markerstyle
        End Get
        Set(ByVal Value As String)
            _markerstyle = Value
        End Set
    End Property
    Friend _markersize As String = vbNullString
    Public Property Markersize() As String
        Get
            Return _markersize
        End Get
        Set(ByVal Value As String)
            _markersize = Value
        End Set
    End Property
    Friend _markercolor
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


Public Class MChartSeriesProperties

    Friend _constlinename As String = vbNullString

    Public Property ConstLineName() As String
        Get
            Return _constlinename
        End Get
        Set(ByVal Value As String)
            _constlinename = Value
        End Set
    End Property

    Friend _constlineaxis As String = vbNullString

    Public Property ConstLineAxis() As String
        Get
            Return _constlineaxis
        End Get
        Set(ByVal Value As String)
            _constlineaxis = Value
        End Set
    End Property

    Friend _constlineaxisvalue As String = vbNullString
    Public Property ConstLineAxisValue() As String
        Get
            Return _constlineaxisvalue
        End Get
        Set(ByVal Value As String)
            _constlineaxisvalue = Value
        End Set
    End Property

    Friend _constlinecolor As String = vbNullString
    Public Property ConstLineColor() As String
        Get
            Return _constlinecolor
        End Get
        Set(ByVal Value As String)
            _constlinecolor = Value
        End Set
    End Property

    Friend _constlineenabled As Boolean
    Public Property ConstLineEnabled() As Boolean
        Get
            Return _constlineenabled
        End Get
        Set(ByVal Value As Boolean)
            _constlineenabled = Value
        End Set
    End Property


End Class

Public Class ConstantLineProp
    Friend _linename As String
    Public Property LineName() As String
        Get
            Return _linename
        End Get
        Set(value As String)
            _linename = value
        End Set
    End Property
    Friend _axis As String
    Public Property Axis() As String
        Get
            Return _axis
        End Get
        Set(value As String)
            _axis = value
        End Set
    End Property
    Friend _axisval As Integer
    Public Property AxisValue() As Integer
        Get
            Return _axisval
        End Get
        Set(value As Integer)
            _axisval = value
        End Set
    End Property
    Friend _color As Integer
    Public Property Color() As Integer
        Get
            Return _color
        End Get
        Set(value As Integer)
            _color = value
        End Set
    End Property

    Friend _visible As Boolean
    Public Property Visible() As Boolean
        Get
            Return _visible
        End Get
        Set(value As Boolean)
            _visible = value
        End Set
    End Property
End Class

Public Class StaticSeries
    Friend _seriesname As String
    Public Property SeriesName() As String
        Get
            Return _seriesname
        End Get
        Set(value As String)
            _seriesname = value
        End Set
    End Property
    Friend _pointXval As String
    Public Property PointXVal() As String
        Get
            Return _pointXval
        End Get
        Set(value As String)
            _pointXval = value
        End Set
    End Property
    Friend _pointYval As String
    Public Property PointYVal() As String
        Get
            Return _pointYval
        End Get
        Set(value As String)
            _pointYval = value
        End Set
    End Property
    Friend _seriescolor As String
    Public Property SeriesColor() As String
        Get
            Return _seriescolor
        End Get
        Set(value As String)
            _seriescolor = value
        End Set
    End Property

    Friend _marker As String
    Public Property Maker() As String
        Get
            Return _marker
        End Get
        Set(value As String)
            _marker = value
        End Set
    End Property
End Class

