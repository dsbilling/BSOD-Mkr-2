Public Class rtecherror
    Public Shared Sub reportError(errorMessage As String, errorToString As String)
        Try

            MBox.ShowErrorBox(errorMessage, errorToString)

        Catch ex As Exception

            rtechlog.logThis("ERROR", "LOG PROBLEMS:" & ex.Message & " - " & ex.ToString)

            rtechapp.ApplicationRestart()

        End Try

    End Sub
End Class
