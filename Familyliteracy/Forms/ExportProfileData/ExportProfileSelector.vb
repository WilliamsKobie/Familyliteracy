Imports BAL
Imports DAL
Imports Familyliteracy.ExportProfileData
Public Class ExportProfileSelector

    Private SelectAllNames As IPopulateSelectedNames = New SelectAllNames
    Private SelectActiveNames As IPopulateSelectedNames = New SelectActiveNames
    Private SelectInactiveNames As IPopulateSelectedNames = New SelectInActiveNames
    Private SelectName As IPopulateSelectedNames = New CertainNameSelection
    Private SelectAllAttributes As IPopulateStudentProfileAttributes = New SelectAllStudentAttributes
    Private Selectedattribute As IPopulateStudentProfileAttributes = New SelectedAttributes

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        SelectName.PopulateRight()

       
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        SelectName.PopulateLeft(False)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            SelectAllNames.PopulateRight()
        ElseIf RadioButton2.Checked = True Then
            SelectActiveNames.PopulateRight()
        ElseIf RadioButton3.Checked = True Then
            SelectInactiveNames.PopulateRight()
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If RadioButton1.Checked = True Then
            SelectAllNames.PopulateLeft(RadioButton1.Checked)
        ElseIf RadioButton2.Checked = True Then
            SelectActiveNames.PopulateLeft(RadioButton2.Checked)
        ElseIf RadioButton3.Checked = True Then
            SelectInactiveNames.PopulateLeft(RadioButton3.Checked)
        End If
    End Sub

    Private Sub ExportProfileSelector_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RadioButton2.Checked = True
        SelectActiveNames.PopulateLeft(True)
      
        Dim att As New List(Of String)
        att = SelectedAttributes.DefaultListing()
        With CheckedListBox3


            For Each item In att
                .Items.Add(item.Trim())

            Next

        End With
        CheckedListBox3.Sorted = True
    End Sub




    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        SelectAllAttributes.PopulateRight()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        SelectAllAttributes.PopulateLeft()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim studentconv As INameConversion = New StudentNameConversion
        Dim studentno = String.Empty
        Dim selectedattributes = New List(Of Attributes)()
        Dim studentcollection As List(Of String) = New List(Of String)
        With CheckedListBox2
            If .Items.Count > 0 Then
                For index As Integer = 0 To .Items.Count - 1
                    Dim studentname As String = .Items(index)
                    studentno = studentconv.ConvertToId(studentname)
                    If studentno <> String.Empty Then
                        studentcollection.Add(studentno.Trim())
                    End If
                Next
            End If
            selectedattributes = AttributeListing.GenerateList(studentcollection, "all")
        End With
        ExportStudentProfile.Show()
        ExportStudentProfile.DataGridView1.DataSource = selectedattributes


        With CheckedListBox3
            If .Items.Count > 0 And CheckedListBox2.Items.Count > 0 Then
                For index As Integer = 0 To .Items.Count - 1
                    Dim att As String = .Items(index)
                    ExportStudentProfile.DataGridView1.Columns.Remove(att)


                Next
            End If
           
        End With
        ExportStudentProfile.Focus()

    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Selectedattribute.PopulateRight()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Selectedattribute.PopulateLeft()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged


      
        If RadioButton1.Checked = True Then
            NameFilter.Filter("all")

            Exit Sub
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
       
        If RadioButton2.Checked = True Then
            NameFilter.Filter("active")


            Exit Sub
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
       


        If RadioButton3.Checked = True Then
            NameFilter.Filter("inactive")
        End If
    End Sub
End Class