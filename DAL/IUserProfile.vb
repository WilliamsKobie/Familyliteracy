Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


'Add a new user entire profile
'Edit a new users entire profile
Public Interface IDeleteUser
    Function DeleteStudent(ByVal Student As String)

End Interface
Public Interface IAddNewUser
    Function AddStudent(ByVal Studentid As String, ByVal Lastname As String, ByVal Firstname As String, ByVal Dob As String, ByVal Gender As String, ByVal SchoolDistrict As String,
                                  ByVal School As String, ByVal initialInquiry As String, ByVal Status As Boolean, ByVal schoolType As Boolean) As Boolean

    Function SetupGuardian(ByVal Guardianid As String, ByVal FirstName As String, ByVal LastName As String, ByVal Address As String,
                                      ByVal City As String, ByVal State As String, ByVal Zipcode As String,
                                      ByVal HomePhone As String, ByVal CellPhone As String, ByVal Workphone As String, ByVal Fax As String,
                                      ByVal OtherPhone As String, ByVal Email As String, ByVal AltEmail As String, ByVal GuardianType As String)
    Function AddNewClinician(ByVal attribute As ArrayList, ByVal clinicianPosition As Integer) As Boolean
End Interface

Public Interface IEditUser
    Function EditStudent(ByVal Studentid As String, ByVal Lastname As String, ByVal Firstname As String, ByVal Dob As String, ByVal Gender As String, ByVal SchoolDistrict As String,
                                    ByVal School As String, ByVal initialInquiry As String, ByVal AssessmentDate As String, ByVal Rptdiscussion As String, ByVal TutorStart As String, ByVal Tutoringstop As String, ByVal Status As Boolean, ByVal readingLevel As String) As Boolean


    Function EditGuardian(ByVal Guardianid As String, ByVal FirstName As String, ByVal LastName As String, ByVal Address As String,
                                     ByVal City As String, ByVal State As String, ByVal Zipcode As String,
                                     ByVal HomePhone As String, ByVal CellPhone As String, ByVal Workphone As String, ByVal Fax As String,
                                    ByVal Email As String, ByVal AltEmail As String, ByVal GuardianType As String)
    Function EditClinician(ByVal attribute As ArrayList) As DataSet
End Interface

