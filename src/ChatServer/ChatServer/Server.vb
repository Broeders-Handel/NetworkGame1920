Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class Server
    Dim TCPServer As Socket
    Dim TCPListenerz As TcpListener
    Dim serverStatus As Boolean = False
    Dim clients As New List(Of TcpClient)
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            Dim rcvbytes(TCPServer.ReceiveBufferSize) As Byte
            TCPServer.Receive(rcvbytes)
            ChatRichTextBox.Text = System.Text.Encoding.ASCII.GetString(rcvbytes)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Dim sendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(MessageTextBox.Text)
        TCPServer.Send(sendbytes)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        TCPListenerz = New TcpListener(IPAddress.Any, 64553)
        TCPListenerz.Start()
        TCPServer = TCPListenerz.AcceptSocket()
        TCPServer.Blocking = False
        Timer1.Enabled = True
    End Sub
    Function SendToClients(ByVal data As String)
        If serverStatus = True Then
            If clients.Count > 0 Then
                Try
                    For Each client As TcpClient In clients
                        Dim TX1 As New StreamWriter(client.GetStream)
                        TX1.WriteLine(data)
                        TX1.Flush()
                    Next
                Catch ex As Exception
                    SendToClients(data)
                End Try
            End If
        End If
        Return True
    End Function
    '   Dim serverStatus As Boolean = False
    '  Dim serverTrying As Boolean = False
    ' Dim Server As TcpListener
    'Dim Clients As New List(Of TcpClient)
    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '     CheckForIllegalCrossThreadCalls = False
    ' End Sub
    'Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
    '   startserver()
    ' End Sub
    'Function startserver()
    'If serverStatus = False Then
    '       serverTrying = True
    'Try
    '           Server = New TcpListener(IPAddress.Any, 64553)
    '          Server.Start()
    '         ChatRichTextBox.Text = "<<Server started>>" & Environment.NewLine
    '        serverStatus = True
    '       Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
    'Catch ex As Exception
    '           serverStatus = False
    'End Try
    '       serverTrying = False
    '
    'End If
    'Return True
    'End Function

    'Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
    '   stopserver()

    'End Sub
    'Function stopserver()
    'If serverStatus = True Then
    ''       serverTrying = True
    'Try
    'For Each client As TcpClient In Clients
    '               client.Close()
    'Next
    '         Server.Stop()
    '          serverStatus = False
    '       Catch ex As Exception
    '     stopserver()
    '    End Try
    '    End If
    '   Return True
    'End Function
    'Function Handler_Client(ByVal state As Object)
    '   Dim TempClient As TcpClient

    '  Try
    '     Using Client As TcpClient = Server.AcceptTcpClient

    '        If serverTrying = False Then
    '           Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
    '      End If
    '     Clients.Add(Client)
    '    TempClient = Client
    '   Dim TX As New StreamWriter(Client.GetStream)
    '  Dim RX As New StreamReader(Client.GetStream)
    ' If RX.BaseStream.CanRead = True Then
    '    While RX.BaseStream.CanRead = True
    '       Dim RawData As String = RX.ReadLine
    '      ChatRichTextBox.Text += Client.Client.RemoteEndPoint.ToString + ">>" + RawData + Environment.NewLine
    ' End While
    ' End If
    'If RX.BaseStream.CanRead = False Then
    '   Client.Close()
    '  Clients.Remove(Client)
    'End If
    ' End Using
    'If TempClient.GetStream.CanRead = False Then
    '   TempClient.Close()
    '  Clients.Remove(TempClient)
    'End If
    'Catch ex As Exception
    '   If TempClient.GetStream.CanRead = False Then
    '      TempClient.Close()
    '     Clients.Remove(TempClient)
    'End If
    '   End Try
    '  Return True
    ' End Function

    'Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
    '   Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, MessageTextBox.Text)
    '  MessageTextBox.Clear()
    'End Sub
    '  Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
    '     If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '       If MessageTextBox.Text.Length > 0 Then
    '          SendToClients(MessageTextBox.Text)
    '         MessageTextBox.Clear()
    '    End If
    ' End If
    ' End Sub
    'Function SendToClients(ByVal data As String)

    '    If serverStatus = True Then
    '       If Clients.Count > 0 Then
    '           Try
    'For Each client As TcpClient In Clients
    'Dim TX1 As New StreamWriter(client.GetStream)
    '                   TX1.WriteLine(data)
    '                  TX1.Flush()
    '             Next
    '        Catch ex As Exception
    '           SendToClients(data)
    '      End Try
    ' End If
    '      End If
    '     Return True
    'End Function
End Class
