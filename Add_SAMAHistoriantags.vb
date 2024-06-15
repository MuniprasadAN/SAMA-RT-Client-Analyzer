Imports System.IO

Public Class Add_SAMAHistoriantags
    Private _taglist As New ArrayList
    Public Sub New(byval taglist As ArrayList)
        InitializeComponent()
        _taglist = taglist
    End Sub
Private Sub Add_SAMAHistoriantags_Load_1( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load

        GenerateTreeView(_taglist)
End Sub
    Private Sub GenerateTreeView(ByVal ar As ArrayList)

        trvwHistoriangroups.Nodes.Clear()
        Dim n As TreeNode = Nothing, isavail As Integer = -1
        For Each s As String In ar


            Dim val1 = s.Substring(InStr(s, "."))
            Dim val = s.Split(".")(0)
            isavail = -1
            'Debug.Print(val)

            Searchnode(trvwHistoriangroups.Nodes, val, isavail, n)

            If isavail = -1 Then

                Dim nn As TreeNode = trvwHistoriangroups.Nodes.Add(val, val)
                nn.Nodes.Add(val1, val1)

            Else
                n.Nodes.Add(val1, val1)
            End If

        Next

    End Sub


    Private Sub Searchnode(ByVal chldNodes As TreeNodeCollection, ByVal NodeName As String, ByRef res As Integer, ByRef resnode As TreeNode)

        'Search the Selected Node 

        For Each nd As TreeNode In chldNodes

            If nd.Text = NodeName Then
                resnode = nd
                res = nd.Index
                'nd.BackColor = Color.Green
            End If

            If nd.Nodes.Count > 0 Then
                Searchnode(nd.Nodes, NodeName, res, resnode)
            End If
        Next

    End Sub

     Private Sub trvwHistoriangroups_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvwHistoriangroups.NodeMouseDoubleClick
        Try
            If e.Node.GetNodeCount(True) > 0 Then
                Exit Sub
            End If

            If lstbxSelectedTags.Items.Count >= 10 Then
                MsgBox("You can add only 10 Tags!")
                Exit Sub
            End If

            If e.Node.FullPath <> "" Then
                lstbxSelectedTags.Items.Add(e.Node.FullPath)
            End If

        Catch ex As Exception
            MsgBox("Error While Browsing...", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If lstbxSelectedTags.Items.Count <> lstbxseltopr.Items.Count Then
                MsgBox("Please check the number of tags and operations are equal!")
                Exit Sub
            End If

            Dim selected_tag As New List(Of String)
            Dim selectdoperations As New List(Of String)
            For i As Integer = 0 To lstbxSelectedTags.Items.Count - 1
                selected_tag.Add(lstbxSelectedTags.Items(i).ToString())
            Next
            For i As Integer = 0 To lstbxseltopr.Items.Count - 1
                selectdoperations.Add(lstbxseltopr.Items(i).ToString())
            Next

            SAMAHistorianChannels.GVChannelsAdd.CurrentRow.Cells(4).Value = String.Join(",", selected_tag.ToArray())
            SAMAHistorianChannels.GVChannelsAdd.CurrentRow.Cells(8).Value = String.Join(",", selectdoperations.ToArray())
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

   

Private Sub btnCancel_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.Close()
End Sub

  
    Private Sub lstbxSelectedTags_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxSelectedTags.MouseDoubleClick
      
        If Not lstbxSelectedTags.SelectedItem Is Nothing Then
            lstbxSelectedTags.Items.Remove(lstbxSelectedTags.SelectedItem)
        End If
    End Sub

    Private Sub lstbxavloperations_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxavloperations.MouseDoubleClick
        If lstbxseltopr.Items.Count >= lstbxSelectedTags.Items.Count Then
            MsgBox("You can add Any one operation for each tag!")
            Exit Sub
        End If

        If Not lstbxavloperations.SelectedItem Is Nothing Then
            lstbxseltopr.Items.Add(lstbxavloperations.SelectedItem)
        End If
    End Sub

    Private Sub lstbxseltopr_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstbxseltopr.MouseDoubleClick
        If Not lstbxseltopr.SelectedItem Is Nothing Then
            lstbxseltopr.Items.Remove(lstbxseltopr.SelectedItem)
        End If
    End Sub
End Class