Imports System.Configuration

Public Class DatabaseConnectionSettings

    Private Sub DatabaseConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim configData As New ConnectionStringSettings
        configData = ConfigurationManager.ConnectionStrings("FamilyLiteracy")
        Dim conn As String = configData.ConnectionString()
        Dim parts As String() = conn.Split(New Char() {";"})

        Dim dataSourceIndex As Integer = parts(0).LastIndexOf("=")
        Dim server As String = parts(0).Substring(dataSourceIndex + 1)
        Dim userNameIndex As Integer = parts(3).LastIndexOf("=")
        Dim userName As String = parts(3).Substring(userNameIndex + 1)
        Dim passwordIndex As Integer = parts(4).LastIndexOf("=")
        Dim password As String = parts(4).Substring(passwordIndex + 1)
        TextBox1.Text = server
        TextBox2.Text = userName
        TextBox3.Text = password
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim server As String = TextBox1.Text
        Dim userId As String = TextBox2.Text
        Dim passWord As String = TextBox3.Text
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

       

       
        ConfigurationManager.RefreshSection("connectionStrings")
        Dim connSettings As ConnectionStringSettings = New ConnectionStringSettings("FamilyLiteracy",
        "Data Source=" & server & ";Integrated Security=SSPI;" & _
        "Initial Catalog=FamilyLiteracy.mdf;User ID=" & userId & ";Password=" & passWord & ";System.Data.SqlClient")

        'Get the connection strings section.
        Dim connSection As ConnectionStringsSection = config.ConnectionStrings
        config.AppSettings.Settings.Remove("FamilyLiteracy")
        config.Save(ConfigurationSaveMode.Modified)

        'Add the new element.
        connSection.ConnectionStrings.Add(connSettings)

        ' Save the configuration file.
        config.Save(ConfigurationSaveMode.Modified, True)

          
        '

        ConfigurationManager.RefreshSection("connectionStrings")

        MsgBox("Connection String has been set.")
    End Sub
End Class