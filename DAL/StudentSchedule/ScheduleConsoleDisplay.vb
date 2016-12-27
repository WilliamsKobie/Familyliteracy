Imports System.Data.SqlClient
Imports System.Configuration
Public Class AppointmentRetriever : Implements IappointmentRetriever
    Dim connectionString As String
    Public Function Retrieve(ByVal ScheduleRequestParameter As IDictionary(Of String, String)) As IEnumerable Implements IappointmentRetriever.Retrieve
        Dim StudentSchedule As New List(Of ScheduleConsoleDisplayCollection)
        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim studentId As Integer = ScheduleRequestParameter("STUDENT_ID")
        Dim startDate As Date = ScheduleRequestParameter("DATE_START")
        Dim stopDate As Date = ScheduleRequestParameter("DATE_STOP")


        Dim query As String = "SELECT [KEY],[StudentID],[Date],TimeIn,TimeOut,ClinicianSignature,Status,Processingclinician,RequestedFashion FROM MainSchedule WHERE [Date] Between '" & startDate & "' And '" & stopDate & "' And Studentid='" & studentId & "' Order By [Date] DESC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        conn.Open()
        Dim reader = cmd.ExecuteReader
        Do While (reader.Read)
            Dim appointmentIndex As String = reader.GetInt32(0).ToString
            Dim dateStamp As String = reader.GetDateTime(2).ToLongDateString
            Dim startTimeStamp As String = reader.GetDateTime(3).ToShortTimeString
            Dim stopTimeStamp As String = reader.GetDateTime(4).ToShortTimeString
            Dim assignedclinician As String = reader.GetString(5)
            Dim appointmentStatus As String = reader.GetString(6)

            Dim dataEntryClinician As String = reader.GetString(7)
            Dim appointmentRequestMedium As String = reader.GetString(8)
            StudentSchedule.Add(New ScheduleConsoleDisplayCollection(appointmentIndex, dateStamp, startTimeStamp, stopTimeStamp, assignedclinician.Trim(), appointmentStatus, dataEntryClinician.Trim(), appointmentRequestMedium.Trim()))
        Loop
        conn.Close()

        Return StudentSchedule

    End Function
End Class
Public Class CurrentNextMonthAppointmentRetriever : Implements IcurrentNextMonthAppointmentRetriever
    Dim connectionString As String

    Public Function Retrieve(ByVal ScheduleRequestParameter As IDictionary(Of String, String)) As IEnumerable Implements IcurrentNextMonthAppointmentRetriever.Retrieve
        Dim StudentSchedule As New List(Of ScheduleConsoleDisplayCollection)
        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim studentId As Integer = ScheduleRequestParameter("STUDENT_ID")
        Dim startDate As Date = ScheduleRequestParameter("DATE_START")
        Dim stopDate As Date = ScheduleRequestParameter("DATE_STOP")


        Dim query As String = "SELECT [KEY],[StudentID],[Date],TimeIn,TimeOut,ClinicianSignature,Status,Processingclinician,RequestedFashion FROM MainSchedule WHERE [Date] Between '" & startDate & "' And '" & stopDate & "' And Studentid='" & studentId & "' Order By [Date] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        conn.Open()
        Dim reader = cmd.ExecuteReader
        Do While (reader.Read)
            Dim appointmentIndex As String = reader.GetInt32(0).ToString
            Dim dateStamp As String = reader.GetDateTime(2).ToLongDateString
            Dim startTimeStamp As String = reader.GetDateTime(3).ToShortTimeString
            Dim stopTimeStamp As String = reader.GetDateTime(4).ToShortTimeString
            Dim assignedclinician As String = reader.GetString(5)
            Dim appointmentStatus As String = reader.GetString(6)

            Dim dataEntryClinician As String = reader.GetString(7)
            Dim appointmentRequestMedium As String = reader.GetString(8)
            StudentSchedule.Add(New ScheduleConsoleDisplayCollection(appointmentIndex, dateStamp, startTimeStamp, stopTimeStamp, assignedclinician.Trim(), appointmentStatus, dataEntryClinician.Trim(), appointmentRequestMedium.Trim()))
        Loop
        conn.Close()

        Return StudentSchedule

    End Function
End Class

Public Class ScheduleConsoleDisplayCollection
    Public Sub New(ByVal _appointmentIndex As String, ByVal _appointmentDate As String, ByVal _timeIn As String, ByVal _timeOut As String, ByVal _assignedClinician As String, ByVal _appointmentStatus As String, ByVal _dataEntryClinician As String, ByVal _appointmentRequestMedium As String)
        AppointmentKey = _appointmentIndex
        Appointment = _appointmentDate
        StartTime = _timeIn
        EndTime = _timeOut
        Status = _appointmentStatus
        Clinician = _assignedClinician
        Processor = _dataEntryClinician
        Medium = _appointmentRequestMedium

    End Sub
    Public Property AppointmentKey As String

    Public Property Appointment As String

    Public Property StartTime As String

    Public Property EndTime As String

    Public Property Status As String

    Public Property Clinician As String

    Public Property Processor As String

    Public Property Medium As String

End Class


Public Class ScheduleDisplayAppointmentRemover : Implements IScheduleDisplayAppointmentRemover

    Dim connectionString As String
    Public Function Delete(Of T)(value As T) Implements IScheduleDisplayAppointmentRemover.Delete

        Dim indicies As IEnumerable(Of Integer) = value

        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        Dim conn As New SqlConnection(connectionString)


        For collectionPointer = 0 To indicies.Count - 1
            Dim index As Integer = indicies(collectionPointer)
            Dim query As String = "DELETE FROM MainSchedule Where [Key]=" & index
            Dim cmd As New SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Next

        Return Nothing
    End Function
End Class

Public Class CampusAppointmentRemover : Implements IScheduleDisplayAppointmentRemover

    Dim connectionString As String
    Public Function Delete(Of T)(value As T) Implements IScheduleDisplayAppointmentRemover.Delete

        Dim indicies As IEnumerable(Of Integer) = value

        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        Dim conn As New SqlConnection(connectionString)
        For collectionPointer = 0 To indicies.Count - 1
            Dim index As Integer = indicies(collectionPointer)
            Dim query As String = "DELETE FROM CLASSROOM Where [TransactionID]=" & index
            Dim cmd As New SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        Next

        Return Nothing
    End Function
End Class
Public Class CampusDTO
    Public Function Download() As IEnumerable
        Dim DataObject As New List(Of CampusObject)
        Dim connString As String
        Dim query As String = "SELECT [KEY],[COUNT] FROM [DBO].MAINSCHEDULE"
        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim newKey As Integer
        Dim oldKey As Integer
        Dim reader = cmd.ExecuteReader

        Do While (reader.Read)

            If Not reader.IsDBNull(1) Then
                newKey = reader.GetInt32(0)
                oldKey = reader.GetInt32(1)
                DataObject.Add(New CampusObject(newKey, oldKey))
            End If

        Loop
        conn.Close()
        Return DataObject
    End Function

    Public Function Upload(Of T)(value As T)
        Dim DataObject As IEnumerable(Of CampusObject)
        DataObject = value
        Dim connString As String
        Dim query As String
        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
        For Each item In DataObject
            Dim conn As New SqlConnection(connString)
            query = "UPDATE Classroom SET NewTransactionID=" & item.NewTransactionID & " WHERE TransactionId=" & item.OldKey
            Dim cmd As New SqlCommand(query, conn)
            conn.Open()
            Dim reader = cmd.ExecuteNonQuery
            conn.Close()
        Next

        Return Nothing
    End Function
End Class
