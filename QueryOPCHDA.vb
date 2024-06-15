'Imports CefSharp.WinForms
'Imports CefSharp
Imports System.Text

Public Class QueryOPCHDA
    'Private WithEvents browser As ChromiumWebBrowser

    Public Sub New()
        Try
            InitializeComponent()

            ' Dim settings As New CefSettings()
            ' CefSharp.Cef.Initialize(settings)
            Dim pth As String = Application.StartupPath & "\OPCHDA Query\OPCHDAQuery.html"
            If IO.File.Exists(pth) Then
                'browser = New ChromiumWebBrowser(pth) With {
                '.Dock = DockStyle.Fill
                '            }
            Else
                MsgBox("There is no file found like" & pth)
            End If
            'browser = New ChromiumWebBrowser("http://thechriskent.com") With {
            '    .Dock = DockStyle.Fill
            '}
            'PanelBrowse.Controls.Add(browser)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BrowseOPCHDA_Tags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComBxServer.Items.Clear()
            For i As Integer = 0 To chklstTreeValues.Items.Count - 1
                chklstTreeValues.SetItemChecked(i, False)
            Next
            ComBxServer.Items.AddRange(MainPage.OPCHDAServersList.Configname.ToArray())
            CBxChartType.Text = "spline"
        Catch ex As Exception

        End Try


    End Sub

    Dim lst As New List(Of String)
    Dim lstSelectedValues As New List(Of String)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComBxServer.Items.Clear()
            For i As Integer = 0 To chklstTreeValues.Items.Count - 1
                chklstTreeValues.SetItemChecked(i, False)
            Next
            ComBxServer.Items.AddRange(MainPage.OPCHDAServersList.Configname.ToArray())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FilterIt()
        If txtSearchText.Text = "" Then
            chklstTreeValues.Items.Clear()
            chklstTreeValues.Items.AddRange(lst.ToArray)
        Else
            chklstTreeValues.Items.Clear()

            Dim v = From k In lst.ToArray()
                    Where k.IndexOf(txtSearchText.Text, StringComparison.CurrentCultureIgnoreCase) >= 0

            For Each ol In v
                chklstTreeValues.Items.Add(ol)
            Next

        End If

        For jj As Integer = 0 To chklstTreeValues.Items.Count - 1
            '   Debug.Print(chklstTreeValues.Items(jj).ToString)

            If lstSelectedValues.Contains(chklstTreeValues.Items(jj).ToString) Then
                ' Debug.Print(jj & vbTab & chklstTreeValues.Items(jj).ToString)
                chklstTreeValues.SetItemChecked(jj, True)
            Else
                chklstTreeValues.SetItemChecked(jj, False)
            End If
        Next
    End Sub

    Private Sub txtSearchText_KeyPress(sender As Object, e As KeyPressEventArgs)
        FilterIt()
    End Sub

    Private Sub txtSearchText_KeyUp(sender As Object, e As KeyEventArgs)
        FilterIt()
    End Sub

    Private Sub txtSearchText_KeyDown(sender As Object, e As KeyEventArgs)
        FilterIt()
    End Sub

    Private Sub chklstTreeValues_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub chklstTreeValues_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        Dim val As String = chklstTreeValues.Items(e.Index)


        If e.NewValue Then
            ' Debug.Print(val & vbTab & " Checked")
            If Not lstSelectedValues.Contains(val) Then
                lstSelectedValues.Add(val)
            End If

        Else
            ' Debug.Print(val & vbTab & "UnChecked")
            lstSelectedValues.Remove(val)
        End If
    End Sub

    Private Sub btnbrowsse_Click(sender As Object, e As EventArgs) Handles btnbrowsse.Click
        Try

            Dim indx As Integer = MainPage.OPCHDAServersList.Configname.IndexOf(ComBxServer.Text)

            lst = New List(Of String)
            lstSelectedValues = New List(Of String)
            chklstTreeValues.Items.Clear()

            If indx > -1 Then

                If MainPage.OPCHDAServersList.SecondaryIPAddress(indx) = "-" Then
                    Dim tmpOPCHDA As New HDARedundancy(MainPage.OPCHDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.PrimaryPortNo(indx), "", False, MainPage)
                    tmpOPCHDA.ThreadConnect()
                    ' System.Diagnostics.Debug.Print(tmpOPCHDA.PrimaryClient.Url)
                    Dim tm As DateTime = Now
                    While True
                        If Not tmpOPCHDA.PrimaryFailed Then
                            Exit While
                        End If

                        If Now > DateAdd(DateInterval.Second, 10, tm) Then
                            Exit While
                        End If
                    End While
                    lst = tmpOPCHDA.GetAllTags
                    chklstTreeValues.Items.AddRange(lst.ToArray)
                Else
                    Dim tmpOPCHDA As New HDARedundancy(MainPage.OPCHDAServersList.PrimaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.PrimaryPortNo(indx), MainPage.OPCHDAServersList.SecondaryIPAddress(indx) + ":" + MainPage.OPCHDAServersList.SecondaryPortNo(indx), True, MainPage)
                    tmpOPCHDA.ThreadConnect()
                    Dim tm As DateTime = Now
                    While True
                        If Not tmpOPCHDA.PrimaryFailed Then
                            Exit While
                        End If

                        If Now > DateAdd(DateInterval.Second, 10, tm) Then
                            Exit While
                        End If
                    End While
                    lst = tmpOPCHDA.GetAllTags
                    chklstTreeValues.Items.AddRange(lst.ToArray)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub QueryOPCHDA_MaximumSizeChanged(sender As Object, e As EventArgs) Handles Me.MaximumSizeChanged

    End Sub

    Private Sub QueryOPCHDA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    browser.Dispose()
        '    browser = Nothing
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim chkitemTags As New List(Of String)
        Dim frmDateTime, toDateTime As DateTime
        Dim rawqueryresult As String = ""
        Try
            For Each ite In chklstTreeValues.CheckedItems
                chkitemTags.Add(ite)
            Next

            frmDateTime = New Date(FromDate.Value.Year, FromDate.Value.Month, FromDate.Value.Day, FromTime.Value.Hour, FromTime.Value.Minute, 0)
            toDateTime = New Date(ToDate.Value.Year, ToDate.Value.Month, ToDate.Value.Day, ToTime.Value.Hour, ToTime.Value.Minute, 0)

            Dim IntervalinSecs As Integer = 0
            If CBxInterval_Query.Text = "Days" Then
                IntervalinSecs = CInt(CBxIntervalQuery.Text) * 24 * 60 * 60
            ElseIf CBxInterval_Query.Text = "Hours" Then
                IntervalinSecs = CInt(CBxIntervalQuery.Text) * 60 * 60
            ElseIf CBxInterval_Query.Text = "Minutes" Then
                IntervalinSecs = CInt(CBxIntervalQuery.Text) * 60
            ElseIf CBxInterval_Query.Text = "Seconds" Then
                IntervalinSecs = CInt(CBxIntervalQuery.Text)
            End If


            Dim tmpopcda As HDARedundancy = MainPage.OPCHDAServersCollection.Item(ComBxServer.Text)


            If RBtnRawValue.Checked Then
                rawqueryresult = tmpopcda.GetRawValues(chkitemTags.ToArray(), frmDateTime, toDateTime)
                FillWebChartandGrid(rawqueryresult, chkitemTags.ToArray(), frmDateTime, toDateTime, "", CBxChartType.Text)
            ElseIf RBtnInterval.Checked Then
                Dim lstopc As New List(Of OPCHDAData)
                For Each tg As String In chkitemTags
                    Dim kk = tmpopcda.GetHistoryValuesUsingDateRange(tg, IntervalinSecs, frmDateTime, toDateTime)
                    lstopc.AddRange(kk)
                Next
                rawqueryresult = Newtonsoft.Json.JsonConvert.SerializeObject(lstopc)
                FillWebChartandGrid(rawqueryresult, chkitemTags.ToArray(), frmDateTime, toDateTime, CBxIntervalQuery.Text + " " + CBxInterval_Query.Text, CBxChartType.Text)
            End If

            'System.Diagnostics.Debug.Print(rawqueryresult)

        Catch ex As Exception

        End Try

    End Sub
    Private Function FillWebChartandGrid(ByVal qryresult As String, ByVal tags() As String, ByVal frmtime As DateTime, ByVal totime As DateTime, ByVal interval As String, ByVal chartype As String)
        Try
            Dim pth As String = Application.StartupPath & "\OPCHDA Query\OPCHDAQuery.html"
            ' Dim pfgth As String = Application.StartupPath & "\OPCHDA Query\1.html"
            If IO.File.Exists(pth) Then
                Dim filecontent As String = IO.File.ReadAllText(pth)
                Dim replstr As String = "var GridDataSource =" & qryresult
                filecontent = filecontent.Replace("var GridDataSource =", replstr)

                Dim lstchartseri As New List(Of chartSeries)
                For Each tg In tags
                    lstchartseri.Add(New chartSeries(tg, tg))
                Next

                Dim taglist As String = String.Join(",", tags)
                filecontent = filecontent.Replace("  Tags :", "  Tags :" & taglist)
                filecontent = filecontent.Replace("  From DateTime :", "  From DateTime :" & frmtime.ToString("yyyy/MMM/dd HH:mm"))
                filecontent = filecontent.Replace("  To DateTime :", "  To DateTime :" & totime.ToString("yyyy/MMM/dd HH:mm"))
                filecontent = filecontent.Replace("  Interval :", "  Interval :" & interval)
                filecontent = filecontent.Replace("spline", chartype)

                replstr = Newtonsoft.Json.JsonConvert.SerializeObject(lstchartseri)
                filecontent = filecontent.Replace("var ChartSeries =", "var ChartSeries =" + replstr)
                Dim st As New StringBuilder
                st.Append("[")
                For Each stt As OPCHDAData In Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of OPCHDAData))(qryresult)
                    st.Append("{""" + stt.T + """:""" + stt.V + """")
                    st.Append(",")
                    st.Append("""Time"":""" + stt.D.ToString("yyyy/MMM/dd HH:mm:ss.fff") + """")
                    st.Append("}")
                    st.Append(",")
                Next
                st.Remove(st.Length - 1, 1)
                st.Append("]")
                filecontent = filecontent.Replace("var ChartDataSource =", "var ChartDataSource =" + st.ToString)

                Dim tmppath As String = Application.StartupPath & "\OPCHDA Query\Default.html"
                IO.File.WriteAllText(tmppath, filecontent)


            Else
                MsgBox("There is no file found like " & pth)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub RBtnRawValue_CheckedChanged_1(sender As Object, e As EventArgs) Handles RBtnRawValue.CheckedChanged, RBtnInterval.CheckedChanged
        If RBtnInterval.Checked Then
            Lblinterval.Visible = True
            CBxIntervalQuery.Visible = True
            CBxInterval_Query.Visible = True
        Else
            Lblinterval.Visible = False
            CBxIntervalQuery.Visible = False
            CBxInterval_Query.Visible = False
        End If
    End Sub
End Class
Public Class chartSeries
    Public valueField As String
    Public name As String
    Public Sub New(value_field As String, namefield As String)
        valueField = value_field
        name = namefield
    End Sub
End Class