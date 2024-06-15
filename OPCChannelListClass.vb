' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-15-2014
'
' Last Modified By : supra
' Last Modified On : 02-04-2014
' ***********************************************************************
' <copyright file="OPC_ChannelListClass.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' Class to store the OPC Details
''' </summary>
Public Class OpcChannelListClass
    Friend OPC_Channel_Name As New List(Of String)
    Friend OPC_ServerName As New List(Of String)
    Friend OPC_OPCItems As New List(Of String)
    Friend OPC_RefreshTime As New List(Of Integer)
    Friend OPC_HistoryLength As New List(Of Integer)
    Friend OPC_LastnnHourHistory As New List(Of Integer)
    Friend OPC_Multiview As New List(Of boolean)
   
End Class
