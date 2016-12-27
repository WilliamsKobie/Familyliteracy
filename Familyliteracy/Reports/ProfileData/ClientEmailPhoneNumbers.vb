Imports DAL
Public Class ClientEmailPhoneNumbers

    Private Sub ClientEmailPhoneNumbers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CaptureContactData As IuserContactProfiler = New StudentPersonalContacts

        Dim Contacts As IEnumerable = CaptureContactData.CaptureProfile()
        PersonalContactCollectionBindingSource.DataSource = Contacts
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class