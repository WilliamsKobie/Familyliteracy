Public Class AttributeListing

    Public Shared Function GenerateList(ByVal studentidlist As List(Of String), ByVal active As String) As List(Of Attributes)
        Dim db As FamilyLiteracyEntityDataModel = New FamilyLiteracyEntityDataModel()
        Dim student As List(Of Attributes) = New List(Of Attributes)

        ' Dim list = From p In db.StudentProfiles
        ' Select p
        Dim attributecollection = Nothing

        For Each studentnumber In studentidlist
            Select Case (active)
                Case "all"
                    attributecollection = From jointable In db.Stud_Guard_Rel
                             Join stud In db.StudentProfiles
                             On stud.StudentID Equals jointable.StudentID
                             Join parent In db.GuardianProfiles
                             On parent.GuardianID Equals jointable.GuardianID
                            Where stud.StudentID = studentnumber

                Case "active"
                    attributecollection = From jointable In db.Stud_Guard_Rel
                                                                   Join stud In db.StudentProfiles
                                                                   On stud.StudentID Equals jointable.StudentID
                                                                   Join parent In db.GuardianProfiles
                                                                   On parent.GuardianID Equals jointable.GuardianID
                                                                   Where stud.StudentID = studentnumber And stud.Active = True

                Case "inActive"

                    attributecollection = From jointable In db.Stud_Guard_Rel
                           Join stud In db.StudentProfiles
                           On stud.StudentID Equals jointable.StudentID
                           Join parent In db.GuardianProfiles
                           On parent.GuardianID Equals jointable.GuardianID
                           Where stud.StudentID = studentnumber And stud.Active = False


            End Select







            For Each item In attributecollection

                Dim fname As String = item.stud.First_Name

                Dim lname As String = item.stud.Last_Name
                Debug.WriteLine(fname & " " & lname)
                'Debug.Assert(lname = "Sims")
                Dim activestudent As String = item.stud.Active
                Dim dob As DateTime = Convert.ToDateTime(item.stud.DOB)
                Dim zone As String = item.stud.District_Zone
                Dim school As String = item.stud.School_Attending
                Dim sex As String = item.stud.Gender
                Dim assessment As DateTime = Convert.ToDateTime(item.stud.Assessment_Date)
                Dim rpt As DateTime = Convert.ToDateTime(item.stud.Report_Discussion_Date)
                Dim inquiry As DateTime = Convert.ToDateTime(item.stud.Initial_Inquiry_Date)
                Dim notes As String = item.stud.InitialNotes
                Dim tutorstart As DateTime = Convert.ToDateTime(item.stud.Tutoring_Start_Date)
                Dim tutorstop As DateTime = Convert.ToDateTime(item.stud.Tutoring_Stop_Date)
                Dim address = item.parent.Address
                Dim city = item.parent.City
                Dim state = item.parent.State
                Dim zip = item.parent.Zip_Code
                Dim phone1 = item.parent.Cell_Phone
                Dim phone2 = item.parent.Home_Phone
                Dim phone3 = item.parent.Work_Phone
                Dim phone4 = item.parent.Fax
                Dim tutortype = item.parent.Guardian_Type
                Dim guardianfirstname = item.parent.First_Name
                Dim guardianlastname = item.parent.Last_Name
                Dim email1 = item.parent.Email
                Dim email2 = item.parent.Email
                student.Add(New Attributes(fname, lname, dob, zone, school, sex, assessment, rpt, inquiry, notes, tutorstart, tutorstop, "0", activestudent, address, city, state, zip, phone1, phone2, phone3, phone4, email1, email2, tutortype, guardianfirstname, guardianlastname))
            Next
        Next
        Return student
    End Function




End Class

