'maken deze aan voor vakjes aan te duiden
Public Class PanelBox
    Inherits Panel

    'gebruiken dit voor aangeduide vakjes
    Private _Used As Boolean

    Public Property Used As Boolean
        Get
            Return _Used
        End Get
        Set(value As Boolean)
            _Used = value
        End Set
    End Property

    Sub New()
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub
End Class
