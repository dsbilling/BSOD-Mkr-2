Public Class timer
    Dim secs As Integer = 0
    Dim usersecs As Integer = 0
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Const KEYEVENTF_KEYUP As Long = &H2
    Private Sub coverscreens_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tTimer.Start()
        usersecs = CInt(rtechsettings.GetSetting("basictime"))
        Call keybd_event(System.Windows.Forms.Keys.VolumeDown, 0, 0, 0) 'make sure the sound is on before muting
        Call keybd_event(System.Windows.Forms.Keys.VolumeMute, 0, 0, 0) 'mute
        Cursor.Hide()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tTimer.Tick
        secs = secs + 1
        lblTimer.Text = secs
        If secs = usersecs Then
            Cursor.Show()
            Call keybd_event(System.Windows.Forms.Keys.VolumeMute, 0, 0, 0) 'unmute
            Call keybd_event(System.Windows.Forms.Keys.VolumeUp, 0, 0, 0) 'make sure the sound is turned back to original level
            If CBool(rtechsettings.GetSetting("autorestartafterbsod")) = True Then
                rtechapp.ApplicationRestart()
            End If
        End If
    End Sub

    Private Sub lblTimer_TextChanged(sender As Object, e As EventArgs) Handles lblTimer.TextChanged
        Try
            Me.lblTimer.Left = Me.ClientSize.Width \ 2 - Me.lblTimer.Width \ 2
        Catch ex As Exception
            'YOLO
        End Try
    End Sub

End Class