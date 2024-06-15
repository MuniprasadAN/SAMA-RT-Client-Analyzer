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


Imports System.ComponentModel

Public Class AnnunciatorCtrl
    Inherits FlowLayoutPanel

    'Public _ThresholdValue As New List(Of String)
    'Public _THForeColor As New List(Of Integer)
    'Public _THBackColor As New List(Of Integer)
    'Public _Description As New List(Of String)
    'Public _THblink As New List(Of Boolean)


    'Private _DefaultForeColor As Color = Color.Black
    'Private _DefaultBackColor As Color
    'Private _UnitVal As String = ""
    'Private _blink As Boolean
    'Public _timerVA As Integer
    'Public _timer As New System.Windows.Forms.Timer

    'Dim i As Integer = 0
    'Public Sub New()

    '    Dim asd As Integer = 0
    '    AddHandler _timer.Tick, AddressOf Tick_Timer
    '    AddHandler Me.Invalidated, AddressOf Focus_Label
    'End Sub
    'Private Sub Focus_Label()

    '    If _blink Then
    '        _timer.Interval = 100
    '        '_timer.Stop()
    '        _timer.Enabled = True

    '    Else
    '        _timer.Enabled = False
    '        _timer.Dispose()
    '        Me.Visible = True
    '    End If
    'End Sub
    'Public Sub Tick_Timer()
    '    If i = 0 Then
    '        Me.Visible = False
    '        i = 1
    '    Else
    '        Me.Visible = True
    '        i = 0
    '    End If

    'End Sub


    '<Category("Custom")>
    'Public Property Blink() As Boolean
    '    Get
    '        Return Me._blink
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Me._blink = value
    '        Me.Invalidate()
    '    End Set
    'End Property
End Class
