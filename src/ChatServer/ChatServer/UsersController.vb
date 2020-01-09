Imports System.Net.Sockets
Public Class UsersController
    Private Shared _Users As New Dictionary(Of String, Users)

    Public Shared Property Users As Dictionary(Of String, Users)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of String, Users))
            _Users = value
        End Set
    End Property
    Public Function addUser(username As String, client As TcpClient) As Users
        Dim user As New Users(username, client)
        _Users.Add(username, user)
        Return user
    End Function
End Class
