Imports Familyliteracy.ExportProfileData
Public Class ExportStudentProfile

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Export()
    End Sub
    Public Function Export()
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

            Worksheet.Name = "Student Information"


            REM storing header part in Excel

            For i = 1 To DataGridView1.Columns.Count



                Worksheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
            Next



            REM Store each row and column value to excel sheet

            For i = 0 To DataGridView1.Rows.Count - 1

                For j = 0 To DataGridView1.Columns.Count - 1

                    Worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString
                    Console.WriteLine(DataGridView1.Rows(i).Cells(j).Value.ToString)
                Next


            Next
            workbook.SaveAs("c:\StudentProfileData.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

        Catch ex As Exception
        End Try

        Return Nothing
    End Function



    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ExportProfileSelector.Show()
        ExportProfileSelector.Focus()
    End Sub
End Class