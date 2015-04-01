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

        If My.Computer.Info.OSFullName.Contains("8") Or My.Computer.Info.OSFullName.Contains("10") Then
            cbBasicStyle.SelectedIndex = 1
        Else
            cbBasicStyle.SelectedIndex = 0
        End If

        LoadSettings()

        If isElevated = False Then
            cbKeyboardBlocker.SelectedIndex = 1
            cbKeyboardBlocker.IsEnabled = False
            lblStatus.BBCode = "Ready. Not as admin."
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

            If cbBasicStyle.SelectedIndex = 0 Then
                Dim cbsod As New custombsod_xpw7
                cbsod.Show()
            Else
                Dim cbsod As New custombsod_w8w10
                cbsod.Show()
            End If

            rtechlog.logThis("INFO", "BSOD is showing.")
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
