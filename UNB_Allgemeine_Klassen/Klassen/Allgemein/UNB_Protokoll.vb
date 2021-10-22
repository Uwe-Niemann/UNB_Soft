Public Class UNB_Protokoll
    Public Shared Sub SchreibeProtokoll(strValue As String)
        If FNC.FF(strValue).Length > 0 Then
            Dim DB As New Allgemeine_Klassen.DB
            DB.Ausführen_SQL("INSERT INTO FKM_PROTOKOLL (WERT) VALUES(" & FNC.DBText(strValue) & ")", ConnPool.DB_Collection.FKM)
        End If
    End Sub
End Class
