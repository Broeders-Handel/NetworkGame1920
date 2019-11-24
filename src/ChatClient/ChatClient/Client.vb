Imports System.IO
Imports System.Threading

Public Class Client
    Dim cc As New TCPControllerClient
    Public Event MessageRecieved(data As String)
    Private ComunicatieThread As Thread
    Dim islistening As Boolean

    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                cc.sendToServer(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Try
            cc.sendToServer(MessageTextBox.Text)
            MessageTextBox.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Dim Connected As Boolean = False
        cc.Username = InputBox("Geef een gebruikersnaam op.")
        Connected = cc.Connect()
        If Connected = True Then
            islistening = True
            ConnectButton.Text = "Connected"
            ChatRichTextBox.Text = "<< CONNECTED TO SERVER >>" & cc.NewLine
            ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
            ComunicatieThread.Start()
            'Listening()
        Else
            MessageBox.Show("Je bent niet verbonden")
        End If


    End Sub
    Private Sub Listening()
        Dim ClientData As StreamReader
        Do Until islistening = False
            ClientData = New StreamReader(cc.TCPClientStream)
            Try
                RaiseEvent MessageRecieved(ClientData.ReadLine)
            Catch ex As Exception
            End Try
            Thread.Sleep(100)
        Loop

    End Sub
End Class

