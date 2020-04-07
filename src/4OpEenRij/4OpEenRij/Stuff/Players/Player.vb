
Public Class Player
    Implements IPlayer

    Public Sub New(strName As String, clr As Color)
        Name = strName
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
        Return frmMain.Grid1.AddItemAtColumn(x, Color)
    End Function
End Class
