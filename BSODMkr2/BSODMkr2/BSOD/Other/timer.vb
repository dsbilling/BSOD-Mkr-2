Public Class timer
    Dim secs As Integer = 0
    Dim usersecs As Integer = 0
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Const KEYEVENTF_KEYUP As Long = &H2
    Private Sub timer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rtechlog.logThis("INFO", "Timer is loaded.")
        tTimer.Start()
        rtechlog.logThis("INFO", "Timer started.")
        usersecs = CInt(rtechsettings.GetSetting("basictime"))
        Call keybd_event(System.Windows.Forms.Keys.VolumeDown, 0, 0, 0) 'make sure the sound is on before muting
        Call keybd_event(System.Windows.Forms.Keys.VolumeMute, 0, 0, 0) 'mute
        rtechlog.logThis("INFO", "Sound is muted.")
        Cursor.Hide()
        rtechlog.logThis("INFO", "Cursor is hidden.")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tTimer.Tick
        secs = secs + 1
        lblTimer.Text = secs
        If secs = usersecs Then
            tTimer.Stop()
            rtechlog.logThis("INFO", "Timer is done.")
            Cursor.Show()
            rtechlog.logThis("INFO", "Cursor is shown.")
            Call keybd_event(System.Windows.Forms.Keys.VolumeMute, 0, 0, 0) 'unmute
            Call keybd_event(System.Windows.Forms.Keys.VolumeUp, 0, 0, 0) 'make sure the sound is turned back to original level
            rtechlog.logThis("INFO", "Sound is unmuted.")
            If CBool(rtechsettings.GetSetting("autorestartafterbsod")) = True Then
                rtechapp.ApplicationRestart()
            Else
                Me.Close()
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
    Private Sub timer_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "Timer is closing.")

    End Sub
End Class