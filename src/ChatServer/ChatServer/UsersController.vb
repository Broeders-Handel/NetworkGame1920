Imports System.Net.Sockets
Imports System.IO
Class UsersController
    Private _Users As New Dictionary(Of String, Users)
    Private _DuplicateUser As Users
    Public Property DuplicateUser As Users
        Get
            Return _DuplicateUser
        End Get
        Set(value As Users)
            _DuplicateUser = value
        End Set
    End Property


    Public Property Users As Dictionary(Of String, Users)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of String, Users))
            _Users = value
        End Set
    End Property
    Public Sub RemoveUser(Username As String)
        _Users.Remove(Username)
    End Sub
    Public Function addUser(username As String, client As TcpClient) As Users
        Dim user As Users
        user = New Users(username, client)
        Try
            _Users.Add(username, user)
        Catch ex As Exception
            MessageBox.Show("User disconnected")
        End Try
        Return user
    End Function
End Class
