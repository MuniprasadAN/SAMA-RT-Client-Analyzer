<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddOPC
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtbxPortnumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtbxHostname = New System.Windows.Forms.TextBox()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.txtbxconfigname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBxredundancy = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbxredundantportno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbxredundantipaddr = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblmillisecs = New System.Windows.Forms.Label()
        Me.lblrefreshinterval = New System.Windows.Forms.Label()
        Me.txtbx_refreshinterval = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "IP Address"
        '
        'TxtbxPortnumber
        '
        Me.TxtbxPortnumber.Location = New System.Drawing.Point(148, 96)
        Me.TxtbxPortnumber.Name = "TxtbxPortnumber"
        Me.TxtbxPortnumber.Size = New System.Drawing.Size(86, 20)
        Me.TxtbxPortnumber.TabIndex = 3
        Me.TxtbxPortnumber.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Port Number"
        '
        'TxtbxHostname
        '
        Me.TxtbxHostname.Location = New System.Drawing.Point(148, 56)
        Me.TxtbxHostname.Name = "TxtbxHostname"
        Me.TxtbxHostname.Size = New System.Drawing.Size(233, 20)
        Me.TxtbxHostname.TabIndex = 2
        Me.TxtbxHostname.Text = "127.0.0.1"
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(248, 306)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 23)
        Me.btnadd.TabIndex = 8
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(339, 306)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 9
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'txtbxconfigname
        '
        Me.txtbxconfigname.Location = New System.Drawing.Point(148, 17)
        Me.txtbxconfigname.Name = "txtbxconfigname"
        Me.txtbxconfigname.Size = New System.Drawing.Size(233, 20)
        Me.txtbxconfigname.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Config Name"
        '
        'CBxredundancy
        '
        Me.CBxredundancy.AutoSize = True
        Me.CBxredundancy.Location = New System.Drawing.Point(294, 99)
        Me.CBxredundancy.Name = "CBxredundancy"
        Me.CBxredundancy.Size = New System.Drawing.Size(87, 17)
        Me.CBxredundancy.TabIndex = 4
        Me.CBxredundancy.Text = "Redundancy"
        Me.CBxredundancy.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = " IP Address"
        '
        'txtbxredundantportno
        '
        Me.txtbxredundantportno.Location = New System.Drawing.Point(128, 68)
        Me.txtbxredundantportno.Name = "txtbxredundantportno"
        Me.txtbxredundantportno.Size = New System.Drawing.Size(86, 20)
        Me.txtbxredundantportno.TabIndex = 6
        Me.txtbxredundantportno.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Port Number"
        '
        'txtbxredundantipaddr
        '
        Me.txtbxredundantipaddr.Location = New System.Drawing.Point(128, 28)
        Me.txtbxredundantipaddr.Name = "txtbxredundantipaddr"
        Me.txtbxredundantipaddr.Size = New System.Drawing.Size(222, 20)
        Me.txtbxredundantipaddr.TabIndex = 5
        Me.txtbxredundantipaddr.Text = "127.0.0.1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtbxredundantipaddr)
        Me.GroupBox1.Controls.Add(Me.txtbxredundantportno)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 181)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 100)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Redundant OPC"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblmillisecs)
        Me.Panel1.Controls.Add(Me.lblrefreshinterval)
        Me.Panel1.Controls.Add(Me.txtbx_refreshinterval)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CBxredundancy)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtbxconfigname)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtbxHostname)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtbxPortnumber)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 288)
        Me.Panel1.TabIndex = 41
        '
        'lblmillisecs
        '
        Me.lblmillisecs.AutoSize = True
        Me.lblmillisecs.Location = New System.Drawing.Point(240, 142)
        Me.lblmillisecs.Name = "lblmillisecs"
        Me.lblmillisecs.Size = New System.Drawing.Size(69, 13)
        Me.lblmillisecs.TabIndex = 44
        Me.lblmillisecs.Text = "Milli Seconds"
        '
        'lblrefreshinterval
        '
        Me.lblrefreshinterval.AutoSize = True
        Me.lblrefreshinterval.Location = New System.Drawing.Point(17, 143)
        Me.lblrefreshinterval.Name = "lblrefreshinterval"
        Me.lblrefreshinterval.Size = New System.Drawing.Size(82, 13)
        Me.lblrefreshinterval.TabIndex = 43
        Me.lblrefreshinterval.Text = "Refresh Interval"
        '
        'txtbx_refreshinterval
        '
        Me.txtbx_refreshinterval.Location = New System.Drawing.Point(148, 139)
        Me.txtbx_refreshinterval.Name = "txtbx_refreshinterval"
        Me.txtbx_refreshinterval.Size = New System.Drawing.Size(86, 20)
        Me.txtbx_refreshinterval.TabIndex = 42
        Me.txtbx_refreshinterval.Text = "1000"
        '
        'AddOPC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 341)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(448, 380)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(448, 380)
        Me.Name = "AddOPC"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit OPCDA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents TxtbxPortnumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtbxHostname As TextBox
    Friend WithEvents btnadd As Button
    Friend WithEvents btncancel As Button
    Friend WithEvents txtbxconfigname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBxredundancy As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtbxredundantportno As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtbxredundantipaddr As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblmillisecs As Label
    Friend WithEvents lblrefreshinterval As Label
    Friend WithEvents txtbx_refreshinterval As TextBox
End Class
