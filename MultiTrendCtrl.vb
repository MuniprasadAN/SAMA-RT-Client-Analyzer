Imports System.Windows.Forms.DataVisualization.Charting

Public Class MultiTrendCtrl
    Inherits Trender
    Private resize As Boolean
    Private dragging As Boolean
    Private loc1 As Point
    Public xaxis As String
    Public Sub New()
        AddHandler Me.ChartControl1.MouseClick, (AddressOf Ctrl_Click)
        AddHandler Me.ChartControl1.MouseDown, AddressOf Ctrl_MouseDown
        AddHandler Me.ChartControl1.MouseUp, AddressOf Ctrl_MouseUp
        AddHandler Me.ChartControl1.MouseMove, AddressOf Ctrl_MouseMove
        'AddHandler Me.ChartControl1.MouseLeave, AddressOf Ctrl_MouseLeave
        'AddHandler Me.DataGridViewCtrl1.CellValueChanged, AddressOf DGV_CellValueChanged
    End Sub
    Private Sub Ctrl_MouseUp(ByVal sender As [Object], ByVal e As MouseEventArgs)

        loc1 = Nothing
        dragging = False
        resize = False
    End Sub
    Private Sub Ctrl_MouseDown(ByVal sender As [Object], ByVal e As MouseEventArgs)
        If Me.Cursor = Cursors.SizeAll Then
            dragging = True
        ElseIf resize Then
            loc1 = e.Location
        End If
    End Sub
    Private Sub Ctrl_Click(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            If e.Button = MouseButtons.Right Then
                If Me.ChartControl1.Series.Count > 0 Then
                    'MsgBox(Me.Name)
                    MainPage.MultiTrendChartProperties.Show(Me, e.X, e.Y)
                    MainPage.Trender_Ctrl = Me
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Ctrl_MouseMove(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            Dim ctl As ChartControl = CType(sender, ChartControl)
            Dim pt As Point = Me.PointToClient(ctl.PointToScreen(Point.Empty))
            If e.X > ctl.Width - 5 And e.X < ctl.Width Then
                If (My.Computer.Keyboard.CtrlKeyDown) Then
                    Me.Cursor = Cursors.SizeWE
                    resize = True
                End If
            ElseIf e.Y > ctl.Height - 5 And e.Y < ctl.Height Then
                If (My.Computer.Keyboard.CtrlKeyDown) Then
                    Me.Cursor = Cursors.SizeNS
                    resize = True
                End If
            Else
                If (My.Computer.Keyboard.CtrlKeyDown) Then
                    Me.Cursor = Cursors.SizeAll
                Else
                    Me.Cursor = Cursors.Default
                End If
            End If


            If e.Button = MouseButtons.Left And (My.Computer.Keyboard.CtrlKeyDown) Then
                If dragging Then
                    Me.Location = New Point(Cursor.Position - New Point(Me.Width \ 2, Me.Height \ 2))

                End If
            End If
            If resize Then
                If e.Button = MouseButtons.Left And (My.Computer.Keyboard.CtrlKeyDown) Then
                    If e.X > ctl.Width - 5 And e.X <= ctl.Width + 5 Then
                        If e.Location.X > loc1.X Then
                            Me.Width += e.X - ctl.Width + 5
                        ElseIf e.Location.X < loc1.X Then
                            Me.Width -= e.X - ctl.Width + 5
                        End If

                    ElseIf e.Y > ctl.Height - 5 And e.Y <= ctl.Height + 5 Then
                        If e.Location.Y > loc1.Y Then
                            Me.Height += e.Y - ctl.Height + 5
                        ElseIf e.Location.Y < loc1.Y Then
                            Me.Height -= e.Y - ctl.Height + 5
                        End If
                    End If
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
    Dim cellEndEditTimer As Timer
    Private Sub DataGridViewCtrl1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewCtrl1.CellMouseClick
        cellEndEditTimer = New Timer
        If e.ColumnIndex = 2 AndAlso e.RowIndex >= 0 Then
            cellEndEditTimer.Start()
            AddHandler cellEndEditTimer.Tick, AddressOf cellEndEditTimer_Tick
        End If

    End Sub
    Private Sub DataGridViewCtrl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewCtrl1.CellValueChanged
        If e.ColumnIndex = 5 AndAlso e.RowIndex >= 0 Then
            cellEndEditTimer.Start()
            AddHandler cellEndEditTimer.Tick, AddressOf cellEndEditTimer_Tick
        End If

    End Sub
    Private Sub DataGridViewCtrl1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewCtrl1.CellEndEdit
        If e.ColumnIndex = 2 Then
            If Me.DataGridViewCtrl1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                Me.ChartControl1.Series(e.RowIndex).Enabled = True
            ElseIf Me.DataGridViewCtrl1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                Me.ChartControl1.Series(e.RowIndex).Enabled = False
            End If
        ElseIf e.ColumnIndex = 6 Then
            Me.ChartControl1.ChartAreas(0).AxisY.Minimum = Me.DataGridViewCtrl1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        ElseIf e.ColumnIndex = 7 Then
            Me.ChartControl1.ChartAreas(0).AxisY.Maximum = Me.DataGridViewCtrl1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        End If


    End Sub

    Private Sub cellEndEditTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me.DataGridViewCtrl1.EndEdit()
        cellEndEditTimer.Stop()
    End Sub

    'Private Sub DataGridViewCtrl1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewCtrl1.CurrentCellDirtyStateChanged
    '    Try
    '        Dim curr_cell As DataGridViewCell
    '        curr_cell = Me.DataGridViewCtrl1.CurrentCell
    '        If curr_cell.RowIndex >= 0 And curr_cell.ColumnIndex = 2 Then

    '            If Me.DataGridViewCtrl1.Rows(curr_cell.RowIndex).Cells(curr_cell.ColumnIndex).FormattedValue.Equals(True) Then
    '                MsgBox("active")
    '                Me.DataGridViewCtrl1.EndEdit()
    '            ElseIf Me.DataGridViewCtrl1.Rows(curr_cell.RowIndex).Cells(curr_cell.ColumnIndex).FormattedValue.Equals(False) Then
    '                MsgBox("Inactive")
    '                Me.DataGridViewCtrl1.EndEdit()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub
End Class
