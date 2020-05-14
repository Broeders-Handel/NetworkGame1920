Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Public Class User
    Private Shared instance As User
    Dim usercontroller As New UsersController
    Private _username As String
    Private _client As TcpClient
    Private _PrivateChatbox As Integer
    Dim Islistening As Boolean = True

    Public Sub New(username As String, client As TcpClient)
        Me.Username = username
        Me.Client = client
    End Sub
    Public Property PrivateChatroomId As Integer
        Get
            Return _PrivateChatbox
        End Get
        Set(value As Integer)
            _PrivateChatbox = value
        End Set
    End Property
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Private Property Client As TcpClient
        Get
            Return _client
        End Get
        Set(value As TcpClient)
            _client = value
        End Set
    End Property
    Public ReadOnly Property TCPClientStream() As NetworkStream
        Get
            Return Client.GetStream()
        End Get
    End Property
    Friend Sub write(message As String, commando As Server.COM_COMMAND)
        Dim strWrit As StreamWriter
        Try
            strWrit = New StreamWriter(TCPClientStream)
            strWrit.WriteLine(Server.fromCommToText(commando) & message)
            strWrit.Flush()
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Return " => " & Username
    End Function
    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
        Else
            If txt IsNot Nothing Then
                RTB.AppendText(txt & Environment.NewLine)
            End If
        End If
    End Sub
    Dim ListenThread As Thread
    Public Sub Listen()
        ListenThread = New Thread(AddressOf ListenThreadProc)
        ListenThread.Start()
    End Sub
    Public Sub stopListen()
        ListenThread.Abort()
    End Sub
    Public Event MessageRecieved(username As String, data As String)
    'bij het luisteren => gooi event wanneer iets ontvangen
    Public Sub ListenThreadProc()
        Try
            Dim ClientData As StreamReader
            Do Until Islistening = False
                ClientData = New StreamReader(_client.GetStream)
                Dim invoer As String = ClientData.ReadLine
                RaiseEvent MessageRecieved(Username, invoer)
            Loop

        Catch ex As Exception

        End Try
    End Sub
End Class
