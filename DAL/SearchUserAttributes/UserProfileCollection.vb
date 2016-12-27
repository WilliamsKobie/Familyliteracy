Public Class GuardianProfileCollection

    Sub New(ByVal _userno As String, ByVal _fname As String, ByVal _lName As String, ByVal _parentType As String, ByVal _email As String, ByVal _altemail As String, ByVal _address As String, ByVal _city As String, ByVal _state As String, ByVal _zipcode As String, ByVal _homephone As String, ByVal _cellphone As String, ByVal _workphone As String, ByVal _faxnumber As String)
        UserNo = _userno
        First_Name = _fname
        Last_Name = _lName
        Guardian_Type = _parentType
        Email = _email
        Alternate_Email = _altemail
        StreetAddress = _address
        City = _city
        State = _state
        Zip_Code = _zipcode
        Home_Phone = _homephone
        Cell_Phone = _cellphone
        Work_Phone = _workphone
        Fax_Number = _faxnumber

    End Sub
    Public Property UserNo As String

    Public Property Last_Name As String

    Public Property First_Name As String



    Public Property Guardian_Type As String

    Public Property Email As String

    Public Property Alternate_Email As String

    Public Property StreetAddress As String

    Public Property City As String

    Public Property State As String

    Public Property Zip_Code As String

    Public Property Home_Phone As String

    Public Property Cell_Phone As String

    Public Property Work_Phone As String

    Public Property Fax_Number As String

End Class

Public Class StudentProfileCollection

    Public Sub New(ByVal _studentno As String, ByVal _fname As String, ByVal _lname As String, ByVal _birthDate As DateTime, ByVal _gender As String, ByVal _schoolDistrict As String, ByVal _school As String, ByVal _initialInquiry As DateTime, ByVal _assessmentDate As DateTime, ByVal _rptDiscussionDate As DateTime, ByVal _tutoringStartDate As DateTime, ByVal _tutoringStopDate As DateTime, ByVal _activeStudent As String, ByVal _initialNotes As String)
        StudentNo = _studentno
        First_Name = _fname
        Last_Name = _lname
        BirthDate = _birthDate
        Gender = _gender
        School_District = _schoolDistrict
        School = _school
        Initial_Inquiry = _initialInquiry
        Assessment_Date = _assessmentDate
        Report_Discussion_Date = _rptDiscussionDate
        Tutoring_Start_Date = _tutoringStartDate
        Tutoring_Stop_Date = _tutoringStopDate
        Active = _activeStudent
        Notes = _initialNotes

    End Sub

    Public Property StudentNo As String

    Public Property First_Name As String

    Public Property Last_Name As String

    Public Property BirthDate As DateTime

    Public Property Gender As String

    Public Property School_District As String

    Public Property School As String

    Public Property Initial_Inquiry As DateTime

    Public Property Assessment_Date As DateTime

    Public Property Report_Discussion_Date As DateTime

    Public Property Tutoring_Start_Date As DateTime

    Public Property Tutoring_Stop_Date As DateTime

    Public Property Active As String

    Public Property Notes As String

End Class
