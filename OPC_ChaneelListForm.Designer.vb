<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcChaneelListForm
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpcChaneelListForm))
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView
        Me.pnlChnlTop = New System.Windows.Forms.Panel
        Me.btnChnlExport = New System.Windows.Forms.Button
        Me.btnChnlimport = New System.Windows.Forms.Button
        Me.btnChnlApply = New System.Windows.Forms.Button
        Me.btnChnlDelete = New System.Windows.Forms.Button
        Me.btnChnlAdd = New System.Windows.Forms.Button
        Me.Statusbar = New System.Windows.Forms.StatusStrip
        Me.ckBox_OPCAllowClients = New System.Windows.Forms.CheckBox
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChannelName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn
        Me.OPCServer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BindingQuery = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefreshTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataStorage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Multiview = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.ChannelName, Me.Config, Me.OPCServer, Me.BindingQuery, Me.RefreshTime, Me.Length, Me.DataStorage, Me.Multiview})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 44)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GVChannelsAdd.Size = New System.Drawing.Size(821, 423)
        Me.GVChannelsAdd.TabIndex = 4
        '
        'pnlChnlTop
        '
        Me.pnlChnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChnlTop.Controls.Add(Me.ckBox_OPCAllowClients)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlExport)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlimport)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlApply)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlDelete)
        Me.pnlChnlTop.Controls.Add(Me.btnChnlAdd)
        Me.pnlChnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlChnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlChnlTop.Name = "pnlChnlTop"
        Me.pnlChnlTop.Size = New System.Drawing.Size(821, 44)
        Me.pnlChnlTop.TabIndex = 5
        '
        'btnChnlExport
        '
        Me.btnChnlExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChnlExport.Location = New System.Drawing.Point(738, 6)
        Me.btnChnlExport.Name = "btnChnlExport"
        Me.btnChnlExport.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlExport.TabIndex = 10
        Me.btnChnlExport.Text = "Export"
        Me.btnChnlExport.UseVisualStyleBackColor = True
        '
        'btnChnlimport
        '
        Me.btnChnlimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChnlimport.Location = New System.Drawing.Point(662, 6)
        Me.btnChnlimport.Name = "btnChnlimport"
        Me.btnChnlimport.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlimport.TabIndex = 9
        Me.btnChnlimport.Text = "Import"
        Me.btnChnlimport.UseVisualStyleBackColor = True
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
        Me.Statusbar.Location = New System.Drawing.Point(0, 467)
        Me.Statusbar.Name = "Statusbar"
        Me.Statusbar.Size = New System.Drawing.Size(821, 22)
        Me.Statusbar.TabIndex = 6
        Me.Statusbar.Text = "StatusStrip1"
        '
        'ckBox_OPCAllowClients
        '
        Me.ckBox_OPCAllowClients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckBox_OPCAllowClients.AutoSize = True
        Me.ckBox_OPCAllowClients.Location = New System.Drawing.Point(542, 12)
        Me.ckBox_OPCAllowClients.Name = "ckBox_OPCAllowClients"
        Me.ckBox_OPCAllowClients.Size = New System.Drawing.Size(99, 17)
        Me.ckBox_OPCAllowClients.TabIndex = 11
        Me.ckBox_OPCAllowClients.Text = "Allow Clients"
        Me.ckBox_OPCAllowClients.UseVisualStyleBackColor = True
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
        Me.ChannelName.HeaderText = "OPC Points"
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Width = 95
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
        'OPCServer
        '
        Me.OPCServer.HeaderText = "OPC Server"
        Me.OPCServer.Name = "OPCServer"
        Me.OPCServer.ReadOnly = True
        '
        'BindingQuery
        '
        Me.BindingQuery.FillWeight = 110.7445!
        Me.BindingQuery.HeaderText = "OPC Tags"
        Me.BindingQuery.Name = "BindingQuery"
        Me.BindingQuery.ReadOnly = True
        Me.BindingQuery.Width = 88
        '
        'RefreshTime
        '
        Me.RefreshTime.HeaderText = "Refresh Time(sec)"
        Me.RefreshTime.Name = "RefreshTime"
        Me.RefreshTime.Width = 137
        '
        'Length
        '
        Me.Length.HeaderText = "Points Length"
        Me.Length.Name = "Length"
        Me.Length.Width = 108
        '
        'DataStorage
        '
        Me.DataStorage.HeaderText = "History(nn Points)"
        Me.DataStorage.Name = "DataStorage"
        Me.DataStorage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataStorage.Width = 134
        '
        'Multiview
        '
        Me.Multiview.HeaderText = "Multiview"
        Me.Multiview.Name = "Multiview"
        Me.Multiview.ReadOnly = True
        Me.Multiview.Visible = False
        Me.Multiview.Width = 84
        '
        'OpcChaneelListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 489)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.Controls.Add(Me.pnlChnlTop)
        Me.Controls.Add(Me.Statusbar)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OpcChaneelListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OPC Channels"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.pnlChnlTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GVChannelsAdd As System.Windows.Forms.DataGridView
    Friend WithEvents pnlChnlTop As System.Windows.Forms.Panel
    Friend WithEvents btnChnlExport As System.Windows.Forms.Button
    Friend WithEvents btnChnlimport As System.Windows.Forms.Button
    Friend WithEvents btnChnlApply As System.Windows.Forms.Button
    Friend WithEvents btnChnlDelete As System.Windows.Forms.Button
    Friend WithEvents btnChnlAdd As System.Windows.Forms.Button
    Friend WithEvents Statusbar As System.Windows.Forms.StatusStrip
    Friend WithEvents ckBox_OPCAllowClients As System.Windows.Forms.CheckBox
    Friend WithEvents Sno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChannelName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Config As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents OPCServer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BindingQuery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefreshTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Length As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataStorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Multiview As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
