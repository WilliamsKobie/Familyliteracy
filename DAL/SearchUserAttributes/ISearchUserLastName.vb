
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration


Public Interface ISearchUserLastName
    Function LastName(ByVal lname As String) As List(Of UserNameCollection)
End Interface



Public Class StudentUserLastName
    Implements ISearchUserLastName

    Public Function LastName(ByVal lname As String) As List(Of UserNameCollection) Implements ISearchUserLastName.LastName
        Dim name As String
        Dim nameIndex As Integer = 0

        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureLastNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchStudentLastName"
        cmd.Parameters.AddWithValue("@lastname", lname)

        conn.Open()

        Using reader = cmd.ExecuteReader()
            captureLastNames.Add(New UserNameCollection(0, lname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureLastNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()
        cmd.Dispose()
        Return captureLastNames
    End Function
End Class

Public Class GuardianUserLastName
    Implements ISearchUserLastName
    Public Function LastName(ByVal lname As String) As List(Of UserNameCollection) Implements ISearchUserLastName.LastName
        Dim name As String
        Dim nameIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureLastNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianLastName"
        cmd.Parameters.AddWithValue("@lastname", lname)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureLastNames.Add(New UserNameCollection(0, lname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureLastNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()
        cmd.Dispose()
        conn.Dispose()
        Return captureLastNames
    End Function
End Class

Public Class ClincianUserLastName
    Implements ISearchUserLastName
    Public Function LastName(ByVal lname As String) As List(Of UserNameCollection) Implements ISearchUserLastName.LastName
        Dim name As String
        Dim nameIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureLastNames As List(Of UserNameCollection) = New List(Of UserNameCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchClinicianLastName"
        cmd.Parameters.AddWithValue("@lastname", lname)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureLastNames.Add(New UserNameCollection(0, lname))
            While reader.Read()
                nameIndex = nameIndex + 1
                name = reader(0).ToString()
                captureLastNames.Add(New UserNameCollection(nameIndex, name))
            End While
        End Using
        conn.Close()
        cmd.Dispose()
        Return captureLastNames
    End Function
End Class




