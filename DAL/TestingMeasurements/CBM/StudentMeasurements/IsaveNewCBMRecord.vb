Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Interface IsaveNewCBMRecord
    Function Save(ByVal studentNo As String, ByVal currentDate As Date, ByVal correctWords As Integer, ByVal numMistakes As Integer, ByVal totaltime As String, ByVal wordsCount As Integer, ByVal method As String, ByVal textSource As String, ByVal level As String, ByVal passage As String)
    Function Delete(ByVal index As String)
End Interface


Public Class SaveNewCBM
    Implements IsaveNewCBMRecord
    Function Save(ByVal studentNo As String, ByVal currentDate As Date, ByVal correctWords As Integer, ByVal numMistakes As Integer, ByVal totaltime As String, ByVal wordsCount As Integer, ByVal method As String, ByVal textSource As String, ByVal level As String, ByVal passage As String) Implements IsaveNewCBMRecord.Save
        Dim connString As Object = Nothing
        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "INSERT INTO CBMData ([StudentId],[Date],[Correct_Words_Each_Minute],[Errors],[Timed],[Word_Count],[Test_Method],[Text_Source],[Reading_Level],[Passage]) VALUES (@studentNo,@currentDate,@cwpm,@mistakes,@totalTime,@wc,@method,@source,@readinglevel,@passage)"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim timer As DateTime = CDate("01/01/1900 " & totaltime)
        cmd.Parameters.AddWithValue("@studentNo", studentNo)
        cmd.Parameters.AddWithValue("@currentDate", currentDate)
        cmd.Parameters.AddWithValue("@cwpm", correctWords)
        cmd.Parameters.AddWithValue("@mistakes", numMistakes)
        cmd.Parameters.AddWithValue("@totalTime", timer)
        cmd.Parameters.AddWithValue("@wc", wordsCount)
        cmd.Parameters.AddWithValue("@method", method)
        cmd.Parameters.AddWithValue("@source", textSource)
        cmd.Parameters.AddWithValue("@readinglevel", level)
        cmd.Parameters.AddWithValue("@passage", passage)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        Return Nothing
    End Function
    Public Function Delete(ByVal index As String) Implements IsaveNewCBMRecord.Delete
        Dim connString As Object
        connString = ConfigurationManager.ConnectionStrings("FamilyLiteracy").ConnectionString
        Dim query As String = "DELETE FROM Student_Testing_Measurements WHERE count='" & index & "'"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        Return Nothing
    End Function
End Class
