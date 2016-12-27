Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Text_Reading
    Implements ItestMethod

    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim textReadingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Text_Reading_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Text_Reading_Tests")
        Dim dt As DataTable = ds.Tables("Text_Reading_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Text Reading"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty

        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            testName = dr("Test_Name")
            scoreLo = dr("Bottom_Standard_Score").ToString()
            scoreHi = dr("Top_Standard_Score").ToString()
            textReadingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))
        Next

        Return textReadingResults
    End Function

    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing

        Dim textReadingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Text_Reading"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Text_Reading")
        Dim dt As DataTable = ds.Tables("Text_Reading")

        Dim dr As DataRow
        Dim groupName As String = "Text Reading"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")          
            textReadingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))
        Next

        Return textReadingResults
    End Function
End Class
