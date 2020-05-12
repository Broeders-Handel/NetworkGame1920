Public Class Readyform
    Dim ChallengePlayer As String = Client.Username
    Dim ChallengedPlayer As String = Client.UsersListBox.SelectedItem

    Private Sub Readyform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SpelerLabel1.Text = ChallengePlayer
        SpelerLabel2.Text = ChallengedPlayer
    End Sub
End Class