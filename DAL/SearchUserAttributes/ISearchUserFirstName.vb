
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration
Public Interface ISearchUserFirstName
    Function FirstName(ByVal fname As String) As List(Of UserNameCollection)
End Interface


Public Class StudentUserFirstName
    Implements ISearchUserFirstName
    Public Function FirstName(ByVal fname As String) As List(Of UserNameCollection) Implements ISearchUserFirstName.FirstName
        Dim name As String
        Dim nameIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchStudentFirstName"
        cmd.Parameters.AddWithValue("@firstname", fname)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New UserNameCollection(0, fname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureFirstNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function

End Class

Public Class GuardianUserFirstName
    Implements ISearchUserFirstName
    Public Function FirstName(ByVal fname As String) As List(Of UserNameCollection) Implements ISearchUserFirstName.FirstName
        Dim name As String
        Dim nameIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianFirstName"
        cmd.Parameters.AddWithValue("@firstname", fname)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New UserNameCollection(0, fname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureFirstNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class

Public Class ClinicianUserFirstName
    Implements ISearchUserFirstName
    Public Function FirstName(ByVal fname As String) As List(Of UserNameCollection) Implements ISearchUserFirstName.FirstName
        Dim name As String
        Dim nameIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchClinicianFirstName"
        cmd.Parameters.AddWithValue("@firstname", fname)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New UserNameCollection(0, fname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureFirstNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class



