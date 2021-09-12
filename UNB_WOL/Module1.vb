Imports System.Net
Imports System.Net.Sockets

Module Module1
    Sub Main()
        If System.Environment.GetCommandLineArgs().Length > 1 Then
            Dim args() As String = {}
            Try
                args = Split(System.Environment.CommandLine, "/")
                If args.Length > 1 Then
                    WakeUp(args(1))
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Wake on lan")
            Finally
                Array.Resize(Of String)(args, 0)
            End Try
        End If
    End Sub

    Private Const MAC_ADDR_BYTES As Integer = 6
    Private Const PORT_BROADCAST = 2304
    ' <remarks>
    ' Constructs and returns a magic packet for the given 
    ' MAC address.
    ' A Magic Packet is 6 bytes of FF followed by the MAC 
    ' address 16 times.
    ' </remarks>
    Private Function GetMagicPacket(ByVal macAddress As String) As Byte()
        Dim Packet As Byte() = New Byte(5 + 16 * MAC_ADDR_BYTES) {} '101 => 102 Elements
        Dim strNumbers As String() = macAddress.Split(New Char() {":", ",", ";", "-"})
        Dim macBytes As Byte() = New Byte(5) {}
        If strNumbers.Length <> 6 Then
            Throw New Exception("MAC Address incorrect!!!")
        End If
        'Convert Numbers to Bytes and set the first 6 FF Values
        For i As Integer = 0 To 5
            Packet(i) = &HFF
            Dim strNumber As String = strNumbers(i)
            'Strip possible leading 0x statments
            If strNumber.StartsWith("0x") Then
                strNumber = strNumber.Substring(2, 2)
            End If
            macBytes(i) = CByte(Int32.Parse(strNumber, System.Globalization.NumberStyles.HexNumber))
        Next i
        'Write the MAC address 16 times after the 6 FF values
        For j As Integer = 0 To 15
            For i As Integer = 0 To 5
                Packet(6 + j * 6 + i) = macBytes(i)
            Next i
        Next j
        Return Packet
    End Function

    '<remarks>
    'Sends the magic packet for a specific MAC address
    '</remarks>
    Private Sub WakeUp(ByVal macAddress As String)
        Dim s As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1)
        Dim Message As Byte() = GetMagicPacket(macAddress)
        Dim IPEP As New IPEndPoint(IPAddress.Broadcast, PORT_BROADCAST)
        '
        s.SendTo(Message, IPEP)
    End Sub
End Module
