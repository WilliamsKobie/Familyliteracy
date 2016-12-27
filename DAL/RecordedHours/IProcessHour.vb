Public Interface ISaveHour

    Function Save(ByVal studentId As String, recordedDate As String, hour As Integer)

End Interface



Public Interface IreturnHour
    Function CheckForStudent(ByVal studentId As String) As Dictionary(Of String, String)

End Interface