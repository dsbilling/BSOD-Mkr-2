Imports System.Text.RegularExpressions
Imports FirstFloor.ModernUI.Windows.Controls

Class advhome

    Private Sub lblResolution_Loaded(sender As Object, e As RoutedEventArgs) Handles lblResolution.Loaded
        lblResolution.Text = SystemParameters.PrimaryScreenWidth & "x" & SystemParameters.PrimaryScreenHeight & _
            " (" & SystemParameters.VirtualScreenWidth & "x" & SystemParameters.VirtualScreenHeight & " - Count: " _
            & System.Windows.Forms.SystemInformation.MonitorCount & ")"

        For Each screen In System.Windows.Forms.Screen.AllScreens
            With ListBox1.Items
                .Add("Device Name: " + screen.DeviceName)
                .Add("Bounds: " + screen.Bounds.ToString())
                .Add("Type: " + screen.GetType().ToString())
                .Add("Working Area: " + screen.WorkingArea.ToString())
                .Add("Primary Screen: " + screen.Primary.ToString())
            End With
        Next

        lblStatusText.Visibility = Windows.Visibility.Visible
        lblStatus.Visibility = Windows.Visibility.Visible
        lblStatus.BBCode = "Ready."
        cbKeyboardBlocker.SelectedIndex = 0
        cbAdvColor.SelectedIndex = 0

        If My.Computer.Info.OSFullName.Contains("8") Or My.Computer.Info.OSFullName.Contains("10") Then
            cbAdvStyle.SelectedIndex = 1 'windows 8-10
        Else
            cbAdvStyle.SelectedIndex = 0 'windows xp-7
        End If

        LoadSettings()

        If rtechapp.isElevated = False Then
            cbKeyboardBlocker.SelectedIndex = 1
            cbKeyboardBlocker.IsEnabled = False
            lblStatus.BBCode = "Ready. [color=red]Not as admin.[/color]"
        End If

    End Sub

    Private Sub btnGo_Click(sender As Object, e As RoutedEventArgs) Handles btnGo.Click
        Try

            If cbAdvStyle.SelectedIndex = -1 Then
                MBox.ShowInfoOKBox("Style has not been selected.")
            End If

            If cbAdvColor.SelectedIndex = -1 Then
                MBox.ShowInfoOKBox("Color has not been selected.")
            End If

            If cbKeyboardBlocker.SelectedIndex = -1 Then
                MBox.ShowInfoOKBox("Keyboard Blocker has not been selected.")
            End If

            If Regex.IsMatch(tbAdvTime.Text, "^[0-9]+$") Then

                If tbAdvTime.Text = 0 Then
                    MBox.ShowInfoOKBox("Time can't be zero.")
                ElseIf tbAdvTime.Text < 6 Then
                    Dim result = ModernDialog.ShowMessage("Do you really want it to last that short?", "Info", MessageBoxButton.YesNo)
                    If result = MessageBoxResult.Yes Then
                        MakeBSOD()
                    End If
                ElseIf tbAdvTime.Text >= 120 Then
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

        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub

    Private Sub MakeBSOD()
        Try
            SaveSettings()

            rtechlog.logThis("INFO", "Starting to make BSOD in advanced mode.")

            If cbKeyboardBlocker.SelectedIndex = 0 Then
                Dim kb As New keyboardblocker
                kb.Show()
            End If

            Dim ctime As New timer
            ctime.Show()

            Dim cscreens As New coverscreens
            cscreens.Show()

            If cbAdvStyle.SelectedIndex = 0 Then 'windows xp-7
                Dim cbsod As New custombsod_xpw7
                cbsod.Show()
            ElseIf cbAdvStyle.SelectedIndex = 1 Then 'windows 8-10
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
            Me.tbAdvTime.Text = CInt(rtechsettings.GetSetting("advtime"))
            Me.cbAdvColor.SelectedIndex = CInt(rtechsettings.GetSetting("advcolor"))
            Me.cbAdvStyle.SelectedIndex = CInt(rtechsettings.GetSetting("advstyle"))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Private Sub SaveSettings()
        Try
            rtechsettings.SaveSetting("advtime", Convert.ToInt16(tbAdvTime.Text.ToString))
            rtechsettings.SaveSetting("advcolor", Convert.ToInt16(cbAdvColor.SelectedIndex.ToString))
            rtechsettings.SaveSetting("advstyle", Convert.ToInt16(cbAdvStyle.SelectedIndex.ToString))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
End Class
