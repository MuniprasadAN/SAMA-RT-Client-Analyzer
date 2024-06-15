<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Add_SAMAHistoriantags
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Add_SAMAHistoriantags))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.trvwHistoriangroups = New System.Windows.Forms.TreeView
        Me.lstbxSelectedTags = New System.Windows.Forms.ListBox
        Me.Tags = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstbxavloperations = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lstbxseltopr = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Tags.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(311, 349)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 27)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(416, 349)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 27)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'trvwHistoriangroups
        '
        Me.trvwHistoriangroups.Location = New System.Drawing.Point(9, 37)
        Me.trvwHistoriangroups.Name = "trvwHistoriangroups"
        Me.trvwHistoriangroups.PathSeparator = "."
        Me.trvwHistoriangroups.Size = New System.Drawing.Size(169, 264)
        Me.trvwHistoriangroups.TabIndex = 22
        '
        'lstbxSelectedTags
        '
        Me.lstbxSelectedTags.FormattingEnabled = True
        Me.lstbxSelectedTags.Location = New System.Drawing.Point(196, 37)
        Me.lstbxSelectedTags.Name = "lstbxSelectedTags"
        Me.lstbxSelectedTags.Size = New System.Drawing.Size(163, 264)
        Me.lstbxSelectedTags.TabIndex = 27
        '
        'Tags
        '
        Me.Tags.Controls.Add(Me.Label2)
        Me.Tags.Controls.Add(Me.Label1)
        Me.Tags.Controls.Add(Me.lstbxSelectedTags)
        Me.Tags.Controls.Add(Me.trvwHistoriangroups)
        Me.Tags.Location = New System.Drawing.Point(3, 5)
        Me.Tags.Name = "Tags"
        Me.Tags.Size = New System.Drawing.Size(383, 322)
        Me.Tags.TabIndex = 30
        Me.Tags.TabStop = False
        Me.Tags.Text = "Tags"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Selected Tags"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Available Tags"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstbxavloperations)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lstbxseltopr)
        Me.GroupBox1.Location = New System.Drawing.Point(416, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 322)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operations"
        '
        'lstbxavloperations
        '
        Me.lstbxavloperations.FormattingEnabled = True
        Me.lstbxavloperations.Items.AddRange(New Object() {"Average", "Maximum", "Minimum", "Instant", "Count", "Totalizer", "Standard Deviation", "Variance", "Sum", "Incremental Average", "Incremental Maximum", "Incremental Minimum", "Incremental Instant", "Incremental Count", "Deviation", "Rate of Change", "Incremental Totalizer", "Incremental Sum"})
        Me.lstbxavloperations.Location = New System.Drawing.Point(12, 37)
        Me.lstbxavloperations.Name = "lstbxavloperations"
        Me.lstbxavloperations.Size = New System.Drawing.Size(163, 264)
        Me.lstbxavloperations.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(193, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Selected Operations"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Available Operations"
        '
        'lstbxseltopr
        '
        Me.lstbxseltopr.FormattingEnabled = True
        Me.lstbxseltopr.Location = New System.Drawing.Point(196, 37)
        Me.lstbxseltopr.Name = "lstbxseltopr"
        Me.lstbxseltopr.Size = New System.Drawing.Size(163, 264)
        Me.lstbxseltopr.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(650, 367)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "* Add operation in order same as tag"
        '
        'Add_SAMAHistoriantags
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 389)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Tags)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Add_SAMAHistoriantags"
        Me.Text = "Add_SAMAHistoriantags"
        Me.Tags.ResumeLayout(False)
        Me.Tags.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents trvwHistoriangroups As System.Windows.Forms.TreeView
    Friend WithEvents lstbxSelectedTags As System.Windows.Forms.ListBox
    Friend WithEvents Tags As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstbxseltopr As System.Windows.Forms.ListBox
    Friend WithEvents lstbxavloperations As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
