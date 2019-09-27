Imports System.ComponentModel

Public Class Form1
    Private Server As TCPController
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Server = New TCPController
        ChatTextBox.Text = "::  Server Starting  ::" & Environment.NewLine

        AddHandler Server.MessageRecieved, AddressOf OnlineRecieved

    End Sub

    Private Delegate Sub UpdateTextDelegate(TB As TextBox, txt As String)

    'Update textbox
    Private Sub UpdateText(TB As TextBox, txt As String)
        If TB.InvokeRequired Then
            TB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {TB, txt})
        Else
            If txt IsNot Nothing Then TB.AppendText(txt & Environment.NewLine)
        End If
    End Sub


    Private Sub OnlineRecieved(sender As TCPController, data As String)
        UpdateText(ChatTextBox, data)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Server.IsListening = False
    End Sub
End Class
