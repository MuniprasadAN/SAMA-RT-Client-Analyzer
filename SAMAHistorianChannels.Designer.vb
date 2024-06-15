<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAMAHistorianChannels
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAMAHistorianChannels))
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView
        Me.pnlChnlTop = New System.Windows.Forms.Panel
        Me.btnChnlApply = New System.Windows.Forms.Button
        Me.btnChnlDelete = New System.Windows.Forms.Button
        Me.btnChnlAdd = New System.Windows.Forms.Button
        Me.Statusbar = New System.Windows.Forms.StatusStrip
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ReportName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tags = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Interval = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XAxisValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Operation = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'GVChannelsAdd
        '
        Me.GVChannelsAdd.AllowUserToAddRows = False
        Me.GVChannelsAdd.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GVChannelsAdd.ColumnHeadersHeight = 25
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.Config, Me.ReportName, Me.Description, Me.Tags, Me.Duration, Me.Interval, Me.XAxisValue, Me.Operation})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 44)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GVChannelsAdd.Size = New System.Drawing.Size(734, 327)
        Me.GVChannelsAdd.TabIndex = 7
        '
        'pnlChnlTop
        '
        Me.pnlChnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChnlTop.Controls.Add(Me.btnChnlApply)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlDelete)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlAdd)
        Me.pnlChnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlChnlTop.Name = "pnlChnlTop"
        Me.pnlChnlTop.Size = New System.Drawing.Size(734, 44)
        Me.pnlChnlTop.TabIndex = 8
        '
        'btnChnlApply
        '
        Me.btnChnlApply.Location = New System.Drawing.Point(168, 9)
        Me.btnChnlApply.Name = "btnChnlApply"
        Me.btnChnlApply.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlApply.TabIndex = 8
        Me.btnChnlApply.Text = "Apply"
        Me.btnChnlApply.UseVisualStyleBackColor = True
        '
        'btnChnlDelete
        '
        Me.btnChnlDelete.Location = New System.Drawing.Point(72, 9)
        Me.btnChnlDelete.Name = "btnChnlDelete"
        Me.btnChnlDelete.Size = New System.Drawing.Size(55, 23)
        Me.btnChnlDelete.TabIndex = 7
        Me.btnChnlDelete.Text = "Delete"
        Me.btnChnlDelete.UseVisualStyleBackColor = True
        '
        'btnChnlAdd
        '
        Me.btnChnlAdd.Location = New System.Drawing.Point(11, 9)
        Me.btnChnlAdd.Name = "btnChnlAdd"
        Me.btnChnlAdd.Size = New System.Drawing.Size(55, 23)
        Me.btnChnlAdd.TabIndex = 6
        Me.btnChnlAdd.Text = "Add"
        Me.btnChnlAdd.UseVisualStyleBackColor = True
        '
        'Statusbar
        '
        Me.Statusbar.Location = New System.Drawing.Point(0, 371)
        Me.Statusbar.Name = "Statusbar"
        Me.Statusbar.Size = New System.Drawing.Size(734, 22)
        Me.Statusbar.TabIndex = 9
        Me.Statusbar.Text = "StatusStrip1"
        '
        'Sno
        '
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.ReadOnly = True
        Me.Sno.Width = 47
        '
        'Config
        '
        Me.Config.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Config.HeaderText = "Configuration"
        Me.Config.Name = "Config"
        Me.Config.ToolTipText = "Click"
        '
        'ReportName
        '
        Me.ReportName.HeaderText = "Report Name"
        Me.ReportName.Name = "ReportName"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        '
        'Tags
        '
        Me.Tags.FillWeight = 110.7445!
        Me.Tags.HeaderText = "Tags"
        Me.Tags.Name = "Tags"
        Me.Tags.ReadOnly = True
        Me.Tags.Width = 88
        '
        'Duration
        '
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        '
        'Interval
        '
        Me.Interval.HeaderText = "Interval"
        Me.Interval.Name = "Interval"
        '
        'XAxisValue
        '
        Me.XAxisValue.HeaderText = "XAxisValue"
        Me.XAxisValue.Name = "XAxisValue"
        '
        'Operation
        '
        Me.Operation.HeaderText = "Operation"
        Me.Operation.Name = "Operation"
        '
        'SAMAHistorianChannels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 393)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.Controls.Add(Me.pnlChnlTop)
        Me.Controls.Add(Me.Statusbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SAMAHistorianChannels"
        Me.Text = "SAMAHistorianChannels"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GVChannelsAdd As System.Windows.Forms.DataGridView
    Friend WithEvents pnlChnlTop As System.Windows.Forms.Panel
    Friend WithEvents btnChnlApply As System.Windows.Forms.Button
    Friend WithEvents btnChnlDelete As System.Windows.Forms.Button
    Friend WithEvents btnChnlAdd As System.Windows.Forms.Button
    Friend WithEvents Statusbar As System.Windows.Forms.StatusStrip
    Friend WithEvents Sno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Config As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ReportName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tags As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Interval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XAxisValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operation As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
