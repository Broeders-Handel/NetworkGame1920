Imports System.Net.Sockets
Class UsersController
    Private _usernameList As New List(Of Username)
    Private _ClientsList As New List(Of Socket)
    Private _Users As New Dictionary(Of Username, Socket)

    Public Property Users As Dictionary(Of Username, Socket)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of Username, Socket))
            _Users = value
        End Set
    End Property

    Public Property ClientsList As List(Of Socket)
        Get
            'kopie
            Return _ClientsList
        End Get
        Set(value As List(Of Socket))
            _ClientsList = value
        End Set
    End Property

    Public Property UsersListname As List(Of Username)
        Get
            Return _usernameList
        End Get
        Set(ByVal value As List(Of Username))
            _usernameList = value
        End Set
    End Property
    Public Sub addUsername(username As String)
        Dim Users As New Username
        Users.Username = username
        _usernameList.Add(Users)
    End Sub
    Public Sub AddClient(Client)
        'KOPIE NEMEN (kopie gemaakt)
        Dim KopieClient As Socket = Client
        ClientsList.Add(KopieClient)
    End Sub
    Public Sub addUser(client As Socket, username As Username)
        Dim KopieClient As Socket = client
        Dim KopieUsername As Username = username
        Users.Add(KopieUsername, KopieClient)
    End Sub
End Class
