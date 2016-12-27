
REM Stores all the student data temporarily in memory.
REM Used for rescheduling student on a single day. 
REM The RescheduleDailyDisplay screen makes use of these properties.
REM used to store student info if there are conflicts with other students or clinicians.


Public Class AutoSelectConflicts
    Private _schDate As String
    Private _Name As [String]
    Private _Conflict As Boolean
    Public Property Conflict() As Boolean
        Get
            Return _Conflict
        End Get
        Set(ByVal value As Boolean)
            _Conflict = value
        End Set
    End Property
    Public Property Name() As [String]
        Get
            Return _Name
        End Get
        Set(ByVal value As [String])
            _Name = value
        End Set
    End Property
    Public Property ScheduledDate() As [String]
        Get
            Return _schDate
        End Get
        Set(ByVal value As String)
            _schDate = value
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

    Public Property DestinationTimeout() As [String]
        Get
            Return _DestinationTimeout
        End Get
        Set(ByVal value As String)
            _DestinationTimeout = value
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



    Private _conflictType As String
    Public Property ConflictType() As [String]
        Get
            Return _conflictType
        End Get
        Set(ByVal value As String)
            _conflictType = value
        End Set
    End Property
    Public Sub New()
    End Sub 'New

  

    Public Sub New(ByVal Name As [String], ByVal DestinationClinician As String, ByVal ScheduledDate As String, ByVal DestinationTimeIn As [String], ByVal DestinationTimeout As String, ByVal Conflict As Boolean, ByVal conflictType As String)
        Me.Name = Name
        Me.D_Clinician = DestinationClinician
        Me.ScheduledDate = ScheduledDate
        Me.DestinationTimeIn = DestinationTimeIn
        Me.DestinationTimeout = DestinationTimeout
        Me.Conflict = Conflict
        Me.ConflictType = conflictType

    End Sub
End Class

