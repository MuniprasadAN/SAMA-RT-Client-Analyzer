Imports System.Data.SqlClient

Public Class AnnunciatorPropertiesForm

    Private ColDialog As New ColorDialog
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer
    Private Get__Query_Channel As String = ""
    Private Constr As String = ""
    Friend Channel_Text As String = ""
    Friend Channel_BackColor As Color

    Dim myConnection As New SqlConnection
    Dim sqlcmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim dt As New DataTable

    Public Sub DataFormAnnun(ByVal QuerVAl As String, Q_Constr As String)
        Try
            'DB_Query = QuerVAl
            ' Constr = Q_Constr
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AnnunciatorPropertiesForm()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
    End Sub

    Private slt_Idx As Integer ' = 0

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        AnnunciatorFlow_Properties(MainPage.Annunciator_Ctrl)
    End Sub

    Public Sub AnnunciatorFlow_Properties(ByVal Annunciator_Ctrl As AnnunciatorCtrl)
        Try
            Annunciator_Ctrl.Controls.Clear()
            If txtFlowWidth.Text <> "" And txtFlowHeight.Text <> "" Then
                Annunciator_Ctrl.Width = txtFlowWidth.Text
                Annunciator_Ctrl.Height = txtFlowHeight.Text

            End If
            Annunciator_Ctrl.BackColor = lblCtrlBackColor.BackColor
            For i As Integer = 0 To MainPage.channelList.Channel_Name.Count - 1
                ' Dim asd= MainPage.channelList.Channel_Flag
                Get_Channel_Name = MainPage.channelList.Channel_Name(i)
                If cBoxActionChannel.Text = Get_Channel_Name Then
                    Dim Get__Channel_Query = MainPage.channelList.Channel_Query(i)
                    Dim Get__Channel_Flag = MainPage.channelList.Channel_Flag(i)
                    Get__Query_Channel = MainPage.channelList._Query_Channel(i)
                    Dim Get__RefreshTime = MainPage.channelList.DBChannel_RefreshTime(i)
                    Annunciator_Ctrl.AccessibleDescription = Get_Channel_Name
                End If
            Next
            If Not Get__Query_Channel Is Nothing Then
                Dim TagParam = Get__Query_Channel.Split("^")
                Dim TagVal = TagParam(1).Split(",")

                If Not TagVal Is Nothing Then
                    For i = 0 To TagVal.Length - 1
                        Dim TagNo = TagVal(i).Split("~")
                        Dim Button = New Button_Control
                        Button.Size = New Size(118, 50)
                        Button.BackColor = Color.Gainsboro
                        Button.Tag = TagNo(1).ToString

                        If TagParam(0) = "Tagpar_AliasName" Then
                            Button.Text = TagNo(1) & "   " & TagNo(0)
                        ElseIf TagParam(0) = "AliasName" Then
                            Button.Text = TagNo(0)
                        ElseIf TagParam(0) = "Tagpar" Then
                            Button.Text = TagNo(1)
                        Else
                            Button.Text = TagNo(1).ToString
                        End If
                        Button.Name = TagNo(1).ToString
                        Annunciator_Ctrl.Controls.Add(Button)
                    Next
                End If
            End If

        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AnnunciatorFlow_Properties()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try
        Me.Close()
    End Sub
    'Public Sub CreateAnnunWindow(ByVal query As String, ByVal rfTime As Integer, ByVal name As String)
    '    If query <> "" Then
    '        For i = 0 To query.Length - 1
    '            Dim TagNo = query(i)
    '            Dim Button = New Button
    '            Button.Size = New Size(108, 46)
    '            Button.BackColor = Color.Gainsboro
    '            Button.Tag = TagNo.ToString
    '            Button.Text = TagNo.ToString
    '            'Annunciator_Ctrl.Controls.Add(Button)
    '        Next
    '    End If
    'End Sub

    Private Sub AnnunciatorProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Grid")).ToArray
        DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Annunciator")).ToArray

        cBoxActionChannel.Items.Clear()
        For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
        Next
        cBoxActionChannel.Text = Channel_Text
        cBoxActionChannel.BackColor = Channel_BackColor
    End Sub

    Private Sub cBoxActionChannel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxActionChannel.SelectedIndexChanged

    End Sub

    Private Sub txtFlowWidth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlowWidth.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) <48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFlowHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlowHeight.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) <48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub lblCtrlBackColor_DoubleClick(sender As Object, e As EventArgs) Handles lblCtrlBackColor.DoubleClick
        ColDialog.Color = Color.White

        ColDialog.ShowDialog()
        ColDialog.FullOpen = True
        lblCtrlBackColor.BackColor = ColDialog.Color

    End Sub
    'Private Sub lblActiveColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCtrlBackColor.DoubleClick, lblActiveColor.DoubleClick, forecolorlbl.DoubleClick
    '    ColDialog.ShowDialog()
    '    ColDialog.FullOpen = False
    '    sender.BackColor = ColDialog.Color
    'End Sub
End Class