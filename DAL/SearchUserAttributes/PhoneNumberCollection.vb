
Public Class PhoneNumberCollection
    Public Sub New(ByVal _index As Integer, ByVal _phoneNumber As String, ByVal _phoneType As String)
        PhoneNumber = _phoneNumber
        PhoneIndex = _index
        PhoneType = _phoneType
    End Sub

    Public Property PhoneIndex As Integer
    Public Property PhoneNumber As String
    Public Property PhoneType As String
End Class

