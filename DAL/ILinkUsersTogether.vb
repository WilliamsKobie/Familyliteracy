Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports log4net
Imports log4net.Config

'Links a guardian to a student or links a student to a guardian
Public Interface Ilink
    Function LinkGuardianToStudent(ByVal Sid As String, ByVal Gid As String) As Boolean
    Function LinkStudentToguardian(ByVal Sid As String, ByVal Gid As String) As Boolean
End Interface

'Deletes a connection between a guardian and a student
Public Interface IterminateLink
    Function DeleteLink(ByVal Guardian As String, ByVal Student As String)
End Interface

'Tries to fetch the link between a a student and a guardian.
Public Interface IlocateLinkedUser
    Function LocateGuardian(ByVal studentid As String) As DataTable
    Function EveryUserLink() As DataTable
    Function LocateStudent(ByVal guardianId As String) As DataTable
End Interface



Public Interface IlUsersProfileData

    Function guardian(ByVal studentId As String) As ArrayList
End Interface
Public Class linkUsersTogether
    Implements Ilink
    Implements IterminateLink

    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try

    End Sub
    Public Function LinkGuardianToStudent(ByVal studentid As String, ByVal guardianid As String) As Boolean Implements Ilink.linkGuardianToStudent
        Dim duplicate As Boolean = False
        Dim sid As Integer
        Dim gid As Integer
        sid = Convert.ToInt16(studentid)
        gid = Convert.ToInt16(guardianid)
        Dim query As String = "SELECT * FROM Stud_Guard_Rel Where StudentId='" & sid & "' AND GuardianId='" & gid & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        Dim da As New SqlDataAdapter(cmd)

        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Stud_Guard_Rel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")

        'Check if Student Guardian relationship already exsist

        Dim dr As DataRow

        If dt.Rows.Count < 1 Then
            dr = dt.NewRow()
            dr.Item("Studentid") = sid
            dr.Item("Guardianid") = gid

            dt.Rows.Add(dr)
            duplicate = False

            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "Stud_Guard_Rel")
        End If
        Return duplicate
    End Function

    Public Function DeleteLink(ByVal Guardian As String, ByVal Student As String) Implements IterminateLink.deleteLink

        Dim sid As Integer
        Dim gid As Integer
        sid = Convert.ToInt16(Student)
        gid = Convert.ToInt16(Guardian)
        Dim query As String = "SELECT * FROM Stud_Guard_Rel where Guardianid='" & gid & "' AND Studentid='" & sid & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Stud_Guard_Rel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")


        Dim row As DataRow
        For Each row In dt.Rows
            row.Delete()
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(da)

        da.Update(ds, "Stud_Guard_Rel")
        Return Nothing

    End Function



    Public Function linkStudentToguardian(Sid As String, Gid As String) As Boolean Implements Ilink.linkStudentToguardian
        Return Nothing
    End Function
End Class


Public Class ReturnLinkedUsersTable


    Implements IlocateLinkedUser
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try

    End Sub
    'Private Property query As Object

    Public Function EveryUserLink() As DataTable Implements IlocateLinkedUser.EveryUserLink
        Dim query As String = "SELECT * FROM Stud_Guard_Rel"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Stud_Guard_Rel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")


        Return dt
    End Function

    Public Function Locateguardian(ByVal studentId As String) As DataTable Implements IlocateLinkedUser.LocateGuardian
        Dim index As Integer
        Dim ds As New DataSet
        If studentId <> String.Empty Then
            index = Convert.ToInt16(studentId)
            Dim query As String = "SELECT * FROM Stud_Guard_Rel Where StudentId='" & index & "'"
            Dim conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)

            conn.Open()
            da.Fill(ds, "Stud_Guard_Rel")
            conn.Close()
        End If
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")

        Return dt

    End Function

    Public Function LocateStudent(ByVal guardianId As String) As DataTable Implements IlocateLinkedUser.LocateStudent
        Dim index As Integer
        index = Convert.ToInt16(guardianId)
        Dim query As String = "SELECT * FROM Stud_Guard_Rel Where GuardianId='" & index & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Stud_Guard_Rel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")
        Return dt
    End Function
End Class


Public Class returnUserProfile
    Inherits returnGuardianInfo
    Implements IlUsersProfileData
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasource")
        End Try

    End Sub
    Public Function Guardian(ByVal studentId As String) As ArrayList Implements IlUsersProfileData.guardian
        Dim index As Integer
        index = Convert.ToInt16(studentId)
        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim fullName As String = String.Empty
        Dim guardianData As New ArrayList
        Dim attributes As New ArrayList
        Dim query As String = "SELECT * FROM Stud_Guard_Rel Where StudentId='" & index & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Stud_Guard_Rel")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Stud_Guard_Rel")
        Dim guardianId As Integer
        Dim row As DataRow

        For Each row In dt.Rows
            guardianId = row("GuardianId")
            attributes = ReturnGuardianinfo(Convert.ToString(guardianId).Trim())
            fullName = attributes(1) & ", " & attributes(0)
            guardianData.Add(fullName)
            guardianData.Add(attributes(2))
            guardianData.Add(attributes(3))
            guardianData.Add(attributes(8))
            guardianData.Add(attributes(9))
            guardianData.Add(attributes(10))
            guardianData.Add(attributes(11))
            guardianData.Add(attributes(12))
        Next

        Return guardianData
    End Function
End Class
