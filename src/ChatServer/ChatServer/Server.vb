Imports System.Net.Sockets
Imports System.Net
Imports System.Threading.Thread
Imports System.IO
Imports System.Threading

Public Class Server
    Dim ThreadConnectClient As Thread
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
    Dim TCPClient As TcpClient
    Private Sub ConnectClient()

        Do Until StopServer = True
            Try

                TCPClient = TCPListener.AcceptTcpClient()
                ThreadConnectClient = New Thread(AddressOf ConnectClient)
                ThreadConnectClient.Start()
                Dim streamRdr As StreamReader
                Try
                    streamRdr = New StreamReader(TCPClient.GetStream)
                    Dim username As String = streamRdr.ReadLine
                    UpdateText(ChatRichTextBox, username)
                    Me.username = username
                    'maak het user object aan
                    Dim usr As Users = UsersController.addUser(username, TCPClient)
                    usr.Listening(ChatRichTextBox)

                    AddHandler usr.MessageRecieved, AddressOf IncomingMessage

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Catch ex As Exception
                serverStatus = False
                isBusy = False
            End Try
        Loop
    End Sub
    Public Sub IncomingMessage(data As String)
        Dim strWrit As StreamWriter
        Try
            strWrit = New StreamWriter(TCPClient.GetStream)
            Write(data)
        Catch ex As Exception
            Throw New Exception("bericht niet verzonden")
        End Try
    End Sub

    Public Sub SendToClient(message As String)
        Dim user As Users = UsersController.Users(username)
        tcpClientStream = TCPClient.GetStream
        If tcpClientStream.CanWrite = True Then
            For Each usr In UsersController.Users
                user.write(message)
            Next

        Else
            Throw New Exception("et werkt weer niet hier")
        End If
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

        serverStatus = True

        TCPListener = New TcpListener(IPAddress.Any, 64553)
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
