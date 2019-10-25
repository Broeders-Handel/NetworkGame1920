Public Class UsersController
    Private _usersList As New List(Of Users)

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
        Users.username = username
        _usersList.Add(Users)
    End Sub
End Class
