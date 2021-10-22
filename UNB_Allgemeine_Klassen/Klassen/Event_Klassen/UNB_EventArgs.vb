Public Class UNB_EventArgs : Inherits System.EventArgs
    Private _Cancel As Boolean = False
    Private _UserObject As Object = Nothing

    Public Property Cancel As Boolean
        Get
            Return _Cancel
        End Get
        Set(value As Boolean)
            _Cancel = value
        End Set
    End Property

    Public Property UserObject As Object
        Get
            Return _UserObject
        End Get
        Set(value As Object)
            _UserObject = value
        End Set
    End Property
End Class
