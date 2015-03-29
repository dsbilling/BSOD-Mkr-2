Public Class introduction

    Private Sub introduction_Initialized(sender As Object, e As EventArgs) Handles MyBase.Initialized, MyBase.Initialized

        'MsgBox(System.Reflection.Assembly.GetExecutingAssembly().Location)

        lblVersion.Text = rtechapp.longVersion

    End Sub

    Private Sub introduction_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded, MyBase.Loaded
        Try
            If CBool(rtechsettings.GetSetting("updatestartup")) = True Then
                lblStatus.Text = checkforupdate.C4UTextOutput()
                lblStatus.Foreground = checkforupdate.C4UColorOutput()
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
        Try
            If IO.File.Exists(rtechapp.tempFilePath & "newversion.zip") Then
                IO.File.Delete(rtechapp.tempFilePath & "newversion.zip")
            End If
            If IO.File.Exists(rtechapp.tempFilePath & "app.txt") Then
                IO.File.Delete(rtechapp.tempFilePath & "app.txt")
            End If
            If IO.Directory.Exists(rtechapp.tempFilePath) Then
                IO.Directory.Delete(rtechapp.tempFilePath)
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
End Class
