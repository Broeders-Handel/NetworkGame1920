Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom
    Dim RijClicked As New Dictionary(Of String, Boolean)
    Dim KolomClicked As New Dictionary(Of String, Boolean)
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

    Public Sub RecieveCoordinaat(Rijkol As String)
        Dim rij As String = Rijkol.Substring(0, 1)
        Dim Kolom As String = Rijkol.Substring(1, 1)
        SetColor()
    End Sub

    Public Sub SendCoordinaat(Rijkol As String, sender As String)
        For Each usr In users
            usr.write(Rijkol, Server.COM_COMMAND.GAME)
        Next
    End Sub
    Public Function SetColor() As Color
        Dim Colored As Boolean
        If Colored = True Then
            MessageBox.Show("Deze button is gebruikt!")
        Else
            Return Color.Blue
        End If
    End Function

    Public Sub SetZwaartekracht(rijkol As String)
        Dim rij As String = rijkol.Substring(0, 1)
        Dim Kolom As String = rijkol.Substring(2, 1)
        RijClicked.Add(rij, True)
        KolomClicked.Add(Kolom, True)

        Dim sb As New System.Text.StringBuilder
        For Each item As KeyValuePair(Of String, Boolean) In RijClicked
            sb.AppendLine(item.Key & ") " & item.Value.ToString)
        Next
        MessageBox.Show(sb.ToString())
    End Sub
End Class
