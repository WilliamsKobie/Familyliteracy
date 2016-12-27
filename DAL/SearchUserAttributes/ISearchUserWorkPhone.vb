Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration

Public Interface ISearchUserWorkPhone
    Function WorkPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection)
End Interface
Public Class StudentUserWorkPhoneNumber
    Implements ISearchUserWorkPhone
    Public Function WorkPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserWorkPhone.WorkPhoneNumber
 
        Return Nothing
    End Function

End Class

Public Class GuardianUserWorkPhoneNumber
    Implements ISearchUserWorkPhone
    Public Function WorkPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserWorkPhone.WorkPhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0

        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianWorkPhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader("Work Phone").ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Work Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class

Public Class ClinicianUserWorkPhoneNumber
    Implements ISearchUserWorkPhone
    Public Function WorkPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserWorkPhone.WorkPhoneNumber

        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchClinicianWorkPhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader(12).ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Work Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function

End Class
