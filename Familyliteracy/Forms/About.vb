Public Class About

    Private Sub About_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Deployment.CurrentVersion.ToString)
    End Sub

   
End Class