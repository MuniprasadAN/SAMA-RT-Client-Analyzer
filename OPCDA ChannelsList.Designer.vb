<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCDA_ChannelsList
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnChnlApply = New System.Windows.Forms.Button()
        Me.btnChnlDelete = New System.Windows.Forms.Button()
        Me.Multiview = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataStorage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefreshTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingQuery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPCServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ChannelName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView()
        Me.btnChnlAdd = New System.Windows.Forms.Button()
        Me.pnlChnlTop = New System.Windows.Forms.Panel()
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChnlTop.SuspendLayout()
        Me.SuspendLayout()
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
        'Multiview
        '
        Me.Multiview.HeaderText = "Multiview"
        Me.Multiview.Name = "Multiview"
        Me.Multiview.ReadOnly = True
        Me.Multiview.Visible = False
        Me.Multiview.Width = 84
        '
        'DataStorage
        '
        Me.DataStorage.HeaderText = "History(nn Points)"
        Me.DataStorage.Name = "DataStorage"
        Me.DataStorage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataStorage.Width = 134
        '
        'Length
        '
        Me.Length.HeaderText = "Points Length"
        Me.Length.Name = "Length"
        Me.Length.Width = 108
        '
        'RefreshTime
        '
        Me.RefreshTime.HeaderText = "Refresh Time(sec)"
        Me.RefreshTime.Name = "RefreshTime"
        Me.RefreshTime.Width = 137
        '
        'BindingQuery
        '
        Me.BindingQuery.FillWeight = 110.7445!
        Me.BindingQuery.HeaderText = "OPC Tags"
        Me.BindingQuery.Name = "BindingQuery"
        Me.BindingQuery.ReadOnly = True
        Me.BindingQuery.Width = 88
        '
        'OPCServer
        '
        Me.OPCServer.HeaderText = "OPC Server"
        Me.OPCServer.Name = "OPCServer"
        Me.OPCServer.ReadOnly = True
        '
        'Config
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = "Config"
        Me.Config.DefaultCellStyle = DataGridViewCellStyle4
        Me.Config.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Config.HeaderText = "Configuration"
        Me.Config.Name = "Config"
        Me.Config.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Config.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Config.Text = ""
        Me.Config.ToolTipText = "Click"
        Me.Config.Width = 109
        '
        'ChannelName
        '
        Me.ChannelName.FillWeight = 110.7445!
        Me.ChannelName.HeaderText = "OPC Points"
        Me.ChannelName.Name = "ChannelName"
        Me.ChannelName.Width = 95
        '
        'Sno
        '
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.ReadOnly = True
        Me.Sno.Width = 47
        '
        'GVChannelsAdd
        '
        Me.GVChannelsAdd.AllowUserToAddRows = False
        Me.GVChannelsAdd.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GVChannelsAdd.ColumnHeadersHeight = 25
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.ChannelName, Me.Config, Me.OPCServer, Me.BindingQuery, Me.RefreshTime, Me.Length, Me.DataStorage, Me.Multiview})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 44)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GVChannelsAdd.Size = New System.Drawing.Size(821, 445)
        Me.GVChannelsAdd.TabIndex = 7
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
        Me.pnlChnlTop.TabIndex = 8
        '
        'OPCDA_ChannelsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 489)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.Controls.Add(Me.pnlChnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(837, 528)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(837, 528)
        Me.Name = "OPCDA_ChannelsList"
        Me.Text = "OPCDA_ChannelsList"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnChnlApply As Button
    Friend WithEvents btnChnlDelete As Button
    Friend WithEvents Multiview As DataGridViewTextBoxColumn
    Friend WithEvents DataStorage As DataGridViewTextBoxColumn
    Friend WithEvents Length As DataGridViewTextBoxColumn
    Friend WithEvents RefreshTime As DataGridViewTextBoxColumn
    Friend WithEvents BindingQuery As DataGridViewTextBoxColumn
    Friend WithEvents OPCServer As DataGridViewTextBoxColumn
    Friend WithEvents Config As DataGridViewButtonColumn
    Friend WithEvents ChannelName As DataGridViewTextBoxColumn
    Friend WithEvents Sno As DataGridViewTextBoxColumn
    Friend WithEvents GVChannelsAdd As DataGridView
    Friend WithEvents btnChnlAdd As Button
    Friend WithEvents pnlChnlTop As Panel
End Class
