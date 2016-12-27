Imports DAL
Imports BAL
Public Class Export_Test_Data

    Private studentGroupData As New List(Of ExportCollection)

    Private Sub Export_Test_Data_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim names As IPopulateAllNames = New IPopulateNames
        Dim dsStudent As New DataSet
        dsStudent = names.DisplayStudents(True)
        Dim dtStudent As DataTable = dsStudent.Tables("StudentList")
        ComboBox1.DataSource = dtStudent
        ComboBox1.DisplayMember = "FullName"
        ComboBox1.ValueMember = "FullName"
        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = True
        DisplayAllStudents()
    End Sub

    Public Sub DisplayAllStudents()

        Dim testingCollection As List(Of ExportCollection)
        testingCollection = Export.AllStudents

        Dim query = From p In testingCollection
                      Order By p.Source, p.Reading_Level, p.Session_Date, p.Reading_Passage
                    Select p
        Dim bs As New BindingSource
        bs.DataSource = query
        DataGridView1.DataSource = bs
        DataGridView1.Columns(4).Width = 180
    End Sub





    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ExportToExcel()
    End Sub


    Public Function ExportToExcel()
        Try

            Dim app As New Microsoft.Office.Interop.Excel.Application


            REM creating new WorkBook within Excel application



            Dim workbook As Microsoft.Office.Interop.Excel.Workbook = app.Workbooks.Add(Type.Missing)


            REM creating new Excelsheet in workbook


            Dim Worksheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

            REM see the excel sheet behind the program

            app.Visible = True



            REM get the reference of first sheet. By default its name is Sheet1.

            REM store its reference to worksheet

            Worksheet = workbook.Sheets("Sheet1")

            Worksheet = workbook.ActiveSheet


            REM changing the name of active sheet

            Worksheet.Name = "Student Testing Information"


            REM storing header part in Excel

            For i = 1 To DataGridView1.Columns.Count



                Worksheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
            Next




            REM Store each row and column value to excel sheet

            For i = 0 To DataGridView1.Rows.Count - 1


                For j = 0 To DataGridView1.Columns.Count - 1


                    Worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString



                Next
            Next
            ' workbook.SaveAs("c:\StudentTestingData.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            '  Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

        Catch ex As Exception

        End Try

        Return Nothing
    End Function



    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Visible = False
        Button2.Hide()
        Button3.Hide()
        studentGroupData.Clear()
        DisplayAllStudents()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ComboBox1.Focus()
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        StudentGroup()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Button2.Show()
        Button3.Show()
        ComboBox1.Visible = True
        ComboBox1.Focus()      
        ComboBox1.SelectedIndex = 0
        DisplaySelectedStudents()
    End Sub

    Public Sub StudentGroup()
        Dim singleStudentData As List(Of DisplayCBMData)
        Dim studentName As String
        Dim studentId As String
        Dim fname As String = String.Empty
        Dim lname As String = String.Empty
        Dim splitName() As String
        ComboBox1.Focus()
        studentName = ComboBox1.SelectedText
        Dim student As IreturnStudentCBMInfo = New StudentCBMInfo
        Dim studentNo = New StudentNameConversion
        studentId = studentNo.ConvertToId(studentName)

        If studentName <> String.Empty Then
            splitName = studentName.Split(",")
            If splitName.Length > 1 Then
                fname = splitName(1)
                lname = splitName(0)
            End If
        End If

        Dim values = From p In studentGroupData
                     Where p.LastName = lname.Trim() And p.FirstName = fname.Trim()
                     Select p
        If values.Count < 1 Then
            singleStudentData = student.StudentTestData(studentId.Trim())
            Dim singlevalues = From p In singleStudentData
                         Select p

            For Each item In singlevalues
                studentGroupData.Add(New ExportCollection(studentId.Trim(), item.Session_Date, item.CWPM, item.Errors, item.Source_Material, item.Total_Words, item.Time, item.Reading_Level, item.Reading_Passage))
            Next

            DisplaySelectedStudents()
        End If
    End Sub

    Public Sub RemoveStudentFromGroup()

        Dim studentName As String
        Dim studentId As String
        Dim fname As String = String.Empty
        Dim lname As String = String.Empty
        ComboBox1.Focus()
        studentName = ComboBox1.SelectedText
        Dim splitName As String()

        Dim student As IreturnStudentCBMInfo = New StudentCBMInfo
        Dim studentNo = New StudentNameConversion
        studentId = studentNo.ConvertToId(studentName.Trim())
        If studentName <> String.Empty Then
            splitName = studentName.Split(",")
            fname = splitName(1)
            lname = splitName(0)

        End If
        Dim values = From p In studentGroupData
                     Where p.LastName = lname.Trim() And p.FirstName = fname.Trim()
                     Select p
        For Each item In values.ToList
            studentGroupData.Remove(item)

        Next

        DisplaySelectedStudents()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        RemoveStudentFromGroup()
    End Sub
    Public Sub DisplaySelectedStudents()
        Dim bs As New BindingSource
        bs.DataSource = studentGroupData
        DataGridView1.DataSource = bs
        If DataGridView1.Rows.Count > 1 Then
            DataGridView1.Columns(4).Width = 180
        End If
    End Sub
End Class