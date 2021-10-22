Imports System.Data.SqlClient

Public Class DB
    Public Function ReadData(SQL As String, TableName As String) As DataTable
        Return ReadData(SQL, TableName, ConnPool.DB_Collection.FKM)
    End Function
    Public Function ReadData(SQL As String, TableName As String, Datenbank As ConnPool.DB_Collection) As DataTable
        Dim rtDataTable As DataTable = Nothing
        AddSQL(SQL, TableName, Datenbank)
        Using DS As DataSet = Hole_daten_lokal(mitSchema:=True, istAsynchron:=False)
            If DS IsNot Nothing Then
                If DS.Tables.Contains(TableName) Then
                    rtDataTable = DS.Tables(TableName).Copy
                End If
            End If
        End Using
        Return rtDataTable
    End Function

    Public Function ExecuteSQL(SQL As String) As Boolean
        Return ExecuteSQL(SQL, ConnPool.DB_Collection.FKM)
    End Function
    Public Function ExecuteSQL(SQL As String, Datenbank As ConnPool.DB_Collection) As Boolean
        Dim Erfolg As Boolean = False
        Dim ds As DataSet = Hole_daten(SQL, "X", Datenbank)
        If Not ds Is Nothing Then
            If Not ds.Tables.Contains("Fehler") Then Erfolg = True
        End If
        Return Erfolg
    End Function

