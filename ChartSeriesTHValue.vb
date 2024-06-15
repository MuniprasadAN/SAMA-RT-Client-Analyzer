Public Class ChartSeriesTHValue

    Public ThresholdValue As New List(Of String)
    Public THPointsColor As New List(Of String)

    Friend _TagName As String = vbNullString

    Public Property TagName() As String
        Get
            Return _TagName
        End Get
        Set(ByVal Value As String)
            _TagName = Value
        End Set
    End Property
End Class
Public Class MChartSeriesTHValue

    Public ThresholdValue As New List(Of String)
    Public THPointsColor As New List(Of String)

    Friend _TagName As String = vbNullString

    Public Property TagName() As String
        Get
            Return _TagName
        End Get
        Set(ByVal Value As String)
            _TagName = Value
        End Set
    End Property
End Class