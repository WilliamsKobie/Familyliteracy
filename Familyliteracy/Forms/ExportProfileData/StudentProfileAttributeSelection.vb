Namespace ExportProfileData
    Public Interface IPopulateStudentProfileAttributes
        Function PopulateRight()
        Function PopulateLeft()
    End Interface

    Class SelectedAttributes
        Implements IPopulateStudentProfileAttributes
        Private Function PopulateRight() Implements IPopulateStudentProfileAttributes.PopulateRight


            With ExportProfileSelector.CheckedListBox3
                If .CheckedItems.Count > 0 Then

                    For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                        ExportProfileSelector.CheckedListBox4.Items.Add(.CheckedItems(checked))
                        .Items.Remove(.CheckedItems(checked))

                    Next
                End If
            End With
            ExportProfileSelector.CheckedListBox3.Sorted = True
            Return Nothing

        End Function

        Private Function PopulateLeft() Implements IPopulateStudentProfileAttributes.PopulateLeft


            With ExportProfileSelector.CheckedListBox4
                If .CheckedItems.Count > 0 Then

                    For checked As Integer = .CheckedItems.Count - 1 To 0 Step -1
                        ExportProfileSelector.CheckedListBox3.Items.Add(.CheckedItems(checked))
                        .Items.Remove(.CheckedItems(checked))
                    Next
                End If
            End With
            ExportProfileSelector.CheckedListBox3.Sorted = True
            Return Nothing

        End Function

        Public Shared Function DefaultListing() As List(Of String)


            Dim defaultattributelist = New List(Of String)
            defaultattributelist.Add("Active")
            defaultattributelist.Add("First_Name")
            defaultattributelist.Add("Last_Name")
            defaultattributelist.Add("Full_Name")

            defaultattributelist.Add("Hours_Cleared")
            defaultattributelist.Add("Date_of_Birth")
            defaultattributelist.Add("Gender")
            defaultattributelist.Add("District")
            defaultattributelist.Add("School_Attending")
            defaultattributelist.Add("Initial_Inquiry")
            defaultattributelist.Add("Assessment")

            defaultattributelist.Add("Report_Discussion")
            defaultattributelist.Add("Tutoring_Start")
            defaultattributelist.Add("Tutoring_Stop")
            defaultattributelist.Add("Address")

            defaultattributelist.Add("City")
            defaultattributelist.Add("State")
            defaultattributelist.Add("Zip_Code")
            defaultattributelist.Add("Guardian_Name")
            defaultattributelist.Add("Guardian_FirstName")
            defaultattributelist.Add("Guardian_LastName")
            defaultattributelist.Add("Cell_Phone")
            defaultattributelist.Add("Home_Phone")
            defaultattributelist.Add("Work_Phone")
            defaultattributelist.Add("Fax")
            defaultattributelist.Add("Email")
            defaultattributelist.Add("Alternate_Email")
            Return defaultattributelist
        End Function
    End Class


    Class SelectAllStudentAttributes
        Implements IPopulateStudentProfileAttributes
        'Move selected items from the left to the right listbox
        Private Function PopulateRight() Implements IPopulateStudentProfileAttributes.PopulateRight

            Dim item As Object
            With ExportProfileSelector.CheckedListBox3
                If .Items.Count > 0 Then

                    For Each item In .Items

                        ExportProfileSelector.CheckedListBox4.Items.Add(item)


                    Next
                End If

            End With
            ClearDefaultBox()

            ExportProfileSelector.CheckedListBox4.Sorted = True
            Return Nothing
        End Function
        'Move selected items from the left to the right listbox
        Private Function PopulateLeft() Implements IPopulateStudentProfileAttributes.PopulateLeft

            With ExportProfileSelector.CheckedListBox4
                If .Items.Count > 0 Then
                    For Each item In .Items

                        ExportProfileSelector.CheckedListBox3.Items.Add(item)


                    Next
                End If


            End With
            RemoveAllItemsRightBox()
            ExportProfileSelector.CheckedListBox3.Sorted = True
            Return Nothing
        End Function

        Function ClearDefaultBox()
            With ExportProfileSelector.CheckedListBox3
                ExportProfileSelector.CheckedListBox3.Items.Clear()
                Dim item As Integer = .Items.Count - 1


                .Items.Clear()
            End With

            Return Nothing
        End Function

        Function RemoveAllItemsRightBox()
            With ExportProfileSelector.CheckedListBox4
                ExportProfileSelector.CheckedListBox4.Items.Clear()
                Dim item As Integer = .Items.Count - 1


                .Items.Clear()
            End With

            Return Nothing
        End Function
    End Class
End Namespace

