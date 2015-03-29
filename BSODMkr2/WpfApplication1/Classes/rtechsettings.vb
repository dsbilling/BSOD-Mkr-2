Public Class rtechsettings
    Public Shared Sub CreateSettingsFile()
        Try
            If System.IO.Directory.Exists(rtechapp.filesFolderPath) = False Then
                System.IO.Directory.CreateDirectory(rtechapp.filesFolderPath)
            End If
            If System.IO.File.Exists(rtechapp.settingsFilePath) = False Then
                System.IO.File.WriteAllText(rtechapp.settingsFilePath, rtechapp.defaultSettings)
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.StackTrace)
        End Try
    End Sub
    Public Shared Function GetSetting(ByVal Name As String) As String
        CreateSettingsFile()

        Dim setting_lines() As String = System.IO.File.ReadAllLines(rtechapp.settingsFilePath)

        For Each line As String In setting_lines
            Dim setting_name As String = line.GetSplit(0, "=")
            Dim setting_value As String = line.GetSplit(1, "=")

            If setting_name = Name Then
                Return setting_value
            End If
        Next

        Return ""
    End Function
    Public Shared Sub SaveSetting(ByVal Name As String, ByVal Value As String)
        Try
            CreateSettingsFile()

            Dim setting_lines() As String = System.IO.File.ReadAllLines(rtechapp.settingsFilePath)
            Dim save_lines As New List(Of String)

            For Each line As String In setting_lines
                Dim setting_name As String = line.GetSplit(0, "=")
                Dim setting_value As String = line.GetSplit(1, "=")

                If setting_name = Name Then
                    setting_value = Value
                End If

                save_lines.Add(setting_name & "=" & setting_value)
            Next

            System.IO.File.WriteAllLines(rtechapp.settingsFilePath, save_lines.ToArray())
        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.StackTrace)
        End Try
    End Sub
End Class
