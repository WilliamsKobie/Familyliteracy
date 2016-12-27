
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports DAL

Public Interface ICbmDataExporter
    Function Export(Of T)(value As T) As IEnumerable
End Interface
Public Interface ICbmFilters
    Function Filter(ByVal readingLevel As String, ByRef newReadingLevel As String, ByVal recordingDate As DateTime, ByRef startDate As DateTime) As Integer
End Interface
Public Class EveryStudentCBMData : Implements ICbmDataExporter

    Public Function ExportCBMData(Of T)(value As T) As IEnumerable Implements ICbmDataExporter.Export
        Dim exportData As New List(Of CBMDataCollection)
        Dim connString As Object = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "SELECT * FROM dbo.CBMData"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "CBMData")
        Dim dt As DataTable = ds.Tables("CBMData")
        Dim dr As DataRow
        Dim recordingdate As String = String.Empty

        Dim cwpm As Integer = 0
        Dim errors As Integer = 0
        Dim timeCount As String = ""
        Dim testingSource As String = String.Empty
        Dim totalWordCount As Integer = 0
        Dim readingLevel As String
        Dim passage As String = String.Empty
        Dim recordNumber As Integer = 0
        Dim textList As String = String.Empty
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
            textList = dr("Test_Method").ToString
            exportData.Add(New CBMDataCollection(studentno, recordingdate, cwpm, errors, testingSource, totalWordCount, timeCount, readingLevel, passage, textList))
        Next
        Return exportData
    End Function
End Class

Public Class SingleStudentCBMData : Implements ICbmDataExporter
    Dim connection As String
    Public Function ExportCBMData(Of T)(value As T) As IEnumerable Implements ICbmDataExporter.Export
        Dim CbmDateFilter As ICbmFilters = New CBMDateFilters
        Dim exportData As New List(Of CBMDataCollection)
        Dim cwpm As Integer = 0
        Dim errors As Integer = 0
        Dim timeCount As String = String.Empty
        Dim testingSource As String = String.Empty
        Dim totalWordCount As String = String.Empty
        Dim readingLevel As String
        Dim testMethod As String = String.Empty
        Dim passage As String = String.Empty
        Dim recordNumber As String = String.Empty
        Dim studentNo As String = value.ToString()
        Dim recordingDate As DateTime

        Dim totalDays As Integer = 0
        Dim query = "SELECT TOP (100) PERCENT dbo.StudentProfile.[StudentID], dbo.CBMData.Correct_Words_Each_Minute, dbo.CBMData.Date, dbo.CBMData.Errors, dbo.CBMData.Test_Method, " &
    "dbo.CBMData.Text_Source, dbo.CBMData.Reading_Level " &
    "FROM dbo.CBMData INNER JOIN " &
    "dbo.StudentProfile ON dbo.CBMData.StudentId = dbo.StudentProfile.StudentID " &
    "WHERE  (dbo.StudentProfile.StudentID = '" & studentNo & "') " &
    "ORDER BY dbo.CBMData.Test_Method, dbo.CBMData.Text_Source, dbo.CBMData.Reading_Level, dbo.CBMData.Date"

        connection = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        Dim conn As New SqlConnection(connection)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim row As Integer = 0
        Dim newReadingLevel As String = ""
        Dim startDate As DateTime

        Dim reader = cmd.ExecuteReader
        Do While (reader.Read)
            studentNo = reader.GetValue(0)
            cwpm = reader.GetValue(1)
            recordingDate = reader.GetValue(2)
            errors = reader.GetValue(3)
            testMethod = reader.GetValue(4)
            testingSource = reader.GetValue(5)
            readingLevel = reader.GetValue(6)

            'Aquire the total number of days from the first date of the current Level by Filtering the start Date and Reading Level 
            totalDays = CbmDateFilter.Filter(readingLevel, newReadingLevel, recordingDate, startDate)
            exportData.Add(New CBMDataCollection(studentNo, recordingDate, cwpm, errors, testingSource, readingLevel, testMethod, totalDays))
        Loop
        conn.Close()

        Return exportData
    End Function


