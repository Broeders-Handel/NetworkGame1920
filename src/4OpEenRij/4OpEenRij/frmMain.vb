
Public Class frmMain

    Public Players(1) As IPlayer
    Public PlayerTurn As IPlayer
    Dim i As Integer = 0

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CreateButtons()
        Init()
    End Sub

    Public Sub Init()
        PlayerTurn = Players(i)
        Grid5.Init()
        UpdateStatus()
        pnlButtons.Enabled = True
    End Sub

    Sub CreateButtons()
        For i As Integer = 0 To Grid1.Columns - 1
            Dim btn As New Button()
            btn.Text = "Click me!"
            btn.Size = New Size(50, 50)
            btn.Location = New Point(i * 50, 0)
            btn.Tag = i

            AddHandler btn.Click, AddressOf BtnClick

            pnlButtons.Controls.Add(btn)
        Next
    End Sub

    Sub BtnClick(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        Dim clickedColumn As Integer = clickedButton.Tag

        DoTurn(clickedColumn)

    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Init()
    End Sub

    Private Sub btnNewGame_Click(sender As System.Object, e As System.EventArgs) Handles btnNewGame.Click
        ReadyForm.Show()
        Me.Close()
    End Sub

    Public Sub NextTurn()
        If (i = 0) Then
            i = 1
        Else
            i = 0
        End If
        PlayerTurn = Players(i)
        UpdateStatus()

        If (PlayerTurn.Name = "AI") Then
            DoTurn(0)
        End If
    End Sub

    Public Sub DoTurn(x As Integer)
        Application.DoEvents()
        If (PlayerTurn.DoTurn(x) = False) Then
            Return
        End If
        Application.DoEvents()
        Dim data As CheckData = Grid1.Check4OnARow(Grid1.lastSet.X, Grid1.lastSet.Y)
        If (data.FourOnARow = True) Then
            DoWin(data)
        Else
            If (Grid1.CheckDraw()) Then
                DoDraw()
            Else
                NextTurn()
            End If

        End If
    End Sub

    Private Sub UpdateStatus()
        txtTurn.Text = String.Format("{0}'s turn!", PlayerTurn.Name)
    End Sub

    Private Sub DoWin(data As CheckData)
        ColorItems(data.Items)
        pnlButtons.Enabled = False
        MessageBox.Show(String.Format("{0} Won!", PlayerTurn.Name))
    End Sub

    Private Sub DoDraw()
        pnlButtons.Enabled = False
        MessageBox.Show("Game ended in a draw!")
    End Sub

    Private Sub ColorItems(Items As PanelBox())
        For Each item As PanelBox In Items
            item.BackColor = Color.Blue
        Next
    End Sub
End Class