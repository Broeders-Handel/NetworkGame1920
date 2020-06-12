Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom
    Dim clickedButtons As New List(Of String)
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
        Dim Kolom As String = Rijkol.Substring(2, 1)
        Return rij & Kolom
    End Function
    Public Function checkHorizontal(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        clickedButtons.Add(clickedButton)


        If clickedButtons.Contains("00") And clickedButtons.Contains("01") And clickedButtons.Contains("02") And clickedButtons.Contains("03") Then
            gewonnen = True
        ElseIf clickedButtons.Contains("01") And clickedButtons.Contains("02") And clickedButtons.Contains("03") And clickedButtons.Contains("04") Then
            gewonnen = True
        ElseIf clickedButtons.contains("02") And clickedButtons.contains("03") And clickedButtons.contains("04") And clickedButtons.contains("05") Then
            gewonnen = True
        ElseIf clickedButtons.contains("10") And clickedButtons.contains("11") And clickedButtons.contains("12") And clickedButtons.contains("13") Then
            gewonnen = True
        ElseIf clickedButtons.contains("11") And clickedButtons.contains("12") And clickedButtons.contains("13") And clickedButtons.contains("14") Then
            gewonnen = True
        ElseIf clickedButtons.contains("12") And clickedButtons.contains("13") And clickedButtons.contains("14") And clickedButtons.contains("15") Then
            gewonnen = True
        ElseIf clickedButtons.contains("20") And clickedButtons.contains("21") And clickedButtons.contains("22") And clickedButtons.contains("23") Then
            gewonnen = True
        ElseIf clickedButtons.contains("21") And clickedButtons.contains("22") And clickedButtons.contains("23") And clickedButtons.contains("24") Then
            gewonnen = True
        ElseIf clickedButtons.contains("22") And clickedButtons.contains("23") And clickedButtons.contains("24") And clickedButtons.contains("25") Then
            gewonnen = True
        ElseIf clickedButtons.contains("30") And clickedButtons.contains("31") And clickedButtons.contains("32") And clickedButtons.contains("33") Then
            gewonnen = True
        ElseIf clickedButtons.contains("31") And clickedButtons.contains("32") And clickedButtons.contains("33") And clickedButtons.contains("34") Then
            gewonnen = True
        ElseIf clickedButtons.contains("32") And clickedButtons.contains("33") And clickedButtons.contains("34") And clickedButtons.contains("35") Then
            gewonnen = True
        ElseIf clickedButtons.contains("40") And clickedButtons.contains("41") And clickedButtons.contains("42") And clickedButtons.contains("43") Then
            gewonnen = True
        ElseIf clickedButtons.contains("41") And clickedButtons.contains("42") And clickedButtons.contains("43") And clickedButtons.contains("44") Then
            gewonnen = True
        ElseIf clickedButtons.contains("42") And clickedButtons.contains("43") And clickedButtons.contains("44") And clickedButtons.contains("45") Then
            gewonnen = True
        ElseIf clickedButtons.contains("50") And clickedButtons.contains("51") And clickedButtons.contains("52") And clickedButtons.contains("53") Then
            gewonnen = True
        ElseIf clickedButtons.contains("51") And clickedButtons.contains("52") And clickedButtons.contains("53") And clickedButtons.contains("54") Then
            gewonnen = True
        ElseIf clickedButtons.contains("52") And clickedButtons.contains("53") And clickedButtons.contains("54") And clickedButtons.contains("55") Then
            gewonnen = True
        Else
            gewonnen = False
        End If
        Return gewonnen
        'If clickedButtons Then

        '        If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
        '            gewonnen = True
        '        ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
        '            gewonnen = True
        '        ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
        '            gewonnen = True
        '        ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
        '            gewonnen = True
        '        ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
        '            gewonnen = True
        '        ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
        '            gewonnen = True
        '        Else
        '            gewonnen = False
        '        End If
        '    ElseIf kolList.Contains(1) And kolList.Contains(2) And kolList.Contains(3) And kolList.Contains(4) Then
        '        If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
        '            gewonnen = True
        '        ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
        '            gewonnen = True
        '        ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
        '            gewonnen = True
        '        ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
        '            gewonnen = True
        '        ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
        '            gewonnen = True
        '        ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
        '            gewonnen = True
        '        Else
        '            gewonnen = False
        '        End If
        '    ElseIf kolList.Contains(2) And kolList.Contains(3) And kolList.Contains(4) And kolList.Contains(5) Then
        '        If rij0.Item(0) = 0 And rij0.Item(1) = 0 And rij0.Item(2) = 0 And rij0.Item(3) = 0 Then
        '        gewonnen = True
        '    ElseIf rij1.Item(0) = 1 And rij1.Item(1) = 1 And rij1.Item(2) = 1 And rij1.Item(3) = 1 Then
        '        gewonnen = True
        '    ElseIf rij2.Item(0) = 2 And rij2.Item(1) = 2 And rij2.Item(2) = 2 And rij2.Item(3) = 2 Then
        '        gewonnen = True
        '    ElseIf rij3.Item(0) = 3 And rij3.Item(1) = 3 And rij3.Item(2) = 3 And rij2.Item(3) = 3 Then
        '        gewonnen = True
        '    ElseIf rij4.Item(0) = 4 And rij4.Item(1) = 4 And rij2.Item(2) = 4 And rij2.Item(3) = 4 Then
        '        gewonnen = True
        '    ElseIf rij5.Item(0) = 5 And rij2.Item(1) = 5 And rij2.Item(2) = 5 And rij2.Item(3) = 5 Then
        '        gewonnen = True
        '    Else
        '        gewonnen = False
        '    End If
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
        'End If

        ''If gewonnen = True Then
        ''    rijKolList.RemoveRange(0, rijKolList.Count - 1)
        ''End If
        'Return gewonnen

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
