Public Class ExportAssesmentData
    Public Shared Function Export(ByVal studentNo As String) As List(Of ExportAssessmentDataObject)
        Dim exportData As IExportassessmentData = Nothing
        Dim data As New List(Of ExportAssessmentDataObject)
        If studentNo = String.Empty Then
            exportData = New AllStudentsAssessmentData
            data = exportData.StudentData(String.Empty)
            Return data
        Else
            exportData = New SingleStudentAssessmentData
            data = exportData.StudentData(studentNo.Trim)
            Return data
        End If

        Return data
    End Function
End Class