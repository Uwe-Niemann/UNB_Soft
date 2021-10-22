Imports Allgemeine_Klassen
Public Class DlgEinheiten
#Region "Enumerationen"
    Private Enum enmHandler
        Add = 0
        Remove = 1
    End Enum
    Private Enum enmCellArt
        Textbox = 1
        Image = 2
    End Enum
#End Region
#Region "Deklarationen"
    Private oSQL As New SQL_Einheiten
    Private _DSID As Long = 0
    Private _bMussNochSpeichern As Boolean = False
#End Region
#Region "Form-Events"
    Private Sub event_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Focus()
        If Not Check_ObDatenBearbeitetWurden("Schließen") Then e.Cancel = True : Exit Sub
    End Sub

    Private Sub event_Form_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub event_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _DSID = 0 Then
            Me.Text = "Neue Einheit erfassen"
        Else
            Me.Text = "Einheit bearbeiten"
        End If
        Lade_Daten()
    End Sub

    Private Sub event_Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtBez.Focus()
    End Sub
#End Region

#Region "Daten laden, Neuanlage, Bearbeiten, Löschen"
    Private Sub Lade_Daten()
        Try
            Cursor = Cursors.WaitCursor
            Handler(enmHandler.Remove)
            Using DT As DataTable = oSQL.Lade_Daten(_DSID)
                If DT IsNot Nothing Then
                    If DT.Rows.Count > 0 Then
                        txtBez.Text = FNC.FF(DT.Rows(0).Item("BEZ"))
                        TxtEkFaktor.Text = FNC.FF(DT.Rows(0).Item("EINKAUF_FAKTOR"), FNC.enmFNC.FFDecimal)
                        txtFaktor.Text = FNC.FF(DT.Rows(0).Item("FAKTOR"), FNC.enmFNC.FFDecimal)
                    Else
                        txtBez.Text = ""
                        TxtEkFaktor.Text = ""
                        txtFaktor.Text = ""
                    End If
                    txtBez.Tag = txtBez.Text
                    TxtEkFaktor.Tag = TxtEkFaktor.Text
                    txtFaktor.Tag = txtFaktor.Text
                End If
            End Using
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        Finally
            Handler(enmHandler.Add)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function Daten_Speichern() As Boolean
        Dim rtBool As Boolean = False
        If _bMussNochSpeichern Then
            If FNC.FF(txtBez.Text).Length = 0 Then
                txtBez.Focus()
                MsgBox("Bitte eine Bezeichnung eingeben", vbOKOnly + MsgBoxStyle.Information, "Speichern")
                Return False
            End If
            If FNC.FF(TxtEkFaktor.Text, FNC.enmFNC.FFLong) = 0 Then
                TxtEkFaktor.Focus()
                MsgBox("Bitte einen Wert > 0 eingeben", vbOKOnly + MsgBoxStyle.Information, "Speichern")
                Return False
            End If
            If FNC.FF(txtFaktor.Text, FNC.enmFNC.FFLong) = 0 Then
                txtFaktor.Focus()
                MsgBox("Bitte einen Wert > 0 eingeben", vbOKOnly + MsgBoxStyle.Information, "Speichern")
                Return False
            End If
            '
            Dim sbSQL As New System.Text.StringBuilder
            If DSID = 0 Then
                sbSQL.AppendLine("Declare @TabellenVariable Table (DSID Int)")
                sbSQL.AppendLine("INSERT INTO FKM_MENGEN_EINHEITEN (ANGELEGT_VON, BEZ, EINKAUF_FAKTOR, FAKTOR)")
                sbSQL.AppendLine("Output inserted.DSID into @TabellenVariable")
                sbSQL.Append("VALUES(1")
                sbSQL.Append(", " & FNC.DBText(txtBez.Text))
                sbSQL.Append(", " & FNC.DBZahl(TxtEkFaktor.Text))
                sbSQL.Append(", " & FNC.DBZahl(txtFaktor.Text))
                sbSQL.AppendLine(")") ' Schließende Klammer Values
                sbSQL.AppendLine("SELECT DSID WERT FROM @TabellenVariable")
                _DSID = FNC.SQLAbruf_Long(sbSQL.ToString) : sbSQL.Length = 0
                rtBool = _DSID > 0
            Else
                sbSQL.AppendLine("UPDATE FKM_MENGEN_EINHEITEN SET GEAENDERT_AM=getdate(), GEAENDERT_VON=1")
                sbSQL.Append(", BEZ=" & FNC.DBText(txtBez.Text))
                sbSQL.Append(", EINKAUF_FAKTOR=" & FNC.DBZahl(TxtEkFaktor.Text))
                sbSQL.Append(", FAKTOR=" & FNC.DBZahl(txtFaktor.Text))
                sbSQL.AppendLine(" WHERE DSID=" & _DSID)
                rtBool = oSQL.Ausführen_SQL(sbSQL.ToString) : sbSQL.Length = 0
            End If
            If rtBool Then
                _bMussNochSpeichern = False
            End If
        Else
            rtBool = True
        End If
        Return rtBool
    End Function
