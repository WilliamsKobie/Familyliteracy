
Imports System.Configuration
Imports System.Data.SqlClient
Public Class MainSchedule : Implements IMainSchedule
    Private _connection As String
    Public Function Capture(ByVal timeStamp As Dictionary(Of String, String)) As IEnumerable Implements IMainSchedule.Capture
        Dim Schedule As New List(Of StudentSchedule)

        Dim startDate As String = timeStamp("START_DATE")
        Dim stopDate As String = timeStamp("STOP_DATE")
        _connection = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        Dim query As String = "SELECT dbo.MainSchedule.Studentid, dbo.StudentProfile.[First Name], dbo.StudentProfile.[Last Name], dbo.MainSchedule.Date, dbo.MainSchedule.TimeIn, dbo.MainSchedule.Timeout, dbo.MainSchedule.ClinicianSignature " & _
        "FROM dbo.MainSchedule " & _
        "INNER JOIN dbo.StudentProfile ON dbo.MainSchedule.Studentid = dbo.StudentProfile.StudentID " & _
        "WHERE [Date] BETWEEN '" & startDate & "' AND '" & stopDate & "' ORDER BY [Last Name] ASC"


        Dim conn As New SqlConnection(_connection)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim reader = cmd.ExecuteReader
        Do While (reader.Read)
            Dim firstname As String = reader.GetString(1)
            Dim lastname As String = reader.GetString(2)
            Dim dateStamp As String = reader.GetDateTime(3).ToShortDateString
            Dim timeInStamp As String = reader.GetDateTime(4).ToShortTimeString()
            Dim timeOutStamp As String = reader.GetDateTime(5).ToShortTimeString()
            Dim assignedClinician As String = reader.GetString(6)
            Dim fullName As String = lastname & ", " & firstname
            Schedule.Add(New StudentSchedule(fullName, firstname, lastname, dateStamp, timeInStamp, timeOutStamp, assignedClinician))
        Loop
        Return Schedule
    End Function

End Class

Public Class StudentSchedule
    Public Sub New(ByVal _student As String, ByVal _firstName As String, ByVal _lastName As String, ByVal _date As String, ByVal _startTime As String, ByVal _stopTime As String, ByVal _assignedClinician As String)
        Student = _student
        FirstName = _firstName
        LastName = _lastName
        Date_Stamp = _date
        Start_Time = _startTime
        Stop_Time = _stopTime
        Assigned_Clinician = _assignedClinician
    End Sub

    Public Property Student As String
    Public Property FirstName As String

    Public Property LastName As String
    Public Property Date_Stamp As Object

    Public Property Start_Time As String

    Public Property Stop_Time As Object

    Public Property Assigned_Clinician As String

  

End Class
