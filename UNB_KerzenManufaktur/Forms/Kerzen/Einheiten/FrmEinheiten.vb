Imports Allgemeine_Klassen
Public Class FrmEinheiten
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
    Private _SP_DSID As Integer = -1
    Private _SP_BEZ As Integer = -1

#End Region
#Region "Form-Events"
    Private Sub event_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub event_Form_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub event_Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        TSB_Delete.Image = My.Resources.Delete
        TSB_Drucken.Image = My.Resources.Print
        TSB_Edit.Image = My.Resources.Edit
        TSB_Neu.Image = My.Resources.Neu
        TSB_PDF.Image = My.Resources.icon_pdf
        '
        Init_Grid()
        Lade_Daten()
    End Sub

    Private Sub event_Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
#End Region
#Region "Grid initialisieren"
    Private Sub Init_Grid()
        With Grid
            .ColumnCount = 0
            .AutoGenerateColumns = False : .MultiSelect = False : .RowHeadersVisible = False
            .AllowUserToAddRows = False : .AllowUserToDeleteRows = False : .AllowUserToResizeRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToOrderColumns = True : .EditMode = DataGridViewEditMode.EditProgrammatically
            _SP_DSID = Erzeuge_Col("DSID", "Nr.", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleRight, CellType:=enmCellArt.Textbox)
            _SP_BEZ = Erzeuge_Col("BEZ", "Bezeichnung", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft, CellType:=enmCellArt.Textbox)
            Erzeuge_Col("ANSICHT", "", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft, CellType:=enmCellArt.Textbox, ExpandLastCol:=True)
            '
            .AutoResizeColumns()
        End With
    End Sub

    Private Function Erzeuge_Col(ColumnName As String, HeaderText As String, HeaderCellAlignment As DataGridViewContentAlignment, HeaderCellBackColor As Drawing.Color, ContentAlignment As DataGridViewContentAlignment, Optional bVisible As Boolean = True, Optional CellType As enmCellArt = enmCellArt.Textbox, Optional ExpandLastCol As Boolean = False) As Integer
        If CellType = enmCellArt.Textbox Then
            Dim Col As New DataGridViewTextBoxColumn
            Col.Name = ColumnName
            Col.DataPropertyName = ColumnName
            Col.HeaderText = HeaderText
            Col.Visible = bVisible
            Col.HeaderCell.Style.Alignment = HeaderCellAlignment
            Col.HeaderCell.Style.BackColor = HeaderCellBackColor
            Col.DefaultCellStyle.Alignment = ContentAlignment
            If ExpandLastCol Then
                Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            '
            Return Grid.Columns.Add(Col)
        ElseIf CellType = enmCellArt.Image Then
            Dim Col As New DataGridViewImageColumn
            Col.Name = ColumnName
            Col.DataPropertyName = ColumnName
            Col.HeaderText = HeaderText
            Col.Visible = bVisible
            Col.HeaderCell.Style.Alignment = HeaderCellAlignment
            Col.HeaderCell.Style.BackColor = HeaderCellBackColor
            Col.DefaultCellStyle.Alignment = ContentAlignment
            If ExpandLastCol Then
                Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            '
            Return Grid.Columns.Add(Col)
        Else
            Return -1
        End If
    End Function

    Private Sub Formatiere_Grid()
        Try
            Lbl_Keine_Daten.Visible = True
            If Grid.Rows.Count = 0 Then Exit Sub
            Lbl_Keine_Daten.Visible = False

        Catch ex As Exception
            unb_err.ShowError(ex, getErrorInfo(Me, ""))
        Finally
        End Try
    End Sub
