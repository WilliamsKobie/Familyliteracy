Imports BAL
Imports DAL
Imports DAL.DAL.Appointments
Imports System.Text

Public Class ExportSchedule
    Private startDate As DateTime
    Private endDate As DateTime
    Private Sub ExportSchedule_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Dim startDate, endDate As DateTime
        startDate = DateTimePicker1.Value
        endDate = DateTimePicker2.Value
        DisplayStudentSchedules(startDate, endDate)

    End Sub
    'Clear and Populate Display
    Public Sub DisplayStudentSchedules(ByVal startDate As Date, ByVal endDate As Date)
        Try

            Dim requestResults As IEnumerable(Of ScheduleRequestDetailCollection)

            Dim getScheduleListing As IDisplaySchedule = New ReschedulingDisplay
            Dim ds As New DataTable

            'Clear display
            startDate = DateTimePicker1.Value
            dt = getScheduleListing.ReturnOfficeSchedule(startDate, endDate)
            dt.Columns.Remove("Prior Date")
            dt.Columns.Remove("Excuse")
            dt.Columns.Remove("TransferId")
            dt.Columns.Remove("State")
            dt.Columns.Remove("Callin date")
            dt.Columns.Remove("MeansofRequest")
            dt.Columns.Remove("Campus")
            dt.Columns.Remove("Attendance")
            dt.Columns.Remove("OriginalTransferDate")
            dt.Columns.Remove("Column1")

            'Populate GridView Control
            DataGridView1.DataSource = dt

            'Display and Populate Request Details 

            Dim dateParameters As New Dictionary(Of String, String)
            dateParameters.Add("START_DATE", startDate)
            dateParameters.Add("STOP_DATE", endDate)
            Dim GetAppointRequestDetails As IAppointmentDetailsReport = Nothing
            GetAppointRequestDetails = New AppointmentRequestReport()
            requestResults = GetAppointRequestDetails.LocateAppointmentDetails(dateParameters)


        

           
            LstView_AppointmentRequestDetails.Clear()
            LstView_AppointmentTally.Clear()
            LstView_AppointmentRequestDetails.View = View.Details
            LstView_AppointmentRequestDetails.GridLines = True
            LstView_AppointmentRequestDetails.FullRowSelect = True
            LstView_AppointmentRequestDetails.Columns.Add("Student", 175, HorizontalAlignment.Center)
            LstView_AppointmentRequestDetails.Columns.Add("Date Hour Changed", 110, HorizontalAlignment.Center)
            LstView_AppointmentRequestDetails.Columns.Add("Change Requested By", 140, HorizontalAlignment.Center)


            LstView_AppointmentTally.View = View.Details
            LstView_AppointmentTally.GridLines = True
            LstView_AppointmentTally.FullRowSelect = True
            LstView_AppointmentTally.Columns.Add("Student", 175, HorizontalAlignment.Center)
            LstView_AppointmentTally.Columns.Add("Appt. Hours", 75, HorizontalAlignment.Center)
           
            For Each student In requestResults
                Dim i As ListViewItem
                LstView_AppointmentRequestDetails.BeginUpdate()
                Dim fullname As New StringBuilder
                fullname.Append(student.LastName).Append(", " & student.FirstName)
                i = LstView_AppointmentRequestDetails.Items.Add(fullname.ToString())
                i.SubItems.Add(student.RequestDate)
                i.SubItems.Add(student.MeansofRequest)
                LstView_AppointmentRequestDetails.Update()
                LstView_AppointmentRequestDetails.EndUpdate()
            Next

            

            Dim studentRequest = From student In requestResults
                    Order By student.LastName, student.FirstName, student.AppointmentDate
                    Group By studentIdNumber = student.StudentNumber, studentLastName = student.LastName
                    Into hours = Group, Count()
                    Order By studentLastName

            For Each appointment In studentRequest
                Dim i As ListViewItem

                LstView_AppointmentTally.BeginUpdate()
                Dim fullname As New StringBuilder
                For Each appointmentTally In appointment.hours

                    fullname.Append(appointmentTally.LastName).Append(", " & appointmentTally.FirstName)
                    i = LstView_AppointmentTally.Items.Add(fullname.ToString())
                    i.SubItems.Add(appointment.Count)
                   
                    Exit For
                Next
                LstView_AppointmentTally.Update()
                LstView_AppointmentTally.EndUpdate()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Move forward or backwards a month
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim startDate, endDate As DateTime
        DateTimePicker2.Value = DateTimePicker1.Value
        startDate = DateTimePicker1.Value
        endDate = DateTimePicker1.Value
        DisplayStudentSchedules(startDate, endDate)
    End Sub
    'Export schedule to Full Schedule
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim dateStamps As New Dictionary(Of String, String)
        startDate = DateTimePicker1.Value
        endDate = DateTimePicker2.Value
        dateStamps.Add("START_DATE", startDate)
        dateStamps.Add("STOP_DATE", endDate)
      
        StudentAppointments.Show()
        StudentAppointments.ExecuteReport(dateStamps)

    End Sub


    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        DisplayStudentSchedules(DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportScheduleRequestDetails()
    End Sub
    Public Function ExportScheduleRequestDetails()
        ExportAppointmentHourly()
        Return Nothing
    End Function
    Public Function ExportAppointmentHourly()
        endDate = startDate
        startDate = DateTimePicker1.Value.ToShortDateString
        endDate = DateTimePicker2.Value.ToShortDateString
        Dim requestResults As IEnumerable(Of ScheduleRequestDetailCollection)
        Dim dateParameters As New Dictionary(Of String, String)
        dateParameters.Add("START_DATE", startDate)
        dateParameters.Add("STOP_DATE", endDate)
        Dim GetAppointRequestDetails As IAppointmentDetailsReport = Nothing
        GetAppointRequestDetails = New AppointmentRequestReport()
        requestResults = GetAppointRequestDetails.LocateAppointmentDetails(dateParameters)
        ReportAppointRequestDetails.Show()
        ReportAppointRequestDetails.ExecuteReport(requestResults)

        Return Nothing
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        endDate = startDate
        startDate = DateTimePicker1.Value.ToShortDateString
        endDate = DateTimePicker2.Value.ToShortDateString
        Dim requestResults As IEnumerable(Of ScheduleRequestDetailCollection)
        Dim dateParameters As New Dictionary(Of String, String)
        dateParameters.Add("START_DATE", startDate)
        dateParameters.Add("STOP_DATE", endDate)
        Dim GetAppointRequestDetails As IAppointmentDetailsReport = Nothing
        GetAppointRequestDetails = New AppointmentRequestReport()
        requestResults = GetAppointRequestDetails.LocateAppointmentDetails(dateParameters)

        HourlyAppointmentCountReport.Show()
        HourlyAppointmentCountReport.ExecuteReport(requestResults)

       
    End Sub
End Class