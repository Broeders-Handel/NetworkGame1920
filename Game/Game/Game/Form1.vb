Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateButtons()
    End Sub

    Sub CreateButtons()

        For i As Integer = 1 To Speelgrid.Columns - 1
            Dim Btn As New Button()
            Btn.Text = "Click me!"

            Btn.Location = New Point(i * 50, 0)
            ButtonPanelBox.Controls.Add(Btn)
        Next




    End Sub
End Class
