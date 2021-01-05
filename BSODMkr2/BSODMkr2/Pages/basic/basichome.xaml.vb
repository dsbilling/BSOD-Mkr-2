Imports FirstFloor.ModernUI.Windows.Controls
Imports System.Text.RegularExpressions

Class basichome
    Private Sub btnGo_Click(sender As Object, e As RoutedEventArgs) Handles btnGo.Click

        If cbBasicStyle.SelectedIndex = -1 Then
            MBox.ShowInfoOKBox("Style has not been selected.")
        End If

        If cbBasicColor.SelectedIndex = -1 Then
            MBox.ShowInfoOKBox("Color has not been selected.")
        End If

        If cbKeyboardBlocker.SelectedIndex = -1 Then
            MBox.ShowInfoOKBox("Keyboard Blocker has not been selected.")
        End If

        If Regex.IsMatch(tbBasicTime.Text, "^[0-9]+$") Then

            If tbBasicTime.Text = 0 Then
                MBox.ShowInfoOKBox("Time can't be zero.")
            ElseIf tbBasicTime.Text < 6 Then
                Dim result = ModernDialog.ShowMessage("Do you really want it to last that short?", "Info", MessageBoxButton.YesNo)
                If result = MessageBoxResult.Yes Then
                    MakeBSOD()
                End If
            ElseIf tbBasicTime.Text >= 120 Then
                Dim result = ModernDialog.ShowMessage("Do you really want it to last that long?", "Info", MessageBoxButton.YesNo)
                If result = MessageBoxResult.Yes Then
                    MakeBSOD()
                End If
            Else
                MakeBSOD()
            End If

        Else
            MBox.ShowInfoOKBox("Time is not defined.")
        End If

    End Sub

    Private Sub lblResolution_Loaded(sender As Object, e As RoutedEventArgs) Handles lblResolution.Loaded
        lblResolution.Text = System.Windows.SystemParameters.PrimaryScreenWidth & "x" & System.Windows.SystemParameters.PrimaryScreenHeight & _
            " (" & System.Windows.SystemParameters.VirtualScreenWidth & "x" & System.Windows.SystemParameters.VirtualScreenHeight & ")"

    End Sub

    Private Sub Page_Initialized(sender As Object, e As EventArgs)

        lblStatusText.Visibility = Windows.Visibility.Visible
        lblStatus.Visibility = Windows.Visibility.Visible
        lblStatus.BBCode = "Ready."
        cbKeyboardBlocker.SelectedIndex = 0
        cbBasicColor.SelectedIndex = 0

        If My.Computer.Info.OSFullName.Contains("8") Or My.Computer.Info.OSFullName.Contains("10") Then
            cbBasicStyle.SelectedIndex = 1 'windows 8-10
        Else
            cbBasicStyle.SelectedIndex = 0 'windows xp-7
        End If

        LoadSettings()

        If rtechapp.isElevated = False Then
            cbKeyboardBlocker.SelectedIndex = 1
            cbKeyboardBlocker.IsEnabled = False
            lblStatus.BBCode = "Ready. [color=red]Not as admin.[/color]"
        End If

    End Sub
    Private Sub MakeBSOD()
        Try
            SaveSettings()

            rtechlog.logThis("INFO", "Starting to make BSOD in basic mode.")

            If cbKeyboardBlocker.SelectedIndex = 0 Then
                Dim kb As New keyboardblocker
                kb.Show()
            End If

            Dim ctime As New timer
            ctime.Show()

            Dim cscreens As New coverscreens
            cscreens.Show()

            If cbBasicStyle.SelectedIndex = 0 Then 'windows xp-7
                Dim cbsod As New custombsod_xpw7
                cbsod.Show()
            ElseIf cbBasicStyle.SelectedIndex = 1 Then 'windows 8-10
                Dim cbsod As New custombsod_w8w10
                cbsod.Show()
            Else
                Throw New NotImplementedException
            End If

            rtechlog.logThis("INFO", "BSOD is showing.")
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub

    Public Sub LoadSettings()
        Try
            Me.tbBasicTime.Text = CInt(rtechsettings.GetSetting("basictime"))
            Me.cbBasicColor.SelectedIndex = CInt(rtechsettings.GetSetting("basiccolor"))
            Me.cbBasicStyle.SelectedIndex = CInt(rtechsettings.GetSetting("basicstyle"))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Private Sub SaveSettings()
        Try
            rtechsettings.SaveSetting("basictime", Convert.ToInt16(tbBasicTime.Text.ToString))
            rtechsettings.SaveSetting("basiccolor", Convert.ToInt16(cbBasicColor.SelectedIndex.ToString))
            rtechsettings.SaveSetting("basicstyle", Convert.ToInt16(cbBasicStyle.SelectedIndex.ToString))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
End Class
