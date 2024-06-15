' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-31-2014
'
' Last Modified By : supra
' Last Modified On : 02-13-2014
' ***********************************************************************
' <copyright file="DataGridViewPrinter.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Windows.Forms

Class LogViewerDataGridViewPrinter
    Implements IDisposable
    Private TheDataGridView As DataGridView
    ' The DataGridView Control which will be printed
    Private ThePrintDocument As PrintDocument
    ' The PrintDocument to be used for printing
    Private IsCenterOnPage As Boolean
    ' Determine if the report will be printed in the Top-Center of the page
    Private IsWithTitle As Boolean
    ' Determine if the page contain title text
    Private TheTitleText As String
    ' The title text to be printed in each page (if IsWithTitle is set to true)
    Private TheTitleFont As Font
    ' The font to be used with the title text (if IsWithTitle is set to true)
    Private TheTitleColor As Color
    ' The color to be used with the title text (if IsWithTitle is set to true)
    Private IsWithPaging As Boolean
    ' Determine if paging is used
    Shared CurrentRow As Integer
    ' A static parameter that keep track on which Row (in the DataGridView control) that should be printed
    Public PageNumber As Integer

    Private PageWidth As Integer
    Private PageHeight As Integer
    Private LeftMargin As Integer
    Private TopMargin As Integer
    Private RightMargin As Integer
    Private BottomMargin As Integer

    Private CurrentY As Single
    ' A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate
    Private RowHeaderHeight As Single
    Private RowsHeight As List(Of Single)
    Private ColumnsWidth As List(Of Single)
    Private TheDataGridViewWidth As Single

    ' Maintain a generic list to hold start/stop points for the column printing
    ' This will be used for wrapping in situations where the DataGridView will not fit on a single page
    Private mColumnPoints As List(Of Integer())
    Private mColumnPointsWidth As List(Of Single)
    Private mColumnPoint As Integer


     Private Tabidx As integer
    ' The class constructor
    Public Sub New(ByVal aDataGridView As DataGridView, ByVal aPrintDocument As PrintDocument, ByVal centerOnPage As Boolean, ByVal withTitle As Boolean, ByVal aTitleText As String, ByVal aTitleFont As Font, _
     ByVal aTitleColor As Color, ByVal withPaging As Boolean)
        TheDataGridView = aDataGridView
        ThePrintDocument = aPrintDocument
        IsCenterOnPage = centerOnPage
        IsWithTitle = withTitle
        TheTitleText = aTitleText
        TheTitleFont = aTitleFont
        TheTitleColor = aTitleColor
        IsWithPaging = WithPaging

        'PageNumber = 0

        RowsHeight = New List(Of Single)()
        ColumnsWidth = New List(Of Single)()

        mColumnPoints = New List(Of Integer())()
        mColumnPointsWidth = New List(Of Single)()

        ' Claculating the PageWidth and the PageHeight
        If Not ThePrintDocument.DefaultPageSettings.Landscape Then
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        Else
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Width
            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Height
        End If

        ' Claculating the page margins
        'LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left
        'TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top
        'RightMargin = ThePrintDocument.DefaultPageSettings.Margins.Right
        'BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom
        LeftMargin = 5
        TopMargin = 5
        RightMargin = 5
        BottomMargin = 5


        ' First, the current row to be printed is the first row in the DataGridView control
        CurrentRow = 0
    End Sub

    ' The function that calculate the height of each row (including the header row), the width of each column (according to the longest text in all its cells including the header cell), and the whole DataGridView width
    Private Sub Calculate(ByVal g As Graphics)
        
         RowsHeight = New List(Of Single)()
        ColumnsWidth = New List(Of Single)()

        mColumnPoints = New List(Of Integer())()
        mColumnPointsWidth = New List(Of Single)()
       
        If PageNumber  <> -1 Then
            ' Just calculate once
            Dim tmpSize As New SizeF()
            Dim tmpFont As Font
            Dim tmpWidth As Single

            TheDataGridViewWidth = 0
            For i As Integer = 0 To TheDataGridView.Columns.Count - 1
                'tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
                tmpFont = New Font("Verdana",6,FontStyle.Bold)
                'If tmpFont Is Nothing Then
                '    ' If there is no special HeaderFont style, then use the default DataGridView font style
                '    tmpFont = TheDataGridView.DefaultCellStyle.Font
                'End If

                tmpSize = g.MeasureString(TheDataGridView.Columns(i).HeaderText, tmpFont)
                tmpWidth = tmpSize.Width
                RowHeaderHeight = tmpSize.Height

                For j As Integer = 0 To TheDataGridView.Rows.Count - 1
                    tmpFont = New Font("Verdana",6,FontStyle.Bold)
                    'If tmpFont Is Nothing Then
                    '    ' If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                    '    tmpFont = TheDataGridView.DefaultCellStyle.Font
                    'End If

                    tmpSize = g.MeasureString("Anything", tmpFont)
                    RowsHeight.Add(tmpSize.Height)

                    tmpSize = g.MeasureString(TheDataGridView.Rows(j).Cells(i).EditedFormattedValue.ToString(), tmpFont)
                    If tmpSize.Width > tmpWidth Then
                        tmpWidth = tmpSize.Width
                    End If
                Next
                If TheDataGridView.Columns(i).Visible Then
                    TheDataGridViewWidth += tmpWidth
                End If
                ColumnsWidth.Add(tmpWidth)
            Next

            ' Define the start/stop column points based on the page width and the DataGridView Width
            ' We will use this to determine the columns which are drawn on each page and how wrapping will be handled
            ' By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
            Dim k As Integer

            Dim mStartPoint As Integer = 0
            For k = 0 To TheDataGridView.Columns.Count - 1
                If TheDataGridView.Columns(k).Visible Then
                    mStartPoint = k
                    Exit For
                End If
            Next

            Dim mEndPoint As Integer = TheDataGridView.Columns.Count
            For k = TheDataGridView.Columns.Count - 1 To 0 Step -1

                If TheDataGridView.Columns(k).Visible Then
                    mEndPoint = k + 1
                    Exit For
                End If

            Next

            Dim mTempWidth As Single = TheDataGridViewWidth
            Dim mTempPrintArea As Single = CSng(PageWidth) - CSng(LeftMargin) - CSng(RightMargin)

            ' We only care about handling where the total datagridview width is bigger then the print area
            If TheDataGridViewWidth > mTempPrintArea Then
                mTempWidth = 0.0F
                For k = 0 To TheDataGridView.Columns.Count - 1
                    If TheDataGridView.Columns(k).Visible Then
                        mTempWidth += ColumnsWidth(k)
                        ' If the width is bigger than the page area, then define a new column print range
                        If mTempWidth > mTempPrintArea Then
                            mTempWidth -= ColumnsWidth(k)
                            mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
                            mColumnPointsWidth.Add(mTempWidth)
                            mStartPoint = k
                            mTempWidth = ColumnsWidth(k)
                        End If
                    End If
                    ' Our end point is actually one index above the current index
                    mEndPoint = k + 1
                Next
            End If
            ' Add the last set of columns
            mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
            mColumnPointsWidth.Add(mTempWidth)
            mColumnPoint = 0


        End If
    End Sub

    ' The funtion that print the title, page number, and the header row
    Private Sub DrawHeader(ByVal g As Graphics)
        CurrentY = CSng(TopMargin)

        ' Printing the page number (if isWithPaging is set to true)
        If IsWithPaging Then
            PageNumber += 1
            Dim pageString As String = ""

            Dim pageStringFormat As New StringFormat()
            pageStringFormat.Trimming = StringTrimming.Word
            pageStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            pageStringFormat.Alignment = StringAlignment.Far

            Dim pageStringFont As New Font("verdana", 6, FontStyle.Regular, GraphicsUnit.Point)

            Dim pageStringRectangle As New RectangleF(CSng(LeftMargin), CurrentY, CSng(PageWidth) - CSng(RightMargin) - CSng(LeftMargin), g.MeasureString(pageString, pageStringFont).Height)

            g.DrawString(pageString, pageStringFont, New SolidBrush(Color.Black), pageStringRectangle, pageStringFormat)

            CurrentY += g.MeasureString(pageString, pageStringFont).Height
        End If

        ' Printing the title (if IsWithTitle is set to true)
        If IsWithTitle Then
            Dim titleFormat As New StringFormat()
            titleFormat.Trimming = StringTrimming.Word
            titleFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            If IsCenterOnPage Then
                titleFormat.Alignment = StringAlignment.Center
            Else
                titleFormat.Alignment = StringAlignment.Near
            End If

            Dim titleRectangle As New RectangleF(CSng(LeftMargin), CurrentY, CSng(PageWidth) - CSng(RightMargin) - CSng(LeftMargin), g.MeasureString(TheTitleText, TheTitleFont).Height)

            g.DrawString(TheTitleText, TheTitleFont, New SolidBrush(TheTitleColor), titleRectangle, titleFormat)

            CurrentY += g.MeasureString(TheTitleText, TheTitleFont).Height
        End If

        ' Calculating the starting x coordinate that the printing process will start from
        Dim currentX As Single = CSng(LeftMargin)
        If IsCenterOnPage Then
            currentX += ((CSng(PageWidth) - CSng(RightMargin) - CSng(LeftMargin)) - mColumnPointsWidth(mColumnPoint)) / 2.0F
        End If

        ' Setting the HeaderFore style
        Dim headerForeColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.ForeColor
        If headerForeColor.IsEmpty Then
            ' If there is no special HeaderFore style, then use the default DataGridView style
            headerForeColor = TheDataGridView.DefaultCellStyle.ForeColor
        End If
        Dim headerForeBrush As New SolidBrush(headerForeColor)

        ' Setting the HeaderBack style
        Dim headerBackColor As Color = TheDataGridView.ColumnHeadersDefaultCellStyle.BackColor
        If headerBackColor.IsEmpty Then
            ' If there is no special HeaderBack style, then use the default DataGridView style
            headerBackColor = TheDataGridView.DefaultCellStyle.BackColor
        End If
        Dim headerBackBrush As New SolidBrush(headerBackColor)

        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim theLinePen As New Pen(TheDataGridView.GridColor, 1)

        ' Setting the HeaderFont style
        'Dim headerFont As Font = TheDataGridView.ColumnHeadersDefaultCellStyle.Font  '@@@@--->
        Dim headerFont As Font = New Font("Verdana",6,FontStyle.Bold)
        'If headerFont Is Nothing Then
        '    ' If there is no special HeaderFont style, then use the default DataGridView font style
        '    headerFont = TheDataGridView.DefaultCellStyle.Font
        'End If

        ' Calculating and drawing the HeaderBounds        
        Dim headerBounds As New RectangleF(currentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowHeaderHeight)
        g.FillRectangle(headerBackBrush, headerBounds)

        ' Setting the format that will be used to print each cell of the header row
        Dim cellFormat As New StringFormat()
        cellFormat.Trimming = StringTrimming.Word
        cellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip

        ' Printing each visible cell of the header row
        Dim cellBounds As RectangleF
        Dim columnWidth As Single
        For i As Integer = CInt(mColumnPoints(mColumnPoint).GetValue(0)) To CInt(mColumnPoints(mColumnPoint).GetValue(1)) - 1
            If Not TheDataGridView.Columns(i).Visible Then
                Continue For
            End If
            ' If the column is not visible then ignore this iteration
            columnWidth = ColumnsWidth(i)

            ' Check the CurrentCell alignment and apply it to the CellFormat
            If TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right") Then
                cellFormat.Alignment = StringAlignment.Far
            ElseIf TheDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center") Then
                cellFormat.Alignment = StringAlignment.Center
            Else
                cellFormat.Alignment = StringAlignment.Near
            End If

            cellBounds = New RectangleF(currentX, CurrentY, columnWidth, RowHeaderHeight)

            ' Printing the cell text
            g.DrawString(TheDataGridView.Columns(i).HeaderText, headerFont, headerForeBrush, cellBounds, cellFormat)

            ' Drawing the cell bounds
            If TheDataGridView.RowHeadersBorderStyle <> DataGridViewHeaderBorderStyle.None Then
                ' Draw the cell border only if the HeaderBorderStyle is not None
                g.DrawRectangle(theLinePen, currentX, CurrentY, columnWidth, RowHeaderHeight)
            End If

            currentX += columnWidth
        Next

        CurrentY += RowHeaderHeight
    End Sub

    ' The function that print a bunch of rows that fit in one page
    ' When it returns true, meaning that there are more rows still not printed, so another PagePrint action is required
    ' When it returns false, meaning that all rows are printed (the CureentRow parameter reaches the last row of the DataGridView control) and no further PagePrint action is required
    Private Function DrawRows(ByVal g As Graphics) As Boolean
        ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
        Dim theLinePen As New Pen( TheDataGridView.GridColor, 1)

        ' The style paramters that will be used to print each cell
        Dim rowFont As Font
        Dim rowForeColor As Color
        Dim rowBackColor As Color
        Dim rowForeBrush As SolidBrush
        'Dim RowBackBrush As SolidBrush
        'Dim RowAlternatingBackBrush As SolidBrush

        ' Setting the format that will be used to print each cell
        Dim cellFormat As New StringFormat()
        cellFormat.Trimming = StringTrimming.Word
        cellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit

        ' Printing each visible cell
        Dim rowBounds As RectangleF
        Dim currentX As Single
        Dim columnWidth As Single
        While CurrentRow < TheDataGridView.Rows.Count
            If TheDataGridView.Rows(CurrentRow).Visible Then
                ' Print the cells of the CurrentRow only if that row is visible
                ' Setting the row font style
                'rowFont = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.Font '@@@@---->
               rowFont= New Font("Verdana",6,FontStyle.Regular)
                'If rowFont Is Nothing Then
                '    ' If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                '    rowFont = TheDataGridView.DefaultCellStyle.Font
                'End If

                ' Setting the RowFore style
                rowForeColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.ForeColor
                If rowForeColor.IsEmpty Then
                    ' If the there is no special RowFore style of the CurrentRow, then use the default one associated with the DataGridView control
                    rowForeColor = TheDataGridView.DefaultCellStyle.ForeColor
                End If
                rowForeBrush = New SolidBrush(rowForeColor)

                ' Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                rowBackColor = TheDataGridView.Rows(CurrentRow).DefaultCellStyle.BackColor


                ' Calculating the starting x coordinate that the printing process will start from
                currentX = CSng(LeftMargin)
                If IsCenterOnPage Then
                    currentX += ((CSng(PageWidth) - CSng(RightMargin) - CSng(LeftMargin)) - mColumnPointsWidth(mColumnPoint)) / 2.0F
                End If

                ' Calculating the entire CurrentRow bounds                
                rowBounds = New RectangleF(currentX, CurrentY, mColumnPointsWidth(mColumnPoint), RowsHeight(CurrentRow))

                ' Filling the back of the CurrentRow
                'If CurrentRow Mod 2 = 0 Then
                '    g.FillRectangle(RowBackBrush, RowBounds)
                'Else
                '    g.FillRectangle(RowAlternatingBackBrush, RowBounds)
                'End If

                ' Printing each visible cell of the CurrentRow                
                For currentCell As Integer = CInt(mColumnPoints(mColumnPoint).GetValue(0)) To CInt(mColumnPoints(mColumnPoint).GetValue(1)) - 1
                    If Not TheDataGridView.Columns(currentCell).Visible Then
                        Continue For
                    End If
                    ' If the cell is belong to invisible column, then ignore this iteration
                    ' Check the CurrentCell alignment and apply it to the CellFormat
                    If TheDataGridView.Columns(currentCell).DefaultCellStyle.Alignment.ToString().Contains("Right") Then
                        cellFormat.Alignment = StringAlignment.Far
                    ElseIf TheDataGridView.Columns(currentCell).DefaultCellStyle.Alignment.ToString().Contains("Center") Then
                        cellFormat.Alignment = StringAlignment.Center
                    Else
                        cellFormat.Alignment = StringAlignment.Near
                    End If

                    columnWidth = ColumnsWidth(currentCell)
                    Dim cellBounds As New RectangleF(currentX, CurrentY, columnWidth, RowsHeight(CurrentRow))

                    ' Printing the cell text
                    g.DrawString(TheDataGridView.Rows(CurrentRow).Cells(currentCell).EditedFormattedValue.ToString(), rowFont, rowForeBrush, CellBounds, cellFormat)

                    ' Drawing the cell bounds
                    If TheDataGridView.CellBorderStyle <> DataGridViewCellBorderStyle.None Then
                        ' Draw the cell border only if the CellBorderStyle is not None
                        g.DrawRectangle(theLinePen, currentX, CurrentY, columnWidth, RowsHeight(CurrentRow))
                    End If

                    currentX += columnWidth
                Next
                CurrentY += RowsHeight(CurrentRow)

                ' Checking if the CurrentY is exceeds the page boundries
                ' If so then exit the function and returning true meaning another PagePrint action is required
                If CInt(Math.Truncate(CurrentY)) > (PageHeight - TopMargin - BottomMargin) Then
                    CurrentRow += 1
                    Return True
                End If
            End If
            CurrentRow += 1
        End While

        CurrentRow = 0
        mColumnPoint += 1
        ' Continue to print the next group of columns
        If mColumnPoint = mColumnPoints.Count Then
            ' Which means all columns are printed
            mColumnPoint = 0
            Return False
        Else
            Return True
        End If
    End Function
   
    ' The method that calls all other functions
    Public Function DrawDataGridView(ByVal g As Graphics) As Boolean
        Try
            Dim bContinue As Boolean
            For i As Integer=Tabidx to Mainpage.LogCtrl.TabPages.Count-1
                If Mainpage.LogCtrl.TabPages(i).Controls.Count>0 AndAlso Typeof Mainpage.LogCtrl.TabPages(i).Controls(0) is DataGridView Then
                    TheDataGridView=Mainpage.LogCtrl.TabPages(i).Controls(0)
                    TheTitleText=Mainpage.LogCtrl.TabPages(i).Text
                    If i=0 then
                         TopMargin = 5  
                    Else
                        If Not TopMargin=4
                            Dim tmpDgView As DataGridView=Mainpage.LogCtrl.TabPages(i-1).Controls(0)
                            TopMargin +=((tmpDgView.Rows.Count + 3 ) * (11.1694317))
                        End If
                        
                    End If
                    
                    Calculate(g)
                    DrawHeader(g)
                    bContinue = DrawRows(g)
                   
                    PageNumber =0
                    Tabidx=i
                    If bContinue Then
                         TopMargin = 4
                         Return bContinue
                    End If

            

                End If
                
            
            Next
           
           
        Catch ex As Exception
            MessageBox.Show("Operation failed: " & ex.Message, Application.ProductName & " - Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try
    End Function

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
                If Not TheDataGridView Is Nothing Then
                    TheDataGridView.Dispose()
                End If
                If Not ThePrintDocument Is Nothing Then
                    ThePrintDocument.Dispose()
                End If
                If Not TheTitleFont Is Nothing Then
                    TheTitleFont.Dispose()
                End If
            End If
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
