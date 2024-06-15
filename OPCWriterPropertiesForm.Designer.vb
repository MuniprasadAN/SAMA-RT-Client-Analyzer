<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OPCWriterPropertiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OPCWriterPropertiesForm))
        Me.lblTitleFont = New System.Windows.Forms.Label()
        Me.txtTitleFont = New System.Windows.Forms.TextBox()
        Me.btnTitleFont = New System.Windows.Forms.Button()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.CBoxStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.forecolorlbl = New System.Windows.Forms.Label()
        Me.lblForecolor = New System.Windows.Forms.Label()
        Me.BackColorlbl = New System.Windows.Forms.Label()
        Me.GrpMaxMinValues = New System.Windows.Forms.GroupBox()
        Me.lblBKcolor = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CBoxActionChannel = New System.Windows.Forms.ComboBox()
        Me.lblActionChannel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtboxopcvalue = New System.Windows.Forms.TextBox()
        Me.GrpMaxMinValues.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitleFont
        '
        Me.lblTitleFont.AutoSize = True
        Me.lblTitleFont.Location = New System.Drawing.Point(19, 47)
        Me.lblTitleFont.Name = "lblTitleFont"
        Me.lblTitleFont.Size = New System.Drawing.Size(34, 13)
        Me.lblTitleFont.TabIndex = 113
        Me.lblTitleFont.Text = "Font :"
        '
        'txtTitleFont
        '
        Me.txtTitleFont.Location = New System.Drawing.Point(100, 43)
        Me.txtTitleFont.Name = "txtTitleFont"
        Me.txtTitleFont.ReadOnly = True
        Me.txtTitleFont.Size = New System.Drawing.Size(288, 20)
        Me.txtTitleFont.TabIndex = 112
        '
        'btnTitleFont
        '
        Me.btnTitleFont.Location = New System.Drawing.Point(394, 42)
        Me.btnTitleFont.Name = "btnTitleFont"
        Me.btnTitleFont.Size = New System.Drawing.Size(49, 21)
        Me.btnTitleFont.TabIndex = 111
        Me.btnTitleFont.Text = "Font..."
        Me.btnTitleFont.UseVisualStyleBackColor = True
        '
        'txtText
        '
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtText.Location = New System.Drawing.Point(100, 16)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(154, 20)
        Me.txtText.TabIndex = 109
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(18, 24)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(34, 13)
        Me.lblCaption.TabIndex = 110
        Me.lblCaption.Text = "Text :"
        '
        'CBoxStyle
        '
        Me.CBoxStyle.FormattingEnabled = True
        Me.CBoxStyle.Items.AddRange(New Object() {"Flat", "Popup", "Standard"})
        Me.CBoxStyle.Location = New System.Drawing.Point(101, 98)
        Me.CBoxStyle.Name = "CBoxStyle"
        Me.CBoxStyle.Size = New System.Drawing.Size(121, 21)
        Me.CBoxStyle.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Style :"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(527, 259)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(67, 21)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(452, 259)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(68, 21)
        Me.btnOK.TabIndex = 25
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'forecolorlbl
        '
        Me.forecolorlbl.BackColor = System.Drawing.Color.Black
        Me.forecolorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.forecolorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.forecolorlbl.Location = New System.Drawing.Point(260, 73)
        Me.forecolorlbl.Name = "forecolorlbl"
        Me.forecolorlbl.Size = New System.Drawing.Size(63, 17)
        Me.forecolorlbl.TabIndex = 27
        '
        'lblForecolor
        '
        Me.lblForecolor.AutoSize = True
        Me.lblForecolor.Location = New System.Drawing.Point(185, 75)
        Me.lblForecolor.Name = "lblForecolor"
        Me.lblForecolor.Size = New System.Drawing.Size(60, 13)
        Me.lblForecolor.TabIndex = 26
        Me.lblForecolor.Text = "Fore color :"
        '
        'BackColorlbl
        '
        Me.BackColorlbl.BackColor = System.Drawing.SystemColors.Control
        Me.BackColorlbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BackColorlbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BackColorlbl.Location = New System.Drawing.Point(101, 73)
        Me.BackColorlbl.Name = "BackColorlbl"
        Me.BackColorlbl.Size = New System.Drawing.Size(63, 17)
        Me.BackColorlbl.TabIndex = 25
        '
        'GrpMaxMinValues
        '
        Me.GrpMaxMinValues.Controls.Add(Me.lblTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.txtTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.btnTitleFont)
        Me.GrpMaxMinValues.Controls.Add(Me.txtText)
        Me.GrpMaxMinValues.Controls.Add(Me.lblCaption)
        Me.GrpMaxMinValues.Controls.Add(Me.CBoxStyle)
        Me.GrpMaxMinValues.Controls.Add(Me.Label1)
        Me.GrpMaxMinValues.Controls.Add(Me.forecolorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblForecolor)
        Me.GrpMaxMinValues.Controls.Add(Me.BackColorlbl)
        Me.GrpMaxMinValues.Controls.Add(Me.lblBKcolor)
        Me.GrpMaxMinValues.Location = New System.Drawing.Point(11, 110)
        Me.GrpMaxMinValues.Name = "GrpMaxMinValues"
        Me.GrpMaxMinValues.Size = New System.Drawing.Size(565, 125)
        Me.GrpMaxMinValues.TabIndex = 55
        Me.GrpMaxMinValues.TabStop = False
        Me.GrpMaxMinValues.Text = "Color Settings"
        '
        'lblBKcolor
        '
        Me.lblBKcolor.AutoSize = True
        Me.lblBKcolor.Location = New System.Drawing.Point(18, 74)
        Me.lblBKcolor.Name = "lblBKcolor"
        Me.lblBKcolor.Size = New System.Drawing.Size(64, 13)
        Me.lblBKcolor.TabIndex = 24
        Me.lblBKcolor.Text = "Back color :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtboxopcvalue)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CBoxActionChannel)
        Me.GroupBox1.Controls.Add(Me.lblActionChannel)
        Me.GroupBox1.Controls.Add(Me.GrpMaxMinValues)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 241)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'CBoxActionChannel
        '
        Me.CBoxActionChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBoxActionChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBoxActionChannel.DropDownHeight = 80
        Me.CBoxActionChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxActionChannel.FormattingEnabled = True
        Me.CBoxActionChannel.IntegralHeight = False
        Me.CBoxActionChannel.ItemHeight = 13
        Me.CBoxActionChannel.Location = New System.Drawing.Point(139, 28)
        Me.CBoxActionChannel.Name = "CBoxActionChannel"
        Me.CBoxActionChannel.Size = New System.Drawing.Size(305, 21)
        Me.CBoxActionChannel.TabIndex = 57
        '
        'lblActionChannel
        '
        Me.lblActionChannel.AutoSize = True
        Me.lblActionChannel.Location = New System.Drawing.Point(31, 32)
        Me.lblActionChannel.Name = "lblActionChannel"
        Me.lblActionChannel.Size = New System.Drawing.Size(85, 13)
        Me.lblActionChannel.TabIndex = 56
        Me.lblActionChannel.Text = "Action Channel :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Value to be Write:"
        '
        'txtboxopcvalue
        '
        Me.txtboxopcvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtboxopcvalue.Location = New System.Drawing.Point(139, 70)
        Me.txtboxopcvalue.Name = "txtboxopcvalue"
        Me.txtboxopcvalue.Size = New System.Drawing.Size(154, 20)
        Me.txtboxopcvalue.TabIndex = 110
        '
        'OPCWriterPropertiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 292)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OPCWriterPropertiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OPCWriterPropertiesForm"
        Me.GrpMaxMinValues.ResumeLayout(False)
        Me.GrpMaxMinValues.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitleFont As Label
    Friend WithEvents txtTitleFont As TextBox
    Friend WithEvents btnTitleFont As Button
    Friend WithEvents txtText As TextBox
    Friend WithEvents lblCaption As Label
    Friend WithEvents CBoxStyle As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents forecolorlbl As Label
    Friend WithEvents lblForecolor As Label
    Friend WithEvents BackColorlbl As Label
    Friend WithEvents GrpMaxMinValues As GroupBox
    Friend WithEvents lblBKcolor As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CBoxActionChannel As ComboBox
    Friend WithEvents lblActionChannel As Label
    Friend WithEvents txtboxopcvalue As TextBox
    Friend WithEvents Label2 As Label
End Class
