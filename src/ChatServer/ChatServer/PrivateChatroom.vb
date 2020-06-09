Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom

    Dim kolLijst As New List(Of String)
    Dim rijLijst As New List(Of String)
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
    Public Function checkHorizontal(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)
        Dim gewonnen As Boolean

        kolLijst.Add(kol)

        If rij = 0 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf rij = 1 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf rij = 2 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf rij = 3 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf rij = 4 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf rij = 5 Then
            If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
                gewonnen = True
            ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
                gewonnen = True
            ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        End If

        If gewonnen = True Then
            kolLijst.RemoveRange(0, kolLijst.Count - 1)
        End If
        Return gewonnen
    End Function
    Public Function checkVertical(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)
        Dim gewonnen As Boolean
        rijLijst.Add(rij)
        If kol = 0 Then
            If kolLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kol = 1 Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kol = 2 Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kol = 3 Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kol = 4 Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kol = 5 Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        End If
        If gewonnen = True Then
            rijLijst.RemoveRange(0, rijLijst.Count - 1)
        End If
        Return gewonnen
    End Function
    Public Function checkDiagonal(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)
        Dim gewonnen As Boolean

        rijLijst.Add(rij)
        kolLijst.Add(kol)

        If kolLijst.Contains(0) And kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijlijst.contains(1) And rijlijst.contains(2) And rijlijst.contains(3) And rijlijst.contains(4) Then
                gewonnen = True
            ElseIf rijlijst.Contains(2) And rijlijst.Contains(3) And rijLijst.Contains(4) And rijlijst.contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kolLijst.Contains(1) And kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kolLijst.Contains(2) And kolLijst.Contains(3) And kolLijst.Contains(4) And kolLijst.Contains(5) Then
            If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
                gewonnen = True
            ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
                gewonnen = True
            ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        End If
        If gewonnen = True Then
            rijLijst.RemoveRange(0, rijLijst.Count - 1)
            kolLijst.RemoveRange(0, kolLijst.Count - 1)
        End If
        Return gewonnen
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
