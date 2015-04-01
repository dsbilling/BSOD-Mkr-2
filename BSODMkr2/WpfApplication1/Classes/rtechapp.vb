Public Class rtechapp
    Public Shared filesFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Retarded Tech\" _
                                              & System.Reflection.Assembly.GetEntryAssembly().GetName().Name & "\"
    Public Shared logsFilePath As String = filesFolderPath & "\logs\"
    Public Shared logFileName As String = logsFilePath & DateTime.Now.ToString("dd-MM-yyyy") & ".log"
    Public Shared tempFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory & "\temp\"
    Public Shared settingsFilePath As String = filesFolderPath & "settings.ini"
    Public Shared defaultSettings As String = "debug=0" & vbNewLine & "updatestartup=1" & vbNewLine & "autorestartafterbsod=1" _
                                              & vbNewLine & "basictime=30" & vbNewLine & "basiccolor=0" & vbNewLine & "basictype=0"
    Public Shared ProductName As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    Public Shared longVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." _
                                            & My.Application.Info.Version.Build.ToString & " Build " & My.Application.Info.Version.Revision.ToString
    Public Shared shortVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." _
                                            & My.Application.Info.Version.Build.ToString
    Public Shared miniVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString

    Public Shared Sub ApplicationShutdown()
        Try
            rtechlog.logThis("INFO", "Application is shutting down.")
            Application.Current.Shutdown()
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Public Shared Sub ApplicationRestart()
        Try
            rtechlog.logThis("INFO", "Application shutting down...")
            Application.Current.Shutdown()
            rtechlog.logThis("INFO", "Application is trying to restart: " & Application.ResourceAssembly.Location)
            Process.Start(Application.ResourceAssembly.Location)
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
End Class
