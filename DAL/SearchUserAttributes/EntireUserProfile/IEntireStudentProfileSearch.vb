Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Interface IEntireStudentProfileSearch

    Function StudentIDNumber(_studentNo As String) As Dictionary(Of String, String)
    Function StudentFullname(ByVal _fullName As String) As Dictionary(Of String, String)
End Interface

Public Class SearchStudentUsingAttributes
    Implements IEntireStudentProfileSearch
    Public Function StudentIDNumber(ByVal _studentNo As String) As Dictionary(Of String, String) Implements IEntireStudentProfileSearch.StudentIDNumber
        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchStudentProfileUsingStudentNo")
        CommandParameters.Add("ParameterAttributeType", "@studentNo")
        Return CommandParameters
    End Function
    Public Function StudentFullname(ByVal _fullName As String) As Dictionary(Of String, String) Implements IEntireStudentProfileSearch.StudentFullname
        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchStudentProfileUsingFullName")
        CommandParameters.Add("ParameterAttributeType", "@studentfullname")

        Return CommandParameters
    End Function

End Class



Public Delegate Function StudentProfileDelegatesearch(ByVal _studentAttribute As String)
Public Class SearchStudentUserProfile

    Public Shared Function SearchStudentProfileTable(ByVal _studentAttribute As String, ByVal StudentProfileDelegate As StudentProfileDelegatesearch) As IList(Of StudentProfileCollection)
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim Profile As List(Of StudentProfileCollection) = New List(Of StudentProfileCollection)
        Dim CommandParameters As New Dictionary(Of String, String)
        Dim studentno, fname, lname, gender, schoolDistrict, school, activeStudent, initialNotes As String
        Dim initialInquiry, birthdate, assessmentDate, reportDiscussionDate, tutoringStartDate, tutoringStopDate As DateTime
        CommandParameters = StudentProfileDelegate(_studentAttribute)
        Dim paraText As String = CommandParameters.Item("CommandText")
        Dim param As String = CommandParameters.Item("ParameterAttributeType")
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandText = paraText
        cmd.Parameters.AddWithValue(param, _studentAttribute)
        cmd.CommandType = CommandType.StoredProcedure

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
End Class

