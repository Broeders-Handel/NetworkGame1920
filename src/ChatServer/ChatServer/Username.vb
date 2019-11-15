Public Class Username
    Private _username As String

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return " => " & Username
    End Function
End Class
