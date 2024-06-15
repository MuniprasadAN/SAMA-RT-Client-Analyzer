Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Threading
Imports NAudio.Wave
Imports System.Data.SqlClient


Public Class AnnunciatorAlarmstateClass
    Friend CheckAlaramList As New List(Of Integer)
    Friend dt_PriorityAnunnciator As DataTable
    Friend _Audible1Enabled As String
    Friend _Audible2Enabled As String
    Friend _AudiblePath1 As String
    Friend _AudiblePath2 As String
    Friend _AudibleDeviceName As String
    Dim list As New List(Of String)
    Dim ltVal As Integer



    Dim MpageVal As New MainPage
    Dim con = MpageVal.GetConString()
    Dim sqlConn As New SqlConnection(con)

    Dim sqLcmd As New SqlCommand
    Dim dr As SqlDataReader

    ' Dim DbData As DBDataForm
    'Dim asd = DbData.dt_AnnunciatorValue

    Friend blnplaying As Boolean = False


    Public Sub AddFunction(ByVal tag_param As String, ByVal priority As String, ByVal StartTime As DateTime, ByVal AlarmState As String)
        Try
            'Dim Tag = tag_param.Substring(0, tag_param.LastIndexOf("."))
            'Dim parameter = tag_param.Substring(tag_param.LastIndexOf(".") + 1)
            '   Dim _StartTime As String = StartTime.ToString("yyyy/MM/dd HH:mm:ss.fff")
            ltVal = CheckAlaramList.Min()
            Dim GetPriorityVal = Annunciator_PriorityDataTable(ltVal)
            If GetPriorityVal IsNot Nothing Then
                If GetPriorityVal.Rows.Count > 0 Then
                    For k = 0 To GetPriorityVal.Rows.Count - 1
                        Dim PriorityName = GetPriorityVal.Rows(k).ItemArray(1)
                        Dim _AlarmState = GetPriorityVal.Rows(k).ItemArray(2)
                        Dim _AudDeviceName = GetPriorityVal.Rows(k).ItemArray(3)
                        Dim _Audible1 As Boolean = GetPriorityVal.Rows(k).ItemArray(4)
                        Dim _Audible2 As Boolean = GetPriorityVal.Rows(k).ItemArray(5)
                        Dim _Audiblepath1 As String = GetPriorityVal.Rows(k).ItemArray(6)
                        Dim _Audiblepath2 As String = GetPriorityVal.Rows(k).ItemArray(7)



                        If priority = PriorityName And AlarmState = _AlarmState Then

                            If _Audible1 AndAlso _Audible2 Then

                                list.Clear()
                                list.Add(_Audiblepath1)
                                list.Add(_AudDeviceName)
                                list.Add(_Audiblepath2)
                                Dim _thread As New Thread(AddressOf GetAudioList12)
                                _thread.Start()
                            ElseIf _Audible1 Then
                                list.Clear()
                                'list.Add("C:\Users\Admin\Downloads\loop.wav")
                                list.Add(_Audiblepath1)
                                list.Add(_AudDeviceName)
                                Dim _thread As New Thread(AddressOf GetAudioList)
                                _thread.Start()
                            ElseIf _Audible2 Then
                                list.Clear()
                                list.Add(_Audiblepath2)
                                list.Add(_AudDeviceName)
                                Dim _thread As New Thread(AddressOf GetAudioList)
                                _thread.Start()
                            End If

                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@AddFunction()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
        End Try

    End Sub

    Friend Function Annunciator_PriorityDataTable(ByVal prirityId As Integer)
        Dim dt As New DataTable
        Try
            sqlConn.Open()
            Using dad As New SqlDataAdapter("SELECT ta.Annunciator_PriorityId,tp.PriorityName,ta.AlarmState,ta.AudioDeviceName,ta.Audible1Enabled,ta.Audible2Enabled,ta.Audible1Path,ta.Audible2Path,tp.PriorityId From tblAnnunciator_Priority as Ta join tblPriority as tp on tp.PriorityId=ta.PriorityName where tp.PriorityId='" & prirityId & "' ", sqlConn)
                dad.Fill(dt)
            End Using
        Catch ex As Exception
            MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@Annunciator_PriorityDataTable()")
            MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            Return Nothing
        Finally
            If sqlConn.State = ConnectionState.Open Then
                sqlConn.Close()
            End If
        End Try
        Return dt
    End Function

    'ByVal _Audiblepath1 As String, ByVal _AudibleDeviceName As String
    Public Sub GetAudioList()
        Dim _AudiblePath1 = list.Item(0)
        Dim _AudibleDeviceName = list.Item(1)
        If _AudiblePath1 <> "" Then
            blnplaying = True
            Dim mainOutputStream As WaveStream
            Dim volumeStream As WaveChannel32
            Dim PathVal = _AudiblePath1.Substring(_AudiblePath1.LastIndexOf(".")).ToUpper

            '---------------------- Mp3 File Reader---------------------'
            If PathVal = ".MP3" Then
                mainOutputStream = New Mp3FileReader(_AudiblePath1)
                volumeStream = New WaveChannel32(mainOutputStream)

                '---------------------- Wav File Reader---------------------'
            ElseIf PathVal = ".WAV" Then
                mainOutputStream = New WaveFileReader(_AudiblePath1)
                volumeStream = New WaveChannel32(mainOutputStream)
            End If


            Dim player As WaveOutEvent = New WaveOutEvent
            Dim waveoutDevices As Integer = WaveOut.DeviceCount
            Dim lstaudiodevices As New List(Of String)
            'Audio List

            For w As Integer = 0 To waveoutDevices - 1
                Dim deviceinfo As WaveOutCapabilities = WaveOut.GetCapabilities(w)
                lstaudiodevices.Add(deviceinfo.ProductName)
            Next
            Try
                Dim indx As Integer = lstaudiodevices.IndexOf(_AudibleDeviceName)
                If indx > -1 Then
                    player.DeviceNumber = indx
                    player.Init(volumeStream)

                    Dim curtime As DateTime = Now
                    Dim wt As Int32 = volumeStream.TotalTime.TotalMilliseconds
                    player.Play()

                    While curtime.AddMilliseconds(wt) > Now
                        Thread.Sleep(100)
                    End While
                    player.Stop()

                End If
                CheckAlaramList.Remove(ltVal)
            Catch ex As Exception
                MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GetAudioList()")
                MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            End Try
        End If
        blnplaying = False
    End Sub


    Public Sub GetAudioList12()


        Debug.Print("Audio 1 :" & Now)
        Dim _AudiblePath1 As String = list.Item(0)
        Dim _AudibleDeviceName As String = list.Item(1)
        Dim mainOutputStream As WaveStream = Nothing
        Dim volumeStream As WaveChannel32
        Dim player As WaveOutEvent = New WaveOutEvent
        If _AudiblePath1 <> "" Then
            blnplaying = True

            Dim PathVal = _AudiblePath1.Substring(_AudiblePath1.LastIndexOf(".")).ToUpper

            '---------------------- Mp3 File Reader---------------------'
            If PathVal = ".MP3" Then
                mainOutputStream = New Mp3FileReader(_AudiblePath1)
                volumeStream = New WaveChannel32(mainOutputStream)

                '---------------------- Wav File Reader---------------------'
            ElseIf PathVal = ".WAV" Then
                mainOutputStream = New WaveFileReader(_AudiblePath1)
                volumeStream = New WaveChannel32(mainOutputStream)
            End If



            Dim waveoutDevices As Integer = WaveOut.DeviceCount
            Dim lstaudiodevices As New List(Of String)
            'Audio List

            For w As Integer = 0 To waveoutDevices - 1
                Dim deviceinfo As WaveOutCapabilities = WaveOut.GetCapabilities(w)
                lstaudiodevices.Add(deviceinfo.ProductName)
            Next
            Try
                Dim indx As Integer = lstaudiodevices.IndexOf(_AudibleDeviceName)
                If indx > -1 Then
                    player.DeviceNumber = indx
                    player.Init(volumeStream)

                    Dim curtime As DateTime = Now
                    Dim wt As Int32 = volumeStream.TotalTime.TotalMilliseconds
                    player.Play()

                    While curtime.AddMilliseconds(wt) > Now
                        Thread.Sleep(100)
                    End While
                    player.Stop()
                    CheckAlaramList.Remove(ltVal)
                End If
                Debug.Print("Audio 1a :" & Now)
            Catch ex As Exception
                MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GetAudioList()")
                MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            End Try
        End If

        Dim _AudiblePathVal As String = list.Item(2)
        Debug.Print("Audio 2 :" & Now)
        If _AudiblePathVal <> "" Then
            blnplaying = True
            Dim PathVal = _AudiblePathVal.Substring(_AudiblePathVal.LastIndexOf(".")).ToUpper

            '---------------------- Mp3 File Reader---------------------'
            If PathVal = ".MP3" Then
                mainOutputStream = New Mp3FileReader(_AudiblePathVal)
                volumeStream = New WaveChannel32(mainOutputStream)

                '---------------------- Wav File Reader---------------------'
            ElseIf PathVal = ".WAV" Then
                mainOutputStream = New WaveFileReader(_AudiblePathVal)
                volumeStream = New WaveChannel32(mainOutputStream)
            End If


            player = New WaveOutEvent
            Dim waveoutDevices As Integer = WaveOut.DeviceCount
            Dim lstaudiodevices As New List(Of String)
            'Audio List

            For w As Integer = 0 To waveoutDevices - 1
                Dim deviceinfo As WaveOutCapabilities = WaveOut.GetCapabilities(w)
                lstaudiodevices.Add(deviceinfo.ProductName)
            Next
            Try
                Dim indx As Integer = lstaudiodevices.IndexOf(_AudibleDeviceName)
                If indx > -1 Then
                    player.DeviceNumber = indx
                    player.Init(volumeStream)

                    Dim curtime As DateTime = Now
                    Dim wt As Int32 = volumeStream.TotalTime.TotalMilliseconds
                    player.Play()

                    While curtime.AddMilliseconds(wt) > Now
                        Thread.Sleep(100)
                    End While
                    player.Stop()
                    CheckAlaramList.Remove(ltVal)
                    Debug.Print("Audio 2a :" & Now)
                End If
            Catch ex As Exception
                MainPage._errLog.Add("Error@" & Now.ToString & "@" & ex.Message & "@GetAudioList()")
                MainPage.MainErrorPV.SetError(MainPage.lblAlert, "Error !!!")
            End Try
        End If


        Try
            mainOutputStream.Dispose()
        Catch ex As Exception

        End Try

        Try
            volumeStream.Dispose()
        Catch ex As Exception

        End Try
        Try
            player.Dispose()
        Catch ex As Exception

        End Try
        blnplaying = False
    End Sub

End Class
