Imports BAL
Imports DAL
Public Class ClinicianConsole

    Dim dt As DataTable
    Dim SourceRowIndex As Integer = -1

    'Drag and Drop operation for repositioning the clinician
    Private Sub ClinicianConsole_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Not IsNothing(dt) Then
            dt.Clear()
            dt.Dispose()
          
        End If
    End Sub
    Private Sub ClinicianConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True      
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        DisplayRefresh()
        If CheckBox1.Checked = True Then
            DataGridView1.AllowDrop = False
        Else
            DataGridView1.AllowDrop = True
        End If
    End Sub

    Public Sub DisplayRefresh()

        Dim refreshClinicianDisplay As IrefreshScreen = New refreshMainDisplay

      
        dt = refreshClinicianDisplay.refresh()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim refresh As IrefreshScreen = New refreshHomedisplay
        Refresh.refresh()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
   
        NewClinician.Show()
        NewClinician.Focus()
    End Sub

    Private Sub NewClinicianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewClinicianToolStripMenuItem.Click

        NewClinician.Show()
    End Sub

    Private Sub ScheduleOffDaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScheduleOffDaysToolStripMenuItem.Click
        ClinicianOff.Show()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub MainDisplayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainDisplayToolStripMenuItem.Click
        HomeDisplay.Show()
        HomeDisplay.Focus()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ClinicianOff.Show()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        NewClinician.Show()
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        HomeDisplay.Show()
        HomeDisplay.Focus()
        Me.Close()
    End Sub




    'Drag and Drop operation for repositioning the clinician
    Private Sub DataGridView1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragDrop
        Try
            Dim reorderClinician As ISwapClinicians = New reorderClinicians

            If CheckBox1.Checked = False Then

                Dim pt As Point = DataGridView1.PointToClient(New Point(e.X, e.Y))
                Dim TargetRowIndex As Integer = DataGridView1.HitTest(pt.X, pt.Y).RowIndex
                If TargetRowIndex > SourceRowIndex Then
                    TargetRowIndex -= 1
                Else
                    TargetRowIndex += 1
                End If
                Dim drMove As DataRow = dt.NewRow
                drMove.ItemArray = dt.Rows(SourceRowIndex).ItemArray
                dt.Rows.RemoveAt(SourceRowIndex)
                dt.Rows.InsertAt(drMove, TargetRowIndex)
                'recount the clinicians in order and store their position in the database.


                reorderClinician.reorder()
            

            End If
        Catch ex As Exception

        End Try
    End Sub



    'Drag and Drop operation for repositioning the clinician
    Private Sub DataGridView1_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragOver
        If SourceRowIndex >= 0 Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub



    'Drag and Drop operation for repositioning the clinician
    Private Sub DataGridView1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        Try
          
            SourceRowIndex = -1
            If e.Button = Windows.Forms.MouseButtons.Left Then
                SourceRowIndex = DataGridView1.HitTest(e.X, e.Y).RowIndex
                DataGridView1.Rows(SourceRowIndex).Selected = True

                DoDragDrop(DataGridView1.Rows(SourceRowIndex), DragDropEffects.Move)
               
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp

        SourceRowIndex = -1
    
    End Sub

 

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        clincianDataforUpdating()
    End Sub
    'Open the EditClinician FORM for editing their personal information.
    ' Place their data from the gridview control into their redpective copntrols within the EditClinician FORM
    Public Sub ClincianDataforUpdating()
        Dim convertApostrophe As New nameOperation
        Dim cliniciandata As DataGridViewRow = DataGridView1.CurrentRow
        EditClinicianProfile.Show()
        Dim splitnameuser() As String
        Dim clinicianLastName, clinicianFirstName As String
        Dim parseApostrophe As New nameOperation

        Dim clinicianFullName As String = cliniciandata.Cells(2).Value.Trim & ", " & cliniciandata.Cells(1).Value.Trim
        clinicianFullName = convertApostrophe.ExecuteName(clinicianFullName, 0)
        splitnameuser = clinicianFullName.Split(",")
        Dim parsedAddress As String = String.Empty
        Dim address As String = String.Empty
        Dim parsecity As String = String.Empty
        Dim parsedEmail As String = String.Empty
        email = cliniciandata.Cells(6).Value.ToString
        Dim city As String = String.Empty
        address = cliniciandata.Cells(7).Value.ToString()
        city = cliniciandata.Cells(8).Value.ToString
        parsedAddress = parseApostrophe.ExecuteName(address, 2)
        parsedcity = parseApostrophe.ExecuteName(city, 2)
        parsedEmail = parseApostrophe.ExecuteName(email, 2)


        clinicianLastName = splitnameuser(0).Trim
        clinicianFirstName = splitnameuser(1).Trim
        EditClinicianProfile.Label13.Text = cliniciandata.Cells(0).Value
        EditClinicianProfile.TextBox2.Text = clinicianFirstName 'FirstName
        EditClinicianProfile.TextBox1.Text = clinicianLastName 'Last Name

        EditClinicianProfile.MaskedTextBox2.Text = cliniciandata.Cells(3).Value.ToString 'Phone
        EditClinicianProfile.MaskedTextBox3.Text = cliniciandata.Cells(4).Value.ToString 'Cell Phone
        EditClinicianProfile.MaskedTextBox4.Text = cliniciandata.Cells(5).Value.ToString 'Alt Phone
        EditClinicianProfile.TextBox10.Text = parsedEmail.Trim 'Email
        EditClinicianProfile.TextBox3.Text = parsedAddress.Trim
        EditClinicianProfile.TextBox4.Text = parsedcity.trim 'City
        EditClinicianProfile.ComboBox1.Text = cliniciandata.Cells(9).Value.ToString 'State
        EditClinicianProfile.MaskedTextBox1.Text = cliniciandata.Cells(10).Value.ToString 'Zip

        EditClinicianProfile.CheckBox1.Checked = cliniciandata.Cells(11).Value
        EditClinicianProfile.CheckBox2.Checked = cliniciandata.Cells(12).Value
        EditClinicianProfile.WebAccountSet(parsedEmail)
    End Sub


    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        clincianDataforUpdating()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ClinicianOff.Show()
        ClinicianOff.Focus()
    End Sub
