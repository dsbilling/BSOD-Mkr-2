Imports System.Drawing
Public Class coverscreens
    Private Sub coverscreens_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rtechlog.logThis("INFO", "Coverscreens is loaded.")

        Me.Location = New Point(System.Windows.SystemParameters.VirtualScreenLeft, System.Windows.SystemParameters.VirtualScreenTop)
        Me.Height = System.Windows.SystemParameters.VirtualScreenHeight
        Me.Width = System.Windows.SystemParameters.VirtualScreenWidth

    End Sub
    Private Sub coverscreens_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "Coverscreens is closing.")

    End Sub
End Class