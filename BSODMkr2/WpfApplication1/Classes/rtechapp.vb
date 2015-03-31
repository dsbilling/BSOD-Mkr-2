Public Class rtechapp
    Public Shared filesFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Retarded Tech\" _
                                              & System.Reflection.Assembly.GetEntryAssembly().GetName().Name & "\"
    Public Shared logsFilePath As String = filesFolderPath & "\logs\"
    Public Shared logFileName As String = logsFilePath & DateTime.Now.ToString("dd-MM-yyyy") & ".log"
    Public Shared tempFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory & "\temp\"
    Public Shared settingsFilePath As String = filesFolderPath & "settings.ini"
    Public Shared defaultSettings As String = "debug=0" & vbNewLine & "updatestartup=1" & vbNewLine & "autorestartafterbsod=1" & vbNewLine & "textmode=0" _
                                              & vbNewLine & "basictime=30" & vbNewLine & "basiccolor=0"
    Public Shared ProductName As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
    Public Shared longVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." _
                                            & My.Application.Info.Version.Build.ToString & " Build " & My.Application.Info.Version.Revision.ToString
    Public Shared shortVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." _
                                            & My.Application.Info.Version.Build.ToString
    Public Shared miniVersion As String = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString

    Public Shared Sub ApplicationShutdown()
        rtechlog.logThis("INFO", "Application is shutting down.")
        Application.Current.Shutdown()
    End Sub
    Public Shared Sub ApplicationRestart()
        rtechlog.logThis("INFO", "Application is restarting.")
        Process.Start(Application.ResourceAssembly.Location)
        Application.Current.Shutdown()
    End Sub
End Class
