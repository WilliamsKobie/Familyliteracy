Imports System
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security

Imports BAL
Imports DAL
Imports System.Net.Mail
Imports System.Net

Public Class EditStudentProfile
    Dim noteid As Integer
    Dim newnote As Boolean = False

    Public Sub New(ByVal studentfullname As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PopulateForm(studentfullname)

    End Sub
    Public Sub PopulateGuradianCombobox()
        ComboBox6.DataSource = Nothing
        ComboBox2.Items.Clear()
        Dim EntireGuardianNameList As List(Of GuardianNames) = New List(Of GuardianNames)()
        EntireGuardianNameList = GuardianNameListing.NameList()

        ComboBox6.DataSource = EntireGuardianNameList
        ComboBox6.DisplayMember = "FullName"
        ComboBox6.ValueMember = "FullName"
    End Sub

    Public Sub PopulateForm(ByVal studentfullname As String)
        ComboBox5.Enabled = True
        PopulateTestTypeComboBox()

        Dim studentId As String = String.Empty

        Dim splitName As String() = Nothing



        Dim parseApostrophe As New NameOperation

        Dim convertstudentname As INameConversion = New StudentNameConversion
        Dim studentData As IstudentAttributesCollection = New userAttributesCollection
        PopulateGuradianCombobox()


        studentId = convertstudentname.ConvertToId(studentfullname)
        Dim studentCollection As New ArrayList

        splitName = studentfullname.Split(", ")
        studentLastname = splitName(0)
        studentFirstname = splitName(1)


        studentId = convertstudentname.ConvertToId(studentfullname.Trim)
        studentFirstname = parseApostrophe.ExecuteName(studentFirstname, 2)
        studentLastname = parseApostrophe.ExecuteName(studentLastname, 2)
        Label29.Text = studentId

        Dim dbContext As New FamilyLiteracyEntityDataModel
        Dim studentLvl = (From p In dbContext.StudentCurrentReadingLevels
       Where (p.StudentId = studentId.Trim())
        Select p Order By p.Date Descending).Take(1).FirstOrDefault
        If Not studentLvl Is Nothing Then
            Dim readingLevel = studentLvl.Reading_Level
            ComboBox5.SelectedItem = readingLevel.Trim()
        End If
        Dim SchoolDistrict As String = String.Empty
        Dim School As String = String.Empty
        Dim AssessmentDate As String = String.Empty
        Dim RptDiscussiondate As String = String.Empty
        Dim InitialInquiry As String = String.Empty
        Dim TutorStart As String = String.Empty
        Dim tutorStop As String = String.Empty
        Dim DOB As String

        Dim convertname As New Schedule

        Dim web As String = String.Empty
        Dim activeStudent As String = String.Empty
        Dim dgvRow As New DataGridViewRow


        studentCollection = studentData.StudentInfo(studentId)
        DOB = studentCollection(2)
        Dim Gender As String = studentCollection(3)
        InitialInquiry = studentCollection(6)
        AssessmentDate = studentCollection(7)
        RptDiscussiondate = studentCollection(8)
        TutorStart = studentCollection(9)
        tutorStop = studentCollection(10)
        SchoolDistrict = studentCollection(4)
        School = studentCollection(5)
        activeStudent = studentCollection(11)

        School = parseApostrophe.ExecuteName(School, 2)
        SchoolDistrict = parseApostrophe.ExecuteName(SchoolDistrict, 2)
        'Appends a 0 to the beginning of the date if it is missing
        Dim iilength As Integer = 0
        iilength = InitialInquiry.Length
        If iilength = 9 Then
            InitialInquiry = "0" & InitialInquiry
        End If

        Me.TextBox3.Text = SchoolDistrict.Trim
        Me.TextBox4.Text = School.Trim
        Me.ComboBox1.SelectedItem = Gender.Trim
        Me.TextBox1.Text = studentFirstname.Trim
        Me.TextBox2.Text = studentLastname.Trim

        Me.MaskedTextBox1.Text = DOB.Trim

        Me.MaskedTextBox2.Text = InitialInquiry
        Me.MaskedTextBox3.Text = AssessmentDate.Trim

        Me.MaskedTextBox4.Text = RptDiscussiondate.Trim

        Me.MaskedTextBox5.Text = TutorStart.Trim

        Me.MaskedTextBox6.Text = tutorStop.Trim





        If activeStudent = "True" Then
            Me.CheckBox1.Checked = True
        ElseIf activeStudent = "False" Then
            Me.CheckBox1.Checked = False
        End If

        If Gender.Trim = "Male" Then
            Me.ComboBox1.SelectedIndex = 0
        Else
            Me.ComboBox1.SelectedIndex = 1
        End If

        Me.Label29.Text = studentId.Trim

        Dim studentInfo As IstudentAttributesDatasets = New userProfileAttributes
        Dim schooltype As Boolean
        Dim dt As DataTable
        dt = studentInfo.RetrieveStudentSchool(studentId.Trim)
        Dim row As DataRow
        For Each row In dt.Rows
            schooltype = row("Prv_Pub")
        Next




        Dim db As New FamilyLiteracyEntityDataModel
        Dim currentreadinglevel = Nothing
        currentreadinglevel = (From p In db.StudentCurrentReadingLevels
                                  Where p.StudentId = studentId
                                  Order By p.Date Descending
                                  Select p).Take(1).FirstOrDefault



        If Not IsNothing(currentreadinglevel) = Nothing Then
            Me.DateTimePicker2.Text = DateTime.Today
            Me.MaskedTextBox13.Text = "0"
        Else
            Me.DateTimePicker2.Text = currentreadinglevel.Date
            Me.ComboBox5.SelectedText = currentreadinglevel.Reading_Level
            Me.MaskedTextBox13.Text = currentreadinglevel.Hour_Number
        End If




        Me.TextBox3.Visible = True
        Me.ComboBox2.Visible = False
        Me.TextBox3.Text = SchoolDistrict.Trim
        Me.RadioButton1.Checked = True
        Me.RadioButton2.Checked = False
        Me.Label7.Text = "School District"
        Me.TextBox4.Text = School.Trim
        Dim dv As New DataView
        dv = studentInfo.RetrieveNotes(studentId.Trim)
        Me.DataGridView1.DataSource = dv
        Me.DataGridView1.Columns(0).Visible = False
        Me.DataGridView1.Columns(1).Visible = False
        Me.DataGridView1.Columns(3).Width = 150
        Me.DataGridView1.Columns(4).Width = 400
        Me.TextBox5.ReadOnly = True
        Me.TextBox6.ReadOnly = True
        Me.DateTimePicker2.Format = DateTimePickerFormat.Custom
        Me.DateTimePicker2.CustomFormat = "MM/dd/yyyy"
        Me.MaskedTextBox13.Enabled = False
        Me.ComboBox5.Enabled = False


    End Sub

    Public Sub PopulateTestTypeComboBox()
        ComboBox5.Items.Add("Level PA")
        ComboBox5.Items.Add("Level BR")

        ComboBox5.Items.Add("Level 0")
        ComboBox5.Items.Add("Level 1")
        ComboBox5.Items.Add("Level 2")

        ComboBox5.Items.Add("Level 3")
        ComboBox5.Items.Add("Level 4")
        ComboBox5.Items.Add("Level 5")

        ComboBox5.Items.Add("Level A100")
        ComboBox5.Items.Add("Level A200")

        ComboBox5.Items.Add("Level A300")

        ComboBox5.Items.Add("Level B100")
        ComboBox5.Items.Add("Level B200")

        ComboBox5.Items.Add("Level B300")
        ComboBox5.Items.Add("Level BC400")
        ComboBox5.Items.Add("Level BC500")

        ComboBox5.Items.Add("Level BC600")

        ComboBox5.Items.Add("Level C700")
        ComboBox5.Items.Add("Level C800")
        ComboBox5.Items.Add("Level C900")
        ComboBox5.Items.Add("Text")
        ComboBox5.Items.Add("Level W")
    End Sub
    Private Sub EditClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Visible = False
        Button3.Visible = True
        Button4.Visible = True
        Button6.Visible = False
        Button5.Visible = True
        Button9.Visible = True
        Button7.Visible = False
        ' Dim studentID As String = Label29.Text
        WebAccountSet()

        ' Set the Format type and the CustomFormat string.
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MM/dd/yyyy"


        MaskedTextBox13.Enabled = False

        ' ComboBox5.SelectedText = readingLevel
        ComboBox5.Enabled = False

        Dim studentid As String = String.Empty
        studentid = Me.Label29.Text
        Me.DisplayGuardians(studentid.Trim())
    End Sub




    'Validate the presence of the first and last name
    Public Function ErrorValidator() As Boolean
        Dim CatchError As Boolean = False



        If TextBox1.Text = [String].Empty Then
            ErrorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider2.SetIconAlignment(TextBox1, ErrorIconAlignment.TopRight)
            ErrorProvider2.SetError(TextBox1, "You must give a First Name")
            CatchError = True
        Else
            ErrorProvider2.Dispose()
        End If

        If TextBox2.Text = [String].Empty Then
            ErrorProvider3.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider3.SetIconAlignment(TextBox2, ErrorIconAlignment.TopRight)
            ErrorProvider3.SetError(TextBox2, "You must give a Last Name")
            CatchError = True
        Else
            ErrorProvider3.Dispose()
        End If


        Return CatchError
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim firstname = TextBox1.Text.Trim()
            Dim lastName = TextBox2.Text.Trim()
            Dim forbiddenSymbols() As String = {"?", "/", "\", "$", "#", "!", "<", ">", ";", ",", ":", "+", "=", "[", "]", "{", "}", "|", "%", "@", "^", """"}
            Dim symbols = (From p In forbiddenSymbols
                           Where firstname.Contains(p) Or lastName.Contains(p)
                          Select p).FirstOrDefault

            If Not symbols = Nothing Then
                MsgBox("Name must not contain symbols e.g. ? / \ < > # $ ; , : + = [  { }  ] | % @ ^ *")
                Exit Sub
            End If
            Dim errortrigger As Boolean = False
            errortrigger = ErrorValidator()
            If errortrigger = False Then
                EditStudent()
                EditGuardian()
                studentid = Label29.Text
                DisplayGuardians(studentid.trim())
                HomeDisplay.Reset()

                Me.Focus()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Dim code As Integer = ex.Message.GetHashCode
            If code = -1949105233 Then
                MsgBox("You have entered an incorrect date format!")

            End If

        End Try
    End Sub

    'Process student entries
    Public Function EditStudent()
        Dim editStudentProfile As IEditUser = New Users
        Dim editStudentAttribute As IUpdateStudentAttributes = New UserAttributes
        Dim findAttribute As IstudentAttributesDatasets = New userProfileAttributes
        Dim submitStudentAttribute As IpopulateUserAttributes = New populateUser
        Dim parseApostrophe As New NameOperation
        Dim Present As Boolean = Nothing
        Dim Studentid As String = [String].Empty
        Dim Firstname As String = [String].Empty
        Dim Lastname As String = [String].Empty
        Dim Dob As String = [String].Empty
        Dim Gender As String = [String].Empty
        Dim AssessmentDate As String = [String].Empty
        Dim Initialinquirydate As String = [String].Empty
        Dim SchoolDistrict As String = [String].Empty
        Dim School As String = [String].Empty
        Dim Rptdiscussion As String = [String].Empty
        Dim TutorStart As String = [String].Empty
        Dim Tutoringstop As String = [String].Empty
        Dim Active As Boolean = True
        Dim Studentfullname As String = [String].Empty
        Dim note As String = [String].Empty
        Dim noteheader As String = [String].Empty
        Dim web As Boolean = False
        Dim schooltype As Boolean
        Dim readingLevel As String = String.Empty

        Studentid = Label29.Text.Trim
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        Firstname = parseApostrophe.ExecuteName(Firstname.Trim, 3)
        Lastname = parseApostrophe.ExecuteName(Lastname.Trim, 3)

        SchoolDistrict = TextBox3.Text
        School = TextBox4.Text
        Dob = MaskedTextBox1.Text
        If TextBox3.Visible = True Then
            SchoolDistrict = TextBox3.Text
            schooltype = True
        ElseIf ComboBox2.Visible = True Then
            If ComboBox2.SelectedIndex > 0 Then
                SchoolDistrict = ComboBox2.SelectedItem
                schooltype = False
            End If
        End If
        Gender = ComboBox1.SelectedItem
        If Gender = String.Empty Then
            MsgBox("You must choose a gender for this student!")
            Return Nothing
            Exit Function
        End If
        Initialinquirydate = MaskedTextBox2.Text
        AssessmentDate = MaskedTextBox3.Text
        Rptdiscussion = MaskedTextBox4.Text
        TutorStart = MaskedTextBox5.Text
        Tutoringstop = MaskedTextBox6.Text
        note = TextBox6.Text.ToString
        noteheader = TextBox5.Text.ToString

        readingLevel = ComboBox5.SelectedItem

        School = parseApostrophe.ExecuteName(School, 3)
        SchoolDistrict = parseApostrophe.ExecuteName(SchoolDistrict, 3)
        noteheader = parseApostrophe.ExecuteName(noteheader, 3)
        note = parseApostrophe.ExecuteName(note, 3)

        Dim hour As Integer

        If MaskedTextBox13.Text = String.Empty Then
            MaskedTextBox13.Text = "0"
        End If
        hour = Convert.ToInt16(MaskedTextBox13.Text)
        If CheckBox1.Checked = True Then
            Active = True
        Else
            Active = False
        End If

        Dim recordHour As ISaveHour = New SaveHour
        editStudentProfile.EditStudent(Studentid.Trim, Lastname.Trim, Firstname.Trim, Dob, Gender.Trim, SchoolDistrict.Trim, School.Trim, Initialinquirydate, AssessmentDate, Rptdiscussion, TutorStart, Tutoringstop, Active, readingLevel)
        editStudentAttribute.editStudentSchool(Studentid.Trim, SchoolDistrict.Trim, School.Trim, schooltype)

        If Not readingLevel = String.Empty Then
            Dim db As New FamilyLiteracyEntityDataModel()
            Dim Recordedlevel = New StudentCurrentReadingLevel

            Recordedlevel.StudentId = Convert.ToInt32(Studentid)
            Recordedlevel.Date = DateTimePicker2.Value
            Recordedlevel.Reading_Level = readingLevel
            Recordedlevel.Hour_Number = hour
            db.StudentCurrentReadingLevels.Add(Recordedlevel)
            db.SaveChanges()
        End If


        Button3.Visible = True
        DateTimePicker1.Visible = False

        MsgBox("Changes have been saved for " & Firstname & " " & Lastname & ".")

        Return Nothing
    End Function
    'Process Guardian Entries
    Public Function EditGuardian()
        Dim guardianinfo As IEditUser = New Users
        Dim parseApostrophe As New NameOperation
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

        guardianid = Label31.Text.Trim
        Firstname = TextBox8.Text.ToString
        Lastname = TextBox9.Text.ToString
        Address = TextBox10.Text.ToString
        City = TextBox11.Text.ToString
        Guardiantype = Convert.ToString(ComboBox3.SelectedItem)
        If ComboBox4.SelectedItem = String.Empty Then
            MsgBox("You must select a U.S. state!")
            Return Nothing
            Exit Function
        Else
            state = ComboBox4.SelectedItem.ToString
        End If

        zipcode = MaskedTextBox7.Text.ToString
        HmPhone = MaskedTextBox8.Text
        WKPhone = MaskedTextBox9.Text
        CellPhone = MaskedTextBox10.Text
        Fax = MaskedTextBox11.Text

        email = TextBox12.Text
        altemail = TextBox13.Text
        If guardianid = [String].Empty Then
            MsgBox("Guardian does not exsist")
            Return Nothing
            Exit Function
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
        guardianinfo.EditGuardian(guardianid.Trim, Firstname.Trim, Lastname.Trim, addressWithoutApostrophe.Trim,
                                 cityWithoutApostrophe.Trim, state.Trim, zipcode.Trim, HmPhone.Trim, CellPhone.Trim, WKPhone.Trim, Fax.Trim,
                                  emailWithoutApostrophe.Trim, altemailWithoutApostrophe.Trim, Guardiantype.Trim)
        StudentManager.ResetDisplay()
        PopulateGuradianCombobox()
        Return Nothing
    End Function

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox2.Visible = False
        Label7.Visible = True
        Label7.Text = "School District"
        TextBox3.Visible = True
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox2.Visible = True
        Label7.Visible = True
        TextBox3.Visible = False
        Label7.Text = "Type of School"

        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False

        End If
    End Sub

    'Get information of the selected notes
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim noteheader As String = String.Empty
        Dim studentid As String = String.Empty
        Dim dateid As String = String.Empty
        Dim returnnotes As IstudentAttributesDatasets = New userProfileAttributes
        Dim parseApostrophe As New NameOperation
        Dim dv As DataView
        dateid = DataGridView1.CurrentRow.Cells(2).Value
        noteheader = DataGridView1.CurrentRow.Cells(3).Value
        studentid = Label29.Text
        TextBox5.ReadOnly = False
        TextBox6.ReadOnly = False
        dv = returnnotes.RetrieveNotes(studentid.Trim, dateid.Trim, noteheader.Trim)
        TextBox5.Text = [String].Empty
        TextBox6.Text = [String].Empty
        Dim parseNoteheader As String = String.Empty
        Dim parseNote As String = String.Empty
        parseNoteheader = parseApostrophe.ExecuteName(dv(0)(3).ToString, 2)
        parseNote = parseApostrophe.ExecuteName(dv(0)(4).ToString, 2)
        TextBox6.Text = parseNote
        TextBox5.Text = parseNoteheader
        noteid = dv(0)(0)
        DateTimePicker1.Visible = False
        Button3.Visible = True
        newnote = False
        Dim initialinquiry As Date
        initialinquiry = DataGridView1.CurrentRow.Cells(2).Value
        MaskedTextBox2.Text = initialinquiry.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox6.Text = [String].Empty
        TextBox5.Text = [String].Empty
        TextBox5.ReadOnly = False
        TextBox6.ReadOnly = False
        Button3.Visible = False
        DateTimePicker1.Visible = True
        newnote = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        removenote()
    End Sub
    'Delete a particular Note
    Public Sub RemoveNote()
        Dim removenote As IUpdateStudentAttributes = New UserAttributes
        Dim studentid As String = String.Empty
        Dim initialinquiry As Date
        studentid = Label29.Text
        initialinquiry = DataGridView1.CurrentRow.Cells(2).Value
        removenote.DeleteNote(studentid.Trim, noteid)
        TextBox5.Text = [String].Empty
        TextBox6.Text = [String].Empty
        RefreshGridview(studentid)



        MaskedTextBox2.Text = initialinquiry.ToString("MM/dd/yyyy")
    End Sub
    'Return all notes and display them for a particular student.
    Public Sub RefreshGridview(ByVal studentid As String)
        Dim returnnotes As IstudentAttributesDatasets = New userProfileAttributes
        Dim dv As New DataView

        dv = returnnotes.RetrieveNotes(studentid.Trim)
        DataGridView1.DataSource = dv
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(3).Width = 300
        DataGridView1.Columns(4).Width = 200
    End Sub

    'Button used for adding a new guardian
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        ResetGuardianDisplay()
        Button6.Visible = True
        Button4.Visible = False
        Button5.Visible = False

        Button7.Visible = True
        Button9.Visible = True
    End Sub
    'Clear out all entries for the Guardian
    Public Sub ResetGuardianDisplay()
        TextBox10.Text = String.Empty
        TextBox11.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox12.Text = String.Empty
        TextBox13.Text = String.Empty
        MaskedTextBox10.Text = String.Empty
        MaskedTextBox11.Text = String.Empty
        MaskedTextBox8.Text = String.Empty
        MaskedTextBox9.Text = String.Empty
        MaskedTextBox7.Text = String.Empty
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedItem = "TX"
        Label31.Text = String.Empty

    End Sub
    'clear out the textboxes for the guardian first and last name, and guardian identification number
    Public Sub CloneGuardianDisplay()
        TextBox8.Text = String.Empty
        TextBox13.Text = String.Empty
        Label31.Text = String.Empty
    End Sub

    'Hide uneccessary columns
    Public Function DisplayGuardians(ByVal studentNo As String)
        Dim parseName As New NameOperation
        Dim returnStudentId As INameConversion = New StudentNameConversion
        Dim GuardianName As IlinkedUsersProfileOutput = New findUserLink



        Dim studentdata As DataTable


        studentdata = GuardianName.parentLink(studentNo)
        DataGridView2.DataSource = studentdata

        DataGridView2.Columns(1).Visible = False
        DataGridView2.Columns(2).Visible = False
        DataGridView2.Columns(3).Visible = False
        DataGridView2.Columns(4).Visible = False
        DataGridView2.Columns(5).Visible = False
        DataGridView2.Columns(6).Visible = False
        DataGridView2.Columns(7).Visible = False
        DataGridView2.Columns(8).Visible = False
        DataGridView2.Columns(9).Visible = False
        DataGridView2.Columns(10).Visible = False
        DataGridView2.Columns(11).Visible = False
        DataGridView2.Columns(12).Visible = False
        DataGridView2.Columns(13).Visible = False
        DataGridView2.Columns(15).Visible = False
        DataGridView2.Columns(16).Visible = False

        DataGridView2.Columns(14).Width = 170
        Button4.Visible = True
        Button6.Visible = False
        Button5.Visible = True
        Button7.Visible = False
        Button9.Visible = True
        PopulateGuardianAttributes()
        Return Nothing
    End Function


    'Save edited guardian information
    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        EditGuardian()
        Dim studentNo As String = Label29.Text
        DisplayGuardians(studentNo.Trim())

    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        PopulateGuardianAttributes()
    End Sub
    'Copy values from the cells within the guardian Gridview display and place the values in their respective controls
    Public Function PopulateGuardianAttributes()
        Dim splitnameUser() As String
        Dim userid As String = String.Empty
        Dim findguardianid As INameConversion = New GuardianNameConversion
        Dim guardianId As String = String.Empty
        Dim userName As String = String.Empty
        Dim Firstname As String = String.Empty
        Dim Lastname As String = String.Empty
        Dim address As String = String.Empty
        Dim city As String = String.Empty
        Dim state As String = String.Empty
        Dim zip As String = String.Empty
        Dim cellphone As String = String.Empty
        Dim workphone As String = String.Empty
        Dim homePhone As String = String.Empty
        Dim faxNumber As String = String.Empty
        Dim email As String = String.Empty
        Dim altEmail As String = String.Empty
        Dim guardianType As String = String.Empty
        Try

            Name = DataGridView2.CurrentRow.Cells(14).Value.ToString

            guardianId = findguardianid.ConvertToId(Name)
            Label31.Text = guardianId
            guardianType = DataGridView2.CurrentRow.Cells(17).Value.ToString
            email = DataGridView2.CurrentRow.Cells(18).Value.ToString

            altEmail = DataGridView2.CurrentRow.Cells(19).Value.ToString
            address = DataGridView2.CurrentRow.Cells(20).Value.ToString
            city = DataGridView2.CurrentRow.Cells(21).Value.ToString
            state = DataGridView2.CurrentRow.Cells(22).Value.ToString
            zip = DataGridView2.CurrentRow.Cells(23).Value.ToString
            cellphone = DataGridView2.CurrentRow.Cells(25).Value.ToString
            workphone = DataGridView2.CurrentRow.Cells(26).Value.ToString
            homePhone = DataGridView2.CurrentRow.Cells(24).Value.ToString
            faxNumber = DataGridView2.CurrentRow.Cells(27).Value.ToString
            'Break the full name into its first and last name.
            If Name <> String.Empty Then
                splitnameUser = Name.Split(",")
                Lastname = splitnameUser(0).Trim
                Firstname = splitnameUser(1).Trim
            End If
            TextBox8.Text = Firstname
            TextBox9.Text = Lastname
            ComboBox3.SelectedItem = guardianType.Trim()
            TextBox10.Text = address
            TextBox11.Text = city
            ComboBox4.SelectedItem = state.Trim()
            MaskedTextBox7.Text = zip
            MaskedTextBox10.Text = cellphone
            MaskedTextBox9.Text = workphone
            MaskedTextBox8.Text = homePhone
            MaskedTextBox11.Text = faxNumber
            TextBox12.Text = email
            TextBox13.Text = altEmail
            DataGridView2.ClearSelection()

            'Search to se if user exsist

        Catch ax As Exception
        End Try
        Button4.Visible = True
        Button6.Visible = False
        Button5.Visible = True
        Return Nothing
    End Function
    'Button used to add a new parent to the student
    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        saved = AddNewParent()
        If saved = True Then
            Dim studentNo As String = Label29.Text
            DisplayGuardians(studentNo.Trim())
            PopulateGuradianCombobox()

        End If
    End Sub

    'Add a new parent to the datasource.
    'Also, check to see if the guardian being saved already exist within the datasource.
    Public Function AddNewParent()
        Dim ParseApostrophe As New NameOperation
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
        'Make their is either a first or last name within their textboxes.
        If TextBox1.Text = String.Empty Or TextBox2.Text = String.Empty Then
            MsgBox("Student name must be present in order to add a new parent!")
            Return False
            Exit Function
        End If
        Guardianid = getid.GenerateIdNumber 'generates a new guardian Identification number
        Firstname = TextBox8.Text
        Lastname = TextBox9.Text
        Address = TextBox10.Text
        City = TextBox11.Text
        Guardian = ComboBox3.SelectedItem.ToString

        state = ComboBox4.SelectedItem.ToString

        ZipCode = MaskedTextBox7.Text
        HomePhone = MaskedTextBox8.Text
        workPhone = MaskedTextBox9.Text
        CellPhone = MaskedTextBox10.Text
        Fax = MaskedTextBox11.Text

        Email = TextBox12.Text
        AltEmail = TextBox13.Text
        Dim addressWithoutApostrophe As String = String.Empty
        Dim cityWothoutApostrophe As String = String.Empty
        Dim emailWothoutApostrophe As String = String.Empty
        Dim altemailWothoutApostrophe As String = String.Empty
        Firstname = ParseApostrophe.ExecuteName(Firstname.Trim, 3)
        Lastname = ParseApostrophe.ExecuteName(Lastname.Trim, 3)
        Dim fullName As String = String.Empty
        Dim duplicate As Boolean = False
        fullName = Lastname & ", " & Firstname
        'Check to see if the guardian already exist
        duplicate = CheckforDuplicateGuardian(fullName)
        If duplicate = True Then
            If MsgBox("There is already a guardian who exist with this same name." & vbCrLf & "Would you still like to continue?", MsgBoxStyle.YesNo) = vbYes Then

            Else
                'Restore display to original look
                ResetGuardianDisplay()
                Button4.Visible = True
                Button6.Visible = False
                Button7.Visible = False
                Button5.Visible = True
                Button9.Visible = True
                PopulateGuradianCombobox()
                Return False
                Exit Function
            End If
        End If

        'Check for any apostrophes
        AddressWithoutApostrophe = ParseApostrophe.ExecuteName(Address, 3)
        cityWithoutApostrophe = ParseApostrophe.ExecuteName(City, 3)
        emailWithoutApostrophe = ParseApostrophe.ExecuteName(Email, 3)
        altemailWithoutApostrophe = ParseApostrophe.ExecuteName(AltEmail, 3)
        'Save guardian information
        Addguardian.SetupGuardian(Guardianid.Trim, Firstname.Trim, Lastname.Trim, AddressWithoutApostrophe.Trim,
                                   cityWithoutApostrophe.Trim, state.Trim, ZipCode.Trim, HomePhone.Trim, CellPhone.Trim, workPhone.Trim, Fax.Trim,
                                   OtherPhone.Trim, emailWithoutApostrophe.Trim, altemailWithoutApostrophe.Trim, Guardian.Trim)
        'Associate student with the guardian
        JoinStudentwithGuardian(Guardianid.Trim)
        Label35.Text = "Web Status: In-Active"
        Button4.Visible = True
        Button6.Visible = False
        Button7.Visible = False
        Button5.Visible = True
        Button9.Visible = True
        ResetGuardianDisplay()

        Return True
    End Function

    Public Function CheckforDuplicateGuardian(ByVal fullName As String) As Boolean
        'Check to see if a duplicate guardian exist with the same first and last name and email address
        Dim validateGuardian As INameConversion = New GuardianNameConversion
        Dim validateId As String = String.Empty

        validateId = validateGuardian.ConvertToId(fullName.Trim)
        If validateId = String.Empty Then
            Return 0
        Else
            Return 1
        End If
    End Function
    'Associate and save to the datasource the student with guardian 
    Public Function JoinStudentwithGuardian(ByVal guardianId As String)
        Dim parseName As New NameOperation

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

        duplicate = linkUsers.LinkGuardianToStudent(studentid.Trim, guardianId.Trim)

        If duplicate = True Then
            MessageBox.Show(studentfullname & " is already assigned", "Error")

        Else
            MessageBox.Show(studentfullname & " has been assigned")
        End If
        Return Nothing
    End Function
    'Cancel current operation by resetting the screen to its default look
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ResetGuardianDisplay()
        Button6.Visible = False
        Button4.Visible = True
        Button5.Visible = True
        Button9.Visible = True
        Button7.Visible = False
    End Sub
    'Save new note
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        SaveNote()
    End Sub
    'Save the new note
    'Each note header must be unique
    Public Function SaveNote()
        Dim editStudentProfile As IEditUser = New Users
        Dim editStudentAttribute As IUpdateStudentAttributes = New UserAttributes
        Dim findAttribute As IstudentAttributesDatasets = New userProfileAttributes
        Dim submitStudentAttribute As IpopulateUserAttributes = New populateUser
        Dim parseApostrophe As New NameOperation
        Dim Present As Boolean = Nothing
        Studentid = Label29.Text.Trim
        Firstname = TextBox1.Text
        Lastname = TextBox2.Text
        note = TextBox6.Text.ToString
        noteheader = TextBox5.Text.ToString
        Firstname = parseApostrophe.ExecuteName(Firstname.Trim, 3)
        Lastname = parseApostrophe.ExecuteName(Lastname.Trim, 3)
        If Lastname = String.Empty Or Firstname = String.Empty Then
            MsgBox("You must provide a first and last Name")
            Return Nothing
            Exit Function
        End If
        Initialinquirydate = MaskedTextBox2.Text
        If Initialinquirydate <> "  /  /" Then
            Present = findAttribute.CheckIfNoteExsist(Studentid.Trim, Initialinquirydate, noteheader)
        Else
            Present = False
        End If

        If Present = True And newnote = False Then
            If MsgBox(Firstname & " " & Lastname & " already has a note with the same header!" & vbCrLf & "Would you like to make any changes?", vbYesNo, MsgBoxStyle.Critical) = vbYes Then
                Present = editStudentAttribute.editNote(Studentid.Trim, noteid, noteheader, note, Convert.ToDateTime(Initialinquirydate))
                MsgBox(Firstname & " " & Lastname & " information has been Edited.")
            Else
                MsgBox("Information has not been edited.")
            End If
        Else
            If TextBox5.Text <> String.Empty Then
                Dim datenote As Date
                Dim tempdateholder As String
                tempdateholder = DateTimePicker1.Value.ToString("MM/dd/yyyy")

                datenote = Convert.ToDateTime(tempdateholder)
                submitStudentAttribute.AddNote(Studentid.Trim, datenote, noteheader.Trim, note.Trim)
                newnote = False
            End If
            MsgBox(Firstname & " " & Lastname & " information has been Edited.")
        End If
        Return Nothing
    End Function
    'Datagridview button used for removing the guardian
    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        If (e.ColumnIndex = DataGridView2.Columns(0).Index And e.RowIndex >= 0) Then
            If DataGridView2.CurrentRow.Cells(14).Value.ToString = String.Empty And e.RowIndex = 0 Then
            Else
                If MsgBox("You are about to remove " & DataGridView2.CurrentRow.Cells(14).Value.ToString & " as a guardian of " & TextBox1.Text & " " & TextBox2.Text & "." & vbCrLf & "Would you like to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    RemoveGuardianLink()
                End If



            End If

        ElseIf (e.ColumnIndex = DataGridView2.Columns(1).Index And e.RowIndex >= 0) Then

        End If
    End Sub
    'Delete the relationship between the student and guardian
    Public Function RemoveGuardianLink()
        Dim userLink As IterminateLink = New linkUsersTogether
        Dim convertGuardianNames As INameConversion = New GuardianNameConversion
        Dim convertStudentNames As INameConversion = New StudentNameConversion
        Dim studentId As String = String.Empty
        Dim guardianid As String = String.Empty
        Name = DataGridView2.CurrentRow.Cells(14).Value.ToString
        If Name <> String.Empty Then
            splitnameUser = Name.Split(",")
            Lastname = splitnameUser(0).Trim
            Firstname = splitnameUser(1).Trim

            guardianid = convertGuardianNames.ConvertToId(Name)
            studentId = Label29.Text.Trim

            userLink.DeleteLink(guardianid, studentId)

            DisplayGuardians(studentId.Trim())
        End If
        Return Nothing
    End Function
    'Setup the display for cloning a guardian
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        CloneGuardianDisplay()
        Button6.Visible = True
        Button4.Visible = False
        Button5.Visible = False
        Button9.Visible = False
        Button7.Visible = True
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click

        Dim password As String = TextBox14.Text
        Dim username = TextBox12.Text
        Dim ConfirmationMail As New MailMessage()
        Dim sFrom As String = "help@familyliteracy.net"
        Dim sTo As String = username
        sTo = sTo.Trim()
        ConfirmationMail.From = New MailAddress(sFrom)

        ConfirmationMail.To.Add(username.Trim())

        ConfirmationMail.Subject = "Family Literacy Network Password Confirmation"


        ConfirmationMail.Body = "Thank You for choosing Family Literacy Network" + "\n" +
            "Your username is: " + username + "\n" + "Your Password is: " + password + "\n" +
            "\n" + "Click here to login  http://familyliteracy.net/flnsite"


        Dim Client = New SmtpClient("smtp.1and1.com", 587)

        Client.Credentials = New NetworkCredential("help@familyliteracy.net", "famlithelp")
        Client.EnableSsl = False
        Client.Send(ConfirmationMail)








    End Sub
    Public Sub WebAccountSet()
        Dim username As String = TextBox12.Text
        Dim user As MembershipUser = Nothing
        If username <> String.Empty Then
            user = Membership.GetUser(username.Trim())
        End If


        If user Is Nothing Then

            Label35.Text = "Web Account: In-Active"
        Else

            Label35.Text = "Web Account: Active"
        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click

        Dim pass As String = TextBox14.Text.Trim()
        If pass.Length > 4 Then
            Dim username As String = String.Empty
            username = TextBox12.Text.Trim()
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

                WebAccountSet()
                MsgBox(TextBox8.Text.Trim() + " " + TextBox9.Text.Trim() + " web Account is now set.")
            Else
                MsgBox(TextBox8.Text.Trim() + " " + TextBox9.Text.Trim() + " already has an active web account.")
            End If
        Else
            MsgBox("Password must be at least 5 character long.")
        End If
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        username = TextBox12.Text.Trim()
        Membership.DeleteUser(username, True)
        MsgBox(TextBox8.Text.Trim() + " " + TextBox9.Text.Trim() + " no longer has a web account setup.")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        ComboBox5.Enabled = True
        MaskedTextBox13.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub


    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        Me.Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        Dim UserStudentId As INameConversion = New StudentNameConversion
        Dim UserGuardianId As INameConversion = New GuardianNameConversion

        Dim linkUsers As Ilink = New linkUsersTogether


        Dim studentid As String = String.Empty
        Dim guardianid As String = String.Empty
        Dim duplicate As Boolean
        Dim studentfullname As String = String.Empty
        Dim guardianfullname As String = String.Empty
        guardianfullname = ComboBox6.SelectedValue.ToString

        'Capture student identification number
        studentid = Label29.Text
        'Capture guardian identification numbe
        guardianid = UserGuardianId.ConvertToId(guardianfullname)

        duplicate = linkUsers.LinkGuardianToStudent(studentid.Trim, guardianid.Trim)
        If duplicate = True Then
            MessageBox.Show(studentfullname & " is already assigned", "Error")

        Else
            MessageBox.Show(studentfullname & " has been assigned")
        End If

        DisplayGuardians(studentid)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class



