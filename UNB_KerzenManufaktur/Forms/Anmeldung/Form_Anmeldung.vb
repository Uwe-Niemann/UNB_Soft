Imports System.ComponentModel
Imports Allgemeine_Klassen

Public Class Form_Anmeldung
#Region "Enumerationen"
    Private Enum enmHandler
        Add = 0
        Remove = 1
    End Enum
#End Region
#Region "Deklarationen"
    Public Event event_SendMessage(sender As Object, e As Allgemeine_Klassen.UNB_EventArgs)
#End Region
#Region "Form-Events"
    Private Sub event_Form_Anmeldung_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub event_Form_Anmeldung_Load(sender As Object, e As EventArgs) Handles Me.Load
        Allgemeine_Klassen.Connectionstrings.Set_Connection_Strings()
#If DEBUG Then
        Txt_AnmeldeName.Text = FNC.String_DeCode("HRD-9fos")
        Txt_Passwort.Text = FNC.String_DeCode("sbdaqbssl")
#End If
    End Sub

    Private Sub event_Form_Anmeldung_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Handler(enmHandler.Add)
#If DEBUG Then
        Btn_Anmelden.Focus()
#Else
        If FNC.FF(Txt_AnmeldeName.Text).Length > 0 Then
            Txt_Passwort.Focus()
        Else
            Txt_AnmeldeName.Focus()
        End If
#End If
    End Sub
#End Region
#Region "Events"
#Region "Textbox"
    Private Sub event_Textbox_GotFocus(sender As Object, e As EventArgs)
        Dim TB As TextBox = sender
        TB.BackColor = Drawing.Color.Yellow
    End Sub

    Private Sub event_Textbox_LostFocus(sender As Object, e As EventArgs)
        Dim TB As TextBox = sender
        TB.BackColor = Drawing.Color.White
        If TB.Name = Txt_NeuesPW.Name Then Btn_Anmelden.Focus()
    End Sub

#End Region
#Region "Button"
    Private Sub event_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Btn As Button = sender
        Try
            Select Case Btn.Name
                Case Btn_Abbruch.Name
                    End ' Programm beenden
                Case Btn_Anmelden.Name
                    Anmeldung_Auswerten
            End Select
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(sender, ""))
        End Try
    End Sub
#End Region

