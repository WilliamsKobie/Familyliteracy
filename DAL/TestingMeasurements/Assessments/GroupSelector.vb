Public Class GroupSelector


    Public Shared Function TestingLabels(ByVal selection As Integer) As List(Of AssessmentObject)
        Dim result = New List(Of AssessmentObject)
        Dim assessmentGroup As ItestMethod
        Select Case (selection)
            Case 0
                assessmentGroup = New Phonological_Awareness
                result = assessmentGroup.TestListing()

            Case 1
                assessmentGroup = New Rapid_Naming
                result = assessmentGroup.TestListing()

            Case 2
                assessmentGroup = New Memory
                result = assessmentGroup.TestListing()

            Case 3
                assessmentGroup = New Language
                result = assessmentGroup.TestListing()

            Case 4
                assessmentGroup = New Word_Reading
                result = assessmentGroup.TestListing()

            Case 5
                assessmentGroup = New Text_Reading
                result = assessmentGroup.TestListing()

            Case 6
                assessmentGroup = New Spelling
                result = assessmentGroup.TestListing()

        End Select

        Return result
    End Function

    Public Shared Function GroupListing(ByVal selectedfunction As Integer) As List(Of AssessmentObject)
        Dim result = New List(Of AssessmentObject)
        Dim assessmentGroup As ItestMethod
        Select Case (selectedfunction)
            Case 0
                assessmentGroup = New Phonological_Awareness
                result = assessmentGroup.FunctionListing()

            Case 1
                assessmentGroup = New Rapid_Naming
                result = assessmentGroup.FunctionListing

            Case 2
                assessmentGroup = New Memory
                result = assessmentGroup.FunctionListing

            Case 3
                assessmentGroup = New Language
                result = assessmentGroup.FunctionListing

            Case 4
                assessmentGroup = New Word_Reading
                result = assessmentGroup.FunctionListing

            Case 5
                assessmentGroup = New Text_Reading
                result = assessmentGroup.FunctionListing

            Case 6
                assessmentGroup = New Spelling
                result = assessmentGroup.FunctionListing

        End Select

        Return result
    End Function
End Class


