Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom

    Public Sub New(user1 As User, user2 As User)
        users = New List(Of User)
        users.Add(user1)
        users.Add(user2)
        latestID += 1
        ID = latestID
        user1.PrivateChatroomId = ID
        user2.PrivateChatroomId = ID
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

    Public Sub RecieveCoordinaat(Rijkol As String)
        Dim rij As String = Rijkol.Substring(0, 1)
        Dim Kolom As String = Rijkol.Substring(1, 1)
        SetColor()
    End Sub

    Public Sub SendCoordinaat(Rijkol As String)
        Chat(Rijkol, Server.COM_COMMAND.GAME)
    End Sub
    Public Function SetColor() As Color
        Dim Colored As Boolean
        If Colored = True Then
            MessageBox.Show("Deze button is gebruikt!")
        Else
            Return Color.Blue
        End If
    End Function

End Class
