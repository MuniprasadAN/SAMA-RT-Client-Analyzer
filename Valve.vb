Imports System.ComponentModel
Imports System.Drawing.Drawing2D


Public Class Valve
      Inherits UserControl

   
    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)

   Private _label As Label

    Private D_backClr As  Color=Color.Black

    Private G_Color1 As Color = Color.Black
    Private G_Color2 As Color = Color.Snow

  
    

    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 2

   
     Private RF As RectangleF
    Public Enum Gradient_Type
        Vertical
        Horizontal
        diagonal
    End Enum

    Public Sub New()
      
        Me.Size = New Size(62, 82)
        Me.MinimumSize = New Size(20,20)
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

             Dim _brush As  LinearGradientBrush
            
               _brush = New LinearGradientBrush(Me.ClientRectangle, G_Color1, G_Color2, 90.0F, True)
         

            Dim _pen As New Pen(_brush, _LineSize)
            _brush.Blend = blend


            Dim xY As Integer=30
            Dim _RectWidth As Single = 10.0

            g.FillEllipse(_brush,cint((Me.Width/2)-20),5,xY+10,_RectWidth)
            g.DrawEllipse(_pen,cint((Me.Width/2)-20),5,xY+10,_RectWidth)

           

            g.FillRectangle(_brush, _LineSize, xY, Me.Width - _LineSize, CSng(Me.Height - (xY+10)))
            g.DrawRectangle(_pen, _LineSize, xY, Me.Width - _LineSize, CSng(Me.Height - (xY+10)))

            g.FillRectangle(_brush, 0, xY-10, _RectWidth, CSng(Me.Height -(2* _LineSize)))
            g.FillRectangle(_brush, CSng(Me.Width - (_RectWidth)), xY-10, _RectWidth, CSng(Me.Height - (_LineSize)))
            g.DrawRectangle(_pen,0, xY-10, _RectWidth, CSng(Me.Height -(2* _LineSize)))
            g.DrawRectangle(_pen, CSng(Me.Width - (_RectWidth)), xY-10, _RectWidth, CSng(Me.Height - (_LineSize)))


             _Pen=New Pen(_brush,_RectWidth)
            g.DrawLine(_pen,cint(Me.Width/2),5,cint(Me.Width/2),xY)

           Me._label.Location = New Point(((Me.Width / 2) - (Me._Label.Width) / 2),((Me.Height / 2 +10) - (Me._Label.Height) / 2))
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
