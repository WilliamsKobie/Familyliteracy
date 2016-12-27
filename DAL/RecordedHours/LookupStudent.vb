Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class LookupStudent
    Implements IreturnHour
    Function CheckForStudent(ByVal studentId As String) As Dictionary(Of String, String) Implements IreturnHour.CheckForStudent

        Dim connectionString As Object = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim record As New Dictionary(Of String, String)
        Dim query As String = "SELECT * FROM StudentHour WHERE StudentId='" & studentId & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "StudentHour")
        Dim dt As DataTable = ds.Tables("StudentHour")
        Dim dr As DataRow
        record("RecordExist") = "No"
        record("DateRecord") = String.Empty
        record("HourNo") = "0"
        For Each dr In dt.Rows
            record("RecordExist") = "Yes"
            record("DateRecord") = dr("Date")

            record("HourNo") = dr("Hour_No")
        Next


        Return record
    End Function
End Class

