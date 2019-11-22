Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Public Class Client
    Dim cc As New TCPControllerClient
    Public Event MessageRecieved(data As String)

    Private ComunicatieThread As Thread

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ChatRichTextBox.Text &= cc.ReceiveText()
    End Sub
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
        cc.Username = InputBox("Geef een gebruikersnaam op.")
        cc.Connect()
        Timer1.Enabled = True
        ConnectButton.Text = "Connected"
        ChatRichTextBox.Text = "<< CONNECTED TO SERVER >>" & cc.NewLine
        ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
        ComunicatieThread.Start()
    End Sub

    Private Sub Listening()
        Dim ClientData As StreamReader
        'Create Listener Loop
        Do While True

            ClientData = New StreamReader(cc.TCPClientStream)

            ' Raise event for incoming messages
            Try
                RaiseEvent MessageRecieved(ClientData.ReadLine)
            Catch ex As Exception
            End Try
            'Reduce Cpu Usage
            Threading.Thread.Sleep(100)
        Loop
    End Sub



End Class

