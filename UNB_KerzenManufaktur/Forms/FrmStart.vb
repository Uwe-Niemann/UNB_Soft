Imports System.ComponentModel
Imports Allgemeine_Klassen

Public Class FrmStart
#Region "Enumerationen"
    Private Enum enmHandler
        Add = 0
        Remove = 1
    End Enum
    Private Enum enmhWnd As Long
        <Description("Kerzenverkauf")> KerzenVerkauf = 1
        <Description("Adressen")> Adressen = 1100
        <Description("Ansprechpartner")> AP = 1200
        <Description("Aufträge")> Auftrag = 1300
        <Description("Materialien")> Materialien = 1400
        <Description("Einkauf")> Einkauf = 1500
        '
        <Description("Einstellungen")> Einstellungen = 9
        <Description("Einheiten")> Einheiten = 9100
    End Enum
#End Region
#Region "Deklarationen"
    Private _AktivNode As TreeNode = Nothing
    Private _ht_hWnd_Forms As Hashtable = Nothing
#End Region
#Region "Form-Events"
    Private Sub FrmStart_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub FrmStart_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _ht_hWnd_Forms IsNot Nothing Then _ht_hWnd_Forms.Clear()
    End Sub

    Private Sub FrmStart_Load(sender As Object, e As EventArgs) Handles Me.Load
        Show_Anmeldung()
    End Sub

    Private Sub FrmStart_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Handler(enmHandler.Add)
    End Sub

    Private Sub Show_Anmeldung()
        Dim oAnmeldung As Form_Anmeldung = Nothing
        Try
            oAnmeldung = New Form_Anmeldung
            AddHandler oAnmeldung.event_SendMessage, AddressOf event_Anmeldung_Abgeschlossen
            oAnmeldung.Show(Me)
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        End Try
    End Sub

    Private Sub event_Anmeldung_Abgeschlossen(sender As Object, e As Allgemeine_Klassen.UNB_EventArgs)
        If e.UserObject IsNot Nothing Then
            Menü_Aufbauen()
        Else
            End
        End If
    End Sub
#End Region

#Region "Menü"
    Private Sub Menü_Aufbauen()
        Dim NodeKerze As TreeNode = Nothing
        Try
            _ht_hWnd_Forms = New Hashtable
            '
            NodeKerze = TV_Kerzen.Nodes.Add(FNC.GetEnumValue(enmhWnd.KerzenVerkauf), FNC.GetEnumDescription(enmhWnd.KerzenVerkauf))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.Adressen), FNC.GetEnumDescription(enmhWnd.Adressen))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.AP), FNC.GetEnumDescription(enmhWnd.AP))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.Auftrag), FNC.GetEnumDescription(enmhWnd.Auftrag))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.Materialien), FNC.GetEnumDescription(enmhWnd.Materialien))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.Einkauf), FNC.GetEnumDescription(enmhWnd.Einkauf))
            NodeKerze.ExpandAll()
            '
            NodeKerze = TV_Kerzen.Nodes.Add(FNC.GetEnumValue(enmhWnd.Einstellungen), FNC.GetEnumDescription(enmhWnd.Einstellungen))
            NodeKerze.Nodes.Add(FNC.GetEnumValue(enmhWnd.Einheiten), FNC.GetEnumDescription(enmhWnd.Einheiten))
            NodeKerze.Collapse()


            SplitContainer.SplitterDistance = 160
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(Me, ""))
        End Try
    End Sub
#End Region

