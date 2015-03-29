Class fsettings

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        SaveSettings()
    End Sub

    Public Sub LoadSettings()
        Try
            Me.cbDebug.IsChecked = CBool(rtechsettings.GetSetting("debug"))
            Me.cbStartup.IsChecked = CBool(rtechsettings.GetSetting("updatestartup"))
            Me.cbTextMode.IsChecked = CBool(rtechsettings.GetSetting("textmode"))
            Me.cbAutoRestartAfterBSOD.IsChecked = CBool(rtechsettings.GetSetting("autorestartafterbsod"))
            If Me.cbDebug.IsChecked Then
                Me.cbDebug.Visibility = Windows.Visibility.Visible
            Else
                Me.cbDebug.Visibility = Windows.Visibility.Hidden
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Private Sub SaveSettings()
        Dim errorcount As Integer = 0
        Try
            rtechsettings.SaveSetting("debug", Convert.ToInt16(Convert.ToBoolean(cbDebug.IsChecked.ToString)))
            rtechsettings.SaveSetting("updatestartup", Convert.ToInt16(Convert.ToBoolean(cbStartup.IsChecked.ToString)))
            rtechsettings.SaveSetting("textmode", Convert.ToInt16(Convert.ToBoolean(cbTextMode.IsChecked.ToString)))
            rtechsettings.SaveSetting("autorestartafterbsod", Convert.ToInt16(Convert.ToBoolean(cbAutoRestartAfterBSOD.IsChecked.ToString)))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
            errorcount = 1
        Finally
            If errorcount = 0 Then
                MBox.ShowInfoOKBox("Settings has now been saved.")
            End If
        End Try
    End Sub

    Private Sub Page_Initialized(sender As Object, e As EventArgs)
        LoadSettings()
    End Sub
End Class
