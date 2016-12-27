Public Interface IResetNames
    Function ResetLeftNames(ByVal activeStudents As String)

End Interface



Public Interface IselectSingleNameRightLeft
    Function MoveSelectedNameRight()
    Function MoveSelectedNameLeft()
End Interface

Public Interface IMoveAllNameLeftRight
    Function MoveAllNamesRight()
    Function MoveAllNameLeft()
End Interface
Public Class Names
    Public Sub New(ByVal _name As String)

        Me.Fullname = _name

    End Sub

    Public Property Fullname As String

End Class