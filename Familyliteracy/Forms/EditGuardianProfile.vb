Imports DAL
Imports BAL
Imports System.Web
Imports System.Web.Security
Imports System.Net.Mail
Imports System.Net

Public Class EditGuardianProfile
    'Submit edited guardian contact information to the database
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim guardianinfo As IEditUser = New Users
        Dim parseApostrophe As New nameOperation
        Dim guardianid As String = [String].Empty
        Dim Firstname As String = [String].Empty
        Dim Lastname As String = [String].Empty
        Dim Guardiantype As String = [String].Empty
        Dim Address As String = [String].Empty
        Dim City As String = [String].Empty
        Dim state As String = [String].Empty
        Dim zipcode As String = [String].Empty
        Dim email As String = [String].Empty
        Dim altemail As String = [String].Empty
        Dim HmPhone As String = [String].Empty
        Dim WKPhone As String = [String].Empty
        Dim CellPhone As String = [String].Empty
        Dim OtherPhone As String = [String].Empty
        Dim Fax As String = [String].Empty

        guardianid = Label15.Text.Trim
        Firstname = TextBox1.Text.ToString 'Guardian First Name
        Lastname = TextBox2.Text.ToString 'Guardian Last Name
        Address = TextBox3.Text.ToString 'Guardian address
        City = TextBox4.Text.ToString 'Guradian City
        Guardiantype = ComboBox1.SelectedItem.ToString 'Guardians relationship to the student.
        If ComboBox2.SelectedItem = Nothing Then 'Check for an empty selection
            MsgBox("You must select a U.S. state!")
            Exit Sub
        Else
            state = ComboBox2.SelectedItem.ToString
        End If

        zipcode = MaskedTextBox1.Text.ToString
        HmPhone = MaskedTextBox2.Text
        WKPhone = MaskedTextBox3.Text
        CellPhone = MaskedTextBox4.Text
        Fax = MaskedTextBox5.Text

        email = TextBox5.Text
        altemail = TextBox6.Text
        If guardianid = [String].Empty Then
            MsgBox("Guardian does not exsist")
            Exit Sub
        End If
        Dim addressWothoutApostrophe As String = String.Empty
        Dim cityWothoutApostrophe As String = String.Empty
        Dim emailWothoutApostrophe As String = String.Empty
        Dim altemailWothoutApostrophe As String = String.Empty
        Firstname = parseApostrophe.ExecuteName(Firstname, 3)
        Lastname = parseApostrophe.ExecuteName(Lastname, 3)
        addressWithoutApostrophe = parseApostrophe.ExecuteName(Address, 3)
        cityWithoutApostrophe = parseApostrophe.ExecuteName(City, 3)
        emailWithoutApostrophe = parseApostrophe.ExecuteName(email, 3)
        altemailWithoutApostrophe = parseApostrophe.ExecuteName(altemail, 3)
        'Add updated data to the datasource
        guardianinfo.EditGuardian(guardianid.Trim, Firstname.Trim, Lastname.Trim, addressWithoutApostrophe.Trim,
                                 cityWithoutApostrophe.Trim, state.Trim, zipcode.Trim, HmPhone.Trim, CellPhone.Trim, WKPhone.Trim, Fax.Trim,
                                  emailWithoutApostrophe.Trim, altemailWithoutApostrophe.Trim, Guardiantype.Trim)
        StudentManager.ResetDisplay()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub EditGuardianInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox2.SelectedItem = "TX"

    End Sub


 
  
    Public Sub WebAccountSet(ByVal username As String)

        'Dim user As MembershipUser = Membership.GetUser(username.Trim())

        ' If user Is Nothing Then

        'Label12.Text = "Web Account: In-Active"
        'Else

        'Label12.Text = "Web Account: Active"
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

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        username = TextBox5.Text.Trim()
        Membership.DeleteUser(username.Trim(), True)
        MsgBox("Web account has been deleted")
    End Sub

    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim pass As String = TextBox7.Text.Trim()
        If pass.Length > 4 Then
            Dim username As String = String.Empty
            username = TextBox5.Text.Trim()
            Dim user As MembershipUser = Membership.GetUser(username.Trim())
            If user Is Nothing Then
                Dim role As String = "guardian"
                Dim rolebased(0) As String
                rolebased(0) = username
                Membership.CreateUser(username, pass, username)
                If Not Roles.RoleExists("guardian") Then
                    Roles.CreateRole("guardian")

                End If
                Roles.AddUsersToRole(rolebased, "guardian")

                WebAccountSet(username.Trim())
                MsgBox(TextBox1.Text.Trim() + " " + TextBox2.Text.Trim() + " web Account is now set.")
            Else
                MsgBox(TextBox1.Text.Trim() + " " + TextBox2.Text.Trim() + " already has an active web account.")
            End If
        Else
            MsgBox("Password must be at least 5 character long.")
        End If
    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim password As String = String.Empty
        Dim username = TextBox5.Text
        Dim user As MembershipUser
        user = Membership.GetUser(username.Trim(), False)
        If Not user Is Nothing Then

            user.UnlockUser()
            password = user.GetPassword()
            SendEmail(username, password)
            MsgBox("Email has been sent.")

        Else
            MsgBox("User is not registered with a web account.", vbOK, "Unregistered User")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class