<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnnunciatorPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnunciatorPropertiesForm))
        Me.TbProperty = New System.Windows.Forms.TabControl()
        Me.TpComponentName = New System.Windows.Forms.TabPage()
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.txtFlowWidth = New System.Windows.Forms.TextBox()
        Me.lblLvlCount = New System.Windows.Forms.Label()
        Me.txtFlowHeight = New System.Windows.Forms.TextBox()
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox()
        Me.lblActionChannel = New System.Windows.Forms.Label()
        Me.lblCtrlBackColor = New System.Windows.Forms.Label()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.SuspendLayout()
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Location = New System.Drawing.Point(12, 22)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(485, 186)
        Me.TbProperty.TabIndex = 23
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.GrpMaxMinValues)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(477, 160)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.lblStart)
        Me.GrpMaxMinValues.Controls.Add(Me.txtFlowWidth)
        Me.GrpMaxMinValues.Controls.Add(Me.lblLvlCount)
        Me.GrpMaxMinValues.Controls.Add(Me.txtFlowHeight)
        Me.GrpMaxMinValues.Controls.Add(Me.cBoxActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCtrlBackColor)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(6, 2)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(460, 152)
        Me.GrpMaxMinValues.TabIndex = 21
        Me.GrpMaxMinValues.TabStop = False
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(12, 76)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(76, 13)
        Me.lblStart.TabIndex = 54
        Me.lblStart.Text = "Layout Width :"
        '
        'txtFlowWidth
        '
        Me.txtFlowWidth.Location = New System.Drawing.Point(124, 72)
        Me.txtFlowWidth.Name = "txtFlowWidth"
        Me.txtFlowWidth.Size = New System.Drawing.Size(64, 20)
        Me.txtFlowWidth.TabIndex = 53
        '
        'lblLvlCount
        '
        Me.lblLvlCount.AutoSize = True
        Me.lblLvlCount.Location = New System.Drawing.Point(256, 72)
        Me.lblLvlCount.Name = "lblLvlCount"
        Me.lblLvlCount.Size = New System.Drawing.Size(79, 13)
        Me.lblLvlCount.TabIndex = 52
        Me.lblLvlCount.Text = "Layout Height :"
        '
        'txtFlowHeight
        '
        Me.txtFlowHeight.Location = New System.Drawing.Point(358, 69)
        Me.txtFlowHeight.Name = "txtFlowHeight"
        Me.txtFlowHeight.Size = New System.Drawing.Size(64, 20)
        Me.txtFlowHeight.TabIndex = 51
        '
        'cBoxActionChannel
        '
        Me.cBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cBoxActionChannel.DropDownHeight = 80
        Me.cBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxActionChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cBoxActionChannel.FormattingEnabled = True
        Me.cBoxActionChannel.ImeMode = System.Windows.Forms.ImeMode.NoControl
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
        Me.lblActionChannel.Size = New System.Drawing.Size(85, 13)
        Me.lblActionChannel.TabIndex = 44
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'lblCtrlBackColor
        '
        Me.lblCtrlBackColor.BackColor = System.Drawing.SystemColors.Control
        Me.lblCtrlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtrlBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCtrlBackColor.Location = New System.Drawing.Point(124, 112)
        Me.lblCtrlBackColor.Name = "lblCtrlBackColor"
        Me.lblCtrlBackColor.Size = New System.Drawing.Size(64, 20)
        Me.lblCtrlBackColor.TabIndex = 25
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(12, 116)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(65, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Back Color :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(422, 214)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 29)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(341, 214)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 29)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'AnnunciatorPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 247)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TbProperty)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(521, 286)
        Me.MinimizeBox = False
        Me.Name = "AnnunciatorPropertiesForm"
        Me.Text = "AnnunciatorProperties"
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TbProperty As TabControl
    Friend WithEvents TpComponentName As TabPage
    Friend WithEvents GrpMaxMinValues As GroupBox
    Friend WithEvents lblStart As Label
    Friend WithEvents txtFlowWidth As TextBox
    Friend WithEvents lblLvlCount As Label
    Friend WithEvents txtFlowHeight As TextBox
    Friend WithEvents cBoxActionChannel As ComboBox
    Friend WithEvents lblActionChannel As Label
    Friend WithEvents lblCtrlBackColor As Label
    Friend WithEvents lblBKcolor As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
