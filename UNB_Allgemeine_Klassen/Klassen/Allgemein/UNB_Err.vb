Public Class UNB_Err
    Public Shared Sub ShowError(ByVal Meldung As String)
        UNB_Protokoll.SchreibeProtokoll("[FEHLER]:" & Meldung)
        MsgBox(Meldung, MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "")
    End Sub
    Public Shared Sub ShowError(ByVal Meldung As String, ByVal bSilentError As Boolean)
        UNB_Protokoll.SchreibeProtokoll("[FEHLER]:" & IIf(bSilentError, "[INFO]: ", "") & Meldung)
        If Not bSilentError Then MsgBox(Meldung, MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal)
    End Sub

    Public Shared Sub ShowError(ByVal ex As Exception)
        ShowError(ex, False, "")
    End Sub
    Public Shared Sub ShowError(ByVal ex As Exception, ByVal bSilentError As Boolean)
        ShowError(ex, bSilentError, "")
    End Sub
    Public Shared Sub ShowError(ByVal ex As Exception, ByVal xtraInfo As String)
        ShowError(ex, False, xtraInfo)
    End Sub
    Public Shared Sub ShowError(ByVal ex As Exception, ByVal bSilentError As Boolean, ByVal xtraInfo As String)
        Dim sMsg As String = Erzeuge_Msg_Aus_Exception(ex, xtraInfo)
        sMsg = "[FEHLER]:" & sMsg ' Zum Filtern im Protokoll-Analysetool
        If bSilentError Then sMsg = "[INFO]: " & sMsg
        UNB_Protokoll.SchreibeProtokoll(sMsg)
        If Not bSilentError Then MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.SystemModal)
    End Sub
    Public Shared Function ShowError(ByVal ds As DataSet, Optional ByVal ZusatzProtoInfo As String = "", Optional ByVal bSilentError As Boolean = False) As Boolean
        If ds Is Nothing Then Return True
        If ds.Tables.Contains("Fehler") Then
            Dim msg As New System.Text.StringBuilder()
            msg.Append("[FEHLER]:") ' Zum Filtern im Protokoll-Analysetool
            If bSilentError Then msg.AppendLine("[INFO]:")
            If ZusatzProtoInfo.Length > 0 Then msg.AppendLine("ZusatzInfo: " & ZusatzProtoInfo)
            For Each r As DataRow In ds.Tables("Fehler").Rows
                For Each c As DataColumn In ds.Tables("Fehler").Columns
                    msg.AppendLine(c.Caption & ": " & r.Item(c))
                Next
            Next
            UNB_Protokoll.SchreibeProtokoll(msg.ToString)
            If Not bSilentError Then MsgBox(msg.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical + MsgBoxStyle.SystemModal)
            Return True
        End If
        Return False
    End Function

    Public Shared Function Erzeuge_Msg_Aus_Exception(ByVal Ex As Exception) As String
        Return Erzeuge_Msg_Aus_Exception(Ex, "")
    End Function
    Public Shared Function Erzeuge_Msg_Aus_Exception(ByVal Ex As Exception, ByVal xtraInfo As String) As String
        Dim rtMsg As New System.Text.StringBuilder()
        If xtraInfo.Length > 0 Then rtMsg.AppendLine("ZusatzInfo: " & xtraInfo)
        rtMsg.AppendLine(Ex.Message)
        rtMsg.AppendLine("Source: " & Ex.Source)
        If Ex.TargetSite IsNot Nothing Then
            rtMsg.AppendLine("TargetSite: " & Ex.TargetSite.ToString)
        Else
            rtMsg.AppendLine("TargetSite:")
        End If
        AppendStacktrace(rtMsg, Ex.StackTrace)
        AppendDataFromError(Ex, rtMsg)
        If Not Ex.InnerException Is Nothing Then
            rtMsg.AppendLine("-")
            rtMsg.AppendLine(Ex.InnerException.Message)
            rtMsg.AppendLine("Source: " & Ex.InnerException.Source)
            If Ex.InnerException.TargetSite IsNot Nothing Then
                rtMsg.AppendLine("TargetSite: " & Ex.InnerException.TargetSite.ToString)
            Else
                rtMsg.AppendLine("TargetSite:")
            End If
            AppendStacktrace(rtMsg, Ex.InnerException.StackTrace)
            AppendDataFromError(Ex.InnerException, rtMsg)
        End If
        Return rtMsg.ToString
    End Function

    Private Shared Sub AppendStacktrace(ByVal msg As System.Text.StringBuilder, ByVal StackTrace As String)
        msg.AppendLine("StackTrace:")
        Dim ar() As String = Split(StackTrace, "    ")
        For i As Integer = LBound(ar) To UBound(ar)
            If ar(i).Length > 0 Then msg.AppendLine(ar(i))
        Next
    End Sub
    Private Shared Sub AppendDataFromError(ByVal ex As Exception, ByVal msg As System.Text.StringBuilder)
        For Each o As Object In ex.Data
            msg.AppendLine(o.ToString)
        Next
    End Sub
End Class
