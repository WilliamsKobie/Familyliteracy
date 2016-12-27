Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class SourceListing
    Implements Isources
    Private connString As Object = Nothing
    Public Sub New()

        connString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
    End Sub
    Public Function FindSources() As List(Of StoredSources) Implements Isources.FindSources
        Dim testingSources As New List(Of StoredSources)
        Dim query As String = "SELECT * FROM ReadingSources"

        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "ReadingSources")
        Dim dr As DataRow
        Dim dt As DataTable = ds.Tables("ReadingSources")
        Dim sources As String = String.Empty
        Dim sourceType As String = String.Empty
        For Each dr In dt.Rows
            sources = dr("Source")
            sourceType = dr("SourceType")
            testingSources.Add(New StoredSources(sources, sourceType))
        Next
        Return testingSources
    End Function

End Class

Public Class StoredSources
    Private _source As String = String.Empty
    Public Property Source As String
        Get
            Return _source
        End Get
        Set(value As String)
            _source = value
        End Set
    End Property

    Public Sub New(ByVal source As String, ByVal sourceCat As String)
        Me.Source = source
        Me.SourceCatagory = sourceCat
    End Sub
    Private _sourceType As String = String.Empty
    Public Property SourceCatagory As String
        Get
            Return _sourceType
        End Get
        Set(value As String)
            _sourceType = value
        End Set
    End Property

End Class
