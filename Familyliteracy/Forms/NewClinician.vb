Imports BAL
Imports DAL
Imports System
Imports System.Linq
Public Class NewClinician

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim orderIdnumber As IIDnumbers = New GenerateClinicianPositionId
        Dim clinicianIdGen As IUserIdNumbers = New GenerateClinicianID
        Dim setupClinicians As IAddNewUser = New Users
        Dim parseApostrophe As New nameOperation
        Dim clinicianinfo As New ArrayList
        'Prepare Clinician Values to be stored into the Database table called Clinician Profile.
        Dim saved As Boolean = True
        Dim clinicianId As String = String.Empty
        Dim lastName As String = String.Empty
        Dim firstName As String = String.Empty
        Dim phone As String = String.Empty
        Dim cellphone As String = String.Empty
        Dim altphone As String = String.Empty
        Dim email As String = String.Empty
        Dim address As String = String.Empty
        Dim state As String = String.Empty
        Dim City As String = String.Empty
        Dim ZipCode As String = String.Empty
        Dim positionId As Integer
        'Generate a new id for the new clinician
        Clinicianid = ClinicianIdGen.GenerateIdNumber()

        lastName = TextBox2.Text
        firstName = TextBox1.Text
        phone = MaskedTextBox2.Text
        cellphone = MaskedTextBox3.Text
        altphone = MaskedTextBox4.Text
        email = TextBox10.Text
        address = TextBox3.Text
        City = TextBox4.Text
        state = ComboBox1.Text
        ZipCode = MaskedTextBox1.Text
        positionId = orderIdnumber.GenerateID
     
        Dim forbiddenSymbols() As String = {"?", "/", "\", "$", "#", "!", "<", ">", ";", ",", ":", "+", "=", "[", "]", "{", "}", "|", "%", "@", "^", "*", """"}
       
        Dim symbols = (From p In forbiddenSymbols
                      Where firstName.Contains(p) Or lastName.Contains(p)
                      Select p).FirstOrDefault

        If Not symbols = Nothing Then
            MsgBox("Name must not contain symbols e.g. ? / \ < > # $ ; , : + = [  { }  ] | % @ ^ *")
            Exit Sub
        End If

        Dim clinicianFullName As String = LastName.Trim & ", " & FirstName.Trim
        Dim addressWithoutApostrophe As String = String.Empty
        Dim cityWithoutApostrophe As String = String.Empty
        Dim emailWithoutApostrophe As String = String.Empty

        clinicianFullName = parseApostrophe.ExecuteName(clinicianFullName, 0)
        addressWithoutApostrophe = parseApostrophe.ExecuteName(address, 3)
        cityWithoutApostrophe = parseApostrophe.ExecuteName(City, 3)
        emailWithoutApostrophe = parseApostrophe.ExecuteName(email, 3)

        lastName = parseApostrophe.ExecuteName(lastName, 3)
        firstName = parseApostrophe.ExecuteName(firstName, 3)
        clinicianinfo.Add(clinicianId.Trim) 'ID
        Clinicianinfo.Add(LastName.Trim) 'Last Name
        Clinicianinfo.Add(FirstName.Trim) 'First Nmae
        clinicianinfo.Add(phone.Trim) 'Phone
        clinicianinfo.Add(cellphone.Trim) 'Cellular
        clinicianinfo.Add(altphone.Trim) 'Other phone
        clinicianinfo.Add(emailWithoutApostrophe.Trim) 'Email
        clinicianinfo.Add(addressWithoutApostrophe.Trim) 'Address
        clinicianinfo.Add(cityWithoutApostrophe.Trim) 'City
        clinicianinfo.Add(state.Trim) 'State
        clinicianinfo.Add(ZipCode.Trim) 'Zip


        If CheckBox1.Checked = True Then
            Clinicianinfo.Add("True") 'Active Status
        ElseIf CheckBox1.Checked = False Then
            Clinicianinfo.Add("False") 'Inactive Status
        End If

        If CheckBox2.Checked = True Then
            Clinicianinfo.Add("True") 'AutoSelect Status=ON
        ElseIf CheckBox2.Checked = False Then
            Clinicianinfo.Add("False") 'AutoSelect Status=OFF
        End If

        saved = setupClinicians.AddNewClinician(Clinicianinfo, positionId)
        Dim fullname As String
        If saved = True Then

            fullname = TextBox1.Text.Trim & " " & TextBox2.Text.Trim
            MsgBox(fullname & " has been added")
            ClinicianConsole.DisplayRefresh()
            Exit Sub
        ElseIf saved = False Then
            fullname = TextBox1.Text.Trim & " " & TextBox2.Text.Trim
            MsgBox(fullname & " could not be added!")
            Exit Sub
            End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub NewClinician_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "TX"
        CheckBox1.Checked = False
        CheckBox2.Checked = True
    End Sub
End Class