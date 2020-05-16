Imports System.IO
Imports System.Net.Sockets
Imports System.Threading


Public Class Client
    Private _Users As List(Of String)
    Private _Username As String
    Dim Connected As Boolean
    WithEvents clientController As New TCPClientController
    Dim tcpclient As TcpClient
    Private ComunicatieThread As Thread
    Dim islistening As Boolean


    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connected = False
        updateGUI()
    End Sub

    Function MessageReceived(message As String) Handles clientController.MessageReceived
        UpdateText(PublicChatTextBox, message)
    End Function
    Function PrivateMessageRecieved(message As String) Handles clientController.PrivateMessageRecieved
        UpdateText(PrivateChatTextBox, message)
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
#Region "Public Chatroom"
    Private Sub PublicMessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PublicTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If PublicTextBox.Text.Length > 0 Then
                clientController.Write(PublicTextBox.Text, clientController.COM_COMMAND.MESSAGE)
                PublicTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub PublicSendButton_Click(sender As Object, e As EventArgs) Handles PublicSendButton.Click
        Try
            If Connected = True Then
                clientController.Write(PublicTextBox.Text, clientController.COM_COMMAND.MESSAGE)
                PublicTextBox.Clear()
            Else
                MessageBox.Show("Je bent niet verbonden met de server")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
#Region "Private chatroom"
    Private Sub PrivateMessageTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PrivateTextBox.KeyDown


        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If PrivateTextBox.Text.Length > 0 Then
                clientController.Write(PrivateTextBox.Text, clientController.COM_COMMAND.PRIVATEMESSAGES)
                PrivateTextBox.Clear()
            End If
        End If
    End Sub
    Private Sub PrivateSendButton_Click(sender As Object, e As EventArgs) Handles PrivateSendButton.Click
        Try
            If Connected = True Then
                clientController.Write(PrivateTextBox.Text, clientController.COM_COMMAND.PRIVATEMESSAGES)
                PrivateTextBox.Clear()
            Else
                MessageBox.Show("Je bent niet verbonden met de server")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click

        If IpAdressTextBox.Text Like "*.*.*.*" Then
            Username = InputBox("Geef een gebruikersnaam op.")

            Do While Username = ""
                MessageBox.Show("Je moet een geldige username ingeven")
                Username = InputBox("Geef een gebruikersnaam op.")
                ConnectButton.Enabled = True
                DisconnectButton.Enabled = False
            Loop

            clientController.Username = Username
            Connected = clientController.Connect(IpAdressTextBox.Text)

            ComunicatieThread = New Thread(New ThreadStart(AddressOf clientController.Listening))
            ComunicatieThread.Start()

            Me.Text = Username
            updateGUI()
        Else
            MessageBox.Show("Dit Is geen correct IP adres")
        End If
    End Sub

    Private Sub updateGUI()
        If Connected Then
            PublicChatTextBox.ReadOnly = False
            IpAdressTextBox.ReadOnly = True
            DisconnectButton.Enabled = True
            ConnectButton.Text = "Connected"
            ConnectButton.Enabled = False
            PrivateMessageButton.Enabled = True
        Else
            updateBut(ConnectButton)
            updateBut(DisconnectButton)
            updatetextBox(IpAdressTextBox)
            updatetextBox(PublicChatTextBox)
            UsersListBox.Items.Clear()
            ConnectButton.Enabled = True
            DisconnectButton.Enabled = False
            IpAdressTextBox.ReadOnly = False
            ConnectButton.Text = "Connect"
            PrivateMessageButton.Enabled = False
            ConnectButton.Enabled = True
            PrivateChatTextBox.Text = ""
            PublicChatTextBox.Text = ""
            IpAdressTextBox.Text = ""

        End If
    End Sub
    Private Sub PrivateMessageButton_Click(sender As Object, e As EventArgs) Handles PrivateMessageButton.Click
        clientController.Write(UsersListBox.SelectedItem, clientController.COM_COMMAND.PRIVATEUSERNAMES)
        TabControl1.SelectTab(1)
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

        updateGUI()
    End Sub
    Public Sub stopServer()
        tcpclient = New TcpClient
        clientController.DisconnectUser()
        Connected = False
        updateGUI()
    End Sub
    Private Sub ChallengeGame(txt As String)
        If PublicTextBox.Text = "!Challenge @" Then
            Me.Hide()
            Readyform.Show()
        End If

    End Sub
    Private Delegate Sub UpdateTextDelegate(RTB As TextBox, txt As String)
    'Update textbox
    Private Sub UpdateText(RTB As TextBox, txt As String)
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
            but.Text = "Connect"
            but.Enabled = True
        Else
            but.Enabled = False
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

