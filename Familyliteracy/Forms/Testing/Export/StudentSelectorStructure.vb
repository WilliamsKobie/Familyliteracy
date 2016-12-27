Imports DAL
Imports BAL
Imports Familyliteracy.ExportProfileData

Class DefaultScreen
    Implements IResetNames
    Public Function ResetLeftNames(ByVal activeStudents As String) Implements IResetNames.ResetLeftNames



        Dim nameList As List(Of StudentNames) = New List(Of StudentNames)

        Dim getnames As IPopulateSelectedNames = Nothing
        Select Case activeStudents
            Case "all"

                getnames = New SelectAllNames

                nameList = NameListing.ListAllNames()
            Case "active"
                getnames = New SelectActiveNames
                nameList = NameListing.ListActiveNames
            Case "inactive"
                nameList = NameListing.ListNonActiveNames()

        End Select

        StudentSelector.CheckedListBox1.Items.Clear()





        Dim students = From p In nameList
                  Select p

        For Each attribute In students
            If Not StudentSelector.CheckedListBox1.Items.Contains(attribute.FullName.Trim()) Then
                StudentSelector.CheckedListBox1.Items.Add(attribute.FullName.Trim())
            End If
        Next
        Dim test As New List(Of String)()
        test.Add("Beginning Phonics")
        test.Add("Advanced Phonics")
        test.Add("Basic Phonics")
        test.Add("Vowel Digraphs")
        test.Add("Consonant Digraphs")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")

        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        test.Add("")
        StudentSelector.CheckedListBox1.Sorted = True
        Return Nothing
    End Function




       


End Class






Class MoveSelectedNames
    Implements IselectSingleNameRightLeft
    'Move selected items from the left to the right listbox
    Public Function MoveSelectedNameRight() Implements IselectSingleNameRightLeft.MoveSelectedNameRight
        Dim studentAttributes As New List(Of StudentNames)
        With StudentSelector.CheckedListBox1
            If .CheckedItems.Count > 0 Then
                For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                    StudentSelector.CheckedListBox2.Items.Add(.CheckedItems(checked))
                    .Items.Remove(.CheckedItems(checked))

                Next
            End If

        End With


        StudentSelector.CheckedListBox2.Sorted = True
        Return Nothing
    End Function


    'Move selected items from the left to the right listbox
    Public Function MoveSelectedNameLeft() Implements IselectSingleNameRightLeft.MoveSelectedNameLeft

        With StudentSelector.CheckedListBox2
            If .CheckedItems.Count > 0 Then
                For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                    StudentSelector.CheckedListBox1.Items.Add(.CheckedItems(checked))
                    .Items.Remove(.CheckedItems(checked))


                Next
            End If


        End With
        StudentSelector.CheckedListBox1.Sorted = True
        Return Nothing
    End Function
End Class

Class MoveAllNames
    Implements IMoveAllNameLeftRight

    Public Function MoveAllNamesRight() Implements IMoveAllNameLeftRight.MoveAllNamesRight
        StudentSelector.CheckedListBox2.Items.Clear()
        For x = 0 To StudentSelector.CheckedListBox1.Items.Count - 1
            If Not StudentSelector.CheckedListBox2.Items.Contains(StudentSelector.CheckedListBox1.Items(x)) Then
                StudentSelector.CheckedListBox2.Items.Add(StudentSelector.CheckedListBox1.Items(x))
            End If
        Next
        StudentSelector.CheckedListBox1.Items.Clear()
        StudentSelector.CheckedListBox2.Sorted = True
        Return Nothing
    End Function

    Public Function MoveAllNameLeft() Implements IMoveAllNameLeftRight.MoveAllNameLeft
        StudentSelector.CheckedListBox1.Items.Clear()
        For x = 0 To StudentSelector.CheckedListBox2.Items.Count - 1
            If Not StudentSelector.CheckedListBox1.Items.Contains(StudentSelector.CheckedListBox2.Items(x)) Then
                StudentSelector.CheckedListBox1.Items.Add(StudentSelector.CheckedListBox2.Items(x))
            End If
        Next
        StudentSelector.CheckedListBox2.Items.Clear()
        StudentSelector.CheckedListBox1.Sorted = True
        Return Nothing
    End Function
End Class

Class ExportStudents
    Public Shared Function ExportNames() As List(Of Names)
        Dim nameObject As New List(Of Names)
        With StudentSelector.CheckedListBox2
            Dim item As Integer = .Items.Count - 1
            For x = 0 To item
                nameObject.Add(New Names(.Items(x)))
            Next

        End With
        Return nameObject
    End Function

End Class





