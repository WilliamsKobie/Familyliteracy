

Public Class AssessmentdataObject
    Public Sub New(ByVal indexRecord As String, ByVal groupType As String, ByVal functionType As String, ByVal testName As String, ByVal recordedDate As String, ByVal rawScore As String, ByVal standardScore As String, ByVal percentagescore As String, ByVal processor As String)
        Me.Group = groupType
        Me.Function = functionType
        Me.Test = testName
        Me.Date = recordedDate
        Me.Raw_Score = rawScore
        Me.Standard_Score = standardScore
        Me.Index = indexRecord
        Me.Percentage = percentagescore
        Me.Operator = processor

    End Sub
    Private Property _groupValues As String = String.Empty
    Private Property _functionValues As String = String.Empty
    Private Property _testName As String = String.Empty
    Private Property _date As String = String.Empty
    Private Property _rawScore As String = String.Empty
    Private Property _totalItems As String = String.Empty
    Private Property _standardScore As String = String.Empty
    Private Property _operator As String = String.Empty
    Private Property _index As String = String.Empty
    Private Property _percent As String = String.Empty

    Public Property Group As String
        Get
            Return _groupValues
        End Get
        Set(value As String)
            _groupValues = value
        End Set
    End Property

    Public Property [Function] As String
        Get

            Return _functionValues
        End Get
        Set(value As String)
            _functionValues = value
        End Set
    End Property

    Public Property Test As String
        Get
            Return _testName
        End Get
        Set(value As String)
            _testName = value
        End Set
    End Property

    Public Property [Date] As String
        Get
            Return _date
        End Get
        Set(value As String)
            Dim newDateFormat As DateTime
            newDateFormat = Convert.ToDateTime(value)

            _date = newDateFormat.ToString("yyyy/MM/dd")

        End Set
    End Property

    Public Property Raw_Score As String
        Get
            Return _rawScore
        End Get
        Set(value As String)
            _rawScore = value
        End Set
    End Property

 

    Public Property Standard_Score As String
        Get
            Return _standardScore
        End Get
        Set(value As String)
            _standardScore = value
        End Set
    End Property
    Public Property Percentage As String
        Get
            Return _percent
        End Get
        Set(value As String)
            _percent = value
        End Set
    End Property
    Public Property [Operator] As String
        Get
            Return _operator
        End Get
        Set(value As String)
            _operator = value
        End Set
    End Property


    Public Property Index As String
        Get
            Return _index
        End Get
        Set(value As String)
            _index = value
        End Set
    End Property



End Class