#End Region
#Region "Daten laden, Neuanlage, Bearbeiten, Löschen"
    Private Sub Lade_Daten()
        Try
            Cursor = Cursors.WaitCursor
            Handler(enmHandler.Remove)
            Using DT As DataTable = oSQL.Lade_Daten
                If DT IsNot Nothing Then
                    Grid.DataSource = DT.Copy
                End If
            End Using
            '

        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        Finally
            Handler(enmHandler.Add)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Eintrag_Bearbeiten(IsNeuanlage As Boolean)
        Dim FrmDlg As DlgEinheiten = Nothing
        Try
            If IsNeuanlage Then
                FrmDlg = New DlgEinheiten With {.DSID = 0}
            Else
                FrmDlg = New DlgEinheiten With {.DSID = Grid.Rows(Grid.CurrentRow.Index).Cells(_SP_DSID).Value}
            End If
            If FrmDlg.ShowDialog(Me) = DialogResult.OK Then
                Lade_Daten()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub event_Grid_DoubleClick(sender As Object, e As EventArgs)
        Try
            If Grid.CurrentRow.Index >= 0 Then
                Eintrag_Bearbeiten(IsNeuanlage:=False)
            Else
                MsgBox("Bitte eine Zeile wählen", "Einheit bearbeiten")
            End If
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(sender, ""))
        End Try
    End Sub
#End Region
#Region "Events"
    Private Sub event_Toolstrip_Button_Click(sender As Object, e As System.EventArgs)
        Dim TSB As ToolStripButton = sender
        Try
            Select Case TSB.Name
                Case TSB_Delete.Name
                    If Grid.CurrentRow.Index > 0 Then
                        Dim DSID As Long = FNC.FF(Grid.Rows(Grid.CurrentRow.Index).Cells(_SP_DSID).Value, FNC.enmFNC.FFLong)
                        If MsgBoxResult.Yes = MsgBox("Soll diese Einheit gelöscht werden?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, "Löschen") Then
                            If oSQL.DatensatzWirdVerwendet(DSID) Then
                                MsgBox("Die Einheit kann nicht gelöscht werden weil sie verwendet wird", vbOKOnly + MsgBoxStyle.Information, "Löschen")
                            Else
                                If oSQL.Datensatz_Löschen(DSID) Then
                                    Lade_Daten()
                                Else
                                    MsgBox("Der Datensatz konnte nicht gelöscht werden", vbOKOnly + MsgBoxStyle.Exclamation, "Löschen")
                                End If
                            End If
                        End If
                    Else
                        MsgBox("Bitte eine Zeile wählen", vbOKOnly + MsgBoxStyle.Information, "Löschen")
                    End If
                Case TSB_Drucken.Name
                Case TSB_Edit.Name : Eintrag_Bearbeiten(IsNeuanlage:=False)
                Case TSB_Neu.Name : Eintrag_Bearbeiten(IsNeuanlage:=True)
                Case TSB_PDF.Name
            End Select

        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(sender, ""))
        End Try
    End Sub
#End Region
#Region "Öffentliche Property, Methoden und Funktionen"
    Public Sub Aktualisieren()
        Lade_Daten()
    End Sub
#End Region
#Region "Allgemeine Property, Methoden und Funktionen"
    Private Sub Handler(Aktion As enmHandler)
        RemoveHandler TSB_Delete.Click, AddressOf event_Toolstrip_Button_Click
        RemoveHandler TSB_Drucken.Click, AddressOf event_Toolstrip_Button_Click
        RemoveHandler TSB_Edit.Click, AddressOf event_Toolstrip_Button_Click
        RemoveHandler TSB_Neu.Click, AddressOf event_Toolstrip_Button_Click
        RemoveHandler TSB_PDF.Click, AddressOf event_Toolstrip_Button_Click
        RemoveHandler Grid.DoubleClick, AddressOf event_Grid_DoubleClick
        If Aktion = enmHandler.Add Then
            AddHandler TSB_Delete.Click, AddressOf event_Toolstrip_Button_Click
            AddHandler TSB_Drucken.Click, AddressOf event_Toolstrip_Button_Click
            AddHandler TSB_Edit.Click, AddressOf event_Toolstrip_Button_Click
            AddHandler TSB_Neu.Click, AddressOf event_Toolstrip_Button_Click
            AddHandler TSB_PDF.Click, AddressOf event_Toolstrip_Button_Click
            AddHandler Grid.DoubleClick, AddressOf event_Grid_DoubleClick
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