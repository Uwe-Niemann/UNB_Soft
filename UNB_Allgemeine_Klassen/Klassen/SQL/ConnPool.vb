Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class ConnPool
#Region "Muss angepaßt werden"
    Public Enum DB_Collection
        <Description("FKM")> FKM = 0
    End Enum
#End Region
#Region "Dieser Teil ist allgemeingültig"
    Public Sub New()
        If Not DB_Was_Opened Then Set_Connection_Strings()
    End Sub
    Public ReadOnly Property DBConnection(ByVal dbn As DB_Collection) As SqlConnection
        Get
            DB_Open(dbn)
            Return Datenbank_Connect(dbn)
        End Get
    End Property
    Public ReadOnly Property DBConnectionString(ByVal dbn As DB_Collection) As String
        Get
            DB_Open(dbn)
            Return Connect_Strings(dbn)
        End Get
    End Property

    Public ReadOnly Property DBName(ByVal dbn As DB_Collection) As String
        Get
            Try
                Return Datenbank_Connect(dbn).Database
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Private Sub DB_Open(ByVal Datenbank As DB_Collection)
        If Datenbank_Connect(Datenbank).State = Data.ConnectionState.Closed Then Datenbank_Connect(Datenbank).Open()
    End Sub
#End Region
End Class