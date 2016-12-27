
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Public Class Export

    Public Shared Function AllStudents() As List(Of ExportCollection)
        Dim export As New List(Of ExportCollection)
        Dim connString As Object = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "SELECT * FROM Student_Testing_Measurements"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Student_Testing_Measurements")
        Dim dt As DataTable = ds.Tables("Student_Testing_Measurements")
        Dim dr As DataRow
        Dim recordingdate As String = String.Empty

        Dim cwpm As String = String.Empty
        Dim errors As String = String.Empty
        Dim timeCount As String
        Dim testingSource As String = String.Empty
        Dim totalWordCount As String = String.Empty
        Dim readingLevel As String = String.Empty
        Dim passage As String = String.Empty
        Dim recordNumber As String = String.Empty
        Dim studentno As String = String.Empty
        For Each dr In dt.Rows
            studentno = dr("StudentId")
            recordingdate = dr("Date").ToString()

            cwpm = dr("Correct_Words_Each_Minute").ToString
            errors = dr("Errors").ToString
            timeCount = dr("Timed")
            testingSource = dr("Text_Source").ToString
            totalWordCount = dr("Word_Count").ToString
            readingLevel = dr("Reading_Level").ToString
            passage = dr("Passage").ToString
            recordNumber = dr("count").ToString
            export.Add(New ExportCollection(studentno, recordingdate, cwpm, errors, testingSource, totalWordCount, timeCount, readingLevel, passage))
        Next
        Return export
    End Function
End Class
