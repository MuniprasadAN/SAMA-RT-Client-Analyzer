Imports Microsoft.Office.Interop
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.ComponentModel
Imports System.Diagnostics

Public Class TaskScheduleClass
    Friend Task_timer As New Timer
    Private Type As String
    Private Ctrl_Name As String
    Private PathOrPrinterNameorEmailmsg As String

    Private PrintDoc_Table As New PrintDocument
    Private PrintDoc_Chart As New PrintDocument

    Private PrintGrid As DataGridViewPrinter
    Private Chart_Ctrl As New ChartControl





    Private email_id As String, email_passwd As String, smtp_server As String, smtp_port As Integer, ssl As Boolean

    Private To_addr As String, email_sub As String, email_body As String
    Private hasAttch As Boolean

    Private msg As New System.Net.Mail.MailMessage
    Private smtp As New System.Net.Mail.SmtpClient
    Private attchFile As Attachment

    Friend Sub New()

    End Sub
    Friend Sub New(ByVal Intervel As Integer, ByVal Task_Type As String, ByVal CtrlName As String, ByVal Path As String)

        Type = Task_Type
        PathOrPrinterNameorEmailmsg = Path
        Ctrl_Name = CtrlName

        Task_timer.Interval = Intervel

        AddHandler Task_timer.Tick, AddressOf Task_timer_Tick

        AddHandler PrintDoc_Table.PrintPage, AddressOf PrintDoc_Table_PrintPage
        AddHandler PrintDoc_Chart.PrintPage, AddressOf PrintDoc_Chart_PrintPage

        Task_timer.Start()

    End Sub
    Private Sub Task_timer_Tick()
        Dim filename As String = ""
        Try
            For j As Integer = 0 To MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1
                Dim pnlObj() As Control
                pnlObj = MainPage.Controls.Find("pnlPage" & j + 1, True)
                If pnlObj.Length > 0 Then
                    If Not pnlObj(0) Is Nothing Then
                        Dim Fcontrols = pnlObj(0).Controls.Find(Ctrl_Name, True)
                        If Fcontrols.Length > 0 Then
                            If Not Fcontrols(0) Is Nothing Then
                                If (TypeOf Fcontrols(0) Is DataGridViewCtrl) Then
                                    If Type = "Print" Then
                                        Print(Fcontrols(0), PathOrPrinterNameorEmailmsg)
                                    ElseIf Type = "Export Image/ CSV File" Then
                                        Export_GridTable(Fcontrols(0), PathOrPrinterNameorEmailmsg & "\" & Now.ToString("dd-MM-yyyy hh-mm-ss") & ".csv")
                                    ElseIf Type = "EMail" Then
                                        If Not IO.Directory.Exists(Application.StartupPath & "\EMail") Then
                                            IO.Directory.CreateDirectory(Application.StartupPath & "\EMail")
                                        End If
                                        filename = Now.ToString("dd-MM-yyyy hh-mm-ss")
                                        Export_GridTable(Fcontrols(0), Application.StartupPath & "\Email\" & filename & ".csv")
                                        PassMailMsg(Application.StartupPath & "\Email\" & filename & ".csv")

                                    End If
                                ElseIf (TypeOf Fcontrols(0) Is Chart) Then
                                    If Type = "Print" Then
                                        Chart_Ctrl = Fcontrols(0)
                                        PrintDoc_Chart.PrintController = New StandardPrintController
                                        PrintDoc_Chart.Print()
                                    ElseIf Type = "Export Image/ CSV File" Then
                                        Chart_Ctrl = Fcontrols(0)
                                        Chart_Ctrl.SaveImage(PathOrPrinterNameorEmailmsg & "\" & Now.ToString("dd-MM-yyyy hh-mm-ss") & ".Jpeg", ChartImageFormat.Jpeg)
                                    ElseIf Type = "EMail" Then
                                        If Not IO.Directory.Exists(Application.StartupPath & "\EMail") Then
                                            IO.Directory.CreateDirectory(Application.StartupPath & "\EMail")
                                        End If

                                        Chart_Ctrl = Fcontrols(0)
                                        filename = Now.ToString("dd-MM-yyyy hh-mm-ss")
                                        Chart_Ctrl.SaveImage(Application.StartupPath & "\Email\" & filename & ".Jpeg", ChartImageFormat.Jpeg)
                                        PassMailMsg(Application.StartupPath & "\Email\" & filename & ".Jpeg")
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TaskScheduleClass.Task_timer_Tick()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try


    End Sub

    Private Sub PassMailMsg(ByVal attach_file As String)

        Try




            If Type = "EMail" Then
                If MainPage.EmailSetting.Count > 0 Then
                    email_id = MainPage.EmailSetting(0)
                    email_passwd = MainPage.EmailSetting(1)
                    smtp_server = MainPage.EmailSetting(2)
                    smtp_port = MainPage.EmailSetting(3)
                    If MainPage.EmailSetting(4) = "True" Then
                        ssl = True
                    Else
                        ssl = False
                    End If
                End If

                Dim aL_msg = PathOrPrinterNameorEmailmsg.Split("&")

                If aL_msg.Length > 1 Then
                    To_addr = aL_msg(0)
                    email_sub = aL_msg(1)
                    email_body = aL_msg(2)

                    If aL_msg(3) = "True" Then
                        hasAttch = True
                    Else
                        hasAttch = False
                    End If
                Else
                    To_addr = ""
                    email_sub = ""
                    email_body = ""

                End If


            End If






            Dim ProcessProperties As New ProcessStartInfo
            ProcessProperties.FileName = Application.StartupPath & "\EmailSender.exe"
            Dim arg As String = email_id & "#" & email_passwd & "#" & smtp_server & "#" & smtp_port & "#" & ssl & _
                "#" & email_sub & "#" & To_addr & "#" & email_body & "#" & hasAttch & "#"
            arg = arg.Replace(" ", "$").Trim()

            ProcessProperties.Arguments = arg & " " & attach_file.Replace(" ", "$")
            ProcessProperties.WindowStyle = ProcessWindowStyle.Hidden

            Dim procID As Integer
            Dim newProc As Diagnostics.Process

            newProc = Diagnostics.Process.Start(ProcessProperties)
            procID = newProc.Id
            newProc.WaitForExit()


        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@PassMailMsg()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try



    End Sub
    Friend Sub Print(ByVal Grid_TableCtrl As DataGridViewCtrl, ByVal PathOrPrinterName As String)

        PrintDoc_Table.PrinterSettings.PrinterName = PathOrPrinterName
        PrintDoc_Table.PrintController = New StandardPrintController
        If SetupThePrinting(Grid_TableCtrl) Then
            PrintDoc_Table.Print()
        End If

    End Sub
    ''' <summary>
    ''' Printing Setup
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetupThePrinting(ByVal Grid_TableCtrl As DataGridViewCtrl) As Boolean
        '========Individual User Status tab=====
        PrintGrid = New DataGridViewPrinter(Grid_TableCtrl, PrintDoc_Table, False, True, "", New Font("Verdana", 8, FontStyle.Bold, GraphicsUnit.Point), _
       Color.Black, True)
        Return True
    End Function
    Private Sub PrintDoc_Table_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim more As Boolean = PrintGrid.DrawDataGridView(e.Graphics)
        If more = True Then
            e.HasMorePages = True
        End If
    End Sub

    ''' <summary>
    ''' Grid table Content Export to .CSV File
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Export_GridTable(ByVal Grid_TableCtrl As DataGridViewCtrl, ByVal path As String)

        Try
            Dim StrExport As String = ""
            For Each C As DataGridViewColumn In Grid_TableCtrl.Columns
                StrExport &= " " & C.HeaderText & ","
            Next
            StrExport = StrExport.Substring(0, StrExport.Length - 1)
            StrExport &= Environment.NewLine

            For Each R As DataGridViewRow In Grid_TableCtrl.Rows
                For Each C As DataGridViewCell In R.Cells
                    If Not C.Value Is Nothing Then
                        StrExport &= " " & C.Value.ToString & ","
                    Else
                        StrExport &= ","
                    End If
                Next

                StrExport &= Environment.NewLine
            Next

            Dim tw As IO.TextWriter = New IO.StreamWriter(path)
            tw.Write(StrExport)
            tw.Close()

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TaskScheduleClass.Export_GridTable()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")

        End Try

    End Sub
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub




    'For Chart Printing
    Private Sub PrintDoc_Chart_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Try
            Dim myImage As New Bitmap(Chart_Ctrl.Width, Chart_Ctrl.Height)
            Dim printSize As Size = e.MarginBounds.Size
            Dim scale As Double = 1
            Chart_Ctrl.DrawToBitmap(myImage, New Rectangle(Point.Empty, Chart_Ctrl.Size))
            printSize.Width *= 1.0 'convert to pixels
            printSize.Height *= 1.0
            If myImage.Width > printSize.Width Then
                'Form is to big. Scale it down.
                scale = printSize.Width / myImage.Width
                e.Graphics.ScaleTransform(scale, scale)
            End If
            If (myImage.Height * scale) > printSize.Height Then
                'The form is still to big. Scale it again.
                scale = printSize.Height / (myImage.Height * scale)
                e.Graphics.ScaleTransform(scale, scale)
            End If
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.DrawImage(myImage, e.MarginBounds.Location)
            myImage.Dispose()
        Catch ex As Exception

            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@TaskScheduleClass.PrintDoc_Chart_PrintPage()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

End Class