Public Class Attributes





    Sub New(ByVal _firstName As String, ByVal _lastname As String, ByVal _dob As DateTime, ByVal _school As String, ByVal _schoolzone As String,
            ByVal _gender As String, ByVal _assess As DateTime, ByVal _report As DateTime, ByVal _initialinquiry As DateTime,
            ByVal _initialNotes As String, ByVal _starttutor As DateTime, ByVal _stoptutor As DateTime, ByVal _hours As String,
            ByVal _activestudent As String, ByVal _address As String, ByVal _city As String, ByVal _state As String, ByVal _zipcode As String, ByVal _phone1 As String,
            ByVal _phone2 As String, ByVal _phone3 As String, ByVal _phone4 As String, ByVal _email1 As String, ByVal _email2 As String, ByVal _tutortype As String,
            ByVal _guardianfname As String, ByVal _guardianlname As String)

        If _dob = #12:00:00 AM# Then
            Me.Date_of_Birth = String.Empty
        Else
            Me.Date_of_Birth = _dob.ToString("ddd M/dd/yyyy")
        End If


        If _initialinquiry = #12:00:00 AM# Then
            Me.Initial_Inquiry = String.Empty
        Else
            Me.Initial_Inquiry = _initialinquiry.ToString("ddd M/dd/yyyy")
        End If

        If _assess = #12:00:00 AM# Then
            Me.Assessment = String.Empty
        Else
            Me.Assessment = _assess.ToString("ddd M/dd/yyyy")
        End If

        If _report = #12:00:00 AM# Then
            Me.Report_Discussion = String.Empty
        Else
            Me.Report_Discussion = _report.ToString("ddd M/dd/yyyy")
        End If

        If _starttutor = #12:00:00 AM# Then
            Me.Tutoring_Start = String.Empty
        Else
            Me.Tutoring_Start = _starttutor.ToString("ddd M/dd/yyyy")
        End If

        If _stoptutor = #12:00:00 AM# Then
            Me.Tutoring_Stop = String.Empty
        Else
            Me.Tutoring_Stop = _stoptutor.ToString("ddd M/dd/yyyy")
        End If
        Dim _fullname As String = _lastname & ", " & _firstName
        Me.First_Name = _firstName
        Me.Last_Name = _lastname
        Me.Hours_Cleared = _hours
        Me.Full_Name = _fullname

        Me.Gender = _gender
        Me.District = _schoolzone
        Me.School_Attending = _school
        Me.Active = _activestudent
        Me.Address = _address
        Me.City = _city
        Me.State = _state
        Me.Zip_Code = _zipcode
        Me.Guardian_FirstName = _guardianfname
        Me.Guardian_LastName = _guardianlname
        Dim _guardianfullname As String = _guardianfname + " " + _guardianlname
        Me.Guardian_Name = _guardianfullname
        If _phone1 = Nothing Then
            _phone1 = String.Empty
        End If
        If _phone2 = Nothing Then
            _phone2 = String.Empty
        End If
        If _phone3 = Nothing Then
            _phone3 = String.Empty
        End If
        If _phone4 = Nothing Then
            _phone4 = String.Empty
        End If
        If _email1 = Nothing Then
            _email1 = String.Empty
        End If

        If _email2 = Nothing Then
            _email2 = String.Empty
        End If
        Me.Cell_Phone = _phone1
        Me.Home_Phone = _phone2
        Me.Work_Phone = _phone3



        Me.Fax = _phone4
        Me.Email = _email1
        Me.Alternate_Email = _email2

    End Sub
    Public Property Active As String
    Public Property Full_Name As String

    Public Property First_Name As String

    Public Property Last_Name As String

    Public Property Gender As String
    Public Property Date_of_Birth As String
    Public Property School_Attending As String
    Public Property District As String
    Public Property Initial_Inquiry As String
    Public Property Assessment As String
    Public Property Report_Discussion As String

    Public Property Tutoring_Start As String

    Public Property Tutoring_Stop As String

    Public Property Hours_Cleared As String

    Public Property Guardian_Name As String


    Public Property Guardian_FirstName As String

    Public Property Guardian_LastName As String

    Public Property Address As String

    Public Property City As String

    Public Property State As String

    Public Property Zip_Code As String

    Public Property Cell_Phone As String


    Public Property Email As String

    Public Property Alternate_Email As String

    Public Property Home_Phone As String

    Public Property Work_Phone As String

    Public Property Fax As String


  
  

   

   




End Class

