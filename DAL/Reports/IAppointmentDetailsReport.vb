Public Interface IAppointmentDetailsReport
    Function LocateAppointmentDetails(Of T)(ByVal searchParameter As T) As IEnumerable
End Interface
