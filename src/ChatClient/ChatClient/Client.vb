Imports System.IO
Imports System.Net.Sockets
Imports System.Threading


Public Class Client
    Private _Users As List(Of String)
    Private _Username As String
    Dim Connected As Boolean
    WithEvents clientController As New TCPClientController
    Private ComunicatieThread As Thread
    Dim islistening As Boolean


    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connected = False
        updateGUI()
    End Sub

    Function MessageReceived(message As String) Handles clientController.MessageReceived
        UpdateText(ChatRichTextBox, message)
    End Function

    Function UserlistRecieved(users As List(Of String)) Handles clientController.ConnectedUsers
        UpdateClientList(users)
    End Function
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
                clientController.Write(MessageTextBox.Text, clientController.COM_COMMAND.MESSAGE)
                MessageTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Try
            If Connected = True Then
                clientController.Write(MessageTextBox.Text, clientController.COM_COMMAND.MESSAGE)
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
            clientController.Username = Username

            Dim response As TCPClientController.ConnectResponse = clientController.Connect(IpAdressTextBox.Text)
            Do While response = TCPClientController.ConnectResponse.DuplicateUsername
                MessageBox.Show("Deze username is al in gebruik.")
                Username = InputBox("Geef een gebruikersnaam op.")
                clientController.Username = Username
                response = clientController.Connect(IpAdressTextBox.Text)
            Loop
            If response = TCPClientController.ConnectResponse.CorrectUsername Then
                Connected = True
            Else
                MessageBox.Show("Geannuleerd")
                Connected = False
            End If



            updateGUI()
        Else
            MessageBox.Show("Dit is geen correct IP adres")
        End If
    End Sub

    Private Sub updateGUI()
        If Connected Then
            MessageTextBox.ReadOnly = False
            IpAdressTextBox.ReadOnly = True
            DisconnectButton.Enabled = True
            ConnectButton.Text = "Connected"
            ConnectButton.Enabled = False
            SendButton.Enabled = True
        Else
            updateBut(ConnectButton)
            updateBut(DisconnectButton)
            updatetextBox(IpAdressTextBox)
            updatetextBox(MessageTextBox)
            updateBut(SendButton)
            ConnectButton.Enabled = True

            DisconnectButton.Enabled = False
            IpAdressTextBox.ReadOnly = False
            MessageTextBox.ReadOnly = True
            ConnectButton.Text = "Connect"
            ConnectButton.Enabled = True

            MessageTextBox.Text = ""
            ChatRichTextBox.Text = ""
            IpAdressTextBox.Text = ""
            SendButton.Enabled = False
        End If
    End Sub
    Public Sub ServerStopped() Handles clientController.ServerStopped
        stopServer()
    End Sub
    'Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    ''Update textbox
    'Private Sub UpdateText(RTB As RichTextBox, txt As String)
    '    If RTB.InvokeRequired Then
    '        RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
    '    Else
    '        If txt IsNot Nothing Then
    '            RTB.AppendText(txt & Environment.NewLine)
    '        End If
    '    End If
    'End Sub

    Private Sub DisconnectButton_Click(sender As Object, e As EventArgs) Handles DisconnectButton.Click
        clientController.DisconnectUser()
        ComunicatieThread.Abort()
        ComunicatieThread = New Thread(New ThreadStart(AddressOf clientController.Listening))
        UsersListBox.DataSource = Nothing
        updateGUI()
    End Sub
    Public Sub stopServer()

        clientController.DisconnectUser()
        Connected = False
        updateGUI()
    End Sub
    Private Sub ChallengeGame(txt As String)
        If MessageTextBox.Text = "!Challenge @" Then
            Me.Hide()
            Readyform.Show()
        End If

    End Sub
    Private Delegate Sub UpdateTextDelegate(RTB As RichTextBox, txt As String)
    'Update textbox
    Private Sub UpdateText(RTB As RichTextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
        ElseIf txt IsNot Nothing Then
            RTB.AppendText(txt & Environment.NewLine)
        End If
    End Sub

    Private Delegate Sub UpdateClientDelegate(ByVal users As List(Of String))
    Private Sub UpdateClientList(users As List(Of String))
        If UsersListBox.InvokeRequired Then
            UsersListBox.Invoke(New UpdateClientDelegate(AddressOf UpdateClientList), users)
        Else
            UsersListBox.DataSource = Nothing
            UsersListBox.DataSource = users
        End If
    End Sub
    Private Delegate Sub UpdateButDelegate(But As Button)
    Private Sub updateBut(but As Button)
        If but.InvokeRequired Then
            but.Invoke(New UpdateButDelegate(AddressOf updateBut), but)
        ElseIf but.Enabled = False Then
            but.Enabled = True
        End If
    End Sub
    Private Delegate Sub updateTextBoxDelegate(tb As TextBox)
    Private Sub updatetextBox(tb As TextBox)
        If tb.InvokeRequired Then
            tb.Invoke(New updateTextBoxDelegate(AddressOf updatetextBox), tb)
        ElseIf tb.ReadOnly = True Then
            tb.ReadOnly = False
            tb.Text = ""
        ElseIf tb.ReadOnly = False Then
            tb.ReadOnly = True
            tb.Text = ""
        End If
    End Sub
End Class
