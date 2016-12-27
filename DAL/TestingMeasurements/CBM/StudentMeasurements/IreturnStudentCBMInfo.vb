Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Interface IReturnStudentCBMInfo
    Function StudentTestData(ByVal studentId As String) As List(Of DisplayCBMData)
End Interface

Public Class StudentCBMInfo
    Implements IreturnStudentCBMInfo


    Public Function StudentTestData(studentId As String) As List(Of DisplayCBMData) Implements IreturnStudentCBMInfo.StudentTestData
        Dim CBMData As New List(Of DisplayCBMData)
        Dim connString As Object = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query = "SELECT * FROM CBMData Where StudentId='" & studentId & "'"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "CBMData")
        Dim dt As DataTable = ds.Tables("CBMData")
        Dim dr As DataRow
        Dim recordingdate As String
        Dim cwpm As String = String.Empty
        Dim errors As String = String.Empty
        Dim timeCount As String
        Dim testingSource As String = String.Empty
        Dim totalWordCount As String = String.Empty
        Dim readingLevel As String = String.Empty
        Dim passage As String = String.Empty
        Dim recordNumber As String = String.Empty
        For Each dr In dt.Rows
            recordingdate = dr("Date")
            cwpm = dr("Correct_Words_Each_Minute").ToString
            errors = dr("Errors").ToString
            timeCount = dr("Timed")
            testingSource = dr("Text_Source").ToString
            totalWordCount = dr("Word_Count").ToString
            readingLevel = dr("Reading_Level").ToString
            passage = dr("Passage").ToString
            recordNumber = dr("CBMID").ToString
            CBMData.Add(New DisplayCBMData(recordNumber, recordingdate, cwpm, errors, totalWordCount, timeCount, testingSource, readingLevel, passage))
        Next


        Return cbmData
    End Function
End Class
