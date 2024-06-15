' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-11-2014
' ***********************************************************************
' <copyright file="DisplayvalueLabelPropertiesForm.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Drawing.Text
Imports System.IO
Imports System.Data.SqlClient
Public Class DisplayvalueLabelPropertiesForm
    Private ColDialog As New ColorDialog
    Private Constr As String = ""
    Private DB_Chnl_Index_Collection() As Integer
    Private OPC_Chnl_Index_Collection() As Integer
    Private OPCDA_Chnl_Index_Collection() As Integer
    Private slt_Idx As Integer' = 0
    Friend Channel_Text As String = ""
    Friend TH_Value As String = ""
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        MainPage.modify = True
        If Not MainPage.Text.EndsWith("*", StringComparison.CurrentCulture) Then
            MainPage.Text = MainPage.Text & " *"
        End If

        Call Properties(MainPage.ValueLabel_Ctrl)
      
    End Sub
    Private Sub Properties(ByVal lblCtrl As LabelValue)
    Try
          'BackColor Setting
        lblCtrl.BackColor = lblCtrlBackColor.BackColor
        lblCtrl.ForeColor = forecolorlbl.BackColor

        lblCtrl.Default_BackColor = lblCtrlBackColor.BackColor
        lblCtrl.DefaultForeColors_ = forecolorlbl.BackColor

        Dim emsize As Single = NUDFontSize.Value
'        Dim g As Graphics = lblFont.CreateGraphics() ' COMMENTED BY CODEIT.RIGHT
        lblCtrl.TextAlign = ContentAlignment.MiddleCenter
        'lblCtrl.Width = CInt(g.MeasureString(lblCtrl.Text, lblCtrl.Font).Width + 10)
        'lblCtrl.Height = CInt(g.MeasureString(lblCtrl.Text, lblCtrl.Font).Height + 10)
        lblCtrl.TextAlign = ContentAlignment.MiddleCenter
        lblCtrl.UnitsValue=txtUnits.text
        
       If CBoxStyle.SelectedItem = "None" Then
                lblCtrl.BorderStyle = BorderStyle.None
        ElseIf CBoxStyle.SelectedItem = "FixedSingle" Then
                lblCtrl.BorderStyle = BorderStyle.FixedSingle
        ElseIf CBoxStyle.SelectedItem = "Fixed3D" Then
                lblCtrl.BorderStyle = BorderStyle.Fixed3D
        End If

        If CKboxBold.Checked = True Then
            lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize, FontStyle.Bold)
        Else
            lblCtrl.Font = New System.Drawing.Font(CBoxFont.Text, emsize)
        End If

        lblCtrl._ThresholdValue.Clear()
        lblCtrl._THForeColor.Clear()
        lblCtrl._THBackColor.Clear()
        lblCtrl._THblink.Clear()
        lblCtrl._Description.Clear()
        For i As Integer = 0 To GVTHValue.Rows.Count - 1
              If Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(0).Value) and Not String.IsNullOrEmpty( GVTHValue.Rows(i).Cells(1).Value) Then
                lblCtrl._ThresholdValue.Add(GVTHValue.Rows(i).Cells(0).Value & "@" & GVTHValue.Rows(i).Cells(1).Value)
                lblCtrl._THForeColor.Add(GVTHValue.Rows(i).Cells(2).Style.BackColor.ToArgb)
                lblCtrl._THBackColor.Add(GVTHValue.Rows(i).Cells(3).Style.BackColor.ToArgb)
                lblCtrl._Description.Add(GVTHValue.Rows(i).Cells(4).Value)
                Dim IsTicked As Boolean = CBool(GVTHValue.Rows(i).Cells(5).Value)
                If IsTicked Then
                    lblCtrl._THblink.Add(1)
                Else
                    lblCtrl._THblink.Add(0)
                End If

            Else
                MsgBox("Empty Fields Not Allowed !!!",MsgBoxStyle.Critical)
                Exit sub
            End If
            
        Next
        lblCtrl.AccessibleDescription = cBoxActionChannel.Text
        Me.close
    Catch ex As Exception
            MsgBox(ex.Message)
    End Try
      
    End Sub
    Private Sub DisplayvalueLabelPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim installed_fonts As New InstalledFontCollection
        ' Get an array of the system's font familiies.
        Dim font_families() As FontFamily = installed_fonts.Families()
        ' Display the font families.
        For Each font_family As FontFamily In font_families
            CBoxFont.Items.Add(font_family.Name)
        Next font_family

        DB_Chnl_Index_Collection = Enumerable.Range(0, MainPage.channelList.Channel_Flag.Count).Where(Function(f) MainPage.channelList.Channel_Flag(f).Contains("Value")).ToArray
        OPC_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPC_ChannelList_Class.OPC_Multiview.Count).Where(Function(f) MainPage.OPC_ChannelList_Class.OPC_Multiview(f) = False).ToArray
        OPCDA_Chnl_Index_Collection = Enumerable.Range(0, MainPage.OPCDAChannelsList.OPC_Multiview.Count).Where(Function(f) MainPage.OPCDAChannelsList.OPC_Multiview(f) = False).ToArray
        cBoxActionChannel.Items.Clear()
        For i As Integer = 0 To DB_Chnl_Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.channelList.Channel_Name(DB_Chnl_Index_Collection(i)))
        Next
        For i As Integer = 0 To OPC_Chnl_Index_Collection.Length - 1
            CBoxActionChannel.Items.Add(MainPage.OPC_ChannelList_Class.OPC_Channel_Name(OPC_Chnl_Index_Collection(i)))
        Next
        For i As Integer = 0 To OPCDA_Chnl_Index_Collection.Length - 1
            cBoxActionChannel.Items.Add(MainPage.OPCDAChannelsList.OPC_Channel_Name(OPCDA_Chnl_Index_Collection(i)))
        Next

        cBoxActionChannel.Text = Channel_Text


        Dim cboxClm As New DataGridViewComboBoxColumn
        cboxClm = GVTHValue.Columns("Condition")
        cboxClm.Items.AddRange(New String() {"=", ">", "<", ">=", "<=", ">=<="})



    End Sub

    Private Sub lblCtrlBackColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCtrlBackColor.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        lblCtrlBackColor.BackColor = ColDialog.Color
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub forecolorlbl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles forecolorlbl.DoubleClick
        ColDialog.ShowDialog()
        ColDialog.FullOpen = False
        forecolorlbl.BackColor = ColDialog.Color
    End Sub


    Private Sub GVTHValue_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GVTHValue.CellDoubleClick
        If GVTHValue.CurrentCell.ColumnIndex = 2 Or GVTHValue.CurrentCell.ColumnIndex = 3 Then
            ColDialog.ShowDialog()
            ColDialog.FullOpen = False
            GVTHValue.CurrentCell.Style.BackColor = ColDialog.Color
        End If
    End Sub

    'Private Sub GVTHValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GVTHValue.KeyPress
    '    If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not Asc(e.KeyChar) = 8 Then
    '        e.Handled = True
    '    Else
    '        e.Handled = False
    '    End If
    'End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
       
        Dim i As Integer =GVTHValue.Rows.Add()
        GVTHValue.Rows(i).Cells(2).Style.BackColor=Color.Black
         GVTHValue.Rows(i).Cells(3).Style.BackColor=Color.White
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If GVTHValue.Rows.Count > 0 AndAlso GVTHValue.CurrentRow.Index <> -1 Then
            GVTHValue.Rows.RemoveAt(GVTHValue.CurrentRow.Index)
        End If

    End Sub

    Private Sub DisplayvalueLabelPropertiesForm_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub


End Class