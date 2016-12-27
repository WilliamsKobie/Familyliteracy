Imports DAL
Public Class ImportCollection


    Private Property _recordingdate As String
    Private Property _cwpm As String
    Private Property _errors As String
    Private Property _wordCount As String

    Private Property _speed As String
    Private Property _lvl As String
    Private Property _passage As String
    Private Property _studentNo As String
    Private Property _fName As String
    Private Property _lName As String
    Public Sub New(lname As String, fName As String, recordingdate As String, correctwpm As String, totalErrors As String, wordCount As String, timed As String, level As String, passage As String)

        Session_Date = recordingdate
        CWPM = correctwpm
        Errors = totalErrors
        Total_Words = wordCount

        Time = timed
        Reading_Level = level
        Reading_Passage = passage
        FirstName = fname
        LastName = lName
        StudentNo = lName & ", " & fname
    End Sub
    Public Property StudentNo As String
        Get
            Return _studentNo
        End Get
        Set(value As String)

            Dim Name As INameConversion = New StudentNameconversion
            value = Name.convertToId(value.Trim)
            _studentNo = value
        End Set
    End Property
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
            _cwpm = value
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



    Public Property LastName As String
        Get
            Return _fName
        End Get
        Set(value As String)
            _fName = value
        End Set
    End Property
    Public Property FirstName As String
        Get
            Return _lName
        End Get
        Set(value As String)
            _lName = value
        End Set
    End Property
End Class

