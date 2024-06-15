<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCDA_Servers
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GVChannelsAdd = New System.Windows.Forms.DataGridView()
        Me.Sno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Configname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimaryIPaddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimaryPortNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RedundantIPAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SecondaryPortNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefreshInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnChnlEdit = New System.Windows.Forms.Button()
        Me.btnChnlApply = New System.Windows.Forms.Button()
        Me.btnChnlDelete = New System.Windows.Forms.Button()
        Me.btnChnlAdd = New System.Windows.Forms.Button()
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GVChannelsAdd
        '
        Me.GVChannelsAdd.AllowUserToAddRows = False
        Me.GVChannelsAdd.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GVChannelsAdd.ColumnHeadersHeight = 35
        Me.GVChannelsAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sno, Me.Configname, Me.PrimaryIPaddress, Me.PrimaryPortNo, Me.RedundantIPAddress, Me.SecondaryPortNo, Me.RefreshInterval})
        Me.GVChannelsAdd.Dock = System.Windows.Forms.DockStyle.Top
        Me.GVChannelsAdd.Location = New System.Drawing.Point(0, 0)
        Me.GVChannelsAdd.MultiSelect = False
        Me.GVChannelsAdd.Name = "GVChannelsAdd"
        Me.GVChannelsAdd.ReadOnly = True
        Me.GVChannelsAdd.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.GVChannelsAdd.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GVChannelsAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GVChannelsAdd.Size = New System.Drawing.Size(634, 252)
        Me.GVChannelsAdd.TabIndex = 10
        '
        'Sno
        '
        Me.Sno.HeaderText = "No"
        Me.Sno.Name = "Sno"
        Me.Sno.ReadOnly = True
        Me.Sno.Width = 47
        '
        'Configname
        '
        Me.Configname.HeaderText = "Name"
        Me.Configname.Name = "Configname"
        Me.Configname.ReadOnly = True
        '
        'PrimaryIPaddress
        '
        Me.PrimaryIPaddress.HeaderText = "Primary IP Address"
        Me.PrimaryIPaddress.Name = "PrimaryIPaddress"
        Me.PrimaryIPaddress.ReadOnly = True
        '
        'PrimaryPortNo
        '
        Me.PrimaryPortNo.HeaderText = "Primary Port No"
        Me.PrimaryPortNo.Name = "PrimaryPortNo"
        Me.PrimaryPortNo.ReadOnly = True
        '
        'RedundantIPAddress
        '
        Me.RedundantIPAddress.HeaderText = "Secondary IP Address"
        Me.RedundantIPAddress.Name = "RedundantIPAddress"
        Me.RedundantIPAddress.ReadOnly = True
        '
        'SecondaryPortNo
        '
        Me.SecondaryPortNo.HeaderText = "Secondary Port No"
        Me.SecondaryPortNo.Name = "SecondaryPortNo"
        Me.SecondaryPortNo.ReadOnly = True
        '
        'RefreshInterval
        '
        Me.RefreshInterval.HeaderText = "Refresh Interval"
        Me.RefreshInterval.Name = "RefreshInterval"
        Me.RefreshInterval.ReadOnly = True
        '
        'btnChnlEdit
        '
        Me.btnChnlEdit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChnlEdit.Location = New System.Drawing.Point(77, 258)
        Me.btnChnlEdit.Name = "btnChnlEdit"
        Me.btnChnlEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnChnlEdit.TabIndex = 14
        Me.btnChnlEdit.Text = "Edit"
        Me.btnChnlEdit.UseVisualStyleBackColor = True
        '
        'btnChnlApply
        '
        Me.btnChnlApply.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChnlApply.Location = New System.Drawing.Point(464, 258)
        Me.btnChnlApply.Name = "btnChnlApply"
        Me.btnChnlApply.Size = New System.Drawing.Size(70, 23)
        Me.btnChnlApply.TabIndex = 13
        Me.btnChnlApply.Text = "Save"
        Me.btnChnlApply.UseVisualStyleBackColor = True
        '
        'btnChnlDelete
        '
        Me.btnChnlDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChnlDelete.Location = New System.Drawing.Point(138, 258)
        Me.btnChnlDelete.Name = "btnChnlDelete"
        Me.btnChnlDelete.Size = New System.Drawing.Size(55, 23)
        Me.btnChnlDelete.TabIndex = 12
        Me.btnChnlDelete.Text = "Delete"
        Me.btnChnlDelete.UseVisualStyleBackColor = True
        '
        'btnChnlAdd
        '
        Me.btnChnlAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChnlAdd.Location = New System.Drawing.Point(16, 258)
        Me.btnChnlAdd.Name = "btnChnlAdd"
        Me.btnChnlAdd.Size = New System.Drawing.Size(55, 23)
        Me.btnChnlAdd.TabIndex = 11
        Me.btnChnlAdd.Text = "Add"
        Me.btnChnlAdd.UseVisualStyleBackColor = True
        '
        'OPCDA_Servers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 293)
        Me.Controls.Add(Me.btnChnlEdit)
        Me.Controls.Add(Me.btnChnlApply)
        Me.Controls.Add(Me.btnChnlDelete)
        Me.Controls.Add(Me.btnChnlAdd)
        Me.Controls.Add(Me.GVChannelsAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(650, 332)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 332)
        Me.Name = "OPCDA_Servers"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OPCDA_Servers"
        CType(Me.GVChannelsAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GVChannelsAdd As DataGridView
    Friend WithEvents btnChnlEdit As Button
    Friend WithEvents btnChnlApply As Button
    Friend WithEvents btnChnlDelete As Button
    Friend WithEvents btnChnlAdd As Button
    Friend WithEvents Sno As DataGridViewTextBoxColumn
    Friend WithEvents Configname As DataGridViewTextBoxColumn
    Friend WithEvents PrimaryIPaddress As DataGridViewTextBoxColumn
    Friend WithEvents PrimaryPortNo As DataGridViewTextBoxColumn
    Friend WithEvents RedundantIPAddress As DataGridViewTextBoxColumn
    Friend WithEvents SecondaryPortNo As DataGridViewTextBoxColumn
    Friend WithEvents RefreshInterval As DataGridViewTextBoxColumn
End Class
