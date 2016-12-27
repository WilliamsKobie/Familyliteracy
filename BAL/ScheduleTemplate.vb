Imports System
Imports System.Data

'Datasets for temporary storage of user schedule,clinician schedule, and user profiles
Public Class ScheduleTemplate
    'Dataset Layout for mainDisplay screens. RescheduleDailyDisplay.vb,HomeDisplay.vb, and OfficeSchedulePrintOut.vb
    Public Function ScheduleTemplate() As DataSet

        Dim Tutor As DataColumn = New DataColumn("Clinician")

        Dim Hour_Half2 As DataColumn = New DataColumn("7:30am")
        Dim Hour3 As DataColumn = New DataColumn("8:00am")
        Dim Hour_Half3 As DataColumn = New DataColumn("8:30am")
        Dim Hour4 As DataColumn = New DataColumn("9:00am")
        Dim Hour_Half4 As DataColumn = New DataColumn("9:30am")
        Dim Hour5 As DataColumn = New DataColumn("10:00am")
        Dim Hour_Half5 As DataColumn = New DataColumn("10:30am")
        Dim Hour6 As DataColumn = New DataColumn("11:00am")
        Dim Hour_Half6 As DataColumn = New DataColumn("11:30am")
        Dim Hour7 As DataColumn = New DataColumn("12:00n")
        Dim Hour_Half7 As DataColumn = New DataColumn("12:30pm")
        Dim Hour8 As DataColumn = New DataColumn("1:00pm")
        Dim Hour_Half8 As DataColumn = New DataColumn("1:30pm")
        Dim Hour9 As DataColumn = New DataColumn("2:00pm")
        Dim Hour_Half9 As DataColumn = New DataColumn("2:30pm")
        Dim Hour10 As DataColumn = New DataColumn("3:00pm")
        Dim Hour_Half10 As DataColumn = New DataColumn("3:30pm")
        Dim Hour11 As DataColumn = New DataColumn("4:00pm")
        Dim Hour_Half11 As DataColumn = New DataColumn("4:30pm")
        Dim Hour12 As DataColumn = New DataColumn("5:00pm")
        Dim Hour_Half12 As DataColumn = New DataColumn("5:30pm")
        Dim Hour13 As DataColumn = New DataColumn("6:00pm")
        Dim Hour_Half13 As DataColumn = New DataColumn("6:30pm")
        Dim Hour14 As DataColumn = New DataColumn("7:00pm")
        Dim Hour_Half14 As DataColumn = New DataColumn("7:30pm")
        Dim Status As DataColumn = New DataColumn("Status")
    


        Dim ds As New DataSet
        ds.Tables.Add("ScheduleDisplayScreen")
        Tutor = New DataColumn("Clinician", Type.GetType("System.String"))

        Hour_Half2 = New DataColumn("7:30 AM", Type.GetType("System.String"))
        Hour3 = New DataColumn("8:00 AM", Type.GetType("System.String"))
        Hour_Half3 = New DataColumn("8:30 AM", Type.GetType("System.String"))
        Hour4 = New DataColumn("9:00 AM", Type.GetType("System.String"))
        Hour_Half4 = New DataColumn("9:30 AM", Type.GetType("System.String"))
        Hour5 = New DataColumn("10:00 AM", Type.GetType("System.String"))
        Hour_Half5 = New DataColumn("10:30 AM", Type.GetType("System.String"))
        Hour6 = New DataColumn("11:00 AM", Type.GetType("System.String"))
        Hour_Half6 = New DataColumn("11:30 AM", Type.GetType("System.String"))
        Hour7 = New DataColumn("12:00 PM", Type.GetType("System.String"))
        Hour_Half7 = New DataColumn("12:30 PM", Type.GetType("System.String"))
        Hour8 = New DataColumn("1:00 PM", Type.GetType("System.String"))
        Hour_Half8 = New DataColumn("1:30 PM", Type.GetType("System.String"))
        Hour9 = New DataColumn("2:00 PM", Type.GetType("System.String"))
        Hour_Half9 = New DataColumn("2:30 PM", Type.GetType("System.String"))
        Hour10 = New DataColumn("3:00 PM", Type.GetType("System.String"))
        Hour_Half10 = New DataColumn("3:30 PM", Type.GetType("System.String"))
        Hour11 = New DataColumn("4:00 PM", Type.GetType("System.String"))
        Hour_Half11 = New DataColumn("4:30 PM", Type.GetType("System.String"))
        Hour12 = New DataColumn("5:00 PM", Type.GetType("System.String"))
        Hour_Half12 = New DataColumn("5:30 PM", Type.GetType("System.String"))
        Hour13 = New DataColumn("6:00 PM", Type.GetType("System.String"))
        Hour_Half13 = New DataColumn("6:30 PM", Type.GetType("System.String"))
        Hour14 = New DataColumn("7:00 PM", Type.GetType("System.String"))
        Hour_Half14 = New DataColumn("7:30 PM", Type.GetType("System.String"))
        Status = New DataColumn("Status", Type.GetType("System.String"))
      


        Dim dt1 As DataTable = ds.Tables("ScheduleDisplayScreen")

        dt1.Columns.Add(Tutor)

        dt1.Columns.Add(Hour_Half2)
        dt1.Columns.Add(Hour3)
        dt1.Columns.Add(Hour_Half3)
        dt1.Columns.Add(Hour4)
        dt1.Columns.Add(Hour_Half4)
        dt1.Columns.Add(Hour5)
        dt1.Columns.Add(Hour_Half5)
        dt1.Columns.Add(Hour6)
        dt1.Columns.Add(Hour_Half6)
        dt1.Columns.Add(Hour7)
        dt1.Columns.Add(Hour_Half7)
        dt1.Columns.Add(Hour8)
        dt1.Columns.Add(Hour_Half8)
        dt1.Columns.Add(Hour9)
        dt1.Columns.Add(Hour_Half9)
        dt1.Columns.Add(Hour10)
        dt1.Columns.Add(Hour_Half10)
        dt1.Columns.Add(Hour11)
        dt1.Columns.Add(Hour_Half11)
        dt1.Columns.Add(Hour12)
        dt1.Columns.Add(Hour_Half12)
        dt1.Columns.Add(Hour13)
        dt1.Columns.Add(Hour_Half13)
        dt1.Columns.Add(Hour14)
        dt1.Columns.Add(Hour_Half14)
        dt1.Columns.Add(Status)
        Return ds
    End Function

    Public Function StudentList() As DataSet
        Dim ds1 As New DataSet
        Dim Studentfn As DataColumn = New DataColumn("FirstName")
        Dim Studentln As DataColumn = New DataColumn("LastName")
        Dim studentname As DataColumn = New DataColumn("Fullname")

        ds1.Tables.Add("StudentList")
        Studentfn = New DataColumn("FirstName", Type.GetType("System.String"))
        Studentln = New DataColumn("LastName", Type.GetType("System.String"))
        studentname = New DataColumn("FullName", Type.GetType("System.String"))

        Dim dt1 As DataTable = ds1.Tables("StudentList")

        dt1.Columns.Add(Studentfn)
        dt1.Columns.Add(Studentln)
        dt1.Columns.Add(studentname)



        Return ds1
    End Function


    Public Function StudentProfile() As DataSet
        Dim ds As New DataSet
        Dim Studentln As DataColumn = New DataColumn("LastName")
        Dim Studentfn As DataColumn = New DataColumn("FirstName")

        Dim studentname As DataColumn = New DataColumn("Fullname")
        Dim DateofBirth As DataColumn = New DataColumn("Dob")
        Dim Gender As DataColumn = New DataColumn("Gender")
        Dim initialinquiry As DataColumn = New DataColumn("Initial Inquiry")
        Dim Assessment As DataColumn = New DataColumn("Assessment")
        Dim RptDiscussion As DataColumn = New DataColumn("Report Discussion")
        Dim TutorStart As DataColumn = New DataColumn("Tutoring Start")
        Dim TutorStop As DataColumn = New DataColumn("Tutoring Stop")
        Dim SchoolDist As DataColumn = New DataColumn("School Dist")
        Dim School As DataColumn = New DataColumn("School")
        Dim ActiveStudent As DataColumn = New DataColumn("Active")
        Dim Webreistered As DataColumn = New DataColumn("Web Ready")


        Studentfn = New DataColumn("FirstName", Type.GetType("System.String"))
        Studentln = New DataColumn("LastName", Type.GetType("System.String"))
        studentname = New DataColumn("FullName", Type.GetType("System.String"))
        DateofBirth = New DataColumn("Dob", Type.GetType("System.String"))
        initialinquiry = New DataColumn("Initial Inquiry", Type.GetType("System.String"))
        Gender = New DataColumn("Gender", Type.GetType("System.String"))
        Assessment = New DataColumn("Assessment", Type.GetType("System.String"))
        RptDiscussion = New DataColumn("Report Discussion", Type.GetType("System.String"))
        TutorStart = New DataColumn("Tutoring Start", Type.GetType("System.String"))
        TutorStop = New DataColumn("Tutoring Stop", Type.GetType("System.String"))
        SchoolDist = New DataColumn("School Dist", Type.GetType("System.String"))
        School = New DataColumn("School", Type.GetType("System.String"))
        ActiveStudent = New DataColumn("Active", Type.GetType("System.String"))
        Webreistered = New DataColumn("Web Ready", Type.GetType("System.String"))
        ds.Tables.Add("StudentProfileData")
        Dim dt As DataTable = ds.Tables("StudentProfileData")
        dt.Columns.Add(Studentln)
        dt.Columns.Add(Studentfn)

        dt.Columns.Add(studentname)
        dt.Columns.Add(DateofBirth)
        dt.Columns.Add(Gender)
        dt.Columns.Add(initialinquiry)
        dt.Columns.Add(Assessment)
        dt.Columns.Add(RptDiscussion)
        dt.Columns.Add(TutorStart)
        dt.Columns.Add(TutorStop)
        dt.Columns.Add(SchoolDist)
        dt.Columns.Add(School)
        dt.Columns.Add(ActiveStudent)
        dt.Columns.Add(Webreistered)
        Return ds
    End Function
    Public Function ClinicianTable() As DataSet
        Dim ds As New DataSet
        Dim Clinicianfn As DataColumn = New DataColumn("clinicianFirstName")
        Dim Clinicianln As DataColumn = New DataColumn("clinicianLastName")
        Dim ClinicianName As DataColumn = New DataColumn("clinicianFullName")

        Clinicianfn = New DataColumn("clinicianFirstName", Type.GetType("System.String"))
        Clinicianln = New DataColumn("clinicianLastName", Type.GetType("System.String"))
        ClinicianName = New DataColumn("clinicianFullName", Type.GetType("System.String"))
        ds.Tables.Add("clinicianList")
        Dim dt As DataTable = ds.Tables("clinicianList")
        dt.Columns.Add(Clinicianfn)
        dt.Columns.Add(Clinicianln)
        dt.Columns.Add(ClinicianName)
        Return ds
    End Function

    Public Function StudentSchedule() As DataSet
        Dim ds As New DataSet
        Dim ScheduledHours As DataColumn = New DataColumn("Hour")
        Dim ScheduleDate As DataColumn = New DataColumn("Date")
        Dim TimeIn As DataColumn = New DataColumn("TimeIn")
        Dim TimeOut As DataColumn = New DataColumn("TimeOut")
        Dim Clinician As DataColumn = New DataColumn("Clinician")
        Dim Campus As DataColumn = New DataColumn("Campus")
        Dim Status As DataColumn = New DataColumn("Status")
        Dim Subject As DataColumn = New DataColumn("Subject")
        Dim Processingclinician As DataColumn = New DataColumn("Processor")


        ScheduledHours = New DataColumn("Hour", Type.GetType("System.String"))
        ScheduleDate = New DataColumn("Date", Type.GetType("System.String"))
        TimeIn = New DataColumn("TimeIn", Type.GetType("System.String"))
        TimeOut = New DataColumn("TimeOut", Type.GetType("System.String"))
        Clinician = New DataColumn("Clinician", Type.GetType("System.String"))
        Campus = New DataColumn("Campus", Type.GetType("System.String"))
        Subject = New DataColumn("Subject", Type.GetType("System.String"))
        Status = New DataColumn("Status", Type.GetType("System.String"))
        Processingclinician = New DataColumn("Processor", Type.GetType("System.String"))
        ds.Tables.Add("Clinicianinfo")
        Dim dt As DataTable = ds.Tables("Clinicianinfo")

        dt.Columns.Add(ScheduledHours)
        dt.Columns.Add(ScheduleDate)
        dt.Columns.Add(TimeIn)
        dt.Columns.Add(TimeOut)
        dt.Columns.Add(Clinician)
        dt.Columns.Add(Status)
        dt.Columns.Add(Campus)
        dt.Columns.Add(Subject)
        dt.Columns.Add(Processingclinician)
        Return ds
    End Function

    Public Function ClinicianStudentSchedule() As DataSet
        Dim dsClinicianScheduleTable As New DataSet()

        Dim ClinicianScheduleTable As DataTable = New DataTable("ClinicianSchedule")
        Dim ClinicianName As New DataColumn("Clinician")
        ClinicianName.DataType = GetType(System.String)
        ClinicianScheduleTable.Columns.Add(ClinicianName)
        Dim StudentName As New DataColumn("Student")
        StudentName.DataType = GetType(System.String)
        ClinicianScheduleTable.Columns.Add(StudentName)
        Dim ScheduleDate As New DataColumn()
        ScheduleDate.DataType = System.Type.GetType("System.String")
        Dim Status As New DataColumn()
        Status.DataType = System.Type.GetType("System.String")
        Dim Campus As New DataColumn()
        Campus.DataType = System.Type.GetType("System.String")
        Dim Subject As New DataColumn()
        Subject.DataType = System.Type.GetType("System.String")

        ScheduleDate.ColumnName = "Scheduled Date"
        ClinicianScheduleTable.Columns.Add(ScheduleDate)
        Dim TimeIn As New DataColumn()
        TimeIn.DataType = System.Type.GetType("System.String")
        TimeIn.ColumnName = "Start"
        ClinicianScheduleTable.Columns.Add(TimeIn)
        Dim TimeOut As New DataColumn()
        TimeOut.DataType = System.Type.GetType("System.String")
        TimeOut.ColumnName = "Finish"
        ClinicianScheduleTable.Columns.Add(TimeOut)
        Status.ColumnName = "Status"
        ClinicianScheduleTable.Columns.Add(Status)
        Campus.ColumnName = "Campus"
        ClinicianScheduleTable.Columns.Add(Campus)

        Subject.ColumnName = "Subject"
        ClinicianScheduleTable.Columns.Add(Subject)

        dsClinicianScheduleTable.Tables.Add(ClinicianScheduleTable)
        Return dsClinicianScheduleTable

    End Function

    Public Function InactiveClinician() As DataSet
        Dim ds As New DataSet
        Dim StudentfullName As DataColumn = New DataColumn("StudentName")
        Dim ScheduleDate As DataColumn = New DataColumn("Date")
        Dim TimeIn As DataColumn = New DataColumn("TimeIn")
        Dim TimeOut As DataColumn = New DataColumn("TimeOut")

        StudentfullName = New DataColumn("StudentName", Type.GetType("System.String"))
        ScheduleDate = New DataColumn("Date", Type.GetType("System.DateTime"))
        TimeIn = New DataColumn("TimeIn", Type.GetType("System.String"))
        TimeOut = New DataColumn("TimeOut", Type.GetType("System.String"))
        ds.Tables.Add("InactiveClinicianSchedule")
        Dim dtable As DataTable = ds.Tables("InactiveClinicianSchedule")
        dtable.Columns.Add(StudentfullName)
        dtable.Columns.Add(ScheduleDate)
        dtable.Columns.Add(TimeIn)
        dtable.Columns.Add(TimeOut)
        Return ds
    End Function

    Public Function ScheduleConflict() As DataTable
        Dim ds As New DataSet
        Dim Student As DataColumn = New DataColumn("Student")
        Dim Clinician As DataColumn = New DataColumn("Clinician")
        Dim ScheduleDate As DataColumn = New DataColumn("Date")
        Dim TimeIn As DataColumn = New DataColumn("TimeIn")
        Dim TimeOut As DataColumn = New DataColumn("TimeOut")

        Student = New DataColumn("Student", Type.GetType("System.String"))
        Clinician = New DataColumn("Clinician", Type.GetType("System.String"))
        ScheduleDate = New DataColumn("Date", Type.GetType("System.String"))
        TimeIn = New DataColumn("TimeIn", Type.GetType("System.String"))
        TimeOut = New DataColumn("TimeOut", Type.GetType("System.String"))
        ds.Tables.Add("Scheduleconflict")

        Dim dt As DataTable = ds.Tables("Scheduleconflict")
        dt.Columns.Add(Student)
        dt.Columns.Add(Clinician)
        dt.Columns.Add(ScheduleDate)
        dt.Columns.Add(TimeIn)
        dt.Columns.Add(TimeOut)
        Return dt
    End Function

    Public Function OffSchedule() As DataSet
        Dim ds As New DataSet

        Dim ScheduleDate As DataColumn = New DataColumn("Date")
        Dim TimeIn As DataColumn = New DataColumn("From")
        Dim TimeOut As DataColumn = New DataColumn("To")

        ScheduleDate = New DataColumn("Date", Type.GetType("System.String"))
        TimeIn = New DataColumn("From", Type.GetType("System.String"))
        TimeOut = New DataColumn("To", Type.GetType("System.String"))
        ds.Tables.Add("Clinicianoff")
        Dim dt As DataTable = ds.Tables("Clinicianoff")

        dt.Columns.Add(ScheduleDate)
        dt.Columns.Add(TimeIn)
        dt.Columns.Add(TimeOut)
        Return ds
    End Function
    Public Function StudentCalendar() As DataSet
        Dim ds As New DataSet

        Dim NewDates As DataColumn = New DataColumn("New Date")
        Dim Start As DataColumn = New DataColumn("Start")
        Dim Finish As DataColumn = New DataColumn("Finish")
        Dim Student As DataColumn = New DataColumn("Student Name")
        Dim OldDates As DataColumn = New DataColumn("Prior Date")
        Dim Excuse As DataColumn = New DataColumn("Excuse")
        Dim Clinician As DataColumn = New DataColumn("Clinician")
        Dim State As DataColumn = New DataColumn("State")
        Dim presence As DataColumn = New DataColumn("Attendance")

        Dim trfid As DataColumn = New DataColumn("Transferid")
        Dim CallDates As DataColumn = New DataColumn("Callin Date")

        Dim RequestInstrument As DataColumn = New DataColumn("MeansofRequest")
        Dim Campus As DataColumn = New DataColumn("Campus")
        Dim Subject As DataColumn = New DataColumn("Subject")
        Dim Processor As DataColumn = New DataColumn("EnteredBy")
        Dim OriginalDate As DataColumn = New DataColumn("InitialTransferDate")

        NewDates = New DataColumn("New Date", Type.GetType("System.DateTime"))
        Start = New DataColumn("Start", Type.GetType("System.String"))
        Finish = New DataColumn("Finish", Type.GetType("System.String"))
        Student = New DataColumn("Student Name", Type.GetType("System.String"))
        OldDates = New DataColumn("Prior Date", Type.GetType("System.DateTime"))
        Excuse = New DataColumn("Excuse", Type.GetType("System.String"))
        Clinician = New DataColumn("Clinician", Type.GetType("System.String"))
        State = New DataColumn("State", Type.GetType("System.String"))
        trfid = New DataColumn("Transferid", Type.GetType("System.String"))
        CallDates = New DataColumn("Callin Date", Type.GetType("System.DateTime"))
        RequestInstrument = New DataColumn("MeansofRequest", Type.GetType("System.String"))
        Campus = New DataColumn("Campus", Type.GetType("System.String"))
        Subject = New DataColumn("Subject", Type.GetType("System.String"))
        Processor = New DataColumn("EnteredBy", Type.GetType("System.String"))
        presence = New DataColumn("Attendance", Type.GetType("System.String"))
        OriginalDate = New DataColumn("OriginalTransferDate", Type.GetType("System.String"))

        ds.Tables.Add("StudentCalendar")
        Dim dt As DataTable = ds.Tables("StudentCalendar")
        dt.Columns.Add(NewDates)
        dt.Columns.Add(Start)
        dt.Columns.Add(Finish)
        dt.Columns.Add(Student)
        dt.Columns.Add(OldDates)
        dt.Columns.Add(Excuse)
        dt.Columns.Add(Clinician)
        dt.Columns.Add(State)
        dt.Columns.Add(trfid)
        dt.Columns.Add(CallDates)
        dt.Columns.Add(RequestInstrument)
        dt.Columns.Add(Campus)
        dt.Columns.Add(Subject)
        dt.Columns.Add(Processor)
        dt.Columns.Add(presence)
        dt.Columns.Add(OriginalDate)
        dt.Columns.Add()
        Return ds
    End Function




    Public Function StudentData() As DataTable
        Dim ds As New DataSet
        Dim Student As DataColumn = New DataColumn("Student Name")
        Dim StudentLn As DataColumn = New DataColumn("Student LastName")
        Dim StudentFn As DataColumn = New DataColumn("Student FirstName")
        Dim BirthDate As DataColumn = New DataColumn("DOB")
        Dim Sex As DataColumn = New DataColumn("Gender")
        Dim SchoolDist As DataColumn = New DataColumn("School District")
        Dim School As DataColumn = New DataColumn("School")
        Dim II As DataColumn = New DataColumn("Initial Inquiry")
        Dim AssDate As DataColumn = New DataColumn("Assessment")
        Dim RptDiscuss As DataColumn = New DataColumn("Report Discussion")
        Dim StartDate As DataColumn = New DataColumn("Tutoring Start")
        Dim StopDate As DataColumn = New DataColumn("Tutoring Stop")


        Dim Guardian As DataColumn = New DataColumn("Guardian Name")
        Dim Guardianln As DataColumn = New DataColumn("Guardian LastName")
        Dim Guardianfn As DataColumn = New DataColumn("Guardian FirstName")

        Dim GuardianType As DataColumn = New DataColumn("Guardian Type")
        Dim email1 As DataColumn = New DataColumn("Email")
        Dim email2 As DataColumn = New DataColumn("Alt. Email")
        Dim Address As DataColumn = New DataColumn("Address")
        Dim City As DataColumn = New DataColumn("City")
        Dim State As DataColumn = New DataColumn("State")
        Dim Zip As DataColumn = New DataColumn("Zip Code")
        Dim home As DataColumn = New DataColumn("Home Phone")
        Dim Cell As DataColumn = New DataColumn("Cell Phone")
        Dim Work As DataColumn = New DataColumn("Work Phone")
        Dim Other As DataColumn = New DataColumn("Fax")
        Dim ActiveStudent As DataColumn = New DataColumn("Active")





        Student = New DataColumn("Student Name", Type.GetType("System.String"))
        StudentLn = New DataColumn("Student LastName", Type.GetType("System.String"))
        StudentFn = New DataColumn("Student FirstName", Type.GetType("System.String"))
        BirthDate = New DataColumn("DOB", Type.GetType("System.String"))
        Sex = New DataColumn("Gender", Type.GetType("System.String"))
        SchoolDist = New DataColumn("School District", Type.GetType("System.String"))
        School = New DataColumn("School", Type.GetType("System.String"))
        II = New DataColumn("Initial Inquiry", Type.GetType("System.String"))
        AssDate = New DataColumn("Assessment", Type.GetType("System.String"))
        RptDiscuss = New DataColumn("Report Discussion", Type.GetType("System.String"))
        StartDate = New DataColumn("Tutoring Start", Type.GetType("System.String"))
        StopDate = New DataColumn("Tutoring Stop", Type.GetType("System.String"))

        ActiveStudent = New DataColumn("Active", Type.GetType("System.String"))


        Guardian = New DataColumn("Guardian Name", Type.GetType("System.String"))
        Guardianln = New DataColumn("Guardian LastName", Type.GetType("System.String"))
        Guardianfn = New DataColumn("Guardian FirstName", Type.GetType("System.String"))

        GuardianType = New DataColumn("Guardian Type", Type.GetType("System.String"))
        email1 = New DataColumn("Email", Type.GetType("System.String"))
        email2 = New DataColumn("Alt Email", Type.GetType("System.String"))
        Address = New DataColumn("Address", Type.GetType("System.String"))
        City = New DataColumn("City", Type.GetType("System.String"))
        State = New DataColumn("State", Type.GetType("System.String"))
        Zip = New DataColumn("Zip Code", Type.GetType("System.String"))
        home = New DataColumn("Home Phone", Type.GetType("System.String"))
        Cell = New DataColumn("Cell Phone", Type.GetType("System.String"))
        Work = New DataColumn("Work Phone", Type.GetType("System.String"))
        Other = New DataColumn("Fax", Type.GetType("System.String"))


        ds.Tables.Add("StudentProfileData")

        Dim dt As DataTable = ds.Tables("StudentProfileData")

        dt.Columns.Add(StudentLn)
        dt.Columns.Add(StudentFn)
        dt.Columns.Add(Student)
        dt.Columns.Add(BirthDate)
        dt.Columns.Add(Sex)
        dt.Columns.Add(SchoolDist)
        dt.Columns.Add(School)
        dt.Columns.Add(II)
        dt.Columns.Add(AssDate)
        dt.Columns.Add(RptDiscuss)
        dt.Columns.Add(StartDate)
        dt.Columns.Add(StopDate)
        dt.Columns.Add(ActiveStudent)


        dt.Columns.Add(Guardian)
        dt.Columns.Add(Guardianln)
        dt.Columns.Add(Guardianfn)

        dt.Columns.Add(GuardianType)
        dt.Columns.Add(email1)
        dt.Columns.Add(email2)
        dt.Columns.Add(Address)
        dt.Columns.Add(City)
        dt.Columns.Add(State)
        dt.Columns.Add(Zip)
        dt.Columns.Add(home)
        dt.Columns.Add(Cell)
        dt.Columns.Add(Work)
        dt.Columns.Add(Other)


        Return dt
    End Function


    Public Function GuardianInfo() As DataSet
        Dim ds1 As New DataSet
        Dim Studentfn As DataColumn = New DataColumn("FirstName")
        Dim Studentln As DataColumn = New DataColumn("LastName")
        Dim studentname As DataColumn = New DataColumn("Fullname")

        ds1.Tables.Add("guardianInformation")
        Studentfn = New DataColumn("FirstName", Type.GetType("System.String"))
        Studentln = New DataColumn("LastName", Type.GetType("System.String"))
        studentname = New DataColumn("FullName", Type.GetType("System.String"))

        Dim dt1 As DataTable = ds1.Tables("guardianInformation")

        dt1.Columns.Add(Studentfn)
        dt1.Columns.Add(Studentln)
        dt1.Columns.Add(studentname)



        Return ds1
    End Function
End Class
