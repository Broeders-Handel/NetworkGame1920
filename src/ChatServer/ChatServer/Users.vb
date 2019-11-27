Imports System.IO
Imports System.Net.Sockets
Public Class Users
    Private _username As String
    Private _client As TcpClient
    Dim Islistening As Boolean
    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property Client As TcpClient
        Get
            Return _client
        End Get
        Set(value As TcpClient)
            _client = value
        End Set
    End Property
    Public Sub write(message)
        Dim strWrit As StreamWriter = New StreamWriter(Client.GetStream)
        strWrit.Write(message)
    End Sub
    Public Event MessageRecieved(data As String)
    'bij het luisteren => gooi event wanneer iets ontvangen
    Public Sub Listening(rtb As RichTextBox)

        Dim ClientData As StreamReader
        Try
            Do Until Islistening = False
                ' If TCPListener.Pending = True Then
                ' Client = TCPListener.AcceptTcpClient
                ClientData = New StreamReader(_client.GetStream)
                UpdateText(rtb, ClientData.ReadLine)
                RaiseEvent MessageRecieved(ClientData.ReadLine)
                ' End If
            Loop
        Catch ex As Exception
        End Try
        'Sleep(100)

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
End Class
