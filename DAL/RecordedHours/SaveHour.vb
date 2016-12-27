Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Public Class SaveHour
    Inherits LookupStudent
    Implements ISaveHour

    Dim connectionString As Object


    Function Save(ByVal studentId As String, recordedDate As String, hour As Integer) Implements ISaveHour.Save

        Dim studentExist As New Dictionary(Of String, String)
        'Check to see if student exist
        studentExist = CheckForStudent(studentId)
        If studentExist("RecordExist") = "Yes" Then
            'Update student
            Dim editStudentHour As ISaveHour = New EditStudentHour

            editStudentHour.Save(studentId, recordedDate, hour)
        Else : studentExist("RecordExist") = "No"
            'Add new Student
            Dim addNewHour As ISaveHour = New AddNewStudentHour
            addNewHour.Save(studentId, recordedDate, hour)
        End If
        Return Nothing
    End Function


End Class
