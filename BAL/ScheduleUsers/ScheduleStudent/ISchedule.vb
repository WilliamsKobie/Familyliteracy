Imports DAL
Imports System.IO
Imports System.Net


'Check to see the next available clinician
'Checks to see if the clinician is scheduled out
'Removes a Student from the Schedule
Public Interface ISchedule
    Function AutoSelectClinician(ByVal StudentFullName As String, ByVal DateStart As String, ByVal DateStop As String, ByVal timeintervals As ArrayList, ByVal dateintervals As ArrayList, ByVal Status As String, ByVal requesteddate As String, ByVal Howrequestwasmade As String, ByVal location As String, ByVal subject As String, ByVal Processor As String) As List(Of AutoSelectConflicts)
    Function ManuallySelectAClinician(ByVal studentFullName As String, ByVal clinicianName As String, ByVal StartDate As String, ByVal EndDate As String, ByVal StartTime As String, ByVal EndTime As String, ByVal timeIntervals As ArrayList, ByVal dateintervals As ArrayList, ByVal Status As String, ByVal requesteddate As String, ByVal Howrequestwasmade As String, ByVal location As String, ByVal subject As String, ByVal Processor As String) As List(Of AutoSelectConflicts)

End Interface


Public Class Scheduling
    Inherits CommitChanges
    Implements ISchedule

    Dim cliniciannameConversion As INameConversion = New ClinicianNameConversion
    Dim intervals As IEvaluateDateTimeIntervals = New DatetimeIntervalConversion
    Dim clinicianName As INameConversion = New ClinicianNameConversion
    Dim studentName As INameConversion = New StudentNameConversion


    Function AutoSelectClinician(ByVal StudentFullName As String, ByVal DateStart As String, ByVal DateStop As String, ByVal timeintervals As ArrayList, ByVal dateintervals As ArrayList, ByVal Status As String, ByVal requesteddate As String, ByVal Howrequestwasmade As String, ByVal location As String, ByVal subject As String, ByVal Processor As String) As List(Of AutoSelectConflicts) Implements ISchedule.AutoSelectClinician
        Dim cliniciannameConversion As INameConversion = New ClinicianNameConversion
        Dim studentnameConversion As INameConversion = New StudentNameConversion
        Dim CheckForScheduleConflict As IScheduleConflicts = New StudentConflict
        Dim ReturnNumberofAppointments As IstudentAppointmentCount = New StudentAppointmentCount
        Dim ScheduleStudentAppointment As IstudentAppointmentInserter = Nothing
        Dim clinicianName As String = String.Empty
        Dim conflictFlag2 As Boolean
        Dim conflictFlag3 As Boolean
        Dim conflictFlag4 As Boolean
        Dim conflictFlag As Boolean
        Dim Studentid As String = String.Empty
        Dim clinicianId As String = String.Empty
        Dim dateAvailability As Boolean = True

        Dim timeIn As String = String.Empty
        Dim timeOut As String = String.Empty
        Dim tm1, tm2 As DateTime
        Dim conflictType As String = String.Empty

        Dim Conflict As New DataSet
        Dim scheduleResults As New Schedule
        Dim clinicianScheduleResults As New Clinicians
        Dim Cdate1, Cdate2, currentDate As Date

        Dim dsActiveclinicians As New DataSet

        Dim autoSelect As Boolean = True
        ' Dim maindisplayidnumber As New idgenerator


        Dim storeConflict As New List(Of AutoSelectConflicts)
        Dim idnumber As Integer = 0
        Dim conflictLabel As String = String.Empty
        Dim convDate As String = String.Empty
        Dim d1 As String
        Cdate1 = Convert.ToDateTime(DateStart)
        Cdate2 = Convert.ToDateTime(DateStop)

        dsActiveclinicians = clinicianScheduleResults.GetClinicianInfo(True) 'Return all  Clinician that are active

        Studentid = studentnameConversion.ConvertToId(StudentFullName.Trim)

        Dim dt1 As DataTable = dsActiveclinicians.Tables("Clinician")
        Dim row As DataRow

        Dim dateIndex As Integer

        For dateIndex = 0 To dateintervals.Count - 1 'Increment to the next date in the the interval range chosen by the user

            For Each row In dt1.Rows 'Iterate through each active Clinicians
                'Check clinician active status.Execute code if clinician is active otherwise iterate to the next Clinician
                autoSelect = row("AutoSelect")

                If autoSelect = True Then   'Check to see if clinician is set for auto selection
                    conflictFlag = 0 'Reset the flag
                    clinicianId = row("ClinicianId")
                    clinicianName = cliniciannameConversion.ConvertName(clinicianId.Trim)
                    d1 = dateintervals(dateIndex)
                    tm1 = timeintervals(0) 'Set the Starttime to 'TimeIn'
                    tm2 = timeintervals(timeintervals.Count - 1) 'Set Final time to timeOut 
                    timeIn = tm1.ToString("h:mm tt")
                    timeOut = tm2.ToString("h:mm tt")
                    currentDate = Convert.ToDateTime(d1).ToLongDateString

                    Dim ScheduleConflict As New Dictionary(Of String, String)
                    ScheduleConflict.Add("Student_Name", StudentFullName)
                    ScheduleConflict.Add("Tutor_Name", clinicianName)
                    ScheduleConflict.Add("Date", d1)
                    ScheduleConflict.Add("Time_In", timeIn)
                    ScheduleConflict.Add("Time_Out", timeOut)
                    ScheduleConflict.Add("Clinician", clinicianName)


                    'Check to see if student is already scheduled at this time
                    conflictFlag4 = CheckForScheduleConflict.Conflict(ScheduleConflict, storeConflict)

                    'Check to see if the clinician is scheduled to be off
                    conflictFlag2 = CheckForScheduleConflict.ConflictwithClinician(clinicianId.Trim, currentDate, timeintervals, conflictFlag)
                    'Check to see if the student has a conflict with another student with the particular clinician within this iteration 

                    conflictFlag3 = CheckForScheduleConflict.ConflictWithAnotherStudent(clinicianName.Trim, d1.Trim, d1.Trim, timeIn.Trim, timeOut.Trim, storeConflict) 'Check to see if there is a Student Scheduled at this Specific time slot 



                    If conflictFlag4 = True Then

                        dateAvailability = False
                        conflictFlag4 = False
                        'Go to next Date
                        Exit For

                    ElseIf conflictFlag2 = True Then
                        dateAvailability = False
                        conflictFlag2 = False

                        'Go to next Clinician
                    ElseIf conflictFlag3 = True Then
                        dateAvailability = False

                        conflictFlag3 = False
                        'Go to next Clinician
                    Else
                        'Save student to the database
                        dateAvailability = True



                        Dim replaceAccentMark As New NameOperation
                        Processor = replaceAccentMark.ExecuteName(Processor, 1)
                        clinicianName = replaceAccentMark.ExecuteName(clinicianName, 1)

                        Dim ProposedAppointment As New Dictionary(Of String, String)
                        ProposedAppointment.Add("STUDENT_ID", Studentid)
                        ProposedAppointment.Add("DATE", currentDate)
                        ProposedAppointment.Add("START_TIME", timeIn)
                        ProposedAppointment.Add("FINAL_TIME", timeOut)
                        ProposedAppointment.Add("STUDENT_STATUS", Status)
                        ProposedAppointment.Add("CLINICIAN_ID", clinicianId)
                        ProposedAppointment.Add("CLINICIAN_FULLNAME", clinicianName)
                        ProposedAppointment.Add("DATE_OF APPOINTMENT_REQUEST", requesteddate)
                        ProposedAppointment.Add("REQUESTED_MEANS", Howrequestwasmade)
                        ProposedAppointment.Add("CAMPUS", location)
                        ProposedAppointment.Add("STUDIED_SUBJECT", subject)
                        ProposedAppointment.Add("DATA_ENTRY_PERSON", Processor)


                        Dim appointmentIndex As Integer
                        ScheduleStudentAppointment = New StudentScheduleInserter
                        appointmentIndex = ScheduleStudentAppointment.Insert(Of Dictionary(Of String, String))(ProposedAppointment)
                        ProposedAppointment.Add("APPOINTMENT_INDEX", appointmentIndex.ToString())
                        ScheduleStudentAppointment = New StudentAppointedCampus
                        ScheduleStudentAppointment.Insert(Of Dictionary(Of String, String))(ProposedAppointment)
                        'Go to next
                        Exit For

                    End If
                End If

            Next
            If dateAvailability = False Then

                conflictLabel = "NothingAvailable"
                storeConflict.Add(New AutoSelectConflicts(StudentFullName, clinicianName, dateintervals(dateIndex), timeIn, timeOut, True, conflictLabel))
                dateAvailability = False
            End If
        Next

        Return storeConflict
    End Function

    Function ManuallySelectedClinician(ByVal studentFullName As String, ByVal clinicianName As String, ByVal StartDate As String, ByVal EndDate As String, ByVal StartTime As String, ByVal EndTime As String, ByVal timeIntervals As ArrayList, ByVal dateintervals As ArrayList, ByVal Status As String, ByVal requesteddate As String, ByVal Howrequestwasmade As String, ByVal location As String, ByVal subject As String, ByVal Processor As String) As List(Of AutoSelectConflicts) Implements ISchedule.ManuallySelectAClinician


        Dim cliniciannameConversion As INameConversion = New ClinicianNameConversion
        Dim studentnameConversion As INameConversion = New StudentNameConversion
        Dim CheckForScheduleConflict As IScheduleConflicts = New StudentConflict
        Dim ScheduleStudentAppointment As IstudentAppointmentInserter = Nothing

      
        Dim storeConflict As New List(Of AutoSelectConflicts)

        Dim AutoSelect As Boolean = True

        Dim conflictFlag2 As Boolean = False
        Dim conflictFlag3 As Boolean = False
        Dim conflictFlag4 As Boolean = False
        Dim conflictFlag As Boolean = False

        Dim clinicianId As String = String.Empty
        Dim Studentid As String = String.Empty


        Dim timeIn As String = String.Empty
        Dim timeOut As String = String.Empty
        Dim tm1 As DateTime
        Dim tm2 As DateTime

        Dim conflictType As String = String.Empty

        Dim Conflict As New DataSet
        Dim scheduleresults As New Schedule

        Dim currentDate As Date



        Dim d1 As String

        clinicianId = cliniciannameConversion.ConvertToId(clinicianName)
        Studentid = studentnameConversion.ConvertToId(studentFullName)
        Dim dateIndex As Integer

        For dateIndex = 0 To dateintervals.Count - 1 'Increment to the next date in the the interval range chosen by the user

            conflictFlag = False 'Reset the flag

            d1 = dateintervals(dateIndex)
            tm1 = timeIntervals(0) 'Set the Starttime to 'TimeIn'
            tm2 = timeIntervals(timeIntervals.Count - 1) 'Set Final time to timeOut 
            timeIn = tm1.ToString("h:mm tt")
            timeOut = tm2.ToString("h:mm tt")
            currentDate = Convert.ToDateTime(d1)

            Dim ScheduleConflict As New Dictionary(Of String, String)
            ScheduleConflict.Add("Student_Name", studentFullName)
            ScheduleConflict.Add("Tutor_Name", clinicianName)
            ScheduleConflict.Add("Date", d1)
            ScheduleConflict.Add("Time_In", timeIn)
            ScheduleConflict.Add("Time_Out", timeOut)

            'Check to see if the Student is scheduled at the same time range. If so then set the 'reflexive variable to TRUE
            conflictFlag4 = CheckForScheduleConflict.Conflict(ScheduleConflict, storeConflict)

            'Check to see if the student has a conflict with another student with the particular clinician being off on the currentdate and the specific time slot within this iteration of dt1
            conflictFlag2 = CheckForScheduleConflict.ConflictwithClinician(clinicianId.Trim, currentDate, timeIntervals, conflictFlag)

            conflictFlag3 = CheckForScheduleConflict.ConflictWithAnotherStudent(clinicianName.Trim, d1.Trim, d1.Trim, timeIn.Trim, timeOut.Trim, storeConflict) 'Check to see if there is a Student Scheduled at this Specific time slot 



            If conflictFlag3 = True Then

                conflictFlag3 = False

            ElseIf conflictFlag4 = True Then
                conflictFlag4 = False

            ElseIf conflictFlag2 = True Then
                'Record conflict with clinician being scheduled out
                storeConflict.Add(New AutoSelectConflicts(studentFullName.Trim, clinicianName.Trim, dateintervals(dateIndex), timeIn.Trim, timeOut.Trim, True, "clinician"))
                conflictFlag2 = False


            Else
                'Save student to the database
               
                Dim replaceAccentMark As New nameOperation
                Processor = replaceAccentMark.ExecuteName(Processor, 1)
                clinicianName = replaceAccentMark.ExecuteName(clinicianName, 1)

                Dim ProposedAppointment As New Dictionary(Of String, String)
                ProposedAppointment.Add("STUDENT_ID", Studentid)
                ProposedAppointment.Add("DATE", currentDate)
                ProposedAppointment.Add("START_TIME", timeIn)
                ProposedAppointment.Add("FINAL_TIME", timeOut)
                ProposedAppointment.Add("STUDENT_STATUS", Status)
                ProposedAppointment.Add("CLINICIAN_ID", clinicianId)
                ProposedAppointment.Add("CLINICIAN_FULLNAME", clinicianName)
                ProposedAppointment.Add("DATE_OF APPOINTMENT_REQUEST", requesteddate)
                ProposedAppointment.Add("REQUESTED_MEANS", Howrequestwasmade)
                ProposedAppointment.Add("CAMPUS", location)
                ProposedAppointment.Add("STUDIED_SUBJECT", subject)
                ProposedAppointment.Add("DATA_ENTRY_PERSON", Processor)
                Dim appointmentIndex As Integer
                ScheduleStudentAppointment = New StudentScheduleInserter
                appointmentIndex = ScheduleStudentAppointment.Insert(Of Dictionary(Of String, String))(ProposedAppointment)
                ProposedAppointment.Add("APPOINTMENT_INDEX", appointmentIndex.ToString())
                ScheduleStudentAppointment = New StudentAppointedCampus
                ScheduleStudentAppointment.Insert(Of Dictionary(Of String, String))(ProposedAppointment)

            End If

        Next

        Return storeConflict
    End Function

   

End Class








