Imports System.IO
Imports System.Threading

Public Class Client
    Dim clienController As New TCPClientController
    Public Event MessageRecieved(data As String)
    Private ComunicatieThread As Thread
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
            clienController.Write(MessageTextBox.Text)
            MessageTextBox.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        Dim Connected As Boolean = False
        clienController.Username = InputBox("Geef een gebruikersnaam op.")
        Connected = clienController.Connect()
        If Connected = True Then
            islistening = True
            ConnectButton.Text = "Connected"
            ChatRichTextBox.Text = "<< CONNECTED TO SERVER >>" & Environment.NewLine
            ComunicatieThread = New Thread(New ThreadStart(AddressOf Listening))
            ComunicatieThread.Start()
            'Listening()
        Else
            MessageBox.Show("Je bent niet verbonden")
        End If
    End Sub
    Private Sub Listening()
        Dim streamRdr As StreamReader
        Do While islistening
            Try
                streamRdr = New StreamReader(clienController.TCPClientStream)
                Dim data As String = streamRdr.ReadLine
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
End Class

