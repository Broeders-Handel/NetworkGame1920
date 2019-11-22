Imports System.Net.Sockets
Imports System.Net
Imports System.Threading.Thread

Public Class Server
    Dim ThreadConnectClient As Threading.Thread
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim StopServer As Boolean = False
    Dim UsersController As New UsersController
    Dim usernameString As String = ""
    Dim username As String
    Dim isBusy As Boolean = False
    Private Sub ConnectClient()
        TCPListener = New TcpListener(IPAddress.Any, 64553)
        TCPListener.Start()
        Timer1.Start()

        Do Until StopServer = True
            Try
                Dim TCPClient As Socket
                TCPClient = TCPListener.AcceptSocket()
                TCPClient.Blocking = False
                Timer1.Enabled = True
                serverStatus = True
                Dim rcvbytes(TCPClient.ReceiveBufferSize) As Byte
                If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
                    usernameString = System.Text.Encoding.ASCII.GetString(rcvbytes)
                    usernameString = usernameString.Substring(2)
                End If
                username = usernameString
                isBusy = False

                Dim user As New Users
                user.Client = TCPClient
                user.Username = usernameString
                UsersController.addUser(username, user)

                'start thread die luistert naar specifieke client

            Catch ex As Exception
                serverStatus = False
                isBusy = False
            End Try
        Loop
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Try
            For Each usr As Users In UsersController.Users.Values
                Dim userName As String = usr.Username


                Dim rcvbytes(usr.Client.ReceiveBufferSize) As Byte
                usr.Client.Receive(rcvbytes)
                If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
                Else
                    Dim message As String = userName & ": " & System.Text.Encoding.ASCII.GetString(rcvbytes)

                    SendToClient(message)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SendToClient(Message As String)
        ChatRichTextBox.Text &= Message & Environment.NewLine

        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
        For Each usr As Users In UsersController.Users.Values
            usr.write(sendbytes)
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
        ThreadConnectClient = New Threading.Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()
        Do While isBusy = True
            Sleep(10000)

        Loop

        If serverStatus = True Then
            ChatRichTextBox.Text &= "<< NEW USER CONNECTED >>" & Environment.NewLine
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
    End Sub
End Class
