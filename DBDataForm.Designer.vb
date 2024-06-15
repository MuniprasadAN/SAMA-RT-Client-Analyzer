''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBDataForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBDataForm))
        Me.DGVDBChannelsValue = New System.Windows.Forms.DataGridView()
        Me.Sts_DBDataForm = New System.Windows.Forms.StatusStrip()
        Me.MS_Updatetime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Alarm_Timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DGVDBChannelsValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Sts_DBDataForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGVDBChannelsValue
        '
        Me.DGVDBChannelsValue.AllowUserToAddRows = False
        Me.DGVDBChannelsValue.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.DGVDBChannelsValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVDBChannelsValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVDBChannelsValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVDBChannelsValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVDBChannelsValue.ColumnHeadersHeight = 30
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVDBChannelsValue.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVDBChannelsValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVDBChannelsValue.Location = New System.Drawing.Point(0, 0)
        Me.DGVDBChannelsValue.MultiSelect = False
        Me.DGVDBChannelsValue.Name = "DGVDBChannelsValue"
        Me.DGVDBChannelsValue.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVDBChannelsValue.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVDBChannelsValue.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.DGVDBChannelsValue.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGVDBChannelsValue.RowTemplate.Height = 30
        Me.DGVDBChannelsValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVDBChannelsValue.Size = New System.Drawing.Size(728, 0)
        Me.DGVDBChannelsValue.TabIndex = 2
        '
        'Sts_DBDataForm
        '
        Me.Sts_DBDataForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.Sts_DBDataForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MS_Updatetime})
        Me.Sts_DBDataForm.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.Sts_DBDataForm.Location = New System.Drawing.Point(0, -21)
        Me.Sts_DBDataForm.Name = "Sts_DBDataForm"
        Me.Sts_DBDataForm.Size = New System.Drawing.Size(728, 24)
        Me.Sts_DBDataForm.TabIndex = 3
        Me.Sts_DBDataForm.Text = "StatusStrip1"
        '
        'MS_Updatetime
        '
        Me.MS_Updatetime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MS_Updatetime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MS_Updatetime.Name = "MS_Updatetime"
        Me.MS_Updatetime.Size = New System.Drawing.Size(88, 19)
        Me.MS_Updatetime.Text = "Updated Time:"
        '
        'Alarm_Timer
        '
        '
        'DBDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 3)
        Me.Controls.Add(Me.DGVDBChannelsValue)
        Me.Controls.Add(Me.Sts_DBDataForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(744, 42)
        Me.Name = "DBDataForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DBDataForm"
        CType(Me.DGVDBChannelsValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Sts_DBDataForm.ResumeLayout(False)
        Me.Sts_DBDataForm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGVDBChannelsValue As System.Windows.Forms.DataGridView
    Friend WithEvents Sts_DBDataForm As System.Windows.Forms.StatusStrip
    Friend WithEvents MS_Updatetime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Alarm_Timer As Timer
End Class
