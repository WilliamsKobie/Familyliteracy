Imports System

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

'Update a users specific attributes

Public Interface IUpdateClincianAttributes
    Function clincianDisplayOrder(ByVal clincianId As String, ByVal ordernumber As Integer)
    Function clinicianStatus(ByVal attribute As Boolean, ByVal Id As String)

End Interface

Public Interface IUpdateStudentAttributes

    Function editNote(ByVal Studentid As String, ByVal noteid As Integer, ByVal noteheader As String, ByVal note As String, ByVal Date1 As Date) As Boolean
    Function editStudentSchool(ByVal Studentid As String, ByVal Schooldist As String, ByVal School As String, ByVal PrivatePublic As Boolean)
    Function DeleteNote(ByVal Studentid As String, ByVal noteid As Integer)

End Interface

Public Class UserAttributes
    Implements IUpdateClincianAttributes
    Implements IUpdateStudentAttributes
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasbase!")
        End Try
    End Sub
    Public Function clincianDisplayOrder(ByVal clincianId As String, ByVal ordernumber As Integer) Implements IUpdateClincianAttributes.clincianDisplayOrder
        Try
            Dim query As String = "SELECT * FROM Clinician Where ClinicianId='" & clincianId & "'"
            Dim conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            conn.Open()
            da.Fill(ds, "Clinician")
            conn.Close()
            Dim dt As DataTable = ds.Tables("Clinician")
            Dim dr As DataRow
            Dim x As Integer
            x = dt.Rows.Count
            For Each dr In dt.Rows
                dr.BeginEdit()
                dr("ClinicianOrder") = ordernumber
                dr.EndEdit()
            Next
            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "Clinician")

            Return Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function clinicianStatus(ByVal attribute As Boolean, ByVal Id As String) Implements IUpdateClincianAttributes.clinicianStatus

        Dim query As String = "SELECT * FROM Clinician Where ClinicianId='" & Id & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim dr As DataRow
        For Each dr In dt.Rows
            dr.BeginEdit()

            dr.Item("Inactive") = attribute

            dr.EndEdit()
        Next
        Dim objCommandBuilder As New SqlCommandBuilder(da)
        da.Update(ds, "Clinician")

        Return Nothing


    End Function

   
    Public Function EditNote(ByVal Studentid As String, ByVal noteid As Integer, ByVal noteheader As String, ByVal note As String, ByVal Date1 As Date) As Boolean Implements IUpdateStudentAttributes.editNote
        Try
            Dim index As Integer
            index = Convert.ToInt16(Studentid)
            Dim query1 As String = "SELECT * FROM Studentnote where Studentid='" & index & "' AND RemarkHeader='" & noteheader & "' AND RemarkDate='" & Date1 & "'"
            Dim conn1 As New SqlConnection(connectionString)
            Dim cmd1 As New SqlCommand(query1, conn1)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As New DataSet

            conn1.Open()
            da1.Fill(ds1, "Studentnote")
            conn1.Close()
            Dim dt1 As DataTable = ds1.Tables("Studentnote")
            Dim max As Integer = dt1.Rows.Count
            Dim dr1 As DataRow

            For Each dr1 In dt1.Rows
                dr1.BeginEdit()
                dr1.Item("StudentId") = Studentid.ToString

                dr1.Item("RemarkHeader") = noteheader.Trim.ToString
                dr1.Item("Remark") = note.ToString
                dr1.EndEdit()

                Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
                da1.Update(ds1, "Studentnote")
                Return False
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return True
    End Function

    Public Function editStudentSchool(ByVal Studentid As String, ByVal Schooldist As String, ByVal School As String, ByVal PrivatePublic As Boolean) Implements IUpdateStudentAttributes.editStudentSchool
        Dim index As Integer
        index = Convert.ToInt16(Studentid)
        Dim query1 As String = "SELECT * FROM StudentSchool Where Studentid='" & index & "'"
        Dim conn1 As New SqlConnection(connectionString)
        Dim cmd1 As New SqlCommand(query1, conn1)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        conn1.Open()
        da1.Fill(ds1, "StudentSchool")
        conn1.Close()
        Dim dt1 As DataTable = ds1.Tables("StudentSchool")
        Dim dr1 As DataRow
        For Each dr1 In dt1.Rows
            dr1.BeginEdit()
            dr1.Item("SchoolDist") = Schooldist.ToString
            dr1.Item("SchoolName") = School.ToString
            dr1.Item("Prv_Pub") = PrivatePublic
            dr1.EndEdit()
        Next
        Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
        da1.Update(ds1, "StudentSchool")
        Return (Nothing)
    End Function

    Public Function DeleteNote(ByVal Studentid As String, ByVal noteid As Integer) Implements IUpdateStudentAttributes.DeleteNote
        Dim index As Integer
        index = Convert.ToInt16(Studentid)
        Dim query1 As String = "SELECT * FROM Studentnote Where Studentid='" & index & "' AND count='" & noteid & "'"
        Dim conn1 As New SqlConnection(connectionString)
        Dim cmd1 As New SqlCommand(query1, conn1)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        conn1.Open()
        da1.Fill(ds1, "StudentNote")
        conn1.Close()
        Dim dt1 As DataTable = ds1.Tables("StudentNote")
        Dim dr1 As DataRow
        For Each dr1 In dt1.Rows
            dr1.Delete()
        Next
        Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
        da1.Update(ds1, "StudentNote")

        Return Nothing
    End Function

End Class
