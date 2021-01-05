Class about

    Private Sub lblAboutVersion_Initialized(sender As Object, e As EventArgs) Handles lblAboutVersion.Initialized
        lblAboutVersion.Text = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." _
                & My.Application.Info.Version.Build.ToString & " Build " & My.Application.Info.Version.Revision.ToString
    End Sub
    Private Sub btnExeption_Click(sender As Object, e As RoutedEventArgs) Handles btnExeption.Click
        Try
            Throw New NotImplementedException
        Catch ex As Exception
            rtecherror.reportError(ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnKnownExeption_Click(sender As Object, e As RoutedEventArgs) Handles btnKnownExeption.Click
        MBox.ShowKnownErrorBox("9999", "Luke.", "I am your father.")
    End Sub

    Private Sub Page_Initialized_1(sender As Object, e As EventArgs)
        Try
            If CBool(rtechsettings.GetSetting("debug")) = False Then
                btnExeption.Visibility = Windows.Visibility.Hidden
                btnKnownExeption.Visibility = Windows.Visibility.Hidden
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
End Class
