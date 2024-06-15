<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddOpcItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddOpcItems))
        Me.trvwOPCGroups = New System.Windows.Forms.TreeView
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpBoxOPCInfo = New System.Windows.Forms.GroupBox
        Me.lblSltOPCitem = New System.Windows.Forms.RichTextBox
        Me.lblOPCitem = New System.Windows.Forms.Label
        Me.cboxMultiview = New System.Windows.Forms.CheckBox
        Me.grpBoxOPCInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'trvwOPCGroups
        '
        Me.trvwOPCGroups.Location = New System.Drawing.Point(6, 2)
        Me.trvwOPCGroups.Name = "trvwOPCGroups"
        Me.trvwOPCGroups.PathSeparator = "."
        Me.trvwOPCGroups.Size = New System.Drawing.Size(328, 330)
        Me.trvwOPCGroups.TabIndex = 9
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(170, 481)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(252, 481)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpBoxOPCInfo
        '
        Me.grpBoxOPCInfo.Controls.Add(Me.lblSltOPCitem)
        Me.grpBoxOPCInfo.Controls.Add(Me.lblOPCitem)
        Me.grpBoxOPCInfo.Location = New System.Drawing.Point(6, 360)
        Me.grpBoxOPCInfo.Name = "grpBoxOPCInfo"
        Me.grpBoxOPCInfo.Size = New System.Drawing.Size(325, 110)
        Me.grpBoxOPCInfo.TabIndex = 20
        Me.grpBoxOPCInfo.TabStop = False
        Me.grpBoxOPCInfo.Text = "OPC Info"
        '
        'lblSltOPCitem
        '
        Me.lblSltOPCitem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSltOPCitem.ForeColor = System.Drawing.Color.Maroon
        Me.lblSltOPCitem.Location = New System.Drawing.Point(8, 33)
        Me.lblSltOPCitem.Name = "lblSltOPCitem"
        Me.lblSltOPCitem.ReadOnly = True
        Me.lblSltOPCitem.Size = New System.Drawing.Size(310, 66)
        Me.lblSltOPCitem.TabIndex = 15
        Me.lblSltOPCitem.Text = ""
        '
        'lblOPCitem
        '
        Me.lblOPCitem.AutoSize = True
        Me.lblOPCitem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOPCitem.Location = New System.Drawing.Point(1, 13)
        Me.lblOPCitem.Name = "lblOPCitem"
        Me.lblOPCitem.Size = New System.Drawing.Size(116, 13)
        Me.lblOPCitem.TabIndex = 14
        Me.lblOPCitem.Text = "Selected OPC Item"
        '
        'cboxMultiview
        '
        Me.cboxMultiview.AutoSize = True
        Me.cboxMultiview.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboxMultiview.Location = New System.Drawing.Point(230, 340)
        Me.cboxMultiview.Name = "cboxMultiview"
        Me.cboxMultiview.Size = New System.Drawing.Size(83, 17)
        Me.cboxMultiview.TabIndex = 21
        Me.cboxMultiview.Text = "Multi Tags"
        Me.cboxMultiview.UseVisualStyleBackColor = True
        '
        'AddOpcItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 508)
        Me.Controls.Add(Me.cboxMultiview)
        Me.Controls.Add(Me.grpBoxOPCInfo)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.trvwOPCGroups)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddOpcItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add_OPCItems"
        Me.grpBoxOPCInfo.ResumeLayout(False)
        Me.grpBoxOPCInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trvwOPCGroups As System.Windows.Forms.TreeView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpBoxOPCInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblOPCitem As System.Windows.Forms.Label
    Friend WithEvents cboxMultiview As System.Windows.Forms.CheckBox
    Friend WithEvents lblSltOPCitem As System.Windows.Forms.RichTextBox
End Class
