Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Data.OleDb
'This class returns the schedule of a student,clincian or multiple students and clinicians based on the given parameters being passed to it
Public Class Schedule
    Dim connectionString As Object
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As SqlException
            MsgBox("Cannot connect to Data the Database", , "Database Connection Status")
        End Try
    End Sub
  

    Public Overloads Function GetSchedule(ByVal startDate As Date, ByVal finalDate As Date) As DataSet

        Dim query As String = "SELECT * FROM MainSchedule where [Date] Between '" & startDate & "' AND '" & finalDate & "' Order By Date, TimeIn ASC"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()


        Dim dt As DataTable = ds.Tables("MainSchedule")

        Return ds
    End Function
    Public Overloads Function MainDisplaySchedule() As String

        Dim transId As String = String.Empty
        Dim query As String = "SELECT TOP 1 * FROM MainSchedule  Order By count Desc"

        Dim conn As New SqlConnection(connectionString)

        Dim cmd As New SqlCommand(query, conn)


        Dim da As New SqlDataAdapter(cmd)

        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")

        conn.Close()
        Dim row As DataRow

        Dim dt As DataTable = ds.Tables("MainSchedule")

        For Each row In dt.Rows
            transId = Convert.ToInt32(row("key"))

        Next

        Return transId


    End Function


    Public Overloads Function ReturnStudentScheduleinfo(ByVal studentid As String) As DataSet

        Dim index As Integer
        index = Convert.ToInt16(Studentid)

        Dim query As String = "SELECT * FROM MainSchedule where StudentID='" & index & "' ORDER BY [DATE] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()


        Return ds

    End Function
    Public Overloads Function ReturnStudentScheduleInfo(ByVal appointment As String, ByVal time1 As String, ByVal time2 As String) As DataSet


        Dim appoint As Date
        Dim timestamp1 As DateTime
        Dim timestamp2 As DateTime
        appoint = Convert.ToDateTime(appointment.Trim)
        timestamp1 = Convert.ToDateTime("1900-01-01 " & time1)
        timestamp2 = Convert.ToDateTime("1900-01-01 " & time2)
        Dim query As String = "SELECT * FROM MainSchedule where [Date]='" & appoint & "' Timein='" & timestamp1 & "' AND Timeout='" & timestamp2 & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()


        Return ds

    End Function
    Public Overloads Function ReturnStudentSchedule(ByVal studentid As String, ByVal appointment As String) As DataSet

        Dim index As Integer
        index = Convert.ToInt16(studentid)
        Dim appoint As Date

        appoint = Convert.ToDateTime(appointment.Trim)

        Dim query As String = "SELECT * FROM MainSchedule where studentid='" & index & "' AND [Date]='" & appoint & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()


        Return ds

    End Function



    Public Overloads Function ReturnStudentScheduleInfo(ByVal studentid As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet


        Dim studentNumber As Integer = Convert.ToInt16(studentid)
        Dim query As String = "SELECT * FROM MainSchedule where [Date] Between '" & StartDate & "' And '" & EndDate & "' And Studentid='" & studentNumber & "' Order By [Date] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()

        Return ds

    End Function
    Public Function ReturnProposedSchedule(ByVal studentid As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal state As String) As DataTable
        Dim index As Integer
        index = Convert.ToInt16(studentid)

        Dim query As String = "SELECT * FROM MainSchedule where [Date] Between '" & StartDate & "' And '" & EndDate & "' And Studentid='" & index & "' AND Status='" & state & "' Order By [Date] DESC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("MainSchedule")
        Return dt

    End Function

    Public Overloads Function ReturnStudentScheduleInfo(ByVal studentid As String, ByVal startDate As Date, ByVal startTime As DateTime, ByVal endTime As DateTime) As DataSet


        Dim studentNumber As Integer = Convert.ToInt16(studentid)
        Dim query As String = "SELECT * FROM MainSchedule where [Date]='" & startDate & "' And Studentid='" & studentNumber & "' AND TimeIn='" & startTime & "' AND TimeOut='" & endTime & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()
        Return ds

    End Function


    Public Overloads Function ReturnClinicianScheduleInfo(ByVal initialScheduleDate As Date, ByVal finalScheduleDate As Date, ByVal clincianId As String) As DataTable


        Dim query As String = "SELECT * FROM MainSchedule where [Date] Between'" & initialScheduleDate & "' AND '" & finalScheduleDate & "' AND ClinicianID='" & clincianId & "' Order By Clinicianid ASC, [Date] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("MainSchedule")

        Return dt

    End Function


    Public Overloads Function ViewSchedule(ByVal Clinician As String, ByVal Date1 As Date, ByVal Date2 As Date) As DataSet

        Dim query As String = "SELECT * FROM MainSchedule WHERE [DATE] BETWEEN '" & Date1 & "' AND '" & Date2 & "' AND ClinicianID='" & Clinician & "' ORDER BY [Date] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()

        Dim dt As DataTable = ds.Tables("MainSchedule")

        Return ds
    End Function
    Public Overloads Function ViewSchedule(ByVal Clinician As String) As DataSet

        Dim query As String = "SELECT * FROM MainSchedule WHERE ClinicianID='" & Clinician & "' ORDER BY [Date] ASC, TimeIn ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()

        Dim dt As DataTable = ds.Tables("MainSchedule")
        Return ds
    End Function


    Public Function GetClassroomData(ByVal transid As String) As DataSet
        Dim query As String = "SELECT * FROM Classroom WHERE Transactionid='" & transid.Trim & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet

        conn.Open()
        da.Fill(ds, "Classroom")
        conn.Close()

        Return ds
    End Function

End Class
Public Interface IstudentAppointmentRemover
    Function Remove(Of T)(values As Dictionary(Of String, String)) As Integer
End Interface
Public Interface IstudentAppointmentInserter
    Function Insert(Of T)(values As Dictionary(Of String, String)) As Integer
End Interface
Public Interface IstudentAppointmentCount
    Function Locate(Of T)(values As Dictionary(Of String, String)) As Integer
End Interface
Public Class StudentScheduleInserter : Implements IstudentAppointmentInserter
    Dim connectionString As String
    Public Function Insert(Of T)(values As Dictionary(Of String, String)) As Integer Implements IstudentAppointmentInserter.Insert
        Dim ProposedAppointment As New Dictionary(Of String, String)
        ProposedAppointment = values
        Dim studentID As String = ProposedAppointment("STUDENT_ID")
        Dim appointmentDate As String = ProposedAppointment("DATE")
        Dim appointmentStartTime As String = ProposedAppointment("START_TIME")
        Dim appointmentFinalTime As String = ProposedAppointment("FINAL_TIME")
        Dim clinicianID As String = ProposedAppointment("CLINICIAN_ID")
        Dim clinicianFullName As String = ProposedAppointment("CLINICIAN_FULLNAME")
        Dim studentStatus As String = ProposedAppointment("STUDENT_STATUS")
        Dim dateofRequestedAppointment As String = ProposedAppointment("DATE_OF APPOINTMENT_REQUEST")
        Dim requestType As String = ProposedAppointment("REQUESTED_MEANS")

        Dim appointmentEntryPersonal As String = ProposedAppointment("DATA_ENTRY_PERSON")

        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "INSERT INTO MAINSCHEDULE (StudentID,[Date],TimeIn,TimeOut,ClinicianID,ClinicianSignature,Status,RequestedDate,RequestedFashion,ProcessingClinician,Attendance) Values(@studentNumber,@scheduledDate,@scheduledStartTime,@scheduledEndTime,@scheduledClincianID,@scheduledClinicianName,@studentStatus,@dateOfAppointmentRequest,@requestedType,@dataEntryClinician,@attendance); SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        cmd.Parameters.AddWithValue("@studentNumber", studentID)
        cmd.Parameters.AddWithValue("@scheduledDate", appointmentDate)
        cmd.Parameters.AddWithValue("@scheduledStartTime", appointmentStartTime)
        cmd.Parameters.AddWithValue("@scheduledEndTime", appointmentFinalTime)
        cmd.Parameters.AddWithValue("@scheduledClincianID", clinicianID)
        cmd.Parameters.AddWithValue("@scheduledClinicianName", clinicianFullName)
        cmd.Parameters.AddWithValue("@studentStatus", studentStatus)
        cmd.Parameters.AddWithValue("@dateOfAppointmentRequest", dateofRequestedAppointment)
        cmd.Parameters.AddWithValue("@requestedType", requestType)

        cmd.Parameters.AddWithValue("@dataEntryClinician", appointmentEntryPersonal)
        cmd.Parameters.AddWithValue("@Attendance", "Proposed")
        conn.Open()
        Dim scope As Integer = cmd.ExecuteScalar()
        conn.Close()
        Return scope

    End Function
End Class
Public Class StudentAppointedCampus : Implements IstudentAppointmentInserter
    Dim connectionString As String
    Public Function Insert(Of T)(values As Dictionary(Of String, String)) As Integer Implements IstudentAppointmentInserter.Insert
        Dim ProposedAppointment As New Dictionary(Of String, String)
        ProposedAppointment = values

        Dim appointmentIndex As String = ProposedAppointment("APPOINTMENT_INDEX")
        Dim studentID As String = ProposedAppointment("STUDENT_ID")

        Dim campus As String = ProposedAppointment("CAMPUS")
        Dim subjectStudied As String = ProposedAppointment("STUDIED_SUBJECT")

        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "INSERT INTO CLASSROOM (TransactionID,StudentID,Campus,Subject) Values(@ScheduledCampusIndex,@studentNumber,@campus,@subjectOfStudy)"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@ScheduledCampusIndex", appointmentIndex)
        cmd.Parameters.AddWithValue("@studentNumber", studentID)
        cmd.Parameters.AddWithValue("@campus", campus)
        cmd.Parameters.AddWithValue("@subjectOfStudy", subjectStudied)


        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
        Return Nothing

    End Function
End Class
Public Class StudentAppointmentCount : Implements IstudentAppointmentCount
    Dim connectionString As String
    Function Locate(Of T)(values As Dictionary(Of String, String)) As Integer Implements IstudentAppointmentCount.Locate
        Dim StudentProposedAppointment As New Dictionary(Of String, String)
        StudentProposedAppointment = values
        Dim studentNumber As String = StudentProposedAppointment("STUDENT_ID")
        Dim appointmentDate As String = StudentProposedAppointment("DATE")
        Dim appointmentStartTime As String = StudentProposedAppointment("START_TIME")
        Dim appointmentFinalTime As String = StudentProposedAppointment("FINAL_TIME")

        connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim query As String = "SELECT Count(*) FROM MainSchedule Where StudentID='" & studentNumber & "' AND [Date]='" & appointmentDate & "' AND TimeIn='" & appointmentStartTime & "' AND TimeOut='" & appointmentFinalTime & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim count As Integer = cmd.ExecuteScalar
        conn.Close()
        Return count
    End Function
End Class

Public Class AppointmentRemover : Implements IstudentAppointmentRemover
    Dim connectionString As String
    Public Function Remove(Of T)(values As Dictionary(Of String, String)) As Integer Implements IstudentAppointmentRemover.Remove
        Dim Appointments As New Dictionary(Of String, String)
        Appointments = values
        Dim studentId As String = Appointments("STUDENT_ID")
        Dim startTime As String = Appointments("START_TIME")
        Dim finalTime As String = Appointments("END_TIME")
        Dim appointedDate As String = Appointments("APPOINTMENT_DATE")
        Dim appointedClinician As String = Appointments("CLINICIAN_ID")
        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "DELETE * FROM MAINSCHEDULE Where StudentID='" & studentId & "' AND [Date]='" & appointedDate & "' AND TimeIn='" & startTime & "' AND TimeOut='" & finalTime & "' SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        Dim appointmentIndex = cmd.ExecuteScalar()
        conn.Close()
        Return appointmentIndex
    End Function
End Class
Public Class AppointedCampusRemover : Implements IstudentAppointmentRemover
    Dim connectionString As String
    Public Function Remove(Of T)(values As Dictionary(Of String, String)) As Integer Implements IstudentAppointmentRemover.Remove
        Dim Appointments As New Dictionary(Of String, String)
        Appointments = values
        Dim appointmentIndex As String = Appointments("APPOINTMENT_INDEX")

        connectionString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "DELETE * FROM CLASSROOM WHERE TransactionID='" & appointmentIndex
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        conn.Open()
        cmd.ExecuteScalar()
        conn.Close()
        Return Nothing
    End Function
End Class

'This class is called when user data needs to modified, added or deleted from the database.
Public Class CommitChanges
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As SqlException
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub
    Public Function EditDailySchedule(ByVal index As String, ByVal Studentid As String, ByVal Clinicianid As String, ByVal ClinicianName As String, ByVal adjustedDate As String, ByVal timein As String, ByVal timeout As String, ByVal OldTimeIn As String, ByVal OldTimeOut As String, ByVal Location As String, ByVal Subject As String)

        Dim t1 As String
        Dim t2 As String
        Dim t3 As String
        Dim t4 As String

        Dim time1 As DateTime
        Dim time2 As DateTime
        Dim time3 As DateTime
        Dim time4 As DateTime
        Dim datestamp As Date
        datestamp = Convert.ToDateTime(adjustedDate)
        t1 = "1900-01-01 " & OldTimeIn.Trim
        t2 = "1900-01-01 " & OldTimeOut.Trim
        time1 = Convert.ToDateTime(t1) 'convert start time to Datetime Datatype
        time2 = Convert.ToDateTime(t2) 'convert stop time to Datetime Datatype
        t3 = "1900-01-01 " & timein.Trim
        t4 = "1900-01-01 " & timeout.Trim
        time3 = Convert.ToDateTime(t3) 'convert start time to Datetime Datatype
        time4 = Convert.ToDateTime(t4) 'convert stop time to Datetime Datatype
        Dim studentIndex As Integer
        studentIndex = Convert.ToInt16(Studentid)

        Dim query As String = "SELECT * FROM MainSchedule Where StudentID='" & studentIndex & "' AND [Date]='" & datestamp & "' AND [Key]=" & index

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim cmd3 As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet

        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("MainSchedule")
        Dim dr As DataRow
        Dim dr3 As DataRow
        Dim returnstate As String = String.Empty
        Dim itimein As DateTime
        Dim status As String = String.Empty
        Dim Meansofrequest As String = String.Empty
        Dim processor As String = String.Empty
        Dim CallinDate As String = String.Empty
        Dim ts As TimeSpan
        Dim totalhours As Integer = 0

        For Each dr In dt.Rows
            returnstate = dr("Status")

            status = dr("Status")
            Meansofrequest = dr("RequestedFashion")
            processor = dr("ProcessingClinician")
            CallinDate = dr("RequestedDate")
            itimein = time2.AddHours(-1)
            ts = (time2 - time1)
            totalhours = Math.Abs(ts.TotalHours)

            If totalhours <= 1 Then
                dr.BeginEdit()
                dr("TimeIn") = time3
                dr("TimeOut") = time4
                dr("Clinicianid") = Clinicianid
                dr("ClinicianSignature") = ClinicianName
                dr.EndEdit()
                Dim objCommandBuilder As New SqlCommandBuilder(da)
                da.Update(ds, "MainSchedule")
                SubmitClassroomData(index.ToString, Location, Subject)
                Exit For
            Else
                dr.BeginEdit()
                dr("TimeIn") = itimein
                dr("TimeOut") = time2
                dr.EndEdit()
                Dim objCommandBuilder As New SqlCommandBuilder(da)
                da.Update(ds, "MainSchedule")



                Dim da3 As New SqlDataAdapter(cmd3)
                Dim ds3 As New DataSet

                conn.Open()
                da3.Fill(ds3, "MainSchedule")
                conn.Close()
                Dim dt3 As DataTable = ds3.Tables("MainSchedule")
                dr3 = dt3.NewRow
                dr3("Status") = status
                dr3("RequestedFashion") = Meansofrequest
                dr3("ProcessingClinician") = processor
                dr3("RequestedDate") = CallinDate
                dr3("Studentid") = Studentid
                dr3("TimeIn") = time3
                dr3("TimeOut") = time4
                dr3("Date") = datestamp
                dr3("Clinicianid") = Clinicianid.Trim
                dr3("ClinicianSignature") = ClinicianName.Trim
                dt3.Rows.Add(dr3)
                Dim objCommandBuilder3 As New SqlCommandBuilder(da3)
                da3.Update(ds3, "MainSchedule")

                Exit For
            End If


        Next

        Return Nothing
    End Function

    Public Function SubmitClassroomData(ByVal Transactionid As String, ByVal Location As String, ByVal Subject As String)


        Dim query As String = "SELECT * FROM Classroom Where Transactionid='" & Transactionid & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet

        conn.Open()
        da.Fill(ds, "Classroom")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Classroom")

        Dim dr As DataRow
        Dim x As Integer = dt.Rows.Count
        If x < 1 Then

            dr = dt.NewRow()
            dr("TransactionId") = Transactionid
            dr("Campus") = Location
            dr("Subject") = Subject

            dt.Rows.Add(dr)

            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "Classroom")
        End If
        Return Nothing
    End Function
  

    Public Function RemoveClinicianOffDays(ByVal clinicianid As String, ByVal StartTime As String, ByVal EndTime As String, ByVal datestamp As Date)

        Dim t1 As String
        Dim t2 As String
        Dim time1 As DateTime
        Dim time2 As DateTime

        t1 = "1900-01-01 " & StartTime.Trim

        t2 = "1900-01-01 " & EndTime.Trim
        time1 = Convert.ToDateTime(t1) 'convert start time to Datetime Datatype
        time2 = Convert.ToDateTime(t2) 'convert stop time to Datetime Datatype


        Dim query As String = "SELECT * FROM Clinician_DailyOutSchedule Where ClinicianID='" & clinicianid.Trim & "'" & " AND [Date]='" & datestamp & "' AND TimeIn='" & time1 & "' AND TimeOut='" & time2 & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician_DailyOutSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician_DailyOutSchedule")
        Dim dr As DataRow
        Dim r As Integer = dt.Rows.Count
        For Each dr In dt.Rows
            dr.Delete()
        Next
        Dim objCommandBuilder2 As New SqlCommandBuilder(da)
        da.Update(ds, "Clinician_DailyOutSchedule")
        Return Nothing
    End Function

