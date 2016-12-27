Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Interface IGuardianEntireProfileSearch



    Function FullName() As Dictionary(Of String, String)

    Function FirstName() As Dictionary(Of String, String)

    Function FaxNumber() As Dictionary(Of String, String)

    Function WorkPhone() As Dictionary(Of String, String)

    Function CellPhone() As Dictionary(Of String, String)

    Function HomePhone() As Dictionary(Of String, String)

    Function LastName() As Dictionary(Of String, String)

    Function EmailAddress() As Dictionary(Of String, String)

    Function AlternateEmailAddress() As Dictionary(Of String, String)

    Function Address() As Dictionary(Of String, String)

End Interface

Public Class SearchGuardianUsingAttributes
    Implements IGuardianEntireProfileSearch

    Public Function FullName() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.FullName

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingFullName")
        CommandParameters.Add("Parameters", "@guardianfullname")
        Return CommandParameters

    End Function
    Public Function FirstName() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.FirstName
        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingFirstName")
        CommandParameters.Add("Parameters", "@firstName")
        Return CommandParameters
    End Function

    Public Function LastName() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.LastName

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingLastName")
        CommandParameters.Add("Parameters", "@lastName")
        Return CommandParameters

    End Function

    Public Function HomePhone() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.HomePhone

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingHomePhone")
        CommandParameters.Add("Parameters", "@homephone")
        Return CommandParameters

    End Function

    Public Function CellPhone() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.CellPhone

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingCellPhone")
        CommandParameters.Add("Parameters", "@cellphone")
        Return CommandParameters

    End Function


    Public Function WorkPhone() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.WorkPhone

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingWorkPhone")
        CommandParameters.Add("Parameters", "@workphone")
        Return CommandParameters

    End Function

    Public Function FaxNumber() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.FaxNumber

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingFaxNumber")
        CommandParameters.Add("Parameters", "@faxnumber")
        Return CommandParameters

    End Function
   

    Public Function EmailAddress() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.EmailAddress

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingEmail")
        CommandParameters.Add("Parameters", "@email")
        Return CommandParameters

    End Function



    Public Function AlternateEmailAddress() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.AlternateEmailAddress

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingAltEmail")
        CommandParameters.Add("Parameters", "@email")
        Return CommandParameters

    End Function
    Public Function Address() As Dictionary(Of String, String) Implements IGuardianEntireProfileSearch.Address

        Dim CommandParameters As New Dictionary(Of String, String)
        CommandParameters.Add("CommandText", "spSearchGuardianProfileUsingAddress")
        CommandParameters.Add("Parameters", "@address")
        Return CommandParameters

    End Function
End Class

Public Delegate Function GuardianDelegate() As Dictionary(Of String, String)
Public Class GuardianProfileData
    Public Shared Function CaptureGuardianData(ByVal value As String, ByVal GuardianAttributeType As GuardianDelegate) As IList(Of GuardianProfileCollection)
        Dim CommandParameters As Dictionary(Of String, String)
        Dim connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Dim Profile As List(Of GuardianProfileCollection) = New List(Of GuardianProfileCollection)
        Dim userid, fname, lname, parentType, email, altemail, address, city, state, zipcode, homephonenumber, cellphone, worknumber, fax As String

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand()
        CommandParameters = GuardianAttributeType()
        Dim paraText As String = CommandParameters.Item("CommandText")
        Dim param As String = CommandParameters.Item("Parameters")
        cmd.CommandText = paraText.Trim()

        cmd.Parameters.AddWithValue(param, value)
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure


        conn.Open()
        Using reader = cmd.ExecuteReader()
            While reader.Read()
                userid = reader(0).ToString()
                fname = reader(2).ToString()
                lname = reader(1).ToString()
                parentType = reader(3).ToString()
                email = reader(4).ToString()
                altemail = reader(5).ToString()
                address = reader(6).ToString()
                city = reader(7).ToString()
                state = reader(8).ToString()
                zipcode = reader(9).ToString()
                homephonenumber = reader(10).ToString()
                cellphone = reader(11).ToString()
                worknumber = reader(12).ToString()
                fax = reader(13).ToString()
                Profile.Add(New GuardianProfileCollection(userid, fname, lname, parentType, email, altemail, address, city, state, zipcode, homephonenumber, cellphone, worknumber, fax))
            End While
        End Using
        conn.Close()
        cmd.Dispose()
        conn.Dispose()
        Return Profile
    End Function
End Class

