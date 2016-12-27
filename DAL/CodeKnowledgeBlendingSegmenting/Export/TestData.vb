Imports System
Imports System.Linq
Imports System.Collections.Generic
Public Class TestData
    Public Shared Function ExportByDateRange(ByVal student As String, ByVal _studentName As String, ByVal startDate As String, ByVal stopDate As String, ByVal studentData As List(Of ExportTestingObject)) As List(Of ExportTestingObject)
        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim CodeKnowledgeValues As New Dictionary(Of String, String)
        Dim BlendingValues As New Dictionary(Of String, String)
        Dim SegmentingValues As New Dictionary(Of String, String)
        Dim testingStartDate As Date = Convert.ToDateTime(startDate)
        Dim testingStopDate As Date = Convert.ToDateTime(stopDate)
        Dim studentNo As Integer = Convert.ToInt32(student)
        'Capture CodeKnowledge Data
        Dim capture1 = From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo And p.Date >= testingStartDate And p.Date <= testingStopDate
                      Select p
        Dim advancedPhonics As String = "x"
        Dim codeKnowledgedate As String = "x"
        Dim beginningPhonics As String = "x"

        Dim index As Integer = 0
        For Each item In capture1
            index = item.Count

            If item.Advanced_Phonics Is Nothing Or item.Advanced_Phonics = "99" Then
                CodeKnowledgeValues("Advanced_Phonics") = "x"

            Else
                CodeKnowledgeValues("Advanced_Phonics") = item.Advanced_Phonics
            End If
            If item.Beginning_Phonics Is Nothing Or item.Beginning_Phonics = "99" Then
                CodeKnowledgeValues("Beginning_Phonics") = "x"
            Else
                CodeKnowledgeValues("Beginning_Phonics") = item.Beginning_Phonics
            End If
            If item.Vowel_Digraphs Is Nothing Or item.Vowel_Digraphs = "99" Then
                CodeKnowledgeValues("Vowel_Digraphs") = "x"

            Else
                CodeKnowledgeValues("Vowel_Digraphs") = item.Vowel_Digraphs
            End If
            If item.Basic_Phonics Is Nothing Or item.Basic_Phonics = "99" Then
                CodeKnowledgeValues("Basic_Phonics") = "x"
            Else
                CodeKnowledgeValues("Basic_Phonics") = item.Basic_Phonics
            End If
            If item.Consonant_Digraphs Is Nothing Or item.Consonant_Digraphs = "99" Then
                CodeKnowledgeValues("Two_Consonant") = "x"
            Else
                CodeKnowledgeValues("Two_Consonant") = item.Consonant_Digraphs
            End If



            If item.sv Is Nothing Or item.sv = "99" Then
                CodeKnowledgeValues("Short_Vowel") = "x"
            Else
                CodeKnowledgeValues("Short_Vowel") = item.sv
            End If

            If item.con Is Nothing Or item.con = "99" Then
                CodeKnowledgeValues("Consonant") = "x"
            Else
                CodeKnowledgeValues("Consonant") = item.con
            End If
            If item.cdg Is Nothing Or item.cdg = "99" Then
                CodeKnowledgeValues("Consonant_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Consonant_Diagraphs") = item.cdg
            End If
            If item.ovdg Is Nothing Or item.ovdg = "99" Then
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = item.ovdg
            End If
            If item.var_vdg Is Nothing Or item.var_vdg = "99" Then
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = item.var_vdg
            End If


            codeKnowledgedate = item.Date



            'Capture Blending Data
            Dim blendingsum1, blendingsum2, blendingsum3, blendingsum4 As Int16
            Dim blendingTotal As Int16 = 0
            Dim blending2snd As String = "x"
            Dim blendingsum As Integer = 0

            Dim capture2 = (From b In dbContext.Blending_Summation
                          Where b.StudentNo = studentNo And b.Count = index And b.Date = codeKnowledgedate
                          Select b).FirstOrDefault

            If capture2 Is Nothing Then
                BlendingValues("Two_Sound") = "x"
                BlendingValues("Three_Sound") = "x"
                BlendingValues("Four_Sound") = "x"
                BlendingValues("Five_Sound") = "x"

            Else

                If capture2.Two_Sound Is Nothing Or capture2.Two_Sound = "99" Then
                    BlendingValues("Two_Sound") = "x"
                    blendingsum1 = 0
                Else
                    BlendingValues("Two_Sound") = capture2.Two_Sound
                    blendingsum1 = (Convert.ToInt16(capture2.Two_Sound))
                End If

                If capture2.Three_Sound Is Nothing Or capture2.Three_Sound = "99" Then
                    BlendingValues("Three_Sound") = "x"
                    blendingsum2 = 0
                Else
                    BlendingValues("Three_Sound") = capture2.Three_Sound
                    blendingsum2 = (Convert.ToInt16(capture2.Three_Sound))
                End If

                If capture2.Four_Sound Is Nothing Or capture2.Four_Sound = "99" Then
                    BlendingValues("Four_Sound") = "x"
                    blendingsum3 = 0
                Else
                    BlendingValues("Four_Sound") = capture2.Four_Sound
                    blendingsum3 = (Convert.ToInt16(capture2.Four_Sound))
                End If

                If capture2.Five_Sound Is Nothing Or capture2.Five_Sound = "99" Then
                    BlendingValues("Five_Sound") = "x"
                    blendingsum4 = 0
                Else
                    BlendingValues("Five_Sound") = capture2.Five_Sound
                    blendingsum4 = (Convert.ToInt16(capture2.Five_Sound))
                End If
                blendingTotal = blendingsum1 + blendingsum2 + blendingsum3 + blendingsum4
            End If


            'Capture Segmenting Date
            Dim segmentingTotal As Int16 = 0
            Dim segmentingsum1, segmentingsum2, segmentingsum3, segmentingsum4, segmentingsum5, segmentingsum6, segmentingsum7 As Int16

            Dim segment3snd As String = "x"
            Dim capture3 = (From c In dbContext.Segmenting_Summation
                         Where c.StudentNo = studentNo And c.Count = index And c.Date = codeKnowledgedate
                         Select c).FirstOrDefault
            If capture3 Is Nothing Then
                SegmentingValues("Two_Sound") = "x"
                SegmentingValues("Three_Sound") = "x"
                SegmentingValues("Four_Sound") = "x"
                SegmentingValues("Five_Sound") = "x"
                SegmentingValues("Two_snd_NonWord") = "x"
                SegmentingValues("Three_snd_NonWord") = "x"
                SegmentingValues("Four_snd_NonWord") = "x"
            Else

                If capture3.Two_Sound Is Nothing Or capture3.Two_Sound = "99" Then
                    segmentingsum1 = 0
                    SegmentingValues("Two_Sound") = "x"
                Else
                    SegmentingValues("Two_Sound") = capture3.Two_Sound
                    segmentingsum1 = Convert.ToInt16(capture3.Two_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Three_Sound = "99" Then
                    segmentingsum2 = 0
                    SegmentingValues("Three_Sound") = "x"
                Else
                    SegmentingValues("Three_Sound") = capture3.Three_Sound
                    segmentingsum2 = Convert.ToInt16(capture3.Three_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Four_Sound = "99" Then
                    segmentingsum3 = 0
                    SegmentingValues("Four_Sound") = "x"
                Else
                    SegmentingValues("Four_Sound") = capture3.Four_Sound
                    segmentingsum3 = Convert.ToInt16(capture3.Four_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Five_Sound = "99" Then
                    segmentingsum4 = 0
                    SegmentingValues("Five_Sound") = "x"
                Else
                    SegmentingValues("Five_Sound") = capture3.Five_Sound
                    segmentingsum4 = Convert.ToInt16(capture3.Five_Sound)
                End If
                If capture3.Two_snd_NonWord Is Nothing Or capture3.Two_snd_NonWord = "99" Then
                    segmentingsum5 = 0
                    SegmentingValues("Two_snd_NonWord") = "x"
                Else
                    SegmentingValues("Two_snd_NonWord") = capture3.Two_snd_NonWord
                    segmentingsum5 = Convert.ToInt16(capture3.Two_snd_NonWord)
                End If
                If capture3.Three_snd_NonWord Is Nothing Or capture3.Three_snd_NonWord = "99" Then
                    segmentingsum6 = 0
                    SegmentingValues("Three_snd_NonWord") = "x"
                Else
                    SegmentingValues("Three_snd_NonWord") = capture3.Three_snd_NonWord
                    segmentingsum6 = Convert.ToInt16(capture3.Three_snd_NonWord)
                End If
                If capture3.Four_snd_NonWord Is Nothing Or capture3.Four_snd_NonWord = "99" Then
                    segmentingsum7 = 0
                    SegmentingValues("Four_snd_NonWord") = "x"
                Else
                    SegmentingValues("Four_snd_NonWord") = capture3.Four_snd_NonWord
                    segmentingsum7 = Convert.ToInt16(capture3.Four_snd_NonWord)
                End If
                segmentingTotal = segmentingsum1 + segmentingsum2 + segmentingsum3 + segmentingsum4 + segmentingsum5 + segmentingsum6 + segmentingsum7
            End If



            studentData.Add(New ExportTestingObject(studentNo, _studentName, item.Date, CodeKnowledgeValues, BlendingValues, SegmentingValues, blendingTotal.ToString(), segmentingTotal.ToString))
        Next
        Return studentData
    End Function
End Class
Public Class TestDataByRecord


    Public Shared Function ExportAll(ByVal student As String, ByVal _studentName As String, ByVal studentData As List(Of ExportTestingObject)) As List(Of ExportTestingObject)
        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim CodeKnowledgeValues As New Dictionary(Of String, String)
        Dim BlendingValues As New Dictionary(Of String, String)
        Dim SegmentingValues As New Dictionary(Of String, String)

        Dim studentNo As Integer = Convert.ToInt32(student)
        'Capture CodeKnowledge Data
        Dim capture1 = From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo
                      Select p
        Dim advancedPhonics As String = "x"
        Dim codeKnowledgedate As String = "x"
        Dim beginningPhonics As String = "x"

        Dim index As Integer = 0
        For Each item In capture1
            index = item.Count

            If item.Advanced_Phonics Is Nothing Or item.Advanced_Phonics = "99" Then
                CodeKnowledgeValues("Advanced_Phonics") = "x"

            Else
                CodeKnowledgeValues("Advanced_Phonics") = item.Advanced_Phonics
            End If
            If item.Beginning_Phonics Is Nothing Or item.Beginning_Phonics = "99" Then
                CodeKnowledgeValues("Beginning_Phonics") = "x"
            Else
                CodeKnowledgeValues("Beginning_Phonics") = item.Beginning_Phonics
            End If
            If item.Vowel_Digraphs Is Nothing Or item.Vowel_Digraphs = "99" Then
                CodeKnowledgeValues("Vowel_Digraphs") = "x"

            Else
                CodeKnowledgeValues("Vowel_Digraphs") = item.Vowel_Digraphs
            End If
            If item.Basic_Phonics Is Nothing Or item.Basic_Phonics = "99" Then
                CodeKnowledgeValues("Basic_Phonics") = "x"
            Else
                CodeKnowledgeValues("Basic_Phonics") = item.Basic_Phonics
            End If
            If item.Consonant_Digraphs Is Nothing Or item.Consonant_Digraphs = "99" Then
                CodeKnowledgeValues("Two_Consonant") = "x"
            Else
                CodeKnowledgeValues("Two_Consonant") = item.Consonant_Digraphs
            End If



            If item.sv Is Nothing Or item.sv = "99" Then
                CodeKnowledgeValues("Short_Vowel") = "x"
            Else
                CodeKnowledgeValues("Short_Vowel") = item.sv
            End If

            If item.con Is Nothing Or item.con = "99" Then
                CodeKnowledgeValues("Consonant") = "x"
            Else
                CodeKnowledgeValues("Consonant") = item.con
            End If
            If item.cdg Is Nothing Or item.cdg = "99" Then
                CodeKnowledgeValues("Consonant_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Consonant_Diagraphs") = item.cdg
            End If
            If item.ovdg Is Nothing Or item.ovdg = "99" Then
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = item.ovdg
            End If
            If item.var_vdg Is Nothing Or item.var_vdg = "99" Then
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = item.var_vdg
            End If


            codeKnowledgedate = item.Date

            'Capture Blending Data

            Dim blendingsum1, blendingsum2, blendingsum3, blendingsum4 As Int16
            Dim blendingTotal As Int16 = 0
            Dim blending2snd As String = "x"
            Dim blendingsum As Integer = 0
            Dim capture2 = (From b In dbContext.Blending_Summation
                          Where b.StudentNo = studentNo And b.Count = index
                          Select b).FirstOrDefault

            If capture2 Is Nothing Then
                BlendingValues("Two_Sound") = "x"
                BlendingValues("Three_Sound") = "x"
                BlendingValues("Four_Sound") = "x"
                BlendingValues("Five_Sound") = "x"

            Else

                If capture2.Two_Sound Is Nothing Or capture2.Two_Sound = "99" Then
                    BlendingValues("Two_Sound") = "x"
                    blendingsum1 = 0
                Else
                    BlendingValues("Two_Sound") = capture2.Two_Sound
                    blendingsum1 = (Convert.ToInt16(capture2.Two_Sound))
                End If

                If capture2.Three_Sound Is Nothing Or capture2.Three_Sound = "99" Then
                    BlendingValues("Three_Sound") = "x"
                    blendingsum2 = 0
                Else
                    BlendingValues("Three_Sound") = capture2.Three_Sound
                    blendingsum2 = (Convert.ToInt16(capture2.Three_Sound))
                End If

                If capture2.Four_Sound Is Nothing Or capture2.Four_Sound = "99" Then
                    BlendingValues("Four_Sound") = "x"
                    blendingsum3 = 0
                Else
                    BlendingValues("Four_Sound") = capture2.Four_Sound
                    blendingsum3 = (Convert.ToInt16(capture2.Four_Sound))
                End If

                If capture2.Five_Sound Is Nothing Or capture2.Five_Sound = "99" Then
                    BlendingValues("Five_Sound") = "x"
                    blendingsum4 = 0
                Else
                    BlendingValues("Five_Sound") = capture2.Five_Sound
                    blendingsum4 = (Convert.ToInt16(capture2.Five_Sound))
                End If
                blendingTotal = blendingsum1 + blendingsum2 + blendingsum3 + blendingsum4
            End If

            'Capture Segmenting Date
            Dim segmentingTotal As Int16 = 0
            Dim segmentingsum1, segmentingsum2, segmentingsum3, segmentingsum4, segmentingsum5, segmentingsum6, segmentingsum7 As Int16

            Dim segment3snd As String = "x"
            Dim capture3 = (From c In dbContext.Segmenting_Summation
                         Where c.StudentNo = studentNo And c.Count = index
                         Select c).FirstOrDefault
            If capture3 Is Nothing Then
                SegmentingValues("Two_Sound") = "x"
                SegmentingValues("Three_Sound") = "x"
                SegmentingValues("Four_Sound") = "x"
                SegmentingValues("Five_Sound") = "x"
                SegmentingValues("Two_snd_NonWord") = "x"
                SegmentingValues("Three_snd_NonWord") = "x"
                SegmentingValues("Four_snd_NonWord") = "x"
            Else

                If capture3.Two_Sound Is Nothing Or capture3.Two_Sound = "99" Then
                    segmentingsum1 = 0
                    SegmentingValues("Two_Sound") = "x"
                Else
                    SegmentingValues("Two_Sound") = capture3.Two_Sound
                    segmentingsum1 = Convert.ToInt16(capture3.Two_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Three_Sound = "99" Then
                    segmentingsum2 = 0
                    SegmentingValues("Three_Sound") = "x"
                Else
                    SegmentingValues("Three_Sound") = capture3.Three_Sound
                    segmentingsum2 = Convert.ToInt16(capture3.Three_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Four_Sound = "99" Then
                    segmentingsum3 = 0
                    SegmentingValues("Four_Sound") = "x"
                Else
                    SegmentingValues("Four_Sound") = capture3.Four_Sound
                    segmentingsum3 = Convert.ToInt16(capture3.Four_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Five_Sound = "99" Then
                    segmentingsum4 = 0
                    SegmentingValues("Five_Sound") = "x"
                Else
                    SegmentingValues("Five_Sound") = capture3.Five_Sound
                    segmentingsum4 = Convert.ToInt16(capture3.Five_Sound)
                End If
                If capture3.Two_snd_NonWord Is Nothing Or capture3.Two_snd_NonWord = "99" Then
                    segmentingsum5 = 0
                    SegmentingValues("Two_snd_NonWord") = "x"
                Else
                    SegmentingValues("Two_snd_NonWord") = capture3.Two_snd_NonWord
                    segmentingsum5 = Convert.ToInt16(capture3.Two_snd_NonWord)
                End If
                If capture3.Three_snd_NonWord Is Nothing Or capture3.Three_snd_NonWord = "99" Then
                    segmentingsum6 = 0
                    SegmentingValues("Three_snd_NonWord") = "x"
                Else
                    SegmentingValues("Three_snd_NonWord") = capture3.Three_snd_NonWord
                    segmentingsum6 = Convert.ToInt16(capture3.Three_snd_NonWord)
                End If
                If capture3.Four_snd_NonWord Is Nothing Or capture3.Four_snd_NonWord = "99" Then
                    segmentingsum7 = 0
                    SegmentingValues("Four_snd_NonWord") = "x"
                Else
                    SegmentingValues("Four_snd_NonWord") = capture3.Four_snd_NonWord
                    segmentingsum7 = Convert.ToInt16(capture3.Four_snd_NonWord)
                End If
                segmentingTotal = segmentingsum1 + segmentingsum2 + segmentingsum3 + segmentingsum4 + segmentingsum5 + segmentingsum6 + segmentingsum7
            End If



            studentData.Add(New ExportTestingObject(studentNo, _studentName, item.Date, CodeKnowledgeValues, BlendingValues, SegmentingValues, blendingTotal.ToString(), segmentingTotal.ToString))
        Next

        Return studentData
    End Function

   
End Class
Public Interface IFirstAndLastTwo
    Function Record(ByVal student As String, ByVal _studentName As String, ByVal studentData As List(Of ExportTestingObject)) As List(Of ExportTestingObject)
End Interface
Public Class ExportFirstTestRecord
    Implements IFirstAndLastTwo
    Public Function Record(ByVal student As String, ByVal _studentName As String, ByVal studentData As List(Of ExportTestingObject)) As List(Of ExportTestingObject) Implements IFirstAndLastTwo.Record
        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim CodeKnowledgeValues As New Dictionary(Of String, String)
        Dim BlendingValues As New Dictionary(Of String, String)
        Dim SegmentingValues As New Dictionary(Of String, String)

        Dim studentNo As Integer = Convert.ToInt32(student)
        'Capture CodeKnowledge Data
        Dim capture1 = From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo
                      Order By p.Date Ascending
                      Take (1)
                      Select p
        Dim advancedPhonics As String = "x"
        Dim codeKnowledgedate As String = "x"
        Dim beginningPhonics As String = "x"
        Dim index As Integer = 0
        Dim x As Integer = 0

        For Each item In capture1
            x = x + 1
            index = item.Count

            If item.Advanced_Phonics Is Nothing Or item.Advanced_Phonics = "99" Then
                CodeKnowledgeValues("Advanced_Phonics") = "x"

            Else
                CodeKnowledgeValues("Advanced_Phonics") = item.Advanced_Phonics
            End If
            If item.Beginning_Phonics Is Nothing Or item.Beginning_Phonics = "99" Then
                CodeKnowledgeValues("Beginning_Phonics") = "x"
            Else
                CodeKnowledgeValues("Beginning_Phonics") = item.Beginning_Phonics
            End If
            If item.Vowel_Digraphs Is Nothing Or item.Vowel_Digraphs = "99" Then
                CodeKnowledgeValues("Vowel_Digraphs") = "x"

            Else
                CodeKnowledgeValues("Vowel_Digraphs") = item.Vowel_Digraphs
            End If
            If item.Basic_Phonics Is Nothing Or item.Basic_Phonics = "99" Then
                CodeKnowledgeValues("Basic_Phonics") = "x"
            Else
                CodeKnowledgeValues("Basic_Phonics") = item.Basic_Phonics
            End If
            If item.Consonant_Digraphs Is Nothing Or item.Consonant_Digraphs = "99" Then
                CodeKnowledgeValues("Two_Consonant") = "x"
            Else
                CodeKnowledgeValues("Two_Consonant") = item.Consonant_Digraphs
            End If



            If item.sv Is Nothing Or item.sv = "99" Then
                CodeKnowledgeValues("Short_Vowel") = "x"
            Else
                CodeKnowledgeValues("Short_Vowel") = item.sv
            End If

            If item.con Is Nothing Or item.con = "99" Then
                CodeKnowledgeValues("Consonant") = "x"
            Else
                CodeKnowledgeValues("Consonant") = item.con
            End If
            If item.cdg Is Nothing Or item.cdg = "99" Then
                CodeKnowledgeValues("Consonant_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Consonant_Diagraphs") = item.cdg
            End If
            If item.ovdg Is Nothing Or item.ovdg = "99" Then
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = item.ovdg
            End If
            If item.var_vdg Is Nothing Or item.var_vdg = "99" Then
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = item.var_vdg
            End If

            codeKnowledgedate = item.Date


            'Capture Blending Data
            Dim blendingsum1, blendingsum2, blendingsum3, blendingsum4 As Int16
            Dim blendingTotal As Int16 = 0
            Dim blending2snd As String = "x"
            Dim blendingsum As Integer = 0
            Dim capture2 = (From b In dbContext.Blending_Summation
                          Where b.StudentNo = studentNo And b.Count = index
                          Select b).FirstOrDefault

            If capture2 Is Nothing Then
                BlendingValues("Two_Sound") = "x"
                BlendingValues("Three_Sound") = "x"
                BlendingValues("Four_Sound") = "x"
                BlendingValues("Five_Sound") = "x"

            Else

                If capture2.Two_Sound Is Nothing Or capture2.Two_Sound = "99" Then
                    BlendingValues("Two_Sound") = "x"
                    blendingsum1 = 0
                Else
                    BlendingValues("Two_Sound") = capture2.Two_Sound
                    blendingsum1 = (Convert.ToInt16(capture2.Two_Sound))
                End If

                If capture2.Three_Sound Is Nothing Or capture2.Three_Sound = "99" Then
                    BlendingValues("Three_Sound") = "x"
                    blendingsum2 = 0
                Else
                    BlendingValues("Three_Sound") = capture2.Three_Sound
                    blendingsum2 = (Convert.ToInt16(capture2.Three_Sound))
                End If

                If capture2.Four_Sound Is Nothing Or capture2.Four_Sound = "99" Then
                    BlendingValues("Four_Sound") = "x"
                    blendingsum3 = 0
                Else
                    BlendingValues("Four_Sound") = capture2.Four_Sound
                    blendingsum3 = (Convert.ToInt16(capture2.Four_Sound))
                End If

                If capture2.Five_Sound Is Nothing Or capture2.Five_Sound = "99" Then
                    BlendingValues("Five_Sound") = "x"
                    blendingsum4 = 0
                Else
                    BlendingValues("Five_Sound") = capture2.Five_Sound
                    blendingsum4 = (Convert.ToInt16(capture2.Five_Sound))
                End If
                blendingTotal = blendingsum1 + blendingsum2 + blendingsum3 + blendingsum4
            End If





            'Capture Segmenting Date
            Dim segmentingTotal As Int16 = 0
            Dim segmentingsum1, segmentingsum2, segmentingsum3, segmentingsum4, segmentingsum5, segmentingsum6, segmentingsum7 As Int16
            Dim segment3snd As String = "x"
            Dim capture3 = (From c In dbContext.Segmenting_Summation
                         Where c.StudentNo = studentNo And c.Count = index
                         Select c).FirstOrDefault
            If capture3 Is Nothing Then
                SegmentingValues("Two_Sound") = "x"
                SegmentingValues("Three_Sound") = "x"
                SegmentingValues("Four_Sound") = "x"
                SegmentingValues("Five_Sound") = "x"
                SegmentingValues("Two_snd_NonWord") = "x"
                SegmentingValues("Three_snd_NonWord") = "x"
                SegmentingValues("Four_snd_NonWord") = "x"
            Else

                If capture3.Two_Sound Is Nothing Or capture3.Two_Sound = "99" Then
                    segmentingsum1 = 0
                    SegmentingValues("Two_Sound") = "x"
                Else
                    SegmentingValues("Two_Sound") = capture3.Two_Sound
                    segmentingsum1 = Convert.ToInt16(capture3.Two_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Three_Sound = "99" Then
                    segmentingsum2 = 0
                    SegmentingValues("Three_Sound") = "x"
                Else
                    SegmentingValues("Three_Sound") = capture3.Three_Sound
                    segmentingsum2 = Convert.ToInt16(capture3.Three_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Four_Sound = "99" Then
                    segmentingsum3 = 0
                    SegmentingValues("Four_Sound") = "x"
                Else
                    SegmentingValues("Four_Sound") = capture3.Four_Sound
                    segmentingsum3 = Convert.ToInt16(capture3.Four_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Five_Sound = "99" Then
                    segmentingsum4 = 0
                    SegmentingValues("Five_Sound") = "x"
                Else
                    SegmentingValues("Five_Sound") = capture3.Five_Sound
                    segmentingsum4 = Convert.ToInt16(capture3.Five_Sound)
                End If
                If capture3.Two_snd_NonWord Is Nothing Or capture3.Two_snd_NonWord = "99" Then
                    segmentingsum5 = 0
                    SegmentingValues("Two_snd_NonWord") = "x"
                Else
                    SegmentingValues("Two_snd_NonWord") = capture3.Two_snd_NonWord
                    segmentingsum5 = Convert.ToInt16(capture3.Two_snd_NonWord)
                End If
                If capture3.Three_snd_NonWord Is Nothing Or capture3.Three_snd_NonWord = "99" Then
                    segmentingsum6 = 0
                    SegmentingValues("Three_snd_NonWord") = "x"
                Else
                    SegmentingValues("Three_snd_NonWord") = capture3.Three_snd_NonWord
                    segmentingsum6 = Convert.ToInt16(capture3.Three_snd_NonWord)
                End If
                If capture3.Four_snd_NonWord Is Nothing Or capture3.Four_snd_NonWord = "99" Then
                    segmentingsum7 = 0
                    SegmentingValues("Four_snd_NonWord") = "x"
                Else
                    SegmentingValues("Four_snd_NonWord") = capture3.Four_snd_NonWord
                    segmentingsum7 = Convert.ToInt16(capture3.Four_snd_NonWord)
                End If
                segmentingTotal = segmentingsum1 + segmentingsum2 + segmentingsum3 + segmentingsum4 + segmentingsum5 + segmentingsum6 + segmentingsum7
            End If



            studentData.Add(New ExportTestingObject(studentNo, _studentName, item.Date, CodeKnowledgeValues, BlendingValues, SegmentingValues, blendingTotal.ToString(), segmentingTotal.ToString))
        Next


        Return studentData
    End Function
End Class

Public Class ExportLastTwoRecords
    Implements IFirstAndLastTwo
    Public Function Record(ByVal student As String, ByVal _studentName As String, ByVal studentData As List(Of ExportTestingObject)) As List(Of ExportTestingObject) Implements IFirstAndLastTwo.Record
        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim CodeKnowledgeValues As New Dictionary(Of String, String)
        Dim BlendingValues As New Dictionary(Of String, String)
        Dim SegmentingValues As New Dictionary(Of String, String)

        Dim studentNo As Integer = Convert.ToInt32(student)
        'Capture CodeKnowledge Data
        Dim capture1 = From p In dbContext.CodeKnowledge_Summations
                      Where p.StudentNo = studentNo
                      Order By p.Date Descending
                      Take (2)
                      Select p
        Dim advancedPhonics As String = "x"
        Dim codeKnowledgedate As String = "x"
        Dim beginningPhonics As String = "x"
        Dim index As Integer = 0
        Dim x As Integer = 0

        For Each item In capture1
            x = x + 1
            index = item.Count

            If item.Advanced_Phonics Is Nothing Or item.Advanced_Phonics = "99" Then
                CodeKnowledgeValues("Advanced_Phonics") = "x"

            Else
                CodeKnowledgeValues("Advanced_Phonics") = item.Advanced_Phonics
            End If
            If item.Beginning_Phonics Is Nothing Or item.Beginning_Phonics = "99" Then
                CodeKnowledgeValues("Beginning_Phonics") = "x"
            Else
                CodeKnowledgeValues("Beginning_Phonics") = item.Beginning_Phonics
            End If
            If item.Vowel_Digraphs Is Nothing Or item.Vowel_Digraphs = "99" Then
                CodeKnowledgeValues("Vowel_Digraphs") = "x"

            Else
                CodeKnowledgeValues("Vowel_Digraphs") = item.Vowel_Digraphs
            End If
            If item.Basic_Phonics Is Nothing Or item.Basic_Phonics = "99" Then
                CodeKnowledgeValues("Basic_Phonics") = "x"
            Else
                CodeKnowledgeValues("Basic_Phonics") = item.Basic_Phonics
            End If
            If item.Consonant_Digraphs Is Nothing Or item.Consonant_Digraphs = "99" Then
                CodeKnowledgeValues("Two_Consonant") = "x"
            Else
                CodeKnowledgeValues("Two_Consonant") = item.Consonant_Digraphs
            End If



            If item.sv Is Nothing Or item.sv = "99" Then
                CodeKnowledgeValues("Short_Vowel") = "x"
            Else
                CodeKnowledgeValues("Short_Vowel") = item.sv
            End If

            If item.con Is Nothing Or item.con = "99" Then
                CodeKnowledgeValues("Consonant") = "x"
            Else
                CodeKnowledgeValues("Consonant") = item.con
            End If
            If item.cdg Is Nothing Or item.cdg = "99" Then
                CodeKnowledgeValues("Consonant_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Consonant_Diagraphs") = item.cdg
            End If
            If item.ovdg Is Nothing Or item.ovdg = "99" Then
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Obligatory_Vowel_Diagraphs") = item.ovdg
            End If
            If item.var_vdg Is Nothing Or item.var_vdg = "99" Then
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = "x"
            Else
                CodeKnowledgeValues("Variant_Vowel_Diagraphs") = item.var_vdg
            End If

            codeKnowledgedate = item.Date


            'Capture Blending Data
            Dim blendingsum1, blendingsum2, blendingsum3, blendingsum4 As Int16
            Dim blendingTotal As Int16 = 0
            Dim blending2snd As String = "x"
            Dim blendingsum As Integer = 0
            Dim capture2 = (From b In dbContext.Blending_Summation
                          Where b.StudentNo = studentNo And b.Count = index
                          Select b).FirstOrDefault

            If capture2 Is Nothing Then
                BlendingValues("Two_Sound") = "x"
                BlendingValues("Three_Sound") = "x"
                BlendingValues("Four_Sound") = "x"
                BlendingValues("Five_Sound") = "x"
              
            Else

                If capture2.Two_Sound Is Nothing Or capture2.Two_Sound = "99" Then
                    BlendingValues("Two_Sound") = "x"
                    blendingsum1 = 0
                Else
                    BlendingValues("Two_Sound") = capture2.Two_Sound
                    blendingsum1 = (Convert.ToInt16(capture2.Two_Sound))
                End If

                If capture2.Three_Sound Is Nothing Or capture2.Three_Sound = "99" Then
                    BlendingValues("Three_Sound") = "x"
                    blendingsum2 = 0
                Else
                    BlendingValues("Three_Sound") = capture2.Three_Sound
                    blendingsum2 = (Convert.ToInt16(capture2.Three_Sound))
                End If

                If capture2.Four_Sound Is Nothing Or capture2.Four_Sound = "99" Then
                    BlendingValues("Four_Sound") = "x"
                    blendingsum3 = 0
                Else
                    BlendingValues("Four_Sound") = capture2.Four_Sound
                    blendingsum3 = (Convert.ToInt16(capture2.Four_Sound))
                End If

                If capture2.Five_Sound Is Nothing Or capture2.Five_Sound = "99" Then
                    BlendingValues("Five_Sound") = "x"
                    blendingsum4 = 0
                Else
                    BlendingValues("Five_Sound") = capture2.Five_Sound
                    blendingsum4 = (Convert.ToInt16(capture2.Five_Sound))
                End If
                blendingTotal = blendingsum1 + blendingsum2 + blendingsum3 + blendingsum4
            End If





            'Capture Segmenting Date
            Dim segmentingTotal As Int16 = 0
            Dim segmentingsum1, segmentingsum2, segmentingsum3, segmentingsum4, segmentingsum5, segmentingsum6, segmentingsum7 As Int16
            Dim segment3snd As String = "x"
            Dim capture3 = (From c In dbContext.Segmenting_Summation
                         Where c.StudentNo = studentNo And c.Count = index
                         Select c).FirstOrDefault
            If capture3 Is Nothing Then
                SegmentingValues("Two_Sound") = "x"
                SegmentingValues("Three_Sound") = "x"
                SegmentingValues("Four_Sound") = "x"
                SegmentingValues("Five_Sound") = "x"
                SegmentingValues("Two_snd_NonWord") = "x"
                SegmentingValues("Three_snd_NonWord") = "x"
                SegmentingValues("Four_snd_NonWord") = "x"
            Else

                If capture3.Two_Sound Is Nothing Or capture3.Two_Sound = "99" Then
                    segmentingsum1 = 0
                    SegmentingValues("Two_Sound") = "x"
                Else
                    SegmentingValues("Two_Sound") = capture3.Two_Sound
                    segmentingsum1 = Convert.ToInt16(capture3.Two_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Three_Sound = "99" Then
                    segmentingsum2 = 0
                    SegmentingValues("Three_Sound") = "x"
                Else
                    SegmentingValues("Three_Sound") = capture3.Three_Sound
                    segmentingsum2 = Convert.ToInt16(capture3.Three_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Four_Sound = "99" Then
                    segmentingsum3 = 0
                    SegmentingValues("Four_Sound") = "x"
                Else
                    SegmentingValues("Four_Sound") = capture3.Four_Sound
                    segmentingsum3 = Convert.ToInt16(capture3.Four_Sound)
                End If
                If capture3.Two_Sound Is Nothing Or capture3.Five_Sound = "99" Then
                    segmentingsum4 = 0
                    SegmentingValues("Five_Sound") = "x"
                Else
                    SegmentingValues("Five_Sound") = capture3.Five_Sound
                    segmentingsum4 = Convert.ToInt16(capture3.Five_Sound)
                End If
                If capture3.Two_snd_NonWord Is Nothing Or capture3.Two_snd_NonWord = "99" Then
                    segmentingsum5 = 0
                    SegmentingValues("Two_snd_NonWord") = "x"
                Else
                    SegmentingValues("Two_snd_NonWord") = capture3.Two_snd_NonWord
                    segmentingsum5 = Convert.ToInt16(capture3.Two_snd_NonWord)
                End If
                If capture3.Three_snd_NonWord Is Nothing Or capture3.Three_snd_NonWord = "99" Then
                    segmentingsum6 = 0
                    SegmentingValues("Three_snd_NonWord") = "x"
                Else
                    SegmentingValues("Three_snd_NonWord") = capture3.Three_snd_NonWord
                    segmentingsum6 = Convert.ToInt16(capture3.Three_snd_NonWord)
                End If
                If capture3.Four_snd_NonWord Is Nothing Or capture3.Four_snd_NonWord = "99" Then
                    segmentingsum7 = 0
                    SegmentingValues("Four_snd_NonWord") = "x"
                Else
                    SegmentingValues("Four_snd_NonWord") = capture3.Four_snd_NonWord
                    segmentingsum7 = Convert.ToInt16(capture3.Four_snd_NonWord)
                End If
                segmentingTotal = segmentingsum1 + segmentingsum2 + segmentingsum3 + segmentingsum4 + segmentingsum5 + segmentingsum6 + segmentingsum7
            End If



            studentData.Add(New ExportTestingObject(studentNo, _studentName, item.Date, CodeKnowledgeValues, BlendingValues, SegmentingValues, blendingTotal.ToString(), segmentingTotal.ToString()))
        Next

        Return studentData
    End Function
End Class




Public Class ExportTestingObject
    Public Sub New(ByVal _studentNo As String, ByVal _studentName As String, ByVal _date As String, ByVal _codeKnowledge As Dictionary(Of String, String), ByVal _blending As Dictionary(Of String, String), ByVal _segmenting As Dictionary(Of String, String), ByVal _blendingsum As String, ByVal _segmentingsum As String)
        Me.Student_No = _studentNo
        Me.Name = _studentName
        Me.Test_Date = _date

        Me.Bln = _blendingsum
        Me.Sg = _segmentingsum
        Me.Sv = _codeKnowledge("Short_Vowel")
        Me.Con = _codeKnowledge("Consonant")
        Me.Cdg = _codeKnowledge("Consonant_Diagraphs")
        Me.Ovdg = _codeKnowledge("Obligatory_Vowel_Diagraphs")
        Me.Vvdg = _codeKnowledge("Variant_Vowel_Diagraphs")
        Me.Adv_Phon = _codeKnowledge("Advanced_Phonics")
        Me.Beg_Phon = _codeKnowledge("Beginning_Phonics")
        Me.Vow2 = _codeKnowledge("Vowel_Digraphs")
        Me.Basic_Phon = _codeKnowledge("Basic_Phonics")
        Me.Con2 = _codeKnowledge("Two_Consonant")

        Me.Bln2 = _blending("Two_Sound")
        Me.Bln3 = _blending("Three_Sound")
        Me.Bln4 = _blending("Four_Sound")
        Me.Bln5 = _blending("Five_Sound")

        Me.Sg_2 = _segmenting("Two_Sound")
        Me.Sg_3 = _segmenting("Three_Sound")
        Me.Sg_4 = _segmenting("Four_Sound")
        Me.Sg_5 = _segmenting("Five_Sound")
        Me.Sg2_NWd = _segmenting("Two_snd_NonWord")
        Me.Sg3_NWd = _segmenting("Three_snd_NonWord")
        Me.Sg4_NWd = _segmenting("Four_snd_NonWord")




    End Sub

    Public Property Student_No As String

    Public Property Name As String

    Public Property Test_Date As String

    Public Property Bln As String
    Public Property Sg As String
    Public Property Sv As String
    Public Property Con As String
    Public Property Cdg As String
    Public Property Ovdg As String
    Public Property Vvdg As String

    Public Property Beg_Phon As String
    Public Property Basic_Phon As String
    Public Property Adv_Phon As String
    Public Property Vow2 As String

    Public Property Con2 As String


    Public Property Bln2 As String
    Public Property Bln3 As String



    Public Property Bln4 As String

    Public Property Bln5 As String

    Public Property Sg_2 As String

    Public Property Sg_3 As String

    Public Property Sg_4 As String

    Public Property Sg_5 As String

    Public Property Sg2_NWd As String

    Public Property Sg3_NWd As String

    Public Property Sg4_NWd As String



   

End Class
