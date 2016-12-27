Public Class FullAssessmentDataExport
    Dim dbContext As New FamilyLiteracyEntityDataModel
    Public Shared Function GetValues(ByVal studentIndex As String, ByVal name As String, ByVal sDate As String, ByVal testvalues As List(Of ExportDateHeader))
        Dim dbContext As New FamilyLiteracyEntityDataModel

        Dim standardscore1, standardscore2, standardscore3 As String
        Dim method As String = String.Empty
        Dim num As Integer = 0
        Dim studentNo As Integer = Convert.ToInt32(studentIndex)
        For num = 0 To 5
            Dim testindex = New String() {"a", "b", "c", "d", "e"}
            'Capture CodeKnowledge Data
            Dim FirstDate = (From p In dbContext.Assessments
                          Where p.StudentId = studentNo And testindex(num) = p.Test_Name
                          Order By p.Date Ascending
            Take (1)
                          Select p).FirstOrDefault
            Dim SecondDate = (From p In dbContext.Assessments
                          Where p.StudentId = studentNo And testindex(num) = p.Test_Name
                          Order By p.Date Descending
                          Skip (1) Take (1)
                          Select p).FirstOrDefault

            Dim ThirdDate = (From p In dbContext.Assessments
                         Where p.StudentId = studentNo And testindex(num) = p.Test_Name
                         Order By p.Date Descending
                         Take (1)
                         Select p).FirstOrDefault
            Dim ss As Integer = 0
            Dim group As String = String.Empty
            Dim groupfunction As String = String.Empty

            standardscore1 = FirstDate.Standard_Score
            standardscore2 = SecondDate.Standard_Score
            standardscore3 = ThirdDate.Standard_Score
            Dim date1 As Date
            Dim date2 As Date
            Dim date3 As Date
            date1 = FirstDate.Date
            date2 = SecondDate.Date
            date3 = ThirdDate.Date
            testvalues.Add(New ExportDateHeader(String.Empty, method, standardscore1, standardscore2, standardscore3, 0, date1, date2, date3))
        Next
        Return testvalues
    End Function

End Class
