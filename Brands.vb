'Imports cglobals = Globals.cGlobals
Imports System.Data.SQLite
Imports Globals.cGlobals
Imports System.Windows.Forms

Public Class Brand
    'Public Shared BrandID As Long
    'Public Shared BrandName As String
    'Public Shared StreetAddress As String
    'Public Shared MondayHours As String
    'Public Shared TuesdayHours As String
    'Public Shared WednesdayHours As String
    'Public Shared ThursdayHours As String
    'Public Shared FridayHours As String
    'Public Shared SaturdayHours As String
    'Public Shared SundayHours As String
    'Public Shared PhoneNumber As String
    'Public Shared MapLocation As String
    'Public Shared ActiveRecord As Boolean

    'Public Shared Function GetBrandData(intBrandID As Integer) As DataTable
    '    Return GetBrandData
    'End Function

    Public Sub SaveBrandData(BrandData As DataTable)
        'check if existing Brand by this name
        'if not, insert records
        'else, update records

        'Dim myTrans As SQLiteTransaction
        'Dim sqlite_conn As SQLiteConnection
        'Dim sqlite_cmd As SQLiteCommand
        ' create a new database connection:
        'Using sqlite_conn = New SQLiteConnection(gConnectionString)

        'Dim strInput As String
        'Dim intCount As Integer
        'Dim ConnectionString As String = String.Empty
        'ConnectionString = String.Empty
        Dim rc As Integer
        rc = BrandData.Rows.Count
        Debug.Print("Brand row count is " & rc)
        Debug.Print("Brand ID is ")
        Debug.Print(BrandData.Rows(0).Item("BrandID").ToString)

        If IsNothing(BrandData.Rows(0).Item("BrandID")) Or BrandData.Rows(0).Item("BrandID").ToString = "" Or BrandData.Rows(0).Item("BrandID").ToString = "0" Then 'Or BrandData.Columns("BrandID") = 0 Then
            ''no previous record, insert new one
            'ConnectionString = "INSERT INTO VehicleBrands(BrandName,IsActive) VALUES ('" & Trim(strInput) & "', '-1')"
            'ConnectionString = "INSERT INTO BrandList(Name,StreetAddress,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours," &
            '    "FridayHours,SaturdayHours,SundayHours,PhoneNumber,MapLocation,IsActive) " &
            '    "VALUES('" & Trim(Me.TxtBrandName.Text) & "','" & Trim(Me.TxtBrandName.Text)
            'Me.TxtAddress.Text
            'Me.TxtMonday.Text
            'Me.TxtTuesday.Text
            'Me.TxtWednesday.Text
            'Me.TxtThursday.Text
            'Me.TxtFriday.Text
            'Me.TxtSaturday.Text
            'Me.TxtSunday.Text
            'Me.TxtPhoneNumber.Text
            'Me.TxtMapLink.Text
            'Me.ChkIsActive.CheckState

            'searchedValue = MyDataTable1.Rows("value3").Item("ColumnName2").ToString 

            Using sqlite_conn = New SQLiteConnection(Globals.cGlobals.gConnection.gConnectionString)
                Using cmd As New SQLiteCommand("INSERT INTO BrandList(Name,StreetAddress,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours," &
                "SaturdayHours,SundayHours,PhoneNumber,MapLocation,IsActive) VALUES (@Name,@Address,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday," &
                "@Sunday,@PhoneNumber,@MapLink,(@IsActive * -1))", sqlite_conn)

                    cmd.Parameters.Add("@Name", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("BrandName").ToString)
                    cmd.Parameters.Add("@Address", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("Address").ToString)
                    cmd.Parameters.Add("@Monday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("MondayHours").ToString)
                    cmd.Parameters.Add("@Tuesday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("TuesdayHours").ToString)
                    cmd.Parameters.Add("@Wednesday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("WednesdayHours").ToString)
                    cmd.Parameters.Add("@Thursday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("ThursdayHours").ToString)
                    cmd.Parameters.Add("@Friday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("FridayHours").ToString)
                    cmd.Parameters.Add("@Saturday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("SaturdayHours").ToString)
                    cmd.Parameters.Add("@Sunday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("SundayHours").ToString)
                    cmd.Parameters.Add("@PhoneNumber", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("PhoneNumber").ToString)
                    cmd.Parameters.Add("@MapLink", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("MapLink").ToString)
                    cmd.Parameters.Add("@IsActive", DbType.Int64).Value = BrandData.Rows(0).Item("IsActive")
                    Debug.Print(cmd.CommandText)
                    sqlite_conn.Open()
                    cmd.ExecuteNonQuery()
                    sqlite_conn.Close()


                End Using
            End Using
        Else
            Using sqlite_conn = New SQLiteConnection(Globals.cGlobals.gConnection.gConnectionString)
                'Using cmd As New SQLiteCommand("UPDATE BrandList (BrandID,Name,StreetAddress,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours," &
                '"SaturdayHours,SundayHours,PhoneNumber,MapLocation,IsActive) VALUES (@BrandID,@Name,@Address,@Monday,@Tuesday,@Wednesday,@Thursday,@Friday,@Saturday," &
                '"@Sunday,@PhoneNumber,@MapLink,@IsActive) WHERE BrandID = '" & BrandData.Rows(0).Item("BrandID").ToString & "'", sqlite_conn)

                Using cmd As New SQLiteCommand("UPDATE BrandList SET Name = @BrandName, StreetAddress = @Address, 
                        MondayHours = @Monday, TuesdayHours = @Tuesday, WednesdayHours = @Wednesday, ThursdayHours = @Thursday, 
                        FridayHours = @Friday, SaturdayHours = @Saturday, SundayHours = @Sunday, PhoneNumber = @PhoneNumber, MapLocation = @MapLink, 
                        IsActive = (@IsActive * -1) WHERE BrandID = @BrandID", sqlite_conn)


                    cmd.Parameters.Add("@BrandID", DbType.Int64).Value = BrandData.Rows(0).Item("BrandID").ToString
                    cmd.Parameters.Add("@BrandName", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("BrandName").ToString)
                    cmd.Parameters.Add("@Address", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("Address").ToString)
                    cmd.Parameters.Add("@Monday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("MondayHours").ToString)
                    cmd.Parameters.Add("@Tuesday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("TuesdayHours").ToString)
                    cmd.Parameters.Add("@Wednesday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("WednesdayHours").ToString)
                    cmd.Parameters.Add("@Thursday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("ThursdayHours").ToString)
                    cmd.Parameters.Add("@Friday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("FridayHours").ToString)
                    cmd.Parameters.Add("@Saturday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("SaturdayHours").ToString)
                    cmd.Parameters.Add("@Sunday", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("SundayHours").ToString)
                    cmd.Parameters.Add("@PhoneNumber", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("PhoneNumber").ToString)
                    cmd.Parameters.Add("@MapLink", DbType.AnsiString).Value = Trim(BrandData.Rows(0).Item("MapLink").ToString)
                    cmd.Parameters.Add("@IsActive", DbType.Int64).Value = BrandData.Rows(0).Item("IsActive")
                    Debug.Print(cmd.CommandText)
                    sqlite_conn.Open()
                    cmd.ExecuteNonQuery()
                    sqlite_conn.Close()


                End Using
            End Using

        End If

        ' Dim myTrans As SQLiteTransaction
        'Dim sqlite_conn As SQLiteConnection
        'Dim sqlite_cmd As SQLiteCommand
        'Exit Sub
        '' create a new database connection:
        'Using sqlite_conn = New SQLiteConnection(Globals.cGlobals.gConnection.gConnectionString)

        '    ' open the connection:
        '    sqlite_conn.Open()
        '    myTrans = sqlite_conn.BeginTransaction
        '    Try
        '        'create the command

        '        sqlite_cmd = sqlite_conn.CreateCommand()
        '        sqlite_cmd.CommandText = ConnectionString
        '        sqlite_cmd.ExecuteNonQuery()
        '        Debug.Print("Record was sucessfully written to database.")
        '        myTrans.Commit()
        '        'Return True
        '    Catch ex As Exception
        '        'TODO :'IF NO RECORD EXISTS, IT'LL FAIL. ADD ROUTINE TO INSERT NEW RECORD INSTEAD
        '        myTrans.Rollback()
        '        Debug.Print(ex.ToString())
        '        Debug.Print("Neither record was written to database.")
        '        'Return False
        '    Finally
        '        'close connection, garbage cleanup
        '        sqlite_conn.Close()
        '        sqlite_conn.Dispose()
        '    End Try
        'End Using
        ''//////////////////////////////////







        'Try
        '    intBrandValue = CInt(LstBrands.SelectedValue)
        'Catch ex As Exception
        '    ' no Brand selected
        '    Exit Sub
        'End Try

        ''Dim t As Tuple(Of DataTable, DataTable) = GetBrandInfo(intBrandValue)
        'Dim dtMain As DataTable = GetBrandInfo(intBrandValue)
        ''Dim dtHours As DataTable = t.Item2
        'If dtMain.Rows.Count = 0 Then
        '    'no Brand? off
        '    Exit Sub
        'End If

        ''TextBox5.Text = table.Rows(0).Item(0)
        'Me.TxtBrandID.Text = dtMain.Rows(0).Item("BrandID")
        'Me.TxtBrandName.Text = dtMain.Rows(0).Item("Name")
        'Me.TxtAddress.Text = dtMain.Rows(0).Item("StreetAddress")
        'Me.TxtPhoneNumber.Text = dtMain.Rows(0).Item("PhoneNumber")
        'Me.TxtMapLink.Text = dtMain.Rows(0).Item("MapLocation")
        'If dtMain.Rows(0).Item("IsActive") = "-1" Then
        '    Me.ChkIsActive.CheckState = CheckState.Checked
        'Else
        '    Me.ChkIsActive.CheckState = CheckState.Unchecked
        'End If
        'Me.TxtMonday.Text = dtMain.Rows(0).Item("MondayHours")
        'Me.TxtTuesday.Text = dtMain.Rows(0).Item("TuesdayHours")
        'Me.TxtWednesday.Text = dtMain.Rows(0).Item("WednesdayHours")
        'Me.TxtThursday.Text = dtMain.Rows(0).Item("ThursdayHours")
        'Me.TxtFriday.Text = dtMain.Rows(0).Item("FridayHours")
        'Me.TxtSaturday.Text = dtMain.Rows(0).Item("SaturdayHours")
        'Me.TxtSunday.Text = dtMain.Rows(0).Item("SundayHours")
        ''Me.ChkIsActive.CheckState = dtMain.Rows(0).Item(5)

        ''Me.DataGridView1.DataSource = dtHours





        'Return False
    End Sub

    Public Function ListBrands(Optional ByRef IsActive As ActiveStatus = ActiveStatus.Active, Optional BrandID As Integer = -1) As DataTable
        Dim dtBrandList As New DataTable
        Dim mSQL As String

        If IsActive = ActiveStatus.Active Then
            ' mSQL = "SELECT tblSubModels.*, (ModelYear || \" \ " || Driveline) AS SubmodelName From tblSubModels WHERE IsActive = '" & vbTrue & "'"

            '          Select
            'CustomerId,
            'FirstName || ' ' || LastName AS "Full Name"
            '              From Customer
            'Limit 5

            mSQL = "SELECT * FROM VehicleBrands WHERE IsActive = '" & vbTrue & "'"
        ElseIf IsActive = ActiveStatus.Inactive Then
            mSQL = "SELECT * FROM VehicleBrands WHERE IsActive = '" & vbFalse & "'"

        Else
            mSQL = "SELECT * FROM VehicleBrands"
        End If

        If BrandID <> -1 Then
            mSQL += " And BrandID = '" & BrandID & "'"
        End If

        'Debug.Print(mSQL & " - " & IsActive)

        'Dim mSQL As String = "SELECT * FROM tblBanks"
        Dim connectionString As String = Globals.cGlobals.gConnection.gConnectionString
        'Debug.Print(connectionString)
        Try
            Using conn As New SQLiteConnection(connectionString)
                Using cmd As New SQLiteCommand(mSQL, conn)
                    conn.Open()
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dtBrandList)
                    End Using
                    conn.Close()
                End Using
            End Using
        Catch ex As Exception
        End Try

        Return dtBrandList
    End Function
    Public Sub Deactivate(intBrandID As Integer, strBrandName As String)
        'Dim intBrandValue As Integer
        'Dim strBrandName As String
        'TODO: Add option to reactivate a vehicle
        'Try
        '    intBrandValue = CInt(LstBrands.SelectedValue)
        '    'strBrandName = LstBrands.SelectedItems(0).ToString
        '    strBrandName = LstBrands.GetItemText(LstBrands.SelectedItem)
        '    'strBrandName = LstBrands.SelectedItems(0).text
        'Catch ex As Exception ' Ignore error on initial load
        '    intBrandValue = 0
        '    strBrandName = ""
        'End Try

        If intBrandID <= 0 Then
            MessageBox.Show("Nothing to deactivate", "Important Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If strBrandName = "" Or strBrandName = String.Empty Then
            strBrandName = "Unknown Brand (ID = " & intBrandID & ")"
        End If
        Dim msgInput As Integer
        msgInput = MsgBox("Are you sure you want to deactivate " & strBrandName & "?" & vbCrLf & vbCrLf & "Deactivation can be reversed in 5-7 business days", CType(vbYesNo + vbQuestion, MsgBoxStyle), "Confirm deactivation")
        If msgInput = vbYes Then
            'deactivate
            Dim gconnectionString As String = Globals.cGlobals.gConnection.gConnectionString
            Dim ConnectionString As String
            'Dim 
            ConnectionString = "UPDATE VehicleBrands SET IsActive = '0' WHERE BrandID = " & intBrandID

            Dim myTrans As SQLiteTransaction
            'Dim sqlite_conn As SQLiteConnection
            Dim sqlite_cmd As SQLiteCommand
            ' create a new database connection:
            Using sqlite_conn = New SQLiteConnection(gConnectionString)

                ' open the connection:
                sqlite_conn.Open()
                myTrans = sqlite_conn.BeginTransaction
                Try
                    'create the command

                    sqlite_cmd = sqlite_conn.CreateCommand()
                    sqlite_cmd.CommandText = ConnectionString
                    sqlite_cmd.ExecuteNonQuery()
                    Debug.Print("Record was sucessfully written to database.")
                    myTrans.Commit()

                    ' refreshes the list

                    'Return True
                Catch ex As Exception
                    'TODO :'IF NO RECORD EXISTS, IT'LL FAIL. ADD ROUTINE TO INSERT NEW RECORD INSTEAD
                    myTrans.Rollback()
                    Debug.Print(ex.ToString())
                    Debug.Print("Neither record was written to database.")
                    'Return False
                Finally
                    'close connection, garbage cleanup
                    sqlite_conn.Close()
                    sqlite_conn.Dispose()
                End Try
            End Using
            '//////////////////////////////////

        End If
    End Sub
End Class