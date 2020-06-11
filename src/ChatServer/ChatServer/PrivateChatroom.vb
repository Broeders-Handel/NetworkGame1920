Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom
    Dim RijClicked As New Dictionary(Of String, Boolean)
    Dim KolomClicked As New Dictionary(Of String, Boolean)
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

    Public function RecieveCoordinaat(message As String) As String
        Return message
    End function

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


    'Public Sub SetZwaartekracht(rijkol As String)
    '    Dim rij As String = rijkol.Substring(0, 1)
    '    Dim Kolom As String = rijkol.Substring(2, 1)
    '    RijClicked.Add(rij, True)
    '    KolomClicked.Add(Kolom, True)

    '    If RijClicked.Keys(rij) = 5 And RijClicked.Keys(True) Then
    '        If KolomClicked.Keys(Kolom) = 0 And KolomClicked.Keys(True) Then
    '            rij = 4
    '            RijClicked.Add(rij, False)
    '        End If
    '    End If
    'Dim sb As New System.Text.StringBuilder
    'For Each item As KeyValuePair(Of String, Boolean) In RijClicked
    '    sb.AppendLine(item.Key & ") " & item.Value.ToString)
    'Next
    'MessageBox.Show(sb.ToString())
    'End Sub
End Class
