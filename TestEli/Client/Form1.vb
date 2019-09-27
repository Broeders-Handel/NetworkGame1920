Imports System.ComponentModel
Public Class Form1
    Private Client As TCPControl
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Client = New TCPControl("10.0.9.105", 64555)
        If Client.Client.Connected Then ConnectButton.Text = "Connected"
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        SendMessage()
        MessageTextBox.Clear()
        MessageTextBox.Focus()
    End Sub
    Private Sub SendMessage()
        If Client.Client.Connected = True Then
            Client.Send(MessageTextBox.Text)
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then SendMessage()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Client.Client.Connected = True Then
            Client.DataStream.Close()
            Client.Client.Close()
        End If
    End Sub
End Class