#Region "Anmeldung"
    Private Sub Anmeldung_Auswerten()
        Try
            If TabCtrl_Anmeldung.SelectedTab Is TP_Anmelden Then
                Anmeldung_Starten
            ElseIf TabCtrl_Anmeldung.SelectedTab Is TP_NeuesPasswort Then
                Passwort_Ändern_Starten
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Anmeldung_Starten()
        Try
            If FNC.FF(Txt_AnmeldeName.Text).Length = 0 Then
                Txt_AnmeldeName.Focus()
                MsgBox("Bitte einen Anmeldenamen eingeben", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            If FNC.FF(Txt_Passwort.Text).Length = 0 Then
                Txt_Passwort.Focus()
                MsgBox("Bitte ein Passwort eingeben", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            Dim bAnmeldungOK As Boolean = False
            Dim sbSQL As New System.Text.StringBuilder
            sbSQL.Append("SELECT DSID, BENUTZER_NAME, PASSWORT FROM FKM_BENUTZER With (NoLock) WHERE LOGIN_NAME=" & FNC.DBText(Txt_AnmeldeName.Text))
            Dim DB As New DB
            Dim oBenutzer As Benutzer_Objekt = Nothing
            Using DT As DataTable = DB.ReadData(sbSQL.ToString, "X") : sbSQL.Length = 0
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        For Each DRow As DataRow In DT.Rows
                            If FNC.FF(DRow("PASSWORT")) = FNC.String_Code(Txt_Passwort.Text) Then
                                oBenutzer = New Benutzer_Objekt With {.UserID = FNC.FF(DRow("DSID"), FNC.enmFNC.FFLong), .UserName = FNC.FF(DRow("BENUTZER_NAME"))}
                                bAnmeldungOK = True
                                Exit For
                            End If
                        Next DRow
                    End If
                End If
            End Using
            If bAnmeldungOK = True Then
                Dim EvtArgs As New UNB_EventArgs
                EvtArgs.UserObject = oBenutzer
                Me.Close()
                RaiseEvent event_SendMessage(Me, EvtArgs)
            Else
                MsgBox("Sie haben keine Berechtigung für dieses Programm", vbOKOnly + vbInformation, "Anmeldung")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Passwort_Ändern_Starten()
        Try
            If FNC.FF(Txt_AktuellesPW.Text).Length = 0 Then
                Txt_AktuellesPW.Focus()
                MsgBox("Bitte ein Passwort eingeben", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            If FNC.FF(Txt_NeuesPW.Text).Length = 0 Then
                Txt_NeuesPW.Focus()
                MsgBox("Bitte ein neues Passwort eingeben", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            If FNC.FF(Txt_NeuesPW2.Text).Length = 0 Then
                Txt_NeuesPW2.Focus()
                MsgBox("Bitte neues Passwort wiederholen eingeben", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            If FNC.FF(Txt_NeuesPW.Text) <> FNC.FF(Txt_NeuesPW2.Text) Then
                Txt_NeuesPW.Text = "" : Txt_NeuesPW2.Text = ""
                Txt_NeuesPW.Focus()
                MsgBox("Neue Passwörter stimmen nicht überein", vbOKOnly + vbInformation, "Anmelden")
                Exit Sub
            End If
            '
            Dim bAnmeldungOK As Boolean = False
            Dim sbSQL As New System.Text.StringBuilder
            sbSQL.Append("SELECT DSID, PASSWORT, BENUTZER_NAME FROM FKM_BENUTZER With (NoLock) WHERE LOGIN_NAME=" & FNC.DBText(Txt_AnmeldeName.Text))
            Dim DB As New DB
            Dim oBenutzer As Benutzer_Objekt = Nothing
            Dim DSID As Long = 0
            Using DT As DataTable = DB.ReadData(sbSQL.ToString, "X") : sbSQL.Length = 0
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        For Each DRow As DataRow In DT.Rows
                            If FNC.FF(DRow("PASSWORT")) = FNC.String_Code(Txt_AktuellesPW.Text) Then
                                sbSQL.AppendLine("UPDATE FKM_BENUTZER SET PASSWORT=" & FNC.DBText(FNC.String_Code(Txt_NeuesPW.Text)) & " WHERE DSID=" & FNC.FF(DRow("DSID"), FNC.enmFNC.FFLong))
                                If FNC.Execute_SQL(sbSQL.ToString) Then
                                    Txt_AktuellesPW.Text = ""
                                    Txt_NeuesPW.Text = ""
                                    Txt_NeuesPW2.Text = ""
                                    oBenutzer = New Benutzer_Objekt With {.UserID = FNC.FF(DRow("DSID"), FNC.enmFNC.FFLong), .UserName = FNC.FF(DRow("BENUTZER_NAME"))}
                                    MsgBox("Das Passwort wurde gespeichert." & vbCrLf & "Sie werden nun mit dem neuen Passwort angemeldet.", vbOKOnly + vbInformation, "Anmelden")
                                    bAnmeldungOK = True
                                    Exit For
                                Else
                                    MsgBox("Das Passwort konnte nicht gespeichert werden!", vbOKOnly + vbInformation, "Anmelden")
                                End If
                            Else
                                Txt_Passwort.Text = ""
                                Txt_NeuesPW.Text = ""
                                Txt_NeuesPW2.Text = ""
                                Txt_Passwort.Focus()
                                MsgBox("Aktuelles Passwort stimmt nicht überein", vbOKOnly + vbInformation, "Anmelden")
                                Exit Sub
                            End If
                        Next DRow
                    End If
                End If
            End Using
            '
            If bAnmeldungOK = True Then
                Dim EvtArgs As New UNB_EventArgs
                EvtArgs.UserObject = oBenutzer
                Me.Close()
                RaiseEvent event_SendMessage(Me, EvtArgs)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
#Region "TabControl"
    Private Sub event_TabControl_SelectedIndexChanged(sender As Object, e As EventArgs)
        If TabCtrl_Anmeldung.SelectedTab Is TP_Anmelden Then
            Txt_AktuellesPW.Text = ""
            Txt_NeuesPW.Text = ""
            Txt_NeuesPW2.Text = ""
            If FNC.FF(Txt_AnmeldeName.Text).Length = 0 Then
                Txt_AnmeldeName.Focus()
            Else
                Txt_Passwort.Focus()
            End If
        ElseIf TabCtrl_Anmeldung.SelectedTab Is TP_NeuesPasswort Then
            Txt_Passwort.Text = ""
            TxtAnmeldung2.ReadOnly = False
            TxtAnmeldung2.Text = Txt_AnmeldeName.Text
            TxtAnmeldung2.ReadOnly = True
            Txt_AktuellesPW.Focus()
        End If
    End Sub
#End Region
#End Region
#Region "Allgemeine Property, Methoden und Funktionen"
    Private Sub Handler(Aktion As enmHandler)
        RemoveHandler Txt_AktuellesPW.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler Txt_AnmeldeName.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler Txt_NeuesPW.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler Txt_Passwort.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler Txt_AktuellesPW.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler Txt_AnmeldeName.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler Txt_NeuesPW.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler Txt_Passwort.GotFocus, AddressOf event_Textbox_GotFocus
        '
        RemoveHandler Btn_Abbruch.Click, AddressOf event_Button_Click
        RemoveHandler Btn_Anmelden.Click, AddressOf event_Button_Click

        RemoveHandler TabCtrl_Anmeldung.SelectedIndexChanged, AddressOf event_TabControl_SelectedIndexChanged

        If Aktion = enmHandler.Add Then
            AddHandler Txt_AktuellesPW.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler Txt_AnmeldeName.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler Txt_NeuesPW.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler Txt_Passwort.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler Txt_AktuellesPW.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler Txt_AnmeldeName.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler Txt_NeuesPW.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler Txt_Passwort.GotFocus, AddressOf event_Textbox_GotFocus

            AddHandler Btn_Abbruch.Click, AddressOf event_Button_Click
            AddHandler Btn_Anmelden.Click, AddressOf event_Button_Click

            AddHandler TabCtrl_Anmeldung.SelectedIndexChanged, AddressOf event_TabControl_SelectedIndexChanged
        End If
    End Sub

    Private Function getErrorInfo(sender As Object, ZusatzInfo As String)
        Dim rtString As String = ""
        Try
            If sender IsNot Nothing Then
                rtString = "sender.Name=" & sender.Name
            Else
            End If
        Catch ex As Exception
        Finally
            If ZusatzInfo.Length > 0 Then
                rtString &= "|" & ZusatzInfo
            End If
        End Try
        Return rtString
    End Function
#End Region

End Class