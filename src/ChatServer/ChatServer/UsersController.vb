Imports System.Net.Sockets
Class UsersController
    Private _usersList As New List(Of Users)
    Private _ClientsList As New List(Of Socket)

    Public Property ClientsList As List(Of Socket)
        Get
            Return _ClientsList
        End Get
        Set(value As List(Of Socket))
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
    Public Sub AddClient(Client)
        ClientsList.Add(Client)
    End Sub
End Class
