Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports DAL
Imports System.Configuration

Public Interface ISearchUserAddress
    Function Address(ByVal useraddress As String) As List(Of MailingAddressCollection)
End Interface



Public Class GuardianUserAddress
    Implements ISearchUserAddress
    Public Function Address(ByVal useraddress As String) As List(Of MailingAddressCollection) Implements ISearchUserAddress.Address
        Dim streetaddress As String
        Dim mailIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim CaptureAddress As List(Of MailingAddressCollection) = New List(Of MailingAddressCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchGuardianAddress"
        cmd.Parameters.AddWithValue("@address", useraddress)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            CaptureAddress.Add(New MailingAddressCollection(0, useraddress))
            While reader.Read()
                mailIndex = mailIndex + 1
                streetaddress = reader("Address").ToString()
                CaptureAddress.Add(New MailingAddressCollection(mailIndex, streetaddress))
            End While
        End Using
        conn.Close()
        Return CaptureAddress
    End Function
End Class



Public Class ClinicianUserAddress
    Implements ISearchUserAddress
    Public Function Address(ByVal useraddress As String) As List(Of MailingAddressCollection) Implements ISearchUserAddress.Address
        Dim streetaddress As String
        Dim mailIndex As Integer = 0
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString

        Dim CaptureAddress As List(Of MailingAddressCollection) = New List(Of MailingAddressCollection)
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()

        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SearchClinicianAddress"
        cmd.Parameters.AddWithValue("@address", useraddress)

        conn.Open()
        Using reader = cmd.ExecuteReader()
            CaptureAddress.Add(New MailingAddressCollection(0, useraddress))
            While reader.Read()
                mailIndex = mailIndex + 1
                streetaddress = reader("Address").ToString()
                CaptureAddress.Add(New MailingAddressCollection(mailIndex, streetaddress))
            End While
        End Using
        conn.Close()

        Return CaptureAddress
    End Function
End Class
