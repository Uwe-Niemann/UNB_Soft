Public Class Benutzer_Objekt
    Private _UserID As Long = 0
    Private _Benutzer_Name As String = ""

    Public Property UserID As Long
        Get
            Return _UserID
        End Get
        Set(value As Long)
            _UserID = value
        End Set
    End Property
    Public Property UserName As String
        Get
            Return _Benutzer_Name
        End Get
        Set(value As String)
            _Benutzer_Name = value
        End Set
    End Property

End Class
