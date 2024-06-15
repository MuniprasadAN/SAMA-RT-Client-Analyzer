<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogCtrlProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogCtrlProperties))
        Me.grpBoxproperties = New System.Windows.Forms.GroupBox
        Me.lblExtension = New System.Windows.Forms.Label
        Me.cboxExtension = New System.Windows.Forms.ComboBox
        Me.lblnnHours = New System.Windows.Forms.Label
        Me.lblLogOption = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblDelimiter = New System.Windows.Forms.Label
        Me.txtdelimiter = New System.Windows.Forms.TextBox
        Me.nudnnhours = New System.Windows.Forms.NumericUpDown
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.cboxOption = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpBoxproperties.SuspendLayout()
        CType(Me.nudnnhours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBoxproperties
        '
        Me.grpBoxproperties.Controls.Add(Me.lblExtension)
        Me.grpBoxproperties.Controls.Add(Me.cboxExtension)
        Me.grpBoxproperties.Controls.Add(Me.lblnnHours)
        Me.grpBoxproperties.Controls.Add(Me.lblLogOption)
        Me.grpBoxproperties.Controls.Add(Me.lblPath)
        Me.grpBoxproperties.Controls.Add(Me.lblDelimiter)
        Me.grpBoxproperties.Controls.Add(Me.txtdelimiter)
        Me.grpBoxproperties.Controls.Add(Me.nudnnhours)
        Me.grpBoxproperties.Controls.Add(Me.btnBrowse)
        Me.grpBoxproperties.Controls.Add(Me.txtPath)
        Me.grpBoxproperties.Controls.Add(Me.cboxOption)
        Me.grpBoxproperties.Location = New System.Drawing.Point(5, 4)
        Me.grpBoxproperties.Name = "grpBoxproperties"
        Me.grpBoxproperties.Size = New System.Drawing.Size(590, 129)
        Me.grpBoxproperties.TabIndex = 0
        Me.grpBoxproperties.TabStop = False
        Me.grpBoxproperties.Text = "Properties"
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = True
        Me.lblExtension.Location = New System.Drawing.Point(25, 105)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(82, 13)
        Me.lblExtension.TabIndex = 12
        Me.lblExtension.Text = "* Extension :"
        '
        'cboxExtension
        '
        Me.cboxExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxExtension.FormattingEnabled = True
        Me.cboxExtension.Items.AddRange(New Object() {".txt", ".csv", ".xls", ".xlsx", ".html", ".xml"})
        Me.cboxExtension.Location = New System.Drawing.Point(117, 99)
        Me.cboxExtension.Name = "cboxExtension"
        Me.cboxExtension.Size = New System.Drawing.Size(88, 21)
        Me.cboxExtension.TabIndex = 11
        '
        'lblnnHours
        '
        Me.lblnnHours.AutoSize = True
        Me.lblnnHours.Location = New System.Drawing.Point(270, 37)
        Me.lblnnHours.Name = "lblnnHours"
        Me.lblnnHours.Size = New System.Drawing.Size(66, 13)
        Me.lblnnHours.TabIndex = 10
        Me.lblnnHours.Text = "nn hours :"
        '
        'lblLogOption
        '
        Me.lblLogOption.AutoSize = True
        Me.lblLogOption.Location = New System.Drawing.Point(25, 39)
        Me.lblLogOption.Name = "lblLogOption"
        Me.lblLogOption.Size = New System.Drawing.Size(88, 13)
        Me.lblLogOption.TabIndex = 9
        Me.lblLogOption.Text = "* Log Option :"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(25, 72)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(52, 13)
        Me.lblPath.TabIndex = 8
        Me.lblPath.Text = "* Path :"
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.Location = New System.Drawing.Point(256, 102)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(68, 13)
        Me.lblDelimiter.TabIndex = 6
        Me.lblDelimiter.Text = "Delimiter :"
        '
        'txtdelimiter
        '
        Me.txtdelimiter.Location = New System.Drawing.Point(339, 99)
        Me.txtdelimiter.MaxLength = 1
        Me.txtdelimiter.Name = "txtdelimiter"
        Me.txtdelimiter.Size = New System.Drawing.Size(44, 21)
        Me.txtdelimiter.TabIndex = 5
        '
        'nudnnhours
        '
        Me.nudnnhours.Location = New System.Drawing.Point(339, 33)
        Me.nudnnhours.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudnnhours.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudnnhours.Name = "nudnnhours"
        Me.nudnnhours.Size = New System.Drawing.Size(56, 21)
        Me.nudnnhours.TabIndex = 3
        Me.nudnnhours.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(504, 67)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(62, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(117, 67)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(381, 21)
        Me.txtPath.TabIndex = 1
        '
        'cboxOption
        '
        Me.cboxOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxOption.FormattingEnabled = True
        Me.cboxOption.Items.AddRange(New Object() {"View Recent File", "View nn hours File"})
        Me.cboxOption.Location = New System.Drawing.Point(117, 33)
        Me.cboxOption.Name = "cboxOption"
        Me.cboxOption.Size = New System.Drawing.Size(147, 21)
        Me.cboxOption.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(464, 138)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(62, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(533, 138)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(12, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "* Mandatory fields"
        '
        'LogCtrlProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 167)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpBoxproperties)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(680, 189)
        Me.Name = "LogCtrlProperties"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LogCtrlProperties"
        Me.grpBoxproperties.ResumeLayout(False)
        Me.grpBoxproperties.PerformLayout()
        CType(Me.nudnnhours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpBoxproperties As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents cboxOption As System.Windows.Forms.ComboBox
    Friend WithEvents txtdelimiter As System.Windows.Forms.TextBox
    Friend WithEvents nudnnhours As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblDelimiter As System.Windows.Forms.Label
    Friend WithEvents lblLogOption As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblnnHours As System.Windows.Forms.Label
    Friend WithEvents lblExtension As System.Windows.Forms.Label
    Friend WithEvents cboxExtension As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
