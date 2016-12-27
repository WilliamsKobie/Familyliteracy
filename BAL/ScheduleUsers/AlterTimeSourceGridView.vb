
'Collection which stores time and user attributes when a student is rescheduled to a different time slot
'Used by the interface RescheduleDailyDisplay

Public Class OriginalTime

    Private _idNumber As Integer

    Public Property key() As Integer
        Get
            Return _idNumber
        End Get
        Set(ByVal value As Integer)
            _idNumber = value
        End Set
    End Property

    Private _Name As [String]

    Public Property Name() As [String]
        Get
            Return _Name
        End Get
        Set(ByVal value As [String])
            _Name = value
        End Set
    End Property

    Private Original_Clinician As [String]

    Public Property S_Clinician() As [String]
        Get
            Return Original_Clinician
        End Get
        Set(ByVal value As [String])
            Original_Clinician = value
        End Set
    End Property




    Private _SourceTimeIn As [String]

    Public Property S_TimeIn() As [String]
        Get
            Return _SourceTimeIn
        End Get
        Set(ByVal value As [String])
            _SourceTimeIn = value
        End Set
    End Property
    Private _SourceTimeOut As [String]

    Public Property S_TimeOut() As [String]
        Get
            Return _SourceTimeOut
        End Get
        Set(ByVal value As [String])
            _SourceTimeOut = value
        End Set
    End Property



    Private _OrigRow As Integer

    Public Property OrigRow() As Integer
        Get
            Return _OrigRow
        End Get
        Set(ByVal value As Integer)
            _OrigRow = value
        End Set
    End Property

    Private _OrigCol As Integer

    Public Property OrigCol() As Integer
        Get
            Return _OrigCol
        End Get
        Set(ByVal value As Integer)
            _OrigCol = value
        End Set
    End Property
    Private _totaltime As Integer
    Public Property totaltime() As Integer
        Get
            Return _totaltime
        End Get
        Set(ByVal value As Integer)
            _totaltime = value
        End Set
    End Property


    Private _Location As [String]
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property




    Private _Status As [String]
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property


    Public Sub New()
        Me.key = 0
        Me.Name = String.Empty
        Me.S_Clinician = String.Empty
        Me.S_TimeIn = String.Empty
        Me.S_TimeOut = String.Empty

        Me.totaltime = 0

        Me.OrigCol = 0
        Me.OrigRow = 0
        Me.Location = String.Empty
        Me.Status = "Proposed"
    End Sub

    Public Sub New(ByVal idNumber As Integer, ByVal Name As String, ByVal SourceClinician As String, ByVal SourcetimeIn As String, ByVal SourceTimeOut As String, ByVal origRow As Integer, ByVal origCol As Integer, ByVal totaltime As Integer, ByVal Status As String, ByVal location As String)
        Me.key = idNumber
        Me.Name = Name
        Me.S_Clinician = SourceClinician
        Me.S_TimeIn = SourcetimeIn
        Me.S_TimeOut = SourceTimeOut

        Me.totaltime = totaltime

        Me.OrigCol = origCol
        Me.OrigRow = origRow
        Me.Location = location
        Me.Status = Status
    End Sub 'New

End Class

REM Stores all the student data temporarily in memory.
REM Used for rescheduling student on a single day. 
REM The RescheduleDailyDisplay object is used.

Public Class Storage
   
    Private _idNumber As Integer

    Public Property key() As Integer
        Get
            Return _idNumber
        End Get
        Set(ByVal value As Integer)
            _idNumber = value
        End Set
    End Property

    Private _Name As [String]

    Public Property Name() As [String]
        Get
            Return _Name
        End Get
        Set(ByVal value As [String])
            _Name = value
        End Set
    End Property

    Private Original_Clinician As [String]

    Public Property S_Clinician() As [String]
        Get
            Return Original_Clinician
        End Get
        Set(ByVal value As [String])
            Original_Clinician = value
        End Set
    End Property
    Private New_Clinician As [String]

    Public Property D_Clinician() As [String]
        Get
            Return New_Clinician
        End Get
        Set(ByVal value As [String])
            New_Clinician = value
        End Set
    End Property

    Private _DestinationTimeIn As [String]

    Public Property DestinationTimeIn() As [String]
        Get
            Return _DestinationTimeIn
        End Get
        Set(ByVal value As [String])
            _DestinationTimeIn = value
        End Set
    End Property
    Private _DestinationTimeout As String

    Public Property DestinationTimeout() As String
        Get
            Return _DestinationTimeout
        End Get
        Set(ByVal value As String)
            _DestinationTimeout = value
        End Set
    End Property

    Private _SourceTimeIn As [String]

    Public Property S_TimeIn() As [String]
        Get
            Return _SourceTimeIn
        End Get
        Set(ByVal value As [String])
            _SourceTimeIn = value
        End Set
    End Property
    Private _SourceTimeOut As [String]

    Public Property S_TimeOut() As [String]
        Get
            Return _SourceTimeOut
        End Get
        Set(ByVal value As [String])
            _SourceTimeOut = value
        End Set
    End Property
    Private _Row As Integer

    Public Property Row() As Integer
        Get
            Return _Row
        End Get
        Set(ByVal value As Integer)
            _Row = value
        End Set
    End Property

    Private _Col As Integer

    Public Property Col() As Integer
        Get
            Return _Col
        End Get
        Set(ByVal value As Integer)
            _Col = value
        End Set
    End Property
    Private _OrigRow As Integer

    Public Property OrigRow() As Integer
        Get
            Return _OrigRow
        End Get
        Set(ByVal value As Integer)
            _OrigRow = value
        End Set
    End Property

    Private _OrigCol As Integer

    Public Property OrigCol() As Integer
        Get
            Return _OrigCol
        End Get
        Set(ByVal value As Integer)
            _OrigCol = value
        End Set
    End Property
    Private _totaltime As Integer
    Public Property totaltime() As Integer
        Get
            Return _totaltime
        End Get
        Set(ByVal value As Integer)
            _totaltime = value
        End Set
    End Property
    Private _Conflict As Boolean
    Public Property Conflict() As Boolean
        Get
            Return _Conflict
        End Get
        Set(ByVal value As Boolean)
            _Conflict = value
        End Set
    End Property
    Private _Location As [String]
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property

    Private _Subject As [String]
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Private _Status As [String]
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property


    Public Sub New(ByVal idNumber As Integer, ByVal Name As [String], ByVal SourceClinician As String, ByVal SourcetimeIn As String, ByVal SourceTimeOut As String, ByVal DestinationClinician As String, ByVal DestinationTimeIn As [String], ByVal DestinationTimeout As String, ByVal Row As Integer, ByVal Col As Integer, ByVal origRow As Integer, ByVal origCol As Integer, ByVal totaltime As Integer, ByVal Conflict As Boolean, ByVal Location As String, ByVal Subject As String, ByVal Status As String)
        Me.key = idNumber
        Me.Name = Name
        Me.S_Clinician = SourceClinician
        Me.S_TimeIn = SourcetimeIn
        Me.S_TimeOut = SourceTimeOut
        Me.D_Clinician = DestinationClinician
        Me.DestinationTimeIn = DestinationTimeIn
        Me.DestinationTimeout = DestinationTimeout
        Me.Row = Row
        Me.Col = Col
        Me.totaltime = totaltime
        Me.Conflict = Conflict
        Me.OrigCol = origCol
        Me.OrigRow = origRow
        Me.Location = Location
        Me.Subject = Subject
        Me.Status = Status
    End Sub 'New
End Class
