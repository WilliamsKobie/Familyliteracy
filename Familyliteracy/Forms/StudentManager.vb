
Imports System.Configuration
Imports BAL
Imports DAL

Public Delegate Function GuardianDelegate() As Dictionary(Of String, String)
Public Class StudentManager

    Private Sub StudentManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ResetDisplay()
      
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewStudent.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    ' Refresh and populate all of then comboboxes
    Public Function ResetDisplay()
        Dim StudentName = New List(Of StudentNames)

        StudentName = NameListing.ListAllNames()
        ComboBox3.SelectedIndex = 0
   

      
        ComboBox1.DataSource = StudentName
        ComboBox1.DisplayMember = "FullName"
        ComboBox1.ValueMember = "FullName"
        ComboBox1.SelectedIndex = 0


        SearchGuardianNameListing()

        Return Nothing
    End Function
    'When cell is clicked query and populate Gridview3 with parent data  
    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim GuardianProfile As IEntireUserProfileSearch = New SearchUserProfile
        Dim GuardianProfileListing As List(Of GuardianProfileCollection) = New List(Of GuardianProfileCollection)
        Dim convertName As INameConversion = New StudentNameConversion

        Dim studentId As String = String.Empty
        Dim firstName, lastName, fullName As String

        firstName = DataGridView1.CurrentRow.Cells(1).Value
        lastName = DataGridView1.CurrentRow.Cells(2).Value

        If lastName = String.Empty Or firstName = String.Empty Then
            Exit Sub
        End If

        fullName = lastName & ", " & firstName
        studentId = convertName.ConvertToId(fullName)
        GuardianProfileListing = GuardianProfile.GuardianSearch(studentId.Trim())
        DataGridView3.DataSource = GuardianProfileListing



    End Sub



    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        UpdateStudentInformation()
    End Sub

    'Place student data into respective controls in  EditStudentProfile.vb FORM
    Public Function UpdateStudentInformation()
        Dim firstName, lastName, fullName As String
        firstName = DataGridView1.CurrentRow.Cells(1).Value
        lastName = DataGridView1.CurrentRow.Cells(2).Value


        If lastName = String.Empty Or firstName = String.Empty Then
            Return Nothing
        End If

        fullName = lastName & ", " & firstName
        Dim Editstudent As New EditStudentProfile(fullName)
        Call Editstudent.Show()
        Return Nothing
    End Function


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        NewStudent.Show()
    End Sub

    'Search for the student within the search filter.
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim StudentAttribute As IEntireStudentProfileSearch = New SearchStudentUsingAttributes
        Dim StudentName As INameConversion = New StudentNameConversion
        Dim StudentProfileCollection As IList(Of StudentProfileCollection) = Nothing
        Dim studentFullname, studentID As String
        Dim ParseOutAprostopheCharacterFromStudentsName As New NameOperation

        ComboBox1.Focus()
        studentFullname = ComboBox1.SelectedText 'Capture Student Full Name




        If studentFullname <> [String].Empty Then
            studentID = StudentName.ConvertToId(studentFullname.Trim())
            If studentID <> "" Then
                StudentProfileCollection = SearchStudentUserProfile.SearchStudentProfileTable(studentID, AddressOf StudentAttribute.StudentIDNumber)
                DataGridView1.DataSource = StudentProfileCollection
                DataGridView1.Columns(0).Visible = False 'Hide Student ID column in the Datagrid
            Else
                MessageBox.Show("Student Could Not Be Found.")
            End If
        Else
            ResetDisplay()
        End If
    End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        NewGuradian.Show()
    End Sub



    'Display Guardians
    Private Sub DataGridView2_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick

        Dim StudentProfile As IEntireUserProfileSearch = New SearchUserProfile
        Dim convertName As INameConversion = New GuardianNameConversion
        Dim StudentProfileListing As IList(Of StudentProfileCollection)

        Dim studentId As String = String.Empty
        Dim firstName, LastName, fullName As String
        LastName = DataGridView2.CurrentRow.Cells(1).Value
        firstName = DataGridView2.CurrentRow.Cells(2).Value
        fullName = LastName & ", " & firstName
        guardianId = convertName.ConvertToId(fullName.Trim)
        StudentProfileListing = StudentProfile.StudentSearch(guardianId.Trim())
        DataGridView3.DataSource = StudentProfileListing
        DataGridView3.Columns(0).Visible = False

    End Sub

    Private Sub DataGridView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.DoubleClick
        OpenEditGuardianProfileFormAndPopulateitWithGuardianAttributes()
    End Sub

    'Place guardian information into the respective controls within the  EditGuardianProfile.vb FORM
    Public Function OpenEditGuardianProfileFormAndPopulateitWithGuardianAttributes()
        EditGuardianProfile.Show()
        Dim parseApostrophe As New NameOperation
        Dim guardianinfo As New ReturnGuardianInfo
        Dim Guardianid As String = String.Empty
        Dim Lastname As String = String.Empty
        Dim Firstname As String = String.Empty
        Dim Guardiantype As String = String.Empty
        Dim Email As String = String.Empty
        Dim AltEmail As String = String.Empty
        Dim Address As String = String.Empty
        Dim city As String = String.Empty
        Dim state As String = String.Empty
        Dim Zip As String = String.Empty
        Dim HMPhone As String = String.Empty
        Dim CellPhone As String = String.Empty
        Dim WKPhone As String = String.Empty
        Dim Fax As String = String.Empty
        Dim OtherPhone As String = String.Empty

        guardianLastName = DataGridView2.CurrentRow.Cells(1).Value().ToString
        guardianFirstName = DataGridView2.CurrentRow.Cells(2).Value().ToString
        Guardianid = guardianinfo.ReturnGuardianinfo(guardianFirstName.Trim, guardianLastName.Trim)
        guardianFirstName = parseApostrophe.ExecuteName(guardianFirstName, 2)
        guardianLastName = parseApostrophe.ExecuteName(guardianLastName, 2)
        Guardiantype = DataGridView2.CurrentRow.Cells(3).Value()
        Email = DataGridView2.CurrentRow.Cells(4).Value.ToString
        AltEmail = DataGridView2.CurrentRow.Cells(5).Value.ToString
        Address = DataGridView2.CurrentRow.Cells(6).Value.ToString
        city = DataGridView2.CurrentRow.Cells(7).Value.ToString

        state = DataGridView2.CurrentRow.Cells(8).Value.ToString

        Zip = DataGridView2.CurrentRow.Cells(9).Value.ToString
        HMPhone = DataGridView2.CurrentRow.Cells(10).Value.ToString
        CellPhone = DataGridView2.CurrentRow.Cells(11).Value.ToString
        WKPhone = DataGridView2.CurrentRow.Cells(12).Value.ToString
        Fax = DataGridView2.CurrentRow.Cells(13).Value.ToString

        Address = parseApostrophe.ExecuteName(Address, 2)
        city = parseApostrophe.ExecuteName(city, 2)
        Email = parseApostrophe.ExecuteName(Email, 2)
        AltEmail = parseApostrophe.ExecuteName(AltEmail, 2)

        EditGuardianProfile.TextBox2.Text = guardianLastName.Trim
        EditGuardianProfile.TextBox1.Text = guardianFirstName.Trim
        EditGuardianProfile.ComboBox1.SelectedItem = Guardiantype
        EditGuardianProfile.TextBox3.Text = Address
        EditGuardianProfile.TextBox4.Text = city
        EditGuardianProfile.TextBox5.Text = Email.Trim
        EditGuardianProfile.TextBox6.Text = AltEmail.Trim

        EditGuardianProfile.ComboBox2.SelectedItem = state

        EditGuardianProfile.MaskedTextBox1.Text = Zip

        EditGuardianProfile.MaskedTextBox2.Text = HMPhone

        EditGuardianProfile.MaskedTextBox4.Text = CellPhone

        EditGuardianProfile.MaskedTextBox3.Text = WKPhone
        EditGuardianProfile.MaskedTextBox5.Text = Fax
        EditGuardianProfile.WebAccountSet(Email.Trim)


        EditGuardianProfile.Label15.Text = Guardianid.Trim
        Return Nothing
    End Function
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub



    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged

        If ComboBox3.SelectedIndex > 0 Then
            PopulateComboBoxSearchQueryResults()
        End If

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex > 0 Then
            Button4.Visible = False
            ComboBox2.Focus()
            ComboBox2.SelectedText = "" 'Clear out ComboBox

            DataGridView2.DataSource = Nothing
            ComboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            PopulateComboBoxSearchQueryResults()
        Else
            SearchGuardianNameListing()
        End If
    End Sub


    Public Sub PopulateComboBoxSearchQueryResults()

        Dim GuardianAttributes As IUserAttributeProfile = New SearchGuardianAttribute
        Dim LocateGuardianProfile As IGuardianEntireProfileSearch = New SearchGuardianUsingAttributes

        Dim captureCharacter As String = String.Empty
        Dim capturedindex As Integer = 0

        ComboBox2.Focus()

        captureCharacter = ComboBox2.SelectedText
        capturedindex = ComboBox3.SelectedIndex

        Dim phonenumber As IList(Of PhoneNumberCollection) = Nothing
        Dim lname As IList(Of UserNameCollection) = Nothing
        Dim fname As IList(Of UserNameCollection) = Nothing
        Dim email As IList(Of EmailCollection) = Nothing
        Dim address As IList(Of MailingAddressCollection) = Nothing
        Dim clGuardianProfile As IList(Of GuardianProfileCollection) = Nothing

        If capturedindex > 0 Then

            Select Case (capturedindex)
                Case 1

                    lname = GuardianAttributes.SearchLastName.LastName(captureCharacter.Trim())
                    ComboBox2.DataSource = lname
                    ComboBox2.ValueMember = "NameIndex"
                    ComboBox2.DisplayMember = "Name"

                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.LastName)
                    lname.Clear()

                    lname = Nothing

                Case 2

                    fname = GuardianAttributes.SearchFirstName.FirstName(captureCharacter.Trim())
                    ComboBox2.DataSource = fname
                    ComboBox2.ValueMember = "NameIndex"
                    ComboBox2.DisplayMember = "Name"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.FirstName)
                    fname.Clear()
                    fname = Nothing
                Case 3

                    phonenumber = GuardianAttributes.SearchHomePhone.HomePhoneNumber(captureCharacter.Trim())
                    ComboBox2.DataSource = phonenumber
                    ComboBox2.ValueMember = "PhoneIndex"
                    ComboBox2.DisplayMember = "PhoneNumber"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.HomePhone)
                    phonenumber.Clear()
                Case 4

                    phonenumber = GuardianAttributes.SearchCellPhone.CellPhoneNumber(captureCharacter.Trim())
                    ComboBox2.DataSource = phonenumber
                    ComboBox2.ValueMember = "PhoneIndex"
                    ComboBox2.DisplayMember = "PhoneNumber"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.CellPhone)
                    phonenumber.Clear()
                Case 5

                    phonenumber = GuardianAttributes.SearchWorkPhone.WorkPhoneNumber(captureCharacter.Trim())
                    ComboBox2.DataSource = phonenumber
                    ComboBox2.ValueMember = "PhoneIndex"
                    ComboBox2.DisplayMember = "PhoneNumber"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.WorkPhone)
                    phonenumber.Clear()
                Case 6

                    phonenumber = GuardianAttributes.SearchFaxNumber.FaxPhoneNumber(captureCharacter.Trim())
                    ComboBox2.DataSource = phonenumber
                    ComboBox2.ValueMember = "PhoneIndex"
                    ComboBox2.DisplayMember = "PhoneNumber"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.FirstName)
                    phonenumber.Clear()
                Case 7

                    email = GuardianAttributes.SearchEmail.EmailAddress(captureCharacter.Trim())
                    ComboBox2.DataSource = email
                    ComboBox2.ValueMember = "EmailIndex"
                    ComboBox2.DisplayMember = "Email"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.EmailAddress)
                    email.Clear()
                Case 8

                    alternateEmail = GuardianAttributes.SearchAlternateEmail.EmailAddress(captureCharacter.Trim())
                    ComboBox2.DataSource = alternateEmail
                    ComboBox2.ValueMember = "EmailIndex"
                    ComboBox2.DisplayMember = "Email"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.AlternateEmailAddress)

                Case 9

                    address = GuardianAttributes.SearchAddress.Address(captureCharacter.Trim())
                    ComboBox2.DataSource = address
                    ComboBox2.ValueMember = "AddressIndex"
                    ComboBox2.DisplayMember = "Street_Address"
                    clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.Address)
             
            End Select



            If ComboBox3.SelectedIndex > 0 Then
                ComboBox2.SelectedIndex = 0 'Position of captured character in  the collection
                ComboBox2.SelectionStart = ComboBox2.Text.Length + 1 'Mmove cursor to the last position
                DataGridView2.DataSource = clGuardianProfile
                DataGridView2.Columns(0).Visible = False
            End If

        End If


    End Sub



    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        DataGridView3.DataSource = Nothing
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim LocateGuardianProfile As IGuardianEntireProfileSearch = New SearchGuardianUsingAttributes
        Dim clGuardianProfile As IList(Of GuardianProfileCollection) = Nothing

        ComboBox2.AutoCompleteMode = AutoCompleteMode.Suggest
        ComboBox2.Focus()
        captureCharacter = ComboBox2.SelectedText
        clGuardianProfile = GuardianProfileData.CaptureGuardianData(captureCharacter.Trim(), AddressOf LocateGuardianProfile.FullName)
        DataGridView2.DataSource = clGuardianProfile
    End Sub

    Public Sub SearchGuardianNameListing()
        Button4.Visible = True
        GuardianNameList = GuardianNameListing.NameList()
        ComboBox2.DataSource = GuardianNameList
        ComboBox2.ValueMember = "FullName"
        ComboBox2.DisplayMember = "FullName"

        ComboBox2.SelectedIndex = 0
        ComboBox2.AutoCompleteMode = AutoCompleteMode.Suggest
        DataGridView2.DataSource = Nothing
    End Sub

 
End Class