Imports DAL
Public Class ReportTwoDaySegmenting

    Private Sub ReportTwoDaySegmenting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_FamilyLiteracy_mdfDataSet1.StudentProfile' table. You can move, or remove it, as needed.
        Me.StudentProfileTableAdapter.Fill(Me._FamilyLiteracy_mdfDataSet1.StudentProfile)
        Dim SegmentingDateList As IEnumerable(Of SegmentingDataAttributes)
        Dim SegmentingData As ISegmentingDataLocator = New SegmentingDataLocator
        SegmentingDateList = SegmentingData.Find()
        SegmentingDataAttributesBindingSource.DataSource = SegmentingDateList

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class