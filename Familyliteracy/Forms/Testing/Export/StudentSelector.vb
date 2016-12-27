Imports DAL
Imports BAL
Imports System.Linq
Imports System.Collections
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class StudentSelector

    Dim selectallnames As IResetNames
    Dim selectName As IselectSingleNameRightLeft = New MoveSelectedNames
    Dim shiftAllnames As IMoveAllNameLeftRight = New MoveAllNames
    Private Sub StudentSelector_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim _activeStudents As String = String.Empty

        If CheckBox1.Checked = True Then
            _activeStudents = "active"
        ElseIf CheckBox1.Checked = False Then
            _activeStudents = "inactive"
        Else
            _activeStudents = "all"
        End If
        Dim ResetNames As IResetNames = New DefaultScreen
        ResetNames.ResetLeftNames(_activeStudents)
        RadioButton1.Checked = True

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        selectName.MoveSelectedNameRight()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'clear the entire DatagridView by removing all row and columns
        ClearData()
        CheckedListBox2.SelectedIndex = -1
        selectName.MoveSelectedNameLeft()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim _activeStudents As Boolean = CheckBox1.Checked
        shiftAllnames.MoveAllNamesRight()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        ClearData()
        Dim _activeStudents As Boolean = CheckBox1.Checked
        shiftAllnames.MoveAllNameLeft()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim nameObject As New List(Of Names)
        Dim getstudentNo As INameConversion = New StudentNameConversion
        Export_CodeKnowledgeBlendingSegmenting.Show()
        Export_CodeKnowledgeBlendingSegmenting.Focus()
        Dim exportedDataObject As New List(Of ExportTestingObject)
        nameObject = ExportStudents.ExportNames()
        Dim fullName As String = String.Empty
        Dim studentNo As String = String.Empty
        Dim startDate As String = String.Empty
        Dim endDate As String = String.Empty
        If RadioButton1.Checked = True Then
            For Each item In nameObject
                fullName = item.Fullname
                studentNo = getstudentNo.ConvertToId(fullName)
                Dim firstRecords As IFirstAndLastTwo = New ExportFirstTestRecord
                Dim lastRecords As IFirstAndLastTwo = New ExportLastTwoRecords
                exportedDataObject = firstRecords.Record(studentNo.Trim(), fullName.Trim(), exportedDataObject)
                exportedDataObject = lastRecords.Record(studentNo.Trim(), fullName.Trim(), exportedDataObject)
            Next
        ElseIf RadioButton2.Checked = True Then

            For Each item In nameObject
                fullName = item.Fullname
                studentNo = getstudentNo.ConvertToId(fullName)

                exportedDataObject = TestDataByRecord.ExportAll(studentNo.Trim(), fullName.Trim(), exportedDataObject)
            Next
        ElseIf RadioButton3.Checked = True Then

            startDate = DateTimePicker1.Value
            endDate = DateTimePicker2.Value
            Dim date1 As DateTime = DateTime.Parse(startDate)
            Dim date2 As DateTime = DateTime.Parse(endDate)
            startDate = date1.ToString("M/dd/yyyy")
            endDate = date2.ToString("M/dd/yyyy")

            endDate = DateTimePicker2.Value
            For Each item In nameObject
                fullName = item.Fullname
                studentNo = getstudentNo.ConvertToId(fullName)

                exportedDataObject = TestData.ExportByDateRange(studentNo.Trim(), fullName.Trim(), startDate, endDate, exportedDataObject)
            Next
        End If
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.DataSource = exportedDataObject
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(0).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(1).Width = 170
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(2).Width = 122
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(3).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(4).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(5).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(6).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(7).Width = 40

        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(8).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(9).Width = 41
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(10).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(11).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(12).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(13).Width = 41
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(14).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(15).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(16).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(17).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(18).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(19).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(20).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(21).Width = 40
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(22).Width = 41
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(23).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(24).Width = 70
        Export_CodeKnowledgeBlendingSegmenting.DataGridView1.Columns(25).Width = 70


    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Hide()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        GroupBox3.Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        GroupBox3.Enabled = False

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        GroupBox3.Enabled = True
    End Sub

    Public Function ClearData()
        'clear the entire DatagridView by removing all row and columns
        If DataGridView1.Rows.Count > 0 Then
            Dim totalrows As Integer = DataGridView1.RowCount - 1
            For b = totalrows To 0 Step -1
                DataGridView1.Rows.RemoveAt(b)
            Next

        End If
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()
        Return Nothing
    End Function

    Public Function VerticalDataDisplay(ByVal fullname)
        LoadingValues.Show()
        Timer1.Enabled = True
        Timer1.Start()
        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim nameObject As New List(Of Names)
        Dim getstudentNo As INameConversion = New StudentNameConversion

        Dim testvalues As New List(Of ExportDateHeader)
        Dim values As New List(Of ExportDateHeader)

        Dim studentNo As String = String.Empty
        Dim startDate As String = String.Empty
        Dim endDate As String = String.Empty
        Dim tests() As String = {"Language", "Spelling", "Memory", "Word Reading", "Text Reading", "Rapid Naming"}


        ClearData()
        'Create the first two columns 'Student name' and 'the test method'
        DataGridView1.Columns.Add("Column1", "Student")
        DataGridView1.Columns.Add("Column2", "Test Method")
        DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(1).Width = 200


        studentNo = getstudentNo.ConvertToId(fullname)

        If studentNo <> String.Empty Then
            'Capture all the student values
            testvalues = TestData_DateHeader.GetValues(studentNo.Trim(), fullname.Trim(), testvalues)
            Dim displaylist = From p In testvalues
                              Order By p.Index Ascending
                              Select p



            Dim dateValues As New List(Of DateCollection)

            Dim newvalues = From p In displaylist
                            Select p
            'Collect/Filter all the dates(1st,2nd,3rd recorded)
            For Each items In testvalues
                dateValues.Add(New DateCollection(items.First_RecordingDate))
                dateValues.Add(New DateCollection(items.Second_RecordingDate))
                dateValues.Add(New DateCollection(items.Third_RecordingDate))
            Next

            'Eliminate all duplicate dates and filter any empty date values. Empty date value ='1/1/1900'
            Dim headerdatelisting = (From p In dateValues
                                    Where p.DateValue <> "1/1/1900"
                                    Order By p.DateValue Ascending
                        Group p By p.DateValue Into Group
                        Select DateValue, Group)

            'Populate columns with the date as headers

            Dim y As Int16 = 3

            Dim d As Integer = 0
            Do While (d < 2)
                Dim dgvRow As New DataGridViewRow
                DataGridView1.Rows.Add(dgvRow)
                d = d + 1
            Loop
            Dim maximumcolumns As Integer = 0
            For Each dateCollection In headerdatelisting.ToList()

                Dim columnName As String = "Column" + y.ToString()
                DataGridView1.Columns.Add(columnName, "")

                maximumcolumns = maximumcolumns + 1

            Next
            'Place the student's full name into the first row
            Dim getReadingLevel As IstudentProfileAttributes = New ReadingLevel
            Dim convertStudentName As INameConversion = New StudentNameConversion
            DataGridView1.Rows(0).Cells(0).Value = fullname


            Dim x As Int16 = 0
            'Place all filtered date columns onto the Grid
            '1) Create column
            '2) Apply date value
            '3) Locate test method and place each test score into its respective row and column cell location
            For Each element In displaylist

                Dim dgvRow As New DataGridViewRow

                DataGridView1.Rows(x).Cells(1).Value = element.Measure
                Dim testtype = element.Measure
                x = x + 1

                DataGridView1.Rows.Add(dgvRow)
                DataGridView1.Rows(x).Cells(0).Value = String.Empty
                Dim col As Integer = 2

                For Each dateCollection In headerdatelisting.ToList()
                    Dim score1 As String = element.First_Date
                    Dim score2 As String = element.Second_From_Last_Date
                    Dim score3 As String = element.Last_Date

                    DataGridView1.Rows(1).Cells(col).Value = dateCollection.DateValue.ToString("M/d/yyyy")
                    If DataGridView1.Rows(1).Cells(col).Value = element.First_RecordingDate.ToString("M/d/yyyy") Then
                        DataGridView1.Rows(x - 1).Cells(col).Value = score1

                    ElseIf DataGridView1.Rows(1).Cells(col).Value = element.Second_RecordingDate.ToString("M/d/yyyy") Then

                        DataGridView1.Rows(x - 1).Cells(col).Value = score2
                    ElseIf DataGridView1.Rows(1).Cells(col).Value = element.Third_RecordingDate.ToString("M/d/yyyy") Then
                        DataGridView1.Rows(x - 1).Cells(col).Value = score3
                    Else

                    End If
                    If x > 1 Then

                        Dim testlabel = (From p In tests
                                        Where p = testtype
                                        Select p).FirstOrDefault

                        If testlabel = Nothing Then
                            If DataGridView1.Rows(x - 1).Cells(col).Value = Nothing Then
                                DataGridView1.Rows(x - 1).Cells(col).Value = "x"
                            End If
                        Else
                            DataGridView1.Rows(x - 1).Cells(col).Value = String.Empty
                            DataGridView1.Rows(x - 1).Cells(col).Style.BackColor = Color.Red
                            DataGridView1.Rows(x - 1).Cells(1).Style.BackColor = Color.Red


                        End If
                    End If
                    col = col + 1


                Next

            Next


            DataGridView1.Rows(1).Cells(0).Value = String.Empty
            DataGridView1.Rows(1).Cells(1).Value = String.Empty
            Dim columnnumber As Integer = DataGridView1.Columns.Count - 1
            For x = 1 To columnnumber

                DataGridView1.Rows(0).Cells(x).Value = String.Empty
                DataGridView1.Rows(1).Cells(x).Style.BackColor = Color.Gray
                DataGridView1.Rows(1).Cells(x).Style.ForeColor = Color.White

            Next
            StudentReadingLevel = getReadingLevel.level(studentNo.Trim())

            DataGridView1.Rows(1).Cells(0).Value = "Reading Level: " & StudentReadingLevel
        End If
        Timer1.Stop()
        Timer1.Enabled = False
        LoadingValues.Close()
        Return Nothing
    End Function
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        CreateExcelSheet()

    End Sub
    Public Sub CreateExcelSheet()
        Try

            Dim app As New Microsoft.Office.Interop.Excel.Application

            REM creating new WorkBook within Excel application

            Dim name1 As String

            Dim workbook As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Add(Type.Missing)

            REM creating new Excelsheet in workbook
            If CheckedListBox2.Items.Count > 0 Then
                For x = 0 To CheckedListBox2.Items.Count - 1

                    name1 = CheckedListBox2.Items(x)
                    VerticalDataDisplay(name1)

                    sheetindex = x

                  

                    REM get the reference of first sheet. By default its name is Sheet1.
                    Dim Worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                    REM store its reference to worksheet

                    Dim sheetname As String = "Sheet"
                    sheetindex = sheetindex + 1
                    sheetname = sheetname + sheetindex.ToString()
                    Worksheet = workbook.Sheets(sheetname.Trim())
                    If sheetindex > 0 Then
                        workbook.Worksheets.Add(After:=workbook.Worksheets(1))
                    End If

                    'Worksheet = workbook.ActiveSheet

                    CType(app.ActiveWorkbook.Sheets(x + 1), Excel.Worksheet).Activate()
                    REM changing the name of active sheet

                    Worksheet.Name = name1


                    REM storing header part in Excel

                    For i = 1 To DataGridView1.Columns.Count

                        Worksheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
                    Next

                    REM Store each row and column value to excel sheet

                    For i = 0 To DataGridView1.Rows.Count - 3

                        For j = 0 To DataGridView1.Columns.Count - 1
                            Console.WriteLine(DataGridView1.Rows(i).Cells(j).Value.ToString)

                            Worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString

                        Next

                    Next

                Next
                MessageBox.Show("Student Data Export Operation has Completed.")
                REM Open Excel with Student Data
                app.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub CheckedListBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim name As String = CheckedListBox2.SelectedItem
        VerticalDataDisplay(name)
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        LoadingValues.ProgressBar1.Increment(1)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim _activeStudents As String = String.Empty

        If CheckBox1.Checked = True Then
            _activeStudents = "active"
        ElseIf CheckBox1.Checked = False Then
            _activeStudents = "inactive"
        Else
            _activeStudents = "all"
        End If
        Dim ResetNames As IResetNames = New DefaultScreen
        ResetNames.ResetLeftNames(_activeStudents)
     
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckStateChanged
      
    End Sub

  
    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub


