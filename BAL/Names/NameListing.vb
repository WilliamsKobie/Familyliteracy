Imports DAL
Imports System.DateTime
Imports System.Data.SqlClient
Public Class NameListing

    Public Shared Function ListAllNames() As IEnumerable
        Try
            Dim getstudents As New ReturnStudentData
            Dim studentName = New List(Of StudentNames)
            Dim dt As DataTable
            dt = getstudents.AllStudentData()
            Dim firstName As String = String.Empty
            Dim lastName As String = String.Empty
            Dim fullName As String = String.Empty
            Dim rw As DataRow
            studentName.Add(New StudentNames("", "", ""))
            For Each rw In dt.Rows
                firstName = rw.Item("First Name").ToString()
                lastName = rw.Item("Last Name").ToString()
                fullName = lastName & ", " & firstName
                studentName.Add(New StudentNames(firstName, lastName, fullName))
            Next
            Return studentName
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ListActiveNames() As List(Of StudentNames)

        Dim getstudents As New ReturnStudentData
        Dim studentName = New List(Of StudentNames)


        Dim dt As DataTable
        dt = getstudents.ActiveStudentData()
        Dim x As Integer = dt.Rows.Count

        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim fullName As String = String.Empty
        Dim rw As DataRow
        For Each rw In dt.Rows
            firstName = rw.Item("First Name").ToString()
            lastName = rw.Item("Last Name").ToString()
            fullName = lastName & ", " & firstName
            studentName.Add(New StudentNames(firstName, lastName, fullName))
        Next
        Return studentName


    End Function


    Public Shared Function ListNonActiveNames() As List(Of StudentNames)

        Dim getstudents As New ReturnStudentData
        Dim studentName = New List(Of StudentNames)


        Dim dt As DataTable
        dt = getstudents.NonActiveStudentData()
        Dim x As Integer = dt.Rows.Count

        Dim firstName As String = String.Empty
        Dim lastName As String = String.Empty
        Dim fullName As String = String.Empty
        Dim rw As DataRow
        For Each rw In dt.Rows
            firstName = rw.Item("First Name").ToString()
            lastName = rw.Item("Last Name").ToString()
            fullName = lastName & ", " & firstName
            studentName.Add(New StudentNames(firstName, lastName, fullName))
        Next
        Return studentName

    End Function
End Class
Public Class GuardianNameListing
    Public Shared Function NameList() As List(Of GuardianNames)
        Dim Names = New List(Of GuardianNames)

        Dim dbContext = New FamilyLiteracyEntityDataModel
        Dim captureguardian = From s In dbContext.GuardianProfiles
                                            Select s
        Names.Add(New GuardianNames("", "", ""))
        For Each name In captureguardian
            Dim fName, lName, fullName As String
            fName = name.First_Name
            lName = name.Last_Name
            fullName = lName & ", " & fName
            Names.Add(New GuardianNames(lName, fName, fullName))
        Next

        Return Names
    End Function
End Class
Public Class StudentNames
    Public Sub New(ByVal _fname As String, ByVal _lname As String, ByVal fullName As String)
        Me.FirstName = _fname
        Me.LastName = _lname
        Me.FullName = fullName
    End Sub
    Public Property FullName As String
    Public Property FirstName As String
    Public Property LastName As String

End Class
Public Class GuardianNames

    Private _fname As String = String.Empty
    Private _lname As String = String.Empty
    Private _guardianfullName As String = String.Empty

    Public Sub New(ByVal _fname As String, ByVal _lname As String, ByVal _guardianfullName As String)
        FirstName = _fname
        LastName = _lname
        FullName = _guardianfullName
    End Sub

    Public Property FirstName As String
    Public Property LastName As String
    Public Property FullName As String
End Class