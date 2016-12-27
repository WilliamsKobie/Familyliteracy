Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


'Fetch all profile information pertaining to the guardians.
Public Class ReturnGuardianInfo

    Dim connectionString As Object

    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try

    End Sub

    Public Overloads Function GetGuardianInfo() As DataSet
        Dim query As String = "SELECT * FROM GuardianProfile Order by [Last Name] ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")

        conn.Close()
        Return ds
    End Function

    'Return guardian information using first and last name
    Public Overloads Function ReturnGuardianinfo(ByVal fn As String, ByVal ln As String) As String

        Dim Guardian As String = String.Empty



        Dim query As String = "SELECT * FROM GuardianProfile where [First Name]='" & fn & "'" & " AND [Last Name]='" & ln & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim rw As DataRow


        For Each rw In dt.Rows

            Guardian = Convert.ToString(rw("GuardianId"))
        Next
        Return Guardian

    End Function




    Public Overloads Function GetID() As String
        Dim query As String = "SELECT * FROM GuardianProfile Order BY GuardianId ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim row As DataRow

        Dim newIndex As String = String.Empty
        For Each row In dt.Rows
            newIndex = row("GuardianId")
        Next

        Return newIndex
    End Function

    Public Overloads Function returnGuardianInfo(ByVal GuardianId As String) As ArrayList
        Dim index As Integer
        index = Convert.ToInt16(GuardianId)
        Dim query As String = "SELECT * FROM GuardianProfile where GuardianId='" & index & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim attributes As New ArrayList()
        Dim row As DataRow
        For Each row In dt.Rows
            attributes.Add(row("First Name")).ToString.Trim()
            attributes.Add(row("Last Name")).ToString.Trim()
            attributes.Add(row("Email")).ToString.Trim()
            attributes.Add(row("Alt Email")).ToString.Trim()
            attributes.Add(row("Address")).ToString.Trim()
            attributes.Add(row("City")).ToString.Trim()
            attributes.Add(row("State")).ToString.Trim()
            attributes.Add(row("Zip Code")).ToString.Trim()
            attributes.Add(row("Home Phone")).ToString.Trim()
            attributes.Add(row("Cell Phone")).ToString.Trim()
            attributes.Add(row("Work Phone")).ToString.Trim()
            attributes.Add(row("Fax")).ToString.Trim()

            attributes.Add(row("Guardian Type")).ToString.Trim()

        Next

        Return attributes

    End Function
    Public Function guardianInfo(ByVal GuardianId As String) As DataTable
        Dim guardianIndex As Integer
        guardianIndex = Convert.ToInt16(GuardianId)
        Dim query As String = "SELECT * FROM GuardianProfile where GuardianId='" & guardianIndex & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")


        Return dt

    End Function

    'Returns guardian information using a filter
    Public Overloads Function GetGuardianInfo(ByVal searchstring As String, ByVal Searchkey As Integer) As DataSet

        Dim query As String

        Select Case Searchkey
            Case 0
                query = "SELECT * FROM GuardianProfile where [First Name] Like '" & searchstring & "%'"


            Case 1
                query = "SELECT * FROM GuardianProfile where [Last Name] Like '" & searchstring & "%'"


            Case 2
                query = "SELECT * FROM GuardianProfile where [Guardian Type] Like '" & searchstring & "%'"

            Case 3
                query = "SELECT * FROM GuardianProfile where Email Like '" & searchstring & "%'"

            Case 4
                query = "SELECT * FROM GuardianProfile where [Alt Email] Like '" & searchstring & "%'"

            Case 5
                query = "SELECT * FROM GuardianProfile where guardianid='" & Convert.ToInt16(searchstring) & "'"

            Case Else
                Return Nothing
        End Select
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Return ds

    End Function
    'Send a 'Flag' if there is a guardian with the same first and last name ready exsisting inside of the data source
    Public Function CheckForDuplicateguardian(ByVal firstName As String, ByVal lastName As String)
        Dim duplicate As Boolean
        Dim query As String = "SELECT * FROM guardianProfile Where [First Name]='" & firstName & "' AND [Last Name]='" & lastName & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "GuardianProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("GuardianProfile")
        Dim x As Integer = 0
        If dt.Rows.Count < 1 Then
            duplicate = False
        Else
            duplicate = True
        End If


        Return duplicate
    End Function
End Class



