Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


'All the functions within this class return the students Profile Data
'All of the Students Id number 
'Students Reading Level
'All of the students information

Public Class ReturnStudentData
    Private connectionString As Object

    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try
    End Sub
    Public Function StudentReadingLevel(ByVal Studentid As String) As String
        Dim readingLevel As String = String.Empty
        Dim studentno As Int32 = Convert.ToInt32(Studentid)
        Dim query As String = "SELECT * FROM StudentCurrentReadingLevel Where StudentId='" & studentno & "' Order By [Date] ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentCurrentReadingLevel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentCurrentReadingLevel")
        Dim dr As DataRow
        For Each dr In dt.Rows

            readingLevel = dr.Item("Reading_Level")

        Next
        Return readingLevel
    End Function
    Public Function GetID() As Integer
        Dim query As String = "SELECT TOP 1 * FROM StudentProfile ORDER BY  StudentId DESC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentProfile")
        Dim row As DataRow
        Dim studentId As String = String.Empty
        Dim index As String = String.Empty
        For Each row In dt.Rows
            index = row("StudentId")
        Next
        studentId = Convert.ToString(index)
        Return studentId.Trim
    End Function


    Public Overloads Function GetStudentInfo() As DataSet

        Dim query As String = "SELECT * FROM StudentProfile ORDER BY [Last Name] ASC, [First Name] ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentProfile")
        Dim x As Integer = dt.Rows.Count
        Return ds

    End Function

    Public Function AllStudentData() As DataTable

        Dim query As String = "SELECT * FROM StudentProfile ORDER BY [Last Name] ASC, [First Name] ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentProfile")
        Dim x As Integer = dt.Rows.Count
        Return dt


    End Function

    Public Function NonActiveStudentData() As DataTable

        Dim query As String = "SELECT * FROM StudentProfile Where Active='False' ORDER BY [Last Name] ASC, [First Name] ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentProfile")
        Dim x As Integer = dt.Rows.Count
        Return dt


    End Function
    Public Function ActiveStudentData() As DataTable

        Dim query As String = "SELECT * FROM StudentProfile Where Active='True' Order By [Last Name]"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Dim dt As DataTable = ds.Tables("StudentProfile")

        Return dt


    End Function


    Public Overloads Function GetStudentInfo(ByVal searchstring As String, ByVal searchkey As Integer) As DataSet
        Dim convertname As New Schedule
        Dim query As String



        Select Case searchkey
            Case 0
                query = "SELECT * FROM StudentProfile where [First Name] Like '" & searchstring.Trim & "%'"


            Case 1
                query = "SELECT * FROM StudentProfile where [Last Name] Like '" & searchstring.Trim & "%'"


            Case 2
                'Validate any date entry
                Dim temp As Date = CDate(searchstring)
                searchstring = CStr(temp)
                query = "SELECT * FROM StudentProfile where DOB Like '%" & searchstring & "%'"

            Case 3
                query = "SELECT * FROM StudentProfile where [District Zone] Like '%" & searchstring.Trim & "%'"


            Case 4
                query = "SELECT * FROM StudentProfile where [School Attending] Like '%" & searchstring.Trim & "%'"

            Case 5
                query = "SELECT * FROM StudentProfile where [Initial Inquiry Date] Like '%" & searchstring & "%'"

            Case 6
                query = "SELECT * FROM StudentProfile where [Assessment Date] Like '%" & searchstring & "%'"

            Case 7
                query = "SELECT * FROM StudentProfile where [Report Discussion Date] Like '%" & searchstring & "%'"

            Case 8
                query = "SELECT * FROM StudentProfile where [Tutoring Start Date] Like '%" & searchstring & "%'"

            Case 9
                query = "SELECT * FROM StudentProfile where [Tutoring Stop Date] Like '%" & searchstring & "%'"
            Case 10
                query = "Select * From StudentProfile Where [Studentid]='" & searchstring.Trim & "'"
            Case Else
                Return Nothing
        End Select
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "StudentProfile")
        conn.Close()
        Return ds

    End Function

    Public Function studentSchool(ByVal Studentid As String, ByVal Schooldist As String, ByVal School As String, ByVal PrivatePublic As Boolean) As ArrayList
        Dim index As Integer
        index = Convert.ToInt16(Studentid)
        Dim query As String = "SELECT * FROM StudentSchool Where Studentid='" & index & "'"
        Dim conn1 As New SqlConnection(connectionString)
        Dim cmd1 As New SqlCommand(query, conn1)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        Dim schoolInfo As New ArrayList
        conn1.Open()
        da1.Fill(ds1, "StudentSchool")
        conn1.Close()
        Dim dt1 As DataTable = ds1.Tables("StudentSchool")
        Dim dr1 As DataRow
        For Each dr1 In dt1.Rows
            schoolInfo.Add(dr1.Item("SchoolDist"))
            schoolInfo.Add(dr1.Item("SchoolName"))
            schoolInfo.Add(dr1.Item("Prv_Pub"))
        Next

        Return schoolInfo
    End Function
End Class



