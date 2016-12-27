Partial Public Class StudentAppointmentExporter : Implements IExcelAppointmentExporter

    Public Function Export(Of T)(ByVal data As T) Implements IExcelAppointmentExporter.Export
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

            Worksheet.Name = "Student Schedules"


            REM storing header part in Excel


            For i = 1 To ExportSchedule.DataGridView1.Columns.Count



                Worksheet.Cells(1, i) = ExportSchedule.DataGridView1.Columns(i - 1).HeaderText
            Next







            REM storing Each row and column value to excel sheet

            For i = 0 To ExportSchedule.DataGridView1.Rows.Count - 2


                For j = 0 To ExportSchedule.DataGridView1.Columns.Count - 1


                    Worksheet.Cells(i + 2, j + 1) = ExportSchedule.DataGridView1.Rows(i).Cells(j).Value.ToString



                Next
            Next
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

End Class
