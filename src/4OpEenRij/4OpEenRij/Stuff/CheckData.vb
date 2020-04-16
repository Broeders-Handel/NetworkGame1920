Public Class CheckData
    Public Sub New(foar As Boolean, i() As PanelBox)
        FourOnARow = foar
        Items = i
    End Sub

    Public FourOnARow As Boolean
    Public Items() As PanelBox
End Class