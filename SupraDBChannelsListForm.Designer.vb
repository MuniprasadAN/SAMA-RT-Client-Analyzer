<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupraDBChannelsListForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupraDBChannelsListForm))
        Me.pnlChannelsAdd = New System.Windows.Forms.Panel()
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView()
        Me.pnlChnlTop = New System.Windows.Forms.Panel()
        Me.ckBox_DBAllowClients = New System.Windows.Forms.CheckBox()
        Me.btnChnlExport = New System.Windows.Forms.Button()
        Me.btnChnlimport = New System.Windows.Forms.Button()
        Me.btnChnlApply = New System.Windows.Forms.Button()
        Me.btnChnlDelete = New System.Windows.Forms.Button()
        Me.btnChnlAdd = New System.Windows.Forms.Button()
        Me.Statusbar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChannelName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Properties = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChannelType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingQuery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefreshTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlChannelsAdd.SuspendLayout()
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChnlTop.SuspendLayout()
        Me.Statusbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlChannelsAdd
        '
        Me.pnlChannelsAdd.AllowDrop = True
        Me.pnlChannelsAdd.AutoScroll = True
        Me.pnlChannelsAdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlChannelsAdd.Controls.Add(Me.GVChannelsAdd)
        Me.pnlChannelsAdd.Controls.Add(Me.pnlChnlTop)
        Me.pnlChannelsAdd.Controls.Add(Me.Statusbar)
        Me.pnlChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChannelsAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlChannelsAdd.Location = New System.Drawing.Point(0, 0)
        Me.pnlChannelsAdd.Name = "pnlChannelsAdd"
        Me.pnlChannelsAdd.Size = New System.Drawing.Size(504, 519)
        Me.pnlChannelsAdd.TabIndex = 2
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
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.ChannelName, Me.Config, Me.Properties, Me.ChannelType, Me.BindingQuery, Me.RefreshTime})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 50)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GVChannelsAdd.Size = New System.Drawing.Size(500, 443)
        Me.GVChannelsAdd.TabIndex = 2
        '
        'pnlChnlTop
        '
        Me.pnlChnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChnlTop.Controls.Add(Me.ckBox_DBAllowClients)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlExport)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlimport)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlApply)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlDelete)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlAdd)
        Me.pnlChnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlChnlTop.Name = "pnlChnlTop"
        Me.pnlChnlTop.Size = New System.Drawing.Size(500, 50)
        Me.pnlChnlTop.TabIndex = 3
        '
        'ckBox_DBAllowClients
        '
        Me.ckBox_DBAllowClients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckBox_DBAllowClients.AutoSize = True
        Me.ckBox_DBAllowClients.Location = New System.Drawing.Point(252, 14)
        Me.ckBox_DBAllowClients.Name = "ckBox_DBAllowClients"
        Me.ckBox_DBAllowClients.Size = New System.Drawing.Size(99, 17)
        Me.ckBox_DBAllowClients.TabIndex = 12
        Me.ckBox_DBAllowClients.Text = "Allow Clients"
        Me.ckBox_DBAllowClients.UseVisualStyleBackColor = True
        '
        'btnChnlExport
        '
        Me.btnChnlExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChnlExport.Location = New System.Drawing.Point(429, 8)
        Me.btnChnlExport.Name = "btnChnlExport"
        Me.btnChnlExport.Size = New System.Drawing.Size(66, 23)
        Me.btnChnlExport.TabIndex = 10
        Me.btnChnlExport.Text = "Export"
        Me.btnChnlExport.UseVisualStyleBackColor = True
        '
        'btnChnlimport
        '
        Me.btnChnlimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChnlimport.Location = New System.Drawing.Point(357, 8)
        Me.btnChnlimport.Name = "btnChnlimport"
        Me.btnChnlimport.Size = New System.Drawing.Size(66, 23)
        Me.btnChnlimport.TabIndex = 9
        Me.btnChnlimport.Text = "Import"
        Me.btnChnlimport.UseVisualStyleBackColor = True
        '
        'btnChnlApply
        '
        Me.btnChnlApply.Location = New System.Drawing.Point(142, 12)
        Me.btnChnlApply.Name = "btnChnlApply"
        Me.btnChnlApply.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlApply.TabIndex = 8
        Me.btnChnlApply.Text = "Apply"
        Me.btnChnlApply.UseVisualStyleBackColor = True
        '
        'btnChnlDelete
        '
        Me.btnChnlDelete.Location = New System.Drawing.Point(71, 12)
        Me.btnChnlDelete.Name = "btnChnlDelete"
        Me.btnChnlDelete.Size = New System.Drawing.Size(54, 23)
        Me.btnChnlDelete.TabIndex = 7
        Me.btnChnlDelete.Text = "Delete"
        Me.btnChnlDelete.UseVisualStyleBackColor = True
        '
        'btnChnlAdd
        '
        Me.btnChnlAdd.Location = New System.Drawing.Point(11, 12)
        Me.btnChnlAdd.Name = "btnChnlAdd"
        Me.btnChnlAdd.Size = New System.Drawing.Size(54, 23)
        Me.btnChnlAdd.TabIndex = 6
        Me.btnChnlAdd.Text = "Add"
        Me.btnChnlAdd.UseVisualStyleBackColor = True
        '
        'Statusbar
        '
        Me.Statusbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.Statusbar.Location = New System.Drawing.Point(0, 493)
        Me.Statusbar.Name = "Statusbar"
        Me.Statusbar.Size = New System.Drawing.Size(500, 22)
        Me.Statusbar.TabIndex = 7
        Me.Statusbar.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(304, 17)
        Me.ToolStripStatusLabel1.Text = "*Set Optimam Refresh Time for Optimal Performance ...."
        '
        'Sno
        '
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.ReadOnly = True
        Me.Sno.Width = 47
        '
        'ChannelName
        '
        Me.ChannelName.FillWeight = 110.7445!
        Me.ChannelName.HeaderText = "SAMA Points"
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Width = 103
        '
        'Config
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.NullValue = "Config"
        Me.Config.DefaultCellStyle = DataGridViewCellStyle2
        Me.Config.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Config.HeaderText = "Configuration"
        Me.Config.Name = "Config"
        Me.Config.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Config.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Config.Text = ""
        Me.Config.ToolTipText = "Click"
        Me.Config.Width = 109
        '
        'Properties
        '
        Me.Properties.FillWeight = 110.7445!
        Me.Properties.HeaderText = "Properties"
        Me.Properties.Name = "Properties"
        Me.Properties.ReadOnly = True
        Me.Properties.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Properties.Visible = False
        Me.Properties.Width = 79
        '
        'ChannelType
        '
        Me.ChannelType.FillWeight = 110.7445!
        Me.ChannelType.HeaderText = "Channel Type"
        Me.ChannelType.Name = "ChannelType"
        Me.ChannelType.Visible = False
        Me.ChannelType.Width = 98
        '
        'BindingQuery
        '
        Me.BindingQuery.FillWeight = 110.7445!
        Me.BindingQuery.HeaderText = "Binding Query"
        Me.BindingQuery.Name = "BindingQuery"
        Me.BindingQuery.ReadOnly = True
        Me.BindingQuery.Width = 113
        '
        'RefreshTime
        '
        Me.RefreshTime.HeaderText = "RefreshTime(sec)"
        Me.RefreshTime.Name = "RefreshTime"
        Me.RefreshTime.Width = 133
        '
        'SupraDBChannelsListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 519)
        Me.Controls.Add(Me.pnlChannelsAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(520, 558)
        Me.Name = "SupraDBChannelsListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supra DB Channels "
        Me.pnlChannelsAdd.ResumeLayout(False)
        Me.pnlChannelsAdd.PerformLayout()
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.pnlChnlTop.PerformLayout()
        Me.Statusbar.ResumeLayout(False)
        Me.Statusbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlChannelsAdd As System.Windows.Forms.Panel
    Friend WithEvents GVChannelsAdd As System.Windows.Forms.DataGridView
    Friend WithEvents pnlChnlTop As System.Windows.Forms.Panel
    Friend WithEvents btnChnlExport As System.Windows.Forms.Button
    Friend WithEvents btnChnlimport As System.Windows.Forms.Button
    Friend WithEvents btnChnlApply As System.Windows.Forms.Button
    Friend WithEvents btnChnlDelete As System.Windows.Forms.Button
    Friend WithEvents btnChnlAdd As System.Windows.Forms.Button
    Friend WithEvents Statusbar As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ckBox_DBAllowClients As System.Windows.Forms.CheckBox
    Friend WithEvents Sno As DataGridViewTextBoxColumn
    Friend WithEvents ChannelName As DataGridViewTextBoxColumn
    Friend WithEvents Config As DataGridViewButtonColumn
    Friend WithEvents Properties As DataGridViewTextBoxColumn
    Friend WithEvents ChannelType As DataGridViewTextBoxColumn
    Friend WithEvents BindingQuery As DataGridViewTextBoxColumn
    Friend WithEvents RefreshTime As DataGridViewTextBoxColumn
End Class
