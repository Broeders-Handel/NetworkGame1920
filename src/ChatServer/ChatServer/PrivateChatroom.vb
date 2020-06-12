Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom

    Dim rij0 As New List(Of String)
    Dim rij1 As New List(Of String)
    Dim rij2 As New List(Of String)
    Dim rij3 As New List(Of String)
    Dim rij4 As New List(Of String)
    Dim rij5 As New List(Of String)
    Dim kolList As New List(Of String)
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

    Public Function RecieveCoordinaat(Rijkol As String) As Boolean
        Dim rij As String = Rijkol.Substring(0, 1)
        Dim Kolom As String = Rijkol.Substring(2, 1)
        Return True
    End Function
    Public Function checkHorizontal(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim rijKolList As New Dictionary(Of String, Boolean)
        Dim clicked As Boolean = RecieveCoordinaat(rijkol)
        rijKolList.Add(rijkol, clicked)

        'rijList.Add(rij)
        kolList.Add(kol)

        If rijKolList And kolList.Contains(1) And kolList.Contains(2) And kolList.Contains(3) Then
            If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
                gewonnen = True
            ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
                gewonnen = True
            ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
                gewonnen = True
            ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
                gewonnen = True
            ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
                gewonnen = True
            ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kolList.Contains(1) And kolList.Contains(2) And kolList.Contains(3) And kolList.Contains(4) Then
            If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
                gewonnen = True
            ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
                gewonnen = True
            ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
                gewonnen = True
            ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
                gewonnen = True
            ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
                gewonnen = True
            ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
                gewonnen = True
            Else
                gewonnen = False
            End If
        ElseIf kolList.Contains(2) And kolList.Contains(3) And kolList.Contains(4) And kolList.Contains(5) Then
            If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
                gewonnen = True
            ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
                gewonnen = True
            ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
                gewonnen = True
            ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
                gewonnen = True
            ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
                gewonnen = True
            ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
                gewonnen = True
            Else
                gewonnen = False
            End If
            'ElseIf rij = 3 Then
            '    If rijKolList.Contains(0) And rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) Then
            '        gewonnen = True
            '    ElseIf rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) Then
            '        gewonnen = True
            '    ElseIf rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) And rijKolList.Contains(5) Then
            '        gewonnen = True
            '    Else
            '        gewonnen = False
            '    End If
            'ElseIf rij = 4 Then
            '    If rijKolList.Contains(0) And rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) Then
            '        gewonnen = True
            '    ElseIf rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) Then
            '        gewonnen = True
            '    ElseIf rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) And rijKolList.Contains(5) Then
            '        gewonnen = True
            '    Else
            '        gewonnen = False
            '    End If
            'ElseIf rij = 5 Then
            '    If rijKolList.Contains(0) And rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) Then
            '    gewonnen = True
            'ElseIf rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) Then
            '    gewonnen = True
            'ElseIf rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) And rijKolList.Contains(5) Then
            '    gewonnen = True
            'Else
            '    gewonnen = False
            'End If
        End If

        'If gewonnen = True Then
        '    rijKolList.RemoveRange(0, rijKolList.Count - 1)
        'End If
        Return gewonnen

    End Function
    'Public Function checkVertical(rijkol As String) As Boolean
    '    Dim rij As String = rijkol.Substring(0, 1)
    '    Dim kol As String = rijkol.Substring(2, 1)
    '    Dim gewonnen As Boolean
    '    rijLijst.Add(rij)
    '    If kol = 0 Then
    '        If rijKolList.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf kol = 1 Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf kol = 2 Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf kol = 3 Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf kol = 4 Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf kol = 5 Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    End If
    '    If gewonnen = True Then
    '        rijLijst.RemoveRange(0, rijLijst.Count - 1)
    '    End If
    '    Return gewonnen
    'End Function
    'Public Function checkDiagonal(rijkol As String) As Boolean

    '    Dim rij As String = rijkol.Substring(0, 1)
    '    Dim kol As String = rijkol.Substring(2, 1)
    '    Dim gewonnen As Boolean

    '    rijLijst.Add(rij)
    '    rijKolList.Add(kol)

    '    If rijKolList.Contains(0) And rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf rijKolList.Contains(1) And rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    ElseIf rijKolList.Contains(2) And rijKolList.Contains(3) And rijKolList.Contains(4) And rijKolList.Contains(5) Then
    '        If rijLijst.Contains(0) And rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(1) And rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) Then
    '            gewonnen = True
    '        ElseIf rijLijst.Contains(2) And rijLijst.Contains(3) And rijLijst.Contains(4) And rijLijst.Contains(5) Then
    '            gewonnen = True
    '        Else
    '            gewonnen = False
    '        End If
    '    End If
    '    If gewonnen = True Then
    '        rijLijst.RemoveRange(0, rijLijst.Count - 1)
    '        rijKolList.RemoveRange(0, rijKolList.Count - 1)
    '    End If
    '    Return gewonnen
    'End Function
    Public Sub SendCoordinaat(Rijkol As String, sender As String)
        For Each usr In users
            usr.write(Rijkol, Server.COM_COMMAND.GAME)
        Next
    End Sub
    Public Function SetColor(color As Color) As Color
        Dim Colored As Boolean
        If Colored = True Then
            MessageBox.Show("Deze button is gebruikt!")
        Else
            color = Color.Blue
            Return color
        End If
    End Function

End Class
