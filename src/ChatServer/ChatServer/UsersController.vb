Imports System.Net.Sockets
Class UsersController
    Private _Users As New Dictionary(Of String, Users)

    Public Property Users As Dictionary(Of String, Users)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of String, Users))
            _Users = value
        End Set
    End Property
    Public Function addUser(username As String, client As TcpClient) As Users
        Dim user As New Users(username, client)
        ' If _Users.ContainsValue(user.Username) Then
        '    MessageBox.Show("Deze username is al in gebruik.", "Error")
        ' Else
        _Users.Add(username, user)
            'End If
            Return user
    End Function
End Class
