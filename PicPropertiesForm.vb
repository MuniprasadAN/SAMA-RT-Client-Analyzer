' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="PicPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Public Class PicPropertiesForm
    Private ResourcePath As String = Application.StartupPath & "\Resources"
    Friend SltImg As String
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If (Not lstPicCollection.SelectedItem Is Nothing AndAlso String.IsNullOrEmpty(lstPicCollection.SelectedItem)) Then
                MsgBox("Please Select image !!!")
            Else
                If lstPicCollection.SelectedItem = "(None)" Then
                    MainPage.PictureBox_Ctrl.BackgroundImage = Nothing
                    MainPage.PictureBox_Ctrl.AccessibleDescription = ""
                Else
                    If CkBoxStretch.Checked Then
                        MainPage.PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Stretch
                       
                    Else
                        MainPage.PictureBox_Ctrl.BackgroundImageLayout = ImageLayout.Center
                      
                    End If
                    If IO.Directory.Exists(ResourcePath) Then
                    MainPage.PictureBox_Ctrl.BackgroundImage = Image.FromFile(ResourcePath & "\" & lstPicCollection.SelectedItem)
                    MainPage.PictureBox_Ctrl.AccessibleDescription = lstPicCollection.SelectedItem
                    End If
                   
                End If

                Me.Close()

            End If
        Catch ex As Exception
           
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@PicPropForm-btnOK_Click()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
       

    End Sub

  
    Private Sub btnimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimport.Click
        Try
            Dim openFldlg As New OpenFileDialog
            openFldlg.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
            openFldlg.Multiselect = False
            openFldlg.Title = "Select Image"
            If openFldlg.ShowDialog = DialogResult.OK Then
                Dim sourcePath As String = openFldlg.FileName
                Dim fileName As String = openFldlg.SafeFileName
                If (Not sourcePath Is Nothing AndAlso String.IsNullOrEmpty(sourcePath)) Then
                    Exit Sub
                Else
                    If Not IO.Directory.Exists(ResourcePath) Then
                        IO.Directory.CreateDirectory(ResourcePath)
                    End If
                    If Not IO.File.Exists(ResourcePath & "\" & fileName) Then
                        IO.File.Copy(sourcePath, ResourcePath & "\" & fileName)
                        PicBoxPreview.BackgroundImage = Image.FromFile(ResourcePath & "\" & fileName)
                        lstPicCollection.Items.Add(fileName)
                    Else
                        MsgBox("File Already Exist!!!")
                    End If

                End If

            End If
        Catch ex As Exception
           Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@ Image Import()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
       
    End Sub

    Private Sub PicPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not IO.Directory.Exists(ResourcePath) Then
                IO.Directory.CreateDirectory(ResourcePath)
            End If
            lstPicCollection.Items.Clear()
            If IO.Directory.Exists(ResourcePath) Then
                For Each file As String In IO.Directory.GetFiles(ResourcePath)
                If Not IO.Path.GetExtension(file).ToLower = ".db" Then
                    lstPicCollection.Items.Add(IO.Path.GetFileName(file))
                End If
                Next
            lstPicCollection.Items.Add("(None)")
            If Not (Not SltImg Is Nothing AndAlso String.IsNullOrEmpty(SltImg)) Then
                lstPicCollection.SelectedItem = SltImg
            End If

            Else
                IO.Directory.CreateDirectory(ResourcePath)
            End If
            
        Catch ex As Exception
           Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@PicPropertiesForm_Load()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
        

    End Sub

  

    Private Sub lstPicCollection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPicCollection.SelectedIndexChanged
        Try
            If lstPicCollection.SelectedIndex <> -1 Then
                If lstPicCollection.SelectedItem = "(None)" Then
                    PicBoxPreview.BackgroundImage = Nothing
                Else
                    If IO.File.Exists(ResourcePath & "\" & lstPicCollection.SelectedItem) Then
                        PicBoxPreview.BackgroundImage = Image.FromFile(ResourcePath & "\" & lstPicCollection.SelectedItem)
                    Else
                        MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Image Not found !!!")
                        MsgBox("Image Not Found!!!")
                    End If
                End If
            End If
        Catch ex As Exception
          
            Mainpage._errLog.Add("Error@"& Now.ToString & "@" & ex.Message &"@lstPicCollection_SelectedIndexChanged()")
            Mainpage.MainErrorPV.SetError(Mainpage.lblAlert,"Error !!!")
        End Try
        
    End Sub

Private Sub CkBoxStretch_CheckedChanged( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles CkBoxStretch.CheckedChanged
        If CkBoxStretch.Checked
             PicBoxPreview.BackgroundImageLayout=ImageLayout.Stretch
        Else
             PicBoxPreview.BackgroundImageLayout=ImageLayout.Center
        End If
        
End Sub
End Class