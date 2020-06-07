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

    Public Function RecieveCoordinaat(Rijkol As String) As String
        Dim rij As String = Rijkol.Substring(0, 1)
        Dim Kolom As String = Rijkol.Substring(1, 1)
        Return Rijkol
    End Function
    Public Function checkHorizontal(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(1, 1)

        If rij = 0 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If
        ElseIf rij = 1 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If

        ElseIf rij = 2 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If
        ElseIf rij = 3 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If
        ElseIf rij = 4 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If
        ElseIf rij = 5 Then
            If kol = 0 And kol = 1 And kol = 2 And kol = 3 Then
                Return True
            ElseIf kol = 1 And kol = 2 And kol = 3 And kol = 4 Then
                Return True
            ElseIf kol = 2 And kol = 3 And kol = 4 And kol = 5 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

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

End Class
