﻿Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class Server
    Dim TCPServer As Socket
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim UsersController As New UsersController
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim rcvbytes(TCPServer.ReceiveBufferSize) As Byte
            TCPServer.Receive(rcvbytes)
            If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
                Dim username As String = System.Text.Encoding.ASCII.GetString(rcvbytes)
                UsersController.addUser(username.Substring(2))
            Else
                ChatRichTextBox.Text &= System.Text.Encoding.ASCII.GetString(rcvbytes)
                ChatRichTextBox.Text &= Environment.NewLine
                MessageTextBox.Text = System.Text.Encoding.ASCII.GetString(rcvbytes)
                SendToClient(MessageTextBox.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SendToClient(Message As String)
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(MessageTextBox.Text)
        TCPServer.Send(sendbytes)
        MessageTextBox.Clear()
    End Sub
    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                SendToClient(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        SendToClient(MessageTextBox.Text)
    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If serverStatus = False Then
            Try
                TCPListener = New TcpListener(IPAddress.Any, 64553)
                TCPListener.Start()
                TCPServer = TCPListener.AcceptSocket()
                TCPServer.Blocking = False
                Timer1.Enabled = True
                serverStatus = True
            Catch ex As Exception
                serverStatus = False
            End Try
        End If
        If serverStatus = True Then
            ChatRichTextBox.Text &= "<< NEW USER CONNECTED >>" & Environment.NewLine
        End If
    End Sub
End Class
