Imports System.ComponentModel

Public Class Frm_Einstellungen
    Private _Programmpfad As String = ""
    Private _Uploadpfad As String = ""
    Private _InitializeDir_DMS As String = ""
    Private _DateiName As String = ""
    Private _bMussNochSpeichern As Boolean = False

    Private Sub Frm_Einstellungen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cmd_Abbruch.Image = My.Resources._Exit
        Cmd_Speichern.Image = My.Resources.Save
        Cmd_ProgrammPfad.Image = My.Resources.Zoom
        Cmd_UploadPfad.Image = My.Resources.Zoom
        '
        _Programmpfad = FNC.ReadAppConfig("AUTOMO_PATH", My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        _Uploadpfad = FNC.ReadAppConfig("AUTOMO_UPLOAD_ORDNER", My.Computer.FileSystem.SpecialDirectories.Desktop)
        _InitializeDir_DMS = FNC.ReadAppConfig("AUTOMO_DMS_ORDNER", My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\UNB_DMS")
        _DateiName = FNC.ReadAppConfig("AUTOMO_FILENAME", "Automobile.xml")
        '
        Txt_ProgrammPfad.Text = _Programmpfad : Txt_ProgrammPfad.Tag = _Programmpfad
        Txt_UploadPfad.Text = _Uploadpfad : Txt_UploadPfad.Tag = _Uploadpfad
    End Sub
    Private Sub Frm_Einstellungen_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Txt_ProgrammPfad.Focus()
        Txt_ProgrammPfad.SelectionLength = Txt_ProgrammPfad.Text.Length
    End Sub
    Private Sub Cmd_Click(sender As Object, e As EventArgs) Handles Cmd_Abbruch.Click, Cmd_Speichern.Click, Cmd_ProgrammPfad.Click, Cmd_UploadPfad.Click
        Select Case sender.Name
            Case Cmd_Abbruch.Name
                If Not CheckObDatenBearbeitetWurden("Schließen") Then Exit Sub
                Me.DialogResult = DialogResult.Cancel
            Case Cmd_ProgrammPfad.Name
                Dim FSB As New OpenFileDialog With {.InitialDirectory = _Programmpfad, .FileName = _DateiName, .CheckFileExists = False, .Filter = "*.xml|*.xml"}
                If FSB.ShowDialog(Me) = DialogResult.OK Then
                    _Programmpfad = New IO.FileInfo(FSB.FileName).DirectoryName
                    If Not _Programmpfad.EndsWith("\") Then _Programmpfad &= "\"
                    Txt_ProgrammPfad.Text = _Programmpfad
                    _bMussNochSpeichern = True
                    PicSpeichernInfo.Visible = True
                End If
            Case Cmd_Speichern.Name
                If DatenSpeichern() Then
                    Me.DialogResult = DialogResult.OK
                Else
                    MsgBox("Daten konnten nicht gespeichert werden", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Daten speichern")
                End If
            Case Cmd_UploadPfad.Name
                Dim FBD As New FolderBrowserDialog With {.SelectedPath = _Uploadpfad, .ShowNewFolderButton = True, .Description = "Upload-Verzeichnis für Ebay auswählen"}
                If FBD.ShowDialog(Me) = DialogResult.OK Then
                    _Uploadpfad = FBD.SelectedPath
                    If Not _Uploadpfad.EndsWith("\") Then _Uploadpfad &= "\"
                    Txt_UploadPfad.Text = _Uploadpfad
                    _bMussNochSpeichern = True
                    PicSpeichernInfo.Visible = True
                End If
        End Select
    End Sub
    Private Sub Frm_Einstellungen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not CheckObDatenBearbeitetWurden("Schließen") Then e.Cancel = True : Exit Sub
    End Sub

    Private Sub Txt_LostFocus(sender As Object, e As EventArgs) Handles Txt_UploadPfad.LostFocus, Txt_ProgrammPfad.LostFocus
        Dim Txt As TextBox = sender
        If FNC.FF(Txt.Tag) <> FNC.FF(Txt.Text) Then
            Txt.Tag = Txt.Text
            PicSpeichernInfo.Visible = True
            _bMussNochSpeichern = True
        End If
    End Sub

    Private Function CheckObDatenBearbeitetWurden(Caption As String) As Boolean
        Dim rtBool As Boolean = False
        If _bMussNochSpeichern Then
            Select Case MsgBox("Die Daten wurden geändert." & vbCrLf & "Sollen die Änderungen übernommen werden?", vbYesNoCancel + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton1, Caption)
                Case vbYes
                    If DatenSpeichern() Then
                        rtBool = True
                    Else
                        MsgBox("Daten konnten nicht gespeichert werden", vbOKOnly + MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Speichern")
                    End If
                Case vbNo
                    _bMussNochSpeichern = False
                    rtBool = True
                Case vbCancel
            End Select
        Else
            rtBool = True
        End If
        Return rtBool
    End Function

    Private Function DatenSpeichern() As Boolean
        Dim rtBool As Boolean = False
        If _bMussNochSpeichern Then
            If FNC.FF(_Programmpfad).Length = 0 Then
                MsgBox("Bitte Programmpfad angeben!", vbOKOnly + MsgBoxStyle.Information + vbSystem, "Speichern")
                Txt_ProgrammPfad.Focus()
                Exit Function
            End If
            If FNC.FF(_Uploadpfad).Length = 0 Then
                MsgBox("Bitte Uploadpfad angeben!", vbOKOnly + MsgBoxStyle.Information + vbSystem, "Speichern")
                Txt_UploadPfad.Focus()
                Exit Function
            End If
            '
            FNC.WriteAppConfig("AUTOMO_PATH", _Programmpfad)
            _InitializeDir_DMS = _Programmpfad & FNC.ReadAppConfig("AUTOMO_DMS_ORDNER", "UNB_DMS")
            If Not _InitializeDir_DMS.EndsWith("\") Then _InitializeDir_DMS &= "\"
            FNC.WriteAppConfig("AUTOMO_DMS_PATH", _InitializeDir_DMS)
            If Not IO.Directory.Exists(_InitializeDir_DMS) Then
                IO.Directory.CreateDirectory(_InitializeDir_DMS)
            End If
            '
            If Not IO.Directory.Exists(_Uploadpfad) Then
                IO.Directory.CreateDirectory(_Uploadpfad)
            End If
            FNC.WriteAppConfig("AUTOMO_UPLOAD_ORDNER", _Uploadpfad)
            '
            _bMussNochSpeichern = False
            rtBool = True
        Else
            rtBool = True
        End If
        Return rtBool
    End Function
End Class