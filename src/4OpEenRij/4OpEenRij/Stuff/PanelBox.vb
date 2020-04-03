

Public Class PanelBox
    Inherits Panel

    Sub New()
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private _used As Boolean
    Public Property Used() As Boolean
        Get
            Return _used
        End Get
        Set(ByVal value As Boolean)
            _used = value
        End Set
    End Property


End Class
