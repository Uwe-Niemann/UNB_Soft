Class Config

    Friend Shared Sub LeseConfigData(ByRef htEintraege As Hashtable)
        htEintraege = New Hashtable
        Dim arZeilen(0) As String
        arZeilen(0) = "5ZX~Sbsb 9frqilNQ_BIQW3IQL3IBBAHRD[9F7=Hylq ?SN444Q[HRD[5ZX=PMSN5%BQ[HRD[5ZX[buQB!=?dmsmbx <bsbxfpN444Q-HRD-5ZX=7bdprbplNplq\bd"

        ' Hashtable '_htEintraege' füllen.
        Dim arrSplits() As String = {}
        For i As Integer = 0 To arZeilen.Length - 1
            Dim Zeile As String = FNC.String_DeCode(arZeilen(i))
            If Zeile.Contains("~") Then
                arrSplits = Split(Zeile, "~")
                If arrSplits(0).Length > 0 Then
                    If Not htEintraege.ContainsKey(arrSplits(0)) Then htEintraege.Add(arrSplits(0), arrSplits(1))
                End If
            End If
        Next
    End Sub
End Class