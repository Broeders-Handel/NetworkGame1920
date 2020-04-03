
Public Class frmLogin

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        Dim player1 As IPlayer
        Dim player2 As IPlayer
        Dim strPlayer1 As String = txtPlayer1.Text
        Dim strPlayer2 As String = txtPlayer2.Text

        If (String.IsNullOrEmpty(strPlayer1) Or strPlayer1 = "AI") Then
            player1 = New AI(Color.Green)
        Else
            player1 = New Player(strPlayer1, Color.Green)
        End If

        If (String.IsNullOrEmpty(strPlayer2) Or strPlayer2 = "AI") Then
            player2 = New AI(Color.Red)
        Else
            player2 = New Player(strPlayer2, Color.Red)
        End If

        Me.Hide()

        frmMain.Players(0) = player1
        frmMain.Players(1) = player2
        frmMain.Init()
        frmMain.Show()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class