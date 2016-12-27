Public Class LoadingValues

    Private Sub LoadingValues_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 200

        Me.ProgressBar1.Value = 200
        'add the progress bar to the form
        Me.Controls.Add(ProgressBar1)

        If CodeKnowledgeBlendingSegemting.Timer1.Interval <= 3000 Then
            Label1.Text = "Saving"
        ElseIf CodeKnowledgeBlendingSegemting.Timer1.Interval > 3000 Then
            Label1.Text = "Saved"
        End If
    End Sub
End Class