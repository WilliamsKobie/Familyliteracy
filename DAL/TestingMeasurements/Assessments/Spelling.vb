Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Spelling
    Implements ItestMethod

    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim spellingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Spelling_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Spelling_Tests")
        Dim dt As DataTable = ds.Tables("Spelling_Tests")

        Dim dr As DataRow
        Dim assessmentFunction As String = String.Empty
        Dim groupName As String = "Spelling"
        Dim testName As String = String.Empty
        Dim scoreLo As String = "0"
        Dim scoreHi As String = "0"
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            testName = dr("Test_Name")

            scoreLo = dr("Bottom_Standard_Score")
            scoreHi = dr("Top_Standard_Score")
            spellingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return spellingResults
    End Function
    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim spellingResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Spelling"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Spelling")
        Dim dt As DataTable = ds.Tables("Spelling")

        Dim dr As DataRow
        Dim assessmentFunction As String = String.Empty
        Dim groupName As String = "Spelling"
        Dim testName As String = String.Empty
        Dim scoreLo As String = "0"
        Dim scoreHi As String = "0"
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")

          
            spellingResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return spellingResults
    End Function
End Class
