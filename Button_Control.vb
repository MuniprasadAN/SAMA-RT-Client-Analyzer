Imports System
Imports System.ComponentModel


Public Class Button_Control
    Inherits Button
    Friend _timer As New System.Windows.Forms.Timer
    Friend _blink As Boolean
    Friend _backColor As Integer
    Friend _AudibleDeviceName As String
    Dim i As Integer = 0
    Private _Interval As Integer = 0

    Friend Action_Type As String = ""
    Friend Action_Ctrl As String = ""

    Friend almstate As String = "NA"
    Friend priority As Integer = 9999

    Public Sub New()
        AddHandler _timer.Tick, AddressOf Tick_Timer
        AddHandler Me.Invalidated, AddressOf Focus_Label
    End Sub

    Private Sub Focus_Label()

        If _blink Then
            _timer.Interval = _Interval
            _timer.Enabled = True
        Else
            _timer.Enabled = False
            _timer.Dispose()

            'Me.Visible = True
        End If
    End Sub

    Public Sub Tick_Timer()
        If i = 0 Then
            Me.BackColor = Color.Transparent
            i = 1
        Else
            Me.BackColor = Color.FromArgb(_backColor)
            i = 0
        End If
    End Sub

    <Category("Custom")>
    Public Property Blink() As Boolean
        Get
            Return Me._blink
        End Get
        Set(ByVal value As Boolean)
            Me._blink = value
            Me.Invalidate()
        End Set
    End Property

    Public Property _InterValTime() As String
        Get
            Return Me._Interval
        End Get
        Set(ByVal value As String)
            Me._Interval = value
        End Set
    End Property
End Class
