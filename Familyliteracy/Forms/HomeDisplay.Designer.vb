<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeDisplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeDisplay))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddRemoveAppointmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClinicianManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentManagerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClinicianScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScheduleDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutFamilyLiteracySchedulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1906, 762)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Hours"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(12, 5)
        Me.MonthCalendar1.Margin = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1906, 28)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AddRemoveAppointmentToolStripMenuItem, Me.ClinicianManagerToolStripMenuItem, Me.StudentManagerToolStripMenuItem1, Me.TestingToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(258, 24)
        Me.ToolStripMenuItem1.Text = "Change Hour for Date"
        '
        'AddRemoveAppointmentToolStripMenuItem
        '
        Me.AddRemoveAppointmentToolStripMenuItem.Name = "AddRemoveAppointmentToolStripMenuItem"
        Me.AddRemoveAppointmentToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.AddRemoveAppointmentToolStripMenuItem.Text = "Add/Remove Appointment"
        '
        'ClinicianManagerToolStripMenuItem
        '
        Me.ClinicianManagerToolStripMenuItem.Name = "ClinicianManagerToolStripMenuItem"
        Me.ClinicianManagerToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.ClinicianManagerToolStripMenuItem.Text = "Clinician Profile Manager"
        '
        'StudentManagerToolStripMenuItem1
        '
        Me.StudentManagerToolStripMenuItem1.Name = "StudentManagerToolStripMenuItem1"
        Me.StudentManagerToolStripMenuItem1.Size = New System.Drawing.Size(258, 24)
        Me.StudentManagerToolStripMenuItem1.Text = "Student Profile Manager"
        '
        'TestingToolStripMenuItem
        '
        Me.TestingToolStripMenuItem.Name = "TestingToolStripMenuItem"
        Me.TestingToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.TestingToolStripMenuItem.Text = "Testing"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyScheduleToolStripMenuItem, Me.StudentScheduleToolStripMenuItem, Me.ClinicianScheduleToolStripMenuItem, Me.ScheduleDetailsToolStripMenuItem})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'DailyScheduleToolStripMenuItem
        '
        Me.DailyScheduleToolStripMenuItem.Name = "DailyScheduleToolStripMenuItem"
        Me.DailyScheduleToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.DailyScheduleToolStripMenuItem.Text = "Office Schedule"
        '
        'StudentScheduleToolStripMenuItem
        '
        Me.StudentScheduleToolStripMenuItem.Name = "StudentScheduleToolStripMenuItem"
        Me.StudentScheduleToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.StudentScheduleToolStripMenuItem.Text = "Student Schedule"
        '
        'ClinicianScheduleToolStripMenuItem
        '
        Me.ClinicianScheduleToolStripMenuItem.Name = "ClinicianScheduleToolStripMenuItem"
        Me.ClinicianScheduleToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.ClinicianScheduleToolStripMenuItem.Text = "Clinician Schedule"
        '
        'ScheduleDetailsToolStripMenuItem
        '
        Me.ScheduleDetailsToolStripMenuItem.Name = "ScheduleDetailsToolStripMenuItem"
        Me.ScheduleDetailsToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.ScheduleDetailsToolStripMenuItem.Text = "Schedule Details"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.CloseToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutFamilyLiteracySchedulerToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.AboutToolStripMenuItem.Text = "Help"
        '
        'AboutFamilyLiteracySchedulerToolStripMenuItem
        '
        Me.AboutFamilyLiteracySchedulerToolStripMenuItem.Name = "AboutFamilyLiteracySchedulerToolStripMenuItem"
        Me.AboutFamilyLiteracySchedulerToolStripMenuItem.Size = New System.Drawing.Size(290, 24)
        Me.AboutFamilyLiteracySchedulerToolStripMenuItem.Text = "About Family Literacy Scheduler"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(290, 24)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1906, 32)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.MaxLength = 3
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(39, 32)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.Familyliteracy.My.Resources.Resources.arrow_resize_135_icon
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(29, 29)
        Me.ToolStripButton4.Text = "Resize Display Columns"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 20)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 28)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Change Hour For Date"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Adjust Column Width (10 - 150px)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.MonthCalendar1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 822)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1906, 215)
        Me.Panel1.TabIndex = 17
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button13)
        Me.GroupBox6.Controls.Add(Me.Button14)
        Me.GroupBox6.Location = New System.Drawing.Point(1451, 13)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(249, 101)
        Me.GroupBox6.TabIndex = 28
        Me.GroupBox6.TabStop = False
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(24, 23)
        Me.Button13.Margin = New System.Windows.Forms.Padding(4)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(200, 28)
        Me.Button13.TabIndex = 26
        Me.Button13.Text = "Repeated Measures-CBM"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(24, 64)
        Me.Button14.Margin = New System.Windows.Forms.Padding(4)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(200, 28)
        Me.Button14.TabIndex = 27
        Me.Button14.Text = "Assessments"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button16)
        Me.GroupBox3.Controls.Add(Me.Button9)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Location = New System.Drawing.Point(384, 16)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(212, 173)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(21, 133)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(173, 31)
        Me.Button16.TabIndex = 4
        Me.Button16.Text = "Reports"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(21, 89)
        Me.Button9.Margin = New System.Windows.Forms.Padding(4)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(173, 28)
        Me.Button9.TabIndex = 2
        Me.Button9.Text = "Clinician Schedule"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(21, 53)
        Me.Button8.Margin = New System.Windows.Forms.Padding(4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(173, 28)
        Me.Button8.TabIndex = 1
        Me.Button8.Text = "Student Schedule"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(21, 17)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(173, 28)
        Me.Button7.TabIndex = 0
        Me.Button7.Text = "Office Schedule"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Location = New System.Drawing.Point(652, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(781, 204)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(284, 128)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Add / Edit A Clinician"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(600, 46)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(173, 28)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "Student Profile Manager"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(100, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 17)
        Me.Label4.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Operator:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button6)
        Me.GroupBox4.Location = New System.Drawing.Point(263, 142)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(215, 55)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(15, 19)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(192, 28)
        Me.Button6.TabIndex = 23
        Me.Button6.Text = "Clinician Profile Manager"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 108)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(221, 89)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(20, 53)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 28)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Add/Remove Appoint."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(263, 76)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 28)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Add a Student"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button12)
        Me.GroupBox2.Controls.Add(Me.Button11)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 46)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(221, 62)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(124, 18)
        Me.Button12.Margin = New System.Windows.Forms.Padding(4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(89, 28)
        Me.Button12.TabIndex = 1
        Me.Button12.Text = "Log- Out"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(8, 18)
        Me.Button11.Margin = New System.Windows.Forms.Padding(4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(88, 28)
        Me.Button11.TabIndex = 0
        Me.Button11.Text = "Login"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(331, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 24)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Add / Edit a Student "
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(263, 46)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(316, 24)
        Me.ComboBox1.TabIndex = 20
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(452, 79)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 28)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Edit a Student"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1906, 762)
        Me.Panel2.TabIndex = 18
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1800000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(694, 36)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(436, 24)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Maximum 8 pre hour  + Front + Testing Room"
        '
        'HomeDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1906, 1037)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "HomeDisplay"
        Me.Text = "Scheduler 2012"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClinicianManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StudentManagerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AddRemoveAppointmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClinicianScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScheduleDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TestingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutFamilyLiteracySchedulerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
