Public Class UserNameCollection
    Public Sub New(ByVal _index As Integer, ByVal _names As String)
        NameIndex = _index
        Name = _names
    End Sub

    Public Property NameIndex As Integer
    Public Property Name As String
End Class
