Imports System.Security.Principal

Class advhome

    Private identity = WindowsIdentity.GetCurrent()
    Private principal = New WindowsPrincipal(identity)
    Private isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

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

        If My.Computer.Info.OSFullName.Contains("8") Then
            cbAdvType.SelectedIndex = 1
        Else
            cbAdvType.SelectedIndex = 0
        End If

        LoadSettings()

        If isElevated = False Then
            cbKeyboardBlocker.SelectedIndex = 1
            cbKeyboardBlocker.IsEnabled = False
            lblStatus.BBCode = "Ready. Not as admin."
        End If

    End Sub

    Private Sub btnGo_Click(sender As Object, e As RoutedEventArgs) Handles btnGo.Click
        Try
            Throw New NotImplementedException
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub

    Public Sub LoadSettings()
        Try
            Me.tbAdvTime.Text = CInt(rtechsettings.GetSetting("advtime"))
            Me.cbAdvColor.SelectedIndex = CInt(rtechsettings.GetSetting("advcolor"))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
        End Try
    End Sub
    Private Sub SaveSettings()
        Dim errorcount As Integer = 0
        Try
            rtechsettings.SaveSetting("advtime", Convert.ToInt16(tbAdvTime.Text.ToString))
            rtechsettings.SaveSetting("advcolor", Convert.ToInt16(cbAdvColor.SelectedIndex.ToString))
        Catch ex As Exception
            rtecherror.reportError(ex.Message(), ex.StackTrace())
            errorcount = 1
        End Try
    End Sub
End Class
