<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValvePropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValvePropertiesForm))
        Me.GrpBoxPoperties = New System.Windows.Forms.GroupBox
        Me.TbProperty = New System.Windows.Forms.TabControl
        Me.TpComponentName = New System.Windows.Forms.TabPage
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox
        Me.lblTh = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnadd = New System.Windows.Forms.Button
        Me.GVTHValue = New System.Windows.Forms.DataGridView
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBackClr = New System.Windows.Forms.Label
        Me.lblKineColor = New System.Windows.Forms.Label
        Me.cBoxActionChannel = New System.Windows.Forms.ComboBox
        Me.lblActionChannel = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.GrpBoxPoperties.SuspendLayout()
        Me.TbProperty.SuspendLayout()
        Me.TpComponentName.SuspendLayout()
        Me.GrpMaxMinValues.SuspendLayout()
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxPoperties
        '
        Me.GrpBoxPoperties.Controls.Add(Me.TbProperty)
        Me.GrpBoxPoperties.Controls.Add(Me.btnCancel)
        Me.GrpBoxPoperties.Controls.Add(Me.btnOK)
        Me.GrpBoxPoperties.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxPoperties.Location = New System.Drawing.Point(7, 1)
        Me.GrpBoxPoperties.Name = "GrpBoxPoperties"
        Me.GrpBoxPoperties.Size = New System.Drawing.Size(569, 297)
        Me.GrpBoxPoperties.TabIndex = 18
        Me.GrpBoxPoperties.TabStop = False
        Me.GrpBoxPoperties.Text = "Valve  Properties"
        '
        'TbProperty
        '
        Me.TbProperty.Controls.Add(Me.TpComponentName)
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
        Me.GrpMaxMinValues.Controls.Add(Me.lblTh)
        Me.GrpMaxMinValues.Controls.Add(Me.btnDelete)
        Me.GrpMaxMinValues.Controls.Add(Me.btnadd)
        Me.GrpMaxMinValues.Controls.Add(Me.GVTHValue)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBackClr)
        Me.GrpMaxMinValues.Controls.Add(Me.lblKineColor)
        Me.GrpMaxMinValues.Controls.Add(Me.cBoxActionChannel)
        Me.GrpMaxMinValues.Controls.Add(Me.lblActionChannel)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(6, 2)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(523, 203)
        Me.GrpMaxMinValues.TabIndex = 21
        Me.GrpMaxMinValues.TabStop = False
        '
        'lblTh
        '
        Me.lblTh.AutoSize = True
        Me.lblTh.Location = New System.Drawing.Point(6, 97)
        Me.lblTh.Name = "lblTh"
        Me.lblTh.Size = New System.Drawing.Size(72, 13)
        Me.lblTh.TabIndex = 70
        Me.lblTh.Text = "Threshold :"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(431, 120)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 21)
        Me.btnDelete.TabIndex = 69
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(431, 93)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(59, 21)
        Me.btnadd.TabIndex = 68
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'GVTHValue
        '
        Me.GVTHValue.AllowUserToAddRows = False
        Me.GVTHValue.AllowUserToDeleteRows = False
        Me.GVTHValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GVTHValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.GVTHValue.Location = New System.Drawing.Point(107, 85)
        Me.GVTHValue.Name = "GVTHValue"
        Me.GVTHValue.RowHeadersVisible = False
        Me.GVTHValue.Size = New System.Drawing.Size(303, 112)
        Me.GVTHValue.TabIndex = 67
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "Condition"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Color"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'lblBackClr
        '
        Me.lblBackClr.BackColor = System.Drawing.Color.Black
        Me.lblBackClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBackClr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBackClr.Location = New System.Drawing.Point(107, 49)
        Me.lblBackClr.Name = "lblBackClr"
        Me.lblBackClr.Size = New System.Drawing.Size(75, 20)
        Me.lblBackClr.TabIndex = 66
        '
        'lblKineColor
        '
        Me.lblKineColor.AutoSize = True
        Me.lblKineColor.Location = New System.Drawing.Point(4, 51)
        Me.lblKineColor.Name = "lblKineColor"
        Me.lblKineColor.Size = New System.Drawing.Size(47, 13)
        Me.lblKineColor.TabIndex = 65
        Me.lblKineColor.Text = "Color :"
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
        Me.cBoxActionChannel.Location = New System.Drawing.Point(107, 16)
        Me.cBoxActionChannel.Name = "cBoxActionChannel"
        Me.cBoxActionChannel.Size = New System.Drawing.Size(298, 21)
        Me.cBoxActionChannel.TabIndex = 48
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(4, 17)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(102, 13)
        Me.lblActionChannel.TabIndex = 44
        Me.lblActionChannel.Text = "Action Channel :"
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
        'ValvePropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 301)
        Me.Controls.Add(Me.GrpBoxPoperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(586, 328)
        Me.Name = "ValvePropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties"
        Me.GrpBoxPoperties.ResumeLayout(False)
        Me.TbProperty.ResumeLayout(False)
        Me.TpComponentName.ResumeLayout(False)
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        CType(Me.GVTHValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxPoperties As System.Windows.Forms.GroupBox
    Friend WithEvents TbProperty As System.Windows.Forms.TabControl
    Friend WithEvents TpComponentName As System.Windows.Forms.TabPage
    Friend WithEvents GrpMaxMinValues As System.Windows.Forms.GroupBox
    Friend WithEvents lblBackClr As System.Windows.Forms.Label
    Friend WithEvents lblKineColor As System.Windows.Forms.Label
    Friend WithEvents cBoxActionChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblActionChannel As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblTh As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents GVTHValue As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
