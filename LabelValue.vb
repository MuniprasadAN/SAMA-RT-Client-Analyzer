Imports System.ComponentModel

Public Class LabelValue
    Inherits Label
    Public _ThresholdValue As New List(Of String)
    Public _THForeColor As New List(Of Integer)
    Public _THBackColor As New List(Of Integer)
    Public _Description As New List(of String)
    Public _THblink As New List(Of Boolean)
   
    
    Private _DefaultForeColor As Color=Color.Black
    Private _DefaultBackColor As Color
    Private _UnitVal As String=""
    Private _blink As Boolean
   
    Private _timer As New Timer
    Dim i As Integer=0
    Public Sub New()
        Me.Text = "Value: 0.0"
        Me.Font = New Font("Verdana", 12, FontStyle.Regular)
        Me.Tag = "displayValue"
        Me.Location = New Point(200, 250)

        AddHandler _timer.Tick ,AddressOf Tick_Timer
        AddHandler Me.Invalidated,AddressOf Focus_Label
    End Sub
     Private Sub Focus_Label
        
         If _blink Then
            _timer.Interval=200
            _timer.Enabled=True

        Else
            _timer.Enabled=False
            _timer.Dispose
            Me.Visible=True
        End If
    End Sub
    Private sub Tick_Timer()
        If i=0 then
           Me.Visible=False
            i=1
        Else
            Me.Visible=True
            i=0
        End If
        
    End Sub


    <Category("Custom")> _
     Public Property Blink() As Boolean
        Get
            Return Me._blink
        End Get
        Set(ByVal value As Boolean)
            Me._blink = value
            Me.Invalidate()
        End Set
    End Property
    
    Public Property UnitsValue() As string
        Get
            Return Me._UnitVal
        End Get
        Set(ByVal value As string)
            Me._UnitVal = value
        End Set
    End Property
     Public Property DefaultForeColors_() As Color
        Get
            Return Me._DefaultForeColor
        End Get
        Set(ByVal value As Color)
            Me._DefaultForeColor = value
        End Set
    End Property
    Public Property Default_BackColor() As Color
        Get
            Return Me._DefaultBackColor
        End Get
        Set(ByVal value As Color)
            Me._DefaultBackColor = value
        End Set
    End Property
End Class
