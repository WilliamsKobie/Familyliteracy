Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports System.Configuration
Public Class Language
    Implements ItestMethod
    Dim connString As Object
    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim languageResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Language_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Language_Tests")
        Dim dt As DataTable = ds.Tables("Language_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Language"
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
            languageResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next
        Return languageResults
    End Function
    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim languageResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Language"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Language")
        Dim dt As DataTable = ds.Tables("Language")

        Dim dr As DataRow
        Dim groupName As String = "Language"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows

            assessmentFunction = dr("Function")
          
            languageResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next
        Return languageResults
    End Function
End Class
