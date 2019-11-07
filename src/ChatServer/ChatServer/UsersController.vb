Imports System.Net.Sockets
Class UsersController
    Private _usersList As New List(Of Users)
    Private _ClientsList As New List(Of TcpClient)

    Public Property ClientsList As List(Of TcpClient)
        Get
            Return _ClientsList
        End Get
        Set(value As List(Of TcpClient))
            _ClientsList = value
        End Set
    End Property

    Public Property UsersList As List(Of Users)
        Get
            Return _usersList
        End Get
        Set(ByVal value As List(Of Users))
            _usersList = value
        End Set
    End Property
    Public Sub addUser(username As String)
        Dim Users As New Users
        Users.Username = username
        _usersList.Add(Users)
    End Sub
    Public Sub AddClient()

    End Sub
End Class
