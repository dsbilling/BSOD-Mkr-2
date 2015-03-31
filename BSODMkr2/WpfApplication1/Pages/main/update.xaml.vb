Imports System.Net
Imports System.ComponentModel
Imports System.IO.Compression
Imports System.IO

Class update

    Public Shared sw As New Stopwatch
    Public Shared client As New WebClient()

    Private Sub lblInfo_Loaded(sender As Object, e As RoutedEventArgs) Handles lblInfo.Loaded

        If checkforupdate.C4UBooleanOutput() = True Then
            btnDownload.Visibility = Windows.Visibility.Visible
        Else
            btnDownload.Visibility = Windows.Visibility.Hidden
        End If

        Try
            If My.Computer.Network.IsAvailable = False Then

                MBox.ShowKnownErrorBox("0001", "Can't connect to the internet!", "You need to be connected to the internet to use some features.")

                lblInfo.BBCode = vbNewLine & "[i]Can't connect to the internet![/i]"

            ElseIf My.Computer.Network.IsAvailable = True Then

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://retardedtech.no/products/bsodmkr/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim serverfile As String = reader.ReadToEnd()

                Dim serverarray() As String = serverfile.Split("|")

                Dim serverversion As String = serverarray(0)
                Dim serverdate As String = serverarray(1)
                Dim serverlink As String = serverarray(2)

                Dim newestversion As String = serverversion
                Dim currentversion As String = My.Application.Info.Version.ToString

                If newestversion <= currentversion Then
                    lblInfo.BBCode = vbNewLine & "[b]You have the newest version![/b]"
                    rtechlog.logThis("INFO", "Application is up-to-date.")
                ElseIf newestversion > currentversion Then
                    lblInfo.BBCode = vbNewLine & "[color=orange][b]Old version detected.[/b][/color] [url=http://docs.rtrdt.ch/display/BM/Release+Notes]What's new?[/url]" & vbNewLine & vbNewLine _
                                   & "[b]Current:[/b] " & currentversion & vbNewLine & "[b]Newest:[/b] " & newestversion & " (" & serverdate & ")"
                    rtechlog.logThis("INFO", "Update for application has been found. New: " & newestversion & " (" & serverdate & ") -  Old: " & currentversion)
                End If

            End If

        Catch ex As Exception
            MBox.ShowErrorBox(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As RoutedEventArgs) Handles btnDownload.Click

        btnDownload.IsEnabled = False
        btnCancel.Visibility = Windows.Visibility.Visible
        btnCancel.IsEnabled = True
        pbLoading.Visibility = Windows.Visibility.Visible
        pbDownload.Visibility = Windows.Visibility.Visible
        lblStatusText.Visibility = Windows.Visibility.Visible
        lblStatus.Visibility = Windows.Visibility.Visible
        lblStatus.BBCode = "Connecting..."
        rtechlog.logThis("INFO", "Update: Connecting to server for download...")

        lblTimeLeftText.Visibility = Windows.Visibility.Visible
        lblTimeLeft.Visibility = Windows.Visibility.Visible
        lblFileSizeText.Visibility = Windows.Visibility.Visible
        lblFileSize.Visibility = Windows.Visibility.Visible
        lblSpeedText.Visibility = Windows.Visibility.Visible
        lblSpeed.Visibility = Windows.Visibility.Visible

        lblElapsedTimeText.Visibility = Windows.Visibility.Visible
        lblElapsedTime.Visibility = Windows.Visibility.Visible

        pbDownload.Value = 0
        sw.Reset() 'Reset elapsed time
        lblElapsedTime.BBCode = "N/A"

        rtechlog.logThis("INFO", "Update: Checking files and folders.")
        Try
            If System.IO.Directory.Exists(rtechapp.filesFolderPath) = False Then
                System.IO.Directory.CreateDirectory(rtechapp.filesFolderPath)
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.ToString)
        End Try

        Try
            If System.IO.Directory.Exists(rtechapp.logsFilePath) = False Then
                System.IO.Directory.CreateDirectory(rtechapp.logsFilePath)
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.ToString)
        End Try

        rtechlog.logThis("INFO", "Update: Getting info from server.")

        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://retardedtech.no/products/bsodmkr/version.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim serverfile As String = reader.ReadToEnd()
            Dim serverarray() As String = serverfile.Split("|")
            Dim serverlink As String = serverarray(2)

            'MsgBox(serverlink)
            downloadUpdate(serverlink)

        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.ToString)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        btnDownload.IsEnabled = True
        btnCancel.IsEnabled = False
        client.CancelAsync()
        client.Dispose()
    End Sub

    Private Sub downloadUpdate(serverlink As String)
        Try
            rtechlog.logThis("INFO", "Update: Creating temp folder.")
            If System.IO.Directory.Exists(rtechapp.tempFilePath) = False Then
                System.IO.Directory.CreateDirectory(rtechapp.tempFilePath)
            End If
            rtechlog.logThis("INFO", "Update: Deleting old files.")
            If IO.File.Exists(rtechapp.tempFilePath & "newversion.zip") Then
                IO.File.Delete(rtechapp.tempFilePath & "newversion.zip")
            End If

            lblStatus.BBCode = "Collecting info..."
            rtechlog.logThis("INFO", "Update: Starting download.")

            sw.Start() ' start stopwatch just before sending request

            AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
            AddHandler client.DownloadFileCompleted, AddressOf OnDownloadComplete
            client.DownloadFileAsync(New Uri(serverlink), rtechapp.tempFilePath & "newversion.zip")

        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.ToString)
        End Try

    End Sub
    Private Sub OnDownloadComplete(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            lblStatus.BBCode = "Download done!"
            lblTimeLeft.BBCode = "Done."
            rtechlog.logThis("INFO", "Update: Download done.")
            'lblElapsedTime.BBCode = sw.Elapsed.Seconds & " seconds"

            unzipUpdate()

        ElseIf e.Cancelled Then
            lblStatus.BBCode = "Download cancelled!"
            rtechlog.logThis("INFO", "Update: Download cancelled!")

            pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 165, 0))
            pbLoading.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 165, 0))
        Else
            lblStatus.BBCode = "Download failed!"
            rtechlog.logThis("INFO", "Update: Download failed!")

            pbDownload.Value = 100
            pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 0, 0))
            pbLoading.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 0, 0))

            rtecherror.reportError("Download failed!", e.Error.ToString)

        End If
        sw.Stop()
    End Sub
    Private Sub ShowDownloadProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        pbDownload.Value = e.ProgressPercentage

        lblStatus.BBCode = "Downloading..."
        pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(27, 161, 0))
        pbLoading.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 255, 255))

        Dim size As Single = e.TotalBytesToReceive
        Dim sizeKB As Single = size / 1024
        Dim sizeMB As Single = sizeKB / 1024
        size = Decimal.Round(size, 2, MidpointRounding.AwayFromZero)
        sizeKB = Decimal.Round(sizeKB, 2, MidpointRounding.AwayFromZero)
        sizeMB = Decimal.Round(sizeMB, 2, MidpointRounding.AwayFromZero)

        If size < 1024 Then
            lblFileSize.BBCode = String.Format("{0} B", size)
        ElseIf sizeKB < 1024 Then
            lblFileSize.BBCode = String.Format("{0} KB", sizeKB)
        Else
            lblFileSize.BBCode = String.Format("{0} MB", sizeMB)
        End If

        Dim fi As New IO.FileInfo(rtechapp.tempFilePath & "newversion.zip")
        Dim kbDownloaded As Double = fi.Length / 1024
        Dim seconds As Integer = sw.Elapsed.Seconds
        If seconds = 0 Then ' Derp Fix
            seconds = 1
        Else
            seconds = seconds
        End If
        Dim kbps As Double = kbDownloaded / seconds
        Dim mbps As Double = kbps / 1024
        kbps = Decimal.Round(kbps, 2, MidpointRounding.AwayFromZero)
        mbps = Decimal.Round(mbps, 2, MidpointRounding.AwayFromZero)

        If kbps < 1024 Then
            lblSpeed.BBCode = String.Format("{0} KB/s", kbps)
        Else
            lblSpeed.BBCode = String.Format("{0} MB/s", mbps)
        End If

        If pbDownload.Value = 0 Then
            lblTimeLeft.BBCode = "Estimating..."
        Else
            Dim secondsRemaining As Double = (e.TotalBytesToReceive - e.BytesReceived) * sw.Elapsed.Seconds / e.BytesReceived
            Dim ts As TimeSpan = TimeSpan.FromSeconds(secondsRemaining)
            lblTimeLeft.BBCode = String.Format("{0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds)
            Select Case secondsRemaining
                Case Is < 60
                    lblTimeLeft.BBCode = String.Format("{0} sec", ts.Seconds)
                Case Is < 3600
                    lblTimeLeft.BBCode = String.Format("{0} min {1} sec", ts.Minutes, ts.Seconds)
                Case Is < 86400
                    lblTimeLeft.BBCode = String.Format("{0} hours {1} min {2} sec", ts.Hours, ts.Minutes, ts.Seconds)
                Case Else
                    lblTimeLeft.BBCode = String.Format("{0} days {1} hours {2} min {3} sec", ts.Days, ts.Hours, ts.Minutes, ts.Seconds)
            End Select

            Dim secondsElapsed As Integer = sw.Elapsed.Seconds
            Dim ts2 As TimeSpan = TimeSpan.FromSeconds(secondsElapsed)
            lblElapsedTime.BBCode = String.Format("{0}:{1}:{2}", ts2.Hours, ts2.Minutes, ts2.Seconds)
            Select Case secondsElapsed
                Case Is < 60
                    lblElapsedTime.BBCode = String.Format("{0} sec", ts2.Seconds)
                Case Is < 3600
                    lblElapsedTime.BBCode = String.Format("{0} min {1} sec", ts2.Minutes, ts2.Seconds)
                Case Is < 86400
                    lblElapsedTime.BBCode = String.Format("{0} hours {1} min {2} sec", ts2.Hours, ts2.Minutes, ts2.Seconds)
                Case Else
                    lblElapsedTime.BBCode = String.Format("{0} days {1} hours {2} min {3} sec", ts2.Days, ts2.Hours, ts2.Minutes, ts2.Seconds)
            End Select
        End If

    End Sub
    Private Sub unzipUpdate()

        lblStatus.Text = "Starting updater..."
        rtechlog.logThis("INFO", "Update: Starting updater...")
        pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(27, 161, 226))

        btnCancel.IsEnabled = False
        pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(27, 161, 0))
        pbLoading.Visibility = Windows.Visibility.Hidden

        Try

            If IO.File.Exists(rtechapp.tempFilePath & "app.txt") Then
                IO.File.Delete(rtechapp.tempFilePath & "app.txt")
            End If

            IO.File.WriteAllText(rtechapp.tempFilePath & "app.txt", System.Reflection.Assembly.GetExecutingAssembly().Location.ToString)

            If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "\updater.exe") Then
                Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\updater.exe")
                rtechapp.ApplicationShutdown()
            Else
                If IO.File.Exists(rtechapp.tempFilePath & "newversion.zip") Then
                    IO.File.Delete(rtechapp.tempFilePath & "newversion.zip")
                End If
                If IO.File.Exists(rtechapp.tempFilePath & "app.txt") Then
                    IO.File.Delete(rtechapp.tempFilePath & "app.txt")
                End If
                If IO.Directory.Exists(rtechapp.tempFilePath) Then
                    IO.Directory.Delete(rtechapp.tempFilePath)
                End If
                lblStatus.BBCode = "Updater.exe not found!"
                rtechlog.logThis("INFO", "Update: Updater.exe not found!")
                pbDownload.Foreground = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 0, 0))

                MBox.ShowKnownErrorBox("0100", "Updater.exe not found!", "Can't locate updater.exe in the same folder as this software, can't continue updating.")
            End If

        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.ToString)
        End Try

    End Sub
End Class
