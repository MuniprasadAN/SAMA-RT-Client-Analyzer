<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCWriter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OPCWriter))
        Me.grpBoxOPCwriter = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtOPCValue = New System.Windows.Forms.TextBox
        Me.lblopcWritter = New System.Windows.Forms.Label
        Me.grpBoxOPCwriter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBoxOPCwriter
        '
        Me.grpBoxOPCwriter.Controls.Add(Me.btnCancel)
        Me.grpBoxOPCwriter.Controls.Add(Me.btnOK)
        Me.grpBoxOPCwriter.Controls.Add(Me.txtOPCValue)
        Me.grpBoxOPCwriter.Controls.Add(Me.lblopcWritter)
        Me.grpBoxOPCwriter.Location = New System.Drawing.Point(5, 4)
        Me.grpBoxOPCwriter.Name = "grpBoxOPCwriter"
        Me.grpBoxOPCwriter.Size = New System.Drawing.Size(586, 67)
        Me.grpBoxOPCwriter.TabIndex = 1
        Me.grpBoxOPCwriter.TabStop = False
        Me.grpBoxOPCwriter.Text = "Write OPC Values"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(512, 25)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(440, 25)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(65, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtOPCValue
        '
        Me.txtOPCValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOPCValue.Location = New System.Drawing.Point(84, 27)
        Me.txtOPCValue.Name = "txtOPCValue"
        Me.txtOPCValue.Size = New System.Drawing.Size(348, 21)
        Me.txtOPCValue.TabIndex = 4
        '
        'lblopcWritter
        '
        Me.lblopcWritter.AutoSize = True
        Me.lblopcWritter.Location = New System.Drawing.Point(8, 30)
        Me.lblopcWritter.Name = "lblopcWritter"
        Me.lblopcWritter.Size = New System.Drawing.Size(77, 13)
        Me.lblopcWritter.TabIndex = 3
        Me.lblopcWritter.Text = "OPC Value :"
        '
        'OPCWriter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 79)
        Me.Controls.Add(Me.grpBoxOPCwriter)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(602, 106)
        Me.Name = "OPCWriter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Write OPC Values"
        Me.grpBoxOPCwriter.ResumeLayout(False)
        Me.grpBoxOPCwriter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBoxOPCwriter As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtOPCValue As System.Windows.Forms.TextBox
    Friend WithEvents lblopcWritter As System.Windows.Forms.Label
End Class
