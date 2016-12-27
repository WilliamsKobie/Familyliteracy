Imports DAL
Imports System.IO
Imports System.Net
Imports System.Globalization


'Returns the name if a students' id number, guardians’ id number or clinicians’ Id number is passed.
'Returns the Id number if a students’ name, guardians’ name, and clinicians’ name is passed.
'Parses an apostrophe out of a string or adds an apostrophe to a string. 
'The input string is usually a name, but can also be used for any other kind of string inputs i.e. address, city, email address etc.

Public Interface INameConversion
    Function ConvertName(ByVal idNumber As String) As String
    Function ConvertToId(ByVal fullName As String) As String
End Interface

Public Class ClinicianNameConversion
    Inherits Clinicians
    Implements INameConversion

    'Converts the Clinician Id number to the corresponding name 
    Public Function ConvertName(ByVal idNumber As String) As String Implements INameConversion.convertName
        Dim findApostrophe As IParseUserName = New ParseFullName
        Dim clinicianLastName As String = String.Empty
        Dim clinicianFirstName As String = String.Empty
        Dim tutor As String = String.Empty
        Dim ClinicianName As New ArrayList

        Dim clinician As String = String.Empty
        If idNumber <> String.Empty Then
            ClinicianName = ClinicianProfile(idNumber.Trim)

            clinicianLastName = ClinicianName(1).Trim
            clinicianFirstName = ClinicianName(0).Trim
            tutor = clinicianLastName.Trim & ", " & clinicianFirstName.Trim
            clinician = findApostrophe.SwitchAccentMarkToApostrophe(tutor.Trim)

            tutor = clinician.Trim

        End If
        Return tutor
    End Function
    'Converts the clinician name to the corresponding clinician Id number 
    Public Function ConvertToId(ByVal fullName As String) As String Implements INameConversion.ConvertToId
        Dim findApostrophe As IParseUserName = New ParseFullName
        Dim clinicianName As String = String.Empty
        Dim splitname_clinician() As String
        Dim returnedId As String = String.Empty

        Dim clinicianFirstName As String = String.Empty
        Dim clinicianLastName As String = String.Empty
        Dim clinicianid As String = [String].Empty
        If fullName <> String.Empty Then
            clinicianName = findApostrophe.SwitchApostropheToAccentMark(fullName.Trim)
            splitname_clinician = clinicianName.Split(",")
            clinicianFirstName = splitname_clinician(1).Trim
            clinicianLastName = splitname_clinician(0).Trim


            returnedId = ClinicianProfile(clinicianLastName.Trim, clinicianFirstName.Trim)
            clinicianid = returnedId.Trim
        End If
        Return clinicianid
    End Function
End Class

'Converts the student Id number to the corresponding name 
'Converts the Student name to the corresponding Student Id number 
Public Class StudentNameConversion

    Implements INameConversion

    'Converts the Student Id number to the corresponding name 
    Public Function ConvertName(ByVal idnumber As String) As String Implements INameConversion.ConvertName

        Dim PlaceApostropheIntoName As IParseUserName = New ParseFullName
        Dim Profile As IEnumerable(Of StudentProfileCollection) = Nothing
        Dim studentName As IEnumerable(Of StudentProfileCollection) = Nothing
        Dim StudentProfile As IEntireStudentProfileSearch = New SearchStudentUsingAttributes

        Dim firstname As String = String.Empty
        Dim lastname As String = String.Empty
        Dim fullname As String = String.Empty
        Dim returnfullname As String = String.Empty

        If idnumber <> String.Empty Then
            ' Locate student in the 'StudentProfile Table of the database
            Profile = SearchStudentUserProfile.SearchStudentProfileTable(idnumber.Trim(), AddressOf StudentProfile.StudentIDNumber)

            studentName = From p In Profile
                       Select p

            For Each name In studentName
                lastname = name.Last_Name
                firstname = name.First_Name
            Next

            fullname = lastname.Trim & ", " & firstname.Trim
            returnfullname = PlaceApostropheIntoName.SwitchAccentMarkToApostrophe(fullname.Trim)
        End If

        Return returnfullname.Trim
    End Function
    'Converts the Student Name to the corresponding StudentId Number 
    Public Function ConvertToId(ByVal fullName As String) As String Implements INameConversion.ConvertToId

        Dim RemoveApostropheInName As IParseUserName = New ParseFullName
        Dim Profile As IList(Of StudentProfileCollection) = Nothing
        Dim StudentProfile As IEntireStudentProfileSearch = New SearchStudentUsingAttributes

        Dim returnedId As String = String.Empty
        Dim studentName As String
        If fullName <> String.Empty Then
            'Catch Apostrophe and replace it
            studentName = RemoveApostropheInName.SwitchApostropheToAccentMark(fullName.Trim)

            'Locate student in the 'StudentProfile Table of the database
            Profile = SearchStudentUserProfile.SearchStudentProfileTable(studentName, AddressOf StudentProfile.StudentFullname)

            returnedId = (From p In Profile
                         Select p.StudentNo).FirstOrDefault

        End If
        Return returnedId
    End Function
