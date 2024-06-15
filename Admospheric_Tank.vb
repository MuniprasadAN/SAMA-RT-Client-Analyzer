Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Admospheric_Tank
    Inherits UserControl
    Public Type As String="symbols"
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   

    Private D_backClr As  Color=Color.Black

    Private _label As New Label
    
    Private G_Color1 As Color=Color.Black
    Private G_Color2 as color=Color.Snow

    
    Private _LineSize As Integer = 2

    Private _Gradient_Type As Gradient_Type

    Private RF As RectangleF
 
    ''' <summary>
    ''' Enumaration for Gradiant style
    ''' </summary>
    ''' <remarks></remarks>
    public Enum Gradient_Type
        Vertical
        Horizontal
        diagonal
    End Enum
    ''' <summary>
    ''' Constructor to initialize the variable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.Size = New Size(120,180)
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
            Dim Rect_Height As Single=(Me.Height/2-70)
            Dim Arc_Height As Single=70
            If Arc_Height<=_LineSize Then
                Arc_Height=_LineSize
            End If
            
          


            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            'Create a Blend object and assign it to linGrBrush. 
            Dim blend As New Blend()'blend gives the effect of combining two color
            blend.Factors = new single(){0.0f,0.2f,0.4f,0.6f,0.8f,1.0f,0.8f,0.6f,0.4f,0.2f,0}
            blend.Positions = new Single() {0.0f,0.1f,0.2f,0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f,1.0f}
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2,90.0f,False )'gives gradian color
            _Gradient_Type=Gradient_Type.Horizontal
            Select Case _Gradient_Type
                Case Gradient_Type.Vertical
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,0.0f,true )
                Case Gradient_Type.Horizontal
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,90.0f,true )
                Case Gradient_Type.diagonal
                    _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,45.0f,true )

            End Select
           
           
            Dim _pen As New Pen(_brush,10)
            _brush.Blend = blend
            
             
           
           
           
           
            g.DrawLine(_pen, 10,Me.Height-50 ,10,Me.Height)'Left Vertical Line
            g.DrawLine(_pen, CSng(Me.Width-10),Me.Height-50 ,CSng(Me.Width-10),Me.Height)'Right Vertival Line

            g.DrawLine(_pen, 0, Me.Height-2, 20, Me.Height-2) 'Bottom Horizontal Line
            g.DrawLine(_pen, Me.Width, Me.Height-2, Me.Width-20, Me.Height-2) 'Bottom Horizontal Line
            _brush.Dispose()
            _brush=New LinearGradientBrush( Me.ClientRectangle,G_Color1, G_Color2,0.0f,true )
            g.FillEllipse(_brush,_LineSize, _LineSize, Me.Width -(2*_LineSize) ,Arc_Height)
            g.FillEllipse(_brush, _LineSize,CSng(Me.Height-(Arc_Height+15)), Me.Width - (2*_LineSize),Arc_height-_LineSize)
            
            g.FillRectangle(_brush, _LineSize, Arc_Height/2, CSng(Me.Width-(2*_LineSize)), CSng(Me.Height - (Arc_height+15)))
       

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

'--------- Properties---------------------

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
    Public Property  GradientStyle() As Gradient_Type
        Get
            return _Gradient_Type
        End Get
        Set(ByVal Value As Gradient_Type)
            _Gradient_Type=Value
            Me.Invalidate()
        End Set
    End Property

      Public Property Gradient_Color1() As  color

        Get
            Return Me.G_Color1
        End Get

        Set(ByVal value As Color)
            Me.G_Color1 = value
            Me.Invalidate()
        End Set
    End Property

       Public Property Gradient_Color2() As  color

        Get
            Return Me.G_Color2
        End Get

        Set(ByVal value As Color)
            Me.G_Color2 = value
            Me.Invalidate()
        End Set
    End Property

      Public Property PenSize() As integer
        Get
            Return Me._LineSize
        End Get

        Set(ByVal value As integer)
            Me._LineSize = value
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
    'Public Property PenColor() As color
    '    Get
    '        Return Me._LineColor
    '    End Get

    '    Set(ByVal value As color)
    '        Me._LineColor = value
    '        Me.Invalidate()
    '    End Set
    'End Property
End Class
