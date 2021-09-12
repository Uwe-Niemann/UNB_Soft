Imports System.Data
Public Class Frm_SuchEingabe
#Region "Enumerationen"
    Private Enum enmHandler
        Add
        Remove
    End Enum
    Private Enum enmCellArt
        Textbox = 1
        Image = 2
    End Enum
#End Region
#Region "Deklarationen"
    Private _DB_Version As Integer = 5
    Private _bMussNochSpeichern As Boolean = False
    Private _bKeineSpeicherMeldungAusgeben As Boolean = False
    Private Const COMBO_HERSTELLER_SONSTIGE As Integer = 999
    Private Const HERSTELLER_SONSTIGE_TEXT As String = "Sonstige"
    Private Const DATATABLE_MODELL As String = "AUTOMOBILE"
    Private Const DATATABLE_DMS As String = "DMS"
    Private Const DATATABLE_DMS_ARCHIV_NR As String = "DMS_ARCHIV_NR"
    Private Const DATATABLE_KATEGORIE As String = "KATEGORIE"
    Private Const DATATABLE_VERSION As String = "VERSION"
    Private Const DMS_DATEI_LÖSCH_KENNER As String = "999999"
    Private _bDoUpdateDataset As Boolean = True
    Private _DateiPfad As String = ""
    Private _DateiName As String = ""
    Private _AutoMo_FileName As String = ""
    Private _FilterText As String = ""
    Private _Gültige_Image_Extension As String = ";.JPG;.JPEG;.TIF;*.TIFF;.BMP;.ico|;.GIF;"
    Private _InitializeDir_DateiSuche As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    Private _InitializeDir_BildDatei_Kopie_Erstellen As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "Bildverarbeitung"
    Private _AutoMo_File_Exists As Boolean = False
    Private _InitializeDir As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    Private _InitializeDir_DMS As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    Private _DS_Daten As DataSet = Nothing
    Private _htColumnName As New Hashtable
    Private _CurrentRowIndex As Integer = -1
    Private _CurrentColIndex As Integer = -1
    Private _TTip As New ToolTip With {.Tag = IntPtr.Zero}
    Private _BindingGridSource As BindingSource = New BindingSource()
    Private _BindingCboHerstellerSource As BindingSource = New BindingSource()
    Private _BindingCboKategorieSource As BindingSource = New BindingSource()
#End Region
#Region "Form-Events"
    Private Sub Frm_SuchEingabe_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Handler(enmHandler.Remove)
        If Not CheckObDatenBearbeitetWurden("Programm beenden") Then e.Cancel = True : Exit Sub
        If _DS_Daten IsNot Nothing Then _DS_Daten.Clear() : _DS_Daten.Dispose()
    End Sub
    Private Sub Frm_SuchEingabe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TSB_Schließen.Image = My.Resources._Exit
            TSB_Modell_Löschen.Image = My.Resources._Erase
            TSB_Neu_Erfassen.Image = My.Resources.New_document
            TSB_Eingabe_Leeren.Image = My.Resources.Refresh
            TSB_Einstellungen.Image = My.Resources.Repair
            Cmd_Speichern.Image = My.Resources.Save
            TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Image = My.Resources.Create
            TSB_Grid_DMS_Delete_Picture.Image = My.Resources._Erase
            TSB_Modell_Löschen.Enabled = False
            TSB_Grid_DMS_Resize_Picture.Image = My.Resources.Zoom
            TSB_Grid_DMS_Copy_Picture.Image = My.Resources.Copy
            TSB_Grid_DMS_Neues_Modell.Image = My.Resources.New_document
            CMSI_Aktuelles_Bild_Löschen.Image = My.Resources._Erase
            CMSI_Alle_Bilder_Löschen.Image = My.Resources._Erase
            Cmd_EAN_Web.Image = My.Resources.Info
            _TTip.SetToolTip(Cmd_EAN_Web, "Nach EAN-Nr. im Internet suchen")
            '
            _InitializeDir_BildDatei_Kopie_Erstellen = FNC.ReadAppConfig("AUTOMO_UPLOAD_ORDNER", My.Computer.FileSystem.SpecialDirectories.Desktop & "Bildverarbeitung")
            _DateiPfad = FNC.ReadAppConfig("AUTOMO_PATH", _InitializeDir)
            _DateiName = FNC.ReadAppConfig("AUTOMO_FILENAME", "Automobile.xml")
            If Not _DateiPfad.EndsWith("\") Then _DateiPfad &= "\"
            _AutoMo_FileName = _DateiPfad & _DateiName
            If Not IO.File.Exists(_AutoMo_FileName) Then
                _AutoMo_File_Exists = False
            Else
                _AutoMo_File_Exists = True
                _InitializeDir_DMS = FNC.ReadAppConfig("AUTOMO_DMS_PATH", "")
            End If
            '
            _htColumnName.Add("DEL_IMAGE", "DEL_IMAGE")
            _htColumnName.Add("THUMBNAIL", "THUMBNAIL")
            _htColumnName.Add("DSID", "DSID")
            _htColumnName.Add("ANGELEGT_AM", "ANGELEGT_AM")
            _htColumnName.Add(Txt_Maßstab.Name, "MAßSTAB")
            _htColumnName.Add(Txt_Modell.Name, "MODELL")
            _htColumnName.Add(Cbo_Hersteller.Name, "HERSTELLER")
            _htColumnName.Add(Txt_Hersteller_Nr.Name, "HERSTELLER_NR")
            _htColumnName.Add(Txt_Fahrer.Name, "FAHRER")
            _htColumnName.Add(Txt_EAN.Name, "EAN")
            _htColumnName.Add(Txt_Farbe.Name, "FARBE")
            _htColumnName.Add(Txt_Baujahr.Name, "BAUJAHR")
            _htColumnName.Add(Cbo_Kategorie.Name, "KATEGORIE")
            _htColumnName.Add(Txt_Besonderheit.Name, "BESONDERHEIT")
            '
            Cbo_Hersteller.Sorted = True
            '
            Init_Grid_Suche()
            Init_Grid_DMS()
            '
            Lade_Daten()
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(Me, ""))
        End Try
    End Sub
    Private Sub Frm_SuchEingabe_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.KeyPreview = True
        Cbo_Hersteller.SelectedIndex = -1
        Handler(enmHandler.Add)
        Txt_Maßstab.Focus()
        Txt_Maßstab.BackColor = Drawing.Color.Yellow
    End Sub
    Private Sub Frm_SuchEingabe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        FNC.KeyPress(e)
    End Sub
