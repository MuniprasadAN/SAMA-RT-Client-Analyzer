Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class LineElbow
    Inherits UserControl
      
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   

    Private D_backClr As  Color=Color.Black
    
  
    Private G_Color1 As Color = Color.Black
    'Private G_Color2 As Color = color.Silver

    Private _LineSize As Integer = 7

   
    Private  _Cap As E_Caps
    Private _Cap_style As E_Capstyle

     public Enum E_Capstyle
        None
        Arrow
        Circle
    End Enum
    Public Enum E_Caps
        None
        StartCap
        EndCap
        Both
    End Enum
    Public Enum DirectionTypes

        Horizontal

        Vertical

        LeftBottom

        RightBottom

        RightBottomTriangle

        LeftBottomTriangle
    End Enum
Private RF As RectangleF
    Public Sub New()
        Me.Size = New Size(200, 12)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.components = New System.ComponentModel.Container()
        'Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        RF = New RectangleF(0, 0, MyBase.Width, MyBase.Height)
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
            Dim _brush As New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color1, 0.0F, False)

           

             Dim _pen As Pen
            _brush.Blend = blend
            
           If Me.Height>Me.Width Then
                _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color1, 0.0F, True)
                
            Else
                _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color1, 90.0F, True)
           End If

        _pen = New Pen(_brush, _LineSize)
        Dim path As New GraphicsPath()

        Dim w As Integer = Me.Width - _LineSize

        Select Case Me._Cap_style
                Case E_Capstyle.Arrow
                    Select Case Me._Cap
                        Case E_Caps.EndCap
                            _pen.EndCap=LineCap.ArrowAnchor
                        Case E_Caps.StartCap
                             _pen.StartCap=LineCap.ArrowAnchor
                        Case E_Caps.Both
                             _pen.EndCap=LineCap.ArrowAnchor
                             _pen.StartCap=LineCap.ArrowAnchor
                    End Select
                Case E_Capstyle.Circle
                    Select Case Me._Cap
                        Case E_Caps.EndCap
                            _pen.EndCap=LineCap.RoundAnchor
                        Case E_Caps.StartCap
                             _pen.StartCap=LineCap.RoundAnchor
                        Case E_Caps.Both
                             _pen.EndCap=LineCap.RoundAnchor
                             _pen.StartCap=LineCap.RoundAnchor
                    End Select
            End Select
        Select Case Me._directionType


            Case DirectionTypes.LeftBottom

                path.AddLine( New Point(w, 1), New Point(w, Me.Height / 2))

                path.AddLine(New Point(w, Me.Height / 2), New Point(_LineSize, Me.Height / 2))

                path.AddLine(New Point(_LineSize, Me.Height / 2), New Point(_LineSize, Me.Height-1))

                Exit Select

            Case DirectionTypes.RightBottom

                path.AddLine(New Point(_LineSize, 1), New Point(_LineSize, Me.Height / 2))

                path.AddLine(New Point(_LineSize, Me.Height / 2), New Point(w, Me.Height / 2))

                path.AddLine(New Point(w, Me.Height / 2), New Point(w, Me.Height-1))

                Exit Select

            Case DirectionTypes.RightBottomTriangle

                path.AddLine(New Point(1, _LineSize), New Point(w, _LineSize))

                path.AddLine(New Point(w, _LineSize), New Point(w, Me.Height-1))

                Exit Select
            Case DirectionTypes.LeftBottomTriangle

                path.AddLine( New Point(me.Width-_LineSize, _LineSize),New Point(_LineSize, _LineSize))

                path.AddLine(New Point(_LineSize, _LineSize), New Point(_LineSize, Me.Height-1))

                Exit Select
            Case DirectionTypes.Horizontal

               path.AddLine( New Point(me.Width-1, _LineSize),New Point(1, _LineSize))

                Exit Select
            Case DirectionTypes.Vertical

                     path.AddLine(New Point(_LineSize, 1), New Point(_LineSize, Me.Height-1))

                 
                Exit Select

        End Select



            g.DrawPath(_pen, path)

            Me.BackColor = Color.Transparent
            _brush.Dispose()
            _pen.Dispose()       
            g.Dispose()

        
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        
    End Sub

   
    <Category("Custom")> _
    Public Property Caps() As E_Caps
        Get
            return _Cap
        End Get
        Set(ByVal Value As E_Caps)
            _Cap=Value
            Me.Invalidate()
        End Set
    End Property
    
     <Category("Custom")> _
    Public Property CapStyle() as E_Capstyle
        Get
         Return _Cap_Style
        End Get
        Set(ByVal value As E_Capstyle)
            Me._Cap_style=value
            Me.Invalidate()
        End Set
    End Property

    Private _directionType As DirectionTypes




    <Category("Custom")> _
    Public Property DirectionType() As DirectionTypes
        Get
            Return Me._directionType
        End Get

        Set(ByVal value As DirectionTypes)

            Me._directionType = value
          
            Me.Invalidate
            If Not Me.Parent is Nothing Then
                Me.Parent.Invalidate
            End If
           
        End Set
    End Property


  
    Public Property Gradient_Color1() As Color

        Get
            Return Me.G_Color1
        End Get

        Set(ByVal value As Color)
           
            Me.G_Color1=value
            Me.Invalidate()
        End Set
    End Property

    'Public Property Gradient_Color2() As Color

    '    Get
    '        Return Me.G_Color2
    '    End Get

    '    Set(ByVal value As Color)

    '         Me.G_Color2=value
    '        Me.Invalidate()
    '    End Set
    'End Property
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
