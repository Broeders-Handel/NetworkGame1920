Imports System.IO
Imports System.Threading

Public Class Client
    Dim Connected As Boolean
    Dim clienController As New TCPClientController
    Public Event MessageRecieved(data As String)
    Private ComunicatieThread As Thread = New Thread(New ThreadStart(AddressOf Listening))
    Dim islistening As Boolean

    Private Sub MessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MessageTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageTextBox.Text.Length > 0 Then
                clienController.Write(MessageTextBox.Text)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Try
            If Connected = True Then
                clienController.Write(MessageTextBox.Text)
                MessageTextBox.Clear()
            Else
                MessageBox.Show("Je bent niet verbonden met de server")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Connected = False
        If IpAdressTextBox.Text Like "*.*.*.*" Then
            clienController.Username = InputBox("Geef een gebruikersnaam op.")
            Connected = clienController.Connect(IpAdressTextBox.Text)
        Else
            MessageBox.Show("Dit Is geen correct IP adres")
        End If
        If Connected = True Then
            islistening = True
            ConnectButton.Text = "Connected"
            ChatRichTextBox.Text = "<< CONNECTED TO SERVER >>"
            ConnectButton.Enabled = False
            ComunicatieThread.Start()
            IpAdressTextBox.ReadOnly = True
        Else
            MessageBox.Show("Je bent niet verbonden")
        End If
    End Sub
    Private Sub Listening()
        Dim streamRdr As StreamReader
        Dim data As String = ""
        Do While islistening
            Try
                streamRdr = New StreamReader(clienController.TCPClientStream)
                UpdateText(ChatRichTextBox, data)
                data = streamRdr.ReadLine
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Thread.Sleep(100)
        Loop
    End Sub
    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    'Update textbox
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
        Else
            If txt IsNot Nothing Then
                RTB.AppendText(txt & Environment.NewLine)
            End If
        End If
    End Sub

    Private Sub DisconnectButton_Click(sender As Object, e As EventArgs) Handles DisconnectButton.Click
        If Connected = True Then
            Connected = False
            islistening = False
            ConnectButton.Text = "Connect"
            ChatRichTextBox.Text &= "<< DISCONNECTED FROM THE SERVER >>"
            ConnectButton.Enabled = True
            DisconnectButton.Enabled = False
            clienController.DisconnectUser()
        Else
            MessageBox.Show("Je bent niet geconnecteerd met een server.")
        End If
    End Sub


End Class

