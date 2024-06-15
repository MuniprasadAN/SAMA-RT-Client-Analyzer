Imports System.IO
Imports System.Data.OleDb

Public Class LogViewer
    Inherits TabControl
    Friend File_Path As String = ""
    Friend isLatest As Boolean
    Friend Extension As String = ""
    Friend Delimiter As String = ""
    Friend nnHour As Integer = 1


    Private Ctrl_MinSize As New Size(20, 20)
    Private dragging As Boolean
    Private oldX, OldY As Single 'Cursor Loc
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 4

    Private mNodeDirectory As IO.DirectoryInfo
    Friend tmrAutoUpdate As New Timer
    Friend isTimerStart As Boolean

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum
    Friend Sub New()

        Me.MinimumSize = Ctrl_MinSize
        Me.Padding = New Point(5, 5)
        Me.Font = New Font("Verdana", 8.25, FontStyle.Bold)
        Me.TabPages.Add("Log Book")
        Me.TabPages(0).BackColor=Color.Transparent
        AddHandler Me.MouseDown, AddressOf LogCtrl_MouseDown
        AddHandler Me.MouseUp, AddressOf LogCtrl_MouseUp
        AddHandler Me.MouseMove, AddressOf LogCtrl_MouseMove
        AddHandler Me.MouseLeave, AddressOf LogCtrl_Leave
        tmrAutoUpdate.Interval=60000
        AddHandler tmrAutoUpdate.Tick,AddressOf tmrAutoUpdate_Tick
       
    End Sub
    Private Sub tmrAutoUpdate_Tick()
        Try
            tmrAutoUpdate.Stop()
            Select Case Extension
                Case ".txt"
                    If Not isLatest Then
                        Me.LoadTextFile(File_Path,False, nnHour)
                    Else
                        Me.LoadTextFile(File_Path, True, 1)
                    End If
                Case ".csv"
                    If Not isLatest Then
                        Me.LoadCSVFile(File_Path, False, nnHour, Delimiter)
                    Else
                        Me.LoadCSVFile(File_Path, True, 1, Delimiter)
                    End If
                Case ".xls"
                    If Not isLatest Then
                        Me.LoadExcelFile(File_Path, False, nnHour, ".xls")
                    Else
                        Me.LoadExcelFile(File_Path, True, 1, ".xls")
                    End If
                Case ".xlsx"
                    If Not isLatest Then
                        Me.LoadExcelFile(File_Path, False, nnHour, ".xlsx")
                    Else
                        Me.LoadExcelFile(File_Path, True, 1, ".xlsx")
                    End If
                Case ".html"
                    If Not isLatest Then
                        Me.LoadHTMLFile(File_Path, False, nnHour)
                    Else
                        Me.LoadHTMLFile(File_Path, True, 1)
                    End If
                Case ".xml"
                    If Not isLatest Then
                        Me.LoadXMLFile(File_Path, False, nnHour)
                    Else
                        Me.LoadXMLFile(File_Path, True, 1)
                    End If
            End Select 

            tmrAutoUpdate.Start()
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@tmrAutoUpdate_Tick()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
       
    End Sub

    Private Sub LogCtrl_Leave()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LogCtrl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Controls.Count > 0 Then
            For Each Ctrl In Me.Controls
                If (TypeOf Ctrl Is RichTextBox Or TypeOf Ctrl Is DataGridView Or TypeOf Ctrl Is WebBrowser) Then
                    Ctrl.width = Me.Width - 30
                    Ctrl.height = Me.Height / (Me.Controls.Count / 2)
                End If
            Next
        End If

    End Sub
    Private Sub LogCtrl_MouseUp(ByVal sender As [Object], ByVal e As MouseEventArgs)
        sender.Cursor = Cursors.Default
        dragging = False
    End Sub
    Private Sub LogCtrl_MouseDown(ByVal sender As [Object], ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            dragging = True
            oldX = e.X
            OldY = e.Y
        End If
    End Sub



    Private Sub LogCtrl_MouseMove(ByVal sender As [Object], ByVal e As MouseEventArgs)
        Try
            Dim c As LogViewer = CType(sender, Control)
            If (My.Computer.Keyboard.CtrlKeyDown) Then

                If dragging And mEdge <> EdgeEnum.None Then
                    c.SuspendLayout()
                    Mainpage.modify = True
                    If Not Mainpage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
                            Mainpage.Text = Mainpage.Text & " *"
                    End If
                    Select Case mEdge
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

                        Case EdgeEnum.TopLeft
                            If dragging And (My.Computer.Keyboard.CtrlKeyDown) Then
                                c.SetBounds((e.X + c.Left) - oldX, (e.Y + c.Top) - OldY, c.Width, c.Height)
                            End If
                        Case Else
                            ' do the defalut action
                    End Select
                    c.ResumeLayout()
                Else
                    Select Case True
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
                            c.Cursor = Cursors.SizeAll
                            mEdge = EdgeEnum.TopLeft
                    End Select
                End If
            End If
        Catch ex As Exception
             MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LogCtrl_MouseMove()")
           MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


    End Sub
    Friend Sub LoadTextFile(ByVal _path As String, ByVal _isLatest As Boolean, ByVal _nnHour As Integer)
        Try
              File_Path = _path
        nnHour = _nnHour
        isLatest = _isLatest
        Extension = ".txt"
        Dim blnExist As Boolean
        If _isLatest Then '-Start

            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.txt", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)

                    Dim TextCtrl As RichTextBox = ViewTextFile(mFileName.FullName)

                    Dim tbPage As New TabPage(mFileName.Name)
                    tbPage.Tag=mFileName.FullName
                    tbPage.BackColor = Color.White
                    tbPage.Controls.Add(TextCtrl)

                    Me.TabPages.Clear()
                    Me.TabPages.Add(tbPage)

                    blnExist = True
                    Exit For

                Next

                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If
            End If '--End

        Else
            nnHour = _nnHour
            Dim i As Integer = 0
            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                Dim DateT As Date = Now.AddHours(-nnHour)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.txt", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)

                    If mFileName.CreationTime >= DateT Then
                        Dim TextCtrl As RichTextBox = ViewTextFile(mFileName.FullName)

                        Dim tbPage As New TabPage(mFileName.Name)
                        tbPage.Tag=mFileName.FullName
                        tbPage.BackColor = Color.White
                        tbPage.Controls.Add(TextCtrl)
                        If i = 0 Then
                            Me.TabPages.Clear()
                            blnExist = True
                            i += 1
                        End If

                        Me.TabPages.Add(tbPage)

                    End If


                Next
                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If

            End If '--End
        End If '-End
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LoadTextFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
      
    End Sub
    Private Function ViewTextFile(ByVal Path As String) As RichTextBox
        Dim rtboxTextFile As New RichTextBox
        Try
            rtboxTextFile.Font = New Font("Courier New", 13, FontStyle.Bold)
            rtboxTextFile.LoadFile(Path, RichTextBoxStreamType.PlainText)
            rtboxTextFile.Dock = DockStyle.Fill
            rtboxTextFile.ScrollBars = RichTextBoxScrollBars.Both

        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ViewTextFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

        Return rtboxTextFile
    End Function

    Friend Sub LoadExcelFile(ByVal _path As String, ByVal _isLatest As Boolean, ByVal _nnHour As Integer, ByVal _Extension As String)
        Try
             File_Path = _path
        nnHour = _nnHour
        isLatest = _isLatest
        Extension = _Extension

        Dim blnExist As Boolean
        If _isLatest Then '-Start

            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*" & Extension, SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                  If mFileName.FullName.EndsWith(Extension) Then
                    Dim EXCELCtrl As DataGridView = ViewExcelFileFile(mFileName.FullName)
                    Dim tbPage As New TabPage(mFileName.Name)
                    tbPage.Tag=mFileName.FullName
                    tbPage.BackColor = Color.White
                    tbPage.Controls.Add(EXCELCtrl)
                    Me.TabPages.Clear()
                    Me.TabPages.Add(tbPage)

                    blnExist = True
                    Exit For
                  End If
                   
                Next

                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If
            End If '--End

        Else
            nnHour = _nnHour
            Dim i As Integer = 0
            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                Dim DateT As Date = Now.AddHours(-nnHour)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*" & Extension, SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    If mFileName.CreationTime >= DateT AndAlso mFileName.FullName.EndsWith(Extension) Then

                        Dim EXCELCtrl As DataGridView = ViewExcelFileFile(mFileName.FullName)

                        Dim tbPage As New TabPage(mFileName.Name)
                        tbPage.Tag=mFileName.FullName
                        tbPage.BackColor = Color.White
                        tbPage.Controls.Add(EXCELCtrl)
                        If i = 0 Then
                            Me.TabPages.Clear()
                            blnExist = True
                            i += 1
                        End If

                        Me.TabPages.Add(tbPage)

                    End If

                Next
                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If

            End If '--End
        End If '-End
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LoadExcelFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
       
    End Sub
    Private Function ViewExcelFileFile(ByVal Path As String) As DataGridView
        Dim DgView As New DataGridView
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim dt As New DataTable
        Dim Constr As String = ""
        Dim ds As New DataSet
        If Path.EndsWith(".xlsx") Then
            Constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Path & ";Extended Properties=Excel 12.0;"
        ElseIf Path.EndsWith(".xls") Then
            Constr = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Path & ";Extended Properties=""Excel 8.0;HDR=YES;"""
        End If

        cn = New System.Data.OleDb.OleDbConnection(Constr)

        Try
            cn.Open()
            ' It Represents Excel data table Schema.'
             ds = New DataSet
            dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            If dt IsNot Nothing OrElse dt.Rows.Count > 0 Then
                For sheet_count As Integer = 0 To dt.Rows.Count - 1
                    Try
                        ' Create Query to get Data from sheet. '
                        Dim sheetname As String = dt.Rows(sheet_count)("table_name").ToString()
                        Dim da As New OleDbDataAdapter("SELECT * FROM [" & sheetname & "]", cn)
                        da.Fill(ds, sheetname)
                    Catch ex As DataException
                        MsgBox(ex.Message)
                    End Try
                Next
            End If
            cn.Close()

            If ds IsNot Nothing  Andalso ds.Tables(0)isNot Nothing Then
                DgView.AllowUserToAddRows=False
                DgView.AllowUserToDeleteRows=False
                DgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                DgView.EditMode = DataGridViewEditMode.EditProgrammatically
                DgView.DataSource = ds.Tables(0)
                DgView.Dock=DockStyle.Fill
                DgView.RowHeadersVisible=False
                DgView.ColumnHeadersDefaultCellStyle.Font= New Font("Verdana", 8.25, FontStyle.Bold)
                DgView.Font= New Font("Verdana", 8.25, FontStyle.Regular)
                DgView.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells
                DgView.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells
                DgView.BackgroundColor=color.FromKnownColor(KnownColor.Window)
                DgView.GridColor=Color.Silver

           
            End If
     
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ViewExcelFileFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        End Try
         Return DgView
    End Function

    Friend Sub LoadHTMLFile(ByVal _path As String, ByVal _isLatest As Boolean, ByVal _nnHour As Integer)
        Try
             File_Path = _path
        nnHour = _nnHour
        isLatest = _isLatest
        Extension = ".html"

        Dim blnExist As Boolean
        If _isLatest Then '-Start

            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.html", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    Dim HTMLCtrl As WebBrowser = ViewHTMLFile(mFileName.FullName)
                    Dim tbPage As New TabPage(mFileName.Name)
                    tbPage.Tag=mFileName.FullName
                    tbPage.BackColor = Color.White
                    tbPage.Controls.Add(HTMLCtrl)
                    Me.TabPages.Clear()
                    Me.TabPages.Add(tbPage)

                    blnExist = True
                    Exit For
                Next

                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If
            End If '--End

        Else
            nnHour = _nnHour
            Dim i As Integer = 0
            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                Dim DateT As Date = Now.AddHours(-nnHour)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.html", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    If mFileName.CreationTime >= DateT Then
                        Dim HTMLCtrl As WebBrowser = ViewHTMLFile(mFileName.FullName)

                        Dim tbPage As New TabPage(mFileName.Name)
                        tbPage.Tag=mFileName.FullName
                        tbPage.BackColor = Color.White
                        tbPage.Controls.Add(HTMLCtrl)
                        If i = 0 Then
                            Me.TabPages.Clear()
                            blnExist = True
                            i += 1
                        End If

                        Me.TabPages.Add(tbPage)

                    End If

                Next
                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If

            End If '--End
        End If '-End
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LoadHTMLFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
       
    End Sub
    Private Function ViewHTMLFile(ByVal Path As String) As WebBrowser
        Dim _WebBrowser As New WebBrowser
        Try

            _WebBrowser.Dock = DockStyle.Fill
            _WebBrowser.ScriptErrorsSuppressed = True

            _WebBrowser.Navigate(IO.Path.GetFullPath(Path))

        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ViewHTMLFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
        Return _WebBrowser
    End Function
    Friend Sub LoadCSVFile(ByVal _path As String, ByVal _isLatest As Boolean, ByVal _nnHour As Integer, ByVal _Delimiter As String)
        Try
        File_Path = _path
        nnHour = _nnHour
        isLatest = _isLatest
        Extension = ".csv"
        Delimiter = _Delimiter
        Dim blnExist As Boolean
        If _isLatest Then '-Start

            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.csv", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    Dim CSVCtrl As DataGridView = ViewCSVFile(mFileName.FullName, _Delimiter)
                    Dim tbPage As New TabPage(mFileName.Name)
                    tbPage.Tag=mFileName.FullName
                    tbPage.BackColor = Color.White
                    tbPage.Controls.Add(CSVCtrl)
                    Me.TabPages.Clear()
                    Me.TabPages.Add(tbPage)

                    blnExist = True
                    Exit For
                Next

                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If
            End If '--End

        Else
            nnHour = _nnHour
            Dim i As Integer = 0
            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                Dim DateT As Date = Now.AddHours(-nnHour)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.csv", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    If mFileName.CreationTime >= DateT Then
                        Dim CSVCtrl As DataGridView = ViewCSVFile(mFileName.FullName, _Delimiter)

                        Dim tbPage As New TabPage(mFileName.Name)
                        tbPage.Tag=mFileName.FullName
                        tbPage.BackColor = Color.White
                        tbPage.Controls.Add(CSVCtrl)
                        If i = 0 Then
                            Me.TabPages.Clear()
                            blnExist = True
                            i += 1
                        End If

                        Me.TabPages.Add(tbPage)

                    End If

                Next
                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If

            End If '--End
        End If '-End
        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LoadCSVFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
     
    End Sub
    Private Function ViewCSVFile(ByVal Path As String, ByVal Delim As String) As DataGridView
        Dim DgView As New DataGridView
        Try

            Dim i As Integer = 0
            DgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgView.EditMode = DataGridViewEditMode.EditProgrammatically
            DgView.AllowUserToAddRows = False
            DgView.AllowUserToDeleteRows = False

            DgView.Dock = DockStyle.Fill
            DgView.RowHeadersVisible = False
            'DgView.ColumnHeadersVisible=False
            DgView.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 8.25, FontStyle.Bold)
            DgView.Font = New Font("Verdana", 8.25, FontStyle.Regular)
            DgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DgView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DgView.BackgroundColor = Color.FromKnownColor(KnownColor.Window)
            DgView.GridColor = Color.Silver

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Path)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(Delim)
                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try

                        currentRow = MyReader.ReadFields() 'Read Row
                        If i = 0 Then
                            For ColIdx As Integer = 0 To currentRow.Length - 2
                                DgView.Columns.Add(currentRow(ColIdx), currentRow(ColIdx))
                            Next
                        Else
                            DgView.Rows.Add()
                            For Cellidx As Integer = 0 To DgView.Columns.Count - 1
                                If currentRow.Length - 1 >= Cellidx Then
                                    DgView.Rows(i - 1).Cells(Cellidx).Value = currentRow(Cellidx)
                                End If

                            Next
                        End If

                        i += 1

                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using

            DgView.Refresh()
        Catch ex As Exception
           MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ViewCSVFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
        Return DgView
    End Function

    Friend Sub LoadXMLFile(ByVal _path As String, ByVal _isLatest As Boolean, ByVal _nnHour As Integer)
        Try
             File_Path = _path
        nnHour = _nnHour
        isLatest = _isLatest
        Extension = ".xml"
        Dim blnExist As Boolean
        If _isLatest Then '-Start

            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.xml", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    Dim XMLCtrl As DataGridView = ViewXMLFile(mFileName.FullName)
                    Dim tbPage As New TabPage(mFileName.Name)
                    tbPage.Tag=mFileName.FullName
                    tbPage.BackColor = Color.White
                    tbPage.Controls.Add(XMLCtrl)
                    Me.TabPages.Clear()
                    Me.TabPages.Add(tbPage)

                    blnExist = True
                    Exit For
                Next

                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If
            End If '--End

        Else
            nnHour = _nnHour
            Dim i As Integer = 0
            If Directory.Exists(_path) Then '--Start
                mNodeDirectory = New IO.DirectoryInfo(_path)
                Dim DateT As Date = Now.AddHours(-nnHour)
                For Each mFileName As IO.FileInfo In mNodeDirectory.GetFiles("*.xml", SearchOption.TopDirectoryOnly).OrderByDescending(Function(x) x.CreationTime)
                    If mFileName.CreationTime >= DateT Then
                        Dim XMLCtrl As DataGridView = ViewXMLFile(mFileName.FullName)

                        Dim tbPage As New TabPage(mFileName.Name)
                        tbPage.Tag=mFileName.FullName
                        tbPage.BackColor = Color.White
                        tbPage.Controls.Add(XMLCtrl)
                        If i = 0 Then
                            Me.TabPages.Clear()
                            blnExist = True
                            i += 1
                        End If

                        Me.TabPages.Add(tbPage)

                    End If

                Next
                If Not blnExist Then
                    Me.TabPages.Clear()
                    Me.TabPages.Add("Log Book")
                End If

            End If '--End
        End If '-End
        Catch ex As Exception
             MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@LoadXMLFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
       
    End Sub

    Private Function ViewXMLFile(ByVal Path As String) As DataGridView
        Dim DgView As New DataGridView
        Try
            Dim ds = New DataSet
            ds.ReadXml(Path)

            DgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DgView.EditMode = DataGridViewEditMode.EditProgrammatically
            DgView.AllowUserToAddRows = False
            DgView.AllowUserToDeleteRows = False
            DgView.Dock = DockStyle.Fill
            DgView.RowHeadersVisible = False
            'DgView.ColumnHeadersVisible=False
            DgView.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 8.25, FontStyle.Bold)
            DgView.Font = New Font("Verdana", 8.25, FontStyle.Regular)
            DgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DgView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DgView.BackgroundColor = Color.FromKnownColor(KnownColor.Window)
            DgView.GridColor = Color.Silver


            DgView.DataSource = ds.Tables(0)

            DgView.Refresh()

        Catch ex As Exception
            MainPage. _errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@ViewXMLFile()")
            MainPage. MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
        Return DgView
    End Function
End Class
