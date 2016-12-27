Public Class EmailCollection
    Sub New(ByVal _emailIndex As String, ByVal _email As String, ByVal _emailType As String)
        EmailIndex = _emailIndex
        Email = _email
        EmailType = _emailType
    End Sub

    Public Property EmailIndex As String
    Public Property Email As String
    Public Property EmailType As String
End Class
