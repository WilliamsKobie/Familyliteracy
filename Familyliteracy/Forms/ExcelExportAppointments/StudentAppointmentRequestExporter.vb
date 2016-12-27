Imports DAL

Public Class StudentAppointmentRequestExporter : Implements IExcelAppointmentExporter
    Public Function Export(Of T)(ByVal data As T) Implements IExcelAppointmentExporter.Export

        Dim requests As IEnumerable(Of ScheduleRequestDetailCollection) = data
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

            Worksheet.Name = "Student Request"

            REM storing header part in Excel

            Worksheet.Cells(1, 1) = "First Name"
            Worksheet.Cells(1, 2) = "Last Name"
            Worksheet.Cells(1, 4) = "Request Date"
            Worksheet.Cells(1, 5) = "Means of Request"
            Dim index As Integer = 1
            For Each student In requests


                index = index + 1
                Worksheet.Cells(index, 1) = student.LastName
                Worksheet.Cells(index, 2) = student.FirstName
                Worksheet.Cells(index, 4) = student.RequestDate
                Worksheet.Cells(index, 5) = student.MeansofRequest


            Next







        Catch ex As Exception
        End Try
        Return Nothing
    End Function

End Class
