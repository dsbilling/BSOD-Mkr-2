Public Class keyboardblocker
    Declare Function BlockInput Lib "user32" (ByVal fBlock As Boolean) As Integer
    Private Sub keyboardblocker_FormClosing(sender As Object, e As Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        BlockInput(False)
        Cursor.Show()
    End Sub

    Private Sub keyboardblocker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Hide()
        BlockInput(True)
    End Sub
End Class