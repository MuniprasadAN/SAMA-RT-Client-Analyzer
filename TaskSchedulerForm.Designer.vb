<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskSchedulerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskSchedulerForm))
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nnhour = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Component = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Task = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.LocationPath = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Config = New System.Windows.Forms.DataGridViewButtonColumn
        Me.TaskCreatedTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlChnlTop = New System.Windows.Forms.Panel
        Me.btnChnlApply = New System.Windows.Forms.Button
        Me.btnChnlDelete = New System.Windows.Forms.Button
        Me.btnChnlAdd = New System.Windows.Forms.Button
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
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
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.nnhour, Me.Component, Me.Task, Me.LocationPath, Me.Config, Me.TaskCreatedTime})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 38)
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.GVChannelsAdd.Size = New System.Drawing.Size(731, 272)
        Me.GVChannelsAdd.TabIndex = 4
        '
        'Sno
        '
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.Width = 99
        '
        'nnhour
        '
        Me.nnhour.FillWeight = 110.7445!
        Me.nnhour.HeaderText = "Intervel"
        Me.nnhour.Items.AddRange(New Object() {"10 -min", "30 -min", "1 -hr", "2 -hr", "12 -hr", "24 -hr"})
        Me.nnhour.Name = "nnhour"
        Me.nnhour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nnhour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nnhour.Width = 111
        '
        'Component
        '
        Me.Component.FillWeight = 110.7445!
        Me.Component.HeaderText = "Component Name"
        Me.Component.Name = "Component"
        Me.Component.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Component.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Component.Width = 110
        '
        'Task
        '
        Me.Task.FillWeight = 110.7445!
        Me.Task.HeaderText = "Task"
        Me.Task.Items.AddRange(New Object() {"Print", "Export Image/ CSV File", "EMail"})
        Me.Task.Name = "Task"
        Me.Task.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Task.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Task.Width = 110
        '
        'LocationPath
        '
        Me.LocationPath.HeaderText = "Location/Printer Name"
        Me.LocationPath.Name = "LocationPath"
        Me.LocationPath.ReadOnly = True
        Me.LocationPath.Width = 99
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
        '
        'TaskCreatedTime
        '
        Me.TaskCreatedTime.HeaderText = "Task Created Time"
        Me.TaskCreatedTime.Name = "TaskCreatedTime"
        Me.TaskCreatedTime.ReadOnly = True
        Me.TaskCreatedTime.Width = 99
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
        Me.pnlChnlTop.Size = New System.Drawing.Size(731, 38)
        Me.pnlChnlTop.TabIndex = 5
        '
        'btnChnlApply
        '
        Me.btnChnlApply.Location = New System.Drawing.Point(189, 6)
        Me.btnChnlApply.Name = "btnChnlApply"
        Me.btnChnlApply.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlApply.TabIndex = 8
        Me.btnChnlApply.Text = "Apply"
        Me.btnChnlApply.UseVisualStyleBackColor = True
        '
        'btnChnlDelete
        '
        Me.btnChnlDelete.Location = New System.Drawing.Point(81, 6)
        Me.btnChnlDelete.Name = "btnChnlDelete"
        Me.btnChnlDelete.Size = New System.Drawing.Size(63, 23)
        Me.btnChnlDelete.TabIndex = 7
        Me.btnChnlDelete.Text = "Delete"
        Me.btnChnlDelete.UseVisualStyleBackColor = True
        '
        'btnChnlAdd
        '
        Me.btnChnlAdd.Location = New System.Drawing.Point(11, 6)
        Me.btnChnlAdd.Name = "btnChnlAdd"
        Me.btnChnlAdd.Size = New System.Drawing.Size(63, 23)
        Me.btnChnlAdd.TabIndex = 6
        Me.btnChnlAdd.Text = "Add"
        Me.btnChnlAdd.UseVisualStyleBackColor = True
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 310)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(731, 29)
        Me.pnlBottom.TabIndex = 6
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(655, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(63, 21)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TaskSchedulerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 339)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.Controls.Add(Me.pnlChnlTop)
        Me.Controls.Add(Me.pnlBottom)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(737, 361)
        Me.Name = "TaskSchedulerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule Task"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GVChannelsAdd As System.Windows.Forms.DataGridView
    Friend WithEvents pnlChnlTop As System.Windows.Forms.Panel
    Friend WithEvents btnChnlApply As System.Windows.Forms.Button
    Friend WithEvents btnChnlDelete As System.Windows.Forms.Button
    Friend WithEvents btnChnlAdd As System.Windows.Forms.Button
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Sno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nnhour As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Component As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Task As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents LocationPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Config As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents TaskCreatedTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
