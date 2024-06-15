' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="pageProperties.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Public Class PageProperties
    Dim ColDialog As New ColorDialog
    Dim idx As String = MainPage.SltPageIndex
    Dim PageLimit As Integer = 20
    Private Sub BGColorLbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGColorLbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        BGColorLbl.BackColor = ColDialog.Color
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Not Me.Text = "Page Add" Then
            If  (Not txtPageName.Text Is Nothing AndAlso Not String.IsNullOrEmpty(txtPageName.Text)) Then
                If MainPage.pageprevname = txtPageName.Text Then
                    Dim pnl_pg() As Control
                    pnl_pg = MainPage.Controls.Find(idx, True)
                    If Not pnl_pg Is Nothing AndAlso Not pnl_pg(0) Is Nothing Then
                        pnl_pg(0).BackColor = BGColorLbl.BackColor
                        pnl_pg(0).Name = txtPageName.Text
                    End If
                    MainPage.TreeViewLeft.SelectedNode.Text = txtPageName.Text
                    MainPage.TreeViewLeft.SelectedNode.Name = txtPageName.Text
                    Me.Close()
                Else
                    If Not MainPage.CreatedPages.Contains(txtPageName.Text) Then
                        Dim pnl_pg() As Control
                        pnl_pg = MainPage.Controls.Find(idx, True)
                        If Not pnl_pg Is Nothing AndAlso Not pnl_pg(0) Is Nothing Then
                            pnl_pg(0).BackColor = BGColorLbl.BackColor
                            pnl_pg(0).Name = txtPageName.Text
                        End If
                        MainPage.TreeViewLeft.SelectedNode.Text = txtPageName.Text
                        MainPage.TreeViewLeft.SelectedNode.Name = txtPageName.Text

                        MainPage.CreatedPages.Remove(MainPage.pageprevname)
                        MainPage.CreatedPages.Add(txtPageName.Text)
                        Me.Close()
                    Else
                        MsgBox("The Page Name you have Entered Alread Exist.....!!!")
                    End If
                End If
            Else
                MsgBox("Enter the Page Name.....!!!")
            End If
        Else
            'If Not MainPage.TreeViewLeft.Nodes(0).Nodes.Count >= PageLimit Then
            If Not MainPage.CreatedPages.Contains(txtPageName.Text) Then


                If Not (Not txtPageName.Text Is Nothing AndAlso String.IsNullOrEmpty(txtPageName.Text)) Then

                    'MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Add(txtPageName.Text)
                    'MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1).Name = txtPageName.Text
                    'MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1).ImageIndex = 3
                    'MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes(MainPage.PageTreeView.Nodes(0).Nodes(2).Nodes.Count - 1).SelectedImageIndex = 3

                    MainPage.TreeViewLeft.SelectedNode.Nodes.Insert(0, txtPageName.Text)
                    MainPage.TreeViewLeft.SelectedNode.Nodes(0).Name = txtPageName.Text
                    MainPage.TreeViewLeft.SelectedNode.Nodes(0).Tag = "PageNode"
                    MainPage.TreeViewLeft.SelectedNode.Nodes(0).ImageIndex = 7
                    MainPage.TreeViewLeft.SelectedNode.Nodes(0).SelectedImageIndex = 7


                    'MainPage.TreeViewLeft.SelectedNode.Nodes.Add(txtPageName.Text)
                    'MainPage.TreeViewLeft.SelectedNode.Nodes(MainPage.TreeViewLeft.SelectedNode.Nodes.Count - 1).Name = txtPageName.Text
                    'MainPage.TreeViewLeft.SelectedNode.Nodes(MainPage.TreeViewLeft.SelectedNode.Nodes.Count - 1).Tag = "PageNode"
                    'MainPage.TreeViewLeft.SelectedNode.Nodes(MainPage.TreeViewLeft.SelectedNode.Nodes.Count - 1).ImageIndex = 7
                    'MainPage.TreeViewLeft.SelectedNode.Nodes(MainPage.TreeViewLeft.SelectedNode.Nodes.Count - 1).SelectedImageIndex = 7



                    Dim cnt As String = txtPageName.Tag
                    Dim pnlObj() As Control
                    pnlObj = MainPage.Controls.Find("pnlPage" & cnt + 1, True)
                    If Not pnlObj Is Nothing AndAlso pnlObj.Length > 0 Then
                        pnlObj(0).Name = txtPageName.Text
                        pnlObj(0).BackColor = BGColorLbl.BackColor
                    End If
                    MainPage.CreatedPages.Add(txtPageName.Text)
                    MainPage._iniPageName += 1
                    MainPage.TreeViewLeft.SelectedNode = MainPage.TreeViewLeft.SelectedNode.LastNode
                    Me.Close()
                Else
                    MsgBox("Enter the Page Name.....!!!")
                End If
                ' Else
                ' MsgBox("Page Limit Exceed Contact Supra Controls Pvt Ltd !!!", MsgBoxStyle.Information)
                'End If
            Else
                MsgBox("The Given Page Name Already Exist! Please Choose Different Name", MsgBoxStyle.Information)
            End If
        End If

        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class