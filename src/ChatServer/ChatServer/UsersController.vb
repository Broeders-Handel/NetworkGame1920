Imports System.Net.Sockets
Imports System.IO
Class UsersController
    Private _Users As New Dictionary(Of Users, String)
    Private _DuplicateUser As Users
    Public Property DuplicateUser As Users
        Get
            Return _DuplicateUser
        End Get
        Set(value As Users)
            _DuplicateUser = value
        End Set
    End Property


    Public Property Users As Dictionary(Of Users, String)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of Users, String))
            _Users = value
        End Set
    End Property
    Public Sub RemoveUser( user As Users)
        _Users.Remove(user)
    End Sub
    Public Function addUser(username As String, client As TcpClient) As Users
        Dim user As Users
        user = New Users(username, client)
        Try
            If _Users.ContainsValue(user.Username) Then
                DuplicateUser = user
                MessageBox.Show("Deze username is al in gebruik.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RemoveUser(DuplicateUser)
            Else
                _Users.Add(user, username)
            End If
        Catch ex As Exception
            MessageBox.Show("User disconnected")
        End Try
        Return user
    End Function
End Class
