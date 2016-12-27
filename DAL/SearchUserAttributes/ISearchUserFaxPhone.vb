Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration

Public Interface ISearchUserFaxPhone
    Function FaxPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection)
End Interface

Public Class StudentUserFaxPhoneNumber
    Implements ISearchUserFaxPhone
    Public Function FaxPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserFaxPhone.FaxPhoneNumber
        Return Nothing
    End Function

End Class

Public Class GuardianUserFaxPhoneNumber
    Implements ISearchUserFaxPhone
    Public Function FaxPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserFaxPhone.FaxPhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianFaxPhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader("Fax").ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Fax Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class

Public Class ClinicianUserFaxPhoneNumber
    Implements ISearchUserFaxPhone
    Public Function FaxPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserFaxPhone.FaxPhoneNumber
        Return Nothing
    End Function

End Class