#End Region
#Region "Eingabemaske leeren, Daten laden, Speichern, Dataset erstellen, Grid initalisieren"
    Private Sub Eingabefelder_Füllen()
        Dim DR() As DataRow = {}
        Dim DMS_Verzeichnis As String = ""
        Try
            If _CurrentRowIndex >= 0 Then
                Lbl_DSID_Value.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells("DSID").Value)
                Lbl_Angelegt_Am_Info.Text = ""
                If FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName("ANGELEGT_AM")).Value).Length > 0 Then
                    Lbl_Angelegt_Am_Info.Text = Format(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName("ANGELEGT_AM")).Value, "dd.MM.yyyy")
                End If
                Txt_Maßstab.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Maßstab.Name)).value)
                Txt_Modell.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Modell.Name)).value)
                Cbo_Hersteller.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Cbo_Hersteller.Name)).value)
                Txt_Hersteller_Nr.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Hersteller_Nr.Name)).value)
                Txt_Fahrer.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Fahrer.Name)).value)
                Txt_EAN.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_EAN.Name)).value)
                Txt_Farbe.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Farbe.Name)).value)
                Txt_Baujahr.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Baujahr.Name)).value)
                Txt_Besonderheit.Text = FNC.FF(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Txt_Besonderheit.Name)).value)
                Cbo_Kategorie.SelectedIndex = -1
                If FNC.DB_Text(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Cbo_Kategorie.Name)).value).Length > 0 Then
                    DR = _DS_Daten.Tables(DATATABLE_KATEGORIE).Select("KATEGORIE=" & FNC.DB_Text(Grid_Suche.Rows(_CurrentRowIndex).Cells(_htColumnName(Cbo_Kategorie.Name)).value))
                    If DR.Length > 0 Then
                        Cbo_Kategorie.SelectedValue = FNC.FF(DR(0)("DSID"), FNC.enmFFArten.FFLong)
                    End If
                End If
                '
                Grid_DMS.SuspendLayout()
                Grid_DMS.ColumnCount = 0
                Grid_DMS.Rows.Clear()
                DR = _DS_Daten.Tables(DATATABLE_DMS).Select("FREMD_DSID=" & Lbl_DSID_Value.Text & " AND STATUS <> " & DMS_DATEI_LÖSCH_KENNER)
                If DR.Length > 0 Then
                    For Each DRow As DataRow In DR
                        DMS_Verzeichnis = Prüfe_KN_DocID(DRow("KN_DOCID"))
                        DMS_Verzeichnis = _InitializeDir_DMS & DMS_Verzeichnis & "\" & getDateiName(DRow("KN_DOCID")) & "." & DRow("DATEI_TYP")
                        Add_Image_To_Grid_DMS(DMS_Verzeichnis, DRow("KN_DOCID"), DRow("DATEINAME"))
                    Next DRow
                    Add_Image_To_Grid_DMS("", 0) ' Leerspalte anhängen
                    Grid_DMS.AutoResizeColumns()
                    Grid_DMS.AutoResizeRows()
                End If
                Schreibe_Anzahl_Bilder()
                Grid_DMS.ResumeLayout()
                _bMussNochSpeichern = False
            End If
        Catch ex As Exception
            Throw
        Finally
            Array.Resize(Of DataRow)(DR, 0)
        End Try
    End Sub
    Private Sub Eingabefelder_Leeren()
        Try
            _FilterText = "GELOESCHT_AM Is Null"
            Lbl_DSID_Value.Text = ""
            Lbl_Angelegt_Am_Info.Text = ""
            Txt_Maßstab.Text = "" : Txt_Maßstab.Tag = ""
            Cbo_Hersteller.SelectedIndex = -1 : Cbo_Hersteller.Tag = -1 : Cbo_Hersteller.BackColor = Drawing.Color.White
            Txt_Hersteller_Nr.Text = "" : Txt_Hersteller_Nr.Tag = -1
            Txt_Modell.Text = "" : Txt_Modell.Tag = ""
            Cbo_Kategorie.SelectedIndex = -1 : Cbo_Kategorie.Tag = -1 : Cbo_Kategorie.BackColor = Drawing.Color.White
            Txt_EAN.Text = "" : Txt_EAN.Tag = ""
            Txt_Fahrer.Text = "" : Txt_Fahrer.Tag = ""
            Txt_Farbe.Text = "" : Txt_Farbe.Tag = ""
            Txt_Baujahr.Text = "" : Txt_Baujahr.Tag = ""
            Txt_Besonderheit.Text = "" : Txt_Besonderheit.Tag = ""
            Grid_DMS.SuspendLayout()
            Grid_DMS.ColumnCount = 0
            Grid_DMS.Rows.Clear()
            Grid_DMS.ResumeLayout()
            Grid_Suche.ClearSelection()
            _CurrentRowIndex = -1
            _CurrentColIndex = -1
            TSB_Grid_DMS_Delete_Picture.Visible = False
            TSB_Grid_DMS_Resize_Picture.Tag = 0
            TSB_Grid_DMS_Resize_Picture.Text = "Bild-Datei maximieren"
            TSB_Grid_DMS_Resize_Picture.Enabled = False
            PicGrid_DMS.Image = Nothing
            PicGrid_DMS.Dock = Nothing
            PicGrid_DMS.Visible = False

            Grid_DMS.BringToFront()
            PicSpeichernInfo.Visible = False
            _bMussNochSpeichern = False
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Init_Grid_Suche()
        With Grid_Suche
            .ColumnCount = 0
            .AutoGenerateColumns = False : .MultiSelect = False : .RowHeadersVisible = False
            .AllowUserToAddRows = False : .AllowUserToDeleteRows = False : .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True : .EditMode = DataGridViewEditMode.EditProgrammatically
            Erzeuge_Col(Grid_Suche, _htColumnName("DEL_IMAGE"), "", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, CellType:=enmCellArt.Image)
            Erzeuge_Col(Grid_Suche, _htColumnName("THUMBNAIL"), "", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, CellType:=enmCellArt.Image)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Modell.Name), "Modell", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Maßstab.Name), "Maßstab", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Cbo_Hersteller.Name), "Hersteller", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Hersteller_Nr.Name), "Hersteller-Nr.", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Fahrer.Name), "Fahrer", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_EAN.Name), "EAN-Nr.", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Farbe.Name), "Farbe", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Baujahr.Name), "Baujahr", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleRight)
            Erzeuge_Col(Grid_Suche, _htColumnName(Cbo_Kategorie.Name), "Kategorie", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleLeft)
            Erzeuge_Col(Grid_Suche, _htColumnName(Txt_Besonderheit.Name), "Besonderheit", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleRight)
            Erzeuge_Col(Grid_Suche, _htColumnName("DSID"), "Nr.", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, bVisible:=False)
            Erzeuge_Col(Grid_Suche, _htColumnName("ANGELEGT_AM"), "Angelegt am", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, bVisible:=False)
            '
            .AutoResizeColumns()
        End With
    End Sub
    Private Sub Init_Grid_DMS()
        With Grid_DMS
            .ColumnCount = 0
            .AutoGenerateColumns = False : .RowHeadersVisible = False
            .AllowUserToAddRows = False : .AllowUserToDeleteRows = False : .AllowUserToResizeRows = False : .EditMode = DataGridViewEditMode.EditProgrammatically
        End With
    End Sub
    Private Function Erzeuge_Col(GRID As DataGridView, ColumnName As String, HeaderText As String, HeaderCellAlignment As DataGridViewContentAlignment, HeaderCellBackColor As Drawing.Color, ContentAlignment As DataGridViewContentAlignment, Optional bVisible As Boolean = True, Optional CellType As enmCellArt = enmCellArt.Textbox) As Integer
        If CellType = enmCellArt.Textbox Then
            Dim Col As New DataGridViewTextBoxColumn
            Col.Name = ColumnName
            Col.DataPropertyName = ColumnName
            Col.HeaderText = HeaderText
            Col.Visible = bVisible
            Col.HeaderCell.Style.Alignment = HeaderCellAlignment
            Col.HeaderCell.Style.BackColor = HeaderCellBackColor
            Col.DefaultCellStyle.Alignment = ContentAlignment
            '
            Return GRID.Columns.Add(Col)
        ElseIf CellType = enmCellArt.Image Then
            Dim Col As New DataGridViewImageColumn
            Col.Name = ColumnName
            Col.DataPropertyName = ColumnName
            Col.HeaderText = HeaderText
            Col.Visible = bVisible
            Col.HeaderCell.Style.Alignment = HeaderCellAlignment
            Col.HeaderCell.Style.BackColor = HeaderCellBackColor
            Col.DefaultCellStyle.Alignment = ContentAlignment
            '
            Return GRID.Columns.Add(Col)
        Else
            Return -1
        End If
    End Function

    Private Sub Lade_Daten()
        Try
            If Grid_Suche.DataSource Is Nothing Then
                If _AutoMo_File_Exists Then
                    If _DS_Daten Is Nothing Then
                        _DS_Daten = New DataSet
                        _DS_Daten.ReadXml(_AutoMo_FileName, XmlReadMode.ReadSchema)
                    End If
                    Do_Update_Dataset()
                    '
                    Dim DT_Modell As DataTable = _DS_Daten.Tables(DATATABLE_MODELL)
                    If Not DT_Modell.Columns.Contains(_htColumnName("THUMBNAIL")) Then
                        DT_Modell.Columns.Add(_htColumnName("THUMBNAIL"), GetType(Drawing.Image))
                    End If
                    Dim DT_DMS As DataTable = _DS_Daten.Tables(DATATABLE_DMS)
                    Dim DR() As DataRow = {}
                    Dim DMS_Verzeichnis As String = ""
                    Dim sFileName As String = ""
                    For x As Integer = 0 To DT_Modell.Rows.Count - 1
                        DR = DT_DMS.Select("FREMD_DSID=" & DT_Modell.Rows(x).Item("DSID"), "KN_ID Asc")
                        If DR.Length > 0 Then
                            DMS_Verzeichnis = Prüfe_KN_DocID(DR(0)("KN_DOCID"))
                            sFileName = _InitializeDir_DMS & DMS_Verzeichnis & "\" & getDateiName(DR(0)("KN_DOCID")) & "." & DR(0)("DATEI_TYP")
                            Dim Original As Image = Drawing.Image.FromFile(sFileName)
                            DT_Modell.Rows(x).Item(_htColumnName("THUMBNAIL")) = ResizeImage(Original, New Drawing.Size(48, 48))
                            If FNC.FF(DT_Modell.Rows(x).Item(_htColumnName("ANGELEGT_AM"))).Length = 0 Then
                                DT_Modell.Rows(x).Item(_htColumnName("ANGELEGT_AM")) = DR(0)("ANGELEGT_AM")
                            End If
                        End If
                    Next
                Else
                    Erstelle_Dataset()
                End If
            End If
            '
            Grid_Suche.SuspendLayout()
            Dim DV As DataView = _DS_Daten.Tables(DATATABLE_MODELL).DefaultView
            _BindingGridSource.DataSource = DV
            If _FilterText = "" Then _FilterText = "GELOESCHT_AM Is Null"
            DV.RowFilter = _FilterText
            Lbl_Keine_Daten.Visible = DV.Count = 0
            '
            Dim GridRow As DataGridViewRow = Nothing
            Grid_Suche.DataSource = _BindingGridSource
            Grid_Suche.Sort(Grid_Suche.Columns(_htColumnName(Txt_Modell.Name)), System.ComponentModel.ListSortDirection.Ascending)
            For Each GridRow In Grid_Suche.Rows
                GridRow.Cells(0).Value = My.Resources.Erase2
            Next
            Grid_Suche.Columns(_htColumnName(Txt_Modell.Name)).HeaderText = "Modell - Anzahl (" & Grid_Suche.Rows.Count & ")"
            Grid_Suche.AutoResizeColumns()
            Grid_Suche.AutoResizeRows()
            _Grid_Suche.AutoResizeColumnHeadersHeight()
            '
            Add_Cbo_BindingSource()
        Catch ex As Exception
            Throw
        Finally
            Grid_Suche.ResumeLayout()
        End Try
    End Sub
    Private Sub Add_Cbo_BindingSource()
        _BindingCboHerstellerSource.DataSource = _DS_Daten.Tables(DATATABLE_DMS_ARCHIV_NR)
        Cbo_Hersteller.DataSource = _BindingCboHerstellerSource
        Cbo_Hersteller.DisplayMember = "HERSTELLER_DISPLAY"
        Cbo_Hersteller.ValueMember = "DSID"
        '
        _BindingCboKategorieSource.DataSource = _DS_Daten.Tables(DATATABLE_KATEGORIE)
        Cbo_Kategorie.DataSource = _BindingCboKategorieSource
        Cbo_Kategorie.DisplayMember = "KATEGORIE"
        Cbo_Kategorie.ValueMember = "DSID"
    End Sub
    Private Function Add_Image_To_Grid_DMS(sFileName As String, KN_DOCID As Long, Optional Dateiname As String = "") As Integer
        Dim Index As Integer = 0
        Dim oFileInfo As IO.FileInfo = Nothing
        Try
            If sFileName.Length > 0 Then
                oFileInfo = New IO.FileInfo(sFileName)
                If oFileInfo.Exists Then
                    Index = Grid_DMS.ColumnCount + 1
                    If Dateiname.Length > 0 Then
                        Index = Erzeuge_Col(Grid_DMS, "BILD_DATEI_" & Index, Dateiname, DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, CellType:=enmCellArt.Image)
                    Else
                        Index = Erzeuge_Col(Grid_DMS, "BILD_DATEI_" & Index, oFileInfo.Name, DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, CellType:=enmCellArt.Image)
                    End If
                    If Grid_DMS.Rows.Count = 0 Then Grid_DMS.Rows.Add()
                    Grid_DMS.Rows(0).Cells(Index).Value = Drawing.Image.FromFile(sFileName)
                    Grid_DMS.Rows(0).Cells(Index).Tag = KN_DOCID
                    TSB_Grid_DMS_Delete_Picture.Visible = True
                    TSB_Grid_DMS_Resize_Picture.Enabled = True
                End If
            Else
                Index = Grid_DMS.ColumnCount + 1
                Index = Erzeuge_Col(Grid_DMS, "BILD_DATEI_" & Index, "", DataGridViewContentAlignment.MiddleCenter, Drawing.Color.Beige, DataGridViewContentAlignment.MiddleCenter, CellType:=enmCellArt.Image)
                If Grid_DMS.Rows.Count = 0 Then Grid_DMS.Rows.Add()
                Grid_DMS.Rows(0).Cells(Index).Value = My.Resources.Leer_Icon
                Grid_DMS.Rows(0).Cells(Index).Tag = -1
            End If
            '
            Return Index
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function DatenSpeichern() As Boolean
        Dim rtBool As Boolean = True
        Dim Value As Object = Nothing
        Dim sFileName As String = ""
        Dim sHersteller As String = HERSTELLER_SONSTIGE_TEXT
        Dim HerstellerNr As String = ""
        Dim KN_DOCID As Long = 0
        Dim ByRef_FileLength As Integer = 0
        Dim DR() As DataRow = {}
        Dim DR_DMS As DataRow = Nothing
        Dim DRow As DataRow = Nothing
        Dim Automobil_DSID As Integer = 0
        Dim DT As DataTable = Nothing
        Dim DT_DMS As DataTable = Nothing
        Dim sMsg As String = ""
        Dim ctrl As Object = Nothing
        Dim Cbo_Hersteller_Text As String = ""
        Dim Cbo_Kategorie_Text As String = ""
        Try
            Handler(enmHandler.Remove)
            If _bMussNochSpeichern Then
                Cbo_Hersteller_Text = Cbo_Hersteller.Text
                Cbo_Kategorie_Text = Cbo_Kategorie.Text
                '
                _bKeineSpeicherMeldungAusgeben = False
                If FNC.FF(Txt_Modell.Text).Length > 0 Then
                    If FNC.FF(Lbl_DSID_Value.Text, FNC.enmFFArten.FFLong) > 0 Then
                        DR = _DS_Daten.Tables(DATATABLE_MODELL).Select("MODELL=" & FNC.DB_Text(Txt_Modell.Text) & " AND DSID <> " & FNC.FF(Lbl_DSID_Value.Text, FNC.enmFFArten.FFLong))
                    Else
                        DR = _DS_Daten.Tables(DATATABLE_MODELL).Select("MODELL=" & FNC.DB_Text(Txt_Modell.Text))
                    End If
                    If DR.Length > 0 Then
                        If MsgBox("Die Modell-Bezeichnung ist bereits vorhanden!" & vbCrLf & "Trotzdem speichern?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Speichern") = vbNo Then
                            _bKeineSpeicherMeldungAusgeben = True
                            Txt_Modell.BackColor = Drawing.Color.Yellow
                            Txt_Modell.Focus()
                            Exit Function
                        End If
                    End If
                End If
                If Not _AutoMo_File_Exists Then
                    MsgBox("Bitte einen Pfad wählen!", vbOKOnly + MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Speichern")
                    Exit Function
                End If
                If FNC.FF(Txt_Maßstab.Text).Length = 0 Then
                    sMsg = "Maßstab nicht gefüllt"
                    ctrl = Txt_Maßstab
                End If
                If FNC.FF(Txt_Modell.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Modell nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Modell
                End If
                If Cbo_Hersteller.Items.Count > 0 AndAlso FNC.FF(Cbo_Hersteller.SelectedValue).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Hersteller nicht gefüllt - !!! " & HERSTELLER_SONSTIGE_TEXT & " wird angenommen !!!"
                    If ctrl Is Nothing Then ctrl = Cbo_Hersteller
                End If
                If FNC.FF(Txt_Hersteller_Nr.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Hersteller-Nr. nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Hersteller_Nr
                End If
                If Cbo_Kategorie.Items.Count > 0 AndAlso FNC.FF(Cbo_Kategorie.SelectedValue).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Kategorie nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Cbo_Kategorie
                End If
                If FNC.FF(Txt_Fahrer.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Fahrer nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Fahrer
                End If
                If FNC.FF(Txt_EAN.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "EAN-Nr. nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_EAN
                End If
                If FNC.FF(Txt_Farbe.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Farbe nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Farbe
                End If
                If FNC.FF(Txt_Baujahr.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Baujahr nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Baujahr
                End If
                If FNC.FF(Txt_Besonderheit.Text).Length = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Besonderheit nicht gefüllt"
                    If ctrl Is Nothing Then ctrl = Txt_Besonderheit
                End If
                If Grid_DMS.ColumnCount = 0 Then
                    sMsg &= IIf(sMsg.Length > 0, vbCrLf, "")
                    sMsg &= "Keine Fotos hinterlegt"
                    If ctrl Is Nothing Then ctrl = Grid_DMS
                End If
                '
                If sMsg.Length > 0 Then
                    If MsgBox(sMsg & vbCrLf & "Trotzdem speichern?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Speichern") = vbNo Then
                        If ctrl IsNot Nothing Then
                            ctrl.Focus()
                        End If
                        _bKeineSpeicherMeldungAusgeben = True ' Wird in event_Cmd_Click ausgewertet
                        Exit Function
                    End If
                End If

                DT = _DS_Daten.Tables(DATATABLE_MODELL)
                If Lbl_DSID_Value.Text.Length = 0 Then
                    DRow = DT.NewRow : DT.Rows.Add(DRow)
                    Value = DT.Compute("Max(DSID)", "")
                    DRow("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                    Lbl_DSID_Value.Text = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                    DRow("ANGELEGT_AM") = Date.Now
                    Lbl_Angelegt_Am_Info.Text = Format(Date.Now, "dd.MM.yyyy")
                Else
                    DR = DT.Select("DSID=" & Lbl_DSID_Value.Text)
                    If DR.Length > 0 Then
                        DRow = DR(0)
                        DRow("GEAENDERT_AM") = Date.Now
                    End If
                End If
                If DRow IsNot Nothing Then
                    Automobil_DSID = DRow("DSID")
                    DRow(_htColumnName(Txt_Maßstab.Name)) = FNC.FF(Txt_Maßstab.Text)
                    If FNC.FF(Cbo_Hersteller.Text).Length > 0 Then
                        sHersteller = FNC.FF(Cbo_Hersteller.Text)
                        DRow(_htColumnName(Cbo_Hersteller.Name)) = sHersteller
                    End If
                    DRow(_htColumnName(Txt_Hersteller_Nr.Name)) = FNC.FF(Txt_Hersteller_Nr.Text)
                    DRow(_htColumnName(Txt_Modell.Name)) = FNC.FF(Txt_Modell.Text)
                    DRow(_htColumnName(Cbo_Kategorie.Name)) = FNC.FF(Cbo_Kategorie.Text)
                    DRow(_htColumnName(Txt_Fahrer.Name)) = FNC.FF(Txt_Fahrer.Text)
                    DRow(_htColumnName(Txt_EAN.Name)) = FNC.FF(Txt_EAN.Text)
                    DRow(_htColumnName(Txt_Farbe.Name)) = FNC.FF(Txt_Farbe.Text)
                    DRow(_htColumnName(Txt_Baujahr.Name)) = FNC.FF(Txt_Baujahr.Text)
                    DRow(_htColumnName(Txt_Besonderheit.Name)) = FNC.FF(Txt_Besonderheit.Text)
                    '
                    DT = _DS_Daten.Tables(DATATABLE_DMS)
                    Dim KNDocID As Long = 0
                    For Each ImageCol As DataGridViewImageColumn In Grid_DMS.Columns
                        Array.Resize(Of DataRow)(DR, 0)
                        KNDocID = FNC.FF(Grid_DMS.Rows(0).Cells(ImageCol.Index).Tag, FNC.enmFFArten.FFLong)
                        If KNDocID <> -1 Then
                            If KNDocID > 0 Then
                                DR = DT.Select("KN_DOCID=" & FNC.DB_Text(KNDocID))
                            End If
                            If DR.Length > 0 Then
                                ByRef_FileLength = DR(0).Item("LENGTH")
                                If Schreibe_Datei(ImageCol, KN_DOCID, ByRef_FileLength) Then
                                    DR(0).Item("LENGTH") = ByRef_FileLength
                                    DR(0).Item("GEAENDERT_AM") = Date.Now
                                End If
                            Else
                                ' Archiv-Nr ermitteln
                                DT_DMS = _DS_Daten.Tables(DATATABLE_DMS_ARCHIV_NR)
                                DR = DT_DMS.Select("HERSTELLER=" & FNC.DB_Text(sHersteller.ToUpper))
                                If DR.Length = 0 Then
                                    DR_DMS = DT_DMS.NewRow : DT_DMS.Rows.Add(DR_DMS)
                                    Value = DT_DMS.Compute("Max(DSID)", "")
                                    DRow("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                    KN_DOCID = Strings.Right("000" & DRow("DSID"), 3) & "000000000"
                                    DR_DMS("HERSTELLER") = sHersteller.ToUpper
                                Else
                                    DR_DMS = DR(0)
                                    KN_DOCID = FNC.FF(DR_DMS("ARCHIV_NR"), FNC.enmFFArten.FFLong)
                                End If
                                DR_DMS("ARCHIV_NR") = KN_DOCID + 1
                                '
                                ' Bild-Datei: Datensatz verarbeiten
                                DRow = DT.NewRow : DT.Rows.Add(DRow)
                                Value = DT.Compute("Max(KN_ID)", "")
                                DRow("KN_ID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                DRow("FREMD_DSID") = Automobil_DSID
                                DRow("KN_DOCID") = KN_DOCID + 1
                                DRow("ANGELEGT_AM") = Date.Now
                                DRow("STATUS") = 0
                                DRow("DATEINAME") = ImageCol.HeaderText
                                DRow("DATEI_TYP") = ImageCol.HeaderText.Substring(ImageCol.HeaderText.IndexOf(".") + 1)
                                ByRef_FileLength = 0
                                Schreibe_Datei(ImageCol, KN_DOCID, ByRef_FileLength)
                                DRow.Item("LENGTH") = ByRef_FileLength
                            End If
                        End If
                    Next
                    '
                    _DS_Daten.AcceptChanges()
                    Schreibe_Dataset()
                    Cbo_Hersteller.Text = Cbo_Hersteller_Text
                    Cbo_Kategorie.Text = Cbo_Kategorie_Text
                    '
                    PicSpeichernInfo.Visible = False
                    _bMussNochSpeichern = False
                End If
            End If
        Catch ex As Exception
            Throw
        Finally
            Array.Resize(Of DataRow)(DR, 0)
            Handler(enmHandler.Add)
        End Try
        '
        Return rtBool
    End Function

    Private Sub Schreibe_Dataset()
        Try
            Using DS As DataSet = _DS_Daten.Copy
                ' Thumbnail wird beim Laden des DS manuel hinzugefügt und muss somit nicht gespeichert werden
                If DS.Tables(DATATABLE_MODELL).Columns.Contains(_htColumnName("THUMBNAIL")) Then
                    DS.Tables(DATATABLE_MODELL).Columns.Remove(_htColumnName("THUMBNAIL"))
                End If
                DS.WriteXml(_AutoMo_FileName, XmlWriteMode.WriteSchema)
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Function Schreibe_Datei(ImageCol As DataGridViewImageColumn, KN_DocID As Long, ByRef ByRef_FileLength As Integer) As Boolean
        Dim rtBool As Boolean = False
        Dim Extension As String = ""
        Dim sFileName As String = ""
        Dim sByRef_DirName As String = ""
        Dim Img As Drawing.Image = Nothing
        Dim oFileInfo As IO.FileInfo = Nothing
        Dim arDir() As String = {}
        Dim DocVerzeichnis As String = ""
        Try
            Using MS As New IO.MemoryStream
                Extension = ImageCol.HeaderText.Substring(ImageCol.HeaderText.IndexOf(".") + 1)
                Img = Grid_DMS.Rows(0).Cells(ImageCol.Index).Value
                Img.Save(MS, getImageFormat(Extension))
                MS.Position = 0
                If MS.Length <> ByRef_FileLength Then
                    ByRef_FileLength = MS.Length
                    DocVerzeichnis = Prüfe_KN_DocID(KN_DocID)
                    sFileName = DocVerzeichnis & "\" & getDateiName(KN_DocID + 1) & "." & Extension
                    sFileName = _InitializeDir_DMS & sFileName
                    oFileInfo = New IO.FileInfo(sFileName)
                    If Not oFileInfo.Directory.Exists Then
                        oFileInfo.Directory.Create()
                    End If
                    If oFileInfo.Exists Then oFileInfo.Delete()
                    IO.File.WriteAllBytes(oFileInfo.FullName, MS.ToArray)
                    rtBool = True
                End If
                MS.Flush()
                MS.Close()
            End Using
        Catch ex As Exception
            Throw
        End Try
        '
        Return rtBool
    End Function

    Private Sub Erstelle_Dataset()
        Dim NewRow As DataRow = Nothing
        _DS_Daten = New DataSet
        _DS_Daten.Tables.Add(DATATABLE_MODELL)
        With _DS_Daten.Tables(DATATABLE_MODELL)
            .Columns.Add(_htColumnName("DSID"), GetType(Integer))
            .Columns.Add("ANGELEGT_AM", GetType(DateTime))
            .Columns.Add("GEAENDERT_AM", GetType(DateTime))
            .Columns.Add("GELOESCHT_AM", GetType(DateTime))
            .Columns.Add(_htColumnName(Txt_Maßstab.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Modell.Name), GetType(String))
            .Columns.Add(_htColumnName(Cbo_Hersteller.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Hersteller_Nr.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Fahrer.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_EAN.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Farbe.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Baujahr.Name), GetType(String))
            .Columns.Add(_htColumnName(Cbo_Kategorie.Name), GetType(String))
            .Columns.Add(_htColumnName(Txt_Besonderheit.Name), GetType(String))
        End With
        '
        _DS_Daten.Tables.Add(DATATABLE_DMS)
        With _DS_Daten.Tables(DATATABLE_DMS)
            .Columns.Add("KN_ID", GetType(Integer))
            .Columns.Add("ANGELEGT_AM", GetType(DateTime))
            .Columns.Add("GEAENDERT_AM", GetType(DateTime))
            .Columns.Add("GELOESCHT_AM", GetType(DateTime))
            .Columns.Add("STATUS", GetType(Integer))
            .Columns.Add("KN_DOCID", GetType(String))
            .Columns.Add("FREMD_DSID", GetType(Integer))
            .Columns.Add("LENGTH", GetType(Integer))
            .Columns.Add("DATEINAME", GetType(String))
            .Columns.Add("DATEI_TYP", GetType(String))
        End With
        '
        _DS_Daten.Tables.Add(DATATABLE_DMS_ARCHIV_NR)
        With _DS_Daten.Tables(DATATABLE_DMS_ARCHIV_NR)
            .Columns.Add("DSID", GetType(Integer))
            .Columns.Add("HERSTELLER", GetType(String))
            .Columns.Add("HERSTELLER_DISPLAY", GetType(String))
            .Columns.Add("ARCHIV_NR", GetType(Long))
            '
            NewRow = .NewRow : .Rows.Add(NewRow)
            NewRow("DSID") = COMBO_HERSTELLER_SONSTIGE
            NewRow("HERSTELLER") = HERSTELLER_SONSTIGE_TEXT.ToUpper
            NewRow("HERSTELLER_DISPLAY") = HERSTELLER_SONSTIGE_TEXT
            NewRow("ARCHIV_NR") = COMBO_HERSTELLER_SONSTIGE & "000000000"
        End With
        '
        _DS_Daten.Tables.Add(DATATABLE_KATEGORIE)
        With _DS_Daten.Tables(DATATABLE_KATEGORIE)
            .Columns.Add("DSID", GetType(Integer))
            .Columns.Add("KATEGORIE", GetType(String))
        End With
        '
        _DS_Daten.Tables.Add(DATATABLE_VERSION)
        With _DS_Daten.Tables(DATATABLE_VERSION)
            .Columns.Add("NR", GetType(Integer))
            .Columns.Add("DATUM", GetType(DateTime))
            NewRow = .NewRow : .Rows.Add(NewRow)
            NewRow("NR") = _DB_Version : NewRow("DATUM") = Date.Now
        End With
        '
        _DS_Daten.AcceptChanges()
    End Sub
    Private Sub Do_Update_Dataset()
        Dim Version As Integer = 0
        Dim DR() As DataRow = {}
        Dim NewRow As DataRow = Nothing
        Try
            If Not _DS_Daten.Tables.Contains(DATATABLE_KATEGORIE) Then
                _DS_Daten.Tables.Add(DATATABLE_KATEGORIE)
                With _DS_Daten.Tables(DATATABLE_KATEGORIE)
                    .Columns.Add("DSID", GetType(Integer))
                    .Columns.Add("KATEGORIE", GetType(String))
                End With
            End If
            If Not _DS_Daten.Tables.Contains(DATATABLE_VERSION) Then
                _DS_Daten.Tables.Add(DATATABLE_VERSION)
                With _DS_Daten.Tables(DATATABLE_VERSION)
                    .Columns.Add("NR", GetType(Integer))
                    .Columns.Add("DATUM", GetType(DateTime))
                    NewRow = .NewRow : .Rows.Add(NewRow)
                    NewRow("NR") = 0 : NewRow("DATUM") = New Date(1950, 1, 1, 0, 0, 0)
                End With
                _DS_Daten.AcceptChanges()
            End If
            '
            Version = FNC.FF(_DS_Daten.Tables(DATATABLE_VERSION).Compute("Max(NR)", ""), FNC.enmFFArten.FFLong)
            If Version <= _DB_Version Then
                Dim bDoUpdate As Boolean = False
                For v As Integer = Version + 1 To _DB_Version
                    bDoUpdate = True
                    Select Case v
                        Case 5
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add(_htColumnName("ANGELEGT_AM"), GetType(DateTime))
                            '
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("NR") = v
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("DATUM") = Date.Now
                        Case 4
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add(_htColumnName(Txt_Besonderheit.Name), GetType(String))
                            '
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("NR") = v
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("DATUM") = Date.Now
                        Case 3
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add("GEAENDERT_AM", GetType(DateTime))
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add("GELOESCHT_AM", GetType(DateTime))
                            '
                            _DS_Daten.Tables(DATATABLE_DMS).Columns.Add("GELOESCHT_AM", GetType(DateTime))
                            '
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("NR") = v
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("DATUM") = Date.Now
                        Case 2
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add(_htColumnName(Txt_Fahrer.Name), GetType(String))
                            '
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("NR") = v
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("DATUM") = Date.Now
                        Case 1
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add(_htColumnName(Txt_Hersteller_Nr.Name), GetType(String))
                            _DS_Daten.Tables(DATATABLE_MODELL).Columns.Add(_htColumnName(Cbo_Kategorie.Name), GetType(String))
                            '
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("NR") = v
                            _DS_Daten.Tables(DATATABLE_VERSION).Rows(0).Item("DATUM") = Date.Now
                    End Select
                Next v
                If bDoUpdate Then
                    _DS_Daten.AcceptChanges()
                    Schreibe_Dataset()
                End If
            End If
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(Me, ""))
        End Try
    End Sub
#End Region
#Region "Events"
    Private Sub event_Grid_SelectionChanged(sender As Object, e As EventArgs)
        Dim Grid As DataGridView = sender
        Try
            If Grid.Name = Grid_Suche.Name Then
                If Grid.CurrentRow IsNot Nothing Then
                    If Grid.CurrentRow.Index >= 0 Then
                        If _CurrentRowIndex <> Grid.CurrentRow.Index Then
                            _CurrentRowIndex = Grid.CurrentRow.Index
                            Eingabefelder_Füllen()
                        End If
                    End If
                End If
            Else
                _CurrentColIndex = Grid.CurrentCell.ColumnIndex
            End If
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(sender, ""))
        End Try
    End Sub
    Private Sub event_Grid_Suche_MouseMove(sender As Object, e As MouseEventArgs)
        On Error Resume Next
        Dim Grid As DataGridView = sender
        Dim ht As DataGridView.HitTestInfo = Grid.HitTest(e.X, e.Y)
        Dim bHand As Boolean = False
        Dim sKey As String = ""
        Dim sToolTip As String = ""
        If ht.ColumnIndex = 0 Then
            If ht.RowIndex >= 0 Then
                bHand = True
                sKey = ht.ColumnIndex & "|" & ht.RowIndex
                sToolTip = "Datensatz löschen"
            End If
        End If
        If bHand Then
            If _TTip.Tag <> sKey Then
                _TTip.Tag = sKey
                Cursor = Cursors.Hand
                _TTip.SetToolTip(Grid, sToolTip)
            End If
        Else
            _TTip.Tag = IntPtr.Zero
            _TTip.SetToolTip(Grid, "")
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub event_Grid_Suche_MouseClick(sender As Object, e As MouseEventArgs)
        Dim Grid As DataGridView = sender
        Dim ht As DataGridView.HitTestInfo = Grid.HitTest(e.X, e.Y)
        If Cursor = Cursors.Hand Then
            Dim DR() As DataRow = {}
            Dim DRow As DataRow = Nothing
            Try
                If MsgBox("Soll der Datensatz und dazu gehörende Bilder gelöscht werden?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Datensatz löschen") = vbYes Then
                    Cursor = Cursors.WaitCursor
                    Dim DSID As Integer = Grid.Rows(ht.RowIndex).Cells(_htColumnName("DSID")).value
                    DR = _DS_Daten.Tables(DATATABLE_DMS).Select("FREMD_DSID=" & DSID)
                    If DR.Length > 0 Then
                        For Each DRow In DR
                            DRow.Item("STATUS") = DMS_DATEI_LÖSCH_KENNER
                            DRow.Item("GELOESCHT_AM") = Date.Now
                        Next
                    End If
                    DR = _DS_Daten.Tables(DATATABLE_MODELL).Select("DSID=" & DSID)
                    If DR.Length > 0 Then
                        DR(0).Item("GELOESCHT_AM") = Date.Now
                    End If
                    Grid.Rows.RemoveAt(ht.RowIndex)
                    _DS_Daten.AcceptChanges()
                    Schreibe_Dataset()
                    Lade_Daten()
                    Eingabefelder_Leeren()
                    MsgBox("Der Datensatz wurde gelöscht", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Datensatz löschen")
                End If
            Finally
                Array.Resize(Of DataRow)(DR, 0)
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub event_Cmd_Click(sender As Object, e As System.EventArgs)
        Dim Cmd As Button = sender
        Try
            Cursor = Cursors.WaitCursor
            Select Case Cmd.Name
                Case Cmd_EAN_Web.Name
                    Dim EAN_Nr As String = FNC.FF(Txt_EAN.Text)
                    If EAN_Nr.Length > 0 Then
                        Clipboard.SetText(EAN_Nr)
                        Process.Start("www.google.de")
                    End If
                Case Cmd_Speichern.Name
                    If Not DatenSpeichern() Then
                        If _bKeineSpeicherMeldungAusgeben Then
                            ' Daten wurden nicht gespeichert weil ein Feld nicht gefüllt war
                        Else
                            MsgBox("Daten konnten nicht gespeichert werden", vbOKOnly + MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Speichern")
                        End If
                    Else
                        Lade_Daten()
                        ' 200308: Nicht gewünscht: MsgBox("Daten wurden gespeichert", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Speichern")
                    End If
            End Select
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(sender, ""))
        Finally
            Grid_DMS.ResumeLayout()
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub event_TSB_Click(sender As Object, e As EventArgs)
        Dim TSB As ToolStripButton = sender
        Dim DR() As DataRow = {}
        Try
            Cursor = Cursors.WaitCursor
            Select Case TSB.Name
                Case TSB_Grid_DMS_Copy_Picture.Name
                    If Grid_DMS.ColumnCount > 0 Then
                        Dim FBD As New FolderBrowserDialog With {.SelectedPath = _InitializeDir_BildDatei_Kopie_Erstellen, .ShowNewFolderButton = True, .Description = "Verzeichnis auswählen um Kopien darin abzulegen"}
                        If FBD.ShowDialog(Me) = DialogResult.OK Then
                            _InitializeDir_BildDatei_Kopie_Erstellen = FBD.SelectedPath
                            If Not IO.Directory.Exists(_InitializeDir_BildDatei_Kopie_Erstellen) Then
                                IO.Directory.CreateDirectory(_InitializeDir_BildDatei_Kopie_Erstellen)
                            End If
                            Dim sFileName As String = ""
                            Dim Img As Drawing.Image = Nothing
                            Dim GridCol As DataGridViewImageColumn = Nothing
                            For Each GridCol In Grid_DMS.Columns
                                If FNC.FF(Grid_DMS.Rows(0).Cells(GridCol.Index).Tag, FNC.enmFFArten.FFLong) >= 0 Then
                                    sFileName = _InitializeDir_BildDatei_Kopie_Erstellen & "\" & Grid_DMS.Columns(GridCol.Index).HeaderText
                                    If IO.File.Exists(sFileName) Then IO.File.Delete(sFileName)
                                    Img = Grid_DMS.Rows(0).Cells(GridCol.Index).Value
                                    Img.Save(sFileName)
                                End If
                            Next
                            Process.Start("Explorer.exe", _InitializeDir_BildDatei_Kopie_Erstellen)
                        End If
                    Else
                        MsgBox("Keine Bild-Dateien zum Kopieren vorhanden", vbOKOnly + MsgBoxStyle.Information + vbSystem, "Bild-Dateien kopieren")
                    End If
                Case TSB_Grid_DMS_Resize_Picture.Name
                    If FNC.FF(TSB.Tag, FNC.enmFFArten.FFLong) = 0 Then ' Bild maximieren
                        PicGrid_DMS.Visible = True
                        PicGrid_DMS.Dock = DockStyle.Fill
                        Dim Original As Image = Grid_DMS.Rows(0).Cells(Grid_DMS.FirstDisplayedCell.ColumnIndex).Value
                        PicGrid_DMS.Image = ResizeImage(Original, PicGrid_DMS.Size)
                        PicGrid_DMS.BringToFront()
                        PicGrid_DMS.Focus()
                        TSB.Text = "Bild-Datei minimieren"
                        TSB.Tag = 1
                    Else ' Bild minimieren (ausblenden)
                        TSB.Text = "Bild-Datei maximieren"
                        PicGrid_DMS.Image = Nothing
                        PicGrid_DMS.Dock = DockStyle.None
                        PicGrid_DMS.Visible = False
                        Grid_DMS.BringToFront()
                        TSB.Tag = 0
                    End If
                Case TSB_Grid_DMS_Delete_Picture.Name
                    CMS_Delete_Picture.Show(MousePosition.X, MousePosition.Y)
                Case TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Name
                    If FNC.FF(Lbl_DSID_Value.Text, FNC.enmFFArten.FFLong) > 0 Then
                        Dim ColIndex As Integer = Bilder_Für_Modell_Suchen_Und_Hinzufügen(sender, e)
                        If ColIndex >= 0 Then
                            Grid_DMS.FirstDisplayedScrollingColumnIndex = ColIndex
                            _bMussNochSpeichern = True
                            PicSpeichernInfo.Visible = True
                            Lade_Daten()
                        End If
                    Else
                        MsgBox("Bitte ein Modell wählen", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Bild hinzufügen")
                    End If
                Case TSB_Grid_DMS_Neues_Modell.Name
                    If Grid_DMS.ColumnCount > 0 Then
                        If Not CheckObDatenBearbeitetWurden("Bildwechsel") Then Exit Sub
                        Handler(enmHandler.Remove)
                        Eingabefelder_Leeren()
                        Handler(enmHandler.Add)
                    End If
                    Bilder_Für_Modell_Suchen_Und_Hinzufügen(sender, e)
                Case TSB_Eingabe_Leeren.Name
                    Handler(enmHandler.Remove)
                    Eingabefelder_Leeren()
                    Lade_Daten()
                    Handler(enmHandler.Add)
                    Txt_Maßstab.Focus()
                Case TSB_Modell_Löschen.Name
                    If MsgBox("Soll das Modell gelöscht werden?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Löschen") = vbYes Then

                    End If
                Case TSB_Einstellungen.Name
                    Dim Frm_CFG As New Frm_Einstellungen
                    If Frm_CFG.ShowDialog(Me) = DialogResult.OK Then
                        _InitializeDir = FNC.ReadAppConfig("AUTOMO_PATH", _InitializeDir)
                        _DateiName = FNC.ReadAppConfig("AUTOMO_FILENAME", "Automobile.xml")
                        If Not _InitializeDir.EndsWith("\") Then _InitializeDir &= "\"
                        _AutoMo_FileName = _InitializeDir & _DateiName
                        _InitializeDir_DMS = _InitializeDir & FNC.ReadAppConfig("AUTOMO_DMS_ORDNER", "UNB_DMS")
                        If Not _InitializeDir_DMS.EndsWith("\") Then _InitializeDir_DMS &= "\"
                        _InitializeDir_BildDatei_Kopie_Erstellen = FNC.ReadAppConfig("AUTOMO_UPLOAD_ORDNER", My.Computer.FileSystem.SpecialDirectories.Desktop & "Bildverarbeitung")
                        '
                        If Not IO.File.Exists(_AutoMo_FileName) Then
                            If _DS_Daten Is Nothing Then
                                Lade_Daten()
                            End If
                            Schreibe_Dataset()
                        ElseIf _DS_Daten IsNot Nothing Then
                            _DS_Daten.Clear() : _DS_Daten.Dispose()
                            _DS_Daten = Nothing
                        End If
                        Grid_Suche.DataSource = Nothing
                        _AutoMo_File_Exists = True
                        Lade_Daten()
                        event_TSB_Click(TSB_Eingabe_Leeren, New System.EventArgs)
                    End If
                    Txt_Maßstab.Focus()
                Case TSB_Schließen.Name
                    'If MsgBox("Programm beenden?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle .SystemModal + MsgBoxStyle.DefaultButton2, "Programm beenden") = vbYes Then
                    If Not CheckObDatenBearbeitetWurden("Programm beenden") Then Exit Sub
                    End
                    'End If
            End Select
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(sender, ""))
        Finally
            Array.Resize(Of DataRow)(DR, 0)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub event_Txt_GotFocus(sender As Object, e As EventArgs)
        Dim Txt As TextBox = sender
        Txt.BackColor = Drawing.Color.Yellow
    End Sub
    Private Sub event_Txt_LostFocus(sender As Object, e As System.EventArgs)
        Dim Txt As TextBox = sender
        Try
            Txt.BackColor = Drawing.Color.White
            If FNC.FF(Txt.Tag) <> FNC.FF(Txt.Text) Then
                Txt.Tag = FNC.FF(Txt.Text)
                _bMussNochSpeichern = True
                PicSpeichernInfo.Visible = True
            End If
            '
            Fill_FilterString()
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(sender, ""))
        End Try
    End Sub

    Private Sub Event_Txt_KeyDown(sender As Object, e As KeyEventArgs)
        Dim TB As TextBox = sender
        Select Case TB.Name
            Case Txt_Baujahr.Name
                If e.KeyData >= Keys.D0 AndAlso e.KeyData <= Keys.D9 Then
                ElseIf e.KeyData >= Keys.NumPad0 AndAlso e.KeyData <= Keys.NumPad9 Then
                ElseIf e.KeyData = Keys.Return OrElse e.KeyData = Keys.Enter Then
                ElseIf e.KeyData = Keys.Home OrElse e.KeyData = Keys.End Then
                ElseIf e.KeyData = Keys.Left OrElse e.KeyData = Keys.Right Then
                ElseIf e.KeyData = Keys.Back OrElse e.KeyData = Keys.Delete Then
                Else
                    e.SuppressKeyPress = True
                End If
        End Select
    End Sub

    Private Sub event_Control_MouseEnter(sender As Object, e As EventArgs)
    End Sub

    Private Sub event_Control_MouseLeave(sender As Object, e As EventArgs)
        _TTip.Tag = IntPtr.Zero
        _TTip.SetToolTip(sender, "")
    End Sub
    Private Sub event_Cbo_GotFocus(sender As Object, e As EventArgs)
        Cbo_Hersteller.BackColor = Drawing.Color.Yellow
    End Sub
    Private Sub event_Cbo_LostFocus(sender As Object, e As EventArgs)
        Dim Cbo As ComboBox = sender
        Dim DR() As DataRow = {}
        Dim Value As Object = Nothing
        Dim DRow As DataRow = Nothing
        Dim DT As DataTable = Nothing
        Dim KN_DOCID As Long = 0
        Try
            Cbo.BackColor = Drawing.Color.White
            Select Case Cbo.Name
                Case Cbo_Hersteller.Name
                    Dim sHersteller As String = ""
                    If FNC.FF(Cbo_Hersteller.Text).Length > 0 Then
                        If FNC.FF(Cbo_Hersteller.SelectedValue).Length = 0 Then
                            sHersteller = Cbo_Hersteller.Text
                            DT = _DS_Daten.Tables(DATATABLE_DMS_ARCHIV_NR)
                            DR = DT.Select("HERSTELLER=" & FNC.DB_Text(sHersteller.ToUpper))
                            If DR.Length = 0 Then
                                DRow = DT.NewRow : DT.Rows.Add(DRow)
                                Value = DT.Compute("Max(DSID)", "DSID < " & COMBO_HERSTELLER_SONSTIGE)
                                DRow("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                KN_DOCID = Strings.Right("000" & DRow("DSID"), 3) & "000000000"
                                DRow("HERSTELLER") = FNC.FF(sHersteller).ToUpper
                                DRow("HERSTELLER_DISPLAY") = FNC.FF(sHersteller)
                                DRow("ARCHIV_NR") = KN_DOCID
                                DRow.AcceptChanges()
                                Add_Cbo_BindingSource()
                                Cbo_Hersteller.SelectedValue = DRow("DSID")
                            ElseIf FNC.FF(DR(0).Item("DSID"), FNC.enmFFArten.FFLong) = 0 Then
                                Value = DT.Compute("Max(DSID)", "DSID < " & COMBO_HERSTELLER_SONSTIGE)
                                DR(0).Item("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                DR(0).Item("HERSTELLER_DISPLAY") = FNC.FF(sHersteller)
                                If FNC.FF(DR(0).Item("ARCHIV_NR")).length < 12 Then
                                    DR(0).Item("ARCHIV_NR") = Strings.Right("000" & DR(0).Item("DSID"), 3) & "000000000"
                                End If
                                DR(0).AcceptChanges()
                            End If
                        End If
                    Else
                        'For x As Integer = 0 To Cbo_Hersteller.Items.Count - 1
                        '    If DirectCast(Cbo_Hersteller.Items(x).row, DataRow).Item("DSID") = COMBO_HERSTELLER_SONSTIGE Then
                        '        Cbo_Hersteller.SelectedIndex = x
                        '        Exit For
                        '    End If
                        'Next
                    End If
                Case Cbo_Kategorie.Name
                    Dim sKategorie As String = ""
                    If FNC.FF(Cbo_Kategorie.Text).Length > 0 Then
                        If FNC.FF(Cbo_Kategorie.SelectedValue).Length = 0 Then
                            sKategorie = Cbo_Kategorie.Text
                            DT = _DS_Daten.Tables(DATATABLE_KATEGORIE)
                            DR = DT.Select("KATEGORIE=" & FNC.DB_Text(sKategorie))
                            If DR.Length = 0 Then
                                Dim NewRow As DataRow = DT.NewRow : DT.Rows.Add(NewRow)
                                Value = DT.Compute("Max(DSID)", "")
                                NewRow("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                If NewRow("DSID") = 1 Then
                                    NewRow("KATEGORIE") = ""
                                    NewRow = DT.NewRow : DT.Rows.Add(NewRow)
                                    Value = DT.Compute("Max(DSID)", "")
                                    NewRow("DSID") = FNC.FF(Value, FNC.enmFFArten.FFLong) + 1
                                End If
                                NewRow("KATEGORIE") = sKategorie
                                NewRow.AcceptChanges()
                                Add_Cbo_BindingSource()
                                Schreibe_Dataset()
                                Cbo_Kategorie.SelectedValue = NewRow("DSID")
                            End If
                        End If
                    End If
            End Select
            '
            Fill_FilterString()
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, getErrorInfo(sender, ""))
        End Try
    End Sub
    Private Sub event_Cbo_SelectedValueChanged(sender As Object, e As EventArgs)
        _bMussNochSpeichern = True
    End Sub
    Private Sub event_Cbo_KeyDown(sender As Object, e As KeyEventArgs)
        Dim Cbo As ComboBox = sender
        If e.KeyData = Keys.Enter Then
            Cbo.DroppedDown = False
        Else
            If Cbo.DroppedDown = False Then
                Cbo.DroppedDown = True
            End If
        End If
    End Sub

    Private Sub event_CMS_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        sender.Hide
        Dim DR() As DataRow = {}
        Dim ColIndex As Integer = -1
        Try
            Select Case e.ClickedItem.Name
                Case CMSI_Aktuelles_Bild_Löschen.Name
                    If _CurrentColIndex >= 0 Then
                        If MsgBox(String.Format("Soll das Bild [{0}] gelöscht werden?", Grid_DMS.Columns(_CurrentColIndex).HeaderText), vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Bild-Datei löschen") = MsgBoxResult.Yes Then
                            Grid_DMS.SuspendLayout()
                            ' DR = _DS_Daten.Tables(DATATABLE_DMS).Select("KN_DOCID=" & FNC.DB_Text(Grid_DMS.FirstDisplayedCell.Tag))
                            DR = _DS_Daten.Tables(DATATABLE_DMS).Select("KN_DOCID=" & FNC.DB_Text(Grid_DMS.Rows(0).Cells(_CurrentColIndex).Tag))
                            If DR.Length > 0 Then
                                DR(0).Item("STATUS") = DMS_DATEI_LÖSCH_KENNER
                                DR(0).Item("GELOESCHT_AM") = Date.Now
                                Grid_DMS.Columns.RemoveAt(Grid_DMS.FirstDisplayedCell.ColumnIndex)
                            End If
                            Grid_DMS.ResumeLayout()
                            Schreibe_Anzahl_Bilder()
                            _DS_Daten.AcceptChanges()
                            Schreibe_Dataset()
                        End If
                    Else
                        MsgBox("Bitte ein Bild wählen", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Bild löschen")
                    End If
                Case CMSI_Alle_Bilder_Löschen.Name
                    If MsgBox("Sollen alle Bilder von dem Modell gelöscht werden?", vbYesNo + MsgBoxStyle.Question + MsgBoxStyle.SystemModal + MsgBoxStyle.DefaultButton2, "Bild-Dateien löschen") = MsgBoxResult.Yes Then
                        Grid_DMS.SuspendLayout()
                        For x As Integer = Grid_DMS.ColumnCount - 1 To 0 Step -1
                            If FNC.FF(Grid_DMS.Rows(0).Cells(x).Tag, FNC.enmFFArten.FFLong) > 0 Then
                                DR = _DS_Daten.Tables(DATATABLE_DMS).Select("KN_DOCID=" & FNC.DB_Text(Grid_DMS.Rows(0).Cells(x).Tag))
                                If DR.Length > 0 Then
                                    DR(0).Item("STATUS") = DMS_DATEI_LÖSCH_KENNER
                                    DR(0).Item("GELOESCHT_AM") = Date.Now
                                    Grid_DMS.Columns.RemoveAt(x)
                                End If
                            End If
                        Next
                        Grid_DMS.ResumeLayout()
                        Schreibe_Anzahl_Bilder()
                        _DS_Daten.AcceptChanges()
                        Schreibe_Dataset()
                    End If
            End Select
        Catch ex As Exception
            UNB_Err.Fehlerprotokoll(ex, e.ClickedItem.Name)
        End Try
    End Sub

    Private Function Bilder_Für_Modell_Suchen_Und_Hinzufügen(sender As Object, e As System.EventArgs) As Integer
        Dim rtInt As Integer = -1
        Dim Index As Integer = -1
        Try
            Grid_DMS.SuspendLayout()
            Dim FSB As New OpenFileDialog With {.InitialDirectory = _InitializeDir_DateiSuche, .Multiselect = True, .Filter = "*.JPG|*.JPG|*.JPEG|*.JPEG|*.TIF|*.TIF|*.BMP|*.BMP|*.ico|*.ico|*.GIF|*.GIF|(Alle Dateien)|*.*", .FilterIndex = 1}
            If FSB.ShowDialog(Me) = DialogResult.OK Then
                _InitializeDir_DateiSuche = New IO.FileInfo(FSB.FileName).DirectoryName
                FNC.WriteAppConfig("AUTOMO_DMS_PATH", _InitializeDir_DMS)
                If IsGültiges_Image(FSB.FileNames) Then
                    Grid_DMS.SuspendLayout()
                    If sender.Name = TSB_Grid_DMS_Neues_Modell.Name Then
                        Grid_DMS.ColumnCount = 0
                        Grid_DMS.Rows.Clear()
                    ElseIf Grid_DMS.ColumnCount > 0 Then 'AndAlso (Grid_DMS.ColumnCount - 1) > 0 Then
                        Grid_DMS.Columns.RemoveAt(Grid_DMS.ColumnCount - 1)
                    End If
                    For Each sFileName As String In FSB.FileNames
                        Index = Add_Image_To_Grid_DMS(sFileName, 0)
                        If FNC.FF(Lbl_DSID_Value.Text, FNC.enmFFArten.FFLong) > 0 Then
                            If rtInt = -1 Then ' Thumbnail erzeugen
                                rtInt = Index
                                If Index = 0 Then
                                    Dim Original As Image = Drawing.Image.FromFile(sFileName)
                                    For Each GridRow As DataGridViewRow In Grid_Suche.Rows
                                        If GridRow.Cells("DSID").Value = Lbl_DSID_Value.Text Then
                                            GridRow.Cells(_htColumnName("THUMBNAIL")).value = ResizeImage(Original, New Drawing.Size(48, 48))
                                            Exit For
                                        End If
                                    Next
                                    Grid_Suche.AutoResizeColumns()
                                End If
                            End If
                        End If
                    Next sFileName
                    Add_Image_To_Grid_DMS("", 0) ' Leerspalte anhängen
                    Schreibe_Anzahl_Bilder()
                    Grid_DMS.AutoResizeColumns()
                    Grid_DMS.AutoResizeRows()
                Else
                    MsgBox("Ungültiges Dateiformat", vbOKOnly + MsgBoxStyle.Information + MsgBoxStyle.SystemModal, "Bild-Datei wählen")
                End If
            End If
            '
            Return rtInt
        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

#Region "Allgemeine Property, Methoden/Funktionen"
    Private Function getErrorInfo(sender As Object, XtraInfo As String)
        Dim rtString As String = ""
        If sender IsNot Nothing Then
            rtString = "Sender.Name:" & sender.Name
        End If
        If FNC.FF(XtraInfo).Length > 0 Then
            rtString &= "|" & XtraInfo
        End If
        '
        Return rtString
    End Function

    Private Sub Handler(Aktion As enmHandler)
        RemoveHandler CMS_Delete_Picture.ItemClicked, AddressOf event_CMS_ItemClicked
        RemoveHandler Grid_Suche.SelectionChanged, AddressOf event_Grid_SelectionChanged
        RemoveHandler Grid_Suche.MouseMove, AddressOf event_Grid_Suche_MouseMove
        RemoveHandler Grid_Suche.MouseClick, AddressOf event_Grid_Suche_MouseClick
        RemoveHandler Grid_DMS.SelectionChanged, AddressOf event_Grid_SelectionChanged
        RemoveHandler TSB_Grid_DMS_Delete_Picture.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Grid_DMS_Resize_Picture.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Grid_DMS_Copy_Picture.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Grid_DMS_Neues_Modell.Click, AddressOf event_TSB_Click
        RemoveHandler Cmd_Speichern.Click, AddressOf event_Cmd_Click
        RemoveHandler Cmd_EAN_Web.Click, AddressOf event_Cmd_Click
        RemoveHandler TSB_Schließen.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Einstellungen.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Modell_Löschen.Click, AddressOf event_TSB_Click
        RemoveHandler TSB_Eingabe_Leeren.Click, AddressOf event_TSB_Click
        RemoveHandler Txt_Baujahr.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Baujahr.KeyDown, AddressOf Event_Txt_KeyDown
        RemoveHandler Txt_Fahrer.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_Fahrer.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_EAN.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_EAN.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Farbe.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_Farbe.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Maßstab.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_Maßstab.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Modell.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_Modell.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Hersteller_Nr.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Hersteller_Nr.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Txt_Besonderheit.LostFocus, AddressOf event_Txt_LostFocus
        RemoveHandler Txt_Besonderheit.GotFocus, AddressOf event_Txt_GotFocus
        RemoveHandler Cbo_Hersteller.GotFocus, AddressOf event_Cbo_GotFocus
        RemoveHandler Cbo_Hersteller.LostFocus, AddressOf event_Cbo_LostFocus
        RemoveHandler Cbo_Hersteller.SelectedValueChanged, AddressOf event_Cbo_SelectedValueChanged
        RemoveHandler Cbo_Hersteller.KeyDown, AddressOf event_Cbo_KeyDown
        RemoveHandler Cbo_Kategorie.GotFocus, AddressOf event_Cbo_GotFocus
        RemoveHandler Cbo_Kategorie.LostFocus, AddressOf event_Cbo_LostFocus
        RemoveHandler Cbo_Kategorie.SelectedValueChanged, AddressOf event_Cbo_SelectedValueChanged
        RemoveHandler Cbo_Kategorie.KeyDown, AddressOf event_Cbo_KeyDown

        If Aktion = enmHandler.Add Then
            AddHandler CMS_Delete_Picture.ItemClicked, AddressOf event_CMS_ItemClicked
            AddHandler Grid_Suche.SelectionChanged, AddressOf event_Grid_SelectionChanged
            AddHandler Grid_Suche.MouseMove, AddressOf event_Grid_Suche_MouseMove
            AddHandler Grid_Suche.MouseClick, AddressOf event_Grid_Suche_MouseClick
            AddHandler Grid_DMS.SelectionChanged, AddressOf event_Grid_SelectionChanged
            AddHandler TSB_Grid_DMS_Delete_Picture.Click, AddressOf event_TSB_Click
            AddHandler TSB_Grid_DMS_Resize_Picture.Click, AddressOf event_TSB_Click
            AddHandler TSB_Grid_DMS_Copy_Picture.Click, AddressOf event_TSB_Click
            AddHandler TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Click, AddressOf event_TSB_Click
            AddHandler TSB_Grid_DMS_Neues_Modell.Click, AddressOf event_TSB_Click
            AddHandler Cmd_Speichern.Click, AddressOf event_Cmd_Click
            AddHandler Cmd_EAN_Web.Click, AddressOf event_Cmd_Click
            AddHandler TSB_Schließen.Click, AddressOf event_TSB_Click
            AddHandler TSB_Einstellungen.Click, AddressOf event_TSB_Click
            AddHandler TSB_Modell_Löschen.Click, AddressOf event_TSB_Click
            AddHandler TSB_Eingabe_Leeren.Click, AddressOf event_TSB_Click
            AddHandler Txt_Baujahr.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Baujahr.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Baujahr.KeyDown, AddressOf Event_Txt_KeyDown
            AddHandler Txt_Fahrer.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Fahrer.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_EAN.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_EAN.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Farbe.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Farbe.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Maßstab.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Maßstab.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Modell.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Modell.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Hersteller_Nr.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Hersteller_Nr.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Txt_Besonderheit.LostFocus, AddressOf event_Txt_LostFocus
            AddHandler Txt_Besonderheit.GotFocus, AddressOf event_Txt_GotFocus
            AddHandler Cbo_Hersteller.GotFocus, AddressOf event_Cbo_GotFocus
            AddHandler Cbo_Hersteller.LostFocus, AddressOf event_Cbo_LostFocus
            AddHandler Cbo_Hersteller.SelectedValueChanged, AddressOf event_Cbo_SelectedValueChanged
            AddHandler Cbo_Hersteller.KeyDown, AddressOf event_Cbo_KeyDown
            AddHandler Cbo_Kategorie.GotFocus, AddressOf event_Cbo_GotFocus
            AddHandler Cbo_Kategorie.LostFocus, AddressOf event_Cbo_LostFocus
            AddHandler Cbo_Kategorie.SelectedValueChanged, AddressOf event_Cbo_SelectedValueChanged
            AddHandler Cbo_Kategorie.KeyDown, AddressOf event_Cbo_KeyDown
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
                    rtBool = True
                Case vbCancel
            End Select
        Else
            rtBool = True
        End If
        Return rtBool
    End Function

    Private Function IsGültiges_Image(Dateinamen() As String) As Boolean
        Dim rtBool As Boolean = True
        Dim oFileInfo As IO.FileInfo = Nothing
        Try
            For Each sFileName As String In Dateinamen
                oFileInfo = New IO.FileInfo(sFileName)
                If Not _Gültige_Image_Extension.Contains(";" & oFileInfo.Extension.ToUpper & ";") Then
                    rtBool = False
                    Exit For
                End If
            Next sFileName
        Catch ex As Exception
            Throw
        End Try
        '
        Return rtBool
    End Function
    Private Function getImageFormat(Extension As String) As Imaging.ImageFormat
        Dim rtFormat As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
        Try
            Select Case Extension.ToUpper
                Case "JPG", "JPEG" : rtFormat = Imaging.ImageFormat.Jpeg
                Case "TIF", "TIFF" : rtFormat = Imaging.ImageFormat.Tiff
                Case "BMP" : rtFormat = Imaging.ImageFormat.Bmp
                Case "EMF" : rtFormat = Imaging.ImageFormat.Emf
                Case "EXIF" : rtFormat = Imaging.ImageFormat.Exif
                Case "GIF" : rtFormat = Imaging.ImageFormat.Gif
                Case "ICON" : rtFormat = Imaging.ImageFormat.Icon
                Case "PNG" : rtFormat = Imaging.ImageFormat.Png
                Case "WMF" : rtFormat = Imaging.ImageFormat.Wmf
            End Select
        Catch ex As Exception
            Throw
        End Try
        '
        Return rtFormat
    End Function

    Private Sub Fill_FilterString()
        Handler(enmHandler.Remove)
        Try
            _FilterText = ""
            If FNC.FF(Txt_Maßstab.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_Maßstab.Name) & "=" & FNC.DB_Text(Txt_Maßstab.Text)
            End If
            If FNC.FF(Txt_Modell.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_Modell.Name) & " LIKE " & FNC.DB_Text("%" & Txt_Modell.Text & "%")
            End If
            If FNC.FF(Cbo_Hersteller.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Cbo_Hersteller.Name) & "=" & FNC.DB_Text(Cbo_Hersteller.Text)
            End If
            If FNC.FF(Txt_Hersteller_Nr.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_Hersteller_Nr.Name) & "=" & FNC.DB_Text(Txt_Hersteller_Nr.Text)
            End If
            If FNC.FF(Txt_Fahrer.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_Fahrer.Name) & "=" & FNC.DB_Text(Txt_Fahrer.Text)
            End If
            If FNC.FF(Txt_EAN.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_EAN.Name) & " Like " & FNC.DB_Text(Txt_EAN.Text & "%")
            End If
            If FNC.FF(Txt_Farbe.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Txt_Farbe.Name) & " Like " & FNC.DB_Text("%" & Txt_Farbe.Text & "%")
            End If
            If FNC.FF(Txt_Baujahr.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText = _htColumnName(Txt_Baujahr.Name) & "=" & FNC.DB_Text(Txt_Baujahr.Text)
            End If
            If FNC.FF(Cbo_Kategorie.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText &= _htColumnName(Cbo_Kategorie.Name) & "=" & FNC.DB_Text(Cbo_Kategorie.Text)
            End If
            If FNC.FF(Txt_Besonderheit.Text).Length > 0 Then
                '_FilterText &= IIf(_FilterText.Length > 0, " OR ", "")
                _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
                _FilterText = _htColumnName(Txt_Besonderheit.Name) & "=" & FNC.DB_Text(Txt_Besonderheit.Text)
            End If

            '
            _FilterText &= IIf(_FilterText.Length > 0, " AND ", "")
            _FilterText &= "GELOESCHT_AM Is Null" ' !!!
            '
            If FNC.FF(Lbl_DSID_Value.Text, FNC.enmFFArten.FFLong) > 0 Then
                If _FilterText.Length > 0 Then _FilterText = "(" & _FilterText & ") OR "
                _FilterText &= "(DSID=" & Lbl_DSID_Value.Text & ")"
            End If
            '
            Lade_Daten()
        Catch ex As Exception
            Throw
        Finally
            Handler(enmHandler.Add)
        End Try
    End Sub
    Private Function Prüfe_KN_DocID(KN_DOCID As Long) As String
        Dim rtString As String = ""
        Dim arDir() As String = {}
        Dim sFileName As String = ""
        Dim sDirName As String = ""
        Try
            sFileName = getDateiName(KN_DOCID)
            sDirName = sFileName.Substring(0, 3) & "\" & sFileName.Substring(3, 3) & "\" & sFileName.Substring(6, 3)
            arDir = Split(sDirName, "\")
            If FNC.FF(arDir(2), FNC.enmFFArten.FFLong) = 999 Then
                If FNC.FF(arDir(1), FNC.enmFFArten.FFLong) = 999 Then
                    MsgBox("Verzeichnis-Struktur ist voll!", vbOKOnly + MsgBoxStyle.Exclamation + MsgBoxStyle.SystemModal, "Datei schreiben")
                    Return rtString
                Else
                    arDir(1) = Strings.Right("000" & FNC.FF(arDir(1), FNC.enmFFArten.FFLong) + 1, 3)
                    arDir(2) = "000"
                End If
            End If
            rtString = Join(arDir, "\")
        Catch ex As Exception
            Throw
        Finally
            Array.Resize(Of String)(arDir, 0)
        End Try
        '
        Return rtString
    End Function
    Private Function getDateiName(KN_DocID As Long) As String
        Return Strings.Right("000000000000" & KN_DocID, 12)
    End Function

    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Private Sub Schreibe_Anzahl_Bilder()
        Dim iCount As Integer = Grid_DMS.ColumnCount - 1
        If iCount < 0 Then iCount = 0
        TS_Grid_DMS_Lbl_Anzahl.Text = "Anzahl: (" & iCount & ")"
    End Sub
#End Region
End Class
