Imports BAL
Imports DAL
Imports System.Web.Security
Public Class NewGuradian
    'Create a new guardian
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim parseApostrophe As New nameOperation
        Dim Guardianid As String = [String].Empty
        Dim Firstname As String = [String].Empty
        Dim Lastname As String = [String].Empty
        Dim Guardian As String = [String].Empty
        Dim Email As String = [String].Empty
        Dim AltEmail As String = [String].Empty
        Dim Address As String = [String].Empty
        Dim City As String = [String].Empty
        Dim state As String = [String].Empty
        Dim HomePhone As String = [String].Empty
        Dim workPhone As String = [String].Empty
        Dim CellPhone As String = [String].Empty
        Dim Fax As String = [String].Empty
        Dim OtherPhone As String = [String].Empty
        Dim ZipCode As String = [String].Empty
        Dim GuardianType As String = [String].Empty
        Dim getid As IUserIdNumbers = New GenerateGuardianID
        Dim Addguardian As IAddNewUser = New Users

        Guardianid = getid.GenerateIdNumber
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        Address = TextBox4.Text
        City = TextBox5.Text
        Guardian = ComboBox1.SelectedItem.ToString
        state = ComboBox2.SelectedItem.ToString
        ZipCode = MaskedTextBox5.Text
        HomePhone = MaskedTextBox1.Text
        workPhone = MaskedTextBox2.Text
        CellPhone = MaskedTextBox3.Text
        Fax = MaskedTextBox4.Text

        Email = TextBox7.Text
        AltEmail = TextBox8.Text
        Dim addressWothoutApostrophe As String = String.Empty
        Dim cityWothoutApostrophe As String = String.Empty
        Dim emailWothoutApostrophe As String = String.Empty
        Dim altemailWothoutApostrophe As String = String.Empty
        Firstname = parseApostrophe.ExecuteName(Firstname.Trim, 3)
        Lastname = parseApostrophe.ExecuteName(Lastname.Trim, 3)
        addressWithoutApostrophe = parseApostrophe.ExecuteName(Address, 3)
        cityWithoutApostrophe = parseApostrophe.ExecuteName(City, 3)
        emailWithoutApostrophe = parseApostrophe.ExecuteName(Email, 3)
        altemailWithoutApostrophe = parseApostrophe.ExecuteName(AltEmail, 3)

        Addguardian.SetupGuardian(Guardianid.Trim, Firstname.Trim, Lastname.Trim, addressWithoutApostrophe.Trim,
                                   cityWithoutApostrophe.Trim, state.Trim, ZipCode.Trim, HomePhone.Trim, CellPhone.Trim, workPhone.Trim, Fax.Trim,
                                   OtherPhone.Trim, emailWithoutApostrophe.Trim, altemailWithoutApostrophe.Trim, Guardian.Trim)

        'Clear out all the Entries
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        MaskedTextBox3.Text = String.Empty
        MaskedTextBox1.Text = String.Empty
        MaskedTextBox2.Text = String.Empty
        MaskedTextBox4.Text = String.Empty
        MaskedTextBox5.Text = String.Empty


        StudentManager.ResetDisplay()
        Me.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    'Set Texas as the default state
    Private Sub AddGuardianInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox2.SelectedItem = "TX"
    End Sub



  

 
End Class