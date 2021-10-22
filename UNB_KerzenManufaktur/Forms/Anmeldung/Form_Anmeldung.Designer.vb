<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Anmeldung
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
        Me.Lbl_AnmeldeName = New System.Windows.Forms.Label()
        Me.Lbl_Passwort = New System.Windows.Forms.Label()
        Me.TabCtrl_Anmeldung = New System.Windows.Forms.TabControl()
        Me.TP_Anmelden = New System.Windows.Forms.TabPage()
        Me.Txt_Passwort = New System.Windows.Forms.TextBox()
        Me.Txt_AnmeldeName = New System.Windows.Forms.TextBox()
        Me.TP_NeuesPasswort = New System.Windows.Forms.TabPage()
        Me.Txt_NeuesPW2 = New System.Windows.Forms.TextBox()
        Me.Lbl_NeuesPW_Wiederholen = New System.Windows.Forms.Label()
        Me.Txt_NeuesPW = New System.Windows.Forms.TextBox()
        Me.Lbl_NeuesPW = New System.Windows.Forms.Label()
        Me.Txt_AktuellesPW = New System.Windows.Forms.TextBox()
        Me.TxtAnmeldung2 = New System.Windows.Forms.TextBox()
        Me.Lbl_AktuellesPW = New System.Windows.Forms.Label()
        Me.Lbl_Anmeldung2 = New System.Windows.Forms.Label()
        Me.PButton = New System.Windows.Forms.Panel()
        Me.Btn_Abbruch = New System.Windows.Forms.Button()
        Me.Btn_Anmelden = New System.Windows.Forms.Button()
        Me.TabCtrl_Anmeldung.SuspendLayout()
        Me.TP_Anmelden.SuspendLayout()
        Me.TP_NeuesPasswort.SuspendLayout()
        Me.PButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_AnmeldeName
        '
        Me.Lbl_AnmeldeName.AutoSize = True
        Me.Lbl_AnmeldeName.Location = New System.Drawing.Point(8, 32)
        Me.Lbl_AnmeldeName.Name = "Lbl_AnmeldeName"
        Me.Lbl_AnmeldeName.Size = New System.Drawing.Size(77, 13)
        Me.Lbl_AnmeldeName.TabIndex = 0
        Me.Lbl_AnmeldeName.Text = "Anmeldename:"
        '
        'Lbl_Passwort
        '
        Me.Lbl_Passwort.AutoSize = True
        Me.Lbl_Passwort.Location = New System.Drawing.Point(8, 58)
        Me.Lbl_Passwort.Name = "Lbl_Passwort"
        Me.Lbl_Passwort.Size = New System.Drawing.Size(53, 13)
        Me.Lbl_Passwort.TabIndex = 2
        Me.Lbl_Passwort.Text = "Passwort:"
        '
        'TabCtrl_Anmeldung
        '
        Me.TabCtrl_Anmeldung.Controls.Add(Me.TP_Anmelden)
        Me.TabCtrl_Anmeldung.Controls.Add(Me.TP_NeuesPasswort)
        Me.TabCtrl_Anmeldung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCtrl_Anmeldung.Location = New System.Drawing.Point(0, 0)
        Me.TabCtrl_Anmeldung.Name = "TabCtrl_Anmeldung"
        Me.TabCtrl_Anmeldung.SelectedIndex = 0
        Me.TabCtrl_Anmeldung.Size = New System.Drawing.Size(287, 136)
        Me.TabCtrl_Anmeldung.TabIndex = 0
        '
        'TP_Anmelden
        '
        Me.TP_Anmelden.Controls.Add(Me.Txt_Passwort)
        Me.TP_Anmelden.Controls.Add(Me.Txt_AnmeldeName)
        Me.TP_Anmelden.Controls.Add(Me.Lbl_Passwort)
        Me.TP_Anmelden.Controls.Add(Me.Lbl_AnmeldeName)
        Me.TP_Anmelden.Location = New System.Drawing.Point(4, 22)
        Me.TP_Anmelden.Name = "TP_Anmelden"
        Me.TP_Anmelden.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Anmelden.Size = New System.Drawing.Size(279, 110)
        Me.TP_Anmelden.TabIndex = 0
        Me.TP_Anmelden.Text = "Anmelden"
        Me.TP_Anmelden.UseVisualStyleBackColor = True
        '
        'Txt_Passwort
        '
        Me.Txt_Passwort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Passwort.Location = New System.Drawing.Point(85, 55)
        Me.Txt_Passwort.MaxLength = 250
        Me.Txt_Passwort.Name = "Txt_Passwort"
        Me.Txt_Passwort.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt_Passwort.Size = New System.Drawing.Size(186, 20)
        Me.Txt_Passwort.TabIndex = 3
        '
        'Txt_AnmeldeName
        '
        Me.Txt_AnmeldeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_AnmeldeName.Location = New System.Drawing.Point(85, 29)
        Me.Txt_AnmeldeName.MaxLength = 250
        Me.Txt_AnmeldeName.Name = "Txt_AnmeldeName"
        Me.Txt_AnmeldeName.Size = New System.Drawing.Size(186, 20)
        Me.Txt_AnmeldeName.TabIndex = 1
        '
        'TP_NeuesPasswort
        '
        Me.TP_NeuesPasswort.Controls.Add(Me.Txt_NeuesPW2)
        Me.TP_NeuesPasswort.Controls.Add(Me.Lbl_NeuesPW_Wiederholen)
        Me.TP_NeuesPasswort.Controls.Add(Me.Txt_NeuesPW)
        Me.TP_NeuesPasswort.Controls.Add(Me.Lbl_NeuesPW)
        Me.TP_NeuesPasswort.Controls.Add(Me.Txt_AktuellesPW)
        Me.TP_NeuesPasswort.Controls.Add(Me.TxtAnmeldung2)
        Me.TP_NeuesPasswort.Controls.Add(Me.Lbl_AktuellesPW)
        Me.TP_NeuesPasswort.Controls.Add(Me.Lbl_Anmeldung2)
        Me.TP_NeuesPasswort.Location = New System.Drawing.Point(4, 22)
        Me.TP_NeuesPasswort.Name = "TP_NeuesPasswort"
        Me.TP_NeuesPasswort.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_NeuesPasswort.Size = New System.Drawing.Size(279, 110)
        Me.TP_NeuesPasswort.TabIndex = 1
        Me.TP_NeuesPasswort.Text = "Passwort ändern"
        Me.TP_NeuesPasswort.UseVisualStyleBackColor = True
        '
        'Txt_NeuesPW2
        '
        Me.Txt_NeuesPW2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_NeuesPW2.Location = New System.Drawing.Point(127, 84)
        Me.Txt_NeuesPW2.MaxLength = 250
        Me.Txt_NeuesPW2.Name = "Txt_NeuesPW2"
        Me.Txt_NeuesPW2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt_NeuesPW2.Size = New System.Drawing.Size(147, 20)
        Me.Txt_NeuesPW2.TabIndex = 7
        '
        'Lbl_NeuesPW_Wiederholen
        '
        Me.Lbl_NeuesPW_Wiederholen.AutoSize = True
        Me.Lbl_NeuesPW_Wiederholen.Location = New System.Drawing.Point(8, 87)
        Me.Lbl_NeuesPW_Wiederholen.Name = "Lbl_NeuesPW_Wiederholen"
        Me.Lbl_NeuesPW_Wiederholen.Size = New System.Drawing.Size(113, 13)
        Me.Lbl_NeuesPW_Wiederholen.TabIndex = 6
        Me.Lbl_NeuesPW_Wiederholen.Text = "Passwort wiederholen:"
        '
        'Txt_NeuesPW
        '
        Me.Txt_NeuesPW.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_NeuesPW.Location = New System.Drawing.Point(127, 58)
        Me.Txt_NeuesPW.MaxLength = 250
        Me.Txt_NeuesPW.Name = "Txt_NeuesPW"
        Me.Txt_NeuesPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt_NeuesPW.Size = New System.Drawing.Size(147, 20)
        Me.Txt_NeuesPW.TabIndex = 5
        '
        'Lbl_NeuesPW
        '
        Me.Lbl_NeuesPW.AutoSize = True
        Me.Lbl_NeuesPW.Location = New System.Drawing.Point(8, 61)
        Me.Lbl_NeuesPW.Name = "Lbl_NeuesPW"
        Me.Lbl_NeuesPW.Size = New System.Drawing.Size(87, 13)
        Me.Lbl_NeuesPW.TabIndex = 4
        Me.Lbl_NeuesPW.Text = "Neues Passwort:"
        '
        'Txt_AktuellesPW
        '
        Me.Txt_AktuellesPW.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_AktuellesPW.Location = New System.Drawing.Point(127, 32)
        Me.Txt_AktuellesPW.MaxLength = 250
        Me.Txt_AktuellesPW.Name = "Txt_AktuellesPW"
        Me.Txt_AktuellesPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt_AktuellesPW.Size = New System.Drawing.Size(147, 20)
        Me.Txt_AktuellesPW.TabIndex = 3
        '
        'TxtAnmeldung2
        '
        Me.TxtAnmeldung2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAnmeldung2.Location = New System.Drawing.Point(127, 6)
        Me.TxtAnmeldung2.MaxLength = 250
        Me.TxtAnmeldung2.Name = "TxtAnmeldung2"
        Me.TxtAnmeldung2.Size = New System.Drawing.Size(147, 20)
        Me.TxtAnmeldung2.TabIndex = 1
        '
        'Lbl_AktuellesPW
        '
        Me.Lbl_AktuellesPW.AutoSize = True
        Me.Lbl_AktuellesPW.Location = New System.Drawing.Point(8, 35)
        Me.Lbl_AktuellesPW.Name = "Lbl_AktuellesPW"
        Me.Lbl_AktuellesPW.Size = New System.Drawing.Size(99, 13)
        Me.Lbl_AktuellesPW.TabIndex = 2
        Me.Lbl_AktuellesPW.Text = "Aktuelles Passwort:"
        '
        'Lbl_Anmeldung2
        '
        Me.Lbl_Anmeldung2.AutoSize = True
        Me.Lbl_Anmeldung2.Location = New System.Drawing.Point(8, 14)
        Me.Lbl_Anmeldung2.Name = "Lbl_Anmeldung2"
        Me.Lbl_Anmeldung2.Size = New System.Drawing.Size(77, 13)
        Me.Lbl_Anmeldung2.TabIndex = 0
        Me.Lbl_Anmeldung2.Text = "Anmeldename:"
        '
        'PButton
        '
        Me.PButton.Controls.Add(Me.Btn_Abbruch)
        Me.PButton.Controls.Add(Me.Btn_Anmelden)
        Me.PButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PButton.Location = New System.Drawing.Point(0, 136)
        Me.PButton.Name = "PButton"
        Me.PButton.Size = New System.Drawing.Size(287, 37)
        Me.PButton.TabIndex = 1
        '
        'Btn_Abbruch
        '
        Me.Btn_Abbruch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_Abbruch.Location = New System.Drawing.Point(146, 5)
        Me.Btn_Abbruch.Name = "Btn_Abbruch"
        Me.Btn_Abbruch.Size = New System.Drawing.Size(98, 28)
        Me.Btn_Abbruch.TabIndex = 1
        Me.Btn_Abbruch.Text = "Abbre&chen"
        Me.Btn_Abbruch.UseVisualStyleBackColor = True
        '
        'Btn_Anmelden
        '
        Me.Btn_Anmelden.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Btn_Anmelden.Location = New System.Drawing.Point(42, 5)
        Me.Btn_Anmelden.Name = "Btn_Anmelden"
        Me.Btn_Anmelden.Size = New System.Drawing.Size(98, 28)
        Me.Btn_Anmelden.TabIndex = 0
        Me.Btn_Anmelden.Text = "&Anmelden"
        Me.Btn_Anmelden.UseVisualStyleBackColor = True
        '
        'Form_Anmeldung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(287, 173)
        Me.Controls.Add(Me.TabCtrl_Anmeldung)
        Me.Controls.Add(Me.PButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Anmeldung"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anmelden"
        Me.TabCtrl_Anmeldung.ResumeLayout(False)
        Me.TP_Anmelden.ResumeLayout(False)
        Me.TP_Anmelden.PerformLayout()
        Me.TP_NeuesPasswort.ResumeLayout(False)
        Me.TP_NeuesPasswort.PerformLayout()
        Me.PButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lbl_AnmeldeName As Label
    Friend WithEvents Lbl_Passwort As Label
    Friend WithEvents TabCtrl_Anmeldung As TabControl
    Friend WithEvents TP_Anmelden As TabPage
    Friend WithEvents Txt_Passwort As TextBox
    Friend WithEvents Txt_AnmeldeName As TextBox
    Friend WithEvents TP_NeuesPasswort As TabPage
    Friend WithEvents PButton As Panel
    Friend WithEvents Btn_Abbruch As Button
    Friend WithEvents Btn_Anmelden As Button
    Friend WithEvents Txt_NeuesPW2 As TextBox
    Friend WithEvents Lbl_NeuesPW_Wiederholen As Label
    Friend WithEvents Txt_NeuesPW As TextBox
    Friend WithEvents Lbl_NeuesPW As Label
    Friend WithEvents Txt_AktuellesPW As TextBox
    Friend WithEvents TxtAnmeldung2 As TextBox
    Friend WithEvents Lbl_AktuellesPW As Label
    Friend WithEvents Lbl_Anmeldung2 As Label
End Class
