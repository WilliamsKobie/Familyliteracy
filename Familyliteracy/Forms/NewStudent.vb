Imports DAL
Imports BAL
Imports System.Globalization
Imports System.Windows.Forms
Public Class NewStudent


    'Add a new student. Check to see if a name exist in the name fields
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim findStudentid As INameConversion = New StudentNameConversion
        Dim studentNo As String = String.Empty
        Dim firstname = TextBox1.Text.Trim()
        Dim lastName = TextBox2.Text.Trim()
        Dim fullName = lastName + ", " + firstname
        Dim forbiddenSymbols() As String = {"?", "/", "\", "$", "#", "!", "<", ">", ";", ",", ":", "+", "=", "[", "]", "{", "}", "|", "%", "@", "^", """"}
        Dim symbols = (From p In forbiddenSymbols
                       Where firstname.Contains(p) Or lastName.Contains(p)
                      Select p).FirstOrDefault

        If Not symbols = Nothing Then
            MsgBox("Name must not contain symbols e.g. ? / \ < > # $ ; , : + = [  { }  ] | % @ ^ """)
            Exit Sub
        End If
        studentNo = findStudentid.ConvertToId(fullName.Trim())
        If TextBox1.Text = String.Empty Or TextBox2.Text = String.Empty Then
            MsgBox("You must give a student name.")
        ElseIf studentNo <> String.Empty Then
            MsgBox("This student name already exist!" & vbCrLf & "You must come up with a different name, or modify it.")
        Else
            newStudent()

            HomeDisplay.Reset()

        End If
        Me.Focus()
    End Sub
    'Acquire Parameters for a new student
    'Validate the parameters
    'And store the values
    Public Sub NewStudent()
        Dim parseName As New nameOperation
        Dim dateFormat = "MM/dd/yyyy"
        Dim emptyDate As String = "  /  /"
        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim Present As Boolean = Nothing
        Dim ProcessStudentid As IUserIdNumbers = New GenerateStudentID
        Dim ProcessStudent As IAddNewUser = New Users

        Dim Studentid As String = [String].Empty
        Dim Firstname As String = [String].Empty
        Dim Lastname As String = [String].Empty
        Dim Dob As String = [String].Empty
        Dim Gender As String = [String].Empty

        Dim InitialInquiry As String = [String].Empty
        Dim SchoolDistrict As String = [String].Empty
        Dim School As String = [String].Empty


        Dim Active As Boolean
        Dim Act As String = "Enroll"
        Dim web As Boolean = False

        Studentid = ProcessStudentid.GenerateIdNumber
        Label27.Text = Studentid.Trim
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        Lastname = parseName.ExecuteName(Lastname.Trim, 3)
        Firstname = parseName.ExecuteName(Firstname.Trim, 3)
        SchoolDistrict = TextBox3.Text
        School = TextBox4.Text
        Dob = MaskedTextBox1.Text
        InitialInquiry = MaskedTextBox6.Text
        Gender = ComboBox1.SelectedItem
        If Gender = String.Empty Then
            MsgBox("You must choose a gender for this student!")
            Exit Sub
        End If



        If CheckBox1.Checked = True Then
            Active = True
        Else
            Active = False
        End If


        'Validate all dates. A blank date is permitted.
        Try
            If Dob <> emptyDate Then
                Date.ParseExact(Dob, dateFormat, provider)
            End If
            If InitialInquiry <> emptyDate Then
                Date.ParseExact(InitialInquiry, dateFormat, provider)
            End If


        Catch e As FormatException
            MsgBox("You entered an invalid date format!")
            Exit Sub
        End Try
        School = parseName.ExecuteName(School, 3)
        SchoolDistrict = parseName.ExecuteName(SchoolDistrict, 3)

        'Save parameters
        ProcessStudent.AddStudent(Studentid.Trim, Lastname.Trim, Firstname.Trim, Dob, Gender.Trim, SchoolDistrict.Trim, School.Trim, InitialInquiry, Active, True)


        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        GroupBox3.Visible = True
        Label29.Text = "Add a brand new student."
        StudentManager.ResetDisplay()
        UnLockGuardian()
        MsgBox(Firstname & " " & Lastname & " has been added")

    End Sub
    'Initialize all the controls on the Form
    Private Sub NewStudent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Visible = False
        Button3.Visible = False
        Button1.Visible = True
        Button4.Visible = False
        Label29.Text = "Save new student information"
        CheckBox1.Checked = True
        ComboBox1.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        LockGuardian()
    End Sub

    'Acquire First name and last name parameters for a new guardian
    'check to see if the guardian already exsist otherwise save the new guardian

    Public Function NewGuradian()

        'Check if guardian already exsist before saving.
        Dim DuplicateGuardian As New returnGuardianInfo
        Firstname = TextBox7.Text
        Lastname = TextBox8.Text
        Dim duplicate As Boolean = False
        duplicate = DuplicateGuardian.CheckForDuplicateguardian(Firstname.Trim, Lastname.Trim)




        If duplicate = True Then
            If MsgBox("There is already someone by the name of " & Firstname & " " & Lastname & " who already exsist." & vbCrLf & "Would you like to proceed by adding this person?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return Nothing
                Exit Function
            ElseIf MsgBoxResult.Yes Then
                SaveGuadian()
            End If
        Else
            SaveGuadian()
        End If

        StudentManager.ResetDisplay()


        Return Nothing
    End Function

    'Acquire all the guardian parameters from the controls on the FORM.
    'Join the new student with the guardian
    'Save them to the datasource
    Public Function SaveGuadian()
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
        Dim Getid As IUserIdNumbers = New GenerateGuardianID
        Dim Addguardian As IAddNewUser = New Users
        Guardianid = getid.GenerateIdNumber
        Label25.Text = Guardianid.Trim
        If Guardianid = String.Empty Then
            Return Nothing
            Exit Function
        End If
        Firstname = TextBox7.Text
        Lastname = TextBox8.Text
        Address = TextBox9.Text
        City = TextBox10.Text
        Guardian = ComboBox2.SelectedItem.ToString
        state = ComboBox3.SelectedItem.ToString
        ZipCode = MaskedTextBox2.Text.ToString
        HomePhone = MaskedTextBox4.Text
        workPhone = MaskedTextBox5.Text
        CellPhone = MaskedTextBox3.Text
        Fax = MaskedTextBox7.Text
        Email = TextBox11.Text
        AltEmail = TextBox12.Text

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
        joinStudentwithGuardian(Guardianid)

        Return Nothing
    End Function

    'Clear all entries related to the guardian
    Public Sub clearentries()

        'Clear out all the Entries


        TextBox5.Text = [String].Empty
        TextBox6.Text = [String].Empty
        MaskedTextBox1.Text = [String].Empty
        MaskedTextBox6.Text = [String].Empty
        TextBox10.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox11.Text = String.Empty
        TextBox12.Text = String.Empty
        MaskedTextBox2.Text = String.Empty
        MaskedTextBox3.Text = String.Empty
        MaskedTextBox4.Text = String.Empty
        MaskedTextBox5.Text = String.Empty
        MaskedTextBox7.Text = String.Empty
    End Sub

    'Clear all entries for the student
    Public Sub clearStudentEntries()
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        MaskedTextBox1.Text = String.Empty
        MaskedTextBox6.Text = String.Empty

    End Sub

    'Link the student to the new guardian
    Public Function joinStudentwithGuardian(ByVal guardianId As String)
        Dim parseName As New nameOperation

        Dim returnStudentId As INameConversion = New StudentNameConversion

        Dim linkUsers As Ilink = New linkUsersTogether
        Dim studentFirstName As String = String.Empty
        Dim studentLastName As String = String.Empty

        Dim studentid As String = String.Empty
        Dim dt As DataTable = Nothing
        Dim duplicate As Boolean
        Dim studentfullname As String = String.Empty
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        studentLastName = parseName.ExecuteName(Lastname.Trim, 3)
        studentFirstName = parseName.ExecuteName(Firstname.Trim, 3)
        studentfullname = studentLastName & ", " & studentFirstName

        studentid = returnStudentId.ConvertToId(studentfullname)
        'Join Student and Parent together
        linkUsers.linkGuardianToStudent(studentid.Trim, guardianId.Trim)

        DisplayGuardians()
        If duplicate = True Then
            MessageBox.Show(studentfullname.Trim & " is already assigned", "Error")

        Else
            MessageBox.Show(studentfullname.Trim & " has been assigned")
        End If
        Return Nothing
    End Function

    'Delete a Parent 
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If (e.ColumnIndex = DataGridView1.Columns(0).Index And e.RowIndex >= 0) Then
            If DataGridView1.CurrentRow.Cells(14).Value.ToString = String.Empty And e.RowIndex = 0 Then
            Else
                If MsgBox("You are about to disassociate " & TextBox1.Text & " " & TextBox2.Text & " from " & DataGridView1.CurrentRow.Cells(14).Value.ToString & vbCrLf & ". Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RemoveGuardianLink()
                End If

            End If

        End If
    End Sub

    'Sever the guradians link to the student
    Public Function RemoveGuardianLink()
        Dim userLink As IterminateLink = New linkUsersTogether
        Dim convertGuardianNames As INameConversion = New GuardianNameConversion
        Dim convertStudentNames As INameConversion = New StudentNameConversion
        Dim parseName As New nameOperation

        Dim studentId As String = String.Empty
        Dim guardianid As String = String.Empty
        Name = DataGridView1.CurrentRow.Cells(14).Value.ToString
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        Lastname = parseName.ExecuteName(Lastname.Trim, 3)
        Firstname = parseName.ExecuteName(Firstname.Trim, 3)
        studentfullname = Lastname & ", " & Firstname

        studentId = convertStudentNames.ConvertToId(studentfullname)
        If Name <> String.Empty Then
            splitnameUser = Name.Split(",")
            Lastname = splitnameUser(0).Trim
            Firstname = splitnameUser(1).Trim

            guardianid = convertGuardianNames.ConvertToId(Name)


            userLink.deleteLink(guardianid, studentId)
            DisplayGuardians()
        End If
        Return Nothing
    End Function

    'Setup guardian fields for adding a new guardian.
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click


        If TextBox7.Text = String.Empty Or TextBox8.Text = String.Empty Then
            MsgBox("You must give a guardian name.")
        Else
            UnLockGuardian()
            NewGuradian()

        End If

    End Sub

    'Display guardians into the datagrid associated to the current student 
    Public Function DisplayGuardians()

        Dim parseName As New nameOperation
        Dim returnStudentId As INameConversion = New StudentNameConversion
        Dim getguardianName As IlinkedUsersProfileOutput = New findUserLink
        CheckBox1.Checked = True
        If TextBox1.Text <> String.Empty Or TextBox2.Text <> String.Empty Then
            Firstname = TextBox1.Text
            Lastname = TextBox2.Text
            studentLastName = parseName.ExecuteName(Lastname.Trim, 3)
            studentFirstName = parseName.ExecuteName(Firstname.Trim, 3)
            studentfullname = studentLastName & ", " & studentFirstName

            studentid = returnStudentId.ConvertToId(studentfullname)
            Dim studentdata As DataTable


            studentdata = getguardianName.parentLink(studentid)
            DataGridView1.DataSource = studentdata

            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(8).Visible = False
            DataGridView1.Columns(9).Visible = False
            DataGridView1.Columns(10).Visible = False
            DataGridView1.Columns(11).Visible = False
            DataGridView1.Columns(12).Visible = False
            DataGridView1.Columns(13).Visible = False
            DataGridView1.Columns(15).Visible = False
            DataGridView1.Columns(16).Visible = False
        End If
        Return Nothing
    End Function
    'Reset Student controls
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        clearentries()
        clearStudentEntries()
        Button1.Visible = True
        Button4.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Label29.Text = "Save new student information"
        LockGuardian()

    End Sub

    'Make all the fields related to the guardian as read-only
    Public Sub LockGuardian()
        TextBox7.ReadOnly = True
        TextBox7.BackColor = Color.LightGray
        TextBox8.ReadOnly = True
        TextBox8.BackColor = Color.LightGray
        TextBox9.ReadOnly = True
        TextBox9.BackColor = Color.LightGray
        TextBox10.ReadOnly = True
        TextBox10.BackColor = Color.LightGray
        TextBox11.ReadOnly = True
        TextBox11.BackColor = Color.LightGray
        TextBox12.ReadOnly = True
        TextBox12.BackColor = Color.LightGray
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox2.BackColor = Color.LightGray
        ComboBox3.BackColor = Color.LightGray
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        MaskedTextBox2.ReadOnly = True
        MaskedTextBox2.BackColor = Color.LightGray
        MaskedTextBox3.ReadOnly = True
        MaskedTextBox3.BackColor = Color.LightGray
        MaskedTextBox4.ReadOnly = True
        MaskedTextBox4.BackColor = Color.LightGray
        MaskedTextBox5.ReadOnly = True
        MaskedTextBox5.BackColor = Color.LightGray
        MaskedTextBox7.ReadOnly = True
        MaskedTextBox7.BackColor = Color.LightGray

    End Sub

    'Unlock guardian field entries
    Public Sub UnLockGuardian()
        TextBox7.ReadOnly = False
        TextBox7.BackColor = Color.White
        TextBox8.ReadOnly = False
        TextBox8.BackColor = Color.White
        TextBox9.ReadOnly = False
        TextBox9.BackColor = Color.White
        TextBox10.ReadOnly = False
        TextBox10.BackColor = Color.White
        TextBox11.ReadOnly = False
        TextBox11.BackColor = Color.White
        TextBox12.ReadOnly = False
        TextBox12.BackColor = Color.White
        MaskedTextBox2.ReadOnly = False
        MaskedTextBox2.BackColor = Color.White
        MaskedTextBox3.ReadOnly = False
        MaskedTextBox3.BackColor = Color.White
        MaskedTextBox4.ReadOnly = False
        MaskedTextBox4.BackColor = Color.White
        MaskedTextBox5.ReadOnly = False
        MaskedTextBox5.BackColor = Color.White
        MaskedTextBox7.ReadOnly = False
        MaskedTextBox7.BackColor = Color.White
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox2.BackColor = Color.White
        ComboBox3.BackColor = Color.White
        'Default selections
        ComboBox2.SelectedItem = "BioParent"
        ComboBox3.SelectedItem = "TX"

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox7.Text = String.Empty
        UnLockGuardian()
        TextBox12.Text = String.Empty
        TextBox11.Text = String.Empty
    End Sub

    'Store an initial note about the student.
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim processNote As IpopulateUserAttributes = New populateUser
        Dim parseName As New nameOperation
        Dim noteHeader As String = TextBox5.Text
        Dim note As String = TextBox6.Text
        Dim studentid = Label27.Text
        Dim firstname As String = String.Empty
        Dim lastname As String = String.Empty

        firstname = TextBox1.Text.Trim
        lastname = TextBox2.Text.Trim
        If firstname = String.Empty Or lastname = String.Empty Then
            MsgBox("There is no student Name")
            Exit Sub
        End If
        If note <> String.Empty Or noteHeader <> String.Empty Then

            noteHeader = parseName.ExecuteName(noteHeader, 3)
            note = parseName.ExecuteName(note, 3)
            processNote.AddNote(studentid, Now, noteHeader, note)
            MsgBox("Note has been saved.")
            TextBox5.Text = String.Empty
            TextBox6.Text = String.Empty
        End If

    End Sub
End Class