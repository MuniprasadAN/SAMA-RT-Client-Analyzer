Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class ManualContactor
    Inherits UserControl

    Public _ThresholdValue As New List(Of String)
    Public _THCondition As New List(Of string)
    Public _THColor As New List(Of Integer)
    Public _THState As New List(Of String)


    Private D_backClr As  Color=Color.Black

    Private _switchopen As Boolean=True
   
    Private _LineColor As Color = Color.Black
    Private _LineSize As Integer = 5
    Private RF As RectangleF
    Private _State As StateIND
     Public Enum StateIND
        Closed
        Open
    End Enum
  
  
    Public Sub New()
        
        Me.Size = New Size(211, 34)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.Opaque, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
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
           
           
           
            Dim _pen As New Pen(_LineColor,_LineSize)
           

         

            ' Draw arc to screen.
            g.SmoothingMode = SmoothingMode.AntiAlias
            _pen.EndCap = LineCap.RoundAnchor
           

             Select Case _State
                Case StateIND.Open
                     
                    g.DrawLine(_pen, (CSng(Me.Width / 2) - 30), CSng((Me.Height)-_LineSize), (CSng(Me.Width / 2) + 30), CSng(Me.Height-30))
                    g.DrawLine(_pen, 0, CSng(Me.Height-_LineSize ), (CSng(Me.Width / 2) - 30), CSng(Me.Height-_LineSize ))
                    g.DrawLine(_pen, Me.Width, CSng(Me.Height-_LineSize), (CSng(Me.Width / 2) + 30), CSng(Me.Height-_LineSize))
                Case StateIND.Closed
                    g.DrawLine(_pen, (CSng(Me.Width / 2) - 30), CSng(Me.Height-_LineSize), (CSng(Me.Width / 2) +30), CSng(Me.Height-_LineSize ))
                
                    g.DrawLine(_pen, 0, CSng(Me.Height-_LineSize), (CSng(Me.Width / 2) - 30), CSng(Me.Height -_LineSize))
                    g.DrawLine(_pen, Me.Width, CSng(Me.Height-_LineSize), (CSng(Me.Width / 2) + 30), CSng(Me.Height-_LineSize ))
            End Select
          
           Me.BackColor=Color.Transparent
      
            _pen.Dispose()       
            g.Dispose()
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

     Public Property PenSize() As Integer
        Get
            Return Me._LineSize
        End Get

        Set(ByVal value As Integer)
            If Not value>4
                Me._LineSize = value
            Else
                Me._LineSize = 4
            End If
            
            Me.Invalidate()
        End Set
    End Property
     Public Property LineColor() As color
        Get
            Return Me._LineColor
        End Get

        Set(ByVal value As color)
            Me._LineColor = value
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
    Public Property State() As StateIND
        Get
            Return Me._State
        End Get

        Set(ByVal value As StateIND)
            Me._State = value
            Me.Invalidate
            If Not Me.Parent is Nothing Then
                Me.Parent.Invalidate
            End If
        End Set
    End Property
End Class
