<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Annunciator_ColorSetting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Annunciator_ColorSetting))
        Me.Cancel = New System.Windows.Forms.Button()
        Me.dataGridAlamStatus = New System.Windows.Forms.DataGridView()
        Me.clmState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmforecolor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmbackcolor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmblink = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmblinkspeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWidth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnHeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dataGridAlamStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(589, 191)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(109, 28)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'dataGridAlamStatus
        '
        Me.dataGridAlamStatus.AllowUserToAddRows = False
        Me.dataGridAlamStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridAlamStatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridAlamStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridAlamStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmState, Me.clmforecolor, Me.clmbackcolor, Me.clmblink, Me.clmblinkspeed, Me.clmWidth, Me.clmnHeight})
        Me.dataGridAlamStatus.Location = New System.Drawing.Point(12, 12)
        Me.dataGridAlamStatus.Name = "dataGridAlamStatus"
        Me.dataGridAlamStatus.RowHeadersVisible = False
        Me.dataGridAlamStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dataGridAlamStatus.Size = New System.Drawing.Size(686, 173)
        Me.dataGridAlamStatus.TabIndex = 8
        '
        'clmState
        '
        Me.clmState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmState.HeaderText = "State"
        Me.clmState.Name = "clmState"
        Me.clmState.ReadOnly = True
        Me.clmState.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clmforecolor
        '
        Me.clmforecolor.HeaderText = "Fore Color"
        Me.clmforecolor.Name = "clmforecolor"
        Me.clmforecolor.ReadOnly = True
        Me.clmforecolor.Width = 80
        '
        'clmbackcolor
        '
        Me.clmbackcolor.HeaderText = "Back Color"
        Me.clmbackcolor.Name = "clmbackcolor"
        Me.clmbackcolor.ReadOnly = True
        Me.clmbackcolor.Width = 84
        '
        'clmblink
        '
        Me.clmblink.HeaderText = "Blink"
        Me.clmblink.Name = "clmblink"
        Me.clmblink.ReadOnly = True
        Me.clmblink.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmblink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmblink.Width = 55
        '
        'clmblinkspeed
        '
        DataGridViewCellStyle1.NullValue = Nothing
        Me.clmblinkspeed.DefaultCellStyle = DataGridViewCellStyle1
        Me.clmblinkspeed.HeaderText = "Blink Speed  (Seconds)"
        Me.clmblinkspeed.Name = "clmblinkspeed"
        Me.clmblinkspeed.ReadOnly = True
        Me.clmblinkspeed.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmblinkspeed.Width = 143
        '
        'clmWidth
        '
        Me.clmWidth.HeaderText = "Window (Width)"
        Me.clmWidth.Name = "clmWidth"
        Me.clmWidth.ReadOnly = True
        Me.clmWidth.Width = 108
        '
        'clmnHeight
        '
        Me.clmnHeight.HeaderText = "Window (Height)"
        Me.clmnHeight.Name = "clmnHeight"
        Me.clmnHeight.ReadOnly = True
        Me.clmnHeight.Width = 111
        '
        'Annunciator_ColorSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 226)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.dataGridAlamStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(726, 265)
        Me.MinimizeBox = False
        Me.Name = "Annunciator_ColorSetting"
        Me.Text = "Annunciator_ColorSetting"
        CType(Me.dataGridAlamStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents Cancel As Button
    Private WithEvents dataGridAlamStatus As DataGridView
    Friend WithEvents clmState As DataGridViewTextBoxColumn
    Friend WithEvents clmforecolor As DataGridViewTextBoxColumn
    Friend WithEvents clmbackcolor As DataGridViewTextBoxColumn
    Friend WithEvents clmblink As DataGridViewCheckBoxColumn
    Friend WithEvents clmblinkspeed As DataGridViewTextBoxColumn
    Friend WithEvents clmWidth As DataGridViewTextBoxColumn
    Friend WithEvents clmnHeight As DataGridViewTextBoxColumn
End Class
