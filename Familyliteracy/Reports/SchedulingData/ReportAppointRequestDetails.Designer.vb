<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportAppointRequestDetails
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
        Me.ScheduleRequestDetailCollectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.ScheduleRequestDetailCollectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScheduleRequestDetailCollectionBindingSource
        '
        Me.ScheduleRequestDetailCollectionBindingSource.DataSource = GetType(DAL.ScheduleRequestDetailCollection)
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "AppointmentRequest"
        ReportDataSource1.Value = Me.ScheduleRequestDetailCollectionBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Familyliteracy.AppointmentRequestDetailListing.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(28, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(989, 499)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportAppointRequestDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 529)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReportAppointRequestDetails"
        Me.Text = "Scheduling Details"
        CType(Me.ScheduleRequestDetailCollectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ScheduleRequestDetailCollectionBindingSource As System.Windows.Forms.BindingSource
End Class
