Imports DAL
Public Interface IUserAttributeProfile

   

    Function SearchFaxNumber() As ISearchUserFaxPhone
    Function SearchLastName() As ISearchUserLastName
    Function SearchFirstName() As ISearchUserFirstName
    Function SearchHomePhone() As ISearchUserHomePhone
    Function SearchCellPhone() As ISearchUserCellPhone
    Function SearchWorkPhone() As ISearchUserWorkPhone
    Function SearchEmail() As ISearchUserEmail
    Function SearchAlternateEmail() As ISearchUserAlternateEmail
    Function SearchAddress() As ISearchUserAddress

End Interface



Public Class SearchStudentAttribute
    Implements IUserAttributeProfile
    Public Function SearchFirstName() As ISearchUserFirstName Implements IUserAttributeProfile.SearchFirstName
        Return New StudentUserFirstName
    End Function

    Public Function SearchLastName() As ISearchUserLastName Implements IUserAttributeProfile.SearchLastName
        Return New StudentUserLastName
    End Function

    Public Function SearchHomePhone() As ISearchUserHomePhone Implements IUserAttributeProfile.SearchHomePhone
        Return New StudentUserHomePhoneNumber
    End Function

    Public Function SearchCellPhone() As ISearchUserCellPhone Implements IUserAttributeProfile.SearchCellPhone
        Return New StudentUserHomePhoneNumber
    End Function

    Public Function SearchWorkPhone() As ISearchUserWorkPhone Implements IUserAttributeProfile.SearchWorkPhone
        Return New StudentUserWorkPhoneNumber
    End Function

    Public Function SearchFaxNumber() As ISearchUserFaxPhone Implements IUserAttributeProfile.SearchFaxNumber
        Return New StudentUserFaxPhoneNumber
    End Function

    Public Function SearchEmail() As ISearchUserEmail Implements IUserAttributeProfile.SearchEmail
        Return Nothing
    End Function
    Public Function SearchAlternateEmail() As ISearchUserAlternateEmail Implements IUserAttributeProfile.SearchAlternateEmail
        Return Nothing
    End Function

    Public Function SearchAddress() As ISearchUserAddress Implements IUserAttributeProfile.SearchAddress
        Return Nothing
    End Function
End Class



Public Class SearchGuardianAttribute
    Implements IUserAttributeProfile
    Public Function SearchFirstName() As ISearchUserFirstName Implements IUserAttributeProfile.SearchFirstName
        Return New GuardianUserFirstName
    End Function

    Public Function SearchLastName() As ISearchUserLastName Implements IUserAttributeProfile.SearchLastName

        Return New GuardianUserLastName

    End Function

    Public Function SearchHomePhone() As ISearchUserHomePhone Implements IUserAttributeProfile.SearchHomePhone
        Return New GuardianUserHomePhoneNumber
    End Function

    Public Function SearchCellPhone() As ISearchUserCellPhone Implements IUserAttributeProfile.SearchCellPhone
        Return New GuardianUserCellPhoneNumber
    End Function

    Public Function SearchWorkPhone() As ISearchUserWorkPhone Implements IUserAttributeProfile.SearchWorkPhone
        Return New GuardianUserWorkPhoneNumber
    End Function

    Public Function SearchFaxNumber() As ISearchUserFaxPhone Implements IUserAttributeProfile.SearchFaxNumber
        Return New GuardianUserFaxPhoneNumber
    End Function

    Public Function SearchEmail() As ISearchUserEmail Implements IUserAttributeProfile.SearchEmail
        Return New GuardianUserEmail
    End Function
    Public Function SearchAlternateEmail() As ISearchUserAlternateEmail Implements IUserAttributeProfile.SearchAlternateEmail
        Return New GuardianUserAlternateEmail
    End Function

    Public Function SearchAddress() As ISearchUserAddress Implements IUserAttributeProfile.SearchAddress
        Return New GuardianUserAddress
    End Function
End Class

Public Class SearchClinicianAttribute
    Implements IUserAttributeProfile
    Public Function SearchFirstName() As ISearchUserFirstName Implements IUserAttributeProfile.SearchFirstName
        Return New ClinicianUserFirstName
    End Function

    Public Function SearchLastName() As ISearchUserLastName Implements IUserAttributeProfile.SearchLastName
        Return New ClincianUserLastName
    End Function

    Public Function SearchHomePhone() As ISearchUserHomePhone Implements IUserAttributeProfile.SearchHomePhone
        Return New ClinicianUserHomePhoneNumber
    End Function

    Public Function SearchCellPhone() As ISearchUserCellPhone Implements IUserAttributeProfile.SearchCellPhone
        Return New ClinicianUserCellPhoneNumber
    End Function

    Public Function SearchWorkPhone() As ISearchUserWorkPhone Implements IUserAttributeProfile.SearchWorkPhone
        Return New ClinicianUserWorkPhoneNumber
    End Function

    Public Function SearchFaxNumber() As ISearchUserFaxPhone Implements IUserAttributeProfile.SearchFaxNumber
        Return New ClinicianUserFaxPhoneNumber
    End Function

    Public Function SearchEmail() As ISearchUserEmail Implements IUserAttributeProfile.SearchEmail
        Return Nothing
    End Function
    Public Function SearchAlternateEmail() As ISearchUserAlternateEmail Implements IUserAttributeProfile.SearchAlternateEmail
        Return Nothing
    End Function

    Public Function SearchAddress() As ISearchUserAddress Implements IUserAttributeProfile.SearchAddress
        Return New ClinicianUserAddress
    End Function
End Class

