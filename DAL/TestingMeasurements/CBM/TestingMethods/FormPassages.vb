Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic
Public Class Forms_And_Passages
    Implements Itext

    Private _source As String
    Private _forms As String


    Dim connString As Object = Nothing
    Public Sub New()

        connString = ConfigurationManager.ConnectionStrings("Familyliteracy").ConnectionString
    End Sub

    Public Function ReturnForms() As List(Of StoredListing) Implements Itext.ReturnForms

        Dim cbmList As New List(Of StoredListing)
        Dim query As String = "SELECT * FROM List"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "List")
        Dim dr As DataRow
        Dim dt As DataTable = ds.Tables("List")
        Dim sourcelvl, maxLevel, minLevel, source, index As String
        For Each dr In dt.Rows
            source = dr("Source")
            sourcelvl = dr("Source_Level").ToString
            maxLevel = dr("Maximum_Form_Level")
            minLevel = dr("Minimum_Form_Level")
            index = dr("Index")
            cbmList.Add(New StoredListing(source, maxLevel, minLevel, sourcelvl, index))
        Next

        Return cbmList
    End Function


    Public Function ReturnPassages() As List(Of StoredText) Implements Itext.ReturnPassages

        Dim cbmText As New List(Of StoredText)

        Dim query As String = "SELECT * FROM Text"
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand(query, conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "Text")
        Dim dt As DataTable = ds.Tables("Text")
        Dim dr As DataRow
        Dim grades As String = String.Empty
        Dim sPassage As String = String.Empty
        Dim fPassage As String = String.Empty
        Dim fSource As String = String.Empty
        Dim index As String = String.Empty
        For Each dr In dt.Rows
            grades = dr("Source_Level")
            sPassage = dr("Start_Passage")
            fPassage = dr("Stop_Passage")
            fSource = dr("Source")
            index = dr("Index")
            cbmText.Add(New StoredText(grades, sPassage, fPassage, fSource, index))
        Next

        Return cbmText
    End Function


End Class

Public Class StoredListing
    'Store All values for all List and their related Forms

    Public Sub New(ByVal source As String, ByVal maxforms As String, ByVal minForms As String, ByVal sourcelvl As String, newindex As String)
        Me.Source = source
        Me.MaximumFormListing = maxforms
        Me.MinimumFormListing = minForms
        Me.SourceLevels = sourcelvl
        Me.Index = newindex
    End Sub
    'Source Levels of the CBM List
    Private _sourceName As String = String.Empty
    Public Property Source() As String
        Get
            Return _sourceName
        End Get
        Set(value As String)
            _sourceName = value
        End Set
    End Property
    'Forms Numbers of the CBM List
    Private _maxformLevel As Integer = 0
    Public Property MaximumFormListing() As Integer
        Get
            Return _maxformLevel
        End Get
        Set(ByVal value As Integer)
            Dim convValue As Integer
            convValue = Convert.ToInt16(value)
            _maxformLevel = convValue
        End Set
    End Property
    Private _sourceLevels As String = String.Empty
    Public Property SourceLevels() As String
        Get
            Return _sourceLevels
        End Get
        Set(value As String)
            _sourceLevels = value
        End Set
    End Property
    Private _minformLevel As Integer = 0
    Public Property MinimumFormListing As Integer
        Get
            Return _minformLevel
        End Get
        Set(ByVal value As Integer)

            Dim convValue As Integer
            convValue = Convert.ToInt16(value)
            _minformLevel = convValue
        End Set
    End Property
    Private Property _order As Integer
    Public Property Index As String
        Get
            Return _order
        End Get
        Set(value As String)
            _order = Convert.ToInt16(value)
        End Set
    End Property



    

End Class

Public Class StoredText


    Public Sub New(ByVal gradeLvl As String, ByVal startPassage As String, ByVal stopPassage As String, ByVal textSource As String, ByVal newindex As String)

        Me.GradeLevel = gradeLvl
        Me.BeginningPassage = startPassage
        Me.FinalPassage = stopPassage
        Me.Source = textSource
        Me.Index = newindex
    End Sub
    Private _gradeLevel As String
    Private _startPassage As String
    Private _stopPassage As String
    Private _textSource As String

    Public Property GradeLevel() As String

        Get
            Return _gradeLevel
        End Get
        Set(value As String)
            _gradeLevel = value
        End Set
    End Property

    Public Property BeginningPassage() As String
        Get
            Return _startPassage
        End Get
        Set(value As String)
            _startPassage = value
        End Set
    End Property

    Public Property FinalPassage() As String
        Get
            Return _stopPassage
        End Get
        Set(value As String)
            _stopPassage = value
        End Set
    End Property
    Public Property Source() As String
        Get
            Return _textSource
        End Get
        Set(value As String)
            _textSource = value
        End Set
    End Property
    Public Property _order As Integer
    Public Property Index As String
        Get
            Return _order
        End Get
        Set(value As String)
            _order = Convert.ToInt16(value)
        End Set
    End Property


End Class





