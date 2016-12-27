Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class EditStudentHour
    Implements ISaveHour

    Dim connString As Object
    Public Function Save(studentId As String, recordedDate As String, hour As Integer) Implements ISaveHour.Save
        Dim newdate As Date
        If recordedDate = "  /  /" Then
            newdate = #1/1/1900#

        Else
            newdate = Convert.ToDateTime(recordedDate)

        End If

        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "UPDATE [FamilyLiteracy.mdf].[dbo].[StudentHour] SET [Date]=@recordDate, [Hour_No]=@hrNo WHERE StudentId='" & studentId & "'"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@recordDate", newdate)
        cmd.Parameters.AddWithValue("@hrNo", hour)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        Return Nothing
    End Function
End Class
