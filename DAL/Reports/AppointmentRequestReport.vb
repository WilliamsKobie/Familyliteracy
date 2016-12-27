
Imports System.Configuration
Imports System.Data.SqlClient
Namespace DAL.Appointments
    Public Class AppointmentRequestReport : Implements IAppointmentDetailsReport
        Private _connection As String
      

        Public Function LocateAppointmentDetails(Of T)(searchParameter As T) As IEnumerable Implements IAppointmentDetailsReport.LocateAppointmentDetails
            _connection = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
            Dim dateRange As IDictionary(Of String, String) = searchParameter
            Dim studentRequestDetailsCache As New List(Of ExcelAppointmentsCache)
            Dim studentRequestDetails As New List(Of ScheduleRequestDetailCollection)

            Dim startDate As DateTime = Convert.ToDateTime(dateRange("START_DATE"))
            Dim endDate As DateTime = Convert.ToDateTime(dateRange("STOP_DATE"))
            Dim firstName, lastName, whenAppointmentWasSet, howAppointmentWasSet, appointmentDate As String
            Dim numberofAppointments As Int32
            Dim studentId As Int32
            Dim duplicate As Integer = 0
            Dim query As String = "SELECT [Date],MainSchedule.Studentid, StudentProfile.[First Name],StudentProfile.[Last Name],MainSchedule.RequestedDate, MainSchedule.RequestedFashion " & _
                                  "FROM [FamilyLiteracy.mdf].[dbo].StudentProfile INNER JOIN " & _
                                  "[FamilyLiteracy.mdf].[dbo].[MainSchedule] ON [FamilyLiteracy.mdf].dbo.StudentProfile.StudentID = MainSchedule.Studentid " & _
                                  "WHERE (MainSchedule.Date BETWEEN '" & startDate & "' AND '" & endDate & "') " & _
                                  "ORDER BY StudentProfile.[Last Name], StudentProfile.[First Name]"

            Dim conn As New SqlConnection(_connection)
            Dim cmd As New SqlCommand(query, conn)
            conn.Open()
            Dim reader = cmd.ExecuteReader()
            Do While (reader.Read())
                numberofAppointments = 0
                appointmentDate = reader.GetDateTime(0)
                studentId = reader.GetInt32(1)
                firstName = reader.GetString(2)
                lastName = reader.GetString(3)
                whenAppointmentWasSet = reader.GetDateTime(4).ToString("M/dd/yyyy")
                howAppointmentWasSet = reader.GetString(5).Trim()
                studentRequestDetails.Add(New ScheduleRequestDetailCollection(numberofAppointments, studentId, firstName, lastName, whenAppointmentWasSet, howAppointmentWasSet, appointmentDate))
            Loop
            conn.Close()
            Return studentRequestDetails
        End Function
    End Class
End Namespace
