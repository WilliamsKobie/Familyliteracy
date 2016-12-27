Imports System

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Class Clinicians
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasbase!")
        End Try
    End Sub

    'Return clinician schedule based on their id number and date that they are scheduled out
    Public Overloads Function GetClinicianSchedule(ByVal clinicianid As String, ByVal Date1 As Date) As DataSet

        Dim query As String = "SELECT * FROM MainSchedule where ClinicianID='" & clinicianid & "' AND [Date] >'" & Date1 & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "MainSchedule")
        conn.Close()


        Dim dt As DataTable = ds.Tables("MainSchedule")

        Return ds
    End Function
    'Return all clinician
    Public Overloads Function GetID() As String

        Dim query As String = "SELECT * FROM Clinician ORDER BY Clinicianid ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim row As String
        If dt.Rows.Count - 1 > -1 Then
            row = dt.Rows(dt.Rows.Count - 1)(0).ToString
        Else
            Return "000"
        End If
        Return row
    End Function
    'Return the numerical location in which the clinician is saved
    Public Overloads Function GetOrderID() As Integer

        Dim query As String = "SELECT TOP 1 * FROM Clinician ORDER BY ClinicianOrder DESC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim dr As DataRow
        Dim placevalue As Integer = 0
        For Each dr In dt.Rows
            placevalue = dr("ClinicianOrder")
        Next
        Return placevalue
    End Function


    'Return clinician profile based on the active or inactive status
    Public Overloads Function GetClinicianInfo(ByVal status As String) As DataSet

        Dim query1 As String

        Select Case status
            Case True
                query1 = "SELECT * FROM Clinician Where Inactive='False' ORDER BY Clinician Order ASC"


            Case False
                query1 = "SELECT * FROM Clinician ORDER BY Clinician Order ASC"

            Case Else
                Return Nothing
        End Select
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Return ds


    End Function





    Public Overloads Function clinicianOutSchedule(ByVal clinician As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Dim query As String = "SELECT * FROM Clinician_DailyOutSchedule where [Date] Between '" & StartDate & "' And '" & EndDate & "' And Clinicianid='" & clinician.Trim & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician_DailyOutSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician_DailyOutSchedule")
        Return ds
    End Function

    Public Overloads Function clinicianOutSchedule(ByVal StartDate As Date, ByVal EndDate As Date) As DataSet

        Dim query As String = "SELECT * FROM Clinician_DailyOutSchedule where [Date] Between '" & StartDate & "' And '" & EndDate & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician_DailyOutSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician_DailyOutSchedule")
        Return ds
    End Function

    Public Overloads Function GetClinicianInfo() As Array

        Dim query As String = "SELECT * FROM Clinician where Inactive=0 ORDER BY LastName ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim dr As DataRow
        Dim cl As String
        Dim clfn As String
        Dim clln As String
        Dim max As Integer = dt.Rows.Count

        Dim x As Integer = 0
        Dim Attribute(max, 2) As String
        Attribute(x, 0) = String.Empty
        Attribute(x, 1) = String.Empty
        Attribute(x, 2) = String.Empty
        For Each dr In dt.Rows
            x = x + 1
            cl = dr("ClinicianID")
            clfn = dr("LastName")
            clln = dr("FirstName")

            cl.Trim()
            clfn.Trim()
            clln.Trim()
            Attribute(x, 0) = cl.ToArray
            Attribute(x, 1) = clfn.ToArray
            Attribute(x, 2) = clln.ToArray

        Next
        Return Attribute
    End Function
    Public Overloads Function ClinicianProfile() As DataTable

        Dim query As String = "SELECT * FROM Clinician ORDER BY LastName ASC"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Return dt
    End Function

    Public Overloads Function ClinicianProfile(ByVal clinicianId As String, ByVal status As Boolean) As DataTable

        Dim query As String = "SELECT * FROM Clinician Where ClinicianId='" & clinicianId.Trim & "' And InActive='" & status & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Return dt
    End Function
    Public Overloads Function ClinicianProfile(ByVal id As String) As ArrayList

        Dim clinician As New ArrayList

        Dim query As String = "SELECT * FROM Clinician where ClinicianId='" & id.Trim & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim rw As DataRow
        For Each rw In dt.Rows
            clinician.Add(rw("FirstName").ToString)
            clinician.Add(rw("LastName").ToString)
        Next
        Return clinician
    End Function


    Public Overloads Function ClinicianProfile(ByVal ln As String, ByVal fn As String) As String

        Dim clinician As String = String.Empty
      
        Dim query As String = "SELECT * FROM Clinician where FirstName='" & fn.Trim & "' AND LastName='" & ln.Trim & "'"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician")
        Dim rw As DataRow


        For Each rw In dt.Rows
            clinician = rw("ClinicianId").ToString
        Next
        Return clinician.Trim
    End Function
End Class
Public Interface IscheduleClinican
    Function RemoveDate(ByVal clinicianid As String, ByVal datestamp As Date)
    Function UpdateSchedule(ByVal clinician As String, ByVal Dateout As Date, ByVal Timein As String, ByVal Timeout As String) As Boolean
End Interface
Public Class alterSchedule
    Implements IscheduleClinican
    Dim connectionString As Object
    Public Sub New()
        Try
            connectionString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
        Catch ex As Exception
            MsgBox("Cannot connect to Datasbase!")
        End Try
    End Sub


    Public Function RemoveDate(ByVal clinicianid As String, ByVal datestamp As Date) Implements IscheduleClinican.RemoveDate


        Dim query As String = "SELECT * FROM Clinician_DailyOutSchedule Where ClinicianID='" & clinicianid.Trim & "'" & " AND [Date]='" & datestamp & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician_DailyOutSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician_DailyOutSchedule")
        Dim dr As DataRow

        For Each dr In dt.Rows
            dr.Delete()
        Next
        Dim objCommandBuilder2 As New SqlCommandBuilder(da)
        da.Update(ds, "Clinician_DailyOutSchedule")
        Return Nothing
    End Function

    Public Function UpdateSchedule(ByVal clinician As String, ByVal dateout As Date, ByVal Timein As String, ByVal Timeout As String) As Boolean Implements IscheduleClinican.UpdateSchedule

        Dim t1 As String = String.Empty
        Dim t2 As String = String.Empty
        Dim time1 As DateTime
        Dim time2 As DateTime

        t1 = "1900-01-01 " & Timein.Trim
        t2 = "1900-01-01 " & Timeout.Trim
        time1 = Convert.ToDateTime(t1) 'convert start time to Datetime Datatype
        time2 = Convert.ToDateTime(t2) 'convert stop time to Datetime Datatype

        Dim query As String = "SELECT * FROM Clinician_DailyOutSchedule Where ClinicianId='" & clinician.Trim & "' AND [Date]='" & dateout & "' And Timein <='" & time1 & "' AND TimeOut >='" & time2 & "'"

        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand(query, conn)

        Dim da As New SqlDataAdapter(cmd)

        Dim ds As New DataSet
        conn.Open()
        da.Fill(ds, "Clinician_DailyOutSchedule")
        conn.Close()
        Dim dt As DataTable = ds.Tables("Clinician_DailyOutSchedule")

        Dim dr As DataRow


        'Place the date and times when the clinician will be out, Check for duplicate entries that match'
        If dt.Rows.Count < 1 Then
            dr = dt.NewRow()


            dr("ClinicianID") = clinician.ToString.Trim
            dr("Date") = dateout
            dr("timein") = time1
            dr("timeout") = time2
            dr("processing_Date") = DateTime.Now
            dt.Rows.Add(dr)

            Dim objCommandBuilder As New SqlCommandBuilder(da)
            da.Update(ds, "Clinician_DailyOutSchedule")
            Return False
        Else

            Return True
            Exit Function
        End If
        Return False
    End Function
End Class
