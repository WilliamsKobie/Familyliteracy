Imports DAL
Imports System.Text

Public Class StudentAppointmentSummation : Implements IExcelAppointmentExporter


    Public Function Export(Of T)(data As T) As Object Implements IExcelAppointmentExporter.Export
        Dim appointmentSummation As IEnumerable(Of ScheduleRequestDetailCollection) = data
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

            Worksheet.Name = "Student Request Summations"

            REM storing header part in Excel

            Worksheet.Cells(1, 1) = "First Name"
            Worksheet.Cells(1, 2) = "Last Name"
            Worksheet.Cells(1, 4) = "Number of Appointments"
            Worksheet.Cells(1, 5) = "Scheduled Appointment Date"

            Dim studentRequest = From student In appointmentSummation
               Order By student.LastName, student.FirstName, student.AppointmentDate
               Group By studentIdNumber = student.StudentNumber, studentLastName = student.LastName
               Into hours = Group, Count()
               Order By studentLastName
            Dim index As Integer = 1
            For Each appointment In studentRequest

                index = index + 1

                For Each appointmentTotal In appointment.hours

                    Worksheet.Cells(index, 1) = appointmentTotal.LastName
                    Worksheet.Cells(index, 2) = appointmentTotal.FirstName
                    Worksheet.Cells(index, 4) = appointment.Count

                    Exit For
                Next
              
            Next


         


        Catch ex As Exception
        End Try
        Return Nothing
    End Function
End Class
