Imports DAL
Imports System.IO
Imports System.Data
'Id number generator for students, guardians, clinicians Primary and surrugate keys for the database.
Public Interface IUserIdNumbers
    Function GenerateIdNumber() As String
End Interface

Public Class GenerateClinicianID
    Inherits Clinicians : Implements IUserIdNumbers

    'Clinician Id generator
    Private Function GenerateIdNumber() As String Implements IUserIdNumbers.GenerateIdNumber

        Dim id As String
        Dim x As Double
        Dim c As String
        id = GetID()
        c = id.Substring(3, 1)
        id = id.Substring(0, 3)

        id = "." & id
        x = 0.001 + CDbl(id)
        id = CStr(x)
        id = id.Trim("0")
        id = id.Trim(".")
        If Len(id) = 1 Then
            id = id + "00"
        ElseIf Len(id) = 2 Then
            id = id & "0"

        End If
        id = id & "c"
        id = id.Trim()
        Return id

    End Function
End Class

Public Class GenerateStudentID
    Inherits ReturnStudentData : Implements IUserIdNumbers


    'Student id generator
    Private Function GenerateIdNumber() As String Implements IUserIdNumbers.GenerateIdNumber

        Dim id As String = String.Empty
        Dim idNumber As String = String.Empty
        Dim newId As Integer
        id = GetID()
        newId = Convert.ToInt64(id)
        'Increment student Id number by one
        newId = newId + 1
        idNumber = Convert.ToString(newId)
        Return idNumber.Trim
    End Function


End Class
Public Class GenerateGuardianID
    Inherits ReturnGuardianInfo : Implements IUserIdNumbers

    'Guardian id Generator
    Private Function GenerateIdNumber() As String Implements IUserIdNumbers.GenerateIdNumber
        Dim id As String
        Dim idNumber As String = String.Empty
        Dim newId As Integer

        id = GetID()
        newId = Convert.ToInt64(id)
        'Increment guardian Id number by one
        newId = newId + 1
        idNumber = Convert.ToString(newId)
        Return idNumber.Trim
    End Function
End Class


Public Interface IIDnumbers
    Function GenerateID() As Integer
End Interface
'Generate an Id number for the main schedule
Public Class GenerateMainDisplayIdnum
    Inherits Schedule
    Implements IIDnumbers
    Public Function GenerateID() As Integer Implements IIDnumbers.GenerateID
        Dim idNum As Int32 = 0
        idNum = MainDisplaySchedule()
        idNum = idNum + 1
        Return idNum
    End Function
End Class
' Generates a position value for a clinician in the database.
Public Class GenerateClinicianPositionId
    Inherits Clinicians
    Implements IIDnumbers
    Public Function GenerateID() As Integer Implements IIDnumbers.GenerateID
        Dim idNum As Int32 = 0
        idNum = GetOrderID()
        idNum = idNum + 1
        Return idNum
    End Function
End Class