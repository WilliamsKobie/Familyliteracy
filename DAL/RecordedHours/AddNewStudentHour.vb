Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class AddNewStudentHour
    Implements ISaveHour
    Private connString As Object
    Public Function Save(ByVal studentId As String, recordedDate As String, hour As Integer) Implements ISaveHour.Save
        Dim newdate As Date
        If recordedDate = "  /  /" Then
            newdate = #12/12/1900#

        Else
            newdate = Convert.ToDateTime(recordedDate)

        End If
        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "INSERT INTO StudentHour ([StudentId],[Date],[Hour_No]) VALUES(@studentNo,@recordDate,@hourNo)"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@studentNo", studentId)
        cmd.Parameters.AddWithValue("@recordDate", newdate)
        cmd.Parameters.AddWithValue("@hourNo", hour)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        Return Nothing
    End Function
End Class
