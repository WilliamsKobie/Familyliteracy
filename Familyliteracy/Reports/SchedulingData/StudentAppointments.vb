Imports DAL

Public Class StudentAppointments

    Private Sub StudentAppointments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub
    Public Function ExecuteReport(ByVal dateStamps As Dictionary(Of String, String))
        Dim exportData As IMainSchedule = Nothing
        exportData = New MainSchedule
        Dim studentSchedule As IEnumerable = exportData.Capture(dateStamps)
        StudentScheduleBindingSource.DataSource = studentSchedule
        Me.ReportViewer1.RefreshReport()
        Return Nothing
    End Function
End Class