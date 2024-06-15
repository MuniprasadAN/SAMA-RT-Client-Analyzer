''' <summary>
''' 	
''' </summary>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DBQueryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBQueryForm))
        Me.GrpBoxSelect = New System.Windows.Forms.GroupBox()
        Me.ckBoxbuild_Fun = New System.Windows.Forms.CheckBox()
        Me.cboxBuildFunction = New System.Windows.Forms.ComboBox()
        Me.CKlstBox__Fields = New System.Windows.Forms.CheckedListBox()
        Me.txtBoxnnDays = New System.Windows.Forms.TextBox()
        Me.rdobtnnnRec = New System.Windows.Forms.RadioButton()
        Me.rdobtnnnDays = New System.Windows.Forms.RadioButton()
        Me.txtBoxnnRec = New System.Windows.Forms.TextBox()
        Me.grpBoxWhere = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.rtBoxCondition = New System.Windows.Forms.RichTextBox()
        Me.lblAND = New System.Windows.Forms.Label()
        Me.btnWhereAdd = New System.Windows.Forms.Button()
        Me.CBoxFields = New System.Windows.Forms.ComboBox()
        Me.cboxValue = New System.Windows.Forms.ComboBox()
        Me.cboxCondition = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpBoxFunction = New System.Windows.Forms.GroupBox()
        Me.lblof = New System.Windows.Forms.Label()
        Me.cboxFunField = New System.Windows.Forms.ComboBox()
        Me.cboxFunction = New System.Windows.Forms.ComboBox()
        Me.grpboxType = New System.Windows.Forms.GroupBox()
        Me.rdobtnAnnunciator = New System.Windows.Forms.RadioButton()
        Me.rdobtnTrend = New System.Windows.Forms.RadioButton()
        Me.rdobtnValue = New System.Windows.Forms.RadioButton()
        Me.rdobtnDisplay = New System.Windows.Forms.RadioButton()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.GrpBoxAnnunciator = New System.Windows.Forms.GroupBox()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.btnMoveUpValue = New System.Windows.Forms.Button()
        Me.BtnAdd_TagParameter = New System.Windows.Forms.Button()
        Me.cBoxParameterField = New System.Windows.Forms.ComboBox()
        Me.cBoxTagNoField = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LstBoxSelectValue = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBoxAnnunValue = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CBoxAnnunFields = New System.Windows.Forms.ComboBox()
        Me.txtAlaiseName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkTagParView = New System.Windows.Forms.CheckBox()
        Me.chkAliasNameView = New System.Windows.Forms.CheckBox()
        Me.GrpBoxSelect.SuspendLayout()
        Me.grpBoxWhere.SuspendLayout()
        Me.grpBoxFunction.SuspendLayout()
        Me.grpboxType.SuspendLayout()
        Me.GrpBoxAnnunciator.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxSelect
        '
        Me.GrpBoxSelect.Controls.Add(Me.ckBoxbuild_Fun)
        Me.GrpBoxSelect.Controls.Add(Me.cboxBuildFunction)
        Me.GrpBoxSelect.Controls.Add(Me.CKlstBox__Fields)
        Me.GrpBoxSelect.Location = New System.Drawing.Point(10, 74)
        Me.GrpBoxSelect.Name = "GrpBoxSelect"
        Me.GrpBoxSelect.Size = New System.Drawing.Size(633, 126)
        Me.GrpBoxSelect.TabIndex = 0
        Me.GrpBoxSelect.TabStop = False
        Me.GrpBoxSelect.Text = "Select Display Fields"
        '
        'ckBoxbuild_Fun
        '
        Me.ckBoxbuild_Fun.AutoSize = True
        Me.ckBoxbuild_Fun.Location = New System.Drawing.Point(15, 107)
        Me.ckBoxbuild_Fun.Name = "ckBoxbuild_Fun"
        Me.ckBoxbuild_Fun.Size = New System.Drawing.Size(169, 17)
        Me.ckBoxbuild_Fun.TabIndex = 15
        Me.ckBoxbuild_Fun.Text = "Select Build In Function :"
        Me.ckBoxbuild_Fun.UseVisualStyleBackColor = True
        '
        'cboxBuildFunction
        '
        Me.cboxBuildFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxBuildFunction.FormattingEnabled = True
        Me.cboxBuildFunction.Items.AddRange(New Object() {"RealTime", "StaleAlarms", "StandingAlarmDuration", "UnAcknowledgedAlarms", "TimeToAcknowledge", "ReturnBeforeAck", "AlarmType --> Misc Alarms", "AlarmType --> Absolute", "AlarmType --> Safety", "AlarmType --> Diagnostic", "AlarmType --> Statistical", "AlarmType --> Calculated", "AlarmType --> ReAlarm", "AlarmType --> BadPVorOP", "AlarmType --> ROC", "AlarmType --> Deviation", "AlarmType --> System", "OperatorAction -->Misc OA", "OperatorAction -->ModeChange", "OperatorAction -->SPorOPChange", "OperatorAction -->On/Off", "OperatorAction -->Start/Stop", "OperatorAction -->AlarmShelving&Release", "OperatorAction -->StateChange", "AlarmStatus -->Active", "AlarmStatus -->Shelved", "AlarmStatus -->SuppressedByDesign", "AlarmStatus -->Released", "ConfigurationChange", "Others", "Priority Distribution"})
        Me.cboxBuildFunction.Location = New System.Drawing.Point(190, 105)
        Me.cboxBuildFunction.Name = "cboxBuildFunction"
        Me.cboxBuildFunction.Size = New System.Drawing.Size(264, 21)
        Me.cboxBuildFunction.TabIndex = 14
        '
        'CKlstBox__Fields
        '
        Me.CKlstBox__Fields.CheckOnClick = True
        Me.CKlstBox__Fields.ColumnWidth = 150
        Me.CKlstBox__Fields.FormattingEnabled = True
        Me.CKlstBox__Fields.Items.AddRange(New Object() {"SupraCurrTime_", "StartTime", "TagNo", "Parameter", "AlarmIdentifier", "Priority", "MessageDescription", "Channel", "Unit", "Area", "Plant", "UserField1", "UserField2", "UserField3", "UserField4", "UserField5"})
        Me.CKlstBox__Fields.Location = New System.Drawing.Point(15, 15)
        Me.CKlstBox__Fields.MultiColumn = True
        Me.CKlstBox__Fields.Name = "CKlstBox__Fields"
        Me.CKlstBox__Fields.Size = New System.Drawing.Size(605, 84)
        Me.CKlstBox__Fields.TabIndex = 8
        Me.CKlstBox__Fields.UseCompatibleTextRendering = True
        '
        'txtBoxnnDays
        '
        Me.txtBoxnnDays.Location = New System.Drawing.Point(144, 16)
        Me.txtBoxnnDays.Name = "txtBoxnnDays"
        Me.txtBoxnnDays.Size = New System.Drawing.Size(43, 21)
        Me.txtBoxnnDays.TabIndex = 12
        Me.txtBoxnnDays.Text = "1"
        '
        'rdobtnnnRec
        '
        Me.rdobtnnnRec.AutoSize = True
        Me.rdobtnnnRec.Location = New System.Drawing.Point(200, 18)
        Me.rdobtnnnRec.Name = "rdobtnnnRec"
        Me.rdobtnnnRec.Size = New System.Drawing.Size(125, 17)
        Me.rdobtnnnRec.TabIndex = 0
        Me.rdobtnnnRec.Text = "Last nn Records :"
        Me.rdobtnnnRec.UseVisualStyleBackColor = True
        '
        'rdobtnnnDays
        '
        Me.rdobtnnnDays.AutoSize = True
        Me.rdobtnnnDays.Location = New System.Drawing.Point(28, 17)
        Me.rdobtnnnDays.Name = "rdobtnnnDays"
        Me.rdobtnnnDays.Size = New System.Drawing.Size(108, 17)
        Me.rdobtnnnDays.TabIndex = 11
        Me.rdobtnnnDays.Text = "Last nn Days :"
        Me.rdobtnnnDays.UseVisualStyleBackColor = True
        '
        'txtBoxnnRec
        '
        Me.txtBoxnnRec.Location = New System.Drawing.Point(330, 16)
        Me.txtBoxnnRec.Name = "txtBoxnnRec"
        Me.txtBoxnnRec.Size = New System.Drawing.Size(43, 21)
        Me.txtBoxnnRec.TabIndex = 7
        Me.txtBoxnnRec.Text = "25"
        '
        'grpBoxWhere
        '
        Me.grpBoxWhere.Controls.Add(Me.btnClear)
        Me.grpBoxWhere.Controls.Add(Me.rtBoxCondition)
        Me.grpBoxWhere.Controls.Add(Me.txtBoxnnDays)
        Me.grpBoxWhere.Controls.Add(Me.lblAND)
        Me.grpBoxWhere.Controls.Add(Me.btnWhereAdd)
        Me.grpBoxWhere.Controls.Add(Me.rdobtnnnRec)
        Me.grpBoxWhere.Controls.Add(Me.rdobtnnnDays)
        Me.grpBoxWhere.Controls.Add(Me.txtBoxnnRec)
        Me.grpBoxWhere.Controls.Add(Me.CBoxFields)
        Me.grpBoxWhere.Controls.Add(Me.cboxValue)
        Me.grpBoxWhere.Controls.Add(Me.cboxCondition)
        Me.grpBoxWhere.Location = New System.Drawing.Point(10, 272)
        Me.grpBoxWhere.Name = "grpBoxWhere"
        Me.grpBoxWhere.Size = New System.Drawing.Size(633, 262)
        Me.grpBoxWhere.TabIndex = 2
        Me.grpBoxWhere.TabStop = False
        Me.grpBoxWhere.Text = "Condition Field"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(557, 212)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 23)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'rtBoxCondition
        '
        Me.rtBoxCondition.AutoWordSelection = True
        Me.rtBoxCondition.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rtBoxCondition.Location = New System.Drawing.Point(13, 85)
        Me.rtBoxCondition.Name = "rtBoxCondition"
        Me.rtBoxCondition.ReadOnly = True
        Me.rtBoxCondition.Size = New System.Drawing.Size(607, 113)
        Me.rtBoxCondition.TabIndex = 13
        Me.rtBoxCondition.Text = ""
        '
        'lblAND
        '
        Me.lblAND.AutoSize = True
        Me.lblAND.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAND.Location = New System.Drawing.Point(460, 52)
        Me.lblAND.Name = "lblAND"
        Me.lblAND.Size = New System.Drawing.Size(46, 13)
        Me.lblAND.TabIndex = 7
        Me.lblAND.Text = "(AND)"
        '
        'btnWhereAdd
        '
        Me.btnWhereAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWhereAdd.Location = New System.Drawing.Point(506, 47)
        Me.btnWhereAdd.Name = "btnWhereAdd"
        Me.btnWhereAdd.Size = New System.Drawing.Size(24, 23)
        Me.btnWhereAdd.TabIndex = 7
        Me.btnWhereAdd.Text = "V"
        Me.btnWhereAdd.UseVisualStyleBackColor = True
        '
        'CBoxFields
        '
        Me.CBoxFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxFields.FormattingEnabled = True
        Me.CBoxFields.Items.AddRange(New Object() {"Channel", "StartTime", "AlarmIdentifier", "Priority", "TagNo", "Parameter", "Unit", "Area", "Plant"})
        Me.CBoxFields.Location = New System.Drawing.Point(13, 49)
        Me.CBoxFields.Name = "CBoxFields"
        Me.CBoxFields.Size = New System.Drawing.Size(158, 21)
        Me.CBoxFields.TabIndex = 8
        '
        'cboxValue
        '
        Me.cboxValue.FormattingEnabled = True
        Me.cboxValue.Location = New System.Drawing.Point(234, 49)
        Me.cboxValue.Name = "cboxValue"
        Me.cboxValue.Size = New System.Drawing.Size(220, 21)
        Me.cboxValue.TabIndex = 9
        '
        'cboxCondition
        '
        Me.cboxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxCondition.FormattingEnabled = True
        Me.cboxCondition.Items.AddRange(New Object() {"=", ">", "<", ">=", "<=", "<>", "LIKE"})
        Me.cboxCondition.Location = New System.Drawing.Point(177, 49)
        Me.cboxCondition.Name = "cboxCondition"
        Me.cboxCondition.Size = New System.Drawing.Size(51, 21)
        Me.cboxCondition.TabIndex = 10
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(480, 543)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(69, 23)
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = " Save"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(567, 543)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpBoxFunction
        '
        Me.grpBoxFunction.Controls.Add(Me.lblof)
        Me.grpBoxFunction.Controls.Add(Me.cboxFunField)
        Me.grpBoxFunction.Controls.Add(Me.cboxFunction)
        Me.grpBoxFunction.Location = New System.Drawing.Point(10, 206)
        Me.grpBoxFunction.Name = "grpBoxFunction"
        Me.grpBoxFunction.Size = New System.Drawing.Size(590, 81)
        Me.grpBoxFunction.TabIndex = 8
        Me.grpBoxFunction.TabStop = False
        Me.grpBoxFunction.Text = "Select Function"
        '
        'lblof
        '
        Me.lblof.AutoSize = True
        Me.lblof.Location = New System.Drawing.Point(287, 27)
        Me.lblof.Name = "lblof"
        Me.lblof.Size = New System.Drawing.Size(31, 13)
        Me.lblof.TabIndex = 9
        Me.lblof.Text = "(Of)"
        '
        'cboxFunField
        '
        Me.cboxFunField.FormattingEnabled = True
        Me.cboxFunField.Items.AddRange(New Object() {"EventId", "Channel", "StartTime", "AlarmIdentifier", "Priority", "TagNo", "Parameter", "Unit", "Area", "Plant"})
        Me.cboxFunField.Location = New System.Drawing.Point(323, 22)
        Me.cboxFunField.Name = "cboxFunField"
        Me.cboxFunField.Size = New System.Drawing.Size(183, 21)
        Me.cboxFunField.TabIndex = 13
        '
        'cboxFunction
        '
        Me.cboxFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxFunction.FormattingEnabled = True
        Me.cboxFunction.Items.AddRange(New Object() {"Max", "Min", "Avg", "RealTime", "StaleAlarms", "StandingAlarmDuration", "UnAcknowledgedAlarms", "TimeToAcknowledge", "ReturnBeforeAck", "AlarmType --> Misc Alarms", "AlarmType --> Absolute", "AlarmType --> Safety", "AlarmType --> Diagnostic", "AlarmType --> Statistical", "AlarmType --> Calculated", "AlarmType --> ReAlarm", "AlarmType --> BadPVorOP", "AlarmType --> ROC", "AlarmType --> Deviation", "AlarmType --> System", "OperatorAction -->Misc OA", "OperatorAction -->ModeChange", "OperatorAction -->SPorOPChange", "OperatorAction -->On/Off", "OperatorAction -->Start/Stop", "OperatorAction -->AlarmShelving&Release", "OperatorAction -->StateChange", "AlarmStatus -->Active", "AlarmStatus -->Shelved", "AlarmStatus -->SuppressedByDesign", "AlarmStatus -->Released", "ConfigurationChange", "Others", "Priority Distribution"})
        Me.cboxFunction.Location = New System.Drawing.Point(15, 22)
        Me.cboxFunction.Name = "cboxFunction"
        Me.cboxFunction.Size = New System.Drawing.Size(266, 21)
        Me.cboxFunction.TabIndex = 13
        '
        'grpboxType
        '
        Me.grpboxType.Controls.Add(Me.rdobtnAnnunciator)
        Me.grpboxType.Controls.Add(Me.rdobtnTrend)
        Me.grpboxType.Controls.Add(Me.rdobtnValue)
        Me.grpboxType.Controls.Add(Me.rdobtnDisplay)
        Me.grpboxType.Location = New System.Drawing.Point(10, 2)
        Me.grpboxType.Name = "grpboxType"
        Me.grpboxType.Size = New System.Drawing.Size(633, 65)
        Me.grpboxType.TabIndex = 9
        Me.grpboxType.TabStop = False
        Me.grpboxType.Text = "Select Type"
        '
        'rdobtnAnnunciator
        '
        Me.rdobtnAnnunciator.AutoSize = True
        Me.rdobtnAnnunciator.Location = New System.Drawing.Point(463, 26)
        Me.rdobtnAnnunciator.Name = "rdobtnAnnunciator"
        Me.rdobtnAnnunciator.Size = New System.Drawing.Size(93, 17)
        Me.rdobtnAnnunciator.TabIndex = 16
        Me.rdobtnAnnunciator.Text = "Annunciator"
        Me.rdobtnAnnunciator.UseVisualStyleBackColor = True
        '
        'rdobtnTrend
        '
        Me.rdobtnTrend.AutoSize = True
        Me.rdobtnTrend.Location = New System.Drawing.Point(330, 26)
        Me.rdobtnTrend.Name = "rdobtnTrend"
        Me.rdobtnTrend.Size = New System.Drawing.Size(60, 17)
        Me.rdobtnTrend.TabIndex = 15
        Me.rdobtnTrend.Text = "Graph"
        Me.rdobtnTrend.UseVisualStyleBackColor = True
        '
        'rdobtnValue
        '
        Me.rdobtnValue.AutoSize = True
        Me.rdobtnValue.Location = New System.Drawing.Point(177, 26)
        Me.rdobtnValue.Name = "rdobtnValue"
        Me.rdobtnValue.Size = New System.Drawing.Size(56, 17)
        Me.rdobtnValue.TabIndex = 14
        Me.rdobtnValue.Text = "Value"
        Me.rdobtnValue.UseVisualStyleBackColor = True
        '
        'rdobtnDisplay
        '
        Me.rdobtnDisplay.AutoSize = True
        Me.rdobtnDisplay.Checked = True
        Me.rdobtnDisplay.Location = New System.Drawing.Point(33, 26)
        Me.rdobtnDisplay.Name = "rdobtnDisplay"
        Me.rdobtnDisplay.Size = New System.Drawing.Size(55, 17)
        Me.rdobtnDisplay.TabIndex = 14
        Me.rdobtnDisplay.TabStop = True
        Me.rdobtnDisplay.Text = "Table"
        Me.rdobtnDisplay.UseVisualStyleBackColor = True
        '
        'lblNote
        '
        Me.lblNote.AutoEllipsis = True
        Me.lblNote.ForeColor = System.Drawing.Color.Gray
        Me.lblNote.Location = New System.Drawing.Point(13, 537)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(253, 29)
        Me.lblNote.TabIndex = 10
        Me.lblNote.Text = "*Set Optimam Records and Refresh Time       for Optimal Performance ...."
        '
        'GrpBoxAnnunciator
        '
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label6)
        Me.GrpBoxAnnunciator.Controls.Add(Me.chkTagParView)
        Me.GrpBoxAnnunciator.Controls.Add(Me.chkAliasNameView)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label1)
        Me.GrpBoxAnnunciator.Controls.Add(Me.txtAlaiseName)
        Me.GrpBoxAnnunciator.Controls.Add(Me.btnMoveDown)
        Me.GrpBoxAnnunciator.Controls.Add(Me.btnMoveUpValue)
        Me.GrpBoxAnnunciator.Controls.Add(Me.BtnAdd_TagParameter)
        Me.GrpBoxAnnunciator.Controls.Add(Me.cBoxParameterField)
        Me.GrpBoxAnnunciator.Controls.Add(Me.cBoxTagNoField)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label5)
        Me.GrpBoxAnnunciator.Controls.Add(Me.LstBoxSelectValue)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label4)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label3)
        Me.GrpBoxAnnunciator.Controls.Add(Me.CBoxAnnunValue)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Label2)
        Me.GrpBoxAnnunciator.Controls.Add(Me.Button1)
        Me.GrpBoxAnnunciator.Controls.Add(Me.CBoxAnnunFields)
        Me.GrpBoxAnnunciator.Location = New System.Drawing.Point(10, 74)
        Me.GrpBoxAnnunciator.Name = "GrpBoxAnnunciator"
        Me.GrpBoxAnnunciator.Size = New System.Drawing.Size(633, 460)
        Me.GrpBoxAnnunciator.TabIndex = 14
        Me.GrpBoxAnnunciator.TabStop = False
        Me.GrpBoxAnnunciator.Text = "Condition Field"
        Me.GrpBoxAnnunciator.Visible = False
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Location = New System.Drawing.Point(554, 247)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(60, 34)
        Me.btnMoveDown.TabIndex = 27
        Me.btnMoveDown.Text = "DOWN"
        Me.btnMoveDown.UseVisualStyleBackColor = True
        '
        'btnMoveUpValue
        '
        Me.btnMoveUpValue.Location = New System.Drawing.Point(554, 193)
        Me.btnMoveUpValue.Name = "btnMoveUpValue"
        Me.btnMoveUpValue.Size = New System.Drawing.Size(60, 34)
        Me.btnMoveUpValue.TabIndex = 27
        Me.btnMoveUpValue.Text = "UP"
        Me.btnMoveUpValue.UseVisualStyleBackColor = True
        '
        'BtnAdd_TagParameter
        '
        Me.BtnAdd_TagParameter.Location = New System.Drawing.Point(554, 145)
        Me.BtnAdd_TagParameter.Name = "BtnAdd_TagParameter"
        Me.BtnAdd_TagParameter.Size = New System.Drawing.Size(60, 23)
        Me.BtnAdd_TagParameter.TabIndex = 26
        Me.BtnAdd_TagParameter.Tag = ""
        Me.BtnAdd_TagParameter.Text = "ADD"
        Me.BtnAdd_TagParameter.UseVisualStyleBackColor = True
        '
        'cBoxParameterField
        '
        Me.cBoxParameterField.FormattingEnabled = True
        Me.cBoxParameterField.Items.AddRange(New Object() {"Channel", "Plant", "Area", "Unit", "Equipment"})
        Me.cBoxParameterField.Location = New System.Drawing.Point(408, 69)
        Me.cBoxParameterField.Name = "cBoxParameterField"
        Me.cBoxParameterField.Size = New System.Drawing.Size(153, 21)
        Me.cBoxParameterField.TabIndex = 25
        '
        'cBoxTagNoField
        '
        Me.cBoxTagNoField.FormattingEnabled = True
        Me.cBoxTagNoField.Items.AddRange(New Object() {"Channel", "Plant", "Area", "Unit", "Equipment"})
        Me.cBoxTagNoField.Location = New System.Drawing.Point(108, 69)
        Me.cBoxTagNoField.Name = "cBoxTagNoField"
        Me.cBoxTagNoField.Size = New System.Drawing.Size(210, 21)
        Me.cBoxTagNoField.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Parameter :"
        '
        'LstBoxSelectValue
        '
        Me.LstBoxSelectValue.FormattingEnabled = True
        Me.LstBoxSelectValue.Location = New System.Drawing.Point(38, 167)
        Me.LstBoxSelectValue.Name = "LstBoxSelectValue"
        Me.LstBoxSelectValue.Size = New System.Drawing.Size(498, 251)
        Me.LstBoxSelectValue.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Tag No "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(358, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "="
        '
        'CBoxAnnunValue
        '
        Me.CBoxAnnunValue.FormattingEnabled = True
        Me.CBoxAnnunValue.Location = New System.Drawing.Point(408, 29)
        Me.CBoxAnnunValue.Name = "CBoxAnnunValue"
        Me.CBoxAnnunValue.Size = New System.Drawing.Size(153, 21)
        Me.CBoxAnnunValue.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Type "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(554, 429)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CBoxAnnunFields
        '
        Me.CBoxAnnunFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxAnnunFields.FormattingEnabled = True
        Me.CBoxAnnunFields.Items.AddRange(New Object() {"Plant", "Area", "Unit", "Equipment"})
        Me.CBoxAnnunFields.Location = New System.Drawing.Point(108, 29)
        Me.CBoxAnnunFields.Name = "CBoxAnnunFields"
        Me.CBoxAnnunFields.Size = New System.Drawing.Size(210, 21)
        Me.CBoxAnnunFields.TabIndex = 8
        '
        'txtAlaiseName
        '
        Me.txtAlaiseName.Location = New System.Drawing.Point(108, 103)
        Me.txtAlaiseName.Name = "txtAlaiseName"
        Me.txtAlaiseName.Size = New System.Drawing.Size(210, 21)
        Me.txtAlaiseName.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Alias Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "View  Name"
        '
        'chkTagParView
        '
        Me.chkTagParView.AutoSize = True
        Me.chkTagParView.Location = New System.Drawing.Point(273, 145)
        Me.chkTagParView.Name = "chkTagParView"
        Me.chkTagParView.Size = New System.Drawing.Size(111, 17)
        Me.chkTagParView.TabIndex = 59
        Me.chkTagParView.Text = "Tag-Parameter"
        Me.chkTagParView.UseVisualStyleBackColor = True
        '
        'chkAliasNameView
        '
        Me.chkAliasNameView.AutoSize = True
        Me.chkAliasNameView.Location = New System.Drawing.Point(138, 145)
        Me.chkAliasNameView.Name = "chkAliasNameView"
        Me.chkAliasNameView.Size = New System.Drawing.Size(90, 17)
        Me.chkAliasNameView.TabIndex = 58
        Me.chkAliasNameView.Text = "Alias Name"
        Me.chkAliasNameView.UseVisualStyleBackColor = True
        '
        'DBQueryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 575)
        Me.Controls.Add(Me.GrpBoxAnnunciator)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.grpboxType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.grpBoxWhere)
        Me.Controls.Add(Me.grpBoxFunction)
        Me.Controls.Add(Me.GrpBoxSelect)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(678, 614)
        Me.Name = "DBQueryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Query Builder"
        Me.GrpBoxSelect.ResumeLayout(False)
        Me.GrpBoxSelect.PerformLayout()
        Me.grpBoxWhere.ResumeLayout(False)
        Me.grpBoxWhere.PerformLayout()
        Me.grpBoxFunction.ResumeLayout(False)
        Me.grpBoxFunction.PerformLayout()
        Me.grpboxType.ResumeLayout(False)
        Me.grpboxType.PerformLayout()
        Me.GrpBoxAnnunciator.ResumeLayout(False)
        Me.GrpBoxAnnunciator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxSelect As System.Windows.Forms.GroupBox
    Friend WithEvents grpBoxWhere As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdobtnnnRec As System.Windows.Forms.RadioButton
    Friend WithEvents txtBoxnnRec As System.Windows.Forms.TextBox
    Friend WithEvents btnWhereAdd As System.Windows.Forms.Button
    Friend WithEvents cboxValue As System.Windows.Forms.ComboBox
    Friend WithEvents CBoxFields As System.Windows.Forms.ComboBox
    Friend WithEvents lblAND As System.Windows.Forms.Label
    Friend WithEvents cboxCondition As System.Windows.Forms.ComboBox
    Friend WithEvents CKlstBox__Fields As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtBoxnnDays As System.Windows.Forms.TextBox
    Friend WithEvents rdobtnnnDays As System.Windows.Forms.RadioButton
    Friend WithEvents grpBoxFunction As System.Windows.Forms.GroupBox
    Friend WithEvents cboxFunField As System.Windows.Forms.ComboBox
    Friend WithEvents cboxFunction As System.Windows.Forms.ComboBox
    Friend WithEvents lblof As System.Windows.Forms.Label
    Friend WithEvents rtBoxCondition As System.Windows.Forms.RichTextBox
    Friend WithEvents ckBoxbuild_Fun As System.Windows.Forms.CheckBox
    Friend WithEvents cboxBuildFunction As System.Windows.Forms.ComboBox
    Friend WithEvents grpboxType As System.Windows.Forms.GroupBox
    Friend WithEvents rdobtnTrend As System.Windows.Forms.RadioButton
    Friend WithEvents rdobtnValue As System.Windows.Forms.RadioButton
    Friend WithEvents rdobtnDisplay As System.Windows.Forms.RadioButton
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents rdobtnAnnunciator As RadioButton
    Friend WithEvents GrpBoxAnnunciator As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CBoxAnnunFields As ComboBox
    Friend WithEvents CBoxAnnunValue As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LstBoxSelectValue As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cBoxParameterField As ComboBox
    Friend WithEvents cBoxTagNoField As ComboBox
    Friend WithEvents BtnAdd_TagParameter As Button
    Friend WithEvents btnMoveDown As Button
    Friend WithEvents btnMoveUpValue As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAlaiseName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkTagParView As CheckBox
    Friend WithEvents chkAliasNameView As CheckBox
End Class
