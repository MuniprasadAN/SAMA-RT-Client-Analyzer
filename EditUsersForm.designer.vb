<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditUsersForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditUsersForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbxUsername = New System.Windows.Forms.TextBox()
        Me.txtbxpassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbxretypepwd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Btncancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.accesslistbox = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbequipment = New System.Windows.Forms.ComboBox()
        Me.cbunit = New System.Windows.Forms.ComboBox()
        Me.cbarea = New System.Windows.Forms.ComboBox()
        Me.cbplant = New System.Windows.Forms.ComboBox()
        Me.rbtnequipment = New System.Windows.Forms.RadioButton()
        Me.rbtnunit = New System.Windows.Forms.RadioButton()
        Me.rbtnarea = New System.Windows.Forms.RadioButton()
        Me.rbtnplant = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnsuperadmin = New System.Windows.Forms.RadioButton()
        Me.RBtnAdmin = New System.Windows.Forms.RadioButton()
        Me.RBtnPower = New System.Windows.Forms.RadioButton()
        Me.RBtnSimple = New System.Windows.Forms.RadioButton()
        Me.cmbScreenName = New System.Windows.Forms.ComboBox()
        Me.rtbScreenname = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UserName"
        '
        'txtbxUsername
        '
        Me.txtbxUsername.Location = New System.Drawing.Point(142, 19)
        Me.txtbxUsername.Name = "txtbxUsername"
        Me.txtbxUsername.Size = New System.Drawing.Size(126, 20)
        Me.txtbxUsername.TabIndex = 1
        '
        'txtbxpassword
        '
        Me.txtbxpassword.Location = New System.Drawing.Point(142, 55)
        Me.txtbxpassword.Name = "txtbxpassword"
        Me.txtbxpassword.Size = New System.Drawing.Size(126, 20)
        Me.txtbxpassword.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'txtbxretypepwd
        '
        Me.txtbxretypepwd.Location = New System.Drawing.Point(142, 94)
        Me.txtbxretypepwd.Name = "txtbxretypepwd"
        Me.txtbxretypepwd.Size = New System.Drawing.Size(126, 20)
        Me.txtbxretypepwd.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Retype Password"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(269, 381)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 25)
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Btncancel
        '
        Me.Btncancel.Location = New System.Drawing.Point(372, 381)
        Me.Btncancel.Name = "Btncancel"
        Me.Btncancel.Size = New System.Drawing.Size(75, 25)
        Me.Btncancel.TabIndex = 9
        Me.Btncancel.Text = "Cancel"
        Me.Btncancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 370)
        Me.Panel1.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtbScreenname)
        Me.GroupBox2.Controls.Add(Me.cmbScreenName)
        Me.GroupBox2.Controls.Add(Me.accesslistbox)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cbequipment)
        Me.GroupBox2.Controls.Add(Me.cbunit)
        Me.GroupBox2.Controls.Add(Me.cbarea)
        Me.GroupBox2.Controls.Add(Me.cbplant)
        Me.GroupBox2.Controls.Add(Me.rbtnequipment)
        Me.GroupBox2.Controls.Add(Me.rbtnunit)
        Me.GroupBox2.Controls.Add(Me.rbtnarea)
        Me.GroupBox2.Controls.Add(Me.rbtnplant)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(648, 207)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Access Level"
        '
        'accesslistbox
        '
        Me.accesslistbox.FormattingEnabled = True
        Me.accesslistbox.Location = New System.Drawing.Point(370, 45)
        Me.accesslistbox.Name = "accesslistbox"
        Me.accesslistbox.Size = New System.Drawing.Size(251, 134)
        Me.accesslistbox.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 43)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbequipment
        '
        Me.cbequipment.FormattingEnabled = True
        Me.cbequipment.Location = New System.Drawing.Point(142, 172)
        Me.cbequipment.Name = "cbequipment"
        Me.cbequipment.Size = New System.Drawing.Size(126, 21)
        Me.cbequipment.TabIndex = 15
        '
        'cbunit
        '
        Me.cbunit.FormattingEnabled = True
        Me.cbunit.Location = New System.Drawing.Point(142, 132)
        Me.cbunit.Name = "cbunit"
        Me.cbunit.Size = New System.Drawing.Size(126, 21)
        Me.cbunit.TabIndex = 14
        '
        'cbarea
        '
        Me.cbarea.FormattingEnabled = True
        Me.cbarea.Location = New System.Drawing.Point(142, 92)
        Me.cbarea.Name = "cbarea"
        Me.cbarea.Size = New System.Drawing.Size(126, 21)
        Me.cbarea.TabIndex = 13
        '
        'cbplant
        '
        Me.cbplant.FormattingEnabled = True
        Me.cbplant.Location = New System.Drawing.Point(142, 55)
        Me.cbplant.Name = "cbplant"
        Me.cbplant.Size = New System.Drawing.Size(126, 21)
        Me.cbplant.TabIndex = 12
        '
        'rbtnequipment
        '
        Me.rbtnequipment.AutoSize = True
        Me.rbtnequipment.Location = New System.Drawing.Point(48, 172)
        Me.rbtnequipment.Name = "rbtnequipment"
        Me.rbtnequipment.Size = New System.Drawing.Size(75, 17)
        Me.rbtnequipment.TabIndex = 3
        Me.rbtnequipment.TabStop = True
        Me.rbtnequipment.Text = "Equipment"
        Me.rbtnequipment.UseVisualStyleBackColor = True
        '
        'rbtnunit
        '
        Me.rbtnunit.AutoSize = True
        Me.rbtnunit.Location = New System.Drawing.Point(47, 133)
        Me.rbtnunit.Name = "rbtnunit"
        Me.rbtnunit.Size = New System.Drawing.Size(44, 17)
        Me.rbtnunit.TabIndex = 2
        Me.rbtnunit.TabStop = True
        Me.rbtnunit.Text = "Unit"
        Me.rbtnunit.UseVisualStyleBackColor = True
        '
        'rbtnarea
        '
        Me.rbtnarea.AutoSize = True
        Me.rbtnarea.Location = New System.Drawing.Point(47, 93)
        Me.rbtnarea.Name = "rbtnarea"
        Me.rbtnarea.Size = New System.Drawing.Size(47, 17)
        Me.rbtnarea.TabIndex = 1
        Me.rbtnarea.TabStop = True
        Me.rbtnarea.Text = "Area"
        Me.rbtnarea.UseVisualStyleBackColor = True
        '
        'rbtnplant
        '
        Me.rbtnplant.AutoSize = True
        Me.rbtnplant.Location = New System.Drawing.Point(47, 57)
        Me.rbtnplant.Name = "rbtnplant"
        Me.rbtnplant.Size = New System.Drawing.Size(49, 17)
        Me.rbtnplant.TabIndex = 0
        Me.rbtnplant.TabStop = True
        Me.rbtnplant.Text = "Plant"
        Me.rbtnplant.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtbxpassword)
        Me.GroupBox3.Controls.Add(Me.txtbxretypepwd)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtbxUsername)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(648, 127)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "User Details"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnsuperadmin)
        Me.GroupBox1.Controls.Add(Me.RBtnAdmin)
        Me.GroupBox1.Controls.Add(Me.RBtnPower)
        Me.GroupBox1.Controls.Add(Me.RBtnSimple)
        Me.GroupBox1.Location = New System.Drawing.Point(296, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 95)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Level"
        '
        'rbtnsuperadmin
        '
        Me.rbtnsuperadmin.AutoSize = True
        Me.rbtnsuperadmin.Location = New System.Drawing.Point(182, 54)
        Me.rbtnsuperadmin.Name = "rbtnsuperadmin"
        Me.rbtnsuperadmin.Size = New System.Drawing.Size(85, 17)
        Me.rbtnsuperadmin.TabIndex = 3
        Me.rbtnsuperadmin.TabStop = True
        Me.rbtnsuperadmin.Text = "Super Admin"
        Me.rbtnsuperadmin.UseVisualStyleBackColor = True
        '
        'RBtnAdmin
        '
        Me.RBtnAdmin.AutoSize = True
        Me.RBtnAdmin.Location = New System.Drawing.Point(182, 19)
        Me.RBtnAdmin.Name = "RBtnAdmin"
        Me.RBtnAdmin.Size = New System.Drawing.Size(54, 17)
        Me.RBtnAdmin.TabIndex = 2
        Me.RBtnAdmin.TabStop = True
        Me.RBtnAdmin.Text = "Admin"
        Me.RBtnAdmin.UseVisualStyleBackColor = True
        '
        'RBtnPower
        '
        Me.RBtnPower.AutoSize = True
        Me.RBtnPower.Location = New System.Drawing.Point(75, 54)
        Me.RBtnPower.Name = "RBtnPower"
        Me.RBtnPower.Size = New System.Drawing.Size(58, 17)
        Me.RBtnPower.TabIndex = 1
        Me.RBtnPower.TabStop = True
        Me.RBtnPower.Text = "Power "
        Me.RBtnPower.UseVisualStyleBackColor = True
        '
        'RBtnSimple
        '
        Me.RBtnSimple.AutoSize = True
        Me.RBtnSimple.Location = New System.Drawing.Point(74, 17)
        Me.RBtnSimple.Name = "RBtnSimple"
        Me.RBtnSimple.Size = New System.Drawing.Size(59, 17)
        Me.RBtnSimple.TabIndex = 0
        Me.RBtnSimple.TabStop = True
        Me.RBtnSimple.Text = "Simple "
        Me.RBtnSimple.UseVisualStyleBackColor = True
        '
        'cmbScreenName
        '
        Me.cmbScreenName.FormattingEnabled = True
        Me.cmbScreenName.Location = New System.Drawing.Point(142, 20)
        Me.cmbScreenName.Name = "cmbScreenName"
        Me.cmbScreenName.Size = New System.Drawing.Size(126, 21)
        Me.cmbScreenName.TabIndex = 19
        '
        'rtbScreenname
        '
        Me.rtbScreenname.AutoSize = True
        Me.rtbScreenname.Location = New System.Drawing.Point(48, 23)
        Me.rtbScreenname.Name = "rtbScreenname"
        Me.rtbScreenname.Size = New System.Drawing.Size(90, 17)
        Me.rtbScreenname.TabIndex = 20
        Me.rtbScreenname.TabStop = True
        Me.rtbScreenname.Text = "Screen Name"
        Me.rtbScreenname.UseVisualStyleBackColor = True
        '
        'EditUsersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 418)
        Me.Controls.Add(Me.Btncancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditUsersForm"
        Me.Text = "EditUsersForm"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbxUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtbxpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbxretypepwd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Btncancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents accesslistbox As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbequipment As System.Windows.Forms.ComboBox
    Friend WithEvents cbunit As System.Windows.Forms.ComboBox
    Friend WithEvents cbarea As System.Windows.Forms.ComboBox
    Friend WithEvents cbplant As System.Windows.Forms.ComboBox
    Friend WithEvents rbtnequipment As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnunit As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnarea As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnplant As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnsuperadmin As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnPower As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnSimple As System.Windows.Forms.RadioButton
    Friend WithEvents cmbScreenName As ComboBox
    Friend WithEvents rtbScreenname As RadioButton
End Class
