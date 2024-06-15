Public Class SAMAHistorianChannelDataform
    Private _datatable As New DataTable
    Private _Indx As New Integer
    Private Formname As String

    Dim redun As Redundancy, indx As Integer
    Public Sub New(ByVal redunc As Redundancy, ByVal indxx As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        redun = redunc
        indx = indxx
        Dim mytime As New Timer
        mytime.Interval = 1000
        AddHandler mytime.Tick, AddressOf RefreshMultiTagsOPCDA
        mytime.Start()

    End Sub

    Private Sub RefreshMultiTagsOPCDA(ByVal sen As Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable


        Try
                For Each tg As String In Split(MainPage.OPCDAChannelsList.OPC_OPCItems(indx), ",")
                    If redun.opctg.ContainsKey(tg) Then
                        If dt.Columns.Count = 0 Then
                            dt.Columns.Add("TagName")

                            For Each dc As DataColumn In redun.opctg(tg).opcdt.Columns
                                dt.Columns.Add(dc.ColumnName)
                            Next
                        End If
                        If redun.opctg(tg).opcdt.Rows.Count > 0 Then
                            Dim dr As DataRow = redun.opctg(tg).opcdt.Rows(0)
                            Dim dr1 As DataRow = dt.NewRow
                            dr1("TagName") = tg
                            For Each dcc As DataColumn In redun.opctg(tg).opcdt.Columns
                                dr1(dcc.ColumnName) = dr(dcc.ColumnName)
                            Next
                            dt.Rows.Add(dr1)
                        Else
                            Dim dr As DataRow = dt.NewRow
                            dr("TagName") = tg
                            dt.Rows.Add(dr)
                        End If

                    End If
                Next
            Catch ex As Exception

            End Try


        DGDataform.DataSource = dt

    End Sub
    Public Sub New(ByVal dt As DataTable, _frmname As String)
        InitializeComponent()
        _datatable = dt
        Formname = _frmname

        DGDataform.DataSource = _datatable
        Me.Text = Formname
    End Sub
    Public Sub New(ByVal indx As Integer, _frmname As String)
        InitializeComponent()
        _Indx = indx
        Formname = _frmname
        Me.Text = Formname
        RefreshMultiTagsOPCHDA(Nothing, Nothing)
        Dim mytime As New Timer
        mytime.Interval = 5000
        AddHandler mytime.Tick, AddressOf RefreshMultiTagsOPCHDA
        mytime.Start()
    End Sub
    Private Sub RefreshMultiTagsOPCHDA(ByVal sen As Object, ByVal e As System.EventArgs)
        Try

            Dim dt As New DataTable
            Dim lstofDT As New List(Of DataTable)
            Dim tmpopcda As HDARedundancy = MainPage.OPCHDAServersCollection.Item(MainPage.OPCHDAChannelsList.OPC_ServerName(_Indx))
            For Each tg As String In Split(MainPage.OPCHDAChannelsList.OPC_OPCItems(_Indx), ",")
                If tmpopcda.opctg.ContainsKey(tg.ToString() + MainPage.OPCHDAChannelsList.OPC_Channel_Name(_Indx).ToString()) Then
                    lstofDT.Add(tmpopcda.opctg(tg.ToString() + MainPage.OPCHDAChannelsList.OPC_Channel_Name(_Indx).ToString()).opcdt)

                End If
            Next
            dt = MultiDttoOne(lstofDT, MainPage.OPCHDAChannelsList.OPC_XAxis(_Indx).ToString())



        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorianChannelDataform_RefreshMultiTagsOPCHDA")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub
    Private Function MultiDttoOne(ByVal lstdt As List(Of DataTable), ByVal xaxis As String) As DataTable


        Dim outdt As New DataTable
        Try
            If xaxis = "Tags" Then
                outdt.Columns.Clear()
                outdt.Columns.Add("DateTime", Type.GetType("System.DateTime"))


                For Each dtt As DataTable In lstdt

                    outdt.Columns.Add(dtt.TableName)
                    For Each dr As DataRow In dtt.Rows
                        Dim dr1() As DataRow = outdt.Select("DateTime='" & dr("TimeStamp") & "'")

                        If dr1.Length = 0 Then
                            Dim dr2 As DataRow = outdt.NewRow
                            dr2("DateTime") = dr("TimeStamp")
                            dr2(dtt.TableName) = dr("Value")
                            outdt.Rows.Add(dr2)
                        Else
                            dr1(0)(dtt.TableName) = dr("Value")
                            outdt.AcceptChanges()
                        End If
                    Next
                    outdt.AcceptChanges()
                Next


                DGDataform.DataSource = outdt

            ElseIf xaxis = "DateTime" Then

                outdt.Columns.Clear()
                outdt.Columns.Add("TagName", Type.GetType("System.String"))

                For Each dtt As DataTable In lstdt

                    Dim dr1() As DataRow = outdt.Select("TagName='" & dtt.TableName & "'")
                    If dr1.Length = 0 Then
                        Dim dr2 As DataRow = outdt.NewRow
                        dr2("TagName") = dtt.TableName
                        outdt.Rows.Add(dr2)
                    End If
                    outdt.AcceptChanges()
                    Dim Curdr As DataRow = outdt.Select("TagName='" & dtt.TableName & "'")(0)
                    For Each dr As DataRow In dtt.Select("", "TimeStamp desc")

                        If outdt.Columns.Contains(dr("TimeStamp")) Then
                            Curdr(dr("TimeStamp")) = dr("Value")
                        Else
                            outdt.Columns.Add(dr("TimeStamp"))
                            Curdr(dr("TimeStamp")) = dr("Value")
                            outdt.AcceptChanges()
                        End If
                        outdt.AcceptChanges()
                    Next

                Next
                DGDataform.Columns.Clear()
                DGDataform.DataSource = outdt
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@SAMAHistorianChannelDataform_MultiDttoOne")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            'MainPage._errLog.Add(ex.Message)
        End Try

        Return outdt
    End Function
    Private Sub SAMAHistorianChannelDataform_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class