End Class


'Switch clinicians order positioning on how they are displayed
Interface ISwapClinicians
    Function reorder()
End Interface
Class reorderClinicians

    Implements ISwapClinicians

    Public Function reorder() Implements ISwapClinicians.reorder
        Try
            Dim moveClincian As IUpdateClincianAttributes = New UserAttributes
            Dim ClinicianTable As New Clinicians
            Dim numofrows As Integer = 0
            Dim clincianId As String = String.Empty
            Dim idChk As String = String.Empty
            ds = ClinicianTable.GetClinicianInfo(False)

            dt = ds.Tables("Clinician")

            numofrows = dt.Rows.Count - 1

            For a = 0 To numofrows

                idChk = ClinicianConsole.DataGridView1.Rows(a).Cells(0).Value
                clinicianID = idChk.Trim
                'this id number 018c is static at poistion 0. It cannot be moved out of its initial position
                If clinicianID = "018c" Then
                    moveClincian.clincianDisplayOrder(clinicianID.Trim, 0)

                Else
                    moveClincian.clincianDisplayOrder(clinicianID.Trim, a + 1)
                End If
            Next

            Dim refreshHomeScreen As IrefreshScreen = New refreshHomedisplay


            Return Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
'Setup Displays 
Interface IrefreshScreen
    Function refresh() As DataTable

End Interface
Public Class refreshMainDisplay

    Implements IrefreshScreen
    Public Function refresh() As DataTable Implements IrefreshScreen.refresh
        Dim SetupClinicians As New Clinicians
        Dim ClinicianTable As New Clinicians
        Dim ds As New DataSet

        If ClinicianConsole.CheckBox1.Checked = True Then

            ds = SetupClinicians.GetClinicianInfo(True)


        ElseIf ClinicianConsole.CheckBox1.Checked = False Then
            ds = SetupClinicians.GetClinicianInfo(False)

        End If

        dt = ds.Tables("Clinician")
        ClinicianConsole.DataGridView1.DataSource = dt
        ClinicianConsole.DataGridView1.Columns(13).Visible = False

        Return dt
    End Function

End Class

Public Class refreshHomedisplay
    Implements IrefreshScreen
    Public Function refresh() As DataTable Implements IrefreshScreen.refresh
        scheduledate = HomeDisplay.MonthCalendar1.SelectionStart
        Dim ClinicianTable As New Clinicians

        ds = ClinicianTable.GetClinicianInfo(False)
        Dim dt As DataTable = ds.Tables("Clinician")
        ClinicianConsole.DataGridView1.DataSource = dt
        HomeDisplay.Show()

        HomeDisplay.RemoveColumns()
        HomeDisplay.DataGridView1.Columns.Add("Column1", "")
        HomeDisplay.HomeScreen(scheduledate)


        Return Nothing
    End Function
End Class

