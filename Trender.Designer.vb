<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Trender
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ChartControl1 = New SAMAAnalyzer.ChartControl(Me.components)
        Me.DataGridViewCtrl1 = New SAMAAnalyzer.DataGridViewCtrl(Me.components)
        Me.SerialNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PenColour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LowRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HighRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChartControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewCtrl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(500, 250)
        Me.SplitContainer1.SplitterDistance = 160
        Me.SplitContainer1.TabIndex = 0
        '
        'ChartControl1
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartControl1.ChartAreas.Add(ChartArea1)
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.ChartControl1.Legends.Add(Legend1)
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartControl1.Series.Add(Series1)
        Me.ChartControl1.Size = New System.Drawing.Size(500, 160)
        Me.ChartControl1.TabIndex = 0
        Me.ChartControl1.Text = "ChartControl1"
        '
        'DataGridViewCtrl1
        '
        Me.DataGridViewCtrl1.AllowUserToAddRows = False
        Me.DataGridViewCtrl1.AllowUserToDeleteRows = False
        Me.DataGridViewCtrl1.AllowUserToOrderColumns = True
        Me.DataGridViewCtrl1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewCtrl1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridViewCtrl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCtrl1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNo, Me.TagName, Me.IsActive, Me.PenColour, Me.TagValue, Me.Column1, Me.LowRange, Me.HighRange})
        Me.DataGridViewCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewCtrl1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewCtrl1.MultiSelect = False
        Me.DataGridViewCtrl1.Name = "DataGridViewCtrl1"
        Me.DataGridViewCtrl1.RowHeadersVisible = False
        Me.DataGridViewCtrl1.Size = New System.Drawing.Size(500, 86)
        Me.DataGridViewCtrl1.TabIndex = 0
        '
        'SerialNo
        '
        Me.SerialNo.HeaderText = "S.No"
        Me.SerialNo.Name = "SerialNo"
        Me.SerialNo.ReadOnly = True
        '
        'TagName
        '
        Me.TagName.HeaderText = "Tag Name"
        Me.TagName.Name = "TagName"
        Me.TagName.ReadOnly = True
        '
        'IsActive
        '
        Me.IsActive.HeaderText = "Active"
        Me.IsActive.Name = "IsActive"
        '
        'PenColour
        '
        Me.PenColour.HeaderText = "PenColour"
        Me.PenColour.Name = "PenColour"
        Me.PenColour.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PenColour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TagValue
        '
        Me.TagValue.HeaderText = "Tag Value"
        Me.TagValue.Name = "TagValue"
        Me.TagValue.ReadOnly = True
        Me.TagValue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TagValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'LowRange
        '
        Me.LowRange.HeaderText = "LowRange"
        Me.LowRange.Name = "LowRange"
        '
        'HighRange
        '
        Me.HighRange.HeaderText = "High Range"
        Me.HighRange.Name = "HighRange"
        '
        'Trender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Trender"
        Me.Size = New System.Drawing.Size(500, 250)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ChartControl1 As SAMAAnalyzer.ChartControl
    Friend WithEvents DataGridViewCtrl1 As SAMAAnalyzer.DataGridViewCtrl
    Friend WithEvents SerialNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PenColour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TagValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LowRange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HighRange As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
