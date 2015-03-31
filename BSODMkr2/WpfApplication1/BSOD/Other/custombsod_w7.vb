Imports System.Drawing

Public Class custombsod_w7
    Private Sub custombsod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rtechlog.logThis("INFO", "CustomW7TextBSOD is loaded.")

        'Dim CalcFontSizeA As Integer = Math.Min(232, CType(Math.Round(Me.custombsodtext.Height * 0.09, 0), Integer))
        'Dim CalcFontSizeB As Integer = Math.Min(232, CType(Math.Round(Me.custombsodtext.Width * 0.05, 0), Integer))
        'Dim FinalFontSize As Integer = Math.Min(CalcFontSizeA, CalcFontSizeB)

        Dim FinalFontSize As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / System.Windows.SystemParameters.PrimaryScreenHeight * 12
        custombsodtext.Font = New Font(custombsodtext.Font.Name, FinalFontSize, custombsodtext.Font.Style)

        custombsodtext.Text = My.Resources.custombsod.ToString

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
    Private Sub custombsod_w7_FormClosing(sender As System.Object, e As System.EventArgs) Handles MyBase.FormClosing

        rtechlog.logThis("INFO", "CustomW7TextBSOD is closing.")

    End Sub
End Class