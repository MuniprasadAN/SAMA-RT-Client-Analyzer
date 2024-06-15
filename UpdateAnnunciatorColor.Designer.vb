<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateAnnunciatorColor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateAnnunciatorColor))
        Me.AlarmColorDialog = New System.Windows.Forms.ColorDialog()
        Me.btnSbmtProperties = New System.Windows.Forms.Button()
        Me.openFileAudible = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.AlarmSettings = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtforeColor = New System.Windows.Forms.TextBox()
        Me.lblsecs = New System.Windows.Forms.Label()
        Me.txtBackcolor = New System.Windows.Forms.TextBox()
        Me.cmbBoxBlinkSecs = New System.Windows.Forms.ComboBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.ChkboxBlink = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.AlarmSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSbmtProperties
        '
        Me.btnSbmtProperties.Location = New System.Drawing.Point(387, 285)
        Me.btnSbmtProperties.Name = "btnSbmtProperties"
        Me.btnSbmtProperties.Size = New System.Drawing.Size(63, 22)
        Me.btnSbmtProperties.TabIndex = 36
        Me.btnSbmtProperties.Text = "Submit"
        Me.btnSbmtProperties.UseVisualStyleBackColor = True
        '
        'openFileAudible
        '
        Me.openFileAudible.FileName = "openFileAudible"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.AlarmSettings)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(442, 271)
        Me.TabControl1.TabIndex = 41
        '
        'AlarmSettings
        '
        Me.AlarmSettings.Controls.Add(Me.GroupBox1)
        Me.AlarmSettings.Location = New System.Drawing.Point(4, 22)
        Me.AlarmSettings.Name = "AlarmSettings"
        Me.AlarmSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.AlarmSettings.Size = New System.Drawing.Size(434, 245)
        Me.AlarmSettings.TabIndex = 0
        Me.AlarmSettings.Text = "Alarm Settings"
        Me.AlarmSettings.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtforeColor)
        Me.GroupBox1.Controls.Add(Me.lblsecs)
        Me.GroupBox1.Controls.Add(Me.txtBackcolor)
        Me.GroupBox1.Controls.Add(Me.cmbBoxBlinkSecs)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.ChkboxBlink)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(421, 235)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Fore Color :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Back Color :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtHeight)
        Me.GroupBox2.Controls.Add(Me.txtWidth)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 100)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Window Size"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Height :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Width :"
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(103, 61)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(182, 20)
        Me.txtHeight.TabIndex = 16
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(103, 19)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(182, 20)
        Me.txtWidth.TabIndex = 15
        '
        'txtforeColor
        '
        Me.txtforeColor.Enabled = False
        Me.txtforeColor.Location = New System.Drawing.Point(132, 22)
        Me.txtforeColor.Name = "txtforeColor"
        Me.txtforeColor.Size = New System.Drawing.Size(180, 20)
        Me.txtforeColor.TabIndex = 43
        '
        'lblsecs
        '
        Me.lblsecs.AutoSize = True
        Me.lblsecs.Location = New System.Drawing.Point(125, 91)
        Me.lblsecs.Name = "lblsecs"
        Me.lblsecs.Size = New System.Drawing.Size(48, 13)
        Me.lblsecs.TabIndex = 49
        Me.lblsecs.Text = "Interval :"
        '
        'txtBackcolor
        '
        Me.txtBackcolor.Enabled = False
        Me.txtBackcolor.Location = New System.Drawing.Point(132, 55)
        Me.txtBackcolor.Name = "txtBackcolor"
        Me.txtBackcolor.Size = New System.Drawing.Size(180, 20)
        Me.txtBackcolor.TabIndex = 44
        '
        'cmbBoxBlinkSecs
        '
        Me.cmbBoxBlinkSecs.FormattingEnabled = True
        Me.cmbBoxBlinkSecs.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmbBoxBlinkSecs.Location = New System.Drawing.Point(190, 86)
        Me.cmbBoxBlinkSecs.Name = "cmbBoxBlinkSecs"
        Me.cmbBoxBlinkSecs.Size = New System.Drawing.Size(122, 21)
        Me.cmbBoxBlinkSecs.TabIndex = 48
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(318, 29)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(74, 13)
        Me.LinkLabel2.TabIndex = 45
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Set Fore Color"
        '
        'ChkboxBlink
        '
        Me.ChkboxBlink.AutoSize = True
        Me.ChkboxBlink.Location = New System.Drawing.Point(38, 90)
        Me.ChkboxBlink.Name = "ChkboxBlink"
        Me.ChkboxBlink.Size = New System.Drawing.Size(49, 17)
        Me.ChkboxBlink.TabIndex = 47
        Me.ChkboxBlink.Text = "Blink"
        Me.ChkboxBlink.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(318, 58)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(78, 13)
        Me.LinkLabel1.TabIndex = 46
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Set Back Color"
        '
        'UpdateAnnunciatorColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 311)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSbmtProperties)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(476, 350)
        Me.Name = "UpdateAnnunciatorColor"
        Me.Text = "UpdateAnnunciatorColor"
        Me.TabControl1.ResumeLayout(False)
        Me.AlarmSettings.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AlarmColorDialog As ColorDialog
    Friend WithEvents btnSbmtProperties As Button
    Friend WithEvents openFileAudible As OpenFileDialog
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents AlarmSettings As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents txtWidth As TextBox
    Friend WithEvents lblsecs As Label
    Friend WithEvents cmbBoxBlinkSecs As ComboBox
    Friend WithEvents ChkboxBlink As CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents txtBackcolor As TextBox
    Friend WithEvents txtforeColor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
