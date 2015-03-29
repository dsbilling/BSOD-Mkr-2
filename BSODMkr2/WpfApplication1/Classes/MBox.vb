Imports FirstFloor.ModernUI.Windows.Controls

Public Class MBox
    Public Shared Sub ShowErrorBox(exMessage As String, exStacktrace As String)

        Dim message As String = "[b]Error Message:[/b]" & vbNewLine & "[color=orange]" & exMessage & "[/color]" & vbNewLine & vbNewLine _
                                & "[b]Error Details:[/b]" & vbNewLine & "[color=red]" & exStacktrace & "[/color]" & vbNewLine & vbNewLine _
                                & vbNewLine & "All errors like this should be reported to us. Do you want to copy this error to the clipboard and open the browser to report this error? Please paste this in the description field."

        'INFO
        Dim OSBit As String
        If Environment.Is64BitOperatingSystem = True Then
            OSBit = " 64-Bit"
        Else
            OSBit = " 32-Bit"
        End If
        Dim cleanmessage As String = "Error Message:" & vbNewLine & exMessage & vbNewLine _
                                    & vbNewLine & "Error Details:" & vbNewLine & exStacktrace & vbNewLine _
                                    & vbNewLine & "Version: " & rtechapp.longVersion _
                                    & vbNewLine & "Windows: " & My.Computer.Info.OSFullName & OSBit & " (" & My.Computer.Info.OSVersion & ")" _
                                    & vbNewLine & "Date and Time: " & DateTime.Now.ToString("dd. MMMM yyyy HH:mm:ss") & vbNewLine

        Dim result = ModernDialog.ShowMessage(message, "Fatal Error", MessageBoxButton.YesNo)

        If result = MessageBoxResult.Yes Then
            Clipboard.SetDataObject(cleanmessage.ToString, True)
            Process.Start("http://jira.rtrdt.ch/secure/CreateIssue!default.jspa?pid=10001")
        End If

    End Sub
    Public Shared Sub ShowKnownErrorBox(errorID As Integer, exMessage As String, exStacktrace As String)

        Dim message As String = "[b]Error ID:[/b]" & vbNewLine & errorID & vbNewLine & vbNewLine _
                                & "[b]Error Message:[/b]" & vbNewLine & "[color=orange]" & exMessage & "[/color]" & vbNewLine & vbNewLine _
                                & "[b]Error Details:[/b]" & vbNewLine & "[color=red]" & exStacktrace & " See documentation for more info.[/color]" & vbNewLine & vbNewLine _
                                & vbNewLine & "Do you want to know more about this error?"

        Dim result = ModernDialog.ShowMessage(message, "Error", MessageBoxButton.YesNo)

        If result = MessageBoxResult.Yes Then
            Process.Start("http://docs.rtrdt.ch/display/BM/Error+Messages")
        End If

    End Sub
    Public Shared Sub ShowInfoOKBox(msg As String)

        Dim result = ModernDialog.ShowMessage(msg, "Info", MessageBoxButton.OK)

        If result = MessageBoxResult.OK Then
            'Nothing
        End If

    End Sub
    Public Shared Sub ShowWarningOKBox(msg As String)

        Dim result = ModernDialog.ShowMessage(msg, "Warning", MessageBoxButton.OK)

        If result = MessageBoxResult.OK Then
            'Nothing
        End If

    End Sub
End Class
