Imports Allgemeine_Klassen

Public Class SQL_Einheiten
    Friend Function Ausführen_SQL(SQL As String) As Boolean
        Dim DB As New Allgemeine_Klassen.DB
        Return DB.Ausführen_SQL(SQL, ConnPool.DB_Collection.FKM)
    End Function

    Friend Function Lade_Daten() As DataTable
        Dim rtDT As DataTable = Nothing
        Dim DB As New Allgemeine_Klassen.DB
        Dim sbSQL As New System.Text.StringBuilder
        sbSQL.AppendLine("SELECT DSID, BEZ, EINKAUF_FAKTOR, FAKTOR, BASIS_EINHEIT_NR FROM FKM_MENGEN_EINHEITEN With (NoLock)")
        sbSQL.AppendLine("WHERE GRUPPE = 0 AND GELOESCHT_AM Is Null")
        sbSQL.AppendLine("Order By BEZ")
        rtDT = DB.ReadData(sbSQL.ToString, "EINHEITEN ") : sbSQL.Length = 0
        '
        Return rtDT
    End Function

    Friend Function Lade_Daten(DSID As Long) As DataTable
        Dim rtDT As DataTable = Nothing
        Dim DB As New Allgemeine_Klassen.DB
        Dim sbSQL As New System.Text.StringBuilder
        sbSQL.AppendLine("SELECT DSID, BEZ, EINKAUF_FAKTOR, FAKTOR, BASIS_EINHEIT_NR FROM FKM_MENGEN_EINHEITEN With (NoLock)")
        sbSQL.AppendLine("WHERE DSID = " & DSID)

        rtDT = DB.ReadData(sbSQL.ToString, "EINHEITEN ") : sbSQL.Length = 0
        '
        Return rtDT
    End Function

    Friend Function DatensatzWirdVerwendet(DSID As Long) As Boolean
        Dim rtBool As Boolean = False
        Dim DB As New DB
        Dim sbSQL As New System.Text.StringBuilder
        sbSQL.AppendLine("SELECT Count(*) WERT FROM yyy WHERE DSID_EINHEIT=" & DSID)
        rtBool = FNC.SQLAbruf_Long(sbSQL.ToString) > 0 : sbSQL.Length = 0
        '
        Return rtBool
    End Function

    Friend Function Datensatz_Löschen(DSID As Long) As Boolean
        Dim rtBool As Boolean = False
        Dim DB As New DB
        Dim sbSQL As New System.Text.StringBuilder
        sbSQL.AppendLine("UPDATE FKM_MENGEN_EINHEITEN SET GELOESCHT_AM=getdate(), GELOESCHT_VON=1 WHERE DSID=" & DSID)
        rtBool = DB.Ausführen_SQL(sbSQL.ToString) : sbSQL.Length = 0
        '
        Return rtBool
    End Function
End Class
