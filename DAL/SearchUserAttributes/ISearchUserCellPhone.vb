
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration
Public Interface ISearchUserCellPhone
    Function CellPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection)
End Interface

Public Class StudentUserCellPhoneNumber
    Implements ISearchUserCellPhone
    Public Function CellPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserCellPhone.CellPhoneNumber
  

        Return Nothing
    End Function

End Class

Public Class GuardianUserCellPhoneNumber
    Implements ISearchUserCellPhone
    Public Function CellPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserCellPhone.CellPhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianCellPhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader("Cell Phone").ToString().Trim()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Cell Phone"))

            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class

Public Class ClinicianUserCellPhoneNumber
    Implements ISearchUserCellPhone
    Public Function CellPhoneNumber(ByVal phone As String) As List(Of PhoneNumberCollection) Implements ISearchUserCellPhone.CellPhoneNumber
        Dim phoneNum As String
        Dim phoneIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim captureFirstNames As List(Of PhoneNumberCollection) = New List(Of PhoneNumberCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchClinicianCellPhoneNumber"
        cmd.Parameters.AddWithValue("@phoneNumber", phone)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            captureFirstNames.Add(New PhoneNumberCollection(0, phone, ""))
            While reader.Read()
                phoneIndex = phoneIndex + 1
                phoneNum = reader(11).ToString()
                captureFirstNames.Add(New PhoneNumberCollection(phoneIndex, phoneNum, "Cell Phone"))
            End While
        End Using
        conn.Close()

        Return captureFirstNames
    End Function
End Class