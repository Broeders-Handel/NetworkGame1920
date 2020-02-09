﻿Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Public Class TCPClientController



    Private _TCPClient As TcpClient
    Private _username As String

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Public Property TCPClient() As TcpClient
        Get
            Return _TCPClient
        End Get
        Set(ByVal value As TcpClient)
            _TCPClient = value
        End Set
    End Property
    Public ReadOnly Property TCPClientStream() As NetworkStream
        Get
            Return TCPClient.GetStream()
        End Get

    End Property
    Public Sub DisconnectUser()
        TCPClient = New TcpClient()
    End Sub
    Public Function Connect(IpAdress As String) As Boolean
        Try
            TCPClient = New TcpClient(IpAdress, 64553)
            Write(Username, True)
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Public Sub Write(Message As String, Optional isUsername As Boolean = False)
        If isUsername Then
            Message = "//UN//" & Message
        Else
            Message = "//MS//" & Message
        End If
        Dim strWrit As StreamWriter = New StreamWriter(TCPClientStream)
        strWrit.WriteLine(Message)
        strWrit.Flush()
    End Sub
    'Public Function Read() As String

    '    Dim Output As String = ""
    '    If _TCPClientStream.DataAvailable = True Then
    '        Dim rcvbytes(_TCPClient.ReceiveBufferSize) As Byte
    '        _TCPClientStream.Read(rcvbytes, 0, CInt(_TCPClient.ReceiveBufferSize))
    '        Output &= _username & " => " & System.Text.Encoding.ASCII.GetString(rcvbytes) & NewLine()
    '    End If

    '    Return Output
    'End Function
End Class
