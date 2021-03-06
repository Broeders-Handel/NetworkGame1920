﻿Imports System.Net.Sockets
Imports System.IO
Imports ChatServer.Server

Class UsersController
    Private _Users As New Dictionary(Of String, User)
    Private _PrivateChatRooms As New Dictionary(Of Integer, PrivateChatroom)
    Public Function createPrivateChatroom(user1 As User, user2 As User) As Integer
        Try
            Dim chtrm As PrivateChatroom = New PrivateChatroom(user1, user2)
            PrivateChatrooms.Add(chtrm.ID, chtrm)
            user1.IsBusy = True
            user2.IsBusy = True
            Return chtrm.ID
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return -1
        End Try
    End Function
    Public Property PrivateChatrooms As Dictionary(Of Integer, PrivateChatroom)
        Get
            Return _PrivateChatRooms
        End Get
        Set(value As Dictionary(Of Integer, PrivateChatroom))
            _PrivateChatRooms = value
        End Set
    End Property
    Public Property Users As Dictionary(Of String, User)
        Get
            Return _Users
        End Get
        Set(value As Dictionary(Of String, User))
            _Users = value
        End Set
    End Property
    Public Sub RemoveUser(userindex As Integer)
        Dim usr As User = Users.Values(userindex)
        RemoveUser(usr)
    End Sub
    Public Sub RemoveUser(usr As User)
        If Not usr Is Nothing Then
            _Users.Remove(usr.Username)
            usr.stopListen()
            usr.write("", COM_COMMAND.STOPSERVER)
        End If
    End Sub
    Public Function addUser(user As User) As Boolean
        Try
            If Users.ContainsKey(user.Username) Then
                Return False
            End If
            _Users.Add(user.Username, user)
            'UsersString = ""
            'For i As Integer = 0 To Users.Count - 1
            '    UsersString &= Users.Keys(i) & ","
            'Next
            'For Each usr In Users.Values
            '    usr.write(UsersString, Server.COM_COMMAND.CONNECTEDUSERS)
            'Next
            'UsersString = ""
            Return True
        Catch ex As Exception
            Console.WriteLine("User disconnected")
        End Try
        Return False
    End Function

    Friend Function getUsers() As String
        Return MakeUserstring()
    End Function
    Private Function MakeUserstring() As String
        Dim UsersString As String
        UsersString = ""
        For i As Integer = 0 To Users.Count - 1
            UsersString &= Users.Keys(i) & ","
        Next
        Return UsersString
    End Function

End Class
