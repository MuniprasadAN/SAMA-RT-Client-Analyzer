﻿Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Cooling_Tower
    Inherits UserControl
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   

    Private D_backClr As  Color=Color.Black
    Private _label As Label
    Private G_Color1 As Color = Color.Black
    Private G_Color2 As Color = Color.Snow

    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 2

    Private _Gradient_Type As Gradient_Type
     Private RF As RectangleF
    Public Enum Gradient_Type
        Vertical
        Horizontal
        diagonal
    End Enum
    Friend Sub New()
        Me.Size = New Size(212, 132)
        
        Me.MinimumSize = New Size(100, 100)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.components = New System.ComponentModel.Container()
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
            ' Create pen. 
            Dim Arc_height As Integer=40
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            'Create a Blend object and assign it to linGrBrush. 
            Dim blend As New Blend()
            blend.Factors = New Single() {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F, 0.8F, 0.6F, 0.4F, 0.2F, 0}
            blend.Positions = New Single() {0.0F, 0.1F, 0.2F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 0.9F, 1.0F}
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 0.0F, False)

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



            Dim wd As Single = Me.Width /2
            Dim ht As Single = Me.Height/2 
            ' Create points that define polygon. 
            Dim point1 As New Point(1, Me.Height - (Arc_height/2))

            Dim point2 As New Point(CSng(Me.Width - _LineSize), Me.Height - (Arc_height/2))
            
            Dim point3 As New Point(CSng((wd) + wd / 2), CSng(ht - (ht / 2)))

            Dim point4 As New Point(CSng((wd) + wd / 2), csng(Arc_height/2))

            Dim point5 As New Point(CSng((wd) - wd / 2), csng(Arc_height/2))

            Dim point6 As New Point(CSng((wd) - wd / 2),  CSng(ht - (ht / 2)))

           


            Dim curvePoints As Point() = {point1, point2, point3, point4, point5, point6, point1}

            ' Draw polygon to screen.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            e.Graphics.FillPolygon(_brush, curvePoints)
            e.Graphics.DrawPolygon(_pen, curvePoints)

            'Bottom
            g.FillEllipse(_brush, _LineSize,CSng(Me.Height-(Arc_height)), Me.Width - (2*_LineSize),Arc_height-_LineSize)
            
            _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,45.0f,true )

            'Top
            g.DrawEllipse(_Pen, CSng(wd -( wd / 2)), _LineSize, Me.Width - (2* CSng(wd -( wd / 2))),30-_LineSize)
            g.FillEllipse(_brush, CSng(wd -( wd / 2)), _LineSize, Me.Width - (2* CSng(wd -( wd / 2))),30-_LineSize)

            Me._label.Location = New Point(((Me.Width / 2) - (Me._Label.Width) / 2),((Me.Height / 2) - (Me._Label.Height) / 2))
            Me._label.MaximumSize=New Size(Me.Width-_LineSize,0)
            Me._label.BackColor=Color.Transparent

            Me.BackColor = Color.Transparent
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
