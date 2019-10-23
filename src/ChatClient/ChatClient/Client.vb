Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class Client
    Dim client As TcpClient
    Dim RX As StreamReader
    Dim TX As StreamWriter

    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Try
            client = New TcpClient("127.0.0.1", 64553)
            If client.GetStream.CanRead = True Then
                RX = New StreamReader(client.GetStream)
                TX = New StreamWriter(client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
                ConnectButton.Text = "Connected"
                ChatRichTextBox.Text = "<< Connected to server >>" & Environment.NewLine
            End If
        Catch ex As Exception
            ChatRichTextBox.Text += "Failed to connect , E: " + ex.Message + Environment.NewLine

        End Try
    End Sub
    Function Connected()
        If RX.BaseStream.CanRead = True Then
            Try
                While RX.BaseStream.CanRead = True
                    Dim RawData As String = RX.ReadLine
                    If RawData.ToUpper = "/MSG" Then
                        Threading.ThreadPool.QueueUserWorkItem(AddressOf MSG1, RawData)
                    Else
                        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToServer, RawData)
                    End If
                End While
            Catch ex As Exception
                client.Close()
            End Try
        End If
        Return True
    End Function
    Function MSG1(ByVal Data As String)
        MsgBox(Data)
        Return True
    End Function

    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                SendToServer(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Function SendToServer(ByVal data As String)
        Try
            TX.WriteLine(data)
            TX.Flush()
        Catch ex As Exception

        End Try
        Return True
    End Function
End Class

