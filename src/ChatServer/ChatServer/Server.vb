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

    Private Sub ClientConnected(clientObject As Object)
        Dim client As TcpClient = CType(clientObject(0), TcpClient)
        Dim streamRdr As StreamReader
        Try
            streamRdr = New StreamReader(client.GetStream)
            Dim username As String = streamRdr.ReadLine
            username = username.Substring(6)
            UpdateText(ChatRichTextBox, username)
            Dim User As New Users(username, client)
            'voeg client toe aan dictionairy
            If UsersController.Users.ContainsValue(username) Then
                MessageBox.Show("Deze username is al in gebruik")
                client = Nothing
            Else
                Dim usr As Users = UsersController.addUser(username, client)
                'meld alle gebruikers van nieuwe client
                sendMessageAsServer(username & " JOINED")
                'luister naar inkomende berichten
                AddHandler usr.MessageRecieved, AddressOf IncomingMessage
                usr.Listen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        Try
            'pas eigen textbox aan
            Dim message As String = username & ": " & data.Substring(6)
            UpdateText(ChatRichTextBox, message)
            'stuur naar alle andere clients
            SendToClients(message)
        Catch ex As Exception
            Throw New Exception("bericht niet verzonden")
        End Try
    End Sub

    Public Sub SendToClients(message As String)
        For Each usr In UsersController.Users.Keys
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
#Region "Buttons"
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim Ipadress As IPAddress
        serverStatus = True
        TCPListener = New TcpListener(IPAddress.Parse("192.168.0.150"), 64553)
        TCPListener.Start()
        ChatRichTextBox.Text &= "<< SERVER OPEN>>" & Environment.NewLine
        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()
        StartLocalButton.Enabled = False
    End Sub
    Private Sub StartLocalButton_Click(sender As Object, e As EventArgs) Handles StartLocalButton.Click
        TCPListener = New TcpListener(IPAddress.Loopback, 64553)
        TCPListener.Start()
        ChatRichTextBox.Text &= "<< SERVER OPEN>>" & Environment.NewLine
        ThreadConnectClient = New Thread(AddressOf ConnectClient)
        isBusy = True
        ThreadConnectClient.Start()
        StartButton.Enabled = False
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        StopServer = True
        StartLocalButton.Enabled = True
        StartButton.Enabled = True
    End Sub
#End Region
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
