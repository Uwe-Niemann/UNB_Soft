<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStart
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
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TV_Kerzen = New System.Windows.Forms.TreeView()
        Me.PControls = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer
        '
        Me.SplitContainer.BackColor = System.Drawing.Color.Black
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Panel1.Controls.Add(Me.TV_Kerzen)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Panel2.Controls.Add(Me.PControls)
        Me.SplitContainer.Size = New System.Drawing.Size(824, 461)
        Me.SplitContainer.SplitterDistance = 99
        Me.SplitContainer.TabIndex = 0
        '
        'TV_Kerzen
        '
        Me.TV_Kerzen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Kerzen.Location = New System.Drawing.Point(0, 0)
        Me.TV_Kerzen.Name = "TV_Kerzen"
        Me.TV_Kerzen.Size = New System.Drawing.Size(99, 461)
        Me.TV_Kerzen.TabIndex = 0
        '
        'PControls
        '
        Me.PControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PControls.Location = New System.Drawing.Point(0, 0)
        Me.PControls.Name = "PControls"
        Me.PControls.Size = New System.Drawing.Size(721, 461)
        Me.PControls.TabIndex = 0
        '
        'FrmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 461)
        Me.Controls.Add(Me.SplitContainer)
        Me.IsMdiContainer = True
        Me.Name = "FrmStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kerzen-Verkauf"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents TV_Kerzen As TreeView
    Friend WithEvents PControls As Panel
End Class
