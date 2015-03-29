Imports System.Net.Mail

Public Class rtecherror
    Public Shared Sub reportError(errorMessage As String, errorToString As String)
        'reportError(errorMessage As String, errorToString As String, errorType As Long, sendEmail As Boolean)
        Try
            If System.IO.Directory.Exists(rtechapp.logsFilePath) = False Then
                System.IO.Directory.CreateDirectory(rtechapp.logsFilePath)
            End If

            'Dim usermessage As String = ""
            'If errorType = MsgBoxStyle.Critical Then
            '    usermessage = "The application ran into a wall, please wait while we gather the bricks. The application needs to restart." & _
            '    vbNewLine & vbNewLine & "Error 1000: " & errorMessage & vbNewLine & vbNewLine & "Do you want to restart the application?"
            'ElseIf errorType = MsgBoxStyle.Exclamation Then
            '    usermessage = "The application needs to restart." & _
            '    vbNewLine & vbNewLine & "Warning: " & errorMessage & vbNewLine & vbNewLine & "Do you want to restart the application?"
            'End If

            MBox.ShowErrorBox(errorMessage, errorToString)

            'INFO
            Dim OSBit As String
            If Environment.Is64BitOperatingSystem = True Then
                OSBit = " 64-Bit"
            Else
                OSBit = " 32-Bit"
            End If

            Dim LogError As String
            LogError = "Date and Time: " & DateTime.Now.ToString("dd. MMMM yyyy HH:mm:ss") & vbNewLine & _
                        "Domain: " & Environment.UserDomainName & vbNewLine & _
                        "Username: " & Environment.UserName & vbNewLine & _
                        "Computername: " & Environment.MachineName & vbNewLine & _
                        "Windows: " & My.Computer.Info.OSFullName & OSBit & " (" & My.Computer.Info.OSVersion & ")" & vbNewLine & vbNewLine & _
                        "Application Error Message: " & vbNewLine & errorMessage & vbNewLine & vbNewLine & _
                        "Detailed Application Error Message: " & vbNewLine & errorToString & vbNewLine



            IO.File.WriteAllText(rtechapp.logsFilePath & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".log", LogError)

        Catch ex As Exception

            IO.File.WriteAllText(rtechapp.logsFilePath & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".log", "LOG PROBLEMS:" & vbNewLine & ex.Message _
                                 & vbNewLine & vbNewLine & ex.ToString)

            rtechapp.ApplicationRestart()

        End Try


        ''EMAIL STUFF
        'Dim HTMLError As String
        'HTMLError = "" & vbNewLine & _
        '            "<b>Date and Time:</b> " & DateTime.Now.ToString("dd. MMMM yyyy HH:mm:ss") & "<br>" & _
        '            "<b>Domain:</b> " & Environment.UserDomainName & "<br>" & _
        '            "<b>Username:</b> " & Environment.UserName & "<br>" & _
        '            "<b>Computername:</b> " & Environment.MachineName & "<br>" & _
        '            "<b>Windows:</b> " & My.Computer.Info.OSFullName & OSBit & " (" & My.Computer.Info.OSVersion & ")" & "<br><br>" & _
        '            "<b>Application Error Message:</b> " & "<br>" & errorMessage & "<br><br>" & _
        '            "<b>Detailed Application Error Message:</b> " & "<br>" & errorToString & "<br>"
        'Dim mail As New MailMessage()
        'Dim HTMLHead As String = "<html><head><style>body{font-family:arial,verdana,sans-serif;font-size:12px;}</style></head><body>"
        'Dim HTMLFoot As String = "</body></html>"
        'Dim smtp As New SmtpClient("smtp.gmail.com")
        'mail.To.Add("daniel@retardedtech.com") 'set the addresses
        'mail.Subject = rtechapp.ProductName & " Debug Email" 'set the content
        'mail.Body = HTMLHead & HTMLError & HTMLFoot
        'mail.IsBodyHtml = True
        'smtp.Port = 587
        'smtp.EnableSsl = True
        'smtp.Credentials = New Net.NetworkCredential("intility@gmail.com", "71gradernord")

        'Try

        '    'fSettings.lblErrorLogs.Text = "Error Logs: " & My.Computer.FileSystem.GetFiles(rtechapp.logsFilePath).Count

        '    If sendEmail = True Then
        '        smtp.Send(mail)
        '        'MsgBox("Email was sent successfully!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, Application.ProductName)
        '    End If

        'Catch ex As Exception

        '    IO.File.WriteAllText(rtechapp.logsFilePath & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".log", "EMAIL PROBLEMS:" & vbNewLine & ex.Message _
        '                         & vbNewLine & vbNewLine & ex.ToString)

        '    rtechapp.ApplicationRestart()

        'End Try

    End Sub
End Class
