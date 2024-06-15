' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-10-2014
' ***********************************************************************
' <copyright file="LabelPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Drawing.Text

Public Class LabelPropertiesForm
    Dim ColDialog As New ColorDialog
    Private Sub LabelProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim installed_fonts As New InstalledFontCollection

        ' Get an array of the system's font familiies.
        Dim font_families() As FontFamily = installed_fonts.Families()

        ' Display the font families.
        For Each font_family As FontFamily In font_families
            CBoxFont.Items.Add(font_family.Name)
        Next font_family
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If
        Call Properties(MainPage.Label_Ctrl)
        Me.Close()
    End Sub
    Private Sub Properties(ByVal lblCtrl As Label)
        'BackColor Setting
        Try
            lblCtrl.BackColor = lblCtrlBackColor.BackColor
            lblCtrl.ForeColor = forecolorlbl.BackColor
            lblCtrl.Text = txtCaption.Text
            If CBoxStyle.SelectedItem = "None" Then
                lblCtrl.BorderStyle = BorderStyle.None
            ElseIf CBoxStyle.SelectedItem = "FixedSingle" Then
                lblCtrl.BorderStyle = BorderStyle.FixedSingle
            ElseIf CBoxStyle.SelectedItem = "Fixed3D" Then
                lblCtrl.BorderStyle = BorderStyle.Fixed3D
            End If
            Dim emsize As Single = NUDFontSize.Value
'            Dim g As Graphics = Label1.CreateGraphics() ' COMMENTED BY CODEIT.RIGHT

          
            If CKboxBold.Checked Then
                lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize, FontStyle.Bold)

            ElseIf Ckboxbtnitalic.Checked Then
                lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize, FontStyle.Italic)

            ElseIf CKBoxUnderLine.Checked Then
                lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize, FontStyle.Underline)
            Else
                lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize, FontStyle.Regular)
            End If
            'lblCtrl.Width = CInt(g.MeasureString(lblCtrl.Text, lblCtrl.Font).Width + 10)
            'lblCtrl.Height = CInt(g.MeasureString(lblCtrl.Text, lblCtrl.Font).Height)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub lblCtrlBackColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCtrlBackColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblCtrlBackColor.BackColor = ColDialog.Color
    End Sub

    Private Sub forecolorlbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forecolorlbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        forecolorlbl.BackColor = ColDialog.Color
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class