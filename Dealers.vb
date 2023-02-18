Imports cglobals = Globals.cGlobals
Imports System.Data.SQLite
Imports Globals.cGlobals

Public Class Dealer
    Public Shared DealerID As Long
    Public Shared DealerName As String
    Public Shared StreetAddress As String
    Public Shared MondayHours As String
    Public Shared TuesdayHours As String
    Public Shared WednesdayHours As String
    Public Shared ThursdayHours As String
    Public Shared FridayHours As String
    Public Shared SaturdayHours As String
    Public Shared SundayHours As String
    Public Shared PhoneNumber As String
    Public Shared MapLocation As String
    Public Shared ActiveRecord As Boolean

    'Public Shared Function GetDealerData(intDealerID As Integer) As DataTable
    '    Return GetDealerData
    'End Function

    Public Shared Sub SaveDealerData()

    End Sub

    Public Function ListDealers(Optional ByRef IsActive As ActiveStatus = ActiveStatus.Active, Optional BrandID As Integer = -1) As DataTable
        Dim dtDealerList As New DataTable
        Dim mSQL As String

        If IsActive = ActiveStatus.Active Then
            ' mSQL = "SELECT tblSubModels.*, (ModelYear || \" \ " || Driveline) AS SubmodelName From tblSubModels WHERE IsActive = '" & vbTrue & "'"

            '          Select
            'CustomerId,
            'FirstName || ' ' || LastName AS "Full Name"
            '              From Customer
            'Limit 5

            mSQL = "SELECT * FROM DealerList WHERE IsActive = '" & vbTrue & "'"
        Else
            mSQL = "SELECT * FROM DealerList"
        End If

        If BrandID <> -1 Then
            mSQL += " And BrandID = '" & BrandID & "'"
        End If

        'Debug.Print(mSQL & " - " & IsActive)

        'Dim mSQL As String = "SELECT * FROM tblBanks"
        Dim connectionString As String = cglobals.gConnection.gConnectionString
        'Debug.Print(connectionString)
        Try
            Using conn As New SQLiteConnection(connectionString)
                Using cmd As New SQLiteCommand(mSQL, conn)
                    conn.Open()
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dtDealerList)
                    End Using
                    conn.Close()
                End Using
            End Using
        Catch ex As Exception
        End Try

        Return dtDealerList
    End Function

End Class