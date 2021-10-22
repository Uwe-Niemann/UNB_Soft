Imports Allgemeine_Klassen

Public Class FrmAdressen
#Region "Enumerationen"
    Private Enum enmHandler
        Add = 0
        Remove = 1
    End Enum
#End Region
#Region "Deklarationen"

#End Region
#Region "Form-Events"
    Private Sub event_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub event_Form_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub event_Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        '
        Lade_Daten()
    End Sub

    Private Sub event_Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
#End Region
#Region "Daten laden, Speichern, Löschen"
    Private Sub Lade_Daten()
        Try
            Cursor = Cursors.WaitCursor
            Handler(enmHandler.Remove)

        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        End Try
    End Sub
    Private Sub Lade_Daten_CallBack(rt As Object)
        Try

        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        Finally
            Handler(enmHandler.Add)
            Cursor = Cursors.Default
        End Try
    End Sub
#End Region
#Region "Events"

#End Region
#Region "Öffentliche Property, Methoden und Funktionen"
    Public Sub Aktualisieren()
        Lade_Daten()
    End Sub
#End Region
#Region "Allgemeine Property, Methoden und Funktionen"
    Private Sub Handler(Aktion As enmHandler)

        If Aktion = enmHandler.Add Then

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