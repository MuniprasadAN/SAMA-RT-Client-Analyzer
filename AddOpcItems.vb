Imports System.Runtime.InteropServices
Imports System.IO
Imports OPC
Imports OPCDA
Imports OPCDA.NET
Imports System.Text
Imports System.Xml
Imports System.Configuration
Public Class AddOpcItems
    Dim opcsr As OpcServer
    Public Slctitems()
    Dim ItemBrwseTree As BrowseTree
    Dim datatypefltr As String = ""
   
    Dim Show_Tree As  ShowBrowseTree


    Public Sub New(ByVal srv As OpcServer)


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        opcsr = srv

        datatypefltr = "System.Void"
      
    End Sub
    ''' <summary>
    ''' Show the OPC Configured Tags and Alises
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Getdetails()
        Try
            ' ItemBrwseTree = New BrowseTree(opcsr)

            ' Dim rtc As Integer = ItemBrwseTree.CreateTree()  ' Browse se1rver from root
            'If HRESULTS.Failed(rtc) Then
            '    MsgBox("Error " & rtc.ToString() + " at browsing the server.")
            'End If
            ' ItemBrwseTree.BrowseModeOneLevel= True
            'trvwOPCGroups.Nodes.Clear()
            'trvwOPCGroups.ImageList = ItemBrwseTree.ImageList
            'trvwOPCGroups.Nodes.AddRange(ItemBrwseTree.Root)
            
            Show_Tree=opcsr.ShowBrowseTree(trvwOPCGroups)
            Show_Tree.BrowseModeOneLevel=True
             Dim rtc As Integer = Show_Tree.Show()  
            If HRESULTS.Failed(rtc) Then
                 MsgBox("Error " & rtc.ToString() + " at browsing the server.")
            End If
           
        Catch ex As Exception

        End Try
       
    End Sub
    Private Sub trvwOPCGroups_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvwOPCGroups.NodeMouseDoubleClick
'Try
'         Dim sel As TreeNode
'        sel = e.Node
'        If ItemBrwseTree.isItem(sel) Then
'            If cboxMultiview.Checked Then
'                If Not lblSltOPCitem.Text.Contains(ItemBrwseTree.ItemName(sel)) Then
'                    If lblSltOPCitem.Text="" Then
'                        lblSltOPCitem.Text  = (ItemBrwseTree.ItemName(sel))
'                    Else
'                        lblSltOPCitem.Text & = "," &(ItemBrwseTree.ItemName(sel))
'                    End If

'                End If

'            Else
'                lblSltOPCitem.Text = (ItemBrwseTree.ItemName(sel))
'            End If

'        End If

'Catch ex As Exception

'End Try
       
        Try
          
            If cboxMultiview.Checked Then
                If Not lblSltOPCitem.Text.Contains(e.Node.Tag.ToString) Then
                    If lblSltOPCitem.Text="" Then
                        lblSltOPCitem.Text  = (e.Node.Tag.ToString)
                    Else
                        lblSltOPCitem.Text & = "," &(e.Node.Tag.ToString)
                    End If
                    
                End If
                
            Else
                lblSltOPCitem.Text = (e.Node.Tag.ToString)
            End If
            
        

Catch ex As Exception
    MsgBox("Error While Browsing...",MsgBoxStyle.Critical)
End Try


    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not (Not lblSltOPCitem.Text Is Nothing AndAlso String.IsNullOrEmpty(lblSltOPCitem.Text)) Then
            OpcServerlistForm.lblSltOPCitem.Text = lblSltOPCitem.Text
            Me.Close()
        Else
            MsgBox("Please Select Any OPC Item")
        End If
       
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Add_OPCItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSltOPCitem.Text = ""
        Me.Text = OpcServerlistForm.lblSltOPCserver.Text
    End Sub

Private Sub cboxMultiview_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles cboxMultiview.CheckedChanged
        lblSltOPCitem.Text=""
End Sub

Private Sub AddOpcItems_Shown( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Shown
         Getdetails()
End Sub
End Class