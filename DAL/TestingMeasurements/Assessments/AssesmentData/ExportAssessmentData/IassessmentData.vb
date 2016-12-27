
Public Interface IExportassessmentData
    Function StudentData(ByVal studentNo As String) As List(Of ExportAssessmentDataObject)

End Interface

Public Interface IassessmentData
    Function StudentData(ByVal studentNo As String) As List(Of AssessmentdataObject)

End Interface

Public Class PeriperalAssessmentData
    Public Function ConvertScoretoPercent(ByVal standardScore As String)
        Dim percentconverted As String = "0"

        If standardScore <> "0" Then
            Dim ss As Integer = Convert.ToInt16(standardScore)
            Dim dbContext As New FamilyLiteracyEntityDataModel
            Dim percentconv = (From p In dbContext.StandardScore_ReferenceTable
                            Where p.Standard_Score = ss Select p).FirstOrDefault

            Dim value As Single = percentconv.Percent
            percentconverted = Convert.ToString(value * 100) + "%"
        End If
        Return percentconverted
    End Function
End Class
