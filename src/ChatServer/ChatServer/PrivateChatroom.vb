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

        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("03") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("03") And clickedButtonsUser1.Contains("04") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("03") And clickedButtonsUser1.Contains("04") And clickedButtonsUser1.Contains("05") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("13") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("14") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("14") And clickedButtonsUser1.Contains("15") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("23") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("24") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("25") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("30") And clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("33") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("34") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("34") And clickedButtonsUser1.Contains("35") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("40") And clickedButtonsUser1.Contains("41") And clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("43") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("41") And clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("43") And clickedButtonsUser1.Contains("44") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("43") And clickedButtonsUser1.Contains("44") And clickedButtonsUser1.Contains("45") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("50") And clickedButtonsUser1.Contains("51") And clickedButtonsUser1.Contains("52") And clickedButtonsUser1.Contains("53") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("51") And clickedButtonsUser1.Contains("52") And clickedButtonsUser1.Contains("53") And clickedButtonsUser1.Contains("54") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("52") And clickedButtonsUser1.Contains("53") And clickedButtonsUser1.Contains("54") And clickedButtonsUser1.Contains("55") Then
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

        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("01") And clickedButtonsUser2.Contains("02") And clickedButtonsUser2.Contains("03") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("01") And clickedbuttonsUser2.Contains("02") And clickedbuttonsUser2.Contains("03") And clickedbuttonsUser2.Contains("04") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("02") And clickedbuttonsUser2.Contains("03") And clickedbuttonsUser2.Contains("04") And clickedbuttonsUser2.Contains("05") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("10") And clickedbuttonsUser2.Contains("11") And clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("13") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("11") And clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("14") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("14") And clickedbuttonsUser2.Contains("15") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("20") And clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("23") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("24") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("25") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("30") And clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("33") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("34") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("34") And clickedbuttonsUser2.Contains("35") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("40") And clickedbuttonsUser2.Contains("41") And clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("43") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("41") And clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("43") And clickedbuttonsUser2.Contains("44") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("43") And clickedbuttonsUser2.Contains("44") And clickedbuttonsUser2.Contains("45") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("50") And clickedbuttonsUser2.Contains("51") And clickedbuttonsUser2.Contains("52") And clickedbuttonsUser2.Contains("53") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("51") And clickedbuttonsUser2.Contains("52") And clickedbuttonsUser2.Contains("53") And clickedbuttonsUser2.Contains("54") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("52") And clickedbuttonsUser2.Contains("53") And clickedbuttonsUser2.Contains("54") And clickedbuttonsUser2.Contains("55") Then
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




        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("30") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("30") And clickedButtonsUser1.Contains("40") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("30") And clickedButtonsUser1.Contains("40") And clickedButtonsUser1.Contains("50") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("31") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("41") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("41") And clickedButtonsUser1.Contains("51") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("32") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("42") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("52") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("03") And clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("33") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("43") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("43") And clickedButtonsUser1.Contains("53") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("04") And clickedButtonsUser1.Contains("14") And clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("34") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("14") And clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("34") And clickedButtonsUser1.Contains("44") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("34") And clickedButtonsUser1.Contains("44") And clickedButtonsUser1.Contains("54") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("05") And clickedButtonsUser1.Contains("15") And clickedButtonsUser1.Contains("25") And clickedButtonsUser1.Contains("35") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("15") And clickedButtonsUser1.Contains("25") And clickedButtonsUser1.Contains("35") And clickedButtonsUser1.Contains("45") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("25") And clickedButtonsUser1.Contains("35") And clickedButtonsUser1.Contains("45") And clickedButtonsUser1.Contains("55") Then
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




        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("10") And clickedButtonsUser2.Contains("20") And clickedButtonsUser2.Contains("30") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("10") And clickedbuttonsUser2.Contains("20") And clickedbuttonsUser2.Contains("30") And clickedbuttonsUser2.Contains("40") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("20") And clickedbuttonsUser2.Contains("30") And clickedbuttonsUser2.Contains("40") And clickedbuttonsUser2.Contains("50") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("01") And clickedbuttonsUser2.Contains("11") And clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("31") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("11") And clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("41") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("41") And clickedbuttonsUser2.Contains("51") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("02") And clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("32") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("42") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("52") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("03") And clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("33") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("43") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("43") And clickedbuttonsUser2.Contains("53") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("04") And clickedbuttonsUser2.Contains("14") And clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("34") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("14") And clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("34") And clickedbuttonsUser2.Contains("44") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("34") And clickedbuttonsUser2.Contains("44") And clickedbuttonsUser2.Contains("54") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("05") And clickedbuttonsUser2.Contains("15") And clickedbuttonsUser2.Contains("25") And clickedbuttonsUser2.Contains("35") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("15") And clickedbuttonsUser2.Contains("25") And clickedbuttonsUser2.Contains("35") And clickedbuttonsUser2.Contains("45") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("25") And clickedbuttonsUser2.Contains("35") And clickedbuttonsUser2.Contains("45") And clickedbuttonsUser2.Contains("55") Then
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


        If clickedButtonsUser1.Contains("00") And clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("33") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("11") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("44") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("44") And clickedButtonsUser1.Contains("55") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("10") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("43") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("43") And clickedButtonsUser1.Contains("54") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("20") And clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("53") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("01") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("34") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("34") And clickedButtonsUser1.Contains("45") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("02") And clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("35") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("05") And clickedButtonsUser1.Contains("14") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("32") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("14") And clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("41") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("23") And clickedButtonsUser1.Contains("32") And clickedButtonsUser1.Contains("41") And clickedButtonsUser1.Contains("50") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("15") And clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("42") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("24") And clickedButtonsUser1.Contains("33") And clickedButtonsUser1.Contains("42") And clickedButtonsUser1.Contains("51") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("25") And clickedButtonsUser1.Contains("34") And clickedButtonsUser1.Contains("43") And clickedButtonsUser1.Contains("52") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("04") And clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("31") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("13") And clickedButtonsUser1.Contains("22") And clickedButtonsUser1.Contains("31") And clickedButtonsUser1.Contains("40") Then
            gewonnen = True
        ElseIf clickedButtonsUser1.Contains("03") And clickedButtonsUser1.Contains("12") And clickedButtonsUser1.Contains("21") And clickedButtonsUser1.Contains("30") Then
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


        If clickedButtonsUser2.Contains("00") And clickedButtonsUser2.Contains("11") And clickedButtonsUser2.Contains("22") And clickedButtonsUser2.Contains("33") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("11") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("44") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("44") And clickedbuttonsUser2.Contains("55") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("10") And clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("43") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("43") And clickedbuttonsUser2.Contains("54") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("20") And clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("53") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("01") And clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("34") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("34") And clickedbuttonsUser2.Contains("45") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("02") And clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("35") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("05") And clickedbuttonsUser2.Contains("14") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("32") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("14") And clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("41") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("23") And clickedbuttonsUser2.Contains("32") And clickedbuttonsUser2.Contains("41") And clickedbuttonsUser2.Contains("50") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("15") And clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("42") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("24") And clickedbuttonsUser2.Contains("33") And clickedbuttonsUser2.Contains("42") And clickedbuttonsUser2.Contains("51") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("25") And clickedbuttonsUser2.Contains("34") And clickedbuttonsUser2.Contains("43") And clickedbuttonsUser2.Contains("52") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("04") And clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("31") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("13") And clickedbuttonsUser2.Contains("22") And clickedbuttonsUser2.Contains("31") And clickedbuttonsUser2.Contains("40") Then
            gewonnen = True
        ElseIf clickedbuttonsUser2.Contains("03") And clickedbuttonsUser2.Contains("12") And clickedbuttonsUser2.Contains("21") And clickedbuttonsUser2.Contains("30") Then
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