End Class





'This class is used to store values any of the datagrid column sizes. 
'Returns the column width value that is store in the database
Public Class StoreGridViewColumnWidth
    Dim connectionString As String
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub
    Public Function ReturnColumnWidth(ByVal screen As Integer, ByVal gridViewControl As Integer) As Integer

        Dim query As String = "SELECT * FROM GridViewColumnSizeAdjustment Where FormReferenceNumber='" & screen & "' AND GridViewControlNumber='" & gridViewControl & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GridViewColumnSizeAdjustment")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GridViewColumnSizeAdjustment")

        Dim rw As DataRow

        Dim columnSize As Integer = 20

        For Each rw In dt.Rows
            columnSize = rw("GridViewColumnSize")
        Next
        Return columnSize

    End Function

    Public Function SaveColumnWidth(ByVal screen As Integer, ByVal gridViewControl As Integer, ByVal columnWidth As Integer) As Integer

        Dim query As String = "SELECT * FROM GridViewColumnSizeAdjustment Where FormReferenceNumber='" & screen & "' AND GridViewControlNumber='" & gridViewControl & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GridViewColumnSizeAdjustment")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GridViewColumnSizeAdjustment")

        Dim rw As DataRow



        For Each rw In dt.Rows
            rw.BeginEdit()
            rw("GridViewColumnSize") = columnWidth
            rw.EndEdit()
        Next

        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "GridViewColumnSizeAdjustment")
        Return columnWidth

    End Function
