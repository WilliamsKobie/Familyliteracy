Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class RemoveCodeKnowledge
    Public Shared Function CodeKnowledge(ByVal dateStamp As DateTime, ByVal studentNo As String)

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString)
        Dim query As String = "DELETE * FROM BeginningPhonic WHERE Date='" & dateStamp & "' AND StudentNo='" & studentNo & "'"

        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "BeginningPhonic")

        cmd.ExecuteNonQuery()
        Return Nothing


    End Function




    Public Shared Function Blending(ByVal dateStamp As DateTime, ByVal studentNo As String)

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString)
        Dim query As String = "DELETE * FROM Blending_2snd_Words WHERE Date='" & dateStamp & "' AND StudentNo='" & studentNo & "'"

        Dim cmd As New SqlCommand(query, conn)

        cmd.ExecuteNonQuery()
        Return Nothing

    End Function


    Public Shared Function Segmenting(ByVal dateStamp As DateTime, ByVal studentNo As String)

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString)
        Dim query As String = "DELETE * FROM Segment_2snd_Words WHERE Date='" & dateStamp & "' AND StudentNo='" & studentNo & "'"

        Dim cmd As New SqlCommand(query, conn)
     

        cmd.ExecuteNonQuery()
        Return Nothing


    End Function
End Class
