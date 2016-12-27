Imports DAL

'Removes a clinician off days
Public Interface IscheduleClinician
    Function deleteClinicianOffdays(ByVal clinician As Array, ByVal selecteddays As Array)

End Interface
Public Class clincianScheduledOff
    Implements IscheduleClinician
    Dim intervals As IEvaluateDateTimeIntervals = New datetimeIntervalConversion
    'Removes the days in which the clinician is scheduled to be off.
    Public Function deleteClinicianOffdays(ByVal clinician As Array, ByVal selecteddays As Array) Implements IscheduleClinician.deleteClinicianOffdays
        Dim tempdate As Date
        Dim Delete As New CommitChanges
        Dim AllClinician As Integer = UBound(clinician)
        For y = 0 To AllClinician


            ' Calculate date intervals

            Dim dateintervals As ArrayList
            dateintervals = intervals.DateIntervals(clinician(y, 0), clinician(y, 0), selecteddays)

            For x = 0 To dateintervals.Count - 1


                tempdate = FormatDateTime(dateintervals(x), DateFormat.LongDate)

                Dim clinicianid As String = clinician(y, 3)
                Dim Stime As String = clinician(y, 1)
                Dim Etime As String = clinician(y, 2)
                'Remove off days
                Delete.RemoveClinicianOffDays(clinicianid.Trim, Stime, Etime, tempdate)
            Next
        Next
        Return Nothing
    End Function


End Class
