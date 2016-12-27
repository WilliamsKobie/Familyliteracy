Imports BAL

Imports DAL
Public Class ImportTestingMeasurements

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
     
        'Store Data using linq to Entities
        Dim studentId As String = String.Empty
        Dim cwpm As Integer = 0
        Dim recordDate As Date = Nothing
        Dim errors As Integer = 0
        Dim totalWords As Integer = 0
        Dim sourceLevel As String = String.Empty
        Dim level As String = String.Empty
        Dim readingSpeed As String = String.Empty
        Dim saveMeasurement As IsaveNewCBMRecord = New SaveNewCBM
        '  Dim query = From p In excelData
        '             Select p
        For Each p In excelData

            studentId = p.StudentNo
            cwpm = Convert.ToInt16(p.CWPM)
            recordDate = Convert.ToDateTime(p.Session_Date)
            errors = Convert.ToInt16(p.Errors)
            totalWords = Convert.ToInt16(p.Total_Words)
            sourceLevel = p.Reading_Level
            level = p.Reading_Passage
            readingSpeed = p.Time
            saveMeasurement.Save(studentId.Trim, recordDate, cwpm, errors, readingSpeed, totalWords, "Text", "Ed Formation", sourceLevel, level)

        Next
        MsgBox("Complete!")

    End Sub
End Class