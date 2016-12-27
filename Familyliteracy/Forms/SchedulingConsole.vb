Imports BAL
Imports DAL
Imports System.ComponentModel

Public Class SchedulingConsole

    'Load all default values
    'Populate student Names that are active (only)
    'Setup Single date range area
      Private Sub SchedulingConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Single date range setupFill the active Students inside of ComboBox1
        Dim names As IPopulateAllNames = New IPopulateNames
        Dim todaysdate As Date
        todaysdate = Today
        CheckBox3.Checked = False
        DateTimePicker2.Visible = False
        GroupBox2.Visible = False
        Label4.Visible = False
        GroupBox4.Location = New Point(37, 100)
        GroupBox3.Location = New Point(256, 100)
        Label2.Location = New Point(31, 165)
        Label12.Location = New Point(198, 165)
        GroupBox1.Size = New Point(563, 250)
        Button1.Location = New Point(340, 185)



        ComboBox6.Location = New Point(34, 185)
        ComboBox7.Location = New Point(201, 185)

        ComboBox6.SelectedIndex = 0
        ComboBox7.SelectedIndex = 0

        Label14.Text = HomeDisplay.Label4.Text

        REM Fill the active Students inside of ComboBox1
        Dim dsStudent As New DataSet
        dsStudent = names.DisplayStudents(False)
        Dim dtStudent As DataTable = dsStudent.Tables("StudentList")
        ComboBox1.DataSource = dtStudent
        ComboBox1.DisplayMember = "FullName"
        ComboBox1.ValueMember = "FullName"

        MaskedTextBox1.Text = todaysdate.ToString("MM/dd/yyyy")
        REM Fill the Clinician Combobox
        Dim ds2 As New DataSet
        ds2 = names.DisplayClinician(True)
        Dim dt2 As DataTable = ds2.Tables("clinicianList")

        ComboBox2.DataSource = dt2
        ComboBox2.DisplayMember = "clinicianFullName"
        ComboBox2.ValueMember = "clinicianFullName"

        ThisMonthDateRange()


        Dim totalDays As Integer

        totalDays = Date.DaysInMonth(Now.Year, Now.Month)
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today.AddDays(totalDays)


        ComboBox1.Focus()


    End Sub
    'Preset the datetimepicker date range of the beginning and last day of the current month for the Display Console.
    Public Sub ThisMonthDateRange()
        Dim currentMonth As Integer
        Dim currentYear As Integer
        currentMonth = Date.Today.Month
        currentYear = Date.Today.Year
        Dim startOfThisMonthRange As String
        Dim endOfThisMonthRange As String
        startOfThisMonthRange = currentMonth & "/1/" & currentYear
        Dim lastday As Integer
        lastday = Date.DaysInMonth(currentYear, currentMonth)
        startOfThisMonthRange = currentMonth & "/1/" & currentYear
        endOfThisMonthRange = currentMonth & "/" & lastday & "/" & currentYear
        DateTimePicker3.Value = startOfThisMonthRange
        DateTimePicker4.Value = endOfThisMonthRange
    End Sub
    'Set the date range for next month in the datetimepickers
    Private Function NextmonthDaterange() As List(Of String)
        Dim nextMonth As Integer
        Dim currentYear As Integer

        nextMonth = Date.Today.Month
        currentYear = Date.Today.Year
        If nextMonth = 12 Then
            currentYear = currentYear + 1
            nextMonth = 0
        End If
        'Increse month number
        nextMonth = nextMonth + 1
        Dim startOfNextMonthRange As String
        Dim endOfNextMonthRange As String
        startOfNextMonthRange = nextMonth & "/1/" & currentYear

        Dim lastday As Integer
        lastday = Date.DaysInMonth(currentYear, nextMonth)
        startOfNextMonthRange = nextMonth & "/1/" & currentYear
        endOfNextMonthRange = nextMonth & "/" & lastday & "/" & currentYear

        Dim nextMonthsRange As New List(Of String)
        nextMonthsRange.Add(startOfNextMonthRange)
        nextMonthsRange.Add(endOfNextMonthRange)
        Return nextMonthsRange
    End Function

   


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataEntry()
        Dim Display As IappointmentRetriever = New AppointmentRetriever
        Dim StudentSchedule As IEnumerable(Of ScheduleConsoleDisplayCollection) = Nothing
        ScheduledParameters = DisplayStudentSchedule()
        StudentSchedule = Display.Retrieve(ScheduledParameters)
        DataGridView1.DataSource = StudentSchedule
        ScheduleDisplayAttributes()
        GridViewColorCode()

    End Sub
    Public Function CheckforSelectedDays(startdate As String, enddate As String, ByVal dayofweek As Array)
        Dim trigger As Boolean = False
        Dim d1 As Date
        Dim d2 As Date
        Dim theday As String
        d1 = Convert.ToDateTime(startdate)
        d2 = Convert.ToDateTime(enddate)



        While d1 <= d2

            For x = 0 To dayofweek.Length - 1

                theday = d2.ToString("dddd")
                If theday = dayofweek(x) Then
                    trigger = True
                End If
            Next
            d2 = d2.AddDays(-1)
        End While




        Return trigger
    End Function
    'Determines an available location for the desired time slot.
    'Store all the entries i.e. Student info, date, time(Single or, multiple dates), todays date, how it was requested the date,clinician, Campus, Subject, with validation
    'Also processes [AUTO SELECT] or the manual selection of Clinicians
    Public Sub DataEntry()


        Dim intervals As IEvaluateDateTimeIntervals = New DatetimeIntervalConversion
        Dim autoAssignClinician As ISchedule = New Scheduling
        Dim manualAssignClinician As ISchedule = New Scheduling
        Dim level As IstudentProfileAttributes = New ReadingLevel
        Dim convertStudentName As INameConversion = New StudentNameConversion
        Dim parseApostrophe As New NameOperation
        Dim dateintervals As New ArrayList
        Dim datestamp As New ArrayList
        Dim timeintervals As New ArrayList
        Dim StudentFullName As String
        Dim Processor As String = String.Empty
        Dim StartDate As String = String.Empty
        Dim EndDate As String = String.Empty
        Dim StartTime As String = String.Empty
        Dim EndTime As String = String.Empty
        Dim SchClinician As String = String.Empty
        Dim PlaceClinician As New ArrayList
        Dim status As String = String.Empty
        Dim requestedDate As String = String.Empty
        Dim MeansofRequest As String = String.Empty
        Dim foundClinician As New List(Of AutoSelectConflicts)
        Dim Location As String = String.Empty
        Dim subject As String = String.Empty
        Dim Priorappointment As String = String.Empty
        Dim p As AutoSelectConflicts
        Dim readingLevel As String = String.Empty
        Dim studentid As String = String.Empty
        Dim Conflict As New DataSet
        '"unassigned" is a place holder for a day of the week
        Dim week() As String = {"unassigned", "unassigned", "unassigned", "unassigned", "unassigned", "unassigned", "unassigned"}
        If Label14.Text = String.Empty Then
            MsgBox("There is no clinician that is signed in. Please close this screen and sign in.")
            Exit Sub
        End If
        StartDate = DateTimePicker1.Value

        'Check to see if datetimepicker end date is visible
        If CheckBox3.Checked = True Then
            EndDate = DateTimePicker2.Value
        Else
            EndDate = DateTimePicker1.Value
        End If
        'Store all neccessary values
        StartTime = ComboBox3.SelectedItem
        EndTime = ComboBox4.SelectedItem
        SchClinician = ComboBox2.SelectedValue
        StudentFullName = ComboBox1.SelectedValue.ToString
        StudentFullName = parseApostrophe.ExecuteName(StudentFullName, 1)
        requestedDate = MaskedTextBox1.Text
        MeansofRequest = ComboBox5.SelectedItem
        Processor = Label14.Text
        'Validation

        If MeansofRequest = String.Empty Then
            MsgBox("You must select a mode of Request")
            Exit Sub

        End If
        Location = ComboBox6.SelectedItem
        subject = ComboBox7.SelectedItem
        'Check to see if your choose a block no larger than 1 hour.
        Dim time1 As String = String.Empty
        Dim time2 As String = String.Empty
        Dim totalminutes As Integer = 0
        Dim t1, t2 As DateTime
        Dim ts As TimeSpan
        time1 = ComboBox3.SelectedItem
        time2 = ComboBox4.SelectedItem
        t1 = Convert.ToDateTime(time1)
        t2 = Convert.ToDateTime(time2)
        ts = (t2 - t1)
        totalminutes = ts.TotalMinutes


        If StudentFullName = String.Empty Then
            MsgBox("You must choose a Student")
        ElseIf ComboBox3.SelectedItem = "" Then
            MsgBox("You use pick a Start Time")
        ElseIf ComboBox4.SelectedItem = "" Then
            MsgBox("You use pick a Finish Time")

            'Automate the selection of the next available Clinician then send the result to the display 
        ElseIf SchClinician = "AUTO SELECT" Then


            If CheckBox3.Checked = True Then

                fweek = Storedayofweek(week)
                Dim chkdays As Boolean
                chkdays = CheckforselectedDays(StartDate.Trim, EndDate.Trim, week)
                If chkdays = False Then
                    MsgBox("You must select the day(s) of the week")
                    Exit Sub
                End If
            Else
                Dim days As DateTime = Nothing
                Dim daynum As Integer = 0
                days = Convert.ToDateTime(StartDate)
                daynum = days.DayOfWeek
                week(daynum) = days.ToString("dddd").Trim
            End If
            studentid = convertStudentName.ConvertToId(StudentFullName)
            'Determine an available location for the desired time slot.
            'Return time and date interval within a date range.
            timeintervals = intervals.TimeIntervals(StartTime.Trim, EndTime.Trim)
            dateintervals = intervals.DateIntervals(StartDate.Trim, EndDate.Trim, week)
            readingLevel = level.Level(studentid)
            'Check to see if selected dtudent is already scheduled at the selected date and time

            'Determine any conflicts within the selected scheduled dates, and store values within the Mainschedule Table within the database


            foundClinician = autoAssignClinician.AutoSelectClinician(StudentFullName.Trim, StartDate.Trim, EndDate.Trim, timeintervals, dateintervals, "Proposed", requestedDate, MeansofRequest, Location, subject, Processor.Trim)

            'Validate for conflicts for Automatic scheduling
            Dim person As Integer
            person = foundClinician.Count

            Dim conflictType As String = String.Empty
            Dim conflictDate As String = String.Empty
            Dim conflictTimeIn As String = String.Empty
            Dim conflictTimeOut As String = String.Empty
            Dim tutor As String = String.Empty
            'There is 0 conflicts then store values

            If person > 0 Then
                For i = 0 To person - 1
                    p = CType(foundClinician(i), AutoSelectConflicts)

                    tutor = p.D_Clinician
                    conflictType = p.ConflictType
                    conflictDate = p.ScheduledDate
                    conflictTimeIn = p.DestinationTimeIn
                    conflictTimeOut = p.DestinationTimeout

                    If conflictType = "NothingAvailable" Then
                        MsgBox("There is no available openings on " & p.ScheduledDate & ".")
                    ElseIf conflictType = "self" Then
                        MsgBox(StudentFullName & " is already scheduled on " & p.ScheduledDate & " from " & conflictTimeIn & " to " & conflictTimeOut & ".")
                    End If
                Next



            Else



                MsgBox(StudentFullName & " has been added to the schedule.")

            End If

        Else
            'Manually select a clinician
            If CheckBox3.Checked = True Then
                week = Storedayofweek(week)

            Else
                'Determine day of the week
                Dim days As DateTime = Nothing
                Dim daynum As Integer = 0
                days = Convert.ToDateTime(StartDate)
                daynum = days.DayOfWeek
                week(daynum) = days.ToString("dddd").Trim
            End If
            'Determine any conflicts within the selected scheduled dates, and store values within the Mainschedule Table within the database
            Dim clinicianoff As Boolean = False
            'Return time and date interval within a date range.
            timeintervals = intervals.TimeIntervals(StartTime.Trim, EndTime.Trim)
            dateintervals = intervals.DateIntervals(StartDate.Trim, EndDate.Trim, week)



            foundClinician = manualAssignClinician.ManuallySelectAClinician(StudentFullName.Trim, SchClinician, StartDate.Trim, EndDate.Trim, StartTime, EndTime.Trim, timeintervals, dateintervals, "Proposed", requestedDate, MeansofRequest, Location, subject, Processor)

            'Validate for conflicts for manual scheduling
            Dim person As Integer
            person = foundClinician.Count

            Dim conflictType As String = String.Empty
            Dim conflictDate As String = String.Empty
            Dim conflictTimeIn As String = String.Empty
            Dim conflictTimeOut As String = String.Empty
            Dim conflictwithstudent As String = String.Empty
            Dim tutor As String = String.Empty
            'There is 0 conflicts then store values

            If person > 0 Then
                For i = 0 To person - 1
                    p = CType(foundClinician(i), AutoSelectConflicts)

                    tutor = p.D_Clinician
                    conflictType = p.ConflictType
                    conflictDate = p.ScheduledDate
                    conflictTimeIn = p.DestinationTimeIn
                    conflictTimeOut = p.DestinationTimeout
                    conflictwithstudent = p.ConflictType
                    If conflictType = "student" Then
                        MsgBox("There is no available opening on " & p.ScheduledDate & " from " & p.DestinationTimeIn & " to " & p.DestinationTimeout & "'")
                    ElseIf conflictType = "self" Then
                        MsgBox(StudentFullName & " is already scheduled on " & p.ScheduledDate & " from " & conflictTimeIn & " to " & conflictTimeOut & ".")
                    ElseIf conflictType = "clinician" Then
                        MsgBox(SchClinician & " is scheduled to be off " & p.ScheduledDate & " from " & conflictTimeIn & " to " & conflictTimeOut & ".")
                    End If
                Next
            Else

                MsgBox(StudentFullName & " has been added to the schedule.")

            End If
        End If

        DisplayStudentSchedule()

        'Display the conflict which aoccured between two different students within DataGridView2
        Dim query = From q In foundClinician
                    Where q.ConflictType = "student"
                    Select q

        If query.Count > 0 Then
            Dim bind As New BindingSource
            bind.DataSource = query
            DataGridView2.DataSource = bind
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(6).Visible = False
        End If
        'Reset HomeDisplay FORM with the new updated changes to the schedule
        HomeDisplay.Show()
        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
        foundClinician.Clear()

    End Sub
    'Store the days of the week
    Public Function Storedayofweek(ByVal dayofweek As Array) As Array

        If Sunday.Checked = True Then
            dayofweek(0) = "Sunday"
        Else
            dayofweek(0) = "Unassigned"
        End If
        If Monday.Checked = True Then
            dayofweek(1) = "Monday"
        Else
            dayofweek(1) = "Unassigned"
        End If
        If Tuesday.Checked = True Then
            dayofweek(2) = "Tuesday"
        Else
            dayofweek(2) = "Unassigned"
        End If
        If Wednesday.Checked = True Then
            dayofweek(3) = "Wednesday"
        Else
            dayofweek(3) = "Unassigned"
        End If
        If Thursday.Checked = True Then
            dayofweek(4) = "Thursday"
        Else
            dayofweek(4) = "Unassigned"
        End If
        If Friday.Checked = True Then
            dayofweek(5) = "Friday"
        Else
            dayofweek(5) = "Unassigned"
        End If
        If Saturday.Checked = True Then
            dayofweek(6) = "Saturday"
        Else
            dayofweek(6) = "Unassigned"
        End If
        Return dayofweek
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HomeDisplay.Show()
        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
        Me.Close()
    End Sub

    Private Sub DailyScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyScheduleToolStripMenuItem.Click
        HomeDisplay.Show()

        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
        HomeDisplay.Focus()
        Me.Close()
    End Sub
    'Display a students schedule
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Display As IappointmentRetriever = New AppointmentRetriever
        Dim StudentSchedule As IEnumerable(Of ScheduleConsoleDisplayCollection) = Nothing
        ScheduledParameters = DisplayStudentSchedule()
        StudentSchedule = Display.Retrieve(ScheduledParameters)
        DataGridView1.DataSource = StudentSchedule
        ScheduleDisplayAttributes()
        GridViewColorcode()
    End Sub
 
    Public Function DisplayStudentSchedule() As IDictionary
        Dim ConvertStudentName As INameConversion = New StudentNameConversion


        Dim studentname As String = ComboBox1.SelectedValue.ToString
        Dim ScheduledParameters As New Dictionary(Of String, String)
        Dim studentId As String
        If Not studentname = String.Empty Then
            'Get beginning and final selected dates from the datetimepicker and convert their data types
            Dim selectedStartDate As String = DateTimePicker3.Value
            Dim selectedFinalDate As String = DateTimePicker4.Value


            If Not selectedStartDate = String.Empty Or Not selectedFinalDate = String.Empty Then

                studentId = ConvertStudentName.ConvertToId(studentname)
                ScheduledParameters.Add("STUDENT_ID", studentId)
                ScheduledParameters.Add("DATE_START", selectedStartDate)
                ScheduledParameters.Add("DATE_STOP", selectedFinalDate)

            End If
          
            Return ScheduledParameters
        Else
            MsgBox("You Must Select a Students Name in Order To View a Students' Schedule")
        End If
        Return Nothing
    End Function



    'Permanently removes a single, or multiple scheduled dates from the datasource. Only remove Proposed dates.


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'Get all checked dates, and store then into an array
        Dim AppointmentRemover As IScheduleDisplayAppointmentRemover = Nothing

        Dim indicies As New List(Of Integer)
        For i = 0 To DataGridView1.RowCount - 1
            'If checkbox is set to true then store each column index value (hidden column 1) into a collection

            If DataGridView1.Rows(i).Cells(0).Value = True Then
                status = DataGridView1.Rows(i).Cells(5).Value
                If status.Trim = "Proposed" Then
                    indicies.Add(Convert.ToInt32(DataGridView1.Rows(i).Cells(1).Value))
                End If

            End If
        Next
        AppointmentRemover = New ScheduleDisplayAppointmentRemover
        AppointmentRemover.Delete(indicies)
        AppointmentRemover = New CampusAppointmentRemover
        AppointmentRemover.Delete(indicies)


        'Refresh the updated Schedule DataGrid Display 
        Dim Display As IappointmentRetriever = New AppointmentRetriever
        Dim StudentSchedule As IEnumerable(Of ScheduleConsoleDisplayCollection) = Nothing
        ScheduledParameters = DisplayStudentSchedule()
        StudentSchedule = Display.Retrieve(ScheduledParameters)
        DataGridView1.DataSource = StudentSchedule
        ScheduleDisplayAttributes()
        GridViewColorcode()

        'Refresh the Home Screen
        HomeDisplay.Removerows(HomeDisplay.MonthCalendar1.SelectionStart)
    End Sub
    'When checkbox is checked it Selects or Deselects all rows (dates) in the datagrid control.
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim trigger As Boolean = False
        For i = 0 To DataGridView1.RowCount - 1

            If CheckBox1.Checked = True Then
                DataGridView1.Rows(i).Cells(0).Value = True
                trigger = True
            ElseIf CheckBox1.Checked = False Then
                DataGridView1.Rows(i).Cells(0).Value = False
                trigger = False
            End If
        Next

    End Sub


    Public Sub ScheduleDisplayAttributes()
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(7).ReadOnly = True

        DataGridView1.Columns(0).Width = 55
        DataGridView1.Columns(1).Width = 55
        DataGridView1.Columns(2).Width = 170
        DataGridView1.Columns(3).Width = 65
        DataGridView1.Columns(4).Width = 65
        DataGridView1.Columns(5).Width = 65
        DataGridView1.Columns(6).Width = 150
        DataGridView1.Columns(7).Width = 150
        DataGridView1.Columns(1).Visible = False
    End Sub


    'Color rows(Scheduled dates) according to their status
    Public Sub GridViewColorCode()
        Dim Status As String
        Dim i As Integer
        Dim numofrows As Integer
        numofrows = DataGridView1.RowCount - 1 'Check for empty Rows
        If numofrows > -1 Then
            For i = 0 To numofrows

                Status = DataGridView1.Rows(i).Cells(5).Value

                If Status.Trim = "Canceled" Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                ElseIf Status.Trim = "Proposed" Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf Status.Trim = "Transfer" Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Azure
                ElseIf Status.Trim = "No Show" Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                ElseIf Status.Trim = "Completed" Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Green

                End If
            Next
        End If
    End Sub
    'Checkbox control display multiple daterange or single date range options
    'Display the date range by making the end date Datetimepicker control visible relocate controle within this area of the screen.
    'Display only a single datetimepicker control
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim groupBoxlocal As New GroupBox()
        'Single date entry
        If CheckBox3.Checked = False Then
            DateTimePicker2.Visible = False
            GroupBox2.Visible = False
            Label4.Visible = False
            GroupBox4.Location = New Point(37, 100)
            GroupBox3.Location = New Point(256, 100)
            GroupBox1.Size = New Point(563, 260)

            Label2.Location = New Point(31, 165)
            Label12.Location = New Point(198, 165)
            Button1.Location = New Point(340, 185)


            ComboBox6.Location = New Point(34, 185)
            ComboBox7.Location = New Point(201, 185)
            ComboBox6.SelectedIndex = 0
            ComboBox7.SelectedIndex = 0
            'Date range entry
        Else
            Label4.Visible = True
            DateTimePicker2.Visible = True
            GroupBox2.Visible = True
            GroupBox4.Location = New Point(37, 150)
            GroupBox3.Location = New Point(256, 150)
            Label2.Location = New Point(39, 215)
            Label12.Location = New Point(198, 215)
            ComboBox6.Location = New Point(34, 235)
            ComboBox7.Location = New Point(201, 235)
            Button1.Location = New Point(340, 230)


            GroupBox1.Size = New Point(563, 296)
            ComboBox6.SelectedIndex = 0
            ComboBox7.SelectedIndex = 0

        End If
    End Sub

    'When the combobox3 start time selector is selected then increment the combobox4 stop stime selector by 60 minutes.
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim time1 As String = String.Empty

        Dim t1, t2 As DateTime
        time1 = ComboBox3.SelectedItem
        t1 = Convert.ToDateTime(time1)
        t2 = t1.AddHours(1)
        ComboBox4.SelectedItem = t2.ToString("h:mm tt")
    End Sub




    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        ThisMonthDateRange()

        Dim Display As IcurrentNextMonthAppointmentRetriever = New CurrentNextMonthAppointmentRetriever
        Dim StudentSchedule As IEnumerable(Of ScheduleConsoleDisplayCollection) = Nothing
        ScheduledParameters = DisplayStudentSchedule()
        StudentSchedule = Display.Retrieve(ScheduledParameters)
        DataGridView1.DataSource = StudentSchedule
        ScheduleDisplayAttributes()
        GridViewColorcode()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim monthrange As IEnumerable(Of String)
        monthrange = NextmonthDaterange()
        DateTimePicker3.Value = monthrange(0)
        DateTimePicker4.Value = monthrange(1)
        Dim Display As IcurrentNextMonthAppointmentRetriever = New CurrentNextMonthAppointmentRetriever
        Dim StudentSchedule As IEnumerable(Of ScheduleConsoleDisplayCollection) = Nothing
        ScheduledParameters = DisplayStudentSchedule()
        StudentSchedule = Display.Retrieve(ScheduledParameters)
        DataGridView1.DataSource = StudentSchedule
        ScheduleDisplayAttributes()
        GridViewColorcode()
    End Sub


    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim trigger As Boolean = False

        For i = 0 To DataGridView1.RowCount - 1
            If DirectCast(DataGridView1.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True Then
                trigger = True
            Else
            End If
        Next

    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        RescheduleDailyDisplay.Show()
        RescheduleDailyDisplay.Focus()
    End Sub



    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
        Dim getstudentId As INameConversion = New StudentNameConversion
        Dim studentId As String = String.Empty
        Dim studentname As String = String.Empty
        If ComboBox1.SelectedIndex > 0 Then
            Displaynotes.Show()
            studentname = ComboBox1.SelectedValue
            studentId = getstudentId.ConvertToId(studentname)
            Displaynotes.PopulateGrid(studentId)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim totalDays As Integer
        totalDays = Date.DaysInMonth(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month)
        DateTimePicker2.Value = DateTimePicker1.Value.AddDays(totalDays)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Displaynotes()
    End Sub


    Public Function Displaynotes()
        Dim returnnotes As IstudentAttributesDatasets = New userProfileAttributes
        Dim convertStudentId As INameConversion = New StudentNameConversion
        Dim dv As New DataView
        Dim studentName As String = Nothing
        Dim studentId As String = String.Empty

        If ComboBox1.SelectedIndex > 0 Then
            studentName = ComboBox1.SelectedValue
            studentId = convertStudentId.ConvertToId(studentName)
            dv = returnnotes.RetrieveNotes(studentId.Trim)
            DataGridView4.DataSource = dv
            DataGridView4.Columns(0).Visible = False
            DataGridView4.Columns(1).Visible = False
            DataGridView4.Columns(3).Width = 150
            DataGridView4.Columns(4).Width = 500
            DataGridView4.Columns(2).SortMode = SortOrder.Descending
        End If
        Return Nothing
    End Function

    Private Sub DateTimePicker3_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker4.Value = DateTimePicker3.Value
    End Sub



    Public Sub StudentProfileUpdate()
        Dim studentData As IstudentAttributesCollection = New userAttributesCollection
        Dim convertName As INameConversion = New StudentNameConversion
        Dim studentAttributes As New ArrayList
        Dim parseApostrophe As New NameOperation
        Dim Lastname As String = String.Empty
        Dim Firstname As String = String.Empty
        Dim SchoolDistrict As String = String.Empty
        Dim School As String = String.Empty
        Dim assessmentDate As String = String.Empty
        Dim rptDiscussiondate As String = String.Empty
        Dim initialInquiry As String = String.Empty
        Dim tutorStart As String = String.Empty
        Dim tutorStop As String = String.Empty
        Dim DOB As String = String.Empty
        Dim studentLastName As String = String.Empty
        Dim studentfirstName As String = String.Empty
        Dim studentfullname As String = String.Empty
        Dim gender As String = String.Empty
        Dim studentid As String = String.Empty
        Dim web As String = String.Empty
        Dim activeStudent As String = String.Empty
        studentfullname = ComboBox1.SelectedText
        If studentfullname = String.Empty Then
            MsgBox("You must select a student")
            Exit Sub
        End If
      

        studentid = convertName.ConvertToId(studentfullname.Trim)
        studentAttributes = studentData.StudentInfo(studentid.Trim)
        Firstname = studentAttributes(0)
        Lastname = studentAttributes(1)
        SchoolDistrict = studentAttributes(4)
        School = studentAttributes(5)
        gender = studentAttributes(3)
        DOB = studentAttributes(2)
        initialInquiry = studentAttributes(6)
        assessmentDate = studentAttributes(7)
        rptDiscussiondate = studentAttributes(8)
        tutorStart = studentAttributes(9)
        tutorStop = studentAttributes(10)
        activeStudent = studentAttributes(11)

        studentfirstName = parseApostrophe.ExecuteName(Firstname, 2)
        studentLastName = parseApostrophe.ExecuteName(Lastname, 2)

        'Append a 0 to the date string
        Dim initialInquiryLength As Integer = 0
        initialInquiryLength = initialInquiry.Length
        If initialInquiryLength = 9 Then
            initialInquiry = "0" & initialInquiry
        End If
        Dim editstudent As New EditStudentProfile(studentfullname)
        Call editstudent.Show()
        editstudent.TextBox3.Text = SchoolDistrict.Trim
        editstudent.TextBox4.Text = School.Trim
        editstudent.ComboBox1.SelectedItem = gender.Trim
        editstudent.TextBox1.Text = studentfirstName.Trim
        editstudent.TextBox2.Text = studentLastName.Trim
        DOB = DateScan(DOB)
        editstudent.MaskedTextBox1.Text = DOB.Trim
        assessmentDate = DateScan(assessmentDate)
        editstudent.MaskedTextBox2.Text = initialInquiry
        editstudent.MaskedTextBox3.Text = assessmentDate.Trim
        rptDiscussiondate = DateScan(rptDiscussiondate)
        editstudent.MaskedTextBox4.Text = rptDiscussiondate.Trim
        tutorStart = DateScan(tutorStart)
        editstudent.MaskedTextBox5.Text = tutorStart.Trim
        tutorStop = DateScan(tutorStop)
        editstudent.MaskedTextBox6.Text = tutorStop.Trim



        If activeStudent = "True" Then
            editstudent.CheckBox1.Checked = True
        ElseIf activeStudent = "False" Then
            editstudent.CheckBox1.Checked = False
        End If

        If gender.Trim = "Male" Then
            editstudent.ComboBox1.SelectedIndex = 0
        Else
            editstudent.ComboBox1.SelectedIndex = 1
        End If

        editstudent.Label29.Text = studentid
        Dim readingLevel As String = String.Empty
        Dim returnLevel As New ReturnStudentData

        readingLevel = returnLevel.StudentReadingLevel(studentid.Trim)
        editstudent.ComboBox5.SelectedItem = readingLevel.Trim


        Dim studentInfo As IstudentAttributesDatasets = New userProfileAttributes
        Dim schooltype As Boolean
        Dim dt As DataTable
        dt = studentInfo.RetrieveStudentSchool(studentid.Trim)
        Dim row As DataRow
        For Each row In dt.Rows
            schooltype = row("Prv_Pub")
        Next
        If schooltype = False Then
            editstudent.TextBox3.Visible = True
            editstudent.ComboBox2.Visible = False
            editstudent.TextBox3.Text = SchoolDistrict.Trim
            editstudent.RadioButton1.Checked = True
            editstudent.RadioButton2.Checked = False
            editstudent.Label7.Text = "School District"
        ElseIf schooltype = True Then
            editstudent.TextBox3.Visible = False
            editstudent.ComboBox2.Visible = True
            editstudent.ComboBox2.SelectedItem = SchoolDistrict.Trim
            editstudent.RadioButton2.Checked = True
            editstudent.RadioButton1.Checked = False
            editstudent.Label7.Text = "Type of Private School"
        End If

        editstudent.TextBox4.Text = School.Trim
        Dim dv As New DataView
        dv = studentInfo.RetrieveNotes(studentid.Trim)
        editstudent.DataGridView1.DataSource = dv
        editstudent.DataGridView1.Columns(0).Visible = False
        editstudent.DataGridView1.Columns(1).Visible = False
        editstudent.DataGridView1.Columns(3).Width = 150
        editstudent.DataGridView1.Columns(4).Width = 400
        editstudent.TextBox5.ReadOnly = True
        editstudent.TextBox6.ReadOnly = True
    End Sub
    Public Function DateScan(ByVal Value As String) As String
        If Value = String.Empty Then
            Return Value
            Exit Function
        End If
        If Value.Chars(1) = "/" Then
            Value = "0" & Value

        End If
        Return Value.Trim
    End Function

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        OpenStudentcalendar()
    End Sub
    Public Function OpenStudentcalendar()

        StudentCalendar.Show()
        StudentCalendar.Focus()
        StudentCalendar.ComboBox1.SelectedValue = DirectCast(Me.ComboBox1.Text.Trim, String)
        DateTimePicker1.Value = Me.DateTimePicker1.Value
        StudentCalendar.StartUp()


        Return Nothing
    End Function

    Private Sub DataGridView4_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentDoubleClick
        ComboBox1.Focus()
        StudentProfileUpdate()
    End Sub

    Private Sub DataGridView4_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView4.DoubleClick
        ComboBox1.Focus()
        StudentProfileUpdate()
    End Sub
End Class

