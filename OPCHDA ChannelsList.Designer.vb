<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCHDA_ChannelsList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Statusbar = New System.Windows.Forms.StatusStrip()
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView()
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChannelName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OPCServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingQuery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ForLast = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RelativeTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XAxis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnChnlApply = New System.Windows.Forms.Button()
        Me.btnChnlDelete = New System.Windows.Forms.Button()
        Me.btnChnlAdd = New System.Windows.Forms.Button()
        Me.pnlChnlTop = New System.Windows.Forms.Panel()
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'Statusbar
        '
        Me.Statusbar.Location = New System.Drawing.Point(0, 467)
        Me.Statusbar.Name = "Statusbar"
        Me.Statusbar.Size = New System.Drawing.Size(821, 22)
        Me.Statusbar.TabIndex = 12
        Me.Statusbar.Text = "StatusStrip1"
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
        Me.GVChannelsAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GVChannelsAdd.ColumnHeadersHeight = 25
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.ChannelName, Me.Config, Me.OPCServer, Me.BindingQuery, Me.ForLast, Me.Interval, Me.RelativeTime, Me.XAxis})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 44)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GVChannelsAdd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.GVChannelsAdd.Size = New System.Drawing.Size(821, 423)
        Me.GVChannelsAdd.TabIndex = 10
        '
        'Sno
        '
        Me.Sno.FillWeight = 40.0!
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.ReadOnly = True
        '
        'ChannelName
        '
        Me.ChannelName.FillWeight = 100.4911!
        Me.ChannelName.HeaderText = "OPC Points"
        Me.ChannelName.Name = "ChannelName"
        '
        'Config
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = "Config"
        Me.Config.DefaultCellStyle = DataGridViewCellStyle2
        Me.Config.FillWeight = 90.74139!
        Me.Config.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Config.HeaderText = "Configuration"
        Me.Config.Name = "Config"
        Me.Config.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Config.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Config.Text = ""
        Me.Config.ToolTipText = "Click"
        '
        'OPCServer
        '
        Me.OPCServer.FillWeight = 90.74139!
        Me.OPCServer.HeaderText = "OPC Server"
        Me.OPCServer.Name = "OPCServer"
        Me.OPCServer.ReadOnly = True
        '
        'BindingQuery
        '
        Me.BindingQuery.FillWeight = 100.4911!
        Me.BindingQuery.HeaderText = "OPC Tags"
        Me.BindingQuery.Name = "BindingQuery"
        Me.BindingQuery.ReadOnly = True
        '
        'ForLast
        '
        Me.ForLast.FillWeight = 90.74139!
        Me.ForLast.HeaderText = "Last"
        Me.ForLast.Name = "ForLast"
        Me.ForLast.ReadOnly = True
        '
        'Interval
        '
        Me.Interval.FillWeight = 90.74139!
        Me.Interval.HeaderText = "Interval"
        Me.Interval.Name = "Interval"
        Me.Interval.ReadOnly = True
        '
        'RelativeTime
        '
        Me.RelativeTime.FillWeight = 90.74139!
        Me.RelativeTime.HeaderText = "RelativeTime"
        Me.RelativeTime.Name = "RelativeTime"
        Me.RelativeTime.ReadOnly = True
        '
        'XAxis
        '
        Me.XAxis.HeaderText = "X-Axis"
        Me.XAxis.Name = "XAxis"
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
        'pnlChnlTop
        '
        Me.pnlChnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChnlTop.Controls.Add(Me.btnChnlApply)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlDelete)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlAdd)
        Me.pnlChnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlChnlTop.Name = "pnlChnlTop"
        Me.pnlChnlTop.Size = New System.Drawing.Size(821, 44)
        Me.pnlChnlTop.TabIndex = 11
        '
        'OPCHDA_ChannelsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 489)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.Controls.Add(Me.Statusbar)
        Me.Controls.Add(Me.pnlChnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(837, 528)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(837, 528)
        Me.Name = "OPCHDA_ChannelsList"
        Me.Text = "OPCHDA_ChannelsList"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Statusbar As StatusStrip
    Friend WithEvents GVChannelsAdd As DataGridView
    Friend WithEvents btnChnlApply As Button
    Friend WithEvents btnChnlDelete As Button
    Friend WithEvents btnChnlAdd As Button
    Friend WithEvents pnlChnlTop As Panel
    Friend WithEvents Sno As DataGridViewTextBoxColumn
    Friend WithEvents ChannelName As DataGridViewTextBoxColumn
    Friend WithEvents Config As DataGridViewButtonColumn
    Friend WithEvents OPCServer As DataGridViewTextBoxColumn
    Friend WithEvents BindingQuery As DataGridViewTextBoxColumn
    Friend WithEvents ForLast As DataGridViewTextBoxColumn
    Friend WithEvents Interval As DataGridViewTextBoxColumn
    Friend WithEvents RelativeTime As DataGridViewTextBoxColumn
    Friend WithEvents XAxis As DataGridViewTextBoxColumn
End Class
