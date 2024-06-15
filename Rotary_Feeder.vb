Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Rotary_Feeder
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
        Vertical
        Horizontal
        diagonal
    End Enum
    Public Sub New()
        Me.Size = New Size(285, 167)
        
        Me.MinimumSize = New Size(100, 50)

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
            blend.Factors = new single(){0.0f,0.2f,0.4f,0.6f,0.8f,1.0f,0.8f,0.6f,0.4f,0.2f,0}
            blend.Positions = new Single() {0.0f,0.1f,0.2f,0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f,1.0f}
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle,G_Color1, G_Color2,0.0f,False )

            Select Case _Gradient_Type
                Case Gradient_Type.Vertical
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,0.0f,true )
                Case Gradient_Type.Horizontal
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,90.0f,true )
                Case Gradient_Type.diagonal
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,45.0f,true )
               
            End Select
           
           
            Dim _pen As New Pen(_brush,_LineSize)
            _brush.Blend = blend


           
            g.FillPolygon(_brush ,New point(){new Point(_LineSize, Me.Height-_LineSize),New Point(30, Me.Height-38),New Point( Me.Width - _LineSize,  Me.Height-40),New Point(Me.Width - 20, Me.Height-3)})
           

            g.FillEllipse(_brush, _LineSize, _LineSize, CSng(Me.Width - (2*_LineSize)), CSng(Me.Height - 30))
            
            g.DrawEllipse(_pen, _LineSize, _LineSize, CSng(Me.Width - (2*_LineSize)), CSng(Me.Height - 30))

            

           

           Dim xy As Integer=20
            Dim wd As Integer=Me.Width-(2* xy)
            Dim ht As Integer=Me.Height-(3* xy)

           
             _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 15.0F, True)
             
            'For jj As Integer = 1 To 15
            '    g.FillPie(_Brush, xy, xy, wd, ht, 180,(jj) * 30)
            'Next
             For jj As Integer = 1 To 15
                g.DrawPie(_pen, xy, xy, wd, ht, 180, (jj) * 30)
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
