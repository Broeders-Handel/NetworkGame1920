Imports System.Net.Sockets
Imports System.IO
Class UsersController
    Private _Users As New Dictionary(Of String, User)
    Dim usr As User

    Public Property Users As Dictionary(Of String, User)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of String, User))
            _Users = value
        End Set
    End Property
    Public Sub RemoveUser(Username As String)
        _Users.Remove(Username)
    End Sub
    Public Function addUser(user As User) As Boolean
        Try
            If Users.ContainsKey(user.Username) Then
                Return False
            End If
            _Users.Add(user.Username, user)
            'UsersString = ""
            'For i As Integer = 0 To Users.Count - 1
            '    UsersString &= Users.Keys(i) & ","
            'Next
            'For Each usr In Users.Values
            '    usr.write(UsersString, Server.COM_COMMAND.CONNECTEDUSERS)
            'Next
            'UsersString = ""
            Return True
        Catch ex As Exception
            '            MessageBox.Show("User disconnected")
            Console.WriteLine("User disconnected")
        End Try
        Return False
    End Function

    Friend Function getUsers() As String
        Throw New NotImplementedException()
    End Function
End Class
