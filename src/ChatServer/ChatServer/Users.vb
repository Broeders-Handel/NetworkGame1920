Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Public Class Users
    Private Shared instance As Users
    Private _username As String
    Private _client As New TcpClient
    Dim Islistening As Boolean = True

    Public Sub New(username As String, client As TcpClient)
        Me.Username = username
        Me.Client = client
    End Sub

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
    Friend Sub write(message As String)
        Dim strWrit As StreamWriter
        Try
            'Dim users As Users = getinstance()
            strWrit = New StreamWriter(TCPClientStream)
            strWrit.WriteLine(message)
            strWrit.Flush()
        Catch ex As Exception
            Throw New Exception("bericht niet verzonden")
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
    Public Sub ListenAsync(rtb As RichTextBox)
        ListenThread = New Thread(AddressOf Listening)
        ListenThread.Start()
    End Sub
    Public Event MessageRecieved(username As String, data As String)
    'bij het luisteren => gooi event wanneer iets ontvangen
    Public Sub Listening(rtb As RichTextBox)
        Dim ClientData As StreamReader
        Do Until Islistening = False
            ClientData = New StreamReader(_client.GetStream)

            RaiseEvent MessageRecieved(Username, ClientData.ReadLine)
        Loop
    End Sub
End Class
