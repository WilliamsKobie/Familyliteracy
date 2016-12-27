Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports System.Configuration
Public Class DeleteAssesmentRecord
    Public Shared Function RemoveTestRecord(ByVal studentId As String, ByVal index As Int16)

        Dim query As String = "DELETE FROM Assessments Where AssessmentID='" & index & "' And studentId='" & studentId & "'"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
       
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        Return Nothing



    End Function

End Class
