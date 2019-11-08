Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Threading.Thread

Public Class Server
    Dim ThreadConnectClient As System.Threading.Thread
    Dim TCPClient As Socket
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim StopServer As Boolean = False
    Dim UsersController As New UsersController


    Private Sub ConnectClient()
        Do Until StopServer = True
            Try
                TCPListener = New TcpListener(IPAddress.Any, 64553)
                TCPListener.Start()
                TcpClient = TCPListener.AcceptSocket()
                TCPClient.Blocking = False
                Timer1.Enabled = True
                serverStatus = True
                'isBusy=false
                UsersController.AddClient(TCPClient)
            Catch ex As Exception
                serverStatus = False
                'isBusy=false
            End Try
        Loop
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim rcvbytes(TCPClient.ReceiveBufferSize) As Byte
            TCPClient.Receive(rcvbytes)
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
        For i As Integer = 0 To UsersController.ClientsList.Count - 1
            UsersController.ClientsList(i).Send(sendbytes)
            MessageTextBox.Clear()
        Next
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
        ThreadConnectClient = New System.Threading.Thread(AddressOf ConnectClient)
        'isBusye=true
        ThreadConnectClient.Start()
        'while isBusy
        'sleep  ms

        If serverStatus = True Then
            ChatRichTextBox.Text &= "<< NEW USER CONNECTED >>" & Environment.NewLine
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
    End Sub
End Class
