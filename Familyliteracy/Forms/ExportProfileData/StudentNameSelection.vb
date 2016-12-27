Imports DAL
Imports BAL
Namespace ExportProfileData
    Public Class NameFilter
        Public Shared Function Filter(ByVal filterkey As String) As List(Of StudentNames)
            Dim nameList As List(Of StudentNames) = New List(Of StudentNames)

            Dim getnames As IPopulateSelectedNames = Nothing
            Select Case filterkey
                Case "all"

                    getnames = New SelectAllNames
                    nameList = getnames.PopulateLeft(False)

                Case "active"
                    getnames = New SelectActiveNames
                    nameList = getnames.PopulateLeft(True)
                Case ("inactive")
                    getnames = New SelectInActiveNames
                    nameList = getnames.PopulateLeft(False)
            End Select
            Return nameList
        End Function
    End Class
    Public Interface IPopulateSelectedNames
        Function PopulateLeft(ByVal activeStudents As Boolean)
        Function PopulateRight()
    End Interface


    Class SelectActiveNames
        Implements IPopulateSelectedNames
        Private Function PopulateLeft(ByVal activeStudents As Boolean) Implements IPopulateSelectedNames.PopulateLeft
            Dim nameList As List(Of StudentNames) = New List(Of StudentNames)
            nameList = NameListing.ListActiveNames
            MoveAllNameLeft()
            For Each Names In nameList

                ExportProfileSelector.CheckedListBox1.Items.Add(Names.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox1.Sorted = True
            Return Nothing

        End Function


        Private Function PopulateRight() Implements IPopulateSelectedNames.PopulateRight
            Dim studentAttributes As List(Of StudentNames)


            studentAttributes = NameListing.ListActiveNames
            MoveAllNameLeft()
            Dim students = From p In studentAttributes
                          Select p

            For Each attribute In students

                ExportProfileSelector.CheckedListBox2.Items.Add(attribute.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox2.Sorted = True
            Return Nothing
        End Function
        Function MoveAllNameLeft()
            With ExportProfileSelector.CheckedListBox2
                ExportProfileSelector.CheckedListBox1.Items.Clear()
                Dim item As Integer = .Items.Count - 1
                .Items.Clear()
            End With

            Return Nothing
        End Function

    End Class


    Class SelectInActiveNames
        Implements IPopulateSelectedNames
        Private Function PopulateLeft(ByVal activeStudents As Boolean) Implements IPopulateSelectedNames.PopulateLeft
            Dim nameList As List(Of StudentNames) = New List(Of StudentNames)
            nameList = NameListing.ListNonActiveNames
            MoveAllNameLeft()
            For Each Names In nameList

                ExportProfileSelector.CheckedListBox1.Items.Add(Names.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox1.Sorted = True
            Return Nothing

        End Function


        Private Function PopulateRight() Implements IPopulateSelectedNames.PopulateRight
            Dim studentAttributes As List(Of StudentNames)


            studentAttributes = NameListing.ListNonActiveNames
            MoveAllNameLeft()
            Dim students = From p In studentAttributes
                          Select p

            For Each attribute In students

                ExportProfileSelector.CheckedListBox2.Items.Add(attribute.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox2.Sorted = True
            Return Nothing
        End Function
        Function MoveAllNameLeft()
            With ExportProfileSelector.CheckedListBox2
                ExportProfileSelector.CheckedListBox1.Items.Clear()
                Dim item As Integer = .Items.Count - 1


                .Items.Clear()
            End With

            Return Nothing
        End Function
    End Class



    Class SelectAllNames
        Implements IPopulateSelectedNames

        Private Function PopulateLeft(ByVal activeStudents As Boolean) Implements IPopulateSelectedNames.PopulateLeft
            Dim nameList As List(Of StudentNames) = New List(Of StudentNames)
            nameList = NameListing.ListAllNames()
            MoveAllNameLeft()
            For Each Names In nameList

                ExportProfileSelector.CheckedListBox1.Items.Add(Names.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox1.Sorted = True
            Return Nothing

        End Function


        Private Function PopulateRight() Implements IPopulateSelectedNames.PopulateRight
            Dim studentAttributes As List(Of StudentNames)


            studentAttributes = NameListing.ListAllNames()
            MoveAllNameLeft()
            Dim students = From p In studentAttributes
                          Select p

            For Each attribute In students

                ExportProfileSelector.CheckedListBox2.Items.Add(attribute.FullName.Trim())
            Next
            ExportProfileSelector.CheckedListBox2.Sorted = True
            Return Nothing
        End Function

        Function MoveAllNameLeft()
            With ExportProfileSelector.CheckedListBox2
                ExportProfileSelector.CheckedListBox1.Items.Clear()
                Dim item As Integer = .Items.Count - 1


                .Items.Clear()
            End With

            Return Nothing
        End Function
    End Class
    Class CertainNameSelection

        Implements IPopulateSelectedNames
        'Move selected items from the left to the right listbox
        Private Function PopulateRight() Implements IPopulateSelectedNames.PopulateRight
            Dim studentAttributes As New List(Of StudentNames)
            With ExportProfileSelector.CheckedListBox1
                If .CheckedItems.Count > 0 Then
                    For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                        ExportProfileSelector.CheckedListBox2.Items.Add(.CheckedItems(checked))
                        .Items.Remove(.CheckedItems(checked))

                    Next
                End If

            End With


            ExportProfileSelector.CheckedListBox2.Sorted = True
            Return Nothing
        End Function
        'Move selected items from the left to the right listbox
        Private Function PopulateLeft(ByVal activeStudentd As Boolean) Implements IPopulateSelectedNames.PopulateLeft

            With ExportProfileSelector.CheckedListBox2
                If .CheckedItems.Count > 0 Then
                    For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                        ExportProfileSelector.CheckedListBox1.Items.Add(.CheckedItems(checked))
                        .Items.Remove(.CheckedItems(checked))
                    Next
                End If


            End With
            ExportProfileSelector.CheckedListBox1.Sorted = True
            Return Nothing
        End Function

    End Class
End Namespace