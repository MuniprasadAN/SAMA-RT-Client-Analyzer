Public Class UsersForm
    Dim ds As DataSet
    Dim dt As DataTable
    Dim dr As DataRow

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click


        Try
            Dim adduser As New EditUsersForm
            adduser.Text = "New User"
            adduser.ShowDialog()
            If adduser.ButtonOk Then

                If Not IO.File.Exists(Application.StartupPath & "\UsersConfig.xml") Then
                    ds = New DataSet
                    dt = New DataTable
                    dt.Columns.Add(New DataColumn("SerialNo", Type.GetType("System.String")))
                    dt.Columns.Add(New DataColumn("Username", Type.GetType("System.String")))
                    dt.Columns.Add(New DataColumn("Password", Type.GetType("System.String")))
                    dt.Columns.Add(New DataColumn("RetypePassword", Type.GetType("System.String")))
                    dt.Columns.Add(New DataColumn("IsSimple", Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("IsPower", Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("IsAdmin", Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("IsSuperAdmin", Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("Accesslevel", Type.GetType("System.String")))
                    dt.Columns.Add(New DataColumn("Accessrules", Type.GetType("System.String")))

                    dt.Columns(0).AutoIncrementSeed = 1
                    dt.Columns(0).AutoIncrement = True
                    dr = dt.NewRow()

                    dr("Username") = adduser.txtbxUsername.Text
                    dr("Password") = adduser.txtbxpassword.Text
                    dr("RetypePassword") = adduser.txtbxretypepwd.Text
                    If adduser.RBtnSimple.Checked Then
                        dr("IsSimple") = "True"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.RBtnPower.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "True"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.RBtnAdmin.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "True"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.rbtnsuperadmin.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "True"
                    End If

                    If adduser.rbtnsuperadmin.Checked Then
                        dr("Accesslevel") = "All"
                        dr("Accessrules") = "All"
                        dr("ReportAccess") = "All"
                    Else
                        If adduser.rbtnplant.Checked Then
                            dr("Accesslevel") = "Plant"
                        ElseIf adduser.rbtnarea.Checked Then
                            dr("Accesslevel") = "Area"
                        ElseIf adduser.rbtnunit.Checked Then
                            dr("Accesslevel") = "Unit"
                        ElseIf adduser.rbtnequipment.Checked Then
                            dr("Accesslevel") = "Equipment"
                        End If

                        Dim accessrules As String = ""
                        For i As Integer = 0 To adduser.accesslistbox.Items.Count - 1
                            accessrules &= " / " & adduser.accesslistbox.Items(i).ToString
                        Next
                        dr("Accessrules") = accessrules
                       
                    End If


                    dt.Rows.Add(dr)
                    ds.Tables.Add(dt)
                    DGViewUsers.DataSource = dt
                Else
                    ds = New DataSet
                    ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
                    dt = ds.Tables(0)
                    dr = dt.NewRow()

                    dr("Username") = adduser.txtbxUsername.Text
                    dr("Password") = adduser.txtbxpassword.Text
                    dr("RetypePassword") = adduser.txtbxretypepwd.Text
                    If adduser.RBtnSimple.Checked Then
                        dr("IsSimple") = "True"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.RBtnPower.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "True"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.RBtnAdmin.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "True"
                        dr("IsSuperAdmin") = "False"
                    ElseIf adduser.rbtnsuperadmin.Checked Then
                        dr("IsSimple") = "False"
                        dr("IsPower") = "False"
                        dr("IsAdmin") = "False"
                        dr("IsSuperAdmin") = "True"
                    End If

                    If adduser.rbtnsuperadmin.Checked Then
                        dr("Accesslevel") = "All"
                        dr("Accessrules") = "All"
                        dr("ReportAccess") = "All"
                    Else
                        If adduser.rbtnplant.Checked Then
                            dr("Accesslevel") = "Plant"
                        ElseIf adduser.rbtnarea.Checked Then
                            dr("Accesslevel") = "Area"
                        ElseIf adduser.rbtnunit.Checked Then
                            dr("Accesslevel") = "Unit"
                        ElseIf adduser.rbtnequipment.Checked Then
                            dr("Accesslevel") = "Equipment"
                        End If

                        Dim accessrules As String = ""
                        For i As Integer = 0 To adduser.accesslistbox.Items.Count - 1
                            accessrules &= adduser.accesslistbox.Items(i).ToString & " / "
                        Next
                        dr("Accessrules") = accessrules

                       

                    End If

                    dt.Rows.Add(dr)
                    DGViewUsers.DataSource = dt
                End If

                ds.WriteXml(Application.StartupPath & "\UsersConfig.xml", XmlWriteMode.WriteSchema)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UsersForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(Application.StartupPath & "\UsersConfig.xml") Then
                ds = New DataSet
                ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
                dt = ds.Tables(0)
                DGViewUsers.DataSource = dt
            End If
        Catch ex As Exception
            'MainPage.insertfilelog(ex.Message)
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Try
            Dim edituser As New EditUsersForm
            edituser.Text = "Edit User"
            Dim _SerialNo As String = DGViewUsers.CurrentRow.Cells("SerialNo").Value
            edituser.txtbxUsername.Text = DGViewUsers.CurrentRow.Cells("Username").Value
            edituser.txtbxpassword.Text = DGViewUsers.CurrentRow.Cells("Password").Value
            edituser.txtbxretypepwd.Text = DGViewUsers.CurrentRow.Cells("RetypePassword").Value
            If (Not IsDBNull(DGViewUsers.CurrentRow.Cells("IsSimple").Value)) And (DGViewUsers.CurrentRow.Cells("IsSimple").Value = "True") Then
                edituser.RBtnSimple.Checked = True
            ElseIf (Not IsDBNull(DGViewUsers.CurrentRow.Cells("IsPower").Value)) And (DGViewUsers.CurrentRow.Cells("IsPower").Value = "True") Then
                edituser.RBtnPower.Checked = True
            ElseIf (Not IsDBNull(DGViewUsers.CurrentRow.Cells("IsAdmin").Value)) And (DGViewUsers.CurrentRow.Cells("IsAdmin").Value = "True") Then
                edituser.RBtnAdmin.Checked = True
            ElseIf (Not IsDBNull(DGViewUsers.CurrentRow.Cells("IsSuperAdmin").Value)) And (DGViewUsers.CurrentRow.Cells("IsSuperAdmin").Value = "True") Then
                edituser.rbtnsuperadmin.Checked = True
            End If

            If edituser.rbtnsuperadmin.Checked Then
                edituser.GroupBox2.Visible = False
            Else
                edituser.rtbScreenname.Checked = True
                If DGViewUsers.CurrentRow.Cells("Accesslevel").Value = "Plant" Then
                    edituser.rbtnplant.Checked = True
                ElseIf DGViewUsers.CurrentRow.Cells("Accesslevel").Value = "Area" Then
                    edituser.rbtnarea.Checked = True
                ElseIf DGViewUsers.CurrentRow.Cells("Accesslevel").Value = "Unit" Then
                    edituser.rbtnunit.Checked = True
                ElseIf DGViewUsers.CurrentRow.Cells("Accesslevel").Value = "Equipment" Then
                    edituser.rbtnequipment.Checked = True
                End If

                Dim access_str As String = DGViewUsers.CurrentRow.Cells("Accessrules").Value
                Dim splstr() As String = access_str.Split("/")
                For Each item In splstr
                    If Not IsDBNull(item) And item <> "" Then
                        Dim AimsVal = item.Split("~")
                        edituser.accesslistbox.Items.Add(item)
                    End If
                Next
            End If

            edituser.ShowDialog()
            If edituser.ButtonOk Then
                ds = New DataSet
                ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
                dt = ds.Tables(0)
                Dim datarow() As DataRow
                datarow = dt.Select("SerialNo=" & _SerialNo)
                dr = datarow(0)
                dr("Username") = edituser.txtbxUsername.Text
                dr("Password") = edituser.txtbxpassword.Text
                dr("RetypePassword") = edituser.txtbxretypepwd.Text
                If edituser.RBtnSimple.Checked Then
                    dr("IsSimple") = "True"
                    dr("IsPower") = "False"
                    dr("IsAdmin") = "False"
                    dr("IsSuperAdmin") = "False"
                ElseIf edituser.RBtnPower.Checked Then
                    dr("IsSimple") = "False"
                    dr("IsPower") = "True"
                    dr("IsAdmin") = "False"
                    dr("IsSuperAdmin") = "False"
                ElseIf edituser.RBtnAdmin.Checked Then
                    dr("IsSimple") = "False"
                    dr("IsPower") = "False"
                    dr("IsAdmin") = "True"
                    dr("IsSuperAdmin") = "False"
                ElseIf edituser.rbtnsuperadmin.Checked Then
                    dr("IsSimple") = "False"
                    dr("IsPower") = "False"
                    dr("IsAdmin") = "False"
                    dr("IsSuperAdmin") = "True"
                End If


                If edituser.rbtnplant.Checked Then
                    dr("Accesslevel") = "Plant"
                ElseIf edituser.rbtnarea.Checked Then
                    dr("Accesslevel") = "Area"
                ElseIf edituser.rbtnunit.Checked Then
                    dr("Accesslevel") = "Unit"
                ElseIf edituser.rbtnequipment.Checked Then
                    dr("Accesslevel") = "Equipment"
                End If

                Dim accessrules As String = ""
                For i As Integer = 0 To edituser.accesslistbox.Items.Count - 1
                    If Not IsDBNull(edituser.accesslistbox.Items(i)) Then
                        accessrules &= edituser.accesslistbox.Items(i).ToString & "/"
                    End If
                Next
                dr("Accessrules") = accessrules
              
                DGViewUsers.DataSource = dt
                ds.WriteXml(Application.StartupPath & "\UsersConfig.xml", XmlWriteMode.WriteSchema)
            End If
        Catch ex As Exception
            'MainPage.insertfilelog(ex.Message)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Dim currentrowindx As Integer = DGViewUsers.CurrentRow.Index
            ds = New DataSet
            ds.ReadXml(Application.StartupPath & "\UsersConfig.xml", XmlReadMode.ReadSchema)
            dt = ds.Tables(0)

            dt.Rows(currentrowindx).Delete()
            DGViewUsers.DataSource = dt
            ds.WriteXml(Application.StartupPath & "\UsersConfig.xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception
            'MainPage.insertfilelog(ex.Message)
        End Try
    End Sub

End Class