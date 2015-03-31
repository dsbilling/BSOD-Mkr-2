Public Class keyboardblocker
    Declare Function BlockInput Lib "user32" (ByVal fBlock As Boolean) As Integer
    Private Sub keyboardblocker_FormClosing(sender As Object, e As Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        BlockInput(False)
        rtechlog.logThis("INFO", "Keyboardblocker is closing.")
    End Sub

    Private Sub keyboardblocker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtechlog.logThis("INFO", "Keyboardblocker is loaded.")
        BlockInput(True)
    End Sub
    Private Sub keyboardblocker_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "Keyboardblocker is closing.")

    End Sub
End Class