End Class

'Stores the path of a Calendar
'Returns the path location of a Calendar
'Makes use of Factory Design Pattern
Public Interface IfileStoragePath
    Function Path(newPath As String, newModule As String) As String

End Interface

Public Class saveStorageModules
    Implements IfileStoragePath
    Public Function Path(newPath As String, scheduleType As String) As String Implements IfileStoragePath.Path

        Dim selectedModule As IStorageModule = Nothing

        Select Case (scheduleType)
            Case "student"
                selectedModule = New storeStudentScheduleFilePath
                selectedModule.storeFilePath(newPath.Trim())
                Exit Select
            Case "office"
                selectedModule = New storeOfficeScheduleFilePath
                selectedModule.storeFilePath(newPath.Trim())
                Exit Select
            Case Else

                Exit Select
        End Select

        Return newPath
    End Function
End Class
Public Class returnStorageModules
    Implements IfileStoragePath
    Public Function path(newPath As String, scheduleType As String) As String Implements IfileStoragePath.Path
        Dim selectedModule As IreturnStorageModule = Nothing
        Dim defaultLocation As String = String.Empty
        Select Case (scheduleType)
            Case "student"
                selectedModule = New StudentCalendarFilelocation
                defaultLocation = selectedModule.locateFilePath(newPath.Trim())
                Exit Select
            Case "office"
                selectedModule = New OfficeCalendarFilelocation
                defaultLocation = selectedModule.locateFilePath(newPath.Trim())
                Exit Select
            Case Else

                Exit Select
        End Select

        Return defaultLocation
    End Function
