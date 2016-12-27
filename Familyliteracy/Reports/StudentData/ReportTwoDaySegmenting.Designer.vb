<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportTwoDaySegmenting
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.SegmentingDataAttributesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StudentProfileBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FamilyLiteracymdfDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._FamilyLiteracy_mdfDataSet1 = New Familyliteracy._FamilyLiteracy_mdfDataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.StudentProfileTableAdapter = New Familyliteracy._FamilyLiteracy_mdfDataSet1TableAdapters.StudentProfileTableAdapter()
        CType(Me.SegmentingDataAttributesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StudentProfileBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FamilyLiteracymdfDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._FamilyLiteracy_mdfDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SegmentingDataAttributesBindingSource
        '
        Me.SegmentingDataAttributesBindingSource.DataSource = GetType(DAL.SegmentingDataAttributes)
        '
        'StudentProfileBindingSource
        '
        Me.StudentProfileBindingSource.DataMember = "StudentProfile"
        Me.StudentProfileBindingSource.DataSource = Me.FamilyLiteracymdfDataSet1BindingSource
        '
        'FamilyLiteracymdfDataSet1BindingSource
        '
        Me.FamilyLiteracymdfDataSet1BindingSource.DataSource = Me._FamilyLiteracy_mdfDataSet1
        Me.FamilyLiteracymdfDataSet1BindingSource.Position = 0
        '
        '_FamilyLiteracy_mdfDataSet1
        '
        Me._FamilyLiteracy_mdfDataSet1.DataSetName = "_FamilyLiteracy_mdfDataSet1"
        Me._FamilyLiteracy_mdfDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "TwoDateSegmentingData"
        ReportDataSource1.Value = Me.SegmentingDataAttributesBindingSource
        ReportDataSource2.Name = "Students"
        ReportDataSource2.Value = Me.StudentProfileBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Familyliteracy.TwoDaySegmentingData.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(27, -1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1252, 601)
        Me.ReportViewer1.TabIndex = 0
        '
        'StudentProfileTableAdapter
        '
        Me.StudentProfileTableAdapter.ClearBeforeFill = True
        '
        'ReportTwoDaySegmenting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 628)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReportTwoDaySegmenting"
        Me.Text = "Report Two Day Segmenting"
        CType(Me.SegmentingDataAttributesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StudentProfileBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FamilyLiteracymdfDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._FamilyLiteracy_mdfDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents SegmentingDataAttributesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FamilyLiteracymdfDataSet1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _FamilyLiteracy_mdfDataSet1 As Familyliteracy._FamilyLiteracy_mdfDataSet1
    Friend WithEvents StudentProfileBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StudentProfileTableAdapter As Familyliteracy._FamilyLiteracy_mdfDataSet1TableAdapters.StudentProfileTableAdapter
End Class
