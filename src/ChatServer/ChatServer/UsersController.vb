Imports System.Net.Sockets
Imports System.IO
Class UsersController
    Private _Users As New Dictionary(Of String, Users)
    Private _UsersString As String
    Dim usr As Users
    Public Property UsersString As String
        Get
            Return _UsersString
        End Get
        Set(value As String)
            _UsersString = value
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
        UsersString = "//USST//"
        For i As Integer = 0 To Users.Count - 1
            UsersString &= Users.Keys(i) & ","
        Next
        For Each usr In Users.Values
            usr.write(UsersString)
        Next
        UsersString = ""
    End Sub
    Public Function addUser(username As String, client As TcpClient) As Users
        Dim user As Users
        user = New Users(username, client)
        Try
            _Users.Add(username, user)
            UsersString = "//USST//"
            For i As Integer = 0 To Users.Count - 1
                UsersString &= Users.Keys(i) & ","
            Next
            For Each usr In Users.Values
                usr.write(UsersString)
            Next
            UsersString = ""
        Catch ex As Exception
            MessageBox.Show("User disconnected")
        End Try
        Return user
    End Function
End Class
