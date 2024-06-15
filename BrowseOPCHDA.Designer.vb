<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseOPCHDA
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
        Me.GrpBxAutoUpdate = New System.Windows.Forms.GroupBox()
        Me.CbxXaxis = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTimeRelative = New System.Windows.Forms.DateTimePicker()
        Me.CBxInterval_AutoUpd = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBxIntervalAutoUpd = New System.Windows.Forms.ComboBox()
        Me.CBx_Last = New System.Windows.Forms.ComboBox()
        Me.CBxLast = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnbrowsse = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComBxServer = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chklstTreeValues = New System.Windows.Forms.CheckedListBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.GrpBxAutoUpdate.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBxAutoUpdate
        '
        Me.GrpBxAutoUpdate.Controls.Add(Me.CbxXaxis)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label2)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label8)
        Me.GrpBxAutoUpdate.Controls.Add(Me.DTimeRelative)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxInterval_AutoUpd)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label7)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxIntervalAutoUpd)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBx_Last)
        Me.GrpBxAutoUpdate.Controls.Add(Me.CBxLast)
        Me.GrpBxAutoUpdate.Controls.Add(Me.Label6)
        Me.GrpBxAutoUpdate.Location = New System.Drawing.Point(14, 12)
        Me.GrpBxAutoUpdate.Name = "GrpBxAutoUpdate"
        Me.GrpBxAutoUpdate.Size = New System.Drawing.Size(310, 196)
        Me.GrpBxAutoUpdate.TabIndex = 27
        Me.GrpBxAutoUpdate.TabStop = False
        Me.GrpBxAutoUpdate.Text = "Auto Update"
        '
        'CbxXaxis
        '
        Me.CbxXaxis.FormattingEnabled = True
        Me.CbxXaxis.Items.AddRange(New Object() {"DateTime", "Tags"})
        Me.CbxXaxis.Location = New System.Drawing.Point(109, 152)
        Me.CbxXaxis.Name = "CbxXaxis"
        Me.CbxXaxis.Size = New System.Drawing.Size(67, 21)
        Me.CbxXaxis.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "X-Axis"
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnbrowsse)
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 46)
        Me.Panel1.TabIndex = 29
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
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.btncancel)
        Me.Panel5.Controls.Add(Me.btnSave)
        Me.Panel5.Location = New System.Drawing.Point(13, 451)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(653, 46)
        Me.Panel5.TabIndex = 31
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Server"
        '
        'ComBxServer
        '
        Me.ComBxServer.FormattingEnabled = True
        Me.ComBxServer.Location = New System.Drawing.Point(68, 24)
        Me.ComBxServer.Name = "ComBxServer"
        Me.ComBxServer.Size = New System.Drawing.Size(233, 21)
        Me.ComBxServer.TabIndex = 24
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.GrpBxAutoUpdate)
        Me.Panel4.Location = New System.Drawing.Point(322, 64)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(344, 382)
        Me.Panel4.TabIndex = 30
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtSearchText)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(288, 28)
        Me.Panel2.TabIndex = 0
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
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chklstTreeValues)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(288, 354)
        Me.Panel3.TabIndex = 1
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.Panel3)
        Me.pnlSearch.Controls.Add(Me.Panel2)
        Me.pnlSearch.Location = New System.Drawing.Point(12, 63)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(290, 384)
        Me.pnlSearch.TabIndex = 23
        '
        'BrowseOPCHDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 509)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComBxServer)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "BrowseOPCHDA"
        Me.Text = "BrowseOPCHDA"
        Me.GrpBxAutoUpdate.ResumeLayout(False)
        Me.GrpBxAutoUpdate.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GrpBxAutoUpdate As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DTimeRelative As DateTimePicker
    Friend WithEvents CBxInterval_AutoUpd As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CBxIntervalAutoUpd As ComboBox
    Friend WithEvents CBx_Last As ComboBox
    Friend WithEvents CBxLast As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnbrowsse As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btncancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComBxServer As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtSearchText As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chklstTreeValues As CheckedListBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents CbxXaxis As ComboBox
    Friend WithEvents Label2 As Label
End Class
