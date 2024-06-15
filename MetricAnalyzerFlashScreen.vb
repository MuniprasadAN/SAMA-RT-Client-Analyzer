' ***********************************************************************
' Assembly         : SAMA Analyzer
' Author           : supra
' Created          : 01-01-2014
'
' Last Modified By : supra
' Last Modified On : 02-12-2014
' ***********************************************************************
' <copyright file="MetricAnalyzerFlashScreen.vb" company="SCPL">
'     SCPL. All rights reserved.
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Reflection
Imports System.IO

Public NotInheritable Class MetricAnalyzerFlashScreen
    Dim i As Integer ' = 0
    Private Sub MetricAnalyzerFlashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If False Then
            tmeProgress.Enabled = False
            Form1.ShowDialog()
            'MChartPropertiesFormNew.ShowDialog()
            End
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        'Copyright info
        'Copyright.Text = My.Application.Info.Copyright
        If MainPage.Server_Flag Then
            lblStatus.Text = "Server Loading ...."
        Else
            lblStatus.Text = "Client Loading ...."
        End If

    End Sub

    Private Sub tmeProgress_Tick( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles tmeProgress.Tick
        tmeProgress.Enabled = False
        If MainPage.Server_Flag Then
            MainPage.Constr = MainPage.GetConString.ToString.Replace("""", "")
            If Not String.IsNullOrEmpty(MainPage.Constr) Then
                Call MainPage.Proc_FillQueryFromtblReportType() 'Fill Query
            End If
            Call MainPage.GetopcServers()
            MainPage.Server_PushDataPath = ""
            Me.Hide()
            MainPage.Show()
        Else
            MainPage.Server_PushDataPath = ""
            Me.Hide()
            MainPage.Show()
       End If
End Sub


End Class
