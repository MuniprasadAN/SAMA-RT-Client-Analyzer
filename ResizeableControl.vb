' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 01-29-2014
' ***********************************************************************
' <copyright file="ResizeableControl.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' 	
''' </summary>
Public Class ResizeableControl
    Implements IDisposable

    Private WithEvents mControl As Control
    Private mMouseDown As Boolean' = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4
    Private mOutlineDrawn As Boolean' = False

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    ''' <summary>
    ''' Initializes a new instance of the <see cref="ResizeableControl" /> class.	
    ''' </summary>
    ''' <param name="control">The control.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal control As Control)
        mControl = control
    End Sub

    Private Sub mControl_MouseDown(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseDown

        If e.Button = MouseButtons.Left Then
            mMouseDown = True
        End If
    End Sub

    Private Sub mControl_MouseUp(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles mControl.MouseUp
        Dim c As Control = CType(sender, Control)
        c.Cursor = Cursors.Default
        mMouseDown = False
    End Sub
    Private Sub mControl_MouseMove(ByVal sender As Object, _
    ByVal e As System.Windows.Forms.MouseEventArgs) _
    Handles mControl.MouseMove

        If (My.Computer.Keyboard.CtrlKeyDown) Then
            Dim c As Control = CType(sender, Control)
            If MainPage.dragging And mEdge <> EdgeEnum.None Then
                c.SuspendLayout()
                Select Case mEdge
                    Case EdgeEnum.TopLeft
                        c.SetBounds(c.Left + e.X, c.Top + e.Y, _
                c.Width, c.Height)
                        c.BringToFront()

                        MainPage.modify = True
                        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            MainPage.Text = MainPage.Text & " *"
                        End If

                    Case EdgeEnum.Left
                        c.SetBounds(c.Left + e.X, c.Top, _
                c.Width - e.X, c.Height)
                    Case EdgeEnum.Right
                        c.SetBounds(c.Left, c.Top, _
                c.Width - (c.Width - e.X), c.Height)
                    Case EdgeEnum.Top
                        c.SetBounds(c.Left, c.Top + e.Y, _
                c.Width, c.Height - e.Y)
                    Case EdgeEnum.Bottom
                        c.SetBounds(c.Left, c.Top, _
                c.Width, c.Height - (c.Height - e.Y))
                    Case Else
                        ' do the defalut action
                End Select
                c.ResumeLayout()
            Else
                Select Case True
                    Case e.X <= (mWidth * 4) And _
                e.Y <= (mWidth * 4) 'top left corner
                        c.Cursor = Cursors.SizeAll
                        mEdge = EdgeEnum.TopLeft
                    Case e.X <= mWidth 'left edge
                        c.Cursor = Cursors.SizeWE
                        mEdge = EdgeEnum.Left
                    Case e.X > c.Width - (mWidth + 1) 'right edge
                        c.Cursor = Cursors.SizeWE
                        mEdge = EdgeEnum.Right
                    Case e.Y <= mWidth 'top edge
                        c.Cursor = Cursors.SizeNS
                        mEdge = EdgeEnum.Top
                    Case e.Y > c.Height - (mWidth + 1) 'bottom edge
                        c.Cursor = Cursors.SizeNS
                        mEdge = EdgeEnum.Bottom
                    Case Else 'no edge
                        c.Cursor = Cursors.Default
                        mEdge = EdgeEnum.None
                End Select
            End If
        End If

    End Sub


#Region "IDisposable Implementation"

    Protected disposed As Boolean

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        SyncLock Me
            ' Do nothing if the object has already been disposed of.
            If disposed Then
                Exit Sub
            End If

            If disposing Then
                ' Release disposable objects used by this instance here.

                If Not mControl Is Nothing Then
                    mControl.Dispose()
                End If
            End If

            ' Release unmanaged resources here. Don't access reference type fields.

            ' Remember that the object has been disposed of.
            disposed = True
        End SyncLock
    End Sub

    Public Overridable Sub Dispose() _
      Implements IDisposable.Dispose
        Dispose(True)
        ' Unregister object for finalization.
        GC.SuppressFinalize(Me)
    End Sub

#End Region
End Class
