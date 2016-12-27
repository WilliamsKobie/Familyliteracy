Imports DAL
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class DataTransferAppointmentKey
    Dim importer As New CampusDTO()
    Dim capturedData As IEnumerable(Of CampusObject)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        capturedData = importer.Download()
        MessageBox.Show("Download Complete!" & vbCrLf & "Number of records=" & capturedData.Count)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        importer.Upload(capturedData)
        MessageBox.Show("Upload Complete!")

    End Sub
End Class