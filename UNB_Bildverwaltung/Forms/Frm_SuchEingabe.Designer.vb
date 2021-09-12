<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_SuchEingabe
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_SuchEingabe))
        Me.Grid_Suche = New System.Windows.Forms.DataGridView()
        Me.PImageVerwaltung = New System.Windows.Forms.Panel()
        Me.Grid_DMS = New System.Windows.Forms.DataGridView()
        Me.PicGrid_DMS = New System.Windows.Forms.PictureBox()
        Me.TS_Grid_DMS = New System.Windows.Forms.ToolStrip()
        Me.TSB_Grid_DMS_Resize_Picture = New System.Windows.Forms.ToolStripButton()
        Me.TS_Grid_DMS_Sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Grid_DMS_Copy_Picture = New System.Windows.Forms.ToolStripButton()
        Me.TS_Grid_DMS_Sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Grid_DMS_Neues_Modell = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Grid_DMS_Delete_Picture = New System.Windows.Forms.ToolStripButton()
        Me.Grid_DMS_Sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_Grid_DMS_Lbl_Anzahl = New System.Windows.Forms.ToolStripLabel()
        Me.PEingabe_Daten = New System.Windows.Forms.Panel()
        Me.Cmd_EAN_Web = New System.Windows.Forms.Button()
        Me.Txt_Besonderheit = New System.Windows.Forms.TextBox()
        Me.Lbl_Besonderheit = New System.Windows.Forms.Label()
        Me.Txt_Fahrer = New System.Windows.Forms.TextBox()
        Me.Lbl_Fahrer = New System.Windows.Forms.Label()
        Me.Cbo_Kategorie = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_DSID = New System.Windows.Forms.Label()
        Me.Txt_Maßstab = New System.Windows.Forms.TextBox()
        Me.Lbl_Baujahr = New System.Windows.Forms.Label()
        Me.Txt_Hersteller_Nr = New System.Windows.Forms.TextBox()
        Me.Lbl_Maßstab = New System.Windows.Forms.Label()
        Me.Lbl_Herstelle_Nr = New System.Windows.Forms.Label()
        Me.Txt_Baujahr = New System.Windows.Forms.TextBox()
        Me.Cbo_Hersteller = New System.Windows.Forms.ComboBox()
        Me.Txt_Farbe = New System.Windows.Forms.TextBox()
        Me.Lbl_Hersteller = New System.Windows.Forms.Label()
        Me.Lbl_Farbe = New System.Windows.Forms.Label()
        Me.Txt_EAN = New System.Windows.Forms.TextBox()
        Me.Txt_Modell = New System.Windows.Forms.TextBox()
        Me.Lbl_DSID_Value = New System.Windows.Forms.Label()
        Me.Lbl_Modell = New System.Windows.Forms.Label()
        Me.Lbl_EAN = New System.Windows.Forms.Label()
        Me.PBottom = New System.Windows.Forms.Panel()
        Me.PicSpeichernInfo = New System.Windows.Forms.PictureBox()
        Me.Cmd_Speichern = New System.Windows.Forms.Button()
        Me.TS_Suche = New System.Windows.Forms.ToolStrip()
        Me.TSB_Schließen = New System.Windows.Forms.ToolStripButton()
        Me.TS_Suche_Sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Eingabe_Leeren = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Neu_Erfassen = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Modell_Löschen = New System.Windows.Forms.ToolStripButton()
        Me.TS_Suche_Sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Einstellungen = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Lbl_Keine_Daten = New System.Windows.Forms.Label()
        Me.CMS_Delete_Picture = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMSI_Aktuelles_Bild_Löschen = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMSI_Alle_Bilder_Löschen = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lbl_Angelegt_Am = New System.Windows.Forms.Label()
        Me.Lbl_Angelegt_Am_Info = New System.Windows.Forms.Label()
        CType(Me.Grid_Suche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PImageVerwaltung.SuspendLayout()
        CType(Me.Grid_DMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicGrid_DMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_Grid_DMS.SuspendLayout()
        Me.PEingabe_Daten.SuspendLayout()
        Me.PBottom.SuspendLayout()
        CType(Me.PicSpeichernInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_Suche.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.CMS_Delete_Picture.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_Suche
        '
        Me.Grid_Suche.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_Suche.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Grid_Suche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Suche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Suche.Location = New System.Drawing.Point(0, 0)
        Me.Grid_Suche.Name = "Grid_Suche"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_Suche.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grid_Suche.Size = New System.Drawing.Size(715, 782)
        Me.Grid_Suche.TabIndex = 0
        '
        'PImageVerwaltung
        '
        Me.PImageVerwaltung.Controls.Add(Me.Grid_DMS)
        Me.PImageVerwaltung.Controls.Add(Me.PicGrid_DMS)
        Me.PImageVerwaltung.Controls.Add(Me.TS_Grid_DMS)
        Me.PImageVerwaltung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PImageVerwaltung.Location = New System.Drawing.Point(0, 199)
        Me.PImageVerwaltung.Name = "PImageVerwaltung"
        Me.PImageVerwaltung.Size = New System.Drawing.Size(675, 545)
        Me.PImageVerwaltung.TabIndex = 0
        '
        'Grid_DMS
        '
        Me.Grid_DMS.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_DMS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Grid_DMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_DMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_DMS.Location = New System.Drawing.Point(0, 25)
        Me.Grid_DMS.Name = "Grid_DMS"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid_DMS.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Grid_DMS.Size = New System.Drawing.Size(675, 520)
        Me.Grid_DMS.TabIndex = 1
        '
        'PicGrid_DMS
        '
        Me.PicGrid_DMS.Location = New System.Drawing.Point(3, 28)
        Me.PicGrid_DMS.Name = "PicGrid_DMS"
        Me.PicGrid_DMS.Size = New System.Drawing.Size(29, 24)
        Me.PicGrid_DMS.TabIndex = 18
        Me.PicGrid_DMS.TabStop = False
        Me.PicGrid_DMS.Visible = False
        '
        'TS_Grid_DMS
        '
        Me.TS_Grid_DMS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_Grid_DMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_Grid_DMS_Resize_Picture, Me.TS_Grid_DMS_Sep1, Me.TSB_Grid_DMS_Copy_Picture, Me.TS_Grid_DMS_Sep2, Me.TSB_Grid_DMS_Neues_Modell, Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen, Me.TSB_Grid_DMS_Delete_Picture, Me.Grid_DMS_Sep3, Me.TS_Grid_DMS_Lbl_Anzahl})
        Me.TS_Grid_DMS.Location = New System.Drawing.Point(0, 0)
        Me.TS_Grid_DMS.Name = "TS_Grid_DMS"
        Me.TS_Grid_DMS.Size = New System.Drawing.Size(675, 25)
        Me.TS_Grid_DMS.TabIndex = 0
        Me.TS_Grid_DMS.Text = "ToolStrip1"
        '
        'TSB_Grid_DMS_Resize_Picture
        '
        Me.TSB_Grid_DMS_Resize_Picture.Enabled = False
        Me.TSB_Grid_DMS_Resize_Picture.Image = CType(resources.GetObject("TSB_Grid_DMS_Resize_Picture.Image"), System.Drawing.Image)
        Me.TSB_Grid_DMS_Resize_Picture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Grid_DMS_Resize_Picture.Name = "TSB_Grid_DMS_Resize_Picture"
        Me.TSB_Grid_DMS_Resize_Picture.Size = New System.Drawing.Size(145, 22)
        Me.TSB_Grid_DMS_Resize_Picture.Text = "Bild-Datei maximieren"
        '
        'TS_Grid_DMS_Sep1
        '
        Me.TS_Grid_DMS_Sep1.Name = "TS_Grid_DMS_Sep1"
        Me.TS_Grid_DMS_Sep1.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Grid_DMS_Copy_Picture
        '
        Me.TSB_Grid_DMS_Copy_Picture.Image = CType(resources.GetObject("TSB_Grid_DMS_Copy_Picture.Image"), System.Drawing.Image)
        Me.TSB_Grid_DMS_Copy_Picture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Grid_DMS_Copy_Picture.Name = "TSB_Grid_DMS_Copy_Picture"
        Me.TSB_Grid_DMS_Copy_Picture.Size = New System.Drawing.Size(129, 22)
        Me.TSB_Grid_DMS_Copy_Picture.Text = "Bild-Datei Kopieren"
        '
        'TS_Grid_DMS_Sep2
        '
        Me.TS_Grid_DMS_Sep2.Name = "TS_Grid_DMS_Sep2"
        Me.TS_Grid_DMS_Sep2.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Grid_DMS_Neues_Modell
        '
        Me.TSB_Grid_DMS_Neues_Modell.Image = CType(resources.GetObject("TSB_Grid_DMS_Neues_Modell.Image"), System.Drawing.Image)
        Me.TSB_Grid_DMS_Neues_Modell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Grid_DMS_Neues_Modell.Name = "TSB_Grid_DMS_Neues_Modell"
        Me.TSB_Grid_DMS_Neues_Modell.Size = New System.Drawing.Size(145, 22)
        Me.TSB_Grid_DMS_Neues_Modell.Text = "Neues Modell anlegen"
        '
        'TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen
        '
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Image = CType(resources.GetObject("TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Image"), System.Drawing.Image)
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Name = "TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen"
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Size = New System.Drawing.Size(176, 22)
        Me.TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen.Text = "Bild zum Modell hinzufügen"
        '
        'TSB_Grid_DMS_Delete_Picture
        '
        Me.TSB_Grid_DMS_Delete_Picture.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSB_Grid_DMS_Delete_Picture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Grid_DMS_Delete_Picture.Image = CType(resources.GetObject("TSB_Grid_DMS_Delete_Picture.Image"), System.Drawing.Image)
        Me.TSB_Grid_DMS_Delete_Picture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Grid_DMS_Delete_Picture.Name = "TSB_Grid_DMS_Delete_Picture"
        Me.TSB_Grid_DMS_Delete_Picture.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Grid_DMS_Delete_Picture.Text = "Bild-Datei(en) löschen"
        Me.TSB_Grid_DMS_Delete_Picture.Visible = False
        '
        'Grid_DMS_Sep3
        '
        Me.Grid_DMS_Sep3.Name = "Grid_DMS_Sep3"
        Me.Grid_DMS_Sep3.Size = New System.Drawing.Size(6, 25)
        '
        'TS_Grid_DMS_Lbl_Anzahl
        '
        Me.TS_Grid_DMS_Lbl_Anzahl.Name = "TS_Grid_DMS_Lbl_Anzahl"
        Me.TS_Grid_DMS_Lbl_Anzahl.Size = New System.Drawing.Size(63, 15)
        Me.TS_Grid_DMS_Lbl_Anzahl.Text = "Anzahl: (0)"
        '
        'PEingabe_Daten
        '
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Angelegt_Am_Info)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Angelegt_Am)
        Me.PEingabe_Daten.Controls.Add(Me.Cmd_EAN_Web)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Besonderheit)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Besonderheit)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Fahrer)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Fahrer)
        Me.PEingabe_Daten.Controls.Add(Me.Cbo_Kategorie)
        Me.PEingabe_Daten.Controls.Add(Me.Label1)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_DSID)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Maßstab)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Baujahr)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Hersteller_Nr)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Maßstab)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Herstelle_Nr)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Baujahr)
        Me.PEingabe_Daten.Controls.Add(Me.Cbo_Hersteller)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Farbe)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Hersteller)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Farbe)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_EAN)
        Me.PEingabe_Daten.Controls.Add(Me.Txt_Modell)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_DSID_Value)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_Modell)
        Me.PEingabe_Daten.Controls.Add(Me.Lbl_EAN)
        Me.PEingabe_Daten.Dock = System.Windows.Forms.DockStyle.Top
        Me.PEingabe_Daten.Location = New System.Drawing.Point(0, 0)
        Me.PEingabe_Daten.Name = "PEingabe_Daten"
        Me.PEingabe_Daten.Size = New System.Drawing.Size(675, 199)
        Me.PEingabe_Daten.TabIndex = 0
        '
        'Cmd_EAN_Web
        '
        Me.Cmd_EAN_Web.Location = New System.Drawing.Point(288, 92)
        Me.Cmd_EAN_Web.Name = "Cmd_EAN_Web"
        Me.Cmd_EAN_Web.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_EAN_Web.TabIndex = 22
        Me.Cmd_EAN_Web.TabStop = False
        Me.Cmd_EAN_Web.UseVisualStyleBackColor = True
        '
        'Txt_Besonderheit
        '
        Me.Txt_Besonderheit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Besonderheit.Location = New System.Drawing.Point(76, 173)
        Me.Txt_Besonderheit.MaxLength = 250
        Me.Txt_Besonderheit.Name = "Txt_Besonderheit"
        Me.Txt_Besonderheit.Size = New System.Drawing.Size(596, 20)
        Me.Txt_Besonderheit.TabIndex = 21
        '
        'Lbl_Besonderheit
        '
        Me.Lbl_Besonderheit.AutoSize = True
        Me.Lbl_Besonderheit.Location = New System.Drawing.Point(4, 176)
        Me.Lbl_Besonderheit.Name = "Lbl_Besonderheit"
        Me.Lbl_Besonderheit.Size = New System.Drawing.Size(72, 13)
        Me.Lbl_Besonderheit.TabIndex = 20
        Me.Lbl_Besonderheit.Text = "Besonderheit:"
        '
        'Txt_Fahrer
        '
        Me.Txt_Fahrer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Fahrer.Location = New System.Drawing.Point(368, 121)
        Me.Txt_Fahrer.MaxLength = 250
        Me.Txt_Fahrer.Name = "Txt_Fahrer"
        Me.Txt_Fahrer.Size = New System.Drawing.Size(304, 20)
        Me.Txt_Fahrer.TabIndex = 15
        '
        'Lbl_Fahrer
        '
        Me.Lbl_Fahrer.AutoSize = True
        Me.Lbl_Fahrer.Location = New System.Drawing.Point(291, 124)
        Me.Lbl_Fahrer.Name = "Lbl_Fahrer"
        Me.Lbl_Fahrer.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_Fahrer.TabIndex = 14
        Me.Lbl_Fahrer.Text = "Fahrer:"
        '
        'Cbo_Kategorie
        '
        Me.Cbo_Kategorie.FormattingEnabled = True
        Me.Cbo_Kategorie.Location = New System.Drawing.Point(76, 120)
        Me.Cbo_Kategorie.MaxDropDownItems = 10
        Me.Cbo_Kategorie.MaxLength = 250
        Me.Cbo_Kategorie.Name = "Cbo_Kategorie"
        Me.Cbo_Kategorie.Size = New System.Drawing.Size(209, 21)
        Me.Cbo_Kategorie.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Kategorie:"
        '
        'Lbl_DSID
        '
        Me.Lbl_DSID.AutoSize = True
        Me.Lbl_DSID.Location = New System.Drawing.Point(4, 0)
        Me.Lbl_DSID.Name = "Lbl_DSID"
        Me.Lbl_DSID.Size = New System.Drawing.Size(24, 13)
        Me.Lbl_DSID.TabIndex = 0
        Me.Lbl_DSID.Text = "Nr.:"
        '
        'Txt_Maßstab
        '
        Me.Txt_Maßstab.Location = New System.Drawing.Point(76, 16)
        Me.Txt_Maßstab.MaxLength = 50
        Me.Txt_Maßstab.Name = "Txt_Maßstab"
        Me.Txt_Maßstab.Size = New System.Drawing.Size(71, 20)
        Me.Txt_Maßstab.TabIndex = 3
        '
        'Lbl_Baujahr
        '
        Me.Lbl_Baujahr.AutoSize = True
        Me.Lbl_Baujahr.Location = New System.Drawing.Point(162, 150)
        Me.Lbl_Baujahr.Name = "Lbl_Baujahr"
        Me.Lbl_Baujahr.Size = New System.Drawing.Size(46, 13)
        Me.Lbl_Baujahr.TabIndex = 18
        Me.Lbl_Baujahr.Text = "Baujahr:"
        '
        'Txt_Hersteller_Nr
        '
        Me.Txt_Hersteller_Nr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Hersteller_Nr.Location = New System.Drawing.Point(368, 68)
        Me.Txt_Hersteller_Nr.MaxLength = 250
        Me.Txt_Hersteller_Nr.Name = "Txt_Hersteller_Nr"
        Me.Txt_Hersteller_Nr.Size = New System.Drawing.Size(304, 20)
        Me.Txt_Hersteller_Nr.TabIndex = 9
        '
        'Lbl_Maßstab
        '
        Me.Lbl_Maßstab.AutoSize = True
        Me.Lbl_Maßstab.Location = New System.Drawing.Point(4, 19)
        Me.Lbl_Maßstab.Name = "Lbl_Maßstab"
        Me.Lbl_Maßstab.Size = New System.Drawing.Size(51, 13)
        Me.Lbl_Maßstab.TabIndex = 2
        Me.Lbl_Maßstab.Text = "Maßstab:"
        '
        'Lbl_Herstelle_Nr
        '
        Me.Lbl_Herstelle_Nr.AutoSize = True
        Me.Lbl_Herstelle_Nr.Location = New System.Drawing.Point(291, 71)
        Me.Lbl_Herstelle_Nr.Name = "Lbl_Herstelle_Nr"
        Me.Lbl_Herstelle_Nr.Size = New System.Drawing.Size(71, 13)
        Me.Lbl_Herstelle_Nr.TabIndex = 8
        Me.Lbl_Herstelle_Nr.Text = "Hersteller-Nr.:"
        '
        'Txt_Baujahr
        '
        Me.Txt_Baujahr.Location = New System.Drawing.Point(214, 147)
        Me.Txt_Baujahr.MaxLength = 4
        Me.Txt_Baujahr.Name = "Txt_Baujahr"
        Me.Txt_Baujahr.Size = New System.Drawing.Size(71, 20)
        Me.Txt_Baujahr.TabIndex = 19
        Me.Txt_Baujahr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cbo_Hersteller
        '
        Me.Cbo_Hersteller.FormattingEnabled = True
        Me.Cbo_Hersteller.Location = New System.Drawing.Point(76, 68)
        Me.Cbo_Hersteller.MaxDropDownItems = 10
        Me.Cbo_Hersteller.MaxLength = 250
        Me.Cbo_Hersteller.Name = "Cbo_Hersteller"
        Me.Cbo_Hersteller.Size = New System.Drawing.Size(209, 21)
        Me.Cbo_Hersteller.TabIndex = 7
        '
        'Txt_Farbe
        '
        Me.Txt_Farbe.Location = New System.Drawing.Point(76, 147)
        Me.Txt_Farbe.MaxLength = 50
        Me.Txt_Farbe.Name = "Txt_Farbe"
        Me.Txt_Farbe.Size = New System.Drawing.Size(71, 20)
        Me.Txt_Farbe.TabIndex = 17
        '
        'Lbl_Hersteller
        '
        Me.Lbl_Hersteller.AutoSize = True
        Me.Lbl_Hersteller.Location = New System.Drawing.Point(4, 71)
        Me.Lbl_Hersteller.Name = "Lbl_Hersteller"
        Me.Lbl_Hersteller.Size = New System.Drawing.Size(54, 13)
        Me.Lbl_Hersteller.TabIndex = 6
        Me.Lbl_Hersteller.Text = "Hersteller:"
        '
        'Lbl_Farbe
        '
        Me.Lbl_Farbe.AutoSize = True
        Me.Lbl_Farbe.Location = New System.Drawing.Point(4, 150)
        Me.Lbl_Farbe.Name = "Lbl_Farbe"
        Me.Lbl_Farbe.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Farbe.TabIndex = 16
        Me.Lbl_Farbe.Text = "Farbe:"
        '
        'Txt_EAN
        '
        Me.Txt_EAN.Location = New System.Drawing.Point(76, 94)
        Me.Txt_EAN.MaxLength = 250
        Me.Txt_EAN.Name = "Txt_EAN"
        Me.Txt_EAN.Size = New System.Drawing.Size(209, 20)
        Me.Txt_EAN.TabIndex = 11
        '
        'Txt_Modell
        '
        Me.Txt_Modell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Modell.Location = New System.Drawing.Point(76, 42)
        Me.Txt_Modell.MaxLength = 250
        Me.Txt_Modell.Name = "Txt_Modell"
        Me.Txt_Modell.Size = New System.Drawing.Size(596, 20)
        Me.Txt_Modell.TabIndex = 5
        '
        'Lbl_DSID_Value
        '
        Me.Lbl_DSID_Value.AutoSize = True
        Me.Lbl_DSID_Value.Location = New System.Drawing.Point(34, 0)
        Me.Lbl_DSID_Value.Name = "Lbl_DSID_Value"
        Me.Lbl_DSID_Value.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_DSID_Value.TabIndex = 1
        Me.Lbl_DSID_Value.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Lbl_Modell
        '
        Me.Lbl_Modell.AutoSize = True
        Me.Lbl_Modell.Location = New System.Drawing.Point(4, 45)
        Me.Lbl_Modell.Name = "Lbl_Modell"
        Me.Lbl_Modell.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_Modell.TabIndex = 4
        Me.Lbl_Modell.Text = "Modell:"
        '
        'Lbl_EAN
        '
        Me.Lbl_EAN.AutoSize = True
        Me.Lbl_EAN.Location = New System.Drawing.Point(4, 97)
        Me.Lbl_EAN.Name = "Lbl_EAN"
        Me.Lbl_EAN.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_EAN.TabIndex = 10
        Me.Lbl_EAN.Text = "EAN-Nr.:"
        '
        'PBottom
        '
        Me.PBottom.Controls.Add(Me.PicSpeichernInfo)
        Me.PBottom.Controls.Add(Me.Cmd_Speichern)
        Me.PBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PBottom.Location = New System.Drawing.Point(0, 744)
        Me.PBottom.Name = "PBottom"
        Me.PBottom.Size = New System.Drawing.Size(675, 38)
        Me.PBottom.TabIndex = 1
        '
        'PicSpeichernInfo
        '
        Me.PicSpeichernInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PicSpeichernInfo.Image = Global.UNB_Bildverwaltung.My.Resources.Resources.Fall_right
        Me.PicSpeichernInfo.Location = New System.Drawing.Point(254, 8)
        Me.PicSpeichernInfo.Name = "PicSpeichernInfo"
        Me.PicSpeichernInfo.Size = New System.Drawing.Size(26, 21)
        Me.PicSpeichernInfo.TabIndex = 1
        Me.PicSpeichernInfo.TabStop = False
        Me.PicSpeichernInfo.Visible = False
        '
        'Cmd_Speichern
        '
        Me.Cmd_Speichern.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Cmd_Speichern.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Speichern.Location = New System.Drawing.Point(280, 2)
        Me.Cmd_Speichern.Name = "Cmd_Speichern"
        Me.Cmd_Speichern.Size = New System.Drawing.Size(135, 34)
        Me.Cmd_Speichern.TabIndex = 0
        Me.Cmd_Speichern.Text = "Speichern"
        Me.Cmd_Speichern.UseVisualStyleBackColor = True
        '
        'TS_Suche
        '
        Me.TS_Suche.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_Suche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_Schließen, Me.TS_Suche_Sep1, Me.TSB_Eingabe_Leeren, Me.TSB_Neu_Erfassen, Me.TSB_Modell_Löschen, Me.TS_Suche_Sep2, Me.TSB_Einstellungen})
        Me.TS_Suche.Location = New System.Drawing.Point(0, 0)
        Me.TS_Suche.Name = "TS_Suche"
        Me.TS_Suche.Size = New System.Drawing.Size(1394, 25)
        Me.TS_Suche.TabIndex = 0
        Me.TS_Suche.Text = "ToolStrip1"
        '
        'TSB_Schließen
        '
        Me.TSB_Schließen.Image = CType(resources.GetObject("TSB_Schließen.Image"), System.Drawing.Image)
        Me.TSB_Schließen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Schließen.Name = "TSB_Schließen"
        Me.TSB_Schließen.Size = New System.Drawing.Size(133, 22)
        Me.TSB_Schließen.Text = "Programm beenden"
        '
        'TS_Suche_Sep1
        '
        Me.TS_Suche_Sep1.Name = "TS_Suche_Sep1"
        Me.TS_Suche_Sep1.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Eingabe_Leeren
        '
        Me.TSB_Eingabe_Leeren.Image = CType(resources.GetObject("TSB_Eingabe_Leeren.Image"), System.Drawing.Image)
        Me.TSB_Eingabe_Leeren.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Eingabe_Leeren.Name = "TSB_Eingabe_Leeren"
        Me.TSB_Eingabe_Leeren.Size = New System.Drawing.Size(104, 22)
        Me.TSB_Eingabe_Leeren.Text = "Eingabe leeren"
        '
        'TSB_Neu_Erfassen
        '
        Me.TSB_Neu_Erfassen.Image = CType(resources.GetObject("TSB_Neu_Erfassen.Image"), System.Drawing.Image)
        Me.TSB_Neu_Erfassen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Neu_Erfassen.Name = "TSB_Neu_Erfassen"
        Me.TSB_Neu_Erfassen.Size = New System.Drawing.Size(146, 22)
        Me.TSB_Neu_Erfassen.Text = "Neues Modell erfassen"
        Me.TSB_Neu_Erfassen.Visible = False
        '
        'TSB_Modell_Löschen
        '
        Me.TSB_Modell_Löschen.Image = CType(resources.GetObject("TSB_Modell_Löschen.Image"), System.Drawing.Image)
        Me.TSB_Modell_Löschen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Modell_Löschen.Name = "TSB_Modell_Löschen"
        Me.TSB_Modell_Löschen.Size = New System.Drawing.Size(108, 22)
        Me.TSB_Modell_Löschen.Text = "Modell löschen"
        Me.TSB_Modell_Löschen.Visible = False
        '
        'TS_Suche_Sep2
        '
        Me.TS_Suche_Sep2.Name = "TS_Suche_Sep2"
        Me.TS_Suche_Sep2.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Einstellungen
        '
        Me.TSB_Einstellungen.Image = CType(resources.GetObject("TSB_Einstellungen.Image"), System.Drawing.Image)
        Me.TSB_Einstellungen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Einstellungen.Name = "TSB_Einstellungen"
        Me.TSB_Einstellungen.Size = New System.Drawing.Size(98, 22)
        Me.TSB_Einstellungen.Text = "Einstellungen"
        '
        'SplitContainer
        '
        Me.SplitContainer.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Panel1.Controls.Add(Me.PImageVerwaltung)
        Me.SplitContainer.Panel1.Controls.Add(Me.PBottom)
        Me.SplitContainer.Panel1.Controls.Add(Me.PEingabe_Daten)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Panel2.Controls.Add(Me.Lbl_Keine_Daten)
        Me.SplitContainer.Panel2.Controls.Add(Me.Grid_Suche)
        Me.SplitContainer.Size = New System.Drawing.Size(1394, 782)
        Me.SplitContainer.SplitterDistance = 675
        Me.SplitContainer.TabIndex = 5
        '
        'Lbl_Keine_Daten
        '
        Me.Lbl_Keine_Daten.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lbl_Keine_Daten.AutoSize = True
        Me.Lbl_Keine_Daten.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Keine_Daten.Location = New System.Drawing.Point(193, 105)
        Me.Lbl_Keine_Daten.Name = "Lbl_Keine_Daten"
        Me.Lbl_Keine_Daten.Size = New System.Drawing.Size(328, 20)
        Me.Lbl_Keine_Daten.TabIndex = 1
        Me.Lbl_Keine_Daten.Text = "Keine Daten für diese Suche vorhanden"
        Me.Lbl_Keine_Daten.Visible = False
        '
        'CMS_Delete_Picture
        '
        Me.CMS_Delete_Picture.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMSI_Aktuelles_Bild_Löschen, Me.CMS_Sep1, Me.CMSI_Alle_Bilder_Löschen})
        Me.CMS_Delete_Picture.Name = "CMS_Delete_Picture"
        Me.CMS_Delete_Picture.Size = New System.Drawing.Size(190, 54)
        '
        'CMSI_Aktuelles_Bild_Löschen
        '
        Me.CMSI_Aktuelles_Bild_Löschen.Name = "CMSI_Aktuelles_Bild_Löschen"
        Me.CMSI_Aktuelles_Bild_Löschen.Size = New System.Drawing.Size(189, 22)
        Me.CMSI_Aktuelles_Bild_Löschen.Text = "Aktuelles Bild löschen"
        '
        'CMS_Sep1
        '
        Me.CMS_Sep1.Name = "CMS_Sep1"
        Me.CMS_Sep1.Size = New System.Drawing.Size(186, 6)
        '
        'CMSI_Alle_Bilder_Löschen
        '
        Me.CMSI_Alle_Bilder_Löschen.Name = "CMSI_Alle_Bilder_Löschen"
        Me.CMSI_Alle_Bilder_Löschen.Size = New System.Drawing.Size(189, 22)
        Me.CMSI_Alle_Bilder_Löschen.Text = "Alle Bilder löschen"
        '
        'Lbl_Angelegt_Am
        '
        Me.Lbl_Angelegt_Am.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Angelegt_Am.AutoSize = True
        Me.Lbl_Angelegt_Am.Location = New System.Drawing.Point(518, 19)
        Me.Lbl_Angelegt_Am.Name = "Lbl_Angelegt_Am"
        Me.Lbl_Angelegt_Am.Size = New System.Drawing.Size(69, 13)
        Me.Lbl_Angelegt_Am.TabIndex = 23
        Me.Lbl_Angelegt_Am.Text = "Angelegt am:"
        '
        'Lbl_Angelegt_Am_Info
        '
        Me.Lbl_Angelegt_Am_Info.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Angelegt_Am_Info.AutoSize = True
        Me.Lbl_Angelegt_Am_Info.Location = New System.Drawing.Point(587, 19)
        Me.Lbl_Angelegt_Am_Info.Name = "Lbl_Angelegt_Am_Info"
        Me.Lbl_Angelegt_Am_Info.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Angelegt_Am_Info.TabIndex = 24
        '
        'Frm_SuchEingabe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1394, 807)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.TS_Suche)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_SuchEingabe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UNB-Soft: Bildverwaltung"
        CType(Me.Grid_Suche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PImageVerwaltung.ResumeLayout(False)
        Me.PImageVerwaltung.PerformLayout()
        CType(Me.Grid_DMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicGrid_DMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_Grid_DMS.ResumeLayout(False)
        Me.TS_Grid_DMS.PerformLayout()
        Me.PEingabe_Daten.ResumeLayout(False)
        Me.PEingabe_Daten.PerformLayout()
        Me.PBottom.ResumeLayout(False)
        CType(Me.PicSpeichernInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_Suche.ResumeLayout(False)
        Me.TS_Suche.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.Panel2.PerformLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.CMS_Delete_Picture.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid_Suche As DataGridView
    Friend WithEvents PImageVerwaltung As Panel
    Friend WithEvents TS_Suche As ToolStrip
    Friend WithEvents TSB_Schließen As ToolStripButton
    Friend WithEvents TS_Suche_Sep2 As ToolStripSeparator
    Friend WithEvents TSB_Einstellungen As ToolStripButton
    Friend WithEvents PBottom As Panel
    Friend WithEvents Cmd_Speichern As Button
    Friend WithEvents Lbl_DSID_Value As Label
    Friend WithEvents Lbl_DSID As Label
    Friend WithEvents Txt_Modell As TextBox
    Friend WithEvents Lbl_Modell As Label
    Friend WithEvents Txt_Farbe As TextBox
    Friend WithEvents Lbl_Farbe As Label
    Friend WithEvents Txt_Maßstab As TextBox
    Friend WithEvents Lbl_Maßstab As Label
    Friend WithEvents Txt_Baujahr As TextBox
    Friend WithEvents Lbl_Baujahr As Label
    Friend WithEvents Lbl_Hersteller As Label
    Friend WithEvents Txt_EAN As TextBox
    Friend WithEvents Lbl_EAN As Label
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents TS_Suche_Sep1 As ToolStripSeparator
    Friend WithEvents TSB_Neu_Erfassen As ToolStripButton
    Friend WithEvents TSB_Modell_Löschen As ToolStripButton
    Friend WithEvents TSB_Eingabe_Leeren As ToolStripButton
    Friend WithEvents PicSpeichernInfo As PictureBox
    Friend WithEvents Grid_DMS As DataGridView
    Friend WithEvents Lbl_Keine_Daten As Label
    Friend WithEvents Cbo_Hersteller As ComboBox
    Friend WithEvents Txt_Hersteller_Nr As TextBox
    Friend WithEvents Lbl_Herstelle_Nr As Label
    Friend WithEvents TS_Grid_DMS As ToolStrip
    Friend WithEvents TS_Grid_DMS_Sep1 As ToolStripSeparator
    Friend WithEvents TSB_Grid_DMS_Bilder_Zu_Modell_Hinzufügen As ToolStripButton
    Friend WithEvents TSB_Grid_DMS_Delete_Picture As ToolStripButton
    Friend WithEvents TSB_Grid_DMS_Resize_Picture As ToolStripButton
    Friend WithEvents PicGrid_DMS As PictureBox
    Friend WithEvents PEingabe_Daten As Panel
    Friend WithEvents TSB_Grid_DMS_Copy_Picture As ToolStripButton
    Friend WithEvents TS_Grid_DMS_Sep2 As ToolStripSeparator
    Friend WithEvents Cbo_Kategorie As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Fahrer As TextBox
    Friend WithEvents Lbl_Fahrer As Label
    Friend WithEvents CMS_Delete_Picture As ContextMenuStrip
    Friend WithEvents CMSI_Aktuelles_Bild_Löschen As ToolStripMenuItem
    Friend WithEvents CMS_Sep1 As ToolStripSeparator
    Friend WithEvents CMSI_Alle_Bilder_Löschen As ToolStripMenuItem
    Friend WithEvents Grid_DMS_Sep3 As ToolStripSeparator
    Friend WithEvents TS_Grid_DMS_Lbl_Anzahl As ToolStripLabel
    Friend WithEvents Txt_Besonderheit As TextBox
    Friend WithEvents Lbl_Besonderheit As Label
    Friend WithEvents Cmd_EAN_Web As Button
    Friend WithEvents TSB_Grid_DMS_Neues_Modell As ToolStripButton
    Friend WithEvents Lbl_Angelegt_Am_Info As Label
    Friend WithEvents Lbl_Angelegt_Am As Label
End Class
