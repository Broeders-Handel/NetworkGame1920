
Public Class Player
    Private _Player As String

    Private Property Player As String
        Get
            Return _Player
        End Get
        Set(value As String)
            If value = String.Empty Then
                Throw New Exception("Dit is geen geldige waarde")
            Else
                _Player = value
            End If
        End Set
    End Property
    'Public Sub New(strName As String, clr As Color)
    '  Name = strName
    '   Color = clr
    'End Sub

    Private _c As Color
    ' Public Property Color As System.Drawing.Color Implements IPlayer.Color
    ' Get
    ' Return _c
    ' End Get
    ' Set(value As System.Drawing.Color)
    '       _c = value
    ' End Set
    ' End Property

    ' Private _n As String


    '  Public Function DoTurn(x As Integer) As Boolean Implements IPlayer.DoTurn
    ' Return frmMain.Grid1.AddItemAtColumn(x, Color)
    ' End Function
End Class