Public Class Users

    Implements IDeleteUser
    Implements IAddNewUser
    Implements IEditUser
    Dim connectionString As Object

    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub





    Public Function DeleteStudent(ByVal StudentId As String) Implements IDeleteUser.DeleteStudent
        Dim index As Integer
        index = Convert.ToInt16(Studentid)
        Dim query1 As String = "SELECT StudentID FROM StudentProfile where StudentId='" & index & "'"
        Dim query2 As String = "SELECT * FROM Stud_Guard_Rel where Student='" & index & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd1 As New SqlCommand(query1, conn)
        Dim cmd2 As New SqlCommand(query2, conn)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim da2 As New SqlDataAdapter(cmd2)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        conn.Open()
        da1.Fill(ds1, "StudentProfile")
        da2.Fill(ds2, "Stud_Guard_Rel")
        conn.Close()
        Dim dt1 As DataTable = ds1.Tables("StudentProfile")
        Dim dt2 As DataTable = ds2.Tables("Stud_Guard_Rel")


        Dim row1 As DataRow
        For Each row1 In dt1.Rows
            row1.Delete()
        Next

        Dim row2 As DataRow
        For Each row2 In dt2.Rows
            row2.Delete()
        Next
        Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
        Dim objCommandBuilder2 As New SqlCommandBuilder(da2)


        da1.Update(ds1, "StudentProfile")
        da2.Update(ds2, "Stud_Guard_Rel")
        Return Nothing

    End Function




    Public Overloads Function EditStudent(ByVal Studentid As String, ByVal Lastname As String, ByVal Firstname As String, ByVal Dob As String, ByVal Gender As String, ByVal SchoolDistrict As String,
                                    ByVal School As String, ByVal initialInquiry As String, ByVal AssessmentDate As String, ByVal Rptdiscussion As String, ByVal TutorStart As String, ByVal Tutoringstop As String, ByVal Status As Boolean, ByVal readingLevel As String) As Boolean Implements IEditUser.EditStudent
        Try
            Dim presence As Boolean = True
            Dim DateofBirth As Date
            Dim reportDiscussion As Date
            Dim TutorB As Date
            Dim TutorF As Date
            Dim Assessment As Date
            Dim Inquiry As Date

            Dim studentindex As Integer
            studentindex = Convert.ToInt16(Studentid)


            Dim query As String = "SELECT * FROM StudentProfile Where Studentid='" & studentindex & "'"
            Dim conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            conn.Open()
            da.Fill(ds, "StudentProfile")
            conn.Close()
            Dim dt As DataTable = ds.Tables("StudentProfile")
            Dim dr As DataRow
            For Each dr In dt.Rows
                dr.BeginEdit()

                dr.Item("Last Name") = Lastname
                dr.Item("First Name") = Firstname
                dr.Item("Gender") = Gender
                dr.Item("District Zone") = SchoolDistrict
                dr.Item("School Attending") = School

                If Dob = "  /  /" Then
                    dr.Item("DOB") = DBNull.Value

                Else
                    DateofBirth = Convert.ToDateTime(Dob)
                    dr.Item("DOB") = DateofBirth
                End If

                If initialInquiry = "  /  /" Then

                    dr.Item("Initial Inquiry Date") = DBNull.Value
                Else
                    Inquiry = Convert.ToDateTime(initialInquiry)
                    dr.Item("Initial Inquiry Date") = Inquiry

                End If

                If AssessmentDate = "  /  /" Then

                    dr.Item("Assessment Date") = DBNull.Value
                Else
                    Assessment = Convert.ToDateTime(AssessmentDate)
                    dr.Item("Assessment Date") = Assessment

                End If
                If Rptdiscussion = "  /  /" Then

                    dr.Item("Report Discussion Date") = DBNull.Value
                Else
                    reportDiscussion = Convert.ToDateTime(Rptdiscussion)
                    dr.Item("Report Discussion Date") = reportDiscussion
                End If



                If TutorStart = "  /  /" Then
                    dr.Item("Tutoring Start Date") = DBNull.Value
                Else

                    TutorB = Convert.ToDateTime(TutorStart)
                    dr.Item("Tutoring Start Date") = TutorB
                End If

                If Tutoringstop = "  /  /" Then

                    dr.Item("Tutoring Stop Date") = DBNull.Value
                Else
                    TutorF = Convert.ToDateTime(Tutoringstop)

                    dr.Item("Tutoring Stop Date") = TutorF
                End If



                dr.Item("Active") = Status

                dr.EndEdit()
            Next
            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "StudentProfile")


            Dim query1 As String = "SELECT * FROM StudentCurrentReadingLevel Where StudentId='" & studentindex & "'"
            Dim conn1 As New SqlConnection(connectionString)
            Dim cmd1 As New SqlCommand(query1, conn1)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As New DataSet
            conn1.Open()
            da1.Fill(ds1, "StudentCurrentReadingLevel")
            conn1.Close()
            Dim dt1 As DataTable = ds1.Tables("StudentCurrentReadingLevel")
            Dim dr1 As DataRow


            If dt1.Rows.Count = 0 Then

                dr1 = dt1.NewRow()
                dr1.Item("StudentId") = studentindex
                dr1.Item("Reading Level") = readingLevel.Trim
                dt1.Rows.Add(dr1)
            Else

                For Each dr1 In dt1.Rows
                    dr1.BeginEdit()
                    dr1.Item("Reading Level") = readingLevel.Trim
                    dr1.EndEdit()
                Next


            End If

            Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
            da1.Update(ds1, "StudentCurrentReadingLevel")
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
    Public Function addNewStudent(ByVal Studentid As String, ByVal Lastname As String, ByVal Firstname As String, ByVal Dob As String, ByVal Gender As String, ByVal SchoolDistrict As String,
                                  ByVal School As String, ByVal initialInquiry As String, ByVal Status As Boolean, ByVal schoolType As Boolean) As Boolean Implements IAddNewUser.AddStudent

        Dim studentindex As Integer
        studentindex = Convert.ToInt16(Studentid)
        Dim presence As Boolean = True
        Dim DateofBirth As Date

        Dim reportDiscussion As Date = Nothing
        Dim TutorB As Date = Nothing
        Dim TutorF As Date = Nothing
        Dim Assessment As Date = Nothing
        Dim Inquiry As Date = Nothing

        Dim query As String = "INSERT INTO StudentProfile ([Studentid],[Last Name],[First Name],[DOB],[Gender],[District Zone],[School Attending],[Initial Inquiry Date],Active) VALUES(@Studentid,@LastName,@FirstName,@DOB,@Gender,@DistrictZone,@SchoolAttending,@InitialInquiryDate,@Active)"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)



        If Dob = "  /  /" Then
            cmd.Parameters.AddWithValue("@DOB", DBNull.Value)

        Else
            DateofBirth = Convert.ToDateTime(Dob)
            cmd.Parameters.AddWithValue("@DOB", DateofBirth)
        End If


        If initialInquiry = "  /  /" Then

            cmd.Parameters.AddWithValue("@InitialInquiryDate", DBNull.Value)
        Else
            Inquiry = Convert.ToDateTime(initialInquiry)
            cmd.Parameters.AddWithValue("@InitialInquiryDate", Inquiry)

        End If


        'Store student  information. 
        Dim index As Integer
        index = Convert.ToInt16(Studentid)
        cmd.Parameters.AddWithValue("@Studentid", studentindex)
        cmd.Parameters.AddWithValue("@LastName", Lastname)
        cmd.Parameters.AddWithValue("@FirstName", Firstname)
        cmd.Parameters.AddWithValue("@Gender", Gender)
        cmd.Parameters.AddWithValue("@DistrictZone", SchoolDistrict)
        cmd.Parameters.AddWithValue("@SchoolAttending", School)
        cmd.Parameters.AddWithValue("@Active", Status)


        Dim updated As Integer = 0
        conn.Open()
        updated = cmd.ExecuteNonQuery()
        conn.Close()


        Dim query2 As String = "INSERT INTO StudentSchool ([Studentid],[SchoolDist],[SchoolName],[Prv_Pub]) VALUES(@Studentid,@District,@School,@SchoolType)"
        Dim conn2 As New SqlConnection(connectionString)
        Dim cmd2 As New SqlCommand(query2, conn2)
        cmd2.Parameters.AddWithValue("@Studentid", studentindex)
        cmd2.Parameters.AddWithValue("@District", SchoolDistrict)
        cmd2.Parameters.AddWithValue("@School", School)
        cmd2.Parameters.AddWithValue("@SchoolType", schoolType)

        Return True

    End Function
    Public Function DeleteGuardian(ByVal Guardian As String)
        Dim query1 As String = "SELECT GuardianID FROM GuardianProfile where GuardianID='" & Guardian & "'"
        Dim query2 As String = "SELECT * FROM Stud_Guard_Rel where GuardianID='" & Guardian.Trim & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd1 As New SqlCommand(query1, conn)
        Dim cmd2 As New SqlCommand(query2, conn)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim da2 As New SqlDataAdapter(cmd2)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        conn.Open()
        da1.Fill(ds1, "GuardianProfile")
        da2.Fill(ds2, "Stud_Guard_Rel")
        conn.Close()
        Dim dt1 As DataTable = ds1.Tables("GuardianProfile")
        Dim dt2 As DataTable = ds2.Tables("Stud_Guard_Rel")

        Dim row1 As DataRow
        For Each row1 In dt1.Rows
            row1.Delete()
        Next

        Dim row2 As DataRow
        For Each row2 In dt2.Rows
            row2.Delete()
        Next
        Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
        Dim objCommandBuilder2 As New SqlCommandBuilder(da2)


        da1.Update(ds1, "GuardianProfile")
        da2.Update(ds2, "Stud_Guard_Rel")

        Return Nothing

    End Function

    Public Function SetupGuardian(ByVal Guardianid As String, ByVal FirstName As String, ByVal LastName As String, ByVal Address As String,
                                  ByVal City As String, ByVal State As String, ByVal Zipcode As String,
                                  ByVal HomePhone As String, ByVal CellPhone As String, ByVal Workphone As String, ByVal Fax As String,
                                  ByVal OtherPhone As String, ByVal Email As String, ByVal AltEmail As String, ByVal GuardianType As String) Implements IAddNewUser.SetupGuardian
        Dim guardianIndex As Integer
        guardianIndex = Convert.ToInt16(Guardianid)

        Dim query As String = "SELECT * FROM GuardianProfile where Guardianid='" & guardianIndex & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        Dim da As New SqlDataAdapter(cmd)

        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim present As Integer = dt.Rows.Count - 1
        If present < 0 Then
            Dim dr As DataRow

            dr = dt.NewRow()
            dr.Item("GuardianID") = guardianIndex
            dr.Item("First Name") = FirstName.Trim.ToString
            dr.Item("Last Name") = LastName.Trim.ToString
            dr.Item("Email") = Email.Trim.ToString
            dr.Item("Alt Email") = AltEmail.ToString.Trim
            dr.Item("Address") = Address.ToString.Trim
            dr.Item("City") = City.ToString.Trim
            dr.Item("State") = State.ToString.Trim
            dr.Item("Zip Code") = Zipcode.ToString.Trim
            dr.Item("Home Phone") = HomePhone.ToString.Trim
            dr.Item("Cell Phone") = CellPhone.ToString.Trim
            dr.Item("Work Phone") = Workphone.ToString.Trim
            dr.Item("Fax") = Fax.ToString.Trim



            dr.Item("Guardian Type") = GuardianType.ToString.Trim


            dt.Rows.Add(dr)

            Dim objCommandBuilder0 As New SqlCommandBuilder(da)
            da.Update(ds, "GuardianProfile")
            MsgBox(FirstName & " " & LastName & " has been added.")
        Else
            MsgBox(FirstName & " " & LastName & " already exsist.")
        End If


        Return Nothing
    End Function

    Public Function EditGuardian(ByVal Guardianid As String, ByVal FirstName As String, ByVal LastName As String, ByVal Address As String,
                                  ByVal City As String, ByVal State As String, ByVal Zipcode As String,
                                  ByVal HomePhone As String, ByVal CellPhone As String, ByVal Workphone As String, ByVal Fax As String,
                                  ByVal Email As String, ByVal AltEmail As String, ByVal GuardianType As String) Implements IEditUser.EditGuardian


        Dim guardianIndex As Integer
        guardianIndex = Convert.ToInt16(Guardianid)
        Dim query As String = "SELECT * FROM GuardianProfile Where GuardianId='" & guardianIndex & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim dr As DataRow
        For Each dr In dt.Rows
            dr.BeginEdit()
            dr.Item("GuardianID") = guardianIndex
            dr.Item("First Name") = FirstName.ToString.Trim
            dr.Item("Last Name") = LastName.ToString.Trim
            dr.Item("Email") = Email.ToString.Trim
            dr.Item("Alt Email") = AltEmail.ToString.Trim
            dr.Item("Address") = Address.ToString.Trim
            dr.Item("City") = City.ToString.Trim
            dr.Item("State") = State.ToString.Trim
            dr.Item("Zip Code") = Zipcode.ToString.Trim
            dr.Item("Home Phone") = HomePhone.ToString.Trim
            dr.Item("Cell Phone") = CellPhone.ToString.Trim
            dr.Item("Work Phone") = Workphone.ToString.Trim
            dr.Item("Fax") = Fax.ToString.Trim


            dr.Item("Guardian Type") = GuardianType.ToString.Trim
            dr.EndEdit()
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "GuardianProfile")
        MsgBox(FirstName & " " & LastName & " information has been updated.", vbOKOnly, "Guardian Information")
        Return Nothing
    End Function
    Public Function addNewClinician(ByVal attribute As ArrayList, ByVal clinicianPosition As Integer) As Boolean Implements IAddNewUser.AddNewClinician
        'Store Values for a New Clinician

      
            Dim query As String = "SELECT * FROM Clinician"
       
            Dim conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)

            Dim da As New SqlDataAdapter(cmd)

            Dim ds As New DataSet
            conn.Open()
            da.Fill(ds, "Clinician")

            Dim dt As DataTable = ds.Tables("Clinician")

            Dim dr As DataRow
      

            dr = dt.NewRow()
            dr.Item("ClinicianID") = attribute(0).ToString.Trim
        dr.Item("LastName") = attribute(1).ToString.Trim
        dr.Item("FirstName") = attribute(2).ToString.Trim
            dr.Item("Phone") = attribute(3).ToString.Trim
            dr.Item("Cellular") = attribute(4).ToString.Trim
            dr.Item("Alt Phone") = attribute(5).ToString.Trim
            dr.Item("Email") = attribute(6).ToString.Trim
            dr.Item("Address") = attribute(7).ToString.Trim
            dr.Item("City") = attribute(8).ToString.Trim
            dr.Item("State") = attribute(9).ToString.Trim
            dr.Item("Zip") = attribute(10).ToString.Trim
            dr.Item("Inactive") = attribute(11).ToString.Trim
            dr.Item("AutoSelect") = attribute(12).ToString.Trim
            dr.Item("ClinicianOrder") = clinicianPosition
            dt.Rows.Add(dr)

            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "Clinician")
            Return True

     

    End Function

    Public Overloads Function EditClinician(ByVal attribute As ArrayList) As DataSet Implements IEditUser.EditClinician
        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim query As String = "SELECT * FROM Clinician Where Clinicianid='" & attribute(0) & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim dr As DataRow

        For Each dr In dt.Rows
            
            dr.BeginEdit()
            dr.Item("ClinicianID") = attribute(0).ToString.Trim
            dr.Item("LastName") = attribute(1).ToString.Trim
            dr.Item("FirstName") = attribute(2).ToString.Trim
            dr.Item("Phone") = attribute(3).ToString.Trim
            dr.Item("Cellular") = attribute(4).ToString.Trim
            dr.Item("Alt Phone") = attribute(5).ToString.Trim
            dr.Item("Email") = attribute(6).ToString.Trim
            dr.Item("Address") = attribute(7).ToString.Trim
            dr.Item("City") = attribute(8).ToString.Trim

            dr.Item("State") = attribute(9).ToString.Trim
            dr.Item("Zip") = attribute(10).ToString.Trim
            If attribute(0).ToString.Trim = "018c" Then 'TRI dummy account
                dr.Item("Inactive") = True
            Else
                dr.Item("Inactive") = Convert.ToBoolean(attribute(11).ToString.Trim)
            End If

            dr.Item("AutoSelect") = Convert.ToBoolean(attribute(12).ToString.Trim)
            dr.EndEdit()
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "Clinician")

        Return ds
    End Function
End Class
