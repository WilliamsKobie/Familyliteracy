<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsMenu
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ReportIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportStudentTestMenuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._FamilyLiteracy_mdfDataSet = New Familyliteracy._FamilyLiteracy_mdfDataSet()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.ReportIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTitleDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportScheduleMenuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._FamilyLiteracy_mdfDataSet1 = New Familyliteracy._FamilyLiteracy_mdfDataSet1()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.ReportClientProfileMenuBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me._FamilyLiteracy_mdfDataSet3 = New Familyliteracy._FamilyLiteracy_mdfDataSet3()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FamilyLiteracymdfDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportStudentTestMenuTableAdapter = New Familyliteracy._FamilyLiteracy_mdfDataSetTableAdapters.ReportStudentTestMenuTableAdapter()
        Me.ReportScheduleMenuTableAdapter = New Familyliteracy._FamilyLiteracy_mdfDataSet1TableAdapters.ReportScheduleMenuTableAdapter()
        Me.ReportClientProfileMenuBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportClientProfileMenuTableAdapter1 = New Familyliteracy._FamilyLiteracy_mdfDataSet3TableAdapters.ReportClientProfileMenuTableAdapter()
        Me.ReportIDDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportTitleDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportStudentTestMenuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._FamilyLiteracy_mdfDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportScheduleMenuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._FamilyLiteracy_mdfDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportClientProfileMenuBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._FamilyLiteracy_mdfDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilyLiteracymdfDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportClientProfileMenuBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(27, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(876, 403)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(867, 374)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Student Test Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportIDDataGridViewTextBoxColumn, Me.ReportTitleDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ReportStudentTestMenuBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(861, 368)
        Me.DataGridView1.TabIndex = 0
        '
        'ReportIDDataGridViewTextBoxColumn
        '
        Me.ReportIDDataGridViewTextBoxColumn.DataPropertyName = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn.HeaderText = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn.Name = "ReportIDDataGridViewTextBoxColumn"
        Me.ReportIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReportIDDataGridViewTextBoxColumn.Width = 65
        '
        'ReportTitleDataGridViewTextBoxColumn
        '
        Me.ReportTitleDataGridViewTextBoxColumn.DataPropertyName = "ReportTitle"
        Me.ReportTitleDataGridViewTextBoxColumn.HeaderText = "Report Title"
        Me.ReportTitleDataGridViewTextBoxColumn.Name = "ReportTitleDataGridViewTextBoxColumn"
        Me.ReportTitleDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReportTitleDataGridViewTextBoxColumn.Width = 535
        '
        'ReportStudentTestMenuBindingSource
        '
        Me.ReportStudentTestMenuBindingSource.DataMember = "ReportStudentTestMenu"
        Me.ReportStudentTestMenuBindingSource.DataSource = Me._FamilyLiteracy_mdfDataSet
        '
        '_FamilyLiteracy_mdfDataSet
        '
        Me._FamilyLiteracy_mdfDataSet.DataSetName = "_FamilyLiteracy_mdfDataSet"
        Me._FamilyLiteracy_mdfDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(867, 374)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Scheduling Info"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportIDDataGridViewTextBoxColumn1, Me.ReportTitleDataGridViewTextBoxColumn1})
        Me.DataGridView2.DataSource = Me.ReportScheduleMenuBindingSource
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(861, 368)
        Me.DataGridView2.TabIndex = 0
        '
        'ReportIDDataGridViewTextBoxColumn1
        '
        Me.ReportIDDataGridViewTextBoxColumn1.DataPropertyName = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn1.DividerWidth = 1
        Me.ReportIDDataGridViewTextBoxColumn1.HeaderText = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn1.Name = "ReportIDDataGridViewTextBoxColumn1"
        Me.ReportIDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.ReportIDDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ReportIDDataGridViewTextBoxColumn1.Width = 65
        '
        'ReportTitleDataGridViewTextBoxColumn1
        '
        Me.ReportTitleDataGridViewTextBoxColumn1.DataPropertyName = "ReportTitle"
        Me.ReportTitleDataGridViewTextBoxColumn1.HeaderText = "Report Title"
        Me.ReportTitleDataGridViewTextBoxColumn1.Name = "ReportTitleDataGridViewTextBoxColumn1"
        Me.ReportTitleDataGridViewTextBoxColumn1.ReadOnly = True
        Me.ReportTitleDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ReportTitleDataGridViewTextBoxColumn1.Width = 535
        '
        'ReportScheduleMenuBindingSource
        '
        Me.ReportScheduleMenuBindingSource.DataMember = "ReportScheduleMenu"
        Me.ReportScheduleMenuBindingSource.DataSource = Me._FamilyLiteracy_mdfDataSet1
        '
        '_FamilyLiteracy_mdfDataSet1
        '
        Me._FamilyLiteracy_mdfDataSet1.DataSetName = "_FamilyLiteracy_mdfDataSet1"
        Me._FamilyLiteracy_mdfDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DataGridView3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(868, 374)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Client Profile"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToOrderColumns = True
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportIDDataGridViewTextBoxColumn2, Me.ReportTitleDataGridViewTextBoxColumn2, Me.FormTitleDataGridViewTextBoxColumn})
        Me.DataGridView3.DataSource = Me.ReportClientProfileMenuBindingSource1
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowTemplate.Height = 24
        Me.DataGridView3.Size = New System.Drawing.Size(862, 368)
        Me.DataGridView3.TabIndex = 2
        '
        'ReportClientProfileMenuBindingSource1
        '
        Me.ReportClientProfileMenuBindingSource1.DataMember = "ReportClientProfileMenu"
        Me.ReportClientProfileMenuBindingSource1.DataSource = Me._FamilyLiteracy_mdfDataSet3
        '
        '_FamilyLiteracy_mdfDataSet3
        '
        Me._FamilyLiteracy_mdfDataSet3.DataSetName = "_FamilyLiteracy_mdfDataSet3"
        Me._FamilyLiteracy_mdfDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(922, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Run Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FamilyLiteracymdfDataSetBindingSource
        '
        Me.FamilyLiteracymdfDataSetBindingSource.DataSource = Me._FamilyLiteracy_mdfDataSet
        Me.FamilyLiteracymdfDataSetBindingSource.Position = 0
        '
        'ReportStudentTestMenuTableAdapter
        '
        Me.ReportStudentTestMenuTableAdapter.ClearBeforeFill = True
        '
        'ReportScheduleMenuTableAdapter
        '
        Me.ReportScheduleMenuTableAdapter.ClearBeforeFill = True
        '
        'ReportClientProfileMenuTableAdapter1
        '
        Me.ReportClientProfileMenuTableAdapter1.ClearBeforeFill = True
        '
        'ReportIDDataGridViewTextBoxColumn2
        '
        Me.ReportIDDataGridViewTextBoxColumn2.DataPropertyName = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn2.HeaderText = "ReportID"
        Me.ReportIDDataGridViewTextBoxColumn2.Name = "ReportIDDataGridViewTextBoxColumn2"
        Me.ReportIDDataGridViewTextBoxColumn2.ReadOnly = True
        Me.ReportIDDataGridViewTextBoxColumn2.Width = 65
        '
        'ReportTitleDataGridViewTextBoxColumn2
        '
        Me.ReportTitleDataGridViewTextBoxColumn2.DataPropertyName = "ReportTitle"
        Me.ReportTitleDataGridViewTextBoxColumn2.HeaderText = "ReportTitle"
        Me.ReportTitleDataGridViewTextBoxColumn2.Name = "ReportTitleDataGridViewTextBoxColumn2"
        Me.ReportTitleDataGridViewTextBoxColumn2.ReadOnly = True
        Me.ReportTitleDataGridViewTextBoxColumn2.Width = 535
        '
        'FormTitleDataGridViewTextBoxColumn
        '
        Me.FormTitleDataGridViewTextBoxColumn.DataPropertyName = "FormTitle"
        Me.FormTitleDataGridViewTextBoxColumn.HeaderText = "FormTitle"
        Me.FormTitleDataGridViewTextBoxColumn.Name = "FormTitleDataGridViewTextBoxColumn"
        Me.FormTitleDataGridViewTextBoxColumn.ReadOnly = True
        Me.FormTitleDataGridViewTextBoxColumn.Visible = False
        '
        'ReportsMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 452)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ReportsMenu"
        Me.Text = "Reports"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportStudentTestMenuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._FamilyLiteracy_mdfDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportScheduleMenuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._FamilyLiteracy_mdfDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportClientProfileMenuBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._FamilyLiteracy_mdfDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilyLiteracymdfDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportClientProfileMenuBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FamilyLiteracymdfDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _FamilyLiteracy_mdfDataSet As Familyliteracy._FamilyLiteracy_mdfDataSet
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ReportStudentTestMenuBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportStudentTestMenuTableAdapter As Familyliteracy._FamilyLiteracy_mdfDataSetTableAdapters.ReportStudentTestMenuTableAdapter
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents _FamilyLiteracy_mdfDataSet1 As Familyliteracy._FamilyLiteracy_mdfDataSet1
    Friend WithEvents ReportScheduleMenuBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportScheduleMenuTableAdapter As Familyliteracy._FamilyLiteracy_mdfDataSet1TableAdapters.ReportScheduleMenuTableAdapter
    Friend WithEvents ReportIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportTitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportTitleDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView

    Friend WithEvents ReportClientProfileMenuBindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents _FamilyLiteracy_mdfDataSet3 As Familyliteracy._FamilyLiteracy_mdfDataSet3
    Friend WithEvents ReportClientProfileMenuBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ReportClientProfileMenuTableAdapter1 As Familyliteracy._FamilyLiteracy_mdfDataSet3TableAdapters.ReportClientProfileMenuTableAdapter
    Friend WithEvents ReportIDDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportTitleDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormTitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
