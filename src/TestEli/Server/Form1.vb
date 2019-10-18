Imports System.Net.Sockets
Imports System.ComponentModel
Imports System.Net
Imports System.IO

Public Class Form1
    Dim serverStatus As Boolean = False
    Dim serverTrying As Boolean = False
    Dim Server As TcpListener
    Dim Clients As New List(Of TcpClient)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        startserver()
    End Sub
    Function startserver()
        If serverStatus = False Then
            serverTrying = True
            Try
                Server = New TcpListener(IPAddress.Any, 64555)
                Server.Start()
                serverStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Catch ex As Exception
                serverStatus = False
            End Try
            serverTrying = False

        End If
        Return True
    End Function

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        stopserver()

    End Sub
    Function stopserver()
        If serverStatus = True Then
            serverTrying = True
            Try
                For Each client As TcpClient In Clients
                    client.Close()
                Next
                Server.Stop()
                serverStatus = False
            Catch ex As Exception
                stopserver()
            End Try
        End If
        Return True
    End Function
    Function Handler_Client(ByVal state As Object)
        Dim TempClient As TcpClient

        Try
            Using Client As TcpClient = Server.AcceptTcpClient

                If serverTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If
                Clients.Add(Client)
                TempClient = Client
                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                If RX.BaseStream.CanRead = True Then
                    While RX.BaseStream.CanRead = True
                        Dim RawData As String = RX.ReadLine
                        RichTextBox1.text += Client.Client.RemoteEndPoint.ToString + ">>" + RawData + Environment.NewLine
                    End While
                End If
                If RX.BaseStream.CanRead = False Then
                    Client.Close()
                    Clients.Remove(Client)
                End If
            End Using
            If TempClient.GetStream.CanRead = False Then
                TempClient.Close()
                Clients.Remove(TempClient)
            End If
        Catch ex As Exception
            If TempClient.GetStream.CanRead = False Then
                TempClient.Close()
                Clients.Remove(TempClient)
            End If
        End Try
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, TextBox1.Text)
    End Sub
    Function SendToClients(ByVal data As String)
        If serverStatus = True Then
            If Clients.Count > 0 Then
                Try
                    For Each client As TcpClient In Clients
                        Dim TX1 As New StreamWriter(client.GetStream)
                        TX1.writeline(data)
                        TX1.Flush()
                    Next
                Catch ex As Exception
                    SendToClients(data)
                End Try
            End If
        End If
        Return True
    End Function
End Class
