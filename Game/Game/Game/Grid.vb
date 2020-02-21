Public Class SpeelGird
    Public Grid(8, 8) As PanelBox
    Public Columns As Integer = 8
    Public Rows As Integer = 8

    Friend Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Init()
    End Sub

    Private Sub Init()
        For x As Integer = 0 To Columns - 1
            For y As Integer = 0 To Rows - 1
                Grid(x, y) = New PanelBox
                Grid(x, y).Size = New Size(50, 50)
                Grid(x, y).Location = New Point((x * 50), (y * 50))
                Grid(x, y).BackColor = Color.Blue
                Me.Controls.Add(Grid(x, y))
            Next
        Next
    End Sub

End Class
