Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
'Returns the any notes about the student based on different properties of the note. Such as its header and storage date.
Public Interface IpopulateUserAttributes
    Function AddNote(ByVal Studentid As String, ByVal Date1 As Date, ByVal noteheader As String, ByVal note As String) As Boolean
End Interface
Public Class populateUser
    Implements IpopulateUserAttributes
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasbase!")
        End Try
    End Sub


    Public Function AddNote(ByVal Studentid As String, ByVal Date1 As Date, ByVal noteheader As String, ByVal note As String) As Boolean Implements IpopulateUserAttributes.AddNote
        Try
            Dim query1 As String = "SELECT * FROM Studentnote"
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

            dr1 = dt1.NewRow()
            dr1.Item("StudentId") = Studentid.ToString
            dr1.Item("RemarkDate") = Date1
            dr1.Item("RemarkHeader") = noteheader.Trim.ToString
            dr1.Item("Remark") = note.ToString
            dt1.Rows.Add(dr1)

            Dim objCommandBuilder1 As New SqlCommandBuilder(da1)
            da1.Update(ds1, "Studentnote")

        Catch ex As Exception

        End Try
        Return Nothing
    End Function


End Class