Imports DAL
Imports BAL
Imports System.Linq
Imports System.Collections
Public Class TestingAssessments

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        populateFunctions()
    End Sub

    Public Sub PopulateFunctions()
        ComboBox2.Focus()
        ComboBox2.Items.Clear()
        ComboBox2.Text = String.Empty
        ComboBox2.Items.Add("")
        Dim index = ComboBox1.SelectedIndex

        Dim groupListings As List(Of AssessmentObject)

        groupListings = GroupSelector.GroupListing(index)

        Dim query = From p In groupListings
                    Select p

        For Each x In query

            ComboBox2.Items.Add(x.TestFunction)

        Next
        ComboBox2.SelectedIndex = 0
    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox2.Focus()
        ComboBox4.Items.Clear()
        Dim max As String = String.Empty
        Dim min As String = String.Empty

        Dim index = ComboBox1.SelectedIndex
        Dim selectedFunction As String = ComboBox1.SelectedItem
        ComboBox2.Focus()
        Dim testName As String = ComboBox2.SelectedItem
        Dim groupListings As List(Of AssessmentObject)

        groupListings = GroupSelector.TestingLabels(index)

        Dim query = From p In groupListings
        Where p.TestFunction.Trim() = testName.Trim
                    Select p


        Dim num As Integer = query.Count

        For Each x In query
            ComboBox4.Items.Add(x.TestName)

            max = x.TopScoreRange
            min = x.BottomScoreRange
            If max = "0" Or min = "0" Then
                ComboBox3.Visible = False
                Label5.Visible = False
                Label7.Visible = False
            Else
                Label5.Visible = True
                Label7.Visible = True
                ComboBox3.Visible = True
                ComboBox3.Focus()
                ComboBox3.Items.Clear()
            End If
        Next

        Dim z As Integer = 0
        For Each y In query
            max = y.TopScoreRange
            min = y.BottomScoreRange
            If min <> "0" Or max <> "0" Then

                Dim low As Integer = Convert.ToInt16(y.BottomScoreRange)
                Dim high As Integer = Convert.ToInt16(y.TopScoreRange)

                For z = low To high
                    ComboBox3.Items.Add(z)
                Next


            End If
        Next
        ComboBox3.Focus()
        ComboBox5.Focus()
        If ComboBox5.SelectedText = String.Empty Then
            Exit Sub
        End If
     

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Save()

    End Sub


    Public Sub Save()
        Dim convertName As INameConversion = New StudentNameConversion
        Dim dbcontext As New FamilyLiteracyEntityDataModel
        Dim assessments As New Assessment
        Dim studentName As String = String.Empty
        Dim group As String = String.Empty
        Dim functionType As String = String.Empty
        Dim testName As String = String.Empty
        Dim recordedDate As String = String.Empty
        Dim rawScore As String = String.Empty
        Dim totalItems As String = String.Empty
        Dim standardScore As String = String.Empty
        Dim studentNo As String = String.Empty
        Dim processingUser As String = Label10.Text
        If processingUser = String.Empty Then
            processingUser = "None"
        End If
        ComboBox5.Focus()
        studentName = ComboBox5.SelectedText.ToString
        studentNo = convertName.ConvertToId(studentName.Trim)

        ComboBox1.Focus()
        group = ComboBox1.SelectedItem
        ComboBox2.Focus()
        functionType = ComboBox2.SelectedItem
        ComboBox4.Focus()
        testName = ComboBox4.SelectedItem
        DateTimePicker1.Focus()
        recordedDate = DateTimePicker1.Value
        rawScore = TextBox2.Text

        standardScore = ComboBox3.Text
        If standardScore = String.Empty Then
            standardScore = 0
        End If
        If totalItems = String.Empty Then
            totalItems = "0"
        End If
        If studentNo <> "" Then
            assessments.Date = recordedDate.Trim
            assessments.StudentId = studentNo.Trim
            If group <> "" Then
                assessments.Group = group.Trim
                If functionType <> "" Then
                    assessments.Function = functionType.Trim
                    If testName <> "" Then
                        assessments.Test_Name = testName.Trim
                        If rawScore = String.Empty Then
                            assessments.Raw_Score = "99"
                        Else
                            assessments.Raw_Score = rawScore.Trim
                        End If


                        assessments.Standard_Score = standardScore.Trim
                        assessments.OperatorID = processingUser
                        dbcontext.Assessments.Add(assessments)
                        dbcontext.SaveChanges()
                        DisplayRecords()
                        MsgBox("New assessment record has been saved.")
                        TextBox2.Text = String.Empty
                    End If
                End If
                End If
            End If
    End Sub

    Private Sub TestingAssesments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label7.Text = "NOTE: If the standard score is less than" & vbCrLf + "some number (eg 55), choose the next" & vbCrLf & "lower number. (eg.54)"
        Startup()
    End Sub


    Public Sub Startup()
        Label10.Text = HomeDisplay.Label4.Text
        Dim names As IPopulateAllNames = New IPopulateNames

        Dim dsStudent As New DataSet
        dsStudent = names.DisplayStudents(True)
        Dim dtStudent As DataTable = dsStudent.Tables("StudentList")
        ComboBox5.DataSource = dtStudent
        ComboBox5.DisplayMember = "FullName"
        ComboBox5.ValueMember = "FullName"
        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        DisplayRecords()
    End Sub


    Public Sub DisplayRecords()
        Dim name As String = String.Empty
        Dim studentNo As String = String.Empty
        ComboBox5.Focus()
        name = ComboBox5.SelectedText
        Dim assessmentData As New List(Of AssessmentdataObject)
        Dim convertName As INameConversion = New StudentNameConversion
        Dim studentassessment As IassessmentData = New StudentAssessmentData
        studentNo = convertName.ConvertToId(name.Trim)
        assessmentData = studentassessment.StudentData(studentNo.Trim)
        Dim bs As New BindingSource
        bs.DataSource = assessmentData
        DataGridView1.DataSource = bs
        DataGridView1.Columns(1).Width = "150"
        DataGridView1.Columns(2).Width = "190"
        DataGridView1.Columns(3).Width = "220"
        DataGridView1.Columns(4).Width = "125"
        DataGridView1.Columns(5).Width = "75"
        DataGridView1.Columns(6).Width = "90"
        DataGridView1.Columns(7).Width = "65"
        DataGridView1.Columns(8).Width = "180"
        DataGridView1.Columns(9).Width = "2"
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If (e.ColumnIndex = DataGridView1.Columns(0).Index And e.RowIndex >= 0) Then


            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.Lime
            If MsgBox("Are you sure you would like to delete this record?", MsgBoxStyle.YesNo, "Delete Record") = vbYes Then

                RemovetestRecord()
            Else
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Public Sub RemovetestRecord()
        Dim index As String = String.Empty
        Dim DeleteRecord As IsaveNewCBMRecord = New SaveNewCBM
        Dim convertName As INameConversion = New StudentNameConversion
        index = DataGridView1.CurrentRow.Cells(9).Value
        Dim newindex As Integer = Convert.ToInt16(index)
        ComboBox5.Focus()
        Dim studentname As String = ComboBox5.SelectedText
        studentId = convertName.ConvertToId(studentname.Trim)
        DeleteAssesmentRecord.RemoveTestRecord(studentId.Trim, newindex)
        DisplayRecords()
        MsgBox("Record has been removed.")

    End Sub



    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ComboBox5.Focus()
        If ComboBox5.SelectedText = String.Empty Then
            MessageBox.Show("You must select a student!")
        Else
            CodeKnowledgeBlendingSegemting.Show()
        End If

    End Sub


End Class