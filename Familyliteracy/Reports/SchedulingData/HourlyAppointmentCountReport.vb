Imports DAL
Imports DAL.DAL.Appointments
Imports System.Text

Public Class HourlyAppointmentCountReport

    Private Sub HourlyAppointmentCountReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function ExecuteReport(ByVal requestResults As IEnumerable(Of ScheduleRequestDetailCollection))

        Dim appointmentsList As New List(Of StudentAppointmentCount)

        ExportSchedule.Focus()
      
        
     
        Me.Focus()
        Dim studentRequest = From student In requestResults
               Order By student.LastName, student.FirstName, student.AppointmentDate
               Group By studentIdNumber = student.StudentNumber, studentLastName = student.LastName
               Into hours = Group, Count()
               Order By studentLastName

        For Each appointment In studentRequest


            For Each appointmentTally In appointment.hours
                Dim fullname As New StringBuilder
                fullname.Append(appointmentTally.LastName).Append(", " & appointmentTally.FirstName)
                appointmentsList.Add(New StudentAppointmentCount(fullname.ToString(), appointment.Count))


                Exit For
            Next

        Next


        StudentAppointmentCountBindingSource.DataSource = appointmentsList
        Me.ReportViewer1.RefreshReport()
        Return Nothing
    End Function
End Class

Public Class StudentAppointmentCount
    Public Sub New(ByVal _name As String, ByVal _tally As String)
        StudentName = _name
        AppointmentTally = _tally
    End Sub

    Public Property StudentName As String
    Public Property AppointmentTally As String
End Class