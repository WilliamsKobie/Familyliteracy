Imports DAL
Imports BAL
Public Class Export_Assesment_Test

    Private Sub Export_Assesment_Test_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DisplayData()

    End Sub

    Public Sub DisplayData()
        Dim names As IPopulateAllNames = New IPopulateNames
        Dim dsStudent As New DataSet
        dsStudent = names.DisplayStudents(True)
        Dim dtStudent As DataTable = dsStudent.Tables("StudentList")
        ComboBox1.DataSource = dtStudent
        ComboBox1.DisplayMember = "FullName"
        ComboBox1.ValueMember = "FullName"
        ComboBox1.SelectedIndex = 0
        Dim exportedData As New List(Of ExportAssessmentDataObject)
        Dim studentNo As String = String.Empty
        Dim studentName As String = String.Empty
        ComboBox1.Focus()
        studentName = ComboBox1.SelectedText
        exportedData = ExportAssesmentData.Export(studentNo.Trim())
        Dim bs As New BindingSource
        bs.DataSource = exportedData
        DataGridView1.DataSource = bs

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        DisplayStudentData()
    End Sub

    Public Sub DisplayStudentData()
        ComboBox1.Focus()
        studentName = ComboBox1.SelectedText
        Dim convertName As INameConversion = New StudentNameConversion
        studentNo = convertName.ConvertToId(studentName.Trim())

        exportedData = ExportAssesmentData.Export(studentNo.Trim())
        Dim bs As New BindingSource
        bs.DataSource = exportedData
        DataGridView1.DataSource = bs
        If studentName <> String.Empty Then
         
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
        Else
            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(1).Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ExportDataExcel()
    End Sub

    Public Sub ExportDataExcel()
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



                Worksheet.Cells(1, i) = Me.DataGridView1.Columns(i - 1).HeaderText
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


    End Sub
End Class