Public Class UNB_CheckEdit_EventArgs
    Private _OhneFragenSpeichern As Integer = 0
    Private _bCancel As Boolean = False
    Private _sCaption As String = ""
    Private _RowIndex As Integer = -1
    Private _AbfrageErgebnis As MsgBoxResult = MsgBoxResult.Ignore
    Public Sub New()
    End Sub
    Public Sub New(ByVal sCaption As String)
        _sCaption = sCaption
    End Sub

    Public Property Caption() As String
        Get
            Return _sCaption
        End Get
        Set(ByVal value As String)
            _sCaption = value
        End Set
    End Property
    Public Property Cancel() As Boolean
        Get
            Return _bCancel
        End Get
        Set(ByVal value As Boolean)
            _bCancel = value
        End Set
    End Property
    Public Property OhneFragenSpeichern() As Integer
        Get
            Return _OhneFragenSpeichern
        End Get
        Set(ByVal value As Integer)
            _OhneFragenSpeichern = value
        End Set
    End Property
    Public Property AbfrageErgebnis() As MsgBoxResult
        Get
            Return _AbfrageErgebnis
        End Get
        Set(ByVal value As MsgBoxResult)
            _AbfrageErgebnis = value
        End Set
    End Property
    Public Property RowIndex As Integer
        Get
            Return _RowIndex
        End Get
        Set(value As Integer)
            _RowIndex = value
        End Set
    End Property

End Class