#End Region
#Region "Events"
    Private Sub event_Button_Click(sender As Object, e As System.EventArgs)
        Dim Btn As Button = sender
        Try
            Select Case Btn.Name
                Case Cmd_Abbrechen.Name
                    If Not Check_ObDatenBearbeitetWurden("Schließen") Then Exit Sub
                    Me.DialogResult = DialogResult.Cancel
                Case Cmd_Speichern.Name
                    If Daten_Speichern() Then
                        Me.DialogResult = DialogResult.OK
                    Else
                        Exit Sub
                    End If
            End Select
            '
            Me.Close()
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(sender, ""))
        End Try
    End Sub

    Private Sub event_Textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Dim TB As TextBox = sender
        Select Case e.KeyCode
            Case Keys.D0 To Keys.D9, Keys.NumPad0 To Keys.NumPad9, Keys.Back, Keys.Home, Keys.Delete, Keys.Left, Keys.Right
            Case Keys.Oemcomma, Keys.Decimal
                If TB.Text.Contains(",") Then
                    e.SuppressKeyPress = True
                End If
            Case Else : e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub event_Textbox_GotFocus(sender As Object, e As System.EventArgs)
        Dim TB As TextBox = sender
        TB.BackColor = Drawing.Color.Yellow
    End Sub
    Private Sub event_Textbox_LostFocus(sender As Object, e As System.EventArgs)
        Dim TB As TextBox = sender
        TB.BackColor = Drawing.Color.White
        If FNC.FF(TB.Tag) <> FNC.FF(TB.Text) Then
            TB.Tag = TB.Text
            _bMussNochSpeichern = True
        End If
    End Sub

#End Region
#Region "Öffentliche Property, Methoden und Funktionen"
    Public Property DSID As Long
        Get
            Return _DSID
        End Get
        Set(value As Long)
            _DSID = value
        End Set
    End Property
#End Region
#Region "Allgemeine Property, Methoden und Funktionen"
    Private Function Check_ObDatenBearbeitetWurden(Caption As String) As Boolean
        Dim rtBool As Boolean = False
        If _bMussNochSpeichern Then
            Try
                Select Case MsgBox("Die Daten wurden geändert. Sollen die Änderungen gespeichert werden?", vbYesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1, "Einheiten: " & Caption)
                    Case MsgBoxResult.Yes
                        rtBool = Daten_Speichern()

                        If rtBool Then
                            _bMussNochSpeichern = False
                            Me.DialogResult = DialogResult.OK
                        End If
                    Case MsgBoxResult.No
                        _bMussNochSpeichern = False
                        rtBool = True
                        Me.DialogResult = DialogResult.OK
                    Case MsgBoxResult.Cancel
                        rtBool = False
                End Select
            Catch ex As Exception
                UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
            Finally
            End Try
        Else
            rtBool = True
        End If
        Return rtBool
    End Function

    Private Sub Handler(Aktion As enmHandler)
        RemoveHandler Cmd_Abbrechen.Click, AddressOf event_Button_Click
        RemoveHandler Cmd_Speichern.Click, AddressOf event_Button_Click
        RemoveHandler txtBez.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler txtBez.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler TxtEkFaktor.KeyDown, AddressOf event_Textbox_KeyDown
        RemoveHandler TxtEkFaktor.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler TxtEkFaktor.LostFocus, AddressOf event_Textbox_LostFocus
        RemoveHandler txtFaktor.KeyDown, AddressOf event_Textbox_KeyDown
        RemoveHandler txtFaktor.GotFocus, AddressOf event_Textbox_GotFocus
        RemoveHandler txtFaktor.LostFocus, AddressOf event_Textbox_LostFocus
        If Aktion = enmHandler.Add Then
            AddHandler Cmd_Abbrechen.Click, AddressOf event_Button_Click
            AddHandler Cmd_Speichern.Click, AddressOf event_Button_Click
            AddHandler txtBez.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler txtBez.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler TxtEkFaktor.KeyDown, AddressOf event_Textbox_KeyDown
            AddHandler TxtEkFaktor.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler TxtEkFaktor.LostFocus, AddressOf event_Textbox_LostFocus
            AddHandler txtFaktor.KeyDown, AddressOf event_Textbox_KeyDown
            AddHandler txtFaktor.GotFocus, AddressOf event_Textbox_GotFocus
            AddHandler txtFaktor.LostFocus, AddressOf event_Textbox_LostFocus
        End If
    End Sub

    Private Function getErrorInfo(sender As Object, ZusatzInfo As String)
        Dim rtString As String = ""
        Try
            If sender IsNot Nothing Then
                rtString = "sender.Name=" & sender.Name
            Else
                rtString = ""
            End If
        Finally
            If ZusatzInfo.Length > 0 Then
                rtString &= "|" & ZusatzInfo
            End If
        End Try
        Return rtString
    End Function
#End Region
End Class