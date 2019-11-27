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
                Dim streamRdr As StreamReader
                Try
                    streamRdr = New StreamReader(TCPClient.GetStream)
                    Dim username As String = streamRdr.ReadLine
                    UpdateText(ChatRichTextBox, username)
                    'maak het user object aan
                    Dim u As New Users
                    u.Username = username
                    u.Client = TCPClient
                    UsersController.addUser(username, u)
                    u.Listening(ChatRichTextBox)
                    'voeg dit toe aan de lijst met huidige users

                    'zeg tegen het user object dat hij moet luisteren

                    'zorg dat events worden opgevangen in een 'schrijf naar textox en alle andere users' functie
                    'gebruik hiervoor delegate


                    ListenThread = New Thread(AddressOf u.Listening)
                    ListenThread.Start()


                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    'Console.WriteLine(ex.Message)
                End Try
                'serverStatus = True
                'Dim rcvbytes(TCPClient.ReceiveBufferSize) As Byte
                'If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
                '    usernameString = System.Text.Encoding.ASCII.GetString(rcvbytes)
                '    usernameString = usernameString.Substring(2)
                'End If
                'username = usernameString
                'isBusy = False

                'Dim user As New Users
                'user.Client = TCPClient
                'user.Username = usernameString
                'UsersController.addUser(username, user)

                'ListenThread.Start()
                'start thread die luistert naar specifieke client
            Catch ex As Exception
                serverStatus = False
                isBusy = False
            End Try
        Loop
    End Sub

    'moet in de user classe zitten
    '  Private Sub Listening()
    '
    'Dim C lientData As StreamReader
    'Try
    'Do Until Islistening = False
    ''           ' If TCPListener.Pending = True Then
    ' Client = TCPListener.AcceptTcpClient
    '         ClientData = New StreamReader(tcpClientStream)
    '        UpdateText(ChatRichTextBox, ClientData.ReadLine)
    'RaiseEvent MessageRecieved(ClientData.ReadLine)
    ' End If
    'Loop
    'Catch ex As Exception
    'End Try
    '   Sleep(100)

    'End Sub

    Public Sub SendToClient(message As String)
        Dim user As Users = Users.getinstance
        tcpClientStream = TCPClient.GetStream
        If tcpClientStream.CanWrite = True Then
            user.write(message)
        Else
            Throw New Exception("et werkt weer niet door kanker")
        End If
    End Sub

    '  Public Sub SendToClient(Message As String)

    '      ChatRichTextBox.Text &= Message & Environment.NewLine
    '  Try
    '
    '        tcpClientStream = TcpClient.GetStream
    'Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Message)
    'For Each usr As Users In UsersController.Users.Values
    ' Dim userName As String = usr.Username
    '           If tcpClientStream.DataAvailable = True Then
    '  Dim rcvbytes(usr.Client.ReceiveBufferSize) As Byte
    '                 tcpClientStream.Read(rcvbytes, 0, CInt(cc.TCPClient.ReceiveBufferSize))
    '
    ' If System.Text.Encoding.ASCII.GetString(rcvbytes) Like "//*" Then
    '  Else
    '''
    '                     Message = userName & ": " & System.Text.Encoding.ASCII.GetString(rcvbytes)
    '                    usr.write(Message)
    '                    SendToClient(Message)
    'end If
    ' End If
    '         Next
    ' Catch ex As Exception
    ' End Try
    '  End Sub
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
        '
        isBusy = True

        ThreadConnectClient.Start()
        'Do While isBusy = True
        '    Sleep(10)
        'Loop



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
