Imports System.IO
Imports System.Threading


Public Class Client
    Private _Username As String
    Dim Connected As Boolean
    Dim clienController As New TCPClientController
    Public Event MessageRecieved(data As String)
    Private ComunicatieThread As Thread = New Thread(New ThreadStart(AddressOf Listening))
    Dim islistening As Boolean

    Public Property Username As String
        Get
            Return _Username
        End Get
        Set(value As String)
            _Username = value
        End Set
    End Property
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
        If IpAdressTextBox.Text Like "*.*.*.*" Then
            Username = InputBox("Geef een gebruikersnaam op.")
            If Username = "" Then
                MessageBox.Show("Je moet een geldige username ingeven")
            Else
                clienController.Username = Username
                clienController.Connect(IpAdressTextBox.Text)
                islistening = True
                ConnectButton.Text = "Connected"
                ConnectButton.Enabled = False
                ComunicatieThread.Start()
                IpAdressTextBox.ReadOnly = True
                DisconnectButton.Enabled = True
                Connected = True
            End If
        Else
            MessageBox.Show("Dit Is geen correct IP adres")
        End If
    End Sub
    Private Sub Listening()
        Dim streamRdr As StreamReader
        Dim data As String = ""
        Do While islistening
            Try
                streamRdr = New StreamReader(clienController.TCPClientStream)
                data = streamRdr.ReadLine
                If data Like "server => " & Username & " JOINED" Then
                    UpdateText(ChatRichTextBox, "<< CONNECTED TO SERVER >>")
                ElseIf data Like "//DISC//" Then
                    ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
                    clienController.stopServer()
                    ConnectButton.Enabled = True
                    DisconnectButton.Enabled = False
                    IpAdressTextBox.Text = ""
                    IpAdressTextBox.ReadOnly = False
                    ChatRichTextBox.Text = ""

                End If
                UpdateText(ChatRichTextBox, data)
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
        clienController.DisconnectUser()
        ConnectButton.Enabled = True
        DisconnectButton.Enabled = False
        IpAdressTextBox.Text = ""
        IpAdressTextBox.ReadOnly = False
        ChatRichTextBox.Text = ""
        ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
    End Sub

    Private Sub ChallengeGame(txt As String)
        If MessageTextBox.Text = "!Challenge @" Then
            Me.Hide()
            Readyform.Show()
        End If

    End Sub
End Class