End Class

Public Class CBMDateFilters : Implements ICbmFilters
    Public Function Filter(readingLevel As String, ByRef newReadingLevel As String, recordingDate As DateTime, ByRef startDate As DateTime) As Integer Implements ICbmFilters.Filter
        Dim totalDays As Integer = 0
        If (Not newReadingLevel = readingLevel) Then
            startDate = recordingDate
        End If
        newReadingLevel = readingLevel
        totalDays = (recordingDate - startDate).TotalDays
        Return totalDays
    End Function
End Class

Public Class CBMDataCollection

    Public Sub New(studentNo As String, recordingdate As DateTime, correctwpm As Integer, totalErrors As Integer, readingsource As String, level As String, _testMethod As String, _totalDays As Integer)

        Session_Date = recordingdate
        CWPM = correctwpm
        Errors = totalErrors
        Reading_Level = level
        LastName = studentNo
        FirstName = studentNo
        FullName = studentNo
        Source = readingsource
        Text_List = _testMethod
        Total_Days = _totalDays
    End Sub
    Public Sub New(studentNo As String, recordingdate As DateTime, correctwpm As Integer, totalErrors As Integer, readingsource As String, wordCount As Integer, timed As String, level As String, passage As String, _testMethod As String)

        Session_Date = recordingdate
        CWPM = correctwpm
        Errors = totalErrors
        Total_Words = wordCount

        Time = timed
        Reading_Level = level
        Reading_Passage = passage
        LastName = studentNo
        FirstName = studentNo
        FullName = studentNo
        Source = readingsource
        Text_List = _testMethod

    End Sub
    Private _lName As String = String.Empty
    Public Property LastName As String
        Get
            Return _lName
        End Get
        Set(value As String)
            Dim lname As String = String.Empty
            Dim splitname() As String
            Dim fullname As String = String.Empty
            Dim student As INameConversion = New StudentNameConversion
            fullname = student.ConvertName(value)
            If fullname <> String.Empty Then
                splitname = fullname.Split(", ")
                lname = splitname(0)
            End If
            _lName = lname.Trim
        End Set
    End Property
    Private _fName As String = String.Empty
    Public Property FirstName As String
        Get
            Return _fName
        End Get
        Set(value As String)
            Dim fullname As String = String.Empty
            Dim splitName() As String
            Dim student As INameConversion = New StudentNameConversion
            Dim fname As String = String.Empty
            fullname = student.ConvertName(value)
            If fullname <> String.Empty Then

                splitName = fullname.Split(", ")
                fname = splitName(1)
            End If
            _fName = fname.Trim
        End Set
    End Property
    Public Property Source As String

    Public Property Reading_Level As String
    Private _recordingdate As DateTime
    Public Property Session_Date As DateTime

    Public Property Reading_Passage As String
    Public Property CWPM As Integer
    Public Property Total_Words As Integer
    Public Property Errors As Integer
    Private _speed As Integer
    Public Property Time As String
        Get
            Return _speed
        End Get
        Set(value As String)
            If Not value = "" Then
                Dim convertDate As DateTime = CDate(value)
                Dim splitTimer() As String
                Dim wholeSecond As String = String.Empty
                Dim fractionOfSecond As String = String.Empty
                Dim timer As String = String.Empty
                value = convertDate.ToString("h:mm")
                splitTimer = value.Split(":")
                wholeSecond = splitTimer(0).Trim
                fractionOfSecond = splitTimer(1).Trim
                timer = wholeSecond.Trim & ":" & fractionOfSecond.Trim
                _speed = timer
            End If
        End Set
    End Property
    Public Property Text_List As String
    Private _fullName As String = String.Empty
    Public Property FullName As String
        Get
            Return _fullName
        End Get
        Set(value As String)
            Dim student As INameConversion = New StudentNameConversion
            _fullName = student.ConvertName(value)
        End Set
    End Property
    Public Property Total_Days As Integer
End Class