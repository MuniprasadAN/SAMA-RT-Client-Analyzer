''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcServerlistForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpcServerlistForm))
        Me.TreevueOPCServerList = New System.Windows.Forms.TreeView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.grpBoxOPCInfo = New System.Windows.Forms.GroupBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lblSltOPCitem = New System.Windows.Forms.RichTextBox()
        Me.lblOPCitem = New System.Windows.Forms.Label()
        Me.lblSltOPCserver = New System.Windows.Forms.Label()
        Me.lblOPCserver = New System.Windows.Forms.Label()
        Me.btnBrowseOPCItem = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddConnectServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpBoxOPCInfo.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreevueOPCServerList
        '
        Me.TreevueOPCServerList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreevueOPCServerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreevueOPCServerList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreevueOPCServerList.ItemHeight = 20
        Me.TreevueOPCServerList.Location = New System.Drawing.Point(14, 12)
        Me.TreevueOPCServerList.Name = "TreevueOPCServerList"
        Me.TreevueOPCServerList.Size = New System.Drawing.Size(330, 237)
        Me.TreevueOPCServerList.TabIndex = 7
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(206, 431)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 21)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(276, 431)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 21)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "computer-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Computer-Network-icon.png")
        '
        'grpBoxOPCInfo
        '
        Me.grpBoxOPCInfo.Controls.Add(Me.btnConnect)
        Me.grpBoxOPCInfo.Controls.Add(Me.lblSltOPCitem)
        Me.grpBoxOPCInfo.Controls.Add(Me.lblOPCitem)
        Me.grpBoxOPCInfo.Controls.Add(Me.lblSltOPCserver)
        Me.grpBoxOPCInfo.Controls.Add(Me.lblOPCserver)
        Me.grpBoxOPCInfo.Location = New System.Drawing.Point(14, 259)
        Me.grpBoxOPCInfo.Name = "grpBoxOPCInfo"
        Me.grpBoxOPCInfo.Size = New System.Drawing.Size(330, 166)
        Me.grpBoxOPCInfo.TabIndex = 14
        Me.grpBoxOPCInfo.TabStop = False
        Me.grpBoxOPCInfo.Text = "OPC Info"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(236, 64)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(80, 21)
        Me.btnConnect.TabIndex = 16
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lblSltOPCitem
        '
        Me.lblSltOPCitem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSltOPCitem.ForeColor = System.Drawing.Color.Maroon
        Me.lblSltOPCitem.Location = New System.Drawing.Point(9, 96)
        Me.lblSltOPCitem.Name = "lblSltOPCitem"
        Me.lblSltOPCitem.ReadOnly = True
        Me.lblSltOPCitem.Size = New System.Drawing.Size(311, 64)
        Me.lblSltOPCitem.TabIndex = 15
        Me.lblSltOPCitem.Text = ""
        '
        'lblOPCitem
        '
        Me.lblOPCitem.AutoSize = True
        Me.lblOPCitem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOPCitem.Location = New System.Drawing.Point(5, 78)
        Me.lblOPCitem.Name = "lblOPCitem"
        Me.lblOPCitem.Size = New System.Drawing.Size(116, 13)
        Me.lblOPCitem.TabIndex = 14
        Me.lblOPCitem.Text = "Selected OPC Item"
        '
        'lblSltOPCserver
        '
        Me.lblSltOPCserver.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSltOPCserver.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSltOPCserver.ForeColor = System.Drawing.Color.Maroon
        Me.lblSltOPCserver.Location = New System.Drawing.Point(9, 38)
        Me.lblSltOPCserver.Name = "lblSltOPCserver"
        Me.lblSltOPCserver.Size = New System.Drawing.Size(311, 21)
        Me.lblSltOPCserver.TabIndex = 13
        Me.lblSltOPCserver.Text = "    "
        '
        'lblOPCserver
        '
        Me.lblOPCserver.AutoSize = True
        Me.lblOPCserver.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOPCserver.Location = New System.Drawing.Point(5, 18)
        Me.lblOPCserver.Name = "lblOPCserver"
        Me.lblOPCserver.Size = New System.Drawing.Size(128, 13)
        Me.lblOPCserver.TabIndex = 12
        Me.lblOPCserver.Text = "Selected OPC Server"
        '
        'btnBrowseOPCItem
        '
        Me.btnBrowseOPCItem.Location = New System.Drawing.Point(14, 432)
        Me.btnBrowseOPCItem.Name = "btnBrowseOPCItem"
        Me.btnBrowseOPCItem.Size = New System.Drawing.Size(123, 21)
        Me.btnBrowseOPCItem.TabIndex = 15
        Me.btnBrowseOPCItem.Text = "Browse OPC Items"
        Me.btnBrowseOPCItem.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddConnectServerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 48)
        '
        'AddConnectServerToolStripMenuItem
        '
        Me.AddConnectServerToolStripMenuItem.Name = "AddConnectServerToolStripMenuItem"
        Me.AddConnectServerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.AddConnectServerToolStripMenuItem.Text = "Add/Connect Server"
        '
        'OpcServerlistForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 465)
        Me.Controls.Add(Me.btnBrowseOPCItem)
        Me.Controls.Add(Me.grpBoxOPCInfo)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TreevueOPCServerList)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OpcServerlistForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OPC Servers List"
        Me.grpBoxOPCInfo.ResumeLayout(False)
        Me.grpBoxOPCInfo.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreevueOPCServerList As System.Windows.Forms.TreeView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents grpBoxOPCInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblOPCitem As System.Windows.Forms.Label
    Friend WithEvents lblSltOPCserver As System.Windows.Forms.Label
    Friend WithEvents lblOPCserver As System.Windows.Forms.Label
    Friend WithEvents btnBrowseOPCItem As System.Windows.Forms.Button
    Friend WithEvents lblSltOPCitem As System.Windows.Forms.RichTextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddConnectServerToolStripMenuItem As ToolStripMenuItem
End Class
