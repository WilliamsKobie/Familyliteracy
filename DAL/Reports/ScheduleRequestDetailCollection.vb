
Public Class ScheduleRequestDetailCollection


    Sub New(numberofAppointments As String, studentId As String, _firstName As String, _lastName As String, whenAppointmentWasSet As String, howAppointmentWasSet As String, scheduledDate As String)

        AppointmentCount = numberofAppointments
        StudentNumber = studentId
        FirstName = _firstName
        LastName = _lastName
        RequestDate = whenAppointmentWasSet
        MeansofRequest = howAppointmentWasSet
        AppointmentDate = scheduledDate
    End Sub

    Public Property AppointmentCount As String

    Public Property StudentNumber As String

    Public Property FirstName As String

    Public Property LastName As String

    Public Property RequestDate As String

    Public Property MeansofRequest As String
    Public Property AppointmentDate As String

End Class