#Region "Datenbank-Funktionen"
    Private m_lngDatenbank As Long = 0
    Private m_Count As Integer = 0
    Private m_SQLs() As String
    Private m_Tables() As String
    Private m_Datenbanken() As Long
    Private m_oDB As New ConnPool
    Public Event Call_Back(ByVal rt As Object)

    ''' <summary>
    ''' Setzen des CommandTimeouts wenn der Datenzugriff nicht über den WebService erfolgt.
    ''' So kann für laaange Abfragen kurzzeitig der Wert hochgedreht werden.
    ''' </summary>
    ''' <remarks></remarks>
    Public CommandTimeout As Integer = 180

    Public Sub New()
    End Sub

    Public Property DBIndex() As Long
        Get
            Return m_lngDatenbank
        End Get
        Set(ByVal value As Long)
            m_lngDatenbank = value
        End Set
    End Property

    ''' <summary>
    ''' Gibt die Anzahl SQL-Statments, die an die DB-Klasse übergeben wurden, aus!
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Count() As Integer
        Get
            Return m_Count
        End Get
        Set(ByVal value As Integer)
            m_Count = value
        End Set
    End Property

    Public Property sqlTable() As String
        Get
            Return m_Tables(m_Count - 1)
        End Get
        Set(ByVal value As String)
            ReDim Preserve m_Tables(m_Count - 1)
            m_Tables(m_Count - 1) = value
        End Set
    End Property

    Public Property SQL() As String
        Get
            Return m_SQLs(m_Count - 1)
        End Get
        Set(ByVal value As String)
            ReDim Preserve m_SQLs(m_Count - 1)
            m_SQLs(m_Count - 1) = value
        End Set
    End Property

    Public Function SQLbyIndex(ByVal idx As Integer) As String
        If idx < m_SQLs.GetLowerBound(0) Then Return ""
        If idx > m_SQLs.GetUpperBound(0) Then Return ""
        Return m_SQLs(idx)
    End Function

    Public Function TablebyIndex(ByVal idx As Integer) As String
        If idx < m_Tables.GetLowerBound(0) Then Return ""
        If idx > m_Tables.GetUpperBound(0) Then Return ""
        Return m_Tables(idx)
    End Function

    Public Property sqlDatenbank() As Long
        Get
            Return m_Datenbanken(m_Count - 1)
        End Get
        Set(ByVal value As Long)
            ReDim Preserve m_Datenbanken(m_Count - 1)
            m_Datenbanken(m_Count - 1) = value
        End Set
    End Property

    Public Sub AddSQL(ByVal Sql As String, Optional ByVal Tablename As String = "Table", Optional ByVal Datenbank As Long = -1)
        Dim index As Integer = m_Count
        m_Count += 1

        ReDim Preserve m_SQLs(index)
        ReDim Preserve m_Tables(index)
        ReDim Preserve m_Datenbanken(index)

        m_SQLs(index) = Sql
        If Tablename = "Table" Then
            m_Tables(index) = "Table" & index
        Else
            m_Tables(index) = Tablename
        End If
        If Datenbank < 0 Then
            m_Datenbanken(index) = m_lngDatenbank
        Else
            m_Datenbanken(index) = Datenbank
        End If
    End Sub

    Public Sub ClearSQL()
        Erase m_Tables
        Erase m_SQLs
        Erase m_Datenbanken
        m_Count = 0
    End Sub

    Public Function Ausführen_SQL(Optional ByVal SQL As String = "", Optional ByVal Datenbank As Long = -1) As Boolean
        Dim Erfolg As Boolean = False
        Dim ds As DataSet = Hole_daten(SQL, "", Datenbank)
        If Not ds Is Nothing Then
            If Not ds.Tables.Contains("Fehler") Then Erfolg = True
        End If
        Return Erfolg
    End Function

    Public Function ExecSQL(SQL As String,
                            Optional Tabellenname As String = "Table", Optional Datenbank As Long = -1,
                            Optional mitSchema As Boolean = True, Optional istAsynchron As Boolean = False) As DataSet
        Dim ds As New DataSet
        If SQL <> "" Then Me.AddSQL(SQL, Tabellenname, Datenbank)
        ds = Hole_daten_lokal(mitSchema, istAsynchron)
        Me.ClearSQL()
        Return ds
    End Function

    Public Function Hole_daten(Optional ByVal SQL As String = "", Optional ByVal Tabellenname As String = "Table", Optional ByVal Datenbank As Long = -1, Optional ByVal Schema As Boolean = True, Optional ByVal Protokollieren As Boolean = False) As DataSet
        Dim ds As New DataSet
        Dim Startzeit As Date = Now
        If SQL <> "" Then Me.AddSQL(SQL, Tabellenname, Datenbank)

        ds = Hole_daten_lokal(Schema, IIf(Schema, False, True))
        Me.ClearSQL()
        Return ds
    End Function

    Public Function Hole_daten_asynch(Optional ByVal SQL As String = "", Optional ByVal Tabellenname As String = "Table", Optional ByVal Datenbank As Long = -1) As DataSet
        Dim ds As New DataSet
        If SQL <> "" Then Me.AddSQL(SQL, Tabellenname, Datenbank)
        ds = Hole_daten_lokal(False, True)
        Me.ClearSQL()
        Return ds
    End Function

    Private Function sqls_asString() As String
        Dim s As New System.Text.StringBuilder
        If m_SQLs IsNot Nothing Then
            For i As Integer = m_SQLs.GetLowerBound(0) To m_SQLs.GetUpperBound(0)
                s.AppendLine(m_SQLs(i))
            Next
        End If
        Return s.ToString
    End Function

    Private Function Hole_daten_lokal(mitSchema As Boolean, istAsynchron As Boolean)
        If m_SQLs Is Nothing Then Return Nothing
        Dim DS As New DataSet
        Dim idx As Integer
        Dim sqlstapel As New System.Text.StringBuilder()
        Dim sqlidxvon As Integer = 0
        Dim sqlidxbis As Integer = 0
        Dim lastDatenbank As Long = m_Datenbanken(0)

        For idx = 0 To m_SQLs.Length - 1
            If lastDatenbank <> m_Datenbanken(idx) Then
                If sqlstapel.Length > 0 Then
                    If (Hole_daten_Stapel(DS, sqlstapel.ToString(), lastDatenbank, mitSchema, istAsynchron)) Then
                        Try
                            For idxT As Integer = sqlidxvon To sqlidxbis
                                If m_Tables(idxT).Length > 0 Then
                                    Try
                                        DS.Tables(idxT).TableName = m_Tables(idxT)
                                    Catch ex As Exception ' Tabelle x kann nicht gefunden werden ignorieren
                                    End Try
                                Else
                                    Try
                                        DS.Tables(idxT).TableName = "T_" & idxT
                                    Catch ex As Exception ' Tabelle x kann nicht gefunden werden ignorieren
                                    End Try
                                End If
                            Next idxT
                        Catch ex As Exception ' Wenn m_Tables Nothing ist oder idxT > m_Tables.Length gibts einen Fehler - Das passiert wenn sich zwei Abfragen aus der selben Quelle zeitlich überschneiden
                        End Try
                        sqlidxvon += 1
                    End If
                End If
                lastDatenbank = m_Datenbanken(idx)
                sqlstapel.Length = 0
            End If
            If sqlstapel.Length > 0 Then sqlstapel.Append(" ")
            sqlstapel.Append(m_SQLs(idx))
            sqlidxbis = idx
        Next idx

        If lastDatenbank >= 0 Then
            If sqlstapel.Length > 0 Then
                If (Hole_daten_Stapel(DS, sqlstapel.ToString(), lastDatenbank, mitSchema, istAsynchron)) Then
                    Try
                        For idxT As Integer = sqlidxvon To sqlidxbis
                            If m_Tables(idxT).Length > 0 Then
                                Try
                                    DS.Tables(idxT).TableName = m_Tables(idxT)
                                Catch ex As Exception ' Tabelle x kann nicht gefunden werden ignorieren
                                End Try
                            Else
                                Try
                                    DS.Tables(idxT).TableName = "T_" & idxT
                                Catch ex As Exception ' Tabelle x kann nicht gefunden werden ignorieren
                                End Try
                            End If
                        Next idxT
                    Catch ex As Exception ' Wenn m_Tables Nothing ist oder idxT > m_Tables.Length gibts einen Fehler - Das passiert wenn sich zwei Abfragen aus der selben Quelle zeitlich überschneiden
                    End Try
                End If
            End If
        End If
        Return DS
    End Function

    Private Function Hole_daten_Stapel(DS As DataSet, sqlstapel As String, Datenbank As Long, mitSchema As Boolean, istAsynchron As Boolean) As Boolean
        'mitSchema = Not istAsynchron ' axel
        Dim adapter As SqlDataAdapter
        Dim countVersuche As Integer = 0
nocheinmalversuchen:
        countVersuche += 1
        Try
            If istAsynchron Then
                adapter = New SqlDataAdapter(sqlstapel, m_oDB.DBConnectionString(Datenbank))
            Else
                adapter = New SqlDataAdapter(sqlstapel, m_oDB.DBConnection(Datenbank))
            End If
            adapter.SelectCommand.CommandTimeout = Me.CommandTimeout
            If mitSchema Then adapter.FillSchema(DS, SchemaType.Mapped)
            adapter.Fill(DS)
            adapter = Nothing
            Return True
        Catch ex As Exception
            ' Beim Lesen mit Schema kann es u.U. dazu kommen, dass die Einschränkungen nicht aktiviert werden können.
            If mitSchema AndAlso countVersuche <= 1 Then
                If ex.Message.Contains("Einschränkungen konnten nicht aktiviert werden. Mindestens eine Zeile enthält Werte die die Einschränkungen non-null, unique or foreign-key verletzen.") Then
                    If DS Is Nothing OrElse DS.Tables.Count = 0 Then
                        'Wenn noch keine Daten eingelesen wurden, dann erneut versuchen
                        mitSchema = False
                        GoTo nocheinmalversuchen
                    Else
                        'Wenn bereits Daten eingelesen wurden, ignorieren und geordneter Abzug.
                        adapter = Nothing
                        Return True
                    End If
                End If
            End If
            If Not DS.Tables.Contains("Fehler") Then
                Dim dt_Fehler As New DataTable
                dt_Fehler.TableName = "Fehler"
                dt_Fehler.Columns.Add("Tabelle")
                dt_Fehler.Columns.Add("Meldung")
                DS.Tables.Add(dt_Fehler)
            End If
            Dim msg As New System.Text.StringBuilder
            msg.AppendLine(ex.Message)
            Dim stack As String = ""
            Try
                stack = Environment.StackTrace
            Catch exEStack As Exception
            End Try
            If stack.Length > 0 Then
                msg.AppendLine("")
                msg.AppendLine("Stacktrace:")
                msg.AppendLine(stack)
            End If
            If sqlstapel.Length > 0 Then
                msg.AppendLine("")
                msg.AppendLine("SQL:")
                msg.AppendLine(sqlstapel)
            End If
            DS.Tables("Fehler").Rows.Add(Datenbank, msg.ToString)
            If Not ex.InnerException Is Nothing Then DS.Tables("Fehler").Rows.Add("Service", ex.InnerException.Message)
            Return False
        End Try
    End Function

    'Public Function ExecuteWebservice(ByVal Methodenname As String, ByVal args() As Object, Optional ByVal webservice As Webservicezugriff = Nothing, Optional ByVal bDeserialize As Boolean = True, Optional bSilentError As Boolean = False)
    '    Dim _rt As Object = Nothing
    '    Try
    '        If webservice Is Nothing Then webservice = Webservices.Datenservice
    '        Select Case webservice.Url.ToLower
    '            Case "dmsdienst", "datadienst", "brokerdienst"
    '                'ein Dienst soll verwendet werden
    '                _rt = Dienst.CallMethod(webservice.Url.ToLower, Methodenname, args, bSilentError)
    '            Case Else
    '                'normaler Webservice
    '                Dim objCallWS As New DynamicWebService
    '                _rt = objCallWS.CallWebService(webservice.Login, webservice.Password, webservice.Url, webservice.Webklasse, Methodenname, args, 0)
    '                objCallWS = Nothing
    '        End Select
    '        If bDeserialize Then
    '            If _rt IsNot Nothing AndAlso _rt.GetType.Name = "Byte[]" Then _rt = DS_Deserialize(_rt)
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return _rt
    'End Function

    Public Function getConnection(ByVal welche As ConnPool.DB_Collection) As String
        Try
            Return m_oDB.DBConnectionString(welche)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public ReadOnly Property DBName(ByVal welche As ConnPool.DB_Collection) As String
        Get
            Try
                Return m_oDB.DBName(welche)
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
End Class

' -------------------------------------------------------------------------------------------------------------------------------
' Module Connectionstrings
' -------------------------------------------------------------------------------------------------------------------------------
Public Module Connectionstrings
    Private _htEintraege As New Hashtable
    'Arraygröße über die Anzahl der Elemente in der Enumeration definieren
    Public Datenbank_Connect([Enum].GetValues(GetType(ConnPool.DB_Collection)).Length - 1) As SqlConnection 'hält die eigentlichen Connections vor
    Public Connect_Strings([Enum].GetValues(GetType(ConnPool.DB_Collection)).Length - 1) As String 'hält die jeweiligen Connections-Strings vor
    Public DB_Was_Opened As Boolean = False

    Public Sub Set_Connection_Strings()
        DB_Was_Opened = True
        Dim StrConnectionString As String
        'Enumeration abarbeiten
        Dim ar As System.Array = [Enum].GetValues(GetType(ConnPool.DB_Collection))
        Dim dbkenner As Object = New ConnPool.DB_Collection
        For Each dbkenner In ar
            'Für jeden Kenner den entsprechenden Connectionstring ermitteln
            StrConnectionString = getConnectionString(dbkenner)
            If StrConnectionString.Length > 0 Then
                'Connection (direkt im Array) erzeugen
                Datenbank_Connect(dbkenner) = New SqlConnection
                'SqlConnection.ClearPool(Datenbank_Connect(dbkenner))
                'Die Connections-Strings seperat speichern; 
                '   werden für den asynchronen Datenzugriff benötigt, da die Connectionstring-Eigenschaft des 
                '   Connection-Objekts kein Paßwort enthält, was natürlich zu Problemen führt!
                Connect_Strings(dbkenner) = StrConnectionString
                Datenbank_Connect(dbkenner).ConnectionString = Connect_Strings(dbkenner)
            End If
        Next
    End Sub

    Private Function getConnectionString(welcher As ConnPool.DB_Collection) As String
        If _htEintraege Is Nothing OrElse _htEintraege.Count = 0 Then Config.LeseConfigData(_htEintraege)
        Dim sKey As String = FNC.GetEnumDescription(welcher)
        If _htEintraege.Contains(sKey) Then Return _htEintraege(sKey)
        Return ""
    End Function

    Public Sub Close_All_SqlConnections()

        DB_Was_Opened = False
        Dim connectString As String = ""

        Dim arrEnumValues_DBCollection As System.Array = System.Enum.GetValues(GetType(ConnPool.DB_Collection))
        Dim dbkenner As Object = New ConnPool.DB_Collection

        For Each dbkenner In arrEnumValues_DBCollection
            connectString = getConnectionString(dbkenner)
            If connectString.Length > 0 Then
                Try
                    Datenbank_Connect(dbkenner).Close()
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
#End Region
End Module
