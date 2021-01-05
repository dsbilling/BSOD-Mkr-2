Imports System.Drawing

Public Class custombsod_2000
    Private Sub custombsod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rtechlog.logThis("INFO", "CustomW2kTextBSOD is loaded.")

        Dim FinalFontSize As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / System.Windows.SystemParameters.PrimaryScreenHeight * 10
        custombsodtext.Font = New Font(custombsodtext.Font.Name, FinalFontSize, custombsodtext.Font.Style)

        custombsodtext.Text = My.Resources.custombsod_2000

        If CInt(rtechsettings.GetSetting("basiccolor")) = 0 Then
            Me.BackColor = Color.FromArgb(0, 0, 130) 'BSOD Blue
        ElseIf CInt(rtechsettings.GetSetting("basiccolor")) = 1 Then
            Me.BackColor = Color.FromArgb(0, 0, 0) 'Black
        Else
            Throw New NotImplementedException
        End If


        Me.Location = New Point(0, 0)
        Me.Height = System.Windows.SystemParameters.PrimaryScreenHeight
        Me.Width = System.Windows.SystemParameters.PrimaryScreenWidth
    End Sub
    Private Sub custombsod_w2k_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "CustomW2kTextBSOD is closing.")

    End Sub

    Private Sub custombsod_w2k_MouseDoubleClick(sender As Object, e As Forms.MouseEventArgs) Handles MyBase.MouseDoubleClick
        rtechlog.logThis("INFO", "User closed CustomW2kTextBSOD manually.")
        Me.Close()
    End Sub
End Class