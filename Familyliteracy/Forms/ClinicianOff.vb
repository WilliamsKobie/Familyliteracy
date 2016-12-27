
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports BAL
Imports DAL
Public Class ClinicianOff
    Dim clinicianConversion As INameConversion = New ClinicianNameConversion
    Dim intervals As IEvaluateDateTimeIntervals = New datetimeIntervalConversion
    Dim scheduleClinician As IscheduleClinican = New alterSchedule

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Capture user input for scheduling the selected clinician to be out/off
        Dim setupClinicians As New Clinicians
        Dim ClinicianProfile As New Schedule
        Dim dateintervals As New ArrayList
        Dim timeintervals As New ArrayList
        Dim conflicts As New List(Of AutoSelectConflicts)

        Dim Dayofweek() As String = {"unassigned", "unassigned", "unassigned", "unassigned", "unassigned", "unassigned", "unassigned"}
        If ComboBox1.SelectedValue = "" Then
            MsgBox("You must provide a Clinician!")
            Exit Sub
        ElseIf ComboBox2.SelectedItem = "" Then
            MsgBox("You must provide a Start Time!")
            Exit Sub
        ElseIf ComboBox3.SelectedItem = "" Then
            MsgBox("You must provide a Finish Time!")
            Exit Sub
        Else

            If Monday.Checked = True Then 'Mon
                Dayofweek(0) = "Monday"
            Else
                Dayofweek(0) = "Unassigned"
            End If
            If Tuesday.Checked = True Then 'Tues
                Dayofweek(1) = "Tuesday"
            Else
                Dayofweek(1) = "Unassigned"
            End If
            If Wednesday.Checked = True Then 'Wed
                Dayofweek(2) = "Wednesday"
            Else
                Dayofweek(2) = "Unassigned"
            End If
            If Thursday.Checked = True Then 'Thurs
                Dayofweek(3) = "Thursday"
            Else
                Dayofweek(3) = "Unassigned"
            End If
            If Friday.Checked = True Then 'Fri
                Dayofweek(4) = "Friday"
            Else
                Dayofweek(4) = "Unassigned"
            End If
            If Saturday.Checked = True Then  'Sat
                Dayofweek(5) = "Saturday"
            Else
                Dayofweek(5) = "Unassigned"
            End If
            If Sunday.Checked = True Then  'Sun
                Dayofweek(6) = "Sunday"
            Else
                Dayofweek(6) = "Unassigned"
            End If

            Dim date1, date2, t1, t2 As String
            date1 = DateTimePicker1.Value.ToString("M/dd/yyyy")
            date2 = DateTimePicker2.Value.ToString("M/dd/yyyy")
            t1 = ComboBox2.SelectedItem
            t2 = ComboBox3.SelectedItem
            Dim Clinicianname As String = ComboBox1.SelectedValue
            Dim dy1, dy2 As DateTime
            dy1 = Convert.ToDateTime(DateTimePicker1.Value)
            dy2 = Convert.ToDateTime(DateTimePicker2.Value)

            'Return all the dates chosen
            dateintervals = intervals.DateIntervals(date1.Trim, date2.Trim, Dayofweek)


            Dim maxdates As Integer = dateintervals.Count - 1
            If maxdates < 0 Then
                MsgBox("You must select a day that corresponds to the date.")
                Exit Sub

            End If
            'Check for any schedule conflicts with any student and store the conflict in a generic collection
            Dim conflictflag As Boolean = False
            Dim checkForStudentConflicts As IScheduleConflicts = New StudentConflict()
            Dim newday As Date
            Dim x As Integer = 0
            newday = dateintervals(x)
            Do While x <= dateintervals.Count - 1
                date1 = dateintervals(x)
                checkForStudentConflicts.ConflictWithAnotherStudent(Clinicianname.Trim, date1.Trim, date1.Trim, t1.Trim, t2.Trim, conflicts)

                x = x + 1
            Loop
            Dim dataTemplate As New ScheduleTemplate
            Dim dt As DataTable
            dt = dataTemplate.ScheduleConflict()
            Dim dr As DataRow
            Dim studentnameConflict As String = String.Empty

            'Check for stored conflicts between the clinician and student(s)

            conflictingstudent = conflicts.Count - 1
            If conflictingstudent > -1 Then
                MsgBox("There are students who need to be rescheduled to a different date and time")
                For i = 0 To conflictingstudent
                    p = CType(conflicts(i), AutoSelectConflicts)

                    studentnameConflict = p.name
                    conflictType = p.ConflictType
                    conflictDate = p.ScheduledDate
                    conflictTimeIn = p.DestinationTimeIn
                    conflictTimeOut = p.DestinationTimeout
                    conflictwithstudent = p.ConflictType
                    dr = dt.NewRow
                    dr("student") = studentnameConflict
                    dr("Date") = conflictDate
                    dr("TimeIn") = conflictTimeIn
                    dr("TimeOut") = conflictTimeOut
                    dt.Rows.Add(dr)

                Next


                'Display discovered conflict into GridView2
                DataGridView2.DataSource = dt
                DataGridView2.Columns(1).Visible = False
                DataGridView2.Columns(0).Width = 150
            Else
                'Save the scheduled days off
                Dim clinicianid As String = String.Empty
                Dim duplicate As Boolean = False
                Dim dateout As Date

                clinicianid = clinicianConversion.ConvertToId(Clinicianname)
                For x = 0 To dateintervals.Count - 1
                    dateout = Convert.ToDateTime(dateintervals(x))

                    duplicate = scheduleClinician.UpdateSchedule(clinicianid.Trim, dateout, t1.Trim, t2.Trim)
                Next
                If duplicate = False Then
                    MsgBox(ComboBox1.SelectedValue.Trim & " has been scheduled to be off")
                ElseIf duplicate = True Then
                    MsgBox(Clinicianname & " has been already scheduled off within this date range!")
                End If
            End If
        End If
        HomeDisplay.Show()
        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
        DisplaySetup()
    End Sub
    'Load all active clincian names into Combobox1
    Private Sub ClinicianOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Scheduleinfo As New IPopulateNames
        Dim ds1 As New DataSet
        ds1 = Scheduleinfo.DisplayClinician(False)
        Dim dt1 As DataTable = ds1.Tables("clinicianList")
        ComboBox1.DataSource = dt1
        ComboBox1.DisplayMember = "clinicianFullName"
        ComboBox1.ValueMember = "clinicianFullName"


    End Sub
    'Display clincian's off dates within the gridview1 control
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DisplaySetup()
    End Sub
    'Display clincian's off dates within the gridview1 control
    Public Sub DisplaySetup()
        Dim convertName As INameConversion = New ClinicianNameConversion
        Dim Clinicianoutput As New ScheduleConfig
        Dim Clinicianname As String = Nothing

        Clinicianname = ComboBox1.SelectedValue
        If Clinicianname = String.Empty Then

            MsgBox("You must Provide a Clinician Name")
            Exit Sub
        End If

        Dim ClinicianProfile As New Schedule



        Dim date1 As String = DateTimePicker3.Value.ToString("M/dd/yyyy")
        Dim date2 As String = DateTimePicker4.Value.ToString("M/dd/yyyy")

        Dim clinicianid As String = String.Empty
        clinicianid = convertName.ConvertToId(Clinicianname)

        Dim dt As DataTable
        dt = Clinicianoutput.clinicianOutSchedule(clinicianid.Trim, date1, date2)

        DataGridView1.DataSource = dt
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 75
        DataGridView1.Columns(3).Width = 75
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SchedulingConsole.Show()
    End Sub



    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        For i = 0 To DataGridView1.RowCount - 1

            If CheckBox1.Checked = True Then
                DataGridView1.Rows(i).Cells(0).Value = True
            ElseIf CheckBox1.Checked = False Then
                DataGridView1.Rows(i).Cells(0).Value = False
            End If
        Next
    End Sub
    'Remove any scheduled off days.
    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim intervals As IEvaluateDateTimeIntervals = New datetimeIntervalConversion
        Dim clinicianConversion As INameConversion = New ClinicianNameConversion

        Dim Clinicianoutput As New ScheduleConfig
        Dim ClinicianProfile As New Schedule
        Dim Daysofweek() As String = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim row As DataGridViewRow = Nothing


        Dim totalTime As New ArrayList
        Dim appointment As String
        Dim StartTime As String
        Dim EndTime As String
        Dim clinicianid As String = String.Empty
        Dim StudentName As String = String.Empty
        Clinicianname = ComboBox1.SelectedValue
        Dim maxrows As Integer = DataGridView1.Rows.Count
        Dim counter As Integer = -1
        Dim DeleteDate(maxrows, 4) As String
        'Scan each row for a checkbox that is set to true
        ' Dim view As DataView = CType(DataGridView1.Rows, DataView)
        For i = 0 To DataGridView1.RowCount - 1


            ' Do something '
            'If checkbox is set to true then store each cloumn item into a two dimensional array
            'first element of the array represents the row index, and the second number represents the attribute of the column
            If DataGridView1.Rows(i).Cells(0).Value = True Then

                'increment counter that represents the row index by 1
                counter = counter + 1
                'Store each label into its respective variable
                appointment = DataGridView1.Rows(i).Cells(1).Value

                StartTime = DataGridView1.Rows(i).Cells(2).Value
                EndTime = DataGridView1.Rows(i).Cells(3).Value

                clinicianid = clinicianConversion.ConvertToId(Clinicianname)

                DeleteDate(counter, 0) = appointment
                DeleteDate(counter, 1) = StartTime
                DeleteDate(counter, 2) = EndTime
                DeleteDate(counter, 3) = clinicianid.Trim
                'calculate the time interval between the start time and end time to erase the contents of the text box in the Main Gridview dispaly
                'Contents must be set to a in the currently displayed Gridview blank string 
                totalTime = intervals.timeIntervals(StartTime.Trim, EndTime.Trim)

            End If
        Next


        'Delete the respective intervals by passing the array of selected row items and the daysof the week

        Dim clinicianSchedule As IscheduleClinician = New clincianScheduledOff
        clinicianSchedule.deleteClinicianOffdays(DeleteDate, Daysofweek)

        'Display the updated gridview
        Dim date1 As String = DateTimePicker3.Value.ToString("M/dd/yyyy")
        Dim date2 As String = DateTimePicker4.Value.ToString("M/dd/yyyy")

        Clinicianname = ComboBox1.SelectedValue



        clinicianid = clinicianConversion.ConvertToId(Clinicianname)


        dt = Clinicianoutput.clinicianOutSchedule(clinicianid.Trim, date1, date2)

        DataGridView1.DataSource = dt
        HomeDisplay.Show()
        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
        DisplaySetup()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker4.Value = DateTimePicker3.Value
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Value = DateTimePicker1.Value
    End Sub


End Class