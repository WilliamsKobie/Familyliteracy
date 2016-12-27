Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Memory
    Implements ItestMethod
    Dim connString As Object
    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim memoryResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Memory_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Memory_Tests")
        Dim dt As DataTable = ds.Tables("Memory_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Memory"
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
            memoryResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next
        Return memoryResults
    End Function

    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim memoryResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Memory"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Memory")
        Dim dt As DataTable = ds.Tables("Memory")

        Dim dr As DataRow
        Dim groupName As String = "Memory"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            memoryResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))
        Next
        Return memoryResults
    End Function
End Class
