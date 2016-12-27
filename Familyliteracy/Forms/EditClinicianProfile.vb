Imports BAL
Imports DAL
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Security
Imports System.Security.Principal
Imports System.Web

Public Class EditClinicianProfile

    'Close Editclincian FORM
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Close()
    End Sub

    Private Sub EditClinician_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set texas as the default state
        ComboBox1.SelectedItem = "TX"

    End Sub

    'Edit Clinician information to the data source
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim clinicianNameConversion As INameConversion = New ClinicianNameConversion
        Dim setupClinicians As New Clinicians
        Dim convertApostrophe As New nameOperation
        Dim Clinattributes As New ArrayList

        Dim submitinfo As IEditUser = New Users

        Dim Firstname As String = String.Empty
        Dim Lastname As String = String.Empty
        Dim convertname As New Schedule
        Dim email As String = String.Empty
        Dim clinicianName As String = Nothing
        Dim city As String = String.Empty
        Dim address As String = String.Empty
        Dim state As String = String.Empty
        Dim ds As New DataSet
        Dim Conflict As New DataSet
        Dim scheduledate As Date
        scheduledate = HomeDisplay.MonthCalendar1.SelectionStart
        Lastname = TextBox2.Text.ToString
        Firstname = TextBox1.Text.ToString

        Dim forbiddenSymbols() As String = {"?", "/", "\", "$", "#", "!", "<", ">", ";", ",", ":", "+", "=", "[", "]", "{", "}", "|", "%", "@", "^", """"}
        Dim symbols = (From p In forbiddenSymbols
                       Where Firstname.Contains(p) Or Lastname.Contains(p)
                      Select p).FirstOrDefault

        If Not symbols = Nothing Then
            MsgBox("Name must not contain symbols e.g. ? / \ < > # $ ; , : + = [  { }  ] | % @ ^ *")
            Exit Sub
        End If
        Dim clinicianFullName As String = Lastname.Trim & ", " & Firstname.Trim
        Dim addressWithoutApostrophe As String = String.Empty
        Dim cityWithoutApostrophe As String = String.Empty
        Dim emailWithoutApostrophe As String = String.Empty

      
        clinicianFullName = convertApostrophe.ExecuteName(clinicianFullName, 0)
        Lastname = convertApostrophe.ExecuteName(Lastname, 3)
        Firstname = convertApostrophe.ExecuteName(Firstname, 3)
        email = TextBox10.Text.ToString
        address = TextBox3.Text.ToString
        city = TextBox4.Text.ToString
        state = ComboBox1.SelectedItem.ToString
        addressWithoutApostrophe = convertApostrophe.ExecuteName(address, 3)
        cityWithoutApostrophe = convertApostrophe.ExecuteName(city, 3)
        emailWithoutApostrophe = convertApostrophe.ExecuteName(email, 3)

        Clinattributes.Add(Label13.Text)
        Clinattributes.Add(Lastname.Trim) 'Last Name
        Clinattributes.Add(Firstname.Trim) 'First Name
        Clinattributes.Add(MaskedTextBox2.Text) 'Phone
        Clinattributes.Add(MaskedTextBox3.Text) 'Cell Phone

        Clinattributes.Add(MaskedTextBox4.Text) 'Alt Phone
        Clinattributes.Add(emailWithoutApostrophe.Trim) 'Email

        Clinattributes.Add(addressWithoutApostrophe.Trim) 'Address
        Clinattributes.Add(cityWithoutApostrophe.Trim) 'City
        If state = String.Empty Then
            MsgBox("You Must Select a State!")
            Exit Sub
        Else
            Clinattributes.Add(ComboBox1.SelectedItem) 'State
        End If
        Clinattributes.Add(MaskedTextBox1.Text) 'Zip Code

        'Check to see if there are any scheduled student by the above clinician
        'Check to see if Clinician has a student before makeing them inactive

        Dim dt2 As DataTable
        Dim clinicianid As String = String.Empty


        clinicianid = clinicianNameConversion.ConvertToId(clinicianFullName.Trim)
        Conflict = setupClinicians.GetClinicianSchedule(clinicianid.Trim, Today)


        Dim num As Integer
        dt2 = Conflict.Tables("MainSchedule")

        num = dt2.Rows.Count
        If num > 0 And CheckBox1.Checked = True Then
            MsgBox("There are students who need to be rescheduled to a different date and time")
            Clinattributes.Add(CheckBox1.Checked = False)
        Else
            Clinattributes.Add(CheckBox1.Checked)

        End If

        If CheckBox2.Checked = True Then
            Clinattributes.Add("True")
        ElseIf CheckBox2.Checked = False Then
            Clinattributes.Add("False")
        End If
        submitinfo.EditClinician(Clinattributes)
        'Get Active or 'InActive Clinician
        If ClinicianConsole.CheckBox1.Checked = True Then

            ds = setupClinicians.GetClinicianInfo(True)

        ElseIf ClinicianConsole.CheckBox1.Checked = False Then
            ds = setupClinicians.GetClinicianInfo(False)

        End If
        REM Autoselect ON/OFF


        Dim dt As DataTable = ds.Tables("Clinician")
        ClinicianConsole.DataGridView1.DataSource = dt
        HomeDisplay.Show()

        HomeDisplay.RemoveColumns()
        HomeDisplay.DataGridView1.Columns.Add("Column1", "")
        HomeDisplay.HomeScreen(scheduledate)
        StudentManager.ResetDisplay()
        Me.Close()
        ClinicianConsole.Show()
        ClinicianConsole.Focus()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If TextBox10.Text <> String.Empty Then
            username = TextBox10.Text.Trim()
            Membership.DeleteUser(username.Trim(), True)
            WebAccountSet(username)
            MsgBox("Web account has been deleted")

        Else
            MsgBox("Must have a email address to delete the account.")

        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim pass As String = TextBox5.Text.Trim()
        If pass.Length > 4 Then
            Dim username As String = String.Empty
            username = TextBox10.Text.Trim()
            Dim user As MembershipUser = Membership.GetUser(username.Trim())
            If user Is Nothing Then
                Dim role As String = "clinician"
                Dim rolebased(0) As String
                rolebased(0) = username
                Membership.CreateUser(username, pass, username)
                If Not Roles.RoleExists("clinician") Then
                    Roles.CreateRole("clinician")

                End If
                Roles.AddUsersToRole(rolebased, "clinician")

                WebAccountSet(username.Trim())
                MsgBox(TextBox1.Text.Trim() + " " + TextBox2.Text.Trim() + " web account is now set.")
            Else
                MsgBox(TextBox1.Text.Trim() + " " + TextBox2.Text.Trim() + " already has an active web account.")
            End If
        Else
            MsgBox("Password must be at least 5 character long.")
        End If
    End Sub

    Public Sub WebAccountSet(ByVal username As String)

        ' Dim user As MembershipUser = Nothing
        'If username <> String.Empty Then
        'user = Membership.GetUser(username.Trim())
        'End If

        'If user Is Nothing Then
        '
        '   Label15.Text = "Web Account: In-Active"
        'Else

        '   Label15.Text = "Web Account: Active"
        'End If
    End Sub




    Public Sub SendEmail(ByVal username As String, ByVal password As String)
        Dim ConfirmationMail As New MailMessage()
        Dim sFrom As String = "help@familyliteracy.net"
        Dim sTo As String = username
        sTo = sTo.Trim()
        ConfirmationMail.From = New MailAddress(sFrom)

        ConfirmationMail.To.Add(username)

        ConfirmationMail.Subject = "Family Literacy Network Password Confirmation"


        ConfirmationMail.Body = "Thank You for choosing Family Literacy Network" & vbCrLf &
            "Your username is: " & username & vbCrLf & "Your Password is: " & password & vbCrLf &
             vbCrLf & "Click here to login  http://familyliteracy.net/flnsite"


        Dim Client = New SmtpClient("smtp.1and1.com", 587)

        Client.Credentials = New NetworkCredential("help@familyliteracy.net", "famlithelp")
        Client.EnableSsl = False
        Client.Send(ConfirmationMail)
    End Sub
End Class