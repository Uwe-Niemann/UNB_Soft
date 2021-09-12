Public Class FNC
#Region "Enumerationen"
    Public Enum enmFFArten
        FFString = 1
        FFLong = 2
    End Enum
#End Region
    Friend Shared Function FF(value As Object) As Object
        Return FF(value, enmFFArten.FFString)
    End Function

    Friend Shared Function FF(value As Object, FFArt As enmFFArten) As Object
        Dim rtObject As Object = Nothing
        Try
            If FFArt = enmFFArten.FFString Then
                If value Is Nothing Then Return ""
                If IsDBNull(value) Then Return ""
                rtObject = CStr(value).Trim
            ElseIf FFArt = enmFFArten.FFLong Then
                If value Is Nothing Then Return 0
                If IsDBNull(value) Then Return 0
                If Not IsNumeric(value) Then Return 0
                rtObject = CLng(value)
            End If
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, "")
        End Try
        '
        Return rtObject
    End Function

    Friend Shared Function DB_Text(value As Object) As String
        Dim rtString As String = ""
        If FF(value).Length = 0 Then Return rtString
        rtString = FF(value)
        If rtString.Contains("'") Then rtString = rtString.Replace("'", "''")
        Return "'" & rtString & "'"
    End Function
    Friend Shared Sub KeyPress(e As KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Return) Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Friend Shared Function ReadAppConfig(Key As String, DefaultValue As String) As String
        Dim rtString As String = DefaultValue
        Dim sValue As String = System.Configuration.ConfigurationManager.AppSettings.Get(Key)
        If FNC.FF(sValue).Length > 0 Then
            rtString = sValue
        End If
        Return rtString
    End Function
    Friend Shared Sub WriteAppConfig(Key As String, Value As String)
        Dim ConfigFile As System.Configuration.Configuration = Nothing
        Dim Settings As System.Configuration.KeyValueConfigurationCollection = Nothing
        Try
            ConfigFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None)
            Settings = ConfigFile.AppSettings.Settings
            If Settings(Key) Is Nothing Then
                Settings.Add(Key, Value)
            Else
                Settings(Key).Value = Value
            End If
            ConfigFile.Save(System.Configuration.ConfigurationSaveMode.Modified)
            System.Configuration.ConfigurationManager.RefreshSection(ConfigFile.AppSettings.SectionInformation.Name)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
