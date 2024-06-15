<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IndicatorProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IndicatorProperties))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox
        Me.TbProperty = New System.Windows.Forms.TabControl
        Me.TpComponentName = New System.Windows.Forms.TabPage
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox
        Me.CKboxScaleEnable = New System.Windows.Forms.CheckBox
        Me.lblEnd = New System.Windows.Forms.Label
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.lblStart = New System.Windows.Forms.Label
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.lblLvlCount = New System.Windows.Forms.Label
        Me.txtlvlCount = New System.Windows.Forms.TextBox
        Me.lblActiveColor = New System.Windows.Forms.Label
        Me.lbl_ActiveColor = New System.Windows.Forms.Label
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox
        Me.lblActionChannel = New System.Windows.Forms.Label
        Me.forecolorlbl = New System.Windows.Forms.Label
        Me.lblForecolor = New System.Windows.Forms.Label
        Me.lblCtrlBackColor = New System.Windows.Forms.Label
        Me.lblBKcolor = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(3, 9)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(573, 288)
        Me.GrpBoxPoperties.TabIndex = 16
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Level Indicator Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Location = New System.Drawing.Point(12, 19)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(540, 236)
        Me.TbProperty.TabIndex = 22
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.GrpMaxMinValues)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(532, 210)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.CKboxScaleEnable)
        Me.GrpMaxMinValues.Controls.Add(Me.lblEnd)
        Me.GrpMaxMinValues.Controls.Add(Me.txtEnd)
        Me.GrpMaxMinValues.Controls.Add(Me.lblStart)
        Me.GrpMaxMinValues.Controls.Add(Me.txtStart)
        Me.GrpMaxMinValues.Controls.Add(Me.lblLvlCount)
        Me.GrpMaxMinValues.Controls.Add(Me.txtlvlCount)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActiveColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lbl_ActiveColor)
        Me.GrpMaxMinValues.Controls.Add(Me.cBoxActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.forecolorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblForecolor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCtrlBackColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(6, 2)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(523, 199)
        Me.GrpMaxMinValues.TabIndex = 21
        Me.GrpMaxMinValues.TabStop = False
        '
        'CKboxScaleEnable
        '
        Me.CKboxScaleEnable.AutoSize = True
        Me.CKboxScaleEnable.Location = New System.Drawing.Point(236, 130)
        Me.CKboxScaleEnable.Name = "CKboxScaleEnable"
        Me.CKboxScaleEnable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CKboxScaleEnable.Size = New System.Drawing.Size(104, 17)
        Me.CKboxScaleEnable.TabIndex = 57
        Me.CKboxScaleEnable.Text = "Enable Scale:"
        Me.CKboxScaleEnable.UseVisualStyleBackColor = True
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(236, 98)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(77, 13)
        Me.lblEnd.TabIndex = 56
        Me.lblEnd.Text = "Range End :"
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(326, 94)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(64, 21)
        Me.txtEnd.TabIndex = 55
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(12, 97)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(84, 13)
        Me.lblStart.TabIndex = 54
        Me.lblStart.Text = "Range Start :"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(124, 93)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(64, 21)
        Me.txtStart.TabIndex = 53
        '
        'lblLvlCount
        '
        Me.lblLvlCount.AutoSize = True
        Me.lblLvlCount.Location = New System.Drawing.Point(12, 131)
        Me.lblLvlCount.Name = "lblLvlCount"
        Me.lblLvlCount.Size = New System.Drawing.Size(84, 13)
        Me.lblLvlCount.TabIndex = 52
        Me.lblLvlCount.Text = "Level Count :"
        '
        'txtlvlCount
        '
        Me.txtlvlCount.Location = New System.Drawing.Point(124, 127)
        Me.txtlvlCount.Name = "txtlvlCount"
        Me.txtlvlCount.Size = New System.Drawing.Size(39, 21)
        Me.txtlvlCount.TabIndex = 51
        '
        'lblActiveColor
        '
        Me.lblActiveColor.BackColor = System.Drawing.Color.Blue
        Me.lblActiveColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblActiveColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblActiveColor.Location = New System.Drawing.Point(124, 62)
        Me.lblActiveColor.Name = "lblActiveColor"
        Me.lblActiveColor.Size = New System.Drawing.Size(75, 20)
        Me.lblActiveColor.TabIndex = 50
        '
        'lbl_ActiveColor
        '
        Me.lbl_ActiveColor.AutoSize = True
        Me.lbl_ActiveColor.Location = New System.Drawing.Point(12, 63)
        Me.lbl_ActiveColor.Name = "lbl_ActiveColor"
        Me.lbl_ActiveColor.Size = New System.Drawing.Size(86, 13)
        Me.lbl_ActiveColor.TabIndex = 49
        Me.lbl_ActiveColor.Text = "Active Color :"
        '
        'cBoxActionChannel
        '
        Me.cBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxActionChannel.DropDownHeight = 80
        Me.cBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxActionChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cBoxActionChannel.FormattingEnabled = True
        Me.cBoxActionChannel.IntegralHeight = False
        Me.cBoxActionChannel.ItemHeight = 13
        Me.cBoxActionChannel.Location = New System.Drawing.Point(124, 29)
        Me.cBoxActionChannel.Name = "cBoxActionChannel"
        Me.cBoxActionChannel.Size = New System.Drawing.Size(298, 21)
        Me.cBoxActionChannel.TabIndex = 48
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(12, 32)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblActionChannel.TabIndex = 44
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'forecolorlbl
        '
        Me.forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.forecolorlbl.Location = New System.Drawing.Point(326, 161)
        Me.forecolorlbl.Name = "forecolorlbl"
        Me.forecolorlbl.Size = New System.Drawing.Size(77, 20)
        Me.forecolorlbl.TabIndex = 34
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(236, 165)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(76, 13)
        Me.lblForecolor.TabIndex = 33
        Me.lblForecolor.Text = "Fore Color :"
        '
        'lblCtrlBackColor
        '
        Me.lblCtrlBackColor.BackColor = System.Drawing.SystemColors.Control
        Me.lblCtrlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtrlBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCtrlBackColor.Location = New System.Drawing.Point(124, 161)
        Me.lblCtrlBackColor.Name = "lblCtrlBackColor"
        Me.lblCtrlBackColor.Size = New System.Drawing.Size(75, 20)
        Me.lblCtrlBackColor.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(12, 165)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(79, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Back Color :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(477, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(396, 260)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'IndicatorProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 302)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(593, 329)
        Me.Name = "IndicatorProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents forecolorlbl As System.Windows.Forms.Label
    Friend WithEvents lblForecolor As System.Windows.Forms.Label
    Friend WithEvents lblCtrlBackColor As System.Windows.Forms.Label
    Friend WithEvents lblBKcolor As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents lblLvlCount As System.Windows.Forms.Label
    Friend WithEvents txtlvlCount As System.Windows.Forms.TextBox
    Friend WithEvents lblActiveColor As System.Windows.Forms.Label
    Friend WithEvents lbl_ActiveColor As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents CKboxScaleEnable As System.Windows.Forms.CheckBox
End Class
