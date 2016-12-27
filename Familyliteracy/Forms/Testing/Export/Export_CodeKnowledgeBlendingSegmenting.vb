Public Class Export_CodeKnowledgeBlendingSegmenting

    Private Sub Export_CodeKnowledgeBlendingSegmenting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

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

                For j = 0 To DataGridView1.Columns.Count - 3

                    If Not DataGridView1.Rows(i).Cells(j + 1).Value.ToString = String.Empty Then
                        Worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString
                    End If
                Next
            Next
            workbook.SaveAs("c:\CodeKnowledge_Blending_Segmenting.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
            Exit Sub
        Catch ex As Exception

        End Try


    End Sub

End Class