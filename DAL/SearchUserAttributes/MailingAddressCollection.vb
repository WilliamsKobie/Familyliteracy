Public Class MailingAddressCollection

    Sub New(ByVal _addressIndex As String, ByVal _streetAddress As String)
        AddressIndex = _addressIndex
        Street_Address = _streetAddress
    End Sub

    Public Property Street_Address As String

    Public Property AddressIndex As String

End Class
