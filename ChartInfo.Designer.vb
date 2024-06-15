<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChartInfo))
        Me.picBoxChartInfo = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.picBoxChartInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBoxChartInfo
        '
        Me.picBoxChartInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBoxChartInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picBoxChartInfo.Image = CType(resources.GetObject("picBoxChartInfo.Image"), System.Drawing.Image)
        Me.picBoxChartInfo.Location = New System.Drawing.Point(0, 0)
        Me.picBoxChartInfo.Name = "picBoxChartInfo"
        Me.picBoxChartInfo.Size = New System.Drawing.Size(672, 501)
        Me.picBoxChartInfo.TabIndex = 0
        Me.picBoxChartInfo.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(601, 476)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChartInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(672, 501)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.picBoxChartInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(690, 540)
        Me.Name = "ChartInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChartInfo"
        CType(Me.picBoxChartInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picBoxChartInfo As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As Button
End Class
