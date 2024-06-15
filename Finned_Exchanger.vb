Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Finned_Exchanger
    Inherits UserControl
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)
    Private _label As Label
   

    Private D_backClr As  Color=Color.Black
    Private G_Color1 As Color = Color.Black
    Private G_Color2 As Color = Color.Black

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
        Me.MinimumSize = New Size(100, 80)
        Me.Size = New Size(321, 80)
        

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
            Dim Arc_height As Single = 50.0


            ' Create start and sweep angles on ellipse. 
            Dim UP_startAngle As Single = 90.0F
            Dim UP_sweepAngle As Single = 180.0F

            Dim Bott_startAngle As Single = -270.0F
            Dim Bott_sweepAngle As Single = -180.0F

            g.SmoothingMode = SmoothingMode.AntiAlias

            g.DrawArc(_pen, 1, CSng(Me.Height / 2), 95, CSng(Me.Height / 2 - 20), UP_startAngle, UP_sweepAngle) 'Left Arc

            g.DrawArc(_pen, CSng(Me.Width - (2 * Arc_height)), 20, 95, CSng(Me.Height / 2 - 20), Bott_startAngle, Bott_sweepAngle) 'Right arc

            g.DrawLine(_pen, 0, 20, Me.Width - 47, 20)
            g.DrawLine(_pen, 45, CSng(Me.Height / 2), Me.Width - 50, CSng(Me.Height / 2))
            g.DrawLine(_pen, 42, CSng(Me.Height - 20), Me.Width, CSng(Me.Height - 20))

            Dim N_Line As Integer =20
            Dim Stnd_hight As Single = (Me.Width - 50) / N_Line

            g.DrawLine(_pen, 25, 0, 25, Me.Height)
            For i As Integer = 1 To N_Line
                g.DrawLine(_pen, 25 + (i * Stnd_hight), 0, 25 + (i * Stnd_hight), Me.Height)
            Next


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
