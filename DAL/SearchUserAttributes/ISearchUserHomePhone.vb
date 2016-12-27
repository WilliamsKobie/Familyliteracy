
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration

Public Interface ISearchUserHomePhone
    Function HomePhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection)
End Interface

Public Class StudentUserHomePhoneNumber
    Implements ISearchUserHomePhone
    Public Function HomePhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserHomePhone.HomePhoneNumber
    

        Return Nothing
    End Function

End Class

Public Class GuardianUserHomePhoneNumber
    Implements ISearchUserHomePhone
    Public Function HomePhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserHomePhone.HomePhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianHomePhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader("Home Phone").ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Home Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class

Public Class ClinicianUserHomePhoneNumber
    Implements ISearchUserHomePhone
    Public Function HomePhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserHomePhone.HomePhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)

        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchStudentPhoneNumber"
        cmd.Parameters.AddWithValue("@firstname", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader(10).ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Home Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class



