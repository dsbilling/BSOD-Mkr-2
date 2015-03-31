Imports FirstFloor.ModernUI.Windows.Controls
Imports System.Text.RegularExpressions
Imports System.Security.Principal

Class basichome
    Private identity = WindowsIdentity.GetCurrent()
    Private principal = New WindowsPrincipal(identity)
    Private isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
    
    Private Sub btnGo_Click(sender As Object, e As RoutedEventArgs) Handles btnGo.Click

        If cbColor.SelectedIndex = -1 Then
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
            ElseIf tbBasicTime.Text > 119 Then
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
        cbColor.SelectedIndex = 0

        LoadSettings()

        If isElevated = False Then
            cbKeyboardBlocker.SelectedIndex = 1
            cbKeyboardBlocker.IsEnabled = False
        End If


    End Sub
    Private Sub MakeBSOD()
        Try
            SaveSettings()

            If CBool(rtechsettings.GetSetting("textmode")) = True Then

                rtechlog.logThis("INFO", "Starting to make BSOD in text mode.")

                pbLoading.Visibility = Windows.Visibility.Hidden
                pbDownload.Visibility = Windows.Visibility.Hidden

                lblTimeLeftText.Visibility = Windows.Visibility.Hidden
                lblTimeLeft.Visibility = Windows.Visibility.Hidden
                lblFileSizeText.Visibility = Windows.Visibility.Hidden
                lblFileSize.Visibility = Windows.Visibility.Hidden
                lblSpeedText.Visibility = Windows.Visibility.Hidden
                lblSpeed.Visibility = Windows.Visibility.Hidden

                lblElapsedTimeText.Visibility = Windows.Visibility.Hidden
                lblElapsedTime.Visibility = Windows.Visibility.Hidden

                pbDownload.Value = 0

                'MBox.ShowInfoOKBox("TEXT MODE")

                If cbKeyboardBlocker.SelectedIndex = 0 Then
                    Dim kb As New keyboardblocker
                    kb.Show()
                End If
                Dim ctime As New timer
                ctime.Show()
                Dim cscreens As New coverscreens
                cscreens.Show()
                Dim cbsod As New custombsod_w8
                cbsod.Show()

                rtechlog.logThis("INFO", "BSOD is showing.")

            Else
                Throw New NotImplementedException
                pbLoading.Visibility = Windows.Visibility.Visible
                pbDownload.Visibility = Windows.Visibility.Visible

                lblTimeLeftText.Visibility = Windows.Visibility.Visible
                lblTimeLeft.Visibility = Windows.Visibility.Visible
                lblFileSizeText.Visibility = Windows.Visibility.Visible
                lblFileSize.Visibility = Windows.Visibility.Visible
                lblSpeedText.Visibility = Windows.Visibility.Visible
                lblSpeed.Visibility = Windows.Visibility.Visible

                lblElapsedTimeText.Visibility = Windows.Visibility.Visible
                lblElapsedTime.Visibility = Windows.Visibility.Visible

                pbDownload.Value = 0

                MBox.ShowInfoOKBox("IMAGE MODE")
            End If
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub

    Public Sub LoadSettings()
        Try
            Me.tbBasicTime.Text = CInt(rtechsettings.GetSetting("basictime"))
            Me.cbColor.SelectedIndex = CInt(rtechsettings.GetSetting("basiccolor"))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Private Sub SaveSettings()
        Dim errorcount As Integer = 0
        Try
            rtechsettings.SaveSetting("basictime", Convert.ToInt16(tbBasicTime.Text.ToString))
            rtechsettings.SaveSetting("basiccolor", Convert.ToInt16(cbColor.SelectedIndex.ToString))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
            errorcount = 1
        End Try
    End Sub
End Class
