Imports System.IO
Imports System.Threading


Public Class Client
    Private _Users As List(Of String)
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
    Public Property Users As List(Of String)
        Get
            Return _Users
        End Get
        Set(value As List(Of String))
            _Users = value
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
        Dim connectionSucces As Boolean = True
        If IpAdressTextBox.Text Like "*.*.*.*" Then
            Username = InputBox("Geef een gebruikersnaam op.")


            clienController.Username = Username
            Dim response As ConnectedResponse = clienController.Connect(IpAdressTextBox.Text)
            Do While response = connectResponse.DuplicateUsername
                Username = InputBox("Geef een gebruikersnaam op.")
                clienController.Username = Username
                response = clienController.Connect(IpAdressTextBox.Text)
            Loop

            If response = ConnectedResponse.CorrectUsername Then
                islistening = True
                ConnectButton.Text = "Connected"
                ConnectButton.Enabled = True
                ComunicatieThread.Start()
                IpAdressTextBox.ReadOnly = True
                DisconnectButton.Enabled = True
                Connected = True
            Else
                MessageBox.Show("Geannuleerd")
                DisconnectButton.Enabled = False
                ConnectButton.Enabled = True
            End If


        Else
            MessageBox.Show("Dit is geen correct IP adres")
        End If
    End Sub


    'Moet in controller staan. 
    Private Sub Listening()
        Dim streamRdr As StreamReader
        Dim data As String = ""
        Do While islistening
            Try
                streamRdr = New StreamReader(clienController.TCPClientStream)
                data = streamRdr.ReadLine
                If data Like "server => " & Username & " JOINED" Then
                    UpdateText(ChatRichTextBox, "<< CONNECTED TO SERVER >>")
                ElseIf data Like "//USST//*" Then
                    data = data.Substring(8)
                    Dim IndexKomma As Integer
                    Dim Username As String
                    Do While data.Contains(",")
                        IndexKomma = data.IndexOf(",")
                        Username = data.Substring(0, IndexKomma)
                        data = data.Substring(IndexKomma + 1)
                        UpdateClientList(Username)
                    Loop
                End If
                UpdateText(ChatRichTextBox, data)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Thread.Sleep(100)
        Loop
    End Sub
<<<<<<< HEAD
    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    'Update textbox
    'Bekijk server voor doorgeven event
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
        Else
            If txt IsNot Nothing Then
                RTB.AppendText(txt & Environment.NewLine)
            End If
        End If
    End Sub
=======
>>>>>>> master

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
    Private Delegate Sub UpdateListBox(ByVal Item As String)
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

    Private Sub UpdateClientList(ByVal Item As String)
        If UsersListBox.InvokeRequired Then
            UsersListBox.Invoke(New UpdateListBox(AddressOf UpdateClientList), Item)
        Else
            If Item IsNot Nothing Then
                UsersListBox.Items.Add(Item)
            End If
        End If
    End Sub
End Class

