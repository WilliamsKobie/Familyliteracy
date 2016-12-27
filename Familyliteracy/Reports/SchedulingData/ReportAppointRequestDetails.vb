Imports DAL
Imports DAL.DAL.Appointments
Public Class ReportAppointRequestDetails

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      
    End Sub
    Public Function ExecuteReport(ByVal requestResults As IEnumerable(Of ScheduleRequestDetailCollection))

        ScheduleRequestDetailCollectionBindingSource.DataSource = requestResults
        Me.ReportViewer1.RefreshReport()
        Return Nothing
    End Function
End Class