End Class
Public Interface IStorageModule
    Function StoreFilePath(path As String)

End Interface

Public Interface IreturnStorageModule
    Function LocateFilePath(path As String) As String
End Interface

Class storeStudentScheduleFilePath
    Implements IstorageModule
    Dim connectionString As Object
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub
    Function StoreFilePath(path As String) Implements IStorageModule.storeFilePath
        Dim query As String = "Update DefaultScheduleFileLocations SET [Student_Schedule_Location]=@storagePath,[StorageDate]=@storageDate"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)


        cmd.Parameters.AddWithValue("@storagePath", path)
        cmd.Parameters.AddWithValue("@storageDate", Now)

        Dim updated As Integer = 0
        conn.Open()
        updated = cmd.ExecuteNonQuery()
        conn.Close()

        Return Nothing
    End Function
End Class

Public Class storeOfficeScheduleFilePath
    Implements IstorageModule
    Dim connectionString As Object
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub
    Function StoreFilePath(path As String) Implements IstorageModule.storeFilePath
        Dim query As String = "Update DefaultScheduleFileLocations SET [Office_Schedule_Location]=@storagePath,[StorageDate]=@storageDate"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)


        cmd.Parameters.AddWithValue("@storagePath", path)
        cmd.Parameters.AddWithValue("@storageDate", Now)

        Dim updated As Integer = 0
        conn.Open()
        updated = cmd.ExecuteNonQuery()
        conn.Close()

        Return Nothing
    End Function

