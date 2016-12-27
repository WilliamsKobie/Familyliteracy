Interface IScheduledHour
    Function displayStudentCalendar(ByVal proposedt As DataTable, ByVal currentcalendardate As Date, ByVal displaytime As String, ByVal x As Integer, ByVal y As Integer)
    Function displayClinicianCalendar(ByVal dtOffdays As DataTable, ByVal currentcalendardate As Date, ByVal displaytime As String, ByVal x As Integer, ByVal y As Integer)
End Interface
Public Class DisplayProposedDate
    Implements IScheduledHour
    Public Function DisplayStudentCalendar(ByVal proposedt As DataTable, ByVal currentcalendardate As Date, ByVal displaytime As String, ByVal x As Integer, ByVal y As Integer) Implements IScheduledHour.displayStudentCalendar
        Dim currentdate As Date
        Dim startTime As DateTime = Nothing
        Dim finalTaime As DateTime = Nothing
        Dim query6 As String = "[Date]='" & currentcalendardate & "'"
        Dim proposeddate2 As DataRow() = proposedt.Select(query6)
        'Return the total size of the dataset containing proposed dates
        Dim allrecords As Integer = proposeddate2.Length - 1
        'Return and proposed date from the MainSchedule Table
        For search1 = 0 To allrecords

            currentdate = proposeddate2(search1)("Date")
            startTime = proposeddate2(search1)("Timein")
            finalTime = proposeddate2(search1)("Timeout")

            finaldate1 = currentdate.ToString(" d ").Trim



            displaytime = displaytime & ControlChars.CrLf & startTime.ToShortTimeString & "-" & finalTime.ToShortTimeString
            'Yellow represents proposed date,color the cell yellow and place the hour numbers within it.
            StudentCalendar.DataGridView1.Rows(x).Cells(y).Style.BackColor = Color.Yellow

            StudentCalendar.DataGridView1.Rows(x).Cells(y).Value = finaldate1 & displaytime


        Next
        Return Nothing
    End Function

    Public Function DisplayClinicianCalendar(ByVal dtOffdays As DataTable, ByVal currentcalendardate As Date, ByVal displaytime As String, ByVal x As Integer, ByVal y As Integer) Implements IScheduledHour.displayClinicianCalendar
        Dim currentdate As Date
        Dim startTime As DateTime = Nothing
        Dim finalTaime As DateTime = Nothing
        Dim query6 As String = "[Date]='" & currentcalendardate & "'"
        Dim dateOff As DataRow() = dtOffdays.Select(query6)
        'Return the total size of the dataset containing proposed dates
        Dim allrecords As Integer = dateOff.Length - 1
        'Return and proposed date from the MainSchedule Table
        For search1 = 0 To allrecords


            currentdate = dateOff(search1)("Date")
            startTime = dateOff(search1)("Timein")
            finalTime = dateOff(search1)("Timeout")



            finaldate = currentdate.ToString(" d ").Trim



            displaytime = displaytime & ControlChars.CrLf & "Out: " & startTime.ToShortTimeString & "-" & finalTime.ToShortTimeString
            'Yellow represents proposed date,color the cell yellow and place the hour numbers within it.
            ClinicianCalendar.DataGridView1.Rows(x).Cells(y).Style.BackColor = Color.LightGreen



            ClinicianCalendar.DataGridView1.Rows(x).Cells(y).Value = finaldate & vbCrLf & displaytime


        Next
        Return Nothing
    End Function
End Class
