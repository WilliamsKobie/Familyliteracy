<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClinicianOff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClinicianOff))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Sunday = New System.Windows.Forms.CheckBox()
        Me.Monday = New System.Windows.Forms.CheckBox()
        Me.Tuesday = New System.Windows.Forms.CheckBox()
        Me.Wednesday = New System.Windows.Forms.CheckBox()
        Me.Thursday = New System.Windows.Forms.CheckBox()
        Me.Friday = New System.Windows.Forms.CheckBox()
        Me.Saturday = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(101, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 26)
        Me.ComboBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(361, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(60, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(242, 24)
        Me.DateTimePicker1.TabIndex = 2
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(363, 25)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(249, 24)
        Me.DateTimePicker2.TabIndex = 3
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM"})
        Me.ComboBox2.Location = New System.Drawing.Point(70, 22)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(83, 26)
        Me.ComboBox2.TabIndex = 4
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM"})
        Me.ComboBox3.Location = New System.Drawing.Point(219, 22)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(87, 26)
        Me.ComboBox3.TabIndex = 5
        '
        'Sunday
        '
        Me.Sunday.AutoSize = True
        Me.Sunday.Location = New System.Drawing.Point(476, 67)
        Me.Sunday.Name = "Sunday"
        Me.Sunday.Size = New System.Drawing.Size(45, 17)
        Me.Sunday.TabIndex = 6
        Me.Sunday.Text = "Sun"
        Me.Sunday.UseVisualStyleBackColor = True
        '
        'Monday
        '
        Me.Monday.AutoSize = True
        Me.Monday.Location = New System.Drawing.Point(112, 67)
        Me.Monday.Name = "Monday"
        Me.Monday.Size = New System.Drawing.Size(47, 17)
        Me.Monday.TabIndex = 7
        Me.Monday.Text = "Mon"
        Me.Monday.UseVisualStyleBackColor = True
        '
        'Tuesday
        '
        Me.Tuesday.AutoSize = True
        Me.Tuesday.Location = New System.Drawing.Point(172, 67)
        Me.Tuesday.Name = "Tuesday"
        Me.Tuesday.Size = New System.Drawing.Size(50, 17)
        Me.Tuesday.TabIndex = 8
        Me.Tuesday.Text = "Tues"
        Me.Tuesday.UseVisualStyleBackColor = True
        '
        'Wednesday
        '
        Me.Wednesday.AutoSize = True
        Me.Wednesday.Location = New System.Drawing.Point(237, 67)
        Me.Wednesday.Name = "Wednesday"
        Me.Wednesday.Size = New System.Drawing.Size(49, 17)
        Me.Wednesday.TabIndex = 9
        Me.Wednesday.Text = "Wed"
        Me.Wednesday.UseVisualStyleBackColor = True
        '
        'Thursday
        '
        Me.Thursday.AutoSize = True
        Me.Thursday.Location = New System.Drawing.Point(299, 67)
        Me.Thursday.Name = "Thursday"
        Me.Thursday.Size = New System.Drawing.Size(53, 17)
        Me.Thursday.TabIndex = 10
        Me.Thursday.Text = "Thurs"
        Me.Thursday.UseVisualStyleBackColor = True
        '
        'Friday
        '
        Me.Friday.AutoSize = True
        Me.Friday.Location = New System.Drawing.Point(369, 67)
        Me.Friday.Name = "Friday"
        Me.Friday.Size = New System.Drawing.Size(37, 17)
        Me.Friday.TabIndex = 11
        Me.Friday.Text = "Fri"
        Me.Friday.UseVisualStyleBackColor = True
        '
        'Saturday
        '
        Me.Saturday.AutoSize = True
        Me.Saturday.Location = New System.Drawing.Point(422, 67)
        Me.Saturday.Name = "Saturday"
        Me.Saturday.Size = New System.Drawing.Size(42, 17)
        Me.Saturday.TabIndex = 12
        Me.Saturday.Text = "Sat"
        Me.Saturday.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Saturday)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Friday)
        Me.GroupBox1.Controls.Add(Me.Wednesday)
        Me.GroupBox1.Controls.Add(Me.Thursday)
        Me.GroupBox1.Controls.Add(Me.Sunday)
        Me.GroupBox1.Controls.Add(Me.Monday)
        Me.GroupBox1.Controls.Add(Me.Tuesday)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 100)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(331, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 18)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "From"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ComboBox3)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 59)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Range"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(187, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "From"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(544, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 27)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "View Days Off"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1007, 857)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Close"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Location = New System.Drawing.Point(58, 81)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(480, 178)
        Me.DataGridView1.TabIndex = 18
        '
        'Column1
        '
        Me.Column1.HeaderText = "Remove"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Width = 70
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Location = New System.Drawing.Point(361, 44)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(257, 24)
        Me.DateTimePicker4.TabIndex = 20
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(58, 44)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(257, 24)
        Me.DateTimePicker3.TabIndex = 19
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(24, 37)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(511, 115)
        Me.DataGridView2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 18)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(337, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 18)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "To"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.DataGridView2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(696, 82)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(560, 201)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Student to be Rescheduled"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(24, 158)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(106, 30)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "Reschedule"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Clinician"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker4)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(35, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(655, 275)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Display the Days Clinician is Scheduled Out"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(544, 114)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 27)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "Remove"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(74, 90)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(482, 139)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 35)
        Me.Button7.TabIndex = 28
        Me.Button7.Text = "Close"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.Button7)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(35, 363)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(655, 187)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Schedule Clinician out"
        '
        'ClinicianOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1268, 576)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClinicianOff"
        Me.Text = "Clinician Off Days"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Sunday As System.Windows.Forms.CheckBox
    Friend WithEvents Monday As System.Windows.Forms.CheckBox
    Friend WithEvents Tuesday As System.Windows.Forms.CheckBox
    Friend WithEvents Wednesday As System.Windows.Forms.CheckBox
    Friend WithEvents Thursday As System.Windows.Forms.CheckBox
    Friend WithEvents Friday As System.Windows.Forms.CheckBox
    Friend WithEvents Saturday As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
