Imports BAL
Imports DAL
Public Class SingleStudentCBMTest

    Private Sub CBM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim StudentNames As IEnumerable = NameListing.ListAllNames()
        ComboBox1.DataSource = StudentNames
        ComboBox1.DisplayMember = "FullName"
        ComboBox1.ValueMember = "FullName"
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim studentID As String
        ComboBox1.Focus()
        Dim studentSelectedName As String = ComboBox1.SelectedValue

        Dim convertStudentName As INameConversion = New StudentNameConversion
        studentID = convertStudentName.ConvertToId(studentSelectedName)
        Dim StudentCBMData As ICbmDataExporter = Nothing
        StudentCBMData = New SingleStudentCBMData
        Dim studentData As IEnumerable = StudentCBMData.Export(studentID.Trim())
        CBMDataCollectionBindingSource.DataSource = studentData
        Me.ReportViewer1.RefreshReport()
    End Sub


End Class