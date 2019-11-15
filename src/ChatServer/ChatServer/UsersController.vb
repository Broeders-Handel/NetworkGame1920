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
    Public Sub addUser(username As String, client As Users)
        Dim KopieClient As Users = client
        Dim KopieUsername As String = username
        Users.Add(KopieUsername, KopieClient)
    End Sub
End Class
