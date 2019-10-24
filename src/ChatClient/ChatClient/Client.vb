﻿Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class Client
    Dim TCPClient As TcpClient
    Dim TCPClientStream As NetworkStream
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TCPClientStream.DataAvailable = True Then
            Dim rcvbytes(TCPClient.ReceiveBufferSize) As Byte
            TCPClientStream.Read(rcvbytes, 0, CInt(TCPClient.ReceiveBufferSize))
            ChatRichTextBox.Text &= TCPClient.Client.RemoteEndPoint.ToString & " => " & System.Text.Encoding.ASCII.GetString(rcvbytes)
            ChatRichTextBox.Text &= Environment.NewLine
        End If
    End Sub
    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                SendToServer(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendToServer(Message As String)
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
        TCPClient.Client.Send(sendbytes)
        MessageTextBox.Clear()
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        SendToServer(MessageTextBox.Text)
    End Sub

    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        TCPClient = New TcpClient("127.0.0.1", 64553)
        Timer1.Enabled = True
        TCPClientStream = TCPClient.GetStream()
        ConnectButton.Text = "Connected"
        ChatRichTextBox.Text = "<< Connected to server >>" & Environment.NewLine
    End Sub
End Class

