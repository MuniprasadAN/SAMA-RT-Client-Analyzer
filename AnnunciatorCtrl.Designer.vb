
Partial Class AnnunciatorCtrl
    Inherits System.Windows.Forms.FlowLayoutPanel

    '<System.Diagnostics.DebuggerNonUserCode()>
    'Public Sub New(ByVal container As System.ComponentModel.IContainer)
    '    MyClass.New()

    '    'Required for Windows.Forms Class Composition Designer support
    '    If (container IsNot Nothing) Then
    '        container.Add(Me)
    '    End If

    'End Sub

    '<System.Diagnostics.DebuggerNonUserCode()>
    'Public Sub New()
    '    MyBase.New()

    '    'This call is required by the Component Designer.
    '    InitializeComponent()

    'End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

End Class

'Inherits System.Windows.Forms.UserControl

''UserControl overrides dispose to clean up the component list.
'<System.Diagnostics.DebuggerNonUserCode()>
'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
'    Try
'        If disposing AndAlso components IsNot Nothing Then
'            components.Dispose()
'        End If
'    Finally
'        MyBase.Dispose(disposing)
'    End Try
'End Sub

''Required by the Windows Form Designer
'Private components As System.ComponentModel.IContainer

''NOTE: The following procedure is required by the Windows Form Designer
''It can be modified using the Windows Form Designer.  
''Do not modify it using the code editor.
'<System.Diagnostics.DebuggerStepThrough()>
'Private Sub InitializeComponent()
'    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
'    Me.SuspendLayout()
'    '
'    'FlowLayoutPanel1
'    '
'    Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'    Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
'    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
'    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
'    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(410, 377)
'    Me.FlowLayoutPanel1.TabIndex = 0
'    '
'    'Annunciator_Win_Control
'    '
'    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
'    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
'    Me.Controls.Add(Me.FlowLayoutPanel1)
'    Me.Name = "Annunciator_Win_Control"
'    Me.Size = New System.Drawing.Size(410, 377)
'    Me.ResumeLayout(False)

'End Sub

'Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
'End Class
