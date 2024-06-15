Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class LevelIndicator
    Inherits UserControl
    Private _levelcount As Integer = 5
    Private _scale As Boolean=True
    Private _rangestart As Single = 0.0
    Private _rangeend As Single = 250.0
    Private _Value As Single = 0.0


    Private _Active_Clr As Color = Color.Blue
    Private _inActive_Clr As Color = Color.Yellow
    Private _Grady_Clr As Color = Color.Snow

    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 2
    Public Sub New()


        Me.Size = New Size(64, 150)
        Me.MinimumSize = New Size(40,40)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
    End Sub



    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Me.Invalidate()
        'MyBase.OnResize(e)
    End Sub
    
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Try
          
            'MyBase.OnPaint(e)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            'Create a Blend object and assign it to linGrBrush. 
            Dim blend As New Blend()
            blend.Factors = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F, 0.8F, 0.6F, 0.4F, 0.2F, 0}
            blend.Positions = New Single() {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle, _Active_Clr,_Grady_Clr , 0.0F, False)

            _brush.Blend = blend

            Dim _pen As New Pen(_LineColor, _LineSize)
            Dim Br As New SolidBrush(Me.ForeColor)

            Dim range As Single
            Dim _stepVal As Single


            If _rangestart < 0 Then
                range = _rangeend + (-1 * _rangestart)
            Else
                range = _rangeend
            End If

            _stepVal = math.Round(range / _levelcount,2)



            Dim Big_Marker As Integer = ((Me.Width / 2) / 2)
            Dim Small_Marker As Integer = (((Me.Width / 2) / 2) / 2)

           

            g.DrawRectangle(_pen, 0, 0, Me.Width - (_LineSize), Me.Height - _LineSize) 'Outer Rect

            Dim Fill_Rec_y As Single

            Fill_Rec_y = Me.Height - (((Me.Height / range) * _Value))
            If _rangestart < 0 Then
                if _Value <0 Then
                    Fill_Rec_y = Me.Height - (((Me.Height / range) *( _Value+(-1*_rangestart))))
                Else
                    
                    Fill_Rec_y = Me.Height - (((Me.Height / range) *( _Value+(-1*_rangestart))))
                End If
            End If

            g.FillRectangle(_brush, _LineSize, Fill_Rec_y, Me.Width - (3 * _LineSize), Me.Height - (2 * _LineSize + Fill_Rec_y)) 'Fill




         


        If  _scale Then

            g.DrawLine(_pen, CInt(Me.Width / 2), _LineSize, CInt(Me.Width / 2), Me.Height - (2*_LineSize))
            If _rangestart < 0 Then
                 g.DrawString( _rangestart , New Font("verdana", 7), Br, 1, Me.Height - 15)
            Else
                g.DrawString(_rangestart, New Font("verdana", 7), Br, 1, Me.Height - 15)
            End If

            Dim linegap As Single = ((Me.Height - 8) / (_levelcount * 5))
            Dim Draw_bigMarker As Boolean = True
            Dim j As Integer = 0
            Dim k As Integer = 0
            For i As Integer = 0 To _levelcount * 5
                Dim y As Single = 2*_LineSize + (i * linegap)
              
                If Draw_bigMarker Then
                    If _rangestart < 0 Then
                        g.DrawString( (k * _stepVal) + (_rangestart), New Font("verdana", 7), Br, 1, Me.Height - (y+2))
                    Else
                        g.DrawString(k * _stepVal, New Font("verdana", 7), Br, 1, Me.Height - (y+2))
                    End If
                    g.DrawLine(_pen, CInt(Me.Width / 2 ), Me.Height - y, CInt(Me.Width / 2 + Big_Marker), Me.Height - (y))
                    Draw_bigMarker = False
                    k += 1

                Else
                    j += 1
                    g.DrawLine(_pen, CInt(Me.Width / 2 ), Me.Height - y, CInt(Me.Width / 2 + Small_Marker), Me.Height - y)
                End If
                If j = 4 Then
                    Draw_bigMarker = True
                    j = 0
                End If
            Next
        End If

           



            Me.BackColor =_inactive_clr
            _brush.Dispose()
            _pen.Dispose()       
            'g.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    <Category("Custom")> _
      Public Property GradianColor() As Color

        Get
            Return Me._Grady_Clr
        End Get

        Set(ByVal value As Color)
            Me._Grady_Clr = value
            Me.Invalidate()
        End Set
    End Property
        Public Property ActiveColor() As Color

        Get
            Return Me._Active_Clr
        End Get

        Set(ByVal value As Color)
            Me._Active_Clr = value
            Me.Invalidate()
        End Set
    End Property

    Public Property InActiveColor() As Color

        Get
            Return Me._inActive_Clr
        End Get

        Set(ByVal value As Color)
            Me._inActive_Clr = value
            Me.Invalidate()
        End Set
    End Property
    Public Property LevelsCount() As integer

        Get
            Return Me._levelcount
        End Get

        Set(ByVal value As integer)
            Me._levelcount = value
            Me.Invalidate()
        End Set
    End Property
    Public Property Scale_Enabled() As Boolean
        Get
            Return Me._scale
        End Get

        Set(ByVal value As Boolean)
            Me._scale = value
            Me.Invalidate()
        End Set
    End Property
    Public Property RangeStart() As Single
        Get
            Return Me._rangestart
        End Get

        Set(ByVal value As Single)
            Me._rangestart = value
            Me.Invalidate()
        End Set
    End Property
    Public Property RangeEnd() As Single
        Get
            Return Me._rangeend
        End Get

        Set(ByVal value As Single)
            Me._rangeend = value
            Me.Invalidate()
        End Set
    End Property
     Public Property Value() As Single
        Get
            Return Me._value
        End Get

        Set(ByVal value As Single)
            Me._value = value
            Me.Invalidate()
        End Set
    End Property
End Class
