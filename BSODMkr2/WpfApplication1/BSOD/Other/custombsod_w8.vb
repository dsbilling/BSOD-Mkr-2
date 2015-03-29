﻿Imports System.Drawing
Imports System.Windows.Forms

Public Class custombsod_w8
    Private Sub custombsod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Dim CalcFontSizeA As Integer = Math.Min(232, CType(Math.Round(Me.custombsodtext.Height * 0.09, 0), Integer))
        'Dim CalcFontSizeB As Integer = Math.Min(232, CType(Math.Round(Me.custombsodtext.Width * 0.05, 0), Integer))
        'Dim FinalFontSize As Integer = Math.Min(CalcFontSizeA, CalcFontSizeB)

        Dim SmileFinalFontSize As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / System.Windows.SystemParameters.PrimaryScreenHeight * 85
        lblSmile.Font = New Font(lblSmile.Font.Name, SmileFinalFontSize, lblSmile.Font.Style)

        Dim SmileTopPoint As Integer = System.Windows.SystemParameters.PrimaryScreenHeight / 6
        Dim SmileLeftPoint As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / 6 - 30
        lblSmile.Location = New Point(SmileLeftPoint, SmileTopPoint)

        Dim MainFinalFontSize As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / System.Windows.SystemParameters.PrimaryScreenHeight * 18
        lblMain.Font = New Font(lblMain.Font.Name, MainFinalFontSize, lblMain.Font.Style)

        Dim MainTopPoint As Integer = SmileTopPoint + lblSmile.Height + 15
        Dim MainLeftPoint As Integer = SmileLeftPoint + 30
        lblMain.AutoSize = False
        lblMain.Width = System.Windows.SystemParameters.PrimaryScreenWidth - (MainLeftPoint * 2)
        lblMain.Height = MainFinalFontSize * 6
        lblMain.Location = New Point(MainLeftPoint, MainTopPoint)

        Dim SubMainFinalFontSize As Integer = System.Windows.SystemParameters.PrimaryScreenWidth / System.Windows.SystemParameters.PrimaryScreenHeight * 9
        lblSubMain.Font = New Font(lblMain.Font.Name, SubMainFinalFontSize, lblSubMain.Font.Style)

        Dim SubMainTopPoint As Integer = MainTopPoint + lblMain.Height + 75
        Dim SubMainLeftPoint As Integer = SmileLeftPoint + 30
        lblSubMain.Location = New Point(SubMainLeftPoint, SubMainTopPoint)

        If CInt(rtechsettings.GetSetting("basiccolor")) = 0 Then
            Me.BackColor = Color.FromArgb(31, 103, 179) 'W8 BSOD Blue
        ElseIf CInt(rtechsettings.GetSetting("basiccolor")) = 1 Then
            Me.BackColor = Color.FromArgb(0, 0, 0) 'Black
        Else
            Throw New NotImplementedException
        End If

        Me.Location = New Point(0, 0)
        Me.Height = System.Windows.SystemParameters.PrimaryScreenHeight
        Me.Width = System.Windows.SystemParameters.PrimaryScreenWidth

    End Sub
End Class