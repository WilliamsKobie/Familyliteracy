Imports BAL
Imports DAL
Imports System.Globalization
Imports System.Linq
Imports log4net
Imports log4net.Config

Public Class RepeatedTesting
    Public Shared logger As log4net.ILog
    Private Sub ProcessCBM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Startup()
    End Sub

    Public Sub Startup()
        Try
            Dim todaysdate = Now
            Dim names As IPopulateAllNames = New IPopulateNames

            Dim dsStudent As New DataSet
            dsStudent = names.DisplayStudents(False)
            Dim dtStudent As DataTable = dsStudent.Tables("StudentList")
            ComboBox1.DataSource = dtStudent
            ComboBox1.DisplayMember = "FullName"
            ComboBox1.ValueMember = "FullName"
            ComboBox1.SelectedIndex = 0
            DateTimePicker1.Value = todaysdate


            DisplayCBMData()

            DataGridView1.Columns(1).Width = "180"
            DataGridView1.Columns(2).Width = "80"
            DataGridView1.Columns(3).Width = "80"
            DataGridView1.Columns(4).Width = "50"
            DataGridView1.Columns(5).Width = "50"
            DataGridView1.Columns(6).Width = "120"
            DataGridView1.Columns(7).Width = "90"
            DataGridView1.Columns(8).Width = "90"
            DataGridView1.Columns(9).Width = "5"
            ComboBox4.SelectedIndex = 0
            Label4.Text = "Forms"
            Label3.Text = "Levels"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    'Populate Combobox 3 with all the levels associated with Lists 
    Public Sub ListLevels(ByVal selectedSource As String, ByVal sourcetype As Integer)
        Dim getLevels As Itext = New Forms_And_Passages
        Dim populateListLevels As New List(Of StoredListing)
        Dim populateTextLevels As New List(Of StoredText)

        Select Case (sourcetype)
            Case 0
                populateListLevels = getLevels.ReturnForms
                Dim lvl As String = String.Empty

                Dim sample = From cust In populateListLevels
                             Where cust.Source = selectedSource.Trim
                             Order By cust.Index
                                   Select cust

                For Each samp In sample
                    lvl = samp.SourceLevels
                    ComboBox3.Items.Add(lvl)
                Next

            Case 1

                populateTextLevels = getLevels.ReturnPassages
                Dim lvl As String = String.Empty

                Dim sample = From cust In populateTextLevels
                             Where cust.Source = selectedSource.Trim
                             Order By cust.Index
                                   Select cust

                For Each samp In sample
                    lvl = samp.GradeLevel
                    ComboBox3.Items.Add(lvl)
                Next

        End Select

        ComboBox3.Focus()




    End Sub




    Public Sub PopulateSources()
        Dim selectedCatagory As Integer
        Dim sourceType As Integer
        selectedCatagory = ComboBox4.SelectedIndex
        sourceType = ComboBox5.SelectedIndex
        Dim listSources As List(Of StoredSources)
        Dim returnSources As Isources = New SourceListing
        listSources = returnSources.FindSources()
        Select Case (selectedCatagory)

            Case 0

                Label3.Text = "Levels"
                Label4.Text = "Forms"

                Dim querySource = From source In listSources
                Where source.SourceCatagory = "List"
                            Select source

                For Each newsource In querySource

                    ComboBox5.Items.Add(newsource.Source)
                Next

            Case 1
                Label3.Text = "Grade"
                Label4.Text = "Passages"
                listSources = returnSources.FindSources
                Dim querySource = From source In listSources
                                 Where source.SourceCatagory = "Text"
                                Select source
                For Each newSource In querySource
                    ComboBox5.Items.Add(newSource.Source)

                Next

            Case Else


        End Select
    End Sub



    Private Sub ComboBox4_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged

        ComboBox5.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Text = String.Empty
        ComboBox2.Text = String.Empty
        PopulateSources()


    End Sub



    Public Sub PopulateText(ByVal selectedLevel As String, ByVal readingType As Integer, readingSource As String)
        Dim getLevels As Itext = New Forms_And_Passages

        Dim populateListLevels As New List(Of StoredListing)
        Dim populateTextLevels As New List(Of StoredText)

        Dim maxlvl As Integer = 0
        Dim minlvl As Integer = 0

        Select Case (readingType)
            Case 0
                Label4.Text = "Forms"

                populateListLevels = getLevels.ReturnForms

                Dim lvl As Integer = 0
                Dim sample = From cust In populateListLevels
                                     Where cust.Source = readingSource.Trim And cust.SourceLevels = selectedLevel.Trim
                                     Order By cust.Index
                                           Select cust

                For Each samp In sample
                    minlvl = samp.MinimumFormListing
                    maxlvl = samp.MaximumFormListing

                Next


            Case 1

                Label4.Text = "Passages"
                populateTextLevels = getLevels.ReturnPassages


                Dim sample = From cust In populateTextLevels
                                     Where cust.Source = readingSource.Trim And cust.GradeLevel = selectedLevel.Trim
                                        Order By cust.Index
                                           Select cust

                For Each samp In sample
                    minlvl = Convert.ToInt16(samp.BeginningPassage)
                    maxlvl = Convert.ToInt16(samp.FinalPassage)

                Next


        End Select

        Dim x As Integer = 0
        For x = minlvl To maxlvl
            ComboBox2.Items.Add(x)
        Next
        ComboBox2.SelectedIndex = 0

    End Sub





    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim source As String = String.Empty
        Dim sourceCatagory As Integer = 0
        ComboBox5.Focus()
        source = ComboBox5.SelectedItem
        sourceCatagory = ComboBox4.SelectedIndex
        ComboBox3.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Text = String.Empty
        ComboBox2.Text = String.Empty


        ListLevels(source, sourceCatagory)



    End Sub

    Private Sub ComboBox3_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim selectedLevel As String = String.Empty
        Dim readingType As Integer = 0
        Dim reading As Integer = 0
        Dim readingSource As String = String.Empty

        ComboBox4.Focus()
        readingType = Me.ComboBox4.SelectedIndex
        Me.ComboBox3.Focus()
        selectedLevel = Me.ComboBox3.SelectedText.ToString
        readingSource = Me.ComboBox5.SelectedItem
        ComboBox2.Items.Clear()

        If selectedLevel <> "DAL.StoredCBMText" And selectedLevel <> String.Empty Then

            PopulateText(selectedLevel, readingType, readingSource)

        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim convertstudentname As INameConversion = New StudentNameConversion
        Dim parseApostrophe As New nameOperation
        Dim studentFullName As String = String.Empty
        Dim gradeLevel As String = String.Empty
        Dim passages As String = String.Empty
        Dim text As String = String.Empty
        Dim textType As String = String.Empty
        Dim wordTotal As Integer = 0
        Dim correctWordPerMinute As Double = 0.0
        Dim timer As String = String.Empty
        Dim numberOfErrors As Integer = 0
        Dim recordDate As DateTime = Nothing
        Dim testMethod As String = String.Empty
        Dim cwpm As Integer = 0
        ComboBox1.Focus()
        studentFullName = ComboBox1.SelectedText
        If studentFullName = String.Empty Then
            MsgBox("You must provide a student name!")
            Exit Sub
        End If
        Dim currentlabel1 As String = Label3.Text
        Dim currentlabel2 As String = Label4.Text
        ComboBox3.Focus()
        gradeLevel = ComboBox3.SelectedText
        ComboBox2.Focus()
        passages = ComboBox2.SelectedText
        If gradeLevel = String.Empty Then
            If currentlabel1.Trim() = "Levels" Then
                MsgBox("You must specifiy a List Level!")

            ElseIf currentlabel1.Trim() = "Grade" Then
                MsgBox("You must specifiy a Grade Level!")
            End If
            Exit Sub
        End If
        If passages = String.Empty Then
            If currentlabel2.Trim() = "Passages" Then
                MsgBox("You must specifiy a Passage!")

            ElseIf currentlabel2.Trim() = "Forms" Then
                MsgBox("You must specifiy a Form!")
            End If
            Exit Sub
        End If
        ComboBox5.Focus()

        text = ComboBox5.SelectedItem
        recordDate = DateTimePicker1.Value
        ComboBox4.Focus()
        testMethod = ComboBox4.SelectedItem
        timer = MaskedTextBox1.Text.ToString()

        Dim catchtimervalue() As String
        Dim part1 As String = String.Empty
        Dim part2 As String = String.Empty
        catchtimervalue = timer.Split(":")

        part1 = catchtimervalue(0).Trim
        part2 = catchtimervalue(1).Trim

        If part1 = String.Empty Or part2 = String.Empty Then
            MsgBox("Minimum value entered for the time stamp must be one minute!")

            Exit Sub

        ElseIf part2 = "60" Then
            timer = "1:00"

        ElseIf Convert.ToInt16(part2) < 60 And Convert.ToInt16(part1) < 1 Then
            MsgBox("Message must be equal to or greater than 1 minute!")
            Exit Sub
        End If
        Dim perminute As Double = TimeSpan.Parse("00:" & timer).TotalMinutes
        numberOfErrors = Convert.ToInt32(MaskedTextBox2.Text)
        wordTotal = Convert.ToInt32(MaskedTextBox4.Text)
        correctWordPerMinute = (wordTotal - numberOfErrors)
        correctWordPerMinute = correctWordPerMinute / perminute
        cwpm = Convert.ToInt16(correctWordPerMinute)
        TextBox1.Text = cwpm.ToString


        studentId = convertstudentname.ConvertToId(studentFullName.Trim)


        Dim SaveMeasurement As IsaveNewCBMRecord = New SaveNewCBM

        SaveMeasurement.Save(studentId.Trim, recordDate, cwpm, numberOfErrors, timer.ToString, wordTotal, testMethod, text, gradeLevel, passages)
        MsgBox(studentFullName & " testing Measurment has been saved.")
        DisplayCBMData()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        DisplayCBMData()

    End Sub

    Public Sub DisplayCBMData()
        Dim ConvertStudentName As INameConversion = New StudentNameConversion
        Dim ParseApostrophe As New nameOperation
        Dim GetCBMData As IReturnStudentCBMInfo = New StudentCBMInfo
        Dim CBMTestData As New List(Of DisplayCBMData)
        Dim studentNo As String = String.Empty


        ComboBox1.Focus()
        studentFullName = ComboBox1.SelectedText

        studentNo = ConvertStudentName.ConvertToId(studentFullName.Trim)

        CBMTestData = GetCBMData.StudentTestData(studentNo)
        Dim bs As New BindingSource
        bs.DataSource = CBMTestData
        DataGridView1.DataSource = bs
        MaskedTextBox1.Text = "01:00"
        MaskedTextBox2.Text = "0"
        MaskedTextBox4.Text = "0"
        TextBox1.Text = String.Empty
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If (e.ColumnIndex = DataGridView1.Columns(0).Index And e.RowIndex >= 0) Then
            RemoveTestRecord()
        End If
    End Sub

    Public Sub RemoveTestRecord()
        Dim index As String = String.Empty
        Dim DeleteRecord As IsaveNewCBMRecord = New SaveNewCBM
        Dim currentOperator As String = HomeDisplay.Label4.Text
        index = DataGridView1.CurrentRow.Cells(9).Value
        Dim cwpm As String = DataGridView1.CurrentRow.Cells(2).Value
        Dim testDate As String = DataGridView1.CurrentRow.Cells(1).Value
        Dim errors As String = DataGridView1.CurrentRow.Cells(4).Value
        Dim totaltime As String = DataGridView1.CurrentRow.Cells(5).Value
        Dim numberOfWords As String = DataGridView1.CurrentRow.Cells(3).Value
        'Log deleted record


        ComboBox1.Focus()
        Dim student As String = ComboBox1.SelectedText

        log4net.Config.XmlConfigurator.Configure()
        logger = log4net.LogManager.GetLogger("Familyliteracy")
        logger.Info("------------------------------------------------------------------------------------------------------")

        logger.Info("Deleted Test Record")
        logger.Debug("Operator: " + currentOperator)
        logger.Debug("Student Name: " + student)
        logger.Debug("Testing Date: " + testDate)
        logger.Debug("Correct Words Per Minute: " + cwpm)
        logger.Debug("Total Words: " + numberOfWords)
        logger.Debug("Total Time: " + totaltime)
        logger.Debug("Errors: " + errors)
        logger.Info("------------------------------------------------------------------------------------------------------")
        DeleteRecord.Delete(index.Trim)
        MsgBox("Record has been deleted.")
        DisplayCBMData()
    End Sub






    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        ' Export_Test_Data.Show()
        'Export_Test_Data.Focus()
    End Sub
End Class