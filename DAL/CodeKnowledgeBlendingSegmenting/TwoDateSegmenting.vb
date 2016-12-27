Imports System.Data.SqlClient
Imports System.Configuration

Public Class SegmentingDataLocator : Implements ISegmentingDataLocator
    Dim SqlConnection As Object
    Public Sub New()
        SqlConnection = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
    End Sub

    Public Function Find() As IEnumerable Implements ISegmentingDataLocator.Find
        Dim studentId, firstName, lastName As String
        Dim TwoDataSegmentcount As New List(Of SegmentingDataAttributes)
        Dim query = "SELECT dbo.Segmenting_Summation.StudentNo, dbo.StudentProfile.[First Name], dbo.StudentProfile.[Last Name]" & _
" FROM  dbo.Segmenting_Summation INNER JOIN" & _
" dbo.StudentProfile ON dbo.Segmenting_Summation.StudentNo = dbo.StudentProfile.StudentID" & _
" GROUP BY dbo.Segmenting_Summation.StudentNo, dbo.StudentProfile.[First Name], dbo.StudentProfile.[Last Name]" & _
" HAVING (COUNT(*) = '2')"
        Dim conn As New SqlConnection(SqlConnection)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim reader = cmd.ExecuteReader()
        Do While (reader.Read())
            studentId = reader.GetInt32(0)
            firstName = reader.GetString(1)
            lastName = reader.GetString(2)
            TwoDataSegmentcount.Add(New SegmentingDataAttributes(studentId, firstName, lastName))
        Loop
        Return TwoDataSegmentcount
    End Function
End Class

Public Class SegmentingDataAttributes
    Public Sub New(ByVal _studentNo As String, ByVal _firstName As String, ByVal _lastName As String)
        StudentId = _studentNo
        FirstName = _firstName
        LastName = _lastName
    End Sub

    Public Property FirstName As String

    Public Property LastName As String

    Public Property StudentId As String

End Class