End Class

Public Class StudentCalendarFilelocation
    Implements IreturnStorageModule
    Dim connectionString As Object
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub

    Function LocateFilePath(path As String) As String Implements IreturnStorageModule.locateFilePath
        Dim query As String = "SELECT * FROM DefaultScheduleFileLocations "
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "DefaultScheduleFileLocations")
        conn.Close()
        Dim dt As DataTable = ds.Tables("DefaultScheduleFileLocations")

        Dim rw As DataRow

        Dim defaultPath As String = String.Empty

        For Each rw In dt.Rows
            defaultPath = rw("Student_Schedule_Location")
        Next

        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "DefaultScheduleFileLocations")


        Return defaultPath
    End Function


End Class


Public Class OfficeCalendarFilelocation
    Implements IreturnStorageModule
    Dim connectionString As Object
    Public Sub New()
        Try

            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub

    Function LocateFilePath(path As String) As String Implements IreturnStorageModule.locateFilePath
        Dim query As String = "SELECT * FROM DefaultScheduleFileLocations"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "DefaultScheduleFileLocations")
        conn.Close()
        Dim dt As DataTable = ds.Tables("DefaultScheduleFileLocations")

        Dim rw As DataRow

        Dim defaultPath As String = String.Empty

        For Each rw In dt.Rows
            defaultPath = rw("Office_Schedule_Location")
        Next

        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "DefaultScheduleFileLocations")


        Return defaultPath
    End Function


End Class