<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Einstellungen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Einstellungen))
        Me.Lbl_Programmpfad = New System.Windows.Forms.Label()
        Me.Lbl_UploadPfad = New System.Windows.Forms.Label()
        Me.Txt_ProgrammPfad = New System.Windows.Forms.TextBox()
        Me.Txt_UploadPfad = New System.Windows.Forms.TextBox()
        Me.Cmd_ProgrammPfad = New System.Windows.Forms.Button()
        Me.Cmd_UploadPfad = New System.Windows.Forms.Button()
        Me.Cmd_Speichern = New System.Windows.Forms.Button()
        Me.Cmd_Abbruch = New System.Windows.Forms.Button()
        Me.PicSpeichernInfo = New System.Windows.Forms.PictureBox()
        CType(Me.PicSpeichernInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Programmpfad
        '
        Me.Lbl_Programmpfad.AutoSize = True
        Me.Lbl_Programmpfad.Location = New System.Drawing.Point(12, 16)
        Me.Lbl_Programmpfad.Name = "Lbl_Programmpfad"
        Me.Lbl_Programmpfad.Size = New System.Drawing.Size(114, 13)
        Me.Lbl_Programmpfad.TabIndex = 0
        Me.Lbl_Programmpfad.Text = "Programm-Verzeichnis:"
        '
        'Lbl_UploadPfad
        '
        Me.Lbl_UploadPfad.AutoSize = True
        Me.Lbl_UploadPfad.Location = New System.Drawing.Point(12, 48)
        Me.Lbl_UploadPfad.Name = "Lbl_UploadPfad"
        Me.Lbl_UploadPfad.Size = New System.Drawing.Size(101, 13)
        Me.Lbl_UploadPfad.TabIndex = 1
        Me.Lbl_UploadPfad.Text = "Upload-Verzeichnis:"
        '
        'Txt_ProgrammPfad
        '
        Me.Txt_ProgrammPfad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_ProgrammPfad.Location = New System.Drawing.Point(132, 13)
        Me.Txt_ProgrammPfad.Name = "Txt_ProgrammPfad"
        Me.Txt_ProgrammPfad.Size = New System.Drawing.Size(367, 20)
        Me.Txt_ProgrammPfad.TabIndex = 2
        '
        'Txt_UplodPfad
        '
        Me.Txt_UploadPfad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_UploadPfad.Location = New System.Drawing.Point(132, 45)
        Me.Txt_UploadPfad.Name = "Txt_UplodPfad"
        Me.Txt_UploadPfad.Size = New System.Drawing.Size(367, 20)
        Me.Txt_UploadPfad.TabIndex = 3
        '
        'Cmd_ProgrammPfad
        '
        Me.Cmd_ProgrammPfad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_ProgrammPfad.Location = New System.Drawing.Point(505, 11)
        Me.Cmd_ProgrammPfad.Name = "Cmd_ProgrammPfad"
        Me.Cmd_ProgrammPfad.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_ProgrammPfad.TabIndex = 4
        Me.Cmd_ProgrammPfad.UseVisualStyleBackColor = True
        '
        'Cmd_UploadPfad
        '
        Me.Cmd_UploadPfad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmd_UploadPfad.Location = New System.Drawing.Point(505, 43)
        Me.Cmd_UploadPfad.Name = "Cmd_UploadPfad"
        Me.Cmd_UploadPfad.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_UploadPfad.TabIndex = 5
        Me.Cmd_UploadPfad.UseVisualStyleBackColor = True
        '
        'Cmd_Speichern
        '
        Me.Cmd_Speichern.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Cmd_Speichern.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Speichern.Location = New System.Drawing.Point(103, 75)
        Me.Cmd_Speichern.Name = "Cmd_Speichern"
        Me.Cmd_Speichern.Size = New System.Drawing.Size(160, 29)
        Me.Cmd_Speichern.TabIndex = 6
        Me.Cmd_Speichern.Text = "&Speichern"
        Me.Cmd_Speichern.UseVisualStyleBackColor = True
        '
        'Cmd_Abbruch
        '
        Me.Cmd_Abbruch.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Cmd_Abbruch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Abbruch.Location = New System.Drawing.Point(269, 75)
        Me.Cmd_Abbruch.Name = "Cmd_Abbruch"
        Me.Cmd_Abbruch.Size = New System.Drawing.Size(160, 29)
        Me.Cmd_Abbruch.TabIndex = 7
        Me.Cmd_Abbruch.Text = "S&chließen"
        Me.Cmd_Abbruch.UseVisualStyleBackColor = True
        '
        'PicSpeichernInfo
        '
        Me.PicSpeichernInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PicSpeichernInfo.Image = Global.UNB_Bildverwaltung.My.Resources.Resources.Fall_right
        Me.PicSpeichernInfo.Location = New System.Drawing.Point(76, 79)
        Me.PicSpeichernInfo.Name = "PicSpeichernInfo"
        Me.PicSpeichernInfo.Size = New System.Drawing.Size(26, 21)
        Me.PicSpeichernInfo.TabIndex = 8
        Me.PicSpeichernInfo.TabStop = False
        Me.PicSpeichernInfo.Visible = False
        '
        'Frm_Einstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(532, 110)
        Me.Controls.Add(Me.PicSpeichernInfo)
        Me.Controls.Add(Me.Cmd_Abbruch)
        Me.Controls.Add(Me.Cmd_Speichern)
        Me.Controls.Add(Me.Cmd_UploadPfad)
        Me.Controls.Add(Me.Cmd_ProgrammPfad)
        Me.Controls.Add(Me.Txt_UploadPfad)
        Me.Controls.Add(Me.Txt_ProgrammPfad)
        Me.Controls.Add(Me.Lbl_UploadPfad)
        Me.Controls.Add(Me.Lbl_Programmpfad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Einstellungen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Einstellungen"
        CType(Me.PicSpeichernInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Programmpfad As Label
    Friend WithEvents Lbl_UploadPfad As Label
    Friend WithEvents Txt_ProgrammPfad As TextBox
    Friend WithEvents Txt_UploadPfad As TextBox
    Friend WithEvents Cmd_ProgrammPfad As Button
    Friend WithEvents Cmd_UploadPfad As Button
    Friend WithEvents Cmd_Speichern As Button
    Friend WithEvents Cmd_Abbruch As Button
    Friend WithEvents PicSpeichernInfo As PictureBox
End Class
