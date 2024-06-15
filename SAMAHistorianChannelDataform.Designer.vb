<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAMAHistorianChannelDataform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAMAHistorianChannelDataform))
        Me.DGDataform = New System.Windows.Forms.DataGridView()
        CType(Me.DGDataform, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGDataform
        '
        Me.DGDataform.AllowUserToAddRows = False
        Me.DGDataform.AllowUserToDeleteRows = False
        Me.DGDataform.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDataform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDataform.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGDataform.Location = New System.Drawing.Point(0, 0)
        Me.DGDataform.Name = "DGDataform"
        Me.DGDataform.ReadOnly = True
        Me.DGDataform.RowHeadersVisible = False
        Me.DGDataform.Size = New System.Drawing.Size(763, 330)
        Me.DGDataform.TabIndex = 0
        '
        'SAMAHistorianChannelDataform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 330)
        Me.Controls.Add(Me.DGDataform)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SAMAHistorianChannelDataform"
        Me.Text = "SAMAHistorianChannelDataform"
        CType(Me.DGDataform, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGDataform As System.Windows.Forms.DataGridView
End Class
