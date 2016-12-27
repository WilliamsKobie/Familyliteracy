Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Interface IuserContactProfiler
    Function CaptureProfile() As IEnumerable
End Interface
Public Class StudentPersonalContacts : Implements IuserContactProfiler

    Dim connection As String
    Public Function CaptureProfile() As IEnumerable Implements IuserContactProfiler.CaptureProfile


        Dim ContactProfile As New List(Of PersonalContactCollection)
        Dim guardianLastName As String = ""
        Dim guardianFirstName As String = ""
        Dim email As String = ""
        Dim alternateEmail As String = ""
        Dim cellPhone As String = ""
        Dim workPhone As String = ""
        Dim homePhone As String = ""
        Dim studentFirstName As String = ""
        Dim studentLastName As String = ""
   
        Dim query As String = "SELECT dbo.GuardianProfile.[Last Name], dbo.GuardianProfile.[First Name], dbo.GuardianProfile.Email, dbo.GuardianProfile.[Alt Email], dbo.GuardianProfile.[Cell Phone], dbo.GuardianProfile.[Work Phone]," & _
                 " dbo.GuardianProfile.[Home Phone], dbo.StudentProfile.[First Name] AS StudentFirstname, dbo.StudentProfile.[Last Name] AS StudentLastName" & _
                 " FROM dbo.Stud_Guard_Rel INNER JOIN" & _
                 " dbo.StudentProfile ON dbo.Stud_Guard_Rel.StudentID = dbo.StudentProfile.StudentID INNER JOIN" & _
                 " dbo.GuardianProfile ON dbo.Stud_Guard_Rel.GuardianID = dbo.GuardianProfile.GuardianID" & _
                 " ORDER BY dbo.GuardianProfile.[Last Name] ASC, dbo.GuardianProfile.[First Name] ASC"

            connection = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString()
            Dim conn As New SqlConnection(connection)
            Dim cmd As New SqlCommand(query, conn)
            conn.Open()

            Dim reader = cmd.ExecuteReader()
            Do While (reader.Read)

                If IsDBNull(reader.GetValue(0)) = False Then
                    guardianLastName = reader.GetString(0).ToString()
                End If
               
                If Not IsDBNull(reader.GetValue(1)) Then
                    guardianFirstName = reader.GetString(1).ToString()
                End If

                If Not IsDBNull(reader.GetValue(2)) Then
                    email = (reader.GetString(2)).ToString()
                End If

                If Not IsDBNull(reader.GetValue(3)) Then
                    alternateEmail = reader.GetString(3).ToString()
                End If

                If Not IsDBNull(reader.GetValue(4)) Then
                    cellPhone = reader.GetString(4).ToString()
                End If

                If Not IsDBNull(reader.GetValue(5)) Then
                    workPhone = reader.GetString(5).ToString()
                End If

                If Not IsDBNull(reader.GetValue(6)) Then
                    homePhone = reader.GetString(6).ToString()
                End If

                If Not IsDBNull(reader.GetValue(7)) Then
                    studentFirstName = reader.GetString(7).ToString()
                End If

            If Not IsDBNull(reader.GetValue(8)) Then
                studentLastName = reader.GetString(8).ToString()
            End If


                ContactProfile.Add(New PersonalContactCollection(studentFirstName, studentLastName, guardianFirstName, guardianLastName, cellPhone, homePhone, workPhone, email, alternateEmail))


            Loop
            conn.Close()
            Return ContactProfile
       
    End Function
End Class

Public Class PersonalContactCollection
    Public Sub New(ByVal _studentFirstName As String, ByVal _studentLastName As String, ByVal _guardianFirstName As String, ByVal _guardianLastName As String, ByVal _cellPhone As String, ByVal _homePhone As String, ByVal _workphone As String, ByVal _email As String, ByVal _alternateEmail As String)
        Student_First_Name = _studentFirstName
        Student_Last_Name = _studentLastName

        Guardian_FirstName = _guardianFirstName
        Guardian_LastName = _guardianLastName
        Cell_Phone = _cellPhone
        Work_Phone = _workphone
        Home_Phone = _homePhone
        Email = _email
        AlternateEmail = _alternateEmail

    End Sub

    Public Property Student_First_Name As String

    Public Property Student_Last_Name As String



    Public Property Guardian_FirstName As String

    Public Property Guardian_LastName As String

    Public Property Cell_Phone As String

    Public Property Work_Phone As String

    Public Property Home_Phone As String

    Public Property Email As String

    Public Property AlternateEmail As String

End Class
