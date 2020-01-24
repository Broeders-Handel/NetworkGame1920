Imports System.Net.Sockets
Imports System.Net
Imports System.Threading.Thread
Imports System.IO
Imports System.Threading

Public Class Server

    Dim ThreadConnectClient As Thread
    Dim ThreadSendToClient As Thread
    Dim Islistening As Boolean
    Dim TCPListener As TcpListener
    Dim serverStatus As Boolean = False
    Dim StopServer As Boolean = False
    Dim UsersController As New UsersController
    Dim usernameString As String = ""
    Dim username As String
    Dim tcpClientStream As NetworkStream
    Dim isBusy As Boolean = False
    Dim cc As New TcpControllerServer

    Private Sub ClientConnected(client As TcpClient)

        Dim streamRdr As StreamReader
            Try
            streamRdr = New StreamReader(client.GetStream)
            Dim username As String = streamRdr.ReadLine
            UpdateText(ChatRichTextBox, username)

            'voeg client toe aan dictionairy
            Dim usr As Users = UsersController.addUser(username, client)
            'meld alle gebruikers van nieuwe client
            sendMessageAsServer("Client connected: " & username)
            'luister naar inkomende berichten
            usr.Listening(ChatRichTextBox)
            AddHandler usr.MessageRecieved, AddressOf IncomingMessage

        Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        'Catch ex As Exception
        '    serverStatus = False
        '    isBusy = False
        'End Try

    End Sub

    Private Sub ConnectClient()
        Do Until StopServer = True

            Dim TCPClient As TcpClient
            TCPClient = TCPListener.AcceptTcpClient()
            Dim ThreadClientConnected As Thread = New Thread(AddressOf ClientConnected)
            Dim parameter = New Object() {TCPClient}
            ThreadClientConnected.Start(parameter)

        Loop
    End Sub
    Public Sub IncomingMessage(username As String, data As String)
        Dim strWrit As StreamWriter
        Try
            'pas eigen textbox aan
            Dim message As String = username & ": " & data
            UpdateText(ChatRichTextBox, message)
            'stuur naar alle andere clients
            SendToClients(message)
        Catch ex As Exception
            Throw New Exception("bericht niet verzonden")
        End Try
    End Sub

    Public Sub SendToClients(message As String)

        For Each usr In UsersController.Users.Values
            usr.write(message)
        Next

    End Sub

    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                sendMessageAsServer(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        sendMessageAsServer(MessageTextBox.Text)
    End Sub

    Private Sub sendMessageAsServer(message As String)
        SendToClients("server => " & message)
    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim IPadress As String = IpAdressTextBox.Text
        serverStatus = True
        TCPListener = New TcpListener(IPAddress.Parse(IPadress), 64553)
        TCPListener.Start()

        ChatRichTextBox.Text &= "<< SERVER OPEN>>" & Environment.NewLine


        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()

    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
    End Sub
#Region "Textbox"

    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    'Update textbox
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})

        Else
            If txt IsNot Nothing Then
                RTB.AppendText(txt & Environment.NewLine)
            End If
        End If
    End Sub
#End Region
End Class
