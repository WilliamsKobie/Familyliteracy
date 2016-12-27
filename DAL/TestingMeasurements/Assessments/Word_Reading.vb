Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Word_Reading
    Implements ItestMethod

    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim wordReadingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Word_Reading_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Word_Reading_Tests")
        Dim dt As DataTable = ds.Tables("Word_Reading_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Word Reading"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            testName = dr("Test_Name")
            scoreLo = dr("Bottom_Standard_Score")
            scoreHi = dr("Top_Standard_Score")

            wordReadingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return wordReadingResults
    End Function

    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim wordReadingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Word_Reading"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Word_Reading")
        Dim dt As DataTable = ds.Tables("Word_Reading")

        Dim dr As DataRow
        Dim groupName As String = "Word Reading"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            wordReadingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return wordReadingResults
    End Function
End Class
