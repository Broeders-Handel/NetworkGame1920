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
    Private _ButtonList As New List(Of Button)
    Private Index As Integer = 0
    Dim islistening As Boolean
    Dim AandeBeurt As Boolean = False

    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To 36 - 1
            addButton("KLIK HIER!")
        Next
        Connected = False
        updateGUI()
    End Sub
    Function WhosTurn(Truefalse As String) Handles clientController.WhosTurn

        If Truefalse Like "False" Then
            For Each button In _ButtonList
                updateButClickable(button)
            Next

        ElseIf Truefalse Like "True" Then
            For Each button In _ButtonList
                updateButNotClickable(button)
            Next
        End If
    End Function
    Function LeftGame() Handles clientController.LeftGame
        ClearTextBox(PrivateChatTextBox)
    End Function
    Function MessageReceived(message As String) Handles clientController.MessageReceived
        UpdateText(PublicChatTextBox, message)
    End Function
    Function PrivateMessageRecieved(message As String) Handles clientController.PrivateMessageRecieved
        UpdateText(PrivateChatTextBox, message)
    End Function

    Function UserlistRecieved(users As List(Of String)) Handles clientController.ConnectedUsers
        UpdateClientList(users)
    End Function
    Function UpdateGame(Message As String) Handles clientController.GamePlayRecieved
        UpdateGamePlay(RetrieveClickedButton(Message))
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
    Private Sub ChallengeButton_Click(sender As Object, e As EventArgs) Handles ChallengeButton.Click
        clientController.Write(UsersListBox.SelectedItem, clientController.COM_COMMAND.PRIVATEUSERNAMES)
        TabControl1.SelectTab(1)
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

            Me.Text = Username
            updateGUI()
        Else
            MessageBox.Show("Dit is geen correct IP adres")
        End If
    End Sub

    Private Sub updateGUI()
        If Connected Then
            PublicChatTextBox.ReadOnly = False
            IpAdressTextBox.ReadOnly = True
            DisconnectButton.Enabled = True
            ConnectButton.Text = "Connected"
            PrivateSendButton.Enabled = True
            PublicSendButton.Enabled = True
            ConnectButton.Enabled = False
            ChallengeButton.Enabled = True
            'PrivateMessageButton.Enabled = True
            PrivateTextBox.ReadOnly = False
            PublicTextBox.ReadOnly = False
            TabControl1.Enabled = True
        Else
            updateBut(ConnectButton)
            updateBut(DisconnectButton)

            updateBut(PublicSendButton)
            updateBut(PrivateSendButton)
            'updateBut(PrivateMessageButton)
            updatetextBox(IpAdressTextBox)
            updatetextBox(PublicTextBox)
            updatetextBox(PrivateTextBox)
            updatetextBox(PublicChatTextBox)
            updateTabcontrol(TabControl1)
            updateListBox(UsersListBox)

            PublicTextBox.ReadOnly = True
            PrivateTextBox.ReadOnly = True
            ConnectButton.Enabled = True
            DisconnectButton.Enabled = False
            IpAdressTextBox.ReadOnly = False
            ConnectButton.Text = "Connect"
            ChallengeButton.Enabled = False
            ConnectButton.Enabled = True
            PrivateChatTextBox.Text = ""
            PublicChatTextBox.Text = ""
            IpAdressTextBox.Text = ""
            PublicSendButton.Enabled = False
            PrivateSendButton.Enabled = False
            TabControl1.Enabled = False
            UsersListBox.Items.Clear()


        End If
    End Sub

    Private Sub addButton(text As String)
        Dim Button As New Button()
        Button.Text = text

        Dim rij As Integer = Index Mod 6
        Dim kol As Integer = Index \ 6

        Button.Location = New Point(10 + 70 * kol, 7.5 + 60 * rij)
        Button.Size = New Size(60, 60)
        Index += 1
        Me.Controls.Add(Button)
        _ButtonList.Add(Button)
        AddHandler Button.Click, AddressOf Button_Click
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim ButtonClick As Button = CType(sender, Button)
        Dim Index As Integer = _ButtonList.IndexOf(ButtonClick)
        Dim Kolom As Integer = Index \ 6
        Dim Rij As Integer = Index Mod 6
        Dim KolRij As String = Rij & "," & Kolom
        clientController.Write(KolRij, clientController.COM_COMMAND.GAME)
        'clientController.GetColor()
    End Sub

    Private Function RetrieveClickedButton(Message As String) As Button
        Dim btn As Button
        Dim rij As String = Message.Substring(0, 1)
        Dim kolom As String = Message.Substring(2, 1)
        Dim index As Integer = kolom * 6 + rij
        btn = _ButtonList(index)
        Return btn
    End Function

    Private Sub PrivateMessageButton_Click(sender As Object, e As EventArgs) Handles PrivateSendButton.Click
        clientController.Write(UsersListBox.SelectedItem, clientController.COM_COMMAND.PRIVATEUSERNAMES)
        TabControl1.SelectTab(1)
    End Sub
    Private Sub LeaveButton_Click(sender As Object, e As EventArgs) Handles LeaveButton.Click
        clientController.Write("", clientController.COM_COMMAND.LEAVEGAME)
        PrivateChatTextBox.Text = ""
    End Sub

    Public Sub ServerStopped() Handles clientController.ServerStopped
        stopServer()
    End Sub
    Public Sub win(message As String) Handles clientController.Win
        GewonnenLabel.Text = message
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
        ComunicatieThread = New Thread(New ThreadStart(AddressOf clientController.Listening))
        UsersListBox.DataSource = Nothing
        Connected = False
        updateGUI()
    End Sub
    Public Sub stopServer()

        tcpclient = New TcpClient
        clientController.DisconnectUser()
        Connected = False
        updateGUI()
    End Sub

    Private Delegate Sub UpdateTextDelegate(RTB As TextBox, txt As String)
    'Update textbox
    Private Sub UpdateText(RTB As TextBox, txt As String)
        If RTB.InvokeRequired Then
            RTB.BeginInvoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {RTB, txt})
        ElseIf txt IsNot Nothing Then
            RTB.AppendText(txt & Environment.NewLine)
        End If
    End Sub
    Private Delegate Sub ClearTextBoxDelegate(TB As TextBox)
    Private Sub ClearTextBox(TB As TextBox)
        If TB.InvokeRequired Then
            TB.Invoke(New ClearTextBoxDelegate(AddressOf ClearTextBox), New Object() {TB})
        Else
            TB.Text = ""
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
    Private Delegate Sub UpdateButClickableDelegate(but As Button)
    Private Sub updateButClickable(but As Button)
        If but.InvokeRequired Then
            but.Invoke(New UpdateButClickableDelegate(AddressOf updateButClickable), but)
        ElseIf but.Enabled = True Then
            but.Enabled = False
        End If
    End Sub
    Private Delegate Sub UpdateButNotClickableDelegate(but As Button)
    Private Sub updateButNotClickable(but As Button)
        If but.InvokeRequired Then
            but.Invoke(New UpdateButClickableDelegate(AddressOf updateButNotClickable), but)
        ElseIf but.Enabled = False Then
            but.Enabled = True
        End If
    End Sub
    Private Delegate Sub UpdateButDelegate(But As Button)
    Private Sub updateBut(but As Button)
        If but.InvokeRequired Then
            but.Invoke(New UpdateButDelegate(AddressOf updateBut), but)
        ElseIf but.Enabled = False Then
            but.Enabled = True
            If but.Text = "Connected" Then
                but.Text = "Connect"
            End If
        Else
            but.Enabled = False
            If but.Text = "Connect" Then
                but.Text = "Connected"
            End If
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
    Private Delegate Sub updateTabControlDelegate(tc As TabControl)
    Private Sub updateTabcontrol(tc As TabControl)
        If tc.InvokeRequired Then
            tc.Invoke(New updateTabControlDelegate(AddressOf updateTabcontrol), tc)
        Else
            If tc.Enabled = True Then
                tc.Enabled = False
            Else
                tc.Enabled = True
            End If
        End If
    End Sub

    Private Delegate Sub updateListBoxDelegate(lb As ListBox)
    Private Sub updateListBox(lb As ListBox)
        If lb.InvokeRequired Then
            lb.Invoke(New updateListBoxDelegate(AddressOf updateListBox), lb)
        Else
            lb.DataSource = Nothing
        End If
    End Sub
    Private Delegate Sub UpdateGamePlayDelegate(but As Button)
    Private Sub UpdateGamePlay(but As Button)
        If but.InvokeRequired Then
            but.BeginInvoke(New UpdateGamePlayDelegate(AddressOf UpdateGamePlay), but)
        ElseIf but.Text = "KLIK HIER!" Then
            but.Text = "Clicked"
            but.BackColor = clientController.GetColor
        End If
    End Sub
End Class
