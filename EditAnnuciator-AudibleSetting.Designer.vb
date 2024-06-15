<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditAnnuciator_AudibleSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAnnuciator_AudibleSetting))
        Me.btnCancelAudible = New System.Windows.Forms.Button()
        Me.btnsveAudible = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPriorityName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPlayAudioDevice = New System.Windows.Forms.ComboBox()
        Me.lblAlarmState = New System.Windows.Forms.Label()
        Me.cmbAlarmState = New System.Windows.Forms.ComboBox()
        Me.GrpbAudio = New System.Windows.Forms.GroupBox()
        Me.txtAudible2Filename = New System.Windows.Forms.TextBox()
        Me.btnBrowseAudibleFile = New System.Windows.Forms.Button()
        Me.txtAudible1Filename = New System.Windows.Forms.TextBox()
        Me.chkbAudible1 = New System.Windows.Forms.CheckBox()
        Me.btnBrowseAudible2File = New System.Windows.Forms.Button()
        Me.chkbAudible2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GrpbAudio.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelAudible
        '
        Me.btnCancelAudible.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancelAudible.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelAudible.Location = New System.Drawing.Point(395, 268)
        Me.btnCancelAudible.Name = "btnCancelAudible"
        Me.btnCancelAudible.Size = New System.Drawing.Size(74, 25)
        Me.btnCancelAudible.TabIndex = 61
        Me.btnCancelAudible.Text = "Cancel"
        Me.btnCancelAudible.UseVisualStyleBackColor = True
        '
        'btnsveAudible
        '
        Me.btnsveAudible.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnsveAudible.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnsveAudible.Location = New System.Drawing.Point(305, 268)
        Me.btnsveAudible.Name = "btnsveAudible"
        Me.btnsveAudible.Size = New System.Drawing.Size(74, 25)
        Me.btnsveAudible.TabIndex = 62
        Me.btnsveAudible.Text = "Submit"
        Me.btnsveAudible.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(52, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(27, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Priority Name :"
        '
        'cmbPriorityName
        '
        Me.cmbPriorityName.FormattingEnabled = True
        Me.cmbPriorityName.Location = New System.Drawing.Point(155, 14)
        Me.cmbPriorityName.Name = "cmbPriorityName"
        Me.cmbPriorityName.Size = New System.Drawing.Size(182, 21)
        Me.cmbPriorityName.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(27, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Select Playback Device  :"
        Me.Label5.UseWaitCursor = True
        '
        'cmbPlayAudioDevice
        '
        Me.cmbPlayAudioDevice.FormattingEnabled = True
        Me.cmbPlayAudioDevice.Location = New System.Drawing.Point(155, 52)
        Me.cmbPlayAudioDevice.Name = "cmbPlayAudioDevice"
        Me.cmbPlayAudioDevice.Size = New System.Drawing.Size(182, 21)
        Me.cmbPlayAudioDevice.TabIndex = 62
        '
        'lblAlarmState
        '
        Me.lblAlarmState.AutoSize = True
        Me.lblAlarmState.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAlarmState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlarmState.Location = New System.Drawing.Point(27, 96)
        Me.lblAlarmState.Name = "lblAlarmState"
        Me.lblAlarmState.Size = New System.Drawing.Size(67, 13)
        Me.lblAlarmState.TabIndex = 63
        Me.lblAlarmState.Text = "Alarm State :"
        Me.lblAlarmState.UseWaitCursor = True
        '
        'cmbAlarmState
        '
        Me.cmbAlarmState.FormattingEnabled = True
        Me.cmbAlarmState.Location = New System.Drawing.Point(155, 93)
        Me.cmbAlarmState.Name = "cmbAlarmState"
        Me.cmbAlarmState.Size = New System.Drawing.Size(182, 21)
        Me.cmbAlarmState.TabIndex = 64
        '
        'GrpbAudio
        '
        Me.GrpbAudio.Controls.Add(Me.chkbAudible2)
        Me.GrpbAudio.Controls.Add(Me.btnBrowseAudible2File)
        Me.GrpbAudio.Controls.Add(Me.chkbAudible1)
        Me.GrpbAudio.Controls.Add(Me.txtAudible1Filename)
        Me.GrpbAudio.Controls.Add(Me.btnBrowseAudibleFile)
        Me.GrpbAudio.Controls.Add(Me.txtAudible2Filename)
        Me.GrpbAudio.Location = New System.Drawing.Point(22, 126)
        Me.GrpbAudio.Name = "GrpbAudio"
        Me.GrpbAudio.Size = New System.Drawing.Size(404, 105)
        Me.GrpbAudio.TabIndex = 70
        Me.GrpbAudio.TabStop = False
        Me.GrpbAudio.Text = "Select Play Audible "
        '
        'txtAudible2Filename
        '
        Me.txtAudible2Filename.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtAudible2Filename.Enabled = False
        Me.txtAudible2Filename.Location = New System.Drawing.Point(133, 65)
        Me.txtAudible2Filename.Name = "txtAudible2Filename"
        Me.txtAudible2Filename.Size = New System.Drawing.Size(182, 20)
        Me.txtAudible2Filename.TabIndex = 58
        '
        'btnBrowseAudibleFile
        '
        Me.btnBrowseAudibleFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBrowseAudibleFile.Enabled = False
        Me.btnBrowseAudibleFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBrowseAudibleFile.Location = New System.Drawing.Point(334, 26)
        Me.btnBrowseAudibleFile.Name = "btnBrowseAudibleFile"
        Me.btnBrowseAudibleFile.Size = New System.Drawing.Size(58, 20)
        Me.btnBrowseAudibleFile.TabIndex = 56
        Me.btnBrowseAudibleFile.Text = "Browse"
        Me.btnBrowseAudibleFile.UseVisualStyleBackColor = True
        '
        'txtAudible1Filename
        '
        Me.txtAudible1Filename.AcceptsReturn = True
        Me.txtAudible1Filename.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtAudible1Filename.Location = New System.Drawing.Point(133, 26)
        Me.txtAudible1Filename.Name = "txtAudible1Filename"
        Me.txtAudible1Filename.Size = New System.Drawing.Size(182, 20)
        Me.txtAudible1Filename.TabIndex = 55
        '
        'chkbAudible1
        '
        Me.chkbAudible1.AutoSize = True
        Me.chkbAudible1.Location = New System.Drawing.Point(33, 26)
        Me.chkbAudible1.Name = "chkbAudible1"
        Me.chkbAudible1.Size = New System.Drawing.Size(70, 17)
        Me.chkbAudible1.TabIndex = 68
        Me.chkbAudible1.Text = "Audible 1"
        Me.chkbAudible1.UseVisualStyleBackColor = True
        '
        'btnBrowseAudible2File
        '
        Me.btnBrowseAudible2File.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBrowseAudible2File.Enabled = False
        Me.btnBrowseAudible2File.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBrowseAudible2File.Location = New System.Drawing.Point(334, 65)
        Me.btnBrowseAudible2File.Name = "btnBrowseAudible2File"
        Me.btnBrowseAudible2File.Size = New System.Drawing.Size(58, 20)
        Me.btnBrowseAudible2File.TabIndex = 59
        Me.btnBrowseAudible2File.Text = "Browse"
        Me.btnBrowseAudible2File.UseVisualStyleBackColor = True
        '
        'chkbAudible2
        '
        Me.chkbAudible2.AutoSize = True
        Me.chkbAudible2.Location = New System.Drawing.Point(33, 68)
        Me.chkbAudible2.Name = "chkbAudible2"
        Me.chkbAudible2.Size = New System.Drawing.Size(70, 17)
        Me.chkbAudible2.TabIndex = 69
        Me.chkbAudible2.Text = "Audible 2"
        Me.chkbAudible2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GrpbAudio)
        Me.GroupBox3.Controls.Add(Me.cmbAlarmState)
        Me.GroupBox3.Controls.Add(Me.lblAlarmState)
        Me.GroupBox3.Controls.Add(Me.cmbPlayAudioDevice)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbPriorityName)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(457, 250)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Audible"
        '
        'EditAnnuciator_AudibleSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 299)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnsveAudible)
        Me.Controls.Add(Me.btnCancelAudible)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditAnnuciator_AudibleSetting"
        Me.Text = "Annuciator AudibleSetting"
        Me.GrpbAudio.ResumeLayout(False)
        Me.GrpbAudio.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelAudible As Button
    Friend WithEvents btnsveAudible As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPriorityName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPlayAudioDevice As ComboBox
    Friend WithEvents lblAlarmState As Label
    Friend WithEvents cmbAlarmState As ComboBox
    Friend WithEvents GrpbAudio As GroupBox
    Friend WithEvents chkbAudible2 As CheckBox
    Friend WithEvents btnBrowseAudible2File As Button
    Friend WithEvents chkbAudible1 As CheckBox
    Friend WithEvents txtAudible1Filename As TextBox
    Friend WithEvents btnBrowseAudibleFile As Button
    Friend WithEvents txtAudible2Filename As TextBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
