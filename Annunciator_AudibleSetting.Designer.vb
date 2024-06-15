<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Annunciator_AudibleSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Annunciator_AudibleSetting))
        Me.Audible = New System.Windows.Forms.TabPage()
        Me.grpBoxThValue = New System.Windows.Forms.GroupBox()
        Me.btnEditAudible = New System.Windows.Forms.Button()
        Me.btnDeleteAudible = New System.Windows.Forms.Button()
        Me.btnAddAudible = New System.Windows.Forms.Button()
        Me.AudibleValue = New System.Windows.Forms.DataGridView()
        Me.clmPriorityID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmPriorityName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAlarmState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPlayDeviceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAudible1Enabled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAudible2Enabled = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Audible1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Audible2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAudible1Brwse = New System.Windows.Forms.Button()
        Me.txtAudible = New System.Windows.Forms.TextBox()
        Me.txtAudible2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAudible2Brwse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Priorityname = New System.Windows.Forms.Label()
        Me.cmboxAudiblePriority = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.btnCnl = New System.Windows.Forms.Button()
        Me.Audible.SuspendLayout()
        Me.grpBoxThValue.SuspendLayout()
        CType(Me.AudibleValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Audible
        '
        Me.Audible.Controls.Add(Me.grpBoxThValue)
        Me.Audible.Controls.Add(Me.btnAudible1Brwse)
        Me.Audible.Controls.Add(Me.txtAudible)
        Me.Audible.Controls.Add(Me.txtAudible2)
        Me.Audible.Controls.Add(Me.Label2)
        Me.Audible.Controls.Add(Me.btnAudible2Brwse)
        Me.Audible.Controls.Add(Me.Label1)
        Me.Audible.Controls.Add(Me.Priorityname)
        Me.Audible.Controls.Add(Me.cmboxAudiblePriority)
        Me.Audible.Location = New System.Drawing.Point(4, 22)
        Me.Audible.Name = "Audible"
        Me.Audible.Padding = New System.Windows.Forms.Padding(3)
        Me.Audible.Size = New System.Drawing.Size(703, 287)
        Me.Audible.TabIndex = 1
        Me.Audible.Text = "Audible"
        Me.Audible.UseVisualStyleBackColor = True
        '
        'grpBoxThValue
        '
        Me.grpBoxThValue.Controls.Add(Me.btnEditAudible)
        Me.grpBoxThValue.Controls.Add(Me.btnDeleteAudible)
        Me.grpBoxThValue.Controls.Add(Me.btnAddAudible)
        Me.grpBoxThValue.Controls.Add(Me.AudibleValue)
        Me.grpBoxThValue.Location = New System.Drawing.Point(6, 6)
        Me.grpBoxThValue.Name = "grpBoxThValue"
        Me.grpBoxThValue.Size = New System.Drawing.Size(691, 279)
        Me.grpBoxThValue.TabIndex = 60
        Me.grpBoxThValue.TabStop = False
        Me.grpBoxThValue.Text = "Settings"
        '
        'btnEditAudible
        '
        Me.btnEditAudible.Location = New System.Drawing.Point(551, 252)
        Me.btnEditAudible.Name = "btnEditAudible"
        Me.btnEditAudible.Size = New System.Drawing.Size(59, 21)
        Me.btnEditAudible.TabIndex = 25
        Me.btnEditAudible.Text = "Edit"
        Me.btnEditAudible.UseVisualStyleBackColor = True
        '
        'btnDeleteAudible
        '
        Me.btnDeleteAudible.Location = New System.Drawing.Point(627, 252)
        Me.btnDeleteAudible.Name = "btnDeleteAudible"
        Me.btnDeleteAudible.Size = New System.Drawing.Size(58, 21)
        Me.btnDeleteAudible.TabIndex = 24
        Me.btnDeleteAudible.Text = "Delete"
        Me.btnDeleteAudible.UseVisualStyleBackColor = True
        '
        'btnAddAudible
        '
        Me.btnAddAudible.Location = New System.Drawing.Point(476, 252)
        Me.btnAddAudible.Name = "btnAddAudible"
        Me.btnAddAudible.Size = New System.Drawing.Size(59, 21)
        Me.btnAddAudible.TabIndex = 23
        Me.btnAddAudible.Text = "Add"
        Me.btnAddAudible.UseVisualStyleBackColor = True
        '
        'AudibleValue
        '
        Me.AudibleValue.AllowUserToAddRows = False
        Me.AudibleValue.AllowUserToDeleteRows = False
        Me.AudibleValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AudibleValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmPriorityID, Me.ClmPriorityName, Me.clmAlarmState, Me.clmPlayDeviceName, Me.clmAudible1Enabled, Me.clmAudible2Enabled, Me.Audible1, Me.Audible2})
        Me.AudibleValue.Location = New System.Drawing.Point(9, 22)
        Me.AudibleValue.Name = "AudibleValue"
        Me.AudibleValue.RowHeadersVisible = False
        Me.AudibleValue.Size = New System.Drawing.Size(676, 224)
        Me.AudibleValue.TabIndex = 1
        '
        'clmPriorityID
        '
        Me.clmPriorityID.HeaderText = "PriorityID"
        Me.clmPriorityID.Name = "clmPriorityID"
        Me.clmPriorityID.ReadOnly = True
        Me.clmPriorityID.Visible = False
        '
        'ClmPriorityName
        '
        Me.ClmPriorityName.HeaderText = "Priority Name"
        Me.ClmPriorityName.Name = "ClmPriorityName"
        Me.ClmPriorityName.ReadOnly = True
        Me.ClmPriorityName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clmAlarmState
        '
        Me.clmAlarmState.HeaderText = "AlarmState"
        Me.clmAlarmState.Name = "clmAlarmState"
        Me.clmAlarmState.ReadOnly = True
        '
        'clmPlayDeviceName
        '
        Me.clmPlayDeviceName.HeaderText = "Audio DeviceName"
        Me.clmPlayDeviceName.Name = "clmPlayDeviceName"
        Me.clmPlayDeviceName.ReadOnly = True
        '
        'clmAudible1Enabled
        '
        Me.clmAudible1Enabled.HeaderText = "Audible1Enabled"
        Me.clmAudible1Enabled.Name = "clmAudible1Enabled"
        Me.clmAudible1Enabled.ReadOnly = True
        '
        'clmAudible2Enabled
        '
        Me.clmAudible2Enabled.HeaderText = "Audible2Enabled"
        Me.clmAudible2Enabled.Name = "clmAudible2Enabled"
        Me.clmAudible2Enabled.ReadOnly = True
        '
        'Audible1
        '
        Me.Audible1.HeaderText = "Audible1 Path"
        Me.Audible1.Name = "Audible1"
        Me.Audible1.ReadOnly = True
        Me.Audible1.Width = 150
        '
        'Audible2
        '
        Me.Audible2.HeaderText = "Audible2 Path"
        Me.Audible2.Name = "Audible2"
        Me.Audible2.ReadOnly = True
        '
        'btnAudible1Brwse
        '
        Me.btnAudible1Brwse.Location = New System.Drawing.Point(363, 69)
        Me.btnAudible1Brwse.Name = "btnAudible1Brwse"
        Me.btnAudible1Brwse.Size = New System.Drawing.Size(58, 20)
        Me.btnAudible1Brwse.TabIndex = 59
        Me.btnAudible1Brwse.Text = "Browse"
        Me.btnAudible1Brwse.UseVisualStyleBackColor = True
        '
        'txtAudible
        '
        Me.txtAudible.Location = New System.Drawing.Point(104, 69)
        Me.txtAudible.Name = "txtAudible"
        Me.txtAudible.Size = New System.Drawing.Size(229, 20)
        Me.txtAudible.TabIndex = 58
        '
        'txtAudible2
        '
        Me.txtAudible2.Location = New System.Drawing.Point(104, 112)
        Me.txtAudible2.Name = "txtAudible2"
        Me.txtAudible2.Size = New System.Drawing.Size(229, 20)
        Me.txtAudible2.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = " Audible 1 :"
        '
        'btnAudible2Brwse
        '
        Me.btnAudible2Brwse.Location = New System.Drawing.Point(363, 108)
        Me.btnAudible2Brwse.Name = "btnAudible2Brwse"
        Me.btnAudible2Brwse.Size = New System.Drawing.Size(58, 20)
        Me.btnAudible2Brwse.TabIndex = 56
        Me.btnAudible2Brwse.Text = "Browse"
        Me.btnAudible2Brwse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(3, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = " Audible 2:"
        '
        'Priorityname
        '
        Me.Priorityname.AutoSize = True
        Me.Priorityname.Location = New System.Drawing.Point(6, 26)
        Me.Priorityname.Name = "Priorityname"
        Me.Priorityname.Size = New System.Drawing.Size(69, 13)
        Me.Priorityname.TabIndex = 1
        Me.Priorityname.Text = "Priority Name"
        '
        'cmboxAudiblePriority
        '
        Me.cmboxAudiblePriority.FormattingEnabled = True
        Me.cmboxAudiblePriority.Location = New System.Drawing.Point(104, 23)
        Me.cmboxAudiblePriority.Name = "cmboxAudiblePriority"
        Me.cmboxAudiblePriority.Size = New System.Drawing.Size(229, 21)
        Me.cmboxAudiblePriority.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Audible)
        Me.TabControl1.Location = New System.Drawing.Point(12, 17)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(711, 313)
        Me.TabControl1.TabIndex = 42
        '
        'btnCnl
        '
        Me.btnCnl.Location = New System.Drawing.Point(656, 332)
        Me.btnCnl.Name = "btnCnl"
        Me.btnCnl.Size = New System.Drawing.Size(63, 22)
        Me.btnCnl.TabIndex = 58
        Me.btnCnl.Text = "Cancel"
        Me.btnCnl.UseVisualStyleBackColor = True
        '
        'Annunciator_AudibleSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 359)
        Me.Controls.Add(Me.btnCnl)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(751, 398)
        Me.MinimizeBox = False
        Me.Name = "Annunciator_AudibleSetting"
        Me.Text = "Annunciator_AudibleSetting"
        Me.Audible.ResumeLayout(False)
        Me.Audible.PerformLayout()
        Me.grpBoxThValue.ResumeLayout(False)
        CType(Me.AudibleValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Audible As TabPage
    Friend WithEvents grpBoxThValue As GroupBox
    Friend WithEvents btnDeleteAudible As Button
    Friend WithEvents btnAddAudible As Button
    Friend WithEvents AudibleValue As DataGridView
    Friend WithEvents btnAudible1Brwse As Button
    Friend WithEvents txtAudible As TextBox
    Friend WithEvents txtAudible2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAudible2Brwse As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Priorityname As Label
    Friend WithEvents cmboxAudiblePriority As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents btnEditAudible As Button
    Friend WithEvents btnCnl As Button
    Friend WithEvents clmPriorityID As DataGridViewTextBoxColumn
    Friend WithEvents ClmPriorityName As DataGridViewTextBoxColumn
    Friend WithEvents clmAlarmState As DataGridViewTextBoxColumn
    Friend WithEvents clmPlayDeviceName As DataGridViewTextBoxColumn
    Friend WithEvents clmAudible1Enabled As DataGridViewTextBoxColumn
    Friend WithEvents clmAudible2Enabled As DataGridViewTextBoxColumn
    Friend WithEvents Audible1 As DataGridViewTextBoxColumn
    Friend WithEvents Audible2 As DataGridViewTextBoxColumn
End Class
