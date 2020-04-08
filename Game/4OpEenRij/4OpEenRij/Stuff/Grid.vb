
Public Class Grid

    Public grid(8, 8) As PanelBox
    Public Columns As Integer = 8
    Public Rows As Integer = 8

    Public lastSet As Point

    Friend Sub New()
        InitializeComponent()
        Init()
    End Sub

    Public Sub Init()
        Me.Controls.Clear()

        For x As Integer = 0 To Columns - 1
            For y As Integer = 0 To Rows - 1
                grid(x, y) = New PanelBox()
                grid(x, y).Size = New Size(50, 50)
                grid(x, y).Location = New Point((x * 50), (y * 50))
                grid(x, y).BackColor = Color.LightGray

                Me.Controls.Add(grid(x, y))
            Next
        Next
    End Sub

    Public Function CheckDraw() As Boolean
        For x = 0 To Columns - 1
            For y = 0 To Rows - 1
                If (grid(x, y).Used = False) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Public Function AddItemAtColumn(x As Integer, clr As Color) As Boolean
        For y As Integer = Rows - 1 To 0 Step -1
            If (grid(x, y).Used = False) Then
                grid(x, y).Used = True
                grid(x, y).BackColor = clr

                lastSet = New Point(x, y)

                Return True
            End If
        Next
        Return False
    End Function

    Public Function Check4OnARow(x As Integer, y As Integer) As CheckData
        Dim blnWin As Boolean = False
        Dim items As New List(Of PanelBox)()

        Dim diagL As CheckData = CheckDiagL(x, y)
        Dim diagR As CheckData = CheckDiagR(x, y)
        Dim ver As CheckData = CheckVertically(x, y)
        Dim hor As CheckData = CheckHorizontally(x, y)

        If diagL.FourOnARow = True Then
            blnWin = True
            items.AddRange(diagL.Items)
        End If

        If diagR.FourOnARow = True Then
            blnWin = True
            items.AddRange(diagR.Items)
        End If

        If hor.FourOnARow = True Then
            blnWin = True
            items.AddRange(hor.Items)
        End If

        If ver.FourOnARow = True Then
            blnWin = True
            items.AddRange(ver.Items)
        End If

        Return New CheckData(blnWin, items.ToArray())

    End Function

    Private Function CheckVertically(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim currColor As Color = frmMain.PlayerTurn.Color

        lstItems.Add(grid(x, y))

        For i As Integer = y + 1 To Columns - 1
            If (i > Rows - 1) Then
                Exit For
            Else
                If (grid(x, i).Used = True) Then
                    If (grid(x, i).BackColor = currColor) Then
                        lstItems.Add(grid(x, i))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        For i As Integer = y - 1 To 0 Step -1
            If (i < 0) Then
                Exit For
            Else
                If (grid(x, i).Used = True) Then
                    If (grid(x, i).BackColor = currColor) Then
                        lstItems.Add(grid(x, i))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If


    End Function

    Private Function CheckHorizontally(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim currColor As Color = frmMain.PlayerTurn.Color

        lstItems.Add(grid(x, y))

        For i As Integer = x + 1 To Columns - 1
            If (i > Columns - 1) Then
                Exit For
            Else
                If (grid(i, y).Used = True) Then
                    If (grid(i, y).BackColor = currColor) Then
                        lstItems.Add(grid(i, y))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        For i = x - 1 To 0 Step -1
            If (i < 0) Then
                Exit For
            Else
                If (grid(i, y).Used = True) Then
                    If (grid(i, y).BackColor = currColor) Then
                        lstItems.Add(grid(i, y))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

    Private Function CheckDiagR(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim currColor As Color = frmMain.PlayerTurn.Color

        lstItems.Add(grid(x, y))

        ' x + 1 | y - 1
        Dim intY As Integer = y + 1
        For intX As Integer = x + 1 To Columns - 1
            If (intX > Columns - 1 Or intY > Rows - 1) Then
                Exit For
            Else
                If (grid(intX, intY).Used = True) Then
                    If (grid(intX, intY).BackColor = currColor) Then
                        lstItems.Add(grid(intX, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intY += 1
        Next


        Dim intX1 As Integer = x - 1
        For intY = y - 1 To 0 Step -1
            If (intX1 < 0 Or intY < 0) Then
                Exit For
            Else
                If (grid(intX1, intY).Used = True) Then
                    If (grid(intX1, intY).BackColor = currColor) Then
                        lstItems.Add(grid(intX1, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intX1 -= 1
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

    Private Function CheckDiagL(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim currColor As Color = frmMain.PlayerTurn.Color

        lstItems.Add(grid(x, y))

        Dim intY As Integer = y - 1
        For intX = x + 1 To Columns - 1
            If (intX > Columns - 1 Or intY < 0) Then
                Exit For
            Else
                If (grid(intX, intY).Used = True) Then
                    If (grid(intX, intY).BackColor = currColor) Then
                        lstItems.Add(grid(intX, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intY -= 1
        Next

        Dim intX1 As Integer = x - 1
        For intY = y + 1 To Rows - 1
            If (intX1 < 0 Or intY > Rows - 1) Then
                Exit For
            Else
                If (grid(intX1, intY).Used = True) Then
                    If (grid(intX1, intY).BackColor = currColor) Then
                        lstItems.Add(grid(intX1, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intX1 -= 1
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

End Class
