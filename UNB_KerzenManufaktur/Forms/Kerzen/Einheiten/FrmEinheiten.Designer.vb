<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEinheiten
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEinheiten))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSB_Neu = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Edit = New System.Windows.Forms.ToolStripButton()
        Me.TSB_Delete = New System.Windows.Forms.ToolStripButton()
        Me.TS_Sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_Drucken = New System.Windows.Forms.ToolStripButton()
        Me.TSB_PDF = New System.Windows.Forms.ToolStripButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.Lbl_Keine_Daten = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_Neu, Me.TSB_Edit, Me.TSB_Delete, Me.TS_Sep1, Me.TSB_Drucken, Me.TSB_PDF})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSB_Neu
        '
        Me.TSB_Neu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Neu.Image = CType(resources.GetObject("TSB_Neu.Image"), System.Drawing.Image)
        Me.TSB_Neu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Neu.Name = "TSB_Neu"
        Me.TSB_Neu.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Neu.Text = "Neuen Datensatz erfassen"
        '
        'TSB_Edit
        '
        Me.TSB_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Edit.Image = CType(resources.GetObject("TSB_Edit.Image"), System.Drawing.Image)
        Me.TSB_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Edit.Name = "TSB_Edit"
        Me.TSB_Edit.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Edit.Text = "Datensatz bearbeiten"
        '
        'TSB_Delete
        '
        Me.TSB_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Delete.Image = CType(resources.GetObject("TSB_Delete.Image"), System.Drawing.Image)
        Me.TSB_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Delete.Name = "TSB_Delete"
        Me.TSB_Delete.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Delete.Text = "Datensatz löschen"
        '
        'TS_Sep1
        '
        Me.TS_Sep1.Name = "TS_Sep1"
        Me.TS_Sep1.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_Drucken
        '
        Me.TSB_Drucken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Drucken.Image = CType(resources.GetObject("TSB_Drucken.Image"), System.Drawing.Image)
        Me.TSB_Drucken.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Drucken.Name = "TSB_Drucken"
        Me.TSB_Drucken.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Drucken.Text = "Liste Drucken"
        '
        'TSB_PDF
        '
        Me.TSB_PDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_PDF.Image = CType(resources.GetObject("TSB_PDF.Image"), System.Drawing.Image)
        Me.TSB_PDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_PDF.Name = "TSB_PDF"
        Me.TSB_PDF.Size = New System.Drawing.Size(23, 22)
        Me.TSB_PDF.Text = "Liste als PDF ausgeben"
        '
        'Grid
        '
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.Location = New System.Drawing.Point(0, 25)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(800, 425)
        Me.Grid.TabIndex = 1
        '
        'Lbl_Keine_Daten
        '
        Me.Lbl_Keine_Daten.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lbl_Keine_Daten.AutoSize = True
        Me.Lbl_Keine_Daten.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Keine_Daten.Location = New System.Drawing.Point(270, 77)
        Me.Lbl_Keine_Daten.Name = "Lbl_Keine_Daten"
        Me.Lbl_Keine_Daten.Size = New System.Drawing.Size(291, 20)
        Me.Lbl_Keine_Daten.TabIndex = 2
        Me.Lbl_Keine_Daten.Text = "Keine Daten für diese Suche vorhanden"
        Me.Lbl_Keine_Daten.Visible = False
        '
        'FrmEinheiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Keine_Daten)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmEinheiten"
        Me.Text = "Einheiten"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TSB_Neu As ToolStripButton
    Friend WithEvents TSB_Edit As ToolStripButton
    Friend WithEvents TSB_Delete As ToolStripButton
    Friend WithEvents TS_Sep1 As ToolStripSeparator
    Friend WithEvents TSB_Drucken As ToolStripButton
    Friend WithEvents TSB_PDF As ToolStripButton
    Friend WithEvents Grid As DataGridView
    Friend WithEvents Lbl_Keine_Daten As Label
End Class