End Class
'Converts the Guardian name to the corresponding guardian Id number 
'Converts the Guardians Id number to the corresponding name 
Public Class GuardianNameConversion
    Inherits ReturnGuardianInfo
    Implements INameConversion
    'Converts the Guardian name to the corresponding Guardian Id number 
    Public Function convertToId(ByVal fullName As String) As String Implements INameConversion.ConvertToId
        Dim findApostrophe As IParseUserName = New ParseFullName
        Dim guardianId As String = String.Empty
        Dim lastName As String = String.Empty
        Dim firstName As String = String.Empty
        Dim splitnameGuardian() As String
        Dim guardianName As String = String.Empty

        Dim returnId As String = String.Empty
        If fullName <> String.Empty Then
            'Catch Apostrophe and replace it
            guardianName = findApostrophe.SwitchApostropheToAccentMark(fullName.Trim)
            splitnameGuardian = guardianName.Split(",")


            firstName = splitnameGuardian(1).Trim
            lastName = splitnameGuardian(0).Trim
            'Locate student in the 'StudentProfile Table of the database
            returnId = ReturnGuardianinfo(firstName.Trim, lastName.Trim)
            guardianId = returnId
        End If

        Return guardianId
    End Function
    'Converts the Guardians Id number to the corresponding name 
    Public Function convertName(ByVal idnumber As String) As String Implements INameConversion.convertName
        Return Nothing
    End Function

End Class

'Parses a user name if string is passed in a format with the lastname and firstname seperated by a comma and then returns the fullname with a comma dividing the first and last name.
'1)Removes a apostrophe or
'2)Adds a apostrophe
Public Interface IParseUserName

    Function SwitchApostropheToAccentMark(ByVal name As String) As String
    Function SwitchAccentMarkToApostrophe(ByVal name As String) As String
End Interface
Public Class ParseFullName
    Implements IParseUserName
    Function SwitchApostrapheToAccentMark(ByVal name As String) As String Implements IParseUserName.SwitchApostropheToAccentMark
        Dim splitname_user() As String
        Dim userid As String = String.Empty
        Dim userFirstName, userLastName As String
        Dim userName As String = String.Empty
        Dim Firstname As String = String.Empty
        Dim Lastname As String = String.Empty
        If name <> String.Empty Then
            splitname_user = name.Split(",")
            If splitname_user.Length > 1 Then
                Lastname = splitname_user(0).Trim
                Firstname = splitname_user(1).Trim
                userFirstName = Firstname.Replace("'", "`")
                userLastName = Lastname.Replace("'", "`")
                userName = userLastName.Trim & ", " & userFirstName.Trim
            End If
        End If

        Return userName
    End Function

    Function SwitchAccentMarkToApostrophe(ByVal name As String) As String Implements IParseUserName.SwitchAccentMarkToApostrophe
        Dim lastName As String = String.Empty
        Dim firstName As String = String.Empty
        Dim studentName As String = String.Empty
        Dim userLastName As String = String.Empty
        Dim userFirstName As String = String.Empty
        Dim splitnameuser() As String

        splitnameuser = name.Split(",")
        lastName = splitnameuser(0).Trim
        firstName = splitnameuser(1).Trim
        userLastName = lastName.Replace("`", "'")
        userFirstName = firstName.Replace("`", "'")
        studentName = userLastName.Trim & ", " & userFirstName.Trim
        Return studentName
    End Function

End Class

'Parses a user name if string is passed in a format with the lastname and firstname not seperated by a comma, but a full on string such as address,email address,City etc.
'1)Removes a apostrophe or
'2)Adds a apostrophe
Class ParseNamePart
    Implements IParseUserName
    Function ReplaceApostrapheToAccentMark(ByVal name As String) As String Implements IParseUserName.SwitchApostropheToAccentMark
        Dim username As String = String.Empty
        username = name.Replace("'", "`")
        Return username.Trim
    End Function
    Function SwitchAccentMarkToApostrophe(ByVal name As String) As String Implements IParseUserName.SwitchAccentMarkToApostrophe
        Dim username As String = String.Empty
        username = name.Replace("`", "'")
        Return username.Trim
    End Function
End Class
Public Class NameOperation
    Public Function ExecuteName(ByVal stringValue As String, ByVal markType As Integer)


        Dim FindApostropheFullName As IParseUserName = New ParseFullName
        Dim FindApostropheSingleName As IParseUserName = New ParseNamePart
        Dim parsedName As String = String.Empty

        Select Case (markType)
            'Used when a the string has a firstname and lastname sepersted by a comma that needs to be parsed
            Case 0 : parsedName = FindApostropheFullName.SwitchAccentMarkToApostrophe(stringValue.Trim)
                'Used when a the string has a firstname and lastname sepersted by a comma that needs to be parsed
            Case 1 : parsedName = FindApostropheFullName.SwitchApostropheToAccentMark(stringValue.Trim)
                'Used when the comma does not have to be parsed
            Case 2 : parsedName = FindApostropheSingleName.SwitchAccentMarkToApostrophe(stringValue.Trim)
                'Used when the comma does not have to be parsed
            Case 3 : parsedName = FindApostropheSingleName.SwitchApostropheToAccentMark(stringValue.Trim)


            Case Else
                parsedName = stringValue.Trim

        End Select

        Return parsedName
    End Function

End Class



