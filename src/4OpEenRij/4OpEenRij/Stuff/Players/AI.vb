

Public Class AI
    Implements IPlayer

    Public Sub New(clr As Color)
        Name = "AI"
        Color = clr
    End Sub

    Private _c As Color
    Public Property Color As System.Drawing.Color Implements IPlayer.Color
        Get
            Return _c
        End Get
        Set(value As System.Drawing.Color)
            _c = value
        End Set
    End Property

    Private _n As String
    Public Property Name As String Implements IPlayer.Name
        Get
            Return _n
        End Get
        Set(value As String)
            _n = value
        End Set
    End Property

    Public Function DoTurn(x As Integer) As Boolean Implements IPlayer.DoTurn
        Dim rnd As New Random()
        Dim intRandom As Integer = rnd.Next(0, frmMain.Grid1.Columns)

        Do Until (DoTurnn(intRandom) = True)
            intRandom = rnd.Next(0, frmMain.Grid1.Columns)
            Threading.Thread.Sleep(10)
        Loop

        Threading.Thread.Sleep(1000)

        Return True
    End Function

    Private Function DoTurnn(x As Integer) As Boolean
        Return (frmMain.Grid1.AddItemAtColumn(x, Color))

    End Function

End Class
