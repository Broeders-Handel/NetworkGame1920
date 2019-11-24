Imports System.Net.Sockets
Imports System.Net
Imports System.Threading.Thread
Imports System.IO
Imports System.Threading

Public Class Server
    Dim ThreadConnectClient As Thread
    Dim Islistening As Boolean
    Dim ListenThread As Thread
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim StopServer As Boolean = False
    Dim Client As New TcpClient
    Dim UsersController As New UsersController
    Dim usernameString As String = ""
    Dim username As String
    Dim tcpClientStream As NetworkStream
    Dim isBusy As Boolean = False
    Dim cc As New TcpControllerServer
    Public Event MessageRecieved(data As String)

    Private Sub ConnectClient()
        TCPListener = New TcpListener(IPAddress.Any, 64553)
        TCPListener.Start()


        Do Until StopServer = True
            Try
                Dim TCPClient As Socket
                TCPClient = TCPListener.AcceptSocket()
                TCPClient.Blocking = False

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

                ListenThread.Start()
                'start thread die luistert naar specifieke client
            Catch ex As Exception
                serverStatus = False
                isBusy = False
            End Try
        Loop
    End Sub
    Private Sub Listening()

        Dim ClientData As StreamReader
        Try
            Do Until Islistening = False
                If TCPListener.Pending = True Then
                    Client = TCPListener.AcceptTcpClient
                    ClientData = New StreamReader(tcpClientStream)
                    RaiseEvent MessageRecieved(ClientData.ReadLine)
                End If
            Loop
        Catch ex As Exception
        End Try
        Sleep(100)

    End Sub



    Public Sub SendToClient(Message As String)

        ChatRichTextBox.Text &= Message & Environment.NewLine
        Try

            tcpClientStream = Client.GetStream
            Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
            For Each usr As Users In UsersController.Users.Values
                Dim userName As String = usr.Username
                If tcpClientStream.DataAvailable = True Then
                    Dim rcvbytes(usr.Client.ReceiveBufferSize) As Byte
                    tcpClientStream.Read(rcvbytes, 0, CInt(cc.TCPClient.ReceiveBufferSize))

                    If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
                    Else

                        Message = userName & ": " & System.Text.Encoding.ASCII.GetString(rcvbytes)
                        usr.write(Message)
                        SendToClient(Message)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
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
        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        ListenThread = New Thread(AddressOf Listening)
        isBusy = True

        ThreadConnectClient.Start()
        Do While isBusy = True
            Sleep(100)

        Loop

        If serverStatus = True Then
            ChatRichTextBox.Text &= "<< NEW USER CONNECTED >>" & Environment.NewLine
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
    End Sub
End Class
