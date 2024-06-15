Imports System.Reflection

Public Class LogCtrlProperties

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Try
        If Not String.IsNullOrEmpty(cboxOption.Text) AndAlso Not String.IsNullOrEmpty(txtPath.Text) AndAlso Not String.IsNullOrEmpty(cboxExtension.Text) Then
            If txtdelimiter.Enabled Then
                If String.IsNullOrEmpty(txtdelimiter.Text) Then
                    MsgBox("Delimiter Should not Empty!!", MsgBoxStyle.Information)
                    Exit Sub
                End If

            End If

            Select Case cboxExtension.Text
                Case ".txt"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadTextFile(txtPath.Text, False, nudnnhours.Value)
                    Else
                        MainPage.LogCtrl.LoadTextFile(txtPath.Text, True, 1)
                    End If
                Case ".csv"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadCSVFile(txtPath.Text, False, nudnnhours.Value, txtdelimiter.Text)
                    Else
                        MainPage.LogCtrl.LoadCSVFile(txtPath.Text, True, 1, txtdelimiter.Text)
                    End If
                Case ".xls"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadExcelFile(txtPath.Text, False, nudnnhours.Value, ".xls")
                    Else
                        MainPage.LogCtrl.LoadExcelFile(txtPath.Text, True, 1, ".xls")
                    End If
                Case ".xlsx"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadExcelFile(txtPath.Text, False, nudnnhours.Value, ".xlsx")
                    Else
                        MainPage.LogCtrl.LoadExcelFile(txtPath.Text, True, 1, ".xlsx")
                    End If
                Case ".html"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadHTMLFile(txtPath.Text, False, nudnnhours.Value)
                    Else
                        MainPage.LogCtrl.LoadHTMLFile(txtPath.Text, True, 1)
                    End If
                Case ".xml"
                    If nudnnhours.Enabled Then
                        MainPage.LogCtrl.LoadXMLFile(txtPath.Text, False, nudnnhours.Value)
                    Else
                        MainPage.LogCtrl.LoadXMLFile(txtPath.Text, True, 1)
                    End If
            End Select
            Me.Close()
        Else
            MsgBox("Mandatory fields are empty,Please Check !!!", MsgBoxStyle.Information)
        End If
    Catch ex As Exception
            MsgBox(ex.Message)
    End Try
        

    End Sub

    Private Sub cboxOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxOption.SelectedIndexChanged
        If cboxOption.SelectedIndex = 1 Then
            nudnnhours.Enabled = True
        Else
            nudnnhours.Enabled = False
        End If
    End Sub

    Private Sub cboxExtension_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxExtension.SelectedIndexChanged
        If cboxExtension.SelectedIndex = 1 Then
            txtdelimiter.Enabled = True
        Else
            txtdelimiter.Enabled = False
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim browseDlg As New FolderBrowserDialog

        'txtPath.Text = GetNetworkFolders(browseDlg)
        If browseDlg.ShowDialog=DialogResult.OK Then
            txtPath.Text =browseDlg.SelectedPath
        End If
    End Sub
    ''' <summary>
    ''' Gets the network folders.	
    ''' </summary>
    ''' <param name="oFolderBrowserDialog">The o folder browser dialog.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNetworkFolders(ByVal oFolderBrowserDialog _
      As FolderBrowserDialog) As String
        '======= Get type of Folder Dialog bog
        Dim type As Type = oFolderBrowserDialog.[GetType]
        '======== Get Fieldinfo for rootfolder.
        Dim fieldInfo As Reflection.FieldInfo = type.GetField("rootFolder", _
        BindingFlags.NonPublic Or BindingFlags.Instance)
        '========= Now set the value for Folder Dialog using DirectCast
        '=== 18 = Network Neighborhood is the root
        fieldInfo.SetValue(oFolderBrowserDialog, DirectCast(18, Environment.SpecialFolder))
        '==== if user click on Ok, then it will return the selected folder.
        '===== otherwise return the blank string.
        If oFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            Return oFolderBrowserDialog.SelectedPath
        Else
            Return ""
        End If
    End Function


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class