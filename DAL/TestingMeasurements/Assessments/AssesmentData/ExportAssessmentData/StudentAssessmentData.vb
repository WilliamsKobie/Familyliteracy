Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Public Class SingleStudentAssessmentData
    Inherits PeriperalAssessmentData
    Implements IExportassessmentData

    Private Function StudentData(ByVal studentNo As String) As List(Of ExportAssessmentDataObject) Implements IExportassessmentData.StudentData
        Dim assessmentData As New List(Of ExportAssessmentDataObject)
        Dim connString As SqlConnection
        connString = New SqlConnection(ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString)
        Dim query As String = "SELECT * FROM ASSESSMENTS WHERE StudentId='" & studentNo & "'"
        Dim cmd As New SqlCommand(query, connString)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Assessments")
        Dim dt As DataTable = ds.Tables("Assessments")
        Dim dr As DataRow
        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim groupType As String = String.Empty
        Dim functionType As String = String.Empty
        Dim testName As String = String.Empty
        Dim recordedDate As String = String.Empty
        Dim rawScore As String = String.Empty
        Dim totalItems As String = String.Empty
        Dim standardScore As String = String.Empty
        Dim processingUser As String = String.Empty
        Dim index As String = String.Empty
        Dim percentscore As String = "0"
        For Each dr In dt.Rows

            groupType = dr("Group")
            functionType = dr("Function")
            testName = dr("Test_Name").ToString
            recordedDate = dr("Date").ToString
            rawScore = dr("Raw_Score").ToString
            standardScore = dr("Standard_Score").ToString

            processingUser = dr("OperatorID").ToString
            If (standardScore <> Nothing) Or (standardScore <> "0") Then
                percentscore = ConvertScoretoPercent(standardScore)
            End If
            assessmentData.Add(New ExportAssessmentDataObject(studentNo, groupType, functionType, testName, recordedDate, rawScore, standardScore, percentscore, processingUser))
        Next

        Return assessmentData
    End Function
End Class

Public Class AllStudentsAssessmentData
    Inherits PeriperalAssessmentData
    Implements IExportassessmentData
    Private Function StudentData(ByVal studentNo As String) As List(Of ExportAssessmentDataObject) Implements IExportassessmentData.StudentData
        Dim assessmentData As New List(Of ExportAssessmentDataObject)
        Dim connString As SqlConnection
        connString = New SqlConnection(ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString)
        Dim query As String = "SELECT * FROM ASSESSMENTS"
        Dim cmd As New SqlCommand(query, connString)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Assessments")
        Dim dt As DataTable = ds.Tables("Assessments")
        Dim dr As DataRow
        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim groupType As String = String.Empty
        Dim functionType As String = String.Empty
        Dim testName As String = String.Empty
        Dim recordedDate As String = String.Empty
        Dim rawScore As String = String.Empty
        Dim totalItems As String = String.Empty
        Dim standardScore As String = String.Empty
        Dim processingUser As String = String.Empty
        Dim index As String = String.Empty
        Dim percentscore As String = "0"
        For Each dr In dt.Rows
            studentNo = dr("StudentId")
            groupType = dr("Group")
            functionType = dr("Function")
            testName = dr("Test_Name").ToString
            recordedDate = dr("Date").ToString
            rawScore = dr("Raw_Score").ToString

            standardScore = dr("Standard_Score").ToString

            processingUser = dr("OperatorID").ToString
            If standardScore <> Nothing Or standardScore <> "0" Then
                percentscore = ConvertScoretoPercent(standardScore)
            End If
            assessmentData.Add(New ExportAssessmentDataObject(studentNo, groupType, functionType, testName, recordedDate, rawScore, standardScore, percentscore, processingUser))
        Next

        Return assessmentData
    End Function
End Class
