<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryOPCHDA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryOPCHDA))
        Me.PanelBrowse = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chklstTreeValues = New System.Windows.Forms.CheckedListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSearchText = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GrpBxquery = New System.Windows.Forms.GroupBox()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBxChartType = New System.Windows.Forms.ComboBox()
        Me.FromTime = New System.Windows.Forms.DateTimePicker()
        Me.CBxInterval_Query = New System.Windows.Forms.ComboBox()
        Me.Lblinterval = New System.Windows.Forms.Label()
        Me.CBxIntervalQuery = New System.Windows.Forms.ComboBox()
        Me.ToTime = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBtnInterval = New System.Windows.Forms.RadioButton()
        Me.RBtnRawValue = New System.Windows.Forms.RadioButton()
        Me.ComBxServer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnbrowsse = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GrpBxquery.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBrowse
        '
        Me.PanelBrowse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBrowse.Location = New System.Drawing.Point(0, 219)
        Me.PanelBrowse.Name = "PanelBrowse"
        Me.PanelBrowse.Size = New System.Drawing.Size(1244, 347)
        Me.PanelBrowse.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlSearch)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1244, 219)
        Me.Panel1.TabIndex = 23
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.Panel3)
        Me.pnlSearch.Controls.Add(Me.Panel2)
        Me.pnlSearch.Location = New System.Drawing.Point(12, 6)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(289, 207)
        Me.pnlSearch.TabIndex = 22
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chklstTreeValues)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(287, 177)
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
        Me.chklstTreeValues.Size = New System.Drawing.Size(287, 177)
        Me.chklstTreeValues.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtSearchText)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(287, 28)
        Me.Panel2.TabIndex = 0
        '
        'txtSearchText
        '
        Me.txtSearchText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchText.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(287, 31)
        Me.txtSearchText.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.GrpBxquery)
        Me.Panel4.Controls.Add(Me.ComBxServer)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btnbrowsse)
        Me.Panel4.Controls.Add(Me.btncancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Location = New System.Drawing.Point(322, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(910, 207)
        Me.Panel4.TabIndex = 23
        '
        'GrpBxquery
        '
        Me.GrpBxquery.Controls.Add(Me.FromDate)
        Me.GrpBxquery.Controls.Add(Me.Label2)
        Me.GrpBxquery.Controls.Add(Me.CBxChartType)
        Me.GrpBxquery.Controls.Add(Me.FromTime)
        Me.GrpBxquery.Controls.Add(Me.CBxInterval_Query)
        Me.GrpBxquery.Controls.Add(Me.Lblinterval)
        Me.GrpBxquery.Controls.Add(Me.CBxIntervalQuery)
        Me.GrpBxquery.Controls.Add(Me.ToTime)
        Me.GrpBxquery.Controls.Add(Me.Label4)
        Me.GrpBxquery.Controls.Add(Me.Label3)
        Me.GrpBxquery.Controls.Add(Me.ToDate)
        Me.GrpBxquery.Controls.Add(Me.GroupBox1)
        Me.GrpBxquery.Location = New System.Drawing.Point(7, 51)
        Me.GrpBxquery.Name = "GrpBxquery"
        Me.GrpBxquery.Size = New System.Drawing.Size(884, 115)
        Me.GrpBxquery.TabIndex = 15
        Me.GrpBxquery.TabStop = False
        Me.GrpBxquery.Text = "Query"
        '
        'FromDate
        '
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(72, 19)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(102, 20)
        Me.FromDate.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(637, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Chart Type"
        '
        'CBxChartType
        '
        Me.CBxChartType.FormattingEnabled = True
        Me.CBxChartType.Items.AddRange(New Object() {"area", "stackedarea", "fullstackedarea", "line", "stackedline", "fullstackedline", "Spline", "stackedspline", "fullstackedspline", "bar"})
        Me.CBxChartType.Location = New System.Drawing.Point(722, 30)
        Me.CBxChartType.Name = "CBxChartType"
        Me.CBxChartType.Size = New System.Drawing.Size(140, 21)
        Me.CBxChartType.TabIndex = 26
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
        Me.CBxInterval_Query.Location = New System.Drawing.Point(473, 70)
        Me.CBxInterval_Query.Name = "CBxInterval_Query"
        Me.CBxInterval_Query.Size = New System.Drawing.Size(88, 21)
        Me.CBxInterval_Query.TabIndex = 21
        Me.CBxInterval_Query.Visible = False
        '
        'Lblinterval
        '
        Me.Lblinterval.AutoSize = True
        Me.Lblinterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblinterval.Location = New System.Drawing.Point(341, 73)
        Me.Lblinterval.Name = "Lblinterval"
        Me.Lblinterval.Size = New System.Drawing.Size(50, 13)
        Me.Lblinterval.TabIndex = 20
        Me.Lblinterval.Text = "Interval"
        Me.Lblinterval.Visible = False
        '
        'CBxIntervalQuery
        '
        Me.CBxIntervalQuery.FormattingEnabled = True
        Me.CBxIntervalQuery.Items.AddRange(New Object() {"1", "2", "4", "5", "6", "8", "10", "12", "15", "20", "30"})
        Me.CBxIntervalQuery.Location = New System.Drawing.Point(397, 70)
        Me.CBxIntervalQuery.Name = "CBxIntervalQuery"
        Me.CBxIntervalQuery.Size = New System.Drawing.Size(70, 21)
        Me.CBxIntervalQuery.TabIndex = 19
        Me.CBxIntervalQuery.Visible = False
        '
        'ToTime
        '
        Me.ToTime.CustomFormat = "HH:mm"
        Me.ToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ToTime.Location = New System.Drawing.Point(180, 67)
        Me.ToTime.Name = "ToTime"
        Me.ToTime.ShowUpDown = True
        Me.ToTime.Size = New System.Drawing.Size(79, 20)
        Me.ToTime.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 73)
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
        Me.ToDate.Location = New System.Drawing.Point(72, 67)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(102, 20)
        Me.ToDate.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBtnInterval)
        Me.GroupBox1.Controls.Add(Me.RBtnRawValue)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(335, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 47)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Read"
        '
        'RBtnInterval
        '
        Me.RBtnInterval.AutoSize = True
        Me.RBtnInterval.Location = New System.Drawing.Point(148, 19)
        Me.RBtnInterval.Name = "RBtnInterval"
        Me.RBtnInterval.Size = New System.Drawing.Size(78, 17)
        Me.RBtnInterval.TabIndex = 24
        Me.RBtnInterval.Text = "By Interval "
        Me.RBtnInterval.UseVisualStyleBackColor = True
        '
        'RBtnRawValue
        '
        Me.RBtnRawValue.AutoSize = True
        Me.RBtnRawValue.Checked = True
        Me.RBtnRawValue.Location = New System.Drawing.Point(33, 19)
        Me.RBtnRawValue.Name = "RBtnRawValue"
        Me.RBtnRawValue.Size = New System.Drawing.Size(94, 17)
        Me.RBtnRawValue.TabIndex = 23
        Me.RBtnRawValue.TabStop = True
        Me.RBtnRawValue.Text = "By RawValues"
        Me.RBtnRawValue.UseVisualStyleBackColor = True
        '
        'ComBxServer
        '
        Me.ComBxServer.FormattingEnabled = True
        Me.ComBxServer.Location = New System.Drawing.Point(84, 11)
        Me.ComBxServer.Name = "ComBxServer"
        Me.ComBxServer.Size = New System.Drawing.Size(233, 21)
        Me.ComBxServer.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Server"
        '
        'btnbrowsse
        '
        Me.btnbrowsse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowsse.Location = New System.Drawing.Point(341, 8)
        Me.btnbrowsse.Name = "btnbrowsse"
        Me.btnbrowsse.Size = New System.Drawing.Size(103, 24)
        Me.btnbrowsse.TabIndex = 10
        Me.btnbrowsse.Text = "Browse"
        Me.btnbrowsse.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.Location = New System.Drawing.Point(508, 172)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(120, 28)
        Me.btncancel.TabIndex = 12
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(347, 172)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 28)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Submit"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'QueryOPCHDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 566)
        Me.Controls.Add(Me.PanelBrowse)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QueryOPCHDA"
        Me.Text = "OPCHDA Query"
        Me.Panel1.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GrpBxquery.ResumeLayout(False)
        Me.GrpBxquery.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBrowse As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chklstTreeValues As CheckedListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtSearchText As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GrpBxquery As GroupBox
    Friend WithEvents FromTime As DateTimePicker
    Friend WithEvents CBxInterval_Query As ComboBox
    Friend WithEvents Lblinterval As Label
    Friend WithEvents CBxIntervalQuery As ComboBox
    Friend WithEvents ToTime As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToDate As DateTimePicker
    Friend WithEvents ComBxServer As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnbrowsse As Button
    Friend WithEvents btncancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBtnInterval As RadioButton
    Friend WithEvents RBtnRawValue As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents CBxChartType As ComboBox
    Friend WithEvents FromDate As DateTimePicker
End Class
