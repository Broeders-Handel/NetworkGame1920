Imports Microsoft.VisualBasic.CompilerServices

Public Class PrivateChatroom
    Dim clickedButtonsUser1 As New List(Of String)
    Dim clickedButtonsUser2 As New List(Of String)

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

    Public Function RecieveCoordinaat(Rijkol As String) As String
        Dim rij As String = Rijkol.Substring(0, 1)
        Dim Kolom As String = Rijkol.Substring(2, 1)
        Return rij & Kolom
    End Function
    Public Function checkHorizontalUser1(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser1.Contains(clickedButton) Then
            clickedButtonsUser1.Add(clickedButton)
        End If

        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("02") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("12") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("22") Then
            gewonnen = True

        Else
            gewonnen = False
        End If
        Return gewonnen
    End Function
    Public Function checkHorizontalUser2(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser2.Contains(clickedButton) Then
            clickedButtonsUser2.Add(clickedButton)
        End If

        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("01") And clickedButtonsUser2.Contains("02") Then
            gewonnen = True
        ElseIf clickedButtonsUser2.Contains("10") And clickedButtonsUser2.Contains("11") And clickedButtonsUser2.Contains("12") Then
            gewonnen = True
        ElseIf clickedButtonsUser2.Contains("20") And clickedButtonsUser2.Contains("21") And clickedButtonsUser2.Contains("22") Then
            gewonnen = True

        Else
            gewonnen = False
        End If
        Return gewonnen
    End Function
    Public Function checkVerticalUser1(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser1.Contains(clickedButton) Then
            clickedButtonsUser1.Add(clickedButton)
        End If


        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("20") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("21") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("22") Then
            gewonnen = True
        Else
            gewonnen = False
        End If
        Return gewonnen


    End Function
    Public Function checkVerticalUser2(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser2.Contains(clickedButton) Then
            clickedButtonsUser2.Add(clickedButton)
        End If




        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("10") And clickedButtonsUser2.Contains("20") Then
            gewonnen = True
        ElseIf clickedButtonsUser2.Contains("01") And clickedButtonsUser2.Contains("11") And clickedButtonsUser2.Contains("21") Then
            gewonnen = True
        ElseIf clickedButtonsUser2.Contains("02") And clickedButtonsUser2.Contains("12") And clickedButtonsUser2.Contains("22") Then
            gewonnen = True
        Else
            gewonnen = False
        End If
        Return gewonnen

    End Function
    Public Function checkDiagonalUser1(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser1.Contains(clickedButton) Then
            clickedButtonsUser1.Add(clickedButton)
        End If

        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("22") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("20") Then
            gewonnen = True
        Else
            gewonnen = False
        End If


        Return gewonnen
    End Function
    Public Function checkDiagonalUser2(rijkol As String) As Boolean
        Dim rij As String = rijkol.Substring(0, 1)
        Dim kol As String = rijkol.Substring(2, 1)

        Dim gewonnen As Boolean
        Dim clickedButton As String = RecieveCoordinaat(rijkol)
        If Not clickedButtonsUser2.Contains(clickedButton) Then
            clickedButtonsUser2.Add(clickedButton)
        End If


        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("11") And clickedButtonsUser2.Contains("22") Then
            gewonnen = True
        ElseIf clickedButtonsUser2.Contains("02") And clickedButtonsUser2.Contains("11") And clickedButtonsUser2.Contains("20") Then
            gewonnen = True
        Else
            gewonnen = False
        End If


        Return gewonnen
    End Function
    Public Sub SendCoordinaat(Rijkol As String, sender As String)
        For Each usr In users
            usr.write(Rijkol, Server.COM_COMMAND.GAME)
        Next
    End Sub



    Public Sub SetZwaartekracht(Message As String)
        Dim Rij As String = Message.Substring(0, 1)
        Dim kolom As String = Message.Substring(2, 1)


    End Sub
End Class
