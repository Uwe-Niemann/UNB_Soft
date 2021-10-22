<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgEinheiten
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
        Me.Cmd_Speichern = New System.Windows.Forms.Button()
        Me.Cmd_Abbrechen = New System.Windows.Forms.Button()
        Me.txtBez = New System.Windows.Forms.TextBox()
        Me.Lbl_Bez = New System.Windows.Forms.Label()
        Me.Lbl_EK_Faktor = New System.Windows.Forms.Label()
        Me.TxtEkFaktor = New System.Windows.Forms.TextBox()
        Me.Lbl_Faktor = New System.Windows.Forms.Label()
        Me.txtFaktor = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Cmd_Speichern
        '
        Me.Cmd_Speichern.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Cmd_Speichern.Location = New System.Drawing.Point(49, 96)
        Me.Cmd_Speichern.Name = "Cmd_Speichern"
        Me.Cmd_Speichern.Size = New System.Drawing.Size(127, 29)
        Me.Cmd_Speichern.TabIndex = 6
        Me.Cmd_Speichern.Text = "&Speichern"
        Me.Cmd_Speichern.UseVisualStyleBackColor = True
        '
        'Cmd_Abbrechen
        '
        Me.Cmd_Abbrechen.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Cmd_Abbrechen.Location = New System.Drawing.Point(182, 96)
        Me.Cmd_Abbrechen.Name = "Cmd_Abbrechen"
        Me.Cmd_Abbrechen.Size = New System.Drawing.Size(127, 29)
        Me.Cmd_Abbrechen.TabIndex = 7
        Me.Cmd_Abbrechen.Text = "Abbre&chen"
        Me.Cmd_Abbrechen.UseVisualStyleBackColor = True
        '
        'txtBez
        '
        Me.txtBez.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBez.Location = New System.Drawing.Point(97, 14)
        Me.txtBez.MaxLength = 250
        Me.txtBez.Name = "txtBez"
        Me.txtBez.Size = New System.Drawing.Size(250, 20)
        Me.txtBez.TabIndex = 1
        '
        'Lbl_Bez
        '
        Me.Lbl_Bez.AutoSize = True
        Me.Lbl_Bez.Location = New System.Drawing.Point(12, 17)
        Me.Lbl_Bez.Name = "Lbl_Bez"
        Me.Lbl_Bez.Size = New System.Drawing.Size(72, 13)
        Me.Lbl_Bez.TabIndex = 0
        Me.Lbl_Bez.Text = "Bezeichnung:"
        '
        'Lbl_EK_Faktor
        '
        Me.Lbl_EK_Faktor.AutoSize = True
        Me.Lbl_EK_Faktor.Location = New System.Drawing.Point(12, 43)
        Me.Lbl_EK_Faktor.Name = "Lbl_EK_Faktor"
        Me.Lbl_EK_Faktor.Size = New System.Drawing.Size(79, 13)
        Me.Lbl_EK_Faktor.TabIndex = 2
        Me.Lbl_EK_Faktor.Text = "Einkauf-Faktor:"
        '
        'TxtEkFaktor
        '
        Me.TxtEkFaktor.Location = New System.Drawing.Point(97, 40)
        Me.TxtEkFaktor.MaxLength = 10
        Me.TxtEkFaktor.Name = "TxtEkFaktor"
        Me.TxtEkFaktor.Size = New System.Drawing.Size(79, 20)
        Me.TxtEkFaktor.TabIndex = 3
        Me.TxtEkFaktor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Faktor
        '
        Me.Lbl_Faktor.AutoSize = True
        Me.Lbl_Faktor.Location = New System.Drawing.Point(12, 69)
        Me.Lbl_Faktor.Name = "Lbl_Faktor"
        Me.Lbl_Faktor.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_Faktor.TabIndex = 4
        Me.Lbl_Faktor.Text = "Faktor:"
        '
        'txtFaktor
        '
        Me.txtFaktor.Location = New System.Drawing.Point(97, 66)
        Me.txtFaktor.MaxLength = 10
        Me.txtFaktor.Name = "txtFaktor"
        Me.txtFaktor.Size = New System.Drawing.Size(79, 20)
        Me.txtFaktor.TabIndex = 5
        Me.txtFaktor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DlgEinheiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 134)
        Me.Controls.Add(Me.Lbl_Faktor)
        Me.Controls.Add(Me.txtFaktor)
        Me.Controls.Add(Me.Lbl_EK_Faktor)
        Me.Controls.Add(Me.TxtEkFaktor)
        Me.Controls.Add(Me.Lbl_Bez)
        Me.Controls.Add(Me.txtBez)
        Me.Controls.Add(Me.Cmd_Abbrechen)
        Me.Controls.Add(Me.Cmd_Speichern)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgEinheiten"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Einheiten erfassen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cmd_Speichern As Button
    Friend WithEvents Cmd_Abbrechen As Button
    Friend WithEvents txtBez As TextBox
    Friend WithEvents Lbl_Bez As Label
    Friend WithEvents Lbl_EK_Faktor As Label
    Friend WithEvents TxtEkFaktor As TextBox
    Friend WithEvents Lbl_Faktor As Label
    Friend WithEvents txtFaktor As TextBox
End Class
