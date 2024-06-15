<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAMAReports_Config
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAMAReports_Config))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CBx_XAxis = New System.Windows.Forms.ComboBox
        Me.XAxis = New System.Windows.Forms.Label
        Me.CBx_Interval = New System.Windows.Forms.ComboBox
        Me.Txtbx_Interval = New System.Windows.Forms.TextBox
        Me._interval = New System.Windows.Forms.Label
        Me.CBx_duration = New System.Windows.Forms.ComboBox
        Me.Txtbx_duration = New System.Windows.Forms.TextBox
        Me._duration = New System.Windows.Forms.Label
        Me.Txtbx_Description = New System.Windows.Forms.TextBox
        Me._Description = New System.Windows.Forms.Label
        Me.txtRpt = New System.Windows.Forms.TextBox
        Me._reportname = New System.Windows.Forms.Label
        Me.Btn_Save = New System.Windows.Forms.Button
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.CBx_XAxis)
        Me.Panel1.Controls.Add(Me.XAxis)
        Me.Panel1.Controls.Add(Me.CBx_Interval)
        Me.Panel1.Controls.Add(Me.Txtbx_Interval)
        Me.Panel1.Controls.Add(Me._interval)
        Me.Panel1.Controls.Add(Me.CBx_duration)
        Me.Panel1.Controls.Add(Me.Txtbx_duration)
        Me.Panel1.Controls.Add(Me._duration)
        Me.Panel1.Controls.Add(Me.Txtbx_Description)
        Me.Panel1.Controls.Add(Me._Description)
        Me.Panel1.Controls.Add(Me.txtRpt)
        Me.Panel1.Controls.Add(Me._reportname)
        Me.Panel1.Location = New System.Drawing.Point(4, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(324, 200)
        Me.Panel1.TabIndex = 0
        '
        'CBx_XAxis
        '
        Me.CBx_XAxis.FormattingEnabled = True
        Me.CBx_XAxis.Items.AddRange(New Object() {"Tags", "Time"})
        Me.CBx_XAxis.Location = New System.Drawing.Point(133, 157)
        Me.CBx_XAxis.Name = "CBx_XAxis"
        Me.CBx_XAxis.Size = New System.Drawing.Size(141, 21)
        Me.CBx_XAxis.TabIndex = 11
        '
        'XAxis
        '
        Me.XAxis.AutoSize = True
        Me.XAxis.Location = New System.Drawing.Point(15, 160)
        Me.XAxis.Name = "XAxis"
        Me.XAxis.Size = New System.Drawing.Size(48, 13)
        Me.XAxis.TabIndex = 10
        Me.XAxis.Text = "In X-Axis"
        '
        'CBx_Interval
        '
        Me.CBx_Interval.FormattingEnabled = True
        Me.CBx_Interval.Items.AddRange(New Object() {"Minutes", "Hours", "Days", "Weeks", "Months"})
        Me.CBx_Interval.Location = New System.Drawing.Point(189, 124)
        Me.CBx_Interval.Name = "CBx_Interval"
        Me.CBx_Interval.Size = New System.Drawing.Size(85, 21)
        Me.CBx_Interval.TabIndex = 9
        '
        'Txtbx_Interval
        '
        Me.Txtbx_Interval.Location = New System.Drawing.Point(133, 125)
        Me.Txtbx_Interval.Name = "Txtbx_Interval"
        Me.Txtbx_Interval.Size = New System.Drawing.Size(50, 20)
        Me.Txtbx_Interval.TabIndex = 8
        '
        '_interval
        '
        Me._interval.AutoSize = True
        Me._interval.Location = New System.Drawing.Point(15, 124)
        Me._interval.Name = "_interval"
        Me._interval.Size = New System.Drawing.Size(42, 13)
        Me._interval.TabIndex = 7
        Me._interval.Text = "Interval"
        '
        'CBx_duration
        '
        Me.CBx_duration.FormattingEnabled = True
        Me.CBx_duration.Items.AddRange(New Object() {"Minutes", "Hours", "Days", "Weeks", "Months"})
        Me.CBx_duration.Location = New System.Drawing.Point(189, 87)
        Me.CBx_duration.Name = "CBx_duration"
        Me.CBx_duration.Size = New System.Drawing.Size(85, 21)
        Me.CBx_duration.TabIndex = 6
        '
        'Txtbx_duration
        '
        Me.Txtbx_duration.Location = New System.Drawing.Point(133, 88)
        Me.Txtbx_duration.Name = "Txtbx_duration"
        Me.Txtbx_duration.Size = New System.Drawing.Size(50, 20)
        Me.Txtbx_duration.TabIndex = 5
        '
        '_duration
        '
        Me._duration.AutoSize = True
        Me._duration.Location = New System.Drawing.Point(15, 90)
        Me._duration.Name = "_duration"
        Me._duration.Size = New System.Drawing.Size(47, 13)
        Me._duration.TabIndex = 4
        Me._duration.Text = "Duration"
        '
        'Txtbx_Description
        '
        Me.Txtbx_Description.Location = New System.Drawing.Point(133, 51)
        Me.Txtbx_Description.Name = "Txtbx_Description"
        Me.Txtbx_Description.Size = New System.Drawing.Size(176, 20)
        Me.Txtbx_Description.TabIndex = 3
        '
        '_Description
        '
        Me._Description.AutoSize = True
        Me._Description.Location = New System.Drawing.Point(15, 51)
        Me._Description.Name = "_Description"
        Me._Description.Size = New System.Drawing.Size(60, 13)
        Me._Description.TabIndex = 2
        Me._Description.Text = "Description"
        '
        'txtRpt
        '
        Me.txtRpt.Location = New System.Drawing.Point(133, 17)
        Me.txtRpt.Name = "txtRpt"
        Me.txtRpt.Size = New System.Drawing.Size(176, 20)
        Me.txtRpt.TabIndex = 1
        '
        '_reportname
        '
        Me._reportname.AutoSize = True
        Me._reportname.Location = New System.Drawing.Point(15, 17)
        Me._reportname.Name = "_reportname"
        Me._reportname.Size = New System.Drawing.Size(70, 13)
        Me._reportname.TabIndex = 0
        Me._reportname.Text = "Report Name"
        '
        'Btn_Save
        '
        Me.Btn_Save.Location = New System.Drawing.Point(87, 228)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Save.TabIndex = 1
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(181, 228)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_cancel.TabIndex = 2
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'SAMAReports_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 264)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SAMAReports_Config"
        Me.Text = "Configuration"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CBx_duration As System.Windows.Forms.ComboBox
    Friend WithEvents Txtbx_duration As System.Windows.Forms.TextBox
    Friend WithEvents _duration As System.Windows.Forms.Label
    Friend WithEvents Txtbx_Description As System.Windows.Forms.TextBox
    Friend WithEvents _Description As System.Windows.Forms.Label
    Friend WithEvents txtRpt As System.Windows.Forms.TextBox
    Friend WithEvents _reportname As System.Windows.Forms.Label
    Friend WithEvents CBx_Interval As System.Windows.Forms.ComboBox
    Friend WithEvents Txtbx_Interval As System.Windows.Forms.TextBox
    Friend WithEvents _interval As System.Windows.Forms.Label
    Friend WithEvents Btn_Save As System.Windows.Forms.Button
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents CBx_XAxis As System.Windows.Forms.ComboBox
    Friend WithEvents XAxis As System.Windows.Forms.Label
End Class
