<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseOPCHDA_Tags
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chklstTreeValues = New System.Windows.Forms.CheckedListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnbrowsse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComBxServer = New System.Windows.Forms.ComboBox()
        Me.GrpBxquery = New System.Windows.Forms.GroupBox()
        Me.FromTime = New System.Windows.Forms.DateTimePicker()
        Me.CBxInterval_Query = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBxIntervalQuery = New System.Windows.Forms.ComboBox()
        Me.ToTime = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.GrpBxAutoUpdate = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTimeRelative = New System.Windows.Forms.DateTimePicker()
        Me.CBxInterval_AutoUpd = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBxIntervalAutoUpd = New System.Windows.Forms.ComboBox()
        Me.CBx_Last = New System.Windows.Forms.ComboBox()
        Me.CBxLast = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Rbtnquery = New System.Windows.Forms.RadioButton()
        Me.Rbtnautoupdate = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pnlSearch.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrpBxquery.SuspendLayout()
        Me.GrpBxAutoUpdate.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.Panel3)
        Me.pnlSearch.Controls.Add(Me.Panel2)
        Me.pnlSearch.Location = New System.Drawing.Point(12, 63)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(290, 384)
        Me.pnlSearch.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chklstTreeValues)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(288, 354)
        Me.Panel3.TabIndex = 1
        '
        'chklstTreeValues
        '
        Me.chklstTreeValues.CheckOnClick = True
        Me.chklstTreeValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklstTreeValues.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstTreeValues.FormattingEnabled = True
        Me.chklstTreeValues.Location = New System.Drawing.Point(0, 0)
        Me.chklstTreeValues.Name = "chklstTreeValues"
        Me.chklstTreeValues.Size = New System.Drawing.Size(288, 354)
        Me.chklstTreeValues.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtSearchText)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(288, 28)
        Me.Panel2.TabIndex = 0
        '
        'txtSearchText
        '
        Me.txtSearchText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchText.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(288, 31)
        Me.txtSearchText.TabIndex = 0
        '
        'btncancel
        '
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.Location = New System.Drawing.Point(512, 11)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(84, 28)
        Me.btncancel.TabIndex = 12
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(392, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 28)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnbrowsse
        '
        Me.btnbrowsse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowsse.Location = New System.Drawing.Point(309, 11)
        Me.btnbrowsse.Name = "btnbrowsse"
        Me.btnbrowsse.Size = New System.Drawing.Size(103, 24)
        Me.btnbrowsse.TabIndex = 10
        Me.btnbrowsse.Text = "Browse"
        Me.btnbrowsse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server"
        '
        'ComBxServer
        '
        Me.ComBxServer.FormattingEnabled = True
        Me.ComBxServer.Location = New System.Drawing.Point(68, 24)
        Me.ComBxServer.Name = "ComBxServer"
        Me.ComBxServer.Size = New System.Drawing.Size(233, 21)
        Me.ComBxServer.TabIndex = 8
        '
        'GrpBxquery
        '
        Me.GrpBxquery.Controls.Add(Me.FromTime)
        Me.GrpBxquery.Controls.Add(Me.CBxInterval_Query)
        Me.GrpBxquery.Controls.Add(Me.Label5)
        Me.GrpBxquery.Controls.Add(Me.CBxIntervalQuery)
        Me.GrpBxquery.Controls.Add(Me.ToTime)
        Me.GrpBxquery.Controls.Add(Me.Label4)
        Me.GrpBxquery.Controls.Add(Me.Label3)
        Me.GrpBxquery.Controls.Add(Me.ToDate)
        Me.GrpBxquery.Controls.Add(Me.FromDate)
        Me.GrpBxquery.Location = New System.Drawing.Point(347, 144)
        Me.GrpBxquery.Name = "GrpBxquery"
        Me.GrpBxquery.Size = New System.Drawing.Size(310, 135)
        Me.GrpBxquery.TabIndex = 15
        Me.GrpBxquery.TabStop = False
        Me.GrpBxquery.Text = "Query"
        '
        'FromTime
        '
        Me.FromTime.CustomFormat = "HH:mm"
        Me.FromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FromTime.Location = New System.Drawing.Point(180, 19)
        Me.FromTime.Name = "FromTime"
        Me.FromTime.ShowUpDown = True
        Me.FromTime.Size = New System.Drawing.Size(79, 20)
        Me.FromTime.TabIndex = 22
        '
        'CBxInterval_Query
        '
        Me.CBxInterval_Query.FormattingEnabled = True
        Me.CBxInterval_Query.Items.AddRange(New Object() {"Days", "Hours", "Minutes", "Seconds"})
        Me.CBxInterval_Query.Location = New System.Drawing.Point(150, 92)
        Me.CBxInterval_Query.Name = "CBxInterval_Query"
        Me.CBxInterval_Query.Size = New System.Drawing.Size(88, 21)
        Me.CBxInterval_Query.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Interval"
        '
        'CBxIntervalQuery
        '
        Me.CBxIntervalQuery.FormattingEnabled = True
        Me.CBxIntervalQuery.Items.AddRange(New Object() {"1", "2", "4", "5", "6", "8", "10", "12", "15", "20", "30"})
        Me.CBxIntervalQuery.Location = New System.Drawing.Point(74, 92)
        Me.CBxIntervalQuery.Name = "CBxIntervalQuery"
        Me.CBxIntervalQuery.Size = New System.Drawing.Size(70, 21)
        Me.CBxIntervalQuery.TabIndex = 19
        '
        'ToTime
        '
        Me.ToTime.CustomFormat = "HH:mm"
        Me.ToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ToTime.Location = New System.Drawing.Point(182, 56)
        Me.ToTime.Name = "ToTime"
        Me.ToTime.ShowUpDown = True
        Me.ToTime.Size = New System.Drawing.Size(79, 20)
        Me.ToTime.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "From "
        '
        'ToDate
        '
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(74, 56)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(102, 20)
        Me.ToDate.TabIndex = 1
        '
        'FromDate
        '
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(74, 19)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(102, 20)
        Me.FromDate.TabIndex = 0
        Me.FromDate.Value = New Date(2018, 8, 2, 0, 0, 0, 0)
        '
        'GrpBxAutoUpdate
        '
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label8)
        Me.GrpBxAutoUpdate.Controls.Add(Me.DTimeRelative)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxInterval_AutoUpd)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label7)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxIntervalAutoUpd)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBx_Last)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxLast)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label6)
        Me.GrpBxAutoUpdate.Location = New System.Drawing.Point(347, 295)
        Me.GrpBxAutoUpdate.Name = "GrpBxAutoUpdate"
        Me.GrpBxAutoUpdate.Size = New System.Drawing.Size(310, 146)
        Me.GrpBxAutoUpdate.TabIndex = 16
        Me.GrpBxAutoUpdate.TabStop = False
        Me.GrpBxAutoUpdate.Text = "Auto Update"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Relative Time"
        '
        'DTimeRelative
        '
        Me.DTimeRelative.CustomFormat = "HH:mm"
        Me.DTimeRelative.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTimeRelative.Location = New System.Drawing.Point(109, 111)
        Me.DTimeRelative.Name = "DTimeRelative"
        Me.DTimeRelative.ShowUpDown = True
        Me.DTimeRelative.Size = New System.Drawing.Size(79, 20)
        Me.DTimeRelative.TabIndex = 26
        '
        'CBxInterval_AutoUpd
        '
        Me.CBxInterval_AutoUpd.FormattingEnabled = True
        Me.CBxInterval_AutoUpd.Items.AddRange(New Object() {"Days", "Hours", "Minutes", "Seconds"})
        Me.CBxInterval_AutoUpd.Location = New System.Drawing.Point(185, 70)
        Me.CBxInterval_AutoUpd.Name = "CBxInterval_AutoUpd"
        Me.CBxInterval_AutoUpd.Size = New System.Drawing.Size(96, 21)
        Me.CBxInterval_AutoUpd.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Interval"
        '
        'CBxIntervalAutoUpd
        '
        Me.CBxIntervalAutoUpd.FormattingEnabled = True
        Me.CBxIntervalAutoUpd.Items.AddRange(New Object() {"1", "2", "4", "5", "6", "8", "10", "12", "15", "20", "30"})
        Me.CBxIntervalAutoUpd.Location = New System.Drawing.Point(109, 70)
        Me.CBxIntervalAutoUpd.Name = "CBxIntervalAutoUpd"
        Me.CBxIntervalAutoUpd.Size = New System.Drawing.Size(67, 21)
        Me.CBxIntervalAutoUpd.TabIndex = 23
        '
        'CBx_Last
        '
        Me.CBx_Last.FormattingEnabled = True
        Me.CBx_Last.Items.AddRange(New Object() {"Months", "Days", "Hours", "Minutes"})
        Me.CBx_Last.Location = New System.Drawing.Point(185, 33)
        Me.CBx_Last.Name = "CBx_Last"
        Me.CBx_Last.Size = New System.Drawing.Size(96, 21)
        Me.CBx_Last.TabIndex = 22
        '
        'CBxLast
        '
        Me.CBxLast.FormattingEnabled = True
        Me.CBxLast.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "12", "15", "20", "30"})
        Me.CBxLast.Location = New System.Drawing.Point(109, 33)
        Me.CBxLast.Name = "CBxLast"
        Me.CBxLast.Size = New System.Drawing.Size(67, 21)
        Me.CBxLast.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Last"
        '
        'Rbtnquery
        '
        Me.Rbtnquery.AutoSize = True
        Me.Rbtnquery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbtnquery.Location = New System.Drawing.Point(50, 19)
        Me.Rbtnquery.Name = "Rbtnquery"
        Me.Rbtnquery.Size = New System.Drawing.Size(58, 17)
        Me.Rbtnquery.TabIndex = 17
        Me.Rbtnquery.TabStop = True
        Me.Rbtnquery.Text = "Query"
        Me.Rbtnquery.UseVisualStyleBackColor = True
        '
        'Rbtnautoupdate
        '
        Me.Rbtnautoupdate.AutoSize = True
        Me.Rbtnautoupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rbtnautoupdate.Location = New System.Drawing.Point(166, 19)
        Me.Rbtnautoupdate.Name = "Rbtnautoupdate"
        Me.Rbtnautoupdate.Size = New System.Drawing.Size(96, 17)
        Me.Rbtnautoupdate.TabIndex = 18
        Me.Rbtnautoupdate.TabStop = True
        Me.Rbtnautoupdate.Text = "Auto Update"
        Me.Rbtnautoupdate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rbtnautoupdate)
        Me.GroupBox2.Controls.Add(Me.Rbtnquery)
        Me.GroupBox2.Location = New System.Drawing.Point(347, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(310, 50)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Type"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnbrowsse)
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 46)
        Me.Panel1.TabIndex = 20
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Location = New System.Drawing.Point(322, 64)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(344, 382)
        Me.Panel4.TabIndex = 21
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.btncancel)
        Me.Panel5.Controls.Add(Me.btnSave)
        Me.Panel5.Location = New System.Drawing.Point(13, 451)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(653, 46)
        Me.Panel5.TabIndex = 22
        '
        'BrowseOPCHDA_Tags
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 509)
        Me.Controls.Add(Me.GrpBxAutoUpdate)
        Me.Controls.Add(Me.GrpBxquery)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComBxServer)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BrowseOPCHDA_Tags"
        Me.Text = "BrowseOPCHDA_Tags"
        Me.pnlSearch.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrpBxquery.ResumeLayout(False)
        Me.GrpBxquery.PerformLayout()
        Me.GrpBxAutoUpdate.ResumeLayout(False)
        Me.GrpBxAutoUpdate.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSearch As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chklstTreeValues As CheckedListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearchText As TextBox
    Friend WithEvents btncancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnbrowsse As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComBxServer As ComboBox
    Friend WithEvents GrpBxquery As GroupBox
    Friend WithEvents CBxInterval_Query As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CBxIntervalQuery As ComboBox
    Friend WithEvents ToTime As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToDate As DateTimePicker
    Friend WithEvents GrpBxAutoUpdate As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DTimeRelative As DateTimePicker
    Friend WithEvents CBxInterval_AutoUpd As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CBxIntervalAutoUpd As ComboBox
    Friend WithEvents CBx_Last As ComboBox
    Friend WithEvents CBxLast As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Rbtnquery As RadioButton
    Friend WithEvents Rbtnautoupdate As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents FromDate As DateTimePicker
    Friend WithEvents FromTime As DateTimePicker
End Class
