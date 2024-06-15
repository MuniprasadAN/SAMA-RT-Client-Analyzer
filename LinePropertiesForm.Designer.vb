<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinePropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LinePropertiesForm))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox
        Me.TbProperty = New System.Windows.Forms.TabControl
        Me.TpComponentName = New System.Windows.Forms.TabPage
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox
        Me.lblThick = New System.Windows.Forms.Label
        Me.txtThick = New System.Windows.Forms.TextBox
        Me.lblBackClr = New System.Windows.Forms.Label
        Me.lblKineColor = New System.Windows.Forms.Label
        Me.cboxDirection = New System.Windows.Forms.ComboBox
        Me.lbldirection = New System.Windows.Forms.Label
        Me.cboxCapStyle = New System.Windows.Forms.ComboBox
        Me.lblCapStyle = New System.Windows.Forms.Label
        Me.cboxCap = New System.Windows.Forms.ComboBox
        Me.lblCap = New System.Windows.Forms.Label
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox
        Me.lblActionChannel = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grpBoxThValue = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GVTHValue = New System.Windows.Forms.DataGridView
        Me.Condition = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pencolor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grpBoxThValue.SuspendLayout()
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(7, 12)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(569, 297)
        Me.GrpBoxPoperties.TabIndex = 17
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Line Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
        Me.TbProperty.Controls.Add(Me.TabPage1)
        Me.TbProperty.Location = New System.Drawing.Point(12, 19)
        Me.TbProperty.Name = "TbProperty"
        Me.TbProperty.SelectedIndex = 0
        Me.TbProperty.Size = New System.Drawing.Size(540, 241)
        Me.TbProperty.TabIndex = 22
        '
        'TpComponentName
        '
        Me.TpComponentName.Controls.Add(Me.GrpMaxMinValues)
        Me.TpComponentName.Location = New System.Drawing.Point(4, 22)
        Me.TpComponentName.Name = "TpComponentName"
        Me.TpComponentName.Padding = New System.Windows.Forms.Padding(3)
        Me.TpComponentName.Size = New System.Drawing.Size(532, 215)
        Me.TpComponentName.TabIndex = 2
        Me.TpComponentName.Text = "Main"
        Me.TpComponentName.UseVisualStyleBackColor = True
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.lblThick)
        Me.GrpMaxMinValues.Controls.Add(Me.txtThick)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBackClr)
        Me.GrpMaxMinValues.Controls.Add(Me.lblKineColor)
        Me.GrpMaxMinValues.Controls.Add(Me.cboxDirection)
        Me.GrpMaxMinValues.Controls.Add(Me.lbldirection)
        Me.GrpMaxMinValues.Controls.Add(Me.cboxCapStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCapStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.cboxCap)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCap)
        Me.GrpMaxMinValues.Controls.Add(Me.cBoxActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActionChannel)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(6, 2)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(523, 203)
        Me.GrpMaxMinValues.TabIndex = 21
        Me.GrpMaxMinValues.TabStop = False
        '
        'lblThick
        '
        Me.lblThick.AutoSize = True
        Me.lblThick.Location = New System.Drawing.Point(14, 165)
        Me.lblThick.Name = "lblThick"
        Me.lblThick.Size = New System.Drawing.Size(72, 13)
        Me.lblThick.TabIndex = 68
        Me.lblThick.Text = "Thickness :"
        '
        'txtThick
        '
        Me.txtThick.Location = New System.Drawing.Point(124, 162)
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(57, 21)
        Me.txtThick.TabIndex = 67
        '
        'lblBackClr
        '
        Me.lblBackClr.BackColor = System.Drawing.Color.Black
        Me.lblBackClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBackClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBackClr.Location = New System.Drawing.Point(124, 127)
        Me.lblBackClr.Name = "lblBackClr"
        Me.lblBackClr.Size = New System.Drawing.Size(75, 20)
        Me.lblBackClr.TabIndex = 66
        '
        'lblKineColor
        '
        Me.lblKineColor.AutoSize = True
        Me.lblKineColor.Location = New System.Drawing.Point(12, 131)
        Me.lblKineColor.Name = "lblKineColor"
        Me.lblKineColor.Size = New System.Drawing.Size(74, 13)
        Me.lblKineColor.TabIndex = 65
        Me.lblKineColor.Text = "Line Color :"
        '
        'cboxDirection
        '
        Me.cboxDirection.FormattingEnabled = True
        Me.cboxDirection.Items.AddRange(New Object() {"Horizontal", "Vertical", "LeftBottom", "RightBottom", "RightBottomTriangle", "LeftBottomTriangle"})
        Me.cboxDirection.Location = New System.Drawing.Point(124, 97)
        Me.cboxDirection.Name = "cboxDirection"
        Me.cboxDirection.Size = New System.Drawing.Size(139, 21)
        Me.cboxDirection.TabIndex = 62
        '
        'lbldirection
        '
        Me.lbldirection.AutoSize = True
        Me.lbldirection.Location = New System.Drawing.Point(12, 101)
        Me.lbldirection.Name = "lbldirection"
        Me.lbldirection.Size = New System.Drawing.Size(94, 13)
        Me.lbldirection.TabIndex = 61
        Me.lbldirection.Text = "Line Direction :"
        '
        'cboxCapStyle
        '
        Me.cboxCapStyle.FormattingEnabled = True
        Me.cboxCapStyle.Items.AddRange(New Object() {"None", "Arrow", "Cicle"})
        Me.cboxCapStyle.Location = New System.Drawing.Point(331, 63)
        Me.cboxCapStyle.Name = "cboxCapStyle"
        Me.cboxCapStyle.Size = New System.Drawing.Size(75, 21)
        Me.cboxCapStyle.TabIndex = 60
        '
        'lblCapStyle
        '
        Me.lblCapStyle.AutoSize = True
        Me.lblCapStyle.Location = New System.Drawing.Point(226, 67)
        Me.lblCapStyle.Name = "lblCapStyle"
        Me.lblCapStyle.Size = New System.Drawing.Size(72, 13)
        Me.lblCapStyle.TabIndex = 59
        Me.lblCapStyle.Text = "Cap Style :"
        '
        'cboxCap
        '
        Me.cboxCap.FormattingEnabled = True
        Me.cboxCap.Items.AddRange(New Object() {"None", "Start Cap", "End Cap", "Both"})
        Me.cboxCap.Location = New System.Drawing.Point(124, 64)
        Me.cboxCap.Name = "cboxCap"
        Me.cboxCap.Size = New System.Drawing.Size(75, 21)
        Me.cboxCap.TabIndex = 58
        '
        'lblCap
        '
        Me.lblCap.AutoSize = True
        Me.lblCap.Location = New System.Drawing.Point(12, 68)
        Me.lblCap.Name = "lblCap"
        Me.lblCap.Size = New System.Drawing.Size(66, 13)
        Me.lblCap.TabIndex = 57
        Me.lblCap.Text = "Line Cap :"
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
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpBoxThValue)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(532, 215)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Threshold settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpBoxThValue
        '
        Me.grpBoxThValue.Controls.Add(Me.btnDelete)
        Me.grpBoxThValue.Controls.Add(Me.btnAdd)
        Me.grpBoxThValue.Controls.Add(Me.GVTHValue)
        Me.grpBoxThValue.Location = New System.Drawing.Point(6, -1)
        Me.grpBoxThValue.Name = "grpBoxThValue"
        Me.grpBoxThValue.Size = New System.Drawing.Size(504, 220)
        Me.grpBoxThValue.TabIndex = 1
        Me.grpBoxThValue.TabStop = False
        Me.grpBoxThValue.Text = "Threshold settings"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(407, 56)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 21)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(407, 29)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 21)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GVTHValue
        '
        Me.GVTHValue.AllowUserToAddRows = False
        Me.GVTHValue.AllowUserToDeleteRows = False
        Me.GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Condition, Me.Value, Me.Pencolor})
        Me.GVTHValue.Location = New System.Drawing.Point(6, 20)
        Me.GVTHValue.Name = "GVTHValue"
        Me.GVTHValue.RowHeadersVisible = False
        Me.GVTHValue.Size = New System.Drawing.Size(395, 183)
        Me.GVTHValue.TabIndex = 1
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.Name = "Condition"
        Me.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Value
        '
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        '
        'Pencolor
        '
        Me.Pencolor.HeaderText = "Color"
        Me.Pencolor.Name = "Pencolor"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(476, 266)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(395, 266)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 21)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'LinePropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 313)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LinePropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.grpBoxThValue.ResumeLayout(False)
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents cBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboxDirection As System.Windows.Forms.ComboBox
    Friend WithEvents lbldirection As System.Windows.Forms.Label
    Friend WithEvents cboxCapStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblCapStyle As System.Windows.Forms.Label
    Friend WithEvents cboxCap As System.Windows.Forms.ComboBox
    Friend WithEvents lblCap As System.Windows.Forms.Label
    Friend WithEvents lblBackClr As System.Windows.Forms.Label
    Friend WithEvents lblKineColor As System.Windows.Forms.Label
    Friend WithEvents lblThick As System.Windows.Forms.Label
    Friend WithEvents txtThick As System.Windows.Forms.TextBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grpBoxThValue As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GVTHValue As System.Windows.Forms.DataGridView
    Friend WithEvents Condition As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pencolor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
