﻿Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Inline_Mixer
    Inherits UserControl
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   
    Private _label As Label

    Private D_backClr As  Color=Color.Black
    Private G_Color1 As Color = Color.Black
    Private G_Color2 As Color = Color.WhiteSmoke

    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 2

    Private _Gradient_Type As Gradient_Type
     Private RF As RectangleF
    Public Enum Gradient_Type
        Horizontal
        Vertical
        diagonal
    End Enum
    Public Sub New()
        Me.Size = New Size(150, 30)
        Me.MinimumSize = New Size(40,40)
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
            Dim arc_size As Integer = 20
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

            g.FillRectangle(_brush, CSng(arc_size / 2), _LineSize, CSng(Me.Width - (arc_size)), CSng(Me.Height))
            _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 15.0F, True)
            g.FillEllipse(_brush, _LineSize, _LineSize, arc_size, Me.Height - _LineSize)
            g.DrawEllipse(_pen, _LineSize, _LineSize, arc_size, Me.Height - _LineSize)

            g.FillEllipse(_brush, CSng(Me.Width - (arc_size + 5)), _LineSize, arc_size, Me.Height - _LineSize)
            g.DrawEllipse(_pen, CSng(Me.Width - (arc_size + 5)), _LineSize, arc_size, Me.Height - _LineSize)

            Dim slice As Single = (Me.Width - 60) / 10

            Dim point1 As New Point(30, _LineSize+5)
            Dim point2 As New Point(30 + slice, Me.Height -  _LineSize+5)
            Dim point3 As New Point((30 + (2 * slice)),  _LineSize+5)
            Dim point4 As New Point((30 + (3 * slice)), Me.Height -  _LineSize+5)
            Dim point5 As New Point((30 + (4 * slice)),  _LineSize+5)
            Dim point6 As New Point((30 + (5 * slice)), Me.Height -  _LineSize+5)
            Dim point7 As New Point((30 + (6 * slice)),  _LineSize+5)
            Dim point8 As New Point((30 + (7 * slice)), Me.Height -  _LineSize+5)
            Dim point9 As New Point((30 + (8 * slice)), _LineSize+5)
            Dim point10 As New Point((30 + (9 * slice)), Me.Height -  _LineSize+5)
            Dim point11 As New Point(CSng(Me.Width - (arc_size+5)),  _LineSize+5)

            Dim curvePoints As Point() = {point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11}
            _pen = New Pen(_brush, _LineSize+1)
            g.FillPolygon(_brush, curvePoints)
            g.DrawPolygon(_pen, curvePoints)



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