Public Class TestData_DateHeader
    Dim dbContext As New FamilyLiteracyEntityDataModel
    Public Shared Function GetValues(ByVal studentIndex As String, ByVal name As String, ByVal testvalues As List(Of ExportDateHeader))
        Dim dbContext As New FamilyLiteracyEntityDataModel

        Dim score1 As String = String.Empty
        Dim score2 As String = String.Empty
        Dim score3 As String = String.Empty


        Dim method As String = String.Empty

        Dim studentNo As Integer = Convert.ToInt32(studentIndex)
        'Capture CodeKnowledge Data
        Dim FirstDate = (From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo
                      Order By p.Date Ascending
                      Take (1)
                      Select p).FirstOrDefault
        Dim SecondDate = (From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo
                      Order By p.Date Descending
                      Skip (1) Take (1)
                      Select p).FirstOrDefault

        Dim ThirdDate = (From p In dbContext.CodeKnowledge_Summations
                     Where p.StudentNo = studentNo
                     Order By p.Date Descending
                     Take (1)
                     Select p).FirstOrDefault

        Dim FirstDate_Blending = (From p In dbContext.Blending_Summation
                 Where p.StudentNo = studentNo
                 Order By p.Date Ascending
                 Take (1)
                 Select p).FirstOrDefault
        Dim SecondDate_Blending = (From p In dbContext.Blending_Summation
                      Where p.StudentNo = studentNo
                      Order By p.Date Descending
                      Skip (1) Take (1)
                      Select p).FirstOrDefault

        Dim ThirdDate_Blending = (From p In dbContext.Blending_Summation
                     Where p.StudentNo = studentNo
                     Order By p.Date Descending
                     Take (1)
                     Select p).FirstOrDefault


        Dim FirstDate_Segmenting = (From p In dbContext.Segmenting_Summation
              Where p.StudentNo = studentNo
              Order By p.Date Ascending
              Take (1)
              Select p).FirstOrDefault
        Dim SecondDate_Segmenting = (From p In dbContext.Segmenting_Summation
                      Where p.StudentNo = studentNo
                      Order By p.Date Descending
                      Skip (1) Take (1)
                      Select p).FirstOrDefault

        Dim ThirdDate_Segmenting = (From p In dbContext.Segmenting_Summation
                     Where p.StudentNo = studentNo
                     Order By p.Date Descending
                     Take (1)
                     Select p).FirstOrDefault
        Dim date1, date2, date3 As Date



        For x = 0 To 73

            Select Case x
                Case 0

                    testvalues.Add(New ExportDateHeader(name, String.Empty, String.Empty, String.Empty, String.Empty, x, #1/1/1900#, #1/1/1900#, #1/1/1900#))
                Case 1

                    If FirstDate Is Nothing Then
                        date1 = #1/1/1900#
                    Else
                        date1 = FirstDate.Date
                    End If

                    If SecondDate Is Nothing Then
                        date2 = #1/1/1900#
                    Else
                        date2 = SecondDate.Date
                    End If

                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                    Else
                        date3 = ThirdDate.Date
                    End If



                    testvalues.Add(New ExportDateHeader(String.Empty, String.Empty, date1, date2, date3, x, date1, date2, date3))
                Case 2
                    method = "Beginning Phonics"


                    If FirstDate Is Nothing Then

                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate.Beginning_Phonics
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate.Beginning_Phonics
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate.Beginning_Phonics
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If

                Case 3
                    method = "Advanced Phonics"
                    If FirstDate Is Nothing Then

                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate.Advanced_Phonics
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#

                    Else
                        score2 = SecondDate.Advanced_Phonics
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate.Advanced_Phonics
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If

                Case 4
                    method = "Basic Phonics"
                    If FirstDate Is Nothing Then

                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate.Basic_Phonics
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#

                    Else
                        score2 = SecondDate.Basic_Phonics
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate.Basic_Phonics
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If

                Case 5
                    method = "Vowel Digraphs"
                    If FirstDate Is Nothing Then

                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate.Vowel_Digraphs
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#

                    Else
                        score2 = SecondDate.Vowel_Digraphs
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate.Vowel_Digraphs
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 6
                    method = "Consonant Digraphs"
                    If FirstDate Is Nothing Then
                        date1 = #1/1/1900#

                        score1 = "n/a"
                    Else
                        score1 = FirstDate.Consonant_Digraphs
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#

                    Else
                        score2 = SecondDate.Consonant_Digraphs
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate.Consonant_Digraphs
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 7
                    method = "Blending Two Sound Words"

                    If FirstDate_Blending Is Nothing Then
                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate_Blending.Two_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Blending Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Blending.Two_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Blending Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Blending.Two_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 8
                    method = "Blending Three Sound Words"

                    If FirstDate_Blending Is Nothing Then
                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate_Blending.Three_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Blending Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Blending.Three_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Blending Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Blending.Three_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 9
                    method = "Blending Four Sound Words"

                    If FirstDate_Blending Is Nothing Then
                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate_Blending.Four_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Blending Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Blending.Four_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Blending Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Blending.Four_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 10
                    method = "Blending Five Sound Words"

                    If FirstDate_Blending Is Nothing Then
                        date1 = #1/1/1900#
                        score1 = "n/a"
                    Else
                        score1 = FirstDate_Blending.Five_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Blending Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Blending.Five_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Blending Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Blending.Five_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 11
                    method = "Segmenting Two Sound Words"

                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Two_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Two_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Two_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 12
                    method = "Segmenting Three Sound Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Three_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Three_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Three_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 13
                    method = "Segmenting Four Sound Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Four_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Four_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Four_Sound
                        date3 = Convert.ToDateTime(FirstDate.Date)
                    End If
                Case 14
                    method = "Segmenting Five Sound Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Five_Sound
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Five_Sound
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Five_Sound
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 15
                    method = "Segmenting Two Sound Non-Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Two_snd_NonWord
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Two_snd_NonWord
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Two_snd_NonWord
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 16
                    method = "Segmenting Three Sound Non-Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Three_snd_NonWord
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Three_snd_NonWord
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Three_snd_NonWord
                        date3 = Convert.ToDateTime(ThirdDate.Date)
                    End If
                Case 17
                    method = "Segmenting Four Sound Non-Words"
                    If FirstDate_Segmenting Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        score1 = FirstDate_Segmenting.Four_snd_NonWord
                        date1 = Convert.ToDateTime(FirstDate.Date)
                    End If
                    If SecondDate_Segmenting Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = SecondDate_Segmenting.Four_snd_NonWord
                        date2 = Convert.ToDateTime(SecondDate.Date)
                    End If
                    If ThirdDate_Segmenting Is Nothing Then
                        date3 = #1/1/1900#
                        score3 = "n/a"
                    Else
                        score3 = ThirdDate_Segmenting.Four_snd_NonWord
                        date3 = Convert.ToDateTime(ThirdDate.Date)

                    End If
                Case 18
                    method = "Language"
                    score1 = String.Empty
                    score2 = String.Empty
                    score3 = String.Empty
                Case 19
                    method = "CELF-R"
                    Dim peabodyTestivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "CELF-R"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim peabodyTestivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "CELF-R"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim peabodyTestivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "CELF-R"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If peabodyTestivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = peabodyTestivaDate1.Date
                        score1 = peabodyTestivaDate1.Raw_Score
                    End If

                    If peabodyTestivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = peabodyTestivaDate2.Raw_Score
                        date2 = peabodyTestivaDate2.Date
                    End If
                    If peabodyTestivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = peabodyTestivaDate3.Raw_Score
                        date3 = peabodyTestivaDate3.Date
                    End If
                Case 20
                    method = "Expressive Vocabulary Test-2A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 21
                    method = "OWLS"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Comprehension" And p.Test_Name = "OWLS"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                         Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Comprehension" And p.Test_Name = "OWLS"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                          Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Comprehension" And p.Test_Name = "OWLS"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 22
                    method = "Peabody Pict Vocab Test-IVA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 23
                    method = "Expressive Vocabulary Test-2A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 24
                    method = "Test Lang Level P3"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Understanding" And p.Test_Name = "Test Lang Level P3"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Understanding" And p.Test_Name = "Test Lang Level P3"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Understanding" And p.Test_Name = "Test Lang Level P3"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 25
                    method = "Test Lang Level P3I"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "Test Lang Level P3I"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "Test Lang Level P3I"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "Test Lang Level P3I"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 26
                    method = "DAB-3"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "DAB-3"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "DAB-3"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Syntax - Grammatic Completion" And p.Test_Name = "DAB-3"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 27
                    method = "Expressive Vocabulary Test-2B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Expressive Vocabulary" And p.Test_Name = "Expressive Vocabulary Test-2B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

                Case 28
                    method = "Peabody Pict Vocab Test-IVB"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVB"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                             Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVB"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                           Where p.StudentId = studentNo And p.Group = "Language" And p.Function = "Vocabulary Receptive" And p.Test_Name = "Peabody Pict Vocab Test-IVB"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 29

                    method = "Memory"
                    score1 = String.Empty
                    score2 = String.Empty
                    score3 = String.Empty
                Case 30
                    method = "Digital Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 31
                    method = "Non-Word Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 32
                    method = "Sentence Span-TOLD P3"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 33
                    method = "Word Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

                Case 34
                    method = "Digital Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Digital Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 35
                    method = "Non-Word Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Non-word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 36
                    method = "Sentence Span-TOLD P3"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Sentence Span" And p.Test_Name = "TOLD P3"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 37
                    method = "Word Span-AWMA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "Word Span" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

                Case 38
                    method = "WM-Reverse Digits"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "WM-Reverse Digits" And p.Test_Name = "AWMA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "WM-Reverse Digits" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Memory" And p.Function = "WM-Reverse Digits" And p.Test_Name = "AWMA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 39
                    method = "Rapid Naming"
                    score1 = String.Empty
                    score2 = String.Empty
                    score3 = String.Empty
                Case 40
                    method = "RAN-Colors/min-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors/min" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

                Case 41
                    method = "RAN-Colors-SS-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors-SS" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Colors-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 42
                    method = "RAN-Letters/min-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters/min" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 43
                    method = "RAN-Letters-SS-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters-SS" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Letters-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 44
                    method = "RAN-Numbers/min-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers/min" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 45
                    method = "RAN-Numbers-SS-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers-SS" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Numbers-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 46
                    method = "RAN-Objects/min-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects/min" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects/min" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 47
                    method = "RAN-Objects-SS-CTOPP"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects-SS" And p.Test_Name = "CTOPP"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Rapid Naming" And p.Function = "RAN-Objects-SS" And p.Test_Name = "CTOPP"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 48
                    method = "Spelling"
                Case 49
                    method = "Test Writing Spelling III A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                    Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 50
                    method = "Test Writing Spelling III B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                         Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling III B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 51
                    method = "Test Writing Spelling IVA"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVA"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVA"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVA"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 52
                    method = "Test Writing Spelling IVB"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVB"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVB"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "Test Writing Spelling IVB"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 53
                    method = "DAB-3"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "DAB-3"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "DAB-3"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "DAB-3"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 54
                    method = "TOC"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "TOC"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "TOC"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Spelling" And p.Function = "Real Words-Accuracy" And p.Test_Name = "TOC"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 55
                    method = "Text Reading"
                    score1 = String.Empty
                    score2 = String.Empty
                    score3 = String.Empty
                Case 56
                    method = "Gray Oral Reading Test - Accuracy A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 57
                    method = "Gray Oral Reading Test - Comprehension A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 58
                    method = "Diagnostic Assessment Battery"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension Silent" And p.Test_Name = "Diagnostic Assessment Battery"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                     Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension Silent" And p.Test_Name = "Diagnostic Assessment Battery"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension Silent" And p.Test_Name = "Diagnostic Assessment Battery"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 59
                    method = "Phonics-Based Reading Test"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Open ended" And p.Test_Name = "Phonics-Based Reading Test"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Open ended" And p.Test_Name = "Phonics-Based Reading Test"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Open ended" And p.Test_Name = "Phonics-Based Reading Test"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 60
                    method = "Gray Oral Reading Test - Rate A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 61
                    method = "Gray Oral Reading Test - Accuracy B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Accuracy" And p.Test_Name = "Gray Oral Reading Test - Accuracy B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

                Case 62
                    method = "Gray Oral Reading Test - Comprehension B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Comprehension - Multiple Choice" And p.Test_Name = "Gray Oral Reading Test - Comprehension B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 63
                    method = "Gray Oral Reading Test - Rate B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Gray Oral Reading Test - Rate B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 64
                    method = "Phonics Based Reading Test"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Phonics Based Reading Test"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Phonics Based Reading Test"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Text Rate" And p.Test_Name = "Phonics Based Reading Test"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 65
                    method = "Word Reading"
                    score1 = String.Empty
                    score2 = String.Empty
                    score3 = String.Empty
                Case 66
                    method = "Woodcock Rd Mastery Word Attack-G"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-G"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-G"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Text Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-G"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 67
                    method = "Test Word Reading Efficiency Sight Word Efficiency-A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 68
                    method = "Woodcock Rd Mastery Word Identification-G"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-G"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-G"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-G"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 69
                    method = "Test Word Reading Effeciency Sight Word Efficiency-A"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-A"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-A"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                        Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-A"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 70
                    method = "Woodcock Rd Mastery Word Attack-H"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-H"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-H"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Attack-H"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 71
                    method = "Test Word Reading Efficiency Sight Word Efficiency-B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Decoding Efficiency" And p.Test_Name = "Test Word Reading Efficiency Sight Word Efficiency-B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 72
                    method = "Woodcock Rd Mastery Word Identification-H"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-H"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-H"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Accuracy" And p.Test_Name = "Woodcock Rd Mastery Word Identification-H"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If
                Case 73
                    method = "Test Word Reading Effeciency Sight Word Efficiency-B"
                    Dim testivaDate1 = (From p In dbContext.Assessments
                                       Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-B"
                                       Order By p.Date Ascending Take (1)
                                       Select p).FirstOrDefault()

                    Dim testivaDate2 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-B"
                                      Order By p.Date Descending Skip (1) Take (1)
                                      Select p).FirstOrDefault()

                    Dim testivaDate3 = (From p In dbContext.Assessments
                                      Where p.StudentId = studentNo And p.Group = "Word Reading" And p.Function = "Word Store Efficiency" And p.Test_Name = "Test Word Reading Effeciency Sight Word Efficiency-B"
                                      Order By p.Date Descending Take (1)
                                      Select p).FirstOrDefault()

                    If testivaDate1 Is Nothing Then
                        score1 = "n/a"
                        date1 = #1/1/1900#
                    Else
                        date1 = testivaDate1.Date
                        score1 = testivaDate1.Raw_Score
                    End If

                    If testivaDate2 Is Nothing Then
                        score2 = "n/a"
                        date2 = #1/1/1900#
                    Else
                        score2 = testivaDate2.Raw_Score
                        date2 = testivaDate2.Date
                    End If
                    If testivaDate3 Is Nothing Then
                        score3 = "n/a"
                        date3 = #1/1/1900#
                    Else
                        score3 = testivaDate3.Raw_Score
                        date3 = testivaDate3.Date
                    End If

            End Select


            If x > 1 Then
                testvalues.Add(New ExportDateHeader(String.Empty, method, score1, score2, score3, x, date1, date2, date3))
            End If
        Next
        Return testvalues.ToList()
    End Function

End Class
Public Class ExportDateHeader

    Private _method As String = String.Empty
    Private _score1 As String = String.Empty
    Private _score2 As String = String.Empty
    Private _score3 As String = String.Empty
    Public Sub New(ByVal studentName As String, ByVal method As String, ByVal _score1 As String, ByVal _score2 As String, ByVal _score3 As String, ByVal _order As Integer, ByVal _date1 As Date, ByVal _date2 As Date, ByVal _date3 As Date)
        Me.First_Date = _score1
        Me.Second_From_Last_Date = _score2
        Me.Last_Date = _score3
        Me.Measure = method
        Me.Name = studentName
        Me.Index = _order
        Me.First_RecordingDate = _date1
        Me.Second_RecordingDate = _date2
        Me.Third_RecordingDate = _date3

    End Sub
    Public Property Name As String

    Public Property Measure As String
      
    Public Property First_Date As String
        
    Public Property Second_From_Last_Date As String
      


    Public Property Last_Date As String
      

    Public Property Index As Integer

    Public Property First_RecordingDate As Date

    Public Property Second_RecordingDate As Date

    Public Property Third_RecordingDate As Date






End Class
