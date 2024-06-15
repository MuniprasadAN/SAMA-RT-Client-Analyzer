' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-13-2014
'
' Last Modified By : supra
' Last Modified On : 02-12-2014
' ***********************************************************************
' <copyright file="OPC_Serverlist_Form.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************

Imports System.IO
Imports OPC
Imports OPCDA
Imports OPCDA.NET
Imports System.Text
Imports System.Xml
Imports System.Configuration
Public Class OpcServerlistForm
    Dim opcsr As OpcServer = Nothing
    Dim opcitems As AddOpcItems = Nothing
    Private aProgIds As String() = Nothing
    Private OPCServeNames() As String = Nothing
    Private OPCServers() As OpcServer = Nothing

    Private Sub OPC_Serverlist_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        opcsr = Nothing

    End Sub
    Private Sub OPC_Serverlist_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSltOPCitem.Text = ""
        lblSltOPCserver.Text = ""
        AddDefaultNodes()
        btnBrowseOPCItem.Enabled = False
        TreevueOPCServerList.ContextMenuStrip = ContextMenuStrip1
    End Sub
    Private Sub AddDefaultNodes()
        TreevueOPCServerList.ImageList = ImageList1
        'Clear Tree View
        TreevueOPCServerList.Nodes.Clear()
        Dim tvwRoot As TreeNode = New TreeNode()
        tvwRoot.Text = "Localhost        "
        tvwRoot.Name = "Localhost"
        tvwRoot.Tag = "Localhost"

        Try
            If Not MainPage.OPC_ServeNames Is Nothing Then
                For kk As Integer = 0 To MainPage.OPC_ServeNames.Length - 1
                    Dim tvwchild As TreeNode = New TreeNode
                    tvwchild.Text = MainPage.OPC_ServeNames(kk)
                    tvwchild.Name = MainPage.OPC_ServeNames(kk)
                    tvwchild.Tag = MainPage.OPC_ServeNames(kk)
                    tvwRoot.Nodes.Add(tvwchild)
                Next
            Else
                MsgBox("OPC Server Not Available", MsgBoxStyle.Critical, "Warning !!!")
                Exit Sub
            End If

            TreevueOPCServerList.Nodes.Add(tvwRoot)
            For Each node As TreeNode In TreevueOPCServerList.Nodes
                If node.Nodes.Count > 0 Then
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    node.ForeColor = Color.Blue
                    node.NodeFont = New Font("Verdana", 10, FontStyle.Bold)
                    CheckChild(node)
                End If
            Next
            TreevueOPCServerList.ExpandAll()


        Catch ex As Exception
          
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@AddDefaultNodes()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try

        'tmrGetStatus.Enabled = True

    End Sub
    Private Sub CheckChild(ByVal nod As TreeNode)
        For Each node As TreeNode In nod.Nodes
            If node.Nodes.Count > 0 Then
                node.ImageIndex = 1
                node.SelectedImageIndex = 1
                node.ForeColor = Color.OrangeRed
                node.NodeFont = New Font("Verdana", 10, FontStyle.Regular)
                CheckChild(node)
            End If
        Next
    End Sub

    Private Sub btnBrowseOPCItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseOPCItem.Click
        'Dim rts As Integer
        'Try
        '    If TreevueOPCServerList.Nodes.Count>0 Andalso TreevueOPCServerList.Nodes(0).Nodes.Count > 0 AndAlso TreevueOPCServerList.SelectedNode.Parent isnot Nothing AndAlso TreevueOPCServerList.SelectedNode.Parent.Index=0 Then
        '         opcsr = New OpcServer()
        '        For i As Integer = 0 To TreevueOPCServerList.Nodes.Count - 1
        '            If TreevueOPCServerList.Nodes(i).BackColor = Color.LightGreen Then
        '                TreevueOPCServerList.Nodes(i).BackColor = Color.White
        '            End If
        '        Next

        '        rts = opcsr.Connect( "Localhost", TreevueOPCServerList.SelectedNode.Text)
        '        If HRESULTS.Succeeded(rts) Then
        '            TreevueOPCServerList.SelectedNode.BackColor = Color.LightGreen
        '            opcitems = New AddOpcItems(opcsr) 'Call AddOPCItemForm
        '            opcitems.ShowDialog()
        '            If opcitems.Slctitems Is Nothing Then
        '                Exit Sub
        '            End If
        '        End If

        '    End If
        '  Catch ex As Exception
        '  Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@btnBrowseOPCItem_Click()")
        '    Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        '    opcsr = Nothing
        'End Try

        Try
                  
            opcitems = New AddOpcItems(opcsr) 'Call AddOPCItemForm
            opcitems.ShowDialog()
            If opcitems.Slctitems Is Nothing Then
                Exit Sub
            End If
        Catch ex As Exception
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@btnBrowseOPCItem_Click()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
            opcsr = Nothing
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            If Not TreevueOPCServerList Is Nothing AndAlso TreevueOPCServerList.Nodes.Count > 0 Then
                If Not TreevueOPCServerList.SelectedNode Is Nothing AndAlso TreevueOPCServerList.SelectedNode.Index <> -1 Then
                    If Not opcsr Is Nothing Then
                        opcsr.Disconnect()
                    End If
                End If

            End If
            Me.Close()
        Catch ex As Exception
             Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@OPC_ServerlistForm-btnCancel()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try


    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not (Not lblSltOPCserver.Text Is Nothing AndAlso String.IsNullOrEmpty(lblSltOPCserver.Text)) And Not (Not lblSltOPCitem.Text Is Nothing AndAlso String.IsNullOrEmpty(lblSltOPCitem.Text)) Then
            Dim OPCitem() As String=lblSltOPCitem.Text.Split(",")
            If OPCitem.Length>1 Then
                OpcChaneelListForm.GVChannelsAdd.CurrentRow.Cells(8).Value ="True"
            Else
                 OpcChaneelListForm.GVChannelsAdd.CurrentRow.Cells(8).Value ="False"
            End If
            OpcChaneelListForm.GVChannelsAdd.CurrentRow.Cells(3).Value = lblSltOPCserver.Text
            OpcChaneelListForm.GVChannelsAdd.CurrentRow.Cells(4).Value = lblSltOPCitem.Text
            Me.Close()
        Else
            MsgBox("Please Select OPC Server/OPC Item")
        End If

    End Sub

    Private Sub TreevueOPCServerList_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreevueOPCServerList.AfterSelect
        Try
            If TreevueOPCServerList.SelectedNode.Parent Is Nothing Then
                'Do Nothing
            Else
                If TreevueOPCServerList.SelectedNode.Parent.Index = 0 Or
                        TreevueOPCServerList.SelectedNode.Parent.Index = 1 Then
                    If TreevueOPCServerList.SelectedNode.Parent.Index = 1 Then
                        lblSltOPCserver.Text = TreevueOPCServerList.SelectedNode.Parent.Text.Trim() + "^" + TreevueOPCServerList.SelectedNode.Text
                    Else
                        lblSltOPCserver.Text = TreevueOPCServerList.SelectedNode.Text
                    End If
                End If
            End If
            '            If Not TreevueOPCServerList.SelectedNode.Parent Is Nothing _
            '                AndAlso
            'TreevueOPCServerList.SelectedNode.Parent.Index = 0 _
            '                                OrElse
            'TreevueOPCServerList.SelectedNode.Parent.Index = 1 _
            '                Then
            '                If TreevueOPCServerList.SelectedNode.Parent.Index = 1 Then
            '                    lblSltOPCserver.Text = TreevueOPCServerList.SelectedNode.Parent.Text.Trim() + "^" + TreevueOPCServerList.SelectedNode.Text
            '                Else
            '                    lblSltOPCserver.Text = TreevueOPCServerList.SelectedNode.Text
            '                End If

            '            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btnConnect_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnConnect.Click
 Dim rts As Integer
        Try
            If TreevueOPCServerList.Nodes.Count > 0 AndAlso TreevueOPCServerList.Nodes(0).Nodes.Count > 0 _
            AndAlso TreevueOPCServerList.SelectedNode.Parent IsNot Nothing _
            AndAlso (TreevueOPCServerList.SelectedNode.Parent.Index = 0 Or TreevueOPCServerList.SelectedNode.Parent.Index = 1) AndAlso Not String.IsNullOrEmpty(lblSltOPCserver.Text) Then
                opcsr = New OpcServer()

                For i As Integer = 0 To TreevueOPCServerList.Nodes(0).Nodes.Count - 1
                    If TreevueOPCServerList.Nodes(0).Nodes(i).BackColor = Color.LightGreen Then
                        TreevueOPCServerList.Nodes(0).Nodes(i).BackColor = Color.White
                    End If
                Next

                Dim strHostName As String = ""
                If TreevueOPCServerList.SelectedNode.Parent.Text = "Localhost" Then
                    strHostName = System.Net.Dns.GetHostName()
                Else
                    strHostName = TreevueOPCServerList.SelectedNode.Parent.Text.Trim()
                End If


                rts = opcsr.Connect(strHostName, TreevueOPCServerList.SelectedNode.Text)
                If HRESULTS.Succeeded(rts) Then
                    TreevueOPCServerList.SelectedNode.BackColor = Color.LightGreen
                    btnBrowseOPCItem.Enabled = True
                Else
                    MsgBox("Connection failure", MsgBoxStyle.Critical, "Connection Error")
                End If
            Else
                MsgBox("Please Select OPC Any Server", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@btnConnect_Click()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
            opcsr = Nothing
        End Try
End Sub

    Private Sub AddConnectServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddConnectServerToolStripMenuItem.Click
        Dim RemoteOPCServerName As String
        Dim remoteopc As New ConnectOPCServer
        remoteopc.ShowDialog()
        If remoteopc.BtnOK Then
            RemoteOPCServerName = remoteopc.txtbxservername.Text
            GetRemoteopcServers(RemoteOPCServerName)
        End If
    End Sub

    Friend Sub GetRemoteopcServers(ByVal Servername As String)
        Dim srvList As OpcServerBrowser

        Try
            srvList = New OpcServerBrowser(Servername)
        Catch ex As Exception
            If ex.Message.Contains("Create Instance Failed") Then
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning !!!")
                Exit Sub
            End If

        End Try


        Try

            'Get Available  OPC Servers
            If srvList IsNot Nothing Then
                srvList.GetServerList(aProgIds)
                'Check if any thhing Found,If Found Store it in tree view
                If Not aProgIds Is Nothing Then
                    ReDim OPCServeNames(aProgIds.Length - 1)
                    ReDim OPCServers(aProgIds.Length - 1)
                    For kk As Integer = 0 To aProgIds.Length - 1
                        OPCServeNames(kk) = aProgIds(kk)
                    Next
                End If
            End If

            Dim tvwRoot As TreeNode = New TreeNode()
            tvwRoot.Text = Servername + "        "
            tvwRoot.Name = Servername
            tvwRoot.Tag = Servername


            If Not OPCServeNames Is Nothing Then
                For kk As Integer = 0 To OPCServeNames.Length - 1
                    Dim tvwchild As TreeNode = New TreeNode
                    tvwchild.Text = OPCServeNames(kk)
                    tvwchild.Name = OPCServeNames(kk)
                    tvwchild.Tag = OPCServeNames(kk)
                    tvwRoot.Nodes.Add(tvwchild)
                Next
            Else
                MsgBox("OPC Server Not Available", MsgBoxStyle.Critical, "Warning !!!")
                Exit Sub
            End If

            TreevueOPCServerList.Nodes.Add(tvwRoot)
            For Each node As TreeNode In TreevueOPCServerList.Nodes
                If node.Nodes.Count > 0 Then
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    node.ForeColor = Color.Blue
                    node.NodeFont = New Font("Verdana", 10, FontStyle.Bold)
                    CheckChild(node)
                End If
            Next
            TreevueOPCServerList.ExpandAll()




        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GETOPC_Servers()")

        End Try

    End Sub
End Class