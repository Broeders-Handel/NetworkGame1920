﻿Imports System.Net.Sockets


Public Class TcpControllerServer
    Private _TCPClient As New TcpClient

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

            Return _TCPClient.GetStream
        End Get
    End Property
End Class
