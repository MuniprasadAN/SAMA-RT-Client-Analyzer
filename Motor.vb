﻿Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Motor
    Inherits UserControl
    Private _label As Label
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   

    Private D_backClr As  Color=Color.Black
    Private G_Color1 As Color = Color.Black
    Private G_Color2 As Color = Color.WhiteSmoke

    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 2

    Private _Gradient_Type As Gradient_Type
     Private RF As RectangleF
    Public Enum Gradient_Type
        Vertical
        Horizontal
        diagonal
    End Enum

    Public Sub New()
        Me.MinimumSize = New Size(100, 100)
     
        Me.Size = New Size(300, 157)
        
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        'Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        RF = New RectangleF(0, 0, MyBase.Width, MyBase.Height)


        Me._label = New Label()
        Me._label .AutoSize=True
        Me._label.MaximumSize=New Size(Me.Width-_LineSize,0)
        Me._label.Location =  New Point(((Me.Width / 2) - (Me._Label.Width) / 2), Me.Height / 2)
        Me._label.Font=New Font("Verdana",8,FontStyle.Bold)
        Me.Controls.Add(Me._label)
    End Sub

 
    
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Me.Invalidate()
        RF.Size = New Size(me.Width, Me.Height)
    End Sub

     Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            'Me.Refresh()
            Return cp
        End Get
    End Property
    
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Try
          
            'MyBase.OnPaint(e)
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            'Create a Blend object and assign it to linGrBrush. 
            Dim blend As New Blend()
            blend.Factors = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F, 0.8F, 0.6F, 0.4F, 0.2F, 0}
            blend.Positions = New Single() {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 0.0F, False)
            _Gradient_Type=Gradient_Type.Horizontal
            Select Case _Gradient_Type
                Case Gradient_Type.Vertical
                    _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 0.0F, True)
                Case Gradient_Type.Horizontal
                    _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 90.0F, True)
                Case Gradient_Type.diagonal
                    _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 45.0F, True)

            End Select


            Dim _pen As New Pen(_brush, _LineSize)
            _brush.Blend = blend


            Dim Arc_height As Single = 50.0

            Dim Stnd_hight As Single = 30
            ' Create start and sweep angles on ellipse. 
            Dim UP_startAngle As Single = 90.0F
            Dim UP_sweepAngle As Single = 180.0F

            Dim Bott_startAngle As Single = -270.0F
            Dim Bott_sweepAngle As Single = -180.0F

            g.SmoothingMode = SmoothingMode.AntiAlias
            g.FillPie(_brush, _LineSize, _LineSize, 95, Me.Height - Stnd_hight, UP_startAngle, UP_sweepAngle)
            g.DrawPie(_pen, _LineSize, _LineSize, 95, Me.Height - Stnd_hight, UP_startAngle, UP_sweepAngle)

           
            
            g.FillPie(_brush, CSng(Me.Width - (2 * Arc_height)-6), _LineSize, 95, Me.Height - Stnd_hight, Bott_startAngle, Bott_sweepAngle)
            g.DrawPie(_pen, CSng(Me.Width - (2 * Arc_height) - 6), _LineSize, 95, Me.Height - Stnd_hight, Bott_startAngle, Bott_sweepAngle)
            g.FillRectangle(_brush, Arc_height, _LineSize, CSng(Me.Width - (2 * Arc_height)), CSng(Me.Height - Stnd_hight))
            g.DrawRectangle(_pen, Arc_height, _LineSize, CSng(Me.Width - (2 * Arc_height)), CSng(Me.Height - Stnd_hight))

          

            Dim point1 As New Point(Arc_height , Me.Height - (Stnd_hight - _LineSize))
            Dim point2 As New Point(_LineSize , Me.Height - _LineSize)
            Dim point3 As New Point(CSng(Me.Width - _LineSize), Me.Height - _LineSize)
            Dim point4 As New Point(CSng((Me.Width - (Arc_height ))), Me.Height - (Stnd_hight - _LineSize))


            Dim curvePoints As Point() = {point1, point2, point3, point4}
            g.FillPolygon(_brush, curvePoints)
            'g.DrawPolygon(_pen, curvePoints)
            _pen=new Pen( Color.Black,5)
             _pen.StartCap = LineCap.RoundAnchor

            g.DrawLine(_pen, Me.Width - 2, CSng((Me.Height - Stnd_hight) / 2), Me.Width - 10, CSng((Me.Height - Stnd_hight) / 2))




           Me._label.Location = New Point(((Me.Width / 2) - (Me._Label.Width) / 2),((Me.Height / 2) - (Me._Label.Height) / 2))
            Me._label.MaximumSize=New Size(Me.Width-_LineSize,0)
            Me._label.BackColor=Color.Transparent

            Me.BackColor=Color.Transparent
            _brush.Dispose()
            _pen.Dispose()       
            g.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    

    <Category("Custom")> _
    Public Property Description() As String


        Get
            Return Me._label.Text
        End Get

        Set(ByVal value As String)
            Me._label.Text = value
            Me.Invalidate()
        End Set
    End Property



    <Category("Custom")> _
   Public Property GradientStyle() As Gradient_Type
        Get
            Return _Gradient_Type
        End Get
        Set(ByVal Value As Gradient_Type)
            _Gradient_Type = Value
            Me.Invalidate()
        End Set
    End Property




    Public Property Gradient_Color1() As Color

        Get
            Return Me.G_Color1
        End Get

        Set(ByVal value As Color)
            Me.G_Color1 = value
            Me.Invalidate()
        End Set
    End Property

    Public Property Gradient_Color2() As Color

        Get
            Return Me.G_Color2
        End Get

        Set(ByVal value As Color)
            Me.G_Color2 = value
            Me.Invalidate()
        End Set
    End Property
    Public Property D_Color1() As Color

        Get
            Return Me.D_backClr
        End Get

        Set(ByVal value As Color)
            Me.D_backClr = value
            
            Me.Invalidate()
        End Set
    End Property
    Public Property PenSize() As Integer
        Get
            Return Me._LineSize
        End Get

        Set(ByVal value As Integer)
            Me._LineSize = value
            Me.Invalidate()
        End Set
    End Property
End Class