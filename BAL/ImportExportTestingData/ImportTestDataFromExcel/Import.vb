Imports Microsoft.Office.Interop.Excel


Public Class Import
    Public Function GetExcelData() As List(Of ImportCollection)

        Dim storage As New List(Of ImportCollection)
        Dim excel As Application = New Application

        ' Open Excel spreadsheet.
        Dim w As Workbook = excel.Workbooks.Open("C:\Users\Administrator.Ankaboot\Desktop\Familyliteracy-v2.0\Familyliteracy\CBMdata2013")

        ' Loop over all sheets.
        For i As Integer = 1 To w.Sheets.Count

            ' Get sheet.
            Dim sheet As Worksheet = w.Sheets(i)

            ' Get range.
            Dim r As Range = sheet.UsedRange

            ' Load all cells into 2d array.
            Dim array(,) As Object = r.Value(XlRangeValueDataType.xlRangeValueDefault)

            ' Scan the cells.
            If array IsNot Nothing Then
                Console.WriteLine("Length: {0}", array.Length)

                ' Get bounds of the array.
                Dim bound0 As Integer = array.GetUpperBound(0)
                Dim bound1 As Integer = array.GetUpperBound(1)

                Console.WriteLine("Dimension 0: {0}", bound0)
                Console.WriteLine("Dimension 1: {0}", bound1)

                ' Loop over all elements.
                For j As Integer = 3 To bound0
                    Dim firstname As String = String.Empty
                    Dim lastName As String = String.Empty
                    Dim cwpm As String = String.Empty
                    Dim testDate As Date = Nothing
                    Dim errors As String = String.Empty
                    Dim timerecord As String = String.Empty
                    Dim sourceLevel As String = String.Empty
                    Dim level As String = String.Empty
                    Dim totalWords As String = String.Empty
                    ' Debug.Assert(j <> 47)
                    For x As Integer = 1 To bound1
                        Dim s1 As String = array(j, x)


                    Next
                    lastName = array(j, 1)
                    firstname = array(j, 2)
                    cwpm = array(j, 6)
                    testDate = array(j, 3)
                    errors = array(j, 7)
                    timerecord = array(j, 8)
                    sourceLevel = array(j, 4)
                    level = array(j, 5)
                    totalWords = array(j, 9)
                    storage.Add(New ImportCollection(lastName.Trim, firstname.Trim, testDate, cwpm, errors, totalWords, "1:00", sourceLevel, level))
                Next
            End If
        Next

        ' Close.
        w.Close()
        Return storage
    End Function

End Class
