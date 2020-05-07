Imports System.IO
Imports System.Threading


Public Class Client
    Private _Users As List(Of String)
    Private _Username As String
    Dim Connected As Boolean
    WithEvents clientController As New TCPClientController

    Private ComunicatieThread As Thread
    Dim islistening As Boolean
    Function MessageReceived(message As String) Handles clientController.MessageReceived
        UpdateText(PublicRichTextBox, message)
    End Function
    Function UserListRecieved(users As List(Of String)) Handles clientController.ConnectedUsers
        UpdateClientList(users)
    End Function
    Function PrivateMessageRecieved(message As String) Handles clientController.PrivateMessageRecieved
        UpdateText(PrivateRichTextBox, message)
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
            clientController.Connect(IpAdressTextBox.Text)
            '            islistening = True 'WHY??
            ConnectButton.Text = "Connected"
            ConnectButton.Enabled = False
            ComunicatieThread = New Thread(New ThreadStart(AddressOf clientController.Listening))
            ComunicatieThread.Start()
            IpAdressTextBox.ReadOnly = True
            DisconnectButton.Enabled = True
            PrivateMessageButton.Enabled = True
            Connected = True

        Else
            MessageBox.Show("Dit Is geen correct IP adres")
        End If
    End Sub
    Private Sub PrivateMessageButton_Click(sender As Object, e As EventArgs) Handles PrivateMessageButton.Click
        clientController.Write(UsersListBox.SelectedItem, clientController.COM_COMMAND.PRIVATEUSERNAMES)
        TabControl1.SelectTab(1)
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
        ConnectButton.Enabled = True
        DisconnectButton.Enabled = False
        IpAdressTextBox.Text = ""
        IpAdressTextBox.ReadOnly = False
        PublicRichTextBox.Text = ""
        ComunicatieThread.Abort()
        ComunicatieThread = New Thread(New ThreadStart(AddressOf clientController.Listening))
        UsersListBox.DataSource = Nothing
    End Sub

    Private Sub ChallengeGame(txt As String)
        If PublicTextBox.Text = "!Challenge @" Then
            Me.Hide()
            Readyform.Show()
        End If

    End Sub
    Private Delegate Sub UpdateListBox(ByVal users As List(Of String))
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

    Private Sub UpdateClientList(users As List(Of String))
        If UsersListBox.InvokeRequired Then
            UsersListBox.Invoke(New UpdateListBox(AddressOf UpdateClientList), users)
        Else
            UsersListBox.DataSource = Nothing
            UsersListBox.DataSource = users
        End If
    End Sub
End Class
