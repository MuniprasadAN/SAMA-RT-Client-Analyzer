Public Class EditUsersForm
    Public ButtonOk As Boolean
    Friend ScreenName As Integer

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
           

            If Requiredfield() Then
                ButtonOk = True
                Me.Close()
            End If
        Catch ex As Exception
            'Mainpage.insertfilelog(ex.Message)
        End Try
    End Sub

    Private Sub Btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        Me.Close()
    End Sub

    Private Function Requiredfield() As Boolean
        Try
            If txtbxpassword.Text <> txtbxretypepwd.Text Then
                MsgBox(("The Password Doesn't Match!"))
                Return False
            End If

            If accesslistbox.Items.Count < 1 Then
                MsgBox(("Please Select atlease one Access Rule!"))
                Return False
            End If

            'If reportlistbox.Items.Count < 1 Then
            'MsgBox(("Please Select atlease one Report Access Rule!"))
            ' Return False
            ' End If

            Return True

        Catch ex As Exception

        End Try
    End Function

    Private Sub rbtnplant_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnplant.CheckedChanged
        'Mainpage.Explore_DataSources()
        accesslistbox.Items.Clear()
        If rbtnplant.Checked Then
            cbplant.Visible = True
            cbarea.Visible = False
            cbunit.Visible = False
            cbequipment.Visible = False
        End If
        'cbplant.Items.Clear()

        'For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes.Count - 1
        '    cbplant.Items.Add(MainPage.TreeViewLeft.Nodes(0).Nodes(i).Text)
        'Next

    End Sub

    Private Sub rbtnarea_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnarea.CheckedChanged
        'Mainpage.Explore_DataSources()
        accesslistbox.Items.Clear()

        cbplant.Visible = True

        cbarea.Visible = True

       
        cbunit.Visible = False
        cbequipment.Visible = False
        'cbplant.Items.Clear()

        'For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes.Count - 1
        '    cbplant.Items.Add(MainPage.TreeViewLeft.Nodes(0).Nodes(i).Text)
        'Next
    End Sub

    Private Sub rbtnunit_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnunit.CheckedChanged
        'Mainpage.Explore_DataSources()
        accesslistbox.Items.Clear()

        cbplant.Visible = True

        cbarea.Visible = True

        cbunit.Visible = True

        cbequipment.Visible = False

        'Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cbarea.Text, True)
        'If nod.Count > 0 Then
        '    cbunit.Items.Clear()
        '    cbunit.Text = ""
        '    For i As Integer = 0 To nod(0).Nodes.Count - 1
        '        cbunit.Items.Add((nod(0).Nodes(i).Text))
        '    Next
        'End If
        'cbplant.Items.Clear()
        'For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes.Count - 1
        '    cbplant.Items.Add(MainPage.TreeViewLeft.Nodes(0).Nodes(i).Text)
        'Next
    End Sub

    Private Sub rbtnequipment_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnequipment.CheckedChanged
        'Mainpage.Explore_DataSources()
        accesslistbox.Items.Clear()

        cbplant.Visible = True

        cbarea.Visible = True

        cbunit.Visible = True

        cbequipment.Visible = True

        'cbplant.Items.Clear()

        'For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes.Count - 1
        '    cbplant.Items.Add(MainPage.TreeViewLeft.Nodes(0).Nodes(i).Text)
        'Next
    End Sub

    Private Sub cbplant_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbplant.SelectedIndexChanged

        Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cbplant.Text, True)

        Dim asda = cmbScreenName.SelectedIndex
        If nod.Count > 0 Then
            cbarea.Items.Clear()
            cbarea.Text = ""
            For i As Integer = 0 To nod(0).Nodes.Count - 1
                cbarea.Items.Add((nod(0).Nodes(i).Text))
            Next
        End If

        'Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cmbScreenName.Text, True)
        'If nod.Count > 0 Then
        '    cbarea.Items.Clear()
        '    cbarea.Text = ""
        '    For i As Integer = 0 To nod(0).Nodes.Count - 1
        '        cbarea.Items.Add((nod(0).Nodes(i).Text))
        '    Next
        'End If

    End Sub

    Private Sub cbarea_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbarea.SelectedIndexChanged
        Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cbarea.Text, True)
        If nod.Count > 0 Then
            cbunit.Items.Clear()
            cbunit.Text = ""
            For i As Integer = 0 To nod(0).Nodes.Count - 1
                cbunit.Items.Add((nod(0).Nodes(i).Text))
            Next
        End If
    End Sub
    Private Sub cbunit_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbunit.SelectedIndexChanged
        Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cbunit.Text, True)
        If nod.Count > 0 Then
            cbequipment.Items.Clear()
            cbequipment.Text = ""
            For i As Integer = 0 To nod(0).Nodes.Count - 1
                cbequipment.Items.Add((nod(0).Nodes(i).Text))
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If rbtnplant.Checked Then
            Dim str As String = cmbScreenName.Text + "~" + cbplant.Text
            If Not accesslistbox.Items.Contains(str) Then
                accesslistbox.Items.Add(str)
            End If
        End If

        If rbtnarea.Checked Then
            Dim str As String = cmbScreenName.Text + "~" + cbplant.Text + "~" + cbarea.Text
            If Not accesslistbox.Items.Contains(str) Then
                accesslistbox.Items.Add(str)
            End If
        End If

        If rbtnunit.Checked Then
            Dim str As String = cmbScreenName.Text + "~" + cbplant.Text + "~" + cbarea.Text + "~" + cbunit.Text
            If Not accesslistbox.Items.Contains(str) Then
                accesslistbox.Items.Add(str)
            End If
        End If

        If rbtnequipment.Checked Then
            Dim str As String = cmbScreenName.Text + "~" + cbplant.Text + "~" + cbarea.Text + "~" + cbunit.Text + "~" + cbequipment.Text
            If Not accesslistbox.Items.Contains(str) Then
                accesslistbox.Items.Add(str)
            End If
        End If

    End Sub


    Private Sub accesslistbox_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles accesslistbox.MouseDoubleClick
        If accesslistbox.SelectedIndex <> -1 Then
            accesslistbox.Items.RemoveAt(accesslistbox.SelectedIndex)
        End If
    End Sub


    Private Sub rbtnsuperadmin_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnsuperadmin.CheckedChanged
        GroupBox2.Visible = False

    End Sub

    Private Sub RBtnSimple_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RBtnSimple.CheckedChanged
        GroupBox2.Visible = True

    End Sub

    Private Sub RBtnAdmin_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RBtnAdmin.CheckedChanged
        GroupBox2.Visible = True

    End Sub

    Private Sub RBtnPower_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RBtnPower.CheckedChanged
        GroupBox2.Visible = True

    End Sub

    Private Sub accesslistbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles accesslistbox.SelectedIndexChanged

    End Sub

    Private Sub cmbScreenName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbScreenName.SelectedIndexChanged
        ScreenName = cmbScreenName.SelectedIndex
        Dim nod As TreeNode() = MainPage.TreeViewLeft.Nodes.Find(cmbScreenName.Text, True)
        If nod.Count > 0 Then
            cbplant.Items.Clear()
            cbplant.Text = ""
            For i As Integer = 0 To nod(0).Nodes.Count - 1
                Dim asdasd = cmbScreenName.SelectedIndex
                cbplant.Items.Add((nod(0).Nodes(i).Text))
            Next
        End If
    End Sub

    Private Sub rtbScreenname_CheckedChanged(sender As Object, e As EventArgs) Handles rtbScreenname.CheckedChanged
        MainPage.Explore_DataSources()
        accesslistbox.Items.Clear()

        cmbScreenName.Visible = True

        cbplant.Visible = False

        cbarea.Visible = False

        cbunit.Visible = False

        cbequipment.Visible = False

        cmbScreenName.Items.Clear()

        For i As Integer = 0 To MainPage.TreeViewLeft.Nodes(0).Nodes.Count - 1
            cmbScreenName.Items.Add(MainPage.TreeViewLeft.Nodes(0).Nodes(i).Text)
        Next
    End Sub

    Private Sub EditUsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cmbScreenName.Visible = True

        'cbplant.Visible = False

        'cbarea.Visible = False

        'cbunit.Visible = False

        'cbequipment.Visible = False
    End Sub

    Private Sub cbequipment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbequipment.SelectedIndexChanged

    End Sub
End Class