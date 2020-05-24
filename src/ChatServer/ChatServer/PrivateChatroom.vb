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

    Public Sub RecieveCoordinaat(rij As Integer, kolom As Integer)
        MessageBox.Show(rij & " " & kolom)
    End Sub

    Public Sub SendCoordinaat(rij As Integer, kolom As Integer, Color As Color)

    End Sub
    Public Function SetColor(Rij As Integer, kolom As Integer) As Color
        Dim Button As Button
        Dim Colored As Boolean
        If Colored = True Then
            MessageBox.Show("Deze button is gebruikt!")
        Else
            Return Color.Blue
        End If
    End Function

End Class
