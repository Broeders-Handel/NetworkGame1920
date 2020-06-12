Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom

    Dim UsersController As New UsersController
    Public Sub New(user1 As User, user2 As User)
        users = New List(Of User)
        users.Add(user1)
        users.Add(user2)
        latestID += 1
        ID = latestID
        user1.PrivateChatroomId = ID
        user2.PrivateChatroomId = ID
        'user1 is de user die de andere challenged dus die mag beginnen
        user1.Turn = True
    End Sub
    Property users As List(Of User)
    Private _id As Integer
    Property ID As Integer
        Get
            Return _id
        End Get
        Private Set(value As Integer)
            _id = value
        End Set
    End Property
    Private Shared latestID As Integer

    Public Sub Chat(message As String, sender As String)
        For Each usr In users
            usr.write(message, Server.COM_COMMAND.PRIVATEMESSAGES)
        Next
    End Sub

    Public Sub RecieveCoordinaat(message As String)

    End Sub

    Public Sub SendCoordinaat(Message As String, sender As String)
        For Each usr In users
            usr.write(Message, Server.COM_COMMAND.GAME)
        Next
    End Sub

    Public Function SetColor(usr As String) As Color
        If UsersController.Users(usr).Turn = True Then
            Return Color.Blue
        Else
            Return Color.Red
        End If

    End Function


    Public Sub SetZwaartekracht(Message As String)
        Dim Rij As String = Message.Substring(0, 1)
        Dim kolom As String = Message.Substring(2, 1)


    End Sub
End Class
