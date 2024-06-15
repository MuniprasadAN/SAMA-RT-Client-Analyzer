' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 02-03-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="StorageLocationForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.IO
Public Class AutoStartLocationForm

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'Dim browseDlg As New FolderBrowserDialog
        'browseDlg.RootFolder = Environment.SpecialFolder.MyDocuments
        'If browseDlg.ShowDialog = DialogResult.OK Then
        '    txtPath.Text = browseDlg.SelectedPath
        'End If
                Dim openSavedlg As New OpenFileDialog
                    openSavedlg.Filter = "Supra File (*.sam)|*.sam"
                    openSavedlg.FilterIndex = 0
                    If openSavedlg.ShowDialog = DialogResult.OK Then
                        If Not (Not openSavedlg.FileName Is Nothing AndAlso String.IsNullOrEmpty(openSavedlg.FileName)) Then
                          txtPath.Text = openSavedlg.FileName
                          
                        Else
                            MsgBox("File Name Required !!")
                        End If
                    End If
    End Sub


''' <summary>
''' Write Auto Start path to "Autostartfile.cfg"
''' </summary>
''' <param name="str"></param>
''' <remarks></remarks>
    Private Sub Writefile(byval str As string)
        Try
            If Not System.IO.File.Exists( Application.StartupPath & "\Autostartfile.cfg")  Then
            IO.File.Create(Application.StartupPath & "\Autostartfile.cfg")
            End if
            Dim objWriter As New System.IO.StreamWriter( Application.StartupPath & "\Autostartfile.cfg" )
            If ckEnable.Checked Then
                str=str & vbCrLf & "True"
            Else
                str=str & vbCrLf & "False"
            End If

            objWriter.Write( str)
            objWriter.Close()
            objWriter.Dispose()
            objWriter=Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub
   

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub StorageLocationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Try
        If  System.IO.File.Exists( Application.StartupPath & "\Autostartfile.cfg")  Then
               Dim objReader As New System.IO.StreamReader( Application.StartupPath & "\Autostartfile.cfg" )
                dim pth As String=objReader.ReadLine()
                Dim enable As String=objReader.ReadLine()
                objReader.Close()
                objReader.Dispose()
                txtPath.Text=pth
            If enable="True" Then
                ckEnable.Checked=True
            Else
                ckEnable.Checked=False
            End If
       End If
    Catch ex As Exception
        MsgBox(ex.Message)
    End Try
       
             
    End Sub

Private Sub btnOk_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles btnOk.Click
        Writefile(txtPath.Text)
        Me.Close()
End Sub
End Class