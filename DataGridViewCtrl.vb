' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 02-11-2014
'
' Last Modified By : supra
' Last Modified On : 02-11-2014
' ***********************************************************************
' <copyright file="DataGridViewCtrl.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Public Class DataGridViewCtrl
    Inherits DataGridView
    Friend _ThresholdValue As New List(Of String)
    Friend _THForeColor As New List(Of Integer)
    Friend _THBackColor As New List(Of Integer)
    Friend _THFont As New List(Of String)
    Friend _SetCondtion As New List(Of String)
End Class

