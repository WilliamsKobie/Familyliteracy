Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Rapid_Naming
    Implements ItestMethod

    Public Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim rnResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Rapid_Naming_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Rapid_Naming_Tests")
        Dim dt As DataTable = ds.Tables("Rapid_Naming_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Rapid Naming"
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

            rnResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return rnResults
    End Function

    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim rnResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Rapid_Naming"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Rapid_Naming")
        Dim dt As DataTable = ds.Tables("Rapid_Naming")

        Dim dr As DataRow
        Dim groupName As String = "Rapid Naming"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
        

            rnResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return rnResults
    End Function
End Class
