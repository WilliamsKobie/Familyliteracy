Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration
Public Interface ISearchUserAlternateEmail
    Function EmailAddress(useremail As String) As List(Of EmailCollection)
End Interface

Public Class GuardianUserAlternateEmail
    Implements ISearchUserAlternateEmail
    Public Function EmailAddress(ByVal useremail As String) As List(Of EmailCollection) Implements ISearchUserAlternateEmail.EmailAddress
        Dim email As String
        Dim emailIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureEmail As List(Of EmailCollection) = New List(Of EmailCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spSearchGuardianProfileUsingAltEmail"
        cmd.Parameters.AddWithValue("@email", useremail)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureEmail.Add(New EmailCollection(0, useremail, ""))
            While reader.Read()
                emailIndex = emailIndex + 1
                email = reader("Alt Email").ToString()
                captureEmail.Add(New EmailCollection(emailIndex, email, "Alt-Email"))
            End While
        End Using
        conn.Close()
        Return captureEmail
    End Function
End Class



Public Class ClinicianUserAlternateEmail
    Implements ISearchUserEmail
    Public Function EmailAddress(ByVal useremail As String) As List(Of EmailCollection) Implements ISearchUserEmail.EmailAddress
        Dim email As String
        Dim emailIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureEmail As List(Of EmailCollection) = New List(Of EmailCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spSearchClinicianProfileUsingAltEmail"
        cmd.Parameters.AddWithValue("@email", useremail)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureEmail.Add(New EmailCollection(0, useremail, ""))
            While reader.Read()
                emailIndex = emailIndex + 1
                email = reader("Alt Email").ToString()
                captureEmail.Add(New EmailCollection(emailIndex, email, "Alt-Email"))
            End While
        End Using
        conn.Close()

        Return captureEmail
    End Function
End Class
