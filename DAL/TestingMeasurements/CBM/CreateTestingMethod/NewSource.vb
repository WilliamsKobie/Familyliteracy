Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Collections
Imports DAL.FamilyLiteracyEntityDataModel


Public Class CreateSources

    Public Shared Function SaveSource(ByVal source As String, ByVal type As String)
        Dim dre As New FamilyLiteracyEntityDataModel
        Dim sourceValue As New ReadingSource
        sourceValue.Source = source
        sourceValue.Sourcetype = type
        dre.ReadingSources.Add(sourceValue)
        dre.SaveChanges()
        Return Nothing
    End Function

    Public Shared Function DeleteSource(ByVal source As String)

        Return Nothing
    End Function


End Class
