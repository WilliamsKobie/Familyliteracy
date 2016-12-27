Imports System.Globalization
Public Class DisplayCBMData

    Private Property _recordingdate As String
    Private Property _cwpm As String
    Private Property _errors As String
    Private Property _wordCount As String
    Private Property _source As String
    Private Property _speed As String
    Private Property _lvl As String
    Private Property _passage As String
    Private Property _recordNumber As String
    Public Sub New(recordnum As String, recordingdate As String, correctwpm As String, totalErrors As String, wordCount As String, timed As String, source As String, level As String, passage As String)
        No = recordnum
        Session_Date = recordingdate
        CWPM = correctwpm
        Errors = totalErrors
        Total_Words = wordCount
        Source_Material = source
        Time = timed
        Reading_Level = level
        Reading_Passage = passage
    End Sub
  
    Public Property Session_Date As String
        Get

            Return _recordingdate
        End Get
        Set(value As String)
            Dim newDateFormat As DateTime
            newDateFormat = Convert.ToDateTime(value)

            _recordingdate = newDateFormat.ToString("dddd, MMMM dd, yyyy")
        End Set
    End Property

    Public Property CWPM As String
        Get
            Return _cwpm
        End Get
        Set(value As String)
            _cwpm = value & " cwpm"
        End Set
    End Property
  

    Public Property Total_Words As String
        Get
            Return _wordCount
        End Get
        Set(value As String)
            _wordCount = value
        End Set
    End Property
    Public Property Errors As String
        Get
            Return _errors
        End Get
        Set(value As String)
            _errors = value
        End Set
    End Property
    Public Property Time As String
        Get
            Return _speed
        End Get
        Set(value As String)
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
        End Set
    End Property

  

   
    Public Property Source_Material As String
        Get
            Return _source
        End Get
        Set(value As String)
            _source = value
        End Set
    End Property
    Public Property Reading_Level As String
        Get
            Return _lvl
        End Get
        Set(value As String)
            _lvl = value
        End Set
    End Property

    Public Property Reading_Passage As String
        Get
            Return _passage
        End Get
        Set(value As String)
            _passage = value
        End Set
    End Property

    Public Property No As String
        Get
            Return _recordNumber
        End Get
        Set(value As String)
            _recordNumber = value
        End Set
    End Property
End Class
