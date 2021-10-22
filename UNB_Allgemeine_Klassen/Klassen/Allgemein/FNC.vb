Public Class FNC
#Region "Enumerationen"
    Public Enum enmFNC
        FFString = 1
        FFLong = 2
        FFDecimal = 3
    End Enum
#End Region
    Public Shared Function FF(value As Object) As String
        Return FF(value, enmFNC.FFString)
    End Function
    Public Shared Function FF(value As Object, Art As enmFNC) As String
        If Art = enmFNC.FFString Then
            If value Is Nothing Then Return ""
            If IsDBNull(value) Then Return ""
            Return CStr(value).Trim
        ElseIf Art = enmFNC.FFLong Then
            If value Is Nothing Then Return 0
            If IsDBNull(value) Then Return 0
            Return CLng(value)
        ElseIf Art = enmFNC.FFDecimal Then
            If value Is Nothing Then Return 0.0
            If IsDBNull(value) Then Return 0.0
            Return CDec(value)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function DBText(value As Object) As String
        Dim rtString As String = FNC.FF(value, enmFNC.FFString)
        If rtString.Length = 0 Then Return "''"
        rtString = rtString.Replace("'", "''")
        Return "'" & rtString & "'"
    End Function

    Public Shared Function DBZahl(value As Object) As String
        Dim rtString As String = FNC.FF(value, enmFNC.FFDecimal)
        If rtString.Length = 0 Then Return "0"
        rtString = rtString.Replace(".", "") ' Tausender-Trennzeichen entfernen
        rtString = rtString.Replace(",", ".") ' Decimal-Trennzeichen DB-Konform wandeln
        Return rtString
    End Function

    Public Shared Function SQLAbruf_String(SQL As String) As String
        On Error Resume Next
        Dim rtString As String = ""
        If SQL.Length > 0 Then
            Dim DB As New DB
            Using DT As DataTable = DB.ReadData(SQL, "X") : SQL = ""
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        rtString = FNC.FF(DT.Rows(0).Item("WERT"), enmFNC.FFString)
                    End If
                End If
            End Using
        End If
        Return rtString
    End Function
    Public Shared Function SQLAbruf_Long(SQL As String) As Long
        On Error Resume Next
        Dim rtLong As Long = 0
        If SQL.Length > 0 Then
            Dim DB As New DB
            Using DT As DataTable = DB.ReadData(SQL, "X") : SQL = ""
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        rtLong = FNC.FF(DT.Rows(0).Item("WERT"), enmFNC.FFLong)
                    End If
                End If
            End Using
        End If
        Return rtLong
    End Function
    Public Shared Function SQLAbruf_Decimal(SQL As String) As Decimal
        On Error Resume Next
        Dim rtDecimal As Decimal = 0.0
        If SQL.Length > 0 Then
            Dim DB As New DB
            Using DT As DataTable = DB.ReadData(SQL, "X") : SQL = ""
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        rtDecimal = FNC.FF(DT.Rows(0).Item("WERT"), enmFNC.FFDecimal)
                    End If
                End If
            End Using
        End If
        Return rtDecimal
    End Function
    Public Shared Function Execute_SQL(SQL As String) As Boolean
        Dim rtBool As Boolean = False
        Dim DB As New DB
        rtBool = DB.ExecuteSQL(SQL)
        Return rtBool
    End Function

    Public Shared Function GetEnumValueDescription(ByVal EnumConstant As [Enum]) As String
        Return GetEnumValueDescription(EnumConstant, " ")
    End Function
    Public Shared Function GetEnumValueDescription(ByVal EnumConstant As [Enum], Delimiter As String) As String
        Return GetEnumValue(EnumConstant) & Delimiter & GetEnumDescription(EnumConstant, EnumConstant.ToString())
    End Function
    Public Shared Function GetEnumDescriptionValue(ByVal EnumConstant As [Enum]) As String
        Return GetEnumDescription(EnumConstant, EnumConstant.ToString()) & " (" & GetEnumValue(EnumConstant) & ")"
    End Function
    Public Shared Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
        Return GetEnumDescription(EnumConstant, EnumConstant.ToString())
    End Function
    Public Shared Function GetEnumDescription(ByVal EnumConstant As [Enum], ByVal defaultvalue As String) As String
        Dim back As String = defaultvalue
        '   Fehler die hier auftreten sind nicht relevant; wenn ungültige Enum-Konstante dann den Defaultwert zurückliefern
        Try
            Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
            Dim attr() As System.ComponentModel.DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False), System.ComponentModel.DescriptionAttribute())
            If attr.Length > 0 Then
                back = attr(0).Description
                If back.Length = 0 Then back = defaultvalue
            End If
        Catch ex As Exception
        End Try
        Return back
    End Function
    Public Shared Function GetEnumDescription(ByVal EnumType As Type, ByVal Key As Integer) As String
        If [Enum].IsDefined(EnumType, Key) Then
            Return GetEnumDescription([Enum].ToObject(EnumType, Key))
        Else
            Return ""
        End If
    End Function
    Public Shared Function GetEnumValue(ByVal EnumConstant As [Enum]) As Integer
        Return CType(System.Enum.Parse(EnumConstant.GetType(), EnumConstant.ToString), Integer)
    End Function


#Region "Verschlüsselung"
    ''' <summary>
    ''' Kodiert eine Zeichenfolge.
    ''' </summary>
    ''' <param name="Zeichen">Die zu kodierende Zeichenfolge</param>
    ''' <returns>Die kodierte Zeichenfolge</returns>
    ''' <remarks></remarks>
    Public Shared Function String_Code(ByVal Zeichen As String) As String
        Dim S As String
        Dim Z As Long
        Dim ZS As String
        Dim A As Long
        Dim P As String
        ZS = Space(Len(Zeichen))
        S = "I>4QB2;TWL3_U=GN/8J6D<SC5OV?KZ7XR@PF.90H^MY:E1Ahg[kb]iwlopvmenx\dfjcqysr`tuza"
        For Z = 1 To Len(Zeichen)
            P = Mid(Zeichen, Z, 1)
            A = Asc(P)
            If P >= "." And P <= "z" Then P = Mid(S, Asc(P) - 45, 1)
            Mid(ZS, Z) = P
        Next Z
        String_Code = ZS
    End Function
    ''' <summary>
    ''' De-Kodiert eine Zeichenfolge
    ''' </summary>
    ''' <param name="Zeichen">Die kodierte Zeichenfolge</param>
    ''' <returns>Die de-kodierte Zeichenfolge</returns>
    ''' <remarks></remarks>
    Public Shared Function String_DeCode(ByVal Zeichen As String) As String
        Dim S As String
        Dim Z As Long
        Dim ZS As String
        Dim P As String
        ZS = Space(Len(Zeichen))
        S = "I>4QB2;TWL3_U=GN/8J6D<SC5OV?KZ7XR@PF.90H^MY:E1Ahg[kb]iwlopvmenx\dfjcqysr`tuza"
        For Z = 1 To Len(Zeichen)
            P = Mid(Zeichen, Z, 1)
            If P >= "." And P <= "z" Then P = Chr(InStr(S, P) + 45)
            Mid(ZS, Z) = P
        Next Z
        String_DeCode = ZS
    End Function
#End Region
End Class
