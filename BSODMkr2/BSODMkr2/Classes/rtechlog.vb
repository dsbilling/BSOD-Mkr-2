Public Class rtechlog
    Public Shared Sub logThis(type As String, text As String)

        If type = Nothing Then
            type = "INFO"
        End If
        type = type.ToUpper()
        text = text.Replace(vbNewLine, "") 'Remove new lines if present

        If Not IO.Directory.Exists(rtechapp.logsFilePath) Then
            IO.Directory.CreateDirectory(rtechapp.logsFilePath)
        End If

        Dim OSBit As String
        If Environment.Is64BitOperatingSystem = True Then
            OSBit = " 64-Bit"
        Else
            OSBit = " 32-Bit"
        End If

        Dim LogComputerInfo As String
        LogComputerInfo = rtechapp.ProductName & " - " & rtechapp.longVersion & vbNewLine & _
                    "========================================" & vbNewLine & _
                    "Date and Time: " & DateTime.Now.ToString("dd. MMMM yyyy - HH:mm:ss") & vbNewLine & _
                    "Domain: " & Environment.UserDomainName & vbNewLine & _
                    "Username: " & Environment.UserName & vbNewLine & _
                    "Computername: " & Environment.MachineName & vbNewLine & _
                    "Windows: " & My.Computer.Info.OSFullName & OSBit & " (" & My.Computer.Info.OSVersion & ")" & vbNewLine & _
                    "========================================" & vbNewLine

        If Not IO.File.Exists(rtechapp.logFileName) Then
            IO.File.WriteAllText(rtechapp.logFileName, LogComputerInfo)
        End If

        Using writer As New IO.StreamWriter(rtechapp.logFileName, True)
            writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") & " - " & type & " - " & text)
        End Using

    End Sub
End Class
