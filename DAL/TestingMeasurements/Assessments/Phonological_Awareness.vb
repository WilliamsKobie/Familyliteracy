Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Class Phonological_Awareness
    Implements ItestMethod

    Function Tests() As List(Of AssessmentObject) Implements ItestMethod.TestListing
        Dim phenoemResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Phonological_Awareness_Tests"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Phonological_Awareness_Tests")
        Dim dt As DataTable = ds.Tables("Phonological_Awareness_Tests")

        Dim dr As DataRow
        Dim groupName As String = "Phonological Awareness"
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

            phenoemResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))

        Next

        Return phenoemResults
    End Function
    Public Function Groups() As List(Of AssessmentObject) Implements ItestMethod.FunctionListing
        Dim phenoemResults As New List(Of AssessmentObject)
        Dim query As String = "SELECT * FROM Phonological_Awareness"
        Dim connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Phonological_Awareness")
        Dim dt As DataTable = ds.Tables("Phonological_Awareness")

        Dim dr As DataRow
        Dim groupName As String = "Phonological Awareness"
        Dim assessmentFunction As String = String.Empty
        Dim testName As String = String.Empty
        Dim scoreLo As String = String.Empty
        Dim scoreHi As String = String.Empty
        Dim items As String = String.Empty
        For Each dr In dt.Rows
            assessmentFunction = dr("Function")
            phenoemResults.Add(New AssessmentObject(groupName, assessmentFunction, testName, scoreLo, scoreHi))
        Next

        Return phenoemResults
        Return Nothing
    End Function
End Class
