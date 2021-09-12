Public Class UNB_Err
    Friend Shared Sub Fehlerprotokoll(ex As Exception)
        Fehlerprotokoll(ex, "")
    End Sub
    Friend Shared Sub Fehlerprotokoll(ex As Exception, XTraInfo As String)
        If ex IsNot Nothing Then
            Dim sMsg As String = ex.Message
            If FNC.FF(XTraInfo).Length > 0 Then
                sMsg &= vbCrLf & "Info: " & XTraInfo
            End If
            MsgBox(sMsg, vbOKOnly + MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Eine Ausnahme ist aufgetreten")
        End If
    End Sub
End Class
