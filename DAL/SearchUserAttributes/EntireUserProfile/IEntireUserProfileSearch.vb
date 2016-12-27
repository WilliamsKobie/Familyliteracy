Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration

Public Interface IEntireUserProfileSearch

    Function StudentSearch(ByVal _guardianNo As String) As IList(Of StudentProfileCollection)
    Function GuardianSearch(ByVal _studentID As String) As IList(Of GuardianProfileCollection)
End Interface

Public Class SearchUserProfile
    Implements IEntireUserProfileSearch
    Public Function StudentSearch(ByVal _guardianNo As String) As IList(Of StudentProfileCollection) Implements IEntireUserProfileSearch.StudentSearch
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim Profile As List(Of StudentProfileCollection) = New List(Of StudentProfileCollection)
        Dim studentno, fname, lname, gender, schoolDistrict, school, activeStudent, initialNotes As String
        Dim initialInquiry, birthdate, assessmentDate, reportDiscussionDate, tutoringStartDate, tutoringStopDate As DateTime
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spSearchStudentProfileUsingGuardianNo"
        cmd.Parameters.AddWithValue("@guardianNo", _guardianNo)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            While reader.Read()
                studentno = reader(0).ToString()
                fname = reader(1).ToString()
                lname = reader(2).ToString()
                If Not reader(3).ToString = String.Empty Then
                    birthdate = reader(3)
                End If
                gender = reader(4).ToString()
                schoolDistrict = reader(5).ToString()
                school = reader(6).ToString()
                If Not reader(7).ToString = String.Empty Then
                    initialInquiry = reader(7)
                End If
                If Not reader(8).ToString = String.Empty Then
                    assessmentDate = reader(8)
                End If
                If Not reader(9).ToString = String.Empty Then
                    reportDiscussionDate = reader(9)
                End If
                If Not reader(10).ToString = String.Empty Then
                    tutoringStartDate = reader(10)
                End If
                If Not reader(11).ToString = String.Empty Then
                    tutoringStopDate = reader(11)
                End If
                activeStudent = reader(12).ToString()
                initialNotes = reader(13).ToString()

                Profile.Add(New StudentProfileCollection(studentno, fname, lname, birthdate, gender, schoolDistrict, school, initialInquiry, assessmentDate, reportDiscussionDate, tutoringStartDate, tutoringStopDate, activeStudent, initialNotes))
            End While
        End Using
        conn.Close()
        Return Profile
    End Function
    'Make use of INNER JOIN using student ID number
    Public Function GuardianSearch(ByVal _studentID As String) As IList(Of GuardianProfileCollection) Implements IEntireUserProfileSearch.GuardianSearch
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim Profile As List(Of GuardianProfileCollection) = New List(Of GuardianProfileCollection)

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spSearchGuardianProfileUsingStudentNo"
        cmd.Parameters.AddWithValue("@studentNo", _studentID)
        Dim userid, fname, lname, parentType, email, altemail, address, city, state, zipcode, homephonenumber, cellphone, worknumber, fax As String
        conn.Open()
        Using reader = cmd.ExecuteReader()
            While reader.Read()
                userid = reader(0).ToString()
                fname = reader(2).ToString()
                lname = reader(1).ToString()
                parentType = reader(3).ToString()
                email = reader(4).ToString()
                altemail = reader(5).ToString()
                address = reader(6).ToString()
                city = reader(7).ToString()
                state = reader(8).ToString()
                zipcode = reader(9).ToString()
                homephonenumber = reader(10).ToString()
                cellphone = reader(11).ToString()
                worknumber = reader(12).ToString()
                fax = reader(13).ToString()
                Profile.Add(New GuardianProfileCollection(userid, fname, lname, parentType, email, altemail, address, city, state, zipcode, homephonenumber, cellphone, worknumber, fax))
            End While
        End Using
        conn.Close()
        Return Profile
    End Function
End Class