End Class

Public Class DisplayReport

    Private _method As String = String.Empty
    Private _score1 As String = String.Empty
    Private _score2 As String = String.Empty
    Private _score3 As String = String.Empty
    Public Sub New(ByVal studentName As String, ByVal method As String, ByVal score1 As String, ByVal score2 As String, ByVal score3 As String, ByVal _order As Integer, ByVal _date1 As Date, ByVal _date2 As Date, ByVal _date3 As Date)
        Me._score1 = score1
        Me._score2 = score2
        Me._score3 = score3
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
        Get
            Return _score1
        End Get
        Set(value As String)
            _score1 = value
        End Set
    End Property
    Public Property Second_From_Last_Date As String
        Get
            Return _score2
        End Get
        Set(value As String)
            _score2 = value
        End Set
    End Property

    Public Property Last_Date As String
        Get
            Return _score3
        End Get
        Set(value As String)
            _score3 = value
        End Set
    End Property

    Public Property Index As Integer

    Private Property First_RecordingDate As Date

    Private Property Second_RecordingDate As Date

    Private Property Third_RecordingDate As Date

End Class

Public Class DateCollection
    Private convertedDate As Date
    Public Sub New(ByVal _newdate As Date)
        Me.DateValue = _newdate
    End Sub

    Public Property DateValue As Date
        Get
            Return convertedDate
        End Get
        Set(value As Date)
            Dim convertedDateString As String = value.ToString("M/dd/yyyy")
            convertedDate = Convert.ToDateTime(convertedDateString)
        End Set
    End Property

End Class


