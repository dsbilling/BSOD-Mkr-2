Class advhome
    Private Sub lblResolution_Loaded(sender As Object, e As RoutedEventArgs) Handles lblResolution.Loaded
        lblResolution.Text = SystemParameters.PrimaryScreenWidth & "x" & SystemParameters.PrimaryScreenHeight & _
            " (" & SystemParameters.VirtualScreenWidth & "x" & SystemParameters.VirtualScreenHeight & " - " _
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

        cbKeyboardBlocker.SelectedIndex = 0
        cbColor.SelectedIndex = 0
    End Sub
End Class
