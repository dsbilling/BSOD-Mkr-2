Imports System.Drawing
Public Class coverscreens
    Private Sub coverscreens_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rtechlog.logThis("INFO", "CoverScreens is loaded.")

        Me.Location = New Point(System.Windows.SystemParameters.VirtualScreenLeft, System.Windows.SystemParameters.VirtualScreenTop)
        Me.Height = System.Windows.SystemParameters.VirtualScreenHeight
        Me.Width = System.Windows.SystemParameters.VirtualScreenWidth

    End Sub
    Private Sub coverscreens_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "CoverScreens is closing.")

    End Sub

    Private Sub coverscreens_MouseDoubleClick(sender As Object, e As Forms.MouseEventArgs) Handles MyBase.MouseDoubleClick
        rtechlog.logThis("INFO", "User closed CoverScreens manually.")
        Me.Close()
    End Sub
End Class