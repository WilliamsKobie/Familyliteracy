Imports System.Configuration
Imports System.Data.SqlClient

Public Class ReportScheduleSignature : Implements IReportMenuSignatures
    Private _connection As String

    Public Function Capture(index As String) As String Implements IReportMenuSignatures.Capture
        Dim _connection = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString()
        Dim reportForm As String = ""
        Dim query = "Select * From dbo.ReportScheduleMenu Where ReportID=" & index
        Dim conn As New SqlConnection(_connection)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim reader = cmd.ExecuteReader()
        Do While (reader.Read())
            reportForm = reader.GetString(2)
        Loop
        Return reportForm
    End Function
End Class

Public Class ReportClientProfileSignature : Implements IReportMenuSignatures
    Private _connection As String

    Public Function Capture(index As String) As String Implements IReportMenuSignatures.Capture
        Dim _connection = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString()
        Dim reportForm As String = ""
        Dim query = "Select * From dbo.ReportClientProfileMenu Where ReportID=" & index
        Dim conn As New SqlConnection(_connection)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim reader = cmd.ExecuteReader()
        Do While (reader.Read())
            reportForm = reader.GetString(2)
        Loop
        Return reportForm
    End Function
End Class
