Imports BAL

Public Class SignIn
    'Sign-In
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        signSuccess()
    End Sub
    'Populate Combobox control with all the clinician names
    Private Sub SignIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim clincianNames As IPopulateAllNames = New IPopulateNames
        Dim ds1 As New DataSet
        ds1 = clincianNames.DisplayClinician(False)
        Dim dt1 As DataTable = ds1.Tables("clinicianList")
        ComboBox1.DataSource = dt1
        ComboBox1.DisplayMember = "clinicianFullName"
        ComboBox1.ValueMember = "clinicianFullName"
     
    End Sub


    Public Sub signSuccess()

        If Me.ComboBox1.Text <> String.Empty Then
            'Place user name on the SchedulingConsole.vb FORM
            Dim signInUser As String = String.Empty
            signInUser = Convert.ToString(ComboBox1.Text)

            HomeDisplay.Label4.Text = signInUser.Trim

            'Reset Login timer
            HomeDisplay.Timer2.Enabled = True
            'Enable all the controls that the user has access to on the HomeDisplay.vb FORM after signing in
            HomeDisplay.Button11.Enabled = False
            HomeDisplay.Button12.Enabled = True
            HomeDisplay.GroupBox4.Enabled = True
            HomeDisplay.Button5.Enabled = True
            HomeDisplay.GroupBox5.Enabled = True
            HomeDisplay.ComboBox1.Enabled = True
            HomeDisplay.Button3.Enabled = True
            HomeDisplay.Button4.Enabled = True
            HomeDisplay.Button12.Enabled = True
            HomeDisplay.Button13.Enabled = True
            HomeDisplay.Button14.Enabled = True

            Me.Close()
        End If
      
    End Sub

    'Cancel
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class