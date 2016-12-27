Imports DAL
Imports System.Reflection
Public Class ReportsMenu

    Private Sub ReportsMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_FamilyLiteracy_mdfDataSet3.ReportClientProfileMenu' table. You can move, or remove it, as needed.
        Me.ReportClientProfileMenuTableAdapter1.Fill(Me._FamilyLiteracy_mdfDataSet3.ReportClientProfileMenu)
        
        'TODO: This line of code loads data into the '_FamilyLiteracy_mdfDataSet1.ReportScheduleMenu' table. You can move, or remove it, as needed.
        Me.ReportScheduleMenuTableAdapter.Fill(Me._FamilyLiteracy_mdfDataSet1.ReportScheduleMenu)
        'TODO: This line of code loads data into the '_FamilyLiteracy_mdfDataSet.ReportStudentTestMenu' table. You can move, or remove it, as needed.
        Me.ReportStudentTestMenuTableAdapter.Fill(Me._FamilyLiteracy_mdfDataSet.ReportStudentTestMenu)

    End Sub

    Public Function SelectReport()

        Dim selectedReportIndex As String = ""
        Dim reportForm As String = ""

        'Capture Menu Report title and Form Title
        If Me.TabControl1.SelectedIndex = 0 Then
            selectedReportIndex = DataGridView1.CurrentRow.Cells(0).Value
            Dim report As IReportMenuSignatures
            report = New ReportTestSignatures
            reportForm = report.Capture(selectedReportIndex.Trim())
        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            selectedReportIndex = DataGridView2.CurrentRow.Cells(0).Value
            Dim report As IReportMenuSignatures
            report = New ReportScheduleSignature
            reportForm = report.Capture(selectedReportIndex.Trim())
        ElseIf Me.TabControl1.SelectedIndex = 2 Then
            selectedReportIndex = DataGridView3.CurrentRow.Cells(0).Value
            Dim report As IReportMenuSignatures
            report = New ReportClientProfileSignature
            reportForm = report.Capture(selectedReportIndex.Trim())
        End If

        'Scan for the Report Form
        Dim currentAssembly = Assembly.GetExecutingAssembly()
        Dim ReportCollection = currentAssembly.GetTypes().Where(Function(t) t.Name = reportForm.Trim())
        Dim reportObj As Type

        For Each reportObj In ReportCollection
            Dim FormObj = Activator.CreateInstance(reportObj)
            DirectCast(FormObj, Form).Show()
            DirectCast(FormObj, Form).Focus()
        Next

        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectReport()
    End Sub

    
End Class