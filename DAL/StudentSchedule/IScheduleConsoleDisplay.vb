Public Interface IappointmentRetriever
    Function Retrieve(ByVal ScheduleRequestParameter As IDictionary(Of String, String)) As IEnumerable
End Interface
Public Interface IcurrentNextMonthAppointmentRetriever
    Function Retrieve(ByVal ScheduleRequestParameter As IDictionary(Of String, String)) As IEnumerable
End Interface


Public Interface IScheduleDisplayAppointmentRemover
    Function Delete(Of T)(value As T)
End Interface
