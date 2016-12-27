
Public Class CampusObject
    Public Sub New(ByVal key1 As Integer, ByVal key2 As Integer)

        OldKey = key2
        NewTransactionID = key1
    End Sub

    Public Property OldKey As Integer

    Public Property NewTransactionID As Integer

End Class
