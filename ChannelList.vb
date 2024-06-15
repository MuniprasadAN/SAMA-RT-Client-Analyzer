' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-06-2014
' ***********************************************************************
' <copyright file="ChannelList.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' 	
''' </summary>
Public Class ChannelList
    Friend Channel_Name As New List(Of String)
    Friend Channel_Query As New List(Of String)
    Friend Channel_Flag As New List(Of String)
    Friend _Query_Channel As New List(Of String)
    Friend DBChannel_RefreshTime As New List(Of Integer)
End Class
