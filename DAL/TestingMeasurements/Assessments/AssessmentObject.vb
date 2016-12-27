Public Class AssessmentObject
    Sub New(ByVal groupName As String, functionName As String, test As String, standardScoreLo As String, standardScoreHi As String)
        Me.TestFunction = functionName
        Me.TestName = test
        Me._loScore = standardScoreLo
        Me._hiScore = standardScoreHi

        Me.Group = groupName
    End Sub
    Private Property _functionName As String = String.Empty
    Private Property _testName As String = String.Empty
    Private Property _loScore As String = String.Empty
    Private Property _hiScore As String = String.Empty
    Private Property _totalItems As String = String.Empty
    Private Property _groupTitle As String = String.Empty
    Public Property Group As String
        Get
            Return _groupTitle
        End Get
        Set(value As String)
            _groupTitle = value
        End Set
    End Property


    Public Property TestFunction As String
        Get
            Return _functionName
        End Get
        Set(value As String)
            _functionName = value
        End Set
    End Property

    Public Property TestName As String
        Get
            Return _testName
        End Get
        Set(value As String)
            _testName = value
        End Set
    End Property
    Public Property BottomScoreRange As String
        Get

            Return _loScore
        End Get
        Set(value As String)
         
            _loScore = value
        End Set
    End Property

    Public Property TopScoreRange As String
        Get
            Return _hiScore
        End Get
        Set(value As String)
          
            _hiScore = value
        End Set
    End Property

   

End Class
