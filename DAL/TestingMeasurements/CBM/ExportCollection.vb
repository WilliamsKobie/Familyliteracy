
Public Class ExportCollection


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
    Private Property _source As String

    Public Sub New(studentNo As String, recordingdate As String, correctwpm As String, totalErrors As String, readingsource As String, wordCount As String, timed As String, level As String, passage As String)

        Session_Date = recordingdate
        CWPM = correctwpm
        Errors = totalErrors
        Total_Words = wordCount

        Time = timed
        Reading_Level = level
        Reading_Passage = passage
        LastName = studentNo
        FirstName = studentNo
        Source = readingsource
    End Sub

    Public Property LastName As String
        Get
            Return _lName
        End Get
        Set(value As String)
            Dim lname As String = String.Empty
            Dim splitname() As String
            Dim fullname As String = String.Empty
            Dim student As INameConversion = New StudentNameConversion
            fullname = student.convertName(value)
            If fullname <> String.Empty Then
                splitname = fullname.Split(", ")
                lname = splitname(0)
            End If
            _lName = lname.Trim
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _fName
        End Get
        Set(value As String)
            Dim fullname As String = String.Empty
            Dim splitName() As String
            Dim student As INameConversion = New StudentNameConversion
            Dim fname As String = String.Empty
            fullname = student.convertName(value)
            If fullname <> String.Empty Then

                splitName = fullname.Split(", ")
                fname = splitName(1)
            End If
            _fName = fname.Trim
        End Set
    End Property
    Public Property Source As String
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
    Public Property Session_Date As String
        Get

            Return _recordingdate
        End Get
        Set(value As String)
            Dim newDateFormat As DateTime
            newDateFormat = Convert.ToDateTime(value)

            _recordingdate = newDateFormat.ToString("yyyy/MM/dd")
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





   




 
  

   

End Class

