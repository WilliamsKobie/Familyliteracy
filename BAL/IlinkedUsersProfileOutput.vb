Imports System
Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports DAL

'Join a parent to a Student and join a student to a parent and store them in a dataset to be displayed
'StudentParentAsociation.vb makes use of the object
Public Interface IlinkedUsersProfileOutput
    Function parentLink(ByVal studentid As String) As DataTable
    Function studentLink(ByVal guardianid As String) As DataTable
End Interface
Public Class findUserLink
    Inherits ScheduleTemplate
    Implements IlinkedUsersProfileOutput

    Public Function parentLink(ByVal studentid As String) As DataTable Implements IlinkedUsersProfileOutput.parentLink
        Dim guardianInformation As IlocateLinkedUser = New returnLinkedUsersTable

        Dim dtGuradian As DataTable
        Dim studentStoragedt As DataTable
        Dim guardianid As String = String.Empty

        Dim dt As DataTable

        Dim Savedata As DataRow
        Dim guardianData As New returnGuardianInfo

        Dim initialinquiry As String = String.Empty
        Dim reportdate As String = String.Empty
        Dim tutoringstartdate As String = String.Empty
        Dim tutoringstopdate As String = String.Empty
        Dim assessmentdate As String = String.Empty
        Dim GuardianFullname, GuardianFirstname, GuardianLastname, guardianType, Address, City, State, Email, AltEmail, HomePhone, CellPhone, WorkPhone, ZipCode, Other As String
        studentStoragedt = StudentData()
        If studentid <> String.Empty Then

            dt = guardianInformation.locateGuardian(studentid.Trim)

            Dim query As String = "Studentid='" & studentid.Trim & "'"
            Dim rw As DataRow
            Dim rw1 As DataRow
            For Each rw In dt.Rows
                guardianid = rw("guardianId")
                dtGuradian = guardianData.guardianInfo(guardianid.Trim)


                For Each rw1 In dtGuradian.Rows
                    GuardianFirstname = rw1("First Name").ToString
                    GuardianLastname = rw1("Last Name").ToString
                    GuardianFullname = GuardianLastname.Trim & ", " & GuardianFirstname.Trim
                    If IsDBNull(rw1("Address")) = True Then

                        Address = [String].Empty

                    Else
                        Address = rw1("Address")

                    End If

                    If rw1("City") Is DBNull.Value Then
                        City = [String].Empty

                    Else
                        City = rw1("City").ToString
                    End If

                    If rw1("State") Is DBNull.Value Then
                        State = [String].Empty
                    Else
                        State = rw1("State").ToString

                    End If

                    If rw1("Zip Code") Is DBNull.Value Then
                        ZipCode = [String].Empty

                    Else
                        ZipCode = rw1("Zip Code").ToString
                    End If

                    If rw1("Home Phone") Is DBNull.Value Then

                        HomePhone = [String].Empty
                    Else
                        HomePhone = rw1("Home Phone")
                    End If

                    If rw1("Cell Phone") Is DBNull.Value Then
                        CellPhone = [String].Empty
                    Else
                        CellPhone = rw1("Cell Phone")
                    End If

                    If rw1("Work Phone") Is DBNull.Value Then
                        WorkPhone = [String].Empty
                    Else
                        WorkPhone = rw1("Work Phone")
                    End If

                    If rw1("Fax") Is DBNull.Value Then
                        Other = [String].Empty
                    Else
                        Other = rw1("Fax")
                    End If


                    If rw1("Email") Is DBNull.Value Then
                        Email = [String].Empty
                    Else
                        Email = rw1("Email")

                    End If

                    If rw1("Alt Email") Is DBNull.Value Then

                        AltEmail = [String].Empty
                    Else
                        AltEmail = rw1("Alt Email")

                    End If


                    If rw1("Guardian Type") Is DBNull.Value Then

                        guardianType = [String].Empty
                    Else
                        guardianType = rw1("Guardian Type")

                    End If


                    Savedata = studentStoragedt.NewRow
                    Savedata("Guardian Name") = GuardianFullname.Trim
                    Savedata("Guardian FirstName") = GuardianFirstname.Trim
                    Savedata("Guardian LastName") = GuardianLastname.Trim
                    Savedata("Guardian Type") = guardianType.Trim
                    Savedata("Address") = Address.Trim
                    Savedata("City") = City.Trim
                    Savedata("State") = State.Trim
                    Savedata("Zip Code") = ZipCode.Trim
                    Savedata("Home Phone") = HomePhone.Trim
                    Savedata("Cell Phone") = CellPhone.Trim
                    Savedata("Work Phone") = WorkPhone.Trim
                    Savedata("Fax") = Other.Trim
                    Savedata("Email") = Email.Trim
                    Savedata("Alt Email") = AltEmail.Trim


                    studentStoragedt.Rows.Add(Savedata)
                Next


            Next
        End If
        Return studentStoragedt



    End Function



    Public Function studentLink(ByVal guardianid As String) As DataTable Implements IlinkedUsersProfileOutput.studentLink

        Dim finduserLink As IlocateLinkedUser = New returnLinkedUsersTable
        Dim studentInfo As IstudentAttributesDatasets = New userProfileAttributes
        Dim StudentStoragedt As New DataTable
        Dim dt As DataTable
        Dim dtStudent As DataTable
        Dim Savedata As DataRow
        Dim outputdob As Date
        Dim initialinquiry As String = String.Empty
        Dim reportdate As String = String.Empty
        Dim tutoringstartdate As String = String.Empty
        Dim tutoringstopdate As String = String.Empty
        Dim assessmentdate As String = String.Empty
        Dim StudentFullname, StudentFirstname, StudentLastname, DOB, Gender, Dist, School As String
        Dim II, AssDate, RptDate, tutorStart, TutorStop As DateTime
        Dim studentId As String = String.Empty
        StudentStoragedt = StudentData()
        dt = finduserLink.locateStudent(guardianid.Trim)

        Dim rw As DataRow
        Dim rw1 As DataRow

        For Each rw In dt.Rows
            studentId = rw("Studentid").ToString
            dtStudent = studentInfo.StudentInfo(studentId.Trim)

            For Each rw1 In dtStudent.Rows


                StudentFirstname = rw1("First Name").ToString
                StudentLastname = rw1("Last Name").ToString
                StudentFullname = StudentLastname.Trim & ", " & StudentFirstname.Trim
                If IsDBNull(rw1("DOB")) = True Then

                    DOB = [String].Empty

                Else
                    DOB = rw1("DOB")
                    outputdob = Convert.ToDateTime(DOB)
                End If
                If rw1("Gender") Is DBNull.Value Then
                    Gender = [String].Empty

                Else
                    Gender = rw1("Gender").ToString
                End If
                If rw1("District Zone") Is DBNull.Value Then
                    Dist = [String].Empty
                Else
                    Dist = rw1("District Zone").ToString

                End If
                If rw1("School Attending") Is DBNull.Value Then
                    School = [String].Empty

                Else
                    School = rw1("School Attending").ToString
                End If
                If IsDBNull(rw1("Initial Inquiry Date")) = True Then
                    initialinquiry = II.ToString


                    initialinquiry = [String].Empty
                Else

                    II = rw1("Initial Inquiry Date")
                    initialinquiry = II.ToString("m/dd/yyyy")
                End If
                If rw1("Assessment Date") Is DBNull.Value Then

                    assessmentdate = AssDate.ToString()
                    assessmentdate = [String].Empty
                Else
                    AssDate = rw1("Assessment Date")
                    assessmentdate = AssDate.ToString("m/dd/yyyy")
                End If
                If rw1("Report Discussion Date") Is DBNull.Value Then
                    reportdate = RptDate.ToString()

                    reportdate = [String].Empty

                Else
                    RptDate = rw1("Report Discussion Date")
                    reportdate = RptDate.ToString("m/dd/yyyy")
                End If
                If rw1("Tutoring Start Date") Is DBNull.Value Then
                    tutoringstartdate = tutorStart.ToString()
                    tutoringstartdate = [String].Empty
                Else
                    tutorStart = rw1("Tutoring Start Date")
                    tutoringstartdate = tutorStart.ToString("m/dd/yyyy")
                End If
                If rw1("Tutoring Stop Date") Is DBNull.Value Then
                    tutoringstopdate = TutorStop.ToString()
                    tutoringstopdate = [String].Empty
                Else
                    TutorStop = rw1("Tutoring Stop Date")
                    tutoringstopdate = TutorStop.ToString("m/dd/yyyy")
                End If


                Savedata = StudentStoragedt.NewRow
                Savedata("Student FirstName") = StudentFirstname.Trim
                Savedata("Student LastName") = StudentLastname.Trim
                Savedata("DOB") = outputdob.ToString("MM/dd/yyyy")
                Savedata("Gender") = Gender.Trim
                Savedata("School District") = Dist.Trim
                Savedata("School") = School.Trim
                Savedata("Initial Inquiry") = initialinquiry.Trim
                Savedata("Assessment") = assessmentdate.Trim
                Savedata("Report Discussion") = reportdate.Trim
                Savedata("Tutoring Start") = tutoringstartdate.Trim
                Savedata("Tutoring Stop") = tutoringstopdate.Trim


                StudentStoragedt.Rows.Add(Savedata)
            Next

        Next
        Return StudentStoragedt
    End Function
End Class