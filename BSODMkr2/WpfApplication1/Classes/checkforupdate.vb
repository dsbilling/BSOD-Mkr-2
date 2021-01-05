Imports FirstFloor.ModernUI.Windows.Controls
Imports System.Windows.Threading
Imports System.Threading

Public Class checkforupdate
    Public Shared Sub C4Umsgbox()
        Try
            If My.Computer.Network.IsAvailable = False Then

                MBox.ShowKnownErrorBox("0001", "Can't connect to the internet!", "You need to be connected to the internet to use some features.")

            ElseIf My.Computer.Network.IsAvailable = True Then

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/DanielRTRD/bsod-mkr-2/main/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = My.Application.Info.Version.ToString

                If newestversion <= currentversion Then

                    Dim title As String = "Information"
                    Dim type As MessageBoxButton = MessageBoxButton.OK
                    Dim msg As String = "You have the newest version!"
                    Dim result = FirstFloor.ModernUI.Windows.Controls.ModernDialog.ShowMessage(msg, title, type)
                    If result = type Then
                        ' Do something
                    End If

                ElseIf newestversion > currentversion Then

                    Dim title As String = "Warning"
                    Dim type As MessageBoxButton = MessageBoxButton.YesNo
                    Dim msg As String = "[color=orange]Old version detected.[/color] Do you want to download the newer version?" & vbNewLine & vbNewLine _
                                        & "[b]Current:[/b] " & currentversion & vbNewLine & "[b]Newest:[/b] " & newestversion
                    Dim result = FirstFloor.ModernUI.Windows.Controls.ModernDialog.ShowMessage(msg, title, type)
                    If result = MessageBoxResult.Yes Then
                        Process.Start("https://github.com/DanielRTRD/bsod-mkr-2")
                    End If

                End If

            End If

        Catch ex As Exception
            MBox.ShowErrorBox(ex.Message, ex.StackTrace)
        End Try

    End Sub

    Public Shared Function C4UTextOutput()

        Dim C4Utext As String = ""

        Try

            If My.Computer.Network.IsAvailable = False Then

                C4Utext = "No internet connection."

            ElseIf My.Computer.Network.IsAvailable = True Then

                C4Utext = "Please wait..."

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/DanielRTRD/bsod-mkr-2/main/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = My.Application.Info.Version.ToString

                If newestversion <= currentversion Then
                    C4Utext = "You have the newest version."
                ElseIf newestversion > currentversion Then
                    C4Utext = "Old version detected. You should update!"
                End If

            End If
        Catch ex As Exception
            MBox.ShowErrorBox(ex.Message, ex.StackTrace)
        End Try

        Return C4Utext
    End Function
    Public Shared Function C4UColorOutput()

        Dim C4Ucolor As New SolidColorBrush(Windows.Media.Color.FromRgb(51, 51, 51))

        Try

            If My.Computer.Network.IsAvailable = False Then

                'C4Ucolor = New SolidColorBrush(Windows.Media.Color.FromRgb(0, 128, 0)) 'Green
                C4Ucolor = New SolidColorBrush(Windows.Media.Color.FromRgb(200, 0, 0)) 'Red

            ElseIf My.Computer.Network.IsAvailable = True Then

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/DanielRTRD/bsod-mkr-2/main/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = My.Application.Info.Version.ToString

                If newestversion <= currentversion Then
                    'nothing
                ElseIf newestversion > currentversion Then

                    C4Ucolor = New SolidColorBrush(Windows.Media.Color.FromRgb(255, 165, 0))

                End If

            End If
        Catch ex As Exception
            MBox.ShowErrorBox(ex.Message, ex.StackTrace)
        End Try

        Return C4Ucolor
    End Function
    Public Shared Function C4UBooleanOutput()

        Dim C4UBoolean As Boolean = False

        Try

            If My.Computer.Network.IsAvailable = False Then

                C4UBoolean = False

            ElseIf My.Computer.Network.IsAvailable = True Then

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/DanielRTRD/bsod-mkr-2/main/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = reader.ReadToEnd()
                Dim currentversion As String = My.Application.Info.Version.ToString

                If newestversion <= currentversion Then

                    C4UBoolean = False

                ElseIf newestversion > currentversion Then

                    C4UBoolean = True

                End If

            End If
        Catch ex As Exception
            MBox.ShowErrorBox(ex.Message, ex.StackTrace)
        End Try

        Return C4UBoolean
    End Function
End Class