#Region "Form-Verwaltung"
    Private Sub Zeige_Adressen(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Form = New FrmAdressen
            Param_Baum.Art = enmhWnd.Adressen
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub
    Private Sub Zeige_Ansprechpartner(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Art = enmhWnd.AP
            Param_Baum.Form = New FrmAnsprechpartner With {.Text = FNC.GetEnumDescription(Param_Baum.Art)}
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub
    Private Sub Zeige_Aufträge(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Form = New FrmAuftrag
            Param_Baum.Art = enmhWnd.Auftrag
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub
    Private Sub Zeige_Materialien(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Form = New FrmMaterialien
            Param_Baum.Art = enmhWnd.Materialien
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub
    Private Sub Zeige_Einkauf(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Form = New FrmEinkauf
            Param_Baum.Art = enmhWnd.Einkauf
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub
    '
    Private Sub Zeige_Einstellungen(ItemNode As TreeNode)
        Dim Param_Baum As Parameter_Baum = Nothing
        Param_Baum = ItemGeladen(ItemNode)
        If Param_Baum Is Nothing Then
            Param_Baum = New Parameter_Baum
            Param_Baum.Form = New FrmEinheiten
            Param_Baum.Art = enmhWnd.Einheiten
            _ht_hWnd_Forms.Add(Param_Baum.Handle, Param_Baum)
        End If
        '
        Zeige_Form(Param_Baum)
    End Sub

    Private Function Zeige_Form(ByVal Para_Amt As Parameter_Baum) As Boolean
        Dim rtBool As Boolean = False
        Try
            For Each element As Object In SplitContainer.Panel2.Controls
                If TypeOf element Is Form Then
                    If DirectCast(element, Form).Handle = Para_Amt.Handle Then
                        element.Visible = True
                        element.Aktualisieren()
                        DirectCast(element, Form).Dock = DockStyle.Fill
                        element.BringToFront()
                        rtBool = True
                    Else
                        DirectCast(element, Form).Dock = DockStyle.None
                        DirectCast(element, Form).Left = -20000
                    End If
                End If
            Next
            If rtBool Then Return True
            Dim Frm As Form = Para_Amt.Form
            Frm.MdiParent = Me
            SplitContainer.Panel2.Controls.Add(Frm)
            Frm.Show()
            Frm.Dock = DockStyle.Fill
            Frm.BringToFront()
            Return True
        Catch ex As Exception
            Throw
        Finally
        End Try
    End Function

    Private Function ItemGeladen(ItemNode As TreeNode) As Parameter_Baum
        Dim rtParam As Parameter_Baum = Nothing
        Dim ParamKey As IntPtr = IntPtr.Zero
        Dim DSID_Amt As Integer = -1
        Try
            For Each DE As DictionaryEntry In _ht_hWnd_Forms
                If FNC.GetEnumValue(DirectCast(DE.Value, Parameter_Baum).Art) = ItemNode.Name Then
                    rtParam = DirectCast(DE.Value, Parameter_Baum)
                    ParamKey = DE.Key ' Wird ggf. unten benötigt wenn die Form bereits entladen wurde
                    Exit For
                End If
            Next DE
            If rtParam IsNot Nothing Then ' Wenn die Form in der Zwischenzeit geschlossen wurde muss sie an dieser Stelle aus der Collection entfernt werden um neu gegründet werden zu können - Sonst LFZ
                If rtParam.Form IsNot Nothing AndAlso DirectCast(rtParam.Form, System.Windows.Forms.Form).IsDisposed Then
                    _ht_hWnd_Forms.Remove(ParamKey)
                    rtParam = Nothing
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
        '
        Return rtParam
    End Function
#End Region

#Region "Events"
    Private Sub event_TV_Kerzen_AfterSelect(sender As Object, e As TreeViewEventArgs)
        Try

            If _AktivNode IsNot Nothing AndAlso Not _AktivNode.Equals(e.Node) Then
                Dim e1 As New Allgemeine_Klassen.UNB_CheckEdit_EventArgs("Programmwechsel")
                If Not Check_ObDatenBearbeitetWurden(e1) Then
                    If e1.Cancel Then Exit Sub ' Wenn der Benutzer Abbrechen gedrückt hat muss die Methode verlassen werden
                End If
            End If
            If _AktivNode IsNot Nothing Then
                _AktivNode.BackColor = Color.White
            End If
            TV_Kerzen.SelectedNode = Nothing ' Damit die Markierung verschwindet
            '
            _AktivNode = e.Node : _AktivNode.BackColor = Color.YellowGreen
            Select Case FNC.FF(e.Node.Name, FNC.enmFNC.FFLong)
                Case enmhWnd.Adressen : Zeige_Adressen(e.Node)
                Case enmhWnd.AP : Zeige_Ansprechpartner(e.Node)
                Case enmhWnd.Auftrag : Zeige_Aufträge(e.Node)
                Case enmhWnd.Materialien : Zeige_Materialien(e.Node)
                Case enmhWnd.Einkauf : Zeige_Einkauf(e.Node)
                Case enmhWnd.Einheiten : Zeige_Einstellungen(e.Node)
                    '
                Case Else : Container_Leeren()
            End Select
        Catch ex As Exception
            UNB_Err.ShowError(ex, getErrorInfo(sender, ""))
        End Try
    End Sub

    Private Sub Container_Leeren()
        Try
            For Each DE As DictionaryEntry In _ht_hWnd_Forms
                DirectCast(DE.Value.Form, System.Windows.Forms.Form).Visible = False
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
#Region "Allgemeine Property, Methoden und Funktionen"
    Private Function Check_ObDatenBearbeitetWurden(ByVal Caption As String) As Boolean
        Return Check_ObDatenBearbeitetWurden(New Allgemeine_Klassen.UNB_CheckEdit_EventArgs With {.Caption = Caption})
    End Function
    Public Function Check_ObDatenBearbeitetWurden(ByVal e As Allgemeine_Klassen.UNB_CheckEdit_EventArgs) As Boolean
        Return True ' Hier kann eine Auswertung stattfinden ob Daten geändert aber noch nicht gespeichert wurden
    End Function

    Private Sub Handler(Aktion As enmHandler)
        RemoveHandler TV_Kerzen.AfterSelect, AddressOf event_TV_Kerzen_AfterSelect
        If Aktion = enmHandler.Add Then
            AddHandler TV_Kerzen.AfterSelect, AddressOf event_TV_Kerzen_AfterSelect
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

    Private Class Parameter_Baum : Implements IDisposable
        Private _enmArt As enmhWnd = -1
        Private _oFrm As System.Object = Nothing
        Public Property Art As enmhWnd
            Get
                Return _enmArt
            End Get
            Set(value As enmhWnd)
                _enmArt = value
            End Set
        End Property
        Public Property Form As System.Object
            Get
                Return _oFrm
            End Get
            Set(value As System.Object)
                _oFrm = value
            End Set
        End Property
        Public ReadOnly Property Handle As IntPtr
            Get
                If _oFrm IsNot Nothing Then
                    Return DirectCast(_oFrm, System.Windows.Forms.Form).Handle
                Else
                    Return IntPtr.Zero
                End If
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Dient zur Erkennung redundanter Aufrufe.

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    _enmArt = -1
                    If _oFrm IsNot Nothing Then
                        _oFrm.Dispose
                    End If
                    _oFrm = Nothing
                End If

                ' TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalize() weiter unten überschreiben.
                ' TODO: große Felder auf Null setzen.
            End If
            disposedValue = True
        End Sub

        ' TODO: Finalize() nur überschreiben, wenn Dispose(disposing As Boolean) weiter oben Code zur Bereinigung nicht verwalteter Ressourcen enthält.
        'Protected Overrides Sub Finalize()
        '    ' Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.
            Dispose(True)
            ' TODO: Auskommentierung der folgenden Zeile aufheben, wenn Finalize() oben überschrieben wird.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Class